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
			this.tabControl.SuspendLayout();
			this.tabPageRawData.SuspendLayout();
			this.tabPageData.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageRawData);
			this.tabControl.Controls.Add(this.tabPageData);
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
			this.buttonPrepareAllSignatures.Location = new System.Drawing.Point(403, 486);
			this.buttonPrepareAllSignatures.Name = "buttonPrepareAllSignatures";
			this.buttonPrepareAllSignatures.Size = new System.Drawing.Size(277, 33);
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
			this.tabPageData.ResumeLayout(false);
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
	}
}

