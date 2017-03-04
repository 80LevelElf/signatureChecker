namespace CheckerUI
{
	partial class MainForm
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageRawData = new System.Windows.Forms.TabPage();
			this.buttonPrepareAllSignatures = new System.Windows.Forms.Button();
			this.panelRawDataPreview = new System.Windows.Forms.Panel();
			this.listBoxRawData = new System.Windows.Forms.ListBox();
			this.tabPageData = new System.Windows.Forms.TabPage();
			this.buttonRefreshData = new System.Windows.Forms.Button();
			this.panelDataPreview = new System.Windows.Forms.Panel();
			this.listBoxData = new System.Windows.Forms.ListBox();
			this.tabPageLearning = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.nudUserId = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nudImageSize = new System.Windows.Forms.NumericUpDown();
			this.btnStartLearning = new System.Windows.Forms.Button();
			this.txtLearingOutput = new System.Windows.Forms.RichTextBox();
			this.tabControl.SuspendLayout();
			this.tabPageRawData.SuspendLayout();
			this.tabPageData.SuspendLayout();
			this.tabPageLearning.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudUserId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageSize)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageRawData);
			this.tabControl.Controls.Add(this.tabPageData);
			this.tabControl.Controls.Add(this.tabPageLearning);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(696, 556);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageRawData
			// 
			this.tabPageRawData.BackColor = System.Drawing.Color.Gainsboro;
			this.tabPageRawData.Controls.Add(this.nudImageSize);
			this.tabPageRawData.Controls.Add(this.label2);
			this.tabPageRawData.Controls.Add(this.buttonPrepareAllSignatures);
			this.tabPageRawData.Controls.Add(this.panelRawDataPreview);
			this.tabPageRawData.Controls.Add(this.listBoxRawData);
			this.tabPageRawData.Location = new System.Drawing.Point(4, 25);
			this.tabPageRawData.Name = "tabPageRawData";
			this.tabPageRawData.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRawData.Size = new System.Drawing.Size(688, 527);
			this.tabPageRawData.TabIndex = 0;
			this.tabPageRawData.Text = "Обработка сырых данных";
			// 
			// buttonPrepareAllSignatures
			// 
			this.buttonPrepareAllSignatures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPrepareAllSignatures.Location = new System.Drawing.Point(482, 486);
			this.buttonPrepareAllSignatures.Name = "buttonPrepareAllSignatures";
			this.buttonPrepareAllSignatures.Size = new System.Drawing.Size(198, 33);
			this.buttonPrepareAllSignatures.TabIndex = 3;
			this.buttonPrepareAllSignatures.Text = "Подготовить все подписи";
			this.buttonPrepareAllSignatures.UseVisualStyleBackColor = true;
			this.buttonPrepareAllSignatures.Click += new System.EventHandler(this.buttonPrepareAllSignatures_Click);
			// 
			// panelRawDataPreview
			// 
			this.panelRawDataPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelRawDataPreview.BackColor = System.Drawing.Color.White;
			this.panelRawDataPreview.Location = new System.Drawing.Point(222, 6);
			this.panelRawDataPreview.Name = "panelRawDataPreview";
			this.panelRawDataPreview.Size = new System.Drawing.Size(463, 474);
			this.panelRawDataPreview.TabIndex = 1;
			this.panelRawDataPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRawDataPreview_Paint);
			// 
			// listBoxRawData
			// 
			this.listBoxRawData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxRawData.FormattingEnabled = true;
			this.listBoxRawData.ItemHeight = 16;
			this.listBoxRawData.Location = new System.Drawing.Point(6, 6);
			this.listBoxRawData.Name = "listBoxRawData";
			this.listBoxRawData.Size = new System.Drawing.Size(210, 516);
			this.listBoxRawData.TabIndex = 0;
			this.listBoxRawData.Click += new System.EventHandler(this.listBoxRawData_Click);
			// 
			// tabPageData
			// 
			this.tabPageData.BackColor = System.Drawing.Color.Gainsboro;
			this.tabPageData.Controls.Add(this.buttonRefreshData);
			this.tabPageData.Controls.Add(this.panelDataPreview);
			this.tabPageData.Controls.Add(this.listBoxData);
			this.tabPageData.Location = new System.Drawing.Point(4, 25);
			this.tabPageData.Name = "tabPageData";
			this.tabPageData.Size = new System.Drawing.Size(688, 527);
			this.tabPageData.TabIndex = 1;
			this.tabPageData.Text = "Обработанные данные";
			// 
			// buttonRefreshData
			// 
			this.buttonRefreshData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshData.Location = new System.Drawing.Point(3, 491);
			this.buttonRefreshData.Name = "buttonRefreshData";
			this.buttonRefreshData.Size = new System.Drawing.Size(213, 33);
			this.buttonRefreshData.TabIndex = 4;
			this.buttonRefreshData.Text = "Обновить";
			this.buttonRefreshData.UseVisualStyleBackColor = true;
			this.buttonRefreshData.Click += new System.EventHandler(this.buttonRefreshData_Click);
			// 
			// panelDataPreview
			// 
			this.panelDataPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelDataPreview.BackColor = System.Drawing.Color.White;
			this.panelDataPreview.Location = new System.Drawing.Point(222, 3);
			this.panelDataPreview.Name = "panelDataPreview";
			this.panelDataPreview.Size = new System.Drawing.Size(463, 516);
			this.panelDataPreview.TabIndex = 2;
			this.panelDataPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDataPreview_Paint);
			// 
			// listBoxData
			// 
			this.listBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxData.FormattingEnabled = true;
			this.listBoxData.ItemHeight = 16;
			this.listBoxData.Location = new System.Drawing.Point(3, 3);
			this.listBoxData.Name = "listBoxData";
			this.listBoxData.Size = new System.Drawing.Size(210, 484);
			this.listBoxData.TabIndex = 1;
			this.listBoxData.Click += new System.EventHandler(this.listBoxData_Click);
			// 
			// tabPageLearning
			// 
			this.tabPageLearning.Controls.Add(this.txtLearingOutput);
			this.tabPageLearning.Controls.Add(this.btnStartLearning);
			this.tabPageLearning.Controls.Add(this.nudUserId);
			this.tabPageLearning.Controls.Add(this.label1);
			this.tabPageLearning.Location = new System.Drawing.Point(4, 25);
			this.tabPageLearning.Name = "tabPageLearning";
			this.tabPageLearning.Size = new System.Drawing.Size(688, 527);
			this.tabPageLearning.TabIndex = 2;
			this.tabPageLearning.Text = "Обучение";
			this.tabPageLearning.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Id пользователя:";
			// 
			// nudUserId
			// 
			this.nudUserId.Location = new System.Drawing.Point(133, 11);
			this.nudUserId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudUserId.Name = "nudUserId";
			this.nudUserId.Size = new System.Drawing.Size(70, 22);
			this.nudUserId.TabIndex = 1;
			this.nudUserId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(222, 494);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Размер:";
			// 
			// nudImageSize
			// 
			this.nudImageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nudImageSize.Location = new System.Drawing.Point(289, 492);
			this.nudImageSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudImageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudImageSize.Name = "nudImageSize";
			this.nudImageSize.Size = new System.Drawing.Size(84, 22);
			this.nudImageSize.TabIndex = 5;
			this.nudImageSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// btnStartLearning
			// 
			this.btnStartLearning.Location = new System.Drawing.Point(220, 6);
			this.btnStartLearning.Name = "btnStartLearning";
			this.btnStartLearning.Size = new System.Drawing.Size(162, 30);
			this.btnStartLearning.TabIndex = 2;
			this.btnStartLearning.Text = "Начать обучение";
			this.btnStartLearning.UseVisualStyleBackColor = true;
			this.btnStartLearning.Click += new System.EventHandler(this.btnStartLearning_Click);
			// 
			// txtLearingOutput
			// 
			this.txtLearingOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLearingOutput.Location = new System.Drawing.Point(11, 45);
			this.txtLearingOutput.Name = "txtLearingOutput";
			this.txtLearingOutput.Size = new System.Drawing.Size(669, 474);
			this.txtLearingOutput.TabIndex = 3;
			this.txtLearingOutput.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(696, 556);
			this.Controls.Add(this.tabControl);
			this.Name = "MainForm";
			this.Text = "Панель управления";
			this.tabControl.ResumeLayout(false);
			this.tabPageRawData.ResumeLayout(false);
			this.tabPageRawData.PerformLayout();
			this.tabPageData.ResumeLayout(false);
			this.tabPageLearning.ResumeLayout(false);
			this.tabPageLearning.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudUserId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageSize)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageRawData;
		private System.Windows.Forms.Panel panelRawDataPreview;
		private System.Windows.Forms.ListBox listBoxRawData;
		private System.Windows.Forms.Button buttonPrepareAllSignatures;
		private System.Windows.Forms.TabPage tabPageData;
		private System.Windows.Forms.Button buttonRefreshData;
		private System.Windows.Forms.Panel panelDataPreview;
		private System.Windows.Forms.ListBox listBoxData;
		private System.Windows.Forms.TabPage tabPageLearning;
		private System.Windows.Forms.NumericUpDown nudUserId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudImageSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox txtLearingOutput;
		private System.Windows.Forms.Button btnStartLearning;
	}
}

