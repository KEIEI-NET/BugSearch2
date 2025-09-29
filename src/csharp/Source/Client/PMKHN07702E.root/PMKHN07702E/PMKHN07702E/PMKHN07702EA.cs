using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesSliptextCndtn
    /// <summary>
    ///                      売上データテキスト出力（TMY)条件
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データテキスト出力（TMY)条件ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2012/11/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesSliptextCndtn
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

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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


        /// <summary>
        /// 売上データテキスト出力（TMY)条件コンストラクタ
        /// </summary>
        /// <returns>SalesSliptextCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSliptextCndtn()
        {
        }

        /// <summary>
        /// 売上データテキスト出力（TMY)条件コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="salesDateSt">対象日付(開始)((YYYYMMDD))</param>
        /// <param name="salesDateEd">対象日付(終了)((YYYYMMDD))</param>
        /// <param name="custAnalysCode1">得意先分析コード1</param>
        /// <param name="custAnalysCode2">得意先分析コード2</param>
        /// <param name="custAnalysCode3">得意先分析コード3</param>
        /// <param name="custAnalysCode4">得意先分析コード4</param>
        /// <param name="custAnalysCode5">得意先分析コード5</param>
        /// <param name="custAnalysCode6">得意先分析コード6</param>
        /// <param name="carMngNo1">車両管理番号</param>
        /// <param name="slipNote">伝票備考</param>
        /// <param name="slipNote2">伝票備考２</param>
        /// <param name="slipNote3">伝票備考３</param>
        /// <param name="partySaleSlipNum">相手先伝票番号(得意先注文番号)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>SalesSliptextCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSliptextCndtn(string enterpriseCode, Int32 salesDateSt, Int32 salesDateEd, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string carMngNo1, string slipNote, string slipNote2, string slipNote3, string partySaleSlipNum, Int32 supplierCd, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._carMngNo1 = carMngNo1;
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            this._partySaleSlipNum = partySaleSlipNum;
            this._supplierCd = supplierCd;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 売上データテキスト出力（TMY)条件複製処理
        /// </summary>
        /// <returns>SalesSliptextCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesSliptextCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSliptextCndtn Clone()
        {
            return new SalesSliptextCndtn(this._enterpriseCode, this._salesDateSt, this._salesDateEd, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._carMngNo1, this._slipNote, this._slipNote2, this._slipNote3, this._partySaleSlipNum, this._supplierCd, this._enterpriseName);
        }

        /// <summary>
        /// 売上データテキスト出力（TMY)条件比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSliptextCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalesSliptextCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.CustAnalysCode1 == target.CustAnalysCode1)
                 && (this.CustAnalysCode2 == target.CustAnalysCode2)
                 && (this.CustAnalysCode3 == target.CustAnalysCode3)
                 && (this.CustAnalysCode4 == target.CustAnalysCode4)
                 && (this.CustAnalysCode5 == target.CustAnalysCode5)
                 && (this.CustAnalysCode6 == target.CustAnalysCode6)
                 && (this.CarMngNo1 == target.CarMngNo1)
                 && (this.SlipNote == target.SlipNote)
                 && (this.SlipNote2 == target.SlipNote2)
                 && (this.SlipNote3 == target.SlipNote3)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 売上データテキスト出力（TMY)条件比較処理
        /// </summary>
        /// <param name="salesSliptextCndtn1">
        ///                    比較するSalesSliptextCndtnクラスのインスタンス
        /// </param>
        /// <param name="salesSliptextCndtn2">比較するSalesSliptextCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalesSliptextCndtn salesSliptextCndtn1, SalesSliptextCndtn salesSliptextCndtn2)
        {
            return ((salesSliptextCndtn1.EnterpriseCode == salesSliptextCndtn2.EnterpriseCode)
                 && (salesSliptextCndtn1.SalesDateSt == salesSliptextCndtn2.SalesDateSt)
                 && (salesSliptextCndtn1.SalesDateEd == salesSliptextCndtn2.SalesDateEd)
                 && (salesSliptextCndtn1.CustAnalysCode1 == salesSliptextCndtn2.CustAnalysCode1)
                 && (salesSliptextCndtn1.CustAnalysCode2 == salesSliptextCndtn2.CustAnalysCode2)
                 && (salesSliptextCndtn1.CustAnalysCode3 == salesSliptextCndtn2.CustAnalysCode3)
                 && (salesSliptextCndtn1.CustAnalysCode4 == salesSliptextCndtn2.CustAnalysCode4)
                 && (salesSliptextCndtn1.CustAnalysCode5 == salesSliptextCndtn2.CustAnalysCode5)
                 && (salesSliptextCndtn1.CustAnalysCode6 == salesSliptextCndtn2.CustAnalysCode6)
                 && (salesSliptextCndtn1.CarMngNo1 == salesSliptextCndtn2.CarMngNo1)
                 && (salesSliptextCndtn1.SlipNote == salesSliptextCndtn2.SlipNote)
                 && (salesSliptextCndtn1.SlipNote2 == salesSliptextCndtn2.SlipNote2)
                 && (salesSliptextCndtn1.SlipNote3 == salesSliptextCndtn2.SlipNote3)
                 && (salesSliptextCndtn1.PartySaleSlipNum == salesSliptextCndtn2.PartySaleSlipNum)
                 && (salesSliptextCndtn1.SupplierCd == salesSliptextCndtn2.SupplierCd)
                 && (salesSliptextCndtn1.EnterpriseName == salesSliptextCndtn2.EnterpriseName));
        }
        /// <summary>
        /// 売上データテキスト出力（TMY)条件比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSliptextCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalesSliptextCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.CustAnalysCode1 != target.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (this.CustAnalysCode2 != target.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (this.CustAnalysCode3 != target.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (this.CustAnalysCode4 != target.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (this.CustAnalysCode5 != target.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (this.CustAnalysCode6 != target.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (this.CarMngNo1 != target.CarMngNo1) resList.Add("CarMngNo1");
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
            if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 売上データテキスト出力（TMY)条件比較処理
        /// </summary>
        /// <param name="salesSliptextCndtn1">比較するSalesSliptextCndtnクラスのインスタンス</param>
        /// <param name="salesSliptextCndtn2">比較するSalesSliptextCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalesSliptextCndtn salesSliptextCndtn1, SalesSliptextCndtn salesSliptextCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (salesSliptextCndtn1.EnterpriseCode != salesSliptextCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesSliptextCndtn1.SalesDateSt != salesSliptextCndtn2.SalesDateSt) resList.Add("SalesDateSt");
            if (salesSliptextCndtn1.SalesDateEd != salesSliptextCndtn2.SalesDateEd) resList.Add("SalesDateEd");
            if (salesSliptextCndtn1.CustAnalysCode1 != salesSliptextCndtn2.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (salesSliptextCndtn1.CustAnalysCode2 != salesSliptextCndtn2.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (salesSliptextCndtn1.CustAnalysCode3 != salesSliptextCndtn2.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (salesSliptextCndtn1.CustAnalysCode4 != salesSliptextCndtn2.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (salesSliptextCndtn1.CustAnalysCode5 != salesSliptextCndtn2.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (salesSliptextCndtn1.CustAnalysCode6 != salesSliptextCndtn2.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (salesSliptextCndtn1.CarMngNo1 != salesSliptextCndtn2.CarMngNo1) resList.Add("CarMngNo1");
            if (salesSliptextCndtn1.SlipNote != salesSliptextCndtn2.SlipNote) resList.Add("SlipNote");
            if (salesSliptextCndtn1.SlipNote2 != salesSliptextCndtn2.SlipNote2) resList.Add("SlipNote2");
            if (salesSliptextCndtn1.SlipNote3 != salesSliptextCndtn2.SlipNote3) resList.Add("SlipNote3");
            if (salesSliptextCndtn1.PartySaleSlipNum != salesSliptextCndtn2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (salesSliptextCndtn1.SupplierCd != salesSliptextCndtn2.SupplierCd) resList.Add("SupplierCd");
            if (salesSliptextCndtn1.EnterpriseName != salesSliptextCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
