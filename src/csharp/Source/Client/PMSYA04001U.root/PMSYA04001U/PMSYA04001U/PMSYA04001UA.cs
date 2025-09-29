//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌出荷部品表示
// プログラム概要   : 車輌出荷部品表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2009/10/20  修正内容 : PM-2-A Redmin#727、#567対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2009/11/04  修正内容 : PM-2-A Redmin#1105対応
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : wangf
// 修 正 日  2011/08/02  修正内容 : NSユーザー改良要望一覧_20110629_PM7相違_連番824によって、画面プロパティ改修
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 凌小青
// 修 正 日  2012/08/09  修正内容 : 2012/09/12配信分、Redmine#31532 車輌出荷部品表示 ソート順不正
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/25  修正内容 : SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正
//----------------------------------------------------------------------------//
// 管理番号  11470076-00 作成担当  譚洪
// 作 成 日  2019/01/08 修正内容  新元号の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Globarization;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 車輌出荷部品表示 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌出荷部品表示のフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.09.10</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/20 呉元嘯</br>
    /// <br>             Redmin#727、#567対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/04 MANTIS 0014544 呉元嘯</br>
    /// <br>             Redmin#1105対応</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/02 wangf (ソース記述なし)</br>
    /// <br>             NSユーザー改良要望一覧_20110629_PM7相違_連番824によって、画面プロパティ改修</br>
    /// <br>Update Note: 2012/08/09 凌小青</br>
    /// <br>             2012/09/12配信分、Redmine#31532 車輌出荷部品表示 ソート順不正</br>
    /// <br>Update Note: SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
    /// <br>Programmer : FSI厚川 宏</br>
    /// <br>Date       : 2013/03/25</br>
    /// </remarks>
    public partial class PMSYA04001UA : Form
    {
        #region ■ Const Memebers ■

        #region 車輌検索グリッド
        // テーブル名称
        private const string CARSEARCH_TABLE = "CarSearchTable";
        // グリッド用
        private const string CUSTOMERSUBNAME_KEY = "CustomerSubName";
        private const string MNGNO_KEY = "CarMngNo";
        private const string ENGINEMODEL_KEY = "EngineModel";
        private const string CARADDINFO1_KEY = "CarAddInfo1";
        private const string CARADDINFO2_KEY = "CarAddInfo2";
        private const string INSERTNO_KEY = "InsertNo";
        private const string MILEAGE_KEY = "Mileage";
        private const string CARINSPECTYEAR_KEY = "CarInspectYear";
        private const string ENTRYDATE_KEY = "EntryDate";
        private const string LTIMECIMATDATE_KEY = "LTimeCiMatDate";
        private const string INSPECTMATURITYDATE_KEY = "InspectMaturityDate";
        private const string CARNOTE_KEY = "CarNote";

        // 画面表示用
        private const string CUSTOMERCODE_KEY = "CustomerCode";
        private const string KINDMODEL_KEY = "KindModel";
        private const string MODELDESIGNATIONNO_KEY = "ModelDesignationNo";
        private const string CATEGORYNO_KEY = "CategoryNo";
        private const string ENGINEMODELNM_KEY = "EngineModelNm";
        private const string MAKERCODE_KEY = "MakerCode";
        private const string MODELCODE_KEY = "ModelCode";
        private const string MODELSUBCODE_KEY = "ModelSubCode";
        private const string MODELFULLNAME_KEY = "ModelFullName";
        private const string FULLMODEL_KEY = "FullModel";
        private const string FIRSTENTRYDATE_KEY = "FirstEntryDate";
        private const string STEDPRODUCETYPEOFYEAR_KEY = "StEdProduceTypeOfYear";
        private const string FRAMENO_KEY = "FrameNo";
        private const string STEDPRODUCEFRAMENO_KEY = "StEdProduceFrameNo";
        private const string COLORCODE_KEY = "ColorCode";
        private const string TRIMCODE_KEY = "TrimCode";
        private const string MODELGRADENM_KEY = "ModelGradeNm";
        private const string BODYNAME_KEY = "BodyName";
        private const string DOORCOUNT_KEY = "DoorCount";
        private const string ENGINEDISPLACENM_KEY = "EngineDisplaceNm";
        private const string EDIVNM_KEY = "EDivNm";
        private const string TRANSMISSIONNM_KEY = "TransmissionNm";
        private const string WHEELDRIVEMETHODNM_KEY = "WheelDriveMethodNm";
        private const string SHIFTNM_KEY = "ShiftNm";
        private const string ADDICARSPECTITLE1_KEY = "AddiCarSpecTitle1";
        private const string ADDICARSPECTITLE2_KEY = "AddiCarSpecTitle2";
        private const string ADDICARSPECTITLE3_KEY = "AddiCarSpecTitle3";
        private const string ADDICARSPECTITLE4_KEY = "AddiCarSpecTitle4";
        private const string ADDICARSPECTITLE5_KEY = "AddiCarSpecTitle5";
        private const string ADDICARSPECTITLE6_KEY = "AddiCarSpecTitle6";
        private const string ADDICARSPEC1_KEY = "AddiCarSpec1";
        private const string ADDICARSPEC2_KEY = "AddiCarSpec2";
        private const string ADDICARSPEC3_KEY = "AddiCarSpec3";
        private const string ADDICARSPEC4_KEY = "AddiCarSpec4";
        private const string ADDICARSPEC5_KEY = "AddiCarSpec5";
        private const string ADDICARSPEC6_KEY = "AddiCarSpec6";
        private const string DOMESTICFOREIGNCODERF_KEY = "DomesticForeignCode";　// ADD 2013/03/25        

        // テキスト用
        private const string COLORNAME1_KEY = "ColorName1";
        private const string TRIMNAME_KEY = "TrimName";
        private const string NUMBERPLATE1CODE_KEY = "NumberPlate1Code";
        private const string NUMBERPLATE1NAME_KEY = "NumberPlate1Name";
        private const string NUMBERPLATE2_KEY = "NumberPlate2";
        private const string NUMBERPLATE3_KEY = "NumberPlate3";
        private const string NUMBERPLATE4_KEY = "NumberPlate4";

        // KEY
        private const string CUSTOMERSUBNAME_TITLE = "得意先";
        private const string MNGNO_TITLE = "管理番号";
        private const string ENGINEMODEL_TITLE = "原動機型式";
        private const string CARADDINFO1_TITLE = "追加情報１";
        private const string CARADDINFO2_TITLE = "追加情報２";
        private const string INSERTNO_TITLE = "登録番号";
        private const string MILEAGE_TITLE = "走行距離";
        private const string CARINSPECTYEAR_TITLE = "車検期間";
        private const string ENTRYDATE_TITLE = "登録年月日";
        private const string LTIMECIMATDATE_TITLE = "前回車検日";
        private const string INSPECTMATURITYDATE_TITLE = "次回車検日";
        private const string CARNOTE_TITLE = "車輌備考";
        private const string CUSTOMERCODE_TITLE = "得意先コード";
        private const string KINDMODEL_TITLE = "型式";
        private const string MODELDESIGNATIONNO_TITLE = "型式指定番号";
        private const string CATEGORYNO_TITLE = "類別番号";
        private const string ENGINEMODELNM_TITLE = "エンジン型式";
        private const string MAKERCODE_TITLE = "車種（メーカーコード）";
        private const string MODELCODE_TITLE = "車種（車種コード）";
        private const string MODELSUBCODE_TITLE = "車種（呼称コード）";
        private const string MODELHALFNAME_TITLE = "車種名称";
        private const string FULLMODEL_TITLE = "型式（フル型）";
        private const string FIRSTENTRYDATE_TITLE = "年式";
        private const string STEDPRODUCETYPEOFYEAR_TITLE = "(生産年式 開始-終了)";
        private const string FRAMENO_TITLE = "車台番号";
        private const string STEDPRODUCEFRAMENO_TITLE = "(車台番号 開始-終了)";
        private const string COLORCODE_TITLE = "カラー";
        private const string TRIMCODE_TITLE = "トリム";
        private const string MODELGRADENM_TITLE = "型式グレード名称";
        private const string BODYNAME_TITLE = "ボディー名称";
        private const string DOORCOUNT_TITLE = "ドア数";
        private const string ENGINEDISPLACENM_TITLE = "排気量名称";
        private const string EDIVNM_TITLE = "E区分名称";
        private const string TRANSMISSIONNM_TITLE = "ミッション名称";
        private const string WHEELDRIVEMETHODNM_TITLE = "駆動方式名称";
        private const string SHIFTNM_TITLE = "シフト名称";
        private const string ADDICARSPECTITLE1_TITLE = "追加諸元タイトル１";
        private const string ADDICARSPECTITLE2_TITLE = "追加諸元タイトル２";
        private const string ADDICARSPECTITLE3_TITLE = "追加諸元タイトル３";
        private const string ADDICARSPECTITLE4_TITLE = "追加諸元タイトル４";
        private const string ADDICARSPECTITLE5_TITLE = "追加諸元タイトル５";
        private const string ADDICARSPECTITLE6_TITLE = "追加諸元タイトル６";
        private const string ADDICARSPEC1_TITLE = "追加諸元１";
        private const string ADDICARSPEC2_TITLE = "追加諸元２";
        private const string ADDICARSPEC3_TITLE = "追加諸元３";
        private const string ADDICARSPEC4_TITLE = "追加諸元４";
        private const string ADDICARSPEC5_TITLE = "追加諸元５";
        private const string ADDICARSPEC6_TITLE = "追加諸元６";
        private const string COLORNAME1_TITLE = "カラー名称1";
        private const string TRIMNAME_TITLE = "トリム名称";
        private const string NUMBERPLATE1CODE_TITLE = "陸運事務所番号";
        private const string NUMBERPLATE1NAME_TITLE = "陸運事務所名称";
        private const string NUMBERPLATE2_TITLE = "車両登録番号（種別）";
        private const string NUMBERPLATE3_TITLE = "車両登録番号（カナ）";
        private const string NUMBERPLATE4_TITLE = "車両登録番号（プレート番号）";

        // 内部.車両管理番号
        private const string MNGNOTEMP_KEY = "CarMngNoTemp";


        #endregion

        #region 車輌情報グリッド
        // テーブル名称
        private const string CARSPEC_TABLE = "CarSpec";
        // グリッド用
        private const string MODELGRADENM_INFO_TITLE = "グレード";
        private const string BODYNAME_INFO_TITLE = "ボディ";
        private const string DOORCOUNT_INFO_TITLE = "ドア";
        private const string ENGINEMODELNM_INFO_TITLE = "エンジン";
        private const string ENGINEDISPLACENM_INFO_TITLE = "排気量";
        private const string EDIVNM_INFO_TITLE = "Ｅ区分";
        private const string TRANSMISSIONNM_INFO_TITLE = "ミッション";
        private const string WHEELDRIVEMETHODNM_INFO_TITLE = "駆動方式";
        private const string SHIFTNM_INFO_TITLE = "シフト";
        private const string ADDICARSPECTITLE1_INFO_TITLE = "追加諸元タイトル１";
        private const string ADDICARSPECTITLE2_INFO_TITLE = "追加諸元タイトル２";
        private const string ADDICARSPECTITLE3_INFO_TITLE = "追加諸元タイトル３";
        private const string ADDICARSPECTITLE4_INFO_TITLE = "追加諸元タイトル４";
        private const string ADDICARSPECTITLE5_INFO_TITLE = "追加諸元タイトル５";
        private const string ADDICARSPECTITLE6_INFO_TITLE = "追加諸元タイトル６";
        #endregion

        #region 出荷部品グリッド
        // テーブル名称
        private const string CARPARTS_TABLE = "CarParts";
        // グリッド用
        private const string SALESDATE_KEY = "SalesDate";
        private const string GOODSNAME_KEY = "GoodsName";
        private const string GOODSNO_KEY = "GoodsNo";
        private const string GOODSMAKERNAME_KEY = "MakerName";
        private const string BLGOODSCD_KEY = "BLGoodsCd";
        private const string SALESORDERDIVCD_KEY = "SaleSorderDivCd";
        private const string LISTPRICETAXEXCFL_KEY = "ListPriceTaxExcFl";
        private const string SHIPMENTCNT_KEY = "ShipmentCnt";
        private const string SALESUNPRCTAXEXCFL_KEY = "SalesUnPrcTaxExcFl";
        private const string SALESMONEYTAXEXC_KEY = "SalesMoneyTaxExc";
        private const string SALESUNITCOST_KEY = "SalesUnitCost";
        private const string SALESMONEYTAXEXC_COST_KEY = "SalesUnCost";
        private const string COST_SALESMONEYTAXEXC_KEY = "SalesUnCostPer";
        private const string SLIPNOTE_KEY = "SlipNote";
        private const string CARNOTE_PARTS_KEY = "CarNote";
        private const string SALESSLIPNUM_KEY = "SalesSlipNum";
        private const string MILEAGE_PARTS_KEY = "Mileage";
        private const string MODEL1TO2_KEY = "Model1To2";
        private const string ROWNO_KEY = "RowNo"; // ADD BY 凌小青　on 2012/08/09 for Redmine#31532

        private const string GOODSMAKERCD_KEY = "GoodsMakerCd";
        private const string STPRODUCEFRAMENO_KEY = "StProduceFrameNo";
        private const string EDPRODUCEFRAMENO_KEY = "EdProduceFrameNo";
        private const string STPRODUCETYPEOFYEAR_KEY = "StProduceTypeOfYear";
        private const string EDPRODUCETYPEOFYEAR_KEY = "EdProduceTypeOfYear";

        // グリッド用
        private const string SALESDATE_TITLE = "伝票日付";
        private const string GOODSNAME_TITLE = "品名";
        private const string ROWNO_TITLE = "行番号"; // ADD BY 凌小青　on 2012/08/09 for Redmine#31532
        private const string GOODSNO_TITLE = "品番";
        private const string GOODSMAKERCD_TITLE = "メーカー";
        private const string BLGOODSCODE_TITLE = "BLコード";
        private const string SALESORDERDIVCD_TITLE = "在庫取寄区分";
        private const string LISTPRICETAXEXCFL_TITLE = "標準価格";
        private const string SHIPMENTCNT_TITLE = "数量";
        private const string SALESUNPRCTAXEXCFL_TITLE = "売単価";
        private const string SALESMONEYTAXEXC_TITLE = "売上金額";
        private const string SALESUNITCOST_TITLE = "原単価";
        private const string SALESMONEYTAXEXC_COST_TITLE = "粗利";
        private const string COST_SALESMONEYTAXEXC_TITLE = "粗利率";
        private const string SLIPNOTE_TITLE = "備考";
        private const string CARNOTE_PARTS_TITLE = "車輌備考";
        private const string SALESSLIPNUM_TITLE = "伝票番号";
        private const string MILEAGE_PARTS_TITLE = "走行距離";
        private const string MODEL1TO2_TITLE = "型式1-2";

        #endregion

        #region 出荷部品（合計）グリッド
        // テーブル名称
        private const string CARPARTSTOTAL_TABLE = "CarPartsTotal";
        // グリッド用
        private const string GOODSNAME_TOTAL_KEY = "GoodsName";
        private const string GOODSNO_TOTAL_KEY = "GoodsNo";
        private const string GOODSMAKERNAME_TOTAL_KEY = "GoodsMakerName";
        private const string BLGOODSCODE_TOTAL_KEY = "BLGoodsCode";
        private const string SHIPMENTCNT_TOTAL_KEY = "ShipmentCnt";
        private const string SALESMONEYTAXEXC_TOTAL_KEY = "SalesMoneyTaxExc";
        private const string COUNT_TOTAL_KEY = "CountTotal";
        private const string WAREHOUSE_TOTAL_KEY = "WareHouseName";
        private const string SHELFNO_TOTAL_KEY = "ShelfNo";
        private const string SHIPMENTPOSCNT_TOTAL_KEY = "ShipmentPosCnt";
        private const string SHIPMENTCNTIN_TOTAL_KEY = "ShipmentInPosCnt";
        private const string SHIPMENTCNTOUT_TOTAL_KEY = "ShipmentOutPosCnt";


        private const string WAREHOUSECODE_TOTAL_KEY = "WareHouseCode";
        private const string GOODSMAKERCD_TOTAL_KEY = "GoodsMakerCd";

        private const string GOODSNAME_TOTAL_TITLE = "品名";
        private const string GOODSNO_TOTAL_TITLE = "品番";
        private const string GOODSMAKERCD_TOTAL_TITLE = "メーカー";
        private const string BLGOODSCODE_TOTAL_TITLE = "BLコード";
        private const string SHIPMENTCNT_TOTAL_TITLE = "数量";
        private const string SALESMONEYTAXEXC_TOTAL_TITLE = "売上金額";
        private const string COUNT_TOTAL_TITLE = "出荷回数";
        private const string WAREHOUSE_TOTAL_TITLE = "倉庫";
        private const string SHELFNO_TOTAL_TITLE = "棚番";
        private const string SHIPMENTPOSCNT_TOTAL_TITLE = "現在庫数";
        private const string SHIPMENTCNTIN_TOTAL_TITLE = "数量（在庫）";
        private const string SHIPMENTCNTOUT_TOTAL_TITLE = "数量（取寄）";


        #endregion

        #region その他設定
        /// <summary>チェック時メッセージ「売上月次締日取得の初期処理でエラーが発生しました。」</summary>
        private const string MSG_TOTALDAY_INITIALIE_FAILED = "売上月次締日取得の初期処理でエラーが発生しました。";

        /// <summary>クリア確認メッセージ「表示内容を初期化してよろしいですか？」</summary>
        private const string MSG_CONFIRM_CLEARINPUT = "表示内容を初期化してよろしいですか？";

        /// <summary>備考区分201</summary>
        private const int SLIPNOTE_DIV = 201;

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>国産/外車区分(外車:2)</summary>
        private const int FOREIGNCODERF_DIV = 2;
        // --- ADD 2013/03/25 ----------<<<<<

        /// <summary>あいまい検索「と一致」ステータス</summary>
        private const int CT_FUZZY_MATCHWITH = 0;
        /// <summary>あいまい検索「で始る」ステータス</summary>
        private const int CT_FUZZY_STARTWITH = 1;
        /// <summary>あいまい検索「を含む」ステータス</summary>
        private const int CT_FUZZY_INCLUDEWITH = 2;
        /// <summary>あいまい検索「で終る」ステータス</summary>
        private const int CT_FUZZY_ENDWITH = 3;

        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>yyyy/MM/dd</summary>
        private const string DATEFORMAT_YYYYMMDD = "yyyy/MM/dd";
        /// <summary>yyyy.MM</summary>
        private const string DATEFORMAT_YYYYMM = "yyyy.MM";
        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";
        // プログラムID
        private const string CT_PGID = "PMSYA04000U";
        #endregion

        #endregion

        # region ■ 前回値保持 ■
        /// <summary>
        /// 前回値保持
        /// </summary>
        /// <remarks>
        /// <br>Note       : 前回値保持です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private struct PrevInputValue
        {
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>得意先コード</summary>
            private int _customerCode;

            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
        }
        # endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        public PMSYA04001UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._textOutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_TextOut"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._carPartDisplayAcs = CarPartDisplayAcs.GetInstance();
            this._tCalcAcs = TotalDayCalculator.GetInstance();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
            this._noteGuidAcs = new NoteGuidAcs();
            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();
            // 変数初期化
            this.carSearchTable = new DataTable(CARSEARCH_TABLE);
            this.carSpecTable = new DataTable(CARSPEC_TABLE);
            this.carPartsTable = new DataTable(CARPARTS_TABLE);
            this.carPartsTotalTable = new DataTable(CARPARTSTOTAL_TABLE);

            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
        }
        # endregion

        # region ■ private field ■
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _textOutButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _loginSectionCode = string.Empty;
        private DataTable carSearchTable;
        private DataTable carSpecTable;
        private DataTable carPartsTable;
        private DataTable carPartsTotalTable;
        private CarPartDisplayAcs _carPartDisplayAcs;
        private AllDefSet _allDefSet;
        /// <summary>PMKHN09012A)得意先</summary>
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        /// <summary>SFKTN09002A)拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>PMKHN09062A)BLグループ</summary>
        private BLGroupUAcs _blGroupUAcs;
        /// <summary>MAKHN09332A)倉庫</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>PMSYA09024A)管理番号</summary>
        private CarMngInputAcs _carMngInputAcs;
        /// <summary>SFTOK9402)備考設定</summary>
        private NoteGuidAcs _noteGuidAcs;
        /// <summary>日付取得部品</summary>
        private DateGetAcs _dateGetAcs;
        // **** 締め日関連 ****
        /// <summary>締め日取得用クラス</summary>
        TotalDayCalculator _tCalcAcs = null;
        /// <summary>今回締処理日</summary>
        private DateTime _currentTotalDay;
        /// <summary>今回締処理月</summary>
        private DateTime _currentTotalMonth;
        /// <summary>前回締処理日</summary>
        private DateTime _prevTotalDay;
        /// <summary>前回締処理月</summary>
        private DateTime _prevTotalMonth;
        // **** コントロール ****
        private Control _prevControl;
        /// <summary>前回入力値</summary>
        private PrevInputValue _prevInputValue;

        // **** コード←→名称を切り替える項目用 ****
        /// <summary>BLグループコード</summary>
        private int _swBLGroupCode = 0;
        /// <summary>BLグループ名</summary>
        private string _swBLGroupName = string.Empty;
        /// <summary>BLコード</summary>
        private int _swBLGoodsCode = 0;
        /// <summary>BLコード名</summary>
        private string _swBLGoodsName = string.Empty;
        /// <summary>倉庫コード</summary>
        private string _swWarehouseCd = string.Empty;
        /// <summary>倉庫名</summary>
        private string _swWarehouseName = string.Empty;
        /// <summary>品名</summary>
        private string _srGoodsName = string.Empty;
        /// <summary>品名(*抜き文字列)</summary>
        private string _srRvGoodsName = string.Empty;
        /// <summary>品番</summary>
        private string _srGoodsNo = string.Empty;
        /// <summary>品番(*抜き文字列)</summary>
        private string _srRvGoodsNo = string.Empty;
        /// <summary>車輌備考</summary>
        private string _srCarNote = string.Empty;
        /// <summary>車輌備考(*抜き文字列)</summary>
        private string _srRvCarNote = string.Empty;
        /// <summary>管理番号</summary>
        private string _srCarMngNo = string.Empty;
        /// <summary>管理番号(*抜き文字列)</summary>
        private string _srRvCarMngNo = string.Empty;
        /// <summary>型式</summary>
        private string _srFullModel = string.Empty;
        /// <summary>型式(*抜き文字列)</summary>
        private string _srRvFullModel = string.Empty;
        /// <summary>車両管理番号</summary>
        private int _carMngNoTemp = 0;
        /// <summary>得意先コード</summary>
        private int _customerCode = 0;
        /// <summary>型式</summary>
        private string _fullModel = string.Empty;
        /// <summary>型式の絞込条件</summary>
        private int _fullModelCon = 0;
        /// <summary>管理番号</summary>
        private string _carMngNo = string.Empty;
        /// <summary>管理番号の絞込条件</summary>
        private int _carMngNoCon = 0;

        // **** 文字サイズ ****
        /// <summary>文字サイズ</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        # endregion

        #region ■ コントロールイベント ■
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がロード時に発生します。</br>      
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void PMSYA04001UA_Load(object sender, EventArgs e)
        {
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            excCtrlNm.Add(this.uGroupBox_ExtractCondition.Name);
            excCtrlNm.Add(this.uGroupBox_CarInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 締日取得初期処理
            GetHisTotalDayProc();

            // 変数などを初期化
            InitializeVariable();
            ReadInitData(_enterpriseCode);

            // 画面の初期化制御
            InitializeControl();

            // 得意先マスタ読込処理
            LoadCustomerSearchRet();
        }
        #endregion

        #region ■ 得意先検索マスタ読込処理 ■
        /// <summary>
        /// 得意先検索マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先検索マスタ読込処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void LoadCustomerSearchRet()
        {
            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = this._enterpriseCode;

            CustomerSearchRet[] retList;

            int status = this._customerSearchAcs.Serch(out retList, para);
            if (status == 0)
            {
                foreach (CustomerSearchRet ret in retList)
                {
                    if (ret.LogicalDeleteCode == 0 && !this._customerSearchRetDic.ContainsKey(ret.CustomerCode))
                    {
                        this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                    }
                }
            }
        }
        #endregion

        #region ■ 締日取得初期処理 ■
        /// <summary>
        /// 締日取得初期処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 締日取得初期処理です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void GetHisTotalDayProc()
        {
            int status;

            // 締日取得前初期処理
            status = _tCalcAcs.InitializeHisMonthlyAccRec();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 今回および前回の締め日/月を取得(月と日は異なる場合がある)
                status = _tCalcAcs.GetHisTotalDayMonthlyAccRec(this._loginSectionCode, out this._prevTotalDay, out this._currentTotalDay, out this._prevTotalMonth, out this._currentTotalMonth);

                if (_prevTotalDay == DateTime.MinValue)
                {
                    DateTime today = DateTime.Today;
                    this.tDateEdit_SalesDateSt.SetDateTime(today);
                    this.tDateEdit_SalesDateEd.SetDateTime(today);
                }
                else
                {
                    this.tDateEdit_SalesDateSt.SetDateTime(this._prevTotalDay.AddDays(1));
                    this.tDateEdit_SalesDateEd.SetDateTime(DateTime.Today);

                    if (this._prevTotalDay.AddDays(1) > DateTime.Today)
                    {
                        this.tDateEdit_SalesDateEd.SetDateTime(this._prevTotalDay.AddDays(1));
                    }
                }
            }
            else
            {
                // 初期処理失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_TOTALDAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
            }
        }
        #endregion

        #region ■ クリア処理 ■
        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : クリア処理です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void Clear()
        {
            // 確認ダイアログ
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_CLEARINPUT,
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            // 表示区分が車輌検索を表示する
             this.tComboEditor_DisplayDiv.SelectedIndex = 0;
            // 抽出条件の「売上日」「入力日」を入力不可に変更する。
            this.tDateEdit_SalesDateSt.Enabled = false;
            this.tDateEdit_SalesDateEd.Enabled = false;
            this.tDateEdit_AddUpADateSt.Enabled = false;
            this.tDateEdit_AddUpADateEd.Enabled = false;
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionNm.Text = "全社";
            this.tEdit_SectionCodeAllowZero.Enabled = false;
            this.uButton_SectionGuide.Enabled = false;

            this.tEdit_BlGroupCode.Text = string.Empty;
            this.tEdit_BlGoodsCode.Text = string.Empty;
            this.tEdit_GoodsName.Text = string.Empty;
            this.tComboEditor_GoodsNameFuzzy.SelectedIndex = 0;
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tComboEditor_GoodsNoFuzzy.SelectedIndex = 0;
            this.tComboEditor_SalesOrderDivCd.SelectedIndex = 0;
            this.tEdit_WarehouseCd.Text = string.Empty;

            this.uGroupBox_CarInfo.Expanded = true;
            // 抽出条件枠を最小化
            this.uGroupBox_ExtractCondition.Expanded = false;
            this.tEdit_BlGroupCode.Enabled = false;
            this.uButton_BlGroupCode.Enabled = false;
            this.tEdit_BlGoodsCode.Enabled = false;
            this.uButton_BlGoodsCode.Enabled = false;
            this.tEdit_GoodsName.Enabled = false;
            this.tComboEditor_GoodsNameFuzzy.Enabled = false;
            this.tEdit_GoodsNo.Enabled = false;
            this.tComboEditor_GoodsNoFuzzy.Enabled = false;
            this.tComboEditor_SalesOrderDivCd.Enabled = false;
            this.tEdit_WarehouseCd.Enabled = false;
            this.uButton_WarehouseCd.Enabled = false;

            this.GetHisTotalDayProc();

            this.tDateEdit_AddUpADateSt.Clear();
            this.tDateEdit_AddUpADateEd.Clear();
            this.tNedit_CustomerCode.Text = string.Empty;
            this.uLabel_CustomerName.Text = string.Empty;
            this.tEdit_FullModel.Text = string.Empty;
            this.tComboEditor_FullModelFuzzy.SelectedIndex = 1;
            this.tEdit_CarMngCode.Text = string.Empty;
            // this.tComboEditor_CarMngCode.SelectedIndex = 1;// DEL 2009/10/19 Redmine#704
            this.tComboEditor_CarMngCode.SelectedIndex = 0;// ADD 2009/10/19 Redmine#704
            this.tEdit_SlipNote.Text = string.Empty;
            this.tComboEditor_SlipNoteFuzzy.SelectedIndex = 0;
            this.CarInfoClear();

            this.carSpecTable.Clear();
            this.carSearchTable.Clear();
            this.carPartsTable.Clear();
            this.carPartsTotalTable.Clear();

            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;

            this.uGrid_CarSearchList.Visible = true;
            this.uGrid_CarPartsTotalList.Visible = false;
            this.uGrid_CarPartsList.Visible = false;

            // テキスト出力
            this._textOutButton.SharedProps.Enabled = false;

            this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.White;

            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
            autoColumnAdjust(false, 0);
            #region コード←→名称を切り替える項目用 クリア
            this._prevInputValue.CustomerCode = 0;
            this._prevInputValue.SectionCode = string.Empty;
            // **** コード←→名称を切り替える項目用 クリア****
            this._swBLGroupCode = 0;
            this._swBLGroupName = string.Empty;
            this._swBLGoodsCode = 0;
            this._swBLGoodsName = string.Empty;
            this._swWarehouseCd = string.Empty;
            this._swWarehouseName = string.Empty;
            this._srGoodsName = string.Empty;
            this._srRvGoodsName = string.Empty;
            this._srGoodsNo = string.Empty;
            this._srRvGoodsNo = string.Empty;
            this._srCarNote = string.Empty;
            this._srRvCarNote = string.Empty;
            this._srCarMngNo = string.Empty;
            this._srRvCarMngNo = string.Empty;
            this._srFullModel = string.Empty;
            this._srRvFullModel = string.Empty;
            this._carMngNoTemp = 0;
            this._customerCode = 0;
            this._fullModel = string.Empty;
            this._fullModelCon = 0;
            this._carMngNo = string.Empty;
            this._carMngNoCon = 0;
            #endregion

            #region 車輌情報グリッドデータ
            DataRow dataRow;
            dataRow = this.carSpecTable.NewRow();
            dataRow[MODELGRADENM_INFO_TITLE] = string.Empty;
            dataRow[BODYNAME_INFO_TITLE] = string.Empty;
            dataRow[DOORCOUNT_INFO_TITLE] = string.Empty;
            dataRow[ENGINEMODELNM_INFO_TITLE] = string.Empty;
            dataRow[ENGINEDISPLACENM_INFO_TITLE] = string.Empty;
            dataRow[EDIVNM_INFO_TITLE] = string.Empty;
            dataRow[TRANSMISSIONNM_INFO_TITLE] = string.Empty;
            dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = string.Empty;
            dataRow[SHIFTNM_INFO_TITLE] = string.Empty;

            this.carSpecTable.Rows.Add(dataRow);

            this.uGrid_CarSpec.Refresh();
            #endregion
        }
        /// <summary>
        /// 車輌情報のクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌情報をクリアします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void CarInfoClear()
        {
            this.uLabel_ModelDesignationNoData.Text = string.Empty;
            this.uLabel_ModelKindNo.Text = string.Empty;
            this.uLabel_EngineModelNmData.Text = string.Empty;
            this.uLabel_FullModelTitleInfoData.Text = string.Empty;
            this.uLabel_ModelMaker.Text = string.Empty;
            this.uLabel_ModelCode.Text = string.Empty;
            this.uLabel_ModelSubCode.Text = string.Empty;
            this.uLabel_ModelName.Text = string.Empty;
            this.tDateEdit_FirstEntryDate.Clear();
            this.uLabel_FirstEntryDateRange.Text = string.Empty;
            this.uLabel_ColorNoData.Text = string.Empty;
            this.uLabel_ProduceFrameNoData.Text = string.Empty;
            this.uLabel_ProduceFrameNoRange.Text = string.Empty;
            this.uLabel_TrimNoData.Text = string.Empty;
            this.uLabel_CarMngCodeData.Text = string.Empty;// ADD 2009/10/10

        }
        #endregion

        #region ■ 初期化処理 ■
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期化処理です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void InitializeControl()
        {
            // 表示区分が車輌検索を表示する
            this.tComboEditor_DisplayDiv.SelectedIndex = 0;
            // 抽出条件の「売上日」「入力日」を入力不可に変更する。
            this.tDateEdit_SalesDateSt.Enabled = false;
            this.tDateEdit_SalesDateEd.Enabled = false;
            this.tDateEdit_AddUpADateSt.Enabled = false;
            this.tDateEdit_AddUpADateEd.Enabled = false;
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionNm.Text = "全社";
            this.tEdit_SectionCodeAllowZero.Enabled = false;
            this.uButton_SectionGuide.Enabled = false;
            // 管理番号検索区分:で始まる
            // this.tComboEditor_CarMngCode.SelectedIndex = 1;// DEL 2009/10/19 Redmine#704
            this.tComboEditor_CarMngCode.SelectedIndex = 0;//  ADD 2009/10/19 Redmine#704
            // 型式検索区分:で始まる
            this.tComboEditor_FullModelFuzzy.SelectedIndex = 1;
            // 抽出条件枠を最小化
            this.uGroupBox_ExtractCondition.Expanded = false;
            this.tEdit_BlGroupCode.Enabled = false;
            this.uButton_BlGroupCode.Enabled = false;
            this.tEdit_BlGoodsCode.Enabled = false;
            this.uButton_BlGoodsCode.Enabled = false;
            this.tEdit_GoodsName.Enabled = false;
            this.tComboEditor_GoodsNameFuzzy.Enabled = false;
            this.tEdit_GoodsNo.Enabled = false;
            this.tComboEditor_GoodsNoFuzzy.Enabled = false;
            this.tComboEditor_SalesOrderDivCd.Enabled = false;
            this.tEdit_WarehouseCd.Enabled = false;
            this.uButton_WarehouseCd.Enabled = false;
            // 出荷部品グリッド
            this.uGrid_CarPartsTotalList.Visible = false;
            // 出荷部品（合計）グリッド
            this.uGrid_CarPartsList.Visible = false;
            // テキスト出力
            this._textOutButton.SharedProps.Enabled = false;
            // 年式
            // 0:西暦
            if (this._allDefSet.EraNameDispCd1 == 0)
            {
                this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.df4Y2M;
            }
            // 1:和歴
            else
            {
                this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.dfG2Y2M;
            }
            
            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
            autoColumnAdjust(false, 0);
        }

        /// <summary>
        /// プライベートレベルの変数などを初期化および初期取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : プライベートレベルの変数などを初期化および初期取得処理です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void InitializeVariable()
        {
            // 文字サイズ設定
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = 4;
            // グリッドを作成
            // グリッド列初期設定処理
            InitializeGridColumns(this.uGrid_CarSearchList.DisplayLayout.Bands[0].Columns, 0);
            InitializeGridColumns(this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns, 1);
            InitializeGridColumns(this.uGrid_CarPartsList.DisplayLayout.Bands[0].Columns, 2);
            InitializeGridColumns(this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0].Columns, 3);
        }

        #region ボタン初期設定処理
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._textOutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCode.ImageList = this._imageList16;
            this.uButton_BlGoodsCode.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGroupCode.ImageList = this._imageList16;
            this.uButton_BlGroupCode.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SlipNote.ImageList = this._imageList16;
            this.uButton_SlipNote.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_WarehouseCd.ImageList = this._imageList16;
            this.uButton_WarehouseCd.Appearance.Image = (int)Size16_Index.STAR1;
            this.CarMngCode_Button.ImageList = this._imageList16;
            this.CarMngCode_Button.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion ■ ボタン初期設定処理 ■

        #endregion

        #region ■ グリッド作成 ■
        /// <summary>
        /// グリッド列の初期化
        /// </summary>
        /// <param name="Columns">グリッド列</param>
        /// <param name="tabNo">テーブル番号</param>
        /// <remarks>
        /// <br>Note       : グリッド列の初期化処理です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/25</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, int tabNo)
        {
            // 表示形式のある列で使用
            //string formatCount = "#,##0;-#,##0;'0'";
            //string formatCurrency = "#,##0;-#,##0;";
            //string formatFraction = "#,##0.00;-#,##0.00;";
            //string formatDate = "yyyy/MM/dd";

            switch (tabNo)
            {
                case 0:
                    {
                        #region 車輌検索グリッド

                        this.carSearchTable.BeginLoadData();
                        // 選択チェックボックス
                        // 得意先
                        this.carSearchTable.Columns.Add(CUSTOMERSUBNAME_KEY, typeof(string));
                        // 管理番号
                        this.carSearchTable.Columns.Add(MNGNO_KEY, typeof(string));
                        // 原動機型式
                        this.carSearchTable.Columns.Add(ENGINEMODEL_KEY, typeof(string));
                        // 追加情報１
                        this.carSearchTable.Columns.Add(CARADDINFO1_KEY, typeof(string));
                        // 追加情報２
                        this.carSearchTable.Columns.Add(CARADDINFO2_KEY, typeof(string));
                        // 登録番号
                        this.carSearchTable.Columns.Add(INSERTNO_KEY, typeof(string));
                        // 走行距離
                        this.carSearchTable.Columns.Add(MILEAGE_KEY, typeof(string));
                        // 車検期間
                        this.carSearchTable.Columns.Add(CARINSPECTYEAR_KEY, typeof(string));
                        // 登録年月日
                        this.carSearchTable.Columns.Add(ENTRYDATE_KEY, typeof(string));
                        // 前回車検日
                        this.carSearchTable.Columns.Add(LTIMECIMATDATE_KEY, typeof(string));
                        // 次回車検日
                        this.carSearchTable.Columns.Add(INSPECTMATURITYDATE_KEY, typeof(string));
                        // 車輌備考
                        this.carSearchTable.Columns.Add(CARNOTE_KEY, typeof(string));

                        // 画面表示用
                        // 得意先コード
                        this.carSearchTable.Columns.Add(CUSTOMERCODE_KEY, typeof(string));
                        // 型式
                        this.carSearchTable.Columns.Add(KINDMODEL_KEY, typeof(string));
                        // 型式指定番号
                        this.carSearchTable.Columns.Add(MODELDESIGNATIONNO_KEY, typeof(string));
                        // 類別番号
                        this.carSearchTable.Columns.Add(CATEGORYNO_KEY, typeof(string));
                        // エンジン型式
                        this.carSearchTable.Columns.Add(ENGINEMODELNM_KEY, typeof(string));
                        // 車種（メーカーコード）
                        this.carSearchTable.Columns.Add(MAKERCODE_KEY, typeof(string));
                        // 車種（車種コード）
                        this.carSearchTable.Columns.Add(MODELCODE_KEY, typeof(string));
                        // 車種（呼称コード）
                        this.carSearchTable.Columns.Add(MODELSUBCODE_KEY, typeof(string));
                        // 車種名称
                        this.carSearchTable.Columns.Add(MODELFULLNAME_KEY, typeof(string));
                        // 型式（フル型）
                        this.carSearchTable.Columns.Add(FULLMODEL_KEY, typeof(string));
                        // 年式
                        this.carSearchTable.Columns.Add(FIRSTENTRYDATE_KEY, typeof(string));
                        // (生産年式 開始-終了)
                        this.carSearchTable.Columns.Add(STEDPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // 車台番号
                        this.carSearchTable.Columns.Add(FRAMENO_KEY, typeof(string));
                        // (車台番号 開始-終了)
                        this.carSearchTable.Columns.Add(STEDPRODUCEFRAMENO_KEY, typeof(string));
                        // カラー
                        this.carSearchTable.Columns.Add(COLORCODE_KEY, typeof(string));
                        // トリム
                        this.carSearchTable.Columns.Add(TRIMCODE_KEY, typeof(string));
                        // 型式グレード名称
                        this.carSearchTable.Columns.Add(MODELGRADENM_KEY, typeof(string));
                        // ボディー名称
                        this.carSearchTable.Columns.Add(BODYNAME_KEY, typeof(string));
                        // ドア数
                        this.carSearchTable.Columns.Add(DOORCOUNT_KEY, typeof(string));
                        // エンジン型式名称
                        //this.carSearchTable.Columns.Add(ENGINEMODELNM_TITLE, typeof(string));
                        // 排気量名称
                        this.carSearchTable.Columns.Add(ENGINEDISPLACENM_KEY, typeof(string));
                        // E区分名称
                        this.carSearchTable.Columns.Add(EDIVNM_KEY, typeof(string));
                        // ミッション名称
                        this.carSearchTable.Columns.Add(TRANSMISSIONNM_KEY, typeof(string));
                        // 駆動方式名称
                        this.carSearchTable.Columns.Add(WHEELDRIVEMETHODNM_KEY, typeof(string));
                        // シフト名称
                        this.carSearchTable.Columns.Add(SHIFTNM_KEY, typeof(string));
                        // 追加諸元タイトル１
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE1_KEY, typeof(string));
                        // 追加諸元タイトル２
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE2_KEY, typeof(string));
                        // 追加諸元タイトル３
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE3_KEY, typeof(string));
                        // 追加諸元タイトル４
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE4_KEY, typeof(string));
                        // 追加諸元タイトル５
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE5_KEY, typeof(string));
                        // 追加諸元タイトル６
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE6_KEY, typeof(string));
                        // 追加諸元１
                        this.carSearchTable.Columns.Add(ADDICARSPEC1_KEY, typeof(string));
                        // 追加諸元２
                        this.carSearchTable.Columns.Add(ADDICARSPEC2_KEY, typeof(string));
                        // 追加諸元３
                        this.carSearchTable.Columns.Add(ADDICARSPEC3_KEY, typeof(string));
                        // 追加諸元４
                        this.carSearchTable.Columns.Add(ADDICARSPEC4_KEY, typeof(string));
                        // 追加諸元５
                        this.carSearchTable.Columns.Add(ADDICARSPEC5_KEY, typeof(string));
                        // 追加諸元６
                        this.carSearchTable.Columns.Add(ADDICARSPEC6_KEY, typeof(string));
                        // --- ADD 2013/03/25 ---------->>>>>
                        // 国産/外車区分
                        this.carSearchTable.Columns.Add(DOMESTICFOREIGNCODERF_KEY, typeof(string));
                        // --- ADD 2013/03/25 ----------<<<<<

                        // テキスト用
                        // カラー名称1
                        this.carSearchTable.Columns.Add(COLORNAME1_KEY, typeof(string));
                        // トリム名称
                        this.carSearchTable.Columns.Add(TRIMNAME_KEY, typeof(string));
                        // 陸運事務所番号
                        this.carSearchTable.Columns.Add(NUMBERPLATE1CODE_KEY, typeof(string));
                        // 陸運事務局名称
                        this.carSearchTable.Columns.Add(NUMBERPLATE1NAME_KEY, typeof(string));
                        // 車両登録番号（種別）
                        this.carSearchTable.Columns.Add(NUMBERPLATE2_KEY, typeof(string));
                        // 車両登録番号（カナ）
                        this.carSearchTable.Columns.Add(NUMBERPLATE3_KEY, typeof(string));
                        // 車両登録番号（プレート番号）
                        this.carSearchTable.Columns.Add(NUMBERPLATE4_KEY, typeof(string));

                        // 車両管理番号
                        this.carSearchTable.Columns.Add(MNGNOTEMP_KEY, typeof(string));

                        this.carSearchTable.EndLoadData();

                        this.uGrid_CarSearchList.DataSource = carSearchTable;

                        #endregion

                        #region 車輌検索グリッド
                        this.uGrid_CarSearchList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        this.uGrid_CarSearchList.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;


                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarSearchList.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // 全ての列をいったん非表示にする。
                            // 得意先
                            if (!CUSTOMERSUBNAME_KEY.Equals(col.Key)
                                // 管理番号
                                && !MNGNO_KEY.Equals(col.Key)
                                // 原動機型式
                                && !ENGINEMODEL_KEY.Equals(col.Key)
                                // 追加情報１
                                && !CARADDINFO1_KEY.Equals(col.Key)
                                // 追加情報２
                                && !CARADDINFO2_KEY.Equals(col.Key)
                                // 登録番号
                                && !INSERTNO_KEY.Equals(col.Key)
                                // 走行距離
                                && !MILEAGE_KEY.Equals(col.Key)
                                // 車検期間
                                && !CARINSPECTYEAR_KEY.Equals(col.Key)
                                // 登録年月日
                                && !ENTRYDATE_KEY.Equals(col.Key)
                                // 前回車検日
                                && !LTIMECIMATDATE_KEY.Equals(col.Key)
                                // 次回車検日
                                && !INSPECTMATURITYDATE_KEY.Equals(col.Key)
                                // 車輌備考
                                && !CARNOTE_KEY.Equals(col.Key)
                                // カラー
                                && !COLORNAME1_KEY.Equals(col.Key)
                                // トリム
                                && !TRIMNAME_KEY.Equals(col.Key)
                                )
                            {
                                col.Hidden = true;
                            }
                        }


                        // Filter設定
                        editBand.Columns[CUSTOMERSUBNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MNGNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[ENGINEMODEL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARADDINFO1_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARADDINFO2_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[INSERTNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MILEAGE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARINSPECTYEAR_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[ENTRYDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[LTIMECIMATDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARNOTE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[COLORNAME1_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[TRIMNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                        // 表示幅設定
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Width = 120;
                        editBand.Columns[MNGNO_KEY].Width = 120;
                        editBand.Columns[ENGINEMODEL_KEY].Width = 120;
                        editBand.Columns[CARADDINFO1_KEY].Width = 120;
                        editBand.Columns[CARADDINFO2_KEY].Width = 120;
                        editBand.Columns[INSERTNO_KEY].Width = 120;
                        editBand.Columns[MILEAGE_KEY].Width = 120;
                        editBand.Columns[CARINSPECTYEAR_KEY].Width = 120;
                        editBand.Columns[ENTRYDATE_KEY].Width = 120;
                        editBand.Columns[LTIMECIMATDATE_KEY].Width = 120;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Width = 120;
                        editBand.Columns[CARNOTE_KEY].Width = 120;
                        editBand.Columns[COLORNAME1_KEY].Width = 120;
                        editBand.Columns[TRIMNAME_KEY].Width = 120;

                        // グリッド名称
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Header.Caption = "得意先";
                        editBand.Columns[MNGNO_KEY].Header.Caption = "管理番号";
                        editBand.Columns[ENGINEMODEL_KEY].Header.Caption = "原動機型式";
                        editBand.Columns[CARADDINFO1_KEY].Header.Caption = "追加情報１";
                        editBand.Columns[CARADDINFO2_KEY].Header.Caption = "追加情報２";
                        editBand.Columns[INSERTNO_KEY].Header.Caption = "登録番号";
                        editBand.Columns[MILEAGE_KEY].Header.Caption = "走行距離";
                        editBand.Columns[CARINSPECTYEAR_KEY].Header.Caption = "車検期間";
                        editBand.Columns[ENTRYDATE_KEY].Header.Caption = "登録年月日";
                        editBand.Columns[LTIMECIMATDATE_KEY].Header.Caption = "前回車検日";
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Header.Caption = "次回車検日";
                        editBand.Columns[CARNOTE_KEY].Header.Caption = "車輌備考";
                        editBand.Columns[COLORNAME1_KEY].Header.Caption = "カラー";
                        editBand.Columns[TRIMNAME_KEY].Header.Caption = "トリム";

                        // 固定列設定
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Header.Fixed = false;
                        editBand.Columns[MNGNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MNGNO_KEY].Header.Fixed = false;
                        editBand.Columns[ENGINEMODEL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENGINEMODEL_KEY].Header.Fixed = false;
                        editBand.Columns[CARADDINFO1_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARADDINFO1_KEY].Header.Fixed = false;
                        editBand.Columns[CARADDINFO2_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARADDINFO2_KEY].Header.Fixed = false;
                        editBand.Columns[INSERTNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[INSERTNO_KEY].Header.Fixed = false;
                        editBand.Columns[MILEAGE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MILEAGE_KEY].Header.Fixed = false;
                        editBand.Columns[CARINSPECTYEAR_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARINSPECTYEAR_KEY].Header.Fixed = false;
                        editBand.Columns[ENTRYDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENTRYDATE_KEY].Header.Fixed = false;
                        editBand.Columns[LTIMECIMATDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[LTIMECIMATDATE_KEY].Header.Fixed = false;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Header.Fixed = false;
                        editBand.Columns[CARNOTE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARNOTE_KEY].Header.Fixed = false;
                        editBand.Columns[COLORNAME1_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[COLORNAME1_KEY].Header.Fixed = false;
                        editBand.Columns[TRIMNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[TRIMNAME_KEY].Header.Fixed = false;
                        // CellAppearance設定
                        editBand.Columns[CUSTOMERSUBNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[MNGNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ENGINEMODEL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARADDINFO1_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARADDINFO2_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[INSERTNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[MILEAGE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[CARINSPECTYEAR_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[ENTRYDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[LTIMECIMATDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARNOTE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[COLORNAME1_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[TRIMNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                        // 入力許可設定
                        editBand.Columns[CUSTOMERSUBNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MNGNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENGINEMODEL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARADDINFO1_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARADDINFO2_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[INSERTNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MILEAGE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARINSPECTYEAR_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENTRYDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[LTIMECIMATDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARNOTE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[COLORNAME1_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[TRIMNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                        editBand.Columns[CUSTOMERSUBNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MNGNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENGINEMODEL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARADDINFO1_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARADDINFO2_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[INSERTNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MILEAGE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARINSPECTYEAR_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENTRYDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[LTIMECIMATDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARNOTE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[COLORNAME1_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[TRIMNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        #endregion

                        break;
                    }
                case 1:
                    {
                        #region 車輌情報グリッド

                        this.carSpecTable.BeginLoadData();

                        // 型式グレード名称
                        this.carSpecTable.Columns.Add(MODELGRADENM_INFO_TITLE, typeof(string));
                        // ボディー名称
                        this.carSpecTable.Columns.Add(BODYNAME_INFO_TITLE, typeof(string));
                        // ドア数
                        this.carSpecTable.Columns.Add(DOORCOUNT_INFO_TITLE, typeof(string));
                        // エンジン型式名称
                        this.carSpecTable.Columns.Add(ENGINEMODELNM_INFO_TITLE, typeof(string));
                        // 排気量名称
                        this.carSpecTable.Columns.Add(ENGINEDISPLACENM_INFO_TITLE, typeof(string));
                        // E区分名称
                        this.carSpecTable.Columns.Add(EDIVNM_INFO_TITLE, typeof(string));
                        // ミッション名称
                        this.carSpecTable.Columns.Add(TRANSMISSIONNM_INFO_TITLE, typeof(string));
                        // 駆動方式名称
                        this.carSpecTable.Columns.Add(WHEELDRIVEMETHODNM_INFO_TITLE, typeof(string));
                        // シフト名称
                        this.carSpecTable.Columns.Add(SHIFTNM_INFO_TITLE, typeof(string));
                        // 追加諸元タイトル１
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE1_INFO_TITLE, typeof(string));
                        // 追加諸元タイトル２
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE2_INFO_TITLE, typeof(string));
                        // 追加諸元タイトル３
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE3_INFO_TITLE, typeof(string));
                        // 追加諸元タイトル４
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE4_INFO_TITLE, typeof(string));
                        // 追加諸元タイトル５
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE5_INFO_TITLE, typeof(string));
                        // 追加諸元タイトル６
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE6_INFO_TITLE, typeof(string));

                        this.carSpecTable.EndLoadData();

                        this.uGrid_CarSpec.DataSource = carSpecTable;

                        #endregion

                        #region 車輌情報グリッド
                        this.uGrid_CarSpec.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;

                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarSpec.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // 全ての列をいったん非表示にする。
                            // グレード
                            if (!MODELGRADENM_INFO_TITLE.Equals(col.Key)
                                // ボディ
                                && !BODYNAME_INFO_TITLE.Equals(col.Key)
                                // ドア
                                && !DOORCOUNT_INFO_TITLE.Equals(col.Key)
                                // エンジン
                                && !ENGINEMODELNM_INFO_TITLE.Equals(col.Key)
                                // 排気量
                                && !ENGINEDISPLACENM_INFO_TITLE.Equals(col.Key)
                                // Ｅ区分
                                && !EDIVNM_INFO_TITLE.Equals(col.Key)
                                // ミッション
                                && !TRANSMISSIONNM_INFO_TITLE.Equals(col.Key)
                                // 駆動方式
                                && !WHEELDRIVEMETHODNM_INFO_TITLE.Equals(col.Key)
                                // シフト
                                && !SHIFTNM_INFO_TITLE.Equals(col.Key))
                            {
                                col.Hidden = true;
                            }
                        }

                        // Filter設定
                        editBand.Columns[MODELGRADENM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[BODYNAME_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[EDIVNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[SHIFTNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        // 表示幅設定
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Width = 120;
                        editBand.Columns[BODYNAME_INFO_TITLE].Width = 120;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Width = 120;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Width = 120;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Width = 120;
                        editBand.Columns[EDIVNM_INFO_TITLE].Width = 120;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Width = 120;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Width = 120;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Width = 120;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Width = 150;

                        // 固定列設定
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[BODYNAME_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[BODYNAME_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[EDIVNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[EDIVNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Header.Fixed = true;

                        // CellAppearance設定
                        editBand.Columns[MODELGRADENM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[BODYNAME_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[EDIVNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SHIFTNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                        // 入力許可設定
                        editBand.Columns[MODELGRADENM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[BODYNAME_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[EDIVNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIFTNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                        // Style設定
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[BODYNAME_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[EDIVNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        #endregion

                        #region 車輌情報グリッド
                        DataRow dataRow;
                        dataRow = this.carSpecTable.NewRow();
                        dataRow[MODELGRADENM_INFO_TITLE] = string.Empty;
                        dataRow[BODYNAME_INFO_TITLE] = string.Empty;
                        dataRow[DOORCOUNT_INFO_TITLE] = string.Empty;
                        dataRow[ENGINEMODELNM_INFO_TITLE] = string.Empty;
                        dataRow[ENGINEDISPLACENM_INFO_TITLE] = string.Empty;
                        dataRow[EDIVNM_INFO_TITLE] = string.Empty;
                        dataRow[TRANSMISSIONNM_INFO_TITLE] = string.Empty;
                        dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = string.Empty;
                        dataRow[SHIFTNM_INFO_TITLE] = string.Empty;

                        this.carSpecTable.Rows.Add(dataRow);

                        this.uGrid_CarSpec.Refresh();
                        #endregion

                        break;
                    }
                case 2:
                    {
                        #region 出荷部品グリッド

                        this.carPartsTable.BeginLoadData();
                        // グリッド用
                        // 伝票日付
                        this.carPartsTable.Columns.Add(SALESDATE_KEY, typeof(string));
                        // 品名
                        this.carPartsTable.Columns.Add(GOODSNAME_KEY, typeof(string));
                        //------ADD BY 凌小青　on 2012/08/09 for Redmine#31532------>>>>>>>
                        // 行番号
                        this.carPartsTable.Columns.Add(ROWNO_KEY, typeof(string));
                        //------ADD BY 凌小青　on 2012/08/09 for Redmine#31532------<<<<<<<
                        // 品番
                        this.carPartsTable.Columns.Add(GOODSNO_KEY, typeof(string));
                        // メーカー
                        this.carPartsTable.Columns.Add(GOODSMAKERNAME_KEY, typeof(string));
                        // BLコード
                        this.carPartsTable.Columns.Add(BLGOODSCD_KEY, typeof(string));
                        // 在庫取寄区分
                        this.carPartsTable.Columns.Add(SALESORDERDIVCD_KEY, typeof(string));
                        // 標準価格
                        this.carPartsTable.Columns.Add(LISTPRICETAXEXCFL_KEY, typeof(string));
                        // 数量
                        this.carPartsTable.Columns.Add(SHIPMENTCNT_KEY, typeof(string));
                        // 売単価
                        this.carPartsTable.Columns.Add(SALESUNPRCTAXEXCFL_KEY, typeof(string));
                        // 売上金額
                        this.carPartsTable.Columns.Add(SALESMONEYTAXEXC_KEY, typeof(string));
                        // 原単価
                        this.carPartsTable.Columns.Add(SALESUNITCOST_KEY, typeof(string));
                        // 粗利
                        this.carPartsTable.Columns.Add(SALESMONEYTAXEXC_COST_KEY, typeof(string));
                        // 粗利率
                        this.carPartsTable.Columns.Add(COST_SALESMONEYTAXEXC_KEY, typeof(string));
                        // 備考
                        this.carPartsTable.Columns.Add(SLIPNOTE_KEY, typeof(string));
                        // 車輌備考
                        this.carPartsTable.Columns.Add(CARNOTE_PARTS_KEY, typeof(string));
                        // 伝票番号
                        this.carPartsTable.Columns.Add(SALESSLIPNUM_KEY, typeof(string));
                        // 走行距離
                        this.carPartsTable.Columns.Add(MILEAGE_PARTS_KEY, typeof(string));
                        // 型式1-2
                        this.carPartsTable.Columns.Add(MODEL1TO2_KEY, typeof(string));

                        // 画面表示用
                        // 得意先コード
                        this.carPartsTable.Columns.Add(CUSTOMERCODE_KEY, typeof(string));
                        // 型式
                        this.carPartsTable.Columns.Add(KINDMODEL_KEY, typeof(string));
                        // 型式指定番号
                        this.carPartsTable.Columns.Add(MODELDESIGNATIONNO_KEY, typeof(string));
                        // 類別番号
                        this.carPartsTable.Columns.Add(CATEGORYNO_KEY, typeof(string));
                        // エンジン型式
                        this.carPartsTable.Columns.Add(ENGINEMODELNM_KEY, typeof(string));
                        // 車種（メーカーコード）
                        this.carPartsTable.Columns.Add(MAKERCODE_KEY, typeof(string));
                        // 車種（車種コード）
                        this.carPartsTable.Columns.Add(MODELCODE_KEY, typeof(string));
                        // 車種（呼称コード）
                        this.carPartsTable.Columns.Add(MODELSUBCODE_KEY, typeof(string));
                        // 車種名称
                        this.carPartsTable.Columns.Add(MODELFULLNAME_KEY, typeof(string));
                        // 型式（フル型）
                        this.carPartsTable.Columns.Add(FULLMODEL_KEY, typeof(string));
                        // 年式
                        this.carPartsTable.Columns.Add(FIRSTENTRYDATE_KEY, typeof(string));
                        // (生産年式 開始-終了)
                        this.carPartsTable.Columns.Add(STEDPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // 車台番号
                        this.carPartsTable.Columns.Add(FRAMENO_KEY, typeof(string));
                        // (車台番号 開始-終了)
                        this.carPartsTable.Columns.Add(STEDPRODUCEFRAMENO_KEY, typeof(string));
                        // カラー
                        this.carPartsTable.Columns.Add(COLORCODE_KEY, typeof(string));
                        // トリム
                        this.carPartsTable.Columns.Add(TRIMCODE_KEY, typeof(string));
                        // 型式グレード名称
                        this.carPartsTable.Columns.Add(MODELGRADENM_KEY, typeof(string));
                        // ボディー名称
                        this.carPartsTable.Columns.Add(BODYNAME_KEY, typeof(string));
                        // ドア数
                        this.carPartsTable.Columns.Add(DOORCOUNT_KEY, typeof(string));
                        // エンジン型式名称
                        //this.carSearchTable.Columns.Add(ENGINEMODELNM_TITLE, typeof(string));
                        // 排気量名称
                        this.carPartsTable.Columns.Add(ENGINEDISPLACENM_KEY, typeof(string));
                        // E区分名称
                        this.carPartsTable.Columns.Add(EDIVNM_KEY, typeof(string));
                        // ミッション名称
                        this.carPartsTable.Columns.Add(TRANSMISSIONNM_KEY, typeof(string));
                        // 駆動方式名称
                        this.carPartsTable.Columns.Add(WHEELDRIVEMETHODNM_KEY, typeof(string));
                        // シフト名称
                        this.carPartsTable.Columns.Add(SHIFTNM_KEY, typeof(string));
                        // 追加諸元タイトル１
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE1_KEY, typeof(string));
                        // 追加諸元タイトル２
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE2_KEY, typeof(string));
                        // 追加諸元タイトル３
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE3_KEY, typeof(string));
                        // 追加諸元タイトル４
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE4_KEY, typeof(string));
                        // 追加諸元タイトル５
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE5_KEY, typeof(string));
                        // 追加諸元タイトル６
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE6_KEY, typeof(string));
                        // 追加諸元１
                        this.carPartsTable.Columns.Add(ADDICARSPEC1_KEY, typeof(string));
                        // 追加諸元２
                        this.carPartsTable.Columns.Add(ADDICARSPEC2_KEY, typeof(string));
                        // 追加諸元３
                        this.carPartsTable.Columns.Add(ADDICARSPEC3_KEY, typeof(string));
                        // 追加諸元４
                        this.carPartsTable.Columns.Add(ADDICARSPEC4_KEY, typeof(string));
                        // 追加諸元５
                        this.carPartsTable.Columns.Add(ADDICARSPEC5_KEY, typeof(string));
                        // 追加諸元６
                        this.carPartsTable.Columns.Add(ADDICARSPEC6_KEY, typeof(string));
                        // --- ADD 2013/03/25 ---------->>>>>
                        // 国産/外車区分
                        this.carPartsTable.Columns.Add(DOMESTICFOREIGNCODERF_KEY, typeof(string));
                        // --- ADD 2013/03/25 ----------<<<<<

                        // テキスト用
                        // メーカーコード
                        this.carPartsTable.Columns.Add(GOODSMAKERCD_KEY, typeof(string));
                        // カラー名称1
                        this.carPartsTable.Columns.Add(COLORNAME1_KEY, typeof(string));
                        // トリム名称
                        this.carPartsTable.Columns.Add(TRIMNAME_KEY, typeof(string));
                        // 陸運事務所番号
                        this.carPartsTable.Columns.Add(NUMBERPLATE1CODE_KEY, typeof(string));
                        // 陸運事務局名称
                        this.carPartsTable.Columns.Add(NUMBERPLATE1NAME_KEY, typeof(string));
                        // 車両登録番号（種別）
                        this.carPartsTable.Columns.Add(NUMBERPLATE2_KEY, typeof(string));
                        // 車両登録番号（カナ）
                        this.carPartsTable.Columns.Add(NUMBERPLATE3_KEY, typeof(string));
                        // 車両登録番号（プレート番号）
                        this.carPartsTable.Columns.Add(NUMBERPLATE4_KEY, typeof(string));
                        // 開始生産年式
                        this.carPartsTable.Columns.Add(STPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // 終了生産年式
                        this.carPartsTable.Columns.Add(EDPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // 生産車台番号開始
                        this.carPartsTable.Columns.Add(STPRODUCEFRAMENO_KEY, typeof(string));
                        // 生産車台番号終了
                        this.carPartsTable.Columns.Add(EDPRODUCEFRAMENO_KEY, typeof(string));

                        //-------ADD 2009/10/10------->>>>>
                        // 管理番号
                        this.carPartsTable.Columns.Add(MNGNO_KEY, typeof(string));
                        //-------ADD 2009/10/10-------<<<<<

                        this.carPartsTable.EndLoadData();

                        this.uGrid_CarPartsList.DataSource = carPartsTable;

                        #endregion

                        #region 出荷部品グリッド
                        this.uGrid_CarPartsList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        this.uGrid_CarPartsList.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;


                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsList.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // 全ての列をいったん非表示にする。
                            // 伝票日付
                            if (!SALESDATE_KEY.Equals(col.Key)
                                // 品名
                                && !GOODSNAME_KEY.Equals(col.Key)
                                //行番号 
                                && !ROWNO_KEY.Equals(col.Key)//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                                // 品番
                                && !GOODSNO_KEY.Equals(col.Key)
                                // メーカー
                                && !GOODSMAKERNAME_KEY.Equals(col.Key)
                                // BLコード
                                && !BLGOODSCD_KEY.Equals(col.Key)
                                // 在庫取寄区分
                                && !SALESORDERDIVCD_KEY.Equals(col.Key)
                                // 標準価格
                                && !LISTPRICETAXEXCFL_KEY.Equals(col.Key)
                                // 数量
                                && !SHIPMENTCNT_KEY.Equals(col.Key)
                                // 売単価
                                && !SALESUNPRCTAXEXCFL_KEY.Equals(col.Key)
                                // 売上金額
                                && !SALESMONEYTAXEXC_KEY.Equals(col.Key)
                                // 原単価
                                && !SALESUNITCOST_KEY.Equals(col.Key)
                                // 粗利
                                && !SALESMONEYTAXEXC_COST_KEY.Equals(col.Key)
                                // 粗利率
                                && !COST_SALESMONEYTAXEXC_KEY.Equals(col.Key)
                                // 備考
                                && !SLIPNOTE_KEY.Equals(col.Key)
                                // 車輌備考
                                && !CARNOTE_PARTS_KEY.Equals(col.Key)
                                // 伝票番号
                                && !SALESSLIPNUM_KEY.Equals(col.Key)
                                // 走行距離
                                && !MILEAGE_PARTS_KEY.Equals(col.Key))
                            {
                                col.Hidden = true;
                            }
                        }


                        // Filter設定
                        editBand.Columns[SALESDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[ROWNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSMAKERNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[BLGOODSCD_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESORDERDIVCD_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNT_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESUNITCOST_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SLIPNOTE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARNOTE_PARTS_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESSLIPNUM_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MILEAGE_PARTS_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MODEL1TO2_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                        // 表示幅設定
                        editBand.Columns[SALESDATE_KEY].Width = 120;
                        editBand.Columns[GOODSNAME_KEY].Width = 120;
                        editBand.Columns[ROWNO_KEY].Width = 120;//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].Width = 120;
                        editBand.Columns[GOODSMAKERNAME_KEY].Width = 120;
                        editBand.Columns[BLGOODSCD_KEY].Width = 120;
                        editBand.Columns[SALESORDERDIVCD_KEY].Width = 120;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNT_KEY].Width = 120;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Width = 120;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Width = 120;
                        editBand.Columns[SALESUNITCOST_KEY].Width = 120;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Width = 120;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Width = 120;
                        editBand.Columns[SLIPNOTE_KEY].Width = 120;
                        editBand.Columns[CARNOTE_PARTS_KEY].Width = 120;
                        editBand.Columns[SALESSLIPNUM_KEY].Width = 120;
                        editBand.Columns[MILEAGE_PARTS_KEY].Width = 120;
                        editBand.Columns[MODEL1TO2_KEY].Width = 120;

                        // グリッド名称
                        editBand.Columns[SALESDATE_KEY].Header.Caption = SALESDATE_TITLE;
                        editBand.Columns[GOODSNAME_KEY].Header.Caption = GOODSNAME_TITLE;
                        editBand.Columns[ROWNO_KEY].Header.Caption = ROWNO_TITLE;//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].Header.Caption = GOODSNO_TITLE;
                        editBand.Columns[GOODSMAKERNAME_KEY].Header.Caption = GOODSMAKERCD_TITLE;
                        editBand.Columns[BLGOODSCD_KEY].Header.Caption = BLGOODSCODE_TITLE;
                        editBand.Columns[SALESORDERDIVCD_KEY].Header.Caption = SALESORDERDIVCD_TITLE;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Header.Caption = LISTPRICETAXEXCFL_TITLE;
                        editBand.Columns[SHIPMENTCNT_KEY].Header.Caption = SHIPMENTCNT_TITLE;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Header.Caption = SALESUNPRCTAXEXCFL_TITLE;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Header.Caption = SALESMONEYTAXEXC_TITLE;
                        editBand.Columns[SALESUNITCOST_KEY].Header.Caption = SALESUNITCOST_TITLE;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Header.Caption = SALESMONEYTAXEXC_COST_TITLE;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Header.Caption = COST_SALESMONEYTAXEXC_TITLE;
                        editBand.Columns[SLIPNOTE_KEY].Header.Caption = SLIPNOTE_TITLE;
                        editBand.Columns[CARNOTE_PARTS_KEY].Header.Caption = CARNOTE_PARTS_TITLE;
                        editBand.Columns[SALESSLIPNUM_KEY].Header.Caption = SALESSLIPNUM_TITLE;
                        editBand.Columns[MILEAGE_PARTS_KEY].Header.Caption = MILEAGE_PARTS_TITLE;
                        editBand.Columns[MODEL1TO2_KEY].Header.Caption = MODEL1TO2_TITLE;

                        // 固定列設定
                        editBand.Columns[SALESDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESDATE_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNAME_KEY].Header.Fixed = false;
                        //-----ADD BY 凌小青　on 2012/08/09 for Redmine#31532------->>>>>>>
                        editBand.Columns[ROWNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ROWNO_KEY].Header.Fixed = false;
                        //-----ADD BY 凌小青　on 2012/08/09 for Redmine#31532-------<<<<<<<
                        editBand.Columns[GOODSNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNO_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSMAKERNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSMAKERNAME_KEY].Header.Fixed = false;
                        editBand.Columns[BLGOODSCD_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[BLGOODSCD_KEY].Header.Fixed = false;
                        editBand.Columns[SALESORDERDIVCD_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESORDERDIVCD_KEY].Header.Fixed = false;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNT_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNT_KEY].Header.Fixed = false;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Header.Fixed = false;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Header.Fixed = false;
                        editBand.Columns[SALESUNITCOST_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESUNITCOST_KEY].Header.Fixed = false;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Header.Fixed = false;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Header.Fixed = false;
                        editBand.Columns[SLIPNOTE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SLIPNOTE_KEY].Header.Fixed = false;
                        editBand.Columns[CARNOTE_PARTS_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARNOTE_PARTS_KEY].Header.Fixed = false;
                        editBand.Columns[SALESSLIPNUM_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESSLIPNUM_KEY].Header.Fixed = false;
                        editBand.Columns[MILEAGE_PARTS_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MILEAGE_PARTS_KEY].Header.Fixed = false;
                        editBand.Columns[MODEL1TO2_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MODEL1TO2_KEY].Header.Fixed = false;

                        // CellAppearance設定
                        editBand.Columns[SALESDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ROWNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSMAKERNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[BLGOODSCD_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESORDERDIVCD_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNT_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESUNITCOST_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SLIPNOTE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARNOTE_PARTS_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SALESSLIPNUM_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[MILEAGE_PARTS_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[MODEL1TO2_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                        // 入力許可設定
                        editBand.Columns[SALESDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ROWNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSMAKERNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[BLGOODSCD_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESORDERDIVCD_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNT_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESUNITCOST_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SLIPNOTE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARNOTE_PARTS_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESSLIPNUM_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MILEAGE_PARTS_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MODEL1TO2_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;


                        // Style設定
                        editBand.Columns[SALESDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ROWNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSMAKERNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[BLGOODSCD_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESORDERDIVCD_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNT_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESUNITCOST_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SLIPNOTE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARNOTE_PARTS_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESSLIPNUM_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MILEAGE_PARTS_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MODEL1TO2_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


                        #endregion

                        break;
                    }
                case 3:
                    {
                        #region 出荷部品（合計）グリッド

                        this.carPartsTotalTable.BeginLoadData();
                        // グリッド用
                        // 品名
                        this.carPartsTotalTable.Columns.Add(GOODSNAME_TOTAL_KEY, typeof(string));
                        // 品番
                        this.carPartsTotalTable.Columns.Add(GOODSNO_TOTAL_KEY, typeof(string));
                        // メーカー
                        this.carPartsTotalTable.Columns.Add(GOODSMAKERNAME_TOTAL_KEY, typeof(string));
                        // BLコード
                        this.carPartsTotalTable.Columns.Add(BLGOODSCODE_TOTAL_KEY, typeof(string));
                        // 数量
                        this.carPartsTotalTable.Columns.Add(SHIPMENTCNT_TOTAL_KEY, typeof(string));
                        // 売上金額
                        this.carPartsTotalTable.Columns.Add(SALESMONEYTAXEXC_TOTAL_KEY, typeof(string));
                        // 出荷回数
                        this.carPartsTotalTable.Columns.Add(COUNT_TOTAL_KEY, typeof(string));
                        // 倉庫
                        this.carPartsTotalTable.Columns.Add(WAREHOUSE_TOTAL_KEY, typeof(string));
                        // 棚番
                        this.carPartsTotalTable.Columns.Add(SHELFNO_TOTAL_KEY, typeof(string));
                        // 現在庫数
                        this.carPartsTotalTable.Columns.Add(SHIPMENTPOSCNT_TOTAL_KEY, typeof(string));
                        // 数量（在庫）
                        this.carPartsTotalTable.Columns.Add(SHIPMENTCNTIN_TOTAL_KEY, typeof(string));
                        // 数量（取寄）
                        this.carPartsTotalTable.Columns.Add(SHIPMENTCNTOUT_TOTAL_KEY, typeof(string));

                        // メーカーコード
                        this.carPartsTotalTable.Columns.Add(GOODSMAKERCD_TOTAL_KEY, typeof(string));
                        // 倉庫コード
                        this.carPartsTotalTable.Columns.Add(WAREHOUSECODE_TOTAL_KEY, typeof(string));
                        this.carPartsTotalTable.EndLoadData();

                        this.uGrid_CarPartsTotalList.DataSource = carPartsTotalTable;

                        #endregion

                        #region 出荷部品（合計）グリッド
                        this.uGrid_CarPartsTotalList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        this.uGrid_CarPartsTotalList.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;


                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // 全ての列をいったん非表示にする。
                            // 品名
                            if (GOODSMAKERCD_TOTAL_KEY.Equals(col.Key)
                                // 品番
                                || WAREHOUSECODE_TOTAL_KEY.Equals(col.Key))
                            {
                                col.Hidden = true;
                            }
                        }

                        // Filter設定
                        editBand.Columns[GOODSNAME_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSNO_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[COUNT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHELFNO_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                        // 表示幅設定
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Width = 120;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Width = 120;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Width = 120;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Width = 120;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Width = 120;
                        editBand.Columns[COUNT_TOTAL_KEY].Width = 120;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Width = 120;

                        // グリッド名称
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Header.Caption = GOODSNAME_TOTAL_TITLE;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Header.Caption = GOODSNO_TOTAL_TITLE;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Header.Caption = GOODSMAKERCD_TOTAL_TITLE;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Header.Caption = BLGOODSCODE_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Header.Caption = SHIPMENTCNT_TOTAL_TITLE;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Header.Caption = SALESMONEYTAXEXC_TOTAL_TITLE;
                        editBand.Columns[COUNT_TOTAL_KEY].Header.Caption = COUNT_TOTAL_TITLE;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Header.Caption = WAREHOUSE_TOTAL_TITLE;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Header.Caption = SHELFNO_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Header.Caption = SHIPMENTPOSCNT_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Header.Caption = SHIPMENTCNTIN_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Header.Caption = SHIPMENTCNTOUT_TOTAL_TITLE;

                        // 固定列設定
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[COUNT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[COUNT_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Header.Fixed = false;

                        // CellAppearance設定
                        editBand.Columns[GOODSNAME_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSNO_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[COUNT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SHELFNO_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                        // 入力許可設定
                        editBand.Columns[GOODSNAME_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSNO_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[COUNT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHELFNO_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                        // Style設定
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[COUNT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        #endregion

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region ■ 列幅自動調整 ■

        /// <summary>
        /// 列幅自動調整
        /// </summary>
        /// <param name="autoAdjust">自動調整するかどうか</param>
        /// <param name="targetGrid">対象となるグリッド 0:車輌検索, 1:出荷部品, 2:出荷部品（合計） 3:車輌情報</param>
        /// <remarks>
        /// <br>Note        : 車輌情報検索処理を行う。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust, int targetGrid)
        {
            switch (targetGrid)
            {
                #region 車輌検索グリッド
                case 0:
                    {
                        if (this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                             this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // 自動調整プロパティを調整
                        if (autoAdjust)
                        {
                            this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // 全ての列でサイズ調整
                        for (int i = 0; i < this.uGrid_CarSearchList.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarSearchList.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                #region 出荷部品グリッド
                case 1:
                    {
                        if (this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                             this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // 自動調整プロパティを調整
                        if (autoAdjust)
                        {
                            this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // 全ての列でサイズ調整
                        for (int i = 0; i < this.uGrid_CarPartsList.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarPartsList.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                #region 出荷部品（合計）グリッド
                case 2:
                    {
                        //if (this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                        //     this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // 自動調整プロパティを調整
                        if (autoAdjust)
                        {
                            this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // 全ての列でサイズ調整
                        for (int i = 0; i < this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                #region 車輌情報グリッド
                case 3:
                    {
                        if (this.uGrid_CarSpec.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                             this.uGrid_CarSpec.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // 自動調整プロパティを調整
                        if (autoAdjust)
                        {
                            this.uGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // 全ての列でサイズ調整
                        for (int i = 0; i < this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                default: break;
            }
        }

        #endregion

        #region ■ 入力チェック処理 ■
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 入力チェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);


                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// エラーメッセージ処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note		: 画面のエラーメッセージ処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                CT_PGID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_NoInput = "を入力して下さい。";
            const string ct_InputError = "の入力が不正です。";

            if (this.tComboEditor_DisplayDiv.SelectedIndex == 2)
            {
                // 型式
                if (string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))
                {
                    errMessage = string.Format("型式{0}", ct_NoInput);
                    errComponent = this.tEdit_FullModel;
                    status = false;

                    return status;
                }
            }

            DateGetAcs.CheckDateResult cdResult;

            if (this.tDateEdit_SalesDateSt.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_SalesDateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("開始日{0}", ct_InputError);
                    errComponent = this.tDateEdit_SalesDateSt;
                    status = false;

                    return status;
                }
            }

            if (this.tDateEdit_SalesDateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_SalesDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("終了日{0}", ct_InputError);
                    errComponent = this.tDateEdit_SalesDateEd;
                    status = false;
                    return status;
                }

                if (this.tDateEdit_SalesDateSt.GetDateTime() > this.tDateEdit_SalesDateEd.GetDateTime())
                {
                    errMessage = "売上日の範囲指定に誤りがあります。";
                    errComponent = this.tDateEdit_SalesDateEd;
                    status = false;
                    return status;
                }
            }

            if (this.tDateEdit_AddUpADateSt.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_AddUpADateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("開始日{0}", ct_InputError);
                    errComponent = this.tDateEdit_AddUpADateSt;
                    status = false;

                    return status;
                }
            }

            if (this.tDateEdit_AddUpADateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_AddUpADateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("終了日{0}", ct_InputError);
                    errComponent = this.tDateEdit_AddUpADateEd;
                    status = false;
                    return status;
                }

                if (this.tDateEdit_AddUpADateSt.GetDateTime() > this.tDateEdit_AddUpADateEd.GetDateTime())
                {
                    errMessage = "入力日の範囲指定に誤りがあります。";
                    errComponent = this.tDateEdit_AddUpADateEd;
                    status = false;
                    return status;
                }
            }

            return status;
        }
        #endregion

        #region ■ 車輌情報検索 ■
        /// <summary>
        /// 車輌情報検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 車輌情報検索処理を行う。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// <br>Update Note : SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer  : FSI厚川 宏</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void SearchProcess()
        {
            // グリット情報クリア
            this.carSearchTable.Clear();
            this.carPartsTable.Clear();
            this.carPartsTotalTable.Clear();
            this.carSpecTable.Clear();
            this.uGrid_CarSearchList.Visible = true;
            this.uGrid_CarPartsList.Visible = false;
            this.uGrid_CarPartsTotalList.Visible = false;
            // 車輌情報クリア
            this.CarInfoClear();
            // 抽出条件枠を最小化
            this.uGroupBox_ExtractCondition.Expanded = false;

            CarManagementWork carManagementWork = new CarManagementWork();
            // 得意先コード
            carManagementWork.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // 企業コード
            carManagementWork.EnterpriseCode = _enterpriseCode;
            // 管理番号
            carManagementWork.CarMngCode = this.tEdit_CarMngCode.Text.Trim();
            // 管理番号検索区分
            carManagementWork.CarMngCodeSearchDiv = this.tComboEditor_CarMngCode.SelectedIndex;
            // 型式
            carManagementWork.KindModel = this.tEdit_FullModel.Text.Trim();
            // 型式検索区分
            carManagementWork.KindModelSearchDiv = this.tComboEditor_FullModelFuzzy.SelectedIndex;
            // 車輌備考
            carManagementWork.CarNote = this.tEdit_SlipNote.Text.Trim();
            // 車輌備考検索区分
            carManagementWork.CarNoteSearchDiv = this.tComboEditor_SlipNoteFuzzy.SelectedIndex;

            object carMngWorkObj = (object)carManagementWork;
            ArrayList carMngWorkList = new ArrayList();
            object carMngWorkListObj = (object)carMngWorkList;
            int status = _carPartDisplayAcs.CarInfoSearch(carMngWorkObj, ref carMngWorkListObj);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                DataRow dataRow;
                ArrayList carMngList = carMngWorkListObj as ArrayList;
                CustomerSearchRet customerWork = null;
                foreach (CarManagementWork work in carMngList)
                {
                    dataRow = this.carSearchTable.NewRow();
                    // 得意先名称
                    if (this._customerSearchRetDic.Count == 0)
                    {
                        this.LoadCustomerSearchRet();
                    }
                    if (this._customerSearchRetDic.ContainsKey(work.CustomerCode))
                    {
                        customerWork = this._customerSearchRetDic[work.CustomerCode];
                        dataRow[CUSTOMERSUBNAME_KEY] = customerWork.Snm;
                    }
                    else
                    {
                        dataRow[CUSTOMERSUBNAME_KEY] = string.Empty;
                    }
                    // 管理番号
                    dataRow[MNGNO_KEY] = work.CarMngCode;
                    // 原動機型式
                    dataRow[ENGINEMODEL_KEY] = work.EngineModel;
                    // 追加情報１
                    dataRow[CARADDINFO1_KEY] = work.CarAddInfo1;
                    // 追加情報２
                    dataRow[CARADDINFO2_KEY] = work.CarAddInfo2;
                    // 登録番号
                    // ------UPD 2009/10/10-------------->>>>>
                    if (work.NumberPlate4 == 0)
                    {
                        dataRow[INSERTNO_KEY] = work.NumberPlate1Name.PadRight(4, '　')
                            + work.NumberPlate2.PadLeft(3, ' ')
                            + work.NumberPlate3.PadRight(1, '　');
                    }
                    else
                    {
                        dataRow[INSERTNO_KEY] = work.NumberPlate1Name.PadRight(4, '　')
                        + work.NumberPlate2.PadLeft(3, ' ')
                        + work.NumberPlate3.PadRight(1, '　')
                        + work.NumberPlate4.ToString().PadLeft(4, ' ');
                    }
                    // ------UPD 2009/10/10--------------<<<<<
                    // 走行距離
                    dataRow[MILEAGE_KEY] = work.Mileage.ToString("#,##0");
                    // 車検期間
                    if (work.CarInspectYear == 0)
                    {
                        dataRow[CARINSPECTYEAR_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[CARINSPECTYEAR_KEY] = work.CarInspectYear.ToString("d2");
                    }

                    // 登録年月日
                    if (work.EntryDate == DateTime.MinValue)
                    {
                        dataRow[ENTRYDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[ENTRYDATE_KEY] = work.EntryDate.ToString(DATEFORMAT_YYYYMMDD);
                    }
                    // 前回車検日
                    if (work.LTimeCiMatDate == DateTime.MinValue)
                    {
                        dataRow[LTIMECIMATDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[LTIMECIMATDATE_KEY] = work.LTimeCiMatDate.ToString(DATEFORMAT_YYYYMMDD);
                    }
                    // 次回車検日
                    if (work.InspectMaturityDate == DateTime.MinValue)
                    {
                        dataRow[INSPECTMATURITYDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[INSPECTMATURITYDATE_KEY] = work.InspectMaturityDate.ToString(DATEFORMAT_YYYYMMDD);
                    }
                    // 車輌備考
                    dataRow[CARNOTE_KEY] = work.CarNote;

                    // 画面表示用
                    // 得意先コード
                    dataRow[CUSTOMERCODE_KEY] = work.CustomerCode;
                    // 型式（シリーズ型式＋型式（類別記号））
                    if (string.IsNullOrEmpty(work.SeriesModel) && string.IsNullOrEmpty(work.CategorySignModel))
                    {
                        dataRow[KINDMODEL_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[KINDMODEL_KEY] = work.SeriesModel + "-" + work.CategorySignModel;
                    }

                    // 型式指定番号
                    if (work.ModelDesignationNo == 0)
                    {
                        dataRow[MODELDESIGNATIONNO_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MODELDESIGNATIONNO_KEY] = work.ModelDesignationNo.ToString("00000");
                    }
                    // 類別番号
                    if (work.CategoryNo == 0)
                    {
                        dataRow[CATEGORYNO_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[CATEGORYNO_KEY] = work.CategoryNo.ToString("0000");
                    }
                    // エンジン型式
                    dataRow[ENGINEMODELNM_KEY] = work.EngineModelNm;
                    // 車種（メーカーコード）
                    if (work.MakerCode == 0)
                    {
                        dataRow[MAKERCODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MAKERCODE_KEY] = work.MakerCode.ToString("000");
                    }
                    // 車種（車種コード）
                    if (work.ModelCode == 0)
                    {
                        dataRow[MODELCODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MODELCODE_KEY] = work.ModelCode.ToString("000");
                    }
                    // 車種（呼称コード）
                    if (work.ModelSubCode == 0)
                    {
                        dataRow[MODELSUBCODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MODELSUBCODE_KEY] = work.ModelSubCode.ToString("000");
                    }
                    // 車種名称
                    dataRow[MODELFULLNAME_KEY] = work.ModelFullName;
                    // 型式（フル型）
                    dataRow[FULLMODEL_KEY] = work.FullModel;
                    // 年式
                    if (work.FirstEntryDate == 0)
                    {
                        dataRow[FIRSTENTRYDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[FIRSTENTRYDATE_KEY] = dataRow[FIRSTENTRYDATE_KEY].ToString().PadLeft(6, '0');
                        dataRow[FIRSTENTRYDATE_KEY] = work.FirstEntryDate.ToString().Substring(0, 4) + "/" + work.FirstEntryDate.ToString().Substring(4);
                    }
                    // (生産年式 開始-終了)
                    if (work.StProduceTypeOfYear == DateTime.MinValue && work.EdProduceTypeOfYear == DateTime.MinValue)
                    {
                        dataRow[STEDPRODUCETYPEOFYEAR_KEY] = string.Empty;
                    }
                    else
                    {
                        // 0:西暦
                        if (this._allDefSet.EraNameDispCd1 == 0)
                        {
                            if (work.StProduceTypeOfYear == DateTime.MinValue)
                            {
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                            else if (work.EdProduceTypeOfYear == DateTime.MinValue)
                            {
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-";
                            }
                            else
                            {
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                        }
                        // 1:和歴
                        else
                        {
                            string stProduceTypeOfYear = this.GetProduceTypeOfYear(work.StProduceTypeOfYear);
                            string edProduceTypeOfYear = this.GetProduceTypeOfYear(work.EdProduceTypeOfYear);
                            dataRow[STEDPRODUCETYPEOFYEAR_KEY] = this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);
                        }
                    }

                    // 車台番号
                    dataRow[FRAMENO_KEY] = work.FrameNo;
                    // (車台番号 開始-終了)
                    if (work.StProduceFrameNo == 0 && work.EdProduceFrameNo == 0)
                    {
                        dataRow[STEDPRODUCEFRAMENO_KEY] = string.Empty;
                    }
                    else
                    {
                        if (work.StProduceFrameNo == 0)
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = "".PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo);
                        }
                        else if (work.EdProduceFrameNo == 0)
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo) + "-" + "".PadLeft(8, ' ');
                        }
                        else
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo).PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo).PadLeft(8, ' ');
                        }
                    }
                    // カラー
                    dataRow[COLORCODE_KEY] = work.ColorCode;
                    // トリム
                    dataRow[TRIMCODE_KEY] = work.TrimCode;
                    // 型式グレード名称
                    dataRow[MODELGRADENM_KEY] = work.ModelGradeNm;
                    // ボディー名称
                    dataRow[BODYNAME_KEY] = work.BodyName;
                    // ドア数
                    if (work.DoorCount == 0)
                    {
                        dataRow[DOORCOUNT_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[DOORCOUNT_KEY] = work.DoorCount;
                    }
                    // エンジン型式名称
                    //dataRow[ENGINEMODELNM_TITLE] = work.EngineModelNm;
                    // 排気量名称
                    dataRow[ENGINEDISPLACENM_KEY] = work.EngineDisplaceNm;
                    // E区分名称
                    dataRow[EDIVNM_KEY] = work.EDivNm;
                    // ミッション名称
                    dataRow[TRANSMISSIONNM_KEY] = work.TransmissionNm;
                    // 駆動方式名称
                    dataRow[WHEELDRIVEMETHODNM_KEY] = work.WheelDriveMethodNm;
                    // シフト名称
                    dataRow[SHIFTNM_KEY] = work.ShiftNm;
                    // 追加諸元タイトル１
                    dataRow[ADDICARSPECTITLE1_KEY] = work.AddiCarSpecTitle1;
                    // 追加諸元タイトル２
                    dataRow[ADDICARSPECTITLE2_KEY] = work.AddiCarSpecTitle2;
                    // 追加諸元タイトル３
                    dataRow[ADDICARSPECTITLE3_KEY] = work.AddiCarSpecTitle3;
                    // 追加諸元タイトル４
                    dataRow[ADDICARSPECTITLE4_KEY] = work.AddiCarSpecTitle4;
                    // 追加諸元タイトル５
                    dataRow[ADDICARSPECTITLE5_KEY] = work.AddiCarSpecTitle5;
                    // 追加諸元タイトル６
                    dataRow[ADDICARSPECTITLE6_KEY] = work.AddiCarSpecTitle6;
                    // 追加諸元１
                    dataRow[ADDICARSPEC1_KEY] = work.AddiCarSpec1;
                    // 追加諸元２
                    dataRow[ADDICARSPEC2_KEY] = work.AddiCarSpec2;
                    // 追加諸元３
                    dataRow[ADDICARSPEC3_KEY] = work.AddiCarSpec3;
                    // 追加諸元４
                    dataRow[ADDICARSPEC4_KEY] = work.AddiCarSpec4;
                    // 追加諸元５
                    dataRow[ADDICARSPEC5_KEY] = work.AddiCarSpec5;
                    // 追加諸元６
                    dataRow[ADDICARSPEC6_KEY] = work.AddiCarSpec6;

                    // 陸運事務所番号
                    if (work.NumberPlate1Code == 0)
                    {
                        dataRow[NUMBERPLATE1CODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[NUMBERPLATE1CODE_KEY] = work.NumberPlate1Code.ToString().PadLeft(4, '0');
                    }

                    // 陸運事務局名称
                    dataRow[NUMBERPLATE1NAME_KEY] = work.NumberPlate1Name;
                    // 車両登録番号（種別）
                    dataRow[NUMBERPLATE2_KEY] = work.NumberPlate2;
                    // 車両登録番号（カナ）
                    dataRow[NUMBERPLATE3_KEY] = work.NumberPlate3;
                    // 車両登録番号（プレート番号）
                    if (work.NumberPlate4 == 0)
                    {
                        dataRow[NUMBERPLATE4_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[NUMBERPLATE4_KEY] = work.NumberPlate4;
                    }

                    // 車両管理番号
                    dataRow[MNGNOTEMP_KEY] = work.CarMngNo;
                    // カラー名称
                    if (string.IsNullOrEmpty(work.ColorName1))
                    {
                        work.ColorName1 = string.Empty;
                    }
                    dataRow[COLORNAME1_KEY] = work.ColorName1;
                    // トリム名称
                    if (string.IsNullOrEmpty(work.TrimName))
                    {
                        work.TrimName = string.Empty;
                    }
                    // dataRow[TRIMNAME_KEY] = work.ColorName1; // DEL 2009/10/10 wuyx
                    dataRow[TRIMNAME_KEY] = work.TrimName; // ADD 2009/10/10 wuyx
                    
                    // --- ADD 2013/03/25 ---------->>>>>
                    // 国産/外車区分
                    if (work.DomesticForeignCode == 0)
                    {
                        dataRow[DOMESTICFOREIGNCODERF_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[DOMESTICFOREIGNCODERF_KEY] = work.DomesticForeignCode.ToString();
                    }
                    // --- ADD 2013/03/25 ----------<<<<<

                    this.carSearchTable.Rows.Add(dataRow);

                }
                if (carMngList.Count > 0)
                {
                    this.uGrid_CarSearchList.Focus();
                    this.uGrid_CarSearchList.ActiveRow = this.uGrid_CarSearchList.Rows[0];
                    this.uGrid_CarSearchList.ActiveRow.Selected = true;
                    this.uGrid_CarSearchList.Refresh();
                    // テキスト出力
                    this._textOutButton.SharedProps.Enabled = true;
                }
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                // テキスト出力
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当するデータが存在しません。",
                    0,
                    MessageBoxButtons.OK);
            }
            else
            {
                // テキスト出力
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "画面検索処理に失敗しました。",
                    0,
                    MessageBoxButtons.OK);
            }
        }
        #endregion

        #region ■ 車輌部品情報検索 ■
        /// <summary>
        /// 車輌部品情報検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 車輌部品情報検索処理を行う。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// <br>Update Note : SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer  : FSI厚川 宏</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void SearchPartsProcess()
        {
            // グリット情報クリア
            if (this.tComboEditor_DisplayDiv.SelectedIndex == 1)
            {
                // グリット情報クリア
                this.carSearchTable.Clear();
                this.carPartsTable.Clear();
                this.carPartsTotalTable.Clear();
                this.carSpecTable.Clear();
                this.uGrid_CarSearchList.Visible = false;
                this.uGrid_CarPartsList.Visible = true;
                this.uGrid_CarPartsTotalList.Visible = false;
            }
            else if (this.tComboEditor_DisplayDiv.SelectedIndex == 2)
            {
                // グリット情報クリア
                this.carSearchTable.Clear();
                this.carPartsTable.Clear();
                this.carPartsTotalTable.Clear();
                this.carSpecTable.Clear();
                this.uGrid_CarSearchList.Visible = false;
                this.uGrid_CarPartsList.Visible = false;
                this.uGrid_CarPartsTotalList.Visible = true;

                this.uLabel_ModelDesignationNoData.Text = string.Empty;
                this.uLabel_ModelKindNo.Text = string.Empty;
                this.uLabel_EngineModelNmData.Text = string.Empty;
                this.uLabel_FullModelTitleInfoData.Text = string.Empty;
                this.uLabel_ModelMaker.Text = string.Empty;
                this.uLabel_ModelCode.Text = string.Empty;
                this.uLabel_ModelSubCode.Text = string.Empty;
                this.uLabel_ModelName.Text = string.Empty;
                this.tDateEdit_FirstEntryDate.Clear();
                this.uLabel_FirstEntryDateRange.Text = string.Empty;
                this.uLabel_ColorNoData.Text = string.Empty;
                this.uLabel_ProduceFrameNoData.Text = string.Empty;
                this.uLabel_ProduceFrameNoRange.Text = string.Empty;
                this.uLabel_TrimNoData.Text = string.Empty;

                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
            }

            // 車輌情報クリア
            this.CarInfoClear();
            CarInfoConditionWorkWork carInfoConditionWorkWork = new CarInfoConditionWorkWork();

            if (this._customerCode != this.tNedit_CustomerCode.GetInt()
                || !this._fullModel.Equals(this.tEdit_FullModel.Text)
                || this._fullModelCon != this.tComboEditor_FullModelFuzzy.SelectedIndex
                || !this._carMngNo.Equals(this.tEdit_CarMngCode.Text)
                || this._carMngNoCon != this.tComboEditor_CarMngCode.SelectedIndex)
            {
                this._carMngNoTemp = 0;
                this._customerCode = this.tNedit_CustomerCode.GetInt();
                this._fullModel = this.tEdit_FullModel.Text;
                this._fullModelCon = this.tComboEditor_FullModelFuzzy.SelectedIndex;
                this._carMngNo = this.tEdit_CarMngCode.Text;
                this._carMngNoCon = this.tComboEditor_CarMngCode.SelectedIndex;
            }
            // 拠点コード
            carInfoConditionWorkWork.SectionCode = this.tEdit_SectionCodeAllowZero.Text;
            // 得意先コード
            carInfoConditionWorkWork.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // 企業コード
            carInfoConditionWorkWork.EnterpriseCode = _enterpriseCode;
            // 管理番号
            carInfoConditionWorkWork.CarMngCode = this.tEdit_CarMngCode.Text.Trim();
            // 管理番号検索区分
            carInfoConditionWorkWork.CarMngCodeDiv = this.tComboEditor_CarMngCode.SelectedIndex;
            // 売上日（開始）
            carInfoConditionWorkWork.StSalesDate = this.tDateEdit_SalesDateSt.GetLongDate();
            // 売上日（終了）
            carInfoConditionWorkWork.EdSalesDate = this.tDateEdit_SalesDateEd.GetLongDate();
            // 入力日（開始）
            carInfoConditionWorkWork.StInputDate = this.tDateEdit_AddUpADateSt.GetLongDate();
            // 入力日（開始）
            carInfoConditionWorkWork.EdInputDate = this.tDateEdit_AddUpADateEd.GetLongDate();
            // 型式
            carInfoConditionWorkWork.FullModel = this.tEdit_FullModel.Text.Trim();
            // 型式検索区分
            carInfoConditionWorkWork.FullModelDiv = this.tComboEditor_FullModelFuzzy.SelectedIndex;
            // 車輌備考
            carInfoConditionWorkWork.CarNote = this.tEdit_SlipNote.Text.Trim();
            // 車輌備考検索区分
            carInfoConditionWorkWork.CarNoteDiv = this.tComboEditor_SlipNoteFuzzy.SelectedIndex;
            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            carInfoConditionWorkWork.BLGroupCode = this._swBLGroupCode;
            // BLコード
            carInfoConditionWorkWork.BLGoodsCode = this._swBLGoodsCode;
            // 品名
            carInfoConditionWorkWork.GoodsName = this.tEdit_GoodsName.Text.Trim();
            // 品名検索区分
            carInfoConditionWorkWork.GoodsNameDiv = this.tComboEditor_GoodsNameFuzzy.SelectedIndex;
            // 品番
            carInfoConditionWorkWork.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
            // 品番検索区分
            carInfoConditionWorkWork.GoodsNoDiv = this.tComboEditor_GoodsNoFuzzy.SelectedIndex;
            // 在庫取寄区分
            carInfoConditionWorkWork.SalesOrderDivCd = this.tComboEditor_SalesOrderDivCd.SelectedIndex;
            // 倉庫
            carInfoConditionWorkWork.WarehouseCode = this._swWarehouseCd;
            // 表示区分
            carInfoConditionWorkWork.DispDiv = this.tComboEditor_DisplayDiv.SelectedIndex;
            // 車両管理番号
            carInfoConditionWorkWork.CarMngNo = this._carMngNoTemp;

            object carInfoConditionWorkWorkObj = (object)carInfoConditionWorkWork;
            ArrayList carMngWorkList = new ArrayList();

            int status = _carPartDisplayAcs.CarPartsInfoSearch(carInfoConditionWorkWorkObj, ref carMngWorkList);
            int i = 0; // ADD 2009/10/10
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                DataRow dataRow;
                #region 出荷部品
                // 表示区分「出荷部品」時
                if (this.tComboEditor_DisplayDiv.SelectedIndex == 1)
                {
                    foreach (CarShipmentPartsDispWork work in carMngWorkList)
                    {
                        dataRow = this.carPartsTable.NewRow();
                        // 伝票日付
                        if (work.SalesDate == DateTime.MinValue)
                        {
                            dataRow[SALESDATE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[SALESDATE_KEY] = work.SalesDate.ToString(DATEFORMAT_YYYYMMDD);
                        }
                        // 品名
                        dataRow[GOODSNAME_KEY] = work.GoodsName;
                        // -------ADD BY 凌小青　on 2012/08/09 for Redmine#31532------->>>>>>>
                        //行番号
                        dataRow[ROWNO_KEY] = work.RowNo;
                        // -------ADD BY 凌小青　on 2012/08/09 for Redmine#31532-------<<<<<<<
                        // 品番
                        dataRow[GOODSNO_KEY] = work.GoodsNo;
                        // メーカー
                        dataRow[GOODSMAKERNAME_KEY] = work.MakerName;
                        // BLコード
                        // --- UPD 2009/09/27 -------------->>>
                        if (work.BLGoodsCode != 0)
                        {
                            dataRow[BLGOODSCD_KEY] = work.BLGoodsCode.ToString("d5");
                        }
                        else
                        {
                            dataRow[BLGOODSCD_KEY] = string.Empty;
                        }
                        // --- UPD 2009/09/27 --------------<<<
                        // 在庫取寄区分
                        if (work.SalesOrderDivCd == 0)
                        {
                            dataRow[SALESORDERDIVCD_KEY] = "取寄";
                        }
                        else if (work.SalesOrderDivCd == 1)
                        {
                            dataRow[SALESORDERDIVCD_KEY] = "在庫";
                        }

                        // --- UPD 2009/10/10 ------------>>>>>
                        // 管理番号
                        dataRow[MNGNO_KEY] = work.CarMngCode;
                        // 検索結果テーブル1.定価（税抜，浮動）
                        dataRow[LISTPRICETAXEXCFL_KEY] = work.ListPriceTaxExcFl.ToString("#,##0");
                        // 数量
                        dataRow[SHIPMENTCNT_KEY] = douToStrChange(work.ShipmentCnt);
                        // 売単価
                        dataRow[SALESUNPRCTAXEXCFL_KEY] = douToStrChange(work.SalesUnPrcTaxExcFl);
                        // 売上金額
                        long salesMoneyTax = work.SalesMoneyTaxExc;
                        dataRow[SALESMONEYTAXEXC_KEY] = salesMoneyTax.ToString("#,##0");
                        // 原単価
                        dataRow[SALESUNITCOST_KEY] = douToStrChange(work.SalesUnitCost);
                        // 粗利
                        long salesMoney;
                        //売上履歴明細データ
                        if (-999999999 != work.Cost)
                        {
                            salesMoney = work.SalesMoneyTaxExc - work.Cost;
                            dataRow[SALESMONEYTAXEXC_COST_KEY] = salesMoney.ToString("#,##0");
                        }
                        else
                        {
                            //車輌部品データ(コンバート)
                            // salesMoney = work.SalesMoneyTaxExc - Convert.ToInt64(work.SalesUnitCost * work.ShipmentCnt);
                            //salesMoney = work.GrossProfit;
                            dataRow[SALESMONEYTAXEXC_COST_KEY] = work.GrossProfit.ToString("#,##0");
                        }
                        // 粗利率 
                        double salesMoneyRate;
                        try
                        {
                            if (-999999999 != work.Cost)
                            {
                                // 粗利 ÷ 売上金額 をセット
                                salesMoneyRate = Convert.ToDouble((work.SalesMoneyTaxExc - work.Cost)) / Convert.ToDouble(salesMoneyTax) * 100;
                            }
                            else
                            {
                                // 粗利 ÷ 売上金額 をセット
                                salesMoneyRate = Convert.ToDouble(work.GrossProfit) / Convert.ToDouble(salesMoneyTax) * 100;
                            }
                            // 少数点以下第二位までセット（第３位を四捨五入）
                            FractionCalculate.FracCalcMoney(salesMoneyRate, 0.01, 2, out salesMoneyRate);
                        }
                        catch
                        {
                            salesMoneyRate = 0.00;
                        }
                        dataRow[COST_SALESMONEYTAXEXC_KEY] = douToStrChange(salesMoneyRate);
                        // --- UPD 2009/10/10 ------------<<<<<

                        // 備考
                        dataRow[SLIPNOTE_KEY] = work.SlipNote;
                        // 車輌備考
                        dataRow[CARNOTE_PARTS_KEY] = work.CarNote;
                        // 伝票番号
                        dataRow[SALESSLIPNUM_KEY] = work.SalesSlipNum;
                        // 走行距離
                        dataRow[MILEAGE_PARTS_KEY] = work.Mileage.ToString("#,##0");
                        // 型式1-2
                        if (string.IsNullOrEmpty(work.SeriesModel) && string.IsNullOrEmpty(work.CategorySignModel))
                        {
                            dataRow[MODEL1TO2_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODEL1TO2_KEY] = work.SeriesModel + '-' + work.CategorySignModel;
                        }
                        // 画面表示用
                        // 型式（シリーズ型式＋型式（類別記号））
                        if (string.IsNullOrEmpty(work.SeriesModel) && string.IsNullOrEmpty(work.CategorySignModel))
                        {
                            dataRow[KINDMODEL_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[KINDMODEL_KEY] = work.SeriesModel + '-' + work.CategorySignModel;
                        }
                        // 型式指定番号
                        if (work.ModelDesignationNo == 0)
                        {
                            dataRow[MODELDESIGNATIONNO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODELDESIGNATIONNO_KEY] = work.ModelDesignationNo.ToString("00000");
                        }
                        // 類別番号
                        if (work.CategoryNo == 0)
                        {
                            dataRow[CATEGORYNO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[CATEGORYNO_KEY] = work.CategoryNo.ToString("0000");
                        }
                        // エンジン型式
                        dataRow[ENGINEMODELNM_KEY] = work.EngineModelNm;
                        // 車種（メーカーコード）
                        if (work.MakerCode == 0)
                        {
                            dataRow[MAKERCODE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MAKERCODE_KEY] = work.MakerCode.ToString("000");
                        }
                        // 車種（車種コード）
                        if (work.ModelCode == 0)
                        {
                            dataRow[MODELCODE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODELCODE_KEY] = work.ModelCode.ToString("000");
                        }
                        // 車種（呼称コード）
                        if (work.ModelSubCode == 0)
                        {
                            dataRow[MODELSUBCODE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODELSUBCODE_KEY] = work.ModelSubCode.ToString("000");
                        }
                        // 車種名称
                        dataRow[MODELFULLNAME_KEY] = work.ModelFullName;
                        // 型式（フル型）
                        dataRow[FULLMODEL_KEY] = work.FullModel;
                        // 年式
                        if (work.FirstEntryDate == DateTime.MinValue)
                        {
                            dataRow[FIRSTENTRYDATE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[FIRSTENTRYDATE_KEY] = work.FirstEntryDate.ToString("yyyy/MM");
                        }
                        // (生産年式 開始-終了)
                        if (work.StProduceTypeOfYear == DateTime.MinValue && work.EdProduceTypeOfYear == DateTime.MinValue)
                        {
                            dataRow[STEDPRODUCETYPEOFYEAR_KEY] = string.Empty;
                        }
                        else
                        {
                            // 0:西暦
                            if (this._allDefSet.EraNameDispCd1 == 0)
                            {
                                if (work.StProduceTypeOfYear == DateTime.MinValue)
                                {
                                    dataRow[STEDPRODUCETYPEOFYEAR_KEY] = "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                                }
                                else if (work.EdProduceTypeOfYear == DateTime.MinValue)
                                {
                                    dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-";
                                }
                                else
                                {
                                    dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                                }
                            }
                            // 1:和歴
                            else
                            {
                                string stProduceTypeOfYear = this.GetProduceTypeOfYear(work.StProduceTypeOfYear);
                                string edProduceTypeOfYear = this.GetProduceTypeOfYear(work.EdProduceTypeOfYear);
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);
                            }
                        }
                        // 車台番号
                        if (string.IsNullOrEmpty(work.FrameNo) || work.FrameNo.Trim() == "0")
                        {
                            dataRow[FRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[FRAMENO_KEY] = work.FrameNo;
                        }

                        // (車台番号 開始-終了)
                        if (work.StProduceFrameNo == 0 && work.EdProduceFrameNo == 0)
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            if (work.StProduceFrameNo == 0)
                            {
                                dataRow[STEDPRODUCEFRAMENO_KEY] = "".PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo);
                            }
                            else if (work.EdProduceFrameNo == 0)
                            {
                                dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo) + "-" + "".PadLeft(8, ' ');
                            }
                            else
                            {
                                dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo).PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo).PadLeft(8, ' ');
                            }
                        }
                        // カラー
                        dataRow[COLORCODE_KEY] = work.ColorCode;
                        // トリム
                        dataRow[TRIMCODE_KEY] = work.TrimCode;
                        // 型式グレード名称
                        dataRow[MODELGRADENM_KEY] = work.ModelGradeNm;
                        // ボディー名称
                        dataRow[BODYNAME_KEY] = work.BodyName;
                        // ドア数
                        if (work.DoorCount == 0)
                        {
                            dataRow[DOORCOUNT_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[DOORCOUNT_KEY] = work.DoorCount;
                        }
                        // エンジン型式名称
                        //dataRow[ENGINEMODELNM_TITLE] = work.EngineModelNm;
                        // 排気量名称
                        dataRow[ENGINEDISPLACENM_KEY] = work.EngineDisplaceNm;
                        // E区分名称
                        dataRow[EDIVNM_KEY] = work.EDivNm;
                        // ミッション名称
                        dataRow[TRANSMISSIONNM_KEY] = work.TransmissionNm;
                        // 駆動方式名称
                        dataRow[WHEELDRIVEMETHODNM_KEY] = work.WheelDriveMethodNm;
                        // シフト名称
                        dataRow[SHIFTNM_KEY] = work.ShiftNm;
                        // 追加諸元タイトル１
                        dataRow[ADDICARSPECTITLE1_KEY] = work.AddiCarSpecTitle1;
                        // 追加諸元タイトル２
                        dataRow[ADDICARSPECTITLE2_KEY] = work.AddiCarSpecTitle2;
                        // 追加諸元タイトル３
                        dataRow[ADDICARSPECTITLE3_KEY] = work.AddiCarSpecTitle3;
                        // 追加諸元タイトル４
                        dataRow[ADDICARSPECTITLE4_KEY] = work.AddiCarSpecTitle4;
                        // 追加諸元タイトル５
                        dataRow[ADDICARSPECTITLE5_KEY] = work.AddiCarSpecTitle5;
                        // 追加諸元タイトル６
                        dataRow[ADDICARSPECTITLE6_KEY] = work.AddiCarSpecTitle6;
                        // 追加諸元１
                        dataRow[ADDICARSPEC1_KEY] = work.AddiCarSpec1;
                        // 追加諸元２
                        dataRow[ADDICARSPEC2_KEY] = work.AddiCarSpec2;
                        // 追加諸元３
                        dataRow[ADDICARSPEC3_KEY] = work.AddiCarSpec3;
                        // 追加諸元４
                        dataRow[ADDICARSPEC4_KEY] = work.AddiCarSpec4;
                        // 追加諸元５
                        dataRow[ADDICARSPEC5_KEY] = work.AddiCarSpec5;
                        // 追加諸元６
                        dataRow[ADDICARSPEC6_KEY] = work.AddiCarSpec6;


                        // メーカーコード
                        if (work.GoodsMakerCd == 0)
                        {
                            dataRow[GOODSMAKERCD_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[GOODSMAKERCD_KEY] = work.GoodsMakerCd.ToString("d4");
                        }

                        // カラー名称1
                        dataRow[COLORNAME1_KEY] = work.ColorName1;
                        // トリム名称
                        dataRow[TRIMNAME_KEY] = work.TrimName;
                        // 陸運事務所番号
                        dataRow[NUMBERPLATE1CODE_KEY] = work.NumberPlate1Code;
                        // 陸運事務局名称
                        dataRow[NUMBERPLATE1NAME_KEY] = work.NumberPlate1Name;
                        // 車両登録番号（種別）
                        dataRow[NUMBERPLATE2_KEY] = work.NumberPlate2;
                        // 車両登録番号（カナ）
                        dataRow[NUMBERPLATE3_KEY] = work.NumberPlate3;
                        // 車両登録番号（プレート番号）
                        dataRow[NUMBERPLATE4_KEY] = work.NumberPlate4;
                        // 生産車台番号開始
                        if (work.StProduceFrameNo == 0)
                        {
                            dataRow[STPRODUCEFRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[STPRODUCEFRAMENO_KEY] = work.StProduceFrameNo;
                        }
                        // 生産車台番号終了
                        if (work.EdProduceFrameNo == 0)
                        {
                            dataRow[EDPRODUCEFRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[EDPRODUCEFRAMENO_KEY] = work.EdProduceFrameNo;
                        }
                        // 開始生産年式
                        if (work.StProduceTypeOfYear == DateTime.MinValue)
                        {
                            dataRow[STPRODUCETYPEOFYEAR_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[STPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMMDD);
                        }
                        // 終了生産年式
                        if (work.EdProduceTypeOfYear == DateTime.MinValue)
                        {
                            dataRow[EDPRODUCETYPEOFYEAR_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[EDPRODUCETYPEOFYEAR_KEY] = work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMMDD);
                        }
                        // --- ADD 2013/03/25 ---------->>>>>
                        // 国産/外車区分
                        if (work.DomesticForeignCode == 0)
                        {
                            dataRow[DOMESTICFOREIGNCODERF_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[DOMESTICFOREIGNCODERF_KEY] = work.DomesticForeignCode.ToString();
                        }
                        // --- ADD 2013/03/25 ----------<<<<<

                        this.carPartsTable.Rows.Add(dataRow);

                        this.uGrid_CarPartsList.Refresh();

                        //-----------ADD 2009/10/10----->>>>>
                        i++;

                        if (work.ShipmentCnt < 0)
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsList.DisplayLayout.Bands[0];
                            if (editBand == null) return;

                            UltraGridRow ultraRow = this.uGrid_CarPartsList.Rows[i-1];
                            foreach (UltraGridCell ultraCell in ultraRow.Cells)
                            {
                                ultraCell.Appearance.ForeColor = Color.Red;
                            }
                        }
                        //-----------ADD 2009/10/10-----<<<<<

                    }

                    if (carMngWorkList.Count > 0)
                    {
                        this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
                        autoColumnAdjust(false, 1);
                        this.uGrid_CarPartsList.Focus();
                        this.uGrid_CarPartsList.ActiveRow = this.uGrid_CarPartsList.Rows[0];
                        this.uGrid_CarPartsList.ActiveRow.Selected = true;
                        this.uGrid_CarPartsList.Refresh();
                        // テキスト出力
                        this._textOutButton.SharedProps.Enabled = true;
                    }
                }
                #endregion 出荷部品

                #region 出荷部品（合計）
                // 表示区分「出荷部品（合計）」時
                else if (this.tComboEditor_DisplayDiv.SelectedIndex == 2)
                {
                    foreach (CarShipmentPartsDispWork work in carMngWorkList)
                    {
                        dataRow = this.carPartsTotalTable.NewRow();
                        // 品名
                        dataRow[GOODSNAME_TOTAL_KEY] = work.GoodsName;
                        // 品番
                        dataRow[GOODSNO_TOTAL_KEY] = work.GoodsNo;
                        // メーカー
                        dataRow[GOODSMAKERNAME_TOTAL_KEY] = work.MakerName;
                        // BLコード
                        // --- UPD 2009/09/27 -------------->>>
                        if (work.BLGoodsCode != 0)
                        {
                            dataRow[BLGOODSCODE_TOTAL_KEY] = work.BLGoodsCode.ToString("d5");
                        }
                        else
                        {
                            dataRow[BLGOODSCODE_TOTAL_KEY] = string.Empty;
                        }
                        // --- UPD 2009/09/27 --------------<<<
                        // 数量
                        dataRow[SHIPMENTCNT_TOTAL_KEY] = douToStrChange(work.ShipmentTotalCnt);
                            // --- UPD 2009/10/10 -------------->>>>>
                        // 売上金額
                        dataRow[SALESMONEYTAXEXC_TOTAL_KEY] = work.SalesMoneyTaxExcTotal.ToString("#,##0");
                        // 出荷回数
                        dataRow[COUNT_TOTAL_KEY] = work.ShipmentCntTotal.ToString("#,##0");
                        // --- UPD 2009/10/10 --------------<<<<<
                        // 倉庫
                        dataRow[WAREHOUSE_TOTAL_KEY] = work.WarehouseName;
                        // 棚番
                        dataRow[SHELFNO_TOTAL_KEY] = work.WarehouseShelfNo;
                        // 現在庫数
                        dataRow[SHIPMENTPOSCNT_TOTAL_KEY] = douToStrChange(work.ShipmentPosCnt);
                        // 数量（在庫）
                        dataRow[SHIPMENTCNTIN_TOTAL_KEY] = douToStrChange(work.ShipmentCntInTotal);
                        // 数量（取寄）
                        dataRow[SHIPMENTCNTOUT_TOTAL_KEY] = douToStrChange(work.ShipmentCntOutTotal);
                        // メーカーコード
                        if (work.GoodsMakerCd == 0)
                        {
                            dataRow[GOODSMAKERCD_TOTAL_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[GOODSMAKERCD_TOTAL_KEY] = work.GoodsMakerCd.ToString("d4");
                        }
                        // 倉庫コード
                        if (string.IsNullOrEmpty(work.WarehouseCode) || work.WarehouseCode.Trim().Equals("0"))
                        {
                            dataRow[WAREHOUSECODE_TOTAL_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[WAREHOUSECODE_TOTAL_KEY] = work.WarehouseCode;
                        }

                        this.carPartsTotalTable.Rows.Add(dataRow);

                        this.uGrid_CarPartsTotalList.Refresh();
                        //-----------ADD 2009/10/10----->>>>>
                        i++;

                        if (work.ShipmentTotalCnt < 0)
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsList.DisplayLayout.Bands[0];
                            if (editBand == null) return;

                            UltraGridRow ultraRow = this.uGrid_CarPartsTotalList.Rows[i - 1];
                            foreach (UltraGridCell ultraCell in ultraRow.Cells)
                            {
                                ultraCell.Appearance.ForeColor = Color.Red;
                            }
                        }
                        //-----------ADD 2009/10/10-----<<<<<

                    }
                    if (carMngWorkList.Count > 0)
                    {
                        this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
                        autoColumnAdjust(false, 2);
                        this.uGrid_CarPartsTotalList.Focus();
                        this.uGrid_CarPartsTotalList.ActiveRow = this.uGrid_CarPartsTotalList.Rows[0];
                        this.uGrid_CarPartsTotalList.ActiveRow.Selected = true;
                        this.uGrid_CarPartsTotalList.Refresh();
                        // テキスト出力
                        this._textOutButton.SharedProps.Enabled = true;
                    }
                }
                #endregion 出荷部品（合計）

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                // テキスト出力
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "該当するデータが存在しません。",
                    0,
                    MessageBoxButtons.OK);

            }
            else
            {
                // テキスト出力
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "画面検索処理に失敗しました。",
                    0,
                    MessageBoxButtons.OK);
            }
        }
        #endregion

        #region ■ 車輌情報選択変化時発生イベント ■
        /// <summary>
        /// 車輌情報選択変化時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 選択変化時に発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.09.10</br>
        /// <br>Update Note : SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer  : FSI厚川 宏</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void uGrid_CarSearchList_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            Type type = e.Type;

            // 行選択の場合
            if (type.Name.Equals("UltraGridRow"))
            {
                if (this.uGrid_CarSearchList.ActiveRow == null) return;
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_CarSearchList.ActiveRow;
                //// 得意先コード
                //this.tNedit_CustomerCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERCODE_TITLE]);
                //// 得意先略称
                //this.uLabel_CustomerName.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERSUBNAME_TITLE]);
                //------UPD 2009/10/20------>>>>>
                // 型式指定番号
                this.uLabel_ModelDesignationNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELDESIGNATIONNO_KEY].Value.ToString();
                // 類別番号
                this.uLabel_ModelKindNo.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[CATEGORYNO_KEY].Value.ToString();
                // エンジン型式
                this.uLabel_EngineModelNmData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // 型式
                this.uLabel_FullModelTitleInfoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[FULLMODEL_KEY].Value.ToString();
                // 車種（メーカーコード）
                this.uLabel_ModelMaker.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MAKERCODE_KEY].Value.ToString();
                // 車種（車種コード）
                this.uLabel_ModelCode.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELCODE_KEY].Value.ToString();
                // 車種（呼称コード）
                this.uLabel_ModelSubCode.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELSUBCODE_KEY].Value.ToString();
                // 車種名称
                this.uLabel_ModelName.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELFULLNAME_KEY].Value.ToString();
                // 年式
                string firstEntryYearMonth = this.uGrid_CarSearchList.Rows[row.Index].Cells[FIRSTENTRYDATE_KEY].Value.ToString().Replace("/", "");
                if (!string.IsNullOrEmpty(firstEntryYearMonth))
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(Int32.Parse(firstEntryYearMonth) * 100 + 1);
                }
                else
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(0);
                }
                // (生産年式 開始-終了)
                this.uLabel_FirstEntryDateRange.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[STEDPRODUCETYPEOFYEAR_KEY].Value.ToString();
                // 車台番号
                this.uLabel_ProduceFrameNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[FRAMENO_KEY].Value.ToString();
                // 車台番号 開始-終了
                this.uLabel_ProduceFrameNoRange.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[STEDPRODUCEFRAMENO_KEY].Value.ToString();
                // カラー
                this.uLabel_ColorNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[COLORCODE_KEY].Value.ToString();
                // トリム
                this.uLabel_TrimNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[TRIMCODE_KEY].Value.ToString();
                //------ADD 2009/10/10-------->>>>>
                // 車輌備考
                // this.tEdit_SlipNote.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CARNOTE_KEY]); // DEL 2009/10/19  Redmine567
                // 管理番号
                this.uLabel_CarMngCodeData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MNGNO_KEY].Value.ToString();
                //------ADD 2009/10/10--------<<<<<

                // --- ADD 2013/03/25 ---------->>>>>
                int divValue = 0;
                Int32.TryParse(this.uGrid_CarSearchList.Rows[row.Index].Cells[DOMESTICFOREIGNCODERF_KEY].Value.ToString(), out divValue);
                if (divValue == FOREIGNCODERF_DIV)
                {
                    this.uLabel_ProduceFrameNoRange.Visible = false;
                }
                else
                {
                    this.uLabel_ProduceFrameNoRange.Visible = true;
                }
                // --- ADD 2013/03/25 ----------<<<<<

                this.carSpecTable.Clear();

                DataRow dataRow;
                dataRow = this.carSpecTable.NewRow();
                // グレード
                dataRow[MODELGRADENM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELGRADENM_KEY].Value.ToString();
                // ボディ
                dataRow[BODYNAME_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[BODYNAME_KEY].Value.ToString();
                // ドア
                dataRow[DOORCOUNT_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[DOORCOUNT_KEY].Value.ToString();
                // エンジン
                dataRow[ENGINEMODELNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // 排気量
                dataRow[ENGINEDISPLACENM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ENGINEDISPLACENM_KEY].Value.ToString();
                // Ｅ区分
                dataRow[EDIVNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[EDIVNM_KEY].Value.ToString();
                // ミッション
                dataRow[TRANSMISSIONNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[TRANSMISSIONNM_KEY].Value.ToString();
                // 駆動方式
                dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[WHEELDRIVEMETHODNM_KEY].Value.ToString();
                // シフト
                dataRow[SHIFTNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[SHIFTNM_KEY].Value.ToString();

                // 追加諸元タイトル１
                string AddiCarSpecTitle1 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE1_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle1))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = AddiCarSpecTitle1;
                    // 追加諸元１
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC1_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル２
                string AddiCarSpecTitle2 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE2_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle2))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = AddiCarSpecTitle2;
                    // 追加諸元２
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC2_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル３
                string AddiCarSpecTitle3 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE3_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle3))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = AddiCarSpecTitle3;
                    // 追加諸元３
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC3_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル４
                string AddiCarSpecTitle4 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE4_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle4))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = AddiCarSpecTitle4;
                    // 追加諸元４
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC4_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル５
                string AddiCarSpecTitle5 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE5_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle5))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = AddiCarSpecTitle5;
                    // 追加諸元５
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC5_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル６
                string AddiCarSpecTitle6 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE6_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle6))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = AddiCarSpecTitle6;
                    // 追加諸元６
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC6_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = string.Empty;
                }
                //------UPD 2009/10/20------<<<<<

                this.carSpecTable.Rows.Add(dataRow);
                this.uGrid_CarSpec.Refresh();

            }
        }
        #endregion

        #region ■ 車輌部品情報選択変化時発生イベント ■
        /// <summary>
        /// 車輌部品情報選択変化時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 選択変化時に発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.09.10</br>
        /// <br>Update Note : SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer  : FSI厚川 宏</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void uGrid_CarPartsList_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            Type type = e.Type;

            // 行選択の場合
            if (type.Name.Equals("UltraGridRow"))
            {
                if (this.uGrid_CarPartsList.ActiveRow == null) return;
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_CarPartsList.ActiveRow;
                //// 得意先コード
                //this.tNedit_CustomerCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERCODE_TITLE]);
                //// 得意先略称
                //this.uLabel_CustomerName.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERSUBNAME_TITLE]);
                //------UPD 2009/10/20------>>>>>
                // 型式指定番号
                this.uLabel_ModelDesignationNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELDESIGNATIONNO_KEY].Value.ToString();
                // 類別番号
                this.uLabel_ModelKindNo.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[CATEGORYNO_KEY].Value.ToString();
                // エンジン型式
                this.uLabel_EngineModelNmData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // 型式
                this.uLabel_FullModelTitleInfoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[FULLMODEL_KEY].Value.ToString();
                // 車種（メーカーコード）
                this.uLabel_ModelMaker.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MAKERCODE_KEY].Value.ToString();
                // 車種（車種コード）
                this.uLabel_ModelCode.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELCODE_KEY].Value.ToString();
                // 車種（呼称コード）
                this.uLabel_ModelSubCode.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELSUBCODE_KEY].Value.ToString();
                // 車種名称
                this.uLabel_ModelName.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELFULLNAME_KEY].Value.ToString();
                // 年式
                string firstEntryYearMonth = this.uGrid_CarPartsList.Rows[row.Index].Cells[FIRSTENTRYDATE_KEY].Value.ToString().Replace("/", "");
                if (!string.IsNullOrEmpty(firstEntryYearMonth))
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(Int32.Parse(firstEntryYearMonth)*100+1);
                }
                else
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(0);
                }
                // (生産年式 開始-終了)
                this.uLabel_FirstEntryDateRange.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[STEDPRODUCETYPEOFYEAR_KEY].Value.ToString();
                // 車台番号
                this.uLabel_ProduceFrameNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[FRAMENO_KEY].Value.ToString();
                // 車台番号 開始-終了
                this.uLabel_ProduceFrameNoRange.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[STEDPRODUCEFRAMENO_KEY].Value.ToString();
                // カラー
                this.uLabel_ColorNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[COLORCODE_KEY].Value.ToString();
                // トリム
                this.uLabel_TrimNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[TRIMCODE_KEY].Value.ToString();

                //-------ADD 2009/10/10--------->>>>>
                // 管理番号
                this.uLabel_CarMngCodeData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MNGNO_KEY].Value.ToString();
                //-------ADD 2009/10/10---------<<<<<

                // --- ADD 2013/03/25 ---------->>>>>
                int divValue = 0;
                Int32.TryParse(this.uGrid_CarPartsList.Rows[row.Index].Cells[DOMESTICFOREIGNCODERF_KEY].Value.ToString(), out divValue);
                if (divValue == FOREIGNCODERF_DIV)
                {
                    this.uLabel_ProduceFrameNoRange.Visible = false;
                }
                else
                {
                    this.uLabel_ProduceFrameNoRange.Visible = true;
                }
                // --- ADD 2013/03/25 ----------<<<<<

                this.carSpecTable.Clear();

                DataRow dataRow;
                dataRow = this.carSpecTable.NewRow();
                // グレード
                dataRow[MODELGRADENM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELGRADENM_KEY].Value.ToString();
                // ボディ
                dataRow[BODYNAME_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[BODYNAME_KEY].Value.ToString();
                // ドア
                dataRow[DOORCOUNT_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[DOORCOUNT_KEY].Value.ToString();
                // エンジン
                dataRow[ENGINEMODELNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // 排気量
                dataRow[ENGINEDISPLACENM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ENGINEDISPLACENM_KEY].Value.ToString();
                // Ｅ区分
                dataRow[EDIVNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[EDIVNM_KEY].Value.ToString();
                // ミッション
                dataRow[TRANSMISSIONNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[TRANSMISSIONNM_KEY].Value.ToString();
                // 駆動方式
                dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[WHEELDRIVEMETHODNM_KEY].Value.ToString();
                // シフト
                dataRow[SHIFTNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[SHIFTNM_KEY].Value.ToString();

                // 追加諸元タイトル１
                string AddiCarSpecTitle1 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE1_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle1))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = AddiCarSpecTitle1;
                    // 追加諸元１
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC1_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル２
                string AddiCarSpecTitle2 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE2_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle2))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = AddiCarSpecTitle2;
                    // 追加諸元２
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC2_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル３
                string AddiCarSpecTitle3 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE3_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle3))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = AddiCarSpecTitle3;
                    // 追加諸元３
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC3_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル４
                string AddiCarSpecTitle4 = Convert.ToString(this.carPartsTable.Rows[row.Index][ADDICARSPECTITLE4_KEY]);
                if (!string.IsNullOrEmpty(AddiCarSpecTitle4))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = AddiCarSpecTitle4;
                    // 追加諸元４
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = Convert.ToString(this.carPartsTable.Rows[row.Index][ADDICARSPEC4_KEY]);
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル５
                string AddiCarSpecTitle5 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE5_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle5))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = AddiCarSpecTitle5;
                    // 追加諸元５
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC5_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = string.Empty;
                }

                // 追加諸元タイトル６
                string AddiCarSpecTitle6 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE6_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle6))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = AddiCarSpecTitle6;
                    // 追加諸元６
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC6_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = string.Empty;
                }
                //------UPD 2009/10/20------<<<<<
                this.carSpecTable.Rows.Add(dataRow);
                this.uGrid_CarSpec.Refresh();

            }
        }
        #endregion

        #region ■ 各コントロールからフォーカスが離れたときにイベント ■
        /// <summary>
        /// 各コントロールからフォーカスが離れたときにイベント(tArrowKeyControl)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            // PrevCtrl設定
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }

            // 名前により分岐
            switch (prevCtrl.Name)
            {
                //---------------------------------------------------------------
                // フィールド間移動
                //---------------------------------------------------------------
                #region 車輌検索グリッド
                // 車輌検索グリッド
                //case "uGrid_CarSearchList":
                //    {
                //        break;
                //    }
                #endregion

                #region 拠点コード
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        string inputValue = this.tEdit_SectionCodeAllowZero.Text;

                        string code;
                        string name;
                        bool status = ReadSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.uLabel_SectionNm.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    //-------DEL 2009/10/10------>>>>>
                                    //case Keys.Left:
                                    //case Keys.Up:
                                    //    {
                                    //        //e.NextCtrl = null;
                                    //    }
                                    //    break;
                                    //-------DEL 2009/10/10------<<<<<
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            //e.NextCtrl = null;// DEL 2009/10/10
                                            e.NextCtrl = this.tComboEditor_DisplayDiv; // ADD 2009/10/10
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.tEdit_SectionCodeAllowZero.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                #region 拠点ガイド
                // 拠点ガイド
                case "uButton_SectionGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region 得意先コード
                // 得意先コード
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code);

                        if (status == true)
                        {
                            tNedit_CustomerCode.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_CarMngCode;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "得意先が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードを戻す
                            tNedit_CustomerCode.SetInt(code);
                            tNedit_CustomerCode.SelectAll();

                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion // 得意先コード

                #region 得意先ガイド
                // 得意先ガイド
                case "uButton_CustomerGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_CarMngCode;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region 売上日（開始）
                // 売上日（開始）
                case "tDateEdit_SalesDateSt":
                    {
                        if (this.tDateEdit_SalesDateSt.GetLongDate() == 0)
                        {
                            this.tDateEdit_SalesDateSt.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_SalesDateEd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 売上日（開始）

                #region 売上日（終了）
                // 売上日（終了）
                case "tDateEdit_SalesDateEd":
                    {
                        if (this.tDateEdit_SalesDateEd.GetLongDate() == 0)
                        {
                            this.tDateEdit_SalesDateEd.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_AddUpADateSt;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 売上日（終了）

                #region 入力日（開始）
                // 入力日（開始）
                case "tDateEdit_AddUpADateSt":
                    {
                        if (this.tDateEdit_AddUpADateSt.GetLongDate() == 0)
                        {
                            this.tDateEdit_AddUpADateSt.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_AddUpADateEd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 入力日（開始）

                #region 入力日（終了）
                // 入力日（終了）
                case "tDateEdit_AddUpADateEd":
                    {
                        if (this.tDateEdit_AddUpADateEd.GetLongDate() == 0)
                        {
                            this.tDateEdit_AddUpADateEd.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_FullModel;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 入力日（終了）

                #region BLコード
                // BLコード
                case "tEdit_BlGoodsCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_BlGoodsCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadBlCodeName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            tEdit_BlGoodsCode.Text = _swBLGoodsName;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        e.NextCtrl = this.uButton_BlGoodsCode;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "ＢＬコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_BlGoodsCode.Text = code.ToString();
                            tEdit_BlGoodsCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                #endregion

                #region BLグループ
                // BLグループ
                case "tEdit_BlGroupCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_BlGroupCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadBlGroupName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            tEdit_BlGroupCode.Text = _swBLGroupName;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        e.NextCtrl = this.uButton_BlGroupCode;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "グループコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_BlGroupCode.Text = code.ToString();
                            tEdit_BlGroupCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                #endregion

                #region 倉庫
                // 倉庫
                case "tEdit_WarehouseCd":
                    {
                        string inputValue = tEdit_WarehouseCd.Text;

                        string code;
                        bool status = ReadWarehouseName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            tEdit_WarehouseCd.Text = _swWarehouseName;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_WarehouseCd.Text = code;
                            tEdit_WarehouseCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                #endregion

                #region 型式
                // 型式
                case "tEdit_FullModel":
                    {
                        string inputValue = tEdit_FullModel.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_FullModel.Text = searchText;
                        tComboEditor_FullModelFuzzy.Value = fuzzyValue;

                        // 退避
                        _srFullModel = inputValue;
                        _srRvFullModel = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // 型式あいまい条件
                case "tComboEditor_FullModelFuzzy":
                    {
                        // 退避
                        _srFullModel = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_FullModelFuzzy.Value, tEdit_FullModel.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion

                #region 品名
                // 品名
                case "tEdit_GoodsName":
                    {
                        string inputValue = tEdit_GoodsName.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_GoodsName.Text = searchText;
                        tComboEditor_GoodsNameFuzzy.Value = fuzzyValue;

                        // 退避
                        _srGoodsName = inputValue;
                        _srRvGoodsName = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // 品名あいまい条件
                case "tComboEditor_GoodsNameFuzzy":
                    {
                        // 退避
                        _srGoodsName = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNameFuzzy.Value, tEdit_GoodsName.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion

                #region 品番
                // 品番
                case "tEdit_GoodsNo":
                    {
                        string inputValue = tEdit_GoodsNo.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_GoodsNo.Text = searchText;
                        tComboEditor_GoodsNoFuzzy.Value = fuzzyValue;

                        // 退避
                        _srGoodsNo = inputValue;
                        _srRvGoodsNo = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // 品番あいまい条件
                case "tComboEditor_GoodsNoFuzzy":
                    {
                        // 退避
                        _srGoodsNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNoFuzzy.Value, tEdit_GoodsNo.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion
                #region 管理番号
                case "tEdit_CarMngCode":
                    {
                        string inputValue = this.tEdit_CarMngCode.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        this.tEdit_CarMngCode.Text = searchText;
                        this.tComboEditor_CarMngCode.Value = fuzzyValue;

                        // 退避
                        _srCarMngNo = inputValue;
                        _srRvCarMngNo = searchText;
                        break;
                    }
                case "tComboEditor_CarMngCode":
                    {
                        // 退避
                        _srCarMngNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_CarMngCode.Value, tEdit_CarMngCode.Text);
                        break;
                    }
                #endregion

                #region 車輌備考
                // 車輌備考
                case "tEdit_SlipNote":
                    {
                        string inputValue = tEdit_SlipNote.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_SlipNote.Text = searchText;
                        tComboEditor_SlipNoteFuzzy.Value = fuzzyValue;

                        // 退避
                        _srCarNote = inputValue;
                        _srRvCarNote = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // 車輌備考あいまい条件
                case "tComboEditor_SlipNoteFuzzy":
                    {
                        // 退避
                        _srCarNote = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_SlipNoteFuzzy.Value, tEdit_SlipNote.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion

                default: break;
            }
        }

        #region 拠点
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadSectionCodeAllowZeroName(out string code, out string name)
        {
            // 入力値を取得
            string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = uLabel_SectionNm.Text;

            if (_prevInputValue.SectionCode == sectionCode)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionCode;
                return true;
            }

            // 00:全社
            if (sectionCode == "00")
            {
                sectionCode = "00";
                _prevInputValue.SectionCode = sectionCode;
                code = sectionCode;
                name = "全社";
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    _prevInputValue.SectionCode = code;
                    return true;
                }
                else
                {
                    code = uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", _prevInputValue.SectionCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.SectionCode = code;
                return true;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/07 ADD

        #endregion

        #region 得意先
        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool ReadCustomerName(out int code)
        {
            int customerCode = this.tNedit_CustomerCode.GetInt();
            code = customerCode;

            if (_prevInputValue.CustomerCode == customerCode) return true;

            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();

                    _prevInputValue.CustomerCode = customerCode;

                    // --- UPD 2009/09/27 -------------->>>
                    // 拠点情報をUIに設定
                    tEdit_SectionCodeAllowZero.Text = customerInfo.MngSectionCode.Trim();
                    ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero);
                    this.tArrowKeyControl_ChangeFocus(this, changeFocusEventArgs);
                    // --- UPD 2009/09/27 --------------<<<

                    return true;
                }
                else
                {
                    code = _prevInputValue.CustomerCode;
                    return false;
                }
            }
            else
            {
                _prevInputValue.CustomerCode = customerCode;
                // 名称をクリア
                this.uLabel_CustomerName.Text = string.Empty;

                return true;
            }
        }

        #endregion // 得意先

        #region BLコード
        /// <summary>
        /// BLコード名称取得
        /// </summary>
        /// <param name="code">BLコード</param>
        private bool ReadBlCodeName(out int code)
        {
            // 入力値を取得
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_BlGoodsCode.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // 空でなければ処理開始
            if (inputValue != 0)
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swBLGoodsCode)
                    {
                        // コードから名称へ変換
                        BLGoodsCdUMnt blGoodsCd;
                        int status = _blGoodsCdAcs.Read(out blGoodsCd, this._enterpriseCode, inputValue);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._swBLGoodsCode = inputValue;
                            this._swBLGoodsName = blGoodsCd.BLGoodsFullName;
                            code = _swBLGoodsCode;
                            return true;
                        }
                        else
                        {
                            // 戻す
                            code = _swBLGoodsCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = _swBLGoodsCode;
                    return false;
                }
            }
            else
            {
                this._swBLGoodsCode = 0;
                this._swBLGoodsName = string.Empty;
                code = _swBLGoodsCode;
                return true;
            }
        }
        #endregion

        #region グループコード
        /// <summary>
        /// グループコード名称取得
        /// </summary>
        /// <param name="code">グループコード</param>
        private bool ReadBlGroupName(out int code)
        {
            // 入力値を取得
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_BlGroupCode.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // 空でなければ処理開始
            if (inputValue != 0)
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swBLGroupCode)
                    {
                        // コードから名称へ変換
                        BLGroupU blGroup;
                        int status = this._blGroupUAcs.Search(out blGroup, this._enterpriseCode, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._swBLGroupCode = inputValue;
                            this._swBLGroupName = blGroup.BLGroupName;
                            code = _swBLGroupCode;
                            return true;
                        }
                        else
                        {
                            // 戻す
                            code = _swBLGroupCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = _swBLGroupCode;
                    return false;
                }
            }
            else
            {
                this._swBLGroupCode = 0;
                this._swBLGroupName = string.Empty;
                code = _swBLGroupCode;
                return true;
            }
        }
        #endregion

        #region 倉庫名
        /// <summary>
        /// 倉庫名称取得
        /// </summary>
        /// <param name="code">倉庫コード</param>
        private bool ReadWarehouseName(out string code)
        {
            // 入力値を取得
            string inputValue = this.tEdit_WarehouseCd.Text.Trim();
            code = inputValue;

            // 空でなければ処理開始
            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swWarehouseCd)
                    {
                        // コードから名称へ変換
                        Warehouse warehouseInfo;
                        int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._swWarehouseCd = inputValue;
                            this._swWarehouseName = warehouseInfo.WarehouseName;
                            code = _swWarehouseCd;
                            return true;
                        }
                        else
                        {
                            // 戻す
                            code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _swWarehouseCd);
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _swWarehouseCd);
                    return false;
                }
            }
            else
            {
                this._swWarehouseCd = string.Empty;
                this._swWarehouseName = string.Empty;
                code = _swWarehouseCd;
                return true;
            }
        }
        #endregion

        #endregion

        #region ■ コードが保存されていれば置き換えイベント ■
        /// <summary>
        /// 管理番号Enterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 管理番号Enter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_CarMngCode_Enter(object sender, EventArgs e)
        {
            // 管理番号が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srCarMngNo))
            {
                this.tEdit_CarMngCode.Text = this._srCarMngNo;
            }
        }

        /// <summary>
        /// BLグループコードEnterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : BLグループコードEnter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_BlGroupCode_Enter(object sender, EventArgs e)
        {
            // BLグループコードが保存されていれば置き換え
            if (this._swBLGroupCode > 0)
            {
                this.tEdit_BlGroupCode.Text = this._swBLGroupCode.ToString();
            }
        }

        /// <summary>
        /// BLコード入力欄Enterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : BLグループコードEnter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_BlGoodsCode_Enter(object sender, EventArgs e)
        {
            // BLコードが保存されていれば置き換え
            if (this._swBLGoodsCode > 0)
            {
                this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString();
            }
        }

        /// <summary>
        /// 倉庫入力欄Enterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 倉庫Enter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_WarehouseCd_Enter(object sender, EventArgs e)
        {
            // 倉庫コードが保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._swWarehouseCd))
            {
                this.tEdit_WarehouseCd.Text = this._swWarehouseCd.Trim();
            }
        }

        /// <summary>
        /// 型式入力欄Enterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 型式Enter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_FullModel_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの型式が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srFullModel))
            {
                this.tEdit_FullModel.Text = this._srFullModel;
            }
        }

        /// <summary>
        /// 車輌備考入力欄Enterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 車輌備考Enter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_SlipNote_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの備考１が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srCarNote))
            {
                this.tEdit_SlipNote.Text = this._srCarNote;
            }
        }

        /// <summary>
        /// 品名入力欄Enterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 品名Enter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_GoodsName_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの品名が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srGoodsName))
            {
                this.tEdit_GoodsName.Text = this._srGoodsName;
            }
        }

        /// <summary>
        /// 品番入力欄Enterイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 品番Enter時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_GoodsNo_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの品番が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srGoodsNo))
            {
                this.tEdit_GoodsNo.Text = this._srGoodsNo;
            }
        }

        # region [あいまい検索用テキスト分解処理]
        /// <summary>
        /// あいまい検索用テキスト分解処理
        /// </summary>
        /// <param name="inputValue">入力データ</param>
        /// <param name="searchText">検索データ</param>
        /// <param name="fuzzyValue">あいまいデータ</param>
        /// <remarks>
        /// <br>Note        : あいまい検索用テキスト分解処理を行う。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void GetFuzzyInput(string inputValue, out string searchText, out int fuzzyValue)
        {
            if (!string.IsNullOrEmpty(inputValue))
            {
                fuzzyValue = 0;     // コンボボックスの値

                if (!inputValue.Contains("*"))
                {
                    // [*]なし（「と一致」）
                    fuzzyValue = CT_FUZZY_MATCHWITH;
                }
                else if (inputValue.StartsWith("*") && inputValue.EndsWith("*"))
                {
                    // [*]…[*]（「を含む」）
                    fuzzyValue = CT_FUZZY_INCLUDEWITH;
                }
                else if (inputValue.StartsWith("*"))
                {
                    // [*]…（「で終る」）
                    fuzzyValue = CT_FUZZY_ENDWITH;
                }
                else if (inputValue.EndsWith("*"))
                {
                    // …[*]（「で始る」）
                    fuzzyValue = CT_FUZZY_STARTWITH;
                }
                searchText = inputValue.Replace("*", ""); // [*]抜き文字列
            }
            else
            {
                // クリア
                searchText = string.Empty;
                fuzzyValue = 0;
            }
        }
        # endregion

        # region [あいまい検索用テキスト変換処理]
        /// <summary>
        /// あいまい検索用テキスト変換処理
        /// </summary>
        /// <param name="fuzzyValue">あいまいデータ</param>
        /// <param name="searchValue">検索データ</param>
        /// <remarks>
        /// <br>Note        : あいまい検索用テキスト分解処理を行う。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private string GetFuzzyInputOnChangeFuzzyValue(int fuzzyValue, string searchValue)
        {
            string fullValue = searchValue;

            switch (fuzzyValue)
            {
                // 完全一致
                case CT_FUZZY_MATCHWITH:
                default:
                    fullValue = searchValue;
                    break;
                // あいまい
                case CT_FUZZY_INCLUDEWITH:
                    fullValue = "*" + searchValue + "*";
                    break;
                // 後方一致
                case CT_FUZZY_ENDWITH:
                    fullValue = "*" + searchValue;
                    break;
                // 前方一致
                case CT_FUZZY_STARTWITH:
                    fullValue = searchValue + "*";
                    break;
            }

            return fullValue;
        }
        #endregion

        #endregion

        #region ■ ガイドボタンクリックイベント ■
        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;

            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.Trim();

                _prevInputValue.SectionCode = sectionInfo.SectionCode.Trim();
                // 次フォーカス
                this.tNedit_CustomerCode.Focus();
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            DialogResult result = customerSearchForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.tEdit_CarMngCode.Focus();
            }
        }

        #region 得意先選択ガイドボタンクリック時イベント

        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : 得意先選択ガイドボタンクリック時イベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            // ステータスによりエラーメッセージを出力
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "選択した得意先は既に削除されています。",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "得意先情報の取得に失敗しました。",
                    status, MessageBoxButtons.OK);
                return;
            }

            // 得意先情報をUIに設定
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();

            _prevInputValue.CustomerCode = customerInfo.CustomerCode;

            // --- UPD 2009/09/27 -------------->>>
            // 拠点情報をUIに設定
            tEdit_SectionCodeAllowZero.Text = customerInfo.MngSectionCode.Trim();
            ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero);
            this.tArrowKeyControl_ChangeFocus(this, changeFocusEventArgs);
            // --- UPD 2009/09/27 --------------<<<

        }

        #endregion

        /// <summary>
        /// 管理番号ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 管理番号ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void CarMngCode_Button_Click(object sender, EventArgs e)
        {
            CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
            CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
            paramInfo.EnterpriseCode = this._enterpriseCode;
            // 「新規登録」行表示なし
            paramInfo.IsDispNewRow = false;
            // 得意先入力有
            if (this.tNedit_CustomerCode.GetInt() != 0)
            {
                // 得意先表示無し
                paramInfo.IsDispCustomerInfo = false;
                // 得意先コード絞り込み有り
                paramInfo.IsCheckCustomerCode = true;
                // 得意先コード
                paramInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
            }
            // 得意先入力無
            else
            {
                // 得意先表示あり
                paramInfo.IsDispCustomerInfo = true;
                // 得意先コード絞り込み無し
                paramInfo.IsCheckCustomerCode = false;
            }

            // 管理番号絞り込み有り
            string carMngCodeStr = this.tEdit_CarMngCode.Text.Trim();
            if (string.IsNullOrEmpty(carMngCodeStr))
            {
                paramInfo.IsCheckCarMngCode = false;
            }
            else
            {
                paramInfo.IsCheckCarMngCode = true;
                paramInfo.CarMngCode = this.tEdit_CarMngCode.Text.Trim();
                paramInfo.CheckCarMngCodeType = this.tComboEditor_CarMngCode.SelectedIndex;
            }
            // 車輌管理区分チェック有り
            paramInfo.IsCheckCarMngDivCd = true;
            // ガイドイベントフラグ
            paramInfo.IsGuideClick = true;
            int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (selectedInfo.CarMngCode != "新規登録")
                {
                    // 得意先コード
                    if (this.tNedit_CustomerCode.GetInt() == 0 && selectedInfo.CustomerCode != 0)
                    {
                        this.tNedit_CustomerCode.Text = selectedInfo.CustomerCode.ToString("00000000");
                    }
                    // 管理番号
                    this.tEdit_CarMngCode.Text = selectedInfo.CarMngCode;
                    // 管理番号抽出条件
                    this.tComboEditor_CarMngCode.SelectedIndex = 0;
                    //-----------ADD 2009/11/04-------->>>>>
                    // 管理番号(車輌情報)
                    this.uLabel_CarMngCodeData.Text = selectedInfo.CarMngCode;
                    //-----------ADD 2009/11/04--------<<<<<
                    // 型式
                    this.tEdit_FullModel.Text = selectedInfo.SeriesModel + "-" + selectedInfo.CategorySignModel;
                    this._srFullModel = this.tEdit_FullModel.Text;
                    // 型式指定番号
                    if (selectedInfo.ModelDesignationNo == 0)
                    {
                        this.uLabel_ModelDesignationNoData.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelDesignationNoData.Text = selectedInfo.ModelDesignationNo.ToString("00000");
                    }
                    // 類別番号
                    if (selectedInfo.CategoryNo == 0)
                    {
                        this.uLabel_ModelKindNo.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelKindNo.Text = selectedInfo.CategoryNo.ToString("0000");
                    }
                    // エンジン型式
                    this.uLabel_EngineModelNmData.Text = selectedInfo.EngineModelNm;
                    // 車種（メーカーコード）
                    if (selectedInfo.MakerCode == 0)
                    {
                        this.uLabel_ModelMaker.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelMaker.Text = selectedInfo.MakerCode.ToString("000");
                    }
                    // 車種（車種コード）
                    if (selectedInfo.ModelCode == 0)
                    {
                        this.uLabel_ModelCode.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelCode.Text = selectedInfo.ModelCode.ToString("000");
                    }
                    // 車種（呼称コード）
                    if (selectedInfo.ModelSubCode == 0)
                    {
                        this.uLabel_ModelSubCode.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelSubCode.Text = selectedInfo.ModelSubCode.ToString("000");
                    }
                    // 車種名称
                    this.uLabel_ModelName.Text = selectedInfo.ModelFullName;
                    // 型式
                    this.uLabel_FullModelTitleInfoData.Text = selectedInfo.FullModel;
                    //this._srFullModel = selectedInfo.FullModel;

                    this.tComboEditor_FullModelFuzzy.SelectedIndex = 0;
                    // 年式
                    // if (selectedInfo.FirstEntryDate == DateTime.MinValue) // DEL 2009/10/10
                    if (selectedInfo.FirstEntryDate == 0) // ADD 2009/10/10
                    {
                        tDateEdit_FirstEntryDate.Clear();
                    }
                    else
                    {
                        // string firstEntryStr = selectedInfo.FirstEntryDate.ToString("yyyyMMdd");// DEL 2009/11/04
                        // tDateEdit_FirstEntryDate.SetLongDate(Int32.Parse(firstEntryStr) * 100 + 1);// DEL 2009/11/04
                        tDateEdit_FirstEntryDate.SetLongDate((selectedInfo.FirstEntryDate) * 100 + 1);// ADD 2009/11/04
                    }
                    // (生産年式 開始-終了)
                    if (selectedInfo.StProduceTypeOfYear == DateTime.MinValue && selectedInfo.EdProduceTypeOfYear == DateTime.MinValue)
                    {
                        this.uLabel_FirstEntryDateRange.Text = string.Empty;
                    }
                    else
                    {
                        // 0:西暦
                        if (this._allDefSet.EraNameDispCd1 == 0)
                        {
                            if (selectedInfo.StProduceTypeOfYear == DateTime.MinValue)
                            {
                                this.uLabel_FirstEntryDateRange.Text = "-" + selectedInfo.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                            else if (selectedInfo.EdProduceTypeOfYear == DateTime.MinValue)
                            {
                                this.uLabel_FirstEntryDateRange.Text = selectedInfo.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-";
                            }
                            else
                            {
                                this.uLabel_FirstEntryDateRange.Text = selectedInfo.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-" + selectedInfo.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                        }
                        // 1:和歴
                        else
                        {
                            string stProduceTypeOfYear = this.GetProduceTypeOfYear(selectedInfo.StProduceTypeOfYear);
                            string edProduceTypeOfYear = this.GetProduceTypeOfYear(selectedInfo.EdProduceTypeOfYear);
                            this.uLabel_FirstEntryDateRange.Text = this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);
                        }
                    }
                    // 車台番号
                    this.uLabel_ProduceFrameNoData.Text = selectedInfo.FrameNo;
                    // (車台番号 開始-終了)
                    if (selectedInfo.StProduceFrameNo == 0 && selectedInfo.EdProduceFrameNo == 0)
                    {
                        this.uLabel_ProduceFrameNoRange.Text = string.Empty;
                    }
                    else
                    {
                        if (selectedInfo.StProduceFrameNo == 0)
                        {
                            this.uLabel_ProduceFrameNoRange.Text = "".PadLeft(8, ' ') + "-" + Convert.ToString(selectedInfo.EdProduceFrameNo);
                        }
                        else if (selectedInfo.EdProduceFrameNo == 0)
                        {
                            this.uLabel_ProduceFrameNoRange.Text = Convert.ToString(selectedInfo.StProduceFrameNo) + "-" + "".PadLeft(8, ' ');
                        }
                        else
                        {
                            this.uLabel_ProduceFrameNoRange.Text = Convert.ToString(selectedInfo.StProduceFrameNo).PadLeft(8, ' ') + "-" + Convert.ToString(selectedInfo.EdProduceFrameNo).PadLeft(8, ' ');
                        }
                    }
                    // カラー
                    this.uLabel_ColorNoData.Text = selectedInfo.ColorCode;
                    // トリム
                    this.uLabel_TrimNoData.Text = selectedInfo.TrimCode;

                    this.carSpecTable.Clear();

                    DataRow dataRow;
                    dataRow = this.carSpecTable.NewRow();
                    // グレード
                    dataRow[MODELGRADENM_INFO_TITLE] = selectedInfo.ModelGradeNm;
                    // ボディ
                    dataRow[BODYNAME_INFO_TITLE] = selectedInfo.BodyName;
                    // ドア
                    dataRow[DOORCOUNT_INFO_TITLE] = selectedInfo.DoorCount;
                    // エンジン
                    dataRow[ENGINEMODELNM_INFO_TITLE] = selectedInfo.EngineModelNm;
                    // 排気量
                    dataRow[ENGINEDISPLACENM_INFO_TITLE] = selectedInfo.EngineDisplaceNm;
                    // Ｅ区分
                    dataRow[EDIVNM_INFO_TITLE] = selectedInfo.EDivNm;
                    // ミッション
                    dataRow[TRANSMISSIONNM_INFO_TITLE] = selectedInfo.TransmissionNm;
                    // 駆動方式
                    dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = selectedInfo.WheelDriveMethodNm;
                    // シフト
                    dataRow[SHIFTNM_INFO_TITLE] = selectedInfo.ShiftNm;

                    // 追加諸元タイトル１
                    string AddiCarSpecTitle1 = selectedInfo.AddiCarSpecTitle1;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle1))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = AddiCarSpecTitle1;
                        // 追加諸元１
                        dataRow[ADDICARSPECTITLE1_INFO_TITLE] = selectedInfo.AddiCarSpec1;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE1_INFO_TITLE] = string.Empty;
                    }

                    // 追加諸元タイトル２
                    string AddiCarSpecTitle2 = selectedInfo.AddiCarSpecTitle2;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle2))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = AddiCarSpecTitle2;
                        // 追加諸元２
                        dataRow[ADDICARSPECTITLE2_INFO_TITLE] = selectedInfo.AddiCarSpec2;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE2_INFO_TITLE] = string.Empty;
                    }

                    // 追加諸元タイトル３
                    string AddiCarSpecTitle3 = selectedInfo.AddiCarSpecTitle3;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle3))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = AddiCarSpecTitle3;
                        // 追加諸元３
                        dataRow[ADDICARSPECTITLE3_INFO_TITLE] = selectedInfo.AddiCarSpec3;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE3_INFO_TITLE] = string.Empty;
                    }

                    // 追加諸元タイトル４
                    string AddiCarSpecTitle4 = selectedInfo.AddiCarSpecTitle4;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle4))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = AddiCarSpecTitle4;
                        // 追加諸元４
                        dataRow[ADDICARSPECTITLE4_INFO_TITLE] = selectedInfo.AddiCarSpec4;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE4_INFO_TITLE] = string.Empty;
                    }

                    // 追加諸元タイトル５
                    string AddiCarSpecTitle5 = selectedInfo.AddiCarSpecTitle5;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle5))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = AddiCarSpecTitle5;
                        // 追加諸元５
                        dataRow[ADDICARSPECTITLE5_INFO_TITLE] = selectedInfo.AddiCarSpec5;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE5_INFO_TITLE] = string.Empty;
                    }

                    // 追加諸元タイトル６
                    string AddiCarSpecTitle6 = selectedInfo.AddiCarSpecTitle6;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle6))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = AddiCarSpecTitle6;
                        // 追加諸元６
                        dataRow[ADDICARSPECTITLE6_INFO_TITLE] = selectedInfo.AddiCarSpec6;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE6_INFO_TITLE] = string.Empty;
                    }

                    this.carSpecTable.Rows.Add(dataRow);
                    this.uGrid_CarSpec.Refresh();

                    _customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

                    // --- UPD 2009/09/27 -------------->>>
                    // 得意先情報をUIに設定
                    _prevInputValue.CustomerCode = 0;
                    ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tNedit_CustomerCode, this.tNedit_CustomerCode);
                    this.tArrowKeyControl_ChangeFocus(this, changeFocusEventArgs);
                    // --- UPD 2009/09/27 --------------<<<
                }
            }
        }

        /// <summary>
        /// 車輌備考ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 車輌備考ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_SlipNote_Click(object sender, EventArgs e)
        {
            NoteGuidBd noteGuidBd;
            int status = _noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, SLIPNOTE_DIV);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SlipNote.Text = noteGuidBd.NoteGuideName;
                this.tEdit_BlGroupCode.Focus();
            }
        }

        /// <summary>
        /// BLｸﾞﾙｰﾌﾟガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : BLｸﾞﾙｰﾌﾟガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_BlGroupCode_Click(object sender, EventArgs e)
        {
            // ガイド表示
            BLGroupU blGroupUInfo;
            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_BlGroupCode.Text = blGroupUInfo.BLGroupName;
                this._swBLGroupCode = blGroupUInfo.BLGroupCode;
                this._swBLGroupName = blGroupUInfo.BLGroupName;

                this.tEdit_BlGoodsCode.Focus();
            }
        }

        /// <summary>
        /// BLコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : BLコードガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_BlGoodsCode_Click(object sender, EventArgs e)
        {
            // コードから名称へ変換
            BLGoodsCdUMnt blGoodsUnit;
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_BlGoodsCode.Text = blGoodsUnit.BLGoodsFullName;
                this._swBLGoodsCode = blGoodsUnit.BLGoodsCode;
                this._swBLGoodsName = blGoodsUnit.BLGoodsFullName;

                this.tEdit_GoodsName.Focus();
            }
        }

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_WarehouseCd_Click(object sender, EventArgs e)
        {
            // 拠点コードを取得
            string sectioncode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            int status = 0;

            // コードから名称へ変換
            Warehouse warehouseInfo;

            // 拠点コードが入力されていれば拠点内、なければ全拠点表示
            if (!String.IsNullOrEmpty(sectioncode))
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode, sectioncode);
            }
            else
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode);
            }

            // 戻り値が正常であれば
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UI上には名前をセット、コードはメモリ内に格納
                this.tEdit_WarehouseCd.Text = warehouseInfo.WarehouseName;
                this._swWarehouseCd = warehouseInfo.WarehouseCode;
                this._swWarehouseName = warehouseInfo.WarehouseName;
            }
        }
        #endregion

        # region ■ その他イベント ■
        /// <summary>
        /// フォントサイズコンボボックスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tComboEditor_DisplayDiv_ValueChanged(object sender, EventArgs e)
        {
            // 表示区分＝車輌検索
            if (this.tComboEditor_DisplayDiv.SelectedIndex == 0)
            {
                // 抽出条件の「売上日」「入力日」を入力不可に変更する。
                this.tDateEdit_SalesDateSt.Enabled = false;
                this.tDateEdit_SalesDateEd.Enabled = false;
                this.tDateEdit_AddUpADateSt.Enabled = false;
                this.tDateEdit_AddUpADateEd.Enabled = false;
                // 拠点コード
                this.tEdit_SectionCodeAllowZero.Enabled = false;
                this.uButton_SectionGuide.Enabled = false;

                this.uGroupBox_CarInfo.Expanded = true;
                // 抽出条件枠を最小化
                this.uGroupBox_ExtractCondition.Expanded = false;
                this.tEdit_BlGroupCode.Enabled = false;
                this.uButton_BlGroupCode.Enabled = false;
                this.tEdit_BlGoodsCode.Enabled = false;
                this.uButton_BlGoodsCode.Enabled = false;
                this.tEdit_GoodsName.Enabled = false;
                this.tComboEditor_GoodsNameFuzzy.Enabled = false;
                this.tEdit_GoodsNo.Enabled = false;
                this.tComboEditor_GoodsNoFuzzy.Enabled = false;
                this.tComboEditor_SalesOrderDivCd.Enabled = false;
                this.tEdit_WarehouseCd.Enabled = false;
                this.uButton_WarehouseCd.Enabled = false;


                this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.White;

                //------ADD 2009/10/10-------->>>>>
                this.uLabel_CarMngCodeTitle.Visible = true;
                this.uLabel_CarMngCodeData.Visible = true;
                this.uLabel_CarMngCodeData.Text = string.Empty;
                //------ADD 2009/10/10--------<<<<<
            }
            // 表示区分が「出荷部品」の時
            else if (this.tComboEditor_DisplayDiv.SelectedIndex == 1)
            {
                // 抽出条件の「売上日」「入力日」を入力不可に変更する。
                this.tDateEdit_SalesDateSt.Enabled = true;
                this.tDateEdit_SalesDateEd.Enabled = true;
                this.tDateEdit_AddUpADateSt.Enabled = true;
                this.tDateEdit_AddUpADateEd.Enabled = true;
                // 拠点コード
                this.tEdit_SectionCodeAllowZero.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;

                // 抽出条件枠を最大化
                this.uGroupBox_ExtractCondition.Expanded = true;
                this.uGroupBox_CarInfo.Expanded = true;
                this.tEdit_BlGroupCode.Enabled = true;
                this.uButton_BlGroupCode.Enabled = true;
                this.tEdit_BlGoodsCode.Enabled = true;
                this.uButton_BlGoodsCode.Enabled = true;
                this.tEdit_GoodsName.Enabled = true;
                this.tComboEditor_GoodsNameFuzzy.Enabled = true;
                this.tEdit_GoodsNo.Enabled = true;
                this.tComboEditor_GoodsNoFuzzy.Enabled = true;
                this.tComboEditor_SalesOrderDivCd.Enabled = true;
                this.tEdit_WarehouseCd.Enabled = true;
                this.uButton_WarehouseCd.Enabled = true;


                this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.White;

                //------ADD 2009/10/10-------->>>>>
                this.uLabel_CarMngCodeTitle.Visible = true;
                this.uLabel_CarMngCodeData.Visible = true;
                this.uLabel_CarMngCodeData.Text = string.Empty;
                //------ADD 2009/10/10--------<<<<<

            }
            else
            {
                // 抽出条件の「売上日」「入力日」を入力不可に変更する。
                this.tDateEdit_SalesDateSt.Enabled = true;
                this.tDateEdit_SalesDateEd.Enabled = true;
                this.tDateEdit_AddUpADateSt.Enabled = true;
                this.tDateEdit_AddUpADateEd.Enabled = true;
                // 拠点コード
                this.tEdit_SectionCodeAllowZero.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;

                // 抽出条件枠を最大化
                this.uGroupBox_ExtractCondition.Expanded = true;
                this.uGroupBox_CarInfo.Expanded = false;
                this.tEdit_BlGroupCode.Enabled = true;
                this.uButton_BlGroupCode.Enabled = true;
                this.tEdit_BlGoodsCode.Enabled = true;
                this.uButton_BlGoodsCode.Enabled = true;
                this.tEdit_GoodsName.Enabled = true;
                this.tComboEditor_GoodsNameFuzzy.Enabled = true;
                this.tEdit_GoodsNo.Enabled = true;
                this.tComboEditor_GoodsNoFuzzy.Enabled = true;
                this.tComboEditor_SalesOrderDivCd.Enabled = true;
                this.tEdit_WarehouseCd.Enabled = true;
                this.uButton_WarehouseCd.Enabled = true;

                //------ADD 2009/10/10-------->>>>>
                this.uLabel_CarMngCodeTitle.Visible = false;
                this.uLabel_CarMngCodeData.Visible = false;
                //------ADD 2009/10/10--------<<<<<

                this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region 終了
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                #endregion

                #region テキスト出力
                case "ButtonTool_TextOut":
                    {
                        TextOutput();
                        break;
                    }
                #endregion

                #region クリア
                case "ButtonTool_Clear":
                    {
                        this.Clear();
                        break;
                    }
                #endregion

                #region 検索
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        bool inputCheck = false;

                        if (this.tComboEditor_DisplayDiv.SelectedIndex == 0)
                        {
                            this.SearchProcess();
                        }
                        else
                        {
                            inputCheck = this.ExecutBeforeCheck();

                            if (inputCheck)
                            {
                                this.SearchPartsProcess();
                            }
                        }
                    }
                    break;
                #endregion

                default: break;
            }
        }

        /// <summary>
        /// 列幅自動調整イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : 列幅自動調整時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            // 車輌検索
            if (this.uGrid_CarSearchList.Enabled == true)
            {
                autoColumnAdjust(this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked, 0);
            }
            // 出荷部品
            if (this.uGrid_CarPartsList.Enabled == true)
            {
                autoColumnAdjust(this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked, 1);
            }
            // 出荷部品（合計）
            if (this.uGrid_CarPartsTotalList.Enabled == true)
            {
                autoColumnAdjust(this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked, 2);
            }
        }

        /// <summary>
        /// フォントサイズ変更
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : フォントサイズ変更時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            if (this.uGrid_CarSearchList.Enabled == true)
            {
                this.uGrid_CarSearchList.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
                this.uGrid_CarSearchList.Refresh();
            }
            else if (this.uGrid_CarPartsList.Enabled == true)
            {
                this.uGrid_CarPartsList.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
                this.uGrid_CarPartsList.Refresh();
            }
            else if (this.uGrid_CarPartsTotalList.Enabled == true)
            {
                this.uGrid_CarPartsTotalList.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
                this.uGrid_CarPartsTotalList.Refresh();
            }

            uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(null, null);
        }

        /// <summary>
        /// オブジェクト変更
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="defaultNo">数字</param>
        /// <remarks>
        /// <br>Note        : フォントサイズ変更時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }

        /// <summary>
        /// マウスのダブルクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : マウスのダブルクリック時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void uGrid_CarSearchList_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_CarSearchList.ActiveRow;
            if (row == null) return;

            this.tComboEditor_DisplayDiv.SelectedIndex = 1;
            this.tComboEditor_CarMngCode.SelectedIndex = 0;
            this.tComboEditor_FullModelFuzzy.SelectedIndex = 0;
            this.tComboEditor_SlipNoteFuzzy.SelectedIndex = 0;
            this.tNedit_CustomerCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERCODE_KEY]);
            int code;
            
            // 得意先マスタ読込処理
            if (this._customerSearchRetDic.Count == 0)
            {
                this.LoadCustomerSearchRet();
            }
            if (!_customerSearchRetDic.ContainsKey(this.tNedit_CustomerCode.GetInt()))
            {
                // エラー時
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "得意先が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                // コードを戻す
                this.tNedit_CustomerCode.Focus();
                this.tNedit_CustomerCode.SelectAll();
            }
            else
            {
                this.ReadCustomerName(out code);
                this.tNedit_CustomerCode.Text = code.ToString("d8");
            }

            this.tEdit_CarMngCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][MNGNO_KEY]);
            this.tEdit_FullModel.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][KINDMODEL_KEY]);
            // this.tEdit_SlipNote.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CARNOTE_KEY]); // DEL 2009/10/20
            this._carMngNoTemp = Int32.Parse(this.carSearchTable.Rows[row.Index][MNGNOTEMP_KEY].ToString());
        }

        /// <summary>
        /// スペースキーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : スペースキー時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void uGrid_CarSearchList_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            if ((uGrid.Rows.Count != 0) && (uGrid.ActiveRow != null))
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            DoubleClickRowEventArgs e2 = new DoubleClickRowEventArgs(uGrid.ActiveRow, new RowArea());
                            this.uGrid_CarSearchList_DoubleClickRow(sender, e2);
                            break;
                        }
                    //----------ADD 2009/10/10------->>>>>
                    case Keys.Left:
                        {
                            // ←矢印キー
                            if (e.KeyCode == Keys.Left)
                            {
                                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                                e.Handled = true;
                                if (this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position == 0)
                                {
                                    // なし
                                }
                                else
                                {
                                    // グリッド表示を左にスクロール
                                    this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position - 40;
                                }
                            }
                            break;
                        }
                    case Keys.Right:
                        {
                            // →矢印キー
                            if (e.KeyCode == Keys.Right)
                            {
                                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                                e.Handled = true;
                                // グリッド表示を右にスクロール
                                this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position + 40;
                            }
                            break;
                            //----------ADD 2009/10/10-------<<<<<
                        }
                }
                return;
            }

        }

        /// <summary>
        /// スペースキーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : スペースキー時に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.10</br>
        /// </remarks>
        private void uGrid_CarPartsTotalList_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_CarPartsTotalList.ActiveRow == null) return;
            // 最上行での↑キー
            if (this.uGrid_CarPartsTotalList.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                    e.Handled = true;
                }
            }
            // →矢印キー
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            // ←矢印キー
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                if (this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                }
                else
                {
                    // グリッド表示を左にスクロール
                    this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

        }

        /// <summary>
        /// スペースキーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : スペースキー時に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2009.10.10</br>
        /// </remarks>
        private void uGrid_CarPartsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_CarPartsList.ActiveRow == null) return;
            // 最上行での↑キー
            if (this.uGrid_CarPartsList.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                    e.Handled = true;
                }
            }
            // →矢印キー
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            // ←矢印キー
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                if (this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                }
                else
                {
                    // グリッド表示を左にスクロール
                    this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }
        }

        /// <summary>
        /// double⇒string変更
        /// </summary>
        /// <param name="numberValue">数字</param>
        /// <remarks>
        /// <br>Note        : double⇒string変更時に発生します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private string douToStrChange(double numberValue)
        {
            return numberValue.ToString("N");
        }

        //-----------DEL 2009/10/10---------->>>>>
        ///// <summary>
        ///// long⇒string変更
        ///// </summary>
        ///// <param name="numberValue">数字</param>
        ///// <remarks>
        ///// <br>Note        : long⇒string変更時に発生します。</br>
        ///// <br>Programmer  : 譚洪</br>
        ///// <br>Date        : 2009.09.10</br>
        ///// </remarks>
        //private string longToStrChange(long numberValue)
        //{
        //    return numberValue.ToString("N");
        //}
        ///// <summary>
        ///// int⇒string変更
        ///// </summary>
        ///// <param name="numberValue">数字</param>
        ///// <remarks>
        ///// <br>Note        : int⇒string変更時に発生します。</br>
        ///// <br>Programmer  : 譚洪</br>
        ///// <br>Date        : 2009.09.10</br>
        ///// </remarks>
        //private string intToStrChange(int numberValue)
        //{
        //    return numberValue.ToString("N");
        //}
        //-----------DEL 2009/10/10----------<<<<<

        #endregion

        # region ■ ﾃｷｽﾄ出力処理 ■
        /// <summary>
        /// 画面ﾃｷｽﾄ出力処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ﾃｷｽﾄ出力をクリック時に発生します。</br>      
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private int TextOutput()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // テキスト出力用ダイアログに必要な情報をセットする
            SFCMN06002C printInfo;
            status = this.GetPrintInfo(out printInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }

            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            customTextProviderInfo.OutPutFileName = printInfo.outPutFilePathName;
            // 上書き／追加フラグをセット(true:追加する、false:上書きする)
            customTextProviderInfo.AppendMode = printInfo.overWriteFlag;
            // スキーマ取得
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);

            DataTable outDataTable = new DataTable();

            if (this.uGrid_CarSearchList.Visible == true)
            {
                outDataTable = this.carSearchTable.DefaultView.ToTable();
            }
            else if (this.uGrid_CarPartsList.Visible == true)
            {
                outDataTable = this.carPartsTable.DefaultView.ToTable();
            }
            else if (this.uGrid_CarPartsTotalList.Visible == true)
            {
                outDataTable = this.carPartsTotalTable;
            }


            // CSV出力
            status = customTextWriter.WriteText(outDataTable, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);

            string resultMessage = "";

            switch (status)
            {
                case 0:    // 処理成功
                    resultMessage = "CSV出力が完了しました。";
                    break;
                case -9:    // 出力対象外のデータが指定された
                    resultMessage = "出力対象外のデータが指定されました。";
                    break;
                default:    // その他エラー
                    resultMessage = "その他のエラーが発生しました。ステータス(" + status.ToString() + ")";
                    break;
            }

            if (!string.IsNullOrEmpty(resultMessage))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    resultMessage,
                    status, MessageBoxButtons.OK);
            }

            return status;
        }
        #endregion

        #region ■ 出力情報取得処理 ■
        /// <summary>
        /// 出力情報取得処理
        /// </summary>
        /// <param name="printInfo">出力情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 出力情報を取得します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private int GetPrintInfo(out SFCMN06002C printInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 印刷情報パラメータ
            printInfo = new SFCMN06002C();
            // 帳票選択ガイド
            SFCMN00391U printDialog = new SFCMN00391U();

            printInfo.enterpriseCode = _enterpriseCode;
            // 起動ＰＧＩＤ
            printInfo.kidopgid = CT_PGID;
            printInfo.selectInfoCode = 1;
            if (this.uGrid_CarSearchList.Visible == true)
            {
                printInfo.PrintPaperSetCd = 0;
            }
            else if (this.uGrid_CarPartsList.Visible == true)
            {
                printInfo.PrintPaperSetCd = 1;
            }
            else if (this.uGrid_CarPartsTotalList.Visible == true)
            {
                printInfo.PrintPaperSetCd = 2;
            }

            // 帳票選択ガイド
            printDialog.PrintMode = 1;
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    if (File.Exists(printInfo.outPutFilePathName) == false)
                    {
                        // ファイルなし
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        // ファイルが存在する場合は、オープンチェック
                        try
                        {
                            // 仮に名称を変更
                            string tempFileName = printInfo.outPutFilePathName
                                                + DateTime.Now.Ticks.ToString();
                            FileInfo fi = new FileInfo(printInfo.outPutFilePathName);
                            fi.MoveTo(tempFileName);
                            // 名称の変更が正しく行えたので、名称を元に戻す
                            fi.MoveTo(printInfo.outPutFilePathName);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        catch (Exception)
                        {
                            // 名称変更失敗 -> 他のアプリケーションが排他で使用中
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "指定されたファイルは使用できません。\r\n"
                                        + "Excel等が使用していないか確認して、\r\n"
                                        + "使用しているときはファイルを閉じて下さい。",
                                        0, MessageBoxButtons.OK);

                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    break;
                default:
                    // 例外が発生
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    break;
            }

            return status;
        }
        #endregion

        #region ■ 全体初期値取得処理 ■
        /// <summary>
        /// 全体初期値取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 全体初期値を取得します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode)
        {
            // 全体初期値設定マスタ
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
            ArrayList retAllDefSetList;
            int status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
            }
            else
            {
                this._allDefSet = null;
            }
            return status;
        }

        /// <summary>
        /// 全体初期値取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 全体初期値を取得します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;
        }
        #endregion

        /// <summary>
        /// 生産年式取得処理(和歴／西暦)
        /// </summary>
        /// <param name="produceTypeOfYear">生産年式</param>
        /// <remarks>
        /// <br>Note       : 生産年式取得処理(和歴／西暦)です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>UpdateNote   2019/01/08  譚洪</br>
        /// <br>修正内容     新元号の対応</br>
        /// </remarks>
        private string GetProduceTypeOfYear(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            if (produceTypeOfYear != DateTime.MinValue)
            {
                if (this._allDefSet.EraNameDispCd1 == 0)
                {
                    // 0:西暦
                    int iyy = produceTypeOfYear.Year;
                    int imm = produceTypeOfYear.Month;
                    retYear = (produceTypeOfYear != DateTime.MinValue) ? string.Format(@"{0:0000}{1:\.00}", iyy, imm) : string.Empty;
                }
                else
                {
                    // 1:和歴
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                    //System.Globalization.DateTimeFormatInfo FormatInfo = null;
                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
                    //System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
                    //culture.DateTimeFormat.Calendar = calendar;
                    //FormatInfo = culture.DateTimeFormat;
                    //FormatInfo.Calendar = calendar;

                    //retYear = produceTypeOfYear.ToString("gyy/MM/dd", culture);

                    //int Era = FormatInfo.Calendar.GetEra(produceTypeOfYear);
                    //string eraString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    //string eraName = string.Empty;
                    //string tempRetYear = string.Empty;
                    //tempRetYear = retYear.Substring(2, retYear.Length - 2);
                    //for (int eraCounter = 0; eraCounter < eraString.Length; eraCounter++)
                    //{
                    //    if (FormatInfo.GetEra(eraString[eraCounter].ToString()) == Era)
                    //    {
                    //        eraName = eraString[eraCounter].ToString();
                    //        break;
                    //    }
                    //}
                    //tempRetYear = eraName + tempRetYear;
                    //retYear = tempRetYear.Remove(tempRetYear.Length - 3);
                    //retYear = retYear.Replace('/', '.');

                    retYear = TDateTime.DateTimeToString("ggYY.MM", produceTypeOfYear);
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                }
            }
            return retYear;
        }

        /// <summary>
        /// 生産年式範囲設定処理
        /// </summary>
        /// <param name="stProduceTypeOfYear"></param>
        /// <param name="edProduceTypeOfYear"></param>
        /// <returns>retString</returns>
        /// <remarks>
        /// <br>Note       : 生産年式範囲設定処理です。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string SettingProduceTypeOfYearRange(string stProduceTypeOfYear, string edProduceTypeOfYear)
        {
            string retString = string.Empty;
            int maxLength = 7;

            stProduceTypeOfYear = stProduceTypeOfYear.PadRight(maxLength, ' ');
            edProduceTypeOfYear = edProduceTypeOfYear.PadRight(maxLength, ' ');
            if ((string.IsNullOrEmpty(stProduceTypeOfYear.Trim())) && (string.IsNullOrEmpty(edProduceTypeOfYear.Trim())))
            {
                retString = string.Empty;
            }
            else
            {
                retString = stProduceTypeOfYear + "-" + edProduceTypeOfYear;
            }

            return retString;
        }

    }
}
