using System.Collections.Generic;
using System.IO;
using System.Linq;
using CheckerUI.Entities;

namespace CheckerUI.Managers
{
	public static class ReadingManager
	{
		public static List<User> ReadData(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
				throw new DirectoryNotFoundException();

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

				userDictionary[userId].SignatureList.Add(ReadDataFromFile(filePath, signatureId));
			}

			return userDictionary.Values.ToList();
		}

		private static Signature ReadDataFromFile(string filePath, int signatureId)
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
	}
}
