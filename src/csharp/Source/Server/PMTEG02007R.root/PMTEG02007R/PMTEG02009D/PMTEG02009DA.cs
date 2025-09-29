//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形確認表抽出条件クラスワーク
// プログラム概要   : 手形確認表抽出条件クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/05/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TegataConfirmReportParaWork
    /// <summary>
    ///                      手形確認表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   手形確認表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2010/04/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TegataConfirmReportParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>手形区分</summary>
        /// <remarks>0:受取手形 1:支払手形</remarks>
        private Int32 _draftDivide;

        /// <summary>開始入金日</summary>
        private DateTime _depositDateSt;

        /// <summary>終了入金日</summary>
        private DateTime _depositDateEd;

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

        /// public propaty name  :  DraftDivide
        /// <summary>手形区分プロパティ</summary>
        /// <value>0:受取手形 1:支払手形</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  DepositDateSt
        /// <summary>開始入金日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DepositDateSt
        {
            get { return _depositDateSt; }
            set { _depositDateSt = value; }
        }

        /// public propaty name  :  DepositDateEd
        /// <summary>終了入金日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DepositDateEd
        {
            get { return _depositDateEd; }
            set { _depositDateEd = value; }
        }

        /// <summary>
        /// 手形確認表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>TegataConfirmReportParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TegataConfirmReportParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TegataConfirmReportParaWork()
        {
        }
    }
}
