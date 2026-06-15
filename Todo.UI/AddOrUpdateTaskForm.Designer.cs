namespace Todo.UI
{
    partial class AddOrUpdateTaskForm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.headerLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLbl = new System.Windows.Forms.Label();
            this.priorityLbl = new System.Windows.Forms.Label();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.dueDateLbl = new System.Windows.Forms.Label();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.statusLbl = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(10, 337);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(155, 27);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(171, 337);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(155, 27);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Отменить";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(11, 28);
            this.titleTextBox.MaxLength = 200;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(313, 20);
            this.titleTextBox.TabIndex = 2;
            // 
            // headerLbl
            // 
            this.headerLbl.AutoSize = true;
            this.headerLbl.Location = new System.Drawing.Point(12, 12);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(68, 13);
            this.headerLbl.TabIndex = 3;
            this.headerLbl.Text = "* Заголовок";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Описание";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(11, 67);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(313, 55);
            this.descriptionTextBox.TabIndex = 5;
            this.descriptionTextBox.Text = "";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(11, 141);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(314, 21);
            this.categoryComboBox.TabIndex = 6;
            // 
            // categoryLbl
            // 
            this.categoryLbl.AutoSize = true;
            this.categoryLbl.Location = new System.Drawing.Point(12, 125);
            this.categoryLbl.Name = "categoryLbl";
            this.categoryLbl.Size = new System.Drawing.Size(60, 13);
            this.categoryLbl.TabIndex = 7;
            this.categoryLbl.Text = "Категория";
            // 
            // priorityLbl
            // 
            this.priorityLbl.AutoSize = true;
            this.priorityLbl.Location = new System.Drawing.Point(14, 169);
            this.priorityLbl.Name = "priorityLbl";
            this.priorityLbl.Size = new System.Drawing.Size(68, 13);
            this.priorityLbl.TabIndex = 8;
            this.priorityLbl.Text = "* Приоритет";
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.Location = new System.Drawing.Point(11, 185);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(314, 21);
            this.priorityComboBox.TabIndex = 9;
            // 
            // dueDateLbl
            // 
            this.dueDateLbl.AutoSize = true;
            this.dueDateLbl.Location = new System.Drawing.Point(12, 209);
            this.dueDateLbl.Name = "dueDateLbl";
            this.dueDateLbl.Size = new System.Drawing.Size(96, 13);
            this.dueDateLbl.TabIndex = 10;
            this.dueDateLbl.Text = "* Дата окончания";
            // 
            // dueDatePicker
            // 
            this.dueDatePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDatePicker.Location = new System.Drawing.Point(11, 225);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(313, 20);
            this.dueDatePicker.TabIndex = 11;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(12, 248);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(48, 13);
            this.statusLbl.TabIndex = 12;
            this.statusLbl.Text = "* Статус";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(10, 264);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(313, 21);
            this.statusComboBox.TabIndex = 13;
            // 
            // AddOrUpdateTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 374);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.dueDatePicker);
            this.Controls.Add(this.dueDateLbl);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.priorityLbl);
            this.Controls.Add(this.categoryLbl);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.headerLbl);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrUpdateTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление/редактирование задачи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label categoryLbl;
        private System.Windows.Forms.Label priorityLbl;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.Label dueDateLbl;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.ComboBox statusComboBox;
    }
}