//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括削除
// プログラム概要   : キャンペーン対象商品設定マスタ一括削除
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/28  修正内容 : Redmine#23278 ユーザー先では発生しないが複数の企業が混載する営業デモ機などで発生するの対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ一括削除リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括削除の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: 2011/07/28 Redmine#23278 ユーザー先では発生しないが複数の企業が混載する営業デモ機などで発生するの対応</br>
    /// </remarks>
    [Serializable]
    public class CampaignGoodsStDB : RemoteDB, ICampaignGoodsStDB
    {
        # region 検索処理
        /// <summary>
        /// キャンペーン管理マスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="objCampaignMngStWorkList">検索結果</param>
        /// <param name="searchParaObj">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタのキー値が一致する、全てのキャンペーン管理マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(object searchParaObj, ref object objCampaignMngStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignGoodsDataWork campaignGoodsDataWork = (CampaignGoodsDataWork)searchParaObj;
            ArrayList campaignMngStWorkList = objCampaignMngStWorkList as ArrayList;

            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchProc(campaignGoodsDataWork, ref campaignMngStWorkList, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignGoodsStDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objCampaignMngStWorkList = campaignMngStWorkList;

            return status;
        }

        /// <summary>
        /// キャンペーン管理マスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="campaignMngStWorkList">検索結果</param>
        /// <param name="campaignGoodsDataWork">検索パラメータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタのキー値が一致する、全てのキャンペーン管理マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>Update Note: 2011/07/28 Redmine#23278 ユーザー先では発生しないが複数の企業が混載する営業デモ機などで発生するの対応</br>
        /// </remarks>
        private int SearchProc(CampaignGoodsDataWork campaignGoodsDataWork, ref ArrayList campaignMngStWorkList, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT文]
                sqlText += "SELECT CAMPAIGNMNGRF.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.GOODSNORF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.PRICEFLRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.RATEVALRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.DISCOUNTRATERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.PRICESTARTDATERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.PRICEENDDATERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNSTRF.CAMPAIGNNAMERF AS CAMPAIGNNAMERF" + Environment.NewLine;    // キャンペーンコード名称
                sqlText += "  ,SECINFOSETRF.SECTIONGUIDESNMRF AS SECTIONNAMERF" + Environment.NewLine;  // 拠点略称
                sqlText += "  ,MAKERURF.MAKERNAMERF AS GOODSMAKERNMRF" + Environment.NewLine;           // メーカー名称
                sqlText += "  ,GOODSURF.GOODSNAMERF AS GOODSNAMERF" + Environment.NewLine;              // 品名
                sqlText += "  ,CUSTOMERRF.CUSTOMERSNMRF AS CUSTOMERNAMERF" + Environment.NewLine;       // 得意先略称
                sqlText += "  ,CAMPAIGNMNGRF.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM";
                sqlText += "  CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  CAMPAIGNSTRF" + Environment.NewLine;  // キャンペーン設定マスタ
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=CAMPAIGNSTRF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.CAMPAIGNCODERF = CAMPAIGNSTRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSTRF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  SECINFOSETRF" + Environment.NewLine;  // 拠点情報設定マスタ
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=SECINFOSETRF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.SECTIONCODERF = SECINFOSETRF.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  AND SECINFOSETRF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  MAKERURF" + Environment.NewLine;      // メーカーマスタ
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=MAKERURF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND MAKERURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  GOODSURF" + Environment.NewLine;      // 商品マスタ
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.GOODSNORF = GOODSURF.GOODSNORF" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNMNGRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND GOODSURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  CUSTOMERRF" + Environment.NewLine;    // 得意先マスタ
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.CUSTOMERCODERF = CUSTOMERRF.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  AND CUSTOMERRF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "WHERE " + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
                if (!"00".Equals(campaignGoodsDataWork.SectionCode.Trim()))
                {
                    sqlText += "  AND CAMPAIGNMNGRF.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                if (campaignGoodsDataWork.HeaderGoodsNo.Trim() != "")
                {
                    sqlText += " AND REPLACE(CAMPAIGNMNGRF.GOODSNORF,'-','') LIKE REPLACE(@FINDHEADERGOODSNO,'-','')" + Environment.NewLine;
                }
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDHEADERGOODSNO", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;
                findParaSectionCode.Value = campaignGoodsDataWork.SectionCode;
                findParaGoodsMakerCd.Value = campaignGoodsDataWork.GoodsMakerCd;
                findParaCampaignSettingKind.Value = 1;
                findParaGoodsNo.Value = campaignGoodsDataWork.HeaderGoodsNo + "%";

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignMngStWorkFromReader(ref myReader));
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.SearchProc" + status);
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

            campaignMngStWorkList = al;

            return status;
        }
        # endregion

        #region 削除処理
        /// <summary>
        /// 一括削除処理
        /// </summary>
        /// <param name="deleteParaObj">削除条件と結果</param>
        /// <param name="campaignGoodsListobj">排他処理条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 一括削除処理を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int DeleteAll(object campaignGoodsListobj, ref object deleteParaObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList deleteParaList = deleteParaObj as ArrayList;

                CampaignGoodsDataWork campaignGoodsDataWork = new CampaignGoodsDataWork();
                if (deleteParaList != null && deleteParaList.Count > 0)
                {
                    campaignGoodsDataWork = (CampaignGoodsDataWork)deleteParaList[0];
                }
                else
                {
                    return status;
                }
                ArrayList campaignGoodsList = campaignGoodsListobj as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                // SqlTransaction生成処理
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // 一括削除処理
                status = DeleteAllProc(ref campaignGoodsDataWork, campaignGoodsList, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteAll", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteAll", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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
        /// 一括削除処理
        /// </summary>
        /// <param name="campaignGoodsDataWork">削除条件と結果</param>
        /// <param name="campaignGoodsList">排他処理処理</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 一括削除処理を行い。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteAllProc(ref CampaignGoodsDataWork campaignGoodsDataWork, ArrayList campaignGoodsList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int deleteCount = 0;
            SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            string str = "";
            int i = 0;
            int endvalue = campaignGoodsList.Count;
         
            try
            {
                foreach (CampaignMngStWork campaignMngStWorks in campaignGoodsList)
                {
                    i++;
                    if (i == endvalue)
                    {
                        str = str + campaignMngStWorks.CampaignCode.ToString("000000");
                    }
                    else
                    {
                        str = str + campaignMngStWorks.CampaignCode.ToString("000000") + ",";
                    }
                    
                    // キャンペーン管理マスタの削除処理
                    status = this.DeleteCampaignMng(ref campaignGoodsDataWork, campaignMngStWorks, ref deleteCount, ref sqlCommand, ref sqlConnection, ref sqlTransaction);
                    if (status != 0)
                    {
                        return status;
                    }
                }

                // キャンペーン設定マスタの整理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.DeleteCampaignSt(ref campaignGoodsDataWork, ref sqlConnection, ref sqlTransaction, str);
                }
                // キャンペーン関連マスタの整理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.DeleteCampaignLink(ref campaignGoodsDataWork, ref sqlConnection, ref sqlTransaction, str);
                }
                // キャンペーン目標マスタの整理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.DeleteCampaignTarget(ref campaignGoodsDataWork, ref sqlConnection, ref sqlTransaction, str);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteAllProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteAllProc" + status);
            }
            finally
            {

            }

            return status;
        }

        /// <summary>
        /// キャンペーン管理マスタの削除処理
        /// </summary>
        /// <param name="campaignGoodsDataWork">削除条件</param>
        /// <param name="campaignMngStWork">排他条件</param>
        /// <param name="deleteCount">削除件数</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタ情報を物理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignMng(ref CampaignGoodsDataWork campaignGoodsDataWork, CampaignMngStWork campaignMngStWork, ref int deleteCount, ref SqlCommand sqlCommand, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            
          
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;
                sqlText += "  AND PRICEENDDATERF=@FINDPRICEENDDATE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                SqlParameter findParaCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                SqlParameter findParaPriceEndDate = sqlCommand.Parameters.Add("@FINDPRICEENDDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;
                findParaSectionCode.Value = campaignMngStWork.SectionCode;
                findParaGoodsMakerCd.Value = campaignMngStWork.GoodsMakerCd;
                findParaCampaignSettingKind.Value = campaignMngStWork.CampaignSettingKind;
                findParaGoodsNo.Value = campaignMngStWork.GoodsNo;
                findParaCampaignCode.Value = campaignMngStWork.CampaignCode;
                findParaCampaignSettingKind.Value = campaignMngStWork.CampaignSettingKind;
                findParaCustomerCode.Value = campaignMngStWork.CustomerCode;
                findParaPriceStartDate.Value = campaignMngStWork.PriceStartDate;
                findParaPriceEndDate.Value = campaignMngStWork.PriceEndDate;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {

                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                    if (_updateDateTime != campaignMngStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    # region [DELETE文]
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  CAMPAIGNMNGRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "  AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;
                    sqlText += "  AND PRICEENDDATERF=@FINDPRICEENDDATE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    # endregion


                }
                else
                {
                    // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    return status;
                }
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();
                deleteCount++;
                

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignMng", sqlex.Number);
                deleteCount = 0;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignMng" + status);
                deleteCount = 0;
            }
            finally
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                campaignGoodsDataWork.GoodsStCount = deleteCount;
            }

            return status;
        }

        /// <summary>
        /// キャンペーン設定マスタの整理
        /// </summary>
        /// <param name="campaignGoodsDataWork">削除条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="str">CAMPAIGNCODE範囲</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン設定マスタ情報を整理します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignSt(ref CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string str)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [DELETE文]
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNSTRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CAMPAIGNSTRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSTRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  NOT IN (" + Environment.NewLine;
                sqlText += "    SELECT CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "    FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "    WHERE" + Environment.NewLine;
                sqlText += "       CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSTRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  IN (" + Environment.NewLine;
                sqlText += str + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;

                int deleteCount = sqlCommand.ExecuteNonQuery();
                campaignGoodsDataWork.NameStCount = deleteCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignSt", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignSt" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// キャンペーン関連マスタの整理
        /// </summary>
        /// <param name="campaignGoodsDataWork">削除条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="str">CAMPAIGNCODE範囲</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン関連マスタ情報を整理します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignLink(ref CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string str)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [DELETE文]
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CAMPAIGNLINKRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNLINKRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  NOT IN (" + Environment.NewLine;
                sqlText += "    SELECT CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "    FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "    WHERE" + Environment.NewLine;
                sqlText += "       CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNLINKRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  IN (" + Environment.NewLine;
                sqlText += str + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;

                int deleteCount = sqlCommand.ExecuteNonQuery();
                campaignGoodsDataWork.CustomStCount = deleteCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignLink", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignLink" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// キャンペーン目標マスタの整理
        /// </summary>
        /// <param name="campaignGoodsDataWork">削除条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="str">CAMPAIGNCODE範囲</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標マスタを整理します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignTarget(ref CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string str)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [DELETE文]
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNTARGETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CAMPAIGNTARGETRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNTARGETRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  NOT IN (" + Environment.NewLine;
                sqlText += "    SELECT CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "    FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "    WHERE" + Environment.NewLine;
                sqlText += "       CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNTARGETRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  IN (" + Environment.NewLine;
                sqlText += str + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;

                int deleteCount = sqlCommand.ExecuteNonQuery();
                campaignGoodsDataWork.TargetStCount = deleteCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignTarget", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignTarget" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CampaignMngStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignMngStWork</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignMngStWork CopyToCampaignMngStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignMngStWork campaignMngStWork = new CampaignMngStWork();

            if (myReader != null && campaignMngStWork != null)
            {
                # region クラスへ格納
                campaignMngStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
                campaignMngStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));
                campaignMngStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                campaignMngStWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONNAMERF"));
                campaignMngStWork.CampaignSettingKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNSETTINGKINDRF"));
                campaignMngStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                campaignMngStWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
                campaignMngStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                campaignMngStWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                campaignMngStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                campaignMngStWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                campaignMngStWork.DiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISCOUNTRATERF"));
                campaignMngStWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
                campaignMngStWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
                campaignMngStWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                campaignMngStWork.PriceEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEENDDATERF"));
                campaignMngStWork.SalesPriceSetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICESETDIVRF"));
                campaignMngStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));

                # endregion
            }
            return campaignMngStWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // トランザクションの生成(開始)
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            }

            return sqlTransaction;
        }
        #endregion
    }
}
