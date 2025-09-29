using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 電帳DX通知ポップアップフォーム
	/// </summary>
	/// <remarks>
	/// <br>Note        : 電帳DX通知ポップアップフォームです。</br>
	/// <br>Programmer  : 32281 高村　省吾</br>
	/// <br>Date        : 2023.12.20</br>
	/// </remarks>
	public partial class SFMIT01297UA : Form
	{
		#region Const Member
		/// <summary> フォームの不透明度(最大値) </summary>
		private const double CT_OPACITY_MAX = 0.99;
		/// <summary> フォームの不透明度(最小値) </summary>
		private const double CT_OPACITY_MIN = 0.0;
		/// <summary> フォームの不透明度(減少値) </summary>
		private const double CT_OPACITY_DECREASE = 0.05;
		#endregion

		#region Private Member
		/// <summary> 電帳DX通知設定アクセスクラス </summary>
		private EBookLinkSettingsNtcSetAcs _eBookLinkSettingsNtcSetAcs;
		/// <summary> 電帳DX通知設定情報 </summary>
		private EBookLinkSettingsNtcSet _settingInfo;
		/// <summary> マウスのクリック位置 </summary>
		private Point _mousePoint;
		/// <summary> 画面起動フラグ </summary>
		private bool _formShown = false;
		/// <summary>アイコン用イメージリスト</summary>
		private ImageList _imageList16;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFMIT01297UA()
		{
			InitializeComponent();

			// 画面は右下に配置（デフォルト）
			int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
			int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;

			this.Left = screenWidth - this.Width;
			this.Top = screenheigth - this.Height;

			this._imageList16 = IconResourceManagement.ImageList16;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// 設定情報取得処理
		/// </summary>
		private int GetSettingInfo()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			if (this._eBookLinkSettingsNtcSetAcs == null)
				this._eBookLinkSettingsNtcSetAcs = new EBookLinkSettingsNtcSetAcs();

			// 電帳DX通知情報を読込
			status = this._eBookLinkSettingsNtcSetAcs.ReadSettingInfo(out this._settingInfo);
			return status;
		}

		/// <summary>
		/// 設定ファイルのチェック
		/// </summary>
		/// <returns>true:チェックOK, false:チェックNG</returns>
		private bool CheckSettingsFile()
		{
			//--------------------------------------------------
			// ポップアップ表示区分が「表示しない」場合
			//--------------------------------------------------
			if (this._settingInfo.PopupDspDiv == EBookLinkSettingsNtcHelper.CT_POPUPDSPDIV_NONDSP)
			{
				// 後続処理しない
				return false;
			}

			// 開始日をチェック
			DateTime notificationDateSt = TDateTime.LongDateToDateTime(EBookLinkSettingsNtcHelper.CT_FORMAT_DATE, this._settingInfo.NotificationDateSt);
			DateTime today = DateTime.Today;
			if (today.CompareTo(notificationDateSt) < 0)
			{
				// 後続処理しない
				return false;
			}

			// 除外用オプションをチェック
			foreach (ExclusionsOption exop in this._settingInfo.ExclusionsOptions)
			{
				PurchaseStatus purchaseStatus = PurchaseStatus.Uncontract;
				switch (exop.Authority)
				{
					case "USB":
						purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(exop.Code);
						break;
					case "Enterprise":
						purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(exop.Code);
						break;
				}
				if (purchaseStatus > PurchaseStatus.Uncontract)
				{
					// 後続処理しない
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 電帳DX通知処理
		/// </summary>
		private void NoticeEBookLinkSettings()
		{
			//--------------------------------------------------
			// 設定ファイルのチェック
			//--------------------------------------------------
			if (!CheckSettingsFile())
			{
				// 電帳DX通知を終了
				this.Close();
				return;
			}
			this.timerBeforeShow.Enabled = true;
		}

		/// <summary>
		/// ポップアップ画面非表示処理
		/// </summary>
		private void HidePopup()
		{
			// ポップアップ画面非表示タイマを起動
			this.timerOpacity.Enabled = true;
		}

		#endregion

		#region Control Event
		/// <summary>
		/// FormShownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void SFMIT01297UA_Shown(object sender, EventArgs e)
		{
			// 画面を非表示にする
			this.Visible = false;

			// アイコン設定
			this.notifyIcon.Icon = Properties.Resources.SFICON01;

			this._formShown = true;

			// 設定情報を取得
			int status = GetSettingInfo();

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.Label_Title.Text = this._settingInfo.PopupTitle;
				this.Label_Contents.Text = this._settingInfo.PopupMsg.Replace("\\n", "\r\n");
				// 電帳DX通知処理
				this.NoticeEBookLinkSettings();
			}
		}

		/// <summary>
		/// ペイントイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void Panel_Main_Paint(object sender, PaintEventArgs e)
		{
			if (this._formShown)
			{
				Color colorTop = Color.FromArgb(222, 247, 255);
				Color colorBottom = Color.FromArgb(162, 235, 255);

				// 下方向に対してのグラデーション
				LinearGradientBrush p = new LinearGradientBrush(ClientRectangle, colorTop, colorBottom, LinearGradientMode.Vertical);
				e.Graphics.FillRectangle(p, ClientRectangle);
			}
		}

		/// <summary>
		/// ヘッダパネルMouseDownイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void Header_MouseDown(object sender, MouseEventArgs e)
		{
			// 画面を非表示にしている
			if (this.timerOpacity.Enabled == true)
			{
				return;
			}

			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				//位置を記憶する
				this._mousePoint = new Point(e.X, e.Y);
			}
		}

		/// <summary>
		/// ヘッダパネルMouseMoveイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void Header_MouseMove(object sender, MouseEventArgs e)
		{
			// 画面を非表示にしている
			if (this.timerOpacity.Enabled == true)
			{
				return;
			}

			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				int pointX = this.Location.X + e.X - this._mousePoint.X;
				int pointY = this.Location.Y + e.Y - this._mousePoint.Y;
				this.Location = new Point(pointX, pointY);
			}
		}

		/// <summary>
		/// 「×」クリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void Label_Close_Click(object sender, EventArgs e)
		{
			this.Label_Close.Enabled = false;
			// ポップアップ画面を非表示にする
			HidePopup();

			this._settingInfo.PopupDspDiv = this.Notification_CheckBox.Checked ? (short)0 : (short)1;
			this._eBookLinkSettingsNtcSetAcs.WriteSettingInfo(ref this._settingInfo);
		}

		/// <summary>
		/// timerBeforeShow_Tickイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void timerBeforeShow_Tick(object sender, EventArgs e)
		{
			this.timerBeforeShow.Enabled = false;

			// 電帳DX通知画面を表示する
			this.Visible = true;
			this.Opacity = CT_OPACITY_MAX;
			this.TopMost = true;
		}

		/// <summary>
		/// timerOpacity_Tickイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void timerOpacity_Tick(object sender, EventArgs e)
		{
			// ポップアップをゆっくり透過し、非表示にする
			try
			{
				this.Opacity -= CT_OPACITY_DECREASE;
			}
			catch (Exception)
			{
				this.Opacity = CT_OPACITY_MIN;
			}
			finally
			{
				if (this.Opacity <= CT_OPACITY_MIN)
				{
					this.TopMost = false;
					this.Visible = false;
					this.timerOpacity.Enabled = false;
					this.Close();
				}
			}
		}

		/// <summary>
		/// プロモーションサイトURLリンクをクリック
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void lblLink_Click(object sender, EventArgs e)
		{
			string url = this._settingInfo.PromotionUrl;
			if (!String.IsNullOrEmpty(LoginInfoAcquisition.EnterpriseCode) && !String.IsNullOrEmpty(this._settingInfo.PromotionParam))
				url += this._settingInfo.PromotionParam + LoginInfoAcquisition.EnterpriseCode;

			// ブラウザを起動し設定されたURLへリンク
			System.Diagnostics.Process.Start(url);
		}

		/// <summary>
		/// 外部送信URLリンクをクリック
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void lblLink2_Click(object sender, EventArgs e)
		{
			// ブラウザを起動し設定されたURLへリンク
			System.Diagnostics.Process.Start(this._settingInfo.ExternalTransmissionUrl);
		}
		#endregion
	}
}