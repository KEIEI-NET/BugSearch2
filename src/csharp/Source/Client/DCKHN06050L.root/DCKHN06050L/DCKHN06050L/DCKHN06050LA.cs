using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// ����S�̐ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����S�̐ݒ�}�X�^LC�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.01.23</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.18 �R�c ���F</br>
    /// <br>           : ������������֘A��ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.26 �R�c ���F</br>
    /// <br>           : ���o�׋敪2�E�l�����̂�ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.09 �D�c �E�l</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// </remarks>
    public class SalesTtlStLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// ����S�̐ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        public SalesTtlStLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC���LIST��߂��܂�
        /// </summary>
        /// <param name="salesTtlStWorkList">��������</param>
        /// <param name="paraSalesTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC���LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int Search(out List<SalesTtlStWork> salesTtlStWorkList, SearchSalesTtlStParaWork paraSalesTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesTtlStWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchSalesTtlStProcProc(out salesTtlStWorkList, paraSalesTtlStWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SalesTtlStLcDB.Search", 0);
                salesTtlStWorkList = new List<SalesTtlStWork>();
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
        /// �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesTtlStWorkList">��������</param>
        /// <param name="salesTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int SearchSalesTtlStProc(out List<SalesTtlStWork> salesTtlStWorkList, SearchSalesTtlStParaWork salesTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            status = SearchSalesTtlStProcProc(out salesTtlStWorkList, salesTtlStWork, readMode, logicalMode, ref sqlConnection);

            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesTtlStWorkList">��������</param>
        /// <param name="salesTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private int SearchSalesTtlStProcProc(out List<SalesTtlStWork> salesTtlStWorkList, SearchSalesTtlStParaWork salesTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<SalesTtlStWork> listdata = new List<SalesTtlStWork>();
            try
            {
                // 2008.06.09 upd start --------------------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SALESTTLSTRF  ", sqlConnection);
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,SHIPMSLIPUNPRCPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHECKLOWERRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHECKBESTRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHECKUPPERRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKLOWSIGNRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKBESTSIGNRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKUPRSIGNRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKMAXSIGNRF" + Environment.NewLine;
                sqlText += "    ,SALESAGENTCHNGDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRAGENTDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,BRSLIPNOTE2DISPDIVRF" + Environment.NewLine;
                sqlText += "    ,DTLNOTEDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,UNPRCNONSETTINGDIVRF" + Environment.NewLine;
                sqlText += "    ,ESTMATEADDUPREMDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRRADDUPREMDIVRF" + Environment.NewLine;
                sqlText += "    ,SHIPMADDUPREMDIVRF" + Environment.NewLine;
                sqlText += "    ,RETGOODSSTOCKETYDIVRF" + Environment.NewLine;
                sqlText += "    ,LISTPRICESELECTDIVRF" + Environment.NewLine;
                sqlText += "    ,MAKERINPDIVRF" + Environment.NewLine;
                sqlText += "    ,BLGOODSCDINPDIVRF" + Environment.NewLine;
                sqlText += "    ,SUPPLIERINPDIVRF" + Environment.NewLine;
                sqlText += "    ,SUPPLIERSLIPDELDIVRF" + Environment.NewLine;
                sqlText += "    ,CUSTGUIDEDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVDATERF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVCOSTRF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVUNPRCRF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVLPRICERF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOKINDCODERF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOKINDNAMERF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOKINDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DISCOUNTNAMERF" + Environment.NewLine;
                sqlText += "    ,INPAGENTDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,CUSTORDERNODISPDIVRF" + Environment.NewLine;
                sqlText += "    ,CARMNGNODISPDIVRF" + Environment.NewLine;
                sqlText += "    ,BRSLIPNOTE3DISPDIVRF" + Environment.NewLine;
                sqlText += "    ,SLIPDATECLRDIVCDRF" + Environment.NewLine;
                sqlText += "    ,AUTOENTRYGOODSDIVCDRF" + Environment.NewLine;
                sqlText += "    ,COSTCHECKDIVCDRF" + Environment.NewLine;
                sqlText += "    ,JOININITDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOSITCDRF" + Environment.NewLine;
                sqlText += "    ,SUBSTCONDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,SLIPCREATEPROCESSRF" + Environment.NewLine;
                sqlText += "    ,WAREHOUSECHKDIVRF" + Environment.NewLine;
                sqlText += "    ,PARTSSEARCHDIVCDRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITDSPCDRF" + Environment.NewLine;
                sqlText += "    ,PARTSSEARCHPRIDIVCDRF" + Environment.NewLine;
                sqlText += "    ,SALESSTOCKDIVRF" + Environment.NewLine;
                sqlText += "    ,PRTBLGOODSCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,SECTDSPDIVCDRF" + Environment.NewLine;
                sqlText += "    ,GOODSNMREDISPDIVCDRF" + Environment.NewLine;
                sqlText += "    ,COSTDSPDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DEPOSLIPDATECLRDIVRF" + Environment.NewLine;
                sqlText += "    ,DEPOSLIPDATEAMBITRF" + Environment.NewLine;
                sqlText += " FROM SALESTTLSTRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                // 2008.06.09 upd end -----------------------------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, salesTtlStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToSalesTtlStWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SalesTtlStLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            salesTtlStWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC��߂��܂�
        /// </summary>
        /// <param name="salesTtlStWork">salesTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int Read(ref SalesTtlStWork salesTtlStWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref salesTtlStWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SalesTtlStLcDB.Read", 0);
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

        /// <summary>
        /// �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesTtlStWork">salesTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int ReadProc(ref SalesTtlStWork salesTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref salesTtlStWork, readMode, ref sqlConnection);
            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesTtlStWork">salesTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private int ReadProcProc(ref SalesTtlStWork salesTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                // 2008.06.09 upd start ---------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SALESTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection))
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,SHIPMSLIPUNPRCPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHECKLOWERRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHECKBESTRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHECKUPPERRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKLOWSIGNRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKBESTSIGNRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKUPRSIGNRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITCHKMAXSIGNRF" + Environment.NewLine;
                sqlText += "    ,SALESAGENTCHNGDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRAGENTDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,BRSLIPNOTE2DISPDIVRF" + Environment.NewLine;
                sqlText += "    ,DTLNOTEDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,UNPRCNONSETTINGDIVRF" + Environment.NewLine;
                sqlText += "    ,ESTMATEADDUPREMDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRRADDUPREMDIVRF" + Environment.NewLine;
                sqlText += "    ,SHIPMADDUPREMDIVRF" + Environment.NewLine;
                sqlText += "    ,RETGOODSSTOCKETYDIVRF" + Environment.NewLine;
                sqlText += "    ,LISTPRICESELECTDIVRF" + Environment.NewLine;
                sqlText += "    ,MAKERINPDIVRF" + Environment.NewLine;
                sqlText += "    ,BLGOODSCDINPDIVRF" + Environment.NewLine;
                sqlText += "    ,SUPPLIERINPDIVRF" + Environment.NewLine;
                sqlText += "    ,SUPPLIERSLIPDELDIVRF" + Environment.NewLine;
                sqlText += "    ,CUSTGUIDEDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVDATERF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVCOSTRF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVUNPRCRF" + Environment.NewLine;
                sqlText += "    ,SLIPCHNGDIVLPRICERF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOKINDCODERF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOKINDNAMERF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOKINDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DISCOUNTNAMERF" + Environment.NewLine;
                sqlText += "    ,INPAGENTDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,CUSTORDERNODISPDIVRF" + Environment.NewLine;
                sqlText += "    ,CARMNGNODISPDIVRF" + Environment.NewLine;
                sqlText += "    ,BRSLIPNOTE3DISPDIVRF" + Environment.NewLine;
                sqlText += "    ,SLIPDATECLRDIVCDRF" + Environment.NewLine;
                sqlText += "    ,AUTOENTRYGOODSDIVCDRF" + Environment.NewLine;
                sqlText += "    ,COSTCHECKDIVCDRF" + Environment.NewLine;
                sqlText += "    ,JOININITDISPDIVRF" + Environment.NewLine;
                sqlText += "    ,AUTODEPOSITCDRF" + Environment.NewLine;
                sqlText += "    ,SUBSTCONDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,SLIPCREATEPROCESSRF" + Environment.NewLine;
                sqlText += "    ,WAREHOUSECHKDIVRF" + Environment.NewLine;
                sqlText += "    ,PARTSSEARCHDIVCDRF" + Environment.NewLine;
                sqlText += "    ,GRSPROFITDSPCDRF" + Environment.NewLine;
                sqlText += "    ,PARTSSEARCHPRIDIVCDRF" + Environment.NewLine;
                sqlText += "    ,SALESSTOCKDIVRF" + Environment.NewLine;
                sqlText += "    ,PRTBLGOODSCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,SECTDSPDIVCDRF" + Environment.NewLine;
                sqlText += "    ,GOODSNMREDISPDIVCDRF" + Environment.NewLine;
                sqlText += "    ,COSTDSPDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DEPOSLIPDATECLRDIVRF" + Environment.NewLine;
                sqlText += "    ,DEPOSLIPDATEAMBITRF" + Environment.NewLine;
                sqlText += " FROM SALESTTLSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                // 2008.06.09 upd end ------------------------------------------<<
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.06.09 add   

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);              // 2008.06.09 add

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        salesTtlStWork = CopyToSalesTtlStWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SalesTtlStLcDB.Read", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [WriteSyncLocalData]
        /// <summary>
        /// ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWork�I�u�W�F�N�g</param>
        /// <param name="paraSyncDataList">paraSyncDataList�I�u�W�F�N�g</param>
        /// <param name="readMode">readMode(���g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int WriteSyncLocalData(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList syncDataList = new ArrayList();
            try
            {
                if (syncServiceWork == null) return status;
                if (paraSyncDataList == null) return status;

                //�g�p����p�����[�^�̃L���X�g
                SalesTtlStWork salesTtlStWork = new SalesTtlStWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == salesTtlStWork.GetType())
                    {
                        break;
                    }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SalesTtlStLcDB.WriteSyncLocalData", 0);
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWork�I�u�W�F�N�g</param>
        /// <param name="paraSyncDataList">paraSyncDataList�I�u�W�F�N�g</param>
        /// <param name="readMode">readMode(���g�p)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private int WriteSyncLocalDataProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList syncDataList = new ArrayList();

            status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

            return status;
        }


        /// <summary>
        /// ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWork�I�u�W�F�N�g</param>
        /// <param name="paraSyncDataList">paraSyncDataList�I�u�W�F�N�g</param>
        /// <param name="readMode">readMode(���g�p)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlText = string.Empty; // 2008.06.09 add

            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.06.09 upd start ----------------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM SALESTTLSTRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM SALESTTLSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@DELSECTIONCODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        // 2008.06.09 upd end -------------------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        // 2008.06.09 add start ---------------------------------------->>
                        SqlParameter delSectionCode = sqlCommand.Parameters.Add("@DELSECTIONCODE", SqlDbType.NChar);
                        delSectionCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.SectionCode);
                        // 2008.06.09 add end ------------------------------------------<<

                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        SalesTtlStWork salesTtlStWork = paraSyncDataList[i] as SalesTtlStWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //�������[�h�̃V���N����
                            case 0:
                                //Select�R�}���h�̐���
                                // 2008.06.09 upd start ---------------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM SALESTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += "    ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,SHIPMSLIPUNPRCPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHECKLOWERRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHECKBESTRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHECKUPPERRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKLOWSIGNRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKBESTSIGNRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKUPRSIGNRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKMAXSIGNRF" + Environment.NewLine;
                                sqlText += "    ,SALESAGENTCHNGDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRAGENTDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,BRSLIPNOTE2DISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,DTLNOTEDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,UNPRCNONSETTINGDIVRF" + Environment.NewLine;
                                sqlText += "    ,ESTMATEADDUPREMDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRRADDUPREMDIVRF" + Environment.NewLine;
                                sqlText += "    ,SHIPMADDUPREMDIVRF" + Environment.NewLine;
                                sqlText += "    ,RETGOODSSTOCKETYDIVRF" + Environment.NewLine;
                                sqlText += "    ,LISTPRICESELECTDIVRF" + Environment.NewLine;
                                sqlText += "    ,MAKERINPDIVRF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSCDINPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SUPPLIERINPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SUPPLIERSLIPDELDIVRF" + Environment.NewLine;
                                sqlText += "    ,CUSTGUIDEDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVDATERF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVCOSTRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVUNPRCRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVLPRICERF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOKINDCODERF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOKINDNAMERF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOKINDDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,DISCOUNTNAMERF" + Environment.NewLine;
                                sqlText += "    ,INPAGENTDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,CUSTORDERNODISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,CARMNGNODISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,BRSLIPNOTE3DISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SLIPDATECLRDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,AUTOENTRYGOODSDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,COSTCHECKDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,JOININITDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOSITCDRF" + Environment.NewLine;
                                sqlText += "    ,SUBSTCONDDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCREATEPROCESSRF" + Environment.NewLine;
                                sqlText += "    ,WAREHOUSECHKDIVRF" + Environment.NewLine;
                                sqlText += "    ,PARTSSEARCHDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITDSPCDRF" + Environment.NewLine;
                                sqlText += "    ,PARTSSEARCHPRIDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,SALESSTOCKDIVRF" + Environment.NewLine;
                                sqlText += "    ,PRTBLGOODSCODEDIVRF" + Environment.NewLine;
                                sqlText += "    ,SECTDSPDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,GOODSNMREDISPDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,COSTDSPDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,DEPOSLIPDATECLRDIVRF" + Environment.NewLine;
                                sqlText += "    ,DEPOSLIPDATEAMBITRF" + Environment.NewLine;
                                sqlText += " FROM SALESTTLSTRF" + Environment.NewLine;
                                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.06.09 upd end ------------------------------------------<<

                                //Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.06.09 add

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode); // 2008.06.09 add

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Update�R�}���h�̐���
                                    // �� 2008.02.26 980081 a
                                    //// �� 2008.02.18 980081 c
                                    ////sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , ZEROPRTDIVRF=@ZEROPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , IOGOODSCNTDIVRF=@IOGOODSCNTDIV , SALESFORMALINRF=@SALESFORMALIN , STOCKDETAILCONFRF=@STOCKDETAILCONF , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                                    //sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , ZEROPRTDIVRF=@ZEROPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , IOGOODSCNTDIVRF=@IOGOODSCNTDIV , SALESFORMALINRF=@SALESFORMALIN , STOCKDETAILCONFRF=@STOCKDETAILCONF , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                                    //// �� 2008.02.18 980081 c
                                    // 2008.06.09 upd start ------------------------------------------------->>
                                    //sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , ZEROPRTDIVRF=@ZEROPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , IOGOODSCNTDIVRF=@IOGOODSCNTDIV , IOGOODSCNTDIV2RF=@IOGOODSCNTDIV2 , SALESFORMALINRF=@SALESFORMALIN , STOCKDETAILCONFRF=@STOCKDETAILCONF , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                                    sqlText = string.Empty;
                                    sqlText += "UPDATE SALESTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                    sqlText += " , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += " , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += " , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV" + Environment.NewLine;
                                    sqlText += " , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER" + Environment.NewLine;
                                    sqlText += " , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST" + Environment.NewLine;
                                    sqlText += " , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER" + Environment.NewLine;
                                    sqlText += " , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN" + Environment.NewLine;
                                    sqlText += " , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN" + Environment.NewLine;
                                    sqlText += " , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN" + Environment.NewLine;
                                    sqlText += " , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN" + Environment.NewLine;
                                    sqlText += " , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV" + Environment.NewLine;
                                    sqlText += " , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV" + Environment.NewLine;
                                    sqlText += " , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV" + Environment.NewLine;
                                    sqlText += " , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV" + Environment.NewLine;
                                    sqlText += " , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV" + Environment.NewLine;
                                    sqlText += " , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV" + Environment.NewLine;
                                    sqlText += " , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV" + Environment.NewLine;
                                    sqlText += " , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV" + Environment.NewLine;
                                    sqlText += " , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV" + Environment.NewLine;
                                    sqlText += " , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV" + Environment.NewLine;
                                    sqlText += " , MAKERINPDIVRF=@MAKERINPDIV" + Environment.NewLine;
                                    sqlText += " , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV" + Environment.NewLine;
                                    sqlText += " , SUPPLIERINPDIVRF=@SUPPLIERINPDIV" + Environment.NewLine;
                                    sqlText += " , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV" + Environment.NewLine;
                                    sqlText += " , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV" + Environment.NewLine;
                                    sqlText += " , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE" + Environment.NewLine;
                                    sqlText += " , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST" + Environment.NewLine;
                                    sqlText += " , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC" + Environment.NewLine;
                                    sqlText += " , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE" + Environment.NewLine;
                                    sqlText += " , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE" + Environment.NewLine;
                                    sqlText += " , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME" + Environment.NewLine;
                                    sqlText += " , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD" + Environment.NewLine;
                                    sqlText += " , DISCOUNTNAMERF=@DISCOUNTNAME" + Environment.NewLine;
                                    sqlText += " , INPAGENTDISPDIVRF=@INPAGENTDISPDIV" + Environment.NewLine;
                                    sqlText += " , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV" + Environment.NewLine;
                                    sqlText += " , CARMNGNODISPDIVRF=@CARMNGNODISPDIV" + Environment.NewLine;
                                    sqlText += " , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV" + Environment.NewLine;
                                    sqlText += " , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD" + Environment.NewLine;
                                    sqlText += " , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD" + Environment.NewLine;
                                    sqlText += " , COSTCHECKDIVCDRF=@COSTCHECKDIVCD" + Environment.NewLine;
                                    sqlText += " , JOININITDISPDIVRF=@JOININITDISPDIV" + Environment.NewLine;
                                    sqlText += " , AUTODEPOSITCDRF=@AUTODEPOSITCD" + Environment.NewLine;
                                    sqlText += " , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD" + Environment.NewLine;
                                    sqlText += " , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS" + Environment.NewLine;
                                    sqlText += " , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV" + Environment.NewLine;
                                    sqlText += " , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD" + Environment.NewLine;
                                    sqlText += " , GRSPROFITDSPCDRF=@GRSPROFITDSPCD" + Environment.NewLine;
                                    sqlText += " , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD" + Environment.NewLine;
                                    sqlText += " , SALESSTOCKDIVRF=@SALESSTOCKDIV" + Environment.NewLine;
                                    sqlText += " , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV" + Environment.NewLine;
                                    sqlText += " , SECTDSPDIVCDRF=@SECTDSPDIVCD" + Environment.NewLine;
                                    sqlText += " , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD" + Environment.NewLine;
                                    sqlText += " , COSTDSPDIVCDRF=@COSTDSPDIVCD" + Environment.NewLine;
                                    sqlText += " , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV" + Environment.NewLine;
                                    sqlText += " , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT" + Environment.NewLine;
                                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.06.09 upd end ---------------------------------------------------<<
                                    // �� 2008.02.26 980081 a
                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode); // 2008.06.09 add
                                    //�X�V�w�b�_����ݒ�
                                    //FileHeaderGuid��Select���ʂ���擾
                                    salesTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)salesTtlStWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insert�R�}���h�̐���
                                    // �� 2008.02.26 980081 c
                                    //// �� 2008.02.18 980081 c
                                    ////sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ZEROPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, IOGOODSCNTDIVRF, SALESFORMALINRF, STOCKDETAILCONFRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ZEROPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @IOGOODSCNTDIV, @SALESFORMALIN, @STOCKDETAILCONF, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE)";
                                    //sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ZEROPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, IOGOODSCNTDIVRF, SALESFORMALINRF, STOCKDETAILCONFRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ZEROPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @IOGOODSCNTDIV, @SALESFORMALIN, @STOCKDETAILCONF, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD)";
                                    //// �� 2008.02.18 980081 c
                                    // 2008.06.09 upd start ------------------------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ZEROPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, IOGOODSCNTDIVRF, IOGOODSCNTDIV2RF, SALESFORMALINRF, STOCKDETAILCONFRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ZEROPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @IOGOODSCNTDIV, @IOGOODSCNTDIV2, @SALESFORMALIN, @STOCKDETAILCONF, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME)";
                                    sqlText = string.Empty;
                                    sqlText += "INSERT INTO SALESTTLSTRF" + Environment.NewLine;
                                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                    sqlText += "    ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SHIPMSLIPUNPRCPRTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITCHECKLOWERRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITCHECKBESTRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITCHECKUPPERRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITCHKLOWSIGNRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITCHKBESTSIGNRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITCHKUPRSIGNRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITCHKMAXSIGNRF" + Environment.NewLine;
                                    sqlText += "    ,SALESAGENTCHNGDIVRF" + Environment.NewLine;
                                    sqlText += "    ,ACPODRAGENTDISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,BRSLIPNOTE2DISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,DTLNOTEDISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,UNPRCNONSETTINGDIVRF" + Environment.NewLine;
                                    sqlText += "    ,ESTMATEADDUPREMDIVRF" + Environment.NewLine;
                                    sqlText += "    ,ACPODRRADDUPREMDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SHIPMADDUPREMDIVRF" + Environment.NewLine;
                                    sqlText += "    ,RETGOODSSTOCKETYDIVRF" + Environment.NewLine;
                                    sqlText += "    ,LISTPRICESELECTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,MAKERINPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSCDINPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SUPPLIERINPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SUPPLIERSLIPDELDIVRF" + Environment.NewLine;
                                    sqlText += "    ,CUSTGUIDEDISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SLIPCHNGDIVDATERF" + Environment.NewLine;
                                    sqlText += "    ,SLIPCHNGDIVCOSTRF" + Environment.NewLine;
                                    sqlText += "    ,SLIPCHNGDIVUNPRCRF" + Environment.NewLine;
                                    sqlText += "    ,SLIPCHNGDIVLPRICERF" + Environment.NewLine;
                                    sqlText += "    ,AUTODEPOKINDCODERF" + Environment.NewLine;
                                    sqlText += "    ,AUTODEPOKINDNAMERF" + Environment.NewLine;
                                    sqlText += "    ,AUTODEPOKINDDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,DISCOUNTNAMERF" + Environment.NewLine;
                                    sqlText += "    ,INPAGENTDISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,CUSTORDERNODISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,CARMNGNODISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,BRSLIPNOTE3DISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SLIPDATECLRDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,AUTOENTRYGOODSDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,COSTCHECKDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,JOININITDISPDIVRF" + Environment.NewLine;
                                    sqlText += "    ,AUTODEPOSITCDRF" + Environment.NewLine;
                                    sqlText += "    ,SUBSTCONDDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,SLIPCREATEPROCESSRF" + Environment.NewLine;
                                    sqlText += "    ,WAREHOUSECHKDIVRF" + Environment.NewLine;
                                    sqlText += "    ,PARTSSEARCHDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,GRSPROFITDSPCDRF" + Environment.NewLine;
                                    sqlText += "    ,PARTSSEARCHPRIDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,SALESSTOCKDIVRF" + Environment.NewLine;
                                    sqlText += "    ,PRTBLGOODSCODEDIVRF" + Environment.NewLine;
                                    sqlText += "    ,SECTDSPDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,GOODSNMREDISPDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,COSTDSPDIVCDRF" + Environment.NewLine;
                                    sqlText += "    ,DEPOSLIPDATECLRDIVRF" + Environment.NewLine;
                                    sqlText += "    ,DEPOSLIPDATEAMBITRF" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlText += " VALUES" + Environment.NewLine;
                                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                                    sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                                    sqlText += "    ,@SALESSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += "    ,@SHIPMSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += "    ,@SHIPMSLIPUNPRCPRTDIV" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITCHECKLOWER" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITCHECKBEST" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITCHECKUPPER" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITCHKLOWSIGN" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITCHKBESTSIGN" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITCHKUPRSIGN" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITCHKMAXSIGN" + Environment.NewLine;
                                    sqlText += "    ,@SALESAGENTCHNGDIV" + Environment.NewLine;
                                    sqlText += "    ,@ACPODRAGENTDISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@BRSLIPNOTE2DISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@DTLNOTEDISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@UNPRCNONSETTINGDIV" + Environment.NewLine;
                                    sqlText += "    ,@ESTMATEADDUPREMDIV" + Environment.NewLine;
                                    sqlText += "    ,@ACPODRRADDUPREMDIV" + Environment.NewLine;
                                    sqlText += "    ,@SHIPMADDUPREMDIV" + Environment.NewLine;
                                    sqlText += "    ,@RETGOODSSTOCKETYDIV" + Environment.NewLine;
                                    sqlText += "    ,@LISTPRICESELECTDIV" + Environment.NewLine;
                                    sqlText += "    ,@MAKERINPDIV" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSCDINPDIV" + Environment.NewLine;
                                    sqlText += "    ,@SUPPLIERINPDIV" + Environment.NewLine;
                                    sqlText += "    ,@SUPPLIERSLIPDELDIV" + Environment.NewLine;
                                    sqlText += "    ,@CUSTGUIDEDISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@SLIPCHNGDIVDATE" + Environment.NewLine;
                                    sqlText += "    ,@SLIPCHNGDIVCOST" + Environment.NewLine;
                                    sqlText += "    ,@SLIPCHNGDIVUNPRC" + Environment.NewLine;
                                    sqlText += "    ,@SLIPCHNGDIVLPRICE" + Environment.NewLine;
                                    sqlText += "    ,@AUTODEPOKINDCODE" + Environment.NewLine;
                                    sqlText += "    ,@AUTODEPOKINDNAME" + Environment.NewLine;
                                    sqlText += "    ,@AUTODEPOKINDDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@DISCOUNTNAME" + Environment.NewLine;
                                    sqlText += "    ,@INPAGENTDISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@CUSTORDERNODISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@CARMNGNODISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@BRSLIPNOTE3DISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@SLIPDATECLRDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@AUTOENTRYGOODSDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@COSTCHECKDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@JOININITDISPDIV" + Environment.NewLine;
                                    sqlText += "    ,@AUTODEPOSITCD" + Environment.NewLine;
                                    sqlText += "    ,@SUBSTCONDDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@SLIPCREATEPROCESS" + Environment.NewLine;
                                    sqlText += "    ,@WAREHOUSECHKDIV" + Environment.NewLine;
                                    sqlText += "    ,@PARTSSEARCHDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@GRSPROFITDSPCD" + Environment.NewLine;
                                    sqlText += "    ,@PARTSSEARCHPRIDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@SALESSTOCKDIV" + Environment.NewLine;
                                    sqlText += "    ,@PRTBLGOODSCODEDIV" + Environment.NewLine;
                                    sqlText += "    ,@SECTDSPDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@GOODSNMREDISPDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@COSTDSPDIVCD" + Environment.NewLine;
                                    sqlText += "    ,@DEPOSLIPDATECLRDIV" + Environment.NewLine;
                                    sqlText += "    ,@DEPOSLIPDATEAMBIT" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.06.09 upd end ---------------------------------------------------<<
                                    // �� 2008.02.26 980081 c
                                    //�o�^�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)salesTtlStWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //�S���o�^�̃V���N����
                            case 1:
                                //Insert�R�}���h�̐���
                                // �� 2008.02.26 980081 c
                                //// �� 2008.02.18 980081 c
                                ////sqlCommand = new SqlCommand("INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ZEROPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, IOGOODSCNTDIVRF, SALESFORMALINRF, STOCKDETAILCONFRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ZEROPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @IOGOODSCNTDIV, @SALESFORMALIN, @STOCKDETAILCONF, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE)", sqlConnection, sqlTransaction);
                                //sqlCommand = new SqlCommand("INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ZEROPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, IOGOODSCNTDIVRF, SALESFORMALINRF, STOCKDETAILCONFRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ZEROPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @IOGOODSCNTDIV, @SALESFORMALIN, @STOCKDETAILCONF, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD)", sqlConnection, sqlTransaction);
                                //// �� 2008.02.18 980081 c
                                // 2008.06.09 upd start ------------------------------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ZEROPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, IOGOODSCNTDIVRF, IOGOODSCNTDIV2RF, SALESFORMALINRF, STOCKDETAILCONFRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ZEROPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @IOGOODSCNTDIV, @IOGOODSCNTDIV2, @SALESFORMALIN, @STOCKDETAILCONF, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME)", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO SALESTTLSTRF" + Environment.NewLine;
                                sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += "    ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,SHIPMSLIPUNPRCPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHECKLOWERRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHECKBESTRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHECKUPPERRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKLOWSIGNRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKBESTSIGNRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKUPRSIGNRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITCHKMAXSIGNRF" + Environment.NewLine;
                                sqlText += "    ,SALESAGENTCHNGDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRAGENTDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,BRSLIPNOTE2DISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,DTLNOTEDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,UNPRCNONSETTINGDIVRF" + Environment.NewLine;
                                sqlText += "    ,ESTMATEADDUPREMDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRRADDUPREMDIVRF" + Environment.NewLine;
                                sqlText += "    ,SHIPMADDUPREMDIVRF" + Environment.NewLine;
                                sqlText += "    ,RETGOODSSTOCKETYDIVRF" + Environment.NewLine;
                                sqlText += "    ,LISTPRICESELECTDIVRF" + Environment.NewLine;
                                sqlText += "    ,MAKERINPDIVRF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSCDINPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SUPPLIERINPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SUPPLIERSLIPDELDIVRF" + Environment.NewLine;
                                sqlText += "    ,CUSTGUIDEDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVDATERF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVCOSTRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVUNPRCRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCHNGDIVLPRICERF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOKINDCODERF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOKINDNAMERF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOKINDDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,DISCOUNTNAMERF" + Environment.NewLine;
                                sqlText += "    ,INPAGENTDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,CUSTORDERNODISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,CARMNGNODISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,BRSLIPNOTE3DISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,SLIPDATECLRDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,AUTOENTRYGOODSDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,COSTCHECKDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,JOININITDISPDIVRF" + Environment.NewLine;
                                sqlText += "    ,AUTODEPOSITCDRF" + Environment.NewLine;
                                sqlText += "    ,SUBSTCONDDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,SLIPCREATEPROCESSRF" + Environment.NewLine;
                                sqlText += "    ,WAREHOUSECHKDIVRF" + Environment.NewLine;
                                sqlText += "    ,PARTSSEARCHDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,GRSPROFITDSPCDRF" + Environment.NewLine;
                                sqlText += "    ,PARTSSEARCHPRIDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,SALESSTOCKDIVRF" + Environment.NewLine;
                                sqlText += "    ,PRTBLGOODSCODEDIVRF" + Environment.NewLine;
                                sqlText += "    ,SECTDSPDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,GOODSNMREDISPDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,COSTDSPDIVCDRF" + Environment.NewLine;
                                sqlText += "    ,DEPOSLIPDATECLRDIVRF" + Environment.NewLine;
                                sqlText += "    ,DEPOSLIPDATEAMBITRF" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlText += " VALUES" + Environment.NewLine;
                                sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                                sqlText += "    ,@SALESSLIPPRTDIV" + Environment.NewLine;
                                sqlText += "    ,@SHIPMSLIPPRTDIV" + Environment.NewLine;
                                sqlText += "    ,@SHIPMSLIPUNPRCPRTDIV" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITCHECKLOWER" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITCHECKBEST" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITCHECKUPPER" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITCHKLOWSIGN" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITCHKBESTSIGN" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITCHKUPRSIGN" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITCHKMAXSIGN" + Environment.NewLine;
                                sqlText += "    ,@SALESAGENTCHNGDIV" + Environment.NewLine;
                                sqlText += "    ,@ACPODRAGENTDISPDIV" + Environment.NewLine;
                                sqlText += "    ,@BRSLIPNOTE2DISPDIV" + Environment.NewLine;
                                sqlText += "    ,@DTLNOTEDISPDIV" + Environment.NewLine;
                                sqlText += "    ,@UNPRCNONSETTINGDIV" + Environment.NewLine;
                                sqlText += "    ,@ESTMATEADDUPREMDIV" + Environment.NewLine;
                                sqlText += "    ,@ACPODRRADDUPREMDIV" + Environment.NewLine;
                                sqlText += "    ,@SHIPMADDUPREMDIV" + Environment.NewLine;
                                sqlText += "    ,@RETGOODSSTOCKETYDIV" + Environment.NewLine;
                                sqlText += "    ,@LISTPRICESELECTDIV" + Environment.NewLine;
                                sqlText += "    ,@MAKERINPDIV" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSCDINPDIV" + Environment.NewLine;
                                sqlText += "    ,@SUPPLIERINPDIV" + Environment.NewLine;
                                sqlText += "    ,@SUPPLIERSLIPDELDIV" + Environment.NewLine;
                                sqlText += "    ,@CUSTGUIDEDISPDIV" + Environment.NewLine;
                                sqlText += "    ,@SLIPCHNGDIVDATE" + Environment.NewLine;
                                sqlText += "    ,@SLIPCHNGDIVCOST" + Environment.NewLine;
                                sqlText += "    ,@SLIPCHNGDIVUNPRC" + Environment.NewLine;
                                sqlText += "    ,@SLIPCHNGDIVLPRICE" + Environment.NewLine;
                                sqlText += "    ,@AUTODEPOKINDCODE" + Environment.NewLine;
                                sqlText += "    ,@AUTODEPOKINDNAME" + Environment.NewLine;
                                sqlText += "    ,@AUTODEPOKINDDIVCD" + Environment.NewLine;
                                sqlText += "    ,@DISCOUNTNAME" + Environment.NewLine;
                                sqlText += "    ,@INPAGENTDISPDIV" + Environment.NewLine;
                                sqlText += "    ,@CUSTORDERNODISPDIV" + Environment.NewLine;
                                sqlText += "    ,@CARMNGNODISPDIV" + Environment.NewLine;
                                sqlText += "    ,@BRSLIPNOTE3DISPDIV" + Environment.NewLine;
                                sqlText += "    ,@SLIPDATECLRDIVCD" + Environment.NewLine;
                                sqlText += "    ,@AUTOENTRYGOODSDIVCD" + Environment.NewLine;
                                sqlText += "    ,@COSTCHECKDIVCD" + Environment.NewLine;
                                sqlText += "    ,@JOININITDISPDIV" + Environment.NewLine;
                                sqlText += "    ,@AUTODEPOSITCD" + Environment.NewLine;
                                sqlText += "    ,@SUBSTCONDDIVCD" + Environment.NewLine;
                                sqlText += "    ,@SLIPCREATEPROCESS" + Environment.NewLine;
                                sqlText += "    ,@WAREHOUSECHKDIV" + Environment.NewLine;
                                sqlText += "    ,@PARTSSEARCHDIVCD" + Environment.NewLine;
                                sqlText += "    ,@GRSPROFITDSPCD" + Environment.NewLine;
                                sqlText += "    ,@PARTSSEARCHPRIDIVCD" + Environment.NewLine;
                                sqlText += "    ,@SALESSTOCKDIV" + Environment.NewLine;
                                sqlText += "    ,@PRTBLGOODSCODEDIV" + Environment.NewLine;
                                sqlText += "    ,@SECTDSPDIVCD" + Environment.NewLine;
                                sqlText += "    ,@GOODSNMREDISPDIVCD" + Environment.NewLine;
                                sqlText += "    ,@COSTDSPDIVCD" + Environment.NewLine;
                                sqlText += "    ,@DEPOSLIPDATECLRDIV" + Environment.NewLine;
                                sqlText += "    ,@DEPOSLIPDATEAMBIT" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.06.09 upd end ---------------------------------------------------<<
                                // �� 2008.02.26 980081 c
                                //�o�^�w�b�_����ݒ�
                                obj = (object)this;
                                flhd = (IFileHeader)salesTtlStWork;
                                fileHeader = new ClientFileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                                break;
                        }

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipUnPrcPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPUNPRCPRTDIV", SqlDbType.Int);
                        SqlParameter paraGrsProfitCheckLower = sqlCommand.Parameters.Add("@GRSPROFITCHECKLOWER", SqlDbType.Float);
                        SqlParameter paraGrsProfitCheckBest = sqlCommand.Parameters.Add("@GRSPROFITCHECKBEST", SqlDbType.Float);
                        SqlParameter paraGrsProfitCheckUpper = sqlCommand.Parameters.Add("@GRSPROFITCHECKUPPER", SqlDbType.Float);
                        SqlParameter paraGrsProfitChkLowSign = sqlCommand.Parameters.Add("@GRSPROFITCHKLOWSIGN", SqlDbType.NChar);
                        SqlParameter paraGrsProfitChkBestSign = sqlCommand.Parameters.Add("@GRSPROFITCHKBESTSIGN", SqlDbType.NChar);
                        SqlParameter paraGrsProfitChkUprSign = sqlCommand.Parameters.Add("@GRSPROFITCHKUPRSIGN", SqlDbType.NChar);
                        SqlParameter paraGrsProfitChkMaxSign = sqlCommand.Parameters.Add("@GRSPROFITCHKMAXSIGN", SqlDbType.NChar);
                        SqlParameter paraSalesAgentChngDiv = sqlCommand.Parameters.Add("@SALESAGENTCHNGDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrAgentDispDiv = sqlCommand.Parameters.Add("@ACPODRAGENTDISPDIV", SqlDbType.Int);
                        SqlParameter paraBrSlipNote2DispDiv = sqlCommand.Parameters.Add("@BRSLIPNOTE2DISPDIV", SqlDbType.Int);
                        SqlParameter paraDtlNoteDispDiv = sqlCommand.Parameters.Add("@DTLNOTEDISPDIV", SqlDbType.Int);
                        SqlParameter paraUnPrcNonSettingDiv = sqlCommand.Parameters.Add("@UNPRCNONSETTINGDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrAddUpRemDiv = sqlCommand.Parameters.Add("@ACPODRRADDUPREMDIV", SqlDbType.Int);
                        SqlParameter paraShipmAddUpRemDiv = sqlCommand.Parameters.Add("@SHIPMADDUPREMDIV", SqlDbType.Int);
                        SqlParameter paraRetGoodsStockEtyDiv = sqlCommand.Parameters.Add("@RETGOODSSTOCKETYDIV", SqlDbType.Int);
                        SqlParameter paraListPriceSelectDiv = sqlCommand.Parameters.Add("@LISTPRICESELECTDIV", SqlDbType.Int);
                        SqlParameter paraMakerInpDiv = sqlCommand.Parameters.Add("@MAKERINPDIV", SqlDbType.Int);
                        SqlParameter paraBLGoodsCdInpDiv = sqlCommand.Parameters.Add("@BLGOODSCDINPDIV", SqlDbType.Int);
                        SqlParameter paraSupplierInpDiv = sqlCommand.Parameters.Add("@SUPPLIERINPDIV", SqlDbType.Int);
                        SqlParameter paraSupplierSlipDelDiv = sqlCommand.Parameters.Add("@SUPPLIERSLIPDELDIV", SqlDbType.Int);
                        SqlParameter paraCustGuideDispDiv = sqlCommand.Parameters.Add("@CUSTGUIDEDISPDIV", SqlDbType.Int);
                        SqlParameter paraSlipChngDivDate = sqlCommand.Parameters.Add("@SLIPCHNGDIVDATE", SqlDbType.Int);
                        SqlParameter paraSlipChngDivCost = sqlCommand.Parameters.Add("@SLIPCHNGDIVCOST", SqlDbType.Int);
                        SqlParameter paraSlipChngDivUnPrc = sqlCommand.Parameters.Add("@SLIPCHNGDIVUNPRC", SqlDbType.Int);
                        SqlParameter paraSlipChngDivLPrice = sqlCommand.Parameters.Add("@SLIPCHNGDIVLPRICE", SqlDbType.Int);
                        // �� 2008.02.18 980081 a
                        SqlParameter paraAutoDepoKindCode = sqlCommand.Parameters.Add("@AUTODEPOKINDCODE", SqlDbType.Int);
                        SqlParameter paraAutoDepoKindName = sqlCommand.Parameters.Add("@AUTODEPOKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraAutoDepoKindDivCd = sqlCommand.Parameters.Add("@AUTODEPOKINDDIVCD", SqlDbType.Int);
                        // �� 2008.02.18 980081 a
                        // �� 2008.02.26 980081 a
                        
                        SqlParameter paraDiscountName = sqlCommand.Parameters.Add("@DISCOUNTNAME", SqlDbType.NVarChar);
                        // �� 2008.02.26 980081 a
                        // 2008.06.09 add start ----------------------------------------->>
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraEstmateAddUpRemDiv = sqlCommand.Parameters.Add("@ESTMATEADDUPREMDIV", SqlDbType.Int);
                        SqlParameter paraInpAgentDispDiv = sqlCommand.Parameters.Add("@INPAGENTDISPDIV", SqlDbType.Int);
                        SqlParameter paraCustOrderNoDispDiv = sqlCommand.Parameters.Add("@CUSTORDERNODISPDIV", SqlDbType.Int);
                        SqlParameter paraCarMngNoDispDiv = sqlCommand.Parameters.Add("@CARMNGNODISPDIV", SqlDbType.Int);
                        SqlParameter paraBrSlipNote3DispDiv = sqlCommand.Parameters.Add("@BRSLIPNOTE3DISPDIV", SqlDbType.Int);
                        SqlParameter paraSlipDateClrDivCd = sqlCommand.Parameters.Add("@SLIPDATECLRDIVCD", SqlDbType.Int);
                        SqlParameter paraAutoEntryGoodsDivCd = sqlCommand.Parameters.Add("@AUTOENTRYGOODSDIVCD", SqlDbType.Int);
                        SqlParameter paraCostCheckDivCd = sqlCommand.Parameters.Add("@COSTCHECKDIVCD", SqlDbType.Int);
                        SqlParameter paraJoinInitDispDiv = sqlCommand.Parameters.Add("@JOININITDISPDIV", SqlDbType.Int);
                        SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                        SqlParameter paraSubstCondDivCd = sqlCommand.Parameters.Add("@SUBSTCONDDIVCD", SqlDbType.Int);
                        SqlParameter paraSlipCreateProcess = sqlCommand.Parameters.Add("@SLIPCREATEPROCESS", SqlDbType.Int);
                        SqlParameter paraWarehouseChkDiv = sqlCommand.Parameters.Add("@WAREHOUSECHKDIV", SqlDbType.Int);
                        SqlParameter paraPartsSearchDivCd = sqlCommand.Parameters.Add("@PARTSSEARCHDIVCD", SqlDbType.Int);
                        SqlParameter paraGrsProfitDspCd = sqlCommand.Parameters.Add("@GRSPROFITDSPCD", SqlDbType.Int);
                        SqlParameter paraPartsSearchPriDivCd = sqlCommand.Parameters.Add("@PARTSSEARCHPRIDIVCD", SqlDbType.Int);
                        SqlParameter paraSalesStockDiv = sqlCommand.Parameters.Add("@SALESSTOCKDIV", SqlDbType.Int);
                        SqlParameter paraPrtBLGoodsCodeDiv = sqlCommand.Parameters.Add("@PRTBLGOODSCODEDIV", SqlDbType.Int);
                        SqlParameter paraSectDspDivCd = sqlCommand.Parameters.Add("@SECTDSPDIVCD", SqlDbType.Int);
                        SqlParameter paraGoodsNmReDispDivCd = sqlCommand.Parameters.Add("@GOODSNMREDISPDIVCD", SqlDbType.Int);
                        SqlParameter paraCostDspDivCd = sqlCommand.Parameters.Add("@COSTDSPDIVCD", SqlDbType.Int);
                        SqlParameter paraDepoSlipDateClrDiv = sqlCommand.Parameters.Add("@DEPOSLIPDATECLRDIV", SqlDbType.Int);
                        SqlParameter paraDepoSlipDateAmbit = sqlCommand.Parameters.Add("@DEPOSLIPDATEAMBIT", SqlDbType.Int);
                        // 2008.06.09 add end -------------------------------------------<<
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesTtlStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesTtlStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesTtlStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.LogicalDeleteCode);
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ShipmSlipPrtDiv);
                        paraShipmSlipUnPrcPrtDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ShipmSlipUnPrcPrtDiv);
                        paraGrsProfitCheckLower.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.GrsProfitCheckLower);
                        paraGrsProfitCheckBest.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.GrsProfitCheckBest);
                        paraGrsProfitCheckUpper.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.GrsProfitCheckUpper);
                        paraGrsProfitChkLowSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkLowSign);
                        paraGrsProfitChkBestSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkBestSign);
                        paraGrsProfitChkUprSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkUprSign);
                        paraGrsProfitChkMaxSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkMaxSign);
                        paraSalesAgentChngDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SalesAgentChngDiv);
                        paraAcpOdrAgentDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AcpOdrAgentDispDiv);
                        paraBrSlipNote2DispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BrSlipNote2DispDiv);
                        paraDtlNoteDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.DtlNoteDispDiv);
                        paraUnPrcNonSettingDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.UnPrcNonSettingDiv);
                        paraAcpOdrrAddUpRemDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AcpOdrrAddUpRemDiv);
                        paraShipmAddUpRemDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ShipmAddUpRemDiv);
                        paraRetGoodsStockEtyDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.RetGoodsStockEtyDiv);
                        paraListPriceSelectDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ListPriceSelectDiv);
                        paraMakerInpDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.MakerInpDiv);
                        paraBLGoodsCdInpDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLGoodsCdInpDiv);
                        paraSupplierInpDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SupplierInpDiv);
                        paraSupplierSlipDelDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SupplierSlipDelDiv);
                        paraCustGuideDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CustGuideDispDiv);
                        paraSlipChngDivDate.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivDate);
                        paraSlipChngDivCost.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivCost);
                        paraSlipChngDivUnPrc.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivUnPrc);
                        paraSlipChngDivLPrice.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivLPrice);
                        // �� 2008.02.18 980081 a
                        paraAutoDepoKindCode.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoDepoKindCode);
                        paraAutoDepoKindName.Value = SqlDataMediator.SqlSetString(salesTtlStWork.AutoDepoKindName);
                        paraAutoDepoKindDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoDepoKindDivCd);
                        // �� 2008.02.18 980081 a
                        // �� 2008.02.26 980081 a
                        
                        paraDiscountName.Value = SqlDataMediator.SqlSetString(salesTtlStWork.DiscountName);
                        // �� 2008.02.26 980081 a
                        // 2008.06.09 add start ----------------------------------------->>
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);
                        paraEstmateAddUpRemDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.EstmateAddUpRemDiv);
                        paraInpAgentDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.InpAgentDispDiv);
                        paraCustOrderNoDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CustOrderNoDispDiv);
                        paraCarMngNoDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CarMngNoDispDiv);
                        paraBrSlipNote3DispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BrSlipNote3DispDiv);
                        paraSlipDateClrDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipDateClrDivCd);
                        paraAutoEntryGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoEntryGoodsDivCd);
                        paraCostCheckDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CostCheckDivCd);
                        paraJoinInitDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.JoinInitDispDiv);
                        paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoDepositCd);
                        paraSubstCondDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SubstCondDivCd);
                        paraSlipCreateProcess.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipCreateProcess);
                        paraWarehouseChkDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.WarehouseChkDiv);
                        paraPartsSearchDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PartsSearchDivCd);
                        paraGrsProfitDspCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GrsProfitDspCd);
                        paraPartsSearchPriDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PartsSearchPriDivCd);
                        paraSalesStockDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SalesStockDiv);
                        paraPrtBLGoodsCodeDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PrtBLGoodsCodeDiv);
                        paraSectDspDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SectDspDivCd);
                        paraGoodsNmReDispDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GoodsNmReDispDivCd);
                        paraCostDspDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CostDspDivCd);
                        paraDepoSlipDateClrDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.DepoSlipDateClrDiv);
                        paraDepoSlipDateAmbit.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.DepoSlipDateAmbit);
                        // 2008.06.09 add end -------------------------------------------<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    //���[�U�f�[�^�V���N�Ǘ��}�X�^�֍X�V
                    DataSyncMngWork dataSyncMngWork = new DataSyncMngWork();
                    DataSyncMngLcDB dataSyncMngLcDB = new DataSyncMngLcDB();
                    List<DataSyncMngWork> dataSyncMngWorkList = new List<DataSyncMngWork>();
                    dataSyncMngWork.EnterpriseCode = syncServiceWork.EnterpriseCode;
                    dataSyncMngWork.LastDataUpdDate = syncServiceWork.SyncDateTimeEd;
                    dataSyncMngWork.SyncExecDate = syncServiceWork.SyncExecDate;
                    dataSyncMngWork.ManagementTableName = syncServiceWork.ManagementTableName;
                    dataSyncMngWork.DataDeleteDateTime = syncServiceWork.DataDeleteDateTime;
                    dataSyncMngWorkList.Add(dataSyncMngWork);
                    status = dataSyncMngLcDB.WriteDataSyncMngProc(ref dataSyncMngWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SalesTtlStLcDB.WriteSyncLocalDataProc", 0);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="salesTtlStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchSalesTtlStParaWork salesTtlStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 2008.06.09 del start ----------------------------->>
            //���_�R�[�h
            if (salesTtlStWork.SectionCode != "")
            {
                retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);
            }
            // 2008.06.09 del end ------------------------------<<

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalesTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        private SalesTtlStWork CopyToSalesTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            SalesTtlStWork wkSalesTtlStWork = new SalesTtlStWork();

            #region �N���X�֊i�[
            wkSalesTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSalesTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSalesTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSalesTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSalesTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSalesTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSalesTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSalesTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSalesTtlStWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
            wkSalesTtlStWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
            wkSalesTtlStWork.ShipmSlipUnPrcPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPUNPRCPRTDIVRF"));
            wkSalesTtlStWork.GrsProfitCheckLower = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITCHECKLOWERRF"));
            wkSalesTtlStWork.GrsProfitCheckBest = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITCHECKBESTRF"));
            wkSalesTtlStWork.GrsProfitCheckUpper = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITCHECKUPPERRF"));
            wkSalesTtlStWork.GrsProfitChkLowSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKLOWSIGNRF"));
            wkSalesTtlStWork.GrsProfitChkBestSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKBESTSIGNRF"));
            wkSalesTtlStWork.GrsProfitChkUprSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKUPRSIGNRF"));
            wkSalesTtlStWork.GrsProfitChkMaxSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKMAXSIGNRF"));
            wkSalesTtlStWork.SalesAgentChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAGENTCHNGDIVRF"));
            wkSalesTtlStWork.AcpOdrAgentDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRAGENTDISPDIVRF"));
            wkSalesTtlStWork.BrSlipNote2DispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BRSLIPNOTE2DISPDIVRF"));
            wkSalesTtlStWork.DtlNoteDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLNOTEDISPDIVRF"));
            wkSalesTtlStWork.UnPrcNonSettingDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCNONSETTINGDIVRF"));
            wkSalesTtlStWork.AcpOdrrAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRADDUPREMDIVRF"));
            wkSalesTtlStWork.ShipmAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMADDUPREMDIVRF"));
            wkSalesTtlStWork.RetGoodsStockEtyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSSTOCKETYDIVRF"));
            wkSalesTtlStWork.ListPriceSelectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICESELECTDIVRF"));
            wkSalesTtlStWork.MakerInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERINPDIVRF"));
            wkSalesTtlStWork.BLGoodsCdInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDINPDIVRF"));
            wkSalesTtlStWork.SupplierInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERINPDIVRF"));
            wkSalesTtlStWork.SupplierSlipDelDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPDELDIVRF"));
            wkSalesTtlStWork.CustGuideDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTGUIDEDISPDIVRF"));
            wkSalesTtlStWork.SlipChngDivDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVDATERF"));
            wkSalesTtlStWork.SlipChngDivCost = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVCOSTRF"));
            wkSalesTtlStWork.SlipChngDivUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVUNPRCRF"));
            wkSalesTtlStWork.SlipChngDivLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVLPRICERF"));
            // �� 2008.02.18 980081 a
            wkSalesTtlStWork.AutoDepoKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOKINDCODERF"));
            wkSalesTtlStWork.AutoDepoKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTODEPOKINDNAMERF"));
            wkSalesTtlStWork.AutoDepoKindDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOKINDDIVCDRF"));
            // �� 2008.02.18 980081 a
            // �� 2008.02.26 980081 a
            
            wkSalesTtlStWork.DiscountName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISCOUNTNAMERF"));
            // �� 2008.02.26 980081 a
            // 2008.06.09 add start ------------------------------------>>
            wkSalesTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkSalesTtlStWork.EstmateAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMATEADDUPREMDIVRF"));
            wkSalesTtlStWork.InpAgentDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPAGENTDISPDIVRF"));
            wkSalesTtlStWork.CustOrderNoDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTORDERNODISPDIVRF"));
            wkSalesTtlStWork.CarMngNoDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNODISPDIVRF"));
            wkSalesTtlStWork.BrSlipNote3DispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BRSLIPNOTE3DISPDIVRF"));
            wkSalesTtlStWork.SlipDateClrDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDATECLRDIVCDRF"));
            wkSalesTtlStWork.AutoEntryGoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOENTRYGOODSDIVCDRF"));
            wkSalesTtlStWork.CostCheckDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COSTCHECKDIVCDRF"));
            wkSalesTtlStWork.JoinInitDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOININITDISPDIVRF"));
            wkSalesTtlStWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            wkSalesTtlStWork.SubstCondDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSTCONDDIVCDRF"));
            wkSalesTtlStWork.SlipCreateProcess = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCREATEPROCESSRF"));
            wkSalesTtlStWork.WarehouseChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAREHOUSECHKDIVRF"));
            wkSalesTtlStWork.PartsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSEARCHDIVCDRF"));
            wkSalesTtlStWork.GrsProfitDspCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITDSPCDRF"));
            wkSalesTtlStWork.PartsSearchPriDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSEARCHPRIDIVCDRF"));
            wkSalesTtlStWork.SalesStockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSTOCKDIVRF"));
            wkSalesTtlStWork.PrtBLGoodsCodeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODEDIVRF"));
            wkSalesTtlStWork.SectDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTDSPDIVCDRF"));
            wkSalesTtlStWork.GoodsNmReDispDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNMREDISPDIVCDRF"));
            wkSalesTtlStWork.CostDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COSTDSPDIVCDRF"));
            wkSalesTtlStWork.DepoSlipDateClrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSLIPDATECLRDIVRF"));
            wkSalesTtlStWork.DepoSlipDateAmbit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSLIPDATEAMBITRF"));
            // 2008.06.09 add end --------------------------------------<<
            #endregion

            return wkSalesTtlStWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_UserDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [�G���[���O�o�͏���]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}
