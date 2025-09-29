//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PriceSelectSetWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPriceSelectSetWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接PriceSelectSetWorkDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 姚学剛</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br></br>
    /// </remarks>
    public class MediationPriceSelectSetWorkDB
    {
        /// <summary>
        /// DepsitListWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public MediationPriceSelectSetWorkDB()
        {

        }

        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IPrtmanageDBインターフェース取得。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public static IPriceSelectSetWorkDB GetPriceSelectSetWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPriceSelectSetWorkDB)Activator.GetObject(typeof(IPriceSelectSetWorkDB), string.Format("{0}/MyAppPriceSelectSetWork", wkStr));
        }
    }
}
