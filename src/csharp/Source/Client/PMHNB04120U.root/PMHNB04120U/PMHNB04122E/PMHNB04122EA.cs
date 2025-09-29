using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomInqOrderCndtn
    /// <summary>
    ///                      得意先過年度実績照会抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先過年度実績照会抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomInqOrderCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private Int32 _customerCode;

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>得意先名称</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _customerName = "";
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<

        /// <summary>開始計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _st_AddUpYearMonth;

        /// <summary>終了計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _ed_AddUpYearMonth;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>計上拠点名称</summary>
        private string _addUpSecName = "";


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// public propaty name  :  CustomerName
        /// <summary>得意先名称プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>開始計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_AddUpYearMonth
        {
            get { return _st_AddUpYearMonth; }
            set { _st_AddUpYearMonth = value; }
        }

        /// public propaty name  :  Ed_AddUpYearMonth
        /// <summary>終了計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
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

        /// public propaty name  :  AddUpSecName
        /// <summary>計上拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }


        /// <summary>
        /// 得意先過年度実績照会抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>CustomInqOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomInqOrderCndtn()
        {
        }

        /// <summary>
        /// 得意先過年度実績照会抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="addUpSecCode">計上拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="customerCode">得意先コード(納入先の場合の使用可能項目)</param>
        /// <param name="st_AddUpYearMonth">開始計上年月(YYYYMM)</param>
        /// <param name="ed_AddUpYearMonth">終了計上年月(YYYYMM)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="addUpSecName">計上拠点名称</param>
        /// <param name="customerName">得意先名称</param> // ADD 2010/07/20 
        /// <returns>CustomInqOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqOrderCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public CustomInqOrderCndtn(string enterpriseCode, string addUpSecCode, Int32 customerCode, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, string enterpriseName, string addUpSecName) // DEL 2010/07/20 
        public CustomInqOrderCndtn(string enterpriseCode, string addUpSecCode, Int32 customerCode, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, string enterpriseName, string addUpSecName, string customerName) // ADD 2010/07/20 
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpSecCode = addUpSecCode;
            this._customerCode = customerCode;
            this._st_AddUpYearMonth = st_AddUpYearMonth;
            this._ed_AddUpYearMonth = ed_AddUpYearMonth;
            this._enterpriseName = enterpriseName;
            this._addUpSecName = addUpSecName;
            this._customerName = customerName; // ADD 2010/07/20 

        }

        /// <summary>
        /// 得意先過年度実績照会抽出条件クラス複製処理
        /// </summary>
        /// <returns>CustomInqOrderCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustomInqOrderCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomInqOrderCndtn Clone()
        {
            //return new CustomInqOrderCndtn(this._enterpriseCode, this._addUpSecCode, this._customerCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._addUpSecName); // DEL 2010/07/20 
            return new CustomInqOrderCndtn(this._enterpriseCode, this._addUpSecCode, this._customerCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._addUpSecName, this._customerName); // ADD 2010/07/20 
        }

        /// <summary>
        /// 得意先過年度実績照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomInqOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CustomInqOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
                 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.CustomerName == target.CustomerName)); // ADD 2010/07/20 
        }

        /// <summary>
        /// 得意先過年度実績照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="customInqOrderCndtn1">
        ///                    比較するCustomInqOrderCndtnクラスのインスタンス
        /// </param>
        /// <param name="customInqOrderCndtn2">比較するCustomInqOrderCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqOrderCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CustomInqOrderCndtn customInqOrderCndtn1, CustomInqOrderCndtn customInqOrderCndtn2)
        {
            return ((customInqOrderCndtn1.EnterpriseCode == customInqOrderCndtn2.EnterpriseCode)
                 && (customInqOrderCndtn1.AddUpSecCode == customInqOrderCndtn2.AddUpSecCode)
                 && (customInqOrderCndtn1.CustomerCode == customInqOrderCndtn2.CustomerCode)
                 && (customInqOrderCndtn1.St_AddUpYearMonth == customInqOrderCndtn2.St_AddUpYearMonth)
                 && (customInqOrderCndtn1.Ed_AddUpYearMonth == customInqOrderCndtn2.Ed_AddUpYearMonth)
                 && (customInqOrderCndtn1.EnterpriseName == customInqOrderCndtn2.EnterpriseName)
                 && (customInqOrderCndtn1.AddUpSecName == customInqOrderCndtn2.AddUpSecName)
                 && (customInqOrderCndtn1.CustomerName == customInqOrderCndtn2.CustomerName)); // ADD 2010/07/20 
        }
        /// <summary>
        /// 得意先過年度実績照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomInqOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CustomInqOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.St_AddUpYearMonth != target.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName"); // ADD 2010/07/20 

            return resList;
        }

        /// <summary>
        /// 得意先過年度実績照会抽出条件クラス比較処理
        /// </summary>
        /// <param name="customInqOrderCndtn1">比較するCustomInqOrderCndtnクラスのインスタンス</param>
        /// <param name="customInqOrderCndtn2">比較するCustomInqOrderCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomInqOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CustomInqOrderCndtn customInqOrderCndtn1, CustomInqOrderCndtn customInqOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (customInqOrderCndtn1.EnterpriseCode != customInqOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customInqOrderCndtn1.AddUpSecCode != customInqOrderCndtn2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (customInqOrderCndtn1.CustomerCode != customInqOrderCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (customInqOrderCndtn1.St_AddUpYearMonth != customInqOrderCndtn2.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (customInqOrderCndtn1.Ed_AddUpYearMonth != customInqOrderCndtn2.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (customInqOrderCndtn1.EnterpriseName != customInqOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");
            if (customInqOrderCndtn1.AddUpSecName != customInqOrderCndtn2.AddUpSecName) resList.Add("AddUpSecName");
            if (customInqOrderCndtn1.CustomerName != customInqOrderCndtn2.CustomerName) resList.Add("CustomerName"); // ADD 2010/07/20 

            return resList;
        }
    }
}
