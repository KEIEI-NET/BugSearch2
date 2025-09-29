//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���[�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/05/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�����ݒ�}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���[�����ݒ�}�X�^�e�[�u���̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer	: �����</br>
    /// <br>Date		: 2010/05/24</br>
    /// <br></br>
    /// </remarks>
    public class MailInfoSettingAcs
    {
        # region -- Private Members --
        /// <summary> �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ </summary>
        private IMailInfoSettingDB _iMailInfoSettingDB = null;
        /// <summary>���_��񕔕i</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
        /// <summary>���_���ێ��e�[�u��</summary>
        private Hashtable _secInfoSetTable = null;
        /// <summary>���O�C�����_</summary>
        private string _loginSectionCode = "";
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        ///  ���[�����ݒ�}�X�^�����e�i���X�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���[�����ݒ�}�X�^�����e�i���X�A�N�Z�X�N���X�̃R���X�g���N�^�ł��B</br>
        /// <br>Programer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        public MailInfoSettingAcs()
        {
            // ��������������
            MemoryCreate();

            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            try
            {
                this._secInfoSetTable = null;
                // �����[�g�I�u�W�F�N�g�擾
                this._iMailInfoSettingDB = (IMailInfoSettingDB)MediationMailInfoSettingDB.GetMailInfoSettingDB();

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iMailInfoSettingDB = null;
            }

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee;
            if (loginEmployee != null)
            {
                this._loginSectionCode = loginEmployee.BelongSectionCode;
            }
        }
        # endregion

        # region [���[�J���A�N�Z�X�p]
        /// <summary> �I�����C�����[�h�̗񋓌^ </summary>
        public enum OnlineMode
        {
            /// <summary> �I�t���C�� </summary>
            Offline,
            /// <summary> �I�����C�� </summary>
            Online
        }

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note		: �I�����C�����[�h���擾���܂�</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iMailInfoSettingDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }
        # endregion

        # region -- �������� --
        /// <summary>
        /// ���[�����ݒ�}�X�^�N���X�ǂݍ��ݏ���
        /// </summary>
        /// <param name="mailInfoSetting">���[�����ݒ�}�X�^�N���X�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�}�X�^�N���X����ǂݍ��݂܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Read(out MailInfoSetting mailInfoSetting, string enterpriseCode, string sectionCode)
        {
            try
            {
                mailInfoSetting = null;
                MailInfoSettingWork mailSndMngWork = new MailInfoSettingWork();
                mailSndMngWork.EnterpriseCode = enterpriseCode;
                mailSndMngWork.SectionCode = sectionCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);

                // ���[�����M�Ǘ��t�B�[���h���̓ǂݍ���
                int status = this._iMailInfoSettingDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    mailSndMngWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // �N���X�������o�R�s�[
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailSndMngWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                mailInfoSetting = null;
                //�I�t���C������null���Z�b�g
                this._iMailInfoSettingDB = null;
                return -1;
            }
        }

        /// <summary>
        /// �S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�}�X�^�̑S�����������s���܂��B</br>
        /// <br>	       : �_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchMailInfoSettingProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
        }

        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�}�X�^�̑S�����������s���܂��B</br>
        /// <br>		   : �_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, MailInfoSetting prevMailInfoSetting)
        {
            return SearchMailInfoSettingProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevMailInfoSetting);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int SearchMailInfoSettingProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MailInfoSetting prevMailInfoSetting)
        {
            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();
            if (prevMailInfoSetting != null)
            {
                mailInfoSettingWork = CopyToMailInfoSettingWorkFromMailInfoSetting(prevMailInfoSetting);
            }
            mailInfoSettingWork.EnterpriseCode = enterpriseCode;

            // ���f�[�^�L��������
            nextData = false;
            // 0�ŏ�����
            retTotalCnt = 0;

            MailInfoSettingWork[] al;
            retList = new ArrayList();
            retList.Clear();

            // ���_���擾����
            ArrayList wkList = new ArrayList();
            wkList.Clear();

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

            byte[] retbyte;

            // ���[�����ݒ�}�X�^����
            int status = 0;
            if (readCnt == 0)
            {
                status = this._iMailInfoSettingDB.Search(out retbyte, parabyte, 0, logicalMode);
            }
            else
            {
                status = this._iMailInfoSettingDB.SearchSpecification(out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt);
            }

            if ((status == 0) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // XML�̓ǂݍ���
                al = (MailInfoSettingWork[])XmlByteSerializer.Deserialize(retbyte, typeof(MailInfoSettingWork[]));

                for (int i = 0; i < al.Length; i++)
                {
                    // �T�[�`���ʎ擾
                    MailInfoSettingWork wkMailInfoSettingWork = (MailInfoSettingWork)al[i];
                    // ���[�����ݒ�}�X�^�N���X�փ����o�R�s�[
                    wkList.Add(CopyToMailInfoSettingFromMailInfoSettingWork(wkMailInfoSettingWork));
                }

                retList = wkList;
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0)
            {
                retTotalCnt = retList.Count;
            }

            return status;
        }

        /// <summary>
        /// ���[�����ݒ菈��
        /// </summary>
        /// <param name="mailInfoSetting">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ݒ荀�ڃ��R�[�h��ǉ����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int AddNewBrSetItemRecord(out MailInfoSetting mailInfoSetting, string enterpriseCode, string sectionCode)
        {
            mailInfoSetting = new MailInfoSetting();

            mailInfoSetting.EnterpriseCode = enterpriseCode;			// ��ƃR�[�h
            mailInfoSetting.SectionCode = sectionCode;				// ���_�R�[�h  

            mailInfoSetting.MailSendMngNo = 0;		// e-mail���M�Ǘ��ԍ�
            mailInfoSetting.SenderName = "";		// ���o�l��
            mailInfoSetting.MailAddress = "";	    // ���[���A�h���X
            mailInfoSetting.Pop3UserId = "";		// POP3���[�U�[ID
            mailInfoSetting.Pop3Password = "";	    // POP3�p�X���[�h
            mailInfoSetting.Pop3ServerName = "";		// POP3�T�[�o�[��
            mailInfoSetting.SmtpServerName = "";		// SMTP�T�[�o�[��
            mailInfoSetting.SmtpAuthUseDiv = 0;	    // SMTP�F�؎g�p�敪
            mailInfoSetting.PopBeforeSmtpUseDiv = 0;		// POP Before SMTP�g�p�敪
            mailInfoSetting.SmtpUserId = "";	    // SMTP���[�U�[ID
            mailInfoSetting.SmtpPassword = "";	    // SMTP�p�X���[�h
            mailInfoSetting.PopServerPortNo = 0;		// POP�T�[�o�[�|�[�g�ԍ�
            mailInfoSetting.SmtpServerPortNo = 0;		// SMTP�T�[�o�[�|�[�g�ԍ�
            mailInfoSetting.MailServerTimeoutVal = 0;	    // ���[���T�[�o�[�^�C���A�E�g�l
            mailInfoSetting.BackupSendDivCd = 1;	    // �o�b�N�A�b�v���M�敪
            mailInfoSetting.BackupFormal = 0;		// �o�b�N�A�b�v�`��
            mailInfoSetting.MailSendDivUnitCnt = 0;		// ���[�����M�����P�ʌ���

            // �V�K�o�^����
            int status = this.Write(ref mailInfoSetting);
            return status;
        }
        # endregion

        # region -- �o�^��X�V���� --
        /// <summary>
        /// ���[�����ݒ�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="mailInfoSetting">���[�����ݒ�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�}�X�^�o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Write(ref MailInfoSetting mailInfoSetting)
        {
            // ���[�����ݒ�}�X�^�N���X���烁�[�����ݒ�}�X�^���[�J�[�N���X�Ƀ����o�R�s�[
            MailInfoSettingWork mailInfoSettingWork = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

            int status = 0;
            try
            {
                // ���[�����ݒ�}�X�^���[�N��������
                status = this._iMailInfoSettingDB.Write(ref parabyte);
                if (status == 0)
                {
                    // �t�@�C������n���ă��[�����ݒ�}�X�^���[�N�N���X���f�V���A���C�Y����
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // �N���X�������o�R�s�[
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailInfoSettingWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iMailInfoSettingDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }
        # endregion

        #region -- �폜��������� --
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="mailInfoSetting">�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����폜���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Delete(MailInfoSetting mailInfoSetting)
        {
            try
            {
                MailInfoSettingWork mailInfoSettingWorks = new MailInfoSettingWork();
                mailInfoSettingWorks = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);

                byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWorks);

                // �����폜
                int status = this._iMailInfoSettingDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iMailInfoSettingDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="mailInfoSetting">�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �_���폜���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int LogicalDelete(ref MailInfoSetting mailInfoSetting)
        {
            try
            {
                MailInfoSettingWork mailInfoSettingWork = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);
                // �C�ӕی��K�C�h�_���폜
                int status = this._iMailInfoSettingDB.LogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ĔC�ӕی��K�C�h���[�N�N���X���f�V���A���C�Y����
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // �N���X�������o�R�s�[
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailInfoSettingWork);

                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iMailInfoSettingDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���[�����ݒ�}�X�^�_���폜��������
        /// </summary>
        /// <param name="mailInfoSetting">���[�����ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�}�X�^�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Revival(ref MailInfoSetting mailInfoSetting)
        {
            try
            {
                MailInfoSettingWork mailSndMngWork = CopyToMailInfoSettingWorkFromMailInfoSetting(mailInfoSetting);
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
                // ��������
                int status = this._iMailInfoSettingDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
                    mailSndMngWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));
                    // �N���X�������o�R�s�[
                    mailInfoSetting = CopyToMailInfoSettingFromMailInfoSettingWork(mailSndMngWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iMailInfoSettingDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        # endregion

        # region -- ���_�̏��� --
        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_���̌����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int GetAliveSectionCodeList(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            // �{�Ћ@�\�̏ꍇ
            if (secInfoAcs.SecInfoSet.MainOfficeFuncFlag == SecInfoSet.CONSTMAINOFFICEFUNCFLAG_MAIN)
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    retList.Add(secInfoSet.SectionCode);
                }
            }
            else
            {
                retList.Add(secInfoAcs.SecInfoSet.SectionCode);
            }

            if (retList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            return status;
        }

        /// <summary>
        /// ���_�K�C�h���̓Ǎ�
        /// </summary>
        /// <param name="sectionName">���_��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�擾����</returns>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h���狒�_�K�C�h���̂��擾���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int ReadSectionName(out string sectionName, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            sectionName = "";

            if (sectionCode.Trim().Equals(""))
            {
                return status;
            }

            sectionCode = sectionCode.Trim().PadLeft(2, '0');
            if (this._secInfoSetTable == null)
            {
                status = SetSecInfoSetTable();
                if ((status != 0) && (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
            }

            if (this._secInfoSetTable.ContainsKey(sectionCode.TrimEnd()) == true)
            {
                SecInfoSet secInfoSet = (SecInfoSet)this._secInfoSetTable[sectionCode.TrimEnd()];
                if (secInfoSet.LogicalDeleteCode != 0)			// �_���폜����Ă���ꍇ
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sectionName = "�폜��";						// ���_��
                }
                else											// �_���폜����Ă��Ȃ��ꍇ
                {
                    sectionName = secInfoSet.SectionGuideSnm;	// ���_��
                }
            }
            else
            {
                //sectionName = "���o�^";							// ���_��
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���_���ێ��e�[�u���ݒ菈��
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_���ێ��e�[�u���ɋ��_�����Z�b�g���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int SetSecInfoSetTable()
        {
            int status = 0;
            this._secInfoSetTable = new Hashtable();
            this._secInfoSetTable.Clear();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
            {
                this._secInfoSetTable.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.Clone());
            }

            if (this._secInfoSetTable.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �N���X�����o�R�s�[�����i���[�����ݒ�}�X�^���[�N�N���X�˃��[�����ݒ�}�X�^�N���X�j
        /// </summary>
        /// <param name="mailInfoSettingWork">���[�����ݒ�}�X�^���[�N�N���X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ���[�����ݒ�}�X�^���[�N�N���X���烁�[�����ݒ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private MailInfoSetting CopyToMailInfoSettingFromMailInfoSettingWork(MailInfoSettingWork mailInfoSettingWork)
        {
            MailInfoSetting mailInfoSetting = new MailInfoSetting();

            mailInfoSetting.CreateDateTime = mailInfoSettingWork.CreateDateTime;
            mailInfoSetting.UpdateDateTime = mailInfoSettingWork.UpdateDateTime;
            mailInfoSetting.EnterpriseCode = mailInfoSettingWork.EnterpriseCode;
            mailInfoSetting.FileHeaderGuid = mailInfoSettingWork.FileHeaderGuid;
            mailInfoSetting.UpdEmployeeCode = mailInfoSettingWork.UpdEmployeeCode;
            mailInfoSetting.UpdAssemblyId1 = mailInfoSettingWork.UpdAssemblyId1;
            mailInfoSetting.UpdAssemblyId2 = mailInfoSettingWork.UpdAssemblyId2;
            mailInfoSetting.LogicalDeleteCode = mailInfoSettingWork.LogicalDeleteCode;
            mailInfoSetting.SectionCode = mailInfoSettingWork.SectionCode;
            mailInfoSetting.MailSendMngNo = mailInfoSettingWork.MailSendMngNo;
            mailInfoSetting.MailAddress = mailInfoSettingWork.MailAddress;
            mailInfoSetting.DialUpCode = mailInfoSettingWork.DialUpCode;
            mailInfoSetting.DialUpConnectName = mailInfoSettingWork.DialUpConnectName;
            mailInfoSetting.DialUpLoginName = mailInfoSettingWork.DialUpLoginName;
            mailInfoSetting.DialUpPassword = mailInfoSettingWork.DialUpPassword;
            mailInfoSetting.AccessTelNo = mailInfoSettingWork.AccessTelNo;
            mailInfoSetting.Pop3UserId = mailInfoSettingWork.Pop3UserId;
            mailInfoSetting.Pop3Password = mailInfoSettingWork.Pop3Password;
            mailInfoSetting.Pop3ServerName = mailInfoSettingWork.Pop3ServerName;
            mailInfoSetting.SmtpServerName = mailInfoSettingWork.SmtpServerName;
            mailInfoSetting.SmtpUserId = mailInfoSettingWork.SmtpUserId;
            mailInfoSetting.SmtpPassword = mailInfoSettingWork.SmtpPassword;
            mailInfoSetting.SmtpAuthUseDiv = mailInfoSettingWork.SmtpAuthUseDiv;
            mailInfoSetting.SenderName = mailInfoSettingWork.SenderName;
            mailInfoSetting.PopBeforeSmtpUseDiv = mailInfoSettingWork.PopBeforeSmtpUseDiv;
            mailInfoSetting.PopServerPortNo = mailInfoSettingWork.PopServerPortNo;
            mailInfoSetting.SmtpServerPortNo = mailInfoSettingWork.SmtpServerPortNo;
            mailInfoSetting.MailServerTimeoutVal = mailInfoSettingWork.MailServerTimeoutVal;
            mailInfoSetting.BackupSendDivCd = mailInfoSettingWork.BackupSendDivCd;
            mailInfoSetting.BackupFormal = mailInfoSettingWork.BackupFormal;
            mailInfoSetting.MailSendDivUnitCnt = mailInfoSettingWork.MailSendDivUnitCnt;
            mailInfoSetting.FilePathNm = mailInfoSettingWork.FilePathNm;

            return mailInfoSetting;
        }

        /// <summary>
        /// �N���X�����o�R�s�[�����i���[�����ݒ�}�X�^�N���X�˃��[�����ݒ�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="mailInfoSetting">���[�����ݒ�}�X�^�N���X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ���[�����ݒ�}�X�^�N���X���烁�[�����ݒ�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private MailInfoSettingWork CopyToMailInfoSettingWorkFromMailInfoSetting(MailInfoSetting mailInfoSetting)
        {
            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();

            mailInfoSettingWork.CreateDateTime = mailInfoSetting.CreateDateTime;
            mailInfoSettingWork.UpdateDateTime = mailInfoSetting.UpdateDateTime;
            mailInfoSettingWork.EnterpriseCode = mailInfoSetting.EnterpriseCode;
            mailInfoSettingWork.FileHeaderGuid = mailInfoSetting.FileHeaderGuid;
            mailInfoSettingWork.UpdEmployeeCode = mailInfoSetting.UpdEmployeeCode;
            mailInfoSettingWork.UpdAssemblyId1 = mailInfoSetting.UpdAssemblyId1;
            mailInfoSettingWork.UpdAssemblyId2 = mailInfoSetting.UpdAssemblyId2;
            mailInfoSettingWork.LogicalDeleteCode = mailInfoSetting.LogicalDeleteCode;
            mailInfoSettingWork.SectionCode = mailInfoSetting.SectionCode;
            mailInfoSettingWork.MailSendMngNo = mailInfoSetting.MailSendMngNo;
            mailInfoSettingWork.MailAddress = mailInfoSetting.MailAddress;
            mailInfoSettingWork.DialUpCode = mailInfoSetting.DialUpCode;
            mailInfoSettingWork.DialUpConnectName = mailInfoSetting.DialUpConnectName;
            mailInfoSettingWork.DialUpLoginName = mailInfoSetting.DialUpLoginName;
            mailInfoSettingWork.DialUpPassword = mailInfoSetting.DialUpPassword;
            mailInfoSettingWork.AccessTelNo = mailInfoSetting.AccessTelNo;
            mailInfoSettingWork.Pop3UserId = mailInfoSetting.Pop3UserId;
            mailInfoSettingWork.Pop3Password = mailInfoSetting.Pop3Password;
            mailInfoSettingWork.Pop3ServerName = mailInfoSetting.Pop3ServerName;
            mailInfoSettingWork.SmtpServerName = mailInfoSetting.SmtpServerName;
            mailInfoSettingWork.SmtpUserId = mailInfoSetting.SmtpUserId;
            mailInfoSettingWork.SmtpPassword = mailInfoSetting.SmtpPassword;
            mailInfoSettingWork.SmtpAuthUseDiv = mailInfoSetting.SmtpAuthUseDiv;
            mailInfoSettingWork.SenderName = mailInfoSetting.SenderName;
            mailInfoSettingWork.PopBeforeSmtpUseDiv = mailInfoSetting.PopBeforeSmtpUseDiv;
            mailInfoSettingWork.PopServerPortNo = mailInfoSetting.PopServerPortNo;
            mailInfoSettingWork.SmtpServerPortNo = mailInfoSetting.SmtpServerPortNo;
            mailInfoSettingWork.MailServerTimeoutVal = mailInfoSetting.MailServerTimeoutVal;
            mailInfoSettingWork.BackupSendDivCd = mailInfoSetting.BackupSendDivCd;
            mailInfoSettingWork.BackupFormal = mailInfoSetting.BackupFormal;
            mailInfoSettingWork.MailSendDivUnitCnt = mailInfoSetting.MailSendDivUnitCnt;
            mailInfoSettingWork.FilePathNm = mailInfoSetting.FilePathNm;

            return mailInfoSettingWork;
        }
        # endregion

        /// <summary>
        /// ��������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void MemoryCreate()
        {
            // �I�����C���̏ꍇ
            if (LoginInfoAcquisition.OnlineFlag)
            {
                //---���_���擾���i�C���X�^���X��---//
                this._secInfoAcs = new SecInfoAcs();
            }
        }
    }
}
