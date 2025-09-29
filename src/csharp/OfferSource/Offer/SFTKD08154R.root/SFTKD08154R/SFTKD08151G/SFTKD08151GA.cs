using System;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// FPprSchmGrDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIFPprSchmGrDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接FPprSchmGrDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 30015　橋本　裕毅</br>
	/// <br>Date       : 2007.05.14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationFPprSchmGrDB
    {
		/// <summary>
		/// FPprSchmGrDB仲介クラスコンストラクタ
		/// </summary>
        public MediationFPprSchmGrDB()
        {
        }

		/// <summary>
		/// IFPprSchmGrDBインターフェース取得
		/// </summary>
		/// <returns>IFPprSchmGrDBオブジェクト</returns>
		public static IFPprSchmGrDB GetFPprSchmGrDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
			return (IFPprSchmGrDB)Activator.GetObject(typeof(IFPprSchmGrDB),string.Format("{0}/MyAppFPprSchmGr",wkStr));
        }
    }
}
