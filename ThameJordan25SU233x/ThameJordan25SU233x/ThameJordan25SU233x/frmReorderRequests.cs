using System;
using System.Data;
using System.Windows.Forms;

namespace ThameJordan25SU233x
{
    public partial class frmReorderRequests : Form
    {
        public frmReorderRequests()
        {
            InitializeComponent();
        }

        private void frmReorderRequests_Load(object sender, EventArgs e)
        {
            RefreshRequests();
        }

        // Load all reorder requests into the top grid
        private void RefreshRequests()
        {
            DataTable dt = clsSQL.GetAllReorderRequests();
            dgvRequests.DataSource = dt;

            if (dgvRequests.Columns.Contains("RequestID"))
                dgvRequests.Columns["RequestID"].HeaderText = "Request #";
            if (dgvRequests.Columns.Contains("CustomerName"))
                dgvRequests.Columns["CustomerName"].HeaderText = "Customer";
            if (dgvRequests.Columns.Contains("RequestDate"))
                dgvRequests.Columns["RequestDate"].HeaderText = "Date";
            if (dgvRequests.Columns.Contains("Status"))
                dgvRequests.Columns["Status"].HeaderText = "Status";
            if (dgvRequests.Columns.Contains("Notes"))
                dgvRequests.Columns["Notes"].HeaderText = "Notes";
            if (dgvRequests.Columns.Contains("ItemCount"))
                dgvRequests.Columns["ItemCount"].HeaderText = "# Items";

            dgvRequests.RowHeadersVisible = false;
            dgvRequestItems.DataSource = null;
            UpdateButtonState();
        }

        // When a request row is selected, load its line items
        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null) return;

            int requestID = Convert.ToInt32(dgvRequests.CurrentRow.Cells["RequestID"].Value);
            DataTable items = clsSQL.GetReorderRequestItems(requestID);
            dgvRequestItems.DataSource = items;

            if (dgvRequestItems.Columns.Contains("ItemName"))
                dgvRequestItems.Columns["ItemName"].HeaderText = "Product";
            if (dgvRequestItems.Columns.Contains("RequestedQty"))
                dgvRequestItems.Columns["RequestedQty"].HeaderText = "Qty Requested";
            if (dgvRequestItems.Columns.Contains("UnitPrice"))
                dgvRequestItems.Columns["UnitPrice"].HeaderText = "Unit Price";
            if (dgvRequestItems.Columns.Contains("InStock"))
                dgvRequestItems.Columns["InStock"].HeaderText = "Currently In Stock";

            dgvRequestItems.RowHeadersVisible = false;
            UpdateButtonState();
        }

        // Enables Fulfill/Cancel only for Pending requests
        private void UpdateButtonState()
        {
            bool isPending = false;
            if (dgvRequests.CurrentRow != null)
            {
                string status = dgvRequests.CurrentRow.Cells["Status"].Value?.ToString() ?? "";
                isPending = status == "Pending";
            }
            btnFulfill.Enabled = isPending;
            btnCancel.Enabled = isPending;
        }

        // Mark the selected request as Fulfilled
        private void btnFulfill_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null) return;

            int requestID = Convert.ToInt32(dgvRequests.CurrentRow.Cells["RequestID"].Value);
            string customer = dgvRequests.CurrentRow.Cells["CustomerName"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Mark request #{requestID} for \"{customer}\" as Fulfilled?",
                "Fulfill Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            if (clsSQL.UpdateReorderRequestStatus(requestID, 1))
            {
                MessageBox.Show("Request marked as Fulfilled.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshRequests();
            }
            else
            {
                MessageBox.Show("Failed to update the request status.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mark the selected request as Cancelled
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null) return;

            int requestID = Convert.ToInt32(dgvRequests.CurrentRow.Cells["RequestID"].Value);
            string customer = dgvRequests.CurrentRow.Cells["CustomerName"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Cancel request #{requestID} for \"{customer}\"?",
                "Cancel Request", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            if (clsSQL.UpdateReorderRequestStatus(requestID, 2))
            {
                MessageBox.Show("Request has been cancelled.", "Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshRequests();
            }
            else
            {
                MessageBox.Show("Failed to cancel the request.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshRequests();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
