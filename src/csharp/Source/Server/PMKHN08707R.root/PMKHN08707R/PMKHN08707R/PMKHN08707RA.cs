//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーンマスタ印刷
// プログラム概要   : キャンペーンマスタ印刷 リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/12  修正内容 : Redmine#22929 データの印刷順（ソート順）を変更の修正
//----------------------------------------------------------------------------//
using System;
using System.Collections;
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
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーンマスタ印刷 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーンマスタ印刷 リモートオブジェクトです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/12 譚洪 Redmine#22929 データの印刷順（ソート順）を変更の修正</br>
    /// </remarks>
    [Serializable]
    public class CampaignMasterWorkDB : RemoteDB, ICampaignMasterWorkDB
    {
        #region [Constructor]
        /// <summary>
        /// キャンペーンマスタ印刷 リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public CampaignMasterWorkDB()
            :
            base("PMKHN08709D", "Broadleaf.Application.Remoting.ParamData.CampaignMasterWork", "CAMPAIGNSTRF")
        {
        }
        #endregion Constructor

        #region [マスタ検索]

        #region [SearchForMasterType]
        /// <summary>
        /// 画面の発行タイプが「マスタリスト」の場合は、抽出条件に該当する、データを取得する。
        /// </summary>
        /// <param name="campaignMasterWork">検索結果</param>
        /// <param name="campaignMasterPrtWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された検索条件に該当する表示のリストを抽出します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SearchForMasterType(ref object campaignMasterWork, object campaignMasterPrtWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //初期化
            campaignMasterWork = null;

            try
            {
                //パラメータチェック
                if (campaignMasterPrtWork == null) return status;

                #region [パラメータのキャスト]
                //検索パラメータ
                CampaignMasterPrtWork _campaignMasterPrtWork = campaignMasterPrtWork as CampaignMasterPrtWork;
                ArrayList campaignMasterWorkArray = campaignMasterWork as ArrayList;
                if (campaignMasterWorkArray == null)
                {
                    campaignMasterWorkArray = new ArrayList();
                }
                #endregion

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Search実行
                #region

                // キャンペーン設定マスタデータ検索
                status = SearchForMasterTypeProc(ref campaignMasterWorkArray, _campaignMasterPrtWork, readMode, logicalMode, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //実行時エラー
                    throw new Exception("検索実行時エラー：Status=" + status.ToString());
                }
                #endregion

                //実行結果セット
                campaignMasterWork = campaignMasterWorkArray;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.SearchForMasterType Exception=" + ex.Message);
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

            return status;
        }
        #endregion  //[SearchForMasterType]

        #region [SearchForMasterTypeProc]
        /// <summary>
        /// 指定された検索条件に該当する表示データのリストを抽出します
        /// </summary>
        /// <param name="campaignMasterWorkArray">検索結果</param>
        /// <param name="campaignMasterPrt">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された検索条件に該当する表示データのリストを抽出します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int SearchForMasterTypeProc(ref ArrayList campaignMasterWorkArray, CampaignMasterPrtWork campaignMasterPrt, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = MakeMasterSelectString(ref sqlCommand, campaignMasterPrt, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
                
                while (myReader.Read())
                {
                    object retWork = CopyToResultWorkFromMasterReaderProc(ref myReader, campaignMasterPrt);
                    if (retWork != null)
                    {
                        campaignMasterWorkArray.Add(retWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;                        
                    }
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.SearchForMasterTypeProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
            }

            return status;
        }
        #endregion  //[SearchForMasterTypeProc]

        #region [CampaignMasterWork用 SELECT文]
        /// <summary>
        /// リスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>リスト抽出SELECT文</returns>
        /// <remarks>
        /// <br>Note       : リスト抽出クエリ作成。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public string MakeMasterSelectString(ref SqlCommand sqlCommand, object paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            CampaignMasterPrtWork _campaignMasterPrtWork = paramWork as CampaignMasterPrtWork;
            string selectTxt = "";

            // 対象テーブル
            #region [Select文作成]
            selectTxt += " SELECT " + Environment.NewLine;
            selectTxt += "  CAMPST.UPDATEDATETIMERF " + Environment.NewLine;        // キャンペーンコード
            selectTxt += " ,CAMPST.CAMPAIGNCODERF " + Environment.NewLine;        // キャンペーンコード
            selectTxt += " ,CAMPST.CAMPAIGNNAMERF " + Environment.NewLine;        // キャンペーンコード名称
            selectTxt += " ,CAMPST.CAMPAIGNOBJDIVRF " + Environment.NewLine;      // キャンペーン対象区分
            selectTxt += " ,CAMPST.APPLYSTADATERF " + Environment.NewLine;        // 適用開始日
            selectTxt += " ,CAMPST.APPLYENDDATERF " + Environment.NewLine;        // 適用終了日
            selectTxt += " ,CAMPST.CAMPEXECSECCODERF " + Environment.NewLine;     // キャンペーン実施拠点
            selectTxt += " ,SEC.SECTIONGUIDESNMRF " + Environment.NewLine;         // 拠点略称
            selectTxt += " ,CAMPLK.CUSTOMERCODERF " + Environment.NewLine;        // 得意先コード
            selectTxt += " ,CUS.CUSTOMERSNMRF " + Environment.NewLine;            // 得意先略称          
            selectTxt += " FROM CAMPAIGNSTRF AS CAMPST WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 拠点情報設定マスタ.拠点ガイド名称を取得する
            selectTxt += " LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
            selectTxt += " ON SEC.ENTERPRISECODERF = CAMPST.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND SEC.SECTIONCODERF = CAMPST.CAMPEXECSECCODERF " + Environment.NewLine;
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            // キャンペーン関連マスタ.得意先コードを取得する
            selectTxt += " LEFT JOIN CAMPAIGNLINKRF AS CAMPLK " + Environment.NewLine;
            selectTxt += " ON CAMPLK.ENTERPRISECODERF = CAMPST.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CAMPLK.CAMPAIGNCODERF = CAMPST.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += " AND CAMPLK.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += " AND CAMPST.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            // 得意先マスタ.得意先略称を取得する
            selectTxt += " LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
            selectTxt += " ON CUS.ENTERPRISECODERF = CAMPLK.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CUS.CUSTOMERCODERF = CAMPLK.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += " AND CUS.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //WHERE文の作成
            selectTxt += MakeMasterWhereString(ref sqlCommand, _campaignMasterPrtWork, logicalMode); 
           
            // ORDER BY
            selectTxt += " ORDER BY CAMPST.CAMPAIGNCODERF, CAMPLK.CUSTOMERCODERF " + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion

        #region [CampaignMasterWork用 WHERE文生成処理]
        /// <summary>
        /// CampaignMasterWork用 WHERE文生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>WHERE文</returns>
        /// <remarks>
        /// <br>Note       : WHERE文作成。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string MakeMasterWhereString(ref SqlCommand sqlCommand, CampaignMasterPrtWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " CAMPST.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            // 開始キャンペーンコード
            if (paramWork.CampaignCodeSt != 0)
            {
                retstring += " AND CAMPST.CAMPAIGNCODERF>=@FINDCAMPAIGNCODEST" + Environment.NewLine;
                SqlParameter paraCampaignCodeSt = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEST", SqlDbType.Int);
                paraCampaignCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeSt);
            }

            // 終了キャンペーンコード
            if (paramWork.CampaignCodeEd != 0)
            {
                retstring += " AND CAMPST.CAMPAIGNCODERF<=@FINDCAMPAIGNCODEED" + Environment.NewLine;
                SqlParameter paraCampaignCodeEd = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEED", SqlDbType.Int);
                paraCampaignCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeEd);
            }

            // 開始拠点
            if (!string.IsNullOrEmpty(paramWork.SectionCodeSt))
            {
                retstring += " AND CAMPST.CAMPEXECSECCODERF>=@FINDCAMPEXECSECCODEST" + Environment.NewLine;
                SqlParameter paraCampexecSecCodeSt = sqlCommand.Parameters.Add("@FINDCAMPEXECSECCODEST", SqlDbType.NChar);
                paraCampexecSecCodeSt.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeSt);
            }

            // 終了拠点
            if (!string.IsNullOrEmpty(paramWork.SectionCodeEd))
            {
                retstring += " AND CAMPST.CAMPEXECSECCODERF<=@FINDCAMPEXECSECCODEED" + Environment.NewLine;
                SqlParameter paraCampexecSecCodeEd = sqlCommand.Parameters.Add("@FINDCAMPEXECSECCODEED", SqlDbType.NChar);
                paraCampexecSecCodeEd.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeEd);
            }

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0))
            {
                retstring += " AND CAMPST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);
            }
            else
            {
                retstring += " AND CAMPST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)1);
            }
            #endregion

            return retstring;
        }
        #endregion

        #region [CampaignMasterWork処理]
        /// <summary>
        /// クラス格納処理 Reader → CampaignMasterWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索条件</param>
        /// <returns>抽出結果</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理 Reader → CampaignMasterWork。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignMasterWork CopyToResultWorkFromMasterReaderProc(ref SqlDataReader myReader, CampaignMasterPrtWork paramWork)
        {
            #region 抽出結果-値セット
            CampaignMasterWork resultWork = new CampaignMasterWork();
            resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
            resultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));     // キャンペーンコード
            resultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));    // キャンペーンコード名称
            resultWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNOBJDIVRF")); // キャンペーン対象区分
            resultWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));     // 適用開始日
            resultWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));     // 適用終了日
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPEXECSECCODERF"));  // キャンペーン実施拠点
            resultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF")); // 拠点略称
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));     // 得意先コード
            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));      // 得意先略称
            #endregion

            return resultWork;
        }
        #endregion

        #endregion  //マスタ検索

        #region [マスタ以外検索]

        #region [Search]
        /// <summary>
        /// 画面の発行タイプが「マスタリスト」以外の場合は、抽出条件に該当する、データを取得する。
        /// </summary>
        /// <param name="campaignMasterWork">検索結果</param>
        /// <param name="campaignMasterPrtWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された検索条件に該当する表示のリストを抽出します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(ref object campaignMasterWork, object campaignMasterPrtWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //初期化
            campaignMasterWork = null;

            try
            {
                //パラメータチェック
                if (campaignMasterPrtWork == null) return status;

                #region [パラメータのキャスト]
                //検索パラメータ
                CampaignMasterPrtWork _campaignMasterPrtWork = campaignMasterPrtWork as CampaignMasterPrtWork;
                ArrayList campaignMasterWorkArray = campaignMasterWork as ArrayList;
                if (campaignMasterWorkArray == null)
                {
                    campaignMasterWorkArray = new ArrayList();
                }
                #endregion

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Search実行
                #region                
                status = SearchProc(ref campaignMasterWorkArray, _campaignMasterPrtWork, readMode, logicalMode, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //実行時エラー
                    throw new Exception("検索実行時エラー：Status=" + status.ToString());
                }
                #endregion

                //実行結果セット
                campaignMasterWork = campaignMasterWorkArray;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.Search Exception=" + ex.Message);
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

            return status;
        }
        #endregion  //[SearchForMasterType]

        #region [SearchProc]
        /// <summary>
        /// 指定された検索条件に該当する表示データのリストを抽出します
        /// </summary>
        /// <param name="campaignMasterWorkArray">検索結果(売上データ)</param>
        /// <param name="campaignMasterPrt">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された検索条件に該当する表示データのリストを抽出します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int SearchProc(ref ArrayList campaignMasterWorkArray, CampaignMasterPrtWork campaignMasterPrt, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = MakeSelectString(ref sqlCommand, campaignMasterPrt, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
               
                while (myReader.Read())
                {
                    object retWork = CopyToResultWorkFromReaderProc(ref myReader, campaignMasterPrt);
                    if (retWork != null)
                    {
                        campaignMasterWorkArray.Add(retWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
            }

            return status;
        }
        #endregion  //[SearchRefProc]

        #region [CampaignMasterWork用 SELECT文]
        /// <summary>
        /// リスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>リスト抽出SELECT文</returns>
        /// <remarks>
        /// <br>Note       : リスト抽出クエリ作成。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 譚洪 Redmine#22929 データの印刷順（ソート順）を変更の修正</br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            CampaignMasterPrtWork _campaignMasterPrtWork = paramWork as CampaignMasterPrtWork;
            string selectTxt = "";

            // 対象テーブル
            #region [Select文作成]
            selectTxt += " SELECT " + Environment.NewLine;
            selectTxt += "    CAMPMNG.CREATEDATETIMERF " + Environment.NewLine;       // 作成日時
            selectTxt += "   ,CAMPMNG.UPDATEDATETIMERF " + Environment.NewLine;       // 更新日時
            selectTxt += "   ,CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;         // キャンペーンコード
            selectTxt += "   ,CAMPMNG.SECTIONCODERF " + Environment.NewLine;          // 拠点コード
            selectTxt += "   ,CAMPMNG.BLGOODSCODERF " + Environment.NewLine;          // BL商品コード
            selectTxt += "   ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;         // 商品メーカーコード
            selectTxt += "   ,CAMPMNG.GOODSNORF " + Environment.NewLine;              // 商品番号
            selectTxt += "   ,CAMPMNG.BLGROUPCODERF " + Environment.NewLine;          // BLグループコード
            selectTxt += "   ,CAMPMNG.SALESCODERF " + Environment.NewLine;            // 販売区分コード
            selectTxt += "   ,CAMPMNG.SALESPRICESETDIVRF " + Environment.NewLine;     // 売価設定区分
            selectTxt += "   ,CAMPMNG.CUSTOMERCODERF " + Environment.NewLine;         // 得意先コード
            selectTxt += "   ,CAMPMNG.PRICEFLRF " + Environment.NewLine;              // 価格（浮動）
            selectTxt += "   ,CAMPMNG.RATEVALRF " + Environment.NewLine;              // 掛率
            selectTxt += "   ,CAMPMNG.PRICESTARTDATERF " + Environment.NewLine;       // 価格開始日
            selectTxt += "   ,CAMPMNG.PRICEENDDATERF " + Environment.NewLine;         // 価格終了日
            selectTxt += "   ,CAMPMNG.DISCOUNTRATERF " + Environment.NewLine;         // 値引率
            selectTxt += "   ,CAMPST.CAMPAIGNNAMERF " + Environment.NewLine;          // キャンペーンコード名称
            selectTxt += "   ,CAMPST.APPLYSTADATERF " + Environment.NewLine;          // 適用開始日
            selectTxt += "   ,CAMPST.APPLYENDDATERF " + Environment.NewLine;          // 適用終了日
            selectTxt += "   ,SEC.SECTIONGUIDESNMRF " + Environment.NewLine;          // 拠点略称

            // 発行タイプ == 「メーカー＋ＢＬコード」|| 発行タイプ ==「ＢＬコード」
            if (_campaignMasterPrtWork.PrintType == 1 || _campaignMasterPrtWork.PrintType == 4)
            {
                selectTxt += "   ,BLGOODSCD.BLGOODSHALFNAMERF " + Environment.NewLine; // ＢＬコード名称（半角）
            }

            // 発行タイプ != 「ＢＬコード」&& 発行タイプ !=「販売区分」
            if (_campaignMasterPrtWork.PrintType != 4 && _campaignMasterPrtWork.PrintType != 5)
            {
                selectTxt += "   ,MAKER.MAKERKANANAMERF " + Environment.NewLine;          // メーカー名称（ｶﾅ） 
            }

            // 発行タイプ == 「メーカー＋品番」
            if (_campaignMasterPrtWork.PrintType == 0)
            {
                selectTxt += "   ,GOODS.GOODSNAMEKANARF " + Environment.NewLine;          // 商品名称（ｶﾅ） 
            }

            // 発行タイプ == 「メーカー＋グループコード」
            if (_campaignMasterPrtWork.PrintType == 2)
            {
                selectTxt += "   ,BLGROUP.BLGROUPKANANAMERF " + Environment.NewLine;      // グループコード名称（ｶﾅ） 
            }

            // 発行タイプ == 「販売区分」
            if (_campaignMasterPrtWork.PrintType == 5)
            {
                selectTxt += "   ,USERGD.GUIDENAMERF " + Environment.NewLine;         // ガイド名称
            }
            selectTxt += "   ,CUSTOMER.CUSTOMERSNMRF " + Environment.NewLine;         // 得意先略称
            selectTxt += " FROM CAMPAIGNMNGRF AS CAMPMNG WITH (READUNCOMMITTED) " + Environment.NewLine;
            // キャンペーン設定マスタ
            selectTxt += " LEFT JOIN CAMPAIGNSTRF AS CAMPST " + Environment.NewLine;
            selectTxt += " ON CAMPST.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CAMPST.CAMPAIGNCODERF = CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += " AND CAMPST.LOGICALDELETECODERF = 0 " + Environment.NewLine;            
            // 拠点情報設定マスタ
            selectTxt += " LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
            selectTxt += " ON SEC.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND SEC.SECTIONCODERF = CAMPMNG.SECTIONCODERF " + Environment.NewLine;
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // ＢＬ商品コードマスタ(ユーザー・提供)
            // 発行タイプ == 「メーカー＋ＢＬコード」|| 発行タイプ ==「ＢＬコード」
            if (_campaignMasterPrtWork.PrintType == 1 || _campaignMasterPrtWork.PrintType == 4)
            {
                selectTxt += " LEFT JOIN BLGOODSCDURF AS BLGOODSCD " + Environment.NewLine;
                selectTxt += " ON BLGOODSCD.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND BLGOODSCD.BLGOODSCODERF = CAMPMNG.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += " AND BLGOODSCD.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // メーカーマスタ（ユーザー・提供）
            // 発行タイプ != 「ＢＬコード」&& 発行タイプ !=「販売区分」
            if (_campaignMasterPrtWork.PrintType != 4 && _campaignMasterPrtWork.PrintType != 5)
            {
                selectTxt += " LEFT JOIN MAKERURF AS MAKER " + Environment.NewLine;
                selectTxt += " ON MAKER.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND MAKER.GOODSMAKERCDRF = CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " AND MAKER.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // 商品マスタ（ユーザー・提供）
            // 発行タイプ == 「メーカー＋品番」
            if (_campaignMasterPrtWork.PrintType == 0)
            {
                selectTxt += " LEFT JOIN GOODSURF AS GOODS " + Environment.NewLine;
                selectTxt += " ON GOODS.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSMAKERCDRF = CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSNORF = CAMPMNG.GOODSNORF " + Environment.NewLine;
                selectTxt += " AND GOODS.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // グループコードマスタ（ユーザー・提供）
            // 発行タイプ == 「メーカー＋グループコード」
            if (_campaignMasterPrtWork.PrintType == 2)
            {
                selectTxt += " LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine;
                selectTxt += " ON BLGROUP.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND BLGROUP.BLGROUPCODERF = CAMPMNG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += " AND BLGROUP.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // 得意先マスタ
            selectTxt += " LEFT JOIN CUSTOMERRF AS CUSTOMER " + Environment.NewLine;
            selectTxt += " ON CUSTOMER.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CUSTOMER.CUSTOMERCODERF = CAMPMNG.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += " AND CUSTOMER.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // ユーザーガイドマスタ
            // 発行タイプ == 「販売区分」
            if (_campaignMasterPrtWork.PrintType == 5)
            {
                selectTxt += " LEFT JOIN USERGDBDURF AS USERGD " + Environment.NewLine;
                selectTxt += " ON USERGD.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND USERGD.GUIDECODERF = CAMPMNG.SALESCODERF " + Environment.NewLine;
                selectTxt += " AND USERGD.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                selectTxt += " AND USERGD.USERGUIDEDIVCDRF = 71 " + Environment.NewLine;
            }

            //WHERE文の作成
            selectTxt += MakeWhereString(ref sqlCommand, _campaignMasterPrtWork, logicalMode);

            #region ORDER BY
            // キャンペーンコード
            selectTxt += " ORDER BY CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;
            if (_campaignMasterPrtWork.PrintType == 0)
            {
                // 品番、メーカー順
                selectTxt += " ,CAMPMNG.GOODSNORF " + Environment.NewLine;
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
            }
            else if (_campaignMasterPrtWork.PrintType == 1)
            {
                // ＢＬコード、メーカー順
                selectTxt += " ,CAMPMNG.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine; 
            }
            else if (_campaignMasterPrtWork.PrintType == 2)
            {
                // グループコード、メーカー順
                selectTxt += " ,CAMPMNG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine; 
            }
            else if (_campaignMasterPrtWork.PrintType == 3)
            {
                // メーカー順
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
            }
            else if (_campaignMasterPrtWork.PrintType == 4)
            {
                // ＢＬコード順
                selectTxt += " ,CAMPMNG.BLGOODSCODERF " + Environment.NewLine; 
            }
            else if (_campaignMasterPrtWork.PrintType == 5)
            {
                // 販売区分順
                selectTxt += " ,CAMPMNG.SALESCODERF " + Environment.NewLine; 
            }
            else
            {
                // 無し
            }

            selectTxt += " ,CAMPMNG.SECTIONCODERF ASC,  CAMPMNG.SALESPRICESETDIVRF DESC, CAMPMNG.CUSTOMERCODERF ASC " + Environment.NewLine;  // ADD 2011/07/12 

            #endregion
            #endregion

            return selectTxt;
        }
        #endregion

        #region [CampaignMasterWork用 WHERE文生成処理]
        /// <summary>
        /// CampaignMasterWork用 WHERE文生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>WHERE文</returns>
        /// <remarks>
        /// <br>Note       : WHERE文作成。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignMasterPrtWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " CAMPMNG.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            // 開始キャンペーンコード
            if (paramWork.CampaignCodeSt != 0)
            {
                retstring += " AND CAMPMNG.CAMPAIGNCODERF>=@FINDCAMPAIGNCODEST" + Environment.NewLine;
                SqlParameter paraCampaignCodeSt = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEST", SqlDbType.Int);
                paraCampaignCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeSt);
            }

            // 終了キャンペーンコード
            if (paramWork.CampaignCodeEd != 0)
            {
                retstring += " AND CAMPMNG.CAMPAIGNCODERF<=@FINDCAMPAIGNCODEED" + Environment.NewLine;
                SqlParameter paraCampaignCodeEd = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEED", SqlDbType.Int);
                paraCampaignCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeEd);
            }

            // 開始拠点
            if (!string.IsNullOrEmpty(paramWork.SectionCodeSt))
            {
                retstring += " AND CAMPMNG.SECTIONCODERF>=@FINDSECCODEST" + Environment.NewLine;
                SqlParameter paraSecCodeSt = sqlCommand.Parameters.Add("@FINDSECCODEST", SqlDbType.NChar);
                paraSecCodeSt.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeSt);
            }

            // 終了拠点
            if (!string.IsNullOrEmpty(paramWork.SectionCodeEd))
            {
                retstring += " AND CAMPMNG.SECTIONCODERF<=@FINDSECCODEED" + Environment.NewLine;
                SqlParameter paraSecCodeEd = sqlCommand.Parameters.Add("@FINDSECCODEED", SqlDbType.NChar);
                paraSecCodeEd.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeEd);
            }

            // 発行タイプ
            retstring += " AND CAMPMNG.CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
            SqlParameter paraCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
            paraCampaignSettingKind.Value = SqlDataMediator.SqlSetInt32(paramWork.PrintType + 1);


            // 発行タイプ != 「ＢＬコード」&& 発行タイプ !=「販売区分」
            if (paramWork.PrintType != 4 && paramWork.PrintType != 5)
            {
                // 開始メーカーコード
                if (paramWork.GoodsMakerCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.GOODSMAKERCDRF>=@FINDGOODSMAKERCDST" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCodeSt = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDST", SqlDbType.Int);
                    paraGoodsMakerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCodeSt);
                }

                // 終了メーカーコード
                if (paramWork.GoodsMakerCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.GOODSMAKERCDRF<=@FINDGOODSMAKERCDED" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCodeEd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDED", SqlDbType.Int);
                    paraGoodsMakerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCodeEd);
                }
            }

            // 発行タイプ == 「メーカー＋グループコード」
            if (paramWork.PrintType == 2)
            {
                // 開始グループコード
                if (paramWork.BLGroupCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.BLGROUPCODERF>=@FINDBLGROUPCODEST" + Environment.NewLine;
                    SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@FINDBLGROUPCODEST", SqlDbType.Int);
                    paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCodeSt);
                }

                // 終了グループコード
                if (paramWork.BLGroupCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.BLGROUPCODERF<=@FINDBLGROUPCODEED" + Environment.NewLine;
                    SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@FINDBLGROUPCODEED", SqlDbType.Int);
                    paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCodeEd);
                }
            }

            // 発行タイプ == 「メーカー＋ＢＬコード」|| 発行タイプ ==「ＢＬコード」
            if (paramWork.PrintType == 1 || paramWork.PrintType == 4)
            {
                // 開始ＢＬコード
                if (paramWork.BLGoodsCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.BLGOODSCODERF>=@FINDBLGOODSCODEST" + Environment.NewLine;
                    SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@FINDBLGOODSCODEST", SqlDbType.Int);
                    paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCodeSt);
                }

                // 終了ＢＬコード
                if (paramWork.BLGoodsCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.BLGOODSCODERF<=@FINDBLGOODSCODEED" + Environment.NewLine;
                    SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@FINDBLGOODSCODEED", SqlDbType.Int);
                    paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCodeEd);
                }
            }

            // 発行タイプ == 「販売区分」
            if (paramWork.PrintType == 5)
            {
                // 開始販売区分コード
                if (paramWork.SalesCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.SALESCODERF>=@FINDSALESCODEST" + Environment.NewLine;
                    SqlParameter paraSalesCodeSt = sqlCommand.Parameters.Add("@FINDSALESCODEST", SqlDbType.Int);
                    paraSalesCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesCodeSt);
                }

                // 終了販売区分コード
                if (paramWork.SalesCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.SALESCODERF<=@FINDSALESCODEED" + Environment.NewLine;
                    SqlParameter paraSalesCodeEd = sqlCommand.Parameters.Add("@FINDSALESCODEED", SqlDbType.Int);
                    paraSalesCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesCodeEd);
                }
            }

            // 発行タイプ == 「メーカー＋品番」
            if (paramWork.PrintType == 0)
            {
                // 開始品番
                if (!string.IsNullOrEmpty(paramWork.GoodsNoSt))
                {
                    retstring += " AND CAMPMNG.GOODSNORF>=@FINDGOODSNOST" + Environment.NewLine;
                    // SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.Int);// DEL 2011/05/10
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NChar);// ADD 2011/05/10
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNoSt);
                }

                // 終了品番
                if (!string.IsNullOrEmpty(paramWork.GoodsNoEd))
                {
                    retstring += " AND CAMPMNG.GOODSNORF<=@FINDGOODSNOED" + Environment.NewLine;
                    // SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.Int);// DEL 2011/05/10
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NChar);// ADD 2011/05/10
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNoEd);
                }

                // 売価額
                // 同じ
                if (paramWork.PriceFlDiv == 1)
                {
                    retstring += " AND CAMPMNG.PRICEFLRF=@FINDPRICEFL" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@FINDPRICEFL", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(paramWork.PriceFl);
                }
                // 以上
                else if (paramWork.PriceFlDiv == 2)
                {
                    retstring += " AND CAMPMNG.PRICEFLRF>=@FINDPRICEFL" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@FINDPRICEFL", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(paramWork.PriceFl);
                }
                // 以下
                else if (paramWork.PriceFlDiv == 3)
                {
                    retstring += " AND CAMPMNG.PRICEFLRF<=@FINDPRICEFL" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@FINDPRICEFL", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(paramWork.PriceFl);
                }
            }

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0))
            {
                retstring += " AND CAMPMNG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);
            }
            else
            {
                retstring += " AND CAMPMNG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)1);
            }

            // 売価率
            // 同じ
            if (paramWork.RateValDiv == 1)
            {
                retstring += " AND CAMPMNG.RATEVALRF=@FINDRATEVAL" + Environment.NewLine;
                SqlParameter paraRateVal = sqlCommand.Parameters.Add("@FINDRATEVAL", SqlDbType.Float);
                paraRateVal.Value = SqlDataMediator.SqlSetDouble(paramWork.RateVal);
            }
            // 以上
            else if (paramWork.RateValDiv == 2)
            {
                retstring += " AND CAMPMNG.RATEVALRF>=@FINDRATEVAL" + Environment.NewLine;
                SqlParameter paraRateVal = sqlCommand.Parameters.Add("@FINDRATEVAL", SqlDbType.Float);
                paraRateVal.Value = SqlDataMediator.SqlSetDouble(paramWork.RateVal);
            }
            // 以下
            else if (paramWork.RateValDiv == 3)
            {
                retstring += " AND CAMPMNG.RATEVALRF<=@FINDRATEVAL" + Environment.NewLine;
                SqlParameter paraRateVal = sqlCommand.Parameters.Add("@FINDRATEVAL", SqlDbType.Float);
                paraRateVal.Value = SqlDataMediator.SqlSetDouble(paramWork.RateVal);
            }

            // 売価率
            // 同じ
            if (paramWork.DiscountRateDiv == 1)
            {
                retstring += " AND CAMPMNG.DISCOUNTRATERF=@FINDDISCOUNTRATE" + Environment.NewLine;
                SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@FINDDISCOUNTRATE", SqlDbType.Float);
                paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(paramWork.DiscountRate);
            }
            // 以上
            else if (paramWork.DiscountRateDiv == 2)
            {
                retstring += " AND CAMPMNG.DISCOUNTRATERF>=@FINDDISCOUNTRATE" + Environment.NewLine;
                SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@FINDDISCOUNTRATE", SqlDbType.Float);
                paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(paramWork.DiscountRate);
            }
            // 以下
            else if (paramWork.DiscountRateDiv == 3)
            {
                retstring += " AND CAMPMNG.DISCOUNTRATERF<=@FINDDISCOUNTRATE" + Environment.NewLine;
                SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@FINDDISCOUNTRATE", SqlDbType.Float);
                paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(paramWork.DiscountRate);
            }
            
            #endregion

            return retstring;
        }
        #endregion

        #region [CampaignMasterWork処理]
        /// <summary>
        /// クラス格納処理 Reader → CampaignMasterWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索条件</param>
        /// <returns>抽出結果</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理 Reader → CampaignMasterWork。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignMasterWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, CampaignMasterPrtWork paramWork)
        {
            #region 抽出結果-値セット
            CampaignMasterWork resultWork = new CampaignMasterWork();
            if (paramWork.PrintType != 6)
            {
                resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                resultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//作成日時
            }
            resultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));     // キャンペーンコード
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));    // 拠点コード
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));     // 商品メーカーコード
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));     // 商品番号
            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));  // BLグループコード
            resultWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")); // 販売区分コード
            resultWork.SalesPriceSetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICESETDIVRF"));     // 売価設定区分
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));      // 得意先コード
            resultWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));      // 価格（浮動）
            resultWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));      // 掛率
            resultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));      // 価格開始日
            resultWork.PriceEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEENDDATERF"));      // 価格終了日
            resultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));      // キャンペーンコード名称
            resultWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));      // 適用開始日
            resultWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));      // 適用終了日
            resultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));      // 拠点略称
            resultWork.DiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISCOUNTRATERF"));      // 値引率
            // 発行タイプ == 「メーカー＋ＢＬコード」|| 発行タイプ ==「ＢＬコード」
            if (paramWork.PrintType == 1 || paramWork.PrintType == 4)
            {
                resultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));      // ＢＬコード名称（半角）
            }

            // 発行タイプ != 「ＢＬコード」&& 発行タイプ !=「販売区分」
            if (paramWork.PrintType != 4 && paramWork.PrintType != 5)
            {
                resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));      // メーカー名称（ｶﾅ）
            }

            // 発行タイプ == 「メーカー＋品番」
            if (paramWork.PrintType == 0)
            {
                resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));      // 商品名称（ｶﾅ）
            }

            // 発行タイプ == 「メーカー＋グループコード」
            if (paramWork.PrintType == 2)
            {
                resultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));      // グループコード名称（ｶﾅ）
            }

            // 発行タイプ == 「販売区分」
            if (paramWork.PrintType == 5)
            {
                resultWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));      // ガイド名称
            }

            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));      // 得意先略称   
            #endregion

            return resultWork;
        }
        #endregion

        #endregion  //マスタ以外検索
    }
}