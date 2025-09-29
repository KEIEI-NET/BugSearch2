using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EmployeeRoleStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIEmployeeRoleStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接EmployeeRoleStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30747 三戸　伸悟</br>
    /// <br>Date       : 2013/02/07</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationEmployeeRoleStDB
    {
        /// <summary>
        /// EmployeeRoleStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        public MediationEmployeeRoleStDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IEmployeeRoleStDB GetEmployeeRoleStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEmployeeRoleStDB)Activator.GetObject(typeof(IEmployeeRoleStDB), string.Format("{0}/MyAppEmployeeRoleSt", wkStr));
        }
    }
}
