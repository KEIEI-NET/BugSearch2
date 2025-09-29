//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   売上月次集計データ更新DBリモートオブジェクト
//                  :   PMHNB01101R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田　誠
// Date             :   2008.05.19
//----------------------------------------------------------------------
// Update Note      :　 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④
//                             ・一括リアル更新の新規を対応
//----------------------------------------------------------------------// 
// 管理番号  10801804-00 作成担当 : 郭永祥  						
// 修 正 日  2012/03/30  修正内容 : 2012/05/24配信分、Redmine#29142 						
//                                 「商品値引」の場合は集計対象外となるように修正する						
//----------------------------------------------------------------------//  
// 管理番号  10707327-00 作成担当 : 李小路 						
// 修 正 日  2012/03/31  修正内容 : 2012/05/24配信分、Redmine#29215　 						
//                                  得意先電子元帳と金額が合わないの修正						
//----------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委 						
// 修 正 日  2020/08/28  修正内容 : PMKOBETSU-4076　 						
//                                  タイムアウト設定						
//----------------------------------------------------------------------// 						
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

using System.Collections.Generic;// ADD 2010/03/30
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上月次集計データ更新DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上月次集計データ更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.05.19</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.04 月次集計データMANTIS対応</br>
    /// <br>Update Note: 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>                ・一括リアル更新の新規を対応</br>
    /// <br>Update Note: 2010/02/24 長内 一括リアル更新 速度アップ対応</br>
    /// <br>                ・スタンドアローンマシンで実行した場合に、ＣＰＵ負荷がかかるため、</br>
    /// <br>                  １か月単位に処理するように修正</br>
    /// <br>Update Note: 2010/03/04 鈴木 正臣 一括リアル更新 タイムアウトエラー対応</br>
    /// <br>                ・既存の集計レコードを削除する際のタイムアウト値を変更</br>
    /// <br>                　（ユーザーデータでエラーになる場合があった為、変更する）</br>
    /// <br>Update Note: 2010/03/30 長内 数馬 一括リアル更新 速度アップ対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/12 30517 夏野 駿希 売上データがないと売上月次集計データが削除されない不具合の修正</br>
    /// <br>Update Note: 2012/03/30 郭永祥 </br>
    /// <br>管理番号   ：10801804-00 2012/05/24配信分</br>
    /// <br>             Redmine#29142 「商品値引」の場合は集計対象外となるように修正する</br>
    /// <br>Update Note: 2012/03/31 李小路</br>							
    /// <br>管理番号   ：10707327-00 2012/05/24配信分</br>							
    /// <br>             Redmine#29215　得意先電子元帳と金額が合わないの修正</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>管理番号   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
    /// </remarks>
    [Serializable]
    public class MonthlyTtlSalesUpdDB : RemoteWithAppLockDB, IMonthlyTtlSalesUpdDB
    {
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        /// <summary>
        /// 売上月次集計データ更新DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        /// </remarks>
        public MonthlyTtlSalesUpdDB()
            : base("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesSlipWork", "MTTLSALESSLIPRF")
        {

        }

        /// <summary>
        /// アプリケーション ロックを行う際のリソース名を取得します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <returns>ロック リソース名</returns>
        private string GetLockResourceName(MTtlSalesUpdParaWork mTtlSalesUpdParaWork)
        {
            return this.GetResourceName(mTtlSalesUpdParaWork.EnterpriseCode);
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
        /// 指定された条件に基づいて、各種月次集計データを追加・更新します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="newSalesSlips">追加・更新する売上伝票データ</param>
        /// <param name="oldSalesSlips">登録前の売上伝票データ</param>
        /// <param name="connection">登録前の売上伝票データ</param>
        /// <param name="transaction">登録前の売上伝票データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを追加・更新します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        public int Write(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ArrayList newSalesSlips, ArrayList oldSalesSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [パラメーターチェック]

            if (mTtlSalesUpdParaWork == null)
            {
                return status;
            }

            if (newSalesSlips == null)
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

#if !DEBUG
            // 排他ロックを行う
            status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
#endif

            try
            {
                ArrayList totaledSalesSlips = null;
                
                // 売上伝票データ 事前集計処理
                if (mTtlSalesUpdParaWork.MTtlSalesPrcFlg == 1 || mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg == 1)
                {
                    status = this.PreTotal(newSalesSlips, oldSalesSlips, out totaledSalesSlips);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }

                if (ListUtils.IsNotEmpty(totaledSalesSlips))
                {
                    // 売上月次集計データ更新処理
                    if (mTtlSalesUpdParaWork.MTtlSalesPrcFlg == 1)
                    {
                        status = this.WriteMTtlSales(mTtlSalesUpdParaWork, totaledSalesSlips, connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }

                    // 商品別売上月次集計データ更新処理
                    if (mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg == 1)
                    {
                        status = this.WriteGoodsMTtlSales(mTtlSalesUpdParaWork, totaledSalesSlips, connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                }
            }
            finally
            {
#if !DEBUG
                // 排他ロックを解放する ※戻り値はスルー
                this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif

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
        /// 売上伝票データ 事前集計処理
        /// </summary>
        /// <param name="newSalesSlips">登録後の売上伝票データ</param>
        /// <param name="oldSalesSlips">登録前の売上伝票データ</param>
        /// <param name="ttlSalesSlips">事前集計後の売上伝票データ</param>
        /// <returns>STATUS</returns>
        private int PreTotal(ArrayList newSalesSlips, ArrayList oldSalesSlips, out ArrayList ttlSalesSlips)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ttlSalesSlips = new ArrayList();

            try
            {
                ArrayList newSlip = null;          // 登録後 売上伝票データ(売上データ＋売上明細データ)
                SalesSlipWork newHeader = null;    // 登録後 売上データ
                ArrayList newDetails = null;       // 登録後 売上明細データ(全明細分)

                SalesSlipWork oldHeader = null;    // 登録前 売上データ
                ArrayList oldDetails = null;       // 登録前 売上明細データ(全明細分)
                
                // 更新後の"売上データ"から集計対象を抽出
                if (ListUtils.IsNotEmpty(newSalesSlips))
                {
                    foreach (object item in newSalesSlips)
                    {
                        if (item is ArrayList)
                        {
                            newHeader = ListUtils.Find((item as ArrayList), typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                            newDetails = ListUtils.Find((item as ArrayList), typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (newHeader != null && newDetails != null && newHeader.AcptAnOdrStatus == 30)  // 売上のみ集計対象とする
                            {
                                ArrayList clnSlip = new ArrayList();  // 売上情報
                                ArrayList clnDtls = new ArrayList();  // 売上明細情報リスト
                                ArrayList clnAdds = new ArrayList();  // 明細追加情報リスト(ダミー)

                                SalesSlipWork clnHeader = newHeader.Clone();
                                clnSlip.Add(clnHeader);
                                clnSlip.Add(clnDtls);
                                clnSlip.Add(clnAdds);
                                
                                foreach (SalesDetailWork newDetail in newDetails)
                                {
                                    // 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の明細だけを集計対象とする
                                    switch (newDetail.SalesSlipCdDtl)
                                    {
                                        case 0:  // 売上
                                        case 1:  // 返品
                                        case 2:  // 値引
                                            {
                                                SalesDetailWork clnDetail = newDetail.Clone();
                                                clnDetail.ShipmCntDifference = 0;
                                                clnDtls.Add(clnDetail);
                                                break;
                                            }
                                    }
                                }

                                ttlSalesSlips.Add(clnSlip);
                            }
                        }
                    }
                }

                // 更新前の売上データが存在する場合にのみ事前集計を行う
                // ※oldSalesSlips 返品伝票の元伝票が設定された場合、集計した結果
                //　 相殺されてしまうので呼出し元で元伝票を設定しない様に注意する
                if (ListUtils.IsNotEmpty(oldSalesSlips))
                {
                    SalesHeaderComparer SalesHdrComp = new SalesHeaderComparer();
                    SalesDetailComparer SalesDtlComp = new SalesDetailComparer();

                    foreach (ArrayList oldslip in oldSalesSlips)
                    {
                        if (ListUtils.IsNotEmpty(oldslip))
                        {
                            oldHeader = ListUtils.Find(oldslip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                            oldDetails = ListUtils.Find(oldslip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (oldHeader != null && oldDetails != null && oldHeader.AcptAnOdrStatus ==30)
                            {
                                if (oldHeader.DebitNoteDiv == 2)
                                {
                                    // 元黒は集計対象から除外する
                                    continue;
                                }

                                # region [--- DEL 2009/01/20 M.Kubota --- 売上伝票のヘッダー部を変更した際の登録不具合対応]
                                //ttlSalesSlips.Sort(SalesHdrComp);
                                
                                //int salesIndex = ttlSalesSlips.BinarySearch(oldslip, SalesHdrComp);

                                //if (salesIndex > -1)
                                //{
                                //    // 同一キーの売上伝票データが存在する場合
                                //    newSlip = ttlSalesSlips[salesIndex] as ArrayList;
                                //    newHeader = ListUtils.Find(newSlip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                                //    newDetails = ListUtils.Find(newSlip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                                //    foreach (SalesDetailWork oldDetail in oldDetails)
                                //    {
                                //        newDetails.Sort(SalesDtlComp);
                                //        int detailIndex = newDetails.BinarySearch(oldDetail, SalesDtlComp);

                                //        if (detailIndex > -1)
                                //        {
                                //            // 同一キーの売上明細データが存在する場合 → 明細の内容が変更された or 何も変わっていない
                                //            SalesDetailWork newDetail = newDetails[detailIndex] as SalesDetailWork;

                                //            newDetail.ShipmentCnt -= oldDetail.ShipmentCnt;            // 出荷数 の変動差分値を算出する
                                //            newDetail.Cost -= oldDetail.Cost;                          // 原価 の変動差分値を算出する
                                //            newDetail.SalesMoneyTaxExc -= oldDetail.SalesMoneyTaxExc;  // 売上金額(税抜) の変動差分値を算出する

                                //            newDetail.ShipmCntDifference = 1;                          // <重要> 出荷差分数に 1 を設定する事により、"登録済み明細"とする
                                //        }
                                //        else
                                //        {
                                //            // 同一キーの売上明細データが存在しない場合 → 明細が削除された
                                //            // 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の明細だけを集計対象とする
                                //            switch (oldDetail.SalesSlipCdDtl)
                                //            {
                                //                case 0:  // 売上
                                //                case 1:  // 返品
                                //                case 2:  // 値引
                                //                    {
                                //                        SalesDetailWork clnDetail = oldDetail.Clone();
                                //                        clnDetail.ShipmentCnt *= -1;                               // 出荷数 の符号を反転させる
                                //                        clnDetail.Cost *= -1;                                      // 原価 の符号を反転させる
                                //                        clnDetail.SalesMoneyTaxExc *= -1;                          // 売上金額(税抜) の符号を反転させる

                                //                        clnDetail.ShipmCntDifference = -1;                         // <重要> 出荷差分数に -1 を設定する事により、"削除された明細"とする
                                //                        newDetails.Add(clnDetail);                                 // 削除された分として追加する
                                //                        break;
                                //                    }
                                //            }
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //    // 登録前 売上伝票データが、登録後 売上伝票データの中に含まれていない場合、伝票削除として扱う。
                                //    ArrayList wrkSlip = new ArrayList();
                                //    ArrayList wrkDetails = new ArrayList();

                                //    SalesSlipWork clnHeader = oldHeader.Clone();
                                //    wrkSlip.Add(clnHeader);
                                //    wrkSlip.Add(wrkDetails);

                                //    foreach (SalesDetailWork oldDetail in oldDetails)
                                //    {
                                //        // 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の明細だけを集計対象とする
                                //        switch (oldDetail.SalesSlipCdDtl)
                                //        {
                                //            case 0:  // 売上
                                //            case 1:  // 返品
                                //            case 2:  // 値引
                                //                {
                                //                    SalesDetailWork clnDetail = oldDetail.Clone();
                                //                    clnDetail.ShipmCntDifference = 0;                              // <重要> 伝票削除の場合には出荷差分数に 0 を設定する(後述処理の辻褄合わせ)
                                //                    wrkDetails.Add(clnDetail);
                                //                    break;
                                //                }
                                //        }
                                //    }

                                //    ttlSalesSlips.Add(wrkSlip);
                                //}
                                # endregion

                                //--- ADD 2009/01/20 M.Kubota --->>>
                                // 比較対象項目を拡大(企業コード・受注ステータス・売上伝票番号＋α)する
                                SalesHdrComp.AdvancedMode = true;
                                ttlSalesSlips.Sort(SalesHdrComp);
                                int salesIndex = ttlSalesSlips.BinarySearch(oldslip, SalesHdrComp);

                                if (salesIndex > -1)
                                {
                                    # region [ヘッダ情報も含めて同一の売上伝票データが存在する場合]
                                    // 同一キーの売上伝票データが存在する場合
                                    newSlip = ttlSalesSlips[salesIndex] as ArrayList;
                                    newHeader = ListUtils.Find(newSlip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                                    newDetails = ListUtils.Find(newSlip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                                    foreach (SalesDetailWork oldDetail in oldDetails)
                                    {
                                        newDetails.Sort(SalesDtlComp);
                                        int detailIndex = newDetails.BinarySearch(oldDetail, SalesDtlComp);

                                        if (detailIndex > -1)
                                        {
                                            // 同一キーの売上明細データが存在する場合 → 明細の内容が変更された or 何も変わっていない
                                            SalesDetailWork newDetail = newDetails[detailIndex] as SalesDetailWork;

                                            newDetail.ShipmentCnt -= oldDetail.ShipmentCnt;            // 出荷数 の変動差分値を算出する
                                            newDetail.Cost -= oldDetail.Cost;                          // 原価 の変動差分値を算出する
                                            newDetail.SalesMoneyTaxExc -= oldDetail.SalesMoneyTaxExc;  // 売上金額(税抜) の変動差分値を算出する

                                            newDetail.ShipmCntDifference = 1;                          // <重要> 出荷差分数に 1 を設定する事により、"登録済み明細"とする
                                        }
                                        else
                                        {
                                            // 同一キーの売上明細データが存在しない場合 → 明細が削除された
                                            // 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の明細だけを集計対象とする
                                            switch (oldDetail.SalesSlipCdDtl)
                                            {
                                                case 0:  // 売上
                                                case 1:  // 返品
                                                case 2:  // 値引
                                                    {
                                                        SalesDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.ShipmentCnt *= -1;                   // 出荷数 の符号を反転させる
                                                        clnDetail.Cost *= -1;                          // 原価 の符号を反転させる
                                                        clnDetail.SalesMoneyTaxExc *= -1;              // 売上金額(税抜) の符号を反転させる

                                                        clnDetail.ShipmCntDifference = -1;             // <重要> 出荷差分数に -1 を設定する事により、"削除された明細"とする
                                                        newDetails.Add(clnDetail);                     // 削除された分として追加する
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    # endregion
                                }
                                else
                                {
                                    // 比較対象項目を縮小(企業コード・受注ステータス・売上伝票番号)する
                                    SalesHdrComp.AdvancedMode = false;  
                                    ttlSalesSlips.Sort(SalesHdrComp);
                                    salesIndex = ttlSalesSlips.BinarySearch(oldslip, SalesHdrComp);

                                    if (salesIndex > -1)
                                    {
                                        # region [ヘッダ情報に変更があった場合]
                                        ArrayList wrkSlip = new ArrayList();
                                        ArrayList wrkDetails = new ArrayList();

                                        SalesSlipWork wrkHeader = oldHeader.Clone();
                                        wrkSlip.Add(wrkHeader);
                                        wrkSlip.Add(wrkDetails);

                                        foreach (SalesDetailWork oldDetail in oldDetails)
                                        {
                                            // 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の明細だけを集計対象とする
                                            switch (oldDetail.SalesSlipCdDtl)
                                            {
                                                case 0:  // 売上
                                                case 1:  // 返品
                                                case 2:  // 値引
                                                    {
                                                        SalesDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.ShipmentCnt *= -1;                    // 出荷数 の符号を反転させる
                                                        clnDetail.Cost *= -1;                           // 原価 の符号を反転させる
                                                        clnDetail.SalesMoneyTaxExc *= -1;               // 売上金額(税抜) の符号を反転させる
                                                        clnDetail.ShipmCntDifference = -1;              // <重要> 出荷差分数に -1 を設定する事により、"削除された明細"とする
                                                        wrkDetails.Add(clnDetail);                      // 削除された分として追加する
                                                        break;
                                                    }
                                            }
                                        }

                                        ttlSalesSlips.Add(wrkSlip);
                                        # endregion
                                    }
                                    else
                                    {
                                        # region [伝票が削除された場合]
                                        // 登録前 売上伝票データが、登録後 売上伝票データの中に含まれていない場合、伝票削除として扱う。
                                        ArrayList wrkSlip = new ArrayList();
                                        ArrayList wrkDetails = new ArrayList();

                                        SalesSlipWork wrkHeader = oldHeader.Clone();
                                        wrkSlip.Add(wrkHeader);
                                        wrkSlip.Add(wrkDetails);

                                        foreach (SalesDetailWork oldDetail in oldDetails)
                                        {
                                            // 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の明細だけを集計対象とする
                                            switch (oldDetail.SalesSlipCdDtl)
                                            {
                                                case 0:  // 売上
                                                case 1:  // 返品
                                                case 2:  // 値引
                                                    {
                                                        SalesDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.ShipmCntDifference = 0;               // <重要> 伝票削除の場合には出荷差分数に 0 を設定する(後述処理の辻褄合わせ)
                                                        wrkDetails.Add(clnDetail);
                                                        break;
                                                    }
                                            }
                                        }

                                        ttlSalesSlips.Add(wrkSlip);
                                        # endregion
                                    }
                                }
                                //--- ADD 2009/01/20 M.Kubota ---<<<
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
        /// 売上月次集計データ 集計・登録処理
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="totaledSalesSlips">事前集計済み売上伝票データリスト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <remarks>事前集計を終えた売上伝票データを集計し、売上月次集計データへ追加・更新を行います。</remarks>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
        private int WriteMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ArrayList totaledSalesSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 日付取得部品のインスタンスを取得
            FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));
            
            // 売上月次集計データ比較用クラスのインスタンスを取得
            //MTtlSalesSlipComparer mTtlSalesSlipComparer = new MTtlSalesSlipComparer();  // DEL 2010/05/13 未使用のため削除

            // 登録・更新対象となる売上月次集計データを保持する配列
            // -- UPD 2010/03/30 ------------------>>>
            //ArrayList MTtlSalesList = new ArrayList();
            Dictionary<string, MTtlSalesSlipWork> MTtlSalesDic = new Dictionary<string, MTtlSalesSlipWork>();
            // -- UPD 2010/03/30 ------------------<<<
            MTtlSalesSlipWork mTtlSalesSlipWork = null;

            // 伝票登録時には加算、伝票削除時には減算を行う
            int sign = (mTtlSalesUpdParaWork.SlipRegDiv == 0) ? -1 : 1;

            # region [売上月次集計処理]
            foreach (ArrayList slip in totaledSalesSlips)
            {
                SalesSlipWork header = ListUtils.Find(slip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                ArrayList details = ListUtils.Find(slip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                if (header == null || ListUtils.IsEmpty(details))
                {
                    continue;
                }

                foreach (SalesDetailWork detail in details)
                {
                    // [使用フラグ(0:登録不可 1:実績集計区分クリア 2:従業員コードクリア 3:登録可能), 売上月次集計データ] を持つ２次元配列を生成
                    object[,] MTtlSalesSlipArray = new object[12, 2];

                    for (int index = 0; index < MTtlSalesSlipArray.GetLength(0); index++)
                    {
                        mTtlSalesSlipWork = new MTtlSalesSlipWork();

                        # region [キー項目の設定]
                        // キー項目の設定
                        MTtlSalesSlipArray[index, 0] = 0;
                        MTtlSalesSlipArray[index, 1] = mTtlSalesSlipWork;

                        mTtlSalesSlipWork.EnterpriseCode = detail.EnterpriseCode;        // 企業コード
                        mTtlSalesSlipWork.LogicalDeleteCode = detail.LogicalDeleteCode;  // 論理削除フラグ
                        mTtlSalesSlipWork.AddUpSecCode = header.ResultsAddUpSecCd;       // 計上拠点コード ← 実績計上拠点コード

                        // 実績集計区分 (0:部品合計 1:在庫 2:純正 3:作業)
                        mTtlSalesSlipWork.RsltTtlDivCd = (int)index / 3;

                        switch (mTtlSalesSlipWork.RsltTtlDivCd)
                        {
                            case 0:
                                {
                                    // 売上商品区分 = 0:商品
                                    if (detail.SalesGoodsCd == 0)
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    // 在庫更新区分
                                    # region [--- DEL 2009/01/20 M.Kubota --- 商品値引を集計対象とする為に"在庫"の判定方法を変更]
                                    //if (detail.StockUpdateDiv)
                                    //{
                                    //    MTtlSalesSlipArray[index, 0] = 1;
                                    //}
                                    # endregion

                                    //--- ADD 2009/01/20 M.Kubota --->>>
                                    // "在庫"に集計する条件
                                    // ① 倉庫コードが設定されている
                                    // ② 売上在庫取寄せ区分が 1:在庫
                                    // ③ 出荷数が0以外
                                    // ④ 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の場合
                                    if (!string.IsNullOrEmpty(detail.WarehouseCode) &&
                                         detail.SalesOrderDivCd == 1 &&
                                         detail.ShipmentCnt != 0 &&
                                        (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || detail.SalesSlipCdDtl == 2))
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    //--- ADD 2009/01/20 M.Kubota ---<<<
                                    break;
                                }
                            case 2:
                                {
                                    // 商品属性 = 0:純正
                                    if (detail.GoodsKindCode == 0)
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    // 売上伝票区分(明細) = 5:作業
                                    //if (detail.SalesSlipCdDtl == 1)  //DEL 2009/01/20 M.Kubota
                                    if (detail.SalesSlipCdDtl == 5)    //ADD 2009/01/20 M.Kubota
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                        }

                        // 従業員区分 (10:販売担当者 20:受付担当者 30:入力担当者)
                        mTtlSalesSlipWork.EmployeeDivCd = (index % 3 + 1) * 10;

                        switch (mTtlSalesSlipWork.EmployeeDivCd)
                        {
                            case 10:
                                {
                                    // 2009/03/04 対象の従業員コードが未入力の場合もレコードを作成する >>>>>>>>>>>>
                                    // MANTIS 12019
                                    //if (!string.IsNullOrEmpty(header.SalesEmployeeCd))
                                    //{
                                        //// 従業員コード ← 販売従業員コード
                                        //mTtlSalesSlipWork.EmployeeCode = header.SalesEmployeeCd;
                                        //MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    //}

                                    // 従業員コード ← 販売従業員コード
                                    mTtlSalesSlipWork.EmployeeCode = header.SalesEmployeeCd;
                                    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                    break;
                                }
                            case 20:
                                {
                                    // 2009/03/04 対象の従業員コードが未入力の場合もレコードを作成する >>>>>>>>>>>>
                                    // MANTIS 12019
                                    //if (!string.IsNullOrEmpty(header.FrontEmployeeCd))
                                    //{
                                    //    // 従業員コード ← 受付従業員コード
                                    //    mTtlSalesSlipWork.EmployeeCode = header.FrontEmployeeCd;
                                    //    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    //}

                                    // 従業員コード ← 受付従業員コード
                                    mTtlSalesSlipWork.EmployeeCode = header.FrontEmployeeCd;
                                    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                    break;
                                }
                            case 30:
                                {
                                    // 2009/03/04 対象の従業員コードが未入力の場合もレコードを作成する >>>>>>>>>>>>
                                    // MANTIS 12019
                                    //if (!string.IsNullOrEmpty(header.SalesInputCode))
                                    //{
                                    //    // 従業員コード ← 売上入力者コード
                                    //    mTtlSalesSlipWork.EmployeeCode = header.SalesInputCode;
                                    //    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    //}

                                    // 従業員コード ← 売上入力者コード
                                    mTtlSalesSlipWork.EmployeeCode = header.SalesInputCode;
                                    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                    break;
                                }
                        }

                        mTtlSalesSlipWork.CustomerCode = header.CustomerCode;  // 得意先コード
                        mTtlSalesSlipWork.SupplierCd = detail.SupplierCd;      // 仕入先コード
                        mTtlSalesSlipWork.SalesCode = detail.SalesCode;        // 販売区分コード

                        # endregion

                        # region [集計項目の設定]
                        if ((int)MTtlSalesSlipArray[index, 0] == 3)
                        {
                            // 売上日より自社締の年月度を取得 ※負担が掛る事が予想されるため、登録可能なレコードにのみ設定する
                            DateTime AddUpDate;
                            dateGetAcs.GetYearMonth(detail.SalesDate, out AddUpDate);
                            mTtlSalesSlipWork.AddUpYearMonth = AddUpDate;                    // 計上年月

                            // 出荷回数
                            //if (header.DebitNoteDiv == 0 && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)   // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 2) && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)     // ADD 2009/12/24
                            {
                                if (detail.ShipmCntDifference != 1)
                                {
                                    // 明細登録の場合は加算、明細削除の場合は減算を行う
                                    int value = (detail.ShipmCntDifference == 0) ? 1 : -1;

                                    // "売上"の明細のみを集計の対象とします、また伝票削除時には減算します
                                    mTtlSalesSlipWork.SalesTimes += sign * value;  // 出荷回数
                                }
                            }   

                            // 売上数計
                            //if (header.DebitNoteDiv == 0 && detail.SalesSlipCdDtl == 0)                                //DEL 2009/01/20 M.Kubota
                            // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //赤伝、商品値引き時に数量が減算されない不具合の修正
                            //if (header.DebitNoteDiv == 0 && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1))  //ADD 2009/01/20 M.Kubota  返品分も売上数計の集計対象とする
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  返品分も売上数計の集計対象とする  // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  返品分も売上数計の集計対象とする  // ADD 2009/12/24
                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                # region [--- DEL 2009/01/20 M.Kubota --- 返品の場合、数量がマイナス値で格納されてくるので符号反転処理(value)を削除]
                                // 売上伝票区分が 0:売上 の場合は加算、1:返品 の場合は減算を行う
                                //int value = (header.SalesSlipCd == 0) ? 1 : -1;
                                //mTtlSalesSlipWork.TotalSalesCount += sign * value * detail.ShipmentCnt;  // 売上数計
                                # endregion
                                
                                mTtlSalesSlipWork.TotalSalesCount += sign * detail.ShipmentCnt;  // 売上数計  //ADD 2009/01/20 M.Kubota
                            }

                            if (header.SalesSlipCd == 0)
                            {
                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 0:  // 0:売上
                                        {
                                            // 売上金額
                                            mTtlSalesSlipWork.SalesMoney = sign * detail.SalesMoneyTaxExc;

                                            // 粗利金額
                                            mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 1:  // 1:返品
                                        {
                                            // 返品額
                                            mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;

                                            // 粗利金額
                                            mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 2:  // 2:値引
                                        {
                                            // PM7の仕様に合わせて行値引は集計対象外とする。
                                            // ※行値引と商品値引の判断はUIと同様に数量の有無(!=0)で判断する
                                            if (detail.ShipmentCnt != 0)  //ADD 2009/01/20 M.Kubota
                                            {
                                                // 値引金額
                                                mTtlSalesSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // 粗利金額
                                                mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }
                                            // 2009/03/04 売上の行値引は売上金額に反映する >>>>>>>>>>>>>>>>>
                                            else
                                            {
                                                // 売上金額
                                                mTtlSalesSlipWork.SalesMoney = sign * detail.SalesMoneyTaxExc;
                                                // 粗利金額
                                                mTtlSalesSlipWork.GrossProfit = sign * detail.SalesMoneyTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                            break;
                                        }
                                }
                            }
                            else  if (header.SalesSlipCd == 1)
                            {
                                //2009/02/05 >>>>>>>>>>>>>>>>>>>>>>>>>
                                // Mantis 11169の対応 返品伝票の行値引金額を値引き金額にセットする(関連ID:11102)

                                //// 返品額
                                //mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                //// 粗利金額
                                //mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 1:  // 1:返品
                                        {
                                            // 返品額
                                            mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                            // 粗利金額
                                            mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 2:  // 2:値引
                                        {

                                            // ※行値引と商品値引の判断はUIと同様に数量の有無(!=0)で判断する
                                            if (detail.ShipmentCnt != 0)
                                            {
                                                // 値引金額
                                                mTtlSalesSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // 粗利金額
                                                mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }
                                            // 2009/03/04 返品の行値引は返品金額に反映する >>>>>>>>>>>>>>>>>
                                            else
                                            {
                                                // 返品額
                                                mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                                // 粗利金額
                                                mTtlSalesSlipWork.GrossProfit = sign * detail.SalesMoneyTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                            break;
                                        }
                                }
                                //2009/02/05 <<<<<<<<<<<<<<<<<<<<<<<<<

                            }

                            // -- DEL 2010/03/30 ----------------------->>>
                            //MTtlSalesList.Sort(mTtlSalesSlipComparer);

                            //int SearchIndex = MTtlSalesList.BinarySearch(mTtlSalesSlipWork, mTtlSalesSlipComparer);
                            // -- DEL 2010/03/30 -----------------------<<<

                            // -- UPD 2010/03/30 ---------------------------------------->>>
                            //if (SearchIndex < 0)
                            //{
                            //    // 同一キーが存在しない場合は登録リストに追加する
                            //    MTtlSalesList.Add(mTtlSalesSlipWork);
                            //}
                            //else
                            //{
                            //    // 同一キーが存在している場合は集計項目を加算する
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).SalesTimes += mTtlSalesSlipWork.SalesTimes;                  // 売上回数
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).TotalSalesCount += mTtlSalesSlipWork.TotalSalesCount;        // 売上数計
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).SalesMoney += mTtlSalesSlipWork.SalesMoney;                  // 売上金額
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).SalesRetGoodsPrice += mTtlSalesSlipWork.SalesRetGoodsPrice;  // 返品金額  //ADD 2009/01/20 M.Kubota
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).DiscountPrice += mTtlSalesSlipWork.DiscountPrice;            // 値引金額
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).GrossProfit += mTtlSalesSlipWork.GrossProfit;                // 粗利金額
                            //}

                            if (!MTtlSalesDic.ContainsKey(MakeKeyMTtlSalesSlip(mTtlSalesSlipWork)))
                            {
                                // 同一キーが存在しない場合は登録リストに追加する
                                MTtlSalesDic.Add(MakeKeyMTtlSalesSlip(mTtlSalesSlipWork), mTtlSalesSlipWork);
                            }
                            else
                            {
                                MTtlSalesSlipWork work = MTtlSalesDic[MakeKeyMTtlSalesSlip(mTtlSalesSlipWork)];
                                // 同一キーが存在している場合は集計項目を加算する
                                work.SalesTimes += mTtlSalesSlipWork.SalesTimes;                  // 売上回数
                                work.TotalSalesCount += mTtlSalesSlipWork.TotalSalesCount;        // 売上数計
                                work.SalesMoney += mTtlSalesSlipWork.SalesMoney;                  // 売上金額
                                work.SalesRetGoodsPrice += mTtlSalesSlipWork.SalesRetGoodsPrice;  // 返品金額 
                                work.DiscountPrice += mTtlSalesSlipWork.DiscountPrice;            // 値引金額
                                work.GrossProfit += mTtlSalesSlipWork.GrossProfit;                // 粗利金額
                            }
                            // -- UPD 2010/03/30 ----------------------------------------<<<
                        }
                        # endregion
                    }
                }
            }
            # endregion

            # region [売上月次集計データ登録]

            string sqlText = string.Empty;
            SqlCommand command = new SqlCommand(sqlText, connection, transaction);
            SqlDataReader reader = null;
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
            try
            {
                // -- UPD 2010/03/30 -------------------------->>>
                //foreach (MTtlSalesSlipWork item in MTtlSalesList)
                foreach (MTtlSalesSlipWork item in MTtlSalesDic.Values)
                // -- UPD 2010/03/30 --------------------------<<<
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
                    sqlText += " ,MTTL.ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.ADDUPYEARMONTHRF" + Environment.NewLine;
                    sqlText += " ,MTTL.RSLTTTLDIVCDRF" + Environment.NewLine;
                    sqlText += " ,MTTL.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    sqlText += " ,MTTL.EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESCODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESTIMESRF" + Environment.NewLine;
                    sqlText += " ,MTTL.TOTALSALESCOUNTRF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESMONEYRF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESRETGOODSPRICERF" + Environment.NewLine;
                    sqlText += " ,MTTL.DISCOUNTPRICERF" + Environment.NewLine;
                    sqlText += " ,MTTL.GROSSPROFITRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  MTTLSALESSLIPRF AS MTTL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  MTTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND MTTL.ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "  AND MTTL.RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                    sqlText += "  AND MTTL.EMPLOYEEDIVCDRF = @FINDEMPLOYEEDIVCD" + Environment.NewLine;
                    sqlText += "  AND MTTL.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "  AND MTTL.SALESCODERF = @FINDSALESCODE" + Environment.NewLine;
                    command.CommandText = sqlText;
                    command.Parameters.Clear();
                    # endregion

                    # region [検索用 パラメータオブジェクトの作成]
                    SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findAddUpSecCode = command.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);      // 計上拠点コード
                    SqlParameter findAddUpYearMonth = command.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);    // 計上年月
                    SqlParameter findRsltTtlDivCd = command.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);        // 実績集計区分
                    SqlParameter findEmployeeDivCd = command.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);      // 従業員区分
                    SqlParameter findEmployeeCode = command.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);      // 従業員コード
                    SqlParameter findCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);        // 得意先コード
                    SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);            // 仕入先コード
                    SqlParameter findSalesCode = command.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);              // 販売区分コード
                    # endregion

                    # region [検索用 パラメータオブジェクトの値設定]
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // 企業コード
                    findAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // 計上拠点コード
                    findAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // 計上年月
                    findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // 実績集計区分
                    findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(item.EmployeeDivCd);                 // 従業員区分
                    // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // MANTIS 12019
                    //findEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // 従業員コード
                    findEmployeeCode.Value = item.EmployeeCode;                  // 従業員コード
                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // 得意先コード
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // 仕入先コード
                    findSalesCode.Value = SqlDataMediator.SqlSetInt32(item.SalesCode);                         // 販売区分コード
                    # endregion

                    command.CommandTimeout = dbCommandTimeout;  //ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE MTTLSALESSLIPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF = @RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,SALESCODERF = @SALESCODE" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF = @SALESTIMES" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF = @TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF = @SALESMONEY" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF = @SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF = @DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF = @GROSSPROFIT" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "  AND RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF = @FINDEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        sqlText += "  AND SALESCODERF = @FINDSALESCODE" + Environment.NewLine;
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
                        item.AddUpSecCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ADDUPSECCODERF"));                  // 計上拠点コード
                        item.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(reader, reader.GetOrdinal("ADDUPYEARMONTHRF"));  // 計上年月
                        item.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("RSLTTTLDIVCDRF"));                   // 実績集計区分
                        item.EmployeeDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("EMPLOYEEDIVCDRF"));                 // 従業員区分
                        item.EmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("EMPLOYEECODERF"));                  // 従業員コード
                        item.CustomerCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("CUSTOMERCODERF"));                   // 得意先コード
                        item.SupplierCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SUPPLIERCDRF"));                       // 仕入先コード
                        item.SalesCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SALESCODERF"));                         // 販売区分コード
                        item.SalesTimes += SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SALESTIMESRF"));                      // 売上回数
                        item.TotalSalesCount += SqlDataMediator.SqlGetDouble(reader, reader.GetOrdinal("TOTALSALESCOUNTRF"));           // 売上数計
                        item.SalesMoney += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESMONEYRF"));                      // 売上金額
                        item.SalesRetGoodsPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESRETGOODSPRICERF"));      // 返品額
                        item.DiscountPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("DISCOUNTPRICERF"));                // 値引金額
                        item.GrossProfit += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("GROSSPROFITRF"));                    // 粗利金額
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
                        sqlText += "INSERT INTO MTTLSALESSLIPRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += " ,SALESCODERF" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF" + Environment.NewLine;
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
                        sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,@RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,@EMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,@SALESCODE" + Environment.NewLine;
                        sqlText += " ,@SALESTIMES" + Environment.NewLine;
                        sqlText += " ,@TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,@SALESMONEY" + Environment.NewLine;
                        sqlText += " ,@SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,@DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,@GROSSPROFIT" + Environment.NewLine;
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
                    SqlParameter paraAddUpSecCode = command.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpYearMonth = command.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraRsltTtlDivCd = command.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                    SqlParameter paraEmployeeDivCd = command.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter paraEmployeeCode = command.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = command.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraSupplierCd = command.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSalesCode = command.Parameters.Add("@SALESCODE", SqlDbType.Int);
                    SqlParameter paraSalesTimes = command.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                    SqlParameter paraTotalSalesCount = command.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                    SqlParameter paraSalesMoney = command.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                    SqlParameter paraSalesRetGoodsPrice = command.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                    SqlParameter paraDiscountPrice = command.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                    SqlParameter paraGrossProfit = command.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);
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
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // 計上拠点コード 
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // 計上年月
                    paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // 実績集計区分
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(item.EmployeeDivCd);                 // 従業員区分
                    // 2009/03/04 文字列のキー項目にNULLがセットされる現象を回避>>>>>>
                    // MANTIS 12019
                    //paraEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // 従業員コード
                    paraEmployeeCode.Value = item.EmployeeCode;                  // 従業員コード
                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // 得意先コード
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // 仕入先コード
                    paraSalesCode.Value = SqlDataMediator.SqlSetInt32(item.SalesCode);                         // 販売区分コード
                    paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(item.SalesTimes);                       // 売上回数
                    paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(item.TotalSalesCount);            // 売上数計
                    paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(item.SalesMoney);                       // 売上金額
                    paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(item.SalesRetGoodsPrice);       // 返品額
                    paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(item.DiscountPrice);                 // 値引金額
                    paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(item.GrossProfit);                     // 粗利金額
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

            return status;
        }

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        // -- ADD 2010/03/30 ----------------------------->>>
        /// <summary>
        /// 売上月次集計データ用Key情報生成
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string MakeKeyMTtlSalesSlip(MTtlSalesSlipWork item)
        {

            return SqlDataMediator.SqlSetString(item.EnterpriseCode) + "-" +                         // 企業コード
                    SqlDataMediator.SqlSetString(item.AddUpSecCode) + "-" +                           // 計上拠点コード
                    SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth).ToString() + "-" +  // 計上年月
                    SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd).ToString() + "-" +                 // 実績集計区分
                    SqlDataMediator.SqlSetInt32(item.EmployeeDivCd).ToString() + "-" +                // 従業員区分
                    item.EmployeeCode + "-" +                                                         // 従業員コード
                    SqlDataMediator.SqlSetInt32(item.CustomerCode).ToString() + "-" +                 // 得意先コード
                    SqlDataMediator.SqlSetInt32(item.SupplierCd).ToString() + "-" +                   // 仕入先コード
                    SqlDataMediator.SqlSetInt32(item.SalesCode).ToString();                           // 販売区分コード

        }
        // -- ADD 2010/03/30 -----------------------------<<<

        /// <summary>
        /// 商品別売上月次集計データ 集計・登録処理
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="totaledSalesSlips">事前集計済み売上伝票データリスト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <remarks>事前集計を終えた売上伝票データを集計し、商品別売上月次集計データへ追加・更新を行います。
        /// <br>Update Note: 2012/03/30 郭永祥 </br>
        /// <br>管理番号   ：10801804-00 2012/05/24配信分</br>
        /// <br>             Redmine#29142 「商品値引」の場合は集計対象外となるように修正する</br>
        /// <br>Update Note: 2012/03/31 李小路</br>							
        /// <br>管理番号   ：10707327-00 2012/05/24配信分</br>							
        /// <br>             Redmine#29215　得意先電子元帳と金額が合わないの修正</br>							
        /// </remarks>
        /// <returns>STATUS</returns>
        private int WriteGoodsMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ArrayList totaledSalesSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 日付取得部品のインスタンスを取得
            FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));

            // 売上月次集計データ比較用クラスのインスタンスを取得
            //GoodsMTtlSaSlipComparer goodsMTtlSaSlipComparer = new GoodsMTtlSaSlipComparer();   // DEL 2010/05/13 未使用のため削除

            // 登録・更新対象となる売上月次集計データを保持する配列
            // -- UPD 2010/03/30 ---------------------->>>
            //ArrayList GoodsMTtlSalseList = new ArrayList();
            Dictionary<string, GoodsMTtlSaSlipWork> GoodsMTtlSalseDic = new Dictionary<string, GoodsMTtlSaSlipWork>();
            // -- UPD 2010/03/30 ----------------------<<<
            GoodsMTtlSaSlipWork goodsMTtlSaSlipWork = null;

            // 伝票登録時には加算、伝票削除時には減算を行う
            int sign = (mTtlSalesUpdParaWork.SlipRegDiv == 0) ? -1 : 1;

            # region [商品別売上月次集計処理]
            foreach (ArrayList slip in totaledSalesSlips)
            {
                SalesSlipWork header = ListUtils.Find(slip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                ArrayList details = ListUtils.Find(slip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                if (header == null || ListUtils.IsEmpty(details))
                {
                    continue;
                }

                foreach (SalesDetailWork detail in details)
                {
                    // 商品番号が未登録のデータ(行値引に相当)は集計対象から外す
                    //if (string.IsNullOrEmpty(detail.GoodsNo))     //DEL 李小路　2012/03/31 Redmine#29215
                    if (string.IsNullOrEmpty(detail.GoodsNo) && detail.BLGoodsCode == 0)    //ADD 李小路　2012/03/31 Redmine#29215
                    {
                        continue;
                    }
                    
                    // [使用フラグ(0:登録不可 1:登録可能), 商品別売上月次集計データ] を持つ２次元配列を生成
                    object[,] GoodsMTtlSaSlipArray = new object[4, 2];

                    for (int index = 0; index < GoodsMTtlSaSlipArray.GetLength(0); index++)
                    {
                        goodsMTtlSaSlipWork = new GoodsMTtlSaSlipWork();

                        # region [キー項目の設定]
                        // キー項目の設定
                        GoodsMTtlSaSlipArray[index, 0] = 0;
                        GoodsMTtlSaSlipArray[index, 1] = goodsMTtlSaSlipWork;

                        goodsMTtlSaSlipWork.EnterpriseCode = detail.EnterpriseCode;        // 企業コード
                        goodsMTtlSaSlipWork.LogicalDeleteCode = detail.LogicalDeleteCode;  // 論理削除フラグ
                        goodsMTtlSaSlipWork.AddUpSecCode = header.ResultsAddUpSecCd;       // 計上拠点コード ← 実績計上拠点コード

                        // 実績集計区分 (0:部品合計 1:在庫 2:純正 3:作業)
                        goodsMTtlSaSlipWork.RsltTtlDivCd = index;

                        switch (goodsMTtlSaSlipWork.RsltTtlDivCd)
                        {
                            case 0:
                                {
                                    // 売上商品区分 = 0:商品
                                    if (detail.SalesGoodsCd == 0)
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    // 在庫更新区分
                                    # region [--- DEL 2009/01/20 M.Kubota --- 商品値引きを集計対象とする為に"在庫"の判定方法を変更]
                                    //if (detail.StockUpdateDiv)
                                    //{
                                    //    GoodsMTtlSaSlipArray[index, 0] = 1;
                                    //}
                                    # endregion

                                    //--- ADD 2009/01/20 M.Kubota --->>>
                                    // "在庫"に集計する条件
                                    // ① 倉庫コードが設定されている
                                    // ② 売上在庫取寄せ区分が 1:在庫
                                    // ③ 出荷数が0以外
                                    // ④ 売上伝票区分(明細)が 0:売上 1:返品 2:値引 の場合
                                    if (!string.IsNullOrEmpty(detail.WarehouseCode) &&
                                         detail.SalesOrderDivCd == 1 &&
                                         detail.ShipmentCnt != 0 &&
                                        (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || detail.SalesSlipCdDtl == 2))
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    //--- ADD 2009/01/20 M.Kubota ---<<<
                                    break;
                                }
                            case 2:
                                {
                                    // 商品属性 = 0:純正
                                    if (detail.GoodsKindCode == 0)
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    // 売上伝票区分(明細) = 5:作業
                                    //if (detail.SalesSlipCdDtl == 1)  //DEL 2009/01/20 M.Kubota
                                    if (detail.SalesSlipCdDtl == 5)    //ADD 2009/01/20 M.Kubota
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                        }

                        goodsMTtlSaSlipWork.EmployeeCode = header.SalesEmployeeCd;  // 従業員コード ← 販売従業員コード
                        goodsMTtlSaSlipWork.CustomerCode = header.CustomerCode;     // 得意先コード
                        goodsMTtlSaSlipWork.BLGoodsCode = detail.BLGoodsCode;       // BL商品コード
                        goodsMTtlSaSlipWork.GoodsMakerCd = detail.GoodsMakerCd;     // 商品メーカーコード
                        goodsMTtlSaSlipWork.GoodsNo = detail.GoodsNo;               // 商品番号
                        goodsMTtlSaSlipWork.SupplierCd = detail.SupplierCd;         // 仕入先コード
                        // -- ADD 2010/05/13 --------------------------------------------->>>
                        goodsMTtlSaSlipWork.GoodsName = detail.GoodsName;           // 商品名称
                        goodsMTtlSaSlipWork.GoodsNameKana = detail.GoodsNameKana;   // 商品名称カナ
                        // -- ADD 2010/05/13 ---------------------------------------------<<<

                        # endregion

                        # region [集計項目の設定]
                        if ((int)GoodsMTtlSaSlipArray[index, 0] == 1)
                        {
                            // 売上日より自社締の年月度を取得 ※負担が掛る事が予想されるため、登録可能なレコードにのみ設定する
                            DateTime AddUpDate;
                            dateGetAcs.GetYearMonth(detail.SalesDate, out AddUpDate);
                            goodsMTtlSaSlipWork.AddUpYearMonth = AddUpDate;                    // 計上年月

                            // 出荷回数
                            //if (header.DebitNoteDiv == 0 && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)   // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 2) && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)     // ADD 2009/12/24
                            {
                                if (detail.ShipmCntDifference != 1)
                                {
                                    // 明細登録の場合は加算、明細削除の場合は減算を行う
                                    int value = (detail.ShipmCntDifference == 0) ? 1 : -1;

                                    // "売上"の明細のみを集計の対象とします、また伝票削除時には減算します
                                    goodsMTtlSaSlipWork.SalesTimes += sign * value;  // 出荷回数
                                }
                            }

                            // 売上数計
                            //if (header.DebitNoteDiv == 0 && detail.SalesSlipCdDtl == 0)                                //DEL 2009/01/20 M.Kubota
                            // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //赤伝、商品値引き時に数量が減算されない不具合の修正
                            //if (header.DebitNoteDiv == 0 && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1))  //ADD 2009/01/20 M.Kubota  返品分も売上数計の集計対象とする
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  返品分も売上数計の集計対象とする                  // DEL 2009/12/24
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  返品分も売上数計の集計対象とする  // ADD 2009/12/24                  //DEL 郭永祥 2012/03/30 Redmine#29142
                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1))  //ADD 郭永祥 2012/03/30 Redmine#29142
                            {
                                # region [--- DEL 2009/01/20 M.Kubota --- 返品の場合、数量がマイナス値で格納されてくるので符号反転処理(value)を削除]
                                // 売上伝票区分が 0:売上 の場合は加算、1:返品 の場合は減算を行う
                                //int value = (header.SalesSlipCd == 0) ? 1 : -1;
                                //goodsMTtlSaSlipWork.TotalSalesCount += sign * value * detail.ShipmentCnt;  // 売上数計
                                # endregion

                                goodsMTtlSaSlipWork.TotalSalesCount += sign * detail.ShipmentCnt;  // 売上数計  //ADD 2009/01/20 M.Kubota
                            }

                            if (header.SalesSlipCd == 0)
                            {
                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 0:  // 0:売上
                                        {
                                            // 売上金額
                                            goodsMTtlSaSlipWork.SalesMoney = sign * detail.SalesMoneyTaxExc;

                                            // 粗利金額
                                            goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 1:  // 1:返品
                                        {
                                            // 粗利金額
                                            goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            // 返品額
                                            goodsMTtlSaSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                            break;
                                        }
                                    case 2:  // 2:値引
                                        {
                                            // PM7の仕様に合わせて行値引は集計対象外とする。
                                            // ※行値引と商品値引の判断はUIと同様に数量の有無(!=0)で判断する
                                            if (detail.ShipmentCnt != 0)  //ADD 2009/01/20 M.Kubota
                                            {
                                                // 値引金額
                                                goodsMTtlSaSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // 粗利金額
                                                goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }
                                            break;
                                        }
                                }
                            }
                            else if (header.SalesSlipCd == 1)
                            {
                                //2009/02/05 >>>>>>>>>>>>>>>>>>>>>>>>>
                                // Mantis 11169の対応 返品伝票の行値引金額を値引き金額にセットする(関連ID:11102)

                                //// 返品額
                                //goodsMTtlSaSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                //// 粗利金額
                                //goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 1:  // 1:返品
                                        {
                                            // 返品額
                                            goodsMTtlSaSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                            // 粗利金額
                                            goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 2:  // 2:値引
                                        {

                                            // ※行値引と商品値引の判断はUIと同様に数量の有無(!=0)で判断する
                                            if (detail.ShipmentCnt != 0)
                                            {
                                                // 値引金額
                                                goodsMTtlSaSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // 粗利金額
                                                goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }

                                            break;
                                        }
                                }
                                //2009/02/05 <<<<<<<<<<<<<<<<<<<<<<<<<
                            }

                            // -- DEL 2010/03/30 -------------------------->>>
                            //GoodsMTtlSalseList.Sort(goodsMTtlSaSlipComparer);

                            //int SearchIndex = GoodsMTtlSalseList.BinarySearch(goodsMTtlSaSlipWork, goodsMTtlSaSlipComparer);
                            // -- DEL 2010/03/30 --------------------------<<<

                            // -- UPD 2010/03/30 -------------------------->>>
                            //if (SearchIndex < 0)
                            //{
                            //    // 同一キーが存在しない場合は登録リストに追加する
                            //    GoodsMTtlSalseList.Add(goodsMTtlSaSlipWork);
                            //}
                            //else
                            //{
                            //    // 同一キーが存在している場合は集計項目を加算する
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesTimes += goodsMTtlSaSlipWork.SalesTimes;            // 売上回数
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).TotalSalesCount += goodsMTtlSaSlipWork.TotalSalesCount;  // 売上数計
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesMoney += goodsMTtlSaSlipWork.SalesMoney;            // 売上金額
                            //    //(GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesMoney += goodsMTtlSaSlipWork.SalesRetGoodsPrice;    // 返品金額  //ADD 2009/01/20 M.Kubota DEL //2009/03/24
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesRetGoodsPrice += goodsMTtlSaSlipWork.SalesRetGoodsPrice;    // 返品金額  //ADD 2009/03/24
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).DiscountPrice += goodsMTtlSaSlipWork.DiscountPrice;      // 値引金額  //ADD 2009/03/24
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).GrossProfit += goodsMTtlSaSlipWork.GrossProfit;          // 粗利金額
                            //}

                            if (!GoodsMTtlSalseDic.ContainsKey(MakeKeyGoodsMTtlSaSlip(goodsMTtlSaSlipWork)))
                            {
                                // 同一キーが存在しない場合は登録リストに追加する
                                GoodsMTtlSalseDic.Add(MakeKeyGoodsMTtlSaSlip(goodsMTtlSaSlipWork), goodsMTtlSaSlipWork);
                            }
                            else
                            {
                                GoodsMTtlSaSlipWork work = GoodsMTtlSalseDic[MakeKeyGoodsMTtlSaSlip(goodsMTtlSaSlipWork)];

                                // 同一キーが存在している場合は集計項目を加算する
                                work.SalesTimes += goodsMTtlSaSlipWork.SalesTimes;            // 売上回数
                                work.TotalSalesCount += goodsMTtlSaSlipWork.TotalSalesCount;  // 売上数計
                                work.SalesMoney += goodsMTtlSaSlipWork.SalesMoney;            // 売上金額
                                work.SalesRetGoodsPrice += goodsMTtlSaSlipWork.SalesRetGoodsPrice;    // 返品金額 
                                work.DiscountPrice += goodsMTtlSaSlipWork.DiscountPrice;      // 値引金額 
                                work.GrossProfit += goodsMTtlSaSlipWork.GrossProfit;          // 粗利金額

                                // -- ADD 2010/05/13 ------------------------------------->>>
                                work.GoodsName = goodsMTtlSaSlipWork.GoodsName;               //商品名称
                                work.GoodsNameKana = goodsMTtlSaSlipWork.GoodsNameKana;       //商品名称カナ
                                // -- ADD 2010/05/13 -------------------------------------<<<
                            }
                            // -- UPD 2010/03/30 --------------------------<<<

                        }
                        # endregion
                    }
                }
            }
            # endregion

            # region [商品別売上月次集計データ登録]

            string sqlText = string.Empty;
            SqlCommand command = new SqlCommand(sqlText, connection, transaction);
            SqlDataReader reader = null;

            try
            {
                // -- UPD 2010/03/30 -------------------------------->>>
                //foreach (GoodsMTtlSaSlipWork item in GoodsMTtlSalseList)
                foreach (GoodsMTtlSaSlipWork item in GoodsMTtlSalseDic.Values)
                // -- UPD 2010/03/30 --------------------------------<<<
                {
                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  GODS.CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,GODS.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,GODS.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,GODS.ADDUPYEARMONTHRF" + Environment.NewLine;
                    sqlText += " ,GODS.RSLTTTLDIVCDRF" + Environment.NewLine;
                    sqlText += " ,GODS.EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,GODS.BLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,GODS.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,GODS.GOODSNORF" + Environment.NewLine;
                    sqlText += " ,GODS.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,GODS.SALESTIMESRF" + Environment.NewLine;
                    sqlText += " ,GODS.TOTALSALESCOUNTRF" + Environment.NewLine;
                    sqlText += " ,GODS.SALESMONEYRF" + Environment.NewLine;
                    sqlText += " ,GODS.SALESRETGOODSPRICERF" + Environment.NewLine;
                    sqlText += " ,GODS.DISCOUNTPRICERF" + Environment.NewLine;
                    sqlText += " ,GODS.GROSSPROFITRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSMTTLSASLIPRF AS GODS" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  GODS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GODS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND GODS.ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND GODS.ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "  AND GODS.RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                    sqlText += "  AND GODS.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  AND GODS.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "  AND GODS.BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                    sqlText += "  AND GODS.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GODS.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND GODS.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                    command.CommandText = sqlText;
                    command.Parameters.Clear();
                    # endregion

                    # region [検索用 パラメータオブジェクトの作成]
                    SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findAddUpSecCode = command.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);      // 計上拠点コード
                    SqlParameter findAddUpYearMonth = command.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);    // 計上年月
                    SqlParameter findRsltTtlDivCd = command.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);        // 実績集計区分
                    SqlParameter findEmployeeCode = command.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);      // 従業員コード
                    SqlParameter findCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);        // 得意先コード
                    SqlParameter findBLGoodsCode = command.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);          // BL商品コード
                    SqlParameter findGoodsMakerCd = command.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);        // 商品メーカーコード
                    SqlParameter findGoodsNo = command.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);             // 商品番号
                    SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);            // 仕入先コード
                    # endregion

                    # region [検索用 パラメータオブジェクトの値設定]
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // 企業コード
                    findAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // 計上拠点コード
                    findAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // 計上年月
                    findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // 実績集計区分
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // 従業員コード
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // 得意先コード
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(item.BLGoodsCode);                     // BL商品コード
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(item.GoodsMakerCd);                   // 商品メーカーコード
                    //findGoodsNo.Value = SqlDataMediator.SqlSetString(item.GoodsNo);                            // 商品番号 //DEL 李小路　2012/03/31 Redmine#29215
                    findGoodsNo.Value = item.GoodsNo;                                                           // 商品番号 //ADD 李小路　2012/03/31 Redmine#29215
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // 仕入先コード
                    # endregion

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE GOODSMTTLSASLIPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF = @RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,BLGOODSCODERF = @BLGOODSCODE" + Environment.NewLine;
                        sqlText += " ,GOODSMAKERCDRF = @GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " ,GOODSNORF = @GOODSNO" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF = @SALESTIMES" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF = @TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF = @SALESMONEY" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF = @SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF = @DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF = @GROSSPROFIT" + Environment.NewLine;
                        // -- ADD 2010/05/13 ----------------------------------->>>
                        sqlText += " ,GOODSNAMERF = @GOODSNAME" + Environment.NewLine;
                        sqlText += " ,GOODSNAMEKANARF = @GOODSNAMEKANA" + Environment.NewLine;
                        // -- ADD 2010/05/13 -----------------------------------<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "  AND RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
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
                        item.AddUpSecCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ADDUPSECCODERF"));                  // 計上拠点コード
                        item.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(reader, reader.GetOrdinal("ADDUPYEARMONTHRF"));  // 計上年月
                        item.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("RSLTTTLDIVCDRF"));                   // 実績集計区分
                        item.EmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("EMPLOYEECODERF"));                  // 従業員コード
                        item.CustomerCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("CUSTOMERCODERF"));                   // 得意先コード
                        item.BLGoodsCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("BLGOODSCODERF"));                     // BL商品コード
                        item.GoodsMakerCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("GOODSMAKERCDRF"));                   // 商品メーカーコード
                        //item.GoodsNo = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("GOODSNORF"));                            // 商品番号   //DEL 李小路　2012/03/31 Redmine#29215
                        item.GoodsNo = string.Format("{0}", reader["GOODSNORF"]);                                                       // 商品番号 //ADD 李小路　2012/03/31 Redmine#29215
                        item.SupplierCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SUPPLIERCDRF"));                       // 仕入先コード
                        item.SalesTimes += SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SALESTIMESRF"));                      // 売上回数
                        item.TotalSalesCount += SqlDataMediator.SqlGetDouble(reader, reader.GetOrdinal("TOTALSALESCOUNTRF"));           // 売上数計
                        item.SalesMoney += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESMONEYRF"));                      // 売上金額
                        item.SalesRetGoodsPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESRETGOODSPRICERF"));      // 返品額
                        item.DiscountPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("DISCOUNTPRICERF"));                // 値引金額
                        item.GrossProfit += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("GROSSPROFITRF"));                    // 粗利金額
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
                        sqlText += "INSERT INTO GOODSMTTLSASLIPRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,BLGOODSCODERF" + Environment.NewLine;
                        sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += " ,GOODSNORF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF" + Environment.NewLine;
                        // -- ADD 2010/05/13 --------------------------->>>
                        sqlText += " ,GOODSNAMERF" + Environment.NewLine;
                        sqlText += " ,GOODSNAMEKANARF" + Environment.NewLine;
                        // -- ADD 2010/05/13 ---------------------------<<<
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
                        sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,@RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@BLGOODSCODE" + Environment.NewLine;
                        sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " ,@GOODSNO" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,@SALESTIMES" + Environment.NewLine;
                        sqlText += " ,@TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,@SALESMONEY" + Environment.NewLine;
                        sqlText += " ,@SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,@DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,@GROSSPROFIT" + Environment.NewLine;
                        // -- ADD 2010/05/13 --------------------------->>>
                        sqlText += " ,@GOODSNAME" + Environment.NewLine;
                        sqlText += " ,@GOODSNAMEKANA" + Environment.NewLine;
                        // -- ADD 2010/05/13 ---------------------------<<<
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
                    SqlParameter paraAddUpSecCode = command.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpYearMonth = command.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraRsltTtlDivCd = command.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                    SqlParameter paraEmployeeCode = command.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = command.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = command.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = command.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsNo = command.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraSupplierCd = command.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSalesTimes = command.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                    SqlParameter paraTotalSalesCount = command.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                    SqlParameter paraSalesMoney = command.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                    SqlParameter paraSalesRetGoodsPrice = command.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                    SqlParameter paraDiscountPrice = command.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                    SqlParameter paraGrossProfit = command.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);
                    // -- ADD 2010/05/13 ---------------------------------------------->>>
                    SqlParameter paraGoodsName = command.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsNameKana = command.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                    // -- ADD 2010/05/13 ----------------------------------------------<<<
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
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // 計上拠点コード
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // 計上年月
                    paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // 実績集計区分
                    paraEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // 従業員コード
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // 得意先コード
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(item.BLGoodsCode);                     // BL商品コード
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(item.GoodsMakerCd);                   // 商品メーカーコード
                    //paraGoodsNo.Value = SqlDataMediator.SqlSetString(item.GoodsNo);                            // 商品番号  //DEL 李小路　2012/03/31 Redmine#29215
                    paraGoodsNo.Value = item.GoodsNo;                                                          // 商品番号  //ADD 李小路　2012/03/31 Redmine#29215
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // 仕入先コード
                    paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(item.SalesTimes);                       // 売上回数
                    paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(item.TotalSalesCount);            // 売上数計
                    paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(item.SalesMoney);                       // 売上金額
                    paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(item.SalesRetGoodsPrice);       // 返品額
                    paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(item.DiscountPrice);                 // 値引金額
                    paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(item.GrossProfit);                     // 粗利金額
                    // -- ADD 2010/05/13 ---------------------------------------------->>>
                    paraGoodsName.Value = SqlDataMediator.SqlSetString(item.GoodsName);                        // 商品名称
                    paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(item.GoodsNameKana);                // 商品名称カナ
                    // -- ADD 2010/05/13 ----------------------------------------------<<<
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

            return status;
        }

        // -- ADD 2010/03/30 ------------------------------->>>
        /// <summary>
        /// 商品月次集計データKey情報生成
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string MakeKeyGoodsMTtlSaSlip(GoodsMTtlSaSlipWork item)
        {
            return SqlDataMediator.SqlSetString(item.EnterpriseCode) + "-" +                          // 企業コード
                    SqlDataMediator.SqlSetString(item.AddUpSecCode) + "-" +                            // 計上拠点コード
                    SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth).ToString() + "-" +    // 計上年月
                    SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd).ToString() + "-" +                  // 実績集計区分
                    SqlDataMediator.SqlSetString(item.EmployeeCode) + "-" +                            // 従業員コード
                    SqlDataMediator.SqlSetInt32(item.CustomerCode).ToString() + "-" +                  // 得意先コード
                    SqlDataMediator.SqlSetInt32(item.BLGoodsCode).ToString() + "-" +                   // BL商品コード
                    SqlDataMediator.SqlSetInt32(item.GoodsMakerCd).ToString() + "-" +                  // 商品メーカーコード
                    SqlDataMediator.SqlSetString(item.GoodsNo) + "-" +                                 // 商品番号
                    SqlDataMediator.SqlSetInt32(item.SupplierCd).ToString();                           // 仕入先コード
        }
        // -- ADD 2010/03/30 -------------------------------<<<

        # region [比較メソッド (並び替えや検索で使用)]

        /// <summary>
        /// 売上データ用 比較メソッド
        /// </summary>
        private class SalesHeaderComparer : IComparer
        {
            public bool AdvancedMode = false;  //ADD 2009/01/20 M.Kubota  比較項目の拡張フラグ

            public int Compare(object x, object y)
            {
                SalesSlipWork xSlip = ListUtils.Find((ArrayList)x, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                SalesSlipWork ySlip = ListUtils.Find((ArrayList)y, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 受注ステータスで比較
                        cmpret = xSlip.AcptAnOdrStatus - ySlip.AcptAnOdrStatus;
                    }

                    if (cmpret == 0)
                    {
                        // 売上伝票番号で比較
                        cmpret = string.Compare(xSlip.SalesSlipNum, ySlip.SalesSlipNum);
                    }

                    //--- ADD 2009/01/20 M.Kubota --->>>
                    // 同一伝票内において、集計の起点となる
                    if (this.AdvancedMode)
                    {
                        if (cmpret == 0)
                        {
                            // 出荷日付で比較
                            cmpret = DateTime.Compare(xSlip.ShipmentDay, ySlip.ShipmentDay);
                        }

                        if (cmpret == 0)
                        {
                            // 売上日付で比較
                            cmpret = DateTime.Compare(xSlip.SalesDate, ySlip.SalesDate);
                        }

                        if (cmpret == 0)
                        {
                            // 販売従業員コードで比較
                            cmpret = string.Compare(xSlip.SalesEmployeeCd, ySlip.SalesEmployeeCd);
                        }

                        if (cmpret == 0)
                        {
                            // 受付従業員コードで比較
                            cmpret = string.Compare(xSlip.FrontEmployeeCd, ySlip.FrontEmployeeCd);
                        }

                        if (cmpret == 0)
                        {
                            // 売上入力者コードで比較
                            cmpret = string.Compare(xSlip.SalesInputCode, ySlip.SalesInputCode);
                        }

                        // ※将来的に売上伝票入力画面で得意先コードが修正可能になったら使用する
                        //if (cmpret == 0)
                        //{
                        //    // 得意先コードで比較
                        //    cmpret = string.Compare(xSlip.CustomerCode, ySlip.CustomerCode);
                        //}
                    }
                    //--- ADD 2009/01/20 M.Kubota ---<<<
                }

                return cmpret;
            }
        }

        /// <summary>
        /// 売上明細データ用 比較メソッド
        /// </summary>
        private class SalesDetailComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SalesDetailWork xDetail = x as SalesDetailWork;
                SalesDetailWork yDetail = y as SalesDetailWork;

                int cmpret = (xDetail == null ? 0 : 1) - (yDetail == null ? 0 : 1);

                if (cmpret == 0 && xDetail != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xDetail.EnterpriseCode, yDetail.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 受注ステータスで比較
                        cmpret = xDetail.AcptAnOdrStatus - yDetail.AcptAnOdrStatus;
                    }

                    if (cmpret == 0)
                    {
                        // 売上明細通番で比較
                        cmpret = (int)(xDetail.SalesSlipDtlNum - yDetail.SalesSlipDtlNum);
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// 売上月次集計データ用 比較メソッド
        /// </summary>
        private class MTtlSalesSlipComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                MTtlSalesSlipWork xSlip = x as MTtlSalesSlipWork;
                MTtlSalesSlipWork ySlip = y as MTtlSalesSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 計上拠点コードで比較
                        cmpret = string.Compare(xSlip.AddUpSecCode, ySlip.AddUpSecCode);
                    }

                    if (cmpret == 0)
                    {
                        // 計上年月で比較
                        cmpret = DateTime.Compare(xSlip.AddUpYearMonth, ySlip.AddUpYearMonth);
                    }

                    if (cmpret == 0)
                    {
                        // 実績集計区分で比較
                        cmpret = xSlip.RsltTtlDivCd - ySlip.RsltTtlDivCd;
                    }

                    if (cmpret == 0)
                    {
                        // 従業員区分で比較
                        cmpret = xSlip.EmployeeDivCd - ySlip.EmployeeDivCd;
                    }

                    if (cmpret == 0)
                    {
                        // 従業員コードで比較
                        cmpret = string.Compare(xSlip.EmployeeCode, ySlip.EmployeeCode);
                    }

                    if (cmpret == 0)
                    {
                        // 得意先コードで比較
                        cmpret = xSlip.CustomerCode - ySlip.CustomerCode;
                    }

                    if (cmpret == 0)
                    {
                        // 仕入先コードで比較
                        cmpret = xSlip.SupplierCd - ySlip.SupplierCd;
                    }

                    if (cmpret == 0)
                    {
                        // 販売区分コードで比較
                        cmpret = xSlip.SalesCode - ySlip.SalesCode;
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// 商品別売上月次集計データ用 比較メソッド
        /// </summary>
        private class GoodsMTtlSaSlipComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                GoodsMTtlSaSlipWork xSlip = x as GoodsMTtlSaSlipWork;
                GoodsMTtlSaSlipWork ySlip = y as GoodsMTtlSaSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // 企業コードで比較
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // 計上拠点コードで比較
                        cmpret = string.Compare(xSlip.AddUpSecCode, ySlip.AddUpSecCode);
                    }

                    if (cmpret == 0)
                    {
                        // 計上年月で比較
                        cmpret = DateTime.Compare(xSlip.AddUpYearMonth, ySlip.AddUpYearMonth);
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
                        // 得意先コードで比較
                        cmpret = xSlip.CustomerCode - ySlip.CustomerCode;
                    }

                    if (cmpret == 0)
                    {
                        // BL商品コードで比較
                        cmpret = xSlip.BLGoodsCode - ySlip.BLGoodsCode;
                    }

                    if (cmpret == 0)
                    {
                        // 商品メーカーコードで比較
                        cmpret = xSlip.GoodsMakerCd - ySlip.GoodsMakerCd;
                    }

                    if (cmpret == 0)
                    {
                        // 商品番号で比較
                        cmpret = string.Compare(xSlip.GoodsNo, ySlip.GoodsNo);
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
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを物理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        public int Delete(MTtlSalesUpdParaWork mTtlSalesUpdParaWork)
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
                status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);
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
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを物理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        public int Delete(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
#if !DEBUG
            // 排他ロックを行う
            status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
            try
            {
                status = this.DeleteMTtlSales(mTtlSalesUpdParaWork, connection, transaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                    status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = this.DeleteGoodsMTtlSales(mTtlSalesUpdParaWork, connection, transaction);
                }
            }
            finally
            {
#if !DEBUG
                // 排他ロックを解放する
                this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
            }

            return status;
        }

        /// <summary>
        /// 指定された条件に基づいて、売上月次集計データを物理削除します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        private int DeleteMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (mTtlSalesUpdParaWork.MTtlSalesPrcFlg != 1)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("", connection, transaction))
                    {
                        #region [DELETE文]
                        string sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MTTLSALESSLIPRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

                        // ---UPD 2009/12/24 ----------->>>>
                        //sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                        if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCode))
                        {
                            sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                            }
                            else if (string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF <= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                            else if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODEST AND ADDUPSECCODERF <= @FINDADDUPSECCODEED" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODEST", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                                command.Parameters.Add("FINDADDUPSECCODEED", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                        }
                        // ---UPD 2009/12/24 -----------<<<

                        if (mTtlSalesUpdParaWork.AddUpYearMonthSt != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF >= @FINDADDUPYEARMONTHST" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPYEARMONTHST", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;
                        }

                        if (mTtlSalesUpdParaWork.AddUpYearMonthEd != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF <= @FINDADDUPYEARMONTHED" + Environment.NewLine;
                            //command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;  // DEL 2009/12/24
                            command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthEd;    // ADD 2009/12/24
                        }

                        command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
                        //command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;    // DEL 2009/12/24

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
            }

            return status;
        }

        /// <summary>
        /// 指定された条件に基づいて、商品別売上月次集計データを物理削除します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        private int DeleteGoodsMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg != 1)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("", connection, transaction))
                    {
                        #region [DELETE文]
                        string sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSMTTLSASLIPRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

                        //sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;    // Del 2009/12/24
                        // ---ADD 2009/12/24 -------->>>
                        if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCode))
                        {
                            sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                            }
                            else if (string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF <= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                            else if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODEST AND ADDUPSECCODERF <= @FINDADDUPSECCODEED" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODEST", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                                command.Parameters.Add("FINDADDUPSECCODEED", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                            // ---ADD 2009/12/24 --------<<<
                        }

                        if (mTtlSalesUpdParaWork.AddUpYearMonthSt != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF >= @FINDADDUPYEARMONTHST" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPYEARMONTHST", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;
                        }

                        if (mTtlSalesUpdParaWork.AddUpYearMonthEd != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF <= @FINDADDUPYEARMONTHED" + Environment.NewLine;
                            //command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;     // DEL 2009/12/24
                            command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthEd;     // ADD 2009/12/24
                        }

                        command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
                        //command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;   // ---DEL 2009/12/24

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
            }

            return status;
        }

        # endregion

        # region [再集計処理]

        /// <summary>
        /// 指定された条件に基づいて、各種月次集計データを再集計します。
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを再集計します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        /// <br>Update Note: 2009/12/24 譚洪 ＰＭ．ＮＳ保守依頼④</br>
        /// <br>                ・一括リアル更新の新規を対応</br>
        public int ReCount(MTtlSalesUpdParaWork mTtlSalesUpdParaWork)
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
//            SqlCommand command = new SqlCommand("", connection, transaction);
//            SqlDataReader reader = null;
            // ---ADD 2009/12/24 --------<<<

            try
            {
                status = this.ReCountProc(mTtlSalesUpdParaWork, ref connection, ref transaction);  // ADD 2009/12/24

                #region 削除
                // ---DEL 2009/12/24 -------->>>
//                ArrayList newSalesSlips = new ArrayList();

//                # region [計上日付から売上年月日(開始～終了)を算出]

//                // 日付取得部品を利用する
//                FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));

//                DateTime tmpStart;
//                DateTime tmpEnd;
//                int AddUpYearMonthSt = 0;
//                int AddUpYearMonthEd = 0;

//                // 計上年月(開始)を元に月度開始日を取得
//                dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthSt * 100 + 1), out tmpStart, out tmpEnd);
//                AddUpYearMonthSt = tmpStart.Year * 100 + tmpStart.Month;

//                // 計上年月(終了)を元に月度終了日を取得
//                dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthEd * 100 + 1), out tmpStart, out tmpEnd);
//                AddUpYearMonthEd = tmpEnd.Year * 100 + tmpEnd.Month;

//                # endregion

//                # region [売上履歴データの取得]

//                // 売上履歴データを取得
//                string sqlText = string.Empty;
//                sqlText += "SELECT" + Environment.NewLine;
//                sqlText += "  HIST.*" + Environment.NewLine;  // 項目が確定するまで * にしておく
//                sqlText += "FROM" + Environment.NewLine;
//                sqlText += "  SALESHISTORYRF AS HIST" + Environment.NewLine;
//                sqlText += "WHERE" + Environment.NewLine;
//                sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
//                sqlText += "  AND HIST.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
//                sqlText += "  AND HIST.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD" + Environment.NewLine;
//                sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
//                command.CommandText = sqlText;
                
//                command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
//                command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
//                command.Parameters.Add("FINDSALESDATEST", SqlDbType.Int).Value = AddUpYearMonthSt;
//                command.Parameters.Add("FINDSALESDATEED", SqlDbType.Int).Value = AddUpYearMonthEd;

//                reader = command.ExecuteReader();

//                ArrayList headerList = new ArrayList();

//                while (reader.Read())
//                {
//                    headerList.Add(this.CopyToSalesSlipWorkFromReader(reader));
//                }

//                command.Parameters.Clear();

//                # endregion

//                # region [売上履歴明細データの取得]

//                // 売上履歴明細データを取得
//                sqlText = string.Empty;
//                sqlText += "SELECT" + Environment.NewLine;
//                sqlText += "  DTIL.*" + Environment.NewLine;  // 項目が確定するまで * にしておく
//                sqlText += "FROM" + Environment.NewLine;
//                sqlText += "  SALESHISTDTLRF AS DTIL" + Environment.NewLine;
//                sqlText += "WHERE" + Environment.NewLine;
//                sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
//                sqlText += "  AND DTIL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
//                sqlText += "  AND DTIL.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

//                command.CommandText = sqlText;

//                SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
//                SqlParameter findSalesSlipNum = command.Parameters.Add("FINDSALESSLIPNUM", SqlDbType.NVarChar);
                
//                foreach (SalesSlipWork header in headerList)
//                {
//                    findEnterpriseCode.Value = header.EnterpriseCode;
//                    findSalesSlipNum.Value = header.SalesSlipNum;

//                    if (!reader.IsClosed)
//                    {
//                        reader.Close();
//                    }

//                    reader = command.ExecuteReader();

//                    ArrayList detail = new ArrayList();

//                    while (reader.Read())
//                    {
//                        detail.Add(this.CopyToSalesDetailWorkFromReader(reader));
//                    }

//                    ArrayList salesSlip = new ArrayList();
//                    salesSlip.Add(header);
//                    salesSlip.Add(detail);
                    
//                    newSalesSlips.Add(salesSlip);
//                }
//                # endregion

//                if (ListUtils.IsEmpty(newSalesSlips))
//                {
//                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
//                }
//                else
//                {
//#if !DEBUG
//                    // 排他ロックを行う
//                    status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
//#endif
//                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//                    {
//                        return status;
//                    }

//                    try
//                    {
//                        // 再集計前に対象範囲を一度全て削除する
//                        status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);

//                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//                        {
//                            return status;
//                        }

//                        // 伝票登録区分を 2:再集計 に設定
//                        mTtlSalesUpdParaWork.SlipRegDiv = 2;

//                        // 再集計を行う
//                        status = this.Write(mTtlSalesUpdParaWork, newSalesSlips, null, connection, transaction);
//                    }
//                    finally
//                    {
//#if !DEBUG
//                        // 排他ロックを解放する
//                        this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
//#endif
//                    }
//                }
                // ---ADD 2009/12/24 --------<<<
                #endregion 
            }
            finally
            {
                #region 削除
                // ---ADD 2009/12/24 -------->>>
                //if (reader != null)
                //{
                //    if (!reader.IsClosed)
                //    {
                //        reader.Close();
                //    }
                //    reader.Dispose();
                //}

                //if (command != null)
                //{
                //    command.Cancel();
                //    command.Dispose();
                //}
                // ---ADD 2009/12/24 --------<<<
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
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWorkオブジェクト</param>
        /// <param name="connection">ＤＢ接続オブジェクト</param>
        /// <param name="transaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に基づいて、各種月次集計データを再集計します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/24</br>
        public int ReCountProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction)
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
            Int32 monthRange = ((mTtlSalesUpdParaWork.AddUpYearMonthEd / 100) - (mTtlSalesUpdParaWork.AddUpYearMonthSt / 100)) * 12 + (mTtlSalesUpdParaWork.AddUpYearMonthEd % 100) - (mTtlSalesUpdParaWork.AddUpYearMonthSt % 100) + 1;
            DateTime dt = new DateTime(mTtlSalesUpdParaWork.AddUpYearMonthSt / 100, mTtlSalesUpdParaWork.AddUpYearMonthSt % 100, 1);
            // -- ADD 2010/02/24 ----------------------------------<<<

            try
            {
                // -- ADD 2010/02/24 ------------------------------>>>
                for (int i = 0; i < monthRange; i++)
                {
                    mTtlSalesUpdParaWork.AddUpYearMonthSt = Int32.Parse(dt.ToString("yyyyMM"));
                    mTtlSalesUpdParaWork.AddUpYearMonthEd = Int32.Parse(dt.ToString("yyyyMM"));

                    command.Parameters.Clear();
                // -- ADD 2010/02/24 ------------------------------<<<

                    ArrayList newSalesSlips = new ArrayList();

                    # region [計上日付から売上年月日(開始～終了)を算出]

                    // 日付取得部品を利用する
                    FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));

                    DateTime tmpStart;
                    DateTime tmpEnd;
                    int AddUpYearMonthSt = 0;
                    int AddUpYearMonthEd = 0;

                    // 計上年月(開始)を元に月度開始日を取得
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthSt * 100 + 1), out tmpStart, out tmpEnd);
                    //AddUpYearMonthSt = tmpStart.Year * 100 + tmpStart.Month;                              // DEL 2009/12/24
                    AddUpYearMonthSt = tmpStart.Year * 10000 + tmpStart.Month * 100 + tmpStart.Day;         // ADD 2009/12/24

                    // 計上年月(終了)を元に月度終了日を取得
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthEd * 100 + 1), out tmpStart, out tmpEnd);
                    //AddUpYearMonthEd = tmpEnd.Year * 100 + tmpEnd.Month;                                  // DEL 2009/12/24
                    AddUpYearMonthEd = tmpEnd.Year * 10000 + tmpEnd.Month * 100 + tmpEnd.Day;               // ADD 2009/12/24

                    # endregion

                    # region [売上履歴データの取得]

                    // 売上履歴データを取得
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.*" + Environment.NewLine;  // 項目が確定するまで * にしておく
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTORYRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = 30" + Environment.NewLine;

                    // ---ADD 2009/12/24 -------->>>
                    if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCode))
                    {
                        sqlText += "  AND HIST.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD" + Environment.NewLine;
                        command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                        {
                            sqlText += "  AND HIST.RESULTSADDUPSECCDRF >= @FINDRESULTSADDUPSECCD" + Environment.NewLine;
                            command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                        }
                        else if (string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                        {
                            sqlText += "  AND HIST.RESULTSADDUPSECCDRF <= @FINDRESULTSADDUPSECCD" + Environment.NewLine;
                            command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                        }
                        else if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                        {
                            sqlText += "  AND HIST.RESULTSADDUPSECCDRF >= @FINDRESULTSADDUPSECCDST AND HIST.RESULTSADDUPSECCDRF <= @FINDRESULTSADDUPSECCDED" + Environment.NewLine;
                            command.Parameters.Add("FINDRESULTSADDUPSECCDST", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                            command.Parameters.Add("FINDRESULTSADDUPSECCDED", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                        }
                    }

                    sqlText += "  AND HIST.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                    // ---ADD 2009/12/24 --------<<<

                    sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
                    command.CommandText = sqlText;
                    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
                    //command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;  // DEL 2009/12/24
                    command.Parameters.Add("FINDSALESDATEST", SqlDbType.Int).Value = AddUpYearMonthSt;
                    command.Parameters.Add("FINDSALESDATEED", SqlDbType.Int).Value = AddUpYearMonthEd;

                    reader = command.ExecuteReader();

                    ArrayList headerList = new ArrayList();

                    while (reader.Read())
                    {
                        headerList.Add(this.CopyToSalesSlipWorkFromReader(reader));
                    }

                    command.Parameters.Clear();

                    # endregion

                    # region [売上履歴明細データの取得]

                    // 売上履歴明細データを取得
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;  // 項目が確定するまで * にしておく
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
                    sqlText += "  AND DTIL.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlText += "  AND DTIL.LOGICALDELETECODERF = 0" + Environment.NewLine;             // ADD 2009/12/24

                    command.CommandText = sqlText;

                    SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
                    SqlParameter findSalesSlipNum = command.Parameters.Add("FINDSALESSLIPNUM", SqlDbType.NVarChar);

                    foreach (SalesSlipWork header in headerList)
                    {
                        findEnterpriseCode.Value = header.EnterpriseCode;
                        findSalesSlipNum.Value = header.SalesSlipNum;

                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }

                        reader = command.ExecuteReader();

                        ArrayList detail = new ArrayList();

                        while (reader.Read())
                        {
                            detail.Add(this.CopyToSalesDetailWorkFromReader(reader));
                        }

                        ArrayList salesSlip = new ArrayList();
                        salesSlip.Add(header);
                        salesSlip.Add(detail);

                        newSalesSlips.Add(salesSlip);
                    }

                    // ---ADD 2009/12/24 --->>>
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    // ---ADD 2009/12/24 ---<<<
                    # endregion

                    if (ListUtils.IsEmpty(newSalesSlips))
                    {
                        // 2010/07/12 Add >>>
                        status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        // 2010/07/12 Add <<<
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2009/12/24
#if !DEBUG
                        // 排他ロックを行う
                        status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        try
                        {

                            // 再集計前に対象範囲を一度全て削除する
                            status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }

                            // 伝票登録区分を 2:再集計 に設定
                            mTtlSalesUpdParaWork.SlipRegDiv = 2;

                            // 再集計を行う
                            status = this.Write(mTtlSalesUpdParaWork, newSalesSlips, null, connection, transaction);
                        }
                        finally
                        {
#if !DEBUG
                            // 排他ロックを解放する
                            this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
                        }
                    } // ADD 2010/02/24
                    dt = dt.AddMonths(1); // ADD 2010/02/24
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2010/02/24

                }
            }
            // -- UPD 2010/02/24 ------------------------>>>
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
            // -- UPD 2010/02/24 ------------------------<<<
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

        # endregion
        // ---ADD 2009/12/24--------------------------------------------------------<<<<<<<<<<<<<<<<<

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → salesHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>salesHistoryWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.05.19</br>
        /// </remarks>
        private SalesSlipWork CopyToSalesSlipWorkFromReader(SqlDataReader myReader)
        {
            SalesSlipWork wkSalesSlipWork = new SalesSlipWork();

            this.CopyToSalesSlipWorkFromReader(myReader, ref wkSalesSlipWork);

            return wkSalesSlipWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkSalesSlipWork"></param>
        private void CopyToSalesSlipWorkFromReader(SqlDataReader myReader, ref SalesSlipWork wkSalesSlipWork)
        {
            if (wkSalesSlipWork != null)
            {
                #region クラスへ格納
                wkSalesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkSalesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkSalesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkSalesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkSalesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkSalesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkSalesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkSalesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkSalesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                wkSalesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                wkSalesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkSalesSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkSalesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                wkSalesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                wkSalesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                wkSalesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                wkSalesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                wkSalesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                wkSalesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
                wkSalesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                wkSalesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                wkSalesSlipWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPUPDATECDRF"));
                wkSalesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                wkSalesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                wkSalesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                wkSalesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                wkSalesSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                //wkSalesSlipWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));      // DEL 2009/12/24
                //wkSalesSlipWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));       // DEL 2009/12/24
                wkSalesSlipWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                wkSalesSlipWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                wkSalesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                wkSalesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                wkSalesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                wkSalesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                wkSalesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                wkSalesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                wkSalesSlipWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                wkSalesSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                wkSalesSlipWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                wkSalesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));
                wkSalesSlipWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));
                wkSalesSlipWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
                wkSalesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));
                wkSalesSlipWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));
                wkSalesSlipWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));
                wkSalesSlipWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));
                wkSalesSlipWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
                wkSalesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
                wkSalesSlipWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
                wkSalesSlipWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
                wkSalesSlipWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
                wkSalesSlipWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
                wkSalesSlipWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
                wkSalesSlipWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
                wkSalesSlipWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
                wkSalesSlipWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
                wkSalesSlipWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));
                wkSalesSlipWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));
                wkSalesSlipWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));
                wkSalesSlipWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));
                wkSalesSlipWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
                wkSalesSlipWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
                wkSalesSlipWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
                wkSalesSlipWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));
                wkSalesSlipWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));
                wkSalesSlipWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                wkSalesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                wkSalesSlipWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                wkSalesSlipWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                wkSalesSlipWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
                wkSalesSlipWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                wkSalesSlipWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
                wkSalesSlipWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
                wkSalesSlipWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                wkSalesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                wkSalesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                wkSalesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                wkSalesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                wkSalesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                wkSalesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                wkSalesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                wkSalesSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                wkSalesSlipWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                wkSalesSlipWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
                wkSalesSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
                wkSalesSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                wkSalesSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                wkSalesSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                wkSalesSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
                wkSalesSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                wkSalesSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                wkSalesSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                wkSalesSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
                wkSalesSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
                wkSalesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                wkSalesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                wkSalesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                wkSalesSlipWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                wkSalesSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                wkSalesSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                //wkSalesSlipWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REGIPROCDATERF"));    // DEL 2009/12/24
                //wkSalesSlipWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));               // DEL 2009/12/24
                //wkSalesSlipWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));                   // DEL 2009/12/24
                wkSalesSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                wkSalesSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                wkSalesSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                wkSalesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                wkSalesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                wkSalesSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                wkSalesSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                wkSalesSlipWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
                wkSalesSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                wkSalesSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                //wkSalesSlipWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));                        // DEL 2009/12/24
                wkSalesSlipWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                wkSalesSlipWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                wkSalesSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                wkSalesSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                //wkSalesSlipWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEFLAGRF"));                   // DEL 2009/12/24
                wkSalesSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                wkSalesSlipWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
                wkSalesSlipWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
                wkSalesSlipWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
                wkSalesSlipWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
                wkSalesSlipWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
                wkSalesSlipWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                // ---DEL 2009/12/24 --->>>>
                //wkSalesSlipWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));
                //wkSalesSlipWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));
                //wkSalesSlipWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));
                //wkSalesSlipWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));
                //wkSalesSlipWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));
                //wkSalesSlipWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
                //wkSalesSlipWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));
                //wkSalesSlipWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));
                //wkSalesSlipWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));
                //wkSalesSlipWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));
                //wkSalesSlipWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
                //wkSalesSlipWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
                //wkSalesSlipWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
                //wkSalesSlipWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
                //wkSalesSlipWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
                //wkSalesSlipWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYDATERF"));
                //wkSalesSlipWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
                //wkSalesSlipWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONPRINGDIVCDRF"));
                //wkSalesSlipWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEUSECODERF"));
                // ---DEL 2009/12/24 -----<<<<
                #endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → SalesHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesHistDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private SalesDetailWork CopyToSalesDetailWorkFromReader(SqlDataReader myReader)
        {
            SalesDetailWork wkSalesDetailWork = new SalesDetailWork();

            this.CopyToSalesDetailWorkFromReader(myReader, ref wkSalesDetailWork);

            return wkSalesDetailWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkSalesDetailWork"></param>
        private void CopyToSalesDetailWorkFromReader(SqlDataReader myReader, ref SalesDetailWork wkSalesDetailWork)
        {
            if (wkSalesDetailWork != null)
            {
                #region クラスへ格納
                wkSalesDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkSalesDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkSalesDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkSalesDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkSalesDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkSalesDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkSalesDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkSalesDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkSalesDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                wkSalesDetailWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                wkSalesDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                wkSalesDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                wkSalesDetailWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
                wkSalesDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkSalesDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkSalesDetailWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                wkSalesDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                wkSalesDetailWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                wkSalesDetailWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                wkSalesDetailWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
                wkSalesDetailWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
                wkSalesDetailWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
                wkSalesDetailWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                //wkSalesDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // DEL 2009/12/24
                wkSalesDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                //wkSalesDetailWork.GoodsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSEARCHDIVCDRF"));                       // DEL 2009/12/24
                wkSalesDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                wkSalesDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                wkSalesDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                //wkSalesDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));                  // DEL 2009/12/24
                wkSalesDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                wkSalesDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                wkSalesDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                wkSalesDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                wkSalesDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                wkSalesDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                wkSalesDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                wkSalesDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                wkSalesDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                wkSalesDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                wkSalesDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                wkSalesDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                wkSalesDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                wkSalesDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                wkSalesDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                wkSalesDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkSalesDetailWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                wkSalesDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                wkSalesDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                wkSalesDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                wkSalesDetailWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
                wkSalesDetailWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));
                wkSalesDetailWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));
                wkSalesDetailWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));
                wkSalesDetailWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));
                wkSalesDetailWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
                wkSalesDetailWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));
                wkSalesDetailWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));
                wkSalesDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                wkSalesDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                wkSalesDetailWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
                wkSalesDetailWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                wkSalesDetailWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));
                wkSalesDetailWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));
                wkSalesDetailWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));
                wkSalesDetailWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));
                wkSalesDetailWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
                wkSalesDetailWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));
                wkSalesDetailWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));
                wkSalesDetailWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                wkSalesDetailWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                wkSalesDetailWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));
                wkSalesDetailWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
                wkSalesDetailWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));
                wkSalesDetailWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));
                wkSalesDetailWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));
                wkSalesDetailWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));
                wkSalesDetailWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
                wkSalesDetailWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));
                wkSalesDetailWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));
                wkSalesDetailWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                wkSalesDetailWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));
                wkSalesDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                wkSalesDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                wkSalesDetailWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                wkSalesDetailWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
                wkSalesDetailWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                wkSalesDetailWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                wkSalesDetailWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));
                wkSalesDetailWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                //wkSalesDetailWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));                    // DEL 2009/12/24
                //wkSalesDetailWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));                // DEL 2009/12/24
                //wkSalesDetailWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));                // DEL 2009/12/24
                //wkSalesDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));      // DEL 2009/12/24
                wkSalesDetailWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                wkSalesDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                wkSalesDetailWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                wkSalesDetailWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
                wkSalesDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                wkSalesDetailWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
                wkSalesDetailWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                wkSalesDetailWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
                wkSalesDetailWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                wkSalesDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                wkSalesDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                wkSalesDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                wkSalesDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
                wkSalesDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                wkSalesDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                wkSalesDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                wkSalesDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                wkSalesDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                wkSalesDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                wkSalesDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                wkSalesDetailWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                wkSalesDetailWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                wkSalesDetailWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
                wkSalesDetailWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
                wkSalesDetailWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
                wkSalesDetailWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
                wkSalesDetailWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
                wkSalesDetailWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
                wkSalesDetailWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
                wkSalesDetailWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
                wkSalesDetailWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
                wkSalesDetailWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
                wkSalesDetailWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
                #endregion
            }
        }
        #endregion        
    }
}
