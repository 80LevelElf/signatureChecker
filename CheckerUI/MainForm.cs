using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CheckerUI.Entities;
using CheckerUI.Managers;
using CheckerUI.UIEntities;
using Learning;

namespace CheckerUI
{
	public partial class MainForm : Form
	{
		private List<User> _rawUserList;
		private readonly string _rawDataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "raw_data");

		private List<User> _userList;
		private readonly string _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sanitized_data");

		public MainForm()
		{
			InitializeComponent();

			ReadRawData();
			ReadData();
		}

		private void ReadRawData()
		{
			_rawUserList = FileManager.ReadAllFromDirectory(_rawDataDirectory);
			ReloadDataToListBox(listBoxRawData, _rawUserList);
		}

		private void ReadData()
		{
			_userList = FileManager.ReadAllFromDirectory(_dataDirectory);
			ReloadDataToListBox(listBoxData, _userList);
		}

		private void listBoxRawData_Click(object sender, EventArgs e)
		{
			panelRawDataPreview.Refresh();
		}

		private void listBoxData_Click(object sender, EventArgs e)
		{
			panelDataPreview.Refresh();
		}

		private void buttonRefreshData_Click(object sender, EventArgs e)
		{
			ReadData();
		}

		private void panelRawDataPreview_Paint(object sender, PaintEventArgs e)
		{
			DrawSelectedSignatureOfListBox(listBoxRawData, _rawUserList, e.Graphics, true);
		}

		private void panelDataPreview_Paint(object sender, PaintEventArgs e)
		{
			DrawSelectedSignatureOfListBox(listBoxData, _userList, e.Graphics, false);
		}

		private void DrawSelectedSignatureOfListBox(ListBox listBox, List<User> userList, Graphics graphics, bool flip)
		{
			var selectedItem = listBox.SelectedItem;
			if (selectedItem == null)
				return;

			var selectedSignatureItem = (UISignatureItem)selectedItem;
			var signaturePointList = GetSignature(userList, selectedSignatureItem.UserId, selectedSignatureItem.SignatureId)
				.SignaturePointList;

			DrawSignature(signaturePointList, graphics, flip);
		}

		private void DrawSignature(List<SignaturePoint> signaturePointList, Graphics graphics, bool flip)
		{
			double spaceK = 0.1;

			signaturePointList = ConvertingDataManager.GetPreparedSignature(signaturePointList,
				Math.Min(panelRawDataPreview.Width * (1 - spaceK), panelRawDataPreview.Height * (1 - spaceK)), flip);

			int startX = (int) (panelRawDataPreview.Width * spaceK / 2);
			int startY = (int) (panelRawDataPreview.Height * spaceK / 2);

			foreach (var point in signaturePointList)
			{
				graphics.DrawRectangle(Pens.Black, startX + point.X, startY + point.Y, 1, 1);
			}
		}

		private Signature GetSignature(List<User> listToSearch, int userId, int signatureId)
		{
			var user = listToSearch.FirstOrDefault(i => i.UserId == userId);
			if (user == null)
				return null;

			return user.SignatureList.FirstOrDefault(i => i.SignatureId == signatureId);
		}

		private void buttonPrepareAllSignatures_Click(object sender, EventArgs e)
		{
			try
			{
				FileManager.WriteAllToDirectory(_dataDirectory, ConvertingDataManager.ConvertUserList(_rawUserList,
					(int)nudImageSize.Value));
			}
			catch (Exception exception)
			{
				MessageBox.Show(string.Format("Во время конвертации произошла следующая ошибка: {0}",
					exception.Message), "Внимание!", MessageBoxButtons.OK);
				return;
			}

			MessageBox.Show("Конвертация произошла без проблем", "Удачна конвертация!", MessageBoxButtons.OK);
		}

		private void ReloadDataToListBox(ListBox listBox, List<User> userList)
		{
			var listToShow = new List<UISignatureItem>();
			foreach (var user in userList)
			{
				foreach (var signature in user.SignatureList)
				{
					listToShow.Add(new UISignatureItem(user.UserId, signature.SignatureId));
				}
			}

			listBox.Items.Clear();
			listBox.Items.AddRange(listToShow.OrderBy(i => i.UserId).ThenBy(i => i.SignatureId).ToArray());
		}

		private void btnStartLearning_Click(object sender, EventArgs e)
		{
			txtLearingOutput.Clear();

			NeuralNet net = new NeuralNet();
			net.Start(_userList, (int)nudUserId.Value, (int)nudImageSize.Value, str =>
			{
				txtLearingOutput.AppendText(string.Format("\n{0}", str));
			});
		}
	}
}
