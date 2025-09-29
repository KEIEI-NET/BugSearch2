//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員別販売区分別売上目標設定マスタ
// プログラム名称   : 従業員別販売区分別売上目標設定マスタ 仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11500865-00  作成担当 : 譚洪
// 作 成 日  2019/09/02   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// EmpScSalesTargetDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIEmpScSalesTargetDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接EmpSalesTargetDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2019/09/02</br>
	/// </remarks>
	public class MediationEmpScSalesTargetDB
	{
		/// <summary>
		/// EmpSalesTargetDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/09/02</br>
		/// </remarks>
        public MediationEmpScSalesTargetDB()
		{
		}
		/// <summary>
        /// IEmpScSalesTargetDBインターフェース取得
		/// </summary>
        /// <returns>IEmpScSalesTargetDBオブジェクト</returns>
        public static IEmpScSalesTargetDB GetEmpScSalesTargetDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9011";
#endif
			
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEmpScSalesTargetDB)Activator.GetObject(typeof(IEmpScSalesTargetDB), string.Format("{0}/MyAppEmpScSalesTarget", wkStr));
		}
	}
}
