//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業掛率マスタ変換処理
// プログラム概要   : ＣＳＶファイルより、画面抽出条件を満たしたデータをテキストファイルへ出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/01/26   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/02/26  修正内容 : Redmine#44209 メッセージの文言対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources; 
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業掛率マスタ変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率マスタ変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiRateDB : RemoteDB
    {
        // 掛率マスタのリモート
        private RateDB _iRateDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        # region メッセージ
        //----- DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応----->>>>>
        //// 排他チェックメッセージ
        //private const string EXISTMSG = "変換先品番が既に登録されました";
        //// 論理削除チェックメッセージ
        //private const string DELETEMSG = "論理削除データ";
        //// 更新失敗の場合
        //private const string UPDATEFAIL = "排他エラー、変換元品番の削除に失敗しました";
        //// 変換元異常エラーの場合
        //private const string OLDEXCEPTIONMSG = "削除エラー、変換元品番の削除に失敗しました";
        //// 変換先異常エラーの場合
        //private const string NEWEXCEPTIONMSG = "登録エラー、変換先品番の登録に失敗しました";
        //----- DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応-----<<<<<
        # endregion

        #region MeijiRateDB
        /// <summary>
        /// 掛率マスタ変換処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiRateDB()
        {
            // 掛率マスタ
            if (this._iRateDB == null)
            {
                this._iRateDB = new RateDB();
            }
            // 品番変換処理共通
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region 掛率マスタの取込処理
        /// <summary>
        /// 指定された企業コードの掛率の全て戻る処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの掛率LISTを全て戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int WriteIn(out object rateSuccessResultWork, out object rateErrorResultWork, out int updateCount, int updateMode, string enterPriseCode)
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 掛率マスタに成功な登録するデータ
            rateSuccessResultWork = null;
            ArrayList rateSuccessResultWorkList = new ArrayList();

            // 掛率マスタに失敗な登録するデータ
            rateErrorResultWork = null;
            ArrayList rateErrorResultWorkList = new ArrayList();

            // 登録件数
            updateCount = 0;

            try
            {
                // コネクション生成
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // 掛率マスタ変換処理
                status = RateWriteInProc(out rateSuccessResultWorkList, out rateErrorResultWorkList, out updateCount, updateMode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                // 戻られるリスト
                rateSuccessResultWork = rateSuccessResultWorkList;
                rateErrorResultWork = rateErrorResultWorkList;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiRateDB.WriteIn");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの掛率マスタの取込処理
        /// </summary>
        /// <param name="rateSuccessResultWork">取込成功リスト</param>
        /// <param name="rateErrorResultWork">取込失敗リスト</param>
        /// <param name="updateCount">更新件数</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/17</br>
        /// </remarks>
        private int RateWriteInProc(out ArrayList rateSuccessResultWork, out ArrayList rateErrorResultWork, out int updateCount, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 戻される結果リスト
            rateSuccessResultWork = new ArrayList();
            rateErrorResultWork = new ArrayList();
            // リスト
            ArrayList changeWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            // 品番変換エラーデータ、更新追加Dictionary
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            // 検索コネクション
            SqlConnection rateConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            // 登録件数
            updateCount = 0;
            // 新旧品番Dictionary
            Dictionary<string, MeijiRateWork> goodsNoAllDic = new Dictionary<string, MeijiRateWork>();
            string goodsNoKey = "";

            try
            {
                // 掛率マスタで検索する
                status = this.SearchSubSectionProcProc(out changeWorkList, out goodsNoAllDic, updateMode, enterPriseCode, ref rateConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && changeWorkList.Count > 0)
                {
                    // 変換されるデータのカウント
                    updateCount = changeWorkList.Count;
                    // 品番変換エラーデータを削除する
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.RATEMST, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        #region 掛率マスタに新旧品番を変換する
                        int logicalDeleteCode = 0;
                        foreach (RateWork rateChgWork in changeWorkList)
                        {
                            // トランザクションの保存
                            sqlTransaction.Save("RateSavePoint");
                            // メーカー＋旧品番のキーの作成
                            goodsNoKey = rateChgWork.GoodsMakerCd.ToString() + "-" + rateChgWork.GoodsNo.Trim();
                            // 掛率マスタに旧品番の削除
                            deleteWorkList.Add(rateChgWork);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                status = this._iRateDB.DeleteSubSectionProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "DeleteSubSectionProc");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                            deleteWorkList.Clear(); // リストのクリア
                            // ログデータの作成
                            MeijiRateWork meijiRateWork = new MeijiRateWork();
                            meijiRateWork.CustomerCode = rateChgWork.CustomerCode;
                            meijiRateWork.CustRateGrpCode = rateChgWork.CustRateGrpCode;
                            meijiRateWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                            meijiRateWork.GoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                            meijiRateWork.LotCount = rateChgWork.LotCount;
                            meijiRateWork.NewGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                            meijiRateWork.SectionCode = rateChgWork.SectionCode;
                            meijiRateWork.SupplierCd = rateChgWork.SupplierCd;
                            meijiRateWork.UnitPriceKind = rateChgWork.UnitPriceKind;
                            meijiRateWork.UnitRateSetDivCd = rateChgWork.UnitRateSetDivCd;
                            // 掛率マスタの旧品番の削除に失敗した場合
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                //meijiRateWork.OutNote = UPDATEFAIL;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                meijiRateWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "掛率マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                rateErrorResultWork.Add(meijiRateWork);
                            }
                            // 掛率マスタの旧品番の削除に成功した場合
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                #region 新品番の追加
                                rateChgWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                rateChgWork.UpdateDateTime = DateTime.MinValue;
                                logicalDeleteCode = rateChgWork.LogicalDeleteCode;
                                insertWorkList.Add(rateChgWork);
                                // 掛率マスタで追加する
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                try
                                {
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                    status = this._iRateDB.WriteSubSectionProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                }
                                catch (Exception ex)
                                {
                                    base.WriteErrorLog(ex, "WriteSubSectionProc");
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                // 掛率マスタに旧品番対応の新品番が既に存在する場合、排他メッセージのセット
                                if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    insertWorkList.Clear(); // リストのクリア
                                    //meijiRateWork.OutNote = EXISTMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    meijiRateWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "掛率マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    rateErrorResultWork.Add(meijiRateWork);
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 論理削除の場合
                                    if (logicalDeleteCode == 1)
                                    {
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                        try
                                        {
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                            status = this._iRateDB.LogicalDeleteSubSectionProc(ref insertWorkList, 0, ref sqlConnection, ref sqlTransaction);
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                        }
                                        catch (Exception ex)
                                        {
                                            base.WriteErrorLog(ex, "LogicalDeleteSubSectionProc");
                                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                        }
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                        insertWorkList.Clear(); // リストのクリア
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            //meijiRateWork.OutNote = DELETEMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            meijiRateWork.OutNote = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            rateSuccessResultWork.Add(meijiRateWork);
                                        }
                                        else
                                        {
                                            //meijiRateWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            meijiRateWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                                goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                            }
                                            rateErrorResultWork.Add(meijiRateWork);
                                        }
                                    }
                                    else
                                    {
                                        insertWorkList.Clear(); // リストのクリア
                                        rateSuccessResultWork.Add(meijiRateWork);
                                    }
                                }
                                else
                                {
                                    insertWorkList.Clear(); // リストのクリア
                                    //meijiRateWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    meijiRateWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    rateErrorResultWork.Add(meijiRateWork);
                                }
                                #endregion
                            }
                            else
                            {
                                //meijiRateWork.OutNote = OLDEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                meijiRateWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                rateErrorResultWork.Add(meijiRateWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("RateSavePoint");
                            }
                        }
                        // リストのクリア
                        changeWorkList.Clear();
                        #endregion

                        #region 品番変換エラーデータの更新
                        status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            rateSuccessResultWork.Clear();
                            rateErrorResultWork.Clear();
                            return status;
                        }
                        #endregion
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    return status;
                }

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiRateDB.RateWriteInProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (rateConnection != null)
                {
                    rateConnection.Close();
                    rateConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="goodsNoAllDic">新旧品番Dictionary</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchSubSectionProcProc(out ArrayList rateWorkList, out Dictionary<string, MeijiRateWork> goodsNoAllDic, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string goodsNoKey = "";
            rateWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiRateWork>();
            try
            {
                string command = string.Empty;
                command = " SELECT A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF, " + Environment.NewLine;
                command += " A.UPDASSEMBLYID1RF, A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.UNITRATESETDIVCDRF, " + Environment.NewLine;
                command += " A.UNITPRICEKINDRF, A.RATESETTINGDIVIDERF, A.RATEMNGGOODSCDRF, A.RATEMNGGOODSNMRF, A.RATEMNGCUSTCDRF, " + Environment.NewLine;
                command += " A.RATEMNGCUSTNMRF, A.GOODSMAKERCDRF, A.GOODSNORF, A.GOODSRATERANKRF, A.GOODSRATEGRPCODERF, A.BLGROUPCODERF, " + Environment.NewLine;
                command += " A.BLGOODSCODERF, A.CUSTOMERCODERF, A.CUSTRATEGRPCODERF, A.SUPPLIERCDRF, A.LOTCOUNTRF, A.PRICEFLRF, " + Environment.NewLine;
                command += " A.RATEVALRF, A.UPRATERF, A.GRSPROFITSECURERATERF, A.UNPRCFRACPROCUNITRF, A.UNPRCFRACPROCDIVRF, B.CHGDESTGOODSNORF " + Environment.NewLine;
                command += " FROM RATERF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    command += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    command += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    command += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    command += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    command += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    command += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    command += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    command += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    command += " AND B.MASTERDIVCDRF = 3 " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(command, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterPriseCode);
                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // 掛率ワークと新旧品番ワークの作成
                    RateWork wkRateWork = new RateWork();
                    MeijiRateWork meijiRateCndtnWork = new MeijiRateWork();
                    // クラス格納処理
                    CopyToRateWorkFromReader(ref myReader, out wkRateWork, out meijiRateCndtnWork);
                    rateWorkList.Add(wkRateWork);
                    goodsNoKey = meijiRateCndtnWork.GoodsMakerCd.ToString() + "-" + meijiRateCndtnWork.GoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiRateCndtnWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note        : Where句を作成して戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterPriseCode)
        {
            string retstring = "WHERE ";

            //企業コード
            retstring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //論理削除区分
            retstring += "AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            retstring += " ORDER BY A.ENTERPRISECODERF, A.GOODSMAKERCDRF, A.GOODSNORF, A.SECTIONCODERF, A.UNITRATESETDIVCDRF, A.CUSTOMERCODERF, A.CUSTRATEGRPCODERF, A.SUPPLIERCDRF, A.LOTCOUNTRF ";
            return retstring;
        }

        /// <summary>
        /// クラス格納処理 Reader → RateWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkRateWork">RateWork</param>
        /// <param name="meijiRateCndtnWork">MeijiRateWork</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private void CopyToRateWorkFromReader(ref SqlDataReader myReader, out RateWork wkRateWork, out MeijiRateWork meijiRateCndtnWork)
        {
            // 掛率ワークと新旧品番ワークの作成
            wkRateWork = new RateWork();
            meijiRateCndtnWork = new MeijiRateWork();
            #region クラスへ格納
            wkRateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkRateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkRateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkRateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkRateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkRateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkRateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkRateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkRateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            wkRateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkRateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkRateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkRateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkRateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkRateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            wkRateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkRateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkRateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkRateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkRateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkRateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkRateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            wkRateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkRateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            wkRateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            wkRateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            wkRateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            wkRateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            wkRateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            wkRateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));

            meijiRateCndtnWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiRateCndtnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiRateCndtnWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
            #endregion
        }
        #endregion
    }
}
