//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ引用登録
// プログラム概要   : 掛率マスタ引用登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10801804-00  作成担当 : chenyd
// 修 正 日 2013/03/18   修正内容 : 2013/05/15配信分
//                         Redmine#35046引用登録で不正な組み合わせのデータが発生
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木創
// 作 成 日  2021/09/06  修正内容 : 引用元得意先掛率グループコードが0000のとき、掛率設定区分（得意先）が「3(得意先掛率G+仕入先)」と「4(得意先掛率G)」以外のレコードを処理対象としない。
//                                  BLINCIDENT-2384 PM(NS) 掛率マスタ引用登録の条件を確認したい。
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 受信データフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : なし。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.04.29</br>
    /// </remarks>
    public class RateQuoteInputAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private RateQuoteInputAcs()
        {
            _stockQuoteData = new StockQuoteData();
            _rateAcs = new RateAcs();
        }

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public static RateQuoteInputAcs GetInstance()
        {
            if (_rateQuoteInputAcs == null)
            {
                _rateQuoteInputAcs = new RateQuoteInputAcs();
            }

            return _rateQuoteInputAcs;
        }
        #endregion


        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static RateQuoteInputAcs _rateQuoteInputAcs = null;
        private StockQuoteData _stockQuoteData = null;
        private RateAcs _rateAcs = null;
        private IRateQuoteDB _rateQuoteDB = null;
        #endregion

        // ===================================================================================== //
        // 属性
        // ===================================================================================== //
        # region ■Propertity

        /// <summary>
        /// UIデータ
        /// </summary>
        public StockQuoteData StockQuoteData
        {
            get { return this._stockQuoteData; }
        }
        #endregion


        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods

        /// <summary>
        /// 検索データ初期インスタンス生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void CreateStockQuoteInitialData()
        {
            StockQuoteData stockQuoteData = new StockQuoteData();

            // 拠点初期値
            stockQuoteData.BfSectionCode = "00";
            stockQuoteData.BfSectionName = "全社";
            stockQuoteData.AfSectionCode = "00";
            stockQuoteData.AfSectionName = "全社";
            stockQuoteData.ObjectDistinctionCode = 0;
            stockQuoteData.UpdateDistinctionCode = 0;

            this.CacheStockQuoteData(stockQuoteData);
        }

        /// <summary>
        /// 検索データキャッシュ処理
        /// </summary>
        /// <param name="source">売上データインスタンス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void CacheStockQuoteData(StockQuoteData source)
        {
            this._stockQuoteData = source.Clone();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <param name="bfCustRateGrpCodeIsZero">引用元の得意先掛率グループコードが「0000」のときTrue</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int SaveData(ref string msg, bool bfCustRateGrpCodeIsZero)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 件数クリア
            this._stockQuoteData.ReadCount = 0;
            this._stockQuoteData.ProcessCount = 0;

            if (_rateQuoteDB == null)
            {
                _rateQuoteDB = MediationRateQuoteDB.GetRateQuoteDB();
            }

            // 引用元情報を取得
            ArrayList bfRetList = new ArrayList();

            status = this.getBfRateData(ref bfRetList);

            // エラーの場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    msg = "引用元のデータが存在しません。";
                }
                else
                {
                    msg = "保存処理が失敗します。";
                }
                return status;
            }

            // ADD BLINCIDENT-2384 2021/09/06 --------------------------------------------------->>>>>

            // 引用元得意先掛率グループコードが0の場合、
            // DBから取得してきた引用元情報から、掛率設定区分（得意先）が「3(得意先掛率G+仕入先)」と「4(得意先掛率G)」以外のものを削除する。
            //   (DB上、得意先掛率グループコードが「0」と「指定なし」は同じ0で表現されており、区別が付かないため)
            if (bfCustRateGrpCodeIsZero)
            {
                bfRetList = RemoveBfRateNullRecord(bfRetList);
            }

            // ADD BLINCIDENT-2384 2021/09/06 ---------------------------------------------------<<<<<

            // 読み件数
            _stockQuoteData.ReadCount = bfRetList.Count;

            // 引用先情報
            ArrayList afRetList = new ArrayList();

            status = this.getAfRateData(ref afRetList);

            // エラーの場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                msg = "保存処理が失敗します。";
                return status;
            }

            // 追加、更新データを取得する
            ArrayList updateList = new ArrayList();
            ArrayList insertList = new ArrayList();
            ArrayList deleteList = new ArrayList();

            this.DivisionArrayList(bfRetList, afRetList, ref updateList, ref insertList, ref deleteList);

            object paraInsertList = (object)insertList;
            object paraUpdateList = (object)updateList;
            object paraDeleteList = (object)deleteList;

            if (_stockQuoteData.UpdateDistinctionCode == 0)
            {
                // 追加・更新の場合
                status = _rateQuoteDB.Update(ref paraInsertList, ref paraUpdateList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockQuoteData.ProcessCount = insertList.Count + updateList.Count;
                }
            }
            else
            {
                // 更新情報がないの場合
                // 2009/06/09　対応した　追加の場合、論理削除区分データ更新しない
                // if (insertList.Count == 0 && deleteList.Count == 0)
                if (insertList.Count == 0)
                {
                    msg = "該当データが存在しません。";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    this._stockQuoteData.ProcessCount = 0;
                }
                else
                {
                    status = _rateQuoteDB.Write(ref paraInsertList, ref paraDeleteList);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._stockQuoteData.ProcessCount = insertList.Count;
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 引用元
        /// </summary>
        /// <param name="rateList">掛率マスタ</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int getBfRateData(ref ArrayList rateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList retList = new ArrayList();

            // 引数設定
            Rate rate = new Rate();
            string errMsg = null;
            // 企業コード
            rate.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            rate.SectionCode = this._stockQuoteData.BfSectionCode;
            // 得意先コード
            rate.CustomerCode = this._stockQuoteData.BfCustomerCode;
            // 得意先掛率グループ
            rate.CustRateGrpCode = this._stockQuoteData.BfCustRateGrpCode;

            rate.UnitPriceKind = string.Empty;
            // 論理削除区分
            rate.LogicalDeleteCode = 0;

            status = _rateAcs.SearchAll(out retList, ref rate, out errMsg);

            // 検索時、エラーを発生する
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 情報を取得する
                foreach (Rate rateData in retList)
                {
                    if (rateData.LogicalDeleteCode == 0 && !rateData.RateMngGoodsCd.Equals("A"))
                    {
                        // 対象区分が”売上・価格”の場合
                        if (this._stockQuoteData.ObjectDistinctionCode == 0)
                        {
                            if (("1".Equals(rateData.UnitPriceKind) || "3".Equals(rateData.UnitPriceKind)) && (rateData.CustRateGrpCode == this._stockQuoteData.BfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // 対象区分が”売上のみ”の場合
                        else if (this._stockQuoteData.ObjectDistinctionCode == 1)
                        {
                            if ("1".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.BfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // 対象区分がが”価格のみ”の場合
                        else
                        {
                            if ("3".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.BfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                    }
                }
            }

            // ステータス
            if (rateList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 引数の掛率リストについて、掛率設定区分（得意先）が「3(得意先掛率G+仕入先)」と「4(得意先掛率G)」以外のレコードを取り除く
        /// </summary>
        /// <param name="rate">掛率マスタ</param>
        /// <returns>取り除いた結果のArrayList</returns>
        /// <remarks>
        /// <br>Note       : BLINCIDENT-2384 2021/09/06</br>
        /// <br>Programmer : 鈴木創</br>
        /// <br>Date       : 2021.09.06</br>
        /// </remarks>
        private ArrayList RemoveBfRateNullRecord(ArrayList rate)
        {
            ArrayList ret = new ArrayList();

            foreach (Rate r in rate)
            {

                // 得意先掛率グループコードが0以外の場合スキップ
                if (r.CustRateGrpCode != 0) continue;

                // 掛率設定区分（得意先）が「3(得意先掛率G+仕入先)」と「4(得意先掛率G)」以外の場合スキップ
                if (r.RateMngCustCd != "3" & r.RateMngCustCd != "4") continue;

                // 返却用リストに追加
                ret.Add(r);

            }

            return ret;
        }

        /// <summary>
        /// 引用先
        /// </summary>
        /// <param name="rateList">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int getAfRateData(ref ArrayList rateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList retList = new ArrayList();

            // 引数設定
            Rate rate = new Rate();
            string errMsg = null;
            // 企業コード
            rate.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            rate.SectionCode = this._stockQuoteData.AfSectionCode;
            // 得意先コード
            rate.CustomerCode = this._stockQuoteData.AfCustomerCode;
            // 得意先掛率グループ
            rate.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;
            // 単価区分
            rate.UnitPriceKind = string.Empty;

            status = _rateAcs.SearchAll(out retList, ref rate, out errMsg);

            // 検索時、エラーを発生する
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 情報を取得する
                foreach (Rate rateData in retList)
                {
                    if (!rateData.RateMngGoodsCd.Equals("A"))
                    {
                        // 対象区分が”売上・価格”の場合
                        if (this._stockQuoteData.ObjectDistinctionCode == 0)
                        {
                            if (("1".Equals(rateData.UnitPriceKind) || "3".Equals(rateData.UnitPriceKind))
                                && (rateData.CustRateGrpCode == this._stockQuoteData.AfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // 対象区分が”売上のみ”の場合
                        else if (this._stockQuoteData.ObjectDistinctionCode == 1)
                        {
                            if ("1".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.AfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // 対象区分がが”価格のみ”の場合
                        else
                        {
                            if ("3".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.AfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                    }
                }
            }

            // ステータス
            if (rateList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 更新データ作成する
        /// </summary>
        /// <param name="bfRateList">引用元データ</param>
        /// <param name="afRateList">引用先データ</param>
        /// <param name="updateList">更新データ</param>
        /// <param name="insertList">新規データ</param>
        /// <param name="deleteList">論理削除データ</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void DivisionArrayList(ArrayList bfRateList, ArrayList afRateList, ref ArrayList updateList, ref ArrayList insertList, ref ArrayList deleteList)
        {
            // 引用元データが存在しない場合
            if (bfRateList == null || bfRateList.Count == 0) return;

            // 引用先データが存在しない場合
            if (afRateList == null || afRateList.Count == 0)
            {
                foreach (Rate bfRate in bfRateList)
                {
                    insertList.Add(RateConvert(bfRate));
                }
                return;
            }

            // 両方が存在時
            foreach(Rate bfRate in bfRateList)
            {
                // 掛率設定区分取得
                string rateMngGoodsCd = bfRate.RateMngGoodsCd;

                bool isExist = false;

                switch (rateMngGoodsCd)
                {
                    // ↓ 2009.06.18 劉洋 modify ロット数削除
                    case "A":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品番号、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsNo.Equals(bfRate.GoodsNo) && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }

                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品番号」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsNo.Equals(bfRate.GoodsNo))
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "B":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率ランク、BL商品コード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode && afRate.LotCount == bfRate.LotCount
                                        && afRate.GoodsNo.Equals(bfRate.GoodsNo))
                                        // && bfRate.SupplierCd == afRate.SupplierCd)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率ランク、BL商品コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode && afRate.GoodsNo.Equals(bfRate.GoodsNo))
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "C":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率ランク、BLグループコード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank)
                                        && afRate.BLGroupCode == bfRate.BLGroupCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率ランク、BLグループコード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank) && afRate.BLGroupCode == bfRate.BLGroupCode)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "D":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、BL商品コード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、BL商品コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "E":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、BLグループコード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGroupCode == bfRate.BLGroupCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、BLグループコード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGroupCode == bfRate.BLGroupCode)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "F":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率グループコード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateGrpCode == bfRate.GoodsRateGrpCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率グループコード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateGrpCode == bfRate.GoodsRateGrpCode)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "G":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率ランク、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank) && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、商品掛率ランク」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank))
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "H":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、ＢＬコード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGoodsCode == afRate.BLGoodsCode
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、ＢＬコード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGoodsCode == afRate.BLGoodsCode)
                                    // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "I":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、BLグループコード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGroupCode == afRate.BLGroupCode
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、BLグループコード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGroupCode == afRate.BLGroupCode)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "J":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品掛率グループコード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsRateGrpCode.Equals(afRate.GoodsRateGrpCode)
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品掛率グループコード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsRateGrpCode.Equals(afRate.GoodsRateGrpCode))
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "K":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、商品メーカーコード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    case "L":
                        {
                            // 単価掛率設定区分変換
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // 判断
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分、仕入先コード」
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // 「変換した単価掛率設定区分」
                                    if (result.Equals(afRate.UnitRateSetDivCd))
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // 更新リスト
                                        updateList.Add(rateWork);
                                        // 論理削除リスト
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // 論理削除フラグ
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // ↓ 2009.06.18 劉洋 add
                                        break;
                                        // ↑ 2009.06.18 劉洋 add
                                    }
                                }
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                    // ↑ 2009.06.18 劉洋 modify
                }

                // 存在しない場合、追加する
                if (!isExist)
                {
                    // 新規リスト
                    insertList.Add(RateConvert(bfRate));
                }
            }
        }

        /// <summary>
        /// データ変換
        /// </summary>
        /// <param name="rate">掛率マスタ</param>
        /// <returns>掛率マスタ</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private RateWork RateConvert(Rate rate)
        {
            RateWork result = new RateWork();

            // 変換
            result = this.CopyToRateWorkFromRate(rate);
            // 拠点コード
            result.SectionCode = this._stockQuoteData.AfSectionCode;
            // ↓ 2009.07.22 劉洋 modify
            // 得意先掛率マスタ
            // result.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046----------------------------------------->>>>>
            //if (!string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName))
            //{
            //    result.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;
            //}
            //else
            //{
            //    result.CustRateGrpCode = rate.CustRateGrpCode;
            //}
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046-----------------------------------------<<<<<
            // 得意先掛率マスタ
            result.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;// ADD By chenyd 2013/03/18 For Redmine #35046

            // 得意先コード
            // result.CustomerCode = this._stockQuoteData.AfCustomerCode;
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046----------------------------------------->>>>>
            //if (this._stockQuoteData.AfCustomerCode != 0)
            //{
            //    result.CustomerCode = this._stockQuoteData.AfCustomerCode;
            //}
            //else
            //{
            //    result.CustomerCode = rate.CustomerCode;
            //}
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046-----------------------------------------<<<<<
            // ↑ 2009.07.22 劉洋 modify
            
            // 得意先コード
            result.CustomerCode = this._stockQuoteData.AfCustomerCode;// ADD By chenyd 2013/03/18 For Redmine #35046

            // 引用元の得意先　⇒　引用先の得意先掛率グループ
            if (this._stockQuoteData.BfCustomerCode != 0 && !string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName))
            {
                string value = rate.UnitRateSetDivCd.Substring(1, 1);
                if ("1".Equals(value))
                {
                    // 単価掛率設定区分
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "3" + rate.UnitRateSetDivCd.Substring(2);
                    // 掛率設定区分
                    result.RateSettingDivide = "3" + rate.RateSettingDivide.Substring(1);
                    // 掛率設定区分（得意先）
                    result.RateMngCustCd = "3";
                    // 掛率設定名称（得意先）
                    result.RateMngCustNm = "得意先掛率G+仕入先";
                }
                else if ("2".Equals(value))
                {
                    // 単価掛率設定区分
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "4" + rate.UnitRateSetDivCd.Substring(2);
                    // 掛率設定区分
                    result.RateSettingDivide = "4" + rate.RateSettingDivide.Substring(1);
                    // 掛率設定区分（得意先）
                    result.RateMngCustCd = "4";
                    // 掛率設定名称（得意先）
                    result.RateMngCustNm = "得意先掛率G";
                }
            }
            // 引用元の得意先掛率グループ　⇒　引用先の得意先
            else if (!string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName) && this._stockQuoteData.AfCustomerCode != 0)
            {
                string value = rate.UnitRateSetDivCd.Substring(1, 1);
                if ("3".Equals(value))
                {
                    // 単価掛率設定区分
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "1" + rate.UnitRateSetDivCd.Substring(2);
                    // 掛率設定区分
                    result.RateSettingDivide = "1" + rate.RateSettingDivide.Substring(1);
                    // 掛率設定区分（得意先）
                    result.RateMngCustCd = "1";
                    // 掛率設定名称（得意先）
                    result.RateMngCustNm = "得意先+仕入先";
                }
                else if ("4".Equals(value))
                {
                    // 単価掛率設定区分
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "2" + rate.UnitRateSetDivCd.Substring(2);
                    // 掛率設定区分
                    result.RateSettingDivide = "2" + rate.RateSettingDivide.Substring(1);
                    // 掛率設定区分（得意先）
                    result.RateMngCustCd = "2";
                    // 掛率設定名称（得意先）
                    result.RateMngCustNm = "得意先";
                }
            }

            return result;
        }

        /// <summary>
        /// 単価掛率設定区分変換
        /// </summary>
        /// <param name="unitRateSetDivCd">単価掛率設定区分</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string UnitRateSetDivCdConvert(string unitRateSetDivCd)
        {
            string result = unitRateSetDivCd;

            // 引用元の得意先　⇒　引用先の得意先掛率グループ
            if (this._stockQuoteData.BfCustomerCode != 0 && !string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName))
            {
                string value = unitRateSetDivCd.Substring(1, 1);
                if ("1".Equals(value))
                {
                    // 単価掛率設定区分
                    result = unitRateSetDivCd.Substring(0, 1) + "3" + unitRateSetDivCd.Substring(2);
                }
                else if ("2".Equals(value))
                {
                    // 単価掛率設定区分
                    result = unitRateSetDivCd.Substring(0, 1) + "4" + unitRateSetDivCd.Substring(2);
                }
            }
            // 引用元の得意先掛率グループ　⇒　引用先の得意先
            else if (!string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName) && this._stockQuoteData.AfCustomerCode != 0)
            {
                string value = unitRateSetDivCd.Substring(1, 1);
                if ("3".Equals(value))
                {
                    // 単価掛率設定区分
                    result = unitRateSetDivCd.Substring(0, 1) + "1" + unitRateSetDivCd.Substring(2);
                }
                else if ("4".Equals(value))
                {
                    // 単価掛率設定区分
                    result = unitRateSetDivCd.Substring(0, 1) + "2" + unitRateSetDivCd.Substring(2);
                }
            }

            return result;
        }


        /// <summary>
        /// クラスメンバーコピー処理（掛率設定クラス⇒掛率設定ワーククラス）
        /// </summary>
        /// <param name="rate">掛率設定クラス</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定クラスから掛率設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            // 作成日時
            rateWork.CreateDateTime = rate.CreateDateTime;
            // 更新日時
            rateWork.UpdateDateTime = rate.UpdateDateTime;
            // 企業コード
            rateWork.EnterpriseCode = rate.EnterpriseCode;
            // GUID
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;
            // 更新従業員コード
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;
            // 更新アセンブリID1
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
            // 更新アセンブリID2
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
            // 論理削除区分
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;
            // 拠点コード
            rateWork.SectionCode = rate.SectionCode;
            // 単価掛率設定区分
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;
            // 単価種類
            rateWork.UnitPriceKind = rate.UnitPriceKind;
            // 掛率設定区分
            rateWork.RateSettingDivide = rate.RateSettingDivide;
            // 掛率設定区分（商品）
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;
            // 掛率設定名称（商品）
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;
            // 掛率設定区分（得意先）
            rateWork.RateMngCustCd = rate.RateMngCustCd;
            // 掛率設定名称（得意先）
            rateWork.RateMngCustNm = rate.RateMngCustNm;
            // 商品メーカーコード
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;
            // 商品番号
            rateWork.GoodsNo = rate.GoodsNo;
            // 商品掛率ランク
            rateWork.GoodsRateRank = rate.GoodsRateRank;
            // BL商品コード
            rateWork.BLGoodsCode = rate.BLGoodsCode;
            // 得意先コード
            rateWork.CustomerCode = rate.CustomerCode;
            // 得意先掛率グループコード
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;
            // 仕入先コード
            rateWork.SupplierCd = rate.SupplierCd;
            // ロット数
            rateWork.LotCount = rate.LotCount;
            // 価格
            rateWork.PriceFl = rate.PriceFl;
            // 掛率
            rateWork.RateVal = rate.RateVal;
            // 単価端数処理単位
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;
            // 単価端数処理区分
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;
            // 商品掛率グループコード
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;
            // BLグループコード
            rateWork.BLGroupCode = rate.BLGroupCode;
            // UP率
            rateWork.UpRate = rate.UpRate;
            // 粗利確保率
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;

            return rateWork;
        }
        #endregion
    }
}
