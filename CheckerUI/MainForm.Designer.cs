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
			this.tabControl.SuspendLayout();
			this.tabPageRawData.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageRawData);
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageRawData;
		private System.Windows.Forms.Panel panelRawDataPreview;
		private System.Windows.Forms.ListBox listBoxRawData;
		private System.Windows.Forms.Button buttonPrepareAllSignatures;
	}
}

