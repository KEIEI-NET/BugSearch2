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
    /// 入庫予定表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入庫予定表実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.9.18</br>
    /// <br>Note       : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/09/14</br>
    /// </remarks>
    [Serializable]
    public class EnterSchOrderWorkDB : RemoteDB, IEnterSchOrderWorkDB
    {
        /// <summary>
        /// 入庫予定表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.18</br>
        /// </remarks>
        public EnterSchOrderWorkDB()
            :
        base("PMUOE02068D", "Broadleaf.Application.Remoting.ParamData.EnterSchResultWork", "UOEORDERDTLRF") //基底クラスのコンストラクタ
        {
        }

        #region 入庫予定表
        /// <summary>
        /// 指定された企業コードの入庫予定表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="enterSchResultWork">検索結果</param>
        /// <param name="enterSchOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの発行確認一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.18</br>
        public int Search(out object enterSchResultWork, object enterSchOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            enterSchResultWork = null;

            EnterSchOrderCndtnWork _enterSchOrderCndtnWork = enterSchOrderCndtnWork as EnterSchOrderCndtnWork;

            try
            {
                status = SearchProc(out enterSchResultWork, _enterSchOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EnterSchOrderWork.Search Exception=" + ex.Message);
                enterSchResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの入庫予定表LISTを全て戻します
        /// </summary>
        /// <param name="enterSchResultWork">検索結果</param>
        /// <param name="_enterSchOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの発行確認一覧表LISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        private int SearchProc(out object enterSchResultWork, EnterSchOrderCndtnWork _enterSchOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            enterSchResultWork = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _enterSchOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "enterSchResultWorkDB.SearchProc Exception=" + ex.Message);
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

            enterSchResultWork = al;

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
        /// <remarks>
        /// <br>Note       : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, EnterSchOrderCndtnWork _enterSchOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += "	       UOD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAKERFOLLOWCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.EOALWCCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERLISTPRICERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTIONSLIPNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.RECEIVEDATERF" + Environment.NewLine;
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                selectTxt += "        ,UOD.COMMASSEMBLYIDRF" + Environment.NewLine;
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
                selectTxt += " FROM UOEORDERDTLRF AS UOD" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  SEC.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;


                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _enterSchOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;


                #endregion

               myReader = sqlCommand.ExecuteReader(); 
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    EnterSchResultWork wkEnterSchResultWork = new EnterSchResultWork();

                    //格納項目
                    wkEnterSchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkEnterSchResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkEnterSchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkEnterSchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkEnterSchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkEnterSchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkEnterSchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkEnterSchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkEnterSchResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkEnterSchResultWork.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));
                    wkEnterSchResultWork.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));
                    wkEnterSchResultWork.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));
                    wkEnterSchResultWork.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));
                    wkEnterSchResultWork.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));
                    wkEnterSchResultWork.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));
                    wkEnterSchResultWork.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERLISTPRICERF"));
                    wkEnterSchResultWork.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERSALESUNITCOSTRF"));
                    wkEnterSchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkEnterSchResultWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));
                    wkEnterSchResultWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));
                    wkEnterSchResultWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));
                    wkEnterSchResultWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));
                    wkEnterSchResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkEnterSchResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkEnterSchResultWork.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECEIVEDATERF"));

                    // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                    wkEnterSchResultWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                    // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

                    #endregion
                    if (_enterSchOrderCndtnWork.PrintTypeCndtn == 0)
                    {
                        if ((wkEnterSchResultWork.UOESectOutGoodsCnt + wkEnterSchResultWork.BOShipmentCnt1 + wkEnterSchResultWork.BOShipmentCnt2 + wkEnterSchResultWork.BOShipmentCnt3 + wkEnterSchResultWork.MakerFollowCnt + wkEnterSchResultWork.EOAlwcCount) != 0)
                        {
                            al.Add(wkEnterSchResultWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    else if (_enterSchOrderCndtnWork.PrintTypeCndtn == 2)
                    {
                        if ((wkEnterSchResultWork.UOESectOutGoodsCnt + wkEnterSchResultWork.BOShipmentCnt1 + wkEnterSchResultWork.BOShipmentCnt2 + wkEnterSchResultWork.BOShipmentCnt3 + wkEnterSchResultWork.MakerFollowCnt + wkEnterSchResultWork.EOAlwcCount) == 0)
                        {
                            al.Add(wkEnterSchResultWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    else
                    {
                        al.Add(wkEnterSchResultWork);
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
                base.WriteErrorLog(ex, "enterSchResultWorkDB.SearchOrderProc Exception=" + ex.Message);
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
        private string MakeWhereString(ref SqlCommand sqlCommand, EnterSchOrderCndtnWork _enterSchOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " UOD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_enterSchOrderCndtnWork.EnterpriseCode);

            //システム区分
            retstring += " AND UOD.SYSTEMDIVCDRF!=1" + Environment.NewLine;

            //拠点コード
            if (_enterSchOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _enterSchOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND UOD.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //範囲発注先コード
            if (_enterSchOrderCndtnWork.UOESupplierCds != null)
            {
                string uoeSupplierCdstr = "";
                foreach (int usupcdstr in _enterSchOrderCndtnWork.UOESupplierCds)
                {
                    if (uoeSupplierCdstr != "")
                    {
                        uoeSupplierCdstr += ",";
                    }
                    uoeSupplierCdstr += "'" + usupcdstr + "'";
                }

                if (uoeSupplierCdstr != "")
                {
                    retstring += " AND (UOD.UOESUPPLIERCDRF IN (" + uoeSupplierCdstr + ") OR UOD.UOESUPPLIERCDRF=0)" + Environment.NewLine;
                }
            }
            else
            {

                if (_enterSchOrderCndtnWork.St_UOESupplierCd != 0)
                {
                    retstring += " AND UOD.UOESUPPLIERCDRF>=@STUOESUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraStUOESupplierCd = sqlCommand.Parameters.Add("@STUOESUPPLIERCD", SqlDbType.Int);
                    paraStUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_enterSchOrderCndtnWork.St_UOESupplierCd);
                }
                if (_enterSchOrderCndtnWork.Ed_UOESupplierCd != 0)
                {
                    retstring += " AND UOD.UOESUPPLIERCDRF<=@EDUOESUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEdUOESupplierCd = sqlCommand.Parameters.Add("@EDUOESUPPLIERCD", SqlDbType.Int);
                    paraEdUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_enterSchOrderCndtnWork.Ed_UOESupplierCd);
                }
            }
            //受信日付
            if (_enterSchOrderCndtnWork.St_ReceiveDate != DateTime.MinValue)
            {

                retstring += " AND UOD.RECEIVEDATERF>=@STRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraStReceiveDate = sqlCommand.Parameters.Add("@STRECEIVEDATE", SqlDbType.Int);
                paraStReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_enterSchOrderCndtnWork.St_ReceiveDate);
            }
            if (_enterSchOrderCndtnWork.Ed_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF<=@EDRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraEdReceiveDate = sqlCommand.Parameters.Add("@EDRECEIVEDATE", SqlDbType.Int);
                paraEdReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_enterSchOrderCndtnWork.Ed_ReceiveDate);
            }

            //入庫更新区分
            if (_enterSchOrderCndtnWork.PrintTypeCndtn != 2)
            {
                retstring += " AND ((UOD.ENTERUPDDIVSECRF=0) OR (UOD.ENTERUPDDIVBO1RF=0) OR (UOD.ENTERUPDDIVBO2RF=0) OR (UOD.ENTERUPDDIVBO3RF=0) OR (UOD.ENTERUPDDIVMAKERRF=0) OR (UOD.ENTERUPDDIVEORF=0))" + Environment.NewLine;
            }

            //倉庫コード
            retstring += " AND UOD.WAREHOUSECODERF !=0" + Environment.NewLine;

            ////印刷タイプ　入庫分のみ
            //if (_enterSchOrderCndtnWork.PrintTypeCndtn == 0)
            //{
            //    retstring += " AND (UOD.UOESECTOUTGOODSCNTRF + UOD.BOSHIPMENTCNT1RF + UOD.BOSHIPMENTCNT2RF + UOD.BOSHIPMENTCNT3RF + UOD.MAKERFOLLOWCNTRF + UOD.EOALWCCOUNTRF) != 0" + Environment.NewLine;
            //}
            //印刷タイプ　メーカーフォロー分のみ
            if (_enterSchOrderCndtnWork.PrintTypeCndtn == 1)
            {
                retstring += " AND UOD.MAKERFOLLOWCNTRF != 0" + Environment.NewLine;
            }
            ////印刷タイプ　欠品分のみ　
            //else if (_enterSchOrderCndtnWork.PrintTypeCndtn == 2)
            //{
            //    retstring += " AND (UOD.UOESECTOUTGOODSCNTRF + UOD.BOSHIPMENTCNT1RF + UOD.BOSHIPMENTCNT2RF + UOD.BOSHIPMENTCNT3RF + UOD.MAKERFOLLOWCNTRF + UOD.EOALWCCOUNTRF) = 0" + Environment.NewLine;
            //}

            //送信フラグ
            retstring += " AND UOD.DATASENDCODERF=9" + Environment.NewLine;

            //復旧フラグ
            retstring += " AND UOD.DATARECOVERDIVRF=9" + Environment.NewLine;

            #endregion
            return retstring;
        }
    }
}