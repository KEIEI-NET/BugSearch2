//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   簡単問合せ接続情報DB仲介クラス
//                  :   PMSCM00204G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21024　佐々木 健
// Date             :   2010/03/25
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CMTCnectInfoDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICMTCnectInfoDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CMTCnectInfoDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSimplInqCnectInfoDB
    {
        /// <summary>
        /// CMTCnectInfoDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public MediationSimplInqCnectInfoDB()
        {

        }

        /// <summary>
        /// ICMTCnectInfoDBインターフェース取得
        /// </summary>
        /// <returns>ICMTCnectInfoDBオブジェクト</returns>
        public static ISimplInqCnectInfoDB GetSimplInqCnectInfoDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISimplInqCnectInfoDB)Activator.GetObject(typeof(ISimplInqCnectInfoDB), string.Format("{0}/MySimplInqCnectInfo", wkStr));
        }
    }
}
