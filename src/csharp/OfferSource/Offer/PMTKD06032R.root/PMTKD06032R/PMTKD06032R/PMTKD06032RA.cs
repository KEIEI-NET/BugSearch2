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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良ＢＬコード検索DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良ＢＬコード検索の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 代替の検索を修正</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/10/19</br>
    /// <br></br>
    /// <br>Update Note: 検索部品名称マスタの全メーカー用の対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/10/22</br>
    /// </remarks>
    [Serializable]
    public class OfferPrimeBlSearchDB : RemoteDB, IOfferPrimeBlSearchDB
    {
        #region << Private 定義 >>
        private string PrimeSearchSelect =
            //[単純に純正品に紐付く優良品を抽出]
            "SELECT DISTINCT "

            // 提供優良検索マスタ項目
            + "ORGPARTSNORF.PRMSETDTLNO2RF" // PRIMEKINDCODERF　種別コード
            // 2009/10/19 >>>
            //+ ",ORGPARTSNORF.PRIMEPARTSNORF"
            + ",ORGPARTSNORF.PRIMEOLDPARTSNORF as PRIMEPARTSNORF"
            // 2009/10/19 <<<
            + ",ORGPARTSNORF.PRMPARTSPROPERNORF"
            + ",ORGPARTSNORF.PARTSDISPORDERRF"
            + ",ORGPARTSNORF.SETPARTSFLGRF"
            + ",ORGPARTSNORF.PRIMEQTYRF"
            + ",ORGPARTSNORF.PRIMESPECIALNOTERF"
            + ",ORGPARTSNORF.STPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.EDPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.STPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.EDPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.OFFERDATERF"
            + ",ORGPARTSNORF.MODELGRADENMRF"
            + ",ORGPARTSNORF.BODYNAMERF"
            + ",ORGPARTSNORF.DOORCOUNTRF"
            + ",ORGPARTSNORF.ENGINEMODELNMRF"
            + ",ORGPARTSNORF.ENGINEDISPLACENMRF"
            + ",ORGPARTSNORF.EDIVNMRF"
            + ",ORGPARTSNORF.TRANSMISSIONNMRF"
            + ",ORGPARTSNORF.SHIFTNMRF"
            + ",ORGPARTSNORF.WHEELDRIVEMETHODNMRF"

            // 提供優良部品マスタ項目
            + ",PRIMEPARTSRF.GOODSMGROUPRF"
            + ",PRIMEPARTSRF.TBSPARTSCODERF"
            + ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF"
            + ",PRIMEPARTSRF.PRMSETDTLNO1RF" // セレクトコード
            + ",PRIMEPARTSRF.PARTSMAKERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNOWITHHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNONONEHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
            + ",PRIMEPARTSRF.PRIMEPARTSKANANMRF"
            + ",PRIMEPARTSRF.PARTSLAYERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
            + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
            + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF"
            + ",PRIMEPARTSRF.PRMPARTSILLUSTCRF "

            + ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF "
            + ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF "
            + ",SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD" // 2009/10/22 Add

            //ＪＯＩＮ項目
            + " FROM PRIMEPARTSRF INNER JOIN ORGPARTSNORF ON PRIMEPARTSRF.GOODSMGROUPRF = ORGPARTSNORF.GOODSMGROUPRF "
            + " AND PRIMEPARTSRF.TBSPARTSCODERF = ORGPARTSNORF.TBSPARTSCODERF "
            + " AND PRIMEPARTSRF.PRMSETDTLNO1RF = ORGPARTSNORF.PRMSETDTLNO1RF "
            + " AND PRIMEPARTSRF.PARTSMAKERCDRF = ORGPARTSNORF.PARTSMAKERCDRF "
            // 2009/10/19 >>>
            //+ " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = ORGPARTSNORF.PRIMEOLDPARTSNORF "// PRIMEOLDPARTSNORFがメイン
            + " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = ORGPARTSNORF.PRIMEPARTSNORF "// PRIMEOLDPARTSNORFがメイン
            // 2009/10/19 <<<
            + " LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
        // JOIN文がここで完了でないので後でメンテする際注意してください。これを使うのは1か所だけです。

        private string PrimeSearchSubstSelect =
            //[単純に純正品に紐付く優良品を抽出]
            "SELECT DISTINCT "
            // 提供優良検索マスタ項目
            + "ORGPARTSNORF.PRMSETDTLNO2RF" // PRIMEKINDCODERF　種別コード
            + ",ORGPARTSNORF.PRIMEPARTSNORF"
            //+ ",ORGPARTSNORF.PRMPARTSPROPERNORF"
            + ",ORGPARTSNORF.PARTSDISPORDERRF"
            + ",ORGPARTSNORF.SETPARTSFLGRF"
            + ",ORGPARTSNORF.PRIMEQTYRF"
            + ",ORGPARTSNORF.PRIMESPECIALNOTERF"
            + ",ORGPARTSNORF.STPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.EDPRODUCETYPEOFYEARRF"
            + ",ORGPARTSNORF.STPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.EDPRODUCEFRAMENORF"
            + ",ORGPARTSNORF.OFFERDATERF"

            // 提供優良部品マスタ項目
            + ",PRIMEPARTSRF.GOODSMGROUPRF"
            + ",PRIMEPARTSRF.TBSPARTSCODERF"
            + ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF"
            + ",PRIMEPARTSRF.PRMSETDTLNO1RF" // セレクトコード
            + ",PRIMEPARTSRF.PARTSMAKERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNOWITHHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNONONEHRF"
            + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
            + ",PRIMEPARTSRF.PRIMEPARTSKANANMRF"
            + ",PRIMEPARTSRF.PARTSLAYERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
            + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
            + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF"
            + ",PRIMEPARTSRF.PRMPARTSILLUSTCRF "

            + ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF "
            + ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF "
            + ",SEARCHPRTNMRF.CARMAKERCODERF AS SRCHPNMACQRCARMKRCD" // 2009/10/22 Add

            //ＪＯＩＮ項目
            + " FROM PRIMEPARTSRF INNER JOIN ORGPARTSNORF ON PRIMEPARTSRF.GOODSMGROUPRF = ORGPARTSNORF.GOODSMGROUPRF "
            + " AND PRIMEPARTSRF.TBSPARTSCODERF = ORGPARTSNORF.TBSPARTSCODERF "
            + " AND PRIMEPARTSRF.PRMSETDTLNO1RF = ORGPARTSNORF.PRMSETDTLNO1RF "
            + " AND PRIMEPARTSRF.PARTSMAKERCDRF = ORGPARTSNORF.PARTSMAKERCDRF "
            + " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = ORGPARTSNORF.PRIMEOLDPARTSNORF "// PRIMEOLDPARTSNORFがメイン
            + " LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
        // JOIN文がここで完了でないので後でメンテする際注意してください。これを使うのは1か所だけです。
        #endregion

        #region << コンストラクター >>
        /// <summary>
        ///　優良ＢＬコード検索DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        public OfferPrimeBlSearchDB()
            :
            base("PMTKD06034D", "Broadleaf.Application.Remoting.OfferPrimeBlSearchDB", "PRIMEPARTSRF")
        {
        }
        #endregion

        #region << Public　メソッド >>
        /// <summary>
        /// 優良ＢＬコード検索DBリモートオブジェクト
        /// </summary>
        /// <param name="offerPrimeBlSearchCondWork"></param>
        /// <param name="offerPrimeSearchRetWork"></param>
        /// <param name="offerPrimePriceRetWork"></param>
        /// <param name="offerSetPartsRetWork"></param>
        /// <param name="offerSetPartPrice"></param>
        /// <returns></returns>
        public int Search(OfferPrimeBlSearchCondWork offerPrimeBlSearchCondWork, out ArrayList offerPrimeSearchRetWork,
            out ArrayList offerPrimePriceRetWork, out ArrayList offerSetPartsRetWork, out ArrayList offerSetPartPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            offerPrimeSearchRetWork = new ArrayList();
            offerPrimePriceRetWork = new ArrayList();
            offerSetPartsRetWork = new ArrayList();
            offerSetPartPrice = new ArrayList();
            //入出力パラメーター設定
            SqlConnection sqlConnection = null;
            try
            {
                ArrayList _offerOldPrimeSearchRetWork = new ArrayList();

                //ＳＱＬ初期処理
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //優良ＢＬコード検索
                status = OfferPrimeBlSearch(offerPrimeBlSearchCondWork, ref offerPrimeSearchRetWork, sqlConnection);
                if (status != 0)
                {
                    return status;
                }

                //優良ＢＬコード検索＜代替検索用＞
                status = OfferPrimeBlSubstSearch(offerPrimeBlSearchCondWork.MakerCode, offerPrimeSearchRetWork, 
                    ref _offerOldPrimeSearchRetWork, sqlConnection);
                if (status != 0 && status != 4)
                {
                    return status;
                }
                offerPrimeSearchRetWork.AddRange(_offerOldPrimeSearchRetWork);

                status = GetOriginalPartsPrice(offerPrimeSearchRetWork, out offerPrimePriceRetWork, sqlConnection);

                //セットマスタ検索
                status = SearchSetParts(offerPrimeBlSearchCondWork.MakerCode, offerPrimeSearchRetWork, out offerSetPartsRetWork, sqlConnection);

                status = SearchSetPartsPrice(offerSetPartsRetWork, out offerSetPartPrice, sqlConnection);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return status;
        }

        // 不要
        ///// <summary>
        ///// 優良ＢＬコード検索DBリモートオブジェクト
        ///// </summary>
        ///// <param name="searchSetPartsCondWork"></param>
        ///// <param name="offerSetPartsRetWork"></param>
        ///// <returns></returns>
        //public int Search(ArrayList searchSetPartsCondWork, out ArrayList offerSetPartsRetWork)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlConnection sqlConnection = null;

        //    //入出力パラメーター設定
        //    offerSetPartsRetWork = null;
        //    try
        //    {
        //        ArrayList _offerSetPartsRetWork = new ArrayList();

        //        //ＳＱＬ初期処理
        //        SqlConnectionInfo sqlConnectioninfo = sqlConnectioninfo = new SqlConnectionInfo();
        //        string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
        //        if (string.IsNullOrEmpty(connectionText))
        //        {
        //            return 99;
        //        }
        //        sqlConnection = new SqlConnection(connectionText);
        //        sqlConnection.Open();

        //        //セットマスタ検索
        //        status = SearchSetParts(searchSetPartsCondWork, out _offerSetPartsRetWork, sqlConnection);
        //        if (status == 0)
        //        {
        //            offerSetPartsRetWork = _offerSetPartsRetWork;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.Search Exception = " + ex.Message);
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //    return status;
        //}

        #endregion

        #region << Private メソッド >>
        /// <summary>
        /// 優良ＢＬコード検索検索（ＢＬコード・装備名称指定）
        /// </summary>
        /// <param name="searchCond"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int OfferPrimeBlSearch(OfferPrimeBlSearchCondWork searchCond, ref ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr;
            SqlDataReader myReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(); //selectstr, sqlConnection);
                selectstr = PrimeSearchSelect;

                // 2009/10/22 >>>
                //selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", searchCond.MakerCode);
                selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF IN ({0},0)) ", searchCond.MakerCode);
                // 2009/10/22 <<<
                //ＷＨＥＲＥ項目
                selectstr += "WHERE ORGPARTSNORF.TBSPARTSCODERF = @TBSPARTSCODE ";
                selectstr += " AND  ORGPARTSNORF.MAKERCODERF = @MAKERCODE";
                selectstr += " AND  ORGPARTSNORF.MODELCODERF = @MODELCODE";
                selectstr += " AND  ORGPARTSNORF.MODELSUBCODERF = @MODELSUBCODE";
                selectstr += " AND  ORGPARTSNORF.SERIESMODELRF = @SERIESMODEL";
                // Prameterオブジェクトの作成
                ((SqlParameter)sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.TbsPartsCode);	//ＢＬコード
                ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.MakerCode);	//車メーカーコード
                ((SqlParameter)sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.ModelCode);	//車種コード
                ((SqlParameter)sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int)).Value =
                    SqlDataMediator.SqlSetInt(searchCond.ModelSubCode);	//車種サブコード
                ((SqlParameter)sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.VarChar)).Value =
                    SqlDataMediator.SqlSetString(searchCond.SeriesModel);	//シリーズ型式

                MakeWhereString(searchCond, ref selectstr);

                sqlCommand.CommandText = selectstr;
                sqlCommand.Connection = sqlConnection;

                myReader = sqlCommand.ExecuteReader();
                SetOfferPrimeSearchRetWork(myReader, retWork, 0);
                CompressPartsRec(ref retWork);
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
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.OfferPrimeBlSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 絞込条件作成
        /// </summary>
        /// <param name="searchCond"></param>
        /// <param name="selectstr"></param>
        private void MakeWhereString(OfferPrimeBlSearchCondWork searchCond, ref string selectstr)
        {
            if (searchCond.CategorySignModel.Count > 0)	    //型式（類別記号）
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.CategorySignModel.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.CATEGORYSIGNMODELRF = '" + searchCond.CategorySignModel[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.CATEGORYSIGNMODELRF = '' )";
            }

            if (searchCond.ProduceTypeOfYear != 0)  // 生産年式 - ユーザー入力の車両の生産年式がある場合
            {
                selectstr += " AND ( ORGPARTSNORF.STPRODUCETYPEOFYEARRF <= " + searchCond.ProduceTypeOfYear.ToString();
                selectstr += " AND ORGPARTSNORF.EDPRODUCETYPEOFYEARRF >= " + searchCond.ProduceTypeOfYear.ToString() + " ) ";
            }
            else // ユーザー入力がない場合、車の開始生産年式・終了生産年式で絞込
            {
                if (searchCond.StProduceTypeOfYear.Count > 0)	    //開始生産年式
                {
                    selectstr += " AND (";
                    for (int i = 0; i < searchCond.StProduceTypeOfYear.Count; i++)
                    {
                        selectstr += string.Format("((ORGPARTSNORF.STPRODUCETYPEOFYEARRF = 0 OR ORGPARTSNORF.STPRODUCETYPEOFYEARRF >= {0})"
                                , searchCond.StProduceTypeOfYear[i]);
                        selectstr += string.Format(" AND (ORGPARTSNORF.EDPRODUCETYPEOFYEARRF = 999999 OR ORGPARTSNORF.EDPRODUCETYPEOFYEARRF <= {0})) OR "
                                , searchCond.EdProduceTypeOfYear[i]);
                    }
                    selectstr = selectstr.Remove(selectstr.Length - 3) + ") ";
                }
            }

            if (searchCond.ProduceTypeOfYear != 0)  // 生産車台番号 - ユーザー入力の車両の生産車台番号がある場合
            {
                selectstr += " AND ( ORGPARTSNORF.STPRODUCETYPEOFYEARRF <= " + searchCond.ProduceTypeOfYear.ToString();
                selectstr += " AND ORGPARTSNORF.EDPRODUCETYPEOFYEARRF >= " + searchCond.ProduceTypeOfYear.ToString() + " ) ";
            }
            else // ユーザー入力がない場合、車の開始生産車台番号・終了生産車台番号で絞込
            {
                if (searchCond.StProduceFrameNo.Count > 0)	    //生産車台番号開始
                {
                    selectstr += " AND (";
                    for (int i = 0; i < searchCond.StProduceFrameNo.Count; i++)
                    {
                        selectstr += string.Format("((ORGPARTSNORF.STPRODUCEFRAMENORF = 0 OR ORGPARTSNORF.STPRODUCEFRAMENORF >= {0})"
                                , searchCond.StProduceFrameNo[i]);
                        selectstr += string.Format(" AND (ORGPARTSNORF.EDPRODUCEFRAMENORF = 99999999 OR ORGPARTSNORF.EDPRODUCEFRAMENORF <= {0})) OR "
                                , searchCond.EdProduceFrameNo[i]);

                        selectstr += " ORGPARTSNORF.STPRODUCEFRAMENORF >= " + searchCond.StProduceFrameNo[i].ToString() + " OR ";
                    }
                    selectstr = selectstr.Remove(selectstr.Length - 3) + ") ";
                }
            }

            if (searchCond.ModelGradeNm.Count > 0)	    //型式グレード名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.ModelGradeNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.MODELGRADENMRF = '" + searchCond.ModelGradeNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.MODELGRADENMRF = '' )";
            }

            if (searchCond.BodyName.Count > 0)	    //ボディー名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.BodyName.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.BODYNAMERF = '" + searchCond.BodyName[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.BODYNAMERF = '' )";
            }

            if (searchCond.DoorCount.Count > 0)	//ドア数
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.DoorCount.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.DOORCOUNTRF = " + searchCond.DoorCount[i].ToString() + " OR ";
                }
                selectstr += "ORGPARTSNORF.DOORCOUNTRF = 0 )";
            }

            if (searchCond.EngineModelNm.Count > 0)	//エンジン型式名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.EngineModelNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.ENGINEMODELNMRF = '" + searchCond.EngineModelNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.ENGINEMODELNMRF = '' )";
            }

            if (searchCond.EngineDisplaceNm.Count > 0)	//排気量名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.EngineDisplaceNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.ENGINEDISPLACENMRF = '" + searchCond.EngineDisplaceNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.ENGINEMODELNMRF = '' )";
            }

            if (searchCond.EDivNm.Count > 0)	//E区分名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.EDivNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.EDIVNMRF = '" + searchCond.EDivNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.ENGINEMODELNMRF = '' )";
            }

            if (searchCond.TransmissionNm.Count > 0)	//ミッション名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.TransmissionNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.TRANSMISSIONNMRF = '" + searchCond.TransmissionNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.TRANSMISSIONNMRF = '' )";
            }

            if (searchCond.ShiftNm.Count > 0)	//シフト名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.ShiftNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.SHIFTNMRF = '" + searchCond.ShiftNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.SHIFTNMRF = '' )";
            }

            if (searchCond.WheelDriveMethodNm.Count > 0)	//駆動方式名称
            {
                selectstr += " AND (";
                for (int i = 0; i < searchCond.WheelDriveMethodNm.Count; i++)
                {
                    selectstr += " ORGPARTSNORF.WHEELDRIVEMETHODNMRF = '" + searchCond.WheelDriveMethodNm[i] + "' OR ";
                }
                selectstr += "ORGPARTSNORF.WHEELDRIVEMETHODNMRF = '' )";
            }
        }

        /// <summary>
        /// 優良ＢＬコード＜優良代替品番専用＞検索（ＢＬコード）
        /// </summary>
        /// <param name="carMakerCd">車メーカーコード（検索品名検索用）</param>
        /// <param name="lstSubstSrc">代替検索条件リスト</param>
        /// <param name="retWork">結果リスト</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int OfferPrimeBlSubstSearch(int carMakerCd, ArrayList lstSubstSrc, ref ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = PrimeSearchSubstSelect;
            string wherestr;
            SqlDataReader myReader = null;
            //ArrayList listWork = new ArrayList();
            //listWork.AddRange(lstSubstSrc);
            List<SubstChkKey> lst = new List<SubstChkKey>();

            try
            {
                // 2009/10/22 >>>
                //selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF IN ({0},0)) ", carMakerCd);
                // 2009/10/22 <<<
                foreach (OfferPrimeSearchRetWork ofrPrime in lstSubstSrc)
                {
                    // 2009/10/19 >>>
                    //if (ofrPrime.PrimePartsNo.Equals(string.Empty)) // 新部品がないと処理しない。
                    //    continue;
                    if (ofrPrime.PrimePartsNoWithH.Equals(string.Empty)) // 新部品がないと処理しない。
                        continue;
                    // 2009/10/19 <<<
                    SubstChkKey key = new SubstChkKey(ofrPrime.GoodsMGroup, ofrPrime.PartsMakerCd, ofrPrime.PrimePartsNoWithH);
                    if (lst.Contains(key))
                        continue;
                    lst.Add(key);

                    ArrayList tmpWork = new ArrayList();
                    wherestr = " WHERE PRIMEPARTSRF.PARTSMAKERCDRF = @PARTSMAKERCD";
                    wherestr += " AND PRIMEPARTSRF.TBSPARTSCODERF = @TBSPARTSCODE";
                    wherestr += " AND PRIMEPARTSRF.GOODSMGROUPRF = @GOODSMGROUP";
                    // 2009/10/19 >>>
                    //wherestr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = @PRIMEPARTSNOWITHH";
                    wherestr += " AND ORGPARTSNORF.PRIMEPARTSNORF = @PRIMEPARTSNOWITHH";
                    // 2009/10/19 <<<

                    SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                    // Prameterオブジェクトの作成
                    ((SqlParameter)sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int)).Value =
                        SqlDataMediator.SqlSetInt(ofrPrime.PartsMakerCd);	//部品メーカーコード
                    ((SqlParameter)sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int)).Value =
                        SqlDataMediator.SqlSetInt(ofrPrime.TbsPartsCode);	//BLコード
                    ((SqlParameter)sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int)).Value =
                        SqlDataMediator.SqlSetInt(ofrPrime.GoodsMGroup);	//商品中分類コード
                    // 2009/10/19 >>>
                    //((SqlParameter)sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHH", SqlDbType.VarChar)).Value =
                    //    SqlDataMediator.SqlSetString(ofrPrime.PrimePartsNo);	//優良新品番

                    ( (SqlParameter)sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHH", SqlDbType.VarChar) ).Value =
                        SqlDataMediator.SqlSetString(ofrPrime.PrimePartsNoWithH);	//優良新品番
                    // 2009/10/19 <<<

                    myReader = sqlCommand.ExecuteReader();
                    SetOfferPrimeSearchRetWork(myReader, tmpWork, 1);
                    CompressPartsRec(ref tmpWork);
                    if (tmpWork.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retWork.AddRange(tmpWork);
                    }
                    myReader.Close();
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.OfferPrimeBlOldSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        private int GetOriginalPartsPrice(ArrayList inPara, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr;
            SqlDataReader myReader = null;
            retWork = new ArrayList();

            selectstr = "SELECT DISTINCT ";
            selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
            selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, ";
            selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
            selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
            selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
            selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
            selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";
            selectstr += " FROM PRMPRTPRICERF ";
            selectstr += "WHERE PRMPRTPRICERF.PRMSETDTLNO1RF = @PRMSETDTLNO1 ";
            selectstr += "AND  PRMPRTPRICERF.PARTSMAKERCDRF = @PARTSMAKERCD ";
            selectstr += "AND  PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = @PRIMEPARTSNOWITHH ";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);

                SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                SqlParameter paraPrimePartsNo = sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHH", SqlDbType.NVarChar);

                foreach (OfferPrimeSearchRetWork ofrPrime in inPara)
                {
                    paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt(ofrPrime.PrmSetDtlNo1);
                    paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt(ofrPrime.PartsMakerCd);
                    paraPrimePartsNo.Value = SqlDataMediator.SqlSetString(ofrPrime.PrimePartsNoWithH);
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        OfferJoinPriceRetWork priceWork = new OfferJoinPriceRetWork();

                        priceWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priceWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                        priceWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                        priceWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                        priceWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                        priceWork.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                        priceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                        retWork.Add(priceWork);
                    }
                    myReader.Close();
                }
                status = 0;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.GetOriginalPartsPrice Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// セットマスタ検索
        /// </summary>
        /// <param name="carMakerCd">車メーカーコード（検索品名検索用）</param>
        /// <param name="inWork">セット検索条件リスト</param>
        /// <param name="retWork">結果リスト</param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSetParts(int carMakerCode, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            //結果の初期化
            retWork = new ArrayList();

            try
            {
                selectstr = "SELECT "
                    //セットマスタ
                    + "SETPARTSRF.OFFERDATERF"
                    + ",SETPARTSRF.GOODSMGROUPRF"
                    + ",SETPARTSRF.TBSPARTSCODERF"
                    + ",SETPARTSRF.TBSPARTSCDDERIVEDNORF"
                    + ",SETPARTSRF.SETMAINMAKERCDRF"
                    + ",SETPARTSRF.SETMAINPARTSNORF"
                    + ",SETPARTSRF.SETSUBMAKERCDRF"
                    + ",SETPARTSRF.SETSUBPARTSNORF"
                    + ",SETPARTSRF.SETDISPORDERRF"
                    + ",SETPARTSRF.SETQTYRF"
                    + ",SETPARTSRF.SETNAMERF"
                    + ",SETPARTSRF.SETSPECIALNOTERF"
                    + ",SETPARTSRF.CATALOGSHAPENORF"

                    //優良部品マスタ
                    + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
                    + ",PRIMEPARTSRF.PARTSLAYERCDRF"
                    + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
                    + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
                    + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF "

                    + ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF "
                    + ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF "

                    //ＪＯＩＮ項目
                    + " FROM PRIMEPARTSRF INNER JOIN SETPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = SETPARTSRF.SETSUBMAKERCDRF"
                    + " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = SETPARTSRF.SETSUBPARTSNORF "
                    + " LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF "
                    + string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCode)
                    + "WHERE ";

                //結合先メーカーコード・結合先品番 
                foreach (OfferPrimeSearchRetWork wk in inWork)
                {
                    //セット品番フラグが１の場合のみ対象
                    if (wk.SetPartsFlg == 1)
                    {
                        wherestr += "OR ( SETPARTSRF.SETMAINMAKERCDRF = " + wk.PartsMakerCd + " AND ";
                        wherestr += "SETPARTSRF.SETMAINPARTSNORF = '" + wk.PrimePartsNoWithH + "' ) ";
                    }
                }
                if (wherestr.Length == 0)
                {
                    return (0);
                }
                wherestr = wherestr.Substring(2); // 先頭のOR除去
                wherestr += "ORDER BY SETDISPORDERRF ASC";
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferSetPartsRetWork mf = new OfferSetPartsRetWork();
                    //セットマスタ
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETMAINMAKERCDRF"));
                    mf.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETMAINPARTSNORF"));
                    mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETSUBMAKERCDRF"));
                    mf.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSUBPARTSNORF"));
                    mf.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETDISPORDERRF"));
                    mf.SetQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SETQTYRF"));
                    mf.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF"));
                    mf.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    mf.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));

                    //優良部品マスタ
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

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
                base.WriteErrorLog(ex, "OfferPrimeBlSearchDB.SearchSetParts Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// 価格取得
        /// </summary>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSetPartsPrice(ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            retWork = new ArrayList();

            if (inWork == null)
            {
                return status;
            }
            else if (inWork.Count == 0)
            {
                return 0;
            }

            try
            {
                //[単純に純正品に紐付く優良品を抽出]
                selectstr = "SELECT ";
                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, "; // セレクトコード
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";

                selectstr += " FROM PRMPRTPRICERF ";

                selectstr += " WHERE ";

                foreach (OfferSetPartsRetWork wk in inWork)
                {
                    //メーカーコード
                    wherestr += " OR ( ";
                    wherestr += " PRMPRTPRICERF.PARTSMAKERCDRF = " + wk.SetSubMakerCd;
                    wherestr += " AND PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = '" + wk.SetSubPartsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // 先頭のOR除去
                wherestr += "ORDER BY PRICESTARTDATERF DESC";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

                    //結合情報
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    mf.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    mf.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
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
                base.WriteErrorLog(ex, "OfferPrimeBlSearch.SearchSetPrimePartsNoにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;

        }

        /// <summary>
        /// DataReaderからリスト作成処理
        /// </summary>
        /// <param name="myReader">myReader</param>
        /// <param name="retInf">結果リスト</param>
        /// <param name="mode">0:一般設定　1:代替設定</param>
        private void SetOfferPrimeSearchRetWork(SqlDataReader myReader, ArrayList retInf, int mode)
        {
            OfferPrimeSearchRetWork primeSearchRetWork;
            while (myReader.Read())
            {
                primeSearchRetWork = new OfferPrimeSearchRetWork();

                //提供優良検索マスタ項目
                primeSearchRetWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                primeSearchRetWork.PrimePartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNORF"));

                primeSearchRetWork.PartsDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSDISPORDERRF"));
                primeSearchRetWork.SetPartsFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                primeSearchRetWork.PrimeQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRIMEQTYRF"));
                primeSearchRetWork.PrimeSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMESPECIALNOTERF"));
                primeSearchRetWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));
                primeSearchRetWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));
                primeSearchRetWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));
                primeSearchRetWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));
                primeSearchRetWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                primeSearchRetWork.SubstFlag = mode; // 1:代替品
                primeSearchRetWork.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                primeSearchRetWork.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                if (mode == 0) // 以下の処理は代替品に関しては処理しない。
                {
                    primeSearchRetWork.PrmPartsProperNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRMPARTSPROPERNORF"));

                    primeSearchRetWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));
                    primeSearchRetWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                    primeSearchRetWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                    primeSearchRetWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    primeSearchRetWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                    primeSearchRetWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));
                    primeSearchRetWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));
                    primeSearchRetWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
                }
                primeSearchRetWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                primeSearchRetWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                primeSearchRetWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                primeSearchRetWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                primeSearchRetWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                primeSearchRetWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                primeSearchRetWork.PrimePartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                primeSearchRetWork.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                primeSearchRetWork.PrimePartsKanaNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                primeSearchRetWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                primeSearchRetWork.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                primeSearchRetWork.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                primeSearchRetWork.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                primeSearchRetWork.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));
                primeSearchRetWork.SrchPNmAcqrCarMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCHPNMACQRCARMKRCD"));  // 2009/10/22 Add

                retInf.Add(primeSearchRetWork);
            }
        }

        /// <summary>
        /// 同一部品圧縮処理
        /// </summary>
        /// <param name="retInf">抽出結果部品レコード</param>
        private void CompressPartsRec(ref ArrayList retInf)
        {
            ArrayList alwk = new ArrayList();
            int ariflg = 0;

            foreach (OfferPrimeSearchRetWork mf in retInf)
            {
                if (mf != null)
                {
                    ariflg = 0;
                    foreach (OfferPrimeSearchRetWork mf2 in alwk)
                    {
                        if (mf2 != null)
                        {
                            if ((mf.PrimePartsNoWithH == mf2.PrimePartsNoWithH) && (mf.PartsMakerCd == mf2.PartsMakerCd)
                                && (mf.PrimeSpecialNote == mf2.PrimeSpecialNote)
                                && (mf.ModelGradeNm == mf2.ModelGradeNm) && (mf.DoorCount == mf2.DoorCount) && (mf.BodyName == mf2.BodyName)
                                && (mf.EDivNm == mf2.EDivNm) && (mf.ShiftNm == mf2.ShiftNm) && (mf.TransmissionNm == mf2.TransmissionNm)
                                && (mf.WheelDriveMethodNm == mf2.WheelDriveMethodNm))
                            {
                                if (((mf.StProduceTypeOfYear == mf2.StProduceTypeOfYear) && (mf.EdProduceTypeOfYear == mf2.EdProduceTypeOfYear)) ||
                                    ((mf.StProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.StProduceTypeOfYear <= mf2.EdProduceTypeOfYear)) ||
                                    ((mf.EdProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.EdProduceTypeOfYear <= mf2.EdProduceTypeOfYear)))
                                {
                                    if ((mf.StProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.StProduceTypeOfYear <= mf2.EdProduceTypeOfYear))
                                    {
                                        if (mf.EdProduceTypeOfYear > mf2.EdProduceTypeOfYear)
                                            mf2.EdProduceTypeOfYear = mf.EdProduceTypeOfYear;
                                    }
                                    if ((mf.EdProduceTypeOfYear >= mf2.StProduceTypeOfYear) && (mf.EdProduceTypeOfYear <= mf2.EdProduceTypeOfYear))
                                    {
                                        if (mf.StProduceTypeOfYear < mf2.StProduceTypeOfYear)
                                            mf2.StProduceTypeOfYear = mf.StProduceTypeOfYear;
                                    }
                                    // 2009/10/22 Add >>>
                                    if (mf2.SrchPNmAcqrCarMkrCd == 0 && mf2.SrchPNmAcqrCarMkrCd != mf.SrchPNmAcqrCarMkrCd)
                                    {
                                        mf2.SrchPNmAcqrCarMkrCd = mf.SrchPNmAcqrCarMkrCd;
                                        mf2.SearchPartsFullName = mf.SearchPartsFullName;
                                        mf2.SearchPartsHalfName = mf.SearchPartsHalfName;
                                    }
                                    // 2009/10/22 Add <<<
                                    ariflg = 1;

                                    break;
                                }
                            }
                        }
                    }
                    //重複していなければalwkにInsert
                    if (ariflg == 0)
                    {
                        alwk.Add(mf);
                    }
                }
            }
            //圧縮済みArrayListを戻す
            retInf = alwk;
        }

        ///// <summary>
        ///// 類別装備部品マスタリード
        ///// </summary>
        ///// <param name="ModelDesignationNo"></param>
        ///// <param name="CategoryNo"></param>
        ///// <param name="TbsPartsCode"></param>
        ///// <param name="RetInf"></param>
        ///// <returns></returns>
        //private int ReadCtgEquip(int ModelDesignationNo, int CategoryNo, int TbsPartsCode, string divname, int divcd, string partsname, ref ArrayList RetInf, ref SqlConnection sqlConnection)
        //{

        //    //SqlConnection sqlConnection		= null;
        //    SqlDataReader myReader = null;
        //    //結果の初期化
        //    //SqlEncryptInfo sqlEncriptInfo = null;

        //    int status = 0;
        //    string selectstr = "";
        //    string fromstr = "";
        //    string wherestr = "";
        //    string orderstr = "";

        //    // Prameterオブジェクトの作成
        //    SqlParameter findfull = null;	//型式
        //    SqlParameter findparts = null; //類別
        //    SqlParameter findpartsdiv = null;	//翼部品コード

        //    RetPartsInf ptwk = null;
        //    try
        //    {
        //        //●暗号化部品準備処理
        //        //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB, new string[] { "CTGEQUIPPTRF" });
        //        //暗号化キーOPEN（SQLExceptionの可能性有り）
        //        //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

        //        //,Cast(  DecryptByKey(CLGPNOINFORF.TBSPARTSCDDERIVEDNMRF) AS NVARCHAR(15) ) AS TBSPARTSCDDERIVEDNMRF				

        //        //selectstr = "SELECT EQUIPMENTNAMERF,EQUIPMENTCNTRF ";
        //        selectstr = "SELECT CTGEQUIPPTRF.EQUIPMENTNAMERF,EQUIPMENTCNTRF ";
        //        fromstr = "FROM CTGEQUIPPTRF ";

        //        wherestr = " WHERE MODELDESIGNATIONNORF=@MODELDESIGNATIONNORF AND TBSPARTSCODERF=@TBSPARTSCODERF AND CATEGORYNORF=@CATEGORYNORF ";

        //        orderstr = " ORDER BY EQUIPMENTDISPORDERRF";

        //        SqlCommand sqlCommand = new SqlCommand(selectstr + fromstr + wherestr + orderstr, sqlConnection);

        //        // Prameterオブジェクトの作成
        //        findfull = sqlCommand.Parameters.Add("@MODELDESIGNATIONNORF", SqlDbType.Int);
        //        findparts = sqlCommand.Parameters.Add("@TBSPARTSCODERF", SqlDbType.Int);
        //        findpartsdiv = sqlCommand.Parameters.Add("@CATEGORYNORF", SqlDbType.Int);

        //        // Parameterオブジェクトへ値設定
        //        findfull.Value = SqlDataMediator.SqlSetInt32(ModelDesignationNo);
        //        findparts.Value = SqlDataMediator.SqlSetInt32(TbsPartsCode);
        //        findpartsdiv.Value = SqlDataMediator.SqlSetInt32(CategoryNo);

        //        myReader = sqlCommand.ExecuteReader();

        //        int ariflg = 0;
        //        while (myReader.Read())
        //        {
        //            ariflg = 1;
        //            ptwk = new RetPartsInf();

        //            ptwk.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("EQUIPMENTCNTRF"));
        //            //ptwk.PartsQtyForRp = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("EQUIPMENTCNTRF"));
        //            ptwk.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPMENTNAMERF"));
        //            ptwk.PartsSearchCode = 2;
        //            ptwk.PartsName = partsname;
        //            ptwk.TbsPartsCode = TbsPartsCode;
        //            ptwk.WorkOrPartsDivNm = divname;
        //            ptwk.PartsCode = divcd;
        //            //ptwk.TotalDivCd = totaldivcdrf;

        //            RetInf.Add(ptwk);
        //        }
        //        if (ariflg == 0)
        //            status = 4;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (myReader != null && !myReader.IsClosed)
        //            myReader.Close();
        //    }

        //    //暗号化キークローズ
        //    //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);

        //    //sqlConnection.Close();
        //    //sqlConnection.Dispose();

        //    return status;
        //}

        #endregion
    }

}
