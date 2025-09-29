using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StcHisRefExtraParamWork
    /// <summary>
    ///                      仕入履歴照会抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入履歴照会抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StcHisRefExtraParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）※必須入力</remarks>
        private Int32 _supplierFormal;

        /// <summary>拠点コード</summary>
        /// <remarks>※必須入力</remarks>
        private string _sectionCode = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>※必須入力</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入日(開始)</summary>
        /// <remarks>0:未指定</remarks>
        private Int32 _stockDateSt;

        /// <summary>仕入日(終了)</summary>
        /// <remarks>0:未指定</remarks>
        private Int32 _stockDateEd;

        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>品番検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>支払先コード</summary>
        /// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
        private Int32 _payeeCode;

        /// <summary>発注番号</summary>
        /// <remarks>発注用</remarks>
        private string _orderNumber = "";

        /// <summary>品名検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _goodsNameSrchTyp;

        /// <summary>品名</summary>
        private string _goodsName = "";

        /// <summary>仕入担当者コード</summary>
        /// <remarks>発注者をセット</remarks>
        private string _stockAgentCode = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>仕入伝票区分</summary>
        /// <remarks>10:仕入,20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>買掛区分</summary>
        /// <remarks>0:買掛なし,1:買掛</remarks>
        private Int32 _accPayDivCd;

        /// <summary>入荷日（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _arrivalGoodsDaySt;

        /// <summary>入荷日（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _arrivalGoodsDayEd;

        /// <summary>入力日（開始）</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _inputDaySt;

        /// <summary>入力日（終了）</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _inputDayEd;

        /// <summary>仕入伝票番号(開始)</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　0:未指定</remarks>
        private Int32 _supplierSlipNoSt;

        /// <summary>仕入伝票番号(終了)</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　0:未指定</remarks>
        private Int32 _supplierSlipNoEd;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>相手先伝票番号検索タイプ</summary>
        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
        private Int32 _partySaleSlipNumSrchTyp;

        /// <summary>消込フラグ</summary>
        /// <remarks>0:残あり 1:残なし -1:全て</remarks>
        private Int32 _reconcileFlag;

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;


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

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）※必須入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>※必須入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>※必須入力</value>
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

        /// public propaty name  :  StockDateSt
        /// <summary>仕入日(開始)プロパティ</summary>
        /// <value>0:未指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateSt
        {
            get { return _stockDateSt; }
            set { _stockDateSt = value; }
        }

        /// public propaty name  :  StockDateEd
        /// <summary>仕入日(終了)プロパティ</summary>
        /// <value>0:未指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateEd
        {
            get { return _stockDateEd; }
            set { _stockDateEd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
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

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>品番検索タイププロパティ</summary>
        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</value>
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

        /// public propaty name  :  OrderNumber
        /// <summary>発注番号プロパティ</summary>
        /// <value>発注用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// public propaty name  :  GoodsNameSrchTyp
        /// <summary>品名検索タイププロパティ</summary>
        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNameSrchTyp
        {
            get { return _goodsNameSrchTyp; }
            set { _goodsNameSrchTyp = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
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

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>発注者をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
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

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>10:仕入,20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  AccPayDivCd
        /// <summary>買掛区分プロパティ</summary>
        /// <value>0:買掛なし,1:買掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   買掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  ArrivalGoodsDaySt
        /// <summary>入荷日（開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ArrivalGoodsDaySt
        {
            get { return _arrivalGoodsDaySt; }
            set { _arrivalGoodsDaySt = value; }
        }

        /// public propaty name  :  ArrivalGoodsDayEd
        /// <summary>入荷日（終了）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ArrivalGoodsDayEd
        {
            get { return _arrivalGoodsDayEd; }
            set { _arrivalGoodsDayEd = value; }
        }

        /// public propaty name  :  InputDaySt
        /// <summary>入力日（開始）プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDaySt
        {
            get { return _inputDaySt; }
            set { _inputDaySt = value; }
        }

        /// public propaty name  :  InputDayEd
        /// <summary>入力日（終了）プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDayEd
        {
            get { return _inputDayEd; }
            set { _inputDayEd = value; }
        }

        /// public propaty name  :  SupplierSlipNoSt
        /// <summary>仕入伝票番号(開始)プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　0:未指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNoSt
        {
            get { return _supplierSlipNoSt; }
            set { _supplierSlipNoSt = value; }
        }

        /// public propaty name  :  SupplierSlipNoEd
        /// <summary>仕入伝票番号(終了)プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　0:未指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNoEd
        {
            get { return _supplierSlipNoEd; }
            set { _supplierSlipNoEd = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  PartySaleSlipNumSrchTyp
        /// <summary>相手先伝票番号検索タイププロパティ</summary>
        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartySaleSlipNumSrchTyp
        {
            get { return _partySaleSlipNumSrchTyp; }
            set { _partySaleSlipNumSrchTyp = value; }
        }

        /// public propaty name  :  ReconcileFlag
        /// <summary>消込フラグプロパティ</summary>
        /// <value>0:残あり 1:残なし -1:全て</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消込フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReconcileFlag
        {
            get { return _reconcileFlag; }
            set { _reconcileFlag = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }


        /// <summary>
        /// 仕入履歴照会抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>StcHisRefExtraParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcHisRefExtraParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StcHisRefExtraParamWork()
        {
        }

    }

}
