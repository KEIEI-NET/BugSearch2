//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買い得商品グループ設定マスタ
// プログラム概要   : お買い得商品グループ設定マスタDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 亘
// 作 成 日  2015/02/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// お買い得商品グループ設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買い得商品グループ設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2015/02/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    //[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRecBgnGrpDB
    {

        /// <summary>
        /// 検索処理（お買得商品グループマスタ全件検索）
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork検索結果データリスト</param>
        /// <param name="cnectOtherEpCd">PM自社企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:有効,1:論理削除,2:保留,3:完全削除)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09037D", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork")]
            out object retobj,
            string cnectOtherEpCd,
            ConstantManagement.LogicalMode logicalMode,
            out int count, 
            ref string errMsg);

        /// <summary>
        /// 検索処理（お買得商品グループマスタ検索）
        /// </summary>
        /// <param name="retobj">RecBgnGrpWork検索結果データリスト</param>
        /// <param name="paraobj">RecBgnGrpSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:有効,1:論理削除,2:保留,3:完全削除)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09037D", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork")]
            out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errMsg);

    }
}