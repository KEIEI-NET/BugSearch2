//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注処理
// プログラム概要   : 発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2008/06/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InpDisplay
    /// <summary>
    ///                      画面入力クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   画面入力クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/06/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InpDisplay
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点名</summary>
        private string _sectionName = "";

        /// <summary>入力担当者コード</summary>
        private string _employeeCode = "";

        /// <summary>入力担当者名</summary>
        private string _employeeName = "";

        /// <summary>業務区分</summary>
        /// <remarks>1:発注 2:見積 3:在庫確認 4:取消処理</remarks>
        private Int32 _businessCode;

        /// <summary>端末番号区分</summary>
        /// <remarks>0:自端末 1:他端末 2:全端末</remarks>
        private Int32 _cashRegisterNoDiv;

        /// <summary>端末番号</summary>
        /// <remarks>端末番号</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>システム区分</summary>
        /// <remarks>0:伝発発注 1:検索発注</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE発注番号（開始）</summary>
        private Int32 _uOESalesOrderNoSt;

        /// <summary>UOE発注番号（終了）</summary>
        private Int32 _uOESalesOrderNoEd;

        /// <summary>開始売上日付</summary>
        private DateTime _salesDateSt;

        /// <summary>終了売上日付</summary>
        private DateTime _salesDateEd;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名</summary>
        private string _customerName = "";

        /// <summary>発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>業務区分名称</summary>
        private string _businessName = "";


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

        /// public propaty name  :  SectionName
        /// <summary>拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>入力担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>入力担当者名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力担当者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  BusinessCode
        /// <summary>業務区分プロパティ</summary>
        /// <value>1:発注 2:見積 3:在庫確認 4:取消処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業務区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  CashRegisterNoDiv
        /// <summary>端末番号区分プロパティ</summary>
        /// <value>0:自端末 1:他端末 2:全端末</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末番号区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNoDiv
        {
            get { return _cashRegisterNoDiv; }
            set { _cashRegisterNoDiv = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>端末番号プロパティ</summary>
        /// <value>端末番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>システム区分プロパティ</summary>
        /// <value>0:伝発発注 1:検索発注</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   システム区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  UOESalesOrderNoSt
        /// <summary>UOE発注番号（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注番号（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESalesOrderNoSt
        {
            get { return _uOESalesOrderNoSt; }
            set { _uOESalesOrderNoSt = value; }
        }

        /// public propaty name  :  UOESalesOrderNoEd
        /// <summary>UOE発注番号（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注番号（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESalesOrderNoEd
        {
            get { return _uOESalesOrderNoEd; }
            set { _uOESalesOrderNoEd = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>開始売上日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>終了売上日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
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

        /// public propaty name  :  CustomerName
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
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

        /// public propaty name  :  BusinessName
        /// <summary>業務区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業務区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }


        /// <summary>
        /// 画面入力クラスコンストラクタ
        /// </summary>
        /// <returns>InpDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpDisplay()
        {
        }

        /// <summary>
        /// 画面入力クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionName">拠点名</param>
        /// <param name="employeeCode">入力担当者コード</param>
        /// <param name="employeeName">入力担当者名</param>
        /// <param name="businessCode">業務区分(1:発注 2:見積 3:在庫確認 4:取消処理)</param>
        /// <param name="cashRegisterNoDiv">端末番号区分(0:自端末 1:他端末 2:全端末)</param>
        /// <param name="cashRegisterNo">端末番号(端末番号)</param>
        /// <param name="systemDivCd">システム区分(0:伝発発注 1:検索発注)</param>
        /// <param name="uOESalesOrderNoSt">UOE発注番号（開始）</param>
        /// <param name="uOESalesOrderNoEd">UOE発注番号（終了）</param>
        /// <param name="salesDateSt">開始売上日付</param>
        /// <param name="salesDateEd">終了売上日付</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名</param>
        /// <param name="uOESupplierCd">発注先コード</param>
        /// <param name="uOESupplierName">UOE発注先名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="businessName">業務区分名称</param>
        /// <returns>InpDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpDisplay(string enterpriseCode, string sectionCode, string sectionName, string employeeCode, string employeeName, Int32 businessCode, Int32 cashRegisterNoDiv, Int32 cashRegisterNo, Int32 systemDivCd, Int32 uOESalesOrderNoSt, Int32 uOESalesOrderNoEd, DateTime salesDateSt, DateTime salesDateEd, Int32 customerCode, string customerName, Int32 uOESupplierCd, string uOESupplierName, string enterpriseName, string businessName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._businessCode = businessCode;
            this._cashRegisterNoDiv = cashRegisterNoDiv;
            this._cashRegisterNo = cashRegisterNo;
            this._systemDivCd = systemDivCd;
            this._uOESalesOrderNoSt = uOESalesOrderNoSt;
            this._uOESalesOrderNoEd = uOESalesOrderNoEd;
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._enterpriseName = enterpriseName;
            this._businessName = businessName;

        }

        /// <summary>
        /// 画面入力クラス複製処理
        /// </summary>
        /// <returns>InpDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいInpDisplayクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpDisplay Clone()
        {
            return new InpDisplay(this._enterpriseCode, this._sectionCode, this._sectionName, this._employeeCode, this._employeeName, this._businessCode, this._cashRegisterNoDiv, this._cashRegisterNo, this._systemDivCd, this._uOESalesOrderNoSt, this._uOESalesOrderNoEd, this._salesDateSt, this._salesDateEd, this._customerCode, this._customerName, this._uOESupplierCd, this._uOESupplierName, this._enterpriseName, this._businessName);
        }

        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のInpDisplayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(InpDisplay target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.CashRegisterNoDiv == target.CashRegisterNoDiv)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.UOESalesOrderNoSt == target.UOESalesOrderNoSt)
                 && (this.UOESalesOrderNoEd == target.UOESalesOrderNoEd)
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.BusinessName == target.BusinessName));
        }

        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="inpDisplay1">
        ///                    比較するInpDisplayクラスのインスタンス
        /// </param>
        /// <param name="inpDisplay2">比較するInpDisplayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            return ((inpDisplay1.EnterpriseCode == inpDisplay2.EnterpriseCode)
                 && (inpDisplay1.SectionCode == inpDisplay2.SectionCode)
                 && (inpDisplay1.SectionName == inpDisplay2.SectionName)
                 && (inpDisplay1.EmployeeCode == inpDisplay2.EmployeeCode)
                 && (inpDisplay1.EmployeeName == inpDisplay2.EmployeeName)
                 && (inpDisplay1.BusinessCode == inpDisplay2.BusinessCode)
                 && (inpDisplay1.CashRegisterNoDiv == inpDisplay2.CashRegisterNoDiv)
                 && (inpDisplay1.CashRegisterNo == inpDisplay2.CashRegisterNo)
                 && (inpDisplay1.SystemDivCd == inpDisplay2.SystemDivCd)
                 && (inpDisplay1.UOESalesOrderNoSt == inpDisplay2.UOESalesOrderNoSt)
                 && (inpDisplay1.UOESalesOrderNoEd == inpDisplay2.UOESalesOrderNoEd)
                 && (inpDisplay1.SalesDateSt == inpDisplay2.SalesDateSt)
                 && (inpDisplay1.SalesDateEd == inpDisplay2.SalesDateEd)
                 && (inpDisplay1.CustomerCode == inpDisplay2.CustomerCode)
                 && (inpDisplay1.CustomerName == inpDisplay2.CustomerName)
                 && (inpDisplay1.UOESupplierCd == inpDisplay2.UOESupplierCd)
                 && (inpDisplay1.UOESupplierName == inpDisplay2.UOESupplierName)
                 && (inpDisplay1.EnterpriseName == inpDisplay2.EnterpriseName)
                 && (inpDisplay1.BusinessName == inpDisplay2.BusinessName));
        }
        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のInpDisplayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(InpDisplay target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.CashRegisterNoDiv != target.CashRegisterNoDiv) resList.Add("CashRegisterNoDiv");
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.UOESalesOrderNoSt != target.UOESalesOrderNoSt) resList.Add("UOESalesOrderNoSt");
            if (this.UOESalesOrderNoEd != target.UOESalesOrderNoEd) resList.Add("UOESalesOrderNoEd");
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");

            return resList;
        }

        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="inpDisplay1">比較するInpDisplayクラスのインスタンス</param>
        /// <param name="inpDisplay2">比較するInpDisplayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            ArrayList resList = new ArrayList();
            if (inpDisplay1.EnterpriseCode != inpDisplay2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (inpDisplay1.SectionCode != inpDisplay2.SectionCode) resList.Add("SectionCode");
            if (inpDisplay1.SectionName != inpDisplay2.SectionName) resList.Add("SectionName");
            if (inpDisplay1.EmployeeCode != inpDisplay2.EmployeeCode) resList.Add("EmployeeCode");
            if (inpDisplay1.EmployeeName != inpDisplay2.EmployeeName) resList.Add("EmployeeName");
            if (inpDisplay1.BusinessCode != inpDisplay2.BusinessCode) resList.Add("BusinessCode");
            if (inpDisplay1.CashRegisterNoDiv != inpDisplay2.CashRegisterNoDiv) resList.Add("CashRegisterNoDiv");
            if (inpDisplay1.CashRegisterNo != inpDisplay2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (inpDisplay1.SystemDivCd != inpDisplay2.SystemDivCd) resList.Add("SystemDivCd");
            if (inpDisplay1.UOESalesOrderNoSt != inpDisplay2.UOESalesOrderNoSt) resList.Add("UOESalesOrderNoSt");
            if (inpDisplay1.UOESalesOrderNoEd != inpDisplay2.UOESalesOrderNoEd) resList.Add("UOESalesOrderNoEd");
            if (inpDisplay1.SalesDateSt != inpDisplay2.SalesDateSt) resList.Add("SalesDateSt");
            if (inpDisplay1.SalesDateEd != inpDisplay2.SalesDateEd) resList.Add("SalesDateEd");
            if (inpDisplay1.CustomerCode != inpDisplay2.CustomerCode) resList.Add("CustomerCode");
            if (inpDisplay1.CustomerName != inpDisplay2.CustomerName) resList.Add("CustomerName");
            if (inpDisplay1.UOESupplierCd != inpDisplay2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (inpDisplay1.UOESupplierName != inpDisplay2.UOESupplierName) resList.Add("UOESupplierName");
            if (inpDisplay1.EnterpriseName != inpDisplay2.EnterpriseName) resList.Add("EnterpriseName");
            if (inpDisplay1.BusinessName != inpDisplay2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }

}
