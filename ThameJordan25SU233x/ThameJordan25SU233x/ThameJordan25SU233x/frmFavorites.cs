using ACS_JThameM7;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ThameJordan25SU233x
{
    public partial class frmFavorites : Form
    {
        private readonly int _personID;

        // Items the customer chose to send back to the shopping cart
        public List<clsCartItem> ItemsToAddToCart { get; private set; } = new List<clsCartItem>();

        public frmFavorites(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void frmFavorites_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        // Reload the favorites grid from the database
        private void RefreshGrid()
        {
            DataTable dt = clsSQL.GetFavorites(_personID);
            dgvFavorites.DataSource = dt;

            if (dgvFavorites.Columns.Contains("FavoriteID"))
                dgvFavorites.Columns["FavoriteID"].Visible = false;
            if (dgvFavorites.Columns.Contains("InventoryID"))
                dgvFavorites.Columns["InventoryID"].Visible = false;
            if (dgvFavorites.Columns.Contains("ItemName"))
                dgvFavorites.Columns["ItemName"].HeaderText = "Product Name";
            if (dgvFavorites.Columns.Contains("Price"))
                dgvFavorites.Columns["Price"].HeaderText = "Unit Price";
            if (dgvFavorites.Columns.Contains("InStock"))
                dgvFavorites.Columns["InStock"].HeaderText = "In Stock";
            if (dgvFavorites.Columns.Contains("Availability"))
                dgvFavorites.Columns["Availability"].HeaderText = "Status";
            if (dgvFavorites.Columns.Contains("DateAdded"))
                dgvFavorites.Columns["DateAdded"].HeaderText = "Saved On";

            dgvFavorites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFavorites.RowHeadersVisible = false;

            bool hasItems = dgvFavorites.Rows.Count > 0;
            btnAddToCart.Enabled = hasItems;
            btnRemoveFavorite.Enabled = hasItems;
            btnRequestReorder.Enabled = hasItems;
        }

        // Add the selected favorite item to the shopping cart
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvFavorites.CurrentRow == null)
            {
                MessageBox.Show("Please select an item from your favorites list.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvFavorites.CurrentRow;
            string availability = row.Cells["Availability"].Value?.ToString() ?? "";

            if (availability != "Available")
            {
                MessageBox.Show("This item is currently not available and cannot be added to your cart.",
                    "Item Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int inventoryID = Convert.ToInt32(row.Cells["InventoryID"].Value);
            string itemName = row.Cells["ItemName"].Value?.ToString() ?? "";
            int inStock = Convert.ToInt32(row.Cells["InStock"].Value);
            int qty = (int)nudQty.Value;

            if (qty > inStock)
            {
                MessageBox.Show($"Only {inStock} unit(s) are available. Please reduce the quantity.",
                    "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string priceText = (row.Cells["Price"].Value?.ToString() ?? "0").Replace("$", "");
            decimal.TryParse(priceText, out decimal price);

            ItemsToAddToCart.Add(new clsCartItem(inventoryID, itemName, price, qty, inStock));
            MessageBox.Show($"\"{itemName}\" (x{qty}) has been added to your cart.",
                "Added to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Remove the selected item from favorites
        private void btnRemoveFavorite_Click(object sender, EventArgs e)
        {
            if (dgvFavorites.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string itemName = dgvFavorites.CurrentRow.Cells["ItemName"].Value?.ToString() ?? "this item";
            var confirm = MessageBox.Show($"Remove \"{itemName}\" from your saved items?",
                "Remove Favorite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int inventoryID = Convert.ToInt32(dgvFavorites.CurrentRow.Cells["InventoryID"].Value);
            if (clsSQL.RemoveFavorite(_personID, inventoryID))
            {
                MessageBox.Show($"\"{itemName}\" has been removed from your saved items.",
                    "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Could not remove the item. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Submit a reorder request for the selected favorite item
        private void btnRequestReorder_Click(object sender, EventArgs e)
        {
            if (dgvFavorites.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to request a reorder for.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int inventoryID = Convert.ToInt32(dgvFavorites.CurrentRow.Cells["InventoryID"].Value);
            string itemName = dgvFavorites.CurrentRow.Cells["ItemName"].Value?.ToString() ?? "";
            int qty = (int)nudQty.Value;
            string notes = tbxNotes.Text.Trim();

            var confirm = MessageBox.Show(
                $"Submit a reorder request for:\n\n  {itemName} x{qty}\n\nA manager will process your request.",
                "Confirm Reorder Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var items = new List<(int, int)> { (inventoryID, qty) };
            if (clsSQL.SubmitReorderRequest(_personID, items, notes))
            {
                MessageBox.Show("Your reorder request has been submitted successfully.\nA manager will process it shortly.",
                    "Request Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxNotes.Clear();
            }
            else
            {
                MessageBox.Show("Failed to submit the reorder request. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Show the customer's past reorder requests
        private void btnViewMyRequests_Click(object sender, EventArgs e)
        {
            DataTable dt = clsSQL.GetReorderRequestsForCustomer(_personID);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("You have not submitted any reorder requests yet.", "My Requests",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string summary = "Your Reorder Requests:\n\n";
            foreach (DataRow row in dt.Rows)
            {
                string date = Convert.ToString(row["RequestDate"]);
                string status = Convert.ToString(row["Status"]);
                string count = Convert.ToString(row["ItemCount"]);
                string notes = Convert.ToString(row["Notes"]);
                summary += $"• {date}  |  Status: {status}  |  Items: {count}";
                if (!string.IsNullOrWhiteSpace(notes)) summary += $"  |  Notes: {notes}";
                summary += "\n";
            }

            MessageBox.Show(summary, "My Reorder Requests", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
