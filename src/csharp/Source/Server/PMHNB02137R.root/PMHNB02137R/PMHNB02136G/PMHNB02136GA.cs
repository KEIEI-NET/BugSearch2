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
    /// <br>Note       : このクラスはICustomInqOrderWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CustomInqOrderWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustFinancialListResultWorkDB
    {
        /// <summary>
        /// MediationPublicationConfOrderWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public MediationCustFinancialListResultWorkDB()
        {
        }
        /// <summary>
        /// ICustomInqOrderWorkDBインターフェース取得
        /// </summary>
        /// <returns>ICustomInqOrderWorkDBオブジェクト</returns>
        public static ICustFinancialListResultWorkDB GetCustFinancialListResultWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustFinancialListResultWorkDB)Activator.GetObject(typeof(ICustFinancialListResultWorkDB), string.Format("{0}/MyAppCustFinancialListResultWork", wkStr));
        }
    }
}
