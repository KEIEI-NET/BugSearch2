using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率優先設定自動登録　優先設定編集画面
    /// </summary>
    /// <remarks>
    /// <br>Note		: 掛率優先設定自動登録UIクラスを表示します。</br>
    /// <br>Programmer  : Miwa Honda</br>
    /// <br>Date        : 2013/11/06</br>
    /// <br>UpDate        : 2014/9/19 Miwa Honda　サポートの管理拠点(1)がないときエラー</br>
    /// </remarks>
    internal partial class RateProtyMngConvertClass : Form
    {
        #region ■ Constructor
        internal RateProtyMngConvertClass()
        {
            InitializeComponent();
        }
        # endregion

        #region Contants

        //テーブル情報
        private const string ctSellingPriceTable = "SellingPriceTable";
        private const string ctCostpriceTable = "CostpriceTable";
        private const string ctSelect = "Select";     　　　    　　　　　　　　　 // 選択有無
        private const string ctPriorityOrder = "PriorityOrder"; 　　　　　　　　 // 掛率優先順位
        private const string ctRateSettingDivideName = "RateSettingDivideName";  // 掛率設定区分名称
        private const string ctRateCount = "RateCount";       　　　　　　　　　　// 掛率件数

        private const string ctRateSettingDivide = "RateSettingDivide";       // 掛率設定区分
        private const string ctRateMngGoodsCd = "RateMngGoodsCd";       // 掛率設定区分（商品）
        private const string ctRateMngGoodsNm = "RateMngGoodsNm";       // 掛率設定名称（商品）
        private const string ctRateMngCustCd = "RateMngCustCd";       // 掛率設定区分（得意先）
        private const string ctRateMngCustNm = "RateMngCustNm";       // 掛率設定名称（得意先）

        // グリッド選択色設定 255, 255, 192
        private readonly Color _selectedBackColor = Color.FromArgb(255, 224, 192);
        private readonly Color _selectedBackColor2 = Color.FromArgb(255, 224, 192);
        # endregion

        # region プライベイトメンバ
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>拠点コード</summary>
        private string _sectionCode;
        /// <summary>従業員</summary>
        private Employee _employee = null;
        /// <summary>エラーメッセージ</summary>
        private string _errMsg = string.Empty;
        /// <summary>拠点情報リスト</summary>
        private SecInfoSet[] _secInfoSetList;

        // 現在選択している件数をカウントしているもの
        /// <summary>選択件数（売価）</summary>
        private int _sellingSelectCnt = 0;
        /// <summary>選択件数（原価）</summary>
        private int _costSelectCnt = 0;

        //　DataTable関連
        /// <summary>DataSet（グリッドに反映しているTabelを格納しているデータセット）</summary>
        private DataSet _dataSet = null;
        /// <summary>売価View(グリッドに反映しているVIEW)</summary>
        private DataView _sellingPriceView = null;
        /// <summary>原価View(グリッドに反映しているVIEW)</summary>
        private DataView _costPriceView = null;

        /// <summary>結果取得View</summary>
        private DataView _retDispView = null;

        /// <summary>掛率設定管理Dic</summary>
        Dictionary<string, DataRow> _rateMngOfferDic = null;

        // アクセスクラス関連
        /// <summary>掛率優先コンバートアクセスクラス</summary>
        private PMKHN09932AA _rateProtyMngConvertAcs = null;
        /// <summary>掛率設定管理マスタアクセスクラス</summary>
        private RateMngGoodsCust _rateMngGoodsCust = null;
        /// <summary>掛率優先管理マスタアクセスクラス</summary>
        private RateProtyMngAcs _rateProtyMngAcs;

        // ガイド
        private PMKHN09931UA.PMKHN09931U_Para _rateDitailFormPara = null;
        private PMKHN09931UA _rateDitailForm = null;

        // フラグ関連
        /// <summary>全社選択フラグ true:全社</summary>
        private bool _selectAllSecFlg;
        /// <summary>画面起動準備中フラグ true:画面起動準備中</summary>
        private bool _showingFlag = false;


        # endregion

        #region プロパティ
        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        /// <summary>
        /// 拠点コード
        /// </summary>
        internal string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        /// <summary>
        /// 拠点リスト
        /// </summary>
        internal SecInfoSet[] SecInfoSetList 
        {
            get { return _secInfoSetList; }
            set { _secInfoSetList = value; }
        }

        /// <summary>
        /// 「全社」選択フラグ true:全社
        /// </summary>
        internal bool SelectAllSecFlg
        {
            get { return _selectAllSecFlg; }
            set { _selectAllSecFlg = value; }
        }

        /// <summary>
        /// チェックボックス（必ず画面起動)
        /// </summary>
        internal bool Confirmation_checkBox
        {
            get { return _confirmation_checkBox; }
            set { _confirmation_checkBox = value; }
        }
        private bool _confirmation_checkBox;

        #endregion


        //#region Public Method
        //================================================================================
        //  internal Method
        //================================================================================

        /// <summary>
        /// 開始処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 優先設定コンバートメインプログラム開始。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        internal int StartProc(Form form)
        {
            int status = 0;
            // 企業コードの表示
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 従業員
            this._employee = LoginInfoAcquisition.Employee;

            Dictionary<string, RateAddingUpResultsPara> resultsParaDic = null;

            try
            {
                // 抽出中画面部品のインスタンスを作成
                SFCMN00299CA msgForm = new SFCMN00299CA();
                msgForm.Title = "抽出中";
                msgForm.Message = "掛率優先管理マスタ作成中…。";
                msgForm.Show();

                try
                {
                    //掛率件数Dictionary作成処理
                    status = this.RateSetDivCdAddingUp(out resultsParaDic);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;
                }
                finally
                {
                    //form.Visible = false;
                    msgForm.Close();
                }

                bool formShowFlg = false;

                //　拠点リストの作成
                this.UtilityDiv_tComboEditor.Items.Clear();
                this.UtilityDiv_tComboEditor.Items.Add(RateProtyMngCnvConst.COM_SECTION_CODE, RateProtyMngCnvConst.COMMON_MODE);
                foreach (SecInfoSet secInfoSet in this._secInfoSetList)
                {
                    this.UtilityDiv_tComboEditor.Items.Add(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), secInfoSet.SectionGuideNm);
                }

                // 画面起動準備開始フラグ：true
                this._showingFlag = true;

                // 必ず画面を起動します
                if (this.Confirmation_checkBox)
                {
                    formShowFlg = true;　// 画面起動
                }
                else  // 問題なければ画面を起動しない
                {

                    // 存在チェック
                    if (this.ExistsRateProtyMngData() == true) // 問題なければ処理続行
                    {
                        // 掛率設定管理データ取得処理
                        this.SearchRateMngGoodsCust();

                        RateAddingUpResultsPara resultsPara;

                        // 全社選択時…全拠点分登録、チェックを行う
                        if (this._selectAllSecFlg)
                        {
                            // 掛率優先管理データ存在チェック
                            foreach (SecInfoSet secInfoSet in this._secInfoSetList)
                            {
                                if (resultsParaDic.TryGetValue(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), out resultsPara))
                                {
                                    // そのまま登録OKフラグ true:問題なく登録可能
                                    if (resultsPara.countFlg)
                                    {
                                        //掛率優先設定保存処理
                                        status = this.SaveRateProtyMng(resultsPara.resultsTbl, secInfoSet.SectionCode.Trim().PadLeft(2, '0'));
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            return status;

                                        // コンボボックスの背景をグレーにする
                                        this.UtilityDiv_tComboEditor.Value = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                                        this.UtilityDiv_tComboEditor.Items[this.UtilityDiv_tComboEditor.SelectedIndex].Appearance.BackColor = System.Drawing.Color.Gray;
                                    }
                                    else
                                        formShowFlg = true;　// 画面起動
                                }
                                else
                                    // 対象の掛率がない場合も画面を表示する対象とする
                                    formShowFlg = true;
                            }
                        }

                        else // 拠点選択時…選択拠点が登録できれば画面を表示せずに終了する
                        {
                            if (resultsParaDic.TryGetValue(this._sectionCode.PadLeft(2, '0'), out resultsPara))
                            {
                                // そのまま登録OKフラグ true:問題なく登録可能
                                if (resultsPara.countFlg)
                                {
                                    //掛率優先設定保存処理
                                    status = this.SaveRateProtyMng(resultsPara.resultsTbl, this._sectionCode);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        return status;
                                }
                                else
                                    formShowFlg = true;　// 画面起動
                            }
                            else
                                formShowFlg = true;　// 画面起動
                        }
                    }
                    else //存在チェックでキャンセルの場合は処理終了
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                // 画面起動準備開始フラグ：false
                this._showingFlag = false;


                // 画面起動の必要あり
                if (formShowFlg)
                {
                    // 画面表示処理
                    this.ShowSelectRateProtyMngForm();
                    Close();
                    return status;
                }
                else
                {
                    // 画面なし＆更新対象があれば更新できた！
                    if (resultsParaDic.Count != 0)
                    {
                        TMsgDisp.Show(
                           emErrorLevel.ERR_LEVEL_INFO, 			    　　	     // エラーレベル
                           RateProtyMngCnvConst.ctPGID,							// アセンブリID
                            "掛率優先管理マスタの更新が完了しました。",               // 表示するメッセージ
                           0,													　　     // ステータス値
                           MessageBoxButtons.OK);							　　	// 表示するボタン
                    }
                }
                
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "掛率マスタ取得に失敗しました。\r\n" + ex, status, MessageBoxButtons.OK);
                return status;
            }

            return status;

        }


        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int ShowSelectRateProtyMngForm()
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string errMsg;

            Note1.Text = "※最大20件選択可能です。";
            Note2.Text = "※グレーの拠点は既に登録済みの拠点です。";


            //---------------------------------
            // アイコン設定
            //---------------------------------
            ImageList imageList16 = IconResourceManagement.ImageList16;

            //ツールバーの設定
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.CLOSE];
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.SAVE];
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Detail"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.DETAILS];

            this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.BASE];
            this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"].SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.EMPLOYEE];

            // 拠点名
            foreach (SecInfoSet secInfoSet in this._secInfoSetList)
            {
                if (_employee.BelongSectionCode.Trim().PadLeft(2, '0') == secInfoSet.SectionCode.Trim().PadLeft(2, '0'))
                {
                    this.tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"].SharedProps.Caption = secInfoSet.SectionGuideNm;
                    break;
                }
            }

            // ログイン名
            this.tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();

            //---------------------------------
            // グリッド設定
            //---------------------------------
            // データセットスキーマ作成
            this._dataSet = new DataSet();
            this.DataSetColumnConstruction(ctSellingPriceTable); // 売価用スキーマ作成
            this.DataSetColumnConstruction(ctCostpriceTable);    // 原価用スキーマ作成
             
            //グリッドにデータを紐付ける
            this._sellingPriceView = _dataSet.Tables[ctSellingPriceTable].DefaultView;
            this._costPriceView = _dataSet.Tables[ctCostpriceTable].DefaultView;

            // GRIDの初期設定
            this.SettingGrid(SellingPrice_Grid, ctSellingPriceTable, this._sellingPriceView); // 売価用
            this.SettingGrid(CostPrice_Grid, ctCostpriceTable, this._costPriceView);   // 原価用


            // 画面の表示
            switch (this.ShowDialog())
            {
                case DialogResult.OK:
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;

                case DialogResult.Cancel:
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    break;

                case DialogResult.Abort:
                    errMsg = this._errMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    break;
                default:
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    break;
            }

            return status;
        }

        /// <summary>
        /// 画面表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 20089 Miwa Honda</br>
        /// <br>Date       : 2008.12.15</br>
        /// </remarks>
        private void SelectRateProtyMngForm_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        /// <summary>
        /// 画面表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Programmer : 20089 Miwa Honda</br>
        /// <br>Date       : 2008.12.15</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "掛率優先管理マスタ作成中…。";
            msgForm.Show();

            try
            {
                //　優先管理データセット処理
                this.SettingRateProtyMngData();

                // 全社の場合は、自拠点を初期表示する
                if (this._selectAllSecFlg)
                {
                    // 最初から自拠点の場合、バリューチェンジが走らないため一旦全社共通を選択する
                    this.UtilityDiv_tComboEditor.Value = RateProtyMngCnvConst.COM_SECTION_CODE;
                    // 自拠点を初期表示する
                    // this.UtilityDiv_tComboEditor.Value = _employee.BelongSectionCode.Trim().PadLeft(2, '0'); // 2014.09.19 del honda
                }
                else // 拠点選択時は選択拠点のまま
                {
                    this.UtilityDiv_tComboEditor.Value = this._sectionCode;
                }

                // フォーカスはグリッドに持っていく（拠点コンボ変えると処理走る）
                SellingPrice_Grid.Focus();
                CostPrice_Grid.ActiveRow = null;
            }
            finally
            {
                //form.Visible = false;
                msgForm.Close();
            }
        }

        /// <summary>
        /// 掛率マスタ集計件数取得処理
        /// </summary>
        /// <param name="resultsParaDic">検索結果</param>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// <returns>status</returns>
        private int RateSetDivCdAddingUp(out Dictionary<string, RateAddingUpResultsPara> resultsParaDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (this._rateProtyMngConvertAcs == null)
                this._rateProtyMngConvertAcs = new PMKHN09932AA();

            string errMsg;
            RateAddingUpResultsPara resultsPara = null;
            resultsParaDic = null;

            // 掛率マスタ件数取得処理
            status = this._rateProtyMngConvertAcs.RateSetDivCdAddingUp(out resultsParaDic, this._enterpriseCode, this._sectionCode, out errMsg);
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                 (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {

                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "掛率マスタ取得に失敗しました。", status, MessageBoxButtons.OK);
                return status;
            }
            if (resultsParaDic == null)
                return (int)ConstantManagement.DB_Status.ctDB_EOF;

            //　拠点がある場合
            if (this._sectionCode != "") 
            {
                // 拠点が特定されている場合はそれをつかう
                if (resultsParaDic.TryGetValue(this._sectionCode.Trim().PadLeft(2, '0'), out resultsPara))
                {
                    // 表示するVIEW
                    this._retDispView = resultsPara.resultsTbl.DefaultView;
                }
            }
            else
            {
                // 全社の場合は自拠点分をViewにいれておくことにしよう
                if (resultsParaDic.TryGetValue(_employee.BelongSectionCode.Trim().PadLeft(2, '0'), out resultsPara))
                {
                    // 表示するVIEW
                    this._retDispView = resultsPara.resultsTbl.DefaultView;
                }
            }
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {

                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "掛率マスタ取得に失敗しました。", status, MessageBoxButtons.OK);
                return status;
            }

            return status;
        }

        /// <summary>
        /// 掛率設定管理マスタ　DataRowセット処理（件数・選択）
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// <returns>status</returns>
        private int SettingRateCount()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "掛率件数取得中…。";
            msgForm.Show();

            Dictionary<string, RateAddingUpResultsPara> resultsParaDic = new Dictionary<string, RateAddingUpResultsPara>();

            try
            {
                // 掛率マスタ集計件数取得処理（アクセスクラスより）
                status = this.RateSetDivCdAddingUp(out resultsParaDic);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 優先管理データセット処理
                // グリッドの色変えをする
                for (int i = 0; i < SellingPrice_Grid.Rows.Count; i++)
                {
                    //　掛率設定管理マスタ　DataRowセット処理 （売価設定）
                    this.SettingRateCountProc(_sellingPriceView, SellingPrice_Grid.Rows[i]);
                    // 選択・非選択変更処理
                    this.ChangedSelect((bool)SellingPrice_Grid.Rows[i].Cells[ctSelect].Value, SellingPrice_Grid.Rows[i]);

                }
                for (int i = 0; i < CostPrice_Grid.Rows.Count; i++)
                {
                    //　掛率設定管理マスタ　DataRowセット処理 （原価設定）
                    this.SettingRateCountProc(_costPriceView, CostPrice_Grid.Rows[i]);
                    // 選択・非選択変更処理
                    this.ChangedSelect((bool)CostPrice_Grid.Rows[i].Cells[ctSelect].Value, CostPrice_Grid.Rows[i]);
                }

                SellingPrice_Grid.UpdateData();
                CostPrice_Grid.UpdateData();

                // グリッド右上の件数取得処理
                // 売価設定
                GetSelectCount(SellingPrice_Grid);
                //原価設定
                GetSelectCount(CostPrice_Grid);

            }
            finally
            {

                SellingPrice_Grid.Focus();
                CostPrice_Grid.Rows[0].Selected = true;
                SellingPrice_Grid.Rows[0].Selected = true;
                SellingPrice_Grid.Rows[0].Activate();
                CostPrice_Grid.ActiveRow = null;

                msgForm.Close();
            }

            return status;
        }
        #region イベント

        /// <summary>
        /// 掛率マスタ詳細表示画面
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <param name="rateSettingDivideName">掛率設定区分名称</param>
        /// <param name="rateCount">掛率件数</param>
        /// <remarks>
        /// <br>Note　　　 : 掛率マスタの詳細画面を表示します。</br>
        /// </remarks>
        private void ShowRateDetailForm(int unitPriceKind, string rateSettingDivide, string rateSettingDivideName, string rateCount)
        {
            if ((rateCount == "") || (rateCount == "0"))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "掛率詳細情報が存在しません。",
                        0, MessageBoxButtons.OK);
                return;
            }

            if (this._rateDitailFormPara == null)
                this._rateDitailFormPara = new PMKHN09931UA.PMKHN09931U_Para();

            this._rateDitailFormPara.SectionCode = this._sectionCode;                //拠点コード
            this._rateDitailFormPara.UnitPriceKind = unitPriceKind;                 //単価種類
            this._rateDitailFormPara.RateSettingDivide = rateSettingDivide;         //掛率設定区分
            this._rateDitailFormPara.RateSettingDivideName = rateSettingDivideName; //掛率設定区分名称


            if (this._rateDitailForm == null)
                this._rateDitailForm = new PMKHN09931UA(_rateDitailFormPara);
            
            // 掛率詳細画面起動処理
            this._rateDitailForm.Disp_CreditRateDtGuid(this._rateDitailFormPara);

        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Search": 　// 件数取得処理
                    {

                        break;
                    }
                case "ButtonTool_Detail": 　// 選択行詳細
                    {

                        int unitPriceKind = 0;          // 単価種類
                        string rateSettingDivide = "";　// 掛率設定区分
                        string rateSettingDivideName = "";　// 掛率設定区分名称　
                        string rateCount = "";

                        if (SellingPrice_Grid.ActiveRow != null)
                        {
                            unitPriceKind = 1;
                            rateSettingDivide = SellingPrice_Grid.ActiveRow.Cells[ctRateSettingDivide].Value.ToString();
                            rateSettingDivideName = SellingPrice_Grid.ActiveRow.Cells[ctRateSettingDivideName].Value.ToString();
                            rateCount = SellingPrice_Grid.ActiveRow.Cells[ctRateCount].Value.ToString();
                        }
                        else if (CostPrice_Grid.ActiveRow != null)
                        {
                            unitPriceKind = 2;
                            rateSettingDivide = CostPrice_Grid.ActiveRow.Cells[ctRateSettingDivide].Value.ToString();
                            rateSettingDivideName = CostPrice_Grid.ActiveRow.Cells[ctRateSettingDivideName].Value.ToString();
                            rateCount = CostPrice_Grid.ActiveRow.Cells[ctRateCount].Value.ToString();
                        }
                        else
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "詳細表示する行を選択してください。",
                                    0, MessageBoxButtons.OK);
                            return;
                        }

                        // 掛率詳細画面起動
                        this.ShowRateDetailForm(unitPriceKind, rateSettingDivide, rateSettingDivideName, rateCount);
                        break;
                    }
                case "ButtonTool_Save": 　// 優先設定作成処理
                    {
                        // 入力チェック
                        bool chkStatus = this.InputCheckProc();
                        if (!chkStatus)
                            return;

                        DialogResult dialogResult = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name, "掛率優先管理マスタを作成します。よろしいですか？",
                            0, MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.Cancel)
                            return;

                        if (this.ExistsRateProtyMngData() == true)
                        {
                            string msg = "";
                            // 掛率優先管理マスタ保存処理(画面選択データ)
                            int status = this.SaveRateProtyMngFromFormSelect();

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                msg = "掛率優先管理マスタの更新が完了しました。";                        // コンボボックスの背景をグレーにする
                                this.UtilityDiv_tComboEditor.Items[this.UtilityDiv_tComboEditor.SelectedIndex].Appearance.BackColor = System.Drawing.Color.Gray;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                msg = "更新データが存在しませんでした。";

                            if (msg != "")
                            {

                                SellingPrice_Grid.Focus();
                                CostPrice_Grid.Rows[0].Selected = true;
                                SellingPrice_Grid.Rows[0].Selected = true;
                                SellingPrice_Grid.Rows[0].Activate();
                                CostPrice_Grid.ActiveRow = null;

                                TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_INFO, 			    　　	     // エラーレベル
                                RateProtyMngCnvConst.ctPGID,											　　    // アセンブリID
                                msg,                    // 表示するメッセージ
                                0,													　　     // ステータス値
                                MessageBoxButtons.OK);							　　	// 表示するボタン
                            }

                        }

                        break;
                    }
            }
        }

        #endregion

        /// <summary>
        ///　掛率優先管理マスタ保存処理(画面選択データ)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 掛率優先管理設定を保存します</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SaveRateProtyMngFromFormSelect()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string compKey;
            DataRow targetRow;

            // --------------------
            // 掛率優先管理の作成
            // --------------------
            RateProtyMng rateProtyMng;
            ArrayList retList = new ArrayList();
            // 更新データの取得
            // 売価設定
            this.SellingPrice_Grid.BeginUpdate();
            this._sellingPriceView.RowFilter = ctSelect;
            for (int i = 0; i < _sellingPriceView.Count; i++)
            {
                compKey = _sellingPriceView[i].Row[ctRateSettingDivide].ToString().Trim();
                if (_rateMngOfferDic.TryGetValue(compKey, out targetRow) == true)
                {
                    // 更新掛率優先管理データ取得処理
                    this.GetRateProtyMngWriteData(targetRow, out  rateProtyMng, 1, this._sectionCode);
                    retList.Add(rateProtyMng);
                }
            }
            this._sellingPriceView.RowFilter = "";
            this.SellingPrice_Grid.EndUpdate();

            // 原価設定
            this.CostPrice_Grid.BeginUpdate();
            this._costPriceView.RowFilter = ctSelect;
            for (int i = 0; i < _costPriceView.Count; i++)
            {
                compKey = _costPriceView[i].Row[ctRateSettingDivide].ToString().Trim();
                if (_rateMngOfferDic.TryGetValue(compKey, out targetRow) == true)
                {
                    // 更新掛率優先管理データ取得処理
                    this.GetRateProtyMngWriteData(targetRow, out  rateProtyMng, 2, this._sectionCode);
                    retList.Add(rateProtyMng);
                }
            }
            this._costPriceView.RowFilter = "";
            this.CostPrice_Grid.EndUpdate();

            // 掛率優先管理の登録
            string msg;
            status = this._rateProtyMngAcs.Write(ref retList, out msg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "掛率優先管理マスタの登録に失敗しました。", status, MessageBoxButtons.OK);
                return status;
            }
            if (retList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }

        /// <summary>
        ///　掛率優先管理マスタ保存処理()
        /// </summary>
        /// <param name="rateProtyMngList">更新対象データ</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note	   : 掛率優先管理設定を保存します</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SaveRateProtyMng(DataTable rateProtyMngList,string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList retList = new ArrayList();


            // 更新データ作成
            if (rateProtyMngList.Rows.Count == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    "掛率マスタが存在しませんでした。\r\n掛率優先管理マスタより登録してください",
                    0, MessageBoxButtons.OK);
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            RateProtyMng rateProtyMng = null;
            // 
            for (int i = 0; i < rateProtyMngList.Rows.Count; i++)
            {
                DataRow dr = rateProtyMngList.Rows[i];
                DataRow targetRow;
                string compKey = dr[PMKHN09932AA.RATESETTINGDIVIDE_TITLE].ToString().Trim();
                if (_rateMngOfferDic.TryGetValue(compKey, out targetRow) == true)
                {
                    // 更新掛率優先管理データ取得処理
                    this.GetRateProtyMngWriteData(targetRow, out rateProtyMng, Convert.ToInt32(dr[PMKHN09932AA.UNITPRICEKIND_TITLE]), sectionCode);

                    retList.Add(rateProtyMng);
                }
            }

            // 掛率優先管理の登録
            string msg;
            status = this._rateProtyMngAcs.Write(ref retList, out msg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "掛率優先管理マスタの登録に失敗しました。", status, MessageBoxButtons.OK);
                return status;
            }

            return status;
        }


        /// <summary>
        /// 更新掛率優先管理データ取得処理
        /// </summary>
        /// <param name="writeList">更新対象データ</param>
        /// <remarks>
        /// <br>Note		: データが入力されているかチェックします。</br>
        /// </remarks>
        private void GetRateProtyMngWriteData(DataRow targetRow, out RateProtyMng rateProtyMng, int unitPriceKind, string sectionCode)
        {
            rateProtyMng = new RateProtyMng();

            // 企業コード
            rateProtyMng.EnterpriseCode = this._enterpriseCode;
            // 論理削除区分
            rateProtyMng.LogicalDeleteCode = 0;
            // 拠点コード
            rateProtyMng.SectionCode = sectionCode;
            // 単価種類
            rateProtyMng.UnitPriceKind = unitPriceKind;
            // 掛率優先順位
            rateProtyMng.RatePriorityOrder = Convert.ToInt32(targetRow[11]);
            // 掛率設定区分
            rateProtyMng.RateSettingDivide = targetRow[4].ToString();
            // 掛率設定区分（商品）
            rateProtyMng.RateMngGoodsCd = targetRow[5].ToString();
            // 掛率設定名称（商品）
            rateProtyMng.RateMngGoodsNm = targetRow[7].ToString();
            // 掛率設定区分（得意先）
            rateProtyMng.RateMngCustCd = targetRow[6].ToString();
            // 掛率設定名称（得意先）
            rateProtyMng.RateMngCustNm = targetRow[8].ToString();

        }

        /// <summary>
        /// 掛率優先管理データ存在チェック
        /// </summary>
        /// <remarks>
        /// <returns>true:OK、false:NG</returns>
        /// <br>Note		: 出力優先管理データが存在するかチェックします。</br>
        /// </remarks>
        private bool ExistsRateProtyMngData()
        {
            int status;
            bool exitChk = true;
            DialogResult dialogResult;

            // 掛率優先管理が設定されてないかチェックする
            // もし優先設定がすでにあれば、削除して作り直す　※通常ありえないしツールだし
            if (this._rateProtyMngAcs == null)
                this._rateProtyMngAcs = new RateProtyMngAcs();
            ArrayList retList = null;
            int retTotalCnt;
            bool nextData;
            string msg;

            // 全拠点分取得できるか？　↓拠点を指定しても全件取得されます！！！
            status = this._rateProtyMngAcs.Search(out retList, out retTotalCnt, out nextData, this._enterpriseCode, this._sectionCode, out msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList delList = new ArrayList();
                if (this._sectionCode != "")
                {
                    foreach (RateProtyMng rateProtyMng in retList)
                    {
                        if (rateProtyMng.SectionCode == this._sectionCode.Trim())
                        {
                            delList.Add(rateProtyMng);
                        }
                    }
                }
                else //　全社の場合 ※全データが対象
                    delList.AddRange(retList);

                if (delList.Count > 0)
                {
                    dialogResult = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, this.Name, "掛率優先管理マスタが既に設定されています。\r\n以前のデータを削除してよろしいですか？", 0, MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return false;
                    }

                    // 掛率優先管理を削除する
                    status = this._rateProtyMngAcs.Delete(0, ref delList, out msg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "掛率優先管理マスタの削除に失敗しました。\r\n掛率優先管理マスタより削除して再度設定してください", 0, MessageBoxButtons.OK);
                        exitChk = false;
                    }
                    exitChk = true;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                exitChk= true;
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "掛率優先管理マスタの取得に失敗しました。\r\n掛率優先管理マスタより削除して再度設定してください", 0, MessageBoxButtons.OK);
                exitChk = false;
            }


            return exitChk;
        }




        /// <summary>
        /// ValueChanged イベント(UnitPriceKind_tComboEditor)
        /// </summary>
        /// <param name="checkMode">チェックレベル</param>
        /// <remarks>
        /// <br>Note		: データが入力されているかチェックします。</br>
        /// </remarks>
        private bool InputCheckProc()
        {
            bool chkFlag = true;  
            string checkMsg = string.Empty;

            try
            {
                if (this.UtilityDiv_tComboEditor.Value.ToString() == string.Empty)
                {
                    chkFlag = false;
                    checkMsg = "拠点を選択してください。";
                }

                // 売価グリッド＆原価グリッド
                else if ((this._sellingSelectCnt == 0) && (this._costSelectCnt == 0))
                {
                    chkFlag = false;
                    checkMsg = "保存対象を選択してください。";
                }
                // 売価グリッド
                else if (this._sellingSelectCnt > 20)
                {
                    chkFlag = false;
                    checkMsg = "売価設定の選択が20件を超えています。\r\n20件以内で設定してください。";
                }
                // 原価グリッド
                else if (this._costSelectCnt > 20)
                {
                    chkFlag = false;
                    checkMsg = "原価設定の選択が20件を超えています。\r\n20件以内で設定してください。";
                }
            }
            finally
            {
                if (!chkFlag)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, checkMsg, 0, MessageBoxButtons.OK);
                }

                this._sellingPriceView.RowFilter = "";
                this.SellingPrice_Grid.EndUpdate();
                this._costPriceView.RowFilter = "";
                this.CostPrice_Grid.EndUpdate();
            }

            return chkFlag;
        }


        /// <summary>
        /// 掛率設定管理 データセット（件数・選択列以外）
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDの初期表示設定を行います</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SettingRateProtyMngData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 掛率設定管理データ DataRowセット処理
            this._dataSet.Tables[ctSellingPriceTable].Clear();
            this._dataSet.Tables[ctCostpriceTable].Clear();

            // 掛率設定管理データ取得処理 まだ未取得なら取得
            if (this._rateMngOfferDic == null)
                status = SearchRateMngGoodsCust();


            foreach (DataRow dr in _rateMngOfferDic.Values)
            {
                //　掛率設定管理マスタ　DataRowセット処理 （売価設定）
                this.SettingTableRow(ctSellingPriceTable, dr);
                //　掛率設定管理マスタ　DataRowセット処理 （原価設定）
                this.SettingTableRow(ctCostpriceTable, dr);
            }

            return status;
        }

        /// <summary>
        /// 選択件数取得処理
        /// </summary>
        /// <param name="cntFlg">true:カウントUP,false:カウントダウン</param>
        /// <param name="targetGrid"></param>
        /// <remarks>
        /// <br>Note	   : GRIDの選択件数を取得します</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void GetSelectCount(bool cntFlg, Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            if (targetGrid.Name == "SellingPrice_Grid")
            {
                if (cntFlg)
                    this._sellingSelectCnt++;
                else if (!cntFlg)
                    this._sellingSelectCnt--;

                this.sellingCnt_label.Text = GetCntLabelName(this._sellingSelectCnt);
            }
            else if (targetGrid.Name == "CostPrice_Grid")
            {
                if (cntFlg)
                    this._costSelectCnt++;
                else if (!cntFlg)
                    this._costSelectCnt--;

                this.costCnt_label.Text = GetCntLabelName(this._costSelectCnt);
            }
        }

        /// <summary>
        /// 選択件数取得処理
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <remarks>
        /// <br>Note	   : GRIDの選択件数を取得します</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void GetSelectCount(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            if (targetGrid.Name == "SellingPrice_Grid")
            {
                targetGrid.BeginUpdate();
                this._sellingPriceView.RowFilter = ctSelect;
                this._sellingSelectCnt = this._sellingPriceView.Count;
                this.sellingCnt_label.Text = GetCntLabelName(this._sellingSelectCnt);
                this._sellingPriceView.RowFilter = "";
                targetGrid.EndUpdate();

            }
            else if (targetGrid.Name == "CostPrice_Grid")
            {
                targetGrid.BeginUpdate();
                this._costPriceView.RowFilter = ctSelect;
                this._costSelectCnt = this._costPriceView.Count;
                this.costCnt_label.Text = GetCntLabelName(this._costSelectCnt);
                this._costPriceView.RowFilter = "";
                targetGrid.EndUpdate();
            }
        }


        /// <summary>
        /// 件数ラベル名取得
        /// </summary>
        private string GetCntLabelName(int cnt)
        {
            return "選択" + cnt + "件";
        }

        /// <summary>
        /// 掛率設定管理データ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 掛率設定マスタ管理データを取得します</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private int SearchRateMngGoodsCust()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //まだデータを取得していないなら
            if (this._rateMngOfferDic == null)
            {
                // 掛率設定管理マスタアクセスクラス
                if (this._rateMngGoodsCust == null)
                    this._rateMngGoodsCust = new RateMngGoodsCust();

                
                DataTable retTable = null;
                int retCount;
                bool nextData;
                string message;
                status = this._rateMngGoodsCust.SearchAll(out retTable, out retCount, out nextData,
                    this._enterpriseCode, this._sectionCode, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                    }

                    // 提供データサーチ
                    TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrLvl,                           // エラーレベル
                            this.Name,                        // アセンブリＩＤまたはクラスＩＤ
                            this.Text,			                // プログラム名称
                            "SearchAll", 							// 処理名称
                            TMsgDisp.OPE_GET,                   // オペレーション
                            "掛率設定管理データの取得に失敗しました。",					    // 表示するメッセージ
                            status,                             // ステータス値
                            this._rateMngGoodsCust,    	        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                    return status;
                }

                this._rateMngOfferDic = new Dictionary<string, DataRow>();

                string key;
                for (int i = 0; i < retTable.Rows.Count; i++)
                {
                    key = retTable.Rows[i][4].ToString().Trim();   // 掛率設定区分
                    _rateMngOfferDic.Add(key, retTable.Rows[i]);
                }

               
            }

            return status;
        }

        /// <summary>
        /// 掛率設定管理マスタ　DataRowセット処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率設定管理マスタのデータをセットします。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void SettingTableRow(string dataTableName, DataRow getRow)
        {
            // 原価設定の場合
            if ((string)dataTableName == ctCostpriceTable)
            {
                if ((int)getRow[11] < 51 && (int)getRow[11] != 6)
                {
                    return;
                }
            }

            // メインテーブルへの登録
            DataRow dataRow = this._dataSet.Tables[dataTableName].NewRow();

            // 選択チェック
            dataRow[ctSelect] = false;
            // 掛率設定区分
            dataRow[ctRateSettingDivide] = getRow[4];
            // 掛率設定区分（商品）
            dataRow[ctRateMngGoodsCd] = getRow[5];  //dr[RateProtyMngAcs.RATEMNGGOODSCD];
            // 掛率設定区分（得意先）
            dataRow[ctRateMngCustCd] = getRow[6];   //dr[RateProtyMngAcs.RATEMNGCUSTCD];
            // 掛率設定名称（商品）
            dataRow[ctRateMngGoodsNm] = getRow[7];  //dr[RateProtyMngAcs.RATEMNGGOODSNM];
            // 掛率設定名称（得意先）
            dataRow[ctRateMngCustNm] = getRow[8];  //dr[RateProtyMngAcs.RATEMNGCUSTNM];
            // 優先順位
            dataRow[ctPriorityOrder] = getRow[11];

            // 掛率設定区分名称
            dataRow[ctRateSettingDivideName] = getRow[12];

            this._dataSet.Tables[dataTableName].Rows.Add(dataRow);

        }

        /// <summary>
        /// 掛率設定管理マスタ　DataRowセット処理（件数・選択）
        /// </summary>
        /// <remarks>
        /// <br>Note       : Gridの「件数」列と「選択」列に値をセットします。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void SettingRateCountProc(DataView targetView, Infragistics.Win.UltraWinGrid.UltraGridRow targetRow)
        {

            // 単価種類の取得
            string unitPriceKind = "";
            if (targetView == this._sellingPriceView)
            {
                unitPriceKind = "1";
            }
            else if (targetView == this._costPriceView)
            {
                unitPriceKind = "2";
            }

            // 件数の取得 
            this._retDispView.RowFilter =
                 PMKHN09932AA.RATESETTINGDIVIDE_TITLE + " = " + " '" + targetRow.Cells[ctRateSettingDivide].Value.ToString() + "' " + " AND " +
                 PMKHN09932AA.UNITPRICEKIND_TITLE + " = " + unitPriceKind;
            if (this._retDispView.Count != 0)
            {
                // 件数
                //targetRow.Cells[ctRateCount].Value = (Convert.ToInt32(_retDispView[0][PMKHN09932AA.COUNT_TITLE])).ToString();
                targetRow.Cells[ctRateCount].Value = _retDispView[0][PMKHN09932AA.COUNT_TITLE].ToString();
                // 選択
                targetRow.Cells[ctSelect].Value = (bool)true;
            }
            else
            {
                // 件数
                targetRow.Cells[ctRateCount].Value = "";
                // 選択
                targetRow.Cells[ctSelect].Value = (bool)false;
            }

        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
		/// </remarks>
        private void DataSetColumnConstruction(string dataTableName)
        {

            DataTable targetTable = new DataTable(dataTableName);

            //カラムの設定
            targetTable.Columns.Add(ctSelect, typeof(bool));                 // 選択    
            targetTable.Columns.Add(ctPriorityOrder, typeof(int));          // 優先順位 
            targetTable.Columns.Add(ctRateSettingDivideName, typeof(string));        　　// 掛率設定区分名称  
            targetTable.Columns.Add(ctRateCount, typeof(string));               // 件数
            targetTable.Columns.Add(ctRateSettingDivide, typeof(string));          // 掛率設定区分
            targetTable.Columns.Add(ctRateMngGoodsCd, typeof(string));          // 掛率設定区分（商品）
            targetTable.Columns.Add(ctRateMngGoodsNm, typeof(string));          // 掛率設定名称（商品）
            targetTable.Columns.Add(ctRateMngCustCd, typeof(int));          // 掛率設定区分（得意先）
            targetTable.Columns.Add(ctRateMngCustNm, typeof(string));          // 掛率設定名称（得意先）
            _dataSet.Tables.Add(targetTable);
        }

        /// <summary>
        /// GRIDの初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDの初期表示設定を行います</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2013/11/06</br>
        /// </remarks>
        private void SettingGrid(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid,  string dataTableName, DataView tarGetDataView)
        {
            targetGrid.DataSource = tarGetDataView;

            //ソート順を設定する(優先順位順）
            tarGetDataView.Sort = ctPriorityOrder;

            // 一旦全てのカラムを非表示に設定する
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn clmn in targetGrid.DisplayLayout.Bands[dataTableName].Columns)
            {
                clmn.Hidden = true;
            }

            // グリッドの設定
            Infragistics.Win.UltraWinGrid.UltraGridColumn column;

            // ----- GRIDのカラム設定 ----- //
            //選択
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctSelect];
            column.Header.Caption = "選択";
            column.Hidden = false;
            column.Width = 10;
            column.MaxWidth = 30;
            column.MinWidth = 30;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            column.CellAppearance.Cursor = Cursors.Hand;

            //優先順位
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctPriorityOrder];
            column.Header.Caption = "優先順位";
            column.Hidden = false;
            column.Width = 80;
            column.MaxWidth = 80;
            column.MinWidth = 80;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //掛率設定区分名称
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctRateSettingDivideName];
            column.Header.Caption = "掛率設定区分名称";
            column.Hidden = false;
            column.Width = 400;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //掛率件数
            column = targetGrid.DisplayLayout.Bands[dataTableName].Columns[ctRateCount];
            column.Header.Caption = "掛率件数";
            column.Hidden = false;
            column.Width = 80;
            column.MaxWidth = 80;
            column.MinWidth = 80;
            column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            // ----- GRIDの外観設定 ----- //

            //選択方法を行選択に設定。
            targetGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            //1行選択設定
            targetGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;

            // 垂直スクロールを最終項目が表示された時点で終了するに設定
            targetGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

            // 行の外観設定
            targetGrid.DisplayLayout.Override.RowAppearance.BackColor = System.Drawing.Color.White;

            // 固定列は非表示とする
            targetGrid.DisplayLayout.Bands[0].Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            // 1行おきの外観設定
            targetGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = System.Drawing.Color.Lavender;

            targetGrid.DisplayLayout.Override.RowAppearance.ForeColorDisabled = System.Drawing.Color.Black;

            //グリッドを階層表示しない（バインドしたデータセット内で配列等が有る場合グリッドが階層で表示されるため）
            targetGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

            // 選択行の外観設定
            // オレンジ
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Black;
            targetGrid.DisplayLayout.Override.SelectedRowAppearance.ForeColorDisabled = Color.Black;

            // アクティブセルの外観設定
            // オレンジ
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            targetGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColorDisabled = Color.Black;

            // ヘッダーの外観設定
            targetGrid.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            targetGrid.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            targetGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            targetGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            targetGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            targetGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            targetGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            targetGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            //行セレクターの外観設定
            targetGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            targetGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            targetGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;


            // 列幅の自動調整
            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }


        /// <summary>
        /// 選択・非選択変更処理
        /// </summary>
        /// <param name="isSelected">[T:選択,F:非選択]</param>
        /// <param name="gridRow">対象のグリッド行</param>
        /// <remarks>
        /// <br>Note　　　 : 選択・非選択状態を変更します。</br>
        /// </remarks>
        private void ChangedSelect(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            // 対象行の選択色を設定する
            if (isSelected)
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                gridRow.Cells[ctSelect].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            }
            else
            {
                if (gridRow.Index % 2 == 1)
                {
                    gridRow.Appearance.BackColor = Color.Lavender;
                }
                else
                {
                    gridRow.Appearance.BackColor = Color.White;
                }
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
                gridRow.Cells[ctSelect].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.Default;

            }
        }

        /// <summary>
        /// UltraGrid KeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Select_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // イベントソースの取得
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            //↑を押されていなかったらなにもしない
            if (e.KeyCode == Keys.Up)
            {
                // グリッドの一番上と言いたい
                if (targetGrid.ActiveRow.Index == 0)
                {
                    UtilityDiv_tComboEditor.Focus();
                    targetGrid.ActiveRow = null;
                    return;
                }
            }   
          
            if (e.KeyCode == Keys.Right)
            {
                if (sender == SellingPrice_Grid)
                {
                    CostPrice_Grid.Focus();
                    CostPrice_Grid.Rows[0].Activate();
                    CostPrice_Grid.Rows[0].Selected = true;
                    SellingPrice_Grid.ActiveRow = null;
                    return;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (sender == CostPrice_Grid)
                {
                    SellingPrice_Grid.Focus();
                    SellingPrice_Grid.Rows[0].Activate();
                    SellingPrice_Grid.Rows[0].Selected = true;
                    CostPrice_Grid.ActiveRow = null;
                    return;
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                // 選択フラグを変更する
                targetGrid.ActiveRow.Cells[ctSelect].Value = !(Boolean)targetGrid.ActiveRow.Cells[ctSelect].Value;
                // 色を変える
                this.ChangedSelect((bool)targetGrid.ActiveRow.Cells[ctSelect].Value, targetGrid.ActiveRow);
                // 件数を取得する
                GetSelectCount((bool)targetGrid.ActiveRow.Cells[ctSelect].Value, targetGrid);
                // データ確定
                targetGrid.UpdateData();
            }

            if (sender == SellingPrice_Grid)
                CostPrice_Grid.ActiveRow = null;
            else if (sender == CostPrice_Grid)
                SellingPrice_Grid.ActiveRow = null;


        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: グリッド上でクリックされた時に発生します。</br>
        /// </remarks>
        private void Select_Grid_Click(object sender, EventArgs e)
        {
            // イベントソースの取得
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            if (sender == SellingPrice_Grid)
                CostPrice_Grid.ActiveRow = null;
            else if (sender == CostPrice_Grid)
                SellingPrice_Grid.ActiveRow = null;

            try
            {
                Infragistics.Win.UltraWinGrid.UltraGrid ugSender = sender as Infragistics.Win.UltraWinGrid.UltraGrid;

                // マウスポインタがグリッドのどの位置にあるかを判定する
                Point point = System.Windows.Forms.Cursor.Position;
                Infragistics.Win.UltraWinGrid.UltraGridCell ugCell = this.getClickCell(point, ugSender);

                //セルじゃないところがクリックされていた場合
                if (ugCell == null)
                {
                    return;
                }

                //クリックした部分が選択の列じゃなかった場合
                if (ugCell.Column.Key != ctSelect)
                {
                    return;
                }

                //変更できないグリッドをクリックしたとき　// 全社共通を使いたいかもなのでチェックがはずせてもよい！
                //if ((ugCell.Row.Cells[ctRateSettingDivide].Value.ToString() == "2A") ||
                //    (ugCell.Row.Cells[ctRateSettingDivide].Value.ToString() == "4A") ||
                //    (ugCell.Row.Cells[ctRateSettingDivide].Value.ToString() == "6A"))
                //{
                //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, ugCell.Row.Cells[ctRateSettingDivideName].Value.ToString() + "は必須項目です。", 0, MessageBoxButtons.OK);
                //    return;
                //}

                ugCell.Row.Cells[ctSelect].Value = !(bool)ugCell.Row.Cells[ctSelect].Value;
                
                // 色を変える
                this.ChangedSelect((bool)ugCell.Row.Cells[ctSelect].Value, ugCell.Row);

                // 件数を取得する
                GetSelectCount((bool)ugCell.Row.Cells[ctSelect].Value, targetGrid);

                // データ確定
                targetGrid.UpdateData();

            }
            catch
            {

            }
        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: グリッド上でダブルクリックされた時に発生します。</br>
        /// </remarks>
        private void Select_Grid_DoubleClick(object sender, EventArgs e)
        {
            // イベントソースの取得
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            try
            {
                Infragistics.Win.UltraWinGrid.UltraGrid ugSender = sender as Infragistics.Win.UltraWinGrid.UltraGrid;

                // マウスポインタがグリッドのどの位置にあるかを判定する
                Point point = System.Windows.Forms.Cursor.Position;
                Infragistics.Win.UltraWinGrid.UltraGridCell ugCell = this.getClickCell(point, ugSender);

                //セルじゃないところがクリックされていた場合
                if (ugCell == null)
                {
                    return;
                }

                // 掛率マスタ詳細表示画面
                int unitPriceKind = 0; // 単価種類
                if (targetGrid.Name == "SellingPrice_Grid")
                    unitPriceKind = 1;
                else
                    unitPriceKind = 2;

                
                string rateSettingDivide = ugCell.Row.Cells[ctRateSettingDivide].Value.ToString(); // 掛率設定区分
                string rateSettingDivideName = ugCell.Row.Cells[ctRateSettingDivideName].Value.ToString(); // 掛率設定区分
                string rateCount = ugCell.Row.Cells[ctRateCount].Value.ToString(); // 掛率設定区分
                // 掛率詳細画面起動
                this.ShowRateDetailForm(unitPriceKind, rateSettingDivide, rateSettingDivideName, rateCount);

            }
            catch
            {

            }
        }


        /// <summary>
        /// 拠点コンボボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void UtilityDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._showingFlag == true) return;

            this._sectionCode = UtilityDiv_tComboEditor.Value.ToString();

            // 掛率マスタ集計件数取得処理
            this.SettingRateCount();
        }


        private void UtilityDiv_tComboEditor_KeyDown(object sender, KeyEventArgs e)
        {

        }


        /// <summary>
        /// クリック位置のセルを取得する
        /// セル以外がクリックされていたらnullを返す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //if (e.PrevCtrl == UtilityDiv_tComboEditor)
            //{
            //    e.NextCtrl = SellingPrice_Grid;
            //    SellingPrice_Grid.Rows[0].Activate();
            //    SellingPrice_Grid.Rows[0].Selected = true;
            //}

        }

        /// <summary>
        /// クリック位置のセルを取得する
        /// セル以外がクリックされていたらnullを返す
        /// </summary>
        /// <param name="point">座標</param>
        /// <param name="ugClick">UltraGrid</param>
        /// <returns></returns>
        private Infragistics.Win.UltraWinGrid.UltraGridCell getClickCell(Point point, Infragistics.Win.UltraWinGrid.UltraGrid ugClick)
        {
            point = ugClick.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = ugClick.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement == null)
            {
                return null;
            }
            objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

            // ヘッダ部の場合は以下の処理をキャンセルします。
            if (objRowCellAreaUIElement == null)
            {
                return null;
            }

            Infragistics.Win.UltraWinGrid.UltraGridCell ugCell;

            //クリックした部分が列じゃなかった場合
            if ((ugCell = objElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell)) as Infragistics.Win.UltraWinGrid.UltraGridCell) == null)
            {
                return null;
            }

            return ugCell;
        }




    }
}