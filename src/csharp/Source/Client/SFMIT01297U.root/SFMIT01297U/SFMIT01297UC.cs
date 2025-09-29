using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 電帳DX通知ポップアップ設定
	/// </summary>
	/// <remarks>
	/// <br>Note        : 電帳DX通知ポップアップフォームです。</br>
	/// <br>Programmer  : 32281 高村　省吾</br>
	/// <br>Date        : 2023.12.20</br>
	/// <br>Update Note : </br>
	/// </remarks>
	public class EBookLinkSettingsNtcSet
	{
		/// <summary>ポップアップ使用区分</summary>
		/// <remarks>0：ポップアップを使用しない、1：ポップアップを使用する</remarks>
		private Int16 _popupDspDiv;

		/// <summary>ポップアップ表示タイトル</summary>
		private string _popupTitle = "";

		/// <summary>ポップアップメッセージ</summary>
		private string _popupMsg = "";

		/// <summary>プロモーションサイトURL</summary>
		private string _promotionUrl = "";

		/// <summary>プロモーションサイトパラメータ</summary>
		private string _promotionParam = "";

		/// <summary>外部送信サイトURL</summary>
		private string _externalTransmissionUrl = "";

		/// <summary>通知開始日</summary>
		private Int32 _notificationDateSt;

		/// <summary>通知終了日</summary>
		private Int32 _notificationDateEd;

		/// <summary>通知除外オプション</summary>
		private List<ExclusionsOption> _exclusionsOptions;

		/// <summary>ポップアップ使用区分プロパティ</summary>
		/// <remarks>0：ポップアップを使用しない、1：ポップアップを使用する</remarks>
		public Int16 PopupDspDiv
		{
			get { return _popupDspDiv; }
			set { _popupDspDiv = value; }
		}

		/// <summary>ポップアップタイトルプロパティ</summary>
		public string PopupTitle
		{
			get { return _popupTitle; }
			set { _popupTitle = value; }
		}

		/// <summary>ポップアップメッセージプロパティ</summary>
		public string PopupMsg
		{
			get { return _popupMsg; }
			set { _popupMsg = value; }
		}

		/// <summary>プロモーションサイトURLプロパティ</summary>
		public string PromotionUrl
		{
			get { return _promotionUrl; }
			set { _promotionUrl = value; }
		}

		/// <summary>プロモーションサイトパラメータ</summary>
		public string PromotionParam
		{
			get { return _promotionParam; }
			set { _promotionParam = value; }
		}

		/// <summary>外部送信サイトURLプロパティ</summary>
		public string ExternalTransmissionUrl
		{
			get { return _externalTransmissionUrl; }
			set { _externalTransmissionUrl = value; }
		}

		/// <summary>通知開始日プロパティ</summary>
		public Int32 NotificationDateSt
		{
			get { return _notificationDateSt; }
			set { _notificationDateSt = value; }
		}

		/// <summary>通知終了日プロパティ</summary>
		public Int32 NotificationDateEd
		{
			get { return _notificationDateEd; }
			set { _notificationDateEd = value; }
		}

		/// <summary>通知除外オプションプロパティ</summary>
		public List<ExclusionsOption> ExclusionsOptions
		{
			get { return _exclusionsOptions; }
			set { _exclusionsOptions = value; }
		}

		/// <summary>
		/// 電帳DX通知ポップアップ設定コンストラクタ
		/// </summary>
		/// <returns>EBookLinkSettingsNtcSetクラスのインスタンス</returns>
		public EBookLinkSettingsNtcSet()
		{
		}

		/// <summary>
		/// 電帳DX通知ポップアップ設定コンストラクタ
		/// </summary>
		/// <param name="popupDspDiv">ポップアップ使用区分(0：ポップアップを使用する、1：ポップアップを使用しない)</param>
		/// <param name="popupTitle">ポップアップタイトル</param>
		/// <param name="popupMsg">ポップアップメッセージ</param>
		/// <param name="promotionUrl">プロモーションサイトURL</param>
		/// <param name="promotionParam">プロモーションサイトパラメータ</param>
		/// <param name="externalTransmissionUrl">外部送信サイトURL</param>
		/// <param name="notificationDateSt">通知開始日</param>
		/// <param name="notificationDateEd">通知終了日</param>
		/// <param name="exclusionsOptions">通知除外オプション</param>
		/// <returns>EBookLinkSettingsNtcSetクラスのインスタンス</returns>
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
		/// 電帳DX通知ポップアップ設定複製処理
		/// </summary>
		/// <returns>EBookLinkSettingsNtcSetクラスのインスタンス</returns>
		public EBookLinkSettingsNtcSet Clone()
		{
			return new EBookLinkSettingsNtcSet(this._popupDspDiv, this._popupTitle, this._popupMsg, this._promotionUrl, this._promotionParam, this._externalTransmissionUrl, this._notificationDateSt, this._notificationDateEd, this._exclusionsOptions);
		}

		/// <summary>
		/// 電帳DX通知ポップアップ設定比較処理
		/// </summary>
		/// <param name="target">比較対象のEBookLinkSettingsNtcSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
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
		/// 電帳DX通知ポップアップ設定比較処理
		/// </summary>
		/// <param name="eBookLinkSettingsNtcSet1">比較するEBookLinkSettingsNtcSetクラスのインスタンス</param>
		/// <param name="eBookLinkSettingsNtcSet2">比較するEBookLinkSettingsNtcSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
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
	/// 電帳DXポップアップ通知除外オプション設定
	/// </summary>
	public class ExclusionsOption
	{
		/// <summary>オプションコード</summary>
		private string _code;
		/// <summary>オプション権限</summary>
		private string _authority;

		/// <summary>オプションコードプロパティ</summary>
		public string Code
		{
			get { return _code; }
			set { _code = value; }
		}

		/// <summary>通知開始日プロパティ</summary>
		public string Authority
		{
			get { return _authority; }
			set { _authority = value; }
		}

		/// <summary>
		/// 電帳DXポップアップ通知除外オプション設定コンストラクタ
		/// </summary>
		/// <returns>ExclusionsOptionクラスのインスタンス</returns>
		public ExclusionsOption()
		{
		}

		/// <summary>
		/// 電帳DXポップアップ通知除外オプションコンストラクタ
		/// </summary>
		/// <returns>Regionクラスのインスタンス</returns>
		public ExclusionsOption(string code, string authority)
		{
			this._code = code;
			this._authority = authority;
		}
	}
}
