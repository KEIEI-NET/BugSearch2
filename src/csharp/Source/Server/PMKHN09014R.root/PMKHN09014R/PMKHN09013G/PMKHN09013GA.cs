//============================================================================//
// システム         : PM.NS
// プログラム名称   : 得意先マスタリモート仲介クラス
// プログラム概要   : 得意先マスタリモートオブジェクトを取得します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10402071-00  作成担当 : 21112
// 作 成 日  2008/04/23  修正内容 : SFTOK01134G をベースにPM.NS用を作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CustomerDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはICustomerDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>　　　　　　 完全スタンドアロンにする場合にはこのクラスで直接CustomerDBを</br>
	/// <br>　　　　　　 インスタンス化して戻します。</br>
	/// <br>Programmer : 21112</br>
	/// <br>Date       : 2008.04.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br></br>
	/// </remarks>
	public class MediationCustomerInfoDB
	{
		/// <summary>
		/// CustomerDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		public MediationCustomerInfoDB()
		{

		}

		/// <summary>
		/// ICustomerDBインターフェース取得
		/// </summary>
		/// <returns>ICustomerDBオブジェクト</returns>
		public static ICustomerInfoDB GetCustomerInfoDB()
		{
			// USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			// AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (ICustomerInfoDB)Activator.GetObject(typeof(ICustomerInfoDB),string.Format("{0}/MyAppCustomer",wkStr));
		}
	}
}
