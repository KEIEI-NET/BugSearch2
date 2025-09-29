//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   GoodsUpdateDB仲介クラス
//                  :   PMKHN09673G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   zhouyu
// Date             :   2011/07/22
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsUpdateDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsUpdateDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接GoodsUpdateDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : zhouyu</br>
    /// <br>Date       : 2011/07/22</br>
    /// <br>Update Note: 連番1029  新規</br>
    /// </remarks>
    public class MediationIGoodsUpdateDB
    {
        /// <summary>
        /// GoodsUpdateDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        public MediationIGoodsUpdateDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IGoodsUpdateDB GetIGoodsUpdateDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            return (IGoodsUpdateDB)Activator.GetObject(typeof(IGoodsUpdateDB), string.Format("{0}/MyAppGoodsUpdate", wkStr));
        }

    }
}
