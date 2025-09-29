//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : テキスト出力操作ログ登録処理DB仲介クラス
// プログラム概要   : テキスト出力操作ログ登録処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570163-00  作成担当 : 田建委
// 作 成 日  2019/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TextOutPutOprtnHisLogDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITextOutPutOprtnHisLogDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接TextOutPutOprtnHisLogDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/08/12</br>
    /// </remarks>
    public class MediationTextOutPutOprtnHisLogDB
    {
        /// <summary>
        /// DataCopyDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public MediationTextOutPutOprtnHisLogDB()
        {

        }

        /// <summary>
        /// ITextOutPutOprtnHisLogDBインターフェース取得
        /// </summary>
        /// <returns>ITextOutPutOprtnHisLogDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ITextOutPutOprtnHisLogDBインターフェース取得処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public static ITextOutPutOprtnHisLogDB GetDataCopyDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITextOutPutOprtnHisLogDB)Activator.GetObject(typeof(ITextOutPutOprtnHisLogDB), string.Format("{0}/MyAppTextOutPutOprtnHisLog", wkStr));
        }
    }
}
