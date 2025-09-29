//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
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
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DCコントロールDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Summary_AP)]
    public interface IMstTotalMachControlDB
    {
        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="BeginningDate">検索結果</param>
        /// <param name="EndingDate">検索条件</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            ArrayList masterDivList,
            string pmEnterpriseCodes,
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            out string retMessage);

        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        [MustCustomSerialization]
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage);
    }
}
