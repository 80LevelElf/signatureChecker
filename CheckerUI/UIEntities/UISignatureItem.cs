namespace CheckerUI.UIEntities
{
	public class UISignatureItem
	{
		public int UserId { get; set; }

		public int SignatureId { get; set; }

		public UISignatureItem(int userId, int signatureId)
		{
			UserId = userId;
			SignatureId = signatureId;
		}

		public override string ToString()
		{
			return string.Format("User: {0} Signarute: {1}", UserId, SignatureId);
		}

		public string FileName
		{
			get { return string.Format("U{0}S{1}", UserId, SignatureId); }
		}
	}
}
