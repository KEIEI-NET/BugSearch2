using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ImportantPrtStDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはImportantPrtStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ImportantPrtStDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.03.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationImportantPrtStDB
	{
		/// <summary>
        /// ImportantPrtStDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.03.02</br>
		/// </remarks>
        public MediationImportantPrtStDB()
		{
		}
		/// <summary>
        /// IImportantPrtStDBインターフェース取得
		/// </summary>
        /// <returns>IImportantPrtStDBオブジェクト</returns>
        public static IImportantPrtStDB GetImportantPrtStDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IImportantPrtStDB)Activator.GetObject(typeof(IImportantPrtStDB), string.Format("{0}/MyAppImportantPrtSt", wkStr));
		}
	}
}
