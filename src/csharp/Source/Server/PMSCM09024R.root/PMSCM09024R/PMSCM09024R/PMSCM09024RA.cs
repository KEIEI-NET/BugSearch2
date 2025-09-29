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
    /// SCM�S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�S�̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.04.27</br>
    /// <br></br>
    /// <br>Update Note      :   2012/08/31  30747 �O�� �L��</br>
    /// <br>                 :   �����ڒǉ� </br>
    /// <br>                 :   �����񓚎��\���敪(2012/10���z�M�\�� SCM��Q��76�̑Ή�)</br>
    /// <br></br>
    /// <br>Update Note      :   2012/11/09  30744 ���� ����q</br>
    /// <br>                 :   �����ڒǉ� </br>
    /// <br>                 :     �����񓚋敪�i�⍇���j�A�����񓚋敪�i�����j�A</br>
    /// <br>                 :     ��t�]�ƈ��R�[�h�A��t�]�ƈ����́A�[�i�敪�A�[�i�敪����</br>
    /// <br>                 :    SCM���Ǉ�10337,10338,10341�Ή�</br>
    /// <br>Update Note      :   2013/02/13  30744 ���� ����q</br>
    /// <br>                 :   ��SCM��Q�Ή� ���ڒǉ� </br>
    /// <br>                 :     �Y���������񓚋敪</br>
    /// <br>Update Note      :   �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh</br>
    /// <br>                 :   �z�M���Ȃ��� Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή� </br>
    /// <br>Update Note      :   �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangl2</br>
    /// <br>                 :   2013/05/15 �z�M�� Redmine#35269 </br>
    /// </remarks>
    [Serializable]
    public class SCMTtlStDB : RemoteDB, ISCMTtlStDB
    {
        /// <summary>
        /// SCM�S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        /// <br>-----------------------------------------------</br>
        /// <br>UpDateNote : ���Ϗ����s�敪�̒ǉ�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2009.07.15</br>
        /// </remarks>
        public SCMTtlStDB()
            :
            base("PMSCM09026D", "Broadleaf.Application.Remoting.ParamData.SCMTtlStWork", "SCMTTLSTRF")
        {
        }

        private string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="scmTtlStWork">��������</param>
        /// <param name="paraSCMTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int Search(out object scmTtlStWork, object paraSCMTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            scmTtlStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMTtlStProc(out scmTtlStWork, paraSCMTtlStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMTtlStDB.Search");
                scmTtlStWork = new ArrayList();
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
        /// �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objscmTtlStWork">��������</param>
        /// <param name="parascmTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchSCMTtlStProc(out object objscmTtlStWork, object parascmTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMTtlStWork scmTtlStWork = null; 

            ArrayList stockmngttlstWorkList = parascmTtlStWork as ArrayList;
            if (stockmngttlstWorkList == null)
            {
                scmTtlStWork = parascmTtlStWork as SCMTtlStWork;
            }
            else
            {
                if (stockmngttlstWorkList.Count > 0)
                    scmTtlStWork = stockmngttlstWorkList[0] as SCMTtlStWork;
            }

            int status = SearchStockMngTtlStProc(out stockmngttlstWorkList, scmTtlStWork, readMode, logicalMode, ref sqlConnection);
            objscmTtlStWork = stockmngttlstWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">��������</param>
        /// <param name="scmTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchStockMngTtlStProc(out ArrayList stockmngttlstWorkList, SCMTtlStWork scmTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchStockMngTtlStProcProc(out stockmngttlstWorkList, scmTtlStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">��������</param>
        /// <param name="scmTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int SearchStockMngTtlStProcProc(out ArrayList stockmngttlstWorkList, SCMTtlStWork scmTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                selectTxt += "         ,SALESSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,ACPODRRSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPERATDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPFOLDERRF " + Environment.NewLine;
                selectTxt += "         ,BLCODECHGDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOCOOPERATDISRF " + Environment.NewLine;
                selectTxt += "         ,DISCOUNTAPPLYCDRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ESTIMATEPRTDIVRF " + Environment.NewLine;  //2009/07/15
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,RCVPROCSTINTERVALRF " + Environment.NewLine;
                selectTxt += "         ,SALESCDSTAUTOANSRF " + Environment.NewLine;
                selectTxt += "         ,SALESCODERF " + Environment.NewLine;
                //2012/04/20 ADD T.Nishi <<<<<<<<<<

                // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,AUTOANSHOURDSPDIVRF " + Environment.NewLine;
                // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                selectTxt += "         ,AUTOANSINQUIRYDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSORDERDIVRF " + Environment.NewLine;
                selectTxt += "         ,FRONTEMPLOYEECDRF " + Environment.NewLine;
                selectTxt += "         ,DELIVEREDGOODSDIVRF " + Environment.NewLine;
                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                selectTxt += "         ,FUWIOUTAUTOANSDIVRF " + Environment.NewLine;
                // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                selectTxt += "         ,DATAUPDATEWAREHDIVRF " + Environment.NewLine;
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                selectTxt += "         ,SALESINPUTCODERF " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                selectTxt += "  FROM SCMTTLSTRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmTtlStWork, logicalMode);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSCMTtlStWorkFromReader(ref myReader));
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

            stockmngttlstWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">SCMTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                SCMTtlStWork scmTtlStWork = new SCMTtlStWork();

                // XML�̓ǂݍ���
                scmTtlStWork = (SCMTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMTtlStWork));
                if (scmTtlStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmTtlStWork, readMode, ref sqlConnection);
                
                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(scmTtlStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Read");
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
        /// �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmTtlStWork">SCMTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɊǗ��S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int ReadProc(ref SCMTtlStWork scmTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref scmTtlStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int ReadProcProc(ref SCMTtlStWork scmTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SALESSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,ACPODRRSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPERATDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPFOLDERRF " + Environment.NewLine;
                selectTxt += "         ,BLCODECHGDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOCOOPERATDISRF " + Environment.NewLine;
                selectTxt += "         ,DISCOUNTAPPLYCDRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ESTIMATEPRTDIVRF " + Environment.NewLine;  //2009/07/15
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,RCVPROCSTINTERVALRF " + Environment.NewLine;
                selectTxt += "         ,SALESCDSTAUTOANSRF " + Environment.NewLine;
                selectTxt += "         ,SALESCODERF " + Environment.NewLine;
                //2012/04/20 ADD T.Nishi <<<<<<<<<<

                // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,AUTOANSHOURDSPDIVRF " + Environment.NewLine;
                // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                selectTxt += "         ,AUTOANSINQUIRYDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSORDERDIVRF " + Environment.NewLine;
                selectTxt += "         ,FRONTEMPLOYEECDRF " + Environment.NewLine;
                selectTxt += "         ,DELIVEREDGOODSDIVRF " + Environment.NewLine;
                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                selectTxt += "         ,FUWIOUTAUTOANSDIVRF " + Environment.NewLine;
                // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                selectTxt += "         ,DATAUPDATEWAREHDIVRF " + Environment.NewLine;
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                selectTxt += "         ,SALESINPUTCODERF " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                selectTxt += "  FROM SCMTTLSTRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;

                #endregion

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);
               
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    scmTtlStWork = CopyToSCMTtlStWorkFromReader(ref myReader);
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
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// SCM�S�̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="scmTtlStWork">SCMTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int Write(ref object scmTtlStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmTtlStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSCMTtlStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMTtlStWork paraWork = paraList[0] as SCMTtlStWork;
                
                //�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecSCMTtlSt(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                scmTtlStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMTtlSttDB.Write(ref object scmTtlStWork)");
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
        /// SCM�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmTtlStWorkList">SCMTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int WriteSCMTtlStProc(ref ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMTtlStProcProc(ref scmTtlStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�N��  ����</br>
        /// <br>Date       : 2009.04.27</br>
        private int WriteSCMTtlStProcProc(ref ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand�@�@sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmTtlStWorkList != null)
                {
                    for (int i = 0; i < scmTtlStWorkList.Count; i++)
                    {
                        SCMTtlStWork scmTtlStWork = scmTtlStWorkList[i] as SCMTtlStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmTtlStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (scmTtlStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMTTLSTRF SET " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "  , ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "  , OLDSYSCOOPERATDIVRF = @OLDSYSCOOPERATDIV " + Environment.NewLine;
                            sqlText += "  , OLDSYSCOOPFOLDERRF = @OLDSYSCOOPFOLDER " + Environment.NewLine;
                            sqlText += "  , BLCODECHGDIVRF = @BLCODECHGDIV " + Environment.NewLine;
                            sqlText += "  , AUTOCOOPERATDISRF = @AUTOCOOPERATDIS " + Environment.NewLine;
                            sqlText += "  , DISCOUNTAPPLYCDRF = @DISCOUNTAPPLYCD " + Environment.NewLine;
                            sqlText += "  , AUTOANSWERDIVRF = @AUTOANSWERDIV" + Environment.NewLine;
                            sqlText += "  , ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;  //2009/07/15
                            //2012/04/20 ADD T.Nishi >>>>>>>>>>
                            sqlText += "  , CASHREGISTERNORF = @CASHREGISTERNO" + Environment.NewLine;  //2009/07/15
                            sqlText += "  , RCVPROCSTINTERVALRF = @RCVPROCSTINTERVAL" + Environment.NewLine;  //2009/07/15
                            sqlText += "  , SALESCDSTAUTOANSRF = @SALESCDSTAUTOANS" + Environment.NewLine;  //2009/07/15
                            sqlText += "  , SALESCODERF = @SALESCODE" + Environment.NewLine;  //2009/07/15
                            //2012/04/20 ADD T.Nishi <<<<<<<<<<

                            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "  , AUTOANSHOURDSPDIVRF = @AUTOANSHOURDSPDIV" + Environment.NewLine;
                            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                            sqlText += "  , AUTOANSINQUIRYDIVRF = @AUTOANSINQUIRYDIV" + Environment.NewLine;
                            sqlText += "  , AUTOANSORDERDIVRF   = @AUTOANSORDERDIV" + Environment.NewLine;
                            sqlText += "  , FRONTEMPLOYEECDRF   = @FRONTEMPLOYEECD" + Environment.NewLine;
                            sqlText += "  , DELIVEREDGOODSDIVRF = @DELIVEREDGOODSDIV" + Environment.NewLine;
                            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                            sqlText += "  , FUWIOUTAUTOANSDIVRF = @FUWIOUTAUTOANSDIV" + Environment.NewLine;
                            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                            sqlText += "  , DATAUPDATEWAREHDIVRF = @DATAUPDATEWAREHDIV" + Environment.NewLine;
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                            sqlText += "  , SALESINPUTCODERF = @SALESINPUTCODE" + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (scmTtlStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMTTLSTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,SALESSLIPPRTDIVRF " + Environment.NewLine;
                            sqlText += "         ,ACPODRRSLIPPRTDIVRF " + Environment.NewLine;
                            sqlText += "         ,OLDSYSCOOPERATDIVRF " + Environment.NewLine;
                            sqlText += "         ,OLDSYSCOOPFOLDERRF " + Environment.NewLine;
                            sqlText += "         ,BLCODECHGDIVRF " + Environment.NewLine;
                            sqlText += "         ,AUTOCOOPERATDISRF " + Environment.NewLine;
                            sqlText += "         ,DISCOUNTAPPLYCDRF " + Environment.NewLine;
                            sqlText += "         ,AUTOANSWERDIVRF " + Environment.NewLine;  
                            sqlText += "         ,ESTIMATEPRTDIVRF " + Environment.NewLine;  // 2009/07/15
                            //2012/04/20 ADD T.Nishi >>>>>>>>>>
                            sqlText += "         ,CASHREGISTERNORF " + Environment.NewLine;
                            sqlText += "         ,RCVPROCSTINTERVALRF " + Environment.NewLine;
                            sqlText += "         ,SALESCDSTAUTOANSRF " + Environment.NewLine;
                            sqlText += "         ,SALESCODERF " + Environment.NewLine;
                            //2012/04/20 ADD T.Nishi <<<<<<<<<<

                            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,AUTOANSHOURDSPDIVRF " + Environment.NewLine;
                            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                            sqlText += "         ,AUTOANSINQUIRYDIVRF " + Environment.NewLine;
                            sqlText += "         ,AUTOANSORDERDIVRF " + Environment.NewLine;
                            sqlText += "         ,FRONTEMPLOYEECDRF " + Environment.NewLine;
                            sqlText += "         ,DELIVEREDGOODSDIVRF " + Environment.NewLine;
                            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                            sqlText += "         ,FUWIOUTAUTOANSDIVRF " + Environment.NewLine;
                            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                            sqlText += "         ,DATAUPDATEWAREHDIVRF " + Environment.NewLine;
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                            sqlText += "         ,SALESINPUTCODERF " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

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
                            sqlText += "         ,@SALESSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "         ,@ACPODRRSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "         ,@OLDSYSCOOPERATDIV " + Environment.NewLine;
                            sqlText += "         ,@OLDSYSCOOPFOLDER " + Environment.NewLine;
                            sqlText += "         ,@BLCODECHGDIV " + Environment.NewLine;
                            sqlText += "         ,@AUTOCOOPERATDIS " + Environment.NewLine;
                            sqlText += "         ,@DISCOUNTAPPLYCD " + Environment.NewLine;
                            sqlText += "         ,@AUTOANSWERDIV " + Environment.NewLine;  
                            sqlText += "         ,@ESTIMATEPRTDIV " + Environment.NewLine;  //2009/07/15
                            //2012/04/20 ADD T.Nishi >>>>>>>>>>
                            sqlText += "         ,@CASHREGISTERNO " + Environment.NewLine;
                            sqlText += "         ,@RCVPROCSTINTERVAL " + Environment.NewLine;
                            sqlText += "         ,@SALESCDSTAUTOANS " + Environment.NewLine;
                            sqlText += "         ,@SALESCODE " + Environment.NewLine;  
                            //2012/04/20 ADD T.Nishi <<<<<<<<<<

                            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,@AUTOANSHOURDSPDIV " + Environment.NewLine;
                            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                            sqlText += "         ,@AUTOANSINQUIRYDIV " + Environment.NewLine;
                            sqlText += "         ,@AUTOANSORDERDIV " + Environment.NewLine;
                            sqlText += "         ,@FRONTEMPLOYEECD " + Environment.NewLine;
                            sqlText += "         ,@DELIVEREDGOODSDIV " + Environment.NewLine;
                            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                            sqlText += "         ,@FUWIOUTAUTOANSDIV " + Environment.NewLine;
                            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                            sqlText += "         ,@DATAUPDATEWAREHDIV " + Environment.NewLine;
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                            sqlText += "         ,@SALESINPUTCODE " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmTtlStWork;
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
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);  // ����`�[���s�敪
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);  // �󒍓`�[���s�敪
                        SqlParameter paraOldSysCooperatDiv = sqlCommand.Parameters.Add("@OLDSYSCOOPERATDIV", SqlDbType.Int);  // ���V�X�e���A�g�敪
                        SqlParameter paraOldSysCoopFolder = sqlCommand.Parameters.Add("@OLDSYSCOOPFOLDER", SqlDbType.NVarChar);  // ���V�X�e���A�g�t�H���_
                        SqlParameter paraBLCodeChgDiv = sqlCommand.Parameters.Add("@BLCODECHGDIV", SqlDbType.Int);  // BL�R�[�h�ϊ��敪
                        SqlParameter paraAutoCooperatDis = sqlCommand.Parameters.Add("@AUTOCOOPERATDIS", SqlDbType.Float);  // �����A�g�l��
                        SqlParameter paraDiscountApplyCd = sqlCommand.Parameters.Add("@DISCOUNTAPPLYCD", SqlDbType.Int);  // �l���K�p�敪
                        SqlParameter paraAutoAnswerDiv = sqlCommand.Parameters.Add("@AUTOANSWERDIV", SqlDbType.Int);  // �����񓚋敪  
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);  // ���Ϗ����s�敪  //2009/07/15
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);  // ���W�ԍ�
                        SqlParameter paraRcvProcStInterval = sqlCommand.Parameters.Add("@RCVPROCSTINTERVAL", SqlDbType.Int);  // ��M�����N���Ԋu
                        SqlParameter paraSalesCdStAutoAns = sqlCommand.Parameters.Add("@SALESCDSTAUTOANS", SqlDbType.Int);  // �̔��敪�ݒ�(�����񓚎�)
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);  // �̔��敪�R�[�h
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraAutoAnsHourDspDiv = sqlCommand.Parameters.Add("@AUTOANSHOURDSPDIV", SqlDbType.Int);  //�����񓚎��\���敪
                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                        SqlParameter paraAutoAnsInquiryDiv = sqlCommand.Parameters.Add("@AUTOANSINQUIRYDIV", SqlDbType.Int);  // �����񓚋敪�i�⍇���j
                        SqlParameter paraAutoAnsOrderDiv = sqlCommand.Parameters.Add("@AUTOANSORDERDIV", SqlDbType.Int);  // �����񓚋敪�i�����j
                        SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);  // ��t�]�ƈ��R�[�h
                        SqlParameter paraDeliverGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);  // �[�i�敪
                        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                        SqlParameter paraFuwioutAutoAnsDiv = sqlCommand.Parameters.Add("@FUWIOUTAUTOANSDIV", SqlDbType.Int);  // �Y���������񓚋敪
                        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                        SqlParameter paraDataUpDateWareHDiv = sqlCommand.Parameters.Add("@DATAUPDATEWAREHDIV", SqlDbType.Int);
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                        SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);// ADD 2013.04.11 wangl2 FOR RedMine#35269

                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmTtlStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);  // ���_�R�[�h
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesSlipPrtDiv);  // ����`�[���s�敪
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AcpOdrrSlipPrtDiv);  // �󒍓`�[���s�敪
                        paraOldSysCooperatDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.OldSysCooperatDiv);  // ���V�X�e���A�g�敪
                        paraOldSysCoopFolder.Value = SqlDataMediator.SqlSetString(scmTtlStWork.OldSysCoopFolder);  // ���V�X�e���A�g�t�H���_
                        paraBLCodeChgDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.BLCodeChgDiv);  // BL�R�[�h�ϊ��敪
                        paraAutoCooperatDis.Value = SqlDataMediator.SqlSetDouble(scmTtlStWork.AutoCooperatDis);  // �����A�g�l��
                        paraDiscountApplyCd.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DiscountApplyCd);  // �l���K�p�敪
                        paraAutoAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnswerDiv);  // �����񓚋敪
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.EstimatePrtDiv);  // ���Ϗ����s�敪  //2009/07/15
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.CashRegisterNo);  // ���W�ԍ�
                        paraRcvProcStInterval.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.RcvProcStInterval);  // ��M�����N���Ԋu
                        paraSalesCdStAutoAns.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCdStAutoAns);  // �̔��敪�ݒ�(�����񓚎�)
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCode);  // �̔��敪�R�[�h
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        paraAutoAnsHourDspDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsHourDspDiv);    //�����񓚎��\���敪
                        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                        paraAutoAnsInquiryDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsInquiryDiv);   // �����񓚋敪�i�⍇���j
                        paraAutoAnsOrderDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsOrderDiv);       // �����񓚋敪�i�����j
                        paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(scmTtlStWork.FrontEmployeeCd);      // ��t�]�ƈ��R�[�h
                        paraDeliverGoodsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DeliveredGoodsDiv);     // �[�i�敪
                        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                        paraFuwioutAutoAnsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.FuwioutAutoAnsDiv);   // �Y���������񓚋敪
                        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                        paraDataUpDateWareHDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DataUpDateWareHDiv);
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                        paraSalesInputCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SalesInputCode);// ADD 2013.04.11 wangl2 FOR RedMine#35269

                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmTtlStWork);
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

            scmTtlStWorkList = al;

            return status;
        }

        /// <summary>
        /// �S�Ћ��ʍ��ڂ��X�V����
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        private int UpdateAllSecSCMTtlSt(ref ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmTtlStWorkList != null)
                {
                    SCMTtlStWork scmTtlStWork = scmTtlStWorkList[0] as SCMTtlStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region �X�V����SQL������
                    string sqlText = string.Empty;
                    sqlText += " UPDATE SCMTTLSTRF SET " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV " + Environment.NewLine;
                    sqlText += "  , ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV " + Environment.NewLine;
                    sqlText += "  , OLDSYSCOOPERATDIVRF = @OLDSYSCOOPERATDIV " + Environment.NewLine;
                    sqlText += "  , OLDSYSCOOPFOLDERRF = @OLDSYSCOOPFOLDER " + Environment.NewLine;
                    sqlText += "  , BLCODECHGDIVRF = @BLCODECHGDIV " + Environment.NewLine;
                    sqlText += "  , AUTOCOOPERATDISRF = @AUTOCOOPERATDIS " + Environment.NewLine;
                    sqlText += "  , DISCOUNTAPPLYCDRF = @DISCOUNTAPPLYCD " + Environment.NewLine;
                    sqlText += "  , AUTOANSWERDIVRF = @AUTOANSWERDIV" + Environment.NewLine;
                    sqlText += "  , ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;  //2009/07/15
                    //2012/04/20 ADD T.Nishi >>>>>>>>>>
                    sqlText += "  , CASHREGISTERNORF = @CASHREGISTERNO" + Environment.NewLine;
                    sqlText += "  , RCVPROCSTINTERVALRF = @RCVPROCSTINTERVAL" + Environment.NewLine;
                    sqlText += "  , SALESCDSTAUTOANSRF = @SALESCDSTAUTOANS" + Environment.NewLine;
                    sqlText += "  , SALESCODERF = @SALESCODE" + Environment.NewLine;
                    //2012/04/20 ADD T.Nishi <<<<<<<<<<

                    // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += "  , AUTOANSHOURDSPDIVRF = @AUTOANSHOURDSPDIV" + Environment.NewLine;
                    // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                    sqlText += "  , AUTOANSINQUIRYDIVRF = @AUTOANSINQUIRYDIV" + Environment.NewLine;
                    sqlText += "  , AUTOANSORDERDIVRF   = @AUTOANSORDERDIV" + Environment.NewLine;
                    sqlText += "  , FRONTEMPLOYEECDRF   = @FRONTEMPLOYEECD" + Environment.NewLine;
                    sqlText += "  , DELIVEREDGOODSDIVRF = @DELIVEREDGOODSDIV" + Environment.NewLine;
                    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                    sqlText += "  , FUWIOUTAUTOANSDIVRF = @FUWIOUTAUTOANSDIV" + Environment.NewLine;
                    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    sqlText += "  , DATAUPDATEWAREHDIVRF = @DATAUPDWAREHOUSEDIV" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    sqlText += "  , SALESINPUTCODERF = @SALESINPUTCODE" + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmTtlStWork;
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
                    SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);  // ����`�[���s�敪
                    SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);  // �󒍓`�[���s�敪
                    SqlParameter paraOldSysCooperatDiv = sqlCommand.Parameters.Add("@OLDSYSCOOPERATDIV", SqlDbType.Int);  // ���V�X�e���A�g�敪
                    SqlParameter paraOldSysCoopFolder = sqlCommand.Parameters.Add("@OLDSYSCOOPFOLDER", SqlDbType.NVarChar);  // ���V�X�e���A�g�t�H���_
                    SqlParameter paraBLCodeChgDiv = sqlCommand.Parameters.Add("@BLCODECHGDIV", SqlDbType.Int);  // BL�R�[�h�ϊ��敪
                    SqlParameter paraAutoCooperatDis = sqlCommand.Parameters.Add("@AUTOCOOPERATDIS", SqlDbType.Float);  // �����A�g�l��
                    SqlParameter paraDiscountApplyCd = sqlCommand.Parameters.Add("@DISCOUNTAPPLYCD", SqlDbType.Int);  // �l���K�p�敪
                    SqlParameter paraAutoAnswerDiv = sqlCommand.Parameters.Add("@AUTOANSWERDIV", SqlDbType.Int);  // �����񓚋敪
                    SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);  // ���Ϗ����s�敪  //2009/07/15
                    //2012/04/20 ADD T.Nishi >>>>>>>>>>
                    SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);  // ���W�ԍ�
                    SqlParameter paraRcvProcStInterval = sqlCommand.Parameters.Add("@RCVPROCSTINTERVAL", SqlDbType.Int);  // ��M�����N���Ԋu
                    SqlParameter paraSalesCdStAutoAns = sqlCommand.Parameters.Add("@SALESCDSTAUTOANS", SqlDbType.Int);  // �̔��敪�ݒ�(�����񓚎�)
                    SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);  // �̔��敪�R�[�h
                    //2012/04/20 ADD T.Nishi <<<<<<<<<<

                    // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    SqlParameter paraAutoAnsHourDspDiv = sqlCommand.Parameters.Add("@AUTOANSHOURDSPDIV", SqlDbType.Int);  //�����񓚎��\���敪
                    // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                    SqlParameter paraAutoAnsInquiryDiv = sqlCommand.Parameters.Add("@AUTOANSINQUIRYDIV", SqlDbType.Int);  // �����񓚋敪�i�⍇���j
                    SqlParameter paraAutoAnsOrderDiv = sqlCommand.Parameters.Add("@AUTOANSORDERDIV", SqlDbType.Int);  // �����񓚋敪�i�����j
                    SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);  // ��t�]�ƈ��R�[�h
                    SqlParameter paraDeliverGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);  // �[�i�敪
                    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                    SqlParameter paraFuwioutAutoAnsDiv = sqlCommand.Parameters.Add("@FUWIOUTAUTOANSDIV", SqlDbType.Int);  // �Y���������񓚋敪
                    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    SqlParameter paraDataUpDateWareHDiv = sqlCommand.Parameters.Add("@DATAUPDWAREHOUSEDIV", SqlDbType.Int);
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);// ADD 2013.04.11 wangl2 FOR RedMine#35269

                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.CreateDateTime);  // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.UpdateDateTime);  // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);  // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmTtlStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.LogicalDeleteCode);  // �_���폜�敪
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);  // ���_�R�[�h
                    paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesSlipPrtDiv);  // ����`�[���s�敪
                    paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AcpOdrrSlipPrtDiv);  // �󒍓`�[���s�敪
                    paraOldSysCooperatDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.OldSysCooperatDiv);  // ���V�X�e���A�g�敪
                    paraOldSysCoopFolder.Value = SqlDataMediator.SqlSetString(scmTtlStWork.OldSysCoopFolder);  // ���V�X�e���A�g�t�H���_
                    paraBLCodeChgDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.BLCodeChgDiv);  // BL�R�[�h�ϊ��敪
                    paraAutoCooperatDis.Value = SqlDataMediator.SqlSetDouble(scmTtlStWork.AutoCooperatDis);  // �����A�g�l��
                    paraDiscountApplyCd.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DiscountApplyCd);  // �l���K�p�敪
                    paraAutoAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnswerDiv);  // �����񓚋敪
                    paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.EstimatePrtDiv);  // ���Ϗ����s�敪  //2009/07/15
                    //2012/04/20 ADD T.Nishi >>>>>>>>>>
                    paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.CashRegisterNo);  // ���W�ԍ�
                    paraRcvProcStInterval.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.RcvProcStInterval);  // ��M�����N���Ԋu
                    paraSalesCdStAutoAns.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCdStAutoAns);  // �̔��敪�ݒ�(�����񓚎�)
                    paraSalesCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCode);  // �̔��敪�R�[�h
                    //2012/04/20 ADD T.Nishi <<<<<<<<<<

                    // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    paraAutoAnsHourDspDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsHourDspDiv);    //�����񓚎��\���敪
                    // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                    paraAutoAnsInquiryDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsInquiryDiv);   // �����񓚋敪�i�⍇���j
                    paraAutoAnsOrderDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsOrderDiv);       // �����񓚋敪�i�����j
                    paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(scmTtlStWork.FrontEmployeeCd);      // ��t�]�ƈ��R�[�h
                    paraDeliverGoodsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DeliveredGoodsDiv);     // �[�i�敪
                    // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

                    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
                    paraFuwioutAutoAnsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.FuwioutAutoAnsDiv);   // �Y���������񓚋敪
                    // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    paraDataUpDateWareHDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DataUpDateWareHDiv);
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    paraSalesInputCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SalesInputCode);// ADD 2013.04.11 wangl2 FOR RedMine#35269

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
        /// SCM�S�̐ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�S�̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        public int LogicalDelete(ref object scmTtlStWork)
        {
            return LogicalDeleteSCMTtlSt(ref scmTtlStWork, 0);
        }

        /// <summary>
        /// �_���폜SCM�S�̐ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int RevivalLogicalDelete(ref object scmTtlStWork)
        {
            return LogicalDeleteSCMTtlSt(ref scmTtlStWork, 1);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteSCMTtlSt(ref object scmTtlStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmTtlStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMTtlStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMTtlStDB.LogicalDeleteSCMTtlSt :" + procModestr);

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
        /// �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int LogicalDeleteSCMTtlStProc(ref ArrayList scmTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMTtlStProcProc(ref scmTtlStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteSCMTtlStProcProc(ref ArrayList scmTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmTtlStWorkList != null)
                {
                    for (int i = 0; i < scmTtlStWorkList.Count; i++)
                    {
                        SCMTtlStWork scmTtlStWork = scmTtlStWorkList[i] as SCMTtlStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmTtlStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmTtlStWork;
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
                            else if (logicalDelCd == 0) scmTtlStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else scmTtlStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmTtlStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmTtlStWork);
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

            scmTtlStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM�S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SCM�S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : SCM�S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
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

                status = DeleteSCMTtlStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMTtlStDB.Delete");
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
        /// �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmTtlStWorkList">�݌ɊǗ��S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        public int DeleteSCMTtlStProc(ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMTtlStProcProc(scmTtlStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmTtlStWorkList">�݌ɊǗ��S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        private int DeleteSCMTtlStProcProc(ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmTtlStWorkList.Count; i++)
                {
                    SCMTtlStWork scmTtlStWork = scmTtlStWorkList[i] as SCMTtlStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != scmTtlStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);
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
        /// <param name="scmTtlStWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@</br>
        /// <br>Date       : 2007.03.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMTtlStWork scmTtlStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(scmTtlStWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);
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
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        private SCMTtlStWork CopyToSCMTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMTtlStWork wkSCMTtlStWork = new SCMTtlStWork();

            #region �N���X�֊i�[
            wkSCMTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkSCMTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkSCMTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkSCMTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkSCMTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkSCMTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkSCMTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkSCMTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkSCMTtlStWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));  // ����`�[���s�敪
            wkSCMTtlStWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));  // �󒍓`�[���s�敪
            wkSCMTtlStWork.OldSysCooperatDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDSYSCOOPERATDIVRF"));  // ���V�X�e���A�g�敪
            wkSCMTtlStWork.OldSysCoopFolder = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDSYSCOOPFOLDERRF"));  // ���V�X�e���A�g�t�H���_
            wkSCMTtlStWork.BLCodeChgDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODECHGDIVRF"));  // BL�R�[�h�ϊ��敪
            wkSCMTtlStWork.AutoCooperatDis = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("AUTOCOOPERATDISRF"));  // �����A�g�l��
            wkSCMTtlStWork.DiscountApplyCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISCOUNTAPPLYCDRF"));  // �l���K�p�敪
            wkSCMTtlStWork.AutoAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVRF"));  // �����񓚋敪
            wkSCMTtlStWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));  // ���Ϗ����s�敪  //2009/07/15
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            wkSCMTtlStWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));  // ���W�ԍ�
            wkSCMTtlStWork.RcvProcStInterval = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RCVPROCSTINTERVALRF"));  // ��M�����N���Ԋu
            wkSCMTtlStWork.SalesCdStAutoAns = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCDSTAUTOANSRF"));  // �̔��敪�ݒ�(�����񓚎�)
            wkSCMTtlStWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));  // �̔��敪�R�[�h
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            wkSCMTtlStWork.AutoAnsHourDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSHOURDSPDIVRF")); //�����񓚎��\���敪
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            wkSCMTtlStWork.AutoAnsInquiryDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSINQUIRYDIVRF"));  // �����񓚋敪�i�⍇���j
            wkSCMTtlStWork.AutoAnsOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSORDERDIVRF"));  // �����񓚋敪�i�����j
            wkSCMTtlStWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));  // ��t�]�ƈ��R�[�h
            wkSCMTtlStWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // �[�i�敪
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� -------------------------------------------->>>>>
            wkSCMTtlStWork.FuwioutAutoAnsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FUWIOUTAUTOANSDIVRF"));  // �Y���������񓚋敪
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            wkSCMTtlStWork.DataUpDateWareHDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAUPDATEWAREHDIVRF"));
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            wkSCMTtlStWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));// ADD 2013.04.11 wangl2 FOR RedMine#35269

            #endregion

            return wkSCMTtlStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��  ����</br>
        /// <br>Date       : 2009.04.27</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMTtlStWork[] SCMTtlStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is SCMTtlStWork)
                    {
                        SCMTtlStWork wkSCMTtlStWork = paraobj as SCMTtlStWork;
                        if (wkSCMTtlStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMTtlStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMTtlStWorkArray = (SCMTtlStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMTtlStWork[]));
                        }
                        catch (Exception) { }
                        if (SCMTtlStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMTtlStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMTtlStWork wkSCMTtlStWork = (SCMTtlStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMTtlStWork));
                                if (wkSCMTtlStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMTtlStWork);
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
        /// <br>Date       : 2009.04.27</br>
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
