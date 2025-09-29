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
// 作 成 日  2009/06/09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2011/06/28  修正内容 : キャンペーン管理
//                               :   キャンペーン管理マスタの変更に伴う変更。
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/15  修正内容 : Redmine#22829 自動回答、手動回答の両方で売価率の算出方法が不正の対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/20  修正内容 : Redmine#22829「掛率マスタ/売価率」と「キャンペーン/売価率」が両方ヒットする場合、明細部も水色になりますの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 修 正 日  2011/09/19  修正内容 : Redmine#25267 定価（税込，浮動）対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/09/22  修正内容 : Redmine#25500 PCCUOE／PM側　自動回答 キャンペーン値引率が設定されている場合の売単価不正の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高川　悟
// 修 正 日  2012/10/10  修正内容 : SCM障害改良No10368対応 Redmine#25500の修正を元に戻す
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/01/18  修正内容 : 2013/03/13配信 SCM障害№10475対応 自動回答が遅い
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/10/01  修正内容 : 2013/04/10配信分 SCM障害№27 自動連携値引は自動回答時のみ適用
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2013/04/14  修正内容 : 2013/04/17配信分 10517:自動連携値引が当たった場合、端数処理が正常に処理されていません。の対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 作 成 日  2013/08/07  修正内容 : Redmine#39620(旧#128)対応
//                                  自社設定の掛率優先順位を参照するように修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 黄興貴
// 作 成 日  2013/04/17  修正内容 : 配信日なし分  Redmine#35271
//			                        No.184 ＰＭ側エントリー 対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/10/25  修正内容 : 201311XX配信予定システムテスト障害№13,14対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/05  修正内容 : SCM仕掛一覧№10627対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2014/02/05  修正内容 : 仕掛一覧№10631 自動回答速度改善 掛率マスタキャッシュ
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
// 管理番号              作成担当 : duzg
// 作 成 日  2014/08/11  修正内容 : 検証／総合テスト障害No.5
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/03/18  修正内容 : SCM高速化 メーカー希望小売価格対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/04/01  修正内容 : SCM高速化 メーカー希望小売価格対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委
// 修 正 日  2020/05/15  修正内容 : PMKOBETSU-3932 BLP障害（ログ強化）
//                                : 既存コードのログ出力強化を行う
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SalesProcMoneyServer  = SingletonInstance<SalesProcMoneyAgent>;   // 売上金額処理区分マスタ
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM全体設定マスタ

    /// <summary>
    /// 価格算出クラス
    /// </summary>
    public sealed class SCMPriceCalculator
    {
        private const string MY_NAME = "SCMPriceCalculator";    // ログ用
        /// <summary>キャンペーン管理リスト</summary>
        private CampaignObjGoodsSt campaignMng;      // ADD 2011/07/15

        // -------- ADD 黄興貴 2013/04/17 for Redmine#35271 ------ >>>>>
        /// <summary>実際値引適用フラグ</summary>
        private bool _isDiscountApply = false; // 実際値引適用があったか

        /// <summary>実際値引適用フラグを取得します。</summary>
        public bool IsDiscountApply
        {
            get { return this._isDiscountApply; }
        }
        // -------- ADD 黄興貴 2013/04/17 for Redmine#35271 ------ <<<<<

        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ---------------------------------->>>>>
        //CampaignObjGoodsStAcs campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs;
        private CampaignObjGoodsStAcs CampaignObjGoodsStAcs
        {
            get
            {
                if (this._campaignObjGoodsStAcs == null)
                {
                    this._campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
                }
                return this._campaignObjGoodsStAcs;
            }
        }
        // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ----------------------------------<<<<<
        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #region <品番検索>

        /// <summary>品番検索アクセサ</summary>
        private GoodsAcs _goodsAccesser;
        /// <summary>品番検索アクセサを取得します。</summary>
        private GoodsAcs GoodsAccesser
        {
            get
            {
                if (_goodsAccesser == null)
                {
                    _goodsAccesser = new GoodsAcs(LoginSectionCode);
                    {
                        string msg = string.Empty;
                        _goodsAccesser.SearchInitial(CurrentEnterpriseCode, LoginSectionCode, out msg);
                    }
                }
                return _goodsAccesser;
            }
        }

        #endregion // </品番検索>

        #region <価格系算出>

        /// <summary>価格系算出</summary>
        private CalculatorAgent _calculator;
        /// <summary>価格系算出を取得します。</summary>
        private CalculatorAgent Calculator
        {
            get
            {
                if (_calculator == null)
                {
                    _calculator = new CalculatorAgent();
                }
                return _calculator;
            }
        }

        #endregion // </価格系算出>

        #region <現在のSCM受注データ>

        /// <summary>現在の得意先コード</summary>
        private int _currentCustomerCode;
        /// <summary>現在の得意先コードを取得または設定します。</summary>
        private int CurrentCustomerCode { get { return _currentCustomerCode; } }

        /// <summary>現在のSCM受注明細データ(問合せ・発注)</summary>
        private ISCMOrderDetailRecord _currentDetailRecord;
        /// <summary>現在のSCM受注明細データ(問合せ・発注)を取得または設定します。</summary>
        private ISCMOrderDetailRecord CurrentDetailRecord { get { return _currentDetailRecord; } }

        /// <summary>
        /// 現在のSCM受注データを設定します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            ISCMOrderDetailRecord detailRecord
        )
        {
            _currentCustomerCode = customerCode;
            _currentDetailRecord = detailRecord;
            Calculator.CustomerDB.TakeCustomerInfo(_currentDetailRecord.InqOtherEpCd, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);

        }

        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
        /// <summary>
        /// 現在のSCM受注データを設定します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            ISCMOrderDetailRecord detailRecord,
            ISCMOrderHeaderRecord headerRecord
        )
        {
            _currentCustomerCode = customerCode;
            _currentDetailRecord = detailRecord;
            Calculator.CustomerDB.TakeCustomerInfo(_currentDetailRecord.InqOtherEpCd, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
            _currentTaxRateSet.TaxRateDate = headerRecord.InquiryDate;
            _currentTaxRateSet.CancelDiv = headerRecord.CancelDiv;
        }
        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<

        /// <summary>
        /// 現在のSCM受注データを設定します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="salesDetail">売上明細データ</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            SalesDetail salesDetail
        )
        {
            _currentEnterpriseCode  = salesDetail.EnterpriseCode;
            _loginSectionCode       = salesDetail.SectionCode;
            _currentCustomerCode    = customerCode;
            Calculator.CustomerDB.TakeCustomerInfo(_currentEnterpriseCode, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
            // ADD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
            _currentTaxRateSet.CancelDiv = 0;
            _currentTaxRateSet.TaxRateDate = salesDetail.SalesDate;
            // ADD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
            _currentDetailRecord = null;
        }

        // ADD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
        /// <summary>
        /// 現在のSCM受注データを設定します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="cancelDiv">キャンセル区分</param>
        /// <param name="inquryDate">問合せ日</param>
        public void SetCurrentSCMOrderData(
            int customerCode,
            SalesDetail salesDetail,
            short cancelDiv,
            DateTime inquryDate
        )
        {
            _currentEnterpriseCode = salesDetail.EnterpriseCode;
            _loginSectionCode = salesDetail.SectionCode;
            _currentCustomerCode = customerCode;
            Calculator.CustomerDB.TakeCustomerInfo(_currentEnterpriseCode, _currentCustomerCode);

            _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
            _currentTaxRateSet.CancelDiv = cancelDiv;
            _currentTaxRateSet.TaxRateDate = inquryDate;
            _currentDetailRecord = null;
        }
        // ADD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<

        /// <summary>現在の企業コード</summary>
        private string _currentEnterpriseCode;
        /// <summary>
        /// 現在の企業コード取得します。
        /// </summary>
        private string CurrentEnterpriseCode
        {
            get
            {
                if (CurrentDetailRecord != null)
                {
                    return CurrentDetailRecord.InqOtherEpCd;
                }
                else
                {
                    return _currentEnterpriseCode;
                }
            }
        }

        /// <summary>ログイン拠点コード</summary>
        private string _loginSectionCode;
        /// <summary>
        /// ログイン拠点コードを取得します。
        /// </summary>
        private string LoginSectionCode
        {
            get
            {
                return CurrentDetailRecord != null ? CurrentDetailRecord.InqOtherSecCd : _loginSectionCode;
            }
        }

        /// <summary>
        /// 現在の得意先情報を取得します。
        /// </summary>
        private CustomerInfo CurrentCustomerInfo
        {
            get
            {
                if (Calculator.CustomerDB.CustomerInfoMap.ContainsKey(CurrentCustomerCode))
                {
                    return Calculator.CustomerDB.CustomerInfoMap[CurrentCustomerCode];
                }
                else
                {
                    Calculator.CustomerDB.TakeCustomerInfo(CurrentEnterpriseCode, CurrentCustomerCode);
                    if (Calculator.CustomerDB.CustomerInfoMap.ContainsKey(CurrentCustomerCode))
                    {
                        return Calculator.CustomerDB.CustomerInfoMap[CurrentCustomerCode];
                    }
                    else
                    {
                        return new CustomerInfo();
                    }
                }
            }
        }

        /// <summary>現在の税率設定マスタ</summary>
        private TaxRateSetAgent _currentTaxRateSet;
        /// <summary>現在の税率設定マスタを取得します。</summary>
        private TaxRateSetAgent CurrentTaxRateSet
        {
            get
            {
                if (_currentTaxRateSet == null)
                {
                    _currentTaxRateSet = new TaxRateSetAgent(CurrentEnterpriseCode);
                }
                return _currentTaxRateSet;
            }
        }

        /// <summary>
        /// 現在の得意先掛率グループを取得します。
        /// </summary>
        private List<CustRateGroup> CurrentCustomerRateGroupList
        {
            get
            {
                if (Calculator.CustomerDB.CustomerRateGroupMap.ContainsKey(CurrentCustomerCode))
                {
                    return Calculator.CustomerDB.CustomerRateGroupMap[CurrentCustomerCode];
                }
                else
                {
                    Calculator.CustomerDB.TakeCustomerInfo(CurrentEnterpriseCode, CurrentCustomerCode);
                    if (Calculator.CustomerDB.CustomerRateGroupMap.ContainsKey(CurrentCustomerCode))
                    {
                        return Calculator.CustomerDB.CustomerRateGroupMap[CurrentCustomerCode];
                    }
                    else
                    {
                        return new List<CustRateGroup>();
                    }
                }
            }
        }

        /// <summary>
        /// 現在のSCM全体設定を取得します。
        /// </summary>
        private SCMTtlSt CurrentSCMTotalSetting
        {
            get
            {
                SCMTtlSt scmTtlSt = SCMTotalSettingServer.Singleton.Instance.Find(CurrentEnterpriseCode, LoginSectionCode);
                if (!SCMDataHelper.IsAvailableRecord(scmTtlSt))
                {
                    scmTtlSt = null;
                }
                return scmTtlSt;
            }
        }

        #endregion // </現在のSCM受注データ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMPriceCalculator() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="goodsAccesser">品番検索アクセサ</param>
        public SCMPriceCalculator(GoodsAcs goodsAccesser)
        {
            _goodsAccesser = goodsAccesser;
        }

        #endregion // </Constructor>

        /// <summary>
        /// 単価算出処理（PartsInfoDataSet.CalculateUnitPrice += デリゲートに使用）
        /// </summary>
        /// <remarks>MAHNB01012AB.cs l.1792 SalesSlipInputAcs.CalculateUnitPrice() を参考</remarks>
        /// <param name="goodsUnitDataList">商品連結データのリスト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果のリスト</param>
        public void CalculateUnitPrice(
            List<GoodsUnitData> goodsUnitDataList,
            out List<UnitPriceCalcRet> unitPriceCalcRetList
        )
        {
            #region <Guard Phrase>

            unitPriceCalcRetList = null;

            if ((goodsUnitDataList == null) || (goodsUnitDataList.Count.Equals(0))) return;

            #endregion // </Guard Phrase>
            
            SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false, LoginSectionCode);

            //-----------------------------------------------------------------------------
            // 単価情報取得
            //-----------------------------------------------------------------------------
            unitPriceCalcRetList = CalclationUnitPrice(goodsUnitDataList);
        }

        #region <単価算出処理用>

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <remarks>MAHNB01012AD.cs l.1792 SalesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst() を参考</remarks>
        /// <param name="goodsUnitDataList">商品連結データのリスト</param>
        /// <param name="isSettingSupplier">???フラグ</param>
        /// <param name="sectionCode">拠点コード</param>
        private void SettingGoodsUnitDataListFromVariousMst(
            ref List<GoodsUnitData> goodsUnitDataList,
            bool isSettingSupplier,
            string sectionCode
        )
        {
            const string METHOD_NAME = "SettingGoodsUnitDataListFromVariousMst()";  // ログ用

            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();

                #region <Log>

                string msg = string.Format(
                    "商品連結データの不足情報で設定した拠点コード=「{0}」→「{1}」",
                    retGoodsUnitData.SectionCode,
                    sectionCode
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                retGoodsUnitData.SectionCode = sectionCode;
                EasyLogger.Write(MY_NAME, METHOD_NAME, "商品連結データ不足情報設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                EasyLogger.Write(MY_NAME, METHOD_NAME, "商品連結データ不足情報設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;

            #region <Log>

            string info = "不足情報の設定結果" + Environment.NewLine + SCMDataHelper.GetProfile(goodsUnitDataList);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(info));

            #endregion // </Log>
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <remarks>MAHNB01012AD.cs l.1800 SalesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst() を参考</remarks>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="isSettingSupplier">???フラグ</param>
        private void SettingGoodsUnitDataListFromVariousMst(
            ref GoodsUnitData goodsUnitData,
            bool isSettingSupplier
        )
        {
            //GoodsAccesser.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, (isSettingSupplier ? 0 : 1));// Del 2014/08/11 duzg For 検証／総合テスト障害No.5
            GoodsAccesser.SettingGoodsUnitDataFromVariousMst2(ref goodsUnitData, (isSettingSupplier ? 0 : 1));// Add 2014/08/11 duzg For 検証／総合テスト障害No.5
        }

        /// <summary>
        /// 単価算出モジュールにより、単価を算出します。
        /// </summary>
        /// <remarks>MAHNB01012AB.cs l.9609 SalesSlipInputAcs.CalclationUnitPrice() を参考</remarks>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(List<GoodsUnitData> goodsUnitDataList)
        {
            string enterpriseCode   = CurrentEnterpriseCode;    // 企業コード
            string sectionCode      = LoginSectionCode;         // 拠点コード

            // 仕入単価端数処理コードディクショナリ
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();

            // 仕入消費税端数処理コードディクショナリ
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();

            // 売上単価端数処理コード(得意先マスタより取得)
            int salesUnPrcFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                enterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            );

            // 売上消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                enterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );

            // 仕入単価端数処理コード
            int stockUnPrcFrcProcCd = 0;
            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = 0;

            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((!goodsUnitData.GoodsMakerCd.Equals(0)) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                    {
                        unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BLコード
                        unitPriceCalcParam.BLGoodsName = goodsUnitData.BLGoodsFullName;                 // BLコード名称
                        unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BLグループコード
                        unitPriceCalcParam.CountFl = 0;                                                 // 数量
                        unitPriceCalcParam.CustomerCode = CurrentCustomerCode;                          // 得意先コード
                        unitPriceCalcParam.CustRateGrpCode = GetCustomerRateGroupCode(goodsUnitData.GoodsMakerCd); // 得意先掛率グループコード
                        unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // メーカーコード
                        unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 商品番号
                        unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // 商品掛率グループコード
                        unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
                        unitPriceCalcParam.PriceApplyDate = DateTime.Today; 　　　　　                  // 適用日
                        unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // 売上消費税端数処理コード
                        unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // 売上単価端数処理コード
                        unitPriceCalcParam.SectionCode = sectionCode;                                   // 拠点コード
                        if (stockCnsTaxFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                        {
                            stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[goodsUnitData.SupplierCd];   // 仕入消費税端数処理コード(ディクショナリか仕入先マスタから取得)
                        }
                        else
                        {
                            stockCnsTaxFrcProcCd = Calculator.SupplierDB.RealAccesser.GetStockFractionProcCd(
                                enterpriseCode,
                                goodsUnitData.SupplierCd,
                                SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd
                            );
                            stockCnsTaxFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                        }
                        unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;

                        if (stockUnPrcFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                        {
                            stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[goodsUnitData.SupplierCd];     // 仕入単価端数処理コード(ディクショナリか仕入先マスタから取得)
                        }
                        else
                        {
                            stockUnPrcFrcProcCd = Calculator.SupplierDB.RealAccesser.GetStockFractionProcCd(
                                enterpriseCode,
                                goodsUnitData.SupplierCd,
                                SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd
                            );
                            stockUnPrcFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                        }
                        unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // 仕入単価端数処理コード
                        unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                       // 仕入先コード
                        unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
                        //unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // HACK:税率
                        //unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // HACK:総額表示方法区分
                        //unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// HACK:総額表示掛率適用区分
                        //unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // HACK:消費税転嫁方式
                        // -- ADD 2011/09/19   ------ >>>>>>
                        // DEL 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>> 
                        //// 得意先情報
                        //CustomerInfo customerInfo = Calculator.CustomerDB.CustomerInfoMap[this._currentCustomerCode];
                        //if (customerInfo != null)
                        //{
                        //    unitPriceCalcParam.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; // 072.消費税転嫁方式…得意先マスタ or 税率設定マスタ
                        //}
                        // DEL 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 --------------------------------<<<<< 

                        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                        //TaxRateSetAgent taxRateSet = new TaxRateSetAgent(enterpriseCode);
                        //{
                        //    unitPriceCalcParam.TaxRate = taxRateSet.TaxRateOfNow;    // 073.消費税税率…税率設定マスタ
                        //}
                        TaxRateSetAgent taxRateSet = new TaxRateSetAgent(enterpriseCode);
                        if (CurrentTaxRateSet != null)
                        {
                            unitPriceCalcParam.TaxRate = (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow; // 073.消費税税率…税率設定マスタ
                        }
                        else
                        {
                            unitPriceCalcParam.TaxRate = taxRateSet.TaxRateOfNow;    // 073.消費税税率…税率設定マスタ
                        }
                        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<

                        // DEL 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
                        #region 旧ソース
                        //// ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>> 
                        //CustomerInfo claim;
                        //// 得意先情報取得
                        //CustomerInfo customerInfo = Calculator.CustomerDB.CustomerInfoMap[this._currentCustomerCode];
                        //if (customerInfo != null)
                        //{
                        //    // 請求先情報取得
                        //    int status = Calculator.CustomerDB.RealAccesser.ReadDBData(Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0, customerInfo.EnterpriseCode, customerInfo.ClaimCode, true, false, out claim);
                        //    if (status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        claim = new CustomerInfo();
                        //    }

                        //    if (claim != null)
                        //    {
                        //        unitPriceCalcParam.ConsTaxLayMethod = (claim.CustCTaXLayRefCd == 0) ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                        //    }
                        //}
                        //// ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 --------------------------------<<<<< 
                        #endregion
                        // DEL 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<
                        // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
                        CustomerInfo claim = Calculator.ClaimInfo(this._currentCustomerCode);
                        if (claim != null)
                        {
                            unitPriceCalcParam.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                        }
                        else
                        {
                            // 請求先が取得できない場合は、マスタの税率設定をセット
                            unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;
                        }
                        // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

                        unitPriceCalcParam.TotalAmountDispWayCd = 0; // 総額表示方法区分
                        unitPriceCalcParam.TtlAmntDspRateDivCd = 0;	// 総額表示掛率適用区分
                        // -- ADD 2011/09/19   ------ <<<<<<
                    }
                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            {
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------>>>>>
                Calculator.RealAccesser.RatePriorityDiv = Calculator.GetCompanyInf(enterpriseCode).RatePriorityDiv; //自社設定･掛率優先順位
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------<<<<<

                // UPD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ ------->>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //Calculator.RealAccesser.CalculateSalesRelevanceUnitPrice(
                //    unitPriceCalcParamList,
                //    tempGoodsUnitDataList,
                //    out unitPriceCalcRetList
                //);
                #endregion
                Calculator.RealAccesser.CalculateSalesRelevanceUnitPriceRateCache(
                    unitPriceCalcParamList,
                    tempGoodsUnitDataList,
                    out unitPriceCalcRetList
                );
                // UPD 2014/02/05 №10631 吉岡 掛率マスタキャッシュ -------<<<<<<<<<<<<<<<<<<<
            }
            return unitPriceCalcRetList;
        }

        /// <summary>純正メーカー最大コード</summary>
        public const int PURE_GOODS_MAKER_CODE_MAX = 1000;

        /// <summary>
        /// 得意先掛率グループコード取得処理
        /// </summary>
        /// <remarks>MAHNB01012AB.cs l.9693 SalesSlipInputAcs.GetCustRateGroupCode() を参考</remarks>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <returns>得意先掛率グループコード</returns>
        private int GetCustomerRateGroupCode(int goodsMakerCode)
        {
            int pureCode = (goodsMakerCode <= PURE_GOODS_MAKER_CODE_MAX ? 0 : 1);   // 0:純正 1:優良

            // 単独キー
            CustRateGroup foundCustomerRateGroup = CurrentCustomerRateGroupList.Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(goodsMakerCode) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;

            // 共通キー
            foundCustomerRateGroup = CurrentCustomerRateGroupList.Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(0) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;

            return 0;
        }

        #endregion // </単価算出処理用>

        /// <summary>
        /// 価格計算処理（PartsInfoDataSet.CalculatePrice += デリゲートに使用）
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcPrice() 1816行目より移植</remarks>
        /// <param name="taxationCode"></param>
        /// <param name="unitPrice"></param>
        /// <param name="priceTaxExc"></param>
        /// <param name="priceTaxInc"></param>
        public void CalcPrice(
            int taxationCode,
            double unitPrice,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            // 消費税端数処理コード
            int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );
            // DEL 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            #region 旧ソース
            //// ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>>
            //// 消費税転嫁方式取得
            //CustomerInfo claim = new CustomerInfo();
            //// 請求先情報取得
            //int status = Calculator.CustomerDB.RealAccesser.ReadDBData(Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0, CurrentCustomerInfo.EnterpriseCode, CurrentCustomerInfo.ClaimCode, true, false, out claim);
            //int ConsTaxLayMethod = (claim.CustCTaXLayRefCd == 0) ? CurrentTaxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;  
            //// ADD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 --------------------------------<<<<<
            #endregion
            // DEL 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            CustomerInfo claim = Calculator.ClaimInfo(CurrentCustomerCode);
            int ConsTaxLayMethod = 0;
            if (claim != null)
            {
                ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? CurrentTaxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
            }
            else
            {
                // 請求先が取得できない場合は、マスタの税率設定をセット
                ConsTaxLayMethod = CurrentTaxRateSet.ConsTaxLayMethod;
            }
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<


            CalclatePrice(
                unitPrice,
                taxationCode,
                0,                                      // 総額表示方法区分 …0:総額表示しない(税抜き)
                // UPD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 -------------------------------->>>>>
                //CurrentCustomerInfo.ConsTaxLayMethod,   // 消費税転嫁方式   …得意先マスタor税率設定マスタより
                ConsTaxLayMethod,   // 消費税転嫁方式   …得意先マスタor税率設定マスタより
                // UPD 2013/10/25 201311XX配信予定システムテスト障害№13,14対応 --------------------------------<<<<<
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                //CurrentTaxRateSet.TaxRateOfNow,
                (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                salesCnsTaxFrcProcCd,
                out priceTaxExc,
                out priceTaxInc
            );
        }

        #region <価格計算処理用>

        /// <summary>
        /// 対象価格から、税抜金額、税込金額、表示金額を計算します
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalclatePrice() 1834行目より移植</remarks>
        /// <param name="targetPrice">対象価格</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="taxRate">税率</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="priceTaxExc">税抜金額</param>
        /// <param name="priceTaxInc">税込金額</param>
        private void CalclatePrice(
            double targetPrice,
            int taxationCode,
            int totalAmountDispWayCd,
            int consTaxLayMethod,
            double taxRate,
            int salesCnsTaxFrcProcCd,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (targetPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            GetSalesFractionProcInfo(
                (int)SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesCnsTaxFrcProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );

            // 総額表示しない
            if (totalAmountDispWayCd == 0)
            {
                // 課税区分「非課税」、転嫁方式：非課税
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税（内税）」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                }
            }
            // 総額表示する
            else
            {
                // 課税区分「非課税」、転嫁方式：非課税
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税（内税）」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
            }
        }

        ///// <summary>端数処理対象金額区分（売上金額）</summary>
        //public const int ctFracProcMoneyDiv_SalesMoney = 0;
        ///// <summary>端数処理対象金額区分（消費税）</summary>
        //public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        public const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        ///// <summary>端数処理対象金額区分（原価単価）</summary>
        //public const int ctFracProcMoneyDiv_SalesUnitCost = 2;
        ///// <summary>端数処理対象金額区分（原価金額）</summary>
        //public const int ctFracProcMoneyDiv_Cost = 0;

        /// <summary>売上金額処理区分リスト</summary>
        private List<SalesProcMoney> _salesProcMoneyList;
        /// <summary>売上金額処理区分リストを取得します。</summary>
        private List<SalesProcMoney> SalesProcMoneyList
        {
            get
            {
                if (_salesProcMoneyList == null)
                {
                    _salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(
                        CurrentEnterpriseCode
                    );
                }
                return _salesProcMoneyList;
            }
        }

        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <remarks>
        /// MAHNB01012AD.cs SalesSlipInputInitDataAcs.GetSalesFractionProcInfo() 1592行目より移植
        /// </remarks>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetSalesFractionProcInfo(
            int fracProcMoneyDiv,
            int fractionProcCode,
            double targetPrice,
            out double fractionProcUnit,
            out int fractionProcCd
        )
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = SalesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            
            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        /// <remarks>
        /// MAHNB01012AD.cs SalesSlipInputInitDataAcs 1661行目より移植
        /// </remarks>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        #endregion // </価格計算処理用>

        // --- UPD m.suzuki 2011/06/28 ---------->>>>>
        ///// <summary>
        ///// キャンペーン適用処理（PartsInfoDataSet.ReflectCampaign += デリゲートに使用）
        ///// </summary>
        ///// <remarks>MAHNB01012AC.cs SalesSlipInputAcs.ReflectAutoDiscount() 14987行目より移植</remarks>
        ///// <param name="taxationCode"></param>
        ///// <param name="customerCode"></param>
        ///// <param name="goodsMGroup"></param>
        ///// <param name="blGoodsCode"></param>
        ///// <param name="goodsMakerCd"></param>
        ///// <param name="goodsNo"></param>
        ///// <param name="applyDate"></param>
        ///// <param name="price"></param>
        //public void ReflectCampaign(
        //    int taxationCode,
        //    int customerCode,
        //    int goodsMGroup,
        //    int blGoodsCode,
        //    int goodsMakerCd,
        //    string goodsNo,
        //    DateTime applyDate,
        //    ref double price
        //)
        /// <summary>
        /// キャンペーン適用処理（PartsInfoDataSet.ReflectCampaign += デリゲートに使用）
        /// </summary>
        /// <remarks>MAHNB01012AC.cs SalesSlipInputAcs.ReflectAutoDiscount()に対応</remarks>
        /// <param name="taxationCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="blGroupCode"></param>
        /// <param name="salesCode"></param>
        /// <param name="applyDate"></param>
        /// <param name="price"></param>
        public void ReflectCampaign(
            int taxationCode,
            int customerCode,
            int blGoodsCode,
            int goodsMakerCd,
            string goodsNo,
            int blGroupCode,
            int salesCode,
            DateTime applyDate,
            ref double price
        )
        // --- UPD m.suzuki 2011/06/28 ----------<<<<<
        {
            const string METHOD_NAME = "ReflectCampaign()"; // ログ用

            // --- UPD m.suzuki 2011/06/28 ---------->>>>>
            //CampaignMngAcs campaignMngAcs = new CampaignMngAcs( CurrentEnterpriseCode, LoginSectionCode );
            //CampaignMng campaignMng;
            //campaignMngAcs.GetRatePriceOfCampaignMng(
            //    out campaignMng,
            //    CurrentEnterpriseCode,
            //    LoginSectionCode,
            //    customerCode,
            //    goodsMakerCd,
            //    goodsMGroup,
            //    blGoodsCode,
            //    goodsNo,
            //    applyDate
            //);

            // DEL 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // CampaignObjGoodsStAcs campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            // DEL 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //CampaignObjGoodsSt campaignMng;   // DEL 2011/07/15

            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ---------------------------------->>>>>
            //int status = campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(
            //    out campaignMng,
            //    CurrentEnterpriseCode,
            //    LoginSectionCode,
            //    customerCode,
            //    goodsMakerCd,
            //    blGroupCode,
            //    blGoodsCode,
            //    salesCode,
            //    goodsNo,
            //    applyDate 
            //);
            int status = CampaignObjGoodsStAcs.GetRatePriceOfCampaignMng(
                out campaignMng,
                CurrentEnterpriseCode,
                LoginSectionCode,
                customerCode,
                goodsMakerCd,
                blGroupCode,
                blGoodsCode,
                salesCode,
                goodsNo,
                applyDate
            );
            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応） ----------------------------------<<<<<
            // --- UPD m.suzuki 2011/06/28 ----------<<<<<

            if (campaignMng == null)
            {
                #region <Log>
                // --- UPD m.suzuki 2011/06/28 ---------->>>>>
                //SCMDataHelper.DumpToLog(campaignMngAcs.CachedCampaignMngDic);   // 調査用にダンプ
                //
                //string msg = string.Format(
                //    "キャンペーン適用処理：キャンペーン管理がnullです。（企業：{0}, 拠点：{1}, 得意先：{2}, メーカー：{3}, 中分類：{4}, BL：{5}, 品番：{6}, 適用日：{7}）",
                //    CurrentEnterpriseCode,
                //    LoginSectionCode,
                //    customerCode,
                //    goodsMakerCd,
                //    goodsMGroup,
                //    blGoodsCode,
                //    goodsNo,
                //    applyDate
                //);
                //msg += Environment.NewLine + "\tキャンペーン管理の取得状況：" + campaignMngAcs.StatusOfResult;
                //EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                string msg = string.Format(
                    "キャンペーン適用処理：キャンペーン管理がnullです。（企業：{0}, 拠点：{1}, 得意先：{2}, メーカー：{3}, グループ : {4}, BL：{5}, 販売区分 : {6}, 品番：{7}, 適用日：{8}）",
                    CurrentEnterpriseCode,
                    LoginSectionCode,
                    customerCode,
                    goodsMakerCd,
                    blGroupCode,
                    blGoodsCode,
                    salesCode,
                    goodsNo,
                    applyDate
                );
                msg += Environment.NewLine + "\tキャンペーン管理の取得状況：" + status;
                EasyLogger.WriteDebugLog( MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg( msg ) );
                
                // --- UPD m.suzuki 2011/06/28 ----------<<<<<

                #endregion // </Log>

                return;
            }
            else
            {
                #region <Log>

                // --- UPD m.suzuki 2011/06/28 ---------->>>>>
                //string msg = string.Format(
                //    "キャンペーン適用処理：演算前価格={0}, 掛率={1}, 価格={2}（企業：{3}, 拠点：{4}, 得意先：{5}, メーカー：{6}, 中分類：{7}, BL：{8}, 品番：{9}, 適用日：{10}）…{11}",
                //    price,
                //    campaignMng.RateVal,
                //    campaignMng.PriceFl,
                //    CurrentEnterpriseCode,
                //    LoginSectionCode,
                //    customerCode,
                //    goodsMakerCd,
                //    goodsMGroup,
                //    blGoodsCode,
                //    goodsNo,
                //    applyDate,
                //    campaignMngAcs.StatusOfResult
                //);
                string msg = string.Format(
                    "キャンペーン適用処理：演算前価格={0}, 値引率={1}, 掛率={2}, 価格={3}（企業：{4}, 拠点：{5}, 得意先：{6}, メーカー：{7}, グループ：{8}, BL：{9}, 販売区分 : {10}, 品番：{11}, 適用日：{12}）…{13}",
                    price,
                    campaignMng.DiscountRate,
                    campaignMng.RateVal,
                    campaignMng.PriceFl,
                    CurrentEnterpriseCode,
                    LoginSectionCode,
                    customerCode,
                    goodsMakerCd,
                    blGroupCode,
                    blGoodsCode,
                    salesCode,
                    goodsNo,
                    applyDate,
                    status
                );
                // --- UPD m.suzuki 2011/06/28 ----------<<<<<
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }

            // DEL 2011/07/15 --- >>>>
            // 価格と掛率は二者択一
            // キャンペーン価格適用
            //if (campaignMng.PriceFl != 0)
            //{
            //    price = campaignMng.PriceFl;
            //}
            //// キャンペーン掛率適用
            //else if (campaignMng.RateVal != 0)
            //{
            //    CalclatePriceByRate(taxationCode, campaignMng.RateVal, ref price);
            //}
            //// --- ADD m.suzuki 2011/06/28 ---------->>>>>
            //// キャンペーン値引率適用
            //else if ( campaignMng.DiscountRate != 0 )
            //{
            //    CalclatePriceByRate( taxationCode, GetPriceRateFromDiscountRate( campaignMng.DiscountRate ), ref price );
            //}
            // --- ADD m.suzuki 2011/06/28 ----------<<<<<
            // DEL 2011/07/15 --- <<<<

            #region <Log>

            string after = string.Format(
                "キャンペーン適用処理：演算後価格={0}",
                price
            );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(after));

            #endregion // </Log>
        }
        // --- ADD m.suzuki 2011/06/28 ---------->>>>>
        /// <summary>
        /// 値引率からの売価率算出
        /// </summary>
        /// <param name="discountRate"></param>
        /// <returns></returns>
        private double GetPriceRateFromDiscountRate( double discountRate )
        {
            // 売価率 = 100% - 値引率
            return (double)(100.0m - (decimal)discountRate);
        }
        // --- ADD m.suzuki 2011/06/28 ----------<<<<<

        /// <summary>
        /// 自動連携値引き適用処理（PartsInfoDataSet.ReflectAutoDiscount += デリゲートに使用）
        /// </summary>
        /// <remarks>MAHNB01012AC.cs SalesSlipInputAcs.ReflectAutoDiscount() 15017行目より移植</remarks>
        /// <param name="taxationCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="price"></param>
        public void ReflectAutoDiscount(
            int taxationCode,
            int customerCode,
            int goodsMGroup,
            int blGoodsCode,
            int goodsMakerCd,
            string goodsNo,
            ref double price
        )
        {
            const string METHOD_NAME = "ReflectAutoDiscount()"; // ログ用

            this._isDiscountApply = false; // ADD 黄興貴 2013/04/17 for Redmine#35271

            SCMTtlSt scmTtlSt = CurrentSCMTotalSetting;
            if (scmTtlSt == null)
            {
                #region <Log>

                string msg = "自動連携値引き適用処理：SCM全体設定がnullです。";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return;
            }
            else
            {
                #region <Log>

                string msg = string.Format(
                    "自動連携値引き適用処理：演算前価格={0}, 自動連携値引き率={1}, 値引き適用区分={2}:{3}",
                    price,
                    scmTtlSt.AutoCooperatDis,
                    scmTtlSt.DiscountApplyCd,
                    SCMDataHelper.GetDiscountApplyName(scmTtlSt)
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }

            double autoCooperatDis = 100.0 - scmTtlSt.AutoCooperatDis;
            switch (scmTtlSt.DiscountApplyCd)
            {
                case 0: // しない
                    break;
                case 1: // 全て
                    {
                        CalclatePriceByRate(taxationCode, autoCooperatDis, ref price);
                        this._isDiscountApply = true; // ADD 黄興貴 2013/04/17 for Redmine#35271
                        break;
                    }
                case 2: // 外装品以外
                    {
                        // 外装品チェック
                        if (!SCMOutEquipment.CheckOutEquipment(blGoodsCode))
                        {
                            CalclatePriceByRate(taxationCode, autoCooperatDis, ref price);
                            this._isDiscountApply = true; // ADD 黄興貴 2013/04/17 for Redmine#35271
                        }
                        break;
                    }
                case 3: // 重点品目
                    {
                        // 重点品目チェック
                        if (IsValidImportantPrtSt(LoginSectionCode, customerCode, goodsMakerCd, goodsMGroup, blGoodsCode, goodsNo))
                        {
                            #region <Log>

                            string msg = string.Format(
                                "\t\t重点品目です。(拠点：{0}, 得意先：{1}, メーカー：{2}, 中分類：{3}, BL：{4}, 品番：{5})",
                                LoginSectionCode,
                                customerCode,
                                goodsMakerCd,
                                goodsMGroup,
                                blGoodsCode,
                                goodsNo
                            );
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>

                            CalclatePriceByRate(taxationCode, autoCooperatDis, ref price);
                            this._isDiscountApply = true; // ADD 黄興貴 2013/04/17 for Redmine#35271
                        }
                        else
                        {
                            #region <Log>

                            string msg = string.Format(
                                "\t\t重点品目ではありません(または有効区分が「しない」です)。(拠点：{0}, 得意先：{1}, メーカー：{2}, 中分類：{3}, BL：{4}, 品番：{5})",
                                LoginSectionCode,
                                customerCode,
                                goodsMakerCd,
                                goodsMGroup,
                                blGoodsCode,
                                goodsNo
                            );
                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                            #endregion // </Log>
                        }
                        break;
                    }
                default:
                    break;
            }

            #region <Log>

            string after = string.Format(
                "自動連携値引き適用処理：演算後価格={0} ※呼出しメソッド：CalclatePriceByRate()",
                price
            );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(after));

            #endregion // </Log>
        }

        #region <キャンペーン適用処理／自動連携値引き適用処理用>

        /// <summary>
        /// 掛率より金額取得
        /// </summary>
        /// <remarks>
        /// MAHNB01012AC.cs SalesSlipInputAcs.CalclatePriceByRate() 15051行目より移植
        /// </remarks>
        /// <param name="taxationDivCd"></param>
        /// <param name="autoCooperatDis"></param>
        /// <param name="price"></param>
        private void CalclatePriceByRate(int taxationDivCd, double autoCooperatDis, ref double price)
        {
            double unitPriceTaxExc = 0;
            double unitPriceTaxInc = 0;

            // 消費税端数処理
            int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            GetSalesFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesCnsTaxFrcProcCd,
                0,
                out taxFracProcUnit,
                out taxFracProcCd
            );

            // 売上単価端数処理
            int frcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                CurrentCustomerCode,
                CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            );
            double fracProcUnit = 0;
            int fracProcDiv = 0;
            GetSalesFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitPrice,
                salesCnsTaxFrcProcCd,
                0,
                out fracProcUnit,
                out fracProcDiv
            );

            Calculator.RealAccesser.CalculateUnitPriceByRate(
                UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
                UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
                0,  // 総額表示方法区分…0:総額表示しない(税抜き)
                0,
                frcProcCd,
                taxationDivCd,
                price,
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                //CurrentTaxRateSet.TaxRateOfNow,
                (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                taxFracProcUnit,
                taxFracProcCd,
                autoCooperatDis,
                ref fracProcUnit,
                ref fracProcDiv,
                out unitPriceTaxExc,
                out unitPriceTaxInc
            );

            if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
            {
                price = unitPriceTaxInc;
            }
            else
            {
                price = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// 重点品目情報取得処理
        /// </summary>
        /// <remarks>
        /// MAHNB01012AC.cs SalesSlipInputAcs.GetImportantPrtSt() 15106行目より移植
        /// </remarks>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private bool IsValidImportantPrtSt(
            string sectionCode,
            int customerCode,
            int goodsMakerCd,
            int goodsMGroup,
            int blGoodsCode,
            string goodsNo
        )
        {
            ImportantPrtSt importantPrtSt;
            ImportantPrtStAcs importantPrtStAcs = new ImportantPrtStAcs(CurrentEnterpriseCode, sectionCode);
            int st = importantPrtStAcs.GetImportantPrtSt(
                out importantPrtSt,
                CurrentEnterpriseCode,
                LoginSectionCode,
                customerCode,
                goodsMakerCd,
                goodsMGroup,
                blGoodsCode,
                goodsNo
            );

            if (importantPrtSt != null)
            {
                return importantPrtSt.ValidDivCd.Equals(0); // 0:有効/1:無効
            }
            else
            {
                SCMDataHelper.DumpToLog(importantPrtStAcs.CachedImportantPrtStDic); // 調査用にダンプ
            }
            return false;
        }

        #endregion // </キャンペーン適用処理／自動連携値引き適用処理用>

        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        #region メーカー希望小売価格用 定価算出
        /// <summary>
        /// 掛率より金額取得（メーカー希望小売価格用 定価算出用）
        /// </summary>
        /// <remarks>
        /// MAHNB01012AC.cs SalesSlipInputAcs.CalclatePriceByRate() 15051行目より移植
        /// </remarks>
        /// <param name="taxationDivCd"></param>
        /// <param name="autoCooperatDis"></param>
        /// <param name="price"></param>
        public void CalclatePriceByRateForListPrice(int taxationDivCd, double autoCooperatDis, ref double price)
        {
            // UPD 2015/04/01 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            #region 削除
            //double unitPriceTaxExc = 0;
            //double unitPriceTaxInc = 0;

            //// 消費税端数処理
            //int salesCnsTaxFrcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
            //    CurrentEnterpriseCode,
            //    CurrentCustomerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            //);

            //int taxFracProcCd = 0;
            //double taxFracProcUnit = 0;
            //GetSalesFractionProcInfo(
            //    SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
            //    salesCnsTaxFrcProcCd,
            //    0,
            //    out taxFracProcUnit,
            //    out taxFracProcCd
            //);

            //// 売上単価端数処理
            //int frcProcCd = Calculator.CustomerDB.RealAccesser.GetSalesFractionProcCd(
            //    CurrentEnterpriseCode,
            //    CurrentCustomerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            //);
            //double fracProcUnit = 0;
            //int fracProcDiv = 0;
            //GetSalesFractionProcInfo(
            //    SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitPrice,
            //    salesCnsTaxFrcProcCd,
            //    0,
            //    out fracProcUnit,
            //    out fracProcDiv
            //);

            //Calculator.RealAccesser.CalculateUnitPriceByRate(
            //    UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
            //    UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
            //    0,  // 総額表示方法区分…0:総額表示しない(税抜き)
            //    0,
            //    frcProcCd,
            //    taxationDivCd,
            //    price,
            //    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
            //    //CurrentTaxRateSet.TaxRateOfNow,
            //    (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
            //    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
            //    taxFracProcUnit,
            //    taxFracProcCd,
            //    autoCooperatDis,
            //    ref fracProcUnit,
            //    ref fracProcDiv,
            //    out unitPriceTaxExc,
            //    out unitPriceTaxInc
            //);

            //if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
            //{
            //    price = unitPriceTaxInc;
            //}
            //else
            //{
            //    price = unitPriceTaxExc;
            //}
            #endregion 

            this.CalclatePriceByRate(taxationDivCd, autoCooperatDis, ref price);

            // UPD 2015/04/01 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
        }
        #endregion
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。(売上明細データの売上単価を再計算時に使用)
        /// </summary>
        /// <remarks>
        /// MAHNB01012AB.cs SalesSlipInputAcs.SalesDetailRowGoodsPriceSetting() 7493行目より移植
        /// </remarks>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>税抜き、税込み価格</returns>
        /// <br>UpdateNote : 2011/07/15 譚洪 Redmine#22829 自動回答、手動回答の両方で売価率の算出方法が不正の対応</br>
        /// <br>UpdateNote : 2011/07/20 譚洪 Redmine#22829「掛率マスタ/売価率」と「キャンペーン/売価率」が両方ヒットする場合、明細部も水色になりますの対応</br>
        /// <br>UpdateNote : 2011/09/22 譚洪 Redmine#25500 PCCUOE／PM側　自動回答 キャンペーン値引率が設定されている場合の売単価不正の対応</br>
        public PriceValue CalcTaxExcAndTaxInc(
            SalesDetail salesDetail,
            SalesSlip salesSlip
        )
        {
            // 2012/10/10 UPD TAKAGAWA SCM障害改良No10368 ----------------->>>>>>>>>>>>>>>>
            ////double price = salesDetail.SalesUnPrcTaxExcFl;   // DEL 2011/09/22
            //double price = salesDetail.BfSalesUnitPrice;      // ADD 2011/09/22
            double price = salesDetail.SalesUnPrcTaxExcFl;
            // 2012/10/10 UPD TAKAGAWA SCM障害改良No10368 -----------------<<<<<<<<<<<<<<<<
            double stdprice = salesDetail.ListPriceTaxExcFl;   // ADD 2011/07/15
            double priceTaxExc = 0.0;
            double priceTaxInc = 0.0;

            //-----------------------------------------------------------------------------
            // 自動連携値引き価格反映
            //-----------------------------------------------------------------------------
            // --- ADD 2012/10/01 三戸 2013/04/10配信分 SCM障害№27 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (salesDetail.AutoAnswerDivSCM == 2)
            {
                //>>>2013/04/14
                List<SalesProcMoney> salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(salesSlip.EnterpriseCode);
                Calculator.RealAccesser.CacheSalesProcMoneyList(salesProcMoneyList);
                //<<<2013/04/14

                //自動連携値引は自動回答時のみ適用
                // --- ADD 2012/10/01 三戸 2013/04/10配信分 SCM障害№27 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                ReflectAutoDiscount(
                    salesDetail.TaxationDivCd,
                    CurrentCustomerCode,
                    salesDetail.GoodsMGroup,
                    salesDetail.BLGoodsCode,
                    salesDetail.GoodsMakerCd,
                    salesDetail.GoodsNo,
                    ref price
                );
                // --- ADD 2012/10/01 三戸 2013/04/10配信分 SCM障害№27 --------->>>>>>>>>>>>>>>>>>>>>>>>
            }
            // --- ADD 2012/10/01 三戸 2013/04/10配信分 SCM障害№27 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //-----------------------------------------------------------------------------
            // キャンペーン価格反映
            //-----------------------------------------------------------------------------
            // --- UPD m.suzuki 2011/06/28 ---------->>>>>
            //ReflectCampaign(
            //    salesDetail.TaxationDivCd,
            //    CurrentCustomerCode,
            //    salesDetail.GoodsMGroup,
            //    salesDetail.BLGoodsCode,
            //    salesDetail.GoodsMakerCd,
            //    salesDetail.GoodsNo,
            //    salesSlip.SalesDate,
            //    ref price
            //);
            // --- UPD 2011/07/15 ---------->>>>>
            ReflectCampaign(
                salesDetail.TaxationDivCd,
                CurrentCustomerCode,
                salesDetail.BLGoodsCode,
                salesDetail.GoodsMakerCd,
                salesDetail.GoodsNo,
                salesDetail.BLGroupCode,
                salesDetail.SalesCode,
                salesSlip.SalesDate,
                ref price
            );

            if (campaignMng != null)
            {
                List<SalesProcMoney> salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(salesSlip.EnterpriseCode);

                Calculator.RealAccesser.CacheSalesProcMoneyList(salesProcMoneyList);

                salesDetail.CampaignCode = campaignMng.CampaignCode;  // ADD 2011/07/20

                // 価格と掛率は二者択一
                // キャンペーン価格適用
                if (campaignMng.PriceFl != 0)
                {
                    price = campaignMng.PriceFl;
                    this._isDiscountApply = false; // ADD 黄興貴 2013/04/17 for Redmine#35271
                }
                // キャンペーン掛率適用
                else if (campaignMng.RateVal != 0)
                {
                    CalclatePriceByRate(salesDetail.TaxationDivCd, campaignMng.RateVal, ref stdprice);
                    price = stdprice;
                    salesDetail.SalesRate = campaignMng.RateVal;
                    this._isDiscountApply = false; // ADD 黄興貴 2013/04/17 for Redmine#35271
                }
                // キャンペーン値引率適用
                else if (campaignMng.DiscountRate != 0)
                {
                    CalclatePriceByRate(salesDetail.TaxationDivCd, GetPriceRateFromDiscountRate(campaignMng.DiscountRate), ref price);
                    this._isDiscountApply = false; // ADD 黄興貴 2013/04/17 for Redmine#35271
                }
            }
            // --- UPD 2011/07/15 ----------<<<<<
            // --- UPD m.suzuki 2011/06/28 ----------<<<<<
            //-----------------------------------------------------------------------------
            // 価格再セット
            //-----------------------------------------------------------------------------
            CalcTaxExcAndTaxInc(
                salesDetail.TaxationDivCd,
                CurrentCustomerCode,
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                //CurrentTaxRateSet.TaxRateOfNow,
                (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                salesSlip.TotalAmountDispWayCd,
                price,
                out priceTaxExc,
                out priceTaxInc
            );
            return new PriceValue(priceTaxInc, priceTaxExc);
        }
        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。(売上明細データの売上単価を再計算時に使用)
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcTaxExcAndTaxInc() 10172行目より移植</remarks>
        /// <param name="taxationCode">課税区分
        /// 得意先コード ※<c>-1</c>を指定するとデフォルト値を使用します。
        /// </param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>

        public PriceValue CalcTaxExcAndTaxInc(
            int taxationCode,
            int totalAmountDispWayCd,
            double displayPrice)
        {

            double priceTaxExc = 0;
            double priceTaxInc = 0;
            //-----------------------------------------------------------------------------
            // 価格再セット
            //-----------------------------------------------------------------------------
                        // 内税品
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                CalcTaxInc(
                    taxationCode,
                    CurrentCustomerCode,
                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                    //CurrentTaxRateSet.TaxRateOfNow,
                    (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                    totalAmountDispWayCd,
                    displayPrice,
                    out priceTaxExc,
                    out priceTaxInc
                );
            }
            else
            {
                CalcTaxExcAndTaxInc(
                    taxationCode,
                    CurrentCustomerCode,
                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                    //CurrentTaxRateSet.TaxRateOfNow,
                    (CurrentTaxRateSet.CancelDiv == 1) ? CurrentTaxRateSet.TaxRateOfSlesDate : CurrentTaxRateSet.TaxRateOfNow,
                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                    totalAmountDispWayCd,
                    displayPrice,
                    out priceTaxExc,
                    out priceTaxInc
                );
            }
            return new PriceValue(priceTaxInc, priceTaxExc);
        }
        /// <summary>
        /// 内税の場合、税込み金額を計算します。(売上明細データの売上単価を再計算時に使用)
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcTaxExcAndTaxInc() 10172行目より移植</remarks>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">
        /// 得意先コード ※<c>-1</c>を指定するとデフォルト値を使用します。
        /// </param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        private void CalcTaxInc(
            int taxationCode,
            int customerCode,
            double taxRate,
            int totalAmountDispWayCd,
            double displayPrice,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (customerCode < 0) customerCode = CurrentCustomerCode;

            // 得意先マスタから消費税端数処理情報を取得
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int salesTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );  // 売上消費税端数処理コード

            double fracProcUnit;
            int fracProcCd;
            GetStockFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesTaxFrcProcCd,
                0,
                out fracProcUnit,
                out fracProcCd
            );

                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
        }

        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。(売上明細データの売上単価を再計算時に使用)
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.CalcTaxExcAndTaxInc() 10172行目より移植</remarks>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">
        /// 得意先コード ※<c>-1</c>を指定するとデフォルト値を使用します。
        /// </param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        private void CalcTaxExcAndTaxInc(
            int taxationCode,
            int customerCode,
            double taxRate,
            int totalAmountDispWayCd,
            double displayPrice,
            out double priceTaxExc,
            out double priceTaxInc
        )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (customerCode < 0) customerCode = CurrentCustomerCode;

            // 得意先マスタから消費税端数処理情報   を取得
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int salesTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                CurrentEnterpriseCode,
                customerCode,
                CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            );  // 売上消費税端数処理コード

            double fracProcUnit;
            int fracProcCd;
            GetStockFractionProcInfo(
                SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax,
                salesTaxFrcProcCd,
                0,
                out fracProcUnit,
                out fracProcCd
            );

            // 内税品
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // 外税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // 総額表示している場合は税込み価格
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // 非課税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }

        #region <対象金額より、税抜き、税込み価格を計算用>

        #region <仕入金額処理区分設定マスタ>

        /// <summary>仕入金額処理区分設定マスタ</summary>
        private List<StockProcMoney> _stockProcMoneyList;
        /// <summary>仕入金額処理区分設定マスタを取得します。</summary>
        private List<StockProcMoney> StockProcMoneyList
        {
            get
            {
                if (_stockProcMoneyList == null)
                {
                    StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
                    {
                        ArrayList aList = null;
                        int status = stockProcMoneyAcs.Search(out aList, CurrentEnterpriseCode);
                        if (aList != null)
                        {
                            _stockProcMoneyList = new List<StockProcMoney>(
                                (StockProcMoney[])aList.ToArray(typeof(StockProcMoney))
                            );
                        }
                        else
                        {
                            _stockProcMoneyList = new List<StockProcMoney>();
                        }
                    }
                }
                return _stockProcMoneyList;
            }
        }

        #endregion // </仕入金額処理区分設定マスタ>

        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <remarks>MAHNB01012AD.cs SalesSlipInputInitDataAcs.GetStockFractionProcInfo() 1722行目より移植</remarks>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void GetStockFractionProcInfo(
            int fracProcMoneyDiv,
            int fractionProcCode,
            double targetPrice,
            out double fractionProcUnit,
            out int fractionProcCd
        )
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<StockProcMoney> stockProcMoneyList = StockProcMoneyList.FindAll(
                delegate(StockProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            stockProcMoneyList.Sort(new StockProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            StockProcMoney stockProcMoney = stockProcMoneyList.Find(
                delegate(StockProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (stockProcMoney != null)
            {
                fractionProcUnit = stockProcMoney.FractionProcUnit;
                fractionProcCd = stockProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 仕入金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        /// <remarks>MAHNB01012AD.cs SalesSlipInputInitDataAcs.StockProcMoneyComparer 1791行目より移植</remarks>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        #endregion // </対象金額より、税抜き、税込み価格を計算用>
    }

    /// <summary>
    /// 価格値構造体
    /// </summary>
    public struct PriceValue
    {
        /// <summary>税込み値</summary>
        public double TaxInc;
        /// <summary>税抜き値</summary>
        public double TaxExc;

        #region <Constructoe>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="taxInc">税込み値</param>
        /// <param name="taxExc">税抜き値</param>
        public PriceValue(
            double taxInc,
            double taxExc
        )
        {
            TaxInc = taxInc;
            TaxExc = taxExc;
        }

        #endregion // </Constructor>
    }
}
