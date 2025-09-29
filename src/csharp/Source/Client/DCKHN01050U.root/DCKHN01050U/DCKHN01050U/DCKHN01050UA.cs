using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 単価情報確認画面フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 単価情報画面フォームクラスです。</br>
	/// <br>Programmer	: 21024　佐々木 健</br>
	/// <br>Date		: 2008.06.24</br>
    /// <br>Update Note : 2010/08/12 楊明俊 PM1012対応</br>
    /// <br>              標準価格、売価、原価情報の一括表示を可能とする</br>
    /// <br>Update Note : 2013/01/24 鄧潘ハン</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分</br>
    /// <br>            : Redmine#34605 売上画面の価格ｶﾞｲﾄﾞ表示に『拠点』や『表示区分』の追加</br>
    /// <br>Update Note: K2014/02/09 yangyi</br>
    /// <br>管理番号   : 10970681-00 前橋京和商会個別個別対応</br>
    /// <br>           : 売上伝票入力の改良対応</br>
    /// <br>Update Note: K2014/05/14 zhaicy</br>
    /// <br>管理番号   : 10970681-00 前橋京和商会個別個別対応</br>
    /// <br>           : Redmine#42658 単価情報ガイドのオプション制御障害</br>
    /// </remarks>
	public partial class DCKHN01050UA : Form
    {
        #region■Constructor

		/// <summary>
		/// 単価情報確認画面フォームクラス コンストラクタ
		/// </summary>
        public DCKHN01050UA()
		{
			InitializeComponent();

			// 変数初期化
			//this._customerClaimConfAcs = new CustomerClaimConfAcs();
            this._imageList16 = IconResourceManagement.ImageList16;

			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
			this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
			this._controlScreenSkin = new ControlScreenSkin();
			this._unitPriceInfoConfAcs = new DCKHN01051A();
			this._unitPriceInfoConf = new UnPrcInfoConf();

			#region クリア対象コンポリストの生成
			_clearTargetList = new List<object>();
			_clearTargetList.Add(this.uLabel_BLGoodsCode);
			_clearTargetList.Add(this.uLabel_BLGoodsFullName);
			_clearTargetList.Add(this.uLabel_StandardCount);
            _clearTargetList.Add(this.uLabel_CustomerCode);
			_clearTargetList.Add(this.uLabel_CustomerSnm);
			_clearTargetList.Add(this.uLabel_CustRateGrpCode);
			_clearTargetList.Add(this.uLabel_GoodsName);
			_clearTargetList.Add(this.uLabel_GoodsNo);
			_clearTargetList.Add(this.uLabel_GoodsRateRank);
			_clearTargetList.Add(this.uLabel_GoodsRateGrpName);
			_clearTargetList.Add(this.uLabel_GoodsMakerCd);
			_clearTargetList.Add(this.uLabel_MakerName);
			_clearTargetList.Add(this.uLabel_BLGroupCode);
			_clearTargetList.Add(this.uLabel_BLGroupName);
			_clearTargetList.Add(this.uLabel_RateDiv);
			_clearTargetList.Add(this.uLabel_RateDivName);
			_clearTargetList.Add(this.uLabel_SupplierSnm);
            _clearTargetList.Add(this.uLabel_SupplierCd);
			_clearTargetList.Add(this.tDateEdit_TargetDay);
			_clearTargetList.Add(this.tComboEditor_UnitPrcCalcDiv);
			_clearTargetList.Add(this.tNedit_StdUnitPrice);
			_clearTargetList.Add(this.tNedit_Rate);
			_clearTargetList.Add(this.tNedit_UnPrcFracProcUnit);
			_clearTargetList.Add(this.tNedit_UnitPrice);
			_clearTargetList.Add(this.tComboEditor_UnPrcFracProcDiv);
            _clearTargetList.Add(this.tEdit_TaxationCode);
			#endregion
		}

        #endregion

        #region■Private Members

		private ControlScreenSkin _controlScreenSkin;
		
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private DialogResult _dialogRes = DialogResult.Cancel;					// ダイアログリザルト

		private DisplayType _displayType = DisplayType.SalesUnitPrice;			// 画面タイプ(デフォルトは売上単価)
		private bool _readOnly = true;											// 読み取り専用モード

		private DCKHN01051A _unitPriceInfoConfAcs;
		private UnPrcInfoConf _unitPriceInfoConf;
		private List<object> _clearTargetList;

		// 小数入力用定義
		private const Int32 MAXLENGTH_DECIMAL = 14;
		private const string NULLTEXT_DECIMAL = "0.00";
		private const Int32 NUMEDIT_DECIMAL = 2;

		// 整数入力定義
		private const Int32 MAXLENGTH_INT = 11;
		private const string NULLTEXT_INT = "0";
		private const Int32 NUMEDIT_INT = 0;

        //-----ADD 2010/08/12----------->>>>>
        //価格tabデータ
        UnPrcInfoConf _unitPriceInfoConfPrice;
        //売単価tabデータ
        UnPrcInfoConf _unitPriceInfoConfSales;
        //原単価tabデータ
        UnPrcInfoConf _unitPriceInfoConfUnit;

        private const string SALESUNITPRICE_TAB = "salesUnitPrice_tab";
        private const string UNITCOST_TAB = "unitCost_tab";
        private const string LISTPRICE_TAB = "listPrice_tab";
        //-----ADD 2010/08/12-----------<<<<<
        #endregion

		#region ■Enums
		/// <summary>
		/// 画面タイプ
		/// </summary>
		public enum DisplayType : int
		{
			/// <summary>売上単価</summary> 
			SalesUnitPrice = 1,
			/// <summary>原価単価</summary>
			UnitCost = 2,
			/// <summary>定価</summary>
			ListPrice =3
		}
		#endregion

        #region ■Properties

		/// <summary>単価情報確認結果プロパティ</summary>
		public UnPrcInfoConfRet UnPrcInfoConfRet
		{
			get { return this._unitPriceInfoConfAcs.UnPrcInfoConfRet; }
		}

		#endregion

        #region ■Public Methods

        ///// <summary>
        ///// 画面表示処理（オーバーロード）
        ///// </summary>
        ///// <param name="owner"></param>
        ///// <param name="displayType"></param>
        ///// <param name="unitPriceInfoConf"></param>
        ///// <param name="readOnly"></param>
        ///// <returns></returns>
        //public DialogResult ShowDialog( IWin32Window owner, DisplayType displayType, UnPrcInfoConf unitPriceInfoConf ,bool readOnly)
        //{
        //    this._readOnly = readOnly;

        //    return this.ShowDialog(owner, displayType, unitPriceInfoConf);
        //}

		/// <summary>
		/// 画面表示処理（オーバーロード）
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="displayType"></param>
		/// <param name="unitPriceInfoConf"></param>
		/// <returns></returns>
		public DialogResult ShowDialog( IWin32Window owner, DisplayType displayType, UnPrcInfoConf unitPriceInfoConf )
		{
			this._displayType = displayType;
			this._unitPriceInfoConfAcs.UnitPriceInfoConf = unitPriceInfoConf;
			this._unitPriceInfoConfAcs.UnitPriceKindCode= (int)displayType;
			this._unitPriceInfoConf = unitPriceInfoConf.Clone();
			return this.ShowDialog(owner);
		}
        //-----ADD 2010/08/12----------->>>>>
        /// <summary>
        /// 画面表示処理（オーバーロード）
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="displayType"></param>
        /// <param name="unPrcInfoConfList">リストのデータ順：価格、売単価、原単価</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowDialog(IWin32Window owner, DisplayType displayType, List<UnPrcInfoConf> unPrcInfoConfList)
        {
            int prcInfolen = unPrcInfoConfList.Count;
            if (unPrcInfoConfList == null || prcInfolen == 0)
            {
                return DialogResult.None;
            }

            this.prcInfo_TabControl.Visible = true;
            this.Form1_Fill_Panel.Location = new Point(0, 0);
            this.Form1_Fill_Panel.BorderStyle = BorderStyle.None;
            this.Form1_Fill_Panel.Visible = true;

            //各タブのデータを取得する
            this.getUnPrcInfoConf(unPrcInfoConfList);


            //画面タイプによって、画面表示設定する
            //売上単価の場合、「売上単価」タブを初期表示する
            if ((int)displayType == 1)
            {
                if (_unitPriceInfoConfSales != null)
                {
                    this.tabChange(_unitPriceInfoConfSales, displayType);
                }
            }
            //原価単価の場合、「原価単価」タブを初期表示する
            else if ((int)displayType == 2)
            {
                if (_unitPriceInfoConfUnit != null)
                {
                    this.tabChange(_unitPriceInfoConfUnit, displayType);
                }
            }
            //定価の場合、「定価」タブを初期表示する
            else if ((int)displayType == 3)
            {
                if (_unitPriceInfoConfPrice != null)
                {
                    this.tabChange(_unitPriceInfoConfPrice, displayType);
                }
            }
            this.setEnableTab();
            //show画面
            return this.ShowDialog(owner);
        }

        /// <summary>
        /// 各タブのデータの取得処理
        /// </summary>
        /// <param name="unPrcInfoConfList"></param>
        private void getUnPrcInfoConf(List<UnPrcInfoConf> unPrcInfoConfList)
        {
            //リストタブデータように、毎タブのデータを取得する
            int prcInfolen = unPrcInfoConfList.Count;
            switch (prcInfolen)
            {
                case 1:
                    { 
                        //価格tabデータ
                        _unitPriceInfoConfPrice = unPrcInfoConfList[0] as UnPrcInfoConf;
                        break;
                    }
                case 2:
                    {
                        //価格tabデータ
                        _unitPriceInfoConfPrice = unPrcInfoConfList[0] as UnPrcInfoConf;
                        //売単価tabデータ
                        _unitPriceInfoConfSales = unPrcInfoConfList[1] as UnPrcInfoConf;
                        break;
                    }
                case 3:
                    {
                        //価格tabデータ
                        _unitPriceInfoConfPrice = unPrcInfoConfList[0] as UnPrcInfoConf;
                        //売単価tabデータ
                        _unitPriceInfoConfSales = unPrcInfoConfList[1] as UnPrcInfoConf;
                        //原単価tabデータ
                        _unitPriceInfoConfUnit = unPrcInfoConfList[2] as UnPrcInfoConf;
                        break;
                    }
            }

        }

        /// <summary>
        /// 画面タイプ表示制御
        /// </summary>
        private void setEnableTab()
        {
            //価格tabデータ
            if (_unitPriceInfoConfPrice != null)
            {
                this.prcInfo_TabControl.Tabs[LISTPRICE_TAB].Visible = true;
            }
            else
            {
                this.prcInfo_TabControl.Tabs[LISTPRICE_TAB].Visible = false;
            }
            //売単価tabデータ
            if (_unitPriceInfoConfSales != null)
            {
                this.prcInfo_TabControl.Tabs[SALESUNITPRICE_TAB].Visible = true;
            }
            else
            {
                this.prcInfo_TabControl.Tabs[SALESUNITPRICE_TAB].Visible = false;
            }
            //原単価tabデータ
            if (_unitPriceInfoConfUnit != null)
            {
                this.prcInfo_TabControl.Tabs[UNITCOST_TAB].Visible = true;
            }
            else
            {
                this.prcInfo_TabControl.Tabs[UNITCOST_TAB].Visible = false;
            }
        }

        /// <summary>
        /// 画面タイプによって、画面表示設定する
        /// </summary>
        /// <param name="unitPriceInfoConf"></param>
        /// <param name="displayType"></param>
        /// <br>Update Note: 2013/01/24 鄧潘ハン Redmine#34605  売上画面の価格ｶﾞｲﾄﾞ表示に『拠点』や『表示区分』の追加</br>
        private void tabChange(UnPrcInfoConf unitPriceInfoConf, DisplayType displayType)
        {
            this._displayType = displayType;
            this._unitPriceInfoConfAcs.UnitPriceInfoConf = unitPriceInfoConf;
            this._unitPriceInfoConfAcs.UnitPriceKindCode = (int)displayType;
            this._unitPriceInfoConf = unitPriceInfoConf.Clone();

            //売単価tab
            if ((int)displayType == 1)
            {
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
                this.uLabel_PriceSelectDiv.Visible = false;
                this.ultraLabel27.Visible = false;
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<
                // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>> 
                //オプション判定ok
                if (showEnable())
                {
                    this.uLabel_Date.Visible = true; 　　//掛率更新日タイトル表示
                    this.ultraLabelDate.Visible = true;  //掛率更新日表示
                }
                // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<
                this.prcInfo_TabControl.SelectedTab = this.prcInfo_TabControl.Tabs[SALESUNITPRICE_TAB];
                this.ultraTabPageControl2.Controls.Add(this.Form1_Fill_Panel);
            }
            //原単価tab
            else if ((int)displayType == 2)
            {
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
                this.uLabel_PriceSelectDiv.Visible = false;
                this.ultraLabel27.Visible = false;
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<
                // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>> 
                //オプション判定ok
                if (showEnable())
                {
                    this.uLabel_Date.Visible = true; 　　//掛率更新日タイトル表示
                    this.ultraLabelDate.Visible = true;  //掛率更新日表示
                }
                // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<
                this.prcInfo_TabControl.SelectedTab = this.prcInfo_TabControl.Tabs[UNITCOST_TAB];
                this.ultraTabPageControl3.Controls.Add(this.Form1_Fill_Panel);
            }
            //価格tab
            else if ((int)displayType == 3)
            {
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
                this.uLabel_PriceSelectDiv.Visible = true;
                this.ultraLabel27.Visible = true;
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<
                this.prcInfo_TabControl.SelectedTab = this.prcInfo_TabControl.Tabs[LISTPRICE_TAB];
                this.ultraTabPageControl1.Controls.Add(this.Form1_Fill_Panel);
                // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>> 
                this.uLabel_Date.Visible = false;     //掛率更新日タイトル非表示
                this.ultraLabelDate.Visible = false;  //掛率更新日非表示
                // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<
            }
        }

        // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
        /// <summary>
        /// 前橋京和商会個別オプション判定
        /// </summary>
        private bool showEnable()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            //ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaGuideCtl); // DEL K2014/05/14 zhaicy FOR  Redmine#42658 前橋京和商会／単価情報ガイドのオプション制御障害の対応
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl);// ADD K2014/05/14 zhaicy FOR  Redmine#42658 前橋京和商会／単価情報ガイドのオプション制御障害の対応
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

        /// <summary>
        /// 画面タイプ切替処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prcInfo_TabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            switch (e.Tab.Key)
            {
                //売単価の場合、「売単価」タブを初期表示する
                case SALESUNITPRICE_TAB:
                    {
                        if (_unitPriceInfoConfSales != null)
                        {
                            this._displayType = DisplayType.SalesUnitPrice;
                            this.tabChange(_unitPriceInfoConfSales, this._displayType);
                        }
                        this.setEnableTab();
                        this.uGrid_LotInfo.DataSource = this._unitPriceInfoConfAcs.LotInfoTable;
                        this.uGrid_PriceInfo.DataSource = this._unitPriceInfoConfAcs.PriceInfoTable;

                        this.SetItemtUnPrcCalcCd(this._displayType);

                        this._unitPriceInfoConfAcs.InitialSearch();

                        // 基準価格エディット入力設定
                        this.SetStdUnitPrcEnabled();

                        this.Initial_Timer.Enabled = true;

                        break;
                    }
                //原単価の場合、「原単価」タブを初期表示する
                case UNITCOST_TAB:
                    {
                        if (_unitPriceInfoConfUnit != null)
                        {
                            this._displayType = DisplayType.UnitCost;
                            this.tabChange(_unitPriceInfoConfUnit, this._displayType);
                        }
                        this.setEnableTab();
                        this.uGrid_LotInfo.DataSource = this._unitPriceInfoConfAcs.LotInfoTable;
                        this.uGrid_PriceInfo.DataSource = this._unitPriceInfoConfAcs.PriceInfoTable;

                        this.SetItemtUnPrcCalcCd(this._displayType);

                        this._unitPriceInfoConfAcs.InitialSearch();

                        // 基準価格エディット入力設定
                        this.SetStdUnitPrcEnabled();

                        this.Initial_Timer.Enabled = true;

                        break;
                    }
                //定価の場合、「定価」タブを初期表示する
                case LISTPRICE_TAB:
                    {
                        if (_unitPriceInfoConfPrice != null)
                        {
                            this._displayType = DisplayType.ListPrice;
                            this.tabChange(_unitPriceInfoConfPrice, this._displayType);
                        }
                        this.setEnableTab();

                        this.uGrid_LotInfo.DataSource = this._unitPriceInfoConfAcs.LotInfoTable;
                        this.uGrid_PriceInfo.DataSource = this._unitPriceInfoConfAcs.PriceInfoTable;

                        this.SetItemtUnPrcCalcCd(this._displayType);

                        this._unitPriceInfoConfAcs.InitialSearch();

                        // 基準価格エディット入力設定
                        this.SetStdUnitPrcEnabled();

                        this.Initial_Timer.Enabled = true;

                        break;
                    }
                default:
                    {
                        break;
                    }
            }            
        }
        //-----ADD 2010/08/12-----------<<<<<
	
        #endregion

        #region ■Private Methods

        #region 各コントロールイベント処理

        /// <summary>
        /// 画面Loadイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Form1_Load( object sender, EventArgs e )
        {
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);

			this.uGrid_LotInfo.DataSource = this._unitPriceInfoConfAcs.LotInfoTable;
			this.uGrid_PriceInfo.DataSource = this._unitPriceInfoConfAcs.PriceInfoTable;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

			this.SetItemtUnPrcCalcCd(this._displayType);

			this._unitPriceInfoConfAcs.InitialSearch();

			// 基準価格エディット入力設定
			this.SetStdUnitPrcEnabled();

			////// 画面初期情報設定処理
			//this.SetInitialInput();

            this.Initial_Timer.Enabled = true;

            // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>> 
            //オプション判定ok
            if (showEnable())
            {
                this.uLabel_Date.Visible = true; 　　//掛率更新日タイトル表示
                this.ultraLabelDate.Visible = true;  //掛率更新日表示
            }
            else
            {
                this.uLabel_Date.Visible = false; 　　//掛率更新日タイトル表示
                this.ultraLabelDate.Visible = false;  //掛率更新日表示
            }
            // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // 終了処理
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        if (DecisionProc())
                        {
                            this.SetDialogRes(DialogResult.OK);
                            this.CloseForm();
                        }
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
						this._unitPriceInfoConfAcs.UnitPriceInfoConf = this._unitPriceInfoConf.Clone();
                        this.ClearDisplay();
                        this.SetDisplayInfo(this._unitPriceInfoConf);

                        break;
                    }
            }
        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void SetStatusBarMessage( object sender, string message )
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。
        ///	                 この処理は、システムが提供するスレッド プール
        ///	                 スレッドで実行されます。</br>
        /// </remarks>
        private void Initial_Timer_Tick( object sender, EventArgs e )
        {
            this.Initial_Timer.Enabled = false;

            this.SetInitialInput();

			if (this._readOnly)
			{
				this.uGrid_PriceInfo.Focus();
			}
			else
			{
				this.tComboEditor_UnitPrcCalcDiv.Focus();
			}
		}

        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
			if (e.PrevCtrl == null || e.NextCtrl == null) return;
			SetStatusBarMessage(this, "");

			bool resetDisplay = false;

			UnPrcInfoConf unPrcInfoConf = this._unitPriceInfoConfAcs.UnitPriceInfoConf;

            // 名称取得 ============================================ //
			switch (e.PrevCtrl.Name)
			{
				// 単価算出方法
				case "tComboEditor_UnitPrcCalcDiv":
					{
						// コンボエディタ選択値変更確定後イベントを一時的に解除
						this.tComboEditor_UnitPrcCalcDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_UnitPrcCalcDiv_SelectionChangeCommitted);

						this.tComboEditor_UnitPrcCalcDiv_SelectionChangeCommitted(tComboEditor_UnitPrcCalcDiv, new EventArgs());

						// コンボエディタ選択値変更確定後イベントを挿入
						this.tComboEditor_UnitPrcCalcDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_UnitPrcCalcDiv_SelectionChangeCommitted);

						//if (( ( e.NextCtrl == tComboEditor_PriceDiv ) || ( e.NextCtrl == tNedit_StdUnitPrice ) ) && ( e.NextCtrl.Enabled == false ))
						if (( e.NextCtrl == tNedit_StdUnitPrice ) && ( e.NextCtrl.Enabled == false ))
						{
							e.NextCtrl = tNedit_Rate;
						}

						break;
					}
				// 基準価格
				case "tNedit_StdUnitPrice":
					{
						double code = tNedit_StdUnitPrice.GetValue();

						// 基準価格が変わった場合、再計算する
						if (code != unPrcInfoConf.StdUnitPrice)
						{
							this._unitPriceInfoConfAcs.StdUnPrcSetting(code);
							resetDisplay = true;
						}

						break;
					}
				// 率
				case "tNedit_Rate":
					{
						double code = tNedit_Rate.GetValue();

						// 率が変わった場合、再計算する
						if (code != unPrcInfoConf.RateVal)
						{
							this._unitPriceInfoConfAcs.RateSetting(code);
							resetDisplay = true;
						}

						break;
					}
				// 単価
				case "tNedit_UnitPrice":
					{
						double code = tNedit_UnitPrice.GetValue();

						double targetPrice = ( ( unPrcInfoConf.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) || ( unPrcInfoConf.TotalAmountDispWayCd ) == 1 ) ? unPrcInfoConf.UnitPriceTaxIncFl : unPrcInfoConf.UnitPriceTaxExcFl;

						if (code != targetPrice)
						{
							this._unitPriceInfoConfAcs.UnitPriceDirectSetting(code);
							resetDisplay = true;
						}

						break;
					}
				// 端数処理単位
				case "tNedit_UnPrcFracProcUnit":
					{
						double code = tNedit_UnPrcFracProcUnit.GetValue();

						// 端数処理単位が変わった場合、再計算する
						if (code != unPrcInfoConf.UnPrcFracProcUnit)
						{
							unPrcInfoConf.UnPrcFracProcUnit = code;
							this._unitPriceInfoConfAcs.ReCalcUnitPrice();

							resetDisplay = true;
						}

						break;
					}
				// 端数処理方法
				case "tComboEditor_UnPrcFracProcDiv":
					{
						// コンボエディタ選択値変更確定後イベントを一時的に解除
						this.tComboEditor_UnPrcFracProcDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_UnPrcFracProcDiv_SelectionChangeCommitted);

						this.tComboEditor_UnPrcFracProcDiv_SelectionChangeCommitted(tComboEditor_UnPrcFracProcDiv, new EventArgs());

						// コンボエディタ選択値変更確定後イベントを挿入
						this.tComboEditor_UnPrcFracProcDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_UnPrcFracProcDiv_SelectionChangeCommitted);

						break;
					}
			}

			if (resetDisplay)
			{
				this.SetDisplayInfo(unPrcInfoConf);
			}
        }

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void DCKHN01050UA_FormClosed( object sender, FormClosedEventArgs e )
        {
            DialogResult = _dialogRes;
		}

		/// <summary>
		/// 価格情報グリッド初期レイアウト設定イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_PriceInfo_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
		{
			InitialSettingPriceGridCol();
		}

		/// <summary>
		/// ロットグリッド初期レイアウト設定イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_LotInfo_InitializeLayout( object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e )
		{
			InitialSettingLotGridCol();
		}

		/// <summary>
		/// 単価算出方法コンボエディタ選択値変更確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_UnitPrcCalcDiv_SelectionChangeCommitted( object sender, EventArgs e )
		{
			if (this.tComboEditor_UnitPrcCalcDiv.SelectedIndex >= 0)
			{
				int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_UnitPrcCalcDiv, ComboEditorGetDataType.TAG);

				if (code != this._unitPriceInfoConfAcs.UnitPriceInfoConf.UnitPrcCalcDiv)
				{
					this._unitPriceInfoConfAcs.unitPrcCalcDivSetting(code);

					// 基準価格エディット入力設定
					this.SetStdUnitPrcEnabled();

					// 単価再計算
					this._unitPriceInfoConfAcs.CalclationUnitPrice();

					this.SetDisplayInfo(this._unitPriceInfoConfAcs.UnitPriceInfoConf);
				}
			}
		}

		/// <summary>
		/// 端数処理区分コンボエディタ選択値変更確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_UnPrcFracProcDiv_SelectionChangeCommitted( object sender, EventArgs e )
		{
			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_UnPrcFracProcDiv, ComboEditorGetDataType.TAG);

			// 端数処理方法が変わった場合、再計算する
			if (code != this._unitPriceInfoConfAcs.UnitPriceInfoConf.UnPrcFracProcDiv)
			{
				this._unitPriceInfoConfAcs.UnitPriceInfoConf.UnPrcFracProcDiv = code;
				this._unitPriceInfoConfAcs.ReCalcUnitPrice();
				this.SetDisplayInfo(this._unitPriceInfoConfAcs.UnitPriceInfoConf);
			}
		}

        # endregion

        /// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        private void SetInitialInput()
        {
            // ヘッダ情報クリア処理
            this.ClearDisplay();

            // ヘッダ初期表示処理
            this.SetDisplayInfo(this._unitPriceInfoConf);
        }


        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplay()
        {
			// 描画を止める
			foreach (object target in _clearTargetList)
			{
				if (target is TEdit)
				{
					( (TEdit)target ).BeginUpdate();
				}
				else if (target is TNedit)
				{
					( (TNedit)target ).BeginUpdate();
				}
				else if (target is Infragistics.Win.Misc.UltraLabel)
				{
					( (Infragistics.Win.Misc.UltraLabel)target ).BeginUpdate();
				}
				else if (target is TComboEditor)
				{
					( (TComboEditor)target ).BeginUpdate();
				}
			}
			try
			{
				foreach (object target in _clearTargetList)
				{
					if (target is TEdit)
					{
						( (TEdit)target ).Text = "";
					}
					else if (target is TNedit)
					{
						( (TNedit)target ).SetValue(0);
					}
					else if (target is TDateEdit)
					{
						( (TDateEdit)target ).SetDateTime(DateTime.MinValue);
					}
					else if (target is Infragistics.Win.Misc.UltraLabel)
					{
						( (Infragistics.Win.Misc.UltraLabel)target ).Text = "";
					}
					else if (target is TComboEditor)
					{
						( (TComboEditor)target ).SelectedIndex = -1;
					}
				}

				if (this._displayType == DisplayType.ListPrice)
				{
					// 端数処理単位整数設定
					this.tNedit_UnPrcFracProcUnit.ExtEdit.Column = MAXLENGTH_INT;
					this.tNedit_UnPrcFracProcUnit.NullText = NULLTEXT_INT;
					this.tNedit_UnPrcFracProcUnit.NumEdit.DecLen = NUMEDIT_INT;

					// 単価整数設定
					this.tNedit_UnitPrice.ExtEdit.Column = MAXLENGTH_INT;
					this.tNedit_UnitPrice.NullText = NULLTEXT_INT;
					this.tNedit_UnitPrice.NumEdit.DecLen = NUMEDIT_INT;
				}
				else
				{
					// 端数処理単位小数点設定
					this.tNedit_UnPrcFracProcUnit.ExtEdit.Column = MAXLENGTH_DECIMAL;
					this.tNedit_UnPrcFracProcUnit.NullText = NULLTEXT_DECIMAL;
					this.tNedit_UnPrcFracProcUnit.NumEdit.DecLen = NUMEDIT_DECIMAL;

					// 単価小数点設定
					this.tNedit_UnitPrice.ExtEdit.Column = MAXLENGTH_DECIMAL;
					this.tNedit_UnitPrice.NullText = NULLTEXT_DECIMAL;
					this.tNedit_UnitPrice.NumEdit.DecLen = NUMEDIT_DECIMAL;
				}
			}
			finally
			{
				// 描画
				foreach (object target in _clearTargetList)
				{
					if (target is TEdit)
					{
						( (TEdit)target ).EndUpdate();
					}
					else if (target is TNedit)
					{
						( (TNedit)target ).EndUpdate();
					}
					else if (target is Infragistics.Win.Misc.UltraLabel)
					{
						( (Infragistics.Win.Misc.UltraLabel)target ).EndUpdate();
					}
					else if (target is TComboEditor)
					{
						( (TComboEditor)target ).EndUpdate();
					}
				}
			}
        }

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        /// <br>Update Note: 2013/01/24 鄧潘ハン Redmine#34605  売上画面の価格ｶﾞｲﾄﾞ表示に『拠点』や『表示区分』の追加</br>
        private void SetDisplayInfo( UnPrcInfoConf unitPriceInfoConf )
        {
			// 描画を止める
			foreach (object target in _clearTargetList)
			{
				if (target is TEdit)
				{
					( (TEdit)target ).BeginUpdate();
				}
				else if (target is TNedit)
				{
					( (TNedit)target ).BeginUpdate();
				}
				else if (target is Infragistics.Win.Misc.UltraLabel)
				{
					( (Infragistics.Win.Misc.UltraLabel)target ).BeginUpdate();
				}
				else if (target is TComboEditor)
				{
					( (TComboEditor)target ).BeginUpdate();
				}
			}

			try
			{
				this.uLabel_RateDiv.Text = this._unitPriceInfoConf.RateSettingDivide;

                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- >>>>>
                // 拠点コードセッド
                this.uLabel_SectionCd.Text = this._unitPriceInfoConf.SectionCode;
                // 拠点ガイド名称セッド
                this.uLabel_SectionNm.Text = this._unitPriceInfoConf.SectionGuideNm;
                // 表示区分セッド
                switch (this._unitPriceInfoConf.PriceSelectDiv)
                {
                    case -1:
                        {
                            this.uLabel_PriceSelectDiv.Text = string.Empty;
                            break;
                        }
                    case 0:
                        {
                            this.uLabel_PriceSelectDiv.Text = "優良";
                            break;
                        }
                    case 1:
                        {
                            this.uLabel_PriceSelectDiv.Text = "純正";
                            break;
                        }
                    case 2:
                        {
                            this.uLabel_PriceSelectDiv.Text = "高い方（１：Ｎ）";
                            break;
                        }
                    case 3:
                        {
                            this.uLabel_PriceSelectDiv.Text = "高い方（１：１）";
                            break;
                        }
                }
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34605---- <<<<<

				this.uLabel_RateDivName.Text = DCKHN01051A.GetRateDivName(unitPriceInfoConf.RateSettingDivide);
                this.uLabel_CustomerCode.Text = ( RateAcs.IsCustomerSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.CustomerCode.ToString() : "";
				this.uLabel_CustomerSnm.Text = ( RateAcs.IsCustomerSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.CustomerSnm : "";
                this.uLabel_CustRateGrpCode.Text = ( RateAcs.IsCustRateGrpSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.CustRateGrpCode.ToString() : "";
                this.uLabel_SupplierCd.Text = ( RateAcs.IsSupplierSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.SupplierCd.ToString(): "";
                this.uLabel_SupplierSnm.Text = ( RateAcs.IsSupplierSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.SupplierSnm : "";
                this.uLabel_GoodsNo.Text = ( RateAcs.IsGoodsNoSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.GoodsNo : "";
                this.uLabel_GoodsName.Text = ( RateAcs.IsGoodsNoSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.GoodsName : "";
                this.uLabel_GoodsMakerCd.Text = ( RateAcs.IsMakerSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.GoodsMakerCd.ToString() : "";
                this.uLabel_MakerName.Text = ( RateAcs.IsMakerSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.MakerName : "";
                this.uLabel_GoodsRateRank.Text = ( RateAcs.IsGoodsRateRankSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.GoodsRateRank : "";
                this.uLabel_GoodsRateGrpCode.Text = ( RateAcs.IsGoodsRateGrpCodeSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.GoodsRateGrpCode.ToString() : "";
                this.uLabel_GoodsRateGrpName.Text = ( RateAcs.IsGoodsRateGrpCodeSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.GoodsRateGrpCodeNm : "";
                this.uLabel_BLGroupCode.Text = ( RateAcs.IsBLGroupCodeSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.BLGroupCode.ToString() : "";
                this.uLabel_BLGroupName.Text = ( RateAcs.IsBLGroupCodeSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.BLGroupName : "";
                this.uLabel_BLGoodsCode.Text = ( RateAcs.IsBLGoodsSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.BLGoodsCode.ToString() : "";
                this.uLabel_BLGoodsFullName.Text = ( RateAcs.IsBLGoodsSetting(unitPriceInfoConf.RateSettingDivide) ) ? unitPriceInfoConf.BLGoodsFullName : "";
                switch ((CalculateTax.TaxationCode)unitPriceInfoConf.TaxationDivCd)
                {
                    case CalculateTax.TaxationCode.TaxExc:
                        this.tEdit_TaxationCode.Text = "外税";
                        break;
                    case CalculateTax.TaxationCode.TaxInc:
                        this.tEdit_TaxationCode.Text = "内税";
                        break;
                    case CalculateTax.TaxationCode.TaxNone:
                        this.tEdit_TaxationCode.Text = "非課税";
                        break;
                    default:
                        break;
                }

                this.uLabel_StandardCount.Text = string.Format("{0:###0.00}", unitPriceInfoConf.CountFl);

				this.tDateEdit_TargetDay.SetDateTime(unitPriceInfoConf.PriceApplyDate);

				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_UnitPrcCalcDiv, unitPriceInfoConf.UnitPrcCalcDiv, true);

				//if (unitPriceInfoConf.UnitPrcCalcDiv == 1)
				//{
				//    // 基準価格区分
				//    if (this._unitPriceInfoConfAcs.GetPriceFromPriceInfoTable() != this._unitPriceInfoConfAcs.UnitPriceInfoConf.StdUnitPrice)
				//    {
				//        this.tComboEditor_PriceDiv.SelectedIndex = -1;
				//    }
				//}
				//else
				//{
				//    this.tComboEditor_PriceDiv.SelectedIndex = 0;
				//}
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_UnPrcFracProcDiv, unitPriceInfoConf.UnPrcFracProcDiv, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_UnitPriceKind, (int)this._displayType, true);

				this.tNedit_UnPrcFracProcUnit.SetValue(unitPriceInfoConf.UnPrcFracProcUnit);
				this.tNedit_Rate.SetValue(unitPriceInfoConf.RateVal);
				this.tNedit_StdUnitPrice.SetValue(unitPriceInfoConf.StdUnitPrice);
				if (( unitPriceInfoConf.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) || ( unitPriceInfoConf.TotalAmountDispWayCd == 1 ))
				{
					this.tNedit_UnitPrice.SetValue(unitPriceInfoConf.UnitPriceTaxIncFl);
				}
				else
				{
					this.tNedit_UnitPrice.SetValue(unitPriceInfoConf.UnitPriceTaxExcFl);
				}

				this.uLabel_Mode.Text = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_UnitPriceKind, ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_UnitPriceKind, ComboEditorGetDataType.TAG));
				this.uLabel_UnitPriceTitle.Text = ComboEditorItemControl.GetComboEditorText(this.tComboEditor_UnitPriceKind, ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_UnitPriceKind, ComboEditorGetDataType.TAG));

                // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
                if (this.uLabel_Mode.Text == "原単価")
                {
                    this.uLabel_Date.Text = unitPriceInfoConf.RateUpdateTimeUnit; //掛率更新日(原単価)
                }
                else
                {
                    this.uLabel_Date.Text = unitPriceInfoConf.RateUpdateTimeSales; //掛率更新日(売単価)
                }
                // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<
                
				// 読み取り専用プロパティの設定
				this.tComboEditor_UnitPrcCalcDiv.ReadOnly = this._readOnly;
                this.tComboEditor_UnitPrcCalcDiv.Enabled = !this._readOnly;
				this.tNedit_StdUnitPrice.ReadOnly = this._readOnly;
                this.tNedit_StdUnitPrice.Enabled = !this._readOnly;
				this.tNedit_Rate.ReadOnly = this._readOnly;
                this.tNedit_Rate.Enabled = !this._readOnly;
				this.tNedit_UnPrcFracProcUnit.ReadOnly = this._readOnly;
                this.tNedit_UnPrcFracProcUnit.Enabled = !this._readOnly;
				this.tComboEditor_UnPrcFracProcDiv.ReadOnly = this._readOnly;
                this.tComboEditor_UnPrcFracProcDiv.Enabled = !this._readOnly;
				this.tNedit_UnitPrice.ReadOnly = this._readOnly;
                this.tNedit_UnitPrice.Enabled = !this._readOnly;
			}
			finally
			{
				// 描画
				foreach (object target in _clearTargetList)
				{
					if (target is TEdit)
					{
						( (TEdit)target ).EndUpdate();
					}
					else if (target is TNedit)
					{
						( (TNedit)target ).EndUpdate();
					}
					else if (target is Infragistics.Win.Misc.UltraLabel)
					{
						( (Infragistics.Win.Misc.UltraLabel)target ).EndUpdate();
					}
					else if (target is TComboEditor)
					{
						( (TComboEditor)target ).EndUpdate();
					}
				}
			}
        }

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

		}

		/// <summary>
		/// 単価算出方法コンボエディタアイテム設定処理
		/// </summary>
		private void SetItemtUnPrcCalcCd( DisplayType displayType )
		{
			this.tComboEditor_UnitPrcCalcDiv.Items.Clear();

			switch (displayType)
			{
				// 定価
				case DisplayType.ListPrice:
					{
						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 0;
						item0.DataValue = 1;
						item0.DisplayText = "定価UP率";
						this.tComboEditor_UnitPrcCalcDiv.Items.Add(item0);

						break;
					}
				// 原価単価
				case DisplayType.UnitCost:
					{
						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 0;
						item0.DataValue = 1;
						item0.DisplayText = "仕入率";
						this.tComboEditor_UnitPrcCalcDiv.Items.Add(item0);

						break;
					}
				// 売上単価
				case DisplayType.SalesUnitPrice:
					{
						Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
						item0.Tag = 0;
						item0.DataValue = 1;
						item0.DisplayText = "売価率";
						this.tComboEditor_UnitPrcCalcDiv.Items.Add(item0);

						Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
						item1.Tag = 1;
						item1.DataValue = 2;
						item1.DisplayText = "原価UP率";
						this.tComboEditor_UnitPrcCalcDiv.Items.Add(item1);

						Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
						item2.Tag = 2;
						item2.DataValue = 3;
						item2.DisplayText = "粗利確保率";
						this.tComboEditor_UnitPrcCalcDiv.Items.Add(item2);

						break;
					}
				default:
					{
						break;
					}
			}
		}

		/// <summary>
		/// 基準価格エディット入力可否設定処理
		/// </summary>
		private void SetStdUnitPrcEnabled()
		{
			
			switch (this._unitPriceInfoConfAcs.UnitPriceInfoConf.UnitPrcCalcDiv)
			{
				case 1:	// 掛率
				case 2: // 原価UP率
				case 3: // 粗利確保率
					{
						this.tNedit_StdUnitPrice.Enabled = false;
						break;
					}
				default:
					{
						this.tNedit_StdUnitPrice.Enabled = true;
						break;
					}
			}
			
		}

        /// <summary>
        /// Valueチェック処理（int）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer	: 21024　佐々木 健</br>
        /// <br>Date		: 2007.09.28</br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                dest = Convert.ToInt32(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }
       
        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
		private void SetDialogRes( DialogResult dialogRes )
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
		/// <param name="enableSet">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            this._decisionButton.SharedProps.Enabled = enableSet;
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        private bool DecisionProc()
        {
            Control control = null;
            string message = null;

            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    message,
                    0,
                    MessageBoxButtons.OK);

                control.Focus();
                return false;
            }

			this._unitPriceInfoConfAcs.UnPrcInfoConfRetSetting();

            return true;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        private bool ScreenDataCheck( ref Control control, ref string message )
        {
            bool result = true;

			//if (tNedit_CustomerCode.GetInt() == 0)
			//{
			//    control = this.tNedit_CustomerCode;
			//    message = this.uLabel_CustomerCodeTitle.Text + "を入力して下さい。";
			//    result = false;
			//}
			//// 計上日入力有りの場合
			//else if ((tDateEdit_AddUpADate.Enabled) && (tDateEdit_AddUpADate.GetDateTime() == DateTime.MinValue))
			//{
			//    control = this.tDateEdit_AddUpADate;
			//    message = this.uLabel_AddUpADateTitle.Text + "を入力して下さい。";
			//    result = false;
			//}
            return result;
        }

		/// <summary>
		/// 価格情報グリッド列初期設定処理
		/// </summary>
		private void InitialSettingPriceGridCol()
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_PriceInfo.DisplayLayout.Bands[0];
			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_PriceInfo.DisplayLayout.Bands[0].Columns;
			if (editBand == null) return;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;

			}

			string decimalFormat = "#,##0.00;-#,##0.00;''";

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
			int visiblePosition = 0;

			// 価格開始日
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.PriceStartDateColumn.ColumnName].Hidden = false;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.PriceStartDateColumn.ColumnName].Width = 90;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.PriceStartDateColumn.ColumnName].Format= "yyyy/MM/dd";
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.PriceStartDateColumn.ColumnName].Header.Caption = "価格開始日";
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.PriceStartDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._unitPriceInfoConfAcs.PriceInfoTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

			// 標準価格
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.ListPriceColumn.ColumnName].Hidden = false;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.ListPriceColumn.ColumnName].Width = 90;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.ListPriceColumn.ColumnName].Header.Caption = "標準価格";
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.ListPriceColumn.ColumnName].Format = decimalFormat;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._unitPriceInfoConfAcs.PriceInfoTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

			// 原価単価
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].Hidden = false;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].Width = 90;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //-----UPD 2010/08/12---------->>>>>
            //Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].Header.Caption = "原価単価";
    		Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].Header.Caption = "原単価";
            //-----UPD 2010/08/12----------<<<<<
            Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].Format = decimalFormat;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._unitPriceInfoConfAcs.PriceInfoTable.SalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

			// 仕入率
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.StockRateColumn.ColumnName].Hidden = false;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.StockRateColumn.ColumnName].Width = 60;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.StockRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.StockRateColumn.ColumnName].Header.Caption = "仕入率";
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.StockRateColumn.ColumnName].Format = decimalFormat;
			Columns[this._unitPriceInfoConfAcs.PriceInfoTable.StockRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._unitPriceInfoConfAcs.PriceInfoTable.StockRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

		/// <summary>
		/// ロット情報グリッド列初期設定処理
		/// </summary>
		private void InitialSettingLotGridCol()
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_LotInfo.DisplayLayout.Bands[0];
			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_LotInfo.DisplayLayout.Bands[0].Columns;
			if (editBand == null) return;

			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;

			}

			string decimalFormat = "#,##0.00;-#,##0.00;''";

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
			int visiblePosition = 0;

			// 数量範囲
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.CountRangeColumn.ColumnName].Hidden = false;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.CountRangeColumn.ColumnName].Width = 100;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.CountRangeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.CountRangeColumn.ColumnName].Header.Caption = "数量範囲";
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.CountRangeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			switch (this._displayType)
			{
				// 売上単価
				case DisplayType.SalesUnitPrice:
					// 掛率
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Header.Caption = "売価率";
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Format = decimalFormat;

					// 単価
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Header.Caption = "売上単価";
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Format = decimalFormat;

					// 原価UP率
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Header.Caption = "原価UP率";
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Format = decimalFormat;

					// 粗利確保率
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.GrsProfitSecureRateColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.GrsProfitSecureRateColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.GrsProfitSecureRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.GrsProfitSecureRateColumn.ColumnName].Header.Caption = "粗利確保率";
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.GrsProfitSecureRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.GrsProfitSecureRateColumn.ColumnName].Format = decimalFormat;

					break;
				// 原価単価
				case DisplayType.UnitCost:
					// 掛率
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Header.Caption = "仕入率";
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.RateValColumn.ColumnName].Format = decimalFormat;

					// 単価
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    //-----UPD 2010/08/12---------->>>>>
                    //Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Header.Caption = "原価単価";
                    Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Header.Caption = "原単価";
                    //-----UPD 2010/08/12----------<<<<<
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Format = decimalFormat;

					break;
				// 定価
				case DisplayType.ListPrice:
					// 定価UP率
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Header.Caption = "定価UP率";
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.UpRateColumn.ColumnName].Format = decimalFormat;

					// ユーザー定価
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Hidden = false;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Width = 90;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Header.Caption = "ユーザー定価";
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
					Columns[this._unitPriceInfoConfAcs.LotInfoTable.PriceFlColumn.ColumnName].Format = decimalFormat;

					break;
			}

			// 端数処理単位
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcUnitColumn.ColumnName].Hidden = false;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcUnitColumn.ColumnName].Width = 100;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcUnitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcUnitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcUnitColumn.ColumnName].Format = decimalFormat;

			// 端数処理区分
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcDivNameColumn.ColumnName].Hidden = false;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcDivNameColumn.ColumnName].Width = 100;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			Columns[this._unitPriceInfoConfAcs.LotInfoTable.UnPrcFracProcDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
		}

		#endregion

        //-----ADD 2010/08/12---------->>>>>
        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCKHN01050UA_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Escape)
            {
                this.SetDialogRes(DialogResult.Cancel);
                // 終了処理
                this.CloseForm();
                return;
            }
        }

        //-----ADD 2010/08/12----------<<<<<
		# region ■Static Methods
	
		#endregion

	}
}