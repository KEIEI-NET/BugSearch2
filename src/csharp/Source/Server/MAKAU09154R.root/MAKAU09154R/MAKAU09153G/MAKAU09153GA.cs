using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// MediationDmdPrtPtnDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIDmdPrtPtnDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接DmdPrtPtnDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.07.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDmdPrtPtnDB
	{
		/// <summary>
        /// DmdPrtPtnDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.07.02</br>
		/// </remarks>
        public MediationDmdPrtPtnDB()
		{
		}
		/// <summary>
        /// IDmdPrtPtnDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
        public static IDmdPrtPtnDB GetDmdPrtPtnDB()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            return (IDmdPrtPtnDB)Activator.GetObject(typeof(IDmdPrtPtnDB), string.Format("{0}/MyAppDmdPrtPtn", wkStr));
        }
	}
}
