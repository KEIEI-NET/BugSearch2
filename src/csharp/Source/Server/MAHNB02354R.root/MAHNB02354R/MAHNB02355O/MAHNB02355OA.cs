using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 売上確認表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上確認表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 20098　村瀬　勝也</br>
	/// <br>Date       : 2007.03.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ISalesConfDB
	{

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 売上確認表LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="salesConfWork">検索結果</param>
		/// <param name="parasalesConfWork">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20098　村瀬　勝也</br>
		/// <br>Date       : 2007.03.19</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAHNB02356D","Broadleaf.Application.Remoting.ParamData.SalesConfWork")]
			out object salesConfWork,
			object parasalesConfWork);

        /// <summary>
        /// 売上確認表(合計)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="salesConfWork">検索結果</param>
        /// <param name="paraSalesConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        [MustCustomSerialization]
        int SearchSlip(
            [CustomSerializationMethodParameterAttribute("MAHNB02356D", "Broadleaf.Application.Remoting.ParamData.SalesConfWork")]
			out object salesConfWork,
            object paraSalesConfWork);

        /// <summary>
        /// 売上確認表(明細・詳細)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="salesConfWork">検索結果</param>
        /// <param name="paraSalesConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        [MustCustomSerialization]
        int SearchDetail(
            [CustomSerializationMethodParameterAttribute("MAHNB02356D", "Broadleaf.Application.Remoting.ParamData.SalesConfWork")]
			out object salesConfWork,
            object paraSalesConfWork);
        #endregion
	}
}
