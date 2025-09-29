using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CustRsltUpdDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはICustRsltUpdDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CustRsltUpdDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.04.20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCustRsltUpdDB
	{
		/// <summary>
        /// CustRsltUpdDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
		public MediationCustRsltUpdDB()
		{
		}
		/// <summary>
        /// ICustRsltUpdDBインターフェース取得
		/// </summary>
        /// <returns>ICustRsltUpdDBオブジェクト</returns>
        public static ICustRsltUpdDB GetCustRsltUpdDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
   			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustRsltUpdDB)Activator.GetObject(typeof(ICustRsltUpdDB), string.Format("{0}/MyAppCustRsltUpd", wkStr));
		}
	}
}
