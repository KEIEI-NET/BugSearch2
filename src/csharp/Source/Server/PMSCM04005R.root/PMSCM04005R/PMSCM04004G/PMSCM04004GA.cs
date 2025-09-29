using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SCMInquiryResultWork仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISCMInquiryResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SCMInquiryResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSCMInquiryResultDB
    {
        /// <summary>
        /// MediationSCMInquiryResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public MediationSCMInquiryResultDB()
        {
        }
        /// <summary>
        /// ISupplierSendErOrderWorkDBインターフェース取得
        /// </summary>+
        /// <returns>ISupplierSendErOrderWorkDBオブジェクト</returns>
        public static ISCMInquiryDB GetSCMInquiryDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISCMInquiryDB)Activator.GetObject(typeof(ISCMInquiryDB), string.Format("{0}/MyAppSCMInquiry", wkStr));
        }
    }
}
