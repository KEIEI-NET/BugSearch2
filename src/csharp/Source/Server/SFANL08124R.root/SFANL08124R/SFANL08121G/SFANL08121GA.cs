using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// FrePrtPSetDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: このクラスはIFrePrtPSetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			  完全スタンドアロンにする場合にはこのクラスで直接FrePrtPSetDBを</br>
	/// <br>			  インスタンス化して戻します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFrePrtPSetDB
	{
		/// <summary>
		/// FrePrtPSetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22024 寺坂　誉志</br>
		/// <br>Date       : 2007.05.10</br>
		/// </remarks>
		public MediationFrePrtPSetDB()
		{
		}

		/// <summary>
		/// IFrePrtPSetDBインターフェース取得
		/// </summary>
		/// <returns>IFrePrtPSetDBオブジェクト</returns>
		/// <remarks>
		/// <br>Note       : リモートオブジェクト取得用のプロキシを作成します。</br>
		/// <br>Programmer : 22024 寺坂　誉志</br>
		/// <br>Date       : 2007.05.10</br>
		/// </remarks>
		public static IFrePrtPSetDB GetFrePrtPSetDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            # if DEBUG
            wkStr = "http://localhost:9001";
            # endif

			return (IFrePrtPSetDB)Activator.GetObject(typeof(IFrePrtPSetDB), string.Format("{0}/MyAppFrePrtPSet", wkStr));
		}
	}
}
