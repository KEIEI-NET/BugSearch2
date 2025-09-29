//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せCTI表示 フォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/06  修正内容 : IAAE版から製品版へ変更(不要ロジック削除)
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 20056 對馬 大輔
// 修 正 日 2010/04/30   修正内容 : 売伝インスタンス生成時のパラメータ変更
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 20056 對馬 大輔
// 作 成 日  2010/06/17  修正内容 : Delphi売伝を起動するように変更
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    using GridSettingsType = SlipGridSettings;

    /// <summary>
    /// 簡単問合せCTI表示 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成(IAAEから変更)</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM00101UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member
        private SimpleInqCTIAcs _salesSlipSearchAcs;
        private SalesSlipSearch _para;
        private SimpleInqCTIDataSet _dataSet;                       // データセット
        private TotalDayCalculator _totalDayCalculator;             // 締日算出モジュール
        private ColDisplayStatusList _colDisplayStatusList = null;	// 列表示状態コレクションクラス
        //private MAHNB01010UA _cmtSalesSlipInputForm;                // 売上伝票入力フォーム // 2010/06/17
        
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private string _allSectionCode = string.Empty;

        private Thread _constructorThread;
        private Thread _loadThread;
        
        // ロード処理済みフラグ
        private bool _loaded;

        private bool _showEstimateInput = true;
        private int _currentCustomerCode;
        private CustomerInfo _currentCustomerInfo;

        private AlItmDspNm _alItmDspNm;
        private SalesTtlSt _salesTtlSt;
        private CompanyInf _companyInf;

        /// <summary>グリッドの設定情報</summary>
        private GridSettingsType _gridSettings;

        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region ■ Private Const

        private const string ctFILENAME_COLDISPLAYSTATUS = "PMSCM00100U_ColSetting.DAT";	// 列表示状態セッティングXMLファイル名
        private const string XML_FILE_NAME = "PMSCM00100U_Construction.XML";                // グリッド情報XMLファイル名
        private const int ct_DefaultAcptAnOdrStatus = 30;	                                // 受注ステータス初期値
        private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01001U.exe"; // 2010/06/17

        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■ Constructor
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        public PMSCM00101UA(int customerCode)
        {
            this._currentCustomerCode = customerCode;
            this._constructorThread = new Thread(this.ConstructorSearch);

            this._constructorThread.Start();

            InitializeComponent();

            this._loadThread = new Thread(this.LoadSearch);
            this._loadThread.Start();

            
            // 変数初期化
            this._salesSlipSearchAcs = new SimpleInqCTIAcs();
            this._para = new SalesSlipSearch();
            this._dataSet = this._salesSlipSearchAcs.DataSet;

            UiSet uiset;
            uiSetControl1.ReadUISet(out uiset, "tEdit_SectionCodeAllowZero");
            _allSectionCode = new string('0', uiset.Column);

            // コンストラクタ用検索スレッドの終了待ち
            while (this._constructorThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMSCM00101UA():this(0)
        {
        }
        # endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ■ Delegate

        /// <summary>
        /// Visible設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        public delegate void SettingVisibleEventHandler(bool visible);

        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■ Event

        /// <summary>Visible設定イベント</summary>
        public event SettingVisibleEventHandler SettingVisible;

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■ Property
        /// <summary>
        /// 開始できるかチェック
        /// </summary>
        public bool CanStart
        {
            get { return ( this._currentCustomerInfo != null ); }
        }

        /// <summary>グリッドの設定情報を取得します。</summary>
        public GridSettingsType GridSettings
        {
            get
            {
                if (_gridSettings == null)
                {
                    _gridSettings = SlipGridUtil.ReadGridSettings(XML_FILE_NAME);
                }
                return _gridSettings;
            }
        }

        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■ Public Method

        # endregion // Public Method

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■ Private Method

        /// <summary>
        /// コンストラクタ用検索処理
        /// </summary>
        private void ConstructorSearch()
        {
            if (this._currentCustomerCode != 0)
            {
                CustomerInfoAcs acs = new CustomerInfoAcs();
                acs.ReadDBData(ConstantManagement.LogicalMode.GetData0, LoginInfoAcquisition.EnterpriseCode, this._currentCustomerCode, false, false, out this._currentCustomerInfo);
            }
        }

        /// <summary>
        /// 画面ロード用検索処理
        /// </summary>
        private void LoadSearch()
        {
            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
            int status = alItmDspNmAcs.Read(out this._alItmDspNm, this._enterpriseCode);

            // 売上全体設定マスタの検索
            this.SearchSalesTtlSt(LoginInfoAcquisition.Employee.BelongSectionCode);
            if (this._salesTtlSt == null) this._salesTtlSt = new SalesTtlSt();

            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out this._companyInf,LoginInfoAcquisition.EnterpriseCode);
            if (this._companyInf == null ) this._companyInf = new CompanyInf();
        }

        /// <summary>
        /// 抽出条件の各種コントロールに値を設定します。
        /// </summary>
        /// <param name="para">売上データ検索条件パラメータオブジェクト</param>
        private void SetDisplayConditionInfoforScm(CustomerInfo custRet)
        {
            this.ulabel_CustomerCode.Text = string.Format("{0:00000000}", custRet.CustomerCode);    // 得意先コード
            this.ulabel_CustomerSnm.Text = custRet.Name + custRet.Name2;                            // 得意先名称
            this.ulabel_PostNo.Text = custRet.PostNo;                                               // 郵便番号
            this.ulabel_Address1.Text = custRet.Address1;                                           // 住所１
            this.ulabel_Address3.Text = custRet.Address3;                                           // 住所３
            this.ulabel_Address4.Text = custRet.Address4;                                           // 住所４
            this.ulabel_HomeTelNo.Text = custRet.HomeTelNo;                                         // 電話番号１
            this.ulabel_OfficeTelNo.Text = custRet.OfficeTelNo;                                     // 電話番号２
            this.ulabel_OfficeFaxNo.Text = custRet.OfficeFaxNo;                                     // FAX
            this.ulabel_Note1.Text = custRet.Note1;                                                 // 備考１
            this.ulabel_Note2.Text = custRet.Note2;                                                 // 備考２
            this.ulabel_Note3.Text = custRet.Note3;                                                 // 備考３
            this.ulabel_Note4.Text = custRet.Note4;                                                 // 備考４
            this.ulabel_TotalDay.Text = custRet.TotalDay.ToString() + "日";                         // 締日
            this.ulabel_CollectMoneyDay.Text = custRet.CollectMoneyDay.ToString() + "日";           // 集金日

            this.ulabel_MoneyKindName.Text = string.Empty;                                          // 回収条件
            Dictionary<int, MoneyKind> _moneyKindDic;
            this._salesSlipSearchAcs.ReadMoneyKind(custRet.EnterpriseCode, out _moneyKindDic);
            if (_moneyKindDic.ContainsKey(custRet.CollectCond)) this.ulabel_MoneyKindName.Text = _moneyKindDic[custRet.CollectCond].MoneyKindName;
            
            Employee data = null;
            this.ulabel_CollectMoneyEmployee.Text = string.Empty;                                   // 集金担当者
            this._salesSlipSearchAcs.GetEmployee(this._enterpriseCode, custRet.BillCollecterCd, out data);
            if (data != null) this.ulabel_CollectMoneyEmployee.Text = data.Name;

            this.ulabel_CustomerAgent.Text = custRet.CustomerAgent;
        }
        

        /// <summary>
        /// 売上データの検索を行います。
        /// </summary>
        /// <returns>STATUS</returns>
        private int Search(SalesSlipSearch para)
        {
            int status = this._salesSlipSearchAcs.Search(para, (int)SimpleInqCTIAcs.ExtractSlipCdType.All, this._showEstimateInput);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //セル毎の設定
                this.uGrid_Result_InitializeLayout(this, null);
                // 売上データグリッドの行、セル毎の設定を行います。
                this.SettingGridRow();

                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveRow.Selected = true;
                }

                string sSort;
                sSort = "RowNo Asc";
                DataView dv = (DataView)this.uGrid_Result.DataSource;
                dv.Sort = sSort;
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "売上データの取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// 画面を初期化します。
        /// </summary>
        private void Clear()
        {
            // 得意先情報の表示
            if (_currentCustomerInfo != null)
            {
                this.SetDisplayConditionInfoforScm(_currentCustomerInfo);
            }

            this._salesSlipSearchAcs.Clear();
        }

        /// <summary>
        /// 前回月次締処理日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay(string sectionCode)
        {
            DateTime prevTotalDay;

            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccRec( sectionCode.Trim(), out prevTotalDay );

            // 取得日が不正な場合は３ヶ月前をセット
            if ( status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today )
            {
                prevTotalDay = DateTime.Today.AddMonths( -3 );
            }
            // 翌日取得
            prevTotalDay = prevTotalDay.AddDays( 1 );

            return prevTotalDay;
        }

        /// <summary>
        /// 売上データグリッドの行、セル毎の設定を行います。
        /// </summary>
        private void SettingGridRow()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Result.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int cnt = this.uGrid_Result.Rows.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // 描画を開始
                this.uGrid_Result.EndUpdate();
            }
        }

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 赤伝区分を取得
            int debitNoteDiv = Convert.ToInt32(this._salesSlipSearchAcs.DataView[rowIndex][this._dataSet.SalesSlip.DebitNoteDivColumn.ColumnName]);

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                switch (debitNoteDiv)
                {
                    case 0:			// 黒伝
                        cell.Appearance.ForeColor = Color.Black;
                        break;
                    case 1:			// 赤伝
                        cell.Appearance.ForeColor = Color.Red;
                        break;
                    case 2:			// 元黒
                        cell.Appearance.ForeColor = Color.Gray;
                        break;
                }
            }
        }

        /// <summary>
        /// 選択済みデータを取得します。
        /// </summary>
        /// <returns>選択済みデータ</returns>
        private SalesSlipSearchResult GetSelectedData()
        {
            // 選択行のインデックスを取得
            CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Result.DataSource];
            int index = cm.Position;

            DataView dataView = (DataView)this.uGrid_Result.DataSource;

            if (index >= 0)
            {
                SalesSlipSearchResult data = SimpleInqCTIAcs.CreateUIDataFromParamData(
                    (SalesSlipSearchResultWork)dataView[index][this._dataSet.SalesSlip.SalesSlipSearchResultWorkColumn.ColumnName]);

                return data;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// ユーザー設定値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void SalesSearchConstructionAcs_DataChanged(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// 列表示状態クラスリストを構築します。
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // グリッドから列表示状態クラスリストを構築
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        #region 売上全体設定マスタ検索
        /// <summary>
        /// 売上全体設定マスタの検索
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        private void SearchSalesTtlSt(string sectionCode)
        {
            #region <Guard Phrase/>

            if (string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return;
            }

            #endregion  // <Guard Phrase/>

            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();
            ArrayList al;
            int status = salesTtlStAcs.Search(out al, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])al.ToArray(typeof(SalesTtlSt)));
                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if (( salesttl.SectionCode.Trim() == sectionCode.Trim() ) &&
                            ( salesttl.EnterpriseCode.Trim() == this._enterpriseCode.Trim() ))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if (( salesttl.SectionCode.Trim() == this._allSectionCode.Trim() ) &&
                            ( salesttl.EnterpriseCode.Trim() == this._enterpriseCode.Trim() ))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }
        #endregion

        /// <summary>
        /// ロード処理
        /// </summary>
        private void Loading()
        {
            if (_loaded) return;

            while (this._loadThread.ThreadState == System.Threading.ThreadState.Running)
            {
                System.Threading.Thread.Sleep(100);
            }

            this._salesSlipSearchAcs.DataView.Sort = "EnterpriseCode, SearchSlipNum DESC";
            this.uGrid_Result.DataSource = this._salesSlipSearchAcs.DataView;   // グリッドにバインド

            // グリッド設定
            this.uGrid_Result_InitializeLayout(this, null);

            _loaded = true;

        }

        /// <summary>
        /// ＵＩ設定ＸＭＬからのコードフォーマット取得(00,000,0000… etc.)
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetCodeFormat(string editName)
        {
            UiSet uiset;
            int status = uiSetControl1.ReadUISet(out uiset, editName);
            if (status == 0)
            {
                return string.Format("{0};-{0};''", new string('0', uiset.Column));
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 得意先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetCustomerCodeFormat()
        {
            return GetCodeFormat("tNedit_CustomerCode");
        }
        /// <summary>
        /// ＢＬコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetBLGoodsCodeFormat()
        {
            return GetCodeFormat("tNedit_BLGoodsCode");
        }


        /// <summary>
        /// 起動時自動実行用初期検索処理
        /// </summary>
        private void SearchDataForInitialSearch()
        {
            Clear();

            // パラメータ生成
            CreateSearchParameterForInitialSearch(ref _para);

            // 検索実行
            Search(_para);
        }

        /// <summary>
        /// パラメータ生成
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private void CreateSearchParameterForInitialSearch(ref SalesSlipSearch para)
        {
            if (para == null)
            {
                para = new SalesSlipSearch();
            }
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            para.CustomerCode = this._currentCustomerCode;
            para.AcptAnOdrStatus = ct_DefaultAcptAnOdrStatus; // 30:売上

            UiSet uiset;
            uiSetControl1.ReadUISet(out uiset, "tEdit_SectionCodeAllowZero");
            para.SectionCode = new string('0', uiset.Column);
            para.SalesDateSt = GetPrevTotalDayNextDay(LoginInfoAcquisition.Employee.BelongSectionCode);
            para.SalesDateEd = DateTime.Today;
        }

        #region グリッドの設定情報

        /// <summary>
        /// 明細情報グリッドにグリッド設定情報を展開します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void LoadDetailGridSettings(
            object sender,
            EventArgs e
        )
        {
            PMSCM00101UB detailForm = sender as PMSCM00101UB;
            if (detailForm == null) return;

            // 列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(detailForm.DetailGrid);
            // グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(detailForm.DetailGrid, GridSettings.DetailColumnsList);
        }

        /// <summary>
        /// 明細情報グリッドのグリッド設定情報を設定します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SetDetailGridSettings(
            object sender,
            FormClosingEventArgs e
        )
        {
            PMSCM00101UB detailForm = sender as PMSCM00101UB;
            if (detailForm == null) return;

            // 明細情報画面のグリッド列情報を生成
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(detailForm.DetailGrid);
        }

        #endregion // グリッドの設定情報

        #region 売上伝票入力フォーム

        #region 操作制御

        /// <summary>売上伝票入力フォームの表示可能イメージを取得します。</summary>
        private static Image EnabledShowSalesSlipInputFormImage
        {
            get { return Properties.Resources.uriden; }
        }

        /// <summary>売上伝票入力フォームの表示不可イメージを取得します。</summary>
        private static Image DisabledShowSalesSlipInputFormImage
        {
            get { return Properties.Resources.uriden_end; }
        }

        /// <summary>
        /// 売上伝票入力フォームの表示が可能であるか設定します。
        /// </summary>
        /// <param name="enabled">表示可能フラグ</param>
        private void SetEnabledShowSalesSlipInputForm(bool enabled)
        {
            this.btnShowSalesSlipInputForm.Enabled = enabled;
            if (enabled)
            {
                this.btnShowSalesSlipInputForm.Image = EnabledShowSalesSlipInputFormImage;
            }
            else
            {
                this.btnShowSalesSlipInputForm.Image = DisabledShowSalesSlipInputFormImage;
            }
        }

        #endregion // 操作制御

        #region コマンドライン引数

        /// <summary>コマンドライン引数</summary>
        private string[] _commandLineArgs;
        /// <summary>コマンドライン引数を取得または設定します。</summary>
        public string[] CommandLineArgs
        {
            get { return _commandLineArgs; }
            set { _commandLineArgs = value; }
        }

        /// <summary>
        /// コマンドライン引数からのパラメータを取得します。
        /// </summary>
        /// <returns>
        /// コマンドライン引数(配列)をスペースで連結した文字列
        /// </returns>
        private string GetCommandLineParameter()
        {
            if (CommandLineArgs == null) return string.Empty;

            StringBuilder commandLineParameter = new StringBuilder();
            {
                foreach (string commandLineToken in CommandLineArgs)
                {
                    // 2010/04/30 Add >>>
                    // 得意先情報は入れない
                    if (commandLineToken.Contains("/Customer")) continue;
                    // 2010/04/30 Add <<<

                    commandLineParameter.Append(commandLineToken).Append(" ");
                }
            }

            return commandLineParameter.ToString().Trim();
        }

        #endregion // コマンドライン引数

        #region ボツ

        ///// <summary>売上伝票入力フォーム</summary>
        //private CMTSalesSlipInputForm _cmtSalesSlipInputForm;
        ///// <summary>売上伝票入力フォームを取得または設定します。</summary>
        //private CMTSalesSlipInputForm CMTSalesSlipInputForm
        //{
        //    get
        //    {
        //        if (_cmtSalesSlipInputForm == null)
        //        {
        //            _cmtSalesSlipInputForm = new CMTSalesSlipInputForm(
        //                GetCommandLineParameter(),
        //                CurrentCustomerCode
        //            );
        //            _cmtSalesSlipInputForm.FormClosing += new FormClosingEventHandler(this.HideMe);
        //        }
        //        return _cmtSalesSlipInputForm;
        //    }
        //    set { _cmtSalesSlipInputForm = value; }
        //}

        #endregion // ボツ

        //>>>2010/06/17
        ///// <summary>売上伝票入力フォームを取得または設定します。</summary>
        //private MAHNB01010UA CMTSalesSlipInputForm
        //{
        //    get
        //    {
        //        if (_cmtSalesSlipInputForm == null)
        //        {
        //            _cmtSalesSlipInputForm = new MAHNB01010UA(
        //                GetCommandLineParameter(),
        //                0,
        //                0,
        //                "000000000",
        //                string.Empty,
        //                string.Empty,
        //                0,
        //                this._currentCustomerCode
        //                ,0 // 2010/04/30
        //            );
        //            _cmtSalesSlipInputForm.FormClosing += new FormClosingEventHandler(this.HideMe);
        //        }
        //        return _cmtSalesSlipInputForm;
        //    }
        //    set { _cmtSalesSlipInputForm = value; }
        //}
        //<<<2010/06/17

        /// <summary>
        /// 売上伝票入力フォームを表示します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :売上伝票入力フォームに得意先情報を展開済<br/>
        /// <c>false</c>:売上伝票入力フォームに得意先情報を未展開
        /// </returns>
        private bool ShowSalesSlipInputFormIf()
        {
            //>>>2010/06/17
            //bool isConfirm = true;
            //try
            //{
            //    if (!CMTSalesSlipInputForm.CustomerCode.Equals(this._currentCustomerCode))
            //    {
            //        CMTSalesSlipInputForm.CustomerCode = this._currentCustomerCode;
            //        isConfirm = CMTSalesSlipInputForm.LinkCommunicationTool();
            //    }
            //    CMTSalesSlipInputForm.Show();
            //    if (CMTSalesSlipInputForm.WindowState.Equals(FormWindowState.Minimized))
            //    {
            //        CMTSalesSlipInputForm.WindowState = FormWindowState.Normal;
            //    }
            //    CMTSalesSlipInputForm.Activate();
            //}
            //catch (ObjectDisposedException ex)
            //{
            //    Debug.WriteLine(ex);

            //    // 既に終了操作しているので、インスタンスをリセットして再表示
            //    CMTSalesSlipInputForm = null;
            //    isConfirm = ShowSalesSlipInputFormIf();
            //}
            //return isConfirm;

            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return false;

            // ログインパラメータ情報を設定
            StringBuilder param = new StringBuilder();
            {
                foreach (string argument in CommandLineArgs)
                {
                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        if (argument.Trim().Contains("/Customer")) break;
                        param.Append(argument + " ");
                    }
                }
            }

            param.Append("/CTI ");
            param.Append(this._currentCustomerCode.ToString()); // 得意先コード
            Process.Start(programPath, param.ToString());

            return true;
            //<<<2010/06/17

        }

        /// <summary>
        /// 自身を隠します。
        /// </summary>
        /// <remarks>
        /// 売上伝票入力フォームの終了操作と連動するために使用しています。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void HideMe(object sender, FormClosingEventArgs e)
        {
            btn_Close_Click(sender, e);
        }

        /// <summary>
        /// 可視化の場合、最小化の状態を通常の状態に設定します。
        /// </summary>
        /// <param name="visible">可視化フラグ</param>
        private void SetWindowStateNormalIf(bool visible)
        {
            if (visible)
            {
                if (this.ParentForm != null)
                {
                    if (this.ParentForm.WindowState.Equals(FormWindowState.Minimized))
                    {
                        this.ParentForm.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    if (this.WindowState.Equals(FormWindowState.Minimized))
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                }
            }
        }

        #endregion // 売上伝票入力フォーム

        /// <summary>
        /// 明細設定保存
        /// </summary>
        public void SaveDetailSetting()
        {
            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

            // 列表示状態クラスリストをXMLにシリアライズする
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);

            // MEMO:グリッド列の表示設定を保存
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this.uGrid_Result);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
        }

        /// <summary>
        /// Visible設定イベントコール処理
        /// </summary>
        private void SettingVisibleEventCall(bool visible)
        {
            // 売上伝票入力フォームを表示可能とする
            SetEnabledShowSalesSlipInputForm(true); // 売上伝票入力フォームを表示した際に無効になる
            // 最小化されている場合、通常の状態へ
            SetWindowStateNormalIf(visible);

            if (this.SettingVisible != null)
            {
                this.SettingVisible(visible);
            }
        }

        # endregion // Private Method

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        # region 各種コントロールイベント処理
        /// <summary>
        /// 画面 ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMSCM00101UA_Load(object sender, EventArgs e)
        {
            Loading();

            // 得意先情報の表示
            if (_currentCustomerInfo != null)
            {
                this.SetDisplayConditionInfoforScm(_currentCustomerInfo);
            }

            // 全体項目名称の設定
            if (_alItmDspNm != null)
            {
                this.ulabel_OfficeTelNoTitle.Text = _alItmDspNm.OfficeTelNoDspName;
                this.ulabel_HomeTelNoTitle.Text = _alItmDspNm.HomeTelNoDspName;
                this.ulabel_OfficeFaxNoTitle.Text = _alItmDspNm.OfficeFaxNoDspName;
            }

            this.SettingVisibleEventCall(true);
        }

        /// <summary>
        /// フォーム表示イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00101UA_Shown(object sender, EventArgs e)
        {
            this.timer_Search.Enabled = true;
        }

        #region グリッド関連
        /// <summary>
        /// 検索結果グリッドレイアウト初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            string codeFormat = "#0;-#0;''";
            string moneyFormat = "#,##0;-#,##0;''";
            string dateFormat = "yyyy/MM/dd";

            int visiblePosition = 1;
            string acptAnOdrStatusTiTle = "";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Result.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            }

            switch (_para.AcptAnOdrStatus)
            {
                case 10:
                case 15:
                case 16:
                    acptAnOdrStatusTiTle = "見積";
                    break;
                case 20: acptAnOdrStatusTiTle = "受注"; break;
                case 30: acptAnOdrStatusTiTle = "売上"; break;
                case 40: acptAnOdrStatusTiTle = "貸出"; break;
                default: acptAnOdrStatusTiTle = "売上"; break;
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            #region 
            // №
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Fixed = true;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Caption = "No";
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Width = 60;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 2008.11.07 add end [7071]

            // 売上日
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "日";
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 伝票番号
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Format = codeFormat;

            // 伝票種別
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.Caption = "伝票種別";
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //伝票区分
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.Caption = "伝票区分";
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //得意先コード
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Hidden = true;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Format = GetCustomerCodeFormat();

            //得意先名
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Hidden = true;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.Caption = "得意先名";
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 担当者名
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Caption = "担当者";
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発行者
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = true;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.Caption = "発行者";
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 受注者名
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注者";
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //売上金額（税抜）
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "金額";
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;

            //消費税
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.Caption = "消費税";
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Format = moneyFormat;

            //管理番号
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.Caption = "管理番号";
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //類別型式
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "類別型式";
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //車種
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 型式
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.Caption = "型式";
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //赤黒
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.Caption = "赤黒";
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            //入力日
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.Caption = "入力日";
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Format = dateFormat;

            //計上日
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.Caption = "計上日";
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //伝票備考
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.Caption = "伝票備考";
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //リマーク1
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.Caption = "リマーク１";
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            //拠点名
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.Caption = "拠点";
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;


            //部門名
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.Caption = "部門名";
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.Caption = "請求先コード";
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Format = GetCustomerCodeFormat();

            //請求先名
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.Caption = "請求先名";
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            #endregion
        }

        /// <summary>
        /// グリッドセルアクティブ後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
            else
            {
                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveCell = this.uGrid_Result.ActiveRow.Cells[0];
                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                    this.uGrid_Result.ActiveRow.Selected = true;
                }
            }
        }

        /// <summary>
        /// グリッドダブルクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement != null)
            {
                objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                    ( typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement) ));

                // ヘッダ部の場合は以下の処理をキャンセルする
                if (objRowCellAreaUIElement == null)
                {
                    return;
                }
            }

            if (this.uGrid_Result.ActiveRow != null)
            {
                this.uButton_ShowDetail_Click(null, new EventArgs());
            }
        }

        #endregion // グリッド  

        /// <summary>
        /// フォーム終了前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMSCM00101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_disposed) return;

            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

            // 列表示状態クラスリストをXMLにシリアライズする
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);

            // グリッド列の表示設定を保存
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this.uGrid_Result);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
        }

      

        /// <summary>
        /// 検索タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_Search_Tick(object sender, EventArgs e)
        {
            timer_Search.Enabled = false;

            SearchDataForInitialSearch();

            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ctFILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._dataSet.SalesSlip);

            // 伝票および明細グリッド列の列設定の変更
            // 列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this.uGrid_Result);
            // グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(this.uGrid_Result, GridSettings.SlipColumnsList);

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = ( this._salesTtlSt.InpAgentDispDiv == 1 );
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = ( this._salesTtlSt.AcpOdrAgentDispDiv == 1 );
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = !( this._companyInf.SecMngDiv == 1 );
        }

        /// <summary>
        /// 明細ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ShowDetail_Click(object sender, EventArgs e)  // MEMO:明細ボタンクリック
        {
            if (this.uGrid_Result.ActiveRow == null)
            {
                return;
            }

            // 現在選択行の売上伝票情報取得
            SalesSlipSearchResult salesSlipSearchResult = this.GetSelectedData();

            // 明細参照画面を起動
            PMSCM00101UB searchDetail = new PMSCM00101UB(_salesSlipSearchAcs, salesSlipSearchResult);

            // 明細表示画面のグリッド列情報をロード時に設定
            searchDetail.Load += new EventHandler(this.LoadDetailGridSettings);
            // 明細表示画面のグリッド列情報をクローズ時に取得
            searchDetail.FormClosing += new FormClosingEventHandler(this.SetDetailGridSettings);

            DialogResult dialogResult = searchDetail.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
            }
        }

        /// <summary>
        /// 売上伝票入力ボタン クリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnShowSalesSlipInputForm_Click(object sender, EventArgs e)
        {
            if (this._currentCustomerCode == 0) return;    // 得意先コードの設定が無ければ何もしない

            Cursor cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 売伝フォームを表示
                bool isConfirm = ShowSalesSlipInputFormIf();
            }
            finally
            {
                this.Cursor = cursor;
            }

            // ボタン設定を操作不可の状態に変更
            SetEnabledShowSalesSlipInputForm(false);
        }

        /// <summary>
        /// 終了ボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.SaveDetailSetting();
            this.Close();
        }

        # endregion // 各種コントロールイベント処理
    }

    #region 伝票グリッド

    /// <summary>
    /// 伝票グリッドユーティリティ
    /// </summary>
    /// <remarks>
    /// 以下の機能で参照しています。<br/>
    /// ・売上履歴照会<br/>
    /// ・仕入伝票照会<br/>
    /// ・仕入履歴照会
    /// </remarks>
    public static class SlipGridUtil
    {
        #region 列を設定

        /// <summary>
        /// 列交換と列固定を可能とします。
        /// </summary>
        /// <param name="grid">対象グリッド</param>
        public static void EnableAllowColSwappingAndFixedHeaderIndicator(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return;

            #endregion // Guard Phrase

            // 列交換を可能にする
            grid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.WithinGroup;
            // 列固定を可能にする
            grid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.Button;
        }

        #endregion // 列を設定

        #region 設定の展開

        /// <summary>
        /// グリッドの表示設定を読み込みます。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04004UA.Deserialize()
        /// </remarks>
        /// <param name="xmlFileName">設定XMLファイル名</param>
        public static GridSettingsType ReadGridSettings(string xmlFileName)
        {
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);
            if (!UserSettingController.ExistUserSetting(filePath)) return new GridSettingsType();

            GridSettingsType gridSettings = null;
            try
            {
                gridSettings = UserSettingController.DeserializeUserSetting<GridSettingsType>(filePath);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
                return new GridSettingsType();
            }
            return gridSettings;
        }

        /// <summary>
        /// 列情報を取り込みます。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04001UA.LoadGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">対象グリッド</param>
        /// <param name="columnInfoList">列情報</param>
        public static void LoadColumnInfo(
            UltraGrid grid,
            List<ColumnInfo> columnInfoList
        )
        {
            #region Guard Phrase

            if (columnInfoList == null || columnInfoList.Count.Equals(0)) return;

            #endregion // Guard Phrase

            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in columnInfoList)
            {
                try
                {
                    UltraGridColumn ultraGridColumn = grid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    {
                        ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                        // 表示・非表示は画面で設定できないので引き継がない
                        //ultraGridColumn.Hidden = columnInfo.Hidden;
                        ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                        ultraGridColumn.Width = columnInfo.Width;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.ToString());
                }
            }
        }

        #endregion // 設定の展開

        #region 設定の保存

        /// <summary>
        /// グリッドの表示設定を保存します。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04004UA.Serialize()
        /// </remarks>
        /// <param name="gridSettings">グリッドの設定情報</param>
        /// <param name="xmlFileName">設定XMLファイル名</param>
        public static void StoreGridSettings(
            GridSettingsType gridSettings,
            string xmlFileName
        )
        {
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);

                UserSettingController.SerializeUserSetting(gridSettings, fileName);

                #region 実験コード
                //CustPtrSalesUserConst test = new CustPtrSalesUserConst();
                //test.OutputPattern = new string[0];
                //test.SlipColumnsList = new List<ColumnInfo>();
                //test.DetailColumnsList = columnInfoList; 
                //test.RedSlipColumnsList = new List<ColumnInfo>();
                //test.EnabledConditionList = new List<string>();
                //UserSettingController.SerializeUserSetting(test, fileName);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// 列情報リストを生成します。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04001UA.SaveGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">対象グリッド</param>
        /// <returns>対象グリッドより列情報を抽出し、リストで返します。</returns>
        public static List<ColumnInfo> CreateColumnInfoList(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return new List<ColumnInfo>();

            #endregion // Guard Phrase

            List<ColumnInfo> columnInfoList = new List<ColumnInfo>();
            {
                foreach (UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].Columns)
                {
                    columnInfoList.Add(new ColumnInfo(
                        ultraGridColumn.Key,
                        ultraGridColumn.Header.VisiblePosition,
                        ultraGridColumn.Hidden,
                        ultraGridColumn.Width,
                        ultraGridColumn.Header.Fixed
                    ));
                }
            }
            return columnInfoList;
        }

        #endregion // 設定の保存
    }

    #region 伝票グリッド設定情報

    /// <summary>
    /// 伝票グリッド設定情報クラス
    /// </summary>
    [Serializable]
    public class SlipGridSettings : CustPtrSalesUserConst
    {
        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SlipGridSettings() : base()
        {
            base.OutputPattern          = new string[0];
            base.SlipColumnsList        = new List<ColumnInfo>();
            base.DetailColumnsList      = new List<ColumnInfo>();
            base.RedSlipColumnsList     = new List<ColumnInfo>();
            base.EnabledConditionList   = new List<string>();
        }

        #endregion // Constructor
    }

    #endregion // 伝票グリッド設定情報

    #endregion // 伝票グリッド
}