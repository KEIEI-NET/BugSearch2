using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// FreePprGrpDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIFreePprGrpDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			 完全スタンドアロンにする場合にはこのクラスで直接FreePprGrpDBを</br>
	/// <br>		 	 インスタンス化して戻します。</br>
	/// <br>Programmer : 22011　柏原　頼人</br>
	/// <br>Date       : 2007.05.22</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFreePprGrpDB
	{
		/// <summary>
		/// FreePprGrpDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22011　柏原　頼人</br>
		/// <br>Date       : 2007.05.22</br>
		/// </remarks>
		public MediationFreePprGrpDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IFreePprGrpDB GetFreePprGrpDB()
		{
//            string wkStr = "HTTP://localhost:8008";
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            return (IFreePprGrpDB)Activator.GetObject(typeof(IFreePprGrpDB),string.Format("{0}/MyAppFreePprGrp",wkStr));
        }
	}
}
