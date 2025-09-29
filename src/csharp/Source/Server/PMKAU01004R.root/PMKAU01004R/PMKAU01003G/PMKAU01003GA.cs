using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// 自由帳票（請求書） DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : このクラスはIFrePDailyExtRetクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>               完全スタンドアロンにする場合にはこのクラスで直接FrePSalesSlipDBを</br>
	/// <br>               インスタンス化して戻します。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// <br>Update Note  : </br>
	/// </remarks>
	public class MediationEBooksFrePBillDB
	{
		/// <summary>
        /// MediationEBooksFrePBillDB DB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
        public MediationEBooksFrePBillDB()
		{
		}
		/// <summary>
        /// IEBooksFrePBillDBインターフェース取得
		/// </summary>
        /// <returns>IEBooksFrePBillDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note        : IEBooksFrePBillDBインターフェース取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static IEBooksFrePBillDB GetEBooksFrePBillDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEBooksFrePBillDB)Activator.GetObject(typeof(IEBooksFrePBillDB), string.Format("{0}/MyAppEBooksFrePBill", wkStr));
		}
	}
}
