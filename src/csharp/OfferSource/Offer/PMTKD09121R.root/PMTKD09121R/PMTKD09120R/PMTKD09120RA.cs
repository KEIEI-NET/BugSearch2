using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自動見積部品番号変換マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自動見積部品番号変換マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20073　西　毅</br>
    /// <br>Date       : 2012.05.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class AutoEstmPtNoChgDB : RemoteDB, IAutoEstmPtNoChgDB
    {
        /// <summary>
        /// 自動見積部品番号変換マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20073　西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        /// </remarks>
        public AutoEstmPtNoChgDB()
            :
            base("PMTKD09122D", "Broadleaf.Application.Remoting.ParamData.AutoEstmPtNoChgWork", "AUTOESTMPTNOCHGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の自動見積部品番号変換マスタ情報LISTを戻します
        /// </summary>
        /// <param name="AutoEstmPtNoChgWork">検索結果</param>
        /// <param name="paraAutoEstmPtNoChgWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動見積部品番号変換マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20073　西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        public int Search(out object autoEstmPtNoChgWork, object paraAutoEstmPtNoChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            autoEstmPtNoChgWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                return SearchAutoEstmPtNoChgProc(out autoEstmPtNoChgWork, paraAutoEstmPtNoChgWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoEstmPtNoChgDB.Search");
                autoEstmPtNoChgWork = new ArrayList();
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

        /// <summary>
        /// 指定された条件の自動見積部品番号変換マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objAutoEstmPtNoChgWork">検索結果</param>
        /// <param name="paraAutoEstmPtNoChgWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動見積部品番号変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20073　西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        public int SearchAutoEstmPtNoChgProc(out object objAutoEstmPtNoChgWork, object paraAutoEstmPtNoChgWork, ref SqlConnection sqlConnection)
        {
            AutoEstmPtNoChgWork autoEstmPtNoChgWork = null;

            ArrayList AutoEstmPtNoChgWorkList = paraAutoEstmPtNoChgWork as ArrayList;
            if (AutoEstmPtNoChgWorkList == null)
            {
                autoEstmPtNoChgWork = paraAutoEstmPtNoChgWork as AutoEstmPtNoChgWork;
            }
            else
            {
                if (AutoEstmPtNoChgWorkList.Count > 0)
                    autoEstmPtNoChgWork = AutoEstmPtNoChgWorkList[0] as AutoEstmPtNoChgWork;
            }

            int status = SearchAutoEstmPtNoChgProc(out AutoEstmPtNoChgWorkList, autoEstmPtNoChgWork, ref sqlConnection);
            objAutoEstmPtNoChgWork = AutoEstmPtNoChgWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の自動見積部品番号変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoEstmPtNoChgWorkList">検索結果</param>
        /// <param name="autoEstmPtNoChgWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動見積部品番号変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20073　西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        /// <br></br>
        public int SearchAutoEstmPtNoChgProc(out ArrayList autoEstmPtNoChgWorkList, AutoEstmPtNoChgWork autoEstmPtNoChgWork, ref SqlConnection sqlConnection)
        {
            return SearchAutoEstmPtNoChgProcProc(out autoEstmPtNoChgWorkList, autoEstmPtNoChgWork, ref sqlConnection);
        }

        private int SearchAutoEstmPtNoChgProcProc(out ArrayList autoEstmPtNoChgWorkList, AutoEstmPtNoChgWork autoEstmPtNoChgWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                string whereTxt = string.Empty;

                sqlTxt += " SELECT " + Environment.NewLine;
                sqlTxt += " OFFERDATERF " + Environment.NewLine;
                sqlTxt += " ,SHAREDSTCSUBPTSCDRF " + Environment.NewLine;
                sqlTxt += " ,PARTSPOSCODERF " + Environment.NewLine;
                sqlTxt += " ,AUTOESTIMATEPARTSCDRF " + Environment.NewLine;
                sqlTxt += " ,TBSPARTSCODERF " + Environment.NewLine;
                sqlTxt += " ,TBSPARTSCDDERIVEDNORF " + Environment.NewLine;
                sqlTxt += " ,NEWBLCODENAMERF " + Environment.NewLine;
                sqlTxt += " ,PARTSABBREVIATIONRF " + Environment.NewLine;
                sqlTxt += " ,COMPOMAINFLAGRF " + Environment.NewLine;
                sqlTxt += " ,DISPLAYORDERRF " + Environment.NewLine;
                sqlTxt += " ,PARTSPOSMAINFLAGRF " + Environment.NewLine;
                sqlTxt += "  FROM AUTOESTMPTNOCHGRF " + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                //共有在庫サブ部品コード
                if (autoEstmPtNoChgWork.SharedStcSubPtsCd != 0)
                {
                    whereTxt += " SHAREDSTCSUBPTSCDRF = @SHAREDSTCSUBPTSCD " + Environment.NewLine;
                    SqlParameter findSharedStcSubPtsCd = sqlCommand.Parameters.Add("@SHAREDSTCSUBPTSCD", SqlDbType.Int);  //共有在庫サブ部品コード
                    findSharedStcSubPtsCd.Value = SqlDataMediator.SqlSetInt32(autoEstmPtNoChgWork.SharedStcSubPtsCd);  //共有在庫サブ部品コード
                }

                //部位コード
                if (autoEstmPtNoChgWork.PartsPosCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " PARTSPOSCODERF = @PARTSPOSCODE " + Environment.NewLine;
                    SqlParameter findPartsPosCode = sqlCommand.Parameters.Add("@PARTSPOSCODE", SqlDbType.Int);  //部位コード
                    findPartsPosCode.Value = SqlDataMediator.SqlSetInt32(autoEstmPtNoChgWork.PartsPosCode);  //部位コード
                }

                //自動見積部品コード
                if (autoEstmPtNoChgWork.AutoEstimatePartsCd != "")
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " AUTOESTIMATEPARTSCDRF = @AUTOESTIMATEPARTSCD " + Environment.NewLine;
                    SqlParameter findAutoEstimatePartsCd = sqlCommand.Parameters.Add("@AUTOESTIMATEPARTSCD", SqlDbType.NVarChar);  //自動見積部品コード
                    findAutoEstimatePartsCd.Value = SqlDataMediator.SqlSetString(autoEstmPtNoChgWork.AutoEstimatePartsCd);  //自動見積部品コード
                }

                //翼部品コード
                if (autoEstmPtNoChgWork.TbsPartsCode != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " TBSPARTSCODERF = @TBSPARTSCODE " + Environment.NewLine;
                    SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);  //翼部品コード
                    findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(autoEstmPtNoChgWork.TbsPartsCode);  //翼部品コード
                }

                //翼部品コード枝番
                if (autoEstmPtNoChgWork.TbsPartsCdDerivedNo != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " TBSPARTSCDDERIVEDNORF = @TBSPARTSCDDERIVEDNO " + Environment.NewLine;
                    SqlParameter findTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);  //翼部品コード枝番
                    findTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(autoEstmPtNoChgWork.TbsPartsCdDerivedNo);  //翼部品コード枝番
                }

                //新BLコード品名
                if (autoEstmPtNoChgWork.NewBLCodeName != "")
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " NEWBLCODENAMERF = @NEWBLCODENAME " + Environment.NewLine;
                    SqlParameter findNewBLCodeName = sqlCommand.Parameters.Add("@NEWBLCODENAME", SqlDbType.NVarChar);  //新BLコード品名
                    findNewBLCodeName.Value = SqlDataMediator.SqlSetString(autoEstmPtNoChgWork.NewBLCodeName);  //新BLコード品名
                }

                //部品略称
                if (autoEstmPtNoChgWork.PartsAbbreviation != "")
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " PARTSABBREVIATIONRF = @PARTSABBREVIATION " + Environment.NewLine;
                    SqlParameter findPartsAbbreviation = sqlCommand.Parameters.Add("@PARTSABBREVIATION", SqlDbType.NVarChar);  //部品略称
                    findPartsAbbreviation.Value = SqlDataMediator.SqlSetString(autoEstmPtNoChgWork.PartsAbbreviation);  //部品略称
                }
                
                //構成メインフラグ
                if (autoEstmPtNoChgWork.CompoMainFlag != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " COMPOMAINFLAGRF = @COMPOMAINFLAG " + Environment.NewLine;
                    SqlParameter findCompoMainFlag = sqlCommand.Parameters.Add("@COMPOMAINFLAG", SqlDbType.Int);  //構成メインフラグ
                    findCompoMainFlag.Value = SqlDataMediator.SqlSetInt32(autoEstmPtNoChgWork.CompoMainFlag);  //構成メインフラグ
                }
                
                //表示順位
                if (autoEstmPtNoChgWork.DisplayOrder != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " DISPLAYORDERRF = @DISPLAYORDER " + Environment.NewLine;
                    SqlParameter findDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);  //表示順位
                    findDisplayOrder.Value = SqlDataMediator.SqlSetInt32(autoEstmPtNoChgWork.DisplayOrder);  //表示順位
                }

                //部位メインフラグ
                if (autoEstmPtNoChgWork.PartsPosMainFlag != 0)
                {
                    if (whereTxt != string.Empty)
                        whereTxt += " AND ";
                    whereTxt += " PARTSPOSMAINFLAGRF = @PARTSPOSMAINFLAG " + Environment.NewLine;
                    SqlParameter findPartsPosMainFlag = sqlCommand.Parameters.Add("@PARTSPOSMAINFLAG", SqlDbType.Int);  //部位メインフラグ
                    findPartsPosMainFlag.Value = SqlDataMediator.SqlSetInt32(autoEstmPtNoChgWork.PartsPosMainFlag);  //部位メインフラグ
                }


                if (whereTxt != string.Empty)
                {
                    sqlTxt += " WHERE " + Environment.NewLine;
                    sqlTxt += whereTxt + Environment.NewLine;
                }

                sqlTxt += " ORDER BY SHAREDSTCSUBPTSCDRF " + Environment.NewLine;
                sqlTxt += "         ,PARTSPOSCODERF " + Environment.NewLine;
                sqlTxt += "         ,AUTOESTIMATEPARTSCDRF " + Environment.NewLine;

                sqlCommand.CommandText = sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToAutoEstmPtNoChgWorkFromReader(ref myReader));
                }
                if (al.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            autoEstmPtNoChgWorkList = al;

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → AutoEstmPtNoChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AutoEstmPtNoChgWork</returns>
        /// <remarks>
        /// <br>Programmer : 20073　西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        /// </remarks>
        private AutoEstmPtNoChgWork CopyToAutoEstmPtNoChgWorkFromReader(ref SqlDataReader myReader)
        {
            AutoEstmPtNoChgWork wkAutoEstmPtNoChgWork = new AutoEstmPtNoChgWork();

            #region クラスへ格納
            wkAutoEstmPtNoChgWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // 提供日付
            wkAutoEstmPtNoChgWork.SharedStcSubPtsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHAREDSTCSUBPTSCDRF"));  //共有在庫サブ部品コード
            wkAutoEstmPtNoChgWork.PartsPosCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSPOSCODERF"));  //部位コード
            wkAutoEstmPtNoChgWork.AutoEstimatePartsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTOESTIMATEPARTSCDRF"));  //自動見積部品コード
            wkAutoEstmPtNoChgWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));  //翼部品コード
            wkAutoEstmPtNoChgWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));  //翼部品コード枝番
            wkAutoEstmPtNoChgWork.NewBLCodeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWBLCODENAMERF"));  //新BLコード品名
            wkAutoEstmPtNoChgWork.PartsAbbreviation = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSABBREVIATIONRF"));  //部品略称
            wkAutoEstmPtNoChgWork.CompoMainFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPOMAINFLAGRF"));  //構成メインフラグ
            wkAutoEstmPtNoChgWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));  //表示順位
            wkAutoEstmPtNoChgWork.PartsPosMainFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSPOSMAINFLAGRF"));  //部位メインフラグ
            #endregion

            return wkAutoEstmPtNoChgWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20073 西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            AutoEstmPtNoChgWork[] autoEstmPtNoChgWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is AutoEstmPtNoChgWork)
                    {
                        AutoEstmPtNoChgWork wkAutoEstmPtNoChgWork = paraobj as AutoEstmPtNoChgWork;
                        if (wkAutoEstmPtNoChgWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkAutoEstmPtNoChgWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            autoEstmPtNoChgWorkArray = (AutoEstmPtNoChgWork[])XmlByteSerializer.Deserialize(byteArray, typeof(AutoEstmPtNoChgWork[]));
                        }
                        catch (Exception) { }
                        if (autoEstmPtNoChgWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(autoEstmPtNoChgWorkArray);
                        }
                        else
                        {
                            try
                            {
                                AutoEstmPtNoChgWork wkAutoEstmPtNoChgWork = (AutoEstmPtNoChgWork)XmlByteSerializer.Deserialize(byteArray, typeof(AutoEstmPtNoChgWork));
                                if (wkAutoEstmPtNoChgWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkAutoEstmPtNoChgWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20073 西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
