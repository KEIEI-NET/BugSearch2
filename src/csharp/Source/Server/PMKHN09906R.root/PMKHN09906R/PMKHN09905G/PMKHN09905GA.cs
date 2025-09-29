//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率一括登録・修正Ⅱ
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：caohh
// 修正日    2013/02/19     修正内容：新規作成
// ---------------------------------------------------------------------//
using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 掛率一括登録・修正ⅡDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRate2DBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接Rate2DBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRate2DB
    {
        /// <summary>
        /// 掛率一括登録・修正ⅡDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public MediationRate2DB()
        {
        }
        /// <summary>
        /// IRateDBインターフェース取得
        /// </summary>
        /// <returns>IRateDBオブジェクト</returns>
        public static IRate2DB GetRate2DB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRate2DB)Activator.GetObject(typeof(IRate2DB), string.Format("{0}/MyAppRate2", wkStr));
        }
    }
}
