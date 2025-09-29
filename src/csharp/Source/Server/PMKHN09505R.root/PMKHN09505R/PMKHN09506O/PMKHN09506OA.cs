//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品不可設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///返品不可設定用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品不可設定用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsNotReturnProcDB
    {
        /// <summary>
        /// 返品不可設定データ初期検索
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="salesSlipNum">検索パラメータ</param>
        /// <param name="goodsNotReturnList">検索結果</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品不可設定データ初期検索する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.20</br>
        [MustCustomSerialization]
        int ReadDBData(
            string enterpriseCodes,
            string salesSlipNum,
            [CustomSerializationMethodParameterAttribute("PMKHN09507D", "Broadleaf.Application.Remoting.ParamData.GoodsNotReturnWork")]
            out ArrayList goodsNotReturnList,
            out string retMessage);

        /// <summary>
        /// 返品不可設定データ更新
        /// </summary>
        /// <param name="goodsNotReturnList">更新データ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品不可設定データ更新する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.20</br>
        [MustCustomSerialization]
        int UpdateReturnUpper(
            [CustomSerializationMethodParameterAttribute("PMKHN09507D", "Broadleaf.Application.Remoting.ParamData.GoodsNotReturnWork")]
            ref ArrayList goodsNotReturnList,
            out string retMessage);
    }
}
