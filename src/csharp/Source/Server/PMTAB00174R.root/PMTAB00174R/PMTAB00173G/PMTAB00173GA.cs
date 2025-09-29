//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受注マスタ(車両)DB仲介クラス
// プログラム概要   : 受注マスタ(車両)DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/05/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// IPmTabAcpOdrCarDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPmTabAcpOdrCarDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PmTabAcpOdrCarDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/05/30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmTabAcpOdrCarDB
    {
        /// <summary>
        /// PmTabAcpOdrCarDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        /// </remarks>
        public MediationPmTabAcpOdrCarDB()
        {

        }

        /// <summary>
        /// IPmTabAcpOdrCarDBインターフェース取得
        /// </summary>
        /// <returns>IPmTabAcpOdrCarDBオブジェクト</returns>
        public static IPmTabAcpOdrCarDB GetPmTabAcpOdrCarDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPmTabAcpOdrCarDB)Activator.GetObject(typeof(IPmTabAcpOdrCarDB), string.Format("{0}/MyAppPmTabAcpOdrCar", wkStr));
        }
    }
}
