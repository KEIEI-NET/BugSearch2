//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : トヨタ発注処理
// プログラム概要   : トヨタ発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 譚洪
// 作 成 日  2009/12/31  修正内容 : 新規作成
//                                  トヨタ電子カタログとの連携用データとして、UOE発注データから発注送信データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InpHedDisplay
    /// <summary>
    ///                      Hed画面入力クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   Hed画面入力クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/12/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InpHedDisplay
    {
        /// <summary>オンライン番号</summary>
        private Int32 _onlineNo;

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

        /// <summary>業務区分</summary>
        private Int32 _businessCode;

        /// <summary>オンライン行番号</summary>
        private Int32 _onlineRowNo;

        /// <summary>業務区分名称</summary>
        private string _businessName = "";


        /// public propaty name  :  OnlineNo
        /// <summary>オンライン番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
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

        /// public propaty name  :  BusinessCode
        /// <summary>業務区分プロパティ</summary>
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

        /// public propaty name  :  OnlineRowNo
        /// <summary>オンライン行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
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
        /// Hed画面入力クラスコンストラクタ
        /// </summary>
        /// <returns>InpHedDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpHedDisplayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpHedDisplay()
        {
        }

        /// <summary>
        /// Hed画面入力クラスコンストラクタ
        /// </summary>
        /// <param name="onlineNo">オンライン番号</param>
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
        /// <param name="businessCode">業務区分</param>
        /// <param name="onlineRowNo">オンライン行番号</param>
        /// <param name="businessName">業務区分名称</param>
        /// <returns>InpHedDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpHedDisplayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpHedDisplay(Int32 onlineNo, Int32 uOESupplierCd, string uOESupplierName, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, string uoeRemark1, string uoeRemark2, Int32 businessCode, Int32 onlineRowNo, string businessName)
        {
            this._onlineNo = onlineNo;
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
            this._businessCode = businessCode;
            this._onlineRowNo = onlineRowNo;
            this._businessName = businessName;

        }

        /// <summary>
        /// Hed画面入力クラス複製処理
        /// </summary>
        /// <returns>InpHedDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいInpHedDisplayクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpHedDisplay Clone()
        {
            return new InpHedDisplay(this._onlineNo, this._uOESupplierCd, this._uOESupplierName, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._uoeRemark1, this._uoeRemark2, this._businessCode, this._onlineRowNo, this._businessName);
        }

        /// <summary>
        /// Hed画面入力クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のInpHedDisplayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpHedDisplayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(InpHedDisplay target)
        {
            return ((this.OnlineNo == target.OnlineNo)
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
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.OnlineRowNo == target.OnlineRowNo)
                 && (this.BusinessName == target.BusinessName));
        }

        /// <summary>
        /// Hed画面入力クラス比較処理
        /// </summary>
        /// <param name="inpHedDisplay1">
        ///                    比較するInpHedDisplayクラスのインスタンス
        /// </param>
        /// <param name="inpHedDisplay2">比較するInpHedDisplayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpHedDisplayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(InpHedDisplay inpHedDisplay1, InpHedDisplay inpHedDisplay2)
        {
            return ((inpHedDisplay1.OnlineNo == inpHedDisplay2.OnlineNo)
                 && (inpHedDisplay1.UOESupplierCd == inpHedDisplay2.UOESupplierCd)
                 && (inpHedDisplay1.UOESupplierName == inpHedDisplay2.UOESupplierName)
                 && (inpHedDisplay1.UOEDeliGoodsDiv == inpHedDisplay2.UOEDeliGoodsDiv)
                 && (inpHedDisplay1.DeliveredGoodsDivNm == inpHedDisplay2.DeliveredGoodsDivNm)
                 && (inpHedDisplay1.FollowDeliGoodsDiv == inpHedDisplay2.FollowDeliGoodsDiv)
                 && (inpHedDisplay1.FollowDeliGoodsDivNm == inpHedDisplay2.FollowDeliGoodsDivNm)
                 && (inpHedDisplay1.UOEResvdSection == inpHedDisplay2.UOEResvdSection)
                 && (inpHedDisplay1.UOEResvdSectionNm == inpHedDisplay2.UOEResvdSectionNm)
                 && (inpHedDisplay1.EmployeeCode == inpHedDisplay2.EmployeeCode)
                 && (inpHedDisplay1.EmployeeName == inpHedDisplay2.EmployeeName)
                 && (inpHedDisplay1.UoeRemark1 == inpHedDisplay2.UoeRemark1)
                 && (inpHedDisplay1.UoeRemark2 == inpHedDisplay2.UoeRemark2)
                 && (inpHedDisplay1.BusinessCode == inpHedDisplay2.BusinessCode)
                 && (inpHedDisplay1.OnlineRowNo == inpHedDisplay2.OnlineRowNo)
                 && (inpHedDisplay1.BusinessName == inpHedDisplay2.BusinessName));
        }
        /// <summary>
        /// Hed画面入力クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のInpHedDisplayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpHedDisplayクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(InpHedDisplay target)
        {
            ArrayList resList = new ArrayList();
            if (this.OnlineNo != target.OnlineNo) resList.Add("OnlineNo");
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
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.OnlineRowNo != target.OnlineRowNo) resList.Add("OnlineRowNo");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");

            return resList;
        }

        /// <summary>
        /// Hed画面入力クラス比較処理
        /// </summary>
        /// <param name="inpHedDisplay1">比較するInpHedDisplayクラスのインスタンス</param>
        /// <param name="inpHedDisplay2">比較するInpHedDisplayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpHedDisplayクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(InpHedDisplay inpHedDisplay1, InpHedDisplay inpHedDisplay2)
        {
            ArrayList resList = new ArrayList();
            if (inpHedDisplay1.OnlineNo != inpHedDisplay2.OnlineNo) resList.Add("OnlineNo");
            if (inpHedDisplay1.UOESupplierCd != inpHedDisplay2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (inpHedDisplay1.UOESupplierName != inpHedDisplay2.UOESupplierName) resList.Add("UOESupplierName");
            if (inpHedDisplay1.UOEDeliGoodsDiv != inpHedDisplay2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (inpHedDisplay1.DeliveredGoodsDivNm != inpHedDisplay2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (inpHedDisplay1.FollowDeliGoodsDiv != inpHedDisplay2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (inpHedDisplay1.FollowDeliGoodsDivNm != inpHedDisplay2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (inpHedDisplay1.UOEResvdSection != inpHedDisplay2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (inpHedDisplay1.UOEResvdSectionNm != inpHedDisplay2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (inpHedDisplay1.EmployeeCode != inpHedDisplay2.EmployeeCode) resList.Add("EmployeeCode");
            if (inpHedDisplay1.EmployeeName != inpHedDisplay2.EmployeeName) resList.Add("EmployeeName");
            if (inpHedDisplay1.UoeRemark1 != inpHedDisplay2.UoeRemark1) resList.Add("UoeRemark1");
            if (inpHedDisplay1.UoeRemark2 != inpHedDisplay2.UoeRemark2) resList.Add("UoeRemark2");
            if (inpHedDisplay1.BusinessCode != inpHedDisplay2.BusinessCode) resList.Add("BusinessCode");
            if (inpHedDisplay1.OnlineRowNo != inpHedDisplay2.OnlineRowNo) resList.Add("OnlineRowNo");
            if (inpHedDisplay1.BusinessName != inpHedDisplay2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }
}
