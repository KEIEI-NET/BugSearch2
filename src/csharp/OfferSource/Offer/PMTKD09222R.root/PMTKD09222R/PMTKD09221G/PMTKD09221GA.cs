using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 提供マージ対象検索DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIMergeDataGetクラスオブジェクトを戻します。</br>
	/// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationMergeDataGetDB
	{
		/// <summary>
        ///提供マージ対象検索DB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.08.15</br>
		/// </remarks>
        public MediationMergeDataGetDB()
		{
			
		}
		
		/// <summary>
        /// IMergeDataGetインターフェース取得
		/// </summary>
        /// <returns>IMergeDataGetオブジェクト</returns>
        public static IMergeDataGet GetRemoteObject()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            //wkStr = "HTTP://10.30.20.202:9002";
            //wkStr = "HTTP://10.30.30.119:9002";
            wkStr = "http://localhost:9002";
#endif

            return (IMergeDataGet)Activator.GetObject(typeof(IMergeDataGet), string.Format("{0}/MyAppMergeDataGet", wkStr));
		}
	}
}
