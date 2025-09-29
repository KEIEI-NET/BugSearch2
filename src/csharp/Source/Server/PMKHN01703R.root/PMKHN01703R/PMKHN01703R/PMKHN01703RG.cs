//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業代替マスタ変換処理
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
// 作 成 日  2015/04/07  修正内容 : Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/29  修正内容 : リストのNULL、とcountは判断する対応
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
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業代替マスタ変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 代替マスタ変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiPartsSubstDB : RemoteDB
    {
        // 代替マスタのリモート
        private PartsSubstUDB _iPartsSubstDB;
        private GoodsNoChgCommonDB _goodsNoChgCommonDB;

        #region MeijiPartsSubstDB
        /// <summary>
        /// 代替マスタ変換処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiPartsSubstDB()
        {
            // 代替マスタ
            if (this._iPartsSubstDB == null)
            {
                this._iPartsSubstDB = new PartsSubstUDB();
            }

            if (this._goodsNoChgCommonDB == null)
            {
                this._goodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region 代替マスタの取込処理
        /// <summary>
        /// 指定された企業コードの代替の全て戻る処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの代替LISTを全て戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int WriteIn(out object partsSubstSuccessResultWork, out object partserrorResultWork, out int updateCount, int mode, string enterPriseCode)
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 代替マスタログ
            partsSubstSuccessResultWork = null;
            partserrorResultWork = null;
            ArrayList partsSubstSuccessResultWorkList = new ArrayList();
            ArrayList partserrorResultWorkList = new ArrayList();

            // 登録件数
            updateCount = 0;

            try
            {
                // コネクション生成
                sqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = _goodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // 代替マスタ変換処理
                status = PartsSubstWriteInProc(out partsSubstSuccessResultWorkList, out partserrorResultWorkList, out updateCount, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                // 戻られるリスト
                partsSubstSuccessResultWork = partsSubstSuccessResultWorkList;
                partserrorResultWork = partserrorResultWorkList;

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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 指定された企業コードの代替マスタの取込処理
        /// </summary>
        /// <param name="partsSubstSuccessResultWork">取込成功リスト</param>
        /// <param name="PartserrorResultWorkList">検索条件リスト</param>
        /// <param name="updateCount">登録件数</param>
        /// <param name="mode"></param>
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
        /// <br>Note        : リストのNULL、とcountは判断する対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/29</br>
        /// </remarks>
        private int PartsSubstWriteInProc(out ArrayList partsSubstSuccessResultWork, out ArrayList PartserrorResultWorkList, out int updateCount, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList cndtnWorkList = new ArrayList();
            // 戻される結果リスト
            partsSubstSuccessResultWork = new ArrayList();
            PartserrorResultWorkList = new ArrayList();
            // 完全削除リスト
            ArrayList phyDeleteWorkList = new ArrayList();
            // 追加リスト
            ArrayList insertWorkList = new ArrayList();
            // 検索した戻されろリスト
            ArrayList searchBackWorkList = new ArrayList();
            
            ArrayList haveWorkList = new ArrayList();
            ArrayList logicalDeleteList = new ArrayList();
            ArrayList errorDeleteList = new ArrayList();

            Dictionary<string, string> deleteErrorDic = new Dictionary<string, string>();
            Dictionary<string, string> errorDic = new Dictionary<string, string>();
            // 検索コネクション
            SqlConnection partsSubstConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);
            // 登録件数
            updateCount = 0;
            string srcGoodsNoKey = "";
            string destGoodsNoKey = "";
            int logicalDeleteCode = 0;

            try
            {
                // 検索条件キー
                string cndtnKey = string.Empty;

                status = this.Search(out searchBackWorkList, out cndtnWorkList, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && searchBackWorkList.Count > 0)
                {
                    updateCount = searchBackWorkList.Count;
                    status = _goodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.PARTSMST, ref  sqlConnection, ref  sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        #region 代替マスタの新旧品番の対応する値
                        foreach (MeijiPartsSubstWork meijiPartsSubstWork in cndtnWorkList)
                        {
                            string str = meijiPartsSubstWork.ChgSrcMakerCd + ":" + meijiPartsSubstWork.ChgSrcGoodsNo;
                            deleteErrorDic.Add(str, meijiPartsSubstWork.ChgDestGoodsNo);
                        }
                        #endregion

                        foreach (PartsSubstUWork partsSubstUWork in searchBackWorkList)
                        {
                            sqlTransaction.Save("PartsSavePoint");
                            logicalDeleteCode = partsSubstUWork.LogicalDeleteCode;
                            srcGoodsNoKey = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                            destGoodsNoKey = partsSubstUWork.ChgDestMakerCd + ":" + partsSubstUWork.ChgDestGoodsNo;
                            ArrayList coyList = new ArrayList();
                            PartsSubstUWork apartsSubstUWork = CloneJoinWork(partsSubstUWork);
                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork1 = new GoodsNoChangeErrorDataWork();

                            MeijiPartsSubstWork ameijiPartsSubstWork = new MeijiPartsSubstWork();
                            ameijiPartsSubstWork.ChgSrcMakerCd = partsSubstUWork.ChgSrcMakerCd;
                            ameijiPartsSubstWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                            ameijiPartsSubstWork.ChgDestMakerCd = partsSubstUWork.ChgDestMakerCd;
                            ameijiPartsSubstWork.ChgDestGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                            if (deleteErrorDic.ContainsKey(srcGoodsNoKey))
                            {
                                ameijiPartsSubstWork.ChgSrcChgGoodsNo = deleteErrorDic[srcGoodsNoKey];
                            }
                            else
                            {
                                ameijiPartsSubstWork.ChgSrcChgGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                            }
                            if (deleteErrorDic.ContainsKey(destGoodsNoKey))
                            {
                                ameijiPartsSubstWork.ChgDestChgGoodsNo = deleteErrorDic[destGoodsNoKey];
                            }
                            else
                            {
                                ameijiPartsSubstWork.ChgDestChgGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                            }

                            // 旧品番の削除
                            coyList.Add(apartsSubstUWork);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                status = this._iPartsSubstDB.Delete(coyList, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "Delete");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                            coyList.Clear();

                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                string stra = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                                string strb = partsSubstUWork.ChgDestMakerCd + ":" + partsSubstUWork.ChgDestGoodsNo;
                                if (deleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgSrcMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (deleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //ameijiPartsSubstWork.OutNote = "排他エラー、変換元品番の削除に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                ameijiPartsSubstWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "代替マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                #region 新品番の追加
                                foreach (MeijiPartsSubstWork newmeijiPartsSubstWork in cndtnWorkList)
                                {
                                    if (partsSubstUWork.ChgSrcMakerCd == newmeijiPartsSubstWork.ChgSrcMakerCd && partsSubstUWork.ChgSrcGoodsNo.Equals(newmeijiPartsSubstWork.ChgSrcGoodsNo))
                                    {
                                        partsSubstUWork.ChgSrcGoodsNo = newmeijiPartsSubstWork.ChgDestGoodsNo;
                                        partsSubstUWork.ChgSrcGoodsNoNoneHp = newmeijiPartsSubstWork.ChgDestGoodsNo.Replace("-", "");
                                    }
                                    if (partsSubstUWork.ChgDestMakerCd == newmeijiPartsSubstWork.ChgSrcMakerCd && partsSubstUWork.ChgDestGoodsNo.Equals(newmeijiPartsSubstWork.ChgSrcGoodsNo))
                                    {
                                        partsSubstUWork.ChgDestGoodsNo = newmeijiPartsSubstWork.ChgDestGoodsNo;
                                        partsSubstUWork.ChgDestGoodsNoNoneHp = newmeijiPartsSubstWork.ChgDestGoodsNo.Replace("-", "");
                                    }
                                }

                                //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------>>>>>
                                if (!string.IsNullOrEmpty(partsSubstUWork.ChgSrcGoodsNo.Trim())
                                    && partsSubstUWork.ChgSrcGoodsNo.Trim().Equals(partsSubstUWork.ChgDestGoodsNo.Trim())
                                    && partsSubstUWork.ChgSrcMakerCd == partsSubstUWork.ChgDestMakerCd)
                                {
                                    string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                    string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                    if (deleteErrorDic.ContainsKey(stra))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                        if (!errorDic.ContainsKey(stra))
                                        {
                                            errorDic.Add(stra, "");
                                            errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    if (deleteErrorDic.ContainsKey(strb))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                        if (!errorDic.ContainsKey(strb))
                                        {
                                            errorDic.Add(strb, "");
                                            errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.REPEATPARTSMSG;
                                    PartserrorResultWorkList.Add(ameijiPartsSubstWork);

                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------<<<<<

                                    // 新品番のinsert
                                    partsSubstUWork.UpdateDateTime = DateTime.MinValue;
                                    insertWorkList.Add(partsSubstUWork);
                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                    try
                                    {
                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                        status = this._iPartsSubstDB.Write(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                    }
                                    catch (Exception ex)
                                    {
                                        base.WriteErrorLog(ex, "Write");
                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                    insertWorkList.Clear(); // リストのクリア
                                    // 代替マスタに旧品番対応の新品番が既に存在する場合、排他メッセージのセット
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                    {
                                        string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                        string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                        if (deleteErrorDic.ContainsKey(stra))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                            if (!errorDic.ContainsKey(stra))
                                            {
                                                errorDic.Add(stra, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        if (deleteErrorDic.ContainsKey(strb))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                            if (!errorDic.ContainsKey(strb))
                                            {
                                                errorDic.Add(strb, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        //ameijiPartsSubstWork.OutNote = "変換先品番が既に登録されました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        ameijiPartsSubstWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "代替マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        if (logicalDeleteCode == 1)
                                        {
                                            logicalDeleteList.Add(partsSubstUWork);
                                            // 新品番の論理削除
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                            try
                                            {
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                                status = this._iPartsSubstDB.LogicalDelete(ref logicalDeleteList, 0, ref  sqlConnection, ref  sqlTransaction);
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                            }
                                            catch (Exception ex)
                                            {
                                                base.WriteErrorLog(ex, "LogicalDelete");
                                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                            }
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                            logicalDeleteList.Clear();

                                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                //ameijiPartsSubstWork.OutNote = "論理削除データ"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                partsSubstSuccessResultWork.Add(ameijiPartsSubstWork);
                                            }
                                            else
                                            {
                                                string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                                string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                                if (deleteErrorDic.ContainsKey(stra))
                                                {
                                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                                    goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                                    if (!errorDic.ContainsKey(stra))
                                                    {
                                                        errorDic.Add(stra, "");
                                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                    }
                                                }
                                                if (deleteErrorDic.ContainsKey(strb))
                                                {
                                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                                    goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                                    if (!errorDic.ContainsKey(strb))
                                                    {
                                                        errorDic.Add(strb, "");
                                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                    }
                                                }
                                                //ameijiPartsSubstWork.OutNote = "登録エラー、変換先品番の登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                                            }
                                        }
                                        else
                                        {
                                            partsSubstSuccessResultWork.Add(ameijiPartsSubstWork);
                                        }
                                    }
                                    else
                                    {
                                        string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                        string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                        if (deleteErrorDic.ContainsKey(stra))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                            if (!errorDic.ContainsKey(stra))
                                            {
                                                errorDic.Add(stra, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        if (deleteErrorDic.ContainsKey(strb))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                            if (!errorDic.ContainsKey(strb))
                                            {
                                                errorDic.Add(strb, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        //ameijiPartsSubstWork.OutNote = "登録エラー、変換先品番の登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                        PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                                    }

                                } // ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応
                                #endregion
                            }
                            else
                            {
                                string stra = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                                string strb = partsSubstUWork.ChgDestMakerCd + ":" + partsSubstUWork.ChgDestGoodsNo;
                                if (deleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgSrcMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (deleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //ameijiPartsSubstWork.OutNote = "削除エラー、変換元品番の削除に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("PartsSavePoint");
                            }
                        }
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
                // リストのクリア
                phyDeleteWorkList.Clear();

                // エラーデータベースの更新
                if (errorDeleteList != null && errorDeleteList.Count > 0)
                {
                    Dictionary<string, GoodsNoChangeErrorDataWork> repeatDate = new Dictionary<string, GoodsNoChangeErrorDataWork>();
                    string repeatDateKey = "";
                    for (int i = 0; i < errorDeleteList.Count; i++)
                    {
                        //GoodsNoChangeErrorDataWork errorDataWork = errorDeleteList[i] as GoodsNoChangeErrorDataWork;// DEL 2015/04/03 時シン リストのNULL、とcountは判断する対応
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                        GoodsNoChangeErrorDataWork errorDataWork = null;
                        if (errorDeleteList != null && errorDeleteList.Count > 0)
                        {
                            errorDataWork = errorDeleteList[i] as GoodsNoChangeErrorDataWork;
                        }
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<
                        repeatDateKey = errorDataWork.GoodsMakerCd.ToString() + "-" + errorDataWork.ChgSrcGoodsNo.Trim();

                        if (!repeatDate.ContainsKey(repeatDateKey))
                        {
                            repeatDate.Add(repeatDateKey, errorDataWork);
                        }
                    }
                    status = _goodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(repeatDate, ref sqlConnection, ref sqlTransaction);
                }

                // 登録件数
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    partsSubstSuccessResultWork.Clear();
                    PartserrorResultWorkList.Clear();
                }
                return status;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (partsSubstConnection != null)
                {
                    partsSubstConnection.Close();
                    partsSubstConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region
        /// <summary>
        /// 部品代替マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="searchBackWorkList">部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="cndtnWorkList">検索条件</param>
        /// <param name="mode">区分</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部品代替マスタのキー値が一致する、全ての部品代替マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int Search(out ArrayList searchBackWorkList, out ArrayList cndtnWorkList, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(out searchBackWorkList, out cndtnWorkList, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部品代替マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="searchBackWorkList">部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="cndtnWorkList">検索条件</param>
        /// <param name="mode">区分</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部品代替マスタのキー値が一致する、全ての部品代替マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int SearchProc(out ArrayList searchBackWorkList, out ArrayList cndtnWorkList, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            Dictionary<string, string> loginDic = new Dictionary<string, string>();
            Dictionary<string, string> CntDic = new Dictionary<string, string>();
            searchBackWorkList = new ArrayList();
            cndtnWorkList = new ArrayList();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                StringBuilder sql = new StringBuilder();

                # region [SELECT文]
                sql.Append("SELECT").Append(Environment.NewLine);
                sql.Append("PRT.CREATEDATETIMERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDATEDATETIMERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.FILEHEADERGUIDRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDEMPLOYEECODERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDASSEMBLYID1RF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDASSEMBLYID2RF").Append(Environment.NewLine);
                sql.Append("  ,PRT.LOGICALDELETECODERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGSRCMAKERCDRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGSRCGOODSNORF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGSRCGOODSNONONEHPRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGDESTMAKERCDRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGDESTGOODSNORF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGDESTGOODSNONONEHPRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.APPLYSTADATERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.APPLYENDDATERF").Append(Environment.NewLine);
                sql.Append("  ,B.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("  ,B.CHGSRCGOODSNORF AS CHGSRCGOODSNORF2").Append(Environment.NewLine);
                sql.Append("  ,B.CHGDESTGOODSNORF AS CHGDESTGOODSNORF2").Append(Environment.NewLine);
                sql.Append(" FROM PARTSSUBSTURF AS PRT WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                if (mode == 0)
                {
                    sql.Append(" INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                    sql.Append("ON").Append(Environment.NewLine);
                    sql.Append("( PRT.CHGSRCMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGSRCGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF) ").Append(Environment.NewLine);
                    sql.Append("OR ( PRT.CHGDESTMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGDESTGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF)").Append(Environment.NewLine);
                }
                else if (mode == 1)
                {
                    sql.Append(" INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                    sql.Append("ON").Append(Environment.NewLine);
                    sql.Append("( PRT.CHGSRCMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGSRCGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF) ").Append(Environment.NewLine);
                    sql.Append("OR ( PRT.CHGDESTMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGDESTGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF)").Append(Environment.NewLine);
                }

                sqlCommand.CommandText = sql.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, mode, enterPriseCode);
                # endregion

                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = 600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
                    MeijiPartsSubstWork meijiPartsSubstWork = new MeijiPartsSubstWork();
                    string str = string.Empty;
                    string str1 = string.Empty;
                    partsSubstUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    partsSubstUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    partsSubstUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    partsSubstUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    partsSubstUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    partsSubstUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    partsSubstUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    partsSubstUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    partsSubstUWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    partsSubstUWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    partsSubstUWork.ChgSrcGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNONONEHPRF"));
                    partsSubstUWork.ChgDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    partsSubstUWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    partsSubstUWork.ChgDestGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNONONEHPRF"));
                    partsSubstUWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    partsSubstUWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                    meijiPartsSubstWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    meijiPartsSubstWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF2"));
                    meijiPartsSubstWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF2"));
                    str = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                    str1 = meijiPartsSubstWork.ChgSrcMakerCd + ":" + meijiPartsSubstWork.ChgDestGoodsNo + ":" + meijiPartsSubstWork.ChgSrcGoodsNo;
                    if (!CntDic.ContainsKey(str1))
                    {
                        cndtnWorkList.Add(meijiPartsSubstWork);
                        CntDic.Add(str1, "");
                    }
                    if (loginDic.ContainsKey(str))
                    {
                        continue;
                    }
                    loginDic.Add(str, "");
                    searchBackWorkList.Add(partsSubstUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                CntDic.Clear();
                loginDic.Clear();

                if (searchBackWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException exsql)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(exsql, errmsg, exsql.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="mode">区分</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private StringBuilder MakeWhereString(ref SqlCommand sqlCommand, int mode, string enterPriseCode)
        {
            StringBuilder sql = new StringBuilder();
            // 企業コード
            sql.Append(" WHERE PRT.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //論理削除区分
            sql.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //マスタ区分
            if (mode == 1)
            {
                sql.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(5);
            }

            sql.Append(" ORDER BY PRT.ENTERPRISECODERF, PRT.CHGSRCMAKERCDRF, PRT.CHGSRCGOODSNORF ");

            return sql;
        }
        # endregion
 
        /// <summary>
        /// ワークのClone
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        private PartsSubstUWork CloneJoinWork(PartsSubstUWork work)
        {
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
            partsSubstUWork.EnterpriseCode = work.EnterpriseCode;
            partsSubstUWork.UpdateDateTime = work.UpdateDateTime;
            partsSubstUWork.ChgDestGoodsNo = work.ChgDestGoodsNo;
            partsSubstUWork.ChgDestMakerCd = work.ChgDestMakerCd;
            partsSubstUWork.ChgSrcGoodsNo = work.ChgSrcGoodsNo;
            partsSubstUWork.ChgSrcMakerCd = work.ChgSrcMakerCd;
            return partsSubstUWork;
        }
    }
}
