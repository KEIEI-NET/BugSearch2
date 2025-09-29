//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : chenyd
// 作 成 日  2012/04/09  修正内容 : 2012/05/24配信分、Redmine#29314           
//                                  タイムアウトエラーの対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン実績表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン実績表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/05/19</br>
    /// </remarks>
    [Serializable]
    public class CampaignRsltListResultDB : RemoteDB, ICampaignRsltListResultDB
    {
        #region [コンストラクタ]
        /// <summary>
        /// キャンペーン実績表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// <br>Update Note: 2012/04/09 chenyd</br>							
        /// <br>管理番号   ：10801804-00 2012/05/24配信分</br>							
        /// <br>             Redmine#29314　タイムアウトエラーの対応</br>
        /// </remarks>
        public CampaignRsltListResultDB()
            :
            base("PMKHN02059D", "Broadleaf.Application.Remoting.ParamData.CampaignstRsltListResultWork", "CAMPAIGNSTRSLTLISTRESULTRF")
        {
        }
        #endregion

        IMTtlCampaign mTtlCampaign;

        #region [Search]
        /// <summary>
        /// 指定された条件のキャンペーン実績データを戻します。
        /// </summary>
        /// <param name="campaignstRsltListSalesWork">検索結果1</param>
        /// <param name="campaignstRsltListTargetWork">検索結果2</param>
        /// <param name="campaignstRsltListPrtWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        public int Search(out object campaignstRsltListSalesWork, out object campaignstRsltListTargetWork, object campaignstRsltListPrtWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            campaignstRsltListSalesWork = null;
            campaignstRsltListTargetWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCampaignRsltListData(out campaignstRsltListSalesWork, out campaignstRsltListTargetWork, campaignstRsltListPrtWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignRsltListResultDB.Search");
                campaignstRsltListSalesWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }
        #endregion Search

        #region [SearchCampaignRsltListData]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCampaignstRsltListSalesWork">検索結果1</param>
        /// <param name="objCampaignstRsltListTargetWork">検索結果2</param>
        /// <param name="objCampaignstRsltListPrtWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        private int SearchCampaignRsltListData(out object objCampaignstRsltListSalesWork, out object objCampaignstRsltListTargetWork, object objCampaignstRsltListPrtWork, ref SqlConnection sqlConnection)
        {
            CampaignstRsltListPrtWork paramWork = null;

            ArrayList paramWorkList = objCampaignstRsltListPrtWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objCampaignstRsltListPrtWork as CampaignstRsltListPrtWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as CampaignstRsltListPrtWork;
            }

            ArrayList campaignRsltListSalesWorkList = null;
            ArrayList campaignRsltListTargetWorkList = null;

            switch (paramWork.TotalType)
            {
                case (int)TotalType.Goods:     // 商品別
                    mTtlCampaign = new MTtlCampaignGoods();
                    break;
                case (int)TotalType.Customer:  // 得意先別
                    mTtlCampaign = new MTtlCampaignCust();
                    break;
                case (int)TotalType.Employee:  // 担当者別
                    mTtlCampaign = new MTtlCampaignEmp();
                    break;
                case (int)TotalType.AcceptOdr: // 受注者別
                    mTtlCampaign = new MTtlCampaignAcp();
                    break;
                case (int)TotalType.Printer:   // 発行者別
                    mTtlCampaign = new MTtlCampaignPrt();
                    break;
                case (int)TotalType.Area:      // 地区別
                    mTtlCampaign = new MTtlCampaignArea();
                    break;
                case (int)TotalType.Sales:     // 販売区分別
                    mTtlCampaign = new MTtlCampaignGuide();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList campaignstWorkLst = new ArrayList();
            // 売上実績データを取込む
            status = SearchCampaignData(out campaignRsltListSalesWorkList, out campaignRsltListTargetWorkList, paramWork, ref sqlConnection);

            objCampaignstRsltListSalesWork = campaignRsltListSalesWorkList;
            objCampaignstRsltListTargetWork = campaignRsltListTargetWorkList;
            return status;
        }
        #endregion SearchCampaignRsltListData

        #region [SearchCampaignData]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignRsltListSalesWorkList">検索結果</param>
        /// <param name="campaignRsltListTargetWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        private int SearchCampaignData(out ArrayList campaignRsltListSalesWorkList, out ArrayList campaignRsltListTargetWorkList, CampaignstRsltListPrtWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList campaignSalesList = new ArrayList();
            ArrayList campaignTargetList = new ArrayList();
            try
            {
                // 売上データを取得する
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlCampaign.MakeSalesSelectString(ref sqlConnection, ref sqlCommand, paramWork);

                //タイムアウト時間の設定（秒）
                //sqlCommand.CommandTimeout = 600; // DEL 2012/04/09 chenyd for Redmine#29314
                sqlCommand.CommandTimeout = 3600;  // ADD 2012/04/09 chenyd for Redmine#29314

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    campaignSalesList.Add(mTtlCampaign.CopyToCampaignSalesWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                // 目標設定データを取得する
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlCampaign.MakeTargetSelectString(ref sqlCommand, paramWork);

                //タイムアウト時間の設定（秒）
                //sqlCommand.CommandTimeout = 600; // DEL 2012/04/09 chenyd for Redmine#29314
                sqlCommand.CommandTimeout = 3600; // ADD 2012/04/09 chenyd for Redmine#29314

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    campaignTargetList.Add(mTtlCampaign.CopyToCampaignTargetWorkFromReader(ref myReader, paramWork));

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
                base.WriteErrorLog(ex, "CampaignRsltListResultDB.SearchCampaignData");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            campaignRsltListSalesWorkList = campaignSalesList;
            campaignRsltListTargetWorkList = campaignTargetList;
            
            return status;
        }
        #endregion SearchCampaignData

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //コネクション生成処理
    }

}
