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
// 作 成 日  2009/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2011/10/10  修正内容 : Redmine#25762 在庫確認の自動回答時、見積データを作成しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2011/11/12  修正内容 : Redmine#26533 Redmine#25762の変更を元に戻す
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/08  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 01.商品検索アクセスクラス補正処理プロパティ対応
//                                : 02.得意先掛率グループマスタ取得改良対応（回答判定時）
//                                : 03.変更前単価計算呼出回数改良対応
//                                : 04.キャンペーン売価設定マスタ取得改良対応
//                                : 05.得意先マスタ（伝票管理）取得改良対応
//                                : 06.得意先マスタ取得改良対応（金額計算クラス）
//                                : 07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応）
//                                : 08.売上データ生成時のシステム日付取得対応
//                                : 09.得意先掛率グループマスタ取得改良対応（売上データ生成時）
//                                : 10.単価計算呼出回数改良
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller.Auto
{
    /// <summary>
    /// SCM自動回答用売上データ作成処理クラス
    /// </summary>
    public sealed class SCMAutoSalesDataMaker : SCMSalesDataMaker
    {
        #region <ログ用定数>

        /// <summary>クラス名称</summary>
        private const string MY_NAME = "SCMAutoSalesDataMaker";

        #endregion // </ログ用定数>

        #region <代表データ>

        /// <summary>代表SCM受注データ</summary>
        private ISCMOrderHeaderRecord _representativeSCMHeaderRecord;
        /// <summary>代表SCM受注データを取得または設定します。</summary>
        private ISCMOrderHeaderRecord RepresentativeSCMHeaderRecord
        {
            get { return _representativeSCMHeaderRecord; }
            set
            {
                if (_representativeSCMHeaderRecord != null) return;
                _representativeSCMHeaderRecord = value;
            }
        }

        /// <summary>
        /// 代表企業コードを取得します。
        /// </summary>
        /// <returns>代表SCM受注データの問合せ先企業コード</returns>
        private string GetRepresentativeEnterpriseCode()
        {
            if (RepresentativeSCMHeaderRecord != null)
            {
                return RepresentativeSCMHeaderRecord.InqOtherEpCd;
            }
            return LoginInfoAcquisition.EnterpriseCode;
        }

        /// <summary>
        /// 代表拠点コードを取得します。
        /// </summary>
        /// <returns>代表SCM受注データの問合せ先拠点コード</returns>
        private string GetRepresentativeSectionCode()
        {
            if (RepresentativeSCMHeaderRecord != null)
            {
                return RepresentativeSCMHeaderRecord.InqOtherSecCd;
            }
            return "00";    // 全社
        }

        #endregion // </代表データ>

        /// <summary>相場回答のみであるかのフラグ</summary>
        private bool _isSobaAnswerOnly;

        /// <summary>相場回答のみのI/O Writer用パラメータ</summary>
        /// <remarks><c>CreateSalesData()</c>にて、売上明細データが存在しない場合に構築されます。</remarks>
        private CustomSerializeArrayList _scmOrderDataWithSobaOnly;

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="referee">SCM回答判定処理</param>
        public SCMAutoSalesDataMaker(SCMReferee referee) : base(referee) { }

        #endregion // </Constructor>

        #region <Override>


        // 2011/02/14 Add >>>
        /// <summary>
        /// 自動回答か判断します。
        /// </summary>
        /// <returns></returns>
        protected override bool IsAutoAnswer()
        {
            return true;
        }
        // 2011/02/14 Add <<<

        // 2011/02/18 Add >>>
        /// <summary>
        /// 回答作成区分を取得します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <returns>
        /// 受注ステータスが「10:見積」「30:売上」の場合、「0:自動」を返します。<br/>
        /// それ以外（「20:受注」）の場合、「1:手動(Web)」を返します。
        /// </returns>
        protected override int GetAnswerCreateDiv(int acptAnOdrStatus)
        {
            if (
                acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate)
                    ||
                acptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales)
            )
            {
                return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.Auto;
            }
            return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.ManualWeb;
        }
        // 2011/02/18 Add <<<

        /// <summary>
        /// 相場回答のみか判断します。
        /// </summary>
        /// <value>
        /// <c>true</c> :相場回答のみです。<br/>
        /// <c>false</c>:相場回答のみではありません。
        /// </value>
        /// <see cref="SCMSalesDataMaker"/>
        public override bool IsSobaAnswerOnly
        {
            get { return _isSobaAnswerOnly; }
        }

        /// <summary>
        /// 相場回答のみのI/O Writer用パラメータを取得します。
        /// </summary>
        /// <see cref="SCMSalesDataMaker"/>
        public override CustomSerializeArrayList SobaOnlySCMOrderDataParameterList
        {
            get
            {
                if (_scmOrderDataWithSobaOnly == null)
                {
                    _scmOrderDataWithSobaOnly = base.CreateSalesData();
                }
                return _scmOrderDataWithSobaOnly;
            }
        }

        /// <summary>
        /// 売上リストの生成者を生成します。
        /// </summary>
        /// <returns>売上リストの生成者</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override SCMSalesListEssence CreateSCMSalesListEssence()
        {
            return new SCMAutoSalesListEssence();
        }

        /// <summary>
        /// 売上データを作成可能か判断します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <returns>
        /// <c>true</c> :作成できます。<br/>
        /// <c>false</c>:作成できません。
        /// </returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override bool CanMakeSalesData(ISCMOrderAnswerRecord answerRecord)
        {
            const string METHOD_NAME = "CanMakeSalesData()";    // ログ用

            // 相場回答の場合、売上データの作成を行わない
            if (SCMDataHelper.IsMarketPrice(answerRecord))
            {
                #region <Log>

                EasyLogger.Write(
                    MY_NAME,
                    METHOD_NAME,
                    LogHelper.GetInfoMsg("相場回答であるため売上明細データを作成しませんでした。" + Environment.NewLine + SCMDataHelper.GetProfile(answerRecord))
                );

                #endregion // </Log>

                return false;
            }

            return true;
        }

        #region <売上データ>

        /// <summary>
        /// 伝票データの生成者を生成します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>伝票データの生成者</returns>
        protected override SCMSlipDataFactory CreateSlipDataFactory(ISCMOrderHeaderRecord headerRecord)
        {
            switch (headerRecord.AcptAnOdrStatus)
            {
                case (int)AcptAnOdrStatus.Sales:
                    return new SCMSalesSlipDataFactory(headerRecord, true);
                case (int)AcptAnOdrStatus.Order:
                    return new SCMOrderSlipDataFactory(headerRecord, true);
                case (int)AcptAnOdrStatus.Estimate:
                    return new SCMEstimateSlipDataFactory(headerRecord, true);
                default:
                    throw new ArgumentException("受注ステータスが不明です。[=" + headerRecord.AcptAnOdrStatus.ToString() + "]");
            }
        }

        /// <summary>
        /// 売上データを生成します。
        /// </summary>
        /// <returns>売上データ</returns>
        public override CustomSerializeArrayList CreateSalesData()
        {
            const string METHOD_NAME = "CreateSalesData()"; // ログ用

            // SCM受注明細データ(回答)と売上データを作成
            MakeAnswerDataAndSalesData();
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("SCM受注明細データ(回答)と売上データを作成：完了"));

            CustomSerializeArrayList salesData = new CustomSerializeArrayList();
            {
                bool canEntryCarMng = false;

                // 売上データ
                foreach (SCMSalesListEssence salesListEssence in SCMSalesListEssenceMap.Values)
                {
                    IList<SCMSalesListEssence> splitedEssence = salesListEssence.Split();

                    // ----- ADD 2011/11/12 ----- >>>>>
                    //// ----- ADD 2011/10/10 ----- >>>>>
                    //// PCCUOEの在庫確認の場合
                    //if (salesListEssence.SCMHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE
                    //    && salesListEssence.SCMHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry)
                    //{
                    //    splitedEssence.Add(salesListEssence);
                    //}
                    //// ----- ADD 2011/10/10 ----- <<<<<
                    // ----- ADD 2011/11/12 ----- <<<<<
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(splitedEssence.Count.ToString() + " 伝票に分割されました。"));

                    foreach (SCMSalesListEssence essence in splitedEssence)
                    {
                        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ---------------------------------->>>>>
                        essence.PriceCalculator = PriceCalculator;
                        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ----------------------------------<<<<<

                        CustomSerializeArrayList salesList = essence.CreateSalesList(out canEntryCarMng);
                        salesData.Add(salesList);
                    }

                    // 相場回答のみの場合
                    if (ListUtil.IsNullOrEmpty(splitedEssence))
                    {
                        _scmOrderDataWithSobaOnly = base.CreateSalesData(true);
                        _isSobaAnswerOnly = !ListUtil.IsNullOrEmpty(_scmOrderDataWithSobaOnly);
                    }
                }

                // リモート参照用パラメータ
                salesData.Add(CreateIOWriteCtrlOptWork(canEntryCarMng));
            }
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("売伝リモート用パラメータの構築：完了"));

            return salesData;
        }

        #endregion // </売上データ>

        #region <SCM受注データ>

        /// <summary>
        /// SCM受注データを回答用にコピーおよび編集します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>回答用に編集したSCM受注データのレコード</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override ISCMOrderHeaderRecord CopyAndEditSCMOrderHeaderRecord(ISCMOrderHeaderRecord headerRecord)
        {
            RepresentativeSCMHeaderRecord = headerRecord;

            UserSCMOrderHeaderRecord userHeaderRecord = base.CopyAndEditSCMOrderHeaderRecord(
                headerRecord
            ) as UserSCMOrderHeaderRecord;
            {
                // 036.回答作成区分(0:自動, 1:手動(Web), 2:手動(その他))
                userHeaderRecord.AnswerCreateDiv = GetAnswerCreateDiv(userHeaderRecord.AcptAnOdrStatus);
            }
            return userHeaderRecord;
        }

        #endregion // </SCM受注データ>

        #region <リモート参照用パラメータ>

        /// <summary>
        /// リモート参照用パラメータを生成します。
        /// </summary>
        /// <param name="canEntryCarMng">車両管理マスタに登録するフラグ</param>
        /// <returns>リモート参照用パラメータ</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override IOWriteCtrlOptWork CreateIOWriteCtrlOptWork(bool canEntryCarMng)
        {
            IOWriteCtrlOptWork ioWriteCtrlOpt = base.CreateIOWriteCtrlOptWork(canEntryCarMng);
            {
                ioWriteCtrlOpt.EnterpriseCode = GetRepresentativeEnterpriseCode();

                // 売上全体設定を取得
                SalesTtlSt salesTotalSetting = SalesTtlStDB.Find(
                    ioWriteCtrlOpt.EnterpriseCode,
                    GetRepresentativeSectionCode()
                );
                if (salesTotalSetting != null)
                {
                    ioWriteCtrlOpt.AcpOdrrAddUpRemDiv = salesTotalSetting.AcpOdrrAddUpRemDiv;   // 受注データ計上残区分(0:残す/1:残さない)
                    ioWriteCtrlOpt.ShipmAddUpRemDiv = salesTotalSetting.ShipmAddUpRemDiv;       // 出荷データ計上残区分(0:残す/1:残さない)
                    ioWriteCtrlOpt.EstimateAddUpRemDiv = salesTotalSetting.EstmateAddUpRemDiv;  // 見積データ計上残区分(0:残す/1:残さない)
                }
            }
            return ioWriteCtrlOpt;
        }

        #endregion  // </リモート参照用パラメータ>

        #endregion // </Override>
    }
}
