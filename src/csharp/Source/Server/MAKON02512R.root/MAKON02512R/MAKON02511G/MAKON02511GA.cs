using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// 支払情報取得 DB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはISuplierPayInfGetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接SuplierPayInfGetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.05.11</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSuplierPayInfGetDB
	{
		/// <summary>
		/// SuplierPayInfGetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.05.11</br>
		/// </remarks>
		public MediationSuplierPayInfGetDB()
		{
		}
		/// <summary>
		/// SuplierPayInfGetDBインターフェース取得
		/// </summary>
		/// <returns>SuplierPayInfGetDBオブジェクト</returns>
		public static ISuplierPayInfGetDB GetSuplierPayInfGetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            return (ISuplierPayInfGetDB)Activator.GetObject(typeof(ISuplierPayInfGetDB), string.Format("{0}/MyAppSuplierPayInfGet", wkStr));
		}
	}
}
