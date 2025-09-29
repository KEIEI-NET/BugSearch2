//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ発注データ抽出条件クラス
// プログラム概要   : ＵＯＥ発注データ抽出条件の定義
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangmj
// 作 成 日  2012/09/20  修正内容 : redmine#32404の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESendProcCndtnPara
    /// <summary>
    ///                      UOE送信処理抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE送信処理抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOESendProcCndtnPara
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";
        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<

        /// <summary>レジ番号</summary>
        private Int32 _cashRegisterNo;

        /// <summary>システム区分</summary>
        /// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
        private Int32 _systemDivCd;

        /// <summary>開始UOE発注番号</summary>
        private Int32 _st_UOESalesOrderNo;

        /// <summary>終了UOE発注番号</summary>
        private Int32 _ed_UOESalesOrderNo;

        /// <summary>開始入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _st_InputDay;

        /// <summary>終了入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _ed_InputDay;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>開始オンライン番号</summary>
        private Int32 _st_OnlineNo;

        /// <summary>終了オンライン番号</summary>
        private Int32 _ed_OnlineNo;

        /// <summary>データ送信区分</summary>
        private Int32[] _dataSendCodes;

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

        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
        /// public propaty name  :  EnterpriseCode
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
        //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<

        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
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

        /// public propaty name  :  St_UOESalesOrderNo
        /// <summary>開始UOE発注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始UOE発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_UOESalesOrderNo
        {
            get { return _st_UOESalesOrderNo; }
            set { _st_UOESalesOrderNo = value; }
        }

        /// public propaty name  :  Ed_UOESalesOrderNo
        /// <summary>終了UOE発注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了UOE発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_UOESalesOrderNo
        {
            get { return _ed_UOESalesOrderNo; }
            set { _ed_UOESalesOrderNo = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>開始入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>終了入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
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

        /// public propaty name  :  St_OnlineNo
        /// <summary>開始オンライン番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始オンライン番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_OnlineNo
        {
            get { return _st_OnlineNo; }
            set { _st_OnlineNo = value; }
        }

        /// public propaty name  :  Ed_OnlineNo
        /// <summary>終了オンライン番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了オンライン番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_OnlineNo
        {
            get { return _ed_OnlineNo; }
            set { _ed_OnlineNo = value; }
        }

        /// public propaty name  :  DataSendCodes
        /// <summary>データ送信区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] DataSendCodes
        {
            get { return _dataSendCodes; }
            set { _dataSendCodes = value; }
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
        /// UOE送信処理抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>UOESendProcCndtnParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESendProcCndtnParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESendProcCndtnPara()
        {
        }

        /// <summary>
        /// UOE送信処理抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="enterpriseCode">拠点コード</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充)</param>
        /// <param name="st_UOESalesOrderNo">開始UOE発注番号</param>
        /// <param name="ed_UOESalesOrderNo">終了UOE発注番号</param>
        /// <param name="st_InputDay">開始入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="ed_InputDay">終了入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="st_OnlineNo">開始オンライン番号</param>
        /// <param name="ed_OnlineNo">終了オンライン番号</param>
        /// <param name="dataSendCodes">データ送信区分</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>UOESendProcCndtnParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESendProcCndtnParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public UOESendProcCndtnPara(string enterpriseCode, Int32 cashRegisterNo, Int32 systemDivCd, Int32 st_UOESalesOrderNo, Int32 ed_UOESalesOrderNo, DateTime st_InputDay, DateTime ed_InputDay, Int32 customerCode, Int32 uOESupplierCd, Int32 st_OnlineNo, Int32 ed_OnlineNo, Int32[] dataSendCodes, string enterpriseName)// DEL YANGMJ 2012/09/20 REDMINE#32404
        public UOESendProcCndtnPara(string enterpriseCode, string sectionCode, Int32 cashRegisterNo, Int32 systemDivCd, Int32 st_UOESalesOrderNo, Int32 ed_UOESalesOrderNo, DateTime st_InputDay, DateTime ed_InputDay, Int32 customerCode, Int32 uOESupplierCd, Int32 st_OnlineNo, Int32 ed_OnlineNo, Int32[] dataSendCodes, string enterpriseName)// ADD YANGMJ 2012/09/20 REDMINE#32404
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;// ADD YANGMJ 2012/09/20 REDMINE#32404
            this._cashRegisterNo = cashRegisterNo;
            this._systemDivCd = systemDivCd;
            this._st_UOESalesOrderNo = st_UOESalesOrderNo;
            this._ed_UOESalesOrderNo = ed_UOESalesOrderNo;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._customerCode = customerCode;
            this._uOESupplierCd = uOESupplierCd;
            this._st_OnlineNo = st_OnlineNo;
            this._ed_OnlineNo = ed_OnlineNo;
            this._dataSendCodes = dataSendCodes;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE送信処理抽出条件クラス複製処理
        /// </summary>
        /// <returns>UOESendProcCndtnParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOESendProcCndtnParaクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESendProcCndtnPara Clone()
        {
            //return new UOESendProcCndtnPara(this._enterpriseCode, this._cashRegisterNo, this._systemDivCd, this._st_UOESalesOrderNo, this._ed_UOESalesOrderNo, this._st_InputDay, this._ed_InputDay, this._customerCode, this._uOESupplierCd, this._st_OnlineNo, this._ed_OnlineNo, this._dataSendCodes, this._enterpriseName);// DEL YANGMJ 2012/09/20 REDMINE#32404
            return new UOESendProcCndtnPara(this._enterpriseCode, this._sectionCode, this._cashRegisterNo, this._systemDivCd, this._st_UOESalesOrderNo, this._ed_UOESalesOrderNo, this._st_InputDay, this._ed_InputDay, this._customerCode, this._uOESupplierCd, this._st_OnlineNo, this._ed_OnlineNo, this._dataSendCodes, this._enterpriseName);// ADD YANGMJ 2012/09/20 REDMINE#32404
        }

        /// <summary>
        /// UOE送信処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOESendProcCndtnParaクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESendProcCndtnParaクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOESendProcCndtnPara target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                && (this.SectionCode == target.SectionCode)// ADD YANGMJ 2012/09/20 REDMINE#32404
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.St_UOESalesOrderNo == target.St_UOESalesOrderNo)
                 && (this.Ed_UOESalesOrderNo == target.Ed_UOESalesOrderNo)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.St_OnlineNo == target.St_OnlineNo)
                 && (this.Ed_OnlineNo == target.Ed_OnlineNo)
                 && (this.DataSendCodes == target.DataSendCodes)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE送信処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="uOESendProcCndtnPara1">
        ///                    比較するUOESendProcCndtnParaクラスのインスタンス
        /// </param>
        /// <param name="uOESendProcCndtnPara2">比較するUOESendProcCndtnParaクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESendProcCndtnParaクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOESendProcCndtnPara uOESendProcCndtnPara1, UOESendProcCndtnPara uOESendProcCndtnPara2)
        {
            return ((uOESendProcCndtnPara1.EnterpriseCode == uOESendProcCndtnPara2.EnterpriseCode)
                && (uOESendProcCndtnPara1.SectionCode == uOESendProcCndtnPara2.SectionCode)// ADD YANGMJ 2012/09/20 REDMINE#32404
                 && (uOESendProcCndtnPara1.CashRegisterNo == uOESendProcCndtnPara2.CashRegisterNo)
                 && (uOESendProcCndtnPara1.SystemDivCd == uOESendProcCndtnPara2.SystemDivCd)
                 && (uOESendProcCndtnPara1.St_UOESalesOrderNo == uOESendProcCndtnPara2.St_UOESalesOrderNo)
                 && (uOESendProcCndtnPara1.Ed_UOESalesOrderNo == uOESendProcCndtnPara2.Ed_UOESalesOrderNo)
                 && (uOESendProcCndtnPara1.St_InputDay == uOESendProcCndtnPara2.St_InputDay)
                 && (uOESendProcCndtnPara1.Ed_InputDay == uOESendProcCndtnPara2.Ed_InputDay)
                 && (uOESendProcCndtnPara1.CustomerCode == uOESendProcCndtnPara2.CustomerCode)
                 && (uOESendProcCndtnPara1.UOESupplierCd == uOESendProcCndtnPara2.UOESupplierCd)
                 && (uOESendProcCndtnPara1.St_OnlineNo == uOESendProcCndtnPara2.St_OnlineNo)
                 && (uOESendProcCndtnPara1.Ed_OnlineNo == uOESendProcCndtnPara2.Ed_OnlineNo)
                 && (uOESendProcCndtnPara1.DataSendCodes == uOESendProcCndtnPara2.DataSendCodes)
                 && (uOESendProcCndtnPara1.EnterpriseName == uOESendProcCndtnPara2.EnterpriseName));
        }
        /// <summary>
        /// UOE送信処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOESendProcCndtnParaクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESendProcCndtnParaクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOESendProcCndtnPara target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");// ADD YANGMJ 2012/09/20 REDMINE#32404
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.St_UOESalesOrderNo != target.St_UOESalesOrderNo) resList.Add("St_UOESalesOrderNo");
            if (this.Ed_UOESalesOrderNo != target.Ed_UOESalesOrderNo) resList.Add("Ed_UOESalesOrderNo");
            if (this.St_InputDay != target.St_InputDay) resList.Add("St_InputDay");
            if (this.Ed_InputDay != target.Ed_InputDay) resList.Add("Ed_InputDay");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.St_OnlineNo != target.St_OnlineNo) resList.Add("St_OnlineNo");
            if (this.Ed_OnlineNo != target.Ed_OnlineNo) resList.Add("Ed_OnlineNo");
            if (this.DataSendCodes != target.DataSendCodes) resList.Add("DataSendCodes");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE送信処理抽出条件クラス比較処理
        /// </summary>
        /// <param name="uOESendProcCndtnPara1">比較するUOESendProcCndtnParaクラスのインスタンス</param>
        /// <param name="uOESendProcCndtnPara2">比較するUOESendProcCndtnParaクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESendProcCndtnParaクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOESendProcCndtnPara uOESendProcCndtnPara1, UOESendProcCndtnPara uOESendProcCndtnPara2)
        {
            ArrayList resList = new ArrayList();
            if (uOESendProcCndtnPara1.EnterpriseCode != uOESendProcCndtnPara2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOESendProcCndtnPara1.SectionCode != uOESendProcCndtnPara2.SectionCode) resList.Add("SectionCode");// ADD YANGMJ 2012/09/20 REDMINE#32404
            if (uOESendProcCndtnPara1.CashRegisterNo != uOESendProcCndtnPara2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (uOESendProcCndtnPara1.SystemDivCd != uOESendProcCndtnPara2.SystemDivCd) resList.Add("SystemDivCd");
            if (uOESendProcCndtnPara1.St_UOESalesOrderNo != uOESendProcCndtnPara2.St_UOESalesOrderNo) resList.Add("St_UOESalesOrderNo");
            if (uOESendProcCndtnPara1.Ed_UOESalesOrderNo != uOESendProcCndtnPara2.Ed_UOESalesOrderNo) resList.Add("Ed_UOESalesOrderNo");
            if (uOESendProcCndtnPara1.St_InputDay != uOESendProcCndtnPara2.St_InputDay) resList.Add("St_InputDay");
            if (uOESendProcCndtnPara1.Ed_InputDay != uOESendProcCndtnPara2.Ed_InputDay) resList.Add("Ed_InputDay");
            if (uOESendProcCndtnPara1.CustomerCode != uOESendProcCndtnPara2.CustomerCode) resList.Add("CustomerCode");
            if (uOESendProcCndtnPara1.UOESupplierCd != uOESendProcCndtnPara2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOESendProcCndtnPara1.St_OnlineNo != uOESendProcCndtnPara2.St_OnlineNo) resList.Add("St_OnlineNo");
            if (uOESendProcCndtnPara1.Ed_OnlineNo != uOESendProcCndtnPara2.Ed_OnlineNo) resList.Add("Ed_OnlineNo");
            if (uOESendProcCndtnPara1.DataSendCodes != uOESendProcCndtnPara2.DataSendCodes) resList.Add("DataSendCodes");
            if (uOESendProcCndtnPara1.EnterpriseName != uOESendProcCndtnPara2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
