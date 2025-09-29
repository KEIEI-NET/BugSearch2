using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SuppYearResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISuppYearResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SuppYearResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 長内 数馬</br>
    /// <br>Date       : 2008.11.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSuppYearResultDB
    {
        /// <summary>
        /// SalesAnnualDataSelectResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 長内 数馬</br>
        /// <br>Date       : 2008.11.20</br>
        /// </remarks>
        public MediationSuppYearResultDB()
        {
        }
        /// <summary>
        /// ISuppYearResultDBインターフェース取得
        /// </summary>
        /// <returns>ISuppYearResultDBオブジェクト</returns>
        public static ISuppYearResultDB GetSuppYearResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISuppYearResultDB)Activator.GetObject(typeof(ISuppYearResultDB), string.Format("{0}/MyAppSuppYearResult", wkStr));
        }
    }
}
