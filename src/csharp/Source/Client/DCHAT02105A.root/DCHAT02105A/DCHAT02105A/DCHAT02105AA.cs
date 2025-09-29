//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 発注一覧表
// プログラム概要   : 発注一覧表と発注残一覧表の印刷、発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/09/01  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 渋谷　大輔
// 作 成 日  2008/12/10  修正内容 : 発注残一覧表追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/09  修正内容 : MANTIS【13332】対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/06/29  修正内容 : 不具合対応[13591]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2009/09/14  修正内容 : MANTIS[0014279] 仕入先コード取得方法変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2009/10/16  修正内容 : MANTIS[0014438] 商品マスタに存在しないデータは対象外になるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 夏野 駿希
// 作 成 日  2010/01/18  修正内容 : MANTIS[14893] 仕入先未登録の場合空白で印字される件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 作 成 日  2010/06/09  修正内容 : 抽出速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 作 成 日  2011/04/11  修正内容 : 障害改良対応(2011年04月)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhujc
// 作 成 日  2011/05/16  修正内容 : 障害改良対応(2011年04月)Redmine#21333
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhangy3
// 作 成 日  2012/10/16  修正内容 : 障害報告Redmine#32860
//----------------------------------------------------------------------------//
// 管理番号 10801804-00  作成担当 : donggy
// 作 成 日  2012/11/27  修正内容 : Redmine#33267 「発注一覧表」のDBサーバー負荷軽減
//----------------------------------------------------------------------------//
// 管理番号 11100068-00  作成担当 : 河原林 一生
// 作 成 日  2015/07/23  修正内容 : 東海自動車工業課題一覧No.2(全社指定-棚番順で出力したときに品番でソートされない)
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/09/14  修正内容 : ハンディターミナル二次開発の対応
//----------------------------------------------------------------------------//
// 管理番号  11570226-00 作成担当 : 譚洪
// 作 成 日  2019/11/05  修正内容 : ㈱ダイサブの対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

using System.Windows.Forms;   // ADD 2017/09/14 譚洪 ハンディターミナル二次開発
using Broadleaf.Library.Windows.Forms;   // ADD 2017/09/14 譚洪 ハンディターミナル二次開発

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 発注一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 発注一覧表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.09.19</br>
	/// <br>Updatenote   : </br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : PM.NS対応</br>
    /// <br>Programmer   : 犬飼</br>
    /// <br>Date	     : 2008.09.01</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : 発注残一覧表追加</br>
    /// <br>Programmer   : 渋谷　大輔</br>
    /// <br>Date	     : 2008.12.10</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : MANTIS【13332】対応</br>
    /// <br>Programmer   : 30413 犬飼</br>
    /// <br>Date	     : 2009/06/09</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : 不具合対応[13591]</br>
    /// <br>Programmer   : 照田 貴志</br>
    /// <br>Date	     : 2009/06/29</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : MANTIS[0014279] 仕入先コード取得方法変更</br>
    /// <br>Programmer   : 對馬 大輔</br>
    /// <br>Date	     : 2009/09/14</br>
    /// <br>             : </br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : MANTIS[0014279] 商品マスタに存在しないデータを対象外とするように修正</br>
    /// <br>Programmer   : 佐々木 健</br>
    /// <br>Date	     : 2009/10/16</br>
    /// <br>             : </br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : 倉庫股のリマークを空白にしていても送信処理の画面でリマーク１に日付が表示される不具合の修正</br>
    /// <br>Programmer   : liyp</br>
    /// <br>Date	     : 2011/04/11</br>
    /// <br>             : </br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : 東海自動車工業課題一覧No.2(全社指定-棚番順で出力したときに品番でソートされない)</br>
    /// <br>Programmer   : 河原林 一生</br>
    /// <br>Date	     : 2015/07/23</br>
    /// <br>             : </br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : 譚洪</br>
    /// <br>Date         : 2017/09/14</br>
    /// <br>管理番号     : 11370074-00</br>
    /// <br>             : ハンディターミナル二次開発の対応</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote   : ㈱ダイサブの対応</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date         : 2019/11/05</br>
    /// <br>管理番号     : 11570226-00</br>
    /// -----------------------------------------------------------------------------------
    /// </remarks>
	public class OrderListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 発注一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public OrderListAcs()
		{
            // 2008.09.02 30413 犬飼 アクセスクラスの変更 >>>>>>START
            //this._iOrderListWorkDB = (IOrderListWorkDB)MediationOrderListWorkDB.GetOrderListWorkDB();
            this._iOrderPointOrderWorkDB = (IOrderPointOrderWorkDB)MediationOrderPointOrderWorkDB.GetOrderPointOrderWorkDB();
            // 2008.09.02 30413 犬飼 アクセスクラスの変更 <<<<<<END

            // 2008.10.23 30413 犬飼 発注一覧表データ更新の追加 >>>>>>START
            this._iOrderListRenewWorkDB = (IOrderListRenewWorkDB)MediationOrderListRenewWorkDB.GetOrderListRenewWorkDB();
            // 2008.10.23 30413 犬飼 発注一覧表データ更新の追加 <<<<<<END

            // -- DEL 2010/06/09 ------------------------------------------------>>>
            // 2008.09.03 30413 犬飼 アクセスクラスの追加 >>>>>>START
            //this._companyInfAcs = new CompanyInfAcs();
            //this._uoeSupplierAcs = new UOESupplierAcs();
            //this._uoeSettingAcs = new UOESettingAcs();
            //this._stockMngTtlStAcs = new StockMngTtlStAcs();
            //this._supplierAcs = new SupplierAcs();
            //this._goodsAcs = new GoodsAcs();
            //this._employeeAcs = new EmployeeAcs();
            //this._secInfoAcs = new SecInfoAcs();
            //this._allDefSetAcs = new AllDefSetAcs();
            //this._taxRateSetAcs = new TaxRateSetAcs();
            //this._unitPriceCalculation = new UnitPriceCalculation();
            //this._posTerminalMgAcs = new PosTerminalMgAcs();
            //this._uoeGuideNameAcs = new UOEGuideNameAcs();
            // 2008.09.03 30413 犬飼 アクセスクラスの追加 <<<<<<END

            //// 2008.10.27 30413 犬飼 商品アクセスクラスの初期化 >>>>>>START
            //string message = "";
            //this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);
            //// 2008.10.27 30413 犬飼 商品アクセスクラスの初期化 <<<<<<END

            //// 2008.10.27 30413 犬飼 単価算出モジュールの初期データ設定 >>>>>>START
            //this.ReadInitData();
            //// 2008.10.27 30413 犬飼 単価算出モジュールの初期データ設定 <<<<<<END

            // ADD 2009/06/09 ------>>>
            //this._warehouseAcs = new WarehouseAcs();
            // ADD 2009/06/09 ------<<<
            // -- DEL 2010/06/09 ------------------------------------------------<<<
        }

		/// <summary>
		/// 発注一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        static OrderListAcs ()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary


			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList ) {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey(secInfoSet.SectionCode) ) {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
            CompanyNmDic = new Dictionary<int, CompanyNm>();  // 自社名Dictionary
            CompanyNm[] companyNmList = stc_SecInfoAcs.CompanyNmList;
            foreach (CompanyNm companyNm in companyNmList)
            {
                // 既存でなければ
                if (!CompanyNmDic.ContainsKey(companyNm.CompanyNameCd))
                {
                    // 追加
                    CompanyNmDic.Add(companyNm.CompanyNameCd, companyNm);
                }
            }
            // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
		#endregion ■ Static Member

		#region ■ Private Member
        // 2008.09.02 30413 犬飼 アクセスクラスの変更 >>>>>>START
        //IOrderListWorkDB _iOrderListWorkDB;
        IOrderPointOrderWorkDB _iOrderPointOrderWorkDB;
        // 2008.09.02 30413 犬飼 アクセスクラスの変更 <<<<<<END

        // 2008.10.23 30413 犬飼 発注一覧表データ更新の追加 >>>>>>START
        IOrderListRenewWorkDB _iOrderListRenewWorkDB;
        // 2008.10.23 30413 犬飼 発注一覧表データ更新の追加 <<<<<<END
        
        // 2008.09.03 30413 犬飼 アクセスクラスの追加 >>>>>>START
        CompanyInfAcs _companyInfAcs;           // 自社マスタ
        UOESupplierAcs _uoeSupplierAcs;         // UOE発注先マスタ
        UOESettingAcs _uoeSettingAcs;           // UOE自社マスタ
        StockMngTtlStAcs _stockMngTtlStAcs;     // 在庫管理全体設定マスタ
        SupplierAcs _supplierAcs;               // 仕入先マスタ
        GoodsAcs _goodsAcs;                     // 商品アクセスクラス
        EmployeeAcs _employeeAcs;               // 従業員アクセスクラス
        SecInfoAcs _secInfoAcs;                 // 拠点アクセスクラス
        AllDefSetAcs _allDefSetAcs;             // 全体初期値設定アクセスクラス
        TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        UnitPriceCalculation _unitPriceCalculation;     // 単価算出モジュール
        PosTerminalMgAcs _posTerminalMgAcs;     // 端末管理マスタ
        UOEGuideNameAcs _uoeGuideNameAcs;       // UOE各種名称マスタアクセスクラス
        // 2008.09.03 30413 犬飼 アクセスクラスの追加 <<<<<<END

        // 2008.10.27 30413 犬飼 ローカルキャッシュを追加 >>>>>>START
        // 仕入先マスタローカルキャッシュ
        private static Dictionary<string, Supplier> _supplierDic;
        // UOE発注先マスタローカルキャッシュ
        private static Dictionary<string, UOESupplier> _uoeSupplierDic;
        // UOE自社マスタローカルキャッシュ
        private static UOESetting _uoeSetting;
        // 商品連結データローカルキャッシュ
        private static Dictionary<string, GoodsUnitData> _goodsUnitDataDic;
        // 在庫管理全体設定マスタローカルキャッシュ
        private static Dictionary<string, StockMngTtlSt> _stockMngTtlStDic;
        // 2008.10.27 30413 犬飼 ローカルキャッシュを追加 <<<<<<END

        // 2008.10.27 30413 犬飼 ローカル変数を追加 >>>>>>START
        // 商品アクセスクラスの抽出条件
        private List<GoodsCndtn> _goodsCndtnList;
        // 税率
        private double _taxRate = 0.0;
        // 発注データ用仕入データディクショナリー
        private Dictionary<string, StockSlipWork> _stockSlipWorkDic;

        // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 >>>>>>START
        //// 発注データ用仕入データワークリスト
        //private List<StockSlipWork> _stockSlipWorkList;
        // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 <<<<<<END
        
        // UOE発注分以外の仕入明細データ
        private ArrayList _stockDetailList;
        // 2008.10.27 30413 犬飼 ローカル変数を追加 <<<<<<END

        // 2008.10.27 30413 犬飼 発注用更新データの追加 >>>>>>START
        // 2009.01.07 30413 犬飼 拠点・倉庫・仕入先単位で作成するため、発注データ用仕入データをディクショナリー化 >>>>>>START
        //// 発注データ用仕入データ
        //private static ArrayList _stockSlipList;
        // 発注データ用仕入データディクショナリー
        private static Dictionary<string, StockSlipWork> _stockSlipDic;
        // 2009.01.07 30413 犬飼 拠点・倉庫・仕入先単位で作成するため、発注データ用仕入データをディクショナリー化 <<<<<<END
        
        // UOE発注分以外の仕入明細データディクショナリー
        private static Dictionary<string, ArrayList> _stockDetailDic;
        // UOE発注分の仕入明細データ
        private static ArrayList _stockDetailUOEList;
        // UOE発注データ
        private static ArrayList _uoeOrderDtlList;
        // 2008.10.27 30413 犬飼 発注用更新データの追加 <<<<<<END
        
		private DataTable _stockNoShipmentListDt;			// 印刷DataTable
		private DataView _stockNoShipmentListDataView;	// 印刷DataView

        // ADD 2009/06/09 ------>>>
        WarehouseAcs _warehouseAcs = null;      // 倉庫マスタアクセスクラス
        // 倉庫マスタローカルキャッシュ
        private static Dictionary<string, Warehouse> _warehouseDic;
        // ADD 2009/06/09 ------<<<

        // -------ADD donggy 2012/11/27------->>>>>
        private Dictionary<string, Employee> employeeDic;
        private Dictionary<string, EmployeeDtl> employeeDtlDic;
        private PosTerminalMg posTerminalMg;
        private Dictionary<string, UOEGuideName> uoeGuideNameDic;
        private Dictionary<string, SecInfoSet> secInfoSetDic;
        private Dictionary<string, AllDefSet> allDefSetDic;
        // ------ADD donggy 2012/11/27 ------<<<<

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>仕入SEQ番号ディクショナリーのキー用</summary>
        private const string Hyphen = "-";
        /// <summary>仕入SEQ番号ディクショナリー</summary>
        private Dictionary<string, string> StockSlipDic = new Dictionary<string, string>();
        /// <summary> バーコード表示区分「False:表示しない True:表示する」</summary>
        private bool _barCodeShowDiv = false;
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
        private const string CtNoLogin = "未登録";
        private static Dictionary<int, CompanyNm> CompanyNmDic;   // 自社名Dictionary
        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockNoShipmentListDataView
		{
			get{ return this._stockNoShipmentListDataView; }
		}

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// バーコード表示区分「False:表示しない True:表示する」
        /// </summary>
        public bool BarCodeShowDiv
        {
            get { return _barCodeShowDiv; }
            set { _barCodeShowDiv = value; }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="orderListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
        /// <br>Note       : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
		/// </remarks>
        public int SearchMain ( OrderListCndtn orderListCndtn, out string errMsg )
		{
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            // バーコード印字する場合
            if (orderListCndtn.BarCodeShowDiv == 0)
            {
                this._barCodeShowDiv = true;
            }
            // バーコード印字しない場合
            else
            {
                this._barCodeShowDiv = false;
            }
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

            return this.SearchProc(orderListCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 在庫移動データ取得
		/// <summary>
		/// 在庫移動データ取得
		/// </summary>
		/// <param name="orderListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        private int SearchProc ( OrderListCndtn orderListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

            // -- ADD 2010/06/09 初期化の実行タイミングを変更--------------------->>>
            //出力ボタンを押してから印刷中ダイアログが表示されるのが遅かったため

            this._companyInfAcs = new CompanyInfAcs();
            this._uoeSupplierAcs = new UOESupplierAcs();
            this._uoeSettingAcs = new UOESettingAcs();
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._supplierAcs = new SupplierAcs();
            this._goodsAcs = new GoodsAcs();
            this._employeeAcs = new EmployeeAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._allDefSetAcs = new AllDefSetAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._posTerminalMgAcs = new PosTerminalMgAcs();
            this._uoeGuideNameAcs = new UOEGuideNameAcs();
            this._warehouseAcs = new WarehouseAcs();


            this.posTerminalMg = new PosTerminalMg();// ADD donggy  2012/11/27

            // ----- ADD donggy 2012/11/27--->>>>>
            this.EmployeeReadAll();
            this.PosTerminalMgSearch(out this.posTerminalMg);
            this.SectionReadAll();
            this.AllDefSetReadAll();
            // ----- ADD donggy 2012/11/27---<<<<<





            //商品アクセスクラスの初期化
            string message = "";
            this._goodsAcs.IsGetSupplier = true; //ADD donggy  2012/11/27
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);
            //単価算出モジュールの初期化
            this.ReadInitData();
            // -- ADD 2010/06/09 -------------------------------------------------<<<

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCHAT02104EA.CreateDataTable( ref this._stockNoShipmentListDt );

                // 2008.09.02 30413 犬飼 アクセスクラスの変更 >>>>>>START
                //OrderListCndtnWork orderListCndtnWork = new OrderListCndtnWork();
                OrderPointOrderCndtnWork orderPointOrderCndtnWork = new OrderPointOrderCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
                //status = this.DevListCndtn( orderListCndtn, out orderListCndtnWork, out errMsg );
                status = this.DevListCndtn(orderListCndtn, out orderPointOrderCndtnWork, out errMsg);
                // 2008.09.02 30413 犬飼 アクセスクラスの変更 <<<<<<END
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					return status;
				}

                // データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;
                // 2008.09.02 30413 犬飼 アクセスクラスの変更 >>>>>>START
                //status = this._iOrderListWorkDB.Search(out retStockMoveList, orderListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                status = this._iOrderPointOrderWorkDB.Search(out retStockMoveList, orderPointOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                // 2008.09.02 30413 犬飼 アクセスクラスの変更 <<<<<<END
                
                switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevListData( orderListCndtn, (ArrayList)retStockMoveList );

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        // 2008.11.10 30413 犬飼 印刷対象データが0件の場合はエラーとする >>>>>>START
                        if (this._stockNoShipmentListDataView == null || this._stockNoShipmentListDataView.Count == 0)  // ADD 2017/09/14 譚洪 ハンディターミナル二次開発
                        //if (this._stockNoShipmentListDataView.Count == 0)  // DEL 2017/09/14 譚洪 ハンディターミナル二次開発
                        {
                            // 印刷データが存在しない
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // 2008.11.10 30413 犬飼 印刷対象データが0件の場合はエラーとする <<<<<<END
                        
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "発注データの取得に失敗しました。";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票データ取得

		#region ◆ データ展開処理
        // 2008.09.02 30413 犬飼 処理内容の変更 >>>>>>START
        #region ◎ 抽出条件展開処理 <<<<<<変更前
        ///// <summary>
        ///// 抽出条件展開処理
        ///// </summary>
        ///// <param name="orderListCndtn">UI抽出条件クラス</param>
        ///// <param name="orderListCndtnWork">リモート抽出条件クラス</param>
        ///// <param name="errMsg">errMsg</param>
        ///// <returns>Status</returns>
        //private int DevListCndtn ( OrderListCndtn orderListCndtn, out OrderListCndtnWork orderListCndtnWork, out string errMsg )
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //    errMsg = string.Empty;
        //    orderListCndtnWork = new OrderListCndtnWork();
        //    try
        //    {
        //        orderListCndtnWork.EnterpriseCode = orderListCndtn.EnterpriseCode;  // 企業コード
        //        // 抽出条件パラメータセット
        //        if ( orderListCndtn.SectionCodes.Length != 0 )
        //        {
        //            if ( orderListCndtn.IsSelectAllSection )
        //            {
        //                // 全社の時
        //                orderListCndtnWork.SectionCodes = null;
        //            }
        //            else
        //            {
        //                orderListCndtnWork.SectionCodes = orderListCndtn.SectionCodes;
        //            }
        //        }
        //        else
        //        {
        //            orderListCndtnWork.SectionCodes = null;
        //        }

        //        orderListCndtnWork.EnterpriseCode = orderListCndtn.EnterpriseCode;
        //        orderListCndtnWork.SectionCodes = orderListCndtn.SectionCodes;
        //        orderListCndtnWork.St_OrderDataCreateDate = orderListCndtn.St_OrderDataCreateDate;
        //        orderListCndtnWork.Ed_OrderDataCreateDate = orderListCndtn.Ed_OrderDataCreateDate;
        //        orderListCndtnWork.St_OrderFormPrintDate = orderListCndtn.St_OrderFormPrintDate;
        //        orderListCndtnWork.Ed_OrderFormPrintDate = orderListCndtn.Ed_OrderFormPrintDate;
        //        orderListCndtnWork.St_ExpectDeliveryDate = orderListCndtn.St_ExpectDeliveryDate;
        //        orderListCndtnWork.Ed_ExpectDeliveryDate = orderListCndtn.Ed_ExpectDeliveryDate;
        //        orderListCndtnWork.OrderFormIssuedDivs = orderListCndtn.OrderFormIssuedDivs;
        //        orderListCndtnWork.StockOrderDivCds = orderListCndtn.StockOrderDivCds;
        //        orderListCndtnWork.ArrivalStateDivs = orderListCndtn.ArrivalStateDiv;
        //        orderListCndtnWork.St_StockAgentCode = orderListCndtn.St_StockAgentCode;
        //        orderListCndtnWork.Ed_StockAgentCode = orderListCndtn.Ed_StockAgentCode;
        //        orderListCndtnWork.St_StockInputCode = orderListCndtn.St_StockInputCode;
        //        orderListCndtnWork.Ed_StockInputCode = orderListCndtn.Ed_StockInputCode;
        //        orderListCndtnWork.St_SupplierCd = orderListCndtn.St_SupplierCd;
        //        orderListCndtnWork.Ed_SupplierCd = orderListCndtn.Ed_SupplierCd;
        //        orderListCndtnWork.St_WarehouseCode = orderListCndtn.St_WarehouseCode;
        //        orderListCndtnWork.Ed_WarehouseCode = orderListCndtn.Ed_WarehouseCode;
        //        orderListCndtnWork.St_GoodsMakerCd = orderListCndtn.St_GoodsMakerCd;
        //        orderListCndtnWork.Ed_GoodsMakerCd = orderListCndtn.Ed_GoodsMakerCd;
        //        orderListCndtnWork.St_GoodsNo = orderListCndtn.St_GoodsNo;
        //        orderListCndtnWork.Ed_GoodsNo = orderListCndtn.Ed_GoodsNo;
        //        orderListCndtnWork.St_LargeGoodsGanreCode = orderListCndtn.St_LargeGoodsGanreCode;
        //        orderListCndtnWork.Ed_LargeGoodsGanreCode = orderListCndtn.Ed_LargeGoodsGanreCode;
        //        orderListCndtnWork.St_MediumGoodsGanreCode = orderListCndtn.St_MediumGoodsGanreCode;
        //        orderListCndtnWork.Ed_MediumGoodsGanreCode = orderListCndtn.Ed_MediumGoodsGanreCode;
        //        orderListCndtnWork.St_DetailGoodsGanreCode = orderListCndtn.St_DetailGoodsGanreCode;
        //        orderListCndtnWork.Ed_DetailGoodsGanreCode = orderListCndtn.Ed_DetailGoodsGanreCode;
        //        orderListCndtnWork.St_EnterpriseGanreCode = orderListCndtn.St_EnterpriseGanreCode;
        //        orderListCndtnWork.Ed_EnterpriseGanreCode = orderListCndtn.Ed_EnterpriseGanreCode;
        //        orderListCndtnWork.DebitNoteDivs = orderListCndtn.DebitNoteDivs;
        //        orderListCndtnWork.SupplierSlipCds = orderListCndtn.SupplierSlipCds;
                
        //    }
        //    catch ( Exception ex )
        //    {
        //        errMsg = ex.Message;
        //        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    }
        //    return status;
        //}
		#endregion

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="orderListCndtn">UI抽出条件クラス</param>
        /// <param name="orderPointOrderCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevListCndtn(OrderListCndtn orderListCndtn, out OrderPointOrderCndtnWork orderPointOrderCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            orderPointOrderCndtnWork = new OrderPointOrderCndtnWork();
            try
            {
                orderPointOrderCndtnWork.EnterpriseCode = orderListCndtn.EnterpriseCode;  // 企業コード
                // 抽出条件パラメータセット
                if (orderListCndtn.SectionCodes.Length != 0)
                {
                    if (orderListCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        orderPointOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        orderPointOrderCndtnWork.SectionCodes = orderListCndtn.SectionCodes;
                    }
                }
                else
                {
                    orderPointOrderCndtnWork.SectionCodes = null;
                }

                orderPointOrderCndtnWork.EnterpriseCode = orderListCndtn.EnterpriseCode;            // 企業コード
                orderPointOrderCndtnWork.SectionCodes = orderListCndtn.SectionCodes;                // 拠点コード
                orderPointOrderCndtnWork.St_WarehouseCode = orderListCndtn.St_WarehouseCode;        // 開始倉庫コード
                orderPointOrderCndtnWork.Ed_WarehouseCode = orderListCndtn.Ed_WarehouseCode;        // 終了倉庫コード
                orderPointOrderCndtnWork.WarehouseCodes = orderListCndtn.WarehouseCodes;            // 倉庫指定
                orderPointOrderCndtnWork.St_SupplierCode = orderListCndtn.St_SupplierCode;          // 開始仕入先コード
                orderPointOrderCndtnWork.Ed_SupplierCode = orderListCndtn.Ed_SupplierCode;          // 終了仕入先コード
                orderPointOrderCndtnWork.SupplierCodes = orderListCndtn.SupplierCodes;              // 仕入先指定
                orderPointOrderCndtnWork.TrustStockDiv = orderListCndtn.TrustStockDiv;              // 受託在庫区分
                orderPointOrderCndtnWork.ObjDiv = orderListCndtn.ObjDiv;                            // 対象区分
                orderPointOrderCndtnWork.OrderRemainUpDate = orderListCndtn.OrderRemainUpDate;      // UOE以外発注残更新
                orderPointOrderCndtnWork.StkCntStandard = orderListCndtn.StkCntStandard;            // 現在庫数基準
                orderPointOrderCndtnWork.OrderStandard = orderListCndtn.OrderStandard;              // 発注基準
                orderPointOrderCndtnWork.LendCntCalc = orderListCndtn.LendCntCalc;                  // 貸出数計算
                orderPointOrderCndtnWork.PrtPaperTypeDiv = orderListCndtn.PrtPaperTypeDiv;          // 帳票タイプ
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        // 2008.09.02 30413 犬飼 処理内容の変更 <<<<<<END

        #region ◎ 取得データ展開
        // 2008.09.02 30413 犬飼 処理内容の変更 >>>>>>START
        #region 取得データ展開処理 <<<<<<変更前
        ///// <summary>
        ///// 取得データ展開処理
        ///// </summary>
        ///// <param name="orderListCndtn">UI抽出条件クラス</param>
        ///// <param name="stockMoveWork">取得データ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 取得データを展開する。</br>
        ///// <br>Programmer : 22018 鈴木 正臣</br>
        ///// <br>Date       : 2007.09.19</br>
        ///// </remarks>
        //private void DevListData ( OrderListCndtn orderListCndtn, ArrayList stockMoveWork )
        //{
        //    DataRow dr;

        //    foreach ( OrderListResultWork orderListResultWork in stockMoveWork )
        //    {
        //        dr = this._stockNoShipmentListDt.NewRow();
        //        // 取得データ展開
        //        #region 取得データ展開

        //        dr[DCHAT02104EA.ct_Col_DebitNoteDiv] = orderListResultWork.DebitNoteDiv; // 赤伝区分
        //        dr[DCHAT02104EA.ct_Col_SupplierSlipCd] = orderListResultWork.SupplierSlipCd; // 仕入伝票区分
        //        dr[DCHAT02104EA.ct_Col_OrderDataCreateDate] = GetDateText(orderListResultWork.OrderDataCreateDate); // 入力日
        //        dr[DCHAT02104EA.ct_Col_StockAgentCode] = orderListResultWork.StockAgentCode; // 仕入担当者コード
        //        dr[DCHAT02104EA.ct_Col_StockAgentName] = orderListResultWork.StockAgentName; // 仕入担当者名称
        //        dr[DCHAT02104EA.ct_Col_OrderFormPrintDate] = GetDateText(orderListResultWork.OrderFormPrintDate); // 発注書発行日
        //        dr[DCHAT02104EA.ct_Col_AcceptAnOrderNo] = orderListResultWork.AcceptAnOrderNo; // 受注番号
        //        dr[DCHAT02104EA.ct_Col_SupplierFormal] = orderListResultWork.SupplierFormal; // 仕入形式
        //        dr[DCHAT02104EA.ct_Col_SupplierSlipNo] = orderListResultWork.SupplierSlipNo; // 仕入伝票番号
        //        dr[DCHAT02104EA.ct_Col_StockRowNo] = orderListResultWork.StockRowNo; // 仕入行番号
        //        dr[DCHAT02104EA.ct_Col_SectionCode] = orderListResultWork.SectionCode; // 拠点コード
        //        dr[DCHAT02104EA.ct_Col_SectionGuideNm] = this.GetSectionGuideNm(orderListResultWork.SectionCode); // 拠点ガイド名称
        //        dr[DCHAT02104EA.ct_Col_StockInputCode] = orderListResultWork.StockInputCode; // 仕入入力者コード
        //        dr[DCHAT02104EA.ct_Col_StockInputName] = orderListResultWork.StockInputName; // 仕入入力者名称
        //        dr[DCHAT02104EA.ct_Col_GoodsMakerCd] = orderListResultWork.GoodsMakerCd; // 商品メーカーコード
        //        dr[DCHAT02104EA.ct_Col_MakerName] = orderListResultWork.MakerName; // メーカー名称
        //        dr[DCHAT02104EA.ct_Col_GoodsNo] = orderListResultWork.GoodsNo; // 商品番号
        //        dr[DCHAT02104EA.ct_Col_GoodsName] = orderListResultWork.GoodsName; // 商品名称
        //        dr[DCHAT02104EA.ct_Col_WarehouseCode] = orderListResultWork.WarehouseCode; // 倉庫コード
        //        dr[DCHAT02104EA.ct_Col_WarehouseName] = orderListResultWork.WarehouseName; // 倉庫名称
        //        dr[DCHAT02104EA.ct_Col_StockOrderDivCd] = orderListResultWork.StockOrderDivCd; // 仕入在庫取寄せ区分
        //        dr[DCHAT02104EA.ct_Col_UnitCode] = orderListResultWork.UnitCode; // 単位コード
        //        dr[DCHAT02104EA.ct_Col_UnitName] = orderListResultWork.UnitName; // 単位名称
        //        dr[DCHAT02104EA.ct_Col_StockUnitPriceFl] = orderListResultWork.StockUnitPriceFl; // 仕入単価（税抜，浮動）
        //        dr[DCHAT02104EA.ct_Col_StockUnitTaxPriceFl] = orderListResultWork.StockUnitTaxPriceFl; // 仕入単価（税込，浮動）
        //        dr[DCHAT02104EA.ct_Col_BargainCd] = orderListResultWork.BargainCd; // 特売区分コード
        //        dr[DCHAT02104EA.ct_Col_BargainNm] = orderListResultWork.BargainNm; // 特売区分名称
        //        //dr[DCHAT02104EA.ct_Col_StockCount] = orderListResultWork.StockCount; // 仕入数
        //        dr[DCHAT02104EA.ct_Col_StockDtiSlipNote1] = orderListResultWork.StockDtiSlipNote1; // 仕入伝票明細備考1
        //        dr[DCHAT02104EA.ct_Col_SalesCustomerCode] = orderListResultWork.SalesCustomerCode; // 販売先コード
        //        dr[DCHAT02104EA.ct_Col_SalesCustomerSnm] = orderListResultWork.SalesCustomerSnm; // 販売先名称
        //        dr[DCHAT02104EA.ct_Col_SupplierCd] = orderListResultWork.SupplierCd; // 仕入先コード
        //        dr[DCHAT02104EA.ct_Col_SupplierSnm] = orderListResultWork.SupplierSnm; // 仕入先略称
        //        dr[DCHAT02104EA.ct_Col_AddresseeCode] = orderListResultWork.AddresseeCode; // 納品先コード
        //        dr[DCHAT02104EA.ct_Col_AddresseeName] = orderListResultWork.AddresseeName; // 納品先名称
        //        dr[DCHAT02104EA.ct_Col_RemainCntUpdDate] = orderListResultWork.RemainCntUpdDate; // 残数更新日
        //        dr[DCHAT02104EA.ct_Col_DirectSendingCd] = orderListResultWork.DirectSendingCd; // 直送区分
        //        dr[DCHAT02104EA.ct_Col_OrderNumber] = orderListResultWork.OrderNumber; // 発注番号
        //        dr[DCHAT02104EA.ct_Col_WayToOrder] = orderListResultWork.WayToOrder; // 注文方法
        //        dr[DCHAT02104EA.ct_Col_DeliGdsCmpltDueDate] = GetDateText(orderListResultWork.DeliGdsCmpltDueDate); // 納品完了予定日
        //        dr[DCHAT02104EA.ct_Col_ExpectDeliveryDate] = GetDateText(orderListResultWork.ExpectDeliveryDate); // 希望納期
        //        //dr[DCHAT02104EA.ct_Col_OrderCnt] = orderListResultWork.OrderCnt; // 発注数量
        //        dr[DCHAT02104EA.ct_Col_OrderAdjustCnt] = orderListResultWork.OrderAdjustCnt; // 発注調整数
        //        dr[DCHAT02104EA.ct_Col_OrderRemainCnt] = orderListResultWork.OrderRemainCnt; // 発注残数
        //        dr[DCHAT02104EA.ct_Col_ReconcileFlag] = orderListResultWork.ReconcileFlag; // 消込フラグ
        //        dr[DCHAT02104EA.ct_Col_OrderFormIssuedDiv] = orderListResultWork.OrderFormIssuedDiv; // 発注書発行済区分
        //        dr[DCHAT02104EA.ct_Col_SlipMemo1] = orderListResultWork.SlipMemo1; // 伝票メモ１
        //        dr[DCHAT02104EA.ct_Col_SlipMemo2] = orderListResultWork.SlipMemo2; // 伝票メモ２
        //        dr[DCHAT02104EA.ct_Col_SlipMemo3] = orderListResultWork.SlipMemo3; // 伝票メモ３
        //        dr[DCHAT02104EA.ct_Col_SlipMemo4] = orderListResultWork.SlipMemo4; // 伝票メモ４
        //        dr[DCHAT02104EA.ct_Col_SlipMemo5] = orderListResultWork.SlipMemo5; // 伝票メモ５
        //        dr[DCHAT02104EA.ct_Col_SlipMemo6] = orderListResultWork.SlipMemo6; // 伝票メモ６
        //        dr[DCHAT02104EA.ct_Col_InsideMemo1] = orderListResultWork.InsideMemo1; // 社内メモ１
        //        dr[DCHAT02104EA.ct_Col_InsideMemo2] = orderListResultWork.InsideMemo2; // 社内メモ２
        //        dr[DCHAT02104EA.ct_Col_InsideMemo3] = orderListResultWork.InsideMemo3; // 社内メモ３
        //        dr[DCHAT02104EA.ct_Col_InsideMemo4] = orderListResultWork.InsideMemo4; // 社内メモ４
        //        dr[DCHAT02104EA.ct_Col_InsideMemo5] = orderListResultWork.InsideMemo5; // 社内メモ５
        //        dr[DCHAT02104EA.ct_Col_InsideMemo6] = orderListResultWork.InsideMemo6; // 社内メモ６

        //        dr[DCHAT02104EA.ct_Col_StockPriceTaxExc] = orderListResultWork.StockPriceTaxExc;    // 税抜金額
        //        dr[DCHAT02104EA.ct_Col_StockPriceTaxInc] = orderListResultWork.StockPriceTaxInc;    // 税込金額

        //        dr[DCHAT02104EA.ct_Col_OrderRemainPrice] = GetOrderRemainPrice( orderListResultWork.StockUnitPriceFl, orderListResultWork.OrderRemainCnt ); // 発注残金額
        //        dr[DCHAT02104EA.ct_Col_DebitNoteDivNm] = OrderListCndtn.GetDebitNoteDivNm(orderListResultWork.DebitNoteDiv); // 赤伝区分名称
        //        dr[DCHAT02104EA.ct_Col_SupplierSlipCdNm] = OrderListCndtn.GetSupplierSlipCdNm(orderListResultWork.SupplierSlipCd); // 仕入伝票区分名称
        //        dr[DCHAT02104EA.ct_Col_StockOrderDivNm] = OrderListCndtn.GetStockOrderDivCdNm(orderListResultWork.StockOrderDivCd); // 仕入在庫取寄せ区分名称
        //        dr[DCHAT02104EA.ct_Col_OrderFormIssuedDivNm] = OrderListCndtn.GetOrderFormIssuedDivNm(orderListResultWork.OrderFormIssuedDiv); // 発注書発行済み区分名称

        //        //dr[DCHAT02104EA.ct_Col_OrderAndAdjustCnt] = orderListResultWork.OrderCnt + orderListResultWork.OrderAdjustCnt;  // 印刷用　発注数（発注数＋発注調整数）

        //        dr[DCHAT02104EA.ct_Col_Sort_SectionCode] = orderListResultWork.SectionCode; // ソート用　拠点コード
        //        dr[DCHAT02104EA.ct_Col_Sort_OrderFormPrintDate] = orderListResultWork.OrderFormPrintDate; // ソート用　発注書発行日
        //        dr[DCHAT02104EA.ct_Col_Sort_GoodsMakerCd] = orderListResultWork.GoodsMakerCd; // ソート用　商品メーカーコード
        //        dr[DCHAT02104EA.ct_Col_Sort_GoodsNo] = orderListResultWork.GoodsNo; // ソート用　商品番号
        //        dr[DCHAT02104EA.ct_Col_Sort_SupplierCd] = orderListResultWork.SupplierCd; // ソート用　仕入先コード
        //        dr[DCHAT02104EA.ct_Col_Sort_OrderDataCreateDate] = orderListResultWork.OrderDataCreateDate; // ソート用　入力日
        //        dr[DCHAT02104EA.ct_Col_Sort_ExpectDeliveryDate] = orderListResultWork.ExpectDeliveryDate; // ソート用　希望納期
        //        dr[DCHAT02104EA.ct_Col_Sort_SupplierSlipNo] = orderListResultWork.SupplierSlipNo; // ソート用　仕入伝票番号
        //        dr[DCHAT02104EA.ct_Col_Sort_StockRowNo] = orderListResultWork.StockRowNo; // ソート用　仕入行番号

        //        //---------------------------------------------------------
        //        // データセット仕様を考慮して、セット値を変更する
        //        //---------------------------------------------------------
        //        // ”仕入数”＝仕入数－発注残数
        //        dr[DCHAT02104EA.ct_Col_StockCount] = orderListResultWork.StockCount - orderListResultWork.OrderRemainCnt;
        //        // ”発注数”＝仕入数
        //        dr[DCHAT02104EA.ct_Col_OrderCnt] = orderListResultWork.StockCount;
        //        // ”調整済発注数”＝仕入数　（調整数は使用しない）
        //        dr[DCHAT02104EA.ct_Col_OrderAndAdjustCnt] = orderListResultWork.StockCount;

        //        #endregion

        //        // TableにAdd
        //        this._stockNoShipmentListDt.Rows.Add( dr );
        //    }

        //    // DataView作成
        //    this._stockNoShipmentListDataView = new DataView( this._stockNoShipmentListDt, "", GetSortOrder(orderListCndtn), DataViewRowState.CurrentRows );
        //}
        #endregion

        #region 取得データ展開処理
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="orderListCndtn">UI抽出条件クラス</param>
        /// <param name="stockMoveWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>UpdateNote : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : 2017/09/14</br>
        /// <br>Update Note: ㈱ダイサブの対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/11/05</br>
        /// </remarks>
        private void DevListData(OrderListCndtn orderListCndtn, ArrayList stockMoveWork)
        {
            DataRow dr;

            // 自社情報を取得
            int status = -1;
            CompanyInf companyInf;
            status = this._companyInfAcs.Read(out companyInf, orderListCndtn.EnterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得失敗の場合は自社情報は初期化
                companyInf = new CompanyInf();
            }

            // 在庫管理全体設定マスタから最高在庫数超え発注区分を取得
            this.CacheStockMngTtlSt(orderListCndtn);

            // 仕入先マスタをローカルキャッシュに設定
            this.CacheSupplierData();

            // UOE発注先マスタをローカルキャッシュに設定
            this.CacheUOESupplierData();

            // UOE自社マスタをローカルキャッシュに設定
            this.CacheUOESettingData();

            // 商品アクセスクラスの抽出条件をクリア
            this._goodsCndtnList = new List<GoodsCndtn>();

            // 2009/09/14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 商品連結データローカルキャッシュをクリア
            _goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            // 2009/09/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 税率取得
            TaxRateSet taxRateSet;
            if (this.TaxRateSetRead(out taxRateSet) == 0)
            {
                _taxRate = this.GetTaxRate(taxRateSet, DateTime.Now);
            }

            // ADD 2009/06/09 ------>>>
            // 倉庫マスタをローカルキャッシュに設定
            this.CacheWarehouseData();
            // ADD 2009/06/09 ------<<<

            foreach (AutoOrderResultWork autoOrderResultWork in stockMoveWork)
            {
                if (string.IsNullOrEmpty(autoOrderResultWork.GoodsName.Trim())) continue;    // 品名が取得できていない（商品がユーザー登録されていない）場合は無条件対象外

                // 2008.11.08 30413 犬飼 受託在庫区分で発注対象チェック >>>>>>START
                // 受託在庫区分
                if (orderListCndtn.TrustStockDiv == 0)
                {
                    // 発注対象としない
                    if (autoOrderResultWork.StockDiv == 1)
                    {
                        // 受託在庫
                        continue;
                    }
                }
                // 2008.11.08 30413 犬飼 受託在庫区分で発注対象チェック <<<<<<END

                // ---ADD 2009/06/29 不具合対応[13591] ------------------>>>>>
                // 現在庫数基準が「マイナスも含めて計算」時、最低在庫・最高在庫の両方がゼロのものは対象としない
                if (orderListCndtn.StkCntStandard == 1)
                {
                    if ((autoOrderResultWork.MinimumStockCnt == 0) && (autoOrderResultWork.MaximumStockCnt == 0))
                    {
                        continue;
                    }
                }
                // ---ADD 2009/06/29 不具合対応[13591] ------------------<<<<<

                dr = this._stockNoShipmentListDt.NewRow();
                // 取得データ展開
                #region 取得データ展開

                // 2008.11.10 30413 犬飼 YYYY/MM/DDに書式を変更 >>>>>>START
                //dr[DCHAT02104EA.ct_Col_ProcessDay] = TDateTime.DateTimeToString("yyyy年MM月dd日", orderListCndtn.ProcessDay);
                dr[DCHAT02104EA.ct_Col_ProcessDay] = TDateTime.DateTimeToString(OrderListCndtn.ct_DateFomat, orderListCndtn.ProcessDay);
                // 2008.11.10 30413 犬飼 YYYY/MM/DDに書式を変更 <<<<<<END
                dr[DCHAT02104EA.ct_Col_SectionCode] = autoOrderResultWork.SectionCode.Trim();           // 拠点コード
                dr[DCHAT02104EA.ct_Col_SectionGuideSnm] = autoOrderResultWork.SectionGuideSnm;          // 拠点ガイド名称
                dr[DCHAT02104EA.ct_Col_GoodsMakerCd] = autoOrderResultWork.GoodsMakerCd;                // 商品メーカーコード
                // ------ UPD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                //dr[DCHAT02104EA.ct_Col_MakerName] = autoOrderResultWork.MakerName;                      // メーカー名称
                dr[DCHAT02104EA.ct_Col_MakerName] = GetMakerName(autoOrderResultWork.MakerName);          // メーカー名称
                // ------ UPD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<
                dr[DCHAT02104EA.ct_Col_GoodsNo] = autoOrderResultWork.GoodsNo;                          // 商品番号
                dr[DCHAT02104EA.ct_Col_GoodsName] = autoOrderResultWork.GoodsName;                      // 商品名称
                dr[DCHAT02104EA.ct_Col_SupplierStock] = autoOrderResultWork.SupplierStock;              // 仕入在庫数
                dr[DCHAT02104EA.ct_Col_AcpOdrCount] = autoOrderResultWork.AcpOdrCount;                  // 受注数
                dr[DCHAT02104EA.ct_Col_SalesOrderCount] = autoOrderResultWork.SalesOrderCount;          // 受注数(発注残)
                dr[DCHAT02104EA.ct_Col_StockDiv] = autoOrderResultWork.StockDiv;                        // 在庫区分
                dr[DCHAT02104EA.ct_Col_MovingSupliStock] = autoOrderResultWork.MovingSupliStock;        // 移動中仕入在庫数
                dr[DCHAT02104EA.ct_Col_ShipmentPosCnt] = autoOrderResultWork.ShipmentPosCnt;            // 出荷可能数
                dr[DCHAT02104EA.ct_Col_MinimumStockCnt] = autoOrderResultWork.MinimumStockCnt;          // 最低在庫数
                dr[DCHAT02104EA.ct_Col_MaximumStockCnt] = autoOrderResultWork.MaximumStockCnt;          // 最高在庫数
                dr[DCHAT02104EA.ct_Col_SalesOrderUnit] = autoOrderResultWork.SalesOrderUnit;            // 発注単位
                dr[DCHAT02104EA.ct_Col_StockSupplierCode] = autoOrderResultWork.StockSupplierCode;      // 在庫発注先コード
                dr[DCHAT02104EA.ct_Col_WarehouseCode] = autoOrderResultWork.WarehouseCode;              // 倉庫コード
                dr[DCHAT02104EA.ct_Col_WarehouseName] = autoOrderResultWork.WarehouseName;              // 倉庫名称
                dr[DCHAT02104EA.ct_Col_WarehouseShelfNo] = autoOrderResultWork.WarehouseShelfNo;        // 倉庫棚番
                dr[DCHAT02104EA.ct_Col_DuplicationShelfNo1] = autoOrderResultWork.DuplicationShelfNo1;  // 重複棚番１
                dr[DCHAT02104EA.ct_Col_DuplicationShelfNo2] = autoOrderResultWork.DuplicationShelfNo2;  // 重複棚番２
                dr[DCHAT02104EA.ct_Col_ShipmentCnt] = autoOrderResultWork.ShipmentCnt;                  // 出荷数(未計上)
                dr[DCHAT02104EA.ct_Col_ArrivalCnt] = autoOrderResultWork.ArrivalCnt;                    // 入荷数(未計上)
                dr[DCHAT02104EA.ct_Col_SupplierCd] = autoOrderResultWork.SupplierCd;                    // 仕入先コード
                dr[DCHAT02104EA.ct_Col_SupplierLot] = autoOrderResultWork.SupplierLot;                  // 発注ロッド
                dr[DCHAT02104EA.ct_Col_AutoOrderCount] = autoOrderResultWork.AutoOrderCount;            // 自動発注数
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                if (orderListCndtn.CoNmPrintOutCd == 0)
                {
                    // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                    dr[DCHAT02104EA.ct_Col_EnterpriseName1] = companyInf.CompanyName1;                      // 自社名称１
                    dr[DCHAT02104EA.ct_Col_EnterpriseName2] = companyInf.CompanyName2;                      // 自社名称２
                    dr[DCHAT02104EA.ct_Col_EnterpriseTel] = companyInf.CompanyTelNo1;                       // 自社電話番号
                    dr[DCHAT02104EA.ct_Col_EnterpriseFax] = companyInf.CompanyTelNo3;                       // 自社FAX番号
                    // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                }
                else
                {
                    if (CompanyNmDic.ContainsKey(stc_SecInfoAcs.SecInfoSet.CompanyNameCd1))
                    {
                        dr[DCHAT02104EA.ct_Col_EnterpriseName1] = CompanyNmDic[stc_SecInfoAcs.SecInfoSet.CompanyNameCd1].CompanyName1;                      // 自社名称１
                        dr[DCHAT02104EA.ct_Col_EnterpriseName2] = CompanyNmDic[stc_SecInfoAcs.SecInfoSet.CompanyNameCd1].CompanyName2;                      // 自社名称２
                        dr[DCHAT02104EA.ct_Col_EnterpriseTel] = CompanyNmDic[stc_SecInfoAcs.SecInfoSet.CompanyNameCd1].CompanyTelNo1;                       // 自社電話番号
                        dr[DCHAT02104EA.ct_Col_EnterpriseFax] = CompanyNmDic[stc_SecInfoAcs.SecInfoSet.CompanyNameCd1].CompanyTelNo3;                       // 自社FAX番号
                    }
                }
                // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                

                // 改頁用
                // 拠点+倉庫
                dr[DCHAT02104EA.ctCol_SectionWareHouse] = autoOrderResultWork.SectionCode.Trim() + autoOrderResultWork.WarehouseCode;

                // 在庫発注先コードのチェック
                int supplierCd = 0;
                if (autoOrderResultWork.StockSupplierCode != 0)
                {
                    // 在庫発注先コードが設定
                    supplierCd = autoOrderResultWork.StockSupplierCode;
                }
                else
                {
                    // 2009/10/16 >>>
                    #region コメントアウト
                    //// 在庫発注先コードが未設定
                    //if (autoOrderResultWork.SupplierCd != 0)
                    //{
                    //    // 仕入先コードが設定
                    //    supplierCd = autoOrderResultWork.SupplierCd;
                    //}
                    //else
                    //{
                    //    // 2009/09/14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //    //// 仕入先コードが未設定
                    //    //GoodsUnitData goodsUnitData = new GoodsUnitData();
                    //    //this.GetGoodsMngInfo(ref goodsUnitData, autoOrderResultWork);
                    //    //if (goodsUnitData != null)
                    //    //{
                    //    //    supplierCd = goodsUnitData.SupplierCd;
                    //    //}

                    //    // 商品アクセスクラスの抽出条件を設定
                    //    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    //    goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    //    goodsCndtn.SectionCode = autoOrderResultWork.SectionCode.Trim();
                    //    goodsCndtn.MakerName = autoOrderResultWork.MakerName;
                    //    goodsCndtn.GoodsNoSrchTyp = 0;
                    //    goodsCndtn.GoodsMakerCd = autoOrderResultWork.GoodsMakerCd;
                    //    goodsCndtn.GoodsNo = autoOrderResultWork.GoodsNo;
                    //    goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                    //    // 商品アクセスクラスから商品情報を取得
                    //    GoodsUnitData gUnitdata = this.GoodsRead(goodsCndtn);
                    //    if (gUnitdata != null)
                    //    {
                    //        supplierCd = gUnitdata.SupplierCd;
                    //    }
                    //    // 2009/09/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //}
                    #endregion

                    // -- UPD 2010/06/09 ----------------------------->>>
                    //// 商品アクセスクラスの抽出条件を設定
                    //GoodsCndtn goodsCndtn = new GoodsCndtn();
                    //goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    //goodsCndtn.SectionCode = autoOrderResultWork.SectionCode.Trim();
                    //goodsCndtn.MakerName = autoOrderResultWork.MakerName;
                    //goodsCndtn.GoodsNoSrchTyp = 0;
                    //goodsCndtn.GoodsMakerCd = autoOrderResultWork.GoodsMakerCd;
                    //goodsCndtn.GoodsNo = autoOrderResultWork.GoodsNo;
                    //goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                    //// 商品アクセスクラスから商品情報を取得
                    //GoodsUnitData gUnitdata = this.GoodsRead(goodsCndtn);
                    //if (gUnitdata != null)
                    //{
                    //    // リモートの結果で、在庫マスタの発注先を取得できている場合は優先してセット
                    //    supplierCd = ( autoOrderResultWork.StockSupplierCode != 0 ) ? autoOrderResultWork.StockSupplierCode : gUnitdata.SupplierCd;
                    //}
                    //else
                    //{
                    //    // 商品マスタに該当データが無い場合は対象外
                    //    continue;
                    //}

                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    this.GetGoodsMngInfo(ref goodsUnitData, autoOrderResultWork);
                    if (goodsUnitData != null)
                    {
                        supplierCd = goodsUnitData.SupplierCd;
                    }

                    // -- UPD 2010/06/09 -----------------------------<<<

                    // 2009/10/16 <<<

                }
                string strSupplierCd = supplierCd.ToString("d06");
                dr[DCHAT02104EA.ct_Col_SupplierCodePrint] = strSupplierCd;             // 仕入先コード(印字用)

                // 2009.01.07 30413 犬飼 仕入先の抽出条件チェックを追加 >>>>>>START
                if (!CheckSupplierCd(orderListCndtn, supplierCd))
                {
                    // 抽出対象外の仕入先
                    continue;
                }
                // 2009.01.07 30413 犬飼 仕入先の抽出条件チェックを追加 <<<<<<END

                // UOE発注先マスタへの存在チェック
                bool uoeFlg = false;

                // 2009.01.07 30413 犬飼 拠点コードをキーに追加 >>>>>>START
                string supplierKey = autoOrderResultWork.SectionCode.TrimEnd() + "-" + strSupplierCd;
                //if (_uoeSupplierDic.ContainsKey(strSupplierCd))
                if (_uoeSupplierDic.ContainsKey(supplierKey))
                {
                    // UOE発注先マスタに存在する
                    uoeFlg = true;
                    dr[DCHAT02104EA.ct_Col_UOEOrderDiv] = 1;                        // UOE発注分
                }
                else
                {
                    dr[DCHAT02104EA.ct_Col_UOEOrderDiv] = 0;                        // UOE発注分以外
                }
                // 2009.01.07 30413 犬飼 拠点コードをキーに追加 <<<<<<END
            
                // 2008.11.10 30413 犬飼 抽出条件の処理区分から印字データを決定 >>>>>>START
                if (orderListCndtn.ObjDiv == 1)
                {
                    // 処理区分がUOE発注分
                    if (!uoeFlg)
                    {
                        // 抽出結果はUOE発注以外
                        continue;
                    }

                }
                else if (orderListCndtn.ObjDiv == 2)
                {
                    // 処理区分がUOE発注以外
                    if (uoeFlg)
                    {
                        // 抽出結果はUOE発注分
                        continue;
                    }
                }
                // 2008.11.10 30413 犬飼 抽出条件の処理区分から印字データを決定 <<<<<<END

                // 仕入先マスタから仕入先名称を取得
                if (_supplierDic.ContainsKey(strSupplierCd))
                {
                    // 仕入先マスタに存在
                    Supplier supplier = _supplierDic[strSupplierCd];
                    // 仕入先名称を設定
                    dr[DCHAT02104EA.ct_Col_SupplierName] = supplier.SupplierNm1;    // 仕入先名称
                }
                else
                {
                    // 2010/01/18 >>>
                    //dr[DCHAT02104EA.ct_Col_SupplierName] = "";                      // 仕入先名称
                    dr[DCHAT02104EA.ct_Col_SupplierName] = "未登録";                      // 仕入先名称
                    // 2010/01/18 <<<
                }

                // 受注数(ロット計算後)
                double workOrderCount = autoOrderResultWork.AutoOrderCount;
                // 2008.12.10 UPD 1:発注残一覧表の場合は処理しない>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (orderListCndtn.LotCalcDiv == 0)
                if ((orderListCndtn.PrtPaperTypeDiv == 0) && (orderListCndtn.LotCalcDiv == 0))
                // 2008.12.10 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    // ロット計算をする
                    if (autoOrderResultWork.SalesOrderUnit != 0)
                    {
                        // 2009.03.09 30413 犬飼 発注単位を整数に変更 >>>>>>START
                        // 発注単位がゼロ以外
                        //double workLotUnit = workOrderCount / autoOrderResultWork.SalesOrderUnit;
                        long workLotUnit = (long)(workOrderCount / autoOrderResultWork.SalesOrderUnit);
                        // 2009.03.09 30413 犬飼 発注単位を整数に変更 <<<<<<END
                        
                        // 在庫管理全体設定マスタのローカルキャッシュを取得
                        StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
                        if (_stockMngTtlStDic.ContainsKey(autoOrderResultWork.SectionCode.Trim()))
                        {
                            stockMngTtlSt = _stockMngTtlStDic[autoOrderResultWork.SectionCode.Trim()];
                        }

                        // 在庫管理全体設定マスタの最高在庫数超え発注区分
                        if (stockMngTtlSt.MaxStkCntOverOderDiv == 0)
                        {
                            // 最高在庫数超え発注をしない
                            workOrderCount = workLotUnit * autoOrderResultWork.SalesOrderUnit;
                        }
                        else
                        {
                            // 最高在庫数超え発注をする
                            workLotUnit++;
                            workOrderCount = workLotUnit * autoOrderResultWork.SalesOrderUnit;
                        }

                        // 2009.03.09 30413 犬飼 発注単位を整数に変更 >>>>>>START
                        if (workOrderCount == 0.0)
                        {
                            // ロット計算によりゼロの場合は、発注対象外
                            continue;
                        }
                        // 2009.03.09 30413 犬飼 発注単位を整数に変更 <<<<<<END
                    }
                }

                // UOE発注区分
                if (uoeFlg)
                {
                    if (workOrderCount > 999)
                    {
                        dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc] = 999;
                    }
                    else
                    {
                        // 2009.01.07 30413 犬飼 小数を切り上げ >>>>>>START
                        //dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc] = workOrderCount;
                        dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc] = Math.Ceiling(workOrderCount);
                        // 2009.01.07 30413 犬飼 小数を切り上げ <<<<<<END
                    }
                }
                else
                {
                    dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc] = workOrderCount;
                }
                #endregion

                // TableにAdd
                this._stockNoShipmentListDt.Rows.Add(dr);

                // 商品アクセスクラスの抽出条件を設定
                GoodsCndtn workGoodsCndtn = new GoodsCndtn();
                workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                workGoodsCndtn.SectionCode = autoOrderResultWork.SectionCode.Trim();
                workGoodsCndtn.MakerName = autoOrderResultWork.MakerName;
                workGoodsCndtn.GoodsNoSrchTyp = 0;
                workGoodsCndtn.GoodsMakerCd = autoOrderResultWork.GoodsMakerCd;
                workGoodsCndtn.GoodsNo = autoOrderResultWork.GoodsNo;
                workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                this._goodsCndtnList.Add(workGoodsCndtn);
            }

            // 2009.02.02 30413 犬飼 発注対象データがゼロ件の処理を追加 >>>>>>START
            if (this._stockNoShipmentListDt.Rows.Count == 0)
            {
                // 発注対象データがゼロ件
                this._stockNoShipmentListDataView = new DataView();
                return;
            }
            // 2009.02.02 30413 犬飼 発注対象データがゼロ件の処理を追加 <<<<<<END
            
            // 商品アクセスクラスから商品情報を取得
            this.GoodsRead(this._goodsCndtnList);

            // 発注データのクリア
            this.CacheOrderDataClear();

            // 発注データの作成
            // ------------DEL zhangy3 2012/10/16 FOR Redmine#32860--------->>>>
            //for (int i = 0; i < this._stockNoShipmentListDt.Rows.Count; i++)
            //{
            //    DataRow workRow = this._stockNoShipmentListDt.Rows[i];
            // ------------DEL zhangy3 2012/10/16 FOR Redmine#32860---------<<<<
            // ------------ADD zhangy3 2012/10/16 FOR Redmine#32860--------->>>>
            DataRow[] rowArr = this._stockNoShipmentListDt.Select("", GetSortOrder(orderListCndtn));
            for (int i = 0; i < rowArr.Length; i++)
            {
                DataRow workRow = rowArr[i];
            // ------------ADD zhangy3 2012/10/16 FOR Redmine#32860---------<<<<
                if ((int)workRow[DCHAT02104EA.ct_Col_UOEOrderDiv] == 1)
                {
                    // UOE発注分関連付けGUID
                    Guid relGuid = Guid.NewGuid();
                    // 仕入明細データの作成
                    this.SetStockDetailWork(orderListCndtn, workRow, relGuid, ref _stockDetailUOEList);
                    // UOE発注データの作成
                    this.SetUOEOrderDtlWork(orderListCndtn, workRow, relGuid, ref _uoeOrderDtlList);
                }
                else
                {
                    Guid guid = new Guid();
                    // 仕入明細データの作成
                    this.SetStockDetailWork(orderListCndtn, workRow, guid, ref this._stockDetailList);
                    // 仕入データの作成
                    this.SetStockSlipWork(orderListCndtn, workRow, this._stockDetailList.Count);
                }
            }

            // 仕入データの更新リストを作成
            //for (int i = 0; i < this._stockSlipWorkList.Count; i++)
            //{
            //    _stockSlipList.Add(this._stockSlipWorkList[i]);
            //}
            // 仕入データの更新ディクショナリーを作成
            foreach (string key in this._stockSlipWorkDic.Keys)
            {
                StockSlipWork stockSlipWork = this._stockSlipWorkDic[key];
                _stockSlipDic.Add(key, stockSlipWork);
            }

            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            // バーコード表示する場合
            if (this._barCodeShowDiv)
            {
                // 既存メソッドの呼出 「BlanketStockInputDataDiv:一括仕入入力データ作成」
                status = this.UpdateOrderDate(orderListCndtn.BlanketStockInputDataDiv);
                // 戻り値(status)がNORMAL　&&　画面条件の「一括仕入入力データ作成」が「0：作成する」の場合、仕入SEQ番号のセット処理を行います。
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (orderListCndtn.BlanketStockInputDataDiv == 0)
                    {
                        string key = string.Empty;
                        string warehouseCodeKey = string.Empty;
                        string sectionCodeKey = string.Empty;
                        string supplierCodeKey = string.Empty;
                        // 印刷用データをループし、キーが一致するレコードの仕入SEQ番号をセットします。
                        for (int index = 0; index < this._stockNoShipmentListDt.Rows.Count; index++)
                        {
                            sectionCodeKey = this._stockNoShipmentListDt.Rows[index][DCHAT02104EA.ct_Col_SectionCode].ToString();
                            supplierCodeKey = this._stockNoShipmentListDt.Rows[index][DCHAT02104EA.ct_Col_SupplierCodePrint].ToString();
                            warehouseCodeKey = this._stockNoShipmentListDt.Rows[index][DCHAT02104EA.ct_Col_WarehouseCode].ToString();
                            key = sectionCodeKey + Hyphen + warehouseCodeKey + Hyphen + supplierCodeKey;
                            if (this.StockSlipDic.ContainsKey(key))
                            {
                                this._stockNoShipmentListDt.Rows[index][DCHAT02104EA.ct_Col_SupplierSeqNoForBarCode] = this.StockSlipDic[key];
                            }
                        }
                    }
                }
                // 企業ロックタイムアウト
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "更新に失敗しました。" + "\r\n"
                                        + "\r\n" +
                                        "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                                        "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                                        status,
                                        MessageBoxButtons.OK);
                    return;
                }
                // 拠点ロックタイムアウト
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "更新に失敗しました。" + "\r\n"
                                        + "\r\n" +
                                        "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                                        "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                                        status,
                                        MessageBoxButtons.OK);
                    return;
                }
                // 倉庫ロックタイムアウト
                else if (status == (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "更新に失敗しました。" + "\r\n"
                                        + "\r\n" +
                                        "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                                        "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                                        status,
                                        MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        "発注データの更新が失敗しました。" + "ST=" + status,
                                        status,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

            // DataView作成
            this._stockNoShipmentListDataView = new DataView(this._stockNoShipmentListDt, "", GetSortOrder(orderListCndtn), DataViewRowState.CurrentRows);
        }
        #endregion
        // 2008.09.02 30413 犬飼 処理内容の変更 <<<<<<END

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "DCHAT02102P", iMsg, iSt, iButton, iDefButton);
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<


        // 2008.09.03 30413 犬飼 未使用のため削除 >>>>>>START
        #region 発注残金額取得処理
        ///// <summary>
        ///// 発注残金額取得処理
        ///// </summary>
        ///// <param name="stockUnitPriceFl">単価</param>
        ///// <param name="orderRemainCount">発注残数</param>
        ///// <returns></returns>
        //private Int64 GetOrderRemainPrice( double stockUnitPriceFl, double orderRemainCount )
        //{
        //    return (Int64)Math.Floor( stockUnitPriceFl * orderRemainCount);
        //}
        #endregion
        // 2008.09.03 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.03 30413 犬飼 未使用のため削除 >>>>>>START
        #region 拠点ガイド名称取得
        ///// <summary>
        ///// 拠点ガイド名称取得
        ///// </summary>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <returns>拠点ガイド名称</returns>
        //private string GetSectionGuideNm ( string sectionCode )
        //{
        //    if ( stc_SectionDic.ContainsKey(sectionCode) ) {
        //        return stc_SectionDic[sectionCode].SectionGuideNm;
        //    }
        //    else {
        //        return string.Empty;
        //    }
        //}
        #endregion
        // 2008.09.03 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.03 30413 犬飼 未使用のため削除 >>>>>>START
        #region 日付文字列取得(YYYY/MM/DD)
        ///// <summary>
        ///// 日付文字列取得(YYYY/MM/DD)
        ///// </summary>
        ///// <param name="dateTime">対象日付</param>
        ///// <returns>日付文字列</returns>
        //private static string GetDateText ( DateTime dateTime ) 
        //{
        //    if (dateTime != DateTime.MinValue) {
        //        return dateTime.ToString("yyyy/MM/dd");
        //    }
        //    else {
        //        return string.Empty;
        //    }
        //}
        #endregion
        // 2008.09.03 30413 犬飼 未使用のため削除 <<<<<<END

        // 2008.09.03 30413 犬飼 未使用のため削除 >>>>>>START
        #region 日付文字列取得(YYYY/MM/DD)
        ///// <summary>
        ///// 日付文字列取得(YYYY/MM/DD)
        ///// </summary>
        ///// <param name="longDate">対象日付</param>
        ///// <returns>日付文字列</returns>
        //private static string GetDateText ( int longDate )
        //{
        //    if ( longDate >= 0 ) {
        //        return string.Format("{0}/{1}/{2}", longDate / 10000, longDate / 100 % 100, longDate % 100);
        //    }
        //    else {
        //        return string.Empty;
        //    }
        //}
        #endregion
        // 2008.09.03 30413 犬飼 未使用のため削除 <<<<<<END

        #endregion

        #region ◎ ソート順作成
        /// <summary>
        /// ソート順作成
        /// </summary>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note        : ㈱ダイサブの対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2019/11/05</br>
        /// </remarks>
        private string GetSortOrder(OrderListCndtn orderListCndtn)
		{
			StringBuilder strSortOrder = new StringBuilder();

            //if ( !orderListCndtn.IsSelectAllSection )
            //{
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append( string.Format("{0},", DCHAT02104EA.ct_Col_SectionCode ) );
            //}

            // 2008.09.02 30413 犬飼 ソート順の変更 >>>>>>START
            switch (orderListCndtn.PrintSortDiv)
            {
                //// 入力日順
                //case OrderListCndtn.PrintSortDivState.ByOrderDataCreateDate :
                //    //strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SectionCode)); // 拠点コード
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_OrderDataCreateDate)); // 発注日
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierSlipNo)); // 仕入伝票番号
                //    strSortOrder.Append(string.Format("{0}" , DCHAT02104EA.ct_Col_Sort_StockRowNo)); // 仕入伝票行№
                //    break;
                //// 希望納期順
                //case OrderListCndtn.PrintSortDivState.ByExpectDeliveryDate :
                //    //strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SectionCode)); // 拠点コード
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_ExpectDeliveryDate)); // 希望納期
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierSlipNo)); // 仕入伝票番号
                //    strSortOrder.Append(string.Format("{0}" , DCHAT02104EA.ct_Col_Sort_StockRowNo)); // 仕入伝票行№
                //    break;
                //// 発行日順
                //case OrderListCndtn.PrintSortDivState.ByOrderFormPrintDate:
                //    //strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SectionCode)); // 拠点コード
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_OrderFormPrintDate)); // 発行日
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierSlipNo)); // 仕入伝票番号
                //    strSortOrder.Append(string.Format("{0}" , DCHAT02104EA.ct_Col_Sort_StockRowNo)); // 仕入伝票行№
                //    break;
                //// メーカー・商品別発行日順
                //case OrderListCndtn.PrintSortDivState.ByMakerGoodsSalesOrderDate:
                //    //strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SectionCode)); // 拠点コード
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_GoodsMakerCd)); // メーカーコード
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_GoodsNo)); // 商品番号
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_OrderFormPrintDate)); // 発行日
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierSlipNo)); // 仕入伝票番号
                //    strSortOrder.Append(string.Format("{0}" , DCHAT02104EA.ct_Col_Sort_StockRowNo)); // 仕入伝票行№
                //    break;
                //// 発注先別発行日順
                //case OrderListCndtn.PrintSortDivState.BySupplierSalesOrderDate:
                //    //strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SectionCode)); // 拠点コード
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierCd)); // 発注先
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_OrderFormPrintDate)); // 発行日
                //    strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierSlipNo)); // 仕入伝票番号
                //    strSortOrder.Append(string.Format("{0}" , DCHAT02104EA.ct_Col_Sort_StockRowNo)); // 仕入伝票行№
                //    break;

                // メーカー・品番順
                case OrderListCndtn.PrintSortDivState.ByOrderMakerGoodNo:
                    {
                        strSortOrder.Append("SectionCode,");            // 拠点コード
                        strSortOrder.Append("WarehouseCode,");          // 倉庫コード
                        strSortOrder.Append("SupplierCodePrint,");      // 仕入先コード
                        strSortOrder.Append("GoodsMakerCd,");           // メーカーコード
                        strSortOrder.Append("GoodsNo");                 // 品番
                        break;
                    }
                // 棚番順
                case OrderListCndtn.PrintSortDivState.ByOrderShelfNo:
                    {
                        strSortOrder.Append("SectionCode,");            // 拠点コード
                        strSortOrder.Append("WarehouseCode,");          // 倉庫コード
                        strSortOrder.Append("SupplierCodePrint,");      // 仕入先コード
                        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
                        if (orderListCndtn.MakerCdDiv == 0)
                        {
                            strSortOrder.Append("GoodsMakerCd,");           // メーカーコード
                        }
                        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<
                        strSortOrder.Append("WarehouseShelfNo");        // 棚番
                        strSortOrder.Append(",GoodsNo");                // 品番     // ADD 2015/07/23 m.kawarabayashi 東海自動車工業課題対応一覧No.2
                        break;
                    }
                // その他(想定外)
                default :
                    ////strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SectionCode)); // 拠点コード
                    //strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierSlipNo)); // 仕入伝票番号
                    //strSortOrder.Append(string.Format("{0}" , DCHAT02104EA.ct_Col_Sort_StockRowNo)); // 仕入伝票行№
                    break;
            }
            // 2008.09.02 30413 犬飼 ソート順の変更 <<<<<<END
            
			return strSortOrder.ToString();
		}
		#endregion

		#endregion ◆ データ展開処理

		#region ◆ 帳票設定データ取得
		#region ◎ 帳票出力設定取得処理
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 22018 kubo</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";	

			try
			{
				// データは読込済みか？
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "帳票出力設定の読込に失敗しました";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票設定データ取得

        #region ◆ 発注データ更新
        #region 仕入データの設定
        /// <summary>
        /// 仕入データの設定
        /// </summary>
        /// <param name="orderListCndtn">抽出条件データクラス</param>
        /// <param name="dr">抽出結果データ行</param>
        /// <param name="i">仕入明細データインデックス</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注用の仕入データを作成。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void SetStockSlipWork(OrderListCndtn orderListCndtn, DataRow dr, int i)
        {
            StockSlipWork stockSlipWork = new StockSlipWork();
            // 仕入明細データを取得
            StockDetailWork stockDetailWork = (StockDetailWork)this._stockDetailList[i - 1];
            Supplier supplierWork = new Supplier();

            // 2009.01.07 30413 犬飼 未使用となったので削除 >>>>>>START
            //UOESupplier uoeSupplierWork = new UOESupplier();
            // 2009.01.07 30413 犬飼 未使用となったので削除 <<<<<<END
            
            //string key = (string)dr[DCHAT02104EA.ct_Col_SectionCode] + "-" + (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
            string key = (string)dr[DCHAT02104EA.ct_Col_SectionCode] + "-"
                       + (string)dr[DCHAT02104EA.ct_Col_WarehouseCode] + "-"
                       + (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];

            // 発注用の仕入明細データの追加・更新
            ArrayList stockDetaiList = new ArrayList();
            if (_stockDetailDic.ContainsKey(key))
            {
                stockDetaiList = _stockDetailDic[key];
                _stockDetailDic.Remove(key);
            }
            stockDetaiList.Add(stockDetailWork);
            _stockDetailDic.Add(key, stockDetaiList);

            // 仕入データキャッシュ存在有無
            if (this._stockSlipWorkDic.ContainsKey(key))
            {
                // キャッシュ有
                stockSlipWork = _stockSlipWorkDic[key];

                // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 >>>>>>START
                //// ワークリストを削除
                //if (this._stockSlipWorkList.Contains(stockSlipWork))
                //{
                //    this._stockSlipWorkList.Remove(stockSlipWork);
                //}
                // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 <<<<<<END

                // 2009.01.07 30413 犬飼 仕入明細データの仕入金額の設定を修正 >>>>>>START
                // 仕入金額合計
                //stockSlipWork.StockTotalPrice += stockDetailWork.StockPriceTaxExc;      // 仕入明細データの仕入金額(税抜)合計
                stockSlipWork.StockTotalPrice += stockDetailWork.StockPriceTaxInc;      // 仕入明細データの仕入金額(税込)合計
                // 仕入金額小計
                //stockSlipWork.StockSubttlPrice += stockDetailWork.StockPriceTaxInc;     // 仕入明細データの仕入金額(税込)合計
                stockSlipWork.StockSubttlPrice += stockDetailWork.StockPriceTaxExc;     // 仕入明細データの仕入金額(税抜)合計
                // 2009.01.07 30413 犬飼 仕入明細データの仕入金額の設定を修正 <<<<<<END
                
                // 明細行数
                stockSlipWork.DetailRowCount++;

                // 既存の仕入データを削除してから追加
                this._stockSlipWorkDic.Remove(key);
                this._stockSlipWorkDic.Add(key, stockSlipWork);

                // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 >>>>>>START
                //// ワークリストに追加
                //this._stockSlipWorkList.Add(stockSlipWork);
                // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 <<<<<<END
        
                return;
            }            

            // 仕入先マスタのキャッシュを取得
            string keySupplier = (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
            if (_supplierDic.ContainsKey(keySupplier))
            {
                // キャッシュ有
                supplierWork = _supplierDic[keySupplier];
            }

            // 2009.01.07 30413 犬飼 未使用となったので削除 >>>>>>START
            //// UOE発注先マスタのキャッシュを取得
            //if (_uoeSupplierDic.ContainsKey(keySupplier))
            //{
            //    // キャッシュ有
            //    uoeSupplierWork = _uoeSupplierDic[keySupplier];
            //}
            // 2009.01.07 30413 犬飼 未使用となったので削除 <<<<<<END
            
            // 企業コード
            stockSlipWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // ログイン担当者の企業コード

            // 2008.12.25 30413 犬飼 仕入形式の値を修正 >>>>>>START
            // 仕入形式
            //stockSlipWork.SupplierFormal = 0;       // 0:発注
            stockSlipWork.SupplierFormal = 2;       // 2:発注
            // 2008.12.25 30413 犬飼 仕入形式の値を修正 <<<<<<END
            
            // 拠点コード
            stockSlipWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;        // ログイン担当者の拠点コード
            // 部門コード
            stockSlipWork.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);       // ログイン担当者の部門コード
            // 赤伝区分
            stockSlipWork.DebitNoteDiv = 0;     // 0:黒伝
            // 仕入伝票区分
            stockSlipWork.SupplierSlipCd = 10;  // 10:仕入
            // 仕入商品区分
            stockSlipWork.StockGoodsCd = 0;     // 0:商品
            // 買掛区分
            stockSlipWork.AccPayDivCd = 1;      // 1:買掛
            // 仕入拠点コード
            stockSlipWork.StockSectionCd = (string)dr[DCHAT02104EA.ct_Col_SectionCode];    // 抽出結果の拠点コード
            // 仕入計上拠点コード
            stockSlipWork.StockAddUpSectionCd = supplierWork.PaymentSectionCode;    // 仕入先マスタの支払拠点コード
            // 仕入伝票更新区分
            stockSlipWork.StockSlipUpdateCd = 0;    // 0:未更新
            // 入力日
            stockSlipWork.InputDay = orderListCndtn.ProcessDay;     // 抽出条件の処理日
            // 来勘区分
            stockSlipWork.DelayPaymentDiv = 0;      // 0:当月
            // 支払先コード
            stockSlipWork.PayeeCode = supplierWork.PayeeCode;   // 仕入先マスタの支払先コード
            // 支払先略称
            stockSlipWork.PayeeSnm = supplierWork.PayeeSnm;     // 仕入先マスタの支払先略称
            // 仕入先コード
            stockSlipWork.SupplierCd = int.Parse((string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint]);    // UOE発注データの仕入先コード
            // 仕入先名1
            stockSlipWork.SupplierNm1 = supplierWork.SupplierNm1;       // 仕入先マスタの仕入先名１
            // 仕入先名2
            stockSlipWork.SupplierNm2 = supplierWork.SupplierNm2;       // 仕入先マスタの仕入先名２
            // 仕入先略称
            stockSlipWork.SupplierSnm = supplierWork.SupplierSnm;       // 仕入先マスタの仕入先略称
            // 業種コード
            stockSlipWork.BusinessTypeCode = supplierWork.BusinessTypeCode;     // 仕入先マスタの業種コード
            // 業種名称
            stockSlipWork.BusinessTypeName = supplierWork.BusinessTypeName;     // 仕入先マスタの業種名
            // 販売エリアコード
            stockSlipWork.SalesAreaCode = supplierWork.SalesAreaCode;       // 仕入先マスタの地区コード
            // 販売エリア名称
            stockSlipWork.SalesAreaName = supplierWork.SalesAreaName;       // 仕入先マスタの地区名
            // 仕入入力者コード
            stockSlipWork.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;    // ログイン担当者コード
            // 仕入入力者名称
            stockSlipWork.StockInputName = GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode);    // ログイン担当者名

            // 2009.01.07 30413 犬飼 ログイン担当者に変更 >>>>>>START
            // 仕入担当者コード
            //stockSlipWork.StockAgentCode = uoeSupplierWork.EmployeeCode;    // UOE発注先マスタの従業員コード
            stockSlipWork.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;    // ログイン担当者コード
            // 仕入担当者名称
            //stockSlipWork.StockAgentName = GetEmployeeName(uoeSupplierWork.EmployeeCode);       // UOE発注先マスタの従業員名
            stockSlipWork.StockAgentName = GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode);    // ログイン担当者名
            // 2009.01.07 30413 犬飼 ログイン担当者に変更 <<<<<<END
            
            // 仕入先総額表示方法区分
            stockSlipWork.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd;       // 仕入先マスタの仕入先総額表示方法区分
            // 総額表示掛率適用区分
            stockSlipWork.TtlAmntDispRateApy = GetTtlAmntDspRateDivCd((string)dr[DCHAT02104EA.ct_Col_SectionCode]);     // 全体初期値設定マスタの総額表示掛率適用区分

            // 2009.01.07 30413 犬飼 仕入明細データの仕入金額の設定を修正 >>>>>>START
            // 仕入金額合計
            //stockSlipWork.StockTotalPrice = stockDetailWork.StockPriceTaxExc;       // 仕入明細データの仕入金額(税抜)合計
            stockSlipWork.StockTotalPrice = stockDetailWork.StockPriceTaxInc;       // 仕入明細データの仕入金額(税込)合計
            // 仕入金額小計
            //stockSlipWork.StockSubttlPrice = stockDetailWork.StockPriceTaxInc;      // 仕入明細データの仕入金額(税込)合計
            stockSlipWork.StockSubttlPrice = stockDetailWork.StockPriceTaxExc;      // 仕入明細データの仕入金額(税抜)合計
            // 2009.01.07 30413 犬飼 仕入明細データの仕入金額の設定を修正 <<<<<<END
            
            // 仕入先消費税転嫁方式コード
            stockSlipWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd;     // 仕入先マスタの仕入先消費税転嫁方式コード
            // 仕入先消費税税率
            stockSlipWork.SupplierConsTaxRate = _taxRate;   // 税率設定マスタの税率
            // 自動支払区分
            stockSlipWork.AutoPayment = 0;      // 0:通常支払
            // 明細行数
            stockSlipWork.DetailRowCount = 1;   // 新規追加の場合は初期値1

            // 仕入データキャッシュに追加
            this._stockSlipWorkDic.Add(key, stockSlipWork);

            // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 >>>>>>START
            //// ワークリストに追加
            //this._stockSlipWorkList.Add(stockSlipWork);
            // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 <<<<<<END
        
        }
        #endregion

        #region 仕入明細データの設定
        /// <summary>
        /// 仕入明細データの設定
        /// </summary>
        /// <param name="orderListCndtn">抽出条件データクラス</param>
        /// <param name="dr">抽出結果データ行</param>
        /// <param name="guid">UOE発注分関連付けGuid</param>
        /// <param name="stockDetailList">仕入明細データリスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注用の仕入明細データを作成。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void SetStockDetailWork(OrderListCndtn orderListCndtn, DataRow dr, Guid guid, ref ArrayList stockDetailList)
        {
            StockDetailWork stockDetailWork = new StockDetailWork();
            UOESupplier uoeSupplierWork = new UOESupplier();
            
            // 商品連結データの取得
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            string key = CreateKey_DataRow(dr);
            if (_goodsUnitDataDic.ContainsKey(key))
            {
                // 商品連結データキャッシュから取得
                goodsUnitData = _goodsUnitDataDic[key];
            }

            // 商品連結データの価格情報
            List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
            GoodsPrice goodsPrice = new GoodsPrice();
            if ((goodsPriceList != null) && (goodsPriceList.Count > 0))
            {
                goodsPrice = goodsPriceList[0];
            }

            // UOE発注先マスタのキャッシュを取得
            // 2009.01.07 30413 犬飼 拠点コードをキーに追加 >>>>>>START
            //string keySupplier = (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
            string keySupplier = ((string)dr[DCHAT02104EA.ct_Col_SectionCode]).TrimEnd() + "-" + (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
            // 2009.01.07 30413 犬飼 拠点コードをキーに追加 <<<<<<END
            
            if (_uoeSupplierDic.ContainsKey(keySupplier))
            {
                // キャッシュ有
                uoeSupplierWork = _uoeSupplierDic[keySupplier];
            }

            // 2009.02.10 30413 犬飼 仕入行番号の設定用 >>>>>>START
            int stockRowNo = 1;
            if (guid == Guid.Empty)
            {
                // UOE発注以外の場合、行番号を設定
                string keyStockDetai = (string)dr[DCHAT02104EA.ct_Col_SectionCode] + "-"
                                     + (string)dr[DCHAT02104EA.ct_Col_WarehouseCode] + "-"
                                     + (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
                ArrayList stockDetaiList = new ArrayList();
                if (_stockDetailDic.ContainsKey(keyStockDetai))
                {
                    stockDetaiList = _stockDetailDic[keyStockDetai];
                }
                stockRowNo = stockDetaiList.Count + 1;
            }
            // 2009.02.10 30413 犬飼 仕入行番号の設定用 ><<<<<<END
            
            // 企業コード
            stockDetailWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // ログイン担当者の企業コード
            // UOE発注分関連付けGUID
            if (guid != Guid.Empty)
            {
                stockDetailWork.DtlRelationGuid = guid;
            }
            // 仕入形式
            stockDetailWork.SupplierFormal = 2;     // 2:発注
            // 2009.02.10 30413 犬飼 仕入行番号の設定用 >>>>>>START
            // 仕入行番号
            stockDetailWork.StockRowNo = stockRowNo;
            // 2009.02.10 30413 犬飼 仕入行番号の設定用 <<<<<<END
            // 拠点コード
            stockDetailWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();        //　ログイン担当者の拠点コード
            // 部門コード
            stockDetailWork.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);     // ログイン担当者の部門コード
            // 仕入入力者コード
            stockDetailWork.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;    // ログイン担当者コード
            // 仕入入力者名称
            stockDetailWork.StockInputName = GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode);   // ログイン担当者名
            // 仕入担当者コード
            // 仕入担当者名称
            //if (uoeSupplierWork.EmployeeCode.Trim() != "")
            if (_uoeSupplierDic.ContainsKey(keySupplier))
            {
                // 2009.03.26 30413 犬飼 発注先マスタの依頼者コードが未設定の場合を考慮 >>>>>>START
                //stockDetailWork.StockAgentCode = uoeSupplierWork.EmployeeCode;      // 発注先マスタの依頼者コード
                //stockDetailWork.StockAgentName = GetEmployeeName(uoeSupplierWork.EmployeeCode);   // 発注先マスタの依頼者名
                if (uoeSupplierWork.EmployeeCode.Trim() != "")
                {
                    stockDetailWork.StockAgentCode = uoeSupplierWork.EmployeeCode;      // 発注先マスタの依頼者コード
                    stockDetailWork.StockAgentName = GetEmployeeName(uoeSupplierWork.EmployeeCode);   // 発注先マスタの依頼者名
                }
                else
                {
                    stockDetailWork.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;    // ログイン担当者コード
                    stockDetailWork.StockAgentName = GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode);   // ログイン担当者名
                }
                // 2009.03.26 30413 犬飼 発注先マスタの依頼者コードが未設定の場合を考慮 <<<<<<END
            }
            else
            {
                stockDetailWork.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;    // ログイン担当者コード
                stockDetailWork.StockAgentName = GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode);   // ログイン担当者名
            }
            // 商品属性
            stockDetailWork.GoodsKindCode = goodsUnitData.GoodsKindCode;    // 商品連結データの商品属性
            // 商品メーカーコード
            stockDetailWork.GoodsMakerCd = (int)dr[DCHAT02104EA.ct_Col_GoodsMakerCd];   // メーカーコード
            // メーカー名称
            stockDetailWork.MakerName = (string)dr[DCHAT02104EA.ct_Col_MakerName];      // メーカー名
            // メーカーカナ名称
            stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;    // 商品連結データのメーカーカナ名
            // 商品番号
            stockDetailWork.GoodsNo = (string)dr[DCHAT02104EA.ct_Col_GoodsNo];      // 品番
            // 商品名称
            stockDetailWork.GoodsName = (string)dr[DCHAT02104EA.ct_Col_GoodsName];      // 品名
            // 商品名称カナ
            stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;    // 商品連結データの品名カナ
            // 商品大分類コード
            stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;    //商品連結データの商品大分類コード
            // 商品大分類名称
            stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;    //商品連結データの商品大分類名
            // 商品中分類コード
            stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;    // 商品連結データの商品中分類コード
            // 商品中分類名称
            stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;    // 商品連結データの商品中分類名
            // BLグループコード
            stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;    // 商品連結データのBLグループコード
            // BLグループコード名称
            stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;    // 商品連結データのBLグループ名
            // BL商品コード
            stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;    // 商品連結データのBLコード
            // BL商品コード名称（全角）
            stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;    // 商品連結データのBL名称(全角)
            // 自社分類コード
            stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // 商品連結データの自社分類コード
            // 自社分類名称
            stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // 商品連結データの自社分類名
            // 倉庫コード
            stockDetailWork.WarehouseCode = (string)dr[DCHAT02104EA.ct_Col_WarehouseCode];      // 倉庫コード
            // 倉庫名称
            stockDetailWork.WarehouseName = (string)dr[DCHAT02104EA.ct_Col_WarehouseName];      // 倉庫名
            // 倉庫棚番
            stockDetailWork.WarehouseShelfNo = (string)dr[DCHAT02104EA.ct_Col_WarehouseShelfNo];    // 倉庫棚番
            // 仕入在庫取寄せ区分
            stockDetailWork.StockOrderDivCd = 1;    // 1:在庫
            // オープン価格区分
            stockDetailWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;     // 商品連結データの価格情報のオープン価格区分
            // 商品掛率ランク
            stockDetailWork.GoodsRateRank = goodsUnitData.GoodsRateRank;    // 商品連結データの商品掛率ランク

            // 単価算出モジュールから値を取得
            UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();
            this.CalculateUnitCost(dr, goodsUnitData, _taxRate, out unitPriceCalcRet);
#if true
            if (unitPriceCalcRet.UnPrcFracProcUnit == 0.0)
            {
                // 単位がゼロはプログラムが落ちるので
                unitPriceCalcRet.UnPrcFracProcUnit = 1.0;
            }
#endif

            // 定価算出
            double priceExe = goodsPrice.ListPrice;     // 商品連結データの価格情報の定価
            double priceInc;    // 定価(税込)
            double priceTax;    // 消費税(定価)
            CalculateTax.CalcTaxIncFromTaxExc(goodsUnitData.TaxationDivCd, ref priceExe, out priceInc, out priceTax, _taxRate, unitPriceCalcRet.UnPrcFracProcUnit, unitPriceCalcRet.UnPrcFracProcDiv);

            // 定価（税抜，浮動）           
            stockDetailWork.ListPriceTaxExcFl = goodsPrice.ListPrice;   // 商品連結データの価格情報の定価
            // 定価（税込，浮動）
            stockDetailWork.ListPriceTaxIncFl = priceInc;       // 単価算出モジュールの定価(税込)
            // 仕入率
            stockDetailWork.StockRate = goodsPrice.StockRate;       // 商品連結データの価格情報の仕入率
            // 掛率設定拠点（仕入単価）
            stockDetailWork.RateSectStckUnPrc = unitPriceCalcRet.SectionCode.TrimEnd();     // 単価算出結果クラスの拠点
            // 掛率設定区分（仕入単価）
            stockDetailWork.RateDivStckUnPrc = unitPriceCalcRet.RateSettingDivide;      // 単価算出結果クラスの掛率設定区分
            // 単価算出区分（仕入単価）
            stockDetailWork.UnPrcCalcCdStckUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;     // 単価算出結果クラスの単価算出区分
            // 価格区分（仕入単価）
            stockDetailWork.PriceCdStckUnPrc = unitPriceCalcRet.PriceDiv;       // 単価算出結果クラスの価格区分
            // 基準単価（仕入単価）
            stockDetailWork.StdUnPrcStckUnPrc = unitPriceCalcRet.StdUnitPrice;      // 単価算出結果クラスの基準単価
            // 端数処理単位（仕入単価）
            stockDetailWork.FracProcUnitStcUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;      // 単価算出結果クラスの端数処理単位
            // 端数処理（仕入単価）
            stockDetailWork.FracProcStckUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;      // 単価算出結果クラスの端数処理


            // 単価算出モジュールから仕入単価を取得
            double StockUnitPriceFl;
            double StockUnitTaxPriceFl;
            double StockUnitConsTax;
            CalculateTax.CalculatePrice(goodsUnitData.TaxationDivCd, unitPriceCalcRet.UnitPriceTaxExcFl, _taxRate, unitPriceCalcRet.UnPrcFracProcUnit, unitPriceCalcRet.UnPrcFracProcDiv,
                                        out StockUnitPriceFl, out StockUnitTaxPriceFl, out StockUnitConsTax);

            // 仕入単価（税抜，浮動）
            stockDetailWork.StockUnitPriceFl = StockUnitPriceFl;    // 単価算出モジュール結果の税抜
            // 仕入単価（税込，浮動）
            stockDetailWork.StockUnitTaxPriceFl = StockUnitTaxPriceFl;      // 単価算出モジュール結果の税込
            // 仕入単価変更区分
            stockDetailWork.StockUnitChngDiv = 0;   // 0:変更なし
            // 変更前仕入単価（浮動）
            stockDetailWork.BfStockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 単価算出結果クラスの単価（税抜，浮動）
            // 変更前定価
            stockDetailWork.BfListPrice = goodsPrice.ListPrice;   // 商品連結データの価格情報の定価
            // BL商品コード（掛率）
            stockDetailWork.RateBLGoodsCode = goodsUnitData.BLGoodsCode;    // 商品連結データのBLコード
            // BL商品コード名称（掛率）
            stockDetailWork.RateBLGoodsName = goodsUnitData.BLGoodsFullName;    // 商品連結データのBL名称(全角)
            // 商品掛率グループコード（掛率）
            stockDetailWork.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;    // 商品連結データの商品掛率グループコード
            // 商品掛率グループ名称（掛率）
            stockDetailWork.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;    // 商品連結データの商品掛率グループ名
            // BLグループコード（掛率）
            stockDetailWork.RateBLGroupCode = goodsUnitData.BLGroupCode;    // 商品連結データのBLグループコード
            // BLグループ名称（掛率）
            stockDetailWork.RateBLGroupName = goodsUnitData.BLGroupName;    // 商品連結データのBLグループ名

            // 2008.12.26 30413 犬飼 仕入数と発注調整数の設定追加、発注残数を未設定に変更 >>>>>>START
            // 2009.01.07 30413 犬飼 浮動小数に修正 >>>>>>START
            // 仕入数
            //stockDetailWork.StockCount = (int)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc];     // 計算後の発注数量
            stockDetailWork.StockCount = (double)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc];     // 計算後の発注数量
            // 発注数量
            //stockDetailWork.OrderCnt = (int)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc];     // 計算後の発注数量
            stockDetailWork.OrderCnt = (double)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc];     // 計算後の発注数量
            // 2009.01.07 30413 犬飼 浮動小数に修正 <<<<<<END
            // 発注調整数
            stockDetailWork.OrderAdjustCnt = 0;     // 発注数量-仕入数
            // 発注残数
            //stockDetailWork.OrderRemainCnt = (int)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc];     // 計算後の発注数量
            // 2008.12.26 30413 犬飼 仕入数と発注調整数の設定追加、発注残数を未設定に変更 <<<<<<END
            

            // 単価算出モジュールから仕入金額（税抜き）を取得
            long StockPriceTaxExc;
            long StockPriceTaxInc = (long)StockUnitTaxPriceFl;
            long StockPriceTax;
            CalculateTax.CalcTaxExcFromTaxInc(goodsUnitData.TaxationDivCd, out StockPriceTaxExc, ref StockPriceTaxInc, out StockPriceTax, _taxRate, unitPriceCalcRet.UnPrcFracProcUnit, unitPriceCalcRet.UnPrcFracProcDiv);

            // 2009.02.10 30413 犬飼 単価*仕入数に修正 >>>>>>START
            // 仕入金額（税抜き）
            //stockDetailWork.StockPriceTaxExc = StockPriceTaxExc;        // 単価算出モジュールの仕入金額（税抜き）
            stockDetailWork.StockPriceTaxExc = (long)(StockPriceTaxExc * stockDetailWork.StockCount);        // 単価算出モジュールの仕入金額（税抜き）* 仕入数
            // 2009.02.10 30413 犬飼 単価*仕入数に修正 <<<<<<END
            

            // 単価算出モジュールから仕入金額（税込み）を取得
            StockPriceTaxExc = (long)StockUnitPriceFl;
            StockPriceTaxInc = 0;
            StockPriceTax = 0;
            CalculateTax.CalcTaxIncFromTaxExc(goodsUnitData.TaxationDivCd, ref StockPriceTaxExc, out StockPriceTaxInc, out StockPriceTax, _taxRate, unitPriceCalcRet.UnPrcFracProcUnit, unitPriceCalcRet.UnPrcFracProcDiv);

            // 2009.02.10 30413 犬飼 単価*仕入数に修正 >>>>>>START
            // 仕入金額（税込み）
            //stockDetailWork.StockPriceTaxInc = StockPriceTaxInc;        // 単価算出モジュールの仕入金額（税込み）
            stockDetailWork.StockPriceTaxInc = (long)(StockPriceTaxInc * stockDetailWork.StockCount);        // 単価算出モジュールの仕入金額（税込み）* 仕入数
            // 2009.02.10 30413 犬飼 単価*仕入数に修正 <<<<<<END
            
            // 仕入商品区分
            stockDetailWork.StockGoodsCd = 0;   // 0:商品
            // 課税区分
            stockDetailWork.TaxationCode = goodsUnitData.TaxationDivCd;     // 商品連結データの課税区分

            // 2009.02.10 30413 犬飼 仕入先コードと仕入先略称の設定を修正 >>>>>>START
            //// 2009.01.20 30413 犬飼 発注マスタの仕入先コードを設定するように修正 >>>>>>START
            //// 仕入先コード
            ////stockDetailWork.SupplierCd = int.Parse((string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint]);   // 印刷対象の発注先(仕入先)コード
            //stockDetailWork.SupplierCd = uoeSupplierWork.SupplierCd;        // UOE発注先マスタの仕入先コード
            //// 仕入先略称
            //string supplierKey = uoeSupplierWork.SupplierCd.ToString("d06");
            //Supplier supplierWork = new Supplier();
            //if (_supplierDic.ContainsKey(supplierKey))
            //{
            //    supplierWork = _supplierDic[supplierKey];
            //}
            //stockDetailWork.SupplierSnm = supplierWork.SupplierSnm;         // UOE発注先マスタの仕入先コードの仕入先略称
            //// 2009.01.20 30413 犬飼 発注マスタの仕入先コードを設定するように修正 <<<<<<END
            Supplier supplierWork = new Supplier();
            if (guid != Guid.Empty)
            {
                // UOE発注データ
                // 仕入先コード
                stockDetailWork.SupplierCd = uoeSupplierWork.SupplierCd;        // UOE発注先マスタの仕入先コード
                // 仕入先略称
                string supplierKey = uoeSupplierWork.SupplierCd.ToString("d06");
                if (_supplierDic.ContainsKey(supplierKey))
                {
                    supplierWork = _supplierDic[supplierKey];
                }
                stockDetailWork.SupplierSnm = supplierWork.SupplierSnm;         // UOE発注先マスタの仕入先コードの仕入先略称
            }
            else
            {
                // UOE発注以外
                // 仕入先コード
                stockDetailWork.SupplierCd = int.Parse((string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint]);      // 仕入先コード
                // 仕入先略称
                string supplierKey2 = (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
                if (_supplierDic.ContainsKey(supplierKey2))
                {
                    supplierWork = _supplierDic[supplierKey2];
                }
                stockDetailWork.SupplierSnm = supplierWork.SupplierSnm;         // 仕入先マスタの仕入先コードの仕入先略称
            }
            // 2009.02.10 30413 犬飼 仕入先コードと仕入先略称の設定を修正 <<<<<<END
            
            // 2009.01.08 30413 犬飼 UOE発注分と以外で値を変更 >>>>>>START
            // 注文方法
            // 2008.12.25 30413 犬飼 注文方法の値を修正 >>>>>>START
            //stockDetailWork.WayToOrder = 2;     // 2:オンライン発注
            //stockDetailWork.WayToOrder = 0;     // 0:発注書発注
            if (_uoeSupplierDic.ContainsKey(keySupplier))
            {
                // UOE発注分
                stockDetailWork.WayToOrder = 2;     // 2:オンライン発注
            }
            else
            {
                // UOE発注分以外
                stockDetailWork.WayToOrder = 0;     // 0:発注書発注
            }
            // 2008.12.25 30413 犬飼 注文方法の値を修正 <<<<<<END
            // 2009.01.08 30413 犬飼 UOE発注分と以外で値を変更 <<<<<<END
            
            // 2008.12.25 30413 犬飼 発注データ作成区分を追加 >>>>>>START
            // 発注データ作成区分
            stockDetailWork.OrderDataCreateDiv = 4;     // 4：発注点割れ
            // 2008.12.25 30413 犬飼 発注データ作成区分を追加 <<<<<<END

            // 2008.12.18 30413 犬飼 発注データ作成日を追加 >>>>>>START
            // 発注データ作成日
            stockDetailWork.OrderDataCreateDate = DateTime.Parse(TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now));       // システム日付
            // 2008.12.18 30413 犬飼 発注データ作成日を追加 <<<<<<END

            // 発注書発行済区分
            stockDetailWork.OrderFormIssuedDiv = 0;     // 0:未発行
            
            // 仕入明細データリストに追加
            stockDetailList.Add(stockDetailWork);
        }
        #endregion

        #region UOE発注データの設定
        /// <summary>
        /// UOE発注データの設定
        /// </summary>
        /// <param name="orderListCndtn">抽出条件データクラス</param>
        /// <param name="dr">抽出結果データ行</param>
        /// <param name="guid">UOE発注分関連付けGuid</param>
        /// <param name="uoeList">UOE発注データリスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注用のUOE発注データを作成。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void SetUOEOrderDtlWork(OrderListCndtn orderListCndtn, DataRow dr, Guid guid, ref ArrayList uoeList)
        {
            UOEOrderDtlWork uoeOrderDtlWork = new UOEOrderDtlWork();
            UOESupplier uoeSupplierWork = new UOESupplier();

            // UOE発注先マスタのキャッシュを取得
            // 2009.01.07 30413 犬飼 拠点コードをキーに追加 >>>>>>START
            //string key = (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
            string key = ((string)dr[DCHAT02104EA.ct_Col_SectionCode]).TrimEnd() + "-" + (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
            // 2009.01.07 30413 犬飼 拠点コードをキーに追加 <<<<<<END
            
            if (_uoeSupplierDic.ContainsKey(key))
            {
                // キャッシュ有
                uoeSupplierWork = _uoeSupplierDic[key];
            }
            
            // 企業コード
            uoeOrderDtlWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // ログイン担当者の企業コード
            // UOE発注分関連付けGUID
            uoeOrderDtlWork.DtlRelationGuid = guid;
            // システム区分
            uoeOrderDtlWork.SystemDivCd = 3;    // 3:一括
            // UOE発注先コード
            uoeOrderDtlWork.UOESupplierCd = int.Parse((string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint]);   // 印刷対象の発注先(仕入先)コード
            // UOE発注先名称
            uoeOrderDtlWork.UOESupplierName = (string)dr[DCHAT02104EA.ct_Col_SupplierName];     // UOE発注先名称
            // 通信アセンブリID
            uoeOrderDtlWork.CommAssemblyId = uoeSupplierWork.CommAssemblyId;    // UOE発注先マスタの通信アセンブリID
            // 入力日
            uoeOrderDtlWork.InputDay = DateTime.Parse(TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now));       // システム日付
            // データ更新日付
            uoeOrderDtlWork.DataUpdateDateTime = DateTime.Now;      // システム日付・時刻
            // UOE種別
            uoeOrderDtlWork.UOEKind = 0;    // 0:UOE
            // 2009.01.08 30413 犬飼 受注ステータスをゼロに修正 >>>>>>START
            // 受注ステータス
            //uoeOrderDtlWork.AcptAnOdrStatus = 20;   // 20:受注
            uoeOrderDtlWork.AcptAnOdrStatus = 0;   // 0:発注一覧表はゼロ
            // 2009.01.08 30413 犬飼 受注ステータスをゼロに修正 <<<<<<END
            // 拠点コード
            uoeOrderDtlWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;      // ログイン担当者の拠点コード
            // 部門コード
            uoeOrderDtlWork.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);     // ログイン担当者の部門コード
            // レジ通番
            uoeOrderDtlWork.CashRegisterNo = GetCashRegisterNo();   // 端末管理マスタのレジ番号
            // 2009.01.08 30413 犬飼 仕入形式を追加 >>>>>>START
            // 仕入形式
            uoeOrderDtlWork.SupplierFormal = 2;     // 2:発注
            // 2009.01.08 30413 犬飼 仕入形式を追加 <<<<<<END
            // BO区分
            uoeOrderDtlWork.BoCode = uoeSupplierWork.BoCode;    // UOE発注先マスタのBO区分
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
            //// 納品区分
            //uoeOrderDtlWork.DeliveredGoodsDiv = uoeSupplierWork.DeliveredGoodsDiv;      // UOE発注先マスタの納品区分
            // UOE納品区分
            uoeOrderDtlWork.UOEDeliGoodsDiv = uoeSupplierWork.UOEDeliGoodsDiv;      // UOE発注先マスタのUOE納品区分
            //// 納品区分名称
            //uoeOrderDtlWork.DeliveredGoodsDivNm = GetDeliveredGoodsName(uoeSupplierWork.DeliveredGoodsDiv);     // UOE各種名称マスタから納品区分名称取得
            // UOE納品区分名称
            uoeOrderDtlWork.DeliveredGoodsDivNm = GetDeliveredGoodsName(uoeSupplierWork);     // UOE各種名称マスタから納品区分名称取得
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            // UOE指定拠点
            uoeOrderDtlWork.UOEResvdSection = uoeSupplierWork.UOEResvdSection.TrimEnd();      // UOE発注先マスタのUOE指定拠点コード
            // UOE指定拠点名称
            uoeOrderDtlWork.UOEResvdSectionNm = GetSectionNm(uoeSupplierWork.UOEResvdSection.TrimEnd());    // 拠点名称
            // 従業員コード
            uoeOrderDtlWork.EmployeeCode = uoeSupplierWork.EmployeeCode;    // UOE発注先マスタの従業員コード
            // 従業員名称
            uoeOrderDtlWork.EmployeeName = GetEmployeeName(uoeSupplierWork.EmployeeCode);   // UOE発注先マスタの従業員名
            // 商品メーカーコード
            uoeOrderDtlWork.GoodsMakerCd = (int)dr[DCHAT02104EA.ct_Col_GoodsMakerCd];   // メーカーコード
            // メーカー名称
            uoeOrderDtlWork.MakerName = (string)dr[DCHAT02104EA.ct_Col_MakerName];      // メーカー名
            // 商品番号
            uoeOrderDtlWork.GoodsNo = (string)dr[DCHAT02104EA.ct_Col_GoodsNo];      // 品番
            // ハイフン無商品番号
            string workGoodsNoNoneHyphen = uoeOrderDtlWork.GoodsNo.Replace("-", "");
            uoeOrderDtlWork.GoodsNoNoneHyphen = workGoodsNoNoneHyphen;      // ハイフン無品番
            // 商品名称
            uoeOrderDtlWork.GoodsName = (string)dr[DCHAT02104EA.ct_Col_GoodsName];      // 品名
            // 倉庫コード
            uoeOrderDtlWork.WarehouseCode = (string)dr[DCHAT02104EA.ct_Col_WarehouseCode];      // 倉庫コード
            // 倉庫名称
            uoeOrderDtlWork.WarehouseName = (string)dr[DCHAT02104EA.ct_Col_WarehouseName];      // 倉庫名
            // 倉庫棚番
            uoeOrderDtlWork.WarehouseShelfNo = (string)dr[DCHAT02104EA.ct_Col_WarehouseShelfNo];    // 倉庫棚番

            // 2009.01.07 30413 犬飼 浮動小数に修正 >>>>>>START
            // 受注数量
            //uoeOrderDtlWork.AcceptAnOrderCnt = (int)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc]; // 受注数
            uoeOrderDtlWork.AcceptAnOrderCnt = (double)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc]; // 受注数
            // 2009.01.07 30413 犬飼 浮動小数に修正 <<<<<<END
            

            //仕入明細データの取得
            StockDetailWork stockDetailWork = (StockDetailWork)_stockDetailUOEList[_stockDetailUOEList.Count - 1];
            
            // 定価(浮動)
            uoeOrderDtlWork.ListPrice = stockDetailWork.ListPriceTaxExcFl;      // 仕入明細データの定価(税抜、浮動)
            // 原価単価
            uoeOrderDtlWork.SalesUnitCost = stockDetailWork.StockUnitPriceFl;       // 仕入明細データの仕入単価(税抜、浮動)

            // 2009.01.15 30413 犬飼 仕入先の設定を変更 >>>>>>START
            // 仕入先コード
            //uoeOrderDtlWork.SupplierCd = uoeSupplierWork.UOESupplierCd;         // UOE発注先マスタの仕入先コード
            uoeOrderDtlWork.SupplierCd = uoeSupplierWork.SupplierCd;        // UOE発注先マスタの仕入先コード
            // 仕入先略称
            //uoeOrderDtlWork.SupplierSnm = uoeSupplierWork.UOESupplierName;      // UOE発注先マスタの仕入先名
            string supplierKey = uoeSupplierWork.SupplierCd.ToString("d06");
            Supplier supplierWork = new Supplier();
            if (_supplierDic.ContainsKey(supplierKey))
            {
                supplierWork = _supplierDic[supplierKey];
            }
            uoeOrderDtlWork.SupplierSnm = supplierWork.SupplierSnm;         // UOE発注先マスタの仕入先コードの仕入先略称
            // 2009.01.15 30413 犬飼 仕入先の設定を変更 <<<<<<END
            
            // UOEリマーク１
            //uoeOrderDtlWork.UoeRemark1 = _uoeSetting.StockBlnktRemark;      // UOE自社マスタの在庫一括補充リマーク    // DEL 2009/06/09
            uoeOrderDtlWork.UoeRemark1 = this.GetRemark(orderListCndtn, uoeOrderDtlWork);   // ADD 2009/06/09
            // データ送信区分
            uoeOrderDtlWork.DataSendCode = 0;   // 0:未処理           
            
            // UOE発注データリストに追加
            uoeList.Add(uoeOrderDtlWork);            
        }
        #endregion

        #region 発注データ更新処理
        /// <summary>
        /// 発注データ更新処理
        /// </summary>
        /// <param name="blanketStockInputDataDiv">一括仕入入力ﾃﾞｰﾀ作成区分</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注データの更新処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// <br>UpdateNote : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : 2017/09/14</br>
        /// </remarks>
        public int UpdateOrderDate(int blanketStockInputDataDiv)
        {
            int status = -1;

            CustomSerializeArrayList csList = new CustomSerializeArrayList();
            object objList;

            // 2009.01.07 30413 犬飼 拠点・倉庫・仕入先単位で作成するため、発注データ用仕入データをディクショナリー化 >>>>>>START
            // UOE発注分以外のリストを作成
            if (blanketStockInputDataDiv == 0)
            {
                //for (int i = 0; i < _stockSlipList.Count; i++)
                foreach(string key in _stockSlipDic.Keys)
                {
                    CustomSerializeArrayList stockCSList = new CustomSerializeArrayList();
                    ArrayList stockDetailWorkList = new ArrayList();
                    //StockSlipWork stockSlipWork = (StockSlipWork)_stockSlipList[i];
                    StockSlipWork stockSlipWork = _stockSlipDic[key];

                    // 仕入データを追加
                    stockCSList.Add(stockSlipWork);

                    //string key = stockSlipWork.StockSectionCd + "-" + stockSlipWork.SupplierCd.ToString("d06");
                    if(_stockDetailDic.ContainsKey(key))
                    {
                        stockDetailWorkList = _stockDetailDic[key];
                        // UOE発注分以外の仕入明細データ
                        stockCSList.Add(stockDetailWorkList);
                    }
                    csList.Add(stockCSList);
                }
            }
            // 2009.01.07 30413 犬飼 拠点・倉庫・仕入先単位で作成するため、発注データ用仕入データをディクショナリー化 <<<<<<END
        
            if (_uoeOrderDtlList.Count != 0)
            {
                // UOE発注データ
                csList.Add(_uoeOrderDtlList);

                // UOE発注分の仕入明細データ
                csList.Add(_stockDetailUOEList);
            }

            if (csList.Count != 0)
            {
                // オブジェクトに発注データをセット
                objList = csList;

                // 更新処理
                status = this._iOrderListRenewWorkDB.Write(ref objList, 0, ConstantManagement.LogicalMode.GetData0);

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード表示する場合
                if (this._barCodeShowDiv)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blanketStockInputDataDiv == 0)
                    {
                        StockDetailWork stockDetailWork = null;
                        StockSlipWork stockSlipWork = null;
                        string key = string.Empty;
                        string warehouseCodeKey = string.Empty;
                        string sectionCodeKey = string.Empty;
                        string supplierCodeKey = string.Empty;
                        ArrayList palamList = objList as ArrayList;
                        for (int i = 0; i < palamList.Count; i++)
                        {
                            if ((object)palamList[i] is CustomSerializeArrayList)
                            {
                                CustomSerializeArrayList list = (CustomSerializeArrayList)palamList[i];
                                foreach (object obj in list)
                                {
                                    if (obj is StockSlipWork)
                                    {
                                        stockSlipWork = (StockSlipWork)obj;
                                        sectionCodeKey = stockSlipWork.StockSectionCd;
                                        // 仕入先コード(先頭0で6桁補足)
                                        supplierCodeKey = stockSlipWork.SupplierCd.ToString("d06");
                                        continue;
                                    }
                                    if (obj is ArrayList)
                                    {
                                        ArrayList arraylist = (ArrayList)obj;
                                        foreach (object subObj in arraylist)
                                        {
                                            if (subObj is StockDetailWork)
                                            {
                                                stockDetailWork = (StockDetailWork)subObj;
                                                warehouseCodeKey = stockDetailWork.WarehouseCode;
                                                continue;
                                            }
                                        }
                                    }
                                }
                                // stockSlipDicのkey:引数.仕入データの拠点コード+ "-" + 引数.仕入明細データの倉庫コード+ "-" + 引数.仕入データの仕入先コード(先頭0で6桁補足)
                                key = sectionCodeKey.Trim() + Hyphen + warehouseCodeKey + Hyphen + supplierCodeKey;
                                if (!this.StockSlipDic.ContainsKey(key) && stockSlipWork != null)
                                {
                                    this.StockSlipDic.Add(key, stockSlipWork.SupplierSlipNo.ToString());
                                }
                            }
                            warehouseCodeKey = string.Empty;
                            sectionCodeKey = string.Empty;
                            supplierCodeKey = string.Empty;
                            key = string.Empty;
                            stockDetailWork = null;
                            stockSlipWork = null;
                        }
                    }
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }
            else
            {
                // 発注件数0件は処理しない
                status = 0;
            }

            return status;
        }
        #endregion

        #endregion

        #region 商品アクセスクラス(商品管理情報取得)
        /// <summary>
        /// 商品アクセスクラス(商品管理情報取得)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データクラス</param>
        /// <param name="autoOrderResultWork">抽出結果データクラス</param>
        /// <remarks>
        /// <br>Note       : 商品管理情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void GetGoodsMngInfo(ref GoodsUnitData goodsUnitData, AutoOrderResultWork autoOrderResultWork)
        {
            // 抽出条件設定
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // 企業コード
            goodsUnitData.SectionCode = autoOrderResultWork.SectionCode;            // 拠点コード
            goodsUnitData.GoodsMakerCd = autoOrderResultWork.GoodsMakerCd;          // メーカーコード
            goodsUnitData.GoodsNo = autoOrderResultWork.GoodsNo;                    // 品番
            goodsUnitData.BLGoodsCode = autoOrderResultWork.BLGoodsCode;            // BLコード

            // -- UPD 2010/06/09 ----------------------------------->>>
            //BLコードマスタ取得
            BLGoodsCdUMnt bLGoodsCdUMnt;
            _goodsAcs.GetBLGoodsCd(autoOrderResultWork.BLGoodsCode, out bLGoodsCdUMnt);

            //BLグループコードマスタ取得
            BLGroupU bLGroupU = null;
            if (bLGoodsCdUMnt != null)
            {
                _goodsAcs.GetBLGroup(goodsUnitData.EnterpriseCode, bLGoodsCdUMnt.BLGloupCode, out bLGroupU);
            }

            //中分類セット
            if (bLGroupU != null)
            {
                goodsUnitData.GoodsMGroup = bLGroupU.GoodsMGroup;
            }
            // -- UPD 2010/06/09 -----------------------------------<<<

            // 商品管理情報の取得
            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
        }
        #endregion

        #region 商品アクセスクラス(結合検索無し完全一致)
        /// <summary>
        /// 商品アクセスクラス(結合検索無し完全一致)
        /// </summary>
        /// <param name="goodsCndtnList">商品抽出条件クラスリスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 結合検索無し完全一致で商品情報リストを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int GoodsRead(List<GoodsCndtn> goodsCndtnList)
        {
            int status = -1;
            string msg;
            List<List<GoodsUnitData>> goodsUnitDataListList;

            // 2009/09/14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 商品連結データローカルキャッシュをクリア
            //_goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            // 2009/09/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 結合検索無し完全一致で商品情報を取得
            status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            if ((goodsUnitDataListList != null) && (goodsUnitDataListList.Count != 0))
            {
                for (int i = 0; i < goodsUnitDataListList.Count; i++)
                {
                    List<GoodsUnitData> goodsUnitDataList = goodsUnitDataListList[i];

                    for (int j = 0; j < goodsUnitDataList.Count; j++)
                    {
                        GoodsUnitData goodsUnitData = goodsUnitDataList[j];
                        string key = CreateKey_GoodsUnitData(goodsUnitData);
                        if (_goodsUnitDataDic.ContainsKey(key))
                        {
                            // 同一商品が存在している場合は削除
                            _goodsUnitDataDic.Remove(key);
                        }
                        _goodsUnitDataDic.Add(key, goodsUnitData);
                    }
                }
            }

            return status;
        }

        // 2009/09/14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 商品アクセスクラス(結合検索無し完全一致)
        /// </summary>
        /// <param name="goodsCndtn"></param>
        /// <returns></returns>
        private GoodsUnitData GoodsRead(GoodsCndtn goodsCndtn)
        {
            int status = -1;
            string msg;
            List<GoodsUnitData> goodsUnitDataList;

            // 結合検索無し完全一致で商品情報を取得
            status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out msg);
            if (( goodsUnitDataList != null ) && ( goodsUnitDataList.Count != 0 ))
            {
                for (int j = 0; j < goodsUnitDataList.Count; j++)
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[j];
                    string key = CreateKey_GoodsUnitData(goodsUnitData);
                    if (_goodsUnitDataDic.ContainsKey(key))
                    {
                        // 同一商品が存在している場合は削除
                        _goodsUnitDataDic.Remove(key);
                    }
                    _goodsUnitDataDic.Add(key, goodsUnitData);
                }
                //} // 2009/10/16 Del
                return goodsUnitDataList[0];
            // 2009/10/16 Add >>>
            }
            else
            {
                return null;
            }
            // 2009/10/16 Add <<<
        }
        // 2009/09/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region 商品連結データのローカルキャッシュ用キー作成(商品連結データ)
        /// <summary>
        /// 商品連結データのローカルキャッシュ用キー作成(商品連結データ)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データのローカルキャッシュ用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private string CreateKey_GoodsUnitData(GoodsUnitData goodsUnitData)
        {
            // メーカーコード＋品番
            string key = goodsUnitData.GoodsMakerCd.ToString("d04") + "-" + goodsUnitData.GoodsNo;
            return key;
        }
        #endregion

        #region 商品連結データのローカルキャッシュ用キー作成(抽出結果データ行)
        /// <summary>
        /// 商品連結データのローカルキャッシュ用キー作成(抽出結果データ行)
        /// </summary>
        /// <param name="dr">抽出結果データ行</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データのローカルキャッシュ用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private string CreateKey_DataRow(DataRow dr)
        {
            // メーカーコード＋品番
            string key = ((int)dr[DCHAT02104EA.ct_Col_GoodsMakerCd]).ToString("d04") + "-" + (string)dr[DCHAT02104EA.ct_Col_GoodsNo];
            return key;
        }
        #endregion

        #region 拠点情報(拠点アクセスクラス)
        /// <summary>
        /// 拠点情報(拠点アクセスクラス)
        /// </summary>
        /// <param name="secInfoSet">拠点情報クラス</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 拠点アクセスクラスから拠点情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int SectionRead(out SecInfoSet secInfoSet, string sectionCode)
        {
            int status = -1;

            // 拠点情報の取得
            // ----DEL donggy 2012/11/27 --------->>>>>>>> 
            //status = this._secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    secInfoSet = new SecInfoSet();
            //}
            // ----DEL donggy 2012/11/27 ---------<<<<<<<<< 
            //-----ADD donggy 2012/11/27---------->>>>>>>>>>>>>
            secInfoSet = new SecInfoSet();
            sectionCode = sectionCode.PadLeft(2, '0');
            sectionCode = sectionCode.PadRight(6, ' ');
            if (this.secInfoSetDic.ContainsKey(sectionCode))
            {
                secInfoSet = this.secInfoSetDic[sectionCode];
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            //-----ADD donggy 2012/11/27---------<<<<<<<<<<<<<
            return status;

        }
        #endregion

        //----ADD donggy 2012/11/27------>>>>>>
        #region 拠点情報一括取得(拠点アクセスクラス)
        /// <summary>
        /// 拠点情報(拠点アクセスクラス)
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 拠点アクセスクラスから拠点情報を一括取得します。</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 2012/11/27</br>
        /// </remarks>
        private void SectionReadAll()
        {
            SecInfoSet[] secInfoSets = this._secInfoAcs.SecInfoSetList;
            this.secInfoSetDic = new Dictionary<string, SecInfoSet>();
            foreach (SecInfoSet sis in secInfoSets)
            {
                this.secInfoSetDic.Add(sis.SectionCode, sis);
            }
        }
        #endregion
        //----ADD donggy 2012/11/27-----<<<<<<



        #region 拠点名称取得
        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>SectionNm</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報から拠点名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private string GetSectionNm(string sectionCode)
        {
            int status = -1;
            string SectionNm = "";
            SecInfoSet secInfoSet;

            // 拠点情報の取得
            status = SectionRead(out secInfoSet, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 拠点名称取得
                SectionNm = secInfoSet.SectionGuideNm;
            }

            return SectionNm;
        }
        #endregion

        #region 従業員アクセスクラス(Read)
        /// <summary>
        /// 従業員アクセスクラス(Read)
        /// </summary>
        /// <param name="employee">従業員情報クラス</param>
        /// <param name="employeeDtl">従業員詳細情報クラス</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 従業員アクセスクラスから従業員情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int EmployeeRead(out Employee employee, out EmployeeDtl employeeDtl, string employeeCode)
        {
            int status = -1;
            // ----DEL donggy 2012/11/27 --------->>>>>>>>
            // 従業員情報の取得
            //status = this._employeeAcs.Read(out employee, out employeeDtl, LoginInfoAcquisition.EnterpriseCode, employeeCode);
            //if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) || ((employee == null) && (employeeDtl == null)))
            //{
            //    // 従業員情報が取得できない
            //    employee = new Employee();
            //    employeeDtl = new EmployeeDtl();
            //}
            // ----DEL donggy 2012/11/27 ---------<<<<<<<<<<
            // ----ADD donggy 2012/11/27 --------->>>>>>>>
            employee = new Employee();
            employeeDtl = new EmployeeDtl();
            if (this.employeeDic.ContainsKey(employeeCode))
            {
                employee = employeeDic[employeeCode];
            }
            else
            {
                return status;
            }
            if (this.employeeDtlDic.ContainsKey(employeeCode))
            {
                employeeDtl = employeeDtlDic[employeeCode];
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                return status;
            }
            //----ADD donggy 2012/11/27 ---------<<<<<<<<<<
            return status;
        }
        #endregion


        //-----ADD donggy 2012/11/27----->>>>>>>>>>
        #region 従業員情報一括取得
        /// <summary>
        /// 従業員アクセスクラス(Read)
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 従業員アクセスクラスから従業員情報を取得します。</br>
        /// <br>Programmer :  donggy</br>
        /// <br>Date       : 2012/11/27</br>
        /// </remarks>
        private int EmployeeReadAll()
        {
            int status = -1;
            ArrayList employeeList = new ArrayList();
            ArrayList employeeDtlList = new ArrayList();

            this.employeeDic = new Dictionary<string, Employee>();
            this.employeeDtlDic = new Dictionary<string, EmployeeDtl>();
            status = this._employeeAcs.SearchAll(out employeeList, out employeeDtlList, LoginInfoAcquisition.EnterpriseCode);
            for (int i = 0; i < employeeList.Count; i++)
            {
                Employee emp = employeeList[i] as Employee;
                if (!this.employeeDic.ContainsKey(emp.EmployeeCode))
                {
                    this.employeeDic.Add(emp.EmployeeCode, emp);
                }
            }
            for (int i = 0; i < employeeDtlList.Count; i++)
            {
                EmployeeDtl empDtl = employeeDtlList[i] as EmployeeDtl;
                if (!this.employeeDtlDic.ContainsKey(empDtl.EmployeeCode))
                {
                    this.employeeDtlDic.Add(empDtl.EmployeeCode, empDtl);
                }
            }
            return status;
        }
        #endregion
        //-----ADD donggy 2012/11/27-----<<<<<<<<<<
        #region 部門コード取得
        /// <summary>
        /// 部門コード取得
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>subSectionCode</returns>
        /// <remarks>
        /// <br>Note       : 従業員詳細情報から部門コードを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int GetSubSectionCode(string employeeCode)
        {
            int status = -1;
            int subSectionCode = 0;
            Employee employee;
            EmployeeDtl employeeDtl;

            // 従業員情報取得
            status = EmployeeRead(out employee, out employeeDtl, employeeCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 部門コードを取得
                subSectionCode = employeeDtl.BelongSubSectionCode;
            }

            return subSectionCode;
        }
        #endregion

        #region 従業員名称取得
        /// <summary>
        /// 従業員名称取得
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>EmployeeName</returns>
        /// <remarks>
        /// <br>Note       : 従業員情報から従業員名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            int status = -1;
            string EmployeeName = "";
            Employee employee;
            EmployeeDtl employeeDtl;

            // 従業員情報取得
            status = EmployeeRead(out employee, out employeeDtl, employeeCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 従業員名称を取得
                if (employee.Name.Length > 16)
                {
                    // 16桁で切り捨て
                    EmployeeName = employee.Name.Substring(0, 16);
                }
                else
                {
                    EmployeeName = employee.Name;
                }
            }

            return EmployeeName;
        }
        #endregion

        #region 全体初期値設定アクセスクラス(Read)
        /// <summary>
        /// 全体初期値設定アクセスクラス(Read)
        /// </summary>
        /// <param name="allDefSet">全体初期値情報クラス</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定アクセスクラスから全体初期値情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int AllDefSetRead(out AllDefSet allDefSet, string sectionCode)
        {
            int status = -1;

            // 全体初期値情報を取得
            //----- DEL donggy 2012/11/27 -------->>>>>>>>>>>
            //status = this._allDefSetAcs.Read(out allDefSet, LoginInfoAcquisition.EnterpriseCode, sectionCode);
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    allDefSet = new AllDefSet();
            //}
            //----- DEL donggy 2012/11/27 --------<<<<<<<<<<<<<

            //------- ADD donggy 2012/11/27--------->>>>>>>>>
            allDefSet = new AllDefSet();
            if (this.allDefSetDic.ContainsKey(sectionCode))
            {
                allDefSet = allDefSetDic[sectionCode];
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            //------- ADD donggy 2012/11/27----------<<<<<<<<
            return status;            
        }
        #endregion

        //---- ADD donggy 2012/11/27------->>>>>>>>>>>>>>
        #region 全体初期値情報一括取得
        /// <summary>
        /// 全体初期値設定アクセスクラス(Read)
        /// </summary>
        /// <param name="allDefSet">全体初期値情報クラス</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定アクセスクラスから全体初期値情報を取得します。</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 20012/11/27</br>
        /// </remarks>
        private int AllDefSetReadAll()
        {
            int status = -1;
            ArrayList allDefSetList = null;
            this.allDefSetDic = new Dictionary<string, AllDefSet>();
            status = this._allDefSetAcs.SearchAll(out allDefSetList, LoginInfoAcquisition.EnterpriseCode);
            AllDefSet allDefSet = null;
            for (int i = 0; i < allDefSetList.Count; i++)
            {
                allDefSet = allDefSetList[i] as AllDefSet;
                if (!this.allDefSetDic.ContainsKey(allDefSet.SectionCode))
                {
                    this.allDefSetDic.Add(allDefSet.SectionCode, allDefSet);
                }
            }
            return status;
        }
        #endregion
        //---- ADD donggy 2012/11/27-------<<<<<<<<<<<<<<

        #region 総額表示掛率適用区分(全体初期値設定マスタ)
        /// <summary>
        /// 総額表示掛率適用区分(全体初期値設定マスタ)
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値情報から総額表示掛率適用区分を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int GetTtlAmntDspRateDivCd(string sectionCode)
        {
            int status = -1;
            int TtlAmntDspRateDivCd = 0;
            AllDefSet allDefSet;

            // 全体初期値情報取得
            status = AllDefSetRead(out allDefSet, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 総額表示掛率適用区分を取得
                TtlAmntDspRateDivCd = allDefSet.TtlAmntDspRateDivCd;
            }

            return TtlAmntDspRateDivCd;
        }
        #endregion

        #region 税率設定マスタアクセスクラス(Read)
        /// <summary>
        /// 税率設定マスタアクセスクラス(Read)
        /// </summary>
        /// <param name="taxRateSet">税率設定情報クラス</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタアクセスクラスから税率設定情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int TaxRateSetRead(out TaxRateSet taxRateSet)
        {
            int status = -1;

            // 税率設定情報を取得
            status = this._taxRateSetAcs.Read(out taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                taxRateSet = new TaxRateSet();
            }
            return status;
        }
        #endregion

        #region 税率取得(税率設定マスタ)
        /// <summary>
        /// 税率取得(税率設定マスタ)
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        /// <remarks>
        /// <br>Note       : 税率取得情報から税率を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private double GetTaxRate(TaxRateSet taxRateSet, DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }        
        #endregion

        #region 端末管理マスタアクセスクラス(Search)
        /// <summary>
        /// 端末管理マスタアクセスクラス(Search)
        /// </summary>
        /// <param name="posTerminalMg">端末管理情報クラス</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 端末管理マスタアクセスクラスから端末管理情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int PosTerminalMgSearch(out PosTerminalMg posTerminalMg)
        {
            int status = -1;

            // 端末管理情報を取得
            status = this._posTerminalMgAcs.Search(out posTerminalMg, LoginInfoAcquisition.EnterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                posTerminalMg = new PosTerminalMg();
            }
            return status;
        }
        #endregion

        #region レジ通番取得(端末管理マスタ)
        /// <summary>
        /// レジ通番取得(端末管理マスタ)
        /// </summary>
        /// <returns>CashRegisterNo</returns>
        /// <remarks>
        /// <br>Note       : 端末管理情報からレジ通番を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int GetCashRegisterNo()
        {
            //int status = -1;//DEL donggy 2012/11/27
            int CashRegisterNo = 0;
            //-------DEL donggy 2012/11/27------>>>>>>>>
            //PosTerminalMg posTerminalMg;

            //// 端末管理情報取得
            //status = PosTerminalMgSearch(out posTerminalMg);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // レジ通番を取得
            //    CashRegisterNo = posTerminalMg.CashRegisterNo;
            //}
            //-------DEL donggy 2012/11/27-------<<<<<<<
            //-------ADD donggy 2012/11/27-------<<<<<<<
            if (this.posTerminalMg.UpdEmployeeCode != string.Empty)
            {
                CashRegisterNo = this.posTerminalMg.CashRegisterNo;
            }
            //-------ADD donggy 2012/11/27------->>>>>>>>>
            return CashRegisterNo;
        }
        #endregion

        #region 納品区分名称取得
        /// <summary>
        /// UOE納品区分名称取得(UOE各種名称マスタアクセスクラス)
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先マスタデータ</param>
        /// <returns>guidName</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドアクセスクラスから納品区分名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private string GetDeliveredGoodsName(UOESupplier uoeSupplier)
        {
            //int status = -1;//DEL donggy 2012/11/27
            string guidName = "";
            //UOEGuideName uoeGuideName;//DEL donggy 2012/11/27

            // UOE納品区分名称を取得
            //--------- DEL donggy 2012/11/27---------->>>>>>>>>>
            //status = this._uoeGuideNameAcs.Read(out uoeGuideName, uoeSupplier.EnterpriseCode, 2, uoeSupplier.UOESupplierCd, uoeSupplier.UOEDeliGoodsDiv, uoeSupplier.SectionCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    guidName = uoeGuideName.UOEGuideNm;
            //}
            // ----- DEL donggy 2012/11/27--------<<<<<<<<<<<

            // ---- ADD donggy 2012/11/27----->>>>>>>>>>>>>>
            string key = uoeSupplier.SectionCode + "-" + uoeSupplier.UOESupplierCd + "-" + uoeSupplier.UOEDeliGoodsDiv;
            if (this.uoeGuideNameDic.ContainsKey(key))
            {
                guidName = this.uoeGuideNameDic[key].UOEGuideNm;
            }

            // -----ADD donggy 2012/11/27------<<<<<<<<<<<<<<<


            return guidName;
        }
        #endregion


        #region 原価単価計算処理(単価算出モジュール)
        /// <summary>
        /// 初期データ設定処理(単価算出モジュール)
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 単価算出モジュールの初期データを設定をします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void ReadInitData()
        {
            int status = -1;
            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList returnStockProcMoney;
            
            // 仕入金額データの取得
            status = stockProcMoneyAcs.Search(out returnStockProcMoney, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                {                    
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            // 仕入金額端数処理区分設定マスタキャッシュ処理
            _unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// 原価単価計算処理(単価算出モジュール)
        /// </summary>
        /// <param name="dr">抽出結果データ行</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="taxRate">税率</param>
        /// <param name="unitPriceCalcRet">単価計算結果</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 原価単価計算を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void CalculateUnitCost(DataRow dr, GoodsUnitData goodsUnitData, double taxRate, out UnitPriceCalcRet unitPriceCalcRet)
        {
            // 仕入先マスタのキャッシュを取得
            Supplier supplierWork = new Supplier();
            string keySupplier = (string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint];
            if (_supplierDic.ContainsKey(keySupplier))
            {
                // キャッシュ有
                supplierWork = _supplierDic[keySupplier];
            }

            List<UnitPriceCalcRet> unitPriceCalcRetList;            
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcRet = new UnitPriceCalcRet();

            // パラメータ設定
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = (int)dr[DCHAT02104EA.ct_Col_GoodsMakerCd];                // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = (string)dr[DCHAT02104EA.ct_Col_GoodsNo];                       // 品番
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                       // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = int.Parse((string)dr[DCHAT02104EA.ct_Col_SupplierCodePrint]);   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                           // 価格適用日
            
            // 2009.01.07 30413 犬飼 浮動小数に修正 >>>>>>START
            //unitPriceCalcParam.CountFl = Math.Abs((int)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc]); // 数量
            unitPriceCalcParam.CountFl = Math.Abs((double)dr[DCHAT02104EA.ct_Col_SalesOrderCountLotCalc]); // 数量
            // 2009.01.07 30413 犬飼 浮動小数に修正 <<<<<<END
            
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = taxRate;                                                       // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード

            // 原価単価計算処理
            _unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // 原価単価を取得
                    unitPriceCalcRet = unitPriceCalcRetWk;
                    return;
                }
            }
        }
        #endregion


        #region 仕入先マスタのローカルキャッシュ
        /// <summary>
        /// 仕入先マスタのローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先マスタのローカルキャッシュを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void CacheSupplierData()
        {
            int status;
            ArrayList retList;

            // 仕入先マスタのローカルキャッシュをクリア
            _supplierDic = new Dictionary<string, Supplier>();

            // 仕入先マスタの取得
            status = this._supplierAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Supplier supplierWork in retList)
                {
                    if (supplierWork.LogicalDeleteCode == 0)
                    {
                        string key = supplierWork.SupplierCd.ToString("d06");
                        if (_supplierDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            _supplierDic.Remove(key);
                        }
                        _supplierDic.Add(key, supplierWork);
                    }
                }
            }
        }
        #endregion

        #region UOE自社マスタのローカルキャッシュ
        /// <summary>
        /// UOE自社マスタのローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE自社マスタのローカルキャッシュを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void CacheUOESettingData()
        {
            int status;

            // UOE自社マスタの取得
            status = this._uoeSettingAcs.Read(out _uoeSetting, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd());
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得失敗
                _uoeSetting = new UOESetting();
            }
        }
        #endregion

        #region UOE発注先マスタのローカルキャッシュ
        /// <summary>
        /// UOE発注先マスタのローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタのローカルキャッシュを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void CacheUOESupplierData()
        {
            int status;
            ArrayList retList;

            // UOE発注先マスタのローカルキャッシュをクリア
            _uoeSupplierDic = new Dictionary<string, UOESupplier>();

            // UOE発注先マスタの取得
            status = this._uoeSupplierAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode, "");
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                UOEGuideName uoeGuideName = null;//ADD donggy 2012/11/27;
                ArrayList uoeGuideNameList = null;//ADD donggy 2012/11/27;
                Dictionary<string, string> sectionCodeDic = new Dictionary<string, string>();//ADD donggy 2012/11/27;

                foreach (UOESupplier uoeSupplierWork in retList)
                {
                    if (uoeSupplierWork.LogicalDeleteCode == 0)
                    {
                        // 2009.01.29 30413 犬飼 キーを拠点+UOE発注先コードに修正 >>>>>>START
                        // 2009.01.07 30413 犬飼 拠点コードをキーに追加 >>>>>>START
                        //string key = uoeSupplierWork.SupplierCd.ToString("d06");
                        //string key = uoeSupplierWork.SectionCode.TrimEnd() + "-" + uoeSupplierWork.SupplierCd.ToString("d06");
                        string key = uoeSupplierWork.SectionCode.TrimEnd() + "-" + uoeSupplierWork.UOESupplierCd.ToString("d06");
                        // 2009.01.07 30413 犬飼 拠点コードをキーに追加 <<<<<<END
                        // 2009.01.29 30413 犬飼 キーを拠点+UOE発注先コードに修正 <<<<<<END

                        //--- ADD donggy 2012/11/27-->>>>>>>>>
                        if (!sectionCodeDic.ContainsKey(uoeSupplierWork.SectionCode))
                        {
                            sectionCodeDic.Add(uoeSupplierWork.SectionCode, uoeSupplierWork.SectionCode);
                        }
                        // ------ ADD donggy 2012/11/27-------<<<<<

                        if (_uoeSupplierDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            _uoeSupplierDic.Remove(key);
                        }
                        _uoeSupplierDic.Add(key, uoeSupplierWork);
                    }
                }
                // --- ADD donggy 2012/11/27------>>>>>>>>>>>>
                Dictionary<string, string>.KeyCollection keys = sectionCodeDic.Keys;
                this.uoeGuideNameDic = new Dictionary<string, UOEGuideName>();
                foreach (string key in keys)
                {
                    uoeGuideName = new UOEGuideName();
                    uoeGuideNameList = new ArrayList();
                    uoeGuideName.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    uoeGuideName.SectionCode = sectionCodeDic[key];
                    uoeGuideName.UOEGuideDivCd = 2;
                    status = this._uoeGuideNameAcs.SearchAll(out uoeGuideNameList, uoeGuideName);
                    UOEGuideName uoeGuideN = null;
                    for (int i = 0; i < uoeGuideNameList.Count; i++)
                    {
                        uoeGuideN = uoeGuideNameList[i] as UOEGuideName;
                        this.uoeGuideNameDic.Add(uoeGuideN.SectionCode + "-" + uoeGuideN.UOESupplierCd + "-" + uoeGuideN.UOEGuideCode, uoeGuideN);
                    }
                }
                // --- ADD donggy 2012/11/27------<<<<<<<<<<<<
            }
        }
        #endregion

        #region 発注データのクリア
        /// <summary>
        /// 発注データのクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注用のデータをクリアします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private void CacheOrderDataClear()
        {
            this._stockSlipWorkDic = new Dictionary<string, StockSlipWork>();   // 仕入データディクショナリー
            
            // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 >>>>>>START
            //this._stockSlipWorkList = new List<StockSlipWork>();                // 仕入データワークリスト
            // 2009.01.07 30413 犬飼 発注データ用仕入データワークリストの削除 <<<<<<END
            
            this._stockDetailList = new ArrayList();                            // UOE発注分以外仕入明細データ

            // 2009.01.07 30413 犬飼 拠点・倉庫・仕入先単位で作成するため、発注データ用仕入データをディクショナリー化 >>>>>>START
            //_stockSlipList = new ArrayList();                                   // 発注用仕入データ
            _stockSlipDic = new Dictionary<string, StockSlipWork>();            // 発注用仕入データディクショナリー
            // 2009.01.07 30413 犬飼 拠点・倉庫・仕入先単位で作成するため、発注データ用仕入データをディクショナリー化 <<<<<<END
            
            _stockDetailDic = new Dictionary<string, ArrayList>();              // UOE発注分以外仕入明細データ
            _stockDetailUOEList = new ArrayList();                              // UOE発注分仕入明細データ
            _uoeOrderDtlList = new ArrayList();                                 // UOE発注データ
        }
        #endregion

        #region 在庫管理全体設定マスタのローカルキャッシュ
        /// <summary>
        /// 在庫管理全体設定マスタのローカルキャッシュ
        /// </summary>
        /// <param name="orderListCndtn">抽出条件</param>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定マスタのローカルキャッシュを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.10</br>
        /// </remarks>
        private void CacheStockMngTtlSt(OrderListCndtn orderListCndtn)
        {
            int status;
            ArrayList retList;

            // 在庫管理全体設定マスタのローカルキャッシュをクリア
            _stockMngTtlStDic = new Dictionary<string, StockMngTtlSt>();

            status = this._stockMngTtlStAcs.SearchAll(out retList, orderListCndtn.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if (stockMngTtlSt.LogicalDeleteCode == 0)
                    {
                        string key = stockMngTtlSt.SectionCode.Trim();
                        if (_stockMngTtlStDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            _stockMngTtlStDic.Remove(key);
                        }
                        _stockMngTtlStDic.Add(key, stockMngTtlSt);
                    }
                }
            }
        }
        #endregion

        #region 仕入先の抽出条件チェック
        /// <summary>
        /// 仕入先の抽出条件チェック
        /// </summary>
        /// <param name="orderListCndtn">抽出条件</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <remarks>
        /// <br>Note       : 仕入先が抽出条件と一致するかチェック。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.07</br>
        /// </remarks>
        private bool CheckSupplierCd(OrderListCndtn orderListCndtn, int supplierCd)
        {
            if (orderListCndtn.SupplierCodes == null)
            {
                // 範囲指定
                int ed_SupplierCode = orderListCndtn.Ed_SupplierCode;
                if (ed_SupplierCode == 0)
                {
                    // 終了未設定
                    ed_SupplierCode = 999999;
                }

                if ((orderListCndtn.St_SupplierCode <= supplierCd) && (supplierCd <= ed_SupplierCode))
                {
                    // 抽出対象
                    return true;
                }
                else
                {
                    // 抽出対象外
                    return false;
                }
            }
            else
            {
                // 単独指定
                foreach (int supplierCdWork in orderListCndtn.SupplierCodes)
                {
                    if (supplierCdWork == supplierCd)
                    {
                        // 抽出対象
                        return true;
                    }
                }
                return false;
            }
        }
        #endregion

        // ADD 2009/06/09 ------>>>
        #region 倉庫マスタのローカルキャッシュ
        /// <summary>
        /// 倉庫マスタのローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタのローカルキャッシュを作成します。</br>
        /// <br></br>
        /// </remarks>
        private void CacheWarehouseData()
        {
            int status;
            ArrayList retList;

            // 倉庫マスタのローカルキャッシュをクリア
            _warehouseDic = new Dictionary<string, Warehouse>();

            // 仕入先マスタの取得
            status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Warehouse wkWarehouse in retList)
                {
                    if (wkWarehouse.LogicalDeleteCode == 0)
                    {
                        string key = wkWarehouse.WarehouseCode.TrimEnd().PadLeft(4, '0');
                        if (_warehouseDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            _warehouseDic.Remove(key);
                        }
                        _warehouseDic.Add(key, wkWarehouse);
                    }
                }
            }
        }
        #endregion

        #region リマーク取得
        /// <summary>
        /// リマーク取得
        /// </summary>
        /// <param name="orderListCndtn">抽出条件</param>
        /// <param name="uoeOrderDtlWork">UOE発注明細ワーク</param>
        /// <remarks>
        /// <br>Note       : リマークを取得する。</br>
        /// <br>UpdateNote : liyp 2011/04/11</br>
        /// <br>             倉庫股のリマークを空白にしていても送信処理の画面でリマーク１に日付が表示される不具合の修正</br>
        /// <br>UpdateNote : zhujc 2011/05/16</br>
        /// <br>             Redmine#21333 リマークのセット仕様がPM7と異なる為、修正する</br>
        /// </remarks>
        private string GetRemark(OrderListCndtn orderListCndtn, UOEOrderDtlWork uoeOrderDtlWork)
        {
            string stockBlnktRemark = string.Empty;

            string key = uoeOrderDtlWork.WarehouseCode.TrimEnd().PadLeft(4, '0');
            if (_warehouseDic.ContainsKey(key))
            {
                stockBlnktRemark = _warehouseDic[key].StockBlnktRemark;
                // if (stockBlnktRemark.Trim().Length < 4) // DEL 2011/04/11
                if (stockBlnktRemark.Trim().Length>0 && stockBlnktRemark.Trim().Length < 4) // ADD 2011/04/11
                {
                    // stockBlnktRemark = stockBlnktRemark.Trim() + orderListCndtn.ProcessDay.ToString("MM/dd"); // DEL 2011/05/16
                    // ADD 2011/05/16 -------------->>>>>>
                    // stockBlnktRemarkが1バイトの場合、リマークは「stockBlnktRemark  MM/DD」
                    if (1 == stockBlnktRemark.Trim().Length)
                    {
                        stockBlnktRemark = stockBlnktRemark.Trim() + "  " + orderListCndtn.ProcessDay.ToString("MM/dd");
                    }
                    // stockBlnktRemarkが2バイトの場合、リマークは「stockBlnktRemark MM/DD」
                    else if (2 == stockBlnktRemark.Trim().Length)
                    {
                        stockBlnktRemark = stockBlnktRemark.Trim() + " " + orderListCndtn.ProcessDay.ToString("MM/dd");
                    }
                    // stockBlnktRemarkが3バイトの場合、リマークは「stockBlnktRemarkMM/DD」
                    else
                    {
                        stockBlnktRemark = stockBlnktRemark.Trim() + orderListCndtn.ProcessDay.ToString("MM/dd");
                    }
                    // ADD 2011/05/16 --------------<<<<<<
                }
            }            

            return stockBlnktRemark;
        }
        #endregion
        // ADD 2009/06/09 ------<<<

        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
        #region ◎ メーカー名称取得
        /// <summary>
        /// メーカー名称取得用メソッド
        /// </summary>
        /// <param name="makeName">メーカー名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : メーカー名称取得用メソッド</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/11/05</br>
        /// </remarks> 
        public string GetMakerName(string makeName)
        {
            // 完全削除の場合
            if (string.IsNullOrEmpty(makeName))
            {
                return CtNoLogin;
            }
            else
            {
                return SubStringOfByte(makeName.Trim(), 40);
            }
        }
        #endregion

        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        /// <remarks>
        /// <br>Note       : 文字列　バイト数指定切り抜き。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/11/05</br>
        /// </remarks>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            if (encoding.GetByteCount(orgString) <= byteCount)
            {
                return orgString;
            }

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount)
                {
                    if (count == byteCount - 1)
                    {
                        resultString += " ";
                    }
                    break;
                }
            }
            // 終端の空白は削除
            return resultString;
        }

        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<

        #endregion ■ Private Method

    }
}
