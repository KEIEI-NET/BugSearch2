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
// 作 成 日  2009/07/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優 
// 作 成 日  2010/04/21  修正内容 : 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517　夏野 駿希 
// 作 成 日  2010/07/07  修正内容 : 売上金額、売上消費税について自動連携値引きが適用されていない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/07/20  修正内容 : 自動回答の場合の端数処理が切り捨てになっていますの修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/08/15  修正内容 : Redmine#23307の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : wangqx
// 作 成 日  2011/09/29  修正内容 : Redmine#25685の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LIUSY
// 作 成 日  2011/10/10  修正内容 : Redmine#25754 25755の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上千加子
// 作 成 日  2012/07/13  修正内容 : SCM障害№161 売価未設定時の障害の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/01/18  修正内容 : 2013/03/13配信 SCM障害№10475対応 自動回答が遅い
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸　伸悟
// 作 成 日  2013/04/17  修正内容 : 2013/05/22配信 SCM障害№10520対応 キャンペーン値引き
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2013/08/07  修正内容 : PM-SCM仕掛一覧№10556対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 黄興貴
// 作 成 日  2013/04/17  修正内容 : 配信日なし分  Redmine#35271
//			                        No.184 ＰＭ側エントリー 対応
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
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/19  修正内容 : リコメンド対応 リコメンド発注時、自動連携値引・キャンペーン値引対応を行わない
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using System.Windows.Forms;
namespace Broadleaf.Application.Controller.Auto
{
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM全体設定マスタ

    /// <summary>
    /// 自動回答用売上リストの生成クラス
    /// </summary>
    public sealed class SCMAutoSalesListEssence : SCMSalesListEssence
    {
        private const string MY_NAME = "SCMAutoSalesListEssence";   // ログ用

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMAutoSalesListEssence() : base() { }

        #endregion // </Constructor>

        #region <Override>

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
        /// 売上リストを生成できるか判断します。
        /// </summary>
        /// <param name="scmHeaderRecord">SCM受注データのレコード</param>
        /// <returns>
        /// <c>true</c> :売上リストを生成できます。<br/>
        /// <c>false</c>:売上リストを生成できません。
        /// </returns>
        /// <see cref="SCMSalesListEssence"/>
        protected override bool CanCreateSalesList(ISCMOrderHeaderRecord scmHeaderRecord)
        {
            SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                scmHeaderRecord.InqOtherEpCd,
                scmHeaderRecord.InqOtherSecCd
            );
            if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
            if (foundTotalSetting != null)
            {
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                #region 削除(SCM改良の為)
                //if (foundTotalSetting.AutoAnswerDiv.Equals((int)AutoAnswerDiv.All))
                //{
                //    // --- Add 2011/08/15 duzg for Redmine#23307の対応 --->>>
                //    if (scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.PartAnswer))
                //    {
                //        return true;
                //    }
                //    // --- Add 2011/08/15 duzg for Redmine#23307の対応 ---<<<
                //    return scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
                //}
                //else
                //{
                //    return true;
                //}
                #endregion

                // 問合せ・発注種別が問合せの時
                if (scmHeaderRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Inquiry))
                {
                    // PCC全体設定の自動回答区分（問合せ）が「する（全て自動回答）」の時
                    if (foundTotalSetting.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.All))
                    {
                        // 回答区分が一部回答、又は回答完了の時、売上リスト生成が可能
                        if (scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.PartAnswer))
                        {
                            return true;
                        }
                        return scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
                    }
                    else
                    {
                        return true;
                    }
                }
                // 問合せ・発注種別が発注の時
                else if (scmHeaderRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Order))
                {
                    // PCC全体設定の自動回答区分（発注）が「する（全て自動回答）」の時
                    if (foundTotalSetting.AutoAnsOrderDiv.Equals((int)AutoAnsOrderDiv.All))
                    {
                        // 回答区分が一部回答、又は回答完了の時、売上リスト生成が可能
                        if (scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.PartAnswer))
                        {
                            return true;
                        }
                        return scmHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
                    }
                    else
                    {
                        return true;
                    }
                }
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            }
            return false;
        }

        /// <summary>
        /// 売上データを売上リストに追加します。
        /// </summary>
        /// <param name="salesList">売上リスト</param>
        /// <param name="salesSlip">売上データ</param>
        /// <see cref="SCMSalesListEssence"/>
        protected override void AddSalesSlipDataToSalesList(
            CustomSerializeArrayList salesList,
            SalesSlip salesSlip
        )
        {
            salesList.Add(CreateSalesSlipWork(salesSlip));
        }

        /// <summary>
        /// 売上明細データを売上リストに追加します。
        /// </summary>
        /// <remarks>
        /// 自動連携値引きとキャンペーンを反映し、SCM受注明細データ(回答)への展開も行います。
        /// </remarks>
        /// <param name="salesList">売上リスト</param>
        /// <param name="salesDetailDataList">売上明細データのリスト</param>
        /// <see cref="SCMSalesListEssence"/>
        /// <br>UpdateNote : 2011/07/20 譚洪 Redmine#22833 自動回答の場合の端数処理が切り捨てになっていますの修正</br>
        protected override void AddSalesDetailToSalesList(
            CustomSerializeArrayList salesList,
            IList<SalesDetail> salesDetailDataList
        )
        {
            const string METHOD_NAME = "AddSalesDetailToSalesList()";   // ログ用

            int salesRowNoCount = 0;
            ArrayList salesDetailWorkList = new ArrayList();

            // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // DEL 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ---------------------------------->>>>>
            //SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
            // DEL 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ----------------------------------<<<<<
            bool first = true;
            // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            foreach (SalesDetail salesDetail in salesDetailDataList)
            {
                bool isDiscountApply = false; // ADD 黄興貴 2013/04/17 for Redmine#35271
                // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                if (first)
                {
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("priceCalculator.SetCurrentSCMOrderData  開始"));
                    // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ---------------------------------->>>>>
                    //priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                    PriceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                    // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ----------------------------------<<<<<
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("priceCalculator.SetCurrentSCMOrderData  終了"));
                    first = false;
                }
                // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // DEL 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ---------->>>>>
                #region 削除コード

                //// 自動連携値引きとキャンペーンを反映
                //SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                //{
                //    priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                //    PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                //    if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                //    {
                //        salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.売上単価(税込, 浮動)
                //        salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.売上単価(税抜, 浮動)
                //    }
                //}

                #endregion // 削除コード
                // DEL 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ----------<<<<<
                // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ---------->>>>>

                                // SCM受注明細データ(回答)へ展開
                // SCM品目設定で価格を回答しないケースがあるので、単価がある場合のみ
                ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                // UPD 2015/01/19 リコメンド対応 --------------------------------------------------->>>>>
                //if (!IsEstimateAddingUp(salesDetail))
                // 見積計上とリコメンド発注時は自動連携値引、キャンペーン値引対象外
                if (!IsEstimateAddingUp(salesDetail) &&
                    !IsRecommend(salesDetail, answerRecord))
                // UPD 2015/01/19 リコメンド対応 ---------------------------------------------------<<<<<
                {
                    // 自動連携値引きとキャンペーンを反映
                    // DEL 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                    // DEL 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // DEL 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                        // DEL 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        PriceValue priceValue;

                        if (salesDetail.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && answerRecord.InqOrdDivCd == (int)InqOrdDivCd.Order)
                        {
                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ---------------------------------->>>>>
                            //priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail.TaxationDivCd, SalesSlipData.TotalAmountDispWayCd, salesDetail.SalesUnPrcTaxExcFl);
                            priceValue = PriceCalculator.CalcTaxExcAndTaxInc(salesDetail.TaxationDivCd, SalesSlipData.TotalAmountDispWayCd, salesDetail.SalesUnPrcTaxExcFl);
                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ----------------------------------<<<<<
                        }
                        else
                        {
                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ---------------------------------->>>>>
                            //priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                            priceValue = PriceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ----------------------------------<<<<<
                        }


                        if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                        {
                            salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.売上単価(税込, 浮動)
                            salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.売上単価(税抜, 浮動)
                            //>>> 2010/07/07 add
                            // --- DEL 2013/08/07 Y.Wakita ---------->>>>>
                            //salesDetail.SalesMoneyTaxInc = (long)(salesDetail.SalesUnPrcTaxIncFl * salesDetail.ShipmentCnt);    // FIXME:098.売上金額(税込み)   …算出
                            //salesDetail.SalesMoneyTaxExc = (long)(salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt);    // FIXME:099.売上金額(税抜き)   …算出
                            // --- DEL 2013/08/07 Y.Wakita ----------<<<<<
                            // --- ADD 2013/08/07 Y.Wakita ---------->>>>>
                            double salesMoneyTaxInc = 0;
                            double salesMoneyTaxExc = 0;

                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ---------------------------------->>>>>
                            //priceCalculator.CalcPrice(salesDetail.TaxationDivCd,
                            //                          (salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt),
                            //                          out salesMoneyTaxExc,
                            //                          out salesMoneyTaxInc);
                            PriceCalculator.CalcPrice(salesDetail.TaxationDivCd,
                                                      (salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt),
                                                      out salesMoneyTaxExc,
                                                      out salesMoneyTaxInc);
                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ----------------------------------<<<<<

                            salesDetail.SalesMoneyTaxInc = (long)salesMoneyTaxInc;    // FIXME:098.売上金額(税込み)   …算出
                            salesDetail.SalesMoneyTaxExc = (long)salesMoneyTaxExc;    // FIXME:099.売上金額(税抜き)   …算出
                            // --- ADD 2013/08/07 Y.Wakita ----------<<<<<
                            salesDetail.SalesPriceConsTax = salesDetail.SalesMoneyTaxInc - salesDetail.SalesMoneyTaxExc;        // 売上金額消費税額
                            //<<< 2010/07/07 add
                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ---------------------------------->>>>>
                            //isDiscountApply = priceCalculator.IsDiscountApply; // ADD 黄興貴 2013/04/17 for Redmine#35271
                            isDiscountApply = PriceCalculator.IsDiscountApply; // ADD 黄興貴 2013/04/17 for Redmine#35271
                            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ----------------------------------<<<<<
                        }
                    }
                }
                else
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("自動連携値引きとキャンペーンは反映しません。∵見積で回答済み商品です"));

                    #endregion // </Log>
                }
                // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ----------<<<<<
                SalesDetailWork salesDetailWork = CreateSalesDetailWork(salesDetail);
                {
                    salesDetailWork.SalesRowNo = ++salesRowNoCount; // 012.売上行番号
                    salesDetailWork.SalesSlipDtlNum = 0;            // 018.売上明細通番
                }
                // --- ADD 黄興貴 2013/04/17 for Redmine#35271 --------->>>>>
                if (isDiscountApply)
                {
                    salesDetailWork.SalesRate = 0.0;
                }
                // --- ADD 黄興貴 2013/04/17 for Redmine#35271 ---------<<<<<
                salesDetailWorkList.Add(salesDetailWork);

                // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                #region 削除
                //// ----- ADD 2011/09/29 ----- >>>>>
                //if (salesDetail.AcceptOrOrderKind != (int)EnumAcceptOrOrderKind.PCCUOE)
                //{
                //// ----- ADD 2011/09/29 ----- <<<<<
                //    // UPD 2012/07/13 SCM障害No.161 --------------------------------------->>>>>
                //    //if (answerRecord.UnitPrice >= 0)
                //    if (answerRecord.UnitPrice > 0)
                //    // UPD 2012/07/13 SCM障害No.161 ---------------------------------------<<<<<
                //    {
                //        #region <Log>

                //        string msg = string.Format(
                //            "価格の最終結果を反映します。回答データ.単価={0} → {1}（拠点：{2}, メーカー：{3}, BL：{4}, 品番：{5}）",
                //            answerRecord.UnitPrice,
                //            salesDetail.SalesUnPrcTaxIncFl,
                //            answerRecord.InqOtherSecCd,
                //            answerRecord.GoodsMakerCd,
                //            answerRecord.BLGoodsCode,
                //            answerRecord.GoodsNo
                //        );
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //        #endregion // </Log>
                //        // -----  UPD 2011/07/20  ------------ >>>>>
                //        //answerRecord.UnitPrice = (long)salesDetail.SalesUnPrcTaxExcFl;  // 売上単価(税抜, 浮動)
                //        answerRecord.UnitPrice = (long)Math.Round(salesDetail.SalesUnPrcTaxExcFl, 0, MidpointRounding.AwayFromZero);
                //        // -----  UPD 2011/07/20  ------------ <<<<<
                //    }
                //    else
                //    {
                //        #region <Log>

                //        string msg = string.Format(
                //            "SCM品目設定で「納期」または「しない」です。回答データ.単価={0} → 0（拠点：{1}, メーカー：{2}, BL：{3}, 品番：{4}）",
                //            salesDetail.SalesUnPrcTaxIncFl,
                //            answerRecord.InqOtherSecCd,
                //            answerRecord.GoodsMakerCd,
                //            answerRecord.BLGoodsCode,
                //            answerRecord.GoodsNo
                //        );
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //        #endregion // </Log>

                //        answerRecord.UnitPrice = 0; // SCM品目設定で価格を回答しないケース
                //    }
                //// ----- ADD 2011/09/29 ----- >>>>>
                //}
                //// ----- ADD 2011/09/29 ----- <<<<<

                //// ----- ADD 2011/10/10 ----- >>>>>
                ////PCCUOEの場合
                //else
                //{
                //    if (answerRecord.UnitPrice > 0)
                //    {
                #endregion
                // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                string msg = string.Format(
                    "価格の最終結果を反映します。回答データ.単価={0} → {1}（拠点：{2}, メーカー：{3}, BL：{4}, 品番：{5}）",
                    answerRecord.UnitPrice,
                    salesDetail.SalesUnPrcTaxIncFl,
                    answerRecord.InqOtherSecCd,
                    answerRecord.GoodsMakerCd,
                    answerRecord.BLGoodsCode,
                    answerRecord.GoodsNo
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                answerRecord.UnitPrice = (long)Math.Round(salesDetail.SalesUnPrcTaxExcFl, 0, MidpointRounding.AwayFromZero);
                // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //    }
                //}
                //// ----- ADD 2011/10/10 ----- <<<<<
                // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
            salesList.Add(salesDetailWorkList);
        }

        /// <summary>
        /// 分割用のインスタンスを生成します。
        /// </summary>
        /// <returns>分割用のインスタンス</returns>
        /// <see cref="SCMSalesListEssence"/>
        protected override SCMSalesListEssence CreateSplitedEssence()
        {
            return new SCMAutoSalesListEssence();
        }

        #endregion // </Override>
    }
}
