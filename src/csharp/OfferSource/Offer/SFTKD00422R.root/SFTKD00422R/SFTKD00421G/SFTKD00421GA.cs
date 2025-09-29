using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// リモートオブジェクト仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationOfferAddressInfo
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MediationOfferAddressInfo()
		{
		}
		/// <summary>
		/// リモートオブジェクト取得
		/// </summary>
		/// <returns></returns>
		public static IOfferAddressInfo GetOfferAddressInfo()
		{
			//アプリケーションサーバー接続切り替え対応↓↓↓↓↓
			//提供データアプリケーションサーバーのPathを取得

            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IOfferAddressInfo)Activator.GetObject(typeof(IOfferAddressInfo),string.Format("{0}/OfferAddressInfo",wkStr));
			//アプリケーションサーバー接続切り替え対応↑↑↑↑↑
		}
		
	}
}
