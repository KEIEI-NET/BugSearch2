//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付け  DB 仲介クラス
// プログラム概要   : 商品バーコード関連付けテーブルに対して各操作処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MediationGoodsBarCodeRevnDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはMediationGoodsBarCodeRevnDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接MediationGoodsBarCodeRevnDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
	public class MediationGoodsBarCodeRevnDB
	{
        /// <summary>
        /// MediationGoodsBarCodeRevnDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public MediationGoodsBarCodeRevnDB()
		{
		}
		/// <summary>
        /// IGoodsBarCodeRevnDBインターフェース取得
		/// </summary>
        /// <returns>IGoodsBarCodeRevnDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IGoodsBarCodeRevnDBインターフェース取得処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public static IGoodsBarCodeRevnDB GetGoodsBarCodeRevnDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsBarCodeRevnDB)Activator.GetObject(typeof(IGoodsBarCodeRevnDB), string.Format("{0}/MyAppGoodsBarCodeRevn", wkStr));
		}
	}
}
