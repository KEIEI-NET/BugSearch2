using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 送受信履歴ログDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送受信履歴ログDB RemoteObject Interfaceです。</br>
    /// <br>Programmer  : lushan</br>
    /// <br>Date        : 2011/07/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)] // アプリケーションの接続先を属性で指定
    public interface ISndRcvHisDB
    {
        /// <summary>
        /// 送受信履歴ログ情報を登録、更新します
        /// </summary>
        /// <param name="paraList">送受信履歴ログブジェクトリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴ログ情報を登録、更新します</br>
        /// <br>Programmer  : lushan</br>
        /// <br>Date        : 2011/07/25</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList);

        /// <summary>
        /// 送受信履歴ログ情報を登録、更新します
        /// </summary>
        /// <param name="sndRcvHisWorkList">pListオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴ログ情報を登録、更新します</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        [MustCustomSerialization]
        int WriteRcvHisWork(
            [CustomSerializationMethodParameterAttribute("PMKYO09407D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisWork")]
            ref ArrayList sndRcvHisWorkList);


        /// <summary>
        /// 送受信履歴ログデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="SndRcvHisCondWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer  : lushan</br>
        /// <br>Date        : 2011/07/25</br>
        [MustCustomSerialization]
        int Search(
            SndRcvHisCondWork SndRcvHisCondWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);


        /// <summary>
        /// 送受信履歴ログ情報を物理削除
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList);

        /// <summary>
        /// 送受信履歴ログ情報を物理削除
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int LogicDelete([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                    ref object paraList);
    }
}
