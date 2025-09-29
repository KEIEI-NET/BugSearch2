//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表DB仲介クラス
// プログラム概要   : IArrGoodsDiffResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 入荷差異表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIArrGoodsDiffResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接MediationArrGoodsDiffResultDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public class MediationArrGoodsDiffResultDB
    {
        /// <summary>
        /// MediationArrGoodsDiffResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public MediationArrGoodsDiffResultDB()
        {
        }
        /// <summary>
        /// IArrGoodsDiffResultDBインターフェース取得
        /// </summary>
        /// <returns>IArrGoodsDiffResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IArrGoodsDiffResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public static IArrGoodsDiffResultDB GetArrGoodsDiffResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9011";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IArrGoodsDiffResultDB)Activator.GetObject(typeof(IArrGoodsDiffResultDB), string.Format("{0}/MyAppArrGoodsDiffResult", wkStr));
        }
    }
}
