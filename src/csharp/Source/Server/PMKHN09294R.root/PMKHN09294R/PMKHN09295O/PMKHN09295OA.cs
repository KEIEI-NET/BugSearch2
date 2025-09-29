//****************************************************************************//
// システム         : RC.NS
// プログラム名称   : バックアップ処理クラス
// プログラム概要   : バックアップ処理クラスDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2011.06.22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// バックアップ処理クラスDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : バックアップ処理クラスDBインターフェースです。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2011.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBackUpExecutionDB
    {

        /// <summary>
        /// バックアップのフォルダ存在チェック処理
        /// </summary>
        /// <param name="filePath">バックアップ用保存先フォルダ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int FilePathCheck(
            string filePath);

        /// <summary>
        /// バックアップの処理履歴取得用処理
        /// </summary>
        /// <param name="backUpExecutionWorkList">バックアップの処理履歴データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int GetBackUpManual(
            [CustomSerializationMethodParameterAttribute("PMKHN09296D", "Broadleaf.Application.Remoting.ParamData.BackUpExecutionWork")]
            out object backUpExecutionWorkList);

        /// <summary>
        /// バックアップ処理
        /// </summary>
        /// <param name="filePath">バックアップ用保存先フォルダ</param>
        /// <param name="fileName">バックアップ用保存先フォルダ名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int ExecuteBackUp(
            string filePath, 
            string fileName);

    }
}