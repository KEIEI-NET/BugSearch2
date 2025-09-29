using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CarModelSearch仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICompanyInfDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CompanyInfDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 99033　岩本　勇</br>
    /// <br>Date       : 2005.04.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCarModelCtlDB
    {
        /// <summary>
        /// CompanyInfDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.02.15</br>
        /// </remarks>
        public MediationCarModelCtlDB()
        {

        }

        /// <summary>
        /// ICarModelSearchインターフェース取得
        /// </summary>
        /// <returns>ICarModelSearchオブジェクト</returns>
        public static ICarModelCtlDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif

			return (ICarModelCtlDB)Activator.GetObject(typeof(ICarModelCtlDB), string.Format("{0}/MyAppCarModelCtl", wkStr));
        }
    }
}
