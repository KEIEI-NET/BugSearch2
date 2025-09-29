//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先マスタ（与信設定）データパラメータ
//                  :   PMKHN09267D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustCreditCndtnWork
    /// <summary>
    ///                      得意先(与信設定)抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先(与信設定)抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustCreditCndtnWork
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


        /// <summary>
        /// 得意先(与信設定)抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustCreditCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustCreditCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustCreditCndtnWork()
        {
        }

    }
}
