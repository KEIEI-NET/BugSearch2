//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー・品番S＆E商品コード変換マスタメンテナンス
// プログラム概要   : 商品コード変換の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 寺田義啓
// 作 成 日  2020/02/20  修正内容 : 新規作成
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
    /// SAndEMkrGdsCdChgSetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISAndEMkrGdsCdChgSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SAndEMkrGdsCdChgSetDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 寺田義啓</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSAndEMkrGdsCdChgSetDB
    {
        /// <summary>
        /// SAndEMkrGdsCdChgSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public MediationSAndEMkrGdsCdChgSetDB()
        {

        }

        /// <summary>
        /// ISAndEMkrGdsCdChgSetDBインターフェース取得
        /// </summary>
        /// <returns>ISAndEMkrGdsCdChgSetDBオブジェクト</returns>
        public static ISAndEMkrGdsCdChgSetDB GetSAndEMkrGdsCdChgSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISAndEMkrGdsCdChgSetDB)Activator.GetObject(typeof(ISAndEMkrGdsCdChgSetDB), string.Format("{0}/MyAppSAndEMkrGdsCdChgSet", wkStr));
        }
    }
}
