//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナルログイン情報取得DB仲介クラス
// プログラム概要   : ハンディターミナルログイン情報取得DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ハンディターミナルログイン情報取得DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandyLoginInfoDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接HandyLoginInfoDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyLoginInfoDB
    {
        /// <summary>
        /// HandyLoginInfoDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public MediationHandyLoginInfoDB()
        {
        }

        /// <summary>
        /// IHandyLoginInfoDBインターフェース取得
        /// </summary>
        /// <returns>IHandyLoginInfoDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyLoginInfoDBインターフェースを取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public static IHandyLoginInfoDB GetHandyLoginInfoDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

# if DEBUG
            wkStr = "http://localhost:8008";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyLoginInfoDB)Activator.GetObject(typeof(IHandyLoginInfoDB), string.Format("{0}/MyAppHandyLoginInfo", wkStr));
        }
    }
}
