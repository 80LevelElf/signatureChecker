using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CheckerUI.Entities;
using CheckerUI.Managers;
using CheckerUI.UIEntities;

namespace CheckerUI
{
	public partial class MainForm : Form
	{
		private List<User> _rawUserList; 

		public MainForm()
		{
			InitializeComponent();

			ReadRawData();
		}

		private void ReadRawData()
		{
			string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "raw_data");
			_rawUserList = ReadingManager.ReadData(directoryPath);

			var listToShow = new List<UISignatureItem>();
			foreach (var user in _rawUserList)
			{
				foreach (var signature in user.SignatureList)
				{
					listToShow.Add(new UISignatureItem(user.UserId, signature.SignatureId));
				}
			}

			listBoxRawData.Items.AddRange(listToShow.OrderBy(i => i.UserId).ThenBy(i => i.SignatureId).ToArray());
		}

		private void listBoxRawData_Click(object sender, EventArgs e)
		{
			panelRawDataPreview.Refresh();
		}

		private void panelRawDataPreview_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;

			var selectedItem = listBoxRawData.SelectedItem;
			if (selectedItem == null)
				return;

			var selectedSignatureItem = (UISignatureItem) selectedItem;
			var signaturePointList = GetSignature(_rawUserList, selectedSignatureItem.UserId, selectedSignatureItem.SignatureId)
				.SignaturePointList;
			
			DrawSignature(signaturePointList, graphics, false);
		}

		private void DrawSignature(List<SignaturePoint> signaturePointList, Graphics graphics, bool asLine = true)
		{
			double spaceK = 0.1;

			signaturePointList = ConvertingDataManager.PrepareSignature(signaturePointList,
				Math.Min(panelRawDataPreview.Width * (1 - spaceK), panelRawDataPreview.Height * (1 - spaceK)));

			int startX = (int) (panelRawDataPreview.Width * spaceK / 2);
			int startY = (int) (panelRawDataPreview.Height * spaceK / 2);

			if (asLine)
			{
				for (int i = 0; i < signaturePointList.Count - 1; i++)
				{
					var first = signaturePointList[i];
					var second = signaturePointList[i + 1];

					graphics.DrawLine(Pens.Black, startX + first.X, startY + first.Y, startX + second.X, startY + second.Y);
				}
			}
			else
			{
				foreach (var point in signaturePointList)
				{
					graphics.DrawRectangle(Pens.Black, startX + point.X, startY + point.Y, 2, 2);
				}
			}
		}

		private Signature GetSignature(List<User> listToSearch, int userId, int signatureId)
		{
			var user = listToSearch.FirstOrDefault(i => i.UserId == userId);
			if (user == null)
				return null;

			return user.SignatureList.FirstOrDefault(i => i.SignatureId == signatureId);
		}
	}
}
