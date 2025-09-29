//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報マスタメンテナンス
// プログラム概要   : 接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : 田建委
// 作 成 日  2019/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ConnectInfoPrcPrStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIConnectInfoPrcPrStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ConnectInfoPrcPrStDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : lyc</br>
    /// <br>Date       : 2019/12/03</br>
    /// <br>管理番号   : 10901034-00</br>
    /// <br></br>
    /// </remarks>
    public class MediationSalCprtConnectInfoPrcPrStDB 
    {
        /// <summary>
        /// IConnectInfoPrcPrStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public MediationSalCprtConnectInfoPrcPrStDB()
        {
        }
        /// <summary>
        /// IConnectInfoPrcPrStDBインターフェース取得
        /// </summary>
        /// <returns>ISlipPrtSetDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IConnectInfoPrcPrStDBインターフェース取得</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// <br></br>
        /// </remarks>
        public static ISalCprtConnectInfoPrcPrStDB GetSalCprtConnectInfoPrcPrStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalCprtConnectInfoPrcPrStDB)Activator.GetObject(typeof(ISalCprtConnectInfoPrcPrStDB), string.Format("{0}/MyAppSalCprtConnectInfoPrcPrSt", wkStr));
        }
    }
}
