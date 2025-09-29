//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良データ削除処理
// プログラム概要   : 優良データ削除処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 梁森東
// 作 成 日  2011/07/15  修正内容 : 連番No.2 新規作成                      
//----------------------------------------------------------------------------//
// <br>Update Note: 2011/08/17  連番2 梁森東</br>
// <br>            : REDMINE#23748の対応</br>
//----------------------------------------------------------------------------//
// <br>Update Note: 2011/08/19  連番2 梁森東</br>
// <br>            : REDMINE#23820の対応</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2011/08/19  連番2 caohh</br>
// <br>            : REDMINE#23820の対応</br>
//----------------------------------------------------------------------------//
// <br>Update Note: 2011/08/30  連番2 梁森東</br>
// <br>            : REDMINE#23820の対応</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2015/01/28 松本</br>
// <br>           : PMSCM同期化対応の変更</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2015/06/08  高騁</br>
// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>
// --------------------------------------------------------------------------//
// <br>Update Note: 2015/08/20  高騁</br>
// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>
// --------------------------------------------------------------------------//
//****************************************************************************//

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
using System.Collections.Generic; 

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良データ削除処理リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 仕入月次集計データ更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer	: 梁森東</br>
    /// <br>Date		: 2011/07/15</br>
    /// <br>Update Note : 2011/07/21 caohh</br>
    /// <br>            : 優良データ削除チェックリスト対応</br>
    /// <br>Update Note : 2015/06/08 高騁</br>
    /// <br>管理番号    : 11100068-00 </br>
    /// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>    
    /// </remarks>
    [Serializable]
    public class YuuRyouDataDelDB : RemoteWithAppLockDB, IYuuRyouDataDelDB
    {
        private int StockDeleteCount = 0;
        private int GoodsDeleteCount = 0;
        private int JoinDeleteCount = 0;
        private int RateDeleteCount = 0; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
        /// <summary>
        /// 優良データ削除処理リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/15</br>
        /// </remarks>
        public YuuRyouDataDelDB()
            : base("PMKHN01516D", "Broadleaf.Application.Remoting.ParamData.MTtlStockSlipWork", "MTTLSTOCKSLIPRF")
        {
        }
        # region [削除処理]
        /// <summary>
        /// 指定された条件に優良データを物理削除。
        /// </summary>
        /// <param name="deleteConditionObj">deleteConditionObjオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に優良データを物理削除します。</br>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        public int Delete(ref object deleteConditionObj)
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
                status = this.DeleteProc(ref deleteConditionObj, connection, transaction);
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
        # endregion

        // ---- ADD caohh 2011/07/21 ---->>>>
        # region [Search処理]
        /// <summary>
        /// 指定された条件に優良データを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="deleteResultWork">検索結果</param>
        /// <param name="deleteConditionObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に優良データを全て戻します（論理削除除く）</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        public int Search(out object deleteResultWork, object deleteConditionObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            deleteResultWork = null;

            DeleteConditionWork deleteConditionWork = deleteConditionObj as DeleteConditionWork;

            try
            {
                status = SearchProc(out deleteResultWork, deleteConditionWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "YuuRyouDataDelDB.Search Exception=" + ex.Message);
                deleteResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された条件に優良データを全て戻します
        /// </summary>
        /// <param name="deleteResultWork">検索結果</param>
        /// <param name="deleteConditionWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に優良データを全て戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// <br></br>
        private int SearchProc(out object deleteResultWork, DeleteConditionWork deleteConditionWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            deleteResultWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }

                status = SearchDeleteDataProc(ref al, ref sqlConnection, deleteConditionWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "YuuRyouDataDelDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            deleteResultWork = al;

            return status;
        }

        /// <summary>
        /// 指定された条件に優良データを全て戻します
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="deleteConditionWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件に優良データを全て戻します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/07/21</br>
        /// <br>Update Note: 2011/08/30  連番2 梁森東</br>
        /// <br>            : REDMINE#23820の対応</br>
        /// <br></br>
        private int SearchDeleteDataProc(ref ArrayList al, ref SqlConnection sqlConnection, DeleteConditionWork deleteConditionWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region Select文作成
                //「在庫品取扱い：④在庫品時 チェックリストを出力 商品と在庫削除しない」の場合
                if (deleteConditionWork.GoodsDeleteCode == 4 || deleteConditionWork.GoodsDeleteCode == 3)
                {
                    # region 条件により、商品マスタ（ユーザー登録分）を検索する;
                    sqlText += " SELECT " + Environment.NewLine;
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        sqlText += " DISTINCT (CAST(GOODSURF.GOODSMAKERCDRF as CHAR(4))+GOODSURF.GOODSNORF) AS FLAG, " + Environment.NewLine;
                    }
                    sqlText += " GOODSURF.GOODSMAKERCDRF, " + Environment.NewLine;//商品メーカーコード
                    sqlText += " MAK.MAKERNAMERF, " + Environment.NewLine;//メーカー名称
                    sqlText += " GOODSURF.GOODSNORF, " + Environment.NewLine;//商品番号
                    sqlText += " GOODSURF.GOODSNAMERF, " + Environment.NewLine;//商品名称
                    sqlText += " GOODSURF.BLGOODSCODERF, " + Environment.NewLine;//BL商品コード
                    sqlText += " '' AS WAREHOUSECODERF, " + Environment.NewLine; //倉庫コード
                    sqlText += " '' AS WAREHOUSENAMERF, " + Environment.NewLine; //倉庫名称                   
                    sqlText += " '' AS WAREHOUSESHELFNORF, " + Environment.NewLine;//倉庫棚番
                    sqlText += " CAST(0 as bigint) AS SHIPMENTPOSCNTRF, " + Environment.NewLine;//出荷可能数
                    sqlText += " CAST(0 as bigint)  AS SALESORDERCOUNTRF " + Environment.NewLine;//発注数
                    sqlText += " FROM " + Environment.NewLine;
                    sqlText += " GOODSURF " + Environment.NewLine;
                    //メーカーマスタ
                    sqlText += " LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                    sqlText += " ON" + Environment.NewLine;
                    sqlText += "     MAK.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND MAK.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    //削除区分:メーカー+中分類/メーカー+グループコード
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        ////商品管理情報マスタ
                        //sqlText += " LEFT JOIN GOODSMNGRF " + Environment.NewLine;
                        //sqlText += " ON" + Environment.NewLine;
                        //sqlText += "     GOODSMNGRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                        //sqlText += " AND GOODSMNGRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                        //sqlText += " AND GOODSMNGRF.GOODSNORF=GOODSURF.GOODSNORF" + Environment.NewLine;
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        sqlText += " LEFT JOIN BLGOODSCDURF " + Environment.NewLine;
                        sqlText += " ON" + Environment.NewLine;
                        sqlText += "     BLGOODSCDURF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND BLGOODSCDURF.BLGOODSCODERF=GOODSURF.BLGOODSCODERF" + Environment.NewLine;

                    }
                    //Where文
                    sqlText += " WHERE " + Environment.NewLine;
                    sqlText += " GOODSURF.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //削除区分:メーカー
                    if (deleteConditionWork.DeleteCode == 0)
                    {
                        //商品メーカーコード
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh 2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            sqlText += " ))" + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0) 
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " ( GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            sqlText += " ))" + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                             --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            sqlText += " ))" + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF  NOT IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /* --- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            sqlText += " ))"+ Environment.NewLine;
                        }
                        sqlText += " )";
                    }
                    //削除区分:メーカー+中分類/メーカー+グループコード
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        sqlText += " AND GOODSURF.GOODSMAKERCDRF =" + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        //{
                        //    sqlText += " AND " + Environment.NewLine;
                        //    sqlText += " GOODSMNGRF.SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        //}
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        //商品番号
                        sqlText += " AND GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                        //ADD by Liangsd   2011/08/30----------------->>>>>>>>>>
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        if (deleteConditionWork.DeleteCode == 2)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND (" + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += " ) ) ) )";
                        }
                        if (deleteConditionWork.DeleteCode == 1)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                            sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += ") ) ) ) ) )";
                        }
                        //ADD by Liangsd   2011/08/30-----------------<<<<<<<<<<

                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        //sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                        //sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        
                        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        //{
                        //    sqlText += " AND " + Environment.NewLine;
                        //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        //}
                       
                        //sqlText += " AND " + Environment.NewLine;
                        //sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        //if (deleteConditionWork.DeleteCode == 1)
                        //{
                        //    sqlText += " AND ( " + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ";
                        //}
                        //if (deleteConditionWork.DeleteCode == 2)
                        //{
                        //    sqlText += " AND GOODSMGROUPRF IN (" + Environment.NewLine;
                        //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        //    sqlText += " AND (" + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " BLGROUPCODERF= " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ) ";
                        //}
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        sqlText += " AND GOODSNORF NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        /* --- DEL by caohh  2011/08/19---------------->>>>>
                        if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        {
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        }
                         --- DEL by caohh  2011/08/19----------------<<<<<*/
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " ) ";
                    }
                    # endregion
                }
                //「在庫品取扱い：③チェックリストを出力して、在庫マスタも削除する」の場合
                if (deleteConditionWork.GoodsDeleteCode == 3)
                {
                    # region 条件により、在庫マスタと商品マスタ（ユーザー登録分）を検索する;
                    sqlText += " UNION ALL " + Environment.NewLine;
                    sqlText += " SELECT " + Environment.NewLine;
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        sqlText += " '' AS FLAG, " + Environment.NewLine;
                    }
                    sqlText += " GOODSURF.GOODSMAKERCDRF, " + Environment.NewLine;//商品メーカーコード
                    sqlText += " MAK.MAKERNAMERF, " + Environment.NewLine;//メーカー名称
                    sqlText += " GOODSURF.GOODSNORF, " + Environment.NewLine;//商品番号
                    sqlText += " GOODSURF.GOODSNAMERF, " + Environment.NewLine;//商品名称
                    sqlText += " GOODSURF.BLGOODSCODERF, " + Environment.NewLine;//BL商品コード
                    sqlText += " STOCKRF.WAREHOUSECODERF, " + Environment.NewLine; //倉庫コード
                    sqlText += " WARE.WAREHOUSENAMERF, " + Environment.NewLine; //倉庫名称                   
                    sqlText += " STOCKRF.WAREHOUSESHELFNORF, " + Environment.NewLine;//倉庫棚番
                    sqlText += " STOCKRF.SHIPMENTPOSCNTRF, " + Environment.NewLine;//出荷可能数
                    sqlText += " STOCKRF.SALESORDERCOUNTRF " + Environment.NewLine;//発注数                                   
                    sqlText += " FROM " + Environment.NewLine;
                    sqlText += " GOODSURF " + Environment.NewLine;
                    //メーカーマスタ
                    sqlText += " LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                    sqlText += " ON" + Environment.NewLine;
                    sqlText += "     MAK.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND MAK.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    //在庫マスタ
                    sqlText += " LEFT JOIN STOCKRF" + Environment.NewLine;
                    sqlText += " ON STOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND STOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " AND STOCKRF.GOODSNORF = GOODSURF.GOODSNORF" + Environment.NewLine;
                    //倉庫マスタ
                    sqlText += " LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                    sqlText += " ON" + Environment.NewLine;
                    sqlText += "     WARE.ENTERPRISECODERF=STOCKRF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND WARE.WAREHOUSECODERF=STOCKRF.WAREHOUSECODERF" + Environment.NewLine;
                    //WHERE文
                    sqlText += " WHERE  " + Environment.NewLine;
                    sqlText += " GOODSURF.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    /* --- DEL by caohh  2011/08/19---------------->>>>>
                    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                    {
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " STOCKRF.SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                    }
                     --- DEL by caohh  2011/08/19----------------<<<<<*/
                    //削除区分:メーカー
                    if (deleteConditionWork.DeleteCode == 0)
                    {
                        //商品マスタ
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /* --- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                             --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            sqlText += " ) )";
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            sqlText += " ) )";
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /*--- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                            --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            sqlText += " ) )";
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                            {
                                sqlText += " OR " + Environment.NewLine;
                            }
                            sqlText += " (GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " STOCKRF.GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            //商品番号
                            sqlText += " AND  GOODSURF.GOODSNORF IN (" + Environment.NewLine;
                            sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            /* --- DEL by caohh  2011/08/19---------------->>>>>
                            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                            {
                                sqlText += " AND " + Environment.NewLine;
                                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                            }
                             --- DEL by caohh  2011/08/19----------------<<<<<*/
                            sqlText += " AND " + Environment.NewLine;
                            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            sqlText += "  ) )";
                        }
                        sqlText += " )";
                    }
                    //削除区分:メーカー＋中分類/メーカー＋グループコード
                    if (deleteConditionWork.DeleteCode == 1 || deleteConditionWork.DeleteCode == 2)
                    {
                        //商品マスタ
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSURF.GOODSNORF IN ( " + Environment.NewLine;

                        //ADD by Liangsd   2011/08/30----------------->>>>>>>>>>
                        sqlText += " SELECT STOCK.GOODSNORF FROM GOODSURF " + Environment.NewLine;
                        sqlText += " INNER JOIN  STOCKRF AS STOCK " + Environment.NewLine;
                        sqlText += " ON STOCK.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND STOCK.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += " AND STOCK.GOODSNORF = GOODSURF.GOODSNORF" + Environment.NewLine;
                        sqlText += " WHERE " + Environment.NewLine;
                        sqlText += " GOODSURF.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND GOODSURF.GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " GOODSURF.BLGOODSCODERF IN ( " + Environment.NewLine;
                        if (deleteConditionWork.DeleteCode == 1)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                            sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND ( " + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += ") ) ) ) ) )";
                        }
                        if (deleteConditionWork.DeleteCode == 2)
                        {
                            sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                            sqlText += " AND (" + Environment.NewLine;
                            if (deleteConditionWork.Code1 != 0)
                            {
                                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code2 != 0)
                            {
                                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code3 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                                if (deleteConditionWork.Code4 != 0)
                                {
                                    sqlText += " OR  " + Environment.NewLine;
                                }
                            }
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                            }
                            sqlText += " ) ) ) )";
                        }
                        //ADD by Liangsd   2011/08/30-----------------<<<<<<<<<<
                        //DEL by Liangsd   2011/08/30----------------->>>>>>>>>>
                        //sqlText += " SELECT STOCK.GOODSNORF FROM GOODSMNGRF AS GOODSMNG " + Environment.NewLine;
                        //sqlText += " INNER JOIN  STOCKRF AS STOCK " + Environment.NewLine;
                        //sqlText += " ON STOCK.ENTERPRISECODERF = GOODSMNG.ENTERPRISECODERF" + Environment.NewLine;
                        ////sqlText += " AND STOCK.SECTIONCODERF = GOODSMNG.SECTIONCODERF" + Environment.NewLine;//DEL by Liangsd     2011/08/19
                        //sqlText += " AND STOCK.GOODSMAKERCDRF = GOODSMNG.GOODSMAKERCDRF" + Environment.NewLine;
                        //sqlText += " AND STOCK.GOODSNORF = GOODSMNG.GOODSNORF" + Environment.NewLine;
                        //sqlText += " WHERE " + Environment.NewLine;
                        //sqlText += " GOODSMNG.ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                       
                        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                        //{
                        //    sqlText += " AND " + Environment.NewLine;
                        //    sqlText += " GOODSMNG.SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                        //}
                        
                        //sqlText += " AND GOODSMNG.GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        //if (deleteConditionWork.DeleteCode == 1)
                        //{
                        //    sqlText += " AND ( " + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " GOODSMNG.GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ) ";
                        //}
                        //if (deleteConditionWork.DeleteCode == 2)
                        //{
                        //    sqlText += " AND GOODSMGROUPRF IN (" + Environment.NewLine;
                        //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        //    sqlText += " AND (" + Environment.NewLine;
                        //    if (deleteConditionWork.Code1 != 0)
                        //    {
                        //        sqlText += " BLGROUPCODERF= " + deleteConditionWork.Code1 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code2 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code3 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        //    }
                        //    if (deleteConditionWork.Code4 != 0)
                        //    {
                        //        if (deleteConditionWork.Code1 != 0 || deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0)
                        //        {
                        //            sqlText += " OR " + Environment.NewLine;
                        //        }
                        //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        //    }
                        //    sqlText += " ) ) ) ";
                        //}
                        //DEL by Liangsd   2011/08/30-----------------<<<<<<<<<<
                    }
                    //ORDER BY
                    sqlText += " ORDER BY GOODSMAKERCDRF, GOODSNORF, WAREHOUSECODERF " + Environment.NewLine;
                    # endregion
                }

                sqlCommand.CommandText = sqlText;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    DeleteResultWork deleteResultWork = new DeleteResultWork();
                    #region [抽出結果-値セット]
                    deleteResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));　 // 商品メーカーコード
                    deleteResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));　 // メーカー名称
                    deleteResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));　         // 商品番号
                    deleteResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
                    deleteResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); 　　　// 商品名称
                    if (deleteConditionWork.GoodsDeleteCode == 3)
                    {
                        deleteResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));         // 倉庫コード
                        deleteResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));         // 倉庫名称
                        deleteResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));           // 倉庫棚番
                        deleteResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));            //出荷可能数
                        deleteResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));                   // 発注数
                    }
                    #endregion

                    al.Add(deleteResultWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "YuuRyouDataDelDB.SearchDeleteDataProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        # endregion [Search処理]
        // ---- ADD caohh 2011/07/21 ----<<<<

        #region メーカーコードを物理削除。
        /// <summary>
        /// メーカーコードを物理削除します。
        /// </summary>
        /// <param name="deleteConditionObj">deleteConditionObjオブジェクト</param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>        /// <remarks>
        /// <br>Note		: メーカーコードを物理削除を初期化します。</br>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note : 2015/06/08 高騁</br>
        /// <br>管理番号    : 11100068-00 </br>
        /// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>     
        /// </remarks>
        /// <returns>STATUS</returns>
        private int DeleteProc(ref object deleteConditionObj, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            DeleteConditionWork deleteConditionWork = (DeleteConditionWork)deleteConditionObj;
            status = SearchStockDelete(ref deleteConditionWork, connection, transaction);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = SearchGoodsDelete(ref deleteConditionWork, connection, transaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchJoinDelete(ref deleteConditionWork, connection, transaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
                        status = SearchRateDelete(ref deleteConditionWork, connection, transaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        if (deleteConditionWork.RateDeleteCode != 9)
                        {
                            status = DeleteRateUProc(ref deleteConditionWork, connection, transaction);
                            deleteConditionWork.RateNotDeleteCnt = RateDeleteCount - deleteConditionWork.RateDeleteCnt;
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }
                        }
                        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<
                        if ((deleteConditionWork.GoodsDeleteCode == 1 || deleteConditionWork.GoodsDeleteCode == 3) && deleteConditionWork.JoinDeleteCode == 1)
                        {
                            status = DeleteStockProc(ref deleteConditionWork, connection, transaction);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                                status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                  ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                                }
                                else
                                {
                                    return status;
                                }
                                  ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 1 || deleteConditionWork.GoodsDeleteCode == 3) && deleteConditionWork.JoinDeleteCode == 2)
                        {
                            status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                            deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteStockProc(ref deleteConditionWork, connection, transaction);
                            }
                            else
                            {
                                return status;
                            }
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                                 status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                                 if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                 {
                                  ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                                }
                                else
                                {
                                    return status;
                                }
                                 ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4) && deleteConditionWork.JoinDeleteCode == 1)
                        {
                            /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                             status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                             if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                             {
                              ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                //ADD by tianjw     2011/09/05------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by tianjw     2011/09/05-------------<<<<<<<<<<<
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                                //DEL by tianjw     2011/09/05------------->>>>>>>>>>>
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                //{
                                //    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                //    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                //}
                                //else
                                //{
                                //    return status;
                                //}
                                //DEL by tianjw     2011/09/05-------------<<<<<<<<<<<
                            /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                            else
                            {
                                return status;
                            }
                              ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4) && deleteConditionWork.JoinDeleteCode == 2)
                        {
                            /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                            status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                              ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                            status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                            /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                            }
                            else
                            {
                                return status;
                            }
                              ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                //ADD by tianjw     2011/09/05------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by tianjw     2011/09/05-------------<<<<<<<<<<<
                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                                //DEL by tianjw     2011/09/05------------->>>>>>>>>>>
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                //{
                                //    status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                //    deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                                //}
                                //else
                                //{
                                //    return status;
                                //}
                                //DEL by tianjw     2011/09/05-------------<<<<<<<<<<<

                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 1 || deleteConditionWork.GoodsDeleteCode == 3) && deleteConditionWork.JoinDeleteCode == 9)
                        {
                            status = DeleteStockProc(ref deleteConditionWork, connection, transaction);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                                status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); 
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                  ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                                /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                                }
                                else
                                {
                                    return status;
                                }
                                  ----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/

                                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                                }
                                else
                                {
                                    return status;
                                }
                                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                                deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if ((deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4) && deleteConditionWork.JoinDeleteCode == 9)
                        {
                            // status = DeleteRateUProc(ref deleteConditionWork, connection, transaction); // DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteGoodsPriceUProc(ref deleteConditionWork, connection, transaction);//ADD by Liangsd     2011/08/17
                            }
                            else
                            {
                                return status;
                            }

                            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                DeleteGoodsUProc(ref deleteConditionWork, connection, transaction);
                            }
                            else
                            {
                                return status;
                            }
                            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                            deleteConditionWork.GoodsNotDeleteCnt = GoodsDeleteCount - deleteConditionWork.GoodsDeleteCnt;
                        }
                        if (deleteConditionWork.GoodsDeleteCode == 9 && deleteConditionWork.JoinDeleteCode == 1)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            }
                            else
                            {
                                return status;
                            }
                        }
                        if (deleteConditionWork.GoodsDeleteCode == 9 && deleteConditionWork.JoinDeleteCode == 2)
                        {
                                status = DeleteJoinPartsUProc(ref deleteConditionWork, connection, transaction);
                                deleteConditionWork.JoinNotDeleteCnt = JoinDeleteCount - deleteConditionWork.JoinDeleteCnt;
                            
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    return status;
                }
            }
            else
            {
                return status;
            }
            deleteConditionWork.StockNotDeleteCnt = StockDeleteCount - deleteConditionWork.StockDeleteCnt;
            return status;
        }
        #endregion
        //DEL by Liangsd 2011/08/30------>>>>>>>>
        #region DeleteSource
        //#region 在庫マスタ削除
        ///// <summary>
        /////    在庫マスタ削除
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">データベース接続情報</param>
        ///// <param name="transaction">トランザクション情報</param>
        ///// <br>Programmer	: 梁森東</br>
        ///// <br>Date		: 2011/07/13</br>
        ///// <br>Update Note: 2011/08/19  連番2 梁森東</br>
        ///// <br>            : REDMINE#23820の対応</br>
        ///// <returns></returns>
        //private int DeleteStockProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region 条件により、在庫マスタを削除する
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " STOCKRF " + Environment.NewLine;
        //        sqlText += "  WHERE  " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //DEL by Liangsd     2011/08/19---------------->>>>>>>>>>>>
        //        //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //        //{
        //        //    sqlText += " AND " + Environment.NewLine;
        //        //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //        //}
        //        //DEL by Liangsd     2011/08/19-----------------<<<<<<<<<<<<
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //        }
        //         if (deleteConditionWork.DeleteCode == 1)
        //         {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSNORF in ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //            }
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine; 
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) )";
        //        }
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //            }
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMGROUPRF  IN (  "   + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //        }
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            deleteConditionWork.StockDeleteCnt = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        # endregion
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        
        //#region 商品マスタ削除
        ////ADD by Liangsd     2011/08/17------------------->>>>>>>>>>
        ///// <summary>
        ///// 商品マスタ削除
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">データベース接続情報</param>
        ///// <param name="transaction">トランザクション情報</param>
        ///// <br>Programmer	: 梁森東</br>
        ///// <br>Date		: 2011/07/13</br>
        ///// <returns></returns>
        //private int DeleteGoodsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region 条件により、商品マスタ（ユーザー登録分）を削除する;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " GOODSURF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //削除区分 = メーカー
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //        // 在庫品取扱い：②④在庫品時、商品／在庫どちらも削除しないと
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {

        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }
        //        //削除区分 = メーカー+中分類
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            { 
        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }
        //        //削除区分 =メーカー +  グループコード
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( "  + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";

        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  "  + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            deleteConditionWork.GoodsDeleteCnt = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        # endregion
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        ////ADD by Liangsd     2011/08/17-------------------<<<<<<<<<<
        //#endregion
        //#region 価格マスタ削除
        ///// <summary>
        ///// 価格マスタ削除
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">データベース接続情報</param>
        ///// <param name="transaction">トランザクション情報</param>
        ///// <br>Programmer	: 梁森東</br>
        ///// <br>Date		: 2011/08/17</br>
        ///// <br>Update Note: 2011/08/17  連番2 梁森東</br>
        ///// <br>            : REDMINE#23748の対応</br>
        ///// <returns></returns>
        //private int DeleteGoodsPriceUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region 条件により、商品マスタ（ユーザー登録分）を削除する;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " GOODSPRICEURF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //削除区分 = メーカー
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //            // 在庫品取扱い：②④在庫品時、商品／在庫どちらも削除しないと
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {

        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }
        //        //削除区分 = メーカー+中分類
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }
        //        //削除区分 =メーカー +  グループコード
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";

        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  " + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        # endregion
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            int i = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        //ADD by Liangsd  2011/08/19--------------->>>>>>>>>>>>>>
        //#region 掛率マスタ削除
        ///// <summary>
        ///// 掛率マスタ削除
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">データベース接続情報</param>
        ///// <param name="transaction">トランザクション情報</param>
        ///// <br>Programmer	: 梁森東</br>
        ///// <br>Date		: 2011/08/19</br>
        ///// <br>Update Note: 2011/08/19  連番2 梁森東</br>
        ///// <br>            : REDMINE#23820の対応</br>
        ///// <returns></returns>
        //private int DeleteRateUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region 条件により、商品マスタ（ユーザー登録分）を削除する;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " RATERF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        sqlText += " AND " + Environment.NewLine;//ADDby Liangsd     2011/08/19
        //        sqlText += " SECTIONCODERF= '00'";//ADDby Liangsd     2011/08/19
        //        //削除区分 = メーカー
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //            // 在庫品取扱い：②④在庫品時、商品／在庫どちらも削除しないと
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {

        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }
        //        //削除区分 = メーカー+中分類
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }
        //        //削除区分 =メーカー +  グループコード
        //        if (deleteConditionWork.DeleteCode == 2)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";

        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
        //            {
        //                sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  " + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        # endregion
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            int i = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        //ADD by Liangsd  2011/08/19---------------<<<<<<<<<<<<<<
        //#region 結合マスタ（ユーザー登録）削除
        ///// <summary>
        ///// 結合マスタ（ユーザー登録）削除
        ///// </summary>
        ///// <param name="deleteConditionWork"></param>
        ///// <param name="connection">データベース接続情報</param>
        ///// <param name="transaction">トランザクション情報</param>
        ///// <br>Programmer	: 梁森東</br>
        ///// <br>Date		: 2011/07/13</br>
        ///// <returns></returns>
        //private int DeleteJoinPartsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {
        //        # region 条件により、商品マスタ（ユーザー登録分）を削除する;
        //        string sqlText = string.Empty;
        //        sqlText += " DELETE " + Environment.NewLine;
        //        sqlText += " FROM " + Environment.NewLine;
        //        sqlText += " JOINPARTSURF " + Environment.NewLine;
        //        sqlText += " WHERE " + Environment.NewLine;
        //        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //        //削除区分 = メーカー
        //        if (deleteConditionWork.DeleteCode == 0)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " (JOINDESTMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " )";
        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.JoinDeleteCode == 2)
        //            {
        //                sqlText += "  AND  JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) )";
        //            }
        //        }

        //        //削除区分 = メーカー + グループコード
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) )";
                    
        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.JoinDeleteCode == 2)
        //            {
        //                sqlText += "  AND  JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) )";
        //            }
        //        }

        //        //削除区分 =メーカー +  中分類
        //        if (deleteConditionWork.DeleteCode == 1)
        //        {
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND " + Environment.NewLine;
        //            sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //            if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //            {
        //                sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //            }
        //            //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //            sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
        //            sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //            sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //            sqlText += " AND ( " + Environment.NewLine;
        //            if (deleteConditionWork.Code1 != 0)
        //            {
        //                sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code2 != 0)
        //            {
        //                sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code3 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += " OR  " + Environment.NewLine;
        //                }
        //            }
        //            if (deleteConditionWork.Code4 != 0)
        //            {
        //                sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //            }
        //            sqlText += " ) ) ) ) )";
        //            // 在庫品取扱い：②在庫品時、結合マスタを削除しない
        //            if (deleteConditionWork.JoinDeleteCode == 2)
        //            {
        //                sqlText += "  AND  ( JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                //DEL by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                //if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                //{
        //                //    sqlText += " AND " + Environment.NewLine;
        //                //    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                //}
        //                //DEL by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                sqlText += " GOODSNORF IN ( " + Environment.NewLine;
        //                sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND " + Environment.NewLine;
        //                sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
        //                sqlText += " AND  " + Environment.NewLine;
        //                //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
        //                if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
        //                {
        //                    sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
        //                    sqlText += " AND " + Environment.NewLine;
        //                }
        //                //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
        //                sqlText += "GOODSMGROUPRF IN (  " + Environment.NewLine;
        //                sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
        //                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
        //                sqlText += " AND ( " + Environment.NewLine;
        //                if (deleteConditionWork.Code1 != 0)
        //                {
        //                    sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
        //                    if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code2 != 0)
        //                {
        //                    sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
        //                    if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code3 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
        //                    if (deleteConditionWork.Code4 != 0)
        //                    {
        //                        sqlText += " OR  " + Environment.NewLine;
        //                    }
        //                }
        //                if (deleteConditionWork.Code4 != 0)
        //                {
        //                    sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
        //                }
        //                sqlText += " ) ) ) ) )";
        //            }
        //        }
        //        using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
        //        {
        //            deleteConditionWork.JoinDeleteCnt = command.ExecuteNonQuery();
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        # endregion
        //    }
        //    catch (SqlException ex)
        //    {
        //        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
        //        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
        //    }
        //    return status;
        //}
        //#endregion
        #endregion
        //DEL by Liangsd 2011/08/30------<<<<<<<<

        #region 在庫マスタ削除件数検索
        /// <summary>
        /// 在庫マスタ削除件数検索
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note: 2011/08/30  連番2 梁森東</br>
        /// <br>            : REDMINE#23820の対応</br>
        /// <returns></returns>
        private int SearchStockDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += " SELECT COUNT(*) " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " STOCKRF " + Environment.NewLine;
                sqlText += "  WHERE  " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //DEL by Liangsd 2011/08/30 ------------>>>>>>>>>>>>>
                //if (deleteConditionWork.DeleteCode == 0)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " )";
                //}
                //if (deleteConditionWork.DeleteCode == 1)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSNORF in ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " AND " + Environment.NewLine;
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //    }
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) )";
                //}
                //if (deleteConditionWork.DeleteCode == 2)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " AND " + Environment.NewLine;
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //    }
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMGROUPRF  IN (  " + Environment.NewLine;
                //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) )";
                //}
                //DEL by Liangsd 2011/08/30 ------------<<<<<<<<<<<<
                //ADD by Liangsd 2011/08/30 ------------>>>>>>>>>>>>
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) )";
                }
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) )";
                }
                //ADD by Liangsd 2011/08/30 ------------<<<<<<<<<<<<<<<
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        StockDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
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
        #endregion

        #region 商品マスタ削除件数検索
        /// <summary>
        /// 商品マスタ削除件数検索
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note: 2011/08/30  連番2 梁森東</br>
        /// <br>            : REDMINE#23820の対応</br>
        /// <returns></returns>
        private int SearchGoodsDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT COUNT( * )  " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " GOODSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //DEL by Liangsd 2011/08/30 ------------>>>>>>>>>>>>
                ////削除区分 = メーカー
                //if (deleteConditionWork.DeleteCode == 0)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " )";
                //}
                ////削除区分 = メーカー+中分類
                //if (deleteConditionWork.DeleteCode == 1)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) )";
                //}
                ////削除区分 =メーカー +  グループコード
                //if (deleteConditionWork.DeleteCode == 2)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) ) ) )";
                //}
                //DEL by Liangsd 2011/08/30 ------------<<<<<<<<<<<<
                //ADD by Liangsd 2011/08/30 ------------>>>>>>>>>>>>
                //削除区分 = メーカー
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                //削除区分 = メーカー+グループコード
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )";
                }
                //削除区分 =メーカー +  中分類
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";
                }
                //ADD by Liangsd 2011/08/30 ------------<<<<<<<<<<<<
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        GoodsDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
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
        #endregion

        #region 結合マスタ削除件数検索
        /// <summary>
        /// 結合マスタ削除件数検索
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/07/13</br>
        /// <br>Update Note: 2011/08/30  連番2 梁森東</br>
        /// <br>            : REDMINE#23820の対応</br>
        /// <returns></returns>
        private int SearchJoinDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += " SELECT COUNT( * ) " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " JOINPARTSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //削除区分 = メーカー
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (JOINDESTMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }

                ////削除区分 = メーカー +中分類
                //if (deleteConditionWork.DeleteCode == 1)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) )";
                //}

                ////削除区分 =メーカー +  グループコード
                //if (deleteConditionWork.DeleteCode == 2)
                //{
                //    sqlText += " AND " + Environment.NewLine;
                //    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSNORF FROM GOODSMNGRF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND " + Environment.NewLine;
                //    //ADD by Liangsd     2011/08/19------------->>>>>>>>>>>>
                //    if (deleteConditionWork.SectionCode != "00" && deleteConditionWork.SectionCode != "0")
                //    {
                //        sqlText += " SECTIONCODERF= " + deleteConditionWork.SectionCode + Environment.NewLine;
                //        sqlText += " AND " + Environment.NewLine;
                //    }
                //    //ADD by Liangsd     2011/08/19-------------<<<<<<<<<<<<
                //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    sqlText += " GOODSMGROUPRF IN ( " + Environment.NewLine;
                //    sqlText += " SELECT GOODSMGROUPRF FROM BLGROUPURF WHERE " + Environment.NewLine;
                //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //    sqlText += " AND ( " + Environment.NewLine;
                //    if (deleteConditionWork.Code1 != 0)
                //    {
                //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code2 != 0)
                //    {
                //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code3 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                //        if (deleteConditionWork.Code4 != 0)
                //        {
                //            sqlText += " OR  " + Environment.NewLine;
                //        }
                //    }
                //    if (deleteConditionWork.Code4 != 0)
                //    {
                //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                //    }
                //    sqlText += " ) ) ) ) )";
                //}
                //ADD by Liangsd 2011/08/30------>>>>>>>>
                //削除区分 = メーカー + グループコード
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";
                }
                 //削除区分 =メーカー +  中分類
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) ) )";
                }
                //ADD by Liangsd 2011/08/30------<<<<<<<<
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        JoinDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
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
        #endregion

        //ADD by Liangsd 2011/08/30------>>>>>>>>
        #region 商品マスタ削除
        /// <summary>
        /// 商品マスタ削除
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteGoodsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region 条件により、商品マスタ（ユーザー登録分）を削除する;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " GOODSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //削除区分 = メーカー
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    // 在庫品取扱い：②④在庫品時、商品／在庫どちらも削除しないと
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {

                        sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) )";
                    }
                }
                //削除区分 = メーカー+グループコード
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )";
                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  GOODSNORF  NOT IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += ") ) ) ) )";
                    }
                }
                //削除区分 =メーカー +  中分類
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";

                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) ) ) ) ) ) )";
                    }
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    deleteConditionWork.GoodsDeleteCnt = command.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region 価格マスタ削除
        /// <summary>
        /// 価格マスタ削除
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteGoodsPriceUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region 条件により、商品マスタ（ユーザー登録分）を削除する;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " GOODSPRICEURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //削除区分 = メーカー
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    // 在庫品取扱い：②④在庫品時、商品／在庫どちらも削除しないと
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {

                        sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) )";
                    }
                }
                //削除区分 = メーカー+グループコード
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) )";
                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  GOODSNORF  NOT IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += ") ) ) ) )";
                    }
                }
                //削除区分 =メーカー +  中分類
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) )";

                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    {
                        sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) ) ) ) ) ) )";
                    }
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    int i = command.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region 掛率マスタ削除
        /// <summary>
        /// 掛率マスタ削除
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/08/30</br>
        /// <br>Update Note : 2015/06/08 高騁</br>
        /// <br>管理番号    : 11100068-00 </br>
        /// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>     
        /// <returns></returns>
        private int DeleteRateUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region 条件により、商品マスタ（ユーザー登録分）を削除する;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " RATERF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 --->>>>>
                //sqlText += " AND " + Environment.NewLine;
                //sqlText += " SECTIONCODERF= '00'";
                // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---<<<<<
                //削除区分 = メーカー
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    //----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                    // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 --->>>>>
                    //if (deleteConditionWork.RateDeleteCode == 2) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    //{

                    //    sqlText += "  AND  GOODSNORF  NOT IN (" + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    //    if (deleteConditionWork.Code2 != 0)
                    //    {
                    //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    //    }
                    //    if (deleteConditionWork.Code3 != 0)
                    //    {
                    //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    //    }
                    //    if (deleteConditionWork.Code4 != 0)
                    //    {
                    //        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    //    }
                    //    sqlText += " ) )";
                    //}
                    // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---<<<<<
                }
                //削除区分 = メーカー+グループコード
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) )";// DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    sqlText += " ) ) ) )" + Environment.NewLine;
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) " + Environment.NewLine;
                    // 判断条件： BLコード
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )  " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;

                    sqlText += " ) ";
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<
                    /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    //----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                    // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 --->>>>>
                    //if (deleteConditionWork.RateDeleteCode == 2) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    //{
                    //    sqlText += "  AND  GOODSNORF  NOT IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND  " + Environment.NewLine;
                    //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND ( " + Environment.NewLine;
                    //    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND (" + Environment.NewLine;
                    //    if (deleteConditionWork.Code1 != 0)
                    //    {
                    //        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code2 != 0)
                    //    {
                    //        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code3 != 0)
                    //    {
                    //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    //        if (deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code4 != 0)
                    //    {
                    //        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    //    }
                    //    sqlText += ") ) ) ) )";
                    //}
                    // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---<<<<<
                }
                //削除区分 =メーカー +  中分類
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) ) ) ) )"; // DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    sqlText += " ) ) ) ) ) ) )" + Environment.NewLine;
                    // 判断条件： グループコード
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;
                    // 判断条件： BLコード
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;

                    sqlText += " ) ";
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<
                    /*----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.GoodsDeleteCode == 2 || deleteConditionWork.GoodsDeleteCode == 4)
                    //----- DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<*/
                    // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 --->>>>>
                    //if (deleteConditionWork.RateDeleteCode == 2) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    //{
                    //    sqlText += "  AND  ( GOODSNORF  NOT IN (" + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND  " + Environment.NewLine;
                    //    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND " + Environment.NewLine;
                    //    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    //    sqlText += " AND  " + Environment.NewLine;
                    //    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND ( " + Environment.NewLine;
                    //    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    //    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    //    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    //    sqlText += " AND ( " + Environment.NewLine;
                    //    if (deleteConditionWork.Code1 != 0)
                    //    {
                    //        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    //        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code2 != 0)
                    //    {
                    //        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    //        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code3 != 0)
                    //    {
                    //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    //        if (deleteConditionWork.Code4 != 0)
                    //        {
                    //            sqlText += " OR  " + Environment.NewLine;
                    //        }
                    //    }
                    //    if (deleteConditionWork.Code4 != 0)
                    //    {
                    //        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    //    }
                    //    sqlText += " ) ) ) ) ) ) )";
                    //}
                    // --- DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---<<<<<
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    int i = command.ExecuteNonQuery();
                    deleteConditionWork.RateDeleteCnt = i; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region 在庫マスタ削除
        /// <summary>
        ///    在庫マスタ削除
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteStockProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region 条件により、在庫マスタを削除する
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " STOCKRF " + Environment.NewLine;
                sqlText += "  WHERE  " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) )";
                }
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) )";
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    deleteConditionWork.StockDeleteCnt = command.ExecuteNonQuery();
                    //----- ADD START 松本 2015/01/28 ----->>>>>>
                    connection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                    connection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                    //----- ADD END 松本 2015/01/28 -----<<<<<<	
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        #region 結合マスタ（ユーザー登録）削除
        /// <summary>
        /// 結合マスタ（ユーザー登録）削除
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 梁森東</br>
        /// <br>Date		: 2011/08/30</br>
        /// <returns></returns>
        private int DeleteJoinPartsUProc(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                # region 条件により、商品マスタ（ユーザー登録分）を削除する;
                string sqlText = string.Empty;
                sqlText += " DELETE " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " JOINPARTSURF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //削除区分 = メーカー
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (JOINDESTMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR JOINDESTMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.JoinDeleteCode == 2)
                    {
                        sqlText += "  AND  JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) )";
                    }
                }

                //削除区分 = メーカー + グループコード
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) )";
                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.JoinDeleteCode == 2)
                    {
                        sqlText += "  AND  JOINDESTPARTSNORF  NOT IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND (" + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += ") ) ) ) )";
                    }
                }

                //削除区分 =メーカー +  中分類
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " JOINDESTMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " JOINDESTPARTSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND  " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += ") ) ) ) ) )";

                    // 在庫品取扱い：②在庫品時、結合マスタを削除しない
                    if (deleteConditionWork.JoinDeleteCode == 2)
                    {
                        sqlText += "  AND  ( JOINDESTPARTSNORF  NOT IN (" + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM STOCKRF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                        sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                        sqlText += " AND  " + Environment.NewLine;
                        sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                        sqlText += " AND ( " + Environment.NewLine;
                        if (deleteConditionWork.Code1 != 0)
                        {
                            sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                            if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code2 != 0)
                        {
                            sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                            if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code3 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                            if (deleteConditionWork.Code4 != 0)
                            {
                                sqlText += " OR  " + Environment.NewLine;
                            }
                        }
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                        }
                        sqlText += " ) ) ) ) ) ) )";
                    }
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    deleteConditionWork.JoinDeleteCnt = command.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                # endregion
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            return status;
        }
        #endregion

        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
        #region 掛率マスタ削除件数検索
        /// <summary>
        /// 掛率マスタ削除件数検索
        /// </summary>
        /// <param name="deleteConditionWork"></param>
        /// <param name="connection">データベース接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Programmer	: 高騁</br>
        /// <br>Date		: 2015/06/08</br>
        /// <br>            : REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>
        /// <returns></returns>
        private int SearchRateDelete(ref DeleteConditionWork deleteConditionWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += " SELECT COUNT( * ) " + Environment.NewLine;
                sqlText += " FROM " + Environment.NewLine;
                sqlText += " RATERF " + Environment.NewLine;
                sqlText += " WHERE " + Environment.NewLine;
                sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                //sqlText += " AND SECTIONCODERF= '00'"; // DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                //削除区分 = メーカー
                if (deleteConditionWork.DeleteCode == 0)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " (GOODSMAKERCDRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += " OR GOODSMAKERCDRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " )";
                }
                //削除区分 = メーカー + グループコード
                if (deleteConditionWork.DeleteCode == 2)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) )"; // DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    sqlText += " ) ) ) )" + Environment.NewLine;
                    // 判断条件：グループコード
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) " + Environment.NewLine;
                    // 判断条件： BLコード
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND (" + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "BLGROUPCODERF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " BLGROUPCODERF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  BLGROUPCODERF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) )  " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;
                    sqlText += " ) ";
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<
                }
                //削除区分 =メーカー +  中分類
                if (deleteConditionWork.DeleteCode == 1)
                {
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine; // ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    sqlText += " GOODSNORF IN ( " + Environment.NewLine;
                    sqlText += " SELECT GOODSNORF FROM GOODSURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND " + Environment.NewLine;
                    sqlText += " GOODSMAKERCDRF = " + deleteConditionWork.GoodsMakerCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    //sqlText += " ) ) ) ) ) ) )"; // DEL 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----->>>>>
                    sqlText += " ) ) ) ) ) ) )" +Environment.NewLine;
                    // 判断条件： グループコード
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;
                    // 判断条件： BLコード
                    sqlText += " OR " + Environment.NewLine;
                    sqlText += " ( " + Environment.NewLine;
                    sqlText += " BLGOODSCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    sqlText += " BLGROUPCODERF IN ( " + Environment.NewLine;
                    sqlText += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF= " + deleteConditionWork.EnterpriseCode + Environment.NewLine;
                    sqlText += " AND ( " + Environment.NewLine;
                    if (deleteConditionWork.Code1 != 0)
                    {
                        sqlText += "GOODSMGROUPRF = " + deleteConditionWork.Code1 + Environment.NewLine;
                        if (deleteConditionWork.Code2 != 0 || deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code2 != 0)
                    {
                        sqlText += " GOODSMGROUPRF = " + deleteConditionWork.Code2 + Environment.NewLine;
                        if (deleteConditionWork.Code3 != 0 || deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code3 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code3 + Environment.NewLine;
                        if (deleteConditionWork.Code4 != 0)
                        {
                            sqlText += " OR  " + Environment.NewLine;
                        }
                    }
                    if (deleteConditionWork.Code4 != 0)
                    {
                        sqlText += "  GOODSMGROUPRF = " + deleteConditionWork.Code4 + Environment.NewLine;
                    }
                    sqlText += " ) ) ) ) " + Environment.NewLine;
                    sqlText += " ) " + Environment.NewLine;

                    sqlText += " ) ";
                    // --- ADD 高騁 2015/08/20 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 -----<<<<<
                }
                using (SqlCommand command = new SqlCommand(sqlText, connection, transaction))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.Read())
                    {
                        RateDeleteCount = sdr.GetInt32(0);
                    }
                    sdr.Close();
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
        #endregion
        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<

        //ADD by Liangsd 2011/08/30------<<<<<<<<
    }
}
