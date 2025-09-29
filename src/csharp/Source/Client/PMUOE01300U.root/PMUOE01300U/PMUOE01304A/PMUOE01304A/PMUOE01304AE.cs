//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2009/10/14  修正内容 : 受信電文で、数値項目にスペースが入ってきた場合の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2012/10/10  修正内容 : Redmine#32725 卸商仕入受信処理／仕入データ作成時の金額不正の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;       // 2009/10/14 Add

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using SupplierDB    = SingletonPolicy<SupplierDBAgent>;
    using GoodsDB       = SingletonPolicy<GoodsDBAgent>;
    using TaxRateSetDB  = SingletonPolicy<TaxRateSetDBAgent>;
    using MakerMasterDB = SingletonPolicy<MakerMasterDBAgent>;

    /// <summary>
    /// 発注情報の仕入明細データの構築者クラス
    /// </summary>
    public class OrderStockDetailDataBuilder : OrderInformationBuilder
    {
        #region <進捗情報/>

        /// <summary>処理中のメッセージ</summary>
        protected const string NOW_RUNNING = "仕入明細データ(発注情報)を作成中";    // LITERAL:

        /// <summary>進捗情報</summary>
        private readonly UpdateProgressEventArgs _progressInfo = new UpdateProgressEventArgs(NOW_RUNNING, 0, 0);
        /// <summary>
        /// 進捗情報を取得します。
        /// </summary>
        protected UpdateProgressEventArgs ProgressInfo { get { return _progressInfo; } }

        /// <summary>デバッグ用ストップウォッチ</summary>
        private readonly Stopwatch _myStopWatch = new Stopwatch();
        /// <summary>
        /// デバッグ用ストップウォッチを取得します。
        /// </summary>
        /// <value>デバッグ用ストップウォッチ</value>
        private Stopwatch MyStopWatch { get { return _myStopWatch; } } 

        #endregion  // <進捗情報/>

        #region <現在の発注情報の仕入明細データのレコード/>

        /// <summary>現在のUOE発注データの明細レコード</summary>
        private StockDetailWork _currentStockDetailRecord;
        /// <summary>
        /// 現在のUOE発注データの明細レコードのアクセサ
        /// </summary>
        /// <value>現在のUOE発注データの明細レコード</value>
        private StockDetailWork CurrentStockDetailRecord
        {
            get { return _currentStockDetailRecord; }
            set { _currentStockDetailRecord = value; }
        }

        #endregion  // <現在の発注情報の仕入明細データのレコード/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="receivedTelegramAgreegate">受信電文の集合体</param>
        /// <param name="observer">簡易オブザーバー</param>
        public OrderStockDetailDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 発注情報の仕入明細データに受信電文およびUOE発注データの内容をマージします。
        /// </summary>
        /// <remarks>
        /// 発注情報の仕入明細データの構築における明治産業による場合分けは
        /// MergeStockUnitPriceFl()：062.仕入単価（税抜, 浮動）をマージ
        /// のみです。
        /// 上記メソッド以外でも場合分けが多く発生する場合、明治産業用のサブクラス化を検討すること。
        /// </remarks>
        public override void Merge()
        {
            ProgressInfo.IsRunning = true;

            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                ProgressInfo.Max += uoeSlip.Count;
            }

            // 出荷伝票番号のループ
            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                // ある出荷伝票番号における受信テキスト（明細）のループ
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    Observer.Update(ProgressInfo);

                    bool isNewRecord = false;

                    // UOE発注番号が 0 の明細に関しては（UOE発注分は既に作成されている）
                    // 仕入明細データ（発注）の作成を行う
                    if (receivedTelegram.IsTelephoneOrder())
                    {
                        // TEL発注分（電文問合せ番号 == 0）…普通に新規登録
                        CurrentStockDetailRecord = new StockDetailWork();
                        isNewRecord = true;
                    }
                    else
                    {
                        // UOE発注分（電文問合せ番号 != 0）…既存のレコードを元に新規登録
                        CurrentStockDetailRecord = StockDB.Instance.Policy.FindStockDetailWork(receivedTelegram);
                        if (CurrentStockDetailRecord == null)
                        {
                            CurrentStockDetailRecord = new StockDetailWork();
                            isNewRecord = true;
                            Debug.WriteLine("オンライン発注のデータを電話発注とみなしています。");
                        }
                        if (!isNewRecord)
                        {
                            // 登録済みの発注情報は基本的にそのまま
                            MergeStockRowNo(receivedTelegram);      // 012.仕入行番号
                            MergeWarehouseCode(receivedTelegram);   // 044.倉庫コード
                            MergeWarehouseName(receivedTelegram);   // 045.倉庫名称
                            MergeWarehouseShelfNo(receivedTelegram);// 046.倉庫棚番
                            MergeStockCount(receivedTelegram);      // 073.仕入数
                            MergeDtlRelationGuid(receivedTelegram); // 105.明細関連付けGUID
                            // ----- ADD 2012/10/10 田建委 Redmine#32725 ---------------------->>>>>
                            MergeStockPriceTaxExc(receivedTelegram);    // 078.仕入金額（税抜き）
                            MergeStockPriceTaxInc(receivedTelegram);    // 079.仕入金額（税込み）
                            // ----- ADD 2012/10/10 田建委 Redmine#32725 ----------------------<<<<<
                            continue;
                        }
                    }
                    CurrentUnitCost = CalculateUnitCost(receivedTelegram, UoeSupplier);

                    // 受信電文およびUOE発注データの内容をマージ
                    MergeEnterpriseCode(receivedTelegram);      // 003.企業コード
                    MergeSupplierFormal(receivedTelegram);      // 010.仕入形式
                    MergeStockRowNo(receivedTelegram);          // 012.仕入行番号
                    MergeSectionCode(receivedTelegram);         // 013.拠点コード
                    MergeSubSectionCode(receivedTelegram);      // 014.部門コード
                    MergeStockInputCode(receivedTelegram);      // 022.仕入入力者コード
                    MergeStockInputName(receivedTelegram);      // 023.仕入入力者名称
                    MergeStockAgentCode(receivedTelegram);      // 024.仕入担当者コード
                    MergeStockAgentName(receivedTelegram);      // 025.仕入担当者名称
                    MergeGoodsMakerCd(receivedTelegram);        // 027.商品メーカーコード
                    MergeMakerName(receivedTelegram);           // 028.メーカー名称
                    MergeMakerKanaName(receivedTelegram);       // 029.メーカーカナ名称
                    MergeGoodsNo(receivedTelegram);             // 031.商品番号
                    MergeGoodsKindCode(receivedTelegram);       // 026.商品属性　※商品番号で検索となるため、031.商品番号のマージ後に処理を行う
                    MergeGoodsName(receivedTelegram);           // 032.商品名称
                    MergeGoodsNameKana(receivedTelegram);       // 033.商品名称カナ
                    MergeGoodsLGroup(receivedTelegram);         // 034.商品大分類コード
                    MergeGoodsLGroupName(receivedTelegram);     // 035.商品大分類名称
                    MergeGoodsMGroup(receivedTelegram);         // 036.商品中分類コード
                    MergeGoodsMGroupName(receivedTelegram);     // 037.商品中分類名称
                    MergeBLGroupCode(receivedTelegram);         // 038.BLグループコード
                    MergeBLGroupName(receivedTelegram);         // 039.BLグループ名称
                    MergeBLGoodsCode(receivedTelegram);         // 040.BL商品コード
                    MergeBLGoodsFullName(receivedTelegram);     // 041.BL商品名称（全角）
                    MergeEnterpriseGanreCode(receivedTelegram); // 042.自社分類コード
                    MergeEnterpriseGanreName(receivedTelegram); // 043.自社分類名称
                    MergeWarehouseCode(receivedTelegram);       // 044.倉庫コード
                    MergeWarehouseName(receivedTelegram);       // 045.倉庫名称
                    MergeWarehouseShelfNo(receivedTelegram);    // 046.倉庫棚番
                    MergeStockOrderDivCd(receivedTelegram);     // 047.仕入在庫取寄せ区分
                    MergeOpenPriceDiv(receivedTelegram);        // 048.オープン価格区分
                    MergeGoodsRateRank(receivedTelegram);       // 049.商品掛率ランク
                    MergeTaxationCode(receivedTelegram);        // 082.課税区分 ※定価、仕入単価の演算にて使用するため、それ以前に設定
                    MergeListPriceTaxExcFl(receivedTelegram);   // 052.定価（税抜, 浮動） ※053.定価（税込, 浮動）の演算にて使用
                    MergeListPriceTaxIncFl(receivedTelegram);   // 053.定価（税込, 浮動）
                    MergeStockUnitPriceFl(receivedTelegram);    // 062.仕入単価（税抜, 浮動） ※063.仕入単価（税込, 浮動）の演算にて使用
                    MergeStockUnitTaxPriceFl(receivedTelegram); // 063.仕入単価（税込, 浮動）
                    MergeStockUnitChngDiv(receivedTelegram);    // 064.仕入単価変更区分
                    MergeBfStockUnitPriceFl(receivedTelegram);  // 065.変更前仕入単価（浮動）
                    MergeBfListPrice(receivedTelegram);         // 066.変更前定価
                    MergeStockCount(receivedTelegram);          // 073.仕入数 ※仕入金額の演算にて使用するため、それ以前に設定
                    MergeOrderCnt(receivedTelegram);            // 074.発注数量
                    MergeOrderRemainCnt(receivedTelegram);      // 076.発注残数
                    MergeOrderAdjustCnt(receivedTelegram);      // 075.発注調整数 ※発注調整数 = 発注残数 - 発注数量
                    MergeStockPriceTaxExc(receivedTelegram);    // 078.仕入金額（税抜き）
                    MergeStockPriceTaxInc(receivedTelegram);    // 079.仕入金額（税込み）
                    MergeStockGoodsCd(receivedTelegram);        // 080.仕入商品区分
                    MergeStockPriceConsTax(receivedTelegram);   // 081.仕入金額消費税額
                    MergeSupplierCd(receivedTelegram);          // 092.仕入先コード
                    MergeSupplierSnm(receivedTelegram);         // 093.仕入先略称
                    MergeWayToOrder(receivedTelegram);          // 098.注文方法
                    MergeOrderDataCreateDate(receivedTelegram); // 102.発注データ作成日
                    MergeOrderFormIssuedDiv(receivedTelegram);  // 103.発注書発行済区分

                    MergeDtlRelationGuid(receivedTelegram);     // 105.明細関連付けGUID

                    // DBへ挿入用にレコードを追加
                    if (isNewRecord)
                    {
                        StockDB.Instance.Policy.AddStockDetailWork(CurrentStockDetailRecord, receivedTelegram);
                    }

                    ProgressInfo.Count++;
                }   // foreach (ReceivedText receivedTelegram in uoeSlip)
            }   // foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)

            ProgressInfo.IsRunning = false;
        }

        #endregion  // <Override/>

        #region <003.企業コード/>

        /// <summary>
        /// 企業コードをマージします。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterpriseCode(ReceivedText receivedTelegram)
        {
            string enterpriseCode = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
            CurrentStockDetailRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion  // <003.企業コード/>

        #region <010.仕入形式/>

        /// <summary>
        /// 仕入形式をマージします。
        /// </summary>
        /// <remarks>
        /// 2:発注
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSupplierFormal(ReceivedText receivedTelegram)
        {
            const int ORDER = 2;    // 発注
            CurrentStockDetailRecord.SupplierFormal = ORDER;
        }

        #endregion  // <010.仕入形式/>

        #region <仕入行番号/>

        /// <summary>仕入伝票番号別の仕入行番号カウンタマップ（キー：仕入伝票番号）</summary>
        private readonly IDictionary<int, int> _stockRowNoCounterMap = new Dictionary<int, int>();
        /// <summary>
        /// 仕入伝票番号別の仕入行番号カウンタマップ（キー：仕入伝票番号）を取得します。
        /// </summary>
        private IDictionary<int, int> StockRowNoCounterMap { get { return _stockRowNoCounterMap; } }

        /// <summary>
        /// 仕入行番号を取得します。
        /// </summary>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <returns>
        /// 仕入行番号
        /// （本メソッドを呼出し毎にインクリメントされます）
        /// </returns>
        private int GetStockRowNo(int supplierSlipNo)
        {
            if (!StockRowNoCounterMap.ContainsKey(supplierSlipNo))
            {
                StockRowNoCounterMap.Add(supplierSlipNo, 0);
            }
            int nextStockRowNo = ++StockRowNoCounterMap[supplierSlipNo];
            {
                StockRowNoCounterMap[supplierSlipNo] = nextStockRowNo;
            }
            return nextStockRowNo;
        }

        // HACK:仕入行番号（電話発注用）のゴミ掃除
        #region <電話発注用/>

        ///// <summary>出荷伝票番号別の仕入行番号カウンタマップ（キー：出荷伝票番号）</summary>
        //private readonly IDictionary<string, int> _stockRowNoCounterOfTelOrderMap = new Dictionary<string, int>();
        ///// <summary>
        ///// 出荷伝票番号別の仕入行番号カウンタマップ（キー：出荷伝票番号）を取得します。
        ///// </summary>
        //private IDictionary<string, int> StockRowNoCounterOfTelOrderMap { get { return _stockRowNoCounterOfTelOrderMap; } }

        ///// <summary>
        ///// 仕入行番号を取得します。（電話発注用）
        ///// </summary>
        ///// <param name="uoeSectionSlipNo">出荷伝票番号</param>
        ///// <returns>
        ///// 仕入行番号
        ///// （本メソッドを呼出し毎にインクリメントされます）
        ///// </returns>
        //private int GetStockRowNoOfTelOrder(string uoeSectionSlipNo)
        //{
        //    if (!StockRowNoCounterOfTelOrderMap.ContainsKey(uoeSectionSlipNo))
        //    {
        //        StockRowNoCounterOfTelOrderMap.Add(uoeSectionSlipNo.Trim(), 0);
        //    }
        //    int nextStockRowNo = ++StockRowNoCounterOfTelOrderMap[uoeSectionSlipNo];
        //    {
        //        StockRowNoCounterOfTelOrderMap[uoeSectionSlipNo] = nextStockRowNo;
        //    }
        //    return nextStockRowNo;
        //}

        #endregion  // <電話発注用/>

        #endregion  // <仕入行番号/>

        #region <012.仕入行番号/>

        /// <summary>
        /// 仕入行番号をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入伝票番号単位で連番（1～）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockRowNo(ReceivedText receivedTelegram)
        {
            int stockRowNo = 0;
            if (receivedTelegram.IsTelephoneOrder())
            {
                stockRowNo = GetRowNoOfTelOrder(receivedTelegram.UOESectionSlipNo);
            }
            else
            {
                stockRowNo = GetStockRowNo(CurrentStockDetailRecord.SupplierSlipNo);
            }
            CurrentStockDetailRecord.StockRowNo = stockRowNo;
        }

        #endregion  // <012.仕入行番号/>

        #region <013.拠点コード/>

        /// <summary>
        /// 拠点コードをマージします。
        /// </summary>
        /// <remarks>
        /// ログインした担当者が所属する拠点コード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSectionCode(ReceivedText receivedTelegram)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentStockDetailRecord.SectionCode = sectionCode;
        }

        #endregion  // <013.拠点コード/>

        #region <014.部門コード/>

        /// <summary>
        /// 部門コードをマージします。
        /// </summary>
        /// <remarks>
        /// ログインした担当者が所属する部門コード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSubSectionCode(ReceivedText receivedTelegram)
        {
            int subSectionCode = LoginWorkerAcs.Instance.Policy.Detail.BelongSubSectionCode;
            CurrentStockDetailRecord.SubSectionCode = subSectionCode;
        }

        #endregion  // <014.部門コード/>

        #region <022.仕入入力者コード/>

        /// <summary>
        /// 仕入入力者コードをマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockInputCode(ReceivedText receivedTelegram)
        {
            string stockInputCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
            CurrentStockDetailRecord.StockInputCode = stockInputCode;
        }

        #endregion  // <022.仕入入力者コード/>

        #region <023.仕入入力者名称/>

        /// <summary>
        /// 仕入入力者名所をマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者名称
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockInputName(ReceivedText receivedTelegram)
        {
            string stockInputName = LoginWorkerAcs.Instance.Policy.Profile.Name;
            CurrentStockDetailRecord.StockInputName = stockInputName;
        }

        #endregion  // <023.仕入入力者名称/>

        #region <024.仕入担当者コード/>

        /// <summary>
        /// 仕入担当者コードをマージします。
        /// </summary>
        /// <remarks>
        /// 発注先マスタの依頼者（未設定時はログイン担当者）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockAgentCode(ReceivedText receivedTelegram)
        {
            string stockAgentCode = UoeSupplier.AgentProfile.Code;
            if (string.IsNullOrEmpty(stockAgentCode))
            {
                stockAgentCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
            }
            CurrentStockDetailRecord.StockAgentCode = stockAgentCode;
        }

        #endregion  // <024.仕入担当者コード/>

        #region <025.仕入担当者名称/>

        /// <summary>
        /// 仕入担当者名称をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入担当者の名称
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockAgentName(ReceivedText receivedTelegram)
        {
            string stockAgentName = UoeSupplier.AgentProfile.Name;
            if (string.IsNullOrEmpty(stockAgentName))
            {
                stockAgentName = LoginWorkerAcs.Instance.Policy.Profile.Name;
            }
            CurrentStockDetailRecord.StockAgentName = stockAgentName;
        }

        #endregion  // <025.仕入担当者名称/>

        #region <026.商品属性/>

        /// <summary>
        /// 商品属性をマージします。
        /// </summary>
        /// <remarks>
        /// 商品抽出条件クラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsKindCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int goodsKindCode = goodsUnitData.GoodsKindCode;
                CurrentStockDetailRecord.GoodsKindCode = goodsKindCode;
            }
        }

        #endregion  // <026.商品属性/>

        #region <027.商品メーカーコード/>

        /// <summary>
        /// 商品メーカーコードをマージします。
        /// </summary>
        /// <remarks>
        /// 仕入受信電文のメーカーコード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsMakerCd(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int goodsMakerCd = int.Parse(receivedTelegram.AnswerMakerCode);
            int goodsMakerCd = TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.GoodsMakerCd = goodsMakerCd;
        }

        #endregion  // <027.商品メーカーコード/>

        #region <028.メーカー名称/>

        /// <summary>
        /// メーカー名称をマージします。
        /// </summary>
        /// <remarks>
        /// メーカーマスタから
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeMakerName(ReceivedText receivedTelegram)
        {
            MakerSet makerSet = MakerMasterDB.Instance.Policy.Find(CurrentStockDetailRecord.GoodsMakerCd);
            if (makerSet != null)
            {
                string makerName = makerSet.MakerName;
                CurrentStockDetailRecord.MakerName = makerName;
            }
        }

        #endregion  // <028.メーカー名称/>

        #region <029.メーカーカナ名称/>

        /// <summary>
        /// メーカーカナ名称をマージします。
        /// </summary>
        /// <remarks>
        /// メーカーマスタから
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeMakerKanaName(ReceivedText receivedTelegram)
        {
            MakerSet makerSet = MakerMasterDB.Instance.Policy.Find(CurrentStockDetailRecord.GoodsMakerCd);
            if (makerSet != null)
            {
                string makerKanaName = makerSet.MakerKanaName;
                CurrentStockDetailRecord.MakerKanaName = makerKanaName;
            }
        }

        #endregion  // <029.メーカーカナ名称/>

        #region <031.商品番号/>

        /// <summary>
        /// 商品番号をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入受信電文の出荷部品番号<br/>
        /// ①商品番号のセットについて<br/>
        /// 品番がスペース時には品名をセットする
        /// （SPKで用品や運賃等、品番がスペースで返ってくる場合がある）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsNo(ReceivedText receivedTelegram)
        {
            string goodsNo = receivedTelegram.ToGoodsNo();
            CurrentStockDetailRecord.GoodsNo = TrimEndCode(goodsNo);
        }

        #endregion  // <031.商品番号/>

        #region <032.商品名称/>

        /// <summary>
        /// 商品名称をマージします。
        /// </summary>
        /// <remarks>
        /// 商品抽出条件クラス　※品番未存在時には仕入電文上の品名をセット
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsName = goodsUnitData.GoodsName;
                CurrentStockDetailRecord.GoodsName = goodsName;
            }
            else
            {
                CurrentStockDetailRecord.GoodsName = receivedTelegram.AnswerPartsName;
            }
        }

        #endregion  // <032.商品名称/>

        #region <033.商品名称カナ/>

        /// <summary>
        /// 商品名称カナをマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsNameKana(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsNameKana = goodsUnitData.GoodsNameKana;
                CurrentStockDetailRecord.GoodsNameKana = goodsNameKana;
            }
        }

        #endregion  // <033.商品名称カナ/>

        #region <034.商品大分類コード/>

        /// <summary>
        /// 商品大分類コードをマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsLGroup(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int goodsLGroup = goodsUnitData.GoodsLGroup;
                CurrentStockDetailRecord.GoodsLGroup = goodsLGroup;
            }
        }

        #endregion  // <034.商品大分類コード/>

        #region <035.商品大分類名称/>

        /// <summary>
        /// 商品大分類名称をマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsLGroupName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsLGrouName = goodsUnitData.GoodsLGroupName;
                CurrentStockDetailRecord.GoodsLGroupName = goodsLGrouName;
            }
        }

        #endregion  // <035.商品大分類名称/>

        #region <036.商品中分類コード/>

        /// <summary>
        /// 商品中分類コードをマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsMGroup(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int goodsMGroup = goodsUnitData.GoodsMGroup;
                CurrentStockDetailRecord.GoodsMGroup = goodsMGroup;
            }
        }

        #endregion  // <036.商品中分類コード/>

        #region <037.商品中分類名称/>

        /// <summary>
        /// 商品中分類名称をマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsMGroupName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsMGroupName = goodsUnitData.GoodsMGroupName;
                CurrentStockDetailRecord.GoodsMGroupName = goodsMGroupName;
            }
        }

        #endregion  // <037.商品中分類名称/>

        #region <038.BLグループコード/>

        /// <summary>
        /// BLグループコードをマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBLGroupCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int blGroupCode = goodsUnitData.BLGroupCode;
                CurrentStockDetailRecord.BLGroupCode = blGroupCode;
            }
        }

        #endregion  // <038.BLグループコード/>

        #region <039.BLグループ名称/>

        /// <summary>
        /// BLグループ名称をマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBLGroupName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string blGroupName = goodsUnitData.BLGroupName;
                CurrentStockDetailRecord.BLGroupName = blGroupName;
            }
        }

        #endregion  // <039.BLグループ名称/>

        #region <040.BL商品コード/>

        /// <summary>
        /// BL商品コードをマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBLGoodsCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int blGoodsCode = goodsUnitData.BLGoodsCode;
                CurrentStockDetailRecord.BLGoodsCode = blGoodsCode;
            }
        }

        #endregion  // <040.BL商品コード/>

        #region <041.BL商品名称（全角）/>

        /// <summary>
        /// BL商品名称（全角）をマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBLGoodsFullName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string blGoodsFullName = goodsUnitData.BLGoodsFullName;
                CurrentStockDetailRecord.BLGoodsFullName = blGoodsFullName;
            }
        }

        #endregion  // <041.BL商品名称（全角）/>

        #region <042.自社分類コード/>

        /// <summary>
        /// 自社分類コードをマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterpriseGanreCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int enterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;
                CurrentStockDetailRecord.EnterpriseGanreCode = enterpriseGanreCode;
            }
        }

        #endregion  // <042.自社分類コード/>

        #region <043.自社分類名称/>

        /// <summary>
        /// 自社分類名称をマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterpriseGanreName(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string enterpriseGanreName = goodsUnitData.EnterpriseGanreName;
                CurrentStockDetailRecord.EnterpriseGanreName = enterpriseGanreName;
            }
        }

        #endregion  // <043.自社分類名称/>

        #region <044.倉庫コード/>

        /// <summary>
        /// 倉庫コードをマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、
        /// 拠点設定マスタの倉庫コード（3つ）と
        /// 受信電文の出荷部品番号、メーカーコードで
        /// 在庫マスタの存在チェックを行い存在する倉庫コードをセットする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeWarehouseCode(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderDetailRecord != null)
            {
                string warehouseCode = uoeOrderDetailRecord.WarehouseCode;
                CurrentStockDetailRecord.WarehouseCode = warehouseCode;
            }
        }

        #endregion  // <044.倉庫コード/>

        #region <045.倉庫名称/>

        /// <summary>
        /// 倉庫名称をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、
        /// 拠点設定マスタの倉庫コード（3つ）と
        /// 受信電文の出荷部品番号、メーカーコードで
        /// 在庫マスタの存在チェックを行い存在する倉庫名称をセットする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeWarehouseName(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderDetailRecord != null)
            {
                string warehouseName = uoeOrderDetailRecord.WarehouseName;
                CurrentStockDetailRecord.WarehouseName = warehouseName;
            }
        }

        #endregion  // <045.倉庫名称/>

        #region <046.倉庫棚番/>

        /// <summary>
        /// 倉庫棚番をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、
        /// 拠点設定マスタの倉庫コード（3つ）と
        /// 受信電文の出荷部品番号、メーカーコードで
        /// 在庫マスタの存在チェックを行い存在する倉庫棚番をセットする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeWarehouseShelfNo(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderDetailRecord != null)
            {
                string warehouseShelfNo = uoeOrderDetailRecord.WarehouseShelfNo;
                CurrentStockDetailRecord.WarehouseShelfNo = warehouseShelfNo;
            }
        }

        #endregion  // <046.倉庫棚番/>

        #region <047.仕入在庫取寄せ区分/>

        /// <summary>
        /// 仕入在庫取寄せ区分をマージします。
        /// </summary>
        /// <remarks>
        /// 倉庫コードが<c>0</c>以外の場合には 1:在庫
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockOrderDivCd(ReceivedText receivedTelegram)
        {
            const int GOODS_IN_STOCK = 1;   // 1:在庫

            int warehouseCode = 0;
            if (int.TryParse(CurrentStockDetailRecord.WarehouseCode.Trim(), out warehouseCode))
            {
                if (!warehouseCode.Equals(0))
                {
                    CurrentStockDetailRecord.StockOrderDivCd = GOODS_IN_STOCK;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(CurrentStockDetailRecord.WarehouseCode.Trim()))
                {
                    CurrentStockDetailRecord.StockOrderDivCd = GOODS_IN_STOCK;
                }
            }
        }

        #endregion  // <047.仕入在庫取寄せ区分/>

        #region <048.オープン価格区分/>

        /// <summary>
        /// オープン価格区分をマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOpenPriceDiv(ReceivedText receivedTelegram)
        {
            GoodsPrice goodsPrice = GoodsDB.Instance.Policy.FindFirstGoodsPrice(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsPrice != null)
            {
                int openPriceDiv = goodsPrice.OpenPriceDiv;
                CurrentStockDetailRecord.OpenPriceDiv = openPriceDiv;
            }
        }

        #endregion  // <048.オープン価格区分/>

        #region <049.商品掛率ランク/>

        /// <summary>
        /// 商品掛率ランクをマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsRateRank(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                string goodsRateRank = goodsUnitData.GoodsRateRank;
                CurrentStockDetailRecord.GoodsRateRank = goodsRateRank;
            }
        }

        #endregion  // <049.商品掛率ランク/>

        #region <052.定価（税抜, 浮動）/>

        /// <summary>
        /// 定価（税抜, 浮動）をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入受信電文の定価
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeListPriceTaxExcFl(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double listPriceTaxExcFl = double.Parse(receivedTelegram.AnswerListPrice);
            double listPriceTaxExcFl = TStrConv.StrToDoubleDef(receivedTelegram.AnswerListPrice.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.ListPriceTaxExcFl = listPriceTaxExcFl;
        }

        #endregion  // <052.定価（税抜, 浮動）/>

        #region <053.定価（税込, 浮動）/>

        /// <summary>
        /// 定価（税込, 浮動）をマージします。
        /// </summary>
        /// <remarks>
        /// 定価（税抜, 浮動）からCalculatePriceメソッドを使用し算出
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeListPriceTaxIncFl(ReceivedText receivedTelegram)
        {
            int stockCnsTaxFrcProcCd = 0;   // 仕入消費税端数処理コード
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                stockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd;
            }
            UOESendReceiveComponent component = new UOESendReceiveComponent();
            double listPriceTaxIncFl = component.GetStockPriceTaxInc(
                CurrentStockDetailRecord.ListPriceTaxExcFl,
                CurrentStockDetailRecord.TaxationCode,
                stockCnsTaxFrcProcCd
            );
            CurrentStockDetailRecord.ListPriceTaxIncFl = listPriceTaxIncFl;
        }

        #endregion  // <053.定価（税込, 浮動）/>

        #region <062.仕入単価（税抜, 浮動）/>

        /// <summary>
        /// 仕入単価（税抜, 浮動）をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入受信電文の仕切単価<br/>
        /// 明治産業は小数点第1位までとなり10倍値がセットされてくる為、小数点付きでセット<br/>
        /// 明治以外はそのまま
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockUnitPriceFl(ReceivedText receivedTelegram)
        {
            if (UoeSupplier is UOEMeijiDecorator)
            {
                #region <Guard Phrase/>

                // 2009/10/14 >>>
                //int telegramValue= CutOffDecimal(double.Parse(receivedTelegram.AnswerSalesUnitCost.Trim()));
                int telegramValue = CutOffDecimal(TStrConv.StrToDoubleDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0));
                // 2009/10/14 <<<
                int currentValue = CutOffDecimal(CurrentStockDetailRecord.StockUnitPriceFl);
                if (telegramValue.Equals(currentValue))
                {
                    // FIXME:送受信処理側で明示用の処理が施される？
                }

                #endregion  // <Guard Phrase/>

                // 2009/10/14 >>>
                //int nStockUnitPriceFl = int.Parse(receivedTelegram.AnswerSalesUnitCost.Trim());
                int nStockUnitPriceFl = TStrConv.StrToIntDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
                // 2009/10/14 <<<
                CurrentStockDetailRecord.StockUnitPriceFl = ( (double)nStockUnitPriceFl ) / 10.0;
            }
            else
            {
                // 2009/10/14 >>>
                //double stockUnitPriceFl = double.Parse(receivedTelegram.AnswerSalesUnitCost.Trim());
                double stockUnitPriceFl = TStrConv.StrToDoubleDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
                // 2009/10/14 <<<
                CurrentStockDetailRecord.StockUnitPriceFl = stockUnitPriceFl;
            }
        }

        /// <summary>
        /// 小数点以下を切り捨てた数値を取得します。
        /// </summary>
        /// <param name="doubleNumber"></param>
        /// <returns></returns>
        private static int CutOffDecimal(double doubleNumber)
        {
            string strNumber = doubleNumber.ToString();
            string[] strNumbers = strNumber.Split('.');
            return int.Parse(strNumbers[0]);
        }

        #endregion  // <062.仕入単価（税抜, 浮動）/>

        #region <063.仕入単価（税込, 浮動）/>

        /// <summary>
        /// 仕入単価（税込, 浮動）をマージします。
        /// </summary>
        /// <remarks>
        /// 定価（税抜, 浮動）からCalculatePriceメソッドを使用し算出
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockUnitTaxPriceFl(ReceivedText receivedTelegram)
        {
            int stockCnsTaxFrcProcCd = 0;   // 仕入消費税端数処理コード
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                stockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd;
            }
            UOESendReceiveComponent component = new UOESendReceiveComponent();
            double stockUnitTaxPriceFl = component.GetStockPriceTaxInc(
                CurrentStockDetailRecord.StockUnitPriceFl,
                CurrentStockDetailRecord.TaxationCode,
                stockCnsTaxFrcProcCd
            );
            CurrentStockDetailRecord.StockUnitTaxPriceFl = stockUnitTaxPriceFl;
        }

        #endregion  // <063.仕入単価（税込, 浮動）/>

        #region <064.仕入単価変更区分/>

        /// <summary>
        /// 仕入単価変更区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:変更なし
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockUnitChngDiv(ReceivedText receivedTelegram)
        {
            const int NOT_CHANGED = 0;  // 0:変更なし
            CurrentStockDetailRecord.StockUnitChngDiv = NOT_CHANGED;
        }

        #endregion  // <064.仕入単価変更区分/>

        #region <065.変更前仕入単価（浮動）/>

        /// <summary>
        /// 変更前仕入単価（浮動）をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入単価（税抜, 浮動)
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBfStockUnitPriceFl(ReceivedText receivedTelegram)
        {
            double bfStockUnitPriceFl = CurrentStockDetailRecord.StockUnitPriceFl;
            CurrentStockDetailRecord.BfStockUnitPriceFl = bfStockUnitPriceFl;
        }

        #endregion  // <065.変更前仕入単価（浮動）/>

        #region <066.変更前定価/>

        /// <summary>
        /// 変更前定価をマージします。
        /// </summary>
        /// <remarks>
        /// 定価（税抜, 浮動）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBfListPrice(ReceivedText receivedTelegram)
        {
            double bfListPrice = CurrentStockDetailRecord.ListPriceTaxExcFl;
            CurrentStockDetailRecord.BfListPrice = bfListPrice;
        }

        #endregion  // <066.変更前定価/>

        #region <073.仕入数/>

        /// <summary>
        /// 仕入数をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入受信電文の出荷数
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockCount(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double stockCount = double.Parse(receivedTelegram.UOESectOutGoodsCount);
            double stockCount = TStrConv.StrToDoubleDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<

            if (receivedTelegram.IsTelephoneOrder())
            {
                UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
                if (uoeOrderDetailRecord != null)
                {
                    stockCount = uoeOrderDetailRecord.UOESectOutGoodsCnt;
                }
            }

            CurrentStockDetailRecord.StockCount = stockCount;
        }

        #endregion  // <073.仕入数/>

        #region <074.発注数量/>

        /// <summary>
        /// 発注数量をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入受信電文の受注数
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOrderCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double orderCnt = double.Parse(receivedTelegram.AcceptAnOrderCount);
            double orderCnt = TStrConv.StrToDoubleDef(receivedTelegram.AcceptAnOrderCount.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.OrderCnt = orderCnt;
        }

        #endregion  // <074.発注数量/>

        #region <075.発注調整数/>

        /// <summary>
        /// 発注調整量をマージします。
        /// </summary>
        /// <remarks>
        /// 発注調整数 = 発注残数 - 発注数量
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOrderAdjustCnt(ReceivedText receivedTelegram)
        {
            CurrentStockDetailRecord.OrderAdjustCnt
                = CurrentStockDetailRecord.OrderRemainCnt - CurrentStockDetailRecord.OrderCnt;
        }

        #endregion  // <075.発注調整数/>

        #region <076.発注残数/>

        /// <summary>
        /// 発注残数をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の出荷数
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOrderRemainCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double orderRemainCnt = double.Parse(receivedTelegram.UOESectOutGoodsCount);
            double orderRemainCnt = TStrConv.StrToDoubleDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<
            CurrentStockDetailRecord.OrderRemainCnt = orderRemainCnt;
        }

        #endregion  // <076.発注残数/>

        #region <078.仕入金額（税抜き）/>

        /// <summary>
        /// 仕入金額（税抜き）をマージします。
        /// </summary>
        /// <remarks>
        /// CalcTaxExcFromTaxIncメソッドを使用し算出
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockPriceTaxExc(ReceivedText receivedTelegram)
        {
            int stockMoneyFrcProcCd = 0;    // 仕入金額端数処理コード
            int stockCnsTaxFrcProcCd = 0;    // 仕入消費税端数処理コード
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                stockMoneyFrcProcCd = supplier.StockMoneyFrcProcCd;
                stockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd;
            }
            long stockPriceTaxInc = 0;  // 仕入金額（税込み）
            long stockPriceTaxExc = 0;  // 仕入金額（税抜き）
            long stockPriceConsTax= 0;  // 仕入消費税
            UOESendReceiveComponent component = new UOESendReceiveComponent();
            {
                if (component.CalculationStockPrice(
                    CurrentStockDetailRecord.StockCount,
                    CurrentStockDetailRecord.StockUnitPriceFl, CurrentStockDetailRecord.TaxationCode,
                    stockMoneyFrcProcCd,
                    stockCnsTaxFrcProcCd,
                    out stockPriceTaxInc,
                    out stockPriceTaxExc,
                    out stockPriceConsTax
                ))
                {
                    CurrentStockDetailRecord.StockPriceTaxInc = stockPriceTaxInc;
                    CurrentStockDetailRecord.StockPriceTaxExc = stockPriceTaxExc;
                    CurrentStockDetailRecord.StockPriceConsTax= stockPriceConsTax;
                }
            }
        }

        #endregion  // <078.仕入金額（税抜き）/>

        #region <079.仕入金額（税込み）/>

        /// <summary>
        /// 仕入金額（税込み）をマージします。
        /// </summary>
        /// <remarks>
        /// CalcTaxExcFromTaxExcメソッドを使用し算出 ※078.仕入金額（税抜き）で同時にマージ
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockPriceTaxInc(ReceivedText receivedTelegram)
        {

        }

        #endregion  // <079.仕入金額（税込み）/>

        #region <080.仕入商品区分/>

        /// <summary>
        /// 仕入商品区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:商品
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockGoodsCd(ReceivedText receivedTelegram)
        {
            const int GOODS = 0;    // 0:商品
            CurrentStockDetailRecord.StockGoodsCd = GOODS;
        }

        #endregion  // <080.仕入商品区分/>

        #region <081.仕入金額消費税額/>

        /// <summary>
        /// 仕入金額消費税額をマージします。
        /// </summary>
        /// <remarks>
        /// ※078.仕入金額（税抜き）で同時にマージ
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeStockPriceConsTax(ReceivedText receivedTelegram) { }

        #endregion  // <081.仕入金額消費税額/>

        #region <082.課税区分/>

        /// <summary>
        /// 課税区分をマージします。
        /// </summary>
        /// <remarks>
        /// 商品連結データクラス
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeTaxationCode(ReceivedText receivedTelegram)
        {
            GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(
                receivedTelegram,
                UoeSupplier
            );
            if (goodsUnitData != null)
            {
                int taxationCode = goodsUnitData.TaxationDivCd;
                CurrentStockDetailRecord.TaxationCode = taxationCode;
            }
        }

        #endregion  // <082.課税区分/>

        #region <092.仕入先コード/>

        /// <summary>
        /// 仕入先コードをマージします。
        /// </summary>
        /// <remarks>
        /// 発注先マスタ上の仕入先コード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSupplierCd(ReceivedText receivedTelegram)
        {
            int supplierCd = UoeSupplier.RealUOESupplier.UOESupplierCd;
            CurrentStockDetailRecord.SupplierCd = supplierCd;
        }

        #endregion  // <092.仕入先コード/>

        #region <093.仕入先略称/>

        /// <summary>
        /// 仕入先略称をマージします。
        /// </summary>
        /// <remarks>
        /// 仕入先マスタの仕入先略称
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSupplierSnm(ReceivedText receivedTelegram)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierSnm = supplier.SupplierSnm;
                CurrentStockDetailRecord.SupplierSnm = supplierSnm;
            }
        }

        #endregion  // <093.仕入先略称/>

        #region <098.注文方法/>

        /// <summary>
        /// 注文方法をマージします。
        /// </summary>
        /// <remarks>
        /// 2:オンライン発注
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeWayToOrder(ReceivedText receivedTelegram)
        {
            const int WAY_OF_ONLINE_ORDER = 2;    // 2:オンライン発注
            CurrentStockDetailRecord.WayToOrder = WAY_OF_ONLINE_ORDER;
        }

        #endregion  // <098.注文方法/>

        #region <102.発注データ作成日/>

        /// <summary>
        /// 発注データ作成日をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOrderDataCreateDate(ReceivedText receivedTelegram)
        {
            DateTime orderDataCreateDate = DateTime.Now;
            CurrentStockDetailRecord.OrderDataCreateDate = orderDataCreateDate;
        }

        #endregion  // <102.発注データ作成日/>

        #region <103.発注書発行済区分/>

        /// <summary>
        /// 発注書発行済区分をマージします。
        /// </summary>
        /// <remarks>
        /// 0:未発行
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOrderFormIssuedDiv(ReceivedText receivedTelegram)
        {
            const int NOT_ISSUED = 0;   // 0:未発行
            CurrentStockDetailRecord.OrderFormIssuedDiv = NOT_ISSUED;
        }

        #endregion  // <103.発注書発行済区分/>

        #region <105.明細関連付けGUID/>

        /// <summary>
        /// 明細関連付けGUIDをマージします。
        /// </summary>
        /// <remarks>
        /// 対応するUOE発注データのレコードと同じ値
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeDtlRelationGuid(ReceivedText receivedTelegram)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
            if (uoeOrderRecord != null)
            {
                CurrentStockDetailRecord.DtlRelationGuid = uoeOrderRecord.DtlRelationGuid;
            }
            else
            {
                Debug.Assert(false, "仕入明細データに対応するUOE発注データがありません\n" + receivedTelegram.DtlRelationGuid.ToString());
                CurrentStockDetailRecord.DtlRelationGuid = Guid.NewGuid();
            }
        }

        #endregion  // <105.明細関連付けGUID/>

        /// <summary>現在の単価計算結果</summary>
        private UnitPriceCalcRet _currentUnitCost;
        /// <summary>
        /// 現在の単価計算結果を取得します。
        /// </summary>
        /// <value>現在の単価計算結果</value>
        private UnitPriceCalcRet CurrentUnitCost
        {
            get { return _currentUnitCost; }
            set { _currentUnitCost = value; }
        }

        /// <summary>
        /// 単価計算結果を取得します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns>単価計算結果</returns>
        private static UnitPriceCalcRet CalculateUnitCost(
            ReceivedText receivedTelegram,
            UOESupplierHelper uoeSupplier
        )
        {
            UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();
            {
                GoodsUnitData goodsUnitData = GoodsDB.Instance.Policy.FindFirstGoodsUnitData(receivedTelegram, uoeSupplier);
                if (goodsUnitData == null)
                {
                    return ReturnUnitPriceCalcRet(unitPriceCalcRet);
                }

                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                {
                    // パラメータ設定
                    unitPriceCalcParam.SectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;    // 拠点コード
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                           // 商品メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                     // 品番
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                         // 商品掛率ランク
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                   // 商品掛率グループコード
                    unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                             // BLグループコード
                    unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                             // BL商品コード
                    unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                               // 仕入先コード
                    unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                       // 価格適用日
                    // 2009/10/14 >>>
                    //unitPriceCalcParam.CountFl = double.Parse(receivedTelegram.UOESectOutGoodsCount);       // 数量
                    unitPriceCalcParam.CountFl = TStrConv.StrToDoubleDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);       // 数量
                    // 2009/10/14 <<<
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                         // 課税区分
                    unitPriceCalcParam.TaxRate = TaxRateSetDB.Instance.Policy.TaxRateOfNow;                 // 税率
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;           // 仕入消費税端数処理コード
                    unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;             // 仕入単価端数処理コード
                }
                // 原価単価計算処理
                List<UnitPriceCalcRet> unitPriceCalcRetList = null;
                UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
                unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
                foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
                {
                    if (unitPriceCalcRetWk.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_UnitCost))
                    {
                        // 原価単価を取得
                        unitPriceCalcRet = unitPriceCalcRetWk;
                        break;
                    }
                }
            }
            return ReturnUnitPriceCalcRet(unitPriceCalcRet);
        }

        /// <summary>
        /// 単価計算結果を返します。
        /// </summary>
        /// <param name="unitPriceCalcRet">単価計算結果</param>
        /// <returns>単価計算結果</returns>
        private static UnitPriceCalcRet ReturnUnitPriceCalcRet(UnitPriceCalcRet unitPriceCalcRet)
        {
            if (unitPriceCalcRet == null)
            {
                unitPriceCalcRet = new UnitPriceCalcRet();
            }
            // 単位がゼロはプログラムが落ちるとのこと
            if (unitPriceCalcRet.UnPrcFracProcUnit.Equals(0.0))
            {
                unitPriceCalcRet.UnPrcFracProcUnit = 1.0;
            }
            return unitPriceCalcRet;
        }
    }
}
