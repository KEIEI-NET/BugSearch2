using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SeiKingetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISeiKingetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ResultsAcceptOdrDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 18023 樋口　政成</br>
    /// <br>Date       : 2005.05.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSeiKingetDB
    {
        /// <summary>
        /// SeiKingetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 18023 樋口　政成</br>
        /// <br>Date       : 2005.05.19</br>
        /// </remarks>
        public MediationSeiKingetDB()
        {
        }
        /// <summary>
        /// ISeiKingetDBインターフェース取得
        /// </summary>
        /// <returns>ISeiKingetDBオブジェクト</returns>
        public static ISeiKingetDB GetSeiKingetDB()
        {
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (ISeiKingetDB)Activator.GetObject(typeof(ISeiKingetDB),string.Format("{0}/MySeiKinget",wkStr));
		}
    }
}
