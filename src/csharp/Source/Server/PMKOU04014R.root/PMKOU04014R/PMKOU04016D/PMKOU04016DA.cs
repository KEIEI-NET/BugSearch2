using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppPrtPprWork
    /// <summary>
    ///                      仕入先電子元帳検索条件(残高・伝票・明細)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先電子元帳検索条件(残高・伝票・明細)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/03/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprWork
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


        /// <summary>
        /// 仕入先電子元帳検索条件(残高・伝票・明細)ワークコンストラクタ
        /// </summary>
        /// <returns>SuppPrtPprWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppPrtPprWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppPrtPprWork()
        {
        }
    }
}