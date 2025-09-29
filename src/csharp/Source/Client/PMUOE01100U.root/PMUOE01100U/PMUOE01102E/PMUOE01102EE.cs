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
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
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

        /// <summary>業務区分</summary>
        /// <remarks>1:発注 2:見積 3:在庫確認</remarks>
        private Int32 _businessCode;

        /// <summary>システム区分</summary>
        /// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";

        /// <summary>UOE納品区分</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>納品区分名称</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>フォロー納品区分</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>フォロー納品区分名称</summary>
        private string _followDeliGoodsDivNm = "";

        /// <summary>UOE指定拠点</summary>
        private string _uOEResvdSection = "";

        /// <summary>UOE指定拠点名称</summary>
        private string _uOEResvdSectionNm = "";

        /// <summary>従業員コード</summary>
        /// <remarks>依頼者コード</remarks>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        /// <remarks>依頼者名称</remarks>
        private string _employeeName = "";

        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

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

        /// public propaty name  :  BusinessCode
        /// <summary>業務区分プロパティ</summary>
        /// <value>1:発注 2:見積 3:在庫確認</value>
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

        /// public propaty name  :  SystemDivCd
        /// <summary>システム区分プロパティ</summary>
        /// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充</value>
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

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
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

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>フォロー納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>フォロー納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE指定拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE指定拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>UOE指定拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE指定拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>依頼者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>従業員名称プロパティ</summary>
        /// <value>依頼者名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
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
        /// <param name="businessCode">業務区分(1:発注 2:見積 3:在庫確認)</param>
        /// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充)</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESupplierName">UOE発注先名称</param>
        /// <param name="uOEDeliGoodsDiv">UOE納品区分</param>
        /// <param name="deliveredGoodsDivNm">納品区分名称</param>
        /// <param name="followDeliGoodsDiv">フォロー納品区分</param>
        /// <param name="followDeliGoodsDivNm">フォロー納品区分名称</param>
        /// <param name="uOEResvdSection">UOE指定拠点</param>
        /// <param name="uOEResvdSectionNm">UOE指定拠点名称</param>
        /// <param name="employeeCode">従業員コード(依頼者コード)</param>
        /// <param name="employeeName">従業員名称(依頼者名称)</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="businessName">業務区分名称</param>
        /// <returns>InpDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpDisplay(string enterpriseCode, string sectionCode, string sectionName, Int32 businessCode, Int32 systemDivCd, Int32 uOESupplierCd, string uOESupplierName, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, string uoeRemark1, string uoeRemark2, string enterpriseName, string businessName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._businessCode = businessCode;
            this._systemDivCd = systemDivCd;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._followDeliGoodsDivNm = followDeliGoodsDivNm;
            this._uOEResvdSection = uOEResvdSection;
            this._uOEResvdSectionNm = uOEResvdSectionNm;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
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
            return new InpDisplay(this._enterpriseCode, this._sectionCode, this._sectionName, this._businessCode, this._systemDivCd, this._uOESupplierCd, this._uOESupplierName, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._uoeRemark1, this._uoeRemark2, this._enterpriseName, this._businessName);
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
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.FollowDeliGoodsDivNm == target.FollowDeliGoodsDivNm)
                 && (this.UOEResvdSection == target.UOEResvdSection)
                 && (this.UOEResvdSectionNm == target.UOEResvdSectionNm)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
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
                 && (inpDisplay1.BusinessCode == inpDisplay2.BusinessCode)
                 && (inpDisplay1.SystemDivCd == inpDisplay2.SystemDivCd)
                 && (inpDisplay1.UOESupplierCd == inpDisplay2.UOESupplierCd)
                 && (inpDisplay1.UOESupplierName == inpDisplay2.UOESupplierName)
                 && (inpDisplay1.UOEDeliGoodsDiv == inpDisplay2.UOEDeliGoodsDiv)
                 && (inpDisplay1.DeliveredGoodsDivNm == inpDisplay2.DeliveredGoodsDivNm)
                 && (inpDisplay1.FollowDeliGoodsDiv == inpDisplay2.FollowDeliGoodsDiv)
                 && (inpDisplay1.FollowDeliGoodsDivNm == inpDisplay2.FollowDeliGoodsDivNm)
                 && (inpDisplay1.UOEResvdSection == inpDisplay2.UOEResvdSection)
                 && (inpDisplay1.UOEResvdSectionNm == inpDisplay2.UOEResvdSectionNm)
                 && (inpDisplay1.EmployeeCode == inpDisplay2.EmployeeCode)
                 && (inpDisplay1.EmployeeName == inpDisplay2.EmployeeName)
                 && (inpDisplay1.UoeRemark1 == inpDisplay2.UoeRemark1)
                 && (inpDisplay1.UoeRemark2 == inpDisplay2.UoeRemark2)
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
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.FollowDeliGoodsDivNm != target.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (this.UOEResvdSection != target.UOEResvdSection) resList.Add("UOEResvdSection");
            if (this.UOEResvdSectionNm != target.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
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
            if (inpDisplay1.BusinessCode != inpDisplay2.BusinessCode) resList.Add("BusinessCode");
            if (inpDisplay1.SystemDivCd != inpDisplay2.SystemDivCd) resList.Add("SystemDivCd");
            if (inpDisplay1.UOESupplierCd != inpDisplay2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (inpDisplay1.UOESupplierName != inpDisplay2.UOESupplierName) resList.Add("UOESupplierName");
            if (inpDisplay1.UOEDeliGoodsDiv != inpDisplay2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (inpDisplay1.DeliveredGoodsDivNm != inpDisplay2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (inpDisplay1.FollowDeliGoodsDiv != inpDisplay2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (inpDisplay1.FollowDeliGoodsDivNm != inpDisplay2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (inpDisplay1.UOEResvdSection != inpDisplay2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (inpDisplay1.UOEResvdSectionNm != inpDisplay2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (inpDisplay1.EmployeeCode != inpDisplay2.EmployeeCode) resList.Add("EmployeeCode");
            if (inpDisplay1.EmployeeName != inpDisplay2.EmployeeName) resList.Add("EmployeeName");
            if (inpDisplay1.UoeRemark1 != inpDisplay2.UoeRemark1) resList.Add("UoeRemark1");
            if (inpDisplay1.UoeRemark2 != inpDisplay2.UoeRemark2) resList.Add("UoeRemark2");
            if (inpDisplay1.EnterpriseName != inpDisplay2.EnterpriseName) resList.Add("EnterpriseName");
            if (inpDisplay1.BusinessName != inpDisplay2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }
}
