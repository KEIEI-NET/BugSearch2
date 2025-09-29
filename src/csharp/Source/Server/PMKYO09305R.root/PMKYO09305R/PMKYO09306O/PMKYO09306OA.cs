//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動起動サービス処理
// プログラム概要   : 自動起動サービスファイルを保存
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/09/01  修正内容 : #24278 データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2014/10/02  修正内容 : ツールチェックの修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DCコントロールDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBインターフェースです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IServiceFilesDB
    {
        /// <summary>
        /// ファイル読む
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object file, ref string msg, ref int fileFlg);

        // ---- ADD 譚洪 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// ファイル読む
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object userFile,
                 [CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object commFile, ref string msg, ref int fileFlg);
        // ---- ADD 譚洪 2014/10/02 ----------------------------<<<<<

        /// <summary>
        /// ファイル書き
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            object file);


        /// <summary>
        /// ファイル読む
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <param name="dataType">データタイプ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.01</br>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            ref object file, ref string msg, ref int fileFlg, int dataType);

        /// <summary>
        /// ファイル書き
        /// </summary>
        /// <param name="file">ファイル内容</param>
        /// <param name="dataType">データタイプ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.01</br>
        /// [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09307D", "Broadleaf.Application.Remoting.ParamData.ServiceFilesWork")]
            object file, int dataType);
    }
}
