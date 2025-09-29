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
	/// <br>Programmer   : 22018　鈴木　正臣</br>
	/// <br>Date         : 2008.05.28</br>
	/// <br></br>
	/// <br>Update Note  : </br>
	/// </remarks>
	public class MediationFrePBillDB
	{
		/// <summary>
        /// FrePSalesSlipDB DB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22018　鈴木　正臣</br>
		/// <br>Date       : 2008.05.28</br>
		/// </remarks>
        public MediationFrePBillDB()
		{
		}
		/// <summary>
        /// IFrePSalesSlipDBインターフェース取得
		/// </summary>
		/// <returns>IPrtmanageDBオブジェクト</returns>
        public static IFrePBillDB GetFrePBillDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IFrePBillDB)Activator.GetObject( typeof( IFrePBillDB ), string.Format( "{0}/MyAppFrePBill", wkStr ) );
		}
	}
}
