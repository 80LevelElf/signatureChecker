using System.Collections.Generic;
using System.IO;
using System.Linq;
using CheckerUI.Entities;

namespace CheckerUI.Managers
{
	public static class FileManager
	{
		public static List<User> ReadAllFromDirectory(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
				Directory.CreateDirectory(directoryPath);

			Dictionary<int, User> userDictionary = new Dictionary<int, User>();

			foreach (var filePath in Directory.GetFiles(directoryPath))
			{
				var fileName = Path.GetFileNameWithoutExtension(filePath);

				//Standard name is something like U2S20
				int indexOfS = fileName.IndexOf('S');
				int indexOfU = 1;
				int userId = int.Parse(fileName.Substring(indexOfU, indexOfS - indexOfU));
				int signatureId = int.Parse(fileName.Substring(indexOfS + 1));

				if (!userDictionary.ContainsKey(userId))
					userDictionary.Add(userId, new User(userId));

				userDictionary[userId].SignatureList.Add(ReadSignatureFromFile(filePath, signatureId));
			}

			return userDictionary.Values.ToList();
		}

		private static Signature ReadSignatureFromFile(string filePath, int signatureId)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException();

			var lineArray = File.ReadAllLines(filePath).Skip(1);
			
			List<SignaturePoint> pointList = new List<SignaturePoint>();
			foreach (var line in lineArray)
			{
				var partArray = line.Split(' ');
				pointList.Add(new SignaturePoint(int.Parse(partArray[0]), int.Parse(partArray[1])));
			}

			return new Signature(signatureId, pointList);
		}


		public static void WriteAllToDirectory(string directoryPath, List<User> userList)
		{
			if (!Directory.Exists(directoryPath))
				Directory.CreateDirectory(directoryPath);

			foreach (var user in userList)
			{
				foreach (var signature in user.SignatureList)
				{
					var fileName = string.Format("U{0}S{1}.txt", user.UserId, signature.SignatureId);
					var filePath = Path.Combine(directoryPath, fileName);

					WriteSignatureToFile(filePath, signature);
				}
			}
		}

		private static void WriteSignatureToFile(string filePath, Signature signature)
		{
			var linesToWrite = new List<string>();
			foreach (var point in signature.SignaturePointList)
			{
				linesToWrite.Add(string.Format("{0} {1}", point.X, point.Y));
			}

			File.WriteAllLines(filePath, linesToWrite.ToArray());
		}
	}
}
