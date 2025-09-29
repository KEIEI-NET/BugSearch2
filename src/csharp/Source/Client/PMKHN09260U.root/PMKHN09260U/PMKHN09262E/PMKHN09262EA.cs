using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustCreditCndtn
    /// <summary>
    ///                      与信額設定処理抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   与信額設定処理抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustCreditCndtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>得意先コード（複数指定）</summary>
        /// <remarks>（配列）nullの場合、開始終了で判定</remarks>
        private Int32[] _customerCodes;

        /// <summary>開始得意先コード</summary>
        private Int32 _st_CustomerCode;

        /// <summary>終了得意先コード</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>処理区分</summary>
        /// <remarks>0:現在売掛残高設定,1:与信額クリア</remarks>
        private Int32 _procDiv;

        /// <summary>与信額フラグ</summary>
        /// <remarks>Trueで処理</remarks>
        private Boolean _creditMoneyFlg;

        /// <summary>警告与信額フラグ</summary>
        /// <remarks>Trueで処理</remarks>
        private Boolean _warningCrdMnyFrg;

        /// <summary>現在売掛残高フラグ</summary>
        /// <remarks>Trueで処理</remarks>
        private Boolean _accRecDiv;

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

        /// public propaty name  :  CustomerCodes
        /// <summary>得意先コード（複数指定）プロパティ</summary>
        /// <value>（配列）nullの場合、開始終了で判定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] CustomerCodes
        {
            get { return _customerCodes; }
            set { _customerCodes = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>0:現在売掛残高設定,1:与信額クリア</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  CreditMoneyFlg
        /// <summary>与信額フラグプロパティ</summary>
        /// <value>Trueで処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信額フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean CreditMoneyFlg
        {
            get { return _creditMoneyFlg; }
            set { _creditMoneyFlg = value; }
        }

        /// public propaty name  :  WarningCrdMnyFrg
        /// <summary>警告与信額フラグプロパティ</summary>
        /// <value>Trueで処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   警告与信額フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean WarningCrdMnyFrg
        {
            get { return _warningCrdMnyFrg; }
            set { _warningCrdMnyFrg = value; }
        }

        /// public propaty name  :  AccRecDiv
        /// <summary>現在売掛残高フラグプロパティ</summary>
        /// <value>Trueで処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在売掛残高フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean AccRecDiv
        {
            get { return _accRecDiv; }
            set { _accRecDiv = value; }
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
        /// 得意先マスタ(与信設定)抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>CustCreditCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustCreditCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustCreditCndtn()
        {
        }

        /// <summary>
        /// 得意先マスタ(与信設定)抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="customerCodes">得意先コード（複数指定）(（配列）nullの場合、開始終了で判定)</param>
        /// <param name="st_CustomerCode">開始得意先コード</param>
        /// <param name="ed_CustomerCode">終了得意先コード</param>
        /// <param name="totalDay">締日(DD)</param>
        /// <param name="procDiv">処理区分(0:現在売掛残高設定,1:与信額クリア)</param>
        /// <param name="creditMoneyFlg">与信額フラグ(Trueで処理)</param>
        /// <param name="warningCrdMnyFrg">警告与信額フラグ(Trueで処理)</param>
        /// <param name="accRecDiv">現在売掛残高フラグ(Trueで処理)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>CustCreditCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustCreditCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustCreditCndtn(string enterpriseCode, Int32[] customerCodes, Int32 st_CustomerCode, Int32 ed_CustomerCode, Int32 totalDay, Int32 procDiv, Boolean creditMoneyFlg, Boolean warningCrdMnyFrg, Boolean accRecDiv, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCodes = customerCodes;
            this._st_CustomerCode = st_CustomerCode;
            this._ed_CustomerCode = ed_CustomerCode;
            this._totalDay = totalDay;
            this._procDiv = procDiv;
            this._creditMoneyFlg = creditMoneyFlg;
            this._warningCrdMnyFrg = warningCrdMnyFrg;
            this._accRecDiv = accRecDiv;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 得意先マスタ(与信設定)抽出条件クラス複製処理
        /// </summary>
        /// <returns>CustCreditCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustCreditCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustCreditCndtn Clone()
        {
            return new CustCreditCndtn(this._enterpriseCode, this._customerCodes, this._st_CustomerCode, this._ed_CustomerCode, this._totalDay, this._procDiv, this._creditMoneyFlg, this._warningCrdMnyFrg, this._accRecDiv, this._enterpriseName);
        }

        /// <summary>
        /// 得意先マスタ(与信設定)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCustCreditCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustCreditCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CustCreditCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.CustomerCodes == target.CustomerCodes)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.TotalDay == target.TotalDay)
                 && (this.ProcDiv == target.ProcDiv)
                 && (this.CreditMoneyFlg == target.CreditMoneyFlg)
                 && (this.WarningCrdMnyFrg == target.WarningCrdMnyFrg)
                 && (this.AccRecDiv == target.AccRecDiv)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 得意先マスタ(与信設定)抽出条件クラス比較処理
        /// </summary>
        /// <param name="custCreditCndtn1">
        ///                    比較するCustCreditCndtnクラスのインスタンス
        /// </param>
        /// <param name="custCreditCndtn2">比較するCustCreditCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustCreditCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CustCreditCndtn custCreditCndtn1, CustCreditCndtn custCreditCndtn2)
        {
            return ((custCreditCndtn1.EnterpriseCode == custCreditCndtn2.EnterpriseCode)
                 && (custCreditCndtn1.CustomerCodes == custCreditCndtn2.CustomerCodes)
                 && (custCreditCndtn1.St_CustomerCode == custCreditCndtn2.St_CustomerCode)
                 && (custCreditCndtn1.Ed_CustomerCode == custCreditCndtn2.Ed_CustomerCode)
                 && (custCreditCndtn1.TotalDay == custCreditCndtn2.TotalDay)
                 && (custCreditCndtn1.ProcDiv == custCreditCndtn2.ProcDiv)
                 && (custCreditCndtn1.CreditMoneyFlg == custCreditCndtn2.CreditMoneyFlg)
                 && (custCreditCndtn1.WarningCrdMnyFrg == custCreditCndtn2.WarningCrdMnyFrg)
                 && (custCreditCndtn1.AccRecDiv == custCreditCndtn2.AccRecDiv)
                 && (custCreditCndtn1.EnterpriseName == custCreditCndtn2.EnterpriseName));
        }
        /// <summary>
        /// 得意先マスタ(与信設定)抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCustCreditCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustCreditCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CustCreditCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.CustomerCodes != target.CustomerCodes) resList.Add("CustomerCodes");
            if (this.St_CustomerCode != target.St_CustomerCode) resList.Add("St_CustomerCode");
            if (this.Ed_CustomerCode != target.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.ProcDiv != target.ProcDiv) resList.Add("ProcDiv");
            if (this.CreditMoneyFlg != target.CreditMoneyFlg) resList.Add("CreditMoneyFlg");
            if (this.WarningCrdMnyFrg != target.WarningCrdMnyFrg) resList.Add("WarningCrdMnyFrg");
            if (this.AccRecDiv != target.AccRecDiv) resList.Add("AccRecDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 得意先マスタ(与信設定)抽出条件クラス比較処理
        /// </summary>
        /// <param name="custCreditCndtn1">比較するCustCreditCndtnクラスのインスタンス</param>
        /// <param name="custCreditCndtn2">比較するCustCreditCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustCreditCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CustCreditCndtn custCreditCndtn1, CustCreditCndtn custCreditCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (custCreditCndtn1.EnterpriseCode != custCreditCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custCreditCndtn1.CustomerCodes != custCreditCndtn2.CustomerCodes) resList.Add("CustomerCodes");
            if (custCreditCndtn1.St_CustomerCode != custCreditCndtn2.St_CustomerCode) resList.Add("St_CustomerCode");
            if (custCreditCndtn1.Ed_CustomerCode != custCreditCndtn2.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (custCreditCndtn1.TotalDay != custCreditCndtn2.TotalDay) resList.Add("TotalDay");
            if (custCreditCndtn1.ProcDiv != custCreditCndtn2.ProcDiv) resList.Add("ProcDiv");
            if (custCreditCndtn1.CreditMoneyFlg != custCreditCndtn2.CreditMoneyFlg) resList.Add("CreditMoneyFlg");
            if (custCreditCndtn1.WarningCrdMnyFrg != custCreditCndtn2.WarningCrdMnyFrg) resList.Add("WarningCrdMnyFrg");
            if (custCreditCndtn1.AccRecDiv != custCreditCndtn2.AccRecDiv) resList.Add("AccRecDiv");
            if (custCreditCndtn1.EnterpriseName != custCreditCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
