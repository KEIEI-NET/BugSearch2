using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// 買掛情報取得 DB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはISuplAccInfGetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接SuplAccInfGetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.05.14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSuplAccInfGetDB
	{
		/// <summary>
		/// SuplAccInfGetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.14</br>
		/// </remarks>
		public MediationSuplAccInfGetDB()
		{
		}
		/// <summary>6
		/// SuplAccInfGetDBインターフェース取得
		/// </summary>
		/// <returns>SuplAccInfGetDBオブジェクト</returns>
		public static ISuplAccInfGetDB GetSuplAccInfGetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
			return (ISuplAccInfGetDB)Activator.GetObject(typeof(ISuplAccInfGetDB), string.Format("{0}/MyAppSuplAccInfGet", wkStr));
		}
	}
}
