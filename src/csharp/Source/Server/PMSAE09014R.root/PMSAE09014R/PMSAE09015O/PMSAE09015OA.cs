//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス設定マスタメンテナンス
// プログラム概要   : オートバックス設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/08/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// オートバックス設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : オートバックス設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISAndESettingDB
    {
        /// <summary>
        /// オートバックス設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SAndESettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オートバックス設定マスタのキー値が一致するオートバックス設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object parabyte);

        /// <summary>
        /// オートバックス設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSAndESettingList">検索結果</param>
        /// <param name="paraSAndESettingWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 企業コードマスタのキー値が一致する、全てのオートバックス設定マスタ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            out object outSAndESettingList, object paraSAndESettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// オートバックス設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="sAndESettingWorkbyte">追加・更新するオートバックス設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">更新区分</param>
        /// <br>Note       : SAndESettingWork に格納されているオートバックス設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object sAndESettingWorkbyte, int writeMode);

        /// <summary>
        /// オートバックス設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="sAndESettingWork">論理削除するオートバックス設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndESettingWork に格納されているオートバックス設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object sAndESettingWork);

        /// <summary>
        /// オートバックス設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="sAndESettingWork">論理削除を解除するオートバックス設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndESettingWork に格納されているオートバックス設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object sAndESettingWork);
    }
}
