using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 受注出荷確認表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 受注出荷確認表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 980081　山田 明友</br>
	/// <br>Date       : 2007.10.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IOrderConfDB
	{

		#region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 受注出荷確認表(合計)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="orderConfWork">検索結果</param>
        /// <param name="paraOrderConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.19</br>
        [MustCustomSerialization]
        int SearchSlip(
            [CustomSerializationMethodParameterAttribute("DCHNB02026D", "Broadleaf.Application.Remoting.ParamData.OrderConfWork")]
			out object orderConfWork,
            object paraOrderConfWork);

        /// <summary>
        /// 受注出荷確認表(明細・詳細)LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="orderConfWork">検索結果</param>
        /// <param name="paraOrderConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.19</br>
        [MustCustomSerialization]
        int SearchDetail(
            [CustomSerializationMethodParameterAttribute("DCHNB02026D", "Broadleaf.Application.Remoting.ParamData.OrderConfWork")]
			out object orderConfWork,
            object paraOrderConfWork);
        #endregion
	}
}
