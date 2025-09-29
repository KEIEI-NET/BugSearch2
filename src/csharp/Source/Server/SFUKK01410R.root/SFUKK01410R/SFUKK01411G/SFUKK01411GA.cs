using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DepBillMonSecDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIDepBillMonSecDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接DepBillMonSecDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 90027　高口　勝</br>
    /// <br>Date       : 2005.08.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationDepBillMonSecDB
    {
        /// <summary>
        /// DepBillMonSecDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.17</br>
        /// </remarks>
        public MediationDepBillMonSecDB()
        {
        }
        /// <summary>
        /// IDepBillMonSecDBインターフェース取得
        /// </summary>
        /// <returns>IDepBillMonSecDBオブジェクト</returns>
        public static IDepBillMonSecDB GetDepBillMonSecDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IDepBillMonSecDB)Activator.GetObject(typeof(IDepBillMonSecDB),string.Format("{0}/MyDepBillMonSec",wkStr));
        }
    }
}
