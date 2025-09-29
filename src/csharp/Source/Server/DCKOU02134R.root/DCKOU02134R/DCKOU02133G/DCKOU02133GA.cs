using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StcRetGdsSlipTtlDataDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStcRetGdsSlipTtlDataDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接StcRetGdsSlipTtlDataDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStcRetGdsSlipTtlDataDB
    {
        /// <summary>
        /// StcRetGdsSlipTtlDataDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        public MediationStcRetGdsSlipTtlDataDB()
        {
        }
        /// <summary>
        /// IStcRetGdsSlipTtlDataDBインターフェース取得
        /// </summary>
        /// <returns>IStcRetGdsSlipTtlDataDBオブジェクト</returns>
        public static IStcRetGdsSlipTtlDataDB GetStcRetGdsSlipTtlDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStcRetGdsSlipTtlDataDB)Activator.GetObject(typeof(IStcRetGdsSlipTtlDataDB),string.Format("{0}/MyAppStcRetGdsSlipTtlData",wkStr));
        }
    }
}
