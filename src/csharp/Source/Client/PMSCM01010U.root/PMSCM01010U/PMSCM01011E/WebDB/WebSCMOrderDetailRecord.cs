//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdDtInq;

    /// <summary>
    /// Web-DB SCM受注明細データ(問合せ・発注)のレコードクラス
    /// </summary>
    public class WebSCMOrderDetailRecord : WebSCMOrderDetailWrapper
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public WebSCMOrderDetailRecord() : base() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord"></param>
        public WebSCMOrderDetailRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constractor>
    }
}
