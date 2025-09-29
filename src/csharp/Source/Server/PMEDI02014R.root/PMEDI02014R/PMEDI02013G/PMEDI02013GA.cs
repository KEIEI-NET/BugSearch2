//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト
// プログラム概要   : 売上データテキストを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EDISalesResultDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIEDISalesResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接EDISalesResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/11/20</br>
    /// <br></br>
    /// </remarks>
    public class MediationEDISalesResultDB
    {
        /// <summary>
        /// EDISalesResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public MediationEDISalesResultDB()
        {
        }
        /// <summary>
        /// IEDISalesResultDBインターフェース取得
        /// </summary>
        /// <returns>IEDISalesResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IEDISalesResultDBインターフェースを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public static IEDISalesResultDB GetEDISalesResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // デバッグ用
#if DEBUG
            wkStr = "http://localhost:8001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEDISalesResultDB)Activator.GetObject(typeof(IEDISalesResultDB), string.Format("{0}/MyAppEDISalesResult", wkStr));
        }
    }
}
