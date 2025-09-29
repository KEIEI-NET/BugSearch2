using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RateSearchParamWork
    /// <summary>
    ///                      掛率一括登録修正抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率一括登録修正抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RateSearchParamWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定はnull</remarks>
        private string[] _sectionCode;

        /// <summary>ログイン拠点コード</summary>
        /// <remarks>ログイン拠点コードをセット</remarks>
        private string[] _prmSectionCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>商品掛率グループコード</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>得意先コード</summary>
        /// <remarks>(配列) nullの場合は全て</remarks>
        private Int32[] _customerCode;

        /// <summary>得意先掛率グループコード</summary>
        /// <remarks>(配列) nullの場合は全て</remarks>
        private Int32[] _custRateGrpCode;


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
        /// <value>(配列)　全社指定はnull</value>
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

        /// public propaty name  :  PrmSectionCode
        /// <summary>ログイン拠点コードプロパティ</summary>
        /// <value>ログイン拠点コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログイン拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PrmSectionCode
        {
            get { return _prmSectionCode; }
            set { _prmSectionCode = value; }
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

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>(配列) nullの場合は全て</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// <value>(配列) nullの場合は全て</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }


        /// <summary>
        /// 掛率一括登録修正抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>RateSearchParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateSearchParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RateSearchParamWork()
        {
        }

    }
}
