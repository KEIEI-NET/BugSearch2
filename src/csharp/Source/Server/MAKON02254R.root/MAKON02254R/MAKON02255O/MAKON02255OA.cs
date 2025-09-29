using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 仕入確認表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入確認表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 20098　村瀬　勝也</br>
	/// <br>Date       : 2007.03.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockConfDB
	{
        /// <summary>
		/// 仕入確認表(明細)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="stockConfWork">検索結果</param>
		/// <param name="parastockConfWork">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20098　村瀬　勝也</br>
		/// <br>Date       : 2007.03.19</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAKON02256D","Broadleaf.Application.Remoting.ParamData.StockConfWork")]
			out object stockConfWork,
			object parastockConfWork);

        /// <summary>
        /// 仕入確認表(伝票)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockConfSlipTtlWork">検索結果</param>
        /// <param name="parastockConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.12.19</br>
        [MustCustomSerialization]
        int SearchSlipTtl(
            [CustomSerializationMethodParameterAttribute("MAKON02256D","Broadleaf.Application.Remoting.ParamData.StockConfSlipTtlWork")]
			out object stockConfSlipTtlWork,
            object parastockConfWork);
	}
}
