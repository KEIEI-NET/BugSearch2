//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動入力の入力フォームクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 作 成 日              修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2008/02/01  修正内容 : DC.NS用に変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2008/07/14  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 修 正 日  2009.07.07  修正内容 : MANTIS対応[0013663],[0013680],[00113679]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2009/07/30  修正内容 : MANTIS対応[13892]：入庫伝票の日付表示が不正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/06/08  修正内容 : MANTIS対応[15321]：在庫移動伝票検索ガイドで、検索条件の値が桁数含めて合ってないと検索されない
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/04/11  修正内容 : 障害改良対応(4月)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/05/22  修正内容 : 06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2014/04/16  修正内容 : 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73,75,76
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    public partial class MAZAI04120UD : Form
    {
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        /// <summary>イメージ情報</summary>
        private ImageList _imageList16 = null;
        /// <summary>在庫移動初期情報</summary>
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs;
        /// <summary>在庫移動アクセス情報</summary>
        private StockMoveInputAcs _stockMoveInputAcs;
        /// <summary>ヘッダ情報</summary>
        private StockMoveHeader _stockMoveHeader;
        /// <summary>検索条件情報</summary>
        private StockMoveSlipSearchCond _stockMoveSlipSearchCond;
        /// <summary>グリッド表示画面</summary>
        private MAZAI04120UE _StockMoveSlipSearchGrid;

        /// <summary>在庫移動データテーブル(ローカル保持)</summary>
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;
        /// <summary>在庫移動データテーブル(親保持)</summary>
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTableEx;

        /// <summary>在庫移動データリスト</summary>
        private ArrayList retStockMoveList;

        // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
        /// <summary>現在の伝票区分</summary>
        private int _currentSlipDiv;
        /// <summary>
        /// 現在の伝票区分を取得または設定します。
        /// </summary>
        /// <remarks>
        /// 伝票区分に応じて、出荷確定日または入荷日を表示する際に参照します。
        /// また、値は検索処理が行われた際に設定されます。
        /// </remarks>
        private int CurrentSlipDiv
        {
            get { return _currentSlipDiv; }
            set { _currentSlipDiv = value; }
        }
        // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<

        /// <summary>選択在庫移動データリスト</summary>
        private ArrayList _retStockMoveList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>在庫移動詳細データリスト</summary>
        //private ArrayList retStockMoveExpList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>在庫検索アクセスクラス</summary>
        private SearchStockAcs _searchStockAcs;

        /// <summary>確定ボタン</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _DecisionButton;
        /// <summary>閉じるボタン</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _CloseButton;
        /// <summary>元に戻すボタン</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _RetryButton;
        /// <summary>検索ボタン</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool _SearchButton;

        // 従業員アクセスクラス
        private EmployeeAcs employeeAcs;
        // 拠点アクセスクラス
        SecInfoSetAcs secInfoSetAcs;
        // 倉庫アクセスクラス
        WarehouseAcs warehouseAcs;

        // ガイド後次フォーカス制御
        MAZAI04120UA.GuideNextFocusControl _guideNextFocusControl;

        private DateTime _prevTotalDay;

        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator;

        /// <summary>所属拠点コード</summary>
        private string _belongSectionCode;
        /// <summary>所属拠点名称</summary>
        private string _belongSectionName;

        /// <summary>
        /// 所属拠点コード
        /// </summary>
        public string BelongSectionCode
        {
            get { return _belongSectionCode; }
            set { _belongSectionCode = value; }
        }
        /// <summary>
        /// 所属拠点名称
        /// </summary>
        public string BelongSectionName
        {
            get { return _belongSectionName; }
            set { _belongSectionName = value; }
        }

        # region ガイド選択結果オブジェクト
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>選択された在庫移動情報</summary>
        //private List<StockMove> _selStockMove;
        ///// <summary>選択された在庫移動詳細情報</summary>
        //private List<StockMoveExp> _selStockMoveExp;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /// <summary>グロス時詳細情報</summary>
        private Hashtable grossMap;

        /// <summary>格納テーブル判別(0:ローカル 1:親側)</summary>
        private int selectTable = 0;

        # endregion

        # region コンストラクタ

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MAZAI04120UD()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            // ボタンイメージの取得
            this._imageList16 = IconResourceManagement.ImageList16;
            // 在庫移動初期情報
            this._stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();
            // 在庫移動アクセスクラス
            this._stockMoveInputAcs = StockMoveInputAcs.GetInstance();
            // ヘッダ情報
            this._stockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;
            // 検索条件情報
            this._stockMoveSlipSearchCond = _stockMoveInputInitAcs.StockMoveSlipSearchCond;
            // グリッド表示画面
            this._StockMoveSlipSearchGrid = new MAZAI04120UE();
            // 在庫移動データテーブル(検索結果用)
            this._stockMoveDataTable = _StockMoveSlipSearchGrid.StockmoveDataTable;
            // 財起動データテーブル(親保持用)
            this._stockMoveDataTableEx = _stockMoveInputAcs.StockMoveDataTable;

            // 在庫検索アクセスクラス
            this._searchStockAcs = new SearchStockAcs();

            // 従業員アクセスクラス
            this.employeeAcs = new EmployeeAcs();
            // 拠点アクセスクラス
            this.secInfoSetAcs = new SecInfoSetAcs();
            // 倉庫アクセスクラス
            this.warehouseAcs = new WarehouseAcs();

            // グロス時詳細情報
            this.grossMap = new Hashtable();

            // 在庫移動データテーブル更新用デリゲート
            this._StockMoveSlipSearchGrid.SettingGuideData += new MAZAI04120UE.SettingGuideDataEventHandler(this.updateGridFromStockMoveSlipGuide);
            this._StockMoveSlipSearchGrid.SetFocus += new MAZAI04120UE.SetFocusEventHandler(this.SetFocus);

            // 確定ボタン設定
            this._DecisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["Decision_ButtonTool"];
            // 閉じるボタン設定
            this._CloseButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["Close_ButtonTool"];
            // 元に戻すボタン設定
            this._RetryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["Retry_ButtonTool"];
            // 検索ボタン設定
            this._SearchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["Search_ButtonTool"];

            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            // ガイド後次フォーカス制御
            SettingGuideNextFocusControl();
        }

        private void SetFocus()
        {
            this.ShipmentFixDaySt_tDateEdit.Focus();
        }

        /// <summary>
        /// 売上仕入月次更新履歴取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="recPayDiv">売上仕入区分(0:売上　1:仕入)</param>
        /// <param name="prevTotalDay">前回月次処理日</param>
        /// <param name="currentTotalDay">今回月次処理日</param>
        /// <param name="prevTotalMonth">前回月次処理年月</param>
        /// <param name="currentTotalMonth">今回月次処理年月</param>
        /// <param name="convertProcessDivCd">コンバート処理区分</param>
        /// <returns>ステータス</returns>
        private int GetHisTotalDayMonthlyAccRecPay(string sectionCode,
                                                  int recPayDiv,
                                                  out DateTime prevTotalDay)
        {
            int status = 0;

            prevTotalDay = new DateTime();
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;

            if ((sectionCode == "") || (sectionCode == "0") || (sectionCode == "00"))
            {
                // 全社の場合
                sectionCode = "";
            }
            else
            {
                // 各拠点の場合
                sectionCode = sectionCode.PadLeft(2, '0');
            }

            try
            {
                if (recPayDiv == 0)
                {
                    this._totalDayCalculator.InitializeHisMonthlyAccRec();

                    // 売上月次更新履歴取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode,
                                                                                  out prevTotalDay,
                                                                                  out currentTotalDay,
                                                                                  out prevTotalMonth,
                                                                                  out currentTotalMonth,
                                                                                  out convertProcessDivCd);
                }
                else
                {
                    this._totalDayCalculator.InitializeHisMonthlyAccPay();

                    // 仕入月次更新履歴取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode,
                                                                                  out prevTotalDay,
                                                                                  out currentTotalDay,
                                                                                  out prevTotalMonth,
                                                                                  out currentTotalMonth,
                                                                                  out convertProcessDivCd);
                }
            }
            catch
            {
                prevTotalDay = new DateTime();
                currentTotalDay = new DateTime();
                prevTotalMonth = new DateTime();
                currentTotalMonth = new DateTime();

                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ガイド後次フォーカス制御
        /// </summary>
        private void SettingGuideNextFocusControl()
        {
            _guideNextFocusControl = new MAZAI04120UA.GuideNextFocusControl();

            _guideNextFocusControl.Add( tNedit_SupplierSlipNo );
            _guideNextFocusControl.Add( StockMvEmpCode_tEdit );
            //_guideNextFocusControl.Add( ShipAgentCd_tEdit );
            _guideNextFocusControl.Add( BfSectionCode_tEdit );
            _guideNextFocusControl.Add( BfEnterWarehCode_tEdit );
            _guideNextFocusControl.Add( AfSectionCode_tEdit );
            _guideNextFocusControl.Add( AfEnterWarehCode_tEdit );

            //_guideNextFocusControl.Add( ShipmentScdlDaySt_tDateEdit );
            // ガイドに関係無いので以下略
        }

        # endregion

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        private void SetControlSize()
        {
            this.tNedit_SupplierSlipNo.Size = new Size(84, 24);
            this.StockMvEmpCode_tEdit.Size = new Size(52, 24);
            this.StockMvEmpName_tEdit.Size = new Size(147, 24);
            this.BfSectionCode_tEdit.Size = new Size(52, 24);
            this.BfSectionName_tEdit.Size = new Size(147, 24);
            this.AfSectionCode_tEdit.Size = new Size(52, 24);
            this.AfSectionName_tEdit.Size = new Size(147, 24);
            this.BfEnterWarehCode_tEdit.Size = new Size(52, 24);
            this.BfEnterWarehName_tEdit.Size = new Size(147, 24);
            this.AfEnterWarehCode_tEdit.Size = new Size(52, 24);
            this.AfEnterWarehName_tEdit.Size = new Size(147, 24);
        }

        private void Search()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 日付範囲チェック
                if ((this.ShipmentFixDaySt_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.ShipmentFixDayEd_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.ShipmentFixDaySt_tDateEdit.GetDateTime().AddMonths(3) <= this.ShipmentFixDayEd_tDateEdit.GetDateTime())
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "出荷日の範囲は3ヶ月以内に設定してください。",
                        0,
                        MessageBoxButtons.OK);
                        return;
                    }
                }

                // ローカルデータテーブル
                selectTable = 0;

                // データテーブルのクリア
                _stockMoveDataTable.Clear();

                // グロスデータ詳細情報のクリア
                grossMap = new Hashtable();

                // 検索条件の格納
                this.SetStockMoveSearchCond();

                // 在庫移動伝票検索画面時在庫移動データ検索処理
                int status = _stockMoveInputAcs.SearchStockMove(ref retStockMoveList);

                // 正常終了
                if (status == 0)
                {
                    // 検索条件のクリア
                    _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();

                    /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                    // 商品の移動可能数を入れるテーブルだが、検索後は入れない
                    Hashtable nullTable = new Hashtable();
                       --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

                    // テーブルデータとして格納
                    // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                    //this.StockMoveDataTableFromStockMoveWork(retList, nullTable);
                    this.StockMoveDataTableFromStockMoveWork(retStockMoveList);
                    // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
                }
                // 該当データ無し
                else if (status == 9)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当データがありません。",
                        status,
                        MessageBoxButtons.OK);
                }
                // 検索失敗
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "検索に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        # region フォームイベントハンドラ

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2012/05/22 wangf </br>
        /// <br>            : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        private void MAZAI04120UD_Load(object sender, EventArgs e)
        {
            // コントロールサイズ設定
            SetControlSize();

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // データグリッドを追加
            this.Detail_panel.Controls.Add(this._StockMoveSlipSearchGrid);
            this._StockMoveSlipSearchGrid.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 前回月次処理日取得
            GetHisTotalDayMonthlyAccRecPay(LoginInfoAcquisition.Employee.BelongSectionCode.Trim(), 0, out this._prevTotalDay);
            if (this._prevTotalDay == DateTime.MinValue)
            {
                this.ShipmentFixDaySt_tDateEdit.SetDateTime(DateTime.Today.AddMonths(-3).AddDays(1));
                this.ShipmentFixDayEd_tDateEdit.SetDateTime(DateTime.Today);
            }
            else
            {
                this.ShipmentFixDaySt_tDateEdit.SetDateTime(this._prevTotalDay.AddDays(1));
                this.ShipmentFixDayEd_tDateEdit.SetDateTime(DateTime.Today);
            }

            //// 表示条件をデフォルト「未出荷」に設定
            //this.DisplayCondition_tComboEditor.SelectedIndex = 0;

            // 出庫拠点
            //if ( _belongSectionCode != string.Empty )
            //{
            //    this.BfSectionCode_tEdit.Text = _belongSectionCode;
            //    // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //    //this.BfSectionName_tEdit.Text = _belongSectionName;
            //    this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            //    // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            //}
            //else
            //{
            //    this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode;
            //    this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            //}
            this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            //this.BfSectionCode_tEdit.ReadOnly = true;

            //// 出荷予定日
            //this.ShipmentScdlDaySt_tDateEdit.SetDateTime(DateTime.Now);
            //this.ShipmentScdlDayEd_tDateEdit.SetDateTime(DateTime.Now);

            // 2009.07.07 Add >>>
            if (this._stockMoveInputInitAcs.StockMoveFixCode == 1)
            {
                this.ShipmentFixDay_ultraLabel.Text = "出荷日";
            }
            else
            {
                //this.ShipmentFixDay_ultraLabel.Text = "日付"; // DEL wangf 2012/05/22 FOR Redmine#29881
                this.ShipmentFixDay_ultraLabel.Text = "入出荷日"; // ADD wangf 2012/05/22 FOR Redmine#29881
            }
            // 2009.07.07 Add <<<

            // 初期フォーカスの決定
            this.tNedit_SupplierSlipNo.Focus();
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAZAI04120UD_FormClosed(object sender, FormClosedEventArgs e)
        {
            _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();
            this.Close();
        }

        # endregion

        # region パブリックメソッド

        /// <summary>
        /// 在庫移動伝票検索ガイド
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="retObject">結果リスト</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowGuide(IWin32Window owner, out object retObject)
        {
            DialogResult dr = DialogResult.OK;

            // 在庫移動伝票検索画面の表示
            dr = base.ShowDialog(owner);

            // 結果オブジェクトを格納
            ArrayList retList = new ArrayList();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //retList.Add( _selStockMove );
            //retList.Add(_selStockMoveExp);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            retObject = this._retStockMoveList;

            return dr;
        }

        # endregion

        # region プライベートメソッド

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            // ツールバーイメージリスト
            this.tToolbarsManager1.ImageListSmall = this._imageList16;

            // 確定ボタン
            this._DecisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 閉じるボタン
            this._CloseButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            // 元に戻すボタン
            this._RetryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            // 検索ボタン
            this._SearchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            //// 検索ボタン
            //Search_ultraButton.ImageList = this._imageList16;
            // 移動指示担当者ガイドボタン
            this.StockMvEmpGuide_uButton.ImageList = this._imageList16;
            //// 出荷確定担当者ガイドボタン
            //this.ShipAgentGuide_ultraButton.ImageList = this._imageList16;
            // 出庫拠点ガイドボタン
            this.BfSectionGuide_ultraButton.ImageList = this._imageList16;
            // 出庫倉庫ガイドボタン
            this.BfEnterWarehGuide_ultraButton.ImageList = this._imageList16;
            // 入庫拠点ガイドボタン
            this.AfSectionGuide_ultraButton.ImageList = this._imageList16;
            // 入庫倉庫ガイドボタン
            this.AfEnterWarehGuide_ultraButton.ImageList = this._imageList16;

            this.StockMvEmpGuide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            //this.ShipAgentGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfSectionGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BfEnterWarehGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.AfSectionGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.AfEnterWarehGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;
            //this.Search_ultraButton.Appearance.Image = (int)Size16_Index.SEARCH;
        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <br>Update Note : 2012/05/22 wangf </br>
        /// <br>            : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        private void SetStockMoveSearchCond()
        {
            // 伝票番号
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.StockMoveSlipNo = this.tNedit_SupplierSlipNo.GetInt();

            // DEL 2010/06/08 MANTIS対応[15321]：在庫移動伝票検索ガイドで、検索条件の値が桁数含めて合ってないと検索されない ---------->>>>>
            #region 削除コード
            // // 移動指示担当者
            // _stockMoveInputInitAcs.StockMoveSlipSearchCond.StockMvEmpCode = this.StockMvEmpCode_tEdit.Text;
            // //// 出荷確定担当者
            // //_stockMoveInputInitAcs.StockMoveSlipSearchCond.ShipAgentCd = this.ShipAgentCd_tEdit.Text;
            // // 出庫拠点
            //_stockMoveInputInitAcs.StockMoveSlipSearchCond.BfSectionCode = this.BfSectionCode_tEdit.Text;
            // // 入庫拠点
            // _stockMoveInputInitAcs.StockMoveSlipSearchCond.AfSectionCode = this.AfSectionCode_tEdit.Text;
            // // 出庫倉庫
            // _stockMoveInputInitAcs.StockMoveSlipSearchCond.BfEnterWarehCode = this.BfEnterWarehCode_tEdit.Text;
            // // 入庫倉庫
            // _stockMoveInputInitAcs.StockMoveSlipSearchCond.AfEnterWarehCode = this.AfEnterWarehCode_tEdit.Text;
            #endregion // 削除コード
            // DEL 2010/06/08 MANTIS対応[15321]：在庫移動伝票検索ガイドで、検索条件の値が桁数含めて合ってないと検索されない ----------<<<<<
            // ADD 2010/06/08 MANTIS対応[15321]：在庫移動伝票検索ガイドで、検索条件の値が桁数含めて合ってないと検索されない ---------->>>>>
            // 移動指示担当者
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.StockMvEmpCode = FormatStringCode(this.StockMvEmpCode_tEdit.Text, 4);
            // 出庫拠点
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.BfSectionCode = FormatStringCode(this.BfSectionCode_tEdit.Text, 2);
            // 入庫拠点
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.AfSectionCode = FormatStringCode(this.AfSectionCode_tEdit.Text, 2);
            // 出庫倉庫
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.BfEnterWarehCode = FormatStringCode(this.BfEnterWarehCode_tEdit.Text, 4);
            // 入庫倉庫
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.AfEnterWarehCode = FormatStringCode(this.AfEnterWarehCode_tEdit.Text, 4);
            // ADD 2010/06/08 MANTIS対応[15321]：在庫移動伝票検索ガイドで、検索条件の値が桁数含めて合ってないと検索されない ----------<<<<<
            
            //// 出荷予定日(開始)
            //_stockMoveInputInitAcs.StockMoveSlipSearchCond.ShipmentScdlStDay = this.ShipmentScdlDaySt_tDateEdit.GetDateTime();
            //// 出荷予定日(終了)
            //_stockMoveInputInitAcs.StockMoveSlipSearchCond.ShipmentScdlEdDay = this.ShipmentScdlDayEd_tDateEdit.GetDateTime();
            // 出荷確定日(開始)
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.ShipmentFixStDay = this.ShipmentFixDaySt_tDateEdit.GetDateTime();
            // 出荷確定日(終了)
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.ShipmentFixEdDay = this.ShipmentFixDayEd_tDateEdit.GetDateTime();
            // 表示条件
            //_stockMoveInputInitAcs.StockMoveSlipSearchCond.MoveStatus = Int32.Parse(this.DisplayCondition_tComboEditor.Value.ToString());
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.MoveStatus = 2;  // 移動中のみ表示
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            // 在庫移動入力検索ガイドから検索する際に、抽出条件の値を設定する。
            _stockMoveInputInitAcs.StockMoveSlipSearchCond.CallerFunction = 1;
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<
        }

        // ADD 2010/06/08 MANTIS対応[15321]：在庫移動伝票検索ガイドで、検索条件の値が桁数含めて合ってないと検索されない ---------->>>>>
        /// <summary>
        /// 文字列型コードをフォーマット(0詰め)します。
        /// </summary>
        /// <param name="codeValue">コード値</param>
        /// <param name="digits">桁数</param>
        /// <returns>
        /// <c>codeValue.PadLeft(digits, '0')</c><br/>
        /// ※<c>codeValue</c>が<c>string.Empty</c>の場合、<c>string.Empty</c>を返します。
        /// </returns>
        private static string FormatStringCode(string codeValue, int digits)
        {
            if (string.IsNullOrEmpty(codeValue.Trim())) return string.Empty;

            return codeValue.PadLeft(digits, '0');
        }
        // ADD 2010/06/08 MANTIS対応[15321]：在庫移動伝票検索ガイドで、検索条件の値が桁数含めて合ってないと検索されない ----------<<<<<

        /// <summary>
        /// 検索条件画面クリア処理
        /// </summary>
        private void DisplayClear()
        {
            this.tNedit_SupplierSlipNo.Text = "";
            this.StockMvEmpCode_tEdit.Text = "";
            this.StockMvEmpName_tEdit.Text = "";
            //this.ShipAgentCd_tEdit.Text = "";
            //this.ShipAgentNm_tEdit.Text = "";
            this.BfSectionCode_tEdit.Text = LoginInfoAcquisition.Employee.BelongSectionCode;
            this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            this.AfSectionCode_tEdit.Text = "";
            this.AfSectionName_tEdit.Text = "";
            this.BfEnterWarehCode_tEdit.Text = "";
            this.BfEnterWarehName_tEdit.Text = "";
            this.AfEnterWarehCode_tEdit.Text = "";
            this.AfEnterWarehName_tEdit.Text = "";
            //this.ShipmentScdlDaySt_tDateEdit.SetDateTime(DateTime.Now);
            //this.ShipmentScdlDayEd_tDateEdit.SetDateTime(DateTime.Now);
            this.ShipmentFixDaySt_tDateEdit.Clear();
            this.ShipmentFixDayEd_tDateEdit.Clear();
            //this.DisplayCondition_tComboEditor.SelectedIndex = 0;

            _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();

            _stockMoveDataTable.Clear();

            if (this._prevTotalDay == DateTime.MinValue)
            {
                this.ShipmentFixDaySt_tDateEdit.SetDateTime(DateTime.Today.AddMonths(-3).AddDays(1));
                this.ShipmentFixDayEd_tDateEdit.SetDateTime(DateTime.Today);
            }
            else
            {
                this.ShipmentFixDaySt_tDateEdit.SetDateTime(this._prevTotalDay.AddDays(1));
                this.ShipmentFixDayEd_tDateEdit.SetDateTime(DateTime.Today);
            }

            this.tNedit_SupplierSlipNo.Focus();
        }

        # endregion

        # region ツールバーイベント

        /// <summary>
        /// ツールバーボタンイベント処理
        /// </summary>
        /// <br>Update Note : 2012/05/22 wangf </br>
        /// <br>            : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 確定ボタン
                case "Decision_ButtonTool":
                    {
                        _StockMoveSlipSearchGrid.timer1.Enabled = true;
                        break;
                    }
                // 閉じるボタン
                case "Close_ButtonTool":
                    {
                        _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();
                        this.Close();
                        break;
                    }
                // 元に戻すボタン
                case "Retry_ButtonTool":
                    {
                        this.DisplayClear();
                        break;
                    }
                // 検索ボタン
                case "Search_ButtonTool":
                    {
                        Search();

                        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
                        // 在庫移動区分が「２：出荷確定なし」になると、入荷日と出荷確定日が表示されています
                        // 以外場合は、そのまま既存処理を行う
                        if (this._stockMoveInputInitAcs.StockMoveFixCode != 1)
                        {
                            break;
                        }
                        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<
                        // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
                        // 伝票区分に応じて、日付カラムを切替
                        _StockMoveSlipSearchGrid.SetGridColumnsBySlipDiv(CurrentSlipDiv);
                        // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<

                        break;
                    }
            }
        }

        # endregion

        # region フォーカスコントロール

        /// <summary>
        /// フォーカスコントロール処理
        /// </summary>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 伝票番号
                case "tNedit_SupplierSlipNo":
                    {
                        if (this.tNedit_SupplierSlipNo.Text.Trim() != "")
                        {
                            // 空でなければ値を格納する
                            _stockMoveSlipSearchCond.StockMoveSlipNo = Int32.Parse(this.tNedit_SupplierSlipNo.Text.Trim());
                        }
                        else
                        {
                            // 空であれば値を初期化する。
                            _stockMoveSlipSearchCond.StockMoveSlipNo = 0;
                        }

                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (_StockMoveSlipSearchGrid.ultraGrid1.Rows.Count == 0)
                                {
                                    e.NextCtrl = ShipmentFixDayEd_tDateEdit;
                                }
                            }
                        }

                        break;
                    }
                // 移動指示担当者コード
                case "StockMvEmpCode_tEdit":
                    {
                        if (this.StockMvEmpCode_tEdit.Text.Trim() != "")
                        {
                            // 初期データに入力されたコードが存在しない場合
                            if (_stockMoveInputInitAcs.GetEmployeeName(StockMvEmpCode_tEdit.Text) == null)
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "担当者が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.StockMvEmpCode_tEdit.Text = "";
                                this.StockMvEmpName_tEdit.Text = "";
                                _stockMoveSlipSearchCond.StockMvEmpCode = "";
                                
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // 移動指示担当者名称に初期データから取得したデータを格納
                                _stockMoveSlipSearchCond.StockMvEmpCode = this.StockMvEmpCode_tEdit.Text;

                                this.StockMvEmpName_tEdit.Text = _stockMoveInputInitAcs.GetEmployeeName(StockMvEmpCode_tEdit.Text);

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        if (this.StockMvEmpName_tEdit.DataText.Trim() != "")
                                        {
                                            // フォーカス設定
                                            e.NextCtrl = this.BfSectionCode_tEdit;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 空であれば値を初期化する
                            _stockMoveSlipSearchCond.StockMvEmpCode = "";
                            // 名称を空にする
                            StockMvEmpName_tEdit.Text = "";

                        }
                        break;
                    }
                // 移動指示担当者ガイドボタン
                case "StockMvEmpGuide_uButton":
                    {
                        if (this.StockMvEmpCode_tEdit.Text.Trim() != "")
                        {
                            // 空でなければ値を格納する
                            _stockMoveSlipSearchCond.StockMvEmpCode = this.StockMvEmpCode_tEdit.Text;
                        }

                        break;
                    }
                // 出庫拠点コード
                case "BfSectionCode_tEdit":
                    {
                        if (this.BfSectionCode_tEdit.Text.Trim() != "")
                        {
                            // 初期データに入力されたコードが存在しない場合
                            if (_stockMoveInputInitAcs.GetSectionName(BfSectionCode_tEdit.Text) == null)
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.BfSectionCode_tEdit.Text = "";
                                this.BfSectionName_tEdit.Text = "";
                                _stockMoveSlipSearchCond.BfSectionCode = "";

                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // 出庫拠点名称に初期データから取得したデータを格納
                                _stockMoveSlipSearchCond.BfSectionCode = this.BfSectionCode_tEdit.Text.Trim().PadLeft(2, '0');

                                this.BfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(BfSectionCode_tEdit.Text);

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        if (this.BfSectionName_tEdit.DataText.Trim() != "")
                                        {
                                            // フォーカス設定
                                            e.NextCtrl = this.BfEnterWarehCode_tEdit;
                                        }
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        if (this.StockMvEmpName_tEdit.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.StockMvEmpCode_tEdit;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 空であれば値を初期化する
                            _stockMoveSlipSearchCond.BfSectionCode = "";
                            // 名称を空にする
                            BfSectionCode_tEdit.Text = "";
                            BfSectionName_tEdit.Text = "";
                        }
                        break;
                    }
                // 出庫拠点ガイドボタン
                case "BfSectionGuide_ultraButton":
                    {
                        if (this.BfSectionCode_tEdit.Text.Trim() != "")
                        {
                            // 空でなければ値を格納する
                            _stockMoveSlipSearchCond.BfSectionCode = this.BfSectionCode_tEdit.Text;
                        }

                        break;
                    }
                // 出庫倉庫コード
                case "BfEnterWarehCode_tEdit":
                    {
                        if (this.BfSectionCode_tEdit.Text.Trim() == "")
                        {
                            // 自拠点の倉庫を対象とする。
                            if (BfEnterWarehCode_tEdit.Text != "" && _stockMoveInputInitAcs.GetWarehouseName(BfEnterWarehCode_tEdit.Text) == null)
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入庫倉庫が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                // 画面を更新
                                this.BfEnterWarehCode_tEdit.Text = "";
                                this.BfEnterWarehName_tEdit.Text = "";
                                // 空であれば値を初期化する
                                _stockMoveSlipSearchCond.BfEnterWarehCode = "";

                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // 画面に反映
                                this.BfEnterWarehName_tEdit.Text = _stockMoveInputInitAcs.GetWarehouseName(BfEnterWarehCode_tEdit.Text);
                                // 空でなければ値を格納する
                                _stockMoveSlipSearchCond.BfEnterWarehCode = this.BfEnterWarehCode_tEdit.Text;

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        if (this.BfEnterWarehName_tEdit.DataText.Trim() != "")
                                        {
                                            // フォーカス設定
                                            e.NextCtrl = this.AfSectionCode_tEdit;
                                        }
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        if (this.BfSectionName_tEdit.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.BfSectionCode_tEdit;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                        else
                        {
                            // 初期データに入力されたコードが存在しない場合
                            if (BfEnterWarehCode_tEdit.Text != "" && _stockMoveInputInitAcs.GetWarehouseName(BfEnterWarehCode_tEdit.Text) == null)
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入庫倉庫が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                // 画面を更新
                                this.BfEnterWarehCode_tEdit.Text = "";
                                this.BfEnterWarehName_tEdit.Text = "";
                                // 空であれば値を初期化する
                                _stockMoveSlipSearchCond.BfEnterWarehCode = "";

                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // 画面に反映
                                this.BfEnterWarehName_tEdit.Text = _stockMoveInputInitAcs.GetWarehouseName(BfEnterWarehCode_tEdit.Text);
                                // 空でなければ値を格納する
                                _stockMoveSlipSearchCond.BfEnterWarehCode = this.BfEnterWarehCode_tEdit.Text;

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        if (this.BfEnterWarehName_tEdit.DataText.Trim() != "")
                                        {
                                            // フォーカス設定
                                            e.NextCtrl = this.AfSectionCode_tEdit;
                                        }
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        if (this.BfSectionName_tEdit.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.BfSectionCode_tEdit;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                // 出庫倉庫ガイドボタン
                case "BfEnterWarehGuide_ultraButton":
                    {
                        if (this.BfEnterWarehCode_tEdit.Text.Trim() != "")
                        {
                            // 空でなければ値を格納する
                            _stockMoveSlipSearchCond.BfEnterWarehCode = this.BfEnterWarehCode_tEdit.Text;
                        }

                        break;
                    }
                // 入庫拠点コード
                case "AfSectionCode_tEdit":
                    {
                        if (this.AfSectionCode_tEdit.Text.Trim() != "")
                        {
                            // 初期データに入力されたコードが存在しない場合
                            if (_stockMoveInputInitAcs.GetSectionName(AfSectionCode_tEdit.Text) == null)
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.AfSectionCode_tEdit.Text = "";
                                this.AfSectionName_tEdit.Text = "";
                                _stockMoveSlipSearchCond.AfSectionCode = "";

                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // 入庫拠点名称に初期データから取得したデータを格納
                                _stockMoveSlipSearchCond.AfSectionCode = this.AfSectionCode_tEdit.Text;

                                this.AfSectionName_tEdit.Text = _stockMoveInputInitAcs.GetSectionName(AfSectionCode_tEdit.Text);

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        if (this.AfSectionName_tEdit.DataText.Trim() != "")
                                        {
                                            // フォーカス設定
                                            e.NextCtrl = this.AfEnterWarehCode_tEdit;
                                        }
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        if (this.BfEnterWarehName_tEdit.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.BfEnterWarehCode_tEdit;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 空であれば値を初期化する
                            _stockMoveSlipSearchCond.AfSectionCode = "";
                            // 名称を空にする
                            AfSectionName_tEdit.Text = "";
                        }
                        break;
                    }
                // 入庫拠点ガイドボタン
                case "AfSectionGuide_ultraButton":
                    {
                        if (this.AfSectionCode_tEdit.Text.Trim() != "")
                        {
                            // 空でなければ値を格納する
                            _stockMoveSlipSearchCond.AfSectionCode = this.AfSectionCode_tEdit.Text;
                        }

                        break;
                    }
                // 入庫倉庫コード
                case "AfEnterWarehCode_tEdit":
                    {
                        if (this.AfSectionCode_tEdit.Text.Trim() == "")
                        {
                            // 自拠点の倉庫を対象とする。
                            if (AfEnterWarehCode_tEdit.Text != "" && _stockMoveInputInitAcs.GetWarehouseName(AfEnterWarehCode_tEdit.Text) == null)
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入庫倉庫が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                // 画面を更新
                                this.AfEnterWarehCode_tEdit.Text = "";
                                this.AfEnterWarehName_tEdit.Text = "";
                                // 空であれば値を初期化する
                                _stockMoveSlipSearchCond.AfEnterWarehCode = "";

                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // 画面に反映
                                this.AfEnterWarehName_tEdit.Text = _stockMoveInputInitAcs.GetWarehouseName(AfEnterWarehCode_tEdit.Text);
                                // 空でなければ値を格納する
                                _stockMoveSlipSearchCond.AfEnterWarehCode = this.AfEnterWarehCode_tEdit.Text;

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        if (this.AfEnterWarehName_tEdit.DataText.Trim() != "")
                                        {
                                            // フォーカス設定
                                            e.NextCtrl = this.ShipmentFixDaySt_tDateEdit;
                                        }
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        if (this.AfSectionName_tEdit.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.AfSectionCode_tEdit;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                        else
                        {
                            // 初期データに入力されたコードが存在しない場合
                            if (AfEnterWarehCode_tEdit.Text != "" && _stockMoveInputInitAcs.GetWarehouseName(AfEnterWarehCode_tEdit.Text) == null)
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入庫倉庫が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                // 画面を更新
                                this.AfEnterWarehCode_tEdit.Text = "";
                                this.AfEnterWarehName_tEdit.Text = "";
                                // 空であれば値を初期化する
                                _stockMoveSlipSearchCond.AfEnterWarehCode = "";

                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // 画面に反映
                                this.AfEnterWarehName_tEdit.Text = _stockMoveInputInitAcs.GetWarehouseName(AfEnterWarehCode_tEdit.Text);
                                // 空でなければ値を格納する
                                _stockMoveSlipSearchCond.AfEnterWarehCode = this.AfEnterWarehCode_tEdit.Text;

                                if (e.ShiftKey == false)
                                {
                                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    {
                                        if (this.AfEnterWarehName_tEdit.DataText.Trim() != "")
                                        {
                                            // フォーカス設定
                                            e.NextCtrl = this.ShipmentFixDaySt_tDateEdit;
                                        }
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        if (this.AfSectionName_tEdit.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.AfSectionCode_tEdit;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                // 入庫倉庫ガイドボタン
                case "AfEnterWarehGuide_ultraButton":
                    {
                        if (this.AfEnterWarehCode_tEdit.Text.Trim() != "")
                        {
                            // 空でなければ値を格納する
                            _stockMoveSlipSearchCond.AfEnterWarehCode = this.AfEnterWarehCode_tEdit.Text;
                        }

                        break;
                    }
                // 出荷確定日(開始)
                case "ShipmentFixDaySt_tDateEdit":
                    {
                        DateTime retDateTime;
                        if (this.ShipmentFixDaySt_tDateEdit.LongDate == 0)
                        {
                            // 空だった場合値を初期化する
                            _stockMoveSlipSearchCond.ShipmentFixStDay = new DateTime();
                        }
                        else if (DateTime.TryParse(this.ShipmentFixDaySt_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) != false)
                        {
                            // 値が不正でなければ値を格納する
                            _stockMoveSlipSearchCond.ShipmentFixStDay = this.ShipmentFixDaySt_tDateEdit.GetDateTime();
                        }
                        else
                        {
                            // エラーメッセージを表示
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "入力した日付が不正です。",
                                -1,
                                MessageBoxButtons.OK);

                            // エラー時はフォーカスを移動しない
                            e.NextCtrl = e.PrevCtrl;
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if (_StockMoveSlipSearchGrid.ultraGrid1.Rows.Count == 0)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.AfEnterWarehName_tEdit.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.AfEnterWarehCode_tEdit;
                                }
                            }
                        }

                        break;
                    }
                // 出荷確定日(終了)
                case "ShipmentFixDayEd_tDateEdit":
                    {
                        DateTime retDateTime;
                        if (this.ShipmentFixDayEd_tDateEdit.LongDate == 0)
                        {
                            // 空だった場合値を初期化する
                            _stockMoveSlipSearchCond.ShipmentFixEdDay = new DateTime();
                        }
                        else if (DateTime.TryParse(this.ShipmentFixDayEd_tDateEdit.GetDateTimeString("yyyy.MM.DD"), out retDateTime) != false)
                        {
                            // 値が不正でなければ値を格納する
                            _stockMoveSlipSearchCond.ShipmentFixEdDay = this.ShipmentFixDayEd_tDateEdit.GetDateTime();
                        }
                        else
                        {
                            // エラーメッセージを表示
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "入力した日付が不正です。",
                                -1,
                                MessageBoxButtons.OK);

                            // エラー時はフォーカスを移動しない
                            e.NextCtrl = e.PrevCtrl;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (_StockMoveSlipSearchGrid.ultraGrid1.Rows.Count == 0)
                                {
                                    e.NextCtrl = tNedit_SupplierSlipNo;
                                }
                                else
                                {
                                    _StockMoveSlipSearchGrid.ultraGrid1.Rows[0].Activate();
                                    _StockMoveSlipSearchGrid.ultraGrid1.Rows[0].Selected = true;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (_StockMoveSlipSearchGrid.ultraGrid1.Rows.Count == 0)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        break;
                    }
                case "ultraGrid1":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.ShipmentFixDayEd_tDateEdit;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Enter)
                            {
                                _StockMoveSlipSearchGrid.GridEnterKeyDown();
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null) return;

            switch (e.NextCtrl.Name)
            {
                case "ultraGrid1":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                _StockMoveSlipSearchGrid.EnterKeyDownNextGrid();
                            }
                            else if (e.Key == Keys.Down)
                            {
                                _StockMoveSlipSearchGrid.DownKeyDownNextGrid();
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                _StockMoveSlipSearchGrid.ShiftKeyDownNextGrid();
                            }
                        }
                        break;
                    }

            }
        }

        # endregion


        # region データテーブル処理用

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動ワークオブジェクトから在庫移動データテーブルに格納処理
        /// </summary>
        /// <param name="stockMoveList">在庫移動検索結果リスト郡</param>
        /// <param name="ItemsTable">移動可能数格納テーブル</param>
        private void StockMoveDataTableFromStockMoveWork(ArrayList stockMoveWorkList)
        {
            // 在庫移動データ
            this._retStockMoveList = stockMoveWorkList;

            // 前回在庫移動明細レコード番号
            int moveIndex = 1;

            foreach (StockMoveWork stockMoveWorkRet in stockMoveWorkList)
            {
                // 親画面のレコードに登録する場合で、必要であれば空レコードの作成
                if (selectTable == 1 && moveIndex != stockMoveWorkRet.StockMoveRowNo)
                {
                    for (int i = moveIndex; i < stockMoveWorkRet.StockMoveRowNo; i++)
                    {
                        // 空レコードを作成
                        StockMoveInputDataSet.StockMoveRow row = this._stockMoveDataTableEx.NewStockMoveRow();

                        row.StockMoveRowNo = moveIndex;

                        // 格納しないとExceptionの発生する項目に対して値を格納
                        row.ShipmentScdlDay = "";
                        row.ShipmentFixDay = "";
                        row.ArrivalGoodsDay = "";

                        _stockMoveDataTableEx.AddStockMoveRow(row);

                        moveIndex++;
                    }
                }

                string retMessage;
                Stock stock = new Stock();
                List<Stock> stockList;

                // 条件を格納
                StockSearchPara para = new StockSearchPara();
                para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                para.SectionCode = stockMoveWorkRet.BfSectionCode;
                para.GoodsMakerCd = stockMoveWorkRet.GoodsMakerCd;
                para.GoodsNo = stockMoveWorkRet.GoodsNo;
                para.WarehouseCode = stockMoveWorkRet.BfEnterWarehCode;

                int status = _searchStockAcs.Search(para, out stockList, out retMessage);
                if (status == 0)
                {
                    stock = stockList[0];
                }
                // --- UPD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73 ---------->>>>>
                //// 在庫移動データのみデータテーブルに格納
                //StockMoveDataTableFromStockMoveWorkRes(stockMoveWorkRet, stock);

                //移動先在庫情報を取得
                Stock Afstock = new Stock();
                para = new StockSearchPara();
                para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode; //企業コード
                para.SectionCode = stockMoveWorkRet.AfSectionCode;      //移動先拠点コード
                para.GoodsMakerCd = stockMoveWorkRet.GoodsMakerCd;       //メーカーコード
                para.GoodsNo = stockMoveWorkRet.GoodsNo;            //品番
                para.WarehouseCode = stockMoveWorkRet.AfEnterWarehCode;   //移動先倉庫コード
                status = _searchStockAcs.Search(para, out stockList, out retMessage);
                if (status == 0)
                {
                    Afstock = stockList[0];
                }

                // 在庫移動データのみデータテーブルに格納
                StockMoveDataTableFromStockMoveWorkRes(stockMoveWorkRet, stock, Afstock);
                // --- UPD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73 ----------<<<<<
                moveIndex++;
            }
            _stockMoveInputInitAcs.GrossMap = grossMap;
        }

        /// <summary>
        /// 在庫移動ワークオブジェクトから在庫移動データテーブル変換処理
        /// </summary>
        /// <param name="stockMoveWorkRes">レスポンス在庫移動ワークオブジェクト</param>
        /// <param name="ItemsTable">移動可能数格納テーブル</param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// <br>Update Note: 2012/05/22 wangf </br>
        /// <br>           : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        // --- UPD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73 ---------->>>>>
        //private void StockMoveDataTableFromStockMoveWorkRes(StockMoveWork stockMoveWorkRes, Stock stock)
        private void StockMoveDataTableFromStockMoveWorkRes(StockMoveWork stockMoveWorkRes, Stock stock, Stock Afstock)
        // --- UPD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73 ----------<<<<<
        {
            StockMoveInputDataSet.StockMoveRow row = null;

            // 新規レコードの追加
            if (selectTable == 0)
            {
                row = this._stockMoveDataTable.NewStockMoveRow();
            }
            else if (selectTable == 1)
            {
                row = this._stockMoveDataTableEx.NewStockMoveRow();
            }

            row.CreateDateTime = stockMoveWorkRes.CreateDateTime;               // 作成日時(在庫移動データ)
            row.UpdateDateTime = stockMoveWorkRes.UpdateDateTime;               // 更新日時(在庫移動データ)
            row.EnterpriseCode = stockMoveWorkRes.EnterpriseCode;               // 企業コード(在庫移動データ)
            row.FileHeaderGuid = stockMoveWorkRes.FileHeaderGuid;               // GUID(在庫移動データ)
            row.UpdEmployeeCode = stockMoveWorkRes.UpdEmployeeCode;             // 更新従業員コード(在庫移動データ)
            row.UpdAssemblyId1 = stockMoveWorkRes.UpdAssemblyId1;               // 更新アセンブリID1(在庫移動データ)
            row.UpdAssemblyId2 = stockMoveWorkRes.UpdAssemblyId2;               // 更新アセンブリID2(在庫移動データ)
            row.LogicalDeleteCode = stockMoveWorkRes.LogicalDeleteCode;         // 論理削除区分(在庫移動データ)

            row.StockMoveFormal = stockMoveWorkRes.StockMoveFormal;             // 在庫移動形式
            // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
            CurrentSlipDiv = SlipDiv.GetNumber(stockMoveWorkRes.StockMoveFormal);   // 在庫移動形式から伝票区分を取得
            // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<

            row.StockMoveSlipNo = stockMoveWorkRes.StockMoveSlipNo;             // 在庫移動伝票番号
            row.StockMoveRowNo = stockMoveWorkRes.StockMoveRowNo;               // 在庫移動行番号
            // メーカーコード
            if (stockMoveWorkRes.GoodsMakerCd == 0)
            {
                row.GoodsMakerCd = "";
            }
            else
            {
                row.GoodsMakerCd = stockMoveWorkRes.GoodsMakerCd.ToString().PadLeft(4, '0');                   
            }
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            //仕入先
            if (stockMoveWorkRes.SupplierCd == 0)
            {
                row.SupplierCd = "";
            }
            else
            {
                row.SupplierCd = stockMoveWorkRes.SupplierCd.ToString().PadLeft(6, '0');
            }
            row.SupplierSnm = stockMoveWorkRes.SupplierSnm;
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            row.GoodsNo = stockMoveWorkRes.GoodsNo;                             // 商品コード
            row.GoodsName = stockMoveWorkRes.GoodsName;                         // 商品名称
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            row.GoodsNameKana = stockMoveWorkRes.GoodsNameKana;                 // 商品名称カナ
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            row.UpdateSecCd = stockMoveWorkRes.UpdateSecCd;                     // 更新拠点コード
            row.BfSectionCode = stockMoveWorkRes.BfSectionCode;                 // 出庫拠点コード
            row.BfSectionGuideNm = stockMoveWorkRes.BfSectionGuideSnm;          // 出庫拠点ガイド名称
            row.BfEnterWarehCode = stockMoveWorkRes.BfEnterWarehCode;           // 出庫倉庫コード
            row.BfEnterWarehName = stockMoveWorkRes.BfEnterWarehName;           // 出庫倉庫名称
            row.AfSectionCode = stockMoveWorkRes.AfSectionCode;                 // 入庫拠点コード
            row.AfSectionGuideNm = stockMoveWorkRes.AfSectionGuideSnm;          // 入庫拠点ガイド名称
            row.AfEnterWarehCode = stockMoveWorkRes.AfEnterWarehCode;           // 入庫倉庫コード
            row.AfEnterWarehName = stockMoveWorkRes.AfEnterWarehName;           // 入庫倉庫名称
            // 出荷予定日
            if (stockMoveWorkRes.ShipmentScdlDay == new DateTime())
            {
                row.ShipmentScdlDay = "";
            }
            else
            {
                row.ShipmentScdlDay = stockMoveWorkRes.ShipmentScdlDay.ToString("yyyy/MM/dd");
            }
            // 出荷確定日
            if (stockMoveWorkRes.ShipmentFixDay == new DateTime())
            {
                row.ShipmentFixDay = "";
            }
            else
            {
                row.ShipmentFixDay = stockMoveWorkRes.ShipmentFixDay.ToString("yyyy/MM/dd");
            }
            // 入荷日
            if (stockMoveWorkRes.ArrivalGoodsDay == new DateTime())
            {
                row.ArrivalGoodsDay = "";
            }
            else
            {
                //row.ArrivalGoodsDay = stockMoveWorkRes.ArrivalGoodsDay.ToString("yyyy/MM/dd"); // DEL wangf 2012/05/22 FOR Redmine#29881
                // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
                // 在庫移動区分が「２：出荷確定なし」になると、出荷確定日値があれば入荷日は削除、入荷日も同じ処理です。
                // 以外場合は、そのまま既存処理を行う
                if (this._stockMoveInputInitAcs.StockMoveFixCode != 1)
                {
                    row.ArrivalGoodsDay = (stockMoveWorkRes.ShipmentFixDay != new DateTime()) ? "" : stockMoveWorkRes.ArrivalGoodsDay.ToString("yyyy/MM/dd");
                }
                else
                {
                    row.ArrivalGoodsDay = stockMoveWorkRes.ArrivalGoodsDay.ToString("yyyy/MM/dd");
                }
                // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<
            }

            row.MoveStatus = stockMoveWorkRes.MoveStatus;                       // 移動状態
            row.StockMvEmpCode = stockMoveWorkRes.StockMvEmpCode;               // 在庫移動入力従業員コード
            row.StockMvEmpName = stockMoveWorkRes.StockMvEmpName;               // 在庫移動入力従業員名称
            row.ShipAgentCd = stockMoveWorkRes.ShipAgentCd;                     // 出荷担当従業員コード
            row.ShipAgentNm = stockMoveWorkRes.ShipAgentNm;                     // 出荷担当従業員名称
            row.ReceiveAgentCd = stockMoveWorkRes.ReceiveAgentCd;               // 引取担当従業員コード
            row.ReceiveAgentNm = stockMoveWorkRes.ReceiveAgentNm;               // 引取担当従業員名称
            row.Outline = stockMoveWorkRes.Outline;                             // 伝票摘要
            row.WarehouseNote1 = stockMoveWorkRes.WarehouseNote1;               // 倉庫備考1
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            row.WarehouseNote2 = stockMoveWorkRes.WarehouseNote2;               // 倉庫備考2
            row.WarehouseNote3 = stockMoveWorkRes.WarehouseNote3;               // 倉庫備考3
            row.WarehouseNote4 = stockMoveWorkRes.WarehouseNote4;               // 倉庫備考4
            row.WarehouseNote5 = stockMoveWorkRes.WarehouseNote5;               // 倉庫備考5
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            row.SearchIndexNumber = _stockMoveDataTable.Count + 1;              // 検索結果用行インデックス
            row.UpdateSecCd = stockMoveWorkRes.UpdateSecCd;                     // 更新営業所
            //row.ArrivalGoodsDay = stockMoveWorkRes.ArrivalGoodsDay.ToString("yyyy/MM/dd");  // 入荷日 // DEL wangf 2012/05/22 FOR Redmine#29881
            row.CustomerCode = stockMoveWorkRes.SupplierCd;                     // 仕入先コード
            row.CustomerName = stockMoveWorkRes.SupplierSnm;                    // 仕入先略称
            row.StockDiv = stockMoveWorkRes.StockDiv;                           // 在庫区分
            row.StockUnitPriceFl = stockMoveWorkRes.StockUnitPriceFl;           // 仕入単価
            row.BfStockUnitPriceFl = stockMoveWorkRes.StockUnitPriceFl;           // 仕入単価
            //row.MovingPrice = (int)Math.Floor(stockMoveWorkRes.StockUnitPriceFl * stockMoveWorkRes.MoveCount);  // 移動金額
            row.MovingPrice = stockMoveWorkRes.StockMovePrice;  // 移動金額
            row.TaxationDivCd = stockMoveWorkRes.TaxationDivCd;                 // 課税区分

            // 移動数
            if ( row.StockDiv == 0 ) {
                // 移動数（仕：自社）
                row.MovingSupliStock = stockMoveWorkRes.MoveCount;
                row.BfMovingSupliStock = stockMoveWorkRes.MoveCount;
                row.MovingTrustStock = 0;
            }
            else {
                // 移動数（受：受託）
                row.MovingSupliStock = 0;
                row.BfMovingSupliStock = 0;
                row.MovingTrustStock = stockMoveWorkRes.MoveCount;
            }

            row.BfShelfNo = stockMoveWorkRes.BfShelfNo;                         // 出庫棚番
            row.AfShelfNo = stockMoveWorkRes.AfShelfNo;                         // 入庫棚番
            // ＢＬ商品コード
            if (stockMoveWorkRes.BLGoodsCode == 0)
            {
                row.BLGoodsCode = "";
            }
            else
            {
                row.BLGoodsCode = stockMoveWorkRes.BLGoodsCode.ToString().PadLeft(5, '0');
            }
            row.BLGoodsFullName = stockMoveWorkRes.BLGoodsFullName;             // ＢＬ商品コード名称
            row.ListPriceFl = stockMoveWorkRes.ListPriceFl;                     // 定価
            row.ListPriceFlView = stockMoveWorkRes.ListPriceFl.ToString("###,##0");     // 定価

            // 在庫移動確定フラグ
            if (row.ShipmentFixDay != "")
            {
                row.FixFlag = true;
            }
            // 在庫移動入荷フラグ
            if (row.ArrivalGoodsDay != "")
            {
                row.ArrivalFlag = true;
            }
            // 格納テーブル判別
            if (selectTable == 0)
            {
                _stockMoveDataTable.AddStockMoveRow(row);
            }
            else if (selectTable == 1)
            {
                _stockMoveDataTableEx.AddStockMoveRow(row);
            }
            // 出庫前数
            double bfBeforeMoveCount = stock.ShipmentPosCnt + stockMoveWorkRes.MoveCount;
            row.BfBeforeMoveCount = bfBeforeMoveCount.ToString("N");
            // 出庫後数
            double bfAfterMoveCount = bfBeforeMoveCount - stockMoveWorkRes.MoveCount;
            row.BfAfterMoveCount = bfAfterMoveCount.ToString("N");
            // --- ADD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73 ---------->>>>>
            // 入庫前数
            // --- ADD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №76 ---------->>>>>
            //double afBeforeMoveCount = Afstock.ShipmentPosCnt - stockMoveWorkRes.MoveCount;
            //row.AfBeforeMoveCount = afBeforeMoveCount.ToString("N");
            // 入庫前数
            double afBeforeMoveCount = Afstock.ShipmentPosCnt;
            if (stockMoveWorkRes.MoveStatus == 9)
            {
                afBeforeMoveCount = afBeforeMoveCount - stockMoveWorkRes.MoveCount;
            }
            // --- ADD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №76 ----------<<<<<
            row.AfBeforeMoveCount = afBeforeMoveCount.ToString("N");
            // 入庫後数
            double afAfterMoveCount = afBeforeMoveCount + stockMoveWorkRes.MoveCount;
            row.AfAfterMoveCount = afAfterMoveCount.ToString("N");
            // --- ADD 2014/04/16 T.Miyamoto 入庫前・入庫後数表示対応 システムテスト障害一覧_先行配信分 №73 ----------<<<<<
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動ワークオブジェクトから在庫移動データテーブルに格納処理
        /// </summary>
        /// <param name="stockMoveList">在庫移動検索結果リスト郡</param>
        /// <param name="ItemsTable">移動可能数格納テーブル</param>
        private void StockMoveDataTableFromStockMoveWork(ArrayList stockMoveList, Hashtable ItemsTable)
        {
            // 在庫移動データ
            ArrayList stockMove = stockMoveList[0] as ArrayList;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 在庫移動詳細データ
            //ArrayList stockMoveExp = stockMoveList[1] as ArrayList;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 前回在庫移動明細レコード番号
            int moveIndex = 1;

            foreach (StockMoveWork stockMoveWorkRet in stockMove)
            {
                int stockMoveFormalRet = stockMoveWorkRet.StockMoveFormal;
                int stockMoveSlipNoRet = stockMoveWorkRet.StockMoveSlipNo;
                int stockMoveRowNoRet = stockMoveWorkRet.StockMoveRowNo;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //double movingSupliStock = stockMoveWorkRet.MovingSupliStock;
                //double movingTrustStock = stockMoveWorkRet.MovingTrustStock;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 親画面のレコードに登録する場合で、必要であれば空レコードの作成
                if (selectTable == 1 && moveIndex != stockMoveWorkRet.StockMoveRowNo)
                {
                    for (int i = moveIndex; i < stockMoveWorkRet.StockMoveRowNo; i++)
                    {
                        // 空レコードを作成
                        StockMoveInputDataSet.StockMoveRow row = this._stockMoveDataTableEx.NewStockMoveRow();

                        row.StockMoveRowNo = moveIndex;

                        // 格納しないとExceptionの発生する項目に対して値を格納
                        row.ShipmentScdlDay = "";
                        row.ShipmentFixDay = "";
                        row.ArrivalGoodsDay = "";

                        _stockMoveDataTableEx.AddStockMoveRow(row);

                        moveIndex++;
                    }
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 詳細指定在庫移動データ(出荷数が1のデータ)の場合
                //if (movingSupliStock == 1 || movingTrustStock == 1)
                //{
                //    // 該当する在庫移動詳細レコードをデータテーブルに格納
                //    foreach (StockMoveExpWork stockMoveExpWorkRet in stockMoveExp)
                //    {
                //        int stockMoveFormalExpRet = stockMoveExpWorkRet.StockMoveFormal;
                //        int stockMoveSlipNoExpRet = stockMoveExpWorkRet.StockMoveSlipNo;
                //        int stockMoveRowNoExpRet = stockMoveExpWorkRet.StockMoveRowNo;

                //        if (stockMoveFormalRet == stockMoveFormalExpRet && stockMoveSlipNoRet == stockMoveSlipNoExpRet && stockMoveRowNoRet == stockMoveRowNoExpRet)
                //        {
                //            // 在庫データと製番データからデータテーブルに格納
                //            this.StockMoveDataTableFromStockMoveWorkRes(stockMoveWorkRet, stockMoveExpWorkRet, ItemsTable);
                //        }
                //    }
                //}
                //// 在庫指定在庫移動データ(出荷数が1以上のデータ<グロス登録データ>)の場合
                //else
                //{
                //    // 在庫移動データのみデータテーブルに格納
                //    this.StockMoveDataTableFromStockMoveWorkRes(stockMoveWorkRet, null, ItemsTable);

                //    // グロスデータ格納リスト
                //    List<StockMoveExpWork> list = new List<StockMoveExpWork>();

                //    // マップオブジェクトに格納
                //    foreach (StockMoveExpWork stockMoveExpWorkRet in stockMoveExp)
                //    {
                //        int stockMoveFormalExpRet = stockMoveExpWorkRet.StockMoveFormal;
                //        int stockMoveSlipNoExpRet = stockMoveExpWorkRet.StockMoveSlipNo;
                //        int stockMoveRowNoExpRet = stockMoveExpWorkRet.StockMoveRowNo;

                //        if (stockMoveFormalRet == stockMoveFormalExpRet && stockMoveSlipNoRet == stockMoveSlipNoExpRet && stockMoveRowNoRet == stockMoveRowNoExpRet)
                //        {
                //            list.Add(stockMoveExpWorkRet);
                //        }
                //    }
                //    // <在庫移動伝票番号_在庫移動行番号>という形でキーを持つ
                //    grossMap.Add(stockMoveSlipNoRet.ToString() + "_" + stockMoveRowNoRet.ToString(), list);
                //}

                // 在庫移動データのみデータテーブルに格納
                this.StockMoveDataTableFromStockMoveWorkRes(stockMoveWorkRet, ItemsTable);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                moveIndex++;
            }
            _stockMoveInputInitAcs.GrossMap = grossMap;
        }

        /// <summary>
        /// 在庫移動ワークオブジェクトから在庫移動データテーブル変換処理
        /// </summary>
        /// <param name="stockMoveWorkRes">レスポンス在庫移動ワークオブジェクト</param>
        /// <param name="ItemsTable">移動可能数格納テーブル</param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private void StockMoveDataTableFromStockMoveWorkRes(StockMoveWork stockMoveWorkRes, StockMoveExpWork stockMoveExpWorkRes, Hashtable ItemsTable)
        private void StockMoveDataTableFromStockMoveWorkRes(StockMoveWork stockMoveWorkRes, Hashtable ItemsTable)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        {
            StockMoveInputDataSet.StockMoveRow row = null;
            // 新規レコードの追加
            if (selectTable == 0)
            {
                row = this._stockMoveDataTable.NewStockMoveRow();
            }
            else if (selectTable == 1)
            {
                row = this._stockMoveDataTableEx.NewStockMoveRow();
            }

            // 作成日時(在庫移動データ)
            row.CreateDateTime = stockMoveWorkRes.CreateDateTime;
            // 更新日時(在庫移動データ)
            row.UpdateDateTime = stockMoveWorkRes.UpdateDateTime;
            // 企業コード(在庫移動データ)
            row.EnterpriseCode = stockMoveWorkRes.EnterpriseCode;
            // GUID(在庫移動データ)
            row.FileHeaderGuid = stockMoveWorkRes.FileHeaderGuid;
            // 更新従業員コード(在庫移動データ)
            row.UpdEmployeeCode = stockMoveWorkRes.UpdEmployeeCode;
            // 更新アセンブリID1(在庫移動データ)
            row.UpdAssemblyId1 = stockMoveWorkRes.UpdAssemblyId1;
            // 更新アセンブリID2(在庫移動データ)
            row.UpdAssemblyId2 = stockMoveWorkRes.UpdAssemblyId2;
            // 論理削除区分(在庫移動データ)
            row.LogicalDeleteCode = stockMoveWorkRes.LogicalDeleteCode;

            // 在庫移動形式
            row.StockMoveFormal = stockMoveWorkRes.StockMoveFormal;
            // 在庫移動伝票番号
            row.StockMoveSlipNo = stockMoveWorkRes.StockMoveSlipNo;
            // 在庫移動行番号
            row.StockMoveRowNo = stockMoveWorkRes.StockMoveRowNo;
            // メーカーコード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //row.MakerCode = stockMoveWorkRes.MakerCode;
            row.GoodsMakerCd = stockMoveWorkRes.GoodsMakerCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // メーカー名称
            row.MakerName = stockMoveWorkRes.MakerName;

            // 商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //row.GoodsCode = stockMoveWorkRes.GoodsCode;
            row.GoodsNo = stockMoveWorkRes.GoodsNo;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 商品名称
            row.GoodsName = stockMoveWorkRes.GoodsName;
            // 更新拠点コード
            row.UpdateSecCd = stockMoveWorkRes.UpdateSecCd;
            // 出庫拠点コード
            row.BfSectionCode = stockMoveWorkRes.BfSectionCode;
            // 出庫拠点ガイド名称
            row.BfSectionGuideNm = stockMoveWorkRes.BfSectionGuideNm;
            // 出庫倉庫コード
            row.BfEnterWarehCode = stockMoveWorkRes.BfEnterWarehCode;
            // 出庫倉庫名称
            row.BfEnterWarehName = stockMoveWorkRes.BfEnterWarehName;
            // 入庫拠点コード
            row.AfSectionCode = stockMoveWorkRes.AfSectionCode;
            // 入庫拠点ガイド名称
            row.AfSectionGuideNm = stockMoveWorkRes.AfSectionGuideNm;
            // 入庫倉庫コード
            row.AfEnterWarehCode = stockMoveWorkRes.AfEnterWarehCode;
            // 入庫倉庫名称
            row.AfEnterWarehName = stockMoveWorkRes.AfEnterWarehName;

            // 出荷予定日
            if (stockMoveWorkRes.ShipmentScdlDay == new DateTime())
            {
                row.ShipmentScdlDay = "";
            }
            else
            {
                row.ShipmentScdlDay = stockMoveWorkRes.ShipmentScdlDay.ToString("yyyy/MM/dd");
            }

            // 出荷確定日
            if (stockMoveWorkRes.ShipmentFixDay == new DateTime())
            {
                row.ShipmentFixDay = "";
            }
            else
            {
                row.ShipmentFixDay = stockMoveWorkRes.ShipmentFixDay.ToString("yyyy/MM/dd");
            }

            // 入荷日
            if (stockMoveWorkRes.ArrivalGoodsDay == new DateTime())
            {
                row.ArrivalGoodsDay = "";
            }
            else
            {
                row.ArrivalGoodsDay = stockMoveWorkRes.ArrivalGoodsDay.ToString("yyyy/MM/dd");
            }

            // 移動状態
            row.MoveStatus = stockMoveWorkRes.MoveStatus;
            // 在庫移動入力従業員コード
            row.StockMvEmpCode = stockMoveWorkRes.StockMvEmpCode;
            // 在庫移動入力従業員名称
            row.StockMvEmpName = stockMoveWorkRes.StockMvEmpName;
            // 出荷担当従業員コード
            row.ShipAgentCd = stockMoveWorkRes.ShipAgentCd;
            // 出荷担当従業員名称
            row.ShipAgentNm = stockMoveWorkRes.ShipAgentNm;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 移動中仕入在庫数
            //row.MovingSupliStock = stockMoveWorkRes.MovingSupliStock;
            //// 移動中受託在庫数
            //row.MovingTrustStock = stockMoveWorkRes.MovingTrustStock;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 仕入在庫残数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (stockMoveExpWorkRes != null && stockMoveWorkRes.MovingSupliStock == 1)
            //{
            //    row.SlipRemainCount = 0;
            //}
            //else
            //{
            //    if (ItemsTable[stockMoveWorkRes.GoodsCode + "_" + stockMoveWorkRes.BfEnterWarehCode] != null)
            //    {
            //        double[] OkCount = (double[])ItemsTable[stockMoveWorkRes.GoodsCode + "_" + stockMoveWorkRes.BfEnterWarehCode];
            //        // 0:仕入在庫移動可能数 1:受託在庫移動可能数
            //        row.SlipRemainCount = OkCount[0];
            //    }
            //}

            if (ItemsTable[stockMoveWorkRes.GoodsNo + "_" + stockMoveWorkRes.BfEnterWarehCode] != null)
            {
                double[] OkCount = (double[])ItemsTable[stockMoveWorkRes.GoodsNo + "_" + stockMoveWorkRes.BfEnterWarehCode];
                // 0:仕入在庫移動可能数 1:受託在庫移動可能数
                row.SlipRemainCount = OkCount[0];
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 受託在庫残数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (stockMoveExpWorkRes != null && stockMoveWorkRes.MovingTrustStock == 1)
            //{
            //    row.TrustRemainCount = 0;
            //}
            //else
            //{
            //    if (ItemsTable[stockMoveWorkRes.GoodsCode + "_" + stockMoveWorkRes.BfEnterWarehCode] != null)
            //    {
            //        double[] OkCount = (double[])ItemsTable[stockMoveWorkRes.GoodsCode + "_" + stockMoveWorkRes.BfEnterWarehCode];
            //        // 0:仕入在庫移動可能数 1:受託在庫移動可能数
            //        row.TrustRemainCount = OkCount[1];
            //    }
            //}

            if (ItemsTable[stockMoveWorkRes.GoodsNo + "_" + stockMoveWorkRes.BfEnterWarehCode] != null)
            {
                double[] OkCount = (double[])ItemsTable[stockMoveWorkRes.GoodsNo + "_" + stockMoveWorkRes.BfEnterWarehCode];
                // 0:仕入在庫移動可能数 1:受託在庫移動可能数
                row.TrustRemainCount = OkCount[1];
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 引取担当従業員コード
            row.ReceiveAgentCd = stockMoveWorkRes.ReceiveAgentCd;
            // 引取担当従業員名称
            row.ReceiveAgentNm = stockMoveWorkRes.ReceiveAgentNm;
            // 伝票摘要
            row.Outline = stockMoveWorkRes.Outline;
            // 倉庫備考1
            row.WarehouseNote1 = stockMoveWorkRes.WarehouseNote1;
            // 倉庫備考2
            row.WarehouseNote2 = stockMoveWorkRes.WarehouseNote2;
            // 倉庫備考3
            row.WarehouseNote3 = stockMoveWorkRes.WarehouseNote3;
            // 倉庫備考4
            row.WarehouseNote4 = stockMoveWorkRes.WarehouseNote4;
            // 倉庫備考5
            row.WarehouseNote5 = stockMoveWorkRes.WarehouseNote5;

            // 検索結果用行インデックス
            row.SearchIndexNumber = _stockMoveDataTable.Count + 1;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 更新営業所
            row.UpdateSecCd = stockMoveWorkRes.UpdateSecCd;
            // 入荷日
            row.ArrivalGoodsDay = stockMoveWorkRes.ArrivalGoodsDay.ToString("yyyy/MM/dd");
            // 得意先コード
            row.CustomerCode = stockMoveWorkRes.CustomerCode;
            // 得意先名称１
            row.CustomerName = stockMoveWorkRes.CustomerName;
            // 得意先名称２
            row.CustomerName2 = stockMoveWorkRes.CustomerName2;
            // 在庫区分
            row.StockDiv = stockMoveWorkRes.StockDiv;
            // 仕入単価
            row.StockUnitPriceFl = stockMoveWorkRes.StockUnitPriceFl;
            // 移動金額
            row.MovingPrice = (int)Math.Floor(stockMoveWorkRes.StockUnitPriceFl * stockMoveWorkRes.MoveCount);
            // 課税区分
            row.TaxationDivCd = stockMoveWorkRes.TaxationDivCd;

            // 移動数
            if (row.StockDiv == 0)
            {
                // 移動数（仕：自社）
                row.MovingSupliStock = stockMoveWorkRes.MoveCount;
                row.MovingTrustStock = 0;
            }
            else
            {
                // 移動数（受：受託）
                row.MovingSupliStock = 0;
                row.MovingTrustStock = stockMoveWorkRes.MoveCount;
            }

            // 出庫棚番
            row.BfShelfNo = stockMoveWorkRes.BfShelfNo;
            // 入庫棚番
            row.AfShelfNo = stockMoveWorkRes.AfShelfNo;
            // ＢＬ商品コード
            row.BLGoodsCode = stockMoveWorkRes.BLGoodsCode;
            //// ＢＬ商品コード枝番
            //row.BLGoodsCdDerivedNo = stockMoveWorkRes.BLGoodsCdDerivedNo;
            // ＢＬ商品コード名称
            row.BLGoodsFullName = stockMoveWorkRes.BLGoodsFullName;
            // 定価
            row.ListPriceFl = stockMoveWorkRes.ListPriceFl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// これ以降は製番データからの情報

            //if (stockMoveExpWorkRes != null)
            //{
            //    // 作成日時(在庫移動詳細データ)
            //    row.CreateDateTimeEx = stockMoveExpWorkRes.CreateDateTime;
            //    // 更新日時(在庫移動詳細データ)
            //    row.UpdateDateTimeEx = stockMoveExpWorkRes.UpdateDateTime;
            //    // 企業コード(在庫移動詳細データ)
            //    row.EnterpriseCodeEx = stockMoveExpWorkRes.EnterpriseCode;
            //    // GUID(在庫移動詳細データ)
            //    row.FileHeaderGuidEx = stockMoveExpWorkRes.FileHeaderGuid;
            //    // 更新従業員コード(在庫移動詳細データ)
            //    row.UpdEmployeeCodeEx = stockMoveExpWorkRes.UpdEmployeeCode;
            //    // 更新アセンブリID1(在庫移動詳細データ)
            //    row.UpdAssemblyId1Ex = stockMoveExpWorkRes.UpdAssemblyId1;
            //    // 更新アセンブリID2(在庫移動詳細データ)
            //    row.UpdAssemblyId2Ex = stockMoveExpWorkRes.UpdAssemblyId2;
            //    // 論理削除区分(在庫移動詳細データ)
            //    row.LogicalDeleteCodeEx = stockMoveExpWorkRes.LogicalDeleteCode;

            //    // 在庫移動行詳細番号
            //    row.StockMoveExpNum = stockMoveExpWorkRes.StockMoveExpNum;
            //    // 得意先コード
            //    row.CustomerCode = stockMoveExpWorkRes.CustomerCode;
            //    // 製造番号
            //    row.ProductNumber = stockMoveExpWorkRes.ProductNumber;
            //    // 製番在庫マスタGUID
            //    row.ProductStockGuid = stockMoveExpWorkRes.ProductStockGuid;
            //    // 在庫区分
            //    row.StockDiv = stockMoveExpWorkRes.StockDiv;
            //    // 仕入単価
            //    row.StockUnitPrice = stockMoveExpWorkRes.StockUnitPrice;
            //    // 課税区分
            //    row.TaxationCode = stockMoveExpWorkRes.TaxationCode;
            //    // 商品電話番号1
            //    row.StockTelNo1 = stockMoveExpWorkRes.StockTelNo1;
            //    // 商品電話番号2
            //    row.StockTelNo2 = stockMoveExpWorkRes.StockTelNo2;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 制御項目

            // 在庫移動確定フラグ
            if (row.ShipmentFixDay != "")
            {
                row.FixFlag = true;
            }

            // 在庫移動入荷フラグ
            if (row.ArrivalGoodsDay != "")
            {
                row.ArrivalFlag = true;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// グロスフラグ
            //// どちらかの出荷数が1以上の場合はグロスと扱う
            //if (row.MovingSupliStock > 1 || row.MovingTrustStock > 1)
            //{
            //    row.GrossFlag = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 検索用インデックス
            row.SearchIndexNumber = _stockMoveDataTable.Count + 1;

            // 格納テーブル判別
            if (selectTable == 0)
            {
                _stockMoveDataTable.AddStockMoveRow(row);
            }
            else if (selectTable == 1)
            {
                _stockMoveDataTableEx.AddStockMoveRow(row);
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        # endregion

        # region デリゲートメソッド

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ガイド選択情報グリッド適用処理
        /// </summary>
        /// <param name="stockMoveWorkList"></param>
        /// <param name="stockMoveExpWorkList"></param>
        private void updateGridFromStockMoveSlipGuide(ArrayList stockMoveWorkList, ArrayList stockMoveExpWorkList)
        {
            int status = 0;

            // 親テーブル
            selectTable = 1;

            // グロス詳細データ初期化
            grossMap = new Hashtable();

            // 在庫移動データテーブルをクリア
            _stockMoveDataTableEx.Clear();

            // グロスデータの商品コード格納リスト
            ArrayList GoodsList = new ArrayList();
            // グロスデータの出庫倉庫コード格納リスト
            ArrayList BfEnterWarehouseList = new ArrayList();

            // 拠点コード
            string targetSectionCode = "";

            // 商品検索を行い、移動可能数を取得
            
            // 該当商品コード及び、出庫倉庫コードを取得
            foreach (StockMoveWork stockMoveWork in stockMoveWorkList)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// グロスデータだった場合、その商品コード及び、倉庫コードを取得
                //if (stockMoveWork.MovingSupliStock > 1 || stockMoveWork.MovingTrustStock > 1)
                //{
                //    // 初めての商品コードだった場合
                //    if (this.ArrayListExsists(GoodsList, stockMoveWork.GoodsCode) == false)
                //    {
                //        GoodsList.Add(stockMoveWork.GoodsCode);
                //    }

                //    // 初めての出庫倉庫コードだった場合
                //    if (this.ArrayListExsists(BfEnterWarehouseList, stockMoveWork.BfEnterWarehCode) == false)
                //    {
                //        BfEnterWarehouseList.Add(stockMoveWork.BfEnterWarehCode);
                //    }
                    
                //    targetSectionCode = stockMoveWork.BfSectionCode.Trim();
                //}

                // 初めての商品コードだった場合
                if ( this.ArrayListExsists(GoodsList, stockMoveWork.GoodsNo) == false ) {
                    GoodsList.Add(stockMoveWork.GoodsNo);
                }

                // 初めての出庫倉庫コードだった場合
                if ( this.ArrayListExsists(BfEnterWarehouseList, stockMoveWork.BfEnterWarehCode) == false ) {
                    BfEnterWarehouseList.Add(stockMoveWork.BfEnterWarehCode);
                }

                targetSectionCode = stockMoveWork.BfSectionCode.Trim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 在庫データ取得
            //string retMessage;

            ////List<StockEachWarehouse> retStockEachWarehouse = new List<StockEachWarehouse>();

            //string[] goods      = new string[GoodsList.Count];
            //string[] warehouses = new string[BfEnterWarehouseList.Count];

            //for (int i = 0; i < GoodsList.Count; i++)
            //{
            //    goods[i] = GoodsList[i].ToString();
            //}

            //for (int i = 0; i < BfEnterWarehouseList.Count; i++)
            //{
            //    warehouses[i] = BfEnterWarehouseList[i].ToString();
            //}

            //// 条件を格納
            //StockSearchPara para = new StockSearchPara();
            //para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //para.SectionCode = targetSectionCode;

            //// 在庫状態
            //// 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////int[] stockState = { 0, 10, 30, 70, 80 };
            ////para.StockState = stockState;

            //// 移動状態
            //// 0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
            ////int[] moveStatus = { 0, 1, 2, 3 };
            ////para.MoveStatus = moveStatus;

            //// 商品状態
            //// 0:正常,1:不良品
            ////int[] goodsCodeStatus = { 0, 1 };
            ////para.GoodsCodeStatus = goodsCodeStatus;

            //// ゼロ在庫表示
            //// 0:表示する 1:表示しない
            ////para.ZeroStckDsp = 0;

            //// データ取得区分
            //// 0:全て(在庫+製番在庫) 1:在庫 2:製番在庫
            ////para.DataAcqrDiv = 0;

            //// 製造番号検索区分
            //// 0:全て 1:製番有りのみ 2:製番なしのみ
            ////para.ProductNumberSrchDivCd = 0;

            ////para.GoodsCodes = goods;
            //para.GoodsNos = goods;
            //para.WarehouseCodes = warehouses;
            
            //if (GoodsList.Count != 0 && BfEnterWarehouseList.Count != 0)
            //{

            //    status = _searchStockAcs.SearchStockEachWarehouse(para, out retStockEachWarehouse, out retMessage);
            //}

            //if (status == 0)
            //{
            //    // 移動可能数格納用
            //    Hashtable goodsOkCount = new Hashtable();

            //    // 移動可能数を格納(自社もしくは受託可能数)
            //    foreach (StockEachWarehouse retSearchEachWarehouse in retStockEachWarehouse)
            //    {
            //        double[] OkCount = new double[2];
            //        // 仕入在庫数(仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数 － 引当在庫数)
            //        double SlipShipmentStock = retSearchEachWarehouse.SupplierStock - retSearchEachWarehouse.EntrustCnt - retSearchEachWarehouse.MovingSupliStock - retSearchEachWarehouse.AllowStockCnt;
            //        // 受託在庫数(受託在庫数 － 受託在庫委託数 － 移動中受託在庫数 － 引当在庫数)
            //        double TrustShipmentStock = retSearchEachWarehouse.TrustCount - retSearchEachWarehouse.TrustEntrustCnt - retSearchEachWarehouse.MovingTrustStock - retSearchEachWarehouse.AllowStockCnt;

            //        OkCount[0] = SlipShipmentStock;
            //        OkCount[1] = TrustShipmentStock;

            //        // 商品コード_倉庫コードでキーを生成し、格納する。
            //        if (goodsOkCount.ContainsKey(retSearchEachWarehouse.GoodsCode + "_" + retSearchEachWarehouse.WarehouseCode) == false)
            //        {
            //            goodsOkCount.Add(retSearchEachWarehouse.GoodsCode + "_" + retSearchEachWarehouse.WarehouseCode, OkCount);
            //        }
            //    }

            //    ArrayList retList = new ArrayList();
            //    retList.Add(stockMoveWorkList);
            //    retList.Add(stockMoveExpWorkList);

            //    // データテーブルに格納
            //    this.StockMoveDataTableFromStockMoveWork(retList, goodsOkCount);

            //    bool defWare = false;
            //    string tempBfWarehouse = "";
            //    StockMoveWork tempStockmoveWorkRet = new StockMoveWork();

            //    foreach (StockMoveWork stockMoveWorkRet in stockMoveWorkList)
            //    {
            //        tempStockmoveWorkRet = stockMoveWorkRet;

            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //        //if (stockMoveWorkRet.GoodsCode.Trim() == "")
            //        if ( stockMoveWorkRet.GoodsNo.Trim() == "" )
            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            if (tempBfWarehouse != "" && tempBfWarehouse != stockMoveWorkRet.BfEnterWarehCode)
            //            {
            //                defWare = true;
            //                break;
            //            }
            //            else
            //            {
            //                defWare = false;
            //                tempBfWarehouse = stockMoveWorkRet.BfEnterWarehCode;
            //            }
            //        }
            //    }

            //    // ヘッダ情報へ格納する
            //    _stockMoveHeader.CreateDateTime = tempStockmoveWorkRet.CreateDateTime;
            //    _stockMoveHeader.UpdateDateTime = tempStockmoveWorkRet.UpdateDateTime;
            //    _stockMoveHeader.EnterpriseCode = tempStockmoveWorkRet.EnterpriseCode;
            //    _stockMoveHeader.FileHeaderGuid = tempStockmoveWorkRet.FileHeaderGuid;
            //    _stockMoveHeader.UpdEmployeeCode = tempStockmoveWorkRet.UpdEmployeeCode;
            //    _stockMoveHeader.UpdAssemblyId1 = tempStockmoveWorkRet.UpdAssemblyId1;
            //    _stockMoveHeader.UpdAssemblyId2 = tempStockmoveWorkRet.UpdAssemblyId2;
            //    _stockMoveHeader.LogicalDeleteCode = tempStockmoveWorkRet.LogicalDeleteCode;
            //    _stockMoveHeader.StockMvEmpCode = tempStockmoveWorkRet.StockMvEmpCode;
            //    _stockMoveHeader.StockMvEmpName = tempStockmoveWorkRet.StockMvEmpName;
            //    _stockMoveHeader.ShipmentScdlDay = tempStockmoveWorkRet.ShipmentScdlDay;
            //    _stockMoveHeader.BfSectionCode = tempStockmoveWorkRet.BfSectionCode;
            //    _stockMoveHeader.BfSectionGuideName = tempStockmoveWorkRet.BfSectionGuideNm;
            //    if (defWare == true)
            //    {
            //        _stockMoveHeader.BfEnterWarehCode = "";
            //        _stockMoveHeader.BfEnterWarehName = "";
            //    }
            //    else
            //    {
            //        _stockMoveHeader.BfEnterWarehCode = tempStockmoveWorkRet.BfEnterWarehCode;
            //        _stockMoveHeader.BfEnterWarehName = tempStockmoveWorkRet.BfEnterWarehName;
            //    }                
            //    _stockMoveHeader.AfSectionCode = tempStockmoveWorkRet.AfSectionCode;
            //    _stockMoveHeader.AfSectionGuideName = tempStockmoveWorkRet.AfSectionGuideNm;
            //    _stockMoveHeader.AfEnterWarehCode = tempStockmoveWorkRet.AfEnterWarehCode;
            //    _stockMoveHeader.AfEnterWarehName = tempStockmoveWorkRet.AfEnterWarehName;
            //    _stockMoveHeader.StockMoveSlipNo = tempStockmoveWorkRet.StockMoveSlipNo;
            //    _stockMoveHeader.MoveSlipPrintDiv = true;
            //    _stockMoveHeader.ShipAgentCd = tempStockmoveWorkRet.ShipAgentCd;
            //    _stockMoveHeader.ShipAgentNm = tempStockmoveWorkRet.ShipAgentNm;
            //    _stockMoveHeader.ReceiveAgentCd = tempStockmoveWorkRet.ReceiveAgentCd;
            //    _stockMoveHeader.ReceiveAgentNm = tempStockmoveWorkRet.ReceiveAgentNm;
            //    _stockMoveHeader.ArrivalGoodsDay = tempStockmoveWorkRet.ArrivalGoodsDay;
            //    _stockMoveHeader.OutLine = tempStockmoveWorkRet.Outline;

            //    // フォームを閉じる
            //    this.Close();
            //}

            //..this.Close();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 在庫データ取得
            string retMessage;

            List<StockExpansion> stockExpansionList = new List<StockExpansion>();

            string[] goods = new string[GoodsList.Count];
            string[] warehouses = new string[BfEnterWarehouseList.Count];

            for ( int i = 0; i < GoodsList.Count; i++ ) {
                goods[i] = GoodsList[i].ToString();
            }

            for ( int i = 0; i < BfEnterWarehouseList.Count; i++ ) {
                warehouses[i] = BfEnterWarehouseList[i].ToString();
            }

            // 条件を格納
            StockSearchPara para = new StockSearchPara();
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            para.SectionCode = targetSectionCode;
            para.GoodsNos = goods;
            para.WarehouseCodes = warehouses;

            if ( GoodsList.Count != 0 && BfEnterWarehouseList.Count != 0 ) {
                status = _searchStockAcs.Search( para, out stockExpansionList, out retMessage );
                //status = _searchStockAcs.SearchStockEachWarehouse(para, out retStockEachWarehouse, out retMessage);
            }

            if ( status == 0 ) {
                // 移動可能数格納用
                Hashtable goodsOkCount = new Hashtable();

                // 移動可能数を格納(自社もしくは受託可能数)
                foreach ( StockExpansion stockExpansion in stockExpansionList ) {
                    
                    double[] OkCount = new double[2];
                    // 仕入在庫数(仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数)
                    double SlipShipmentStock = stockExpansion.SupplierStock - stockExpansion.EntrustCnt - stockExpansion.MovingSupliStock;
                    // 受託在庫数(受託在庫数 － 移動中受託在庫数)
                    double TrustShipmentStock = stockExpansion.TrustCount - stockExpansion.MovingTrustStock;

                    OkCount[0] = SlipShipmentStock;
                    OkCount[1] = TrustShipmentStock;

                    // 商品コード_倉庫コードでキーを生成し、格納する。
                    if ( goodsOkCount.ContainsKey(stockExpansion.GoodsNo + "_" + stockExpansion.WarehouseCode) == false ) {
                        goodsOkCount.Add(stockExpansion.GoodsNo + "_" + stockExpansion.WarehouseCode, OkCount);
                    }
                }

                ArrayList retList = new ArrayList();
                retList.Add(stockMoveWorkList);
                //retList.Add(stockMoveExpWorkList);

                // データテーブルに格納
                this.StockMoveDataTableFromStockMoveWork(retList, goodsOkCount);

                bool defWare = false;
                string tempBfWarehouse = "";
                StockMoveWork tempStockmoveWorkRet = new StockMoveWork();

                foreach ( StockMoveWork stockMoveWorkRet in stockMoveWorkList ) {
                    tempStockmoveWorkRet = stockMoveWorkRet;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //if (stockMoveWorkRet.GoodsCode.Trim() == "")
                    if ( stockMoveWorkRet.GoodsNo.Trim() == "" )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    {
                        continue;
                    }
                    else {
                        if ( tempBfWarehouse != "" && tempBfWarehouse != stockMoveWorkRet.BfEnterWarehCode ) {
                            defWare = true;
                            break;
                        }
                        else {
                            defWare = false;
                            tempBfWarehouse = stockMoveWorkRet.BfEnterWarehCode;
                        }
                    }
                }

                // ヘッダ情報へ格納する
                _stockMoveHeader.CreateDateTime = tempStockmoveWorkRet.CreateDateTime;
                _stockMoveHeader.UpdateDateTime = tempStockmoveWorkRet.UpdateDateTime;
                _stockMoveHeader.EnterpriseCode = tempStockmoveWorkRet.EnterpriseCode;
                _stockMoveHeader.FileHeaderGuid = tempStockmoveWorkRet.FileHeaderGuid;
                _stockMoveHeader.UpdEmployeeCode = tempStockmoveWorkRet.UpdEmployeeCode;
                _stockMoveHeader.UpdAssemblyId1 = tempStockmoveWorkRet.UpdAssemblyId1;
                _stockMoveHeader.UpdAssemblyId2 = tempStockmoveWorkRet.UpdAssemblyId2;
                _stockMoveHeader.LogicalDeleteCode = tempStockmoveWorkRet.LogicalDeleteCode;
                _stockMoveHeader.StockMvEmpCode = tempStockmoveWorkRet.StockMvEmpCode;
                _stockMoveHeader.StockMvEmpName = tempStockmoveWorkRet.StockMvEmpName;
                _stockMoveHeader.ShipmentScdlDay = tempStockmoveWorkRet.ShipmentScdlDay;
                _stockMoveHeader.BfSectionCode = tempStockmoveWorkRet.BfSectionCode;
                _stockMoveHeader.BfSectionGuideName = tempStockmoveWorkRet.BfSectionGuideNm;
                if ( defWare == true ) {
                    _stockMoveHeader.BfEnterWarehCode = "";
                    _stockMoveHeader.BfEnterWarehName = "";
                }
                else {
                    _stockMoveHeader.BfEnterWarehCode = tempStockmoveWorkRet.BfEnterWarehCode;
                    _stockMoveHeader.BfEnterWarehName = tempStockmoveWorkRet.BfEnterWarehName;
                }
                _stockMoveHeader.AfSectionCode = tempStockmoveWorkRet.AfSectionCode;
                _stockMoveHeader.AfSectionGuideName = tempStockmoveWorkRet.AfSectionGuideNm;
                _stockMoveHeader.AfEnterWarehCode = tempStockmoveWorkRet.AfEnterWarehCode;
                _stockMoveHeader.AfEnterWarehName = tempStockmoveWorkRet.AfEnterWarehName;
                _stockMoveHeader.StockMoveSlipNo = tempStockmoveWorkRet.StockMoveSlipNo;
                _stockMoveHeader.MoveSlipPrintDiv = true;
                _stockMoveHeader.ShipAgentCd = tempStockmoveWorkRet.ShipAgentCd;
                _stockMoveHeader.ShipAgentNm = tempStockmoveWorkRet.ShipAgentNm;
                _stockMoveHeader.ReceiveAgentCd = tempStockmoveWorkRet.ReceiveAgentCd;
                _stockMoveHeader.ReceiveAgentNm = tempStockmoveWorkRet.ReceiveAgentNm;
                _stockMoveHeader.ArrivalGoodsDay = tempStockmoveWorkRet.ArrivalGoodsDay;
                _stockMoveHeader.OutLine = tempStockmoveWorkRet.Outline;

                // フォームを閉じる
                this.Close();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ガイド選択情報グリッド適用処理
        /// </summary>
        /// <param name="stockMoveWorkList"></param>
        /// <remarks>
        /// <br>Note　　　  : </br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        public void updateGridFromStockMoveSlipGuide(ArrayList stockMoveWorkList)
        {
            // 親テーブル
            selectTable = 1;

            // グロス詳細データ初期化
            grossMap = new Hashtable();

            // 在庫移動データテーブルをクリア
            _stockMoveDataTableEx.Clear();


            //// 在庫データ取得
            //string retMessage;

            //List<Stock> stockList = new List<Stock>();
            //Stock stock = new Stock();

            //// 条件を格納
            //StockSearchPara para = new StockSearchPara();
            //para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //para.SectionCode = stockMoveWork.BfSectionCode;
            //para.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            //para.GoodsNo = "";
            //para.WarehouseCode = stockMoveWork.BfEnterWarehCode;

            //status = _searchStockAcs.Search(para, out stockList, out retMessage);
            //if (status == 0)
            //{
            //    foreach (Stock stockWk in stockList)
            //    {
            //        if (stockWk.GoodsNo.Trim() == stockMoveWork.GoodsNo.Trim())
            //        {
            //            stock = stockWk.Clone();
            //            break;
            //        }
            //    }

            //    // データテーブルに格納
            //    StockMoveDataTableFromStockMoveWork(stockMoveWorkList, stock);

            //    // ヘッダ情報へ格納する
            //    _stockMoveHeader.CreateDateTime = stockMoveWork.CreateDateTime;
            //    _stockMoveHeader.UpdateDateTime = stockMoveWork.UpdateDateTime;
            //    _stockMoveHeader.EnterpriseCode = stockMoveWork.EnterpriseCode;
            //    _stockMoveHeader.FileHeaderGuid = stockMoveWork.FileHeaderGuid;
            //    _stockMoveHeader.UpdEmployeeCode = stockMoveWork.UpdEmployeeCode;
            //    _stockMoveHeader.UpdAssemblyId1 = stockMoveWork.UpdAssemblyId1;
            //    _stockMoveHeader.UpdAssemblyId2 = stockMoveWork.UpdAssemblyId2;
            //    _stockMoveHeader.LogicalDeleteCode = stockMoveWork.LogicalDeleteCode;
            //    _stockMoveHeader.StockMvEmpCode = stockMoveWork.StockMvEmpCode;
            //    _stockMoveHeader.StockMvEmpName = stockMoveWork.StockMvEmpName;
            //    _stockMoveHeader.ShipmentScdlDay = stockMoveWork.ShipmentScdlDay;
            //    _stockMoveHeader.BfSectionCode = stockMoveWork.BfSectionCode;
            //    _stockMoveHeader.BfSectionGuideName = stockMoveWork.BfSectionGuideSnm;
            //    _stockMoveHeader.BfEnterWarehCode = stockMoveWork.BfEnterWarehCode;
            //    _stockMoveHeader.BfEnterWarehName = stockMoveWork.BfEnterWarehName;
            //    _stockMoveHeader.AfSectionCode = stockMoveWork.AfSectionCode;
            //    _stockMoveHeader.AfSectionGuideName = stockMoveWork.AfSectionGuideSnm;
            //    _stockMoveHeader.AfEnterWarehCode = stockMoveWork.AfEnterWarehCode;
            //    _stockMoveHeader.AfEnterWarehName = stockMoveWork.AfEnterWarehName;
            //    _stockMoveHeader.StockMoveSlipNo = stockMoveWork.StockMoveSlipNo;
            //    _stockMoveHeader.MoveSlipPrintDiv = true;
            //    _stockMoveHeader.ShipAgentCd = stockMoveWork.ShipAgentCd;
            //    _stockMoveHeader.ShipAgentNm = stockMoveWork.ShipAgentNm;
            //    _stockMoveHeader.ReceiveAgentCd = stockMoveWork.ReceiveAgentCd;
            //    _stockMoveHeader.ReceiveAgentNm = stockMoveWork.ReceiveAgentNm;
            //    _stockMoveHeader.ArrivalGoodsDay = stockMoveWork.ArrivalGoodsDay;
            //    _stockMoveHeader.OutLine = stockMoveWork.Outline;

            //    // フォームを閉じる
            //    this.Close();
            //}

            // データテーブルに格納
            StockMoveDataTableFromStockMoveWork(stockMoveWorkList);

            StockMoveWork stockMoveWork = (StockMoveWork)stockMoveWorkList[0];

            // ヘッダ情報へ格納する
            _stockMoveHeader.CreateDateTime = stockMoveWork.CreateDateTime;
            _stockMoveHeader.UpdateDateTime = stockMoveWork.UpdateDateTime;
            _stockMoveHeader.EnterpriseCode = stockMoveWork.EnterpriseCode;
            _stockMoveHeader.FileHeaderGuid = stockMoveWork.FileHeaderGuid;
            _stockMoveHeader.UpdEmployeeCode = stockMoveWork.UpdEmployeeCode;
            _stockMoveHeader.UpdAssemblyId1 = stockMoveWork.UpdAssemblyId1;
            _stockMoveHeader.UpdAssemblyId2 = stockMoveWork.UpdAssemblyId2;
            _stockMoveHeader.LogicalDeleteCode = stockMoveWork.LogicalDeleteCode;
            _stockMoveHeader.StockMvEmpCode = stockMoveWork.StockMvEmpCode;
            _stockMoveHeader.StockMvEmpName = stockMoveWork.StockMvEmpName;
            _stockMoveHeader.ShipmentScdlDay = stockMoveWork.ShipmentScdlDay;
            _stockMoveHeader.BfSectionCode = stockMoveWork.BfSectionCode;
            _stockMoveHeader.BfSectionGuideName = stockMoveWork.BfSectionGuideSnm;
            _stockMoveHeader.BfEnterWarehCode = stockMoveWork.BfEnterWarehCode;
            _stockMoveHeader.BfEnterWarehName = stockMoveWork.BfEnterWarehName;
            _stockMoveHeader.AfSectionCode = stockMoveWork.AfSectionCode;
            _stockMoveHeader.AfSectionGuideName = stockMoveWork.AfSectionGuideSnm;
            _stockMoveHeader.AfEnterWarehCode = stockMoveWork.AfEnterWarehCode;
            _stockMoveHeader.AfEnterWarehName = stockMoveWork.AfEnterWarehName;
            _stockMoveHeader.StockMoveSlipNo = stockMoveWork.StockMoveSlipNo;
            _stockMoveHeader.MoveSlipPrintDiv = true;
            _stockMoveHeader.ShipAgentCd = stockMoveWork.ShipAgentCd;
            _stockMoveHeader.ShipAgentNm = stockMoveWork.ShipAgentNm;
            _stockMoveHeader.ReceiveAgentCd = stockMoveWork.ReceiveAgentCd;
            _stockMoveHeader.ReceiveAgentNm = stockMoveWork.ReceiveAgentNm;
            _stockMoveHeader.ArrivalGoodsDay = stockMoveWork.ArrivalGoodsDay;
            _stockMoveHeader.OutLine = stockMoveWork.Outline;

            // フォームを閉じる
            this.Close();
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ガイド選択情報グリッド適用処理
        /// </summary>
        /// <param name="stockMoveWorkList"></param>
        /// <param name="stockMoveExpWorkList"></param>
        /// <remarks>
        /// <br>Note　　　  : </br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void updateGridFromStockMoveSlipGuide(ArrayList stockMoveWorkList, ArrayList stockMoveExpWorkList)
        {
            int status = 0;

            // 親テーブル
            selectTable = 1;

            // グロス詳細データ初期化
            grossMap = new Hashtable();

            // 在庫移動データテーブルをクリア
            _stockMoveDataTableEx.Clear();

            // グロスデータの商品コード格納リスト
            ArrayList GoodsList = new ArrayList();
            // グロスデータの出庫倉庫コード格納リスト
            ArrayList BfEnterWarehouseList = new ArrayList();

            // 拠点コード
            string targetSectionCode = "";

            // 商品検索を行い、移動可能数を取得

            // 該当商品コード及び、出庫倉庫コードを取得
            foreach (StockMoveWork stockMoveWork in stockMoveWorkList)
            {
                // 初めての商品コードだった場合
                if (this.ArrayListExsists(GoodsList, stockMoveWork.GoodsNo) == false)
                {
                    GoodsList.Add(stockMoveWork.GoodsNo);
                }

                // 初めての出庫倉庫コードだった場合
                if (this.ArrayListExsists(BfEnterWarehouseList, stockMoveWork.BfEnterWarehCode) == false)
                {
                    BfEnterWarehouseList.Add(stockMoveWork.BfEnterWarehCode);
                }

                targetSectionCode = stockMoveWork.BfSectionCode.Trim();
            }

            // 在庫データ取得
            string retMessage;

            List<Stock> stockList = new List<Stock>();

            string[] goods = new string[GoodsList.Count];
            string[] warehouses = new string[BfEnterWarehouseList.Count];

            for (int i = 0; i < GoodsList.Count; i++)
            {
                goods[i] = GoodsList[i].ToString();
            }

            for (int i = 0; i < BfEnterWarehouseList.Count; i++)
            {
                warehouses[i] = BfEnterWarehouseList[i].ToString();
            }

            // 条件を格納
            StockSearchPara para = new StockSearchPara();
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            para.SectionCode = targetSectionCode;
            para.GoodsNos = goods;
            para.GoodsNo = goods[0];
            para.WarehouseCodes = warehouses;

            if (GoodsList.Count != 0 && BfEnterWarehouseList.Count != 0)
            {
                status = _searchStockAcs.Search(para, out stockList, out retMessage);
            }

            if (status == 0)
            {
                // 移動可能数格納用
                Hashtable goodsOkCount = new Hashtable();

                // 移動可能数を格納(自社もしくは受託可能数)
                foreach (Stock stockExpansion in stockList)
                {
                    double[] OkCount = new double[2];
                    //// 仕入在庫数(仕入在庫数 － 仕入在庫委託数 － 移動中仕入在庫数)
                    //double SlipShipmentStock = stockExpansion.SupplierStock - stockExpansion.EntrustCnt - stockExpansion.MovingSupliStock;
                    //// 受託在庫数(受託在庫数 － 移動中受託在庫数)
                    //double TrustShipmentStock = stockExpansion.TrustCount - stockExpansion.MovingTrustStock;

                    //OkCount[0] = SlipShipmentStock;
                    //OkCount[1] = TrustShipmentStock;

                    // 商品コード_倉庫コードでキーを生成し、格納する。
                    if (goodsOkCount.ContainsKey(stockExpansion.GoodsNo + "_" + stockExpansion.WarehouseCode) == false)
                    {
                        goodsOkCount.Add(stockExpansion.GoodsNo + "_" + stockExpansion.WarehouseCode, OkCount);
                    }
                }

                ArrayList retList = new ArrayList();
                retList.Add(stockMoveWorkList);

                // データテーブルに格納
                this.StockMoveDataTableFromStockMoveWork(retList, goodsOkCount);

                bool defWare = false;
                string tempBfWarehouse = "";
                StockMoveWork tempStockmoveWorkRet = new StockMoveWork();

                foreach (StockMoveWork stockMoveWorkRet in stockMoveWorkList)
                {
                    tempStockmoveWorkRet = stockMoveWorkRet;

                    if (stockMoveWorkRet.GoodsNo.Trim() == "")
                    {
                        continue;
                    }
                    else
                    {
                        if (tempBfWarehouse != "" && tempBfWarehouse != stockMoveWorkRet.BfEnterWarehCode)
                        {
                            defWare = true;
                            break;
                        }
                        else
                        {
                            defWare = false;
                            tempBfWarehouse = stockMoveWorkRet.BfEnterWarehCode;
                        }
                    }
                }

                // ヘッダ情報へ格納する
                _stockMoveHeader.CreateDateTime = tempStockmoveWorkRet.CreateDateTime;
                _stockMoveHeader.UpdateDateTime = tempStockmoveWorkRet.UpdateDateTime;
                _stockMoveHeader.EnterpriseCode = tempStockmoveWorkRet.EnterpriseCode;
                _stockMoveHeader.FileHeaderGuid = tempStockmoveWorkRet.FileHeaderGuid;
                _stockMoveHeader.UpdEmployeeCode = tempStockmoveWorkRet.UpdEmployeeCode;
                _stockMoveHeader.UpdAssemblyId1 = tempStockmoveWorkRet.UpdAssemblyId1;
                _stockMoveHeader.UpdAssemblyId2 = tempStockmoveWorkRet.UpdAssemblyId2;
                _stockMoveHeader.LogicalDeleteCode = tempStockmoveWorkRet.LogicalDeleteCode;
                _stockMoveHeader.StockMvEmpCode = tempStockmoveWorkRet.StockMvEmpCode;
                _stockMoveHeader.StockMvEmpName = tempStockmoveWorkRet.StockMvEmpName;
                _stockMoveHeader.ShipmentScdlDay = tempStockmoveWorkRet.ShipmentScdlDay;
                _stockMoveHeader.BfSectionCode = tempStockmoveWorkRet.BfSectionCode;
                _stockMoveHeader.BfSectionGuideName = tempStockmoveWorkRet.BfSectionGuideSnm;
                if (defWare == true)
                {
                    _stockMoveHeader.BfEnterWarehCode = "";
                    _stockMoveHeader.BfEnterWarehName = "";
                }
                else
                {
                    _stockMoveHeader.BfEnterWarehCode = tempStockmoveWorkRet.BfEnterWarehCode;
                    _stockMoveHeader.BfEnterWarehName = tempStockmoveWorkRet.BfEnterWarehName;
                }
                _stockMoveHeader.AfSectionCode = tempStockmoveWorkRet.AfSectionCode;
                _stockMoveHeader.AfSectionGuideName = tempStockmoveWorkRet.AfSectionGuideSnm;
                _stockMoveHeader.AfEnterWarehCode = tempStockmoveWorkRet.AfEnterWarehCode;
                _stockMoveHeader.AfEnterWarehName = tempStockmoveWorkRet.AfEnterWarehName;
                _stockMoveHeader.StockMoveSlipNo = tempStockmoveWorkRet.StockMoveSlipNo;
                _stockMoveHeader.MoveSlipPrintDiv = true;
                _stockMoveHeader.ShipAgentCd = tempStockmoveWorkRet.ShipAgentCd;
                _stockMoveHeader.ShipAgentNm = tempStockmoveWorkRet.ShipAgentNm;
                _stockMoveHeader.ReceiveAgentCd = tempStockmoveWorkRet.ReceiveAgentCd;
                _stockMoveHeader.ReceiveAgentNm = tempStockmoveWorkRet.ReceiveAgentNm;
                _stockMoveHeader.ArrivalGoodsDay = tempStockmoveWorkRet.ArrivalGoodsDay;
                _stockMoveHeader.OutLine = tempStockmoveWorkRet.Outline;

                // フォームを閉じる
                this.Close();
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// ArrayList内容存在チェック(商品コード及び出庫倉庫コードArrayListに利用)
        /// </summary>
        /// <param name="targetList">対象となるArrayList</param>
        /// <param name="targetString">対象となる文字列</param>
        /// <returns>true: 存在する false: 存在しない</returns>
        private bool ArrayListExsists(ArrayList targetList, string targetString)
        {
            for (int i = 0; i < targetList.Count; i++)
            {
                if (targetList[i].ToString() == targetString)
                {
                    return true;
                }
            }

            return false;
        }

        # endregion


        # region ガイド系イベント

        /// <summary>
        /// 移動指示担当者ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockMvEmpGuide_uButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;
                int status = employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, LoginInfoAcquisition.Employee.BelongSectionCode, out employee);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.StockMvEmpCode = employee.EmployeeCode;

                    this.StockMvEmpCode_tEdit.Text = employee.EmployeeCode.TrimEnd();
                    this.StockMvEmpName_tEdit.Text = employee.Name;
                    
                    // 次フォーカス
                    this.BfSectionCode_tEdit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 出庫拠点ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BfSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                int status = secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.BfSectionCode = secInfoSet.SectionCode;

                    this.BfSectionCode_tEdit.Text = secInfoSet.SectionCode.TrimEnd();
                    this.BfSectionName_tEdit.Text = secInfoSet.SectionGuideNm;
                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(BfSectionCode_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 入庫拠点ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;
                int status = secInfoSetAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, false, out secInfoSet);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.AfSectionCode = secInfoSet.SectionCode;

                    this.AfSectionCode_tEdit.Text = secInfoSet.SectionCode.TrimEnd();
                    this.AfSectionName_tEdit.Text = secInfoSet.SectionGuideNm;
                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(AfSectionCode_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 出庫倉庫ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BfEnterWarehGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                Warehouse warehouse;

                int status = warehouseAcs.ExecuteGuid(out warehouse, LoginInfoAcquisition.EnterpriseCode, SectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.BfEnterWarehCode = warehouse.WarehouseCode;

                    this.BfEnterWarehCode_tEdit.Text = warehouse.WarehouseCode.Trim();
                    this.BfEnterWarehName_tEdit.Text = warehouse.WarehouseName.Trim();

                    // 次フォーカス
                    _guideNextFocusControl.GetNextControl(BfEnterWarehCode_tEdit).Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 入庫倉庫ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfEnterWarehGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string SectionCode;

                if (this.AfSectionCode_tEdit.Text.Trim() == "")
                {
                    SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }
                else
                {
                    SectionCode = this.AfSectionCode_tEdit.Text;
                }

                Warehouse warehouse;

                int status = warehouseAcs.ExecuteGuid(out warehouse, LoginInfoAcquisition.EnterpriseCode, SectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _stockMoveSlipSearchCond.AfEnterWarehCode = warehouse.WarehouseCode;

                    this.AfEnterWarehCode_tEdit.Text = warehouse.WarehouseCode.Trim();
                    this.AfEnterWarehName_tEdit.Text = warehouse.WarehouseName.Trim();

                    // 次フォーカス
                    this.ShipmentFixDaySt_tDateEdit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        # endregion
    }

    // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
    #region 伝票区分

    /// <summary>
    /// 伝票区分クラス
    /// </summary>
    internal static class SlipDiv
    {
        /// <summary>
        /// 伝票区分値の列挙型「-1:項目非表示、0:出庫伝票、1:入庫伝票」
        /// </summary>
        private enum Value : int
        {
            /// <summary>項目非表示</summary>
            None = -1,
            /// <summary>出庫伝票</summary>
            OutSlip = 0,
            /// <summary>入庫伝票</summary>
            InSlip = 1
        }

        /// <summary>
        /// 伝票区分値を取得します。
        /// </summary>
        /// <remarks>
        /// MAZAI04120UA.cs 1345行目より移植
        /// </remarks>
        /// <param name="stockMoveFormal">在庫移動データ.在庫移動形式</param>
        /// <returns>
        /// 在庫移動形式が｢1：在庫移動｣または｢2：倉庫移動｣のとき、｢0：出庫伝票｣を返します。
        /// それ以外は｢1：入庫伝票｣を返します。
        /// </returns>
        public static int GetNumber(int stockMoveFormal)
        {
            return (stockMoveFormal.Equals(1) || stockMoveFormal.Equals(2)) ? (int)Value.OutSlip : (int)Value.InSlip;
        }

        /// <summary>
        /// 入庫伝票であるか判断します。
        /// </summary>
        /// <param name="slipDiv">伝票区分の値</param>
        /// <returns>
        /// <c>true</c> :入庫伝票です。<br/>
        /// <c>false</c>:入庫伝票ではありません。
        /// </returns>
        public static bool IsInSlip(int slipDiv)
        {
            return slipDiv.Equals((int)Value.InSlip);
        }
    }

    #endregion // 伝票区分
    // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<
}