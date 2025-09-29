//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 件数と結果コードのペアクラス
    /// </summary>
    public class CountResultPair : Pair<int, int>
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="count">件数</param>
        /// <param name="resultCode">結果コード</param>
        public CountResultPair(int count, int resultCode) : base(count, resultCode) { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 件数を取得します。
        /// </summary>
        /// <value>件数</value>
        public int Count
        {
            get { return First; }
        }

        /// <summary>
        /// 結果コードを取得します。
        /// </summary>
        /// <value>結果コード</value>
        public int ResultCode
        {
            get { return Second; }
        }

        /// <summary>
        /// エラーか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :エラーである。<br/>
        /// <c>false</c>:エラーではない。
        /// </returns>
        public bool IsError()
        {
            return !ResultCode.Equals((int)Result.Code.Normal);
        }
    }
}
