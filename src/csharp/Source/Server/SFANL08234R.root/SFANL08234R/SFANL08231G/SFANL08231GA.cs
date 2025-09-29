using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// 自由帳票印字位置設定 DB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはIUpdateCustAccDmdRecクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接UpdateCustAccDmdRecを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22011　柏原　頼人</br>
	/// <br>Date       : 2007.05.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFrePrtPSetDLDB
	{
		/// <summary>
		/// UpdateCustAccDmdRec DB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22011　柏原　頼人</br>
		/// <br>Date       : 2007.09.30</br>
		/// </remarks>
		public MediationFrePrtPSetDLDB()
		{
		}
		/// <summary>
		/// IPrtmanageDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
		public static IFrePrtPSetDLDB GetFrePrtPSetDLDB()
		{
//            string wkStr = "HTTP://localhost:8008";

			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

# if DEBUG
            wkStr = "http://localhost:9001";
# endif 

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (IFrePrtPSetDLDB)Activator.GetObject(typeof(IFrePrtPSetDLDB),string.Format("{0}/MyAppFrePrtPSetDL",wkStr));
		}
	}
}
