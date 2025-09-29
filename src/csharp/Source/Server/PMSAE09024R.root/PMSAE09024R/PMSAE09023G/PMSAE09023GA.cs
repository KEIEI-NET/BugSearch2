//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品コード変換マスタメンテナンス
// プログラム概要   : 商品コード変換の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SAndEGoodsCdChgSetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISAndEGoodsCdChgSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SAndEGoodsCdChgSetDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSAndEGoodsCdChgSetDB
    {
        /// <summary>
        /// SAndEGoodsCdChgSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public MediationSAndEGoodsCdChgSetDB()
        {

        }

        /// <summary>
        /// ISAndEGoodsCdChgSetDBインターフェース取得
        /// </summary>
        /// <returns>ISAndEGoodsCdChgSetDBオブジェクト</returns>
        public static ISAndEGoodsCdChgSetDB GetSAndEGoodsCdChgSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISAndEGoodsCdChgSetDB)Activator.GetObject(typeof(ISAndEGoodsCdChgSetDB), string.Format("{0}/MyAppSAndEGoodsCdChgSet", wkStr));
        }
    }
}
