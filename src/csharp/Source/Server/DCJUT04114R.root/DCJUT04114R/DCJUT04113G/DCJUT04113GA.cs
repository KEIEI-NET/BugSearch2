using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// AcptAnOdrRemainRefDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIAcptAnOdrRemainRefDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接AcptAnOdrRemainRefDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationAcptAnOdrRemainRefDB
    {
        /// <summary>
        /// AcptAnOdrRemainRefDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        public MediationAcptAnOdrRemainRefDB()
        {

        }

        /// <summary>
        /// IAcptAnOdrRemainRefDBインターフェース取得
        /// </summary>
        /// <returns>IAcptAnOdrRemainRefDBオブジェクト</returns>
        public static IAcptAnOdrRemainRefDB GetAcptAnOdrRemainRefDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IAcptAnOdrRemainRefDB)Activator.GetObject(typeof(IAcptAnOdrRemainRefDB),string.Format("{0}/MyAppAcptAnOdrRemainRef",wkStr));
        }
    }
}
