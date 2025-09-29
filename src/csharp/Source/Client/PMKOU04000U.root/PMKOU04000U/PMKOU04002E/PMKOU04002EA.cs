using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SuppPrtPpr
    /// <summary>
    ///                      仕入先電子元帳検索条件(残高・伝票・明細)
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先電子元帳検索条件(残高・伝票・明細)ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/03/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SuppPrtPpr
    {
        /// <summary>検索上限</summary>
        /// <remarks>検索上限数+1をセット</remarks>
        private Int64 _searchCnt;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private string[] _sectionCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>支払先コード</summary>
        private Int32 _payeeCode;

        /// <summary>開始仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_StockDate;

        /// <summary>終了仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_StockDate;

        /// <summary>開始入力日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_InputDay;

        /// <summary>終了入力日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_InputDay;

        /// <summary>仕入形式</summary>
        /// <remarks>(配列)　全指定の場合は{""}　0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32[] _supplierFormal;

        /// <summary>仕入伝票区分</summary>
        /// <remarks>(配列)　全指定の場合は{""}　10:仕入,20:返品</remarks>
        private Int32[] _supplierSlipCd;

        /// <summary>伝票番号</summary>
        /// <remarks>相手先伝票番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>仕入SEQ/支払№</summary>
        /// <remarks>支払伝票番号/仕入伝票番号</remarks>
        private Int32 _paymentSlipNo;

        /// <summary>担当者</summary>
        /// <remarks>仕入担当者コード</remarks>
        private string _stockAgentCode = "";

        /// <summary>発行者</summary>
        /// <remarks>仕入入力者コード</remarks>
        private string _stockInputCode = "";

        /// <summary>ＵＯＥ発送</summary>
        /// <remarks>注文方法　0:全て 1:通常 2:UOE発送</remarks>
        private Int32 _wayToOrder;

        /// <summary>備考１</summary>
        /// <remarks>仕入伝票備考1</remarks>
        private string _supplierSlipNote1 = "";

        /// <summary>備考２</summary>
        /// <remarks>仕入伝票備考2</remarks>
        private string _supplierSlipNote2 = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>ＵＯＥリマーク１</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        /// <remarks>ＵＯＥリマーク２</remarks>
        private string _uoeRemark2 = "";

        /// <summary>ＢＬグループ</summary>
        /// <remarks>BLグループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>ＢＬコード</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>品名</summary>
        /// <remarks>商品名称</remarks>
        private string _goodsName = "";

        /// <summary>品番</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        /// <summary>メーカーコード</summary>
        /// <remarks>商品メーカーコード</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>在庫取寄区分</summary>
        /// <remarks>仕入在庫取寄せ区分　-1:全て 0:取寄せ 1:在庫</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫コード</remarks>
        private string _warehouseCode = "";

        /// <summary>伝票検索区分</summary>
        /// <remarks>0:全て 1:仕入のみ 2:支払のみ</remarks>
        private Int32 _searchType;

        /// <summary>仕入伝票区分（明細）[明細]</summary>
        /// <remarks>0:仕入,1:返品,2:値引</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>仕入担当者名称</summary>
        private string _stockAgentName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";


        /// public propaty name  :  SearchCnt
        /// <summary>検索上限プロパティ</summary>
        /// <value>検索上限数+1をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索上限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SearchCnt
        {
            get { return _searchCnt; }
            set { _searchCnt = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>(配列)　全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  St_StockDate
        /// <summary>開始仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_StockDate
        {
            get { return _st_StockDate; }
            set { _st_StockDate = value; }
        }

        /// public propaty name  :  Ed_StockDate
        /// <summary>終了仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_StockDate
        {
            get { return _ed_StockDate; }
            set { _ed_StockDate = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>開始入力日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>終了入力日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>(配列)　全指定の場合は{""}　0:仕入,1:入荷,2:発注　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>(配列)　全指定の場合は{""}　10:仕入,20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>伝票番号プロパティ</summary>
        /// <value>相手先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>仕入SEQ/支払№プロパティ</summary>
        /// <value>支払伝票番号/仕入伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入SEQ/支払№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>担当者プロパティ</summary>
        /// <value>仕入担当者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockInputCode
        /// <summary>発行者プロパティ</summary>
        /// <value>仕入入力者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  WayToOrder
        /// <summary>ＵＯＥ発送プロパティ</summary>
        /// <value>注文方法　0:全て 1:通常 2:UOE発送</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥ発送プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>備考１プロパティ</summary>
        /// <value>仕入伝票備考1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>備考２プロパティ</summary>
        /// <value>仕入伝票備考2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>ＵＯＥリマーク１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// <value>ＵＯＥリマーク２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>ＢＬグループプロパティ</summary>
        /// <value>BLグループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬグループプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>ＢＬコードプロパティ</summary>
        /// <value>BL商品コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
        /// <value>商品名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// <value>商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>商品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>在庫取寄区分プロパティ</summary>
        /// <value>仕入在庫取寄せ区分　-1:全て 0:取寄せ 1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  SearchType
        /// <summary>伝票検索区分プロパティ</summary>
        /// <value>0:全て 1:仕入のみ 2:支払のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>仕入伝票区分（明細）[明細]プロパティ</summary>
        /// <value>0:仕入,1:返品,2:値引</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分（明細）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }


        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)コンストラクタ
        /// </summary>
        /// <returns>SuppPrtPprクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppPrtPpr()
        {
        }

        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)コンストラクタ
        /// </summary>
        /// <param name="searchCnt">検索上限(検索上限数+1をセット)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード((配列)　全社指定は{""})</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="st_StockDate">開始仕入日(YYYYMMDD)</param>
        /// <param name="ed_StockDate">終了仕入日(YYYYMMDD)</param>
        /// <param name="st_InputDay">開始入力日(YYYYMMDD)</param>
        /// <param name="ed_InputDay">終了入力日(YYYYMMDD)</param>
        /// <param name="supplierFormal">仕入形式((配列)　全指定の場合は{""}　0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
        /// <param name="supplierSlipCd">仕入伝票区分((配列)　全指定の場合は{""}　10:仕入,20:返品)</param>
        /// <param name="partySaleSlipNum">伝票番号(相手先伝票番号)</param>
        /// <param name="paymentSlipNo">仕入SEQ/支払№(支払伝票番号/仕入伝票番号)</param>
        /// <param name="stockAgentCode">担当者(仕入担当者コード)</param>
        /// <param name="stockInputCode">発行者(仕入入力者コード)</param>
        /// <param name="wayToOrder">ＵＯＥ発送(注文方法　0:全て 1:通常 2:UOE発送)</param>
        /// <param name="supplierSlipNote1">備考１(仕入伝票備考1)</param>
        /// <param name="supplierSlipNote2">備考２(仕入伝票備考2)</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１(ＵＯＥリマーク１)</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２(ＵＯＥリマーク２)</param>
        /// <param name="bLGroupCode">ＢＬグループ(BLグループコード)</param>
        /// <param name="bLGoodsCode">ＢＬコード(BL商品コード)</param>
        /// <param name="goodsName">品名(商品名称)</param>
        /// <param name="goodsNo">品番(商品番号)</param>
        /// <param name="goodsMakerCd">メーカーコード(商品メーカーコード)</param>
        /// <param name="stockOrderDivCd">在庫取寄区分(仕入在庫取寄せ区分　-1:全て 0:取寄せ 1:在庫)</param>
        /// <param name="warehouseCode">倉庫コード(倉庫コード)</param>
        /// <param name="searchType">伝票検索区分(0:全て 1:仕入のみ 2:支払のみ)</param>
        /// <param name="stockSlipCdDtl">仕入伝票区分（明細）[明細](0:仕入,1:返品,2:値引)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="stockAgentName">仕入担当者名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="warehouseName">倉庫名称</param>
        /// <returns>SuppPrtPprクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppPrtPpr( Int64 searchCnt, string enterpriseCode, string[] sectionCode, Int32 supplierCd, Int32 payeeCode, DateTime st_StockDate, DateTime ed_StockDate, DateTime st_InputDay, DateTime ed_InputDay, Int32[] supplierFormal, Int32[] supplierSlipCd, string partySaleSlipNum, Int32 paymentSlipNo, string stockAgentCode, string stockInputCode, Int32 wayToOrder, string supplierSlipNote1, string supplierSlipNote2, string uoeRemark1, string uoeRemark2, Int32 bLGroupCode, Int32 bLGoodsCode, string goodsName, string goodsNo, Int32 goodsMakerCd, Int32 stockOrderDivCd, string warehouseCode, Int32 searchType, Int32 stockSlipCdDtl, string enterpriseName, string stockAgentName, string bLGoodsName, string warehouseName )
        {
            this._searchCnt = searchCnt;
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            this._payeeCode = payeeCode;
            this._st_StockDate = st_StockDate;
            this._ed_StockDate = ed_StockDate;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._supplierFormal = supplierFormal;
            this._supplierSlipCd = supplierSlipCd;
            this._partySaleSlipNum = partySaleSlipNum;
            this._paymentSlipNo = paymentSlipNo;
            this._stockAgentCode = stockAgentCode;
            this._stockInputCode = stockInputCode;
            this._wayToOrder = wayToOrder;
            this._supplierSlipNote1 = supplierSlipNote1;
            this._supplierSlipNote2 = supplierSlipNote2;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsName = goodsName;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._stockOrderDivCd = stockOrderDivCd;
            this._warehouseCode = warehouseCode;
            this._searchType = searchType;
            this._stockSlipCdDtl = stockSlipCdDtl;
            this._enterpriseName = enterpriseName;
            this._stockAgentName = stockAgentName;
            this._bLGoodsName = bLGoodsName;
            this._warehouseName = warehouseName;

        }

        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)複製処理
        /// </summary>
        /// <returns>SuppPrtPprクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSuppPrtPprクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppPrtPpr Clone()
        {
            return new SuppPrtPpr( this._searchCnt, this._enterpriseCode, this._sectionCode, this._supplierCd, this._payeeCode, this._st_StockDate, this._ed_StockDate, this._st_InputDay, this._ed_InputDay, this._supplierFormal, this._supplierSlipCd, this._partySaleSlipNum, this._paymentSlipNo, this._stockAgentCode, this._stockInputCode, this._wayToOrder, this._supplierSlipNote1, this._supplierSlipNote2, this._uoeRemark1, this._uoeRemark2, this._bLGroupCode, this._bLGoodsCode, this._goodsName, this._goodsNo, this._goodsMakerCd, this._stockOrderDivCd, this._warehouseCode, this._searchType, this._stockSlipCdDtl, this._enterpriseName, this._stockAgentName, this._bLGoodsName, this._warehouseName );
        }

        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="target">比較対象のSuppPrtPprクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( SuppPrtPpr target )
        {
            return ((this.SearchCnt == target.SearchCnt)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.St_StockDate == target.St_StockDate)
                 && (this.Ed_StockDate == target.Ed_StockDate)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.SupplierSlipCd == target.SupplierSlipCd)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.PaymentSlipNo == target.PaymentSlipNo)
                 && (this.StockAgentCode == target.StockAgentCode)
                 && (this.StockInputCode == target.StockInputCode)
                 && (this.WayToOrder == target.WayToOrder)
                 && (this.SupplierSlipNote1 == target.SupplierSlipNote1)
                 && (this.SupplierSlipNote2 == target.SupplierSlipNote2)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.StockOrderDivCd == target.StockOrderDivCd)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.SearchType == target.SearchType)
                 && (this.StockSlipCdDtl == target.StockSlipCdDtl)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.StockAgentName == target.StockAgentName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.WarehouseName == target.WarehouseName));
        }

        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="suppPrtPpr1">
        ///                    比較するSuppPrtPprクラスのインスタンス
        /// </param>
        /// <param name="suppPrtPpr2">比較するSuppPrtPprクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( SuppPrtPpr suppPrtPpr1, SuppPrtPpr suppPrtPpr2 )
        {
            return ((suppPrtPpr1.SearchCnt == suppPrtPpr2.SearchCnt)
                 && (suppPrtPpr1.EnterpriseCode == suppPrtPpr2.EnterpriseCode)
                 && (suppPrtPpr1.SectionCode == suppPrtPpr2.SectionCode)
                 && (suppPrtPpr1.SupplierCd == suppPrtPpr2.SupplierCd)
                 && (suppPrtPpr1.PayeeCode == suppPrtPpr2.PayeeCode)
                 && (suppPrtPpr1.St_StockDate == suppPrtPpr2.St_StockDate)
                 && (suppPrtPpr1.Ed_StockDate == suppPrtPpr2.Ed_StockDate)
                 && (suppPrtPpr1.St_InputDay == suppPrtPpr2.St_InputDay)
                 && (suppPrtPpr1.Ed_InputDay == suppPrtPpr2.Ed_InputDay)
                 && (suppPrtPpr1.SupplierFormal == suppPrtPpr2.SupplierFormal)
                 && (suppPrtPpr1.SupplierSlipCd == suppPrtPpr2.SupplierSlipCd)
                 && (suppPrtPpr1.PartySaleSlipNum == suppPrtPpr2.PartySaleSlipNum)
                 && (suppPrtPpr1.PaymentSlipNo == suppPrtPpr2.PaymentSlipNo)
                 && (suppPrtPpr1.StockAgentCode == suppPrtPpr2.StockAgentCode)
                 && (suppPrtPpr1.StockInputCode == suppPrtPpr2.StockInputCode)
                 && (suppPrtPpr1.WayToOrder == suppPrtPpr2.WayToOrder)
                 && (suppPrtPpr1.SupplierSlipNote1 == suppPrtPpr2.SupplierSlipNote1)
                 && (suppPrtPpr1.SupplierSlipNote2 == suppPrtPpr2.SupplierSlipNote2)
                 && (suppPrtPpr1.UoeRemark1 == suppPrtPpr2.UoeRemark1)
                 && (suppPrtPpr1.UoeRemark2 == suppPrtPpr2.UoeRemark2)
                 && (suppPrtPpr1.BLGroupCode == suppPrtPpr2.BLGroupCode)
                 && (suppPrtPpr1.BLGoodsCode == suppPrtPpr2.BLGoodsCode)
                 && (suppPrtPpr1.GoodsName == suppPrtPpr2.GoodsName)
                 && (suppPrtPpr1.GoodsNo == suppPrtPpr2.GoodsNo)
                 && (suppPrtPpr1.GoodsMakerCd == suppPrtPpr2.GoodsMakerCd)
                 && (suppPrtPpr1.StockOrderDivCd == suppPrtPpr2.StockOrderDivCd)
                 && (suppPrtPpr1.WarehouseCode == suppPrtPpr2.WarehouseCode)
                 && (suppPrtPpr1.SearchType == suppPrtPpr2.SearchType)
                 && (suppPrtPpr1.StockSlipCdDtl == suppPrtPpr2.StockSlipCdDtl)
                 && (suppPrtPpr1.EnterpriseName == suppPrtPpr2.EnterpriseName)
                 && (suppPrtPpr1.StockAgentName == suppPrtPpr2.StockAgentName)
                 && (suppPrtPpr1.BLGoodsName == suppPrtPpr2.BLGoodsName)
                 && (suppPrtPpr1.WarehouseName == suppPrtPpr2.WarehouseName));
        }
        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="target">比較対象のSuppPrtPprクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( SuppPrtPpr target )
        {
            ArrayList resList = new ArrayList();
            if ( this.SearchCnt != target.SearchCnt ) resList.Add( "SearchCnt" );
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.SectionCode != target.SectionCode ) resList.Add( "SectionCode" );
            if ( this.SupplierCd != target.SupplierCd ) resList.Add( "SupplierCd" );
            if ( this.PayeeCode != target.PayeeCode ) resList.Add( "PayeeCode" );
            if ( this.St_StockDate != target.St_StockDate ) resList.Add( "St_StockDate" );
            if ( this.Ed_StockDate != target.Ed_StockDate ) resList.Add( "Ed_StockDate" );
            if ( this.St_InputDay != target.St_InputDay ) resList.Add( "St_InputDay" );
            if ( this.Ed_InputDay != target.Ed_InputDay ) resList.Add( "Ed_InputDay" );
            if ( this.SupplierFormal != target.SupplierFormal ) resList.Add( "SupplierFormal" );
            if ( this.SupplierSlipCd != target.SupplierSlipCd ) resList.Add( "SupplierSlipCd" );
            if ( this.PartySaleSlipNum != target.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( this.PaymentSlipNo != target.PaymentSlipNo ) resList.Add( "PaymentSlipNo" );
            if ( this.StockAgentCode != target.StockAgentCode ) resList.Add( "StockAgentCode" );
            if ( this.StockInputCode != target.StockInputCode ) resList.Add( "StockInputCode" );
            if ( this.WayToOrder != target.WayToOrder ) resList.Add( "WayToOrder" );
            if ( this.SupplierSlipNote1 != target.SupplierSlipNote1 ) resList.Add( "SupplierSlipNote1" );
            if ( this.SupplierSlipNote2 != target.SupplierSlipNote2 ) resList.Add( "SupplierSlipNote2" );
            if ( this.UoeRemark1 != target.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( this.UoeRemark2 != target.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( this.BLGroupCode != target.BLGroupCode ) resList.Add( "BLGroupCode" );
            if ( this.BLGoodsCode != target.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( this.GoodsName != target.GoodsName ) resList.Add( "GoodsName" );
            if ( this.GoodsNo != target.GoodsNo ) resList.Add( "GoodsNo" );
            if ( this.GoodsMakerCd != target.GoodsMakerCd ) resList.Add( "GoodsMakerCd" );
            if ( this.StockOrderDivCd != target.StockOrderDivCd ) resList.Add( "StockOrderDivCd" );
            if ( this.WarehouseCode != target.WarehouseCode ) resList.Add( "WarehouseCode" );
            if ( this.SearchType != target.SearchType ) resList.Add( "SearchType" );
            if ( this.StockSlipCdDtl != target.StockSlipCdDtl ) resList.Add( "StockSlipCdDtl" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( this.StockAgentName != target.StockAgentName ) resList.Add( "StockAgentName" );
            if ( this.BLGoodsName != target.BLGoodsName ) resList.Add( "BLGoodsName" );
            if ( this.WarehouseName != target.WarehouseName ) resList.Add( "WarehouseName" );

            return resList;
        }

        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="suppPrtPpr1">比較するSuppPrtPprクラスのインスタンス</param>
        /// <param name="suppPrtPpr2">比較するSuppPrtPprクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( SuppPrtPpr suppPrtPpr1, SuppPrtPpr suppPrtPpr2 )
        {
            ArrayList resList = new ArrayList();
            if ( suppPrtPpr1.SearchCnt != suppPrtPpr2.SearchCnt ) resList.Add( "SearchCnt" );
            if ( suppPrtPpr1.EnterpriseCode != suppPrtPpr2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( suppPrtPpr1.SectionCode != suppPrtPpr2.SectionCode ) resList.Add( "SectionCode" );
            if ( suppPrtPpr1.SupplierCd != suppPrtPpr2.SupplierCd ) resList.Add( "SupplierCd" );
            if ( suppPrtPpr1.PayeeCode != suppPrtPpr2.PayeeCode ) resList.Add( "PayeeCode" );
            if ( suppPrtPpr1.St_StockDate != suppPrtPpr2.St_StockDate ) resList.Add( "St_StockDate" );
            if ( suppPrtPpr1.Ed_StockDate != suppPrtPpr2.Ed_StockDate ) resList.Add( "Ed_StockDate" );
            if ( suppPrtPpr1.St_InputDay != suppPrtPpr2.St_InputDay ) resList.Add( "St_InputDay" );
            if ( suppPrtPpr1.Ed_InputDay != suppPrtPpr2.Ed_InputDay ) resList.Add( "Ed_InputDay" );
            if ( suppPrtPpr1.SupplierFormal != suppPrtPpr2.SupplierFormal ) resList.Add( "SupplierFormal" );
            if ( suppPrtPpr1.SupplierSlipCd != suppPrtPpr2.SupplierSlipCd ) resList.Add( "SupplierSlipCd" );
            if ( suppPrtPpr1.PartySaleSlipNum != suppPrtPpr2.PartySaleSlipNum ) resList.Add( "PartySaleSlipNum" );
            if ( suppPrtPpr1.PaymentSlipNo != suppPrtPpr2.PaymentSlipNo ) resList.Add( "PaymentSlipNo" );
            if ( suppPrtPpr1.StockAgentCode != suppPrtPpr2.StockAgentCode ) resList.Add( "StockAgentCode" );
            if ( suppPrtPpr1.StockInputCode != suppPrtPpr2.StockInputCode ) resList.Add( "StockInputCode" );
            if ( suppPrtPpr1.WayToOrder != suppPrtPpr2.WayToOrder ) resList.Add( "WayToOrder" );
            if ( suppPrtPpr1.SupplierSlipNote1 != suppPrtPpr2.SupplierSlipNote1 ) resList.Add( "SupplierSlipNote1" );
            if ( suppPrtPpr1.SupplierSlipNote2 != suppPrtPpr2.SupplierSlipNote2 ) resList.Add( "SupplierSlipNote2" );
            if ( suppPrtPpr1.UoeRemark1 != suppPrtPpr2.UoeRemark1 ) resList.Add( "UoeRemark1" );
            if ( suppPrtPpr1.UoeRemark2 != suppPrtPpr2.UoeRemark2 ) resList.Add( "UoeRemark2" );
            if ( suppPrtPpr1.BLGroupCode != suppPrtPpr2.BLGroupCode ) resList.Add( "BLGroupCode" );
            if ( suppPrtPpr1.BLGoodsCode != suppPrtPpr2.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( suppPrtPpr1.GoodsName != suppPrtPpr2.GoodsName ) resList.Add( "GoodsName" );
            if ( suppPrtPpr1.GoodsNo != suppPrtPpr2.GoodsNo ) resList.Add( "GoodsNo" );
            if ( suppPrtPpr1.GoodsMakerCd != suppPrtPpr2.GoodsMakerCd ) resList.Add( "GoodsMakerCd" );
            if ( suppPrtPpr1.StockOrderDivCd != suppPrtPpr2.StockOrderDivCd ) resList.Add( "StockOrderDivCd" );
            if ( suppPrtPpr1.WarehouseCode != suppPrtPpr2.WarehouseCode ) resList.Add( "WarehouseCode" );
            if ( suppPrtPpr1.SearchType != suppPrtPpr2.SearchType ) resList.Add( "SearchType" );
            if ( suppPrtPpr1.StockSlipCdDtl != suppPrtPpr2.StockSlipCdDtl ) resList.Add( "StockSlipCdDtl" );
            if ( suppPrtPpr1.EnterpriseName != suppPrtPpr2.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( suppPrtPpr1.StockAgentName != suppPrtPpr2.StockAgentName ) resList.Add( "StockAgentName" );
            if ( suppPrtPpr1.BLGoodsName != suppPrtPpr2.BLGoodsName ) resList.Add( "BLGoodsName" );
            if ( suppPrtPpr1.WarehouseName != suppPrtPpr2.WarehouseName ) resList.Add( "WarehouseName" );

            return resList;
        }
    }
}
