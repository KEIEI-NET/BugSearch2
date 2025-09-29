using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SuplierPayDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISuplierPayDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SuplierPayDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSuplierPayDB
    {
        /// <summary>
        /// SuplierPayDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public MediationSuplierPayDB()
        {
        }

        /// <summary>
        /// ISuplierPayDBインターフェース取得
        /// </summary>
        /// <returns>ISuplierPayDBオブジェクト</returns>
        public static ISuplierPayDB GetSuplierPayDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISuplierPayDB)Activator.GetObject(typeof(ISuplierPayDB), string.Format("{0}/MyAppSuplierPay", wkStr));
        }
    }
}
