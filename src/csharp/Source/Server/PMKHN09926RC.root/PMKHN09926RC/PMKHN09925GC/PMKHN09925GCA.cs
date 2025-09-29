//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品テキスト変換DB仲介クラス
// プログラム概要   : 商品テキスト変換DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10802197-00  作成担当 : FSI菅原 庸平
// 作 成 日  K2012/05/28  修正内容 : 新規作成 山形部品個別対応
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 商品テキスト変換DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsUMasDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接GoodsUMasDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : K2012/05/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsUMasDB
    {
        /// <summary>
        /// GoodsUMasDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        public MediationGoodsUMasDB()
        {

        }

        /// <summary>
        /// IGoodsUMasDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsUMasDBオブジェクト</returns>
        public static IGoodsUMasDB GetGoodsUMasDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsUMasDB)Activator.GetObject(typeof(IGoodsUMasDB), string.Format("{0}/MyAppGoodsUMas", wkStr));
        }
    }
}
