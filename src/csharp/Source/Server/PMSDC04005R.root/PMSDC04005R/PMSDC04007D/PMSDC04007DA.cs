//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データ送信ログ一覧抽出条件パラメータ
// プログラム概要   : 売上データ送信ログ一覧抽出条件パラメータデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2019/12/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalCprtSndLogListCndtnWork
    /// <summary>
    /// 売上データ送信ログ一覧抽出条件パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データ送信ログ一覧抽出条件パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2019/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalCprtSndLogListCndtnWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>拠点コード</remarks>
        private string[] _sectionCodes;

        /// <summary>送信日時（開始）</summary>
        /// <remarks>送信日時（開始）</remarks>
        private Int64 _sendDateTimeStart;

        /// <summary>送信日時（終了）</summary>
        /// <remarks>送信日時（終了）</remarks>
        private Int64 _sendDateTimeEnd;

        /// <summary>自動送信区分</summary>
        /// <remarks>0:手動,1:自動</remarks>
        private Int32 _sAndEAutoSendDiv;

        /// <summary>抽出最大件数設定</summary>
        /// <remarks>抽出最大件数設定</remarks>
        private Int32 _maxSearchCt;

        /// <summary>抽出件数超過フラグ</summary>
        /// <remarks>抽出件数超過フラグ</remarks>
        private bool _searchOverFlg;

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
        /// <summary>拠点コード</summary>
        /// <value>拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  SendDateTimeStart
        /// <summary>送信日時（開始）</summary>
        /// <value>送信日時（開始）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信日時（開始）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendDateTimeStart
        {
            get { return _sendDateTimeStart; }
            set { _sendDateTimeStart = value; }
        }

        /// public propaty name  :  SendDateTimeEnd
        /// <summary>送信日時（終了）</summary>
        /// <value>送信日時（終了）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信日時（終了）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SendDateTimeEnd
        {
            get { return _sendDateTimeEnd; }
            set { _sendDateTimeEnd = value; }
        }

        /// public propaty name  :  SAndEAutoSendDiv
        /// <summary>自動送信区分</summary>
        /// <value>0:手動,1:自動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動送信区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SAndEAutoSendDiv
        {
            get { return _sAndEAutoSendDiv; }
            set { _sAndEAutoSendDiv = value; }
        }

        /// public propaty name  :  MaxSearchCt
        /// <summary>抽出最大件数設定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出最大件数設定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MaxSearchCt
        {
            get { return _maxSearchCt; }
            set { _maxSearchCt = value; }
        }

        /// public propaty name  :  SearchOverFlg
        /// <summary>抽出件数超過フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出件数超過フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool SearchOverFlg
        {
            get { return _searchOverFlg; }
            set { _searchOverFlg = value; }
        }

        /// <summary>
        /// 売上データ送信ログ一覧抽出条件パラメータワークコンストラクタ
        /// </summary>
        /// <returns>SalCprtSndLogListCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalCprtSndLogListCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalCprtSndLogListCndtnWork()
        {
        }
    }
}
