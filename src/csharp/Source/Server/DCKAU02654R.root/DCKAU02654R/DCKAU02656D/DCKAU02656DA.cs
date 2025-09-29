using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CreditMngListCndtnWork
    /// <summary>
    ///                      与信管理表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   与信管理表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CreditMngListCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（複数指定）</summary>
        /// <remarks>（配列）</remarks>
        private string[] _sectionCodes;

        /// <summary>与信使用率</summary>
        private Double _creditRate;

        /// <summary>与信限度額</summary>
        private Int64 _creditMoney;

        /// <summary>開始担当者</summary>
        private string _st_AgentCd = "";

        /// <summary>終了担当者</summary>
        private string _ed_AgentCd = "";


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

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コード（複数指定）プロパティ</summary>
        /// <value>（配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  CreditRate
        /// <summary>与信使用率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信使用率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CreditRate
        {
            get { return _creditRate; }
            set { _creditRate = value; }
        }

        /// public propaty name  :  CreditMoney
        /// <summary>与信限度額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信限度額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  St_AgentCd
        /// <summary>開始担当者プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_AgentCd
        {
            get { return _st_AgentCd; }
            set { _st_AgentCd = value; }
        }

        /// public propaty name  :  Ed_AgentCd
        /// <summary>終了担当者プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_AgentCd
        {
            get { return _ed_AgentCd; }
            set { _ed_AgentCd = value; }
        }


        /// <summary>
        /// 与信管理表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>CreditMngListCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreditMngListCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CreditMngListCndtnWork()
        {
        }

    }
}
