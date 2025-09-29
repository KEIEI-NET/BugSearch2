//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業商品管理情報マスタ変換処理
// プログラム概要   : 条件を満たしたデータをテキストファイルへ出力する
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
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業商品管理情報マスタ変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品管理情報マスタ変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsMngDB : RemoteDB
    {
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

        #region 既存のリモート
        private GoodsMngDB _iGoodsMngDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        #region MeijiGoodsStockDB
        /// <summary>
        /// 商品管理情報マスタ変換処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsMngDB()
        {
            // 商品管理情報
            if (this._iGoodsMngDB == null)
            {
                this._iGoodsMngDB = new GoodsMngDB();
            }
            // 品番変換処理共通
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region 商品管理情報マスタの取込処理
        /// <summary>
        /// 指定された企業コードの商品管理情報の全て戻る処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの商品管理情報LISTを全て戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int WriteIn(out object MngSuccessResultWork, out object MngErrorResultWork, out int updateCount, int updateMode, string enterPriseCode)
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 商品管理情報マスタに成功な登録するデータ
            MngSuccessResultWork = null;
            ArrayList mngSuccessResultWorkList = new ArrayList();

            // 商品管理情報マスタに失敗な登録するデータ
            MngErrorResultWork = null;
            ArrayList mngErrorResultWorkList = new ArrayList();

            // 登録件数
            updateCount = 0;

            try
            {
                // コネクション生成
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // 商品管理情報マスタ変換処理
                status = WriteInMngProc(out mngSuccessResultWorkList, out mngErrorResultWorkList, out updateCount, updateMode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                // 戻られるリスト
                MngSuccessResultWork = mngSuccessResultWorkList;
                MngErrorResultWork = mngErrorResultWorkList;

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
                base.WriteErrorLog(ex, "MeijiGoodsMngDB.WriteIn");
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

        #region 商品情報管理マスタ
        #region 商品情報管理Write
        /// <summary>
        /// 指定された企業コードの商品管理情報マスタの取込処理
        /// </summary>
        /// <param name="mngSuccessResultWork">取込成功リスト</param>
        /// <param name="mngErrorResultWork">取込失敗リスト</param>
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
        private int WriteInMngProc(out ArrayList mngSuccessResultWork, out ArrayList mngErrorResultWork, out int updateCount, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // 戻される結果リスト
            mngSuccessResultWork = new ArrayList();
            mngErrorResultWork = new ArrayList();
            updateCount = 0;
            // エラーメッセージ
            string message = string.Empty;
            // リスト
            ArrayList changeWorkList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            SqlConnection mngConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            // 新旧品番Dictionary
            Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            string goodsNoKey = "";
            // 品番変換エラーデータ、更新追加リスト
            ArrayList changeErrorList = new ArrayList();
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDeleteDiv = 0;

            try
            {
                // 商品管理情報マスタで検索する
                status = this.SearchGoodsMngProcProc(out changeWorkList, out goodsNoAllDic, updateMode, enterPriseCode, ref mngConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && changeWorkList.Count > 0)
                {
                    // 変換されるデータのカウント
                    updateCount = changeWorkList.Count;
                    // 品番変換エラーデータを削除する
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.GOODSMNGMST, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        #region 商品管理情報マスタに新旧品番を変換する
                        foreach (GoodsMngWork goodsMngWork in changeWorkList)
                        {
                            // トランザクションの保存
                            sqlTransaction.Save("GoodsMngSavePoint");
                            // メーカー＋旧品番のキーの作成
                            goodsNoKey = goodsMngWork.GoodsMakerCd.ToString() + "-" + goodsMngWork.GoodsNo.Trim();
                            // 商品管理情報マスタに旧品番の削除
                            deleteWorkList.Add(goodsMngWork);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                status = this._iGoodsMngDB.DeleteGoodsMngProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "DeleteGoodsMngProc");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                            deleteWorkList.Clear();
                            // ログデータの作成
                            MeiJiGoodsMngWork meiJiGoodsMngWork = new MeiJiGoodsMngWork();
                            meiJiGoodsMngWork.SectionCode = goodsMngWork.SectionCode;
                            meiJiGoodsMngWork.GoodsMGroup = goodsMngWork.GoodsMGroup;
                            meiJiGoodsMngWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                            meiJiGoodsMngWork.BLGoodsCode = goodsMngWork.BLGoodsCode;
                            meiJiGoodsMngWork.GoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                            meiJiGoodsMngWork.NewGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                            // 商品管理情報マスタで旧品番に更新される場合
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                //meiJiGoodsMngWork.OutNote = UPDATEFAIL; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                meiJiGoodsMngWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "商品管理情報マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                mngErrorResultWork.Add(meiJiGoodsMngWork);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                #region 新品番の追加
                                goodsMngWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                goodsMngWork.UpdateDateTime = DateTime.MinValue;
                                logicalDeleteDiv = goodsMngWork.LogicalDeleteCode;
                                insertWorkList.Add(goodsMngWork);
                                // 商品管理情報マスタで追加する
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                try
                                {
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                    status = this._iGoodsMngDB.WriteGoodsMngProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                }
                                catch (Exception ex)
                                {
                                    base.WriteErrorLog(ex, "WriteGoodsMngProc");
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                // 商品管理情報マスタに旧品番対応の新品番が既に存在する場合、排他メッセージのセット
                                if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    insertWorkList.Clear();　// リストのクリア
                                    //meiJiGoodsMngWork.OutNote = EXISTMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    meiJiGoodsMngWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "商品管理情報マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    mngErrorResultWork.Add(meiJiGoodsMngWork);
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (logicalDeleteDiv == 1)
                                    {
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                        try
                                        {
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                            status = this._iGoodsMngDB.LogicalDeleteGoodsMngProc(ref insertWorkList, 0, ref sqlConnection, ref sqlTransaction);
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                                        }
                                        catch (Exception ex)
                                        {
                                            base.WriteErrorLog(ex, "LogicalDeleteGoodsMngProc");
                                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                        }
                                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                        insertWorkList.Clear();　// リストのクリア
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            //meiJiGoodsMngWork.OutNote = DELETEMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            mngSuccessResultWork.Add(meiJiGoodsMngWork);
                                        }
                                        else
                                        {
                                            //meiJiGoodsMngWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                            if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                                goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                            }
                                            mngErrorResultWork.Add(meiJiGoodsMngWork);
                                        }
                                    }
                                    else
                                    {
                                        insertWorkList.Clear();　// リストのクリア
                                        mngSuccessResultWork.Add(meiJiGoodsMngWork);
                                    }
                                }
                                else
                                {
                                    insertWorkList.Clear();　// リストのクリア
                                    //meiJiGoodsMngWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    mngErrorResultWork.Add(meiJiGoodsMngWork);
                                }
                                #endregion
                            }
                            else
                            {
                                //meiJiGoodsMngWork.OutNote = OLDEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                mngErrorResultWork.Add(meiJiGoodsMngWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("GoodsMngSavePoint");
                            }
                        }
                        // リストのクリア
                        changeWorkList.Clear();
                        #endregion

                        #region 品番変換エラーデータの更新
                        status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            mngSuccessResultWork.Clear();
                            mngErrorResultWork.Clear();
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
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.WriteInMngProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (mngConnection != null)
                {
                    mngConnection.Close();
                    mngConnection.Dispose();
                }
            }
        }
        #endregion

        #region 商品情報管理検索
        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsmngWorkList">検索結果</param>
        /// <param name="goodsNoAllDic">新旧品番Dictionary</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 指定された条件の商品管理情報マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        private int SearchGoodsMngProcProc(out ArrayList goodsmngWorkList, out Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string goodsNoKey = "";
            goodsmngWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
                sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                sqlTxt += "	,B.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GDM.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GDM.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    sqlTxt += " AND B.MASTERDIVCDRF = 2 " + Environment.NewLine;
                }
                sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //企業コード
                sqlTxt += " GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

                //論理削除区分
                sqlTxt += " AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlTxt += " ORDER BY GDM.ENTERPRISECODERF, GDM.GOODSMAKERCDRF, GDM.GOODSNORF, GDM.SECTIONCODERF ";

                sqlCommand.CommandText += sqlTxt;

                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // 商品管理情報ワークと新旧品番ワークの作成
                    GoodsMngWork goodsMngWork = new GoodsMngWork();
                    MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();
                    // クラス格納処理
                    CopyToGoodsMngWorkFromReader(ref myReader, out goodsMngWork, out meijiGoodsStockWork);
                    goodsmngWorkList.Add(goodsMngWork);
                    goodsNoKey = meijiGoodsStockWork.GoodsMakerCd.ToString() + "-" + meijiGoodsStockWork.OldGoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiGoodsStockWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
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
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkGoodsMngWork">GoodsMngWork</param>
        /// <param name="meijiGoodsStockWork">MeijiGoodsStockWork</param>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        /// </remarks>
        private void CopyToGoodsMngWorkFromReader(ref SqlDataReader myReader, out GoodsMngWork wkGoodsMngWork, out MeijiGoodsStockWork meijiGoodsStockWork)
        {
            wkGoodsMngWork = new GoodsMngWork();
            meijiGoodsStockWork = new MeijiGoodsStockWork();

            wkGoodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkGoodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkGoodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
            wkGoodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkGoodsMngWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkGoodsMngWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkGoodsMngWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkGoodsMngWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkGoodsMngWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsMngWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));

            meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
        }
        #endregion
        #endregion
        #endregion
    }
}
