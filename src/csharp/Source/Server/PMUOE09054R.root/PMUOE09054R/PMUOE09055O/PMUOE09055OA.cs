//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : UOE接続先情報マスタメンテナンス
// プログラム概要   : UOE接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : caowj
// 作 成 日  2010/07/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE接続先情報DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE接続先情報DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : caowj</br>
    /// <br>Date       : 2010/07/26</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOEConnectInfoDB
    {
        /// <summary>
        /// UOE接続先情報LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE09056D", "Broadleaf.Application.Remoting.ParamData.UOEConnectInfoWork")]
			out object retobj,
            object paraobj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE接続先情報マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        int Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定されたUOE接続先情報GuidのUOE接続先情報を戻します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたUOE接続先情報GuidのUOE接続先情報を戻します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// UOE接続先情報を登録、更新します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE接続先情報を登録、更新します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int Write(ref byte[] parabyte);

        /// <summary>
        /// UOE接続先情報を物理削除します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE接続先情報を物理削除します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// UOE接続先情報を論理削除します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE接続先情報を論理削除します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int LogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// 論理削除UOE接続先情報を復活します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除UOE接続先情報を復活します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        int RevivalLogicalDelete(ref byte[] parabyte);
    }
}
