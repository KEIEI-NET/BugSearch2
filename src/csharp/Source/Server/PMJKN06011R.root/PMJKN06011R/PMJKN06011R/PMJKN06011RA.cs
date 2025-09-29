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
using Broadleaf.Application.Common;  // ADD 2020/06/18 譚洪 PMKOBETSU-4005 

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 自由検索部品取得DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタ情報取得の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22018  鈴木 正臣</br>
    /// <br>Date       : 2010/04/26</br>
    /// <br></br>
    /// <br>Update Note: 2014/02/06 湯上 千加子</br>
    /// <br>管理番号   : </br>
    /// <br>           : SCM仕掛一覧№10632対応</br>
    /// <br>Update Note: 2020/06/18 譚洪</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FreeSearchPartsSearchDB : RemoteDB, IFreeSearchPartsSearchDB
    {
        #region [ Query ]
        private const string ctQryBLSearch =
                      "SELECT "
                    + "FSP.CREATEDATETIMERF "
                    + ",FSP.UPDATEDATETIMERF "
                    + ",FSP.ENTERPRISECODERF "
                    + ",FSP.FILEHEADERGUIDRF "
                    + ",FSP.UPDEMPLOYEECODERF "
                    + ",FSP.UPDASSEMBLYID1RF "
                    + ",FSP.UPDASSEMBLYID2RF "
                    + ",FSP.LOGICALDELETECODERF "
                    + ",FSP.FRESRCHPRTPROPNORF "
                    + ",FSP.MAKERCODERF "
                    + ",FSP.MODELCODERF "
                    + ",FSP.MODELSUBCODERF "
                    + ",FSP.FULLMODELRF "
                    + ",FSP.TBSPARTSCODERF "
                    + ",FSP.TBSPARTSCDDERIVEDNORF "
                    + ",FSP.GOODSNORF "
                    + ",FSP.GOODSNONONEHYPHENRF "
                    + ",FSP.GOODSMAKERCDRF "
                    + ",FSP.PARTSQTYRF "
                    + ",FSP.PARTSOPNMRF "
                    + ",FSP.MODELPRTSADPTYMRF "
                    + ",FSP.MODELPRTSABLSYMRF "
                    + ",FSP.MODELPRTSADPTFRAMENORF "
                    + ",FSP.MODELPRTSABLSFRAMENORF "
                    + ",FSP.MODELGRADENMRF "
                    + ",FSP.BODYNAMERF "
                    + ",FSP.DOORCOUNTRF "
                    + ",FSP.ENGINEMODELNMRF "
                    + ",FSP.ENGINEDISPLACENMRF "
                    + ",FSP.EDIVNMRF "
                    + ",FSP.TRANSMISSIONNMRF "
                    + ",FSP.WHEELDRIVEMETHODNMRF "
                    + ",FSP.SHIFTNMRF "
                    + ",FSP.CREATEDATERF "
                    + ",FSP.UPDATEDATERF "
                    + ",GDS.GOODSNORF AS GOODSNOFROMGOODSRF "
                    + ",GDS.GOODSNAMERF "
                    + ",GDS.GOODSNAMEKANARF "
                    + ",GDS.GOODSRATERANKRF "
                    + ",GDS.BLGOODSCODERF AS BLGOODSCODEFROMGOODSRF "
                    + ",PRC.GOODSNORF AS GOODSNOFROMPRICERF "
                    + ",PRC.PRICESTARTDATERF "
                    + ",PRC.LISTPRICERF "
                    + ",PRC.OPENPRICEDIVRF "
                    + ",BLC.BLGOODSFULLNAMERF "
                    + ",BLC.BLGOODSHALFNAMERF ";

        #endregion

        #region [ コンストラクタ ]
        /// <summary>
        /// 自由検索部品情報取得DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2010/04/26</br>
        /// </remarks>
        public FreeSearchPartsSearchDB()
            :
            base("PMJKN06013D", "Broadleaf.Application.Remoting.FreeSearchPartsSearchDB", "FREESEARCHPARTSRF")
        {
        }
        #endregion

        #region [ Search ]
        /// <summary>
        /// 自由検索部品マスタ取得処理
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retParts"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        public int Search( FreeSearchPartsSParaWork inPara, ref object retParts, out long retCnt )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            retParts = null;
            retCnt = 0;

            ArrayList alRetParts = new ArrayList();

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                // 部品検索メイン
                status = SearchPartsInf( inPara, ref alRetParts, ref sqlConnection );
            }
            catch
            {
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

            // 結果格納
            retParts = alRetParts;
            retCnt = alRetParts.Count;


            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                retParts = null;
            }

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 自由検索部品マスタ取得処理
        /// </summary>
        /// <param name="inParaList"></param>
        /// <param name="retParts"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        public int Search(ArrayList inParaList, ref object retParts, out long retCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            retParts = null;
            retCnt = 0;

            ArrayList alRetParts = new ArrayList();

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return 99;
                }
                sqlConnection.Open();

                // 部品検索メイン
                status = SearchPartsInf(inParaList, ref alRetParts, ref retCnt,  ref sqlConnection);
            }
            catch
            {
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

            // 結果格納
            retParts = alRetParts;

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retParts = null;
            }

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 自由検索部品の検索
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="alRetParts"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2010/04/26</br>
        private int SearchPartsInf( FreeSearchPartsSParaWork inPara, ref ArrayList alRetParts, ref SqlConnection sqlConnection )
        {
            ArrayList retInf = new ArrayList();
            ArrayList retEquip = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //結果の初期化
            retInf = new ArrayList();

            try
            {
                // 部品固有番号の重複チェック用 (検索後に圧縮処理を行うが、効率化の為ディクショナリで同一レコードを除外する)
                Dictionary<string, bool> freSrchPrtPropNoDic = new Dictionary<string, bool>();


                // ＢＬコード検索 or 固有番号配列検索
                if ( inPara.FreSrchPrtPropNos == null || inPara.FreSrchPrtPropNos.Length == 0 )
                {
                    // 車輌毎の該当部品検索
                    for ( int modelIndex = 0; modelIndex < inPara.FSPartsSModels.Length; modelIndex++ )
                    {
                        //部品検索
                        status = SearchPartsInfProc( inPara, modelIndex, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection );
                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                             status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                        {
                            break;
                        }
                    }

                    // STATUSの再設定
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && retInf.Count > 0 )
                    {
                        // 最後の車輌で該当が無くても、途中で抽出データがある場合はctDB_NORMALに補正する
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    // 抽出結果の圧縮処理
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        CompressPartsRec( inPara, ref retInf );
                    }
                }
                else
                {
                    // 固有番号配列検索
                    status = SearchPartsInfProc( inPara, 0, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection );
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //基底クラスに例外を渡して処理してもらう
                status = -1;
            }

            alRetParts = retInf;

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 自由検索部品の検索
        /// </summary>
        /// <param name="inParaList"></param>
        /// <param name="alRetParts"></param>
        /// <param name="retCount"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPartsInf(ArrayList inParaList, ref ArrayList alRetParts, ref long retCount, ref SqlConnection sqlConnection)
        {
            ArrayList retInf = new ArrayList();
            ArrayList retEquip = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;


            try
            {
                foreach (FreeSearchPartsSParaWork inPara in inParaList)
                {
                    // 部品固有番号の重複チェック用 (検索後に圧縮処理を行うが、効率化の為ディクショナリで同一レコードを除外する)
                    Dictionary<string, bool> freSrchPrtPropNoDic = new Dictionary<string, bool>();
                    //結果の初期化
                    retInf = new ArrayList();

                    // ＢＬコード検索 or 固有番号配列検索
                    if (inPara.FreSrchPrtPropNos == null || inPara.FreSrchPrtPropNos.Length == 0)
                    {
                        // 車輌毎の該当部品検索
                        for (int modelIndex = 0; modelIndex < inPara.FSPartsSModels.Length; modelIndex++)
                        {
                            //部品検索
                            status = SearchPartsInfProc(inPara, modelIndex, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                                 status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                break;
                            }
                        }

                        // STATUSの再設定
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && retInf.Count > 0)
                        {
                            // 最後の車輌で該当が無くても、途中で抽出データがある場合はctDB_NORMALに補正する
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        // 抽出結果の圧縮処理
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CompressPartsRec(inPara, ref retInf);
                        }
                    }
                    else
                    {
                        // 固有番号配列検索
                        status = SearchPartsInfProc(inPara, 0, ref freSrchPrtPropNoDic, ref retInf, ref sqlConnection);
                    }
                    alRetParts.Add(retInf);
                    retCount += retInf.Count;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //基底クラスに例外を渡して処理してもらう
                status = -1;
            }
            if (retCount != 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 自由検索部品マスタ検索
        /// </summary>
        /// <param name="inPara">条件パラメータ</param>
        /// <param name="modelIndex">型式条件index</param>
        /// <param name="freSrchPrtPropNoDic">自由検索部品固有番号ディクショナリ</param>
        /// <param name="retInf">抽出した部品レコード</param>
        /// <param name="sqlConnection">コネクションクラス</param>
        /// <returns></returns>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchPartsInfProc( FreeSearchPartsSParaWork inPara, int modelIndex, ref Dictionary<string, bool> freSrchPrtPropNoDic, ref ArrayList retInf, ref SqlConnection sqlConnection )
        {
            SqlDataReader myReader = null;
            //結果のArrayListにいれる作業情報クラス
            FreeSearchPartsSRetWork mf = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string selectstr = string.Empty;
            string fromstr = string.Empty;
            string wherestr = string.Empty;
            string orderstring = string.Empty;
            string queryCol = string.Empty;
            string originalPartsNo = string.Empty;
            string partsNo = string.Empty;

            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

            try
            {
                SqlCommand sqlCommand = new SqlCommand();

                // Selectコマンド生成（自由検索部品・商品・価格）
                selectstr = ctQryBLSearch;

                fromstr = " FROM FREESEARCHPARTSRF AS FSP " + Environment.NewLine;
                fromstr += "  LEFT JOIN BLGOODSCDURF AS BLC " + Environment.NewLine;
                fromstr += "    ON (FSP.ENTERPRISECODERF = BLC.ENTERPRISECODERF AND FSP.TBSPARTSCODERF = BLC.BLGOODSCODERF AND BLC.LOGICALDELETECODERF = @FINDLOGICALDELETECODE) " + Environment.NewLine;
                fromstr += "  LEFT JOIN GOODSURF AS GDS " + Environment.NewLine;
                fromstr += "    ON (FSP.ENTERPRISECODERF = GDS.ENTERPRISECODERF AND FSP.GOODSNORF = GDS.GOODSNORF AND FSP.GOODSMAKERCDRF = GDS.GOODSMAKERCDRF AND GDS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE) " + Environment.NewLine;
                fromstr += "  LEFT JOIN GOODSPRICEURF AS PRC " + Environment.NewLine;
                fromstr += "    ON (FSP.ENTERPRISECODERF = PRC.ENTERPRISECODERF AND FSP.GOODSNORF = PRC.GOODSNORF AND FSP.GOODSMAKERCDRF = PRC.GOODSMAKERCDRF AND PRC.LOGICALDELETECODERF = @FINDLOGICALDELETECODE) " + Environment.NewLine;

                # region [WHERE]

                wherestr = "WHERE ";

                // 企業ｺｰﾄﾞ
                wherestr += "  FSP.ENTERPRISECODERF = @FINDENTERPRISECODE ";
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString( inPara.EnterpriseCode );

                // 論理削除
                wherestr += " AND FSP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE";
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
                findLogicalDeleteCode.Value = 0;

                // ＢＬコード
                if ( inPara.TbsPartsCode != 0 )
                {
                    wherestr += " AND FSP.TBSPARTSCODERF = @FINDTBSPARTSCODE ";
                    SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add( "@FINDTBSPARTSCODE", SqlDbType.Int );
                    findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32( inPara.TbsPartsCode );
                }

                // 品番
                if ( inPara.GoodsNo != string.Empty )
                {
                    wherestr += " AND FSP.GOODSNORF = @FINDGOODSNO ";
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NVarChar );
                    findGoodsNo.Value = SqlDataMediator.SqlSetString( inPara.GoodsNo );
                }

                // 商品メーカーコード
                if ( inPara.GoodsMakerCd != 0 )
                {
                    wherestr += " AND FSP.GOODSMAKERCDRF = @FINDGOODSMAKERCD ";
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( inPara.GoodsMakerCd );
                }

                // 価格開始日
                if ( inPara.PriceStartDate != DateTime.MinValue )
                {
                    wherestr += " AND ( PRICESTARTDATERF IS NULL OR PRICESTARTDATERF <= @FINDPRICESTARTDATE ) ";
                    SqlParameter findPriceStartDate = sqlCommand.Parameters.Add( "@FINDPRICESTARTDATE", SqlDbType.Int );
                    findPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( inPara.PriceStartDate );
                }

                // 自由検索部品固有番号配列
                if ( inPara.FreSrchPrtPropNos != null && inPara.FreSrchPrtPropNos.Length > 0 )
                {
                    wherestr += " AND FRESRCHPRTPROPNORF IN ( ";
                    for ( int propIndex = 0; propIndex < inPara.FreSrchPrtPropNos.Length; propIndex++ )
                    {
                        if ( propIndex > 0 )
                        {
                            wherestr += ",";
                        }
                        wherestr += string.Format( "@FINDFRESRCHPRTPROPNO{0}", propIndex );
                        SqlParameter findFreSrchPrtPropNo = sqlCommand.Parameters.Add( string.Format( "@FINDFRESRCHPRTPROPNO{0}", propIndex ), SqlDbType.NChar );
                        findFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString( inPara.FreSrchPrtPropNos[propIndex] );
                    }
                    wherestr += " ) ";
                }

                // 型式情報・諸元情報の絞り込み（このメソッド１回に付き、modelIndexで特定した１車輌のみが対象となる）
                if ( inPara.FSPartsSModels != null && inPara.FSPartsSModels.Length > modelIndex )
                {
                    FreeSearchPartsSMdlParaWork mdlPara = inPara.FSPartsSModels[modelIndex];

                    # region [対象車輌毎]

                    //--------------------------------------------------
                    // 型式情報
                    //--------------------------------------------------

                    // メーカーコード
                    if ( mdlPara.MakerCode != 0 )
                    {
                        wherestr += " AND FSP.MAKERCODERF = @FINDMAKERCODE ";
                        SqlParameter findMakerCode = sqlCommand.Parameters.Add( "@FINDMAKERCODE", SqlDbType.Int );
                        findMakerCode.Value = SqlDataMediator.SqlSetInt32( mdlPara.MakerCode );
                    }

                    // 車種コード
                    if ( mdlPara.ModelCode != 0 )
                    {
                        wherestr += " AND FSP.MODELCODERF = @FINDMODELCODE ";
                        SqlParameter findModelCode = sqlCommand.Parameters.Add( "@FINDMODELCODE", SqlDbType.Int );
                        findModelCode.Value = SqlDataMediator.SqlSetInt32( mdlPara.ModelCode );
                    }

                    // 車種サブコード
                    if ( mdlPara.ModelSubCode != -1 )
                    {
                        wherestr += " AND FSP.MODELSUBCODERF = @FINDMODELSUBCODE ";
                        SqlParameter findModelSubCode = sqlCommand.Parameters.Add( "@FINDMODELSUBCODE", SqlDbType.Int );
                        findModelSubCode.Value = SqlDataMediator.SqlSetInt32( mdlPara.ModelSubCode );
                    }

                    // 型式（フル型）
                    if ( mdlPara.FullModel != string.Empty )
                    {
                        wherestr += " AND FSP.FULLMODELRF = @FINDFULLMODEL ";
                        SqlParameter findFullModel = sqlCommand.Parameters.Add( "@FINDFULLMODEL", SqlDbType.NVarChar );
                        findFullModel.Value = SqlDataMediator.SqlSetString( mdlPara.FullModel );
                    }

                    //--------------------------------------------------
                    // 年式・車台番号の範囲
                    //--------------------------------------------------

                    // 年式（開始～終了）
                    if ( mdlPara.ProduceTypeOfYear != 0 )
                    {
                        if ( mdlPara.ProduceTypeOfYear % 100 == 0 )
                        {
                            //--------------------
                            // 年のみ (例:201000)
                            //--------------------

                            // 開始
                            wherestr += " AND (FSP.MODELPRTSADPTYMRF / 100 <= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSADPTYMRF = 0 OR FSP.MODELPRTSADPTYMRF IS NULL) ";
                            // 終了
                            wherestr += " AND (FSP.MODELPRTSABLSYMRF / 100 >= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSABLSYMRF = 0 OR FSP.MODELPRTSABLSYMRF IS NULL) ";

                            SqlParameter findProduceTypeOfYear = sqlCommand.Parameters.Add( "@FINDPRODUCETYPEOFYEAR", SqlDbType.Int );
                            findProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32( mdlPara.ProduceTypeOfYear / 100 );
                        }
                        else
                        {
                            //--------------------
                            // 年月 (例:201012)
                            //--------------------

                            // 開始
                            //wherestr += " AND (FSP.MODELPRTSADPTYMRF <= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSADPTYMRF = 0) ";
                            wherestr += " AND (FSP.MODELPRTSADPTYMRF <= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSADPTYMRF = 0 OR FSP.MODELPRTSADPTYMRF IS NULL) ";
                            // 終了
                            //wherestr += " AND (FSP.MODELPRTSABLSYMRF >= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSABLSYMRF = 0) ";
                            wherestr += " AND (FSP.MODELPRTSABLSYMRF >= @FINDPRODUCETYPEOFYEAR OR FSP.MODELPRTSABLSYMRF = 0 OR FSP.MODELPRTSABLSYMRF IS NULL) ";

                            SqlParameter findProduceTypeOfYear = sqlCommand.Parameters.Add( "@FINDPRODUCETYPEOFYEAR", SqlDbType.Int );
                            findProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32( mdlPara.ProduceTypeOfYear );
                        }
                    }

                    // 車台番号
                    if ( mdlPara.ProduceFrameNo != 0 )
                    {
                        // 開始
                        //wherestr += " AND (FSP.MODELPRTSADPTFRAMENORF <= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSADPTFRAMENORF = 0) ";
                        wherestr += " AND (FSP.MODELPRTSADPTFRAMENORF <= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSADPTFRAMENORF = 0 OR FSP.MODELPRTSADPTFRAMENORF IS NULL) ";
                        // 終了
                        //wherestr += " AND (FSP.MODELPRTSABLSFRAMENORF >= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSABLSFRAMENORF = 0) ";
                        wherestr += " AND (FSP.MODELPRTSABLSFRAMENORF >= @FINDPRODUCEFRAMENO OR FSP.MODELPRTSABLSFRAMENORF = 0 OR FSP.MODELPRTSABLSFRAMENORF IS NULL) ";

                        SqlParameter findProduceFrameNo = sqlCommand.Parameters.Add( "@FINDPRODUCEFRAMENO", SqlDbType.Int );
                        findProduceFrameNo.Value = SqlDataMediator.SqlSetInt32( mdlPara.ProduceFrameNo );
                    }

                    //--------------------------------------------------
                    // 諸元情報
                    //--------------------------------------------------

                    // 型式グレード名称
                    if ( mdlPara.ModelGradeNm != string.Empty )
                    {
                        wherestr += " AND (FSP.MODELGRADENMRF IS NULL OR FSP.MODELGRADENMRF = @FINDMODELGRADENM OR FSP.MODELGRADENMRF = '') ";
                        SqlParameter findModelGradeNm = sqlCommand.Parameters.Add( "@FINDMODELGRADENM", SqlDbType.NVarChar );
                        findModelGradeNm.Value = SqlDataMediator.SqlSetString( mdlPara.ModelGradeNm );
                    }

                    // ボディー名称
                    if ( mdlPara.BodyName != string.Empty )
                    {
                        wherestr += " AND (FSP.BODYNAMERF IS NULL OR FSP.BODYNAMERF = @FINDBODYNAME OR FSP.BODYNAMERF = '') ";
                        SqlParameter findBodyName = sqlCommand.Parameters.Add( "@FINDBODYNAME", SqlDbType.NVarChar );
                        findBodyName.Value = SqlDataMediator.SqlSetString( mdlPara.BodyName );
                    }

                    // ドア数
                    if ( mdlPara.DoorCount != 0 )
                    {
                        wherestr += " AND (FSP.DOORCOUNTRF IS NULL OR FSP.DOORCOUNTRF = @FINDDOORCOUNT OR FSP.DOORCOUNTRF = 0) ";
                        SqlParameter findDoorCount = sqlCommand.Parameters.Add( "@FINDDOORCOUNT", SqlDbType.Int );
                        findDoorCount.Value = SqlDataMediator.SqlSetInt32( mdlPara.DoorCount );
                    }

                    // エンジン型式名称
                    if ( mdlPara.EngineModelNm != string.Empty )
                    {
                        wherestr += " AND (FSP.ENGINEMODELNMRF IS NULL OR FSP.ENGINEMODELNMRF = @FINDENGINEMODELNM OR FSP.ENGINEMODELNMRF = '') ";
                        SqlParameter findEngineModelNm = sqlCommand.Parameters.Add( "@FINDENGINEMODELNM", SqlDbType.NVarChar );
                        findEngineModelNm.Value = SqlDataMediator.SqlSetString( mdlPara.EngineModelNm );
                    }

                    // 排気量名称
                    if ( mdlPara.EngineDisplaceNm != string.Empty )
                    {
                        wherestr += " AND (FSP.ENGINEDISPLACENMRF IS NULL OR FSP.ENGINEDISPLACENMRF = @FINDENGINEDISPLACENM OR FSP.ENGINEDISPLACENMRF = '') ";
                        SqlParameter findEngineDisplaceNm = sqlCommand.Parameters.Add( "@FINDENGINEDISPLACENM", SqlDbType.NVarChar );
                        findEngineDisplaceNm.Value = SqlDataMediator.SqlSetString( mdlPara.EngineDisplaceNm );
                    }

                    // E区分名称
                    if ( mdlPara.EDivNm != string.Empty )
                    {
                        wherestr += " AND (FSP.EDIVNMRF IS NULL OR FSP.EDIVNMRF = @FINDEDIVNM OR FSP.EDIVNMRF = '') ";
                        SqlParameter findEDivNm = sqlCommand.Parameters.Add( "@FINDEDIVNM", SqlDbType.NVarChar );
                        findEDivNm.Value = SqlDataMediator.SqlSetString( mdlPara.EDivNm );
                    }

                    // ミッション名称
                    if ( mdlPara.TransmissionNm != string.Empty )
                    {
                        wherestr += " AND (FSP.TRANSMISSIONNMRF IS NULL OR FSP.TRANSMISSIONNMRF = @FINDTRANSMISSIONNM OR FSP.TRANSMISSIONNMRF ='') ";
                        SqlParameter findTransmissionNm = sqlCommand.Parameters.Add( "@FINDTRANSMISSIONNM", SqlDbType.NVarChar );
                        findTransmissionNm.Value = SqlDataMediator.SqlSetString( mdlPara.TransmissionNm );
                    }

                    // シフト名称
                    if ( mdlPara.ShiftNm != string.Empty )
                    {
                        wherestr += " AND (FSP.SHIFTNMRF IS NULL OR FSP.SHIFTNMRF = @FINDSHIFTNM OR FSP.SHIFTNMRF = '') ";
                        SqlParameter findShiftNm = sqlCommand.Parameters.Add( "@FINDSHIFTNM", SqlDbType.NVarChar );
                        findShiftNm.Value = SqlDataMediator.SqlSetString( mdlPara.ShiftNm );
                    }

                    // 駆動方式名称
                    if ( mdlPara.WheelDriveMethodNm != string.Empty )
                    {
                        wherestr += " AND (FSP.WHEELDRIVEMETHODNMRF IS NULL OR FSP.WHEELDRIVEMETHODNMRF = @FINDWHEELDRIVEMETHODNM OR FSP.WHEELDRIVEMETHODNMRF = '') ";
                        SqlParameter findWheelDriveMethodNm = sqlCommand.Parameters.Add( "@FINDWHEELDRIVEMETHODNM", SqlDbType.NVarChar );
                        findWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString( mdlPara.WheelDriveMethodNm );
                    }
                    # endregion
                }
                # endregion

                orderstring = " ORDER BY FSP.FULLMODELRF, FSP.GOODSNORF, FSP.GOODSMAKERCDRF, FSP.MODELPRTSADPTFRAMENORF, PRC.PRICESTARTDATERF DESC";

                string strdum = selectstr + fromstr + wherestr + orderstring;

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strdum;
                sqlCommand.Transaction = null;


                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // 自由検索部品固有番号の取得
                    string freSrchPrtPropNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRESRCHPRTPROPNORF" ) );  // 自由検索部品固有番号
                    
                    // 固有番号の重複チェック（価格マスタが複数レコード有る場合もこのチェックで最新のみ残る）
                    if ( freSrchPrtPropNoDic.ContainsKey( freSrchPrtPropNo ) )
                    {
                        continue;
                    }
                    freSrchPrtPropNoDic.Add( freSrchPrtPropNo, true );

                    // 抽出結果セット
                    mf = new FreeSearchPartsSRetWork();

                    # region [抽出結果のセット]
                    mf.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "CREATEDATETIMERF" ) );  // 作成日時
                    mf.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );  // 更新日時
                    mf.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );  // 企業コード
                    mf.FileHeaderGuid = SqlDataMediator.SqlGetGuid( myReader, myReader.GetOrdinal( "FILEHEADERGUIDRF" ) );  // GUID
                    mf.UpdEmployeeCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDEMPLOYEECODERF" ) );  // 更新従業員コード
                    mf.UpdAssemblyId1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID1RF" ) );  // 更新アセンブリID1
                    mf.UpdAssemblyId2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID2RF" ) );  // 更新アセンブリID2
                    mf.LogicalDeleteCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "LOGICALDELETECODERF" ) );  // 論理削除区分
                    mf.FreSrchPrtPropNo = freSrchPrtPropNo;  // 自由検索部品固有番号
                    mf.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );  // メーカーコード
                    mf.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );  // 車種コード
                    mf.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );  // 車種サブコード
                    mf.FullModel = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );  // 型式（フル型）
                    mf.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );  // ＢＬコード
                    mf.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCDDERIVEDNORF" ) );  // ＢＬコード枝番
                    mf.GoodsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );  // 商品番号
                    mf.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNONONEHYPHENRF" ) );  // ハイフン無商品番号
                    mf.GoodsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );  // 商品メーカーコード
                    mf.PartsQty = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSQTYRF" ) );  // 部品QTY
                    mf.PartsOpNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSOPNMRF" ) );  // 部品オプション名称
                    mf.ModelPrtsAdptYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "MODELPRTSADPTYMRF" ) );  // 型式別部品採用年月
                    mf.ModelPrtsAblsYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "MODELPRTSABLSYMRF" ) );  // 型式別部品廃止年月
                    mf.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELPRTSADPTFRAMENORF" ) );  // 型式別部品採用車台番号
                    mf.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELPRTSABLSFRAMENORF" ) );  // 型式別部品廃止車台番号
                    mf.ModelGradeNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELGRADENMRF" ) );  // 型式グレード名称
                    mf.BodyName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BODYNAMERF" ) );  // ボディー名称
                    mf.DoorCount = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DOORCOUNTRF" ) );  // ドア数
                    mf.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) );  // エンジン型式名称
                    mf.EngineDisplaceNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEDISPLACENMRF" ) );  // 排気量名称
                    mf.EDivNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EDIVNMRF" ) );  // E区分名称
                    mf.TransmissionNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRANSMISSIONNMRF" ) );  // ミッション名称
                    mf.WheelDriveMethodNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WHEELDRIVEMETHODNMRF" ) );  // 駆動方式名称
                    mf.ShiftNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SHIFTNMRF" ) );  // シフト名称
                    mf.CreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "CREATEDATERF" ) );  // 作成日付
                    mf.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "UPDATEDATERF" ) );  // 更新年月日
                    mf.GoodsNoFromGoods = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNOFROMGOODSRF" ) );  // 商品番号[商品マスタ]
                    mf.GoodsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMERF" ) );  // 商品名称
                    mf.GoodsNameKana = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMEKANARF" ) );  // 商品名称カナ
                    mf.GoodsRateRank = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSRATERANKRF" ) );  // 商品掛率ランク
                    mf.GoodsNoFromPrice = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNOFROMPRICERF" ) );  // 商品番号[価格マスタ]
                    mf.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "PRICESTARTDATERF" ) );  // 価格開始日
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //mf.ListPrice = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICERF" ) );  // 定価
                    convertDoubleRelease.EnterpriseCode = mf.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = mf.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = mf.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    mf.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                    mf.OpenPriceDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );  // オープン価格区分
                    mf.BLGoodsFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSFULLNAMERF" ) );  // ＢＬ商品名称
                    mf.BLGoodsHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSHALFNAMERF" ) );  // ＢＬ商品名称カナ
                    mf.BLGoodsCodeFromGoods = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODEFROMGOODSRF" ) );  // 商品マスタＢＬコード
                    # endregion

                    # region [型式０・１・２のセット(指定された抽出条件より)]
                    if ( inPara.FSPartsSModels != null && inPara.FSPartsSModels.Length > modelIndex )
                    {
                        mf.ExhaustGasSign = inPara.FSPartsSModels[modelIndex].ExhaustGasSign;
                        mf.SeriesModel = inPara.FSPartsSModels[modelIndex].SeriesModel;
                        mf.CategorySignModel = inPara.FSPartsSModels[modelIndex].CategorySignModel;
                    }
                    # endregion

                    retInf.Add(mf);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                    myReader.Close();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion

        #region [ 同一部品情報圧縮処理 ]
        /// <summary>
        /// 同一部品圧縮処理
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retInf">抽出結果部品レコード</param>
        private void CompressPartsRec( FreeSearchPartsSParaWork inPara, ref ArrayList retInf )
        {
            ArrayList alwk = new ArrayList();
            FreeSearchPartsSRetWork rtwk = new FreeSearchPartsSRetWork();
            int existsFlag = 0;

            foreach ( FreeSearchPartsSRetWork mf in retInf )
            {
                if ( mf != null )
                {
                    existsFlag = 0;
                    foreach ( FreeSearchPartsSRetWork mf2 in alwk )
                    {
                        if ( mf2 != null )
                        {
                            if ( (mf.MakerCode == mf2.MakerCode) &&
                                (mf.GoodsNo == mf2.GoodsNo) &&
                                (mf.PartsQty == mf2.PartsQty) &&
                                (mf.PartsOpNm == mf2.PartsOpNm) )
                            {
                                if ( (((mf.ModelPrtsAdptYm == mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm == mf2.ModelPrtsAblsYm)) ||
                                     ((mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm)) ||
                                     ((mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm)) ||
                                     ((mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm))) &&
                                    (((mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo) && (mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo)) ||
                                       (mf.ModelPrtsAdptFrameNo >= mf2.ModelPrtsAdptFrameNo) && (mf.ModelPrtsAblsFrameNo <= mf2.ModelPrtsAblsFrameNo)) )
                                {
                                    if ( (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm )
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                        if ( mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm )
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }
                                    if ( (mf.ModelPrtsAdptYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAdptYm <= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAblsYm > mf2.ModelPrtsAblsYm )
                                            mf2.ModelPrtsAblsYm = mf.ModelPrtsAblsYm;
                                    }
                                    if ( (mf.ModelPrtsAblsYm >= mf2.ModelPrtsAdptYm) && (mf.ModelPrtsAblsYm <= mf2.ModelPrtsAblsYm) )
                                    {
                                        if ( mf.ModelPrtsAdptYm < mf2.ModelPrtsAdptYm )
                                            mf2.ModelPrtsAdptYm = mf.ModelPrtsAdptYm;
                                    }
                                    // 価格情報の更新
                                    if ( (mf2.PriceStartDate < mf.PriceStartDate) &&
                                         (mf.PriceStartDate <= inPara.PriceStartDate) )
                                    {
                                        mf2.ListPrice = mf.ListPrice; // 部品価格
                                        mf2.PriceStartDate = mf.PriceStartDate; // 部品価格開始日
                                        mf2.OpenPriceDiv = mf.OpenPriceDiv; // オープン価格区分
                                    }
                                    if ( (mf.ModelPrtsAdptFrameNo <= mf2.ModelPrtsAdptFrameNo) && (mf.ModelPrtsAblsFrameNo >= mf2.ModelPrtsAblsFrameNo) )
                                    {
                                        if ( mf.ModelPrtsAdptFrameNo < mf2.ModelPrtsAdptFrameNo )
                                            mf2.ModelPrtsAdptFrameNo = mf.ModelPrtsAdptFrameNo;
                                        if ( mf.ModelPrtsAblsFrameNo > mf2.ModelPrtsAblsFrameNo )
                                            mf2.ModelPrtsAblsFrameNo = mf.ModelPrtsAblsFrameNo;
                                    }
                                    existsFlag = 1;

                                    break;
                                }
                            }
                        }
                    }
                    //重複していなければalwkにInsert
                    if ( existsFlag == 0 )
                    {
                        alwk.Add( mf );
                    }
                }
            }
            //圧縮済みArrayListを戻す
            retInf = alwk;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
