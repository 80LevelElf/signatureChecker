using System;
using System.Collections.Generic;
using System.Linq;
using CheckerUI.Entities;

namespace CheckerUI.Managers
{
	public static class ConvertingDataManager
	{
		public static List<User> ConvertUserList(List<User> userList, double signatureSize = 100)
		{
			return userList.Select(i => ConvertUser(i, signatureSize)).ToList();
		} 

		public static User ConvertUser(User user, double signatureSize = 100)
		{
			return new User(user.UserId, 
				user.SignatureList.Select(i => ConvertSignature(i, signatureSize)).ToList());
		}

		public static Signature ConvertSignature(Signature signature, double size = 100)
		{
			return new Signature(signature.SignatureId, ConvertSignature(signature.SignaturePointList, size));
		}

		public static List<SignaturePoint> ConvertSignature(List<SignaturePoint> pointList, double size = 100)
		{
			pointList = GetPreparedSignature(pointList);

			//Add line points
			var linePointList = new List<SignaturePoint>();

			for (int i = 0; i < pointList.Count - 1; i++)
			{
				linePointList.AddRange(GetLinePointList(pointList[i], pointList[i + 1]));
			}

			return linePointList;
		}

		public static List<SignaturePoint> GetPreparedSignature(List<SignaturePoint> pointList, double size = 100)
		{
			pointList = new List<SignaturePoint>(pointList.Select(i => new SignaturePoint(i.X, i.Y)));

			// Move
			var minX = pointList.Min(i => i.X);
			var minY = pointList.Min(i => i.Y);

			foreach (var point in pointList)
			{
				point.X -= minX;
				point.Y -= minY;
			}

			// Scale
			var maxX = pointList.Max(i => i.X);
			var maxY = pointList.Max(i => i.Y);

			double xK = size / maxX;
			double yk = size / maxY;

			foreach (var point in pointList)
			{
				point.X = (int)(point.X * xK);
				point.Y = (int)(point.Y * yk);

				point.Y += (int) size - 2 * point.Y;
			}

			return pointList;
		} 

		private static List<SignaturePoint> GetLinePointList(SignaturePoint first, SignaturePoint second)
		{
			//http://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
			List<SignaturePoint> result = new List<SignaturePoint>();

			int x = first.X;
			int y = first.Y;
			int x2 = second.X;
			int y2 = second.Y;

			int w = x2 - x;
			int h = y2 - y;
			int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
			if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
			if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
			if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
			int longest = Math.Abs(w);
			int shortest = Math.Abs(h);
			if (!(longest > shortest))
			{
				longest = Math.Abs(h);
				shortest = Math.Abs(w);
				if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
				dx2 = 0;
			}
			int numerator = longest >> 1;
			for (int i = 0; i <= longest; i++)
			{
				result.Add(new SignaturePoint(x, y));

				numerator += shortest;
				if (!(numerator < longest))
				{
					numerator -= longest;
					x += dx1;
					y += dy1;
				}
				else
				{
					x += dx2;
					y += dy2;
				}
			}

			return result;
		}
	}
}
