using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 在庫仕入入力メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫仕入入力の各子画面を制御するメインフレームです。</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.03.12</br>
	/// <br>Update Date: 2008/07/24 30414 忍 幸史</br>
    /// <br>           : Partsman用に変更</br>
    /// <br>Update Date: 2009/11/16 30434 工藤 恵優</br>
    /// <br>           : 3次対応分 在庫登録機能を追加</br>
    /// <br>Update Note: 2009/12/16 朱俊成</br>
    /// <br>               PM.NS-5</br>
    /// <br>               在庫仕入入力で標準価格と原単価の入力制御の修正</br>
    /// </remarks>
	public partial class MAZAI04350UA : Form
	{
		//----------------------------------------------------------------------------------------------------
		//  コンストラクタ
		//----------------------------------------------------------------------------------------------------
		# region コンストラクタ
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// コンストラクタ
        ///// </summary>
        //public MAZAI04350UA()
        //{
        //    InitializeComponent();

        //    AdjustStockAcs.GetStockSectionCode += new AdjustStockAcs.GetStockSectionCodeEventHandler(this.GetStockSectionCode);
        //    MAZAI04360UA.GetSection += new MAZAI04360UA.GetSectionEventHandler(this.GetSection);
        //    AdjustStockAcs.GetDate += new AdjustStockAcs.GetDateEventHandler(this.GetDate);
        //    AdjustStockAcs.GetStockPointWay += new AdjustStockAcs.GetStockPointWayEventHandler(this.GetStockPointWayCD);
        //    AdjustStockAcs.GetFractionProcCd += new AdjustStockAcs.GetFractionProcCdEventHandler(this.GetFractionProcCd);
        //    MAZAI04360UA.GetStockPointWay += new MAZAI04360UA.GetStockPointWayCDEventHandler(this.GetStockPointWayCD);
        //    MAZAI04360UA.GetFractionProcCD += new MAZAI04360UA.GetFractionProcCdEventHandler(this.GetFractionProcCd);
        //    MAZAI04360UA.GetEmpList += new MAZAI04360UA.GetEmpListEventHandler(this.GetEmpList);
        //    MAZAI04360UA.GetEmployee += new MAZAI04360UA.GetEmployeeEventHandler(this.GetEmployee);
        //    AdjustStockAcs.GetSubttlPrice += new AdjustStockAcs.GetSubttlPriceEventHandler(this.GetSubttlPrice);
        //    AdjustStockAcs.GetBlGoodsName += new AdjustStockAcs.GetBlGoodsNameEventHandler(this.GetBlGoodsName);

        //    // 企業コード取得
        //    if (LoginInfoAcquisition.EnterpriseCode != null)
        //    {
        //        this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //    }

        //    this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();

        //    // 在庫評価方法取得
        //    StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
        //    StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();

        //    stockMngTtlStAcs.Read(out stockMngTtlSt, _enterpriseCode, 0);

        //    _stockPointWay = stockMngTtlSt.StockPointWay;

        //    MAZAI04360UA _mazai04360UA = MAZAI04360UA.GetInstance();
        //    MAZAI04360UA.ChangeToolbarSetting += new MAZAI04360UA.ChangeToolbarSettingEventHandler(ToolbarEnableChange);
        //    InitialProc();
        //}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAZAI04350UA()
        {
            InitializeComponent();

            AdjustStockAcs.GetStockSectionCode += new AdjustStockAcs.GetStockSectionCodeEventHandler(this.GetStockSectionCode);
            AdjustStockAcs.GetDate += new AdjustStockAcs.GetDateEventHandler(this.GetDate);
            AdjustStockAcs.GetSubttlPrice += new AdjustStockAcs.GetSubttlPriceEventHandler(this.GetSubttlPrice);
            AdjustStockAcs.GetSlipNote += new AdjustStockAcs.GetSlipNoteEventHandler(this.GetSlipNote);
            MAZAI04360UA.ChangeToolbarSetting += new MAZAI04360UA.ChangeToolbarSettingEventHandler(ToolbarEnableChange);
            MAZAI04360UA.changeFocusFooter += new MAZAI04360UA.ChangeFocusFooterEventHandler(ChangeFocusFooter);
            // 2009.04.02 30413 犬飼 保存用イベント追加 >>>>>>START
            MAZAI04360UA.save += new MAZAI04360UA.SaveEventHandler(Save);
            // 2009.04.02 30413 犬飼 保存用イベント追加 <<<<<<END
            // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
            MAZAI04360UA.EnabledToInputStock += new MAZAI04360UA.OnEnabledToInputStock(EnabledToInputStock);
            // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

            MAZAI04360UA _mazai04360UA = MAZAI04360UA.GetInstance();

            this._adjustStockAcs = AdjustStockAcs.GetInstance();
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        # endregion

        /// <summary>
        /// オペレーションコード
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>修正</summary>
            Revision = 10,
            /// <summary>削除</summary>
            Delete = 11,
        }
		//----------------------------------------------------------------------------------------------------
		//  プライベイトメンバ
		//----------------------------------------------------------------------------------------------------
		# region プライベイトメンバ

        private AdjustStockAcs _adjustStockAcs = null;

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>企業コード</summary>
		private string _enterpriseCode;
		/// <summary>自拠点コード</summary>
		private string _ownSectionCode;
		/// <summary>拠点オプション有効フラグ</summary>
		private bool _optSection = false;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>表示モード</summary>
		private int _dispMode = 0;
		/// <summary>タブチェンジイベント制御フラグ</summary>
		private bool _enableTabChange = false;
		/// <summary>イベント制御フラグ</summary>
		private bool _cancelEventFlg = false;

        //private int _fractionProcCd; 
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private int _fractionProcCd = 0;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        /// <summary>在庫評価方法</summary>
        private int _stockPointWay;
        //private MAZAI04360UA _mazai04360UA;

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>定価原価更新区分</summary>
        private int _priceCostUpdtDiv;
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		/// <summary>子画面制御クラス</summary>
		private FormControlInfo _formControlInfo;

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>保存中画面</summary>
		private SFCMN00299CA _WaitingDialog;

        private IEmployeeDB _iEmployeeDB;
        public ArrayList _employeeList = new ArrayList();
        public string _employeeCd = "";
        public string _employeeNm = "";
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        // 画面デザイン変更クラス
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        //private BLGoodsCdAcs _blGoodsCdAcs;
        //private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

        private bool _saveFlg;

		# endregion

		//----------------------------------------------------------------------------------------------------
		//  定数宣言
		//----------------------------------------------------------------------------------------------------
		# region 定数宣言
		/// <summary>先頭タブKEY名称</summary>
		private const string NO0_TOP_TAB = "TOP_TAB";
		/// <summary>タブなし</summary>
		private const string NO_TAB = "";

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>部品仕入入力</summary>
		private const int ctInputPartsStock = 1;
		/// <summary>車両仕入入力</summary>
		private const int ctInputCarStock = 2;
		/// <summary>外注発注入力</summary>
		private const int ctInputOutsourcing = 3;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>PGID</summary>
		private const string ctPGID = "MAZAI04350U";
		# endregion

        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAZAI04350U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>
        /// 拠点取得
        /// </summary>
        /// <returns>拠点コード</returns>
        public string GetStockSectionCode()
        {
            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            //Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            //return (string)cmbOwnSection.Value;
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            return mazai04360UA.GetStockSectionCode();
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 作成日取得
        /// </summary>
        /// <returns>作成日</returns>
        public DateTime GetDate()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            return mazai04360UA.GetDate();
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        public int GetFractionProcCd()
        {
            return _fractionProcCd;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
        /// 在庫評価方法取得
        /// </summary>
        /// <returns>在庫評価方法</returns>
        public int GetStockPointWayCD()
        {
            return _stockPointWay;
        }

        /// <summary>
        /// 仕入金額計取得
        /// </summary>
        /// <returns>仕入金額計</returns>
        public Int64 GetSubttlPrice()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            return mazai04360UA.GetSubttlPrice();
        }

        /// <summary>
        /// 伝票備考取得処理
        /// </summary>
        /// <returns>伝票備考</returns>
        public string GetSlipNote()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            return mazai04360UA.GetSlipNote();
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        public ArrayList GetEmpList()
        {
            return _employeeList;
        }
        public string GetEmployee()
        {
            return _employeeCd;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // 伝票削除ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Visible = false;
                ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Shortcut = Shortcut.None;
            }
        }

        //----------------------------------------------------------------------------------------------------
		//  コントロールイベントハンドラ
		//----------------------------------------------------------------------------------------------------
		# region コントロールイベントハンドラ
        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// フォームロードイベントハンドラ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームがロードされた時に発動します</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// <br>Update Note: 2009/12/16 朱俊成</br>
        /// <br>             PM.NS-5</br>
        /// <br>             在庫仕入入力で標準価格と原単価の入力制御の修正</br>
        /// </remarks>
        private void MAZAI04350UA_Load(object sender, EventArgs e)
        {
            try
            {
                // 画面スキンファイルの読込(デフォルトスキン指定)
                this._controlScreenSkin.LoadSkin();

                // 画面スキン変更
                this._controlScreenSkin.SettingScreenSkin(this);

                // ツールバーの設定
                SettingToolbar();

                // ツールバーの有効無効設定
                ToolbarEnableChange(0);

                // セキュリティ権限による制御開始(ツールバーボタン)
                BeginControllingByOperationAuthority();
                
                // 在庫評価方法取得
                GetStockPointWay();

                // 定価原価更新区分取得
                GetPriceCostUpdtDiv();

                // フォーム制御テーブルを生成する
                FormControlInfoCreate("");

                // 先頭タブ生成
                TabCreate(NO0_TOP_TAB);

                // 先頭タブアクティブ化
                TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);

                // 画面に表示した内容を初期値にする
                StoreTabChild();

                // タブチェンジイベントON
                this._enableTabChange = true;

                /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
                // TSPバーコードオプション情報取得
                PurchaseStatus purchaseStatus =
                    LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeTspInput);
                
                // 未契約時はボタンは非表示とする
                if ((purchaseStatus == PurchaseStatus.Contract) ||
                    (purchaseStatus == PurchaseStatus.Trial_Contract))
                {
                    // バーコード読取機能をON
                    tBarcodeReader1.Monitoring = true;
                }
                else
                {
                    // バーコード読取機能をOFFにする
                    tBarcodeReader1.Monitoring = false;
                }
                   --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
          
                // --- ADD 2009/12/16 ---------->>>>>
                // 定価入力区分取得
                GetListPriceInpDiv();

                // 単価入力区分取得
                GetUnitPriceInpDiv();
                // --- ADD 2009/12/16 ----------<<<<<
            }
            finally
            {
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// フォームロードイベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームがロードされた時に発動します</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void MAZAI04350UA_Load(object sender, EventArgs e)
		{
			try
            {
                // 画面スキンファイルの読込(デフォルトスキン指定)
                this._controlScreenSkin.LoadSkin();

                // 画面スキン変更
                this._controlScreenSkin.SettingScreenSkin(this);

                // 拠点情報の取得
				SecInfoSet secInfoSet;
				SecInfoAcs secInfoAcs = new SecInfoAcs();

				// 自社情報取得
				secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

				// 拠点コンボボックスに拠点リストを設定する
				Infragistics.Win.ValueList secInfoList = new Infragistics.Win.ValueList();
				foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
				{
					Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
					secInfoItem.DataValue = secInfoSetWk.SectionCode;
					secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
					secInfoList.ValueListItems.Add(secInfoItem);
				}
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"]).ValueList = secInfoList;

				// 本社機能無しor拠点オプション無しなら拠点を変更できないようにする
				this._optSection = !((secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) || (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) <= 0));
				this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
                
                // ツールバーの設定
				this.SettingToolbar();

				// ツールバーの有効無効設定
				this.ToolbarEnableChange(0);
                // 
                //this._adjustStockAcs = new AdjustStockAcs();
                this._adjustStockAcs = AdjustStockAcs.GetInstance();

				// 仕入管理アクセスクラスを初期化
				string sectionCode = "";
				Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"];
				if (cmbOwnSection.Value is string)
				{
					sectionCode = (string)cmbOwnSection.Value;
				}

				// 自拠点情報を設定する
				cmbOwnSection.Value = secInfoSet.SectionCode;
				this._ownSectionCode = secInfoSet.SectionCode;

				// 表示モード初期設定
				this.SettingDispMode((int)ChildFormDispMode.Normal);
                
                // フォーム制御テーブルを生成する
				this.FormControlInfoCreate("");

				// 先頭タブ生成
				this.TabCreate(NO0_TOP_TAB);

				// 先頭タブアクティブ化
				this.TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);

				// 画面に表示した内容を初期値にする
				this.StoreTabChild();

				// タブチェンジイベントON
				this._enableTabChange = true;

				// TSPバーコードオプション情報取得
				PurchaseStatus purchaseStatus =
					LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeTspInput);
				// 未契約時はボタンは非表示とする
				if ((purchaseStatus == PurchaseStatus.Contract) ||
					(purchaseStatus == PurchaseStatus.Trial_Contract))
				{
					// バーコード読取機能をON
					tBarcodeReader1.Monitoring = true;
				}
				else
				{
					// バーコード読取機能をOFFにする
					tBarcodeReader1.Monitoring = false;
				}
			}
			finally
			{
			}
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// フォームClose前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームが終了する前に発生します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void MAZAI04350UA_FormClosing(object sender, FormClosingEventArgs e)
		{

		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <param name="sender"></param>
        private void Close(bool isConfirm,object sender)
        {
            if ((isConfirm) && (this._adjustStockAcs.IsDataChanged))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                    //this.Save(true, sender);
                    MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
                    mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

                    // 伝票修正時
                    if (mazai04360UA.GetEnabledSupplierSlipNo() == false)
                    {
                        if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  ctPGID,
                                  "セキュリティにより伝票修正が制限されています。",
                                  0,
                                  MessageBoxButtons.OK);
                            return;
                        }
                    }
                    this.Save();
                    // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }


		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ツールバーがクリックされた時に発動します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
        /// <br>Update Note: 2009/12/16 朱俊成</br>
        /// <br>               PM.NS-5</br>
        /// <br>               在庫仕入入力で標準価格と原単価の入力制御の修正</br>
        /// </remarks>
		private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
		{
			if (this._cancelEventFlg) return;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();

			switch (e.Tool.Key)
			{
				case "ButtonTool_Close":
					//--------------------------------------------------------------
					// 終了ボタン
					//--------------------------------------------------------------
					// メイン画面のクローズ
					this.Close(true,sender);
					break;
				case "ButtonTool_Save":

					//--------------------------------------------------------------
					// 保存ボタン
					//--------------------------------------------------------------
                    // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                    //Save(true, sender);

                    mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

                    if (ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Caption == "確定(F10)")
                    {
                        if (mazai04360UA.ActiveControl.Parent == mazai04360UA.StockGrid)
                        {
                            mazai04360UA.edtNote1.Focus();
                            ChangeFocusFooter(true);
                        }
                        else
                        {
                            mazai04360UA.StockGrid.Focus();
                        }
                        return;
                    }

                    // 伝票修正時
                    if (mazai04360UA.GetEnabledSupplierSlipNo() == false)
                    {
                        if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  ctPGID,
                                  "セキュリティにより伝票修正が制限されています。",
                                  0,
                                  MessageBoxButtons.OK);
                            return;
                        }
                    }

                    DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                    ctPGID,
                                                    "登録してもよろしいですか？",
                                                    0,
                                                    MessageBoxButtons.YesNo);

                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                    Save();
                    // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
                    this._adjustStockAcs.IsDataChanged = false;
					break;
				case "ButtonTool_New":
					//--------------------------------------------------------------
					// 新規ボタン
					//--------------------------------------------------------------
					// 新規処理
					this.NewEditTabChild(true);
                    this._adjustStockAcs.IsDataChanged = false;
					break;
                /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
				case "ButtonTool_Undo":
					//--------------------------------------------------------------
					// 元に戻すボタン
					//--------------------------------------------------------------
					// 復帰処理
					this.RetryEditTabChild();
					break;
                   --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
                case "ButtonTool_Delete":
					//--------------------------------------------------------------
					// 削除ボタン
					//--------------------------------------------------------------
					// 削除処理
					this.DeleteEditTabChild();
					break;
                // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
                case "ButtonTool_Load":
                    //--------------------------------------------------------------
                    // 伝票呼出ボタン
                    //--------------------------------------------------------------
                    // 伝票呼出処理
                    LoadSlip();
                    break;
                case "ButtonTool_OrderAddUp":
                    //--------------------------------------------------------------
                    // 発注計上ボタン
                    //--------------------------------------------------------------
                    // 発注計上処理
                    AddUpOrder();
                    break;
                case "ButtonTool_Setup":
                    //--------------------------------------------------------------
                    // 設定ボタン
                    //--------------------------------------------------------------
                    // 設定処理
                    SetUp();
                    break;
                // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
                case "ButtonTool_Renewal":
                    {
                        mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
                        mazai04360UA.Renewal();
                        // --- ADD 2009/12/16 ---------->>>>>
                        // 定価入力区分の再取得
                        GetListPriceInpDiv();
                        // 単価入力区分の再取得
                        GetUnitPriceInpDiv();
                        // --- ADD 2009/12/16 -----------<<<<<
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "最新情報を取得しました。",
                                      0,
                                      MessageBoxButtons.OK);
                        break;
                    }
                // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                case "ButtonTool_InputStock":
                    {
                        InputStock();
                        break;
                    }
                // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
			}
		}

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫調整データの登録を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void Save()
        {
			this._cancelEventFlg = true;
                                
            string retMessage;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            // 入力チェック
            bool bStatus = mazai04360UA.CheckInputData(out retMessage);
            if (!bStatus)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                              ctPGID,
                              retMessage,
                              0,
                              MessageBoxButtons.OK);

                ChangeFocusFooter(false);
                this._cancelEventFlg = false;

                return;
            }

            bool priceUpdateFlg;

            // 定価原価更新区分チェック
            switch (this._priceCostUpdtDiv)
            {
                case 0:
                    // 非更新
                    priceUpdateFlg = false;
                    break;
                case 1:
                    // 無条件更新
                    priceUpdateFlg = true;
                    break;
                case 2:
                    // 確認更新
                    DialogResult result = TMsgDisp.Show(this,
                                                        emErrorLevel.ERR_LEVEL_QUESTION,
                                                        this.Name,
                                                        "価格・原価を更新しますか？",
                                                        0,
                                                        MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        priceUpdateFlg = true;
                    }
                    else if (result == DialogResult.No)
                    {
                        priceUpdateFlg = false;
                    }
                    else
                    {
                        mazai04360UA.SetDefaultFocus();
                        this._cancelEventFlg = false;
                        return;
                    }
                    break;
                default:
                    priceUpdateFlg = false;
                    break;
            }

            // 発注残履歴修正フラグ
            bool orderListResultFlg = mazai04360UA.GetOrderListResultFlg();

            // 登録処理
            bool isNew;
            int stockAdjustSlipNo;
            int status = _adjustStockAcs.SaveDBData(out stockAdjustSlipNo, out retMessage, out isNew, priceUpdateFlg, orderListResultFlg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (!isNew)
                        {
                            // ログ出力
                            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                            {
                                MyOpeCtrl.Logger.WriteOperationLog(
                                    "Revision",
                                    (int)OperationCode.Revision,
                                    0,
                                    string.Format("{0}伝票、伝票番号:{1}を修正", "在庫仕入", stockAdjustSlipNo.ToString("000000000")));
                            }
                        }

                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        this._saveFlg = true;

                        this.NewEditTabChild(true);
                        this._adjustStockAcs.IsDataChanged = false;

                        mazai04360UA.SetStockAdjustSlipNo(stockAdjustSlipNo);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "現在、編集中の在庫データは既に削除されています。" + "\r\n" + "\r\n" +
                                      "在庫情報を再度取得しなおしてください",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "現在、編集中の在庫データは既に更新されています。" + "\r\n" + "\r\n" +
                                      "在庫情報を再度取得しなおしてください",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                // 企業ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(企業ロック)です。" + "\r\n" + 
                                      "月次更新か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // 拠点ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(拠点ロック)です。" + "\r\n" +
                                      "締更新か、処理が込み合っているためタイムアウトしました。。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                // 倉庫ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      "シェアチェックエラー(倉庫ロック)です。" + "\r\n" +
                                      "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                      "再試行するか、しばらく待ってから再度処理を行ってください。",
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOP,
                                      this.Name,
                                      "MAZAI04350U",
                                      "Save",
                                      TMsgDisp.OPE_UPDATE,
                                      retMessage,
                                      status,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                        break;
                    }
            }

			this._cancelEventFlg = false;
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private void Save(bool isShowSaveCompletionDialog, object sender)
        {
            this._cancelEventFlg = true;

            string retMessage;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();

            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            int mode = mazai04360UA.ModetCmbEditor.SelectedIndex;

            string slipnote = mazai04360UA.GetSlipNote();

            //登録
            int status = mazai04360UA.CheckInputData(sender);
            if (status != 0)
            {
                if (status == -1)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ctPGID,
                        "商品が1件も登録されていません。",
                        0,
                        MessageBoxButtons.OK);
                    this._cancelEventFlg = false;
                    return;
                }
                else if (status == -2)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ctPGID,
                        "調整数の入力がない行があります。",
                        0,
                        MessageBoxButtons.OK);
                    this._cancelEventFlg = false;
                    return;
                }
                else if (status == -3)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ctPGID,
                        "入力担当が入力されていません。",
                        0,
                        MessageBoxButtons.OK);
                    this._cancelEventFlg = false;
                    return;
                }
            }

            status = _adjustStockAcs.SaveDBData(out retMessage, mode, slipnote, GetDate());
            if (status == 0)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
                //GRID初期化
                _adjustStockAcs.DBDataClear();
                _adjustStockAcs.StockDataClear();

                AdjustStockAcs.RepaintProductStock();
                mazai04360UA.SetSlipNote("");
                mazai04360UA.SetDefaultFocus();
                mazai04360UA.ClrDsp(false);
            }
            else
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// 排他（別端末更新済）
                {

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "現在、編集中の在庫データは既に更新されています。" + "\r\n" + "\r\n" +
                        "在庫情報を再度取得しなおしてください",
                        -1,
                        MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("更新に失敗しました。" + "(" + status.ToString() + ")");
                }
            }
            this._cancelEventFlg = false;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        /// <summary>
		/// 選択タブチェンジ後イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void TabControl_Main_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
		{
			if (!this._enableTabChange) return;

			// 子画面のアクティブ処理
			this.TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);
		}

		/// <summary>
		/// 選択タブチェンジ前イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void TabControl_Main_SelectedTabChanging(object sender, SelectedTabChangingEventArgs e)
		{
			if (!this._enableTabChange) return;

			if (this.TabControl_Main.SelectedTab == null || this.TabControl_Main.SelectedTab.Key == null) return;

			// 子画面の非アクティブ処理
			if (this.TabDeactivattingProc(this.TabControl_Main.SelectedTab.Tag as Form) != 0)
			{
				e.Cancel = true;
			}
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ツールバー値変更時イベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolbarsManager_Main_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "ComboBoxTool_Section":
					//--------------------------------------------------------------
					// 入力拠点を変更する
					//--------------------------------------------------------------
					Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
					if (cmbOwnSection.Value is string)
					{

						// 選択した拠点コードを取得する
						string sectionCode = (string)cmbOwnSection.Value;			// 拠点コード

					}
					break;
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        /// <summary>
		/// バーコード読み取りイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tBarcodeReader1_BarcodeReaded(object sender, BarcodeReadedEventArgs e)
		{
			int st;

			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IStockEntryTbsCtrlChildResponse)
				{
					// 子画面アクション通知処理
					st = ((IStockEntryTbsCtrlChildResponse)_formControlInfo.Form).ChildResponse(this, _formControlInfo.Form, "BarcodeRead", e.BarcodeString);
				}
			}
		}
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  プライベートメソッド
		//----------------------------------------------------------------------------------------------------
		# region プライベートメソッド
        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 新規作成処理
		/// </summary>
		/// <param name="comparer">編集中チェック有無</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 新規ボタンが押された時に発動して、全データを初期化します。</br>
		/// <br>Programer  : 30414 忍 幸史</br>
		/// <br>Date       : 2008/07/24</br>
		/// </remarks>
		private int NewEditTabChild(bool comparer)
		{
			// タブ子画面が展開されていない→exit
			if (this.TabControl_Main.Tabs.Count <= 0) return -1;

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            if (!this._saveFlg)
            {
                if (!mazai04360UA.CompareScreen())
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                        "初期状態に戻しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2);

                    if (dialogResult != DialogResult.Yes)
                    {
                        return -1;
                    }
                }
            }

			if (comparer)
			{
				// 子画面に対して保存処理を行う
				this.StoreTabChild();
			}

			// 現在のカーソルを退避する
			Cursor bufCursor = this.Cursor;
			try
			{
				// カーソルを『Wait』にする
				this.Cursor = Cursors.WaitCursor;

				// 子画面に対して再表示を実行させる
				this.ShowTabChild();

				//･･････････････････････････････････････････････････････････････････････････
				// 画面系の初期化を行う
				//･･････････････････････････････････････････････････････････････････････････
				try
				{
                    // ツールバー調整
					this.ToolbarEnableChange(0);
				}
				finally
				{
					// 画面に表示した内容を初期値にする
					this.StoreTabChild();
				}
			}
			finally // マウスカーソルに対するfinally
			{
				// マウスカーソルを元に戻す
				this.Cursor = bufCursor;
			}
            //GRID初期化
            _adjustStockAcs.DBDataClear();

            mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.ClrDsp(true);
            mazai04360UA.SetDefaultFocus();

            AdjustStockAcs.RepaintProductStock();

			return 0;
		}
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 新規作成処理
        /// </summary>
        /// <param name="comparer">編集中チェック有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンが押された時に発動して、全データを初期化します。</br>
        /// <br>Programer  : 19077 渡邉貴裕</br>
        /// <br>Date       : 2007.03.12</br>
        /// </remarks>
        private int NewEditTabChild(bool comparer)
        {
            // タブ子画面が展開されていない→exit
            if (this.TabControl_Main.Tabs.Count <= 0) return -1;

            if (comparer)
            {
                // 子画面に対して保存処理を行う
                this.StoreTabChild();

                //// 編集画面に変化があっているか？
                //if (this._stockMngAcs.CompareStaticMemory(this) != 0)
                //{
                //    // 変更ありの為、保存確認のダイアログを表示する	
                //    DialogResult retResult = TMsgDisp.Show(
                //        emErrorLevel.ERR_LEVEL_QUESTION,
                //        ctPGID,
                //        "現在、編集中のデータが存在します\n\n" + "登録してもよろしいですか？",
                //        0,
                //        MessageBoxButtons.YesNoCancel);

                //    switch (retResult)
                //    {
                //        case DialogResult.Yes:
                //            // はい
                //            if (this.SaveEditTabChild() != 0) return -1;
                //            break;
                //        case DialogResult.No:
                //            // いいえ
                //            break;
                //        case DialogResult.Cancel:
                //            // キャンセル
                //            return -1;
                //    }
                //}
            }

            // 現在のカーソルを退避する
            Cursor bufCursor = this.Cursor;
            try
            {
                // カーソルを『Wait』にする
                this.Cursor = Cursors.WaitCursor;

				// 表示モード初期化
				this.SettingDispMode((int)ChildFormDispMode.Normal);

                //･･････････････････････････････････････････････････････････････････････････
                // 関連するアクセスクラスを初期化する
                //･･････････････････････････････････････････････････････････････････････････
                // 仕入管理アクセスクラス初期化
                // this._stockMngAcs.InitStaticMemory(0, this._enterpriseCode, this._ownSectionCode, 1, (int)ConstantManagement_SF_SIR.SupplierSlipKind.PartsSuplSlip);

                // 子画面に対して再表示を実行させる
                this.ShowTabChild();

                //･･････････････････････････････････････････････････････････････････････････
                // 画面系の初期化を行う
                //･･････････････････････････････････････････････････････････････････････････
                try
                {

                    // 拠点情報表示
                    //					this.ShowToolBarSection();

					// 仕入先のツールバーを設定する
					this.ShowToolbarSupplier();

                    // ツールバー調整
                    this.ToolbarEnableChange(0);
                }
                finally
                {
                    // 画面に表示した内容を初期値にする
                    this.StoreTabChild();
                    // this._stockMngAcs.CopyStaticMemory(this, 0);	// 0:Main→Undo
                }
            }
			finally // マウスカーソルに対するfinally
            {
                // マウスカーソルを元に戻す
                this.Cursor = bufCursor;
            }
            //GRID初期化
            _adjustStockAcs.DBDataClear();

            _adjustStockAcs.StockDataClear();

            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.ClrDsp(true);
            AdjustStockAcs.RepaintProductStock();

            return 0;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : データの保存処理を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int SaveEditTabChild()
		{
			if (_formControlInfo.Form != null)
			{
				int st = 0;


				// 子画面入力チェック
				if (this.CheckEditTabChild() != 0) return 1;

				// 編集画面のデータをStaticな領域に保存する
				this.StoreTabChild();

				// 現在のカーソルを退避する
				Cursor localCursor = this.Cursor;
				//string retMsg = "", retItemInfo;
                string retMsg = "";

				try
				{
					// カーソルを『Wait』にする
					this.Cursor = Cursors.WaitCursor;
					// 画面の再描画
					Refresh();

					this._WaitingDialog = new SFCMN00299CA();
					this._WaitingDialog.Title = "保存中";							// 画面のタイトルバーに表示する文字列
					this._WaitingDialog.Message = "伝票データの保存中です．．．";	// 画面のプログレスバーの上に表示する文字列
					this._WaitingDialog.Show(this);

					// StaticなデータをDBに書き込む
//*					st = this._stockMngAcs.WriteDBData(this, out retMsg, out retItemInfo, false);
				}
				finally
				{
					// 登録中画面の非表示
					this._WaitingDialog.Close();

					// カーソルを元に戻す
					this.Cursor = localCursor;
				}

				switch (st)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

						// 伝票番号表示用
						this.ShowToolbarSupplier();
#if true
                        // 保存確認のダイアログを表示する

						// 画面クリア
						this.NewEditTabChild(false);
#else
						// 子画面に対して再表示を実行させる
						this.ShowTabChild();

						// 保存確認のダイアログを表示する
						SaveCompletionDialog saveDialog = new SaveCompletionDialog();
						saveDialog.Owner = this;
						saveDialog.ShowDialog("RED", 2);

						// ツールバー調整
						this.ToolbarEnableChange(1);

						// 画面に表示した内容を初期値にする
						this._stockMngAcs.CopyStaticMemory(this, 0);	// 0:Main→Undo
#endif
					break;

					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE :
						// 仕入管理の書き込みで仕入先伝票番号が重複
						retMsg = "入力された仕入先伝票番号は既に登録済みです。\n\n他の仕入先伝票番号を設定してください。";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, retMsg, st, MessageBoxButtons.OK);
						if ((_formControlInfo != null) && (_formControlInfo.Form is IStockEntryTbsCtrlChildResponse))
						{
							// 子画面アクション通知処理(仕入先伝票番号にフォーカス遷移)
							((IStockEntryTbsCtrlChildResponse)_formControlInfo.Form).ChildResponse(this, _formControlInfo.Form, "SetFocus_SlipNo", null);
						}
						return st;

					case (int)ConstantManagement.DB_Status.ctDB_WARNING :
						// 仕入管理の書込みで締チェックNG
						// (締済みに対する更新チェック＆最終締日より過去の仕入日付チェック)
						// 仕入先フラグチェックNG
						// (得意先情報に部品仕入の種別がONになっていない)
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;

					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE :
						// 既に更新されている
						retMsg = "編集中の仕入伝票は、既に他の端末で更新されています。\n\n再度、この仕入伝票を呼び出して編集してください。";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;

					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
						// 既に削除されている
						retMsg = "編集中の仕入伝票は、既に他の端末で削除されています。";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;

					default:
						// 仕入管理の書き込みでエラーが発生
						retMsg = "仕入伝票の書き込みでエラーが発生しました。\n\n" + retMsg;
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ctPGID, retMsg, st, MessageBoxButtons.OK);
						return st;
				}
			}

			return 0;
        }

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 初期表示のデータに戻します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int RetryEditTabChild()
		{
			// 子画面の現在の情報を保存させる
			this.StoreTabChild();
			return 0;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 伝票呼出処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票ガイドを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private int LoadSlip()
        {
            // 画面情報取得
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            // 在庫仕入伝票照会画面起動
            mazai04360UA.ShowStockSlipGuide();

            return 0;
        }

        /// <summary>
        /// 発注計上処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 発注計上画面を表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private int AddUpOrder()
        {
            // 画面情報取得
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

            // 発注残照会画面起動
            mazai04360UA.ShowOrderHisGuide();
            ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = false;
            return 0;
        }

        /// <summary>
        /// ユーザー設定画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー設定画面を表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void SetUp()
        {
            ArrayList userSettingList;

            // 画面情報取得
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.GetUserSetting(out userSettingList);

            MAZAI04350UC mazai04350UC = new MAZAI04350UC(userSettingList);
            DialogResult res = mazai04350UC.ShowDialog();
            if (res == DialogResult.OK)
            {
                // ユーザー設定情報反映
                userSettingList = mazai04350UC.UserSettingList;
                mazai04360UA.SetUserSetting(userSettingList);
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : データの保存処理を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int DeleteEditTabChild()
		{
			DialogResult Dresult = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_QUESTION,
				ctPGID,
				"選択中の仕入伝票を削除します。\n\nよろしいですか？",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			if (Dresult == DialogResult.Yes)
			{
                MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
                mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;

                DateTime targetDate;
                if (!mazai04360UA.CheckHisTotalDayMonthly(mazai04360UA.GetStockSectionCode(), mazai04360UA.GetDate(), out targetDate))
                {
                    string errMsg = "仕入日が前回月次更新日以前になっている為、削除できません。" + "\r\n\r\n" + "  前回月次更新日：" + targetDate.ToString("yyyy年MM月dd日");
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  errMsg,
                                  0,
                                  MessageBoxButtons.OK);
                    return (0);
                }

                int st = 0; //*
                // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
                int slipNo;
                st = this._adjustStockAcs.DeleteDBData(out slipNo);
                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // ログ出力
                            if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Delete))
                            {
                                MyOpeCtrl.Logger.WriteOperationLog(
                                    "Delete",
                                    (int)OperationCode.Delete,
                                    0,
                                    string.Format("{0}伝票、伝票番号:{1}を削除", "在庫仕入", slipNo.ToString("000000000")));
                            }

                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "在庫仕入伝票を削除しました。",
                                          0,
                                          MessageBoxButtons.OK);

                            this.NewEditTabChild(true);
                            this._adjustStockAcs.IsDataChanged = false;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "現在、編集中の在庫データは既に削除されています。" + "\r\n" + "\r\n" +
                                          "在庫情報を再度取得しなおしてください",
                                          st,
                                          MessageBoxButtons.OK);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "現在、編集中の在庫データは既に更新されています。" + "\r\n" + "\r\n" +
                                          "在庫情報を再度取得しなおしてください",
                                          st,
                                          MessageBoxButtons.OK);
                            break;
                        }
                    // 企業ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "MAZAI04350U",
                                          "DeleteEditTabChild",
                                          TMsgDisp.OPE_DELETE,
                                          "シェアチェックエラー(企業ロック)です。" + "\r\n" +
                                          "月次更新か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          st,
                                          this._adjustStockAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            break;
                        }
                    // 拠点ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "MAZAI04350U",
                                          "DeleteEditTabChild",
                                          TMsgDisp.OPE_DELETE,
                                          "シェアチェックエラー(拠点ロック)です。" + "\r\n" +
                                          "締更新か、処理が込み合っているためタイムアウトしました。。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          st,
                                          this._adjustStockAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            break;
                        }
                    // 倉庫ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "MAZAI04350U",
                                          "DeleteEditTabChild",
                                          TMsgDisp.OPE_DELETE,
                                          "シェアチェックエラー(倉庫ロック)です。" + "\r\n" +
                                          "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          st,
                                          this._adjustStockAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOP,
                                      this.Name,
                                      "MAZAI04350U",
                                      "DeleteEditTabChild",
                                      TMsgDisp.OPE_DELETE,
                                      "削除に失敗しました。" + "(" + st.ToString() + ")",
                                      st,
                                      this._adjustStockAcs,
                                      MessageBoxButtons.OK,
                                      MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
                // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
                return st;
			}

			return 0;
        }

        #region DEL 2008/07/24 使用していないでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 仕入先情報取得・更新処理
		/// </summary>
		/// <param name="mode">データコピーモード[0:両方, 1:リアルのみ]</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns></returns>
		private int ReadNewEntry(int mode, int customerCode)
		{
			if (customerCode == 0) return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないでコメントアウト

        /// <summary>
		/// 子画面の保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 子画面に対して、Staticに保存させる処理を実行させます。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int StoreTabChild()
		{
			int st = -1;

			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IStockEntryTbsCtrlChildEdit)
				{
					// スタティック保存処理
					st = ((IStockEntryTbsCtrlChildEdit)_formControlInfo.Form).SaveStaticMemoryData(this);
				}
			}

			return st;
		}

		/// <summary>
		/// 子画面へStatic情報を表示させる
		/// </summary>
		/// <remarks>
		/// <br>Note       : 子画面に対して、Staticに保持されているデータを表示するように要求します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void ShowTabChild()
		{
			if (_formControlInfo != null)
			{
				if (_formControlInfo.Form is IStockEntryTbsCtrlChild)
				{
					// スタティック表示処理
					((IStockEntryTbsCtrlChild)_formControlInfo.Form).ShowStaticMemoryData(this, this._dispMode);
				}
			}
		}

		/// <summary>
		/// 子画面（編集画面）の入力チェック処理
		/// </summary>
		/// <returns>0=入力エラー無し,1=入力エラー有り</returns>
		/// <remarks>
		/// <br>Note       : MDIフォーム(編集画面）の入力チェック処理</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private int CheckEditTabChild()
		{
			if (_formControlInfo != null)
			{
				// 画面に対して入力内容のチェックを行う
				if (_formControlInfo.Form is IStockEntryTbsCtrlChildCheck)
				{
					if (((IStockEntryTbsCtrlChildCheck)_formControlInfo.Form).CheckInputData(this) != 0)
						return 1;
				}                
			}

			return 0;
		}

		/// <summary>
		/// タブアクティブ処理
		/// </summary>
		/// <param name="form"></param>
		private void TabActivatedProc(Form form)
		{
			if (form != null)
			{
				if (this._formControlInfo == null) return;

				// 子画面にアクティブイベントを通知する
				if (form is IStockEntryTbsCtrlChildEvent)
				{
					((IStockEntryTbsCtrlChildEvent)form).EntryTabChildFormActivated(this, EventArgs.Empty);
				}

				// 子画面の描画をかける
				this.RefreshTabChild(form);
			}
		}

		/// <summary>
		/// タブ非アクティブ処理
		/// </summary>
		/// <param name="form"></param>
		/// <returns></returns>
		private int TabDeactivattingProc(Form form)
		{
			if (form != null)
			{
				// 子画面に非アクティブイベントを通知する
				if (form is IStockEntryTbsCtrlChildEvent)
				{
					((IStockEntryTbsCtrlChildEvent)form).EntryTabChildFormDeactivate(this, EventArgs.Empty);
				}
			}

			return 0;
		}

		/// <summary>
		/// MDI子画面の再描画指示（staticな領域からデータを取得して表示）
		/// </summary>
		/// <param name="form">MDI子画面(編集画面)</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI子画面の再描画指示（staticな領域からデータを取得して表示）</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void RefreshTabChild(Form form)
		{
			if (form != null)
			{
				// IStockEntryTbsCtrlChildインターフェイスを実装している場合は以下の処理を実行する。
				if ((form is IStockEntryTbsCtrlChild))
				{
					((IStockEntryTbsCtrlChild)form).ShowStaticMemoryData(this, this._dispMode);
				}
			}
		}

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫評価方法取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定マスタから在庫評価方法を取得します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void GetStockPointWay()
        {
            int status;
            StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
            ArrayList retList;

            try
            {
                status = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockMngTtlSt stockMngTtlSt in retList)
                    {
                        if (stockMngTtlSt.SectionCode.Trim() == "00")
                        {
                            this._stockPointWay = stockMngTtlSt.StockPointWay;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 定価原価更新区分取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定マスタから定価原価更新区分を取得します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void GetPriceCostUpdtDiv()
        {
            int status;
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
            ArrayList retList;

            try
            {
                status = stockTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockTtlSt stockTtlSt in retList)
                    {
                        if (stockTtlSt.SectionCode.Trim() == LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                        {
                            this._priceCostUpdtDiv = stockTtlSt.PriceCostUpdtDiv;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
        /// <summary>
        /// 在庫を入力します。
        /// </summary>
        private void InputStock()
        {
            MAZAI04360UA mainForm = (MAZAI04360UA)_formControlInfo.Form;
            mainForm.InputStock();
        }
        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<


        // --- ADD 2009/12/16 ---------->>>>>
        /// <summary>
        /// 定価入力区分取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定マスタから定価入力区分を取得します。</br>
        /// <br>Programer  : 朱俊成</br>
        /// <br>Date       : 2009/12/16</br>
        /// </remarks>
        private void GetListPriceInpDiv()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.GetListPriceInpDiv();
        }

        /// <summary>
        /// 単価入力区分取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定マスタから単価入力区分を取得します。</br>
        /// <br>Programer  : 朱俊成</br>
        /// <br>Date       : 2009/12/16</br>
        /// </remarks>
        private void GetUnitPriceInpDiv()
        {
            MAZAI04360UA mazai04360UA = MAZAI04360UA.GetInstance();
            mazai04360UA = (MAZAI04360UA)_formControlInfo.Form;
            mazai04360UA.GetUnitPriceInpDiv();
        }
        // --- ADD 2009/12/16 -----------<<<<<

		# endregion

		//----------------------------------------------------------------------------------------------------
		//  プライベートメソッド(タブ構築関連)
		//----------------------------------------------------------------------------------------------------
		# region プライベートメソッド(タブ構築関連)
		/// <summary>
		/// フォームコントロールクラスクリエイト処理
		/// </summary>
		/// <param name="NexViewFormname">次に表示するフォーム</param>
		/// <remarks>
		/// <br>Note       : フレームが起動するフォームクラステーブルを生成します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void FormControlInfoCreate(string NexViewFormname)
		{
			_formControlInfo = null;

			_formControlInfo = new FormControlInfo(
				NO0_TOP_TAB,
				"MAZAI04360U",
				"Broadleaf.Windows.Forms.MAZAI04360UA",
				"在庫仕入入力",
				IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
				NO_TAB,
				NO_TAB);
		}

		/// <summary>
		/// タブクリエイト処理
		/// </summary>
		/// <param name="key">タブ管理キー</param>
		/// <remarks>
		/// <br>Note       : フレームのタブをクリエイトします。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			Cursor localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				switch (key)
				{
					case NO0_TOP_TAB:
						// 先頭画面生成
						if (_formControlInfo == null) return;

						this.CreateTabChildForm(_formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
						break;
				}
			}
			finally
			{
				this.Cursor = localCursor;
			}
		}

		/// <summary>
		/// TAB子画面を生成する
		/// </summary>
		/// <param name="frmAssemblyName">フォームアセンブリ名</param>
		/// <param name="frmClassName">フォームクラス名称</param>
		/// <param name="title">表示タイトル</param>
		/// <param name="frmName">フォーム名</param>
		/// <param name="icon">アイコン・イメージ</param>
		/// <param name="info">フォーム制御情報</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : TAB子画面を生成する</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info)
		{
			Form form = null;
			form = (Form)this.LoadAssemblyFrom(frmAssemblyName, frmClassName, typeof(Form));

			if (form == null)
			{
//				ErrorForm ef = new ErrorForm();
//				form = (System.Windows.Forms.Form)ef;
			}
			else
			{
				// フォームプロパティ変更
				form.Name = frmName;

				// タブページコントロールをインスタンス
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// タブの外観を設定し、タブコントロールにタブを追加する
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = title;												// 名称
				uTab.Key = frmName;												// Key
				uTab.Tag = form;												// フォームのインスタンス
				uTab.Appearance.Image = icon;									// アイコン
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
				uTab.ActiveAppearance.BackColor = Color.White;
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

				this.TabControl_Main.Controls.Add(uTabPageControl);
				this.TabControl_Main.Tabs.AddRange(new UltraTab[] { uTab });
				this.TabControl_Main.SelectedTab = uTab;

				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
				// IStockEntryTbsCtrlChildインターフェイスを実装している場合は以下の処理を実行する。
				if ((form is IStockEntryTbsCtrlChild))
				{
					// 今のところパラメータは特に無し
					((IStockEntryTbsCtrlChild)form).Show(null);
				}
				else
				{
					form.Show();
				}

				uTabPageControl.Controls.Add(form);
				form.Dock = DockStyle.Fill;
			}

			info.Form = form;
			return form;
		}

		/// <summary>
		/// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note       : アセンブリをロードします。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				Assembly asm = Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (FileNotFoundException ex)
			{
				// 対象アセンブリなし（警告）
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, ex.StackTrace, 0, MessageBoxButtons.OK);
			}
			catch (System.Exception ex)
			{
				// 対象アセンブリなし（警告)
				string _msg = "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, _msg, 0, MessageBoxButtons.OK);
			}
			return obj;
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private void InitialProc()
        {
            // 全従業員情報を取得
            object returnEmployee;
            EmployeeWork paraEmployee = new EmployeeWork();
            paraEmployee.EnterpriseCode = _enterpriseCode;

            int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnEmployee is ArrayList)
                {                    
                    foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                    {
                        _employeeList.Add(employeeWork);
                    }
                }
            }
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        # endregion


        //----------------------------------------------------------------------------------------------------
		//  プライベートメソッド(画面設定関連)
		//----------------------------------------------------------------------------------------------------
		# region プライベートメソッド(画面設定関連)

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ツールバー仕入情報表示処理
		/// </summary>
		private void ShowToolbarSupplier()
		{
		}

		/// <summary>
		/// 画面表示モード設定処理
		/// </summary>
		/// <param name="dispMode">表示モード</param>
		private void SettingDispMode(int dispMode)
		{
			this._dispMode = dispMode;

			switch (dispMode)
			{
				case (int)ChildFormDispMode.Normal:
				case (int)ChildFormDispMode.RefNormal:
//					this.DockManager_Main.Enabled = true;
					// 拠点変更可
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
					break;
				case (int)ChildFormDispMode.ReadOnly:
//					this.DockManager_Main.Enabled = false;
					// 拠点変更不可
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
					break;
				case (int)ChildFormDispMode.RefNew:
//					this.DockManager_Main.Enabled = true;
					// 拠点変更可
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
					break;
				case (int)ChildFormDispMode.RefRed:
//					this.DockManager_Main.Enabled = false;
					// 拠点変更不可
					this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
					break;
			}

			// ステータスバー表示
			if (dispMode == (int)ChildFormDispMode.ReadOnly)
			{
				this.ultraStatusBar1.Panels["Text"].Text = "読み取り専用";
			}
			else
			{
				this.ultraStatusBar1.Panels["Text"].Text = "";
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
		/// ツールバーのアイコン設定
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームのツールバーの設定を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.12</br>
		/// </remarks>
		private void SettingToolbar()
		{
			//--------------------------------------------------------------
			// メインツールバー
			//--------------------------------------------------------------
			// イメージリストを設定する
			this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
			// 拠点のアイコン設定
			ToolbarsManager_Main.Tools["LabelTool_SectionTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
            // ログイン担当者のアイコン設定
			ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// 終了のアイコン設定
			ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// 保存のアイコン設定
			ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// 新規のアイコン設定
			ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            // 削除のアイコン設定
            ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 伝票呼出のアイコン設定
            ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            // 発注計上のアイコン設定
            ToolbarsManager_Main.Tools["ButtonTool_OrderAddUp"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // 設定のアイコン設定
            ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

            // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
            // 在庫のアイコン設定
            ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PACKAGEINPUT;
            // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

			// ログイン名
			ToolBase LoginName = ToolbarsManager_Main.Tools["LabelTool_LoginName"];
			if (LoginName != null && LoginInfoAcquisition.Employee != null)
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				LoginName.SharedProps.Caption = employee.Name;

                /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
                _employeeCd = employee.EmployeeCode;
                _employeeNm = employee.Name;                
                   --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
            }

		}

        /// <summary>
        /// ツールバー有効無効変更処理
        /// </summary>
        /// <param name="mode">モード[0:初期表示, 1:更新時]</param>
        private void ToolbarEnableChange(int mode)
        {
            switch (mode)
            {
                case 0:
                    // 削除ボタン無効
                    ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
                    ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_OrderAddUp"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = true;

                    // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                    // 在庫ボタンは非在庫品を入力時のみ有効
                    ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.Enabled = false;
                    // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

                    break;
                case 1:
                    // 削除ボタン有効
                    ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Load"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_OrderAddUp"].SharedProps.Enabled = false;
                    ToolbarsManager_Main.Tools["ButtonTool_Setup"].SharedProps.Enabled = true;
                    ToolbarsManager_Main.Tools["ButtonTool_Renewal"].SharedProps.Enabled = false;

                    // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                    // 在庫ボタンは非在庫品を入力時のみ有効
                    ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.Enabled = false;
                    // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

                    break;
            }
        }

        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
        /// <summary>
        /// 在庫登録操作を有効（無効）にするイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void EnabledToInputStock(
            object sender,
            MAZAI04360UA.EnabledToInputStockEventArgs e
        )
        {
            ToolbarsManager_Main.Tools["ButtonTool_InputStock"].SharedProps.Enabled = e.Enabled;
        }
        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

        private void ChangeFocusFooter(Boolean changeFlg)
        {
            if (changeFlg == true)
            {
                ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Caption = "保存(F10)";
            }
            else
            {
                ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Caption = "確定(F10)";
            }
        }

        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンを「Visible = False」にすると、イベントが発生しないため、
            // サイズを「1, 1」にし、実質的に見えないようにする

            DialogResult dResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "終了してもよろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close(true, sender);
            }
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ツールバー有効無効変更処理
		/// </summary>
		/// <param name="mode">モード[0:初期表示, 1:呼出し, 2:読み取り専用]</param>
		private void ToolbarEnableChange(int mode)
		{
			switch (mode)
			{
				case 0:
					// 保存ボタン有効
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// 削除ボタン無効
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
				case 1:
					// 保存ボタン有効
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// 削除ボタン有効
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
					break;
				case 2:
					// 保存ボタン無効
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
					// 削除ボタン無効
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        # endregion
    }
}