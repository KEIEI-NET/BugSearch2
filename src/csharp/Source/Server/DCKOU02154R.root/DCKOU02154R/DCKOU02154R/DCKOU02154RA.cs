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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d�����v�݌v�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����v�݌v�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2007.09.13</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.23  30290</br>
    /// <br>             ���Ӑ�E�d���敪���Ή�</br>
    /// </remarks>
    [Serializable]
    public class StockDayTotalDataDB : RemoteDB, IStockDayTotalDataDB
    {
        /// <summary>
        /// �d�����v�݌v�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        public StockDayTotalDataDB()
            :
            base("DCKOU02156D", "Broadleaf.Application.Remoting.ParamData.StockDayTotalDataWork", "STOCKDAYTOTALDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��߂��܂�
        /// </summary>
        /// <param name="stockdaytotalDataWork">��������</param>
        /// <param name="parastockdaytotalDataWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(0:�S���ҕ�,1:�S���ҁE�d�����)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
        public int Search(out object stockdaytotalDataWork, object parastockdaytotalDataWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockdaytotalDataWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();

                return SearchStockDayTotalDataProc(out stockdaytotalDataWork, parastockdaytotalDataWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDayTotalDataDB.Search");
                stockdaytotalDataWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objstockdaytotalDataWork">��������</param>
        /// <param name="parastockdaytotalDataWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(0:�S���ҕ�,1:�S���ҁE�d�����)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
        public int SearchStockDayTotalDataProc(out object objstockdaytotalDataWork, object parastockdaytotalDataWork, int readMode, ref SqlConnection sqlConnection)
        {
            StockDayTotalExtractWork stockdaytotalExtractWork = null;

            ArrayList stockdaytotaldataWorkList = parastockdaytotalDataWork as ArrayList;

            if (stockdaytotaldataWorkList == null)
            {
                stockdaytotalExtractWork = parastockdaytotalDataWork as StockDayTotalExtractWork;
            }
            else
            {
                if (stockdaytotaldataWorkList.Count > 0)
                {
                    stockdaytotalExtractWork = stockdaytotaldataWorkList[0] as StockDayTotalExtractWork;
                }
            }

            int status = SearchStockDayTotalDataProc(out stockdaytotaldataWorkList, stockdaytotalExtractWork, readMode, ref sqlConnection);

            objstockdaytotalDataWork = stockdaytotaldataWorkList;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockdaytotaldataWorkList">��������</param>
        /// <param name="stockdaytotalExtractWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(0:�S���ҕ�,1:�S���ҁE�d�����)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
		public int SearchStockDayTotalDataProc(out ArrayList stockdaytotaldataWorkList, StockDayTotalExtractWork stockdaytotalExtractWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.SearchStockDayTotalDataProcProc(out stockdaytotaldataWorkList, stockdaytotalExtractWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockdaytotaldataWorkList">��������</param>
        /// <param name="stockdaytotalExtractWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(0:�S���ҕ�,1:�S���ҁE�d�����)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����v�݌v�\���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
		private int SearchStockDayTotalDataProcProc(out ArrayList stockdaytotaldataWorkList, StockDayTotalExtractWork stockdaytotalExtractWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = "";

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;

                switch (readMode)
                {
                    case 0:
                        {
                            // �_�~�[�f�[�^��ݒ肷��
                            sqlText += " ,NULL AS SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM1" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM2" + Environment.NewLine;
                            break;
                        }
                    case 1:
                        {
                            // �S���ҕʁE�d����ʂ̏ꍇ�ɂ̂ݎd������𒊏o����
                            sqlText += " ,SLIP.SUPPLIERCDRF AS SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,SLIP.SUPPLIERNM1RF AS SUPPLIERNM1" + Environment.NewLine;
                            sqlText += " ,SLIP.SUPPLIERNM2RF AS SUPPLIERNM2" + Environment.NewLine;
                            break;
                        }
                    default:
                        {
                            // �s�K�؂ȃp�����[�^���ݒ肳��Ă���
                            base.WriteErrorLog(string.Format("SearchStockDayTotalDataProc: �����敪�ɕs�K�؂Ȓl���ݒ肳��Ă��܂��B({0})", readMode));
                            stockdaytotaldataWorkList = al;
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                }

                sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
                sqlText += " ,SUM(CASE DTIL.STOCKSLIPCDDTLRF WHEN 0 THEN DTIL.STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKTTLPRICERF" + Environment.NewLine;
                sqlText += " ,SUM(CASE DTIL.STOCKSLIPCDDTLRF WHEN 1 THEN DTIL.STOCKPRICETAXEXCRF ELSE 0 END) AS RETGOODSTTLPRICERF" + Environment.NewLine;
                sqlText += " ,SUM(CASE DTIL.STOCKSLIPCDDTLRF WHEN 2 THEN DTIL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISCOUNTTTLPRICERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "    INNER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "      AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "    LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [WHERE��]
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.EnterpriseCode);

                sqlText += "  AND SLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

                // ���_�R�[�h
                if (stockdaytotalExtractWork.SectionCd != null && stockdaytotalExtractWork.SectionCd.Length > 0)
                {
                    string[] sections = stockdaytotalExtractWork.SectionCd;

                    for (int i = 0; i < sections.Length; i++)
                    {
                        sections[i] = "'" + sections[i] + "'";
                    }

                    string inText = string.Join(", ", sections);

                    sqlText += "  AND SLIP.SECTIONCODERF IN (" + inText + ")" + Environment.NewLine;
                }

                // �d�����t(�J�n)
                if (stockdaytotalExtractWork.StockDateSt != 0)
                {
                    sqlText += "  AND SLIP.STOCKDATERF >= @FINDSTOCKDATEST" + Environment.NewLine;
                    SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                    paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockdaytotalExtractWork.StockDateSt);
                }

                // �d�����t(�I��)
                if (stockdaytotalExtractWork.StockDateEd != 0)
                {
                    sqlText += "  AND SLIP.STOCKDATERF <= @FINDSTOCKDATEED" + Environment.NewLine;
                    SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                    paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockdaytotalExtractWork.StockDateEd);
                }

                // �d���S���҃R�[�h(�J�n)
                if (!string.IsNullOrEmpty(stockdaytotalExtractWork.StockAgentCodeSt) && stockdaytotalExtractWork.StockAgentCodeSt == stockdaytotalExtractWork.StockAgentCodeEd)
                {
                    // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                    sqlText += "  AND SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                    SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                    paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeSt + "%");
                }
                else
                {
                    // �d���S���҃R�[�h(�J�n)
                    if (!string.IsNullOrEmpty(stockdaytotalExtractWork.StockAgentCodeSt))
                    {
                        // �J�n�ƏI���������ꍇ�͌����v�̞B�������Ƃ���
                        sqlText += "  AND SLIP.STOCKAGENTCODERF >= @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                        SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                        paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeSt);
                    }

                    // �d���S���҃R�[�h(�I��)
                    if (stockdaytotalExtractWork.StockAgentCodeEd != "")
                    {
                        if (string.IsNullOrEmpty(stockdaytotalExtractWork.StockAgentCodeSt))
                        {
                            sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF IS NULL)" + Environment.NewLine;

                            SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                            paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd);

                            SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                            paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd + "%");
                        }
                        else
                        {
                            sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2)" + Environment.NewLine;

                            SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                            paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd);

                            SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                            paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockdaytotalExtractWork.StockAgentCodeEd + "%");
                        }
                    }
                }

                sqlText += "GROUP BY" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;

                if (readMode == 1)
                {
                    // �S���ҕʁE�d����ʂ̏ꍇ�ɂ̂ݎd��������O���[�v�����ɓ����
                    sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SLIP.SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += " ,SLIP.SUPPLIERNM2RF" + Environment.NewLine;
                }
                
                sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
                #endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(sqlText);
#endif

                sqlCommand.CommandText = sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockDayTotalDataWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
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

            stockdaytotaldataWorkList = al;

            return status;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockDayTotalDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockDayTotalDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        private StockDayTotalDataWork CopyToStockDayTotalDataWorkFromReader(ref SqlDataReader myReader)
        {
            StockDayTotalDataWork wkStockDayTotalDataWork = new StockDayTotalDataWork();

            #region �N���X�֊i�[
            wkStockDayTotalDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));      // ��ƃR�[�h
            wkStockDayTotalDataWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));         // ���_�R�[�h
            wkStockDayTotalDataWork.StockSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));      // ���_�K�C�h����
            wkStockDayTotalDataWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));  // �d�����t
            wkStockDayTotalDataWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));      // �d���S���҃R�[�h
            wkStockDayTotalDataWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));      // �d���S���Җ�
            wkStockDayTotalDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCD"));               // �d����R�[�h
            wkStockDayTotalDataWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1"));             // �d���於�̂P
            wkStockDayTotalDataWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2"));            // �d���於�̂Q
            wkStockDayTotalDataWork.StockTtlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICERF"));         // �d���z(���v)
            wkStockDayTotalDataWork.RetGoodsTtlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETGOODSTTLPRICERF"));   // �ԕi�z(���v) ���}�C�i�X�l
            wkStockDayTotalDataWork.DiscountTtlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTTTLPRICERF"));   // �l���z(���v) ���}�C�i�X�l
            wkStockDayTotalDataWork.PureStockTtlPrice = wkStockDayTotalDataWork.StockTtlPrice +                                            // ���d���z(���v: �d���z�{�ԕi�z�{�l���z)
                                                        wkStockDayTotalDataWork.RetGoodsTtlPrice +
                                                        wkStockDayTotalDataWork.DiscountTtlPrice;
            #endregion

            return wkStockDayTotalDataWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockDayTotalDataWork[] StockDayTotalDataWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is StockDayTotalDataWork)
                    {
                        StockDayTotalDataWork wkStockDayTotalDataWork = paraobj as StockDayTotalDataWork;
                        if (wkStockDayTotalDataWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockDayTotalDataWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockDayTotalDataWorkArray = (StockDayTotalDataWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockDayTotalDataWork[]));
                        }
                        catch (Exception) { }
                        if (StockDayTotalDataWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockDayTotalDataWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockDayTotalDataWork wkStockDayTotalDataWork = (StockDayTotalDataWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockDayTotalDataWork));
                                if (wkStockDayTotalDataWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockDayTotalDataWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
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
