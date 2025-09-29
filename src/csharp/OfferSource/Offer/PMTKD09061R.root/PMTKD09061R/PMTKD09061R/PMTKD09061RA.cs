using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using System.Collections.Generic; // --- ADD m.suzuki 2012/01/31
using Broadleaf.Library.Collections; // ADD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 


namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 優良部品情報取得リモートオブジェクトクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良部品情報取得の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.17 22018  鈴木 正臣</br>
    /// <br>           : ①セレクトコード(PrmSetDtlNo1)をセットするよう修正。</br>
    /// <br>           :   (セレクトコード別のデータがあるとき該当なしになる現象の対応)</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/24　21024 佐々木 健</br>
    /// <br>           : セット部品検索の戻り値に、優良部品BLコード、枝番を追加(MANTIS[0013603])</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/25　21024 佐々木 健</br>
    /// <br>           : 検索速度チューニング対応（結合代替部品の読み込み方法の修正,MANTIS[0014934]）</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/28　22018 鈴木 正臣</br>
    /// <br>           : 自由検索対応　優良部品を一括取得する処理を追加。(PMTKD06161Rから呼び出す)</br>
    /// <br></br>
    /// <br>Update Note: 2012/01/31　22018 鈴木 正臣</br>
    /// <br>           : 提供DBへの負荷軽減対応</br>
    /// <br>           : 　①結合代替マスタの抽出回数が優良部品の件数分になっていたので、一括で抽出するよう変更。</br>
    /// <br>           : 　②セット代替マスタの抽出回数がセット子品番の件数分になっていたので、一括で抽出するよう変更。</br>
    /// <br>Update Note: 2014/05/09　吉岡</br>
    /// <br>           : 速度改善フェーズ２№11,№12 絞込タイミング変更</br>
    /// <br></br>
    /// <br>Update Note: 管理番号  11070076-00  PM-SCM速度改良 フェーズ２対応</br>
    /// <br>                                    13.フル型式固定番号からのＢＬコード検索回数改良対応</br>
    /// <br>                                    14.明細取込区分の更新方法を改良対応</br>
    /// <br>                                    15.SCM受発注データ（車両情報）取得方法改良対応</br>
    /// <br>                                    16.純正品検索改良対応</br>
    /// <br>                                    17.優良品検索改良対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/05/13</br>
    /// <br></br>
    /// <br>Update Note: 管理番号  11070076-00  PM-SCM速度改良 フェーズ２対応</br>
    /// <br>                                    障害対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/06/12</br>
    /// <br></br>
    /// <br>Update Note: 管理番号  11070076-00  PM-SCM速度改良 フェーズ２対応</br>
    /// <br>                                    パブリック変数をプライベート変数に変更</br>
    /// <br>Programmer : 20073 西 毅</br>
    /// <br>Date       : 2014/08/07</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class PrimePartsInfDB : RemoteDB, IPrimePartsInfo
    {
        # region ＰＵＢＬＩＣ定義

        # region 優良品番検索 DBリモートオブジェクトクラスコンストラクタ
        /// <summary>
        ///　優良品番検索 DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        public PrimePartsInfDB()
            :
            base("PMTKD09063D", "Broadleaf.Application.Remoting.PrimePartsInfDB", "PRIMEPARTSRF")
        {
        }
        # endregion

        # region 優良品番検索 DBリモートオブジェクト
        /// <summary>
        /// 優良品番検索 DBリモートオブジェクト
        /// </summary>
        /// <param name="inPara">検索パラメータ</param>
        /// <param name="inRetInf">部品情報</param>
        /// <param name="inPrimePrice">部品価格</param>
        /// <param name="inRetSetParts">セット部品</param>
        /// <param name="SetPrice">セット価格</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : パラメータで指定された優良部品情報を返します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int GetPartsInf(GetPrimePartsInfPara inPara, out ArrayList inRetInf, out ArrayList inPrimePrice,
                        out ArrayList inRetSetParts, out ArrayList SetPrice)
        {
            return GetPartsInfProc(inPara, out inRetInf, out inPrimePrice, out inRetSetParts, out SetPrice);
        }

        private int GetPartsInfProc(GetPrimePartsInfPara inPara, out ArrayList inRetInf, out ArrayList inPrimePrice,
                        out ArrayList inRetSetParts, out ArrayList SetPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            //結果の初期化
            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //優良品番をＫＥＹにして優良品番を検索
                status = SearchPrimePartsNo(inPara, out inRetInf, sqlConnection);
                if (status != 0)
                {
                    return (status);
                }
                //セットマスタの読み込み
                ArrayList list = new ArrayList();
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.JoinDestMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.JoinDestPartsNo;
                    list.Add(ofrPartsCondWork);
                }
                SearchPartsPrice( list, out inPrimePrice, sqlConnection, null );

                if (inPara.SetSearchFlg == 1)
                {
                    status = SearchSetParts(0, list, out inRetSetParts, sqlConnection, null);
                    list = new ArrayList();
                    foreach (OfferSetPartsRetWork wk in inRetSetParts)
                    {
                        OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                        ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                        ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                        list.Add(ofrPartsCondWork);
                    }
                    SearchPartsPrice( list, out SetPrice, sqlConnection, null );
                }
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInfにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInfにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        # region [優良部品検索(自由検索用)]
        /// <summary>
        /// 優良部品検索（自由検索用）
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="condList"></param>
        /// <param name="inRetInf"></param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        public int GetPrimePartsInfForFreeSearch( int blGoodsCode, ArrayList condList, out ArrayList inRetInf, out ArrayList inPrimePrice,
                        out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //結果の初期化
            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            try
            {
                //優良品番をＫＥＹにして優良品番を検索
                status = SearchPrimePartsNoForFreeSearch( blGoodsCode, condList, out inRetInf, sqlConnection );
                if ( status != 0 )
                {
                    return (status);
                }
                //セットマスタの読み込み
                ArrayList list = new ArrayList();
                foreach ( OfferJoinPartsRetWork wk in inRetInf )
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.JoinDestMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.JoinDestPartsNo;
                    list.Add( ofrPartsCondWork );
                }
                // 優良価格読み込み
                SearchPartsPrice( list, out inPrimePrice, sqlConnection, null );

                // セット読み込み
                status = SearchSetParts( 0, list, out inRetSetParts, sqlConnection, null );
                list = new ArrayList();
                foreach ( OfferSetPartsRetWork wk in inRetSetParts )
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                    list.Add( ofrPartsCondWork );
                }
                // セット価格読み込み
                SearchPartsPrice( list, out SetPrice, sqlConnection, null );
            }
            catch ( SqlException ex )
            {
                return base.WriteSQLErrorLog( ex, "PrimePartsInfDB.GetPartsInfにてSQLエラー発生 Msg=" + ex.Message, 0 );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "PrimePartsInfDB.GetPartsInfにてエラー発生 Msg=" + ex.Message, 0 );
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }
            return status;
        }

        /// <summary>
        /// 優良部品情報取得（自由検索用）
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="condList"></param>
        /// <param name="inRetInf"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>※SearchPrimePartsNoを元に複数品番に対応する処理として新規作成します。</remarks>
        private int SearchPrimePartsNoForFreeSearch( int blGoodsCode, ArrayList condList, out ArrayList inRetInf, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            inRetInf = new ArrayList();

            try
            {
                SqlCommand sqlCommand = new SqlCommand();

                //[提供優良品番検索]
                selectstr = "SELECT ";
                selectstr += "PRM.OFFERDATERF, ";
                selectstr += "PRM.GOODSMGROUPRF, ";
                selectstr += "PRM.TBSPARTSCODERF, ";
                selectstr += "PRM.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PRM.PRMSETDTLNO1RF, ";
                selectstr += "PRM.PARTSMAKERCDRF, ";
                selectstr += "PRM.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRM.PRIMEPARTSNONONEHRF, ";
                selectstr += "PRM.PRIMEPARTSNAMERF, ";
                selectstr += "PRM.PRIMEPARTSKANANMRF, ";
                selectstr += "PRM.PARTSLAYERCDRF, ";
                selectstr += "PRM.PRIMEPARTSSPECIALNOTERF, ";
                selectstr += "PRM.PARTSATTRIBUTERF, ";
                selectstr += "PRM.CATALOGDELETEFLAGRF, ";
                selectstr += "PRM.PRMPARTSILLUSTCRF, ";
                selectstr += "SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF, ";
                selectstr += "SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";

                selectstr += " FROM PRIMEPARTSRF AS PRM ";

                selectstr += " LEFT OUTER JOIN SEARCHPRTNMRF ON (@FINDBLGOODSCODE = SEARCHPRTNMRF.TBSPARTSCODERF ";
                selectstr += " AND PRM.PARTSMAKERCDRF = SEARCHPRTNMRF.CARMAKERCODERF ) ";

                SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add( "@FINDBLGOODSCODE", SqlDbType.Int );
                findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32( blGoodsCode );

                # region [WHERE]
                wherestr = " WHERE ";

                for ( int index = 0; index < condList.Count; index++ )
                {
                    if ( index > 0 )
                    {
                        wherestr += " OR ";
                    }
                    wherestr += string.Format( " (PRM.PRIMEPARTSNOWITHHRF = @PARTSNORF{0} AND PRM.PARTSMAKERCDRF = @PARTSMAKERCDRF{0}) ", index );


                    OfrPartsCondWork cond = (condList[index] as OfrPartsCondWork);

                    // 品番
                    SqlParameter ptno = sqlCommand.Parameters.Add( string.Format( "@PARTSNORF{0}", index ), SqlDbType.NVarChar );
                    ptno.Value = SqlDataMediator.SqlSetString( cond.PrtsNo );

                    // メーカー
                    SqlParameter mkcd = sqlCommand.Parameters.Add( string.Format( "@PARTSMAKERCDRF{0}", index ), SqlDbType.Int );
                    mkcd.Value = SqlDataMediator.SqlSetInt( cond.MakerCode );
                }
                # endregion

                selectstr += wherestr;

                selectstr += " ORDER BY PRM.PARTSMAKERCDRF, PRM.PRIMEPARTSNOWITHHRF";


                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = selectstr;
                sqlCommand.Transaction = null;


                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    # region [結果格納]
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "OFFERDATERF" ) );
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) );
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNORF" ) );
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRMSETDTLNO1RF" ) );
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCDRF" ) );
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNOWITHHRF" ) );
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNONONEHRF" ) );
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNAMERF" ) );
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSKANANMRF" ) );
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSLAYERCDRF" ) );
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSSPECIALNOTERF" ) );
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSATTRIBUTERF" ) );
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CATALOGDELETEFLAGRF" ) );
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRMPARTSILLUSTCRF" ) );
                    mf.SearchPartsFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSFULLNAMERF" ) );
                    mf.SearchPartsHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEARCHPARTSHALFNAMERF" ) );
                    # endregion

                    inRetInf.Add( mf );
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "PrimePartsInfDB.SearchPrimePartsNoにてエラー発生 Msg=" + ex.Message, 0 );
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( myReader != null && !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }
        # endregion
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        # endregion

        #region 純正品番　→　結合検索
        /// <summary>
        /// 優良品番検索 DBリモートオブジェクト[純正品番　→　結合検索]
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg">代替フラグ[true:する/false:しない]</param>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        /// <param name="inPara">検索パラメータ</param>		
        /// <param name="inRetInf">部品情報</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : パラメータで指定された優良部品情報を返します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        public int GetPartsInfByCtlgPtNo( bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
                out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice )
        {
            SqlConnection sqlConnection = null;
            inRetInf = null;
            inPrimePrice = null;
            inRetSetParts = null;
            SetPrice = null;
            try
            {
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                return GetPartsInfByCtlgPtNoProc( substFlg, carMakerCd, inPara, out inRetInf, out inPrimePrice,
                            out inRetSetParts, out SetPrice, sqlConnection );
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNoにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNoにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
        }

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応 ---------------------------------->>>>>
        /// <summary>
        /// 優良品番検索 DBリモートオブジェクト[純正品番　→　結合検索]（自動回答処理専用）
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg">代替フラグ[true:する/false:しない]</param>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        /// <param name="inPara">検索パラメータ</param>		
        /// <param name="inRetInf">部品情報</param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : パラメータで指定された優良部品情報を返します。</br>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //// UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ---------------------------->>>>>
        ////public int GetPartsInfByCtlgPtNoAutoAnswer(bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
        ////        out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice)
        //public int GetPartsInfByCtlgPtNoAutoAnswer(bool substFlg, int carMakerCd, ArrayList inPara, out object inRetInf,
        //        out object inPrimePrice, out object inRetSetParts, out object SetPrice)
        public int GetPartsInfByCtlgPtNoAutoAnswer(string sectionCodeWk, int customerCodeWk, List<object> obAutoAnsItemStList, List<object> obPrmSettingList,
            bool substFlg, int carMakerCd, ArrayList inPara, out object inRetInf,
                out object inPrimePrice, out object inRetSetParts, out object SetPrice)
        //// UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ----------------------------<<<<<
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            SqlConnection sqlConnection = null;
            // UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ---------------------------->>>>>
            //inRetInf = new ArrayList();
            //inPrimePrice = new ArrayList();
            //inRetSetParts = new ArrayList();
            //SetPrice = new ArrayList();
            CustomSerializeArrayList inRetInfCustomSerializeArrayList = new CustomSerializeArrayList();
            inRetInf = inRetInfCustomSerializeArrayList;
            CustomSerializeArrayList inPrimePriceCustomSerializeArrayList = new CustomSerializeArrayList();
            inPrimePrice = inPrimePriceCustomSerializeArrayList;
            CustomSerializeArrayList inRetSetPartsCustomSerializeArrayList = new CustomSerializeArrayList();
            inRetSetParts = inRetSetPartsCustomSerializeArrayList;
            CustomSerializeArrayList SetPriceCustomSerializeArrayList = new CustomSerializeArrayList();
            SetPrice = SetPriceCustomSerializeArrayList;
            // UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ----------------------------<<<<<

            ArrayList retInRetInf = new ArrayList();
            ArrayList retInPrimePrice = new ArrayList();
            ArrayList retInRetSetParts = new ArrayList();
            ArrayList retSetPrice = new ArrayList();

            try
            {

                // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
                List<AutoAnsItemStForOffer> autoAnsItemStList = new List<AutoAnsItemStForOffer>();
                List<PrmSettingUForOffer> prmSettingUList = new List<PrmSettingUForOffer>();
                int customerCode = 0;
                string sectionCode = string.Empty;

                CacheAutoAnswer(sectionCodeWk, customerCodeWk, obAutoAnsItemStList, obPrmSettingList,
                                    ref autoAnsItemStList, ref prmSettingUList, out customerCode, out sectionCode);
                // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (inPara != null && inPara.Count != 0)
                {
                    foreach (ArrayList paraList in inPara)
                    {
                        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
                        //status = GetPartsInfByCtlgPtNoProcAutoAnswer(substFlg, carMakerCd, paraList, out retInRetInf, out retInPrimePrice,
                        //    out retInRetSetParts, out retSetPrice, sqlConnection);
                        status = GetPartsInfByCtlgPtNoProcAutoAnswer(autoAnsItemStList, prmSettingUList, customerCode, sectionCode, substFlg, carMakerCd, paraList, out retInRetInf, out retInPrimePrice,
                            out retInRetSetParts, out retSetPrice, sqlConnection);
                        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ---------------------------->>>>>
                            //if (retInRetInf == null || retInRetInf.Count == 0) SetInRetInf(ref retInRetInf);
                            //inRetInf.Add(retInRetInf);
                            //if (retInPrimePrice == null || retInPrimePrice.Count == 0) SetInPrimePrice(ref retInPrimePrice);
                            //inPrimePrice.Add(retInPrimePrice);
                            //if (retInRetSetParts == null || retInRetSetParts.Count == 0) SetInRetSetParts(ref retInRetSetParts);
                            //inRetSetParts.Add(retInRetSetParts);
                            //if (retSetPrice == null || retSetPrice.Count == 0) SetSetPrice(ref retSetPrice);
                            //SetPrice.Add(retSetPrice);
                            if (retInRetInf == null || retInRetInf.Count == 0) SetInRetInf(ref retInRetInf);
                            inRetInfCustomSerializeArrayList.Add(retInRetInf);
                            if (retInPrimePrice == null || retInPrimePrice.Count == 0) SetInPrimePrice(ref retInPrimePrice);
                            inPrimePriceCustomSerializeArrayList.Add(retInPrimePrice);
                            if (retInRetSetParts == null || retInRetSetParts.Count == 0) SetInRetSetParts(ref retInRetSetParts);
                            inRetSetPartsCustomSerializeArrayList.Add(retInRetSetParts);
                            if (retSetPrice == null || retSetPrice.Count == 0) SetSetPrice(ref retSetPrice);
                            SetPriceCustomSerializeArrayList.Add(retSetPrice);
                            // UPD 2014/06/12 PM-SCM速度改良 フェーズ２ 障害対応 ----------------------------<<<<<
                        }
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                return status;
            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNoにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNoにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        ///  優良品番情報初期化設定
        /// </summary>
        /// <param name="retInRetInf"></param>
        private void SetInRetInf(ref ArrayList retInRetInf)
        {
            OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.GoodsMGroup = 0;
            mf.JoinDestMakerCd = 0;
            mf.JoinDestPartsNo = string.Empty;
            mf.JoinDispOrder = 0;
            mf.JoinQty = 0;
            mf.JoinSourceMakerCode = 0;
            mf.JoinSourPartsNoNoneH = string.Empty;
            mf.JoinSourPartsNoWithH = string.Empty;
            mf.JoinSpecialNote = string.Empty;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty; ;
            mf.PrimePartsName = string.Empty; ;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmSetDtlNo1 = 0;
            mf.PrmSetDtlNo2 = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetPartsFlg = 0;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            retInRetInf.Add(mf);
        }
        /// <summary>
        ///  優良品番価格情報初期化設定
        /// </summary>
        /// <param name="retInPrimePrice"></param>
        private void SetInPrimePrice(ref ArrayList retInPrimePrice)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            retInPrimePrice.Add(mf);

        }
        /// <summary>
        ///  セット品情報初期化設定
        /// </summary>
        /// <param name="retInRetSetParts"></param>
        private void SetInRetSetParts(ref ArrayList retInRetSetParts)
        {
            OfferSetPartsRetWork mf = new OfferSetPartsRetWork();

            mf.CatalogDeleteFlag = 0;
            mf.CatalogShapeNo = string.Empty;
            mf.GoodsMGroup = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.PartsAttribute = 0;
            mf.PartsLayerCd = string.Empty;
            mf.PrimePartsKanaName = string.Empty;
            mf.PrimePartsName = string.Empty;
            mf.PrimePartsSpecialNote = string.Empty;
            mf.PrmPartsIllustC = string.Empty;
            mf.PrmPrtTbsPrtCd = 0;
            mf.PrmPrtTbsPrtCdDerivNo = 0;
            mf.SearchPartsFullName = string.Empty;
            mf.SearchPartsHalfName = string.Empty;
            mf.SetDispOrder = 0;
            mf.SetMainMakerCd = 0;
            mf.SetMainPartsNo = string.Empty;
            mf.SetName = string.Empty;
            mf.SetQty = 0;
            mf.SetSpecialNote = string.Empty;
            mf.SetSubMakerCd = 0;
            mf.SetSubPartsNo = string.Empty;
            mf.SubstKubun = 0;
            mf.TbsPartsCdDerivedNo = 0;
            mf.TbsPartsCode = 0;

            retInRetSetParts.Add(mf);

        }
        /// <summary>
        ///  セット品価格情報初期化設定
        /// </summary>
        /// <param name="retSetPrice"></param>
        private void SetSetPrice(ref ArrayList retSetPrice)
        {
            OfferJoinPriceRetWork mf = new OfferJoinPriceRetWork();

            mf.NewPrice = 0;
            mf.OfferDate = DateTime.MinValue;
            mf.OpenPriceDiv = 0;
            mf.PartsMakerCd = 0;
            mf.PriceStartDate = DateTime.MinValue;
            mf.PrimePartsNoWithH = string.Empty;
            mf.PrmSetDtlNo1 = 0;

            retSetPrice.Add(mf);

        }

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応 ----------------------------------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="substFlg"></param>
        /// <param name="carMakerCd"></param>
        /// <param name="inPara"></param>
        /// <param name="inRetInf"></param>
        /// <param name="inPrimePrice"></param>
        /// <param name="inRetSetParts"></param>
        /// <param name="SetPrice"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetPartsInfByCtlgPtNoProc( bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
                out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList condListForJoin = (ArrayList)inPara.Clone();

            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            //純正品番をＫＥＹにして優良結合品番を検索
            status = SearchPrimePartsNo(carMakerCd, condListForJoin, out inRetInf, sqlConnection, null);

            if (status != 0)
            {
                return (status);
            }

            ArrayList listForSetSearch = new ArrayList();
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            ArrayList listForJoinSubst = new ArrayList(); // 結合代替の検索条件リスト (結合先情報)
            Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>(); // 結合代替の検索に使用する結合元情報ディクショナリ
            Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic;
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<
            if (substFlg) // 結合代替検索
            {
                ArrayList primeSubstList = new ArrayList();
                // 結合代替を全て探す。旧品番→新品番→(新品番->旧品番)→新品番→  10世代まで
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // 結合品の価格検索のため 
                    listForSetSearch.Add(condWork); // ここでセットマスタ検索用リストを予め作って置く。

                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    # region // DEL
                    //for ( int i = 1; i < 11; i++ )
                    //{
                    //    OfferJoinPartsRetWork primeSubstWork;
                    //    // 2010/01/25 >>>
                    //    //SearchJoinSubst(carMakerCd, condWork, out primeSubstWork, sqlConnection, null);
                    //    SearchJoinSubst( carMakerCd, wk, condWork, out primeSubstWork, sqlConnection, null );
                    //    // 2010/01/25 <<<
                    //    if ( primeSubstWork != null )
                    //    {
                    //        primeSubstList.Add( primeSubstWork );
                    //
                    //        condWork = new OfrPartsCondWork();
                    //        condWork.MakerCode = primeSubstWork.JoinDestMakerCd;
                    //        condWork.PrtsNo = primeSubstWork.JoinDestPartsNo;
                    //        condWork.PrtsNoOrg = primeSubstWork.JoinSourPartsNoWithH;
                    //        condListForJoin.Add( condWork ); // 結合代替品の価格検索のため !!!!!!!!
                    //    }
                    //    else
                    //    {
                    //        break;
                    //    }
                    //}
                    # endregion
                    // 結合代替の検索用リストに格納
                    listForJoinSubst.Add( condWork ); 
                    
                    // 結合元情報ディクショナリに格納
                    string key = GetJoinSrcInfoKey( condWork.MakerCode, condWork.PrtsNo );
                    if ( !joinSrcInfoDic.ContainsKey( key ) )
                    {
                        joinSrcInfoDic.Add( key, wk );
                    }
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                }
                // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                if ( listForJoinSubst.Count > 0 )
                {
                    // 結合代替検索(10世代)
                    for ( int i = 1; i < 11; i++ )
                    {
                        // 結合代替検索（世代が進むと joinSrcInfoDic と listForJoinSubst が差し替わる）
                        SearchJoinSubst( carMakerCd, joinSrcInfoDic, listForJoinSubst, out primeSubstList, out newJoinSrcInfoDic, sqlConnection, null );

                        // 検索結果をリストに格納
                        if ( primeSubstList != null && primeSubstList.Count > 0 )
                        {
                            // (次の世代へ)結合代替の検索条件リストを作成し直す
                            listForJoinSubst = new ArrayList();

                            foreach ( OfferJoinPartsRetWork primeSubstWork in primeSubstList )
                            {
                                OfrPartsCondWork condWork = new OfrPartsCondWork();
                                condWork.MakerCode = primeSubstWork.JoinDestMakerCd;
                                condWork.PrtsNo = primeSubstWork.JoinDestPartsNo;
                                condWork.PrtsNoOrg = primeSubstWork.JoinSourPartsNoWithH;

                                condListForJoin.Add( condWork ); // 結合代替品の価格検索の為、セット
                                listForJoinSubst.Add( condWork ); // 結合代替の次世代検索の為、セット
                            }

                            // (次の世代へ)結合元情報ディクショナリの差し替え
                            joinSrcInfoDic = newJoinSrcInfoDic;
                        }
                        else
                        {
                            // 該当がなかったら10世代分のループを終了
                            break;
                        }
                    }
                }
                // --- ADD m.suzuki 2012/01/31 ----------<<<<<
                inRetInf.AddRange(primeSubstList);
            }
            else // 代替検索しない場合、価格・セット検索のため以下のリスト作成を行う。
            {
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // 結合品の価格検索のため 
                    listForSetSearch.Add(condWork); // ここでセットマスタ検索用リストを予め作って置く。
                }
            }

            // 結合・結合代替の価格情報を取得する。
            SearchPartsPrice( condListForJoin, out inPrimePrice, sqlConnection, null );

            //セットマスタの読み込み
            status = SearchSetParts(carMakerCd, listForSetSearch, out inRetSetParts, sqlConnection, null);

            if (substFlg) // セット代替検索
            {
                ArrayList list = (ArrayList)inRetSetParts.Clone();

                // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                # region // DEL
                //// セット代替を全て探す。旧品番→新品番→(新品番->旧品番)→新品番→  10世代まで
                //foreach (OfferSetPartsRetWork wk in list)
                //{
                //    OfferSetPartsRetWork condWork = wk;
                //    for (int i = 1; i < 11; i++)
                //    {
                //        OfferSetPartsRetWork setSubst;
                //        SearchSetSubst(carMakerCd, condWork, out setSubst, sqlConnection, null);
                //        if (setSubst != null)
                //        {
                //            inRetSetParts.Add(setSubst);
                //
                //            condWork = new OfferSetPartsRetWork();
                //            condWork.SetMainPartsNo = setSubst.SetMainPartsNo;
                //            condWork.SetSubMakerCd = setSubst.SetSubMakerCd;
                //            condWork.SetSubPartsNo = setSubst.SetSubPartsNo;
                //        }
                //        else
                //        {
                //            break;
                //        }
                //    }
                //}
                # endregion

                if ( list.Count > 0 )
                {
                    // セット情報ディクショナリ生成
                    Dictionary<string, OfferSetPartsRetWork> setPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
                    foreach ( OfferSetPartsRetWork setPartsRetWork in inRetSetParts )
                    {
                        string key = GetSetPartsInfoKey( setPartsRetWork.SetSubMakerCd, setPartsRetWork.SetMainPartsNo, setPartsRetWork.SetSubPartsNo );
                        if ( !setPartsDic.ContainsKey( key ) )
                        {
                            setPartsDic.Add( key, setPartsRetWork );
                        }
                    }

                    ArrayList setSubstList;
                    Dictionary<string, OfferSetPartsRetWork> newSetPartsDic;

                    // セット代替検索(10世代)
                    for ( int i = 0; i < 11; i++ )
                    {
                        // セット代替検索
                        SearchSetSubst( carMakerCd, setPartsDic, list, out setSubstList, out newSetPartsDic, sqlConnection, null );

                        if ( setSubstList != null && setSubstList.Count > 0 )
                        {
                            // (次の世代へ)セット代替の検索条件リストを作成し直す
                            list = new ArrayList();
                            foreach ( OfferSetPartsRetWork setSubst in setSubstList )
                            {
                                inRetSetParts.Add( setSubst ); // セットの検索結果リストに追加

                                OfferSetPartsRetWork condWork = new OfferSetPartsRetWork();
                                condWork.SetMainPartsNo = setSubst.SetMainPartsNo;
                                condWork.SetSubMakerCd = setSubst.SetSubMakerCd;
                                condWork.SetSubPartsNo = setSubst.SetSubPartsNo;
                                list.Add( condWork );
                            }

                            // (次の世代へ)セット情報ディクショナリの差し替え
                            setPartsDic = newSetPartsDic;
                        }
                        else
                        {
                            // 該当がなかったら10世代分のループを終了
                            break;
                        }
                    }
                }
                // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            }

            // セット・セット代替の価格情報を取得する。
            ArrayList listForSetPrice = new ArrayList();
            foreach (OfferSetPartsRetWork wk in inRetSetParts)
            {
                OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                listForSetPrice.Add(ofrPartsCondWork);
            }
            SearchPartsPrice( listForSetPrice, out SetPrice, sqlConnection, null );

            return status;
        }
        #endregion

        # region 純正品番ＫＥＹ→優良結合部品検索
        /// <summary>
        /// 純正品番ＫＥＹ→優良部品検索
        /// </summary>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード</param>
        /// <param name="inWork">条件リスト</param>
        /// <param name="retWork">結果リスト</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchPrimePartsNo(int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            retWork = new ArrayList();

            if (inWork == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            if (inWork.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return SearchPrimePartsNoProc(carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
        }

        private int SearchPrimePartsNoProc(int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            try
            {
                //[単純に純正品に紐付く優良品を抽出]
                selectstr = "SELECT ";
                //selectstr += "JOINPARTSRF.OFFERDATERF, ";
                selectstr += "JOINPARTSRF.GOODSMGROUPRF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCODERF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCDDERIVEDNORF ";
                selectstr += ",JOINPARTSRF.PRMSETDTLNO1RF "; // セレクトコード
                selectstr += ",JOINPARTSRF.PRMSETDTLNO2RF "; // 種別コード
                selectstr += ",JOINPARTSRF.JOINDISPORDERRF ";
                selectstr += ",JOINPARTSRF.JOINSOURCEMAKERCODERF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNONONEHRF ";
                selectstr += ",JOINPARTSRF.JOINDESTMAKERCDRF ";
                selectstr += ",JOINPARTSRF.JOINDESTPARTSNORF ";
                selectstr += ",JOINPARTSRF.JOINQTYRF ";
                selectstr += ",JOINPARTSRF.SETPARTSFLGRF ";
                selectstr += ",JOINPARTSRF.JOINSPECIALNOTERF ";

                selectstr += ",PRIMEPARTSRF.OFFERDATERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF ";
                selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF ";
                selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF ";
                selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF ";

                if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                {
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                }

                selectstr += " FROM PRIMEPARTSRF INNER JOIN JOINPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = JOINPARTSRF.JOINDESTMAKERCDRF";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINPARTSRF.JOINDESTPARTSNORF ";

                if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                {
                    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (JOINPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                }

                selectstr += " WHERE ";

                foreach (OfrPartsCondWork wk in inWork)
                {
                    //メーカーコード
                    wherestr += " OR ( ";
                    wherestr += " JOINPARTSRF.JOINSOURCEMAKERCODERF = " + wk.MakerCode;
                    wherestr += " AND JOINPARTSRF.JOINSOURPARTSNOWITHHRF = '" + wk.PrtsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // 先頭のOR除去

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    //結合情報
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));    // セレクトコード
                    mf.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));    // 種別コード
                    mf.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));  //
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    mf.SetPartsFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    //優良情報
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }

                    retWork.Add(mf);
                }
                // ここまで正常処理されると0件の場合でも正常扱いする。
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPrimePartsNoProcにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// 結合代替検索処理
        /// </summary>
        /// <param name="carMakerCd"></param>
        /// <param name="joinSrcInfoDic"></param>
        /// <param name="inWorkList"></param>
        /// <param name="retWorkList"></param>
        /// <param name="newJoinSrcInfoDic"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchJoinSubst( int carMakerCd, Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            //----------------------------------------
            // 優良部品の検索結果の件数が多過ぎると、
            // クエリの最大文字数をオーバーする危険が有る為、
            // リストを分割して処理します。
            // 
            // メインとなる処理内容は「SearchJoinSubstProc」です。
            //----------------------------------------

            int status;
            int retStatus = 0;

            Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDicSub;
            ArrayList retWorkListSub;

            newJoinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>();
            retWorkList = new ArrayList();

            const int maxCount = 100; // 分割する件数
            
            for ( int startIndex = 0; startIndex < inWorkList.Count; startIndex += maxCount )
            {
                // 条件リストの分割（List->ListSub）
                ArrayList inWorkListSub = new ArrayList();
                inWorkListSub.AddRange( inWorkList.GetRange( startIndex, Math.Min( maxCount, inWorkList.Count - startIndex ) ) );

                // 検索実行
                status = SearchJoinSubstProc( carMakerCd, joinSrcInfoDic, inWorkListSub, out retWorkListSub, out newJoinSrcInfoDicSub, sqlConnection, sqlTransaction );
                if ( status != 0 && status != (int)ConstantManagement.DB_Status.ctDB_EOF )
                {
                    retStatus = status;
                }

                // 結果リストの統合（List<-ListSub）
                retWorkList.AddRange( retWorkListSub );

                // 結果ディクショナリの統合（Dic<-DicSub）
                foreach ( string key in newJoinSrcInfoDicSub.Keys )
                {
                    if ( !newJoinSrcInfoDic.ContainsKey( key ) )
                    {
                        newJoinSrcInfoDic.Add( key, newJoinSrcInfoDicSub[key] );
                    }
                }
            }

            // 該当が１件も無い場合
            if ( retWorkList.Count == 0 )
            {
                retStatus = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return retStatus;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<
        // --- UPD m.suzuki 2012/01/31 ---------->>>>>
        ///// <summary>
        ///// 結合代替検索処理
        ///// </summary>
        ///// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        ///// <param name="inWork">条件リスト</param>
        ///// <param name="joinSrcInfo">結合元情報</param>
        ///// <param name="retWork">結果リスト</param>
        ///// <param name="sqlConnection"></param>
        ///// <param name="sqlTransaction"></param>
        ///// <returns></returns>
        //// 2010/01/25 >>>
        ////private int SearchJoinSubst(int carMakerCd, OfrPartsCondWork inWork, out OfferJoinPartsRetWork retWork,
        ////    SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        //private int SearchJoinSubst(int carMakerCd, OfferJoinPartsRetWork joinSrcInfo, OfrPartsCondWork inWork, out OfferJoinPartsRetWork retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        //// 2010/01/25 <<<
        /// <summary>
        /// 結合代替検索処理
        /// </summary>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        /// <param name="joinSrcInfoDic">結合元情報</param>
        /// <param name="inWorkList">条件リスト</param>
        /// <param name="retWorkList">結果リスト</param>
        /// <param name="newJoinSrcInfoDic">結合元情報(次世代分)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns></returns>
        private int SearchJoinSubstProc( int carMakerCd, Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        // --- UPD m.suzuki 2012/01/31 ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            // --- DEL m.suzuki 2012/01/31 ---------->>>>>
            //retWork = null;
            // --- DEL m.suzuki 2012/01/31 ----------<<<<<

            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            retWorkList = new ArrayList();
            newJoinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>();
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<

            // 結合代替を検索
            selectstr = "SELECT ";
            // 2010/01/25 結合マスタは参照しない >>>
            //selectstr += "JOINPARTSRF.JOINSOURCEMAKERCODERF";
            //selectstr += ",JOINPARTSRF.JOINSOURPARTSNOWITHHRF";
            //selectstr += ",JOINPARTSRF.JOINDESTPARTSNORF";
            //selectstr += ",JOINPARTSRF.JOINDESTMAKERCDRF";
            //selectstr += ",JOINPARTSRF.JOINQTYRF ";
            //selectstr += ",PRIMEPARTSRF.OFFERDATERF";
            selectstr += "PRIMEPARTSRF.OFFERDATERF";
            // 2010/01/25 <<<
            selectstr += ",PRIMEPARTSRF.GOODSMGROUPRF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCODERF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF";
            selectstr += ",PRIMEPARTSRF.PRMSETDTLNO1RF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF";
            selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF";
            selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF";
            selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF";
            // 2010/01/25 Add >>>
            selectstr += ",JOINSUBSTRF.PARTSMAKERCODERF";
            // 2010/01/25 Add <<<
            selectstr += ",JOINSUBSTRF.JOINNEWPARTSNORF";
            selectstr += ",JOINSUBSTRF.JOINSUBSTSPECIALNOTERF ";
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            selectstr += ",JOINSUBSTRF.JOINOLDPARTSNORF ";
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<

            // 2010/01/25 検索品名は、純正情報で良いので削除 >>>
            //if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
            //{
            //    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
            //    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
            //}
            // 2010/01/25 Del <<<

            // 2010/01/25 >>>
            //selectstr += "FROM ";
            //selectstr += " JOINPARTSRF JOIN JOINSUBSTRF ON JOINPARTSRF.JOINDESTMAKERCDRF = JOINSUBSTRF.PARTSMAKERCODERF AND ";
            //selectstr += " JOINPARTSRF.JOINDESTPARTSNORF = JOINSUBSTRF.JOINOLDPARTSNORF ";
            //selectstr += " INNER JOIN PRIMEPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = JOINSUBSTRF.PARTSMAKERCODERF ";
            //selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINSUBSTRF.JOINNEWPARTSNORF ";

            selectstr += "FROM";
            selectstr += "  JOINSUBSTRF ";
            selectstr += "INNER JOIN PRIMEPARTSRF ON ";
            selectstr += "  PRIMEPARTSRF.PARTSMAKERCDRF = JOINSUBSTRF.PARTSMAKERCODERF";
            selectstr += "  AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINSUBSTRF.JOINNEWPARTSNORF";
            // 2010/01/25 <<<

            // 2010/01/25 検索品名は、純正情報で良いので削除 >>>
            //if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
            //{
            //    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (JOINPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
            //    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
            //}
            // 2010/01/25 Del <<<

            selectstr += " WHERE ";

            //メーカーコード
            // --- UPD m.suzuki 2012/01/31 ---------->>>>>
            //// 2010/01/25 >>>
            ////wherestr += " JOINPARTSRF.JOINDESTMAKERCDRF = " + inWork.MakerCode;
            ////wherestr += " AND JOINPARTSRF.JOINDESTPARTSNORF = '" + inWork.PrtsNo + "'";
            ////wherestr += " AND JOINPARTSRF.JOINSOURPARTSNOWITHHRF = '" + inWork.PrtsNoOrg + "'";
            //wherestr += "  JOINSUBSTRF.PARTSMAKERCODERF = " + inWork.MakerCode;
            //wherestr += "  AND JOINSUBSTRF.JOINOLDPARTSNORF = '" + inWork.PrtsNo + "'";
            //// 2010/01/25 <<<
            foreach ( OfrPartsCondWork wk in inWorkList )
            {
                wherestr += "OR ( JOINSUBSTRF.PARTSMAKERCODERF = " + wk.MakerCode + " AND ";
                wherestr += "JOINSUBSTRF.JOINOLDPARTSNORF = '" + wk.PrtsNo + "' ) ";
            }
            wherestr = wherestr.Substring( 3 ); // 先頭のOR除去
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                //if ( myReader.Read() )
                while ( myReader.Read() )
                // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    //結合情報
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));    // セレクトコード
                    //mf.PrmSetDtlNo2 = 0;//  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));    // 種別コード
                    //mf.JoinDispOrder = 0;// SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));  //
                    // 2010/01/25 >>>
                    //mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    //mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    //mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    //mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));

                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //mf.JoinSourceMakerCode = inWork.MakerCode;
                    //mf.JoinSourPartsNoWithH = inWork.PrtsNo;
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "JOINOLDPARTSNORF" ) );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                    // 結合元情報の取得
                    OfferJoinPartsRetWork joinSrcInfo;

                    string key = GetJoinSrcInfoKey( mf.JoinSourceMakerCode, mf.JoinSourPartsNoWithH );
                    if ( joinSrcInfoDic.ContainsKey( key ) )
                    {
                        joinSrcInfo = joinSrcInfoDic[key];
                    }
                    else
                    {
                        joinSrcInfo = new OfferJoinPartsRetWork();
                    }
                    // --- ADD m.suzuki 2012/01/31 ----------<<<<<

                    mf.JoinSourPartsNoNoneH = joinSrcInfo.JoinSourPartsNoNoneH; // 結合元品番（ハイフン無し）に、大元の結合元品番を入れないと正常に動かない...
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                    // 2010/01/25 <<<
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINNEWPARTSNORF"));
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //// 2010/01/25 >>>
                    ////mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF")); // 結合元のQTYを使っていいか？
                    //mf.JoinQty = joinSrcInfo.JoinQty;
                    //// 2010/01/25 <<<
                    mf.JoinQty = joinSrcInfo.JoinQty;
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    mf.SetPartsFlg = 0;// 見にいかない //  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSUBSTSPECIALNOTERF"));

                    //優良情報
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    if ( carMakerCd != 0 ) // 車メーカーコードあり　（検索品名検索する）
                    {
                        // 2010/01/25 >>>
                        //mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        //mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                        mf.SearchPartsFullName = joinSrcInfo.SearchPartsFullName;
                        mf.SearchPartsHalfName = joinSrcInfo.SearchPartsHalfName;
                        // 2010/01/25 <<<
                    }

                    mf.SubstKubun = 1;
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //retWork = mf;
                    retWorkList.Add( mf );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<

                    // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                    // 次の世代向けの結合元情報ディクショナリ
                    string newKey = GetJoinSrcInfoKey( mf.JoinDestMakerCd, mf.JoinDestPartsNo);
                    if ( !newJoinSrcInfoDic.ContainsKey( newKey ) )
                    {
                        newJoinSrcInfoDic.Add( newKey, joinSrcInfo );
                    }

                    // 処理ステータスセット(正常終了)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // --- ADD m.suzuki 2012/01/31 ----------<<<<<
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchJoinSubstにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }
        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// 結合元情報のディクショナリ用キー生成処理
        /// </summary>
        /// <param name="partsMakerCode"></param>
        /// <param name="joinOldPartsNoWithH"></param>
        /// <returns></returns>
        private string GetJoinSrcInfoKey( int partsMakerCode, string joinOldPartsNoWithH )
        {
            return partsMakerCode.ToString( "0000" ) + "'" + joinOldPartsNoWithH;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<
        # endregion

        # region セットマスタ検索
        /// <summary>
        /// セットマスタ検索
        /// </summary>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        /// <param name="inWork">条件リスト</param>
        /// <param name="retWork">結果リスト</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchSetParts(int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            retWork = new ArrayList();
            if (inWork == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            if (inWork.Count == 0)
            {
                return 0;
            }

            return SearchSetPartsProc(carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
        }

        private int SearchSetPartsProc(int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                //取得マスタ項目
                selectstr = OFFERSETPARTSRFSelectFields;
                if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                {
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                }
                //ＪＯＩＮ項目
                selectstr += " FROM PRIMEPARTSRF INNER JOIN SETPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = SETPARTSRF.SETSUBMAKERCDRF";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = SETPARTSRF.SETSUBPARTSNORF ";
                if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                {
                    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                }
                //ＷＨＥＲＥ項目
                selectstr += "WHERE ";

                //結合先メーカーコード・結合先品番 
                foreach (OfrPartsCondWork wk in inWork)
                {
                    wherestr += "OR ( SETPARTSRF.SETMAINMAKERCDRF = " + wk.MakerCode + " AND ";
                    wherestr += "SETPARTSRF.SETMAINPARTSNORF = '" + wk.PrtsNo + "' ) ";
                }
                wherestr = wherestr.Substring(3); // 先頭のOR除去

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
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
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    // 2009/11/24 Add >>>
                    mf.PrmPrtTbsPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMPRTTBSPRTCDRF"));
                    mf.PrmPrtTbsPrtCdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMPRTTBSPRTCDDERIVNORF"));
                    // 2009/11/24 Add <<<

                    if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }

                    retWork.Add(mf);
                }
                //if (retWork.Count > 0)
                //{
                // 取得件数が0件でも異常終了してはいけないので正常リターンする。
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPartsにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// セット代替検索
        /// </summary>
        /// <param name="carMakerCd"></param>
        /// <param name="setPartsDic"></param>
        /// <param name="inWorkList"></param>
        /// <param name="retWorkList"></param>
        /// <param name="newSetPartsDic"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchSetSubst( int carMakerCd, Dictionary<string, OfferSetPartsRetWork> setPartsDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferSetPartsRetWork> newSetPartsDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            //----------------------------------------
            // セットの検索結果の件数が多過ぎると、
            // クエリの最大文字数をオーバーする危険が有る為、
            // リストを分割して処理します。
            // 
            // メインとなる処理内容は「SearchSetSubstProc」です。
            //----------------------------------------

            int status;
            int retStatus = 0;

            Dictionary<string, OfferSetPartsRetWork> newSetPartsDicSub;
            ArrayList retWorkListSub;

            newSetPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
            retWorkList = new ArrayList();

            const int maxCount = 100; // 分割する件数

            for ( int startIndex = 0; startIndex < inWorkList.Count; startIndex += maxCount )
            {
                // 条件リストの分割（List->ListSub）
                ArrayList inWorkListSub = new ArrayList();
                inWorkListSub.AddRange( inWorkList.GetRange( startIndex, Math.Min( maxCount, inWorkList.Count - startIndex ) ) );

                // セット代替検索実行
                status = SearchSetSubstProc( carMakerCd, setPartsDic, inWorkListSub, out retWorkListSub, out newSetPartsDicSub, sqlConnection, sqlTransaction );
                if ( status != 0 && status != (int)ConstantManagement.DB_Status.ctDB_EOF )
                {
                    retStatus = status;
                }

                // 結果リストの統合（List<-ListSub）
                retWorkList.AddRange( retWorkListSub );

                // 結果ディクショナリの統合（Dic<-DicSub）
                foreach ( string key in newSetPartsDicSub.Keys )
                {
                    if ( !newSetPartsDic.ContainsKey( key ) )
                    {
                        newSetPartsDic.Add( key, newSetPartsDicSub[key] );
                    }
                }
            }

            // 該当が１件も無い場合
            if ( retWorkList.Count == 0 )
            {
                retStatus = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            
            return retStatus;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<

        // --- UPD m.suzuki 2012/01/31 ---------->>>>>
        ///// <summary>
        ///// セット代替検索
        ///// </summary>
        ///// <param name="carMakerCd"></param>
        ///// <param name="inWork"></param>
        ///// <param name="retWork"></param>
        ///// <param name="sqlConnection"></param>
        ///// <param name="sqlTransaction"></param>
        ///// <returns></returns>
        //private int SearchSetSubst(int carMakerCd, OfferSetPartsRetWork inWork, out OfferSetPartsRetWork retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        /// <summary>
        /// セット代替検索
        /// </summary>
        /// <param name="carMakerCd"></param>
        /// <param name="inWorkList"></param>
        /// <param name="retWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchSetSubstProc( int carMakerCd, Dictionary<string, OfferSetPartsRetWork> setPartsDic, ArrayList inWorkList, out ArrayList retWorkList, out Dictionary<string, OfferSetPartsRetWork> newSetPartsDic, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        // --- UPD m.suzuki 2012/01/31 ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            // --- UPD m.suzuki 2012/01/31 ---------->>>>>
            //retWork = null;
            retWorkList = new ArrayList();
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            newSetPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<

            #region クエリ作成
            // 結合代替を検索
            selectstr = "SELECT ";
            // --- DEL m.suzuki 2012/01/31 ---------->>>>>
            //selectstr += "SETPARTSRF.SETMAINMAKERCDRF";
            //selectstr += ",SETPARTSRF.SETSUBPARTSNORF";
            //selectstr += ",SETPARTSRF.SETSUBMAKERCDRF";
            //selectstr += ",SETPARTSRF.SETDISPORDERRF";
            //selectstr += ",SETPARTSRF.SETSPECIALNOTERF";
            //selectstr += ",SETPARTSRF.SETNAMERF";
            //selectstr += ",SETPARTSRF.CATALOGSHAPENORF";
            // --- DEL m.suzuki 2012/01/31 ----------<<<<<
            // --- ADD m.suzuki 2012/01/31 ---------->>>>>
            selectstr += "SETSUBSTRF.SETMAINPARTSNORF ";
            selectstr += ",SETSUBSTRF.PARTSMAKERCODERF ";
            selectstr += ",SETSUBSTRF.SETOLDPARTSNORF ";
            // --- ADD m.suzuki 2012/01/31 ----------<<<<<
            selectstr += ",PRIMEPARTSRF.OFFERDATERF";
            selectstr += ",PRIMEPARTSRF.GOODSMGROUPRF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCODERF";
            selectstr += ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF";
            selectstr += ",PRIMEPARTSRF.PRMSETDTLNO1RF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF";
            selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF";
            selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF";
            selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF";
            selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF";
            selectstr += ",SETSUBSTRF.SETNEWPARTSNORF";
            selectstr += ",SETSUBSTRF.SETSUBSTSPECIALNOTERF ";
            if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
            {
                selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
            }
            selectstr += "FROM ";
            // --- UPD m.suzuki 2012/01/31 ---------->>>>>
            //selectstr += " SETPARTSRF JOIN SETSUBSTRF ON SETPARTSRF.SETSUBMAKERCDRF = SETSUBSTRF.PARTSMAKERCODERF AND ";
            //selectstr += " SETPARTSRF.SETMAINPARTSNORF = SETSUBSTRF.SETMAINPARTSNORF AND ";
            //selectstr += " SETPARTSRF.SETSUBPARTSNORF = SETSUBSTRF.SETOLDPARTSNORF ";
            selectstr += " SETSUBSTRF ";
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            selectstr += " INNER JOIN PRIMEPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = SETSUBSTRF.PARTSMAKERCODERF ";
            selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = SETSUBSTRF.SETNEWPARTSNORF ";
            if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
            {
                selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (PRIMEPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
            }
            selectstr += " WHERE ";

            // --- UPD m.suzuki 2012/01/31 ---------->>>>>「
            ////foreach (OfrPartsCondWork wk in inWork)
            ////{
            ////メーカーコード
            ////wherestr += " OR ( ";
            //wherestr += " SETSUBSTRF.PARTSMAKERCODERF = " + inWork.SetSubMakerCd;
            //wherestr += " AND SETSUBSTRF.SETMAINPARTSNORF = '" + inWork.SetMainPartsNo + "'";
            //wherestr += " AND SETSUBSTRF.SETOLDPARTSNORF = '" + inWork.SetSubPartsNo + "'";
            ////wherestr += " ) ";
            ////}
            ////wherestr = wherestr.Substring(3); // 先頭のOR除去
            foreach ( OfferSetPartsRetWork wk in inWorkList )
            {
                wherestr += "OR ( SETSUBSTRF.PARTSMAKERCODERF = " + wk.SetSubMakerCd + " AND ";
                wherestr += "SETSUBSTRF.SETMAINPARTSNORF = '" + wk.SetMainPartsNo + "' AND ";
                wherestr += "SETSUBSTRF.SETOLDPARTSNORF = '" + wk.SetSubPartsNo + "' ) ";
            }
            wherestr = wherestr.Substring( 3 ); // 先頭のOR除去
            // --- UPD m.suzuki 2012/01/31 ----------<<<<<
            #endregion
            try
            {
                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();
                // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                //if ( myReader.Read() )
                while ( myReader.Read() )
                // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                {
                    OfferSetPartsRetWork mf = new OfferSetPartsRetWork();

                    //セットマスタ
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetMainMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETMAINMAKERCDRF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetMainPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSUBPARTSNORF"));
                    mf.SetMainPartsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SETMAINPARTSNORF" ) );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETSUBMAKERCDRF"));
                    mf.SetSubMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                    mf.SetSubPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNEWPARTSNORF"));
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETDISPORDERRF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<
                    mf.SetQty = 0;// SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETQTYRF"));
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETNAMERF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<
                    // --- DEL m.suzuki 2012/01/31 ---------->>>>>
                    //mf.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    //mf.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
                    // --- DEL m.suzuki 2012/01/31 ----------<<<<<

                    // --- ADD m.suzuki 2012/01/31 ---------->>>>>
                    // 元になっているセットマスタを取得する
                    string setOldPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETOLDPARTSNORF"));
                    OfferSetPartsRetWork setParts;
                    string key = GetSetPartsInfoKey( mf.SetSubMakerCd, mf.SetMainPartsNo, setOldPartsNo );
                    if ( setPartsDic.ContainsKey( key ) )
                    {
                        setParts = setPartsDic[key];
                    }
                    else
                    {
                        setParts = new OfferSetPartsRetWork();
                    }
                    // セットマスタからの取得
                    mf.SetMainMakerCd = setParts.SetMainMakerCd;
                    mf.SetDispOrder = setParts.SetDispOrder;
                    mf.SetName = setParts.SetName;
                    mf.SetSpecialNote = setParts.SetSpecialNote;
                    mf.CatalogShapeNo = setParts.CatalogShapeNo;
                    // --- ADD m.suzuki 2012/01/31 ----------<<<<<

                    //優良部品マスタ
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }
                    mf.SubstKubun = 1;

                    // --- UPD m.suzuki 2012/01/31 ---------->>>>>
                    //retWork = mf;
                    retWorkList.Add( mf );

                    // ディクショナリの再生成（次の世代へ）
                    string newKey = GetSetPartsInfoKey( mf.SetSubMakerCd, mf.SetMainPartsNo, mf.SetSubPartsNo );
                    if ( !newSetPartsDic.ContainsKey( newKey ) )
                    {
                        newSetPartsDic.Add( newKey, setParts );
                    }

                    // 処理ステータスセット(正常終了)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // --- UPD m.suzuki 2012/01/31 ----------<<<<<
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchSetSubstにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }
        // --- ADD m.suzuki 2012/01/31 ---------->>>>>
        /// <summary>
        /// セット情報のディクショナリ用キー生成処理
        /// </summary>
        /// <param name="partsMakerCode"></param>
        /// <param name="setMainPartsNo"></param>
        /// <param name="setSubPartsNo"></param>
        /// <returns></returns>
        private string GetSetPartsInfoKey( int partsMakerCode, string setMainPartsNo, string setSubPartsNo )
        {
            return partsMakerCode.ToString( "0000" ) + "'" + setMainPartsNo + "'" + setSubPartsNo;
        }
        // --- ADD m.suzuki 2012/01/31 ----------<<<<<
        # endregion

        /// <summary>
        /// 品名取得(全角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        public int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name,0);
        }

        /// <summary>
        /// 品名取得(半角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        public int GetPartsNameKana(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name,1);
        }

        private int GetPartsNameProc(int makerCd, string partsNo, out string name, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string nameString = "";
            if (mode == 0)
            {
                nameString = "PRIMEPARTSNAMERF";
            }
            else
            {
                nameString = "PRIMEPARTSKANANMRF";
            }

            string query = "SELECT " + nameString +" PRIMEPARTSNAMERF FROM PRIMEPARTSRF "
                         + "WHERE PRIMEPARTSNOWITHHRF = @PARTSNO AND PARTSMAKERCDRF = @MAKERCODE ";
            name = string.Empty;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return 99;
            }
            sqlConnection.Open();

            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                ((SqlParameter)sqlCommand.Parameters.Add("@PARTSNO", SqlDbType.NVarChar)).Value = partsNo;
                ((SqlParameter)sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int)).Value = makerCd;
                object ret = sqlCommand.ExecuteScalar();
                if (ret != null)
                {
                    name = ret.ToString();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }

            return status;
        }
        # endregion

        # region ＰＲＩＶＡＴＥ定義

        #region 価格取得
        /// <summary>
        /// 価格取得
        /// </summary>
        /// <param name="priceDate"></param>
        /// <param name="inWork"></param>
        /// <param name="retWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchPartsPrice( ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;
            retWork = new ArrayList();

            if (inWork == null || inWork.Count == 0)
            {
                return status;
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

                foreach ( OfrPartsCondWork wk in inWork )
                {
                    //メーカーコード
                    wherestr += " OR ( ";
                    wherestr += " PRMPRTPRICERF.PARTSMAKERCDRF = " + wk.MakerCode;
                    wherestr += " AND PRMPRTPRICERF.PRIMEPARTSNOWITHHRF = '" + wk.PrtsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // 先頭のOR除去
                wherestr += "ORDER BY PRICESTARTDATERF DESC";

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

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
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPartsPriceにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;

        }
        #endregion

        # region 優良品番ＫＥＹ→優良品番検索
        /// <summary>
        /// 優良品番ＫＥＹ→優良部品検索[価格処理追加要り]
        /// </summary>
        /// <param name="inPara">検索条件</param>
        /// <param name="retWork">検索結果</param>
        /// <param name="sqlConnection">コンネクション</param>
        /// <returns></returns>
        private int SearchPrimePartsNo(GetPrimePartsInfPara inPara, out ArrayList retWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;
            string queryCol = string.Empty;
            SqlDataReader myReader = null;

            string partsNo = inPara.PrtsNoNoneHyphen;
            int partsMakerCode = inPara.PartsMakerCode;

            retWork = new ArrayList();

            try
            {
                if (inPara.PrtsNoNoneHyphen.Contains("-"))
                {
                    queryCol = "PRIMEPARTSNOWITHHRF";
                }
                else
                {
                    queryCol = "PRIMEPARTSNONONEHRF";
                }

                //[提供商品品番曖昧検索]
                selectstr = "SELECT TOP(100) ";
                selectstr += "PRIMEPARTSRF.OFFERDATERF, ";
                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PRIMEPARTSRF.PRMSETDTLNO1RF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNONONEHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSKANANMRF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";
                selectstr += "PRIMEPARTSRF.PARTSATTRIBUTERF, ";
                selectstr += "PRIMEPARTSRF.CATALOGDELETEFLAGRF, ";
                selectstr += "PRIMEPARTSRF.PRMPARTSILLUSTCRF ";

                selectstr += " FROM PRIMEPARTSRF ";

                //////////////////////////////////////////////////////////////////////////////////////
                switch (inPara.SearchType)
                {
                    case 0: // 完全一致
                        wherestr = " WHERE PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = @PARTSNORF ";
                        break;
                    case 1: // 前方一致
                        partsNo = partsNo + "%";
                        wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @PARTSNORF ";
                        break;
                    case 2: // 後方一致
                        partsNo = "%" + partsNo;
                        wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @PARTSNORF ";
                        break;
                    case 3: // 曖昧検索
                        partsNo = "%" + partsNo + "%";
                        wherestr = " WHERE PRIMEPARTSRF." + queryCol + " LIKE @PARTSNORF ";
                        break;
                    case 4: // ハイフン無し完全一致
                        wherestr = " WHERE PRIMEPARTSRF.PRIMEPARTSNONONEHRF = @PARTSNORF ";
                        break;
                }
                if (inPara.PartsMakerCode != 0)
                    wherestr += "AND PRIMEPARTSRF.PARTSMAKERCDRF = @PARTSMAKERCDRF";
                //////////////////////////////////////////////////////////////////////////////////////
                selectstr += wherestr;

                selectstr += " ORDER BY PRIMEPARTSRF.PARTSMAKERCDRF, PRIMEPARTSRF.PRIMEPARTSNOWITHHRF";

                // Prameterオブジェクトの作成
                SqlCommand sqlCommand = new SqlCommand(selectstr, sqlConnection);
                SqlParameter ptno = sqlCommand.Parameters.Add("@PARTSNORF", SqlDbType.NVarChar);
                // Parameterオブジェクトへ値設定
                ptno.Value = SqlDataMediator.SqlSetString(partsNo);

                if (partsMakerCode != 0)
                {
                    SqlParameter mkcd = sqlCommand.Parameters.Add("@PARTSMAKERCDRF", SqlDbType.Int);
                    mkcd.Value = SqlDataMediator.SqlSetInt(partsMakerCode);
                }

                // Parameterオブジェクトへ値設定

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRMSETDTLNO1RF" ) );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = mf.JoinSourceMakerCode;
                    mf.JoinDestPartsNo = mf.JoinSourPartsNoWithH;
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    mf.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));
                    
                    retWork.Add(mf);
                }
                //if (retWork.Count > 0)
                //{
                // 取得件数が0件でも異常終了してはいけないので正常リターンする。
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPrimePartsNoにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        # endregion

        # region セットマスタ取得項目定義
        // セットマスタ取得項目定義
        private string OFFERSETPARTSRFSelectFields = "SELECT "
            //セットマスタ
            //+ "SETPARTSRF.OFFERDATERF, "
            + "SETPARTSRF.GOODSMGROUPRF"
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
            + ",PRIMEPARTSRF.OFFERDATERF"
            // 2009/11/24 Add >>>
            + ",PRIMEPARTSRF.TBSPARTSCODERF AS PRMPRTTBSPRTCDRF"
            + ",PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF AS PRMPRTTBSPRTCDDERIVNORF"
            // 2009/11/24 Add <<<
            + ",PRIMEPARTSRF.PRIMEPARTSNAMERF"
            + ",PRIMEPARTSRF.PRIMEPARTSKANANMRF"
            + ",PRIMEPARTSRF.PARTSLAYERCDRF"
            + ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF"
            + ",PRIMEPARTSRF.PARTSATTRIBUTERF"
            + ",PRIMEPARTSRF.CATALOGDELETEFLAGRF ";
        # endregion

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        # endregion

#if Kill0618
        /// <summary>
        /// 優良・セット代替検索
        /// </summary>
        /// <param name="inPara">検索条件リスト</param>
        /// <param name="retSubstParts">代替部品リスト</param>
        /// <param name="retSubstPrice">代替部品価格リスト</param>
        /// <returns></returns>
        public int GetJoinSubst(ArrayList inPara, out ArrayList retSubstParts, out ArrayList retSubstPrice)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retSubstParts = new ArrayList();
            retSubstPrice = new ArrayList();

            SqlConnection sqlConnection = null;

            try
            {
                SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
                string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                {
                    return 99;
                }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchPrimePartsNo(condListForJoin, out inRetInf, sqlConnection, null);

                if (status != 0)
                {
                    return (status);
                }

                //セットマスタの読み込み
                ArrayList listForSetSearch = new ArrayList();
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.JoinDestMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.JoinDestPartsNo;
                    listForSetSearch.Add(ofrPartsCondWork);
                }
                status = SearchSetParts(listForSetSearch, out inRetSetParts, sqlConnection, null);

                // セット代替を全て探す。
                ArrayList inputList = (ArrayList)inRetSetParts.Clone();
                ArrayList setSubstList;
                do
                {
                    setSubstList = new ArrayList();
                    SearchSetSubst(inputList, out setSubstList, sqlConnection, null);
                    if (setSubstList.Count > 0)
                    {
                        inRetSetParts.AddRange(setSubstList);

                        inputList = new ArrayList();
                        foreach (OfferSetPartsRetWork work in setSubstList)
                        {
                            OfferSetPartsRetWork condWork = new OfferSetPartsRetWork();
                            condWork.SetMainPartsNo = work.SetMainPartsNo;
                            condWork.SetSubMakerCd = work.SetSubMakerCd;
                            condWork.SetSubPartsNo = work.SetSubPartsNo;
                            inputList.Add(condWork);
                            //retSetParts.Add(condWork); // セット代替品の価格検索のため !!!!!!!!
                        }
                    }
                } while (setSubstList.Count > 0);

                // セット・セット代替の価格情報を取得する。
                ArrayList listForSetPrice = new ArrayList();
                foreach (OfferSetPartsRetWork wk in inRetSetParts)
                {
                    OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                    ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                    ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                    listForSetPrice.Add(ofrPartsCondWork);
                }
                SearchPartsPrice(listForSetPrice, out SetPrice, sqlConnection, null);

                // 結合代替を全て探す。旧品番→新品番→(新品番->旧品番)→新品番→
                inputList = (ArrayList)condListForJoin.Clone();
                ArrayList primeSubstList;
                do
                {
                    primeSubstList = new ArrayList();
                    SearchJoinSubst(inputList, out primeSubstList, sqlConnection, null);
                    if (primeSubstList.Count > 0)
                    {
                        inRetInf.AddRange(primeSubstList);

                        inputList = new ArrayList();
                        foreach (OfferJoinPartsRetWork work in primeSubstList)
                        {
                            OfrPartsCondWork condWork = new OfrPartsCondWork();
                            condWork.MakerCode = work.JoinDestMakerCd;
                            condWork.PrtsNo = work.JoinDestPartsNo;
                            inputList.Add(condWork);
                            condListForJoin.Add(condWork); // 結合代替品の価格検索のため !!!!!!!!
                        }
                    }
                } while (primeSubstList.Count > 0);

                // 結合・結合代替の価格情報を取得する。
                SearchPartsPrice(condListForJoin, out inPrimePrice, sqlConnection, null);

            }
            catch (SqlException ex)
            {
                return base.WriteSQLErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNoにてSQLエラー発生 Msg=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.GetPartsInfByCtlgPtNoにてエラー発生 Msg=" + ex.Message, 0);
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
            return status;
        }
#endif

        // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // DEL 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        ///// <summary> 自動回答品目設定リスト（自動回答専用） </summary>
        //private List<AutoAnsItemStForOffer> autoAnsItemStList = null;
        ///// <summary> 優先設定リスト（自動回答専用）</summary>
        //private List<PrmSettingUForOffer> prmSettingUList = null;
        ///// <summary> PM.NS 得意先コード（自動回答専用）</summary>
        //private int customerCode = 0;
        ///// <summary> PM.NS 拠点コード(Trim済)（自動回答専用） </summary>
        //private string sectionCode = string.Empty;
        // DEL 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

        /// <summary>
        /// 自動回答専用 各種プロパティ キャッシュ処理
        /// </summary>
        /// <param name="sectionCodeWk">拠点コード</param>
        /// <param name="customerCodeWk">得意先コード</param>
        /// <param name="obAutoAnsItemStList">自動回答品目設定リスト</param>
        /// <param name="obPrmSettingList">優先設定リスト</param>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //public void CacheAutoAnswer(string sectionCodeWk, int customerCodeWk, List<object> obAutoAnsItemStList, List<object> obPrmSettingList)
        private void CacheAutoAnswer(string sectionCodeWk, int customerCodeWk, List<object> obAutoAnsItemStList, List<object> obPrmSettingList,
                                    ref List<AutoAnsItemStForOffer> autoAnsItemStList, ref List<PrmSettingUForOffer> prmSettingUList, out int customerCode, out string sectionCode)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            // 自動回答品目設定リスト 設定
            // DEL 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            //autoAnsItemStList = new List<AutoAnsItemStForOffer>();
            // DEL 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
            foreach (List<object> tgt in obAutoAnsItemStList)
            {
                AutoAnsItemStForOffer wk = new AutoAnsItemStForOffer();
                wk.SectionCode = tgt[0].ToString().Trim();	// 拠点コード
                wk.CustomerCode = (int)tgt[1];      // 得意先コード
                wk.GoodsMGroup = (int)tgt[2];		// 商品中分類コード
                wk.BLGoodsCode = (int)tgt[3];       // BL商品コード
                wk.GoodsMakerCd = (int)tgt[4];      // 商品メーカーコード
                wk.PrmSetDtlNo2 = (int)tgt[5];      // 優良設定詳細コード２
                wk.AutoAnswerDiv = (int)tgt[6];     // 自動回答区分
                wk.PriorityOrder = (int)tgt[7];     // 優先順位
        
                autoAnsItemStList.Add(wk);
            }
        
            // 優良設定リスト 設定
            // DEL 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            //prmSettingUList = new List<PrmSettingUForOffer>();
            // DEL 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            foreach (List<object> tgt in obPrmSettingList)
            {
                PrmSettingUForOffer wk = new PrmSettingUForOffer();
                wk.GoodsMGroup = (int)tgt[0];   // 商品中分類コード
                wk.TbsPartsCode = (int)tgt[1];  // BLコード
                wk.PartsMakerCd = (int)tgt[2];  // 部品メーカーコード
                wk.PrmSetDtlNo1 = (int)tgt[3];  // 優良設定詳細コード１
                wk.PrmSetDtlNo2 = (int)tgt[4];  // 優良設定詳細コード２
                wk.PrimeDisplayCode = (int)tgt[5];  // 優良表示区分プロパティ
        
                prmSettingUList.Add(wk);
            }

            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            //this.customerCode = customerCodeWk;
            //this.sectionCode = sectionCodeWk.Trim();
            customerCode = customerCodeWk;
            sectionCode = sectionCodeWk.Trim();
            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        }

        // DEL 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        ///// <summary>
        ///// 自動回答専用 各種プロパティ キャッシュクリア
        ///// </summary>
        //public void CacheClearAutoAnswer()
        //{
        //    // 自動回答品目設定リスト 設定
        //    autoAnsItemStList = null;
        //
        //    // 優良設定リスト 設定
        //    prmSettingUList = null;
        //    customerCode = 0;
        //    sectionCode = string.Empty;
        //}
        // DEL 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

        /// <summary>
        /// 自動回答専用　優良品番検索 DBリモートオブジェクト[純正品番　→　結合検索]
        /// </summary>
        /// <param name="substFlg">代替フラグ[true:する/false:しない]</param>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</param>
        /// <param name="inPara">検索パラメータ</param>		
        /// <param name="inRetInf">部品情報</param>
        /// <param name="inPrimePrice">優良価格リスト</param>
        /// <param name="inRetSetParts">セット部品情報</param>
        /// <param name="SetPrice">セット価格</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>0:正常終了 4:NOT FOUND その他:エラー</returns>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //private int GetPartsInfByCtlgPtNoProcAutoAnswer(bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
        //        out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection)
        private int GetPartsInfByCtlgPtNoProcAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, List<PrmSettingUForOffer> prmSettingUList, int customerCode, string sectionCode, 
                bool substFlg, int carMakerCd, ArrayList inPara, out ArrayList inRetInf,
                out ArrayList inPrimePrice, out ArrayList inRetSetParts, out ArrayList SetPrice, SqlConnection sqlConnection)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList condListForJoin = (ArrayList)inPara.Clone();

            inRetInf = new ArrayList();
            inPrimePrice = new ArrayList();
            inRetSetParts = new ArrayList();
            SetPrice = new ArrayList();

            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            //純正品番をＫＥＹにして優良結合品番を検索
            //status = SearchPrimePartsNoAutoAnswer(carMakerCd, condListForJoin, out inRetInf, sqlConnection, null);
            status = SearchPrimePartsNoAutoAnswer(autoAnsItemStList, prmSettingUList, customerCode, sectionCode, carMakerCd, condListForJoin, out inRetInf, sqlConnection, null);
            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

            if (status != 0)
            {
                return (status);
            }

            ArrayList listForSetSearch = new ArrayList();
            ArrayList listForJoinSubst = new ArrayList(); // 結合代替の検索条件リスト (結合先情報)
            Dictionary<string, OfferJoinPartsRetWork> joinSrcInfoDic = new Dictionary<string, OfferJoinPartsRetWork>(); // 結合代替の検索に使用する結合元情報ディクショナリ
            Dictionary<string, OfferJoinPartsRetWork> newJoinSrcInfoDic;
            if (substFlg) // 結合代替検索
            {
                ArrayList primeSubstList = new ArrayList();
                // 結合代替を全て探す。旧品番→新品番→(新品番->旧品番)→新品番→  10世代まで
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // 結合品の価格検索のため 
                    listForSetSearch.Add(condWork); // ここでセットマスタ検索用リストを予め作って置く。

                    # region // DEL
                    # endregion
                    // 結合代替の検索用リストに格納
                    listForJoinSubst.Add(condWork);

                    // 結合元情報ディクショナリに格納
                    string key = GetJoinSrcInfoKey(condWork.MakerCode, condWork.PrtsNo);
                    if (!joinSrcInfoDic.ContainsKey(key))
                    {
                        joinSrcInfoDic.Add(key, wk);
                    }
                }
                if (listForJoinSubst.Count > 0)
                {
                    // 結合代替検索(10世代)
                    for (int i = 1; i < 11; i++)
                    {
                        // 結合代替検索（世代が進むと joinSrcInfoDic と listForJoinSubst が差し替わる）
                        SearchJoinSubst(carMakerCd, joinSrcInfoDic, listForJoinSubst, out primeSubstList, out newJoinSrcInfoDic, sqlConnection, null);

                        // 検索結果をリストに格納
                        if (primeSubstList != null && primeSubstList.Count > 0)
                        {
                            // (次の世代へ)結合代替の検索条件リストを作成し直す
                            listForJoinSubst = new ArrayList();

                            foreach (OfferJoinPartsRetWork primeSubstWork in primeSubstList)
                            {
                                OfrPartsCondWork condWork = new OfrPartsCondWork();
                                condWork.MakerCode = primeSubstWork.JoinDestMakerCd;
                                condWork.PrtsNo = primeSubstWork.JoinDestPartsNo;
                                condWork.PrtsNoOrg = primeSubstWork.JoinSourPartsNoWithH;

                                condListForJoin.Add(condWork); // 結合代替品の価格検索の為、セット
                                listForJoinSubst.Add(condWork); // 結合代替の次世代検索の為、セット
                            }

                            // (次の世代へ)結合元情報ディクショナリの差し替え
                            joinSrcInfoDic = newJoinSrcInfoDic;
                        }
                        else
                        {
                            // 該当がなかったら10世代分のループを終了
                            break;
                        }
                    }
                }
                inRetInf.AddRange(primeSubstList);
            }
            else // 代替検索しない場合、価格・セット検索のため以下のリスト作成を行う。
            {
                foreach (OfferJoinPartsRetWork wk in inRetInf)
                {
                    OfrPartsCondWork condWork = new OfrPartsCondWork();
                    condWork.MakerCode = wk.JoinDestMakerCd;
                    condWork.PrtsNo = wk.JoinDestPartsNo;
                    condWork.PrtsNoOrg = wk.JoinSourPartsNoWithH;
                    condListForJoin.Add(condWork); // 結合品の価格検索のため 
                    listForSetSearch.Add(condWork); // ここでセットマスタ検索用リストを予め作って置く。
                }
            }

            // 結合・結合代替の価格情報を取得する。
            SearchPartsPrice(condListForJoin, out inPrimePrice, sqlConnection, null);

            //セットマスタの読み込み
            status = SearchSetParts(carMakerCd, listForSetSearch, out inRetSetParts, sqlConnection, null);

            if (substFlg) // セット代替検索
            {
                ArrayList list = (ArrayList)inRetSetParts.Clone();

                if (list.Count > 0)
                {
                    // セット情報ディクショナリ生成
                    Dictionary<string, OfferSetPartsRetWork> setPartsDic = new Dictionary<string, OfferSetPartsRetWork>();
                    foreach (OfferSetPartsRetWork setPartsRetWork in inRetSetParts)
                    {
                        string key = GetSetPartsInfoKey(setPartsRetWork.SetSubMakerCd, setPartsRetWork.SetMainPartsNo, setPartsRetWork.SetSubPartsNo);
                        if (!setPartsDic.ContainsKey(key))
                        {
                            setPartsDic.Add(key, setPartsRetWork);
                        }
                    }

                    ArrayList setSubstList;
                    Dictionary<string, OfferSetPartsRetWork> newSetPartsDic;

                    // セット代替検索(10世代)
                    for (int i = 0; i < 11; i++)
                    {
                        // セット代替検索
                        SearchSetSubst(carMakerCd, setPartsDic, list, out setSubstList, out newSetPartsDic, sqlConnection, null);

                        if (setSubstList != null && setSubstList.Count > 0)
                        {
                            // (次の世代へ)セット代替の検索条件リストを作成し直す
                            list = new ArrayList();
                            foreach (OfferSetPartsRetWork setSubst in setSubstList)
                            {
                                inRetSetParts.Add(setSubst); // セットの検索結果リストに追加

                                OfferSetPartsRetWork condWork = new OfferSetPartsRetWork();
                                condWork.SetMainPartsNo = setSubst.SetMainPartsNo;
                                condWork.SetSubMakerCd = setSubst.SetSubMakerCd;
                                condWork.SetSubPartsNo = setSubst.SetSubPartsNo;
                                list.Add(condWork);
                            }

                            // (次の世代へ)セット情報ディクショナリの差し替え
                            setPartsDic = newSetPartsDic;
                        }
                        else
                        {
                            // 該当がなかったら10世代分のループを終了
                            break;
                        }
                    }
                }
            }

            // セット・セット代替の価格情報を取得する。
            ArrayList listForSetPrice = new ArrayList();
            foreach (OfferSetPartsRetWork wk in inRetSetParts)
            {
                OfrPartsCondWork ofrPartsCondWork = new OfrPartsCondWork();
                ofrPartsCondWork.MakerCode = wk.SetSubMakerCd;
                ofrPartsCondWork.PrtsNo = wk.SetSubPartsNo;
                listForSetPrice.Add(ofrPartsCondWork);
            }
            SearchPartsPrice(listForSetPrice, out SetPrice, sqlConnection, null);

            return status;
        }

        /// <summary>
        /// 自動回答専用　純正品番ＫＥＹ→優良部品検索
        /// </summary>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード</param>
        /// <param name="inWork">条件リスト</param>
        /// <param name="retWork">結果リスト</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>0:正常終了 4:NOT FOUND その他:エラー</returns>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //public int SearchPrimePartsNoAutoAnswer(int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        private int SearchPrimePartsNoAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, List<PrmSettingUForOffer> prmSettingUList, int customerCode, string sectionCode, int carMakerCd, ArrayList inWork, out ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            retWork = new ArrayList();

            if (inWork == null)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            if (inWork.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            //return SearchPrimePartsNoProcAutoAnswer(carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
            return SearchPrimePartsNoProcAutoAnswer(autoAnsItemStList, prmSettingUList, customerCode, sectionCode, carMakerCd, inWork, ref retWork, sqlConnection, sqlTransaction);
            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        }

        /// <summary>
        /// 自動回答専用　純正品番ＫＥＹ→優良部品検索
        /// </summary>
        /// <param name="carMakerCd">検索品名検索用車メーカーコード</param>
        /// <param name="inWork">条件リスト</param>
        /// <param name="retWork">結果リスト</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>0:正常終了 4:NOT FOUND その他:エラー</returns>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //private int SearchPrimePartsNoProcAutoAnswer(int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        private int SearchPrimePartsNoProcAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, List<PrmSettingUForOffer> prmSettingUList, int customerCode, string sectionCode, int carMakerCd, ArrayList inWork, ref ArrayList retWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string selectstr = string.Empty;
            string wherestr = string.Empty;

            SqlDataReader myReader = null;

            try
            {
                //[単純に純正品に紐付く優良品を抽出]
                selectstr = "SELECT ";
                //selectstr += "JOINPARTSRF.OFFERDATERF, ";
                selectstr += "JOINPARTSRF.GOODSMGROUPRF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCODERF ";
                selectstr += ",JOINPARTSRF.TBSPARTSCDDERIVEDNORF ";
                selectstr += ",JOINPARTSRF.PRMSETDTLNO1RF "; // セレクトコード
                selectstr += ",JOINPARTSRF.PRMSETDTLNO2RF "; // 種別コード
                selectstr += ",JOINPARTSRF.JOINDISPORDERRF ";
                selectstr += ",JOINPARTSRF.JOINSOURCEMAKERCODERF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNOWITHHRF ";
                selectstr += ",JOINPARTSRF.JOINSOURPARTSNONONEHRF ";
                selectstr += ",JOINPARTSRF.JOINDESTMAKERCDRF ";
                selectstr += ",JOINPARTSRF.JOINDESTPARTSNORF ";
                selectstr += ",JOINPARTSRF.JOINQTYRF ";
                selectstr += ",JOINPARTSRF.SETPARTSFLGRF ";
                selectstr += ",JOINPARTSRF.JOINSPECIALNOTERF ";

                selectstr += ",PRIMEPARTSRF.OFFERDATERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSNAMERF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSKANANMRF ";
                selectstr += ",PRIMEPARTSRF.PARTSLAYERCDRF ";
                selectstr += ",PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF ";
                selectstr += ",PRIMEPARTSRF.PARTSATTRIBUTERF ";
                selectstr += ",PRIMEPARTSRF.CATALOGDELETEFLAGRF ";

                if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                {
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSFULLNAMERF ";
                    selectstr += ",SEARCHPRTNMRF.SEARCHPARTSHALFNAMERF ";
                }

                selectstr += " FROM PRIMEPARTSRF INNER JOIN JOINPARTSRF ON PRIMEPARTSRF.PARTSMAKERCDRF = JOINPARTSRF.JOINDESTMAKERCDRF";
                selectstr += " AND PRIMEPARTSRF.PRIMEPARTSNOWITHHRF = JOINPARTSRF.JOINDESTPARTSNORF ";

                if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                {
                    selectstr += "LEFT OUTER JOIN SEARCHPRTNMRF ON (JOINPARTSRF.TBSPARTSCODERF = SEARCHPRTNMRF.TBSPARTSCODERF ";
                    selectstr += string.Format("AND SEARCHPRTNMRF.CARMAKERCODERF = {0}) ", carMakerCd);
                }

                selectstr += " WHERE ";

                foreach (OfrPartsCondWork wk in inWork)
                {
                    //メーカーコード
                    wherestr += " OR ( ";
                    wherestr += " JOINPARTSRF.JOINSOURCEMAKERCODERF = " + wk.MakerCode;
                    wherestr += " AND JOINPARTSRF.JOINSOURPARTSNOWITHHRF = '" + wk.PrtsNo + "'";
                    wherestr += " ) ";
                }
                wherestr = wherestr.Substring(3); // 先頭のOR除去

                SqlCommand sqlCommand = new SqlCommand(selectstr + wherestr, sqlConnection, sqlTransaction);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    OfferJoinPartsRetWork mf = new OfferJoinPartsRetWork();

                    //結合情報
                    mf.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    mf.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    mf.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));    // セレクトコード
                    mf.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));    // 種別コード
                    mf.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));  //
                    mf.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    mf.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    mf.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                    mf.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    mf.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                    mf.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    mf.SetPartsFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSFLGRF"));
                    mf.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                    //優良情報
                    mf.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    mf.PrimePartsKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    mf.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    mf.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    mf.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    mf.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));

                    if (carMakerCd != 0) // 車メーカーコードあり　（検索品名検索する）
                    {
                        mf.SearchPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSFULLNAMERF"));
                        mf.SearchPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSHALFNAMERF"));
                    }

                    // 自動回答品目設定 による回答対象かの判断
                    if (autoAnsItemStList != null && autoAnsItemStList.Count > 0)
                    {
                        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
                        //if (!IsAutoAnswer(mf))
                        if (!IsAutoAnswer(autoAnsItemStList, mf, customerCode, sectionCode))
                        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
                            continue;
                    }

                    // 優先設定 による回答対象かの判断
                    if (prmSettingUList != null && prmSettingUList.Count > 0)
                    {
                        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
                        //if (!IsPrmSetting(mf))
                        if (!IsPrmSetting(prmSettingUList,mf))
                        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
                            continue;
                    }

                    retWork.Add(mf);
                }

                // ここまで正常処理されると0件の場合でも正常扱いする。
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrimePartsInfDB.SearchPrimePartsNoProcAutoAnswerにてエラー発生 Msg=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 自動回答専用　優良設定の判断
        /// </summary>
        /// <param name="mf">検索結果部品情報</param>
        /// <returns>true：優良設定有り　false：優良設定無し</returns>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //private bool IsPrmSetting(OfferJoinPartsRetWork mf)
        private bool IsPrmSetting(List<PrmSettingUForOffer> prmSettingUList, OfferJoinPartsRetWork mf)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            bool isPrmSetting = false;

            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            //PrmSettingUForOffer prmSetting = SearchPrmSettingUWork(mf.GoodsMGroup, mf.TbsPartsCode, mf.JoinDestMakerCd, mf.PrmSetDtlNo1, mf.PrmSetDtlNo2);
            PrmSettingUForOffer prmSetting = SearchPrmSettingUWork(prmSettingUList,mf.GoodsMGroup, mf.TbsPartsCode, mf.JoinDestMakerCd, mf.PrmSetDtlNo1, mf.PrmSetDtlNo2);
            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

            if (prmSetting != null)
            {
                if (mf.JoinSourPartsNoWithH == mf.JoinDestPartsNo && mf.JoinSourceMakerCode == mf.JoinDestMakerCd)
                {
                    // セット品は、優良表示区分が「表示しない」以外は表示する
                    if (!prmSetting.PrimeDisplayCode.Equals(0))
                    {
                        isPrmSetting = true;
                    }
                }
                else
                {
                    // 優良表示区分が[優良表示区分]以外は表示しない
                    if (prmSetting.PrimeDisplayCode.Equals(1))
                    {
                        isPrmSetting = true;
                    }
                }
            }

            return isPrmSetting;
        }

        /// <summary>
        /// 自動回答専用　優良設定リストから、対象の優良設定を取得します。
        /// </summary>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="partsMakerCd">部品メーカーコード</param>
        /// <param name="prmSetDtlNo1">優良設定詳細コード１（セレクトコード）</param>
        /// <param name="prmSetDtlNo2">優良設定詳細コード２（種別コード）</param>
        /// <returns>対象優良設定</returns>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //private PrmSettingUForOffer SearchPrmSettingUWork(int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, int prmSetDtlNo2)
        private PrmSettingUForOffer SearchPrmSettingUWork(List<PrmSettingUForOffer> prmSettingUList, int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, int prmSetDtlNo2)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            return prmSettingUList.Find(
                        delegate(PrmSettingUForOffer prmSettingUWork)
                        {
                            if (prmSettingUWork.PrmSetDtlNo2.Equals(prmSetDtlNo2) &&
                                prmSettingUWork.PrmSetDtlNo1.Equals(prmSetDtlNo1) &&
                                prmSettingUWork.PartsMakerCd.Equals(partsMakerCd) &&
                                prmSettingUWork.TbsPartsCode.Equals(tbsPartsCode) &&
                                prmSettingUWork.GoodsMGroup.Equals(goodsMGroup) )
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });
        }

        /// <summary>
        /// 自動回答専用　自動回答品目設定の判断
        /// </summary>
        /// <param name="mf">検索結果部品情報</param>
        /// <returns>true：自動回答対象　false：自動回答対象外</returns>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //private bool IsAutoAnswer(OfferJoinPartsRetWork mf)
        private bool IsAutoAnswer(List<AutoAnsItemStForOffer> autoAnsItemStList, OfferJoinPartsRetWork mf, int customerCode, string sectionCode)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            bool autoAnswer = false;

            AutoAnsItemStForOffer selectAutoAnsItemSt = new AutoAnsItemStForOffer();

            // 自動回答品目設定マスタを検索
            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
            //selectAutoAnsItemSt = autoAnsItemStFind(autoAnsItemStList, mf, this.sectionCode, this.customerCode);
            selectAutoAnsItemSt = autoAnsItemStFind(autoAnsItemStList, mf, sectionCode, customerCode);
            // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<

            // 自動回答品目設定マスタに登録がある場合
            if (selectAutoAnsItemSt != null)
            {
                // 自動回答品目設定マスタ.自動回答区分の判定
                if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals(0)) // 0:しない(全て手動回答)
                {
                    autoAnswer = true;
                }
            }

            return autoAnswer;
        }

        /// <summary>
        /// 自動回答専用　自動回答品目設定検索
        /// </summary>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="sectionCodeWk">拠点コード</param>
        /// <param name="customerCodeWk">得意先コード</param>
        /// <returns>対象自動回答品目設定</returns>
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
        //private AutoAnsItemStForOffer autoAnsItemStFind(OfferJoinPartsRetWork mf, string sectionCodeWk, int customerCodeWk)
        private AutoAnsItemStForOffer autoAnsItemStFind(List<AutoAnsItemStForOffer> autoAnsItemStList, OfferJoinPartsRetWork mf, string sectionCodeWk, int customerCodeWk)
        // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
        {
            // 検索結果
            AutoAnsItemStForOffer retAutoAnsItemSt;

            // 一括検索結果より優先順位に合わせて検索結果を抽出
            if (customerCodeWk > 0)
            {
                #region  優先順位1:得意先＋中分類＋BLコード＋メーカー
                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority1(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位1:得意先(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        customerCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }
                #endregion

                #region  優先順位2:得意先＋中分類（共通）＋BLコード＋メーカー

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority2(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位1:得意先(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        customerCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion
                    return retAutoAnsItemSt;
                }

                #endregion
                #region 優先順位3:得意先＋中分類＋メーカー

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority3(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位3:得意先(={0})＋中分類(={1}) で検索されました。",
                        customerCodeWk,
                        mf.GoodsMGroup
                    );

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region 優先順位4:得意先＋メーカー

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority4(AutoAnsItemSt, mf, customerCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位4:得意先(={0}) で検索されました。",
                        customerCodeWk
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            if (!string.IsNullOrEmpty(sectionCodeWk))
            {
                #region 優先順位5:拠点＋中分類＋BLコード＋メーカー

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority5(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位5:拠点(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        sectionCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion

                #region 優先順位6:拠点＋中分類（共通）＋BLコード＋メーカー

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority6(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位5:拠点(={0})＋中分類(={1})＋BLコード(={2})＋メーカー(={3}) で検索されました。",
                        sectionCodeWk,
                        mf.GoodsMGroup,
                        mf.TbsPartsCode,
                        mf.JoinDestMakerCd
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion

                #region 優先順位7:拠点＋中分類＋メーカー

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority7(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位7:拠点(={0})＋中分類(={1}) で検索されました。",
                        sectionCodeWk,
                        mf.GoodsMGroup
                    );

                    #endregion // </Log>

                    return retAutoAnsItemSt;
                }

                #endregion

                #region 優先順位8:拠点＋メーカー

                retAutoAnsItemSt = autoAnsItemStList.Find(
                    delegate(AutoAnsItemStForOffer AutoAnsItemSt)
                    {
                        return IsPriority8(AutoAnsItemSt, mf, sectionCodeWk);
                    }
                );
                if (retAutoAnsItemSt != null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先順位8:拠点(={0}) で検索されました。",
                        sectionCodeWk
                    );

                    #endregion

                    return retAutoAnsItemSt;
                }

                #endregion
            }
            else
            {
                retAutoAnsItemSt = null;
                return retAutoAnsItemSt;
            }

            if (!sectionCodeWk.Equals("00"))
            {
                // 拠点：全社で検索
                // UPD 2014/08/07 速度改善フェーズ２ T.Nishi ----->>>>>
                //return autoAnsItemStFind(mf, "00", 0);
                return autoAnsItemStFind(autoAnsItemStList,mf, "00", 0);
                // UPD 2014/08/07 速度改善フェーズ２ T.Nishi -----<<<<<
            }

            return retAutoAnsItemSt;
        }

        #region 優先順位の判断

        /// <summary>
        /// 自動回答専用　優先順位1:得意先＋中分類＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="customerCodeWk">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位1です。<br/>
        /// <c>false</c>:優先順位1ではありません。
        /// </returns>
        private static bool IsPriority1(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }
        /// <summary>
        /// 自動回答専用　優先順位2:得意先＋中分類（共通）＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="customerCodeWk">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位2です。<br/>
        /// <c>false</c>:優先順位2ではありません。
        /// </returns>
        private static bool IsPriority2(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd

                );
            }
            return false;
        }

        /// <summary>
        /// 自動回答専用　優先順位3:得意先＋中分類＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="customerCodeWk">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位3です。<br/>
        /// <c>false</c>:優先順位3ではありません。
        /// </returns>
        private static bool IsPriority3(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 自動回答専用　優先順位4:得意先＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="customerCodeWk">得意先コード</param>
        /// <returns>
        /// <c>true</c> :優先順位4です。<br/>
        /// <c>false</c>:優先順位4ではありません。
        /// </returns>
        private static bool IsPriority4(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, int customerCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == customerCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 自動回答専用　優先順位5:拠点＋中分類＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="sectionCodeWk">拠点コード</param>
        /// <returns>
        /// <c>true</c> :優先順位5です。<br/>
        /// <c>false</c>:優先順位5ではありません。
        /// </returns>
        private static bool IsPriority5(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 自動回答専用　優先順位6:拠点＋中分類（共通）＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="sectionCodeWk">拠点コード</param>
        /// <returns>
        /// <c>true</c> :優先順位6です。<br/>
        /// <c>false</c>:優先順位6ではありません。
        /// </returns>
        private static bool IsPriority6(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == mf.TbsPartsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd

                );
            }
            return false;
        }

        /// <summary>
        /// 自動回答専用　優先順位7:拠点＋中分類であるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="sectionCodeWk">拠点コード</param>
        /// <returns>
        /// <c>true</c> :優先順位7です。<br/>
        /// <c>false</c>:優先順位7ではありません。
        /// </returns>
        private static bool IsPriority7(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == mf.GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 自動回答専用　優先順位8:拠点であるか判断します。
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定</param>
        /// <param name="mf">検索結果部品情報</param>
        /// <param name="sectionCodeWk">拠点コード</param>
        /// <returns>
        /// <c>true</c> :優先順位8です。<br/>
        /// <c>false</c>:優先順位8ではありません。
        /// </returns>
        private static bool IsPriority8(AutoAnsItemStForOffer autoAnsItemSt, OfferJoinPartsRetWork mf, string sectionCodeWk)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == mf.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == sectionCodeWk
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == mf.JoinDestMakerCd
                );
            }
            return false;
        }

        #endregion
        // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }

    // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// 自動回答専用　オファー用自動回答品目設定データクラス
    /// </summary>
    internal class AutoAnsItemStForOffer
    {
        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        /// <remarks>0は全得意先</remarks>
        private Int32 _customerCode;

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>※種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>自動回答区分</summary>
        /// <remarks>0:しない,1:納期,2:価格</remarks>
        private Int32 _autoAnswerDiv;

        /// <summary>優先順位</summary>
        private Int32 _priorityOrder;

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>00は全社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>0は全得意先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
       /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>※種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  AutoAnswerDiv
        /// <summary>自動回答区分プロパティ</summary>
        /// <value>0:しない,1:納期,2:価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分プロパティ</br>
        /// </remarks>
        public Int32 AutoAnswerDiv
        {
            get { return _autoAnswerDiv; }
            set { _autoAnswerDiv = value; }
        }

        /// public propaty name  :  PriorityOrder
        /// <summary>優先順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先順位プロパティ</br>
        /// </remarks>
        public Int32 PriorityOrder
        {
            get { return _priorityOrder; }
            set { _priorityOrder = value; }
        }

        /// <summary>
        /// 自動回答品目設定マスタコンストラクタ
        /// </summary>
        /// <returns>AutoAnsItemStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AutoAnsItemStクラスの新しいインスタンスを生成します</br>
        /// </remarks>
        public AutoAnsItemStForOffer()
        {
        }
    }

    /// <summary>
    /// 自動回答専用　オファー用優良設定データクラス
    /// </summary>
    internal class PrmSettingUForOffer
    {
        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>部品メーカーコード</summary>
        private Int32 _partsMakerCd;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>※セレクトコード</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>※種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>優良表示区分</summary>
        /// <remarks>0:無し　1:商品&結合　2:商品</remarks>
        private Int32 _primeDisplayCode;

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  PartsMakerCd
        /// <summary>部品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// </remarks>
        public Int32 PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>※セレクトコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード１プロパティ</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>※種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrimeDisplayCode
        /// <summary>優良表示区分プロパティ</summary>
        /// <value>0:無し　1:商品&結合　2:商品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良表示区分プロパティ</br>
        /// </remarks>
        public Int32 PrimeDisplayCode
        {
            get { return _primeDisplayCode; }
            set { _primeDisplayCode = value; }
        }

        /// <summary>
        /// 優良設定（ユーザー登録分）ワークコンストラクタ
        /// </summary>
        /// <returns>PrmSettingUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSettingUWorkクラスの新しいインスタンスを生成します</br>
        /// </remarks>
        public PrmSettingUForOffer()
        {
        }
    }
    // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
}
