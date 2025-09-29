using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 見積初期値設定マスタ(ユーザ)DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 見積初期値設定マスタ(ユーザ)DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.09.26</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IEstimateDefSetDB
    {
        /// <summary>
        /// 指定された見積初期値設定マスタ(ユーザ)を戻します
        /// </summary>
        /// <param name="parabyte">EstimateDefSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された見積初期値設定マスタ(ユーザ)戻りデータGuidの見積初期値設定マスタ(ユーザ)を戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 見積初期値設定マスタ(ユーザ)を物理削除します
        /// </summary>
        /// <param name="parabyte">EstimateDefSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ(ユーザ)を物理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 見積初期値設定情報を登録、更新します
        /// </summary>
        /// <param name="paraList">EstimateDefSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定情報を登録、更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        int Write(
            [CustomSerializationMethodParameterAttribute("DCMIT09016D", "Broadleaf.Application.Remoting.ParamData.EstimateDefSetWork")]
            ref object paraList
            );

        /// <summary>
        /// 見積初期値設定マスタ(ユーザ)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCMIT09016D", "Broadleaf.Application.Remoting.ParamData.EstimateDefSetWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 見積初期値設定マスタ(ユーザ)を論理削除します
        /// </summary>
        /// <param name="paraObj">EstimateDefSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ(ユーザ)を論理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCMIT09016D", "Broadleaf.Application.Remoting.ParamData.EstimateDefSetWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除見積初期値設定マスタ(ユーザ)を復活します
        /// </summary>
        /// <param name="paraObj">EstimateDefSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除見積初期値設定マスタ(ユーザ)を復活します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCMIT09016D", "Broadleaf.Application.Remoting.ParamData.EstimateDefSetWork")]
			ref object paraObj
            );
    }
}
