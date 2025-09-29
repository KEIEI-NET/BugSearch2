//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸関連一覧表
// プログラム概要   : 棚卸関連一覧表 ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村 仁
// 作 成 日  2007/04/09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/09/05  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/02/13  修正内容 : 不具合対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 修 正 日  2008/10/07  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応13108
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2009/12/04  修正内容 : 不具合対応(PM.NS保守依頼③対応)
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 呉元嘯
// 修 正 日  2010/02/20  修正内容 : 不具合対応(PM1005)
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : liyp
// 修 正 日  2011/01/11  修正内容 : 不具合対応(PM1101B)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2011/01/11  修正内容 : 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2011/02/17  修正内容 : 棚卸調査表の棚番ブレイク区分の有効無効のチェックについて
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/11/14  修正内容 : 2013/01/16配信分、Redmine#33271
//                                  印字制御の区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 董桂鈺
// 作 成 日  2012/12/25  修正内容 : 2013/01/16配信分、Redmine#33271
//                                  帳票の罫線印字（する・しない）を前回指定したも
//                                  のを記憶させることの設定を追加する
//----------------------------------------------------------------------------//
// 管理番号  11000606-00 作成担当 : licb
// 作 成 日  K2014/03/10 修正内容 : 信越自動車商会個別開発 テキスト出力機能を追加する                                 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData; // 2008.02.13 追加
using Broadleaf.Library.Windows;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 棚卸関連一覧表 ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸関連一覧表 ＵＩクラスの出力条件入力を行います。</br>
    /// <br>Programmer : 23010 中村 仁</br>
    /// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.05 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.02.13 980035 金沢 貞義</br>
    /// <br>			 ・不具合対応（DC.NS対応）</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.10.07</br>
    /// <br>Update Note: 2009/04/13 30452 上野 俊治</br>
    /// <br>            ・障害対応13108</br>
    /// <br>Update Note: 2009/12/04 呉元嘯</br>
    /// <br>			 不具合対応(PM.NS保守依頼③対応)</br>
    /// <br>Update Note: 2010/02/20 呉元嘯</br>
    /// <br>			 不具合対応(PM1005)</br> 
    /// <br>Update Note: 2011/01/11 田建委</br>
    /// <br>			 棚卸障害対応</br> 
    /// <br>Update Note: 2011/02/17 田建委</br>
    /// <br>			 棚卸調査表の棚番ブレイク区分の有効無効のチェックについて</br>
    /// <br>Update Note: 2012/11/14 李亜博</br>
    ///	<br>			 Redmine#33271 印字制御の区分の追加</br> 
    /// <br>Update Note: 2012/12/25 董桂鈺</br>
    ///	<br>			 Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
    /// <br></br>
    /// </remarks>
    public partial class MAZAI02110UA : Form,
                                        IPrintConditionInpType,						// 帳票共通(条件入力タイプ)
                                        IPrintConditionInpTypeSelectedSection,		// 帳票業務(条件入力)拠点選択
                                        IPrintConditionInpTypePdfCareer,            // 帳票業務(条件入力)PDF出力履歴管理
        　　　　　　　　　　　　　　　　// --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
                                        IPrintConditionInpTypeTextOutPut,           //テキスト出力　
                                        IPrintConditionInpTypeTextOutControl        //オプションの制御
    　　　　　　　　　　　　　　　　　　// --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
    {

        #region Constructor
        // <summary>
        /// 棚卸関連一覧表 ＵＩクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : 棚卸関連一覧表 ＵＩクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2012/12/25 董桂鈺</br>
        ///	<br>			 Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
        /// <br></br>
        /// </remarks>
        public MAZAI02110UA()
        {
            InitializeComponent();
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //キャリア用リスト
            this._carrierList = new SortedList();
            //画面デザイン変更クラス
            this._controlScreenSkin = new ControlScreenSkin();

   
			// ログイン情報生成 //
			if (LoginInfoAcquisition.Employee != null)
			{
				Employee _employee = new Employee();
				_employee = LoginInfoAcquisition.Employee;
     
				// 企業コード
				this._enterpriseCode = _employee.EnterpriseCode;
                // 拠点コード
                this._sectionCode = _employee.BelongSectionCode;             
				// ログイン従業員コード
				this._employeeCode = _employee.EmployeeCode;
				// ログイン従業員名称
				this._employeeName = _employee.Name;
			}

            // 2008.10.08 30413 犬飼 未使用のため削除 >>>>>>START
            ////得意先情報アクセスクラス
            //this._customerInfoAcs = new CustomerInfoAcs();
            // 2008.10.08 30413 犬飼 未使用のため削除 <<<<<<END
            
            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            //棚卸準備処理アクセスクラス
            this._inventoryPrepareAcs = new InventoryPrepareAcs();
            // 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<

            // 2008.10.08 30413 犬飼 仕入先ガイドアクセスクラスの追加 >>>>>>START
            // 仕入先アクセスクラス
            this._supplierAcs = new SupplierAcs();
            // 2008.10.08 30413 犬飼 仕入先ガイドアクセスクラスの追加 <<<<<<END

            // 2008.11.26 30413 犬飼 BLグループアクセスクラスの追加 >>>>>>START
            this._blGroupUAcs = new BLGroupUAcs();
            // 2008.11.26 30413 犬飼 BLグループアクセスクラスの追加 <<<<<<END

            // 2008.11.26 30413 犬飼 在庫管理全体設定アクセスクラスの追加 >>>>>>START
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            // 2008.11.26 30413 犬飼 在庫管理全体設定アクセスクラスの追加 <<<<<<END

            //---ADD 董桂鈺 2012/12/25 for Redmine#33271-------------->>>>>
            tComboEditor_LineMaSqOfChDiv0.Visible = false;
            tComboEditor_LineMaSqOfChDiv1.Visible = false;
            tComboEditor_LineMaSqOfChDiv2.Visible = false;
            //---ADD 董桂鈺 2012/12/25 for Redmine#33271--------------<<<<<
            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            this._inventoryListCmnAcs = new InventoryListCmnAcs();
            this._warehouseAcs = new WarehouseAcs();
            //仕入先ArrayList
            _supplierAl = new ArrayList();
            _warehouseAl = new ArrayList();
            _MakerAl = new ArrayList();
            _stockMngTtlStAl = new ArrayList();
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

        }
        #endregion

        # region エントリ ポイント
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAZAI02110UA());
        }
        #endregion

        #region Events
        /// <summary>フレームツールバー設定イベント</summary>
        public event Broadleaf.Application.Common.ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Private Members
        // 企業コード
        private string _enterpriseCode = "";       
        // 抽出条件クラス
        private InventSearchCndtnUI _inventSearchCndtnUI = new InventSearchCndtnUI();      
        //在庫更新拠点コード(倉庫ガイド時に使用)
        //private string _stockUpdateSecCd = "";
        // 在庫更新拠点情報
        //private SecInfoSet _stockSecInfoSet;
        private string _employeeCode;		// 担当者コード
		private string _employeeName;		// 担当者名称
        //ログイン拠点
        private string _sectionCode;    

        // ------------------------------
        // IPrintConditionInpTypeのプロパティ用変数
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;

        // ------------------------------
        // IPrintConditionInpTypeSelectedSectionのプロパティ用変数
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無プロパティ
        private bool _isOptSection = false;
        // 本社機能有無プロパティ
        private bool _isMainOfficeFunc = false;

        // ------------------------------
        // IPrintConditionInpTypePdfCareerのプロパティ用変数
        // 帳票名称
        private string _printName = "";
        // 帳票キー
        private string _printKey = "";

        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
        //IPrintConditionInpTypeTextOutPutのプロパティ用変数
        private bool _isCanTextOutPut = false;
        private string _outPutFileName = string.Empty;
        private ArrayList _supplierAl;
        private InventoryListCmnAcs _inventoryListCmnAcs = null;    // 棚卸関連一覧表アクセスクラス
        private MAZAI02110UB _textOutDialog;
        private WarehouseAcs _warehouseAcs;
        private ArrayList _warehouseAl;
        private ArrayList _MakerAl;
        private ArrayList _stockMngTtlStAl;
        private StockMngTtlSt _stockMngTtlSt;
        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
             
        //起動帳票
        private int _selPrintMode;  // 0:棚卸記入表1:棚卸差異表:2:棚卸表
        ///画面デザイン変更クラス
        private ControlScreenSkin _controlScreenSkin;

        // 2008.10.08 30413 犬飼 未使用のため削除 >>>>>>START
        ////仕入先ガイド起動元特定インデックス
        //private int _custmerGuideIndex;
        ////委託先ガイド起動元特定インデックス
        //private int _shipCustmerGuideIndex;
        // 2008.10.08 30413 犬飼 未使用のため削除 <<<<<<END

        ///メーカーマスタアクセスクラス
        private MakerAcs _makerAcs = null;

        // 2008.10.08 30413 犬飼 未使用のため削除 >>>>>>START
        /////商品区分グループマスタアクセスクラス
        //private LGoodsGanreAcs _lGoodsGanreAcs = null;
        /////商品区分マスタアクセスクラス
        //private MGoodsGanreAcs _mGoodsGanreAcs = null;
        // 2008.10.08 30413 犬飼 未使用のため削除 <<<<<<END
        
        //キャリア用リスト
        private SortedList _carrierList = null;

        // 2008.10.08 30413 犬飼 未使用のため削除 >>>>>>START
        ////得意先情報アクセスクラス
        //private CustomerInfoAcs _customerInfoAcs;
        // 2008.10.08 30413 犬飼 未使用のため削除 <<<<<<END
        
        // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
        ////事業者マスタアクセスクラス
        //private CarrierEpAcs _carrierEpGuide = null;
        ////キャリアガイド
        //private CarrierOdrAcs _carrierOdrAcs = null;
        ////機種ガイド
        //private CellphoneModelAcs _cellphoneModelAcs = null;

        // 2008.10.08 30413 犬飼 未使用のため削除 >>>>>>START
        ////商品区分詳細マスタアクセスクラス
        //private DGoodsGanreAcs _dGoodsGanreAcs = null;
        ////自社分類ガイド
        //private UserGuideGuide _userGuideGuide = null;
        // 2008.10.08 30413 犬飼 未使用のため削除 <<<<<<END
        
        //ＢＬ商品マスタガイド
        private BLGoodsCdAcs _blGoodsCdAcs = null;
        // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<

        // 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
        // 棚卸準備処理アクセスクラス
        private InventoryPrepareAcs _inventoryPrepareAcs = null;
        // 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<

        // 2008.10.08 30413 犬飼 仕入先ガイドアクセスクラスの追加 >>>>>>START
        // 仕入先ガイド
        private SupplierAcs _supplierAcs;
        // 2008.10.08 30413 犬飼 仕入先ガイドアクセスクラスの追加 <<<<<<END

        // 2008.11.26 30413 犬飼 BLグループアクセスクラスの追加 >>>>>>START
        BLGroupUAcs _blGroupUAcs = null;
        // 2008.11.26 30413 犬飼 BLグループアクセスクラスの追加 <<<<<<END
        
        // 2008.11.26 30413 犬飼 在庫管理全体設定アクセスクラスの追加 >>>>>>START
        StockMngTtlStAcs _stockMngTtlStAcs = null;
        // 2008.11.26 30413 犬飼 在庫管理全体設定アクセスクラスの追加 <<<<<<END

        List<Control> ctrlList = new List<Control>();//ADD 董桂鈺 2012/12/25 for Redmine#33271
        #endregion

        #region Private Constant
        // クラスID
        private const string CT_CLASSID = "MAZAI02110UA";
        // プログラムID
        private const string CT_PGID = "MAZAI02110U";
        // プログラム名称
        private const string CT_PGNM = "棚卸関連一覧表";
        // キー情報
        private const string PRINT_KEY01 = "baa409ca-5d89-41eb-a5f0-82bf716c0641";
        private const string PRINT_KEY02 = "d45e41e1-3f42-46f5-aac3-00ac832e4a07";
        private const string PRINT_KEY03 = "b0fa554d-13d9-481a-b71b-34b202de9cfb";
      
        private const string PRINT_NAME_01 = "棚卸記入表";
        private const string PRINT_NAME_02 = "棚卸差異表";
        private const string PRINT_NAME_03 = "棚卸表";
    
        //出力順
        private const string CHANGEPAGEDIV1_01    = "仕入先別";
        private const string CHANGEPAGEDIV1_02    = "得意先別";
        private const string CHANGEPAGEDIV1_03    = "事業者別";

        //出力項目
        private const string CTOUTPUTPATERN01 = "帳簿数０出力";
        private const string CTOUTPUTPATERN02 = "棚卸数０出力";
        //日付名称
        private const string CTDATENAMEPATERN01 = "棚卸準備処理日";
        private const string CTDATENAMEPATERN02 = "棚卸日";

        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
        /// <summary> 倉庫コード </summary>
        private const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名 </summary>
        private const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 棚番 </summary>
        private const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 品番 </summary>
        private const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 品名 </summary>
        private const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 仕入先コード </summary>
        private const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先名 </summary>
        private const string ct_Col_SupplierName = "SupplierName";
        /// <summary> BLコード </summary>
        private const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> メーカーコード </summary>
        private const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名 </summary>
        private const string ct_Col_MakerName = "MakerName";
        /// <summary> 棚卸数 </summary>
        private const string ct_Col_StockCount = "StockCount";
        /// <summary> 標準価格 </summary>
        private const string ct_Col_ListPrice = "ListPrice";
        /// <summary> 在庫単価 </summary>
        private const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> 棚卸金額</summary>
        private const string ct_Col_StockAmountPrice = "StockAmountPrice";
        /// <summary> 棚卸連番</summary>
        private const string ct_Col_InventorySeqNo = "InventorySeqNo";

        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
                  
        #endregion
        
        #region Properties
        // ------------------------------
        // IPrintConditionInpTypeのプロパティ
        /// <summary>
        /// 抽出ボタン状態取得プロパティ
        /// </summary>
        public bool CanExtract
        {
            get
            {
                return this._canExtract;
            }
        }

        /// <summary>
        /// PDF出力ボタン状態取得プロパティ
        /// </summary>
        public bool CanPdf
        {
            get
            {
                return this._canPdf;
            }
        }

        /// <summary>
        /// 印刷ボタン状態取得プロパティ
        /// </summary>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>
        /// 抽出ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledExtractButton
        {
            get
            {
                return this._visibledExtractButton;
            }
        }

        /// <summary>
        /// PDF出力ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledPdfButton
        {
            get
            {
                return this._visibledPdfButton;
            }
        }

        /// <summary>
        /// 印刷ボタン表示有無プロパティ
        /// </summary>
        public bool VisibledPrintButton
        {
            get
            {
                return this._visibledPrintButton;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypeSelectedSectionのプロパティ
        /// <summary>
        /// 計上拠点選択表示取得プロパティ
        /// </summary>
        public bool VisibledSelectAddUpCd
        {
            get
            {
                return this._visibledSelectAddUpCd;
            }
        }

        /// <summary>
        /// 拠点オプション有無プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get
            {               
                return this._isOptSection;
            }
            set
            {
                this._isOptSection = value;
            }
        }

        /// <summary>
        /// 本社機能有無プロパティ
        /// </summary>
        public bool IsMainOfficeFunc
        {
            get
            {
                return this._isMainOfficeFunc;
            }
            set
            {
                this._isMainOfficeFunc = value;
            }
        }

        // ------------------------------
        // IPrintConditionInpTypePdfCareerのプロパティ用変数
        /// <summary>
        /// 帳票名称
        /// </summary>
        public string PrintName
        {
            get
            {
                return this._printName;
            }
        }

        /// <summary>
        /// 帳票キー
        /// </summary>
        public string PrintKey
        {
            get
            {
                return this._printKey;
            }
        }

        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
        // IPrintConditionInpTypeTextOutPutのプロパティ用変数
        /// <summary>
        /// 出力機能の制御
        /// </summary>
        public bool CanTextOutPut
        {
            get
            {
                return this._isCanTextOutPut;
            }
        }
        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
        #endregion

        #region Public Methods

        // ------------------------------
        // IPrintConditionInpTypeのプロパティ
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">帳票設定コード</param>
        /// <remarks>
        /// <br>Note       : 画面表示処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._selPrintMode = 0;
            //型チェック（Stringかどうか）
            if (parameter is string)
            {
                //起動モードを取得します（0：棚卸調査表、1:棚卸差異表、2:棚卸表）
                this._selPrintMode = TStrConv.StrToIntDef((string)parameter, 0);
            }
            //起動モードが0、1、2以外の値であれば、デフォルト(棚卸調査表)とする
            if ((this._selPrintMode != 0) && (this._selPrintMode != 1) && (this._selPrintMode != 2))
            {
                this._selPrintMode = 0;
            }

            switch (this._selPrintMode)
            {
                case 0:
                    {
                        this._printName = PRINT_NAME_01;
                        this._printKey = PRINT_KEY01;
                        //---ADD 董桂鈺 2012/12/25 for Redmine#33271-------------->>>>>
                        ctrlList.Clear();
                        ctrlList.Add(tComboEditor_LineMaSqOfChDiv0);        // 罫線印字
                        uiMemInput1.OptionCode = "0";//（0：棚卸調査表、1:棚卸差異表、2:棚卸表）
                        //---ADD 董桂鈺 2012/12/25 for Redmine#33271--------------<<<<<
                        break;
                    }
                case 1:
                    {
                        this._printName = PRINT_NAME_02;
                        this._printKey = PRINT_KEY02;
                        //---ADD 董桂鈺 2012/12/25 for Redmine#33271-------------->>>>>
                        ctrlList.Clear();
                        ctrlList.Add(tComboEditor_LineMaSqOfChDiv1);        // 罫線印字
                        uiMemInput1.OptionCode = "1";//（0：棚卸調査表、1:棚卸差異表、2:棚卸表）
                        //---ADD 董桂鈺 2012/12/25 for Redmine#33271--------------<<<<<
                        break;
                    }
                case 2:
                    {
                        this._printName = PRINT_NAME_03;
                        this._printKey = PRINT_KEY03;
                        //---ADD 董桂鈺 2012/12/25 for Redmine#33271-------------->>>>>
                        ctrlList.Clear();
                        ctrlList.Add(tComboEditor_LineMaSqOfChDiv2);        // 罫線印字
                        uiMemInput1.OptionCode = "2";//（0：棚卸調査表、1:棚卸差異表、2:棚卸表）
                        //---ADD 董桂鈺 2012/12/25 for Redmine#33271--------------<<<<<
                        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
                        PurchaseStatus sletuPurchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinetsuInventoryListCtl);
                        if (sletuPurchaseStatus == PurchaseStatus.Contract ||// 契約済
                                sletuPurchaseStatus == PurchaseStatus.Trial_Contract)// 体験版契約済
                        {
                            this._isCanTextOutPut = true;
                        }
                        if (TextOutControlCall != null)
                        {
                            this.TextOutControlCall();
                        }
                        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
                        break;
                    }
            }
            uiMemInput1.TargetControls = ctrlList;//ADD 董桂鈺 2012/12/25 for Redmine#33271
            this.Show();
        }

        /// <summary>
        /// 印刷前入力チェック
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 印刷前入力チェックを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool result = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                result = false;
            }

            return result;
        }
      		
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">印刷情報パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = CT_PGID;// 起動PGID
            //起動モード別に設定コードをセット
            switch(this._selPrintMode)
            {
                //棚卸調査表
                case 0:
                {
                    printInfo.PrintPaperSetCd = 0;
                    break;
                }
                //棚卸差異表
                case 1:
                {
                    printInfo.PrintPaperSetCd = 10;
                    break;
                }
                //棚卸表
                case 2:
                {
                    printInfo.PrintPaperSetCd = 20;
                    break;
                }
            }
            
            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // 画面→抽出条件クラス
            int status = this.SetExtrInfoFromScreen(ref this._inventSearchCndtnUI);
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._inventSearchCndtnUI;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">印刷情報パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無し
            //return 0;//DEL licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する
            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            PurchaseStatus sletuPurchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinetsuInventoryListCtl);
            if (sletuPurchaseStatus == PurchaseStatus.Contract ||// 契約済
                    sletuPurchaseStatus == PurchaseStatus.Trial_Contract)// 体験版契約済
            {
                SFCMN06002C outTextInfo = (SFCMN06002C)parameter;
                if (_textOutDialog == null)
                {
                    _textOutDialog = new MAZAI02110UB();
                }
                if (_textOutDialog.ShowDialog() == DialogResult.OK)
                {
                    //出力ファイル名
                    this._outPutFileName = _textOutDialog._outPutFileName;
                    string resultMessage = "";
                    emErrorLevel iLevel = emErrorLevel.ERR_LEVEL_INFO;
                    SFCMN00299CA form = new SFCMN00299CA();
                    // 表示文字を設定
                    form.Title = "テキスト抽出中";
                    form.Message = "現在、データを抽出中です。" + "\r\n" + "しばらくお待ちください";
                    try
                    {
                        // ダイアログ表示
                        form.Show();
                        this.Cursor = Cursors.WaitCursor;
                        InventSearchCndtnUI textOutInventSearchCndtnUI = new InventSearchCndtnUI();

                        // 画面→抽出条件クラス
                        this.SetExtrInfoFromScreen(ref textOutInventSearchCndtnUI);

                        //検索
                        //データ取得
                        string message = string.Empty;
                        status = this._inventoryListCmnAcs.Search(textOutInventSearchCndtnUI, out message);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // フィルター文字列
                            string strFilter = string.Empty;
                            // ソート文字列を取得
                            string strSort = this.MakeSortingOrderString(textOutInventSearchCndtnUI);

                            DataView dv = new DataView(this._inventoryListCmnAcs._printDataSet.Tables[MAZAI02114EA.InventoryListDataTable], strFilter, strSort, DataViewRowState.CurrentRows);

                            if (dv.Count > 0)
                            {
                                // データをセット
                                outTextInfo.rdData = dv;
                                outTextInfo.jyoken = textOutInventSearchCndtnUI;
                                parameter = (object)outTextInfo;

                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                resultMessage = "該当するデータがありません。";
                                iLevel = emErrorLevel.ERR_LEVEL_INFO;
                            }
                        }
                        //// 該当データ無し
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            resultMessage = "該当するデータがありません。";
                            iLevel = emErrorLevel.ERR_LEVEL_INFO;
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        // ダイアログを閉じる
                        form.Close();
                    }
                    // メッセージ表示
                    if (!string.IsNullOrEmpty(resultMessage))
                    {
                        TMsgDisp.Show(iLevel, CT_PGID, resultMessage, 0, MessageBoxButtons.OK);
                    }
                }
            }
                return status;
            
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

        }

        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
        #region IPrintConditionInpTypeTextOutPut メンバ
        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="parameter">出力Info</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        public int OutPutText(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            //仕入先情報を取得
            this.GetSupplierInfo();
            //倉庫情報を取得
            this.GetWareHouseInfo();
            //メーカー情報を取得
            this.GetMakerInfo();
            //在庫管理全体設定情報を取得
            this.GetStockMngTtl();

            SFCMN06002C outPutTextInfo = (SFCMN06002C)parameter;
            DataTable dataTable = new DataTable();

            //DataTableのColumnsを追加する
            this.CreateDataTable(ref dataTable);

            DataView dv = outPutTextInfo.rdData as DataView;
            char[] zero ={'0'};
            DataTable dt = dv.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                // 倉庫コード 
                dataRow[ct_Col_WarehouseCode] = dt.Rows[i][MAZAI02114EA.ctCol_WarehouseCode].ToString().TrimStart(zero);
                //倉庫名
                dataRow[ct_Col_WarehouseName] = this.GetWareHouseName(dt.Rows[i][MAZAI02114EA.ctCol_WarehouseCode].ToString());
                //棚番
                dataRow[ct_Col_WarehouseShelfNo] = dt.Rows[i][MAZAI02114EA.ctCol_WarehouseShelfNo];
                //品番
                dataRow[ct_Col_GoodsNo] = dt.Rows[i][MAZAI02114EA.ctCol_GoodsNo];
                //品名
                dataRow[ct_Col_GoodsName] = dt.Rows[i][MAZAI02114EA.ctCol_GoodsName];
                //仕入先コード
                dataRow[ct_Col_SupplierCd] = dt.Rows[i][MAZAI02114EA.ctCol_SupplierCd];
                //仕入先名
                dataRow[ct_Col_SupplierName] = this.GetSupplierName((Int32)dt.Rows[i][MAZAI02114EA.ctCol_SupplierCd]);
                //BLコード
                dataRow[ct_Col_BLGoodsCode] = dt.Rows[i][MAZAI02114EA.ctCol_BLGoodsCode];
                //メーカーコード
                dataRow[ct_Col_GoodsMakerCd] = dt.Rows[i][MAZAI02114EA.ctCol_GoodsMakerCd];
                //メーカー名
                dataRow[ct_Col_MakerName] = this.GetMakerName((Int32)dt.Rows[i][MAZAI02114EA.ctCol_GoodsMakerCd]);
                //棚卸数
                dataRow[ct_Col_StockCount] = Math.Floor(GetStockCount(dt.Rows[i]));
                //標準価格
                dataRow[ct_Col_ListPrice] = Math.Round(Convert.ToDouble(dt.Rows[i][MAZAI02114EA.ctCol_ListPriceTextOut]), 0);
                //在庫単価
                dataRow[ct_Col_StockUnitPriceFl] = Math.Round(Convert.ToDouble(dt.Rows[i][MAZAI02114EA.ctCol_StockUnitPriceFl]), 2);
                //棚卸金額
                dataRow[ct_Col_StockAmountPrice] = (long)Math.Floor(GetStockCount(dt.Rows[i]) * Convert.ToDouble(dataRow[ct_Col_StockUnitPriceFl]) + 0.5);
                //棚卸連番
                dataRow[ct_Col_InventorySeqNo] = dt.Rows[i][MAZAI02114EA.ctCol_InventorySeqNo];

                dataTable.Rows.Add(dataRow);

            }

            // 抽出データ取得
            FormattedTextWriter printInfo = new FormattedTextWriter();
            Object paraInfo = (object)printInfo;

            // CSV出力情報処理
            this.GetCSVInfo(ref paraInfo, dataTable, _outPutFileName);

            emErrorLevel iLevel = emErrorLevel.ERR_LEVEL_INFO;
            string resultMessage = string.Empty;
            // CSV出力処理
            status = this.DoOutPut(ref paraInfo, ref resultMessage, ref iLevel);
            // メッセージ表示
            if (!string.IsNullOrEmpty(resultMessage))
            {
                TMsgDisp.Show(iLevel, CT_PGID, resultMessage, 0, MessageBoxButtons.OK);
            }

            return status;

        }

        /// <summary>
        /// 棚卸数を取得
        /// </summary>
        /// <param name="dataRow">DataRow</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 棚卸数を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private double GetStockCount(DataRow dataRow)
        {
            double stockCount = 0;
            if (_stockMngTtlSt.InventoryMngDiv == 1) // 棚卸運用区分＝PM7
            {
                //棚卸数 = 棚卸在庫数（InventoryStockCnt）
                stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_InventoryStockCntTextOut]);
                try
                {
                    DateTime dt = this.GetDateTime((dataRow[MAZAI02114EA.ctCol_InventoryDay].ToString()));
                    if (dt == DateTime.MinValue)           // 棚卸未入力のレコード
                      
                    {
                        //棚卸数 = 在庫総数（StockTotal）
                        stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_StockTotal]);
                    }
                }
                catch
                {
                    //棚卸数 = 在庫総数（StockTotal）
                    stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_StockTotal]);
                }
            }
            else                                        // 棚卸運用区分＝PM.NS
            {
                //棚卸数 = 在庫総数（StockTotal） + 棚卸差異数（InventoryTolerancCnt）
                stockCount = Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_StockTotal]) +  Convert.ToDouble(dataRow[MAZAI02114EA.ctCol_InventoryTolerancCnt]);
            }

            return stockCount;
        }

        /// <summary>
        ///stringからDateTimeに転換
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Int64からDateTimeに転換。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private  DateTime GetDateTime(string date)
        {
            DateTime dt = DateTime.MinValue;
            try
            {
                if (date.ToString().Length == 8)
                {
                    string DateStr = date.ToString();
                    int year = Convert.ToInt32(DateStr.Substring(0, 4));
                    int month = Convert.ToInt32(DateStr.Substring(4, 2));
                    int day = Convert.ToInt32(DateStr.Substring(6, 2));

                    dt = new DateTime(year, month, day);
                }
            }
            catch
            {
                 dt = DateTime.MinValue;
            }
            return dt;

        }

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add(ct_Col_WarehouseCode, typeof(Int32));// 倉庫コード
            dataTable.Columns.Add(ct_Col_WarehouseName, typeof(string));//倉庫名
            dataTable.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));//棚番
            dataTable.Columns.Add(ct_Col_GoodsNo, typeof(string));//品番
            dataTable.Columns.Add(ct_Col_GoodsName, typeof(string));//品名
            dataTable.Columns.Add(ct_Col_SupplierCd, typeof(Int32));//仕入先コード
            dataTable.Columns.Add(ct_Col_SupplierName, typeof(string));//仕入先名
            dataTable.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));//BLコード
            dataTable.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));//メーカーコード
            dataTable.Columns.Add(ct_Col_MakerName, typeof(string));//メーカー名
            dataTable.Columns.Add(ct_Col_StockCount, typeof(long));//棚卸数
            dataTable.Columns.Add(ct_Col_ListPrice, typeof(Int32));//標準価格
            dataTable.Columns.Add(ct_Col_StockUnitPriceFl, typeof(double));//在庫単価
            dataTable.Columns.Add(ct_Col_StockAmountPrice, typeof(long));//棚卸金額
            dataTable.Columns.Add(ct_Col_InventorySeqNo, typeof(long));//棚卸連番
        }

        /// <summary>
        ///仕入先情報を取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先情報を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetSupplierInfo()
        {
            ArrayList tempAl = new ArrayList();

            this._supplierAcs.SearchAll(out tempAl, _enterpriseCode);

            _supplierAl = tempAl;

        }

        /// <summary>
        ///倉庫情報を取得
        /// </summary>
        /// <remarks>
        /// <br>Note       :　倉庫情報を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetWareHouseInfo()
        {
            ArrayList tempAl = new ArrayList();

            this._warehouseAcs.SearchAll(out tempAl, _enterpriseCode);

            _warehouseAl = tempAl;

        }

        /// <summary>
        ///メーカー情報を取得
        /// </summary>
        /// <remarks>
        /// <br>Note       :　メーカー情報を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetMakerInfo()
        {
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();
            }
            ArrayList tempAl = new ArrayList();
            this._makerAcs.SearchAll(out tempAl, _enterpriseCode);
            _MakerAl = tempAl;
        }

        /// <summary>
        ///在庫全体設定情報を取得
        /// </summary>
        /// <remarks>
        /// <br>Note       :　在庫全体設定情報を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void GetStockMngTtl()
        {
            StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
            if(_stockMngTtlStAcs == null)
            {
                _stockMngTtlStAcs =new StockMngTtlStAcs();
            }
            if (_stockMngTtlSt == null)
            {
                _stockMngTtlSt = new StockMngTtlSt();
            }
             ArrayList tempAl = new ArrayList();
             this._stockMngTtlStAcs.SearchAll(out tempAl, _enterpriseCode);
             _stockMngTtlStAl = tempAl;
             foreach (StockMngTtlSt TempStockMngTtlSt in _stockMngTtlStAl)
             {
                 if ((TempStockMngTtlSt.LogicalDeleteCode == 0) && (TempStockMngTtlSt.SectionCode.Trim() == "00"))
                 {
                     _stockMngTtlSt = TempStockMngTtlSt;
                     break;
                 }
             }
        }

        /// <summary>
        /// 仕入先名称を取得
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string GetSupplierName(int supplierCode)
        {
           
            string resultName = string.Empty;
            bool flag = false;
            int logicalDel = 0;
            if (supplierCode != 0)
            {
                foreach (Supplier supplier in _supplierAl)
                {
                    if (supplier.SupplierCd == supplierCode)
                    {
                        resultName = supplier.SupplierSnm;
                        logicalDel = supplier.LogicalDeleteCode;
                        flag = true;
                        break;
                    }

                }
                //有効か論理削除のデータ
                if (flag)
                {
                    if (logicalDel == 1)
                    {
                        resultName = "＊" + resultName;
                    }
                }
                //完全削除の場合
                else
                {
                    resultName = "未登録";
                }
            }

            return resultName;
        }

        /// <summary>
        /// 倉庫名称を取得
        /// </summary>
        /// <param name="wareHouseCode">仕入先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string GetWareHouseName(string wareHouseCode)
        {
            string resultName = string.Empty;
            bool flag = false;
            int logicalDel = 0;
            if (!string.IsNullOrEmpty(wareHouseCode))
            {
                foreach (Warehouse warehouse in _warehouseAl)
                {
                    if (warehouse.WarehouseCode.Trim().Equals(wareHouseCode.Trim()))
                    {
                        resultName = warehouse.WarehouseName;
                        logicalDel = warehouse.LogicalDeleteCode;
                        flag = true;
                        break;
                    }

                }
                //有効か論理削除のデータ
                if (flag)
                {
                    if (logicalDel == 1)
                    {
                        resultName = "＊" + resultName;
                    }
                }
                //完全削除の場合
                else
                {
                    resultName = "未登録";
                }
            }

            return resultName;
 
        }

        /// <summary>
        /// メーカ名称を取得
        /// </summary>
        /// <param name="makerCode">仕入先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : メーカ名称を取得。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string resultName = string.Empty;
            bool flag = false;
            int logicalDel = 0;
            if (makerCode != 0)
            {
                foreach (MakerUMnt makerUMnt in _MakerAl)
                {
                    if (makerUMnt.GoodsMakerCd == makerCode)
                    {
                        resultName = makerUMnt.MakerName;
                        logicalDel = makerUMnt.LogicalDeleteCode;
                        flag = true;
                        break;
                    }

                }
                //有効か論理削除のデータ
                if (flag)
                {
                    if (logicalDel == 1)
                    {
                        resultName = "＊" + resultName;
                    }
                }
                //完全削除の場合
                else
                {
                    resultName = "未登録";
                }
            }

            return resultName;

        }

        /// <summary>
        /// CSV出力情報処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <param name="dt">データ</param>
        /// <param name="outPutFileName">出力パース</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private int GetCSVInfo(ref object parameter, DataTable dt, string outPutFileName)
        {
            List<string> schemeList = new List<string>();

            //倉庫コード  
            schemeList.Add(ct_Col_WarehouseCode);
            //倉庫名
            schemeList.Add(ct_Col_WarehouseName);
            //棚番 
            schemeList.Add(ct_Col_WarehouseShelfNo);
            //品番
            schemeList.Add(ct_Col_GoodsNo);
            //品名
            schemeList.Add(ct_Col_GoodsName);
            //仕入先コード 
            schemeList.Add(ct_Col_SupplierCd);
            //仕入先名 
            schemeList.Add(ct_Col_SupplierName);
            //BLコード 
            schemeList.Add(ct_Col_BLGoodsCode);
            //メーカーコード 
            schemeList.Add(ct_Col_GoodsMakerCd);
            //メーカー名 
            schemeList.Add(ct_Col_MakerName);
            //棚卸数 
            schemeList.Add(ct_Col_StockCount);
            //標準価格 
            schemeList.Add(ct_Col_ListPrice);
            //在庫単価 
            schemeList.Add(ct_Col_StockUnitPriceFl);
            //棚卸金額
            schemeList.Add(ct_Col_StockAmountPrice);
            //棚卸連番
            schemeList.Add(ct_Col_InventorySeqNo);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());
            enclosingTypeList.Add(typeof(System.Int32));
            enclosingTypeList.Add(typeof(System.Int64));
            enclosingTypeList.Add(typeof(System.Double));
            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();

            maxLengthList.Add(ct_Col_WarehouseCode, 4);
            maxLengthList.Add(ct_Col_WarehouseName, 40);
            maxLengthList.Add(ct_Col_WarehouseShelfNo, 8);
            maxLengthList.Add(ct_Col_GoodsNo, 24);
            maxLengthList.Add(ct_Col_GoodsName, 40);
            maxLengthList.Add(ct_Col_SupplierCd, 6);
            maxLengthList.Add(ct_Col_SupplierName, 20);
            maxLengthList.Add(ct_Col_BLGoodsCode, 5);
            maxLengthList.Add(ct_Col_GoodsMakerCd, 4);
            maxLengthList.Add(ct_Col_MakerName, 30);
            maxLengthList.Add(ct_Col_StockCount, 7);
            maxLengthList.Add(ct_Col_ListPrice, 7);
            maxLengthList.Add(ct_Col_StockUnitPriceFl, 10);
            maxLengthList.Add(ct_Col_StockAmountPrice, 9);
            maxLengthList.Add(ct_Col_InventorySeqNo, 9);

            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;
            formattedTextWriter.DataSource = dt;
            formattedTextWriter.DataMember = String.Empty;
            //テキストファイル出力パスの取得
            formattedTextWriter.OutputFileName = outPutFileName;
            //テキスト出力する項目名のリスト
            formattedTextWriter.SchemeList = schemeList;
            formattedTextWriter.Splitter = ",";
            formattedTextWriter.Encloser = "\"";
            formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            Dictionary<string, string> formatDic= new Dictionary<string, string>();
            //倉庫コード  
            formatDic.Add(ct_Col_WarehouseCode,string.Empty);
            //倉庫名
            formatDic.Add(ct_Col_WarehouseName, string.Empty);
            //棚番 
            formatDic.Add(ct_Col_WarehouseShelfNo, string.Empty);
            //品番
            formatDic.Add(ct_Col_GoodsNo, string.Empty);
            //品名
            formatDic.Add(ct_Col_GoodsName, string.Empty);
            //仕入先コード 
            formatDic.Add(ct_Col_SupplierCd, string.Empty);
            //仕入先名 
            formatDic.Add(ct_Col_SupplierName, string.Empty);
            //BLコード 
            formatDic.Add(ct_Col_BLGoodsCode, string.Empty);
            //メーカーコード 
            formatDic.Add(ct_Col_GoodsMakerCd, string.Empty);
            //メーカー名 
            formatDic.Add(ct_Col_MakerName, string.Empty);
            //棚卸数 
            formatDic.Add(ct_Col_StockCount, string.Empty);
            //標準価格 
            formatDic.Add(ct_Col_ListPrice, string.Empty);
            //在庫単価 
            formatDic.Add(ct_Col_StockUnitPriceFl, "0.00");
            //棚卸金額
            formatDic.Add(ct_Col_StockAmountPrice, string.Empty);
            //棚卸連番
            formatDic.Add(ct_Col_InventorySeqNo, string.Empty);
            formattedTextWriter.FormatList = formatDic;
            formattedTextWriter.CaptionOutput = false;
            formattedTextWriter.FixedLength = true;
            formattedTextWriter.ReplaceList = null;
            formattedTextWriter.MaxLengthList = maxLengthList;

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="parameter">出力Info</param>
        /// <param name="iLevel"></param>
        /// <param name="resultMessage"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private int DoOutPut(ref object parameter, ref string resultMessage, ref emErrorLevel iLevel)
        {
            int status = 0;
            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;

            try
            {
                int totalCount;
                status = formattedTextWriter.SietuTextOut(out totalCount);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    return status;
                }
            }
            catch
            {
                status = -1;
            }
            switch (status)
            {
                case 0:    // 処理成功
                    _textOutDialog.WriteMemInput();
                    resultMessage = "抽出処理が終了しました。";
                    iLevel = emErrorLevel.ERR_LEVEL_INFO;
                    break;
                case 1:    // 対象データなし
                    resultMessage = "出力処理を中断しました。";
                    iLevel = emErrorLevel.ERR_LEVEL_INFO;
                    break;
                default:    // その他エラー
                    resultMessage = "テキストファイルの書き込みに失敗しました。";
                    iLevel = emErrorLevel.ERR_LEVEL_STOP;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ソート文字列作成処理
        /// </summary>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note	   : ソート文字列作成処理。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string MakeSortingOrderString(InventSearchCndtnUI searchCndtn)
        {
            string sortStr = "";
            switch (searchCndtn.SortDiv)
            {

                case 0:             // 棚番順
                    {

                        break;
                    }
                case 1:             // 仕入先順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //仕入先
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 2:             // ＢＬコード順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //ＢＬコード
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGoodsCode, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 3:             // グループコード順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //グループコード
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGroupCode, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 4:             // メーカー順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
                case 5:             // 仕入先・棚番順
                    {

                        break;
                    }
                case 6:             // 仕入先・メーカー順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //仕入先
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
            }

            return sortStr;
        }

        /// <summary>
        /// ソート用文字列作成処理
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="ascDescDiv">昇順・降順区分[0:昇順, 1:降順]</param>
        /// <param name="strQuery">ソート用文字列</param>
        /// <remarks>
        /// <br>Note	   : ソート用文字列作成処理。</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
        {
            if (strQuery == null)
            {
                strQuery = "";
            }

            if (strQuery == "")
            {
                strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
            else
            {
                strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
        }

        #endregion

        #region IPrintConditionInpTypeTextOutControl メンバ
        /// <summary>
        /// テキスト出力ボタンの制御
        /// </summary>
        public event TextOutControl TextOutControlCall;

        #endregion

        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

        // ------------------------------
        // IPrintConditionInpTypeSelectedSectionのプロパティ
        /// <summary>
        /// 初期選択計上拠点設定処理
        /// </summary>
        /// <param name="addUpCd">選択拠点種別</param>
        /// <remarks>
        /// <br>Note       : 選択されている計上拠点を設定します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 未使用
        }

        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点</param>
        /// <param name="checkState"></param>
        /// <remarks>
        /// <br>Note       : 拠点選択処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, System.Windows.Forms.CheckState checkState)
        {
           //未実装
        }       

        /// <summary>
        /// 計上拠点選択処理
        /// </summary>
        /// <param name="addUpCd">選択拠点種別</param>
        /// <remarks>
        /// <br>Note       : 計上拠点選択処理</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 未使用
        }

        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 選択されている拠点を設定します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            if (sectionCodeLst.Length == 0)
            {
                return;
            }        
        }

        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">初期表示有無ステータス</param>
        /// <returns>変更後表示有無ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点選択スライダーの表示有無を判定します。</br>
        /// <br>           : 拠点オプション、本社機能以外の個別の表示有無判定を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            //拠点選択スライダーを非表示にする
            return false;
        }
        #endregion

        #region Private Methods

        #region 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2009/12/04 呉元嘯</br>
        /// <br>             棚卸日の取得不正対応</br>
        /// <br>Update Note: 2011/01/11 liyp</br>
        /// <br>             出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
        /// <br>Update Note: 2011/01/11 田建委</br>
        /// <br>			 棚卸障害対応</br> 
        /// <br>Update Note: 2012/11/14 李亜博</br>
        ///	<br>			 Redmine#33271 印字制御の区分の追加</br>
        /// <br>Update Note : 2012/12/25 董桂鈺</br>
        ///	<br>			  Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
           
            // 2008.10.07 30413 犬飼 処理別の画面初期化処理を変更 >>>>>>START
            //帳票の種類により処理を分ける
            switch(this._selPrintMode)
            {
                case 0:
                {
                    //棚卸調査表？
                    //this.Condition_panel1.Visible = true;
                    //this.Condition_panel2.Visible = false;
                    //// 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel3.Visible = true;
                    //this.Condition_panel3.Visible = false;
                    //// 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    //this.Condition_panel4.Visible = false;
                    //this.Condition_panel5.Visible = true;                  
                    ////this.Condition_panel6.Visible = true;
                    //// 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel7.Visible = true;
                    //this.Condition_panel6.Visible = true;
                    //// 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<
                    
                    // 出力条件 表示設定
                    this.Condition_panel1.Visible = true;
                    this.Condition_panel2.Visible = true;
                    this.Condition_panel3.Visible = true;
                    this.Condition_panel4.Visible = false;
                    //this.Condition_panel5.Visible = false;// DEL 2010/02/20
                    this.Condition_panel6.Visible = true;
                    this.Condition_panel8.Visible = false;
                    this.Condition_panel7.Visible = false;
                    // -----------ADD 2010/02/20---------->>>>>
                    this.Condition_panel5.Visible = true;
                    this.CustomerPrintDiv_Title.Visible = true;
                    this.tComboEditor_SubtotalPrint.Visible = false;
                    // 計印字(調査表)
                    this.CustomerPrintDivTemp_Title.Visible = true;
                    this.tComboEditor_SubtotalPrintTemp.Visible = true;
                    // -----------ADD 2010/02/20----------<<<<<
                  
                    //this.ZeroExtraDiv_Title.Text = CTOUTPUTPATERN01;
                    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this.Date_Title.Text = CTDATENAMEPATERN01;
                    //this.Date_Title.Text = CTDATENAMEPATERN02;
                    // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;

                    // 出力条件の高さ調整
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;// DEL 2010/02/20
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 145;// ADD 2010/02/20 //DEL 2012/11/14 李亜博 for Redmine#33271
                    this.Main_UltraExplorerBar.Groups[0].Container.Height = 174;//ADD 2012/11/14 李亜博 for Redmine#33271
                    // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    //コンボボックスにソート順をセット
                    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods));
                    //// 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv));
                    //// 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker));
                    // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.SequenceNumber,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.SequenceNumber));
   
                    //this.ChangePageDiv_tComboEditor.MaxDropDownItems = this.ChangePageDiv_tComboEditor.Items.Count;
                    
                   

                    break;
                }
                case 1:
                {
                    //棚卸差異表
                    ////2007/04/24
                    ////帳簿数０出力を画面から消す。
                    ////これにより帳簿数０の物は常に出力される
                    //this.Condition_panel1.Visible = true;
                    //this.Condition_panel2.Visible = true;
                    //// 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel3.Visible = true;
                    //this.Condition_panel3.Visible = false;
                    //// 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    //this.Condition_panel4.Visible = false;
                    //this.Condition_panel5.Visible = true;                  
                    ////this.Condition_panel6.Visible = false;
                    //// 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel7.Visible = false;
                    //this.Condition_panel6.Visible = true;
                    //// 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<

                    // 出力条件 表示設定
                    this.Condition_panel1.Visible = true;
                    this.Condition_panel2.Visible = false;
                    this.Condition_panel3.Visible = true;
                    this.Condition_panel4.Visible = false;
                    this.Condition_panel5.Visible = true;
                    this.Condition_panel6.Visible = true;
                    this.Condition_panel7.Visible = false;
                    this.Condition_panel8.Visible = false;

                    //this.ZeroExtraDiv_Title.Text = CTOUTPUTPATERN01;
                    //this.Date_Title.Text = CTDATENAMEPATERN02;
                    //コンテナの幅を調整
                    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;

                    // 出力条件の高さ調整
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;//DEL 2012/11/14 李亜博 for Redmine#33271
                    this.Main_UltraExplorerBar.Groups[0].Container.Height = 145;//ADD 2012/11/14 李亜博 for Redmine#33271
                    // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    //コンボボックスにソート順をセット
                    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods));
                    //// 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv));
                    //// 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker));
                    //// 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    ////this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.SequenceNumber,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.SequenceNumber));   

                    //this.ChangePageDiv_tComboEditor.MaxDropDownItems = this.ChangePageDiv_tComboEditor.Items.Count;

                    // ----- UPD 2011/01/11 ------------------------------------->>>>>
                    //// 抽出条件 表示設定
                    //this.uLabel_LendExtraDiv.Visible = false;
                    //this.tComboEditor_LendExtraDiv.Visible = false;
                    //this.uLabel_DelayPaymentDiv.Visible = false;
                    //this.tComboEditor_DelayPaymentDiv.Visible = false;
                    ////抽出条件の高さ調整
                    //this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height - 58;

                    // 抽出条件 表示設定
                    this.uLabel_LendExtraDiv.Visible = true;
                    this.tComboEditor_LendExtraDiv.Visible = true;
                    this.uLabel_DelayPaymentDiv.Visible = true;
                    this.tComboEditor_DelayPaymentDiv.Visible = true;
                    // ----- UPD 2011/01/11 -------------------------------------<<<<<

                    break;
                }
                case 2:
                {
                    //棚卸表
                    //this.Condition_panel1.Visible = true;
                    //this.Condition_panel2.Visible = false;
                    //this.Condition_panel3.Visible = true;
                    //this.Condition_panel4.Visible = true;
                    //this.Condition_panel5.Visible = true;                  
                    ////this.Condition_panel6.Visible = false;
                    //// 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
                    ////this.Condition_panel7.Visible = false;
                    //this.Condition_panel6.Visible = true;
                    //// 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<

                    // 出力条件 表示設定
                    this.Condition_panel1.Visible = true;
                    this.Condition_panel2.Visible = false;
                    this.Condition_panel3.Visible = true;
                    this.Condition_panel4.Visible = true;
                    this.Condition_panel5.Visible = true;
                    this.Condition_panel6.Visible = true;
                    this.Condition_panel7.Visible = true;
                    this.Condition_panel8.Visible = true;


                    //this.ZeroExtraDiv_Title.Text = CTOUTPUTPATERN02;
                    //this.Date_Title.Text = CTDATENAMEPATERN02;
                    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 116;

                    // 出力条件の高さ調整
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 145;//DEL 2011/01/11
                    //this.Main_UltraExplorerBar.Groups[0].Container.Height = 202;//ADD 2011/01/11 //DEL 2012/11/14 李亜博 for Redmine#33271
                    this.Main_UltraExplorerBar.Groups[0].Container.Height = 231;//ADD 2012/11/14 李亜博 for Redmine#33271
                    // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                    //コンボボックスにソート順をセット
                    //通番を含まない
                    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods,InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods));
                    //// 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv));
                    //// 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Maker));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo));
                    //this.ChangePageDiv_tComboEditor.Items.Add((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker, InventSearchCndtnUI.GetTargetSortTitle((int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker));
                    // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                 
                    //this.ChangePageDiv_tComboEditor.MaxDropDownItems = this.ChangePageDiv_tComboEditor.Items.Count;

                    // 抽出条件 表示設定
                    //----------------DEL 2011/01/11--------------->>>>>
                    //this.uLabel_LendExtraDiv.Visible = false;
                    //this.tComboEditor_LendExtraDiv.Visible = false;
                    //this.uLabel_DelayPaymentDiv.Visible = false;
                    //this.tComboEditor_DelayPaymentDiv.Visible = false;
                    //----------------DEL 2011/01/11---------------<<<<<
                    //抽出条件の高さ調整
                    //this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height - 58;
                    this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height;

                    break;
                }
            }
            
            // 出力条件の初期値設定
            // 出力指定
            this.tComboEditor_OutputAppointDiv.Value = 0;
            // 在庫区分
            this.tComboEditor_StockDiv.Value = 1;
            // 棚卸未入力区分
            this.tComboEditor_InventoryNonInputDiv.Value = 0;//ADD 2011/01/11
            
            //棚番出力区分
            this.tComboEditor_WarehouseShelfOutputDiv.Value = 0;
            // 小計印字
            this.tComboEditor_SubtotalPrint.Value = 0;
            // -----------ADD 2010/02/20----------->>>>>
            // 計印字
            this.tComboEditor_SubtotalPrintTemp.Value = 0;
            // -----------ADD 2010/02/20-----------<<<<<
            // 改ページ
            this.tComboEditor_NewPageDiv.Value = 0;
            // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
            //罫線印字区分
            this.tComboEditor_LineMaSqOfChDiv.Value = 0;
            // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

            // 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
            ////抽出画面の高さ調整
            //this.Main_UltraExplorerBar.Groups[2].Container.Height = this.Main_UltraExplorerBar.Groups[2].Container.Height - 29;
            //棚番ブレイク区分をデフォルトで選択
            this.ShelfNoBreakDiv_tComboEditor.SelectedIndex = 0;
            // 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<

            // 抽出条件の初期値設定
            // 貸出分
            this.tComboEditor_LendExtraDiv.Value = 0;
            // 来勘計上分
            this.tComboEditor_DelayPaymentDiv.Value = 0;
            //----------------ADD 2011/01/11--------------->>>>>
            if ((int)this.tComboEditor_InventoryNonInputDiv.Value == 0)
            {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "全て出力");
                tComboEditor_NumOutputDiv.Items.Add(1, "棚卸数１以上出力");
                tComboEditor_NumOutputDiv.Items.Add(2, "棚卸数０以下出力");
                tComboEditor_NumOutputDiv.Items.Add(3, "棚卸数０のみ出力");
            }
            else {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "全て出力");
                tComboEditor_NumOutputDiv.Items.Add(4, "未入力のみ出力");
                tComboEditor_NumOutputDiv.Items.Add(5, "未入力以外出力");
            }
            //数量出力区分
            this.tComboEditor_NumOutputDiv.Value = 0;
            //----------------ADD 2011/01/11---------------<<<<<

            //---ADD 董桂鈺 2012/12/25 for Redmine#33271 ---->>>>>>>>>
            tComboEditor_LineMaSqOfChDiv0.Value = 0;
            tComboEditor_LineMaSqOfChDiv1.Value = 0;
            tComboEditor_LineMaSqOfChDiv2.Value = 0;
            //---ADD 董桂鈺 2012/12/25 for Redmine#33271 ----<<<<<<<<<

            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            //終了対象年月日にシステム日付をセット
            //this.EndDate_tDateEdit.SetDateTime(TDateTime.GetSFDateNow());

            // 2008.12.10 30413 犬飼 棚卸準備処理が未実施の場合は空白とする >>>>>>START
            //// 2008.12.02 30413 犬飼 初期値にシステム日付をセット >>>>>>START
            //// 初期値としてシステム日付をセット
            //this.StartDate_tDateEdit.SetDateTime(DateTime.Now);
            //// 2008.12.02 30413 犬飼 初期値にシステム日付をセット <<<<<<END
            // 2008.12.10 30413 犬飼 棚卸準備処理が未実施の場合は空白とする <<<<<<END
            
            //対象年月日に最終棚卸準備処理日付をセット
            //履歴データ取得
            //--------- UPD 2009/12/04 --------->>>>>
            DataSet prtIvntHisDataSet;
            DataView dv = new DataView();
            DataView dataView = new DataView();
            this._inventoryPrepareAcs.Read(out prtIvntHisDataSet);
            dv.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            dataView.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            // ログイン拠点
            dv.RowFilter = String.Format("{0}={1}", InventoryPrepareAcs.ctSectionCode, this._sectionCode);
            // ソート順：更新日付
            dv.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";
            // ログイン拠点に該当するデータ有り：ログイン拠点に該当する最新データから棚卸日を取得
            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    // 削除した履歴データは対象外
                    if ((int)drv[InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((drv[InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)drv[InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.StartDate_tDateEdit.SetLongDate((int)drv[InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // ログイン拠点に該当するデータ無し：拠点に関係なく最新データから棚卸日を取得
            else
            {
                // ソート順：更新日付
                dataView.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";

                // 棚卸日
                foreach (DataRowView drv in dataView)
                {
                    // 削除した履歴データは対象外
                    if ((int)drv[InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((drv[InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)drv[InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.StartDate_tDateEdit.SetLongDate((int)drv[InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // ソート順設定
            //dv.Sort = InventoryPrepareAcs.ctInventoryDate_Int + "," + InventoryPrepareAcs.ctInventoryPreprDate_Int + " DESC," + InventoryPrepareAcs.ctInventoryPreprTime_Int + " DESC";
            //for (int ix = 0; ix < dv.Count; ix++)
            //{
            //    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
            //    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
            //        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
            //    {
            //        this.StartDate_tDateEdit.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
            //        break;
            //    }
            //}
            //--------- UPD 2009/12/04 ---------<<<<<
            // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<

            ////倉庫-商品をデフォルトで選択
            //this.ChangePageDiv_tComboEditor.SelectedIndex = 0;
            // 在庫管理全体設定マスタから棚卸印刷順初期設定区分を取得
            int invntryPrtOdrIniDiv = 0;
            ArrayList retList = new ArrayList();
            int status = this._stockMngTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (StockMngTtlSt stockMngTtlStl in retList)
                {
                    if (this._sectionCode.TrimEnd() == stockMngTtlStl.SectionCode.TrimEnd())
                    {
                        // 自拠点のデータが存在
                        invntryPrtOdrIniDiv = stockMngTtlStl.InvntryPrtOdrIniDiv;
                        break;
                    }

                    if (stockMngTtlStl.SectionCode.TrimEnd() == "00")
                    {
                        // 全社設定は取得だけ行う
                        invntryPrtOdrIniDiv = stockMngTtlStl.InvntryPrtOdrIniDiv;
                    }
                }                
            }
            // 出力順を設定
            this.ChangePageDiv_tComboEditor.Value = invntryPrtOdrIniDiv;

            // 2008.10.07 30413 犬飼 処理別の画面初期化処理を変更 <<<<<<END            
        }
        #endregion

        #region 抽出条件格納処理
        /// <summary>
        /// 抽出条件UIクラスデータ格納処理(画面情報⇒抽出条件UIクラス)
        /// </summary>
        /// <param name="extraInfo">抽出条件UIクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件詳細情報を画面から取得します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2011/01/11 liyp</br>
        /// <br>            出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
        /// </remarks>
        private int SetExtrInfoFromScreen(ref InventSearchCndtnUI extraInfo)
        {
            const string ctPROCNM = "SetExtrInfoFromScreen";
            int status = 0;

            if (extraInfo == null)
            {
                extraInfo = new InventSearchCndtnUI();
            }

            try
            {
                // 2008.10.07 30413 犬飼 画面情報と抽出条件設定を変更 >>>>>>START
                // 2007.09.05 削除 >>>>>>>>>>>>>>>>>>>>
                ////拠点オプション有無
                //extraInfo.IsOptSection = this._isOptSection;
                // 2007.09.05 削除 <<<<<<<<<<<<<<<<<<<<
                //企業コード
                extraInfo.EnterpriseCode = this._enterpriseCode;
                //拠点コード(自拠点)
                extraInfo.SectionCode = this._sectionCode;
                ////画面情報→条件クラス                                 
                // 2007.09.05 削除 >>>>>>>>>>>>>>>>>>>>
                ////集計単位区分             
                //extraInfo.GrossPrintDiv = this.GrossPrintDiv_ultraOptionSet.CheckedIndex;                        
                // 2007.09.05 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////在庫抽出区分
                ////自社在庫
                //if(this.CmpStockDiv_CheckEditor.Checked)
                //{
                //    //抽出する
                //    extraInfo.CompanyStockExtraDiv = 0;
                //}
                //else
                //{
                //    //抽出しない
                //    extraInfo.CompanyStockExtraDiv = 1;
                //}
                ////受託在庫
                //if(this.TrsStockDiv_CheckEditor.Checked)
                //{
                //    //抽出する
                //    extraInfo.TrustStockExtraDiv = 0;
                //}
                //else
                //{
                //    //抽出しない
                //    extraInfo.TrustStockExtraDiv = 1;
                //}
                ////委託在庫(自社)
                //if(this.EntrustCmpStockDiv_CheckEditor.Checked)
                //{
                //    //抽出する
                //    extraInfo.EntrustCmpStockExtraDiv = 0;
                //}
                //else
                //{
                //    //抽出しない
                //    extraInfo.EntrustCmpStockExtraDiv = 1;
                //}
                ////委託在庫(自社)
                //if(this.EntrustTrsStockDiv_CheckEditor.Checked)
                //{
                //    //抽出する
                //    extraInfo.EntrustTrtStockExtraDiv = 0;
                //}
                //else
                //{
                //    //抽出しない
                //    extraInfo.EntrustTrtStockExtraDiv = 1;
                //}
                // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<

                // 2008.10.31 30413 犬飼 0詰め対応 >>>>>>START
                //倉庫コード
                //extraInfo.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                //extraInfo.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;

                // 倉庫コード(開始)
                if (this.tEdit_WarehouseCode_St.Text.TrimEnd() == "")
                {
                    extraInfo.St_WarehouseCode = "";
                }
                else
                {
                    extraInfo.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text.TrimEnd().PadLeft(4, '0');
                }

                // 倉庫コード(終了)
                if (this.tEdit_WarehouseCode_Ed.Text.TrimEnd() == "")
                {
                    extraInfo.Ed_WarehouseCode = "";
                }
                else
                {
                    extraInfo.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text.TrimEnd().PadLeft(4, '0');
                }
                // 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
                //棚番
                //extraInfo.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText;
                //extraInfo.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText;

                // 棚番(開始)
                if (this.tEdit_WarehouseShelfNo_St.Text.TrimEnd() == "")
                {
                    extraInfo.St_WarehouseShelfNo = "";
                }
                else
                {
                    //extraInfo.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text.TrimEnd().PadLeft(8, '0');
                    extraInfo.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text.Trim();
                }

                // 棚番(終了)
                if (this.tEdit_WarehouseShelfNo_Ed.Text.TrimEnd() == "")
                {
                    extraInfo.Ed_WarehouseShelfNo = "";
                }
                else
                {
                    //extraInfo.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text.TrimEnd().PadLeft(8, '0');
                    extraInfo.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text.Trim();
                }
                // 2008.10.31 30413 犬飼 0詰め対応 <<<<<<END
                
                // 仕入先
                extraInfo.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                extraInfo.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();

                //ＢＬコード
                extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                
                // グループコード
                extraInfo.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                extraInfo.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();

                // 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<
                //メーカーコード
                extraInfo.St_MakerCode = this.tNedit_GoodsMakerCd_St.GetInt();
                extraInfo.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // 出力指定区分
                extraInfo.OutputAppointDiv = (int)this.tComboEditor_OutputAppointDiv.Value;
                
                // 在庫区分
                extraInfo.StockDiv = (int)this.tComboEditor_StockDiv.Value;

                // -----------ADD 2011/01/11----------------------------------->>>>>
                // 数量出力区分
                extraInfo.NumOutputDiv = (int)this.tComboEditor_NumOutputDiv.Value;

                // 棚番出力区分
                extraInfo.WarehouseShelfOutputDiv = (int)this.tComboEditor_WarehouseShelfOutputDiv.Value;

                // -----------ADD 2011/01/11-----------------------------------<<<<<

                // 棚卸未入力区分
                extraInfo.InventoryNonInputDiv = (int)this.tComboEditor_InventoryNonInputDiv.Value;

                // 小計区分
                extraInfo.SubtotalPrintDiv = (int)this.tComboEditor_SubtotalPrint.Value;

                // -------------ADD 2010/02/20--------------->>>>>
                // 計印字(棚卸調査表用)
                extraInfo.SubtotalPrintDivTemp = (int)this.tComboEditor_SubtotalPrintTemp.Value;
                // -------------ADD 2010/02/20---------------<<<<<

                //改ページ指定区分
                extraInfo.TurnOoverThePagesDiv = (int)this.tComboEditor_NewPageDiv.Value;
                
                // 貸出抽出区分
                extraInfo.LendExtraDiv = (int)this.tComboEditor_LendExtraDiv.Value;

                // 来勘計上抽出区分
                extraInfo.DelayPaymentDiv = (int)this.tComboEditor_DelayPaymentDiv.Value;

                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_MakerCode = this.EndMakerCode_tNedit.GetInt();
                //if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
                //{
                //    extraInfo.Ed_MakerCode = 999999;
                //}
                //else
                //{
                //    extraInfo.Ed_MakerCode = this.tNedit_GoodsMakerCd_Ed.GetInt();
                //}
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                ////商品コード
                //extraInfo.St_GoodsNo = this.StartGoodsCode_tEdit.DataText;
                //extraInfo.Ed_GoodsNo = this.EndGoodsCode_tEdit.DataText;
                       
                ////商品区分グループコード
                //extraInfo.St_LargeGoodsGanreCode = this.StartLargeGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_LargeGoodsGanreCode = this.EndLargeGoodsGanreCode_tEdit.DataText;
                ////商品区分コード
                //extraInfo.St_MediumGoodsGanreCode = this.StartMediumGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_MediumGoodsGanreCode = this.EndMediumGoodsGanreCode_tEdit.DataText;
                ////商品区分詳細コード
                //extraInfo.St_DetailGoodsGanreCode = this.StartDetailGoodsGanreCode_tEdit.DataText;
                //extraInfo.Ed_DetailGoodsGanreCode = this.EndDetailGoodsGanreCode_tEdit.DataText;
                ////自社分類コード
                //extraInfo.St_EnterpriseGanreCode = this.StartEnterpriseGanreCode_tNedit.GetInt();
                //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_EnterpriseGanreCode = this.EndCmpClassificationCode_tNedit.GetInt();
                //if (this.EndEnterpriseGanreCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = 9999;
                //}
                //else
                //{
                //    extraInfo.Ed_EnterpriseGanreCode = this.EndEnterpriseGanreCode_tNedit.GetInt();
                //}
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                ////ＢＬコード
                //extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                //extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                //extraInfo.Ed_BLGoodsCode = this.EndBLGoodsCode_tNedit.GetInt();
                //if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                //{
                //    extraInfo.Ed_BLGoodsCode = 99999999;
                //}
                //else
                //{
                //    extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                //}
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<

                //ソート区分
                extraInfo.SortDiv = (int)this.ChangePageDiv_tComboEditor.Value;
               
                ////得意先コード(仕入先)
                //extraInfo.St_CustomerCode = this.StartCustomerCode_tNedit.GetInt();
                //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_CustomerCode = this.EndCustomerCode_tNedit.GetInt();
                //if (this.EndCustomerCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_CustomerCode = 999999999;
                //}
                //else
                //{
                //    extraInfo.Ed_CustomerCode = this.EndCustomerCode_tNedit.GetInt();
                //}
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                ////出荷先得意先コード(委託先)
                //extraInfo.St_ShipCustomerCode = this.StartShipCustomerCode_tNedit.GetInt();
                //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                ////extraInfo.Ed_ShipCustomerCode = this.EndShipCustomerCode_tNedit.GetInt();
                //if (this.EndShipCustomerCode_tNedit.GetInt() == 0)
                //{
                //    extraInfo.Ed_ShipCustomerCode = 999999999;
                //}
                //else
                //{
                //    extraInfo.Ed_ShipCustomerCode = this.EndShipCustomerCode_tNedit.GetInt();
                //}
                //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                ////得意先印字区分(0:仕入先,1:委託先)
                //extraInfo.CustomerPrintDiv = this.CustomerPrintDiv_ultraOptionSet.CheckedIndex;

                //// 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
                ////棚卸未入力区分
                //extraInfo.InventoryInputDiv = this.InventoryInputDiv_ultraOptionSet.CheckedIndex;
                ////出力指定区分
                //extraInfo.OutputAppointDiv = this.OutputAppointDiv_ultraOptionSet.CheckedIndex;
                ////改ページ指定区分
                //extraInfo.TurnOoverThePagesDiv = this.TurnOoverThePagesDiv_ultraOptionSet.CheckedIndex;
                //棚番ブレイク区分
                extraInfo.ShelfNoBreakDiv = this.ShelfNoBreakDiv_tComboEditor.SelectedIndex;
                // 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<
                // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
                //罫線印字区分
                extraInfo.LineMaSqOfChDiv = (int)this.tComboEditor_LineMaSqOfChDiv.Value;
                // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

                //TODO:今のところ未使用
                //通番
                extraInfo.St_InventorySeqNo = 0;
                extraInfo.Ed_InventorySeqNo = 999999;
    
                //起動している帳票によって変化する条件
                switch(this._selPrintMode)
                {
                    case 0:
                    {
                        #region 棚卸調査表の場合
                       
                        //棚卸準備処理日
                        extraInfo.St_InventoryPreprDayDateTime = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryPreprDayDateTime = this.EndDate_tDateEdit.GetDateTime();
                        // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<
                        extraInfo.St_InventoryPreprDay = this.StartDate_tDateEdit.GetLongDate();
                        // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryPreprDay = this.EndDate_tDateEdit.GetLongDate();
                        // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<
                        //棚卸実施日にはMinValuをセット
                        extraInfo.St_InventoryDayDateTime = DateTime.MinValue;
                        extraInfo.Ed_InventoryDayDateTime = DateTime.MinValue;

                        // 2008.12.10 30413 犬飼 棚卸日の設定 >>>>>>START
                        // 棚卸日
                        extraInfo.InventoryDate = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.12.10 30413 犬飼 棚卸日の設定 <<<<<<END
                        
                        //差異分抽出区分(全て)
                        extraInfo.DifCntExtraDiv = 0;

                        ////在庫数０印字
                        //switch (this.ZeroExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //抽出する
                        //        extraInfo.StockCntZeroExtraDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //抽出しない
                        //        extraInfo.StockCntZeroExtraDiv = 1;
                        //        break;
                        //    }
                        //}

                        //////帳簿数印字(項目)
                        //switch (this.StockCntPrintDiv_UOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //印字する
                        //        extraInfo.StockCntPrintDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //印字しない
                        //        extraInfo.StockCntPrintDiv = 1;
                        //        break;
                        //    }
                        //}

                        ////棚卸数０印字(抽出する)
                        extraInfo.IvtStkCntZeroExtraDiv = 0;
                        //帳票種類
                        // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.SelctedPaperKindDiv = 0;
                        extraInfo.SelectedPaperKind = 0;    // 0:棚卸調査表
                        // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //抽出対象日付区分 0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日
                        extraInfo.TargetDateExtraDiv = 0;

                        break;
                         
                        #endregion
                    }
                    case 1:
                    {
                        #region 棚卸差異表の場合
                       
                        //棚卸準備処理日にはMinValuをセット
                        extraInfo.St_InventoryPreprDayDateTime = DateTime.MinValue;
                        extraInfo.Ed_InventoryPreprDayDateTime = DateTime.MinValue;
                        //棚卸実施日
                        extraInfo.St_InventoryDayDateTime = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDayDateTime = this.EndDate_tDateEdit.GetDateTime();
                        // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<
                        extraInfo.St_InventoryDay = this.StartDate_tDateEdit.GetLongDate();
                        // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDay = this.EndDate_tDateEdit.GetLongDate();
                        // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 犬飼 棚卸日の設定 >>>>>>START
                        // 棚卸日
                        extraInfo.InventoryDate = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.12.10 30413 犬飼 棚卸日の設定 <<<<<<END

                        ////差異分抽出区分
                        //switch (this.DifCntExtraDiv_OptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //全て
                        //        extraInfo.DifCntExtraDiv = 0;
                        //        break;
                        //    }
                        //    // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //    //case 1:
                        //    //{
                        //    //    //差異分のみ
                        //    //    extraInfo.DifCntExtraDiv = 1;
                        //    //    break;
                        //    //}
                        //    case 1:
                        //    {
                        //        //数未入力分のみ
                        //        extraInfo.DifCntExtraDiv = 1;
                        //        break;
                        //    }
                        //    case 2:
                        //    {
                        //        //数入力分のみ
                        //        extraInfo.DifCntExtraDiv = 2;
                        //        break;
                        //    }
                        //    case 3:
                        //    {
                        //        //差異分のみ
                        //        extraInfo.DifCntExtraDiv = 3;
                        //        break;
                        //    }
                        //    // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //}

                        ////在庫数０印字
                        //switch (this.ZeroExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //抽出する
                        //        extraInfo.StockCntZeroExtraDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //抽出しない
                        //        extraInfo.StockCntZeroExtraDiv = 1;
                        //        break;
                        //    }
                        //}
                                                
                        //棚卸数０印字(抽出する)
                        extraInfo.IvtStkCntZeroExtraDiv = 0;
                        //帳票種類
                        // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.SelctedPaperKindDiv = 1;
                        extraInfo.SelectedPaperKind = 1;        // 1:棚卸差異表
                        // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 犬飼 棚卸差異表は1:棚卸実施日とする >>>>>>START
                        //// 2008.12.05 30413 犬飼 棚卸差異表も0:棚卸準備処理日とする >>>>>>START
                        ////抽出対象日付区分 0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日
                        ////extraInfo.TargetDateExtraDiv = 1;

                        ////// 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
                        ////extraInfo.TargetDateExtraDiv = 1;
                        ////// 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<

                        //extraInfo.TargetDateExtraDiv = 0;
                        //// 2008.12.05 30413 犬飼 棚卸差異表も0:棚卸準備処理日とする <<<<<<END
                        
                        extraInfo.TargetDateExtraDiv = 1;
                        // 2008.12.10 30413 犬飼 棚卸差異表は1:棚卸実施日とする <<<<<<END
                        
                        break;
                        #endregion
                    }
                    case 2:
                    {
                        #region 棚卸表の場合 
                     
                        //棚卸準備処理日にはMinValuをセット
                        extraInfo.St_InventoryPreprDayDateTime = DateTime.MinValue;
                        extraInfo.Ed_InventoryPreprDayDateTime = DateTime.MinValue;
                        //棚卸実施日
                        extraInfo.St_InventoryDayDateTime = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDayDateTime = this.EndDate_tDateEdit.GetDateTime();
                        // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<
                        extraInfo.St_InventoryDay = this.StartDate_tDateEdit.GetLongDate();
                        // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.Ed_InventoryDay = this.EndDate_tDateEdit.GetLongDate();
                        // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 犬飼 棚卸日の設定 >>>>>>START
                        // 棚卸日
                        extraInfo.InventoryDate = this.StartDate_tDateEdit.GetDateTime();
                        // 2008.12.10 30413 犬飼 棚卸日の設定 <<<<<<END

                        //差異分抽出区分(全て)
                        extraInfo.DifCntExtraDiv = 0;

                        //在庫数０印字
                        extraInfo.StockCntZeroExtraDiv = 0;
                                             
                        ////棚卸数０印字
                        //switch (this.ZeroExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    case 0:
                        //    {
                        //        //抽出する
                        //        extraInfo.IvtStkCntZeroExtraDiv = 0;
                        //        break;
                        //    }
                        //    case 1:
                        //    {
                        //        //抽出しない
                        //        extraInfo.IvtStkCntZeroExtraDiv = 1;
                        //        break;
                        //    }
                        //}

                        //帳票種類
                        // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.SelctedPaperKindDiv = 2;
                        extraInfo.SelectedPaperKind = 2;        // 2:棚卸表
                        // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<

                        // 2008.12.10 30413 犬飼 棚卸表は1:棚卸実施日とする >>>>>>START
                        //// 2008.12.05 30413 犬飼 棚卸表も0:棚卸準備処理日とする >>>>>>START
                        ////TODO:棚卸更新の機能ができ、棚卸データマスタに棚卸更新日が落ちるようになったら
                        ////2:棚卸更新日を条件としてセットする。それまでは1をセット
                        ////UI側でコンボボックスで選択できるようになるかもしれないのでその時は別途対応が必要
                        ////抽出対象日付区分 0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日
                        ////extraInfo.TargetDateExtraDiv = 1;
                        ////extraInfo.TargetDateExtraDiv = 2;

                        //extraInfo.TargetDateExtraDiv = 0;
                        //// 2008.12.05 30413 犬飼 棚卸表も0:棚卸準備処理日とする >>>>>>START

                        extraInfo.TargetDateExtraDiv = 1;
                        // 2008.12.10 30413 犬飼 棚卸表は1:棚卸実施日とする <<<<<<END
                        
                        break;
                        #endregion                
                    }                 
                }
                // 2008.10.07 30413 犬飼 画面情報と抽出条件設定を変更 <<<<<<END
            }
            catch (Exception ex)
            {
                status = -1;
                MsgDispProc("抽出条件の取得に失敗しました。", status, ctPROCNM, ex);
            }

            return status;
        }
    
        #endregion

        #region エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                CT_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                CT_PGNM,							// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.03.24</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                CT_CLASSID,							// アセンブリＩＤまたはクラスＩＤ
                CT_PGNM,							// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion       

        #region 画面入力チェック
        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー対象コントロール</param>
        /// <returns>チェック結果(true/false)</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行い、エラー時はメッセージと対象のコントロールを返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool result = false;

            // 2008.10.07 30413 犬飼 画面入力チェックを変更 >>>>>>START
            //出力帳票年月のチェック1
            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            //result = DateCheck(this.StartDate_tDateEdit, this.EndDate_tDateEdit, ref errMessage, ref errComponent);
            result = DateCheck(this.StartDate_tDateEdit, ref errMessage, ref errComponent);
            // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            if (!result)
            {
                return result;
            }

            //倉庫
            if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseCode_St.DataText.Trim().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.Trim()) > 0)
                {         
                    //errMessage = "倉庫コードの範囲指定に誤りがあります。";
                    errMessage = "倉庫の範囲指定に誤りがあります。";
                    errComponent = this.tEdit_WarehouseCode_St;
                    result = false;
                    return result;
                }
            }

            // 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
            //棚番
            if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != ""))
            {
                if (this.tEdit_WarehouseShelfNo_St.DataText.Trim().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.Trim()) > 0)
                {
                    //errMessage = this.WarehouseShelfNo_Title.Text.Trim() + "の範囲指定に誤りがあります。";
                    errMessage = "棚番の範囲指定に誤りがあります。";
                    errComponent = this.tEdit_WarehouseShelfNo_St;
                    result = false;
                    return result;
                }
            }
            // 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<

            //仕入先
            if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") && (this.tNedit_SupplierCd_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
                {
                    errMessage = "仕入先の範囲指定に誤りがあります。";
                    errComponent = this.tNedit_SupplierCd_St;
                    result = false;
                    return result;
                }
            }

            //ＢＬコード
            if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") && (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
                {
                    errMessage = "ＢＬコードの範囲指定に誤りがあります。";
                    errComponent = this.tNedit_BLGoodsCode_St;
                    result = false;
                    return result;
                }
            }

            // グループコード
            if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") && (this.tNedit_BLGloupCode_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_BLGloupCode_St.DataText.Trim().CompareTo(this.tNedit_BLGloupCode_Ed.DataText.Trim()) > 0)
                {
                    errMessage = "グループコードの範囲指定に誤りがあります。";
                    errComponent = this.tNedit_BLGloupCode_St;
                    result = false;
                    return result;
                }
            }

            //メーカー
            if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") && (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != ""))
            {
                if (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
                {         
                    errMessage = "メーカーの範囲指定に誤りがあります。";
                    errComponent = this.tNedit_GoodsMakerCd_St;
                    result = false;
                    return result;
                }
            }

            ////仕入先コード
            //if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") && (this.tNedit_SupplierCd_Ed.DataText.Trim() != ""))
            //{
            //    if (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            //    {         
            //        errMessage = "仕入先コードの範囲指定に誤りがあります。";
            //        errComponent = this.tNedit_SupplierCd_St;
            //        result = false;
            //        return result;
            //    }
            //}
            ////委託先コード
            //if ((this.StartShipCustomerCode_tNedit.DataText.Trim() != "") && (this.EndShipCustomerCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartShipCustomerCode_tNedit.GetInt() > this.EndShipCustomerCode_tNedit.GetInt())
            //    {         
            //        errMessage = "委託先コードの範囲指定に誤りがあります。";
            //        errComponent = this.StartShipCustomerCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}
            ////商品区分グループコード
            //if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") && (this.tNedit_BLGloupCode_Ed.DataText.Trim() != ""))
            //{
            //    if (this.tNedit_BLGloupCode_St.DataText.Trim().CompareTo(this.tNedit_BLGloupCode_Ed.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "商品区分グループの範囲指定に誤りがあります。";
            //        errComponent = this.tNedit_BLGloupCode_St;
            //        result = false;
            //        return result;
            //    }
            //}

            
            ////商品区分コード
            //if ((this.StartMediumGoodsGanreCode_tEdit.DataText.Trim() != "") && (this.EndMediumGoodsGanreCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartMediumGoodsGanreCode_tEdit.DataText.Trim().CompareTo(this.EndMediumGoodsGanreCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "商品区分の範囲指定に誤りがあります。";
            //        errComponent = this.StartMediumGoodsGanreCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}

            // 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
            ////商品区分詳細コード
            //if ((this.StartDetailGoodsGanreCode_tEdit.DataText.Trim() != "") &&	(this.EndDetailGoodsGanreCode_tEdit.DataText.Trim() != "") &&
            //    (this.StartDetailGoodsGanreCode_tEdit.DataText.CompareTo(this.EndDetailGoodsGanreCode_tEdit.DataText) > 0))
            //{
            //    errMessage = this.DetailGoodsGanreCode_Title.Text + "の範囲指定に誤りがあります。";
            //    errComponent = this.StartDetailGoodsGanreCode_tEdit;
            //    result = false;
            //    return result;           
            //}
            //// 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<
                    
            ////商品コード
            //if ((this.StartGoodsCode_tEdit.DataText.Trim() != "") && (this.EndGoodsCode_tEdit.DataText.Trim() != ""))
            //{
            //    if (this.StartGoodsCode_tEdit.DataText.Trim().CompareTo(this.EndGoodsCode_tEdit.DataText.Trim()) > 0)
            //    {         
            //        errMessage = "商品コードの範囲指定に誤りがあります。";
            //        errComponent = this.StartGoodsCode_tEdit;
            //        result = false;
            //        return result;
            //    }
            //}

            //// 2007.09.05 追加 >>>>>>>>>>>>>>>>>>>>
            ////自社分類コード
            //if ((this.StartEnterpriseGanreCode_tNedit.DataText.Trim() != "") && (this.EndEnterpriseGanreCode_tNedit.DataText.Trim() != ""))
            //{
            //    if (this.StartEnterpriseGanreCode_tNedit.GetInt() > this.EndEnterpriseGanreCode_tNedit.GetInt())
            //    {
            //        errMessage = "自社分類コードの範囲指定に誤りがあります。";
            //        errComponent = this.StartEnterpriseGanreCode_tNedit;
            //        result = false;
            //        return result;
            //    }
            //}

            ////ＢＬコード
            //if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") && (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != ""))
            //{
            //    if (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            //    {
            //        errMessage = "ＢＬコードの範囲指定に誤りがあります。";
            //        errComponent = this.tNedit_BLGoodsCode_St;
            //        result = false;
            //        return result;
            //    }
            //}
            // 2007.09.05 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.05 削除 >>>>>>>>>>>>>>>>>>>>
            //在庫抽出区分
            //if (this.CmpStockDiv_CheckEditor.Checked == false && this.TrsStockDiv_CheckEditor.Checked == false &&
            //  this.EntrustCmpStockDiv_CheckEditor.Checked == false && this.EntrustTrsStockDiv_CheckEditor.Checked == false)
            //{
            //    //一つもチェックされていない
            //    errMessage = StockExtraDiv_Title.Text + "は最低一つは選択してください。";
            //    errComponent = this.CmpStockDiv_CheckEditor;
            //    result = false;
            //    return result;             
            //}
            // 2007.09.05 削除 <<<<<<<<<<<<<<<<<<<<

            // 2008.10.07 30413 犬飼 画面入力チェックを変更 <<<<<<END

            return result;
        }
        #endregion     

        #region 日付入力チェック
        /// <summary>
        /// 日付項目入力チェック関数
        /// </summary>
        /// <param name="startDateEdit">開始日付コンポーネント</param>
        /// <param name="endDateEdit">終了日付コンポーネント</param>
        /// <param name="msg">エラーメッセージ</param>   
        /// <param name="errComponent">入力エラーコントロール</param>
        /// <returns>true:正常 false:異常</returns>
        // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
        //private bool DateCheck(TDateEdit startDateEdit, TDateEdit endDateEdit, ref string msg, ref Control errComponent)
        private bool DateCheck(TDateEdit startDateEdit, ref string msg, ref Control errComponent)
        // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
        {
            bool status = true;

            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            //if (IsErrorTDateEdit(startDateEdit, true))
            if (IsErrorTDateEdit(startDateEdit, false))
            // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            {
                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                //msg += "開始日の日付が正しくありません。";
                msg += "棚卸日の日付が正しくありません。";
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                errComponent = startDateEdit;
                status = false;
                return status;
            }

            // 2008.02.13 削除 >>>>>>>>>>>>>>>>>>>>
            //if (IsErrorTDateEdit(endDateEdit, true))
            //{
            //    msg += "終了日の日付が正しくありません。";
            //    errComponent = endDateEdit;
            //    status = false;
            //    return status;
            //}

            //if ((startDateEdit.GetDateTime() != DateTime.MinValue) && (endDateEdit.GetDateTime() != DateTime.MinValue))
            //{
            //    if (startDateEdit.GetLongDate() > endDateEdit.GetLongDate())
            //    {
            //        msg += "開始日が終了日を超えています。";
            //        errComponent = startDateEdit;
            //        status = false;
            //        return status;
            //    }
            //}
            // 2008.02.13 削除 <<<<<<<<<<<<<<<<<<<<
            return status;
        }
        
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="canEmpty">未入力フラグ(true:未入力可,false:未入力不可)</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool canEmpty)
        {
            if (tDateEdit.CheckInputData() != null) return true;

            // 日付を数値型で取得
            int date = tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 未入力フラグチェック
            if (canEmpty)
            {
                // 未入力可で未入力の場合は正常
                if (date == 0) return false;
            }

            // 日付未入力チェック
            if (date == 0) return true;

            // システムサポートチェック
            if ((yy > 0) && (yy < 1900)) return true;

            // 年・月・日別入力チェック
            switch (tDateEdit.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    {
                        if (yy == 0 || mm == 0 || dd == 0) return true;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    {
                        if (yy == 0 || mm == 0) return true;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date / 100 * 100 + 1);
                        if (TDateTime.IsAvailableDate(dt) == false) return true;
                        break;
                    }
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    {
                        if (yy == 0) return false;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date / 10000 * 10000 + 101);
                        break;
                    }
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    {
                        if (mm == 0 || dd == 0) return true;
                        break;
                    }
                // 月        表示時
                case emDateFormat.df2M:
                    {
                        if (mm == 0) return true;
                        break;
                    }
                // 日        表示時
                case emDateFormat.df2D:
                    {
                        if (dd == 0) return true;
                        break;
                    }
            }

            return false;
        }

        #endregion

        // 2008.10.08 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 得意先(仕入先)選択時発生イベント
        ///// <summary>
        ///// 得意先(仕入先)選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        ///// <<remarks>
        ///// <br>Note        :得意先ガイドで得意先を選択した時に発生します</br>
        ///// <br>Programmer  :23010 中村　仁</br>
        ///// <br>Date        :2007.04.17</br>
        ///// </remarks>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustSuppli custSuppli;

        //    //選択された得意先の状態をチェック
        //    int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
			
        //    if(customerSearchRet == null) return;

        //    //得意先(仕入先)コードをセット
        //    switch(this._custmerGuideIndex)
        //    {
        //        //開始仕入先
        //        case 1:
        //        {
        //            this.tNedit_SupplierCd_St.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //        //終了仕入先
        //        case 2:
        //        {
        //            this.tNedit_SupplierCd_Ed.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //    }
	          
        //}    
        #endregion
        // 2008.10.08 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 出荷先得意先(委託先)選択時発生イベント
        ///// <summary>
        ///// 出荷先得意先(委託先)選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        ///// <<remarks>
        ///// <br>Note        :得意先ガイドで出荷先得意先を選択した時に発生します</br>
        ///// <br>Programmer  :23010 中村　仁</br>
        ///// <br>Date        :2007.04.17</br>
        ///// </remarks>
        //private void CustomerSearchForm_ShipCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
			
        //    //選択された得意先の状態をチェック
        //    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
			
        //    if(customerSearchRet == null) return;
					
        //    //出荷先得意先(委託先)コードをセット
        //    switch(this._shipCustmerGuideIndex)
        //    {
        //        //開始委託先
        //        case 1:
        //        {
        //            this.StartShipCustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //        //終了委託先
        //        case 2:
        //        {
        //            this.EndShipCustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
        //            break;
        //        }
        //    }
	          
        //}    
        #endregion
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
        #endregion

        #region ControlEvent

        #region Form Load イベント
        /// <summary>
        /// Form.Load イベント (MAZAI02110UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが初めて表示される直前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note : 2012/12/25 董桂鈺</br>
        ///	<br>			  Redmine#33271 帳票の罫線印字（する・しない）を前回指定したものを記憶させることの設定を追加する</br> 
        /// </remarks>
        private void MAZAI02110UA_Load(object sender, EventArgs e)
        {
            //アイコン(☆) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
            // 2008.10.07 30413 犬飼 ガイドボタンのイメージ設定を変更 >>>>>>START
            //倉庫ガイド
            this.St_WarehouseGuide_Button.ImageList = imageList16;
            this.Ed_WarehouseGuide_Button.ImageList = imageList16;
            this.St_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;           
            this.Ed_WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //メーカーガイド
            this.St_MakerGuide_Button.ImageList = imageList16;
            this.Ed_MakerGuide_Button.ImageList = imageList16;
            this.St_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_MakerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //得意先(仕入先)ガイド
            this.St_SupplierGuide_Button.ImageList = imageList16;
            this.Ed_SupplierGuide_Button.ImageList = imageList16;
            this.St_SupplierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_SupplierGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////出荷先得意先(委託先)ガイド
            //this.St_ShipCustomerGuide_Button.ImageList = imageList16;
            //this.Ed_ShipCustomerGuide_Button.ImageList = imageList16;
            //this.St_ShipCustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_ShipCustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////商品ガイド
            //this.St_GoodsGuide_Button.ImageList = imageList16;
            //this.Ed_GoodsGuide_Button.ImageList = imageList16;
            //this.St_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //商品区分グループガイド
            this.St_BLGloupGuide_Button.ImageList = imageList16;
            this.Ed_BLGloupGuide_Button.ImageList = imageList16;
            this.St_BLGloupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_BLGloupGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////商品区分ガイド
            //this.St_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_MidiumGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_MidiumGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////商品区分詳細ガイド
            //this.St_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.Ed_DetailGoodsGanreGuide_Button.ImageList = imageList16;
            //this.St_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_DetailGoodsGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            ////自社分類ガイド
            //this.St_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.Ed_EnterpriseGanreGuide_Button.ImageList = imageList16;
            //this.St_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //this.Ed_EnterpriseGanreGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //ＢＬコードガイド
            this.St_BLGoodsGuide_Button.ImageList = imageList16;
            this.Ed_BLGoodsGuide_Button.ImageList = imageList16;
            this.St_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            this.Ed_BLGoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2008.10.07 30413 犬飼 ガイドボタンのイメージ設定を変更 <<<<<<END
            
            //画面初期設定
            this.ScreenInitialSetting();

            // ---- ADD 董桂鈺　2012/12/25 for Redmine#33271 ------------>>>>>>>>>>>
            uiMemInput1.ReadMemInput();
            switch (this._selPrintMode)
            {
                case 0:
                    {
                        this.tComboEditor_LineMaSqOfChDiv.Value = tComboEditor_LineMaSqOfChDiv0.Value;
                        break;
                    }
                case 1:
                    {
                        this.tComboEditor_LineMaSqOfChDiv.Value = tComboEditor_LineMaSqOfChDiv1.Value;
                        break;
                    }
                case 2:
                    {
                        this.tComboEditor_LineMaSqOfChDiv.Value = tComboEditor_LineMaSqOfChDiv2.Value;
                        break;
                    }
            }
            
            // ---- ADD 董桂鈺　2012/12/25 for Redmine#33271 ------------<<<<<<<<<<<

            // 2008.10.08 30413 犬飼 未使用のため削除 >>>>>>START
            //TurnOoverThePagesDiv_ultraOptionSet_ValueChanged(sender, e);
            // 2008.10.08 30413 犬飼 未使用のため削除 <<<<<<END
            
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            if (this.ParentToolbarSettingEvent != null)
            {
                this.ParentToolbarSettingEvent(this);
            }
        }
        #endregion

        #region Form VisibleChanged イベント
        /// <summary>
        /// Form.VisibleChanged イベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変更されると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2006.07.31</br>
        /// </remarks>    
        private void Main_UltraExplorerBar_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                // 初期フォーカス設定
                this.StartDate_tDateEdit.Focus();
            }
        }
        #endregion

        #region UltraExplorerBar イベント
        /// <summary>
        /// UltraExplorerBar.GroupExpanding イベント (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroupが展開される前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortConditionGroup") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// UltraExplorerBar.GroupCollapsing イベント (Main_UltraExplorerBar)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroupが縮小される前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private void Main_UltraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "SortConditionGroup") ||
                (e.Group.Key == "CustomerConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        #endregion

        #region Control Leave イベント
       
        /// <summary>
        /// Control.Leave イベント (StartMakerCode_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void StartMakerCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // 空欄か0の時初期値をセット
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                //if (tNedit.Equals(this.StartMakerCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.StartLargeGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(0);                  
                //}
                //else if(tNedit.Equals(this.StartMediumGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.EndMakerCode_tNedit))
                //{
                //    tNedit.SetInt(999);
                //}
                //else if (tNedit.Equals(this.EndLargeGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(999);
                //}
                //else if (tNedit.Equals(this.EndMediumGoodsGanreCode_tEdit))
                //{
                //    tNedit.SetInt(999);
                //}
                //else if(tNedit.Equals(this.StartCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.EndCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(999999999);
                //}
                // else if(tNedit.Equals(this.StartShipCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.EndShipCustomerCode_tNedit))
                //{
                //    tNedit.SetInt(999999999);
                //}
                //else if(tNedit.Equals(this.StartCmpClassificationCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if(tNedit.Equals(this.EndCmpClassificationCode_tNedit))
                //{
                //    tNedit.SetInt(99);
                //}
                tNedit.Clear();
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            }

        }

        /// <summary>
        /// Control.Leave イベント (StartCarrierEpCode_tNedit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.07</br>
        /// </remarks>
        private void StartCarrierEpCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }
            // 空欄か0の時初期値をセット
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                //if (tNedit.Equals(this.StartBLGoodsCode_tNedit))
                //{
                //    tNedit.SetInt(0);
                //}
                //else if (tNedit.Equals(this.EndBLGoodsCode_tNedit))
                //{
                //    tNedit.SetInt(99999);
                //}
                tNedit.Clear();
                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            }
        }
  
        #endregion

        // 2008.10.08 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region Value Changed イベント
        ///// <summary>
        ///// ValueChanged イベント (TurnOoverThePagesDiv_ultraOptionSet)
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        ///// <br>Programmer : 980035 金沢 貞義</br>
        ///// <br>Date       : 2007.09.05</br>
        ///// </remarks>
        //private void TurnOoverThePagesDiv_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        //{
        //    // 2008.10.07 30413 犬飼 暫定的にコメント >>>>>>START
        //    //int checkIndex = this.TurnOoverThePagesDiv_ultraOptionSet.CheckedIndex;
        //    int checkIndex = 0;
        //    // 2008.10.07 30413 犬飼 暫定的にコメント <<<<<<END
        //    int selectIndex = this.ChangePageDiv_tComboEditor.SelectedIndex;

        //    if ((checkIndex == 1) && ((selectIndex == 0) || (selectIndex == 4)))
        //    {
        //        ShelfNoBreakDiv_tComboEditor.Enabled = true;
        //    }
        //    else
        //    {
        //        ShelfNoBreakDiv_tComboEditor.Enabled = false;
        //    }
        //}
        #endregion
        // 2008.10.08 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
        #region ガイド呼出し処理

        #region メーカーガイド
        /// <summary>
        /// メーカーガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            if(this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();               
            }
            //メーカーガイド起動
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            switch(status)
            {
                //取得
                case 0:
                {
                    if (makerUMnt != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if((Infragistics.Win.Misc.UltraButton)sender == this.St_MakerGuide_Button)
                        {
                            //開始
                            this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                        }
                        else
                        {
                            //終了
                            this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                        }

                        // 次のコントロールへフォーカスを移動
                        this.SelectNextControl((Control)sender, true, true, true, true);
                    }           
                    break;
                }
                //キャンセル
                case 1:
                {
                    
                    break;
                }
            }
        }

        #endregion

        // 2008.10.07 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 商品区分グループガイド
        ///// <summary>
        ///// 商品区分グループガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 商品区分グループガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.04.09</br>
        ///// </remarks>    
        //private void LargeGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    LGoodsGanre lGoodsGanre = null;
        //    if(this._lGoodsGanreAcs == null)
        //    {
        //        this._lGoodsGanreAcs = new LGoodsGanreAcs();               
        //    }
        //    //従業員ガイド起動(メカ、受付、販売を全て含む)←要変更
        //    int status = this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,out lGoodsGanre);

        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(lGoodsGanre != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGloupGuide_Button)
        //                {
        //                    //開始
        //                    this.tNedit_BLGloupCode_St.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.tNedit_BLGloupCode_Ed.DataText = lGoodsGanre.LargeGoodsGanreCode.TrimEnd();
        //                }           
                                  
        //            }
        //            break;
        //        }
        //        //キャンセル
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 <<<<<<END

        // 2008.10.07 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 商品区分ガイド
        ///// <summary>
        ///// 商品区分ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 商品区分ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.04.09</br>
        ///// </remarks>    
        //private void MidiumGoodsGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    MGoodsGanre mGoodsGanre = null;
        //    if(this._mGoodsGanreAcs == null)
        //    {
        //        this._mGoodsGanreAcs = new MGoodsGanreAcs();               
        //    }
        //    //商品区分ガイド起動(引数に商品グループコードが残っているので空文字をセット)
        //    //int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 0);
        //    int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, string.Empty, out mGoodsGanre, 1);

        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(mGoodsGanre != null)
        //            {
        //                //開始、終了どちらのボタンが押されたか？
        //                if((Infragistics.Win.Misc.UltraButton)sender == this.St_MidiumGoodsGanreGuide_Button)
        //                {
        //                    //開始
        //                    this.StartMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }
        //                else
        //                {
        //                    //終了
        //                    this.EndMediumGoodsGanreCode_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
        //                }           
                                  
        //            }
        //            break;
        //        }
        //        //キャンセル
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 <<<<<<END

        // 2008.10.07 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 商品区分詳細ガイド
        ///// <summary>
        ///// 商品区分詳細ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 商品区分詳細ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 980035 金沢　貞義</br>
        ///// <br>Date       : 2007.09.05</br>
        ///// </remarks>    
        //private void St_CellphoneModelGuide_Button_Click(object sender, EventArgs e)
        //{
        //    DGoodsGanre dGoodsGanre = null;
        //    if (this._dGoodsGanreAcs == null)
        //    {
        //        this._dGoodsGanreAcs = new DGoodsGanreAcs();
        //    }

        //    //商品区分詳細ガイド起動
        //    int status = this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre);

        //    switch (status)
        //    {
        //        //取得
        //        case 0:
        //            {
        //                if (dGoodsGanre != null)
        //                {
        //                    //開始、終了どちらのボタンが押されたか？
        //                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_DetailGoodsGanreGuide_Button)
        //                    {
        //                        //開始
        //                        this.StartDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }
        //                    else
        //                    {
        //                        //終了
        //                        this.EndDetailGoodsGanreCode_tEdit.DataText = dGoodsGanre.DetailGoodsGanreCode.TrimEnd();
        //                    }
        //                }
        //                break;
        //            }
        //        //キャンセル
        //        case 1:
        //            {

        //                break;
        //            }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 <<<<<<END

        // 2008.10.07 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 商品ガイド
        ///// <summary>
        ///// 商品ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 商品ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.03.13</br>
        ///// </remarks>    
        //private void GoodsGuide_Button_Click(object sender, EventArgs e)
        //{     
        //    GoodsUnitData goodsUnitData = null;
        //    MAKHN04110UA goodsGuide = new MAKHN04110UA();

        //    DialogResult ret = goodsGuide.ShowGuide(this,this._enterpriseCode,out goodsUnitData);

        //    if(ret == DialogResult.OK)
        //    {
        //        if(goodsUnitData != null)
        //        {
        //            //開始、終了どちらのボタンが押されたか？
        //            if((Infragistics.Win.Misc.UltraButton)sender == this.St_GoodsGuide_Button)
        //            {
        //                //開始
        //                // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
        //                //this.StartGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
        //                this.StartGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo.TrimEnd();
        //                // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
        //            }
        //            else
        //            {
        //                //終了
        //                // 2007.09.05 修正 >>>>>>>>>>>>>>>>>>>>
        //                //this.EndGoodsCode_tEdit.DataText = goodsUnitData.GoodsCode.TrimEnd();
        //                this.EndGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo.TrimEnd();
        //                // 2007.09.05 修正 <<<<<<<<<<<<<<<<<<<<
        //            }           
                              
        //        }
        //    }
        //    else
        //    {
        //        //キャンセルなのでなにもしない
        //    }

        //}
        #endregion
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
        #region 倉庫ガイド
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.03.13</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;
            WarehouseAcs _warehouseGuide = new WarehouseAcs();

            int status = _warehouseGuide.ExecuteGuid(out warehouseData,this._enterpriseCode,this._sectionCode);

            if(status == 0)
            {
                if(warehouseData != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if((Infragistics.Win.Misc.UltraButton)sender == this.St_WarehouseGuide_Button)
                    {
                        //開始
                        this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }
                    else
                    {
                        //終了
                        this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                    }

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);          
                }
            }
            else
            {
                //キャンセルなのでなにもしない
            }
        }

        #endregion

        // 2008.10.07 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 出荷先得意先(委託先)ガイド
        ///// <summary>
        ///// 出荷先得意先(委託先)ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       :得意先ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.04.13</br>
        ///// </remarks>    
        //private void St_ShipCustomerGuide_Button_Click(object sender, EventArgs e)
        //{
        //    Infragistics.Win.Misc.UltraButton uButton = sender as Infragistics.Win.Misc.UltraButton;

        //    if (uButton == null)
        //    {
        //        return;
        //    }

        //    //開始仕入先ボタン
        //    if(uButton.Equals(this.St_ShipCustomerGuide_Button))
        //    {
        //        this._shipCustmerGuideIndex = 1;
        //    }
        //    //終了仕入先ボタン
        //    else if(uButton.Equals(this.Ed_ShipCustomerGuide_Button))
        //    {
        //        this._shipCustmerGuideIndex = 2;
        //    }

        //    //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_ACCEPT_WHOLE_SALE, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
        //    customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_ShipCustomerSelect);
        //    customerSearchForm.ShowDialog(this);
        //}
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 <<<<<<END
        #endregion

        #region 得意先(仕入先)ガイド
        /// <summary>
        /// 得意先(仕入先)ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       :得意先ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>    
        private void St_SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            // 2008.10.08 30413 犬飼 仕入先ガイドに変更 >>>>>>START
            //Infragistics.Win.Misc.UltraButton uButton = sender as Infragistics.Win.Misc.UltraButton;

            //if (uButton == null)
            //{
            //    return;
            //}

            ////開始仕入先ボタン
            //if(uButton.Equals(this.St_SupplierGuide_Button))
            //{
            //    this._custmerGuideIndex = 1;
            //}
            ////終了仕入先ボタン
            //else if(uButton.Equals(this.Ed_SupplierGuide_Button))
            //{
            //    this._custmerGuideIndex = 2;
            //}

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            int status = -1;
            string supplierTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            
            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                if (supplierTag.CompareTo("1") == 0)
                {
                    this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                }
                else
                {
                    this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                }

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.08 30413 犬飼 仕入先ガイドに変更 <<<<<<END
        }

        #endregion

        // 2008.10.07 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 自社分類ガイド
        ///// <summary>
        ///// 自社分類ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 自社分類ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 980035 金沢　貞義</br>
        ///// <br>Date       : 2007.09.05</br>
        ///// </remarks>    
        //private void St_EnterpriseGanreGuide_Button_Click(object sender, EventArgs e)
        //{
        //    UserGdBd userGdBd = null;
        //    if (this._userGuideGuide == null)
        //    {
        //        this._userGuideGuide = new UserGuideGuide();
        //    }

        //    //自社分類ガイド起動
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(41, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        //取得
        //        if (userGdBd != null)
        //        {
        //            //開始、終了どちらのボタンが押されたか？
        //            if ((Infragistics.Win.Misc.UltraButton)sender == this.St_EnterpriseGanreGuide_Button)
        //            {
        //                //開始
        //                this.StartEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //            else
        //            {
        //                //終了
        //                this.EndEnterpriseGanreCode_tNedit.SetInt(userGdBd.GuideCode);
        //            }
        //        }
        //    }
        //}
        #endregion
        // 2008.10.07 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
        #region ＢＬコードガイド
        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ＢＬコードガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.05</br>
        /// </remarks>    
        private void St_BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status == 0)
            {
                if (blGoodsCdUMnt != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGoodsGuide_Button)
                    {
                        //開始
                        this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    }
                    else
                    {
                        //終了
                        this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    }

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                //キャンセルなのでなにもしない
            }
        }

        #endregion

        #region グループコードガイド
        /// <summary>
        /// グループコードガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : グループコードガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.26</br>
        /// </remarks>    
        private void St_BLGloupGuide_Button_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupU = new BLGroupU();
            if (this._blGoodsCdAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = _blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                if (blGroupU != null)
                {
                    //開始、終了どちらのボタンが押されたか？
                    if ((Infragistics.Win.Misc.UltraButton)sender == this.St_BLGloupGuide_Button)
                    {
                        //開始
                        this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                    }
                    else
                    {
                        //終了
                        this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                    }

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                //キャンセルなのでなにもしない
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        // 倉庫(開始)→倉庫(終了)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // 倉庫(終了)→棚番(開始)
                        e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→BLコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BLコード(開始)→BLコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BLコード(終了)→グループコード(開始)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // グループコード(開始)→グループコード(終了)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // グループコード(終了)→メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // メーカー(開始)→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        if (this.tComboEditor_LendExtraDiv.Visible)
                        {
                            // メーカー(終了)→貸出分
                            e.NextCtrl = this.tComboEditor_LendExtraDiv;
                        }
                        else
                        {
                            // メーカー(終了)→棚卸日
                            e.NextCtrl = this.StartDate_tDateEdit;
                        }
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if ((e.PrevCtrl == this.StartDate_tDateEdit) && (!this.tComboEditor_LendExtraDiv.Visible))
                    {
                        // 棚卸日→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LendExtraDiv)
                    {
                        // 貸出分→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // メーカー(終了)→メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // メーカー(開始)→グループコード(終了)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // グループコード(終了)→グループコード(開始)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // グループコード(開始)→BLコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BLコード(終了)→BLコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BLコード(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseShelfNo_St)
                    {
                        // 棚番(開始)→倉庫(終了)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // 倉庫(終了)→倉庫(開始)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                }
            }
        }

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion

        /// <summary>
        /// ValueChanged イベント (tComboEditor_NewPageDiv)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 改頁の値を変更すると発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.09</br>
        /// <br>Update Note: 2009/12/04 呉元嘯</br>
        /// <br>			 画面制御の変更対応</br>
        /// </remarks>
        private void tComboEditor_NewPageDiv_ValueChanged(object sender, EventArgs e)
        {
            //-------- UPD 2009/12/04 ------->>>>>
            //int selectIndex = this.tComboEditor_NewPageDiv.SelectedIndex;
            //if (selectIndex == 1)
            //{
            //    // 出力順の場合は有効
            //    ShelfNoBreakDiv_tComboEditor.Enabled = true;
            //}
            //else
            //{
            //    // 上記以外は無効
            //    ShelfNoBreakDiv_tComboEditor.Enabled = false;
            //}
            if (this._selPrintMode == 1 || this._selPrintMode == 2)
            {
                // 棚番順
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    // 小計印刷
                    switch (this.tComboEditor_SubtotalPrint.SelectedIndex)
                    {
                        // する
                        case 0:
                            ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            break;
                        // しない
                        case 1:
                            // 改頁:倉庫
                            if (this.tComboEditor_NewPageDiv.SelectedIndex == 0)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            // 改頁:出力順
                            else if (this.tComboEditor_NewPageDiv.SelectedIndex == 1)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            }
                            // 改頁:しない
                            else
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            break;
                    }

                }
                // 棚番順以外
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }
            //-------- UPD 2009/12/04 -------<<<<<
        }
        /// <summary>
        /// 出力順変更時棚番ブレイク区分の設定を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 出力順変更時棚番ブレイク区分の設定を行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.12.04</br>
        /// <br>Update Note: 2011/02/17 田建委</br>
        /// <br>			 棚卸調査表の棚番ブレイク区分の有効無効のチェックについて</br>
        /// </remarks>
        private void ChangePageDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._selPrintMode == 1 || this._selPrintMode == 2)
            {
                // 棚番順
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    // 小計印刷
                    switch (this.tComboEditor_SubtotalPrint.SelectedIndex)
                    {
                        // する
                        case 0:
                            ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            break;
                        // しない
                        case 1:
                            // 改頁:倉庫
                            if (this.tComboEditor_NewPageDiv.SelectedIndex == 0)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            // 改頁:出力順
                            else if (this.tComboEditor_NewPageDiv.SelectedIndex == 1)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            }
                            // 改頁:しない
                            else
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            break;
                    }

                }
                // 棚番順以外
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }

            // ---------- ADD 2011/02/17 ------------------------------>>>>>
            // 棚卸調査表
            if (this._selPrintMode == 0)
            {
                // 棚番順
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = true;
                }
                // 棚番順以外
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }
            // ---------- ADD 2011/02/17 ------------------------------<<<<<

        }
        /// <summary>
        /// 小計印刷変更時棚番ブレイク区分の設定を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 小計印刷変更時棚番ブレイク区分の設定を行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.12.04</br>
        /// </remarks>
        private void tComboEditor_SubtotalPrint_ValueChanged(object sender, EventArgs e)
        {
            if (this._selPrintMode == 1 || this._selPrintMode == 2)
            {
                // 棚番順
                if (this.ChangePageDiv_tComboEditor.SelectedIndex == 0)
                {
                    // 小計印刷
                    switch (this.tComboEditor_SubtotalPrint.SelectedIndex)
                    {
                        // する
                        case 0:
                            ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            break;
                        // しない
                        case 1:
                            // 改頁:倉庫
                            if (this.tComboEditor_NewPageDiv.SelectedIndex == 0)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            // 改頁:出力順
                            else if (this.tComboEditor_NewPageDiv.SelectedIndex == 1)
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = true;
                            }
                            // 改頁:しない
                            else
                            {
                                ShelfNoBreakDiv_tComboEditor.Enabled = false;
                            }
                            break;
                    }

                }
                // 棚番順以外
                else
                {
                    ShelfNoBreakDiv_tComboEditor.Enabled = false;
                }
            }
        }
        // -----------------------ADD 2011/01/11------------------------>>>>>
        /// <summary>
        /// 棚卸未入力区分変更時数量出力区分の設定を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 棚卸未入力区分変更時数量出力区分の設定を行う。</br>
        /// <br>Programmer	: liyp</br>
        /// <br>Date		: 2011/01/11</br>
        /// </remarks>
        private void tComboEditor_InventoryNonInputDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_InventoryNonInputDiv.Value == 0)
            {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "全て出力");
                tComboEditor_NumOutputDiv.Items.Add(1, "棚卸数１以上出力");
                tComboEditor_NumOutputDiv.Items.Add(2, "棚卸数０以下出力");
                tComboEditor_NumOutputDiv.Items.Add(3, "棚卸数０のみ出力");
            }
            else
            {
                tComboEditor_NumOutputDiv.Items.Clear();
                tComboEditor_NumOutputDiv.Items.Add(0, "全て出力");
                tComboEditor_NumOutputDiv.Items.Add(4, "未入力のみ出力");
                tComboEditor_NumOutputDiv.Items.Add(5, "未入力以外出力");
            }
            tComboEditor_NumOutputDiv.Value = 0;
        }
        // -----------------------ADD 2011/01/11------------------------<<<<<
        // --- ADD 董桂鈺 2012/12/25  for Redmine#33271--------->>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 帳票の罫線印字（する・しない）を前回指定したものの取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 帳票の罫線印字（する・しない）を前回指定したものの取得</br>
        /// <br>Programmer	: 董桂鈺</br>
        /// <br>Date		: 2012/12/25</br>
        /// </remarks>
        private void tComboEditor_LineMaSqOfChDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (this._selPrintMode)
            {
                case 0:
                    {
                        tComboEditor_LineMaSqOfChDiv0.Value = this.tComboEditor_LineMaSqOfChDiv.Value;
                        break;
                    }
                case 1:
                    {
                        tComboEditor_LineMaSqOfChDiv1.Value = this.tComboEditor_LineMaSqOfChDiv.Value;
                        break;
                    }
                case 2:
                    {
                        tComboEditor_LineMaSqOfChDiv2.Value = this.tComboEditor_LineMaSqOfChDiv.Value;
                        break;
                    }
            }

        }
        // --- ADD 董桂鈺 2012/12/25  for Redmine#33271---------<<<<<<<<<<<<<<<<<<<<<<<
        
    }
}
