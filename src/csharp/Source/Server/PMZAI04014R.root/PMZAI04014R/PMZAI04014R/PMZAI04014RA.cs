using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
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
    /// 在庫仕入伝票検索リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫仕入伝票(在庫調整データ)の検索を行うクラスです</br>
    /// <br>Programmer : 22018　鈴木　正臣</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class StockAdjRefSearchDB : RemoteDB, IStockAdjRefSearchDB
    {
        /// <summary>
        /// 在庫仕入伝票検索リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22018　鈴木　正臣</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public StockAdjRefSearchDB()
            : base( "PMZAI04016D", "Broadleaf.Application.Remoting.ParamData.StockAdjRefSearchParaWork", "STOCKADJUSTRF" )
        {
        }

        #region[指定paraの在庫調整データLIST]
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての在庫調整データLISTを戻します
        /// </summary>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="retObj">検索結果在庫調整データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定されたパラメータの条件を満たす全ての在庫調整データLISTを戻します</br>
        /// <br>Programmer : 22018　鈴木　正臣</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public int Search( ref object paraObj, out object retObj )
        {
            return SearchProc( ref paraObj, out retObj );
        }
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての在庫調整データLISTを戻します
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retObj"></param>
        /// <returns></returns>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        private int SearchProc(ref object paraObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●検索パラメータList・検索結果リターンList
            CustomSerializeArrayList paraList = paraObj as CustomSerializeArrayList;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            retObj = null;

            //●検索パラメータチェック
            if (paraObj == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。検索対象パラメータListが未指定です");
                return status;
            }

            // ---ADD 2011/03/22---------->>>>>
            StockAdjRefSearchParaWork searchPara = new StockAdjRefSearchParaWork();
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            SqlConnection sqlConnection = null;

            //●検索パラメータの取り出し
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is StockAdjRefSearchParaWork)
                {
                    searchPara = paraList[i] as StockAdjRefSearchParaWork;
                }
            }

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, searchPara.EnterpriseCode, "在庫仕入伝票照会", "抽出開始");
            // ---ADD 2011/03/22----------<<<<<

            //●検索処理実行
            status = SearchProc(paraList, out retList);

            // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, searchPara.EnterpriseCode, "在庫仕入伝票照会", "抽出終了");
            }
            catch
            {
                //なし。
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // ---ADD 2011/03/22----------<<<<<

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    retObj = (object)retList;
            //}
            retObj = (object)retList;

            return status;
        }

        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての在庫調整データLISTを戻します
        /// </summary>
        /// <param name="paraList">検索パラメータ</param>
        /// <param name="retList">検索結果在庫調整データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす全ての在庫調整データLISTを戻します</br>
        /// <br>Programmer : 22018　鈴木　正臣</br>
        /// <br>Date       : 2008.08.20</br>
        private int SearchProc(CustomSerializeArrayList paraList, out CustomSerializeArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            SqlConnection sqlConnection = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //SqlEncryptInfo sqlEncriptInfo = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            SqlDataReader myReader = null;

            //●検索パラメータ格納用
            StockAdjRefSearchParaWork searchPara = null;

            //●検索結果格納用List
            retList = new CustomSerializeArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //●検索パラメータの取り出し
                if (paraList != null)
                {
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        if (paraList[i] is StockAdjRefSearchParaWork)
                        {
                            searchPara = paraList[i] as StockAdjRefSearchParaWork;
                        }
                    }
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "STOCKSLIPRF", "STOCKDETAILRF", "STOCKEXPLADATARF" });
                //●暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if (searchPara != null)
                {
                    string sqlText = string.Empty;
                    SqlCommand sqlCommand = new SqlCommand( sqlText, sqlConnection );

                    //●SQL構文生成

                    # region [SELECT文生成]

                    # region //delete
                    //// Select
                    //sqlText += "SELECT " + Environment.NewLine;
                    //sqlText += "  ADJ.ENTERPRISECODERF," + Environment.NewLine;
                    //sqlText += "  ADJ.SECTIONCODERF," + Environment.NewLine;
                    //sqlText += "  SEC.SECTIONGUIDESNMRF," + Environment.NewLine;
                    //sqlText += "  DTL.WAREHOUSECODERF," + Environment.NewLine;
                    //sqlText += "  DTL.WAREHOUSENAMERF," + Environment.NewLine;
                    //sqlText += "  ADJ.ACPAYSLIPCDRF," + Environment.NewLine;
                    //sqlText += "  ADJ.ACPAYTRANSCDRF," + Environment.NewLine;
                    //sqlText += "  ADJ.INPUTDAYRF," + Environment.NewLine;
                    //sqlText += "  ADJ.ADJUSTDATERF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKADJUSTSLIPNORF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKAGENTCODERF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKAGENTNAMERF," + Environment.NewLine;
                    //sqlText += "  ADJ.SLIPNOTERF," + Environment.NewLine;
                    //sqlText += "  ADJ.STOCKSUBTTLPRICERF" + Environment.NewLine;

                    //sqlText += "FROM " + Environment.NewLine;
                    //sqlText += "  STOCKADJUSTRF AS ADJ" + Environment.NewLine;

                    //// LeftJoin SEC
                    //sqlText += "LEFT JOIN" + Environment.NewLine;
                    //sqlText += "  SECINFOSETRF AS SEC" + Environment.NewLine;
                    //sqlText += "ON" + Environment.NewLine;
                    //sqlText += "  ADJ.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                    //// LeftJoin DTL
                    //sqlText += "LEFT JOIN" + Environment.NewLine;
                    //sqlText += "  STOCKADJUSTDTLRF AS DTL" + Environment.NewLine;
                    //sqlText += "ON" + Environment.NewLine;
                    //sqlText += "  ADJ.ENTERPRISECODERF=DTL.ENTERPRISECODERF" + Environment.NewLine;
                    //sqlText += "  AND ADJ.STOCKADJUSTSLIPNORF=DTL.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    //sqlText += "  AND DTL.STOCKADJUSTROWNORF='1'" + Environment.NewLine;

                    //// Where
                    //sqlText += MakeWhereString( ref sqlCommand, searchPara );
                    # endregion

                    // Select
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "  ADJ.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  SEC.SECTIONGUIDESNMRF," + Environment.NewLine;
                    sqlText += "  DTL.WAREHOUSECODERF," + Environment.NewLine;
                    sqlText += "  DTL.WAREHOUSENAMERF," + Environment.NewLine;
                    sqlText += "  ADJ.ACPAYSLIPCDRF," + Environment.NewLine;
                    sqlText += "  ADJ.ACPAYTRANSCDRF," + Environment.NewLine;
                    sqlText += "  ADJ.INPUTDAYRF," + Environment.NewLine;
                    sqlText += "  ADJ.ADJUSTDATERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKADJUSTSLIPNORF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKAGENTCODERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKAGENTNAMERF," + Environment.NewLine;
                    sqlText += "  ADJ.SLIPNOTERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKSUBTTLPRICERF" + Environment.NewLine;

                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    
                    # region [SLP]
                    // Select SLP
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += "  ADJS.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  ADJS.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "  STOCKADJUSTRF AS ADJS" + Environment.NewLine;
                    sqlText += "JOIN " + Environment.NewLine;
                    sqlText += "  STOCKADJUSTDTLRF AS DTLS" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  ADJS.ENTERPRISECODERF=DTLS.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ADJS.STOCKADJUSTSLIPNORF=DTLS.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    // Where
                    sqlText += MakeWhereString( ref sqlCommand, searchPara );

                    # endregion

                    sqlText += ") AS SLP" + Environment.NewLine;

                    // LeftJoin ADJ
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKADJUSTRF AS ADJ" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  SLP.ENTERPRISECODERF=ADJ.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND SLP.STOCKADJUSTSLIPNORF=ADJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;

                    // LeftJoin SEC
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  SECINFOSETRF AS SEC" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  ADJ.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ADJ.STOCKSECTIONCDRF=SEC.SECTIONCODERF" + Environment.NewLine;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
                    // LeftJoin DTLROW
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  SELECT " + Environment.NewLine;
                    sqlText += "    ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "    STOCKADJUSTSLIPNORF," + Environment.NewLine;
                    sqlText += "    MIN(STOCKADJUSTROWNORF) AS ROWNO" + Environment.NewLine;
                    sqlText += "  FROM STOCKADJUSTDTLRF" + Environment.NewLine;
                    sqlText += "  GROUP BY" + Environment.NewLine;
                    sqlText += "    ENTERPRISECODERF,STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    sqlText += ") AS DTLROW" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  DTLROW.ENTERPRISECODERF=ADJ.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND DTLROW.STOCKADJUSTSLIPNORF=ADJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

                    // LeftJoin DTL
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKADJUSTDTLRF AS DTL" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  ADJ.ENTERPRISECODERF=DTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ADJ.STOCKADJUSTSLIPNORF=DTL.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
                    //sqlText += "  AND DTL.STOCKADJUSTROWNORF='1'" + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
                    sqlText += "  AND DTL.STOCKADJUSTSLIPNORF=DTLROW.STOCKADJUSTSLIPNORF" + Environment.NewLine;
                    sqlText += "  AND DTL.STOCKADJUSTROWNORF=DTLROW.ROWNO" + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

                    // OrderBy
                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "  ADJ.ADJUSTDATERF," + Environment.NewLine;
                    sqlText += "  ADJ.STOCKADJUSTSLIPNORF" + Environment.NewLine;

                    # endregion

                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();

                    while ( myReader.Read() )
                    {
                        //●検索結果を格納
                        retList.Add( CopyToRetWork( ref myReader ) );
                    }

                    if ( retList.Count > 0 )
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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
                base.WriteErrorLog(ex, "SearchStockSlipDB.SearchProc Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (myReader != null && myReader.IsClosed == false) myReader.Close();
                ////暗号化キークローズ
                //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region[Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="searchPara">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>WHERE句生成を使い回す為、SQL文文字列生成とパラメータ設定を分けて記載します。</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAdjRefSearchParaWork searchPara )
        {
            string retstring = "WHERE" + Environment.NewLine;

            # region [条件]

            // 企業コード
            retstring += "  ADJS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString( searchPara.EnterpriseCode );

            // 論理削除
            retstring += "  AND ADJS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            retstring += "  AND DTLS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32( (int)ConstantManagement.LogicalMode.GetData0 );

            // 拠点コード
            if ( searchPara.SectionCode != string.Empty )
            {
                retstring += "  AND ADJS.STOCKSECTIONCDRF=@FINDSECTIONCODE " + Environment.NewLine;
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSECTIONCODE", SqlDbType.NChar );
                findParaSectionCode.Value = SqlDataMediator.SqlSetString( searchPara.SectionCode );
            }
            // 倉庫コード
            if ( searchPara.WarehouseCode != string.Empty )
            {
                retstring += "  AND DTLS.WAREHOUSECODERF=@FINDWAREHOUSECODE " + Environment.NewLine;
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add( "@FINDWAREHOUSECODE", SqlDbType.NChar );
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString( searchPara.WarehouseCode );
            }
            // 受払元伝票区分
            if ( searchPara.AcPaySlipCd != 0 )
            {
                retstring += "  AND ADJS.ACPAYSLIPCDRF=@FINDACPAYSLIPCD " + Environment.NewLine;
                SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add( "@FINDACPAYSLIPCD", SqlDbType.Int );
                findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32( searchPara.AcPaySlipCd );
            }
            // 受払元取引区分
            if ( searchPara.AcPayTransCd != 0 )
            {
                retstring += "  AND ADJS.ACPAYTRANSCDRF=@FINDACPAYTRANSCD " + Environment.NewLine;
                SqlParameter findParaAcPayTransCd = sqlCommand.Parameters.Add( "@FINDACPAYTRANSCD", SqlDbType.Int );
                findParaAcPayTransCd.Value = SqlDataMediator.SqlSetInt32( searchPara.AcPayTransCd );
            }
            // 開始入力日付
            if ( searchPara.St_InputDay != 0 )
            {
                retstring += "  AND ADJS.INPUTDAYRF>=@FINDST_INPUTDAY " + Environment.NewLine;
                SqlParameter findParaSt_InputDay = sqlCommand.Parameters.Add( "@FINDST_INPUTDAY", SqlDbType.Int );
                findParaSt_InputDay.Value = SqlDataMediator.SqlSetInt32( searchPara.St_InputDay );
            }
            // 終了入力日付
            if ( searchPara.Ed_InputDay != 0 )
            {
                retstring += "  AND ADJS.INPUTDAYRF<=@FINDED_INPUTDAY " + Environment.NewLine;
                SqlParameter findParaEd_InputDay = sqlCommand.Parameters.Add( "@FINDED_INPUTDAY", SqlDbType.Int );
                findParaEd_InputDay.Value = SqlDataMediator.SqlSetInt32( searchPara.Ed_InputDay );
            }
            // 開始調整日付
            if ( searchPara.St_AdjustDate != 0 )
            {
                retstring += "  AND ADJS.ADJUSTDATERF>=@FINDST_ADJUSTDATE " + Environment.NewLine;
                SqlParameter findParaSt_AdjustDate = sqlCommand.Parameters.Add( "@FINDST_ADJUSTDATE", SqlDbType.Int );
                findParaSt_AdjustDate.Value = SqlDataMediator.SqlSetInt32( searchPara.St_AdjustDate );
            }
            // 終了調整日付
            if ( searchPara.Ed_AdjustDate != 0 )
            {
                retstring += "  AND ADJS.ADJUSTDATERF<=@FINDED_ADJUSTDATE " + Environment.NewLine;
                SqlParameter findParaEd_AdjustDate = sqlCommand.Parameters.Add( "@FINDED_ADJUSTDATE", SqlDbType.Int );
                findParaEd_AdjustDate.Value = SqlDataMediator.SqlSetInt32( searchPara.Ed_AdjustDate );
            }
            // 開始在庫調整伝票番号
            if ( searchPara.St_StockAdjustSlipNo != 0 )
            {
                retstring += "  AND ADJS.STOCKADJUSTSLIPNORF>=@FINDST_STOCKADJUSTSLIPNO " + Environment.NewLine;
                SqlParameter findParaSt_StockAdjustSlipNo = sqlCommand.Parameters.Add( "@FINDST_STOCKADJUSTSLIPNO", SqlDbType.Int );
                findParaSt_StockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32( searchPara.St_StockAdjustSlipNo );
            }
            // 終了在庫調整伝票番号
            if ( searchPara.Ed_StockAdjustSlipNo != 0 )
            {
                retstring += "  AND ADJS.STOCKADJUSTSLIPNORF<=@FINDED_STOCKADJUSTSLIPNO " + Environment.NewLine;
                SqlParameter findParaEd_StockAdjustSlipNo = sqlCommand.Parameters.Add( "@FINDED_STOCKADJUSTSLIPNO", SqlDbType.Int );
                findParaEd_StockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32( searchPara.Ed_StockAdjustSlipNo );
            }
            // 仕入担当者コード
            if ( searchPara.StockAgentCode != string.Empty )
            {
                retstring += "  AND ADJS.STOCKAGENTCODERF=@FINDSTOCKAGENTCODE " + Environment.NewLine;
                SqlParameter findParaStockAgentCode = sqlCommand.Parameters.Add( "@FINDSTOCKAGENTCODE", SqlDbType.NVarChar );
                findParaStockAgentCode.Value = SqlDataMediator.SqlSetString( searchPara.StockAgentCode );
            }
            // 商品メーカーコード
            if ( searchPara.GoodsMakerCd != 0 )
            {
                retstring += "  AND DTLS.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( searchPara.GoodsMakerCd );
            }
            // 商品番号
            if ( searchPara.GoodsNo != string.Empty )
            {
                retstring += "  AND DTLS.GOODSNORF" + MakeMarkFromType( searchPara.GoodsNoTyp ) + "@FINDGOODSNO " + Environment.NewLine;
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NVarChar );
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString( MakeLikeStringFromType( searchPara.GoodsNo, searchPara.GoodsNoTyp ) );
            }
            // 商品名称
            if ( searchPara.GoodsName != string.Empty )
            {
                retstring += "  AND DTLS.GOODSNAMERF" + MakeMarkFromType( searchPara.GoodsNameTyp ) + "@FINDGOODSNAME " + Environment.NewLine;
                SqlParameter findParaGoodsName = sqlCommand.Parameters.Add( "@FINDGOODSNAME", SqlDbType.NVarChar );
                findParaGoodsName.Value = SqlDataMediator.SqlSetString( MakeLikeStringFromType( searchPara.GoodsName, searchPara.GoodsNameTyp ) );
            }
            // 倉庫棚番
            if ( searchPara.WarehouseShelfNo != string.Empty )
            {
                retstring += "  AND DTLS.WAREHOUSESHELFNORF" + MakeMarkFromType( searchPara.WarehouseShelfNoTyp ) + "@FINDWAREHOUSESHELFNO " + Environment.NewLine;
                SqlParameter findParaWarehouseShelfNo = sqlCommand.Parameters.Add( "@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar );
                findParaWarehouseShelfNo.Value = SqlDataMediator.SqlSetString( MakeLikeStringFromType( searchPara.WarehouseShelfNo, searchPara.WarehouseShelfNoTyp ) );
            }

            # endregion

            return retstring;
        }
        /// <summary>
        /// 検索タイプ別 Like文字列取得
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchType"></param>
        /// <returns></returns>
        private string MakeLikeStringFromType( string value, int searchType )
        {
            switch ( searchType )
            {
                case 0:
                    {
                        // 完全一致
                        return string.Format( "{0}", value );
                    }
                case 1:
                    {
                        // 前方一致
                        return string.Format( "{0}%", value );
                    }
                case 2:
                    {
                        // 後方一致
                        return string.Format( "%{0}", value );
                    }
                case 3:
                default:
                    {
                        // あいまい
                        return string.Format( "%{0}%", value );
                    }
            }
        }
        /// <summary>
        /// 検索タイプ別 記号取得
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        private string MakeMarkFromType( int searchType )
        {
            if ( searchType == 0 )
            {
                // 完全一致
                return " = ";
            }
            else
            {
                return " LIKE ";
            }
        }
        #endregion

        #region[検索結果クラス格納]
        /// <summary>
        /// 仕入検索結果クラス出力処理
        /// </summary>
        /// <param name="myReader">検索結果</param>
        /// <returns>出力クラス</returns>
        /// <remarks>
        /// <br>Note       : 仕入検索結果クラス出力処理</br>
        /// <br>Programmer : 22018　鈴木　正臣</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        private StockAdjRefSearchRetWork CopyToRetWork(ref SqlDataReader myReader)
        {
            StockAdjRefSearchRetWork stockAdjRefSearchRetWork = new StockAdjRefSearchRetWork();

            # region [copy]
            stockAdjRefSearchRetWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) ); // 企業コード
            stockAdjRefSearchRetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF")); // 拠点コード
            stockAdjRefSearchRetWork.SectionGuideSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONGUIDESNMRF" ) ); // 拠点ガイド略称
            stockAdjRefSearchRetWork.WarehouseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSECODERF" ) ); // 倉庫コード
            stockAdjRefSearchRetWork.WarehouseName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENAMERF" ) ); // 倉庫名称
            stockAdjRefSearchRetWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPAYSLIPCDRF" ) ); // 受払元伝票区分
            stockAdjRefSearchRetWork.AcPayTransCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPAYTRANSCDRF" ) ); // 受払元取引区分
            stockAdjRefSearchRetWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "INPUTDAYRF" ) ); // 入力日付
            stockAdjRefSearchRetWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "ADJUSTDATERF" ) ); // 調整日付
            stockAdjRefSearchRetWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STOCKADJUSTSLIPNORF" ) ); // 在庫調整伝票番号
            stockAdjRefSearchRetWork.StockAgentCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKAGENTCODERF" ) ); // 仕入担当者コード
            stockAdjRefSearchRetWork.StockAgentName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKAGENTNAMERF" ) ); // 仕入担当者名称
            stockAdjRefSearchRetWork.SlipNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTERF" ) ); // 伝票備考
            stockAdjRefSearchRetWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "STOCKSUBTTLPRICERF" ) ); // 仕入金額
            # endregion

            return stockAdjRefSearchRetWork;
        }
        #endregion
    }
}
