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
    /// SCM���ꉿ�i�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.05.08</br>
    /// <br></br>
    /// <br>Update Note: ���ꉿ�i�i���R�[�h�Q�A���ꉿ�i�i���R�[�h�R�̒ǉ�</br>
    /// <br>Programmer : 21024 ���X��</br>
    /// <br>Date       : 2010/04/12</br>
    /// </remarks>
    [Serializable]
    public class SCMMrktPriStDB : RemoteDB, ISCMMrktPriStDB
    {
        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        public SCMMrktPriStDB()
            :
            base("PMSCM09056D", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork", "SCMMRKTPRISTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="scmMrktPriStWork">��������</param>
        /// <param name="parascmMrktPriStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int Search(out object scmMrktPriStWork, object parascmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmMrktPriStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMMrktPriStProc(out scmMrktPriStWork, parascmMrktPriStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Search");
                scmMrktPriStWork = new ArrayList();
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
        /// �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objscmMrktPriStWork">��������</param>
        /// <param name="parascmMrktPriStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int SearchSCMMrktPriStProc(out object objscmMrktPriStWork, object parascmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMMrktPriStWork scmMrktPriStWork = null; 

            ArrayList scmMrktPriStWorkList = parascmMrktPriStWork as ArrayList;
            if (scmMrktPriStWorkList == null)
            {
                scmMrktPriStWork = parascmMrktPriStWork as SCMMrktPriStWork;
            }
            else
            {
                if (scmMrktPriStWorkList.Count > 0)
                    scmMrktPriStWork = scmMrktPriStWorkList[0] as SCMMrktPriStWork;
            }

            int status = SearchSCMMrktPriStProc(out scmMrktPriStWorkList, scmMrktPriStWork, readMode, logicalMode, ref sqlConnection);
            objscmMrktPriStWork = scmMrktPriStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">��������</param>
        /// <param name="scmMrktPriStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int SearchSCMMrktPriStProc(out ArrayList scmMrktPriStWorkList, SCMMrktPriStWork scmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMMrktPriStProcProc(out scmMrktPriStWorkList, scmMrktPriStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">��������</param>
        /// <param name="scmMrktPriStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private int SearchSCMMrktPriStProcProc(out ArrayList scmMrktPriStWorkList, SCMMrktPriStWork scmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += " SELECT   CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEAREACDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD1RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD2RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD3RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICESALESRATERF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT10RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT10RF " + Environment.NewLine;
                selectTxt += "         ,FRACTIONPROCCDRF" + Environment.NewLine;
                // 2010/04/12 Add >>>
                selectTxt += "         ,MARKETPRICEQUALITYCD2RF" + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCD3RF" + Environment.NewLine;
                // 2010/04/12 Add <<<
                selectTxt += "  FROM SCMMRKTPRISTRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmMrktPriStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSCMMrktPriStWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            scmMrktPriStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();

                // XML�̓ǂݍ���
                scmMrktPriStWork = (SCMMrktPriStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMMrktPriStWork));
                if (scmMrktPriStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmMrktPriStWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(scmMrktPriStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Read");
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
        /// �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int ReadProc(ref SCMMrktPriStWork scmMrktPriStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref scmMrktPriStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM���ꉿ�i�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private int ReadProcProc(ref SCMMrktPriStWork scmMrktPriStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += " SELECT   CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEAREACDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD1RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD2RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD3RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICESALESRATERF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT10RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT10RF " + Environment.NewLine;
                selectTxt += "         ,FRACTIONPROCCDRF" + Environment.NewLine;
                // 2010/04/12 Add >>>
                selectTxt += "         ,MARKETPRICEQUALITYCD2RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCD3RF " + Environment.NewLine;
                // 2010/04/12 Add <<<
                selectTxt += "  FROM SCMMRKTPRISTRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                #endregion

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmMrktPriStWork = CopyToSCMMrktPriStWorkFromReader(ref myReader);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="scmMrktPriStWork">scmMrktPriStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int Write(ref object scmMrktPriStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmMrktPriStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSCMMrktPriStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMMrktPriStWork paraWork = paraList[0] as SCMMrktPriStWork;
                
                //�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecSCMMrktPriSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                scmMrktPriStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Write(ref object scmMrktPriStWork)");
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
        /// SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int WriteSCMMrktPriStProc(ref ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMMrktPriStProcProc(ref scmMrktPriStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private int WriteSCMMrktPriStProcProc(ref ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmMrktPriStWorkList != null)
                {
                    for (int i = 0; i < scmMrktPriStWorkList.Count; i++)
                    {
                        SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[i] as SCMMrktPriStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMMRKTPRISTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmMrktPriStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (scmMrktPriStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMMRKTPRISTRF SET  " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEAREACDRF = @MARKETPRICEAREACD " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEQUALITYCDRF = @MARKETPRICEQUALITYCD " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEKINDCD1RF = @MARKETPRICEKINDCD1 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEKINDCD2RF = @MARKETPRICEKINDCD2 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEKINDCD3RF = @MARKETPRICEKINDCD3 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEANSWERDIVRF = @MARKETPRICEANSWERDIV " + Environment.NewLine;
                            sqlText += "  , MARKETPRICESALESRATERF = @MARKETPRICESALESRATE " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT1RF = @ADDPAYMNTAMBIT1 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT2RF = @ADDPAYMNTAMBIT2 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT3RF = @ADDPAYMNTAMBIT3 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT4RF = @ADDPAYMNTAMBIT4 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT5RF = @ADDPAYMNTAMBIT5 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT6RF = @ADDPAYMNTAMBIT6 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT7RF = @ADDPAYMNTAMBIT7 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT8RF = @ADDPAYMNTAMBIT8 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT9RF = @ADDPAYMNTAMBIT9 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT10RF = @ADDPAYMNTAMBIT10 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT1RF = @ADDPAYMNT1 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT2RF = @ADDPAYMNT2 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT3RF = @ADDPAYMNT3 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT4RF = @ADDPAYMNT4 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT5RF = @ADDPAYMNT5 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT6RF = @ADDPAYMNT6 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT7RF = @ADDPAYMNT7 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT8RF = @ADDPAYMNT8 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT9RF = @ADDPAYMNT9 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT10RF = @ADDPAYMNT10 " + Environment.NewLine;
                            sqlText += "  , FRACTIONPROCCDRF = @FRACTIONPROCCD" + Environment.NewLine;
                            // 2010/04/12 Add >>>
                            sqlText += "  , MARKETPRICEQUALITYCD2RF = @MARKETPRICEQUALITYCD2 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEQUALITYCD3RF = @MARKETPRICEQUALITYCD3 " + Environment.NewLine;
                            // 2010/04/12 Add <<<
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (scmMrktPriStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMMRKTPRISTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEAREACDRF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEQUALITYCDRF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEKINDCD1RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEKINDCD2RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEKINDCD3RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEANSWERDIVRF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICESALESRATERF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT1RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT2RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT3RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT4RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT5RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT6RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT7RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT8RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT9RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT10RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT1RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT2RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT3RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT4RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT5RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT6RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT7RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT8RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT9RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT10RF " + Environment.NewLine;
                            sqlText += "         ,FRACTIONPROCCDRF" + Environment.NewLine;
                            // 2010/04/12 Add >>>
                            sqlText += "         ,MARKETPRICEQUALITYCD2RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEQUALITYCD3RF " + Environment.NewLine;
                            // 2010/04/12 Add <<<
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "         ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "         ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "         ,@SECTIONCODE " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEAREACD " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEQUALITYCD " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEKINDCD1 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEKINDCD2 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEKINDCD3 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEANSWERDIV " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICESALESRATE " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT1 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT2 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT3 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT4 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT5 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT6 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT7 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT8 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT9 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT10 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT1 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT2 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT3 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT4 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT5 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT6 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT7 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT8 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT9 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT10 " + Environment.NewLine;
                            sqlText += "         ,@FRACTIONPROCCD" + Environment.NewLine;
                            // 2010/04/12 Add >>>
                            sqlText += "         ,@MARKETPRICEQUALITYCD2 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEQUALITYCD3 " + Environment.NewLine;
                            // 2010/04/12 Add <<<
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter paraMarketPriceAreaCd = sqlCommand.Parameters.Add("@MARKETPRICEAREACD", SqlDbType.Int);  // ���ꉿ�i�n��R�[�h
                        SqlParameter paraMarketPriceQualityCd = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD", SqlDbType.Int);  // ���ꉿ�i�i���R�[�h
                        SqlParameter paraMarketPriceKindCd1 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD1", SqlDbType.Int);  // ���ꉿ�i��ʃR�[�h�P
                        SqlParameter paraMarketPriceKindCd2 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD2", SqlDbType.Int);  // ���ꉿ�i��ʃR�[�h�Q
                        SqlParameter paraMarketPriceKindCd3 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD3", SqlDbType.Int);  // ���ꉿ�i��ʃR�[�h�R
                        SqlParameter paraMarketPriceAnswerDiv = sqlCommand.Parameters.Add("@MARKETPRICEANSWERDIV", SqlDbType.Int);  // ���ꉿ�i�񓚋敪
                        SqlParameter paraMarketPriceSalesRate = sqlCommand.Parameters.Add("@MARKETPRICESALESRATE", SqlDbType.Float);  // ���ꉿ�i������
                        SqlParameter paraAddPaymntAmbit1 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT1", SqlDbType.Int);  // ���Z�z�͈�1
                        SqlParameter paraAddPaymntAmbit2 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT2", SqlDbType.Int);  // ���Z�z�͈�2
                        SqlParameter paraAddPaymntAmbit3 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT3", SqlDbType.Int);  // ���Z�z�͈�3
                        SqlParameter paraAddPaymntAmbit4 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT4", SqlDbType.Int);  // ���Z�z�͈�4
                        SqlParameter paraAddPaymntAmbit5 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT5", SqlDbType.Int);  // ���Z�z�͈�5
                        SqlParameter paraAddPaymntAmbit6 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT6", SqlDbType.Int);  // ���Z�z�͈�6
                        SqlParameter paraAddPaymntAmbit7 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT7", SqlDbType.Int);  // ���Z�z�͈�7
                        SqlParameter paraAddPaymntAmbit8 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT8", SqlDbType.Int);  // ���Z�z�͈�8
                        SqlParameter paraAddPaymntAmbit9 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT9", SqlDbType.Int);  // ���Z�z�͈�9
                        SqlParameter paraAddPaymntAmbit10 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT10", SqlDbType.Int);  // ���Z�z�͈�10
                        SqlParameter paraAddPaymnt1 = sqlCommand.Parameters.Add("@ADDPAYMNT1", SqlDbType.Int);  // ���Z�z1
                        SqlParameter paraAddPaymnt2 = sqlCommand.Parameters.Add("@ADDPAYMNT2", SqlDbType.Int);  // ���Z�z2
                        SqlParameter paraAddPaymnt3 = sqlCommand.Parameters.Add("@ADDPAYMNT3", SqlDbType.Int);  // ���Z�z3
                        SqlParameter paraAddPaymnt4 = sqlCommand.Parameters.Add("@ADDPAYMNT4", SqlDbType.Int);  // ���Z�z4
                        SqlParameter paraAddPaymnt5 = sqlCommand.Parameters.Add("@ADDPAYMNT5", SqlDbType.Int);  // ���Z�z5
                        SqlParameter paraAddPaymnt6 = sqlCommand.Parameters.Add("@ADDPAYMNT6", SqlDbType.Int);  // ���Z�z6
                        SqlParameter paraAddPaymnt7 = sqlCommand.Parameters.Add("@ADDPAYMNT7", SqlDbType.Int);  // ���Z�z7
                        SqlParameter paraAddPaymnt8 = sqlCommand.Parameters.Add("@ADDPAYMNT8", SqlDbType.Int);  // ���Z�z8
                        SqlParameter paraAddPaymnt9 = sqlCommand.Parameters.Add("@ADDPAYMNT9", SqlDbType.Int);  // ���Z�z9
                        SqlParameter paraAddPaymnt10 = sqlCommand.Parameters.Add("@ADDPAYMNT10", SqlDbType.Int);  // ���Z�z10
                        SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);  // �[�������敪
                        // 2010/04/12 Add >>>
                        SqlParameter paraMarketPriceQualityCd2 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD2", SqlDbType.Int);  // ���ꉿ�i�i���R�[�h�Q
                        SqlParameter paraMarketPriceQualityCd3 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD3", SqlDbType.Int);  // ���ꉿ�i�i���R�[�h�R
                        // 2010/04/12 Add <<<
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmMrktPriStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);  // ���_�R�[�h
                        paraMarketPriceAreaCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAreaCd);  // ���ꉿ�i�n��R�[�h
                        paraMarketPriceQualityCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd);  // ���ꉿ�i�i���R�[�h
                        paraMarketPriceKindCd1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd1);  // ���ꉿ�i��ʃR�[�h�P
                        paraMarketPriceKindCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd2);  // ���ꉿ�i��ʃR�[�h�Q
                        paraMarketPriceKindCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd3);  // ���ꉿ�i��ʃR�[�h�R
                        paraMarketPriceAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAnswerDiv);  // ���ꉿ�i�񓚋敪
                        paraMarketPriceSalesRate.Value = SqlDataMediator.SqlSetDouble(scmMrktPriStWork.MarketPriceSalesRate);  // ���ꉿ�i������
                        paraAddPaymntAmbit1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit1);  // ���Z�z�͈�1
                        paraAddPaymntAmbit2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit2);  // ���Z�z�͈�2
                        paraAddPaymntAmbit3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit3);  // ���Z�z�͈�3
                        paraAddPaymntAmbit4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit4);  // ���Z�z�͈�4
                        paraAddPaymntAmbit5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit5);  // ���Z�z�͈�5
                        paraAddPaymntAmbit6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit6);  // ���Z�z�͈�6
                        paraAddPaymntAmbit7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit7);  // ���Z�z�͈�7
                        paraAddPaymntAmbit8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit8);  // ���Z�z�͈�8
                        paraAddPaymntAmbit9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit9);  // ���Z�z�͈�9
                        paraAddPaymntAmbit10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit10);  // ���Z�z�͈�10
                        paraAddPaymnt1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt1);  // ���Z�z1
                        paraAddPaymnt2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt2);  // ���Z�z2
                        paraAddPaymnt3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt3);  // ���Z�z3
                        paraAddPaymnt4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt4);  // ���Z�z4
                        paraAddPaymnt5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt5);  // ���Z�z5
                        paraAddPaymnt6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt6);  // ���Z�z6
                        paraAddPaymnt7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt7);  // ���Z�z7
                        paraAddPaymnt8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt8);  // ���Z�z8
                        paraAddPaymnt9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt9);  // ���Z�z9
                        paraAddPaymnt10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt10);  // ���Z�z10
                        paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.FractionProcCd);  // �[�������敪
                        // 2010/04/12 Add >>>
                        paraMarketPriceQualityCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd2);  // ���ꉿ�i�i���R�[�h�Q
                        paraMarketPriceQualityCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd3);  // ���ꉿ�i�i���R�[�h�R
                        // 2010/04/12 Add <<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmMrktPriStWork);
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            scmMrktPriStWorkList = al;

            return status;
        }

        /// <summary>
        /// �S�Ћ��ʍ��ڂ��X�V����
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private int UpdateAllSecSCMMrktPriSt(ref ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmMrktPriStWorkList != null)
                {
                    SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[0] as SCMMrktPriStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region �X�V����SQL������
                    string sqlText = string.Empty;
                    sqlText += " UPDATE SCMMRKTPRISTRF SET  " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEAREACDRF = @MARKETPRICEAREACD " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEQUALITYCDRF = @MARKETPRICEQUALITYCD " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEKINDCD1RF = @MARKETPRICEKINDCD1 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEKINDCD2RF = @MARKETPRICEKINDCD2 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEKINDCD3RF = @MARKETPRICEKINDCD3 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEANSWERDIVRF = @MARKETPRICEANSWERDIV " + Environment.NewLine;
                    sqlText += "  , MARKETPRICESALESRATERF = @MARKETPRICESALESRATE " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT1RF = @ADDPAYMNTAMBIT1 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT2RF = @ADDPAYMNTAMBIT2 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT3RF = @ADDPAYMNTAMBIT3 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT4RF = @ADDPAYMNTAMBIT4 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT5RF = @ADDPAYMNTAMBIT5 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT6RF = @ADDPAYMNTAMBIT6 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT7RF = @ADDPAYMNTAMBIT7 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT8RF = @ADDPAYMNTAMBIT8 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT9RF = @ADDPAYMNTAMBIT9 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT10RF = @ADDPAYMNTAMBIT10 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT1RF = @ADDPAYMNT1 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT2RF = @ADDPAYMNT2 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT3RF = @ADDPAYMNT3 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT4RF = @ADDPAYMNT4 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT5RF = @ADDPAYMNT5 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT6RF = @ADDPAYMNT6 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT7RF = @ADDPAYMNT7 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT8RF = @ADDPAYMNT8 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT9RF = @ADDPAYMNT9 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT10RF = @ADDPAYMNT10 " + Environment.NewLine;
                    sqlText += "  , FRACTIONPROCCDRF = @FRACTIONPROCCD" + Environment.NewLine;
                    // 2010/04/12 Add >>>
                    sqlText += "  , MARKETPRICEQUALITYCD2RF = @MARKETPRICEQUALITYCD2 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEQUALITYCD3RF = @MARKETPRICEQUALITYCD3 " + Environment.NewLine;
                    // 2010/04/12 Add <<<
                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  �@AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                    SqlParameter paraMarketPriceAreaCd = sqlCommand.Parameters.Add("@MARKETPRICEAREACD", SqlDbType.Int);  // ���ꉿ�i�n��R�[�h
                    SqlParameter paraMarketPriceQualityCd = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD", SqlDbType.Int);  // ���ꉿ�i�i���R�[�h
                    SqlParameter paraMarketPriceKindCd1 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD1", SqlDbType.Int);  // ���ꉿ�i��ʃR�[�h�P
                    SqlParameter paraMarketPriceKindCd2 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD2", SqlDbType.Int);  // ���ꉿ�i��ʃR�[�h�Q
                    SqlParameter paraMarketPriceKindCd3 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD3", SqlDbType.Int);  // ���ꉿ�i��ʃR�[�h�R
                    SqlParameter paraMarketPriceAnswerDiv = sqlCommand.Parameters.Add("@MARKETPRICEANSWERDIV", SqlDbType.Int);  // ���ꉿ�i�񓚋敪
                    SqlParameter paraMarketPriceSalesRate = sqlCommand.Parameters.Add("@MARKETPRICESALESRATE", SqlDbType.Float);  // ���ꉿ�i������
                    SqlParameter paraAddPaymntAmbit1 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT1", SqlDbType.Int);  // ���Z�z�͈�1
                    SqlParameter paraAddPaymntAmbit2 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT2", SqlDbType.Int);  // ���Z�z�͈�2
                    SqlParameter paraAddPaymntAmbit3 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT3", SqlDbType.Int);  // ���Z�z�͈�3
                    SqlParameter paraAddPaymntAmbit4 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT4", SqlDbType.Int);  // ���Z�z�͈�4
                    SqlParameter paraAddPaymntAmbit5 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT5", SqlDbType.Int);  // ���Z�z�͈�5
                    SqlParameter paraAddPaymntAmbit6 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT6", SqlDbType.Int);  // ���Z�z�͈�6
                    SqlParameter paraAddPaymntAmbit7 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT7", SqlDbType.Int);  // ���Z�z�͈�7
                    SqlParameter paraAddPaymntAmbit8 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT8", SqlDbType.Int);  // ���Z�z�͈�8
                    SqlParameter paraAddPaymntAmbit9 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT9", SqlDbType.Int);  // ���Z�z�͈�9
                    SqlParameter paraAddPaymntAmbit10 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT10", SqlDbType.Int);  // ���Z�z�͈�10
                    SqlParameter paraAddPaymnt1 = sqlCommand.Parameters.Add("@ADDPAYMNT1", SqlDbType.Int);  // ���Z�z1
                    SqlParameter paraAddPaymnt2 = sqlCommand.Parameters.Add("@ADDPAYMNT2", SqlDbType.Int);  // ���Z�z2
                    SqlParameter paraAddPaymnt3 = sqlCommand.Parameters.Add("@ADDPAYMNT3", SqlDbType.Int);  // ���Z�z3
                    SqlParameter paraAddPaymnt4 = sqlCommand.Parameters.Add("@ADDPAYMNT4", SqlDbType.Int);  // ���Z�z4
                    SqlParameter paraAddPaymnt5 = sqlCommand.Parameters.Add("@ADDPAYMNT5", SqlDbType.Int);  // ���Z�z5
                    SqlParameter paraAddPaymnt6 = sqlCommand.Parameters.Add("@ADDPAYMNT6", SqlDbType.Int);  // ���Z�z6
                    SqlParameter paraAddPaymnt7 = sqlCommand.Parameters.Add("@ADDPAYMNT7", SqlDbType.Int);  // ���Z�z7
                    SqlParameter paraAddPaymnt8 = sqlCommand.Parameters.Add("@ADDPAYMNT8", SqlDbType.Int);  // ���Z�z8
                    SqlParameter paraAddPaymnt9 = sqlCommand.Parameters.Add("@ADDPAYMNT9", SqlDbType.Int);  // ���Z�z9
                    SqlParameter paraAddPaymnt10 = sqlCommand.Parameters.Add("@ADDPAYMNT10", SqlDbType.Int);  // ���Z�z10
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);  // �[�������敪
                    // 2010/04/12 Add >>>
                    SqlParameter paraMarketPriceQualityCd2 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD2", SqlDbType.Int);  // ���ꉿ�i�i���R�[�h�Q
                    SqlParameter paraMarketPriceQualityCd3 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD3", SqlDbType.Int);  // ���ꉿ�i�i���R�[�h�R
                    // 2010/04/12 Add <<<
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.CreateDateTime);  // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.UpdateDateTime);  // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);  // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmMrktPriStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.LogicalDeleteCode);  // �_���폜�敪
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);  // ���_�R�[�h
                    paraMarketPriceAreaCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAreaCd);  // ���ꉿ�i�n��R�[�h
                    paraMarketPriceQualityCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd);  // ���ꉿ�i�i���R�[�h
                    paraMarketPriceKindCd1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd1);  // ���ꉿ�i��ʃR�[�h�P
                    paraMarketPriceKindCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd2);  // ���ꉿ�i��ʃR�[�h�Q
                    paraMarketPriceKindCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd3);  // ���ꉿ�i��ʃR�[�h�R
                    paraMarketPriceAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAnswerDiv);  // ���ꉿ�i�񓚋敪
                    paraMarketPriceSalesRate.Value = SqlDataMediator.SqlSetDouble(scmMrktPriStWork.MarketPriceSalesRate);  // ���ꉿ�i������
                    paraAddPaymntAmbit1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit1);  // ���Z�z�͈�1
                    paraAddPaymntAmbit2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit2);  // ���Z�z�͈�2
                    paraAddPaymntAmbit3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit3);  // ���Z�z�͈�3
                    paraAddPaymntAmbit4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit4);  // ���Z�z�͈�4
                    paraAddPaymntAmbit5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit5);  // ���Z�z�͈�5
                    paraAddPaymntAmbit6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit6);  // ���Z�z�͈�6
                    paraAddPaymntAmbit7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit7);  // ���Z�z�͈�7
                    paraAddPaymntAmbit8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit8);  // ���Z�z�͈�8
                    paraAddPaymntAmbit9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit9);  // ���Z�z�͈�9
                    paraAddPaymntAmbit10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit10);  // ���Z�z�͈�10
                    paraAddPaymnt1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt1);  // ���Z�z1
                    paraAddPaymnt2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt2);  // ���Z�z2
                    paraAddPaymnt3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt3);  // ���Z�z3
                    paraAddPaymnt4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt4);  // ���Z�z4
                    paraAddPaymnt5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt5);  // ���Z�z5
                    paraAddPaymnt6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt6);  // ���Z�z6
                    paraAddPaymnt7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt7);  // ���Z�z7
                    paraAddPaymnt8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt8);  // ���Z�z8
                    paraAddPaymnt9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt9);  // ���Z�z9
                    paraAddPaymnt10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt10);  // ���Z�z10
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.FractionProcCd);  // �[�������敪
                    // 2010/04/12 Add >>>
                    paraMarketPriceQualityCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd2);  // ���ꉿ�i�i���R�[�h�Q
                    paraMarketPriceQualityCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd3);  // ���ꉿ�i�i���R�[�h�R
                    // 2010/04/12 Add <<<
                    #endregion

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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int LogicalDelete(ref object scmMrktPriStWork)
        {
            return LogicalDeleteSCMMrktPriSt(ref scmMrktPriStWork, 0);
        }

        /// <summary>
        /// �_���폜SCM���ꉿ�i�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜SCM���ꉿ�i�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int RevivalLogicalDelete(ref object scmMrktPriStWork)
        {
            return LogicalDeleteSCMMrktPriSt(ref scmMrktPriStWork, 1);
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private int LogicalDeleteSCMMrktPriSt(ref object scmMrktPriStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmMrktPriStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMMrktPriStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMMrktPriStDB.LogicalDeleteSCMMrktPriSt :" + procModestr);

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
        /// SCM���ꉿ�i�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int LogicalDeleteSCMMrktPriStProc(ref ArrayList scmMrktPriStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMMrktPriStProcProc(ref scmMrktPriStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private int LogicalDeleteSCMMrktPriStProcProc(ref ArrayList scmMrktPriStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmMrktPriStWorkList != null)
                {
                    for (int i = 0; i < scmMrktPriStWorkList.Count; i++)
                    {
                        SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[i] as SCMMrktPriStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMMRKTPRISTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmMrktPriStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMMRKTPRISTRF  SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
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
                            else if (logicalDelCd == 0) scmMrktPriStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else scmMrktPriStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmMrktPriStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmMrktPriStWork);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            scmMrktPriStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SCM���ꉿ�i�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
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

                status = DeleteSCMMrktPriStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Delete");
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
        /// SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">SCM���ꉿ�i�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        public int DeleteSCMMrktPriStProc(ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMMrktPriStProcProc(scmMrktPriStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">SCM���ꉿ�i�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private int DeleteSCMMrktPriStProcProc(ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmMrktPriStWorkList.Count; i++)
                {
                    SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[i] as SCMMrktPriStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMMRKTPRISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != scmMrktPriStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMMRKTPRISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

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
        /// <param name="scmMrktPriStWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMMrktPriStWork scmMrktPriStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(scmMrktPriStWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);
            }
            
            //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

		    return retstring;
		}
	    #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        private SCMMrktPriStWork CopyToSCMMrktPriStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMMrktPriStWork wkSCMMrktPriStWork = new SCMMrktPriStWork();

            #region �N���X�֊i�[
            wkSCMMrktPriStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkSCMMrktPriStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkSCMMrktPriStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkSCMMrktPriStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMMrktPriStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkSCMMrktPriStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkSCMMrktPriStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkSCMMrktPriStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkSCMMrktPriStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkSCMMrktPriStWork.MarketPriceAreaCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEAREACDRF"));  // ���ꉿ�i�n��R�[�h
            wkSCMMrktPriStWork.MarketPriceQualityCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEQUALITYCDRF"));  // ���ꉿ�i�i���R�[�h
            wkSCMMrktPriStWork.MarketPriceKindCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEKINDCD1RF"));  // ���ꉿ�i��ʃR�[�h�P
            wkSCMMrktPriStWork.MarketPriceKindCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEKINDCD2RF"));  // ���ꉿ�i��ʃR�[�h�Q
            wkSCMMrktPriStWork.MarketPriceKindCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEKINDCD3RF"));  // ���ꉿ�i��ʃR�[�h�R
            wkSCMMrktPriStWork.MarketPriceAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEANSWERDIVRF"));  // ���ꉿ�i�񓚋敪
            wkSCMMrktPriStWork.MarketPriceSalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MARKETPRICESALESRATERF"));  // ���ꉿ�i������
            wkSCMMrktPriStWork.AddPaymntAmbit1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT1RF"));  // ���Z�z�͈�1
            wkSCMMrktPriStWork.AddPaymntAmbit2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT2RF"));  // ���Z�z�͈�2
            wkSCMMrktPriStWork.AddPaymntAmbit3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT3RF"));  // ���Z�z�͈�3
            wkSCMMrktPriStWork.AddPaymntAmbit4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT4RF"));  // ���Z�z�͈�4
            wkSCMMrktPriStWork.AddPaymntAmbit5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT5RF"));  // ���Z�z�͈�5
            wkSCMMrktPriStWork.AddPaymntAmbit6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT6RF"));  // ���Z�z�͈�6
            wkSCMMrktPriStWork.AddPaymntAmbit7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT7RF"));  // ���Z�z�͈�7
            wkSCMMrktPriStWork.AddPaymntAmbit8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT8RF"));  // ���Z�z�͈�8
            wkSCMMrktPriStWork.AddPaymntAmbit9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT9RF"));  // ���Z�z�͈�9
            wkSCMMrktPriStWork.AddPaymntAmbit10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT10RF"));  // ���Z�z�͈�10
            wkSCMMrktPriStWork.AddPaymnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT1RF"));  // ���Z�z1
            wkSCMMrktPriStWork.AddPaymnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT2RF"));  // ���Z�z2
            wkSCMMrktPriStWork.AddPaymnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT3RF"));  // ���Z�z3
            wkSCMMrktPriStWork.AddPaymnt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT4RF"));  // ���Z�z4
            wkSCMMrktPriStWork.AddPaymnt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT5RF"));  // ���Z�z5
            wkSCMMrktPriStWork.AddPaymnt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT6RF"));  // ���Z�z6
            wkSCMMrktPriStWork.AddPaymnt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT7RF"));  // ���Z�z7
            wkSCMMrktPriStWork.AddPaymnt8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT8RF"));  // ���Z�z8
            wkSCMMrktPriStWork.AddPaymnt9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT9RF"));  // ���Z�z9
            wkSCMMrktPriStWork.AddPaymnt10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT10RF"));  // ���Z�z9
            wkSCMMrktPriStWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));  //�[�������敪
            // 2010/04/12 Add >>>
            wkSCMMrktPriStWork.MarketPriceQualityCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEQUALITYCD2RF"));  // ���ꉿ�i�i���R�[�h�Q
            wkSCMMrktPriStWork.MarketPriceQualityCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEQUALITYCD3RF"));  // ���ꉿ�i�i���R�[�h�R
            // 2010/04/12 Add <<<
            #endregion

            return wkSCMMrktPriStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMMrktPriStWork[] SCMMrktPriStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is SCMMrktPriStWork)
                    {
                        SCMMrktPriStWork wkSCMMrktPriStWork = paraobj as SCMMrktPriStWork;
                        if (wkSCMMrktPriStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMMrktPriStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMMrktPriStWorkArray = (SCMMrktPriStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMMrktPriStWork[]));
                        }
                        catch (Exception) { }
                        if (SCMMrktPriStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMMrktPriStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMMrktPriStWork wkSCMMrktPriStWork = (SCMMrktPriStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMMrktPriStWork));
                                if (wkSCMMrktPriStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMMrktPriStWork);
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
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
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
