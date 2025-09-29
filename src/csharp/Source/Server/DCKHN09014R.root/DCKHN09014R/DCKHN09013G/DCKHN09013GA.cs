using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SubSectionDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISubSectionDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SubSectionDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 96050  横川　昌令</br>
    /// <br>Date       : 2007.08.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSubSectionDB
    {
        /// <summary>
        /// SubSectionDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.10</br>
        /// </remarks>
        public MediationSubSectionDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static ISubSectionDB GetSubSectionDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISubSectionDB)Activator.GetObject(typeof(ISubSectionDB), string.Format("{0}/MyAppSubSection", wkStr));
        }
    }
}
