//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 優良部品詳細マスタDBリモートオブジェクト
// プログラム概要   : 優良部品詳細マスタの取得を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00 作成担当 : 櫻井　亮太
// 作 成 日  2017/10/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TbsPartsCodeDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPrimePartsDtlDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PrimePartsDtlDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2017.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPrimePartsDtl
    {
        /// <summary>
        /// MediationPrimePartsDtl仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        /// </remarks>
        public MediationPrimePartsDtl()
        {
        }
        /// <summary>
        /// IPrimePartsDtlDBインターフェース取得
        /// </summary>
        /// <returns>IPrimePartsDtlDBオブジェクト</returns>
        public static IPrimePartsDtlDB GetPrimePartsDtlDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            
#if DEBUG
            wkStr = "http://localhost:9012";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
    return (IPrimePartsDtlDB)Activator.GetObject(typeof(IPrimePartsDtlDB), string.Format("{0}/MyAppPrimePartsDtl", wkStr));
        }
    }
}
