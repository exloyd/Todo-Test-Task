namespace Todo.UI
{
    partial class CategoriesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoriesGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusLabel = new System.Windows.Forms.Label();
            this.deleteCategoryBtn = new System.Windows.Forms.Button();
            this.addCategoryBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // categoriesGridView
            // 
            this.categoriesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categoriesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameColumn,
            this.CreatedAt,
            this.UpdatedAt});
            this.categoriesGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.categoriesGridView.Location = new System.Drawing.Point(0, 40);
            this.categoriesGridView.Name = "categoriesGridView";
            this.categoriesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoriesGridView.Size = new System.Drawing.Size(717, 329);
            this.categoriesGridView.TabIndex = 0;
            this.categoriesGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCategoryDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "NameColumn";
            this.NameColumn.HeaderText = "Наименование";
            this.NameColumn.Name = "NameColumn";
            // 
            // CreatedAt
            // 
            this.CreatedAt.DataPropertyName = "CreatedAt";
            this.CreatedAt.HeaderText = "Дата создания";
            this.CreatedAt.Name = "CreatedAt";
            // 
            // UpdatedAt
            // 
            this.UpdatedAt.DataPropertyName = "UpdatedAt";
            this.UpdatedAt.HeaderText = "Дата обновления";
            this.UpdatedAt.Name = "UpdatedAt";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(12, 14);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(46, 15);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Всего: ";
            // 
            // deleteCategoryBtn
            // 
            this.deleteCategoryBtn.Location = new System.Drawing.Point(548, 11);
            this.deleteCategoryBtn.Name = "deleteCategoryBtn";
            this.deleteCategoryBtn.Size = new System.Drawing.Size(157, 23);
            this.deleteCategoryBtn.TabIndex = 8;
            this.deleteCategoryBtn.Text = "Удалить категорию";
            this.deleteCategoryBtn.UseVisualStyleBackColor = true;
            this.deleteCategoryBtn.Click += new System.EventHandler(this.OnCategoryDeleteClick);
            // 
            // addCategoryBtn
            // 
            this.addCategoryBtn.Location = new System.Drawing.Point(385, 11);
            this.addCategoryBtn.Name = "addCategoryBtn";
            this.addCategoryBtn.Size = new System.Drawing.Size(157, 23);
            this.addCategoryBtn.TabIndex = 7;
            this.addCategoryBtn.Text = "Добавить категорию";
            this.addCategoryBtn.UseVisualStyleBackColor = true;
            this.addCategoryBtn.Click += new System.EventHandler(this.OnAddCategoryClick);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 369);
            this.Controls.Add(this.deleteCategoryBtn);
            this.Controls.Add(this.addCategoryBtn);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.categoriesGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoriesForm";
            this.Text = "Управление категориями";
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView categoriesGridView;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedAt;
        private System.Windows.Forms.Button deleteCategoryBtn;
        private System.Windows.Forms.Button addCategoryBtn;
    }
}