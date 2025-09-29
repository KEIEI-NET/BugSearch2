//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 優良部品詳細マスタDBリモートオブジェクト
// プログラム概要   : 優良部品詳細マスタの取得を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00 作成担当 : 櫻井　亮太
// 作 成 日  2017/10/17  修正内容 : 新規作成
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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良部品詳細マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井　亮太</br>
    /// <br>Date       : 2017.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PrimePartsDtlDB : RemoteDB, IPrimePartsDtlDB
    {
        //レコード有無フラグ
        private short ExistFlg_ON = 1;

        /// <summary>
        /// 優良部品詳細情報マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        /// </remarks>
        public PrimePartsDtlDB()
            :
            base("PMTKD09313D", "Broadleaf.Application.Remoting.ParamData.PrmPrtDtInfWork", "PRMPRTDTINFRF")
        {
        }

        #region [優良部品詳細マスタRead]
        /// <summary>
        /// 指定された条件の優良部品詳細情報マスタLISTを戻します
        /// </summary>
        /// <param name="PrimePartsDtlobj">検索結果</param>
        /// <param name="PartsMakerCode">メーカーコード</param>
        /// <param name="PrimePartsNoWithHypen">品番(ハイフン付)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の優良部品詳細情報マスタLISTを戻します</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        public int Read(out object PrimePartsDtlObj, object PrimePartsParaObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            PrimePartsDtlObj = null;
            PrmPrtDtInfWork prmPrtDtlInfWork = new PrmPrtDtInfWork();
            SqlConnection sqlConnection = null;

            if (PrimePartsParaObj == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //優良部品詳細情報マスタ取得
                status = ReadPrimePartsDtl(ref prmPrtDtlInfWork, PrimePartsParaObj, ref sqlConnection);
                
                //メーカー名称取得（メーカーマスタ）
                if (status == 0){
                    status = ReadPartsMaker(ref prmPrtDtlInfWork, ref sqlConnection);                   
                }
                //規格・特記事項取得（優良部品マスタ）
                if (status == 0){
                    status = ReadPrimePartsMst(ref prmPrtDtlInfWork, ref sqlConnection);    
                }

                PrimePartsDtlObj = prmPrtDtlInfWork;

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsDtlDB.Read");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 指定された条件のBLコードマスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="PrimePartsDtlobj">検索結果</param>
        /// <param name="PartsMakerCode">メーカーコード</param>
        /// <param name="PrimePartsNoWithHypen">品番(ハイフン付)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の優良部品詳細マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        private int ReadPrimePartsDtl(ref PrmPrtDtInfWork PrmPrtDtInfWork, object PrimePartsParaobj, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            PrmPrtDtParaWork prmPrtDtParaWork = PrimePartsParaobj as PrmPrtDtParaWork;

            try
            {
                #region SELECT文
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "  OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  , PARTSMAKERCODERF" + Environment.NewLine;
                sqlTxt += "  , PRIMEPARTSNOWITHHRF" + Environment.NewLine;
                sqlTxt += "  , GOODSDETAILDESCTOBRF" + Environment.NewLine;
                sqlTxt += "  , GOODSDETAILDESCTOCRF" + Environment.NewLine;
                sqlTxt += "  , PRMPARTSMAKERURLRF" + Environment.NewLine;
                sqlTxt += "  , PRMPARTSCATALOGURIRF" + Environment.NewLine;
                sqlTxt += "  , PRMPTDESCMOVIEURIRF" + Environment.NewLine;
                sqlTxt += "  , GOODSSIZELENGTHRF" + Environment.NewLine;
                sqlTxt += "  , GOODSSIZEWIDTHRF" + Environment.NewLine;
                sqlTxt += "  , GOODSSIZEHEIGHTRF" + Environment.NewLine;
                sqlTxt += "  , GOODSSIZEUNITRF" + Environment.NewLine;
                sqlTxt += "  , GOODSPKGBOXLENGTHRF" + Environment.NewLine;
                sqlTxt += "  , GOODSPKGBOXWIDTHRF" + Environment.NewLine;
                sqlTxt += "  , GOODSPKGBOXHEIGHTRF" + Environment.NewLine;
                sqlTxt += "  , GOODSPKGBOXUNITRF" + Environment.NewLine;
                sqlTxt += "  , GOODSVOLUMERF" + Environment.NewLine;
                sqlTxt += "  , GOODSVOLUMEUNITRF" + Environment.NewLine;
                sqlTxt += "  , GOODSWEIGHTRF" + Environment.NewLine;
                sqlTxt += "  , GOODSWEIGHTUNITRF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGEXTDIVRF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGEXTDIVRF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME1RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME1RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME2RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME2RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME3RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME3RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME4RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME4RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME5RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME5RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME6RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME6RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME7RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME7RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME8RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME8RF" + Environment.NewLine;
                sqlTxt += "  , GOODSDTLIMGFLNAME9RF" + Environment.NewLine;
                sqlTxt += "  , GOODSTMBIMGFLNAME9RF" + Environment.NewLine;
                sqlTxt += "  , CARPRTSDISCONTDIVRF" + Environment.NewLine;
                sqlTxt += "  , CARPRTSDISCONTDATERF" + Environment.NewLine;
                sqlTxt += "  , SUBSTPRMPRTSWITHHYPHRF " + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  PRMPRTDTINFRF " + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "      PARTSMAKERCODERF = @FINDPARTSMAKERCODE " + Environment.NewLine;
                sqlTxt += "  AND PRIMEPARTSNOWITHHRF = @FINDPRIMEPARTSNOWITHH" + Environment.NewLine;
                sqlTxt += "  AND OFFERDATERF <= @FINDOFFERDATE " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);  // 提供日付
                SqlParameter findPartsMakerCode = sqlCommand.Parameters.Add("@FINDPARTSMAKERCODE", SqlDbType.Int);  // 部品メーカーコード
                SqlParameter findPrimePartsNoWithH = sqlCommand.Parameters.Add("@FINDPRIMEPARTSNOWITHH", SqlDbType.NVarChar);  // 優良品番(－付き品番)

                //Parameterオブジェクトへ値設定
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(System.DateTime.Now.Year * 10000 + System.DateTime.Now.Month * 100 + System.DateTime.Now.Day);  // 提供日付
                findPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(prmPrtDtParaWork.PartsMakerCode);  // 部品メーカーコード
                findPrimePartsNoWithH.Value = SqlDataMediator.SqlSetString(prmPrtDtParaWork.PrimePartsNoWithH);  // 優良品番(－付き品番)

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read()){
                    PrmPrtDtInfWork = CopyToPrmPrtDtInfWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex){
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally{
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// メーカー名を取得します
        /// </summary>
        /// <param name="PrimePartsDtlobj">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー名を取得します</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        private int ReadPartsMaker(ref PrmPrtDtInfWork PrmPrtDtInfWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                #region SELECT文
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "  OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  , PARTSMAKERCODERF" + Environment.NewLine;
                sqlTxt += "  , PARTSMAKERFULLNAMERF" + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  PMAKERNMRF " + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "      PARTSMAKERCODERF = @FINDPARTSMAKERCODE " + Environment.NewLine;
                sqlTxt += "  AND OFFERDATERF <= @FINDOFFERDATE " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);  // 提供日付
                SqlParameter findPartsMakerCode = sqlCommand.Parameters.Add("@FINDPARTSMAKERCODE", SqlDbType.Int);  // 部品メーカーコード

                //Parameterオブジェクトへ値設定
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(System.DateTime.Now.Year * 10000 + System.DateTime.Now.Month * 100 + System.DateTime.Now.Day);  // 提供日付
                findPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(PrmPrtDtInfWork.PartsMakerCode);  // 部品メーカーコード

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    PrmPrtDtInfWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF")); 
                }
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
            return status;
        
        }

        /// <summary>
        /// 品名・特記事項を取得します
        /// </summary>
        /// <param name="PrimePartsDtlobj">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品名・特記事項を取得します</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        private int ReadPrimePartsMst(ref PrmPrtDtInfWork PrmPrtDtInfWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;


            try
            {
                #region SELECT文
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT TOP(1)" + Environment.NewLine;
                sqlTxt += "  OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  , PARTSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  , PRIMEPARTSNOWITHHRF" + Environment.NewLine;
                sqlTxt += "  , PRIMEPARTSNAMERF" + Environment.NewLine;
                sqlTxt += "  , PRIMEPARTSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  PRIMEPARTSRF " + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "      PARTSMAKERCDRF = @FINDPARTSMAKERCD " + Environment.NewLine;
                sqlTxt += "     AND PRIMEPARTSNOWITHHRF = @FINDPRIMEPARTSNOWITHH " + Environment.NewLine;
                sqlTxt += "  AND OFFERDATERF <= @FINDOFFERDATE " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);  // 提供日付
                SqlParameter findPartsMakerCode = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);  // 部品メーカーコード
                SqlParameter findPrimePartsNoWithH = sqlCommand.Parameters.Add("@FINDPRIMEPARTSNOWITHH", SqlDbType.NVarChar);  // 優良品番(－付き品番)

                //Parameterオブジェクトへ値設定
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(System.DateTime.Now.Year * 10000 + System.DateTime.Now.Month * 100 + System.DateTime.Now.Day);  // 提供日付
                findPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(PrmPrtDtInfWork.PartsMakerCode);  // 部品メーカーコード
                findPrimePartsNoWithH.Value = SqlDataMediator.SqlSetString(PrmPrtDtInfWork.PrimePartsNoWithH);  // 優良品番(－付き品番)

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    PrmPrtDtInfWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // 提供日付
                    PrmPrtDtInfWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));  // 部品メーカーコード
                    PrmPrtDtInfWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));  // 優良品番(－付き品番)
                    PrmPrtDtInfWork.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));  // 品名
                    PrmPrtDtInfWork.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));  // 特記事項
                }
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
            return status;      
        }
        #endregion

        #region 優良部品詳細マスタ有無チェック
        /// <summary>
        /// 優良部品詳細マスタの有無チェックを行います。
        /// </summary>
        /// <param name="parabyte">TbsPartsCodeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良部品詳細マスタの有無チェックを行います。</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        public int CheckExist(out object PrimPartsCheckObj, object PrimePartsParaObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            PrimPartsCheckObj = null;

            if (PrimePartsParaObj == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try{
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                CustomSerializeArrayList prmPrtDtParalist = PrimePartsParaObj as CustomSerializeArrayList;

                if (prmPrtDtParalist.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_EOF;

                status = CheckExistProc(out PrimPartsCheckObj,prmPrtDtParalist, ref sqlConnection);
                
                return status;
            }
            catch(Exception ex){
                base.WriteErrorLog(ex, "PrimePartsDtlDB.CheckExist");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally{
                if (sqlConnection != null){
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 優良部品詳細マスタの有無チェックを行います。
        /// </summary>
        /// <param name="prmPrtDtparaWork">抽出条件</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優良部品詳細マスタの有無チェックを行います。</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        private int CheckExistProc(out object PrimPartsCheckObj, CustomSerializeArrayList PrmPrtDtParalist, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int querryCount = 0;
            int setCount = 0; 
            int Maker = 0;
            string GoodsNo = string.Empty;

            SqlDataReader myReader = null;
            CustomSerializeArrayList PrimePartsCheckResult = new CustomSerializeArrayList();
            Dictionary<string, int> retdic = new Dictionary<string, int>();
            PrimPartsCheckObj = null;
            try
            {
                //クエリ作成
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += " PARTSMAKERCODERF," + Environment.NewLine;
                sqlTxt += " PRIMEPARTSNOWITHHRF" + Environment.NewLine;
                sqlTxt += "FROM PRMPRTDTINFRF" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                if (PrmPrtDtParalist.Count>1)
                    sqlTxt += " (" + Environment.NewLine;
                foreach (PrmPrtDtParaWork prmPrtDtParaWork in PrmPrtDtParalist){
                    if (querryCount != 0) sqlTxt += " OR " + Environment.NewLine;
                    ++querryCount;

                    sqlTxt += " (PARTSMAKERCODERF=@PARTSMAKERCODE" + querryCount + Environment.NewLine;
                    sqlTxt += " AND PRIMEPARTSNOWITHHRF=@PRIMEPARTSNOWITHH" + querryCount+")" + Environment.NewLine;
                }
                if (PrmPrtDtParalist.Count > 1)
                    sqlTxt += " )" + Environment.NewLine;
                sqlTxt += " AND OFFERDATERF<=@OFFERDATE" + Environment.NewLine;

                //Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                foreach (PrmPrtDtParaWork prmPrtDtParaWork in PrmPrtDtParalist){
                    ++setCount;
                    //Prameterオブジェクトの作成
                    SqlParameter findParaPartsMakerCode = sqlCommand.Parameters.Add("@PARTSMAKERCODE" + setCount, SqlDbType.Int);
                    SqlParameter findParaPrimePartsNoWith = sqlCommand.Parameters.Add("@PRIMEPARTSNOWITHH" + setCount, SqlDbType.NVarChar);
                    //Parameterオブジェクトへ値設定
                    findParaPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(prmPrtDtParaWork.PartsMakerCode);
                    findParaPrimePartsNoWith.Value = SqlDataMediator.SqlSetString(prmPrtDtParaWork.PrimePartsNoWithH);
                }

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.NVarChar);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(System.DateTime.Now.Year * 10000 + System.DateTime.Now.Month * 100 + System.DateTime.Now.Day);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while(myReader.Read())
                {
                    Maker =0;
                    GoodsNo = string.Empty;
                   
                    Maker = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));  // 部品メーカーコード
                    GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));  // 優良品番(－付き品番) 
                    retdic.Add(Maker + "," + GoodsNo.Trim(), 1);
                }
                foreach (PrmPrtDtParaWork prmPrtDtParaWork in PrmPrtDtParalist)
                {
                    PrmPrtDtParaWork retPrmPrtDtParaWork = prmPrtDtParaWork as PrmPrtDtParaWork;
                    if (retdic.ContainsKey(retPrmPrtDtParaWork.PartsMakerCode + "," + retPrmPrtDtParaWork.PrimePartsNoWithH.Trim()))
                    {
                        retPrmPrtDtParaWork.DtlMstExistDiv = ExistFlg_ON;
                    }
                    PrimePartsCheckResult.Add(retPrmPrtDtParaWork);
                }

                PrimPartsCheckObj = PrimePartsCheckResult;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                {
                    PrimePartsCheckResult = null;
                    retdic = null;
                }
            }            
            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → TbsPartsCodeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TbsPartsCodeWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        /// </remarks>
        private PrmPrtDtInfWork CopyToPrmPrtDtInfWorkFromReader(ref SqlDataReader myReader)
        {
            PrmPrtDtInfWork wkPrmPrtDtInfWork = new PrmPrtDtInfWork();

            #region クラスへ格納
            wkPrmPrtDtInfWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // 提供日付
            wkPrmPrtDtInfWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));  // 部品メーカーコード
            wkPrmPrtDtInfWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));  // 優良品番(－付き品番)
            wkPrmPrtDtInfWork.GoodsDetailDescToB = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDETAILDESCTOBRF"));  // 商品詳細説明(B向け)
            wkPrmPrtDtInfWork.GoodsDetailDescToC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDETAILDESCTOCRF"));  // 商品詳細説明(C向け)
            wkPrmPrtDtInfWork.PrmPartsMakerUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSMAKERURLRF"));  // 優良部品メーカーURL
            wkPrmPrtDtInfWork.PrmPartsCatalogUri = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSCATALOGURIRF"));  // 優良部品カタログURI
            wkPrmPrtDtInfWork.PrmPtDescMovieUri = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPTDESCMOVIEURIRF"));  // 優良部品説明動画URI
            wkPrmPrtDtInfWork.GoodsSizeLength = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSSIZELENGTHRF"));  // 商品寸法・長さ
            wkPrmPrtDtInfWork.GoodsSizeWidth = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSSIZEWIDTHRF"));  // 商品寸法・幅
            wkPrmPrtDtInfWork.GoodsSizeHeight = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSSIZEHEIGHTRF"));  // 商品寸法・高さ
            wkPrmPrtDtInfWork.GoodsSizeUnit = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSIZEUNITRF"));  // 商品寸法・単位
            wkPrmPrtDtInfWork.GoodsPkgBoxLength = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPKGBOXLENGTHRF"));  // 商品箱寸法・長さ
            wkPrmPrtDtInfWork.GoodsPkgBoxWidth = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPKGBOXWIDTHRF"));  // 商品箱寸法・幅
            wkPrmPrtDtInfWork.GoodsPkgBoxHeight = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPKGBOXHEIGHTRF"));  // 商品箱寸法・高さ
            wkPrmPrtDtInfWork.GoodsPkgBoxUnit = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPKGBOXUNITRF"));  // 商品箱寸法・単位
            wkPrmPrtDtInfWork.GoodsVolume = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSVOLUMERF"));  // 商品内容量
            wkPrmPrtDtInfWork.GoodsVolumeUnit = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSVOLUMEUNITRF"));  // 商品内容量単位
            wkPrmPrtDtInfWork.GoodsWeight = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSWEIGHTRF"));  // 商品重量
            wkPrmPrtDtInfWork.GoodsWeightUnit = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSWEIGHTUNITRF"));  // 商品重量単位
            wkPrmPrtDtInfWork.GoodsDtlImgExtDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("GOODSDTLIMGEXTDIVRF"));  // 商品詳細画像有無区分
            wkPrmPrtDtInfWork.GoodsTmbImgExtDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("GOODSTMBIMGEXTDIVRF"));  // 商品サムネイル画像有無区分
            wkPrmPrtDtInfWork.GoodsDtlImgFlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME1RF"));  // 商品画像1詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME1RF"));  // 商品画像1サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME2RF"));  // 商品画像2詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME2RF"));  // 商品画像2サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME3RF"));  // 商品画像3詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME3RF"));  // 商品画像3サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME4RF"));  // 商品画像4詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME4RF"));  // 商品画像4サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME5RF"));  // 商品画像5詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME5RF"));  // 商品画像5サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME6RF"));  // 商品画像6詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME6RF"));  // 商品画像6サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME7RF"));  // 商品画像7詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME7RF"));  // 商品画像7サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME8RF"));  // 商品画像8詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME8RF"));  // 商品画像8サムネイルファイル名
            wkPrmPrtDtInfWork.GoodsDtlImgFlName9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSDTLIMGFLNAME9RF"));  // 商品画像9詳細ファイル名
            wkPrmPrtDtInfWork.GoodsTmbImgFlName9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSTMBIMGFLNAME9RF"));  // 商品画像9サムネイルファイル名
            wkPrmPrtDtInfWork.CarPrtsDiscontDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CARPRTSDISCONTDIVRF"));  // 自動車部品廃番区分
            wkPrmPrtDtInfWork.CarPrtsDiscontDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPRTSDISCONTDATERF"));  // 自動車部品廃番日
            wkPrmPrtDtInfWork.SubstPrmPrtsWithHyph = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSTPRMPRTSWITHHYPHRF"));  // 代替優良品番(－付き品番)
            #endregion

            return wkPrmPrtDtInfWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
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
