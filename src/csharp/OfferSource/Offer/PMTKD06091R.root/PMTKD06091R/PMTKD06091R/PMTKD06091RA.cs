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
//using Broadleaf.Xml.Serialization;
//using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 部品情報取得リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class ClgPrmPartsInfoSearchDB : RemoteDB, IClgPrmPartsInfoSearchDB
    {
        # region ＰＵＢＬＩＣ定義

        # region 提供品番検索 DBリモートオブジェクトクラスコンストラクタ
        /// <summary>
        ///　提供品番検索 DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        /// </remarks>
        public ClgPrmPartsInfoSearchDB()
            :
            base("PMTKD06093D", "Broadleaf.Application.Remoting.ClgPrmPartsInfoSearchDB", "PRIMEPARTSRF")
        {
        }
        # endregion

        # region 提供品番検索 DBリモートオブジェクト
        /// <summary>
        /// 提供品番検索 DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondList"></param>
        /// <param name="listOfrPartsRet"></param>
        /// <param name="listOfrPartsPriceRet"></param>
        /// <returns></returns>
        public int Search(ArrayList partsNoSearchCondList, out ArrayList listOfrPartsRet, out ArrayList listOfrPartsPriceRet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            listOfrPartsRet = new ArrayList();
            listOfrPartsPriceRet = new ArrayList();
            try
            {
                OfrPartsRetWork _ofrPartsRetWork;
                OfrPartsPriceRetWork _ofrPartsPriceRetWork;

                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // 各部品が純正か優良かわからないため、一括でなくそれぞれ処理する。
                foreach (PartsNoSearchCondWork searchCondition in partsNoSearchCondList)
                {
                    status = SearchOfferPrimeParts(searchCondition, out _ofrPartsRetWork, sqlConnection);
                    if (status == 0 && _ofrPartsRetWork != null)
                    {
                        status = SearchOfferPrimePartsPrice(searchCondition, out _ofrPartsPriceRetWork, sqlConnection);
                        listOfrPartsRet.Add(_ofrPartsRetWork);
                        listOfrPartsPriceRet.Add(_ofrPartsPriceRetWork);
                    }
                    else
                    {
                        status = SearchPtMkrPrice(searchCondition, out _ofrPartsRetWork, out _ofrPartsPriceRetWork, sqlConnection);
                        if (status == 0 && _ofrPartsRetWork != null)
                        {
                            listOfrPartsRet.Add(_ofrPartsRetWork);
                            listOfrPartsPriceRet.Add(_ofrPartsPriceRetWork);
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion

        # region 提供品番検索＜セットなし・結合なし＞ DBリモートオブジェクト
        /// <summary>
        /// 提供品番検索＜セット・結合なし＞ DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="offerPrimePartsRetWork"></param>
        /// <param name="offerPrimePartsPriceRet"></param>
        /// <param name="ptMkrPriceRetWork"></param>
        /// <returns></returns>
        public int Search(PartsNoSearchCondWork partsNoSearchCondWork, out ArrayList offerPrimePartsRetWork,
            out ArrayList offerPrimePartsPriceRet, out ArrayList ptMkrPriceRetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            offerPrimePartsRetWork = new ArrayList();
            offerPrimePartsPriceRet = new ArrayList();
            ptMkrPriceRetWork = new ArrayList();

            offerPrimePartsRetWork = null;
            ptMkrPriceRetWork = null;

            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //提供優良部品マスタ検索
                status = FuzzySearchOfferPrimeParts(partsNoSearchCondWork, out offerPrimePartsRetWork, out offerPrimePartsPriceRet, sqlConnection);
                if (status != 0)
                {
                    return status;
                }

                //提供純正部品情報検索
                status = FuzzySearchPtMkrPrice(partsNoSearchCondWork, out ptMkrPriceRetWork, sqlConnection);
                if (status != 0)
                {
                    return status;
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion

        # region 提供品番検索＜セットあり・結合あり＞ DBリモートオブジェクト
        /// <summary>
        /// 提供品番検索＜セットあり・結合あり＞ DBリモートオブジェクト
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="offerPrimePartsRetWork"></param>
        /// <param name="ptMkrPriceRetWork"></param>
        /// <param name="offerJoinPartsRetWork"></param>
        /// <param name="offerSetPartsRetWork"></param>
        /// <param name="opt">検索対象 1:提供結合情報検索　2:提供セット情報検索　3:両方検索</param>
        /// <returns></returns>
        public int Search(PartsNoSearchCondWork partsNoSearchCondWork,
                        out ArrayList offerPrimePartsRetWork,
                        out ArrayList ptMkrPriceRetWork,
                        out ArrayList offerJoinPartsRetWork,
                        out ArrayList offerSetPartsRetWork,
                        int opt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //入出力パラメーター設定
            ArrayList offerPrimePartsArray = new ArrayList();
            ArrayList offerPrimePartsPriceArray = new ArrayList();
            ArrayList ptMkrPriceArray = new ArrayList();
            
            ArrayList offerJoinPartsArray = new ArrayList();
            ArrayList offerSetPartsArray = new ArrayList();

            offerPrimePartsRetWork = null;
            ptMkrPriceRetWork = null;
            offerJoinPartsRetWork = null;
            offerSetPartsRetWork = null;

            PrimePartsInfDB primePartsInfDB = new PrimePartsInfDB();

            try
            {
                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //提供優良部品マスタ検索
                status = FuzzySearchOfferPrimeParts(partsNoSearchCondWork, out offerPrimePartsArray, out offerPrimePartsPriceArray,  sqlConnection);
                if (status != 0)
                {
                    return status;
                }

                //提供純正部品情報検索
                status = FuzzySearchPtMkrPrice(partsNoSearchCondWork, out ptMkrPriceArray, sqlConnection);
                if (status != 0)
                {
                    return status;
                }

                //提供結合情報検索
                if ((opt == 1) || (opt == 3))
                {
                    ArrayList inWork = new ArrayList();
                    foreach (OfrPartsRetWork InPara in ptMkrPriceArray)
                    {
                        OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                        ofrPartsCondWork.PrtsNo = InPara.PartsNoWithHyphen;
                        ofrPartsCondWork.MakerCode = InPara.MakerCode;
                        inWork.Add(ofrPartsCondWork);
                    }

                    if (inWork.Count > 0)
                    {
                        status = primePartsInfDB.SearchPrimePartsNo(inWork, out offerJoinPartsArray, sqlConnection, null);
                        if (status != 0)
                        {
                            return status;
                        }
                    }
                }

                //提供セット情報検索
                if ((opt == 2) || (opt == 3))
                {
                    ArrayList inWork = new ArrayList();
                    foreach (OfrPartsRetWork InPara in offerPrimePartsArray)
                    {
                        OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                        ofrPartsCondWork.PrtsNo = InPara.PartsNoWithHyphen;
                        ofrPartsCondWork.MakerCode = InPara.MakerCode;
                        inWork.Add(ofrPartsCondWork);
                    }

                    if (inWork.Count > 0)
                    {
                        status = primePartsInfDB.SearchSetParts(inWork, out offerSetPartsArray, sqlConnection, null);
                        if (status != 0)
                        {
                            return status;
                        }
                    }
                }

                //検索結果の設定
                offerPrimePartsRetWork = offerPrimePartsArray;
                ptMkrPriceRetWork = ptMkrPriceArray;
                offerJoinPartsRetWork = offerJoinPartsArray;
                offerSetPartsRetWork = offerSetPartsArray;
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        # endregion

        # endregion

        # region ＰＲＩＶＡＴＥ定義

        # region 提供純正部品情報検索
        /// <summary>
        /// 提供純正部品情報検索
        /// </summary>
        /// <param name="list"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPtMkrPrice(ArrayList list, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            //結果の初期化
            retWork = new ArrayList();

            if (list == null || list.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            try
            {
                selectstr = "SELECT ";
                selectstr += "PTMKRPRICERF.OFFERDATERF, ";
                selectstr += "PTMKRPRICERF.MAKERCODERF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNONONEHYPHENRF, ";
                selectstr += "PTMKRPRICERF.TBSPARTSCODERF, ";
                selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                // TODO : PTMKRPRICERF レイアウト変更待ち
                selectstr += "PTMKRPRICERF.PARTSPRICEREVCDRF, ";
                selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                selectstr += "PTMKRPRICERF.PARTSLAYERCDRF ";

                selectstr += "FROM PTMKRPRICERF "; // 部品価格マスタ
                selectstr += "WHERE ";//PTMKRPRICERF.PARTSINFOCTRLFLGRF = 0"; // 部品情報制御フラグコラムがなくなったため。

                foreach (PartsNoSearchCondWork cond in list)
                {
                    wherestr += "OR ( PTMKRPRICERF.MAKERCODERF = " + cond.MakerCode + " AND ";
                    wherestr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = '" + cond.PrtsNo + "' ) ";
                }
                wherestr = wherestr.Substring(2);

                // バインド変数にパラメータを設定
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfrPartsRetWork mf = new OfrPartsRetWork();
                    OfrPartsPriceRetWork mfPrice = new OfrPartsPriceRetWork();

                    mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    mf.PartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.PartsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PartsCode = 0; // 0 : 純正

                    mfPrice.PartsMakerCd = mf.MakerCode;
                    mfPrice.PrimePartsNoWithH = mf.PartsNoWithHyphen;
                    mfPrice.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mfPrice.NewPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mfPrice.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchPtMkrPrice Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// 提供純正部品情報検索
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <param name="retWork"></param>
        /// <param name="retPriceWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPtMkrPrice(PartsNoSearchCondWork searchCondition, out OfrPartsRetWork retWork,
                                    out OfrPartsPriceRetWork retPriceWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            //結果の初期化
            retWork = null;
            retPriceWork = null;

            try
            {
                selectstr = "SELECT ";
                selectstr += "PTMKRPRICERF.OFFERDATERF, ";
                selectstr += "PTMKRPRICERF.MAKERCODERF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNONONEHYPHENRF, ";
                selectstr += "PTMKRPRICERF.TBSPARTSCODERF, ";
                selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                // TODO : PTMKRPRICERF レイアウト変更待ち
                selectstr += "PTMKRPRICERF.PARTSPRICEREVCDRF, ";
                selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                selectstr += "PTMKRPRICERF.PARTSLAYERCDRF ";

                selectstr += "FROM PTMKRPRICERF "; // 部品価格マスタ
                selectstr += "WHERE ";

                wherestr += "PTMKRPRICERF.MAKERCODERF = " + searchCondition.MakerCode + " AND ";
                wherestr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF = '" + searchCondition.PrtsNo + "'";


                // バインド変数にパラメータを設定
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    OfrPartsRetWork mf = new OfrPartsRetWork();
                    OfrPartsPriceRetWork mfPrice = new OfrPartsPriceRetWork();

                    mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    mf.PartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.PartsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PartsCode = 0; // 0 : 純正

                    mfPrice.PartsMakerCd = mf.MakerCode;
                    mfPrice.PrimePartsNoWithH = mf.PartsNoWithHyphen;
                    mfPrice.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mfPrice.NewPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mfPrice.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    retWork = mf;
                    retPriceWork = mfPrice;
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchPtMkrPrice Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion

        # region 提供純正部品情報曖昧検索
        /// <summary>
        /// 提供純正部品情報曖昧検索
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int FuzzySearchPtMkrPrice(PartsNoSearchCondWork partsNoSearchCondWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string partsNoRF = string.Empty;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //結果の初期化
            retWork = new ArrayList();

            try
            {
                selectstr = "SELECT ";
                selectstr += "PTMKRPRICERF.OFFERDATERF, ";
                selectstr += "PTMKRPRICERF.MAKERCODERF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNONONEHYPHENRF, ";
                selectstr += "PTMKRPRICERF.TBSPARTSCODERF, ";
                selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                // TODO : PTMKRPRICERF レイアウト変更待ち
                selectstr += "PTMKRPRICERF.PARTSPRICEREVCDRF, ";
                selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                selectstr += "PTMKRPRICERF.PARTSLAYERCDRF ";

                selectstr += "FROM PTMKRPRICERF ";
                selectstr += "WHERE ";//PTMKRPRICERF.PARTSINFOCTRLFLGRF = 0"; // 部品情報制御フラグコラムがなくなったため。


                //メーカーコード
                if (partsNoSearchCondWork.MakerCode != 0)
                {
                    selectstr += "PTMKRPRICERF.MAKERCODERF = @MAKERCODERF ";
                }

                //品番：後方一致
                string prtsNoWithHyphen = partsNoSearchCondWork.PrtsNo;
                int len = prtsNoWithHyphen.Length;
                if (len <= 0)
                {
                    return (0);
                }

                //品番ハイフンあり
                if (prtsNoWithHyphen.IndexOf("-") != -1)
                {
                    partsNoRF = "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF";
                }
                //品番ハイフンなし
                else
                {
                    partsNoRF = "PTMKRPRICERF.NEWPRTSNONONEHYPHENRF";
                }

                if (prtsNoWithHyphen.EndsWith("*"))
                {
                    wherestr += " AND " + partsNoRF + " LIKE @NEWPRTSNOWITHHYPHENRF ";
                    prtsNoWithHyphen = prtsNoWithHyphen.Remove(len - 1) + "%";
                }
                //品番：完全一致
                else
                {
                    wherestr += " AND " + partsNoRF + " = @NEWPRTSNOWITHHYPHENRF ";
                }

                // バインド変数にパラメータを設定
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);
                if (partsNoSearchCondWork.MakerCode != 0)
                {
                    ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODERF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(partsNoSearchCondWork.MakerCode);
                }
                ((SqlParameter)sqlCommand.Parameters.Add("@NEWPRTSNOWITHHYPHENRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(prtsNoWithHyphen);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfrPartsRetWork mf = new OfrPartsRetWork();
                    OfrPartsPriceRetWork mfPrice = new OfrPartsPriceRetWork();

                    mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    mf.PartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    mf.PartsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PartsCode = 0; // 0 : 純正

                    mfPrice.OfferDate = mf.OfferDate;
                    mfPrice.PartsMakerCd = mf.MakerCode;
                    mfPrice.PrimePartsNoWithH = mf.PartsNoWithHyphen;
                    mfPrice.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mfPrice.NewPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    mfPrice.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchPtMkrPrice Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion

        # region 提供優良部品情報検索
        /// <summary> 
        /// 提供優良部品情報検索
        /// </summary>
        /// <param name="list"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchOfferPrimeParts(ArrayList list, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //結果の初期化
            retWork = new ArrayList();

            if (list == null || list.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            try
            {
                selectstr = "SELECT ";

                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";

                selectstr += "FROM PRIMEPARTSRF ";
                selectstr += "WHERE ";

                foreach (PartsNoSearchCondWork cond in list)
                {
                    wherestr += "OR ( PRIMEPARTSRF.PARTSMAKERCDRF = " + cond.MakerCode + " AND ";
                    wherestr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = '" + cond.PrtsNo + "' ) ";
                }
                wherestr = wherestr.Substring(2);

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfrPartsRetWork mf = new OfrPartsRetWork();

                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsCode = 1; // 1 : 優良

                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchOfferPrimeParts Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary> 
        /// 提供優良部品情報検索
        /// </summary>
        /// <param name="list"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchOfferPrimePartsPrice(ArrayList list, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //結果の初期化
            retWork = new ArrayList();

            if (list == null || list.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            try
            {
                selectstr = "SELECT ";

                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, ";
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += "FROM PRMPRTPRICERF ";
                selectstr += "WHERE ";

                foreach (PartsNoSearchCondWork cond in list)
                {
                    wherestr += "OR ( PRMPRTPRICERF.PARTSMAKERCDRF = " + cond.MakerCode + " AND ";
                    wherestr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = '" + cond.PrtsNo + "' ) ";
                }
                wherestr = wherestr.Substring(2);

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfrPartsPriceRetWork mf = new OfrPartsPriceRetWork();

                    mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    mf.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mf.NewPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    retWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchOfferPrimeParts Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary> 
        /// 提供優良部品情報検索
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchOfferPrimeParts(PartsNoSearchCondWork searchCondition, out OfrPartsRetWork retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //結果の初期化
            retWork = null;

            try
            {
                selectstr = "SELECT ";

                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";

                selectstr += "FROM PRIMEPARTSRF ";
                selectstr += "WHERE ";

                wherestr += "PRIMEPARTSRF.PARTSMAKERCDRF = " + searchCondition.MakerCode + " AND ";
                wherestr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = '" + searchCondition.PrtsNo + "'";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    OfrPartsRetWork mf = new OfrPartsRetWork();

                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));

                    mf.PartsCode = 1; // 1 : 優良
                    retWork = mf;
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchOfferPrimeParts Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        private int SearchOfferPrimePartsPrice(PartsNoSearchCondWork searchCondition, out OfrPartsPriceRetWork retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //結果の初期化
            retWork = null;

            try
            {
                selectstr = "SELECT ";

                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, ";
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += "FROM PRMPRTPRICERF ";
                selectstr += "WHERE ";

                wherestr += " PRMPRTPRICERF.PARTSMAKERCDRF = " + searchCondition.MakerCode + " AND ";
                wherestr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = '" + searchCondition.PrtsNo + "'";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    OfrPartsPriceRetWork mf = new OfrPartsPriceRetWork();

                    mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    mf.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mf.NewPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    retWork = mf;
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchOfferPrimePartsPrice Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion

        # region 提供優良部品情報曖昧検索
        /// <summary> 
        /// 提供優良部品情報曖昧検索
        /// </summary>
        /// <param name="partsNoSearchCondWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int FuzzySearchOfferPrimeParts(PartsNoSearchCondWork partsNoSearchCondWork, out ArrayList retWork, out ArrayList retPriceWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string partsNoRF = string.Empty;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //結果の初期化
            retWork = new ArrayList();
            retPriceWork = new ArrayList();

            try
            {
                selectstr = "SELECT ";

                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";

                selectstr += "FROM PRIMEPARTSRF ";
                selectstr += "WHERE ";

                //メーカーコード
                if (partsNoSearchCondWork.MakerCode != 0)
                {
                    selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF = @PARTSMAKERCDRF AND ";
                }

                //品番：後方一致
                string prtsNoWithHyphen = partsNoSearchCondWork.PrtsNo;
                int len = prtsNoWithHyphen.Length;
                if (len <= 0)
                {
                    return (0);
                }

                //品番ハイフンあり
                if (prtsNoWithHyphen.IndexOf("-") != -1)
                {
                    partsNoRF = "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF";
                }
                //品番ハイフンなし
                else
                {
                    partsNoRF = "PRIMEPARTSRF.PRIMEPARTSNONONEHRF";
                }

                if (prtsNoWithHyphen.EndsWith("*"))
                {
                    wherestr += partsNoRF + " LIKE @PRIMEPARTSNOWITHHRF ";
                    prtsNoWithHyphen = prtsNoWithHyphen.Remove(len - 1) + "%";
                }
                //品番：完全一致
                else
                {
                    wherestr += partsNoRF + " = @PRIMEPARTSNOWITHHRF ";
                }

                // バインド変数にパラメータを設定
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);
                if (partsNoSearchCondWork.MakerCode != 0)
                {
                    ((SqlParameter)sqlCommand.Parameters.Add("@PARTSMAKERCDRF", SqlDbType.Int)).Value = SqlDataMediator.SqlSetInt32(partsNoSearchCondWork.MakerCode);
                }
                ((SqlParameter)sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHHRF", SqlDbType.NChar)).Value = SqlDataMediator.SqlSetString(prtsNoWithHyphen);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfrPartsRetWork mf = new OfrPartsRetWork();

                    mf.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PartsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsCode = 1; // 1 : 純正

                    retWork.Add(mf);
                }

                selectstr = "SELECT ";

                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, ";
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += "FROM PRMPRTPRICERF ";
                selectstr += "WHERE ";
                sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfrPartsPriceRetWork mf = new OfrPartsPriceRetWork();

                    mf.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    mf.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mf.NewPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    retPriceWork.Add(mf);
                }
                if (retWork.Count > 0)
                {
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
                base.WriteErrorLog(ex, "ClgPrmPartsInfoSearchDB.SearchOfferPrimeParts Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        # endregion
        # endregion

    }

}
