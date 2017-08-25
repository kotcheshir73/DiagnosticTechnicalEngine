namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormClustering
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
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonLoadFromTxt = new System.Windows.Forms.Button();
            this.buttonLoadFromExcel = new System.Windows.Forms.Button();
            this.textBoxCountClusters = new System.Windows.Forms.TextBox();
            this.labelCountClusters = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMinVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaxVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxSettings.SuspendLayout();
            this.panel.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.buttonLoadFromTxt);
            this.groupBoxSettings.Controls.Add(this.buttonLoadFromExcel);
            this.groupBoxSettings.Controls.Add(this.textBoxCountClusters);
            this.groupBoxSettings.Controls.Add(this.labelCountClusters);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSettings.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(384, 100);
            this.groupBoxSettings.TabIndex = 0;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Настройки";
            // 
            // buttonLoadFromTxt
            // 
            this.buttonLoadFromTxt.Location = new System.Drawing.Point(189, 61);
            this.buttonLoadFromTxt.Name = "buttonLoadFromTxt";
            this.buttonLoadFromTxt.Size = new System.Drawing.Size(150, 23);
            this.buttonLoadFromTxt.TabIndex = 3;
            this.buttonLoadFromTxt.Text = "Загрузить ряд из txt";
            this.buttonLoadFromTxt.UseVisualStyleBackColor = true;
            this.buttonLoadFromTxt.Click += new System.EventHandler(this.buttonLoadFromTxt_Click);
            // 
            // buttonLoadFromExcel
            // 
            this.buttonLoadFromExcel.Location = new System.Drawing.Point(15, 61);
            this.buttonLoadFromExcel.Name = "buttonLoadFromExcel";
            this.buttonLoadFromExcel.Size = new System.Drawing.Size(150, 23);
            this.buttonLoadFromExcel.TabIndex = 2;
            this.buttonLoadFromExcel.Text = "Загрузить ряд из Excel";
            this.buttonLoadFromExcel.UseVisualStyleBackColor = true;
            this.buttonLoadFromExcel.Click += new System.EventHandler(this.buttonLoadFromExcel_Click);
            // 
            // textBoxCountClusters
            // 
            this.textBoxCountClusters.Location = new System.Drawing.Point(289, 23);
            this.textBoxCountClusters.MaxLength = 2;
            this.textBoxCountClusters.Name = "textBoxCountClusters";
            this.textBoxCountClusters.Size = new System.Drawing.Size(50, 20);
            this.textBoxCountClusters.TabIndex = 1;
            this.textBoxCountClusters.Text = "5";
            this.textBoxCountClusters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelCountClusters
            // 
            this.labelCountClusters.AutoSize = true;
            this.labelCountClusters.Location = new System.Drawing.Point(12, 26);
            this.labelCountClusters.Name = "labelCountClusters";
            this.labelCountClusters.Size = new System.Drawing.Size(271, 13);
            this.labelCountClusters.TabIndex = 0;
            this.labelCountClusters.Text = "Количество кластеров (рекомендуется не менее 5):";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonApply);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(3, 288);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(378, 31);
            this.panel.TabIndex = 1;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonApply.Location = new System.Drawing.Point(275, 4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(100, 23);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Применить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.dataGridView);
            this.groupBox.Controls.Add(this.panel);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 100);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(384, 322);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Нечеткие метки";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnWeight,
            this.ColumnMinVal,
            this.ColumnCenter,
            this.ColumnMaxVal});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 16);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(378, 272);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Название";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 150;
            // 
            // ColumnWeight
            // 
            this.ColumnWeight.HeaderText = "Вес";
            this.ColumnWeight.Name = "ColumnWeight";
            this.ColumnWeight.Width = 50;
            // 
            // ColumnMinVal
            // 
            this.ColumnMinVal.HeaderText = "Мин";
            this.ColumnMinVal.Name = "ColumnMinVal";
            this.ColumnMinVal.Width = 50;
            // 
            // ColumnCenter
            // 
            this.ColumnCenter.HeaderText = "Центр";
            this.ColumnCenter.Name = "ColumnCenter";
            this.ColumnCenter.Width = 50;
            // 
            // ColumnMaxVal
            // 
            this.ColumnMaxVal.HeaderText = "Макс";
            this.ColumnMaxVal.Name = "ColumnMaxVal";
            this.ColumnMaxVal.Width = 50;
            // 
            // FormClustering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 422);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.groupBoxSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClustering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кластеризация ряда";
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.panel.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TextBox textBoxCountClusters;
        private System.Windows.Forms.Label labelCountClusters;
        private System.Windows.Forms.Button buttonLoadFromExcel;
        private System.Windows.Forms.Button buttonLoadFromTxt;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMinVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaxVal;
    }
}