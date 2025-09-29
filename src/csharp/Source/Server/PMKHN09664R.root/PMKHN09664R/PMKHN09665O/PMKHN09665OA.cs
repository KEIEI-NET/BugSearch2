//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リモート伝発設定マスタメンテ
// プログラム概要   : リモート伝発設定マスタメンテDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 欧方方
// 作 成 日  2011.08.03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// リモート伝発設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : リモート伝発設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 欧方方</br>
    /// <br>Date       : 2011.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IRmSlpPrtStDB
    {

        /// <summary>
        /// 指定されたリモート伝発設定マスタGuidのリモート伝発設定マスタを戻します
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたリモート伝発設定マスタGuidのリモート伝発設定マスタを戻します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        int Read(ref RmSlpPrtStWork rmSlpPrtStWork, int readMode);

        /// <summary>
        /// リモート伝発設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">RmSlpPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// リモート伝発設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="rmslpprtstWork">検索結果</param>
        /// <param name="pararmslpprtstWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			out object rmslpprtstWork,
           RmSlpPrtStWork pararmslpprtstWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// リモート伝発設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="rmslpprtstWork">RmSlpPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			ref object rmslpprtstWork
            );

        /// <summary>
        /// リモート伝発設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="rmslpprtstWork">RmSlpPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			ref object rmslpprtstWork
            );

        /// <summary>
        /// 論理削除リモート伝発設定マスタ情報を復活します
        /// </summary>
        /// <param name="rmslpprtstWork">RmSlpPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除リモート伝発設定マスタ情報を復活します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			ref object rmslpprtstWork
            );
        #endregion
    }
}
