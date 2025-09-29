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
// �� 2008.02.08 980081 a
using Broadleaf.Application.Common;
// �� 2008.02.08 980081 a

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081�@�D�c  �E�l</br>
    /// <br>Date       : 2007.09.18</br>
    /// <br></br>
    /// <br>Update Note: 980081 �R�c ���F</br>
    /// <br>Date       : 2008.02.08</br>
    /// <br>             ���[�J���V���N�Ή�</br>
    /// <br>Update Note: 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.05.26</br>
    /// <br>             �o�l.�m�r�p�ɕύX</br>
    /// <br>Update Note: caowj</br>
    /// <br>Date       : 2010.08.06</br>
    /// <br>             �o�l.�m�r�P�O�P�Q�p�ɕύX</br>
    /// </remarks>
    [Serializable]
    // �� 2008.02.08 980081 a
    //public class CustSlipMngDB : RemoteDB, ICustSlipMngDB
    public class CustSlipMngDB : RemoteDB, ICustSlipMngDB, IGetSyncdataList
    // �� 2008.02.08 980081 a
    {
        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public CustSlipMngDB()
            :
            base("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork", "CUSTSLIPMNGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="custslipmngWork">��������</param>
        /// <param name="paracustslipmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        public int Search(out object custslipmngWork, object paracustslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custslipmngWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCustSlipMngProc(out custslipmngWork, paracustslipmngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSlipMngDB.Search");
                custslipmngWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objcustslipmngWork">��������</param>
        /// <param name="paracustslipmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        public int SearchCustSlipMngProc(out object objcustslipmngWork, object paracustslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            CustSlipMngWork custslipmngWork = null; 

            ArrayList custslipmngWorkList = paracustslipmngWork as ArrayList;
            if (custslipmngWorkList == null)
            {
                custslipmngWork = paracustslipmngWork as CustSlipMngWork;
            }
            else
            {
                if (custslipmngWorkList.Count > 0)
                    custslipmngWork = custslipmngWorkList[0] as CustSlipMngWork;
            }

            int status = SearchCustSlipMngProc(out custslipmngWorkList, custslipmngWork, readMode, logicalMode, ref sqlConnection);
            objcustslipmngWork = custslipmngWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">��������</param>
        /// <param name="custslipmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		public int SearchCustSlipMngProc(out ArrayList custslipmngWorkList, CustSlipMngWork custslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchCustSlipMngProcProc(out custslipmngWorkList, custslipmngWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">��������</param>
        /// <param name="custslipmngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		private int SearchCustSlipMngProcProc(out ArrayList custslipmngWorkList, CustSlipMngWork custslipmngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start ------------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end --------------------------------<<

		        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, custslipmngWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCustSlipMngWorkFromReader(ref myReader));

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

            custslipmngWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                CustSlipMngWork custslipmngWork = new CustSlipMngWork();

                // XML�̓ǂݍ���
                custslipmngWork = (CustSlipMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSlipMngWork));
                if (custslipmngWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref custslipmngWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(custslipmngWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSlipMngDB.Read");
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
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		public int ReadProc(ref CustSlipMngWork custslipmngWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref custslipmngWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		private int ReadProcProc(ref CustSlipMngWork custslipmngWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            
            try        
            {
                //Select�R�}���h�̐���
                // 2008.05.26 upd start ------------------------------------------>>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += " WHERE CUSTSLIP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlTxt += "    AND CUSTSLIP.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                // 2008.05.26 upd end --------------------------------------------<<
                {
                    
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 2008.05.26 add
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);              // 2008.05.26 add
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                    
                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        custslipmngWork = CopyToCustSlipMngWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        public int Write(ref object custslipmngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(custslipmngWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteCustSlipMngProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                custslipmngWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSlipMngDB.Write(ref object custslipmngWork)");
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
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		public int WriteCustSlipMngProc(ref ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteCustSlipMngProcProc(ref custslipmngWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		private int WriteCustSlipMngProcProc(ref ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.26 add
            try
            {
                if (custslipmngWorkList != null)
                {
                    for (int i = 0; i < custslipmngWorkList.Count; i++)
                    {
                        CustSlipMngWork custslipmngWork = custslipmngWorkList[i] as CustSlipMngWork;

                        //Select�R�}���h�̐���
                        // 2008.05.26 upd start ----------------------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end -------------------------------------------------------<<

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 2008.05.26 add
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);              // 2008.05.26 add 
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                        
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != custslipmngWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (custslipmngWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008.05.26 upd start -------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE CUSTSLIPMNGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERSNMRF=@CUSTOMERSNM , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                            sqlTxt += "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTKINDRF=@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            sqlTxt = string.Empty;
                            // 2008.05.26 upd end ----------------------------------------<<
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                            findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);        // 2008.05.26 add 
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custslipmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (custslipmngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            //�V�K�쐬����SQL���𐶐�
                            // 2008.05.26 upd start --------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO CUSTSLIPMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, CUSTOMERCODERF, CUSTOMERSNMRF, SLIPPRTSETPAPERIDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @CUSTOMERCODE, @CUSTOMERSNM, @SLIPPRTSETPAPERID)";
                            sqlTxt += "INSERT INTO CUSTSLIPMNGRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
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
                            sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            sqlTxt = string.Empty;
                            // 2008.05.26 upd end -----------------------------------<<
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custslipmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 2008.05.26 add
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NChar);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custslipmngWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custslipmngWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custslipmngWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.LogicalDeleteCode);
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);         // 2008.05.26 add
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(custslipmngWork.SlipPrtSetPaperId);
                        #endregion
                        
                        sqlCommand.ExecuteNonQuery();
                        al.Add(custslipmngWork);
                    }
                }
                
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
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

            custslipmngWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        public int LogicalDelete(ref object custslipmngWork)
        {
            return LogicalDeleteCustSlipMng(ref custslipmngWork, 0);
        }

        /// <summary>
        /// �_���폜���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        public int RevivalLogicalDelete(ref object custslipmngWork)
        {
            return LogicalDeleteCustSlipMng(ref custslipmngWork, 1);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        private int LogicalDeleteCustSlipMng(ref object custslipmngWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(custslipmngWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCustSlipMngProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "CustSlipMngDB.LogicalDeleteCustSlipMng :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		public int LogicalDeleteCustSlipMngProc(ref ArrayList custslipmngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteCustSlipMngProcProc(ref custslipmngWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">CustSlipMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		private int LogicalDeleteCustSlipMngProcProc(ref ArrayList custslipmngWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.26 add 
            try
            {
                if (custslipmngWorkList != null)
                {
                    for (int i = 0; i < custslipmngWorkList.Count; i++)
                    {
                        CustSlipMngWork custslipmngWork = custslipmngWorkList[i] as CustSlipMngWork;

                        //Select�R�}���h�̐���
                        // 2008.05.26 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.26 upd end ----------------------------------<<

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("FINDSECTIONCODE", SqlDbType.NChar);   // 2008.05.26 add
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);              // 2008.05.26 add
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != custslipmngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // 2008.05.26 upd start ----------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end -------------------------------------------<<
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                            findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);    // 2008.05.26 add
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custslipmngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) custslipmngWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else custslipmngWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) custslipmngWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custslipmngWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custslipmngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custslipmngWork);
                    }

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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            custslipmngWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteCustSlipMngProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CustSlipMngDB.Delete");
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
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		public int DeleteCustSlipMngProc(ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteCustSlipMngProcProc(custslipmngWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="custslipmngWorkList">���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
		private int DeleteCustSlipMngProcProc(ArrayList custslipmngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.05.26 add
            try
            {
                for (int i = 0; i < custslipmngWorkList.Count; i++)
                {
                    CustSlipMngWork custslipmngWork = custslipmngWorkList[i] as CustSlipMngWork;
                    // 2008.05.26 upd start ------------------------->>
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                    sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    sqlTxt = string.Empty;
                    // 2008.05.26 upd end ---------------------------<<

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);   // 2008.05.26 add
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);               // 2008.05.26 add
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != custslipmngWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // 2008.05.26 upd start ---------------------------------------->>
                        //sqlCommand.CommandText = "DELETE FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end ------------------------------------------<<
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);  // 2008.05.26 add
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();                    
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
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
        // �� 2008.02.08 980081 a
        #region [GetSyncdataList]
		/// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}
		
		/// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start ------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end ---------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToCustSlipMngWorkFromReader(ref myReader));
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
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += "CUSTSLIP.ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND CUSTSLIP.UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND CUSTSLIP.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND CUSTSLIP.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion
        // �� 2008.02.08 980081 a

	    #region [Where���쐬����]
	    /// <summary>
	    /// �������������񐶐��{�����l�ݒ�
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
	    /// <param name="custslipmngWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSlipMngWork custslipmngWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
            retstring += "CUSTSLIP.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.EnterpriseCode);

		    // �_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND CUSTSLIP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND CUSTSLIP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // �f�[�^���̓V�X�e��
            if (custslipmngWork.DataInputSystem != 0)
            {
                retstring += "AND CUSTSLIP.DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM ";
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.DataInputSystem);
            }

            // �`�[������
            if (custslipmngWork.SlipPrtKind != 0)
            {
                retstring += "AND CUSTSLIP.SLIPPRTKINDRF=@FINDSLIPPRTKIND ";
                SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.SlipPrtKind);
            }

            // 2008.05.26 add start ------------------------------>>
            // ���_�R�[�h
            if (custslipmngWork.SectionCode != string.Empty)
            {
                retstring += "AND CUSTSLIP.SECTIONCODERF=@FINDSECTIONCODE ";
                // ---DEL 2010/08/06 ------------------------------------------------------------>>>>>
                //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                // ---DEL 2010/08/06 ------------------------------------------------------------<<<<<
                // ---UPD 2010/08/06 ------------------------------------------------------------>>>>>
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                // ---UPD 2010/08/06 ------------------------------------------------------------<<<<<
                paraSectionCode.Value = SqlDataMediator.SqlSetString(custslipmngWork.SectionCode);
            }
            // 2008.05.26 add end --------------------------------<<

            // ���Ӑ�R�[�h
            if (custslipmngWork.CustomerCode != 0)
            {
                retstring += "AND CUSTSLIP.CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custslipmngWork.CustomerCode);
            }

		    return retstring;
		}
	    #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustSlipMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustSlipMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private CustSlipMngWork CopyToCustSlipMngWorkFromReader(ref SqlDataReader myReader)
        {
            CustSlipMngWork wkCustSlipMngWork = new CustSlipMngWork();

            #region �N���X�֊i�[
            wkCustSlipMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustSlipMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustSlipMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustSlipMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustSlipMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustSlipMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustSlipMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustSlipMngWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            wkCustSlipMngWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
            wkCustSlipMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkCustSlipMngWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustSlipMngWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustSlipMngWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            #endregion

            return wkCustSlipMngWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CustSlipMngWork[] CustSlipMngWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is CustSlipMngWork)
                    {
                        CustSlipMngWork wkCustSlipMngWork = paraobj as CustSlipMngWork;
                        if (wkCustSlipMngWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCustSlipMngWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CustSlipMngWorkArray = (CustSlipMngWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CustSlipMngWork[]));
                        }
                        catch (Exception) { }
                        if (CustSlipMngWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CustSlipMngWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CustSlipMngWork wkCustSlipMngWork = (CustSlipMngWork)XmlByteSerializer.Deserialize(byteArray, typeof(CustSlipMngWork));
                                if (wkCustSlipMngWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCustSlipMngWork);
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
        /// <br>Programmer : 20081�@�D�c  �E�l</br>
        /// <br>Date       : 2007.09.18</br>
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
