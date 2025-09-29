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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優良設定マスタ印刷DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入アンマッチリストの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class PrmSettingPrintOrderWorkDB : RemoteDB, IPrmSettingPrintOrderWorkDB
    {
        /// <summary>
        /// 優良設定マスタ印刷DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public PrmSettingPrintOrderWorkDB()
            :
        base("PMKEN02019D", "Broadleaf.Application.Remoting.ParamData.PrmSettingPrintResultWork", "PRMSETTINGURF") //基底クラスのコンストラクタ
        {
        }

        #region 優良設定マスタ印刷
        /// <summary>
        /// 指定された企業コードの優良設定マスタ印刷のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="prmSettingPrintResultWork">検索結果</param>
        /// <param name="prmSettingPrintOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの有料設定マスタ印刷を全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.24</br>
        public int Search(out object prmSettingPrintResultWork, object prmSettingPrintOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prmSettingPrintResultWork = null;

            PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork = prmSettingPrintOrderCndtnWork as PrmSettingPrintOrderCndtnWork;

            try
            {
                status = SearchProc(out prmSettingPrintResultWork, _prmSettingPrintOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrmSettingPrintOrderWork.Search Exception=" + ex.Message);
                prmSettingPrintResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの優良設定マスタ印刷のLISTを全て戻します
        /// </summary>
        /// <param name="prmSettingPrintResultWork">検索結果</param>
        /// <param name="prmSettingPrintOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの優良設定マスタ印刷のLISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br></br>
        private int SearchProc(out object prmSettingPrintResultWork, PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            prmSettingPrintResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _prmSettingPrintOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrmSettingPrintOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            prmSettingPrintResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	       PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,PRM.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,PRM.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                selectTxt += "        ,PRM.TBSPARTSCODERF" + Environment.NewLine;
                selectTxt += "        ,BLG.BLGOODSHALFNAMERF" + Environment.NewLine;
                selectTxt += "        ,PRM.PARTSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,MAK.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRIMEDISPORDERRF" + Environment.NewLine;
                selectTxt += "        ,MNG.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRMSETDTLNAME1RF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRMSETDTLNAME2RF" + Environment.NewLine;
                selectTxt += "        ,PRM.MAKERDISPORDERRF" + Environment.NewLine;
                selectTxt += "        ,PRM.PRIMEDISPLAYCODERF" + Environment.NewLine;
                selectTxt += " FROM PRMSETTINGURF AS PRM" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	SEC.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND SEC.SECTIONCODERF=PRM.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	GGR.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND GGR.GOODSMGROUPRF = PRM.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGOODSCDURF BLG" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	BLG.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND BLG.BLGOODSCODERF=PRM.TBSPARTSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	MAK.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND MAK.GOODSMAKERCDRF=PRM.PARTSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSMNGRF AS MNG" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	MNG.ENTERPRISECODERF=PRM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND MNG.SECTIONCODERF=PRM.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "	AND MNG.GOODSMAKERCDRF=PRM.PARTSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	AND MNG.BLGOODSCODERF=PRM.TBSPARTSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	SUP.ENTERPRISECODERF=MNG.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND SUP.SUPPLIERCDRF=MNG.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "" + Environment.NewLine;
                
                //WHERE文の作成
                 selectTxt += MakeWhereString(ref sqlCommand, _prmSettingPrintOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    PrmSettingPrintResultWork wkPrmSettingPrintResultWork = new PrmSettingPrintResultWork();
                    
                    //格納項目
                    wkPrmSettingPrintResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPrmSettingPrintResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkPrmSettingPrintResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkPrmSettingPrintResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrmSettingPrintResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    wkPrmSettingPrintResultWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrmSettingPrintResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    wkPrmSettingPrintResultWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrmSettingPrintResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkPrmSettingPrintResultWork.PrimeDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPORDERRF"));
                    wkPrmSettingPrintResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkPrmSettingPrintResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkPrmSettingPrintResultWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
                    wkPrmSettingPrintResultWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
                    wkPrmSettingPrintResultWork.MakerDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERDISPORDERRF"));
                    wkPrmSettingPrintResultWork.PrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPLAYCODERF"));                   
#endregion

                    al.Add(wkPrmSettingPrintResultWork);

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
                base.WriteErrorLog(ex, "PrmSettingPrintOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, PrmSettingPrintOrderCndtnWork _prmSettingPrintOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;


            //企業コード
            retstring += " PRM.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_prmSettingPrintOrderCndtnWork.EnterpriseCode);

            //拠点コード
            if (_prmSettingPrintOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _prmSettingPrintOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND PRM.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //商品中分類コード
            if (_prmSettingPrintOrderCndtnWork.St_GoodsMGroup != 0)
            {
                retstring += " AND PRM.GOODSMGROUPRF>=@STGOODSMGROUPRF" + Environment.NewLine;
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUPRF", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_prmSettingPrintOrderCndtnWork.St_GoodsMGroup);
            }
            if (_prmSettingPrintOrderCndtnWork.Ed_GoodsMGroup != 0)
            {
                retstring += " AND PRM.GOODSMGROUPRF<=@EDGOODSMGROUPRF" + Environment.NewLine;
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUPRF", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_prmSettingPrintOrderCndtnWork.Ed_GoodsMGroup);
            }
            #endregion
            return retstring;
        }
    }
}
