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
    /// SCM�D��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�D��ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>Update Note: 2011.08.08 lingxiaoqing</br>
    /// <br>             SCM�D��ݒ�}�X�^�̎��f�[�^�����ύX</br>
    /// </remarks>
    [Serializable]
    public class SCMPriorStDB : RemoteDB, ISCMPriorStDB
    {
        /// <summary>
        /// SCM�D��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public SCMPriorStDB()
            :
            base("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.scmPriorStWork", "SCMPRIORSTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="scmPriorStWork">��������</param>
        /// <param name="parascmPriorStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Search(out object scmPriorStWork, object parascmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmPriorStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMPriorStProc(out scmPriorStWork, parascmPriorStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.Search");
                scmPriorStWork = new ArrayList();
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
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objscmPriorStWork">��������</param>
        /// <param name="parascmPriorStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchSCMPriorStProc(out object objscmPriorStWork, object parascmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMPriorStWork scmPriorStWork = null; 

            ArrayList scmPriorStWorkList = parascmPriorStWork as ArrayList;
            if (scmPriorStWorkList == null)
            {
                scmPriorStWork = parascmPriorStWork as SCMPriorStWork;
            }
            else
            {
                if (scmPriorStWorkList.Count > 0)
                    scmPriorStWork = scmPriorStWorkList[0] as SCMPriorStWork;
            }

            int status = SearchSCMPriorStProc(out scmPriorStWorkList, scmPriorStWork, readMode, logicalMode, ref sqlConnection);
            objscmPriorStWork = scmPriorStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">��������</param>
        /// <param name="scmPriorStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchSCMPriorStProc(out ArrayList scmPriorStWorkList, SCMPriorStWork scmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMPriorStProcProc(out scmPriorStWorkList, scmPriorStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">��������</param>
        /// <param name="scmPriorStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int SearchSCMPriorStProcProc(out ArrayList scmPriorStWorkList, SCMPriorStWork scmPriorStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                selectTxt += "         , CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                selectTxt += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRIORSTRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmPriorStWork, logicalMode);
                sqlCommand.CommandText += "  ORDER BY SECTIONCODERF ASC,CUSTOMERCODERF ASC";  //ADD BY lingxiaoqing �Ή�ID=PCCUOE-0071�I�[
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToscmPriorStWorkFromReader(ref myReader));

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

            scmPriorStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">scmPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();

                // XML�̓ǂݍ���
                scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                if (scmPriorStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmPriorStWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(scmPriorStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.Read");
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
        // ADD 2011/08/10 ------------<<<<<<<<
        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(PCCUO��p)
        /// </summary>
        /// <param name="parabyte">scmPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        public int ReadPCCUOE(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();

                // XML�̓ǂݍ���
                scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                if (scmPriorStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcPCCUOE(ref scmPriorStWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(scmPriorStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.ReadPCCUOE");
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
        // ADD 2011/08/10 ------------>>>>>>>>

        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int ReadProc(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref scmPriorStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int ReadProcProc(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                selectTxt += "         , CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                selectTxt += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRIORSTRF " + Environment.NewLine;
                //------------DELETE BY lingxiaoqing 2011.08.08 -------------->>>>>>>>>>>>>>>>
                //selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                //selectTxt += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                //------------DELETE BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<<<<


                //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>>>
                if (scmPriorStWork.CustomerCode == 0)
                {
                    //���_�R�[�h
                    selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    selectTxt += "         AND SECTIONCODERF IN (" + scmPriorStWork.SectionCode+",00)"+ Environment.NewLine;
                    selectTxt += "         AND PRIORAPPLIDIVRF IN (" + scmPriorStWork.PriorAppliDiv +",0)"+ Environment.NewLine;
                }
                else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                {
                    //���Ӑ�R�[�h
                    selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    selectTxt += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                    selectTxt += "         AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV " + Environment.NewLine;
                }
                selectTxt += "         ORDER BY PRIORAPPLIDIVRF DESC, SECTIONCODERF DESC" + Environment.NewLine;
                //------------ADD BY lingxiaoqing ---------------------<<<<<<<<<<<<<<<<<
                #endregion�@

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing on 2011.08.08 for ���Ӑ�R�[�h
                    SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing on 2011.08.08 for �D��K�p�敪


                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                    findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode); //ADD BY lingxiaoqing on  2011.08.08 for ���Ӑ�R�[�h
                    findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing on 2011.08.08 for �D��K�p�敪
                    
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmPriorStWork = CopyToscmPriorStWorkFromReader(ref myReader);
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

        // ADD 2011.08.10 ------------------<<<<<<<<<
        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(PCCUOE��p)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(PCCUOE��p)</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        public int ReadProcPCCUOE(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProcPCCUOE(ref scmPriorStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(PCCUOE��p)
        /// </summary>
        /// <param name="scmPriorStWork">scmPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�(PCCUOE��p)</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        private int ReadProcProcPCCUOE(ref SCMPriorStWork scmPriorStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         , CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                selectTxt += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                selectTxt += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
                selectTxt += "  FROM SCMPRIORSTRF " + Environment.NewLine;

                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                //���_�R�[�h
                selectTxt += "         AND  SECTIONCODERF IN (" + scmPriorStWork.SectionCode + ",00)" + Environment.NewLine;
                //���Ӑ�R�[�h
                selectTxt += "         AND  CUSTOMERCODERF IN (" + scmPriorStWork.CustomerCode + ",0)" + Environment.NewLine;
                selectTxt += "         AND  PRIORAPPLIDIVRF IN (" + scmPriorStWork.PriorAppliDiv + ",0)" + Environment.NewLine;
                selectTxt += "         AND LOGICALDELETECODERF = 0 ";
                selectTxt += "         ORDER BY CUSTOMERCODERF DESC, SECTIONCODERF DESC, PRIORAPPLIDIVRF DESC" + Environment.NewLine;
                #endregion

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);


                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                    findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode); 
                    findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmPriorStWork = CopyToscmPriorStWorkFromReader(ref myReader);
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
        // ADD 2011.08.10 ------------------>>>>>>>>>>
        #endregion

        #region [Write]
        /// <summary>
        /// SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Write(ref object scmPriorStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmPriorStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSCMPriorStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMPriorStWork paraWork = paraList[0] as SCMPriorStWork;
                
                //�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                //-----------DELETE BY lingxiaoqing on 2011.08.08 for #Redmine25643------------>>>>>>>>>>>>
                //if (paraWork.SectionCode == _allSecCode)
                //{
                //    UpdateAllSecSCMPriorSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                //}
                //-----------DELETE BY lingxiaoqing on 2011.08.08 for #Redmine25643------------<<<<<<<<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                scmPriorStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMPriorStDB.Write(ref object scmPriorStWork)");
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
        /// SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int WriteSCMPriorStProc(ref ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMPriorStProcProc(ref scmPriorStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int WriteSCMPriorStProcProc(ref ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPriorStWorkList != null)
                {
                    foreach (SCMPriorStWork scmPriorStWork in scmPriorStWorkList)
                    {
                        //Select�R�}���h�̐���
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); // DELETE BY lingxiaoqing for �敪���_�R�[�h�Ɠ��Ӑ�R�[�h
                        
                        //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                        if (scmPriorStWork.CustomerCode == 0)
                        {
                            //���_�R�[�h
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND  CUSTOMERCODERF = 0 AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                        {
                            //���Ӑ�R�[�h
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        //------------ADD BY lingxiaoqing 2011.08.08---------<<<<<<<<<<

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing for ���Ӑ�R�[�h
                        SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing for �D��K�p�敪

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                        findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing  for ���Ӑ�R�[�h
                        findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing for �D��K�p�敪                       
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmPriorStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (scmPriorStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region UPDATE��
                            string sqlText = string.Empty;

                            sqlText += " UPDATE SCMPRIORSTRF SET  " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                           // sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;   //DELETE BY lingxiaoqing 2011.08.08
                            //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //���_�R�[�h
                                sqlText += "         ,SECTIONCODERF= @SECTIONCODE" + Environment.NewLine;
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //���Ӑ�R�[�h
                                sqlText += "         , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            }
                            sqlText += "  , PRIORAPPLIDIVRF = @PRIORAPPLIDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTPUREDIVRF = @SELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTSTCKDIVRF = @SELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTCAMPDIVRF = @SELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "  , SELTGTPRICDIV1RF = @SELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "  , SELTGTPRICDIV2RF = @SELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "  , SELTGTPRICDIV3RF = @SELTGTPRICDIV3 " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPUREDIVRF = @UNSELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "  , UNSELTGTSTCKDIVRF = @UNSELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "  , UNSELTGTCAMPDIVRF = @UNSELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPRICDIV1RF = @UNSELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPRICDIV2RF = @UNSELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "  , UNSELTGTPRICDIV3RF = @UNSELTGTPRICDIV3 " + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                            sqlText += "  , PRIORITYSETTINGCD1RF = @PRIORITYSETTINGCD1 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM1RF = @PRIORITYSETTINGNM1 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD2RF = @PRIORITYSETTINGCD2 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM2RF = @PRIORITYSETTINGNM2 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD3RF = @PRIORITYSETTINGCD3 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM3RF = @PRIORITYSETTINGNM3 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD4RF = @PRIORITYSETTINGCD4 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM4RF = @PRIORITYSETTINGNM4 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGCD5RF = @PRIORITYSETTINGCD5 " + Environment.NewLine;
                            sqlText += "  , PRIORITYSETTINGNM5RF = @PRIORITYSETTINGNM5 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD1RF = @PRIORPRICESETCD1 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM1RF = @PRIORPRICESETNM1 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD2RF = @PRIORPRICESETCD2 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM2RF = @PRIORPRICESETNM2 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD3RF = @PRIORPRICESETCD3 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM3RF = @PRIORPRICESETNM3 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD4RF = @PRIORPRICESETCD4 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM4RF = @PRIORPRICESETNM4 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETCD5RF = @PRIORPRICESETCD5 " + Environment.NewLine;
                            sqlText += "  , PRIORPRICESETNM5RF = @PRIORPRICESETNM5 " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            //sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;  // DELETE BY lingxiaoqing for �敪���_�R�[�h�Ɠ��Ӑ�R�[�h
                            // ---------ADD BY lingxiaoqing 2011.08.08--------->>>>>>>>>>
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //���_�R�[�h
                                sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE  AND CUSTOMERCODERF = 0 " + Environment.NewLine;
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //���Ӑ�R�[�h
                                sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            }
                            sqlText += "             AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV" + Environment.NewLine;
                            // ---------ADD BY lingxiaoqing ----------<<<<<<<<<<<
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode); //ADD BY lingxiaoqing for ���Ӑ�R�[�h
                            findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing for �D��K�p�敪

                            //---------ADD BY lingxiaoqing 2011.08.08------------>>>>>>>>>>>>
                            SqlParameter paraSectionCode = null;
                            SqlParameter paraCustomerCode = null;
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //���_�R�[�h
                                paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //���Ӑ�R�[�h
                                paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);  //���Ӑ�R�[�h
                            }
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //���_�R�[�h
                                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //���Ӑ�R�[�h
                                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//���Ӑ�R�[�h
                            }
                            //---------ADD BY lingxiaoqing 2011.08.08------------<<<<<<<<<<<<
                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPriorStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                           
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (scmPriorStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region INSERT��
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMPRIORSTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                            sqlText += "         , CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "         , PRIORAPPLIDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTPUREDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTSTCKDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTCAMPDIVRF" + Environment.NewLine;
                            sqlText += "         , SELTGTPRICDIV1RF" + Environment.NewLine;
                            sqlText += "         , SELTGTPRICDIV2RF" + Environment.NewLine;
                            sqlText += "         , SELTGTPRICDIV3RF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPUREDIVRF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTSTCKDIVRF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTCAMPDIVRF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPRICDIV1RF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPRICDIV2RF" + Environment.NewLine;
                            sqlText += "         , UNSELTGTPRICDIV3RF" + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                            sqlText += "         ,PRIORITYSETTINGCD1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGCD5RF " + Environment.NewLine;
                            sqlText += "         ,PRIORITYSETTINGNM5RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM1RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM2RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM3RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM4RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETCD5RF " + Environment.NewLine;
                            sqlText += "         ,PRIORPRICESETNM5RF " + Environment.NewLine;
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
                            //-------ADD BY  lingxiaoqing 2011.08.08----------->>>>>>>>>>
                            sqlText += "         , @CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         , @PRIORAPPLIDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "         , @SELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "         , @SELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "         , @SELTGTPRICDIV3 " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPUREDIV " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTSTCKDIV " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTCAMPDIV " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPRICDIV1 " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPRICDIV2 " + Environment.NewLine;
                            sqlText += "         , @UNSELTGTPRICDIV3 " + Environment.NewLine;
                            //-------ADD BY  lingxiaoqing 2011.08.08-----------<<<<<<<<<<
                            sqlText += "         ,@PRIORITYSETTINGCD1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGCD5 " + Environment.NewLine;
                            sqlText += "         ,@PRIORITYSETTINGNM5 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM1 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM2 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM3 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM4 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETCD5 " + Environment.NewLine;
                            sqlText += "         ,@PRIORPRICESETNM5 " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>>>
                            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);  //���Ӑ�R�[�h
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);  // ���_�R�[�h
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//���Ӑ�R�[�h
                            //---------ADD BY lingxiaoqing 2011.08.08------------<<<<<<<<<<<<
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPriorStWork;
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
                        //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h DELETE BY lingxiaoqing 2011.08.08
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>                                            
                        SqlParameter paraPriorAppliDiv = sqlCommand.Parameters.Add("@PRIORAPPLIDIV", SqlDbType.NChar); //�D��K�p�敪
                        SqlParameter paraSelTgtPureDiv = sqlCommand.Parameters.Add("@SELTGTPUREDIV", SqlDbType.NChar);//�I�����Ώۏ��D�敪    
                        SqlParameter paraSelTgtStckDiv = sqlCommand.Parameters.Add("@SELTGTSTCKDIV", SqlDbType.NChar);//�I�����Ώۍ݌ɋ敪
                        SqlParameter paraSelTgtCampDiv = sqlCommand.Parameters.Add("@SELTGTCAMPDIV", SqlDbType.NChar);//�I�����ΏۃL�����y�[���敪
                        SqlParameter paraSelTgtPricDiv1 = sqlCommand.Parameters.Add("@SELTGTPRICDIV1", SqlDbType.NChar);//�I�����Ώۉ��i�敪�P    
                        SqlParameter paraSelTgtPricDiv2 = sqlCommand.Parameters.Add("@SELTGTPRICDIV2", SqlDbType.NChar);//�I�����Ώۉ��i�敪�Q
                        SqlParameter paraSelTgtPricDiv3 = sqlCommand.Parameters.Add("@SELTGTPRICDIV3", SqlDbType.NChar);//�I�����Ώۉ��i�敪 3
                        SqlParameter paraUnSelTgtPureDiv = sqlCommand.Parameters.Add("@UNSELTGTPUREDIV", SqlDbType.NChar);//��I�����Ώۏ��D�敪
                        SqlParameter paraUnSelTgtStckDiv = sqlCommand.Parameters.Add("@UNSELTGTSTCKDIV", SqlDbType.NChar);//��I�����Ώۍ݌ɋ敪
                        SqlParameter paraUnSelTgtCampDiv = sqlCommand.Parameters.Add("@UNSELTGTCAMPDIV", SqlDbType.NChar);//��I�����ΏۃL�����y�[���敪
                        SqlParameter paraUnSelTgtPricDiv1 = sqlCommand.Parameters.Add("@UNSELTGTPRICDIV1", SqlDbType.NChar);//��I�����Ώۉ��i�敪�P
                        SqlParameter paraUnSelTgtPricDiv2 = sqlCommand.Parameters.Add("@UNSELTGTPRICDIV2", SqlDbType.NChar);//��I�����Ώۉ��i�敪�Q
                        SqlParameter paraUnSelTgtPricDiv3 = sqlCommand.Parameters.Add("@UNSELTGTPRICDIV3", SqlDbType.NChar);//��I�����Ώۉ��i�敪 3
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        SqlParameter paraPrioritySettingCd1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD1", SqlDbType.Int);  // �D��ݒ�R�[�h�P
                        SqlParameter paraPrioritySettingNm1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM1", SqlDbType.NVarChar);  // �D��ݒ薼�̂P
                        SqlParameter paraPrioritySettingCd2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD2", SqlDbType.Int);  // �D��ݒ�R�[�h�Q
                        SqlParameter paraPrioritySettingNm2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM2", SqlDbType.NVarChar);  // �D��ݒ薼�̂Q
                        SqlParameter paraPrioritySettingCd3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD3", SqlDbType.Int);  // �D��ݒ�R�[�h�R
                        SqlParameter paraPrioritySettingNm3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM3", SqlDbType.NVarChar);  // �D��ݒ薼�̂R
                        SqlParameter paraPrioritySettingCd4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD4", SqlDbType.Int);  // �D��ݒ�R�[�h�S
                        SqlParameter paraPrioritySettingNm4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM4", SqlDbType.NVarChar);  // �D��ݒ薼�̂S
                        SqlParameter paraPrioritySettingCd5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD5", SqlDbType.Int);  // �D��ݒ�R�[�h�T
                        SqlParameter paraPrioritySettingNm5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM5", SqlDbType.NVarChar);  // �D��ݒ薼�̂T
                        SqlParameter paraPriorPriceSetCd1 = sqlCommand.Parameters.Add("@PRIORPRICESETCD1", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�P
                        SqlParameter paraPriorPriceSetNm1 = sqlCommand.Parameters.Add("@PRIORPRICESETNM1", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂P
                        SqlParameter paraPriorPriceSetCd2 = sqlCommand.Parameters.Add("@PRIORPRICESETCD2", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�Q
                        SqlParameter paraPriorPriceSetNm2 = sqlCommand.Parameters.Add("@PRIORPRICESETNM2", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂Q
                        SqlParameter paraPriorPriceSetCd3 = sqlCommand.Parameters.Add("@PRIORPRICESETCD3", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�R
                        SqlParameter paraPriorPriceSetNm3 = sqlCommand.Parameters.Add("@PRIORPRICESETNM3", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂R
                        SqlParameter paraPriorPriceSetCd4 = sqlCommand.Parameters.Add("@PRIORPRICESETCD4", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�S
                        SqlParameter paraPriorPriceSetNm4 = sqlCommand.Parameters.Add("@PRIORPRICESETNM4", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂S
                        SqlParameter paraPriorPriceSetCd5 = sqlCommand.Parameters.Add("@PRIORPRICESETCD5", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�T
                        SqlParameter paraPriorPriceSetNm5 = sqlCommand.Parameters.Add("@PRIORPRICESETNM5", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂T
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPriorStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.LogicalDeleteCode);  // �_���폜�敪
                        //paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);  // ���_�R�[�h DELETE BY lingxiaiqing 2011.08.08
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>                   
                        paraPriorAppliDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//�D��K�p�敪
                        paraSelTgtPureDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPureDiv);//�I�����Ώۏ��D�敪    
                        paraSelTgtStckDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtStckDiv);//�I�����Ώۍ݌ɋ敪
                        paraSelTgtCampDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtCampDiv);//�I�����ΏۃL�����y�[���敪
                        paraSelTgtPricDiv1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPricDiv1); //�I�����Ώۉ��i�敪�P    
                        paraSelTgtPricDiv2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPricDiv2);//�I�����Ώۉ��i�敪�Q
                        paraSelTgtPricDiv3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.SelTgtPricDiv3);//�I�����Ώۉ��i�敪 3
                        paraUnSelTgtPureDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPureDiv);//��I�����Ώۏ��D�敪
                        paraUnSelTgtStckDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtStckDiv);//��I�����Ώۍ݌ɋ敪
                        paraUnSelTgtCampDiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtCampDiv);//��I�����ΏۃL�����y�[���敪
                        paraUnSelTgtPricDiv1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPricDiv1);//��I�����Ώۉ��i�敪�P
                        paraUnSelTgtPricDiv2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPricDiv2);//��I�����Ώۉ��i�敪�Q
                        paraUnSelTgtPricDiv3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.UnSelTgtPricDiv3);//��I�����Ώۉ��i�敪 3
                        //--------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        paraPrioritySettingCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd1);  // �D��ݒ�R�[�h�P
                        paraPrioritySettingNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm1);  // �D��ݒ薼�̂P
                        paraPrioritySettingCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd2);  // �D��ݒ�R�[�h�Q
                        paraPrioritySettingNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm2);  // �D��ݒ薼�̂Q
                        paraPrioritySettingCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd3);  // �D��ݒ�R�[�h�R
                        paraPrioritySettingNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm3);  // �D��ݒ薼�̂R
                        paraPrioritySettingCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd4);  // �D��ݒ�R�[�h�S
                        paraPrioritySettingNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm4);  // �D��ݒ薼�̂S
                        paraPrioritySettingCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd5);  // �D��ݒ�R�[�h�T
                        paraPrioritySettingNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm5);  // �D��ݒ薼�̂T
                        paraPriorPriceSetCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd1);  // �D�承�i�ݒ�R�[�h�P
                        paraPriorPriceSetNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm1);  // �D�承�i�ݒ薼�̂P
                        paraPriorPriceSetCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd2);  // �D�承�i�ݒ�R�[�h�Q
                        paraPriorPriceSetNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm2);  // �D�承�i�ݒ薼�̂Q
                        paraPriorPriceSetCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd3);  // �D�承�i�ݒ�R�[�h�R
                        paraPriorPriceSetNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm3);  // �D�承�i�ݒ薼�̂R
                        paraPriorPriceSetCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd4);  // �D�承�i�ݒ�R�[�h�S
                        paraPriorPriceSetNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm4);  // �D�承�i�ݒ薼�̂S
                        paraPriorPriceSetCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd5);  // �D�承�i�ݒ�R�[�h�T
                        paraPriorPriceSetNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm5);  // �D�承�i�ݒ薼�̂T
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPriorStWork);
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

            scmPriorStWorkList = al;

            return status;
        }

        /// <summary>
        /// �S�Ћ��ʍ��ڂ��X�V����
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int UpdateAllSecSCMPriorSt(ref ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmPriorStWorkList != null)
                {
                    SCMPriorStWork scmPriorStWork = scmPriorStWorkList[0] as SCMPriorStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region �X�V����SQL������
                    string sqlText = string.Empty;
                    sqlText += " UPDATE SCMPRIORSTRF SET  " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD1RF = @PRIORITYSETTINGCD1 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM1RF = @PRIORITYSETTINGNM1 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD2RF = @PRIORITYSETTINGCD2 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM2RF = @PRIORITYSETTINGNM2 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD3RF = @PRIORITYSETTINGCD3 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM3RF = @PRIORITYSETTINGNM3 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD4RF = @PRIORITYSETTINGCD4 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM4RF = @PRIORITYSETTINGNM4 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGCD5RF = @PRIORITYSETTINGCD5 " + Environment.NewLine;
                    sqlText += "  , PRIORITYSETTINGNM5RF = @PRIORITYSETTINGNM5 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD1RF = @PRIORPRICESETCD1 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM1RF = @PRIORPRICESETNM1 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD2RF = @PRIORPRICESETCD2 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM2RF = @PRIORPRICESETNM2 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD3RF = @PRIORPRICESETCD3 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM3RF = @PRIORPRICESETNM3 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD4RF = @PRIORPRICESETCD4 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM4RF = @PRIORPRICESETNM4 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETCD5RF = @PRIORPRICESETCD5 " + Environment.NewLine;
                    sqlText += "  , PRIORPRICESETNM5RF = @PRIORPRICESETNM5 " + Environment.NewLine;
                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmPriorStWork;
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
                    SqlParameter paraPrioritySettingCd1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD1", SqlDbType.Int);  // �D��ݒ�R�[�h�P
                    SqlParameter paraPrioritySettingNm1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM1", SqlDbType.NVarChar);  // �D��ݒ薼�̂P
                    SqlParameter paraPrioritySettingCd2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD2", SqlDbType.Int);  // �D��ݒ�R�[�h�Q
                    SqlParameter paraPrioritySettingNm2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM2", SqlDbType.NVarChar);  // �D��ݒ薼�̂Q
                    SqlParameter paraPrioritySettingCd3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD3", SqlDbType.Int);  // �D��ݒ�R�[�h�R
                    SqlParameter paraPrioritySettingNm3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM3", SqlDbType.NVarChar);  // �D��ݒ薼�̂R
                    SqlParameter paraPrioritySettingCd4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD4", SqlDbType.Int);  // �D��ݒ�R�[�h�S
                    SqlParameter paraPrioritySettingNm4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM4", SqlDbType.NVarChar);  // �D��ݒ薼�̂S
                    SqlParameter paraPrioritySettingCd5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD5", SqlDbType.Int);  // �D��ݒ�R�[�h�T
                    SqlParameter paraPrioritySettingNm5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGNM5", SqlDbType.NVarChar);  // �D��ݒ薼�̂T
                    SqlParameter paraPriorPriceSetCd1 = sqlCommand.Parameters.Add("@PRIORPRICESETCD1", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�P
                    SqlParameter paraPriorPriceSetNm1 = sqlCommand.Parameters.Add("@PRIORPRICESETNM1", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂P
                    SqlParameter paraPriorPriceSetCd2 = sqlCommand.Parameters.Add("@PRIORPRICESETCD2", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�Q
                    SqlParameter paraPriorPriceSetNm2 = sqlCommand.Parameters.Add("@PRIORPRICESETNM2", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂Q
                    SqlParameter paraPriorPriceSetCd3 = sqlCommand.Parameters.Add("@PRIORPRICESETCD3", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�R
                    SqlParameter paraPriorPriceSetNm3 = sqlCommand.Parameters.Add("@PRIORPRICESETNM3", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂R
                    SqlParameter paraPriorPriceSetCd4 = sqlCommand.Parameters.Add("@PRIORPRICESETCD4", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�S
                    SqlParameter paraPriorPriceSetNm4 = sqlCommand.Parameters.Add("@PRIORPRICESETNM4", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂S
                    SqlParameter paraPriorPriceSetCd5 = sqlCommand.Parameters.Add("@PRIORPRICESETCD5", SqlDbType.Int);  // �D�承�i�ݒ�R�[�h�T
                    SqlParameter paraPriorPriceSetNm5 = sqlCommand.Parameters.Add("@PRIORPRICESETNM5", SqlDbType.NVarChar);  // �D�承�i�ݒ薼�̂T
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.CreateDateTime);  // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.UpdateDateTime);  // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);  // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmPriorStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.LogicalDeleteCode);  // �_���폜�敪
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);  // ���_�R�[�h
                    paraPrioritySettingCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd1);  // �D��ݒ�R�[�h�P
                    paraPrioritySettingNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm1);  // �D��ݒ薼�̂P
                    paraPrioritySettingCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd2);  // �D��ݒ�R�[�h�Q
                    paraPrioritySettingNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm2);  // �D��ݒ薼�̂Q
                    paraPrioritySettingCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd3);  // �D��ݒ�R�[�h�R
                    paraPrioritySettingNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm3);  // �D��ݒ薼�̂R
                    paraPrioritySettingCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd4);  // �D��ݒ�R�[�h�S
                    paraPrioritySettingNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm4);  // �D��ݒ薼�̂S
                    paraPrioritySettingCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PrioritySettingCd5);  // �D��ݒ�R�[�h�T
                    paraPrioritySettingNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PrioritySettingNm5);  // �D��ݒ薼�̂T
                    paraPriorPriceSetCd1.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd1);  // �D�承�i�ݒ�R�[�h�P
                    paraPriorPriceSetNm1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm1);  // �D�承�i�ݒ薼�̂P
                    paraPriorPriceSetCd2.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd2);  // �D�承�i�ݒ�R�[�h�Q
                    paraPriorPriceSetNm2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm2);  // �D�承�i�ݒ薼�̂Q
                    paraPriorPriceSetCd3.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd3);  // �D�承�i�ݒ�R�[�h�R
                    paraPriorPriceSetNm3.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm3);  // �D�承�i�ݒ薼�̂R
                    paraPriorPriceSetCd4.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd4);  // �D�承�i�ݒ�R�[�h�S
                    paraPriorPriceSetNm4.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm4);  // �D�承�i�ݒ薼�̂S
                    paraPriorPriceSetCd5.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorPriceSetCd5);  // �D�承�i�ݒ�R�[�h�T
                    paraPriorPriceSetNm5.Value = SqlDataMediator.SqlSetString(scmPriorStWork.PriorPriceSetNm5);  // �D�承�i�ݒ薼�̂T
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
        /// SCM�D��ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDelete(ref object scmPriorStWork)
        {
            return LogicalDeleteSCMPriorSt(ref scmPriorStWork, 0);
        }

        /// <summary>
        /// �_���폜SCM�D��ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜SCM�D��ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int RevivalLogicalDelete(ref object scmPriorStWork)
        {
            return LogicalDeleteSCMPriorSt(ref scmPriorStWork, 1);
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeleteSCMPriorSt(ref object scmPriorStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmPriorStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMPriorStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMPriorStDB.LogicalDeleteSCMPriorSt :" + procModestr);

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
        /// SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDeleteSCMPriorStProc(ref ArrayList scmPriorStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMPriorStProcProc(ref scmPriorStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeleteSCMPriorStProcProc(ref ArrayList scmPriorStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmPriorStWorkList != null)
                {
                    foreach (SCMPriorStWork scmPriorStWork in scmPriorStWorkList)
                    {
                        //Select�R�}���h�̐���
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); //DELETE BY lingxiaoqing on 2011.08.08 for �敪���_�R�[�h�Ɠ��Ӑ�R�[�h
                        //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                        if (scmPriorStWork.CustomerCode == 0)
                        {
                            //���_�R�[�h
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                        {
                            //���Ӑ�R�[�h
                            sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV", sqlConnection, sqlTransaction);
                        }
                        //------------ADD BY lingxiaoqing -----------------<<<<<<<<<<<<<

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing for ���Ӑ�R�[�h
                        SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing for �D��K�p�敪


                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                        findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing   for  ���Ӑ�R�[�h
                        findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing  for �D��K�p�敪

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmPriorStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            //----------DELETE BY lingxiaoqing 2011.08.08 ------------------>>>>>>>>>>>>
                            //sqlCommand.CommandText = "UPDATE SCMPRIORSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEY�R�}���h���Đݒ�
                            //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            //----------DELETE BY lingxiaoqing 2011.08.08 ------------------<<<<<<<<<<<<<
                            //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                            if (scmPriorStWork.CustomerCode == 0)
                            {
                                //���_�R�[�h
                                sqlCommand.CommandText = "UPDATE SCMPRIORSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                                //KEY�R�}���h���Đݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                                findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing
                            }
                            else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                            {
                                //���Ӑ�R�[�h
                                sqlCommand.CommandText = "UPDATE SCMPRIORSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                                //KEY�R�}���h���Đݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                                findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing
                                findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing
                            }
                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmPriorStWork;
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
                            else if (logicalDelCd == 0) scmPriorStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else scmPriorStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmPriorStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmPriorStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmPriorStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmPriorStWork);
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

            scmPriorStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM�D��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SCM�D��ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
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

                status = DeleteSCMPriorStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMPriorStDB.Delete");
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
        /// SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">SCM�D��ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int DeleteSCMPriorStProc(ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMPriorStProcProc(scmPriorStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmPriorStWorkList">SCM�D��ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int DeleteSCMPriorStProcProc(ArrayList scmPriorStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                foreach(SCMPriorStWork scmPriorStWork in scmPriorStWorkList)
                {
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); //DELETE BY lingxiaoqing on 2011.08.08 for �敪���_�R�[�h�Ɠ��Ӑ�R�[�h
                    //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                    if (scmPriorStWork.CustomerCode == 0)
                    {
                        //���_�R�[�h
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV ", sqlConnection, sqlTransaction);
                    }
                    else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                    {
                        //���Ӑ�R�[�h
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV ", sqlConnection, sqlTransaction);

                    }
                    //------------ADD BY lingxiaoqing --------------->>>>>>>>>>
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomernCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); //ADD BY lingxiaoqing on 2011.08.08 for ���Ӑ�R�[�h
                    SqlParameter findParaPriorapplidiv = sqlCommand.Parameters.Add("@FINDPRIORAPPLIDIV", SqlDbType.Int);//ADD BY lingxiaoqing on 2011.08.08 for �D��K�p�敪

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                    findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);//ADD BY lingxiaoqing on 2011.08.08 for ���Ӑ�R�[�h
                    findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);//ADD BY lingxiaoqing on 2011.08.08 for �D��K�p�敪
                    
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != scmPriorStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        //-----------DELETE BY lingxiaoqing  2011.08.08----------->>>>>>>>
                        //sqlCommand.CommandText = "DELETE FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEY�R�}���h���Đݒ�
                        //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                        //-----------DELETE BY lingxiaoqing  2011.08.08-----------<<<<<<<< 
                        //------------ADD BY lingxiaoqing 2011.08.08 --------->>>>>>>>>>
                        if (scmPriorStWork.CustomerCode == 0)
                        {
                            //���_�R�[�h
                            sqlCommand.CommandText = "DELETE FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
                            findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);
                        }
                        else if (scmPriorStWork.SectionCode.Trim().Equals("00"))
                        {
                            //���Ӑ�R�[�h
                            sqlCommand.CommandText = "DELETE FROM SCMPRIORSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRIORAPPLIDIVRF =@FINDPRIORAPPLIDIV";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);
                            findParaCustomernCode.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.CustomerCode);
                            findParaPriorapplidiv.Value = SqlDataMediator.SqlSetInt32(scmPriorStWork.PriorAppliDiv);
                        }
                        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<
                       
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
        /// <param name="scmPriorStWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMPriorStWork scmPriorStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(scmPriorStWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmPriorStWork.SectionCode);
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
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private SCMPriorStWork CopyToscmPriorStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMPriorStWork wkscmPriorStWork = new SCMPriorStWork();

            #region �N���X�֊i�[
            wkscmPriorStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkscmPriorStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkscmPriorStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkscmPriorStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkscmPriorStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkscmPriorStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkscmPriorStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkscmPriorStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkscmPriorStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkscmPriorStWork.PrioritySettingCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD1RF"));  // �D��ݒ�R�[�h�P
            wkscmPriorStWork.PrioritySettingNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM1RF"));  // �D��ݒ薼�̂P
            wkscmPriorStWork.PrioritySettingCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD2RF"));  // �D��ݒ�R�[�h�Q
            wkscmPriorStWork.PrioritySettingNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM2RF"));  // �D��ݒ薼�̂Q
            wkscmPriorStWork.PrioritySettingCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD3RF"));  // �D��ݒ�R�[�h�R
            wkscmPriorStWork.PrioritySettingNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM3RF"));  // �D��ݒ薼�̂R
            wkscmPriorStWork.PrioritySettingCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD4RF"));  // �D��ݒ�R�[�h�S
            wkscmPriorStWork.PrioritySettingNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM4RF"));  // �D��ݒ薼�̂S
            wkscmPriorStWork.PrioritySettingCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD5RF"));  // �D��ݒ�R�[�h�T
            wkscmPriorStWork.PrioritySettingNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORITYSETTINGNM5RF"));  // �D��ݒ薼�̂T
            wkscmPriorStWork.PriorPriceSetCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD1RF"));  // �D�承�i�ݒ�R�[�h�P
            wkscmPriorStWork.PriorPriceSetNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM1RF"));  // �D�承�i�ݒ薼�̂P
            wkscmPriorStWork.PriorPriceSetCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD2RF"));  // �D�承�i�ݒ�R�[�h�Q
            wkscmPriorStWork.PriorPriceSetNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM2RF"));  // �D�承�i�ݒ薼�̂Q
            wkscmPriorStWork.PriorPriceSetCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD3RF"));  // �D�承�i�ݒ�R�[�h�R
            wkscmPriorStWork.PriorPriceSetNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM3RF"));  // �D�承�i�ݒ薼�̂R
            wkscmPriorStWork.PriorPriceSetCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD4RF"));  // �D�承�i�ݒ�R�[�h�S
            wkscmPriorStWork.PriorPriceSetNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM4RF"));  // �D�承�i�ݒ薼�̂S
            wkscmPriorStWork.PriorPriceSetCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORPRICESETCD5RF"));  // �D�承�i�ݒ�R�[�h�T
            wkscmPriorStWork.PriorPriceSetNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIORPRICESETNM5RF"));  // �D�承�i�ݒ薼�̂T
            //-------------ADD BY lingxiaoqing  2011.08.08-------------->>>>>>>>>>>>>>>>>>>
            wkscmPriorStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));//���Ӑ�R�[�h
            wkscmPriorStWork.PriorAppliDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORAPPLIDIVRF"));//�D��K�p�敪
            wkscmPriorStWork.SelTgtPureDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPUREDIVRF"));//�I�����Ώۏ��D�敪 
            wkscmPriorStWork.SelTgtStckDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTSTCKDIVRF"));//�I�����Ώۍ݌ɋ敪
            wkscmPriorStWork.SelTgtCampDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTCAMPDIVRF"));//�I�����ΏۃL�����y�[���敪
            wkscmPriorStWork.UnSelTgtPureDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPUREDIVRF"));//��I�����Ώۏ��D�敪   
            wkscmPriorStWork.UnSelTgtStckDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTSTCKDIVRF"));//��I�����Ώۍ݌ɋ敪
            wkscmPriorStWork.UnSelTgtCampDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTCAMPDIVRF"));//��I�����ΏۃL�����y�[���敪
            wkscmPriorStWork.SelTgtPricDiv1= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPRICDIV1RF"));//�I�����Ώۉ��i�敪�P
            wkscmPriorStWork.SelTgtPricDiv2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPRICDIV2RF"));//�I�����Ώۉ��i�敪�Q
            wkscmPriorStWork.SelTgtPricDiv3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SELTGTPRICDIV3RF"));//�I�����Ώۉ��i�敪 3
            wkscmPriorStWork.UnSelTgtPricDiv1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPRICDIV1RF"));//��I�����Ώۉ��i�敪�P
            wkscmPriorStWork.UnSelTgtPricDiv2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPRICDIV2RF"));//��I�����Ώۉ��i�敪�Q
            wkscmPriorStWork.UnSelTgtPricDiv3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNSELTGTPRICDIV3RF"));//��I�����Ώۉ��i�敪 3
            //-------------ADD BY lingxiaoqing  -------------------------<<<<<<<<<<<<<<<<<<<<<
            #endregion

            return wkscmPriorStWork;
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
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMPriorStWork[] scmPriorStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is SCMPriorStWork)
                    {
                        SCMPriorStWork wkscmPriorStWork = paraobj as SCMPriorStWork;
                        if (wkscmPriorStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkscmPriorStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            scmPriorStWorkArray = (SCMPriorStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMPriorStWork[]));
                        }
                        catch (Exception) { }
                        if (scmPriorStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(scmPriorStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMPriorStWork wkscmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMPriorStWork));
                                if (wkscmPriorStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkscmPriorStWork);
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
        /// <br>Date       : 2009.05.12</br>
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
