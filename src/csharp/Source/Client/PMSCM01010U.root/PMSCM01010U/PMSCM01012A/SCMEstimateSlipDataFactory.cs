//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using EstimateDefSetServer = SingletonInstance<EstimateDefSetAgent>;   // 見積初期値設定マスタ

    /// <summary>
    /// SCM見積伝票データの生成クラス
    /// </summary>
    public sealed class SCMEstimateSlipDataFactory : SCMSlipDataFactory
    {
        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="scmHeaderRecord">SCM受注データのレコード</param>
        /// <param name="topPriorityIsSCMTotalSetting">SCM全体設定を最優先するフラグ</param>
        public SCMEstimateSlipDataFactory(
            ISCMOrderHeaderRecord scmHeaderRecord,
            bool topPriorityIsSCMTotalSetting
        ) : base(scmHeaderRecord, topPriorityIsSCMTotalSetting) { }

        #endregion // </Constructor>

        #region <見積初期値マスタ>

        /// <summary>
        /// 見積初期値設定マスタを取得します。
        /// </summary>
        private static EstimateDefSetAgent EstimateDefSetDB
        {
            get { return EstimateDefSetServer.Singleton.Instance; }
        }

        #endregion // </見積初期値マスタ>

        #region <114.伝票発行区分>

        /// <summary>
        /// 伝票発行区分を取得します。
        /// </summary>
        /// <returns>伝票発行区分(0:しない/1:する)</returns>
        /// <see cref="SCMSlipDataFactory"/>
        public override int GetSlipPrintDivCd()
        {
            int slipPrintDivCd = 0; // 0:しない

            // 見積初期値設定マスタより
            EstimateDefSet salesTotalSetting = EstimateDefSetDB.Find(
                SCMHeaderRecord.InqOtherEpCd,
                SCMHeaderRecord.InqOtherSecCd
            );
            if (salesTotalSetting != null)
            {
                slipPrintDivCd = salesTotalSetting.EstimateDtCreateDiv; // 見積データ作成区分
            }
            if (TopPriorityIsSCMTotalSetting)
            {
                // 見積初期値設定マスタに存在しない場合、SCM全体設定マスタより
                SCMTtlSt scmTotalSetting = SCMTotalSettingDB.Find(
                    SCMHeaderRecord.InqOtherEpCd,
                    SCMHeaderRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(scmTotalSetting)) scmTotalSetting = null;
                if (scmTotalSetting != null)
                {
                    slipPrintDivCd = scmTotalSetting.EstimatePrtDiv;    // 見積書発行区分
                }
            }
            return slipPrintDivCd;
        }

        #endregion // </114.伝票発行区分>
    }
}
