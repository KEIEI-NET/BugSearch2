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
    /// SCM�[���ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.04.28</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.08.26 20056 ���n ���</br>
    /// <br>           : MANTIS 14165 ���ʂɉ񓚔[���U���Z�b�g</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/01/06 30517 �Ė� �x��</br>
    /// <br>           : SCM���،��ʑΉ�No.7�@�[���ݒ�����i�E�݌ɕi�ŕʂɐݒ�o����l�ɏC��</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/10/11  ���R</br>
    /// <br>Note       : Redmine #25765</br>
    /// <br>           : �D��݌ɉ񓚔[���敪�A�D��݌ɉ񓚔[���̒ǉ�</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2012/08/30 ���� ��</br>
    /// <br>           : SCM��Q�Ή�No.10345�@�񓚔[���̐ݒ���@��ύX</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/02/10 �g��</br>
    /// <br>           : SCM������ �񓚔[���敪�Ή�</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/02/16 �L��</br>
    /// <br>           : SCM������ �V�X�e����QNo226�Ή�</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// </remarks>
    [Serializable]
    public class SCMDeliDateStDB : RemoteDB, ISCMDeliDateStDB
    {
        /// <summary>
        /// SCM�[���ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public SCMDeliDateStDB()
            :
            base("PMSCM09036D", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork", "SCMDELIDATESTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ������SCM�[���ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="stockmngttlstWork">��������</param>
        /// <param name="parastockmngttlstWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�_�@�ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int Search(out object scmDeliDateStWork, object parascmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmDeliDateStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMDeliDateStProc(out scmDeliDateStWork, parascmDeliDateStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Search");
                scmDeliDateStWork = new ArrayList();
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
        /// �w�肳�ꂽ������SCM�[���ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objscmDeliDateStWork">��������</param>
        /// <param name="parascmDeliDateStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchSCMDeliDateStProc(out object objscmDeliDateStWork, object parascmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMDeliDateStWork scmDeliDateStWork = null; 

            ArrayList scmDeliDateStWorkList = parascmDeliDateStWork as ArrayList;
            if (scmDeliDateStWorkList == null)
            {
                scmDeliDateStWork = parascmDeliDateStWork as SCMDeliDateStWork;
            }
            else
            {
                if (scmDeliDateStWorkList.Count > 0)
                    scmDeliDateStWork = scmDeliDateStWorkList[0] as SCMDeliDateStWork;
            }

            int status = SearchSCMDeliDateStProc(out scmDeliDateStWorkList, scmDeliDateStWork, readMode, logicalMode, ref sqlConnection);
            objscmDeliDateStWork = scmDeliDateStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">��������</param>
        /// <param name="scmDeliDateStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchSCMDeliDateStProc(out ArrayList scmDeliDateStWorkList, SCMDeliDateStWork scmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMDeliDateStProcProc(out scmDeliDateStWorkList, scmDeliDateStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">��������</param>
        /// <param name="scmDeliDateStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchSCMDeliDateStProcProc(out ArrayList scmDeliDateStWorkList, SCMDeliDateStWork scmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                selectTxt += " SELECT SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6RF " + Environment.NewLine;
                // 2011/01/06 Add >>>
                selectTxt += "         ,SCM.ANSWERDEADTIME1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/01/06 Add <<<
                // 2011/10/11 Add >>>
                selectTxt += "         ,SCM.PRISTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/10/11 Add <<<
                // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDATSHORTOFSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDATWITHOUTSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATWIOUTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATWIOUTRF " + Environment.NewLine;
                // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDTDIV1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTWIODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTWIODIVRF " + Environment.NewLine;
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                selectTxt += "  FROM SCMDELIDATESTRF AS SCM" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmDeliDateStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSCMDeliDateStWorkFromReader(ref myReader));

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

            scmDeliDateStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ������SCM�[���ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�[���ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                SCMDeliDateStWork scmDeliDateStWork = new SCMDeliDateStWork();

                // XML�̓ǂݍ���
                scmDeliDateStWork = (SCMDeliDateStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMDeliDateStWork));
                if (scmDeliDateStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmDeliDateStWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(scmDeliDateStWork);
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
        /// �w�肳�ꂽ������SCM�_�@�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�_�@�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int ReadProc(ref SCMDeliDateStWork scmDeliDateStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref scmDeliDateStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ������SCM�_�@�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������SCM�_�@�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        private int ReadProcProc(ref SCMDeliDateStWork scmDeliDateStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;
                selectTxt += "SELECT SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6RF " + Environment.NewLine;
                // 2011/01/06 Add >>>
                selectTxt += "         ,SCM.ANSWERDEADTIME1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/01/06 Add <<<
                // 2011/10/11 Add >>>
                selectTxt += "         ,SCM.PRISTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/10/11 Add <<<
                // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDATSHORTOFSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDATWITHOUTSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATWIOUTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATWIOUTRF " + Environment.NewLine;
                // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDTDIV1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTWIODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTWIODIVRF " + Environment.NewLine;
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                selectTxt += "  FROM SCMDELIDATESTRF  AS SCM " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += " WHERE SCM.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SCM.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;


                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                    findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmDeliDateStWork = CopyToSCMDeliDateStWorkFromReader(ref myReader);
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
        /// SCM�[���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int Write(ref object stockmngttlstWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(stockmngttlstWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSCMDeliDateStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMDeliDateStWork paraWork = paraList[0] as SCMDeliDateStWork;
                
                // DEL 2015/02/16 �L�� SCM������ �V�X�e����QNo226�Ή� ------------------------------------------>>>>>
                // �S�Ћ��ʍ��ڍX�V�����ł̓f�[�^�X�V���s���Ă��Ȃ��������ߍ폜
                ////�S�Аݒ���X�V�����ꍇ�́A���̍��ڂɂ����f������
                //if (paraWork.SectionCode == _allSecCode)
                //{
                //    UpdateAllSCMDeliDateSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                //}
                // DEL 2015/02/16 �L�� SCM������ �V�X�e����QNo226�Ή� ------------------------------------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                stockmngttlstWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMDeliDateStDB.Write(ref object scmDeliDateStWork)");
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
        /// SCM�[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int WriteSCMDeliDateStProc(ref ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMDeliDateStProcProc(ref scmDeliDateStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        private int WriteSCMDeliDateStProcProc(ref ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmDeliDateStWorkList != null)
                {
                    for (int i = 0; i < scmDeliDateStWorkList.Count; i++)
                    {
                        SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[i] as SCMDeliDateStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                        findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h



                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmDeliDateStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (scmDeliDateStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMDELIDATESTRF SET  " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME1RF = @ANSWERDEADTIME1 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME2RF = @ANSWERDEADTIME2 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME3RF = @ANSWERDEADTIME3 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME4RF = @ANSWERDEADTIME4 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME5RF = @ANSWERDEADTIME5 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME6RF = @ANSWERDEADTIME6 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE1RF = @ANSWERDELIVDATE1 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE2RF = @ANSWERDELIVDATE2 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE3RF = @ANSWERDELIVDATE3 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE4RF = @ANSWERDELIVDATE4 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE5RF = @ANSWERDELIVDATE5 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE6RF = @ANSWERDELIVDATE6 " + Environment.NewLine;
                            // 2011/01/06 Add >>>
                            sqlText += "  , ANSWERDEADTIME1STCRF = @ANSWERDEADTIME1STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME2STCRF = @ANSWERDEADTIME2STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME3STCRF = @ANSWERDEADTIME3STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME4STCRF = @ANSWERDEADTIME4STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME5STCRF = @ANSWERDEADTIME5STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME6STCRF = @ANSWERDEADTIME6STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE1STCRF = @ANSWERDELIVDATE1STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE2STCRF = @ANSWERDELIVDATE2STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE3STCRF = @ANSWERDELIVDATE3STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE4STCRF = @ANSWERDELIVDATE4STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE5STCRF = @ANSWERDELIVDATE5STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE6STCRF = @ANSWERDELIVDATE6STC " + Environment.NewLine;
                            sqlText += "  , ENTSTCKANSDELIDTDIVRF = @ENTSTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "  , ENTSTCKANSDELIDATERF = @ENTSTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/01/06 Add <<<
                            // 2011/10/11 Add >>>
                            sqlText += "  , PRISTCKANSDELIDTDIVRF = @PRISTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "  , PRISTCKANSDELIDATERF = @PRISTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/10/11 Add <<<
                            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "  , ANSDELDATSHORTOFSTCRF = @ANSDELDATSHORTOFSTC " + Environment.NewLine;
                            sqlText += "  , ANSDELDATWITHOUTSTCRF = @ANSDELDATWITHOUTSTC " + Environment.NewLine;
                            sqlText += "  , ENTSTCANSDELDATSHORTRF = @ENTSTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "  , ENTSTCANSDELDATWIOUTRF = @ENTSTCANSDELDATWIOUT " + Environment.NewLine;
                            sqlText += "  , PRISTCANSDELDATSHORTRF = @PRISTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "  , PRISTCANSDELDATWIOUTRF = @PRISTCANSDELDATWIOUT " + Environment.NewLine;
                            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "  , ANSDELDTDIV1RF = @ANSDELDTDIV1RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV2RF = @ANSDELDTDIV2RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV3RF = @ANSDELDTDIV3RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV4RF = @ANSDELDTDIV4RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV5RF = @ANSDELDTDIV5RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV6RF = @ANSDELDTDIV6RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV1STCRF = @ANSDELDTDIV1STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV2STCRF = @ANSDELDTDIV2STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV3STCRF = @ANSDELDTDIV3STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV4STCRF = @ANSDELDTDIV4STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV5STCRF = @ANSDELDTDIV5STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV6STCRF = @ANSDELDTDIV6STCRF " + Environment.NewLine;
                            sqlText += "  , ENTANSDELDTSTCDIVRF = @ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , PRIANSDELDTSTCDIVRF = @PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTSHOSTCDIVRF = @ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTWIOSTCDIVRF = @ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , ENTANSDELDTSHODIVRF = @ENTANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "  , ENTANSDELDTWIODIVRF = @ENTANSDELDTWIODIVRF " + Environment.NewLine;
                            sqlText += "  , PRIANSDELDTSHODIVRF = @PRIANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "  , PRIANSDELDTWIODIVRF = @PRIANSDELDTWIODIVRF " + Environment.NewLine;
                            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                            findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (scmDeliDateStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMDELIDATESTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME1RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME2RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME3RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME4RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME5RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME6RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE1RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE2RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE3RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE4RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE5RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE6RF " + Environment.NewLine;
                            // 2011/01/06 Add >>>
                            sqlText += "         ,ANSWERDEADTIME1STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME2STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME3STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME4STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME5STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME6STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE1STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE2STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE3STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE4STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE5STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE6STCRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCKANSDELIDTDIVRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCKANSDELIDATERF " + Environment.NewLine;
                            // 2011/01/06 Add <<<
                            // 2011/10/11 Add >>>
                            sqlText += "         ,PRISTCKANSDELIDTDIVRF " + Environment.NewLine;
                            sqlText += "         ,PRISTCKANSDELIDATERF " + Environment.NewLine;
                            // 2011/10/11 Add <<<
                            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,ANSDELDATSHORTOFSTCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDATWITHOUTSTCRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCANSDELDATSHORTRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCANSDELDATWIOUTRF " + Environment.NewLine;
                            sqlText += "         ,PRISTCANSDELDATSHORTRF " + Environment.NewLine;
                            sqlText += "         ,PRISTCANSDELDATWIOUTRF " + Environment.NewLine;
                            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,ANSDELDTDIV1RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV2RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV3RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV4RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV5RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV6RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV1STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV2STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV3STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV4STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV5STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV6STCRF " + Environment.NewLine;
                            sqlText += "         ,ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,ENTANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,ENTANSDELDTWIODIVRF " + Environment.NewLine;
                            sqlText += "         ,PRIANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,PRIANSDELDTWIODIVRF " + Environment.NewLine;
                            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
                            sqlText += "         ,@CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME1 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME2 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME3 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME4 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME5 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME6 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE1 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE2 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE3 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE4 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE5 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE6 " + Environment.NewLine;
                            // 2011/01/06 Add >>>
                            sqlText += "         ,@ANSWERDEADTIME1STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME2STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME3STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME4STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME5STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME6STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE1STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE2STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE3STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE4STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE5STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE6STC " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/01/06 Add <<<
                            // 2011/10/11 Add >>>
                            sqlText += "         ,@PRISTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "         ,@PRISTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/10/11 Add <<<
                            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,@ANSDELDATSHORTOFSTC " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDATWITHOUTSTC " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCANSDELDATWIOUT " + Environment.NewLine;
                            sqlText += "         ,@PRISTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "         ,@PRISTCANSDELDATWIOUT " + Environment.NewLine;
                            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,@ANSDELDTDIV1RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV2RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV3RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV4RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV5RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV6RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV1STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV2STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV3STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV4STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV5STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV6STCRF " + Environment.NewLine;
                            sqlText += "         ,@ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@ENTANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,@ENTANSDELDTWIODIVRF " + Environment.NewLine;
                            sqlText += "         ,@PRIANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,@PRIANSDELDTWIODIVRF " + Environment.NewLine;
                            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                        SqlParameter paraAnswerDeadTime1 = sqlCommand.Parameters.Add("@ANSWERDEADTIME1", SqlDbType.Int);  // �񓚒��؎����P
                        SqlParameter paraAnswerDeadTime2 = sqlCommand.Parameters.Add("@ANSWERDEADTIME2", SqlDbType.Int);  // �񓚒��؎����Q
                        SqlParameter paraAnswerDeadTime3 = sqlCommand.Parameters.Add("@ANSWERDEADTIME3", SqlDbType.Int);  // �񓚒��؎����R
                        SqlParameter paraAnswerDeadTime4 = sqlCommand.Parameters.Add("@ANSWERDEADTIME4", SqlDbType.Int);  // �񓚒��؎����S
                        SqlParameter paraAnswerDeadTime5 = sqlCommand.Parameters.Add("@ANSWERDEADTIME5", SqlDbType.Int);  // �񓚒��؎����T
                        SqlParameter paraAnswerDeadTime6 = sqlCommand.Parameters.Add("@ANSWERDEADTIME6", SqlDbType.Int);  // �񓚒��؎����U
                        SqlParameter paraAnswerDelivDate1 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1", SqlDbType.NVarChar);  // �񓚔[���P
                        SqlParameter paraAnswerDelivDate2 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2", SqlDbType.NVarChar);  // �񓚔[���Q
                        SqlParameter paraAnswerDelivDate3 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3", SqlDbType.NVarChar);  // �񓚔[���R
                        SqlParameter paraAnswerDelivDate4 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4", SqlDbType.NVarChar);  // �񓚔[���S
                        SqlParameter paraAnswerDelivDate5 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5", SqlDbType.NVarChar);  // �񓚔[���T
                        SqlParameter paraAnswerDelivDate6 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6", SqlDbType.NVarChar);  // �񓚔[��6
                        // 2011/01/06 Add >>>
                        SqlParameter paraAnswerDeadTime1Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME1STC", SqlDbType.Int);  // �񓚒��؎����P�i�݌Ɂj
                        SqlParameter paraAnswerDeadTime2Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME2STC", SqlDbType.Int);  // �񓚒��؎����Q�i�݌Ɂj
                        SqlParameter paraAnswerDeadTime3Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME3STC", SqlDbType.Int);  // �񓚒��؎����R�i�݌Ɂj
                        SqlParameter paraAnswerDeadTime4Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME4STC", SqlDbType.Int);  // �񓚒��؎����S�i�݌Ɂj
                        SqlParameter paraAnswerDeadTime5Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME5STC", SqlDbType.Int);  // �񓚒��؎����T�i�݌Ɂj
                        SqlParameter paraAnswerDeadTime6Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME6STC", SqlDbType.Int);  // �񓚒��؎����U�i�݌Ɂj
                        SqlParameter paraAnswerDelivDate1Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1STC", SqlDbType.NVarChar);  // �񓚔[���P�i�݌Ɂj
                        SqlParameter paraAnswerDelivDate2Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2STC", SqlDbType.NVarChar);  // �񓚔[���Q�i�݌Ɂj
                        SqlParameter paraAnswerDelivDate3Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3STC", SqlDbType.NVarChar);  // �񓚔[���R�i�݌Ɂj
                        SqlParameter paraAnswerDelivDate4Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4STC", SqlDbType.NVarChar);  // �񓚔[���S�i�݌Ɂj
                        SqlParameter paraAnswerDelivDate5Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5STC", SqlDbType.NVarChar);  // �񓚔[���T�i�݌Ɂj
                        SqlParameter paraAnswerDelivDate6Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6STC", SqlDbType.NVarChar);  // �񓚔[��6�i�݌Ɂj
                        SqlParameter paraEntStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDTDIV", SqlDbType.Int);  // �ϑ��݌ɉ񓚔[���敪
                        SqlParameter paraEntStckAnsDeliDate = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDATE", SqlDbType.NVarChar);  // �ϑ��݌ɉ񓚔[��
                        // 2011/01/06 Add <<<
                        // 2011/10/11 Add >>>
                        SqlParameter paraPriStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@PRISTCKANSDELIDTDIV", SqlDbType.Int);  // �D��݌ɉ񓚔[���敪
                        SqlParameter paraPriStckAnsDeliDate = sqlCommand.Parameters.Add("@PRISTCKANSDELIDATE", SqlDbType.NVarChar);  // �D��݌ɉ񓚔[��
                        // 2011/10/11 Add <<<
                        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraAnsDelDatShortOfStc = sqlCommand.Parameters.Add("@ANSDELDATSHORTOFSTC", SqlDbType.NVarChar);   // �񓚔[���i�݌ɕs���j
                        SqlParameter paraAnsDelDatWithoutStc = sqlCommand.Parameters.Add("@ANSDELDATWITHOUTSTC", SqlDbType.NVarChar);   // �񓚔[���i�݌ɐ������j
                        SqlParameter paraEntStcAnsDelDatShort = sqlCommand.Parameters.Add("@ENTSTCANSDELDATSHORT", SqlDbType.NVarChar); // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
                        SqlParameter paraEntStcAnsDelDatWiout = sqlCommand.Parameters.Add("@ENTSTCANSDELDATWIOUT", SqlDbType.NVarChar); // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
                        SqlParameter paraPriStcAnsDelDatShort = sqlCommand.Parameters.Add("@PRISTCANSDELDATSHORT", SqlDbType.NVarChar); // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
                        SqlParameter paraPriStcAnsDelDatWiout = sqlCommand.Parameters.Add("@PRISTCANSDELDATWIOUT", SqlDbType.NVarChar); // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
                        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraAnsDelDtDiv1 = sqlCommand.Parameters.Add("@ANSDELDTDIV1RF", SqlDbType.SmallInt); // �񓚔[���敪�P
                        SqlParameter paraAnsDelDtDiv2 = sqlCommand.Parameters.Add("@ANSDELDTDIV2RF", SqlDbType.SmallInt); // �񓚔[���敪�Q
                        SqlParameter paraAnsDelDtDiv3 = sqlCommand.Parameters.Add("@ANSDELDTDIV3RF", SqlDbType.SmallInt); // �񓚔[���敪�R
                        SqlParameter paraAnsDelDtDiv4 = sqlCommand.Parameters.Add("@ANSDELDTDIV4RF", SqlDbType.SmallInt); // �񓚔[���敪�S
                        SqlParameter paraAnsDelDtDiv5 = sqlCommand.Parameters.Add("@ANSDELDTDIV5RF", SqlDbType.SmallInt); // �񓚔[���敪�T
                        SqlParameter paraAnsDelDtDiv6 = sqlCommand.Parameters.Add("@ANSDELDTDIV6RF", SqlDbType.SmallInt); // �񓚔[���敪�U
                        SqlParameter paraAnsDelDtDiv1Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV1STCRF", SqlDbType.SmallInt); // �񓚔[���敪�P�i�݌Ɂj
                        SqlParameter paraAnsDelDtDiv2Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV2STCRF", SqlDbType.SmallInt); // �񓚔[���敪�Q�i�݌Ɂj
                        SqlParameter paraAnsDelDtDiv3Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV3STCRF", SqlDbType.SmallInt); // �񓚔[���敪�R�i�݌Ɂj
                        SqlParameter paraAnsDelDtDiv4Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV4STCRF", SqlDbType.SmallInt); // �񓚔[���敪�S�i�݌Ɂj
                        SqlParameter paraAnsDelDtDiv5Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV5STCRF", SqlDbType.SmallInt); // �񓚔[���敪�T�i�݌Ɂj
                        SqlParameter paraAnsDelDtDiv6Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV6STCRF", SqlDbType.SmallInt); // �񓚔[���敪�U�i�݌Ɂj
                        SqlParameter paraEntAnsDelDtStcDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSTCDIVRF", SqlDbType.SmallInt); // �ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
                        SqlParameter paraPriAnsDelDtStcDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSTCDIVRF", SqlDbType.SmallInt); // �D��݌ɉ񓚔[���敪�i�݌Ɂj
                        SqlParameter paraAnsDelDtShoStcDiv = sqlCommand.Parameters.Add("@ANSDELDTSHOSTCDIVRF", SqlDbType.SmallInt); // �񓚔[���敪�i�݌ɕs���j
                        SqlParameter paraAnsDelDtWioStcDiv = sqlCommand.Parameters.Add("@ANSDELDTWIOSTCDIVRF", SqlDbType.SmallInt); // �񓚔[���敪�i�݌ɐ������j
                        SqlParameter paraEntAnsDelDtShoDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSHODIVRF", SqlDbType.SmallInt); // �ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
                        SqlParameter paraEntAnsDelDtWioDiv = sqlCommand.Parameters.Add("@ENTANSDELDTWIODIVRF", SqlDbType.SmallInt); // �ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
                        SqlParameter paraPriAnsDelDtShoDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSHODIVRF", SqlDbType.SmallInt); // �D��݌ɉ񓚔[���敪�i�݌ɕs���j
                        SqlParameter paraPriAnsDelDtWioDiv = sqlCommand.Parameters.Add("@PRIANSDELDTWIODIVRF", SqlDbType.SmallInt); // �D��݌ɉ񓚔[���敪�i�݌ɐ������j
                        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmDeliDateStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h
                        paraAnswerDeadTime1.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1);  // �񓚒��؎����P
                        paraAnswerDeadTime2.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2);  // �񓚒��؎����Q
                        paraAnswerDeadTime3.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3);  // �񓚒��؎����R
                        paraAnswerDeadTime4.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4);  // �񓚒��؎����S
                        paraAnswerDeadTime5.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5);  // �񓚒��؎����T
                        paraAnswerDeadTime6.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6);  // �񓚒��؎����U
                        paraAnswerDelivDate1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1);  // �񓚔[���P
                        paraAnswerDelivDate2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2);  // �񓚔[���Q
                        paraAnswerDelivDate3.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3);  // �񓚔[���R
                        paraAnswerDelivDate4.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4);  // �񓚔[���S
                        paraAnswerDelivDate5.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5);  // �񓚔[���T
                        paraAnswerDelivDate6.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6);  // �񓚔[��6
                        // 2011/01/06 Add >>>
                        paraAnswerDeadTime1Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1Stc);  // �񓚒��؎����P�i�݌Ɂj
                        paraAnswerDeadTime2Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2Stc);  // �񓚒��؎����Q�i�݌Ɂj
                        paraAnswerDeadTime3Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3Stc);  // �񓚒��؎����R�i�݌Ɂj
                        paraAnswerDeadTime4Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4Stc);  // �񓚒��؎����S�i�݌Ɂj
                        paraAnswerDeadTime5Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5Stc);  // �񓚒��؎����T�i�݌Ɂj
                        paraAnswerDeadTime6Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6Stc);  // �񓚒��؎����U�i�݌Ɂj
                        paraAnswerDelivDate1Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1Stc);  // �񓚔[���P�i�݌Ɂj
                        paraAnswerDelivDate2Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2Stc);  // �񓚔[���Q�i�݌Ɂj
                        paraAnswerDelivDate3Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3Stc);  // �񓚔[���R�i�݌Ɂj
                        paraAnswerDelivDate4Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4Stc);  // �񓚔[���S�i�݌Ɂj
                        paraAnswerDelivDate5Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5Stc);  // �񓚔[���T�i�݌Ɂj
                        paraAnswerDelivDate6Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6Stc);  // �񓚔[��6�i�݌Ɂj
                        paraEntStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.EntStckAnsDeliDtDiv);  // �ϑ��݌ɉ񓚔[���敪
                        paraEntStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStckAnsDeliDate);  // �ϑ��݌ɉ񓚔[��
                        // 2011/01/06 Add <<<
                        // 2011/10/11 Add >>>
                        paraPriStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.PriStckAnsDeliDtDiv);  // �D��݌ɉ񓚔[���敪
                        paraPriStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStckAnsDeliDate);  // �D��݌ɉ񓚔[��
                        // 2011/10/11 Add <<<
                        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        paraAnsDelDatShortOfStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatShortOfStc);    // �񓚔[���i�݌ɕs���j
                        paraAnsDelDatWithoutStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatWithoutStc);    // �񓚔[���i�݌ɐ������j
                        paraEntStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatShort);  // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
                        paraEntStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatWiout);  // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
                        paraPriStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatShort);  // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
                        paraPriStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatWiout);  // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
                        // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        paraAnsDelDtDiv1.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1); // �񓚔[���敪�P
                        paraAnsDelDtDiv2.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2); // �񓚔[���敪�Q
                        paraAnsDelDtDiv3.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3); // �񓚔[���敪�R
                        paraAnsDelDtDiv4.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4); // �񓚔[���敪�S
                        paraAnsDelDtDiv5.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5); // �񓚔[���敪�T
                        paraAnsDelDtDiv6.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6); // �񓚔[���敪�U
                        paraAnsDelDtDiv1Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1Stc); // �񓚔[���敪�P�i�݌Ɂj
                        paraAnsDelDtDiv2Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2Stc); // �񓚔[���敪�Q�i�݌Ɂj
                        paraAnsDelDtDiv3Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3Stc); // �񓚔[���敪�R�i�݌Ɂj
                        paraAnsDelDtDiv4Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4Stc); // �񓚔[���敪�S�i�݌Ɂj
                        paraAnsDelDtDiv5Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5Stc); // �񓚔[���敪�T�i�݌Ɂj
                        paraAnsDelDtDiv6Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6Stc); // �񓚔[���敪�U�i�݌Ɂj
                        paraEntAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtStcDiv); // �ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
                        paraPriAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtStcDiv); // �D��݌ɉ񓚔[���敪�i�݌Ɂj
                        paraAnsDelDtShoStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtShoStcDiv); // �񓚔[���敪�i�݌ɕs���j
                        paraAnsDelDtWioStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtWioStcDiv); // �񓚔[���敪�i�݌ɐ������j
                        paraEntAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtShoDiv); // �ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
                        paraEntAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtWioDiv); // �ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
                        paraPriAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtShoDiv); // �D��݌ɉ񓚔[���敪�i�݌ɕs���j
                        paraPriAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtWioDiv); // �D��݌ɉ񓚔[���敪�i�݌ɐ������j
                        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmDeliDateStWork);
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

            scmDeliDateStWorkList = al;

            return status;
        }

        // DEL 2015/02/16 �L�� SCM������ �V�X�e����QNo226�Ή� ------------------------------------------>>>>>
        // �S�Ћ��ʍ��ڍX�V�����ł̓f�[�^�X�V���s���Ă��Ȃ��������ߍ폜
        ///// <summary>
        ///// �S�Ћ��ʍ��ڂ��X�V����
        ///// </summary>
        ///// <param name="scmDeliDateStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : SCM�[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        ///// <br>Programmer : 30350�@�N��@����</br>
        ///// <br>Date       : 2009.04.28</br>
        //private int UpdateAllSCMDeliDateSt(ref ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    SqlCommand sqlCommand = null;
        //    ArrayList al = new ArrayList();
        //    try
        //    {
        //        if (scmDeliDateStWorkList != null)
        //        {
        //            SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[0] as SCMDeliDateStWork;

        //            sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
        //            # region �X�V����SQL������
        //            string sqlText = string.Empty;
        //            sqlText += " UPDATE SCMDELIDATESTRF SET  " + Environment.NewLine;
        //            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
        //            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
        //            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
        //            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
        //            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
        //            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
        //            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
        //            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
        //            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
        //            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME1RF = @ANSWERDEADTIME1 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME2RF = @ANSWERDEADTIME2 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME3RF = @ANSWERDEADTIME3 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME4RF = @ANSWERDEADTIME4 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME5RF = @ANSWERDEADTIME5 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME6RF = @ANSWERDEADTIME6 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE1RF = @ANSWERDELIVDATE1 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE2RF = @ANSWERDELIVDATE2 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE3RF = @ANSWERDELIVDATE3 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE4RF = @ANSWERDELIVDATE4 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE5RF = @ANSWERDELIVDATE5 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE6RF = @ANSWERDELIVDATE6 " + Environment.NewLine;
        //            // 2011/01/06 Add >>>
        //            sqlText += "  , ANSWERDEADTIME1STCRF = @ANSWERDEADTIME1STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME2STCRF = @ANSWERDEADTIME2STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME3STCRF = @ANSWERDEADTIME3STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME4STCRF = @ANSWERDEADTIME4STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME5STCRF = @ANSWERDEADTIME5STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME6STCRF = @ANSWERDEADTIME6STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE1STCRF = @ANSWERDELIVDATE1STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE2STCRF = @ANSWERDELIVDATE2STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE3STCRF = @ANSWERDELIVDATE3STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE4STCRF = @ANSWERDELIVDATE4STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE5STCRF = @ANSWERDELIVDATE5STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE6STCRF = @ANSWERDELIVDATE6STC " + Environment.NewLine;
        //            sqlText += "  , ENTSTCKANSDELIDTDIVRF = @ENTSTCKANSDELIDTDIV " + Environment.NewLine;
        //            sqlText += "  , ENTSTCKANSDELIDATERF = @ENTSTCKANSDELIDATE " + Environment.NewLine;
        //            // 2011/01/06 Add <<<
        //            // 2011/10/11 Add >>>
        //            sqlText += "  , PRISTCKANSDELIDTDIVRF = @PRISTCKANSDELIDTDIV " + Environment.NewLine;
        //            sqlText += "  , PRISTCKANSDELIDATERF = @PRISTCKANSDELIDATE " + Environment.NewLine;
        //            // 2011/10/11 Add <<<
        //            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            sqlText += "  , ANSDELDATSHORTOFSTCRF = @ANSDELDATSHORTOFSTC " + Environment.NewLine;
        //            sqlText += "  , ANSDELDATWITHOUTSTCRF = @ANSDELDATWITHOUTSTC " + Environment.NewLine;
        //            sqlText += "  , ENTSTCANSDELDATSHORTRF = @ENTSTCANSDELDATSHORT " + Environment.NewLine;
        //            sqlText += "  , ENTSTCANSDELDATWIOUTRF = @ENTSTCANSDELDATWIOUT " + Environment.NewLine;
        //            sqlText += "  , PRISTCANSDELDATSHORTRF = @PRISTCANSDELDATSHORT " + Environment.NewLine;
        //            sqlText += "  , PRISTCANSDELDATWIOUTRF = @PRISTCANSDELDATWIOUT " + Environment.NewLine;
        //            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            sqlText += "  , ANSDELDTDIV1RF = @ANSDELDTDIV1RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV2RF = @ANSDELDTDIV2RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV3RF = @ANSDELDTDIV3RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV4RF = @ANSDELDTDIV4RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV5RF = @ANSDELDTDIV5RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV6RF = @ANSDELDTDIV6RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV1STCRF = @ANSDELDTDIV1STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV2STCRF = @ANSDELDTDIV2STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV3STCRF = @ANSDELDTDIV3STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV4STCRF = @ANSDELDTDIV4STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV5STCRF = @ANSDELDTDIV5STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV6STCRF = @ANSDELDTDIV6STCRF " + Environment.NewLine;
        //            sqlText += "  , ENTANSDELDTSTCDIVRF = @ENTANSDELDTSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , PRIANSDELDTSTCDIVRF = @PRIANSDELDTSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTSHOSTCDIVRF = @ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTWIOSTCDIVRF = @ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , ENTANSDELDTSHODIVRF = @ENTANSDELDTSHODIVRF " + Environment.NewLine;
        //            sqlText += "  , ENTANSDELDTWIODIVRF = @ENTANSDELDTWIODIVRF " + Environment.NewLine;
        //            sqlText += "  , PRIANSDELDTSHODIVRF = @PRIANSDELDTSHODIVRF " + Environment.NewLine;
        //            sqlText += "  , PRIANSDELDTWIODIVRF = @PRIANSDELDTWIODIVRF " + Environment.NewLine;
        //            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
        //            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
        //            sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
        //            sqlCommand.CommandText = sqlText;

        //            //�X�V�w�b�_����ݒ�
        //            object obj = (object)this;
        //            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
        //            FileHeader fileHeader = new FileHeader(obj);
        //            fileHeader.SetUpdateHeader(ref flhd, obj);
        //            #endregion

        //            #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
        //            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
        //            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
        //            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
        //            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
        //            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
        //            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
        //            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
        //            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
        //            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
        //            SqlParameter paraAnswerDeadTime1 = sqlCommand.Parameters.Add("@ANSWERDEADTIME1", SqlDbType.Int);  // �񓚒��؎����P
        //            SqlParameter paraAnswerDeadTime2 = sqlCommand.Parameters.Add("@ANSWERDEADTIME2", SqlDbType.Int);  // �񓚒��؎����Q
        //            SqlParameter paraAnswerDeadTime3 = sqlCommand.Parameters.Add("@ANSWERDEADTIME3", SqlDbType.Int);  // �񓚒��؎����R
        //            SqlParameter paraAnswerDeadTime4 = sqlCommand.Parameters.Add("@ANSWERDEADTIME4", SqlDbType.Int);  // �񓚒��؎����S
        //            SqlParameter paraAnswerDeadTime5 = sqlCommand.Parameters.Add("@ANSWERDEADTIME5", SqlDbType.Int);  // �񓚒��؎����T
        //            SqlParameter paraAnswerDeadTime6 = sqlCommand.Parameters.Add("@ANSWERDEADTIME6", SqlDbType.Int);  // �񓚒��؎����U
        //            SqlParameter paraAnswerDelivDate1 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1", SqlDbType.NVarChar);  // �񓚔[���P
        //            SqlParameter paraAnswerDelivDate2 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2", SqlDbType.NVarChar);  // �񓚔[���Q
        //            SqlParameter paraAnswerDelivDate3 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3", SqlDbType.NVarChar);  // �񓚔[���R
        //            SqlParameter paraAnswerDelivDate4 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4", SqlDbType.NVarChar);  // �񓚔[���S
        //            SqlParameter paraAnswerDelivDate5 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5", SqlDbType.NVarChar);  // �񓚔[���T
        //            // 2011/01/06 Add >>>
        //            SqlParameter paraAnswerDelivDate6 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6", SqlDbType.NVarChar);  // �񓚔[���U
        //            SqlParameter paraAnswerDeadTime1Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME1STC", SqlDbType.Int);  // �񓚒��؎����P�i�݌Ɂj
        //            SqlParameter paraAnswerDeadTime2Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME2STC", SqlDbType.Int);  // �񓚒��؎����Q�i�݌Ɂj
        //            SqlParameter paraAnswerDeadTime3Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME3STC", SqlDbType.Int);  // �񓚒��؎����R�i�݌Ɂj
        //            SqlParameter paraAnswerDeadTime4Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME4STC", SqlDbType.Int);  // �񓚒��؎����S�i�݌Ɂj
        //            SqlParameter paraAnswerDeadTime5Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME5STC", SqlDbType.Int);  // �񓚒��؎����T�i�݌Ɂj
        //            SqlParameter paraAnswerDeadTime6Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME6STC", SqlDbType.Int);  // �񓚒��؎����U�i�݌Ɂj
        //            SqlParameter paraAnswerDelivDate1Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1STC", SqlDbType.NVarChar);  // �񓚔[���P�i�݌Ɂj
        //            SqlParameter paraAnswerDelivDate2Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2STC", SqlDbType.NVarChar);  // �񓚔[���Q�i�݌Ɂj
        //            SqlParameter paraAnswerDelivDate3Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3STC", SqlDbType.NVarChar);  // �񓚔[���R�i�݌Ɂj
        //            SqlParameter paraAnswerDelivDate4Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4STC", SqlDbType.NVarChar);  // �񓚔[���S�i�݌Ɂj
        //            SqlParameter paraAnswerDelivDate5Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5STC", SqlDbType.NVarChar);  // �񓚔[���T�i�݌Ɂj
        //            SqlParameter paraAnswerDelivDate6Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6STC", SqlDbType.NVarChar);  // �񓚔[���U�i�݌Ɂj
        //            SqlParameter paraEntStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDTDIV", SqlDbType.Int);  // �ϑ��݌ɉ񓚔[���敪
        //            SqlParameter paraEntStckAnsDeliDate = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDATE", SqlDbType.NVarChar);  // �ϑ��݌ɉ񓚔[��
        //            // 2011/01/06 Add <<<
        //            // 2011/10/11 Add >>>
        //            SqlParameter paraPriStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@PRISTCKANSDELIDTDIV", SqlDbType.Int);  // �D��݌ɉ񓚔[���敪
        //            SqlParameter paraPriStckAnsDeliDate = sqlCommand.Parameters.Add("@PRISTCKANSDELIDATE", SqlDbType.NVarChar);  // �D��݌ɉ񓚔[��
        //            // 2011/10/11 Add <<<
        //            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            SqlParameter paraAnsDelDatShortOfStc = sqlCommand.Parameters.Add("@ANSDELDATSHORTOFSTC", SqlDbType.NVarChar);   // �񓚔[���i�݌ɕs���j
        //            SqlParameter paraAnsDelDatWithoutStc = sqlCommand.Parameters.Add("@ANSDELDATWITHOUTSTC", SqlDbType.NVarChar);   // �񓚔[���i�݌ɐ������j
        //            SqlParameter paraEntStcAnsDelDatShort = sqlCommand.Parameters.Add("@ENTSTCANSDELDATSHORT", SqlDbType.NVarChar); // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
        //            SqlParameter paraEntStcAnsDelDatWiout = sqlCommand.Parameters.Add("@ENTSTCANSDELDATWIOUT", SqlDbType.NVarChar); // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
        //            SqlParameter paraPriStcAnsDelDatShort = sqlCommand.Parameters.Add("@PRISTCANSDELDATSHORT", SqlDbType.NVarChar); // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
        //            SqlParameter paraPriStcAnsDelDatWiout = sqlCommand.Parameters.Add("@PRISTCANSDELDATWIOUT", SqlDbType.NVarChar); // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
        //            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            SqlParameter paraAnsDelDtDiv1 = sqlCommand.Parameters.Add("@ANSDELDTDIV1RF", SqlDbType.SmallInt); // �񓚔[���敪�P
        //            SqlParameter paraAnsDelDtDiv2 = sqlCommand.Parameters.Add("@ANSDELDTDIV2RF", SqlDbType.SmallInt); // �񓚔[���敪�Q
        //            SqlParameter paraAnsDelDtDiv3 = sqlCommand.Parameters.Add("@ANSDELDTDIV3RF", SqlDbType.SmallInt); // �񓚔[���敪�R
        //            SqlParameter paraAnsDelDtDiv4 = sqlCommand.Parameters.Add("@ANSDELDTDIV4RF", SqlDbType.SmallInt); // �񓚔[���敪�S
        //            SqlParameter paraAnsDelDtDiv5 = sqlCommand.Parameters.Add("@ANSDELDTDIV5RF", SqlDbType.SmallInt); // �񓚔[���敪�T
        //            SqlParameter paraAnsDelDtDiv6 = sqlCommand.Parameters.Add("@ANSDELDTDIV6RF", SqlDbType.SmallInt); // �񓚔[���敪�U
        //            SqlParameter paraAnsDelDtDiv1Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV1STCRF", SqlDbType.SmallInt); // �񓚔[���敪�P�i�݌Ɂj
        //            SqlParameter paraAnsDelDtDiv2Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV2STCRF", SqlDbType.SmallInt); // �񓚔[���敪�Q�i�݌Ɂj
        //            SqlParameter paraAnsDelDtDiv3Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV3STCRF", SqlDbType.SmallInt); // �񓚔[���敪�R�i�݌Ɂj
        //            SqlParameter paraAnsDelDtDiv4Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV4STCRF", SqlDbType.SmallInt); // �񓚔[���敪�S�i�݌Ɂj
        //            SqlParameter paraAnsDelDtDiv5Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV5STCRF", SqlDbType.SmallInt); // �񓚔[���敪�T�i�݌Ɂj
        //            SqlParameter paraAnsDelDtDiv6Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV6STCRF", SqlDbType.SmallInt); // �񓚔[���敪�U�i�݌Ɂj
        //            SqlParameter paraEntAnsDelDtStcDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSTCDIVRF", SqlDbType.SmallInt); // �ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
        //            SqlParameter paraPriAnsDelDtStcDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSTCDIVRF", SqlDbType.SmallInt); // �D��݌ɉ񓚔[���敪�i�݌Ɂj
        //            SqlParameter paraAnsDelDtShoStcDiv = sqlCommand.Parameters.Add("@ANSDELDTSHOSTCDIVRF", SqlDbType.SmallInt); // �񓚔[���敪�i�݌ɕs���j
        //            SqlParameter paraAnsDelDtWioStcDiv = sqlCommand.Parameters.Add("@ANSDELDTWIOSTCDIVRF", SqlDbType.SmallInt); // �񓚔[���敪�i�݌ɐ������j
        //            SqlParameter paraEntAnsDelDtShoDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSHODIVRF", SqlDbType.SmallInt); // �ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
        //            SqlParameter paraEntAnsDelDtWioDiv = sqlCommand.Parameters.Add("@ENTANSDELDTWIODIVRF", SqlDbType.SmallInt); // �ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
        //            SqlParameter paraPriAnsDelDtShoDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSHODIVRF", SqlDbType.SmallInt); // �D��݌ɉ񓚔[���敪�i�݌ɕs���j
        //            SqlParameter paraPriAnsDelDtWioDiv = sqlCommand.Parameters.Add("@PRIANSDELDTWIODIVRF", SqlDbType.SmallInt); // �D��݌ɉ񓚔[���敪�i�݌ɐ������j
        //            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            #endregion

        //            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
        //            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.CreateDateTime);  // �쐬����
        //            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.UpdateDateTime);  // �X�V����
        //            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
        //            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmDeliDateStWork.FileHeaderGuid);  // GUID
        //            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
        //            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
        //            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.LogicalDeleteCode);  // �_���폜�敪
        //            paraSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
        //            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h
        //            paraAnswerDeadTime1.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1);  // �񓚒��؎����P
        //            paraAnswerDeadTime2.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2);  // �񓚒��؎����Q
        //            paraAnswerDeadTime3.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3);  // �񓚒��؎����R
        //            paraAnswerDeadTime4.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4);  // �񓚒��؎����S
        //            paraAnswerDeadTime5.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5);  // �񓚒��؎����T
        //            paraAnswerDeadTime6.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6);  // �񓚒��؎����U
        //            paraAnswerDelivDate1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1);  // �񓚔[���P
        //            paraAnswerDelivDate2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2);  // �񓚔[���Q
        //            paraAnswerDelivDate3.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3);  // �񓚔[���R
        //            paraAnswerDelivDate4.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4);  // �񓚔[���S
        //            paraAnswerDelivDate5.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5);  // �񓚔[���T
        //            // 2011/01/06 Add >>>
        //            paraAnswerDelivDate6.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6);  // �񓚔[���U
        //            paraAnswerDeadTime1Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1Stc);  // �񓚒��؎����P�i�݌Ɂj
        //            paraAnswerDeadTime2Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2Stc);  // �񓚒��؎����Q�i�݌Ɂj
        //            paraAnswerDeadTime3Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3Stc);  // �񓚒��؎����R�i�݌Ɂj
        //            paraAnswerDeadTime4Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4Stc);  // �񓚒��؎����S�i�݌Ɂj
        //            paraAnswerDeadTime5Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5Stc);  // �񓚒��؎����T�i�݌Ɂj
        //            paraAnswerDeadTime6Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6Stc);  // �񓚒��؎����U�i�݌Ɂj
        //            paraAnswerDelivDate1Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1Stc);  // �񓚔[���P�i�݌Ɂj
        //            paraAnswerDelivDate2Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2Stc);  // �񓚔[���Q�i�݌Ɂj
        //            paraAnswerDelivDate3Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3Stc);  // �񓚔[���R�i�݌Ɂj
        //            paraAnswerDelivDate4Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4Stc);  // �񓚔[���S�i�݌Ɂj
        //            paraAnswerDelivDate5Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5Stc);  // �񓚔[���T�i�݌Ɂj
        //            paraAnswerDelivDate6Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6Stc);  // �񓚔[���U�i�݌Ɂj
        //            paraEntStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.EntStckAnsDeliDtDiv);  // �ϑ��݌ɉ񓚔[���敪
        //            paraEntStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStckAnsDeliDate);  // �ϑ��݌ɉ񓚔[��
        //            // 2011/01/06 Add <<<
        //            // 2011/10/11 Add >>>
        //            paraPriStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.PriStckAnsDeliDtDiv);  // �D��݌ɉ񓚔[���敪
        //            paraPriStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStckAnsDeliDate);  // �D��݌ɉ񓚔[��
        //            // 2011/10/11 Add <<<
        //            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            paraAnsDelDatShortOfStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatShortOfStc);    // �񓚔[���i�݌ɕs���j
        //            paraAnsDelDatWithoutStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatWithoutStc);    // �񓚔[���i�݌ɐ������j
        //            paraEntStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatShort);  // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
        //            paraEntStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatWiout);  // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
        //            paraPriStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatShort);  // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
        //            paraPriStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatWiout);  // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
        //            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            paraAnsDelDtDiv1.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1); // �񓚔[���敪�P
        //            paraAnsDelDtDiv2.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2); // �񓚔[���敪�Q
        //            paraAnsDelDtDiv3.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3); // �񓚔[���敪�R
        //            paraAnsDelDtDiv4.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4); // �񓚔[���敪�S
        //            paraAnsDelDtDiv5.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5); // �񓚔[���敪�T
        //            paraAnsDelDtDiv6.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6); // �񓚔[���敪�U
        //            paraAnsDelDtDiv1Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1Stc); // �񓚔[���敪�P�i�݌Ɂj
        //            paraAnsDelDtDiv2Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2Stc); // �񓚔[���敪�Q�i�݌Ɂj
        //            paraAnsDelDtDiv3Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3Stc); // �񓚔[���敪�R�i�݌Ɂj
        //            paraAnsDelDtDiv4Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4Stc); // �񓚔[���敪�S�i�݌Ɂj
        //            paraAnsDelDtDiv5Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5Stc); // �񓚔[���敪�T�i�݌Ɂj
        //            paraAnsDelDtDiv6Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6Stc); // �񓚔[���敪�U�i�݌Ɂj
        //            paraEntAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtStcDiv); // �ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
        //            paraPriAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtStcDiv); // �D��݌ɉ񓚔[���敪�i�݌Ɂj
        //            paraAnsDelDtShoStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtShoStcDiv); // �񓚔[���敪�i�݌ɕs���j
        //            paraAnsDelDtWioStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtWioStcDiv); // �񓚔[���敪�i�݌ɐ������j
        //            paraEntAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtShoDiv); // �ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
        //            paraEntAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtWioDiv); // �ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
        //            paraPriAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtShoDiv); // �D��݌ɉ񓚔[���敪�i�݌ɕs���j
        //            paraPriAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtWioDiv); // �D��݌ɉ񓚔[���敪�i�݌ɐ������j
        //            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            #endregion

        //            sqlCommand.ExecuteNonQuery();

        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }

        //    return status;
        //}
        // DEL 2015/02/16 �L�� SCM������ �V�X�e����QNo226�Ή� ------------------------------------------<<<<<

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// SCM�[���ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="scmDeliDateStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int LogicalDelete(ref object scmDeliDateStWork)
        {
            return LogicalDeleteSCMDeliDateSt(ref scmDeliDateStWork, 0);
        }

        /// <summary>
        /// �_���폜SCM�_�@�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="scmDeliDateStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜SCM�_�@�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int RevivalLogicalDelete(ref object scmDeliDateStWork)
        {
            return LogicalDeleteSCMDeliDateSt(ref scmDeliDateStWork, 1);
        }

        /// <summary>
        /// SCM�_�@�ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�_�@�ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        private int LogicalDeleteSCMDeliDateSt(ref object scmDeliDateStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(scmDeliDateStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMDeliDateStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMDeliDateStDB.LogicalDeleteSCMDeliDateSt :" + procModestr);

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
        /// SCM�[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int LogicalDeleteSCMDeliDateStProc(ref ArrayList scmDeliDateStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMDeliDateStProcProc(ref scmDeliDateStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�_�@�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�_�@�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        private int LogicalDeleteSCMDeliDateStProcProc(ref ArrayList scmDeliDateStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmDeliDateStWorkList != null)
                {
                    for (int i = 0; i < scmDeliDateStWorkList.Count; i++)
                    {
                        SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[i] as SCMDeliDateStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                        findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != scmDeliDateStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMDELIDATESTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE";
                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                            findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
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
                            else if (logicalDelCd == 0) scmDeliDateStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else scmDeliDateStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmDeliDateStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmDeliDateStWork);
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

            scmDeliDateStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM�[���ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SCM�_�@�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
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

                status = DeleteSCMDeliDateStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "StockMngTtlStDB.Delete");
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
        /// SCM�[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">SCM�_�@�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        public int DeleteSCMDeliDateStProc(ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMDeliDateStProcProc(scmDeliDateStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">SCM�_�@�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        private int DeleteSCMDeliDateStProcProc(ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmDeliDateStWorkList.Count; i++)
                {
                    SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[i] as SCMDeliDateStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                    //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                    findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != scmDeliDateStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE";
                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // ��ƃR�[�h
                        findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // ���_�R�[�h
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // ���Ӑ�R�[�h
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
	    /// <param name="stockmngttlstWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMDeliDateStWork scmDeliDateStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "SCM.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(scmDeliDateStWork.SectionCode) == false)
            {
                retstring += "AND SCM.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();
            }
            
            //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // ���Ӑ�R�[�h
            if (scmDeliDateStWork.CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF = @FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.NChar);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);
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
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        private SCMDeliDateStWork CopyToSCMDeliDateStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMDeliDateStWork wkSCMDeliDateStWork = new SCMDeliDateStWork();

            #region �N���X�֊i�[
            wkSCMDeliDateStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkSCMDeliDateStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkSCMDeliDateStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkSCMDeliDateStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMDeliDateStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkSCMDeliDateStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkSCMDeliDateStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkSCMDeliDateStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkSCMDeliDateStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
            wkSCMDeliDateStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
            wkSCMDeliDateStWork.AnswerDeadTime1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME1RF"));  // �񓚒��؎����P
            wkSCMDeliDateStWork.AnswerDeadTime2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME2RF"));  // �񓚒��؎����Q
            wkSCMDeliDateStWork.AnswerDeadTime3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME3RF"));  // �񓚒��؎����R
            wkSCMDeliDateStWork.AnswerDeadTime4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME4RF"));  // �񓚒��؎����S
            wkSCMDeliDateStWork.AnswerDeadTime5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME5RF"));  // �񓚒��؎����T
            wkSCMDeliDateStWork.AnswerDeadTime6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME6RF"));  // �񓚒��؎����U
            wkSCMDeliDateStWork.AnswerDelivDate1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE1RF"));  // �񓚔[���P
            wkSCMDeliDateStWork.AnswerDelivDate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE2RF"));  // �񓚔[���Q
            wkSCMDeliDateStWork.AnswerDelivDate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE3RF"));  // �񓚔[���R
            wkSCMDeliDateStWork.AnswerDelivDate4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE4RF"));  // �񓚔[���S
            wkSCMDeliDateStWork.AnswerDelivDate5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE5RF"));  // �񓚔[���T
            wkSCMDeliDateStWork.AnswerDelivDate6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE6RF"));  // �񓚔[���U // 2009.08.26
            // 2011/01/06 Add >>>
            wkSCMDeliDateStWork.AnswerDeadTime1Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME1STCRF"));  // �񓚒��؎����P�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDeadTime2Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME2STCRF"));  // �񓚒��؎����Q�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDeadTime3Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME3STCRF"));  // �񓚒��؎����R�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDeadTime4Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME4STCRF"));  // �񓚒��؎����S�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDeadTime5Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME5STCRF"));  // �񓚒��؎����T�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDeadTime6Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME6STCRF"));  // �񓚒��؎����U�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDelivDate1Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE1STCRF"));  // �񓚔[���P�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDelivDate2Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE2STCRF"));  // �񓚔[���Q�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDelivDate3Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE3STCRF"));  // �񓚔[���R�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDelivDate4Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE4STCRF"));  // �񓚔[���S�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDelivDate5Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE5STCRF"));  // �񓚔[���T�i�݌Ɂj
            wkSCMDeliDateStWork.AnswerDelivDate6Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE6STCRF"));  // �񓚔[���U�i�݌Ɂj
            wkSCMDeliDateStWork.EntStckAnsDeliDtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTSTCKANSDELIDTDIVRF"));  // �ϑ��݌ɉ񓚔[���敪
            wkSCMDeliDateStWork.EntStckAnsDeliDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTSTCKANSDELIDATERF"));  // �ϑ��݌ɉ񓚔[��
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            wkSCMDeliDateStWork.PriStckAnsDeliDtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRISTCKANSDELIDTDIVRF"));  // �D��݌ɉ񓚔[���敪
            wkSCMDeliDateStWork.PriStckAnsDeliDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRISTCKANSDELIDATERF"));  // �D��݌ɉ񓚔[��
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            wkSCMDeliDateStWork.AnsDelDatShortOfStc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSDELDATSHORTOFSTCRF"));   // �񓚔[���i�݌ɕs���j
            wkSCMDeliDateStWork.AnsDelDatWithoutStc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSDELDATWITHOUTSTCRF"));   // �񓚔[���i�݌ɐ������j
            wkSCMDeliDateStWork.EntStcAnsDelDatShort = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTSTCANSDELDATSHORTRF")); // �ϑ��݌ɉ񓚔[���i�݌ɕs���j
            wkSCMDeliDateStWork.EntStcAnsDelDatWiout = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTSTCANSDELDATWIOUTRF")); // �ϑ��݌ɉ񓚔[���i�݌ɐ������j
            wkSCMDeliDateStWork.PriStcAnsDelDatShort = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRISTCANSDELDATSHORTRF")); // �Q�ƍ݌ɉ񓚔[���i�݌ɕs���j
            wkSCMDeliDateStWork.PriStcAnsDelDatWiout = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRISTCANSDELDATWIOUTRF")); // �Q�ƍ݌ɉ񓚔[���i�݌ɐ������j
            // 2012/08/30 ADD TAKAGAWA 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            wkSCMDeliDateStWork.AnsDelDtDiv1 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV1RF")); // �񓚔[���敪�P
            wkSCMDeliDateStWork.AnsDelDtDiv2 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV2RF")); // �񓚔[���敪�Q
            wkSCMDeliDateStWork.AnsDelDtDiv3 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV3RF")); // �񓚔[���敪�R
            wkSCMDeliDateStWork.AnsDelDtDiv4 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV4RF")); // �񓚔[���敪�S
            wkSCMDeliDateStWork.AnsDelDtDiv5 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV5RF")); // �񓚔[���敪�T
            wkSCMDeliDateStWork.AnsDelDtDiv6 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV6RF")); // �񓚔[���敪�U
            wkSCMDeliDateStWork.AnsDelDtDiv1Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV1STCRF")); // �񓚔[���敪�P�i�݌Ɂj
            wkSCMDeliDateStWork.AnsDelDtDiv2Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV2STCRF")); // �񓚔[���敪�Q�i�݌Ɂj
            wkSCMDeliDateStWork.AnsDelDtDiv3Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV3STCRF")); // �񓚔[���敪�R�i�݌Ɂj
            wkSCMDeliDateStWork.AnsDelDtDiv4Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV4STCRF")); // �񓚔[���敪�S�i�݌Ɂj
            wkSCMDeliDateStWork.AnsDelDtDiv5Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV5STCRF")); // �񓚔[���敪�T�i�݌Ɂj
            wkSCMDeliDateStWork.AnsDelDtDiv6Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV6STCRF")); // �񓚔[���敪�U�i�݌Ɂj
            wkSCMDeliDateStWork.EntAnsDelDtStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ENTANSDELDTSTCDIVRF")); // �ϑ��݌ɉ񓚔[���敪�i�݌Ɂj
            wkSCMDeliDateStWork.PriAnsDelDtStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PRIANSDELDTSTCDIVRF")); // �D��݌ɉ񓚔[���敪�i�݌Ɂj
            wkSCMDeliDateStWork.AnsDelDtShoStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTSHOSTCDIVRF")); // �񓚔[���敪�i�݌ɕs���j
            wkSCMDeliDateStWork.AnsDelDtWioStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTWIOSTCDIVRF")); // �񓚔[���敪�i�݌ɐ������j
            wkSCMDeliDateStWork.EntAnsDelDtShoDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ENTANSDELDTSHODIVRF")); // �ϑ��݌ɉ񓚔[���敪�i�݌ɕs���j
            wkSCMDeliDateStWork.EntAnsDelDtWioDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ENTANSDELDTWIODIVRF")); // �ϑ��݌ɉ񓚔[���敪�i�݌ɐ������j
            wkSCMDeliDateStWork.PriAnsDelDtShoDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PRIANSDELDTSHODIVRF")); // �D��݌ɉ񓚔[���敪�i�݌ɕs���j
            wkSCMDeliDateStWork.PriAnsDelDtWioDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PRIANSDELDTWIODIVRF")); // �D��݌ɉ񓚔[���敪�i�݌ɐ������j
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            return wkSCMDeliDateStWork;
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
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMDeliDateStWork[] SCMDeliDateStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is SCMDeliDateStWork)
                    {
                        SCMDeliDateStWork wkSCMDeliDateStWork = paraobj as SCMDeliDateStWork;
                        if (wkSCMDeliDateStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMDeliDateStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMDeliDateStWorkArray = (SCMDeliDateStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMDeliDateStWork[]));
                        }
                        catch (Exception) { }
                        if (SCMDeliDateStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMDeliDateStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMDeliDateStWork wkSCMDeliDateStWork = (SCMDeliDateStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMDeliDateStWork));
                                if (wkSCMDeliDateStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMDeliDateStWork);
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
        /// <br>Date       : 2009.04.28</br>
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
