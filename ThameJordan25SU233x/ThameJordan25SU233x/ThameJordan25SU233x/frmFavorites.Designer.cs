namespace ThameJordan25SU233x
{
    partial class frmFavorites
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvFavorites = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnRemoveFavorite = new System.Windows.Forms.Button();
            this.btnRequestReorder = new System.Windows.Forms.Button();
            this.btnViewMyRequests = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.tbxNotes = new System.Windows.Forms.TextBox();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.lblQty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavorites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 25);
            this.lblTitle.Text = "My Saved Items";

            // dgvFavorites
            this.dgvFavorites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFavorites.Location = new System.Drawing.Point(15, 50);
            this.dgvFavorites.Name = "dgvFavorites";
            this.dgvFavorites.Size = new System.Drawing.Size(720, 400);
            this.dgvFavorites.TabIndex = 0;
            this.dgvFavorites.ReadOnly = true;
            this.dgvFavorites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFavorites.MultiSelect = false;
            this.dgvFavorites.AllowUserToAddRows = false;
            this.dgvFavorites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // lblQty
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(15, 462);
            this.lblQty.Name = "lblQty";
            this.lblQty.Text = "Qty for reorder:";

            // nudQty
            this.nudQty.Location = new System.Drawing.Point(110, 458);
            this.nudQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQty.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(60, 20);
            this.nudQty.TabIndex = 1;

            // lblNotes
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(15, 490);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Text = "Reorder notes (optional):";

            // tbxNotes
            this.tbxNotes.Location = new System.Drawing.Point(15, 508);
            this.tbxNotes.Name = "tbxNotes";
            this.tbxNotes.Size = new System.Drawing.Size(720, 20);
            this.tbxNotes.TabIndex = 2;

            // btnAddToCart
            this.btnAddToCart.Location = new System.Drawing.Point(15, 545);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(140, 30);
            this.btnAddToCart.TabIndex = 3;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            // btnRemoveFavorite
            this.btnRemoveFavorite.Location = new System.Drawing.Point(165, 545);
            this.btnRemoveFavorite.Name = "btnRemoveFavorite";
            this.btnRemoveFavorite.Size = new System.Drawing.Size(140, 30);
            this.btnRemoveFavorite.TabIndex = 4;
            this.btnRemoveFavorite.Text = "Remove Favorite";
            this.btnRemoveFavorite.UseVisualStyleBackColor = true;
            this.btnRemoveFavorite.Click += new System.EventHandler(this.btnRemoveFavorite_Click);

            // btnRequestReorder
            this.btnRequestReorder.Location = new System.Drawing.Point(315, 545);
            this.btnRequestReorder.Name = "btnRequestReorder";
            this.btnRequestReorder.Size = new System.Drawing.Size(160, 30);
            this.btnRequestReorder.TabIndex = 5;
            this.btnRequestReorder.Text = "Submit Reorder Request";
            this.btnRequestReorder.UseVisualStyleBackColor = true;
            this.btnRequestReorder.Click += new System.EventHandler(this.btnRequestReorder_Click);

            // btnViewMyRequests
            this.btnViewMyRequests.Location = new System.Drawing.Point(485, 545);
            this.btnViewMyRequests.Name = "btnViewMyRequests";
            this.btnViewMyRequests.Size = new System.Drawing.Size(130, 30);
            this.btnViewMyRequests.TabIndex = 6;
            this.btnViewMyRequests.Text = "My Requests";
            this.btnViewMyRequests.UseVisualStyleBackColor = true;
            this.btnViewMyRequests.Click += new System.EventHandler(this.btnViewMyRequests_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(625, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // frmFavorites
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 592);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvFavorites);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.tbxNotes);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.btnRemoveFavorite);
            this.Controls.Add(this.btnRequestReorder);
            this.Controls.Add(this.btnViewMyRequests);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFavorites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Saved Items";
            this.Load += new System.EventHandler(this.frmFavorites_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavorites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFavorites;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnRemoveFavorite;
        private System.Windows.Forms.Button btnRequestReorder;
        private System.Windows.Forms.Button btnViewMyRequests;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox tbxNotes;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Label lblQty;
    }
}
