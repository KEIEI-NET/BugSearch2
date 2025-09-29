using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// ClaimSalesReadDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIClaimSalesReadDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接ClaimSalesReadDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 18322 T.Kimura</br>
	/// <br>Date       : 2007.01.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationClaimSalesReadDB
	{
		/// <summary>
		/// SalesSlipReadDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		public MediationClaimSalesReadDB()
		{
		}
		/// <summary>
		/// SalesSlipReadDBインターフェース取得
		/// </summary>
		/// <returns>SalesSlipReadDBオブジェクト</returns>
		public static IClaimSalesReadDB GetClaimSalesReadDB()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9011";
#endif

            return (IClaimSalesReadDB)Activator.GetObject(typeof(IClaimSalesReadDB),string.Format("{0}/MyAppClaimSalesRead",wkStr));
        }
	}
}
