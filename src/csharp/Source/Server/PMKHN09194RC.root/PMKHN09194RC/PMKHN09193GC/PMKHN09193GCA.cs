//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品（テキスト変換）
// プログラム概要   : 商品マスタテキスト変換  DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902160-00  作成担当 : 高陽
// 作 成 日  K2013/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// 商品マスタテキスト変換  DB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIGoodsTextExpDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接GoodsTextExpDBを</br>
	/// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 高陽</br>
    /// <br>Date       : K2013/08/08</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsTextExpDB
	{
		/// <summary>
        /// GoodsTextExpDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
        /// </remarks>
        public MediationGoodsTextExpDB()
		{
		}

		/// <summary>
        /// IGoodsTextExpDBインターフェース取得
		/// </summary>
        /// <returns>IGoodsTextExpDBオブジェクト</returns>
        public static IGoodsTextExpDB GetGoodsTextExpDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsTextExpDB)Activator.GetObject(typeof(IGoodsTextExpDB), string.Format("{0}/MyAppGoodsTextExp", wkStr));
		}
	}
}
