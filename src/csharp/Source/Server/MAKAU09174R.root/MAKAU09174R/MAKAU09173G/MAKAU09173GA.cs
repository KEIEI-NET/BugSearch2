using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// MediationDmdPrtPtnSetDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIDmdPrtPtnSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接DmdPrtPtnSetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2007.07.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDmdPrtPtnSetDB
	{
		/// <summary>
        /// DmdPrtPtnSetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2007.07.02</br>
		/// </remarks>
        public MediationDmdPrtPtnSetDB()
		{
		}
		/// <summary>
        /// IDmdPrtPtnSetDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
        public static IDmdPrtPtnSetDB GetDmdPrtPtnSetDB()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            return (IDmdPrtPtnSetDB)Activator.GetObject(typeof(IDmdPrtPtnSetDB), string.Format("{0}/MyAppDmdPrtPtnSet", wkStr));
        }
	}
}
