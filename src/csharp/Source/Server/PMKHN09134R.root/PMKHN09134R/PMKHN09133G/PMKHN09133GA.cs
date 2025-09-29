using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// オペレーション設定DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIOperationStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接OperationStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOperationStDB
    {
        /// <summary>
        /// OperationStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        public MediationOperationStDB()
        {

        }

        /// <summary>
        /// IOperationStDBインターフェース取得
        /// </summary>
        /// <returns>IOperationStDBオブジェクト</returns>
        public static IOperationStDB GetOperationStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IOperationStDB)Activator.GetObject(typeof(IOperationStDB), string.Format("{0}/MyAppOperationSt", wkStr));
        }
    }
}
