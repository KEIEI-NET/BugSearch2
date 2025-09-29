using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StcRetGdsSlipTtlExtraWork
    /// <summary>
    ///                      仕入返品伝票(鑑部)抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入返品伝票(鑑部)抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StcRetGdsSlipTtlExtraWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>配列で複数拠点指定　全拠点の場合は配列数0</remarks>
        private string[] _sectionCode;

        /// <summary>仕入計上日付(開始)</summary>
        /// <remarks>未入力時は 0</remarks>
        private Int32 _stockAddUpADateSt;

        /// <summary>仕入計上日付(終了)</summary>
        /// <remarks>未入力時は 0</remarks>
        private Int32 _stockAddUpADateEd;

        /// <summary>仕入伝票番号(開始)</summary>
        /// <remarks>未入力時は 0</remarks>
        private Int32 _supplierSlipNoSt;

        /// <summary>仕入伝票番号(終了)</summary>
        /// <remarks>未入力時は 0</remarks>
        private Int32 _supplierSlipNoEd;

        /// <summary>仕入先コード</summary>
        /// <remarks>未入力時は 0</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入入力者コード</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _stockInputName = "";


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
        /// <value>配列で複数拠点指定　全拠点の場合は配列数0</value>
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

        /// public propaty name  :  StockAddUpADateSt
        /// <summary>仕入計上日付(開始)プロパティ</summary>
        /// <value>未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAddUpADateSt
        {
            get { return _stockAddUpADateSt; }
            set { _stockAddUpADateSt = value; }
        }

        /// public propaty name  :  StockAddUpADateEd
        /// <summary>仕入計上日付(終了)プロパティ</summary>
        /// <value>未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入計上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAddUpADateEd
        {
            get { return _stockAddUpADateEd; }
            set { _stockAddUpADateEd = value; }
        }

        /// public propaty name  :  SupplierSlipNoSt
        /// <summary>仕入伝票番号(開始)プロパティ</summary>
        /// <value>未入力時は 0</value>
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
        /// <value>未入力時は 0</value>
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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>未入力時は 0</value>
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

        /// public propaty name  :  StockInputName
        /// <summary>仕入入力者コードプロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }


        /// <summary>
        /// 仕入返品伝票(鑑部)抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>StcRetGdsSlipTtlExtraWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StcRetGdsSlipTtlExtraWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StcRetGdsSlipTtlExtraWork()
        {
        }

    }
}