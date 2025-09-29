//============================================================================//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�����[�g
// �v���O�����T�v   : ���Ӑ�}�X�^�ւ̓Ǎ��E�����E�폜�Ȃǂ�񋟂��܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10402071-00  �쐬�S�� : 21112
// �� �� ��  2008/04/23  �C�����e : SFTOK01130R ���x�[�X��PM.NS�p���쐬
//
// �Ǘ��ԍ� 10402071-00  �쐬�S�� : 23015 �X�{ ��P
// �� �� ��  2008/09/02  �C�����e : �����폜�@�\�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012 ���� �[���N
// �� �� ��  2009/04/09  �C�����e : ���Ӑ�ꊇ�o�^�C����Write�����𓝍�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/09/26  �C�����e : Redmine��Q�� #14483�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/10/28  �C�����e : �Ǝ�A�E��A�n��A��s�敪���̂́A���[�U�[�K�C�h���Ř_���폜���ɖ��̂��擾���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10970681-00 �쐬�S���F��
// �C����    K2014/02/06 �C�����e�F�O�����a����� ���Ӑ�}�X�^���ǑΉ�
// ---------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00 �쐬�S���F���J�M�m
// �C����    2021/05/10  �C�����e�F���Ӑ���K�C�h�\��PKG�Ή�
// ---------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���Ӑ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer   : 21112</br>
    /// <br>Date         : 2007.02.14</br>
    /// <br></br>
    /// <br>Update Note  : 2007.05.21�@19026�@���R�@�����@Sync�Ή�</br>
    /// <br></br>
    /// <br>Update Note  : DC.NS�p�ɉ��ǔ�����z�����敪�ݒ�}�X�^��ʃ����[�g�ŏ��������</br>
    /// <br>               �s�v���\�b�h�̍폜</br>
    /// <br>Programmer   : 22008�@�����@���n</br>
    /// <br>Date         : 2007.08.14</br>
    /// <br></br>
    /// <br>Update Note  : DC.NS�p�ɓ��Ӑ�}�X�^�̕ύX�ɔ����C��</br>
    /// <br>Update Note  : �Ƒ��\���}�X�^�ɑ΂��鏈�����폜(�R�����g�A�E�g)</br>
    /// <br>Programmer   : 21112�@�v�ۓc�@��</br>
    /// <br>Date         : 2007.08.23</br>
    /// <br></br>
    /// <br>Update Note  : ���[�J���V���N�Ή�</br>
    /// <br>Programmer   : 980081 �R�c ���F</br>
    /// <br>Date         : 2008.02.07</br>
    /// <br></br>
    /// <br>Update Note  : PM.NS�p�ɉ���</br>
    /// <br>Programmer   : 21112</br>
    /// <br>Date         : 2008.04.23</br>
    /// <br></br>
    /// <br>Update Note  : �����폜�����ǉ�</br>
    /// <br>Programmer   : 23015 �X�{ ��P</br>
    /// <br>Date         : 2008.09.02</br>
    /// <br></br>
    /// <br>Update Note  : ���Ӑ�(�ϓ����)�}�X�^�̍X�V�����ǉ�</br>
    /// <br>Programmer   : 23012 ���� �[���N</br>
    /// <br>Date         : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note  : �_���폜�����̃`�F�b�N�ǉ�</br>
    /// <br>Update Note  : ���Ӑ�(�|���O���[�v)�}�X�^�Ɠ��Ӑ�(�`�[�ԍ�)�̍X�V�����ǉ�</br>
    /// <br>Programmer   : 30009 �a�J ���</br>
    /// <br>Date         : 2008.11.14</br>
    /// <br></br>
    /// <br>Update Note  : ���Ӑ�D��q�ɃR�[�h�̌^��ύX(Int32��NChar)</br>
    /// <br>Programmer   : 30009 �a�J ���</br>
    /// <br>Date         : 2008.12.01</br>
    /// <br></br>
    /// <br>Update Note  : Search���\�b�h�ǉ�</br>
    /// <br>Programmer   : 23012 ���� �[���N</br>
    /// <br>Date         : 2009.01.19</br>
    /// <br></br>
    /// <br>Update Note  : ���v�������o�́A���א������o�́A�`�[���v�������o�͂̍X�V�����ǉ�</br>
    /// <br>             : ���Ӑ�ꊇ�C���ɂ��`�[�^�C�v���̋敪���C���ł���悤�ɂ���</br>
    /// <br>Programmer   : 30531 ��� �r��</br>
    /// <br>Date         : 2010.01.04</br>
    /// <br></br>
    /// <br>Update Note  : �ȒP�⍇���A�J�E���g�O���[�vID �ǉ�</br>
    /// <br>Programmer   : 22008 ���� ���n</br>
    /// <br>Date         : 2010/06/25</br>
    /// <br></br>
    /// <br>Update Note  : �Ǝ�A�E��A�n��A��s�敪���̂́A���[�U�[�K�C�h���Ř_���폜���ɖ��̂��擾���Ȃ�</br>
    /// <br>Programmer   : 21024 ���X�� ��</br>
    /// <br>Date         : 2010/10/28</br>
    /// <br></br>
    /// <br>Update Note  : ���Ӑ���֘A�����}�X�^�̌��������A�o�^�����A�X�V�����A�_���폜�����ǉ�</br>
    /// <br>Programmer   : ��</br>
    /// <br>Date         : K2014/02/06</br>
    /// <br></br>
    /// <br>Update Note  : ���Ӑ���K�C�h�\��PKG�Ή��ɂāA���Ӑ���K�C�h�\���敪��ǉ�</br>
    /// <br>Programmer   : ���J �M�m</br>
    /// <br>Date         : 2021/05/10</br>
    /// </remarks>
    [Serializable]
    public class CustomerDB : RemoteDB, ICustomerInfoDB, IGetSyncdataList
    {
        /// <summary>
        /// ���Ӑ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public CustomerDB()
            : base("PMKHN09016D", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "CUSTOMERRF")
        {

        }

        // ===================================================================================== //
        // Read�֘A�@�p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// <summary>
        /// ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="paraList">CustomSerializeList(���Ӑ�}�X�^�A���l�}�X�^�A�Ƒ��\���}�X�^���X�g)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̓��Ӑ��߂��܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Read(ref object paraList)
        {
            return this.Read(ConstantManagement.LogicalMode.GetData01, ref paraList);
        }
        # endregion

        # region ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// <summary>
        /// ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̓��Ӑ��߂��܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Read(ConstantManagement.LogicalMode logicalMode, ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            // �I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ惊�X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                // ���Ӑ�}�X�^�ǂݍ��ݏ���
                status = this.ReadCustomerWork(ref customerWork, ref sqlConnection, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    customSerializeArrayList.Add(customerWork);
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        # endregion

        # region ���Ӑ�}�X�^�ǂݍ��ݏ����i���Ӑ�R�[�h�����w��j
        /// <summary>
        /// ���Ӑ�}�X�^�ǂݍ��ݏ����i���Ӑ�R�[�h�����w��j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCodeArray">���Ӑ�R�[�h�z��</param>
        /// <param name="customerWorkArray">���Ӑ���N���X�z��</param>
        /// <param name="statusArray">�X�e�[�^�X�z��</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̓��Ӑ�𕡐����߂��܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Read(string enterpriseCode, int[] customerCodeArray, out CustomerWork[] customerWorkArray, out int[] statusArray, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if ((sqlConnection == null) || (customerCodeArray == null) || (customerCodeArray.Length == 0))
            {
                customerWorkArray = new CustomerWork[0];
                statusArray = new Int32[0];
                return status;
            }

            statusArray = new Int32[customerCodeArray.Length];
            customerWorkArray = new CustomerWork[customerCodeArray.Length];

            for (int i = 0; i < customerCodeArray.Length; i++)
            {
                CustomerWork customerWork = new CustomerWork();
                customerWork.EnterpriseCode = enterpriseCode;
                customerWork.CustomerCode = customerCodeArray[i];

                statusArray[i] = this.ReadCustomerWork(ref customerWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);
                customerWorkArray[i] = customerWork;
            }

            foreach (int i in statusArray)
            {
                if (i == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            return status;
        }
        # endregion

        # region ���Ӑ�}�X�^���݃`�F�b�N����
        /// <summary>
        /// ���Ӑ�}�X�^���݃`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        public int ExistData(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                status = this.ExistCheckProc(enterpriseCode, customerCode, logicalMode, sqlConnection);
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^���݃`�F�b�N�����Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // Read�֘A�@�v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// <summary>
        /// ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="customerWork">���Ӑ惏�[�N�N���X</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̓��Ӑ��߂��܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int ReadCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;
                
                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;                       
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;                
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                // ADD 2009.02.05 >>>
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/06 ------<<<
                // --- ADD 2009.05.20 ------>>>
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD 2009.05.20 ------<<<
                // --- ADD  ���r��  2010/01/04 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/04 ----------<<<<<
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25

                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- �̔��G���A�敪" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- ��s�敪" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- �E��敪" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- �Ǝ�敪" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                # endregion

                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);

                    // �_���폜�敪�`�F�b�N����
                    status = this.LogicalDeleteCodeCheck(customerWork.LogicalDeleteCode, logicalMode);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
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
            }

            return status;
        }
        # endregion

        // ADD 2009.01.19 >>>
        // ===================================================================================== //
        // Search�֘A�@�p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�ǂݍ��ݏ����i���Ӑ�R�[�h�����w��j
        /// <summary>
        /// ���Ӑ�}�X�^�ǂݍ��ݏ����i���Ӑ�R�[�h�����w��j
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̐e���Ӑ�Ǝq���Ӑ�𕡐����߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.19</br>
        /// </remarks>       
        public int Search(ConstantManagement.LogicalMode logicalMode, ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            // �I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ惊�X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                for (int i = 0; i < paraCustomList.Count; i++)
                {
                    customerWork = paraCustomList[i] as CustomerWork;

                    // ���Ӑ�}�X�^�ǂݍ��ݏ���
                    status = this.SearchCustomerWork(ref customSerializeArrayList, ref customerWork, ref sqlConnection, logicalMode);
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        # endregion

        // ===================================================================================== //
        // Search�֘A�@�v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// <summary>
        /// ���Ӑ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="ResultcustomerWork">���o����</param>
        /// <param name="customerWork">���Ӑ惏�[�N�N���X</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̐e���Ӑ�Ǝq���Ӑ��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.19</br>
        /// </remarks>
        private int SearchCustomerWork(ref CustomSerializeArrayList ResultcustomerWork, ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                // ADD 2009.02.05 >>>
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/06 ------<<<
                // --- ADD 2009.05.20 ------>>>
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD 2009.05.20 ------<<<
                // --- ADD  ���r��  2010/01/04 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/04 ----------<<<<<
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;           
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- �̔��G���A�敪" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- ��s�敪" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- �E��敪" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- �Ǝ�敪" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CLAIMCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                # endregion

                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                //if (myReader.Read())
                //{
                //    this.ReaderToCustomerWork(ref myReader, ref customerWork);

                //    // �_���폜�敪�`�F�b�N����
                //    status = this.LogicalDeleteCodeCheck(customerWork.LogicalDeleteCode, logicalMode);
                //}
                while (myReader.Read())
                {
                    customerWork = new CustomerWork();
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);
                    ResultcustomerWork.Add(customerWork);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
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
            }

            return status;
        }
        # endregion
        // ADD 2009.01.19 <<<

        // ===================================================================================== //
        // Write�֘A�@�p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�o�^���� public int Write(ref object paraList, out ArrayList duplicationItemList)
        /// <summary>
        /// ���Ӑ�}�X�^�o�^����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">�d���G���[���̏d������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Write(ref object paraList, out ArrayList duplicationItemList)
        {
            return this.Write(ref paraList, out duplicationItemList, 0);
        }
        # endregion

        # region ���Ӑ�}�X�^�o�^���� public int Write(ref object paraList, out ArrayList duplicationItemList, int carMngNo)
        /// <summary>
        /// ���Ӑ�}�X�^�o�^����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">�d���G���[���̏d������</param>
        /// <param name="carMngNo">���Ӑ�Ǝԗ��𓯎��o�^����ۂ̎ԗ��Ǘ��ԍ�</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Write(ref object paraList, out ArrayList duplicationItemList, int carMngNo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			string retMsg = "";
			duplicationItemList = new ArrayList();

			int customerCode = 0;
			CustomerWork customerWork = null;

			ArrayList paraCustomList = paraList as ArrayList;


			// �I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
			if (paraCustomList == null)
			{
				base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
				return status;
			}
			else if (paraCustomList.Count > 0)
			{
				// List���̓��Ӑ�E���l�E�Ƒ��\�����X�g�𒊏o
				foreach (object obj in paraCustomList)
				{
					if (customerWork == null)
					{
						if (obj is CustomerWork)
						{
							customerWork = obj as CustomerWork;

							// ���Ӑ�R�[�h�Ɗ�ƃR�[�h��Ҕ�
							if (customerCode == 0)
							{
								customerCode = customerWork.CustomerCode;
							}
						}
					}
				}
			}

            if (customerWork == null)
			{
				base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
				return status;
			}

			CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

			try
			{
				// �o�^�O�̓��Ӑ���p
				CustomerWork customerWorkBef = new CustomerWork();
                // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�������ݏ��� >>>
                
                //if (customerWork.CreditMngCode == 1)
                
                    CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                    CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                    int CusChangestatus = 0;
                
                // --- ADD 2008.10.14 <<<
                // 2009.02.20
                ArrayList WriteCustomList = new ArrayList();
                ArrayList changeWorkLogicalDeleteList = new ArrayList();                
                ArrayList changeWorkWriteList = new ArrayList();
               

				// �r��Lock
				//ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
				//status = this.ControlExclusiveProc(0,ref ctrlExclsvOdAcs,ref customerWork, ref retMsg);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{

					// �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
					// ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();

                    // �g�����U�N�V�����X�^�[�g
					sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

					// ���O�C�����擾�N���X���C���X�^���X��
					ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
                    changeWorkLogicalDeleteList = new ArrayList();
                    changeWorkWriteList = new ArrayList();

                    // ADD 2009.01.19 >>>
                    for (int i = 0; i < paraCustomList.Count; i++)
                    {
                        customerWork = paraCustomList[i] as CustomerWork;
                        customerCode = customerWork.CustomerCode;
                    // ADD 2009.01.19 <<<
                        // ================================================================================= //
                        // ���Ӑ�X�V�O���擾
                        // ================================================================================= //
                        if (customerWork != null)
                        {
                            if ((customerWork.EnterpriseCode.Trim() != "") && (customerWork.CustomerCode != 0))
                            {
                                // 2009.02.20
                                // Read�p�R�l�N�V�������C���X�^���X��
                                SqlConnection sqlConnection_read = new SqlConnection(connectionText);
                                sqlConnection_read.Open();

                                customerWorkBef.EnterpriseCode = customerWork.EnterpriseCode;
                                customerWorkBef.CustomerCode = customerWork.CustomerCode;

                                // ���Ӑ���擾�i�o�^�O�j
                                status = this.ReadCustomerWork(ref customerWorkBef, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData0);

                                // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�������ݏ��� >>>
                                if (customerWork.CreditMngCode == 1)
                                {
                                    customerChangeWork = new CustomerChangeWork();
                                    customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode;
                                    customerChangeWork.CustomerCode = customerWork.CustomerCode;
                                    // ���Ӑ�}�X�^(�ϓ����)�擾
                                    CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                                }
                                // ADD 2008.10.14 <<<      

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    // �Y���f�[�^�����̏ꍇ�͐���Ƃ���
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                sqlConnection_read.Close();
                            }
                        }

                        // ================================================================================= //
                        // ���Ӑ�R�[�h�̍̔�
                        // ================================================================================= //
                        // ���Ӑ�R�[�h�������Ă��Ȃ��ꍇ�̂�
                        if (customerCode == 0)
                        {
                            // ���͋��_�R�[�h��ޔ�
                            string sectionCode = customerWork.InpSectionCode;

                            // ���Ӑ�R�[�h�̔ԏ���
                            status = this.CreateCustomerCode(customerWork.EnterpriseCode, sectionCode, out customerCode, out retMsg, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (customerWork.CustomerCode != 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }

                                if (customerWork != null)
                                {
                                    if (customerWork.CustomerCode == 0)
                                    {
                                        customerWork.CustomerCode = customerCode;
                                    }

                                    if (customerWork.ClaimCode == 0)
                                    {
                                        customerWork.ClaimCode = customerCode;
                                    }

                                }
                            }
                            else
                            {
                                duplicationItemList.Add(retMsg);
                            }
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ���Ӑ�}�X�^�������݃��X�g�쐬
                            WriteCustomList.Add(customerWork);

                            // ���Ӑ�}�X�^(�ϓ����)�������݃��X�g�쐬
                            // �^�M�Ǘ�=1:����@���@�e���Ӑ�
                            if ((customerWork.CreditMngCode == 1)&&(customerWork.ClaimCode == customerWork.CustomerCode))
                            {
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ��������
                                    // ADD 2009/04/09 >>>
                                    if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    // ADD 2009/04/09 <<<
                                    changeWorkLogicalDeleteList.Add(customerChangeWork);
                                }
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // �V�K�쐬����
                                    // ADD 2009/04/09 >>>
                                    if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    // ADD 2009/04/09 <<<
                                    changeWorkWriteList.Add(customerChangeWork);
                                }
                            }

                        }
                    // ADD 2009.01.19 >>>
                    }
                    // ADD 2009.01.19 <<<

                    // ���Ӑ�}�X�^����
                    for (int i = 0; i < WriteCustomList.Count; i++)
                    {
                        customerWork = WriteCustomList[i] as CustomerWork;
                        status = this.WriteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, ref duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                    }
                    // << ���Ӑ�}�X�^(�ϓ����)�������ݏ��� >>
                    if (changeWorkLogicalDeleteList.Count > 0)
                    {
                        if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                        {
                            // �X�V����
                            customerChangeDB.WriteProc(ref changeWorkLogicalDeleteList, ref sqlConnection, ref sqlTransaction);
                        }
                        else
                        {
                            // ��������
                            customerChangeDB.LogicalDeleteProc(ref changeWorkLogicalDeleteList, 1, ref sqlConnection, ref sqlTransaction);
                        }
                    }
                    if (changeWorkWriteList.Count > 0)
                    {
                        // �V�K�쐬����
                        customerChangeDB.WriteProc(ref changeWorkWriteList, ref sqlConnection, ref sqlTransaction);
                    }
                    
                        //// ================================================================================= //
                        //// ���Ӑ�f�[�^�������ݏ���
                        //// ================================================================================= //
                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    if (customerWork != null)
                        //    {
                        //        status = this.WriteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, ref duplicationItemList);

                            
                        //        // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�������ݏ��� >>>
                        //        if (customerWork.CreditMngCode == 1)
                        //        {
                        //            // ��������
                        //            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //            {
                        //                //�p�����[�^�̃L���X�g
                        //                ArrayList changeWorkparaList = new ArrayList();
                        //                changeWorkparaList.Add(customerChangeWork);
                        //                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref changeWorkparaList, 1, ref sqlConnection, ref sqlTransaction);
                        //            }

                        //            // �V�K�쐬����
                        //            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //            {
                        //                //�p�����[�^�̃L���X�g
                        //                ArrayList changeWorkparaList = new ArrayList();
                        //                changeWorkparaList.Add(customerChangeWork);
                        //                CusChangestatus = customerChangeDB.WriteProc(ref changeWorkparaList, ref sqlConnection, ref sqlTransaction);
                        //            }
                        //        }
                        //        // --- ADD 2008.10.14 <<<

                        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        {
                        //            customSerializeArrayList.Add((CustomerWork)customerWork);
                        //        }

                        //    }
                        //}
                    
					// �R�~�b�g
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						sqlTransaction.Commit();
					}
				}
				else
				{
					if (retMsg.Trim() != "")
					{
						duplicationItemList.Add(retMsg);
					}
				}
			}
			// ��O����
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̏������݂Ɏ��s���܂����B", ex.Number);
			}
			catch(Exception ex)
			{
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
			}
			finally
			{
				// �r��Lock�j��
				//this.ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref customerWork, ref retMsg);

				// �g�����U�N�V�����j��
				if (sqlTransaction != null) sqlTransaction.Dispose();

				// �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
			}

			paraList = (object)customSerializeArrayList;
            return status;
		}
        # endregion

        // ===================================================================================== //
        // Write�֘A�@�v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�f�[�^�o�^����
        /// <summary>
        /// ���Ӑ�f�[�^�o�^����
        /// </summary>
        /// <param name="customerWork">�o�^�󓾈Ӑ��</param>
        /// <param name="sqlConnection">sql�R�l�N�V�����I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="duplicationItemList">�d���G���[���̏d������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.07.11</br>
        /// </remarks>
        private int WriteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref ArrayList duplicationItemList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;

            try
            {
                // Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Parameter�I�u�W�F�N�g�̃N���A
                    sqlCommand.Parameters.Clear();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (customerWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        string sqlText = string.Empty;

                        // ADD 2009/04/09 >>>
                        if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C�� 
                        {
                        // ADD 2009/04/09 <<<
                            # region [UPDATE��]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;                            
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;                          
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            // ADD 2009.02.05 >>>
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            // ADD 2009.02.05 <<<

                            // --- ADD 2009/04/06 ------>>>
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/06 ------<<<
                            // --- ADD 2009/05/20 ------>>>
                            sqlText += " , CUSTOMEREPCODERF = @CUSTOMEREPCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERSECCODERF = @CUSTOMERSECCODE" + Environment.NewLine;
                            sqlText += " , ONLINEKINDDIVRF = @ONLINEKINDDIV" + Environment.NewLine;
                            // --- ADD 2009/05/20 ------>>>
                            // --- ADD  ���r��  2010/01/04 ---------->>>>>
                            sqlText += " , TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " , DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " , SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/04 ----------<<<<<
                            sqlText += " , SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine; // ADD 2010/06/25
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        // ADD 2009/04/09 >>>
                        }
                        else if (customerWork.WriteDiv == 1)  // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C�� 
                        {
                            # region [UPDATE��]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;                            
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;                        
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            // --- ADD 2009/04/07 -------->>>
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/07 --------<<<
                            // --- ADD  ���r��  2010/01/04 ---------->>>>>
                            sqlText += " ,TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/04 ----------<<<<<
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        // ADD 2009/04/09 <<<
                        sqlCommand.CommandText = sqlText;

                        // KEY�R�}���h���Đݒ�
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (customerWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        // �V�K�쐬����SQL���𐶐�

                        string sqlText = string.Empty;
                        // ADD 2009/04/09 >>>
                        if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                        {
                        // ADD 2009/04/09 <<<
                            # region [INSERT��]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;                            
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;                  
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;       
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            // ADD 2009.02.05 >>> 
                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            // ADD 2009.02.05 <<<

                            // --- ADD 2009/04/06 ------>>>
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            // --- ADD 2009/04/06 ------<<<
                            // --- ADD 2009/05/20 ------>>>
                            sqlText += " ,CUSTOMEREPCODERF " + Environment.NewLine;
                            sqlText += " ,CUSTOMERSECCODERF " + Environment.NewLine;
                            sqlText += " ,ONLINEKINDDIVRF " + Environment.NewLine;
                            // --- ADD 2009/05/20 ------<<<
                            // --- ADD  ���r��  2010/01/04 ---------->>>>>
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;                            
                            // --- ADD  ���r��  2010/01/04 ----------<<<<<
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;                                                       
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;                     
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            // ADD 2009.02.05 >>>
                            sqlText += " ,@SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIV" + Environment.NewLine;
                            // ADD 2009.02.05 <<<

                            // --- ADD 2009/04/06 ------>>>
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/06 ------<<<
                            // --- ADD 2009/05/20 ------>>>
                            sqlText += " ,@CUSTOMEREPCODE " + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSECCODE " + Environment.NewLine;
                            sqlText += " ,@ONLINEKINDDIV " + Environment.NewLine;
                            // --- ADD 2009/05/20 ------<<<
                            // --- ADD  ���r��  2010/01/04 ---------->>>>>
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/04 ----------<<<<<
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;  // ADD 20101/06/25
                            sqlText += ")" + Environment.NewLine;
                            # endregion
                        // ADD 2009/04/09 >>>
                        }
                        else if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                        {
                            # region [INSERT��]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;                                                  
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;                           
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            // --- ADD 2009/04/07 -------->>>
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            // --- ADD 2009/04/07 --------<<<
                            // --- ADD  ���r��  2010/01/04 ---------->>>>>
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                            
                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/04 ----------<<<<<
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            // --- ADD 2009/04/07 -------->>>
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/07 --------<<<
                            // --- ADD  ���r��  2010/01/04 ---------->>>>>
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;

                            sqlText += " ,@SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIVRF" + Environment.NewLine;
                            // --- ADD  ���r��  2010/01/04 ----------<<<<<
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += ")" + Environment.NewLine;
                            # endregion

                        }
                        // ADD 2009/04/09 <<<
                        sqlCommand.CommandText = sqlText;

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    // ADD 2009/04/09 >>>
                    if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��                    
                    {
                    // ADD 2009/04/09 <<<
                        # region Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);                                         
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);                   
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar);
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        // ADD 2009.02.05 >>>
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        // ADD 2009.02.05 <<<

                        // --- ADD 2009/04/06 ------>>>
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        // --- ADD 2009/04/06 ------<<<
                        // --- ADD 2009/05/20 ------>>>
                        SqlParameter paraCustomerEpCode = sqlCommand.Parameters.Add("@CUSTOMEREPCODE", SqlDbType.NChar);  // ���Ӑ��ƃR�[�h
                        SqlParameter paraCustomerSecCode = sqlCommand.Parameters.Add("@CUSTOMERSECCODE", SqlDbType.NChar);  // ���Ӑ拒�_�R�[�h
                        SqlParameter paraOnlineKindDiv = sqlCommand.Parameters.Add("@ONLINEKINDDIV", SqlDbType.Int);  // �I�����C����ʋ敪
                        // --- ADD 2009/05/20 ------<<<
                        // --- ADD  ���r��  2010/01/04 ---------->>>>>
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);
                        // --- ADD  ���r��  2010/01/04 ----------<<<<<
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar);  // �ȒP�⍇���A�J�E���g�O���[�vID // ADD 2010/06/25

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);                                              
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);                    
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        // ADD 2009.02.05 >>>
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);
                        // ADD 2009.02.05 <<<

                        // --- ADD 2009/04/06 ------>>>
                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);
                        // --- ADD 2009/04/06 ------<<<

                        // --- ADD 2009/05/20 ------>>>
                        paraCustomerEpCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerEpCode);  // ���Ӑ��ƃR�[�h
                        paraCustomerSecCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSecCode);  // ���Ӑ拒�_�R�[�h
                        paraOnlineKindDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.OnlineKindDiv);  // �I�����C����ʋ敪
                        // --- ADD 2009/05/20 ------<<<
                        // --- ADD  ���r��  2010/01/04 ---------->>>>>
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);
                        // --- ADD  ���r��  2010/01/04 ----------<<<<<
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);  // �ȒP�⍇���A�J�E���g�O���[�vID // ADD 2010/06/25
                        # endregion
                    // ADD 2009/04/09 >>>
                    }
                    else if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                    {
                        # region Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);                                          
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);                        
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        //SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.Int);// DEL 2008.12.10
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar); // ADD 2008.12.10
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        // --- ADD 2009/04/07 -------->>>
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        // --- ADD 2009/04/07 --------<<<
                        // --- ADD  ���r��  2010/01/04 ---------->>>>>
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);

                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        // --- ADD  ���r��  2010/01/04 ----------<<<<<
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar); // ADD 2010/06/25
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);                                              
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);                        
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        // --- ADD 2009/04/07 -------->>>
                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);
                        // --- ADD 2009/04/07 --------<<<
                        // --- ADD  ���r��  2010/01/04 ---------->>>>>
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);

                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);
                        // --- ADD  ���r��  2010/01/04 ----------<<<<<
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);  // ADD 2010/06/25
                        # endregion
                    }
                    // ADD 2009/04/09 <<<
                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̏����݂Ɏ��s���܂����B", ex.Number);
                sqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            return status;
        }
        # endregion

        // --- ADD 2008/09/02 ---------->>>>>

        // ===================================================================================== //
        // Delete�֘A�@�p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ���Ӑ�}�X�^�����폜���� public int Delete(ref object paraList)
        /// <summary>
        /// ���Ӑ�}�X�^��������
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public int Delete(ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ�E���l�E�Ƒ��\�����X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read�p�R�l�N�V�������C���X�^���X��
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ���O�C�����擾�N���X���C���X�^���X��
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                // --- ADD 2008.10.14 >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // --- ADD 2008.10.14 <<<
                // 2008.11.14 add ----------------------------------------------------------------->>
                // ���Ӑ�(�|���O���[�v)�����폜
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // ���Ӑ�(�`�[�ԍ�)�����폜
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                // 2008.11.14 add -----------------------------------------------------------------<<


                // ================================================================================= //
                // ���Ӑ�}�X�^�����폜
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�����폜���� >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            // �p�����[�^�[�ݒ�
                            customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                            customerChangeWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                            // ���Ӑ�}�X�^(�ϓ����)�擾
                            CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // ���Ӑ�(�|���O���[�v)�擾
                        custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                        custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                        CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                        // ���Ӑ�(�`�[�ԍ�)�擾
                        custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                        custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                        CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                        // 2008.11.14 add -----------------------------------------------------------------<<

                        status = this.DeleteProc(ref customerWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }

                        // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�����폜���� >>>                            
                        if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�p�����[�^�̃L���X�g
                            ArrayList changeWorkparaList = new ArrayList();
                            changeWorkparaList.Add(customerChangeWork);
                            CusChangestatus = customerChangeDB.DeleteProc(changeWorkparaList, ref sqlConnection, ref sqlTransaction);

                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // ���Ӑ�(�|���O���[�v)�����폜����
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.Delete(custRateGroupList, ref sqlConnection, ref sqlTransaction);

                        }

                        // ���Ӑ�(�`�[�ԍ�)�����폜����
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.Delete(custSlipNoSetList, ref sqlConnection, ref sqlTransaction);

                        }

                        // 2008.11.14 add -----------------------------------------------------------------<<

                    }
                }

                // �R�~�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̕����폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        #endregion

        // ===================================================================================== //
        // Delete�֘A�@�v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ���Ӑ�}�X�^�����폜����
        /// <summary>
        /// ���Ӑ�}�X�^��������
        /// </summary>
        /// <param name="customerWork">CustomSerializeList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        private int DeleteProc(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != customerWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    //Delete�R�}���h�̐���
                    #region [DELETE��]
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion

                    // KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                }
                else
                {
                    // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }

                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̕����폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�}�X�^�̕����폜�Ɏ��s���܂����B", status);
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
            }

            return status;
        }
        #endregion

        // --- ADD 2008/09/02 ----------<<<<<

        // ===================================================================================== //
        // LogidalDelete�֘A�@�p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�_���폜���� public int LogicalDelete(ref object paraList, bool carDeleteFlg)
        /// <summary>
        /// ���Ӑ�}�X�^�_���폜����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="carDeleteFlg">�ԗ��폜�t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int LogicalDelete(ref object paraList, bool carDeleteFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;
            //CusCarNoteWork cusCarNoteWork = null;  �폜�\��

            ArrayList paraCustomList = paraList as ArrayList;

            //�I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ�E���l�E�Ƒ��\�����X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            //�폜�\��
            //if ((customerWork == null) && (cusCarNoteWork == null))                                //ADD 2007/08/23 M.Kubota
            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read�p�R�l�N�V�������C���X�^���X��
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ���O�C�����擾�N���X���C���X�^���X��
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                // --- ADD 2008.10.14 >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                if (customerWork.CreditMngCode == 1)
                {
                    // �p�����[�^�[�ݒ�
                    paraCustomerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                    paraCustomerChangeWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                    // ���Ӑ�}�X�^(�ϓ����)�擾
                    CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                }
                // --- ADD 2008.10.14 <<<
                // 2008.11.14 add ----------------------------------------------------------------->>
                // ���Ӑ�(�|���O���[�v)�擾
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;
                custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                // ���Ӑ�(�`�[�ԍ�)�擾
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                // 2008.11.14 add -----------------------------------------------------------------<<


                // ================================================================================= //
                // ���Ӑ�}�X�^�_���폜
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        status = this.LogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 0);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                        // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�_���폜���� >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //�p�����[�^�̃L���X�g
                                ArrayList paraCustomerChangeList = new ArrayList();
                                paraCustomerChangeList.Add(paraCustomerChangeWork);

                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraCustomerChangeList, 0, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // ���Ӑ�(�|���O���[�v)�_���폜����
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 0, ref sqlConnection, ref sqlTransaction);

                        }

                        // ���Ӑ�(�`�[�ԍ�)�_���폜����
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 0, ref sqlConnection, ref sqlTransaction);

                        }

                        // 2008.11.14 add -----------------------------------------------------------------<<

                    }
                }

                // �R�~�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        # endregion

        // ===================================================================================== //
        // LogidalDelete�֘A�@�v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�_���폜���� private int LogicalDeleteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int procMode)
        /// <summary>
        /// ���Ӑ�}�X�^�_���폜����
        /// </summary>
        /// <param name="customerWork">���Ӑ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V�����I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int LogicalDeleteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int procMode)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE CUSTOMERRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

                        // KEY�R�}���h���Đݒ�
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                        if ((myReader != null) && (!myReader.IsClosed))
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        return status;
                    }

                    sqlCommand.Cancel();

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    // �_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            return status;
                        }
                        else if (logicalDelCd == 0)
                        {
                            customerWork.LogicalDeleteCode = 1;
                        }
                        else
                        {
                            customerWork.LogicalDeleteCode = 3;
                        }
                    }
                    // �������[�h�̏ꍇ
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            customerWork.LogicalDeleteCode = 0;
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                                myReader.Dispose();
                            }

                            return status;
                        }
                    }

                    // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdcustomercode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                    paraUpdcustomercode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                    paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                    paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                    paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�Ɏ��s���܂����B", status);
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
            }

            return status;

        }
        # endregion

        // ===================================================================================== //
        // RevivalLogidalDelete�֘A�@�p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�}�X�^�_���폜�������� public int RevivalLogicalDelete(ref object paraList)
        /// <summary>
        /// ���Ӑ�}�X�^�_���폜��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̘_���폜�f�[�𕜊����܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int RevivalLogicalDelete(string enterpriseCode, int customerCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = new CustomerWork();
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read�p�R�l�N�V�������C���X�^���X��
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ���O�C�����擾�N���X���C���X�^���X��
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();


                // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�������� >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // --- ADD 2008.10.14 <<<
                // 2008.11.14 add ----------------------------------------------------------------->>
                // ���Ӑ�(�|���O���[�v)��������
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // ���Ӑ�(�`�[�ԍ�)��������
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                // 2008.11.14 add -----------------------------------------------------------------<<


                // ���Ӑ�}�X�^��������
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���Ӑ�}�X�^�p�����[�^�ݒ�
                    customerWork.EnterpriseCode = enterpriseCode;
                    customerWork.CustomerCode = customerCode;

                    // ���Ӑ�}�X�^�擾����
                    status = this.ReadCustomerWork(ref customerWork, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData1);

                    // ADD 2008.10.14 >>>
                    if (customerWork.CreditMngCode == 1)
                    {
                        // �p�����[�^�[�ݒ�
                        paraCustomerChangeWork.EnterpriseCode = enterpriseCode; // ��ƃR�[�h
                        paraCustomerChangeWork.CustomerCode = customerCode;     // ���Ӑ�R�[�h
                        // ���Ӑ�}�X�^(�ϓ����)�擾
                        CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                    }
                    // ADD 2008.10.14 <<<
                    // 2008.11.14 add ----------------------------------------------------------------->>
                    // ���Ӑ�(�|���O���[�v)�擾
                    custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                    custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                    CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                    // ���Ӑ�(�`�[�ԍ�)�擾
                    custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                    custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                    CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                    // 2008.11.14 add -----------------------------------------------------------------<<


                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.LogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 1);
                        
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add(customerWork);
                        }

                        // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�������� >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            // �p�����[�^�[�ݒ�
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //�p�����[�^�̃L���X�g
                                ArrayList paraList = new ArrayList();
                                paraList.Add(paraCustomerChangeWork);
                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraList, 1, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // ���Ӑ�(�|���O���[�v)��������
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                        // ���Ӑ�(�`�[�ԍ�)��������
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                        // 2008.11.14 add -----------------------------------------------------------------<<
                    }
                }

                // �R�~�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�����Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�����Ɏ��s���܂����B", status);
            }

            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // �폜�`�F�b�N�֘A�@�p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ���Ӑ�}�X�^�폜�`�F�b�N���� public int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
        /// <summary>
        /// ���Ӑ�}�X�^�폜�`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="checkFlg">�`�F�b�N����[true:�폜�n�j][false:�폜�m�f]</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̍폜�`�F�b�N�������s���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.09.26</br>
        /// </remarks>
        public int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
        {
            checkFlg = true;
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // ============================================================================= //
                // ���Ӑ���擾����
                // ============================================================================= //
                CustomerWork customerWork = new CustomerWork();
                customerWork.EnterpriseCode = enterpriseCode;
                customerWork.CustomerCode = customerCode;
                status = this.ReadCustomerWork(ref customerWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // OK
                    //2008.11.14 add ���Ӑ�}�X�^(�����ݒ�)�`�F�b�N���� ------------------------>>
                    SumCustStDB sumCustStDB = new SumCustStDB();
                    ArrayList retList = new ArrayList();
                    SumCustStWork sumCustStWork = new SumCustStWork();
                    sumCustStWork.EnterpriseCode = enterpriseCode;
                    sumCustStWork.SumClaimCustCode = customerCode;
                    
                    object retObj = retList;
                    object paraObj = sumCustStWork;

                    // �������Ӑ���`�F�b�N
                    status = sumCustStDB.Search(ref retObj, paraObj, 4, ConstantManagement.LogicalMode.GetData012);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���݂�����NG
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        checkFlg = false;
                        message = "�����ɐݒ�ςׁ̈A�폜�ł��܂���";
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // OK
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        sumCustStWork = new SumCustStWork();
                        sumCustStWork.EnterpriseCode = enterpriseCode;
                        sumCustStWork.CustomerCode = customerCode;

                        paraObj = sumCustStWork;

                        // �������Ӑ���`�F�b�N
                        status = sumCustStDB.Search(ref retObj, paraObj, 4, ConstantManagement.LogicalMode.GetData012);
                        
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ���݂�����NG
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            checkFlg = false;
                            message = "�����ɐݒ�ςׁ̈A�폜�ł��܂���";
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            
                            //�e���Ӑ�̏ꍇ �e�q�֌W�`�F�b�N
                            if (customerWork.CustomerCode == customerWork.ClaimCode)
                            {
                                status = this.CheckCustomerWork(ref customerWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂�����NG
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    checkFlg = false;
                                    message = "�e���Ӑ�͍폜�ł��܂���B"+Environment.NewLine;
                                    message += "�폜����ꍇ�́A�q���Ӑ���ɍ폜���ĉ������B";
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // OK
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    // �G���[
                                }
                            }
                            else
                            {
                                // OK
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            // �G���[
                        }

                    }
                    else
                    {
                        // �G���[
                    }

                    //2008.11.14 add ---------------------------------------------------------<<
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    checkFlg = false;
                    message = "���̓��Ӑ�͊��ɑ��[���ɂč폜����Ă��܂��B";
                }
                else
                {
                    // �G���[
                }

                if ((!checkFlg) || (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    return status;

            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�폜�`�F�b�N�����Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�}�X�^�폜�`�F�b�N�����Ɏ��s���܂����B", status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // �폜�`�F�b�N�֘A�@�v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ���Ӑ�e�q�֌W�`�F�b�N private int CheckCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        /// ���Ӑ�}�X�^�e�q���`�F�b�N����
        /// </summary>
        /// <param name="customerWork">���Ӑ惏�[�N�N���X</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A������R�[�h�̓��Ӑ��߂��܂�</br>
        /// <br>Programmer : 23012</br>
        /// <br>Date       : 2009.02.05</br>
        /// </remarks>
        private int CheckCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;             
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD  ���r��  2010/01/04 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/04 ----------<<<<<
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF != @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUST.CLAIMCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                
                # endregion

                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
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
            }

            return status;
        }
        #endregion

        # region ���Ӑ�폜�`�F�b�N�敪�擾����
        /*�폜�\�� (���g�p)
        /// <summary>
        /// ���Ӑ�폜�`�F�b�N�敪�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <returns>���Ӑ�폜�`�F�b�N�敪</returns>
        /// <remarks>
        /// <br>Note       : �S�̏����l�ݒ�}�X�^���A���Ӑ�폜�`�F�b�N�敪���擾���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.09.26</br>
        /// </remarks>
        private int GetCustomerDelChkDivCd(string enterpriseCode, string sectionCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int customerDelChkDivCd = 0;

            SqlDataReader myReader = null;

            try
            {
                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT CUSTOMERDELCHKDIVCDRF FROM ALLDEFSETRF " +
                    "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF=@FINDSECTIONCODE",
                    sqlConnection);

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    customerDelChkDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERDELCHKDIVCDRF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);

                #if DEBUG
                Console.WriteLine(ex.Message);
                # endif
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            }

            return customerDelChkDivCd;
        }
        */
        # endregion

        // ===================================================================================== //
        // ���̑��@�p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�����擾���� private int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        /// <summary>
        /// ���Ӑ�����擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="totalDay">����</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <param name="sqlTransaction">�r�p�k�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̒������擾���܂��B</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.GetCustomerTotalDayProc(enterpriseCode, customerCode, ref totalDay, ref sqlConnection, ref sqlTransaction);
        }
        #endregion

        # region ���Ӑ�����擾���� private int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection)
        /// <summary>
        /// ���Ӑ�����擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="totalDay">����</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̒������擾���܂��B</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.09.21</br>
        /// </remarks>
        public int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return this.GetCustomerTotalDay(enterpriseCode, customerCode, ref totalDay, ref sqlConnection, ref sqlTransaction);
        }
        # endregion

        # region �X�V���ύX�`�F�b�N���� public bool IsUpdateDateTimeChange(DateTime updateDateTime, string enterpriseCode, int customerCode)
        /// <summary>
        /// �X�V���ύX�`�F�b�N����
        /// </summary>
        /// <param name="updateDateTime">�X�V��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>true:�ύX�L�� false:�ύX����</returns>
        public bool IsUpdateDateTimeChange(DateTime updateDateTime, string enterpriseCode, int customerCode)
        {
            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return true;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            bool isChange;
            int status = this.IsUpdateDateTimeChangeProc(out isChange, updateDateTime, enterpriseCode, customerCode, sqlConnection);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isChange = true;
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return isChange;
        }
        # endregion

        // ===================================================================================== //
        // ���̑��@�v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ���Ӑ�����擾���� private int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        /// <summary>
        /// ���Ӑ�����擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="totalDay">����</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <param name="sqlTransaction">�r�p�k�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̒������擾���܂��B</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int GetCustomerTotalDayProc(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                // Select�R�}���h�̐���

                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;

                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    totalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�����擾�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�����擾�Ɏ��s���܂����B", status);
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
            }

            return status;
        }
        # endregion

        # region ���Ӑ�R�[�h�̔ԏ���
        /// <summary>
        /// ���Ӑ�R�[�h�̔ԏ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="retMsg">���^�[�����b�Z�[�W</param>
        /// <param name="sqlConnection">�r�����R�l�N�V����</param>
        /// <param name="sqlTransaction">�r�����g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h���̔Ԃ��ĕԂ��܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int CreateCustomerCode(string enterpriseCode, string sectionCode, out int customerCode, out string retMsg,ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        {
            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            customerCode = 0;
            retMsg = "";

            NumberNumbering numberNumbering = new NumberNumbering();

            //�ԍ��͈͕����[�v
            int firstNo = 0;
            int loopCnt = 0;	//�ő僋�[�v�J�E���^

            while (loopCnt <= 999999999)
            {
                string retNo;
                int no;
                Int32 ptnCd;
                Int32 noCode = 1;		// �ԍ��b�c�F���Ӑ�R�[�h

                // �ԍ��̔�
                status = numberNumbering.Numbering(enterpriseCode, sectionCode, noCode, new string[0], out retNo, out ptnCd, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    no = Convert.ToInt32(retNo);

                    // ����̔Ԕԍ���ۑ�
                    if (firstNo == 0)
                    {
                        firstNo = no;
                    }
                    //����ԍ��Ɠ���ԍ����̔Ԃ��ꂽ�ꍇ���[�v�J�E���^��Max�ɂ��ďI��
                    else if (firstNo == no)
                    {
                        loopCnt = 999999999;
                        break;
                    }

                    SqlDataReader myReader = null;

                    // ���Ӑ�R�[�h�󂫔ԃ`�F�b�N
                    try
                    {
                        // Select�R�}���h�̐���
                        SqlCommand sqlCommand = new SqlCommand("SELECT CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(no);

                        sqlCommand.CommandTimeout = 3600;
                        myReader = sqlCommand.ExecuteReader();

                        // �f�[�^�����̏ꍇ�ɂ͖߂�l���Z�b�g
                        if (!myReader.Read())
                        {
                            customerCode = no;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    catch (SqlException ex)
                    {
                        // ���N���X�ɗ�O��n���ď������Ă��炤
                        status = base.WriteSQLErrorLog(ex, "���Ӑ�R�[�h�̍̔ԂɎ��s���܂����B", ex.Number);
                        break;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "���Ӑ�R�[�h�̍̔ԂɎ��s���܂����B", status);
                        break;
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
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
                // �̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                else
                {
                    break;
                }

                // ����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                loopCnt++;
            }

            // �S�����[�v���Ă��擾�o���Ȃ��ꍇ
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "���Ӑ�R�[�h�ɋ󂫔ԍ�������܂���B�폜�\�ȓ��Ӑ���폜���Ă��������B";
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }
        # endregion

        # region �r���R���g���[������
        ///// <summary>
        ///// �r���R���g���[������
        ///// </summary>
        ///// <param name="mode">�����敪 0:Lock 1:UnLock</param>
        ///// <param name="ctrlExclsvOdAcs">�r�����i�I�u�W�F�N�g</param>
        ///// <param name="customerWork">�r���ݒ蓾�Ӑ�N���X</param>
        ///// <param name="msg">�G���[���b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        //private int ControlExclusiveProc(int mode, ref ControlExclusiveOrderAccess ctrlExclsvOdAcs,ref CustomerWork customerWork,ref string msg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    // �p�����[�^�`�F�b�N
        //    if ((customerWork == null) || (customerWork.EnterpriseCode.Trim() == "") || (customerWork.CustomerCode == 0))
        //    {
        //        return status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // �r��Lock���[�h�̏ꍇ
        //    if (mode == 0)
        //    {
        //        // ���Ӑ�R�[�h���Z�b�g
        //        Int32[] customerCodeList = new Int32[1];
        //        Int32[] acceptAnOrderNoList = new Int32[0];

        //        customerCodeList[0] = customerWork.CustomerCode;

        //        status = ctrlExclsvOdAcs.LockDB(customerWork.EnterpriseCode, customerCodeList, acceptAnOrderNoList);

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE ||
        //            status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
        //        {
        //            msg = "�r���̈דo�^�o���܂���ł����B���΂炭���҂��ɂȂ��čēx�o�^���Ă�������";
        //        }
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
        //        {
        //            msg = "�f�[�^�T�[�o�[�̐ڑ����^�C���A�E�g�ɂȂ�܂����B���΂炭���҂��ɂȂ��čēx�o�^���Ă�������";
        //        }
        //    }
        //    // �r��UnLock���[�h�̏ꍇ
        //    else
        //    {
        //        status = ctrlExclsvOdAcs.UnlockDB();
        //    }

        //    return status;
        //}
        # endregion

        # region �_���폜�敪�`�F�b�N����
        /// <summary>
        /// �_���폜�敪�`�F�b�N����
        /// </summary>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="logicalMode">�_���폜�f�[�^���o���[�h</param>
        /// <returns>0:�Y���f�[�^���� 4:�Y���f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note		: �_���폜�f�[�^���o���[�h�����ɁA�_���폜�敪�̃`�F�b�N���s���܂��B</br>
        /// <br>Programmer	: 980079 �Ȓ�  ����Y</br>
        /// <br>Date		: 2006.01.17</br>
        /// </remarks>
        private int LogicalDeleteCodeCheck(int logicalDeleteCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            switch (logicalMode)
            {
                case ConstantManagement.LogicalMode.GetData0:
                    {
                        if (logicalDeleteCode == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData01:
                    {
                        if ((logicalDeleteCode == 0) || (logicalDeleteCode == 1))
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData012:
                    {
                        if ((logicalDeleteCode == 0) || (logicalDeleteCode == 1) || (logicalDeleteCode == 2))
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData1:
                    {
                        if (logicalDeleteCode == 1)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData2:
                    {
                        if (logicalDeleteCode == 2)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData3:
                    {
                        if (logicalDeleteCode == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                default:
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
            }

            return status;
        }
        # endregion

        # region ���Ӑ�}�X�^���݃`�F�b�N
        /// <summary>
        /// ���Ӑ�}�X�^���݃`�F�b�N
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        private int ExistCheckProc(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand("SELECT CUSTOMERRF.LOGICALDELETECODERF" +
                    " FROM CUSTOMERRF" +
                    " WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE",
                    sqlConnection);

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(customerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    status = this.LogicalDeleteCodeCheck(logicalDeleteCode, logicalMode);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̑��݃`�F�b�N�Ɏ��s���܂����B", ex.Number);
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
            }
            return status;
        }
        # endregion

        # region �X�V���ύX�`�F�b�N����
        /// <summary>
        /// �X�V���ύX�`�F�b�N����
        /// </summary>
        /// <param name="isChange">�ύX�L��</param>
        /// <param name="updateDateTime">�X�V��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        private int IsUpdateDateTimeChangeProc(out bool isChange, DateTime updateDateTime, string enterpriseCode, int customerCode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            isChange = true;
            SqlDataReader myReader = null;

            try
            {
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand("SELECT CUSTOMERRF.UPDATEDATETIMERF" +
                    " FROM CUSTOMERRF" +
                    " WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
                    sqlConnection);

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(customerCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt(0);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    DateTime source = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));

                    if (source == updateDateTime)
                    {
                        isChange = false;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̍X�V���`�F�b�N�Ɏ��s���܂����B", ex.Number);
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
            }

            return status;
        }
        # endregion

        # region ���Ӑ於�̎擾����
        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCodeArray">���Ӑ�R�[�h�z��</param>
        /// <param name="nameTable">����Hashtable</param>
        /// <param name="name2Table">����2Hashtable</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�𕡐��w�肵�A���̂Ɩ��̂Q��Hashtable�Ŏ擾���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2006.06.28</br>
        /// </remarks>
        public int GetName(string enterpriseCode, int[] customerCodeArray, out Hashtable nameTable, out Hashtable name2Table)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            nameTable = new Hashtable();
            name2Table = new Hashtable();

            CustomerWork[] customerWorkArray;
            int[] statusArray;

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                status = this.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CustomerWork customerWork in customerWorkArray)
                    {
                        if (!(nameTable.ContainsKey(customerWork.CustomerCode)))
                        {
                            nameTable.Add(customerWork.CustomerCode, customerWork.Name);
                        }

                        if (!(name2Table.ContainsKey(customerWork.CustomerCode)))
                        {
                            name2Table.Add(customerWork.CustomerCode, customerWork.Name2);
                        }
                    }
                }
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // IGetSyncdataList �����o
        // ===================================================================================== //
        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">Sync�p�f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,NAMERF" + Environment.NewLine;
                sqlText += " ,NAME2RF" + Environment.NewLine;
                sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,KANARF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,POSTNORF" + Environment.NewLine;
                sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,HOMETELNORF" + Environment.NewLine;
                sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;                             
                sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;                
                sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,PURECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,NOTE1RF" + Environment.NewLine;
                sqlText += " ,NOTE2RF" + Environment.NewLine;
                sqlText += " ,NOTE3RF" + Environment.NewLine;
                sqlText += " ,NOTE4RF" + Environment.NewLine;
                sqlText += " ,NOTE5RF" + Environment.NewLine;
                sqlText += " ,NOTE6RF" + Environment.NewLine;
                sqlText += " ,NOTE7RF" + Environment.NewLine;
                sqlText += " ,NOTE8RF" + Environment.NewLine;
                sqlText += " ,NOTE9RF" + Environment.NewLine;
                sqlText += " ,NOTE10RF" + Environment.NewLine;
                // ADD 2009.02.05 >>>
                sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/06 ------<<<
                // --- ADD 2009.05.20 ------>>>
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD 2009.05.20 ------<<<
                // --- ADD  ���r��  2010/01/04 ---------->>>>>
                sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/04 ----------<<<<<
                sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25

                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF" + Environment.NewLine;
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(ReaderToCustomerWork(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̃��[�J���V���N�p�f�[�^�̎擾�Ɏ��s���܂����B", ex.Number);
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
                    sqlCommand.Dispose();
                }
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
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
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
        /// ���Ӑ�}�X�^�̓Ǎ�����(SqlDataReader)�𓾈Ӑ�}�X�^���[�N(CustomerWork)�Ɋi�[���܂��B
        /// </summary>
        /// <param name="myReader">���Ӑ�}�X�^�̓Ǎ�����</param>
        /// <param name="customerWork">���Ӑ�}�X�^���[�N</param>
        private void ReaderToCustomerWork(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region [�i�[����]
                customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));                              
                customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));                
                customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                // ADD 2009.02.05 >>>
                customerWork.SalesSlipPrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                customerWork.ShipmSlipPrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                customerWork.AcpOdrrSlipPrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                customerWork.EstimatePrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                // --- ADD 2009/04/06 ------<<<
                customerWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
                customerWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME"));
                customerWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2"));
                customerWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNM"));
                customerWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNM"));
                customerWork.OldCustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNM"));
                customerWork.ClaimSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONNAME"));
                customerWork.DepoBankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOBANKNAME"));
                customerWork.CustWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSENAME"));
                customerWork.MngSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONNAME"));
                customerWork.JobTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOBTYPENAME"));
                customerWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAME"));
                // --- ADD 2009/05/20 ------>>>
                customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));  // ���Ӑ��ƃR�[�h
                customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));  // ���Ӑ拒�_�R�[�h
                customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));  // �I�����C����ʋ敪
                // --- ADD 2009/05/20 ------<<<
                // --- ADD  ���r��  2010/01/04 ---------->>>>>
                customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));  // ���v�������o�͋敪
                customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));  // ���א������o�͋敪
                customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));  // �`�[���v�������o�͋敪
                // --- ADD  ���r��  2010/01/04 ----------<<<<<
                customerWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));    // 2010/06/25 Add
                # endregion
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�̓Ǎ�����(SqlDataReader)�𓾈Ӑ�}�X�^���[�N(CustomerWork)�Ɋi�[���܂��B
        /// </summary>
        /// <param name="myReader">���Ӑ�}�X�^�̓Ǎ�����</param>
        /// <returns>���Ӑ�}�X�^���[�N</returns>
        private CustomerWork ReaderToCustomerWork(ref SqlDataReader myReader)
        {
            CustomerWork customerWork = new CustomerWork();

            this.ReaderToCustomerWork(ref myReader, ref customerWork);

            return customerWork;
        }
        #endregion

        // --- ADD 2010/09/26 ---------->>>>>
        /// <summary>
        /// ���Ӑ�}�X�^��ALL�Ǎ�
        /// </summary>
        /// <param name="paraObj">����Para</param>
        /// <param name="customerWorkList">��������</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��ALL�Ǎ����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int Search(object paraObj,out object customerWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            customerWorkList = null;

            CustomerWork customerWork = paraObj as CustomerWork;

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            ArrayList retList = new ArrayList();

            try
            {
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                string sqlText = string.Empty;

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- �̔��G���A�敪" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- ��s�敪" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- �E��敪" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- �Ǝ�敪" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;

                # endregion

                // Select�R�}���h�̐���
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    customerWork = new CustomerWork();
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);
                    retList.Add(customerWork);
                }

                customerWorkList = (object)retList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̃��[�J���V���N�p�f�[�^�̎擾�Ɏ��s���܂����B", ex.Number);
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
                    sqlCommand.Dispose();
                }

                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        // --- ADD 2010/09/26 ----------<<<<<
        // ADD �� K2014/02/06 ------------------------------------->>>>>
        #region ���O�����a�����

        # region �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�ǂݍ��ݏ���
        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�ǂݍ��ݏ���
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̓��Ӑ��߂��܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiRead(ConstantManagement.LogicalMode logicalMode, ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            // �I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ惊�X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                // ���Ӑ�}�X�^�ǂݍ��ݏ���
                status = this.MaehashiReadCustomerWork(ref customerWork, ref sqlConnection, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    customSerializeArrayList.Add(customerWork);
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�ǂݍ��ݏ���
        /// </summary>
        /// <param name="customerWork">���Ӑ惏�[�N�N���X</param>
        /// <param name="sqlConnection">�r�p�k�R�l�N�V����</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�A���Ӑ�R�[�h�̓��Ӑ��߂��܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// <br>Note       : ���Ӑ���K�C�h�\��PKG�Ή��ɂē��Ӑ�K�C�h�\���敪�ǉ�</br>
        /// <br>Programmer : ���J�M�m</br>
        /// <br>Date       : 2021/05/10</br>
        /// </remarks>
        private int MaehashiReadCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUSTMEMO.NOTEINFORF" + Environment.NewLine;
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                sqlText += " ,ISNULL(CUSTMEMO.DISPLAYDIVCODERF, 0) AS DISPLAYDIVCODERF" + Environment.NewLine;  //���Ӑ�}�X�^�i�������j�̃��R�[�h���Ȃ��ꍇ��0�F�\���������\�����邽��
                // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- �̔��G���A�敪" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- ��s�敪" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- �E��敪" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- �Ǝ�敪" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERMEMORF AS CUSTMEMO" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CUSTMEMO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF = CUSTMEMO.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                # endregion

                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.MaehashiReaderToCustomerWork(ref myReader, ref customerWork);

                    // �_���폜�敪�`�F�b�N����
                    status = this.LogicalDeleteCodeCheck(customerWork.LogicalDeleteCode, logicalMode);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
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
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�̓Ǎ�����(SqlDataReader)�𓾈Ӑ�}�X�^���[�N(CustomerWork)�Ɋi�[���܂��B
        /// </summary>
        /// <param name="myReader">���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�̓Ǎ�����</param>
        /// <param name="customerWork">���Ӑ�}�X�^���[�N</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ���K�C�h�\���敪��ǉ�</br>
        /// <br>Programmer : ���J �M�m</br>
        /// <br>Date       : 2021/05/10</br>
        /// </remarks>
        private void MaehashiReaderToCustomerWork(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region [�i�[����]
                customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
                customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                customerWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
                customerWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME"));
                customerWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2"));
                customerWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNM"));
                customerWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNM"));
                customerWork.OldCustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNM"));
                customerWork.ClaimSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONNAME"));
                customerWork.DepoBankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOBANKNAME"));
                customerWork.CustWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSENAME"));
                customerWork.MngSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONNAME"));
                customerWork.JobTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOBTYPENAME"));
                customerWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAME"));
                customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));  // ���Ӑ��ƃR�[�h
                customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));  // ���Ӑ拒�_�R�[�h
                customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));  // �I�����C����ʋ敪
                customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));  // ���v�������o�͋敪
                customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));  // ���א������o�͋敪
                customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));  // �`�[���v�������o�͋敪
                customerWork.NoteInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTEINFORF"));  // ����
                customerWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));
                // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                customerWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));
                // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                # endregion
            }
        }

        # endregion

        # region �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�o�^����
        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�o�^����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">�d���G���[���̏d������</param>
        /// <param name="carMngNo">���Ӑ�Ǝԗ��𓯎��o�^����ۂ̎ԗ��Ǘ��ԍ�</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiWrite(ref object paraList, out ArrayList duplicationItemList, int carMngNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMsg = "";
            duplicationItemList = new ArrayList();

            int customerCode = 0;
            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;


            // �I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ�E���l�E�Ƒ��\�����X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;

                            // ���Ӑ�R�[�h�Ɗ�ƃR�[�h��Ҕ�
                            if (customerCode == 0)
                            {
                                customerCode = customerWork.CustomerCode;
                            }
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

            try
            {
                // �o�^�O�̓��Ӑ���p
                CustomerWork customerWorkBef = new CustomerWork();

                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;

                ArrayList WriteCustomList = new ArrayList();
                ArrayList changeWorkLogicalDeleteList = new ArrayList();
                ArrayList changeWorkWriteList = new ArrayList();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    // �g�����U�N�V�����X�^�[�g
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // ���O�C�����擾�N���X���C���X�^���X��
                    ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
                    changeWorkLogicalDeleteList = new ArrayList();
                    changeWorkWriteList = new ArrayList();

                    for (int i = 0; i < paraCustomList.Count; i++)
                    {
                        customerWork = paraCustomList[i] as CustomerWork;
                        customerCode = customerWork.CustomerCode;
                        // ================================================================================= //
                        // ���Ӑ�X�V�O���擾
                        // ================================================================================= //
                        if (customerWork != null)
                        {
                            if ((customerWork.EnterpriseCode.Trim() != "") && (customerWork.CustomerCode != 0))
                            {
                                // 2009.02.20
                                // Read�p�R�l�N�V�������C���X�^���X��
                                SqlConnection sqlConnection_read = new SqlConnection(connectionText);
                                sqlConnection_read.Open();

                                customerWorkBef.EnterpriseCode = customerWork.EnterpriseCode;
                                customerWorkBef.CustomerCode = customerWork.CustomerCode;

                                // ���Ӑ���擾�i�o�^�O�j
                                status = this.MaehashiReadCustomerWork(ref customerWorkBef, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData0);

                                if (customerWork.CreditMngCode == 1)
                                {
                                    customerChangeWork = new CustomerChangeWork();
                                    customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode;
                                    customerChangeWork.CustomerCode = customerWork.CustomerCode;
                                    // ���Ӑ�}�X�^(�ϓ����)�擾
                                    CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                                }   

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    // �Y���f�[�^�����̏ꍇ�͐���Ƃ���
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                sqlConnection_read.Close();
                            }
                        }

                        // ================================================================================= //
                        // ���Ӑ�R�[�h�̍̔�
                        // ================================================================================= //
                        // ���Ӑ�R�[�h�������Ă��Ȃ��ꍇ�̂�
                        if (customerCode == 0)
                        {
                            // ���͋��_�R�[�h��ޔ�
                            string sectionCode = customerWork.InpSectionCode;

                            // ���Ӑ�R�[�h�̔ԏ���
                            status = this.CreateCustomerCode(customerWork.EnterpriseCode, sectionCode, out customerCode, out retMsg, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (customerWork.CustomerCode != 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }

                                if (customerWork != null)
                                {
                                    if (customerWork.CustomerCode == 0)
                                    {
                                        customerWork.CustomerCode = customerCode;
                                    }

                                    if (customerWork.ClaimCode == 0)
                                    {
                                        customerWork.ClaimCode = customerCode;
                                    }

                                }
                            }
                            else
                            {
                                duplicationItemList.Add(retMsg);
                            }
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ���Ӑ�}�X�^�������݃��X�g�쐬
                            WriteCustomList.Add(customerWork);

                            // ���Ӑ�}�X�^(�ϓ����)�������݃��X�g�쐬
                            // �^�M�Ǘ�=1:����@���@�e���Ӑ�
                            if ((customerWork.CreditMngCode == 1) && (customerWork.ClaimCode == customerWork.CustomerCode))
                            {
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ��������
                                    if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    changeWorkLogicalDeleteList.Add(customerChangeWork);
                                }
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // �V�K�쐬����
                                    if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    changeWorkWriteList.Add(customerChangeWork);
                                }
                            }

                        }
                    }

                    // ���Ӑ�}�X�^����
                    for (int i = 0; i < WriteCustomList.Count; i++)
                    {
                        customerWork = WriteCustomList[i] as CustomerWork;
                        status = this.MaehashiWriteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, ref duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                    }
                    // << ���Ӑ�}�X�^(�ϓ����)�������ݏ��� >>
                    if (changeWorkLogicalDeleteList.Count > 0)
                    {
                        if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                        {
                            // �X�V����
                            customerChangeDB.WriteProc(ref changeWorkLogicalDeleteList, ref sqlConnection, ref sqlTransaction);
                        }
                        else
                        {
                            // ��������
                            customerChangeDB.LogicalDeleteProc(ref changeWorkLogicalDeleteList, 1, ref sqlConnection, ref sqlTransaction);
                        }
                    }
                    if (changeWorkWriteList.Count > 0)
                    {
                        // �V�K�쐬����
                        customerChangeDB.WriteProc(ref changeWorkWriteList, ref sqlConnection, ref sqlTransaction);
                    }

                    // �R�~�b�g
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sqlTransaction.Commit();
                    }
                }
                else
                {
                    if (retMsg.Trim() != "")
                    {
                        duplicationItemList.Add(retMsg);
                    }
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̏������݂Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {

                // �g�����U�N�V�����j��
                if (sqlTransaction != null) sqlTransaction.Dispose();

                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�f�[�^�o�^����
        /// </summary>
        /// <param name="customerWork">�o�^�󓾈Ӑ��</param>
        /// <param name="sqlConnection">sql�R�l�N�V�����I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="duplicationItemList">�d���G���[���̏d������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// <br>Note       : ���Ӑ���K�C�h�\���敪��ǉ�</br>
        /// <br>Programmer : ���J �M�m</br>
        /// <br>Date       : 2021/05/10</br>
        /// </remarks>
        private int MaehashiWriteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref ArrayList duplicationItemList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            DateTime updDateTimeTmp = customerWork.UpdateDateTime;
            try
            {
                #region ���Ӑ�}�X�^DB�̏���
                // Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Parameter�I�u�W�F�N�g�̃N���A
                    sqlCommand.Parameters.Clear();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (customerWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        string sqlText = string.Empty;

                        if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C�� 
                        {
                            # region [UPDATE��]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMEREPCODERF = @CUSTOMEREPCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERSECCODERF = @CUSTOMERSECCODE" + Environment.NewLine;
                            sqlText += " , ONLINEKINDDIVRF = @ONLINEKINDDIV" + Environment.NewLine;
                            sqlText += " , TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " , DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " , SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " , SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        else if (customerWork.WriteDiv == 1)  // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C�� 
                        {
                            # region [UPDATE��]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        sqlCommand.CommandText = sqlText;

                        // KEY�R�}���h���Đݒ�
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (customerWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        // �V�K�쐬����SQL���𐶐�

                        string sqlText = string.Empty;
                        if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                        {
                            # region [INSERT��]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMEREPCODERF " + Environment.NewLine;
                            sqlText += " ,CUSTOMERSECCODERF " + Environment.NewLine;
                            sqlText += " ,ONLINEKINDDIVRF " + Environment.NewLine;
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            sqlText += " ,@SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMEREPCODE " + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSECCODE " + Environment.NewLine;
                            sqlText += " ,@ONLINEKINDDIV " + Environment.NewLine;
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            # endregion
                        }
                        else if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                        {
                            # region [INSERT��]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;

                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;

                            sqlText += " ,@SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            # endregion

                        }
                        sqlCommand.CommandText = sqlText;

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��                    
                    {
                        # region Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar);
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraCustomerEpCode = sqlCommand.Parameters.Add("@CUSTOMEREPCODE", SqlDbType.NChar);  // ���Ӑ��ƃR�[�h
                        SqlParameter paraCustomerSecCode = sqlCommand.Parameters.Add("@CUSTOMERSECCODE", SqlDbType.NChar);  // ���Ӑ拒�_�R�[�h
                        SqlParameter paraOnlineKindDiv = sqlCommand.Parameters.Add("@ONLINEKINDDIV", SqlDbType.Int);  // �I�����C����ʋ敪
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar);  // �ȒP�⍇���A�J�E���g�O���[�vID
                        // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                        SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);
                        // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                        SqlParameter paraNoteInfo = sqlCommand.Parameters.Add("@NOTEINFO", SqlDbType.NChar);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);

                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);

                        paraCustomerEpCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerEpCode);  // ���Ӑ��ƃR�[�h
                        paraCustomerSecCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSecCode);  // ���Ӑ拒�_�R�[�h
                        paraOnlineKindDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.OnlineKindDiv);  // �I�����C����ʋ敪
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);  // �ȒP�⍇���A�J�E���g�O���[�vID
                        // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                        paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DisplayDivCode);    //���Ӑ�K�C�h�\���敪
                        // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                        paraNoteInfo.Value = SqlDataMediator.SqlSetString(customerWork.NoteInfo);   // ����
                        # endregion
                    }
                    else if (customerWork.WriteDiv == 1) // 0:���Ӑ�}�X�^ 1:���Ӑ�ꊇ�C��
                    {
                        # region Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar); // ADD 2008.12.10
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);

                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);

                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);
                        # endregion
                    }
                    sqlCommand.ExecuteNonQuery();
                }
                #endregion

                #region ���Ӑ惁��DB�̏���
                // Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERMEMORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Parameter�I�u�W�F�N�g�̃N���A
                    sqlCommand.Parameters.Clear();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        string sqlText = string.Empty;

                        if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^
                        {
                            # region [UPDATE��]
                            sqlText += "UPDATE CUSTOMERMEMORF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                            sqlText += " ,DISPLAYDIVCODERF = @DISPLAYDIVCODE" + Environment.NewLine;    //���Ӑ���K�C�h�\���敪
                            // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                            sqlText += " ,NOTEINFORF = @NOTEINFO" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        sqlCommand.CommandText = sqlText;

                        // KEY�R�}���h���Đݒ�
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // �V�K�쐬����SQL���𐶐�

                        string sqlText = string.Empty;
                        if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^
                        {
                            # region [INSERT��]
                            sqlText += "INSERT INTO CUSTOMERMEMORF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                            sqlText += " ,DISPLAYDIVCODERF" + Environment.NewLine;    //���Ӑ���K�C�h�\���敪
                            // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                            sqlText += " ,NOTEINFORF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                            sqlText += " ,@DISPLAYDIVCODE" + Environment.NewLine;    //���Ӑ���K�C�h�\���敪
                            // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                            sqlText += " ,@NOTEINFO" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            # endregion
                        }
                        sqlCommand.CommandText = sqlText;

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    if (customerWork.WriteDiv == 0) // 0:���Ӑ�}�X�^                  
                    {
                        # region Parameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                        SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);    //���Ӑ���K�C�h�\���敪
                        // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                        SqlParameter paraNoteInfo = sqlCommand.Parameters.Add("@NOTEINFO", SqlDbType.NChar);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        // --- ADD ���J �M�m 2021/05/10 ---------->>>>>
                        paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DisplayDivCode);    //���Ӑ���K�C�h�\���敪
                        // --- ADD ���J �M�m 2021/05/10 ----------<<<<<
                        paraNoteInfo.Value = SqlDataMediator.SqlSetString(customerWork.NoteInfo);   // ����
                        # endregion
                    }
                    sqlCommand.ExecuteNonQuery();
                }
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̏����݂Ɏ��s���܂����B", ex.Number);
                sqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            return status;
        }
        # endregion

        # region �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�_���폜����
        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�_���폜����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="carDeleteFlg">�ԗ��폜�t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB��_���폜���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiLogicalDelete(ref object paraList, bool carDeleteFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            //�I�u�W�F�N�g�̎擾(�J�X�^��Array�����猟��)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ�E���l�E�Ƒ��\�����X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            //�폜�\��
            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read�p�R�l�N�V�������C���X�^���X��
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ���O�C�����擾�N���X���C���X�^���X��
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                if (customerWork.CreditMngCode == 1)
                {
                    // �p�����[�^�[�ݒ�
                    paraCustomerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                    paraCustomerChangeWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                    // ���Ӑ�}�X�^(�ϓ����)�擾
                    CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                }
                // ���Ӑ�(�|���O���[�v)�擾
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;
                custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                // ���Ӑ�(�`�[�ԍ�)�擾
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);



                // ================================================================================= //
                // ���Ӑ�}�X�^�_���폜
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        status = this.MaehashiLogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 0);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                        if (customerWork.CreditMngCode == 1)
                        {
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //�p�����[�^�̃L���X�g
                                ArrayList paraCustomerChangeList = new ArrayList();
                                paraCustomerChangeList.Add(paraCustomerChangeWork);

                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraCustomerChangeList, 0, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // ���Ӑ�(�|���O���[�v)�_���폜����
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 0, ref sqlConnection, ref sqlTransaction);

                        }

                        // ���Ӑ�(�`�[�ԍ�)�_���폜����
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 0, ref sqlConnection, ref sqlTransaction);

                        }


                    }
                }

                // �R�~�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�_���폜����
        /// </summary>
        /// <param name="customerWork">���Ӑ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V�����I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB��_���폜���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        private int MaehashiLogicalDeleteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int procMode)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE CUSTOMERRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText += Environment.NewLine;
                        // CUSTOMERMEMORF���O�����a����ʂɐV�ǉ��������Ӑ惁��DB���A�b�v�f�[�g����B
                        sqlCommand.CommandText += "UPDATE CUSTOMERMEMORF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        // KEY�R�}���h���Đݒ�
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                        if ((myReader != null) && (!myReader.IsClosed))
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        return status;
                    }

                    sqlCommand.Cancel();

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    // �_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            return status;
                        }
                        else if (logicalDelCd == 0)
                        {
                            customerWork.LogicalDeleteCode = 1;
                        }
                        else
                        {
                            customerWork.LogicalDeleteCode = 3;
                        }
                    }
                    // �������[�h�̏ꍇ
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            customerWork.LogicalDeleteCode = 0;
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                                myReader.Dispose();
                            }

                            return status;
                        }
                    }

                    // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdcustomercode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                    paraUpdcustomercode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                    paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                    paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                    paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�Ɏ��s���܂����B", status);
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
            }

            return status;

        }
        # endregion

        #region �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�����폜����
        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB��������
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�𕨗��폜���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiDelete(ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            if (paraCustomList == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B�Ώۃp�����[�^�����w��ł�", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List���̓��Ӑ�E���l�E�Ƒ��\�����X�g�𒊏o
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("�v���O�����G���[�B���o�ΏۃI�u�W�F�N�g�p�����[�^�����w��ł��B", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read�p�R�l�N�V�������C���X�^���X��
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ���O�C�����擾�N���X���C���X�^���X��
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                // --- ADD 2008.10.14 >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // ���Ӑ�(�|���O���[�v)�����폜
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // ���Ӑ�(�`�[�ԍ�)�����폜
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;


                // ================================================================================= //
                // ���Ӑ�}�X�^�����폜
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        // --- ADD 2008.10.14 ���Ӑ�}�X�^(�ϓ����)�����폜���� >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            // �p�����[�^�[�ݒ�
                            customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                            customerChangeWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                            // ���Ӑ�}�X�^(�ϓ����)�擾
                            CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                        }
                        // ���Ӑ�(�|���O���[�v)�擾
                        custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                        custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                        CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                        // ���Ӑ�(�`�[�ԍ�)�擾
                        custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                        custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                        CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);


                        status = this.MaehashiDeleteProc(ref customerWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                         
                        if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�p�����[�^�̃L���X�g
                            ArrayList changeWorkparaList = new ArrayList();
                            changeWorkparaList.Add(customerChangeWork);
                            CusChangestatus = customerChangeDB.DeleteProc(changeWorkparaList, ref sqlConnection, ref sqlTransaction);

                        }
                        // ���Ӑ�(�|���O���[�v)�����폜����
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.Delete(custRateGroupList, ref sqlConnection, ref sqlTransaction);

                        }

                        // ���Ӑ�(�`�[�ԍ�)�����폜����
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.Delete(custSlipNoSetList, ref sqlConnection, ref sqlTransaction);

                        }


                    }
                }

                // �R�~�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̕����폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB��������
        /// </summary>
        /// <param name="customerWork">CustomSerializeList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�𕨗��폜���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        private int MaehashiDeleteProc(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != customerWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    //Delete�R�}���h�̐���
                    #region [DELETE��]
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += Environment.NewLine;
                    // ���Ӑ惁��DB
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM CUSTOMERMEMORF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion

                    // KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                }
                else
                {
                    // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }

                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̕����폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�}�X�^�̕����폜�Ɏ��s���܂����B", status);
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
            }

            return status;
        }
        #endregion

        # region �O�����a����ʂɂ��āA���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�_���폜��������
        /// <summary>
        /// ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�_���폜��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�̘_���폜�f�[�𕜊����܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiRevivalLogicalDelete(string enterpriseCode, int customerCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = new CustomerWork();
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read�p�R�l�N�V�������C���X�^���X��
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ���O�C�����擾�N���X���C���X�^���X��
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();


                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // ���Ӑ�(�|���O���[�v)��������
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // ���Ӑ�(�`�[�ԍ�)��������
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;


                // ���Ӑ�}�X�^��������
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���Ӑ�}�X�^�p�����[�^�ݒ�
                    customerWork.EnterpriseCode = enterpriseCode;
                    customerWork.CustomerCode = customerCode;

                    // ���Ӑ�}�X�^�擾����
                    status = this.MaehashiReadCustomerWork(ref customerWork, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData1);

                    if (customerWork.CreditMngCode == 1)
                    {
                        // �p�����[�^�[�ݒ�
                        paraCustomerChangeWork.EnterpriseCode = enterpriseCode; // ��ƃR�[�h
                        paraCustomerChangeWork.CustomerCode = customerCode;     // ���Ӑ�R�[�h
                        // ���Ӑ�}�X�^(�ϓ����)�擾
                        CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                    }
                    // ���Ӑ�(�|���O���[�v)�擾
                    custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                    custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                    CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                    // ���Ӑ�(�`�[�ԍ�)�擾
                    custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // ��ƃR�[�h
                    custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // ���Ӑ�R�[�h
                    CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);



                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.MaehashiLogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 1);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add(customerWork);
                        }

                        if (customerWork.CreditMngCode == 1)
                        {
                            // �p�����[�^�[�ݒ�
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //�p�����[�^�̃L���X�g
                                ArrayList paraList = new ArrayList();
                                paraList.Add(paraCustomerChangeWork);
                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraList, 1, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // ���Ӑ�(�|���O���[�v)��������
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                        // ���Ӑ�(�`�[�ԍ�)��������
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                    }
                }

                // �R�~�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // ��O����
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�����Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "���Ӑ�}�X�^�̘_���폜�����Ɏ��s���܂����B", status);
            }

            finally
            {
                // �R�l�N�V�����j��
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            return status;
        }
        # endregion

        #endregion ���O�����a�����
        // ADD �� K2014/02/06 --------------------------------------<<<<<
    }
}
