using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CustomInqOrderWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalStcCompReportResultWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalStcCompReportResultWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalStcCompReportResultWorkDB
    {
        /// <summary>
        /// MediationSalStcCompReportResultWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.18</br>
        /// </remarks>
        public MediationSalStcCompReportResultWorkDB()
        {
        }
        /// <summary>
        /// ISalStcCompReportResultWorkDBインターフェース取得
        /// </summary>
        /// <returns>ISalStcCompReportResultWorkDBオブジェクト</returns>
        public static ISalStcCompReportResultWorkDB GetSalStcCompReportResultWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalStcCompReportResultWorkDB)Activator.GetObject(typeof(ISalStcCompReportResultWorkDB), string.Format("{0}/MyAppSalStcCompReportResultWork", wkStr));
        }
    }
}
