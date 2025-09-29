//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 葉書・封筒・ＤＭテキスト出力
// プログラム概要   : 葉書・封筒・ＤＭテキスト出力を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// UseMastListDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIUseMastListDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接UseMastListDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationUseMastDB
    {
        /// <summary>
        /// IUseMastListDB仲介クラスコンストラクタ											
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public MediationUseMastDB()
        {
        }
        /// <summary>
        /// IUseMastListDBインターフェース取得
        /// </summary>
        /// <returns>IUseMastListDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note　　　  : IUseMastListDBインターフェース取得</br>                  
        /// <br>Programmer  : 朱宝軍</br>                                    
        /// <br>Date        : 2009.04.01</br>                                        
        /// </remarks>
        public static IUseMastListDB GetMastDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8009";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IUseMastListDB)Activator.GetObject(typeof(IUseMastListDB), string.Format("{0}/MyAppUseMast", wkStr));
        }

    }
}
