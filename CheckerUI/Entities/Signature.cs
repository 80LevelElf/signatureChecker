using System.Collections.Generic;

namespace CheckerUI.Entities
{
	public class Signature
	{
		public int SignatureId { get; private set; }

		public List<SignaturePoint> SignaturePointList { get; set; }

		public Signature(int signatureId, List<SignaturePoint> signaturePointList)
		{
			SignaturePointList = signaturePointList;
			SignatureId = signatureId;
		}
	}
}
