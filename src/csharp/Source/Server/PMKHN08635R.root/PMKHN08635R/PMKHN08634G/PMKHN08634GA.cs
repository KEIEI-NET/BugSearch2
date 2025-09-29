using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalTrgtPrintResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalTrgtPrintResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalTrgtPrintResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalTrgtPrintResultDB
    {
        /// <summary>
        /// SalTrgtPrintResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public MediationSalTrgtPrintResultDB()
        {
        }
        /// <summary>
        /// ISalTrgtPrintResultDBインターフェース取得
        /// </summary>
        /// <returns>ISalTrgtPrintResultDBオブジェクト</returns>
        public static ISalTrgtPrintResultDB GetSalTrgtPrintResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalTrgtPrintResultDB)Activator.GetObject(typeof(ISalTrgtPrintResultDB), string.Format("{0}/MyAppSalTrgtPrintResult", wkStr));
        }
    }
}
