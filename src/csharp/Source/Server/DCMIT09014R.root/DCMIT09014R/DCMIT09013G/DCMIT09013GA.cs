﻿using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EstimateDefSetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIEstimateDefSetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接EstimateDefSetDBを</br>
    /// <br>			       インスタンス化して戻します。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.09.26</br>
    /// </remarks>
    public class MediationEstimateDefSetDB
    {
        /// <summary>
        /// EstimateDefSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        public MediationEstimateDefSetDB()
        {
        }
        /// <summary>
        /// IEstimateDefSetDBインターフェース取得
        /// </summary>
        /// <returns>IEstimateDefSetDBオブジェクト</returns>
        public static IEstimateDefSetDB GetEstimateDefSetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
  wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEstimateDefSetDB)Activator.GetObject(typeof(IEstimateDefSetDB), string.Format("{0}/MyAppEstimateDefSet", wkStr));
        }
    }
}
