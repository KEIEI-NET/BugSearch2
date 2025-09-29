//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入出庫照会
// プログラム概要   : 在庫入出庫照会メインフレームです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 19077 渡邉 貴裕
// 作 成 日  2007/05/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 修 正 日  2007/11/30  修正内容 : DC.NS用に変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/07/17  修正内容 : PM.NS用に変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/09/29  修正内容 : 仕様変更対応。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/11/17  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/11/28  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/12/01  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/09  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/15  修正内容 : ・拠点00を入力すると倉庫コードが消えるバグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/19  修正内容 : ・ガイドから拠点00を入力すると倉庫コードが消えるバグ修正(2008/12/15分の修正漏れ)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/09  修正内容 : ・拠点00時はstring.emptyではなくnullを渡すように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/14  修正内容 : ・バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/20  修正内容 : 不具合対応[10121]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/28  修正内容 : 不具合対応[10619]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/02  修正内容 : 不具合対応[10773]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/03/12  修正内容 : 不具合対応[12297]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/16  修正内容 : 不具合対応[10778]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/26  修正内容 : 不具合対応[13625]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李侠
// 修 正 日  2009/12/04  修正内容 : PM.NS-4・保守依頼③の対応
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 李占川
// 修 正 日  2010/11/15  修正内容 : PM1014の対応
//----------------------------------------------------------------------------//
// 管理番号  11070263-00 作成担当 : 時シン
// 作 成 日  2015/03/27  修正内容 : Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応
//----------------------------------------------------------------------------//
// 管理番号  11070263-00 作成担当 : zhangll
// 作 成 日  2015/04/07  修正内容 : Redmine#44209 の#479　削除チェックONから削除チェックOFFへ変更の場合、画面エラーの対応
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Threading;
using System.Xml;
using System.IO;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 履歴検索メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note		: 履歴検索メインフレームです。</br>
	/// <br>Programmer	: 19077 渡邉 貴裕</br>
	/// <br>Date		: 2007.05.18</br>
    /// <br></br>
    /// <br>UpdateNote : 2007.11.30 鈴木 正臣</br>
    /// <br>　　　　　　　DC.NS用に変更。</br>
    /// <br>           : 2008/07/17 照田 貴志</br>
    /// <br>　　　　　　　PM.NS用に変更。</br>
    /// <br>           : 2008/09/29 照田 貴志</br>
    /// <br>　　　　　　　仕様変更対応。</br>
    /// <br>           : 2008/11/17 照田 貴志</br>
    /// <br>              バグ修正、仕様変更対応</br>
    /// <br>           : 2008/11/28 照田 貴志</br>
    /// <br>              バグ修正、仕様変更対応</br>
    /// <br>           : 2008/12/01 行澤 仁美</br>
    /// <br>              バグ修正、仕様変更対応</br>
    /// <br>           : 2008/12/09 照田 貴志</br>
    /// <br>              バグ修正、仕様変更対応</br>
    /// <br>           : 2008/12/15 照田 貴志</br>
    /// <br>              ・拠点00を入力すると倉庫コードが消えるバグ修正</br>
    /// <br>           : 2008/12/19 照田 貴志</br>
    /// <br>              ・ガイドから拠点00を入力すると倉庫コードが消えるバグ修正(2008/12/15分の修正漏れ)</br>
    /// <br>           : 2009/01/09 照田 貴志</br>
    /// <br>              ・拠点00時はstring.emptyではなくnullを渡すように修正</br>
    /// <br>           : 2009/01/14 照田 貴志</br>
    /// <br>              ・バグ修正、仕様変更対応</br>
    /// <br>           : 2009/01/20 照田 貴志　不具合対応[10121]</br>
    /// <br>           : 2009/01/28 照田 貴志　不具合対応[10619]</br>
    /// <br>           : 2009/02/02 照田 貴志　不具合対応[10773]</br>
    /// <br>           : 2009/03/12 忍 幸史　不具合対応[12297]</br>
    /// <br>           : 2009/03/16 上野 俊治　不具合対応[10778]</br>
    /// <br>           : 2009/06/26 照田 貴志　不具合対応[13625]</br>
    /// <br>　　　　　 : 2009/12/04 李侠　PM.NS-4・保守依頼③の対応</br>
    /// <br>　　　　　 : 2010/11/15 李占川 PM1014の対応</br>
    /// </remarks>
	public class MAZAI04310UA : System.Windows.Forms.Form
	{
		#region Const
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //// テーブル名
        //private const string TBL_HISTORY			= "History";

        //// 行番号
        //private const string COL_ROWNUM = "RowNum";

        //// 計上有無
        //private const string COL_ADDUPEXST          = "AddUpExst";
        //// 伝票番号
        //private const string COL_SLIPCD             = "SlipCd";
        //// 伝票区分
        //private const string COL_SLIPNO             = "SlipNo";
        //// 取引区分
        //private const string COL_TRANSDIV           = "TransDiv";
        //// 商品コード
        //private const string COL_GOODSCODE          = "GoodsCode";
        //// 商品名称
        //private const string COL_GOODSNM            = "GoodsNm";
        //// 入荷数
        //private const string COL_ARRIVALGOODSCNT    = "ArrivalGoodsCnt";
        //// 出荷数
        //private const string COL_SHIPMCNT           = "ShipmCnt";
        //// 在庫数
        //private const string COL_STOCKCNT           = "StockCnt";
        //// 出荷未計上残
        //private const string COL_SHIPMNOADDUPREM    = "ShipmNoAddupRem";
        //// 入荷未計上算
        //private const string COL_ARRIVALNOADDUPREM  = "ArrivalNoAddupRem";
        //// 受払先
        //private const string COL_RECVPYEECUST       = "RecvPyeeCust";
        //// 機種
        //private const string COL_MODEL              = "Model";
        //// 事業者
        //private const string COL_CARRIEREP          = "CarrierEP";
        //// 製造番号
        //private const string COL_PRODUCTNO          = "ProductNo";
        //// SIM製造番号
        //private const string COL_SIMPRODUCENO       = "SIMProduceNo";
        //// 携帯番号
        //private const string COL_CPHONENO           = "CPhoneNo";
        //// 入出荷日
        //private const string COL_tde_st_IoGoodsDay = "tde_st_IoGoodsDay";
        //// 拠点CD
        //private const string COL_SECTIONCODE = "SectionCode";
        //// 拠点名称
        //private const string COL_SECTIONNAME = "SectionName";
        ////移動元拠点
        //private const string COL_BFSECTIONGUIDENM = "BfSectionGuidName";
        ////移動元倉庫
        //private const string COL_BFENTERWAREHCODE = "BfEnterWarehCode";
        ////移動元倉庫名
        //private const string COL_BFENTERWAREHNAME = "BfEnterWarehName";
        ////移動先拠点
        //private const string COL_AFSECTIONGUIDENM = "AfSectionGuideNm";
        ////移動先倉庫
        //private const string COL_AFENTERWAREHCODE = "AfEnterWarehCode";
        ////移動元倉庫名
        //private const string COL_AFENTERWAREHNAME = "AfEnterWarehName";
        ////伝票備考
        //private const string COL_ACPAYNOTE = "AcPayNote";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // Read件数保存XMLファイル名
		private const string ctFileNm	= "MAZAI04310U.XML";

//        private const string ctGridInfoFileNm = "MAZAI04310UA.dat";

        //取引区分
        private const string TK_10 = "通常";
        private const string TK_11 = "返品";
        private const string TK_12 = "値引";
        private const string TK_20 = "赤伝";
        private const string TK_21 = "削除";
        private const string TK_30 = "在庫数調整";
        private const string TK_31 = "原価調整";
        private const string TK_32 = "製番調整";
        private const string TK_33 = "不良品";
        private const string TK_34 = "抜出";
        private const string TK_35 = "消去";
        private const string TK_40 = "過不足更新";
        private const string TK_90 = "取消";

        //伝票区分
        private const string SK_10 = "仕入";
        private const string SK_11 = "受託";
        private const string SK_12 = "受計上";
        private const string SK_20 = "売上";
        private const string SK_21 = "売計上";
        private const string SK_22 = "委託";
        private const string SK_23 = "売切";
        private const string SK_30 = "移動出荷";
        private const string SK_31 = "移動入荷";
        private const string SK_40 = "調整";
        private const string SK_41 = "半黒";
        private const string SK_50 = "棚卸";

        // -----ADD 2008/07/17 ------------------------------------------->>>>>
        // READ結果
        private const int READDATA_FAILED = -1;         // 読み込み失敗
        private const int READDATA_CNDTNEMPTY = 0;      // 入力なし
        private const int READDATA_SUCCESS = 1;         // 読み込み成功
        private const int READDATA_CANCEL = 2;          // 読み込みキャンセル
        // -----ADD 2008/07/17 -------------------------------------------<<<<<
        # endregion

        # region Struct
        /// <summary>
        /// ヘッダ情報　構造体
        /// </summary>
        internal struct HeaderInfo
        {
            private string _goodsNo;
            private int _goodsMakerCode;
            private string _sectionCode;
            private string _warehouseCode;

            public int GoodsMakerCode
            {
                get { return _goodsMakerCode; }
                set { _goodsMakerCode = value; }
            }
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            public string WarehouseCode
            {
                get { return _warehouseCode; }
                set { _warehouseCode = value; }
            }
        }
        # endregion

        # region Private Members
        // アイコン用
		private ImageList _imageList16 = null;

		// 企業コード取得用
		private string _enterprisecode = "";
		// ステータスバー表示文字列
		private string statusbarStr = "";
		// 起動パラメータ
		private static string[] _parameter;
		// 起動フォーム
		private static System.Windows.Forms.Form _form = null;
		// 拠点情報取得部品
		private SecInfoAcs _SecInfoAcs;
        // 得意先マスタアクセス部品
        private CustomerInfoAcs _customerInfoAcs;
		// 拠点情報データクラス
		private SecInfoSet _secInfoSet;
		// 自社名称データクラス
		private CompanyNm companyNm;

        // 締日算出モジュール
        private TotalDayCalculator _totalDayCalculator;     //ADD 2008/11/17

		private DataSet ds = null;
		
        //// フォーカス遷移値退避用、前回値
        //private string _prevText = "";
        //private double _prevDouble  = 0;

		// 履歴データ
		//private List<StockAcPayHist> _stockAcPayHistList = null;                  //DEL 2008/07/17 使用クラス変更の為
        private List<StockAcPayHisSearchRet> _stockAcPayHisSearchRetList = null;    //ADD 2008/07/17
        private List<StockCarEnterCarOutRet> _stockCarEnterCarOutRetList = null;    //ADD 2008/07/17

        //// 印刷確認画面＆明細履歴画面表示中フラグ
        //private bool _showPrintDialogFlg = false;

        // 抽出モード
        private int SearchMode = 0;
		// 抽出中ダイアログ
		private MAZAI04310UB _MAZAI04310ub;
        // 起動画面
        private static Broadleaf.Windows.Forms.FloatingWindow _floatingWindow = new FloatingWindow();

        // グリッド設定制御クラス
		GridStateController _gridStateController = new GridStateController();

        // 画面デザイン変更クラス
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
        // アクセスクラス
        private MakerAcs _makerAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private CarrierOdrAcs _carrierOdrAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private WarehouseAcs _warehouseAcs;
        private GoodsAcs _goodsAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //// 前回入力退避用
        //private int _beforeMakerCd;
        //private string _beforeGoodsNo;
        //private string _beforeSectionCd;
        //private string _beforeWarehouseCd;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // DataView
        private DataView _stockAcPayHistView;
        
        // 区分名Dictionary
        private Dictionary<int, string> _acPaySlipNmDic;    // 伝票区分名称ディクショナリ
        private Dictionary<int, string> _acPayTransNmDic;   // 取引区分名称ディクショナリ

        // 入荷数・仕入金額を印字する伝票区分
        private List<int> _stockAcPaySlipOfArrivalList;
        // 出荷数・仕入金額を印字する伝票区分
        private List<int> _stockAcPaySlipOfShipmentList;
        // 出荷数・売上金額を印字する伝票区分
        private List<int> _stockAcPaySlipOfSalesList;

        //// 在庫調整の伝票区分
        //private List<int> _stockAcPaySlipOfAdjustList;

        // 前回入力ヘッダ情報
        private HeaderInfo _prevHeaderInfo;

        // ガイド後次フォーカス制御
        private GuideNextFocusControl _guideNextFocusControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // -----ADD 2008/07/17 ------------------------------------------->>>>>
        // 印刷関連
        //private DCZAI02200UA _printControl = null;
        private StockAcPayListCndtn _stockAcPayListCndtn = new StockAcPayListCndtn();
        // -----ADD 2008/07/17 -------------------------------------------<<<<<

		# endregion

		#region Private Members (Component)
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Right;
		private Broadleaf.Library.Windows.Forms.TToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea2;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea3;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
		private TComboEditor FontSize_tComboEditor;
        private UltraCheckEditor AutoFitCol_ultraCheckEditor;
        private UiSetControl uiSetControl1;
        private Panel panel2;
        private Infragistics.Win.Misc.UltraLabel lb_CarryForwardCnt;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel lb_GridShipmentTotal;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private Infragistics.Win.Misc.UltraLabel lb_GridArrivalTotal;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Infragistics.Win.Misc.UltraLabel lb_StCarryForwardCnt;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private UltraGrid History_Grid;
        private Panel panel3;
        private Infragistics.Win.Misc.UltraLabel lb_AcpOdrCount;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel lb_ShipmentPosCnt;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel lb_ShipmentCntTotal;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private Infragistics.Win.Misc.UltraLabel lb_ArrivalCntTotal;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel lb_LMonthStockCnt;
        private Infragistics.Win.Misc.UltraLabel AllMvPrice_ultraLabel;
        private Infragistics.Win.Misc.UltraExpandableGroupBox uGroupBox_ExtractInfo;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private Panel panel1;
        private Infragistics.Win.Misc.UltraLabel lb_BLGoodsCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel lb_WarehouseShelfNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel lb_WarehouseName;
        private Infragistics.Win.Misc.UltraLabel lb_SectionName;
        private Infragistics.Win.Misc.UltraLabel lb_GoodsName;
        private Infragistics.Win.Misc.UltraLabel lb_MakerName;
        private Infragistics.Win.Misc.UltraButton ub_WarehouseGuide;
        private TEdit tEdit_WarehouseCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private TDateEdit tde_ed_IoGoodsDay;
        private TNedit tNedit_GoodsMakerCd;
        private TEdit tEdit_GoodsNo;
        private Infragistics.Win.Misc.UltraButton ub_MakerGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TComboEditor ce_IoGoodsDayDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private TDateEdit tde_st_IoGoodsDay;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private TComboEditor ce_SlipKindDiv;
        private Infragistics.Win.Misc.UltraButton ub_SectionGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TEdit tEdit_SectionCodeAllowZero;
        private Infragistics.Win.Misc.UltraButton ub_GoodsGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private UltraCheckEditor CheckEditor_DeleteDataSearch;
        private Broadleaf.Library.Windows.Forms.UiMemInput uiMemInput1;
		private System.ComponentModel.IContainer components;
		#endregion

		#region constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
		public MAZAI04310UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// Configファイル情報取得
            //RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;

			// 企業コード取得
			_enterprisecode = LoginInfoAcquisition.EnterpriseCode;

			//---拠点情報部品アクセスクラスのインスタンス化---//
			//ここでログイン企業コードから全ての拠点情報をサーバーから取得します
			_SecInfoAcs = new SecInfoAcs();

            _customerInfoAcs = new CustomerInfoAcs();

            // 履歴削除用アクセスクラスインスタンス作成
//            _mainWkHisAcs = new MainWkHisAcs();

            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<

			// ツールバー初期設定処理
			this.SetToolbar();

            // アクセスクラス(ガイド用)
            this._makerAcs = new MakerAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._carrierOdrAcs = new CarrierOdrAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._warehouseAcs = new WarehouseAcs();
            this._goodsAcs = new GoodsAcs();
            string msg;
            this._goodsAcs.SearchInitial( this._enterprisecode, string.Empty, out msg );

            this._acPaySlipNmDic = CreateAcPaySlipNmDictionary();
            this._acPayTransNmDic = CreateAcPayTransNmDictionary();

            /* ---DEL 2008/12/09 不具合対応[8827] ----------------------------------->>>>>
            // 入荷数・仕入金額を印字する伝票区分のリスト
            // 10:仕入
            // 11:入荷
            // 31:移動入荷
            // 40:調整
            // 50:棚卸
            _stockAcPaySlipOfArrivalList = new List<int>();
            _stockAcPaySlipOfArrivalList.AddRange( new int[] { 10, 11, 31, 40, 50 } );

            // 出荷数・仕入金額を印字する伝票区分のリスト
            // 30:移動出荷
            _stockAcPaySlipOfShipmentList = new List<int>();
            _stockAcPaySlipOfShipmentList.AddRange( new int[] { 30 } );

            // 出荷数・売上金額を印字する伝票区分のリスト
            // 12:受計上
            // 20:売上
            // 21:売計上
            // 22:出荷
            // 23:売切
            // 41:半黒
            _stockAcPaySlipOfSalesList = new List<int>();
            _stockAcPaySlipOfSalesList.AddRange( new int[] { 12, 20, 21, 22, 23, 41 } );
               ---DEL 2008/12/09 不具合対応[8827] -----------------------------------<<<<< */
            // ---ADD 2008/12/09 不具合対応[8827] ----------------------------------->>>>>
            // 10：仕入、11：入荷、13：在庫仕入、31：移動入荷、40：調整、42：マスタメンテ、50：棚卸、60：組立、61：分解、70：補充入庫
            _stockAcPaySlipOfArrivalList = new List<int>();
            _stockAcPaySlipOfArrivalList.AddRange(new int[] { 10, 11, 13, 31, 40, 42, 50, 60, 61, 70 });
            // 12：受計上、20：売上、21：売計上、22：出荷、23：売切、30：移動出荷、41：半黒、71：補充出庫
            _stockAcPaySlipOfShipmentList = new List<int>();
            _stockAcPaySlipOfShipmentList.AddRange(new int[] { 12, 20, 21, 22, 23, 30, 41, 71 });
            // ---ADD 2008/12/09 不具合対応[8827] -----------------------------------<<<<<


            //// 在庫調整の伝票区分リスト
            //_stockAcPaySlipOfAdjustList = new List<int>();
            //_stockAcPaySlipOfAdjustList.AddRange( new int[] {} );

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

//            this._carrierEpAcs = new CarrierEpAcs();


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// テキスト出力オプションのオプション導入状況を取得（テキスト出力はUSB単位にオプションチェック）
            //PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);

            //if (purchaseStatus == PurchaseStatus.Contract ||        // 契約済み
            //    purchaseStatus == PurchaseStatus.Trial_Contract)    // 体験版契約済み
            //{
            //    // 契約時は、テキスト出力ボタン表示
            //    this.Main_ToolbarsManager.Tools["TextOut_ButtonTool"].SharedProps.Visible = true;
            //}
            //else
            //{
            //    // 未契約時は、テキスト出力ボタン非表示
            //    this.Main_ToolbarsManager.Tools["TextOut_ButtonTool"].SharedProps.Visible = false;
            //}

            // テキスト出力は未実装のようなのでfalse
            this.Main_ToolbarsManager.Tools["TextOut_ButtonTool"].SharedProps.Visible = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_GoodsNo.Clear();
            //this.tEdit_SectionCodeAllowZero.Clear();          //DEL 2009/06/26 不具合対応[13625]
            this.tEdit_WarehouseCode.Clear();

            //this._beforeMakerCd = 0;
            //this._beforeGoodsNo = string.Empty;
            //this._beforeSectionCd = string.Empty;
            //this._beforeWarehouseCd = string.Empty;

            _prevHeaderInfo = new HeaderInfo();

            // ガイド後フォーカス制御設定
            SettingGuideNextFocusControl();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		}

        /// <summary>
        /// ガイド後次フォーカス制御設定
        /// </summary>
        private void SettingGuideNextFocusControl()
        {
            _guideNextFocusControl = new GuideNextFocusControl();

            /* -----DEL 2008/07/17 タブ順変更の為 ---------------->>>>>
            _guideNextFocusControl.Add( tne_GoodsMakerCd );
            _guideNextFocusControl.Add( te_GoodsNo );
            _guideNextFocusControl.Add( ce_SlipKindDiv );

            _guideNextFocusControl.Add( te_SectionCode );
            _guideNextFocusControl.Add( te_WarehouseCode );
            _guideNextFocusControl.Add( tde_st_IoGoodsDay );
               -----DEL 2008/07/17 -------------------------------<<<<< */
            // -----ADD 2008/07/17 ------------------------------->>>>>
            //_guideNextFocusControl.Add(tEdit_SectionCodeAllowZero);      // 拠点      //DEL 2009/06/26 不具合対応[13625]
            _guideNextFocusControl.Add(ce_SlipKindDiv);         // 伝票区分
            _guideNextFocusControl.Add(tde_st_IoGoodsDay);      // 入出荷日(From)
            _guideNextFocusControl.Add(tde_ed_IoGoodsDay);      // 入出荷日(To)
            _guideNextFocusControl.Add(tEdit_WarehouseCode);    // 倉庫
            _guideNextFocusControl.Add(tEdit_GoodsNo);          // 品番
            _guideNextFocusControl.Add(tNedit_GoodsMakerCd);    // メーカー
            // -----ADD 2008/07/17 -------------------------------<<<<<

            // 以後はガイドに関係ないので略
        }
		#endregion

		#region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("倉庫ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("メーカーガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("商品ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_Toolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("Section_ComboBoxTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("Section_ComboBoxTool");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem31 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem32 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem33 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem34 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI04310UA));
            this.FontSize_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoFitCol_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ub_WarehouseGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_MakerGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_GoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_CarryForwardCnt = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_GridShipmentTotal = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_GridArrivalTotal = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_StCarryForwardCnt = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolbarsDockArea3 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this.ultraToolbarsDockArea2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.uGroupBox_ExtractInfo = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckEditor_DeleteDataSearch = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lb_BLGoodsCode = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_WarehouseShelfNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_WarehouseName = new Infragistics.Win.Misc.UltraLabel();
            this.lb_SectionName = new Infragistics.Win.Misc.UltraLabel();
            this.lb_GoodsName = new Infragistics.Win.Misc.UltraLabel();
            this.lb_MakerName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_WarehouseCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.tde_ed_IoGoodsDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ce_IoGoodsDayDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tde_st_IoGoodsDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ce_SlipKindDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_AcpOdrCount = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_ShipmentPosCnt = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_ShipmentCntTotal = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_ArrivalCntTotal = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_LMonthStockCnt = new Infragistics.Win.Misc.UltraLabel();
            this.AllMvPrice_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.History_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).BeginInit();
            this.ultraStatusBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGroupBox_ExtractInfo)).BeginInit();
            this.uGroupBox_ExtractInfo.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ce_IoGoodsDayDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ce_SlipKindDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.History_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // FontSize_tComboEditor
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FontSize_tComboEditor.ActiveAppearance = appearance65;
            this.FontSize_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FontSize_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 7.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FontSize_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Off;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FontSize_tComboEditor.ItemAppearance = appearance66;
            valueListItem1.DataValue = 6;
            valueListItem1.DisplayText = "6";
            valueListItem2.DataValue = 8;
            valueListItem2.DisplayText = "8";
            valueListItem3.DataValue = 9;
            valueListItem3.DisplayText = "9";
            valueListItem4.DataValue = 10;
            valueListItem4.DisplayText = "10";
            valueListItem5.DataValue = 11;
            valueListItem5.DisplayText = "11";
            valueListItem6.DataValue = 12;
            valueListItem6.DisplayText = "12";
            valueListItem7.DataValue = 14;
            valueListItem7.DisplayText = "14";
            this.FontSize_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.FontSize_tComboEditor.Location = new System.Drawing.Point(70, 3);
            this.FontSize_tComboEditor.Name = "FontSize_tComboEditor";
            this.FontSize_tComboEditor.Size = new System.Drawing.Size(50, 18);
            this.FontSize_tComboEditor.TabIndex = 13;
            this.FontSize_tComboEditor.TabStop = false;
            this.FontSize_tComboEditor.Text = "11";
            this.FontSize_tComboEditor.ValueChanged += new System.EventHandler(this.FontSize_tComboEditor_ValueChanged);
            // 
            // AutoFitCol_ultraCheckEditor
            // 
            appearance67.FontData.SizeInPoints = 9F;
            this.AutoFitCol_ultraCheckEditor.Appearance = appearance67;
            this.AutoFitCol_ultraCheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.AutoFitCol_ultraCheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.AutoFitCol_ultraCheckEditor.Location = new System.Drawing.Point(125, 3);
            this.AutoFitCol_ultraCheckEditor.Name = "AutoFitCol_ultraCheckEditor";
            this.AutoFitCol_ultraCheckEditor.Size = new System.Drawing.Size(145, 18);
            this.AutoFitCol_ultraCheckEditor.TabIndex = 14;
            this.AutoFitCol_ultraCheckEditor.TabStop = false;
            this.AutoFitCol_ultraCheckEditor.Text = "列サイズの自動調整";
            this.AutoFitCol_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.AutoFitCol_ultraCheckEditor_CheckedChanged);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Controls.Add(this.FontSize_tComboEditor);
            this.ultraStatusBar1.Controls.Add(this.AutoFitCol_ultraCheckEditor);
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            appearance23.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance23;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_FontSizeCaption";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel1.Text = "文字サイズ";
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Control = this.FontSize_tComboEditor;
            ultraStatusPanel2.Key = "StatusBarPanel_FontSize";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel2.Width = 50;
            ultraStatusPanel3.Width = 1;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Control = this.AutoFitCol_ultraCheckEditor;
            ultraStatusPanel4.Key = "StatusBarPanel_AutoFitCol";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel4.Width = 145;
            appearance24.FontData.SizeInPoints = 9F;
            ultraStatusPanel5.Appearance = appearance24;
            ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel5.Key = "StatusBarPanel_Text";
            ultraStatusPanel5.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel5.Width = 200;
            appearance38.FontData.SizeInPoints = 9F;
            ultraStatusPanel6.Appearance = appearance38;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "StatusBarPanel_update";
            appearance39.FontData.ItalicAsString = "False";
            ultraStatusPanel7.Appearance = appearance39;
            ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel7.Key = "StatusBarPanel_Progress";
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.SizeInPoints = 10F;
            ultraStatusPanel7.ProgressBarInfo.Appearance = appearance40;
            appearance41.FontData.BoldAsString = "True";
            appearance41.FontData.SizeInPoints = 9F;
            appearance41.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel7.ProgressBarInfo.FillAppearance = appearance41;
            ultraStatusPanel7.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel7.Visible = false;
            ultraStatusPanel7.Width = 158;
            ultraStatusPanel8.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel8.Key = "StatusBarPanel_Date";
            ultraStatusPanel8.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel8.Width = 90;
            ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel9.Key = "StatusBarPanel_Time";
            ultraStatusPanel9.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel9.Width = 50;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel7,
            ultraStatusPanel8,
            ultraStatusPanel9});
            this.ultraStatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ultraStatusBar1.Size = new System.Drawing.Size(1016, 23);
            this.ultraStatusBar1.TabIndex = 8;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            this.ultraStatusBar1.WrapText = false;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // ub_WarehouseGuide
            // 
            this.ub_WarehouseGuide.Location = new System.Drawing.Point(327, 35);
            this.ub_WarehouseGuide.Name = "ub_WarehouseGuide";
            this.ub_WarehouseGuide.Size = new System.Drawing.Size(24, 24);
            this.ub_WarehouseGuide.TabIndex = 7;
            this.ub_WarehouseGuide.Tag = "";
            ultraToolTipInfo1.ToolTipText = "倉庫ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.ub_WarehouseGuide, ultraToolTipInfo1);
            this.ub_WarehouseGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_WarehouseGuide.Click += new System.EventHandler(this.ub_WarehouseGuide_Click);
            // 
            // ub_MakerGuide
            // 
            this.ub_MakerGuide.Location = new System.Drawing.Point(908, 94);
            this.ub_MakerGuide.Name = "ub_MakerGuide";
            this.ub_MakerGuide.Size = new System.Drawing.Size(24, 24);
            this.ub_MakerGuide.TabIndex = 11;
            this.ub_MakerGuide.Tag = "";
            ultraToolTipInfo2.ToolTipText = "メーカーガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.ub_MakerGuide, ultraToolTipInfo2);
            this.ub_MakerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_MakerGuide.Click += new System.EventHandler(this.ub_MakerGuide_Click);
            // 
            // ub_SectionGuide
            // 
            this.ub_SectionGuide.Location = new System.Drawing.Point(311, 131);
            this.ub_SectionGuide.Name = "ub_SectionGuide";
            this.ub_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.ub_SectionGuide.TabIndex = 1;
            this.ub_SectionGuide.Tag = "";
            ultraToolTipInfo3.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.ub_SectionGuide, ultraToolTipInfo3);
            this.ub_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_SectionGuide.Visible = false;
            // 
            // ub_GoodsGuide
            // 
            this.ub_GoodsGuide.Location = new System.Drawing.Point(311, 67);
            this.ub_GoodsGuide.Name = "ub_GoodsGuide";
            this.ub_GoodsGuide.Size = new System.Drawing.Size(24, 24);
            this.ub_GoodsGuide.TabIndex = 9;
            this.ub_GoodsGuide.Tag = "";
            ultraToolTipInfo4.ToolTipText = "商品ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.ub_GoodsGuide, ultraToolTipInfo4);
            this.ub_GoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_GoodsGuide.Visible = false;
            this.ub_GoodsGuide.Click += new System.EventHandler(this.ub_GoodsGuide_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lb_CarryForwardCnt);
            this.panel2.Controls.Add(this.ultraLabel14);
            this.panel2.Controls.Add(this.lb_GridShipmentTotal);
            this.panel2.Controls.Add(this.ultraLabel21);
            this.panel2.Controls.Add(this.lb_GridArrivalTotal);
            this.panel2.Controls.Add(this.ultraLabel23);
            this.panel2.Controls.Add(this.lb_StCarryForwardCnt);
            this.panel2.Controls.Add(this.ultraLabel25);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 680);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 31);
            this.panel2.TabIndex = 23;
            // 
            // lb_CarryForwardCnt
            // 
            appearance36.TextHAlignAsString = "Right";
            appearance36.TextVAlignAsString = "Middle";
            this.lb_CarryForwardCnt.Appearance = appearance36;
            this.lb_CarryForwardCnt.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_CarryForwardCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_CarryForwardCnt.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_CarryForwardCnt.Location = new System.Drawing.Point(894, 4);
            this.lb_CarryForwardCnt.Margin = new System.Windows.Forms.Padding(4);
            this.lb_CarryForwardCnt.Name = "lb_CarryForwardCnt";
            this.lb_CarryForwardCnt.Size = new System.Drawing.Size(118, 24);
            this.lb_CarryForwardCnt.TabIndex = 133;
            this.lb_CarryForwardCnt.Text = "0";
            // 
            // ultraLabel14
            // 
            appearance37.TextHAlignAsString = "Center";
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance37;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel14.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(820, 4);
            this.ultraLabel14.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel14.TabIndex = 132;
            this.ultraLabel14.Text = "繰越数";
            // 
            // lb_GridShipmentTotal
            // 
            appearance51.TextHAlignAsString = "Right";
            appearance51.TextVAlignAsString = "Middle";
            this.lb_GridShipmentTotal.Appearance = appearance51;
            this.lb_GridShipmentTotal.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_GridShipmentTotal.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_GridShipmentTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_GridShipmentTotal.Location = new System.Drawing.Point(486, 4);
            this.lb_GridShipmentTotal.Margin = new System.Windows.Forms.Padding(4);
            this.lb_GridShipmentTotal.Name = "lb_GridShipmentTotal";
            this.lb_GridShipmentTotal.Size = new System.Drawing.Size(118, 24);
            this.lb_GridShipmentTotal.TabIndex = 131;
            this.lb_GridShipmentTotal.Text = "0";
            // 
            // ultraLabel21
            // 
            appearance52.TextHAlignAsString = "Center";
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance52;
            this.ultraLabel21.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel21.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel21.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel21.Location = new System.Drawing.Point(412, 4);
            this.ultraLabel21.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel21.TabIndex = 130;
            this.ultraLabel21.Text = "出庫数計";
            // 
            // lb_GridArrivalTotal
            // 
            appearance50.TextHAlignAsString = "Right";
            appearance50.TextVAlignAsString = "Middle";
            this.lb_GridArrivalTotal.Appearance = appearance50;
            this.lb_GridArrivalTotal.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_GridArrivalTotal.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_GridArrivalTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_GridArrivalTotal.Location = new System.Drawing.Point(282, 4);
            this.lb_GridArrivalTotal.Margin = new System.Windows.Forms.Padding(4);
            this.lb_GridArrivalTotal.Name = "lb_GridArrivalTotal";
            this.lb_GridArrivalTotal.Size = new System.Drawing.Size(118, 24);
            this.lb_GridArrivalTotal.TabIndex = 129;
            this.lb_GridArrivalTotal.Text = "0";
            // 
            // ultraLabel23
            // 
            appearance53.TextHAlignAsString = "Center";
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel23.Appearance = appearance53;
            this.ultraLabel23.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel23.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel23.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel23.Location = new System.Drawing.Point(208, 4);
            this.ultraLabel23.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel23.TabIndex = 128;
            this.ultraLabel23.Text = "入庫数計";
            // 
            // lb_StCarryForwardCnt
            // 
            appearance54.TextHAlignAsString = "Right";
            appearance54.TextVAlignAsString = "Middle";
            this.lb_StCarryForwardCnt.Appearance = appearance54;
            this.lb_StCarryForwardCnt.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_StCarryForwardCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_StCarryForwardCnt.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_StCarryForwardCnt.Location = new System.Drawing.Point(78, 4);
            this.lb_StCarryForwardCnt.Margin = new System.Windows.Forms.Padding(4);
            this.lb_StCarryForwardCnt.Name = "lb_StCarryForwardCnt";
            this.lb_StCarryForwardCnt.Size = new System.Drawing.Size(118, 24);
            this.lb_StCarryForwardCnt.TabIndex = 127;
            this.lb_StCarryForwardCnt.Text = "0";
            // 
            // ultraLabel25
            // 
            appearance55.TextHAlignAsString = "Center";
            appearance55.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance55;
            this.ultraLabel25.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel25.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel25.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel25.Location = new System.Drawing.Point(4, 4);
            this.ultraLabel25.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel25.TabIndex = 126;
            this.ultraLabel25.Text = "残数";
            // 
            // ultraToolbarsDockArea3
            // 
            this.ultraToolbarsDockArea3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea3.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.ultraToolbarsDockArea3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea3.Location = new System.Drawing.Point(1016, 63);
            this.ultraToolbarsDockArea3.Name = "ultraToolbarsDockArea3";
            this.ultraToolbarsDockArea3.Size = new System.Drawing.Size(0, 648);
            this.ultraToolbarsDockArea3.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingSize = new System.Drawing.Size(726, 23);
            ultraToolbar1.IsMainMenuBar = true;
            labelTool2.InstanceProps.Width = 62;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            labelTool1,
            labelTool2,
            comboBoxTool1,
            labelTool3,
            labelTool4});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6});
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.Main_ToolbarsManager.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool2.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7,
            buttonTool8,
            buttonTool9});
            labelTool5.SharedProps.Spring = true;
            labelTool6.SharedProps.Caption = "ログイン担当者";
            labelTool6.SharedProps.ShowInCustomizer = false;
            appearance42.BackColor = System.Drawing.Color.White;
            appearance42.TextHAlignAsString = "Left";
            labelTool7.SharedProps.AppearancesSmall.Appearance = appearance42;
            labelTool7.SharedProps.Caption = "翼　太郎";
            labelTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 150;
            buttonTool10.SharedProps.Caption = "終了(&X)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.ToolTipText = "画面を終了します。";
            buttonTool11.SharedProps.Caption = "印刷(&P)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.ToolTipText = "履歴を印刷します。";
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            comboBoxTool2.EditAppearance = appearance43;
            comboBoxTool2.SharedProps.Enabled = false;
            comboBoxTool2.SharedProps.Visible = false;
            comboBoxTool2.ValueList = valueList1;
            labelTool8.SharedProps.Caption = "拠　点";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool8.SharedProps.Visible = false;
            buttonTool12.SharedProps.Caption = "テキスト出力(&O)";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool12.SharedProps.ToolTipText = "履歴をテキスト出力します。";
            buttonTool12.SharedProps.Visible = false;
            buttonTool13.SharedProps.Caption = "クリア(&C)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Caption = "検索(&R)";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool15.SharedProps.Caption = "PDF表示(&V)";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2,
            labelTool5,
            labelTool6,
            labelTool7,
            buttonTool10,
            buttonTool11,
            comboBoxTool2,
            labelTool8,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.Main_ToolbarsManager_ToolValueChanged);
            // 
            // ultraToolbarsDockArea2
            // 
            this.ultraToolbarsDockArea2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this.ultraToolbarsDockArea2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea2.Location = new System.Drawing.Point(0, 63);
            this.ultraToolbarsDockArea2.Name = "ultraToolbarsDockArea2";
            this.ultraToolbarsDockArea2.Size = new System.Drawing.Size(0, 648);
            this.ultraToolbarsDockArea2.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // ultraToolbarsDockArea1
            // 
            this.ultraToolbarsDockArea1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea1.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this.ultraToolbarsDockArea1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea1.Location = new System.Drawing.Point(0, 711);
            this.ultraToolbarsDockArea1.Name = "ultraToolbarsDockArea1";
            this.ultraToolbarsDockArea1.Size = new System.Drawing.Size(1016, 0);
            this.ultraToolbarsDockArea1.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Right
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Right";
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 648);
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Left
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Left";
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 648);
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Top
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Top";
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Bottom";
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // uGroupBox_ExtractInfo
            // 
            this.uGroupBox_ExtractInfo.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.uGroupBox_ExtractInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.uGroupBox_ExtractInfo.ExpandedSize = new System.Drawing.Size(1016, 178);
            this.uGroupBox_ExtractInfo.Location = new System.Drawing.Point(0, 63);
            this.uGroupBox_ExtractInfo.Name = "uGroupBox_ExtractInfo";
            this.uGroupBox_ExtractInfo.Size = new System.Drawing.Size(1016, 178);
            this.uGroupBox_ExtractInfo.TabIndex = 1;
            this.uGroupBox_ExtractInfo.TabStop = false;
            this.uGroupBox_ExtractInfo.Text = "絞込条件";
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.panel1);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(1010, 156);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.CheckEditor_DeleteDataSearch);
            this.panel1.Controls.Add(this.lb_BLGoodsCode);
            this.panel1.Controls.Add(this.ultraLabel9);
            this.panel1.Controls.Add(this.lb_WarehouseShelfNo);
            this.panel1.Controls.Add(this.ultraLabel4);
            this.panel1.Controls.Add(this.lb_WarehouseName);
            this.panel1.Controls.Add(this.lb_SectionName);
            this.panel1.Controls.Add(this.lb_GoodsName);
            this.panel1.Controls.Add(this.lb_MakerName);
            this.panel1.Controls.Add(this.ub_WarehouseGuide);
            this.panel1.Controls.Add(this.tEdit_WarehouseCode);
            this.panel1.Controls.Add(this.ultraLabel6);
            this.panel1.Controls.Add(this.tde_ed_IoGoodsDay);
            this.panel1.Controls.Add(this.tNedit_GoodsMakerCd);
            this.panel1.Controls.Add(this.tEdit_GoodsNo);
            this.panel1.Controls.Add(this.ub_MakerGuide);
            this.panel1.Controls.Add(this.ultraLabel8);
            this.panel1.Controls.Add(this.ce_IoGoodsDayDiv);
            this.panel1.Controls.Add(this.ultraLabel13);
            this.panel1.Controls.Add(this.tde_st_IoGoodsDay);
            this.panel1.Controls.Add(this.ultraLabel5);
            this.panel1.Controls.Add(this.ce_SlipKindDiv);
            this.panel1.Controls.Add(this.ub_SectionGuide);
            this.panel1.Controls.Add(this.ultraLabel3);
            this.panel1.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.panel1.Controls.Add(this.ub_GoodsGuide);
            this.panel1.Controls.Add(this.ultraLabel1);
            this.panel1.Controls.Add(this.ultraLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 156);
            this.panel1.TabIndex = 47;
            // 
            // CheckEditor_DeleteDataSearch
            // 
            appearance108.FontData.SizeInPoints = 10F;
            this.CheckEditor_DeleteDataSearch.Appearance = appearance108;
            this.CheckEditor_DeleteDataSearch.BackColor = System.Drawing.Color.Transparent;
            this.CheckEditor_DeleteDataSearch.BackColorInternal = System.Drawing.Color.Transparent;
            this.CheckEditor_DeleteDataSearch.Location = new System.Drawing.Point(318, 69);
            this.CheckEditor_DeleteDataSearch.Name = "CheckEditor_DeleteDataSearch";
            this.CheckEditor_DeleteDataSearch.Size = new System.Drawing.Size(166, 20);
            this.CheckEditor_DeleteDataSearch.TabIndex = 10;
            this.CheckEditor_DeleteDataSearch.TabStop = false;
            this.CheckEditor_DeleteDataSearch.Text = "削除済み在庫も検索";
            // 
            // lb_BLGoodsCode
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance15.BorderColor = System.Drawing.Color.RosyBrown;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.lb_BLGoodsCode.Appearance = appearance15;
            this.lb_BLGoodsCode.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_BLGoodsCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_BLGoodsCode.Location = new System.Drawing.Point(602, 125);
            this.lb_BLGoodsCode.Name = "lb_BLGoodsCode";
            this.lb_BLGoodsCode.Padding = new System.Drawing.Size(3, 0);
            this.lb_BLGoodsCode.Size = new System.Drawing.Size(59, 24);
            this.lb_BLGoodsCode.TabIndex = 109;
            this.lb_BLGoodsCode.Text = "12345";
            this.lb_BLGoodsCode.WrapText = false;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel9.Location = new System.Drawing.Point(513, 128);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(67, 17);
            this.ultraLabel9.TabIndex = 108;
            this.ultraLabel9.Text = "BLｺｰﾄﾞ";
            // 
            // lb_WarehouseShelfNo
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance44.BorderColor = System.Drawing.Color.RosyBrown;
            appearance44.TextVAlignAsString = "Middle";
            this.lb_WarehouseShelfNo.Appearance = appearance44;
            this.lb_WarehouseShelfNo.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_WarehouseShelfNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_WarehouseShelfNo.Location = new System.Drawing.Point(602, 63);
            this.lb_WarehouseShelfNo.Name = "lb_WarehouseShelfNo";
            this.lb_WarehouseShelfNo.Padding = new System.Drawing.Size(3, 0);
            this.lb_WarehouseShelfNo.Size = new System.Drawing.Size(89, 24);
            this.lb_WarehouseShelfNo.TabIndex = 107;
            this.lb_WarehouseShelfNo.Text = "TANA-678";
            this.lb_WarehouseShelfNo.WrapText = false;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel4.Location = new System.Drawing.Point(513, 66);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(67, 17);
            this.ultraLabel4.TabIndex = 106;
            this.ultraLabel4.Text = "棚番";
            // 
            // lb_WarehouseName
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance59.BorderColor = System.Drawing.Color.RosyBrown;
            appearance59.TextVAlignAsString = "Middle";
            this.lb_WarehouseName.Appearance = appearance59;
            this.lb_WarehouseName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_WarehouseName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_WarehouseName.Location = new System.Drawing.Point(156, 35);
            this.lb_WarehouseName.Name = "lb_WarehouseName";
            this.lb_WarehouseName.Padding = new System.Drawing.Size(3, 0);
            this.lb_WarehouseName.Size = new System.Drawing.Size(165, 24);
            this.lb_WarehouseName.TabIndex = 105;
            this.lb_WarehouseName.Text = "あいうえおかきくけこ";
            this.lb_WarehouseName.WrapText = false;
            // 
            // lb_SectionName
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance62.BorderColor = System.Drawing.Color.RosyBrown;
            appearance62.TextVAlignAsString = "Middle";
            this.lb_SectionName.Appearance = appearance62;
            this.lb_SectionName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_SectionName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_SectionName.Location = new System.Drawing.Point(141, 131);
            this.lb_SectionName.Name = "lb_SectionName";
            this.lb_SectionName.Padding = new System.Drawing.Size(3, 0);
            this.lb_SectionName.Size = new System.Drawing.Size(164, 24);
            this.lb_SectionName.TabIndex = 104;
            this.lb_SectionName.Text = "あいうえおかきくけこ";
            this.lb_SectionName.Visible = false;
            this.lb_SectionName.WrapText = false;
            // 
            // lb_GoodsName
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance14.BorderColor = System.Drawing.Color.RosyBrown;
            appearance14.TextVAlignAsString = "Middle";
            this.lb_GoodsName.Appearance = appearance14;
            this.lb_GoodsName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_GoodsName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_GoodsName.Location = new System.Drawing.Point(107, 97);
            this.lb_GoodsName.Name = "lb_GoodsName";
            this.lb_GoodsName.Padding = new System.Drawing.Size(3, 0);
            this.lb_GoodsName.Size = new System.Drawing.Size(324, 24);
            this.lb_GoodsName.TabIndex = 103;
            this.lb_GoodsName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.lb_GoodsName.WrapText = false;
            // 
            // lb_MakerName
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance45.BorderColor = System.Drawing.Color.RosyBrown;
            appearance45.TextVAlignAsString = "Middle";
            this.lb_MakerName.Appearance = appearance45;
            this.lb_MakerName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_MakerName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_MakerName.Location = new System.Drawing.Point(651, 95);
            this.lb_MakerName.Name = "lb_MakerName";
            this.lb_MakerName.Padding = new System.Drawing.Size(3, 0);
            this.lb_MakerName.Size = new System.Drawing.Size(251, 24);
            this.lb_MakerName.TabIndex = 102;
            this.lb_MakerName.Text = "あいうえおかきくけこさしすせそ";
            this.lb_MakerName.WrapText = false;
            // 
            // tEdit_WarehouseCode
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_WarehouseCode.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.tEdit_WarehouseCode.Appearance = appearance17;
            this.tEdit_WarehouseCode.AutoSelect = true;
            this.tEdit_WarehouseCode.AutoSize = false;
            this.tEdit_WarehouseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_WarehouseCode.DataText = "1234";
            this.tEdit_WarehouseCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_WarehouseCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_WarehouseCode.Location = new System.Drawing.Point(107, 35);
            this.tEdit_WarehouseCode.MaxLength = 4;
            this.tEdit_WarehouseCode.Name = "tEdit_WarehouseCode";
            this.tEdit_WarehouseCode.Size = new System.Drawing.Size(43, 24);
            this.tEdit_WarehouseCode.TabIndex = 6;
            this.tEdit_WarehouseCode.Text = "1234";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel6.Location = new System.Drawing.Point(559, 38);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(21, 21);
            this.ultraLabel6.TabIndex = 101;
            this.ultraLabel6.Text = "～";
            // 
            // tde_ed_IoGoodsDay
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_ed_IoGoodsDay.ActiveEditAppearance = appearance18;
            this.tde_ed_IoGoodsDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_ed_IoGoodsDay.CalendarDisp = true;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.tde_ed_IoGoodsDay.EditAppearance = appearance19;
            this.tde_ed_IoGoodsDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_ed_IoGoodsDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.tde_ed_IoGoodsDay.LabelAppearance = appearance20;
            this.tde_ed_IoGoodsDay.Location = new System.Drawing.Point(602, 33);
            this.tde_ed_IoGoodsDay.Name = "tde_ed_IoGoodsDay";
            this.tde_ed_IoGoodsDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_ed_IoGoodsDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tde_ed_IoGoodsDay.Size = new System.Drawing.Size(172, 24);
            this.tde_ed_IoGoodsDay.TabIndex = 5;
            this.tde_ed_IoGoodsDay.TabStop = true;
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance21;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.tNedit_GoodsMakerCd.Appearance = appearance48;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.AutoSize = false;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "1234";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(602, 95);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 10;
            this.tNedit_GoodsMakerCd.Text = "1234";
            // 
            // tEdit_GoodsNo
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance60;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.tEdit_GoodsNo.Appearance = appearance61;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.AutoSize = false;
            this.tEdit_GoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_GoodsNo.DataText = "123456789012345678901234";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(107, 67);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(198, 24);
            this.tEdit_GoodsNo.TabIndex = 8;
            this.tEdit_GoodsNo.Text = "123456789012345678901234";
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel8.Location = new System.Drawing.Point(513, 98);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(67, 17);
            this.ultraLabel8.TabIndex = 94;
            this.ultraLabel8.Text = "メーカー";
            // 
            // ce_IoGoodsDayDiv
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ce_IoGoodsDayDiv.ActiveAppearance = appearance49;
            this.ce_IoGoodsDayDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ce_IoGoodsDayDiv.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ce_IoGoodsDayDiv.ItemAppearance = appearance26;
            valueListItem8.DataValue = -6;
            valueListItem8.DisplayText = "以前　3ヶ月";
            valueListItem9.DataValue = -5;
            valueListItem9.DisplayText = "以前　2ヶ月";
            valueListItem10.DataValue = -4;
            valueListItem10.DisplayText = "以前　1ヶ月";
            valueListItem11.DataValue = -3;
            valueListItem11.DisplayText = "以前　3週間";
            valueListItem12.DataValue = -2;
            valueListItem12.DisplayText = "以前　2週間";
            valueListItem13.DataValue = -1;
            valueListItem13.DisplayText = "以前　1週間";
            valueListItem14.DataValue = 0;
            valueListItem14.DisplayText = " ";
            valueListItem15.DataValue = 1;
            valueListItem15.DisplayText = "以降　1週間";
            valueListItem16.DataValue = 2;
            valueListItem16.DisplayText = "以降　2週間";
            valueListItem17.DataValue = 3;
            valueListItem17.DisplayText = "以降　3週間";
            valueListItem18.DataValue = 4;
            valueListItem18.DisplayText = "以降　1ヶ月";
            valueListItem19.DataValue = 5;
            valueListItem19.DisplayText = "以降　2ヶ月";
            valueListItem20.DataValue = 6;
            valueListItem20.DisplayText = "以降　3ヶ月";
            this.ce_IoGoodsDayDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem16,
            valueListItem17,
            valueListItem18,
            valueListItem19,
            valueListItem20});
            this.ce_IoGoodsDayDiv.Location = new System.Drawing.Point(780, 3);
            this.ce_IoGoodsDayDiv.MaxDropDownItems = 10;
            this.ce_IoGoodsDayDiv.Name = "ce_IoGoodsDayDiv";
            this.ce_IoGoodsDayDiv.Size = new System.Drawing.Size(152, 24);
            this.ce_IoGoodsDayDiv.TabIndex = 4;
            this.ce_IoGoodsDayDiv.SelectionChangeCommitted += new System.EventHandler(this.ce_IoGoodsDayDiv_SelectionChangeCommitted);
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel13.Location = new System.Drawing.Point(513, 8);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(67, 17);
            this.ultraLabel13.TabIndex = 89;
            this.ultraLabel13.Text = "入出荷日";
            // 
            // tde_st_IoGoodsDay
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_st_IoGoodsDay.ActiveEditAppearance = appearance27;
            this.tde_st_IoGoodsDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_st_IoGoodsDay.CalendarDisp = true;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance28.TextHAlignAsString = "Left";
            appearance28.TextVAlignAsString = "Middle";
            this.tde_st_IoGoodsDay.EditAppearance = appearance28;
            this.tde_st_IoGoodsDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_st_IoGoodsDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.tde_st_IoGoodsDay.LabelAppearance = appearance29;
            this.tde_st_IoGoodsDay.Location = new System.Drawing.Point(602, 3);
            this.tde_st_IoGoodsDay.Name = "tde_st_IoGoodsDay";
            this.tde_st_IoGoodsDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_st_IoGoodsDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tde_st_IoGoodsDay.Size = new System.Drawing.Size(172, 24);
            this.tde_st_IoGoodsDay.TabIndex = 3;
            this.tde_st_IoGoodsDay.TabStop = true;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel5.Location = new System.Drawing.Point(18, 8);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(67, 17);
            this.ultraLabel5.TabIndex = 71;
            this.ultraLabel5.Text = "伝票区分";
            // 
            // ce_SlipKindDiv
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ce_SlipKindDiv.ActiveAppearance = appearance30;
            this.ce_SlipKindDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ce_SlipKindDiv.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ce_SlipKindDiv.ItemAppearance = appearance31;
            valueListItem21.DataValue = -1;
            valueListItem21.DisplayText = "全て";
            valueListItem22.DataValue = 10;
            valueListItem22.DisplayText = "仕入";
            valueListItem23.DataValue = 20;
            valueListItem23.DisplayText = "売上";
            valueListItem24.DataValue = 30;
            valueListItem24.DisplayText = "移動出荷";
            valueListItem25.DataValue = 31;
            valueListItem25.DisplayText = "移動入荷";
            valueListItem26.DataValue = 11;
            valueListItem26.DisplayText = "入荷";
            valueListItem27.DataValue = 22;
            valueListItem27.DisplayText = "貸出";
            valueListItem28.DataValue = 13;
            valueListItem28.DisplayText = "在庫仕入";
            valueListItem29.DataValue = 42;
            valueListItem29.DisplayText = "マスタメンテ";
            valueListItem30.DataValue = 50;
            valueListItem30.DisplayText = "棚卸";
            valueListItem31.DataValue = 60;
            valueListItem31.DisplayText = "組立";
            valueListItem32.DataValue = 61;
            valueListItem32.DisplayText = "分解";
            valueListItem33.DataValue = 70;
            valueListItem33.DisplayText = "補充入庫";
            valueListItem34.DataValue = 71;
            valueListItem34.DisplayText = "補充出庫";
            this.ce_SlipKindDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem21,
            valueListItem22,
            valueListItem23,
            valueListItem24,
            valueListItem25,
            valueListItem26,
            valueListItem27,
            valueListItem28,
            valueListItem29,
            valueListItem30,
            valueListItem31,
            valueListItem32,
            valueListItem33,
            valueListItem34});
            this.ce_SlipKindDiv.Location = new System.Drawing.Point(107, 5);
            this.ce_SlipKindDiv.MaxDropDownItems = 14;
            this.ce_SlipKindDiv.Name = "ce_SlipKindDiv";
            this.ce_SlipKindDiv.Size = new System.Drawing.Size(119, 24);
            this.ce_SlipKindDiv.TabIndex = 2;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel3.Location = new System.Drawing.Point(18, 70);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(86, 20);
            this.ultraLabel3.TabIndex = 13;
            this.ultraLabel3.Text = "品番";
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance32;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance33.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.tEdit_SectionCodeAllowZero.Appearance = appearance33;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.AutoSize = false;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.DataText = "12";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(107, 131);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero.Text = "12";
            this.tEdit_SectionCodeAllowZero.Visible = false;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel1.Location = new System.Drawing.Point(18, 135);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(52, 19);
            this.ultraLabel1.TabIndex = 11;
            this.ultraLabel1.Text = "拠点";
            this.ultraLabel1.Visible = false;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel2.Location = new System.Drawing.Point(18, 38);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(67, 17);
            this.ultraLabel2.TabIndex = 12;
            this.ultraLabel2.Text = "倉庫";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_AcpOdrCount);
            this.panel3.Controls.Add(this.ultraLabel15);
            this.panel3.Controls.Add(this.lb_ShipmentPosCnt);
            this.panel3.Controls.Add(this.ultraLabel11);
            this.panel3.Controls.Add(this.lb_ShipmentCntTotal);
            this.panel3.Controls.Add(this.ultraLabel19);
            this.panel3.Controls.Add(this.lb_ArrivalCntTotal);
            this.panel3.Controls.Add(this.ultraLabel10);
            this.panel3.Controls.Add(this.lb_LMonthStockCnt);
            this.panel3.Controls.Add(this.AllMvPrice_ultraLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 241);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 32);
            this.panel3.TabIndex = 2;
            // 
            // lb_AcpOdrCount
            // 
            appearance58.TextHAlignAsString = "Right";
            appearance58.TextVAlignAsString = "Middle";
            this.lb_AcpOdrCount.Appearance = appearance58;
            this.lb_AcpOdrCount.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_AcpOdrCount.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_AcpOdrCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_AcpOdrCount.Location = new System.Drawing.Point(690, 4);
            this.lb_AcpOdrCount.Margin = new System.Windows.Forms.Padding(4);
            this.lb_AcpOdrCount.Name = "lb_AcpOdrCount";
            this.lb_AcpOdrCount.Size = new System.Drawing.Size(118, 24);
            this.lb_AcpOdrCount.TabIndex = 137;
            this.lb_AcpOdrCount.Text = "0";
            // 
            // ultraLabel15
            // 
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance80;
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel15.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel15.Location = new System.Drawing.Point(616, 4);
            this.ultraLabel15.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel15.TabIndex = 136;
            this.ultraLabel15.Text = "受注数";
            // 
            // lb_ShipmentPosCnt
            // 
            appearance56.TextHAlignAsString = "Right";
            appearance56.TextVAlignAsString = "Middle";
            this.lb_ShipmentPosCnt.Appearance = appearance56;
            this.lb_ShipmentPosCnt.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_ShipmentPosCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_ShipmentPosCnt.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_ShipmentPosCnt.Location = new System.Drawing.Point(894, 4);
            this.lb_ShipmentPosCnt.Margin = new System.Windows.Forms.Padding(4);
            this.lb_ShipmentPosCnt.Name = "lb_ShipmentPosCnt";
            this.lb_ShipmentPosCnt.Size = new System.Drawing.Size(118, 24);
            this.lb_ShipmentPosCnt.TabIndex = 135;
            this.lb_ShipmentPosCnt.Text = "0";
            // 
            // ultraLabel11
            // 
            appearance57.TextHAlignAsString = "Center";
            appearance57.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance57;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel11.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(820, 4);
            this.ultraLabel11.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel11.TabIndex = 134;
            this.ultraLabel11.Text = "現在庫数";
            // 
            // lb_ShipmentCntTotal
            // 
            appearance46.TextHAlignAsString = "Right";
            appearance46.TextVAlignAsString = "Middle";
            this.lb_ShipmentCntTotal.Appearance = appearance46;
            this.lb_ShipmentCntTotal.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_ShipmentCntTotal.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_ShipmentCntTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_ShipmentCntTotal.Location = new System.Drawing.Point(486, 4);
            this.lb_ShipmentCntTotal.Margin = new System.Windows.Forms.Padding(4);
            this.lb_ShipmentCntTotal.Name = "lb_ShipmentCntTotal";
            this.lb_ShipmentCntTotal.Size = new System.Drawing.Size(118, 24);
            this.lb_ShipmentCntTotal.TabIndex = 133;
            this.lb_ShipmentCntTotal.Text = "0";
            // 
            // ultraLabel19
            // 
            appearance47.TextHAlignAsString = "Center";
            appearance47.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance47;
            this.ultraLabel19.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel19.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel19.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel19.Location = new System.Drawing.Point(412, 4);
            this.ultraLabel19.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel19.TabIndex = 132;
            this.ultraLabel19.Text = "出庫計";
            // 
            // lb_ArrivalCntTotal
            // 
            appearance81.TextHAlignAsString = "Right";
            appearance81.TextVAlignAsString = "Middle";
            this.lb_ArrivalCntTotal.Appearance = appearance81;
            this.lb_ArrivalCntTotal.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_ArrivalCntTotal.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_ArrivalCntTotal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_ArrivalCntTotal.Location = new System.Drawing.Point(282, 4);
            this.lb_ArrivalCntTotal.Margin = new System.Windows.Forms.Padding(4);
            this.lb_ArrivalCntTotal.Name = "lb_ArrivalCntTotal";
            this.lb_ArrivalCntTotal.Size = new System.Drawing.Size(118, 24);
            this.lb_ArrivalCntTotal.TabIndex = 131;
            this.lb_ArrivalCntTotal.Text = "0";
            // 
            // ultraLabel10
            // 
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance82;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel10.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(208, 4);
            this.ultraLabel10.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel10.TabIndex = 130;
            this.ultraLabel10.Text = "入庫計";
            // 
            // lb_LMonthStockCnt
            // 
            appearance83.TextHAlignAsString = "Right";
            appearance83.TextVAlignAsString = "Middle";
            this.lb_LMonthStockCnt.Appearance = appearance83;
            this.lb_LMonthStockCnt.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_LMonthStockCnt.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_LMonthStockCnt.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_LMonthStockCnt.Location = new System.Drawing.Point(78, 4);
            this.lb_LMonthStockCnt.Margin = new System.Windows.Forms.Padding(4);
            this.lb_LMonthStockCnt.Name = "lb_LMonthStockCnt";
            this.lb_LMonthStockCnt.Size = new System.Drawing.Size(118, 24);
            this.lb_LMonthStockCnt.TabIndex = 129;
            this.lb_LMonthStockCnt.Text = "0";
            // 
            // AllMvPrice_ultraLabel
            // 
            appearance84.TextHAlignAsString = "Center";
            appearance84.TextVAlignAsString = "Middle";
            this.AllMvPrice_ultraLabel.Appearance = appearance84;
            this.AllMvPrice_ultraLabel.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.AllMvPrice_ultraLabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.AllMvPrice_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AllMvPrice_ultraLabel.Location = new System.Drawing.Point(4, 4);
            this.AllMvPrice_ultraLabel.Margin = new System.Windows.Forms.Padding(4);
            this.AllMvPrice_ultraLabel.Name = "AllMvPrice_ultraLabel";
            this.AllMvPrice_ultraLabel.Size = new System.Drawing.Size(75, 24);
            this.AllMvPrice_ultraLabel.TabIndex = 128;
            this.AllMvPrice_ultraLabel.Text = "前月末残";
            // 
            // History_Grid
            // 
            this.History_Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance68.BackColor = System.Drawing.Color.White;
            appearance68.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.History_Grid.DisplayLayout.Appearance = appearance68;
            this.History_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.History_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.History_Grid.DisplayLayout.InterBandSpacing = 10;
            this.History_Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.History_Grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance69.ForeColor = System.Drawing.Color.Black;
            this.History_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance69;
            this.History_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.History_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.History_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.History_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance70.BackColor = System.Drawing.Color.Transparent;
            this.History_Grid.DisplayLayout.Override.CardAreaAppearance = appearance70;
            this.History_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Center";
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.History_Grid.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.History_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.History_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.History_Grid.DisplayLayout.Override.RowAppearance = appearance9;
            this.History_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.History_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance71.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance71.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.History_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance71;
            this.History_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.History_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.History_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.History_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.History_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.History_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.History_Grid.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.History_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.History_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.History_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.History_Grid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both;
            this.History_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.History_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.History_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.History_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.History_Grid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.History_Grid.Location = new System.Drawing.Point(0, 273);
            this.History_Grid.Name = "History_Grid";
            this.History_Grid.Size = new System.Drawing.Size(1016, 407);
            this.History_Grid.TabIndex = 62;
            this.History_Grid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.History_Grid_InitializeLayout);
            this.History_Grid.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.History_Grid_AfterRowFilterChanged);
            this.History_Grid.AfterRowActivate += new System.EventHandler(this.History_Grid_AfterRowActivate);
            this.History_Grid.AfterPerformAction += new Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventHandler(this.History_Grid_AfterPerformAction);
            this.History_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.History_Grid_KeyDown);
            this.History_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.History_Grid_AfterSortChange);
            this.History_Grid.FilterRow += new Infragistics.Win.UltraWinGrid.FilterRowEventHandler(this.History_Grid_FilterRow);
            this.History_Grid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.History_Grid_DoubleClickRow);
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.CustomizeWrite += new Broadleaf.Library.Windows.Forms.CustomizeWriteEventHandler(this.uiMemInput1_CustomizeWrite);
            this.uiMemInput1.CustomizeRead += new Broadleaf.Library.Windows.Forms.CustomizeReadEventHandler(this.uiMemInput1_CustomizeRead);
            // 
            // MAZAI04310UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.History_Grid);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.uGroupBox_ExtractInfo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ultraToolbarsDockArea3);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this.ultraToolbarsDockArea2);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this.ultraToolbarsDockArea1);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAZAI04310UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在庫入出庫照会";
            this.Load += new System.EventHandler(this.MAZAI04310UA_Load);
            this.Closed += new System.EventHandler(this.MAZAI04310UA_Closed);
            this.Shown += new System.EventHandler(this.MAZAI04310UA_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAZAI04310UA_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).EndInit();
            this.ultraStatusBar1.ResumeLayout(false);
            this.ultraStatusBar1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGroupBox_ExtractInfo)).EndInit();
            this.uGroupBox_ExtractInfo.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ce_IoGoodsDayDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ce_SlipKindDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.History_Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        // -----DEL 2008/07/17 起動用フォームを別に作成の為 ---------------------------------------------------------------------------------------------->>>>>
        //#region Main
        ///// <summary>
        ///// アプリケーションのメイン エントリ ポイントです。
        ///// </summary>
        //[STAThread]
        //static void Main(String[] args) 
        //{
        //    System.Windows.Forms.Application.EnableVisualStyles();
        //    try
        //    {
        //        string msg = "";
        //        _parameter = args;
        //        // アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は指定。
        //        // 出来ない場合はプロダクトコード
        //        int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode,
        //            new EventHandler(ApplicationReleased));
        //        if (status == 0)
        //        {
        //            // オンライン状態判断
        //            if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
        //            {
        //                // オフライン情報
        //                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAZAI04310U", 
        //                    "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
        //            }
        //            else
        //            {
        //                _form = new MAZAI04310UA();
        //                System.Windows.Forms.Application.EnableVisualStyles();
        //                System.Windows.Forms.Application.Run(_form);
        //            }
        //        }
        //        if (status != 0)
        //        {
        //            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAZAI04310U", msg, 0, MessageBoxButtons.OK);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "MAZAI04310U", ex.Message + "\r\n" + ex.StackTrace.ToString(), 0, MessageBoxButtons.OK);
        //    }
        //    finally
        //    {
        //        ApplicationStartControl.EndApplication();
        //    }
        //}
        //#endregion
        // -----DEL 2008/07/17 起動用フォームを別に作成の為 ----------------------------------------------------------------------------------------------<<<<<
        // -----ADD 2008/07/17 起動用フォームを別に作成の為 ---------------------------------------------------------------------------------------------->>>>>
        /// <summary>
        /// 初回表示時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAZAI04310UA_Shown(object sender, EventArgs e)
        {
            //// 拠点にフォーカス
            //tEdit_SectionCodeAllowZero.Focus();           //DEL 2009/06/26 不具合対応[13625]
            // 伝票区分にフォーカス
            this.ce_SlipKindDiv.Focus();                    //ADD 2009/06/26 不具合対応[13625]
        }
        // -----ADD 2008/07/17 起動用フォームを別に作成の為 ----------------------------------------------------------------------------------------------<<<<<

		#region 強制終了event
		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
		private static void ApplicationReleased(Object sender, EventArgs e)
		{
			// メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();
			// 従業員ログオフのメッセージを表示
			if (_form != null)
			{
				TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "MAZAI04310U", e.ToString(), 0, MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAZAI04310U", e.ToString(), 0, MessageBoxButtons.OK);
			}
			// アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
		#endregion

		#region Private Event
		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバークリック時に処理します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			// ステータスバー表示印紙情報初期化
			ultraStatusBar1.Panels["StatusBarPanel_Text"].Text = statusbarStr;

			switch (e.Tool.Key)
			{
                /* -----DEL 2008/07/17 新規→クリア変更の為 --------------------->>>>>
                // 新規ボタン押下
                case "New_ButtonTool":
                {
                    this.Clear();
                    break;
                }
                   -----DEL 2008/07/17 ------------------------------------------<<<<< */
                // 終了ボタン押下
				case "End_ButtonTool":
				{
					this.Close();
					break;
				}
                // -----ADD 2008/07/17 ------------------------------------------>>>>> 
                // クリアボタン押下
                case "Clear_ButtonTool":
                {
                    this.Clear();
                    break;
                }
                // 検索ボタン押下
                case "Search_ButtonTool":
                {
                    this.SearchMain();
                    break;
                }
                // -----ADD 2008/07/17 ------------------------------------------<<<<<
                // 印刷ボタン押下
				case "Print_ButtonTool":
				{
					//PrintMain();          //DEL 2008/07/17 プレビューボタン追加の為
                    PrintMain(false);       //ADD 2008/07/17
					break;
				}
                // -----ADD 2008/07/17 ------------------------------------------>>>>> 
                // プレビュー(PDF)ボタン押下
                case "Preview_ButtonTool":
                {
                    PrintMain(true);
                    break;
                }
                // -----ADD 2008/07/17 ------------------------------------------<<<<<
                // テキスト出力ボタン押下   ※使用していない？
                case "TextOut_ButtonTool":
                {
                    TextOutMain();
                    break;
                }
            }
		}

		/// <summary>
		/// ツールバーValueChangeイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの値が変更された時に処理します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			// 拠点情報
			Infragistics.Win.UltraWinToolbars.ComboBoxTool SectionCombo = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
		}

		/// <summary>
		/// Formロードイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : Formロード時に処理します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
        /// <br>Update Note: 2009/12/04 李侠</br>
        /// <br>             PM.NS-4・保守依頼③の列サイズの自動調整の不具合対応</br>
        /// <br>Update Note: 2010/11/15 李占川</br>
        /// <br>             絞込条件を非表示へ変更可能に変更</br>
		/// </remarks>
		private void MAZAI04310UA_Load(object sender, System.EventArgs e)
		{
            try
            {
                // --- ADD 2010/11/15 ---------->>>>>
                List<string> excCtrlNm = new List<string>();
                excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
                this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
                // --- ADD 2010/11/15  ----------<<<<<

                this._controlScreenSkin.LoadSkin();

                // 画面スキン変更
                this._controlScreenSkin.SettingScreenSkin(this);

                // ガイドボタンイメージ設定
                this.ub_MakerGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                this.ub_GoodsGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                this.ub_SectionGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.CarrierEp_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this.ub_WarehouseGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                //this.ub_Search.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];    //DEL 2008/07/17 検索ボタン削除(ツールバーへ移動)の為
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 締日算出モジュール
                _totalDayCalculator = TotalDayCalculator.GetInstance();         //ADD 2008/11/17

                //履歴画面情報を読込み
/*
                MainWkHisFormInfo info = null;
                info = MainWkHisFormInfo_Load(ctFileNm);

				this.History_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

                // グリッド情報取得
				if (_gridStateController.LoadGridState(ctGridInfoFileNm) == 0)
				{
					// フォントサイズ
					this.FontSize_tComboEditor.Value
						= (int)_gridStateController.GetGridStateInfo(ref this.History_Grid).FontSize;
					// 列サイズの自動調整
//					this.AutoFitCol_ultraCheckEditor.Checked
//						= _gridStateController.GetGridStateInfo(ref this.History_Grid).AutoFit;
                    this.AutoFitCol_ultraCheckEditor.Checked = false;
				}
				else
				{
					// フォントサイズ
					this.FontSize_tComboEditor.Value = 11;
					// 列サイズの自動調整
                    this.AutoFitCol_ultraCheckEditor.Checked = false;
				}
 */
                // --- ADD 2009/12/04 ---------->>>>>
                MainWkHisFormInfo info = null;
                info = MainWkHisFormInfo_Load(ctFileNm);

                if (info.SearchCheckEditor == true)
                {
                    //列サイズの自動調整
                    this.AutoFitCol_ultraCheckEditor.Checked = true;
                }
                else
                {
                    //列サイズの自動調整
                    this.AutoFitCol_ultraCheckEditor.Checked = false;
                }
                // --- ADD 2009/12/04 ----------<<<<<

                // フォントサイズ
                this.FontSize_tComboEditor.Value = 11;

                // --- DEL 2009/12/04 ---------->>>>>
                //// 列サイズの自動調整
                //this.AutoFitCol_ultraCheckEditor.Checked = false;
                // --- DEL 2009/12/04 ----------<<<<<

                // 画面初期化
                AllDispClear(false);

                this.ub_GoodsGuide.Visible = false;     //ADD 2008/09/29 仕様変更

                // --- ADD 2010/11/15 ---------->>>>>
                _MAZAI04310ub = new MAZAI04310UB();
                _MAZAI04310ub.tde_st_IoGoodsDay = this.tde_st_IoGoodsDay.GetLongDate(); //入出荷日
                _MAZAI04310ub.tde_ed_IoGoodsDay = (int)this.tde_ed_IoGoodsDay.GetLongDate();
                _MAZAI04310ub.AcPaySlipCd = (int)this.ce_SlipKindDiv.Value;    //伝票区分(選択INDEX)  
                _MAZAI04310ub.WareHouse = this.tEdit_WarehouseCode.Text.PadLeft(4, '0'); //倉庫コード    //ADD 2009/01/14 不具合対応[9800]
                _MAZAI04310ub.MakerCode = this.tNedit_GoodsMakerCd.GetInt();//メーカー
                _MAZAI04310ub.GoodsCd = this.tEdit_GoodsNo.Text;//商品コード
                // --- ADD 2010/11/15  ----------<<<<<
            }
			finally
			{
                // ときどきツールバーが消えるので、リフレッシュ
                this.Refresh();
			}
		}


		/// <summary>
		/// Formクローズイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : Formクローズ時に処理します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void MAZAI04310UA_Closed(object sender, System.EventArgs e)
		{
            //履歴画面情報を保存します。
            MainWkHisFormInfo_Save(ctFileNm);
		}

		#region GridInitialize
		/// <summary>
		/// 履歴グリッドInitializeLayoutイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : 履歴グリッド初期化時に処理します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
        /// <br>Update Note: 2009/12/04 李侠</br>
        /// <br>             PM.NS-4・保守依頼③の受払履歴作成日付を追加する</br>
        /// <br>Update Note: 2010/11/15 李占川</br>
        /// <br>             明細の表示順が受払作成日時の昇順になっていない障害の修正</br>
        /// <br>Update Note: 2010/11/15 施ヘイ中</br>
        /// <br>             明細タイトルを「仕入先／得意先」から「仕入先／得意先／相手倉庫」へ変更する。</br>
		/// </remarks>
		private void History_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// 該当のグリッドコントロール取得
			UltraGrid grids = (UltraGrid)sender;

			// 『固定列』プッシュピンアイコンを消す
			e.Layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// 固定ヘッダー機能を有効にする
			grids.DisplayLayout.UseFixedHeaders = true;
            
			// 行サイズを設定
			grids.DisplayLayout.Override.DefaultRowHeight = 24;
            grids.DisplayLayout.Override.FixedCellSeparatorColor = Color.Black;
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
			//ColumnsCollection Columns = grids.DisplayLayout.Bands[TBL_HISTORY].Columns;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

/////grid設定 >>>>>

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Columns[COL_ROWNUM].Header.Caption = "No";
            //Columns[COL_ROWNUM].Width = 50;
            //Columns[COL_ROWNUM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[COL_ROWNUM].CellActivation = Activation.NoEdit;
            //Columns[COL_ROWNUM].Hidden = true;

            //// 入出荷日
            //Columns[COL_tde_st_IoGoodsDay].Header.Caption = "入出荷日";
            //Columns[COL_tde_st_IoGoodsDay].Width = 80;
            //Columns[COL_tde_st_IoGoodsDay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_tde_st_IoGoodsDay].CellActivation = Activation.NoEdit;
            //Columns[COL_tde_st_IoGoodsDay].Format = "yyyy/MM/dd";

            //// 伝票区分
            //Columns[COL_SLIPCD].Header.Caption = "伝票区分";
            //Columns[COL_SLIPCD].Width = 80;
            //Columns[COL_SLIPCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_SLIPCD].CellActivation = Activation.NoEdit;
            //if (ce_SlipKindDiv.SelectedIndex != 0)
            //{
            //    Columns[COL_SLIPCD].Hidden = true;
            //}
            //else
            //{
            //    Columns[COL_SLIPCD].Hidden = false;
            //}

            //// 取引区分
            //Columns[COL_TRANSDIV].Header.Caption = "取引区分";
            //Columns[COL_TRANSDIV].Width = 80;
            //Columns[COL_TRANSDIV].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_TRANSDIV].CellActivation = Activation.NoEdit;
            //Columns[COL_TRANSDIV].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //// 商品コード
            //Columns[COL_GOODSCODE].Header.Caption = "商品コード";
            //Columns[COL_GOODSCODE].Width = 150;
            //Columns[COL_GOODSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_GOODSCODE].CellActivation = Activation.NoEdit;
            //if (!String.IsNullOrEmpty(te_GoodsNo.Text.Trim()))
            //{
            //    Columns[COL_GOODSCODE].Hidden = true;
            //}
            //else
            //{
            //    Columns[COL_GOODSCODE].Hidden = false;
            //}

            //// 商品名称
            //Columns[COL_GOODSNM].Header.Caption = "商品名称";
            //Columns[COL_GOODSNM].Width = 200;
            //Columns[COL_GOODSNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_GOODSNM].CellActivation = Activation.NoEdit;

            //// 入荷数
            //Columns[COL_ARRIVALGOODSCNT].Header.Caption = "入荷数";
            //Columns[COL_ARRIVALGOODSCNT].Width = 80;
            //Columns[COL_ARRIVALGOODSCNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[COL_ARRIVALGOODSCNT].CellActivation = Activation.NoEdit;
            //Columns[COL_ARRIVALGOODSCNT].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //// 出荷数
            //Columns[COL_SHIPMCNT].Header.Caption = "出荷数";
            //Columns[COL_SHIPMCNT].Width = 80;
            //Columns[COL_SHIPMCNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[COL_SHIPMCNT].CellActivation = Activation.NoEdit;
            //Columns[COL_SHIPMCNT].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //// 拠点名称
            //Columns[COL_SECTIONNAME].Header.Caption = "拠点";
            //Columns[COL_SECTIONNAME].Width = 150;
            //Columns[COL_SECTIONNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_SECTIONNAME].CellActivation = Activation.NoEdit;
            //if (!String.IsNullOrEmpty(te_SectionCode.Text.Trim()))
            //{
            //    Columns[COL_SECTIONNAME].Hidden = true;
            //}
            //else
            //{
            //    Columns[COL_SECTIONNAME].Hidden = false;
            //}
            //// 受払先
            //Columns[COL_RECVPYEECUST].Header.Caption = "受払先";
            //Columns[COL_RECVPYEECUST].Width = 150;
            //Columns[COL_RECVPYEECUST].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_RECVPYEECUST].CellActivation = Activation.NoEdit;

            //// 移動元拠点
            //Columns[COL_BFSECTIONGUIDENM].Header.Caption = "移動元拠点";
            //Columns[COL_BFSECTIONGUIDENM].Width = 150;
            //Columns[COL_BFSECTIONGUIDENM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_BFSECTIONGUIDENM].CellActivation = Activation.NoEdit;
            //// 移動元倉庫
            //Columns[COL_BFENTERWAREHNAME].Header.Caption = "移動元倉庫";
            //Columns[COL_BFENTERWAREHNAME].Width = 150;
            //Columns[COL_BFENTERWAREHNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_BFENTERWAREHNAME].CellActivation = Activation.NoEdit;
            //// 移動先拠点
            //Columns[COL_AFSECTIONGUIDENM].Header.Caption = "移動先拠点";
            //Columns[COL_AFSECTIONGUIDENM].Width = 150;
            //Columns[COL_AFSECTIONGUIDENM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_AFSECTIONGUIDENM].CellActivation = Activation.NoEdit;
            //// 移動先倉庫
            //Columns[COL_AFENTERWAREHNAME].Header.Caption = "移動先倉庫";
            //Columns[COL_AFENTERWAREHNAME].Width = 150;
            //Columns[COL_AFENTERWAREHNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_AFENTERWAREHNAME].CellActivation = Activation.NoEdit;

            //// 在庫数
            //Columns[COL_STOCKCNT].Header.Caption = "在庫数";
            //Columns[COL_STOCKCNT].Width = 150;
            //Columns[COL_STOCKCNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[COL_STOCKCNT].CellActivation = Activation.NoEdit;
            //Columns[COL_STOCKCNT].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //// 伝票番号
            //Columns[COL_SLIPNO].Header.Caption = "伝票番号";
            //Columns[COL_SLIPNO].Width = 150;
            //Columns[COL_SLIPNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_SLIPNO].CellActivation = Activation.NoEdit;

            //// 備考
            //Columns[COL_ACPAYNOTE].Header.Caption = "備考";
            //Columns[COL_ACPAYNOTE].Width = 400;
            //Columns[COL_ACPAYNOTE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_ACPAYNOTE].CellActivation = Activation.NoEdit;

            //// 機種
            //Columns[COL_MODEL].Header.Caption = "機種";
            //Columns[COL_MODEL].Width = 300;
            //Columns[COL_MODEL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[COL_MODEL].CellActivation = Activation.NoEdit;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////製番有無によってGrid表示変更
            //if (this.ProductNo_Edit.Text.Trim() != "")
            //{
            //    // 事業者
            //    Columns[COL_CARRIEREP].Header.Caption = "事業者";
            //    Columns[COL_CARRIEREP].Width = 200;
            //    Columns[COL_CARRIEREP].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    Columns[COL_CARRIEREP].CellActivation = Activation.NoEdit;

            //    // 製造番号
            //    Columns[COL_PRODUCTNO].Header.Caption = "製造番号";
            //    Columns[COL_PRODUCTNO].Width = 200;
            //    Columns[COL_PRODUCTNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    Columns[COL_PRODUCTNO].CellActivation = Activation.NoEdit;
            //    Columns[COL_PRODUCTNO].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //    // SIM製造番号
            //    Columns[COL_SIMPRODUCENO].Header.Caption = "SIM製造番号";
            //    Columns[COL_SIMPRODUCENO].Width = 200;
            //    Columns[COL_SIMPRODUCENO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    Columns[COL_SIMPRODUCENO].CellActivation = Activation.NoEdit;
            //    Columns[COL_SIMPRODUCENO].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //    // 携帯番号
            //    Columns[COL_CPHONENO].Header.Caption = "携帯番号";
            //    Columns[COL_CPHONENO].Width = 200;
            //    Columns[COL_CPHONENO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    Columns[COL_CPHONENO].CellActivation = Activation.NoEdit;
            //    Columns[COL_CPHONENO].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            int visiblePosition = 0;

            string dateFormat = "yyyy/MM/dd";
            string dateTimeFormat = "yyyy/MM/dd H:mm:ss"; // ADD 2010/11/15
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string priceFormat = "#,##0;-#,##0;";

            ColumnsCollection Columns = grids.DisplayLayout.Bands[MAZAI04311EC.ct_Tbl_StockAcPayRef].Columns;

            // 行番号
            Columns[MAZAI04311EC.ct_Col_RowNo].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_RowNo].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_RowNo].Header.Caption = "行番号";
            Columns[MAZAI04311EC.ct_Col_RowNo].Width = 100;
            Columns[MAZAI04311EC.ct_Col_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_RowNo].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_RowNo].Header.VisiblePosition = visiblePosition++;

            // 入出荷日
            Columns[MAZAI04311EC.ct_Col_IoGoodsDay].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_IoGoodsDay].Header.Caption = "入出荷日";
            Columns[MAZAI04311EC.ct_Col_IoGoodsDay].Width = 100;
            Columns[MAZAI04311EC.ct_Col_IoGoodsDay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_IoGoodsDay].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_IoGoodsDay].Format = dateFormat;
            Columns[MAZAI04311EC.ct_Col_IoGoodsDay].Header.VisiblePosition = visiblePosition++;

            /* -----DEL 2008/07/17 初期表示時の列順変更の為 ---------------------------------------------------------->>>>>
            // 受払元伝票番号
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Header.Caption = "伝票番号";
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Width = 200;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Header.VisiblePosition = visiblePosition++;
               -----DEL 2008/07/17 -----------------------------------------------------------------------------------<<<<< */

            // 受払元行番号
            Columns[MAZAI04311EC.ct_Col_AcPaySlipRowNo].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipRowNo].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipRowNo].Header.Caption = "行番号";
            Columns[MAZAI04311EC.ct_Col_AcPaySlipRowNo].Width = 100;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipRowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipRowNo].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipRowNo].Header.VisiblePosition = visiblePosition++;

            // 受払元伝票区分
            Columns[MAZAI04311EC.ct_Col_AcPaySlipCd].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipCd].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipCd].Header.Caption = "受払元伝票区分";
            Columns[MAZAI04311EC.ct_Col_AcPaySlipCd].Width = 100;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipCd].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipCd].Header.VisiblePosition = visiblePosition++;

            // 受払元伝票区分（名称）
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNm].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNm].Header.Caption = "伝票区分";
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNm].Width = 100;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNm].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNm].Header.VisiblePosition = visiblePosition++;

            // 受払元取引区分
            Columns[MAZAI04311EC.ct_Col_AcPayTransCd].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_AcPayTransCd].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_AcPayTransCd].Header.Caption = "受払元取引区分";
            Columns[MAZAI04311EC.ct_Col_AcPayTransCd].Width = 100;
            Columns[MAZAI04311EC.ct_Col_AcPayTransCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_AcPayTransCd].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPayTransCd].Header.VisiblePosition = visiblePosition++;

            // 受払元取引区分（名称）
            Columns[MAZAI04311EC.ct_Col_AcPayTransNm].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_AcPayTransNm].Header.Caption = "取引区分";
            Columns[MAZAI04311EC.ct_Col_AcPayTransNm].Width = 100;
            Columns[MAZAI04311EC.ct_Col_AcPayTransNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_AcPayTransNm].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPayTransNm].Header.VisiblePosition = visiblePosition++;

            // --- DEL 2009/12/04 ---------->>>>>
            //// 受払履歴作成日時
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Hidden = true;
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Header.Fixed = true;
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Header.Caption = "受払履歴作成日時";
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Width = 100;
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].CellActivation = Activation.NoEdit;
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Format = dateFormat;
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/12/04 ----------<<<<<

            // -----ADD 2008/07/17 ----------------------------------------------------------------------------------->>>>>
            // 受払元伝票番号
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Header.Fixed = true;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Header.Caption = "伝票番号";
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Width = 200;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPaySlipNum].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/07/17 -----------------------------------------------------------------------------------<<<<<

            // 明細通番
            Columns[MAZAI04311EC.ct_Col_SlipDtlNum].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_SlipDtlNum].Header.Caption = "明細通番";
            Columns[MAZAI04311EC.ct_Col_SlipDtlNum].Width = 100;
            Columns[MAZAI04311EC.ct_Col_SlipDtlNum].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_SlipDtlNum].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_SlipDtlNum].Header.VisiblePosition = visiblePosition++;

            // 受払先名称
            ////Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].Header.Caption = "受払先名称";     //DEL 2008/07/17 文言変更の為
            //Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].Header.Caption = "入出庫先名";       //ADD 2008/07/17 → DEL 2008/09/29 仕様変更
            // --- UPD 2010/11/15------ <<<<<<<
            //Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].Header.Caption = "仕入先／得意先";       //ADD 2008/09/29
            //Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].Width = 200;
            Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].Header.Caption = "仕入先／得意先／相手倉庫";       
            Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].Width = 240;
            // --- UPD 2010/11/15------ <<<<<<<               
            Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPayOtherPartyNm].Header.VisiblePosition = visiblePosition++;

            // -----ADD 2008/07/17 ----------------------------------------------------------------------------------->>>>>
            // 定価（税抜，浮動）
            //Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Header.Caption = "定価";       //DEL 2008/07/17 文言変更の為
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Header.Caption = "標準価格";     //ADD 2008/07/17
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/07/17 -----------------------------------------------------------------------------------<<<<<

            // 入荷数
            //Columns[MAZAI04311EC.ct_Col_ArrivalCnt].Header.Caption = "受入数";            //DEL 2008/07/17 文言変更の為
            Columns[MAZAI04311EC.ct_Col_ArrivalCnt].Header.Caption = "入庫数";              //ADD 2008/07/17
            Columns[MAZAI04311EC.ct_Col_ArrivalCnt].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ArrivalCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ArrivalCnt].CellActivation = Activation.NoEdit;
            //Columns[MAZAI04311EC.ct_Col_ArrivalCnt].Format = decimalFormat;               //DEL 2008/09/29 仕様変更
            Columns[MAZAI04311EC.ct_Col_ArrivalCnt].Header.VisiblePosition = visiblePosition++;

            // -----ADD 2008/07/17 ----------------------------------------------------------------------------------->>>>>
            // 仕入単価（税抜，浮動）
            ////Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Header.Caption = "仕入単価";    //DEL 2008/07/17 文言変更の為
            //Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Header.Caption = "原単価";        //ADD 2008/07/17 → DEL 2008/09/29 仕様変更
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Header.Caption = "入庫単価";        //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Width = 100;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Header.VisiblePosition = visiblePosition++;

            // 仕入金額
            Columns[MAZAI04311EC.ct_Col_StockPrice].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_StockPrice].Header.Caption = "仕入金額";
            Columns[MAZAI04311EC.ct_Col_StockPrice].Width = 100;
            Columns[MAZAI04311EC.ct_Col_StockPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_StockPrice].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_StockPrice].Format = priceFormat;
            Columns[MAZAI04311EC.ct_Col_StockPrice].Header.VisiblePosition = visiblePosition++;

            // 入庫金額（仕入金額を表示）
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Header.Caption = "入庫金額";
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Format = priceFormat;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/07/17 -----------------------------------------------------------------------------------<<<<<

            // 出荷数
            //Columns[MAZAI04311EC.ct_Col_ShipmentCnt].Header.Caption = "払出数";       //DEL 2008/07/17 文言変更の為
            Columns[MAZAI04311EC.ct_Col_ShipmentCnt].Header.Caption = "出庫数";         //ADD 2008/07/17
            Columns[MAZAI04311EC.ct_Col_ShipmentCnt].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ShipmentCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ShipmentCnt].CellActivation = Activation.NoEdit;
            //Columns[MAZAI04311EC.ct_Col_ShipmentCnt].Format = decimalFormat;          //DEL 2008/09/29 仕様変更
            Columns[MAZAI04311EC.ct_Col_ShipmentCnt].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/09/29 ----------------------------------------------------------------------------------->>>>>
            // 出庫単価（売上単価(税抜,浮動)を表示）
            Columns[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl].Header.Caption = "出庫単価";
            Columns[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl].Width = 100;
            Columns[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/09/29 -----------------------------------------------------------------------------------<<<<<
            // 出庫金額（仕入金額を表示）
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Header.Caption = "出庫金額";
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Format = priceFormat;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Header.VisiblePosition = visiblePosition++;

            // 繰越数
            Columns[MAZAI04311EC.ct_Col_CarryForwardCnt].Header.Caption = "繰越数";
            Columns[MAZAI04311EC.ct_Col_CarryForwardCnt].Width = 100;
            Columns[MAZAI04311EC.ct_Col_CarryForwardCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_CarryForwardCnt].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_CarryForwardCnt].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_CarryForwardCnt].Header.VisiblePosition = visiblePosition++;

            // 入力担当者コード
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Header.Caption = "入力担当者コード";
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Width = 200;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Header.VisiblePosition = visiblePosition++;

            // 入力担当者名称
            //Columns[MAZAI04311EC.ct_Col_InputAgenNm].Header.Caption = "入力担当者";       //DEL 2008/09/29 仕様変更
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].Header.Caption = "担当者";         //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].Width = 200;
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/07/17 -----------------------------------------------------------------------------------<<<<<

            // 拠点コード
            Columns[MAZAI04311EC.ct_Col_SectionCode].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_SectionCode].Header.Caption = "拠点コード";
            Columns[MAZAI04311EC.ct_Col_SectionCode].Width = 200;
            Columns[MAZAI04311EC.ct_Col_SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_SectionCode].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_SectionCode].Header.VisiblePosition = visiblePosition++;

            /* -----DEL 2008/09/29 仕様変更--------------------------------------------------------------------------->>>>>
            // 拠点ガイド名称
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].Header.Caption = "拠点名称";
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].Width = 200;
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].Header.VisiblePosition = visiblePosition++;
               -----DEL 2008/09/29 -----------------------------------------------------------------------------------<<<<< */

            // 倉庫コード
            Columns[MAZAI04311EC.ct_Col_WarehouseCode].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_WarehouseCode].Header.Caption = "倉庫コード";
            Columns[MAZAI04311EC.ct_Col_WarehouseCode].Width = 200;
            Columns[MAZAI04311EC.ct_Col_WarehouseCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_WarehouseCode].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_WarehouseCode].Header.VisiblePosition = visiblePosition++;

            // 倉庫名称
            Columns[MAZAI04311EC.ct_Col_WarehouseName].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_WarehouseName].Header.Caption = "倉庫名称";
            Columns[MAZAI04311EC.ct_Col_WarehouseName].Width = 200;
            Columns[MAZAI04311EC.ct_Col_WarehouseName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_WarehouseName].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_WarehouseName].Header.VisiblePosition = visiblePosition++;

            // 棚番
            Columns[MAZAI04311EC.ct_Col_ShelfNo].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_ShelfNo].Header.Caption = "棚番";
            Columns[MAZAI04311EC.ct_Col_ShelfNo].Width = 200;
            Columns[MAZAI04311EC.ct_Col_ShelfNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_ShelfNo].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ShelfNo].Header.VisiblePosition = visiblePosition++;

            /* -----DEL 2008/07/17 初期表示時の列順変更の為 ---------------------------------------------------------->>>>>
            // 定価（税抜，浮動）
            //Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Header.Caption = "定価";       //DEL 2008/07/17 文言変更の為
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Header.Caption = "標準価格";     //ADD 2008/07/17
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_ListPriceTaxExcFl].Header.VisiblePosition = visiblePosition++;

            // 仕入単価（税抜，浮動）
            //Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Header.Caption = "仕入単価";    //DEL 2008/07/17 文言変更の為
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Header.Caption = "原単価";        //ADD 2008/07/17
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Width = 100;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_StockUnitPriceFl].Header.VisiblePosition = visiblePosition++;

            // 仕入金額
            Columns[MAZAI04311EC.ct_Col_StockPrice].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_StockPrice].Header.Caption = "仕入金額";
            Columns[MAZAI04311EC.ct_Col_StockPrice].Width = 100;
            Columns[MAZAI04311EC.ct_Col_StockPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_StockPrice].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_StockPrice].Format = priceFormat;
            Columns[MAZAI04311EC.ct_Col_StockPrice].Header.VisiblePosition = visiblePosition++;

            // 入庫金額（仕入金額を表示）
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Header.Caption = "入庫金額";
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Format = priceFormat;
            Columns[MAZAI04311EC.ct_Col_ArrivalPrice].Header.VisiblePosition = visiblePosition++;

            // 出庫金額（仕入金額を表示）
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Header.Caption = "出庫金額";
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Format = priceFormat;
            Columns[MAZAI04311EC.ct_Col_ShipmentPrice].Header.VisiblePosition = visiblePosition++;
               -----DEL 2008/07/17 -----------------------------------------------------------------------------------<<<<< */

            // 仕入在庫数
            Columns[MAZAI04311EC.ct_Col_SupplierStock].Hidden = true;                   //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_SupplierStock].Header.Caption = "仕入在庫数";
            Columns[MAZAI04311EC.ct_Col_SupplierStock].Width = 100;
            Columns[MAZAI04311EC.ct_Col_SupplierStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_SupplierStock].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_SupplierStock].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_SupplierStock].Header.VisiblePosition = visiblePosition++;

            // 受注数
            Columns[MAZAI04311EC.ct_Col_AcpOdrCount].Hidden = true;                     //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_AcpOdrCount].Header.Caption = "受注数";
            Columns[MAZAI04311EC.ct_Col_AcpOdrCount].Width = 100;
            Columns[MAZAI04311EC.ct_Col_AcpOdrCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_AcpOdrCount].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcpOdrCount].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_AcpOdrCount].Header.VisiblePosition = visiblePosition++;

            // 発注数
            Columns[MAZAI04311EC.ct_Col_SalesOrderCount].Hidden = true;                 //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_SalesOrderCount].Header.Caption = "発注数";
            Columns[MAZAI04311EC.ct_Col_SalesOrderCount].Width = 100;
            Columns[MAZAI04311EC.ct_Col_SalesOrderCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_SalesOrderCount].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_SalesOrderCount].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_SalesOrderCount].Header.VisiblePosition = visiblePosition++;

            // 移動中仕入在庫数
            Columns[MAZAI04311EC.ct_Col_MovingSupliStock].Hidden = true;                //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_MovingSupliStock].Header.Caption = "移動数";
            Columns[MAZAI04311EC.ct_Col_MovingSupliStock].Width = 100;
            Columns[MAZAI04311EC.ct_Col_MovingSupliStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_MovingSupliStock].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_MovingSupliStock].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_MovingSupliStock].Header.VisiblePosition = visiblePosition++;

            // 出荷数（未計上）
            // 2009.03.18 30413 犬飼 未計上出荷数を未計上貸出数に変更 >>>>>>START
            //Columns[MAZAI04311EC.ct_Col_NonAddUpShipmCnt].Header.Caption = "未計上出荷数";
            Columns[MAZAI04311EC.ct_Col_NonAddUpShipmCnt].Header.Caption = "未計上貸出数";
            // 2009.03.18 30413 犬飼 未計上出荷数を未計上貸出数に変更 <<<<<<END
            Columns[MAZAI04311EC.ct_Col_NonAddUpShipmCnt].Width = 100;
            Columns[MAZAI04311EC.ct_Col_NonAddUpShipmCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_NonAddUpShipmCnt].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_NonAddUpShipmCnt].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_NonAddUpShipmCnt].Header.VisiblePosition = visiblePosition++;

            // 入荷数（未計上）
            Columns[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt].Header.Caption = "未計上入荷数";
            Columns[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt].Width = 100;
            Columns[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt].Header.VisiblePosition = visiblePosition++;

            // 出荷可能数
            Columns[MAZAI04311EC.ct_Col_ShipmentPosCnt].Hidden = true;                  //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_ShipmentPosCnt].Header.Caption = "出荷可能数";
            Columns[MAZAI04311EC.ct_Col_ShipmentPosCnt].Width = 100;
            Columns[MAZAI04311EC.ct_Col_ShipmentPosCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[MAZAI04311EC.ct_Col_ShipmentPosCnt].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_ShipmentPosCnt].Format = decimalFormat;
            Columns[MAZAI04311EC.ct_Col_ShipmentPosCnt].Header.VisiblePosition = visiblePosition++;

            // 相手先伝票番号
            Columns[MAZAI04311EC.ct_Col_CustSlipNo].Hidden = true;                      //ADD 2008/09/29
            Columns[MAZAI04311EC.ct_Col_CustSlipNo].Header.Caption = "相手先伝票番号";
            Columns[MAZAI04311EC.ct_Col_CustSlipNo].Width = 200;
            Columns[MAZAI04311EC.ct_Col_CustSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_CustSlipNo].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_CustSlipNo].Header.VisiblePosition = visiblePosition++;

            /* -----DEL 2008/07/17 初期表示時の列順変更の為 ---------------------------------------------------------->>>>>
            // 入力担当者コード
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Header.Caption = "入力担当者コード";
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Width = 200;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_InputAgenCd].Header.VisiblePosition = visiblePosition++;

            // 入力担当者名称
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].Header.Caption = "入力担当者";
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].Width = 200;
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_InputAgenNm].Header.VisiblePosition = visiblePosition++;
               -----DEL 2008/07/17 -----------------------------------------------------------------------------------<<<<< */
            // 受払備考
            Columns[MAZAI04311EC.ct_Col_AcPayNote].Hidden = true;                       //ADD 2008/09/29
            //Columns[MAZAI04311EC.ct_Col_AcPayNote].Header.Caption = "受払備考";       //DEL 2008/07/17 文言変更の為
            Columns[MAZAI04311EC.ct_Col_AcPayNote].Header.Caption = "入出庫備考";       //ADD 2008/07/17
            Columns[MAZAI04311EC.ct_Col_AcPayNote].Width = 200;
            Columns[MAZAI04311EC.ct_Col_AcPayNote].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_AcPayNote].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_AcPayNote].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/09/29 ----------------------------------------------------------------------------------->>>>>
            // 拠点ガイド名称
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].Header.Caption = "拠点名";
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].Width = 200;
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_SectionGuideNm].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/09/29 -----------------------------------------------------------------------------------<<<<<
            // --- ADD 2009/12/04 ---------->>>>>
            // 受払履歴作成日時
            Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Header.Caption = "作成日時";
            Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Width = 200;
            Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].CellActivation = Activation.NoEdit;
            // --- UPD 2010/11/15 ---------->>>>>
            //Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Format = dateFormat;
            Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Format = dateTimeFormat;
            // --- UPD 2010/11/15  ----------<<<<<
            Columns[MAZAI04311EC.ct_Col_AcPayHistDateTime].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/12/04 ----------<<<<<
            // -----ADD 2008/12/09 不具合対応[8895]------------------------------------------------------------------->>>>>
            // 品番(ソート用、非表示)
            Columns[MAZAI04311EC.ct_Col_GoodsNo].Header.Caption = "品番";
            Columns[MAZAI04311EC.ct_Col_GoodsNo].Hidden = true;
            Columns[MAZAI04311EC.ct_Col_GoodsNo].Width = 10;
            Columns[MAZAI04311EC.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[MAZAI04311EC.ct_Col_GoodsNo].CellActivation = Activation.NoEdit;
            Columns[MAZAI04311EC.ct_Col_GoodsNo].Header.VisiblePosition = visiblePosition++;
            // -----ADD 2008/09/29 不具合対応[8895]-------------------------------------------------------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

/////grid設定 <<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.SettingGridColVisible(0);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private void SettingGridColVisible(int value)
        //{
        //    // すべての列の表示非表示設定
        //    Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.History_Grid.DisplayLayout.Bands[0];
        //    if ( editBand == null ) return;


        //    // 指定行の全ての列に対して設定を行う。
        //    foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns )
        //    {
        //        if ( col.Key == COL_GOODSCODE )
        //        {
        //            if ( !String.IsNullOrEmpty( te_GoodsNo.Text.Trim() ) )
        //            {
        //                col.Hidden = true;
        //            }
        //            else
        //            {
        //                col.Hidden = false;
        //            }
        //        }
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		#endregion

        /// <summary>
        /// 履歴グリッド／InitializeRow イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 19077 渡邉 貴裕</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        private void History_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }


		#region ArrowKeyChangeFocus
		/// <summary>
		/// ArrowKey チェンジフォーカスイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォーカス遷移が行われた時に処理します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
        /// <br>Update Note: 2010/11/15 李占川</br>
        /// <br>             フォーカス遷移の変更</br>
        /// <br>Update Note: 2015/03/27 時シン</br>
        /// <br>管理番号   : 11070263-00　Seiken品番変更</br>
        /// <br>           : 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // 例外判定
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

            //-----------------------------------------------------
            // 次項目がグリッドの場合、フォーカス制御
            //-----------------------------------------------------
            if ( e.NextCtrl == this.History_Grid )
            {
                // Shift同時押下は除外
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                // --- UPD 2010/11/15 ---------->>>>>
                                //if ( this.History_Grid.Rows.Count == 0 )
                                //{
                                //    // データが無い→移動しない
                                //    e.NextCtrl = e.PrevCtrl;
                                //}
                                //else
                                //{
                                //    // データあり
                                //}

                                // 絞込条件を変更した場合
                                if (this.SearchParaChange())
                                {
                                    e.NextCtrl = null;
                                    // 検索処理を実行する
                                    this.SearchMain();
                                }
                                else
                                {
                                    if (this.History_Grid.Rows.Count > 0)
                                    {
                                        // グリットへフォーカス移動
                                        e.NextCtrl = this.History_Grid;
                                        this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                                        this.History_Grid.Rows[0].Selected = true;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.ce_SlipKindDiv;
                                    }
                                }
                                break;
                                // --- UPD 2010/11/15  ----------<<<<<
                            }

                    }
                }
            }
            /* // -----DEL 2008/07/17 ----------------------------------------------------------------------------->>>>>

                        //-----------------------------------------------------
                        // 前項目従い処理
                        //-----------------------------------------------------
                        int status = 0;
                        bool readed = false;

                        if ( e.PrevCtrl == this.tNedit_GoodsMakerCd )
                        {
                            // メーカーコード
                            status = ReadMaker();
                            readed = true;
                        }
                        else if ( e.PrevCtrl == this.tEdit_GoodsNo )
                        {
                            // 商品番号
                            status = ReadGoods();
                            // -----ADD 2008/07/17 ----------------------------->>>>>
                            if (status == -1)
                            {
                                return;
                            }
                            // -----ADD 2008/07/17 -----------------------------<<<<<
                            readed = true;
                        }
                        else if ( e.PrevCtrl == this.tEdit_SectionCode )
                        {
                            // 拠点コード
                            status = ReadSection();
                            readed = true;
                        }
                        else if ( e.PrevCtrl == this.tEdit_WarehouseCode )
                        {
                            // 倉庫コード
                            status = ReadWarehouse();
                            readed = true;
                        }
                        // -----ADD 2008/07/17 ----------------------------->>>>>
                        if (( e.PrevCtrl == this.tEdit_WarehouseCode ) || ( e.PrevCtrl == this.tEdit_GoodsNo ) || ( e.PrevCtrl == this.tNedit_GoodsMakerCd ))
                        {
                            if ( status == 0 )
                            {
                                // 品番、メーカー、倉庫のいずれかからフォーカス移動時
                                this.ReadGoodsUnit();
                            }
                        }
                        // -----ADD 2008/07/17 -----------------------------<<<<<

                        // 検索を行った場合
                        if ( readed )
                        {
                            // 検索結果で分岐
                            if ( status == 0 )
                            {
                                if ( !e.ShiftKey )
                                {
                                    switch ( e.Key )
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                e.NextCtrl = _guideNextFocusControl.GetNextControl( e.PrevCtrl );
                                            }
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
            // -----DEL 2008/07/17 -----------------------------------------------------------------------------<<<<< */
            // -----ADD 2008/07/17 ----------------------------------------------------------------------------->>>>>
            int status = 0;

            // ボタン
            if (e.PrevCtrl is Infragistics.Win.Misc.UltraButton)
            {
                // メーカーガイド
                if (e.PrevCtrl == ub_MakerGuide)
                {
                    // ↓は移動しない
                    if (e.Key == Keys.Down)
                    {
                        // --- UPD 2010/11/15 ---------->>>>>
                        //e.NextCtrl = e.PrevCtrl;
                        // 絞込条件を変更した場合
                        if (this.SearchParaChange())
                        {
                            e.NextCtrl = null;
                            // 検索処理を実行する
                            this.SearchMain();
                        }
                        else
                        {
                            if (this.History_Grid.Rows.Count > 0)
                            {
                                // グリットへフォーカス移動
                                e.NextCtrl = this.History_Grid;
                                this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                                this.History_Grid.Rows[0].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        // --- UPD 2010/11/15  ----------<<<<<
                    }
                    // Enter/Tabは拠点へ
                    if ((e.ShiftKey == false) && ((e.Key == Keys.Enter) || (e.Key == Keys.Tab)))
                    {
                        //e.NextCtrl = this.tEdit_SectionCodeAllowZero;         //DEL 2009/06/26 不具合対応[13625]
                        //e.NextCtrl = this.ce_SlipKindDiv;                       //ADD 2009/06/26 不具合対応[13625] -> DEL 2010/11/15
                    }    
                }
                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                if (e.PrevCtrl == this.ub_WarehouseGuide && e.Key == Keys.Down)
                {
                    e.NextCtrl = this.CheckEditor_DeleteDataSearch;
                }
                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<

                // 品番
                if (e.PrevCtrl == ub_GoodsGuide)
                {
                    // ↓は移動しない
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                return;
            }

            #region 伝票区分
            // 伝票区分
            if (e.PrevCtrl == this.ce_SlipKindDiv)
            {
                // ↑は拠点コードへ
                if (e.Key == Keys.Up)
                {
                    //e.NextCtrl = this.tEdit_SectionCodeAllowZero;         //DEL 2009/06/26 不具合対応[13625]
                    e.NextCtrl = e.PrevCtrl;                                //ADD 2009/06/26 不具合対応[13625]
                }
                // ↓は倉庫コードへ
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tEdit_WarehouseCode;
                }
                return;
            }
            #endregion

            #region 入出荷日To
            // 入出荷日To
            if (e.PrevCtrl == this.tde_ed_IoGoodsDay)
            {
                // ↓はメーカーへ
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd; 
                }
                return;
            }
            #endregion

            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
            #region 削除検索チェック
            if (e.PrevCtrl == this.CheckEditor_DeleteDataSearch)
            {
                if (e.Key == Keys.Enter || e.Key == Keys.Tab || e.Key == Keys.Right)
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                }
                if ((e.Key == Keys.Enter || e.Key == Keys.Tab) && e.ShiftKey)
                {
                    e.NextCtrl = this.tEdit_GoodsNo;
                }
                if (e.Key == Keys.Down)
                {
                    // 絞込条件を変更した場合
                    if (this.SearchParaChange())
                    {
                        e.NextCtrl = null;
                        // 検索処理を実行する
                        this.SearchMain();
                    }
                    else
                    {
                        if (this.History_Grid.Rows.Count > 0)
                        {
                            // グリットへフォーカス移動
                            e.NextCtrl = this.History_Grid;
                            this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                            this.History_Grid.Rows[0].Selected = true;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                }
                return;
            }
            #endregion
            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<

            // ---DEL 2009/06/26 不具合対応[13625] ---------------->>>>>
            //#region 拠点コード
            //// 拠点コード
            //if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            //{
            //    status = ReadSection();
            //}
            //#endregion
            // ---DEL 2009/06/26 不具合対応[13625] ----------------<<<<<

            // 倉庫コード
            if (e.PrevCtrl == this.tEdit_WarehouseCode)
            {
                status = ReadWarehouse();

                // 棚番を取得
                this.ReadGoodsUnit();
            }
            /* --- DEL 2008/11/28 品番入力後、メーカーを削除すると品番が一緒に削除される為 ------>>>>>
            // 品番
            if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                status = ReadGoods();

                // 棚番、BLｺｰﾄﾞを取得
                this.ReadGoodsUnit();
            }
            // メーカー
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                status = ReadMaker();

                // 棚番、BLｺｰﾄﾞを取得
                this.ReadGoodsUnit();
            }
               --- DEL 2008/11/28 ---------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/28 --------------------------------------------------------------->>>>>
            // 品番 or メーカー
            if ((e.PrevCtrl == this.tEdit_GoodsNo) || (e.PrevCtrl == this.tNedit_GoodsMakerCd))
            {
                status = READDATA_FAILED;

                // 品番、メーカーが未入力
                /* --- DEL 2009/01/14 不具合対応[9865] ------------------------------------------------------>>>>>
                if ((string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.TrimEnd()) == false) &&
                    (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.TrimEnd()) == false) &&
                    (this.tEdit_GoodsNo.Text.TrimEnd() == _prevHeaderInfo.GoodsNo) &&
                    (this.tNedit_GoodsMakerCd.GetInt() == _prevHeaderInfo.GoodsMakerCode))
                {
                    status = READDATA_SUCCESS;
                }
                   --- DEL 2009/01/14 不具合対応[9865] ------------------------------------------------------<<<<< */
                // --- ADD 2009/01/14 不具合対応[9865] ------------------------------------------------------>>>>>
                if ((string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.TrimEnd()) == true) &&
                    (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.TrimEnd()) == true) &&
                    (this.tEdit_GoodsNo.Text.TrimEnd() == _prevHeaderInfo.GoodsNo) &&
                    (this.tNedit_GoodsMakerCd.GetInt() == _prevHeaderInfo.GoodsMakerCode))
                {
                    status = READDATA_SUCCESS;
                }
                // 品番で未入力時
                else if ((e.PrevCtrl == this.tEdit_GoodsNo) &&
                    (string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.TrimEnd())))
                {
                    this.lb_GoodsName.Text = string.Empty;                                  //品名
                    _prevHeaderInfo.GoodsNo = this.tEdit_GoodsNo.Text;                      //品番保持
                    status = READDATA_CNDTNEMPTY;
                }
                // --- ADD 2009/01/14 不具合対応[9865] ------------------------------------------------------<<<<<
                // メーカーで未入力時、メーカー名称を削除
                else if ((e.PrevCtrl == this.tNedit_GoodsMakerCd) &&
                    (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.TrimEnd())))
                {
                    this.lb_MakerName.Text = string.Empty;                                  //メーカー名称
                    _prevHeaderInfo.GoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt();     //メーカーコード保持
                    status = READDATA_CNDTNEMPTY;
                }
                // --- ADD 2009/03/25 -------------------------------->>>>>
                // 品番で変更なし
                else if ((e.PrevCtrl == this.tEdit_GoodsNo) &&
                    this.tEdit_GoodsNo.Text.Trim() == this._prevHeaderInfo.GoodsNo.Trim())
                {
                    status = READDATA_SUCCESS;
                }
                // メーカーで変更なし
                else if ((e.PrevCtrl == this.tNedit_GoodsMakerCd) &&
               this.tNedit_GoodsMakerCd.GetInt() == this._prevHeaderInfo.GoodsMakerCode)
                {
                    status = READDATA_SUCCESS;
                }
                // --- ADD 2009/03/25 --------------------------------<<<<<
                else
                {
                    // --- ADD 2010/11/15 ---------->>>>>
                    // メーカー読み込み処理
                    status = ReadMaker();

                    if (status == READDATA_FAILED)
                    {
                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }
                    // --- ADD 2010/11/15  ----------<<<<<
                    // 商品マスタ読み込み
                    //status = ReadGoods(); // DEL 2009/03/16
                    status = ReadGoods(e); // ADD 2009/03/16

                    if (status == READDATA_SUCCESS)
                    {
                        // 棚番、BLｺｰﾄﾞを取得
                        this.ReadGoodsUnit();
                    }
                    // キャンセル時
                    else if (status == READDATA_CANCEL)
                    {
                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }
                    // エラー時
                    else
                    {
                        if (e.PrevCtrl == this.tEdit_GoodsNo)
                        {
                            /* --- DEL 2009/01/14 不具合対応[9865] ------------------------------------>>>>>
                            //                            this.tNedit_GoodsMakerCd.Clear();
                            //                            this.lb_MakerName.Text = string.Empty;
                            //                            this.lb_GoodsName.Text = string.Empty;
                            //                            _prevHeaderInfo.GoodsMakerCode = 0;
                               --- DEL 2009/01/14 不具合対応[9865] ------------------------------------<<<<< */
                            // --- ADD 2009/01/14 不具合対応[9865] ------------------------------------>>>>>
                            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                            if (!this.CheckEditor_DeleteDataSearch.Checked)
                            {
                                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                                // 前回入力に戻す
                                this.tEdit_GoodsNo.Text = _prevHeaderInfo.GoodsNo;

                                // メッセージ
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "在庫マスタ未登録です",
                                    -1,
                                    MessageBoxButtons.OK);
                            }// ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応
                            // --- ADD 2009/01/14 不具合対応[9865] ------------------------------------<<<<<
                            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                            else
                            {
                                this.lb_GoodsName.Text = string.Empty;             //前回の品名をクリアする。
                                _prevHeaderInfo.GoodsNo = this.tEdit_GoodsNo.Text; //品番保持
                                // 棚番、BLコードをクリアする。
                                status = READDATA_CNDTNEMPTY;
                            }
                            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                        }
                        else
                        {
                            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                            if (!this.CheckEditor_DeleteDataSearch.Checked)
                            {
                                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                                this.tEdit_GoodsNo.Clear();
                                this.lb_GoodsName.Text = string.Empty;
                                _prevHeaderInfo.GoodsNo = string.Empty;
                                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                            }
                            else
                            {
                                this.lb_GoodsName.Text = string.Empty;　　 //前回の品名をクリアする。
                                //メーカーコード保持
                                _prevHeaderInfo.GoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                            }
                            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                            // --- DEL 2010/11/15 ---------->>>>>
                            //status = ReadMaker();

                            //e.NextCtrl = this.tEdit_GoodsNo;
                            // --- DEL 2010/11/15  ----------<<<<<
                            status = READDATA_CNDTNEMPTY;               //ADD 2009/01/14 不具合対応[9865]
                        }
                        //status = READDATA_CNDTNEMPTY;                 //DEL 2009/01/14 不具合対応[9865]
                    }
                }
            }
            // --- ADD 2008/11/28 ---------------------------------------------------------------<<<<<

            // 読み込み失敗 or キャンセル時
            if ((status == READDATA_FAILED) || (status == READDATA_CANCEL))
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            // 入力値なし時
            else if (status == READDATA_CNDTNEMPTY)
            {
                // 倉庫時、棚番をクリア
                if (e.PrevCtrl == this.tEdit_WarehouseCode)
                {
                    this.lb_WarehouseShelfNo.Text = string.Empty;       // 棚番
                }
                // 品番、メーカー時、棚番、BLコードをクリア
                if ((e.PrevCtrl == this.tEdit_GoodsNo) ||
                    (e.PrevCtrl == this.tNedit_GoodsMakerCd))
                {
                    this.lb_BLGoodsCode.Text = string.Empty;            // BLコード
                    this.lb_WarehouseShelfNo.Text = string.Empty;       // 棚番
                }
            }
            // 読み込み成功時
            else if(status == READDATA_SUCCESS)
            {

            }

            // Shift押下時
            if (e.ShiftKey)
            {
               
                // 拠点
                //if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)        //DEL 2009/06/26 不具合対応[13625]
                if (e.PrevCtrl == this.ce_SlipKindDiv)                      //ADD 2009/06/26 不具合対応[13625]
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                return;
            }
            
            // Enter/Tab押下時
            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
            {
                // --- DEL 2010/11/15 ---------->>>>>
                //if (status == READDATA_CNDTNEMPTY)
                //{
                //    return;
                //}
                // --- DEL 2010/11/15  ----------<<<<<
                // メーカー
                if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
                {
                    // 拠点へ
                    //e.NextCtrl = this.tEdit_SectionCodeAllowZero;         //DEL 2009/06/26 不具合対応[13625]
                    // --- UPD 2010/11/15 ---------->>>>>
                    //e.NextCtrl = this.ce_SlipKindDiv;                       //ADD 2009/06/26 不具合対応[13625]
                    // 絞込条件を変更した場合
                    if (this.SearchParaChange())
                    {
                        e.NextCtrl = null;
                        // 検索処理を実行する
                        this.SearchMain();
                    }
                    else
                    {
                        if (this.History_Grid.Rows.Count > 0)
                        {
                            // グリットへフォーカス移動
                            e.NextCtrl = this.History_Grid;
                            this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                            this.History_Grid.Rows[0].Selected = true;
                        }
                        else
                        {
                            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                            {
                                e.NextCtrl = this.ub_MakerGuide;
                            }
                            else
                            {
                                e.NextCtrl = this.ce_SlipKindDiv;
                            }
                        }
                    }
                    // --- UPD 2010/11/15  ----------<<<<<
                }
                else
                {
                    e.NextCtrl = _guideNextFocusControl.GetNextControl(e.PrevCtrl);
                }
            }

            // 品番
            if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                // ↑は倉庫コードへ
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = this.tEdit_WarehouseCode;
                }
                // ↓は移動なし
                if (e.Key == Keys.Down)
                {
                    // --- UPD 2010/11/15 ---------->>>>>
                    //e.NextCtrl = e.PrevCtrl;
                    // 絞込条件を変更した場合
                    if (this.SearchParaChange())
                    {
                        e.NextCtrl = null;
                        // 検索処理を実行する
                        this.SearchMain();
                    }
                    else
                    {
                        if (this.History_Grid.Rows.Count > 0)
                        {
                            // グリットへフォーカス移動
                            e.NextCtrl = this.History_Grid;
                            this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                            this.History_Grid.Rows[0].Selected = true;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    // --- UPD 2010/11/15  ----------<<<<<
                }
                // --- ADD 2010/11/15 ---------->>>>>
                if (e.Key == Keys.Right)
                {
                    //e.NextCtrl = this.tNedit_GoodsMakerCd; // DEL 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応
                    e.NextCtrl = this.CheckEditor_DeleteDataSearch; // ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応
                }
                // --- ADD 2010/11/15  ----------<<<<<
                return;
            }
            // メーカー
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                // ↓は移動なし
                if (e.Key == Keys.Down)
                {
                    // --- UPD 2010/11/15 ---------->>>>>
                    //e.NextCtrl = e.PrevCtrl;

                    // 絞込条件を変更した場合
                    if (this.SearchParaChange())
                    {
                        e.NextCtrl = null;
                        // 検索処理を実行する
                        this.SearchMain();
                    }
                    else
                    {
                        if (this.History_Grid.Rows.Count > 0)
                        {
                            // グリットへフォーカス移動
                            e.NextCtrl = this.History_Grid;
                            this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                            this.History_Grid.Rows[0].Selected = true;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    // --- UPD 2010/11/15  ----------<<<<<
                }
                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                if (e.Key == Keys.Left)
                {
                    e.NextCtrl = this.CheckEditor_DeleteDataSearch;
                }
                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                return;
            }
            // -----ADD 2008/07/17 -----------------------------------------------------------------------------<<<<<
        }
        # region [Read系処理]
        // -----ADD 2008/07/17 ----------------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚番、現在庫数、BLコード読み込み処理
        /// </summary>
        /// <returns></returns>
        private void ReadGoodsUnit()
        {
            int status = 0;
            string msg = string.Empty;

            //string sectionCode   = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();        //DEL　2009/06/26 不具合対応[13625]
            string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();
            int goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // 初期化
            this.lb_BLGoodsCode.Text = string.Empty;
            this.lb_WarehouseShelfNo.Text = string.Empty;

            if ((goodsNo != string.Empty) && (goodsMakerCd != 0))
            {
                GoodsAcs goodsAcs = new GoodsAcs();

                // BLコード取得
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                status = goodsAcs.Read(this._enterprisecode, goodsMakerCd, goodsNo, out goodsUnitData);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitData != null))
                {
                    if (goodsUnitData.BLGoodsCode == 0)
                    {
                        this.lb_BLGoodsCode.Text = string.Empty;
                    }
                    else
                    {
                        this.lb_BLGoodsCode.Text = goodsUnitData.BLGoodsCode.ToString("00000");
                    }
                }

                // 棚番、現在庫数取得
                if (warehouseCode != string.Empty)
                {
                    //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                    //if (this.CheckEditor_DeleteDataSearch.Checked && goodsUnitData.StockList == null)  // DEL 2015/04/07 zhangll Redmine#44209 の#479　削除チェックONから削除チェックOFFへ変更の場合、画面エラーの対応
                    if (goodsUnitData.StockList == null) // ADD 2015/04/07 zhangll Redmine#44209 の#479　削除チェックONから削除チェックOFFへ変更の場合、画面エラーの対応
                    {
　                      goodsUnitData.StockList = new List<Stock>();
                    }
                    //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<

                    /* --- DEL 2008/11/28 棚番、現在庫数が表示されない為 ------------------------------------->>>>>
                    List<Stock> StockList = new List<Stock>();
                    Stock stock = new Stock();
                    stock = goodsAcs.GetStockFromStockList(warehouseCode, goodsMakerCd, goodsNo, StockList);
                       --- DEL 2008/11/28 --------------------------------------------------------------------<<<<< */
                    // --- ADD 2008/11/28 -------------------------------------------------------------------->>>>>
                    Stock stock = new Stock();
                    stock = goodsAcs.GetStockFromStockList(warehouseCode, goodsMakerCd, goodsNo, goodsUnitData.StockList);
                    // --- ADD 2008/11/28 --------------------------------------------------------------------<<<<<
                    if (stock != null)
                    {
                        lb_WarehouseShelfNo.Text = stock.WarehouseShelfNo;                      // 棚番
                        //lb_ShipmentPosCnt.Text = stock.ShipmentPosCnt.ToString("#,##0.00");     // 現在庫数       //DEL 2009/01/14 不具合対応[9992]
                        // --- ADD 2009/01/14 不具合対応[9992]　検索時のみTextをクリアする事により検索時のみ現在庫数の変更を行うように変更 ----->>>>>
                        if (string.IsNullOrEmpty(lb_ShipmentPosCnt.Text))
                        {
                            lb_ShipmentPosCnt.Text = stock.ShipmentPosCnt.ToString("#,##0.00");     // 現在庫数
                            lb_AcpOdrCount.Text = stock.AcpOdrCount.ToString("#,##0.00");           // 受注数       //ADD 2009/01/14 不具合対応[9852]
                        }
                        // --- ADD 2009/01/14 不具合対応[9992] ---------------------------------------------------------------------------------<<<<<
                    }
                    //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                    else
                    {
                        if (this.CheckEditor_DeleteDataSearch.Checked)
                        {
                            if (string.IsNullOrEmpty(lb_ShipmentPosCnt.Text))
                            {
                                // 在庫しない場合、現在庫数と受注数をセットする。
                                lb_ShipmentPosCnt.Text = "0.00";　　　// 現在庫数
                                lb_AcpOdrCount.Text = "0.00";　　　　 // 受注数
                            }
                        }
                    }
                    //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                }
            }

        }
         // -----ADD 2008/07/17 -----------------------------------------------------------------------------<<<<<

        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存項目設定を行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/27</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.CheckEditor_DeleteDataSearch);

            this.uiMemInput1.TargetControls = saveCtrAry;
        }

        /// <summary>
        /// UIMemInputの保存
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInputの保存</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/27</br>
        /// </remarks>
        public void BeforeClose()
        {
            this.uiMemInput1.WriteMemInput();
        }

        #region ◆ UI保存 書込・読込イベント
        /// <summary>
        /// UI保存コンポーネント書込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/27</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[1];

            if (this.CheckEditor_DeleteDataSearch.Checked) customizeData[0] = "1";
            else customizeData[0] = "0";
        }

        /// <summary>
        /// UI保存コンポーネント読込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/27</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                if (customizeData[0] == "1") this.CheckEditor_DeleteDataSearch.Checked = true;
                else this.CheckEditor_DeleteDataSearch.Checked = false;
            }
        }

        #endregion
        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<

        /// <summary>
        /// 倉庫読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadWarehouse()
        {
            //int status = 0;               //DEL 2008/07/17
            int status = READDATA_FAILED;   //ADD 2008/07/17

            string code = this.tEdit_WarehouseCode.DataText.Trim();
            //if ( code == _prevHeaderInfo.WarehouseCode ) return status;           //DEL 2008/07/17
            // -----ADD 2008/07/17 -------------------------->>>>>
            if (code == _prevHeaderInfo.WarehouseCode)
            {
                if (code == string.Empty)
                {
                    return READDATA_CNDTNEMPTY;
                }
                else
                {
                    return READDATA_SUCCESS;
                }
            }
            // -----ADD 2008/07/17 --------------------------<<<<<

            if ( code != string.Empty )
            {
                // ---DEL 2009/06/26 不具合対応[13625] ---------------------------------------->>>>>
                //WarehouseAcs warehouseAcs = new WarehouseAcs();
                //Warehouse warehouse;
                //string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.TrimEnd();

                //// 読み込み
                //status = warehouseAcs.Read( out warehouse, this._enterprisecode, sectionCode, code );
                //if (status == 0)
                //{
                //    // 検索結果をセット
                //    //this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd();                //DEL 2009/01/14 不具合対応[9800]
                //    this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd().PadLeft(4,'0');   //ADD 2009/01/14 不具合対応[9800]
                //    this.lb_WarehouseName.Text = warehouse.WarehouseName.TrimEnd();

                //    _prevHeaderInfo.WarehouseCode = warehouse.WarehouseCode.TrimEnd();
                //    status = READDATA_SUCCESS;      //ADD 2008/07/17
                //}
                //else
                //{
                //    // 前回入力に戻す
                //    this.tEdit_WarehouseCode.Text = _prevHeaderInfo.WarehouseCode;

                //    // メッセージ
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_INFO,
                //        this.Name,
                //        "倉庫コード [" + code + "] に該当するデータが存在しません。",
                //        -1,
                //        MessageBoxButtons.OK );
                //    status = READDATA_FAILED;       //ADD 2008/07/17
                //}
                // ---DEL 2009/06/26 不具合対応[13625] ----------------------------------------<<<<<
                // ---ADD 2009/06/26 不具合対応[13625] ---------------------------------------->>>>>
                WarehouseAcs warehouseAcs = new WarehouseAcs();
                Warehouse warehouse;
                ArrayList arrayList = null;
                // 読み込み
                status = warehouseAcs.Search(out arrayList, this._enterprisecode);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                else if (arrayList == null)
                {
                }
                else if (arrayList.Count == 0)
                {
                }
                else
                {
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        warehouse = (Warehouse)arrayList[i];
                        if (warehouse.WarehouseCode.Trim().PadLeft(4, '0') == code.Trim().PadLeft(4, '0'))
                        {
                            // 検索結果をセット
                            this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd().PadLeft(4, '0');
                            this.lb_WarehouseName.Text = warehouse.WarehouseName.TrimEnd();

                            _prevHeaderInfo.WarehouseCode = warehouse.WarehouseCode.TrimEnd();
                            return READDATA_SUCCESS;
                        }
                    }
                }

                // 前回入力に戻す
                this.tEdit_WarehouseCode.Text = _prevHeaderInfo.WarehouseCode;

                // メッセージ
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "倉庫コード [" + code + "] に該当するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return READDATA_FAILED;
                // ---ADD 2009/06/26 不具合対応[13625] ----------------------------------------<<<<<
            }
            else
            {
                // 入力値をクリア
                this.tEdit_WarehouseCode.Text = string.Empty;
                this.lb_WarehouseName.Text = string.Empty;

                _prevHeaderInfo.WarehouseCode = string.Empty;
                status = READDATA_CNDTNEMPTY;       //ADD 2008/07/17
            }

            return status;
        }

        /// <summary>
        /// 拠点読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadSection()
        {
            // ---DEL 2009/06/26 不具合対応[13625] --------------------------->>>>>
            ////int status = 0;               //DEL 2008/07/17
            //int status = READDATA_FAILED;   //ADD 2008/07/17

            //string code = this.tEdit_SectionCodeAllowZero.DataText.Trim();
            ////if ( code == _prevHeaderInfo.SectionCode ) return status;     //DEL 2008/07/17
            //// -----ADD 2008/07/17 -------------------------->>>>>
            //if (code == _prevHeaderInfo.SectionCode)
            //{
            //    if (code == string.Empty)
            //    {
            //        return READDATA_CNDTNEMPTY;
            //    }
            //    else
            //    {
            //        return READDATA_SUCCESS;
            //    }
            //}
            //if (code == "00")
            //{
            //    // 結果セット
            //    this.lb_SectionName.Text = "全社";
            //    //this.tEdit_WarehouseCode.Text = string.Empty;         //DEL 2008/12/15
            //    //this.lb_WarehouseName.Text = string.Empty;            //DEL 2008/12/15

            //    _prevHeaderInfo.SectionCode = code;
            //    //_prevHeaderInfo.WarehouseCode = string.Empty;         //DEL 2008/12/15
            //    return READDATA_SUCCESS;
            //}

            //// -----ADD 2008/07/17 --------------------------<<<<<
            //if ( code != string.Empty )
            //{
            //    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            //    SecInfoSet secInfoSet;

            //    // 読み込み
            //    status = secInfoSetAcs.Read( out secInfoSet, this._enterprisecode, code );

            //    if ( status == 0 )
            //    {
            //        // 検索結果をセット
            //        this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.TrimEnd();
            //        this.lb_SectionName.Text = secInfoSet.SectionGuideNm.TrimEnd();
            //        //this.tEdit_WarehouseCode.Text = string.Empty;     //DEL 2008/11/28    拠点を変更すると倉庫コードが消える為
            //        //this.lb_WarehouseName.Text = string.Empty;        //DEL 2008/11/28

            //        _prevHeaderInfo.SectionCode = secInfoSet.SectionCode.TrimEnd();
            //        //_prevHeaderInfo.WarehouseCode = string.Empty;       //ADD 2008/07/17  DEL 2008/11/28
            //        status = READDATA_SUCCESS;                          //ADD 2008/07/17
            //    }
            //    else
            //    {
            //        // 前回入力に戻す
            //        this.tEdit_SectionCodeAllowZero.Text = _prevHeaderInfo.SectionCode;

            //        // メッセージ
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "拠点コード [" + code + "] に該当するデータが存在しません。",
            //            -1,
            //            MessageBoxButtons.OK );
            //        status = READDATA_FAILED;       //ADD 2008/07/17 
            //    }
            //}
            //else
            //{
            //    // 入力値をクリア
            //    this.tEdit_SectionCodeAllowZero.Text = string.Empty;
            //    this.lb_SectionName.Text = string.Empty;
            //    this.tEdit_WarehouseCode.Text = string.Empty;
            //    this.lb_WarehouseName.Text = string.Empty;

            //    _prevHeaderInfo.SectionCode = string.Empty;
            //    status = READDATA_CNDTNEMPTY;       //ADD 2008/07/17
            //}

            //return status;
            // ---DEL 2009/06/26 不具合対応[13625] ---------------------------<<<<<
            return 0;       //ADD 2009/06/26 不具合対応[13625]
        }

        /// <summary>
        /// 商品読み込み処理
        /// </summary>
        /// <returns></returns>
        //private int ReadGoods() // DEL 2009/03/16
        private int ReadGoods(Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e) // ADD 2009/03/16
        {
            // -----DEL 2008/07/17 大幅変更の為 ----------------------------------------------------------------------------------------->>>>>
            //int status = 0;

            //string code = this.tEdit_GoodsNo.DataText.Trim();
            //if ( code == _prevHeaderInfo.GoodsNo ) return status;

            //if ( code != string.Empty )
            //{
            //    string searchCode;
            //    int searchType = StockAcPayHistAcs.GetSearchType( code, out searchCode );
            //    List<GoodsUnitData> goodsUnitDataList;
            //    string message;
            //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            //    GoodsCndtn goodsCndtn = new GoodsCndtn();
            //    # region [商品検索条件セット]
            //    goodsCndtn.EnterpriseCode = this._enterprisecode;
            //    goodsCndtn.SectionCode = this.tEdit_SectionCode.Text.TrimEnd();
            //    goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            //    goodsCndtn.MakerName = this.lb_MakerName.Text.TrimEnd();
            //    goodsCndtn.GoodsNo = searchCode.TrimEnd();
            //    goodsCndtn.GoodsNoSrchTyp = searchType;
            //    # endregion

            //    status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
            //    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            //    {
            //        // 検索結果をセット
            //        this.tEdit_GoodsNo.Text = goodsUnitDataList[0].GoodsNo.TrimEnd();
            //        this.lb_GoodsName.Text = goodsUnitDataList[0].GoodsName.TrimEnd();
            //        this.tNedit_GoodsMakerCd.SetInt(goodsUnitDataList[0].GoodsMakerCd);
            //        this.lb_MakerName.Text = goodsUnitDataList[0].MakerName;

            //        _prevHeaderInfo.GoodsNo = goodsUnitDataList[0].GoodsNo.TrimEnd();
            //        _prevHeaderInfo.GoodsMakerCode = goodsUnitDataList[0].GoodsMakerCd;
            //    }
            //    else if (status == -1)
            //    {
            //        // 選択ダイアログでキャンセル
            //    }
            //    else
            //    {
            //        // 前回入力に戻す
            //        this.tEdit_GoodsNo.Text = _prevHeaderInfo.GoodsNo;

            //        // メッセージ
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            //"商品番号 [" + searchCode + "] に該当するデータが存在しません。",     //DEL 2008/07/17 共通化の為
            //            "品番 [" + searchCode + "] に該当するデータが存在しません。",           //ADD 2008/07/17
            //            -1,
            //            MessageBoxButtons.OK);
            //    }
            //}
            //else
            //{
            //    // 入力値をクリア
            //    this.tEdit_GoodsNo.Text = string.Empty;
            //    this.lb_GoodsName.Text = string.Empty;

            //    _prevHeaderInfo.GoodsNo = string.Empty;
            //}
            //-----DEL 2008/07/17 大幅変更の為 ----------------------------------------------------------------------------------------->>>>> */
            //// -----ADD 2008/07/17 --------------------------------------------------------------------------------------------------->>>>>
            string code = this.tEdit_GoodsNo.DataText.Trim();
            /* --- DEL 2008/11/28 品番入力後、メーカーを削除すると品番が一緒に削除される為 -------->>>>>
            // 前回入力値と同じ
            if (code == _prevHeaderInfo.GoodsNo)
            {
                if (string.IsNullOrEmpty(code))
                {
                    return READDATA_CNDTNEMPTY;
                }
                else
                {
                    return READDATA_SUCCESS;
                }
            }
            // 入力なし
            if (code == string.Empty)
            {
                // 入力値をクリア
                this.tEdit_GoodsNo.Text = string.Empty;
                this.lb_GoodsName.Text = string.Empty;

                _prevHeaderInfo.GoodsNo = string.Empty;
                return READDATA_CNDTNEMPTY;
            }
               --- DEL 2008/11/28 -----------------------------------------------------------------<<<<< */

            // インスタンス化
            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            // 検索条件作成
            //string searchCode;                                                            //DEL 2008/11/28　*を使った曖昧検索可能とする為
            //int searchType = StockAcPayHistAcs.GetSearchType(code, out searchCode);       //DEL 2008/11/28

            goodsCndtn.EnterpriseCode = this._enterprisecode;
            //goodsCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();      //DEL 2009/06/26 不具合対応[13625]
            goodsCndtn.SectionCode = "00";                                                  //ADD 2009/06/26 不具合対応[13625]
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd) // ADD 2009/03/16
            {
                goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                goodsCndtn.MakerName = this.lb_MakerName.Text.TrimEnd();
            }
            //goodsCndtn.GoodsNo = searchCode.TrimEnd();                                    //DEL 2008/11/28　*を使った曖昧検索可能とする為
            //goodsCndtn.GoodsNoSrchTyp = searchType;                                       //DEL 2008/11/28
            goodsCndtn.GoodsNo = this.tEdit_GoodsNo.Text.TrimEnd();                         //ADD 2008/11/28
            // ---ADD 2008/12/09 不具合対応[8830] --------------------------------->>>>>
            // 倉庫に値がある場合は入力値を優先させる
            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.TrimEnd()) == false)
            {
                List<string> priorWarehouseList = new List<string>();
                //priorWarehouseList.Add(this.tEdit_WarehouseCode.Text.TrimEnd());                  //DEL 2009/01/14 不具合対応[9800]
                priorWarehouseList.Add(this.tEdit_WarehouseCode.Text.TrimEnd().PadLeft(4,'0'));     //ADD 2009/01/14 不具合対応[9800]
                goodsCndtn.ListPriorWarehouse = priorWarehouseList;
            }
            // ---ADD 2008/12/09 不具合対応[8830] ---------------------------------<<<<<

            string message = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = null;
            // 検索
            int goodsAcsStatus = goodsAcs.SearchInitial(goodsCndtn.EnterpriseCode, goodsCndtn.SectionCode, out message);
            goodsAcsStatus = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
            if ((goodsAcsStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
                // ---ADD 2009/02/02 不具合対応[10773] ------------------------------->>>>>
                if (string.IsNullOrEmpty(goodsUnitDataList[0].SelectedWarehouseCode))
                {
                    this.tEdit_WarehouseCode.Text = _prevHeaderInfo.WarehouseCode;
                    ReadWarehouse();
                    return READDATA_FAILED;
                }
                // ---ADD 2009/02/02 不具合対応[10773] -------------------------------<<<<<

                // 検索結果をセット
                this.tEdit_GoodsNo.Text = goodsUnitDataList[0].GoodsNo.TrimEnd();
                this.lb_GoodsName.Text = goodsUnitDataList[0].GoodsName.TrimEnd();
                this.tNedit_GoodsMakerCd.SetInt(goodsUnitDataList[0].GoodsMakerCd);
                this.lb_MakerName.Text = goodsUnitDataList[0].MakerName;

                _prevHeaderInfo.GoodsNo = goodsUnitDataList[0].GoodsNo.TrimEnd();
                _prevHeaderInfo.GoodsMakerCode = goodsUnitDataList[0].GoodsMakerCd;
                /* ---DEL 2009/02/02 不具合対応[10773] ---------------------------------------------->>>>>

                // ADD 2008/12/09 不具合対応[8874] ------------------------------------->>>>>
                // 倉庫情報が無い場合、Nullで返ってくる
                if (string.IsNullOrEmpty(goodsUnitDataList[0].SelectedWarehouseCode))
                {
                    this.tEdit_WarehouseCode.Text = "";
                    ReadWarehouse();
                    _prevHeaderInfo.WarehouseCode = "";
                }
                else
                {
                // ADD 2008/12/09 不具合対応[8874] -------------------------------------<<<<<
                    // ADD 2008/12/01 不具合対応[8516] ---------->>>>>
                    this.tEdit_WarehouseCode.Text = goodsUnitDataList[0].SelectedWarehouseCode.TrimEnd();
                    ReadWarehouse();
                    _prevHeaderInfo.WarehouseCode = goodsUnitDataList[0].SelectedWarehouseCode;
                    // ADD 2008/12/01 不具合対応[8516] ----------<<<<<
                }//ADD 2008/12/09 不具合対応[8874]
                   ---DEL 2009/02/02 不具合対応[10773] ----------------------------------------------<<<<< */
                // ---ADD 2009/02/02 不具合対応[10773] ---------------------------------------------->>>>>
                this.tEdit_WarehouseCode.Text = goodsUnitDataList[0].SelectedWarehouseCode.TrimEnd();
                ReadWarehouse();
                _prevHeaderInfo.WarehouseCode = goodsUnitDataList[0].SelectedWarehouseCode;
                // ---ADD 2009/02/02 不具合対応[10773] ----------------------------------------------<<<<<
            }
            /* --- DEL 2008/11/28 品番入力後、メーカーを削除すると品番が一緒に削除される為 -------->>>>>
            else if (goodsAcsStatus == -1)
            {
                // 選択ダイアログでキャンセル

                // 前回入力に戻す
                this.tEdit_GoodsNo.Text = _prevHeaderInfo.GoodsNo;
                return READDATA_CANCEL;
            }
            else
            {
                // 前回入力に戻す
                this.tEdit_GoodsNo.Text = _prevHeaderInfo.GoodsNo;

                // メッセージ
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "品番 [" + searchCode + "] に該当するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return READDATA_FAILED;
            }
               --- DEL 2008/11/28 -----------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/28 ----------------------------------------------------------------->>>>>
            else if (goodsAcsStatus == -1)
            {
                return READDATA_CANCEL;
            }
            else
            {
                return READDATA_FAILED;
            }
            // --- ADD 2008/11/28 -----------------------------------------------------------------<<<<<

            return READDATA_SUCCESS;
            //// -----ADD 2008/07/17 ---------------------------------------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// メーカー読み込み処理
        /// </summary>
        /// <returns></returns>
        private int ReadMaker()
        {
            //int status = 0;               //DEL 2008/07/17
            int status = READDATA_FAILED;   //ADD 2008/07/17

            int code = this.tNedit_GoodsMakerCd.GetInt();
            //if ( code == _prevHeaderInfo.GoodsMakerCode ) return status;          //DEL 2008/07/17
            // -----ADD 2008/07/17 -------------------------->>>>>
            if (code == _prevHeaderInfo.GoodsMakerCode)
            {
                if (code == 0)
                {
                    return READDATA_CNDTNEMPTY;
                }
                else
                {
                    return READDATA_SUCCESS;
                }
            }
            // -----ADD 2008/07/17 --------------------------<<<<<

            if ( code != 0 )
            {
                MakerAcs makerAcs = new MakerAcs();
                MakerUMnt makerUMnt;

                // 読み込み
                status = makerAcs.Read( out makerUMnt, this._enterprisecode, code );

                if ( status == 0 )
                {
                    // 検索結果をセット
                    this.tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
                    this.lb_MakerName.Text = makerUMnt.MakerName.TrimEnd();
                    //this.tEdit_GoodsNo.Text = string.Empty; // DEL 2010/11/15
                    //this.lb_GoodsName.Text = string.Empty; // DEL 2010/11/15

                    _prevHeaderInfo.GoodsMakerCode = makerUMnt.GoodsMakerCd;
                    //_prevHeaderInfo.GoodsNo = string.Empty;         //ADD 2008/07/17 -> DEL 2010/11/15
                    status = READDATA_SUCCESS;                      //ADD 2008/07/17
                }
                else
                {
                    // 前回入力に戻す
                    this.tNedit_GoodsMakerCd.SetInt( _prevHeaderInfo.GoodsMakerCode );

                    // メッセージ
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "メーカーコード [" + code + "] に該当するデータが存在しません。",
                        -1,
                        MessageBoxButtons.OK );
                    status = READDATA_FAILED;       //ADD 2008/07/17
                }
            }
            else
            {
                // 入力値をクリア
                this.tNedit_GoodsMakerCd.SetInt( 0 );
                this.lb_MakerName.Text = string.Empty;
                this.tEdit_GoodsNo.Text = string.Empty;
                this.lb_GoodsName.Text = string.Empty;
                
                _prevHeaderInfo.GoodsMakerCode = 0;
                _prevHeaderInfo.GoodsNo = string.Empty;     //ADD 2008/07/17
                status = READDATA_CNDTNEMPTY;               //ADD 2008/07/17
            }

            return status;
        }
        # endregion
        #endregion

        /// <summary>
		/// 得意先ガイドボタンクリックイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: 得意先ガイドを起動します。</br>
		/// <br>Programmer	: 19077 渡邉 貴裕</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>
		private void Customer_uButton_Click(object sender, System.EventArgs e)
		{
		}

        /* -----DEL 2008/07/17 検索ボタンをツールバーに定義の為 ※元の検索ボタンごと削除------------------------------------------------------------------->>>>>
        /// <summary>
        /// 履歴データ読込実行ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索を実行します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private void Performed_uButton_Click(object sender, System.EventArgs e)
        {   
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 商品番号は必須入力に変更
            //if ( this.te_GoodsNo.Text.TrimEnd() == string.Empty )
            //{
            //    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "商品番号を入力してください", 0, MessageBoxButtons.OK );
            //    return;
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        
            //if (ChkDateLength() != true)
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "日付範囲が広すぎます。3ヶ月以内で設定してください", 0, MessageBoxButtons.OK);
            //    return;
            //}
        
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 画面入力内容のチェック
            Control errorControl;
            string errorMessage;
        
            if ( ScreenInputCheck( out errorControl, out errorMessage ) == false )
            {
                // エラーメッセージ表示
                TMsgDisp.Show( emErrorLevel.ERR_LEVEL_INFO, this.ToString(), errorMessage, 0, MessageBoxButtons.OK );
        
                // エラー発生コントロールにフォーカス移動
                if ( errorControl != null )
                {
                    errorControl.Focus();
                }
                return;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        
          
            // 画面情報設定
            _MAZAI04310ub = new MAZAI04310UB();
            _MAZAI04310ub.SearchMode		= this.SearchMode;                  //検索モード
            _MAZAI04310ub.EnterpriseCode	= this._enterprisecode;              //企業コード
            _MAZAI04310ub.GoodsCd           = this.te_GoodsNo.Text;            //商品コード
            _MAZAI04310ub.tde_st_IoGoodsDay        = this.tde_st_IoGoodsDay.GetDateYear() * 10000
                                            + this.tde_st_IoGoodsDay.GetDateMonth() * 100
                                            + this.tde_st_IoGoodsDay.GetDateDay();     //入出荷日
        
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this.ce_IoGoodsDayDiv.SelectedItem != null)
            //{
            //    _MAZAI04310ub.tde_ed_IoGoodsDay = (int)this.ce_IoGoodsDayDiv.SelectedItem.DataValue;
            //}
            //else
            //{
            //    int setDate = this.tde_ed_IoGoodsDay.GetDateYear() * 10000
            //                + this.tde_ed_IoGoodsDay.GetDateMonth() * 100
            //                + this.tde_ed_IoGoodsDay.GetDateDay();
        
            //    _MAZAI04310ub.tde_ed_IoGoodsDay = setDate;
            //}
        
            _MAZAI04310ub.tde_ed_IoGoodsDay = (int)this.tde_ed_IoGoodsDay.GetLongDate();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            
            _MAZAI04310ub.AcPaySlipCd       = (int)this.ce_SlipKindDiv.Value;    //伝票区分(選択INDEX)            
            _MAZAI04310ub.SectionCd         = this.te_SectionCode.Text;          //拠点コード
            _MAZAI04310ub.WareHouse         = this.te_WarehouseCode.Text;        //倉庫コード
        
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //_MAZAI04310ub.Carrier           = this.Carrier_tNedit.GetInt();     //キャリア
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            _MAZAI04310ub.MakerCode = this.tne_GoodsMakerCd.GetInt();//メーカー
            _MAZAI04310ub.GoodsCd = this.te_GoodsNo.Text;//商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //_MAZAI04310ub.ProductNo         = this.ProductNo_Edit.Text;             //製造番号
            //_MAZAI04310ub.StockTellNo       = this.CellPhoneNo_Edit.Text;             //携帯番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            _MAZAI04310ub.StartCnt			= this.History_Grid.Rows.Count;
            _MAZAI04310ub.StockAcPayHistList= this._stockAcPayHistList;
            
            //検索
            // 共通処理中画面生成
            SFCMN00299CA form = new SFCMN00299CA();
        
            try
            {
                // 共通処理中画面プロパティ設定
                form.Title = "読込み中";                            // 画面のタイトル部分に表示する文字列
                form.Message = "履歴データの読込み中です．．．";    // 画面のプログレスバーの上に表示する文字列
                form.DispCancelButton = false;                      // キャンセルボタン押下による中断機能ＯＮ（デフォルトはＯＦＦ）
        
                // 共通処理中画面表示
                form.Show();
        
                _MAZAI04310ub.ReadProc();
        
                this._stockAcPayHistList = _MAZAI04310ub.StockAcPayHistList;
        
                if (_stockAcPayHistList != null)
                {
                    if (_stockAcPayHistList.Count != 0)
                    {
                        // グリッド表示
                        GridDataSet();
        
                        // 取得データグリッド表示
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //History_Grid.DataSource = ds;
                        //History_Grid.DataMember = TBL_HISTORY;
        
                        History_Grid.DataSource = _stockAcPayHistView;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        
                        _gridStateController.SetGridStateToGrid(ref this.History_Grid);
        
                        AutoFitCol_ultraCheckEditor.Checked = false;
                        AutoFitCol_ultraCheckEditor.Checked = true;
        
                        form.Close();
                    }
                    else                
                    {
                        //Gridクリア
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //ds.Tables[TBL_HISTORY].Rows.Clear();
                        ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows.Clear();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        
                        form.Close();
                        // 該当データなし
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "該当データがありません", 0, MessageBoxButtons.OK);
                    }
        
                }
                else
                {
                    form.Close();
                    // 該当データなし
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "該当データがありません", 0, MessageBoxButtons.OK);
                }
            }
            finally
            {
              
            }
        }
           -----DEL 2008/07/17 ----------------------------------------------------------------------------------------------------------------------------<<<<< */

        /// <summary>
        /// 画面入力内容のチェック
        /// </summary>
        /// <param name="errorControl">(out)エラー発生コントロール</param>
        /// <param name="errorMessage">(out)エラーメッセージ</param>
        /// <returns>true : 入力OK / false : 入力NG</returns>
        /// <remarks>
        /// <br>Update Note: 2009/12/04 李侠</br>
        /// <br>             PM.NS-4・保守依頼③</br>
        /// <br>             入出荷日の３カ月以上の入力チェックを取消する</br>
        /// <br>Update Note: 2015/03/27 時シン</br>
        /// <br>管理番号   : 11070263-00　Seiken品番変更</br>
        /// <br>           : 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応</br>
        /// </remarks>
        private bool ScreenInputCheck( out Control errorControl, out string errorMessage )
        {
            errorControl = null;
            errorMessage = string.Empty;

            /* -----DEL 2008/07/17 タブ順変更の為 ------------------------------------------------------------------------->>>>> 
            // メーカー必須チェック
            if ( tne_GoodsMakerCd.GetInt() == 0 )
            {
                errorControl = tne_GoodsMakerCd;
                errorMessage = "メーカーを入力して下さい";
                return false;
            }
            // 商品番号必須チェック
            if ( te_GoodsNo.Text.TrimEnd() == string.Empty )
            {
                errorControl = te_GoodsNo;
                errorMessage = "商品番号を入力して下さい";
                return false;
            }
            // 拠点必須チェック
            if ( te_SectionCode.Text.TrimEnd() == string.Empty )
            {
                errorControl = te_SectionCode;
                errorMessage = "拠点コードを入力して下さい";
                return false;
            }
            // 倉庫必須チェック
            if ( te_WarehouseCode.Text.TrimEnd() == string.Empty )
            {
                errorControl = te_WarehouseCode;
                errorMessage = "倉庫コードを入力して下さい";
                return false;
            }
            // 日付開始チェック
            if ( tde_st_IoGoodsDay.GetDateTime() == DateTime.MinValue )
            {
                errorControl = tde_st_IoGoodsDay;
                errorMessage = "入出荷日開始の入力が不正です";
                return false;
            }
            // 日付終了チェック
            if ( tde_ed_IoGoodsDay.GetDateTime() == DateTime.MinValue )
            {
                errorControl = tde_ed_IoGoodsDay;
                errorMessage = "入出荷日終了の入力が不正です";
                return false;
            }
            // 日付大小チェック
            if ( tde_st_IoGoodsDay.GetLongDate() > tde_ed_IoGoodsDay.GetLongDate())
            {
                errorControl = tde_st_IoGoodsDay;
                errorMessage = "入出荷日は開始≦終了となるように入力して下さい";
                return false;
            }
            // 日付範囲過剰チェック
            if ( ChkDateLength() == false )
            {
                errorControl = tde_st_IoGoodsDay;
                errorMessage = "入出荷日の日付範囲が広すぎます。３ヶ月以内で設定してください";
                return false;
            }
               -----DEL 2008/07/17 ----------------------------------------------------------------------------------------<<<<< */
            // -----ADD 2008/07/17 ---------------------------------------------------------------------------------------->>>>>
            // ---DEL 2009/06/26 不具合対応[13625] --------------------->>>>>
            //// 拠点必須チェック
            //if (tEdit_SectionCodeAllowZero.Text.TrimEnd() == string.Empty)
            //{
            //    errorControl = tEdit_SectionCodeAllowZero;
            //    errorMessage = "拠点コードを入力して下さい";
            //    return false;
            //}
            // ---DEL 2009/06/26 不具合対応[13625] ---------------------<<<<<
            // 日付開始チェック
            if (tde_st_IoGoodsDay.GetDateTime() == DateTime.MinValue)
            {
                errorControl = tde_st_IoGoodsDay;
                errorMessage = "入出荷日開始の入力が不正です";
                return false;
            }
            // 日付終了チェック
            if (tde_ed_IoGoodsDay.GetDateTime() == DateTime.MinValue)
            {
                errorControl = tde_ed_IoGoodsDay;
                errorMessage = "入出荷日終了の入力が不正です";
                return false;
            }
            // 日付大小チェック
            if (tde_st_IoGoodsDay.GetLongDate() > tde_ed_IoGoodsDay.GetLongDate())
            {
                errorControl = tde_st_IoGoodsDay;
                errorMessage = "入出荷日は開始≦終了となるように入力して下さい";
                return false;
            }
            // --- DEL 2009/12/04 ---------->>>>>
            //// 日付範囲過剰チェック
            //if (ChkDateLength() == false)
            //{
            //    errorControl = tde_st_IoGoodsDay;
            //    //errorMessage = "入出荷日の日付範囲が広すぎます。３ヶ月以内で設定してください";        //DEL 2008/11/17 メッセージ変更
            //    errorMessage = "入出荷日は３ヶ月の範囲内で入力して下さい。";                            //ADD 2008/11/17
            //    return false;
            //}
            // --- DEL 2009/12/04 ----------<<<<<
            // 倉庫必須チェック
            if (tEdit_WarehouseCode.Text.TrimEnd() == string.Empty)
            {
                errorControl = tEdit_WarehouseCode;
                errorMessage = "倉庫コードを入力して下さい";
                return false;
            }
            // 商品番号必須チェック
            if (tEdit_GoodsNo.Text.TrimEnd() == string.Empty)
            {
                errorControl = tEdit_GoodsNo;
                //errorMessage = "商品番号を入力して下さい";        //DEL 2008/07/17
                errorMessage = "品番を入力して下さい";              //ADD 2008/07/17
                return false;
            }
            // メーカー必須チェック
            if (tNedit_GoodsMakerCd.GetInt() == 0)
            {
                errorControl = tNedit_GoodsMakerCd;
                errorMessage = "メーカーを入力して下さい";
                return false;
            }
            // -----ADD 2008/07/17 ----------------------------------------------------------------------------------------<<<<<
            /* ---DEL 2009/01/14 不具合対応[9865] --------------------------------------------------------->>>>>
            // ---ADD 2008/12/09 不具合対応[8873] ---------------------------------------------------->>>>>
            // 倉庫存在チェック
            if (this.CheckGoods() == false)
            {
                errorControl = tEdit_WarehouseCode;
                errorMessage = "倉庫コード [" + tEdit_WarehouseCode.Text.TrimEnd() + "] に該当するデータが存在しません。";
                return false;
            }
            // ---ADD 2008/12/09 不具合対応[8873] ----------------------------------------------------<<<<<
              ---DEL 2009/01/14 不具合対応[9865] ---------------------------------------------------------<<<<< */
            // ---ADD 2009/01/14 不具合対応[9865] --------------------------------------------------------->>>>>
            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
            if (!this.CheckEditor_DeleteDataSearch.Checked)
            {
                //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                // 倉庫存在チェック
                int status = this.CheckGoods();
                if (status == -1)
                {
                    if (tNedit_GoodsMakerCd.GetInt() != _prevHeaderInfo.GoodsMakerCode)
                    {
                        errorControl = tNedit_GoodsMakerCd;
                    }
                    else
                    {
                        errorControl = tEdit_GoodsNo;
                    }
                    errorMessage = "在庫マスタ未登録です";
                    return false;
                }
                else if (status == -2)
                {
                    errorControl = tEdit_WarehouseCode;
                    errorMessage = "倉庫コード [" + tEdit_WarehouseCode.Text.TrimEnd() + "] に該当するデータが存在しません。";
                    return false;
                }
            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
            }
            else
            { 
                // 削除検索チェックあり場合
            }
            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
            // ---ADD 2009/01/14 不具合対応[9865] ---------------------------------------------------------<<<<<
            return true;
        }

        // ---ADD 2008/12/09 不具合対応[8873] ---------------------------------------------------->>>>>
        /// <summary>
        /// 在庫マスタ存在チェック
        /// </summary>
        /// <returns>-2：在庫情報が存在しない、-1：商品マスタに存在しない、0：存在する</returns>
        /// <remarks>
        /// <br>Note		: メーカー、品番、倉庫を元に在庫マスタの存在チェックを行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/12/09</br>
        /// </remarks>
        //private bool CheckGoods()         //DEL 2009/01/14 不具合対応[9865]
        private int CheckGoods()            //ADD 2009/01/14
        {
            string message = string.Empty;
            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            List<GoodsUnitData> goodsUnitDataList = null;

            // 抽出条件
            goodsCndtn.EnterpriseCode = this._enterprisecode;                           // 企業コード
            //goodsCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();    // 拠点コード     //DEL 2009/06/26 不具合対応[13625]
            goodsCndtn.SectionCode = "00";                                                                  //ADD 2009/06/26 不具合対応[13625]
            goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();                // メーカーコード
            goodsCndtn.GoodsNo = this.tEdit_GoodsNo.Text.TrimEnd();                     // 品番

            // 検索(商品マスタ読み込み)
            int goodsAcsStatus = goodsAcs.SearchInitial(goodsCndtn.EnterpriseCode, goodsCndtn.SectionCode, out message);
            goodsAcsStatus = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
            if (goodsAcsStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //return false;         //DEL 2009/01/14 不具合対応[9865]
                return -1;              //ADD 2009/01/14
            }
            if (goodsUnitDataList == null)
            {
                //return false;         //DEL 2009/01/14 不具合対応[9865]
                return -1;              //ADD 2009/01/14
            }
            if (goodsUnitDataList.Count == 0)
            {
                //return false;         //DEL 2009/01/14 不具合対応[9865]
                return -1;              //ADD 2009/01/14
            }

            // 関連する在庫情報取得
            List<Stock> stockList = goodsUnitDataList[0].StockList;
            if (stockList == null)
            {
                //return false;         //DEL 2009/01/14 不具合対応[9865]
                //return -2;              //ADD 2009/01/14  →DEL 2009/02/02　不具合対応[10773]
                return -1;              //ADD 2009/02/02　不具合対応[10773]
            }
            if (stockList.Count == 0)
            {
                //return false;         //DEL 2009/01/14 不具合対応[9865]
                //return -2;              //ADD 2009/01/14　→DEL 2009/02/02　不具合対応[10773]
                return -1;              //ADD 2009/02/02　不具合対応[10773]
            }

            // 抽出条件
            //string warehouseCode = this.tEdit_WarehouseCode.Text.TrimEnd();                   //DEL 2009/01/14 不具合対応[9800]
            string warehouseCode = this.tEdit_WarehouseCode.Text.TrimEnd().PadLeft(4,'0');      //ADD 2009/01/14 不具合対応[9800]

            // 検索(在庫情報を画面の値で絞り込む)
            Stock stock = goodsAcs.GetStockFromStockList(warehouseCode, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, stockList);
            if (stock == null)
            {
                //return false;         //DEL 2009/01/14 不具合対応[9865]
                return -2;              //ADD 2009/01/14
            }

            //return true;              //DEL 2009/01/14 不具合対応[9865]
            return 0;                   //ADD 2009/01/14
        }
        // ---ADD 2008/12/09 不具合対応[8873] ----------------------------------------------------<<<<<

		/// <summary>
		/// 履歴グリッドRowダブルクリックイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: 明細履歴画面を起動します。</br>
		/// <br>Programmer	: 19077 渡邉 貴裕</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>

        private void History_Grid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
        }

        /// <summary>
        /// 履歴グリッドアフターKeyDownイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: グリッド上でキー押下時に発生します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private void History_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            /* --- DEL 2008/11/28 明細グリッドで矢印キー押下時の動き修正の為 --------------------------------------->>>>>
            //↑を押されていなかったらなにもしない
            if (e.KeyCode != Keys.Up)
            {
                return;
            }

            //フォーカスを電話番号のとこに移す
            if (this.History_Grid.ActiveRow != null
                && this.History_Grid.ActiveRow.Index == 0)
            {
                // 得意先コードへフォーカス遷移
                this.tEdit_GoodsNo.Focus();

                // ChangeFocusイベントが発動しないのでバッファを取得しておく
                //                _prevDouble = this.Customer_tNedit.GetInt();
            }
               --- DEL 2008/11/28 ----------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/28 ---------------------------------------------------------------------------------->>>>>
            #region ↑押下
            if (e.KeyCode == Keys.Up)
            {
                // 得意先コードへ移動
                if ((this.History_Grid.ActiveRow != null) && (this.History_Grid.ActiveRow.Index == 0))
                {
                    this.tEdit_GoodsNo.Focus();
                }

                return;
            }
            #endregion

            #region →押下
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.History_Grid.DisplayLayout.ColScrollRegions[0].Position = this.History_Grid.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            #endregion

            #region ←押下
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を左にスクロール
                this.History_Grid.DisplayLayout.ColScrollRegions[0].Position = this.History_Grid.DisplayLayout.ColScrollRegions[0].Position - 40;
            }
            #endregion

            #region Home押下
            if (e.KeyCode == Keys.Home)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.History_Grid.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // 先頭行に移動
                    this.History_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }
            #endregion

            #region End押下
            if (e.KeyCode == Keys.End)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.History_Grid.DisplayLayout.ColScrollRegions[0].Position = this.History_Grid.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // 最終行に移動
                    this.History_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
            #endregion
            // --- ADD 2008/11/28 ----------------------------------------------------------------------------------<<<<<
        }
        
        /// <summary>
		/// 履歴グリッドアフターRowアクティブイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: 行がアクティブになった後に発生します。</br>
		/// <br>Programmer	: 19077 渡邉 貴裕</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>
		private void History_Grid_AfterRowActivate(object sender, System.EventArgs e)
		{
			// 選択行が存在する場合
			if ( History_Grid.ActiveRow != null )
			{
				Infragistics.Win.UltraWinGrid.UltraGridRow activeRow = History_Grid.ActiveRow;

                //　行を選択
//                activeRow.Selected = true;
/*
				// 情報Editに表示する
				switch (SearchMode)
				{
					case (int)SFTOK01433EA.RemoteMode.CustomerCode:
					{
						// 得意先情報で抽出されている場合は変更が無いのでそのまま何もしない
						break;
					}
					case (int)SFTOK01433EA.RemoteMode.FrameNo:
					case (int)SFTOK01433EA.RemoteMode.NumberPlate:
					{
						break;
					}
				}
 */ 
			}
		}
		/// <summary>
		/// FormClosingイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フォームを閉じるクエリー内で発生します。</br>
		/// <br>Programmer	: 19077 渡邉 貴裕</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>
		private void MAZAI04310UA_FormClosed(object sender, FormClosedEventArgs e)
		{
			// グリッド設定制御クラスにグリッド情報を展開
//			_gridStateController.GetGridStateFromGrid(ref this.History_Grid);
			// グリッド情報を保存
//			_gridStateController.SaveGridState(ctGridInfoFileNm);
		}

		/// <summary>
		/// フォントサイズValueChangedイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フォントサイズの値が変更された時に発生します。</br>
		/// <br>Programmer	: 19077 渡邉 貴裕</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>
		private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			// フォントサイズを変更
			this.History_Grid.DisplayLayout.Appearance.FontData.SizeInPoints
				= (int)FontSize_tComboEditor.Value;
		}

		/// <summary>
		/// 列サイズの自動調整CheckedChangedイベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: 列サイズの自動調整のチェックが変更された時に発生します。</br>
		/// <br>Programmer	: 19077 渡邉 貴裕</br>
		/// <br>Date		: 2007.05.18</br>
        /// <br>Update Note : 2009/12/04 李侠</br>
        /// <br>              PM.NS-4・保守依頼③の列サイズの自動調整の不具合対応</br>
		/// </remarks>
		private void AutoFitCol_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
		{
			// 列サイズの自動調整
            // --- UPD 2009/12/04 ---------->>>>>
            //if (!this.AutoFitCol_ultraCheckEditor.Checked)
            if (this.AutoFitCol_ultraCheckEditor.Checked)
            // --- UPD 2009/12/04 ----------<<<<<
				this.History_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
			else
				this.History_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

			foreach (UltraGridColumn wkColumn in this.History_Grid.DisplayLayout.Bands[0].Columns)
			{
                // --- UPD 2009/12/04 ---------->>>>>
                //wkColumn.PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
                wkColumn.PerformAutoResize();
                // --- UPD 2009/12/04 ----------<<<<<
			}
		}
		#endregion

		#region Private Method
		/// <summary>
		/// グリッド表示用DataSetスキーマ作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッド表示用DataSetスキーマを作成します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void CreateGridSchema(bool productStock)
		{
            if (ds != null)
            {
                ds.Clear();
            }
			ds = new DataSet();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 照会grid用データテーブル生成
            DataTable dt = null;
            MAZAI04311EC.CreateDataTable( ref dt );

            // ビューの生成
            _stockAcPayHistView = new DataView( dt );
            /* -----DEL 2008/07/17 ソート順変更の為 ---------------------------------------------------->>>>>
            _stockAcPayHistView.Sort = string.Format("{0} DESC, {1} DESC",
                                                        MAZAI04311EC.ct_Col_IoGoodsDay,
                                                        MAZAI04311EC.ct_Col_AcPayHistDateTime);
               -----DEL 2008/07/17 ---------------------------------------------------------------------<<<<< */
            /* -----DEL 2008/12/09 不具合対応[8895]---------------------------------------------------------------->>>>>
            // -----ADD 2008/07/17 --------------------------------------------------------------------->>>>>
            _stockAcPayHistView.Sort = string.Format("{0}, {1}, {2}",
                                                       MAZAI04311EC.ct_Col_IoGoodsDay,
                                                       MAZAI04311EC.ct_Col_AcPayHistDateTime,
                                                       MAZAI04311EC.ct_Col_AcPaySlipCd);
            // -----ADD 2008/07/17 ---------------------------------------------------------------------<<<<<
               -----DEL 2008/12/09 不具合対応[8895]----------------------------------------------------------------<<<<< */
            /* -----DEL 2008/12/09 不具合対応[10619]-------------------------------------------------------------------->>>>>
            // -----ADD 2008/12/09 不具合対応[8895]---------------------------------------------------------------->>>>>
            _stockAcPayHistView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                       MAZAI04311EC.ct_Col_SectionCode,             //拠点
                                                       MAZAI04311EC.ct_Col_WarehouseCode,           //倉庫
                                                       MAZAI04311EC.ct_Col_GoodsNo,                 //品番
                                                       MAZAI04311EC.ct_Col_IoGoodsDay,              //日付
                                                       MAZAI04311EC.ct_Col_AcPaySlipCd,             //伝票区分
                                                       MAZAI04311EC.ct_Col_AcPaySlipNum);           //伝票番号
            // -----ADD 2008/12/09 不具合対応[8895]----------------------------------------------------------------<<<<<
               -----DEL 2008/12/09 不具合対応[10619]--------------------------------------------------------------------<<<<< */
            // -----ADD 2008/12/09 不具合対応[10619]-------------------------------------------------------------------->>>>>
            _stockAcPayHistView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}",
                                                       MAZAI04311EC.ct_Col_SectionCode,             //拠点
                                                       MAZAI04311EC.ct_Col_WarehouseCode,           //倉庫
                                                       MAZAI04311EC.ct_Col_GoodsNo,                 //品番
                                                       MAZAI04311EC.ct_Col_AcPayHistDateTime,       //受払履歴作成日時
                                                       MAZAI04311EC.ct_Col_AcPaySlipRowNo);         //受払元行番号
            // -----ADD 2008/12/09 不具合対応[10619]--------------------------------------------------------------------<<<<<


            //DataTable dt = new DataTable(TBL_HISTORY);
            //dt.Clear();

            // //dt.Columns.Add(COL_ADDUPEXST, typeof(string));	// 計上有無
            // dt.Columns.Add(COL_ROWNUM, typeof(int)); //行番号
            // dt.Columns.Add(COL_tde_st_IoGoodsDay, typeof(DateTime)); // 入出荷日
            // dt.Columns.Add(COL_SLIPCD, typeof(string));     // 伝票区分
            // dt.Columns.Add(COL_TRANSDIV, typeof(string));	// 取引区分
            // dt.Columns.Add(COL_GOODSCODE, typeof(string));	// 商品コード
            // dt.Columns.Add(COL_GOODSNM, typeof(string));	// 商品名称            
            // dt.Columns.Add(COL_ARRIVALGOODSCNT, typeof(double));	// 入荷数
            // dt.Columns.Add(COL_SHIPMCNT, typeof(double));	// 出荷数
            // dt.Columns.Add(COL_STOCKCNT, typeof(int));      // 在庫数
            // dt.Columns.Add(COL_SECTIONNAME, typeof(string)); //拠点名称
            // dt.Columns.Add(COL_RECVPYEECUST, typeof(string));	// 受払先
            // dt.Columns.Add(COL_BFSECTIONGUIDENM, typeof(string));//移動元拠点
            // dt.Columns.Add(COL_BFENTERWAREHNAME, typeof(string));//移動元倉庫            
            // dt.Columns.Add(COL_AFSECTIONGUIDENM,typeof(string));//移動先拠点
            // dt.Columns.Add(COL_AFENTERWAREHNAME,typeof(string));//移動先倉庫
            // dt.Columns.Add(COL_SLIPNO, typeof(int));	    // 伝票番号
            // dt.Columns.Add(COL_ACPAYNOTE,typeof(string));//伝票備考
            // dt.Columns.Add(COL_MODEL, typeof(string));	// 機種

            // /*
            // dt.Columns.Add(COL_SLIPNO, typeof(int));	    // 伝票番号
            // dt.Columns.Add(COL_STOCKCNT, typeof(double));	// 在庫数
            //*/
            // if (productStock != false)
            // {
            //     dt.Columns.Add(COL_PRODUCTNO, typeof(string));		// 製造番号
            //     dt.Columns.Add(COL_SIMPRODUCENO, typeof(string));		// SIM製造番号
            //     dt.Columns.Add(COL_CPHONENO, typeof(string));		// 携帯番号
            //     dt.Columns.Add(COL_CARRIEREP, typeof(string));	// 事業者
            // }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			ds.Tables.Add(dt);                        
		}
		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="TempCarCheck">仮登録車両チェック状態</param>
		/// <remarks>
		/// <br>Note       : 画面の初期化を行います</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void AllDispClear(bool TempCarCheck)
		{
			// 画面初期化
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_GoodsNo.Clear();
			//this.tEdit_SectionCodeAllowZero.Clear();          //DEL 2009/06/26 不具合対応[13625]
            this.tEdit_WarehouseCode.Clear();

            this.lb_MakerName.Text = string.Empty;
            this.lb_GoodsName.Text = string.Empty;
            this.lb_WarehouseName.Text = string.Empty;
            // -----ADD 2008/07/17 ------------------------------------>>>>>
            this.lb_WarehouseShelfNo.Text = string.Empty;       // 棚番
            this.lb_BLGoodsCode.Text = string.Empty;            // BLコード

            // グリッド関連クリア
            GridClear();
            // -----ADD 2008/07/17 ------------------------------------<<<<<

            // ---DEL 2009/06/26 不具合対応[13625] ------------------------>>>>>
            ///* ---DEL 2009/01/20 不具合対応[10121] ---------------------------------------------------------------------------------->>>>>
            ////拠点はログイン拠点

            //SecInfoSet secInfoSet;
            ////int status = _SecInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);       //DEL 2008/07/17 コンパイルエラーとなる為
            //int status = _SecInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);       //ADD 2008/07/17  
            
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (secInfoSet != null)
            //    {
            //        this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
            //        this.lb_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //        this.tEdit_WarehouseCode.Text = secInfoSet.SectWarehouseCd1.TrimEnd();
            //        //this.lb_WarehouseName.Text = secInfoSet.SectWarehouseNm1.TrimEnd();       //DEL 2008/07/17 名称は入ってこない為
            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //        this.ReadWarehouse();       //ADD 2008/07/17
            //    }
            //}
            //   ---DEL 2009/01/20 不具合対応[10121] ----------------------------------------------------------------------------------<<<<< */
            //// ---ADD 2009/01/20 不具合対応[10121] ---------------------------------------------------------------------------------->>>>>
            //this.tEdit_SectionCodeAllowZero.Text = "00";
            //this.ReadSection();
            //// ---ADD 2009/01/20 不具合対応[10121] ----------------------------------------------------------------------------------<<<<<
            // ---DEL 2009/06/26 不具合対応[13625] ------------------------<<<<<

            /* --- DEL 2008/11/17 初期値変更 ---------------------------------------------------------------------------->>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.Carrier_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.tde_st_IoGoodsDay.SetDateTime(DateTime.Now);
            this.tde_st_IoGoodsDay.SetDateTime( DateTime.Now.AddMonths(-1).AddDays(1) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.tde_ed_IoGoodsDay.SetDateTime(DateTime.Now);
            // --- DEL 2008/11/17 ---------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/17 --------------------------------------------------------------------------------------->>>>>
            this.tde_st_IoGoodsDay.SetDateTime(this.GetPrevTotalDayNextDay(LoginInfoAcquisition.Employee.BelongSectionCode));
            this.tde_ed_IoGoodsDay.SetDateTime(DateTime.Today);
            // --- ADD 2008/11/17 ---------------------------------------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ProductNo_Edit.Clear();
            //this.CellPhoneNo_Edit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.ce_SlipKindDiv.SelectedIndex = 0;
            this.ce_IoGoodsDayDiv.Value = 0;



			CreateGridSchema(false);

			History_Grid.DataSource = ds;

            _gridStateController.SetGridStateToGrid(ref this.History_Grid);
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 前回入力をセット
            _prevHeaderInfo.GoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt();
            _prevHeaderInfo.GoodsNo = this.tEdit_GoodsNo.Text.TrimEnd();
            //_prevHeaderInfo.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();             //DEL 2009/06/26 不具合対応[13625]
            //_prevHeaderInfo.WarehouseCode = this.tEdit_WarehouseCode.Text.TrimEnd();                  //DEL 2009/01/14 不具合対応[9800]
            _prevHeaderInfo.WarehouseCode = this.tEdit_WarehouseCode.Text.TrimEnd().PadLeft(4,'0');     //ADD 2009/01/14 不具合対応[9800]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
            // 前回表示状態が保存されていれば上書き
            this.uiMemInput1.ReadMemInput();
            //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
		}

		#region ToolBarSetting
		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行います</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void SetToolbar()
		{
			// 拠点コンボボックス作成
			Infragistics.Win.UltraWinToolbars.ComboBoxTool SectionCombo = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
			if (SectionCombo != null) 
			{
				foreach (SecInfoSet secInfoSet in _SecInfoAcs.SecInfoSetList)
				{
					SectionCombo.ValueList.ValueListItems.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm);
				}

				//---自拠点の拠点情報の取得---//
				_secInfoSet = new SecInfoSet();
				companyNm = new CompanyNm();
				_SecInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd4, out _secInfoSet, out companyNm);
            
    			SectionCombo.SharedProps.Enabled = false;
			}

			// イメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = this._imageList16;

			// 拠点情報へのアイコン設定
			Infragistics.Win.UltraWinToolbars.LabelTool SectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["SectionTitle_LabelTool"];
			if (SectionLabel != null) SectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

			// ログイン担当者へのアイコン設定
			Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
			if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// ログイン担当者表示
			Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if (LoginInfoAcquisition.Employee != null)
			{
				if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;                
			}

			// 終了のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool endButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["End_ButtonTool"];
			if (endButton != null) endButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // -----ADD 2008/07/17 -------------------------------------------------------------------------------------------------------------------------------->>>>>
            // クリアのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Clear_ButtonTool"];
            if (clearButton != null) clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // 検索のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Search_ButtonTool"];
            if (searchButton != null) searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // -----ADD 2008/07/17 --------------------------------------------------------------------------------------------------------------------------------<<<<<

			// 印刷のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Print_ButtonTool"];
			if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            // -----ADD 2008/07/17 -------------------------------------------------------------------------------------------------------------------------------->>>>>
            // プレビュー(PDF)のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Preview_ButtonTool"];
            if (previewButton != null) previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            // -----ADD 2008/07/17 --------------------------------------------------------------------------------------------------------------------------------<<<<<


            // テキスト出力のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool textoutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["TextOut_ButtonTool"];
            if (textoutButton != null) textoutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;

            /* -----DEL 2008/07/17 新規→クリア変更の為 ----------------------------------------------------------------------------------------------------------->>>>> 
            // 新規のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["New_ButtonTool"];
            if (textoutButton != null) newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
               -----DEL 2008/07/17 --------------------------------------------------------------------------------------------------------------------------------<<<<< */

        }
		#endregion

		#region GridDataSet
		/// <summary>
		/// グリッド表示用DataSet作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッド表示用DataSetの作成を行います</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private int GridDataSet()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int st = 0;

            //ds.Tables[TBL_HISTORY].Clear();

            //if ((this.ProductNo_Edit.Text.Trim() != "") || (this.CellPhoneNo_Edit.Text.Trim() != ""))
            //{
            //    //製番あり
            //    StockAcPayHisDt[] _mainWkHisDtArray = null;
            //    StockAcPayHisDt _mainWkHisDt = null;

            //    int ii = 0;
            //    //配列データの取得
            //    _mainWkHisDtArray = new StockAcPayHisDt[retList.Count];
            //    foreach (Object wkObj in retList)
            //    {
            //        if (wkObj is StockAcPayHisDt)
            //        {
            //            _mainWkHisDt = (StockAcPayHisDt)wkObj;
            //            _mainWkHisDtArray[ii] = _mainWkHisDt;
            //            ii++;
            //        }
            //    }

            //    // グリッド用データセット初期化
            //    CreateGridSchema(true);

            //    int i = 1;

            //    foreach (StockAcPayHisDt stockAcPayHisDt in _mainWkHisDtArray)
            //    {
            //        DataRow dr = ds.Tables[TBL_HISTORY].NewRow();

            //        // 計上年月
            //        if (stockAcPayHisDt.tde_st_IoGoodsDay == DateTime.MinValue)
            //        {

            //        }
            //        else
            //        {
            //            dr[COL_tde_st_IoGoodsDay] = stockAcPayHisDt.tde_st_IoGoodsDay;
            //        }

            //        dr[COL_ROWNUM] = i;
            //        i++;
            //        // 伝票番号
            //        dr[COL_SLIPNO] = stockAcPayHisDt.AcPaySlipNum;
            //        // 伝票区分
            //        string denKbn = "";
            //        denKbn = GetSlipKbn(stockAcPayHisDt.AcPaySlipCd);
            //        dr[COL_SLIPCD] = denKbn;

            //        // 取引区分
            //        string setKbn = "";
            //        setKbn = GetTranceKBN(stockAcPayHisDt.AcPayTransCd);
            //        dr[COL_TRANSDIV] = setKbn;
                    
            //        // 移動前・移動後
            //        dr[COL_BFSECTIONGUIDENM] = stockAcPayHisDt.BfSectionGuideNm;
            //        dr[COL_BFENTERWAREHNAME] = stockAcPayHisDt.BfEnterWarehName;
            //        dr[COL_AFSECTIONGUIDENM] = stockAcPayHisDt.AfSectionGuideNm;
            //        dr[COL_AFENTERWAREHNAME] = stockAcPayHisDt.AfEnterWarehName;

            //        // 商品コード
            //        dr[COL_GOODSCODE] = stockAcPayHisDt.GoodsCode;

            //        // 商品名称
            //        dr[COL_GOODSNM] = stockAcPayHisDt.GoodsName;
            //        // 入荷数
            //        dr[COL_ARRIVALGOODSCNT] = stockAcPayHisDt.ArrivalCnt;
            //        // 出荷数
            //        dr[COL_SHIPMCNT] = stockAcPayHisDt.ShipmentCnt;
            //        // 在庫数
            //        dr[COL_STOCKCNT] = stockAcPayHisDt.SupplierStock + stockAcPayHisDt.TrustCount;

            //        // 受払先
            //        dr[COL_RECVPYEECUST] = stockAcPayHisDt.CustomerName;

            //        // 拠点
            //        dr[COL_SECTIONNAME] = GetSectionName(stockAcPayHisDt.SectionCode);

            //        // 機種
            //        dr[COL_MODEL] = stockAcPayHisDt.CellphoneModelName;
            //        // 事業者
            //        dr[COL_CARRIEREP] = stockAcPayHisDt.CarrierEpName;
                    
            //        // 製造番号
            //        dr[COL_PRODUCTNO] = stockAcPayHisDt.ProductNumber;
            //        // SIM製造番号
            //        dr[COL_SIMPRODUCENO] = stockAcPayHisDt.SimProductNumber;
            //        // 携帯番号
            //        dr[COL_CPHONENO] = stockAcPayHisDt.StockTelNo1;
            //        // 倉庫
            //        //                dr[COL_WAREHOUSE] = _mainWkHist.BfEnterWarehName;
            //        // 元伝票番号
            //        // 備考
            //        dr[COL_ACPAYNOTE] = stockAcPayHisDt.AcPayNote;


            //        ds.Tables[TBL_HISTORY].Rows.Add(dr);
            //    }
            //}
            //else
            //{
            //    //製番なし

                //StockAcPayHist[] _mainWkHisArray = null;
                //StockAcPayHist _mainWkHist = null;

                //int ii = 0;
                ////配列データの取得
                //_mainWkHisArray = new StockAcPayHist[_stockAcPayHistList.Count];
                //foreach (Object wkObj in _stockAcPayHistList)
                //{
                //    if (wkObj is StockAcPayHist)
                //    {
                //        _mainWkHist = (StockAcPayHist)wkObj;
                //        _mainWkHisArray[ii] = _mainWkHist;
                //        ii++;
                //    }
                //}

                //// グリッド用データセット初期化
                //CreateGridSchema(false);

                //int i = 1;

                //foreach (StockAcPayHist stockAcPayHist in _mainWkHisArray)
                //{
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //    //DataRow dr = ds.Tables[TBL_HISTORY].NewRow();
                //    DataRow dr = ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].NewRow();
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //    // 計上年月

                //    if (stockAcPayHist.tde_st_IoGoodsDay == DateTime.MinValue)
                //    {
                //    }
                //    else
                //    {
                //        dr[COL_tde_st_IoGoodsDay] = stockAcPayHist.tde_st_IoGoodsDay;
                //    }
                //    dr[COL_ROWNUM] = i;
                //    i++;

                //    // 伝票番号
                //    dr[COL_SLIPNO] = stockAcPayHist.AcPaySlipNum;

                //    // 伝票区分
                //    string denKbn = "";
                //    denKbn = GetSlipKbn(stockAcPayHist.AcPaySlipCd);
                //    dr[COL_SLIPCD] = denKbn;

                //    // 取引区分
                //    string setKbn = "";
                //    setKbn = GetTranceKBN(stockAcPayHist.AcPayTransCd);
                //    dr[COL_TRANSDIV] = setKbn;

                //    // 拠点
                //    dr[COL_SECTIONNAME] = GetSectionName(stockAcPayHist.SectionCode);

                //    // 商品コード
                //    dr[COL_GOODSCODE] = stockAcPayHist.GoodsCode;
                //    // 商品名称
                //    dr[COL_GOODSNM] = stockAcPayHist.GoodsName;
                //    // 入荷数
                //    dr[COL_ARRIVALGOODSCNT] = stockAcPayHist.ArrivalCnt;
                //    // 出荷数
                //    dr[COL_SHIPMCNT] = stockAcPayHist.ShipmentCnt;
                //    // 在庫数
                //    dr[COL_STOCKCNT] = stockAcPayHist.SupplierStock + stockAcPayHist.TrustCount;
                //    // 出荷未計上残
                //    // 入荷未計上算
                    
                //    // 受払先
                //    dr[COL_RECVPYEECUST] = stockAcPayHist.CustomerName;
                //    // 機種
                //    dr[COL_MODEL] = stockAcPayHist.CellphoneModelName;

                //    // 移動元拠点
                //    dr[COL_BFSECTIONGUIDENM] = stockAcPayHist.BfSectionGuideNm;

                //    // 移動元倉庫
                //    dr[COL_BFENTERWAREHNAME] = stockAcPayHist.BfEnterWarehName;

                //    // 移動先拠点
                //    dr[COL_AFSECTIONGUIDENM] = stockAcPayHist.AfSectionGuideNm;

                //    // 移動先倉庫
                //    dr[COL_AFENTERWAREHNAME] = stockAcPayHist.AfEnterWarehName;

                //    //備考
                //    dr[COL_ACPAYNOTE] = stockAcPayHist.AcPayNote;

                //    ds.Tables[TBL_HISTORY].Rows.Add(dr);
                //}
            //}
            //return st;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            int status = 0;

            ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Clear();

            int rowNo = 1;

            /* -----DEL 2008/07/17 使用クラス変更の為 ----------------------------------->>>>>
            foreach (StockAcPayHist stockAcPayHist in this._stockAcPayHistList)
            {
                CopyToDataRowFromStockAcPayHist( stockAcPayHist, rowNo++ );
            }
               -----DEL 2008/07/17 ------------------------------------------------------<<<<< */
            // -----ADD 2008/07/17 ------------------------------------------------------>>>>>
            foreach (StockAcPayHisSearchRet stockAcPayHisSearchRet in this._stockAcPayHisSearchRetList)
            {
                // グリッド表示
                CopyToDataRowFromStockAcPayHist(stockAcPayHisSearchRet, rowNo++);
            }

            // ラベル表示
            foreach (StockCarEnterCarOutRet stockCarEnterCarOutRet in this._stockCarEnterCarOutRetList)
            {
                this.lb_LMonthStockCnt.Text = stockCarEnterCarOutRet.StockTotal.ToString("#,##0.00");           // 前月末残
                this.lb_ArrivalCntTotal.Text = stockCarEnterCarOutRet.ArrivalCnt.ToString("#,##0.00");          // 入庫計
                this.lb_ShipmentCntTotal.Text = stockCarEnterCarOutRet.ShipmentCnt.ToString("#,##0.00");        // 出庫計
                this.lb_StCarryForwardCnt.Text = stockCarEnterCarOutRet.RemainCount.ToString("#,##0.00");       // 残数
                break;
            }
            
            double gridArravalTotal = 0;
            double gridShipmentTotal = 0;
            foreach ( DataRow dataRow in ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows )
            {
                // 入庫数計算出
                if (dataRow[MAZAI04311EC.ct_Col_ArrivalCnt].ToString() != "")
                {
                    //gridArravalTotal += double.Parse(dataRow[MAZAI04311EC.ct_Col_ArrivalCnt].ToString().Replace(",", ""));        //DEL 2008/09/29 仕様変更
                    // ---ADD 2008/09/29 ----------------------------------------------------------------------------------------------------------------->>>>> 
                    // "("が含まれているものは対象としない
                    if (dataRow[MAZAI04311EC.ct_Col_ArrivalCnt].ToString().Contains("("))
                    {
                        gridArravalTotal += 0;
                    }
                    else
                    {
                        gridArravalTotal += double.Parse(dataRow[MAZAI04311EC.ct_Col_ArrivalCnt].ToString().Replace(",", ""));
                    }
                    // ---ADD 2008/09/29 -----------------------------------------------------------------------------------------------------------------<<<<< 
                }
                // 出庫数計算出
                if ( dataRow[MAZAI04311EC.ct_Col_ShipmentCnt].ToString() != "" )
                {
                    //gridShipmentTotal += double.Parse(dataRow[MAZAI04311EC.ct_Col_ShipmentCnt].ToString().Replace(",",""));       //DEL 2008/09/29 仕様変更
                    // ---ADD 2008/09/29 ----------------------------------------------------------------------------------------------------------------->>>>> 
                    // "("が含まれているものは対象としない
                    if (dataRow[MAZAI04311EC.ct_Col_ShipmentCnt].ToString().Contains("("))
                    {
                        gridShipmentTotal += 0;
                    }
                    else
                    {
                        gridShipmentTotal += double.Parse(dataRow[MAZAI04311EC.ct_Col_ShipmentCnt].ToString().Replace(",", ""));
                    }
                    // ---ADD 2008/09/29 -----------------------------------------------------------------------------------------------------------------<<<<< 
                }
            }
            this.lb_GridArrivalTotal.Text = gridArravalTotal.ToString("#,##0.00");      // 入庫数計
            this.lb_GridShipmentTotal.Text = gridShipmentTotal.ToString("#,##0.00");    // 出庫数計
            // -----ADD 2008/07/17 ------------------------------------------------------<<<<<
            
            return status;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// データコピー処理（StockAcPayHisSearchRet → DataRow）
        /// </summary>
        /// <param name="stockAcPayHisSearchRet"></param>
        /// <param name="rowNo"></param>
        /* -----DEL 2008/07/17 使用クラス変更の為 ----------------------------------------------------------------------->>>>>
        private void CopyToDataRowFromStockAcPayHist(StockAcPayHist stockAcPayHist, int rowNo)
        {
            DataRow row = ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].NewRow();

            row[MAZAI04311EC.ct_Col_IoGoodsDay] = stockAcPayHist.IoGoodsDay; // 入出荷日
            row[MAZAI04311EC.ct_Col_AcPaySlipCd] = stockAcPayHist.AcPaySlipCd; // 受払元伝票区分
            row[MAZAI04311EC.ct_Col_AcPaySlipNum] = stockAcPayHist.AcPaySlipNum; // 受払元伝票番号
            row[MAZAI04311EC.ct_Col_AcPaySlipRowNo] = stockAcPayHist.AcPaySlipRowNo; // 受払元行番号
            row[MAZAI04311EC.ct_Col_AcPayHistDateTime] = stockAcPayHist.AcPayHistDateTime; // 受払履歴作成日時
            row[MAZAI04311EC.ct_Col_AcPayTransCd] = stockAcPayHist.AcPayTransCd; // 受払元取引区分
            row[MAZAI04311EC.ct_Col_InputAgenCd] = stockAcPayHist.InputAgenCd; // 入力担当者コード
            row[MAZAI04311EC.ct_Col_InputAgenNm] = stockAcPayHist.InputAgenNm; // 入力担当者名称
            row[MAZAI04311EC.ct_Col_CustSlipNo] = stockAcPayHist.CustSlipNo; // 相手先伝票番号
            row[MAZAI04311EC.ct_Col_SlipDtlNum] = stockAcPayHist.SlipDtlNum; // 明細通番
            row[MAZAI04311EC.ct_Col_AcPayNote] = stockAcPayHist.AcPayNote; // 受払備考
            row[MAZAI04311EC.ct_Col_SectionCode] = stockAcPayHist.SectionCode; // 拠点コード
            row[MAZAI04311EC.ct_Col_SectionGuideNm] = stockAcPayHist.SectionGuideNm; // 拠点ガイド名称
            row[MAZAI04311EC.ct_Col_WarehouseCode] = stockAcPayHist.WarehouseCode; // 倉庫コード
            row[MAZAI04311EC.ct_Col_WarehouseName] = stockAcPayHist.WarehouseName; // 倉庫名称
            row[MAZAI04311EC.ct_Col_ShelfNo] = stockAcPayHist.ShelfNo; // 棚番
            row[MAZAI04311EC.ct_Col_ArrivalCnt] = stockAcPayHist.ArrivalCnt; // 入荷数
            row[MAZAI04311EC.ct_Col_ShipmentCnt] = stockAcPayHist.ShipmentCnt; // 出荷数
            row[MAZAI04311EC.ct_Col_ListPriceTaxExcFl] = stockAcPayHist.ListPriceTaxExcFl; // 定価（税抜，浮動）
            row[MAZAI04311EC.ct_Col_StockUnitPriceFl] = stockAcPayHist.StockUnitPriceFl; // 仕入単価（税抜，浮動）
            row[MAZAI04311EC.ct_Col_StockPrice] = stockAcPayHist.StockPrice; // 仕入金額
            row[MAZAI04311EC.ct_Col_SupplierStock] = stockAcPayHist.SupplierStock; // 仕入在庫数
            row[MAZAI04311EC.ct_Col_AcpOdrCount] = stockAcPayHist.AcpOdrCount; // 受注数
            row[MAZAI04311EC.ct_Col_SalesOrderCount] = stockAcPayHist.SalesOrderCount; // 発注数
            row[MAZAI04311EC.ct_Col_MovingSupliStock] = stockAcPayHist.MovingSupliStock; // 移動中仕入在庫数
            row[MAZAI04311EC.ct_Col_NonAddUpShipmCnt] = stockAcPayHist.NonAddUpShipmCnt; // 出荷数（未計上）
            row[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt] = stockAcPayHist.NonAddUpArrGdsCnt; // 入荷数（未計上）
            row[MAZAI04311EC.ct_Col_ShipmentPosCnt] = stockAcPayHist.ShipmentPosCnt; // 出荷可能数


            row[MAZAI04311EC.ct_Col_RowNo] = rowNo; // 行番号


            // 伝票区分名称
            row[MAZAI04311EC.ct_Col_AcPaySlipNm] = GetAcPaySlipNm( stockAcPayHist.AcPaySlipCd );

            // 取引区分名称
            row[MAZAI04311EC.ct_Col_AcPayTransNm] = GetAcPayTransNm( stockAcPayHist.AcPayTransCd );


            // 受払先名称（伝票区分に依存）
            switch ( stockAcPayHist.AcPaySlipCd )
            {
                // 30:移動出荷
                case 30:
                    // 移動先拠点ガイド名＋移動先倉庫名
                    row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = string.Format( "{0} : {1}", stockAcPayHist.AfSectionGuideNm, stockAcPayHist.AfEnterWarehName );
                    break;
                // 31:移動入荷
                case 31:
                    // 移動元拠点ガイド名＋移動元倉庫名
                    row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = string.Format( "{0} : {1}", stockAcPayHist.BfSectionGuideNm, stockAcPayHist.BfEnterWarehName );
                    break;
                // その他
                default:
                    // 得意先略称
                    row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = stockAcPayHist.CustomerSnm;
                    break;
            }   

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( _stockAcPaySlipOfAdjustList.Contains( stockAcPayHist.AcPaySlipCd ) )
            //{
            //    // ※在庫調整関連は入庫数の符号で判定する

            //    if ( stockAcPayHist.ArrivalCnt >= 0 )
            //    {
            //        // 入庫
            //        row[MAZAI04311EC.ct_Col_ArrivalPrice] = stockAcPayHist.StockPrice.ToString( "#,##0" ); // 仕入金額をセット
            //        row[MAZAI04311EC.ct_Col_ArrivalCnt] = stockAcPayHist.ArrivalCnt;

            //        row[MAZAI04311EC.ct_Col_ShipmentPrice] = string.Empty;
            //        row[MAZAI04311EC.ct_Col_ShipmentCnt] = DBNull.Value;
            //    }
            //    else
            //    {
            //        // 出庫
            //        row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHist.StockPrice.ToString( "#,##0" ); // 仕入金額をセット
            //        row[MAZAI04311EC.ct_Col_ShipmentCnt] = -1 * stockAcPayHist.ArrivalCnt;  // マイナスの入庫数を反転してセットする

            //        row[MAZAI04311EC.ct_Col_ArrivalPrice] = string.Empty;
            //        row[MAZAI04311EC.ct_Col_ArrivalCnt] = DBNull.Value;
            //    }
            //}
            //else
            //{
            //    //-------------------------------------------------------------
            //    // 入庫数・入庫金額
            //    //-------------------------------------------------------------
            //    if ( _stockAcPaySlipOfArrivalList.Contains( stockAcPayHist.AcPaySlipCd ) )
            //    {
            //        row[MAZAI04311EC.ct_Col_ArrivalPrice] = stockAcPayHist.StockPrice.ToString( "#,##0" ); // 仕入金額をセット
            //    }
            //    else
            //    {
            //        row[MAZAI04311EC.ct_Col_ArrivalPrice] = string.Empty;
            //        row[MAZAI04311EC.ct_Col_ArrivalCnt] = DBNull.Value;
            //    }
            //    //-------------------------------------------------------------
            //    // 出庫数・出庫金額
            //    //-------------------------------------------------------------
            //    if ( _stockAcPaySlipOfShipmentList.Contains( stockAcPayHist.AcPaySlipCd ) )
            //    {
            //        row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHist.StockPrice.ToString( "#,##0" ); // 仕入金額をセット
            //    }
            //    else
            //    {
            //        row[MAZAI04311EC.ct_Col_ShipmentPrice] = string.Empty;
            //        row[MAZAI04311EC.ct_Col_ShipmentCnt] = DBNull.Value;
            //    }
            //}

            //-------------------------------------------------------------
            // 入庫数・仕入金額
            //-------------------------------------------------------------
            if ( _stockAcPaySlipOfArrivalList.Contains( stockAcPayHist.AcPaySlipCd ) )
            {
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = stockAcPayHist.StockPrice.ToString( "#,##0" ); // 入庫金額←仕入金額をセット

                // 出庫はクリア
                row[MAZAI04311EC.ct_Col_ShipmentPrice] = string.Empty;
                row[MAZAI04311EC.ct_Col_ShipmentCnt] = DBNull.Value;
            }
            //-------------------------------------------------------------
            // 出庫数・仕入金額（移動出荷の場合）
            //-------------------------------------------------------------
            else if ( _stockAcPaySlipOfShipmentList.Contains( stockAcPayHist.AcPaySlipCd ) )
            {
                row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHist.StockPrice.ToString( "#,##0" ); // 出庫金額←仕入金額をセット

                // 入庫はクリア
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = string.Empty;
                row[MAZAI04311EC.ct_Col_ArrivalCnt] = DBNull.Value;
            }
            //-------------------------------------------------------------
            // 出庫数・売上金額
            //-------------------------------------------------------------
            else if ( _stockAcPaySlipOfSalesList.Contains( stockAcPayHist.AcPaySlipCd ) )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 仕様が二転三転していて分かりにくいですが、売上・出荷などでも出庫金額は仕入金額をセットします
                //row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHist.SalesMoney.ToString( "#,##0" ); // 出庫金額←売上金額をセット
                row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHist.StockPrice.ToString( "#,##0" ); // 出庫金額←仕入金額をセット
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 入庫はクリア
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = string.Empty;
                row[MAZAI04311EC.ct_Col_ArrivalCnt] = DBNull.Value;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows.Add( row );
        }
           -----DEL 2008/07/17 ------------------------------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 ------------------------------------------------------------------------------------------>>>>>
        private void CopyToDataRowFromStockAcPayHist(StockAcPayHisSearchRet stockAcPayHisSearchRet, int rowNo)
        {
            DataRow row = ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].NewRow();

            row[MAZAI04311EC.ct_Col_IoGoodsDay] = stockAcPayHisSearchRet.IoGoodsDay; // 入出荷日
            row[MAZAI04311EC.ct_Col_AcPaySlipCd] = stockAcPayHisSearchRet.AcPaySlipCd; // 受払元伝票区分
            //row[MAZAI04311EC.ct_Col_AcPaySlipNum] = stockAcPayHisSearchRet.AcPaySlipNum; // 受払元伝票番号        //DEL 2008/12/09 不具合対応[8877]
            // --- ADD 2008/12/09 不具合対応[8877] ----------------------------------------------------->>>>>
            int acPaySlipNum = 0;
            int.TryParse(stockAcPayHisSearchRet.AcPaySlipNum,out acPaySlipNum);
            row[MAZAI04311EC.ct_Col_AcPaySlipNum] = acPaySlipNum.ToString("000000000"); // 受払元伝票番号
            // --- ADD 2008/12/09 不具合対応[8877] -----------------------------------------------------<<<<<

            row[MAZAI04311EC.ct_Col_AcPaySlipRowNo] = stockAcPayHisSearchRet.AcPaySlipRowNo; // 受払元行番号
            row[MAZAI04311EC.ct_Col_AcPayHistDateTime] = stockAcPayHisSearchRet.AcPayHistDateTime; // 受払履歴作成日時
            row[MAZAI04311EC.ct_Col_AcPayTransCd] = stockAcPayHisSearchRet.AcPayTransCd; // 受払元取引区分
            row[MAZAI04311EC.ct_Col_InputAgenCd] = stockAcPayHisSearchRet.InputAgenCd; // 入力担当者コード
            row[MAZAI04311EC.ct_Col_InputAgenNm] = stockAcPayHisSearchRet.InputAgenNm; // 入力担当者名称
            row[MAZAI04311EC.ct_Col_CustSlipNo] = stockAcPayHisSearchRet.CustSlipNo; // 相手先伝票番号
            row[MAZAI04311EC.ct_Col_SlipDtlNum] = stockAcPayHisSearchRet.SlipDtlNum; // 明細通番
            row[MAZAI04311EC.ct_Col_AcPayNote] = stockAcPayHisSearchRet.AcPayNote; // 受払備考
            row[MAZAI04311EC.ct_Col_SectionCode] = stockAcPayHisSearchRet.SectionCode; // 拠点コード
            row[MAZAI04311EC.ct_Col_SectionGuideNm] = stockAcPayHisSearchRet.SectionGuideNm; // 拠点ガイド名称
            row[MAZAI04311EC.ct_Col_WarehouseCode] = stockAcPayHisSearchRet.WarehouseCode; // 倉庫コード
            row[MAZAI04311EC.ct_Col_WarehouseName] = stockAcPayHisSearchRet.WarehouseName; // 倉庫名称
            row[MAZAI04311EC.ct_Col_ShelfNo] = stockAcPayHisSearchRet.ShelfNo; // 棚番
            /* ---DEL 2008/09/29 仕様変更 --------------------------------------------------------------------->>>>>
            //row[MAZAI04311EC.ct_Col_ArrivalCnt] = stockAcPayHisSearchRet.ArrivalCnt; // 入荷数
            //row[MAZAI04311EC.ct_Col_ShipmentCnt] = stockAcPayHisSearchRet.ShipmentCnt; // 出荷数
               ---DEL 2008/09/29 ------------------------------------------------------------------------------<<<<< */
            row[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl] = stockAcPayHisSearchRet.SalesUnPrcTaxExcFl; // 出庫単価    ADD 2008/09/29

            row[MAZAI04311EC.ct_Col_ListPriceTaxExcFl] = stockAcPayHisSearchRet.ListPriceTaxExcFl; // 定価（税抜，浮動）
            row[MAZAI04311EC.ct_Col_StockUnitPriceFl] = stockAcPayHisSearchRet.StockUnitPriceFl; // 仕入単価（税抜，浮動）
            row[MAZAI04311EC.ct_Col_StockPrice] = stockAcPayHisSearchRet.StockPrice; // 仕入金額
            row[MAZAI04311EC.ct_Col_SupplierStock] = stockAcPayHisSearchRet.SupplierStock; // 仕入在庫数
            row[MAZAI04311EC.ct_Col_AcpOdrCount] = stockAcPayHisSearchRet.AcpOdrCount; // 受注数
            row[MAZAI04311EC.ct_Col_SalesOrderCount] = stockAcPayHisSearchRet.SalesOrderCount; // 発注数
            row[MAZAI04311EC.ct_Col_MovingSupliStock] = stockAcPayHisSearchRet.MovingSupliStock; // 移動中仕入在庫数
            row[MAZAI04311EC.ct_Col_GoodsNo] = stockAcPayHisSearchRet.GoodsNo;                  // 品番             ADD 2008/12/09 不具合対応[8895]
            /* ---DEL 2008/09/29 仕様変更 --------------------------------------------------------------------->>>>>
            row[MAZAI04311EC.ct_Col_NonAddUpShipmCnt] = stockAcPayHisSearchRet.NonAddUpShipmCnt; // 出荷数（未計上）
            row[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt] = stockAcPayHisSearchRet.NonAddUpArrGdsCnt; // 入荷数（未計上）
               ---DEL 2008/09/29 ------------------------------------------------------------------------------<<<<< */
            // ---ADD 2008/09/29 ------------------------------------------------------------------------------>>>>>
            // 出荷数（未計上）
            if (stockAcPayHisSearchRet.AcPaySlipCd == 22)
            {
                // 伝票区分「22：出荷」時、表示
                row[MAZAI04311EC.ct_Col_NonAddUpShipmCnt] = stockAcPayHisSearchRet.NonAddUpShipmCnt;
            }
            else
            {
                row[MAZAI04311EC.ct_Col_NonAddUpShipmCnt] = DBNull.Value;
            }
            // 入荷数（未計上）
            if (stockAcPayHisSearchRet.AcPaySlipCd == 11)
            {
                // 伝票区分「11：入荷」時、表示
                row[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt] = stockAcPayHisSearchRet.NonAddUpArrGdsCnt;
            }
            else
            {
                row[MAZAI04311EC.ct_Col_NonAddUpArrGdsCnt] = DBNull.Value;
            }
            // ---ADD 2008/09/29 ------------------------------------------------------------------------------<<<<<
            row[MAZAI04311EC.ct_Col_ShipmentPosCnt] = stockAcPayHisSearchRet.ShipmentPosCnt; // 出荷可能数

            row[MAZAI04311EC.ct_Col_RowNo] = rowNo; // 行番号


            // 伝票区分名称
            row[MAZAI04311EC.ct_Col_AcPaySlipNm] = GetAcPaySlipNm(stockAcPayHisSearchRet.AcPaySlipCd);

            // 取引区分名称
            row[MAZAI04311EC.ct_Col_AcPayTransNm] = GetAcPayTransNm(stockAcPayHisSearchRet.AcPayTransCd);


            // 受払先名称（伝票区分に依存）
            switch (stockAcPayHisSearchRet.AcPaySlipCd)
            {
                // 30:移動出荷
                case 30:
                    // 移動先拠点ガイド名＋移動先倉庫名
                    row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = string.Format("{0} : {1}", stockAcPayHisSearchRet.AfSectionGuideNm, stockAcPayHisSearchRet.AfEnterWarehName);
                    break;
                // 31:移動入荷
                case 31:
                    // 移動元拠点ガイド名＋移動元倉庫名
                    row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = string.Format("{0} : {1}", stockAcPayHisSearchRet.BfSectionGuideNm, stockAcPayHisSearchRet.BfEnterWarehName);
                    break;
                // --- ADD 2008/12/09 不具合対応[8754] ---------------------------------------------->>>>>
                // 10:仕入
                case 10:
                    row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = stockAcPayHisSearchRet.SupplierSnm;
                    break;
                // --- ADD 2008/12/09 不具合対応[8754] ----------------------------------------------<<<<<
                // その他
                default:
                    // 2009.02.12 30413 犬飼 得意先略称が空の場合は、仕入先略称を表示 >>>>>>START
                    //// 得意先略称
                    //row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = stockAcPayHisSearchRet.CustomerSnm;
                    if (!string.IsNullOrEmpty(stockAcPayHisSearchRet.CustomerSnm))
                    {
                        // 得意先略称
                        row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = stockAcPayHisSearchRet.CustomerSnm;
                    }
                    else
                    {
                        // 仕入先略称
                        row[MAZAI04311EC.ct_Col_AcPayOtherPartyNm] = stockAcPayHisSearchRet.SupplierSnm;
                    }
                    // 2009.02.12 30413 犬飼 得意先略称が空の場合は、仕入先略称を表示 <<<<<<END
                    break;
            }

            // ---ADD 2008/09/29 ------------------------------------------------------------------------>>>>>
            // 入荷数・出荷数
            // ※受払元伝票区分が10:仕入 or 20:売上 且つ入出荷日に値がセットされていない場合、()で囲んで表示し、
            //   繰越数の計算対象外とする
            /* ---DEL 2009/02/09 不具合対応[11007] ------------------------------------------------->>>>>
            if (((stockAcPayHisSearchRet.AcPaySlipCd == 10) || (stockAcPayHisSearchRet.AcPaySlipCd == 20)) &&
                (string.IsNullOrEmpty(stockAcPayHisSearchRet.IoGoodsDay.ToString())))
               ---DEL 2009/02/09 不具合対応[11007] -------------------------------------------------<<<<< */
            // ---ADD 2009/02/09 不具合対応[11007] ------------------------------------------------->>>>>
            if (((stockAcPayHisSearchRet.AcPaySlipCd == 10) || (stockAcPayHisSearchRet.AcPaySlipCd == 20)) &&
                (stockAcPayHisSearchRet.IoGoodsDay == DateTime.MinValue))
            // ---ADD 2009/02/09 不具合対応[11007] -------------------------------------------------<<<<<
            {
                row[MAZAI04311EC.ct_Col_ArrivalCnt] = string.Format("({0})",stockAcPayHisSearchRet.ArrivalCnt.ToString("#,##0.00"));    // 入荷数
                row[MAZAI04311EC.ct_Col_ShipmentCnt] = string.Format("({0})", stockAcPayHisSearchRet.ShipmentCnt.ToString("#,##0.00")); // 出荷数
                row[MAZAI04311EC.ct_Col_IoGoodsDay] = stockAcPayHisSearchRet.AddUpADate;        //計上日    //ADD 2009/02/09 不具合対応[11007]
            }
            else
            {
                row[MAZAI04311EC.ct_Col_ArrivalCnt] = stockAcPayHisSearchRet.ArrivalCnt.ToString("#,##0.00");       // 入荷数
                row[MAZAI04311EC.ct_Col_ShipmentCnt] = stockAcPayHisSearchRet.ShipmentCnt.ToString("#,##0.00");     // 出荷数
            }
            // ---ADD 2008/09/29 ------------------------------------------------------------------------<<<<<

            /* ---DEL 2008/12/09 不具合対応[8827] ---------------------------------------------------------------------------------->>>>>
            //-------------------------------------------------------------
            // 入庫数・仕入金額
            //-------------------------------------------------------------
            if (_stockAcPaySlipOfArrivalList.Contains(stockAcPayHisSearchRet.AcPaySlipCd))
            {
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = stockAcPayHisSearchRet.StockPrice.ToString("#,##0"); // 入庫金額←仕入金額をセット

                // 出庫はクリア
                row[MAZAI04311EC.ct_Col_ShipmentPrice] = string.Empty;
                row[MAZAI04311EC.ct_Col_ShipmentCnt] = DBNull.Value;
            }
            //-------------------------------------------------------------
            // 出庫数・仕入金額（移動出荷の場合）
            //-------------------------------------------------------------
            else if (_stockAcPaySlipOfShipmentList.Contains(stockAcPayHisSearchRet.AcPaySlipCd))
            {
                row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHisSearchRet.StockPrice.ToString("#,##0"); // 出庫金額←仕入金額をセット

                // 入庫はクリア
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = string.Empty;
                row[MAZAI04311EC.ct_Col_ArrivalCnt] = DBNull.Value;
            }
            //-------------------------------------------------------------
            // 出庫数・売上金額
            //-------------------------------------------------------------
            else if (_stockAcPaySlipOfSalesList.Contains(stockAcPayHisSearchRet.AcPaySlipCd))
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 仕様が二転三転していて分かりにくいですが、売上・出荷などでも出庫金額は仕入金額をセットします
                //row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHist.SalesMoney.ToString( "#,##0" ); // 出庫金額←売上金額をセット
                row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHisSearchRet.StockPrice.ToString("#,##0"); // 出庫金額←仕入金額をセット
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 入庫はクリア
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = string.Empty;
                row[MAZAI04311EC.ct_Col_ArrivalCnt] = DBNull.Value;
            }
               ---DEL 2008/12/09 不具合対応[8827] ----------------------------------------------------------------------------------<<<<< */
            // ---ADD 2008/12/09 不具合対応[8827] ---------------------------------------------------------------------------------->>>>>
            // 10：仕入、11：入荷、13：在庫仕入、31：移動入荷、40：調整、42：マスタメンテ、50：棚卸、60：組立、61：分解、70：補充入庫
            if (_stockAcPaySlipOfArrivalList.Contains(stockAcPayHisSearchRet.AcPaySlipCd))
            {
                //入庫数は上でセットしている
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = stockAcPayHisSearchRet.StockPrice.ToString("#,##0");    // 入庫金額
                row[MAZAI04311EC.ct_Col_StockUnitPriceFl] = stockAcPayHisSearchRet.StockUnitPriceFl;            // 入庫単価

                row[MAZAI04311EC.ct_Col_ShipmentPrice] = string.Empty;                                          // 出庫金額
                row[MAZAI04311EC.ct_Col_ShipmentCnt] = DBNull.Value;                                            // 出庫数
                row[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl] = DBNull.Value;                                     // 出庫単価
            }
            // 12：受計上、20：売上、21：売計上、22：出荷、23：売切、30：移動出荷、41：半黒、71：補充出庫
            else if (_stockAcPaySlipOfShipmentList.Contains(stockAcPayHisSearchRet.AcPaySlipCd))
            {
                row[MAZAI04311EC.ct_Col_ArrivalPrice] = string.Empty;                                           // 入庫金額
                row[MAZAI04311EC.ct_Col_ArrivalCnt] = DBNull.Value;                                             // 入庫数
                row[MAZAI04311EC.ct_Col_StockUnitPriceFl] = DBNull.Value;                                       // 入庫単価

                //出庫数は上でセットしている
                row[MAZAI04311EC.ct_Col_ShipmentPrice] = stockAcPayHisSearchRet.SalesMoney.ToString("#,##0");   // 出庫金額
                row[MAZAI04311EC.ct_Col_SalesUnPrcTaxExcFl] = stockAcPayHisSearchRet.SalesUnPrcTaxExcFl;        // 出庫単価
            }
            // ---ADD 2008/12/09 不具合対応[8827] ----------------------------------------------------------------------------------<<<<<

            ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows.Add(row);
        }
        // -----ADD 2008/07/17 ------------------------------------------------------------------------------------------<<<<<

        /// <summary>
        /// 伝票区分名称取得
        /// </summary>
        /// <param name="acPaySlipCd"></param>
        /// <returns></returns>
        private string GetAcPaySlipNm ( int acPaySlipCd )
        {
            if ( this._acPaySlipNmDic.ContainsKey( acPaySlipCd ) )
            {
                return this._acPaySlipNmDic[acPaySlipCd];
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 取引区分名称取得
        /// </summary>
        /// <param name="acPayTransCd"></param>
        /// <returns></returns>
        private string GetAcPayTransNm ( int acPayTransCd )
        {
            if ( this._acPayTransNmDic.ContainsKey( acPayTransCd ) )
            {
                return this._acPayTransNmDic[acPayTransCd];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 伝票区分名称ディクショナリ生成
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> CreateAcPaySlipNmDictionary ()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add( 10, "仕入" );
            dic.Add( 11, "入荷" );
            dic.Add( 12, "受計上" );
            dic.Add( 13, "在庫仕入");           //ADD 2008/12/09
            dic.Add( 20, "売上" );
            dic.Add( 21, "売計上" );
            // 2009.03.18 30413 犬飼 出荷を貸出に変更 >>>>>>START
            //dic.Add( 22, "出荷" );
            dic.Add(22, "貸出");
            // 2009.03.18 30413 犬飼 出荷を貸出に変更 <<<<<<END
            dic.Add(23, "売切");
            dic.Add( 30, "移動出荷" );
            dic.Add( 31, "移動入荷" );
            dic.Add( 40, "調整" );
            dic.Add( 41, "半黒" );
            dic.Add( 42, "マスタメンテ");       //ADD 2008/11/28
            dic.Add( 50, "棚卸" );
            // --- ADD 2008/09/29 ----->>>>>
            dic.Add( 60, "組立");
            dic.Add( 61, "分解");
            dic.Add( 70, "補充入庫");
            dic.Add( 71, "補充出庫");
            // --- ADD 2008/09/29 -----<<<<<

            return dic;
        }
        /// <summary>
        /// 取引区分名称ディクショナリ生成
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> CreateAcPayTransNmDictionary ()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add( 10, "通常" );
            dic.Add( 11, "返品" );
            dic.Add( 12, "値引" );
            dic.Add( 20, "赤伝" );
            dic.Add( 21, "削除" );
            dic.Add( 22, "解除" );
            dic.Add( 30, "在庫数調整" );
            dic.Add( 31, "原価調整" );
            dic.Add( 32, "製番調整" );
            dic.Add( 33, "不良品" );
            dic.Add( 34, "抜出" );
            dic.Add( 35, "消去" );
            dic.Add( 36, "一括登録" );
            dic.Add( 40, "過不足更新" );
            //dic.Add( 90, "取消" );            //DEL 2009/01/28 不具合対応[10619]
            dic.Add( 90, "相殺");               //ADD 2009/01/28 不具合対応[10619]

            return dic;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string GetSectionName(string sectionCode)
        {
            SecInfoSet secInfoSet = new SecInfoSet();
            if (!String.IsNullOrEmpty(sectionCode))
            {
                _secInfoSetAcs.Read(out secInfoSet, _enterprisecode, sectionCode);
            }
            else
            {
                return "";
            }

            return secInfoSet.SectionGuideNm;
        }

		#endregion

        /// <summary>
        /// 初期化
        /// </summary>
        private void Clear()
        {
            AllDispClear(true);

            // --- ADD 2010/11/15 ---------->>>>>
            _MAZAI04310ub = new MAZAI04310UB();
            _MAZAI04310ub.tde_st_IoGoodsDay = this.tde_st_IoGoodsDay.GetLongDate(); //入出荷日
            _MAZAI04310ub.tde_ed_IoGoodsDay = (int)this.tde_ed_IoGoodsDay.GetLongDate();
            _MAZAI04310ub.AcPaySlipCd = (int)this.ce_SlipKindDiv.Value;    //伝票区分(選択INDEX)  
            _MAZAI04310ub.WareHouse = this.tEdit_WarehouseCode.Text.PadLeft(4, '0'); //倉庫コード    //ADD 2009/01/14 不具合対応[9800]
            _MAZAI04310ub.MakerCode = this.tNedit_GoodsMakerCd.GetInt();//メーカー
            _MAZAI04310ub.GoodsCd = this.tEdit_GoodsNo.Text;//商品コード
            // --- ADD 2010/11/15  ----------<<<<<

            // ---DEL 2009/06/26 不具合対応[13625] ----------------------->>>>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////ProductNo_Edit.Focus();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////tne_GoodsMakerCd.Focus();     //DEL 2008/07/17 フォーカス順変更の為
            //tEdit_SectionCodeAllowZero.Focus();      //ADD 2008/07/17    
            // ---DEL 2009/06/26 不具合対応[13625] -----------------------<<<<<
            this.ce_SlipKindDiv.Focus();        //ADD 2009/06/26 不具合対応[13625]

            //this._beforeMakerCd = 0;
            //this._beforeGoodsNo = string.Empty;
            //this._beforeSectionCd = string.Empty;
            //this._beforeWarehouseCd = string.Empty;

            _prevHeaderInfo.GoodsMakerCode = tNedit_GoodsMakerCd.GetInt();
            _prevHeaderInfo.GoodsNo = tEdit_GoodsNo.Text.TrimEnd();
            //_prevHeaderInfo.SectionCode = tEdit_SectionCodeAllowZero.Text.TrimEnd();      //DEL 2009/06/26 不具合対応[13625]
            _prevHeaderInfo.WarehouseCode = tEdit_WarehouseCode.Text.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }


        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索ボタンが押下された時に処理します</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/07/17</br>
        /// <br>Update Note: 2009/12/04 李侠</br>
        /// <br>             PM.NS-4・保守依頼③の列サイズの自動調整対応</br>
        /// <br>Update Note: 2010/11/15 李占川</br>
        /// <br>             検索処理実行後、フォーカスをグリットへ移動変更</br>
        /// <br>Update Note: 2010/11/15 施ヘイ中</br>
        /// <br>             在庫受払履歴が存在しない場合でも、前月末残と現在庫数を表示するように変更。</br>
        /// </remarks>
        // -----ADD 2008/07/17 ------------------------------------------------------------------------------>>>>>
        private void SearchMain()
        {
            // 画面入力内容のチェック
            Control errorControl;
            string errorMessage;

            if (ScreenInputCheck(out errorControl, out errorMessage) == false)
            {
                // エラーメッセージ表示
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), errorMessage, 0, MessageBoxButtons.OK);

                // エラー発生コントロールにフォーカス移動
                if (errorControl != null)
                {
                    errorControl.Focus();
                }
                return;
            }

            // 画面情報設定
            _MAZAI04310ub = new MAZAI04310UB();
            _MAZAI04310ub.SearchMode = this.SearchMode;                  //検索モード
            _MAZAI04310ub.EnterpriseCode = this._enterprisecode;              //企業コード
            _MAZAI04310ub.GoodsCd = this.tEdit_GoodsNo.Text;            //商品コード
            _MAZAI04310ub.tde_st_IoGoodsDay = this.tde_st_IoGoodsDay.GetDateYear() * 10000
                                            + this.tde_st_IoGoodsDay.GetDateMonth() * 100
                                            + this.tde_st_IoGoodsDay.GetDateDay();     //入出荷日
            _MAZAI04310ub.tde_ed_IoGoodsDay = (int)this.tde_ed_IoGoodsDay.GetLongDate();
            _MAZAI04310ub.AcPaySlipCd = (int)this.ce_SlipKindDiv.Value;    //伝票区分(選択INDEX)            
            // ---DEL 2009/06/26 不具合対応[13625] --------------------------------------->>>>>
            ////_MAZAI04310ub.SectionCd = this.tEdit_SectionCodeAllowZero.Text;          //拠点コード     //DEL 2008/11/28 「00：全社」検索可能とする為
            //// --- ADD 2008/11/28 ---------------------------------------------------->>>>>
            //// 拠点
            //if (this.tEdit_SectionCodeAllowZero.Text == "00")
            //{
            //    //_MAZAI04310ub.SectionCd = string.Empty;           //DEL 2009/01/09 不具合対応[9799]
            //    _MAZAI04310ub.SectionCd = null;                     //ADD 2009/01/09 不具合対応[9799]
            //}
            //else
            //{
            //    _MAZAI04310ub.SectionCd = this.tEdit_SectionCodeAllowZero.Text;
            //}
            //// --- ADD 2008/11/28 ----------------------------------------------------<<<<<
            // ---DEL 2009/06/26 不具合対応[13625] ---------------------------------------<<<<<
            _MAZAI04310ub.SectionCd = null;         //ADD 2009/06/26 不具合対応[13625]

            //_MAZAI04310ub.WareHouse = this.tEdit_WarehouseCode.Text;        //倉庫コード          //DEL 2009/01/14 不具合対応[9800]
            _MAZAI04310ub.WareHouse = this.tEdit_WarehouseCode.Text.PadLeft(4,'0'); //倉庫コード    //ADD 2009/01/14 不具合対応[9800]
            _MAZAI04310ub.MakerCode = this.tNedit_GoodsMakerCd.GetInt();//メーカー
            _MAZAI04310ub.GoodsCd = this.tEdit_GoodsNo.Text;//商品コード
            _MAZAI04310ub.StartCnt = this.History_Grid.Rows.Count;
            //_MAZAI04310ub.StockAcPayHistList = this._stockAcPayHistList;                  //DEL 2008/07/17 使用クラス変更の為
            _MAZAI04310ub.StockAcPayHisSearchRetList = this._stockAcPayHisSearchRetList;    //ADD 2008/07/17

            // 印刷用に条件取得
            GetStockAcPayHisSearchRetListCache();

            //検索
            // 共通処理中画面生成
            SFCMN00299CA form = new SFCMN00299CA();

            try
            {
                // 共通処理中画面プロパティ設定
                form.Title = "読込み中";                            // 画面のタイトル部分に表示する文字列
                form.Message = "履歴データの読込み中です．．．";    // 画面のプログレスバーの上に表示する文字列
                form.DispCancelButton = false;                      // キャンセルボタン押下による中断機能ＯＮ（デフォルトはＯＦＦ）

                // 共通処理中画面表示
                form.Show();

                _MAZAI04310ub.ReadProc();

                //this._stockAcPayHistList = _MAZAI04310ub.StockAcPayHistList;                  //DEL 2008/07/17 使用クラス変更の為
                this._stockAcPayHisSearchRetList = _MAZAI04310ub.StockAcPayHisSearchRetList;    //ADD 2008/07/17
                this._stockCarEnterCarOutRetList = _MAZAI04310ub.StockCarEnterCarOutRetList;    //ADD 2008/07/17

                //if (_stockAcPayHistList != null)          //DEL 2008/07/17 使用クラス変更の為
                if (_stockAcPayHisSearchRetList != null)    //ADD 2008/07/17
                {
                    //if (_stockAcPayHistList.Count != 0)           //DEL 2008/07/17 使用クラス変更の為
                    if (_stockAcPayHisSearchRetList.Count != 0)     //ADD 2008/07/17
                    {
                        // グリッド表示
                        GridDataSet();

                        // 取得データグリッド表示
                        History_Grid.DataSource = _stockAcPayHistView;

                        _gridStateController.SetGridStateToGrid(ref this.History_Grid);

                        // --- DEL 2009/12/04 ---------->>>>>
                        //AutoFitCol_ultraCheckEditor.Checked = false;
                        //AutoFitCol_ultraCheckEditor.Checked = true;
                        // --- DEL 2009/12/04 ----------<<<<<

                        // 繰越数再計算
                        CalcCarryForwardProc();     //ADD 2008/07/17

                        // 印刷/プレビューボタン表示
                        //this.Main_ToolbarsManager.Tools["Print_ButtonTool"].SharedProps.Visible = true;     //ADD 2008/07/17
                        //this.Main_ToolbarsManager.Tools["Preview_ButtonTool"].SharedProps.Visible = true;   //ADD 2008/07/17

                        // --- ADD 2009/01/14 不具合対応[9992] ---------------------------------------------------------->>>>>
                        lb_ShipmentPosCnt.Text = string.Empty;      // 現在庫数
                        lb_AcpOdrCount.Text = string.Empty;         // 受注数                               //ADD 2009/01/14 不具合対応[9852]
                        this.ReadGoodsUnit();
                        // --- ADD 2009/01/14 不具合対応[9992] ----------------------------------------------------------<<<<<

                        form.Close();

                        // --- ADD 2010/11/15 ---------->>>>>
                        this.History_Grid.Focus();
                        this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                        this.History_Grid.Rows[0].Selected = true;
                        // --- ADD 2010/11/15  ----------<<<<<
                    }
                    else
                    {
                        //Gridクリア
                        //ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows.Clear();        //DEL 2008/07/17 同じロジックが存在する為、まとめる
                        GridClear();
                        // --- ADD 2010/11/15 ---------->>>>>
                        lb_ShipmentPosCnt.Text = string.Empty;      // 現在庫数
                        lb_AcpOdrCount.Text = string.Empty;         // 受注数 
                        this.ReadGoodsUnit();
                        this._stockCarEnterCarOutRetList = _MAZAI04310ub.StockCarEnterCarOutRetList;
                        foreach (StockCarEnterCarOutRet stockCarEnterCarOutRet in this._stockCarEnterCarOutRetList)
                        {
                            this.lb_LMonthStockCnt.Text = stockCarEnterCarOutRet.StockTotal.ToString("#,##0.00");
                            break;
                        }
                        // --- ADD 2010/11/15 ---------<<<<<<
                        form.Close();
                        // 該当データなし
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "該当データがありません", 0, MessageBoxButtons.OK);
                    }

                }
                else
                {
                    // グリッド関連クリア
                    GridClear();    //ADD 2008/07/17

                    form.Close();
                    // 該当データなし
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "該当データがありません", 0, MessageBoxButtons.OK);
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// 繰越数再計算            //ADD 2008/07/17 
        /// </summary>
        private void CalcCarryForwardProc()
        {
            if ( ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows.Count == 0 )
            {
                lb_CarryForwardCnt.Text = "0.00";
                return;
            }

            double carryForwardCnt = double.Parse(lb_StCarryForwardCnt.Text.Replace(",", ""));

            //foreach (DataRow dataRow in ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows)
            //{
            //    // 入庫数
            //    if (dataRow[MAZAI04311EC.ct_Col_ArrivalCnt].ToString() != "")
            //    {
            //        carryForwardCnt += double.Parse(dataRow[MAZAI04311EC.ct_Col_ArrivalCnt].ToString().Replace(",",""));
            //    }
            //    // 出庫数
            //    if (dataRow[MAZAI04311EC.ct_Col_ShipmentCnt].ToString() != "")
            //    {
            //        carryForwardCnt -= double.Parse(dataRow[MAZAI04311EC.ct_Col_ShipmentCnt].ToString().Replace(",", ""));
            //    }

            //    dataRow[MAZAI04311EC.ct_Col_CarryForwardCnt] = carryForwardCnt.ToString("#,##0.00");
            //}

            foreach (UltraGridRow dataRow in this.History_Grid.Rows)
            {
                
                // 入庫数
                if (string.IsNullOrEmpty(dataRow.Cells[MAZAI04311EC.ct_Col_ArrivalCnt].Value.ToString()) == false)
                {
                    //carryForwardCnt += (double)dataRow.Cells[MAZAI04311EC.ct_Col_ArrivalCnt].Value;
                    // "("付きは対象としない
                    if (dataRow.Cells[MAZAI04311EC.ct_Col_ArrivalCnt].Value.ToString().Contains("("))
                    {
                        carryForwardCnt += 0;
                    }
                    else
                    {
                        carryForwardCnt += double.Parse(dataRow.Cells[MAZAI04311EC.ct_Col_ArrivalCnt].Value.ToString().Replace(",", ""));
                    }
                }
                // 出庫数
                if (string.IsNullOrEmpty(dataRow.Cells[MAZAI04311EC.ct_Col_ShipmentCnt].Value.ToString()) == false)
                {
                    //carryForwardCnt -= (double)dataRow.Cells[MAZAI04311EC.ct_Col_ShipmentCnt].Value;
                    if (dataRow.Cells[MAZAI04311EC.ct_Col_ShipmentCnt].Value.ToString().Contains("("))
                    {
                        carryForwardCnt -= 0;
                    }
                    else
                    {
                        carryForwardCnt -= double.Parse(dataRow.Cells[MAZAI04311EC.ct_Col_ShipmentCnt].Value.ToString().Replace(",", ""));
                    }
                }
                dataRow.Cells[MAZAI04311EC.ct_Col_CarryForwardCnt].Value = carryForwardCnt;
                dataRow.Update();       //ADD 2009/01/14 不具合対応[9801][9993]
            }


            lb_CarryForwardCnt.Text = carryForwardCnt.ToString("#,##0.00");
        }

        /// <summary>
        /// グリッド関連クリア      //ADD 2008/07/17
        /// </summary>
        private void GridClear()
        {
            // グリッドクリア
            if (ds != null)
            {
                ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef].Rows.Clear();
            }

            // 印刷/プレビューボタン非表示
            this.Main_ToolbarsManager.Tools["Print_ButtonTool"].SharedProps.Visible = false;
            this.Main_ToolbarsManager.Tools["Preview_ButtonTool"].SharedProps.Visible = false;

            // 各種数値初期化
            this.lb_LMonthStockCnt.Text = "0";                  // 前月末残
            this.lb_ArrivalCntTotal.Text = "0";                 // 入庫計
            this.lb_ShipmentCntTotal.Text = "0";                // 在庫計
            this.lb_ShipmentPosCnt.Text = "0";                  // 現在庫数
            this.lb_AcpOdrCount.Text = "0";                     // 受注数       //ADD 2009/01/14 不具合対応[9852]
            this.lb_StCarryForwardCnt.Text = "0";               // 残数
            this.lb_GridArrivalTotal.Text = "0";                // 入庫数計
            this.lb_GridShipmentTotal.Text = "0";               // 出庫数計
            this.lb_CarryForwardCnt.Text = "0";                 // 繰越数
        }

        /// <summary>
        /// 印刷用条件取得      //ADD 2008/07/17
        /// </summary>
        private void GetStockAcPayHisSearchRetListCache()
        {
            // 企業コード
            _stockAcPayListCndtn.EnterpriseCode = this._enterprisecode;

            // 拠点
            /* --- DEL 2009/01/09 不具合対応[9799] ------------------------------------->>>>>
            ArrayList sectionList = new ArrayList(0);
            sectionList.Add(_MAZAI04310ub.SectionCd);
            _stockAcPayListCndtn.SectionCodes = (string[])sectionList.ToArray(typeof(string));
            //_stockAcPayListCndtn.SectionCodes = _MAZAI04310ub.SectionCd;
               --- DEL 2009/01/09 不具合対応[9799] -------------------------------------<<<<< */
            // --- ADD 2009/01/09 不具合対応[9799] ------------------------------------->>>>>
            if (_MAZAI04310ub.SectionCd == null)
            {
                _stockAcPayListCndtn.SectionCodes = null;
            }
            else
            {
                ArrayList sectionList = new ArrayList(0);
                sectionList.Add(_MAZAI04310ub.SectionCd);
                _stockAcPayListCndtn.SectionCodes = (string[])sectionList.ToArray(typeof(string));
            }
            // --- ADD 2009/01/09 不具合対応[9799] -------------------------------------<<<<<

            // 伝票区分
            _stockAcPayListCndtn.AcPaySlipCd = _MAZAI04310ub.AcPaySlipCd;

            // 入出荷日
            _stockAcPayListCndtn.St_IoGoodsDay = DateTime.ParseExact(_MAZAI04310ub.tde_st_IoGoodsDay.ToString() + "000000", "yyyyMMddHHmmss", null);
            _stockAcPayListCndtn.Ed_IoGoodsDay = DateTime.ParseExact(_MAZAI04310ub.tde_ed_IoGoodsDay.ToString() + "000000", "yyyyMMddHHmmss", null);

            // 倉庫
            _stockAcPayListCndtn.St_WarehouseCode = _MAZAI04310ub.WareHouse;
            _stockAcPayListCndtn.Ed_WarehouseCode = _MAZAI04310ub.WareHouse;

            // 品番
            _stockAcPayListCndtn.St_GoodsNo = _MAZAI04310ub.GoodsCd;
            _stockAcPayListCndtn.Ed_GoodsNo = _MAZAI04310ub.GoodsCd;

            // メーカー
            _stockAcPayListCndtn.St_GoodsMakerCd = _MAZAI04310ub.MakerCode;
            _stockAcPayListCndtn.Ed_GoodsMakerCd = _MAZAI04310ub.MakerCode;



            //_stockAcPayListCndtn.St_AcPaySlipNum;
            //_stockAcPayListCndtn.Ed_AcPaySlipNum;
            //_stockAcPayListCndtn.St_AddUpADate;
            //_stockAcPayListCndtn.Ed_AddUpADate;



            //_MAZAI04310ub.SearchMode = this.SearchMode;                  //検索モード
            //_MAZAI04310ub.EnterpriseCode = this._enterprisecode;              //企業コード
            //_MAZAI04310ub.GoodsCd = this.te_GoodsNo.Text;            //商品コード
            //_MAZAI04310ub.tde_st_IoGoodsDay = this.tde_st_IoGoodsDay.GetDateYear() * 10000
            //                                + this.tde_st_IoGoodsDay.GetDateMonth() * 100
            //                                + this.tde_st_IoGoodsDay.GetDateDay();     //入出荷日
            //_MAZAI04310ub.tde_ed_IoGoodsDay = (int)this.tde_ed_IoGoodsDay.GetLongDate();
            //_MAZAI04310ub.AcPaySlipCd = (int)this.ce_SlipKindDiv.Value;    //伝票区分(選択INDEX)            
            //_MAZAI04310ub.SectionCd = this.te_SectionCode.Text;          //拠点コード
            //_MAZAI04310ub.WareHouse = this.te_WarehouseCode.Text;        //倉庫コード
            //_MAZAI04310ub.MakerCode = this.tne_GoodsMakerCd.GetInt();//メーカー
            //_MAZAI04310ub.GoodsCd = this.te_GoodsNo.Text;//商品コード



        }
        // -----ADD 2008/07/17 ------------------------------------------------------------------------------<<<<<


		/// <summary>
		/// 印刷Main処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷ボタンが押下された時に処理します</br>
		/// <br>Programmer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
        /* -----DEL 2008/07/17 プレビュー追加の為 ----------------------------------------------->>>>>
        private void PrintMain()
        {
            // 一軒も抽出されていない場合は何もしない
            if (History_Grid.Rows.Count == 0)
            {
                return;
            }

            try
            {
                //// ダイアログ表示フラグON
                //_showPrintDialogFlg = true;

                // 共通印刷ダイアログの表示
                ShowCommonPrintDialog();
            }
            finally
            {
                //// ダイアログ表示フラグOFF
                //_showPrintDialogFlg = false;
            }
        }
           -----DEL 2008/07/17 ------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 → 2008/07/24時点で使用しない為、コメントアウト------------------->>>>>
        private void PrintMain(bool preview)
        {
            /*
            SFCMN06002C printInfo = new SFCMN06002C();
            if (this._printControl == null)
                this._printControl = new DCZAI02200UA();

            printInfo.printmode = (preview) ? 2 : 3;
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            // 直接印刷バージョン
            printInfo.enterpriseCode = this._enterprisecode;
            printInfo.kidopgid = "MAZAI04310U";				// 起動PGID

            // PDF出力履歴用
            printInfo.key = "da797c1f-b718-4fa4-8dec-cd4977b7792a";
            printInfo.prpnm = "";
            printInfo.PrintPaperSetCd = 0;

            // 条件設定
            printInfo.jyoken = _stockAcPayListCndtn;

            printInfo.rdData = ds.Tables[MAZAI04311EC.ct_Tbl_StockAcPayRef];

            object parameter = printInfo;
            int status = _printControl.Print(ref parameter);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (preview)
                {
                    //this._printControl.PDFViewer.Dock = DockStyle.Fill;
                    //this.uTab_View.Controls.Add(this._printControl.PDFViewer);
                    //this.uTabControl.Tabs[cTAB_PREVIEW].Visible = true;
                    //this.uTabControl.SelectedTab = this.uTabControl.Tabs[cTAB_PREVIEW];
                }
            }
            */
        }
        // -----ADD 2008/07/17 ------------------------------------------------------------------<<<<<

		/// <summary>
		/// 共通印刷ダイアログ表示処理
		/// </summary>
		/// <returns>ダイアログリザルト</returns>
		/// <remarks>
		/// <br>Note		: 帳票印刷用の共通ダイアログを起動します。</br>
		/// <br>Programmer	: 19077 渡邉 貴裕</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>
		private DialogResult ShowCommonPrintDialog()
		{
/*		
            SFTOK01433EA extrInfo = new SFTOK01433EA();
//			extrInfo.CustomerCode	= this.Customer_tNedit.GetInt();
			extrInfo.CarMngNo		= 0;
			extrInfo.FrameNo		= this.te_SectionCode.DataText;
			extrInfo.NumberPlate	= this.Carrier_tNedit.GetInt();
			extrInfo.RemoteType		= (SFTOK01433EA.RemoteMode)this.SearchMode;
			extrInfo.StartDate		= DateTime.MinValue;
			extrInfo.EndDate		= DateTime.MinValue;
			extrInfo.IsRemote		= false;
			extrInfo.DataClassList	= this.retList;

			SFCMN06002C printInfo	= new SFCMN06002C();
			printInfo.enterpriseCode= this._enterprisecode;
			printInfo.kidopgid		= "MAZAI04310U";
			printInfo.printmode		= 1;
			switch (this.SearchMode)
			{
					// 得意先履歴
				case (int)SFTOK01433EA.RemoteMode.CustomerCode:
				{
					printInfo.PrintPaperSetCd	= (int)SFTOK01433EA.ExtractMode.Customer;
					break;
				}
					// 車両履歴
				case (int)SFTOK01433EA.RemoteMode.FrameNo:
				case (int)SFTOK01433EA.RemoteMode.NumberPlate:
				{
					printInfo.PrintPaperSetCd	= (int)SFTOK01433EA.ExtractMode.Car;
					break;
				}
			}
			printInfo.jyoken		= extrInfo;

			SFCMN06001U prtDialog	= new SFCMN06001U();
			prtDialog.PrintInfo		= printInfo;

			prtDialog.ShowDialog();
*/
			return 0;
		}

        /// <summary>
        /// テキスト出力Main処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力ボタンが押下された時に処理します</br>
        /// <br>Programmer  : 19077 渡邉 貴裕</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        private void TextOutMain()
        {
            // 一軒も抽出されていない場合は何もしない
            if (History_Grid.Rows.Count == 0)
            {
                return;
            }

            try
            {
                //// テキスト出力用ダイアログ表示フラグON
                //_showPrintDialogFlg = true;

                // 共通印刷ダイアログの表示
                ShowCommonTextOutDialog();
            }
            finally
            {
                //// ダイアログ表示フラグOFF
                //_showPrintDialogFlg = false;
            }
        }


        /// <summary>
        /// 共通テキスト出力ダイアログ表示処理
        /// </summary>
        /// <returns>ダイアログリザルト</returns>
        /// <remarks>
        /// <br>Note		: 帳票テキスト出力用の共通ダイアログを起動します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private DialogResult ShowCommonTextOutDialog()
        {
/*
            SFTOK01433EA extrInfo = new SFTOK01433EA();
//            extrInfo.CustomerCode = this.Customer_tNedit.GetInt();
            extrInfo.CarMngNo = 0;
            extrInfo.FrameNo = this.te_SectionCode.DataText;
            extrInfo.NumberPlate = this.Carrier_tNedit.GetInt();
            extrInfo.RemoteType = (SFTOK01433EA.RemoteMode)this.SearchMode;
            extrInfo.StartDate = DateTime.MinValue;
            extrInfo.EndDate = DateTime.MinValue;
            extrInfo.IsRemote = false;
            extrInfo.DataClassList = this.retList;

            SFCMN06002C printInfo = new SFCMN06002C();
            printInfo.enterpriseCode = this._enterprisecode;
            printInfo.kidopgid = "MAZAI04310U";
            printInfo.printmode = 1;
            printInfo.selectInfoCode = 1;
            switch (this.SearchMode)
            {
                // 得意先履歴
                case (int)SFTOK01433EA.RemoteMode.CustomerCode:
                    {
                        printInfo.PrintPaperSetCd = (int)SFTOK01433EA.ExtractMode.Customer;
                        break;
                    }
                // 車両履歴
                case (int)SFTOK01433EA.RemoteMode.FrameNo:
                case (int)SFTOK01433EA.RemoteMode.NumberPlate:
                    {
                        printInfo.PrintPaperSetCd = (int)SFTOK01433EA.ExtractMode.Car;
                        break;
                    }
            }
            printInfo.jyoken = extrInfo;

            SFCMN00391U textDialog = new SFCMN00391U();
            textDialog.PrintInfo = printInfo;

            DialogResult dealogResult = textDialog.ShowDialog();

            // 戻り値を判定する

            // 戻り値がAbortの場合　⇒　例外が発生
            if (dealogResult == DialogResult.Abort)
            {
                TMsgDisp.Show(
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.ToString(),
                   "「" + printInfo.outPutFileName + "」の出力に失敗しました。",
                   printInfo.status,
                   MessageBoxButtons.OK);
            }
            else if (dealogResult == DialogResult.OK)
            {
                // ステータスが０の場合 ⇒ 出力成功
                if (printInfo.status == 0)
                {
                    TMsgDisp.Show(
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.ToString(),
                       "「" + printInfo.outPutFileName + "」を出力しました。",
                       printInfo.status,
                       MessageBoxButtons.OK);
                }
            }
 */ 
            return 0;
        }

        /// <summary>
        /// 履歴読込み件数保存用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note		: 履歴読込み件数保存用クラスです。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// <br>Update Note : 2009/12/04 李侠</br>
        /// <br>              PM.NS-4・保守依頼③の列サイズの自動調整の不具合対応</br>
        /// </remarks>
        public class MainWkHisFormInfo
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public MainWkHisFormInfo()
            {
            }

            //Filds
            private int _searchCount = 10;						//抽出件数
            // --- ADD 2009/12/04 ---------->>>>>
            private bool _searchCheckEditor = false;            //列サイズの自動調整
            // --- ADD 2009/12/04 ----------<<<<<
            //Properties
            /// <summary>
            /// 抽出件数
            /// </summary>
            public int SearchCount
            {
                get { return _searchCount; }
                set { _searchCount = value; }
            }
            // --- ADD 2009/12/04 ---------->>>>>
            /// <summary>
            /// 列サイズの自動調整
            /// </summary>
            public bool SearchCheckEditor
            {
                get { return _searchCheckEditor; }
                set { _searchCheckEditor = value; }
            }
            // --- ADD 2009/12/04 ----------<<<<<
        }

        /// <summary>
        /// 履歴画面情報読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 履歴画面情報を読み込みます。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private MainWkHisFormInfo MainWkHisFormInfo_Load(string fileName)
        {
            MainWkHisFormInfo info = null;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, fileName)))
            {
                try
                {
                    // XMLから抽出条件アイテムクラス配列にデシリアライズする
                    info = UserSettingController.DeserializeUserSetting<MainWkHisFormInfo>(Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, fileName));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, fileName));
                }
            }

            if (info == null)
            {
                info = new MainWkHisFormInfo();
            }

            return info;
        }
        /// <summary>
        /// 履歴画面情報保存処理。
        /// </summary>
        /// <remarks>
        /// <br>Note		: 履歴画面情報を保存します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// <br>Update Note : 2009/12/04 李侠</br>
        /// <br>              PM.NS-4・保守依頼③の列サイズの自動調整の不具合対応</br>
        /// </remarks>
        private void MainWkHisFormInfo_Save(string fileName)
        {
            MainWkHisFormInfo info = new MainWkHisFormInfo();

            //検索件数
//            info.SearchCount = ReadCnt_tNedit.GetInt();

            // --- ADD 2009/12/04 ---------->>>>>
            //列サイズの自動調整
            info.SearchCheckEditor = this.AutoFitCol_ultraCheckEditor.Checked;
            // --- ADD 2009/12/04 ----------<<<<<

            try
            {
                // 抽出条件アイテムクラス配列をXMLにシリアライズする
                UserSettingController.SerializeUserSetting(info, Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, fileName));
            }
            catch (Exception)
            {
            }
        }

		#endregion

        /// <summary>
        /// 拠点検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 拠点を検索します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private void ub_SectionGuide_Click(object sender, EventArgs e)
        {
            // ---DEL 2009/06/26 不具合対応[13625] ------------------------------------>>>>>
            //SecInfoSet secInfoSet = null;
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterprisecode,true,out secInfoSet);
            
            ////if (status == 0)
            ////{
            ////    this.te_SectionCode.Tag = secInfoSets;
            ////    this.te_SectionCode.Text = secInfoSets.SectionCode;
            ////    this.lb_SectionName.Text = secInfoSets.SectionGuideNm;
               
            ////    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////    // 拠点が変わったら倉庫をクリア
            ////    this.te_WarehouseCode.Tag = null;
            ////    this.te_WarehouseCode.Text = string.Empty;
            ////    this.lb_WarehouseName.Text = string.Empty;
            ////    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            ////}
            ////else
            ////{
            ////    ((Control)sender).Focus();
            ////}

            //if ( status == 0 )
            //{
            //    if ( secInfoSet.SectionCode.TrimEnd() != _prevHeaderInfo.SectionCode )
            //    {
            //        // 結果をセット
            //        //this.tEdit_SectionCode.Text = secInfoSet.SectionCode;             //DEL 2008/07/17
            //        this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.TrimEnd();     //ADD 2008/07/17
            //        this.lb_SectionName.Text = secInfoSet.SectionGuideNm;
            //        //this.tEdit_WarehouseCode.Text = string.Empty;                     //DEL 2008/12/19
            //        //this.lb_WarehouseName.Text = string.Empty;                        //DEL 2008/12/19

            //        _prevHeaderInfo.SectionCode = secInfoSet.SectionCode;
            //        //_prevHeaderInfo.WarehouseCode = string.Empty;                     //DEL 2008/12/19
            //    }
                
            //    // 次フォーカス
            //    _guideNextFocusControl.GetNextControl( tEdit_SectionCodeAllowZero ).Focus();

            //}
            // ---DEL 2009/06/26 不具合対応[13625] ------------------------------------<<<<<
        }

        /// <summary>
        /// 倉庫ガイド処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 倉庫を検索します。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.30</br>
        /// </remarks>
        private void ub_WarehouseGuide_Click ( object sender, EventArgs e )
        {
            // ---DEL 2009/06/26 不具合対応[13625] ------------------------------------>>>>>
            //// ----- ADD 2008/07/17 ------------------------------------------------------------------------->>>>>
            //string sectionCode = tEdit_SectionCodeAllowZero.DataText.TrimEnd();
            //if (sectionCode == "00")
            //{
            //    sectionCode = string.Empty;
            //}
            //// ----------------------------------------------------------------------------------------------<<<<<
            // ---DEL 2009/06/26 不具合対応[13625] ------------------------------------<<<<<
            string sectionCode = string.Empty;     //ADD 2009/06/26 不具合対応[13625]

            Warehouse warehouse = null;
            //int status = this._warehouseAcs.ExecuteGuid( out warehouse, this._enterprisecode, tEdit_SectionCodeAllowZero.DataText.TrimEnd() );        //DEL 2008/07/17 拠点00入力対応
            int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterprisecode, sectionCode);                                              //ADD 2008/07/17

            if ( status == 0 )
            {
                if ( warehouse.WarehouseCode != _prevHeaderInfo.WarehouseCode )
                {
                    //this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode;                  //DEL 2008/07/17
                    this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd();          //ADD 2008/07/17
                    this.lb_WarehouseName.Text = warehouse.WarehouseName;
                    //this.tEdit_SectionCodeAllowZero.Text = warehouse.SectionCode;             //DEL 2008/07/17
                    //this.lb_SectionName.Text = GetSectionName( warehouse.SectionCode );       //DEL 2008/07/17

                    _prevHeaderInfo.WarehouseCode = warehouse.WarehouseCode;
                    //_prevHeaderInfo.SectionCode = warehouse.SectionCode;                      //DEL 2008/07/17
                }

                // 次フォーカス
                _guideNextFocusControl.GetNextControl( tEdit_WarehouseCode ).Focus();
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 事業者検索
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: 事業者を検索します。</br>
        ///// <br>Programmer	: 19077 渡邉 貴裕</br>
        ///// <br>Date		: 2007.05.18</br>
        ///// </remarks>
        //private void CarrerEP_uButton_Click(object sender, EventArgs e)
        //{            
        //    Carrier carrier;

        //    string sectionCode = te_SectionCode.Text.Trim();

        //    int status = this._carrierOdrAcs.ExecuteGuid(this._enterprisecode, sectionCode, out carrier);
                        
        //    if (status == 0)
        //    {
        //        this.Carrier_tNedit.Tag = carrier.CarrierCode;
        //        this.Carrier_tNedit.SetInt(carrier.CarrierCode);
        //        this.CarrierNametEdit.Text = carrier.CarrierName;

        //        //                // フォーカスを次へ移動
        //        //                this.SelectNextControl((Control)sender, true, true, true, true);
        //    }
        //    else
        //    {
        //        ((Control)sender).Focus();
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// Control.Click イベント(CarInspectVarCstCd_Guide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 19077 渡邉貴裕</br>
        /// <br>Date        : 2007.01.26</br>
        /// <br>Update Note : 2015/03/27 時シン</br>
        /// <br>管理番号    : 11070263-00　Seiken品番変更</br>
        /// <br>            : 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応</br>
        /// </remarks>
        private void ub_MakerGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt maker = null;
            int status = this._makerAcs.ExecuteGuid(this._enterprisecode, out maker);

//            if (status == 0)
//            {
//                this.tne_GoodsMakerCd.Tag = maker;
//                this.tne_GoodsMakerCd.SetInt(maker.GoodsMakerCd);
//                this.tne_GoodsMakerCd.Text = this.tne_GoodsMakerCd.GetInt().ToString();
//                this.lb_MakerName.Text = maker.MakerName;
//                // フォーカスを次へ移動
////                this.SelectNextControl((Control)sender,true, true, true, true);
////                this.SelectNextControl((Control)sender, false, false, false, false);
                
//                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
//                this._beforeMakerCd = maker.GoodsMakerCd;
//                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
//            }
//            else
//            {
//                ((Control)sender).Focus();
//            }
            if ( status == 0 )
            {
                if ( maker.GoodsMakerCd != _prevHeaderInfo.GoodsMakerCode )
                {
                    // 結果セット
                    this.tNedit_GoodsMakerCd.SetInt( maker.GoodsMakerCd );
                    this.lb_MakerName.Text = maker.MakerName.TrimEnd();

                    // --- UPD 2010/11/15 ---------->>>>>
                    //this.tEdit_GoodsNo.Text = string.Empty;
                    //this.lb_GoodsName.Text = string.Empty;

                    _prevHeaderInfo.GoodsMakerCode = maker.GoodsMakerCd;
                    //_prevHeaderInfo.GoodsNo = string.Empty;

                    ChangeFocusEventArgs cfe = new ChangeFocusEventArgs(false, false, true, Keys.Control, tNedit_GoodsMakerCd, tNedit_GoodsMakerCd);
                    status = ReadGoods(cfe);

                    if (status == READDATA_SUCCESS)
                    {
                        // 棚番、BLｺｰﾄﾞを取得
                        this.ReadGoodsUnit();
                    }
                    else
                    {
                        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                        if (!this.CheckEditor_DeleteDataSearch.Checked)
                        {
                        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                            this.tEdit_GoodsNo.Clear();
                            this.lb_GoodsName.Text = string.Empty;
                            _prevHeaderInfo.GoodsNo = string.Empty;
                        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------>>>>>
                        }
                        else
                        {
                            this.lb_GoodsName.Text = string.Empty;
                            this.lb_BLGoodsCode.Text = string.Empty;            // BLコード
                            this.lb_WarehouseShelfNo.Text = string.Empty;       // 棚番
                        }
                        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済み在庫も検索」チェックボタンを追加対応------<<<<<
                    }
                    // --- UPD 2010/11/15  ----------<<<<<
                }

                // --- UPD 2010/11/15 ---------->>>>>
                // 次フォーカス
                //_guideNextFocusControl.GetNextControl( tNedit_GoodsMakerCd ).Focus();
                // 絞込条件を変更した場合
                if (this.SearchParaChange())
                {
                    // 検索処理を実行する
                    this.SearchMain();
                }
                else
                {
                    if (this.History_Grid.Rows.Count > 0)
                    {
                        // グリットへフォーカス移動
                        this.History_Grid.Focus();
                        this.History_Grid.ActiveRow = this.History_Grid.Rows[0];
                        this.History_Grid.Rows[0].Selected = true;
                    }
                    else
                    {
                        this.ce_SlipKindDiv.Focus();
                    }
                }
                // --- UPD 2010/11/15  ----------<<<<<
            }
        }
        ///// <summary>
        ///// メーカー検索処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: 倉庫を検索します。</br>
        ///// <br>Programmer	: 19077 渡邉 貴裕</br>
        ///// <br>Date		: 2007.05.18</br>
        ///// </remarks>
        //private void tne_GoodsMakerCd_AfterExitEditMode(object sender, EventArgs e)
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    if ( tne_GoodsMakerCd.GetInt() == this._beforeMakerCd ) return;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    MakerUMnt maker = new MakerUMnt();

        //    if (tne_GoodsMakerCd.GetInt() == 0)
        //    {
        //        this.lb_MakerName.Text = "";
        //        return;
        //    }
            
        //    int makerCode = tne_GoodsMakerCd.GetInt();
        //    //int status = this._makerAcs.Read(out maker, _enterprisecode, makerCode);
        //    int status = _goodsAcs.GetMaker( this._enterprisecode, makerCode, out maker );

        //    if (status == 0)
        //    {
        //        this.lb_MakerName.Text = maker.MakerName;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        this._beforeMakerCd = maker.GoodsMakerCd;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    }
        //    else
        //    {
        //        this.lb_MakerName.Text = "";
        //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAZAI04310U",
        //            "該当するメーカーはありません。", 0, MessageBoxButtons.OK);                
        //    }
        //}
        /// <summary>
        /// 日付範囲指定処理(ドロップダウン)
        /// </summary>
        /// <remarks>
        /// <br>Note		: 日付範囲を指定します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private void ce_IoGoodsDayDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int year;
            int month;
            int day;
            int date;

            year = tde_st_IoGoodsDay.GetDateYear();
            month = tde_st_IoGoodsDay.GetDateMonth();
            day = tde_st_IoGoodsDay.GetDateDay();
            date = year * 10000 + month * 100 + day;

            _MAZAI04310ub = new MAZAI04310UB();

            int setDate;
            DateTime setDatetime = new DateTime();
            DateTime reserveDate = new DateTime();

            if (date != 0)
            {
                setDate = _MAZAI04310ub.AddDays(date, (int)ce_IoGoodsDayDiv.Value);
                setDatetime = DateTime.ParseExact(setDate.ToString() + "000000", "yyyyMMddHHmmss", null);

                if ((int)ce_IoGoodsDayDiv.Value > 0)
                {
                    //以降                   
                    reserveDate = tde_st_IoGoodsDay.GetDateTime();
                    tde_st_IoGoodsDay.SetDateTime(reserveDate);
                    tde_ed_IoGoodsDay.SetDateTime(setDatetime);
                }
                else
                {
                    //以前
                    reserveDate = tde_st_IoGoodsDay.GetDateTime();
                    tde_st_IoGoodsDay.SetDateTime(setDatetime);
                    tde_ed_IoGoodsDay.SetDateTime(reserveDate);
                }

            }

        }

        #region DEL 2008/11/28 未使用でまぎらわしい為、削除
        /*
        /// <summary>
        /// 取引区分名取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 取引区分名を取得します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private string GetTranceKBN(int AcPayTransCd)
        {
            string setKbn = "";
            switch (AcPayTransCd)
            {
                case 10:
                    {
                        setKbn = TK_10;
                        break;
                    }
                case 11:
                    {
                        setKbn = TK_11;
                        break;
                    }
                case 20:
                    {
                        setKbn = TK_20;
                        break;
                    }
                case 21:
                    {
                        setKbn = TK_21;
                        break;
                    }
                case 30:
                    {
                        setKbn = TK_30;
                        break;
                    }
                case 31:
                    {
                        setKbn = TK_31;
                        break;
                    }
                case 32:
                    {
                        setKbn = TK_32;
                        break;
                    }
                case 33:
                    {
                        setKbn = TK_33;
                        break;
                    }
                case 34:
                    {
                        setKbn = TK_34;
                        break;
                    }
                case 35:
                    {
                        setKbn = TK_35;
                        break;
                    }
                case 40:
                    {
                        setKbn = TK_40;
                        break;
                    }
                case 90:
                    {
                        setKbn = TK_90;
                        break;
                    }
            }
            return setKbn;
        }
        /// <summary>
        /// 伝票区分名取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 伝票区分名を取得します。</br>
        /// <br>Programmer	: 19077 渡邉 貴裕</br>
        /// <br>Date		: 2007.05.18</br>
        /// </remarks>
        private string GetSlipKbn(int AcPaySlipCd)
        {
            string denKbn = "";
            switch (AcPaySlipCd)
            {
                case 10:
                    {
                        denKbn = "仕入";
                        break;
                    }
                case 11:
                    {
                        denKbn = "受託";
                        break;
                    }
                case 12:
                    {
                        denKbn = "受計上";
                        break;
                    }
                case 20:
                    {
                        denKbn = "売上";
                        break;
                    }
                case 21:
                    {
                        denKbn = "売計上";
                        break;
                    }
                case 22:
                    {
                        denKbn = "委託";
                        break;
                    }
                case 23:
                    {
                        denKbn = "売切";
                        break;
                    }
                case 30:
                    {
                        denKbn = "移動出荷";
                        break;
                    }
                case 31:
                    {
                        denKbn = "移動入荷";
                        break;
                    }
                case 40:
                    {
                        denKbn = "調整";
                        break;
                    }
                case 41:
                    {
                        denKbn = "半黒";
                        break;
                    }
                case 50:
                    {
                        denKbn = "棚卸";
                        break;
                    }            
            }
            return denKbn;
        }
        */
        #endregion

        // --- DEL 2009/12/04 ---------->>>>>
        ///// <summary>
        ///// 日数間チェック処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note		: 指定日数間をチェックします。3ヶ月を超えるとエラーとします</br>
        ///// <br>Programmer	: 19077 渡邉 貴裕</br>
        ///// <br>Date		: 2007.05.18</br>
        ///// </remarks>
        //private bool ChkDateLength()
        //{
        //    bool bDateCHk = true;

        //    int years = this.tde_st_IoGoodsDay.GetDateYear();
        //    int months = this.tde_st_IoGoodsDay.GetDateMonth();
        //    int days = this.tde_st_IoGoodsDay.GetDateDay();

        //    int yeare = this.tde_ed_IoGoodsDay.GetDateYear();
        //    int monthe = this.tde_ed_IoGoodsDay.GetDateMonth();
        //    int daye = this.tde_ed_IoGoodsDay.GetDateDay();

        //    if ((years == 0 && months == 0 && days == 0) || (yeare == 0 && monthe == 0 && daye == 0))
        //    {
        //        return false;
        //    }

        //    MAZAI04310UB mazai04310ub = new MAZAI04310UB();

        //    int chkDate = mazai04310ub.AddDays(years * 10000 + months * 100 + days,6);

        //    if (chkDate < yeare * 10000 + monthe * 100 + daye)
        //    {
        //        bDateCHk = false;
        //    }
        //    return bDateCHk;
        //}
        // --- DEL 2009/12/04 ----------<<<<<

        // --- ADD 2008/11/17 ------------------------------------------------------------------------------>>>>>
        /// <summary>
        /// 前回月次締処理日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay(string sectionCode)
        {
            DateTime prevTotalDay;
            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode.Trim(), out prevTotalDay);

            // 取得日が不正な場合は３ヶ月前をセット
            if (status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today)
            {
                prevTotalDay = DateTime.Today.AddMonths(-3);
            }
            // 翌日取得
            prevTotalDay = prevTotalDay.AddDays(1);

            return prevTotalDay;
        }
        // --- ADD 2008/11/17 ------------------------------------------------------------------------------<<<<<

        /// <summary>
        /// 商品ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_GoodsGuide_Click(object sender, EventArgs e)
        {
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            GoodsUnitData goodsUnitData;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterprisecode, out goodsUnitData);

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterprisecode;
            bool autoSearch = false;

            // ---DEL 2009/06/26 不具合対応[13625] ------------------------>>>>>
            //// --- DEL 2009/03/16 -------------------------------->>>>>
            ////// 検索条件にメーカーをセット
            ////if ( this.tNedit_GoodsMakerCd.GetInt() != 0 )
            ////{
            ////    goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            ////    goodsCndtn.MakerName = this.lb_MakerName.Text.TrimEnd();
            ////    autoSearch = true;
            ////}
            //// --- DEL 2009/03/16 --------------------------------<<<<<
            //// 検索条件に拠点をセット
            //if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd() != string.Empty)
            //{
            //    goodsCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();
            //}
            // ---DEL 2009/06/26 不具合対応[13625] ------------------------<<<<<

            DialogResult dialogResult = goodsSelectGuide.ShowGuide( this, autoSearch, goodsCndtn, out goodsUnitData );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
			{
                tEdit_GoodsNo.Text = goodsUnitData.GoodsNo;
                lb_GoodsName.Text = goodsUnitData.GoodsName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                tNedit_GoodsMakerCd.SetInt( goodsUnitData.GoodsMakerCd );
                lb_MakerName.Text = goodsUnitData.MakerName;

                _prevHeaderInfo.GoodsNo = goodsUnitData.GoodsNo;
                _prevHeaderInfo.GoodsMakerCode = goodsUnitData.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                
            }
        }
        ///// <summary>
        ///// 拠点検索(1件)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void te_SectionCode_AfterExitEditMode(object sender, EventArgs e)
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    if ( te_SectionCode.Text.Trim() == this._beforeSectionCd ) return;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    string sectionCode = te_SectionCode.Text.Trim();

        //    if (sectionCode == "")
        //    {
        //        lb_SectionName.Text = "";
        //        return;
        //    }

        //    SecInfoSet secInfoSets = new SecInfoSet();

        //    int status = this._secInfoSetAcs.Read(out secInfoSets,this._enterprisecode,sectionCode);

        //    if (status == 0)
        //    {                
        //        this.te_SectionCode.Text = secInfoSets.SectionCode;
        //        this.lb_SectionName.Text = secInfoSets.SectionGuideNm;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        this._beforeSectionCd = secInfoSets.SectionCode;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    }
        //    else
        //    {
        //        this.lb_SectionName.Text = "";
        //        ((Control)sender).Focus();
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_INFO,
        //            this.Name,
        //            "拠点コード [" + sectionCode + "] に該当するデータが存在しません。",
        //            -1,
        //            MessageBoxButtons.OK);
        //    }
        //}

        //private void SearchGoodsName()
        //{
        //    string goodsCode = te_GoodsNo.Text.Trim();
        //    string searchCode;
        //    int searchType = StockAcPayHistAcs.GetSearchType(goodsCode, out searchCode);
        //    List<GoodsUnitData> goodsUnitDataList;
        //    string message;
        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    if (te_GoodsNo.Text.Trim() != "")
        //    {
        //        int status = goodsSelectGuide.ReadGoods(this, this._enterprisecode, searchType, searchCode, out goodsUnitDataList, out message);

        //        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //        {
        //            if (searchType != 0)
        //            {
        //                te_GoodsNo.Text = goodsUnitDataList[0].GoodsNo;
        //            }

        //            te_GoodsName.Text = goodsUnitDataList[0].GoodsName;
        //        }
        //        else
        //        {
        //            te_GoodsName.Text = "";

        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_INFO,
        //                this.Name,
        //                "商品コード [" + searchCode + "] に該当するデータが存在しません。",
        //                -1,
        //                MessageBoxButtons.OK);
        //        }
        //    }
        //    else
        //    {
        //        te_GoodsName.Text = "";
        //    }

        //}


        ///// <summary>
        ///// 商品検索
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void te_GoodsNo_AfterExitEditMode(object sender, EventArgs e)
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    if ( te_GoodsNo.Text.Trim() == _beforeGoodsNo ) return;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


        //    string goodsCode = te_GoodsNo.Text.Trim();
        //    string searchCode;
        //    int searchType = StockAcPayHistAcs.GetSearchType(goodsCode, out searchCode);
        //    List<GoodsUnitData> goodsUnitDataList;
        //    string message;
        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    if (te_GoodsNo.Text.Trim() != "")
        //    {
        //        int status = goodsSelectGuide.ReadGoods(this, this._enterprisecode, searchType, searchCode, out goodsUnitDataList, out message);

        //        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //        {
        //            if (searchType != 0)
        //            {
        //                te_GoodsNo.Text = goodsUnitDataList[0].GoodsNo;
        //            }

        //            lb_GoodsName.Text = goodsUnitDataList[0].GoodsName;

        //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //            this._beforeGoodsNo = goodsUnitDataList[0].GoodsNo;
        //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //        }
        //        else
        //        {
        //            lb_GoodsName.Text = "";
        //            ((Control)sender).Focus();
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_INFO,
        //                this.Name,
        //                "商品コード [" + searchCode + "] に該当するデータが存在しません。",
        //                -1,
        //                MessageBoxButtons.OK);
        //        }
        //    }
        //    else
        //    {
        //        lb_GoodsName.Text = "";
        //    }
        //}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 倉庫検索
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void te_WarehouseCode_AfterExitEditMode ( object sender, EventArgs e )
        //{
        //    if ( te_WarehouseCode.Text.Trim() == this._beforeWarehouseCd ) return;

        //    Warehouse warehouse;

        //    if ( te_WarehouseCode.Text.Trim() == string.Empty )
        //    {
        //        this.te_WarehouseCode.Text = "";
        //        this.lb_WarehouseName.Text = "";
        //        return;
        //    }

        //    int status = this._warehouseAcs.Read( out warehouse, this._enterprisecode, this.te_SectionCode.Text.TrimEnd(), this.te_WarehouseCode.Text.TrimEnd() );
        //    if ( status == 0 )
        //    {
        //        this.te_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd();
        //        this.lb_WarehouseName.Text = warehouse.WarehouseName.TrimEnd();

        //        this._beforeWarehouseCd = warehouse.WarehouseCode;
        //    }
        //    else
        //    {
        //        this.te_WarehouseCode.Text = "";
        //        TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAZAI04310U",
        //            "該当する倉庫はありません。", 0, MessageBoxButtons.OK );
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// キャリア検索
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Carrier_tNedit_AfterExitEditMode(object sender, EventArgs e)
        //{
        //    int carrierCd = Carrier_tNedit.GetInt();

        //    if (carrierCd == 0)
        //    {
        //        CarrierNametEdit.Text = "";
        //        return;
        //    }

        //    string sectionCode = te_SectionCode.Text.Trim();
        //    Carrier carrier;

        //    int status = this._carrierOdrAcs.Read(out carrier, _enterprisecode, sectionCode, carrierCd);

        //    if (status == 0)
        //    {
        //        this.Carrier_tNedit.Tag = carrier.CarrierCode;
        //        this.Carrier_tNedit.SetInt(carrier.CarrierCode);
        //        this.CarrierNametEdit.Text = carrier.CarrierName;

        //        //                // フォーカスを次へ移動
        //        //                this.SelectNextControl((Control)sender, true, true, true, true);
        //    }
        //    else
        //    {
        //        ((Control)sender).Focus();
        //        CarrierNametEdit.Text = "";
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_INFO,
        //            this.Name,
        //            "キャリアコード [" + carrierCd + "] に該当するデータが存在しません。",
        //            -1,
        //            MessageBoxButtons.OK);

        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        private void History_Grid_FilterRow(object sender, FilterRowEventArgs e)
        {
//            MessageBox.Show("");
        }

        private void History_Grid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
//            MessageBox.Show("");
        }

        ///行フィルタ終了後
        private void History_Grid_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
        {
            ReNumberProc();
        }

        /// <summary>
        /// 行No振りなおし
        /// </summary>
        private void ReNumberProc ()
        {

        }

        /// <summary>
        /// ソート後処理    //ADD 2008/07/17
        /// </summary>
        private void History_Grid_AfterSortChange(object sender, BandEventArgs e)
        {
            // 繰越数再計算
            CalcCarryForwardProc();
        }

        # region ■ ガイド後次フォーカス制御クラス ■
        /// <summary>
        /// ガイド後次フォーカス制御クラス
        /// </summary>
        internal class GuideNextFocusControl
        {
            private List<Control> _controls;
            private Dictionary<Control, int> _indexDic;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public GuideNextFocusControl()
            {
                _controls = new List<Control>();
                _indexDic = new Dictionary<Control, int>();
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="control"></param>
            public void Add(Control control)
            {
                _controls.Add(control);
                if (!_indexDic.ContainsKey(control))
                {
                    _indexDic.Add(control, _controls.Count - 1);
                }
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="collection"></param>
            public void AddRange(IEnumerable<Control> collection)
            {
                int stIndex = _controls.Count;
                _controls.AddRange(collection);
                int edIndex = _controls.Count - 1;

                for (int i = stIndex; i <= edIndex; i++)
                {
                    if (!_indexDic.ContainsKey(_controls[i]))
                    {
                        _indexDic.Add(_controls[i], i);
                    }
                }
            }
            /// <summary>
            /// 対象コントロールクリア
            /// </summary>
            public void Clear()
            {
                _controls.Clear();
                _indexDic.Clear();
            }
            /// <summary>
            /// 次コントロール取得
            /// </summary>
            /// <param name="control"></param>
            /// <returns></returns>
            public Control GetNextControl(Control control)
            {
                // -----ADD 2008/07/17 --------------------------->>>>>
                // 無いコントロールの場合、そのまま返す
                if (_indexDic.ContainsKey(control) == false)
                {
                    return control;
                }
                // -----ADD 2008/07/17 ---------------------------<<<<<

                int index = _indexDic[control];
                index++;

                for (int i = index; i < _controls.Count; i++)
                {
                    if (!_controls[i].Visible || !_controls[i].Enabled)
                    {
                        continue;
                    }

                    if (_controls[i] is TEdit)
                    {
                        if ((_controls[i] as TEdit).ReadOnly == true)
                        {
                            continue;
                        }
                    }

                    return _controls[i];
                }
                return _controls[_controls.Count - 1];
            }
        }
        # endregion ■ ガイド後次フォーカス制御クラス ■

        // --- ADD 2010/11/15 ---------->>>>>
        /// <summary>
        /// 絞込条件の変更判断
        /// </summary>
        /// <remarks>
        /// <br>Note       : 絞込条件の変更判断をお行いします</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/11/15</br>
        /// </remarks>
        private bool SearchParaChange()
        {
            // 絞込条件を変更した場合
            if ((int)this.ce_SlipKindDiv.Value != this._MAZAI04310ub.AcPaySlipCd
                || this.tde_st_IoGoodsDay.GetLongDate() != this._MAZAI04310ub.tde_st_IoGoodsDay
                || this.tde_ed_IoGoodsDay.GetLongDate() != this._MAZAI04310ub.tde_ed_IoGoodsDay
                || (!this.tEdit_WarehouseCode.Text.PadLeft(4, '0').Equals(this._MAZAI04310ub.WareHouse))
                || (!this.tEdit_GoodsNo.Text.Equals(this._MAZAI04310ub.GoodsCd))
                || this.tNedit_GoodsMakerCd.GetInt() != this._MAZAI04310ub.MakerCode)
            {
                return true;
            }

            return false;
        }
        // --- ADD 2010/11/15  ----------<<<<<
    }

}
