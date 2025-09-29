using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SlipOutputSetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISlipOutputSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>            完全スタンドアロンにする場合にはこのクラスで直接SlipOutputSetDBを</br>
    /// <br>            インスタンス化して戻します。</br>
    /// <br>Programmer : 980081  山田 明友</br>
    /// <br>Date       : 2007.12.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSlipOutputSetDB
    {
        /// <summary>
        /// SlipOutputSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public MediationSlipOutputSetDB()
        {
        }
        /// <summary>
        /// ISlipOutputSetDBインターフェース取得
        /// </summary>
        /// <returns>ISlipOutputSetDBオブジェクト</returns>
        public static ISlipOutputSetDB GetSlipOutputSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISlipOutputSetDB)Activator.GetObject(typeof(ISlipOutputSetDB),string.Format("{0}/MyAppSlipOutputSet",wkStr));
        }
    }
}
