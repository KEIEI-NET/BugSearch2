//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ
// プログラム概要   : 自由検索型式マスタ DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 自由検索型式マスタ DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは自由検索型式マスタ検索DBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010/04/30</br>
    /// </remarks>
    public class MediationFreeSearchModelDB
    {
        /// <summary>
        /// 自由検索型式マスタ DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public MediationFreeSearchModelDB()
        {
        }
        /// <summary>
        /// ISupplierChangeProcDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierChangeProcDBオブジェクト</returns>
        public static IFreeSearchModelDB GetFreeSearchModelDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IFreeSearchModelDB)Activator.GetObject(typeof(IFreeSearchModelDB), string.Format("{0}/MyAppFreeSearchModel", wkStr));
        }
    }
}
