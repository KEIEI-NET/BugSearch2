using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// PrtItemSetDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: このクラスはIPrtItemSetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			  完全スタンドアロンにする場合にはこのクラスで直接PrtItemSetDBを</br>
	/// <br>			  インスタンス化して戻します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.05.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPrtItemSetDB
	{
		/// <summary>
		/// PrtItemSetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22024 寺坂　誉志</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
		public MediationPrtItemSetDB()
		{
		}

		/// <summary>
		/// IPrtItemSetDBインターフェース取得
		/// </summary>
		/// <returns>IPrtItemSetDBオブジェクト</returns>
		/// <remarks>
		/// <br>Note       : リモートオブジェクト取得用のプロキシを作成します。</br>
		/// <br>Programmer : 22024 寺坂　誉志</br>
		/// <br>Date       : 2007.05.07</br>
		/// </remarks>
		public static IPrtItemSetDB GetPrtItemSetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
			return (IPrtItemSetDB)Activator.GetObject(typeof(IPrtItemSetDB), string.Format("{0}/MyAppPrtItemSet", wkStr));
		}
	}
}
