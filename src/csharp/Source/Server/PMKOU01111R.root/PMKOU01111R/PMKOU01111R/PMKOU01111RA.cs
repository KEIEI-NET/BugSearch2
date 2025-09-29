//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入月次集計データ更新リモートオブジェクト
//                  :   PMKOU01111R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.12.12
//----------------------------------------------------------------------
// Update Note      :　 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④
//                             ・一括リアル更新の新規を対応
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

using System.Collections.Generic; // ADD 2010/03/30

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入月次集計データ更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入月次集計データ更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.04 月次集計データMANTIS対応</br>
    /// <br>Update Note: 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>                ・一括リアル更新の新規を対応</br>
    /// <br>Update Note: 2010/02/24 長内 一括リアル更新 速度アップ対応</br>
    /// <br>                ・スタンドアローンマシンで実行した場合に、ＣＰＵ負荷がかかるため、</br>
    /// <br>                  １か月単位に処理するように修正</br>
    /// <br>Update Note: 2010/03/04 鈴木 正臣 一括リアル更新 タイムアウトエラー対応</br>
    /// <br>                ・既存の集計レコードを削除する際のタイムアウト値を変更</br>
    /// <br>                　（ユーザーデータの売上側でエラーになる場合があった為、変更する）</br>
    /// <br>Update Note: 2010/03/30 長内 数馬 一括リアル更新 速度アップ対応</br>
    /// </remarks>
    [Serializable]
    public class MonthlyTtlStockUpdDB : RemoteWithAppLockDB, IMonthlyTtlStockUpdDB
    {
        /// <summary>
        /// 仕入月次集計データ更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public MonthlyTtlStockUpdDB()
            : base("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockSlipWork", "MTTLSTOCKSLIPRF")
        {

        }

        /// <summary>
        /// アプリケーション ロックを行う際のリソース名を取得します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <returns>ロック リソース名</returns>
        private string GetLockResourceName(MTtlStockUpdParaWork mTtlStockUpdParaWork)
        {
            return this.GetResourceName(mTtlStockUpdParaWork.EnterpriseCode);
        }

        private CompanyInfWork _CompanyInfWork = null;

        private CompanyInfWork GetCompanyInformation(string enterpriseCode)
        {
            if (this._CompanyInfWork == null)
            {
                CompanyInfDB companyInfDB = new CompanyInfDB();

                CompanyInfWork companyInfWork = new CompanyInfWork();

                companyInfWork.EnterpriseCode = enterpriseCode;
                companyInfWork.CompanyCode = 0;

                byte[] paraByte = XmlByteSerializer.Serialize(companyInfWork);

                int status = companyInfDB.Read(ref paraByte, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._CompanyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(paraByte, typeof(CompanyInfWork));
                }
            }

            return this._CompanyInfWork;
        }

        # region [登録・更新処理]

        /// <summary>
        /// 指定された条件に基づいて、仕入月次集計データを追加・更新します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <param name="newStockSlips">追加・更新する仕入伝票データ</param>
        /// <param name="oldStockSlips">登録前の仕入伝票データ</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、仕入月次集計データを追加・更新します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        public int Write(MTtlStockUpdParaWork mTtlStockUpdParaWork, ArrayList newStockSlips, ArrayList oldStockSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [パラメーターチェック]

            if (mTtlStockUpdParaWork == null)
            {
                return status;
            }

            if (newStockSlips == null)
            {
                return status;
            }

            // 本メソッド内で SqlConnection を生成した場合は true を設定
            bool CreatedConnection = false;

            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);

                if (connection == null)
                {
                    return status;
                }
                else
                {
                    CreatedConnection = true;
                }
            }

            // 本メソッド内で SqlTransaction を生成した場合は true を設定
            bool CreatedTransaction = false;

            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);

                if (transaction == null)
                {
                    return status;
                }
                else
                {
                    CreatedTransaction = true;
                }
            }

            # endregion

            // 排他ロックを行う
            status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            try
            {
                ArrayList totaledStockSlips = null;

                // 仕入伝票データ 事前集計処理
                status = this.PreTotal(newStockSlips, oldStockSlips, out totaledStockSlips);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }


                if (ListUtils.IsNotEmpty(totaledStockSlips))
                {
                    // 仕入月次集計データ更新処理
                    status = this.WriteMTtlStock(mTtlStockUpdParaWork, totaledStockSlips, connection, transaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                }
            }
            finally
            {
                // 排他ロックを解放する ※戻り値はスルー
                this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

                if (CreatedTransaction)
                {
                    if (transaction != null)
                    {
                        if (transaction.Connection != null)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 正常終了の場合はコミット
                                transaction.Commit();
                            }
                            else
                            {
                                // 異常終了の場合はロールバック
                                transaction.Rollback();
                            }
                        }

                        transaction.Dispose();
                    }
                }

                if (CreatedConnection)
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入伝票データ 事前集計処理
        /// </summary>
        /// <param name="newStockSlips">登録後の仕入伝票データ</param>
        /// <param name="oldStockSlips">登録前の仕入伝票データ</param>
        /// <param name="ttlStockSlips">事前集計後の仕入伝票データ</param>
        /// <returns>STATUS</returns>
        private int PreTotal(ArrayList newStockSlips, ArrayList oldStockSlips, out ArrayList ttlStockSlips)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ttlStockSlips = new ArrayList();

            try
            {
                ArrayList newSlip = null;          // 登録後 仕入伝票データ(仕入データ＋仕入明細データ)
                StockSlipWork newHeader = null;    // 登録後 仕入データ
                ArrayList newDetails = null;       // 登録後 仕入明細データ(全明細分)

                StockSlipWork oldHeader = null;    // 登録前 仕入データ
                ArrayList oldDetails = null;       // 登録前 仕入明細データ(全明細分)

                // 更新後の"仕入データ"から集計対象を抽出
                if (ListUtils.IsNotEmpty(newStockSlips))
                {
                    foreach (object item in newStockSlips)
                    {
                        if (item is ArrayList)
                        {
                            newHeader = ListUtils.Find((item as ArrayList), typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                            newDetails = ListUtils.Find((item as ArrayList), typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (newHeader != null && newDetails != null && newHeader.SupplierFormal == 0)
                            {
                                ArrayList clnSlip = new ArrayList();  // 仕入情報
                                ArrayList clnDtls = new ArrayList();  // 仕入明細情報リスト
                                ArrayList clnAdds = new ArrayList();  // 明細追加情報リスト(ダミー)

                                //newHeader = newHeader.Clone();
                                clnSlip.Add(newHeader.Clone());
                                clnSlip.Add(clnDtls);
                                clnSlip.Add(clnAdds);

                                foreach (StockDetailWork newDetail in newDetails)
                                {
                                    //// 仕入伝票区分(明細)が 0:仕入 1:返品 2:値引 の明細だけを集計対象とする
                                    //仕入形式が0:仕入の明細だけを集計対象とする
                                    switch (newDetail.StockSlipCdDtl)
                                    {
                                        case 0:  // 仕入
                                        case 1:  // 返品
                                        case 2:  // 値引
                                            {
                                                StockDetailWork clnDetail = newDetail.Clone();
                                                //clnDetail.ShipmCntDifference = 0;
                                                clnDetail.StockCountDifference = 0;
                                                clnDtls.Add(clnDetail);
                                                break;
                                            }
                                    }
                                }

                                ttlStockSlips.Add(clnSlip);
                            }
                        }
                    }
                }

                // 更新前の仕入データが存在する場合にのみ事前集計を行う
                if (ListUtils.IsNotEmpty(oldStockSlips))
                {
                    StockHeaderComparer StockHdrComp = new StockHeaderComparer();
                    StockHeaderComparer2 StockHdrComp2 = new StockHeaderComparer2();
                    StockDetailComparer StockDtlComp = new StockDetailComparer();

                    foreach (ArrayList oldslip in oldStockSlips)
                    {
                        if (ListUtils.IsNotEmpty(oldslip))
                        {
                            oldHeader = ListUtils.Find(oldslip, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                            oldDetails = ListUtils.Find(oldslip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (oldHeader != null && oldDetails != null && oldHeader.SupplierFormal == 0)
                            {
                                if (oldHeader.DebitNoteDiv == 2)
                                {
                                    // 元黒は集計対象から除外する
                                    continue;
                                }

                                ttlStockSlips.Sort(StockHdrComp);
                                int stockIndex = ttlStockSlips.BinarySearch(oldslip, StockHdrComp);
                                ttlStockSlips.Sort(StockHdrComp2);
                                int stockIndex2 = ttlStockSlips.BinarySearch(oldslip, StockHdrComp2);

                                if (stockIndex2 > -1)
                                {
                                    // 同一キーの仕入伝票データが存在する場合
                                    newSlip = ttlStockSlips[stockIndex2] as ArrayList;
                                    newHeader = ListUtils.Find(newSlip, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                                    newDetails = ListUtils.Find(newSlip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                                    foreach (StockDetailWork oldDetail in oldDetails)
                                    {
                                        newDetails.Sort(StockDtlComp);
                                        //int hdrComp = StockHdrComp.Compare(oldHeader, newHeader);
                                        int detailIndex = newDetails.BinarySearch(oldDetail, StockDtlComp);

                                        if (detailIndex > -1)
                                        //if (hdrComp == 0 && detailIndex > -1)
                                        {
                                            // 同一キーの仕入明細データが存在する場合 → 明細の内容が変更された or 何も変わっていない
                                            StockDetailWork newDetail = newDetails[detailIndex] as StockDetailWork;

                                            newDetail.StockCount -= oldDetail.StockCount;                // 出荷数 の変動差分値を算出する
                                            newDetail.StockPriceTaxExc -= oldDetail.StockPriceTaxExc;    // 仕入金額(税抜) の変動差分値を算出する

                                            newDetail.StockCountDifference = 1;                          // <重要> 出荷差分数に 1 を設定する事により、"登録済み明細"とする
                                        }
                                        else
                                        {
                                            // 同一キーの仕入明細データが存在しない場合 → 明細が削除された
                                            //// 仕入伝票区分(明細)が 0:仕入 1:返品 2:値引 の明細だけを集計対象とする
                                            //仕入形式が0:仕入の明細だけを集計対象とする
                                            switch (oldDetail.StockSlipCdDtl)
                                            {
                                                case 0:  // 仕入
                                                case 1:  // 返品
                                                case 2:  // 値引
                                                    {
                                                        StockDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.StockCount *= -1;                                  // 出荷数 の符号を反転させる
                                                        clnDetail.StockPriceTaxExc *= -1;                            // 仕入金額(税抜) の符号を反転させる

                                                        clnDetail.StockCountDifference = -1;                         // <重要> 出荷差分数に -1 を設定する事により、"削除された明細"とする
                                                        newDetails.Add(clnDetail);                                   // 削除された分として追加する
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                else if (stockIndex > -1) // ヘッダ情報が変更された場合
                                {
                                    ArrayList clnSlip = new ArrayList();  // 仕入情報
                                    ArrayList clnDtls = new ArrayList();  // 仕入明細情報リスト
                                    ArrayList clnAdds = new ArrayList();  // 明細追加情報リスト(ダミー) 

                                    // 同一キーの仕入伝票データが存在する場合
                                    newSlip = ttlStockSlips[stockIndex] as ArrayList;

                                    clnSlip.Add(oldHeader.Clone());
                                    clnSlip.Add(clnDtls);
                                    clnSlip.Add(clnAdds);

                                    //StockSlipWork wrkHeader = oldHeader.Clone();
                                    newDetails = ListUtils.Find(newSlip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                                    //wrkSlip.Add(wrkHeader);
                                    foreach (StockDetailWork oldDetail in oldDetails)
                                    {
                                        //newDetails.Sort(StockDtlComp);
                                        //int detailIndex = newDetails.BinarySearch(oldDetail, StockDtlComp);

                                        //if (detailIndex > -1)
                                        //{
                                        //    // 同一キーの仕入明細データが存在する場合 → 明細の内容が変更された or 何も変わっていない
                                        //    StockDetailWork newDetail = newDetails[detailIndex] as StockDetailWork;
                                        //    StockDetailWork clnDetail = newDetail.Clone();
                                        //    //newDetail.ShipmentCnt -= oldDetail.ShipmentCnt;            // 出荷数 の変動差分値を算出する
                                        //    //newDetail.Cost -= oldDetail.Cost;                          // 原価 の変動差分値を算出する
                                        //    //newDetail.SalesMoneyTaxExc -= oldDetail.SalesMoneyTaxExc;  // 売上金額(税抜) の変動差分値を算出する
                                        //    clnDetail.StockCount -= oldDetail.StockCount;                // 出荷数 の変動差分値を算出する
                                        //    //newDetail.Cost -= oldDetail.Cost;                          // 原価 の変動差分値を算出する
                                        //    clnDetail.StockPriceTaxExc -= oldDetail.StockPriceTaxExc;    // 仕入金額(税抜) の変動差分値を算出する

                                        //    clnDetail.StockCountDifference = 1;                          // <重要> 出荷差分数に 1 を設定する事により、"登録済み明細"とする

                                        //    clnDtls.Add(clnDetail);
                                        //}
                                        //else
                                        //{
                                        // 同一キーの仕入明細データが存在しない場合 → 明細が削除された
                                        //// 仕入伝票区分(明細)が 0:仕入 1:返品 2:値引 の明細だけを集計対象とする
                                        //仕入形式が0:仕入の明細だけを集計対象とする
                                        switch (oldDetail.StockSlipCdDtl)
                                        {
                                            case 0:  // 仕入                                            
                                            case 1:  // 返品
                                            case 2:  // 値引
                                                {
                                                    StockDetailWork clnDetail = oldDetail.Clone();

                                                    clnDetail.StockCount *= -1;                                  // 出荷数 の符号を反転させる
                                                    clnDetail.StockPriceTaxExc *= -1;                            // 仕入金額(税抜) の符号を反転させる

                                                    clnDetail.StockCountDifference = -1;                         // <重要> 出荷差分数に -1 を設定する事により、"削除された明細"とする

                                                    clnDtls.Add(clnDetail);                                   // 削除された分として追加する
                                                    break;
                                                }
                                        }
                                        //}
                                    }

                                    ttlStockSlips.Add(clnSlip);
                                }
                                else
                                {
                                    // 登録前 仕入伝票データが、登録後 仕入伝票データの中に含まれていない場合、伝票削除として扱う。
                                    ArrayList wrkSlip = new ArrayList();
                                    ArrayList wrkDetails = new ArrayList();

                                    StockSlipWork wrkHeader = oldHeader.Clone();
                                    //oldHeader = oldHeader.Clone();

                                    //wrkSlip.Add(oldHeader);
                                    wrkSlip.Add(wrkHeader);
                                    wrkSlip.Add(wrkDetails);

                                    foreach (StockDetailWork oldDetail in oldDetails)
                                    {
                                        //// 仕入伝票区分(明細)が 0:仕入 1:返品 2:値引 の明細だけを集計対象とする
                                        //仕入形式が0:仕入の明細だけを集計対象とする
                                        switch (oldDetail.StockSlipCdDtl)
                                        {
                                            case 0:  // 仕入                                            
                                            case 1:  // 返品
                                            case 2:  // 値引
                                                {
                                                    StockDetailWork clnDetail = oldDetail.Clone();
                                                    clnDetail.StockCountDifference = 0;                              // <重要> 伝票削除の場合には出荷差分数に 0 を設定する(後述処理の辻褄合わせ)
                                                    wrkDetails.Add(clnDetail);
                                                    break;
                                                }
                                        }
                                    }

                                    ttlStockSlips.Add(wrkSlip);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// 仕入月次集計データ 集計・登録処理
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <param name="totaledStockSlips">事前集計済み仕入伝票データリスト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <remarks>事前集計を終えた仕入伝票データを集計し、仕入月次集計データへ追加・更新を行います。</remarks>
        /// <returns>STATUS</returns>
        private int WriteMTtlStock(MTtlStockUpdParaWork mTtlStockUpdParaWork, ArrayList totaledStockSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 日付取得部品のインスタンスを取得
            FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlStockUpdParaWork.EnterpriseCode));

            // 仕入月次集計データ比較用クラスのインスタンスを取得
            MTtlStockSlipComparer mTtlStockSlipComparer = new MTtlStockSlipComparer();

            // 伝票登録時には加算、伝票削除時には減算を行う
            int sign = (mTtlStockUpdParaWork.SlipRegDiv == 0) ? -1 : 1;

            # region [仕入月次集計処理]
            foreach (ArrayList slip in totaledStockSlips)
            {
                // 登録・更新対象となる仕入月次集計データを保持する配列
                // -- UPD 2010/03/30 ------------------<<<
                //ArrayList MTtlStockList = new ArrayList();
                Dictionary<string, MTtlStockSlipWork> MTtlStockDic = new Dictionary<string, MTtlStockSlipWork>();
                // -- UPD 2010/03/30 ------------------<<<
                MTtlStockSlipWork mTtlStockSlipWork = null;

                StockSlipWork header = ListUtils.Find(slip, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                ArrayList details = ListUtils.Find(slip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                if (header == null || ListUtils.IsEmpty(details))
                {
                    continue;
                }

                foreach (StockDetailWork detail in details)
                {
                    // [使用フラグ(0:登録不可 1:実績集計区分クリア 2:従業員コードクリア 3:登録可能), 仕入月次集計データ] を持つ２次元配列を生成
                    // 売上月次集計は従業員区分(3)*実績集計区分(4)=12だが、仕入には実績集計区分(3)しかない。
                    object[,] MTtlStockSlipArray = new object[3, 2];
                    //object[,] MTtlStockSlipArray = new object[12, 2];

                    for (int index = 0; index < MTtlStockSlipArray.GetLength(0); index++)
                    {
                        mTtlStockSlipWork = new MTtlStockSlipWork();

                        # region [キー項目の設定]
                        // キー項目の設定
                        MTtlStockSlipArray[index, 0] = 0;
                        MTtlStockSlipArray[index, 1] = mTtlStockSlipWork;

                        mTtlStockSlipWork.EnterpriseCode = detail.EnterpriseCode;        // 企業コード
                        mTtlStockSlipWork.LogicalDeleteCode = detail.LogicalDeleteCode;  // 論理削除フラグ
                        //mTtlStockSlipWork.AddUpSecCode = header.ResultsAddUpSecCd;       // 計上拠点コード ← 実績計上拠点コード
                        mTtlStockSlipWork.StockSectionCd = header.StockSectionCd;

                        // 実績集計区分 (0:合計 1:在庫 2:純正)
                        mTtlStockSlipWork.RsltTtlDivCd = index; //(int)index / 3;

                        switch (mTtlStockSlipWork.RsltTtlDivCd)
                        {
                            case 0:
                                {
                                    // 2009/03/04 MANTIS 11429-1>>>>>>>>>>>>
                                    // 合計入力も実績に登録するように修正
                                    //// 仕入商品区分 = 0:商品
                                    //if (detail.StockGoodsCd == 0)
                                    // 仕入商品区分 = 0:商品,6:合計入力
                                    if (detail.StockGoodsCd == 0 || detail.StockGoodsCd == 6)
                                    {
                                        MTtlStockSlipArray[index, 0] = 1;
                                    }
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<< 
                                    break;
                                }
                            case 1:
                                {
                                    //// 在庫更新区分
                                    //if (detail.StockUpdateDiv)

                                    // 商品値引は在庫の場合でも集計するため、以下のように修正する。(2009/01/19)

                                    // 在庫管理する条件
                                    // ① 倉庫コードが設定されている
                                    // ② 仕入在庫取寄せ区分が 1:在庫
                                    // ③ 仕入数が0以外
                                    // ④ 仕入伝票区分(明細)が 0:売上 1:返品 2:商品値引の場合
                                    // (仕入数が0以外の判断により結局仕入伝票区分(明細)の判断は不要)

                                    if (!string.IsNullOrEmpty(detail.WarehouseCode) &&
                                        detail.StockOrderDivCd == 1 &&
                                        detail.StockCount != 0)
                                    {
                                        MTtlStockSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    // 商品属性 = 0:純正
                                    if (detail.GoodsKindCode == 0)
                                    {
                                        MTtlStockSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            //case 3:
                            //    {
                            //        // 売上伝票区分(明細) = 1:作業
                            //        if (detail.SalesSlipCdDtl == 1)
                            //        {
                            //            MTtlStockSlipArray[index, 0] = 1;
                            //        }
                            //        break;
                            //    }
                        }
                        // 従業員コード
                        mTtlStockSlipWork.EmployeeCode = header.StockAgentCode; // 仕入担当者コード
                        MTtlStockSlipArray[index, 0] = ((int)MTtlStockSlipArray[index, 0]) + 2; // 登録可能にする

                        //mTtlStockSlipWork.CustomerCode = header.CustomerCode;  // 得意先コード
                        mTtlStockSlipWork.SupplierCd = header.SupplierCd;      // 仕入先コード
                        //mTtlStockSlipWork.SalesCode = detail.SalesCode;        // 販売区分コード

                        # endregion

                        # region [集計項目の設定]
                        if ((int)MTtlStockSlipArray[index, 0] == 3)
                        {
                            // 仕入日より自社締の年月度を取得 ※負担が掛る事が予想されるため、登録可能なレコードにのみ設定する
                            DateTime AddUpDate;
                            //dateGetAcs.GetYearMonth(detail.SalesDate, out AddUpDate);
                            //mTtlStockSlipWork.AddUpYearMonth = AddUpDate;                    // 計上年月
                            //dateGetAcs.GetYearMonth(header.StockAddUpADate, out AddUpDate); // 仕入計上日付   // DEL 2009/12/24
                            dateGetAcs.GetYearMonth(header.StockDate, out AddUpDate); // 仕入日     // ADD 2009/12/24
                            mTtlStockSlipWork.StockDateYm = AddUpDate;              // 仕入年月

                            //// 出荷回数
                            //if (header.DebitNoteDiv == 0 && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)
                            //{
                            //    if (detail.StockCountDifference != 1)
                            //    {
                            //        // 明細登録の場合は加算、明細削除の場合は減算を行う
                            //        int value = (detail.StockCountDifference == 0) ? 1 : -1;

                            //        // "仕入"の明細のみを集計の対象とします、また伝票削除時には減算します
                            //        mTtlStockSlipWork.SalesTimes += sign * value;  // 出荷回数
                            //    }
                            //}

                            // 仕入数計
                            //if (header.DebitNoteDiv == 0 && detail.SalesSlipCdDtl == 0)
                            // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // 赤伝、商品値引き時に数量が減算されない不具合の修正 MANTIS 11430
                            // 合計入力時に数量がカウントされる不具合の修正 MANTIS 11429-2
                            //if (header.DebitNoteDiv == 0 && detail.StockSlipCdDtl != 2) // 値引以外をカウントする
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1) && (detail.StockSlipCdDtl == 0 || detail.StockSlipCdDtl == 1 || (detail.StockSlipCdDtl == 2 && detail.StockCount != 0)) && detail.StockGoodsCd == 0) // 値引以外をカウントする // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.StockSlipCdDtl == 0 || detail.StockSlipCdDtl == 1 || (detail.StockSlipCdDtl == 2 && detail.StockCount != 0)) && detail.StockGoodsCd == 0) // 値引以外をカウントする // ADD 2009/12/24
                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                // 仕入リモートから既に逆転した数値がくるため、ここでの反転処理不要
                                //// 仕入伝票区分が 10:仕入 の場合は加算、1:返品 の場合は減算を行う
                                //int value = (header.SupplierSlipCd == 10) ? 1 : -1;

                                //mTtlStockSlipWork.TotalStockCount += sign * value * detail.ShipmentCnt;  // 仕入数計
                                //mTtlStockSlipWork.TotalStockCount += sign * value * detail.StockCount;  // 仕入数計
                                mTtlStockSlipWork.TotalStockCount += sign * detail.StockCount;  // 仕入数計
                            }

                            if (header.SupplierSlipCd == 10) //仕入
                            {
                                switch (detail.StockSlipCdDtl)
                                {
                                    case 0:  // 0:仕入
                                        {
                                            // 仕入金額合計
                                            mTtlStockSlipWork.StockTotalPrice = sign * detail.StockPriceTaxExc;

                                            break;
                                        }
                                    case 1:  // 1:返品
                                        {
                                            // 返品額
                                            mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;

                                            break;
                                        }
                                    case 2:  // 2:値引
                                        {
                                            //if (mTtlStockSlipWork.RsltTtlDivCd == 0 || // 商品合計の場合は全て集計する。
                                            //    (mTtlStockSlipWork.RsltTtlDivCd == 2 && detail.StockCount != 0) )
                                            //    // Mantis 10028 行値引が純正として集計されないようにする。
                                            if (detail.StockCount != 0) // PM7の仕様に合わせ、行値引はリアル更新対象外とする。
                                            {
                                                // 値引金額
                                                mTtlStockSlipWork.StockTotalDiscount = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 仕入の行値引は仕入金額に反映する>>>>>>>>>>
                                            else
                                            {
                                                // 仕入金額合計
                                                mTtlStockSlipWork.StockTotalPrice = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                            
                                            break;
                                        }
                                }
                            }

                            if (header.SupplierSlipCd == 20) //返品
                            {
                                //2009/02/05 >>>>>>>>>>>>>>>>>>>>>>>>>
                                // Mantis 11102の対応 返品伝票の行値引金額を値引き金額にセットする
                                //// 返品額
                                //mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;

                                switch (detail.StockSlipCdDtl)
                                {
                                    case 1: //1:返品
                                        {
                                            // 返品額
                                            mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;

                                            break;
                                        }
                                    case 2: //2:値引
                                        {

                                            //数量≠0 商品値引明細ののみ対象（行値引き明細は対象外とする）
                                            if (detail.StockCount != 0) 
                                            {
                                                // 値引金額
                                                mTtlStockSlipWork.StockTotalDiscount = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 返品の行値引は返品金額に反映する>>>>>>>>>>
                                            else
                                            {
                                                // 返品額
                                                mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                            break;
                                        }
                                }
                                //2009/02/05 <<<<<<<<<<<<<<<<<<<<<<<<<

                            }

                            // -- DEL 2010/03/30 ------------------------>>>
                            //MTtlStockList.Sort(mTtlStockSlipComparer);

                            //int SearchIndex = MTtlStockList.BinarySearch(mTtlStockSlipWork, mTtlStockSlipComparer);
                            // -- DEL 2010/03/30 ------------------------<<<

                            // -- UPD 2010/03/30 ------------------------>>>
                            //if (SearchIndex < 0)
                            //{
                            //    // 同一キーが存在しない場合は登録リストに追加する
                            //    MTtlStockList.Add(mTtlStockSlipWork);
                            //}
                            //else
                            //{
                            //    // 同一キーが存在している場合は集計項目を加算する
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).TotalStockCount += mTtlStockSlipWork.TotalStockCount;
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).StockTotalPrice += mTtlStockSlipWork.StockTotalPrice;
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).StockTotalDiscount += mTtlStockSlipWork.StockTotalDiscount;
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).StockRetGoodsPrice += mTtlStockSlipWork.StockRetGoodsPrice; // ***
                            //}

                            if (!MTtlStockDic.ContainsKey(MakeKeyMTtlStockSlip(mTtlStockSlipWork)))
                            {
                                // 同一キーが存在しない場合は登録リストに追加する
                                MTtlStockDic.Add(MakeKeyMTtlStockSlip(mTtlStockSlipWork), mTtlStockSlipWork);
                            }
                            else
                            {
                                MTtlStockSlipWork work = MTtlStockDic[MakeKeyMTtlStockSlip(mTtlStockSlipWork)];
                                // 同一キーが存在している場合は集計項目を加算する
                                work.TotalStockCount += mTtlStockSlipWork.TotalStockCount;
                                work.StockTotalPrice += mTtlStockSlipWork.StockTotalPrice;
                                work.StockTotalDiscount += mTtlStockSlipWork.StockTotalDiscount;
                                work.StockRetGoodsPrice += mTtlStockSlipWork.StockRetGoodsPrice; 
                            }
                            // -- UPD 2010/03/30 ------------------------<<<

                        }
                        # endregion
                    }
                }

                # region [仕入月次集計データ登録]

                string sqlText = string.Empty;
                SqlCommand command = new SqlCommand(sqlText, connection, transaction);
                SqlDataReader reader = null;

                try
                {
                    // -- UPD 2010/03/30 -------------------------------->>>
                    //foreach (MTtlStockSlipWork item in MTtlStockList)
                    foreach (MTtlStockSlipWork item in MTtlStockDic.Values)
                    // -- UPD 2010/03/30 -------------------------------->>>
                    {
                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  MTTL.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,MTTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,MTTL.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKSECTIONCDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKDATEYMRF" + Environment.NewLine;
                        sqlText += " ,MTTL.RSLTTTLDIVCDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKTOTALPRICERF" + Environment.NewLine;
                        sqlText += " ,MTTL.TOTALSTOCKCOUNTRF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKTOTALDISCOUNTRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MTTLSTOCKSLIPRF AS MTTL" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  MTTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND MTTL.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        sqlText += "  AND MTTL.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                        sqlText += "  AND MTTL.STOCKDATEYMRF = @FINDSTOCKDATEYM" + Environment.NewLine;
                        sqlText += "  AND MTTL.RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += "  AND MTTL.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND MTTL.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        command.CommandText = sqlText;
                        command.Parameters.Clear();
                        # endregion

                        # region [検索用 パラメータオブジェクトの作成]
                        SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findStockSectionCd = command.Parameters.Add("@FINDSTOCKSECTIONCD", SqlDbType.NChar);  // 仕入拠点コード
                        SqlParameter findStockDateYM = command.Parameters.Add("@FINDSTOCKDATEYM", SqlDbType.Int);          // 仕入年月
                        SqlParameter findRsltTtlDivCd = command.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);        // 実績集計区分
                        SqlParameter findEmployeeCode = command.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);      // 従業員コード                    
                        SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);            // 仕入先コード
                        # endregion

                        # region [検索用 パラメータオブジェクトの値設定]
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // 企業コード
                        findStockSectionCd.Value = SqlDataMediator.SqlSetString(item.StockSectionCd);              // 仕入拠点コード
                        findStockDateYM.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.StockDateYm);        // 仕入年月
                        findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // 実績集計区分
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // 従業員コード
                        findSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // 仕入先コード
                        # endregion

                        reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE MTTLSTOCKSLIPRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,STOCKSECTIONCDRF = @STOCKSECTIONCD" + Environment.NewLine;
                            sqlText += " ,STOCKDATEYMRF = @STOCKDATEYM" + Environment.NewLine;
                            sqlText += " ,RSLTTTLDIVCDRF = @RSLTTTLDIVCD" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALPRICERF = @STOCKTOTALPRICE" + Environment.NewLine;
                            sqlText += " ,TOTALSTOCKCOUNTRF = @TOTALSTOCKCOUNT" + Environment.NewLine;
                            sqlText += " ,STOCKRETGOODSPRICERF = @STOCKRETGOODSPRICE" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALDISCOUNTRF = @STOCKTOTALDISCOUNT" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            sqlText += "  AND STOCKDATEYMRF = @FINDSTOCKDATEYM" + Environment.NewLine;
                            sqlText += "  AND RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                            command.CommandText = sqlText;
                            # endregion

                            # region [同一キーのデータが既に存在している場合は集計(合算)する]
                            item.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(reader, reader.GetOrdinal("CREATEDATETIMERF"));   // 作成日時
                            item.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(reader, reader.GetOrdinal("UPDATEDATETIMERF"));   // 更新日時
                            item.EnterpriseCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ENTERPRISECODERF"));              // 企業コード
                            item.FileHeaderGuid = SqlDataMediator.SqlGetGuid(reader, reader.GetOrdinal("FILEHEADERGUIDRF"));                // GUID
                            item.UpdEmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("UPDEMPLOYEECODERF"));            // 更新従業員コード
                            item.UpdAssemblyId1 = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("UPDASSEMBLYID1RF"));              // 更新アセンブリID1
                            item.UpdAssemblyId2 = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("UPDASSEMBLYID2RF"));              // 更新アセンブリID2
                            item.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("LOGICALDELETECODERF"));         // 論理削除区分
                            item.StockSectionCd = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("STOCKSECTIONCDRF"));              // 仕入拠点コード
                            item.StockDateYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(reader, reader.GetOrdinal("STOCKDATEYMRF"));        // 仕入年月
                            item.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("RSLTTTLDIVCDRF"));                   // 実績集計区分
                            item.EmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("EMPLOYEECODERF"));                  // 従業員コード
                            item.SupplierCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SUPPLIERCDRF"));                       // 仕入先コード
                            item.StockTotalPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("STOCKTOTALPRICERF"));            // 仕入金額合計
                            item.TotalStockCount += SqlDataMediator.SqlGetDouble(reader, reader.GetOrdinal("TOTALSTOCKCOUNTRF"));           // 仕入数計
                            item.StockRetGoodsPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("STOCKRETGOODSPRICERF"));      // 仕入返品額
                            item.StockTotalDiscount += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("STOCKTOTALDISCOUNTRF"));      // 仕入値引計
                            # endregion

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)item;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO MTTLSTOCKSLIPRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,STOCKSECTIONCDRF" + Environment.NewLine;
                            sqlText += " ,STOCKDATEYMRF" + Environment.NewLine;
                            sqlText += " ,RSLTTTLDIVCDRF" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALPRICERF" + Environment.NewLine;
                            sqlText += " ,TOTALSTOCKCOUNTRF" + Environment.NewLine;
                            sqlText += " ,STOCKRETGOODSPRICERF" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALDISCOUNTRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@STOCKSECTIONCD" + Environment.NewLine;
                            sqlText += " ,@STOCKDATEYM" + Environment.NewLine;
                            sqlText += " ,@RSLTTTLDIVCD" + Environment.NewLine;
                            sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,@STOCKTOTALPRICE" + Environment.NewLine;
                            sqlText += " ,@TOTALSTOCKCOUNT" + Environment.NewLine;
                            sqlText += " ,@STOCKRETGOODSPRICE" + Environment.NewLine;
                            sqlText += " ,@STOCKTOTALDISCOUNT" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            command.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)item;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        reader.Close();
                        reader.Dispose();

                        # region [登録・更新用 パラメータオブジェクトの作成]
                        SqlParameter paraCreateDateTime = command.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = command.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = command.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = command.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = command.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = command.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = command.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = command.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraStockSectionCd = command.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                        SqlParameter paraStockDateYM = command.Parameters.Add("@STOCKDATEYM", SqlDbType.Int);
                        SqlParameter paraRsltTtlDivCd = command.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                        SqlParameter paraEmployeeCode = command.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = command.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraStockTotalPrice = command.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraTotalStockCount = command.Parameters.Add("@TOTALSTOCKCOUNT", SqlDbType.Float);
                        SqlParameter paraStockRetGoodsPrice = command.Parameters.Add("@STOCKRETGOODSPRICE", SqlDbType.BigInt);
                        SqlParameter paraStockTotalDiscount = command.Parameters.Add("@STOCKTOTALDISCOUNT", SqlDbType.BigInt);
                        # endregion

                        # region [登録・更新用 パラメータオブジェクトの値設定]
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(item.CreateDateTime);   // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(item.UpdateDateTime);   // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(item.FileHeaderGuid);                // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(item.UpdEmployeeCode);            // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId1);              // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId2);              // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(item.LogicalDeleteCode);         // 論理削除区分
                        paraStockSectionCd.Value = SqlDataMediator.SqlSetString(item.StockSectionCd);              // 仕入拠点コード
                        paraStockDateYM.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.StockDateYm);        // 仕入年月
                        paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // 実績集計区分
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // 従業員コード
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // 仕入先コード
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(item.StockTotalPrice);             // 仕入金額合計
                        paraTotalStockCount.Value = SqlDataMediator.SqlSetDouble(item.TotalStockCount);            // 仕入数計
                        paraStockRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(item.StockRetGoodsPrice);       // 仕入返品額
                        paraStockTotalDiscount.Value = SqlDataMediator.SqlSetInt64(item.StockTotalDiscount);       // 仕入値引計
                        # endregion

                        command.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }

                        reader.Dispose();
                    }

                    if (command != null)
                    {
                        command.Cancel();
                        command.Dispose();
                    }
                }

                # endregion
            }
            # endregion

            return status;
        }

        // -- ADD 2010/03/30 ----------------------------->>>
        /// <summary>
        /// 売上月次集計データ用Key情報生成
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string MakeKeyMTtlStockSlip(MTtlStockSlipWork item)
        {
            return SqlDataMediator.SqlSetString(item.EnterpriseCode) + "-" +                            // 企業コード
                    SqlDataMediator.SqlSetString(item.StockSectionCd) + "-" +                            // 仕入拠点コード
                    SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.StockDateYm).ToString() + "-" +        // 仕入年月
                    SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd).ToString() + "-" +                    // 実績集計区分
                    SqlDataMediator.SqlSetString(item.EmployeeCode) +"-" +                               // 従業員コード
                    SqlDataMediator.SqlSetInt32(item.SupplierCd);                                        // 仕入先コード

        }
        // -- ADD 2010/03/30 -----------------------------<<<

        # region [比較メソッド (並び替えや検索で使用)]

        /// <summary>
        /// 仕入データ用 比較メソッド
        /// </summary>
        private class StockHeaderComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                StockSlipWork xSlip = ListUtils.Find((ArrayList)x, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                StockSlipWork ySlip = ListUtils.Find((ArrayList)y, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 仕入形式で比較
                        cmpret = xSlip.SupplierFormal - ySlip.SupplierFormal;
                    }

                    if (cmpret == 0)
                    {
                        // 仕入伝票番号で比較
                        cmpret = xSlip.SupplierSlipNo - ySlip.SupplierSlipNo;//string.Compare(xSlip.SupplierSlipNo, ySlip.SupplierSlipNo);
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// 仕入データ用 比較メソッド2
        /// </summary>
        private class StockHeaderComparer2 : IComparer
        {
            public int Compare(object x, object y)
            {
                StockSlipWork xSlip = ListUtils.Find((ArrayList)x, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                StockSlipWork ySlip = ListUtils.Find((ArrayList)y, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 仕入形式で比較
                        cmpret = xSlip.SupplierFormal - ySlip.SupplierFormal;
                    }

                    if (cmpret == 0)
                    {
                        // 仕入伝票番号で比較
                        cmpret = xSlip.SupplierSlipNo - ySlip.SupplierSlipNo;//string.Compare(xSlip.SupplierSlipNo, ySlip.SupplierSlipNo);
                    }

                    // Mantis 10027対応[ヘッダ情報変更による集計更新のため]     ↓↓↓↓↓
                    if (cmpret == 0)
                    {
                        // 仕入拠点コードで比較
                        cmpret = string.Compare(xSlip.StockSectionCd, ySlip.StockSectionCd);
                    }

                    if (cmpret == 0)
                    {
                        // 仕入日で比較
                        cmpret = DateTime.Compare(xSlip.StockDate, ySlip.StockDate);
                    }

                    if (cmpret == 0)
                    {
                        // 仕入担当者コードで比較
                        cmpret = string.Compare(xSlip.StockAgentCode, ySlip.StockAgentCode);
                    }

                    if (cmpret == 0)
                    {
                        // 仕入先コードで比較
                        cmpret = xSlip.SupplierCd - ySlip.SupplierCd;
                    }
                    // Mantis 10027対応[ヘッダ情報変更による集計更新のため]     ↑↑↑↑↑
                }

                return cmpret;
            }
        }

        /// <summary>
        /// 仕入明細データ用 比較メソッド
        /// </summary>
        private class StockDetailComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                StockDetailWork xDetail = x as StockDetailWork;
                StockDetailWork yDetail = y as StockDetailWork;

                int cmpret = (xDetail == null ? 0 : 1) - (yDetail == null ? 0 : 1);

                if (cmpret == 0 && xDetail != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xDetail.EnterpriseCode, yDetail.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 仕入形式で比較
                        cmpret = xDetail.SupplierFormal - yDetail.SupplierFormal;
                    }

                    if (cmpret == 0)
                    {
                        // 仕入明細通番で比較
                        cmpret = (int)(xDetail.StockSlipDtlNum - yDetail.StockSlipDtlNum);
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// 仕入月次集計データ用 比較メソッド
        /// </summary>
        private class MTtlStockSlipComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                MTtlStockSlipWork xSlip = x as MTtlStockSlipWork;
                MTtlStockSlipWork ySlip = y as MTtlStockSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 仕入拠点コードで比較
                        cmpret = string.Compare(xSlip.StockSectionCd, ySlip.StockSectionCd);
                    }

                    if (cmpret == 0)
                    {
                        // 仕入年月で比較
                        cmpret = DateTime.Compare(xSlip.StockDateYm, ySlip.StockDateYm);
                    }

                    if (cmpret == 0)
                    {
                        // 実績集計区分で比較
                        cmpret = xSlip.RsltTtlDivCd - ySlip.RsltTtlDivCd;
                    }

                    if (cmpret == 0)
                    {
                        // 従業員コードで比較
                        cmpret = string.Compare(xSlip.EmployeeCode, ySlip.EmployeeCode);
                    }

                    if (cmpret == 0)
                    {
                        // 仕入先コードで比較
                        cmpret = xSlip.SupplierCd - ySlip.SupplierCd;
                    }

                }

                return cmpret;
            }
        }

        # endregion

        # endregion

        # region [削除処理]

        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを物理削除します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを物理削除します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        public int Delete(MTtlStockUpdParaWork mTtlStockUpdParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection connection = this.CreateSqlConnection(true);

            if (connection == null)
            {
                return status;
            }

            SqlTransaction transaction = this.CreateTransaction(ref connection);

            if (transaction == null)
            {
                return status;
            }

            try
            {
                status = this.Delete(mTtlStockUpdParaWork, connection, transaction);
            }
            finally
            {
                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }

                    transaction.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを物理削除します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを物理削除します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        public int Delete(MTtlStockUpdParaWork mTtlStockUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            // 排他ロックを行う
            int status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

            try
            {
                status = this.DeleteMTtlStock(mTtlStockUpdParaWork, connection, transaction);
            }
            finally
            {
                // 排他ロックを解放する
                this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);
            }

            return status;
        }

        /// <summary>
        /// 指定された条件に基づいて、仕入月次集計データを物理削除します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        private int DeleteMTtlStock(MTtlStockUpdParaWork mTtlStockUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand command = new SqlCommand("", connection, transaction))
                {
                    #region [DELETE文]
                    string sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  MTTLSTOCKSLIPRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

                    //sqlText += "  AND STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine; // DEL 2009/12/24

                    // ---ADD 2009/12/24 -------->>>
                    if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCd))
                    {
                        sqlText += "  AND STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                        }
                        else if (string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                        else if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCDST AND STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCDED" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCDST", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                            command.Parameters.Add("FINDSTOCKSECTIONCDED", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                    }
                    // ---ADD 2009/12/24 --------<<<

                    if (mTtlStockUpdParaWork.StockDateYmSt != 0)
                    {
                        sqlText += "  AND STOCKDATEYMRF >= @FINDSTOCKDATEYMST" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKDATEYMST", SqlDbType.Int).Value = mTtlStockUpdParaWork.StockDateYmSt;
                    }

                    if (mTtlStockUpdParaWork.StockDateYmEd != 0)
                    {
                        sqlText += "  AND STOCKDATEYMRF <= @FINDSTOCKDATEYMED" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKDATEYMED", SqlDbType.Int).Value = mTtlStockUpdParaWork.StockDateYmEd;
                    }

                    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.EnterpriseCode;
                    //command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;  // ---DEL 2009/12/24

                    command.CommandText = sqlText;

#if DEBUG
                    Console.Clear();  // コンソール画面の初期化は任意
                    Console.WriteLine(NSDebug.GetSqlCommand(command));
#endif
                    # endregion;

                    // --- ADD m.suzuki 2010/03/04 ---------->>>>>
                    command.CommandTimeout = 3600; // =1.0H
                    // --- ADD m.suzuki 2010/03/04 ----------<<<<<
                    command.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }
        # endregion

        # region [再集計処理]

        /// <summary>
        /// 指定された条件に基づいて、仕入月次集計データを再集計します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、仕入月次集計データを再集計します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// <br>Update Note: 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・一括リアル更新の新規を対応</br>
        public int ReCount(MTtlStockUpdParaWork mTtlStockUpdParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection connection = this.CreateSqlConnection(true);

            if (connection == null)
            {
                return status;
            }

            SqlTransaction transaction = this.CreateTransaction(ref connection);

            if (transaction == null)
            {
                return status;
            }

            // ---DEL 2009/12/24 -------->>>
            //SqlCommand command = new SqlCommand("", connection, transaction);
            //SqlDataReader reader = null;
            // ---DEL 2009/12/24 --------<<<

            try
            {
                status = this.ReCountProc(mTtlStockUpdParaWork, ref connection, ref transaction);  // ADD 2009/12/24

                #region 削除
                // ---DEL 2009/12/24 -------->>>
            //    ArrayList newStockSlips = new ArrayList();

            //    # region [仕入日付から仕入年月日(開始～終了)を算出]

            //    // 日付取得部品を利用する
            //    FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlStockUpdParaWork.EnterpriseCode));

            //    DateTime tmpStart;
            //    DateTime tmpEnd;
            //    int StockDateYmSt = 0;
            //    int StockDateYmEd = 0;

            //    // 仕入年月(開始)を元に月度開始日を取得
            //    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmSt * 100 + 1), out tmpStart, out tmpEnd);
            //    StockDateYmSt = tmpStart.Year * 100 + tmpStart.Month;

            //    // 仕入年月(終了)を元に月度終了日を取得
            //    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmEd * 100 + 1), out tmpStart, out tmpEnd);
            //    StockDateYmEd = tmpEnd.Year * 100 + tmpEnd.Month;

            //    # endregion

            //    # region [仕入履歴データの取得]

            //    // 仕入履歴データを取得
            //    string sqlText = string.Empty;
            //    sqlText += "SELECT" + Environment.NewLine;
            //    sqlText += "  HIST.CREATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  HIST.ENTERPRISECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.FILEHEADERGUIDRF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDEMPLOYEECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDASSEMBLYID1RF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDASSEMBLYID2RF" + Environment.NewLine;
            //    sqlText += "  HIST.LOGICALDELETECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERFORMALRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPNORF" + Environment.NewLine;
            //    sqlText += "  HIST.SECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.SUBSECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.DEBITNOTEDIVRF" + Environment.NewLine;
            //    sqlText += "  HIST.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKGOODSCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.ACCPAYDIVCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSECTIONCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSLIPUPDATECDRF" + Environment.NewLine;
            //    sqlText += "  HIST.INPUTDAYRF" + Environment.NewLine;
            //    sqlText += "  HIST.ARRIVALGOODSDAYRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKADDUPADATERF" + Environment.NewLine;
            //    sqlText += "  HIST.DELAYPAYMENTDIVRF" + Environment.NewLine;
            //    sqlText += "  HIST.PAYEECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.PAYEESNMRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERNM1RF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERNM2RF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSNMRF" + Environment.NewLine;
            //    sqlText += "  HIST.BUSINESSTYPECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.BUSINESSTYPENAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.SALESAREACODERF" + Environment.NewLine;
            //    sqlText += "  HIST.SALESAREANAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKINPUTCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKINPUTNAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKAGENTCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKAGENTNAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKTOTALPRICERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSUBTTLPRICERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKNETPRICERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKPRICECONSTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLITDEDSTCINTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLITDEDSTCTAXFREERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
            //    sqlText += "  HIST.STCKDISTTLTAXEXCRF" + Environment.NewLine;
            //    sqlText += "  HIST.ITDEDSTOCKDISOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.ITDEDSTOCKDISINTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.ITDEDSTOCKDISTAXFRERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKDISOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            //    sqlText += "  HIST.TAXADJUSTRF" + Environment.NewLine;
            //    sqlText += "  HIST.BALANCEADJUSTRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPCTAXLAYCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
            //    sqlText += "  HIST.ACCPAYCONSTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKFRACTIONPROCCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.AUTOPAYMENTRF" + Environment.NewLine;
            //    sqlText += "  HIST.AUTOPAYSLIPNUMRF" + Environment.NewLine;
            //    sqlText += "  HIST.RETGOODSREASONDIVRF" + Environment.NewLine;
            //    sqlText += "  HIST.RETGOODSREASONRF" + Environment.NewLine;
            //    sqlText += "  HIST.PARTYSALESLIPNUMRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            //    sqlText += "  HIST.DETAILROWCOUNTRF" + Environment.NewLine;
            //    sqlText += "  HIST.EDISENDDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.EDITAKEINDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.UOEREMARK1RF" + Environment.NewLine;
            //    sqlText += "  HIST.UOEREMARK2RF" + Environment.NewLine;
            //    sqlText += "  HIST.SLIPPRINTDIVCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.SLIPPRINTFINISHCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSLIPPRINTDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
            //    sqlText += "FROM" + Environment.NewLine;
            //    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
            //    sqlText += "WHERE" + Environment.NewLine;
            //    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            //    sqlText += "  AND HIST.SUPPLIERFORMALRF = 0" + Environment.NewLine;
            //    sqlText += "  AND HIST.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
            //    //sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
            //    // 売上日の相手は「入荷日」なのか「仕入日」なのか
            //    sqlText += "  AND (HIST.STOCKDATERF >= @FINDSTOCKDATEST AND HIST.STOCKDATERF <= @FINDSTOCKDATEED)" + Environment.NewLine;
            //    command.CommandText = sqlText;

            //    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.EnterpriseCode;
            //    command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;
            //    command.Parameters.Add("FINDSTOCKDATEST", SqlDbType.Int).Value = StockDateYmSt;
            //    command.Parameters.Add("FINDSTOCKDATEED", SqlDbType.Int).Value = StockDateYmEd;

            //    reader = command.ExecuteReader();

            //    ArrayList headerList = new ArrayList();

            //    while (reader.Read())
            //    {
            //        headerList.Add(this.CopyToStockSlipWorkFromReader(reader));
            //    }

            //    command.Parameters.Clear();

            //    # endregion

            //    # region [仕入履歴明細データの取得]

            //    // 仕入履歴明細データを取得
            //    sqlText = string.Empty;
            //    sqlText += "SELECT" + Environment.NewLine;
            //    sqlText += "  DTIL.CREATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.FILEHEADERGUIDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDEMPLOYEECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDASSEMBLYID1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDASSEMBLYID2RF" + Environment.NewLine;
            //    sqlText += "  DTIL.LOGICALDELETECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ACCEPTANORDERNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKROWNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.SECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUBSECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.COMMONSEQNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPLIERFORMALSRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKSLIPCDDTLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKAGENTCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKAGENTNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSKINDCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSMAKERCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.MAKERNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.MAKERKANANAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.CMPLTMAKERKANANAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSNAMEKANARF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSLGROUPRF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSLGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSMGROUPRF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSMGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGROUPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGOODSCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGOODSFULLNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISEGANRECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.WAREHOUSECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.WAREHOUSENAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.WAREHOUSESHELFNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKORDERDIVCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.OPENPRICEDIVRF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSRATERANKRF" + Environment.NewLine;
            //    sqlText += "  DTIL.CUSTRATEGRPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPRATEGRPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.LISTPRICETAXINCFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKRATERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATESECTSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEDIVSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.UNPRCCALCCDSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.PRICECDSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STDUNPRCSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.FRACPROCUNITSTCUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.FRACPROCSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKUNITCHNGDIVRF" + Environment.NewLine;
            //    sqlText += "  DTIL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.BFLISTPRICERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGOODSCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGOODSNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEGOODSRATEGRPCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEGOODSRATEGRPNMRF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGROUPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKCOUNTRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKPRICETAXINCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKGOODSCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKPRICECONSTAXRF" + Environment.NewLine;
            //    sqlText += "  DTIL.TAXATIONCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.SALESCUSTOMERCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.SALESCUSTOMERSNMRF" + Environment.NewLine;
            //    sqlText += "  DTIL.ORDERNUMBERRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SLIPMEMO1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.SLIPMEMO2RF" + Environment.NewLine;
            //    sqlText += "  DTIL.SLIPMEMO3RF" + Environment.NewLine;
            //    sqlText += "  DTIL.INSIDEMEMO1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.INSIDEMEMO2RF" + Environment.NewLine;
            //    sqlText += "  DTIL.INSIDEMEMO3RF" + Environment.NewLine;
            //    sqlText += "FROM" + Environment.NewLine;
            //    sqlText += "  STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
            //    sqlText += "WHERE" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            //    sqlText += "  AND DTIL.SUPPLIERFORMALRF = 0" + Environment.NewLine;
            //    sqlText += "  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

            //    command.CommandText = sqlText;

            //    SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
            //    SqlParameter findSupplierSlipNo = command.Parameters.Add("FINDSUPPLIERSLIPNO", SqlDbType.Int);

            //    foreach (StockSlipWork header in headerList)
            //    {
            //        findEnterpriseCode.Value = header.EnterpriseCode;
            //        findSupplierSlipNo.Value = header.SupplierSlipNo;

            //        if (!reader.IsClosed)
            //        {
            //            reader.Close();
            //        }

            //        reader = command.ExecuteReader();

            //        ArrayList detail = new ArrayList();

            //        while (reader.Read())
            //        {
            //            detail.Add(this.CopyToStockDetailWorkFromReader(reader));
            //        }

            //        ArrayList stockSlip = new ArrayList();
            //        stockSlip.Add(header);
            //        stockSlip.Add(detail);

            //        newStockSlips.Add(stockSlip);
            //    }
            //    # endregion

            //    if (ListUtils.IsEmpty(newStockSlips))
            //    {
            //        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //    }
            //    else
            //    {
            //        // 排他ロックを行う
            //        status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

            //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        {
            //            return status;
            //        }

            //        try
            //        {
            //            // 再集計前に対象範囲を一度全て削除する
            //            status = this.Delete(mTtlStockUpdParaWork, connection, transaction);

            //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //            {
            //                return status;
            //            }

            //            // 伝票登録区分を 2:再集計 に設定
            //            mTtlStockUpdParaWork.SlipRegDiv = 2;

            //            // 再集計を行う
            //            status = this.Write(mTtlStockUpdParaWork, newStockSlips, null, connection, transaction);
            //        }
            //        finally
            //        {
            //            // 排他ロックを解放する
            //            this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);
            //        }
            //    }
                // ---DEL 2009/12/24 --------<<<
                #endregion
            }
            finally
            {
                #region 削除
                // ---DEL 2009/12/24 -------->>>
            //    if (reader != null)
            //    {
            //        if (!reader.IsClosed)
            //        {
            //            reader.Close();
            //        }
            //        reader.Dispose();
            //    }

            //    if (command != null)
            //    {
            //        command.Cancel();
            //        command.Dispose();
            //    }
                // ---DEL 2009/12/24 --------<<<
                #endregion

                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 正常終了の場合はコミット処理を行う
                            transaction.Commit();
                        }
                        else
                        {
                            // 異常終了の場合はロールバック処理を行う
                            transaction.Rollback();
                        }
                    }

                    transaction.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        // ---ADD 2009/12/24-------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを再集計します。
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="connection">ＤＢ接続オブジェクト</param>
        /// <param name="transaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを再集計します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.12.24</br>
        public int ReCountProc(MTtlStockUpdParaWork mTtlStockUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (connection == null)
            {
                return status;
            }

            if (transaction == null)
            {
                return status;
            }

            SqlCommand command = new SqlCommand("", connection, transaction);
            SqlDataReader reader = null;

            // -- ADD 2010/02/24 ---------------------------------->>>
            Int32 monthRange = ((mTtlStockUpdParaWork.StockDateYmEd / 100) - (mTtlStockUpdParaWork.StockDateYmSt / 100)) * 12 + (mTtlStockUpdParaWork.StockDateYmEd % 100) - (mTtlStockUpdParaWork.StockDateYmSt % 100) + 1;
            DateTime dt = new DateTime(mTtlStockUpdParaWork.StockDateYmSt / 100, mTtlStockUpdParaWork.StockDateYmSt % 100, 1); 
            // -- ADD 2010/02/24 ----------------------------------<<<

            try
            {
                // -- ADD 2010/02/24 ------------------------------>>>
                for (int i = 0; i < monthRange; i++)
                {
                    mTtlStockUpdParaWork.StockDateYmSt = Int32.Parse(dt.ToString("yyyyMM"));
                    mTtlStockUpdParaWork.StockDateYmEd = Int32.Parse(dt.ToString("yyyyMM"));

                    command.Parameters.Clear();
                // -- ADD 2010/02/24 ------------------------------<<<

                    ArrayList newStockSlips = new ArrayList();

                    # region [仕入日付から仕入年月日(開始～終了)を算出]

                    // 日付取得部品を利用する
                    FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlStockUpdParaWork.EnterpriseCode));

                    DateTime tmpStart;
                    DateTime tmpEnd;
                    int StockDateYmSt = 0;
                    int StockDateYmEd = 0;

                    // 仕入年月(開始)を元に月度開始日を取得
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmSt * 100 + 1), out tmpStart, out tmpEnd);
                    //StockDateYmSt = tmpStart.Year * 100 + tmpStart.Month;                        // DEL 2009/12/24
                    StockDateYmSt = tmpStart.Year * 10000 + tmpStart.Month * 100 + tmpStart.Day;   // ADD 2009/12/24

                    // 仕入年月(終了)を元に月度終了日を取得
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmEd * 100 + 1), out tmpStart, out tmpEnd);
                    //StockDateYmEd = tmpEnd.Year * 100 + tmpEnd.Month;                        // DEL 2009/12/24
                    StockDateYmEd = tmpEnd.Year * 10000 + tmpEnd.Month * 100 + tmpEnd.Day;     // ADD 2009/12/24

                    # endregion

                    # region [仕入履歴データの取得]

                    // 仕入履歴データを取得
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    // ---UPD 2009/12/24 ------------->>>>>>>>>>>
                    sqlText += "  HIST.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  HIST.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += "  HIST.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += "  HIST.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += "  HIST.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += "  HIST.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERFORMALRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPNORF," + Environment.NewLine;
                    sqlText += "  HIST.SECTIONCODERF," + Environment.NewLine;
                    sqlText += "  HIST.SUBSECTIONCODERF," + Environment.NewLine;
                    sqlText += "  HIST.DEBITNOTEDIVRF," + Environment.NewLine;
                    sqlText += "  HIST.DEBITNLNKSUPPSLIPNORF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKGOODSCDRF," + Environment.NewLine;
                    sqlText += "  HIST.ACCPAYDIVCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKADDUPSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSLIPUPDATECDRF," + Environment.NewLine;
                    sqlText += "  HIST.INPUTDAYRF," + Environment.NewLine;
                    sqlText += "  HIST.ARRIVALGOODSDAYRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKDATERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKADDUPADATERF," + Environment.NewLine;
                    sqlText += "  HIST.DELAYPAYMENTDIVRF," + Environment.NewLine;
                    sqlText += "  HIST.PAYEECODERF," + Environment.NewLine;
                    sqlText += "  HIST.PAYEESNMRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSNMRF," + Environment.NewLine;
                    sqlText += "  HIST.BUSINESSTYPECODERF," + Environment.NewLine;
                    sqlText += "  HIST.BUSINESSTYPENAMERF," + Environment.NewLine;
                    sqlText += "  HIST.SALESAREACODERF," + Environment.NewLine;
                    sqlText += "  HIST.SALESAREANAMERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKINPUTCODERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKINPUTNAMERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKAGENTCODERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKAGENTNAMERF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPTTLAMNTDSPWAYCDRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLAMNTDISPRATEAPYRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKTOTALPRICERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSUBTTLPRICERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKTTLPRICTAXINCRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKTTLPRICTAXEXCRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKNETPRICERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKPRICECONSTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLITDEDSTCINTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.STCKPRCCONSTAXINCLURF," + Environment.NewLine;
                    sqlText += "  HIST.STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "  HIST.ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.STCKDISTTLTAXINCLURF," + Environment.NewLine;
                    sqlText += "  HIST.TAXADJUSTRF," + Environment.NewLine;
                    sqlText += "  HIST.BALANCEADJUSTRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERCONSTAXRATERF," + Environment.NewLine;
                    sqlText += "  HIST.ACCPAYCONSTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKFRACTIONPROCCDRF," + Environment.NewLine;
                    sqlText += "  HIST.AUTOPAYMENTRF," + Environment.NewLine;
                    sqlText += "  HIST.AUTOPAYSLIPNUMRF," + Environment.NewLine;
                    sqlText += "  HIST.RETGOODSREASONDIVRF," + Environment.NewLine;
                    sqlText += "  HIST.RETGOODSREASONRF," + Environment.NewLine;
                    sqlText += "  HIST.PARTYSALESLIPNUMRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPNOTE1RF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPNOTE2RF," + Environment.NewLine;
                    sqlText += "  HIST.DETAILROWCOUNTRF," + Environment.NewLine;
                    sqlText += "  HIST.EDISENDDATERF," + Environment.NewLine;
                    sqlText += "  HIST.EDITAKEINDATERF," + Environment.NewLine;
                    sqlText += "  HIST.UOEREMARK1RF," + Environment.NewLine;
                    sqlText += "  HIST.UOEREMARK2RF," + Environment.NewLine;
                    sqlText += "  HIST.SLIPPRINTDIVCDRF," + Environment.NewLine;
                    sqlText += "  HIST.SLIPPRINTFINISHCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSLIPPRINTDATERF," + Environment.NewLine;
                    // ---UPD 2009/12/24 -------------<<<<<<<<<<<
                    sqlText += "  HIST.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = 0" + Environment.NewLine;

                    // ---UPD 2009/12/24 ----------->>>>
                    //sqlText += "  AND HIST.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                    if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCd))
                    {
                        sqlText += "  AND HIST.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND HIST.STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                        }
                        else if (string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND HIST.STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                        else if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND HIST.STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCDST AND HIST.STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCDED" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCDST", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                            command.Parameters.Add("FINDSTOCKSECTIONCDED", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                    }
                    sqlText += "  AND HIST.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                    // ---UPD 2009/12/24 -----------<<<


                    //sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
                    // 売上日の相手は「入荷日」なのか「仕入日」なのか
                    sqlText += "  AND (HIST.STOCKDATERF >= @FINDSTOCKDATEST AND HIST.STOCKDATERF <= @FINDSTOCKDATEED)" + Environment.NewLine;
                    command.CommandText = sqlText;

                    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.EnterpriseCode;
                    //command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;  // DEL 2009/12/24
                    command.Parameters.Add("FINDSTOCKDATEST", SqlDbType.Int).Value = StockDateYmSt;
                    command.Parameters.Add("FINDSTOCKDATEED", SqlDbType.Int).Value = StockDateYmEd;

                    reader = command.ExecuteReader();

                    ArrayList headerList = new ArrayList();

                    while (reader.Read())
                    {
                        headerList.Add(this.CopyToStockSlipWorkFromReader(reader));
                    }

                    command.Parameters.Clear();

                    # endregion

                    # region [仕入履歴明細データの取得]

                    // 仕入履歴明細データを取得
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    // ---UPD 2009/12/24 ------------->>>>>>>>>>>
                    sqlText += "  DTIL.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += "  DTIL.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.ACCEPTANORDERNORF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPLIERFORMALRF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPLIERSLIPNORF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKROWNORF," + Environment.NewLine;
                    sqlText += "  DTIL.SECTIONCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.SUBSECTIONCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.COMMONSEQNORF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKSLIPDTLNUMRF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPLIERFORMALSRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKSLIPDTLNUMSRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.ACPTANODRSTATUSSYNCRF," + Environment.NewLine;
                    sqlText += "  DTIL.SALESSLIPDTLNUMSYNCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKSLIPCDDTLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKAGENTCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKAGENTNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSKINDCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSMAKERCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.MAKERNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.MAKERKANANAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.CMPLTMAKERKANANAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSNORF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSNAMEKANARF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSLGROUPRF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSLGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSMGROUPRF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSMGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGROUPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGOODSCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGOODSFULLNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISEGANRECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISEGANRENAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.WAREHOUSECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.WAREHOUSENAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.WAREHOUSESHELFNORF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKORDERDIVCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.OPENPRICEDIVRF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSRATERANKRF," + Environment.NewLine;
                    sqlText += "  DTIL.CUSTRATEGRPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPRATEGRPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.LISTPRICETAXINCFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKRATERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATESECTSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEDIVSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.UNPRCCALCCDSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.PRICECDSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STDUNPRCSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.FRACPROCUNITSTCUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.FRACPROCSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKUNITPRICEFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKUNITTAXPRICEFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKUNITCHNGDIVRF," + Environment.NewLine;
                    sqlText += "  DTIL.BFSTOCKUNITPRICEFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.BFLISTPRICERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGOODSCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGOODSNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEGOODSRATEGRPCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEGOODSRATEGRPNMRF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGROUPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKCOUNTRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKPRICETAXEXCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKPRICETAXINCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKGOODSCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKPRICECONSTAXRF," + Environment.NewLine;
                    sqlText += "  DTIL.TAXATIONCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKDTISLIPNOTE1RF," + Environment.NewLine;
                    sqlText += "  DTIL.SALESCUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.SALESCUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += "  DTIL.ORDERNUMBERRF," + Environment.NewLine;
                    sqlText += "  DTIL.SLIPMEMO1RF," + Environment.NewLine;
                    sqlText += "  DTIL.SLIPMEMO2RF," + Environment.NewLine;
                    sqlText += "  DTIL.SLIPMEMO3RF," + Environment.NewLine;
                    sqlText += "  DTIL.INSIDEMEMO1RF," + Environment.NewLine;
                    sqlText += "  DTIL.INSIDEMEMO2RF," + Environment.NewLine;
                    // ---UPD 2009/12/24 -------------<<<<<<<
                    sqlText += "  DTIL.INSIDEMEMO3RF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += "  AND DTIL.LOGICALDELETECODERF = 0" + Environment.NewLine;             // ADD 2009/12/24

                    command.CommandText = sqlText;

                    SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
                    SqlParameter findSupplierSlipNo = command.Parameters.Add("FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    foreach (StockSlipWork header in headerList)
                    {
                        findEnterpriseCode.Value = header.EnterpriseCode;
                        findSupplierSlipNo.Value = header.SupplierSlipNo;

                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }

                        reader = command.ExecuteReader();

                        ArrayList detail = new ArrayList();

                        while (reader.Read())
                        {
                            detail.Add(this.CopyToStockDetailWorkFromReader(reader));
                        }

                        ArrayList stockSlip = new ArrayList();
                        stockSlip.Add(header);
                        stockSlip.Add(detail);

                        newStockSlips.Add(stockSlip);
                    }

                    // ---ADD 2009/12/24 --->>>
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    // ---ADD 2009/12/24 ---<<<
                    # endregion

                    if (ListUtils.IsEmpty(newStockSlips))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2009/12/24

                        // 排他ロックを行う
                        status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        try
                        {
                            // 再集計前に対象範囲を一度全て削除する
                            status = this.Delete(mTtlStockUpdParaWork, connection, transaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }

                            // 伝票登録区分を 2:再集計 に設定
                            mTtlStockUpdParaWork.SlipRegDiv = 2;

                            // 再集計を行う
                            status = this.Write(mTtlStockUpdParaWork, newStockSlips, null, connection, transaction);
                        }
                        finally
                        {
                            // 排他ロックを解放する
                            this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);
                        }
                    }

                    dt = dt.AddMonths(1); // ADD 2010/02/24
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2010/02/24

                } // ADD 2010/02/24

            }
            // -- ADD 2010/02/24 ------------------------>>>
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            // -- ADD 2010/02/24 ------------------------<<<
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    reader.Dispose();
                }

                if (command != null)
                {
                    command.Cancel();
                    command.Dispose();
                }
            }
            return status;
        }
        // ---ADD 2009/12/24--------------------------------------------------------<<<<<<<<<<<<<<<<<
        # endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → stockHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>stockHistoryWork</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private StockSlipWork CopyToStockSlipWorkFromReader(SqlDataReader myReader)
        {
            StockSlipWork wkStockSlipWork = new StockSlipWork();

            this.CopyToStockSlipWorkFromReader(myReader, ref wkStockSlipWork);

            return wkStockSlipWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkStockSlipWork"></param>
        private void CopyToStockSlipWorkFromReader(SqlDataReader myReader, ref StockSlipWork wkStockSlipWork)
        {
            if (wkStockSlipWork != null)
            {
                #region クラスへ格納
                wkStockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkStockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkStockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkStockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkStockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkStockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkStockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                wkStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                wkStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkStockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                wkStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
                wkStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                wkStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                wkStockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
                wkStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                wkStockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
                wkStockSlipWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));
                wkStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                wkStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                wkStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                wkStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                wkStockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                wkStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                wkStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                wkStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                wkStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                wkStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                wkStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                wkStockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                wkStockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                wkStockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                wkStockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                wkStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                wkStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                wkStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                wkStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                wkStockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                wkStockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                wkStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                wkStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                wkStockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                wkStockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                wkStockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
                wkStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                wkStockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                wkStockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                wkStockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                wkStockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
                wkStockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
                wkStockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
                wkStockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
                wkStockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
                wkStockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
                wkStockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
                wkStockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
                wkStockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
                wkStockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
                wkStockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                wkStockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
                wkStockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
                wkStockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
                wkStockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                wkStockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
                wkStockSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                wkStockSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                wkStockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                wkStockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
                wkStockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
                wkStockSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                wkStockSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                wkStockSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                wkStockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                wkStockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                wkStockSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                wkStockSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                wkStockSlipWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
                wkStockSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                #endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → StockHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockHistDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private StockDetailWork CopyToStockDetailWorkFromReader(SqlDataReader myReader)
        {
            StockDetailWork wkStockDetailWork = new StockDetailWork();

            this.CopyToStockDetailWorkFromReader(myReader, ref wkStockDetailWork);

            return wkStockDetailWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkStockDetailWork"></param>
        private void CopyToStockDetailWorkFromReader(SqlDataReader myReader, ref StockDetailWork wkStockDetailWork)
        {
            if (wkStockDetailWork != null)
            {
                #region クラスへ格納
                wkStockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkStockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkStockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkStockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkStockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkStockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkStockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkStockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                wkStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                wkStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                wkStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                wkStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkStockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                wkStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                wkStockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
                wkStockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
                wkStockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
                wkStockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
                wkStockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                wkStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                wkStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                wkStockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                wkStockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                wkStockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                wkStockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                wkStockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
                wkStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                wkStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                wkStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                wkStockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                wkStockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                wkStockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                wkStockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                wkStockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                wkStockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                wkStockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                wkStockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                wkStockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                wkStockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                wkStockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                wkStockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                wkStockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkStockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                wkStockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                wkStockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                wkStockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                wkStockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
                wkStockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                wkStockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                wkStockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                wkStockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
                wkStockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
                wkStockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
                wkStockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
                wkStockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
                wkStockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
                wkStockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
                wkStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                wkStockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
                wkStockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
                wkStockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                wkStockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                wkStockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                wkStockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                wkStockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
                wkStockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
                wkStockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
                wkStockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
                wkStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                wkStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                wkStockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                wkStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                wkStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                wkStockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                wkStockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
                wkStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
                wkStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
                wkStockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                wkStockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                wkStockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                wkStockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                wkStockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                wkStockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                wkStockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                #endregion
            }
        }
        #endregion
    }
}
