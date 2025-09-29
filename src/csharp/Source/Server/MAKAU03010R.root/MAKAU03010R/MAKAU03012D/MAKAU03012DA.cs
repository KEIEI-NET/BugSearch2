using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_EBooksDemandTotalWork
    /// <summary>
    ///                      請求書(鑑部)抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求書(鑑部)抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/06  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_EBooksDemandTotalWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>実績計上拠点コードリスト</summary>
        /// <remarks>文字型　※配列項目 全社指定は{""}</remarks>
        private string[] _resultsAddUpSecList;

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD 請求締を行なった日（相手先基準）</remarks>
        private DateTime _addUpDate;

        /// <summary>集金担当コード(開始)</summary>
        /// <remarks>文字型</remarks>
        private string _billCollecterCdSt = "";

        /// <summary>集金担当コード(終了)</summary>
        /// <remarks>文字型</remarks>
        private string _billCollecterCdEd = "";

        /// <summary>顧客担当コード(開始)</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCdSt = "";

        /// <summary>顧客担当コード(終了)</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCdEd = "";

        /// <summary>販売エリアコード(開始)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>販売エリアコード(終了)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>得意先コード(開始)</summary>
        private Int32 _customerCodeSt;

        /// <summary>得意先コード(終了)</summary>
        private Int32 _customerCodeEd;

        /// <summary>電子帳簿出力対象</summary>
        private Int32 _eBooksOutMode;

        /// <summary>印刷対象</summary>
        private Int32 _printOutMode;

        /// <summary>同期処理区分</summary>
        private Int32 _eBooksFlg;

        /// <summary>伝票印刷種別</summary>
        /// <remarks>0:請求一覧,60:明細請求書</remarks>
        private Int32 _slipPrtKind;
        /// <summary>税別内訳印字区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>税率1</summary>
        /// <remarks>税率1</remarks>
        private Double _taxRate1;

        /// <summary>税率2</summary>
        /// <remarks>税率2</remarks>
        private Double _taxRate2;


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

        /// public propaty name  :  ResultsAddUpSecList
        /// <summary>実績計上拠点コードリストプロパティ</summary>
        /// <value>文字型　※配列項目 全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] ResultsAddUpSecList
        {
            get { return _resultsAddUpSecList; }
            set { _resultsAddUpSecList = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD 請求締を行なった日（相手先基準）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  BillCollecterCdSt
        /// <summary>集金担当コード(開始)プロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCdSt
        {
            get { return _billCollecterCdSt; }
            set { _billCollecterCdSt = value; }
        }

        /// public propaty name  :  BillCollecterCdEd
        /// <summary>集金担当コード(終了)プロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCdEd
        {
            get { return _billCollecterCdEd; }
            set { _billCollecterCdEd = value; }
        }

        /// public propaty name  :  CustomerAgentCdSt
        /// <summary>顧客担当コード(開始)プロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCdSt
        {
            get { return _customerAgentCdSt; }
            set { _customerAgentCdSt = value; }
        }

        /// public propaty name  :  CustomerAgentCdEd
        /// <summary>顧客担当コード(終了)プロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCdEd
        {
            get { return _customerAgentCdEd; }
            set { _customerAgentCdEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>販売エリアコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>販売エリアコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>得意先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>得意先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  EBooksOutMode
        /// <summary>電子帳簿出力対象プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電子帳簿出力対象プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EBooksOutMode
        {
            get { return _eBooksOutMode; }
            set { _eBooksOutMode = value; }
        }

        /// public propaty name  :  PrintOutMode
        /// <summary>印刷対象プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷対象プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintOutMode
        {
            get { return _printOutMode; }
            set { _printOutMode = value; }
        }

        /// public propaty name  :  EBooksFlg
        /// <summary>同期処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   同期処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EBooksFlg
        {
            get { return _eBooksFlg; }
            set { _eBooksFlg = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>伝票印刷種別プロパティ</summary>
        /// <value>0:請求一覧,60:明細請求書</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  TaxPrintDiv
        /// <summary>税別内訳印字区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税別内訳印字区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>税率1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>税率2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }

        /// <summary>
        /// 請求書(鑑部)抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_EBooksDemandTotalWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_EBooksDemandTotalWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_EBooksDemandTotalWork()
        {
        }

    }

}
