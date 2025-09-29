using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
// --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
using System.IO;
using Broadleaf.Application.Resources;
// --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>UpDateNote : ガイドの機動モードを指定出来るように修正</br>
    /// <br>             部位ガイドの場合のフォーカスの修正</br>
    /// <br>             モード切り替え時の画面のちらつきを修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009.07.13</br>
    /// <br>UpDateNote : 部位情報表示設定時の画面表示位置修正</br>
    /// <br>Programmer : 980035 金沢 貞義</br>
    /// <br>Date       : 2009.08.01</br>
    /// <br>UpDateNote : 部位選択時に、先頭の部位に該当するBLコードが１つも無い時エラーになる件の修正。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.08.06</br>
    /// <br>UpDateNote : ＢＬコード名をＢＬコード名称(全角)からＢＬコード名称(半角)に変更する。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2010/06/08</br>
    /// <br>
    /// <br>UpDateNote : 売伝からガイド起動時に落ちます</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2010/06/28</br>
    /// <br>
    /// <br>UpDateNote : ①部位選択でＢＬコード選択できません</br>
    /// <br>           : ②ガイドガイドを初期起動設定すると該当データありません。になる</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2010/07/13</br>
    /// <br>Update Note: 2013/01/24 yangmj </br>
    /// <br>           : 10806793-00、Redmine#33919の対応</br>
    /// <br>           : 売上入力と検索見積で部位マスタの設定通りの検索結果にならない</br>
    /// <br>Update Note: 2013/02/06 donggy </br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信</br>
    /// <br>           : Redmine#33919の対応</br>
    /// <br>Update Note: 2016/01/13 田建委</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
    /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
    /// <br>Update Note: 2016/02/03 田建委</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
    /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
    /// <br>Update Note: 2016/02/16 田建委</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : 障害一覧No.252 BLコード選択(部位別)画面で、検索文字削除後に名称絞込欄がフォーカスされない障害の対応</br>
    /// <br>Update Note: 2016/02/17  田建委</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ①名称絞込みの初期入力モードを「半角カナ」にする変更</br>
    /// <br>           : ②アローキー、enter、tabのフォーカス遷移の対応</br>
    /// <br>Update Note: 2016/02/25 脇田靖之</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : 名称絞込みの初期入力モードを「半角カナ」にする</br>
    /// <br>Update Note: 2016/12/26 譚洪</br>
    /// <br>管理番号   : 11270116-00 売上伝票入力パッケージ出荷用ソースのマージ</br>
    /// <br>             Designer.csの修正</br>
    /// <br>Update Note: K2021/04/19 陳艶丹</br>
    /// <br>管理番号   : 11770032-00 PMKOBETSU-4130</br>
    /// <br>             ＢＬＣＤガイドを押すと障害の対応</br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {

        # region 変数定義
        private const string Pure_Search = "純正";
        private const string Prime_Search = "優良";
        private const string CarInfo_Search = "TBO";
        private BlInfo _blInfoTable = null;
        internal BLInfoDataTable _orgBlInfoTable = null;
        private Dictionary<int, BLGoodsCdUMnt> _orgBLList;
        private ArrayList partsPosList;

        /// <summary>対象のみ表示用</summary>
        private string rowFilter1 = string.Empty;
        /// <summary>部位別表示用</summary>
        private string rowFilter2 = string.Empty;
        /// <summary>BLコード名絞込用</summary>
        private string rowFilter3 = string.Empty;
        /// <summary>拠点コード（BLコードガイド表示用）</summary>
        private string _sectionCd;
        /// <summary>得意先コード（BLコードガイド表示用）</summary>
        private int _customerCode;
        private bool flipflopFlg = false;
        private SelectionForm2 frmBLAll = null;

        private List<int> retLstBl = null;

        private Thread prepareThread;

        private SelectionOfrBL.GuideMode _guideMode;
        // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
        // BLコードと部位コード関連用
        private Dictionary<int, string> rowPosDic = new Dictionary<int, string>();
        private Dictionary<int, string> rowPosBlDic = new Dictionary<int, string>();
        private List<string> blCdList = new List<string>();
        // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
        private int time_count;//ADD 2016/02/17 田建委 Redmine#48587

        // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
        private RetrySet RetrySettingInfo = null;
        // リトライ設定XMLファイル
        private const string XmlFileName = "PMKEN08140U_UserSetting.xml";
        // リトライ回数-デフォルト：3回
        private const int CtRetryCount = 3;
        // リトライ間隔-デフォルト：3秒
        private const int CtRetryInterval = 3000;
        // ゼロ
        private const int CtCount = 0;
        // スリープ時間：50ms
        private const int CtSleepMs = 50;
        // クライアントログ出力内容
        private const string ErrorMessage = "PMKEN08140UB SearchPartsPosList 部位データ取得で例外発生、拠点コード:{0}、得意先コード:{1}、ガイド起動モード:{2}、リトライ回数:{3}";
        // 部品別表示エラー内容
        private const string ErrMesShowByPos = "PMKEN08140UB ShowByPos 部位別表示処理で例外発生、拠点コード:{0}、得意先コード:{1}、ガイド起動モード:{2}";
        // 異常メッセージ
        private const string BLGuidErMes = "部位情報の検索中にエラーが発生しました。\r\nしばらく時間を置いて再度検索を行なってください。";
        // PGID
        private const string CtPGID = "PMKEN08140U";
        // ログ出力部品
        OutLogCommon LogCommon;
        // 初回メッセージ表示
        private bool ErrMesFirst = false;
        // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
        # endregion

        #region [ コンストラクタ ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="blTable">グリッドに表示するデータを指定します。</param>
        /// <param name="blList"></param>
        /// <param name="sectionCd"></param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="guideMode">ガイド起動モード</param>
        //public SelectionForm(BLInfoDataTable blTable, Dictionary<int, BLGoodsCdUMnt> blList, string sectionCd, int customerCode)
        public SelectionForm(BLInfoDataTable blTable, Dictionary<int, BLGoodsCdUMnt> blList, string sectionCd, int customerCode, SelectionOfrBL.GuideMode guideMode)
        {
            //>>>2010/07/13
            _sectionCd = sectionCd;
            _customerCode = customerCode;
            _guideMode = guideMode; // 2009/07/13
            //<<<2010/07/13

            //>>>2010/06/28
            _orgBlInfoTable = blTable;
            _orgBLList = blList;
            //<<<2010/06/28

            GetXmlInfo(); // ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応
            _blInfoTable = new BlInfo();
            prepareThread = new Thread(DoPrepare);
            prepareThread.Start();
            InitializeComponent();
            // DataTable の設定
            //>>>2010/06/28
            //_orgBlInfoTable = blTable;
            //_orgBLList = blList;
            //<<<2010/06/28

            //>>>2010/07/13
            //_sectionCd = sectionCd;
            //_customerCode = customerCode;
            //_guideMode = guideMode; // 2009/07/13
            //<<<2010/07/13

            InitializeTable();
            InitializeForm();
            RefreshDataCount();

            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.Opacity = 0;
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion

        #region [ 初期処理 ]
        private void InitializeForm()
        {
            // ステータスバーの初期化
            StatusBar.Panels[0].Text = "";

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_All"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            ToolbarsManager.Tools["Button_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PARTSSELECT;
            ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.LABEL;
            ToolbarsManager.Tools["Button_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            if (_orgBlInfoTable.Count == 0)
            {
                //ToolbarsManager.Tools["Button_All"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Search"].SharedProps.Visible = false;
            }
        }

        private void InitializeTable()
        {
            // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
            while (Monitor.TryEnter(_blInfoTable) == false)
                Thread.Sleep(50);
            // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
            gridBLInfo.BeginUpdate();
            gridBLInfo.DataSource = _blInfoTable.BL.DefaultView;
            gridBLInfo.EndUpdate();

            gridPartsPosInfo.BeginUpdate();
            gridPartsPosInfo.DataSource = _blInfoTable.Pos.DefaultView;
            gridPartsPosInfo.EndUpdate();
            // --- DEL K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
            //while (Monitor.TryEnter(_blInfoTable) == false)
            //    Thread.Sleep(50);
            // --- DEL K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
            if (_orgBlInfoTable.Count > 0)
            {
                rowFilter1 = String.Format("{0}<>''", _blInfoTable.BL.SearchMethodColumn.ColumnName);
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter1;
                ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
            }
            Monitor.Exit(_blInfoTable);
            //ChangeToolColor("Button_Search");
        }

        private void DoPrepare()
        {
            Monitor.Enter(_blInfoTable);
            // --- UPD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
            //PartsPosCodeUAcs partsPosCdAcs = new PartsPosCodeUAcs();
            //partsPosCdAcs.SearchAll(out partsPosList, LoginInfoAcquisition.EnterpriseCode);
            int retryCnt = 0;
            SearchPartsPosList(ref retryCnt);
            // --- UPD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
            InitializeData();
            Monitor.Exit(_blInfoTable);
            frmBLAll = new SelectionForm2(this, _blInfoTable.BL, _sectionCd);
        }

        // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
        /// <summary>
        /// 部位データ取得処理
        /// </summary>
        /// <param name="retryCnt">リトライ回数</param>
        /// <remarks>
        /// <br>Note         : 部位データ取得処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void SearchPartsPosList(ref int retryCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                PartsPosCodeUAcs partsPosCdAcs = new PartsPosCodeUAcs();
                retryCnt++;
                status = partsPosCdAcs.SearchAll(out partsPosList, LoginInfoAcquisition.EnterpriseCode);
                //検索失敗の場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // リトライ処理を行う
                    RetrySearchPartsPosList(ref retryCnt, null);
                }
            }
            catch (Exception ex)
            {
                // リトライ処理を行う
                RetrySearchPartsPosList(ref retryCnt, ex);
            }
        }

        /// <summary>
        /// 部位データ取得リトライ処理
        /// </summary>
        /// <param name="retryCnt">リトライ回数</param>
        /// <param name="ex">例外内容</param> 
        /// <remarks>
        /// <br>Note         : 部位データ取得リトライ処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void RetrySearchPartsPosList(ref int retryCnt, Exception ex)
        {
            // ログ出力
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            string message = string.Format(ErrorMessage, _sectionCd, _customerCode, _guideMode, retryCnt);
            LogCommon.OutputClientLog(CtPGID, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            // リトライ回数まで
            if (retryCnt >= RetrySettingInfo.RetryCount)
            {
                // 処理なし
            }
            else
            {
                System.Threading.Thread.Sleep(RetrySettingInfo.RetryInterval);

                // リトライ処理を行う
                SearchPartsPosList(ref retryCnt);
            }
        }

        /// <summary>
        /// 異常メッセージを表示
        /// </summary>
        /// <param name="ex">例外内容</param> 
        /// <remarks>
        /// <br>Note         : 異常メッセージを表示</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void ExcetionShow(Exception ex)
        {
            //初回ではない
            if (ErrMesFirst)return;

            ErrMesFirst = true;
            // ログ出力
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            string message = string.Format(ErrMesShowByPos, _sectionCd, _customerCode, _guideMode);
            LogCommon.OutputClientLog(CtPGID, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            // メッセージを出力しガイドとして正しく終了
            TMsgDisp.Show(
                        null,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        string.Empty,
                        BLGuidErMes,
                        0,
                        MessageBoxButtons.OK);
            this.Close();
        }

        /// <summary>
        /// XML情報取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : K2021/04/19</br>
        /// </remarks>
        private void GetXmlInfo()
        {
            try
            {
                RetrySettingInfo = new RetrySet();

                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName)))
                {
                    // XMLからリトライ回数とリトライ間隔を取得する
                    RetrySettingInfo = UserSettingController.DeserializeUserSetting<RetrySet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName));
                }
                else
                {
                    // リトライ回数-デフォルト：3回
                    RetrySettingInfo.RetryCount = CtRetryCount;
                    // リトライ間隔-デフォルト：3秒
                    RetrySettingInfo.RetryInterval = CtRetryInterval;
                }
            }
            catch
            {
                if (RetrySettingInfo == null) RetrySettingInfo = new RetrySet();
                // リトライ回数-デフォルト：3回
                RetrySettingInfo.RetryCount = CtRetryCount;
                // リトライ間隔-デフォルト：3秒
                RetrySettingInfo.RetryInterval = CtRetryInterval;
            }
        }
        // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<

        /// <summary>
        /// 表示用データをDataTableに登録するためのサブスレッド
        /// </summary>
        /// <br>Update Note: 2010/06/08 張凱 PM.NS障害・改良対応（７月リリース案件）</br>
        /// <br>             ＢＬコード名をＢＬコード名称(全角)からＢＬコード名称(半角)に変更する。</br>
        private void InitializeData()
        {
            _blInfoTable.BL.BeginLoadData();
            try
            {
                foreach (BLGoodsCdUMnt blGoodsCdUMnt in _orgBLList.Values)
                {
                    BlInfo.BLRow wkRow = wkRow = _blInfoTable.BL.NewBLRow();

                    wkRow.BLCd = blGoodsCdUMnt.BLGoodsCode;
                    // -------UPD 2010/06/08------->>>>>
                    //wkRow.BLName = blGoodsCdUMnt.BLGoodsFullName;
                    wkRow.BLName = blGoodsCdUMnt.BLGoodsHalfName;
                    // -------UPD 2010/06/08-------<<<<<

                    _blInfoTable.BL.AddBLRow(wkRow);
                }

                foreach (PartsPosCodeU partsPosCode in partsPosList)
                {
                    if (partsPosCode.CustomerCode != _customerCode && partsPosCode.CustomerCode != 0) // 指定得意先でないか
                        continue;
                    if (partsPosCode.TbsPartsCode != 0 && // BLコード0は部位名称用なので除外
                        _blInfoTable.BL.FindByBLCd(partsPosCode.TbsPartsCode) != null) // 検索可能な対象BL以外は除外
                    {
                        BlInfo.PartsPosRow partsPosRow = _blInfoTable.PartsPos.NewPartsPosRow();

                        partsPosRow.PosCd = partsPosCode.SearchPartsPosCode;
                        partsPosRow.CustomerCode = partsPosCode.CustomerCode;
                        partsPosRow.BLCd = partsPosCode.TbsPartsCode;
                        partsPosRow.PosDispOrder = partsPosCode.PosDispOrder;

                        _blInfoTable.PartsPos.AddPartsPosRow(partsPosRow);
                    }
                    string pos = partsPosCode.SearchPartsPosCode.ToString("00");
                    if ((partsPosCode.CustomerCode == 0 && _blInfoTable.Pos.FindByPosCd(pos) == null) ||
                        (partsPosCode.CustomerCode != 0 && _blInfoTable.Pos.FindByPosCd("[" + pos + "]") == null))
                    {
                        BlInfo.PosRow posRow = _blInfoTable.Pos.NewPosRow();
                        if (partsPosCode.CustomerCode == 0)
                            posRow.PosCd = pos;
                        else
                            posRow.PosCd = "[" + pos + "]";
                        posRow.PosName = partsPosCode.SearchPartsPosName;
                        _blInfoTable.Pos.AddPosRow(posRow);
                    }
                }
                _blInfoTable.Pos.DefaultView.Sort = _blInfoTable.Pos.PosCdColumn.ColumnName;

                if (_orgBlInfoTable.Count > 0)
                {
                    for (int i = 0; i < _orgBlInfoTable.Count; i++)
                    {
                        BlInfo.BLRow wkRow = _blInfoTable.BL.FindByBLCd(_orgBlInfoTable[i].TbsPartsCode);
                        if (wkRow != null)
                        {
                            int searchFlg = _orgBlInfoTable[i].PrimeSearchFlg;
                            if (_orgBlInfoTable[i].PrimeSearchFlg != 0)
                            {
                                wkRow.SearchMethod = Prime_Search;
                            }
                            else if (_orgBlInfoTable[i].EquipGenreCode != 0)
                            {
                                wkRow.SearchMethod = CarInfo_Search;
                            }
                            else
                            {
                                wkRow.SearchMethod = Pure_Search;
                            }
                        }
                    }
                }
            }
            finally
            {
                _blInfoTable.BL.EndLoadData();
            }
        }
        #endregion

        #region ColInfo　インターナル

        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }

        }


        #endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //gridBLInfo.BeginUpdate();
            //try
            //{
            //    gridBLInfo.DataSource = null;
            //}
            //finally
            //{
            //    gridBLInfo.EndUpdate();
            //}
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// ガイド画面の表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベント</param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>Update Note: 2016/02/03 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
        /// <br>Update Note: 2016/02/17 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①名称絞込みの初期入力モードを「半角カナ」にする。</br>
        /// <br>Update Note: K2021/04/19 陳艶丹</br>
        /// <br>管理番号   : 11770032-00 PMKOBETSU-4130</br>
        /// <br>             ＢＬＣＤガイドを押すと障害の対応</br>
        /// </remarks>
        private void SelectionForm_Shown(object sender, EventArgs e)
        {
            // 先頭行を選択状態にする
            if (gridBLInfo.Rows.Count > 0)
                gridBLInfo.Rows[0].Selected = true;
            this.StartPosition = FormStartPosition.Manual;

            //----- ADD 2016/01/13 田建委 Redmine#48587 ----->>>>>
            // 初期フォーカス：名称絞込に設定し、「曖昧」をチェックオン
            if (_guideMode == SelectionOfrBL.GuideMode.BLCode)
            {
                this.OptionSearch.CheckedIndex = 1;
                //this.txtName.Focus();//DEL 2016/02/17 田建委 Redmine#48587
                this.chkSearch.Checked = true;//ADD 2016/02/03 田建委 Redmine#48587
            }
            //----- ADD 2016/01/13 田建委 Redmine#48587 -----<<<<<

            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>
            if (_guideMode == SelectionOfrBL.GuideMode.PartsPos)
            {
                ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
                // スレッド処理中の場合、スリープ：50ms
                if (prepareThread.ThreadState == ThreadState.Running)
                {
                    while (prepareThread.ThreadState == ThreadState.Running)
                    {
                        Thread.Sleep(CtSleepMs);
                    }
                }
                // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
                //部位ガイド表示
                ShowByPos(true);

                this.Opacity = 1;
            }
            else
                if (_guideMode == SelectionOfrBL.GuideMode.BLGuide)
                {
                    //BLコードガイド表示
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                    flipflopFlg = false;
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(50);
                        }
                    }

                    this.Opacity = 0;

                    RetType result;
                    DialogResult ret = frmBLAll.ShowDialog(out retLstBl, out result, true);
                    switch (result)
                    {
                        case RetType.ShowPos:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                            this.Opacity = 1;
                            break;
                        case RetType.ShowSearch:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false; // ADD 2016/01/13 田建委 Redmine#48587
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                            this.Opacity = 1;
                            break;
                        case RetType.OK:
                            DialogResult = DialogResult.OK;
                            break;
                        case RetType.Cancel:
                            DialogResult = DialogResult.Cancel;
                            break;
                    }

                }
                else
                {
                    this.Opacity = 1;
                }
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// アローキー、enter、tabのフォーカス遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17  田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ②アローキー、enter、tabのフォーカス遷移の対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == txtName)
            {
                if (gridPartsPosInfo.Visible)
                    gridPartsPosInfo.Select();
                else
                    gridBLInfo.Select();
            }
            //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
            switch (e.Key)
            {
                case Keys.Enter:
                case Keys.Tab:
                    //SHIFT押下しない
                    if (!e.ShiftKey)
                    {
                        //検索条件　前方・曖昧⇒グリッド
                        if (e.PrevCtrl == OptionSearch)
                        {
                            if (gridPartsPosInfo.Visible)
                            {
                                e.NextCtrl = gridPartsPosInfo;
                            }
                            else
                            {
                                e.NextCtrl = gridBLInfo;
                            }
                        }
                    }
                    else
                    {
                        //検索条件　前方・曖昧⇒自動検索
                        if (e.PrevCtrl == OptionSearch)
                        {
                            e.NextCtrl = this.chkSearch;
                        }
                        //BL部位別
                        if (gridPartsPosInfo.Visible)
                        {
                            if (e.PrevCtrl == txtName)
                            {
                                e.NextCtrl = this.gridBLInfo;
                            }
                        }
                    }
                    break;
                case Keys.Down:
                    //BL部位別
                    if (gridPartsPosInfo.Visible)
                    {
                        //自動検索、検索条件　前方・曖昧 ⇒BLコードグリッド
                        if (e.PrevCtrl == chkSearch || e.PrevCtrl == OptionSearch)
                        {
                            e.NextCtrl = gridBLInfo;
                        }
                    }
                    break;
            }
            //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
        }
        #endregion

        internal DialogResult ShowDialog(out List<int> lstBlCd)
        {
            lstBlCd = null;
            DialogResult ret = base.ShowDialog();
            if (ret == DialogResult.OK)
            {
                //>>>2010/07/13
                //if (retLstBl != null) // PMKEN08140UCでBLリストが決まったらそれを返す。
                if ((retLstBl != null) && (retLstBl.Count != 0)) // PMKEN08140UCでBLリストが決まったらそれを返す。
                //<<<2010/07/13
                {
                    lstBlCd = retLstBl;
                }
                else
                {
                    lstBlCd = new List<int>();
                    //-----ADD yangmj 2013/01/24 for redmine#33919 ----->>>>>
                    bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
                    // 部位以外の場合、既存処理を保持
                    if (!chk)
                    {
                    //-----ADD yangmj 2013/01/24 for redmine#33919 -----<<<<<
                        for (int i = 0; i < _blInfoTable.BL.Count; i++)
                        {
                            if (_blInfoTable.BL[i].SelectionState)
                            {
                                lstBlCd.Add(_blInfoTable.BL[i].BLCd);
                            }
                        }
                    //-----ADD yangmj 2013/01/24 for redmine#33919 ----->>>>>
                    }
                    else
                    {
                        // --- DEL donggy 2013/02/06 for Redmine#33919 --->>>>>>
                        // 部位の場合、画面表示順で、戻り値を設定する
                        //for (int i = 0; i < _blInfoTable.Pos.DefaultView.Count; i++)
                        //{
                        //    //部位より、ｂLコードのfilter
                        //    string tmpFilter;
                        //    string pos = gridPartsPosInfo.Rows[i].Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
                        // --- DEL donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                        //　部位コードとＢＬコードの選択処理
                        if (!splitContainer1.Panel1Collapsed)// 部位コード表示の場合
                        {
                            Dictionary<int, string>.KeyCollection keys = rowPosDic.Keys;
                            Dictionary<int, string>.KeyCollection keysBL = rowPosBlDic.Keys;
                            int[] keyArray = new int[keys.Count];
                            int[] keyBLArray = new int[keysBL.Count];
                            keys.CopyTo(keyArray, 0);
                            keysBL.CopyTo(keyBLArray, 0);
                            List<int> keyList = new List<int>();
                            //直接選択した部位コードの行番号の取得
                            for (int i = 0; i < keyArray.Length; i++)
                            {
                                keyList.Add(keyArray[i]);
                            }
                            //選択したＢＬコードによって、選択した部位コードの行番号の取得
                            for (int i = 0; i < keyBLArray.Length; i++)
                            {
                                if (!keyList.Contains(keyBLArray[i]))
                                {
                                    keyList.Add(keyBLArray[i]);
                                }
                            }
                            keyList.Sort();
                            //選択した部位コードによって、ＢＬコードを取得する
                            for (int i = 0; i < keyList.Count; i++)
                            {
                                string tmpFilter;
                                string pos = string.Empty;
                                //部位コードの取得
                                if (rowPosDic.ContainsKey(keyList[i]))
                                {
                                    pos = rowPosDic[keyList[i]].ToString();
                                }
                                else if (rowPosBlDic.ContainsKey(keyList[i]))
                                {
                                    pos = rowPosBlDic[keyList[i]].ToString();
                                }
                                else
                                {
                                    break;
                                }
                          // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                                if (pos.StartsWith("["))
                                {
                                    pos = pos.Substring(1, pos.Length - 2);
                                    tmpFilter = String.Format("{0} = {1} AND {2} <> 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                                    _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
                                }
                                else
                                {
                                    tmpFilter = String.Format("{0} = {1} AND {2} = 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                                    _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
                                }
                                _blInfoTable.PartsPos.DefaultView.RowFilter = tmpFilter;
                                rowFilter2 = "(";
                                for (int j = 0; j < _blInfoTable.PartsPos.DefaultView.Count; j++)
                                {
                                    BlInfo.PartsPosRow row = (BlInfo.PartsPosRow)_blInfoTable.PartsPos.DefaultView[j].Row;
                                    rowFilter2 += string.Format("{0} = {1} OR ", _blInfoTable.BL.BLCdColumn.ColumnName, row.BLCd);
                                    _blInfoTable.BL.FindByBLCd(row.BLCd).PosDispOrder = row.PosDispOrder;
                                }
                                rowFilter2 = rowFilter2.Remove(rowFilter2.Length - 4) + ")";

                                string rowFilter;
                                if (rowFilter1.Equals(string.Empty))
                                {
                                    rowFilter = rowFilter2;
                                }
                                else
                                {
                                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                                }

                                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                                _blInfoTable.BL.DefaultView.Sort = _blInfoTable.BL.PosDispOrderColumn.ColumnName;
                                //選択されたBLコードを戻り値を設定する
                                for (int n = 0; n < gridBLInfo.Rows.Count; n++)
                                {
                                    if ((bool)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value)
                                    {
                                        int blCd = (int)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value;
                                        if (!lstBlCd.Contains(blCd))
                                        {
                                            lstBlCd.Add(blCd);
                                        }
                                    }
                                }

                                rowFilter2 = string.Empty;
                            }
                        }
                        //-----ADD donggy 2013/02/06 for redmine#33919 ----->>>>>
                        // 部位コード表示しない場合
                        else
                        {
                            //選択されたBLコードを戻り値を設定する
                            for (int n = 0; n < gridBLInfo.Rows.Count; n++)
                            {
                                if ((bool)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value)
                                {
                                    int blCd = (int)gridBLInfo.Rows[n].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value;
                                    if (!lstBlCd.Contains(blCd))
                                    {
                                        lstBlCd.Add(blCd);
                                    }
                                }
                            }

                            rowFilter2 = string.Empty;
                        }
                        //-----ADD donggy 2013/02/06 for redmine#33919 -----<<<<<

                    }
                    //-----ADD yangmj 2013/01/24 for redmine#33919 -----<<<<<
                }
            }
            return ret;
        }

        #region [ ツールバーイベント処理 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : 画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>Update Note: K2021/04/19 陳艶丹</br>
        /// <br>管理番号   : 11770032-00 PMKOBETSU-4130</br>
        /// <br>             ＢＬＣＤガイドを押すと障害の対応</br>
        /// </remarks>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (flipflopFlg)
                return;
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            switch (e.Tool.Key)
            {
                case "Button_Select": // 選択されている行を確定する
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back": // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_All": // 全表示
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = false;
                    flipflopFlg = false;
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(50);
                        }
                    }
                    if (frmBLAll == null) // 正常的な状態ではありえないケースだが、念のため入れておく。
                    {
                        frmBLAll = new SelectionForm2(this, _blInfoTable.BL, _sectionCd);
                    }
                    // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                    //this.Visible = false;
                    this.Opacity = 0;
                    // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    RetType result;
                    DialogResult ret = frmBLAll.ShowDialog(out retLstBl, out result, false);
                    switch (result)
                    {
                        case RetType.ShowPos:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        case RetType.ShowSearch:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false; // ADD 2016/01/13 田建委 Redmine#48587
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        case RetType.OK:
                            DialogResult = DialogResult.OK;
                            break;
                        case RetType.Cancel:
                            DialogResult = DialogResult.Cancel;
                            break;
                    }
                    break;

                case "Button_Search": // 検索可能対象のみ表示
                    ShowBySearch(chk);
                    break;

                case "Button_Pos": // 部位別表示処理
                    // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
                    // スレッド処理中の場合、スリープ：50ms
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(CtSleepMs);
                        }
                    }
                    // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
                    ShowByPos(chk);
                    break;

                case "Button_Guide": // BLコードガイド表示
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                    flipflopFlg = false;
                    if (prepareThread.ThreadState == ThreadState.Running)
                    {
                        while (prepareThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(50);
                        }
                    }

                    // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //this.Visible = false;
                    this.Opacity = 0;
                    // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    ret = frmBLAll.ShowDialog(out retLstBl, out result, true);
                    switch (result)
                    {
                        case RetType.ShowPos:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<< 
                            break;
                        case RetType.ShowSearch:
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false; // ADD 2016/01/13 田建委 Redmine#48587
                            ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>> 
                            //this.Visible = true;
                            this.Opacity = 1;
                            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<
                            break;
                        case RetType.OK:
                            DialogResult = DialogResult.OK;
                            break;
                        case RetType.Cancel:
                            DialogResult = DialogResult.Cancel;
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// 検索可能対象のみ表示
        /// </summary>
        /// <param name="chk"></param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>Update Note: 2016/02/03 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
        /// </remarks>
        private void ShowBySearch(bool chk)
        {
            string rowFilter;
            if (((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked)
            {
                rowFilter1 = String.Format("{0}<>''", _blInfoTable.BL.SearchMethodColumn.ColumnName);
                if (rowFilter2.Equals(string.Empty))
                    rowFilter = rowFilter1;
                else
                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                flipflopFlg = true;
                ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = false;
                flipflopFlg = false;
                if (chk == false)
                {
                    if (gridBLInfo.Rows.Count > 0)
                    {
                        gridBLInfo.Rows[0].Activate();
                        if (gridBLInfo.Selected.Rows.Count > 0)
                        {
                            gridBLInfo.Select();
                            gridBLInfo.Selected.Rows[0].Activate();
                        }
                    }
                }
                SetSplitter(chk);
            }
            else
            {
                flipflopFlg = true;
                ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = true;
                flipflopFlg = false;
            }
            RefreshDataCount();

            //----- ADD 2016/01/13 田建委 Redmine#48587 ----->>>>>
            // 初期フォーカス：名称絞込に設定し、「曖昧」をチェックオン
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 田建委 Redmine#48587
            //----- ADD 2016/01/13 田建委 Redmine#48587 -----<<<<<
        }

        /// <summary>
        /// 部位別表示処理
        /// </summary>
        /// <param name="chk"></param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>Update Note: 2016/02/03 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
        /// <br>Update Note: K2021/04/19 陳艶丹</br>
        /// <br>管理番号   : 11770032-00 PMKOBETSU-4130</br>
        /// <br>             ＢＬＣＤガイドを押すと障害の対応</br>
        /// </remarks>
        private void ShowByPos(bool chk)
        {
            // --- UPD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
            //string rowFilter;
            string rowFilter = string.Empty;
            // --- UPD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
            //int blCode = 0;

            txtName.Clear();
            BLFiltering();
            //if (gridBLInfo.Selected.Rows.Count > 0)
            //{
            //    blCode = int.Parse(gridBLInfo.Selected.Rows[0].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
            //}
            //else
            //{
            //    return;
            //}
            SetSplitter(chk);
            // --- UPD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
            //if (chk)    // 部位表示
            //{
            //    GridPosFiltering();

            //    if (rowFilter1.Equals(string.Empty))
            //        rowFilter = rowFilter2;
            //    else
            //        rowFilter = rowFilter1 + " AND " + rowFilter2;
            //}
            //else        // 部位非表示
            //{
            //    rowFilter2 = string.Empty;
            //    rowFilter = rowFilter1;
            //}

            if (gridPartsPosInfo.Selected.Rows.Count == CtCount && chk)
            {
                ExcetionShow(null);
                return;
            }

            try
            {
                if (chk)
                {
                    GridPosFiltering();

                    if (rowFilter1.Equals(string.Empty))
                        rowFilter = rowFilter2;
                    else
                        rowFilter = rowFilter1 + " AND " + rowFilter2;
                }
                else        // 部位非表示
                {
                    rowFilter2 = string.Empty;
                    rowFilter = rowFilter1;
                }

            }
            catch(Exception ex)
            {
                ExcetionShow(ex);
                return;
            }
            // --- UPD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
            _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
            if (chk)
            {
                _blInfoTable.BL.DefaultView.Sort = _blInfoTable.BL.PosDispOrderColumn.ColumnName;
                //gridPartsPosInfo.Rows[0].Activate();
                //gridPartsPosInfo.Rows[0].Selected = true;

                //int posCd = _blInfoTable.BL.FindByBLCd(blCode).PosCd;
                ////_blInfoTable.PartsPos.FindByPosCd(posCd);

                //for (int i = 0; i < gridPartsPosInfo.Rows.Count; i++)
                //{
                //    if (gridPartsPosInfo.Rows[i].Cells[_blInfoTable.PartsPos.PosCdColumn.ColumnName].Value.Equals(posCd))
                //    {
                //        gridPartsPosInfo.Rows[i].Selected = true;
                //        gridPartsPosInfo.Rows[i].Activate();
                //        break;
                //    }
                //}
                //for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                //{
                //    if (gridBLInfo.Rows[i].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.Equals(blCode))
                //    {
                //        gridBLInfo.Rows[i].Selected = true;
                //        gridBLInfo.Rows[i].Activate();
                //        break;
                //    }
                //}
                ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT2;
            }
            else
            {
                _blInfoTable.BL.DefaultView.Sort = string.Empty;
                //for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                //{
                //    if (gridBLInfo.Rows[i].Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.Equals(blCode))
                //    {
                //        gridBLInfo.Select();
                //        gridBLInfo.Rows[i].Selected = true;
                //        gridBLInfo.Rows[i].Activate();
                //        break;
                //    }
                //}
                ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE2;
                
                gridBLInfo.Focus(); //2009/07/13
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.06 DEL
            //gridBLInfo.Rows[0].Activate();
            //gridBLInfo.Rows[0].Selected = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.06 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.06 ADD
            // 該当行が無ければフォーカスセットしない。
            if ( gridBLInfo.Rows.Count > 0 )
            {
                gridBLInfo.Rows[0].Activate();
                gridBLInfo.Rows[0].Selected = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.06 ADD

            //----- ADD 2016/01/13 田建委 Redmine#48587 ----->>>>>
            // 初期フォーカス：名称絞込に設定し、「曖昧」をチェックオン
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 田建委 Redmine#48587
            //----- ADD 2016/01/13 田建委 Redmine#48587 -----<<<<<

            RefreshDataCount();
        }

        /// <summary>
        /// 部位グリッドフィルタリング処理
        /// </summary>
        private void GridPosFiltering()
        {
            string tmpFilter;
            string pos = gridPartsPosInfo.Selected.Rows[0].Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
            if (pos.StartsWith("["))
            {
                pos = pos.Substring(1, pos.Length - 2);
                tmpFilter = String.Format("{0} = {1} AND {2} <> 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
            }
            else
            {
                tmpFilter = String.Format("{0} = {1} AND {2} = 0", _blInfoTable.PartsPos.PosCdColumn.ColumnName, pos,
                                _blInfoTable.PartsPos.CustomerCodeColumn.ColumnName);
            }
            _blInfoTable.PartsPos.DefaultView.RowFilter = tmpFilter;
            rowFilter2 = "(";
            for (int i = 0; i < _blInfoTable.PartsPos.DefaultView.Count; i++)
            {
                BlInfo.PartsPosRow row = (BlInfo.PartsPosRow)_blInfoTable.PartsPos.DefaultView[i].Row;
                rowFilter2 += string.Format("{0} = {1} OR ", _blInfoTable.BL.BLCdColumn.ColumnName, row.BLCd);
                _blInfoTable.BL.FindByBLCd(row.BLCd).PosDispOrder = row.PosDispOrder;
            }
            rowFilter2 = rowFilter2.Remove(rowFilter2.Length - 4) + ")";
        }

        /// <summary>
        /// 部位情報表示設定
        /// </summary>
        /// <param name="flg">true:表示／false:非表示</param>
        /// <br>Update Note: 2016/02/16 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : 障害一覧No.252 BLコード選択(部位別)画面で、検索文字削除後に名称絞込欄がフォーカスされない障害の対応</br>
        private void SetSplitter(bool flg)
        {
            splitContainer1.Panel1Collapsed = !flg;
            if (flg)
            {
                if (this.Width < 960)
                {
                    // 2009/08/01 >>>>>>>>>>>>>>>>>>>>>> 
                    //this.Left -= 300;
                    //this.Width = 960;
                    //if (this.Left < 200)
                    //    this.Left = 200;
                    //if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width - 200)
                    //{
                    //    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 200;
                    //}
                    this.Left -= 150;
                    this.Width = 960;
                    if (this.Left < 0)
                        this.Left = 0;
                    if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width)
                    {
                        this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
                    }
                    // 2009/08/01 <<<<<<<<<<<<<<<<<<<<<<
                }
                if (gridPartsPosInfo.Selected.Rows.Count == 0 && gridPartsPosInfo.Rows.Count > 0)
                {
                    //gridPartsPosInfo.Select();//DEL 2016/02/16 田建委 Redmine#48587
                    gridPartsPosInfo.Rows[0].Activate();
                    gridPartsPosInfo.Rows[0].Selected = true;
                }
            }
            else
            {
                bool prevWidth = false;
                // 2009/08/01 >>>>>>>>>>>>>>>>>>>>>> 
                //if (this.Width > 660)
                //    prevWidth = true;
                //this.Width = 660;
                //if (prevWidth)
                //    this.Left += 300;
                //if (this.Left < 200)
                //    this.Left = 200;
                //if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width - 200)
                //{
                //    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 200;
                //}
                if (this.Width > 660)
                    prevWidth = true;
                this.Width = 660;
                if (prevWidth)
                    this.Left += 150;
                if (this.Left < 0)
                    this.Left = 0;
                if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width)
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
                }
                // 2009/08/01 <<<<<<<<<<<<<<<<<<<<<<
                gridPartsPosInfo.Selected.Rows.Clear();
            }

        }
        #endregion

        #region [ グリッドイベント処理 ]
        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void gridBLInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            #region グリッドのレイアウト初期化
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // バンドの取得
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // 水平表示位置
                if (Band.Columns[Index].DataType == typeof(int) || Band.Columns[Index].DataType == typeof(double))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // 垂直表示位置
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_blInfoTable.BL.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            Band.Columns[_blInfoTable.BL.PosDispOrderColumn.ColumnName].Hidden = true;
            Band.Columns[_blInfoTable.BL.SelectionStateColumn.ColumnName].Hidden = true;
            Band.Columns[_blInfoTable.BL.BLCdColumn.ColumnName].Format = "00000";

            ColInfo.SetColInfo(Band, _blInfoTable.BL.SelImageColumn.ColumnName, 2, 0, 20);
            ColInfo.SetColInfo(Band, _blInfoTable.BL.BLCdColumn.ColumnName, 3, 0, 50);
            ColInfo.SetColInfo(Band, _blInfoTable.BL.BLNameColumn.ColumnName, 5, 0, 250);
            if (_orgBlInfoTable.Count == 0)
            {
                Band.Columns[_blInfoTable.BL.SearchMethodColumn.ColumnName].Hidden = true;
            }
            else
            {
                ColInfo.SetColInfo(Band, _blInfoTable.BL.SearchMethodColumn.ColumnName, 8, 0, 50);
            }

            #endregion
        }

        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridBLInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (gridBLInfo.Selected.Rows.Count > 0)
            {
                gridBLInfo.Selected.Rows[0].Activate();
            }
            RefreshDataCount();
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信</br>
        /// <br>             Redmine#33919対応</br>
        /// <br>Update Note: 2016/02/17 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ②アローキー、enter、tabのフォーカス遷移の対応</br>>
        private void gridBLInfo_KeyDown(object sender, KeyEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // 部位別
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (e.KeyCode == Keys.Enter)
            {
                //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
                //SHIFT押下しない
                if (!e.Shift)
                {
                    //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
                    if (gridBLInfo.ActiveRow != null)
                    {
                        if (gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            // BLコードを選択された部位コードの行番号の削除
                            if (chk)
                            {
                                if (blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                                {
                                    blCdList.Remove(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                                }
                                if (blCdList.Count == 0)
                                {
                                    rowPosBlDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        }
                        else
                        {
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            // BLコードを選択された部位コードの行番号の追加
                            if (chk)
                            {
                                string posCd = gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
                                if (!rowPosBlDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                                {
                                    rowPosBlDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, posCd);
                                }
                                if (!blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                                {
                                    blCdList.Add(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        }
                        UltraGridRow ugr = this.gridBLInfo.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridBLInfo.UpdateData();
                    }
                //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
                }
                //SHIFT押下する
                else
                {
                    if (gridBLInfo.ActiveRow != null)
                    {
                        UltraGridRow ugr = this.gridBLInfo.ActiveRow.GetSibling(SiblingRow.Previous);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridBLInfo.UpdateData();
                    }
                }
                //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
            }
            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>
            //部位ガイドモードの場合に←を押された場合は部位グリッドに移動
            else if (e.KeyCode == Keys.Left)
            {
                if (((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked == true)
                {
                    gridPartsPosInfo.Focus();
                    e.Handled = true;   //KeyDownイベントを回避
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked == true)
                {
                    e.Handled = true;   //KeyDownイベントを回避
                }
            }
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<
            //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
            //グリッドの一行目↑キーを押下された場合は名称絞込みに移動
            if (e.KeyCode == Keys.Up)
            {
                if (gridBLInfo.Rows.Count > 0 && gridBLInfo.ActiveRow != null)
                {
                    if (gridBLInfo.ActiveRow.VisibleIndex == 0)
                    {
                        this.txtName.Focus();
                    }
                }
            }
            //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信</br>
        /// <br>             Redmine#33919対応</br>
        private void gridBLInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            //部位別
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (gridBLInfo.ActiveRow != null)
            {
                if (gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    // BLコードを選択された部位コードの行番号の削除
                    if (chk)
                    {
                        if (blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                        {
                            blCdList.Remove(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                        }
                        if (blCdList.Count == 0)
                        {
                            rowPosBlDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                }
                else
                {
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    // BLコードを選択された部位コードの行番号の追加
                    if (chk)
                    {
                        string posCd = gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString();
                        if (!rowPosBlDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                        {
                            rowPosBlDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, posCd);
                        }
                        if (!blCdList.Contains(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString()))
                        {
                            blCdList.Add(gridBLInfo.ActiveRow.Cells[_blInfoTable.BL.BLCdColumn.ColumnName].Value.ToString());
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<

                }
                gridBLInfo.UpdateData();
            }
        }

        private void gridPartsPosInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // バンドの取得
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Hidden = true;
            ColInfo.SetColInfo(Band, _blInfoTable.Pos.SelImageColumn.ColumnName, 2, 0, 20);
            ColInfo.SetColInfo(Band, _blInfoTable.Pos.PosCdColumn.ColumnName, 4, 0, 30);
            ColInfo.SetColInfo(Band, _blInfoTable.Pos.PosNameColumn.ColumnName, 7, 0, 160);
            Band.Columns[_blInfoTable.Pos.PosCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Band.Columns[_blInfoTable.Pos.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
        }

        private void gridPartsPosInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // 部位別
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            blCdList = new List<string>();
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<
            string rowFilter;
            if (gridPartsPosInfo.Selected.Rows.Count > 0)
            {
                gridPartsPosInfo.Selected.Rows[0].Activate();

                GridPosFiltering();

                if (rowFilter1.Equals(string.Empty))
                    rowFilter = rowFilter2;
                else
                    rowFilter = rowFilter1 + " AND " + rowFilter2;
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                if (gridBLInfo.Rows.Count > 0)
                {
                    gridBLInfo.Rows[0].Activate();
                    gridBLInfo.Rows[0].Selected = true;
                }
            }

        }
        private void gridPartsPosInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // 部位別
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (gridPartsPosInfo.ActiveRow != null)
            {
                if (gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = DBNull.Value;
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = false;
                    for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                    {
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    //選択解除の部位コードの行番号の削除
                    if (chk)
                    {
                        if (rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                        {
                            rowPosDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                }
                else
                {
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = true;
                    for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                    {
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK]; ;
                        gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                    //選択部位コードの行番号の追加
                    if (chk)
                    {
                        if (!rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                        {
                            rowPosDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString());
                        }
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                }
                gridPartsPosInfo.UpdateData();
                gridBLInfo.UpdateData();
            }
        }

        /// <summary>
        /// 「部品別」モードでグリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ②アローキー、enter、tabのフォーカス遷移の対応</br>
        /// </remarks>
        private void gridPartsPosInfo_KeyDown(object sender, KeyEventArgs e)
        {
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // 部位別
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
            if (e.KeyCode == Keys.Enter)
            {
                //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
                //SHIFT押下しない
                if (!e.Shift)
                {
                    //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
                    if (gridPartsPosInfo.ActiveRow != null)
                    {
                        if (gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value != DBNull.Value)
                        {
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = DBNull.Value;
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = false;
                            for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                            {
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = DBNull.Value;
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = false;
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            //選択解除の部位コードの行番号の削除
                            if (chk)
                            {
                                if (rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                                {
                                    rowPosDic.Remove(gridPartsPosInfo.ActiveRow.RowSelectorNumber);
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<<
                        }
                        else
                        {
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.SelectionStateColumn.ColumnName].Value = true;
                            for (int i = 0; i < gridBLInfo.Rows.Count; i++)
                            {
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK]; ;
                                gridBLInfo.Rows[i].Cells[_blInfoTable.BL.SelectionStateColumn.ColumnName].Value = true;
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
                            // 選択部位コーダの行番号の追加
                            if (chk)
                            {
                                if (!rowPosDic.ContainsKey(gridPartsPosInfo.ActiveRow.RowSelectorNumber))
                                {
                                    rowPosDic.Add(gridPartsPosInfo.ActiveRow.RowSelectorNumber, gridPartsPosInfo.ActiveRow.Cells[_blInfoTable.Pos.PosCdColumn.ColumnName].Value.ToString());
                                }
                            }
                            // --- ADD donggy 2013/02/06 for Redmine#33919 ---<<<<<
                        }
                        UltraGridRow ugr = gridPartsPosInfo.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridPartsPosInfo.UpdateData();
                        gridBLInfo.UpdateData();
                    }
                //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
                }
                //SHIFT押下する
                else
                {
                    if (gridPartsPosInfo.ActiveRow != null)
                    {
                        UltraGridRow ugr = gridPartsPosInfo.ActiveRow.GetSibling(SiblingRow.Previous);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        gridPartsPosInfo.UpdateData();
                        gridBLInfo.UpdateData();
                    }
                }
                //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
            }
            // 2009/07/13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //部位コードグリッドで→を押された場合はBLコードグリッドに移動
            else if (e.KeyCode == Keys.Right)
            {
                if (gridBLInfo.Rows.Count != 0)
                {
                    gridBLInfo.Focus();
                }

                e.Handled = true;   //KeyDownイベントを回避
            }
            else if (e.KeyCode == Keys.Left)
            {
                e.Handled = true;   //KeyDownイベントを回避
            }
            // 2009/07/13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
            //グリッドの一行目↑キーを押下された場合は名称絞込みに移動
            else if ((e.KeyCode == Keys.Up))
            {
                if (gridPartsPosInfo.Rows.Count > 0 && gridPartsPosInfo.ActiveRow != null)
                {
                    if (gridPartsPosInfo.ActiveRow.VisibleIndex == 0)
                    {
                        this.txtName.Focus();
                    }
                }
            }
            //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
        }
        #endregion

        #region [ フィルタリング ]
        private void txtName_ValueChanged(object sender, EventArgs e)
        {
            if (chkSearch.Checked && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (chkSearch.Checked == false && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void OptionSearch_ValueChanged(object sender, EventArgs e)
        {
            BLFiltering();
        }

        private void BLFiltering()
        {
            if (((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked == false)
            {
                string rowFilter;
                if (txtName.Text != string.Empty)
                {
                    if (OptionSearch.Value.Equals(true)) // 曖昧検索
                        rowFilter3 = string.Format("{0} like '%{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                    else // 前方一致検索
                        rowFilter3 = string.Format("{0} like '{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                }
                else
                {
                    rowFilter3 = string.Empty;
                }
                rowFilter = rowFilter1;
                if (rowFilter2 != string.Empty)
                {
                    if (rowFilter != string.Empty)
                        rowFilter += " AND ";
                    rowFilter += rowFilter2;
                }
                if (rowFilter != string.Empty && rowFilter3 != string.Empty)
                    rowFilter += " AND " + rowFilter3;
                _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                txtName.Tag = txtName.Text;
                if (gridBLInfo.Rows.Count > 0)
                    gridBLInfo.Rows[0].Selected = true;
                RefreshDataCount();
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 ---->>>>>>
            // 部位別の名称絞込の追加
            else
            {
                
                if (txtName.Text != string.Empty)
                {
                    string rowFilter;
                    if (OptionSearch.Value.Equals(true)) // 曖昧検索
                        rowFilter3 = string.Format("{0} like '%{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                    else // 前方一致検索
                        rowFilter3 = string.Format("{0} like '{1}%'", _blInfoTable.BL.BLNameColumn.ColumnName, txtName.Text);
                    SetSplitter(false);
                    rowFilter = rowFilter1;
                    if (rowFilter != string.Empty && rowFilter3 != string.Empty)
                        rowFilter += " AND " + rowFilter3;
                    _blInfoTable.BL.DefaultView.RowFilter = rowFilter;
                    _blInfoTable.BL.DefaultView.Sort = _blInfoTable.BL.BLCdColumn.ColumnName+" ASC";
                }
                else
                {
                    SetSplitter(true);
                }
                txtName.Tag = txtName.Text;
                if (gridBLInfo.Rows.Count > 0)
                    gridBLInfo.Rows[0].Selected = true;
                RefreshDataCount();
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 ----<<<<<<
        }
        #endregion

        /// <summary>
        /// [現ページ／総ページ]表示更新
        /// </summary>
        private void RefreshDataCount()
        {
            int cnt = _blInfoTable.BL.DefaultView.Count;
            int current = 0;
            if (gridBLInfo.Selected.Rows.Count > 0)
                current = gridBLInfo.Selected.Rows[0].Index + 1;
            string cntMsg;
            cntMsg = string.Format("{0} / {1}", current, cnt);

            ToolbarsManager.Tools["lbl_Cnt"].SharedProps.Caption = cntMsg;
        }

        //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
        /// <summary>
        /// 売上入力から起動の場合、カーソルを取得できない既存障害あるので、初期カーソルはtimer1_Tickで「名称絞込み」にセットする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : 名称絞込みの初期入力モードを「半角カナ」にする</br>
        /// <br>Update Note: 2016/02/25 脇田靖之</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : 名称絞込みの初期入力モードを「半角カナ」にする</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Focus();
            this.txtName.Focus();
            this.txtName.ImeMode = ImeMode.KatakanaHalf; //ADD 2016/02/25 y.wakita Redmine#48587
            time_count++;
            if (time_count > 1)
            {
                this.timer1.Enabled = false;
            }
        }

        /// <summary>
        /// 売上入力から起動の場合、カーソルを取得できない既存障害あるので、初期カーソルはtimer1_Tickで「名称絞込み」にセットする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : 名称絞込みの初期入力モードを「半角カナ」にする</br>
        /// </remarks>
        private void SelectionForm_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }
        //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
    }

    // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 ----->>>>>
    # region
    /// <summary>
    /// リトライ設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       　: リトライ設定クラス</br>
    /// <br>Programmer   : 陳艶丹</br>
    /// <br>Date         : K2021/04/19</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RetrySet
    {
        // リトライ回数
        private int _retryCount;

        // リトライ間隔
        private int _retryInterval;

        /// <summary>
        /// リトライ設定クラス
        /// </summary>
        public RetrySet()
        {

        }

        /// <summary>リトライ回数</summary>
        public int RetryCount
        {
            get { return this._retryCount; }
            set { this._retryCount = value; }
        }

        /// <summary>リトライ間隔</summary>
        public int RetryInterval
        {
            get { return this._retryInterval; }
            set { this._retryInterval = value; }
        }
    }
    # endregion
    // --- ADD K2021/04/19 陳艶丹 PMKOBETSU-4130の対応 -----<<<<<
}