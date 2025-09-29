//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括登録
// プログラム概要   : キャンペーン対象商品設定マスタ一括登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/13  修正内容 : Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正
//----------------------------------------------------------------------------//
using System.Data.SqlClient;
using System.Collections;
using System;
using System.Data;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///キャンペーン対象商品設定マスタ一括登録DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括登録の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
    /// </remarks>
    [Serializable]
    public class CampaignLoginDB : RemoteDB, ICampaignLoginDB
    {
        # region 検索処理
        /// <summary>
        /// 商品マスタ(ユーザー)検索処理
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">検索結果</param>
        /// <param name="campaignGoodsDataWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int Search(ref object campaignGoodsDataWorkList, object campaignGoodsDataWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignGoodsDataWork campaignGoodsDataWorks = campaignGoodsDataWork as CampaignGoodsDataWork;

            ArrayList campaignGoodsDataWorkLists = campaignGoodsDataWorkList as ArrayList;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchProc(ref campaignGoodsDataWorkLists, campaignGoodsDataWorks, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            campaignGoodsDataWorkList = campaignGoodsDataWorkLists as Object;

            return status;
        }

        /// <summary>
        /// 商品マスタ(ユーザー)検索処理
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">検索結果</param>
        /// <param name="campaignGoodsDataWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private int SearchProc(ref ArrayList campaignGoodsDataWorkList, CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT DISTINCT GOODSNORF," + Environment.NewLine;
                sqlText += "GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "FROM GOODSURF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "AND LOGICALDELETECODERF =@LOGICALDELETECODE" + Environment.NewLine;
                sqlText += "AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                if (campaignGoodsDataWork.GoodsNoNoneHyphen != "")
                {
                    sqlText += " AND REPLACE(GOODSNONONEHYPHENRF,'-','') LIKE REPLACE(@GOODSNO,'-','')" + Environment.NewLine;
                }
                // --- UPD 2011/07/13 --- >>>>>>>>
                if (campaignGoodsDataWork.BLGroupCodeSt != 0)
                {
                    sqlText += "AND BLGOODSCODERF=@BLGROUPCODEST" + Environment.NewLine;
                }
                //if (campaignGoodsDataWork.BLGroupCodeSt != 0)
                //{
                //    sqlText += "AND BLGOODSCODERF>=@BLGROUPCODEST" + Environment.NewLine;
                //}
                //if (campaignGoodsDataWork.BLGroupCodeEd != 0)
                //{
                //    sqlText += "AND BLGOODSCODERF<=@BLGROUPCODEED" + Environment.NewLine;
                //}
                // --- UPD 2011/07/13 --- <<<<<<<<<<
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                //SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);  // DEL 2011/07/13


                //Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.GoodsMakerCd);
                if (!string.Empty.Equals(campaignGoodsDataWork.GoodsNoNoneHyphen.Trim()))
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.GoodsNoNoneHyphen.Trim())+"%";
                }
                else
                {
                    paraGoodsNo.Value = campaignGoodsDataWork.GoodsNoNoneHyphen.Trim();
                }
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.BLGroupCodeSt);
                //paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.BLGroupCodeEd); // DEL 2011/07/13

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToGoodsUWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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
            campaignGoodsDataWorkList = al;


            return status;
        }

        /// <summary>
        /// キャンペーン管理マスタ検索処理
        /// </summary>
        /// <param name="campaignMngList">検索結果</param>
        /// <param name="campaignGoodsDataWork">検索条件</param>
        /// <param name="readMode">検索キャンペーン管理マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int Search(ref object campaignMngList, object campaignGoodsDataWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignGoodsDataWork campaignGoodsDataWorks = campaignGoodsDataWork as CampaignGoodsDataWork;

            ArrayList campaignMngLists = campaignMngList as ArrayList;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchProc(ref campaignMngLists, campaignGoodsDataWorks, readMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            campaignMngList = campaignMngLists;

            return status;
        }

        /// <summary>
        /// キャンペーン管理マスタ検索処理
        /// </summary>
        /// <param name="campaignMngLists">検索結果</param>
        /// <param name="campaignGoodsDataWorks">検索条件</param>
        /// <param name="readMode">検索キャンペーン管理マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int SearchProc(ref ArrayList campaignMngLists, CampaignGoodsDataWork campaignGoodsDataWorks, int readMode, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT  GOODSNORF," + Environment.NewLine;
                sqlText += "  LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sqlText += "AND CAMPAIGNSETTINGKINDRF=@CAMPAIGNSETTINGKIND" + Environment.NewLine;
                sqlText += "AND CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;

                # endregion

                //Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                SqlParameter paraCampaingnSettingKind = sqlCommand.Parameters.Add("@CAMPAIGNSETTINGKIND", SqlDbType.Int);
          
                //Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWorks.EnterpriseCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWorks.GoodsMakerCd);
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWorks.CampaignCode);
                paraCampaingnSettingKind.Value = SqlDataMediator.SqlSetInt32(1);

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignObjGoodsStWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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
            campaignMngLists = al;


            return status;
        }

        /// <summary>
        /// キャンペーン名称設定マスタ検索処理
        /// </summary>
        /// <param name="campaignStList">検索結果</param>
        /// <param name="campaignStWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン名称設定マスタ検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCampaignSt(ref object campaignStList, object campaignStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CampaignStWork campaignStWorks = campaignStWork as CampaignStWork;

            ArrayList campaignStLists = campaignStList as ArrayList;

            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchCampaignStProc(ref campaignStLists, campaignStWorks, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            campaignStList = campaignStLists;

            return status;
        }

        /// <summary>
        /// キャンペーン名称設定マスタ検索処理
        /// </summary>
        /// <param name="campaignStList">検索結果</param>
        /// <param name="campaignStWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン名称設定マスタ検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int SearchCampaignStProc(ref ArrayList campaignStList, CampaignStWork campaignStWork, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT CAMPAIGNNAMERF," + Environment.NewLine;
                sqlText += "CAMPEXECSECCODERF," + Environment.NewLine;
                sqlText += "CAMPAIGNOBJDIVRF," + Environment.NewLine;
                sqlText += "APPLYSTADATERF," + Environment.NewLine;
                sqlText += "APPLYENDDATERF" + Environment.NewLine;
                sqlText += "FROM CAMPAIGNSTRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "AND CAMPAIGNCODERF =@CAMPAIGNCODE" + Environment.NewLine;

                # endregion

                //Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignStWork.EnterpriseCode);
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignStWork.CampaignCode);

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignStWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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


            campaignStList = al;
            return status;
        }

        /// <summary>
        /// キャンペーン対象得意先設定マスタ検索処理
        /// </summary>
        /// <param name="searchParaObj">検索条件</param>
        /// <param name="objcampaignLinkList">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象得意先設定マスタ検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCustomer(object searchParaObj, ref object objcampaignLinkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CampaignLinkWork campaignLinkWork = searchParaObj as CampaignLinkWork;

            ArrayList campaignLinkList = objcampaignLinkList as ArrayList;

            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchCustomerProc(ref campaignLinkList, campaignLinkWork, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objcampaignLinkList = campaignLinkList;

            return status;
        }

        /// <summary>
        /// キャンペーン対象得意先設定マスタ検索処理
        /// </summary>
        /// <param name="campaignLinkList">検索結果</param>
        /// <param name="campaignLinkWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象得意先設定マスタ検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int SearchCustomerProc(ref ArrayList campaignLinkList, CampaignLinkWork campaignLinkWork, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "FROM CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText += "WHERE  CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;
                sqlText += "AND LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                sqlText += "AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);
  
             
                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignLinkWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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

            campaignLinkList = al;
            return status;
        }

        # endregion

        # region 登録処理
        /// <summary>
        /// キャンペーン管理マスタ、キャンペーン関連マスタ、キャンペーン設定マスタの登録処理
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">登録品物リスト</param>
        /// <param name="campaignGoodsDataWork">条件</param>
        /// <param name="campaignLinkobjlist">得意先リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録条件を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int Write(object campaignGoodsDataWorkList, object campaignGoodsDataWork, object campaignLinkobjlist)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            CampaignGoodsDataWork campaignGoodsDataWorks = campaignGoodsDataWork  as CampaignGoodsDataWork;
            ArrayList campaignGoodsDataWorkLists = campaignGoodsDataWorkList as ArrayList;
            ArrayList campaignLinkobjlists=campaignLinkobjlist as ArrayList;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = WriteProc(ref campaignGoodsDataWorkLists, campaignGoodsDataWorks, ref sqlConnection, ref sqlTransaction);

                //キャンペーン設定マスタの登録処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteCampaignSt(campaignGoodsDataWorks, ref sqlConnection, ref sqlTransaction);
                }

                //キャンペーン関連マスタの登録処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && campaignLinkobjlists.Count > 0)
                {
                    status = WriteCampaignLink(campaignLinkobjlists, campaignGoodsDataWorks,ref sqlConnection, ref sqlTransaction);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.Write", status);
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
        /// キャンペーン関連マスタの登録処理
        /// </summary>
        /// <param name="campaignLinkobjlist">得意先リスト</param>
        /// <param name="campaignGoodsDataWork">条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録条件を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int WriteCampaignLink(ArrayList campaignLinkobjlist, CampaignGoodsDataWork campaignGoodsDataWork,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList campaignLinkLog = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);


                //Prameterオブジェクトの作成
                SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter ParaCampaingnCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode1 = sqlCommand.Parameters.Add("@LOGICALDELETECODE1", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode2 = sqlCommand.Parameters.Add("@LOGICALDELETECODE2", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                ParaCampaingnCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraLogicalDeleteCode1.Value = SqlDataMediator.SqlSetInt32(1);
                paraLogicalDeleteCode2.Value = SqlDataMediator.SqlSetInt32(0);



                # region [SELECT文]

                string sqlText_SELECT = string.Empty;
                sqlText_SELECT += "SELECT  CUSTOMERCODERF" + Environment.NewLine;
                sqlText_SELECT += "FROM CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText_SELECT += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText_SELECT += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText_SELECT;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    campaignLinkLog.Add(this.CopyToCampaignLinkWorkFromReader(ref myReader));
                }

    
                if (!myReader.IsClosed) myReader.Close();

                # region [DELETE文]
                string sqlText_DELETELOG = string.Empty;
                sqlText_DELETELOG += "DELETE " + Environment.NewLine;
                sqlText_DELETELOG += "FROM CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText_DELETELOG += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText_DELETELOG += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText_DELETELOG;

                # endregion

                sqlCommand.ExecuteNonQuery();

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                SqlParameter paraInfoSendCode = sqlCommand.Parameters.Add("@INFOSENDCODE", SqlDbType.Int);

                foreach (CampaignLinkWork campaignLinkWork in campaignLinkobjlist)
                {
                    if (campaignLinkWork.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //Parameterオブジェクトへ値設定
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(0);
                    paraCustomerAgentCd.Value = "         ";
                    paraInfoSendCode.Value = SqlDataMediator.SqlSetInt32(0);
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignLinkWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);

                    # region [INSERT文]
                    string sqlText_INSERT = string.Empty;
                    sqlText_INSERT += "INSERT INTO CAMPAIGNLINKRF" + Environment.NewLine;
                    sqlText_INSERT += "  (CREATEDATETIMERF," + Environment.NewLine;
                    sqlText_INSERT += "   UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText_INSERT += "   ENTERPRISECODERF, " + Environment.NewLine;
                    sqlText_INSERT += "   FILEHEADERGUIDRF, " + Environment.NewLine;
                    sqlText_INSERT += "   UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText_INSERT += "   UPDASSEMBLYID1RF, " + Environment.NewLine;
                    sqlText_INSERT += "   UPDASSEMBLYID2RF, " + Environment.NewLine;
                    sqlText_INSERT += "   LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText_INSERT += "   CAMPAIGNCODERF," + Environment.NewLine;
                    sqlText_INSERT += "   CUSTOMERCODERF," + Environment.NewLine;
                    sqlText_INSERT += "   SALESAREACODERF," + Environment.NewLine;
                    sqlText_INSERT += "   CUSTOMERAGENTCDRF," + Environment.NewLine;
                    sqlText_INSERT += "   INFOSENDCODERF)" + Environment.NewLine;
                    sqlText_INSERT += "   VALUES (@CREATEDATETIME," + Environment.NewLine;
                    sqlText_INSERT += "   @UPDATEDATETIME," + Environment.NewLine;
                    sqlText_INSERT += "   @FINDENTERPRISECODE," + Environment.NewLine;
                    sqlText_INSERT += "   @FILEHEADERGUID," + Environment.NewLine;
                    sqlText_INSERT += "   @UPDEMPLOYEECODE, " + Environment.NewLine;
                    sqlText_INSERT += "   @UPDASSEMBLYID1, " + Environment.NewLine;
                    sqlText_INSERT += "   @UPDASSEMBLYID2, " + Environment.NewLine;
                    if(campaignLinkWork.LogicalDeleteCode == 1)
                    {
                        sqlText_INSERT += " @LOGICALDELETECODE1," + Environment.NewLine;
                    }
                    else
                    {
                        sqlText_INSERT += " @LOGICALDELETECODE2," + Environment.NewLine;
                    }
                    
                    sqlText_INSERT += "   @FINDCAMPAIGNCODE," + Environment.NewLine;
                    sqlText_INSERT += "   @CUSTOMERCODE," + Environment.NewLine;
                    sqlText_INSERT += "   @SALESAREACODE, " + Environment.NewLine;
                    sqlText_INSERT += "   @CUSTOMERAGENTCD," + Environment.NewLine;
                    sqlText_INSERT += "   @INFOSENDCODE) " + Environment.NewLine;
                    # endregion

                    sqlCommand.CommandText = sqlText_INSERT;

                     //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)campaignLinkWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignLinkWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.WriteProc", status);
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
        /// キャンペーン設定マスタの登録処理
        /// </summary>
        /// <param name="campaignGoodsDataWork">条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録条件を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int WriteCampaignSt(CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try{
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
            
                    # region [SELECT文]

                    string sqlText_SELECT = string.Empty;
                    sqlText_SELECT += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText_SELECT += "FROM CAMPAIGNSTRF" + Environment.NewLine;
                    sqlText_SELECT += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText_SELECT += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText_SELECT;
                    # endregion

                    SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter ParaCampaingnCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);

                    ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                    ParaCampaingnCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        # region [UPDATE文]
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNSTRF" + Environment.NewLine;
                        sqlText_UPDATE += "SET LOGICALDELETECODERF ='" + 0 + "'," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPEXECSECCODERF=@CAMPEXECSECCODE," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPAIGNCODERF=@FINDCAMPAIGNCODE," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPAIGNNAMERF=@CAMPAIGNNAMERF," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPAIGNOBJDIVRF=@CAMPAIGNOBJDIVRF," + Environment.NewLine;
                        sqlText_UPDATE += "APPLYSTADATERF=@APPLYSTADATERF," + Environment.NewLine;
                        sqlText_UPDATE += "APPLYENDDATERF=@APPLYENDDATERF" + Environment.NewLine;
                        sqlText_UPDATE += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText_UPDATE += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignGoodsDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    { 
                        # region [INSERT文]
                        string sqlText_INSERT = string.Empty;
                        sqlText_INSERT += "INSERT  INTO CAMPAIGNSTRF" + Environment.NewLine;
                        sqlText_INSERT += "  (CREATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   ENTERPRISECODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   FILEHEADERGUIDRF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDEMPLOYEECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID1RF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID2RF, " + Environment.NewLine;
                        sqlText_INSERT += "   LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPEXECSECCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNNAMERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNOBJDIVRF," + Environment.NewLine;
                        sqlText_INSERT += "   APPLYSTADATERF," + Environment.NewLine;
                        sqlText_INSERT += "   APPLYENDDATERF," + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETMONEYRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETPROFITRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETCOUNTRF)" + Environment.NewLine;
                        sqlText_INSERT += "   VALUES (@CREATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @FINDENTERPRISECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @FILEHEADERGUID," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDEMPLOYEECODE, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID1, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID2, " + Environment.NewLine;
                        sqlText_INSERT += "   @LOGICALDELETECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPEXECSECCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @FINDCAMPAIGNCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNNAMERF," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNOBJDIVRF," + Environment.NewLine;
                        sqlText_INSERT += "   @APPLYSTADATERF," + Environment.NewLine;
                        sqlText_INSERT += "   @APPLYENDDATERF," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETMONEY, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETPROFIT," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETCOUNT)" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_INSERT;
                        
                        # endregion
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignGoodsDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter ParaCampexEcsecCode = sqlCommand.Parameters.Add("@CAMPEXECSECCODE", SqlDbType.NChar);
                    SqlParameter ParaCampaingnName = sqlCommand.Parameters.Add("@CAMPAIGNNAMERF", SqlDbType.NChar);
                    SqlParameter ParaCampaingnObjDiv = sqlCommand.Parameters.Add("@CAMPAIGNOBJDIVRF", SqlDbType.Int);
                    SqlParameter ParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATERF", SqlDbType.NChar);
                    SqlParameter ParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATERF", SqlDbType.Int);
                    SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                    SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                    SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);
                
                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignGoodsDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignGoodsDataWork.UpdateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignGoodsDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.LogicalDeleteCode);
                    ParaCampexEcsecCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.SectionCode);
                    ParaCampaingnName.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.CampaignName);
                    ParaCampaingnObjDiv.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignObjDiv);
                    ParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.ApplyStaDate);
                    ParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.ApplyEndDate);
                    paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(0);
                    paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(0);
                    paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(0);
    
                    if (!myReader.IsClosed) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                  
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.WriteProc", status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// キャンペーン管理マスタの登録処理
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">登録品物リスト</param>
        /// <param name="campaignGoodsDataWork">条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録条件を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int WriteProc(ref ArrayList campaignGoodsDataWorkList, CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {

                foreach (GoodsUWork coodsUWork in campaignGoodsDataWorkList)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    if (coodsUWork.LogicalDeleteCode == 1)
                    {
                        # region [UPDATE文]
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNMNGRF" + Environment.NewLine;
                        sqlText_UPDATE += "    SET LOGICALDELETECODERF=@LOGICALDELETECODE," + Environment.NewLine;
                        sqlText_UPDATE += " SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                        sqlText_UPDATE += " WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCDRF " + Environment.NewLine;
                        sqlText_UPDATE += " AND GOODSNORF=@FINDGOODSNORF " + Environment.NewLine;
                        sqlText_UPDATE += " AND ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                        sqlText_UPDATE += " AND CAMPAIGNCODERF=@FINDCAMPAIGNCODERF " + Environment.NewLine;
                        sqlText_UPDATE += " AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKINDRF " + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)coodsUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);


                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter ParaEnterpriseCode1 = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                        SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                        SqlParameter ParaGoodsMarkerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.Int);
                        SqlParameter ParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NVarChar);
                        SqlParameter ParaCampaingnCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODERF", SqlDbType.Int);
                        SqlParameter ParaCampaingnSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKINDRF", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(coodsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(coodsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        ParaEnterpriseCode1.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                        ParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.SectionCode);
                        ParaGoodsMarkerCd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.GoodsMakerCd);
                        if (!string.Empty.Equals(coodsUWork.GoodsNo.Trim()))
                        {
                            ParaGoodsNo.Value = SqlDataMediator.SqlSetString(coodsUWork.GoodsNo);
                        }
                        else
                        {
                            ParaGoodsNo.Value = coodsUWork.GoodsNo;
                        }
                        ParaCampaingnCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);
                        ParaCampaingnSettingKind.Value = SqlDataMediator.SqlSetInt32(1);

                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        # region [INSERT文]
                        string sqlText_INSERT= string.Empty;
                        sqlText_INSERT += "  INSERT INTO CAMPAIGNMNGRF " + Environment.NewLine;
                        sqlText_INSERT += "  (CREATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   ENTERPRISECODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   FILEHEADERGUIDRF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDEMPLOYEECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID1RF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID2RF, " + Environment.NewLine;
                        sqlText_INSERT += "   LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   SECTIONCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   GOODSMGROUPRF, " + Environment.NewLine;
                        sqlText_INSERT += "   BLGOODSCODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   GOODSMAKERCDRF," + Environment.NewLine;
                        sqlText_INSERT += "   GOODSNORF," + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETMONEYRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETPROFITRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETCOUNTRF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   PRICEFLRF," + Environment.NewLine;
                        sqlText_INSERT += "   RATEVALRF," + Environment.NewLine;
                        sqlText_INSERT += "   BLGROUPCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   SALESCODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNSETTINGKINDRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESPRICESETDIVRF, " + Environment.NewLine;
                        sqlText_INSERT += "   CUSTOMERCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   PRICESTARTDATERF, " + Environment.NewLine;
                        sqlText_INSERT += "   PRICEENDDATERF, " + Environment.NewLine;
                        sqlText_INSERT += "   DISCOUNTRATERF) " + Environment.NewLine;
                        sqlText_INSERT += "   VALUES (@CREATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @ENTERPRISECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @FILEHEADERGUID," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDEMPLOYEECODE, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID1, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID2, " + Environment.NewLine;
                        sqlText_INSERT += "   @LOGICALDELETECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @SECTIONCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @GOODSMGROUP, " + Environment.NewLine;
                        sqlText_INSERT += "   @BLGOODSCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @GOODSMAKERCD, " + Environment.NewLine;
                        sqlText_INSERT += "   @GOODSNO, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETMONEY, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETPROFIT," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETCOUNT," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @PRICEFL," + Environment.NewLine;
                        sqlText_INSERT += "   @RATEVAL," + Environment.NewLine;
                        sqlText_INSERT += "   @BLGROUPCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNSETTINGKIND, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESPRICESETDIV, " + Environment.NewLine;
                        sqlText_INSERT += "   @CUSTOMERCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @PRICESTARTDATE," + Environment.NewLine;
                        sqlText_INSERT += "   @PRICEENDDATE," + Environment.NewLine;
                        sqlText_INSERT += "   @DISCOUNTRATE)" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_INSERT;
                       
                        # endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)coodsUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                        SqlParameter paraCampaignSettingKind = sqlCommand.Parameters.Add("@CAMPAIGNSETTINGKIND", SqlDbType.Int);
                        SqlParameter paraSalesPriceSetDiv = sqlCommand.Parameters.Add("@SALESPRICESETDIV", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                        SqlParameter paraPriceEndDate = sqlCommand.Parameters.Add("@PRICEENDDATE", SqlDbType.Int);
                        SqlParameter paraDisCountRate = sqlCommand.Parameters.Add("@DISCOUNTRATE", SqlDbType.Float);
                        
                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(coodsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(coodsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(coodsUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(coodsUWork.GoodsMakerCd);
                        if (!string.Empty.Equals(coodsUWork.GoodsNo.Trim()))
                        {
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(coodsUWork.GoodsNo);
                        }
                        else
                        {
                            paraGoodsNo.Value = coodsUWork.GoodsNo;
                        }
                        
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(0);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(0);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(0);
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(0);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(0);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraCampaignSettingKind.Value = SqlDataMediator.SqlSetInt32(1);
                        paraSalesPriceSetDiv.Value = SqlDataMediator.SqlSetInt32(0);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraPriceStartDate.Value = SqlDataMediator.SqlSetInt32(0);
                        paraPriceEndDate.Value = SqlDataMediator.SqlSetInt32(0);
                        paraDisCountRate.Value = SqlDataMediator.SqlSetDouble(0);

                        sqlCommand.ExecuteNonQuery();

                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.WriteProc", status);
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

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
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
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
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

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsUWork</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private GoodsUWork CopyToGoodsUWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUWork coodsUWork = new GoodsUWork();

            if (myReader != null && coodsUWork != null)
            {
                # region クラスへ格納
                coodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                coodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                # endregion
            }
            return coodsUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CampaignObjGoodsStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignObjGoodsStWork</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignObjGoodsStWork CopyToCampaignObjGoodsStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignObjGoodsStWork campaignObjGoodsStWork = new CampaignObjGoodsStWork();

            if (myReader != null && campaignObjGoodsStWork != null)
            {

                # region クラスへ格納

                 campaignObjGoodsStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                 campaignObjGoodsStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
             
                # endregion
            }
            return campaignObjGoodsStWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CampaignLinkWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignLinkWork</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignLinkWork CopyToCampaignLinkWorkFromReader(ref SqlDataReader myReader)
        {

            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            if (myReader != null && campaignLinkWork != null)
            {
                # region クラスへ格納

                 campaignLinkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                # endregion
            }
            return campaignLinkWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CampaignStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns></returns>
        /// <returns>CampaignStWork</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignStWork CopyToCampaignStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignStWork campaignStWork = new CampaignStWork();

            if (myReader != null && campaignStWork != null)
            {
                # region クラスへ格納

                 campaignStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPEXECSECCODERF"));  // 拠点コード
                 campaignStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));  // キャンペーン名称
                 campaignStWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNOBJDIVRF"));  // キャンペーン対象区分
                 campaignStWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));  // 適用開始日
                 campaignStWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));  // 適用終了日

                # endregion
            }
            return campaignStWork;
        }

        # endregion

        
    }
}