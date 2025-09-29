//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力（ＴＭＹ）
// プログラム概要   : 売上データテキスト出力（ＴＭＹ）　DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン
// 作 成 日  2011/10/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 売上データテキストDBインターフェース</summary>
    /// <remarks>
    /// <br>Note       : 売上データテキスト出力（ＴＭＹ）DBインターフェースです。</br>
    /// <br>Programmer : 鄧潘ハン</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>管理番号   : 10805731-00</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesSliptextResultDB
    {
        /// <summary>
        ///  売上データテキスト出力（ＴＭＹ）情報リストの取得処理。
        /// </summary>
        /// <param name="salesSliptextResultWork">検索結果</param>
        /// <param name="salesSliptextcndtnWork">検索条件</param>
        /// <param name="retMsg"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）情報リストの取得処理。</br>
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>  
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN07707D", "Broadleaf.Application.Remoting.ParamData.SalesSliptextResultWork")]
            out object salesSliptextResultWork,
            object salesSliptextcndtnWork,
            out string retMsg);

    }
}
