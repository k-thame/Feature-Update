namespace ThameJordan25SU233x
{
    partial class frmReorderRequests
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
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.dgvRequestItems = new System.Windows.Forms.DataGridView();
            this.lblRequests = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnFulfill = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestItems)).BeginInit();
            this.SuspendLayout();

            // lblRequests
            this.lblRequests.AutoSize = true;
            this.lblRequests.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRequests.Location = new System.Drawing.Point(12, 12);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Text = "Customer Reorder Requests";

            // dgvRequests
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(15, 35);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.Size = new System.Drawing.Size(860, 280);
            this.dgvRequests.TabIndex = 0;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.SelectionChanged += new System.EventHandler(this.dgvRequests_SelectionChanged);

            // lblItems
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblItems.Location = new System.Drawing.Point(12, 328);
            this.lblItems.Name = "lblItems";
            this.lblItems.Text = "Items in Selected Request";

            // dgvRequestItems
            this.dgvRequestItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestItems.Location = new System.Drawing.Point(15, 350);
            this.dgvRequestItems.Name = "dgvRequestItems";
            this.dgvRequestItems.Size = new System.Drawing.Size(860, 200);
            this.dgvRequestItems.TabIndex = 1;
            this.dgvRequestItems.ReadOnly = true;
            this.dgvRequestItems.AllowUserToAddRows = false;
            this.dgvRequestItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // btnFulfill
            this.btnFulfill.Location = new System.Drawing.Point(15, 565);
            this.btnFulfill.Name = "btnFulfill";
            this.btnFulfill.Size = new System.Drawing.Size(130, 30);
            this.btnFulfill.TabIndex = 2;
            this.btnFulfill.Text = "Mark as Fulfilled";
            this.btnFulfill.UseVisualStyleBackColor = true;
            this.btnFulfill.Click += new System.EventHandler(this.btnFulfill_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(155, 565);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel Request";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(630, 565);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(750, 565);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // frmReorderRequests
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 612);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.dgvRequestItems);
            this.Controls.Add(this.btnFulfill);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReorderRequests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reorder Requests";
            this.Load += new System.EventHandler(this.frmReorderRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.DataGridView dgvRequestItems;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnFulfill;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}
