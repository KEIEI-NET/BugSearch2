using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using System.IO;   // ADD 譚洪 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Resources;  // ADD 譚洪 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Common;   // ADD 譚洪 2014/09/01 FOR Redmine#43289
using Broadleaf.Library.Globarization; // ADD 譚洪 2014/09/01 FOR Redmine#43289

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// <br></br>
    /// <br>Update Note	: 速度チューニング対応（表示対象データの価格一括取得を追加）</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note	: 優先倉庫にトリムをかけてチェックするように修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.16</br>
    /// <br></br>
    /// <br>Update Note	: NSモード、Enetr「次画面」で次の画面に表示するデータが無い場合に部品が選択されない不具合修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.18</br>
    /// <br></br>
    /// <br>Update Note	: オーナーフォーム対応、代替がある部品を選択した時に新品番に属性が反映されるように修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note	: 優良設定で設定した表示順位順で表示されるよう修正</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.03.18</br>
    /// <br></br>
    /// <br>Update Note	: 在庫表示順で優先倉庫が上に表示されるよう変更</br>
    /// <br>            : 在庫の選択方法をチェック方式に変更（未チェックで取寄を選択可能に変更）</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note	: BLコード枝番対応</br>
    /// <br>Programmer	: 20056 對馬 大輔</br>
    /// <br>Date		: 2009.06.08</br>
    /// <br></br>
    /// <br>Update Note	: ソート順を変更。基本はPM7に合わせるが提供データのレイアウト上、</br>
    /// <br>            : ｵﾌﾟｼｮﾝｺｰﾄﾞ(PM7に有った項目)の代わりにｵﾌﾟｼｮﾝ名称を使用。</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.07.23</br>
    /// <br></br>
    /// <br>Update Note	: 純正代替「しない」場合に、表示部品が1件の場合にカタログ品番の結合情報が表示されない不具合の修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/09/29</br>
    /// <br></br>
    /// <br>Update Note	: ①純正代替「しない」場合に、最新品番の情報が存在しないと落ちる不具合の修正</br>
    /// <br>            : ②純正代替「しない」場合に、結合元品番がセットされない不具合の修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/11/27</br>
    /// <br></br>
    /// <br>Update Note	: ①部品選択ウィンドウ無し（１部品のみ）の場合に、結合元、セット親品番を選択した場合に在庫情報が反映されない現象の修正(MANTIS[0014650]</br>
    /// <br>              ②選択品番は、選択部品情報にセットするように修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note : 部品選択ウィンドウに表示される部品リストを取得できるメソッドを追加(部品選択UI用)</br>
    /// <br>Programmer  : 21024　佐々木 健</br>
    /// <br>Date        : 2010/03/15</br>    
    /// <br></br>
    /// <br>Update Note  : 提供代替マスタのQTYがゼロの場合、代替先のQTYに代替元のQTYが表示されない場合がある件の修正(MANTIS[0014913])</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2010/03/16</br>
    /// <br></br>
    /// <br>Update Note  : 装備情報による絞り込みで設定なしのデータが表示対象とならない件の修正(MANTIS[0014913])</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2010/03/29</br>
    /// <br></br>
    /// <br>Update Note : 自由検索オプション ヘッダ部に検索したBLコードを表示するよう修正</br>
    /// <br>Programmer  : 22018　鈴木正臣</br>
    /// <br>Date        : 2010/06/10</br>
    /// <br></br>
    /// <br>Update Note : 成果物統合</br>
    /// <br>                自由検索 2010/06/10 の組込</br>
    /// <br>Programmer  : 22018　鈴木正臣</br>
    /// <br>Date        : 2010/06/10</br>
    /// <br></br>
    /// <br>Update Note : 成果物統合</br>
    /// <br>                ５次改良 2010/03/16 の組込</br>
    /// <br>                ５次改良 2010/03/29 の組込</br>
    /// <br>                売上伝票入力高速化対応 Delphi売上伝票入力から呼び出すとエラーになる件の対応</br>
    /// <br>                                      this.ToolbarsManager.DockWithinContainer = SelectionForm_Fill_Panel</br>
    /// <br>Programmer  : 22018　鈴木正臣</br>
    /// <br>Date        : 2010/06/21</br>
    /// <br></br>
    /// <br>Update Note  : 部品選択ウィンドウ無し（１部品のみ）の場合で、結合元の代替元が在庫なし・代替先が在庫ありのとき、</br>
    /// <br>             : 正しく在庫情報が選択状態にならない現象の修正(MANTIS[0015647])</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2010/06/24</br>
    /// <br></br>
    /// <br>Update Note  : 成果物統合</br>
    /// <br>             : 　MANTIS[0015647] 2010/06/24 の組込</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2010/06/24</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(８月分)</br>
    /// <br>             :   ・部品選択での不正な画面遷移の修正。</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2010/10/01</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(８月分) (※武生自動車部品 対応)</br>
    /// <br>             :   フォーカス位置が不明になったり、分かりにくくなるのを防ぐ。</br>
    /// <br>             : 　・gridCondition.TabStop = false に変更</br>
    /// <br>             :   ・txtBLCode.Enabled = false に変更 (BackColorDisabled=White,ForeColorDisabled=WindowText)</br>
    /// <br>             :   ・txtPartName.Enabled = false に変更 (BackColorDisabled=White,ForeColorDisabled=WindowText)</br>
    /// <br>             : 　・諸元情報グリッドに進入したら強制的に部品グリッドに移動させる。</br>
    /// <br>             :   ・ゼロ件の場合は、在庫・カラー・トリム・装備の各グリッドに移動しない。(即,部品グリッドへ移動)</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note  : 純正部品が１つの場合に、優先倉庫順に在庫が引き当らない不具合の修正(MANTIS[0016779])</br>
    /// <br>Programmer   : 21024  佐々木 健</br>
    /// <br>Date         : 2010/12/20</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(ｘｘ月分)</br>
    /// <br>             :   ・代替制御をＰＭ７準拠の動作に修正。</br>
    /// <br>                   （代替元の在庫があれば、代替しない。(但しユーザー代替と提供代替で判定方法が違う)）</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/01</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(ｘｘ月分)</br>
    /// <br>             :   ・2011/02/01分の修正。在庫有無判定は優先倉庫のみ対象とする。(PM7準拠)</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/09</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(ｘｘ月分)</br>
    /// <br>             :   ・2011/02/01分の修正。標準価格取得の処理を修正。</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/14</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(ｘｘ月分)</br>
    /// <br>             :   ・2011/02/09分の修正。優先倉庫未設定の場合の処理を修正(異常終了させない)</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/02/18</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(2011年03月)</br>
    /// <br>             :   ・複数装備情報の条件が付いている部品を含む検索で、装備情報が設定されていない部品が対象外になる件の修正</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/03/03</br>
    /// <br></br>
    /// <br>Update Note  : SCM対応</br>
    /// <br>             :   ・自動回答時、部品が一件でも回答できない件の修正</br>
    /// <br>Programmer   : 21024  佐々木 健</br>
    /// <br>Date         : 2011/03/08</br>
    /// <br></br>
    /// <br>Update Note  : SCM対応</br>
    /// <br>             :  ・自動回答時、在庫の引当がカタログ品番になる件の修正</br>
    /// <br>Programmer   : 21024  佐々木 健</br>
    /// <br>Date         : 2011/03/15</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応(2011年03月)</br>
    /// <br>             :   ・(2011/03/03に関連して修正)型式全選択時に装備による絞り込みが正常に行われない為、修正。</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2011/03/16</br>
    /// <br>Update Note  : 2011/07/25　譚洪　連番No.702の対応</br>
    /// <br>               代替する（在庫無）の場合、在庫数＞１での条件にして欲しい。品番入力の場合も、在庫条件を参照して欲しい</br>
    /// <br>Update Note  : PCCUOE対応</br>
    /// <br>             :   ・純正Index指定による選択を可能とする</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2011/09/04</br>
    /// <br></br>
    /// <br>Update Note  : 2011/11/29　yangmj　redmine#7759 の対応</br>
    /// <br>               結合選択が表示されないの修正</br>
    /// <br></br>
    /// <br>Update Note  : PMSF連携</br>
    /// <br>             :   ・純正代替するの場合、自動回答で正常に部品情報を回答できない件の対応</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2012/02/09</br>
    /// <br></br>
    /// <br>Update Note	 : 絞込条件のカラーを指定した場合、色無し部品も抽出されるように修正（トリムも同様）</br>
    /// <br>Programmer	 : 30810　宮本 利明</br>
    /// <br>Date		 : 2012/11/27</br>
    /// <br></br>
    /// <br>Update Note  : SCM障害改良一覧№253対応</br>
    /// <br>             :   ・SFからカラー№付きでF/バンパーを発注しても自動回答されない件の対応</br>
    /// <br>Programmer   : 高川 悟</br>
    /// <br>Date         : 2012/09/14</br>
    /// <br></br>
    /// <br>Update Note  : 10900269-00 SPK車台番号文字列対応</br>
    /// <br>                 部品絞込区分と国産/外車区分に応じてVINコードを表示する対応</br>
    /// <br>Programmer   : FSI斎藤 和宏</br>
    /// <br>Date         : 2013/03/25</br>
    /// <br>Update Note: 2014/09/01 譚洪</br>
    /// <br>管理番号   : 11070184-00　SCM障害対応 №190　RedMine#43289</br>
    /// <br>         　: SFから問合せの車輌情報・備考を売上伝票入力に表示する</br>
    /// <br>Update Note: 2014/09/22 鹿庭 一郎</br>
    /// <br>管理番号   : 11070184-00　SCM仕掛一覧No.10598</br>
    /// <br>         　: 文字列車台番号での発注・問合せ対応</br>
    /// <br>Update Note: 2014/11/04 宮本 利明</br>
    /// <br>管理番号   : 11070221-00　仕掛一覧 №2577</br>
    /// <br>         　: 車両情報を表示切替時の明細グリッドの高さ調整処理を修正</br>
    /// <br>Update Note: 2019/01/08 譚洪</br>
    /// <br>管理番号   : 11470076-00</br>
    /// <br>         　: 新元号の対応</br>
    /// </remarks>
    public partial class SelectionParts : Form
    {
        # region DataSetスキーマ情報
        /// <summary>データセット</summary>
        private PMKEN01010E _orgCar = null;
        private PartsInfoDataSet _orgDataSet = null;
        private PartsInfoDataSet.OfrColorInfoDataTable _colorTable;
        private PartsInfoDataSet.OfrTrimInfoDataTable _trimTable;
        private PartsInfoDataSet.OfrEquipInfoDataTable _equipTable;

        private dsPartsSel _dsParts = null;
        private dsPartsSel.PartsInfoDataTable _partsInfo = null;
        /// <summary>部品選択UI用データ</summary>
        public dsPartsSel.PartsInfoDataTable PartsInfo
        {
            get { return _partsInfo; }
        }
        private dsPartsSel.StockDataTable _StockTable = null;
        private dsPartsSel.ModelPartsDetailDataTable _modelPartsDetail = null;
        private int _selectIndex = -1; // 2011/09/04
        /// <summary>
        /// PM.NS式制御／以前開かれた選択UIを処理元になる行 
        /// 例）2行目に対して結合選択UIを開いて戻って来た時は2行目となる。
        /// </summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;
        //private PartsInfoDataSet.UsrGoodsInfoRow _orgRow = null;

        # endregion

        # region private member 各種定数(メッセージなど)
        private string rowNoInput = string.Empty;

        private List<string> colToShow;

        private bool IsColorData = false;
        private bool IsTrimData = false;
        private bool IsEquipData = false;
        private bool isSelectChangeDisabled = false;
        private bool eraNameDispDiv;    // false:西暦  true:和暦
        private bool uiControlFlg;      // false:PM7スタイル   true:PM.NSスタイル
        private int substFlg;          // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
        private int totalAmountDispWay;       // 総額表示方法区分 0:総額表示しない（税抜き）,1:総額表示する（税込み）

        private int catalogMakerCd;

        private DateTimeFormatInfo dtfi;
        private int PartsNarrowing = 0;
        private string originalRowFilter = string.Empty;
        private bool isUserClose = true;
        private int _mode; // 0:通常　1:検索見積専用

        private FrmPartsInfo frmPartsInfo = null;
        private FrmJoinPartsInfo frmJoinInfo = null;

        private UltraGridCell processedCell = null;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusPanel panel;

        private int currentCell;
        private readonly int conditionCellCount = 15;
        private Dictionary<RowFilterKind, string> rowFilterList = new Dictionary<RowFilterKind, string>(18);
        private Dictionary<string, RowFilterKind> lstEnum = new Dictionary<string, RowFilterKind>(18);
        private SelectionInfo _prevSelInfo;
        private bool isDialogShown = true;

        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
        private string _pgid = string.Empty;
        /// <summary>車両情報を表示用XMLファイル名（売伝画面）</summary>
        private const string MAHNB01001U_PMKEN08060U_CARINFOSELETED = "MAHNB01001U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>車両情報を表示用XMLファイル名（見積画面）</summary>
        private const string PMMIT01010U_PMKEN08060U_CARINFOSELETED = "PMMIT01010U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>売伝画面PGID</summary>
        private const string MAHNB01001U_PGID = "MAHNB01001U";
        /// <summary>見積画面PGID</summary>
        private const string PMMIT01010U_PGID = "PMMIT01010U";
        /// <summary>車両情報表示用SOLT</summary>
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

        /// <summary> ダイアログが表示可否フラグ（データ数により自動判定） </summary>
        public bool IsDialogShown
        {
            get { return isDialogShown; }
        }
        # endregion

        #region [ Constructor ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SelectionParts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dsCar">型式情報のデータセット</param>
        /// <param name="dsParts">グリッドに表示するデータを指定します。</param>
        public SelectionParts(PMKEN01010E dsCar, PartsInfoDataSet dsParts)
        {
            InitialMain(dsCar, dsParts);
        }

        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dsCar">型式情報のデータセット</param>
        /// <param name="dsParts">グリッドに表示するデータを指定します。</param>
        /// <param name="mode">0:通常　1:検索見積専用 2:SCM自動回答用</param>
        public SelectionParts(PMKEN01010E dsCar, PartsInfoDataSet dsParts, int mode)
        {
            _mode = mode;
            // 2010/03/15 >>>
            //InitialMain(dsCar, dsParts);
            switch (mode)
            {
                case 0:
                case 1:
                    InitialMain(dsCar, dsParts);
                    break;
                case 2:
                    InitialMain2(dsCar, dsParts);
                    break;
            }
            // 2010/03/15 <<<
        }
        // 2010/03/15 Add >>>
        // 2010/03/15 Add <<<
        #endregion

        #region [ 初期処理 ]
        /// <summary>
        /// コンストラクタでの初期化処理メイン
        /// </summary>
        /// <param name="dsCar"></param>
        /// <param name="dsParts"></param>
        private void InitialMain(PMKEN01010E dsCar, PartsInfoDataSet dsParts)
        {
            _orgCar = dsCar;
            _orgDataSet = dsParts;
            SearchCntSetWork cond = dsParts.SearchCondition.SearchCntSetWork;
            eraNameDispDiv = Convert.ToBoolean(cond.EraNameDispCd1); // 0:西暦／1:和暦
            uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7スタイル／1:PM.NSスタイル
            substFlg = cond.SubstCondDivCd; // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
            userSubstFlg = cond.SubstApplyDivCd;
            enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:総額表示しない（税抜き）,1:総額表示する（税込み）
            if (eraNameDispDiv) // 和暦表示の場合
            {
                dtfi = new CultureInfo("ja-JP").DateTimeFormat;
                dtfi.Calendar = new JapaneseCalendar();
            }
            _dsParts = new dsPartsSel();
            _partsInfo = _dsParts.PartsInfo;
            _StockTable = _dsParts.Stock;
            _modelPartsDetail = _dsParts.ModelPartsDetail;

            Thread initialProcThread = new Thread(InitialThread1);
            Thread initialProcThread2 = new Thread(InitialThread2);
            Thread initialProcThread3 = new Thread(InitialThread3);
            initialProcThread.Start();
            initialProcThread2.Start();
            initialProcThread3.Start();

            InitializeComponent();
            InitializeComponentCustom();

            //InitializeData();

            InitializeForm();
            while (initialProcThread.ThreadState == ThreadState.Running || initialProcThread2.ThreadState == ThreadState.Running)
                Thread.Sleep(10);

            InitializeForm2();

            InitializeTable();
            InitializeGrid();
            MakeConditionGridData();
            RefreshDataCount();
        }

        /// <summary>
        /// マルチスレッドで処理される部分
        /// </summary>
        private void InitialThread1()
        {
            // 2010/03/15 >>>
            //_colorTable = _orgDataSet.OfrColorInfo;
            //_trimTable = _orgDataSet.OfrTrimInfo;
            //_equipTable = _orgDataSet.OfrEquipInfo;

            //InitializeData();
            ////frmPartsInfo = new FrmPartsInfo();
            ////frmJoinInfo = new FrmJoinPartsInfo(_orgDataSet.UsrJoinParts);

            this.InitialThread1(true);
            // 2010/03/15 <<<
        }

        // 2010/03/15 Add >>>
        /// <summary>
        /// マルチスレッドで処理される部分
        /// </summary>
        private void InitialThread1(bool settingPrice)
        {
            _colorTable = _orgDataSet.OfrColorInfo;
            _trimTable = _orgDataSet.OfrTrimInfo;
            _equipTable = _orgDataSet.OfrEquipInfo;

            InitializeData(settingPrice);
        }
        // 2010/03/15 Add <<<

        private void InitialThread2()
        {
            while (_orgDataSet == null)
                System.Threading.Thread.Sleep(10);
            _modelPartsDetail.Merge(_orgDataSet.ModelPartsDetail, true, MissingSchemaAction.Ignore);

        }

        private void InitialThread3()
        {
            lstEnum.Add("ModelGradeNm", RowFilterKind.ModelGradeNm);
            lstEnum.Add("BodyName", RowFilterKind.BodyName);
            lstEnum.Add("DoorCount", RowFilterKind.DoorCount);
            lstEnum.Add("EngineModelNm", RowFilterKind.EngineModelNm);
            lstEnum.Add("EngineDisplaceNm", RowFilterKind.EngineDisplaceNm);
            lstEnum.Add("EDivNm", RowFilterKind.EDivNm);
            lstEnum.Add("TransmissionNm", RowFilterKind.TransmissionNm);
            lstEnum.Add("ShiftNm", RowFilterKind.ShiftNm);
            lstEnum.Add("WheelDriveMethodNm", RowFilterKind.WheelDriveMethodNm);
            lstEnum.Add("AddiCarSpec1", RowFilterKind.AddiCarSpec1);
            lstEnum.Add("AddiCarSpec2", RowFilterKind.AddiCarSpec2);
            lstEnum.Add("AddiCarSpec3", RowFilterKind.AddiCarSpec3);
            lstEnum.Add("AddiCarSpec4", RowFilterKind.AddiCarSpec4);
            lstEnum.Add("AddiCarSpec5", RowFilterKind.AddiCarSpec5);
            lstEnum.Add("AddiCarSpec6", RowFilterKind.AddiCarSpec6);

            frmPartsInfo = new FrmPartsInfo();
            frmJoinInfo = new FrmJoinPartsInfo(_orgDataSet);
        }

        private void InitializeComponentCustom()
        {
            panel = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            panel.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            panel.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.Add(panel);
        }

        private void InitializeForm()
        {
            // ステータスバーの初期化
            StatusBar.Panels[0].Text = string.Empty;

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

            if (uiControlFlg && _mode == 0) // PM.NS式画面制御　且つ　通常モード
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
                ToolbarsManager.Tools["Button_Join"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARCHANGE;
            }
            else// PM7式画面制御　又は　検索見積専用モード
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Visible = false;
            }

            if (substFlg != 0)
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            }
            else
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
            }
            //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
            ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;

            ToolbarsManager.Tools["BtnExchangeDisp"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            ToolbarsManager.Tools["BtnSpec"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SUBMENU;
            ToolbarsManager.Tools["BtnClear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;

        }

        private void InitializeForm2()
        {
            IsColorData = _colorTable != null && _colorTable.Count >= 1;
            IsTrimData = _trimTable != null && _trimTable.Count >= 1;
            IsEquipData = _equipTable != null && _equipTable.Count >= 1;

            //カラー
            ColorGrid.Visible = IsColorData;//カラーが無い
            splitContainer1.Panel1Collapsed = !IsColorData; // カラーが無い
            splitContainer1.Panel2Collapsed = (!IsTrimData && !IsEquipData);// トリム、装備が両方無い
            //トリム
            splitContainer2.Panel1Collapsed = !IsTrimData; //トリムが無い
            //装備
            splitContainer2.Panel2Collapsed = !IsEquipData; //装備が無い

            ultraLabel5.Visible = (!IsColorData && !IsTrimData && !IsEquipData);

            if (IsColorData)
                splitContainer1.SplitterDistance = Convert.ToInt32(dockableWindow2.Width / 2);
            else if (IsTrimData || (IsTrimData == false && IsEquipData))
                splitContainer2.Width = dockableWindow2.Width;

            // --- UPD m.suzuki 2010/06/10 ---------->>>>>
            //txtBLCode.Text = _partsInfo[0].TbsPartsCode.ToString("00000");
            if ( !_partsInfo[0].IsTbsPartsCodeFSNull() && _partsInfo[0].TbsPartsCodeFS != 0 )
            {
                // 自由検索の場合は画面入力されたBLコードを表示する
                // （※商品・部品のBLｺｰﾄﾞと異なる設定も可能な為）
                txtBLCode.Text = _partsInfo[0].TbsPartsCodeFS.ToString( "00000" );
            }
            else
            {
                txtBLCode.Text = _partsInfo[0].TbsPartsCode.ToString( "00000" );
            }
            // --- UPD m.suzuki 2010/06/10 ----------<<<<<
            PartsInfoDataSet.UsrGoodsInfoRow rowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_partsInfo[0].CatalogPartsMakerCd, _partsInfo[0].ClgPrtsNoWithHyphen);
            if (rowGoods != null)
            {
                if (rowGoods.SearchPartsFullName != string.Empty)
                {
                    txtPartName.Text = rowGoods.SearchPartsFullName;
                }
                else if (rowGoods.GoodsName != string.Empty)
                {
                    txtPartName.Text = rowGoods.GoodsName;
                }
                else
                {
                    txtPartName.Text = rowGoods.GoodsOfrName;
                }
            }
            else
            {
                txtPartName.Text = _partsInfo[0].PartsName;
            }
            string keyCol;
            string valueCol;
            if (IsColorData)
            {
                cmbColor.BeginUpdate();
                keyCol = _colorTable.ColorCdInfoNoColumn.ColumnName;
                valueCol = _colorTable.ColorNameColumn.ColumnName;
                cmbColor.DataSource = CmbDataContainer.GetList(_colorTable, keyCol, valueCol);
                cmbColor.ValueMember = "KeyMember";
                cmbColor.DisplayMember = "DisplayMember";
                cmbColor.EndUpdate();
                PMKEN01010E.ColorCdInfoRow[] row = (PMKEN01010E.ColorCdInfoRow[])_orgCar.ColorCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    cmbColor.Value = row[0].ColorCode;
                }
            }
            else
            {
                pnlColor.Visible = false;
            }
            if (IsTrimData)
            {
                cmbTrim.BeginUpdate();
                keyCol = _trimTable.TrimCodeColumn.ColumnName;
                valueCol = _trimTable.TrimNameColumn.ColumnName;
                cmbTrim.DataSource = CmbDataContainer.GetList(_trimTable, keyCol, valueCol);
                cmbTrim.ValueMember = "KeyMember";
                cmbTrim.DisplayMember = "DisplayMember";
                cmbTrim.EndUpdate();
                PMKEN01010E.TrimCdInfoRow[] row = (PMKEN01010E.TrimCdInfoRow[])_orgCar.TrimCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    cmbTrim.Value = row[0].TrimCode;
                }
            }
            else
            {
                pnlTrim.Visible = false;
            }
            if (IsEquipData)
            {
                FillInSoubiGrid();
                GridFiltering();
            }
            else
            {
                pnlEquip.Visible = IsEquipData;
            }

            //RefreshDataCount();
        }

        private void InitializeTable()
        {
            originalRowFilter = _orgDataSet.PartsInfo.DefaultView.RowFilter;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009.07.23 DEL
            //_partsInfo.DefaultView.Sort = _partsInfo.ModelPrtsAblsYmColumn.ColumnName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009.07.23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009.07.23 ADD
            _partsInfo.DefaultView.Sort = string.Format( "{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                        _partsInfo.SeriesModelColumn.ColumnName,
                                                        _partsInfo.CategorySignModelColumn.ColumnName,
                                                        _partsInfo.ExhaustGasSignColumn.ColumnName,
                                                        _partsInfo.FullModelFixedNoColumn.ColumnName,
                                                        _partsInfo.PartsQtyColumn.ColumnName,
                                                        _partsInfo.PartsOpNmColumn.ColumnName,
                                                        _partsInfo.NewPrtsNoWithHyphenColumn.ColumnName,
                                                        _partsInfo.CatalogPartsMakerCdColumn.ColumnName,
                                                        _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName
                                                        );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009.07.23 ADD
            gridPartsInfo.BeginUpdate();
            gridPartsInfo.DataSource = _partsInfo.DefaultView;//_orgDataSet.PartsInfo.DefaultView;
            gridPartsInfo.EndUpdate();
            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView( _StockTable.DefaultView );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            ColorGrid.DataSource = _colorTable.DefaultView;
            TrimGrid.DataSource = _trimTable.DefaultView;
            EquipGrid.DataSource = _equipTable.DefaultView;

            PartsNarrowing = _partsInfo[0].PartsNarrowingCode;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
        /// <summary>
        /// 在庫のDataSourceとなるViewを設定します
        /// </summary>
        /// <param name="dataView"></param>
        private void SettingStockView( DataView dataView )
        {
            // ソート設定
            dataView.Sort = string.Format( "{0}, {1}",
                                            _StockTable.SortDivColumn.ColumnName,
                                            _StockTable.WarehouseCodeColumn.ColumnName );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

        private void InitializeGrid()
        {
            colToShow = new List<string>(new string[]{ 
                _modelPartsDetail.ModelGradeNmColumn.ColumnName,            // 0
                _modelPartsDetail.BodyNameColumn.ColumnName,                // 1
                _modelPartsDetail.DoorCountColumn.ColumnName,               // 2
                _modelPartsDetail.EngineModelNmColumn.ColumnName,           // 3
                _modelPartsDetail.EngineDisplaceNmColumn.ColumnName,        // 4
                _modelPartsDetail.EDivNmColumn.ColumnName,                  // 5
                _modelPartsDetail.TransmissionNmColumn.ColumnName,          // 6
                _modelPartsDetail.ShiftNmColumn.ColumnName,                 // 7
                _modelPartsDetail.WheelDriveMethodNmColumn.ColumnName,      // 8
                _modelPartsDetail.AddiCarSpec1Column.ColumnName,            // 9
                _modelPartsDetail.AddiCarSpec2Column.ColumnName,            // 10
                _modelPartsDetail.AddiCarSpec3Column.ColumnName,            // 11
                _modelPartsDetail.AddiCarSpec4Column.ColumnName,            // 12
                _modelPartsDetail.AddiCarSpec5Column.ColumnName,            // 13
                _modelPartsDetail.AddiCarSpec6Column.ColumnName,            // 14
                _modelPartsDetail.SelImgColumn.ColumnName
            });

            gridPartsInfo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            //gridPartsInfo.DisplayLayout.InterBandSpacing = 3;

            Infragistics.Win.UltraWinGrid.UltraGridBand Band0 = gridPartsInfo.DisplayLayout.Bands[0];
            Infragistics.Win.UltraWinGrid.UltraGridBand Band1 = gridPartsInfo.DisplayLayout.Bands[1];

            #region 部品情報バンド(親バンド)
            Band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            Band0.Override.RowSizing = RowSizing.Fixed;
            Band0.Override.AllowColSizing = AllowColSizing.None;
            Band0.Indentation = 0;
            Band0.UseRowLayout = true;
            Band0.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            #region 不要コラム非表示処理
            Band0.Columns[_partsInfo.PartsNarrowingCodeColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsCodeColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsNameColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.FullModelFixedNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.TbsPartsCodeColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.CatalogPartsMakerNmColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ColdDistrictsFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ColorNarrowingFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.TrimNarrowingFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.EquipNarrowingFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.MakerOfferPartsNameColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsLayerCdColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsUniqueNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.SelectionStateColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.OldPartsNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAdptYmColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAblsYmColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAdptFrameNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAblsFrameNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.UsrSubstColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.WarehouseCodeColumn.ColumnName].Hidden = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009.07.23 ADD
            Band0.Columns[_partsInfo.SeriesModelColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.CategorySignModelColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ExhaustGasSignColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009.07.23 ADD
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            Band0.Columns[_partsInfo.TbsPartsCodeFSColumn.ColumnName].Hidden = true;
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            #endregion
            if (_mode == 1) // 検索見積専用モード
            {
                Band0.Columns[_partsInfo.JoinColumn.ColumnName].Hidden = true;
                Band0.Columns[_partsInfo.SetColumn.ColumnName].Hidden = true;
            }
            if (substFlg == 0) // 「代替しない」は代替カラムを表示しない。
            {
                Band0.Columns[_partsInfo.SubstColumn.ColumnName].Hidden = true;
            }

            for (int Index = 0; Index < Band0.Columns.Count; Index++)
            {
                if (Band0.Columns[Index].Hidden)
                    continue;
                // 水平表示位置
                if ((Band0.Columns[Index].DataType == typeof(int)) ||
                         (Band0.Columns[Index].DataType == typeof(double)) ||
                         (Band0.Columns[Index].DataType == typeof(Int64)) ||
                         (Band0.Columns[Index].DataType == typeof(Int16)))
                {
                    Band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (Band0.Columns[Index].DataType == typeof(Image))
                {
                    Band0.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                }
                else
                {
                    Band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band0.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                Band0.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            ColInfo.SetColInfo(Band0, _partsInfo.SelImageColumn.ColumnName, 2, 0, 1, 6, 15);

            // 1段
            ColInfo.SetColInfo(Band0, _partsInfo.PartsNoColumn.ColumnName, 3, 0, 7, 2, 70);
            ColInfo.SetColInfo(Band0, _partsInfo.PrimePartsNoColumn.ColumnName, 10, 0, 7, 2, 70);
            ColInfo.SetColInfo(Band0, _partsInfo.JoinSrcPartsNoColumn.ColumnName, 17, 0, 7, 2, 60);

            // --- ADD 2013/03/25 ---------->>>>>
            // 国産/外車区分の値をチェック
            if (_orgCar != null && _orgCar.CarModelUIData[0].DomesticForeignCode == 2)
            {
                // 外車の場合
                // 部品絞込区分の値をチェック
                if (PartsNarrowing == 1)
                {
                    // 部品絞込区分→車台番号
                    // VINコード開始・VINコード終了を表示
                    ColInfo.SetColInfo(Band0, _partsInfo.VinProduceStartNoColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.VinProduceEndNoColumn.ColumnName, 30, 0, 6, 2, 60);
                    // 年式・車台番号は非表示
                    Band0.Columns[_partsInfo.YearStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.YearEndColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoEndColumn.ColumnName].Hidden = true;
                    
                }
                else
                {
                    // 部品絞込区分→年式
                    ColInfo.SetColInfo(Band0, _partsInfo.YearStartColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.YearEndColumn.ColumnName, 30, 0, 6, 2, 60);
                    // VINコード・車台番号は非表示
                    Band0.Columns[_partsInfo.VinProduceStartNoColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.VinProduceEndNoColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoEndColumn.ColumnName].Hidden = true;
                }
            }
            else
            {
                // 国産車の場合はVINコードを非表示にセット
                Band0.Columns[_partsInfo.VinProduceStartNoColumn.ColumnName].Hidden = true;
                Band0.Columns[_partsInfo.VinProduceEndNoColumn.ColumnName].Hidden = true;

                // VINコード絞込行わない場合
                if (PartsNarrowing == 0)
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.YearStartColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.YearEndColumn.ColumnName, 30, 0, 6, 2, 60);
                    Band0.Columns[_partsInfo.FrameNoStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoEndColumn.ColumnName].Hidden = true;
                }
                else
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.FrameNoStartColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.FrameNoEndColumn.ColumnName, 30, 0, 6, 2, 60);
                    Band0.Columns[_partsInfo.YearStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.YearEndColumn.ColumnName].Hidden = true;
                }
            }
            // --- ADD 2013/03/25 ----------<<<<<

            ColInfo.SetColInfo(Band0, _partsInfo.PartsQtyColumn.ColumnName, 36, 0, 4, 2, 40);
            if (_mode == 0)
            {
                ColInfo.SetColInfo(Band0, _partsInfo.GenkaColumn.ColumnName, 40, 0, 4, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarirituColumn.ColumnName, 44, 0, 4, 2, 40);
            }
            else // 検索見積専用モードでは結合・代替などがない分調整が必要・２段も同様
            {
                ColInfo.SetColInfo(Band0, _partsInfo.GenkaColumn.ColumnName, 40, 0, 4, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarirituColumn.ColumnName, 45, 0, 5, 2, 40);
            }

            // 2段
            ColInfo.SetColInfo(Band0, _partsInfo.PartsOpNmColumn.ColumnName, 3, 2, 14, 2, 140);
            ColInfo.SetColInfo(Band0, _partsInfo.StandardNameColumn.ColumnName, 17, 2, 7, 2, 70);
            ColInfo.SetColInfo(Band0, _partsInfo.WarehouseColumn.ColumnName, 24, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band0, _partsInfo.ShelfColumn.ColumnName, 28, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band0, _partsInfo.StockCntColumn.ColumnName, 32, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band0, _partsInfo.PriceColumn.ColumnName, 36, 2, 4, 2, 40);
            if (_mode == 0)
            {
                ColInfo.SetColInfo(Band0, _partsInfo.UrikaColumn.ColumnName, 40, 2, 4, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarigakuColumn.ColumnName, 44, 2, 4, 2, 40);
            }
            else
            {
                ColInfo.SetColInfo(Band0, _partsInfo.UrikaColumn.ColumnName, 40, 2, 5, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarigakuColumn.ColumnName, 45, 2, 5, 2, 40);
            }

            // 1・2段
            if (_mode == 0) // 通常モードの場合
            {
                if (substFlg == 0) // 代替しない
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.SetColumn.ColumnName, 48, 0, 1, 4, 12);
                    ColInfo.SetColInfo(Band0, _partsInfo.JoinColumn.ColumnName, 49, 0, 1, 4, 12);
                }
                else // 代替する（在庫判定なし） 又は　代替する（在庫判定あり）
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.SubstColumn.ColumnName, 48, 0, 1, 4, 15);
                    ColInfo.SetColInfo(Band0, _partsInfo.SetColumn.ColumnName, 49, 0, 1, 4, 15);
                    ColInfo.SetColInfo(Band0, _partsInfo.JoinColumn.ColumnName, 50, 0, 1, 4, 15);
                }
            }
            else            // 検索見積専用モードの場合
            {
                if (substFlg != 0)
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.SubstColumn.ColumnName, 50, 0, 1, 4, 12);
                }
            }

            Band0.Columns[_partsInfo.PriceColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.GenkaColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.UrikaColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.ArarigakuColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.ArarirituColumn.ColumnName].Format = "#%";
            Band0.Columns[_partsInfo.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            Band0.Columns[_partsInfo.PartsQtyColumn.ColumnName].Format = "###,###,##0.00";
            #endregion

            #region 型式情報バンド設定
            List<String> ret = SetAddCarSpecColumn(gridPartsInfo.DisplayLayout.Bands[1]);
            bool is4thRow = false;
            if (ret.Count > 0)
                is4thRow = true;

            Band1.UseRowLayout = true;
            Band1.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
            //Band1.Override.HeaderPlacement = HeaderPlacement.OncePerGroupedRowIsland;
            //Band1.ColHeadersVisible = false;
            Band1.Indentation = 0;
            //Band1.Override.DefaultRowHeight = 20;
            Band1.Columns[_modelPartsDetail.FullModelFixedNoColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.PartsNoColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.PartsMakerCdColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.SelectionStateColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.PartsUniqueNoColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle1Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle2Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle3Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle4Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle5Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle6Column.ColumnName].Hidden = true;

            Band1.Override.RowSizing = RowSizing.Fixed;
            Band1.Override.AllowColSizing = AllowColSizing.None;
            Band1.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 諸元情報
            if (ret.Count > 0)
                ColInfo.SetColInfo(Band1, _modelPartsDetail.SelImgColumn.ColumnName, 2, 0, 1, 4, 13);
            else
                ColInfo.SetColInfo(Band1, _modelPartsDetail.SelImgColumn.ColumnName, 2, 0, 1, 2, 13);
            ColInfo.SetColInfo(Band1, colToShow[0], 3, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[1], 9, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[2], 15, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[3], 21, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[4], 27, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[5], 33, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[6], 39, 0, 5, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[7], 44, 0, 4, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[8], 48, 0, 4, 2, 50, 16);
            if (is4thRow)
            {
                int originX = 4;
                int del = 48 / ret.Count;
                int remainder = 48;
                for (int i = 0; i < ret.Count; i++)
                {
                    if (i == ret.Count - 1)
                        del = remainder;
                    ColInfo.SetColInfo(Band1, ret[i], originX, 2, del, 2, 60, 16);
                    originX += del;
                    remainder -= del;
                }
            }
            #endregion

            #region カラグリッド
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.PartsProperNoColumn.ColumnName].Hidden = true;
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.SelectionStateColumn.ColumnName].Hidden = true;
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.ColorCdInfoNoColumn.ColumnName].Width = 100;
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.ColorNameColumn.ColumnName].Width = 200;
            ColorGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            #endregion

            #region トリムグリッド
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.PartsProperNoColumn.ColumnName].Hidden = true;
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.SelectionStateColumn.ColumnName].Hidden = true;
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.TrimCodeColumn.ColumnName].Width = 100;
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.TrimNameColumn.ColumnName].Width = 200;
            TrimGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            #endregion

            #region 装備グリッド
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.PartsProperNoColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.SelectionStateColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentCodeColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentDispOrderColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentGenreCdColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentIconCodeColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentShortNameColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentGenreNmColumn.ColumnName].Width = 200;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentNameColumn.ColumnName].Width = 200;
            EquipGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            #endregion

        }

        //---- ADD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
        /// <summary>
        /// 生産年式文字列取得処理
        /// </summary>
        /// <param name="produceTypeOfYear">生産年式</param>
        /// <remarks>
        /// <br>Note	   : 生産年式を和暦の「GG YY年MM月」形式に変換する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/01/08</br>
        /// </remarks>
        private string GetStrFromDt(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            retYear = TDateTime.DateTimeToString("GGYYMM", produceTypeOfYear);
            string gg = retYear.Substring(0, 2);
            string yymm = retYear.Substring(2, 6);
            retYear = gg + " " + yymm;
            return retYear;
        }
        //---- ADD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<

        /// <summary>
        /// 表示用データをDataTableに登録するためのサブスレッド
        /// </summary>
        /// <param name="setPrice">価格のセット</param>
        // 2010/03/15 >>>
        //private void InitializeData()
        /// <remarks>
        /// <br>UpdateNote   2019/01/08  譚洪</br>
        /// <br>修正内容     新元号の対応</br>
        /// </remarks>
        private void InitializeData(bool setPrice)
        // 2010/03/15 <<<
        {
            // 2010/03/15 >>>
            //// 2009.02.10 Add >>>
            //this.SettingPriceTargetData();
            //// 2009.02.10 Add <<<

            if (setPrice) this.SettingPriceTargetData();
            // 2010/03/15 <<<

            // 2009.06.08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //_partsInfo.Merge(_orgDataSet.PartsInfo, true, MissingSchemaAction.Ignore);

            if (_orgDataSet.BLGoodsDrCode != 0)
            {
                DataRow[] rows = _orgDataSet.PartsInfo.Select(string.Format("{0}={1}", _orgDataSet.PartsInfo.TbsPartsCdDerivedNoColumn.ColumnName, _orgDataSet.BLGoodsDrCode));
                PartsInfoDataSet.PartsInfoDataTable dt = new PartsInfoDataSet.PartsInfoDataTable();
                if (( rows != null ) && ( rows.Length != 0 ))
                {
                    foreach (DataRow row in rows)
                    {
                        PartsInfoDataSet.PartsInfoRow p = dt.NewPartsInfoRow();
                        PartsInfoDataSet.PartsInfoRow temprow = (PartsInfoDataSet.PartsInfoRow)row;
                        p.CatalogPartsMakerCd = temprow.CatalogPartsMakerCd;
                        p.CatalogPartsMakerNm = temprow.CatalogPartsMakerNm;
                        p.ClgPrtsNoWithHyphen = temprow.ClgPrtsNoWithHyphen;
                        p.ColdDistrictsFlag = temprow.ColdDistrictsFlag;
                        p.ColorNarrowingFlag = temprow.ColorNarrowingFlag;
                        p.EquipNarrowingFlag = temprow.EquipNarrowingFlag;
                        p.FigshapeNo = temprow.FigshapeNo;
                        p.FullModelFixedNo = temprow.FullModelFixedNo;
                        p.MakerOfferPartsName = temprow.MakerOfferPartsName;
                        p.ModelPrtsAblsFrameNo = temprow.ModelPrtsAblsFrameNo;
                        p.ModelPrtsAblsYm = temprow.ModelPrtsAblsYm;
                        p.ModelPrtsAdptFrameNo = temprow.ModelPrtsAdptFrameNo;
                        p.ModelPrtsAdptYm = temprow.ModelPrtsAdptYm;
                        p.NewPrtsNoNoneHyphen = temprow.NewPrtsNoNoneHyphen;
                        p.NewPrtsNoWithHyphen = temprow.NewPrtsNoWithHyphen;
                        p.OfferDate = temprow.OfferDate;
                        p.PartsCode = temprow.PartsCode;
                        p.PartsLayerCd = temprow.PartsLayerCd;
                        p.PartsName = temprow.PartsName;
                        p.PartsNameKana = temprow.PartsNameKana;
                        p.PartsNarrowingCode = temprow.PartsNarrowingCode;
                        p.PartsOpNm = temprow.PartsOpNm;
                        p.PartsQty = temprow.PartsQty;
                        p.PartsSearchCode = temprow.PartsSearchCode;
                        p.PartsUniqueNo = temprow.PartsUniqueNo;
                        p.SelectionState = temprow.SelectionState;
                        p.StandardName = temprow.StandardName;
                        p.TbsPartsCdDerivedNo = temprow.TbsPartsCdDerivedNo;
                        p.TbsPartsCode = temprow.TbsPartsCode;
                        p.TrimNarrowingFlag = temprow.TrimNarrowingFlag;
                        p.WorkOrPartsDivNm = temprow.WorkOrPartsDivNm;

                        // --- ADD 2013/03/25 ---------->>>>>
                        // 「VIN生産No.(始期)」「VIN生産No.(終期)」
                        p.VinProduceStartNo = temprow.VinProduceStartNo;
                        p.VinProduceEndNo = temprow.VinProduceEndNo;
                        // --- ADD 2013/03/25 ----------<<<<<

                        dt.AddPartsInfoRow(p);
                    }
                }

                if (dt.Count != 0)
                {
                    _partsInfo.Merge(dt, true, MissingSchemaAction.Ignore);
                }
                else
                {
                    _partsInfo.Merge(_orgDataSet.PartsInfo, true, MissingSchemaAction.Ignore);
                }
            }
            else
            {
                _partsInfo.Merge(_orgDataSet.PartsInfo, true, MissingSchemaAction.Ignore);
            }
            // 2009.06.08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            catalogMakerCd = _partsInfo[0].CatalogPartsMakerCd;
            //_modelPartsDetail.Merge(_orgDataSet.ModelPartsDetail, true, MissingSchemaAction.Ignore);
            int cnt = _partsInfo.Count;
            string catalogPartsNo, newPartsNo, partsNoInUse = string.Empty;
            int makerCd;
            for (int i = 0; i < cnt; i++)
            {
                #region [ 年式・車台番号・QTY設定処理 ]
                // 年式情報編集
                if (eraNameDispDiv) // 和暦
                {
                    if (_partsInfo[i].ModelPrtsAdptYm > 0)
                        //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                        //_partsInfo[i].YearStart = GetDtFromInt(_partsInfo[i].ModelPrtsAdptYm).ToString("gg yy年MM月", dtfi);
                        _partsInfo[i].YearStart = GetStrFromDt(GetDtFromInt(_partsInfo[i].ModelPrtsAdptYm));
                        //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                    if (_partsInfo[i].ModelPrtsAdptYm > 0 && _partsInfo[i].ModelPrtsAblsYm != 999999)
                        //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                        //_partsInfo[i].YearEnd = GetDtFromInt(_partsInfo[i].ModelPrtsAblsYm).ToString("gg yy年MM月", dtfi);
                        _partsInfo[i].YearEnd = GetStrFromDt(GetDtFromInt(_partsInfo[i].ModelPrtsAblsYm));
                        //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                }
                else                // 西暦
                {
                    if (_partsInfo[i].ModelPrtsAdptYm > 0)
                        _partsInfo[i].YearStart = _partsInfo[i].ModelPrtsAdptYm.ToString("####年 ##月");
                    if (_partsInfo[i].ModelPrtsAdptYm > 0 && _partsInfo[i].ModelPrtsAblsYm != 999999)
                        _partsInfo[i].YearEnd = _partsInfo[i].ModelPrtsAblsYm.ToString("####年 ##月");
                }
                _partsInfo[i].FrameNoStart = _partsInfo[i].ModelPrtsAdptFrameNo.ToString();

                // フレーム番号情報編集
                if (_partsInfo[i].ModelPrtsAblsFrameNo != 99999999)
                    _partsInfo[i].FrameNoEnd = _partsInfo[i].ModelPrtsAblsFrameNo.ToString();
                _partsInfo[i].JoinSrcPartsNo = _partsInfo[i].ClgPrtsNoWithHyphen;

                // QTY情報編集
                if (_partsInfo[i].PartsQty == 0)
                    _partsInfo[i].PartsQty = 1;
                #endregion

                catalogPartsNo = _partsInfo[i].ClgPrtsNoWithHyphen;
                newPartsNo = _partsInfo[i].NewPrtsNoWithHyphen;
                makerCd = _partsInfo[i].CatalogPartsMakerCd;
                PartsInfoDataSet.UsrGoodsInfoRow row;
                // --- UPD m.suzuki 2011/02/01 ---------->>>>>
                # region // DEL
                //if (substFlg == 1 && CatalogPartsStockCheck(catalogPartsNo, makerCd))
                //{       // 代替条件：在庫判定有　且つ　カタログ品在庫ありの場合
                //    partsNoInUse = catalogPartsNo;  // 価格・在庫・セット情報をカタログ品番から取得
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                //else
                //{
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, catalogPartsNo);
                //    if (userSubstFlg != 0)
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(row);
                //        if (rowSubst.Equals(row))
                //        {
                //            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //            rowSubst = _orgDataSet.GetUsrSubst(row);
                //            if (rowSubst.Equals(row) == false) // 最新品に対してユーザー代替がある場合
                //            {
                //                _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                //                partsNoInUse = rowSubst.GoodsNo;      // 価格・在庫・セット情報を最新品番から取得
                //                catalogPartsNo = newPartsNo = partsNoInUse;
                //                _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                //                row = rowSubst;
                //                _partsInfo[i].UsrSubst = true;
                //                _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                //            }
                //            else // ユーザー代替がない場合
                //            {
                //                partsNoInUse = newPartsNo;      // 価格・在庫・セット情報を最新品番から取得
                //            }
                //        }
                //        else // カタログ品に対してユーザー代替がある場合
                //        {
                //            _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                //            partsNoInUse = rowSubst.GoodsNo;      // 価格・在庫・セット情報を最新品番から取得
                //            catalogPartsNo = newPartsNo = partsNoInUse;
                //            _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                //            row = rowSubst;
                //            _partsInfo[i].UsrSubst = true;
                //            _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                //        }
                //    }
                //    else // ユーザー代替がない場合
                //    {
                //        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //        partsNoInUse = newPartsNo;      // 価格・在庫・セット情報を最新品番から取得
                //    }
                //}
                # endregion

                bool stockCountNotZero;
                if ( CatalogPartsStockCheck( catalogPartsNo, makerCd, out stockCountNotZero ) )
                {
                    // 在庫レコードあり
                    if ( stockCountNotZero )
                    {
                        //------------------------------
                        // 在庫あり(在庫数>0) ⇒ 代替元
                        //------------------------------

                        // 代替元
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );
                        partsNoInUse = catalogPartsNo;  // 価格・在庫・セット情報をカタログ品番から取得
                    }
                    else
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        //------------------------------
                        // 在庫ゼロ ⇒ ユーザー代替のみ有り
                        //------------------------------
                        // ユーザー代替区分
                        // --- UPD 2011/07/25 ---- >>>>>
                        //if ( userSubstFlg != 0 )
                        //{
                        // --- ADD 2011/11/29 ---- >>>>>
                        if ( userSubstFlg != 0 )
                        {
                        // --- ADD 2011/11/29 ---- <<<<<
                            // ユーザー代替先(無ければ代替元)
                            PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                            bool usrSubst = !(rowSubst.Equals( row ));
                            row = rowSubst;

                            _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                            partsNoInUse = rowSubst.GoodsNo;      // 価格・在庫・セット情報を最新品番から取得
                            catalogPartsNo = newPartsNo = partsNoInUse;
                            _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                            _partsInfo[i].UsrSubst = usrSubst;
                            _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                        // --- ADD 2011/11/29 ---- >>>>>
                        }
                        else
                        {
                            // 代替元
                            partsNoInUse = catalogPartsNo;  // 価格・在庫・セット情報をカタログ品番から取得
                        }
                        // --- ADD 2011/11/29 ---- <<<<<
                        //}
                        //else
                        //{
                        //    // 代替元
                        //    partsNoInUse = catalogPartsNo;  // 価格・在庫・セット情報をカタログ品番から取得
                        //}
                        // --- UPD 2011/07/25 ---- <<<<<
                    }
                }
                else
                {
                    //------------------------------
                    // 在庫レコードなし ⇒ ユーザー代替・提供代替
                    //------------------------------
                    // ユーザー代替区分
                    // --- UPD 2011/07/25 ---- >>>>>
                    //if ( userSubstFlg != 0 )
                    //{
                    // --- ADD 2011/11/29 ---- >>>>>
                    if ( userSubstFlg != 0 )
                    {
                    // --- ADD 2011/11/29 ---- <<<<<
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                        if ( rowSubst.Equals( row ) )
                        {
                            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                            rowSubst = _orgDataSet.GetUsrSubst( row );
                            if ( rowSubst.Equals( row ) == false ) // 最新品に対してユーザー代替がある場合
                            {
                                row = rowSubst;

                                _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                                partsNoInUse = rowSubst.GoodsNo;      // 価格・在庫・セット情報を最新品番から取得
                                catalogPartsNo = newPartsNo = partsNoInUse;
                                _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                                _partsInfo[i].UsrSubst = true;
                                _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                            }
                            else // ユーザー代替がない場合
                            {
                                partsNoInUse = newPartsNo;
                            }
                        }
                        else // カタログ品に対してユーザー代替がある場合
                        {
                            row = rowSubst;

                            _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                            partsNoInUse = rowSubst.GoodsNo;      // 価格・在庫・セット情報を最新品番から取得
                            catalogPartsNo = newPartsNo = partsNoInUse;
                            _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                            _partsInfo[i].UsrSubst = true;
                            _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                        }
                    // --- ADD 2011/11/29 ---- >>>>>
                    }
                    else
                    {
                        // 提供代替先(無ければ代替元)
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                        partsNoInUse = newPartsNo;      // 価格・在庫・セット情報を最新品番から取得
                    }
                    // --- ADD 2011/11/29 ---- <<<<<
                    //}
                    //else
                    //{
                    //    // 提供代替先(無ければ代替元)
                    //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                    //    partsNoInUse = newPartsNo;      // 価格・在庫・セット情報を最新品番から取得
                    //}
                    // --- UPD 2011/07/25 ---- <<<<<
                }

                // --- UPD m.suzuki 2011/02/01 ----------<<<<<


                _partsInfo[i].PartsNo = partsNoInUse;
                //PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);

                if (row != null)    // 2009/11/27 Add
                {                   // 2009/11/27 Add

                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        _partsInfo[i].Price = row.PriceTaxInc;
                        _partsInfo[i].Urika = row.SalesUnitPriceTaxInc;
                        _partsInfo[i].Genka = row.UnitCostTaxInc;
                    }
                    else // 総額表示しない（税抜き）
                    {
                        _partsInfo[i].Price = row.PriceTaxExc;
                        _partsInfo[i].Urika = row.SalesUnitPriceTaxExc;
                        _partsInfo[i].Genka = row.UnitCostTaxExc;
                    }
                    // 粗利額・粗利率は区分関係なく税抜きで計算
                    _partsInfo[i].Ararigaku = row.SalesUnitPriceTaxExc - row.UnitCostTaxExc;
                    if (row.SalesUnitPriceTaxExc != 0)
                        _partsInfo[i].Arariritu = _partsInfo[i].Ararigaku / row.SalesUnitPriceTaxExc;
                }               // 2009/11/27 Add
                // 優良品番情報編集
                string primePartsNo;
                if (JoinExists(catalogPartsNo, makerCd, out primePartsNo))
                {
                    _partsInfo[i].Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                    _partsInfo[i].PrimePartsNo = primePartsNo;
                }
                // 代替条件区分が在庫判定有でカタログ品番の在庫有の場合カタログ品番のみから結合するため直下の処理はしない
                if (catalogPartsNo != newPartsNo && partsNoInUse == newPartsNo
                        && JoinExists(newPartsNo, makerCd, out primePartsNo))
                {
                    _partsInfo[i].Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                    if (_partsInfo[i].PrimePartsNo == string.Empty)
                    {
                        _partsInfo[i].PrimePartsNo = primePartsNo;
                    }
                }

                if (SubstExists(catalogPartsNo, makerCd)) // 代替に関してはこのモジュールの中で各チェック処理を行う
                {
                    _partsInfo[i].Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                }
                if (SetExists(partsNoInUse, makerCd))
                {
                    _partsInfo[i].Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                }

                #region [ 在庫設定 ]
                //在庫設定
                bool flgStock = false;
                string filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, makerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, partsNoInUse);
                PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                for (int j = 0; j < stockRows.Length; j++)
                {
                    if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                    {
                        dsPartsSel.StockRow stockRow = _StockTable.NewStockRow();
                        stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                        stockRow.GoodsNo = stockRows[j].GoodsNo;
                        stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                        stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                        stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                        stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                        stockRow.WarehouseName = stockRows[j].WarehouseName;
                        stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                        stockRow.SelectionState = stockRows[j].SelectionState;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                        // 在庫情報のソートに使用する区分値をセットする
                        if ( _orgDataSet.ListPriorWarehouse != null )
                        {
                            int index = _orgDataSet.ListPriorWarehouse.IndexOf( stockRow.WarehouseCode.Trim() );
                            if ( index >= 0 )
                            {
                                // 優先倉庫リストにあればindexをセット
                                stockRow.SortDiv = index;
                            }
                            else
                            {
                                // 優先倉庫リストになければリストのCount(最大のindex+1)
                                stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                            }
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

                        _StockTable.AddStockRow(stockRow);
                        if (stockRows[j].SelectionState)
                        {
                            _partsInfo[i].Shelf = stockRow.WarehouseShelfNo;
                            _partsInfo[i].StockCnt = stockRow.ShipmentPosCnt;
                            _partsInfo[i].Warehouse = stockRow.WarehouseName;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                            _partsInfo[i].WarehouseCode = stockRow.WarehouseCode;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                            flgStock = true;
                        }
                    }
                }
                if (flgStock == false && _orgDataSet.ListPriorWarehouse != null)
                {
                    for (int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++)
                    {
                        // 2009.02.16 >>>
                        //string warehouseCd = _orgDataSet.ListPriorWarehouse[j];
                        string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();
                        // 2009.02.16 <<<
                        for (int k = 0; k < stockRows.Length; k++)
                        {
                            if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                            {
                                _partsInfo[i].Shelf = stockRows[k].WarehouseShelfNo;
                                _partsInfo[i].StockCnt = stockRows[k].ShipmentPosCnt;
                                _partsInfo[i].Warehouse = stockRows[k].WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                _partsInfo[i].WarehouseCode = stockRows[k].WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                flgStock = true;
                                break;
                            }
                        }
                        if (flgStock)
                            break;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫になければ取寄にする
                //if (flgStock == false && stockRows.Length > 0)
                //{
                //    _partsInfo[i].Shelf = stockRows[0].WarehouseShelfNo;
                //    _partsInfo[i].StockCnt = stockRows[0].ShipmentPosCnt;
                //    _partsInfo[i].Warehouse = stockRows[0].WarehouseName;
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                //    _partsInfo[i].WarehouseCode = stockRows[0].WarehouseCode;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                #endregion
            }
        }

        // 2009.02.10 Add >>>
        /// <summary>
        /// 対象データの価格設定
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculateGoodsPrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            foreach (PartsInfoDataSet.PartsInfoRow partsInfoRow in _orgDataSet.PartsInfo)
            {
                string catalogPartsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                string newPartsNo = partsInfoRow.NewPrtsNoWithHyphen;
                // --- DEL m.suzuki 2011/02/01 ---------->>>>>
                //string partsNoInUse;
                // --- DEL m.suzuki 2011/02/01 ----------<<<<<
                int makerCd = partsInfoRow.CatalogPartsMakerCd;
                PartsInfoDataSet.UsrGoodsInfoRow row;
                // --- UPD m.suzuki 2011/02/01 ---------->>>>>
                # region // DEL
                //if (substFlg == 1 && CatalogPartsStockCheck(catalogPartsNo, makerCd))
                //{       // 代替条件：在庫判定有　且つ　カタログ品在庫ありの場合
                //    partsNoInUse = catalogPartsNo;  // 価格・在庫・セット情報をカタログ品番から取得
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                //else
                //{
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, catalogPartsNo);
                //    if (userSubstFlg != 0)
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(row);
                //        if (rowSubst.Equals(row))
                //        {
                //            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //            rowSubst = _orgDataSet.GetUsrSubst(row);
                //            if (rowSubst.Equals(row) == false) // 最新品に対してユーザー代替がある場合
                //            {
                //                row = rowSubst;
                //            }
                //            else // ユーザー代替がない場合
                //            {
                //            }
                //        }
                //        else // カタログ品に対してユーザー代替がある場合
                //        {
                //            row = rowSubst;
                //        }
                //    }
                //    else // ユーザー代替がない場合
                //    {
                //        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //    }
                //}
                //if (row != null)
                //{
                //    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(row.GoodsNo, row.GoodsMakerCd));
                //}
                # endregion

                bool stockCountNotZero;
                if ( CatalogPartsStockCheck( catalogPartsNo, makerCd, out stockCountNotZero ) )
                {   
                    // 在庫レコードあり
                    if ( stockCountNotZero )
                    {
                        //------------------------------
                        // 在庫あり(在庫数>0) ⇒ 代替元
                        //------------------------------

                        // 代替元
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );
                    }
                    else
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        //------------------------------
                        // 在庫ゼロ ⇒ ユーザー代替のみ有り
                        //------------------------------
                        // ユーザー代替区分
                        // --- UPD 2011/07/25 ---- >>>>>
                        //if ( userSubstFlg != 0 )
                        //{
                        // --- ADD 2011/11/29 ---- >>>>>
                        if ( userSubstFlg != 0 )
                        {
                        // --- ADD 2011/11/29 ---- >>>>>
                            // ユーザー代替先(無ければ代替元)
                            PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                            row = rowSubst;
                        // --- ADD 2011/11/29 ---- >>>>>
                        }
                        else
                        {
                            // 代替元
                        }
                        // --- ADD 2011/11/29 ---- <<<<<
                        //}
                        //else
                        //{
                        //    // 代替元
                        //}
                        // --- UPD 2011/07/25 ---- <<<<<
                    }
                }
                else
                {
                    //------------------------------
                    // 在庫レコードなし ⇒ ユーザー代替・提供代替
                    //------------------------------
                    // ユーザー代替区分
                    // --- UPD 2011/07/25 ---- >>>>>
                    //if ( userSubstFlg != 0 )
                    //{
                    // --- ADD 2011/11/29 ---- >>>>>
                    if ( userSubstFlg != 0 )
                    {
                    // --- ADD 2011/11/29 ---- <<<<<
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                        if ( rowSubst.Equals( row ) )
                        {
                            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                            rowSubst = _orgDataSet.GetUsrSubst( row );
                            if ( rowSubst.Equals( row ) == false ) // 最新品に対してユーザー代替がある場合
                            {
                                row = rowSubst;
                            }
                            else // ユーザー代替がない場合
                            {
                            }
                        }
                        else // カタログ品に対してユーザー代替がある場合
                        {
                            row = rowSubst;
                        }
                    // --- ADD 2011/11/29 ---- >>>>>
                    }
                    else
                    {
                        // 提供代替先(無ければ代替元)
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                    }
                    // --- ADD 2011/11/29 ---- <<<<<
                    //}
                    //else
                    //{
                    //    // 提供代替先(無ければ代替元)
                    //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                    //}
                    // --- UPD 2011/07/25 ---- <<<<<
                }
                // --- UPD m.suzuki 2011/02/01 ----------<<<<<
                // --- ADD m.suzuki 2011/02/14 ---------->>>>>
                if ( row != null )
                {
                    // 価格取得リストに追加
                    goodsPrimaryKeyList.Add( new PartsInfoDataSet.GoodsPrimaryKey( row.GoodsNo, row.GoodsMakerCd ) );
                }
                // --- ADD m.suzuki 2011/02/14 ----------<<<<<
            }
            // 商品情報が存在する場合は価格計算
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingGoodsPrice(goodsPrimaryKeyList);
            }

        }
        // 2009.02.10 Add <<<
        #endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// ダイアログを表示する。[この画面を開く直前に代替処理があった場合代替元品番から代替先品番への切り替え処理も行う]
        /// </summary>
        /// <returns></returns>
        // 2009.02.19 >>>
        //public new DialogResult ShowDialog()
        public new DialogResult ShowDialog(IWin32Window owner)
        // 2009.02.19 <<<
        {
            // --- ADD 譚洪 2014/09/01 Redmine#43289 -------------------- >>>
            // Thread中、車両情報を取得します
            carInfoSolt = Thread.GetNamedDataSlot(CARINFOSOLT);
            string carInfoStr = string.Empty;
            // Thread中、車両情報を取得できる場合、
            if (Thread.GetData(carInfoSolt) != null)
            {
                CarInfoThreadData carInfoThreadData = (CarInfoThreadData)Thread.GetData(carInfoSolt);


                // 類別(PMの情報)
                this.tNedit_ModelDesignationNo.SetInt(carInfoThreadData.ModelDesignationNo);
                // 番号(PMの情報)
                this.tNedit_CategoryNo.SetInt(carInfoThreadData.CategoryNo);
                // 車台番号(PMとSF計算後の情報)
                this.tEdit_ProduceFrameNo.Text = carInfoThreadData.FrameNo;
                // VINコード「1:国産,2:外車」
                if (carInfoThreadData.FrameNoKubun == 2)
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "VINコード";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(80, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(147, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------<<<<<
                }
                else
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "車台番号";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(67, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(76, 24);
                    // --- DEL 2014/09/22 鹿庭 仕掛一覧 №10598 ------------------------------<<<<<
                }
                // 年式区分(PMの情報)全体初期値設定マスタの「0:西暦　1:和暦（年式）」
                if (carInfoThreadData.FirstEntryDateKubun == 0)
                {
                    // 西暦
                    this.tEdit_Gango.Visible = false;
                    this.tNedit_Wareki_Year.Visible = false;
                    this.tNedit_Sereki_Year.Visible = true;

                    // 西暦
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Sereki_Year.SetInt(carInfoThreadData.FirstEntryDate / 100); // 西暦年
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100);　// 西暦月
                    }
                }
                else
                {
                    // 和歴
                    this.tEdit_Gango.Visible = true;
                    this.tNedit_Wareki_Year.Visible = true;
                    this.tNedit_Sereki_Year.Visible = false;

                    // 和暦
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Wareki_Year.SetInt(GetDateFW(carInfoThreadData.FirstEntryDate * 100 + 1)); // 和暦年
                        this.tEdit_Gango.Text = TDateTime.LongDateToString("GG", carInfoThreadData.FirstEntryDate * 100 + 1); // 和暦元号
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100); // 和暦月
                    }
                }

                // メーカー(PMの情報)
                this.tNedit_MakerCode.SetInt(carInfoThreadData.MakerCode);
                // 車種(PMの情報)(PMの情報)
                this.tNedit_ModelCode.SetInt(carInfoThreadData.ModelCode);
                // 車種サブコード(PMの情報)
                this.tNedit_ModelSubCode.SetInt(carInfoThreadData.ModelSubCode);
                // 車種名(PMの情報)
                this.tEdit_ModelFullName.Text = carInfoThreadData.ModelFullName;
                // 型式(PMとSF計算後の情報)
                this.tEdit_FullModel.Text = carInfoThreadData.FullModel;
                // 備考(PMとSF計算後の情報)
                this.tEdit_Note.Text = carInfoThreadData.Note;
                // 画面元
                this._pgid = carInfoThreadData.Pgid;
            }

            // 検索見積画面のXMLファイルを読む
            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                bool carInfoFlg = Deserialize(PMMIT01010U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // 売伝画面のXMLファイルを読む
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                bool carInfoFlg = Deserialize(MAHNB01001U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // --- ADD 譚洪 2014/09/01 Redmine#43289 -------------------- <<<

            #region [ 表示するデータが1件しかないときの処理－選択し終了 ]
            if ( gridPartsInfo.Rows.Count == 1
                && (substFlg == 0 || gridPartsInfo.Rows[0].Cells[_partsInfo.SubstColumn.ColumnName].Value.Equals( DBNull.Value )) )
            {
                int makerCd = (int)gridPartsInfo.Rows[0].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                // 2009/09/29 >>>
                //string goodsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                // 結合元（カタログ部品）のデータを使用する。
                string goodsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                // 2009/09/29 <<<
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = gridPartsInfo.Rows[0].ListIndex;
                selInfo.RowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                // 2009/09/29 Add >>>
                // 最新品番をセット
                selInfo.RowGoods.NewGoodsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                // 2009/09/29 Add <<<
                // 2009/11/27 Add >>>
                selInfo.RowGoods.JoinSrcPrtsNo= gridPartsInfo.Rows[0].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                // 2009/11/27 Add <<<
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                isDialogShown = false;
                // --- ADD m.suzuki 2010/10/01 ---------->>>>>
                selInfo.ExtractSetParent = IsSetParent( gridPartsInfo.Rows[0] ); // セット親ならtrue
                // --- ADD m.suzuki 2010/10/01 ----------<<<<<

                if (gridPartsInfo.Rows[0].Cells[_partsInfo.JoinColumn.ColumnName].Value.Equals(DBNull.Value)
                        && gridPartsInfo.Rows[0].Cells[_partsInfo.SetColumn.ColumnName].Value.Equals(DBNull.Value))
                {
                    selInfo.Selected = true;

                    // --- UPD m.suzuki 2010/06/24 ---------->>>>>
                    //string filter = string.Format("{0}={1} AND {2}='{3}' ",
                    //    _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                    //    _StockTable.GoodsNoColumn.ColumnName, goodsNo);
                    // 最新品番で在庫をチェックする
                    string filter = string.Format( "{0}={1} AND {2}='{3}' ",
                        _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                        _StockTable.GoodsNoColumn.ColumnName, selInfo.RowGoods.NewGoodsNo );
                    // --- UPD m.suzuki 2010/06/24 ----------<<<<<
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_orgDataSet.ListPriorWarehouse != null) // 優先倉庫指定あり
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            // 2009.02.16 >>>
                            //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            // 2009.02.16 <<<
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                    return DialogResult.OK;
                                }
                            }
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // 優先倉庫にない場合は取寄にする
                    //if (_StockTable.DefaultView.Count > 0)
                    //    selInfo.WarehouseCode = _StockTable.DefaultView[0][_StockTable.WarehouseCodeColumn.ColumnName].ToString();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                }
                else
                {
                    // 2009/12/14 ①　Add >>>
                    if (_orgDataSet.ListPriorWarehouse != null) // 優先倉庫指定あり
                    {
                        string orgFilter = _StockTable.DefaultView.RowFilter;
                        try
                        {
                            // --- UPD m.suzuki 2010/06/24 ---------->>>>>
                            //string filter = string.Format( "{0}={1} AND {2}='{3}' ",
                            //    _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                            //    _StockTable.GoodsNoColumn.ColumnName, godsNo);
                            // 最新品番で在庫をチェックする
                            string filter = string.Format( "{0}={1} AND {2}='{3}' ",
                                _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                                _StockTable.GoodsNoColumn.ColumnName, selInfo.RowGoods.NewGoodsNo );
                            // --- UPD m.suzuki 2010/06/24 ----------<<<<<
                            _StockTable.DefaultView.RowFilter = filter;
                            if (_StockTable.DefaultView.Count > 0)
                            {
                                for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                                {
                                    bool stockExist = false;    // 2010/12/20 Add
                                    string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                                    for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                                    {
                                        if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                        {
                                            selInfo.WarehouseCode = warehouseCd;
                                            // 2010/12/20 Add >>>
                                            stockExist = true;
                                            break;
                                            // 2010/12/20 Add <<<
                                        }
                                    }
                                    if ( stockExist ) break; // 2010/12/20 Add
                                }
                            }
                        }
                        finally
                        {
                            _StockTable.DefaultView.RowFilter = orgFilter;
                        }
                    }
                    // 2009/12/14 ①　Add <<<
                    if (uiControlFlg)
                    {
                        _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;
                        if (gridPartsInfo.Rows[0].Cells[_partsInfo.JoinColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        {
                            _orgDataSet.JoinSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Join;
                        }
                        else
                        {
                            _orgDataSet.SetSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Set;
                        }
                        return DialogResult.Retry;
                    }
                    // 2009/12/14 ②　>>>
                    //_orgDataSet.GoodsNoSel = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                    selInfo.SelectedPartsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                    // 2009/12/14 ②　<<<
                }

                return DialogResult.OK;
            }
            #endregion
            if (_prevRow != null && _prevRow.NewGoodsNo != string.Empty) //代替された部品があるかチェック[NewGoodsNo:代替先品番]
            {
                #region [ 代替選択UIあと処理 ]
                _orgDataSet.GoodsNoSel = string.Empty;
                string partsNo;
                UltraGridRow gridRow = gridPartsInfo.Rows.GetRowWithListIndex(_prevSelInfo.Key);
                // 代替する前の選択した結合先・セット子部品情報クリア
                _prevSelInfo.ListChildGoods.Clear();
                _prevSelInfo.ListChildGoods2.Clear();
                if (_prevSelInfo.ListPlrlSubst.Count > 0)
                    _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1個目は代替品情報なので削除しておく。
                if (_prevRow.NewGoodsNo == _prevRow.GoodsNo) // 代替選択UIで代替として代替元品番を選んだ時の処理
                {
                    _prevRow.NewGoodsNo = string.Empty;
                    gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value = gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value;
                    gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = _prevRow.SelectionState;
                    gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value = _prevRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value = _prevRow.GoodsNo;
                    partsNo = _prevRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNameColumn.ColumnName].Value = _prevRow.GoodsName;
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = _prevRow.PriceTaxInc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxInc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxInc;
                    }
                    else // 総額表示しない（税抜き）
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = _prevRow.PriceTaxExc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxExc;
                    }
                    // 粗利額・粗利率は区分関係なく税抜きで計算
                    gridRow.Cells[_partsInfo.ArarigakuColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc;
                    if (_prevRow.UnitCostTaxExc != 0)
                        gridRow.Cells[_partsInfo.ArarirituColumn.ColumnName].Value = (_prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc) / _prevRow.UnitCostTaxExc;

                    // --- UPD m.suzuki 2010/03/16 ---------->>>>>
                    //gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value = ((_prevRow.QTY != 0) ? _prevRow.QTY : 1);
                    double partsQty = _prevRow.QTY;
                    if ( partsQty == 0 )
                    {
                        // 代替元品番を取得
                        string oldGoodsNo = string.Empty;
                        if ( gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value != null && gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value != DBNull.Value )
                        {
                            try
                            {
                                oldGoodsNo = (string)gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value;
                            }
                            catch
                            {
                                oldGoodsNo = string.Empty;
                            }
                        }
                        if ( !string.IsNullOrEmpty( oldGoodsNo ) )
                        {
                            // 代替元Find
                            PartsInfoDataSet.PartsInfoRow rowPartsInfo =
                                _orgDataSet.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( _prevRow.GoodsMakerCd, oldGoodsNo );
                            if ( rowPartsInfo != null )
                            {
                                // 代替元のQTYで書き換え
                                partsQty = rowPartsInfo.PartsQty;
                            }
                        }
                    }
                    gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value = ((partsQty != 0) ? partsQty : 1);
                    // --- UPD m.suzuki 2010/03/16 ----------<<<<<
                    gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                }
                else                                        // 上記以外代替した時の処理
                {
                    PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_prevRow.GoodsMakerCd, _prevRow.NewGoodsNo);

                    gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value = gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value;
                    gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value = newRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value = newRow.GoodsNo;
                    partsNo = newRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNameColumn.ColumnName].Value = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // 総額表示する（税込み）
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = newRow.PriceTaxInc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = newRow.SalesUnitPriceTaxInc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = newRow.UnitCostTaxInc;
                    }
                    else // 総額表示しない（税抜き）
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = _prevRow.PriceTaxExc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxExc;
                    }
                    // 粗利額・粗利率は区分関係なく税抜きで計算
                    gridRow.Cells[_partsInfo.ArarigakuColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc;
                    if (_prevRow.UnitCostTaxExc != 0)
                        gridRow.Cells[_partsInfo.ArarirituColumn.ColumnName].Value = (_prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc) / _prevRow.UnitCostTaxExc;

                    PartsInfoDataSet.PartsInfoRow rowPartsInfo =
                        _orgDataSet.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(newRow.GoodsMakerCd, newRow.GoodsNo);
                    if (rowPartsInfo != null)
                    {
                        gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value = ((rowPartsInfo.PartsQty != 0) ? rowPartsInfo.PartsQty : 1);
                    }
                    gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                    _prevRow.NewGoodsNo = string.Empty;
                }
                if (SetExists(partsNo, catalogMakerCd))
                {
                    gridRow.Cells[_partsInfo.SetColumn.ColumnName].Value = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                }
                else
                {
                    gridRow.Cells[_partsInfo.SetColumn.ColumnName].Value = DBNull.Value;
                }
                string primePartsNo;
                if (JoinExists(partsNo, catalogMakerCd, out primePartsNo))
                {
                    gridRow.Cells[_partsInfo.JoinColumn.ColumnName].Value = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                    gridRow.Cells[_partsInfo.PrimePartsNoColumn.ColumnName].Value = primePartsNo;
                }
                else
                {
                    gridRow.Cells[_partsInfo.JoinColumn.ColumnName].Value = DBNull.Value;
                    gridRow.Cells[_partsInfo.PrimePartsNoColumn.ColumnName].Value = string.Empty;
                }
                _prevRow.NewGoodsNo = string.Empty;
                _prevRow = null;
                SelectionInfo selInfo = _prevSelInfo;
                if (selInfo != null)
                {
                    UltraGridRow row = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key);
                    row.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = selInfo.WarehouseCode;
                }
                _partsInfo.AcceptChanges();
                #endregion
            }
            else // 代替選択UI以外の画面からの遷移の場合の更新処理を行う。
            {
                //_orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
                SelectionInfo selInfo = _prevSelInfo;
                if (selInfo != null)
                {
                    UltraGridRow row = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key);

                    row.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = selInfo.Selected;
                    row.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = selInfo.WarehouseCode;
                    if (selInfo.Selected)
                    {
                        row.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    }
                    else
                    {
                        row.Cells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                    }
                }
            }
            // 在庫表示更新
            gridPartsInfo_AfterSelectChange(this, null);

            isUserClose = true; // ×ボタン制御フラグ　リセット

            if (gridPartsInfo.Selected.Rows.Count > 0)
            {
                gridPartsInfo.Selected.Rows[0].Activated = true;
                int makerCd;
                string goodsNo;
                if (gridPartsInfo.Selected.Rows[0].Band.ParentBand == null)
                {
                    makerCd = (int)gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                    goodsNo = gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                    //goodsNo = gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);

                    if (row.SelectionComplete)
                    {
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].Appearance.BackColor = Color.DarkKhaki;
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.BackColor = Color.DarkKhaki;
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.BackColor2 = Color.DarkKhaki;
                    }
                    else
                    {
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].Appearance.ResetBackColor();
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor();
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor2();
                    }
                }
            }
            else
            {
                gridPartsInfo.Rows[0].Activate();
                gridPartsInfo.Rows[0].Selected = true;
            }
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        // --- ADD m.suzuki 2010/10/01 ---------->>>>>
        /// <summary>
        /// セット親判定処理
        /// </summary>
        /// <param name="ultraGridRow"></param>
        /// <returns>true: セット親, false: セット親ではない</returns>
        private bool IsSetParent( UltraGridRow ultraGridRow )
        {
            string goodsNo = ultraGridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
            int makerCd = (int)ultraGridRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;

            //----------------------------------------
            // GoodsSet
            //----------------------------------------
            DataRow[] rows;
            rows = _orgDataSet.GoodsSet.Select( string.Format( "{0}='{1}' AND {2}='{3}' ",
                                                                _orgDataSet.GoodsSet.SetMainPartsNoColumn.ColumnName, goodsNo,
                                                                _orgDataSet.GoodsSet.SetMainMakerCdColumn.ColumnName, makerCd ) );
            if ( rows.Length > 0 ) return true;
            
            //----------------------------------------
            // UsrSetParts
            //----------------------------------------
            rows = _orgDataSet.UsrSetParts.Select( string.Format( "{0}='{1}' AND {2}='{3}' ",
                                                                _orgDataSet.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo,
                                                                _orgDataSet.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, makerCd ) );
            if ( rows.Length > 0 ) return true;

            // セット親ではない
            return false;
        }
        // --- ADD m.suzuki 2010/10/01 ----------<<<<<

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>不測の事態を避けるため、サブスレッドの実行中は終了できないようにする</br>
        /// </remarks>
        private void SelectionParts_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (uiControlFlg && e.CloseReason == CloseReason.UserClosing && isUserClose) // PM.NS式制御 ＆ ×ボタン押下
            //{
            //    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, "選択UIを終了しますか？", 0, MessageBoxButtons.YesNo)
            //        == DialogResult.Yes)
            //    {
            //        this.DialogResult = DialogResult.Abort;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void SelectionParts_FormClosed(object sender, FormClosedEventArgs e)
        {

            // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
            bool carInfoFlg = this.pnl_CarInfo.Visible;

            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                Serialize(carInfoFlg, PMMIT01010U_PMKEN08060U_CARINFOSELETED);
            }
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                Serialize(carInfoFlg, MAHNB01001U_PMKEN08060U_CARINFOSELETED);
            }
            // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

            if (this.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            int cnt = gridPartsInfo.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = null;
                UltraGridRow gridRow = gridPartsInfo.Rows[i];

                if (gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    SelectionInfo selInfo = null;
                    if (gridRow.Cells[_partsInfo.UsrSubstColumn.ColumnName].Value.Equals(true)) // ユーザー代替された場合
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString());
                        if (row != null)
                        {
                            selInfo = new SelectionInfo();
                            selInfo.Depth = 0;
                            selInfo.Key = gridRow.ListIndex;
                            selInfo.RowGoods = row;
                            row.JoinSrcPrtsNo = gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            selInfo.WarehouseCode = gridRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value.ToString();
                            if (gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                            {
                                if (uiControlFlg)
                                    selInfo.Selected = true;
                                else if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index
                                        && _orgDataSet.UIKind == SelectUIKind.Subst)
                                    selInfo.Selected = true;
                            }
                            else
                                selInfo.Selected = false;
                            _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                            if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index)
                            {
                                switch (_orgDataSet.UIKind)
                                {
                                    case SelectUIKind.Join:
                                        _orgDataSet.JoinSrcSelInf = selInfo;
                                        // 2009/12/14 ②　>>>
                                        //_orgDataSet.GoodsNoSel = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        selInfo.SelectedPartsNo = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        // 2009/12/14 ②　<<<
                                        break;
                                    case SelectUIKind.Set:
                                        _orgDataSet.SetSrcSelInf = selInfo;
                                        break;
                                    case SelectUIKind.Subst:
                                        _orgDataSet.SubstSrcSelInf = selInfo;
                                        break;
                                }
                                _prevSelInfo = selInfo;
                            }
                        }
                    }
                    else // 通常ケース
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString());
                        if (row != null)
                        {
                            selInfo = new SelectionInfo();
                            selInfo.Depth = 0;
                            selInfo.Key = gridRow.ListIndex;
                            selInfo.RowGoods = row;
                            row.JoinSrcPrtsNo = gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            selInfo.WarehouseCode = gridRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value.ToString();
                            if (gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                            {
                                if (uiControlFlg)
                                    selInfo.Selected = true;
                                else if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index
                                        && _orgDataSet.UIKind == SelectUIKind.Subst)
                                    selInfo.Selected = true;
                            }
                            else
                                selInfo.Selected = false;
                            _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                            if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index)
                            {
                                switch (_orgDataSet.UIKind)
                                {
                                    case SelectUIKind.Join:
                                        _orgDataSet.JoinSrcSelInf = selInfo;
                                        // 2009/12/14 ②　>>>
                                        //_orgDataSet.GoodsNoSel = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        selInfo.SelectedPartsNo = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        // 2009/12/14 ②　<<<
                                        break;
                                    case SelectUIKind.Set:
                                        _orgDataSet.SetSrcSelInf = selInfo;
                                        break;
                                    case SelectUIKind.Subst:
                                        _orgDataSet.SubstSrcSelInf = selInfo;
                                        break;
                                }
                                _prevSelInfo = selInfo;
                            }
                            if (substFlg == 1 && gridRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value.Equals(0) // 在庫がないときは普通の代替処理をするため在庫数チェック
                                && gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.Equals(gridRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                            {   // 代替条件区分が在庫判定有＆在庫あり＆カタログ品番が最新品番と異なるとき
                                row.NewGoodsNo = _partsInfo[i].PartsNo;  // 在庫有無により判定された品番に代替する。
                            }
                            else if (_orgDataSet.UIKind != SelectUIKind.Subst &&
                                gridRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value.Equals(gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                            {
                                // 結合元品番の設定
                                if (gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.Equals(gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value))
                                {   // 代替選択UIで代替した場合
                                    row.NewGoodsNo = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                }
                                else
                                {
                                    row.NewGoodsNo = gridRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                                }
                                row.QTY = (double)gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value;
                            }
                        }
                    }
                    // 2009/12/14 ②　>>>
                    //if (uiControlFlg == false && string.IsNullOrEmpty(_orgDataSet.GoodsNoSel)) // PM7制御で結合画面用品番が未設定？
                    if (uiControlFlg == false && string.IsNullOrEmpty(selInfo.SelectedPartsNo)) // PM7制御で結合画面用品番が未設定？
                    // 2009/12/14 ②　<<<
                    {
                        // 2009/12/14 ②　>>>
                        //_orgDataSet.GoodsNoSel = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key).Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString(); //selInfo.RowGoods.NewGoodsNo;
                        selInfo.SelectedPartsNo = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key).Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                        // 2009/12/14 ②　<<<
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_orgDataSet.ListSelectionInfo, gridRow.ListIndex);
                }
                if (row != null)
                {
                    row.GoodsKindResolved = (int)GoodsKind.Parent;
                    // 2009.02.19 Add >>>
                    if (!string.IsNullOrEmpty(row.NewGoodsNo) && row.NewGoodsNo != row.GoodsNo)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowToProcess = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd,row.NewGoodsNo);
                        if (rowToProcess !=null)
                        {
                            rowToProcess.GoodsKindResolved = (int)GoodsKind.Parent;
                        }
                    }
                    // 2009.02.19 Add <<<
                }
            }
            if (cmbColor.Value != null)
            {
                string filter = string.Format("{0}='{1}'", _orgCar.ColorCdInfo.ColorCodeColumn.ColumnName, cmbColor.Value);
                PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])_orgCar.ColorCdInfo.Select(filter);
                if (colorRows.Length > 0)
                {
                    colorRows[0].SelectionState = true;
                }
            }
            if (cmbTrim.Value != null)
            {
                string filter = string.Format("{0}='{1}'", _orgCar.TrimCdInfo.TrimCodeColumn.ColumnName, cmbTrim.Value);
                PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])_orgCar.TrimCdInfo.Select(filter);
                if (trimRows.Length > 0)
                {
                    trimRows[0].SelectionState = true;
                }
            }
        }

        private void SelectionParts_Shown(object sender, EventArgs e)
        {
            // 先頭行を選択状態にする
            if (gridPartsInfo.Focused == false)
            {
                gridPartsInfo.Focus();
                if (gridPartsInfo.Selected.Rows.Count > 0)
                {
                    gridPartsInfo.Selected.Rows[0].Activate();
                }
                else
                {
                    gridPartsInfo.Rows[0].Activate();
                    gridPartsInfo.Rows[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case Keys.Back:
                    int rowNo;
                    if (rowNoInput.Length > 1)
                    {
                        rowNoInput = rowNoInput.Remove(rowNoInput.Length - 1);
                        rowNo = int.Parse(rowNoInput);
                    }
                    else
                    {
                        rowNoInput = string.Empty;
                        rowNo = 1;
                    }
                    gridPartsInfo.Rows[rowNo - 1].Activate();
                    gridPartsInfo.Rows[rowNo - 1].Selected = true;
                    break;

                case Keys.Delete:
                    rowNoInput = string.Empty;
                    gridPartsInfo.Rows[0].Activate();
                    gridPartsInfo.Rows[0].Selected = true;
                    break;
            }
        }

        private void SelectionParts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                string strRowNo = rowNoInput + e.KeyChar.ToString();

                int rowNo = int.Parse(strRowNo);
                if (rowNo > 0 && rowNo <= gridPartsInfo.Rows.VisibleRowCount)
                {
                    rowNoInput = strRowNo;
                }
                else
                {
                    if (e.KeyChar.Equals('0') == false)
                    {
                        rowNoInput = e.KeyChar.ToString();
                    }
                    rowNo = int.Parse(rowNoInput);
                    if (rowNo > gridPartsInfo.Rows.VisibleRowCount)
                    {
                        rowNoInput = string.Empty;
                        rowNo = 1;
                    }
                }
                if (gridPartsInfo.Focused == false)
                    gridPartsInfo.Select();
                gridPartsInfo.Rows[rowNo - 1].Activate();
                gridPartsInfo.Rows[rowNo - 1].Selected = true;
            }
        }
        #endregion

        #region [ チェック処理 ]
        /// <summary>
        /// カタログ品番の現在庫数チェック
        /// </summary>
        /// <param name="parts">品番</param>
        /// <param name="maker">メーカー</param>
        /// <returns>true:現在庫数あり　false:現在庫なし</returns>
        internal bool CatalogPartsStockCheck(string parts, int maker)
        {
            bool ret = false;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker);
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(rowFilter);
            if (rowStock.Length > 0) // 実は下記のコメントされた処理がもっと正しいと思われるが、PM7に合わせたほうが
                ret = true;          // いいということによりこの処理にする。
            //for (int i = 0; i < rowStock.Length; i++)
            //{
            //    if (rowStock[i].ShipmentPosCnt > 0)
            //    {
            //        ret = true;
            //        break;
            //    }
            //}
            return ret;
        }
        // --- ADD m.suzuki 2011/02/01 ---------->>>>>
        /// <summary>
        /// カタログ品番の現在庫数チェック(2)
        /// </summary>
        /// <param name="parts">品番</param>
        /// <param name="maker">メーカー</param>
        /// <param name="stockCountNotZero"></param>
        /// <returns>true:現在庫数あり　false:現在庫なし</returns>
        /// <br>Update Note: 2011/07/25　譚洪　連番No.702の対応</br>
        /// <br>             代替する（在庫無）の場合、在庫数＞１での条件にして欲しい。品番入力の場合も、在庫条件を参照して欲しい</br>
        internal bool CatalogPartsStockCheck( string parts, int maker, out bool stockCountNotZero )
        {
            bool ret = false;
            stockCountNotZero = false;

            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            if ( _orgDataSet.ListPriorWarehouse == null ||
                 _orgDataSet.ListPriorWarehouse.Count == 0 )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            // --- ADD m.suzuki 2011/02/18 ---------->>>>>
            bool settingFlag = false;
            foreach ( string warehouseCd in _orgDataSet.ListPriorWarehouse )
            {
                if ( !string.IsNullOrEmpty( warehouseCd ) )
                {
                    settingFlag = true;
                    break;
                }
            }
            if ( settingFlag == false )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/18 ----------<<<<<
            string rowFilter = String.Format( "{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker );
            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            rowFilter += " AND (";
            foreach ( string priorWarehouse in _orgDataSet.ListPriorWarehouse )
            {
                if ( string.IsNullOrEmpty( priorWarehouse ) ) continue;
                rowFilter += string.Format( " {0}='{1}' OR", _orgDataSet.Stock.WarehouseCodeColumn.ColumnName, priorWarehouse );
            }
            rowFilter = rowFilter.Remove( rowFilter.Length - 2, 2 );
            rowFilter += ")";
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select( rowFilter );

            if ( rowStock.Length > 0 )
            {
                // 在庫レコードあり
                //ret = true;   // DEL 2011/07/25

                // 在庫数>0のレコード有無を判定
                for ( int i = 0; i < rowStock.Length; i++ )
                {
                    if ( rowStock[i].ShipmentPosCnt > 0 )
                    {
                        // 在庫数>0の在庫が存在する
                        stockCountNotZero = true;
                        // 在庫レコードあり
                        ret = true;   // ADD 2011/07/25
                        break;
                    }
                }
            }

            return ret;
        }
        // --- ADD m.suzuki 2011/02/01 ----------<<<<<

        internal bool SubstExists(string parts, int maker)
        {
            // --- UPD m.suzuki 2011/02/01 ---------->>>>>
            # region // DEL
            //if (substFlg == 0) // 「代替しない」の時は無条件false
            //    return false;
            //string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // 代替選択UIには提供のみ表示
            //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
            //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            //if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
            //{
            //    if (substFlg == 2) // 「在庫判定なし」の時は　代替があるだけでtrue
            //    {
            //        return true;
            //    }
            //    else // 「在庫判定あり」の時は代替あり且つ代替元品の現在庫数なしの時のみtrue
            //    {
            //        if (CatalogPartsStockCheck(parts, maker) == false) // 現在庫なしなら「在庫判定有」でも代替可
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            # endregion

            // 純正代替区分＝「2:代替する(在庫無視)」
            if ( substFlg == 2 )
            {
                // 代替あればTRUE
                string rowFilter = String.Format( "{0}='{1}' AND {2}={3} AND {4} = true", // 代替選択UIには提供のみ表示
                    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
                    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName );
                if ( _orgDataSet.UsrSubstParts.Select( rowFilter ).Length > 0 )
                {
                    return true;
                }
            }
            return false;
            // --- UPD m.suzuki 2011/02/01 ----------<<<<<
        }

        internal bool SetExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrSetParts.ParentGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, maker,
                _orgDataSet.UsrSetParts.PrmSettingFlgColumn.ColumnName);

            if (_orgDataSet.UsrSetParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        internal bool JoinExists(string parts, int maker, out string primePartsNo)
        {
            primePartsNo = string.Empty;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, parts,
                _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, maker,
                _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 DEL
            //PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])_orgDataSet.UsrJoinParts.Select( rowFilter );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
            string sortString = String.Format( "{0}",
                _orgDataSet.UsrJoinParts.JoinDispOrderColumn
                );
            PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])_orgDataSet.UsrJoinParts.Select( rowFilter, sortString );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
            if (rows.Length > 0)
            {
                primePartsNo = rows[0].JoinDestPartsNo;
                return true;
            }
            return false;
        }

        internal bool JoinExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, parts,
                _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, maker,
                _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
            if (_orgDataSet.UsrJoinParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        #endregion
        /*---------------------------------------------------------------------------*/

        private List<String> SetAddCarSpecColumn(UltraGridBand band)
        {
            //UltraGridBand band0 = gridPartsInfo.DisplayLayout.Bands[0];
            //UltraGridBand band = gridPartsInfo.DisplayLayout.Bands[1];
            List<String> ret = new List<string>();
            //追加諸元の表示設定（先頭が表示の場合全て表示する）
            if (_modelPartsDetail[0].AddiCarSpec1 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec1Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec1Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec1Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec1Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec1Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec2 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec2Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec2Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec2Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec2Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec2Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec3 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec3Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec3Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec3Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec3Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec3Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec4 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec4Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec4Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec4Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec4Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec4Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec5 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec5Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec5Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec5Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec5Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec5Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec6 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec6Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec6Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec6Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec6Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec6Column.Caption;
            }
            return ret;
        }

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
                sizeHeader.Height = 20;
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
                sizeHeader.Height = 20;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width, int height)
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

                sizeCell.Height = height;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = height - 2;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
        }

        #region [ ツールバー制御 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // 選択されている行を確定する
                    //if ((!uiControlFlg && _partsInfo.Select("SelectionState = true").Length == 0)
                    //    || (uiControlFlg && _partsInfo.Select("SelectionState = true").Length == 0 // PM.NS式制御の場合自画面及び
                    //        && _orgDataSet.UsrGoodsInfo.Select("SelectionState = true").Length == 0)) // 他画面の選択状態チェック
                    if (enterFlg == 2)
                    {
                        SetSelect(false);
                    }
                    else
                    {
                        if (_partsInfo.Select("SelectionState = true").Length == 0
                           && (_orgDataSet.ListSelectionInfo.Count == 0 ||
                           (_orgDataSet.ListSelectionInfo.ContainsKey(_prevSelInfo.Key) && _orgDataSet.ListSelectionInfo[_prevSelInfo.Key].IsThereSelection == false)))
                        {
                            SetStatusBarText(1, "データの選択がされていません。");
                            break;
                        }
                        DialogResult = DialogResult.OK;
                    }
                    isUserClose = false;
                    break;

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    // 代替がある場合代替UI表示
                    if (substFlg != 0 && activeRow != null)
                    {
                        if (activeRow.Cells[_partsInfo.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                            //string clgpartsNo = activeRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            string clgpartsNo = activeRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow rowClg =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, clgpartsNo);
                            if (rowClg != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = rowClg;
                                activeRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = rowClg;
                                //_prevRow = rowClg;
                                _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                    activeRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                case "Button_Set": // セットがある場合セット選択UI表示                    
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_partsInfo.SetColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                            string partsNo = activeRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                case "Button_Join":
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_partsInfo.JoinColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                            string partsNo = activeRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Join;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                case "Button_SubstOff":
                    //BtnSubstOffProc();
                    break;

                case "BtnExchangeDisp":
                    ExchangeDisp();
                    break;

                case "BtnSpec":
                    if (ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption.Equals("諸元詳細(F3)"))
                        SetSpecVisible();
                    else
                        SetSpecInvisible();
                    break;

                case "BtnClear":
                    ClearCondition();
                    break;

                // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
                case "Button_Car":
                    if (this.pnl_CarInfo.Visible == false)
                    {
                        this.pnl_CarInfo.Visible = true;
                    }
                    else
                    {
                        this.pnl_CarInfo.Visible = false;
                    }

                    this.SetPnlCarInfoVisible(this.pnl_CarInfo.Visible);
                    break;
                // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<
            }
        }

        /// <summary>
        /// 画面表示切替処理
        /// </summary>
        private void ExchangeDisp()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand Band0 = gridPartsInfo.DisplayLayout.Bands[0];
            if (Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden) // 優良品番表示中
            {
                Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.PrimePartsNoColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, 10, 0, 7, 2, 70);

                Band0.Columns[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.NewPrtsNoWithHyphenColumn.ColumnName, 17, 0, 7, 2, 60);
            }
            else                                                                       // カタログ品番表示中
            {
                Band0.Columns[_partsInfo.PrimePartsNoColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.PrimePartsNoColumn.ColumnName, 10, 0, 7, 2, 70);

                Band0.Columns[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.JoinSrcPartsNoColumn.ColumnName, 17, 0, 7, 2, 60);
            }
        }

        /// <summary>
        /// 代替実行可能かチェックする
        /// </summary>
        /// <returns>true：代替不可／false：代替可</returns>
        private bool CheckSubstExecution()
        {
            bool ret = true;
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
            string partsNo = activeRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
            string clgPartsNo = activeRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
            string query = string.Format("{0}={1} AND {2}='{3}'",
                _partsInfo.CatalogPartsMakerCdColumn.ColumnName, makerCd,
                _partsInfo.PartsNoColumn.ColumnName, partsNo);
            dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(query);
            if (rows.Length > 1 && (rows[0].ClgPrtsNoWithHyphen.Equals(clgPartsNo) == false ||
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionComplete == false))
            {
                ret = false;
            }
            //string joinSrcPartsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
            //string partsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
            //int makerCd = (int)gridPartsInfo.ActiveRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
            //string query = String.Format("({0}='{1}' OR {2}='{3}') AND {4}={5}", // 代替選択UIには提供のみ表示
            //    _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, partsNo,
            //    _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, joinSrcPartsNo,
            //    _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, makerCd);
            //PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])_orgDataSet.UsrJoinParts.Select(query);
            //PartsInfoDataSet.UsrGoodsInfoRow rowGoods;
            //for (int i = 0; i < rows.Length; i++)
            //{
            //    rowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rows[i].JoinDestMakerCd, rows[i].JoinDestPartsNo);
            //    if (rowGoods != null && rowGoods.SelectionState)
            //    {
            //        ret = true;
            //        break;
            //    }
            //}
            return ret;
        }

        /*
        /// <summary>代替解除処理</summary>
        private void BtnSubstOffProc()
        {
            if (gridPartsInfo.ActiveRow != null &&
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                int makerCd = (int)gridPartsInfo.ActiveRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                string partsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                string nPartsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                string oldPartsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value.ToString();
                PartsInfoDataSet.UsrGoodsInfoRow newRow =　//　最新品番の部品情報
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, nPartsNo);

                string filter = string.Format("{0}={1} AND {2}='{3}'",
                     _partsInfo.CatalogPartsMakerCdColumn.ColumnName, makerCd,
                     _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, partsNo);

                dsPartsSel.PartsInfoRow[] oldRow = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(filter);
                for (int i = 0; i < oldRow.Length; i++)
                {
                    if (oldRow[i].OldPartsNo == oldPartsNo) // 代替解除する部品か(代替された代替元が一致する部品)
                    {
                        oldRow[i].OldPartsNo = string.Empty;
                        oldRow[i].JoinSrcPartsNo = partsNo; // 代替解除時はカタログ品番が結合元品番
                        oldRow[i].PartsNo = nPartsNo;
                        oldRow[i].PartsName = newRow.GoodsName;
                        oldRow[i].Price = newRow.Price;
                        oldRow[i].Urika = newRow.SalesUnitPrice;
                        oldRow[i].Genka = newRow.UnitCost;
                        oldRow[i].Ararigaku = newRow.SalesUnitPrice - newRow.UnitCost;
                        if (newRow.UnitCost != 0)
                            oldRow[i].Arariritu = oldRow[i].Ararigaku / newRow.UnitCost;
                        PartsInfoDataSet.PartsInfoRow rowPartsInfo =
                            _orgDataSet.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(newRow.GoodsMakerCd, newRow.GoodsNo);
                        if (rowPartsInfo != null)
                        {
                            oldRow[i].PartsQty = rowPartsInfo.PartsQty;
                        }
                        if (SubstExists(oldPartsNo, makerCd)) // 代替はカタログ品番でチェック
                        {
                            oldRow[i].Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                        }
                        if (SetExists(nPartsNo, makerCd)) // セットは最新品番でチェック
                        {
                            oldRow[i].Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                        }
                        if (JoinExists(oldPartsNo, makerCd) || JoinExists(nPartsNo, makerCd)) // 結合は両方でチェック
                        {
                            oldRow[i].Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                        }

                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionState = false;
                        SetButtonState();
                        //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                        break;
                    }
                }
                gridPartsInfo_AfterSelectChange(this, null);
            }
        }
        */
        /// <summary>
        /// 選択行によりボタンの活性・非活性状態を切替します。
        /// </summary>
        private void SetButtonState()
        {
            bool enaSet = false;
            bool enaSubst = false;
            bool enaJoin = false;
            try
            {
                if (gridPartsInfo.ActiveRow == null) return;//
                if (gridPartsInfo.ActiveRow.Band != gridPartsInfo.DisplayLayout.Bands[0]) return;

                enaSet = (gridPartsInfo.ActiveRow.Cells[_partsInfo.SetColumn.ColumnName].Value != System.DBNull.Value);
                enaSubst = (gridPartsInfo.ActiveRow.Cells[_partsInfo.SubstColumn.ColumnName].Value != System.DBNull.Value);
                enaJoin = (gridPartsInfo.ActiveRow.Cells[_partsInfo.JoinColumn.ColumnName].Value != System.DBNull.Value);

            }
            finally
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Enabled = enaSet;
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Enabled = enaJoin;
            }

        }

        /// <summary>
        /// 在庫グリッド選択処理（ユーザー選択→優先倉庫→先頭行の順で選択）
        /// </summary>
        private void SetStockGridSelect()
        {
            if ( gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value.Equals( string.Empty ) == false )
            {
                for ( int i = 0; i < gridStock.Rows.Count; i++ )
                {
                    if ( gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals( gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value ) )
                    {
                        gridStock.Rows[i].Activate();
                        gridStock.Rows[i].Selected = true;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                        SetSelectStock( false, true );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                        return;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                // 該当がなければ先頭にフォーカスのみセット
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            else
            {
                // 在庫未選択(取寄扱い)ならば在庫行の選択解除
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                // 在庫を全て選択解除した後、フォーカスは先頭の在庫
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (_orgDataSet.ListPriorWarehouse != null)
            //{
            //    for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
            //    {
            //        // 2009.02.16 >>>
            //        //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
            //        string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
            //        // 2009.02.16 <<<
            //        for (int j = 0; j < gridStock.Rows.Count; j++)
            //        {
            //            if (gridStock.Rows[j].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value.Equals(warehouseCd))
            //            {
            //                gridStock.Rows[j].Activate();
            //                gridStock.Rows[j].Selected = true;
            //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //                if ( (bool)gridStock.Rows[i].Cells[_StockTable.SelectionStateColumn.ColumnName].Value == false )
            //                {
            //                    SetSelectStock( false );
            //                }
            //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //                return;
            //            }
            //        }
            //    }
            //}
            //if ( gridStock.Rows.Count > 0 )
            //{
            //    gridStock.Rows[0].Activate();
            //    gridStock.Rows[0].Selected = true;
            //    gridStock.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    gridStock.Rows[0].Cells[_StockTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //}
            //else
            //{
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value = 0;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridPartsInfo.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        /// <summary>
        /// 諸元情報表示
        /// </summary>
        private void SetSpecVisible()
        {
            if (gridPartsInfo.ActiveRow != null && gridPartsInfo.ActiveRow.Band.ParentBand == null)
            {
                if (gridPartsInfo.ActiveRow.ChildBands.Count > 0)
                {
                    gridPartsInfo.ActiveRow.ExpandAll();
                    ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "品番単位(F3)";
                }
            }
        }

        /// <summary>
        /// 諸元情報非表示
        /// </summary>
        private void SetSpecInvisible()
        {
            if (gridPartsInfo.ActiveRow != null)
            {
                if (gridPartsInfo.ActiveRow.Band.ParentBand == null)
                {
                    gridPartsInfo.ActiveRow.CollapseAll();
                    ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "諸元詳細(F3)";
                }
                else
                {
                    gridPartsInfo.ActiveRow.ParentRow.CollapseAll();
                    ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "諸元詳細(F3)";
                }
            }
        }
        ///////////////////////////////////////////////////////////

        private void RefreshDataCount()
        {
            int cnt = gridPartsInfo.Rows.VisibleRowCount;
            string cntMsg;
            if (cnt != 0)
            {
                if (gridPartsInfo.Selected.Rows.Count > 0 && gridPartsInfo.Selected.Rows[0].VisibleIndex != -1)
                {
                    cntMsg = string.Format("{0} / {1}", gridPartsInfo.Selected.Rows[0].VisibleIndex + 1, cnt);
                }
                else
                {
                    cntMsg = string.Format("1 / {0}", cnt);
                }
            }
            else
            {
                cntMsg = "0 / 0";
            }
            ToolbarsManager.Tools["LblCntDisplay"].SharedProps.Caption = cntMsg;
        }
        #endregion

        #region [ グリッドイベント処理 ]

        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridPartsInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            
            if (gridPartsInfo.Selected.Rows.Count == 0)
                return;
            if (gridPartsInfo.Selected.Rows[0].Activated == false)
                gridPartsInfo.Selected.Rows[0].Activate();
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            if (activeRow == null || activeRow.Band.ParentBand != null) // 親バンドの場合
                return;
            #region [ 在庫グリッドフィルタリング処理 ]
            string filter = string.Empty;
            try
            {
                filter = string.Format("{0}={1} AND {2}='{3}' ",
                    _StockTable.GoodsMakerCdColumn.ColumnName,
                    activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                    _StockTable.GoodsNoColumn.ColumnName,
                    activeRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value);
            }
            finally
            {
                _StockTable.DefaultView.RowFilter = filter;
            }
            #endregion

            SetStockGridSelect();

            _colorTable.DefaultView.RowFilter = string.Empty;
            _trimTable.DefaultView.RowFilter = string.Empty;
            _equipTable.DefaultView.RowFilter = string.Empty;

            string partsProperNo = activeRow.Cells[_partsInfo.PartsUniqueNoColumn.ColumnName].Text;
            if (IsColorData)
            {
                filter = string.Format("{0} = '{1}'", _colorTable.PartsProperNoColumn.ColumnName, partsProperNo);
                _colorTable.DefaultView.RowFilter = filter;
            }
            if (IsTrimData)
            {
                filter = string.Format("{0} = '{1}'", _trimTable.PartsProperNoColumn.ColumnName, partsProperNo);
                _trimTable.DefaultView.RowFilter = filter;
            }
            if (IsEquipData)
            {
                filter = string.Format("{0} = '{1}'", _equipTable.PartsProperNoColumn.ColumnName, partsProperNo);
                _equipTable.DefaultView.RowFilter = filter;
            }
            if (activeRow.Expanded)
            {
                ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "品番単位(F3)";
            }
            else
            {
                ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "諸元詳細(F3)";
            }
            RefreshDataCount();

            SetButtonState();
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridPartsInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridPartsInfo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    SetSpecVisible();
                    break;

                case Keys.Subtract:
                    SetSpecInvisible();
                    break;

                case Keys.Enter:
                    SetSelect(true);
                    break;

            }
        }

        private void gridPartsInfo_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            if (e.Element.ToString().Contains("CellUIElement") == false)
                return;
            for (int i = 0; i < gridPartsInfo.Rows.Count; i++)
            {
                UltraGridCell processingCell = gridPartsInfo.Rows[i].Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName];
                UltraGridCell processingCell2 = gridPartsInfo.Rows[i].Cells[_partsInfo.PrimePartsNoColumn.ColumnName];
                if (e.Element.Equals(processingCell.GetUIElement()) &&
                    processingCell.Value.Equals(gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                {
                    processedCell = processingCell;

                    string query = string.Format("{0}={1} AND {2}='{3}'",
                        _partsInfo.CatalogPartsMakerCdColumn.ColumnName, catalogMakerCd,
                        _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, processingCell.Value);
                    dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(query);
                    if (rows.Length > 0)
                    {
                        processingCell.Appearance.BackColor = Color.White;
                        processingCell.Appearance.BackColor2 = Color.LightBlue;
                        processingCell.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        processingCell.SelectedAppearance = processingCell.Appearance;
                        panel.Text = string.Format("マウス右クリックでカタログ品番{0}の最新純正部品の情報を見ることが出来ます。",
                            gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value);

                        Infragistics.Win.UIElement element = processingCell.GetUIElement();
                        frmPartsInfo.Year = rows[0].ModelPrtsAdptYm.ToString("####年##月") + " - " + rows[0].ModelPrtsAblsYm.ToString("####年##月");
                        frmPartsInfo.SpecialNote = rows[0].PartsOpNm;
                        frmPartsInfo.Standard = rows[0].StandardName;
                        frmPartsInfo.PartsNo = rows[0].ClgPrtsNoWithHyphen;

                        frmPartsInfo.Left = this.Left + element.Rect.Left + (element.Rect.Width / 4);
                        frmPartsInfo.Top = this.Top + gridPartsInfo.Top + 30 + element.Rect.Top + element.Rect.Height - frmPartsInfo.Height;
                        //frmPartsInfo.Show(this);
                        currentCell = 1;
                    }

                    break;
                }
                else if (e.Element.Equals(processingCell2.GetUIElement())
                    && gridPartsInfo.Rows[i].Cells[_partsInfo.PrimePartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                {
                    processedCell = processingCell2;

                    panel.Text = string.Format("マウス右クリックで品番{0}の全ての結合部品の情報を見ることが出来ます。",
                        gridPartsInfo.Rows[i].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value);
                    processingCell2.Appearance.BackColor = Color.White;
                    processingCell2.Appearance.BackColor2 = Color.LightBlue;
                    processingCell2.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                    processingCell2.SelectedAppearance = processingCell2.Appearance;

                    Infragistics.Win.UIElement element = processingCell2.GetUIElement();
                    frmJoinInfo.Left = this.Left + element.Rect.Left + (element.Rect.Width / 4);
                    frmJoinInfo.Top = this.Top + gridPartsInfo.Top + 30 + element.Rect.Top + element.Rect.Height - frmJoinInfo.Height;
                    if (frmJoinInfo.Top < 0)
                        frmJoinInfo.Top = this.Top + gridPartsInfo.Top + 34 + element.Rect.Top + element.Rect.Height * 2;

                    frmJoinInfo.JoinSrcMakerCd = (int)gridPartsInfo.Rows[i].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                    frmJoinInfo.JoinSrcPartsNo = (string)gridPartsInfo.Rows[i].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value;
                    //frmJoinInfo.Show(this, (int)gridPartsInfo.Rows[i].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                    //    (string)gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value);
                    currentCell = 2;
                    break;
                }
            }
        }

        /// <summary>
        /// マウスカーソルがグリッドの特定セルから離れる際の処理
        /// </summary>
        private void gridPartsInfo_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            GridElementLeaveProcess();
        }

        /// <summary>
        /// マウスカーソルがグリッドの特定セルから離れる際の処理
        /// </summary>
        private void gridPartsInfo_Leave(object sender, EventArgs e)
        {
            GridElementLeaveProcess();
        }

        private void gridPartsInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (currentCell == 1)
                {
                    frmPartsInfo.Show(this);
                }
                else if (currentCell == 2)
                {
                    frmJoinInfo.Show(this);//, (int)gridPartsInfo.Rows[i].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                    // (string)gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value);
                }
                currentCell = 0;
            }
        }

        private void gridCondition_CellListSelect(object sender, CellEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            string filterString = string.Empty;

            RowFilterKind selected = lstEnum[e.Cell.Column.Key];
            if (e.Cell.Text == string.Empty)
            {
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList.Remove(selected);
                }
            }
            else
            {
                filterString = string.Format("{0} = '{1}'", e.Cell.Column.Key, e.Cell.Text);
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList[selected] = filterString;
                }
                else
                {
                    rowFilterList.Add(selected, filterString);
                }
            }

            gridCondition.UpdateData();

            GridFiltering();
        }

        /// <summary>
        /// マウスカーソルがグリッドの特定セルから離れる際の処理
        /// </summary>
        private void GridElementLeaveProcess()
        {
            if (frmPartsInfo.Visible)
            {
                frmPartsInfo.Visible = false;
            }
            if (frmJoinInfo.Visible)
            {
                frmJoinInfo.Visible = false;
            }
            if (processedCell != null)
            {
                processedCell.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.None;
                processedCell.Appearance.ResetBackColor();
                processedCell.SelectedAppearance.Reset();
            }
            panel.Text = "";
            currentCell = 0;
            processedCell = null;
        }

        /// <summary>
        /// Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行を選択状態に／false:なにもしない（マウスダブルクリック時）</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;
                if (activeRow.Band.ParentBand == null // 親バンドか(子バンドは車両情報のため）
                    && enterFlg != 2) // （PM.NS式制御でEnterキーが「次画面」）以外か
                {
                    if (activeCells[_partsInfo.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        activeCells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = false;
                        if (_orgDataSet.ListSelectionInfo.ContainsKey(activeRow.ListIndex)) // 選択解除する部品の結合先などの選択状態解除
                        {
                            _orgDataSet.ListSelectionInfo.Remove(activeRow.ListIndex);
                        }
                    }
                    else
                    {
                        activeCells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                    }
                    _partsInfo.AcceptChanges();
                }
                switch (enterFlg) // エンターキー処理区分
                {
                    case 2: // Enterキーが「次画面」の場合
                        foreach (UltraGridRow row in gridPartsInfo.Rows) // 次画面の時は選択行以外は選択解除する
                        {
                            if (row.Equals(activeRow) == false && row.Cells[_partsInfo.SelImageColumn.ColumnName].Value != DBNull.Value)
                            {
                                row.Cells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                                row.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = false;
                                if (_orgDataSet.ListSelectionInfo.ContainsKey(row.ListIndex))
                                {
                                    _orgDataSet.ListSelectionInfo.Remove(row.ListIndex);
                                }
                            }
                        }
                        if (uiControlFlg) // PM.NS制御
                        {
                            //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                            if (activeCells[_partsInfo.JoinColumn.ColumnName].Value != DBNull.Value) // 結合情報あり
                            {
                                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                                    ((int)activeCells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                     activeCells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Join;
                                DialogResult = DialogResult.Retry;
                            }
                            else if (activeCells[_partsInfo.SetColumn.ColumnName].Value != DBNull.Value) // セット情報あり
                            {
                                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                                    ((int)activeCells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                     activeCells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                            }
                            else
                            {
                                // 2009.02.18 >>>
                                //DialogResult = DialogResult.OK;
                                activeCells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                                activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                DialogResult = DialogResult.OK;
                                return;
                                // 2009.02.18 <<<
                            }
                            //activeCells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            //activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true; // 次画面がない場合選択し終了
                        }
                        else // PM7制御
                        {
                            //activeCells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                            //activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                            DialogResult = DialogResult.OK;
                        }
                        activeCells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                        break;
                    default: // Enterキーが「選択」「PM7」の場合：複数選択動作のため次行を選択状態とする。
                        if (moveFlg)
                        {
                            UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                            if (ugr != null)
                            {
                                ugr.Selected = true;
                                ugr.Activate();
                            }
                        }
                        break;
                }
            }
        }
        #endregion

        #region [ 絞込関連処理 ]
        private void cmbColor_SelectionChanged(object sender, EventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            GridFiltering();
            gridPartsInfo.Select();
        }

        private void cmbTrim_SelectionChanged(object sender, EventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            GridFiltering();
            gridPartsInfo.Select();
        }

        private void GridFiltering()
        {
            string filter = MakeRowFilterString();

            gridPartsInfo.BeginUpdate();
            _partsInfo.DefaultView.RowFilter = filter;
            gridPartsInfo.EndUpdate();
            if (gridPartsInfo.Rows.Count > 0)
            {
                gridPartsInfo.Rows[0].Activate();
                gridPartsInfo.Rows[0].Selected = true;
            }
            //gridPartsInfo_AfterSelectChange(this, null);
            RefreshDataCount();
        }

        /// <summary>
        /// 各種絞込条件によるフィルタリングクエリ作成
        /// </summary>
        /// <returns></returns>
        private string MakeRowFilterString()
        {
            string innerFilter;
            List<long> partsProperNoList = null;
            List<long> properNoLstClrTrm = null;
            #region [ カラー・トリム・装備絞込 ]
            if (IsColorData)
            {
                if (cmbColor.Value != null && !cmbColor.Value.Equals(string.Empty))
                {
                    properNoLstClrTrm = new List<long>();
                    innerFilter = string.Format("{0} = '{1}'", _colorTable.ColorCdInfoNoColumn.ColumnName, cmbColor.Value);

                    PartsInfoDataSet.OfrColorInfoRow[] row = (PartsInfoDataSet.OfrColorInfoRow[])_colorTable.Select(innerFilter);
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                            properNoLstClrTrm.Add(row[i].PartsProperNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------>>>>>
                    // カラー情報なし部品(カラー絞込フラグ＝０)をフィルター条件に追加
                    innerFilter = string.Format("{0} = {1}", _partsInfo.ColorNarrowingFlagColumn.ColumnName, 0);
                    dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(innerFilter);
                    for (int iChk = 0; iChk < rows.Length; iChk++)
                    {
                        if (properNoLstClrTrm.Contains(rows[iChk].PartsUniqueNo) == false)
                            properNoLstClrTrm.Add(rows[iChk].PartsUniqueNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------<<<<<
                }
            }
            if (IsTrimData)
            {
                if (cmbTrim.Value != null && !cmbTrim.Value.Equals(string.Empty))
                {
                    properNoLstClrTrm = new List<long>();
                    innerFilter = string.Format("{0} = '{1}'", _trimTable.TrimCodeColumn.ColumnName, cmbTrim.Value);

                    PartsInfoDataSet.OfrTrimInfoRow[] row = (PartsInfoDataSet.OfrTrimInfoRow[])_trimTable.Select(innerFilter);
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                            properNoLstClrTrm.Add(row[i].PartsProperNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------>>>>>
                    // トリム情報なし部品(トリム絞込フラグ＝０)をフィルター条件に追加
                    innerFilter = string.Format("{0} = {1}", _partsInfo.TrimNarrowingFlagColumn.ColumnName, 0);
                    dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(innerFilter);
                    for (int iChk = 0; iChk < rows.Length; iChk++)
                    {
                        if (properNoLstClrTrm.Contains(rows[iChk].PartsUniqueNo) == false)
                            properNoLstClrTrm.Add(rows[iChk].PartsUniqueNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------<<<<<
                }
            }
            if (IsEquipData)
            {
                innerFilter = string.Empty;
                List<long> lstTmp;

                for (int i = 0; i < gridSoubi.Rows.Count; i++)
                {
                    lstTmp = null;
                    if (gridSoubi.Rows[i].Cells[1].Value.Equals(string.Empty) == false && gridSoubi.Rows[i].Cells[1].Value.Equals(DBNull.Value) == false)
                    {
                        lstTmp = new List<long>();
                        innerFilter = string.Format("{0} = '{1}' AND ({2}='{3}' OR {4}='')",
                            _equipTable.EquipmentGenreNmColumn.ColumnName, gridSoubi.Rows[i].Cells[0].Value,
                            _equipTable.EquipmentNameColumn.ColumnName, gridSoubi.Rows[i].Cells[1].Value.ToString(),
                            _equipTable.EquipmentNameColumn.ColumnName);
                        PartsInfoDataSet.OfrEquipInfoRow[] row = (PartsInfoDataSet.OfrEquipInfoRow[])_equipTable.Select(innerFilter);
                        for (int j = 0; j < row.Length; j++)
                        {
                            lstTmp.Add(row[j].PartsProperNo);
                        }
                    }
                    //>>>2010/03/29
                    else
                    {
                        lstTmp = new List<long>();
                        foreach ( PartsInfoDataSet.OfrEquipInfoRow row in this._equipTable )
                        {
                            lstTmp.Add( row.PartsProperNo );
                        }
                    }
                    //<<<2010/03/29

                    // --- DEL m.suzuki 2011/03/03 ---------->>>>>
                    //if (partsProperNoList == null) // 初回目
                    //    partsProperNoList = lstTmp;
                    //else
                    //    partsProperNoList = GetCommonLongList(lstTmp, partsProperNoList);
                    // --- DEL m.suzuki 2011/03/03 ----------<<<<<

                    //>>>2010/03/29
                    dsPartsSel.ModelPartsDetailDataTable svModelPartsDetail = (dsPartsSel.ModelPartsDetailDataTable)this._modelPartsDetail.Copy();
                    string filter = string.Empty;
                    foreach ( PartsInfoDataSet.OfrEquipInfoRow equipRow in this._equipTable )
                    {
                        // --- ADD m.suzuki 2011/03/16 ---------->>>>>
                        // 今注目しているgridSoubi.Rows[i]と異なる装備情報は無視する。
                        if ( gridSoubi.Rows[i].Cells[0].Value.Equals( DBNull.Value ) ||
                             (string)gridSoubi.Rows[i].Cells[0].Value != equipRow.EquipmentGenreNm )
                        {
                            continue;
                        }
                        // --- ADD m.suzuki 2011/03/16 ----------<<<<<

                        string ffilter = string.Format( "{0} = '{1}'", svModelPartsDetail.PartsUniqueNoColumn, equipRow.PartsProperNo );

                        dsPartsSel.ModelPartsDetailRow[] rows = (dsPartsSel.ModelPartsDetailRow[])svModelPartsDetail.Select( ffilter );

                        if ( rows.Length != 0 )
                        {
                            // --- UPD m.suzuki 2011/03/16 ---------->>>>>
                            //svModelPartsDetail.RemoveModelPartsDetailRow( rows[0] );
                            // 同一PartsProperNoの行も全て除外
                            for ( int deleteIndex = 0; deleteIndex < rows.Length; deleteIndex++ )
                            {
                                svModelPartsDetail.RemoveModelPartsDetailRow( rows[deleteIndex] );
                            }
                            // --- UPD m.suzuki 2011/03/16 ----------<<<<<
                        }
                    }
                    if ( svModelPartsDetail.Count != 0 )
                    {
                        foreach ( dsPartsSel.ModelPartsDetailRow row in svModelPartsDetail )
                        {
                            if ( lstTmp == null ) lstTmp = new List<long>();
                            lstTmp.Add( row.PartsUniqueNo );
                        }
                    }
                    if ( (partsProperNoList != null) && (partsProperNoList.Count == 0) ) partsProperNoList = null;

                    if ( partsProperNoList == null ) // 初回目
                        partsProperNoList = lstTmp;
                    else
                        partsProperNoList = GetCommonLongList( lstTmp, partsProperNoList );
                    //<<<2010/03/29
                }
                partsProperNoList = GetCommonLongList(properNoLstClrTrm, partsProperNoList);
            }
            else // 装備条件なしのときはカラー・トリムのみによる
            {
                partsProperNoList = properNoLstClrTrm;
            }
            #endregion

            bool flg2 = false;  // 車両情報絞込　条件ありフラグ
            List<long> lstProperNoFromCarInfo = new List<long>();

            if (rowFilterList.Values.Count > 0)
            {
                flg2 = true;
                StringBuilder modelFilter = new StringBuilder();
                foreach (string rowFilter in rowFilterList.Values)
                {
                    modelFilter.Append(" AND " + rowFilter);
                }
                modelFilter.Remove(0, 4);
                dsPartsSel.ModelPartsDetailRow[] modelRows = (dsPartsSel.ModelPartsDetailRow[])_modelPartsDetail.Select(modelFilter.ToString());
                for (int i = 0; i < modelRows.Length; i++)
                {
                    if (lstProperNoFromCarInfo.Contains(modelRows[i].PartsUniqueNo) == false)
                        lstProperNoFromCarInfo.Add(modelRows[i].PartsUniqueNo);
                }
            }

            StringBuilder retRowFilter = new StringBuilder();
            retRowFilter.Append(originalRowFilter);

            if (partsProperNoList == null || partsProperNoList.Count > 0) // カラー・トリム・装備情報絞込条件なし　又は　あり且つ部品固有番号リストあり
            {
                if (partsProperNoList == null && flg2 == false) // 車両絞り条件なし　及び　カラートリム装備条件なし
                {
                    this.ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;
                    return originalRowFilter;
                }

                if (retRowFilter.Length > 0)
                {
                    retRowFilter.Append(" AND ");
                }
                retRowFilter.Append("PartsUniqueNo in (");

                if (partsProperNoList != null && partsProperNoList.Count > 0)
                {
                    bool isCondition = false;
                    for (int i = 0; i < partsProperNoList.Count; i++)
                    {
                        if (flg2 == false || (flg2 && lstProperNoFromCarInfo.Contains(partsProperNoList[i])))
                        { // 車両情報絞込　条件なし　又は　あり且つ部品固有番号リストに同一部品固有番号あり
                            retRowFilter.Append(partsProperNoList[i]);
                            retRowFilter.Append(", ");
                            isCondition = true;
                        }
                    }
                    if (isCondition == false)
                        return "false";
                }
                else
                {
                    if (lstProperNoFromCarInfo.Count == 0)
                        return "false";
                    for (int i = 0; i < lstProperNoFromCarInfo.Count; i++)
                    {
                        retRowFilter.Append(lstProperNoFromCarInfo[i]);
                        retRowFilter.Append(", ");
                    }
                }

                retRowFilter.Remove(retRowFilter.Length - 2, 2);
                retRowFilter.Append(")");

                if (flg2) // 車両情報絞込条件のみ　絞込条件クリア対象とする。
                {
                    this.ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = true;
                }
                else
                {
                    this.ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;
                }

            }
            else // 絞込条件に該当する部品なし
            {
                return "false";
            }
            return retRowFilter.ToString();
        }

        /// <summary>
        /// 二つのリストから共通の要素のみのリストを返す。
        /// </summary>
        /// <param name="lst1">リスト１</param>
        /// <param name="lst2">リスト２</param>
        /// <returns>共通要素のリスト</returns>
        private List<long> GetCommonLongList(List<long> lst1, List<long> lst2)
        {
            List<long> lstTmpResult;
            List<long> lstShort;
            List<long> lstLong;
            if (lst1 == null)
            {
                if (lst2 == null)
                    return null;
                else
                    return lst2;
            }
            else
            {
                if (lst2 == null)
                    return lst1;
            }
            lstTmpResult = new List<long>();
            if (lst1.Count > lst2.Count)
            {
                lstShort = lst2;
                lstLong = lst1;
            }
            else
            {
                lstShort = lst1;
                lstLong = lst2;
            }
            for (int j = 0; j < lstShort.Count; j++) // 短いリストの要素が長いリストにあるかチェック
            {
                if (lstLong.Contains(lstShort[j]))
                    lstTmpResult.Add(lstShort[j]);
            }
            return lstTmpResult;
        }

        /// <summary>
        /// 絞込グリッドデータ作成処理
        /// </summary>
        private void MakeConditionGridData()
        {
            List<Infragistics.Win.ValueList> vlist = new List<Infragistics.Win.ValueList>();

            for (int i = 0; i < conditionCellCount; i++)
            {
                vlist.Add(new Infragistics.Win.ValueList());
                vlist[i].ValueListItems.Add("");
            }

            gridCondition.BeginUpdate();

            gridCondition.DisplayLayout.Bands[0].AddNew();

            for (int i = 0; i < conditionCellCount; i++)
            {
                gridCondition.Rows[0].Cells[i].ValueList = vlist[i];
            }
            SetAddCarSpecColumn(gridCondition.DisplayLayout.Bands[0]);

            for (int i = 0; i < _modelPartsDetail.DefaultView.Count; i++)
            {
                dsPartsSel.ModelPartsDetailRow rowToComp = (dsPartsSel.ModelPartsDetailRow)_modelPartsDetail.DefaultView[i].Row;

                if (vlist[0].FindByDataValue(rowToComp.ModelGradeNm) == null)      // 型式グレード名称
                    vlist[0].ValueListItems.Add(rowToComp.ModelGradeNm);
                if (vlist[1].FindByDataValue(rowToComp.BodyName) == null)          // ボディー名称
                    vlist[1].ValueListItems.Add(rowToComp.BodyName);
                if (vlist[2].FindByDataValue(rowToComp.DoorCount) == null)         // ドア数
                    vlist[2].ValueListItems.Add(rowToComp.DoorCount);
                if (vlist[3].FindByDataValue(rowToComp.EngineModelNm) == null)     // エンジン型式名称
                    vlist[3].ValueListItems.Add(rowToComp.EngineModelNm);
                if (vlist[4].FindByDataValue(rowToComp.EngineDisplaceNm) == null)  // 排気量名称
                    vlist[4].ValueListItems.Add(rowToComp.EngineDisplaceNm);
                if (vlist[5].FindByDataValue(rowToComp.EDivNm) == null)            // E区分名称
                    vlist[5].ValueListItems.Add(rowToComp.EDivNm);
                if (vlist[6].FindByDataValue(rowToComp.TransmissionNm) == null)    // ミッション名称
                    vlist[6].ValueListItems.Add(rowToComp.TransmissionNm);
                if (vlist[7].FindByDataValue(rowToComp.ShiftNm) == null)           // シフト名称
                    vlist[7].ValueListItems.Add(rowToComp.ShiftNm);
                if (vlist[8].FindByDataValue(rowToComp.WheelDriveMethodNm) == null)// 駆動方式名称
                    vlist[8].ValueListItems.Add(rowToComp.WheelDriveMethodNm);
                if (vlist[9].FindByDataValue(rowToComp.AddiCarSpec1) == null)      // 追加諸元1
                    vlist[9].ValueListItems.Add(rowToComp.AddiCarSpec1);
                if (vlist[10].FindByDataValue(rowToComp.AddiCarSpec2) == null)      // 追加諸元2
                    vlist[10].ValueListItems.Add(rowToComp.AddiCarSpec2);
                if (vlist[11].FindByDataValue(rowToComp.AddiCarSpec3) == null)      // 追加諸元3
                    vlist[11].ValueListItems.Add(rowToComp.AddiCarSpec3);
                if (vlist[12].FindByDataValue(rowToComp.AddiCarSpec4) == null)      // 追加諸元4
                    vlist[12].ValueListItems.Add(rowToComp.AddiCarSpec4);
                if (vlist[13].FindByDataValue(rowToComp.AddiCarSpec5) == null)      // 追加諸元5
                    vlist[13].ValueListItems.Add(rowToComp.AddiCarSpec5);
                if (vlist[14].FindByDataValue(rowToComp.AddiCarSpec6) == null)      // 追加諸元6
                    vlist[14].ValueListItems.Add(rowToComp.AddiCarSpec6);
            }

            for (int i = 0; i < conditionCellCount; i++)
            {
                if (vlist[i].ValueListItems.Count <= 2) // 絞込条件が1個（先頭空白含めて2個）しかない場合
                {
                    gridCondition.Rows[0].Cells[i].Column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                    gridCondition.Rows[0].Cells[i].Column.CellClickAction = CellClickAction.CellSelect;
                    if (vlist[i].ValueListItems.Count == 2)
                        gridCondition.Rows[0].Cells[i].Value = vlist[i].ValueListItems[1].DisplayText;
                }
            }
            gridCondition.UpdateData();
            gridCondition.EndUpdate();

            UltraGridBand band = gridCondition.DisplayLayout.Bands[0];
            band.UseRowLayout = true;
            band.Columns[colToShow[2]].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // ドア右詰め
            gridCondition.DisplayLayout.Override.RowSelectorWidth = gridPartsInfo.DisplayLayout.Override.RowSelectorWidth;
            ColInfo.SetColInfo(band, colToShow[0], 2, 0, 4, 2, 120);    // ModelGradeNm
            ColInfo.SetColInfo(band, colToShow[1], 6, 0, 4, 2, 120);    // BodyName
            ColInfo.SetColInfo(band, colToShow[2], 10, 0, 2, 2, 60);    // DoorCount
            ColInfo.SetColInfo(band, colToShow[3], 12, 0, 4, 2, 120);   // EngineModelNm
            ColInfo.SetColInfo(band, colToShow[4], 16, 0, 4, 2, 120);    // EngineDisplaceNm
            ColInfo.SetColInfo(band, colToShow[5], 20, 0, 2, 2, 60);   // EDivNm
            ColInfo.SetColInfo(band, colToShow[6], 22, 0, 4, 2, 120);   // TransmissionNm
            ColInfo.SetColInfo(band, colToShow[7], 26, 0, 3, 2, 90);   // ShiftNm
            ColInfo.SetColInfo(band, colToShow[8], 29, 0, 3, 2, 90);   // WheelDriveMethodNm
            // 3段
            int originX = 2;
            if (band.Columns[colToShow[9]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[9], originX, 2, 5, 2, 150);   // 追加諸元1
                originX += 5;
            }
            if (band.Columns[colToShow[10]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[10], originX, 2, 5, 2, 150);   // 追加諸元2
                originX += 5;
            }
            if (band.Columns[colToShow[11]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[11], originX, 2, 5, 2, 150);  // 追加諸元3
                originX += 5;
            }
            if (band.Columns[colToShow[12]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[12], originX, 2, 5, 2, 150);  // 追加諸元4
                originX += 5;
            }
            if (band.Columns[colToShow[13]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[13], originX, 2, 5, 2, 150);  // 追加諸元5
                originX += 5;
            }
            if (band.Columns[colToShow[14]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[14], originX, 2, 5, 2, 120);  // 追加諸元6
            }

            if (originX > 2) // 追加諸元情報がある場合
            {
                gridCondition.Height = 94;
                gridPartsInfo.Top += 48;
                gridPartsInfo.Height -= 48;
            }
            else
            {
                gridCondition.Height = 48;
            }
        }

        private void ClearCondition()
        {
            isSelectChangeDisabled = true;
            //cmbColor.SelectedIndex = 0;
            //cmbTrim.SelectedIndex = 0;
            //cmbEquip.SelectedIndex = 0;
            for (int i = 0; i < conditionCellCount; i++)
            {
                if (gridCondition.Rows[0].Cells[i].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                {
                    gridCondition.Rows[0].Cells[i].Value = string.Empty;
                }
            }
            isSelectChangeDisabled = false;

            gridCondition.UpdateData();
            rowFilterList.Clear();

            GridFiltering();
            isSelectChangeDisabled = true;
            gridPartsInfo.Selected.Rows.Clear();
            isSelectChangeDisabled = false;
            RefreshDataCount();
        }
        #endregion

        private DateTime GetDtFromInt(int dt)
        {
            if (dt <= 101)
                return DateTime.MinValue;
            if (dt > 300000)
                return DateTime.MaxValue;
            int year = dt / 100;
            int month = dt % 100;

            return new DateTime(year, month, 1);
        }

        /// <summary>
        /// ステータスバー設定
        /// </summary>
        /// <param name="mode">0:黒字　1:赤字</param>
        /// <param name="msg">設定するメッセージ</param>
        private void SetStatusBarText(int mode, string msg)
        {
            StatusBar.Panels[0].Text = msg;
            switch (mode)
            {
                case 0: // 0:黒字
                    StatusBar.Panels[0].Appearance.Reset();
                    break;
                case 1: // 1:赤字
                    StatusBar.Panels[0].Appearance.ForeColor = Color.Red;
                    StatusBar.Panels[0].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    break;
            }
        }

        #region [ 在庫グリッドイベント処理 ]
        private void gridStock_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UltraGridBand band = e.Layout.Bands[0];
            band.UseRowLayout = true;
            band.Indentation = 0;

            band.Columns[_StockTable.SelectionStateColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsMakerCdColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsNoColumn.ColumnName].Hidden = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            band.Columns[_StockTable.SortDivColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                // 水平表示位置
                if ((band.Columns[Index].DataType == typeof(int)) ||
                   (band.Columns[Index].DataType == typeof(double)))
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo( band, _StockTable.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo(band, _StockTable.WarehouseCodeColumn.ColumnName, 2, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.WarehouseNameColumn.ColumnName, 5, 0, 100);
            ColInfo.SetColInfo(band, _StockTable.WarehouseShelfNoColumn.ColumnName, 7, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.ShipmentPosCntColumn.ColumnName, 9, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MinimumStockCntColumn.ColumnName, 11, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MaximumStockCntColumn.ColumnName, 13, 0, 50);
            band.Columns[_StockTable.ShipmentPosCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MinimumStockCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MaximumStockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (gridStock.ActiveRow != null && gridPartsInfo.ActiveRow != null)
            //{
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //    //gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    //gridStock.ActiveRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
            //    gridPartsInfo.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if ( gridStock.Selected.Rows.Count > 0 )
            //{
            //    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    gridStock.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
        /// <summary>
        /// 在庫グリッド・Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg"></param>
        private void SetSelectStock( bool moveFlg )
        {
            SetSelectStock( moveFlg, false );
        }
        /// <summary>
        /// 在庫グリッド・Enterキー(ダブルクリック)による選択処理
        /// </summary>
        /// <param name="moveFlg">true:次の行を選択状態に／false:なにもしない（マウスダブルクリック時）</param>
        /// <param name="setTrue">true:選択状態TRUEにする／選択状態を反転する</param>
        private void SetSelectStock( bool moveFlg, bool setTrue )
        {
            UltraGridRow activeRow = gridStock.ActiveRow;
            if ( activeRow != null )
            {
                CellsCollection activeCells = activeRow.Cells;

                // 選択/非選択の切り替え
                if ( activeCells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value && !setTrue )
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                }
                else
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
                }
                _StockTable.AcceptChanges();

                // 他の行は選択解除する
                # region [他の行は選択解除する]
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Equals( activeRow ) == false && row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                # endregion

                // 部品グリッドの在庫情報表示を更新
                # region [部品グリッドの在庫情報表示を更新]
                if ( gridPartsInfo.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // 部品グリッドに在庫情報表示
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // 部品グリッドの在庫情報をクリア
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value = string.Empty;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value = 0;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridPartsInfo.UpdateData();
                }
                # endregion
            }
        }
        /// <summary>
        /// 在庫グリッド・行ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            SetSelectStock( false );
        }
        /// <summary>
        /// 在庫グリッド・キーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_KeyDown( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    SetSelectStock( true );
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
        #endregion

        #region [ 装備絞込処理 ]
        // 装備絞込条件設定画面表示
        private void lblSoubi_Click(object sender, EventArgs e)
        {
            if (pnlGridSoubi.Visible)
            {
                pnlGridSoubi.Visible = false;
            }
            else
            {
                pnlGridSoubi.Visible = true;
                gridSoubi.Select();
            }
        }

        /// <summary>
        /// 装備絞込用グリッド埋め込み
        /// </summary>
        private void FillInSoubiGrid()
        {
            List<string> lst = new List<string>();
            List<string> equipGenreLst = new List<string>();

            Infragistics.Win.ValueList vList = null;
            int count = _equipTable.Count;
            UltraGridBand band = gridSoubi.DisplayLayout.Bands[0];
            gridSoubi.BeginUpdate();
            for (int i = 0; i < count; i++)
            {
                if (lst.Contains(_equipTable[i].EquipmentGenreNm) == false)
                {
                    string filter = string.Format("{0}={1}",
                        _orgCar.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, _equipTable[i].EquipmentGenreCd);
                    _orgCar.CEqpDefDspInfo.DefaultView.RowFilter = filter;
                    vList = new Infragistics.Win.ValueList();
                    vList.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DataValueAndPicture;
                    vList.Key = _equipTable[i].EquipmentGenreNm;
                    for (int j = 0; j < _orgCar.CEqpDefDspInfo.DefaultView.Count; j++)
                    {
                        PMKEN01010E.CEqpDefDspInfoRow row = (PMKEN01010E.CEqpDefDspInfoRow)_orgCar.CEqpDefDspInfo.DefaultView[j].Row;
                        Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem(row.EquipmentName);

                        item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[row.EquipmentIconCode];
                        vList.ValueListItems.Add(item);
                        if (row.SelectionState)
                        {
                            vList.SelectedItem = item;
                        }
                    }
                    lst.Add(vList.Key);

                    UltraGridRow gridRow = band.AddNew();
                    gridRow.Cells[0].Value = _equipTable[i].EquipmentGenreNm;
                    //row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                    gridRow.Cells[1].ValueList = vList;
                    if (vList.SelectedItem != null)
                    {
                        gridRow.Cells[1].Value = vList.SelectedItem.ToString();
                    }
                }
            }
            gridSoubi.EndUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlGridSoubi.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            GridFiltering();
            gridPartsInfo.Select();
            pnlGridSoubi.Visible = false;
        }
        #endregion

        // 2010/03/15 Add >>>
        /// <summary>
        /// コンストラクタでの初期化処理メイン
        /// </summary>
        /// <param name="dsCar"></param>
        /// <param name="dsParts"></param>
        public void InitialMain2(PMKEN01010E dsCar, PartsInfoDataSet dsParts)
        {
            _orgCar = dsCar;
            _orgDataSet = dsParts;
            SearchCntSetWork cond = dsParts.SearchCondition.SearchCntSetWork;
            //eraNameDispDiv = Convert.ToBoolean(cond.EraNameDispCd1); // 0:西暦／1:和暦
            //uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7スタイル／1:PM.NSスタイル
            //>>>2012/02/09
            //substFlg = cond.SubstCondDivCd; // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
            substFlg = 0;
            //<<<2012/02/09
            userSubstFlg = cond.SubstApplyDivCd;
            //enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:総額表示しない（税抜き）,1:総額表示する（税込み）
            _dsParts = new dsPartsSel();
            _partsInfo = _dsParts.PartsInfo;
            _StockTable = _dsParts.Stock;
            _modelPartsDetail = _dsParts.ModelPartsDetail;
            _selectIndex = dsParts.SelectIndex; // 2011/09/04

            this.InitialThread1(false);
            this.InitialThread2();

            originalRowFilter = _orgDataSet.PartsInfo.DefaultView.RowFilter;
            _partsInfo.DefaultView.Sort = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                        _partsInfo.SeriesModelColumn.ColumnName,
                                                        _partsInfo.CategorySignModelColumn.ColumnName,
                                                        _partsInfo.ExhaustGasSignColumn.ColumnName,
                                                        _partsInfo.FullModelFixedNoColumn.ColumnName,
                                                        _partsInfo.PartsQtyColumn.ColumnName,
                                                        _partsInfo.PartsOpNmColumn.ColumnName,
                                                        _partsInfo.NewPrtsNoWithHyphenColumn.ColumnName,
                                                        _partsInfo.CatalogPartsMakerCdColumn.ColumnName,
                                                        _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName
                                                        );

            #region カラー・トリム・装備での絞り込み

            IsColorData = _colorTable != null && _colorTable.Count >= 1;
            IsTrimData = _trimTable != null && _trimTable.Count >= 1;
            IsEquipData = _equipTable != null && _equipTable.Count >= 1;
            string colorCode = string.Empty;
            string trimCode = string.Empty;
            if (IsColorData)
            {
                PMKEN01010E.ColorCdInfoRow[] row = (PMKEN01010E.ColorCdInfoRow[])_orgCar.ColorCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    colorCode = row[0].ColorCode;
                }
            }
            if (IsTrimData)
            {
                PMKEN01010E.TrimCdInfoRow[] row = (PMKEN01010E.TrimCdInfoRow[])_orgCar.TrimCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    trimCode = row[0].TrimCode;
                }
            }
            if (IsEquipData)
            {
                //FillInSoubiGrid();
                //GridFiltering();
            }

            List<long> properNoLstClrTrm = null;
            string innerFilter = string.Empty;
            if (IsColorData && !string.IsNullOrEmpty(colorCode))
            {
                properNoLstClrTrm = new List<long>();
                innerFilter = string.Format("{0} = '{1}'", _colorTable.ColorCdInfoNoColumn.ColumnName, colorCode);

                PartsInfoDataSet.OfrColorInfoRow[] row = (PartsInfoDataSet.OfrColorInfoRow[])_colorTable.Select(innerFilter);
                for (int i = 0; i < row.Length; i++)
                {
                    if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                        properNoLstClrTrm.Add(row[i].PartsProperNo);
                }
            }

            if (IsTrimData && !string.IsNullOrEmpty(trimCode))
            {
                properNoLstClrTrm = new List<long>();
                innerFilter = string.Format("{0} = '{1}'", _trimTable.TrimCodeColumn.ColumnName, trimCode);

                PartsInfoDataSet.OfrTrimInfoRow[] row = (PartsInfoDataSet.OfrTrimInfoRow[])_trimTable.Select(innerFilter);
                for (int i = 0; i < row.Length; i++)
                {
                    if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                        properNoLstClrTrm.Add(row[i].PartsProperNo);
                }
            }

            if (properNoLstClrTrm != null && properNoLstClrTrm.Count > 0)
            {
                StringBuilder retRowFilter = new StringBuilder();
                retRowFilter.Append(originalRowFilter);

                if (retRowFilter.Length > 0)
                {
                    retRowFilter.Append(" AND ");
                }
                retRowFilter.Append("PartsUniqueNo in (");

                foreach (long no in properNoLstClrTrm)
                {
                    retRowFilter.Append(no);
                    retRowFilter.Append(", ");
                }
                retRowFilter.Remove(retRowFilter.Length - 2, 2);
                retRowFilter.Append(")");

                _partsInfo.DefaultView.RowFilter = retRowFilter.ToString();
            }
            #endregion

        }

        /// <summary>
        /// 部品選択
        /// </summary>
        /// <returns></returns>
        public  DialogResult SelectParts()
        {
            DataView dv = _partsInfo.DefaultView;

            //>>>2011/09/04
            if (_selectIndex != -1) return SelectParts(_selectIndex);
            //<<<2011/09/04

            #region 純正部品が１つしかない
            if (dv.Count == 1
                // 2011/03/08 >>>
                //&& ( substFlg == 0 || dv[0][_partsInfo.SubstColumn.ColumnName] == null ))
                && ( substFlg == 0 || dv[0][_partsInfo.SubstColumn.ColumnName].Equals(DBNull.Value) ))
                // 2011/03/08 <<<
            {

                int makerCd = (int)dv[0][_partsInfo.CatalogPartsMakerCdColumn.ColumnName];
                // 結合元（カタログ部品）のデータを使用する。
                string goodsNo = (string)dv[0][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = 0;
                selInfo.RowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                // 最新品番をセット
                selInfo.RowGoods.NewGoodsNo = (string)dv[0][_partsInfo.PartsNoColumn.ColumnName];
                selInfo.RowGoods.JoinSrcPrtsNo = (string)dv[0][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                selInfo.RowGoods.SelectionState = true;
                selInfo.Selected = true;
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                isDialogShown = false;

                // 結合情報がある場合はセット
                if (dv[0][_partsInfo.JoinColumn.ColumnName] != null)
                {
                    _orgDataSet.JoinSrcSelInf = selInfo;
                    _orgDataSet.UIKind = SelectUIKind.Join;
                }
                _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                #region 倉庫の設定
                string orgFilter = _StockTable.DefaultView.RowFilter;
                try
                {
                    // 2011/03/15 >>>
                    //string filter = string.Format("{0}={1} AND {2}='{3}' ",
                    //    _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                    //    _StockTable.GoodsNoColumn.ColumnName, goodsNo);
                    // 最新品番で在庫をチェックする
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                        _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                        _StockTable.GoodsNoColumn.ColumnName, selInfo.RowGoods.NewGoodsNo);
                    // 2011/03/15 <<<
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_StockTable.DefaultView.Count > 0)
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            bool stockExist = false;    // 2010/12/20 Add
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                    // 2010/12/20 Add >>>
                                    stockExist = true;
                                    break;
                                    // 2010/12/20 Add <<<
                                }
                            }
                            if ( stockExist ) break; // 2010/12/20 Add
                        }
                    }
                }
                finally
                {
                    _StockTable.DefaultView.RowFilter = orgFilter;
                }
                #endregion

                #region おそらく不要
                //if (dv[0][_partsInfo.JoinColumn.ColumnName] != null || dv[0][_partsInfo.SetColumn.ColumnName] != null)
                //{
                //    if (uiControlFlg)
                //    {
                //        _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                //        if (dv[0][_partsInfo.JoinColumn.ColumnName] != null)
                //        {
                //            _orgDataSet.JoinSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Join;
                //        }
                //        else
                //        {
                //            _orgDataSet.SetSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Set;
                //        }
                //    }
                //    else
                //    {
                //        selInfo.SelectedPartsNo = (string)dv[0][_partsInfo.PartsNoColumn.ColumnName];
                //    }
                //}
                #endregion

                return DialogResult.OK;
            }
            #endregion

            return DialogResult.None;
        }
        // 2010/03/15 Add <<<

        //>>>2011/09/04
        /// <summary>
        /// 部品選択(純正Index指定)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DialogResult SelectParts(int index)
        {
            DataView dv = _partsInfo.DefaultView;

            // 2012/09/14 ADD TAKAGAWA SCM障害改良一覧№253 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (dv.Count <= index) return DialogResult.None;
            // 2012/09/14 ADD TAKAGAWA SCM障害改良一覧№253 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #region 純正部品をIndex指定
            if (substFlg == 0 || dv[index][_partsInfo.SubstColumn.ColumnName] == null)
            {
                int makerCd = (int)dv[index][_partsInfo.CatalogPartsMakerCdColumn.ColumnName];
                // 結合元（カタログ部品）のデータを使用する。
                string goodsNo = (string)dv[index][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = 0;
                selInfo.RowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                // 最新品番をセット
                selInfo.RowGoods.NewGoodsNo = (string)dv[index][_partsInfo.PartsNoColumn.ColumnName];
                selInfo.RowGoods.JoinSrcPrtsNo = (string)dv[index][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                selInfo.RowGoods.SelectionState = true;
                selInfo.Selected = true;
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                isDialogShown = false;

                // 結合情報がある場合はセット
                if (dv[index][_partsInfo.JoinColumn.ColumnName] != null)
                {
                    _orgDataSet.JoinSrcSelInf = selInfo;
                    _orgDataSet.UIKind = SelectUIKind.Join;
                }
                _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                #region 倉庫の設定
                string orgFilter = _StockTable.DefaultView.RowFilter;
                try
                {
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                        _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                        _StockTable.GoodsNoColumn.ColumnName, goodsNo);
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_StockTable.DefaultView.Count > 0)
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    _StockTable.DefaultView.RowFilter = orgFilter;
                }
                #endregion

                #region おそらく不要
                //if (dv[0][_partsInfo.JoinColumn.ColumnName] != null || dv[0][_partsInfo.SetColumn.ColumnName] != null)
                //{
                //    if (uiControlFlg)
                //    {
                //        _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                //        if (dv[0][_partsInfo.JoinColumn.ColumnName] != null)
                //        {
                //            _orgDataSet.JoinSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Join;
                //        }
                //        else
                //        {
                //            _orgDataSet.SetSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Set;
                //        }
                //    }
                //    else
                //    {
                //        selInfo.SelectedPartsNo = (string)dv[0][_partsInfo.PartsNoColumn.ColumnName];
                //    }
                //}
                #endregion

                return DialogResult.OK;
            }
            #endregion

            return DialogResult.None;
        }
        //<<<2011/09/04

        // --- ADD m.suzuki 2010/10/26 ---------->>>>>
        # region [諸元情報]
        /// <summary>
        /// 諸元情報グリッドへの進入時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCondition_Enter( object sender, EventArgs e )
        {
            // 強制的に部品グリッドにフォーカス移動する
            gridPartsInfo.Focus();
        }
        # endregion

        # region [カラー／トリム／装備]
        /// <summary>
        /// 装備（カラー／トリム／装備）コンテナ進入時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Enter( object sender, EventArgs e )
        {
            if ( ColorGrid.Rows.Count > 0 )
            {
                // カラー
                SetGridFocus( ColorGrid );
            }
            else if ( TrimGrid.Rows.Count > 0 )
            {
                // トリム
                SetGridFocus( TrimGrid );
            }
            else if ( EquipGrid.Rows.Count > 0 )
            {
                // 装備
                SetGridFocus( EquipGrid );
            }
            else
            {
                // 強制的に部品グリッドにフォーカス移動する
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// グリッドへのフォーカスセット処理（カラー・トリム・装備 用）
        /// </summary>
        /// <param name="grid"></param>
        private void SetGridFocus( UltraGrid grid )
        {
            // 更新開始 >>>
            grid.BeginUpdate();

            // グリッド自体にフォーカス移動
            grid.Focus();

            // 行をアクティブにする
            if ( grid.ActiveRow == null )
            {
                grid.Rows[0].Activate();
            }

            // 行を選択状態にする
            if ( grid.ActiveRow != null )
            {
                grid.ActiveRow.Selected = true;
            }

            // 更新終了<<<
            grid.EndUpdate();
        }
        /// <summary>
        /// カラーグリッド進入時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorGrid_Enter( object sender, EventArgs e )
        {
            if ( ColorGrid.Rows.Count == 0 )
            {
                // 強制的に部品グリッドにフォーカス移動する
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// カラーグリッド脱出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorGrid_Leave( object sender, EventArgs e )
        {
            if ( ColorGrid.Rows.Count > 0 && ColorGrid.ActiveRow != null )
            {
                ColorGrid.ActiveRow.Selected = false;
                ColorGrid.ActiveRow = null;
            }
        }
        /// <summary>
        /// トリムグリッド進入時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrimGrid_Enter( object sender, EventArgs e )
        {
            if ( TrimGrid.Rows.Count == 0 )
            {
                // 強制的に部品グリッドにフォーカス移動する
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// トリムグリッド脱出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrimGrid_Leave( object sender, EventArgs e )
        {
            if ( TrimGrid.Rows.Count > 0 && TrimGrid.ActiveRow != null )
            {
                TrimGrid.ActiveRow.Selected = false;
                TrimGrid.ActiveRow = null;
            }
        }
        /// <summary>
        /// 装備グリッド進入時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipGrid_Enter( object sender, EventArgs e )
        {
            if ( EquipGrid.Rows.Count == 0 )
            {
                // 強制的に部品グリッドにフォーカス移動する
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// 装備グリッド脱出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipGrid_Leave( object sender, EventArgs e )
        {
            if ( EquipGrid.Rows.Count > 0 && EquipGrid.ActiveRow != null )
            {
                EquipGrid.ActiveRow.Selected = false;
                EquipGrid.ActiveRow = null;
            }
        }
        # endregion

        # region [在庫]
        /// <summary>
        /// 在庫グリッド進入時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_Enter( object sender, EventArgs e )
        {
            if ( gridStock.Rows.Count == 0 )
            {
                // 強制的に部品グリッドにフォーカス移動する
                gridPartsInfo.Focus();
            }
        }
        # endregion
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<

        // ADD 譚洪 2014/09/01 FOR Redmine#43289　--- >>>
        /// <summary>
        /// XMLファイルを保存処理
        /// </summary>
        /// <param name="carInfoFlg">車両情報ボタン表示フラグ</param>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : XMLファイルを保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private void Serialize(bool carInfoFlg, string fileName)
        {
            UserSettingController.SerializeUserSetting(carInfoFlg, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
        }


        /// <summary>
        /// XMLファイルを読み処理
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : XMLファイルを読み処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private bool Deserialize(string fileName)
        {
            bool carInfoFlg = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
            {
                try
                {
                    carInfoFlg = UserSettingController.DeserializeUserSetting<bool>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
            }

            return carInfoFlg;
        }

        /// <summary>
        /// 車両情報を表示切替処理
        /// </summary>
        private void SetPnlCarInfoVisible(bool carInfoVisible)
        {
            if (carInfoVisible)
            {
                this.gridCondition.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height + this.pnl_CarInfo.Height);
                this.gridPartsInfo.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height + this.gridCondition.Height + this.pnl_CarInfo.Height);
                // --- ADD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------>>>>>
                this.gridPartsInfo.Height = panel1.Height - (this.ultraGroupBox1.Height + this.pnl_CarInfo.Height + this.gridCondition.Height);
                // --- ADD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------<<<<<
            }
            else
            {
                this.gridCondition.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height);
                this.gridPartsInfo.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height + this.gridCondition.Height);
                // --- UPD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------>>>>>
                //this.gridPartsInfo.Height = this.gridPartsInfo.Height + this.pnl_CarInfo.Height;
                this.gridPartsInfo.Height = panel1.Height - (this.ultraGroupBox1.Height + this.gridCondition.Height);
                // --- UPD 2014/11/04 T.Miyamoto 仕掛一覧 №2577 ------------------------------<<<<<
            }
        }

        /// <summary>
        /// 和暦年取得処理（H20の"20"のみを取得する）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDateFW(int date)
        {
            // 和暦略号を取得
            string date_gg = TDateTime.LongDateToString("gg", date);  // H
            string date_exggyy = TDateTime.LongDateToString("exggyy", date);  // H20

            // "H20" から "H" を取り除いて "20" を取得する
            return ToInt(date_exggyy.Substring(date_gg.Length, date_exggyy.Length - date_gg.Length));

        }

        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<
    }
}