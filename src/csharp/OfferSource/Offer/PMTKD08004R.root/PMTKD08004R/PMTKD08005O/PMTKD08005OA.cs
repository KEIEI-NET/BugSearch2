using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票(売上伝票)提供DBRemoteObjectインターフェース	
	/// </summary>
	/// <remarks>
	/// <br>Note         : 自由帳票(売上伝票)提供 RemoteObject Interfaceです。</br>
	/// <br>Programmer   : 22018 鈴木 正臣</br>
	/// <br>Date         : 2008.06.06</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IFrePSalesSlipOfferDB
	{
		/// <summary>
		/// 自由帳票項目設定マスタ取得処理
		/// </summary>
        /// <param name="frePSalesSlipOfferWork">提供検索ワークリスト</param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
		/// <returns>ステータス</returns>
		/// <br>Note         : 指定された提供データ配列を取得します。</br>
		/// <br>Programmer   : 22018 鈴木 正臣</br>
		/// <br>Date         : 2008.06.06</br>
        [MustCustomSerialization]
        int SearchFrePSalesSlipOffer(
            ref object frePSalesSlipOfferWork,
            out bool msgDiv,
            out string errMsg
            );
	}
}
