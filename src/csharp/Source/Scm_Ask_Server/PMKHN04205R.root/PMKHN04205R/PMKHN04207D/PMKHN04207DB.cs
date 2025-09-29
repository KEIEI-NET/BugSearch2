//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会 
// プログラム概要   : 他社部品検索履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// SCM問合せログテーブル検索条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM問合せログテーブル検索条件クラス</br>
    /// <br>Programmer       :   朱 猛</br>
    /// <br>Date             :   2010/11/19</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ScmInqLogInquirySearchPara
    {
        /// <summary>開始日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _beginDateTime;

        /// <summary>終了日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _endDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>連結先企業コード</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>抽出最大件数設定</summary>
        private Int32 _maxSearchCt;

        /// <summary>抽出件数超過フラグ</summary>
        private bool _searchOverFlg;

        /// public propaty name  :  BeginDateTime
        /// <summary>開始日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BeginDateTime
        {
            get { return _beginDateTime; }
            set { _beginDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>終了日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  CnectOtherEpCd
        /// <summary>連結先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOtherEpCd
        {
            get { return _cnectOtherEpCd; }
            set { _cnectOtherEpCd = value; }
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
        /// SSCM問合せログテーブル検索条件クラスコンストラクタ
        /// </summary>
        /// <returns>SCM問合せログテーブル検索条件クラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogInquirySearchParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programmer       :   朱 猛</br>
        /// <br>Date             :   2010/11/17</br>
        /// </remarks>
        public ScmInqLogInquirySearchPara()
        {
        }
    }
}
