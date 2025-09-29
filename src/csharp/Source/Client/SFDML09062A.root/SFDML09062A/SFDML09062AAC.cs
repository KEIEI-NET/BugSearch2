using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���[�����M�Ǘ��ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���[�����M�Ǘ��ݒ�e�[�u���̃A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer	: �v�ہ@����</br>
	/// <br>Date		: 2005.04.12</br>
	/// <br></br>
    /// <br>Note		: ���ڒǉ��E�L�[�ǉ��ɂ��啝�ύX</br>
    /// <br>Programmer	: 23013 �q�@���l</br>
    /// <br>Date		: 2006.11.06</br>
	/// </remarks>
	public class MailSndMngAcs
	{
		/// <summary> �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ </summary>
		private IMailSndMngDB _iMailSndMngDB = null;
        /// <summary>���_��񕔕i</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
        /// <summary>���_���ێ��e�[�u��</summary>
        private Hashtable _secInfoSetTable = null;
        /// <summary>���O�C�����_</summary>
        private string _loginSectionCode = "";

		/// <summary>
		///  ���[�����M�Ǘ��ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���[�����M�Ǘ��ݒ�e�[�u���A�N�Z�X�N���X�̃R���X�g���N�^�ł��B</br>
		/// <br>Programer	: �v�ہ@����</br>
		/// <br>Date		: 2005.04.12</br>
		/// <br></br>
		/// </remarks>
		public MailSndMngAcs()
		{
            // ��������������
            MemoryCreate();

            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
			try
			{
                this._secInfoSetTable = null;
				// �����[�g�I�u�W�F�N�g�擾
				this._iMailSndMngDB = (IMailSndMngDB)MediationMailSndMngDB.GetMailSndMngDB();

			}
			catch ( Exception )
			{
				// �I�t���C������null���Z�b�g
				this._iMailSndMngDB = null;
			}            

            // ���O�C�����_�擾
			Employee loginEmployee = LoginInfoAcquisition.Employee;
			if( loginEmployee != null ) {
				this._loginSectionCode = loginEmployee.BelongSectionCode;
			}
		}
		
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
		/// <br>Programmer	: �v�ہ@����</br>
		/// <br>Date		: 2005.04.12</br>
		/// <br></br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if ( this._iMailSndMngDB == null )
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// ���[�����M�Ǘ��ݒ�N���X�ǂݍ��ݏ���
		/// </summary>
		/// <param name="mailSndMng">���[�����M�Ǘ��ݒ�N���X�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="mailSendMngNo">e-mail���M�Ǘ��ԍ�</param>
		/// <param name="companySignAttachCd">���Џ����Y�t�敪</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���[�����M�Ǘ��ݒ�N���X����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 22013�@�v�ہ@����</br>
		/// <br>Date       : 2005.04.15</br>
		/// </remarks>
		public int Read(out MailSndMng mailSndMng, string enterpriseCode, string sectionCode)
		{			
			try
			{
				mailSndMng = null;
				MailSndMngWork mailSndMngWork = new MailSndMngWork();
				mailSndMngWork.EnterpriseCode = enterpriseCode;
                // 2006.11.02 Maki ���_�R�[�h�ǉ�
                mailSndMngWork.SectionCode = sectionCode;                
	
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
	
				// ���[�����M�Ǘ��t�B�[���h���̓ǂݍ���
				int status = this._iMailSndMngDB.Read(ref parabyte,0);
	
				if (status == 0)
				{
					// XML�̓ǂݍ���
					mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
					// �N���X�������o�R�s�[
					mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);
				}
				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				mailSndMng = null;
				//�I�t���C������null���Z�b�g
				this._iMailSndMngDB = null;
				return -1;
			}
		}
        
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="insLnCdChg">�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����폜���s���܂��B</br>
        /// <br>Programmer : �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Delete(MailSndMng mailSndMng)
        {
            try
            {
                MailSndMngWork mailSndMngWorks = new MailSndMngWork();
                mailSndMngWorks = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);

                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWorks);

                // �����폜
                int status = this._iMailSndMngDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iMailSndMngDB = null;

                //�ʐM�G���[��-1��߂�
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
        /// <br>Note       : �\���Ǘ����i�ݒ�}�X�^�̑S�����������s���܂��B</br>
        /// <br>	       : �_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchMailSndMngProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
        }

        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���Ǘ����i�ݒ�}�X�^�̑S�����������s���܂��B</br>
        /// <br>		   : �_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, MailSndMng prevMailSndMng)
        {
            return SearchMailSndMngProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01,readCnt, prevMailSndMng);
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
        /// <br>Programmer : �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private int SearchMailSndMngProc(out ArrayList retList,out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MailSndMng prevMailSndMng)
        {
            MailSndMngWork mailSndMngWork = new MailSndMngWork();
            if (prevMailSndMng != null)
            {
                mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(prevMailSndMng);
            }
            mailSndMngWork.EnterpriseCode = enterpriseCode;

            // �폜����Ă��Ȃ����_�R�[�h�m�ۗp
            ArrayList aliveSectionCodeList = new ArrayList();
            // ���_�R�[�h�̃R���N�V�������擾
            int sectionStatus = GetAliveSectionCodeList(out aliveSectionCodeList, enterpriseCode);

            // ���f�[�^�L��������
            nextData = false;
            // 0�ŏ�����
            retTotalCnt = 0;

            MailSndMngWork[] al;
            retList = new ArrayList();
            retList.Clear();

            // ���_���擾����
            ArrayList wkList = new ArrayList();
            wkList.Clear();

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);

            byte[] retbyte;

            // ���[�����M�Ǘ��ݒ茟��
            int status = 0;
            if (readCnt == 0)
            {
                status = this._iMailSndMngDB.Search(out retbyte, parabyte, 0, logicalMode);
            }
            else
            {
                status = this._iMailSndMngDB.SearchSpecification(out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt);
            }

            if ((status == 0) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // XML�̓ǂݍ���
                al = (MailSndMngWork[])XmlByteSerializer.Deserialize(retbyte, typeof(MailSndMngWork[]));

                for (int i = 0; i < al.Length; i++)
                {
                    // �T�[�`���ʎ擾
                    MailSndMngWork wkMailSndMngWork = (MailSndMngWork)al[i];
                    // ���[�����M�Ǘ��ݒ�N���X�փ����o�R�s�[
                    wkList.Add(CopyToMailSndMngFromMailSndMngWork(wkMailSndMngWork));
                }
                // ���_������ꍇ
                if (sectionStatus == 0)
                {
                    MailSndMng mailSndMng;
                    // ���_��񃌃R�[�h�͂��邪�A���[�����M�Ǘ��ݒ背�R�[�h�����݂��Ȃ��ꍇ
                    foreach (string sectionCode in aliveSectionCodeList)
                    {
                        bool existFlg = false;
                        for (int ix = 0; ix < wkList.Count; ix++)
                        {
                            mailSndMng = (MailSndMng)wkList[ix];
                            if (mailSndMng.SectionCode.TrimEnd() == sectionCode.TrimEnd())
                            {
                                retList.Add(mailSndMng);
                                existFlg = true;
                                break;
                            }
                        }
                        if (existFlg == false)
                        {
                            // ���_���ɍ��킹�ă��R�[�h��ǉ�
                            int st = AddNewBrSetItemRecord(out mailSndMng, enterpriseCode, sectionCode);
                            if (st == 0)
                            {
                                retList.Add(mailSndMng);
                            }
                        }
                    }
                }
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
        /// ���_���擾����
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_���̌����������s���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
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
		/// ���[�����M�Ǘ��ݒ菈��
		/// </summary>
        /// <param name="mailSndMng">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ����ݒ荀�ڃ��R�[�h��ǉ����܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
		/// </remarks>
		private int AddNewBrSetItemRecord(out MailSndMng mailSndMng, string enterpriseCode, string sectionCode)
		{
			mailSndMng = new MailSndMng();  

			mailSndMng.EnterpriseCode		= enterpriseCode;			// ��ƃR�[�h
			mailSndMng.SectionCode			= sectionCode;				// ���_�R�[�h  
			
			mailSndMng.MailSendMngNo	    = 0;		// e-mail���M�Ǘ��ԍ�
			mailSndMng.SenderName		    = "";		// ���o�l��
			mailSndMng.MailAddress		    = "";	    // ���[���A�h���X
			mailSndMng.Pop3UserId           = "";		// POP3���[�U�[ID
			mailSndMng.Pop3Password		    = "";	    // POP3�p�X���[�h
			mailSndMng.Pop3ServerName		= "";		// POP3�T�[�o�[��
			mailSndMng.SmtpServerName		= "";		// SMTP�T�[�o�[��
            mailSndMng.SmtpAuthUseDiv		= 0;	    // SMTP�F�؎g�p�敪
			mailSndMng.PopBeforeSmtpUseDiv  = 0;		// POP Before SMTP�g�p�敪
            mailSndMng.SmtpUserId		    = "";	    // SMTP���[�U�[ID
			mailSndMng.SmtpPassword		    = "";	    // SMTP�p�X���[�h
			mailSndMng.PopServerPortNo		= 0;		// POP�T�[�o�[�|�[�g�ԍ�
			mailSndMng.SmtpServerPortNo		= 0;		// SMTP�T�[�o�[�|�[�g�ԍ�
            mailSndMng.MailServerTimeoutVal	= 0;	    // ���[���T�[�o�[�^�C���A�E�g�l
			mailSndMng.BackupSendDivCd	    = 1;	    // �o�b�N�A�b�v���M�敪
			mailSndMng.BackupFormal		    = 0;		// �o�b�N�A�b�v�`��
			mailSndMng.MailSendDivUnitCnt	= 0;		// ���[�����M�����P�ʌ���
			
			// �V�K�o�^����
			int status = this.Write(ref mailSndMng);
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
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int ReadSectionName(out string sectionName, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            sectionName = "";

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
                    sectionName = secInfoSet.SectionGuideNm;	// ���_��
                }
            }
            else
            {
                sectionName = "���o�^";							// ���_��
            }

            return status;
        }

        /// <summary>
        /// ���_���ێ��e�[�u���ݒ菈��
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_���ێ��e�[�u���ɋ��_�����Z�b�g���܂�</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
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

        /// <summary>
        /// �_���폜���� TODO �g�p���Ă��Ȃ�
        /// </summary>
        /// <param name="mailSndMng">�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �_���폜���s���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int LogicalDelete(ref MailSndMng mailSndMng)
        {
            try
            {
                MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
                // �C�ӕی��K�C�h�_���폜
                int status = this._iMailSndMngDB.LogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ĔC�ӕی��K�C�h���[�N�N���X���f�V���A���C�Y����
                    mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
                    // �N���X�������o�R�s�[
                    mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);

                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iMailSndMngDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #region 2006.11.06 Maki Del
        /*
		/// <summary>
		/// ���[�����M�Ǘ��ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���[�����M�Ǘ��ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note		: ���[�����M�Ǘ��ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer	: 22013�@�v�ہ@����</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		public MailSndMng Deserialize(string fileName)
		{
			MailSndMng mailSndMng = null;
			// �t�@�C������n���ă��[�����M�Ǘ��ݒ�N���X���f�V���A���C�Y����
			mailSndMng = (MailSndMng)XmlByteSerializer.Deserialize(fileName, typeof(MailSndMng));
			return mailSndMng;
		}

		/// <summary>
		/// ���[�����M�Ǘ��ݒ胊�X�g�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���[�����M�Ǘ��ݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : ���[�����M�Ǘ��ݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 22013�@�v�ہ@����</br>
		/// <br>Date       : 2005.04.15</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList mailSndMngList = new ArrayList();
			mailSndMngList.Clear();

			// �t�@�C������n���ă��[�����M�Ǘ��ݒ�N���X���f�V���A���C�Y����
			MailSndMng[] mailSndMngs;
			mailSndMngs = (MailSndMng[])XmlByteSerializer.Deserialize(fileName, typeof(MailSndMng[]));
			
			foreach (MailSndMng mailSndMng in mailSndMngs)
			{
				mailSndMngList.Add(mailSndMng);
			}
			return mailSndMngList;
		}
        */
        #endregion

        /// <summary>
		/// ���[�����M�Ǘ��ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="mailSndMng">���[�����M�Ǘ��ݒ�N���X</param>
		/// <returns>STATUS</returns>
		public int Write(ref MailSndMng mailSndMng)
		{
			// ���[�����M�Ǘ��ݒ�N���X���烁�[�����M�Ǘ��ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
			MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);

			int status = 0;
			try
			{
				// ���[�����M�Ǘ��ݒ胏�[�N��������
				status = this._iMailSndMngDB.Write(ref parabyte);
				if (status == 0)
				{
					// �t�@�C������n���ă��[�����M�Ǘ��ݒ胏�[�N�N���X���f�V���A���C�Y����
					mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
					// �N���X�������o�R�s�[
					mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);
				}
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iMailSndMngDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}
			return status;
        }

        #region 2006.11.06 Maki Del
        /*
		/// <summary>
		/// ���[�����M�Ǘ��N���X�V���A���C�Y����
		/// </summary>
		/// <param name="mailSndMng">�V���A���C�Y�Ώۃ��[�����M�Ǘ��N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		public void Serialize(MailSndMng mailSndMng, string fileName)
		{
			// �N���X���烏�[�N�N���X�ɃR�s�[
			MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);
			// ���[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(mailSndMngWork,fileName);
		}

		/// <summary>
		/// ���[�����M�Ǘ��N���XList�V���A���C�Y����
		/// </summary>
		/// <param name="mailSndMngList">�V���A���C�Y�Ώۃ��[�����M�Ǘ��N���XList</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���[�����M�Ǘ��N���XList�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 22013�@�v�ہ@����</br>
		/// <br>Date       : 2005.04.15</br>
		/// </remarks>
		public void ListSerialize(ArrayList mailSndMngList, string fileName)
		{
			MailSndMngWork[] mailSndMngWorks = new MailSndMngWork[mailSndMngList.Count];
			for(int i= 0; i < mailSndMngList.Count; i++)
			{
				mailSndMngWorks[i] = CopyToMailSndMngWorkFromMailSndMng((MailSndMng)mailSndMngList[i]);
			}
			// ���[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(mailSndMngWorks, fileName);
		}
        */
        #endregion

        /// <summary>�@TODO �g�p���Ă��Ȃ�
        /// ���[�����M�Ǘ��ݒ�_���폜��������
        /// </summary>
        /// <param name="mailSndMng">���[�����M�Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�����M�Ǘ��ݒ蕜�����s���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Revival(ref MailSndMng mailSndMng)
        {
            try
            {
                MailSndMngWork mailSndMngWork = CopyToMailSndMngWorkFromMailSndMng(mailSndMng);
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(mailSndMngWork);
                // ��������
                int status = this._iMailSndMngDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
                    mailSndMngWork = (MailSndMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailSndMngWork));
                    // �N���X�������o�R�s�[
                    mailSndMng = CopyToMailSndMngFromMailSndMngWork(mailSndMngWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iMailSndMngDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

		/// <summary>
		/// �N���X�����o�R�s�[�����i���[�����M�Ǘ��ݒ胏�[�N�N���X�˃��[�����M�Ǘ��ݒ�N���X�j
		/// </summary>
		/// <param name="mailSndMngWork">���[�����M�Ǘ��ݒ胏�[�N�N���X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: ���[�����M�Ǘ��ݒ胏�[�N�N���X���烁�[�����M�Ǘ��ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer	: 22013  �v�ہ@����</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		private MailSndMng CopyToMailSndMngFromMailSndMngWork(MailSndMngWork mailSndMngWork)
		{
			MailSndMng mailSndMng = new MailSndMng();
            
			mailSndMng.CreateDateTime  		= mailSndMngWork.CreateDateTime;
			mailSndMng.UpdateDateTime  		= mailSndMngWork.UpdateDateTime;
			mailSndMng.EnterpriseCode		= mailSndMngWork.EnterpriseCode;
			mailSndMng.FileHeaderGuid  		= mailSndMngWork.FileHeaderGuid;
			mailSndMng.UpdEmployeeCode		= mailSndMngWork.UpdEmployeeCode;
			mailSndMng.UpdAssemblyId1		= mailSndMngWork.UpdAssemblyId1;
			mailSndMng.UpdAssemblyId2		= mailSndMngWork.UpdAssemblyId2;
			mailSndMng.LogicalDeleteCode	= mailSndMngWork.LogicalDeleteCode;
            mailSndMng.SectionCode          = mailSndMngWork.SectionCode;
			mailSndMng.MailSendMngNo		= mailSndMngWork.MailSendMngNo;
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            //mailSndMng.CompanySignAttachCd	= mailSndMngWork.CompanySignAttachCd;
            //mailSndMng.AttachFilePath 		= mailSndMngWork.AttachFilePath;
            //mailSndMng.MailDocMaxSize 		= mailSndMngWork.MailDocMaxSize;
            //mailSndMng.PMailDocMaxSize 		= mailSndMngWork.PMailDocMaxSize;
            //mailSndMng.MailLineStrMaxSize	= mailSndMngWork.MailLineStrMaxSize;
            //mailSndMng.PMailLineStrMaxSize	= mailSndMngWork.PMailLineStrMaxSize;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
			mailSndMng.MailAddress 			= mailSndMngWork.MailAddress;            
            mailSndMng.Pop3UserId           = mailSndMngWork.Pop3UserId;
            mailSndMng.Pop3Password         = mailSndMngWork.Pop3Password;
            mailSndMng.Pop3ServerName       = mailSndMngWork.Pop3ServerName;
            mailSndMng.SmtpServerName       = mailSndMngWork.SmtpServerName;
            // 2006.11.01 Maki Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            mailSndMng.SmtpUserId           = mailSndMngWork.SmtpUserId;
            mailSndMng.SmtpPassword         = mailSndMngWork.SmtpPassword;
            mailSndMng.SmtpAuthUseDiv       = mailSndMngWork.SmtpAuthUseDiv;
            mailSndMng.SenderName           = mailSndMngWork.SenderName;
            mailSndMng.PopBeforeSmtpUseDiv  = mailSndMngWork.PopBeforeSmtpUseDiv;
            mailSndMng.PopServerPortNo      = mailSndMngWork.PopServerPortNo;
            mailSndMng.SmtpServerPortNo     = mailSndMngWork.SmtpServerPortNo;
            mailSndMng.MailServerTimeoutVal = mailSndMngWork.MailServerTimeoutVal;
            mailSndMng.BackupSendDivCd      = mailSndMngWork.BackupSendDivCd;
            mailSndMng.BackupFormal         = mailSndMngWork.BackupFormal;
            mailSndMng.MailSendDivUnitCnt   = mailSndMngWork.MailSendDivUnitCnt;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            //mailSndMng.DialUpCode 			= mailSndMngWork.DialUpCode;
            //mailSndMng.DialUpConnectName	= mailSndMngWork.DialUpConnectName;
            //mailSndMng.DialUpLoginName		= mailSndMngWork.DialUpLoginName;
            //mailSndMng.DialUpPassword 		= mailSndMngWork.DialUpPassword;
            //mailSndMng.AccessTelNo 			= mailSndMngWork.AccessTelNo;
            //mailSndMng.Pop3UserId 			= mailSndMngWork.Pop3UserId;
            //mailSndMng.Pop3Password 		= mailSndMngWork.Pop3Password;
            //mailSndMng.Pop3ServerName 		= mailSndMngWork.Pop3ServerName;
            //mailSndMng.SmtpServerName 		= mailSndMngWork.SmtpServerName;
            //mailSndMng.SenderName 			= mailSndMngWork.SenderName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End

			return mailSndMng;
		}

		/// <summary>
		/// �N���X�����o�R�s�[�����i���[�����M�Ǘ��ݒ�N���X�˃��[�����M�Ǘ��ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="mailSndMngWork">���[�����M�Ǘ��ݒ�N���X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: ���[�����M�Ǘ��ݒ�N���X���烁�[�����M�Ǘ��ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer	: 22013  �v�ہ@����</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		private MailSndMngWork CopyToMailSndMngWorkFromMailSndMng(MailSndMng mailSndMng)
		{
			MailSndMngWork mailSndMngWork = new MailSndMngWork();

////////////////////////////////////////////// 2005.06.21 TERASAKA DEL STA //
//			mailSndMngWork.CreateDateTime  		= mailSndMng.CreateDateTime;
//			mailSndMngWork.UpdateDateTime  		= mailSndMng.UpdateDateTime;
//			mailSndMngWork.EnterpriseCode		= mailSndMng.EnterpriseCode;
//			mailSndMngWork.FileHeaderGuid  		= mailSndMng.FileHeaderGuid;
//			mailSndMngWork.UpdEmployeeCode		= mailSndMng.UpdEmployeeCode;
//			mailSndMngWork.UpdAssemblyId1		= mailSndMng.UpdAssemblyId1;
//			mailSndMngWork.UpdAssemblyId2		= mailSndMng.UpdAssemblyId2;
//			mailSndMngWork.LogicalDeleteCode	= mailSndMng.LogicalDeleteCode;
//			mailSndMngWork.MailSendMngNo		= mailSndMng.MailSendMngNo;
//			mailSndMngWork.CompanySignAttachCd	= mailSndMng.CompanySignAttachCd;
//			mailSndMngWork.AttachFilePath 		= mailSndMng.AttachFilePath;
//			mailSndMngWork.MailDocMaxSize 		= mailSndMng.MailDocMaxSize;
//			mailSndMngWork.PMailDocMaxSize 		= mailSndMng.PMailDocMaxSize;
//			mailSndMngWork.MailLineStrMaxSize	= mailSndMng.MailLineStrMaxSize;
//			mailSndMngWork.PMailLineStrMaxSize	= mailSndMng.PMailLineStrMaxSize;
//			mailSndMngWork.MailAddress 			= mailSndMng.MailAddress;
//			mailSndMngWork.DialUpCode 			= mailSndMng.DialUpCode;
//			mailSndMngWork.DialUpConnectName	= mailSndMng.DialUpConnectName;
//			mailSndMngWork.DialUpLoginName		= mailSndMng.DialUpLoginName;
//			mailSndMngWork.DialUpPassword 		= mailSndMng.DialUpPassword;
//			mailSndMngWork.AccessTelNo 			= mailSndMng.AccessTelNo;
//			mailSndMngWork.Pop3UserId 			= mailSndMng.Pop3UserId;
//			mailSndMngWork.Pop3Password 		= mailSndMng.Pop3Password;
//			mailSndMngWork.Pop3ServerName 		= mailSndMng.Pop3ServerName;
//			mailSndMngWork.SmtpServerName 		= mailSndMng.SmtpServerName;
//			mailSndMngWork.SenderName 			= mailSndMng.SenderName;
// 2005.06.21 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2005.06.21 TERASAKA ADD STA //
			mailSndMngWork.CreateDateTime  		= mailSndMng.CreateDateTime;
			mailSndMngWork.UpdateDateTime  		= mailSndMng.UpdateDateTime;
			mailSndMngWork.EnterpriseCode		= mailSndMng.EnterpriseCode;
			mailSndMngWork.FileHeaderGuid  		= mailSndMng.FileHeaderGuid;
			mailSndMngWork.UpdEmployeeCode		= mailSndMng.UpdEmployeeCode;
			mailSndMngWork.UpdAssemblyId1		= mailSndMng.UpdAssemblyId1;
			mailSndMngWork.UpdAssemblyId2		= mailSndMng.UpdAssemblyId2;
			mailSndMngWork.LogicalDeleteCode	= mailSndMng.LogicalDeleteCode;

            mailSndMngWork.SectionCode          = mailSndMng.SectionCode;
			mailSndMngWork.MailSendMngNo		= mailSndMng.MailSendMngNo;
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start			
            //mailSndMngWork.CompanySignAttachCd	= mailSndMng.CompanySignAttachCd;
            //mailSndMngWork.AttachFilePath 		= mailSndMng.AttachFilePath.TrimEnd();
            //mailSndMngWork.MailDocMaxSize 		= mailSndMng.MailDocMaxSize;
            //mailSndMngWork.PMailDocMaxSize 		= mailSndMng.PMailDocMaxSize;
            //mailSndMngWork.MailLineStrMaxSize	= mailSndMng.MailLineStrMaxSize;
            //mailSndMngWork.PMailLineStrMaxSize	= mailSndMng.PMailLineStrMaxSize;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
            mailSndMngWork.MailAddress = mailSndMng.MailAddress.Trim();
            // 2006.11.01 Maki Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start
            mailSndMngWork.Pop3UserId           = mailSndMng.Pop3UserId.Trim();
            mailSndMngWork.Pop3Password         = mailSndMng.Pop3Password.Trim();
            mailSndMngWork.Pop3ServerName       = mailSndMng.Pop3ServerName.Trim();
            mailSndMngWork.SmtpServerName       = mailSndMng.SmtpServerName.Trim();
            mailSndMngWork.SmtpUserId           = mailSndMng.SmtpUserId.Trim();
            mailSndMngWork.SmtpPassword         = mailSndMng.SmtpPassword.Trim();
            mailSndMngWork.SmtpAuthUseDiv       = mailSndMng.SmtpAuthUseDiv;
            mailSndMngWork.SenderName           = mailSndMng.SenderName.TrimEnd();
            mailSndMngWork.PopBeforeSmtpUseDiv  = mailSndMng.PopBeforeSmtpUseDiv;
            mailSndMngWork.PopServerPortNo      = mailSndMng.PopServerPortNo;
            mailSndMngWork.SmtpServerPortNo     = mailSndMng.SmtpServerPortNo;
            mailSndMngWork.MailServerTimeoutVal = mailSndMng.MailServerTimeoutVal;
            mailSndMngWork.BackupSendDivCd      = mailSndMng.BackupSendDivCd;
            mailSndMngWork.BackupFormal         = mailSndMng.BackupFormal;
            mailSndMngWork.MailSendDivUnitCnt   = mailSndMng.MailSendDivUnitCnt;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
            // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Start			
            //mailSndMngWork.DialUpCode 			= mailSndMng.DialUpCode;
            //mailSndMngWork.DialUpConnectName	= mailSndMng.DialUpConnectName.TrimEnd();
            //mailSndMngWork.DialUpLoginName		= mailSndMng.DialUpLoginName.Trim();
            //mailSndMngWork.DialUpPassword 		= mailSndMng.DialUpPassword.Trim();
            //mailSndMngWork.AccessTelNo 			= mailSndMng.AccessTelNo.Trim();
            //mailSndMngWork.Pop3UserId 			= mailSndMng.Pop3UserId.Trim();
            //mailSndMngWork.Pop3Password 		= mailSndMng.Pop3Password.Trim();
            //mailSndMngWork.Pop3ServerName 		= mailSndMng.Pop3ServerName.Trim();
            //mailSndMngWork.SmtpServerName 		= mailSndMng.SmtpServerName.Trim();
            //mailSndMngWork.SenderName 			= mailSndMng.SenderName.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< End
// 2005.06.21 TERASAKA ADD END //////////////////////////////////////////////

			return mailSndMngWork;
		}

        /// <summary>
        /// ��������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
        /// <br>Programer  : 22033 �O��  �M�j</br>
        /// <br>Date       : 2005.10.25</br>
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
