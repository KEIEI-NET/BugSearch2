using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 検品全体設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品全体設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 3H 楊善娟</br>
    /// <br>Date       : K2017/06/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IInspectTtlStDB
    {
        /// <summary>
        /// 指定された検品全体設定マスタGuidの検品全体設定マスタを戻します
        /// </summary>
		/// <param name="parabyte">InspectTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された検品全体設定マスタGuidの検品全体設定マスタを戻します</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 検品全体設定マスタ情報を物理削除します
        /// </summary>
		/// <param name="parabyte">InspectTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検品全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 検品全体設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
		/// <param name="inspectTtlStWork">検索結果</param>
		/// <param name="parainspectTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int Search(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			out object inspectTtlStWork,
			object parainspectTtlStWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 検品全体設定マスタ情報を登録、更新します
        /// </summary>
		/// <param name="inspectTtlStWork">InspectTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検品全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			ref object inspectTtlStWork
            );

        /// <summary>
        /// 検品全体設定マスタ情報を論理削除します
        /// </summary>
		/// <param name="inspectTtlStWork">InspectTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検品全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			ref object inspectTtlStWork
            );

        /// <summary>
        /// 論理削除検品全体設定マスタ情報を復活します
        /// </summary>
		/// <param name="inspectTtlStWork">InspectTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除検品全体設定マスタ情報を復活します</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			ref object inspectTtlStWork
            );
        #endregion
    }
}
