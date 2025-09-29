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
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良設定マスタ検索リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/23  豊沢</br>
    /// <br>           : SCM高速化 C向け種別特記対応</br>
    /// </remarks>
    [Serializable]
    public class PrimeSettingDB : RemoteDB, IPrimeSettingDB
    {

        /// <summary>
        /// 優良設定マスタ検索リモートオブジェクトコンストラクタ
        /// </summary>
        public PrimeSettingDB()
            :
        base("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSettingWork", "PRMSETTINGRF")
        {
        }

        /// <summary>
        /// 優良設定を全て戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="primeSettingWork"></param>
        /// <returns></returns>
        public int Search(out object primeSettingWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            primeSettingWork = null;
            try
            {
                ArrayList _primeSettingWork = null;
                status = SearchProc(out _primeSettingWork);

                primeSettingWork = _primeSettingWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// Search実装部
        /// </summary>
        /// <param name="primeSettingWork"></param>
        /// <returns>ステータス</returns>
        private int SearchProc(out ArrayList primeSettingWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            primeSettingWork = null;
            ArrayList retlist = new ArrayList();	//結果クラス格納用ArrayList
            try
            {
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return 99;
                //コネクション文字列取得対応↑↑↑↑↑

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;
                string sqlText = "SELECT OFFERDATERF, GOODSMGROUPRF, PARTSMAKERCDRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, "
                    // UPD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
                    //+ "SECRETCODERF, DISPLAYORDERRF, PRMSETDTLNO1RF, PRMSETDTLNAME1RF, PRMSETDTLNO2RF, PRMSETDTLNAME2RF, PRMSETGROUPRF FROM PRMSETTINGRF";
                    + "SECRETCODERF, DISPLAYORDERRF, PRMSETDTLNO1RF, PRMSETDTLNAME1RF, PRMSETDTLNO2RF, PRMSETDTLNAME2RF, PRMSETGROUPRF,"
                    + "PRMSETDTLNAME2FORFACRF, PRMSETDTLNAME2FORCOWRF"
                    + " FROM PRMSETTINGRF";
                    // UPD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {

                    //優良設定結果クラス
                    PrmSettingWork wkPrimeSettingWork = new PrmSettingWork();

                    #region 結果クラスへ格納
                    wkPrimeSettingWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingWork.SecretCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECRETCODERF"));
                    wkPrimeSettingWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    wkPrimeSettingWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    wkPrimeSettingWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
                    wkPrimeSettingWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                    wkPrimeSettingWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
                    wkPrimeSettingWork.PrmSetGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETGROUPRF"));
                    // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ---------->>>>>
                    wkPrimeSettingWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));
                    wkPrimeSettingWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));
                    // ADD 2015/02/23 豊沢 SCM高速化 C向け種別特記対応 ----------<<<<<
                    #endregion

                    retlist.Add(wkPrimeSettingWork);

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchProcにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();
                sqlConnection.Close();
            }
            primeSettingWork = retlist;

            return status;
        }


        /// <summary>
        /// 優良設定を全て戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="primeSettingNoteWork"></param>
        /// <returns></returns>
        public int SearchNote(out object primeSettingNoteWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            primeSettingNoteWork = null;
            try
            {
                ArrayList _primeSettingNoteWork = null;
                status = SearchNoteProc(out _primeSettingNoteWork);

                primeSettingNoteWork = _primeSettingNoteWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.Search Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }


        /// <summary>
        /// Search実装部
        /// </summary>
        /// <param name="primeSettingNoteWork"></param>
        /// <returns>ステータス</returns>
        private int SearchNoteProc(out ArrayList primeSettingNoteWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            primeSettingNoteWork = null;
            ArrayList retlist = new ArrayList();	//結果クラス格納用ArrayList
            try
            {
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;
                string sqlText =
                    "SELECT OFFERDATERF, GOODSMGROUPRF, PARTSMAKERCDRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, "
                    + "IMPORTANTNOTECDRF, PRMSETNOTERF "
                    + "FROM PRMSETNOTERF";
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    //優良設定結果クラス
                    PrmSetNoteWork wkPrimeSettingNoteWork = new PrmSetNoteWork();

                    #region 結果クラスへ格納
                    wkPrimeSettingNoteWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingNoteWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingNoteWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingNoteWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingNoteWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingNoteWork.ImportantNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMPORTANTNOTECDRF"));
                    wkPrimeSettingNoteWork.PrmSetNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETNOTERF"));
                    #endregion

                    retlist.Add(wkPrimeSettingNoteWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchNoteProcにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();
                sqlConnection.Close();
            }
            primeSettingNoteWork = retlist;

            return status;
        }

        /// <summary>
        /// 優良設定変更マスタ
        /// </summary>
        /// <param name="PrimeSettingChgWork"></param>
        /// <returns>ステータス</returns>
        public int SearchChg(out object PrimeSettingChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            PrimeSettingChgWork = null;
            try
            {
                ArrayList _primeSettingChgWork = null;
                status = SerchChgProc(out _primeSettingChgWork);

                PrimeSettingChgWork = _primeSettingChgWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchChg Exception = " + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// Search実装部
        /// </summary>
        /// <param name="primeSettingChgWork"></param>
        /// <returns>ステータス</returns>
        private int SerchChgProc(out ArrayList primeSettingChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            primeSettingChgWork = null;
            ArrayList retlist = new ArrayList();	//結果クラス格納用ArrayList
            try
            {
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_OfferDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return 99;
                //コネクション文字列取得対応↑↑↑↑↑

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;
                string sqlText = "SELECT OFFERDATERF, GOODSMGROUPRF, PARTSMAKERCDRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, "
                               + "PRMSETDTLNO1RF, PRMSETDTLNO2RF, AFPRMSETDTLNO1RF, AFPRMSETDTLNO2RF, AFPRIMEDISPLAYCODERF, PROCDIVCDRF FROM PRMSETTINGCHGRF";
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {

                    //優良設定結果クラス
                    PrmSettingChgWork wkPrimeSettingchgWork = new PrmSettingChgWork();

                    #region 結果クラスへ格納
                    wkPrimeSettingchgWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingchgWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingchgWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingchgWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingchgWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingchgWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    wkPrimeSettingchgWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                    wkPrimeSettingchgWork.AfPrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRMSETDTLNO1RF"));
                    wkPrimeSettingchgWork.AfPrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRMSETDTLNO2RF"));
                    wkPrimeSettingchgWork.AfPrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRIMEDISPLAYCODERF"));
                    wkPrimeSettingchgWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
                    #endregion

                    retlist.Add(wkPrimeSettingchgWork);

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimeSettingDB.SearchChgProcにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();
                sqlConnection.Close();
            }
            primeSettingChgWork = retlist;

            return status;
        }
    }
}
