using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d��DX�ʒm�|�b�v�A�b�v�ݒ�
	/// </summary>
	/// <remarks>
	/// <br>Note        : �d��DX�ʒm�|�b�v�A�b�v�t�H�[���ł��B</br>
	/// <br>Programmer  : 32281 �����@�Ȍ�</br>
	/// <br>Date        : 2023.12.20</br>
	/// <br>Update Note : </br>
	/// </remarks>
	public class EBookLinkSettingsNtcSet
	{
		/// <summary>�|�b�v�A�b�v�g�p�敪</summary>
		/// <remarks>0�F�|�b�v�A�b�v���g�p���Ȃ��A1�F�|�b�v�A�b�v���g�p����</remarks>
		private Int16 _popupDspDiv;

		/// <summary>�|�b�v�A�b�v�\���^�C�g��</summary>
		private string _popupTitle = "";

		/// <summary>�|�b�v�A�b�v���b�Z�[�W</summary>
		private string _popupMsg = "";

		/// <summary>�v�����[�V�����T�C�gURL</summary>
		private string _promotionUrl = "";

		/// <summary>�v�����[�V�����T�C�g�p�����[�^</summary>
		private string _promotionParam = "";

		/// <summary>�O�����M�T�C�gURL</summary>
		private string _externalTransmissionUrl = "";

		/// <summary>�ʒm�J�n��</summary>
		private Int32 _notificationDateSt;

		/// <summary>�ʒm�I����</summary>
		private Int32 _notificationDateEd;

		/// <summary>�ʒm���O�I�v�V����</summary>
		private List<ExclusionsOption> _exclusionsOptions;

		/// <summary>�|�b�v�A�b�v�g�p�敪�v���p�e�B</summary>
		/// <remarks>0�F�|�b�v�A�b�v���g�p���Ȃ��A1�F�|�b�v�A�b�v���g�p����</remarks>
		public Int16 PopupDspDiv
		{
			get { return _popupDspDiv; }
			set { _popupDspDiv = value; }
		}

		/// <summary>�|�b�v�A�b�v�^�C�g���v���p�e�B</summary>
		public string PopupTitle
		{
			get { return _popupTitle; }
			set { _popupTitle = value; }
		}

		/// <summary>�|�b�v�A�b�v���b�Z�[�W�v���p�e�B</summary>
		public string PopupMsg
		{
			get { return _popupMsg; }
			set { _popupMsg = value; }
		}

		/// <summary>�v�����[�V�����T�C�gURL�v���p�e�B</summary>
		public string PromotionUrl
		{
			get { return _promotionUrl; }
			set { _promotionUrl = value; }
		}

		/// <summary>�v�����[�V�����T�C�g�p�����[�^</summary>
		public string PromotionParam
		{
			get { return _promotionParam; }
			set { _promotionParam = value; }
		}

		/// <summary>�O�����M�T�C�gURL�v���p�e�B</summary>
		public string ExternalTransmissionUrl
		{
			get { return _externalTransmissionUrl; }
			set { _externalTransmissionUrl = value; }
		}

		/// <summary>�ʒm�J�n���v���p�e�B</summary>
		public Int32 NotificationDateSt
		{
			get { return _notificationDateSt; }
			set { _notificationDateSt = value; }
		}

		/// <summary>�ʒm�I�����v���p�e�B</summary>
		public Int32 NotificationDateEd
		{
			get { return _notificationDateEd; }
			set { _notificationDateEd = value; }
		}

		/// <summary>�ʒm���O�I�v�V�����v���p�e�B</summary>
		public List<ExclusionsOption> ExclusionsOptions
		{
			get { return _exclusionsOptions; }
			set { _exclusionsOptions = value; }
		}

		/// <summary>
		/// �d��DX�ʒm�|�b�v�A�b�v�ݒ�R���X�g���N�^
		/// </summary>
		/// <returns>EBookLinkSettingsNtcSet�N���X�̃C���X�^���X</returns>
		public EBookLinkSettingsNtcSet()
		{
		}

		/// <summary>
		/// �d��DX�ʒm�|�b�v�A�b�v�ݒ�R���X�g���N�^
		/// </summary>
		/// <param name="popupDspDiv">�|�b�v�A�b�v�g�p�敪(0�F�|�b�v�A�b�v���g�p����A1�F�|�b�v�A�b�v���g�p���Ȃ�)</param>
		/// <param name="popupTitle">�|�b�v�A�b�v�^�C�g��</param>
		/// <param name="popupMsg">�|�b�v�A�b�v���b�Z�[�W</param>
		/// <param name="promotionUrl">�v�����[�V�����T�C�gURL</param>
		/// <param name="promotionParam">�v�����[�V�����T�C�g�p�����[�^</param>
		/// <param name="externalTransmissionUrl">�O�����M�T�C�gURL</param>
		/// <param name="notificationDateSt">�ʒm�J�n��</param>
		/// <param name="notificationDateEd">�ʒm�I����</param>
		/// <param name="exclusionsOptions">�ʒm���O�I�v�V����</param>
		/// <returns>EBookLinkSettingsNtcSet�N���X�̃C���X�^���X</returns>
		public EBookLinkSettingsNtcSet(Int16 popupDspDiv, string popupTitle, string popupMsg, string promotionUrl, string promotionParam, string externalTransmissionUrl, Int32 notificationDateSt, Int32 notificationDateEd, List<ExclusionsOption> exclusionsOptions)
		{
			this._popupDspDiv = popupDspDiv;
			this._popupTitle = popupTitle;
			this._popupMsg = popupMsg;
			this._promotionUrl = promotionUrl;
			this._promotionParam = promotionParam;
			this._externalTransmissionUrl = externalTransmissionUrl;
			this._notificationDateSt = notificationDateSt;
			this._notificationDateEd = notificationDateEd;
			this._exclusionsOptions = exclusionsOptions;
		}

		/// <summary>
		/// �d��DX�ʒm�|�b�v�A�b�v�ݒ蕡������
		/// </summary>
		/// <returns>EBookLinkSettingsNtcSet�N���X�̃C���X�^���X</returns>
		public EBookLinkSettingsNtcSet Clone()
		{
			return new EBookLinkSettingsNtcSet(this._popupDspDiv, this._popupTitle, this._popupMsg, this._promotionUrl, this._promotionParam, this._externalTransmissionUrl, this._notificationDateSt, this._notificationDateEd, this._exclusionsOptions);
		}

		/// <summary>
		/// �d��DX�ʒm�|�b�v�A�b�v�ݒ��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�EBookLinkSettingsNtcSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		public bool Equals(EBookLinkSettingsNtcSet target)
		{
			return ((this.PopupDspDiv == target.PopupDspDiv)
				 && (this.PopupTitle == target.PopupTitle)
				 && (this.PopupMsg == target.PopupMsg)
				 && (this.PromotionUrl == target.PromotionUrl)
				 && (this.PromotionParam == target.PromotionParam)
				 && (this.ExternalTransmissionUrl == target.ExternalTransmissionUrl)
				 && (this.NotificationDateSt == target.NotificationDateSt)
				 && (this.NotificationDateEd == target.NotificationDateEd)
				 && (this.ExclusionsOptions == target.ExclusionsOptions));
		}

		/// <summary>
		/// �d��DX�ʒm�|�b�v�A�b�v�ݒ��r����
		/// </summary>
		/// <param name="eBookLinkSettingsNtcSet1">��r����EBookLinkSettingsNtcSet�N���X�̃C���X�^���X</param>
		/// <param name="eBookLinkSettingsNtcSet2">��r����EBookLinkSettingsNtcSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		public static bool Equals(EBookLinkSettingsNtcSet eBookLinkSettingsNtcSet1, EBookLinkSettingsNtcSet eBookLinkSettingsNtcSet2)
		{
			return ((eBookLinkSettingsNtcSet1.PopupDspDiv == eBookLinkSettingsNtcSet2.PopupDspDiv)
				 && (eBookLinkSettingsNtcSet1.PopupTitle == eBookLinkSettingsNtcSet2.PopupTitle)
				 && (eBookLinkSettingsNtcSet1.PopupMsg == eBookLinkSettingsNtcSet2.PopupMsg)
				 && (eBookLinkSettingsNtcSet1.PromotionUrl == eBookLinkSettingsNtcSet2.PromotionUrl)
				 && (eBookLinkSettingsNtcSet1.PromotionParam == eBookLinkSettingsNtcSet2.PromotionParam)
				 && (eBookLinkSettingsNtcSet1.ExternalTransmissionUrl == eBookLinkSettingsNtcSet2.ExternalTransmissionUrl)
				 && (eBookLinkSettingsNtcSet1.NotificationDateSt == eBookLinkSettingsNtcSet2.NotificationDateSt)
				 && (eBookLinkSettingsNtcSet1.NotificationDateEd == eBookLinkSettingsNtcSet2.NotificationDateEd)
				 && (eBookLinkSettingsNtcSet1.ExclusionsOptions == eBookLinkSettingsNtcSet2.ExclusionsOptions));
		}
	}

	/// <summary>
	/// �d��DX�|�b�v�A�b�v�ʒm���O�I�v�V�����ݒ�
	/// </summary>
	public class ExclusionsOption
	{
		/// <summary>�I�v�V�����R�[�h</summary>
		private string _code;
		/// <summary>�I�v�V��������</summary>
		private string _authority;

		/// <summary>�I�v�V�����R�[�h�v���p�e�B</summary>
		public string Code
		{
			get { return _code; }
			set { _code = value; }
		}

		/// <summary>�ʒm�J�n���v���p�e�B</summary>
		public string Authority
		{
			get { return _authority; }
			set { _authority = value; }
		}

		/// <summary>
		/// �d��DX�|�b�v�A�b�v�ʒm���O�I�v�V�����ݒ�R���X�g���N�^
		/// </summary>
		/// <returns>ExclusionsOption�N���X�̃C���X�^���X</returns>
		public ExclusionsOption()
		{
		}

		/// <summary>
		/// �d��DX�|�b�v�A�b�v�ʒm���O�I�v�V�����R���X�g���N�^
		/// </summary>
		/// <returns>Region�N���X�̃C���X�^���X</returns>
		public ExclusionsOption(string code, string authority)
		{
			this._code = code;
			this._authority = authority;
		}
	}
}
