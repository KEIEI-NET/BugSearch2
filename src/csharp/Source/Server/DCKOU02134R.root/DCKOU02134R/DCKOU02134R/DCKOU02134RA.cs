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
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入返品伝票(鑑部)DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品伝票(鑑部)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.23  30290</br>
    /// <br>             得意先・仕入先分離対応</br>
    /// </remarks>
    [Serializable]
    public class StcRetGdsSlipTtlDataDB : RemoteDB, IStcRetGdsSlipTtlDataDB
    {
        /// <summary>
        /// 仕入返品伝票(鑑部)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        public StcRetGdsSlipTtlDataDB()
            :
            base("DCKOU02136D", "Broadleaf.Application.Remoting.ParamData.StcRetGdsSlipTtlDataWork", "STCRETGDSSLIPTTLDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入返品伝票(鑑部)情報LISTを戻します
        /// </summary>
        /// <param name="stcretgdsslipttlDataWork">検索結果</param>
        /// <param name="parastcretgdsslipttlExtraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入返品伝票(鑑部)情報LISTを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
        public int Search(out object stcretgdsslipttlDataWork, object parastcretgdsslipttlExtraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retWorkList = new CustomSerializeArrayList();

            try
            {
                // 検索パラメータチェック
                StcRetGdsSlipTtlExtraWork paraExtraWork = null;
                
                ArrayList paraList = parastcretgdsslipttlExtraWork as ArrayList;

                if (paraList != null)
                {
                    if (paraList.Count > 0)
                    {
                        paraExtraWork = paraList[0] as StcRetGdsSlipTtlExtraWork;
                    }
                }
                else
                {
                    paraExtraWork = parastcretgdsslipttlExtraWork as StcRetGdsSlipTtlExtraWork;
                }
                
                if (paraExtraWork == null)
                {
                    throw new Exception("検索パラメータの指定に誤りが有ります。");
                }

                // コネクション生成
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null)
                {
                    throw new Exception("SqlConnection の作成に失敗しました。");
                }

                sqlConnection.Open();

                // 暗号化部品準備処理
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });

                // 暗号化キーOPEN
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                status = SearchProc(out retWorkList, paraExtraWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StcRetGdsSlipTtlDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                // 暗号化キー破棄
                if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen)
                {
                    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                }

                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            stcretgdsslipttlDataWork = retWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の仕入返品伝票(鑑部)情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stcretgdsslipttldataWorkList">検索結果</param>
        /// <param name="stcretgdsslipttlExtraWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入返品伝票(鑑部)情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
		public int SearchProc(out CustomSerializeArrayList stcretgdsslipttldataWorkList, StcRetGdsSlipTtlExtraWork stcretgdsslipttlExtraWork, ref SqlConnection sqlConnection)
		{
			return this.SearchProcProc(out stcretgdsslipttldataWorkList, stcretgdsslipttlExtraWork, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の仕入返品伝票(鑑部)情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stcretgdsslipttldataWorkList">検索結果</param>
        /// <param name="stcretgdsslipttlExtraWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入返品伝票(鑑部)情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
		private int SearchProcProc(out CustomSerializeArrayList stcretgdsslipttldataWorkList, StcRetGdsSlipTtlExtraWork stcretgdsslipttlExtraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            CustomSerializeArrayList al = new CustomSerializeArrayList();
            try
            {
                string sqlText = "";
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [Select句]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
#if DEBUG
                sqlText += " ,'★自社情報' AS SEPARATOR1" + Environment.NewLine;
#endif
                sqlText += " ,CINF.COMPANYNAME1RF AS COINFNAME1RF" + Environment.NewLine;
                sqlText += " ,CINF.COMPANYNAME2RF AS COINFNAME2RF" + Environment.NewLine;
                sqlText += " ,CINF.POSTNORF AS COINFPOSTNORF" + Environment.NewLine;
                sqlText += " ,CINF.ADDRESS1RF AS COINFADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CINF.ADDRESS2RF AS COINFADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CINF.ADDRESS3RF AS COINFADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CINF.ADDRESS4RF AS COINFADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CINF.COMPANYTELNO1RF AS COINFTELNO1RF" + Environment.NewLine;
                sqlText += " ,CINF.COMPANYTELNO2RF AS COINFTELNO2RF" + Environment.NewLine;
                sqlText += " ,CINF.COMPANYTELNO3RF AS COINFTELNO3RF" + Environment.NewLine;
                sqlText += " ,CINF.COMPANYTELTITLE1RF AS COINFTELTITLE1RF" + Environment.NewLine;
                sqlText += " ,CINF.COMPANYTELTITLE2RF AS COINFTELTITLE2RF" + Environment.NewLine;
                sqlText += " ,CINF.COMPANYTELTITLE3RF AS COINFTELTITLE3RF" + Environment.NewLine;
#if DEBUG
                sqlText += " ,'★自社名称' AS SEPARATOR2" + Environment.NewLine;
#endif
                sqlText += " ,CNAM.COMPANYNAME1RF AS CONMNAME1RF" + Environment.NewLine;
                sqlText += " ,CNAM.COMPANYNAME2RF AS CONMNAME2RF" + Environment.NewLine;
                sqlText += " ,CNAM.POSTNORF AS CONMPOSTNORF" + Environment.NewLine;
                sqlText += " ,CNAM.ADDRESS1RF AS CONMADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CNAM.ADDRESS2RF AS CONMADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CNAM.ADDRESS3RF AS CONMADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CNAM.ADDRESS4RF AS CONMADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CNAM.COMPANYTELNO1RF AS CONMTELNO1RF" + Environment.NewLine;
                sqlText += " ,CNAM.COMPANYTELNO2RF AS CONMTELNO2RF" + Environment.NewLine;
                sqlText += " ,CNAM.COMPANYTELNO3RF AS CONMTELNO3RF" + Environment.NewLine;
                sqlText += " ,CNAM.COMPANYTELTITLE1RF AS CONMTELTITLE1RF" + Environment.NewLine;
                sqlText += " ,CNAM.COMPANYTELTITLE2RF AS CONMTELTITLE2RF" + Environment.NewLine;
                sqlText += " ,CNAM.COMPANYTELTITLE3RF AS CONMTELTITLE3RF" + Environment.NewLine;
#if DEBUG
                sqlText += " ,'★得意先' AS SEPARATOR3" + Environment.NewLine;
#endif
                sqlText += " ,SUPPL.SUPPHONORIFICTITLERF AS SUPPHONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERPOSTNORF) AS NVARCHAR(10)) AS SUPPLIERPOSTNORF" + Environment.NewLine;
                sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERADDR1RF) AS NVARCHAR(30)) AS SUPPLIERADDR1RF" + Environment.NewLine;
                sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERADDR3RF) AS NVARCHAR(22)) AS SUPPLIERADDR3RF" + Environment.NewLine;
                sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERADDR4RF) AS NVARCHAR(30)) AS SUPPLIERADDR4RF" + Environment.NewLine;
                sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERTELNORF) AS NVARCHAR(16)) AS SUPPLIERTELNORF" + Environment.NewLine;
                sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERTELNO2RF) AS NVARCHAR(16)) AS SUPPLIERTELNO2RF" + Environment.NewLine;
                //sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.HOMETELNORF) AS NVARCHAR(16)) AS CUSTHOMETELNORF" + Environment.NewLine;
                //sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.HOMEFAXNORF) AS NVARCHAR(16)) AS CUSTHOMEFAXNORF" + Environment.NewLine;
#if DEBUG                
                sqlText += " ,'★仕入' AS SEPARATOR4" + Environment.NewLine;
#endif
                sqlText += " ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                sqlText += " ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                sqlText += " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;
                sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;
                sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKINPUTCODERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,SLIP.RETGOODSREASONDIVRF" + Environment.NewLine;
                sqlText += " ,SLIP.RETGOODSREASONRF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                sqlText += " ,SLIP.TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;
                sqlText += " ,SLIP.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                sqlText += " ,SLIP.STCKDISTTLTAXEXCRF" + Environment.NewLine;
                sqlText += " ,SLIP.STCKDISTTLTAXINCLURF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPRF AS SLIP INNER JOIN" + Environment.NewLine;
                sqlText += "    SUPPLIERRF AS SUPPL" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = SUPPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.SUPPLIERCDRF = SUPPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    INNER JOIN COMPANYINFRF AS CINF" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = CINF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    INNER JOIN SECINFOSETRF AS SINF" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = SINF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.SECTIONCODERF = SINF.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    INNER JOIN COMPANYNMRF AS CNAM" + Environment.NewLine;
                sqlText += "      ON  SINF.ENTERPRISECODERF = CNAM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SINF.COMPANYNAMECD1RF = CNAM.COMPANYNAMECDRF" + Environment.NewLine;
                # endregion

                # region [Where句]
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CINF.COMPANYCODERF = 0" + Environment.NewLine;
                sqlText += "  AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                sqlText += "  AND SLIP.SUPPLIERSLIPCDRF = 20" + Environment.NewLine;
                sqlText += "  AND SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NVarChar).Value = stcretgdsslipttlExtraWork.EnterpriseCode;

                // 得意先コード
                if (stcretgdsslipttlExtraWork.SupplierCd > 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                    sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int).Value = stcretgdsslipttlExtraWork.SupplierCd;
                }

                // 拠点コード
                if (stcretgdsslipttlExtraWork.SectionCode != null && stcretgdsslipttlExtraWork.SectionCode.Length > 0)
                {
                    string[] sections = stcretgdsslipttlExtraWork.SectionCode;

                    for (int i = 0; i < sections.Length; i++)
                    {
                        sections[i] = "'" + sections[i] + "'";
                    }

                    string inText = string.Join(", ", sections);

                    sqlText += "  AND SLIP.SECTIONCODERF IN (" + inText + ")" + Environment.NewLine;
                }

                // 仕入入力者コード
                if (!string.IsNullOrEmpty(stcretgdsslipttlExtraWork.StockInputName))
                {
                    sqlText += "  AND SLIP.STOCKINPUTCODERF = @FINDSTOCKINPUTCODE" + Environment.NewLine;
                    sqlCommand.Parameters.Add("@FINDSTOCKINPUTCODE", SqlDbType.NVarChar).Value = stcretgdsslipttlExtraWork.StockInputName;
                }

                // 仕入伝票番号(開始)
                if (stcretgdsslipttlExtraWork.SupplierSlipNoSt > 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF >= @FINDSUPPLIERSLIPNOST" + Environment.NewLine;
                    sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOST", SqlDbType.Int).Value = stcretgdsslipttlExtraWork.SupplierSlipNoSt;
                }

                // 仕入伝票番号(終了)
                if (stcretgdsslipttlExtraWork.SupplierSlipNoEd > 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF <= @FINDSUPPLIERSLIPNOED" + Environment.NewLine;
                    sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOED", SqlDbType.Int).Value = stcretgdsslipttlExtraWork.SupplierSlipNoEd;
                }

                // 仕入計上日(開始)
                if (stcretgdsslipttlExtraWork.StockAddUpADateSt > 0)
                {
                    sqlText += "  AND SLIP.STOCKADDUPADATERF >= @FINDSTOCKADDUPADATEST" + Environment.NewLine;
                    sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATEST", SqlDbType.Int).Value = stcretgdsslipttlExtraWork.StockAddUpADateSt;
                }

                // 仕入計上日(終了)
                if (stcretgdsslipttlExtraWork.StockAddUpADateEd > 0)
                {
                    sqlText += "  AND SLIP.STOCKADDUPADATERF <= @FINDSTOCKADDUPADATEED" + Environment.NewLine;
                    sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATEED", SqlDbType.Int).Value = stcretgdsslipttlExtraWork.StockAddUpADateEd;
                }

                # endregion

                sqlText += "ORDER BY" + Environment.NewLine;
                sqlText += "  SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;

#if DEBUG
                Console.Clear();
                Console.WriteLine("--- 変数 ---");

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    string sqlDbType = param.SqlDbType.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                    }

                    string value = param.Value.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        value = string.Format("'{0}'", param.Value);
                    }

                    Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                    Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                    Console.WriteLine("");
                }

                Console.WriteLine("--- SQL ---");
                Console.WriteLine(sqlText);
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStcRetGdsSlipTtlDataWorkFromReader(ref myReader));
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
                base.WriteErrorLog(ex, "StcRetGdsSlipTtlDataDB.SearchProc");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stcretgdsslipttldataWorkList = al;
            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StcRetGdsSlipTtlDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StcRetGdsSlipTtlDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private StcRetGdsSlipTtlDataWork CopyToStcRetGdsSlipTtlDataWorkFromReader(ref SqlDataReader myReader)
        {
            StcRetGdsSlipTtlDataWork retWork = new StcRetGdsSlipTtlDataWork();

            #region クラスへ格納
            retWork.SuppHonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
            retWork.SupplierPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERPOSTNORF"));
            retWork.SupplierAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR1RF"));
            retWork.SupplierAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR3RF"));
            retWork.SupplierAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR4RF"));
            retWork.SupplierTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNORF"));
            retWork.SupplierTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO2RF"));
            retWork.CoInfName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFNAME1RF"));
            retWork.CoInfName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFNAME2RF"));
            retWork.CoInfPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFPOSTNORF"));
            retWork.CoInfAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFADDRESS1RF"));
            retWork.CoInfAddress2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COINFADDRESS2RF"));
            retWork.CoInfAddress3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFADDRESS3RF"));
            retWork.CoInfAddress4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFADDRESS4RF"));
            retWork.CoInfTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFTELNO1RF"));
            retWork.CoInfTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFTELNO2RF"));
            retWork.CoInfTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFTELNO3RF"));
            retWork.CoInfTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFTELTITLE1RF"));
            retWork.CoInfTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFTELTITLE2RF"));
            retWork.CoInfTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COINFTELTITLE3RF"));
            retWork.CoNmName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMNAME1RF"));
            retWork.CoNmName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMNAME2RF"));
            retWork.CoNmPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMPOSTNORF"));
            retWork.CoNmAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMADDRESS1RF"));
            retWork.CoNmAddress2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONMADDRESS2RF"));
            retWork.CoNmAddress3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMADDRESS3RF"));
            retWork.CoNmAddress4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMADDRESS4RF"));
            retWork.CoNmTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMTELNO1RF"));
            retWork.CoNmTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMTELNO2RF"));
            retWork.CoNmTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMTELNO3RF"));
            retWork.CoNmTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMTELTITLE1RF"));
            retWork.CoNmTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMTELTITLE2RF"));
            retWork.CoNmTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONMTELTITLE3RF"));
            retWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            retWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            retWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            retWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            retWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            retWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            retWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            retWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            retWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            retWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            retWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            retWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            retWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            retWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            retWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            retWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            retWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            retWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            retWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            retWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            retWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            retWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            retWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            retWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            retWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            retWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            retWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            retWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            retWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
            retWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            retWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            retWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            retWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            retWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            #endregion

            return retWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
