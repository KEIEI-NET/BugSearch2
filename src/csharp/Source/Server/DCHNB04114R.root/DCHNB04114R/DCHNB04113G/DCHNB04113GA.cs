using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// SalHisRefDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはISalHisRefDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalHisRefDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 980081 山田 明友</br>
	/// <br>Date       : 2007.10.03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSalHisRefDB
	{
		/// <summary>
        /// SalHisRefDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
		/// </remarks>
		public MediationSalHisRefDB()
		{
		}
		/// <summary>
        /// ISalHisRefDBインターフェース取得
		/// </summary>
        /// <returns>ISalHisRefDBオブジェクト</returns>
        public static ISalHisRefDB GetSalHisRefDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (ISalHisRefDB)Activator.GetObject(typeof(ISalHisRefDB),string.Format("{0}/MyAppSalHisRef",wkStr));
		}
	}
}
