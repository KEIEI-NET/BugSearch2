//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理例外
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

namespace Broadleaf.Application.UIData.Exception
{
    /// <summary>
    /// 卸商仕入受信処理例外クラス
    /// </summary>
    public class OroshishoStockReceptionException : ApplicationException
    {
        #region <処理結果/>

        /// <summary>処理結果</summary>
        private readonly int _status;
        /// <summary>
        /// 処理結果を取得します。
        /// </summary>
        /// <value>処理結果</value>
        public int Status { get { return _status; } }

        #endregion  // <処理結果/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">処理結果</param>
        public OroshishoStockReceptionException(
            string message, 
            int status
        ) : base(message)
        {
            _status = status;
        }

        #endregion  // <Constructor/>
    }
}
