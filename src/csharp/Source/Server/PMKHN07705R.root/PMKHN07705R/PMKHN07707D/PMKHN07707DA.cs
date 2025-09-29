using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesSliptextCndtnWork
    /// <summary>
    ///                      売上データテキスト出力（TMY)条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データテキスト出力（TMY)条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2012/11/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesSliptextCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>対象日付(開始)</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private Int32 _salesDateSt;

        /// <summary>対象日付(終了)</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private Int32 _salesDateEd;

        /// <summary>得意先分析コード1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>得意先分析コード2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>得意先分析コード3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>得意先分析コード4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>得意先分析コード5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>得意先分析コード6</summary>
        private Int32 _custAnalysCode6;

        /// <summary>車両管理番号</summary>
        private string _carMngNo1 = "";

        /// <summary>伝票備考</summary>
        private string _slipNote = "";

        /// <summary>伝票備考２</summary>
        private string _slipNote2 = "";

        /// <summary>伝票備考３</summary>
        private string _slipNote3 = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;


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

        /// public propaty name  :  SalesDateSt
        /// <summary>対象日付(開始)プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>対象日付(終了)プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>得意先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>得意先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>得意先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>得意先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>得意先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>得意先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  CarMngNo1
        /// <summary>車両管理番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngNo1
        {
            get { return _carMngNo1; }
            set { _carMngNo1 = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>伝票備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>伝票備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>得意先注文番号</value>
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


        /// <summary>
        /// 売上データテキスト出力（TMY)条件ワークコンストラクタ
        /// </summary>
        /// <returns>SalesSliptextCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSliptextCndtnWork()
        {
        }


    }  
}
