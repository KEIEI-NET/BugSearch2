using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

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
using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// トップメニューユーザーコントロールクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : スライダーのトップメニューを表示します。</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2007.02.19</br>
	/// <br></br>
	/// <br>Update Note: 2007.10.12 21024 佐々木 健</br>
	/// <br>			 ・携帯版をDC.NS版に変更</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.24 20056 對馬 大輔</br>
    ///	<br>		   : PM.NS 共通修正 得意先・仕入先分離対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.09.05 21024 佐々木 健</br>
    ///	<br>		   : PM.NS用に項目名等を修正</br>
    /// <br>Update Note: 2015/02/04 譚洪</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : ハンドルエラーが出る障害の再修正</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/06 30757 佐々木 貴英</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/12 30757 佐々木 貴英</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : システムテスト障害対応：最近使用した仕入伝票を開いている状態で画面更新すると最近使用した仕入伝票が閉じる障害対応</br>
    /// <br></br>
    /// </remarks>
	internal partial class SFCMN00221UF : System.Windows.Forms.UserControl
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// トップメニューフォームクラスのデフォルトコンストラクタ
		/// </summary>
		public SFCMN00221UF(ControlScreenSkin controlScreenSkin)
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();

			// 変数初期化
			this.CustomerListShow = true;
			this.StockSlipListShow = true;
			this._customerSearchRetRecordList = new List<CustomerSearchRet>();			// 最近選択した得意先情報
			// 2008.05.22 Update >>>
			//this._supplierSearchRetRecordList = new List<CustomerSearchRet>();			// 最近選択した仕入先情報
			this._supplierSearchRetRecordList = new List<Supplier>();					// 最近選択した仕入先情報
			// 2008.05.22 Update <<<
			this._stockSlipRecordList = new List<SearchRetStockSlip>();					// 最近選択した仕入伝票情報

			// スキン設定
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Top.Name);
			ctrlNameList.Add(this.uExplorerBar_TopRecord.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);
		}

        // --- ADD 譚洪 2015/02/04 ------ >>>
        /// <summary>
        /// 初期化メッソド（コンポ－ネント除く）
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕掛一覧№2200 redmine #43864 追加対応</br>
        /// <br>             コンポーネントハンドル生成エラー対応（再）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2015/02/04 </br>
        /// <br></br>
        /// <br>Update Note: 2015/02/06 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
        /// <br>           : 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応</br>
        /// <br></br>
        /// <br>Update Note: 2015/02/12 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
        /// <br>           : システムテスト障害対応：最近使用した仕入伝票を開いている状態で画面更新すると最近使用した仕入伝票が閉じる障害対応</br>
        /// <br></br>
        /// </remarks>
        public void InitForNoComponent()
        {
            // 変数初期化
            // --- DEL 30757 佐々木 貴英 2015/02/12 システムテスト障害対応：最近使用した仕入伝票を開いている状態で画面更新すると最近使用した仕入伝票が閉じる障害対応------ >>>
            //this.CustomerListShow = true;
            //this.StockSlipListShow = true;
            // --- DEL 30757 佐々木 貴英 2015/02/12 システムテスト障害対応：最近使用した仕入伝票を開いている状態で画面更新すると最近使用した仕入伝票が閉じる障害対応------ <<<
            // --- DEL 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ >>>
            //this._customerSearchRetRecordList = new List<CustomerSearchRet>();			// 最近選択した得意先情報
            //this._supplierSearchRetRecordList = new List<Supplier>();					// 最近選択した仕入先情報
            //this._stockSlipRecordList = new List<SearchRetStockSlip>();					// 最近選択した仕入伝票情報
            // --- DEL 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ <<<
            // --- ADD 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ >>>
            if (null == this._customerSearchRetRecordList)
            {
                this._customerSearchRetRecordList = new List<CustomerSearchRet>();			// 最近選択した得意先情報
            }
            if (null == this._supplierSearchRetRecordList)
            {
                this._supplierSearchRetRecordList = new List<Supplier>();					// 最近選択した仕入先情報
            }
            if (null == this._stockSlipRecordList)
            {
                this._stockSlipRecordList = new List<SearchRetStockSlip>();					// 最近選択した仕入伝票情報
            }
            // --- ADD 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ <<<
        }
        // --- ADD 譚洪 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// 内部で使用する定数郡
		// ===================================================================================== //
		# region const
		private const string TOP_KEY = "TopNavigator";
		private const string RECORD_KEY_CUSTOMER = "CustomerRecord";
		private const string RECORD_KEY_STOCKSLIP = "StockSlipRecord";
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private bool _customerListShow = true;
		private bool _stockSlipListShow = true;
		private List<CustomerSearchRet> _customerSearchRetRecordList;					// 最近選択した得意先情報
		// 2008.05.22 Update >>>
		//private List<CustomerSearchRet> _supplierSearchRetRecordList;					// 最近選択した仕入先情報
		private List<Supplier> _supplierSearchRetRecordList;							// 最近選択した仕入先情報
		// 2008.05.22 Update <<<
		private List<SearchRetStockSlip> _stockSlipRecordList;							// 最近選択した仕入伝票情報
		private LuncherTopMenuInfo[] _luncherTopMenuInfoArray;							// ランチャートップメニュー情報
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>パネル変更イベント</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>トップメニュー選択イベント</summary>
		internal event TopMenuSelectEventHandler TopMenuSelect;

		/// <summary>得意先選択後イベント</summary>
		internal event CustomerSelectedHandler CustomerSelected;

		// 2008.05.22 Add >>>
		/// <summary>仕入先選択後イベント</summary>
		internal event SupplierSelectedHandler SupplierSelected;
		// 2008.05.22 Add <<<

		/// <summary>仕入伝票選択後イベント</summary>
		internal event SearchRetStockSlipSelectedHandler StockSlipSelected;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Priperties
		/// <summary>
		/// 最近参照した得意先表示プロパティ
		/// </summary>
		public bool CustomerListShow
		{
			get
			{
				return this._customerListShow;
			}
			set
			{
				this._customerListShow = value;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible = this._customerListShow;

				if ((this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible) && 
					(this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible))
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Selected = true;
				}
				else
				{
					this.uExplorerBar_Top.Dock = DockStyle.Fill;
					this.uExplorerBar_TopRecord.Visible = false;
				}
			}
		}

		/// <summary>
		/// 最近参照した仕入伝票表示プロパティ
		/// </summary>
		public bool StockSlipListShow
		{
			get
			{
				return this._stockSlipListShow;
			}
			set
			{
				this._stockSlipListShow = value;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible = this._stockSlipListShow;

				if ((this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible) &&
					(this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible))
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					uExplorerBar_TopRecord.Visible = true;
					uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Selected = true;
				}
				else
				{
					this.uExplorerBar_Top.Dock = DockStyle.Fill;
					this.uExplorerBar_TopRecord.Visible = false;
				}
			}
		}

		/// <summary>
		/// 最近選択した得意先情報プロパティ
		/// </summary>
		public List<CustomerSearchRet> CustomerSearchRetRecordList
		{
			get
			{
				return this._customerSearchRetRecordList;
			}
			set
			{
				this._customerSearchRetRecordList = value;
			}
		}

		/// <summary>
		/// 最近選択した仕入先情報プロパティ
		/// </summary>
		// 2008.05.22 Update >>>
		//public List<CustomerSearchRet> SupplierSearchRetRecordList
		public List<Supplier> SupplierSearchRetRecordList
		// 2008.05.22 Update <<<
		{
			get
			{
				return this._supplierSearchRetRecordList;
			}
			set
			{
				this._supplierSearchRetRecordList = value;
			}
		}

		/// <summary>
		/// 最近選択した仕入伝票情報
		/// </summary>
		public List<SearchRetStockSlip> StockSlipRecordList
		{
			get
			{
				return this._stockSlipRecordList;
			}
			set
			{
				this._stockSlipRecordList = value;
			}
		}

		/// <summary>
		/// ランチャートップメニュー情報
		/// </summary>
		public LuncherTopMenuInfo[] LuncherTopMenuInfoArray
		{
			get
			{
				return this._luncherTopMenuInfoArray;
			}
			set
			{
				this._luncherTopMenuInfoArray = value;
			}
		}
		# endregion

		// ===================================================================================== //
		// インターナルメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 初期設定処理
		/// </summary>
		internal void InitialSetting(SFCMN00221UAParam param)
		{
			// 画面初期表示設定処理
			this.DisplayInitialSetting(param);
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

			// TOP処理選択グループ
			this.uExplorerBar_Top.Groups[TOP_KEY].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.EDITING];
			
			// 最近使った得意先選択グループ
			if (param.SupplierDiv == 1)
			{
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMERCORP2];
			}
			else
			{
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
			}
			
			// 最近使った伝票グループ
			this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];

			// 最近使用した得意先の表示
			this.DispViewCustomer(param);

			// 最近使用した仕入伝票の表示
			this.DispViewStockSlip();
			
			// TOPメニュー表示
			this.DispTopMenuWindow();
		}

		/// <summary>
		/// 最近使用した得意先の表示処理
		/// </summary>
		private void DispViewCustomer(SFCMN00221UAParam param)
		{
			string title = "";
			// 2008.05.22 Update >>>
			//List<CustomerSearchRet> searchRetRecordList;

			//if (param.SupplierDiv == 1)
			//{
			//    this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "最近使用した仕入先";
			//    title = "仕入先";
			//    searchRetRecordList = this._supplierSearchRetRecordList;
			//}
			//else
			//{
			//    this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "最近使用した得意先";
			//    title = "得意先";
			//    searchRetRecordList = this._customerSearchRetRecordList;
			//}

			//this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Clear();

			//// 最近使用した得意先の表示
			//for (int i = searchRetRecordList.Count; i > 0; i--)
			//{
			//    CustomerSearchRet lst = searchRetRecordList[i - 1];

			//    if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

			//    // 仕入先指定の場合、仕入先以外のデータは表示しない
			//    if ((param.SupplierDiv == 1) && (lst.SupplierDiv != 1)) continue;

			//    Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
			//    item.Text = lst.Name + " " + lst.Name2;
			//    item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
			//    item.ToolTipText = this.GetCustomerInfoHint(lst);
			//    item.Settings.Tag = title + "情報";
			//    item.Tag = lst.Clone();

			//    this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Add(item);
			//}


			if (param.SupplierDiv == 1)
			{
				List<Supplier> searchRetRecordList;
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "最近使用した仕入先";
				title = "仕入先";
				searchRetRecordList = this._supplierSearchRetRecordList;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Clear();

				// 最近使用した得意先の表示
				for (int i = searchRetRecordList.Count; i > 0; i--)
				{
					Supplier lst = searchRetRecordList[i - 1];

					if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

					Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
					item.Text = lst.SupplierNm1 + " " + lst.SupplierNm2;
					item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
					item.ToolTipText = this.GetSupplierInfoHint(lst);
					item.Settings.Tag = title + "情報";
					item.Tag = lst.Clone();

					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Add(item);
				}
			}
			else
			{
				List<CustomerSearchRet> searchRetRecordList;
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "最近使用した得意先";
				title = "得意先";
				searchRetRecordList = this._customerSearchRetRecordList;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Clear();

				// 最近使用した得意先の表示
				for (int i = searchRetRecordList.Count; i > 0; i--)
				{
					CustomerSearchRet lst = searchRetRecordList[i - 1];

					if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

					Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
					item.Text = lst.Name + " " + lst.Name2;
					item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
					item.ToolTipText = this.GetCustomerInfoHint(lst);
					item.Settings.Tag = title + "情報";
					item.Tag = lst.Clone();

					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Add(item);
				}
			}

			// 2008.05.22 Update <<<
		}

		/// <summary>
		/// 最近使用した仕入伝票の表示処理
		/// </summary>
		private void DispViewStockSlip()
		{
			this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Items.Clear();

			// 最近使用した仕入伝票の表示
			for (int i = this._stockSlipRecordList.Count; i > 0; i--)
			{
				SearchRetStockSlip lst = this._stockSlipRecordList[i - 1];

				if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

				// 仕入形式名称取得処理
				string supplierFormalName = SliderCommonLib.GetSupplierFormalName(lst);

				Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //item.Text = supplierFormalName + "," + lst.ArrivalGoodsDay.ToString("yyyy/MM/dd") + "," + lst.CustomerName;
                item.Text = supplierFormalName + "," + lst.ArrivalGoodsDay.ToString("yyyy/MM/dd") + "," + lst.SupplierNm1;
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
				item.ToolTipText = this.GetStockSlipInfoHint(lst);
				item.Settings.Tag = "仕入伝票情報";
				item.Tag = lst;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Items.Add(item);
			}
		}

		/// <summary>
		/// ランチャーTOPメニュー表示処理
		/// </summary>
		private void DispTopMenuWindow()
		{
			this.uExplorerBar_Top.Groups[TOP_KEY].Items.Clear();
			if (this._luncherTopMenuInfoArray == null) return;

			// ランチャーメニュー表示処理
			ImageList imglist = IconResourceManagement.ImageList16;
			
			for (int i = 0; i < this._luncherTopMenuInfoArray.Length; i++)
			{
				this.uExplorerBar_Top.Groups[TOP_KEY].Items.Add(this._luncherTopMenuInfoArray[i].Mode.ToString(), this._luncherTopMenuInfoArray[i].DispName);
				
				if (this._luncherTopMenuInfoArray[i].ImageNo >= 0)
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.AppearancesSmall.Appearance.Image = imglist.Images[this._luncherTopMenuInfoArray[i].ImageNo];
				}

				if (this._luncherTopMenuInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Separator)
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
				}
				else if (this._luncherTopMenuInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Blank)
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.AppearancesSmall.Appearance.ForeColor = Color.Transparent;
				}
				else
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
				}
			}
		}

		/// <summary>
		/// 得意先情報ヒント文字列取得処理
		/// </summary>
		/// <param name="customerSearchRet">得意先検索結果クラス</param>
		/// <returns>得意先情報ヒント文字列</returns>
		private string GetCustomerInfoHint(CustomerSearchRet customerSearchRet)
		{
			StringBuilder tipString = new StringBuilder();
			int maxLength = 10;

			// 得意先名称
			tipString.Append(SFCMN00221UA.CommonLib.PadRight(maxLength, "得意先名", ' ') + "：" + customerSearchRet.Name + " " + customerSearchRet.Name2);
					
			// カナ
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "カナ", ' ') + "：" + customerSearchRet.Kana);

			// 得意先コード
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "コード", ' ') + "：" + customerSearchRet.CustomerCode.ToString());
					
			// 得意先サブコード
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "サブコード", ' ') + "：" + customerSearchRet.CustomerSubCode);

			// 自宅TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, SFCMN00221UA.GetTelNoDspName(0), ' ') + "：" + customerSearchRet.HomeTelNo);
					
			// 勤務先TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, SFCMN00221UA.GetTelNoDspName(1), ' ') + "：" + customerSearchRet.OfficeTelNo);
					
			// 携帯TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, SFCMN00221UA.GetTelNoDspName(2), ' ') + "：" + customerSearchRet.PortableTelNo);

			// 住所 列設定
			string address =
				customerSearchRet.Address1 +
				// 2008.05.22 Update >>>
				//AddressConverter.CombineAddress(customerSearchRet.Address2, customerSearchRet.Address3) +
				customerSearchRet.Address3 +
				// 2008.05.22 Update <<<
				customerSearchRet.Address4;

			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "住所", ' ') + "：" + address);

			return tipString.ToString();
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// 仕入先情報ヒント文字列取得処理
		/// </summary>
		/// <param name="supplierSearchRet">仕入先検索結果クラス</param>
		/// <returns>得意先情報ヒント文字列</returns>
		private string GetSupplierInfoHint( Supplier supplierSearchRet )
		{
			StringBuilder tipString = new StringBuilder();
			int maxLength = 10;

			// 仕入先名称
			tipString.Append(SFCMN00221UA.CommonLib.PadRight(maxLength, "仕入先名", ' ') + "：" + supplierSearchRet.SupplierNm1 + " " + supplierSearchRet.SupplierNm2);

			// カナ
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "カナ", ' ') + "：" + supplierSearchRet.SupplierKana);

			// 得意先コード
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "コード", ' ') + "：" + supplierSearchRet.SupplierCd.ToString());

			// 自宅TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "ＴＥＬ", ' ') + "：" + supplierSearchRet.SupplierTelNo);

			// 住所 列設定
			string address =
				supplierSearchRet.SupplierAddr1 +
				supplierSearchRet.SupplierAddr3 +
				supplierSearchRet.SupplierAddr4;

			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "住所", ' ') + "：" + address);

			return tipString.ToString();
		}		
		// 2008.05.22 Add <<<

		/// <summary>
		/// 仕入伝票情報ヒント文字列取得処理
		/// </summary>
		/// <param name="searchRetStockSlip">仕入伝票検索結果クラス</param>
		/// <returns>仕入伝票情報ヒント文字列</returns>
		private string GetStockSlipInfoHint(SearchRetStockSlip searchRetStockSlip)
		{
			string tipString = "";
			int totalLength = 12;

			// ブランク
			tipString += "　\r\n";

			// 仕入伝票番号
            // 2008.09.05 Update >>>
			//tipString += SFCMN00221UA.CommonLib.PadRight(totalLength, "伝票番号", ' ') + "：" + searchRetStockSlip.SupplierSlipNo.ToString();
            tipString += SFCMN00221UA.CommonLib.PadRight(totalLength, "仕入SEQ番号", ' ') + "：" + searchRetStockSlip.SupplierSlipNo.ToString();
            // 2008.09.05 Update <<<

			// 2007.10.12 sasaki >>
			//// 入荷日
			//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "入荷日", ' ') + "：" + searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd");

			//// 計上日
			//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "計上日", ' ') + "：" + searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd");

			// 入荷日
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "入荷日", ' ') + "：" + searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd");

			// 仕入日、計上日は仕入伝票の場合のみ表示する
			if (searchRetStockSlip.SupplierFormal == 0) 
			{
				// 仕入日
				tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "仕入日", ' ') + "：" + searchRetStockSlip.StockDate.ToString("yyyy/MM/dd");

				// 計上日
				tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "計上日", ' ') + "：" + searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd");
			}
			// 2007.10.12 sasaki <<

			// 仕入担当
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "仕入担当", ' ') + "：" + searchRetStockSlip.StockAgentName;

            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 仕入先
            //tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "仕入先", ' ') + "：" + searchRetStockSlip.CustomerName;
            // 仕入先
            tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "仕入先", ' ') + "：" + searchRetStockSlip.SupplierNm1;
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// 2007.10.12 sasaki >>
			/*
			// 倉庫
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "倉庫", ' ') + "：" + searchRetStockSlip.WarehouseName;

			// 事業者
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "事業者", ' ') + "：" + searchRetStockSlip.CarrierEpName;
			*/
			// 2007.10.12 sasaki <<

			// 相手先伝番
            // 2008.09.05 Update >>>
			//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "相手先伝番", ' ') + "：" + searchRetStockSlip.PartySaleSlipNum;
            tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "伝票番号", ' ') + "：" + searchRetStockSlip.PartySaleSlipNum;
            // 2008.09.05 Update <<<

			// セパレータ
			tipString += "\r\n";

			/*
			// 仕入形式
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "仕入形式", ' ') + "：" + searchRetStockSlip.SupplierFomalName;

			// 伝票区分
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "伝票区分", ' ') + "：" + searchRetStockSlip.SupplierSlipCdName;

			// 赤伝区分
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "赤伝区分", ' ') + "：" + searchRetStockSlip.DebitNoteDivName;

			// 商品区分
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "商品区分", ' ') + "：" + searchRetStockSlip.StockGoodsCdName;

			// 買掛区分
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "買掛区分", ' ') + "：" + searchRetStockSlip.AccPayDivCdName;

			// セパレータ
			tipString += "\r\n";
			*/

			// 仕入金額合計
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "仕入合計金額", ' ') + "：" + searchRetStockSlip.StockTotalPrice.ToString("N0") + "円";

			// セパレータ
			tipString += "\r\n";

			// 備考１
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "備考1", ' ') + "：" + searchRetStockSlip.SupplierSlipNote1;

			// 備考２
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "備考2", ' ') + "：" + searchRetStockSlip.SupplierSlipNote2;

			return tipString;
		}

		/// <summary>
		/// パネル変更イベントコール処理
		/// </summary>
		/// <param name="mode">モード</param>
		private void PanelChangeEventCall(int dispNo)
		{
			if (this.PanelChange != null)
			{
				PanelChangeEventArgs e = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, dispNo);
				this.PanelChange(this, e);
			}
		}

		/// <summary>
		/// ランチャー起動イベントコール処理
		/// </summary>
		/// <param name="mode">モード</param>
		private void TopMenuSelectEventCall(LuncherTopMenuInfo luncherTopMenuInfo)
		{
			if (this.TopMenuSelect != null)
			{
				this.TopMenuSelect(this, luncherTopMenuInfo);
			}
		}

		/// <summary>
		/// 得意先車両検索結果クラス取得処理（抽出履歴選択時に使用）
		/// </summary>
		/// <param name="customerSearchRet">得意先車両検索結果クラス</param>
		/// <returns>STATUS 0:該当データあり others:該当データなし</returns>
		private int GetSearchRetCustomer(ref CustomerSearchRet customerSearchRet)
		{
			int result = 4;

			// 検索条件クラスのインスタンス化
			CustomerSearchPara para = new CustomerSearchPara();
			para.EnterpriseCode = customerSearchRet.EnterpriseCode;
			para.CustomerCode = customerSearchRet.CustomerCode;

			CustomerSearchRet[] retArray;

			// 得意先車両検索アクセスクラスのインスタンス化
			CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			status = customerSearchAcs.Serch(out retArray, para);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (CustomerSearchRet ret in retArray)
				{
					if ((ret.EnterpriseCode.Trim() == customerSearchRet.EnterpriseCode.Trim()) &&
						(ret.CustomerCode == customerSearchRet.CustomerCode))
					{
						customerSearchRet = ret.Clone();
						result = 0;
						break;
					}
				}
			}

			return result;
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// 仕入先クラス取得処理（抽出履歴選択時に使用）
		/// </summary>
		/// <param name="supplierSearchRet">得意先車両検索結果クラス</param>
		/// <returns>STATUS 0:該当データあり others:該当データなし</returns>
		private int GetSearchRetCustomer( ref Supplier supplierSearchRet )
		{
			int result = 4;

			// 仕入先アクセスクラスのインスタンス化
			SupplierAcs supplierAcs = new SupplierAcs();
			Supplier retSupplier;

			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			status = supplierAcs.Read(out retSupplier, supplierSearchRet.EnterpriseCode, supplierSearchRet.SupplierCd);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				supplierSearchRet = retSupplier.Clone();
				result = 0;
			}

			return result;
		}
		// 2008.05.22 Add <<<

		/// <summary>
		/// 仕入伝票検索結果クラス取得処理（抽出履歴選択時に使用）
		/// </summary>
		/// <param name="searchRetStockSlip">仕入伝票検索結果クラス</param>
		/// <returns>STATUS 0:該当データあり others:該当データなし</returns>
		private int GetSearchRetStockSlip(ref SearchRetStockSlip searchRetStockSlip)
		{
			int result = 4;

			// 検索条件クラスのインスタンス化
			SearchParaStockSlip para = new SearchParaStockSlip();
			para.EnterpriseCode = searchRetStockSlip.EnterpriseCode;
			para.SupplierFormal = searchRetStockSlip.SupplierFormal;
            // 2008.09.05 Update >>>
			//para.SupplierSlipNo = searchRetStockSlip.SupplierSlipNo;
            para.SupplierSlipNoSt = searchRetStockSlip.SupplierSlipNo;
            // 2008.09.05 Update <<<
            para.SupplierSlipCd = 99;
			para.DebitNoteDiv = 99;
			para.StockGoodsCd = 99;
			para.AccPayDivCd = 99;

			List<SearchRetStockSlip> searchRetStockSlipList;

			// 仕入伝票検索アクセスクラスのインスタンス化
			SearchSlipAcs searchSlipAcs = new SearchSlipAcs();
			int status = searchSlipAcs.Search(out searchRetStockSlipList, para);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (SearchRetStockSlip ret in searchRetStockSlipList)
				{
					if ((searchRetStockSlip.EnterpriseCode.Trim() == searchRetStockSlip.EnterpriseCode.Trim()) &&
						(searchRetStockSlip.SupplierFormal == searchRetStockSlip.SupplierFormal) &&
						(searchRetStockSlip.SupplierSlipNo == searchRetStockSlip.SupplierSlipNo))
					{
						searchRetStockSlip = ret;
						result = 0;
						break;
					}
				}
			}

			return result;
		}
		# endregion

		// ===================================================================================== //
		// コントロールイベントメソッド
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// トップエクスプローラーバーアイテムクリックイベント
		/// </summary>
		/// <param name="sender">イベントパラメータクラス</param>
		/// <param name="e">対象オブジェクト</param>
		private void uExplorerBar_Top_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			int key = 0;
			
			try
			{
				key = Convert.ToInt32(e.Item.Key.ToString());
			}
			catch
			{
				return;
			}

			switch (key)
			{
				// 得意先検索時
				case SFCMN00221UA.TOP_MODE_CustomerSearch:
				{
					this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_FindCustomer);
					break;				
				}
				// 仕入先検索時
				case SFCMN00221UA.TOP_MODE_SupplierSearch:
				{
					this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_FindSupplier);
					break;
				}
				// 仕入検索時
				case SFCMN00221UA.TOP_MODE_StockSlipSearch:
				{
					this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_FindStockSlip);
					break;				
				}
				default:
				{
					this.TopMenuSelectEventCall(this._luncherTopMenuInfoArray[e.Item.Index]);
					break;
				}
			}
		}

		/// <summary>
		/// 履歴エクスプローラーバーアイテムクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uExplorerBar_TopRecord_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			if (e.Item.Group.Key == RECORD_KEY_CUSTOMER)			// 得意先車両選択時
			{
				// 2008.05.22 Del >>>
				//CustomerSearchRet customerSearchRet = e.Item.Tag as CustomerSearchRet;
				// 2008.05.22 Del <<<

				if (LoginInfoAcquisition.OnlineFlag)
				{
					// 2008.05.22 Update >>>
					//int status = this.GetSearchRetCustomer(ref customerSearchRet);
					//if (status != 0)
					//{
					//    TMsgDisp.Show(
					//        Form.ActiveForm,
					//        emErrorLevel.ERR_LEVEL_INFO,
					//        this.Name,
					//        "選択した得意先は既に削除されているため、選択出来ません",
					//        0,
					//        MessageBoxButtons.OK);

					//    return;
					//}

					//if (this.CustomerSelected != null)
					//{
					//    this.CustomerSelected(this, customerSearchRet);

					//    // パネル変更イベントコール処理
					//    this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
					//}

					if (e.Item.Tag is CustomerSearchRet)
					{
						CustomerSearchRet customerSearchRet = e.Item.Tag as CustomerSearchRet;

						int status = this.GetSearchRetCustomer(ref customerSearchRet);
						if (status != 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"選択した得意先は既に削除されているため、選択出来ません",
								0,
								MessageBoxButtons.OK);

							return;
						}

						if (this.CustomerSelected != null)
						{
							this.CustomerSelected(this, customerSearchRet);

							// パネル変更イベントコール処理
							this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
						}
					}
					else if (e.Item.Tag is Supplier)
					{
						Supplier supplierSearchRet = e.Item.Tag as Supplier;

						int status = this.GetSearchRetCustomer(ref supplierSearchRet);
						if (status != 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"選択した仕入先は既に削除されているため、選択出来ません",
								0,
								MessageBoxButtons.OK);

							return;
						}

						if (this.SupplierSelected != null)
						{
							this.SupplierSelected(this, supplierSearchRet);

							// パネル変更イベントコール処理
							this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
						}
					}
					// 2008.05.22 Update <<<
				}
				else
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"オフラインモードの為、処理を行えません。",
						0,
						MessageBoxButtons.OK);
				}
			}
			else													// 仕入伝票選択時
			{			
//				int cnt = this._stockSlipRecordList.Count - 1;
				SearchRetStockSlip searchRetStockSlip = e.Item.Tag as SearchRetStockSlip;

				if (LoginInfoAcquisition.OnlineFlag)
				{
					int status = this.GetSearchRetStockSlip(ref searchRetStockSlip);
					if (status != 0)
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"選択した仕入伝票伝票は既に削除されているため、選択出来ません",
							0,
							MessageBoxButtons.OK);

						return;
					}

					if (this.StockSlipSelected != null)
					{
						this.StockSlipSelected(this, searchRetStockSlip);

						// パネル変更イベントコール処理
						this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_StockSlipLuncher);
					}
				}
				else
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"オフラインモードの為、処理を行えません。",
						0,
						MessageBoxButtons.OK);
				}
			}
		}

		/// <summary>
		/// エクスプローラーバーマウスエンターエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uExplorerBar_TopRecord_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			// 仕入伝票情報をポップアップ表示
			Infragistics.Win.UIElement element = e.Element;
			object oContextItem = null;

			oContextItem = element.GetContext(typeof(Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem));

			if (oContextItem != null)
			{
				Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = (Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem)oContextItem;

				if ((item.ToolTipText != "") && (item.Settings.Tag != null))
				{
					Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
					ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
					ultraToolTipInfo.ToolTipTitle = item.Settings.Tag.ToString();
					ultraToolTipInfo.ToolTipText = item.ToolTipText.ToString();

					this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
					this.uToolTipManager_Information.SetUltraToolTip(this.uExplorerBar_TopRecord, ultraToolTipInfo);
					this.uToolTipManager_Information.Enabled = true;
				}
			}
		}

		/// <summary>
		/// エクスプローラーバーマウスリーヴエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uExplorerBar_TopRecord_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			this.uToolTipManager_Information.Enabled = false;
		}
		# endregion
	}

	# region internal Delegate
	/// <summary>トップメニュー選択イベント用デリゲート</summary>
	internal delegate void TopMenuSelectEventHandler(object sender, LuncherTopMenuInfo luncherTopMenuInfo);
	# endregion
}
