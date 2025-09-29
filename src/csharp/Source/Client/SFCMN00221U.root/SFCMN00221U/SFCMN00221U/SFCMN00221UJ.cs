using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先・車両情報選択ユーザーコントロールクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : スライダーにて得意先・車両情報選択後の表示を行います。</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2006.03.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br>2006.09.22 men 得意先を選択した場合、必ず「車両なし」と表示される障害を解除（品管管理No001285-01）</br>
	/// <br>2006.11.17 men ランチャーメニューにオプションコード参照処理を追加</br>
	/// </remarks>
	internal class SFCMN00221UJ : System.Windows.Forms.UserControl
	{
		# region Components
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_LuncherInfo;
		internal System.Windows.Forms.Panel panel_Main;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_Infomation;
		private System.Windows.Forms.Splitter splitter;
		private IContainer components = null;
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		public SFCMN00221UJ(ControlScreenSkin controlScreenSkin)
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();

			// 変数初期化
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// 企業コードを取得

			// スキン設定
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Infomation.Name);
			ctrlNameList.Add(this.uExplorerBar_LuncherInfo.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);
		}
		# endregion

		// ===================================================================================== //
		// 破棄処理
		// ===================================================================================== //
		# region
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		// ===================================================================================== //
		// コンポーネント デザイナ デザイナで作成されたコード
		// ===================================================================================== //
		#region コンポーネント デザイナ デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			this.panel_Main = new System.Windows.Forms.Panel();
			this.uExplorerBar_LuncherInfo = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.splitter = new System.Windows.Forms.Splitter();
			this.uExplorerBar_Infomation = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.panel_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_LuncherInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Infomation)).BeginInit();
			this.SuspendLayout();
			// 
			// panel_Main
			// 
			this.panel_Main.Controls.Add(this.uExplorerBar_LuncherInfo);
			this.panel_Main.Controls.Add(this.splitter);
			this.panel_Main.Controls.Add(this.uExplorerBar_Infomation);
			this.panel_Main.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.panel_Main.Location = new System.Drawing.Point(10, 9);
			this.panel_Main.Name = "panel_Main";
			this.panel_Main.Size = new System.Drawing.Size(354, 628);
			this.panel_Main.TabIndex = 4;
			// 
			// uExplorerBar_LuncherInfo
			// 
			this.uExplorerBar_LuncherInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uExplorerBar_LuncherInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance1.FontData.Name = "ＭＳ ゴシック";
			appearance1.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup1.ItemSettings.AppearancesSmall.Appearance = appearance1;
			appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance2.FontData.UnderlineAsString = "True";
			appearance2.ForeColor = System.Drawing.Color.Blue;
			ultraExplorerBarGroup1.ItemSettings.AppearancesSmall.HotTrackAppearance = appearance2;
			ultraExplorerBarGroup1.ItemSettings.Height = 22;
			ultraExplorerBarGroup1.ItemSettings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup1.ItemSettings.HotTrackStyle = Infragistics.Win.UltraWinExplorerBar.ItemHotTrackStyle.HighlightText;
			ultraExplorerBarGroup1.Key = "LuncherInfo";
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			appearance3.FontData.Name = "ＭＳ ゴシック";
			appearance3.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance3;
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance4.FontData.BoldAsString = "False";
			appearance4.FontData.Name = "ＭＳ ゴシック";
			appearance4.FontData.SizeInPoints = 11.25F;
			appearance4.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.HeaderAppearance = appearance4;
			ultraExplorerBarGroup1.Settings.ItemAreaOuterMargins.Top = 10;
			ultraExplorerBarGroup1.Text = "何をしますか？";
			this.uExplorerBar_LuncherInfo.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
			this.uExplorerBar_LuncherInfo.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowDragCopy = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowDragMove = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
			this.uExplorerBar_LuncherInfo.Location = new System.Drawing.Point(0, 143);
			this.uExplorerBar_LuncherInfo.Name = "uExplorerBar_LuncherInfo";
			this.uExplorerBar_LuncherInfo.ShowDefaultContextMenu = false;
			this.uExplorerBar_LuncherInfo.Size = new System.Drawing.Size(354, 485);
			this.uExplorerBar_LuncherInfo.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_LuncherInfo.TabIndex = 3;
			this.uExplorerBar_LuncherInfo.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			this.uExplorerBar_LuncherInfo.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.uExplorerBar_LuncherInfo_ItemClick);
			// 
			// splitter
			// 
			this.splitter.BackColor = System.Drawing.SystemColors.Control;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter.Location = new System.Drawing.Point(0, 140);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(354, 3);
			this.splitter.TabIndex = 2;
			this.splitter.TabStop = false;
			// 
			// uExplorerBar_Infomation
			// 
			this.uExplorerBar_Infomation.Dock = System.Windows.Forms.DockStyle.Top;
			this.uExplorerBar_Infomation.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance5.FontData.Name = "ＭＳ ゴシック";
			appearance5.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup2.ItemSettings.AppearancesSmall.Appearance = appearance5;
			ultraExplorerBarGroup2.Key = "Infomation";
			appearance6.BackColor = System.Drawing.Color.White;
			appearance6.BackColor2 = System.Drawing.Color.White;
			ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance6;
			appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance7.FontData.BoldAsString = "False";
			appearance7.FontData.Name = "ＭＳ ゴシック";
			appearance7.FontData.SizeInPoints = 11.25F;
			appearance7.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup2.Settings.AppearancesSmall.HeaderAppearance = appearance7;
			ultraExplorerBarGroup2.Settings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup2.Text = "得意先情報";
			this.uExplorerBar_Infomation.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup2});
			this.uExplorerBar_Infomation.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_Infomation.Location = new System.Drawing.Point(0, 0);
			this.uExplorerBar_Infomation.Name = "uExplorerBar_Infomation";
			this.uExplorerBar_Infomation.ShowDefaultContextMenu = false;
			this.uExplorerBar_Infomation.Size = new System.Drawing.Size(354, 140);
			this.uExplorerBar_Infomation.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_Infomation.TabIndex = 1;
			this.uExplorerBar_Infomation.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			// 
			// SFCMN00221UJ
			// 
			this.Controls.Add(this.panel_Main);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "SFCMN00221UJ";
			this.Size = new System.Drawing.Size(387, 646);
			this.panel_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_LuncherInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Infomation)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// 内部で使用する定数群
		// ===================================================================================== //
		# region Const
		private const string KEY_INFOMATION = "Infomation";
		private const string KEY_LUNCHER_INFO = "LuncherInfo";
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";									// 企業コード
		private CustomerSearchRet _customerSearchRet = new CustomerSearchRet();
		private Supplier _supplierSearchRet = new Supplier();					// 2008.05.22 Add
		private LuncherStartAssemblyInfo[] _luncherStartAssemblyInfoArray;		// ランチャー表示アセンブリ情報(得意先車両検索)
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>パネル変更イベント</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>ランチャー起動イベント</summary>
		internal event LuncherStartEventHandler LuncherStart;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// 得意先車両検索結果クラス
		/// </summary>
		public CustomerSearchRet CustomerSearchRet_Data
		{
			get
			{
				return this._customerSearchRet;
			}
			set
			{
				this._customerSearchRet = value;
			}
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// 仕入先検索結果クラス
		/// </summary>
		public Supplier SupplierSearchRet_Data
		{
			get
			{
				return this._supplierSearchRet;
			}
			set
			{
				this._supplierSearchRet = value;
			}
		}		
		// 2008.05.22 Add <<<

		/// <summary>
		/// ランチャー表示アセンブリ情報(得意先車両検索)
		/// </summary>
		public LuncherStartAssemblyInfo[] LuncherStartAssemblyInfoArray
		{
			get
			{
				return this._luncherStartAssemblyInfoArray;
			}
			set
			{
				this._luncherStartAssemblyInfoArray = value;
			}
		}
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 初期設定処理
		/// </summary>
		public void InitialSetting(SFCMN00221UAParam param)
		{
			// 画面初期表示設定処理
			this.DisplayInitialSetting(param);

			// 得意先車両ランチャーメニュー表示処理
			this.DispLuncherWindow();
		}
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// 画面初期表示設定処理
		/// </summary>
		private void DisplayInitialSetting(SFCMN00221UAParam param)
		{
			// イメージアイコン設定処理
			ImageList imglist = IconResourceManagement.ImageList16;

			// 抽出条件タイトル設定
			string dataType1 = "";
			string dataType2 = "";
			if (param.SupplierDiv == 1)
			{
				dataType1 = "仕入先";
				dataType2 = "仕 入 先";

				// 2008.05.22 Add >>>
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Text = dataType2 + " 情 報";

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Clear();
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerCode", "コード：" + this._supplierSearchRet.SupplierCd.ToString());
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Name", "名　称：" + this._supplierSearchRet.SupplierNm1 + " " + this._supplierSearchRet.SupplierNm2);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				// 住所 列設定
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address1", "住　所：" + this._supplierSearchRet.SupplierAddr1);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address2", "　　　　" + this._supplierSearchRet.SupplierAddr3);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address4", "　　　　" + this._supplierSearchRet.SupplierAddr4);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.EDITING];
				// 2008.05.22 Add <<<
			}
			else
			{
				dataType1 = "得意先";
				dataType2 = "得 意 先";

				// 2008.05.22 Add >>>
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Text = dataType2 + " 情 報";

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Clear();
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerCode", "コード：" + this._customerSearchRet.CustomerCode.ToString());
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Name", "名　称：" + this._customerSearchRet.Name + " " + this._customerSearchRet.Name2);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				// 住所 列設定
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address1", "住　所：" + this._customerSearchRet.Address1);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address2", "　　　　" + this._customerSearchRet.Address3);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address4", "　　　　" + this._customerSearchRet.Address4);
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.EDITING];				
				// 2008.05.22 Add <<<
			}

			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Text = dataType2 + " 情 報";

			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Clear();
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerCode", "コード：" + this._customerSearchRet.CustomerCode.ToString());
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Name", "名　称：" + this._customerSearchRet.Name + " " + this._customerSearchRet.Name2);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// 住所 列設定
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address1", "住　所：" + this._customerSearchRet.Address1);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//string address2 =
			//    AddressConverter.CombineAddress(this._customerSearchRet.Address2, this._customerSearchRet.Address3);

			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address2", "　　　　" + address2);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("Address4", "　　　　" + this._customerSearchRet.Address4);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.EDITING];
			this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Text = "選択中の" + dataType1 + "を使用して何をしますか？";
		}

		/// <summary>
		/// 得意先車両ランチャーメニュー表示処理
		/// </summary>
		private void DispLuncherWindow()
		{
			this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items.Clear();

			if (this._luncherStartAssemblyInfoArray == null) return;

			// ランチャーメニュー表示処理
			ImageList imglist = IconResourceManagement.ImageList16;
			for (int i = 0; i < this._luncherStartAssemblyInfoArray.Length; i++)
			{
				this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items.Add(i.ToString(), this._luncherStartAssemblyInfoArray[i].DispName);

				if (this._luncherStartAssemblyInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Separator)
				{
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
				}
				else if (this._luncherStartAssemblyInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Blank)
				{
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.AppearancesSmall.Appearance.ForeColor = Color.Transparent;
				}
				else
				{
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.AppearancesSmall.Appearance.Image = imglist.Images[this._luncherStartAssemblyInfoArray[i].ImageNo];
				}

				// オプションチェック
				if (!(String.IsNullOrEmpty(this._luncherStartAssemblyInfoArray[i].SoftwareCode)))
				{
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Visible = SFCMN00221UA.OptionCheckForUSB(this._luncherStartAssemblyInfoArray[i].SoftwareCode);
				}

			}
		}

		/// <summary>
		/// パネル変更イベントコール処理
		/// </summary>
		/// <param name="recodeUpdateMode">画面遷移履歴情報更新モード</param>
		/// <param name="dispNo">画面番号</param>
		private void PanelChangeEventCall(int recodeUpdateMode, int dispNo)
		{
			if (this.PanelChange != null)
			{
				PanelChangeEventArgs e = new PanelChangeEventArgs(recodeUpdateMode, dispNo);
				this.PanelChange(this, e);
			}
		}

		/// <summary>
		/// ランチャー起動イベントコール処理
		/// </summary>
		/// <param name="mode">モード</param>
		private void LuncherStartEventCall(LuncherStartAssemblyInfo luncherStartAssemblyInfo)
		{
			if (this.LuncherStart != null)
			{
				LuncherStartEventArgs e = new LuncherStartEventArgs(luncherStartAssemblyInfo, SFCMN00221UA.FORM_STATUS_CustomerLuncher);
				this.LuncherStart(this, e);
			}
		}
		# endregion

		// ===================================================================================== //
		// コントロールイベントメソッド
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// 受注ランチャーアイテムクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uExplorerBar_LuncherInfo_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			this.uExplorerBar_LuncherInfo.Enabled = false;
			
			this.LuncherStartEventCall(this._luncherStartAssemblyInfoArray[e.Item.Index]);
			
			this.uExplorerBar_LuncherInfo.Enabled = true;
		}
		# endregion
	}
}
