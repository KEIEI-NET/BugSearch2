//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信制御条件クラス
// プログラム概要   : ＵＯＥ送信制御条件の定義
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UoeSndRcvCtlPara
    /// <summary>
    ///                      ＵＯＥ送信制御条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＵＯＥ送信制御条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UoeSndRcvCtlPara
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>業務区分</summary>
        /// <remarks>1:発注 2:見積 3:在庫確認</remarks>
        private Int32 _businessCode;

        /// <summary>システム区分</summary>
        /// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
        private Int32 _systemDivCd;

        /// <summary>処理区分</summary>
        /// <remarks>0:通常 1:復旧</remarks>
        private Int32 _processDiv;

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

        /// public propaty name  :  ProcessDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>0:通常 1:復旧</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcessDiv
        {
            get { return _processDiv; }
            set { _processDiv = value; }
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
        /// ＵＯＥ送信制御条件クラスコンストラクタ
        /// </summary>
        /// <returns>UoeSndRcvCtlParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UoeSndRcvCtlParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UoeSndRcvCtlPara()
        {
        }

        /// <summary>
        /// ＵＯＥ送信制御条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="businessCode">業務区分(1:発注 2:見積 3:在庫確認)</param>
        /// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充)</param>
        /// <param name="processDiv">処理区分(0:通常 1:復旧)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="businessName">業務区分名称</param>
        /// <returns>UoeSndRcvCtlParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UoeSndRcvCtlParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UoeSndRcvCtlPara(string enterpriseCode, Int32 businessCode, Int32 systemDivCd, Int32 processDiv, string enterpriseName, string businessName)
        {
            this._enterpriseCode = enterpriseCode;
            this._businessCode = businessCode;
            this._systemDivCd = systemDivCd;
            this._processDiv = processDiv;
            this._enterpriseName = enterpriseName;
            this._businessName = businessName;

        }

        /// <summary>
        /// ＵＯＥ送信制御条件クラス複製処理
        /// </summary>
        /// <returns>UoeSndRcvCtlParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUoeSndRcvCtlParaクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UoeSndRcvCtlPara Clone()
        {
            return new UoeSndRcvCtlPara(this._enterpriseCode, this._businessCode, this._systemDivCd, this._processDiv, this._enterpriseName, this._businessName);
        }

        /// <summary>
        /// ＵＯＥ送信制御条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUoeSndRcvCtlParaクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UoeSndRcvCtlParaクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UoeSndRcvCtlPara target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.ProcessDiv == target.ProcessDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.BusinessName == target.BusinessName));
        }

        /// <summary>
        /// ＵＯＥ送信制御条件クラス比較処理
        /// </summary>
        /// <param name="uoeSndRcvCtlPara1">
        ///                    比較するUoeSndRcvCtlParaクラスのインスタンス
        /// </param>
        /// <param name="uoeSndRcvCtlPara2">比較するUoeSndRcvCtlParaクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UoeSndRcvCtlParaクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UoeSndRcvCtlPara uoeSndRcvCtlPara1, UoeSndRcvCtlPara uoeSndRcvCtlPara2)
        {
            return ((uoeSndRcvCtlPara1.EnterpriseCode == uoeSndRcvCtlPara2.EnterpriseCode)
                 && (uoeSndRcvCtlPara1.BusinessCode == uoeSndRcvCtlPara2.BusinessCode)
                 && (uoeSndRcvCtlPara1.SystemDivCd == uoeSndRcvCtlPara2.SystemDivCd)
                 && (uoeSndRcvCtlPara1.ProcessDiv == uoeSndRcvCtlPara2.ProcessDiv)
                 && (uoeSndRcvCtlPara1.EnterpriseName == uoeSndRcvCtlPara2.EnterpriseName)
                 && (uoeSndRcvCtlPara1.BusinessName == uoeSndRcvCtlPara2.BusinessName));
        }
        /// <summary>
        /// ＵＯＥ送信制御条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUoeSndRcvCtlParaクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UoeSndRcvCtlParaクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UoeSndRcvCtlPara target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.ProcessDiv != target.ProcessDiv) resList.Add("ProcessDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");

            return resList;
        }

        /// <summary>
        /// ＵＯＥ送信制御条件クラス比較処理
        /// </summary>
        /// <param name="uoeSndRcvCtlPara1">比較するUoeSndRcvCtlParaクラスのインスタンス</param>
        /// <param name="uoeSndRcvCtlPara2">比較するUoeSndRcvCtlParaクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UoeSndRcvCtlParaクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UoeSndRcvCtlPara uoeSndRcvCtlPara1, UoeSndRcvCtlPara uoeSndRcvCtlPara2)
        {
            ArrayList resList = new ArrayList();
            if (uoeSndRcvCtlPara1.EnterpriseCode != uoeSndRcvCtlPara2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uoeSndRcvCtlPara1.BusinessCode != uoeSndRcvCtlPara2.BusinessCode) resList.Add("BusinessCode");
            if (uoeSndRcvCtlPara1.SystemDivCd != uoeSndRcvCtlPara2.SystemDivCd) resList.Add("SystemDivCd");
            if (uoeSndRcvCtlPara1.ProcessDiv != uoeSndRcvCtlPara2.ProcessDiv) resList.Add("ProcessDiv");
            if (uoeSndRcvCtlPara1.EnterpriseName != uoeSndRcvCtlPara2.EnterpriseName) resList.Add("EnterpriseName");
            if (uoeSndRcvCtlPara1.BusinessName != uoeSndRcvCtlPara2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }
}
