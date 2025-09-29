using System;
using System.IO;
using System.Reflection;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ネットワーク通信処理DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはAWSCommTstRsltDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接AWSCommTstRsltDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2019.01.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationAWSCommTstRsltDB
    {
        /// <summary>
        /// ネットワーク通信処理DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public MediationAWSCommTstRsltDB()
        {
        }
        /// <summary>
        /// IAWSCommTstRsltDBインターフェース取得
        /// </summary>
        /// <returns>IAWSCommTstRsltDBオブジェクト</returns>
        public static IAWSCommTstRsltDB GetAWSCommTstRsltDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_Center_UserAP);
#if DEBUG
            //wkStr = "http://localhost:8028";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IAWSCommTstRsltDB)Activator.GetObject(typeof(IAWSCommTstRsltDB), string.Format("{0}/MyAppAWSCommTstRslt", wkStr));
        }
    }
}
