//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム概要   : ＴＢＯ情報出力 RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00   作成担当 : 黄亜光
// 作 成 日 : 2016/05/20    修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 
    /// ＴＢＯ情報出力DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＴＢＯ情報出力DBインターフェースです.</br>
    /// <br>Programmer : 黄亜光</br>
    /// <br>Date       : 2016/05/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITBODataExportDB
    {
        /// <summary>
        /// ＴＢＯ情報出力情報リストの取得処理
        /// </summary>
        /// <param name="TBOExportResultWork">TBOデータ結果</param>
        /// <param name="TBODataExportCond">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＴＢＯ情報出力情報リスト(TBOデータ)を取得します。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchTBOData(
            [CustomSerializationMethodParameterAttribute("PMKHN09518D", "Broadleaf.Application.Remoting.ParamData.TBODataExportResultWork")]
            out object TBOExportResultWork,
            object TBODataExportCond,
            out string errMessage);
    }
}
