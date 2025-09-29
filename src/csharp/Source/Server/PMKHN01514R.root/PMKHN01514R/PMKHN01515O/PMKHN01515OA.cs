//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良データ削除処理
// プログラム概要   : 優良データ削除処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 梁森東
// 作 成 日  2011/07/15  修正内容 : 連番No.2 新規作成                      
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

using System.Data.SqlClient;    // ADD 2009/12/24

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良データ更新DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note        : 優良データ更新DBインターフェースです。</br>
    /// <br>Programmer	: 梁森東</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br></br>
    /// <br>Update Note : 2011/07/21 caohh</br>
    /// <br>            : 優良データ削除チェックリスト対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IYuuRyouDataDelDB
    {
        /// <summary>
        /// 指定された条件に優良データを物理削除。
        /// </summary>
        /// <param name="deleteConditionWork">deleteConditionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に優良データを物理削除します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        int Delete([CustomSerializationMethodParameterAttribute("PMKHN01516D", "Broadleaf.Application.Remoting.ParamData.DeleteConditionWork")]
            ref object deleteConditionWork);

        // ---- ADD caohh 2011/07/21 ---->>>>
        /// <summary>
        /// 指定された条件に優良データを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="deleteResultWork">検索結果</param>
        /// <param name="deleteConditionObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に優良データを全て戻します（論理削除除く）</br>
	    /// <br>Programmer : caohh</br>
	    /// <br>Date       : 2011.07.21</br>
        [MustCustomSerialization]
		    int Search(
                [CustomSerializationMethodParameterAttribute("PMKHN01516D", "Broadleaf.Application.Remoting.ParamData.DeleteResultWork")]
      			out object deleteResultWork,
                object deleteConditionObj,
      			int readMode,
                ConstantManagement.LogicalMode logicalMode);
       // ---- ADD caohh 2011/07/21 ----<<<< 
    }
}
