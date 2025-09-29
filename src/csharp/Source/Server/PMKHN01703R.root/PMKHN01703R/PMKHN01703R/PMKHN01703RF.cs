//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業結合マスタ変換処理
// プログラム概要   : ＣＳＶファイルより、画面抽出条件を満たしたデータをテキストファイルへ出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/02/26  修正内容 : Redmine#44209 メッセージの文言対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/07  修正内容 : Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/04/13  修正内容 : Redmine#45436 表示順位重複の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/29  修正内容 : Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業結合マスタ変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 結合マスタ変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiJoinPartsDB : RemoteDB
    {
        #region 既存リモート
        // 結合マスタのリモート
        private JoinPartsUDB _joinPartsUDB;
        // 品番変換処理共通
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        #region JoinPartsDB
        /// <summary>
        /// 結合マスタ変換処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiJoinPartsDB()
        {
            // 結合マスタ
            if (this._joinPartsUDB == null)
            {
                this._joinPartsUDB = new JoinPartsUDB();
            }
            // 品番変換処理共通
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region 結合マスタの取込処理
        /// <summary>
        /// 指定された企業コードの結合の全て戻る処理
        /// </summary>
        /// <param name="updateCount">改正の件数</param>
        /// <param name="joinerrorResultWork">検索条件リスト</param>
        /// <param name="mode">区分</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="joinSuccessResultWork">取込成功リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの結合LISTを全て戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int ReadIn(out object joinSuccessResultWork, out object joinerrorResultWork, out int updateCount, int mode, string enterPriseCode)
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            #region 結合マスタ
            // 結合マスタログ
            joinSuccessResultWork = null;
            joinerrorResultWork = null;
            ArrayList joinSuccessResultWorkList = new ArrayList();
            ArrayList joinerrorResultWorkList = new ArrayList();
            // 登録件数
            updateCount = 0;
            #endregion

            try
            {
                // コネクション生成
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // 結合マスタ変換処理
                status = JoinReadInProc(out joinSuccessResultWorkList, out joinerrorResultWorkList, out updateCount, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 戻られるリスト
                joinSuccessResultWork = joinSuccessResultWorkList;
                joinerrorResultWork = joinerrorResultWorkList;

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
                base.WriteErrorLog(ex, "JoinPartsDB.ReadIn");
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

        ///<summary>
        /// 指定された企業コードの結合マスタの取込処理
        /// </summary>
        /// <param name="joinSuccessResultWork">取込成功リスト</param>
        /// <param name="updateCount">改正の件数</param>
        /// <param name="joinerrorResultWorkList">検索条件リスト</param>
        /// <param name="mode">区分</param>
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
        /// <br>Note        : Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/29</br>
        /// </remarks>
        private int JoinReadInProc(out ArrayList joinSuccessResultWork, out ArrayList joinerrorResultWorkList, out int updateCount, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // 戻される結果リスト
            joinSuccessResultWork = new ArrayList();
            joinerrorResultWorkList = new ArrayList();
            // 完全削除リスト
            ArrayList phyDeleteWorkList = new ArrayList();
            ArrayList DeleteWorkList = new ArrayList();
            // 追加リスト
            ArrayList insertWorkList = new ArrayList();
            ArrayList haveWorkList = new ArrayList();
            ArrayList LogicalDeleteList = new ArrayList();
            ArrayList FinallyDeleteList = new ArrayList();
            ArrayList cndtnWorkList = new ArrayList();
            ArrayList coyList = new ArrayList();
            Dictionary<string, string> DeleteErrorDic = new Dictionary<string, string>();
            Dictionary<string, string> errorDic = new Dictionary<string, string>();
            Dictionary<string, string> _insertDic = new Dictionary<string, string>();
            Dictionary<string, int> _displayOrderDic = new Dictionary<string, int>(); // ADD 陳永康 2015/04/13 表示順位重複の対応
            ArrayList ErrorDeleteList = new ArrayList();
            // 登録件数
            updateCount = 0;

            Dictionary<string, JoinPartsUWork> JoinDic = new Dictionary<string, JoinPartsUWork>();
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            SqlConnection joinConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string goodsNoKeySrc = "";
            string goodsNoKeyDes = "";
            string specialNote = "";
            string errDBInsertKey = "";

            try
            {
                // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------>>>>>
                // 表示順位を検索する
                status = this.SearchDisplayOrder(out _displayOrderDic, enterPriseCode, mode);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------<<<<<
                // 結合マスタの検索
                status = this.JoinSearchProc(out phyDeleteWorkList, ref cndtnWorkList, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && phyDeleteWorkList.Count > 0)
                {
                    // 更新件数
                    updateCount = phyDeleteWorkList.Count;
                    // 新旧品番Dictionaryの作成
                    foreach (NewJoinPartsWork newJoinPartsWork in cndtnWorkList)
                    {
                        string str = newJoinPartsWork.JoinSourceMakerCode + ":" + newJoinPartsWork.JoinSourPartsNoWithH;
                        DeleteErrorDic.Add(str, newJoinPartsWork.JoinDestPartsNo);
                    }
                    // エラーデータの削除
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.JOINMST, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (JoinPartsUWork ajoinPartsUWork in phyDeleteWorkList)
                        {
                            goodsNoKeySrc = ajoinPartsUWork.JoinSourceMakerCode + ":" + ajoinPartsUWork.JoinSourPartsNoWithH;
                            goodsNoKeyDes = ajoinPartsUWork.JoinDestMakerCd + ":" + ajoinPartsUWork.JoinDestPartsNo;
                            // トランザクションの保存
                            sqlTransaction.Save("JoinSavePoint");
                            JoinPartsUWork bjoinPartsUWork = CloneJoinWork(ajoinPartsUWork);
                            NewJoinPartsWork sucNewJoinPartsWork = new NewJoinPartsWork();
                            sucNewJoinPartsWork.JoinSourPartsNoWithH = ajoinPartsUWork.JoinSourPartsNoWithH;
                            sucNewJoinPartsWork.JoinSourceMakerCode = ajoinPartsUWork.JoinSourceMakerCode;
                            sucNewJoinPartsWork.JoinDestPartsNo = ajoinPartsUWork.JoinDestPartsNo;
                            sucNewJoinPartsWork.JoinDestMakerCd = ajoinPartsUWork.JoinDestMakerCd;
                            if (DeleteErrorDic.ContainsKey(goodsNoKeySrc))
                            {
                                sucNewJoinPartsWork.NewJoinSourPartsNoWithH = DeleteErrorDic[goodsNoKeySrc];
                            }
                            else
                            {
                                sucNewJoinPartsWork.NewJoinSourPartsNoWithH = ajoinPartsUWork.JoinSourPartsNoWithH;
                            }
                            if (DeleteErrorDic.ContainsKey(goodsNoKeyDes))
                            {
                                sucNewJoinPartsWork.NewJoinDestPartsNo = DeleteErrorDic[goodsNoKeyDes];
                            }
                            else
                            {
                                sucNewJoinPartsWork.NewJoinDestPartsNo = ajoinPartsUWork.JoinDestPartsNo;
                            }
                            coyList.Add(ajoinPartsUWork);
                            // 結合マスタで削除する
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                status = this._joinPartsUDB.Delete(coyList, ref  sqlConnection, ref sqlTransaction);
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
                                string stra = ajoinPartsUWork.JoinSourceMakerCode + ":" + ajoinPartsUWork.JoinSourPartsNoWithH;
                                string strb = ajoinPartsUWork.JoinDestMakerCd + ":" + ajoinPartsUWork.JoinDestPartsNo;
                                if (DeleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinSourPartsNoWithH;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinSourceMakerCode;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (DeleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinDestPartsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //sucNewJoinPartsWork.OutNote = "排他エラー、変換元品番の削除に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                sucNewJoinPartsWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "結合マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 旧品番から新品番を変更する
                                foreach (NewJoinPartsWork anewJoinPartsWork in cndtnWorkList)
                                {
                                    if (ajoinPartsUWork.JoinDestMakerCd == anewJoinPartsWork.JoinSourceMakerCode && ajoinPartsUWork.JoinDestPartsNo.Equals(anewJoinPartsWork.JoinSourPartsNoWithH))
                                    {
                                        ajoinPartsUWork.JoinDestPartsNo = anewJoinPartsWork.JoinDestPartsNo;
                                        if (string.IsNullOrEmpty(ajoinPartsUWork.JoinSpecialNote))
                                        {
                                            ajoinPartsUWork.JoinSpecialNote = anewJoinPartsWork.JoinSourPartsNoWithH;
                                        }
                                        else
                                        {
                                            specialNote = ajoinPartsUWork.JoinSpecialNote + " " + anewJoinPartsWork.JoinSourPartsNoWithH;
                                            if (!string.IsNullOrEmpty(specialNote) && specialNote.Length > 40)
                                            {
                                                ajoinPartsUWork.JoinSpecialNote = specialNote.Substring(0, 40);
                                            }
                                            else
                                            {
                                                ajoinPartsUWork.JoinSpecialNote = specialNote;
                                            }
                                        }
                                    }

                                    if (ajoinPartsUWork.JoinSourceMakerCode == anewJoinPartsWork.JoinSourceMakerCode && ajoinPartsUWork.JoinSourPartsNoWithH.Equals(anewJoinPartsWork.JoinSourPartsNoWithH))
                                    {
                                        ajoinPartsUWork.JoinSourPartsNoWithH = anewJoinPartsWork.JoinDestPartsNo;
                                        ajoinPartsUWork.JoinSourPartsNoNoneH = anewJoinPartsWork.JoinDestPartsNo.Replace("-", "");
                                    }
                                }

                                //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------>>>>>
                                if (!string.IsNullOrEmpty(ajoinPartsUWork.JoinSourPartsNoWithH.Trim())
                                    && ajoinPartsUWork.JoinSourPartsNoWithH.Trim().Equals(ajoinPartsUWork.JoinDestPartsNo.Trim())
                                    && ajoinPartsUWork.JoinSourceMakerCode == ajoinPartsUWork.JoinDestMakerCd)
                                {
                                    string repeatStra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                    string repeatStrb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                    if (DeleteErrorDic.ContainsKey(repeatStra))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[repeatStra];
                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                        if (!errorDic.ContainsKey(repeatStra))
                                        {
                                            errorDic.Add(repeatStra, "");
                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    if (DeleteErrorDic.ContainsKey(repeatStrb))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[repeatStrb];
                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                        if (!errorDic.ContainsKey(repeatStrb))
                                        {
                                            errorDic.Add(repeatStrb, "");
                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.REPEATJOINMSG;
                                    joinerrorResultWorkList.Add(sucNewJoinPartsWork);

                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------<<<<<
                                    ajoinPartsUWork.UpdateDateTime = DateTime.MinValue;

                                    int logicalDeleteCode = ajoinPartsUWork.LogicalDeleteCode;
                                    // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------>>>>>
                                    string displayOrderKey = ajoinPartsUWork.JoinSourceMakerCode.ToString().Trim().PadLeft(4, '0') + ":" + ajoinPartsUWork.JoinSourPartsNoWithH.Trim();
                                    if (_displayOrderDic.ContainsKey(displayOrderKey))
                                    {
                                        ajoinPartsUWork.JoinDispOrder = _displayOrderDic[displayOrderKey] + 1;
                                    }
                                    //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------>>>>>
                                    if (ajoinPartsUWork.JoinDispOrder > 50)
                                    {
                                        string straOver = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                        string strbOver = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                        if (DeleteErrorDic.ContainsKey(straOver))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[straOver];
                                            goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                            if (!errorDic.ContainsKey(straOver))
                                            {
                                                errorDic.Add(straOver, "");
                                                ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        if (DeleteErrorDic.ContainsKey(strbOver))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strbOver];
                                            goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                            if (!errorDic.ContainsKey(strbOver))
                                            {
                                                errorDic.Add(strbOver, "");
                                                ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.DISPORDEROVERNUMBER;
                                        joinerrorResultWorkList.Add(sucNewJoinPartsWork);

                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                    //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------<<<<<
                                        // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------<<<<<
                                        insertWorkList.Add(ajoinPartsUWork);
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                        try
                                        {
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                            status = this._joinPartsUDB.Write(ref insertWorkList, ref  sqlConnection, ref sqlTransaction);
                                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                        }
                                        catch (Exception ex)
                                        {
                                            base.WriteErrorLog(ex, "Write");
                                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                        }
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                        insertWorkList.Clear();
                                        // 結合マスタに旧品番対応の新品番が既に存在する場合、排他メッセージのセット
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                        {
                                            string stra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                            string strb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                            if (DeleteErrorDic.ContainsKey(stra))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(stra))
                                                {
                                                    errorDic.Add(stra, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            if (DeleteErrorDic.ContainsKey(strb))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(strb))
                                                {
                                                    errorDic.Add(strb, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            //sucNewJoinPartsWork.OutNote = "変換先品番が既に登録されました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            sucNewJoinPartsWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "結合マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                                        }
                                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------>>>>>
                                            if (_displayOrderDic.ContainsKey(displayOrderKey))
                                            {
                                                _displayOrderDic[displayOrderKey] = _displayOrderDic[displayOrderKey] + 1;
                                            }
                                            // --- ADD 陳永康 2015/04/13 表示順位重複の対応 ------<<<<<
                                            if (logicalDeleteCode == 1)
                                            {
                                                LogicalDeleteList.Add(ajoinPartsUWork);
                                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                                try
                                                {
                                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                                    status = this._joinPartsUDB.LogicalDelete(ref LogicalDeleteList, 0, ref  sqlConnection, ref  sqlTransaction);
                                                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                                }
                                                catch (Exception ex)
                                                {
                                                    base.WriteErrorLog(ex, "LogicalDelete");
                                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                                }
                                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                                LogicalDeleteList.Clear();
                                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                                {
                                                    //sucNewJoinPartsWork.OutNote = "論理削除データ"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                    sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                    joinSuccessResultWork.Add(sucNewJoinPartsWork);
                                                }
                                                else
                                                {
                                                    string stra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                                    string strb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                                    if (DeleteErrorDic.ContainsKey(stra))
                                                    {
                                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                        if (!errorDic.ContainsKey(stra))
                                                        {
                                                            errorDic.Add(stra, "");
                                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                        }
                                                    }
                                                    if (DeleteErrorDic.ContainsKey(strb))
                                                    {
                                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                        if (!errorDic.ContainsKey(strb))
                                                        {
                                                            errorDic.Add(strb, "");
                                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                        }
                                                    }
                                                    //sucNewJoinPartsWork.OutNote = "登録エラー、変換先品番の登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                    sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                                    joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                                                }
                                            }
                                            else
                                            {
                                                joinSuccessResultWork.Add(sucNewJoinPartsWork);
                                            }
                                        }
                                        else
                                        {
                                            string stra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                            string strb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                            if (DeleteErrorDic.ContainsKey(stra))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(stra))
                                                {
                                                    errorDic.Add(stra, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            if (DeleteErrorDic.ContainsKey(strb))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(strb))
                                                {
                                                    errorDic.Add(strb, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            //sucNewJoinPartsWork.OutNote = "登録エラー、変換先品番の登録に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                                        }
                                    }  // ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応
                                }// ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応
                            }
                            else
                            {
                                string stra = ajoinPartsUWork.JoinSourceMakerCode + ":" + ajoinPartsUWork.JoinSourPartsNoWithH;
                                string strb = ajoinPartsUWork.JoinDestMakerCd + ":" + ajoinPartsUWork.JoinDestPartsNo;
                                if (DeleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinSourPartsNoWithH;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinSourceMakerCode;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (DeleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinDestPartsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //sucNewJoinPartsWork.OutNote = "削除エラー、変換元品番の削除に失敗しました"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("JoinSavePoint");
                            }
                        }
                        phyDeleteWorkList.Clear();

                        #region 品番変換エラーデータの更新
                        if (ErrorDeleteList != null && ErrorDeleteList.Count > 0)
                        {
                            foreach (GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork in ErrorDeleteList)
                            {
                                errDBInsertKey = goodsNoChangeErrorDataWork.GoodsMakerCd.ToString() + "-" + goodsNoChangeErrorDataWork.ChgSrcGoodsNo;
                                if (!goodsNoChgErrDic.ContainsKey(errDBInsertKey))
                                {
                                    goodsNoChgErrDic.Add(errDBInsertKey, goodsNoChangeErrorDataWork);
                                }
                            }
                            status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            joinSuccessResultWork.Clear();
                            joinerrorResultWorkList.Clear();
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
                base.WriteErrorLog(ex, "JoinPartsDB.JoinReadInProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (joinConnection != null)
                {
                    joinConnection.Close();
                    joinConnection.Dispose();
                }
            }
        }
        #endregion

        #region
        /// <summary>
        /// 結合マスタ変換処理の検索
        /// </summary>
        /// <param name="deleteWorkList">検索結果</param>
        /// <param name="cndtnWorkList">検索パラメータ</param>
        /// <param name="mode">区分</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int JoinSearchProc(out ArrayList deleteWorkList, ref ArrayList cndtnWorkList, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            Dictionary<string, string> loginDic = new Dictionary<string, string>();
            Dictionary<string, string> CntDic = new Dictionary<string, string>();
            deleteWorkList = new ArrayList();
            cndtnWorkList = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                StringBuilder sb = new StringBuilder();
                sb.Append(
                    " SELECT " +
                    "A.LOGICALDELETECODERF ," +
                    "A.UPDASSEMBLYID2RF ," +
                    "A.UPDASSEMBLYID1RF ," +
                    "A.UPDEMPLOYEECODERF ," +
                    "A.FILEHEADERGUIDRF ," +
                    "A.ENTERPRISECODERF ," +
                    "A.CREATEDATETIMERF ," +
                    "A.UPDATEDATETIMERF ," +
                    "A.JOINSOURCEMAKERCODERF ," +
                    "A.JOINSOURPARTSNOWITHHRF ," +
                    "A.JOINSOURPARTSNONONEHRF ," +
                    "A.JOINDESTMAKERCDRF ," +
                    "A.JOINDESTPARTSNORF ," +
                    "A.JOINDISPORDERRF ," +
                    "A.JOINQTYRF ," +
                    "A.JOINSPECIALNOTERF ," +
                    "B.GOODSMAKERCDRF ," +
                    "B.CHGSRCGOODSNORF ," +
                    "B.CHGDESTGOODSNORF " +
                    " FROM " +
                    "JOINPARTSURF A WITH (READUNCOMMITTED) " +
                    "INNER JOIN ");

                if (mode == 0)
                {
                    sb.Append(" GOODSNOCHANGERF B WITH (READUNCOMMITTED) " +
                              "ON " +
                              "( A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                              "OR ( A.JOINDESTMAKERCDRF = B.GOODSMAKERCDRF AND A.JOINDESTPARTSNORF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                              "WHERE A.ENTERPRISECODERF = @ENTERPRISECODERF AND B.LOGICALDELETECODERF = 0 " +
                              "ORDER BY A.ENTERPRISECODERF, A.JOINSOURCEMAKERCODERF, A.JOINSOURPARTSNOWITHHRF, A.JOINDESTMAKERCDRF, A.JOINDESTPARTSNORF ");
                }
                else if (mode == 1)
                {
                    sb.Append(" GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " +
                             "ON " +
                             "( A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                             "OR ( A.JOINDESTMAKERCDRF = B.GOODSMAKERCDRF AND A.JOINDESTPARTSNORF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                             "WHERE A.ENTERPRISECODERF = @ENTERPRISECODERF AND B.MASTERDIVCDRF = 4 AND B.LOGICALDELETECODERF = 0 " +
                             "ORDER BY A.ENTERPRISECODERF, A.JOINSOURCEMAKERCODERF, A.JOINSOURPARTSNOWITHHRF, A.JOINDESTMAKERCDRF, A.JOINDESTPARTSNORF ");
                }

                //Prameterオブジェクトの作成
                SqlParameter findParaJoinEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
                //Parameterオブジェクトへ値設定
                findParaJoinEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                sqlCommand.CommandText = sb.ToString();

                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                if (myReader == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                while (myReader.Read())
                {
                    JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
                    NewJoinPartsWork newJoinPartsWork = new NewJoinPartsWork();
                    string str = string.Empty;
                    string str1 = string.Empty;
                    joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF")).Trim();
                    joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF")).Trim();
                    joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                    joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF")).Trim();
                    newJoinPartsWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    newJoinPartsWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF")).Trim();
                    newJoinPartsWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF")).Trim();
                    str = joinPartsUWork.JoinSourceMakerCode + ":" + joinPartsUWork.JoinSourPartsNoWithH + ":" + joinPartsUWork.JoinDestMakerCd + ":" + joinPartsUWork.JoinDestPartsNo;
                    str1 = newJoinPartsWork.JoinSourceMakerCode + ":" + newJoinPartsWork.JoinDestPartsNo + ":" + newJoinPartsWork.JoinSourPartsNoWithH;
                    if (!CntDic.ContainsKey(str1))
                    {
                        cndtnWorkList.Add(newJoinPartsWork);
                        CntDic.Add(str1, "");
                    }
                    if (loginDic.ContainsKey(str))
                    {
                        continue;
                    }
                    loginDic.Add(str, "");
                    deleteWorkList.Add(joinPartsUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                CntDic.Clear();
                loginDic.Clear();
                if (deleteWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlEx)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(sqlEx, "JoinPartsChangeDB.JoinPartsSearchProc", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "JoinPartsChangeDB.JoinPartsSearchProc", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (null != sqlCommand)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region 表示順位を検索する
        /// <summary>
        /// 結合マスタの表示順位を取得します。
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="mode">モード</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrder(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション
            SqlConnection sqlConnection = null;

            Dictionary<string, int> displayOrder = new Dictionary<string, int>();
            try
            {
                // コネクション生成
                sqlConnection = _iGoodsNoChgCommonDB.CreateSqlConnection(true);
                // 結合マスタ検索処理
                status = SearchDisplayOrderProc(out displayOrder, enterpriseCode, mode, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiJoinPartsDB.SearchDisplayOrder");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            displayOrderDic = displayOrder;

            return status;
        }

        /// <summary>
        /// 商品結合マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="mode">モード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrderProc(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            displayOrderDic = new Dictionary<string, int>();
            try
            {
                string sqlText = "SELECT A.JOINSOURCEMAKERCODERF , A.JOINSOURPARTSNOWITHHRF , MAX(A.JOINDISPORDERRF) AS DISPLAYORDERRF " + Environment.NewLine;
                sqlText += "FROM JOINPARTSURF A WITH (READUNCOMMITTED) " + Environment.NewLine;

                if (mode == 0)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }
                if (mode == 1)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereStringDisplayOrder(ref sqlCommand, mode, enterpriseCode);

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
                    if (myReader != null && joinPartsUWork != null)
                    {
                        # region クラスへ格納
                        joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                        joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                        joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                        # endregion
                    }
                    string key = joinPartsUWork.JoinSourceMakerCode.ToString().Trim().PadLeft(4, '0') + ":" + joinPartsUWork.JoinSourPartsNoWithH.Trim();
                    if (!displayOrderDic.ContainsKey(key))
                    {
                        displayOrderDic.Add(key, joinPartsUWork.JoinDispOrder);
                    }
                    else
                    {
                        continue;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiJoinPartsDB.SearchDisplayOrderProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="mode">モード</param>
        /// <param name="enterpriseCode">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/04/13</br>
        private string MakeWhereStringDisplayOrder(ref SqlCommand sqlCommand, int mode, string enterpriseCode)
        {
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //企業コード
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            retstring.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //マスタ区分
            if (mode == 1)
            {
                retstring.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(4);
            }

            //GROUP BY
            retstring.Append(" GROUP BY A.JOINSOURCEMAKERCODERF, A.JOINSOURPARTSNOWITHHRF ");

            return retstring.ToString();
        }
        #endregion

        /// <summary>
        /// ワークのClone
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        private JoinPartsUWork CloneJoinWork(JoinPartsUWork work)
        {
            JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
            joinPartsUWork.EnterpriseCode = work.EnterpriseCode;
            joinPartsUWork.UpdateDateTime = work.UpdateDateTime;
            joinPartsUWork.JoinDestPartsNo = work.JoinDestPartsNo;
            joinPartsUWork.JoinDestMakerCd = work.JoinDestMakerCd;
            joinPartsUWork.JoinSourceMakerCode = work.JoinSourceMakerCode;
            joinPartsUWork.JoinSourPartsNoWithH = work.JoinSourPartsNoWithH;
            return joinPartsUWork;
        }
    }
}
