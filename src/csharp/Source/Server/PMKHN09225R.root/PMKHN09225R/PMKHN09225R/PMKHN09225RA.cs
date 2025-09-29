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
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�����ݒ�}�X�^  �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�����ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.19</br>
    /// <br></br>
    /// <br>Update Note: BL�R�[�h�X�V�敪�̒ǉ�(MANTIS[0014774])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/12/11</br>
    /// </remarks>
    [Serializable]
    public class PriceChgProcStDB : RemoteDB, IRemoteDB, IPriceChgProcStDB, IGetSyncdataList // MarshalByRefObject , ITaxRateSetDB
    {
        /// <summary>
        /// ���i�����ݒ�}�X�^  �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.19</br>
        /// </remarks>
        public PriceChgProcStDB()
            :
        base("PMKHN09227D", "Broadleaf.Application.Remoting.ParamData.PriceChgProcStWork", "PRICECHGPROCSTRF")
        {
            //			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST�̌�����߂��܂�
        /// </summary>
        /// <param name="retCnt">�Y���f�[�^����</param>
        /// <param name="parabyte">�����p�����[�^(readMode=0:PriceChgProcStWork�N���X�F��ƃR�[�h)</param>		
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int SearchCnt(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            //			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status = SearchCntProc(out retCnt, parabyte, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchCnt Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST�̌�����߂��܂�
        /// </summary>
        /// <param name="retCnt">�Y���f�[�^����</param>
        /// <param name="parabyte">�����p�����[�^(readMode=0:PriceChgProcStWork�N���X�F��ƃR�[�h)</param>		
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            PriceChgProcStWork PriceChgProcStWork = null;

            retCnt = 0;

            ArrayList al = new ArrayList();

            try
            {
                // XML�̓ǂݍ���
                PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                string sqlTxt = string.Empty; // 2008.05.21 add

                SqlCommand sqlCommand;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    //�_���폜�敪�ݒ�
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    //�_���폜�敪�ݒ�
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlTxt += "SELECT COUNT" + Environment.NewLine;
                    sqlTxt += "    (*)" + Environment.NewLine;
                    sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                //�f�[�^���[�h
                retCnt = (int)sqlCommand.ExecuteScalar();
                if (retCnt > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchCntProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            sqlConnection.Close();

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status = SearchProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="PriceChgProcStWork">���i�����ݒ�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int Search(ref object PriceChgProcStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = SearchProc(ref PriceChgProcStWork, out retTotalCnt, out nextData, readMode, logicalMode, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">��������</param>		
        /// <returns>STATUS</returns>
        public int SearchSpecification(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status = SearchProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, readCnt);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchSpecification Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>		
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <returns>STATUS</returns>
        private int SearchProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();
            PriceChgProcStWork = null;

            retbyte = null;

            //��������0�ŏ�����
            retTotalCnt = 0;

            //�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
            int _readCnt = readCnt;
            if (_readCnt > 0) _readCnt += 1;
            //�����R�[�h�����ŏ�����
            nextData = false;

            ArrayList al = new ArrayList();

            try
            {
                // XML�̓ǂݍ���
                PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                //�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾

                string sqlTxt = string.Empty; // 2008.05.21 add

                if (readCnt > 0)//&&(PriceChgProcStWork.TaxRateCode == 0))//||(PriceChgProcStWork.TaxRateSetCode == "")))
                {
                    SqlCommand sqlCommandCount;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        // 2008.05.21 upd start ----------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                        //�_���폜�敪�ݒ�
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        // 2008.05.21 upd start ----------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                        //�_���폜�敪�ݒ�
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        // 2008.05.21 upd start ----------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT" + Environment.NewLine;
                        sqlTxt += "    (*)" + Environment.NewLine;
                        sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.21 upd end -------------------------------------------<<
                    }
                    SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                }

                //		SqlCommand sqlCommand;

                sqlTxt = string.Empty;   // 2008.05.21 add

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    //�����w�薳���̏ꍇ

                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;

                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt += "SELECT TOP" + Environment.NewLine;
                    sqlTxt += _readCnt.ToString() + Environment.NewLine;
                    sqlTxt += "     CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;

                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;

                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
                {
                    //�߂�l�J�E���^�J�E���g
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                        if (readCnt < retCnt)
                        {
                            nextData = true;
                            break;
                        }
                    }
                    PriceChgProcStWork wkPriceChgProcStWork = new PriceChgProcStWork();

                    wkPriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkPriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkPriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkPriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkPriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkPriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkPriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkPriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                    wkPriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                    wkPriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                    wkPriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    wkPriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                    wkPriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                    // 2009/12/11 Add >>>
                    wkPriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                    // 2009/12/11 Add <<<


                    al.Add(wkPriceChgProcStWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // XML�֕ϊ����A������̃o�C�i����
            PriceChgProcStWork[] PriceChgProcStWorks = (PriceChgProcStWork[])al.ToArray(typeof(PriceChgProcStWork));
            retbyte = XmlByteSerializer.Serialize(PriceChgProcStWorks);

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="objPriceChgProcStWork">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>		
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <returns>STATUS</returns>
        private int SearchProc(ref object objPriceChgProcStWork, out int retTotalCnt, out bool nextData, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();
            PriceChgProcStWork PriceChgProcStWork = null;

            //��������0�ŏ�����
            retTotalCnt = 0;

            //�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
            int _readCnt = readCnt;
            if (_readCnt > 0) _readCnt += 1;
            //�����R�[�h�����ŏ�����
            nextData = false;

            ArrayList al = new ArrayList();

            try
            {
                ArrayList PriceChgProcStWorkList = objPriceChgProcStWork as ArrayList;
                if (PriceChgProcStWorkList != null)
                {
                    // XML�̓ǂݍ���
                    PriceChgProcStWork = PriceChgProcStWorkList[0] as PriceChgProcStWork;

                    //�R�l�N�V��������
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return status;

                    sqlConnection.Open();

                    string sqlTxt = string.Empty;

                    //�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾

                    if (readCnt > 0)
                    {
                        SqlCommand sqlCommandCount;
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                            //�_���폜�敪�ݒ�
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);

                            //�_���폜�敪�ݒ�
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                            else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                        }
                        else
                        {
                            sqlTxt += "SELECT COUNT" + Environment.NewLine;
                            sqlTxt += "    (*)" + Environment.NewLine;
                            sqlTxt += "    FROM PRICECHGPROCSTRF" + Environment.NewLine;
                            sqlTxt += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                            sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        }
                        SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                        retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                    }

                    //		SqlCommand sqlCommand;

                    sqlTxt = string.Empty;  // 2008.05.21 add

                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        // 2008.05.21 upd start ------------------------------------>>
                        //sqlCommand = new SqlCommand("SELECT * FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY TAXRATECODERF", sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add >>>
                        sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add <<<
                        sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add >>>
                        sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add <<<
                        sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "        AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add >>>
                        sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                        // 2009/12/11 Add <<<
                        sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY TAXRATECODERF" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    int retCnt = 0;
                    while (myReader.Read())
                    {
                        //�߂�l�J�E���^�J�E���g
                        retCnt += 1;
                        if (readCnt > 0)
                        {
                            //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                            if (readCnt < retCnt)
                            {
                                nextData = true;
                                break;
                            }
                        }
                        PriceChgProcStWork wkPriceChgProcStWork = new PriceChgProcStWork();

                        wkPriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkPriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkPriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkPriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkPriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkPriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkPriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkPriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkPriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                        wkPriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                        wkPriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                        wkPriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                        wkPriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                        wkPriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                        // 2009/12/11 Add >>>
                        wkPriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                        // 2009/12/11 Add <<<

                        al.Add(wkPriceChgProcStWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objPriceChgProcStWork = al;

            return status;
        }


        #region �C���^�[�t�F�[�X�Ō��J���Ȃ����\�b�h
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="PriceChgProcStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        public int Search(out ArrayList retList, PriceChgProcStWork PriceChgProcStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchProc(out retList, PriceChgProcStWork, readMode, logicalMode, ref sqlConnection);
        }
        private int SearchProc(out ArrayList retList, PriceChgProcStWork PriceChgProcStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            retList = null;

            try
            {
                //		SqlCommand sqlCommand;

                string sqlTxt = string.Empty; // 2008.05.21 add

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    PriceChgProcStWork wkPriceChgProcStWork = new PriceChgProcStWork();

                    wkPriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkPriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkPriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkPriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkPriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkPriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkPriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkPriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                    wkPriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                    wkPriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                    wkPriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    wkPriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                    wkPriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                    // 2009/12/11 Add >>>
                    wkPriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                    // 2009/12/11 Add <<<

                    al.Add(wkPriceChgProcStWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            retList = al;

            return status;
        }

        /// <summary>
        /// ���i�����ݒ��ǂݍ��݂܂��B
        /// </summary>
        /// <param name="PriceChgProcStWork">���i�����ݒ�}�X�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        public int Read(ref PriceChgProcStWork PriceChgProcStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref PriceChgProcStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        private int ReadProc(ref PriceChgProcStWork PriceChgProcStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string queryString = string.Empty;

                queryString += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                queryString += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                queryString += "    ,ENTERPRISECODERF" + Environment.NewLine;
                queryString += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                queryString += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                queryString += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                queryString += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                queryString += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                queryString += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                queryString += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                queryString += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                queryString += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                queryString += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                queryString += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                queryString += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                queryString += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                queryString += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                if (sqlTransaction == null)
                    sqlCommand = new SqlCommand(queryString, sqlConnection);
                else
                    sqlCommand = new SqlCommand(queryString, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    PriceChgProcStWork = CopyToPriceChgProcStWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Read(ref PriceChgProcStWork,int,ref SqlConnection,ref SqlTransaction) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���� ����</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
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

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode);
        }

        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();

            try
            {
                // XML�̓ǂݍ���
                PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                //Select�R�}���h�̐���	
                // 2008.05.21 upd start ------------------------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end --------------------------------------------<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    PriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    PriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    PriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    PriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    PriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    PriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    PriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    PriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    PriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
                    PriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
                    PriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
                    PriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    PriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
                    PriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
                    // 2009/12/11 Add >>>
                    PriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
                    // 2009/12/11 Add <<<
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Read Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // XML�֕ϊ����A������̃o�C�i����
            parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);

            return status;
        }

        /// <summary>
        /// ���i�����ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Write(ref byte[] parabyte)
        {
            return this.WriteProc(ref parabyte);
        }

        private int WriteProc(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XML�̓ǂݍ���
                PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                //Select�R�}���h�̐���
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != PriceChgProcStWork.UpdateDateTime)
                    {
                        //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        if (PriceChgProcStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }

                    // 2008.05.21 upd start ------------------------------------------->>
                    //sqlCommand.CommandText = "UPDATE PRICECHGPROCSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , TAXRATECODERF=@TAXRATECODE , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM , TAXRATENAMERF=@TAXRATENAME , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD , TAXRATESTARTDATERF=@TAXRATESTARTDATE , TAXRATEENDDATERF=@TAXRATEENDDATE , "
                    //    +"TAXRATERF=@TAXRATE , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2 , TAXRATEENDDATE2RF=@TAXRATEENDDATE2 , TAXRATE2RF=@TAXRATE2 , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3 , TAXRATEENDDATE3RF=@TAXRATEENDDATE3 , TAXRATE3RF=@TAXRATE3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "UPDATE PRICECHGPROCSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , NAMEUPDDIVRF=@NAMEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PARTSLAYERUPDDIVRF=@PARTSLAYERUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEUPDDIVRF=@PRICEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEMNGCNTRF=@PRICEMNGCNT" + Environment.NewLine;
                    sqlTxt += " , PRICECHGPROCDIVRF=@PRICECHGPROCDIV" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += " , BLGOODSCDUPDDIVRF=@BLGOODSCDUPDDIV" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end ---------------------------------------------<<

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)PriceChgProcStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (PriceChgProcStWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }

                    //�V�K�쐬����SQL���𐶐�
                    // 2008.05.21 upd start ------------------------------------------->>
                    //sqlCommand.CommandText = "INSERT INTO PRICECHGPROCSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, "
                    //    +"@ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @CONSTAXLAYMETHOD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)";
                    sqlTxt = string.Empty;

                    sqlTxt += "INSERT INTO PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " )" + Environment.NewLine;
                    sqlTxt += " VALUES" + Environment.NewLine;
                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "    ,@NAMEUPDDIV" + Environment.NewLine;
                    sqlTxt += "    ,@PARTSLAYERUPDDIV" + Environment.NewLine;
                    sqlTxt += "    ,@PRICEUPDDIV" + Environment.NewLine;
                    sqlTxt += "    ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlTxt += "    ,@PRICEMNGCNT" + Environment.NewLine;
                    sqlTxt += "    ,@PRICECHGPROCDIV" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += "    ,@BLGOODSCDUPDDIV" + Environment.NewLine;
                    // 2009/12/11 Add <<<
                    sqlTxt += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end ---------------------------------------------<<

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)PriceChgProcStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                if (!myReader.IsClosed) myReader.Close();

                #region �l�Z�b�g
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                SqlParameter paraNameUpdDiv = sqlCommand.Parameters.Add("@NAMEUPDDIV", SqlDbType.Int);
                SqlParameter paraPartsLayerUpdDiv = sqlCommand.Parameters.Add("@PARTSLAYERUPDDIV", SqlDbType.Int);
                SqlParameter paraPriceUpdDiv = sqlCommand.Parameters.Add("@PRICEUPDDIV", SqlDbType.Int);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraPriceMngCnt = sqlCommand.Parameters.Add("@PRICEMNGCNT", SqlDbType.Int);
                SqlParameter paraPriceChgProcDiv = sqlCommand.Parameters.Add("@PRICECHGPROCDIV", SqlDbType.Int);
                // 2009/12/11 Add >>>
                SqlParameter paraBLGoodsCdUpdDiv = sqlCommand.Parameters.Add("@BLGOODSCDUPDDIV", SqlDbType.Int);
                // 2009/12/11 Add <<<

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(PriceChgProcStWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(PriceChgProcStWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(PriceChgProcStWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.LogicalDeleteCode);
                paraNameUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.NameUpdDiv);
                paraPartsLayerUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PartsLayerUpdDiv);
                paraPriceUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PriceUpdDiv);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.OpenPriceDiv);
                paraPriceMngCnt.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PriceMngCnt);
                paraPriceChgProcDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.PriceChgProcDiv);
                // 2009/12/11 Add >>>
                paraBLGoodsCdUpdDiv.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.BLGoodsCdUpdDiv);
                // 2009/12/11 Add <<<
                #endregion

                sqlCommand.ExecuteNonQuery();

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Write Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�����ݒ����_���폜���܂�
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int LogicalDelete(ref byte[] parabyte)
        {
            //			return LogicalDeleteProc(ref parabyte,0);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteProc(ref parabyte, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.LogicalDelete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �_���폜���i�����ݒ���𕜊����܂�
        /// </summary>
        /// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref byte[] parabyte)
        {
            //			return LogicalDeleteProc(ref parabyte,1);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteProc(ref parabyte, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.RevivalLogicalDelete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���i�����ݒ���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="parabyte">PriceChgProcStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteProc(ref byte[] parabyte, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XML�̓ǂݍ���
                PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();
                // 2008.05.21 upd start --------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, TAXRATECODERF FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end -----------------------------------------<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != PriceChgProcStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    //���݂̘_���폜�敪���擾
                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 2008.05.21 upd start -------------------------------------------------------->>
                    //sqlCommand.CommandText = "UPDATE PRICECHGPROCSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "UPDATE PRICECHGPROCSTRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , NAMEUPDDIVRF=@NAMEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PARTSLAYERUPDDIVRF=@PARTSLAYERUPDDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEUPDDIVRF=@PRICEUPDDIV" + Environment.NewLine;
                    sqlTxt += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                    sqlTxt += " , PRICEMNGCNTRF=@PRICEMNGCNT" + Environment.NewLine;
                    sqlTxt += " , PRICECHGPROCDIVRF=@PRICECHGPROCDIV" + Environment.NewLine;
                    // 2009/12/11 Add >>>
                    sqlTxt += " , BLGOODSCDUPDDIVRF=@BLGOODSCDUPDDIV" + Environment.NewLine;
                    // 2009/12/11 Add <<<

                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;

                    // 2008.05.21 upd end ----------------------------------------------------------<<

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)PriceChgProcStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();

                //�_���폜���[�h�̏ꍇ
                if (procMode == 0)
                {
                    if (logicalDelCd == 3)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    else if (logicalDelCd == 0) PriceChgProcStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                    else PriceChgProcStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                }
                else
                {
                    if (logicalDelCd == 1) PriceChgProcStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                    else
                    {
                        if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                        else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                }

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(PriceChgProcStWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(PriceChgProcStWork.LogicalDeleteCode);

                sqlCommand.ExecuteNonQuery();

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�����ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���i�����ݒ�I�u�W�F�N�g</param>
        /// <returns></returns>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }
        private int DeleteProc(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XML�̓ǂݍ���
                PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // 2008.05.21 upd start ----------------------------------->>
                //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, TAXRATECODERF FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end -------------------------------------<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UpdateDateTimeRF"));//�X�V����
                    if (_updateDateTime != PriceChgProcStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }

                    // 2008.05.21 upd start --------------------------------->>
                    //sqlCommand.CommandText = "DELETE FROM PRICECHGPROCSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                    sqlTxt = string.Empty;

                    sqlTxt += "DELETE" + Environment.NewLine;
                    sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    // 2008.05.21 upd end -----------------------------------<<

                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(PriceChgProcStWork.EnterpriseCode);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PriceChgProcStDB.Delete Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }


        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.23</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.21 upd start ------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM PRICECHGPROCSTRF ", sqlConnection);
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PARTSLAYERUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEUPDDIVRF" + Environment.NewLine;
                sqlTxt += "    ,OPENPRICEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,PRICEMNGCNTRF" + Environment.NewLine;
                sqlTxt += "    ,PRICECHGPROCDIVRF" + Environment.NewLine;
                // 2009/12/11 Add >>>
                sqlTxt += "    ,BLGOODSCDUPDDIVRF" + Environment.NewLine;
                // 2009/12/11 Add <<<
                sqlTxt += " FROM PRICECHGPROCSTRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.21 upd end --------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToPriceChgProcStWorkFromReader(ref myReader));
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.23</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }

        /// <summary>
        /// SqlDataReader -> PriceChgProcStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PriceChgProcStWork</returns>
        private PriceChgProcStWork CopyToPriceChgProcStWorkFromReader(ref SqlDataReader myReader)
        {
            PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();
            PriceChgProcStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            PriceChgProcStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            PriceChgProcStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            PriceChgProcStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            PriceChgProcStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            PriceChgProcStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            PriceChgProcStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            PriceChgProcStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            PriceChgProcStWork.NameUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NAMEUPDDIVRF"));
            PriceChgProcStWork.PartsLayerUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSLAYERUPDDIVRF"));
            PriceChgProcStWork.PriceUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDDIVRF"));
            PriceChgProcStWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            PriceChgProcStWork.PriceMngCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEMNGCNTRF"));
            PriceChgProcStWork.PriceChgProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECHGPROCDIVRF"));
            // 2009/12/11 Add >>>
            PriceChgProcStWork.BLGoodsCdUpdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDUPDDIVRF"));
            // 2009/12/11 Add <<<
            return PriceChgProcStWork;
        }
        #endregion

    }

}

