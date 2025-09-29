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
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM�₢���킹�ꗗDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�₢���킹�ꗗ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// <br>Update Note: MANTIS 14019 �r�b�l�󒍃f�[�^�擾���A�ŐV�̔���ɔ���`�[�ԍ���ǉ�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2009.08.13</br>
    /// <br></br>
    /// <br>Update Note: IAAE�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/03/11</br>
    /// <br></br>
    /// <br>Update Note: SCM�����[�X�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/04/13</br>
    /// <br></br>
    /// <br>Update Note: �񓚌������A�⍇���E������ʂ����o����</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// <br>Update Note: �@�e�[�u�����C�A�E�g�ύX�Ή�</br>
    /// <br>             �A�ŐV���擾���̕s��C��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/17</br>
    /// <br></br>
    /// <br>Update Note: �⍇��/������ʃf�[�^�Ƃ��Ĉ����Ή�</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2011/01/24</br>
    /// <br></br>
    /// <br>Update Note: �L�����Z���f�[�^�̕ԕi�Ή�</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2011/02/18</br>
    /// <br></br>
    /// <br>Update Note: ��ʏo�͍��ڒǉ�(��: ���l,�w�����ԍ� ����:�q��, �I�� )</br>
    /// <br>Programmer : 21112�@�v�ۓc ��</br>
    /// <br>Date       : 2011/05/26</br>
    /// <br></br>
    /// <br>Update Note: ���o�������ڒǉ�(�X�V��(UpdateDate))</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2011/06/13</br>
    /// <br>Update Note: Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/11/12</br>
    /// <br></br>
    /// <br>Update Note: �V�X�e���e�X�g��Q��101 ����⍇���ԍ��ŕ�������`�[�ԍ��̏ꍇ�̌���������ύX</br>
    /// <br>Programmer : 30744�@���� ����q</br>
    /// <br>Date       : 2012/07/18</br>
    /// <br>Update Note: 2012/08/07�z�M�V�X�e���e�X�g��Q��126�Ή� (��101�Ή����̕s�)</br>
    /// <br>Programmer : 30745�@�g�� �F��</br>
    /// <br>Date       : 2012/07/27</br>
    /// <br></br>
    /// <br>Update Note: 2012/11/14�z�M�\�� SCM��Q��176�Ή�</br>
    /// <br>Programmer : 30744�@���� ����q</br>
    /// <br>Date       : 2012/10/10</br>
    /// <br></br>
    /// <br>Update Note: SCM��Q��10384�Ή�</br>
    /// <br>Programmer : 30744�@���� ����q</br>
    /// <br>Date       : 2013/05/09</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ� 10900690-00 �z�M���Ȃ��� Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή�</br>
    /// <br>Programmer : qijh</br>
    /// <br>Date       : 2013/02/27</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ� 11070266-00 SCM������ SCM������ C������ʓ��L�Ή� </br>
    /// <br>Programmer : �g��</br>
    /// <br>Date       : 2015/02/20</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SCMInquiryDB : RemoteDB, ISCMInquiryDB
    {
        /// <summary>
        /// SCM�₢���킹�ꗗDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public SCMInquiryDB()
            :
        base("PMSCM04007D", "Broadleaf.Application.Remoting.ParamData.SCMInquiryResultWork", "SCMACODRDATARF") //���N���X�̃R���X�g���N�^
        {
        }

        #region SCM�⍇���ꗗ

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        public int Search(out object scmInquiryResultWork, object objscmInquiryOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            scmInquiryResultWork = null;

            SCMInquiryOrderWork scmInquiryOrderWork = objscmInquiryOrderWork as SCMInquiryOrderWork;
            
            try
            {
                status = SearchProc(out scmInquiryResultWork, scmInquiryOrderWork, readMode, logicalMode);
            }

            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.Search Exception=" + ex.Message);
                scmInquiryResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="supplierSendErResultWork">��������</param>
        /// <param name="_supplierSendErOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        private int SearchProc(out object scmInquiryResultWork, SCMInquiryOrderWork scmInquiryOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmInquiryResultWork = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList(); // �`�[���X�g��񒊏o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �`�[��񒊏o
                status = SearchProc(ref retList, ref sqlConnection, scmInquiryOrderWork, logicalMode);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            scmInquiryResultWork = retList;

            return status;
        }

        // -- UPD 2010/04/13 ----------------------------------------------------------->>>
        #region [�폜]
        ///// <summary>
        ///// �������������񐶐��{�����l�ݒ�
        ///// </summary>
        ///// <param name="al">��������ArrayList</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="_supplierSendErOrderCndtnWork">���������i�[�N���X</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        //private int SearchProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryOrderWork scmInquiryOrderWork, ConstantManagement.LogicalMode logicalMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    // �`�[���X�g
        //    CustomSerializeArrayList SlipList = new CustomSerializeArrayList();

        //    try
        //    {
        //        string selectTxt = "";
        //        sqlCommand = new SqlCommand(selectTxt, sqlConnection);

        //        #region Select���쐬
        //        selectTxt += "  SELECT   SCM.CUSTOMERCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CUS.CUSTOMERSNMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ENTERPRISECODERF  " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ACPTANODRSTATUSRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.SALESSLIPNUMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.UPDATEDATERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.UPDATETIMERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORDDIVCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSWERDIVCDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.JUDGEMENTDATERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQORDNOTERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.APPENDINGFILERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.APPENDINGFILENMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQEMPLOYEECDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQEMPLOYEENMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSEMPLOYEECDRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSEMPLOYEENMRF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.INQUIRYDATERF   " + Environment.NewLine;
        //        selectTxt += "          ,SCM.ANSWERCREATEDIVRF  " + Environment.NewLine;
        //        selectTxt += "          ,SCM.SALESTOTALTAXINCRF  " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE1CODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE1NAMERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE2RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE3RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.NUMBERPLATE4RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELDESIGNATIONNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CATEGORYNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MAKERCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELSUBCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MODELNAMERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CARINSPECTCERTMODELRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.FULLMODELRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.FRAMENORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.FRAMEMODELRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CHASSISNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.CARPROPERNORF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.PRODUCETYPEOFYEARNUMRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.COMMENTRF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.RPCOLORCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.COLORNAME1RF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.TRIMCODERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.TRIMNAMERF   " + Environment.NewLine;
        //        selectTxt += "          ,CAR.MILEAGERF   " + Environment.NewLine;
        //        selectTxt += "   FROM SCMACODRDATARF AS SCM   " + Environment.NewLine;
        //        selectTxt += "    INNER JOIN   " + Environment.NewLine;
        //        selectTxt += "    (   " + Environment.NewLine;
        //        selectTxt += "  	  SELECT    " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
        //        //selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
        //        selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQUIRYNUMBERRF    " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
        //        //selectTxt += "  	  ,ACPTANODRSTATUSRF	   " + Environment.NewLine;
        //        //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "  	  FROM SCMACODRDATARF    " + Environment.NewLine;
        //        selectTxt += "  	  GROUP BY    " + Environment.NewLine;
        //        selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "  	  ,INQUIRYNUMBERRF	   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
        //        //// -- 2009/08/13 ------------------------------------------------------->>>
        //        //selectTxt += "  	  ,ACPTANODRSTATUSRF	   " + Environment.NewLine;
        //        //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
        //        //// -- 2009/08/13 -------------------------------------------------------<<<
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "    ) AS SCM2   " + Environment.NewLine;
        //        selectTxt += "    ON   " + Environment.NewLine;
        //        selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF   " + Environment.NewLine;
        //        selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 -------------------------------------------------->>>
        //        //selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF   " + Environment.NewLine;
        //        //selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF   " + Environment.NewLine;
        //        //// -- 2009/08/13 ------------------------------------------------------->>>
        //        //selectTxt += "    AND SCM2.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
        //        //selectTxt += "    AND SCM2.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF  " + Environment.NewLine;
        //        //// -- 2009/08/13 -------------------------------------------------------<<<
        //        selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
        //        // -- UPD 2010/03/11 --------------------------------------------------<<<
        //        selectTxt += "   LEFT JOIN SCMACODRDTCARRF AS CAR   " + Environment.NewLine;
        //        selectTxt += "    ON  " + Environment.NewLine;
        //        selectTxt += "        CAR.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
        //        selectTxt += "    AND CAR.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
        //        selectTxt += "    AND CAR.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
        //        selectTxt += "    AND CAR.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF " + Environment.NewLine;
        //        selectTxt += "    AND CAR.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
        //        selectTxt += "    AND CAR.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF  " + Environment.NewLine;
        //        selectTxt += "   LEFT JOIN CUSTOMERRF AS CUS  " + Environment.NewLine;
        //        selectTxt += "    ON  " + Environment.NewLine;
        //        selectTxt += "        CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
        //        selectTxt += "    AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF  " + Environment.NewLine;



        //        //WHERE���̍쐬
        //        selectTxt += MakeWhereString(ref sqlCommand, scmInquiryOrderWork, logicalMode);

        //        sqlCommand.CommandText = selectTxt;

        //        #endregion

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region ���o����-�l�Z�b�g

        //            // �`�[
        //            SCMInquiryResultWork wkSCMInquiryResultWork = new SCMInquiryResultWork();

        //            #region �i�[����-�`�[
        //            wkSCMInquiryResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); // ��ƃR�[�h
        //            wkSCMInquiryResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
        //            wkSCMInquiryResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // ���Ӑ於��
        //            wkSCMInquiryResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // �󒍃X�e�[�^�X
        //            wkSCMInquiryResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // ����`�[�ԍ�
        //            wkSCMInquiryResultWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));  // �⍇������ƃR�[�h
        //            wkSCMInquiryResultWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // �⍇�������_�R�[�h
        //            wkSCMInquiryResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // �⍇�����ƃR�[�h
        //            wkSCMInquiryResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // �⍇���拒�_�R�[�h
        //            wkSCMInquiryResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // �⍇���ԍ�
        //            wkSCMInquiryResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // �X�V�N����
        //            wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����
        //            wkSCMInquiryResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // �⍇���E�������
        //            wkSCMInquiryResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // �񓚋敪
        //            wkSCMInquiryResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // �m���
        //            wkSCMInquiryResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // �⍇���E�������l
        //            wkSCMInquiryResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // �⍇���]�ƈ��R�[�h
        //            wkSCMInquiryResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // �⍇���]�ƈ�����
        //            wkSCMInquiryResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // �񓚏]�ƈ��R�[�h
        //            wkSCMInquiryResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // �񓚏]�ƈ�����
        //            wkSCMInquiryResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // �⍇����
        //            wkSCMInquiryResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // ���^�������ԍ�
        //            wkSCMInquiryResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // ���^�����ǖ���
        //            wkSCMInquiryResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // �ԗ��o�^�ԍ��i��ʁj
        //            wkSCMInquiryResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // �ԗ��o�^�ԍ��i�J�i�j
        //            wkSCMInquiryResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
        //            wkSCMInquiryResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // �^���w��ԍ�
        //            wkSCMInquiryResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // �ޕʔԍ�
        //            wkSCMInquiryResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // ���[�J�[�R�[�h
        //            wkSCMInquiryResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // �Ԏ�R�[�h
        //            wkSCMInquiryResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // �Ԏ�T�u�R�[�h
        //            wkSCMInquiryResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // �Ԏ햼
        //            wkSCMInquiryResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // �Ԍ��،^��
        //            wkSCMInquiryResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // �^���i�t���^�j
        //            wkSCMInquiryResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // �ԑ�ԍ�
        //            wkSCMInquiryResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // �ԑ�^��
        //            wkSCMInquiryResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // �V���V�[No
        //            wkSCMInquiryResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // �ԗ��ŗL�ԍ�
        //            wkSCMInquiryResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // ���Y�N���iNUM�^�C�v�j
        //            wkSCMInquiryResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // �R�����g
        //            wkSCMInquiryResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // ���y�A�J���[�R�[�h
        //            wkSCMInquiryResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // �J���[����1
        //            wkSCMInquiryResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // �g�����R�[�h
        //            wkSCMInquiryResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // �g��������
        //            wkSCMInquiryResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // �ԗ����s����      
        //            wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����   
        //            wkSCMInquiryResultWork.AwnserMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // �񓚕��@
        //            wkSCMInquiryResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // ����`�[���v�i�ō��݁j
        //            #endregion
        //            #endregion

        //                SlipList.Add(wkSCMInquiryResultWork);

        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //        // �Ō�̓`�[���ǉ�
        //        if (SlipList.Count != 0)
        //        {
        //            retList.Add(SlipList);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (!myReader.IsClosed) myReader.Close();
        //    }

        //    return status;
        //}
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_supplierSendErOrderCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryOrderWork scmInquiryOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // �`�[���X�g
            CustomSerializeArrayList SlipList = new CustomSerializeArrayList();

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "           SCM.CUSTOMERCODERF   " + Environment.NewLine;
                selectTxt += "          ,CUS.CUSTOMERSNMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "          ,SCM.ACPTANODRSTATUSRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.SALESSLIPNUMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORIGINALSECCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.UPDATEDATERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.UPDATETIMERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORDDIVCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSWERDIVCDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.JUDGEMENTDATERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQORDNOTERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.APPENDINGFILERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.APPENDINGFILENMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQEMPLOYEECDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQEMPLOYEENMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSEMPLOYEECDRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSEMPLOYEENMRF   " + Environment.NewLine;
                selectTxt += "          ,SCM.INQUIRYDATERF   " + Environment.NewLine;
                selectTxt += "          ,SCM.ANSWERCREATEDIVRF  " + Environment.NewLine;
                selectTxt += "          ,SCM.ACCEPTORORDERKINDRF  " + Environment.NewLine; // ADD gezh 2011/11/12
                selectTxt += "          ,SCM.SALESTOTALTAXINCRF  " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE1CODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE1NAMERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE2RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE3RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.NUMBERPLATE4RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELDESIGNATIONNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CATEGORYNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MAKERCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELSUBCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MODELNAMERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CARINSPECTCERTMODELRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.FULLMODELRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.FRAMENORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.FRAMEMODELRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CHASSISNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.CARPROPERNORF   " + Environment.NewLine;
                selectTxt += "          ,CAR.PRODUCETYPEOFYEARNUMRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.COMMENTRF   " + Environment.NewLine;
                selectTxt += "          ,CAR.RPCOLORCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.COLORNAME1RF   " + Environment.NewLine;
                selectTxt += "          ,CAR.TRIMCODERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.TRIMNAMERF   " + Environment.NewLine;
                selectTxt += "          ,CAR.MILEAGERF   " + Environment.NewLine;
                // -- ADD 2010/06/17 ----------------------------------->>>
                selectTxt += "          ,SCM.CANCELDIVRF" + Environment.NewLine;
                selectTxt += "          ,SCM.CMTCOOPRTDIVRF" + Environment.NewLine;
                // -- ADD 2010/06/17 -----------------------------------<<<
                // -- ADD 2011/05/26 ----------------------------------->>>
                selectTxt += "          ,SCM.SFPMCPRTINSTSLIPNORF" + Environment.NewLine;
                // -- ADD 2011/05/26 -----------------------------------<<<
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                selectTxt += "          ,SCM.AUTOANSWERCOUNT" + Environment.NewLine;
                selectTxt += "          ,SCM.MANUALANSWERCOUNT" + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
                selectTxt += "          ,CAR.EXPECTEDCEDATERF   " + Environment.NewLine;
                // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
                selectTxt += "   FROM " + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "      --�L�����Z���ȊO�̃f�[�^�擾�p" + Environment.NewLine;
                selectTxt += "      SELECT" + Environment.NewLine;
                selectTxt += "         SCM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALEPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHEREPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYNUMBERRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSWERDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.JUDGEMENTDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDNOTERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSUBTOTALTAXRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDANSDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.RECEIVEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSWERCREATEDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACCEPTORORDERKINDRF  " + Environment.NewLine; // ADD gezh 2011/11/12
                // -- ADD 2010/06/17 ----------------------------------->>>
                selectTxt += "        ,SCM2.CANCELDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CMTCOOPRTDIVRF" + Environment.NewLine;
                // -- ADD 2010/06/17 -----------------------------------<<<
                // -- ADD 2011/05/26 ----------------------------------->>>
                selectTxt += "        ,SCM2.SFPMCPRTINSTSLIPNORF" + Environment.NewLine;
                // -- ADD 2011/05/26 -----------------------------------<<<
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                selectTxt += "        ,SCM3.AUTOANSWERCOUNT" + Environment.NewLine;
                selectTxt += "        ,SCM3.MANUALANSWERCOUNT" + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                selectTxt += "      FROM SCMACODRDATARF AS SCM2 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "      INNER JOIN   " + Environment.NewLine;
                selectTxt += "      (   " + Environment.NewLine;
                // UPD 2012/07/27 T.Yoshioka 2012/08/07�z�M�V�X�e���e�X�g��126�Ή� ------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "          SELECT " + Environment.NewLine;
                selectTxt += "            MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "            , MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF " + Environment.NewLine;
                selectTxt += "            , T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                selectTxt += "            , MAX(ISNULL(AUTOANSWERCOUNT,0)) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "            , MAX(ISNULL(MANUALANSWERCOUNT,0)) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                selectTxt += "          FROM " + Environment.NewLine;
                selectTxt += "            SCMACODRDATARF T1 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "            INNER JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT " + Environment.NewLine;
                selectTxt += "                MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T2  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T2.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T2.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T2.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T2.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T2.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T2.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T2.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              AND CAST (T1.UPDATEDATERF AS NVARCHAR) +  RIGHT ( '000000000' + CAST (T1.UPDATETIMERF AS NVARCHAR), 9) = T2.UPDATEDATETIMERF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 0  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T3  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T3.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T3.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T3.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T3.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T3.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T3.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T3.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 2  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T4  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T4.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T4.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T4.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T4.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T4.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T4.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T4.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                selectTxt += "          WHERE " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "            AND CANCELDIVRF <> 1  " + Environment.NewLine;
                selectTxt += "          GROUP BY " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF " + Environment.NewLine;
                # region ��SQL
                //selectTxt += "  	  SELECT    " + Environment.NewLine;
                //// -- UPD 2010/06/17 --------------------------------------->>>
                ////selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/06/17 ---------------------------------------<<<
                //// ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami ------------------------------------------->>>>>
                //selectTxt += "  	  ,MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF   " + Environment.NewLine;
                //// ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami -------------------------------------------<<<<<
                //selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF    " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	  ,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                //selectTxt += "  	  FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                //selectTxt += "        WHERE" + Environment.NewLine;
                //selectTxt += "              ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                //// 2011/02/18 >>>
                ////selectTxt += "          AND ANSWERDIVCDRF <> 99    " + Environment.NewLine; //99:�L�����Z���ȊO
                //selectTxt += "          AND CANCELDIVRF <> 1    " + Environment.NewLine; //1:�L�����Z���ȊO
                //// 2011/02/18 <<<
                //selectTxt += "  	  GROUP BY    " + Environment.NewLine;
                //selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF	   " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	  ,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                # endregion
                // UPD 2012/07/27 T.Yoshioka 2012/08/07�z�M�V�X�e���e�X�g��126�Ή� -------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                selectTxt += "      ) AS SCM3   " + Environment.NewLine;
                selectTxt += "      ON   " + Environment.NewLine;
                selectTxt += "          SCM3.ENTERPRISECODERF = SCM2.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALEPCDRF = SCM2.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALSECCDRF = SCM2.INQORIGINALSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHEREPCDRF = SCM2.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHERSECCDRF = SCM2.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQUIRYNUMBERRF = SCM2.INQUIRYNUMBERRF   " + Environment.NewLine;
                // -- UPD 2010/06/17 ------------------------------------------->>>
                //selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + cast(SCM2.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM2.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                // -- UPD 2010/06/17 -------------------------------------------<<<
                // 2011/01/24 Add >>>
                selectTxt += "      AND SCM3.INQORDDIVCDRF = SCM2.INQORDDIVCDRF   " + Environment.NewLine;
                // 2011/01/24 Add <<<
                // ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami ------------------------------------------->>>>>
                selectTxt += "  	AND SCM3.SALESSLIPNUMRF = SCM2.SALESSLIPNUMRF   " + Environment.NewLine;
                // ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami -------------------------------------------<<<<<
                selectTxt += "    UNION ALL " + Environment.NewLine;
                selectTxt += "      --�L�����Z���f�[�^�擾�p" + Environment.NewLine;
                selectTxt += "      SELECT" + Environment.NewLine;
                selectTxt += "         SCM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALEPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORIGINALSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHEREPCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYNUMBERRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.UPDATETIMERF" + Environment.NewLine;
                // 2011/02/18 >>>
                //selectTxt += "        ,SCM2.ANSWERDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,99 AS ANSWERDIVCDRF" + Environment.NewLine;
                // 2011/02/18 <<<
                selectTxt += "        ,SCM2.JUDGEMENTDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDNOTERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.APPENDINGFILENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQUIRYDATERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.SALESSUBTOTALTAXRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.INQORDANSDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.RECEIVEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ANSWERCREATEDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.ACCEPTORORDERKINDRF  " + Environment.NewLine; // ADD gezh 2011/11/12
                // -- ADD 2010/06/17 ----------------------------------->>>
                selectTxt += "        ,SCM2.CANCELDIVRF" + Environment.NewLine;
                selectTxt += "        ,SCM2.CMTCOOPRTDIVRF" + Environment.NewLine;
                // -- ADD 2010/06/17 -----------------------------------<<<
                // -- ADD 2011/05/26 ----------------------------------->>>
                selectTxt += "        ,SCM2.SFPMCPRTINSTSLIPNORF" + Environment.NewLine;
                // -- ADD 2011/05/26 -----------------------------------<<<
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                selectTxt += "        ,SCM3.AUTOANSWERCOUNT" + Environment.NewLine;
                selectTxt += "        ,SCM3.MANUALANSWERCOUNT" + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                selectTxt += "      FROM SCMACODRDATARF AS SCM2 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "      --�ŐV�̃L�����Z���f�[�^���擾" + Environment.NewLine;
                selectTxt += "      INNER JOIN   " + Environment.NewLine;
                selectTxt += "      (   " + Environment.NewLine;

                // UPD 2012/07/27 T.Yoshioka 2012/08/07�z�M�V�X�e���e�X�g��126�Ή� ------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "          SELECT " + Environment.NewLine;
                selectTxt += "            MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "            , MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF " + Environment.NewLine;
                selectTxt += "            , T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                selectTxt += "            , MAX(ISNULL(AUTOANSWERCOUNT,0)) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "            , MAX(ISNULL(MANUALANSWERCOUNT,0)) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                selectTxt += "          FROM " + Environment.NewLine;
                selectTxt += "            SCMACODRDATARF T1 WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "            INNER JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT " + Environment.NewLine;
                selectTxt += "                MAX( CAST (UPDATEDATERF AS NVARCHAR) + RIGHT ('000000000' + CAST (UPDATETIMERF AS NVARCHAR), 9 )) AS UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T2  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T2.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T2.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T2.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T2.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T2.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T2.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T2.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              AND CAST (T1.UPDATEDATERF AS NVARCHAR) +  RIGHT ( '000000000' + CAST (T1.UPDATETIMERF AS NVARCHAR), 9) = T2.UPDATEDATETIMERF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS AUTOANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 0  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T3  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T3.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T3.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T3.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T3.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T3.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T3.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T3.INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "            LEFT JOIN (  " + Environment.NewLine;
                selectTxt += "              SELECT  " + Environment.NewLine;
                selectTxt += "                  COUNT(ANSWERCREATEDIVRF) AS MANUALANSWERCOUNT  " + Environment.NewLine;
                selectTxt += "                , ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF  " + Environment.NewLine;
                selectTxt += "              FROM  " + Environment.NewLine;
                selectTxt += "                SCMACODRDATARF WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "              WHERE  " + Environment.NewLine;
                selectTxt += "                ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "                AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "                AND ANSWERCREATEDIVRF = 2  " + Environment.NewLine;
                selectTxt += "              GROUP BY " + Environment.NewLine;
                selectTxt += "                  ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "                , INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "                , INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "                , INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "                , INQORDDIVCDRF " + Environment.NewLine;
                selectTxt += "            ) T4  " + Environment.NewLine;
                selectTxt += "              ON T1.ENTERPRISECODERF = T4.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALEPCDRF = T4.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORIGINALSECCDRF = T4.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHEREPCDRF = T4.INQOTHEREPCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQOTHERSECCDRF = T4.INQOTHERSECCDRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQUIRYNUMBERRF = T4.INQUIRYNUMBERRF  " + Environment.NewLine;
                selectTxt += "              AND T1.INQORDDIVCDRF = T4.INQORDDIVCDRF  " + Environment.NewLine;
                //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                selectTxt += "          WHERE " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                selectTxt += "            AND CANCELDIVRF = 1  " + Environment.NewLine;
                selectTxt += "          GROUP BY " + Environment.NewLine;
                selectTxt += "            T1.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALEPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORIGINALSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHEREPCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQOTHERSECCDRF " + Environment.NewLine;
                selectTxt += "            , T1.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "            , T1.INQORDDIVCDRF " + Environment.NewLine;
                # region ��SQL
                //selectTxt += "      SELECT    " + Environment.NewLine;
                //// -- UPD 2010/06/17 --------------------------------->>>
                ////selectTxt += "       MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //selectTxt += "       MAX(cast(UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/06/17 ---------------------------------<<<
                //// ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami ------------------------------------------->>>>>
                //selectTxt += "  	,MAX(SALESSLIPNUMRF) AS SALESSLIPNUMRF   " + Environment.NewLine;
                //// ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami -------------------------------------------<<<<<
                //selectTxt += "      ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQUIRYNUMBERRF    " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                //selectTxt += "      FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                //selectTxt += "        WHERE" + Environment.NewLine;
                //selectTxt += "              ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                //// 2011/02/18 >>>
                ////selectTxt += "          AND ANSWERDIVCDRF = 99   " + Environment.NewLine;
                ////selectTxt += "          AND INQORDDIVCDRF = 2    " + Environment.NewLine;
                //selectTxt += "          AND CANCELDIVRF = 1   " + Environment.NewLine;
                //// 2011/02/18 <<<
                //selectTxt += "      GROUP BY    " + Environment.NewLine;
                //selectTxt += "       ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQOTHERSECCDRF   " + Environment.NewLine;
                //selectTxt += "      ,INQUIRYNUMBERRF     " + Environment.NewLine;
                //// 2011/01/24 Add >>>
                //selectTxt += "  	,INQORDDIVCDRF	   " + Environment.NewLine;
                //// 2011/01/24 Add <<<
                #endregion
                // UPD 2012/07/27 T.Yoshioka 2012/08/07�z�M�V�X�e���e�X�g��126�Ή� -------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                selectTxt += "      ) AS SCM3   " + Environment.NewLine;
                selectTxt += "      ON   " + Environment.NewLine;
                selectTxt += "          SCM3.ENTERPRISECODERF = SCM2.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALEPCDRF = SCM2.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQORIGINALSECCDRF = SCM2.INQORIGINALSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHEREPCDRF = SCM2.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQOTHERSECCDRF = SCM2.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "      AND SCM3.INQUIRYNUMBERRF = SCM2.INQUIRYNUMBERRF   " + Environment.NewLine;
                // -- UPD 2010/06/17 ----------------------------------------->>>
                //selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + cast(SCM2.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                selectTxt += "      AND SCM3.UPDATEDATETIMERF = (cast(SCM2.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM2.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                // -- UPD 2010/06/17 -----------------------------------------<<<
                // 2011/01/24 Add >>>
                selectTxt += "      AND SCM3.INQORDDIVCDRF = SCM2.INQORDDIVCDRF   " + Environment.NewLine;
                // 2011/01/24 Add <<<
                // ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami ------------------------------------------->>>>>
                selectTxt += "  	AND SCM3.SALESSLIPNUMRF = SCM2.SALESSLIPNUMRF   " + Environment.NewLine;
                // ADD 2012/07/18 �V�X�e���e�X�g��QNo.101  yugami -------------------------------------------<<<<<
                selectTxt += "    ) AS SCM   " + Environment.NewLine;
                selectTxt += "   LEFT JOIN SCMACODRDTCARRF AS CAR WITH (READUNCOMMITTED)  " + Environment.NewLine;
                selectTxt += "    ON  " + Environment.NewLine;
                selectTxt += "        CAR.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "    AND CAR.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                selectTxt += "    AND CAR.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                selectTxt += "    AND CAR.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF " + Environment.NewLine;
                selectTxt += "    AND CAR.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF " + Environment.NewLine;
                selectTxt += "    AND CAR.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                selectTxt += "   LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "    ON  " + Environment.NewLine;
                selectTxt += "        CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "    AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF  " + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, scmInquiryOrderWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(Broadleaf.Library.Diagnostics.NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g

                    // �`�[
                    SCMInquiryResultWork wkSCMInquiryResultWork = new SCMInquiryResultWork();

                    #region �i�[����-�`�[
                    wkSCMInquiryResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF")); // ��ƃR�[�h
                    wkSCMInquiryResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
                    wkSCMInquiryResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // ���Ӑ於��
                    wkSCMInquiryResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // �󒍃X�e�[�^�X
                    wkSCMInquiryResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // ����`�[�ԍ�
                    wkSCMInquiryResultWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();  // �⍇������ƃR�[�h//@@@@20230303
                    wkSCMInquiryResultWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // �⍇�������_�R�[�h
                    wkSCMInquiryResultWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));  // �⍇�����ƃR�[�h
                    wkSCMInquiryResultWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));  // �⍇���拒�_�R�[�h
                    wkSCMInquiryResultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // �⍇���ԍ�
                    wkSCMInquiryResultWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // �X�V�N����
                    wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����
                    wkSCMInquiryResultWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // �⍇���E�������
                    wkSCMInquiryResultWork.AnswerDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));  // �񓚋敪
                    wkSCMInquiryResultWork.JudgementDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));  // �m���
                    wkSCMInquiryResultWork.InqOrdNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));  // �⍇���E�������l
                    wkSCMInquiryResultWork.InqEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));  // �⍇���]�ƈ��R�[�h
                    wkSCMInquiryResultWork.InqEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));  // �⍇���]�ƈ�����
                    wkSCMInquiryResultWork.AnsEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));  // �񓚏]�ƈ��R�[�h
                    wkSCMInquiryResultWork.AnsEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));  // �񓚏]�ƈ�����
                    wkSCMInquiryResultWork.InquiryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQUIRYDATERF"));  // �⍇����
                    wkSCMInquiryResultWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));  // ���^�������ԍ�
                    wkSCMInquiryResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));  // ���^�����ǖ���
                    wkSCMInquiryResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));  // �ԗ��o�^�ԍ��i��ʁj
                    wkSCMInquiryResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));  // �ԗ��o�^�ԍ��i�J�i�j
                    wkSCMInquiryResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));  // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                    wkSCMInquiryResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));  // �^���w��ԍ�
                    wkSCMInquiryResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));  // �ޕʔԍ�
                    wkSCMInquiryResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));  // ���[�J�[�R�[�h
                    wkSCMInquiryResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));  // �Ԏ�R�[�h
                    wkSCMInquiryResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));  // �Ԏ�T�u�R�[�h
                    wkSCMInquiryResultWork.ModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));  // �Ԏ햼
                    wkSCMInquiryResultWork.CarInspectCertModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));  // �Ԍ��،^��
                    wkSCMInquiryResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));  // �^���i�t���^�j
                    wkSCMInquiryResultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));  // �ԑ�ԍ�
                    wkSCMInquiryResultWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));  // �ԑ�^��
                    wkSCMInquiryResultWork.ChassisNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));  // �V���V�[No
                    wkSCMInquiryResultWork.CarProperNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));  // �ԗ��ŗL�ԍ�
                    wkSCMInquiryResultWork.ProduceTypeOfYearNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));  // ���Y�N���iNUM�^�C�v�j
                    wkSCMInquiryResultWork.Comment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));  // �R�����g
                    wkSCMInquiryResultWork.RpColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));  // ���y�A�J���[�R�[�h
                    wkSCMInquiryResultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));  // �J���[����1
                    wkSCMInquiryResultWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));  // �g�����R�[�h
                    wkSCMInquiryResultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));  // �g��������
                    wkSCMInquiryResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));  // �ԗ����s����      
                    wkSCMInquiryResultWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����   
                    wkSCMInquiryResultWork.AwnserMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERCREATEDIVRF"));  // �񓚕��@
                    wkSCMInquiryResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));  // ����`�[���v�i�ō��݁j
                    // -- UPD 2010/06/17 ------------------------------------------------->>>
                    wkSCMInquiryResultWork.CancelDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CANCELDIVRF"));  // �L�����Z���敪
                    wkSCMInquiryResultWork.CMTCooprtDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CMTCOOPRTDIVRF"));  // CMT�A�g�敪
                    // -- UPD 2010/06/17 -------------------------------------------------<<<
                    wkSCMInquiryResultWork.SfPmCprtInstSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SFPMCPRTINSTSLIPNORF"));  // SF-PM�A�g�w�����ԍ�
                    // -- ADD gezh 2011/11/12 ------------------------------------------------->>>>>
                    wkSCMInquiryResultWork.CooperationOptionDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF"));  // �A�g�Ώۋ敪
                    // -- ADD gezh 2011/11/12 -------------------------------------------------<<<<<
                    //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
                    wkSCMInquiryResultWork.AutoAnswerCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERCOUNT"));  // �񓚕��@�����i�����񓚕��j
                    wkSCMInquiryResultWork.ManualAnswerCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MANUALANSWERCOUNT"));  // �񓚕��@�����i�蓮�񓚕��j
                    //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<
                    // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
                    wkSCMInquiryResultWork.ExpectedCeDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPECTEDCEDATERF"));  // ���ɗ\���
                    // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
                    #endregion
                    #endregion

                    SlipList.Add(wkSCMInquiryResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // �Ō�̓`�[���ǉ�
                if (SlipList.Count != 0)
                {
                    retList.Add(SlipList);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�L�����Z���ȊO���A�L�����Z�����̗����j
        /// </summary>
        /// <param name="scmInquiryResultWork">�L�����Z���ȊO���̌�������</param>
        /// <param name="scmInquiryResultWorkCancel">�L�����Z�����̌�������</param>
        /// <param name="objscmInquiryResultWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�L�����Z���ȊO���A�L�����Z�����̗����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010/04/13</br>
        public int SearchDetailAll(out object scmInquiryResultWork, out object scmInquiryResultWorkCancel, object objscmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            scmInquiryResultWork = null;
            scmInquiryResultWorkCancel = null;

            SCMInquiryResultWork parascmInquiryResultWork = objscmInquiryResultWork as SCMInquiryResultWork;

            try
            {
                status = SearchDetailAllProc(out scmInquiryResultWork, out scmInquiryResultWorkCancel, parascmInquiryResultWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailAll Exception=" + ex.Message);
                scmInquiryResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�L�����Z���ȊO���A�L�����Z�����̗����j
        /// </summary>
        /// <param name="scmInquiryResultWork">�L�����Z���ȊO���̌�������</param>
        /// <param name="scmInquiryResultWorkCancel">�L�����Z�����̌�������</param>
        /// <param name="objscmInquiryResultWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010/04/13</br>
        private int SearchDetailAllProc(out object scmInquiryResultWork, out object scmInquiryResultWorkCancel, SCMInquiryResultWork parascmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmInquiryResultWork = null;
            scmInquiryResultWorkCancel = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList(); // �L�����Z���ȊO�̖��ג��o����
            CustomSerializeArrayList retCancelList = new CustomSerializeArrayList(); // �L�����Z���̖��ג��o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�L�����Z�����̒��o
                parascmInquiryResultWork.AnswerDivCd = 20;  //�p�����[�^�̓L�����Z���ȊO�Ȃ�Ȃ�ł��������A�Ƃ肠����20:�񓚊������Z�b�g

                // �₢���킹���o
                status = SearchDetailInqProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                // �񓚒��o
                status = SearchDetailAnsProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                //�L�����Z�����̒��o
                parascmInquiryResultWork.AnswerDivCd = 99;  //99:�L�����Z��

                // �₢���킹���o
                status = SearchDetailInqProc(ref retCancelList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                // �񓚒��o
                status = SearchDetailAnsProc(ref retCancelList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                //�񓚂��Ȃ��Ă�����Ƃ���
                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF && (retList.Count > 0 || retCancelList.Count > 0))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailAllProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            scmInquiryResultWork = retList;
            scmInquiryResultWorkCancel = retCancelList;

            return status;
        }
        // -- UPD 2010/04/13 -----------------------------------------------------------<<<

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierUnmResultWork">��������</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        public int SearchDetail(out object scmInquiryResultWork, object objscmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            scmInquiryResultWork = null;

            SCMInquiryResultWork parascmInquiryResultWork = objscmInquiryResultWork as SCMInquiryResultWork;

            try
            {
                status = SearchDetailProc(out scmInquiryResultWork, parascmInquiryResultWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetail Exception=" + ex.Message);
                scmInquiryResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="supplierSendErResultWork">��������</param>
        /// <param name="_supplierSendErOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        private int SearchDetailProc(out object scmInquiryResultWork, SCMInquiryResultWork parascmInquiryResultWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            scmInquiryResultWork = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList(); // �`�[���X�g��񒊏o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �₢���킹���o
                status = SearchDetailInqProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                // �񓚒��o
                status = SearchDetailAnsProc(ref retList, ref sqlConnection, parascmInquiryResultWork, logicalMode);

                //�񓚂��Ȃ��Ă�����Ƃ���
                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF && retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            scmInquiryResultWork = retList;

            return status;
        }

        /// <summary>
        /// �₢���킹���ג��o
        /// </summary>
        /// <param name="retList">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="parascmInquiryResultWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchDetailInqProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryResultWork parascmInquiryResultWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // �`�[���X�g
            CustomSerializeArrayList DetailList = new CustomSerializeArrayList();

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                // -- UPD 2010/04/13-------------------------------->>>
                #region [�폜]
                //selectTxt += "  SELECT " + Environment.NewLine;
                //selectTxt += " 	    SCM.ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "	   ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.ANSWERDELIVERYDATERF  " + Environment.NewLine;
                //// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                //// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "   FROM SCMACODRDTLIQRF AS SCM " + Environment.NewLine;
                //selectTxt += "    INNER JOIN   " + Environment.NewLine;
                //selectTxt += "    (   " + Environment.NewLine;
                //selectTxt += "  	 SELECT    " + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
                ////selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
                //selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "  	 FROM SCMACODRDTLIQRF    " + Environment.NewLine;
                //selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                //selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                //selectTxt += "    ON   " + Environment.NewLine;
                //selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                ////selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                //selectTxt += "  WHERE  " + Environment.NewLine;
                //selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                #endregion

                if (parascmInquiryResultWork.AnswerDivCd != 99)
                {
                    //�L�����Z���ȊO�̒��o�N�G��
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += " 	    SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "	   ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERDELIVERYDATERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // -- ADD 2010/06/17 ------------------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF" + Environment.NewLine;
                    // -- ADD 2010/06/17 -------------------------------------<<<
                    //--- ADD 2011/05/26 ------------------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------------------<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF " + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLIQRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "    INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    // -- UPD 2010/06/17 ----------------------------->>>
                    //selectTxt += "  	   MAX(cast(SCMIQ.UPDATEDATERF as nvarchar) + cast(SCMIQ.UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    selectTxt += "  	   MAX(cast(SCMIQ.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCMIQ.UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    // -- UPD 2010/06/17 -----------------------------<<<
                    selectTxt += "  	  ,SCMIQ.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDTLIQRF AS SCMIQ WITH (READUNCOMMITTED)  " + Environment.NewLine;
                    selectTxt += "       INNER JOIN   " + Environment.NewLine;
                    selectTxt += "       (   " + Environment.NewLine;
                    selectTxt += "         SELECT    " + Environment.NewLine;
                    selectTxt += "  	     ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "          ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	   FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "         WHERE" + Environment.NewLine;
                    selectTxt += "             ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/01/24 Add >>>
                    selectTxt += "             AND INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "             AND INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "             AND INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "             AND INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "             AND INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "             AND INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                    // 2011/01/24 Add <<<
                    // 2011/02/18 >>>
                    //selectTxt += "         AND ANSWERDIVCDRF <> 99   " + Environment.NewLine;
                    selectTxt += "         AND CANCELDIVRF <> 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "       ) AS SCMODR   " + Environment.NewLine;
                    selectTxt += "       ON   " + Environment.NewLine;
                    selectTxt += "           SCMODR.ENTERPRISECODERF = SCMIQ.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALEPCDRF = SCMIQ.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALSECCDRF = SCMIQ.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHEREPCDRF = SCMIQ.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHERSECCDRF = SCMIQ.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQUIRYNUMBERRF = SCMIQ.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATEDATERF = SCMIQ.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATETIMERF = SCMIQ.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                    selectTxt += "  	   SCMIQ.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMIQ.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    // -- UPD 2010/06/17 ----------------------------------->>>
                    //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                    // -- UPD 2010/06/17 -----------------------------------<<<
                    selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                }
                else
                {
                    //�L�����Z�����̒��o�N�G��
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += " 	    SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "	   ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERDELIVERYDATERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // -- ADD 2010/06/17 ------------------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF" + Environment.NewLine;
                    // -- ADD 2010/06/17 -------------------------------------<<<
                    //--- ADD 2011/05/26 ------------------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------------------<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLIQRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "   INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "       WHERE" + Environment.NewLine;
                    selectTxt += "             ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/02/18 >>>
                    //selectTxt += "         AND ANSWERDIVCDRF = 99   " + Environment.NewLine;
                    selectTxt += "         AND CANCELDIVRF = 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                }
                // -- UPD 2010/04/13--------------------------------<<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.EnterpriseCode);

                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalEpCd);

                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalSecCd);

                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherEpCd);

                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherSecCd);

                SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
                paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(parascmInquiryResultWork.InquiryNumber);

                SqlParameter paraInqOrdDivCd = sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
                paraInqOrdDivCd.Value = SqlDataMediator.SqlSetInt32(parascmInquiryResultWork.InqOrdDivCd);

                //selectTxt += " 	GROUP BY   " + Environment.NewLine;
                //selectTxt += " 	    ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "     ,INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "	   ,INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "	   ,INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,ANSPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "     ,LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQORDDIVCDRF  " + Environment.NewLine;
                //selectTxt += "     ,ANSWERDELIVERYDATERF  " + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    // ����-�⍇��
                    SCMInquiryDtlInqResultWork wkSCMInquiryDtlResultInqWork = new SCMInquiryDtlInqResultWork();

                    wkSCMInquiryDtlResultInqWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();  // �⍇������ƃR�[�h//@@@@20230303
                    wkSCMInquiryDtlResultInqWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // �⍇�������_�R�[�h
                    wkSCMInquiryDtlResultInqWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // �⍇���ԍ�
                    wkSCMInquiryDtlResultInqWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // �X�V�N����
                    wkSCMInquiryDtlResultInqWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����
                    wkSCMInquiryDtlResultInqWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));  // �⍇���s�ԍ�
                    wkSCMInquiryDtlResultInqWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));  // �⍇���s�ԍ��}��
                    wkSCMInquiryDtlResultInqWork.InqOrgDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQORGDTLDISCGUIDRF"));  // �⍇�������׎���GUID
                    wkSCMInquiryDtlResultInqWork.InqOthDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQOTHDTLDISCGUIDRF"));  // �⍇���斾�׎���GUID
                    wkSCMInquiryDtlResultInqWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));  // ���i���
                    wkSCMInquiryDtlResultInqWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // �[�i�敪
                    wkSCMInquiryDtlResultInqWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));  // �戵�敪
                    wkSCMInquiryDtlResultInqWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));  // ���i�`��
                    wkSCMInquiryDtlResultInqWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));  // �[�i�m�F�敪
                    wkSCMInquiryDtlResultInqWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // �[�i�����\���
                    wkSCMInquiryDtlResultInqWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL���i�R�[�h
                    wkSCMInquiryDtlResultInqWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));  // BL���i�R�[�h�}��
                    wkSCMInquiryDtlResultInqWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF"));  // �┭���i����
                    wkSCMInquiryDtlResultInqWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF"));  // �񓚏��i����
                    wkSCMInquiryDtlResultInqWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));  // ������
                    wkSCMInquiryDtlResultInqWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));  // �[�i��
                    wkSCMInquiryDtlResultInqWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // ���i�ԍ�
                    wkSCMInquiryDtlResultInqWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // ���i���[�J�[�R�[�h
                    wkSCMInquiryDtlResultInqWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));  // �������i���[�J�[�R�[�h
                    wkSCMInquiryDtlResultInqWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF")); // �┭�������i�ԍ�
                    wkSCMInquiryDtlResultInqWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF")); // �񓚏������i�ԍ�
                    wkSCMInquiryDtlResultInqWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));  // �艿
                    wkSCMInquiryDtlResultInqWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));  // �P��
                    wkSCMInquiryDtlResultInqWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));  // ���i�⑫���
                    wkSCMInquiryDtlResultInqWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));  // �e���z
                    wkSCMInquiryDtlResultInqWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));  // �e����
                    wkSCMInquiryDtlResultInqWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));  // �񓚊���
                    wkSCMInquiryDtlResultInqWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));  // ���l(����)
                    wkSCMInquiryDtlResultInqWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));  // �I��
                    wkSCMInquiryDtlResultInqWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));  // �ǉ��敪
                    wkSCMInquiryDtlResultInqWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));  // �����敪   
                    wkSCMInquiryDtlResultInqWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // �⍇���E�������  
                    wkSCMInquiryDtlResultInqWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
                    wkSCMInquiryDtlResultInqWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVERYDATERF"));  // �񓚔[��
                    // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultInqWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));  // ���T�C�N�����i���
                    wkSCMInquiryDtlResultInqWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));  // ���T�C�N�����i��ʖ���
                    // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // -- ADD 2010/06/17 ----------------------------------------->>>
                    wkSCMInquiryDtlResultInqWork.CancelCndtinDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CANCELCNDTINDIVRF"));  // �L�����Z����ԋ敪
                    wkSCMInquiryDtlResultInqWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // �󒍃X�e�[�^�X
                    wkSCMInquiryDtlResultInqWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // ����`�[�ԍ�
                    wkSCMInquiryDtlResultInqWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));  // ����s�ԍ�
                    // -- ADD 2010/06/17 -----------------------------------------<<<

                    //--- ADD 2011/05/26 ------------------------------------->>>
                    wkSCMInquiryDtlResultInqWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));  // �q�ɃR�[�h
                    wkSCMInquiryDtlResultInqWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));  // �q�ɖ���
                    wkSCMInquiryDtlResultInqWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));  // �q�ɒI��
                    //--- ADD 2011/05/26 -------------------------------------<<<

                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    wkSCMInquiryDtlResultInqWork.PmMainMngWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSECDRF"));  // PM��Ǒq�ɃR�[�h
                    wkSCMInquiryDtlResultInqWork.PmMainMngWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSENAMERF"));  // PM��Ǒq�ɖ���
                    wkSCMInquiryDtlResultInqWork.PmMainMngShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGSHELFNORF"));  // PM��ǒI��
                    wkSCMInquiryDtlResultInqWork.PmMainMngPrsntCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMMAINMNGPRSNTCOUNTRF"));  // PM��ǌ��݌�
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultInqWork.GoodsSpecialNtForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORFACRF"));  // ���i�K�i�E���L����(�H�����)
                    wkSCMInquiryDtlResultInqWork.GoodsSpecialNtForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORCOWRF"));  // ���i�K�i�E���L����(�J�[�I�[�i�[����)
                    wkSCMInquiryDtlResultInqWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));  // �D�ǐݒ�ڍז��̂Q(�H�����)
                    wkSCMInquiryDtlResultInqWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));  // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<

                    DetailList.Add(wkSCMInquiryDtlResultInqWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // �Ō�̓`�[���ǉ�
                if (DetailList.Count != 0)
                {
                    retList.Add(DetailList);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailInqProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �񓚖��ג��o
        /// </summary>
        /// <param name="retList">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="parascmInquiryResultWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchDetailAnsProc(ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection, SCMInquiryResultWork parascmInquiryResultWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // �`�[���X�g
            CustomSerializeArrayList DetailList = new CustomSerializeArrayList();

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                // -- UPD 2010/04/13-------------------------------->>>
                #region[�폜]
                //selectTxt += "  SELECT " + Environment.NewLine;
                //selectTxt += "      SCM.ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += " 	   ,SCM.ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SCM.SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.CAMPAIGNCODERF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.STOCKDIVRF  " + Environment.NewLine;
                //// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                //selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                //// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //selectTxt += "   FROM SCMACODRDTLASRF AS SCM" + Environment.NewLine;
                //selectTxt += "    INNER JOIN   " + Environment.NewLine;
                //selectTxt += "    (   " + Environment.NewLine;
                //selectTxt += "  	 SELECT    " + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
                ////selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
                //selectTxt += "  	   MAX(cast(UPDATEDATERF as nvarchar) + cast(UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "  	  ,ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "  	 FROM SCMACODRDTLASRF    " + Environment.NewLine;
                //selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                //selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                //selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                //selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMBERRF	   " + Environment.NewLine;
                //selectTxt += "  	  ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += "  	  ,ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "  	  ,SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                //selectTxt += "    ON   " + Environment.NewLine;
                //selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                //// -- UPD 2010/03/11 -------------------------------------------------->>>
                ////selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                ////selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                //// -- UPD 2010/03/11 --------------------------------------------------<<<
                //selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF" + Environment.NewLine;
                //selectTxt += "    AND SCM2.SALESROWNORF = SCM.SALESROWNORF" + Environment.NewLine;

                //selectTxt += "  WHERE  " + Environment.NewLine;
                //selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                //selectTxt += "    AND SCM.ACPTANODRSTATUSRF = @ACPTANODRSTATUS " + Environment.NewLine;
                //selectTxt += "    AND SCM.SALESSLIPNUMRF = @SALESSLIPNUM " + Environment.NewLine;
                #endregion

                if (parascmInquiryResultWork.AnswerDivCd != 99)
                {
                    //�L�����Z���ȊO�̒��o�N�G��
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += "      SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.CAMPAIGNCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.STOCKDIVRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // 2010/05/27 Add >>>
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    // 2010/05/27 Add <<<
                    // -- ADD 2010/06/17 -------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    // -- ADD 2010/06/17 --------------------------<<<
                    //--- ADD 2011/05/26 -------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------->>>
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLASRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "    INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    // -- UPD 2010/06/17 --------------------------------------->>>
                    //selectTxt += "  	   MAX(cast(SCMAS.UPDATEDATERF as nvarchar) + cast(SCMAS.UPDATETIMERF as nvarchar)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    selectTxt += "  	   MAX(cast(SCMAS.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCMAS.UPDATETIMERF as nvarchar),9)) AS UPDATEDATETIMERF   " + Environment.NewLine;
                    // -- UPD 2010/06/17 ---------------------------------------<<<
                    selectTxt += "  	  ,SCMAS.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDTLASRF AS SCMAS WITH (READUNCOMMITTED)   " + Environment.NewLine;
                    selectTxt += "       INNER JOIN   " + Environment.NewLine;
                    selectTxt += "       (   " + Environment.NewLine;
                    selectTxt += "         SELECT    " + Environment.NewLine;
                    selectTxt += "  	     ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "          ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "          ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "          ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	   FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "         WHERE" + Environment.NewLine;
                    selectTxt += "               ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/01/24 Add >>>
                    selectTxt += "           AND INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "           AND INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "           AND INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "           AND INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "           AND INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "           AND INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                    // 2011/01/24 Add <<<        
                    // 2011/02/18 >>>
                    //selectTxt += "           AND ANSWERDIVCDRF <> 99   " + Environment.NewLine;
                    selectTxt += "           AND CANCELDIVRF <> 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "       ) AS SCMODR   " + Environment.NewLine;
                    selectTxt += "       ON   " + Environment.NewLine;
                    selectTxt += "           SCMODR.ENTERPRISECODERF = SCMAS.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALEPCDRF = SCMAS.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQORIGINALSECCDRF = SCMAS.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHEREPCDRF = SCMAS.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQOTHERSECCDRF = SCMAS.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.INQUIRYNUMBERRF = SCMAS.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATEDATERF = SCMAS.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "       AND SCMODR.UPDATETIMERF = SCMAS.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  	 GROUP BY    " + Environment.NewLine;
                    selectTxt += "  	   SCMAS.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMBERRF	   " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "  	  ,SCMAS.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    // -- UPD 2010/06/17 ------------------------------------>>>
                    //selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + cast(SCM.UPDATETIMERF as nvarchar))   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATETIMERF = (cast(SCM.UPDATEDATERF as nvarchar) + RIGHT('000000000' + cast(SCM.UPDATETIMERF as nvarchar),9))   " + Environment.NewLine;
                    // -- UPD 2010/06/17 ------------------------------------<<<
                    selectTxt += "    AND SCM2.INQROWNUMBERRF = SCM.INQROWNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQROWNUMDERIVEDNORF = SCM.INQROWNUMDERIVEDNORF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.ACPTANODRSTATUSRF = SCM.ACPTANODRSTATUSRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.SALESSLIPNUMRF = SCM.SALESSLIPNUMRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.SALESROWNORF = SCM.SALESROWNORF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;
                }
                else
                {
                    //�L�����Z�����̒��o�N�G��
                    selectTxt += "  SELECT " + Environment.NewLine;
                    selectTxt += "      SCM.ENTERPRISECODERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALEPCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQORIGINALSECCDRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMBERRF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                    selectTxt += " 	   ,SCM.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESSLIPNUMRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.HANDLEDIVCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSHAPERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.BLGOODSDRCODERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSGOODSNAMERF " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESORDERCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.PUREGOODSMAKERCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.INQPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "	   ,SCM.ANSPUREGOODSNORF " + Environment.NewLine;
                    selectTxt += "     ,SCM.LISTPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.UNITPRICERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSADDINFORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRROFITRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ROUGHRATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ANSWERLIMITDATERF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.COMMENTDTLRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SHELFNORF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.ADDITIONALDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.CORRECTDIVCDRF   " + Environment.NewLine;
                    selectTxt += "     ,SCM.SALESROWNORF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.CAMPAIGNCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.STOCKDIVRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDCODERF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.RECYCLEPRTKINDNAMERF  " + Environment.NewLine;
                    // 2010/05/27 Add >>>
                    selectTxt += "     ,SCM.INQORDDIVCDRF  " + Environment.NewLine;
                    // 2010/05/27 Add <<<
                    // -- ADD 2010/06/17 -------------------------->>>
                    selectTxt += "     ,SCM.CANCELCNDTINDIVRF" + Environment.NewLine;
                    // -- ADD 2010/06/17 --------------------------<<<
                    //--- ADD 2011/05/26 -------------------------->>>
                    selectTxt += "     ,SCM.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.WAREHOUSESHELFNORF" + Environment.NewLine;
                    //--- ADD 2011/05/26 -------------------------->>>
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSECDRF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGWAREHOUSENAMERF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGSHELFNORF" + Environment.NewLine;
                    selectTxt += "     ,SCM.PMMAINMNGPRSNTCOUNTRF" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.GOODSSPECIALNTFORCOWRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORFACRF  " + Environment.NewLine;
                    selectTxt += "     ,SCM.PRMSETDTLNAME2FORCOWRF  " + Environment.NewLine;
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<
                    selectTxt += "   FROM SCMACODRDTLASRF AS SCM WITH (READUNCOMMITTED)" + Environment.NewLine;
                    selectTxt += "   INNER JOIN   " + Environment.NewLine;
                    selectTxt += "    (   " + Environment.NewLine;
                    selectTxt += "  	 SELECT    " + Environment.NewLine;
                    selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQORIGINALSECCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                    selectTxt += "  	  ,INQOTHERSECCDRF    " + Environment.NewLine;
                    selectTxt += "  	  ,INQUIRYNUMBERRF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATEDATERF  " + Environment.NewLine;
                    selectTxt += "  	  ,UPDATETIMERF  " + Environment.NewLine;
                    selectTxt += "  	 FROM SCMACODRDATARF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "       WHERE" + Environment.NewLine;
                    selectTxt += "             ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    // 2011/02/18 >>>
                    //selectTxt += "         AND ANSWERDIVCDRF = 99   " + Environment.NewLine;
                    selectTxt += "         AND CANCELDIVRF = 1   " + Environment.NewLine;
                    // 2011/02/18 <<<
                    selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                    selectTxt += "    ON   " + Environment.NewLine;
                    selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQORIGINALSECCDRF = SCM.INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF" + Environment.NewLine;
                    selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF" + Environment.NewLine;
                    selectTxt += "  WHERE  " + Environment.NewLine;
                    selectTxt += "        SCM.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALEPCDRF = @INQORIGINALEPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORIGINALSECCDRF = @INQORIGINALSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQUIRYNUMBERRF = @INQUIRYNUMBER  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHEREPCDRF = @INQOTHEREPCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQOTHERSECCDRF = @INQOTHERSECCD  " + Environment.NewLine;
                    selectTxt += "    AND SCM.INQORDDIVCDRF = @INQORDDIVCD  " + Environment.NewLine;

                }
                // -- UPD 2010/04/13--------------------------------<<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.EnterpriseCode);

                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalEpCd);

                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOriginalSecCd);

                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherEpCd);

                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parascmInquiryResultWork.InqOtherSecCd);

                SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
                paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(parascmInquiryResultWork.InquiryNumber);

                SqlParameter paraInqOrdDivCd = sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
                paraInqOrdDivCd.Value = SqlDataMediator.SqlSetInt32(parascmInquiryResultWork.InqOrdDivCd);


                // -- UPD 2010/04/13-------------------------------->>>
                //�񓚂͓`�[�ԍ��ōi�荞�݂��s��Ȃ�
                //SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                //paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(parascmInquiryResultWork.AcptAnOdrStatus);

                //SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                //paraSalesSlipNum.Value = parascmInquiryResultWork.SalesSlipNum;
                // -- UPD 2010/04/13--------------------------------<<<

                
                //selectTxt += " 	GROUP BY   " + Environment.NewLine;
                //selectTxt += "      ENTERPRISECODERF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALEPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQORIGINALSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQOTHEREPCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQOTHERSECCDRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQUIRYNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMBERRF  " + Environment.NewLine;
                //selectTxt += " 	   ,INQROWNUMDERIVEDNORF  " + Environment.NewLine;
                //selectTxt += " 	   ,ACPTANODRSTATUSRF  " + Environment.NewLine;
                //selectTxt += "     ,SALESSLIPNUMRF  " + Environment.NewLine;
                //selectTxt += "     ,INQORGDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQOTHDTLDISCGUIDRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSDIVRF   " + Environment.NewLine;
                //selectTxt += "     ,HANDLEDIVCODERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSSHAPERF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVRDGDSCONFCDRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIGDSCMPLTDUEDATERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSCODERF   " + Environment.NewLine;
                //selectTxt += "     ,BLGOODSDRCODERF   " + Environment.NewLine;
                //selectTxt += "     ,INQGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "	   ,ANSGOODSNAMERF " + Environment.NewLine;
                //selectTxt += "     ,SALESORDERCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,DELIVEREDGOODSCOUNTRF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSNORF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,PUREGOODSMAKERCDRF   " + Environment.NewLine;
                //selectTxt += "     ,INQPUREGOODSNORF " + Environment.NewLine;
                //selectTxt += "	   ,ANSPUREGOODSNORF  " + Environment.NewLine;
                //selectTxt += "     ,LISTPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,UNITPRICERF   " + Environment.NewLine;
                //selectTxt += "     ,GOODSADDINFORF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRROFITRF   " + Environment.NewLine;
                //selectTxt += "     ,ROUGHRATERF   " + Environment.NewLine;
                //selectTxt += "     ,ANSWERLIMITDATERF   " + Environment.NewLine;
                //selectTxt += "     ,COMMENTDTLRF   " + Environment.NewLine;
                //selectTxt += "     ,SHELFNORF   " + Environment.NewLine;
                //selectTxt += "     ,ADDITIONALDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,CORRECTDIVCDRF   " + Environment.NewLine;
                //selectTxt += "     ,SALESROWNORF  " + Environment.NewLine;
                //selectTxt += "     ,CAMPAIGNCODERF  " + Environment.NewLine;
                //selectTxt += "     ,STOCKDIVRF  " + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    // ����-��
                    SCMInquiryDtlAnsResultWork wkSCMInquiryDtlResultAnsWork = new SCMInquiryDtlAnsResultWork();

                    wkSCMInquiryDtlResultAnsWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();  // �⍇������ƃR�[�h//@@@@20230303
                    wkSCMInquiryDtlResultAnsWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));  // �⍇�������_�R�[�h
                    wkSCMInquiryDtlResultAnsWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));  // �⍇���ԍ�
                    wkSCMInquiryDtlResultAnsWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));  // �X�V�N����
                    wkSCMInquiryDtlResultAnsWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));  // �X�V����
                    wkSCMInquiryDtlResultAnsWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));  // �󒍃X�e�[�^�X
                    wkSCMInquiryDtlResultAnsWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));  // ����`�[�ԍ�
                    wkSCMInquiryDtlResultAnsWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));  // �⍇���s�ԍ�
                    wkSCMInquiryDtlResultAnsWork.InqRowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));  // �⍇���s�ԍ��}��
                    wkSCMInquiryDtlResultAnsWork.InqOrgDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQORGDTLDISCGUIDRF"));  // �⍇�������׎���GUID
                    wkSCMInquiryDtlResultAnsWork.InqOthDtlDiscGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQOTHDTLDISCGUIDRF"));  // �⍇���斾�׎���GUID
                    wkSCMInquiryDtlResultAnsWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));  // ���i���
                    wkSCMInquiryDtlResultAnsWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // �[�i�敪
                    wkSCMInquiryDtlResultAnsWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));  // �戵�敪
                    wkSCMInquiryDtlResultAnsWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));  // ���i�`��
                    wkSCMInquiryDtlResultAnsWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));  // �[�i�m�F�敪
                    wkSCMInquiryDtlResultAnsWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // �[�i�����\���
                    wkSCMInquiryDtlResultAnsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL���i�R�[�h
                    wkSCMInquiryDtlResultAnsWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));  // BL���i�R�[�h�}��
                    wkSCMInquiryDtlResultAnsWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQGOODSNAMERF")); // �┭���i����
                    wkSCMInquiryDtlResultAnsWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSGOODSNAMERF")); // �񓚏��i����
                    wkSCMInquiryDtlResultAnsWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));  // ������
                    wkSCMInquiryDtlResultAnsWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));  // �[�i��
                    wkSCMInquiryDtlResultAnsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // ���i�ԍ�
                    wkSCMInquiryDtlResultAnsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // ���i���[�J�[�R�[�h
                    wkSCMInquiryDtlResultAnsWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));  // �������i���[�J�[�R�[�h
                    wkSCMInquiryDtlResultAnsWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF")); // �┭�������i�ԍ�
                    wkSCMInquiryDtlResultAnsWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF")); // �񓚏������i�ԍ�
                    wkSCMInquiryDtlResultAnsWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));  // �艿
                    wkSCMInquiryDtlResultAnsWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));  // �P��
                    wkSCMInquiryDtlResultAnsWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));  // ���i�⑫���
                    wkSCMInquiryDtlResultAnsWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));  // �e���z
                    wkSCMInquiryDtlResultAnsWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));  // �e����
                    wkSCMInquiryDtlResultAnsWork.AnswerLimitDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));  // �񓚊���
                    wkSCMInquiryDtlResultAnsWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));  // ���l(����)
                    wkSCMInquiryDtlResultAnsWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));  // �I��
                    wkSCMInquiryDtlResultAnsWork.AdditionalDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));  // �ǉ��敪
                    wkSCMInquiryDtlResultAnsWork.CorrectDivCD = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));  // �����敪   
                    wkSCMInquiryDtlResultAnsWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
                    wkSCMInquiryDtlResultAnsWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));  // ����s�ԍ�
                    wkSCMInquiryDtlResultAnsWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // �L�����y�[���R�[�h
                    wkSCMInquiryDtlResultAnsWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));  // �݌ɋ敪
                    // 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultAnsWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));  // ���T�C�N�����i���
                    wkSCMInquiryDtlResultAnsWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));  // ���T�C�N�����i��ʖ���
                    // 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2010/05/27 Add >>>
                    wkSCMInquiryDtlResultAnsWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // �⍇���E�������
                    // 2010/05/27 Add <<<
                    // -- ADD 2010/06/17 -------------------------------------->>>
                    wkSCMInquiryDtlResultAnsWork.CancelCndtinDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CANCELCNDTINDIVRF"));  // �L�����Z����ԋ敪
                    // -- ADD 2010/06/17 --------------------------------------<<<

                    //--- ADD 2011/05/26 -------------------------------------->>>
                    wkSCMInquiryDtlResultAnsWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));  // �q�ɃR�[�h
                    wkSCMInquiryDtlResultAnsWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));  // �q�ɖ���
                    wkSCMInquiryDtlResultAnsWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));  // �q�ɒI��
                    //--- ADD 2011/05/26 --------------------------------------<<<

                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    wkSCMInquiryDtlResultAnsWork.PmMainMngWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSECDRF"));  // PM��Ǒq�ɃR�[�h
                    wkSCMInquiryDtlResultAnsWork.PmMainMngWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGWAREHOUSENAMERF"));  // PM��Ǒq�ɖ���
                    wkSCMInquiryDtlResultAnsWork.PmMainMngShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMMAINMNGSHELFNORF"));  // PM��ǒI��
                    wkSCMInquiryDtlResultAnsWork.PmMainMngPrsntCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMMAINMNGPRSNTCOUNTRF"));  // PM��ǌ��݌�
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
                    wkSCMInquiryDtlResultAnsWork.GoodsSpecialNtForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORFACRF"));  // 
                    wkSCMInquiryDtlResultAnsWork.GoodsSpecialNtForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNTFORCOWRF"));  // 
                    wkSCMInquiryDtlResultAnsWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));  // 
                    wkSCMInquiryDtlResultAnsWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));  // 
                    // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<

                    DetailList.Add(wkSCMInquiryDtlResultAnsWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // �Ō�̓`�[���ǉ�
                if (DetailList.Count != 0)
                {
                    retList.Add(DetailList);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchDetailAnsProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        #region �����擾

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ�̌�����߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="readCnt">���o����</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ������߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        public int SearchCnt(out int readCnt, object objscmInquiryOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SCMInquiryOrderWork scmInquiryOrderWork = objscmInquiryOrderWork as SCMInquiryOrderWork;

            readCnt = 0;

            try
            {
                status = SearchCntProc(out readCnt, scmInquiryOrderWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ�̌�����߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="supplierSendErResultWork">��������</param>
        /// <param name="_supplierSendErOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ������߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        private int SearchCntProc(out int readCnt, SCMInquiryOrderWork scmInquiryOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            readCnt = 0;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �`�[��񒊏o
                status = SearchOrderProc(ref readCnt, ref sqlConnection, scmInquiryOrderWork);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMInquiryDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_supplierSendErOrderCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref int retCnt, ref SqlConnection sqlConnection, SCMInquiryOrderWork scmInquiryOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                selectTxt += "  SELECT COUNT(*) AS READCOUNT " + Environment.NewLine;
                // -- UPD 2010/04/13 --------------------------------->>>
                //selectTxt += "   FROM SCMACODRDATARF AS SCM   " + Environment.NewLine;
                selectTxt += "   FROM SCMACODRDATARF AS SCM WITH (READUNCOMMITTED)  " + Environment.NewLine;
                // -- UPD 2010/04/13 ---------------------------------<<<
                selectTxt += "    INNER JOIN   " + Environment.NewLine;
                selectTxt += "    (   " + Environment.NewLine;
                selectTxt += "  	  SELECT    " + Environment.NewLine;
                selectTxt += "  	   MAX(UPDATETIMERF) AS UPDATETIMERF   " + Environment.NewLine;
                selectTxt += "  	  ,MAX(UPDATEDATERF) AS UPDATEDATERF   " + Environment.NewLine;
                selectTxt += "  	  ,ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQUIRYNUMBERRF    " + Environment.NewLine;
                selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
                // -- UPD 2010/04/13 --------------------------------->>>
                //selectTxt += "  	  FROM SCMACODRDATARF    " + Environment.NewLine;
                selectTxt += "  	  FROM SCMACODRDATARF WITH (READUNCOMMITTED)    " + Environment.NewLine;
                // -- UPD 2010/04/13 ---------------------------------<<<
                selectTxt += "  	  GROUP BY    " + Environment.NewLine;
                selectTxt += "  	   ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "  	  ,INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "  	  ,INQUIRYNUMBERRF	   " + Environment.NewLine;
                selectTxt += "  	  ,INQORDANSDIVCDRF  " + Environment.NewLine;
                selectTxt += "    ) AS SCM2   " + Environment.NewLine;
                selectTxt += "    ON   " + Environment.NewLine;
                selectTxt += "        SCM2.ENTERPRISECODERF = SCM.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQORIGINALEPCDRF = SCM.INQORIGINALEPCDRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQOTHEREPCDRF = SCM.INQOTHEREPCDRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQOTHERSECCDRF = SCM.INQOTHERSECCDRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.INQUIRYNUMBERRF = SCM.INQUIRYNUMBERRF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.UPDATEDATERF = SCM.UPDATEDATERF   " + Environment.NewLine;
                selectTxt += "    AND SCM2.UPDATETIMERF = SCM.UPDATETIMERF   " + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, scmInquiryOrderWork, 0);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    retCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("READCOUNT")); // ���o����

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
                base.WriteErrorLog(ex, "SCMInquiryDB.CustomSearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_supplierSendErOrderCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMInquiryOrderWork scmInquiryOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬

            string retst = "";

            string retstring = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            retstring += " SCM.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.EnterpriseCode);

            // �⍇�킹����ƃR�[�h 
            if (scmInquiryOrderWork.InqOriginalEpCd != "")
            {
                retstring += "AND  SCM.INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine;
                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOriginalEpCd);
            }
            // �⍇�킹�����_�R�[�h //��ʋ��_
            if (scmInquiryOrderWork.InqOriginalSecCd != "")
            {
                retstring += " AND SCM.INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine;
                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOriginalSecCd);
            }

            // �⍇�킹���ƃR�[�h
            if (scmInquiryOrderWork.InqOtherEpCd != "")
            {
                retstring += " AND SCM.INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOtherEpCd);
            }

            // �⍇�킹�拒�_�R�[�h
            if (scmInquiryOrderWork.InqOtherSecCd != "")
            {
                retstring += " AND SCM.INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine;
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOtherSecCd);
            }

            // �⍇���ԍ�
            if (scmInquiryOrderWork.St_InquiryNumber != 0)
            {
                retstring += " AND SCM.INQUIRYNUMBERRF>=@STINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraStInquiryNumber = sqlCommand.Parameters.Add("@STINQUIRYNUMBER", SqlDbType.BigInt);
                paraStInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmInquiryOrderWork.St_InquiryNumber);
            }
            if (scmInquiryOrderWork.Ed_InquiryNumber != 0)
            {
                retstring += " AND SCM.INQUIRYNUMBERRF<=@EDINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraEdInquiryNumber = sqlCommand.Parameters.Add("@EDINQUIRYNUMBER", SqlDbType.BigInt);
                paraEdInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmInquiryOrderWork.Ed_InquiryNumber);
            }

            // �X�V�N����
            if (scmInquiryOrderWork.UpdateDate != DateTime.MinValue)
            {
                retstring += " AND SCM.UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmInquiryOrderWork.UpdateDate);
            }

            // �X�V�����b�~���b
            if (scmInquiryOrderWork.UpdateTime != 0)
            {
                retstring += " AND SCM.UPDATETIMERF=@UPDATETIME" + Environment.NewLine;
                SqlParameter paraUpdateTime = sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
                paraUpdateTime.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.UpdateTime);
            }

            // �⍇���E�������
            if (scmInquiryOrderWork.InqOrdDivCd != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.InqOrdDivCd)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.INQORDDIVCDRF IN (" + retst + ") ";
                }
            }

            // �񓚋敪
            if (scmInquiryOrderWork.AnswerDivCd != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.AnswerDivCd)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ANSWERDIVCDRF IN (" + retst + ") ";
                }
            }
            
            // �m���
            if (scmInquiryOrderWork.JudgementDate != 0)
            {
                retstring += " AND SCM.JUDGEMENTDATERF=@JUDGEMENTDATE" + Environment.NewLine;
                SqlParameter paraJudgementDate = sqlCommand.Parameters.Add("@JUDGEMENTDATE", SqlDbType.Int);
                paraJudgementDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.JudgementDate);
            }

            // �⍇�킹�E�������l
            if (scmInquiryOrderWork.InqOrdNote != "")
            {
                retstring += " AND SCM.INQORDNOTERF=@INQORDNOTE" + Environment.NewLine;
                SqlParameter paraInqOrdNote = sqlCommand.Parameters.Add("@INQORDNOTE", SqlDbType.NChar);
                paraInqOrdNote.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqOrdNote);
            }

            // �⍇���]�ƈ��R�[�h
            if (scmInquiryOrderWork.InqEmployeeCd != "")
            {
                retstring += " AND SCM.INQEMPLOYEECDRF=@INQEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraInqEmployeeCd = sqlCommand.Parameters.Add("@INQEMPLOYEECD", SqlDbType.NChar);
                paraInqEmployeeCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.InqEmployeeCd);
            }

            // �񓚏]�ƈ��R�[�h
            if (scmInquiryOrderWork.AnsEmployeeCd != "")
            {
                retstring += " AND SCM.ANSEMPLOYEECDRF=@ANSEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraAnsEmployeeCd = sqlCommand.Parameters.Add("@ANSEMPLOYEECD", SqlDbType.NChar);
                paraAnsEmployeeCd.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.AnsEmployeeCd);
            }

            // �⍇����
            if (scmInquiryOrderWork.St_InquiryDate != 0)
            {
                retstring += " AND SCM.INQUIRYDATERF>=@STINQUIRYDATE" + Environment.NewLine;
                SqlParameter paraStInquiryDate = sqlCommand.Parameters.Add("@STINQUIRYDATE", SqlDbType.Int);
                paraStInquiryDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.St_InquiryDate);
            }
            if (scmInquiryOrderWork.Ed_InquiryDate != 0)
            {
                retstring += " AND SCM.INQUIRYDATERF<=@EDINQUIRYDATE" + Environment.NewLine;
                SqlParameter paraEdInquiryDate = sqlCommand.Parameters.Add("@EDINQUIRYDATE", SqlDbType.Int);
                paraEdInquiryDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.Ed_InquiryDate);
            }
            // --- ADD m.suzuki 2011/06/13 ---------->>>>>
            // �X�V�N����
            if ( scmInquiryOrderWork.St_UpdateDate != 0 )
            {
                retstring += " AND SCM.UPDATEDATERF>=@STUPDATEDATE" + Environment.NewLine;
                SqlParameter paraStUpdateDate = sqlCommand.Parameters.Add( "@STUPDATEDATE", SqlDbType.Int );
                paraStUpdateDate.Value = SqlDataMediator.SqlSetInt32( scmInquiryOrderWork.St_UpdateDate );
            }
            if ( scmInquiryOrderWork.Ed_UpdateDate != 0 )
            {
                retstring += " AND SCM.UPDATEDATERF<=@EDUPDATEDATE" + Environment.NewLine;
                SqlParameter paraEdUpdateDate = sqlCommand.Parameters.Add( "@EDUPDATEDATE", SqlDbType.Int );
                paraEdUpdateDate.Value = SqlDataMediator.SqlSetInt32( scmInquiryOrderWork.Ed_UpdateDate );
            }
            // --- ADD m.suzuki 2011/06/13 ----------<<<<<

            // ���Ӑ�R�[�h
            if (scmInquiryOrderWork.St_CustomerCode != 0)
            {
                retstring += " AND SCM.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.St_CustomerCode);
            }
            if (scmInquiryOrderWork.Ed_CustomerCode != 0)
            {
                retstring += " AND SCM.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.Ed_CustomerCode);
            }

            // �񓚕��@
            if (scmInquiryOrderWork.AwnserMethod != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.AwnserMethod)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ANSWERCREATEDIVRF IN (" + retst + ") ";
                }
            }

            // �`�[�ԍ�
            if (scmInquiryOrderWork.St_SalesSlipNum != "")
            {
                retstring += " AND SCM.SALESSLIPNUMRF>=@STSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraStSalesSlipNum = sqlCommand.Parameters.Add("@STSALESSLIPNUM", SqlDbType.NChar);
                paraStSalesSlipNum.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.St_SalesSlipNum);
            }
            if (scmInquiryOrderWork.Ed_SalesSlipNum != "")
            {
                retstring += " AND SCM.SALESSLIPNUMRF<=@EDSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraEdSalesSlipNum = sqlCommand.Parameters.Add("@EDSALESSLIPNUM", SqlDbType.NChar);
                paraEdSalesSlipNum.Value = SqlDataMediator.SqlSetString(scmInquiryOrderWork.Ed_SalesSlipNum);
            }

            // �󒍃X�e�[�^�X
            if (scmInquiryOrderWork.AcptAnOdrStatus != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.AcptAnOdrStatus)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ACPTANODRSTATUSRF IN (" + retst + ") ";
                }
            }

            // ����`�[�v
            if (scmInquiryOrderWork.SalesTotalTaxInc != 0)
            {
                retstring += " AND SCM.SALESTOTALTAXINCRF=@SALESTOTALTAXINC" + Environment.NewLine;
                SqlParameter paraSalesTotalTaxInc = sqlCommand.Parameters.Add("@SALESTOTALTAXINC", SqlDbType.Int);
                paraSalesTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(scmInquiryOrderWork.SalesTotalTaxInc);
            }
            // ---- ADD gezh 2011/11/12 -------->>>>>
            // �A�g�Ώۋ敪
            if (scmInquiryOrderWork.CooperationOptionDiv != null)
            {
                retst = "";
                foreach (int str in scmInquiryOrderWork.CooperationOptionDiv)
                {
                    if (retst != "") retst += ",";
                    retst += "'" + str + "'";
                }
                if (retst != "")
                {
                    retstring += "AND SCM.ACCEPTORORDERKINDRF IN (" + retst + ") ";
                }
            }
            // ---- ADD gezh 2011/11/12 --------<<<<<

            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            // ���ɗ\���
            if (scmInquiryOrderWork.St_ExpectedCeDate != 0)
            {
                retstring += " AND CAR.EXPECTEDCEDATERF>=@STEXPECTEDCEDATE" + Environment.NewLine;
                SqlParameter paraStExpectedCeDate = sqlCommand.Parameters.Add("@STEXPECTEDCEDATE", SqlDbType.Int);
                paraStExpectedCeDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.St_ExpectedCeDate);
            }
            if (scmInquiryOrderWork.Ed_ExpectedCeDate != 0)
            {
                retstring += " AND CAR.EXPECTEDCEDATERF<=@EDEXPECTEDCEDATE" + Environment.NewLine;
                SqlParameter paraEdExpectedCeDate = sqlCommand.Parameters.Add("@EDEXPECTEDCEDATE", SqlDbType.Int);
                paraEdExpectedCeDate.Value = SqlDataMediator.SqlSetInt32(scmInquiryOrderWork.Ed_ExpectedCeDate);
            }
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

            return retstring;
            #endregion
        }
    }
}
