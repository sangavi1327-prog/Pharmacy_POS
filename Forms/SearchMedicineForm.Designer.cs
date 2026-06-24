using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class SearchMedicineForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlSearchControls;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblMinPrice;
        private TextBox txtMinPrice;
        private Label lblMaxPrice;
        private TextBox txtMaxPrice;
        private Button btnSearch;
        private Label lblSort;
        private ComboBox cmbSort;
        private DataGridView dgvSearch;
        private Panel pnlCartAction;
        private Label lblSelectedLabel;
        private Label lblSelectedMed;
        private Label lblQtyLabel;
        private NumericUpDown numQuantity;
        private Button btnAddToCart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSearchControls = new Panel();
            this.lblKeyword = new Label();
            this.txtKeyword = new TextBox();
            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();
            this.lblMinPrice = new Label();
            this.txtMinPrice = new TextBox();
            this.lblMaxPrice = new Label();
            this.txtMaxPrice = new TextBox();
            this.btnSearch = new Button();
            this.lblSort = new Label();
            this.cmbSort = new ComboBox();
            this.dgvSearch = new DataGridView();
            this.pnlCartAction = new Panel();
            this.lblSelectedLabel = new Label();
            this.lblSelectedMed = new Label();
            this.lblQtyLabel = new Label();
            this.numQuantity = new NumericUpDown();
            this.btnAddToCart = new Button();

            this.pnlSearchControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.pnlCartAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();

            // pnlSearchControls (Top Panel)
            this.pnlSearchControls.BackColor = Color.FromArgb(240, 244, 248);
            this.pnlSearchControls.Controls.Add(this.cmbSort);
            this.pnlSearchControls.Controls.Add(this.lblSort);
            this.pnlSearchControls.Controls.Add(this.btnSearch);
            this.pnlSearchControls.Controls.Add(this.txtMaxPrice);
            this.pnlSearchControls.Controls.Add(this.lblMaxPrice);
            this.pnlSearchControls.Controls.Add(this.txtMinPrice);
            this.pnlSearchControls.Controls.Add(this.lblMinPrice);
            this.pnlSearchControls.Controls.Add(this.cmbCategory);
            this.pnlSearchControls.Controls.Add(this.lblCategory);
            this.pnlSearchControls.Controls.Add(this.txtKeyword);
            this.pnlSearchControls.Controls.Add(this.lblKeyword);
            this.pnlSearchControls.Dock = DockStyle.Top;
            this.pnlSearchControls.Location = new Point(0, 0);
            this.pnlSearchControls.Name = "pnlSearchControls";
            this.pnlSearchControls.Size = new Size(900, 75);
            this.pnlSearchControls.TabIndex = 0;

            // lblKeyword
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblKeyword.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblKeyword.Location = new Point(15, 15);
            this.lblKeyword.Text = "Keyword Search";

            // txtKeyword
            this.txtKeyword.Font = new Font("Segoe UI", 9F);
            this.txtKeyword.Location = new Point(15, 38);
            this.txtKeyword.Size = new Size(160, 23);

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblCategory.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblCategory.Location = new Point(190, 15);
            this.lblCategory.Text = "Category";

            // cmbCategory
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new Font("Segoe UI", 9F);
            this.cmbCategory.Location = new Point(190, 38);
            this.cmbCategory.Size = new Size(130, 23);

            // lblMinPrice
            this.lblMinPrice.AutoSize = true;
            this.lblMinPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblMinPrice.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblMinPrice.Location = new Point(335, 15);
            this.lblMinPrice.Text = "Min Price ($)";

            // txtMinPrice
            this.txtMinPrice.Font = new Font("Segoe UI", 9F);
            this.txtMinPrice.Location = new Point(335, 38);
            this.txtMinPrice.Size = new Size(70, 23);

            // lblMaxPrice
            this.lblMaxPrice.AutoSize = true;
            this.lblMaxPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblMaxPrice.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblMaxPrice.Location = new Point(415, 15);
            this.lblMaxPrice.Text = "Max Price ($)";

            // txtMaxPrice
            this.txtMaxPrice.Font = new Font("Segoe UI", 9F);
            this.txtMaxPrice.Location = new Point(415, 38);
            this.txtMaxPrice.Size = new Size(70, 23);

            // btnSearch
            this.btnSearch.BackColor = Color.FromArgb(0, 128, 128);
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new Point(505, 35);
            this.btnSearch.Size = new Size(95, 27);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // lblSort
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblSort.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblSort.Location = new Point(620, 15);
            this.lblSort.Text = "Sort Results By";

            // cmbSort
            this.cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new Font("Segoe UI", 9F);
            this.cmbSort.Location = new Point(620, 38);
            this.cmbSort.Size = new Size(150, 23);
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            // dgvSearch
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.BackgroundColor = Color.White;
            this.dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Dock = DockStyle.Fill;
            this.dgvSearch.Location = new Point(0, 75);
            this.dgvSearch.MultiSelect = false;
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.Size = new Size(900, 360);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellClick);

            // pnlCartAction (Bottom Panel)
            this.pnlCartAction.BackColor = Color.White;
            this.pnlCartAction.Controls.Add(this.btnAddToCart);
            this.pnlCartAction.Controls.Add(this.numQuantity);
            this.pnlCartAction.Controls.Add(this.lblQtyLabel);
            this.pnlCartAction.Controls.Add(this.lblSelectedMed);
            this.pnlCartAction.Controls.Add(this.lblSelectedLabel);
            this.pnlCartAction.Dock = DockStyle.Bottom;
            this.pnlCartAction.Location = new Point(0, 435);
            this.pnlCartAction.Name = "pnlCartAction";
            this.pnlCartAction.Size = new Size(900, 65);
            this.pnlCartAction.TabIndex = 2;

            // lblSelectedLabel
            this.lblSelectedLabel.AutoSize = true;
            this.lblSelectedLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.lblSelectedLabel.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSelectedLabel.Location = new Point(15, 23);
            this.lblSelectedLabel.Text = "Selected Item:";

            // lblSelectedMed
            this.lblSelectedMed.AutoSize = true;
            this.lblSelectedMed.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            this.lblSelectedMed.ForeColor = Color.FromArgb(0, 128, 128);
            this.lblSelectedMed.Location = new Point(115, 21);
            this.lblSelectedMed.Text = "None Selected";

            // lblQtyLabel
            this.lblQtyLabel.AutoSize = true;
            this.lblQtyLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.lblQtyLabel.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblQtyLabel.Location = new Point(480, 23);
            this.lblQtyLabel.Text = "Quantity:";

            // numQuantity
            this.numQuantity.Font = new Font("Segoe UI", 10F);
            this.numQuantity.Location = new Point(545, 21);
            this.numQuantity.Size = new Size(70, 25);
            this.numQuantity.TabIndex = 3;

            // btnAddToCart
            this.btnAddToCart.BackColor = Color.FromArgb(0, 128, 128);
            this.btnAddToCart.FlatStyle = FlatStyle.Flat;
            this.btnAddToCart.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnAddToCart.ForeColor = Color.White;
            this.btnAddToCart.Location = new Point(635, 16);
            this.btnAddToCart.Size = new Size(245, 33);
            this.btnAddToCart.TabIndex = 4;
            this.btnAddToCart.Text = "🛒 Add Selected Item to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            // SearchMedicineForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ClientSize = new Size(900, 500);
            this.Controls.Add(this.dgvSearch);
            this.Controls.Add(this.pnlCartAction);
            this.Controls.Add(this.pnlSearchControls);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SearchMedicineForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SmartMed Pharmacy - Browse Medicines";
            this.Load += new System.EventHandler(this.SearchMedicineForm_Load);
            this.pnlSearchControls.ResumeLayout(false);
            this.pnlSearchControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.pnlCartAction.ResumeLayout(false);
            this.pnlCartAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
