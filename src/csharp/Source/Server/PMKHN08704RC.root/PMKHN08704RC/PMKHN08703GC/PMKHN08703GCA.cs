//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品価格マスタ展開DB仲介クラス
// プログラム概要   : 部品価格マスタ展開DB仲介クラスを管理する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : huangqb
// 作 成 日  K2011/07/14 作成内容 : イスコ個別対応
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 部品価格マスタ展開DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICostExpandDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CostExpandDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : huangqb</br>
    /// <br>Date       : K2011/07/14</br>
    /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
    /// <br></br>
    /// </remarks>
    public class MediationCostExpandDB
    {
        /// <summary>
        /// 部品価格マスタ展開DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        public MediationCostExpandDB()
        {
        }

        /// <summary>
        /// ICostExpandDBインターフェース取得
        /// </summary>
        /// <returns>ICostExpandDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ICostExpandDBインターフェースを取得します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        public static ICostExpandDB GetCostExpandDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif            
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICostExpandDB)Activator.GetObject(typeof(ICostExpandDB), string.Format("{0}/MyAppCostExpand", wkStr));
        }
    }
}
