//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入庫更新
// プログラム概要   : 在庫入庫更新で使用するデータの取得、更新を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2008/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/14  修正内容 : 買掛オプション取得メソッド変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/15  修正内容 : 不具合対応[10068][10115][10059]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/16  修正内容 : UOE発注で拠点、BO1、BO2、BO3のうち2つ以上伝票番号が入ってこないデータがある場合にエラーとなる為、修正
//                                  不具合対応[10145]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/19  修正内容 : 2009/01/16対応分の文言変更、及びﾒｰｶｰﾌｫﾛｰ、EOの追加
//                                  不具合対応[10063]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/05  修正内容 : 不具合対応[10974]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/17  修正内容 : 不具合対応[11238]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/18  修正内容 : 分納時、指定された伝票番号の明細のみ表示する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/23  修正内容 : 締日取得前に締日チェックを行うように修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/11/15  修正内容 : 1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応
//                                : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが
//                                : 価格マスタの原価を変えても、色彩は変化しない。
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangmj
// 修 正 日  2012/12/17  修正内容 : 1月16日配信分、Redmine#32926 PMデータと連携が取れないの対応
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangmj
// 修 正 日  2012/12/17  修正内容 :  1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李占川
// 修 正 日  2013/05/16  修正内容 : 2013/06/18配信分、Redmine#35459 #42の対応
//----------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 高騁
// 修 正 日  2015/01/21  修正内容 : Redmine#44056 在庫入庫更新で締月次チェックの修正
//----------------------------------------------------------------------//
// 管理番号  11170129-00 作成担当 : 宋剛
// 修 正 日  2015/08/26  修正内容 : Redmine#47030 【№332】在庫入庫更新の障害対応
//----------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 修 正 日  2017/08/11  修正内容 : ハンディターミナル在庫仕入登録の対応
//----------------------------------------------------------------------//

# region ※using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;// ADD wangf 2012/11/15 FOR Redmine#31980
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE入庫更新テーブルアクセスクラス
    /// </summary>
    /// <remarks>
	/// <br>Note		: UOE入庫更新データの検索を行います。</br>
    /// <br>              ◆UOE発注データ→UOE入庫更新メインデータ(オンライン番号-伝票番号単位に分割)→UOE入庫更新ヘッダー、明細データの順に作成</br>
	/// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2008/09/04</br>
    /// <br>UpdateNote  : 2009/01/14 照田 貴志　買掛オプション取得メソッド変更</br>
    /// <br>              2009/01/15 照田 貴志　不具合対応[10068][10115][10059]</br>
    /// <br>              2009/01/16 照田 貴志　UOE発注で拠点、BO1、BO2、BO3のうち2つ以上伝票番号が入ってこないデータがある場合にエラーとなる為、修正</br>
    /// <br>                                    不具合対応[10145]</br>
    /// <br>              2009/01/19 照田 貴志　2009/01/16対応分の文言変更、及びﾒｰｶｰﾌｫﾛｰ、EOの追加</br>
    /// <br>                                    不具合対応[10063]</br>
    /// <br>              2009/02/05 照田 貴志　不具合対応[10974]</br>
    /// <br>              2009/02/17 照田 貴志　不具合対応[11238]</br>
    /// <br>              2009/02/18 照田 貴志　分納時、指定された伝票番号の明細のみ表示する</br>
    /// <br>              2009/02/23 照田 貴志　締日取得前に締日チェックを行うように修正</br>
    /// <br>Update Note : 2012/11/15 wangf </br>
    /// <br>            : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
    /// <br>            : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
    /// <br>            : 価格マスタの原価を変えても、色彩は変化しない。</br>
    /// <br>Update Note : 2012/12/17 yangmj </br>
    /// <br>            : 10801804-00、1月16日配信分、redmine#32926 PMデータと連携が取れないの対応</br>
    /// <br>Update Note : 2012/12/17 yangmj </br>
    /// <br>            : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
    /// <br>UpdateNote  : 2013/05/16 李占川</br>
    /// <br>管理番号    : 10801804-00 2013/06/18配信分</br>
    /// <br>              Redmine#35459 #42の対応</br>
    /// <br>UpdateNote  : 2015/01/21 高騁  </br>
    /// <br>管理番号    : 11070149-00 2015/01/21配信分</br>
    /// <br>              Redmine#44056 在庫入庫更新で締月次チェックの修正の対応</br> 
    /// <br>UpdateNote  : 2015/08/26 宋剛  </br>
    /// <br>管理番号    : 11170129-00</br>
    /// <br>              Redmine#47030 【№332】在庫入庫更新の障害対応</br> 
    /// <br>UpdateNote  : 2017/08/11 譚洪  </br>
    /// <br>管理番号    : 11370074-00</br>
    /// <br>              ハンディターミナル在庫仕入登録の対応</br> 
    /// </remarks>
    public class PMUOE01203AA
    {
        // ===================================================================================== //
        // パブリック変数
        // ===================================================================================== //
        # region ▼定数
        // 列区分
        public const string COLUMNDIV_SECTION = "SECTION";      // 拠点
        public const string COLUMNDIV_BO1 = "BO1";              // BO1
        public const string COLUMNDIV_BO2 = "BO2";              // BO2
        public const string COLUMNDIV_BO3 = "BO3";              // BO3
        public const string COLUMNDIV_MAKER = "MAKER";          // メーカー
        public const string COLUMNDIV_EO = "EO";                // EO
        #endregion

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼定数（ハンディターミナル用）
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムID</summary>
        private const string AssemblyIdPmhnd01114d = "PMHND01114D";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01114dClassName = "Broadleaf.Application.Remoting.ParamData.InspectDataAddWork";

        /// <summary>仕入明細通番</summary>
        private const string StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary>入庫区分</summary>
        private const string WarehousingDivCd = "WarehousingDivCd";
        /// <summary>更新区分</summary>
        private const string UpdateDiv = "UpdateDiv";
        /// <summary>検品数</summary>
        private const string InspectCnt = "InspectCnt";
        /// <summary>発注先コード</summary>
        private const string UoeSupplierCd = "UoeSupplierCd";

        /// <summary>税率コード</summary>
        private const int TaxRateCode = 0;

        /// <summary>拠点</summary>
        private const string WarehousingSectionDiv = "1";
        /// <summary>BO1</summary>
        private const string WarehousingBo1Div = "2";
        /// <summary>BO2</summary>
        private const string WarehousingBo2Div = "3";
        /// <summary>BO3</summary>
        private const string WarehousingBo3Div = "4";
        /// <summary>メーカー</summary>
        private const string WarehousingMakerDiv = "5";
        /// <summary>EO</summary>
        private const string WarehousingEoDiv = "6";

        /// <summary>UOE拠点伝票番号</summary>
        private const string EnterUpdDivSecSlipNo = "ﾊﾞﾝｺﾞｳﾅｼ ｷｮﾃﾝ";
        /// <summary>BO伝票番号1</summary>
        private const string EnterUpdDivBO1SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO1";
        /// <summary>BO伝票番号2</summary>
        private const string EnterUpdDivBO2SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO2";
        /// <summary>BO伝票番号3</summary>
        private const string EnterUpdDivBO3SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO3";
        /// <summary>ﾒｰｶｰ</summary>
        private const string EnterUpdDivMakerSlipNo = "ﾊﾞﾝｺﾞｳﾅｼ ﾒｰｶｰ";
        /// <summary>EO</summary>
        private const string EnterUpdDivEOSlipNo = "ﾊﾞﾝｺﾞｳﾅｼ EO";

        /// <summary>入庫更新区分（拠点）「0:未入庫」</summary>
        private const int EnterUpdDivSecData0 = 0;
        /// <summary>入庫更新区分（BO1）「0:未入庫」</summary>
        private const int EnterUpdDivBO1Data0 = 0;
        /// <summary>入庫更新区分（BO2）「0:未入庫」</summary>
        private const int EnterUpdDivBO2Data0 = 0;
        /// <summary>入庫更新区分（BO3）「0:未入庫」</summary>
        private const int EnterUpdDivBO3Data0 = 0;
        /// <summary>入庫更新区分（ﾒｰｶｰ）「0:未入庫」</summary>
        private const int EnterUpdDivMakerData0 = 0;
        /// <summary>入庫更新区分（EO）「0:未入庫」</summary>
        private const int EnterUpdDivEOData0 = 0;

        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ▼変数
        // 各種クラス
        private GoodsAcs _goodsAcs = null;                      // 商品マスタアクセスクラス
        private PMUOE01203AB _decisionDataAcs = null;           // 入庫更新確定処理用クラス
        private IUOEStockUpdateDB _iUOEStockUpdateDB = null;    // 入庫更新用リモートオブジェクト
        // データセット関連
        private GridMainDataSet.GridMainTableDataTable _gridMainTable = null;   // UOE入庫更新メイン
        private HeaderGridDataSet _headerDataSet = null;                        // UOE入庫更新ヘッダー
        private DetailGridDataSet _detailDataSet = null;                        // UOE入庫更新明細
        // HashTable
        private Hashtable _supplierHTable = null;               // 仕入先マスタ(key：仕入先コード)
        private Hashtable _uoeOrderDtlWorkHTable = null;        // UOE発注データ(key：仕入明細通番)
        private Hashtable _stockSlipWorkHTable = null;          // 仕入データ(key：仕入伝票番号)
        private Hashtable _stockDetailWorkHTable = null;        // 仕入明細データ(key：仕入明細通番)
        private Hashtable _uoeSupplierHTable = null;            // UOE発注先マスタ(key：UOE発注先コード)        //ADD 2009/01/19 不具合対応[10063]
        // その他
        private string _enterpriseCode;                         // 企業コード
        private int _prevHeaderRowNo = -1;                      // 現在選択されているヘッダー行No.
        private bool _stockingPaymentOption = false;            // 買掛オプション
        private int _stockBlnktPrtNoDiv;                        // UOE自社マスタ.在庫一括品番区分
        private bool _meiJiDiv = false;                         // 明治産業区分　ADD 李占川 2013/05/16 Redmine#35459

        private UOEStockUpdSearchWork _searchBackup = null;     //ADD 2009/02/18 分納時、指定された伝票番号の明細のみ表示する為
        // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
        private string _loginSectionCode = string.Empty;// ログイン拠点コード

        private TaxRateSet _taxRateSet;
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        private StockProcMoneyAcs _stockProcMoneyAcs;   // 単価算出クラスアクセスクラス
        private UnitPriceCalculation _unitPriceCalculation;
        private List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
        private List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
        private List<RateProtyMng> _rateProtyMngAllList = null;                                 // 掛率優先順位情報リスト（全情報）
        // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
        #endregion

        #region ▼UOEOrderDtlInfo構造体
        /// <summary>
        /// UOE発注先情報　構造体
        /// </summary>
        public struct UOEOrderDtlInfo
        {
            /// <summary> アセンブリID </summary>
            public string CommAssemblyId;
            /// <summary> 発注先名称 </summary>
            public string UOESupplierName;
        }
        # endregion

        #region ▼デリゲート
        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);
		#endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
		# region ■Constracter
		/// <summary>
		/// コンストラクタ
        /// </summary>
        /// <remarks>
		/// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public PMUOE01203AA()
        {
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 買掛オプションを取得する
            this._stockingPaymentOption = this.CheckOption();

            // オフラインチェック
            if (!LoginInfoAcquisition.OnlineFlag)
            {
                MessageBox.Show("オフライン状態のため検索が実行できません。");
                return;
            }

            // アクセスクラスインスタンス化
            string msg = string.Empty;
            this._goodsAcs = new GoodsAcs();                                // 商品マスタアクセスクラス
            this._goodsAcs.IsGetSupplier = true;// ADD wangf 2012/11/15 FOR Redmine#31980
            this._goodsAcs.SearchInitial(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            if (LoginInfoAcquisition.Employee != null)
            {
                Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                this._loginSectionCode = loginEmployee.BelongSectionCode.Trim();
            }
            this._taxRateSetAcs = new TaxRateSetAcs();

            int status;

            try
            {
                // 税率設定マスタ取得(税率コード=0固定)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            ReadInitData();
            SearchRateProtyMng();
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            // 入庫更新用リモートオブジェクト取得
            this._iUOEStockUpdateDB = (IUOEStockUpdateDB)MediationUOEStockUpdateDB.GetUOEStockUpdateDB();

            // 表示DataSetインスタンス化(データなし、グリッドレイアウト設定のみ)
            this._headerDataSet = new HeaderGridDataSet();      // ヘッダーグリッド用
            this._detailDataSet = new DetailGridDataSet();      // 明細グリッド用

            // 仕入先データHashTable作成
            this.CreateSupplierHTable();

            // UOE発注先データHashTable作成
            this.CreateUOESupplierHTable();                     //ADD 2009/01/19 不具合対応[10063]
        }
        # endregion

        // ===================================================================================== //
        // パブリック
        // ===================================================================================== //
        // プロパティ
        /// <summary> UOE入庫更新ヘッダーデータ </summary>
        public HeaderGridDataSet UOEEnterUpdHeaderDataSet { get { return this._headerDataSet; } }
        /// <summary> UOE入庫更新明細データ </summary>
        public DetailGridDataSet UOEEnterUpdDetailDataSet { get { return this._detailDataSet; } }
        /// <summary> UOE自社マスタ.在庫一括品番区分</summary>
        public int StockBlnktPrtNoDiv { set { this._stockBlnktPrtNoDiv = value; } }
        /// <summary> 買掛オプション </summary>
        public bool StockingPaymentOption { get { return this._stockingPaymentOption; } }

        #region ▼SetSearchData(検索処理)
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="uoeEnterUpdCndtn">UOE発注データ検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 条件に沿って検索を行います。取得したデータを元に各種HashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public int SetSearchData(UOEStockUpdSearch uoeStockUpdSearch)
        {
            // 初期化
            this.ClearUOEEnterUpdHeaderData();
            this.ClearUOEEnterUpdDetailData();

            // 条件作成
            UOEStockUpdSearchWork uoeStockUpdSearchWork = new UOEStockUpdSearchWork();
            uoeStockUpdSearchWork.EnterpriseCode = uoeStockUpdSearch.EnterpriseCode;
            uoeStockUpdSearchWork.SectionCode = uoeStockUpdSearch.SectionCode.Trim();
            uoeStockUpdSearchWork.ProcDiv = uoeStockUpdSearch.ProcDiv;
            uoeStockUpdSearchWork.UOESupplierCd = uoeStockUpdSearch.UOESupplierCd;
            uoeStockUpdSearchWork.SlipNo = uoeStockUpdSearch.SlipNo;

            // データ抽出
            object retObject = new CustomSerializeArrayList();
            int status = this._iUOEStockUpdateDB.Search(uoeStockUpdSearchWork, ref retObject, 0, ConstantManagement.LogicalMode.GetData0);
            // --- テスト用データ(PMUOE01203AZ)使用時 --->>>>>
            //int status = 0;
            //DummyData.GetDummyData(ref retObject);
            // ------------------------------------------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.StatusBarMessageSetting(this, "該当データがありません。");
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                default:
                    this.StatusBarMessageSetting(this, "データの読込に失敗しました。");
                    return status;
            }

            CustomSerializeArrayList uoeStcUpdDataList = (CustomSerializeArrayList)retObject;
            if ((uoeStcUpdDataList == null) || (uoeStcUpdDataList.Count == 0))
            {
                this.StatusBarMessageSetting(this, "該当データがありません。");
                return status;
            }

            this._searchBackup = uoeStockUpdSearchWork;         //ADD 2009/02/18 分納時、指定された伝票番号の明細のみ表示する為

            // 各種データ取り込み
            for (int index = 0; index <= uoeStcUpdDataList.Count - 1; index++)
            {
                ArrayList arrayList = (ArrayList)uoeStcUpdDataList[index];
                if (arrayList.Count == 0)
                {
                    continue;
                }

                // 仕入データ→HashTable
                if (arrayList[0] is StockSlipWork)
                {
                    this.CreateStockSlipWorkHTable(arrayList);
                }
                // 仕入明細データ→HashTable
                else if (arrayList[0] is StockDetailWork)
                {
                    this.CreateStockDetailWorkHTable(arrayList);
                }
                // UOE発注データ→DataSet(グリッドとの連携の為)
                else if (arrayList[0] is UOEOrderDtlWork)
                {
                    // バックアップ(更新時に使用)
                    //this._uoeOrderDtlWorkList = arrayList;
                    this.CreateUOEOrderDtlWorkHTable(arrayList);

                    // UOE発注データ→グリッドメインデータ
                    this.CreateGridMainTable(arrayList);
                    // グリッドメインデータ→UOE入庫更新ヘッダー用データ
                    this.CreateHeaderGridDataSet();

                    // グリッドメインデータ→UOE入庫更新明細用データ
                    this.CreateDetailGridDataSet(0);
                }
            }

            if (this.StatusBarMessageSetting != null)
            {
                this.StatusBarMessageSetting(this, "データを抽出しました。");
            }
            return 0;
        }
        #endregion

        #region ▼DecisionData(UOE入庫更新確定処理)
        /// <summary>
        /// UOE入庫更新確定処理(本処理はPMUOE01203ABで行う)
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>処理結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE入庫更新確定処理を行います。データの作成はPMUOE01203ABクラスで行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        //public bool DecisionData(out string msg) // DEL 2009/02/02
        public int DecisionData(out string msg)
        {
            // ヘッダーグリッド→GridMain反映
            this.CopyToGridMainFromHeaderGrid();

            // インスタンス作成
            this._decisionDataAcs = new PMUOE01203AB(this._enterpriseCode
                                                    , this._uoeOrderDtlWorkHTable
                                                    , this._gridMainTable
                                                    , this._stockSlipWorkHTable
                                                    , this._stockDetailWorkHTable
                                                    , this._supplierHTable);    // 入庫更新確定処理専用クラス

            // プロパティセット
            this._decisionDataAcs.GoodsAcs = this._goodsAcs;                            // 商品マスタアクセスクラス
            this._decisionDataAcs.StockingPaymentOption = this._stockingPaymentOption;  // 買掛オプション
            this._decisionDataAcs.StockBlnktPrtNoDiv = this._stockBlnktPrtNoDiv;        // UOE自社マスタ.在庫一括品番区分       //ADD 2009/01/16 不具合対応[10145]
            this._decisionDataAcs.MeiJiDiv = this._meiJiDiv;                            // 明治産業区分　ADD 李占川 2013/05/16 Redmine#35459

            // データ作成
            object uoeStcUpdDataList = this._decisionDataAcs.CreateUOEStcUpdDataList(out msg);
            if (uoeStcUpdDataList == null)
            {

                // データ作成失敗
                //return false; // DEL 2009/02/02
                return -1; // ADD 2009/02/02
            }

            // データ作成成功
            int status = this._iUOEStockUpdateDB.Write(ref uoeStcUpdDataList);

            // ---ADD 2009/02/17 -------------------------------------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                msg = "更新時にエラーが発生しました。 " + "\r\n" + status.ToString();
            }
            // ---ADD 2009/02/17 --------------------------------------<<<<<

            //return true; // DEL 2009/02/02
            return status; // ADD 2009/02/02
        }
        #endregion

        // UOE入庫更新データ関連
        #region ▼SaveDetailGrid(明細グリッド→UOE入庫更新メインデータ反映)
        /// <summary>
        /// 明細グリッド→UOE入庫更新メインデータ反映
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッドの内容をUOE入庫更新メインデータに反映します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void SaveDetailGrid()
        {
            // 明細グリッド→GridMain反映
            this.CopyToGridMainFromDetailGrid();
        }
        #endregion

        // 仕入先データ関連
        #region ▼GetSupplierName(仕入先名称取得)
        /// <summary>
        /// 仕入先名称取得
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierName">仕入先名称</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 仕入先コードを元に仕入先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public bool GetSupplierName(int supplierCd, out string supplierName)
        {
            return this.GetSupplierNameFromSupplierHTable(supplierCd, out supplierName);
        }
        #endregion

        // ---ADD 2009/01/19 不具合対応[10063] ------------------------------------------------------->>>>>
        // UOE発注先データ関連
        #region ▼GetUOESupplierName(UOE発注先名称取得)
        /// <summary>
        /// UOE発注先名称取得
        /// </summary>
        /// <param name="supplierCd">UOE発注先コード</param>
        /// <param name="supplierName">UOE発注先名称</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元にUOE発注先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public bool GetUOESupplierName(int uoeSupplierCd, out string uoeSupplierName)
        {
            return this.GetUOESupplierNameFromUOESupplierHTable(uoeSupplierCd, out uoeSupplierName);
        }
        #endregion
        // ---ADD 2009/01/19 不具合対応[10063] -------------------------------------------------------<<<<<

        // グリッド用
        #region ▼ClearUOEEnterUpdHeaderData(ヘッダーグリッドデータクリア)
        /// <summary>
        /// ヘッダーグリッドデータクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダーグリッドのデータをクリアします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void ClearUOEEnterUpdHeaderData()
        {
            this._headerDataSet.HeaderTable.Rows.Clear();
            this._prevHeaderRowNo = -1;
        }
        #endregion

        #region ▼HeaderGridTotalDisplay(ヘッダーグリッド合計設定)
        /// <summary>
        /// ヘッダーグリッド合計設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッドデータからヘッダーグリッドの合計を算出し、表示します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void HeaderGridTotalDisplay()
        {
            // 明細グリッドの内容を元に合計を算出
            Double total = 0;
            DetailGridDataSet.DetailTableRow detailRow = null;
            for (int index = 0; index <= this._detailDataSet.DetailTable.Rows.Count - 1; index++)
            {
                detailRow = (DetailGridDataSet.DetailTableRow)this._detailDataSet.DetailTable.Rows[index];
                total = total + (detailRow.InputEnterCnt * detailRow.InputAnswerSalesUnitCost);
            }

            // 算出した合計を表示
            HeaderGridDataSet.HeaderTableRow headerRow = (HeaderGridDataSet.HeaderTableRow)this._headerDataSet.HeaderTable.Rows[this._prevHeaderRowNo];
            headerRow.Total = total;
        }
        #endregion

        #region ▼ClearUOEEnterUpdDetailData(明細グリッドデータクリア)
        /// <summary>
        /// 明細グリッドデータクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッドのデータをクリアします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void ClearUOEEnterUpdDetailData()
        {
            this._detailDataSet.DetailTable.Rows.Clear();
        }
        #endregion

        #region ▼DetailGridDivCdDisplayAll(明細グリッド区分項目設定)
        /// <summary>
        /// 明細グリッド区分項目設定
        /// </summary>
        /// <param name="divCd">ヘッダーグリッドで選択された区分</param>
        /// <remarks>
        /// <br>Note       : 渡された区分(ヘッダーグリッドの区分)に応じて明細グリッドの区分項目を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void DetailGridDivCdDisplayAll(string divCd)
        {
            DetailGridDataSet.DetailTableRow row = null;
            for (int index = 0; index <= this._detailDataSet.DetailTable.Rows.Count - 1; index++)
            {
                row = (DetailGridDataSet.DetailTableRow)this._detailDataSet.DetailTable.Rows[index];       

                // 在庫存在時、そのままの値
                if ((bool)row[this._detailDataSet.DetailTable.StockExistsColumn.ColumnName])
                {
                    row.DivCd = divCd;
                }
                else
                {
                    // 在庫未存在時、「9：消込み」「△：未処理」はそのままの値
                    if ((divCd == PMUOE01202EA.DIVCD_DELETE) || (divCd == PMUOE01202EA.DIVCD_NOCHANGE))
                    {
                        row.DivCd = divCd;
                    }
                    else
                    {
                        row.DivCd = PMUOE01202EA.DIVCD_NOTENTER;        // 「2：未入荷」
                    }
                }
            }
        }
        #endregion

        #region ▼DetailGridDataDisplay(明細データ表示)
        /// <summary>
        /// 明細データ表示
        /// </summary>
        /// <param name="headerRowNo">ヘッダーグリッドで選択された行</param>
        /// <remarks>
        /// <br>Note       : ヘッダーグリッドで選択された行に応じて明細の表示を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void DetailGridDataDisplay(int headerRowNo)
        {
            this.CreateDetailGridDataSet(headerRowNo);
        }
        #endregion

        #region ▼CheckSlipNoIsNullOrEmpty(伝票番号入力チェック)
        /// <summary>
        /// 伝票番号入力チェック
        /// </summary>
        /// <param name="errorRowNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 伝票番号の入力チェックを行います。(入庫、修正時は必須)</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public bool CheckSlipNoIsNullOrEmpty(out int errorRowNo)
        {
            errorRowNo = -1;

            // 買掛オプションなしの場合、無条件でチェックOKとする
            if (this._stockingPaymentOption == false)
            {
                return true;
            }

            DataTable dataTable = this._headerDataSet.Tables[0];

            HeaderGridDataSet.HeaderTableRow headerRow = null;
            for (int index = 0; index <= dataTable.Rows.Count - 1; index++)
            {
                headerRow = (HeaderGridDataSet.HeaderTableRow)dataTable.Rows[index];
                if ((headerRow.DivCd == PMUOE01202EA.DIVCD_ENTER) || (headerRow.DivCd == PMUOE01202EA.DIVCD_UPDATE))
                {
                    if (string.IsNullOrEmpty(headerRow.SlipNo) == true)
                    {
                        errorRowNo = index;
                        return false;
                    }
                    // ---ADD 2009/01/16 -------------------------------------------------------------------->>>>>
                    /* ---DEL 2009/01/19 文言変更＆ﾒｰｶｰ、EO追加 ---------------------------------->>>>>
                    if ((headerRow.SlipNo == "ｷｮﾃﾝﾊﾞﾝｺﾞｳﾅｼ") ||
                        (headerRow.SlipNo == "BO1ﾊﾞﾝｺﾞｳﾅｼ") ||
                        (headerRow.SlipNo == "BO2ﾊﾞﾝｺﾞｳﾅｼ") ||
                        (headerRow.SlipNo == "BO3ﾊﾞﾝｺﾞｳﾅｼ"))
                       ---DEL 2009/01/19 ---------------------------------------------------------<<<<< */
                    // ---ADD 2009/01/19 --------------------------------------------------------->>>>>
                    if ((headerRow.SlipNo == "ﾊﾞﾝｺﾞｳﾅｼ ｷｮﾃﾝ") ||
                        (headerRow.SlipNo == "ﾊﾞﾝｺﾞｳﾅｼ BO1") ||
                        (headerRow.SlipNo == "ﾊﾞﾝｺﾞｳﾅｼ BO2") ||
                        (headerRow.SlipNo == "ﾊﾞﾝｺﾞｳﾅｼ BO3") ||
                        (headerRow.SlipNo == "ﾊﾞﾝｺﾞｳﾅｼ ﾒｰｶｰ") ||
                        (headerRow.SlipNo == "ﾊﾞﾝｺﾞｳﾅｼ EO"))
                    // ---ADD 2009/01/19 ---------------------------------------------------------<<<<<
                    {
                        errorRowNo = index;
                        return false;
                    }
                    // ---ADD 2009/01/16 --------------------------------------------------------------------<<<<<
                }
            }

            return true;
        }
        #endregion

        // ---ADD 2009/02/05 不具合対応[10974] ------------------------------------------------------------------------------------------->>>>>
        #region ▼CheckDayPayment(締日チェック)
        /// <summary>
        /// 締日チェック
        /// </summary>
        /// <param name="errorRowNo"></param>
        /// <returns>0：正常、-1：月次締日エラー、-2：締次締日エラー</returns>
        /// <remarks>
        /// <br>Note       : 締日チェックを行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/05</br>
        /// <br>UpdateNote : 2015/01/21 高騁</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>             在庫入庫更新で締月次チェックの修正(Redmine#44056)</br>
        /// </remarks>
        public int CheckDayPayment(out int errorRowNo)
        {
            errorRowNo = -1;

            int status = 0;
            DateTime prevTotalDay = DateTime.MinValue;

            StockSlipWork stockSlipWork = null;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            // 締日算出モジュール
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();

            // 区分が「入庫」「明細修正」のものを抽出
            string filter = string.Format("({0} = '{1}') OR ({0} = '{2}')"
                                        , this._gridMainTable.DivCdColumn.ColumnName
                                        , PMUOE01202EA.DIVCD_ENTER
                                        , PMUOE01202EA.DIVCD_UPDATE);

            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());
            // 買掛オプションあり
            if (this._stockingPaymentOption == true)
            {
                for (int index = 0; index <= dataRows.Length - 1; index++)
                {
                    gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                    if (this._stockSlipWorkHTable.ContainsKey(gridMainRow.SupplierSlipNo.ToString()) == false)
                    {
                        continue;
                    }

                    stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[gridMainRow.SupplierSlipNo.ToString()];

                    /* ---DEL 2009/02/23 --------------------------------------------------------------------->>>>>
                    // 仕入月次の締日取得
                    status = totalDayCalculator.GetTotalDayMonthlyAccPay(stockSlipWork.PayeeCode, out prevTotalDay);
                    if (DateTime.Today <= prevTotalDay)
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }

                    // 仕入締次の締日取得
                    status = totalDayCalculator.GetTotalDayPayment(stockSlipWork.PayeeCode, out prevTotalDay);
                    if (DateTime.Today <= prevTotalDay)
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -2;
                    }
                       ---DEL 2009/02/23 ---------------------------------------------------------------------<<<<< */
                    // ----------------------- DEL 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正-------------------------------------->>>>>
                    // ---ADD 2009/02/23 --------------------------------------------------------------------->>>>>
                    //// 仕入月次の締日チェック
                    //if (totalDayCalculator.CheckMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate))
                    //{
                    //    // 仕入月次の締日取得
                    //    status = totalDayCalculator.GetTotalDayMonthlyAccPay(stockSlipWork.PayeeCode, out prevTotalDay);
                    //    if (DateTime.Today <= prevTotalDay)
                    //    {
                    //        errorRowNo = gridMainRow.HeaderGridRowNo;
                    //        return -1;
                    //    }
                    //}
                    //// 仕入締次の締日チェック
                    //if (totalDayCalculator.CheckPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate))
                    //{
                    //    // 仕入締次の締日取得
                    //    status = totalDayCalculator.GetTotalDayPayment(stockSlipWork.PayeeCode, out prevTotalDay);
                    //    if (DateTime.Today <= prevTotalDay)
                    //    {
                    //        errorRowNo = gridMainRow.HeaderGridRowNo;
                    //        return -2;
                    //    }
                    //}
                    // ---ADD 2009/02/23 ---------------------------------------------------------------------<<<<<
                    // ----------------------- DEL 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正--------------------------------------<<<<<
                    // ----------------------- ADD 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正-------------------------------------->>>>>
                    UOEOrderDtlWork uoeOrderData = this.GetUOEOrderData(gridMainRow);
                    if (uoeOrderData == null) return -1;
                    // 仕入月次の締日チェック
                    if (totalDayCalculator.CheckMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, uoeOrderData.ReceiveDate))
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }
                    // 仕入締次の締日チェック
                    if (totalDayCalculator.CheckPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, uoeOrderData.ReceiveDate))
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -2;
                    }
                    // ----------------------- ADD 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正--------------------------------------<<<<<
                }
            }
            // 買掛オプションなし
            else
            {
                totalDayCalculator.InitializeHisMonthlyAccPay();
                for (int index = 0; index <= dataRows.Length - 1; index++)
                {
                    gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                    if (this._stockSlipWorkHTable.ContainsKey(gridMainRow.SupplierSlipNo.ToString()) == false)
                    {
                        continue;
                    }

                    stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[gridMainRow.SupplierSlipNo.ToString()];
                    /* ---DEL 2009/02/23 --------------------------------------------------------------------->>>>>
                    // 売上月次の締日取得
                    status = totalDayCalculator.GetHisTotalDayMonthly(stockSlipWork.StockAddUpSectionCd.TrimEnd(), out prevTotalDay);
                    if (DateTime.Today <= prevTotalDay)
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }
                       ---DEL 2009/02/23 ---------------------------------------------------------------------<<<<< */
                    // ----------------------- DEL 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正-------------------------------------->>>>>
                    // ---ADD 2009/02/23 --------------------------------------------------------------------->>>>>
                    //// 売上月次の締日チェック
                    //if (totalDayCalculator.CheckMonthlyAccRec(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate))
                    //{
                    //    // 売上月次の締日取得
                    //    status = totalDayCalculator.GetHisTotalDayMonthly(stockSlipWork.StockAddUpSectionCd.TrimEnd(), out prevTotalDay);
                    //    if (DateTime.Today <= prevTotalDay)
                    //    {
                    //        errorRowNo = gridMainRow.HeaderGridRowNo;
                    //        return -1;
                    //    }
                    //}
                    // ---ADD 2009/02/23 ---------------------------------------------------------------------<<<<
                    // ----------------------- DEL 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正--------------------------------------<<<<<
                    // ----------------------- ADD 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正-------------------------------------->>>>>
                    UOEOrderDtlWork uoeOrderData = this.GetUOEOrderData(gridMainRow);
                    if (uoeOrderData == null) return -1;
                    // 売上月次の締日取得
                    totalDayCalculator.ClearCache();
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(stockSlipWork.StockAddUpSectionCd.TrimEnd(), out prevTotalDay);
                    // 売上月次の締日チェック
                    if (uoeOrderData.ReceiveDate <= prevTotalDay) 
                    {
                        errorRowNo = gridMainRow.HeaderGridRowNo;
                        return -1;
                    }
                    // ----------------------- ADD 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正--------------------------------------<<<<<
                }
            }

            return 0;
        }
        #endregion
        // ---ADD 2009/02/05 不具合対応[10974] -------------------------------------------------------------------------------------------<<<<<

        // ===================================================================================== //
        // プライベート
        // ===================================================================================== //
        // ----------------------- ADD 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正-------------------------------------->>>>>
        #region ▼GetOrderDtlKey(UOE発注データのキーの判断)
        /// <summary>
        /// キーの判断
        /// </summary>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <param name="slipNo">伝票番号</param>
        /// <returns>キー</returns>
        /// <remarks>
        /// <br>Note       : キーを取得します。</br>
        /// <br>Programmer : 高騁</br>
        /// <br>Date       : 2015/01/21</br>
        /// </remarks>
        private string GetOrderDtlKey(string stockSlipDtlNum, string slipNo)
        {
            // 明治産業時
            if (_meiJiDiv)
            {
                int slipNoInt = 0;
                Int32.TryParse(slipNo, out slipNoInt);
                return stockSlipDtlNum + slipNoInt.ToString().PadLeft(6, '0');
            }
            else
            {
                return stockSlipDtlNum;
            }
        }
        #endregion

        #region ▼GetUOEOrderData(UOEデータの取得)
        /// <summary>
        /// UOEデータの取得
        /// </summary>
        /// <param name="mainRow">Gridの行</param>
        /// <returns>UOEデータ</returns>
        /// <remarks>
        /// <br>Note       : UOEデータの取得</br>
        /// <br>Programmer : 高騁</br>
        /// <br>Date       : 2015/01/21</br>
        /// </remarks>
        private UOEOrderDtlWork GetUOEOrderData(GridMainDataSet.GridMainTableRow mainRow)
        {
            //UOE発注データ(key：仕入明細通番)
            UOEOrderDtlWork uoeOrderDtlWork = null;
            string uoeOrderDtlKey = this.GetOrderDtlKey(mainRow.StockSlipDtlNumSrc.ToString(), mainRow.SlipNo);
            foreach (string key in this._uoeOrderDtlWorkHTable.Keys)
            {  
                if (uoeOrderDtlKey == key)
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
                    break;
                }
            }
            return uoeOrderDtlWork;
        }
        #endregion
        // ----------------------- ADD 高騁 2015/01/21 Redmine#44056 在庫入庫更新で締月次チェックの修正--------------------------------------<<<<<

        #region ▼CheckOption(仕入支払管理オプションチェック)
        /// <summary>
        /// 仕入支払管理オプションチェック
        /// </summary>
        /// <returns>True：オプションOK、False：オプションNG</returns>
        /// <remarks>
        /// <br>Note       : 仕入支払管理オプションの値を判定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool CheckOption()
        {
            //PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);        //DEL 2009/01/14
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);      //ADD 2009/01/14
            return status >= PurchaseStatus.Contract;
        }
        #endregion

        // HashTable作成
        #region ▼CreateUOEOrderDtlWorkHTable(UOE発注データHashTable作成)
        /// <summary>
        /// UOE発注データHashTable作成
        /// </summary>
        /// <param name="arrayList">UOE発注データ</param>
        /// <remarks>
        /// <br>Note       : UOE発注データ用HashTableの作成を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        private void CreateUOEOrderDtlWorkHTable(ArrayList arrayList)
        {
            UOEOrderDtlWork uoeOrderDtlWork = null;

            this._uoeOrderDtlWorkHTable = new Hashtable();

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
                // 明治産業の判断
                if (index == 0)
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)arrayList[0];
                    _meiJiDiv = this.IsMEIJI(uoeOrderDtlWork.SupplierCd);
                }
                // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<

                uoeOrderDtlWork = (UOEOrderDtlWork)arrayList[index];

                // キー作成(仕入明細通番)
                //string key = string.Format("{0}", uoeOrderDtlWork.StockSlipDtlNum);   // DEL 李占川 2013/05/16 Redmine#35459

                // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
                string key = string.Empty;
                if (_meiJiDiv)
                {
                    // キー作成(仕入明細通番 + 出荷番号)
                    key = string.Format("{0}{1}", uoeOrderDtlWork.StockSlipDtlNum, uoeOrderDtlWork.UOESectionSlipNo.PadLeft(6, '0'));
                }
                else
                {
                    // キー作成(仕入明細通番)
                    key = string.Format("{0}", uoeOrderDtlWork.StockSlipDtlNum);
                }
                // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<

                // 格納
                if (this._uoeOrderDtlWorkHTable.ContainsKey(key) == false)
                {
                    this._uoeOrderDtlWorkHTable[key] = uoeOrderDtlWork;
                }
            }
        }
        #endregion

        #region ▼CreateStockSlipWorkHTable(仕入データHashTable作成)
        /// <summary>
        /// 仕入データHashTable作成
        /// </summary>
        /// <param name="arrayList">仕入データ</param>
        /// <remarks>
        /// <br>Note       : 仕入データ用HashTableの作成を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateStockSlipWorkHTable(ArrayList arrayList)
        {
            StockSlipWork stockSlipWork = null;

            this._stockSlipWorkHTable = new Hashtable();

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                stockSlipWork = (StockSlipWork)arrayList[index];

                // キー作成(仕入伝票番号)
                string key = string.Format("{0}", stockSlipWork.SupplierSlipNo);

                // 格納
                if (this._stockSlipWorkHTable.ContainsKey(key) == false)
                {
                    this._stockSlipWorkHTable[key] = stockSlipWork;
                }
            }
        }
        #endregion

        #region ▼CreateStockDetailWorkHTable(仕入明細データHashTable作成)
        /// <summary>
        /// 仕入明細データHashTable作成
        /// </summary>
        /// <param name="arrayList">仕入明細データ</param>
        /// <remarks>
        /// <br>Note       : 仕入明細データ用HashTableの作成を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/12/17 yangmj </br>
        /// <br>           : 10801804-00、1月16日配信分、redmine#32926 PMデータと連携が取れないの対応</br>
        /// </remarks>
        private void CreateStockDetailWorkHTable(ArrayList arrayList)
        {
            StockDetailWork stockDetailWork = null;

            this._stockDetailWorkHTable = new Hashtable();

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                stockDetailWork = (StockDetailWork)arrayList[index];

                // キー作成(仕入明細通番)
                string key = string.Format("{0}", stockDetailWork.StockSlipDtlNum);

                // 格納
                if (this._stockDetailWorkHTable.ContainsKey(key) == false)
                {
                    // ------------ADD yangmj 2012/12/17 FOR Redmine#32926--------->>>>
                    GridMainDataSet.GridMainTableRow mainRow = null;
                    DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());
                    for (int idx = 0; idx <= dataRows.Length - 1; idx++)
                    {
                        mainRow = (GridMainDataSet.GridMainTableRow)dataRows[idx];

                        string ver = string.Empty;
                        if (GetUOESupplierVerFromUOESupplierHTable(mainRow.SupplierCd, out ver))
                        {
                            //接続バージョン区分が"新",UOERemark1は「*D XXXX」の場合、倉庫情報は空白を設定する
                            if ((!string.IsNullOrEmpty(ver)) 
                                && (ver.Equals("1")) 
                                && (!string.IsNullOrEmpty(mainRow.UOERemark1) 
                                && mainRow.UOERemark1.Length >= 2 
                                && mainRow.UOERemark1.Substring(0, 2).Equals("*D")))
                            {
                                if (key.Equals(mainRow.StockSlipDtlNumSrc.ToString()))
                                {
                                    stockDetailWork.WarehouseCode = string.Empty;
                                    stockDetailWork.WarehouseName = string.Empty;
                                    stockDetailWork.WarehouseShelfNo = string.Empty;
                                }
                            }
                        }
                    }
                    // ------------ADD yangmj 2012/12/17 FOR Redmine#32926---------<<<<<
                    this._stockDetailWorkHTable[key] = stockDetailWork;
                }
            }
        }
        #endregion

        // ADD BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応 ---->>>>> 
        #region ▼UpdBOSlipNo(BO伝票番号編集処理)
        /// <summary>
        /// 重複のBO伝票番号編集処理
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE発注データ</param>
        /// <remarks>
        /// <br>Note       : 重複のBO伝票番号によって、通信IDよて、「-F」の編集処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2015/08/26</br>
        /// <br>管理番号   : 11170129-00</br>
        /// <br>             Redmine#47030 【№332】在庫入庫更新の障害対応</br>
        /// </remarks>
        private void UpdBOSlipNo(ref UOEOrderDtlWork uoeOrderDtlWork)
        {
            // UOE伝票番号
            string tempUOESectionSlipNo = uoeOrderDtlWork.UOESectionSlipNo;
            // BO1伝票番号
            string tempBOSlipNo1 = uoeOrderDtlWork.BOSlipNo1;
            // BO2伝票番号
            string tempBOSlipNo2 = uoeOrderDtlWork.BOSlipNo2;
            // BO3伝票番号
            string tempBOSlipNo3 = uoeOrderDtlWork.BOSlipNo3;

            switch (uoeOrderDtlWork.CommAssemblyId.Trim())
            {
                // ホンダ e-Parts「通信ID：0502」の場合
                case EnumUoeConst.ctCommAssemblyId_0502:
                    {
                        // BO1伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            uoeOrderDtlWork.BOSlipNo1 = tempBOSlipNo1 + "-F";
                        }

                        // BO2伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo))
                            {
                                uoeOrderDtlWork.BOSlipNo2 = tempBOSlipNo2 + "-F2";
                            }
                        }

                        // BO3伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) || tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                uoeOrderDtlWork.BOSlipNo3 = tempBOSlipNo3 + "-F3";
                            }
                        }

                        break;
                    }
                // ホンダ e-Parts「通信ID：0502」以外の場合
                default:
                    {
                        // BO1伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            if (tempBOSlipNo1.Equals(tempUOESectionSlipNo))
                            {
                                uoeOrderDtlWork.BOSlipNo1 = tempBOSlipNo1 + "-F";
                            }
                        }

                        // BO2伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo2.Equals(tempBOSlipNo1))
                            {
                                uoeOrderDtlWork.BOSlipNo2 = tempBOSlipNo2 + "-F2";
                            }
                        }

                        // BO3伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo1) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                uoeOrderDtlWork.BOSlipNo3 = tempBOSlipNo3 + "-F3";
                            }
                        }

                        break;
                    }
            }
        }
        #endregion
        // ADD BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応 ----<<<<<

        // グリッドメインデータ作成
        #region ▼CreateGridMainTable(UOE入庫更新メインデータ作成)
        /// <summary>
        /// UOE入庫更新メインデータ作成
        /// </summary>
        /// <param name="uoeOrderDtlTable">UOE発注データ</param>
        /// <remarks>
        /// <br>Note       : UOE発注データからUOE入庫更新メインデータを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
        /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
        /// <br>Update Note: 2012/12/17 yangmj </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>Update Note: 2015/08/26 宋剛 </br>
        /// <br>           : 11170129-00、Redmine#47030 【№332】在庫入庫更新の障害対応</br>
        /// </remarks>
        private void CreateGridMainTable(ArrayList arrayList)
        {
            UOEOrderDtlWork uoeOrderDtlWork = null;

            // UOE入庫更新メインテーブルインスタンス作成
            this._gridMainTable = new GridMainDataSet.GridMainTableDataTable();

            // 伝票番号単位に展開
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                uoeOrderDtlWork = (UOEOrderDtlWork)arrayList[index];

                // ADD BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応 ---->>>>> 
                UOEOrderDtlWork tempUoeOrderDtlWork = new UOEOrderDtlWork();
                tempUoeOrderDtlWork.UOESectionSlipNo = uoeOrderDtlWork.UOESectionSlipNo;
                tempUoeOrderDtlWork.CommAssemblyId = uoeOrderDtlWork.CommAssemblyId;
                tempUoeOrderDtlWork.BOSlipNo1 = uoeOrderDtlWork.BOSlipNo1;
                tempUoeOrderDtlWork.BOSlipNo2 = uoeOrderDtlWork.BOSlipNo2;
                tempUoeOrderDtlWork.BOSlipNo3 = uoeOrderDtlWork.BOSlipNo3;
                // 重複のBO伝票番号編集処理
                UpdBOSlipNo(ref tempUoeOrderDtlWork);
                // ADD BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応 ----<<<<<

                #region UOE拠点伝票番号
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.UOESectionSlipNo) == false)          //DEL 2009/01/15 不具合対応[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivSec == 0)                                        //ADD 2009/01/15
                {
                    // 共通部コピー
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_SECTION;                              // 列区分
                    gridMainRow.SlipNo = uoeOrderDtlWork.UOESectionSlipNo;                  // 伝票番号
                    gridMainRow.UOESectOutGoodsCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;    // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = 0;                                          // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;              // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;         // 入庫数(入力用)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "ｷｮﾃﾝﾊﾞﾝｺﾞｳﾅｼ";      //DEL 2009/01/19 文言変更
                        gridMainRow.SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ ｷｮﾃﾝ";       //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region BO伝票番号1
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.BOSlipNo1) == false)                 //DEL 2009/01/15 不具合対応[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivBO1 == 0)                                        //ADD 2009/01/15
                {
                    // 共通部コピー
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_BO1;                                  // 列区分
                    // gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo1;                         // 伝票番号 // DEL BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応
                    gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo1;                         // 伝票番号// ADD BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt1;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt1;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt1;             // 入庫数(入力用)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "BO1ﾊﾞﾝｺﾞｳﾅｼ";       //DEL 2009/01/19 文言変更
                        gridMainRow.SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO1";        //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region BO伝票番号2
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.BOSlipNo2) == false)                 //DEL 2009/01/15 不具合対応[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivBO2 == 0)                                        //ADD 2009/01/15
                {
                    // 共通部コピー
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_BO2;                                  // 列区分
                    //gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo2;                         // 伝票番号// DEL BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応
                    gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo2;                         // 伝票番号// ADD BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt2;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt2;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt2;             // 入庫数(入力用)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "BO2ﾊﾞﾝｺﾞｳﾅｼ";       //DEL 2009/01/19 文言変更
                        gridMainRow.SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO2";        //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region BO伝票番号3
                //if (string.IsNullOrEmpty(uoeOrderDtlWork.BOSlipNo3) == false)                 //DEL 2009/01/15 不具合対応[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivBO3 == 0)                                        //ADD 2009/01/15
                {
                    // 共通部コピー
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_BO3;                                  // 列区分
                    //gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo3;                         // 伝票番号// DEL BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応
                    gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo3;                         // 伝票番号// ADD BY 宋剛 2015/08/26 Redmine#47030 【№332】在庫入庫更新の障害対応
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt3;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt3;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt3;             // 入庫数(入力用)

                    // ---ADD 2009/01/16 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                        //gridMainRow.SlipNo = "BO3ﾊﾞﾝｺﾞｳﾅｼ";       //DEL 2009/01/19 文言変更
                        gridMainRow.SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO3";        //ADD 2009/01/19
                    }
                    // ---ADD 2009/01/16 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region ﾒｰｶｰ
                //if (uoeOrderDtlWork.MakerFollowCnt != 0)                                      //DEL 2009/01/15 不具合対応[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivMaker == 0)                                      //ADD 2009/01/15
                {
                    // 共通部コピー
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_MAKER;                                // 列区分
                    //gridMainRow.SlipNo = "";                                                // 伝票番号(スペース)     //DEL 2009/01/19
                    gridMainRow.SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ ﾒｰｶｰ";                                   // 伝票番号(スペース)       //ADD 2009/01/19
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.MakerFollowCnt;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.MakerFollowCnt;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.MakerFollowCnt;             // 入庫数(入力用)

                    // ---ADD 2009/01/19 --------------------------------------------------------------->>>>>
                    if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                    {
                    }
                    // ---ADD 2009/01/19 ---------------------------------------------------------------<<<<<

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion

                #region EO
                //if (uoeOrderDtlWork.EOAlwcCount != 0)                                         //DEL 2009/01/15 不具合対応[10068][10115]
                if (uoeOrderDtlWork.EnterUpdDivEO == 0)                                         //ADD 2009/01/15
                {
                    // 共通部コピー
                    gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRow(uoeOrderDtlWork);

                    gridMainRow.ColumnDiv = COLUMNDIV_EO;                                   // 列区分
                    //gridMainRow.SlipNo = "";                                                // 伝票番号(スペース)     //DEL 2009/01/19
                    gridMainRow.SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ EO";                                     // 伝票番号(スペース)       //ADD 2009/01/19
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.EOAlwcCount;                // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.EOAlwcCount;                     // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.EOAlwcCount;                // 入庫数(入力用)

                    this._gridMainTable.Rows.Add(gridMainRow);
                }
                #endregion
            }
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            Dictionary<string, Double> stockUnitPriceDic = new Dictionary<string,double>();       // カラー情報

            this._unitPriceCalculation.CacheRateProtyMngAllList(_rateProtyMngAllList);
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    string keyUnitPrice = unitPriceCalcRetWk.GoodsMakerCd.ToString() + unitPriceCalcRetWk.GoodsNo;
                    if (!stockUnitPriceDic.ContainsKey(keyUnitPrice))
                    {
                        stockUnitPriceDic.Add(keyUnitPrice, unitPriceCalcRetWk.UnitPriceTaxExcFl);
                    }
                }
            }
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

            #region 各グリッド用行No.付加
            int headerGridRowNo = 0;
            int detailGridRowNo = 0;
            String key = string.Empty;
            String keyPrice = string.Empty;// ADD wangf 2012/11/15 FOR Redmine#31980

            GridMainDataSet.GridMainTableRow mainRow = null;
            DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());
            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];
                keyPrice = mainRow.GoodsMakerCd.ToString() + mainRow.GoodsNo; // ADD wangf 2012/11/15 FOR Redmine#31980
                if (key == string.Empty)
                {
                    // 1件目
                    mainRow.HeaderGridRowNo = headerGridRowNo;       // ヘッダーグリッド用行No.
                    mainRow.DetailGridRowNo = detailGridRowNo;       // 明細グリッド用行No.
                    key = mainRow.OnlineNo + mainRow.SlipNo;

                    // ------------ADD yangmj 2012/12/17 FOR Redmine#31980--------->>>>
                    if (stockUnitPriceDic.ContainsKey(keyPrice))
                    {
                        // 原価単価（価格マスタより）
                        mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                    }
                    // ------------ADD yangmj 2012/12/17 FOR Redmine#31980---------<<<<
                    continue;
                }

                if (key != (mainRow.OnlineNo + mainRow.SlipNo))
                {
                    // 伝票番号が変わった時
                    headerGridRowNo++;
                }
                detailGridRowNo++;

                mainRow.HeaderGridRowNo = headerGridRowNo;           // ヘッダーグリッド用行No.
                mainRow.DetailGridRowNo = detailGridRowNo;           // 明細グリッド用行No.

                key = mainRow.OnlineNo + mainRow.SlipNo;
           		 // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                if (stockUnitPriceDic.ContainsKey(keyPrice))
                {
                    // 原価単価（価格マスタより）
                    mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                }
           		 // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            }
            #endregion
        }
        #endregion

        #region ▼CopyToGridMainRowFromUOEOrderDtlRow(UOE発注データ→UOE入庫更新メインデータ反映)
        /// <summary>
        /// UOE発注データ→UOE入庫更新メインデータ反映
        /// </summary>
        /// <param name="uoeOrderDtlRow">UOE発注データ</param>
        /// <returns>UOE入庫更新メインデータ</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データの内容をUOE入庫更新メインデータに反映します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
        /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
        /// </remarks>
        private GridMainDataSet.GridMainTableRow CopyToGridMainRowFromUOEOrderDtlWorkRow(UOEOrderDtlWork uoeOrderDtlWorkRow)
        {
            GridMainDataSet.GridMainTableRow gridMainRow = this._gridMainTable.NewGridMainTableRow();

            gridMainRow.DivCd = PMUOE01202EA.DIVCD_NOCHANGE;                            // 区分(" "：未処理、"1"：入荷、"2"：未入荷、"3"：修正、"9"：消込み)
            gridMainRow.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // メーカーコード
            gridMainRow.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // 品番
            gridMainRow.GoodsName = uoeOrderDtlWorkRow.GoodsName;                       // 品名
            gridMainRow.UOESalesOrderNo = uoeOrderDtlWorkRow.UOESalesOrderNo;           // UOE発注番号
            gridMainRow.UOESalesOrderRowNo = uoeOrderDtlWorkRow.UOESalesOrderRowNo;     // UOE発注行番号
            gridMainRow.OnlineNo = uoeOrderDtlWorkRow.OnlineNo;                         // オンライン番号
            gridMainRow.OnlineRowNo = uoeOrderDtlWorkRow.OnlineRowNo;                   // オンライン行番号
            gridMainRow.WarehouseCode = uoeOrderDtlWorkRow.WarehouseCode;               // 倉庫コード
            gridMainRow.WarehouseShelfNo = uoeOrderDtlWorkRow.WarehouseShelfNo;         // 棚番
            gridMainRow.SalesUnitCost = uoeOrderDtlWorkRow.SalesUnitCost;               // 原価単価
            gridMainRow.AnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // 回答原価単価
            gridMainRow.AnswerPartsNo = uoeOrderDtlWorkRow.AnswerPartsNo;               // 回答品番
            gridMainRow.UOERemark1 = uoeOrderDtlWorkRow.UoeRemark1;                     // リマーク1
            gridMainRow.UOERemark2 = uoeOrderDtlWorkRow.UoeRemark2;                     // リマーク2
            gridMainRow.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // 仕入先コード
            gridMainRow.SubstPartsNo = uoeOrderDtlWorkRow.SubstPartsNo;                 // 代替品番
            gridMainRow.SupplierSlipNo = uoeOrderDtlWorkRow.SupplierSlipNo;             // 仕入伝票番号
            gridMainRow.StockSlipDtlNumSrc = uoeOrderDtlWorkRow.StockSlipDtlNum;        // 仕入明細通番
            gridMainRow.HeaderGridRowNo = 0;                                            // UOE入庫更新ヘッダーグリッド用行番号
            gridMainRow.DetailGridRowNo = 0;                                            // UOE入庫更新明細グリッド用行番号
            gridMainRow.InputAnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // 回答原価単価
            gridMainRow.AnswerMakerCd = uoeOrderDtlWorkRow.AnswerMakerCd;               // 回答メーカーコード
            gridMainRow.UOESupplierCd = uoeOrderDtlWorkRow.UOESupplierCd;               // UOE発注先コード          //ADD 2009/01/19 不具合対応[10063]
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            gridMainRow.GoodspriceuSalesUnitCost = 0.0;                             

            GoodsUnitData unitData = new GoodsUnitData();
            unitData.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // 商品メーカーコード
            unitData.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // 商品番号
            unitData.GoodsRateRank = uoeOrderDtlWorkRow.GoodsRateRank;               // 商品掛率ランク
            unitData.BLGoodsCode = uoeOrderDtlWorkRow.BLGoodsCode;                   // BL商品コード
            unitData.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // 仕入先コード
            unitData.TaxationDivCd = uoeOrderDtlWorkRow.TaxationDivCd;               // 課税区分
            unitData.SectionCode = uoeOrderDtlWorkRow.SectionCode;

            List<GoodsPrice> goodsPriceList;
            goodsPriceList = new List<GoodsPrice>();
            GoodsPrice goodsPrice = new GoodsPrice();
            goodsPrice.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;
            goodsPrice.ListPrice = uoeOrderDtlWorkRow.PriceListPrice;
            goodsPrice.PriceStartDate = TDateTime.LongDateToDateTime(uoeOrderDtlWorkRow.PriceStartDate);
            goodsPrice.StockRate = uoeOrderDtlWorkRow.StockRate;
            goodsPrice.EnterpriseCode = uoeOrderDtlWorkRow.EnterpriseCode;
            goodsPrice.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;
            goodsPrice.LogicalDeleteCode = 0; // 論理削除区分
            goodsPrice.SalesUnitCost = uoeOrderDtlWorkRow.GoodspriceuSalesUnitCost;
            goodsPriceList.Add(goodsPrice);
            unitData.GoodsPriceList = goodsPriceList;
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);

            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = unitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = unitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = unitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = unitData.GoodsMGroup;                            // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = unitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = unitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = unitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                              // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = unitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);    // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = unitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = unitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            goodsUnitDataList.Add(unitData);
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

            return gridMainRow;
        }
        #endregion

        #region ▼CopyToGridMainFromHeaderGrid(ヘッダーグリッドデータ→UOE入庫更新メインデータ反映)
        /// <summary>
        /// ヘッダーグリッドデータ→UOE入庫更新メインデータ反映
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダーグリッドデータの内容をUOE入庫更新メインデータに反映します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CopyToGridMainFromHeaderGrid()
        {
            GridMainDataSet.GridMainTableRow mainRow = null;
            HeaderGridDataSet.HeaderTableRow headerGridRow = null;
            for (int index = 0; index <= this._gridMainTable.Rows.Count - 1; index++)
            {
                mainRow = (GridMainDataSet.GridMainTableRow)this._gridMainTable.Rows[index];

                DataView dv = new DataView(this._headerDataSet.HeaderTable);
                dv.Sort = "No";

                // 抽出
                int index2 = dv.Find(mainRow.HeaderGridRowNo);
                // ---ADD 2009/02/18 分納時、指定された伝票番号の明細のみ表示する為 ---------------->>>>>
                if (index2 == -1)
                {
                    continue;
                }
                // ---ADD 2009/02/18 分納時、指定された伝票番号の明細のみ表示する為 ----------------<<<<<

                headerGridRow = (HeaderGridDataSet.HeaderTableRow)this._headerDataSet.HeaderTable.Rows[index2];

                mainRow.InputSlipNo = headerGridRow.SlipNo;     // 伝票番号
            }
        }
        #endregion

        #region ▼CopyToGridMainFromDetailGrid(明細グリッドデータ→UOE入庫更新メインデータ反映)
        /// <summary>
        /// 明細グリッドデータ→UOE入庫更新メインデータ反映
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッドデータの内容をUOE入庫更新メインデータに反映します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CopyToGridMainFromDetailGrid()
        {
            GridMainDataSet.GridMainTableRow mainRow = null;
            DetailGridDataSet.DetailTableRow detailGridRow = null;
            for (int index = 0; index <= this._detailDataSet.DetailTable.Rows.Count - 1; index++)
            {
                detailGridRow = (DetailGridDataSet.DetailTableRow)this._detailDataSet.DetailTable.Rows[index];
                // 対応する行取得
                mainRow = this._gridMainTable.FindBySupplierCdSlipNoOnlineNoOnlineRowNo(detailGridRow.SupplierCd, detailGridRow.SlipNo, detailGridRow.OnlineNo, detailGridRow.OnlineRowNo);

                mainRow.DivCd = detailGridRow.DivCd;                                            // 区分
                mainRow.InputEnterCnt = detailGridRow.InputEnterCnt;                            // 入庫数(入力値)
                mainRow.InputAnswerSalesUnitCost = detailGridRow.InputAnswerSalesUnitCost;      // 原価単価(入力値)
            }
        }
        #endregion

        #region ▼GetGridMainTableSortCondition(UOE入庫更新メインデータ用ソート条件取得)
        /// <summary>
        /// UOE入庫更新メインデータ用ソート条件取得
        /// </summary>
        /// <returns>ソート条件</returns>
        /// <remarks>
        /// <br>Note       : UOE入庫更新メインデータ用のソート条件を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private string GetGridMainTableSortCondition()
        {
            // 仕入先、伝票番号、オンライン番号、オンライン行番号の順
            string sortCondition = string.Empty;
            sortCondition = string.Format("{0},{1},{2},{3}"
                                    //, this._gridMainTable.SupplierCdColumn.ColumnName             //DEL 2009/01/19 不具合対応[10063]
                                    , this._gridMainTable.UOESupplierCdColumn.ColumnName            //ADD 2009/01/19
                                    , this._gridMainTable.SlipNoColumn.ColumnName
                                    , this._gridMainTable.OnlineNoColumn.ColumnName
                                    , this._gridMainTable.OnlineRowNoColumn.ColumnName);
            return sortCondition;
        }
        #endregion

        // ヘッダー用データ作成
        #region ▼CreateHeaderGridDataSet(ヘッダーグリッドデータ作成)
        /// <summary>
        /// ヘッダーグリッドデータ作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE入庫更新メインデータからヘッダーグリッドデータを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateHeaderGridDataSet()
        {
            // データクリア
            this.ClearUOEEnterUpdHeaderData();

            // ソートを行い、その順番にヘッダーデータを追加
            int key = -1;
            HeaderGridDataSet.HeaderTableRow headerRow = null;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            //DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());      //DEL 2009/02/18 分納時、指定された伝票番号の明細のみ表示する為
            // ---ADD 2009/02/18 分納時、指定された伝票番号の明細のみ表示する為 ---------------->>>>>
            string filter = string.Empty;
            if (string.IsNullOrEmpty(this._searchBackup.SlipNo.TrimEnd()) == false)
            {
                filter = string.Format("{0}='{1}'", this._gridMainTable.SlipNoColumn.ColumnName, this._searchBackup.SlipNo.TrimEnd());
            }
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());
            // ---ADD 2009/02/18 分納時、指定された伝票番号の明細のみ表示する為 ----------------<<<<<
            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];
                if (key != gridMainRow.HeaderGridRowNo)
                {
                    // ヘッダーデータ取得
                    headerRow = this.CopyToHeaderGridFromGridMain(gridMainRow);

                    // 合計取得
                    double total = this.CaluclateTotalFromGridMainTable(gridMainRow.HeaderGridRowNo);
                    headerRow.Total = total;

                    this._headerDataSet.HeaderTable.Rows.Add(headerRow);
                }

                key = gridMainRow.HeaderGridRowNo;
            }
        }
        #endregion

        #region ▼CopyToHeaderGridFromGridMain(UOE入庫更新メインデータ→ヘッダーグリッドデータ反映)
        /// <summary>
        /// UOE入庫更新メインデータ→ヘッダーグリッドデータ反映
        /// </summary>
        /// <param name="mainRow">UOE入庫更新メインデータ</param>
        /// <returns>ヘッダーグリッドデータ</returns>
        /// <remarks>
        /// <br>Note       : UOE入庫更新メインデータの内容をヘッダーグリッドデータに反映します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private HeaderGridDataSet.HeaderTableRow CopyToHeaderGridFromGridMain(GridMainDataSet.GridMainTableRow mainRow)
        {
            HeaderGridDataSet.HeaderTableRow headerRow = this._headerDataSet.HeaderTable.NewHeaderTableRow();

            headerRow.No = mainRow.HeaderGridRowNo;     // ヘッダー行No.
            headerRow.DivCd = mainRow.DivCd;            // 区分
            headerRow.SlipNo = mainRow.SlipNo;          // 伝票番号
            headerRow.Remark = mainRow.UOERemark1;      // リマーク
            headerRow.Total = 0;                        // 合計

            return headerRow;
        }
        #endregion

        // 明細用データ作成
        #region ▼CreateDetailGridDataSet(明細グリッドデータ作成)
        /// <summary>
        /// 明細グリッドデータ作成
        /// </summary>
        /// <param name="headerRowNo">ヘッダーグリッド行番号</param>
        /// <remarks>
        /// <br>Note       : UOE入庫更新メインデータから明細グリッドデータを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateDetailGridDataSet(int headerRowNo)
        {
            // 前回と同じ行の場合は処理をしない
            if (headerRowNo == this._prevHeaderRowNo)
            {
                return;
            }

            // 初回以外は入力値を保存
            if (this._prevHeaderRowNo != -1)
            {
                this.CopyToGridMainFromDetailGrid();
            }

            // データクリア
            this.ClearUOEEnterUpdDetailData();

            // 抽出
            DetailGridDataSet.DetailTableRow detailRow = null;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            string filter = string.Format("{0} = {1}", this._gridMainTable.HeaderGridRowNoColumn.ColumnName, headerRowNo);
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());
            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                // 明細データ追加
                detailRow = this.CopyToDetailGridFromGridMain(gridMainRow);
                this._detailDataSet.DetailTable.Rows.Add(detailRow);
            }

            this._prevHeaderRowNo = headerRowNo;
        }
        #endregion

        #region ▼CopyToGridDetailFromGridMain(UOE入庫更新メインデータ→UOE入庫更新明細用データ反映)
        /// <summary>
        /// UOE入庫更新メインデータ→明細グリッドデータ反映
        /// </summary>
        /// <param name="gridMainRow">UOE入庫更新メインデータ</param>
        /// <returns>明細グリッドデータ</returns>
        /// <remarks>
        /// <br>Note       : UOE入庫更新メインデータの内容を明細グリッドデータに反映します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
        /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
        /// </remarks>
        private DetailGridDataSet.DetailTableRow CopyToDetailGridFromGridMain(GridMainDataSet.GridMainTableRow gridMainRow)
        {
            DetailGridDataSet.DetailTableRow detailRow = this._detailDataSet.DetailTable.NewDetailTableRow();

            detailRow.No = gridMainRow.DetailGridRowNo;                                 // 明細行No.
            detailRow.DivCd = gridMainRow.DivCd;                                        // 区分
            detailRow.EnterCnt = gridMainRow.EnterCnt;                                  // 入庫数
            detailRow.GoodsName = gridMainRow.GoodsName;                                // 品名
            detailRow.GoodsNo = gridMainRow.GoodsNo;                                    // 品番
            detailRow.WarehouseCode = gridMainRow.WarehouseCode;                        // 倉庫コード
            detailRow.SectionCnt = gridMainRow.UOESectOutGoodsCnt;                      // 回答
            detailRow.BOCnt = gridMainRow.BOShipmentCnt;                                // BO数
            detailRow.SalesUnitCost = gridMainRow.SalesUnitCost;                        // 原単価
            detailRow.AnswerSalesUnitCost = gridMainRow.AnswerSalesUnitCost;            // 回答原単価
            detailRow.SubstPartsNo = gridMainRow.SubstPartsNo;                          // 代替品番
            detailRow.SupplierCd = gridMainRow.SupplierCd;                              // 仕入先コード
            detailRow.SlipNo = gridMainRow.SlipNo;                                      // 納品No,
            detailRow.OnlineNo = gridMainRow.OnlineNo;                                  // オンライン番号
            detailRow.OnlineRowNo = gridMainRow.OnlineRowNo;                            // オンライン行番号
            detailRow.AnswerPartsNo = gridMainRow.AnswerPartsNo;                        // 回答品番
            detailRow.InputEnterCnt = gridMainRow.InputEnterCnt;                        // 入庫数(入力用)
            detailRow.InputAnswerSalesUnitCost = gridMainRow.InputAnswerSalesUnitCost;  // 回答原価単価(入力用)
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            // 原単価（価格マスタより）
            detailRow.GoodspriceuSalesUnitCost = gridMainRow.GoodspriceuSalesUnitCost;
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            /* ---DEL 2009/01/16 不具合対応[10145] ----------------------------------------------------->>>>>
            // 代替品
            if (string.IsNullOrEmpty(detailRow.SubstPartsNo.TrimEnd()) == false)
            {
                detailRow.GoodsName = detailRow.SubstPartsNo;
            }
               ---DEL 2009/01/16 不具合対応[10145] -----------------------------------------------------<<<<< */
            // ---ADD 2009/01/16 不具合対応[10145] ----------------------------------------------------->>>>>
            // 代替品(代替品番採用時のみ)
            if (this._stockBlnktPrtNoDiv == 0)
            {
                if (string.IsNullOrEmpty(detailRow.SubstPartsNo.TrimEnd()) == false)
                {
                    detailRow.GoodsNo = detailRow.SubstPartsNo;
                }
            }
            // ---ADD 2009/01/16 不具合対応[10145] -----------------------------------------------------<<<<<

            // 棚番
            //if (gridMainRow.WarehouseCode == "0")                             //DEL 2009/02/17 不具合対応[11238]
            if (string.IsNullOrEmpty(gridMainRow.WarehouseCode.TrimEnd()))      //ADD 2009/02/17 不具合対応[11238]
            {
                detailRow.WarehouseShelfNo = "取寄";
            }
            else
            {
                detailRow.WarehouseShelfNo = gridMainRow.WarehouseShelfNo;
            }

            // 在庫有無
            detailRow.StockExists = this.CheckStockIsExists(gridMainRow);

            return detailRow;
        }
        #endregion

        // 仕入先用
        #region ▼CreateUOEOrderDtlHTable(仕入先HashTable作成)
        /// <summary>
        /// 仕入先HashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先マスタを元にHashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateSupplierHTable()
        {
            ArrayList array = null;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.Search(out array, this._enterpriseCode);
            if (status != 0)
            {
                this._supplierHTable = null;
                return;
            }
            if (array == null)
            {
                this._supplierHTable = null;
                return;
            }

            // HashTable作成
            this._supplierHTable = new Hashtable();
            Supplier supplier = null;
            for (int index = 0; index <= array.Count - 1; index++)
            {
                supplier = (Supplier)array[index];
                if (this._supplierHTable.ContainsKey(supplier.SupplierCd) == false)
                {
                    this._supplierHTable[supplier.SupplierCd] = supplier;
                }
            }
        }
        #endregion

        #region ▼GetSupplierNameFromSupplierHTable(仕入先名称取得)
        /// <summary>
        /// 仕入先名称取得
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierName">仕入先名称</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : 仕入先コードを元に仕入先HashTableから仕入先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool GetSupplierNameFromSupplierHTable(int supplierCd, out string supplierName)
        {
            supplierName = string.Empty;     // なし
            if (this.HashTableIsNullOrEmpty(this._supplierHTable, supplierCd))
            {
                return false;
            }

            // HashTableより取得
            Supplier supplier = (Supplier)this._supplierHTable[supplierCd];
            supplierName = supplier.SupplierSnm;

            return true;
        }
        #endregion

        // ---ADD 2009/01/19 不具合対応[10063] ------------------------------------------------------------------------>>>>>
        //UOE発注先用
        #region ▼CreateUOESupplierHTable(HashTable作成)
        /// <summary>
        /// UOE発注先マスタHashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタを元にHashTableを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private void CreateUOESupplierHTable()
        {
            DataSet retDataSet = new DataSet();

            // UOE発注先マスタデータ取得(PMUOE09022A)
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            int status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            // 異常
            if (status != 0)
            {
                this._uoeSupplierHTable = null;
                return;
            }
            // データなし
            if (retDataSet == null)
            {
                this._uoeSupplierHTable = null;
                return;
            }

            // HashTable作成
            this._uoeSupplierHTable = new Hashtable();
            foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
            {
                int key = 0;
                int.TryParse(dataRow["UoeSupplierCd"].ToString(), out key);

                this._uoeSupplierHTable[key] = dataRow;
            }
        }
        #endregion


        #region ▼GetUOESupplierNameFromUOESupplierHTable(UOE発注先名称取得)
        /// <summary>
        /// UOE発注先名称取得
        /// </summary>
        /// <param name="supplierCd">UOE発注先コード</param>
        /// <param name="supplierName">UOE発注先名称</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元に仕入先HashTableからUOE発注先名称を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool GetUOESupplierNameFromUOESupplierHTable(int uoeSupplierCd, out string uoeSupplierName)
        {
            uoeSupplierName = string.Empty;     // なし
            if (this.HashTableIsNullOrEmpty(this._uoeSupplierHTable, uoeSupplierCd))
            {
                return false;
            }

            // HashTableより取得
            DataRow dataRow = (DataRow)this._uoeSupplierHTable[uoeSupplierCd];
            uoeSupplierName = dataRow["UOESupplierName"].ToString();

            return true;
        }
        #endregion
        // ---ADD 2009/01/19 不具合対応[10063] ------------------------------------------------------------------------<<<<<

        // ------------ADD yangmj 2012/12/17 FOR Redmine#32926--------->>>>
        #region ▼GetUOESupplierVerFromUOESupplierHTable(UOE発注先名称取得)
        /// <summary>
        /// 接続バージョン区分取得
        /// </summary>
        /// <param name="supplierCd">UOE発注先コード</param>
        /// <param name="uoeSupplierVer">接続バージョン区分</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先コードを元に仕入先HashTableから接続バージョン区分を取得します。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/12/17</br>
        /// </remarks>
        private bool GetUOESupplierVerFromUOESupplierHTable(int uoeSupplierCd, out string uoeSupplierVer)
        {
            uoeSupplierVer = string.Empty;     // なし
            if (this.HashTableIsNullOrEmpty(this._uoeSupplierHTable, uoeSupplierCd))
            {
                return false;
            }

            // HashTableより取得
            DataRow dataRow = (DataRow)this._uoeSupplierHTable[uoeSupplierCd];

            string stockSlipDtRecvDiv = dataRow["StockSlipDtRecvDiv"].ToString();
            string receiveCondition = dataRow["ReceiveCondition"].ToString();
            if ("1".Equals(stockSlipDtRecvDiv) && "1".Equals(receiveCondition))   // 仕入受信区分(=1：あり）&& 送信のみ
            {
                uoeSupplierVer = dataRow["ConnectVersionDiv"].ToString();
                return true;
            }

            return false;
        }
        #endregion
        // ------------ADD yangmj 2012/12/17 FOR Redmine#32926---------<<<<
        // 共通
        #region ▼CheckStockIsExists(在庫存在チェック)
        /// <summary>
        /// 在庫存在チェック
        /// </summary>
        /// <param name="row">メインテーブル行</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : 在庫チェックを行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool CheckStockIsExists(GridMainDataSet.GridMainTableRow row)
        {
            /* ---DEL 2009/02/17 不具合対応[11238] ------------------------>>>>>
            if (row.WarehouseCode == "0")
            {
                return false;
            }
               ---DEL 2009/02/17 不具合対応[11238] ------------------------<<<<< */
            // ---ADD 2009/02/17 不具合対応[11238] ------------------------>>>>>
            if (string.IsNullOrEmpty(row.WarehouseCode))
            {
                return true;
            }
            // ---ADD 2009/02/17 不具合対応[11238] ------------------------<<<<<

            int goodsMakerCd = 0;
            string goodsNo = string.Empty;

            // 0：代替品採用時
            if (this._stockBlnktPrtNoDiv == 0)
            {
                // 代替品番がスペース以外の場合
                if (string.IsNullOrEmpty(row.SubstPartsNo.TrimEnd()) == false)
                {
                    goodsNo = row.SubstPartsNo;         // 代替品番
                    goodsMakerCd = row.AnswerMakerCd;   // 回答メーカーコード
                }
                else
                {
                    goodsNo = row.GoodsNo;              // 品番
                    goodsMakerCd = row.GoodsMakerCd;    // メーカーコード
                }
            }
            // 1：発注品採用時
            else
            {
                goodsNo = row.GoodsNo;              // 品番
                goodsMakerCd = row.GoodsMakerCd;    // メーカーコード
            }

            string msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            // 抽出条件
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = goodsMakerCd;
            goodsCndtn.GoodsNo = goodsNo;
            
            // 検索
            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out msg);
            /* ---DEL 2009/01/15 不具合対応[10059] ---------------------------------------->>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return true;        // あり
            }
            else
            {
                return false;       // なし
            }
               ---DEL 2009/01/15 不具合対応[10059] ----------------------------------------<<<<< */
            // ---ADD 2009/01/15 不具合対応[10059] ---------------------------------------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return false;
            }
            // 関連する在庫情報取得
            List<Stock> stockList = goodsUnitDataList[0].StockList;
            if (stockList == null)
            {
                return false;
            }
            if (stockList.Count == 0)
            {
                return false;
            }
            // 抽出条件
            string warehouseCode = row.WarehouseCode.TrimEnd();

            // 検索(在庫情報を画面の値で絞り込む)
            Stock stock = this._goodsAcs.GetStockFromStockList(warehouseCode, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, stockList);
            if (stock == null)
            {
                return false;
            }

            return true;
            // ---ADD 2009/01/15 不具合対応[10059] ----------------------------------------<<<<<
        }
        #endregion

        #region ▼CaluclateTotalFromGridMainTable(合計取得)
        /// <summary>
        /// 合計取得
        /// </summary>
        /// <param name="headerRowNo">ヘッダーグリッド行番号</param>
        /// <returns>計算結果</returns>
        /// <remarks>
        /// <br>Note       : UOE入庫更新メインデータからヘッダーグリッドの合計を求めます。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private double CaluclateTotalFromGridMainTable(int headerRowNo)
        {
            // 抽出
            Double total = 0;
            GridMainDataSet.GridMainTableRow gridMainRow = null;

            string filter = string.Format("{0} = {1}", this._gridMainTable.HeaderGridRowNoColumn.ColumnName, headerRowNo);
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());

            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                gridMainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                // 合計
                total = total + (gridMainRow.InputEnterCnt * gridMainRow.InputAnswerSalesUnitCost);
            }

            return total;
        }
        #endregion

        #region ▼CheckSupplierCdIsExists(仕入先存在チェック)
        /// <summary>
        /// 仕入先存在チェック
        /// </summary>
        /// <param name="rowNo">チェック対象のヘッダーグリッド行No</param>
        /// <returns>True：データあり、False：データなし</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データ上の仕入先を元に仕入先マスタ存在チェックを行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public bool CheckSupplierCdIsExists(int rowNo)
        {
            // 買掛オプションなしの場合、無条件でチェックOKとする
            if (this._stockingPaymentOption == false)
            {
                return true;
            }

            // UOE発注データ上の仕入先を取得
            string filter = string.Format("{0} = {1}", this._gridMainTable.HeaderGridRowNoColumn.ColumnName, rowNo);
            DataRow[] dataRows = this._gridMainTable.Select(filter, this.GetGridMainTableSortCondition());

            int supplierCd = ((GridMainDataSet.GridMainTableRow)dataRows[0]).SupplierCd;

            // 仕入先マスタ存在チェック
            if (this.HashTableIsNullOrEmpty(this._supplierHTable, supplierCd))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ▼HashTableIsNullOrDataNothing(HashTableデータ存在チェック)
        /// <summary>
        /// HashTableデータ存在チェック
        /// </summary>
        /// <param name="hashTable">チェック対象HashTable</param>
        /// <param name="key">チェック対象key</param>
        /// <returns>True:データなし、False:データあり</returns>
        /// <remarks>
        /// <br>Note       : Keyで指定されたデータがHashTableに存在するかチェックを行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool HashTableIsNullOrEmpty(Hashtable hashTable, int key)
        {
            // データが無い
            if (hashTable == null)
            {
                return true;
            }

            // INDEX範囲外
            if (hashTable.ContainsKey(key) == false)
            {
                return true;
            }
            return false;
        }
        #endregion

        // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
        #region 原単価取得処理
        /// <summary>
        /// 単価算出クラス初期データ読込処理
        /// </summary>
        private void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// 掛率優先管理検索
        /// </summary>
        private void SearchRateProtyMng()
        {
            _rateProtyMngAllList = new List<RateProtyMng>();
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();

            bool nextdata;
            int totalcnt;
            string msg;
            ArrayList list;
            rateProtyMngAcs.Search(out list, out totalcnt, out nextdata, this._enterpriseCode, "", out msg);

            if (list != null)
            {
                _rateProtyMngAllList = new List<RateProtyMng>();
                _rateProtyMngAllList.AddRange((RateProtyMng[])list.ToArray(typeof(RateProtyMng)));

                // 拠点、単価種類、優先順位でソート
                _rateProtyMngAllList.Sort(new RateProtyMngComparer());
            }
        }

        #endregion
        // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
        /// <summary>
        /// 明治産業の判断
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>明治産業の判断結果</returns>
        /// <remarks>
        /// <br>Note       : 明治産業の判断を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/16</br>
        /// </remarks>
        private bool IsMEIJI(int uoeSupplierCd)
        {
            //※発注先マスタ
            //①受信有無区分：送信のみ
            //②仕入受信区分：あり
            string ver = string.Empty;
            if (GetUOESupplierVerFromUOESupplierHTable(uoeSupplierCd, out ver))
            {
                return true;
            }

            return false;
        }
        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459----------<<<<

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼ハンディターミナル在庫仕入登録の対応
        // ===================================================================================== //
        // コンストラクタ（ハンディターミナル用）
        // ===================================================================================== //
        # region ■Constracter
        /// <summary>
        /// コンストラクタ（ハンディターミナル用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="status">初期化ステータス「0：成功  0以外：失敗」</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public PMUOE01203AA(string enterpriseCode, string sectionCode, out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 

            try
            {
                //　企業コードを取得する
                this._enterpriseCode = enterpriseCode;

                // 買掛オプションを取得する
                this._stockingPaymentOption = this.CheckOption();

                // アクセスクラスインスタンス化
                string msg = string.Empty;
                this._goodsAcs = new GoodsAcs();
                this._goodsAcs.IsGetSupplier = true;
                status = this._goodsAcs.SearchInitial(this._enterpriseCode, sectionCode, out msg);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                this._taxRateSetAcs = new TaxRateSetAcs();
                // 税率設定マスタ取得(税率コード=0固定)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, this._enterpriseCode, TaxRateCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                this._unitPriceCalculation = new UnitPriceCalculation();
                this._stockProcMoneyAcs = new StockProcMoneyAcs();

                // 単価算出クラス初期データ読込処理
                ReadInitData();
                
                // 掛率優先管理検索
                SearchRateProtyMng();

                // 入庫更新用リモートオブジェクト取得
                this._iUOEStockUpdateDB = (IUOEStockUpdateDB)MediationUOEStockUpdateDB.GetUOEStockUpdateDB();

                // 表示DataSetインスタンス化(データなし、グリッドレイアウト設定のみ)
                this._headerDataSet = new HeaderGridDataSet();      // ヘッダーグリッド用
                this._detailDataSet = new DetailGridDataSet();      // 明細グリッド用

                // 仕入先データHashTable作成
                this.CreateSupplierHTable();

                // UOE発注先データHashTable作成
                this.CreateUOESupplierHTableForHandy(sectionCode);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 
            }
        }
        # endregion

        /// <summary>
        /// UOE発注先マスタHashTable作成（ハンディターミナル用）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>UOE発注先マスタHashTable作成結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタを元にHashTableを作成します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int CreateUOESupplierHTableForHandy(string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                DataSet retDataSet = new DataSet();

                // UOE発注先マスタデータ取得(PMUOE09022A)
                UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
                status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode, sectionCode);

                // 異常
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._uoeSupplierHTable = null;
                    return status;
                }
                // データなし
                if (retDataSet == null)
                {
                    this._uoeSupplierHTable = null;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }

                // HashTable作成
                this._uoeSupplierHTable = new Hashtable();
                foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
                {
                    int key = 0;
                    int.TryParse(dataRow[UoeSupplierCd].ToString(), out key);

                    this._uoeSupplierHTable[key] = dataRow;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// UOE発注データ情報検索処理（ハンディターミナル用）
        /// </summary>
        /// <param name="uoeEnterUpdCndtn">UOE発注データ検索条件</param>
        /// <returns>検索結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : 条件に沿って検索を行います。取得したデータを元に各種HashTableを作成します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetSearchDataForHandy(UOEStockUpdSearch uoeStockUpdSearch)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 初期化
                this.ClearUOEEnterUpdHeaderData();
                this.ClearUOEEnterUpdDetailData();

                // 条件作成
                UOEStockUpdSearchWork uoeStockUpdSearchWork = new UOEStockUpdSearchWork();
                uoeStockUpdSearchWork.EnterpriseCode = uoeStockUpdSearch.EnterpriseCode;
                uoeStockUpdSearchWork.SectionCode = uoeStockUpdSearch.SectionCode.Trim();
                uoeStockUpdSearchWork.ProcDiv = uoeStockUpdSearch.ProcDiv;
                uoeStockUpdSearchWork.UOESupplierCd = uoeStockUpdSearch.UOESupplierCd;

                // データ抽出
                object retObject = new CustomSerializeArrayList();
                status = this._iUOEStockUpdateDB.Search(uoeStockUpdSearchWork, ref retObject, 0, ConstantManagement.LogicalMode.GetData0);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                CustomSerializeArrayList uoeStcUpdDataList = (CustomSerializeArrayList)retObject;
                if ((uoeStcUpdDataList == null) || (uoeStcUpdDataList.Count == 0))
                {
                    return status;
                }

                this._searchBackup = uoeStockUpdSearchWork;

                ArrayList arrayList = null;
                // 各種データ取り込み
                for (int index = 0; index <= uoeStcUpdDataList.Count - 1; index++)
                {
                    arrayList = (ArrayList)uoeStcUpdDataList[index];
                    if (arrayList.Count == 0)
                    {
                        continue;
                    }

                    // 仕入データ→HashTable
                    if (arrayList[0] is StockSlipWork)
                    {
                        this.CreateStockSlipWorkHTable(arrayList);
                    }
                    // 仕入明細データ→HashTable
                    else if (arrayList[0] is StockDetailWork)
                    {
                        this.CreateStockDetailWorkHTable(arrayList);
                    }
                    // UOE発注データ→DataSet(グリッドとの連携の為)
                    else if (arrayList[0] is UOEOrderDtlWork)
                    {
                        // バックアップ(更新時に使用)
                        //this._uoeOrderDtlWorkList = arrayList;
                        this.CreateUOEOrderDtlWorkHTable(arrayList);

                        // UOE発注データ→グリッドメインデータ
                        this.CreateGridMainTableForHandy(uoeStockUpdSearch.SectionCode.Trim(),arrayList);
                        // グリッドメインデータ→UOE入庫更新ヘッダー用データ
                        this.CreateHeaderGridDataSet();

                        // グリッドメインデータ→UOE入庫更新明細用データ
                        this.CreateDetailGridDataSet(0);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// UOE入庫更新メインデータ作成（ハンディターミナル用）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="uoeOrderList">UOE発注リスト</param>
        /// <returns>UOE入庫更新メインデータ作成ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データからUOE入庫更新メインデータを取得します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int CreateGridMainTableForHandy(string sectionCode, ArrayList uoeOrderList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                UOEOrderDtlWork uoeOrderDtlWork = null;

                // UOE入庫更新メインテーブルインスタンス作成
                this._gridMainTable = new GridMainDataSet.GridMainTableDataTable();

                // 伝票番号単位に展開
                GridMainDataSet.GridMainTableRow gridMainRow = null;

                for (int index = 0; index <= uoeOrderList.Count - 1; index++)
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)uoeOrderList[index];

                    UOEOrderDtlWork tempUoeOrderDtlWork = new UOEOrderDtlWork();
                    tempUoeOrderDtlWork.UOESectionSlipNo = uoeOrderDtlWork.UOESectionSlipNo;
                    tempUoeOrderDtlWork.CommAssemblyId = uoeOrderDtlWork.CommAssemblyId;
                    tempUoeOrderDtlWork.BOSlipNo1 = uoeOrderDtlWork.BOSlipNo1;
                    tempUoeOrderDtlWork.BOSlipNo2 = uoeOrderDtlWork.BOSlipNo2;
                    tempUoeOrderDtlWork.BOSlipNo3 = uoeOrderDtlWork.BOSlipNo3;
                    // 重複のBO伝票番号編集処理
                    UpdBOSlipNo(ref tempUoeOrderDtlWork);

                    #region UOE拠点伝票番号
                    if (uoeOrderDtlWork.EnterUpdDivSec == EnterUpdDivSecData0)
                    {
                        // 共通部コピー
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_SECTION;                              // 列区分
                        gridMainRow.SlipNo = uoeOrderDtlWork.UOESectionSlipNo;                  // 伝票番号
                        gridMainRow.UOESectOutGoodsCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;    // UOE拠点出庫数
                        gridMainRow.BOShipmentCnt = 0;                                          // BO出庫数
                        gridMainRow.EnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;              // 入庫数
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;         // 入庫数(入力用)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivSecSlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region BO伝票番号1
                    if (uoeOrderDtlWork.EnterUpdDivBO1 == EnterUpdDivBO1Data0)
                    {
                        // 共通部コピー
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_BO1;                                  // 列区分
                        gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo1;                         // 伝票番号
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt1;             // BO出庫数
                        gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt1;                  // 入庫数
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt1;             // 入庫数(入力用)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivBO1SlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region BO伝票番号2
                    if (uoeOrderDtlWork.EnterUpdDivBO2 == EnterUpdDivBO2Data0)
                    {
                        // 共通部コピー
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_BO2;                                  // 列区分
                        gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo2;                         // 伝票番号
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt2;             // BO出庫数
                        gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt2;                  // 入庫数
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt2;             // 入庫数(入力用)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivBO2SlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region BO伝票番号3
                    if (uoeOrderDtlWork.EnterUpdDivBO3 == EnterUpdDivBO3Data0)
                    {
                        // 共通部コピー
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_BO3;                                  // 列区分
                        gridMainRow.SlipNo = tempUoeOrderDtlWork.BOSlipNo3;                         // 伝票番号
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt3;             // BO出庫数
                        gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt3;                  // 入庫数
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt3;             // 入庫数(入力用)

                        if (string.IsNullOrEmpty(gridMainRow.SlipNo.Trim()))
                        {
                            gridMainRow.SlipNo = EnterUpdDivBO3SlipNo;
                        }

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region ﾒｰｶｰ
                    if (uoeOrderDtlWork.EnterUpdDivMaker == EnterUpdDivMakerData0)
                    {
                        // 共通部コピー
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_MAKER;                                // 列区分
                        gridMainRow.SlipNo = EnterUpdDivMakerSlipNo;                            // 伝票番号(スペース)
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.MakerFollowCnt;             // BO出庫数
                        gridMainRow.EnterCnt = uoeOrderDtlWork.MakerFollowCnt;                  // 入庫数
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.MakerFollowCnt;             // 入庫数(入力用)

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion

                    #region EO
                    if (uoeOrderDtlWork.EnterUpdDivEO == EnterUpdDivEOData0)
                    {
                        // 共通部コピー
                        gridMainRow = this.CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(sectionCode, uoeOrderDtlWork);

                        gridMainRow.ColumnDiv = COLUMNDIV_EO;                                   // 列区分
                        gridMainRow.SlipNo = EnterUpdDivEOSlipNo;                               // 伝票番号(スペース)
                        gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                        gridMainRow.BOShipmentCnt = uoeOrderDtlWork.EOAlwcCount;                // BO出庫数
                        gridMainRow.EnterCnt = uoeOrderDtlWork.EOAlwcCount;                     // 入庫数
                        gridMainRow.InputEnterCnt = uoeOrderDtlWork.EOAlwcCount;                // 入庫数(入力用)

                        this._gridMainTable.Rows.Add(gridMainRow);
                    }
                    #endregion
                }

                List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
                Dictionary<string, Double> stockUnitPriceDic = new Dictionary<string, double>();       // カラー情報

                this._unitPriceCalculation.CacheRateProtyMngAllList(_rateProtyMngAllList);
                this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
                foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
                {
                    if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                    {
                        string keyUnitPrice = unitPriceCalcRetWk.GoodsMakerCd.ToString() + unitPriceCalcRetWk.GoodsNo;
                        if (!stockUnitPriceDic.ContainsKey(keyUnitPrice))
                        {
                            stockUnitPriceDic.Add(keyUnitPrice, unitPriceCalcRetWk.UnitPriceTaxExcFl);
                        }
                    }
                }

                #region 各グリッド用行No.付加
                int headerGridRowNo = 0;
                int detailGridRowNo = 0;
                String key = string.Empty;
                String keyPrice = string.Empty;

                GridMainDataSet.GridMainTableRow mainRow = null;
                DataRow[] dataRows = this._gridMainTable.Select(string.Empty, this.GetGridMainTableSortCondition());
                for (int index = 0; index <= dataRows.Length - 1; index++)
                {
                    mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];
                    keyPrice = mainRow.GoodsMakerCd.ToString() + mainRow.GoodsNo;
                    if (key == string.Empty)
                    {
                        // 1件目
                        mainRow.HeaderGridRowNo = headerGridRowNo;       // ヘッダーグリッド用行No.
                        mainRow.DetailGridRowNo = detailGridRowNo;       // 明細グリッド用行No.
                        key = mainRow.OnlineNo + mainRow.SlipNo;

                        if (stockUnitPriceDic.ContainsKey(keyPrice))
                        {
                            // 原価単価（価格マスタより）
                            mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                        }
                        continue;
                    }

                    if (key != (mainRow.OnlineNo + mainRow.SlipNo))
                    {
                        // 伝票番号が変わった時
                        headerGridRowNo++;
                    }
                    detailGridRowNo++;

                    mainRow.HeaderGridRowNo = headerGridRowNo;           // ヘッダーグリッド用行No.
                    mainRow.DetailGridRowNo = detailGridRowNo;           // 明細グリッド用行No.

                    key = mainRow.OnlineNo + mainRow.SlipNo;

                    if (stockUnitPriceDic.ContainsKey(keyPrice))
                    {
                        // 原価単価（価格マスタより）
                        mainRow.GoodspriceuSalesUnitCost = stockUnitPriceDic[keyPrice];
                    }
                }
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                // 処理なし
            }
            return status;
        }

        /// <summary>
        /// UOE発注データ→UOE入庫更新メインデータ反映（ハンディターミナル用）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="uoeOrderDtlRow">UOE発注データ</param>
        /// <returns>UOE入庫更新メインデータ</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データの内容をUOE入庫更新メインデータに反映します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private GridMainDataSet.GridMainTableRow CopyToGridMainRowFromUOEOrderDtlWorkRowForHandy(string sectionCode, UOEOrderDtlWork uoeOrderDtlWorkRow)
        {
            GridMainDataSet.GridMainTableRow gridMainRow = this._gridMainTable.NewGridMainTableRow();

            gridMainRow.DivCd = PMUOE01202EA.DIVCD_NOCHANGE;                            // 区分(" "：未処理、"1"：入荷、"2"：未入荷、"3"：修正、"9"：消込み)
            gridMainRow.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // メーカーコード
            gridMainRow.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // 品番
            gridMainRow.GoodsName = uoeOrderDtlWorkRow.GoodsName;                       // 品名
            gridMainRow.UOESalesOrderNo = uoeOrderDtlWorkRow.UOESalesOrderNo;           // UOE発注番号
            gridMainRow.UOESalesOrderRowNo = uoeOrderDtlWorkRow.UOESalesOrderRowNo;     // UOE発注行番号
            gridMainRow.OnlineNo = uoeOrderDtlWorkRow.OnlineNo;                         // オンライン番号
            gridMainRow.OnlineRowNo = uoeOrderDtlWorkRow.OnlineRowNo;                   // オンライン行番号
            gridMainRow.WarehouseCode = uoeOrderDtlWorkRow.WarehouseCode;               // 倉庫コード
            gridMainRow.WarehouseShelfNo = uoeOrderDtlWorkRow.WarehouseShelfNo;         // 棚番
            gridMainRow.SalesUnitCost = uoeOrderDtlWorkRow.SalesUnitCost;               // 原価単価
            gridMainRow.AnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // 回答原価単価
            gridMainRow.AnswerPartsNo = uoeOrderDtlWorkRow.AnswerPartsNo;               // 回答品番
            gridMainRow.UOERemark1 = uoeOrderDtlWorkRow.UoeRemark1;                     // リマーク1
            gridMainRow.UOERemark2 = uoeOrderDtlWorkRow.UoeRemark2;                     // リマーク2
            gridMainRow.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // 仕入先コード
            gridMainRow.SubstPartsNo = uoeOrderDtlWorkRow.SubstPartsNo;                 // 代替品番
            gridMainRow.SupplierSlipNo = uoeOrderDtlWorkRow.SupplierSlipNo;             // 仕入伝票番号
            gridMainRow.StockSlipDtlNumSrc = uoeOrderDtlWorkRow.StockSlipDtlNum;        // 仕入明細通番
            gridMainRow.HeaderGridRowNo = 0;                                            // UOE入庫更新ヘッダーグリッド用行番号
            gridMainRow.DetailGridRowNo = 0;                                            // UOE入庫更新明細グリッド用行番号
            gridMainRow.InputAnswerSalesUnitCost = uoeOrderDtlWorkRow.AnswerSalesUnitCost;   // 回答原価単価
            gridMainRow.AnswerMakerCd = uoeOrderDtlWorkRow.AnswerMakerCd;               // 回答メーカーコード
            gridMainRow.UOESupplierCd = uoeOrderDtlWorkRow.UOESupplierCd;               // UOE発注先コード

            gridMainRow.GoodspriceuSalesUnitCost = 0.0;                             

            GoodsUnitData unitData = new GoodsUnitData();
            unitData.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;                 // 商品メーカーコード
            unitData.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;                           // 商品番号
            unitData.GoodsRateRank = uoeOrderDtlWorkRow.GoodsRateRank;               // 商品掛率ランク
            unitData.BLGoodsCode = uoeOrderDtlWorkRow.BLGoodsCode;                   // BL商品コード
            unitData.SupplierCd = uoeOrderDtlWorkRow.SupplierCd;                     // 仕入先コード
            unitData.TaxationDivCd = uoeOrderDtlWorkRow.TaxationDivCd;               // 課税区分
            unitData.SectionCode = uoeOrderDtlWorkRow.SectionCode;

            List<GoodsPrice> goodsPriceList;
            goodsPriceList = new List<GoodsPrice>();
            GoodsPrice goodsPrice = new GoodsPrice();
            goodsPrice.GoodsNo = uoeOrderDtlWorkRow.GoodsNo;
            goodsPrice.ListPrice = uoeOrderDtlWorkRow.PriceListPrice;
            goodsPrice.PriceStartDate = TDateTime.LongDateToDateTime(uoeOrderDtlWorkRow.PriceStartDate);
            goodsPrice.StockRate = uoeOrderDtlWorkRow.StockRate;
            goodsPrice.EnterpriseCode = uoeOrderDtlWorkRow.EnterpriseCode;
            goodsPrice.GoodsMakerCd = uoeOrderDtlWorkRow.GoodsMakerCd;
            goodsPrice.LogicalDeleteCode = 0; // 論理削除区分
            goodsPrice.SalesUnitCost = uoeOrderDtlWorkRow.GoodspriceuSalesUnitCost;
            goodsPriceList.Add(goodsPrice);
            unitData.GoodsPriceList = goodsPriceList;
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);

            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = sectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = unitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = unitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = unitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = unitData.GoodsMGroup;                            // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = unitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = unitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = unitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                              // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = unitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);    // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = unitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = unitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            goodsUnitDataList.Add(unitData);

            return gridMainRow;
        }

        /// <summary>
        /// UOE発注データの補正（ハンディターミナル用）
        /// </summary>
        /// <param name="inspectDataAddList">検品登録データ</param>
        /// <returns>補正ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データの更新区分、検品数を補正します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetUpdateDivForHandy(ArrayList inspectDataAddList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 検品登録データがない場合
                if (inspectDataAddList == null || inspectDataAddList.Count == 0)
                {
                    return status;
                }

                string errMessage = string.Empty;
                object searchObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassName, out errMessage);
                // 検品登録条件オブジェクトがない場合
                if (searchObj == null)
                {
                    return status;
                }

                // 検品登録ワークタイプを取得します。
                Type searchType = searchObj.GetType();
                for (int i = 0; i < inspectDataAddList.Count; i++)
                {
                    // 仕入明細通番
                    long stockSlipDtlNum = (long)searchType.GetProperty(StockSlipDtlNum).GetValue(inspectDataAddList[i], null);
                    // 入庫区分
                    string warehousingDivCd = searchType.GetProperty(WarehousingDivCd).GetValue(inspectDataAddList[i], null).ToString();
                    // 更新区分
                    int updateDiv = (int)searchType.GetProperty(UpdateDiv).GetValue(inspectDataAddList[i], null);
                    // 検品数
                    double inspectCnt = (double)searchType.GetProperty(InspectCnt).GetValue(inspectDataAddList[i], null);

                    if (updateDiv == 0) continue;

                    string Filter = string.Format("{0}={1} AND {2}='{3}'",
                                this._gridMainTable.StockSlipDtlNumSrcColumn, stockSlipDtlNum,
                                this._gridMainTable.ColumnDivColumn, WarehousingDivCdToString(warehousingDivCd));

                    GridMainDataSet.GridMainTableRow[] gridMainTableRow =
                        (GridMainDataSet.GridMainTableRow[])this._gridMainTable.Select(Filter);

                    if (gridMainTableRow.Length > 0)
                    {
                        // _gridMainTable.DivCdに引数.更新区分をセットする。
                        gridMainTableRow[0].DivCd = updateDiv.ToString();
                        // _gridMainTable.InputEnterCntに引数.検品数をセットする。
                        gridMainTableRow[0].InputEnterCnt = (int)inspectCnt;
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 入庫区分用文字列の取得（ハンディターミナル用）
        /// </summary>
        /// <param name="warehousingDivCd">入庫区分コード</param>
        /// <returns>入庫区分用文字列</returns>
        /// <remarks>
        /// <br>Note       : 入庫区分用文字列を取得します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private string WarehousingDivCdToString(string warehousingDivCd)
        {
            string resultWarehousingDivCd = string.Empty;
            switch (warehousingDivCd)
            {
                // 引数.入庫区分が「1:拠点」の場合、
                case WarehousingSectionDiv:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_SECTION;
                        break;
                    }
                // 引数.入庫区分が「2:BO1」の場合、
                case WarehousingBo1Div:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_BO1;
                        break;
                    }
                // 引数.入庫区分が「3:BO2」の場合、
                case WarehousingBo2Div:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_BO2;
                        break;
                    }
                // 引数.入庫区分が「4:BO3」の場合、
                case WarehousingBo3Div:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_BO3;
                        break;
                    }
                // 引数.入庫区分が「5:ﾒｰｶｰ」の場合、
                case WarehousingMakerDiv:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_MAKER;
                        break;
                    }
                // 引数.入庫区分が「6：EO」の場合、
                case WarehousingEoDiv:
                    {
                        resultWarehousingDivCd = PMUOE01203AA.COLUMNDIV_EO;
                        break;
                    }
                default:
                    break;
            }
            return resultWarehousingDivCd;
        }

        /// <summary>
        /// UOE入庫更新確定処理(本処理はPMUOE01203ABで行う)（ハンディターミナル用）
        /// </summary>
        /// <param name="uoeStcUpdDataListObj">UOE発注データオブジェクト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>処理結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : UOE入庫更新確定処理を行います。データの作成はPMUOE01203ABクラスで行う。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int DecisionDataForHandy(out object uoeStcUpdDataListObj, out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ヘッダーグリッド→GridMain反映
            this.CopyToGridMainFromHeaderGrid();

            // インスタンス作成
            this._decisionDataAcs = new PMUOE01203AB(this._enterpriseCode
                                                    , this._uoeOrderDtlWorkHTable
                                                    , this._gridMainTable
                                                    , this._stockSlipWorkHTable
                                                    , this._stockDetailWorkHTable
                                                    , this._supplierHTable);    // 入庫更新確定処理専用クラス

            // プロパティセット
            this._decisionDataAcs.GoodsAcs = this._goodsAcs;                            // 商品マスタアクセスクラス
            this._decisionDataAcs.StockingPaymentOption = this._stockingPaymentOption;  // 買掛オプション
            this._decisionDataAcs.StockBlnktPrtNoDiv = this._stockBlnktPrtNoDiv;        // UOE自社マスタ.在庫一括品番区分
            this._decisionDataAcs.MeiJiDiv = this._meiJiDiv;                            // 明治産業区分

            // データ作成
            uoeStcUpdDataListObj = this._decisionDataAcs.CreateUOEStcUpdDataList(out msg);
            if (uoeStcUpdDataListObj == null)
            {
                // データ作成失敗
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                // インスタンスタイプがある場合、インスタンスオブジェクトを生成します。
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return obj;
        }
        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<
    }

    // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
    /// <summary>
    /// 掛率優先管理データ比較クラス(拠点コード(昇順)、単価種類(昇順)、掛率優先順位(昇順))
    /// </summary>
    /// <remarks></remarks>
    internal class RateProtyMngComparer : Comparer<RateProtyMng>
    {

        public override int Compare(RateProtyMng x, RateProtyMng y)
        {
            int result = x.SectionCode.CompareTo(y.SectionCode);
            if (result != 0) return result;

            result = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
            if (result != 0) return result;

            result = x.RatePriorityOrder.CompareTo(y.RatePriorityOrder);
            return result;
        }
    }
	// ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<

}
