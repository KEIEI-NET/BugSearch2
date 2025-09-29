using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// DepsitListWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIDepsitListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StcDataRefListWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22013 kubo</br>
    /// <br>Date       : 2007.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStcDataRefListWorkDB
    {
        /// <summary>
        /// DepsitListWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.06.06</br>
        /// </remarks>
        public MediationStcDataRefListWorkDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IStcDataRefListWorkDB GetStcDataRefListWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            IStcDataRefListWorkDB isworkDB = (IStcDataRefListWorkDB)Activator.GetObject(typeof(IStcDataRefListWorkDB), string.Format("{0}/MyAppStcDataRefListWork", wkStr));
			return isworkDB;
        }
    }
}
