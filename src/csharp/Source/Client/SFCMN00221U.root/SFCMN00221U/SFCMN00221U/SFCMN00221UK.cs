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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入伝票情報表示ユーザーコントロールクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : スライダーにて仕入伝票情報選択後の表示を行います。</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2007.02.23</br>
	/// <br></br>
    /// <br>Update Note: 2008.04.24 20056 對馬 大輔</br>
    ///	<br>		   : PM.NS 共通修正 得意先・仕入先分離対応</br>
    /// </remarks>
	internal class SFCMN00221UK : System.Windows.Forms.UserControl
	{
		# region Components
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_LuncherInfo;
		internal System.Windows.Forms.Panel panel_Main;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_Infomation;
		private System.Windows.Forms.Splitter splitter;
		private System.ComponentModel.Container components = null;

		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 仕入伝票情報表示フォームクラスのデフォルトコンストラクタ
		/// </summary>
		public SFCMN00221UK(ControlScreenSkin controlScreenSkin)
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
		# region Dispose
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
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(225)))));
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance3;
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance4.FontData.BoldAsString = "False";
			appearance4.FontData.Name = "ＭＳ ゴシック";
			appearance4.FontData.SizeInPoints = 11.25F;
			appearance4.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.HeaderAppearance = appearance4;
			ultraExplorerBarGroup1.Text = "何をしますか？";
			this.uExplorerBar_LuncherInfo.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
			this.uExplorerBar_LuncherInfo.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowDragCopy = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowDragMove = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
			this.uExplorerBar_LuncherInfo.Location = new System.Drawing.Point(0, 187);
			this.uExplorerBar_LuncherInfo.Name = "uExplorerBar_LuncherInfo";
			this.uExplorerBar_LuncherInfo.ShowDefaultContextMenu = false;
			this.uExplorerBar_LuncherInfo.Size = new System.Drawing.Size(354, 441);
			this.uExplorerBar_LuncherInfo.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_LuncherInfo.TabIndex = 3;
			this.uExplorerBar_LuncherInfo.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			this.uExplorerBar_LuncherInfo.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.uExplorerBar_LuncherInfo_ItemClick);
			// 
			// splitter
			// 
			this.splitter.BackColor = System.Drawing.SystemColors.Control;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter.Location = new System.Drawing.Point(0, 184);
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
			ultraExplorerBarGroup2.ItemSettings.Height = 22;
			ultraExplorerBarGroup2.Key = "Infomation";
			appearance6.BackColor = System.Drawing.Color.White;
			appearance6.BackColor2 = System.Drawing.Color.White;
			appearance6.FontData.Name = "ＭＳ ゴシック";
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
			ultraExplorerBarGroup2.Text = "仕入伝票情報";
			this.uExplorerBar_Infomation.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup2});
			this.uExplorerBar_Infomation.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_Infomation.Location = new System.Drawing.Point(0, 0);
			this.uExplorerBar_Infomation.Name = "uExplorerBar_Infomation";
			this.uExplorerBar_Infomation.ShowDefaultContextMenu = false;
			// 2007.10.12 sasaki >>
			//this.uExplorerBar_Infomation.Size = new System.Drawing.Size(354, 184);
			this.uExplorerBar_Infomation.Size = new System.Drawing.Size(354, 194);
			// 2007.10.12 sasaki <<
			this.uExplorerBar_Infomation.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_Infomation.TabIndex = 1;
			this.uExplorerBar_Infomation.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			// 
			// SFCMN00221UK
			// 
			this.Controls.Add(this.panel_Main);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "SFCMN00221UK";
			// 2007.10.12 sasaki >>
			//this.Size = new System.Drawing.Size(509, 646);
			this.Size = new System.Drawing.Size(509, 636);
			// 2007.10.12 sasaki <<
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
		private SearchRetStockSlip _searchRetStockSlip = new SearchRetStockSlip();
		private LuncherStartAssemblyInfo[] _luncherStartAssemblyInfoArray;		// ランチャー表示アセンブリ情報(仕入伝票検索)
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
		/// 仕入伝票検索結果クラス
		/// </summary>
		public SearchRetStockSlip SearchRetStockSlip_Data
		{
			get
			{
				return this._searchRetStockSlip;
			}
			set
			{
				this._searchRetStockSlip = value;
			}
		}

		/// <summary>
		/// ランチャー表示アセンブリ情報(仕入伝票)
		/// </summary>
		public LuncherStartAssemblyInfo[] OdrLuncherStartAssemblyInfoArray
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

			// 仕入伝票ランチャーメニュー表示処理
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

			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Clear();

			// 2007.10.12 sasaki >>
			//// 伝票番号
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierSlipNo", "伝票番号　　：" + this._searchRetStockSlip.SupplierSlipNo.ToString());
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// 仕入形式名称取得処理
			//string supplierFormalName = SliderCommonLib.GetSupplierFormalName(this._searchRetStockSlip);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierFormal", "仕入形式　　：" + supplierFormalName);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// 入荷日
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("ArrivalGoodsDay", "入荷日　　　：" + this._searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd"));
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// 計上日
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockAddUpADate", "計上日　　　：" + this._searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd"));
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// 仕入先
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerName", "仕入先　　　：" + this._searchRetStockSlip.CustomerName.ToString());
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// 仕入金額
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockTotalPrice", "仕入合計金額：" + this._searchRetStockSlip.StockTotalPrice.ToString("N0") + "円");
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[5].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[5].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			int index = 0;
			// 伝票番号
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierSlipNo", "伝票番号　　：" + this._searchRetStockSlip.SupplierSlipNo.ToString());
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// 伝票種別名称取得処理
			index++;
			string supplierFormalName = SliderCommonLib.GetSupplierFormalName(this._searchRetStockSlip);
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierFormal", "伝票種別　　：" + supplierFormalName);
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// 入荷日
			index++;
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("ArrivalGoodsDay", "入荷日　　　：" + this._searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd"));
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// 仕入の場合のみ表示
			if (this._searchRetStockSlip.SupplierFormal == 0)
			{
				// 仕入日
				index++;
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockDate", "仕入日　　　：" + this._searchRetStockSlip.StockDate.ToString("yyyy/MM/dd"));
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				// 計上日
				index++;
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockAddUpADate", "計上日　　　：" + this._searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd"));
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
			}
			// 仕入先
			index++;
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerName", "仕入先　　　：" + this._searchRetStockSlip.CustomerName.ToString());
            this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerName", "仕入先　　　：" + this._searchRetStockSlip.SupplierNm1.ToString());
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// 仕入金額
			index++;
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockTotalPrice", "仕入合計金額：" + this._searchRetStockSlip.StockTotalPrice.ToString("N0") + "円");
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
			// 2007.10.12 sasaki <<
		}

		/// <summary>
		/// 仕入伝票ランチャーメニュー表示処理
		/// </summary>
		private void DispLuncherWindow()
		{
			this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items.Clear();
			
			if (this._luncherStartAssemblyInfoArray == null) return;

			// ランチャーメニュー表示処理
			ImageList imglist = IconResourceManagement.ImageList16;
			
			for(int i = 0; i < this._luncherStartAssemblyInfoArray.Length; i++)
			{
				this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items.Add(i.ToString(), this._luncherStartAssemblyInfoArray[i].DispName);

				if (this._luncherStartAssemblyInfoArray[i].ImageNo >= 0)
				{
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
				}

				// オプションチェック
				if (!(String.IsNullOrEmpty(this._luncherStartAssemblyInfoArray[i].SoftwareCode)))
				{
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Visible = SFCMN00221UA.OptionCheckForUSB(this._luncherStartAssemblyInfoArray[i].SoftwareCode);
				}

				// 特殊処理
				if (this._luncherStartAssemblyInfoArray[i].Mode == SFCMN00221UA.LuncherMode_TrustAppropriate)
				{
					if (this._searchRetStockSlip.SupplierFormal == 1)
					{
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Enabled = Infragistics.Win.DefaultableBoolean.True;
					}
					else
					{
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Enabled = Infragistics.Win.DefaultableBoolean.False;
					}
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
				LuncherStartEventArgs e = new LuncherStartEventArgs(luncherStartAssemblyInfo, SFCMN00221UA.FORM_STATUS_StockSlipLuncher);
				this.LuncherStart(this, e);
			}
		}
		# endregion

		// ===================================================================================== //
		// コントロールイベントメソッド
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// 仕入伝票ランチャーアイテムクリックイベント
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
