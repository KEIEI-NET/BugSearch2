using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// AlItmDspNmDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIAlItmDspNmDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接AlItmDspNmDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 90027　高口　勝</br>
	/// <br>Date       : 2006.08.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationAlItmDspNmDB
	{
		/// <summary>
		/// AlItmDspNmDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public MediationAlItmDspNmDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IAlItmDspNmDB GetAlItmDspNmDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			return (IAlItmDspNmDB)Activator.GetObject(typeof(IAlItmDspNmDB),string.Format("{0}/MyAppAlItmDspNm",wkStr));
		}
	}
}
