using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

using Broadleaf.Web.Services;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ȒP�⍇��ID�ϊ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br>Note       : IDExchange�T�[�r�X�̕ύX�ɔ����Ή�</br>
    /// <br>Programmer : 30434�@�H�� �b�D</br>
    /// <br>Date       : 2010/06/25</br>
    /// </remarks>
    public class SimplInqIDExchangeAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member

        /// <summary>�A�v���P�[�V�����\���N���X�p�V���A���C�Y�L�[</summary>
        private static readonly string[] AppConfigKey = new string[] { typeof(SimplInqIDExchangeAcs).Name, "AppConfigKey" };
        /// <summary>�A�v���P�[�V�����ݒ�t�@�C����</summary>
        private static readonly string AppConfigFileName = "PMSCM01040A_Config.dat";
		/// <summary>�X�V�`�F�b�NWeb�T�[�r�XURL</summary>
		private static string WebServiceURL = String.Empty;
		/// <summary>�A�v���P�[�V�����\���ێ��N���X</summary>
		private static SimplInqIDExchangeAppConfig AppConfig;

        private SFINQ06740ABServices _service =null;

        #endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region �� Public Enum
        /// <summary>
        /// �ȒP�⍇���̃V�X�e���R�[�h
        /// </summary>
        public enum SimpleInqIdCngSysCd : int
        {
            Partsman = 300
        }
        
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Costructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SimplInqIDExchangeAcs()
        {
            if (_service == null)
            {
                string msg = string.Empty;
                this.GetService(out msg);
            }
            // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            ChannelServices.RegisterChannel(new IpcClientChannel(), true);
            // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Method

        /// <summary>
        /// �A�J�E���g�ϊ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="smplInqInf">�ȒP�⍇��ID���Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="smplInqBas">�ȒP�⍇��ID�t�����}�X�^(��{���)�I�u�W�F�N�g</param>
        /// <param name="errorMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int ExchangeAcntId(string enterpriseCode, string employeeCode, out SmplInqInf smplInqInf, out SmplInqBas smplInqBas, out string errorMsg)
        {
            errorMsg = string.Empty;
            smplInqInf = null;
            smplInqBas = null;
            int status = 0;

            if (_service == null)
            {
                status = this.GetService(out errorMsg);
                if (status != 0) return status;
            }

            SmplInqBasWork smplInqBasWork;
            SmplInqInfWork smplInqInfWork;
            status = _service.ExchangeAcntId(this.GetAuthenticateCode(), (int)SimpleInqIdCngSysCd.Partsman, enterpriseCode, employeeCode, out smplInqInfWork, out smplInqBasWork, out errorMsg);
            if (status == 0)
            {
                smplInqInf = CopyToPrmFromWork(smplInqInfWork);
                smplInqBas = CopyToPrmFromWork(smplInqBasWork);
            }

            return status;
        }

        /// <summary>
        /// UNDONE:�A�J�E���g��񌟍�����
        /// </summary>
        /// <param name="simplInqAcntAcntId">�ȒP�⍇���A�J�E���gID</param>
        /// <param name="smplInqInf">�ȒP�⍇��ID���Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="smplInqBas">�ȒP�⍇��ID�t�����}�X�^(��{���)�I�u�W�F�N�g</param>
        /// <param name="smplInqChgList">�ȒP�⍇��ID�ϊ��}�X�^�I�u�W�F�N�g���X�g</param>
        /// <param name="errorMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchRelatedSmplInqInf(string simplInqAcntAcntId, out SmplInqInf smplInqInf, out SmplInqBas smplInqBas,out List<SmplInqChg> smplInqChgList, out string errorMsg)
        {
            // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            smplInqInf = new SmplInqInf();
            smplInqBas = new SmplInqBasExt();
            smplInqChgList = new List<SmplInqChg>();
            errorMsg = string.Empty;

            // �F�؃R�[�h���擾
            string authenticateCode = this.GetAuthenticateCode();

            // ��ƃR�[�h������
            string nsEnterpriseCode = string.Empty;
            int status = SearchNSEnterpriseCode(
                authenticateCode,
                simplInqAcntAcntId,
                out nsEnterpriseCode,
                out errorMsg
            );
            if (status.Equals(0))
            {
                smplInqBas.EnterpriseCode = nsEnterpriseCode;
            }
            else
            {
                smplInqBas = null;  // �ďo������null�̔���ŃG���[���������Ă���̂ŁAnull�ŕԂ�
            }

            // �ȒP�⍇���A�J�E���g�O���[�vID������
            status = SearchSimplInqAcntGrpId(
                authenticateCode,
                simplInqAcntAcntId,
                (SmplInqBasExt)smplInqBas,
                out errorMsg
            );
            if (!status.Equals(0))
            {
                smplInqBas = null;  // �ďo������null�̔���ŃG���[���������Ă���̂ŁAnull�ŕԂ�
            }

            return status;
            // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<
            // DEL 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            #region �폜�R�[�h

            //smplInqInf=null;
            //smplInqBas=null;
            //smplInqChgList=null;
            //errorMsg = string.Empty;
            //int status = 0;

            //if (_service == null)
            //{
            //    status = this.GetService(out errorMsg);
            //    if (status != 0) return status;
            //}

            //SmplInqBasWork smplInqBasWork;
            //SmplInqInfWork smplInqInfWork;
            //SmplInqChgWork[] smplInqChgWorkList;
            //status = _service.SearchRelatedSmplInqInf(this.GetAuthenticateCode(), simplInqAcntAcntId, out smplInqInfWork, out smplInqBasWork,out smplInqChgWorkList, out errorMsg);

            //if (status == 0)
            //{
            //    smplInqInf=CopyToPrmFromWork(smplInqInfWork);
            //    smplInqBas=CopyToPrmFromWork(smplInqBasWork);
            //    if (smplInqChgWorkList!=null && smplInqChgWorkList.Length>0)
            //    {
            //        smplInqChgList=new List<SmplInqChg>();
            //        foreach(SmplInqChgWork work in smplInqChgWorkList)
            //        {
            //            smplInqChgList.Add(CopyToPrmFromWork( work));
            //        }
            //    }
            //}
            //return status;

            #endregion // �폜�R�[�h
            // DEL 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<
        }

        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        /// <summary>
        /// �T�[�r�X�擾
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private int GetService(out string errorMsg)
        {
            errorMsg = string.Empty;
            if (_service != null) return 0;

            if (AppConfig == null)
            {
                GetApplicationConfig();
            }

            if (AppConfig == null)
            {
                errorMsg = "�\���t�@�C���̓ǂݍ��݂Ɏ��s���܂���";
                return -1;
            }

            try
            {
                _service = new SFINQ06740ABServices(AppConfig.WebServiceURL);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return -2;
            }

            return 0;
        }

        /// <summary>
        /// Web�T�[�r�X��URL�擾
        /// </summary>
        /// <returns></returns>
        private string GetAuthenticateCode()
        {
            //string authenticateCode = ExchgWebServiceAuthentication.GetAuthenticateString();
            //System.Diagnostics.Trace.WriteLine(authenticateCode);
            //return authenticateCode;
            return ExchgWebServiceAuthentication.GetAuthenticateString();
        }

        /// <summary>
		/// �A�v���P�[�V�����\�����擾����
		/// </summary>
        private static void GetApplicationConfig()
        {
            try
            {
                string path = System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, AppConfigFileName);
                // �A�v���P�[�V�����\�����擾
                if (UserSettingController.ExistUserSetting(path))
                {
                    AppConfig = UserSettingController.DecryptionDeserializeUserSetting<SimplInqIDExchangeAppConfig>(path, AppConfigKey);
                }
            }
            catch (Exception ex)
            {
            }

            if (AppConfig == null)
            {
            }
            else
            {
                WebServiceURL = AppConfig.WebServiceURL;	// �X�V�`�F�b�NWeb�T�[�r�XURL
                //if (WebServiceURL.Contains("%Infomation%"))
                //{
                //    WebServiceURL = WebServiceURL.Replace("%Infomation%", GetWebTopPageURLFromPMC());
                //}
            }
        }

        /// <summary>
        /// �F�؏����Infomation��URL�擾
        /// </summary>
        /// <returns></returns>
        private static string GetWebServiceURLFromPMC()
        {
            string url = string.Empty;
            //url = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.IndexCode_Infomation);	// �X�V�`�F�b�NWeb�T�[�r�XURL
            //url += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Infomation, ConstantManagement_SF_PRO.IndexCode_Infomation);

            return url;
        }

        #region �N���X�ԃR�s�[

        /// <summary>
        /// UI�f�[�^�˃����[�g�p�����[�^�ϊ�
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqInfWork CopyToWorkFromPrm(SmplInqInf src)
        {
            SmplInqInfWork dst = new SmplInqInfWork();
            #region �R�s�[
            dst.CreateDateTime = src.CreateDateTime;            // �쐬����
            dst.UpdateDateTime = src.UpdateDateTime;            // �X�V����
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // �_���폜�敪
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // �ȒP�⍇��ID�t�����Ǘ��ԍ�
            dst.SimplInqAcntAcntId = src.SimplInqAcntAcntId;    // �ȒP�⍇���A�J�E���gID
            dst.SimplInqAcntPass = src.SimplInqAcntPass;        // �ȒP�⍇���A�J�E���g�p�X���[�h
            #endregion
            return dst;
        }

        /// <summary>
        /// �����[�g�p�����[�^��UI�f�[�^�ϊ�
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqInf CopyToPrmFromWork(SmplInqInfWork src)
        {
            SmplInqInf dst = new SmplInqInf();
            #region �R�s�[
            dst.CreateDateTime = src.CreateDateTime;            // �쐬����
            dst.UpdateDateTime = src.UpdateDateTime;            // �X�V����
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // �_���폜�敪
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // �ȒP�⍇��ID�t�����Ǘ��ԍ�
            dst.SimplInqAcntAcntId = src.SimplInqAcntAcntId;    // �ȒP�⍇���A�J�E���gID
            dst.SimplInqAcntPass = src.SimplInqAcntPass;        // �ȒP�⍇���A�J�E���g�p�X���[�h
            #endregion
            return dst;
        }

        /// <summary>
        /// UI�f�[�^�˃����[�g�p�����[�^�ϊ�
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqBasWork CopyToWorkFromPrm(SmplInqBas src)
        {
            SmplInqBasWork dst = new SmplInqBasWork();
            #region �R�s�[
            dst.CreateDateTime = src.CreateDateTime;            // �쐬����
            dst.UpdateDateTime = src.UpdateDateTime;            // �X�V����
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // �_���폜�敪
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // �ȒP�⍇��ID�t�����Ǘ��ԍ�
            dst.Name = src.Name;                                // ����
            dst.Name2 = src.Name2;                              // ����2
            dst.Kana = src.Kana;                                // �J�i
            dst.SexCode = src.SexCode;                          // ���ʃR�[�h
            dst.SexName = src.SexName;                          // ���ʖ���
            dst.Birthday = src.Birthday;                        // ���N����
            dst.PostNo = src.PostNo;                            // �X�֔ԍ�
            dst.AddressCode1Upper = src.AddressCode1Upper;      // �s���{���R�[�h
            dst.WebDspAddrADOJp = src.WebDspAddrADOJp;          // WEB�\���Z��(�s���{��)
            dst.WebDspAddrCity = src.WebDspAddrCity;            // WEB�\���Z��(��s����)
            dst.WebDspAddrBuil = src.WebDspAddrBuil;            // WEB�\���Z��(�r����}���V������)
            dst.JobTypeCode = src.JobTypeCode;                  // �E��R�[�h
            dst.BusinessTypeCode = src.BusinessTypeCode;        // �Ǝ�R�[�h
            dst.HomeTelNo = src.HomeTelNo;                      // ����TEL
            dst.OfficeTelNo = src.OfficeTelNo;                  // �d�b�ԍ��i�Ζ���j
            dst.PortableTelNo = src.PortableTelNo;              // �d�b�ԍ��i�g�сj
            dst.HomeFaxNo = src.HomeFaxNo;                      // FAX�ԍ��i����j
            dst.OfficeFaxNo = src.OfficeFaxNo;                  // FAX�ԍ��i�Ζ���j
            dst.MailAddress1 = src.MailAddress1;                // ���[���A�h���X1
            dst.MailAddrKindCode1 = src.MailAddrKindCode1;      // ���[���A�h���X��ʃR�[�h1
            dst.MailAddress2 = src.MailAddress2;                // ���[���A�h���X2
            dst.MailAddrKindCode2 = src.MailAddrKindCode2;      // ���[���A�h���X��ʃR�[�h2
            dst.MailAddress3 = src.MailAddress3;                // ���[���A�h���X3
            dst.MailAddrKindCode3 = src.MailAddrKindCode3;      // ���[���A�h���X��ʃR�[�h3
            dst.EnterpriseCode = src.EnterpriseCode;            // ��ƃR�[�h
            dst.EnterpriseName = src.EnterpriseName;            // ��Ɩ���
            #endregion
            return dst;
        }

        /// <summary>
        /// �����[�g�p�����[�^��UI�f�[�^�ϊ�
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqBas CopyToPrmFromWork(SmplInqBasWork src)
        {
            SmplInqBas dst = new SmplInqBas();
            #region �R�s�[
            dst.CreateDateTime = src.CreateDateTime;            // �쐬����
            dst.UpdateDateTime = src.UpdateDateTime;            // �X�V����
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // �_���폜�敪
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // �ȒP�⍇��ID�t�����Ǘ��ԍ�
            dst.Name = src.Name;                                // ����
            dst.Name2 = src.Name2;                              // ����2
            dst.Kana = src.Kana;                                // �J�i
            dst.SexCode = src.SexCode;                          // ���ʃR�[�h
            dst.SexName = src.SexName;                          // ���ʖ���
            dst.Birthday = src.Birthday;                        // ���N����
            dst.PostNo = src.PostNo;                            // �X�֔ԍ�
            dst.AddressCode1Upper = src.AddressCode1Upper;      // �s���{���R�[�h
            dst.WebDspAddrADOJp = src.WebDspAddrADOJp;          // WEB�\���Z��(�s���{��)
            dst.WebDspAddrCity = src.WebDspAddrCity;            // WEB�\���Z��(��s����)
            dst.WebDspAddrBuil = src.WebDspAddrBuil;            // WEB�\���Z��(�r����}���V������)
            dst.JobTypeCode = src.JobTypeCode;                  // �E��R�[�h
            dst.BusinessTypeCode = src.BusinessTypeCode;        // �Ǝ�R�[�h
            dst.HomeTelNo = src.HomeTelNo;                      // ����TEL
            dst.OfficeTelNo = src.OfficeTelNo;                  // �d�b�ԍ��i�Ζ���j
            dst.PortableTelNo = src.PortableTelNo;              // �d�b�ԍ��i�g�сj
            dst.HomeFaxNo = src.HomeFaxNo;                      // FAX�ԍ��i����j
            dst.OfficeFaxNo = src.OfficeFaxNo;                  // FAX�ԍ��i�Ζ���j
            dst.MailAddress1 = src.MailAddress1;                // ���[���A�h���X1
            dst.MailAddrKindCode1 = src.MailAddrKindCode1;      // ���[���A�h���X��ʃR�[�h1
            dst.MailAddress2 = src.MailAddress2;                // ���[���A�h���X2
            dst.MailAddrKindCode2 = src.MailAddrKindCode2;      // ���[���A�h���X��ʃR�[�h2
            dst.MailAddress3 = src.MailAddress3;                // ���[���A�h���X3
            dst.MailAddrKindCode3 = src.MailAddrKindCode3;      // ���[���A�h���X��ʃR�[�h3
            dst.EnterpriseCode = src.EnterpriseCode;            // ��ƃR�[�h
            dst.EnterpriseName = src.EnterpriseName;            // ��Ɩ���
            #endregion
            return dst;
        }

        /// <summary>
        /// UI�f�[�^�˃����[�g�p�����[�^�ϊ�
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqChgWork CopyToWorkFromPrm(SmplInqChg src)
        {
            SmplInqChgWork dst = new SmplInqChgWork();
            #region �R�s�[
            dst.CreateDateTime = src.CreateDateTime;            // �쐬����
            dst.UpdateDateTime = src.UpdateDateTime;            // �X�V����
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // �_���폜�敪
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // �ȒP�⍇��ID�t�����Ǘ��ԍ�
            dst.SimpleInqIdCngSysCd = src.SimpleInqIdCngSysCd;  // �ȒP�⍇��ID�ϊ��T�[�r�X�V�X�e���敪
            dst.OriginalAcntDiskKey = src.OriginalAcntDiskKey;  // �ϊ����A�J�E���g���ʃL�[
            dst.OriginalAcntId = src.OriginalAcntId;            // �ϊ����A�J�E���gID
            #endregion

            return dst;
        }

        /// <summary>
        /// �����[�g�p�����[�^��UI�f�[�^�ϊ�
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private SmplInqChg CopyToPrmFromWork(SmplInqChgWork src)
        {
            SmplInqChg dst = new SmplInqChg();
            #region �R�s�[
            dst.CreateDateTime = src.CreateDateTime;            // �쐬����
            dst.UpdateDateTime = src.UpdateDateTime;            // �X�V����
            dst.LogicalDeleteCode = src.LogicalDeleteCode;      // �_���폜�敪
            dst.SimpleInqIdInfMngNo = src.SimpleInqIdInfMngNo;  // �ȒP�⍇��ID�t�����Ǘ��ԍ�
            dst.SimpleInqIdCngSysCd = src.SimpleInqIdCngSysCd;  // �ȒP�⍇��ID�ϊ��T�[�r�X�V�X�e���敪
            dst.OriginalAcntDiskKey = src.OriginalAcntDiskKey;  // �ϊ����A�J�E���g���ʃL�[
            dst.OriginalAcntId = src.OriginalAcntId;            // �ϊ����A�J�E���gID
            #endregion
            return dst;
        }

        #endregion

        // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
        /// <summary>
        /// CMT�A�J�E���gID ���� NS��ƃR�[�h ���������܂��B
        /// </summary>
        /// <remarks>
        /// �R�~���j�P�[�V�����c�[���{�̂��o�R����
        ///
        /// �A�J�E���gID --> �A�J�E���gID�����������ƃR�[�h 
        ///
        /// ���擾���܂��B
        /// CTI�@�\���ŁA�������Ă�������̊�ƃR�[�h���K�v�ȏꍇ���ł��g�p���������B
        /// 
        /// �܂��A���L�A�Z���u�����Q�ƒǉ����Ă��������B
        /// �A�Z���u���́A�g�p����V�X�e���̃f�B���N�g���ȉ��ɔz�u���Ă��������B
        /// (��: SF�BL�CS --> \SuperFrontman �ȉ��֔z�u����)
        /// ���R�~���j�P�[�V�����c�[���̃C���X�g�[���ł̓C���X�g�[�����s���܂���B
        /// 
        /// BLCMTServiceProvider.dll
        /// SFCMN05012E.dll
        /// SFINQ01130I.dll
        /// </remarks>
        /// <param name="authenticateCode">�F�؃R�[�h</param>
        /// <param name="simplInqAcntAcntId">�ȒP�⍇���A�J�E���gID�i��ƃR�[�h���擾����A�J�E���gID�j</param>
        /// <param name="nsEnterpriseCode">��ƃR�[�h(�擾����)</param>
        /// <param name="errorMsg">�G���[���b�Z�[�W</param>
        /// <returns>�������ʃX�e�[�^�X</returns>
        private int SearchNSEnterpriseCode(
            string authenticateCode,
            string simplInqAcntAcntId,
            out string nsEnterpriseCode,
            out string errorMsg
        )
        {
            nsEnterpriseCode= string.Empty;
            errorMsg        = string.Empty;

            //--- �ȒP�⍇���f�[�^�T�[�r�X�v���o�C�_����C���^�t�F�[�X���擾���܂�
            ISimpleInquiryDataService simpleInquiryDataService = BLCMTServiceProvider.GetISimpleInquiryDataService();

            CMTActGrEpr cmtActGrEpr = null; // CMT�A�J�E���g�O���[�v��Ə��(�v���p�e�B�ڍׂ͕ʎ��̃t�@�C�����C�A�E�g���Q�Ƃ��Ă�������)
            CMTEprSet   cmtEprSet   = null; // CMT��Ɛݒ���(�v���p�e�B�ڍׂ͕ʎ��̃t�@�C�����C�A�E�g���Q�Ƃ��Ă�������)
            InqCoInfSt  inqCoInfSt  = null; // �ȒP�⍇����Ɛݒ���(�v���p�e�B�ڍׂ͕ʎ��̃t�@�C�����C�A�E�g���Q�Ƃ��Ă�������)

            int status = -1;

            //--- �擾�����C���^�t�F�[�X�𗘗p���āA�ȒP�⍇��ID(�A�J�E���gID)�̊�Ə����擾���܂�
            try
            {
                status = simpleInquiryDataService.SearchEnterpriseInfo(
                    authenticateCode,
                    simplInqAcntAcntId,
                    out cmtActGrEpr,
                    out cmtEprSet,
                    out inqCoInfSt,
                    out errorMsg
                );

                // ���L�N���X�̃v���p�e�B�Ɋ�ƃR�[�h���Z�b�g����Ă��܂��B
                // ��ƃR�[�h���擾�ł��Ȃ��ꍇ(��Ə��֘A���ݒ肳��Ă��Ȃ�)�́A
                // �I�u�W�F�N�g���̂�null�ŕԂ�̂ŁAnull�`�F�b�N�͍s���Ă��������B
                if (status.Equals(0))
                {
                    if (cmtEprSet != null)
                    {
                        // �擾������ƃR�[�h���Z�b�g����
                        nsEnterpriseCode = cmtEprSet.BLEnterpriseCd.Trim();
                        Debug.Assert(false, "OK: " + nsEnterpriseCode + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                    }
                    else
                    {
                        Debug.Assert(false, "NG: cmtEprSet ��null" + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                    }
                }
                else
                {
                    Debug.Assert(false, "NG:�G���[�R�[�h�F" + status.ToString() + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                }
            }
            catch (Exception ex)
            {
                // �R�~���j�P�[�V�����c�[���ɖ����O�C���̏�Ԃŏ�L���������s����Ɨ�O���������܂��B
                Debug.WriteLine(ex);
                errorMsg += Environment.NewLine + ex.Message;
                Debug.Assert(false, "NG:��O\n" + "<- " + authenticateCode + ", " + simplInqAcntAcntId + "\n" + ex.ToString());
            }

            return status;
        }

        /// <summary>
        /// CMT�A�J�E���gID ���� �ȒP�⍇���A�J�E���g�O���[�vID ���������܂��B
        /// </summary>
        /// <remarks>
        /// �R�~���j�P�[�V�����c�[���{�̂��o�R����
        //
        /// �A�J�E���gID --> �A�J�E���gID����������A�J�E���g�O���[�v 
        ///
        /// ���擾���܂��B
        ///
        /// �A�J�E���gID�͕����̃O���[�v�ɏ����ł���̂ŁA
        /// �擾�ł��鏊���O���[�v��1�Ƃ͌���Ȃ��̂ł����ӂ�������
        /// �܂��A���[�U�̉^�p����ł́ANS���i�̋��_��CMT�̃A�J�E���g�O���[�v(�����O���[�v)��
        /// ��v���Ȃ��P�[�X���l������̂ŁA
        ///
        /// NS�̋��_�R�[�h �� �A�J�E���g�O���[�v
        ///
        /// �ƂȂ�P�[�X�����݂��鎖�ɒ��ӂ��Ă�������
        ///
        /// �܂��A���L�A�Z���u�����Q�ƒǉ����Ă�������
        /// �A�Z���u���́A�g�p����V�X�e���̃f�B���N�g���ȉ��ɔz�u���Ă�������
        /// (��: SF�BL�CS --> \SuperFrontman �ȉ��֔z�u����)
        /// ���R�~���j�P�[�V�����c�[���̃C���X�g�[���ł̓C���X�g�[�����s���܂���
        ///
        /// BLCMTServiceProvider.dll
        /// SFCMN05012E.dll
        /// SFINQ01130I.dll
        /// </remarks>
        /// <param name="authenticateCode">�F�؃R�[�h</param>
        /// <param name="simplInqAcntAcntId">�ȒP�⍇���A�J�E���gID�i��ƃR�[�h���擾����A�J�E���gID�j</param>
        /// <param name="smpInqBasExt">�ȒP�⍇��ID�t�����}�X�^(��{���)</param>
        /// <param name="errorMsg">�G���[���b�Z�[�W</param>
        /// <returns>�������ʃX�e�[�^�X</returns>
        private int SearchSimplInqAcntGrpId(
            string authenticateCode,
            string simplInqAcntAcntId,
            SmplInqBasExt smpInqBasExt,
            out string errorMsg
        )
        {
            errorMsg = string.Empty;

            //--- �ȒP�⍇���f�[�^�T�[�r�X�v���o�C�_����C���^�t�F�[�X���擾���܂�
            ISimpleInquiryDataService simpleInquiryDataService = BLCMTServiceProvider.GetISimpleInquiryDataService();

            List<InqAcntGrp> inqActGrList = null;   // �A�J�E���g�O���[�v��񃊃X�g
            int status = -1;

            //--- �擾�����C���^�t�F�[�X�𗘗p���āA�ȒP�⍇��ID(�A�J�E���gID)�̊�Ə����擾���܂�
            //    2010/06/25 20:00 ���_�ł́A���s����ƃG���[�ɂȂ�܂��̂ł����ӂ�������
            try
            {
                status = simpleInquiryDataService.SearchInqAcntGrp(
                    authenticateCode,
                    simplInqAcntAcntId,
                    out inqActGrList,
                    out errorMsg
                );

                // ���L�N���X�̃v���p�e�B�Ɋ�ƃR�[�h���Z�b�g����Ă��܂��B
                // ��ƃR�[�h���擾�ł��Ȃ��ꍇ(��Ə��֘A���ݒ肳��Ă��Ȃ�)�́A
                // �I�u�W�F�N�g���̂�null�ŕԂ�̂ŁAnull�`�F�b�N�͍s���Ă��������B
                if (status.Equals(0))
                {
                    if (inqActGrList != null)
                    {
                        // ���X�g���Ɏ擾�����A�J�E���g�O���[�vID�������Ă��܂�
                        foreach (InqAcntGrp inqAcntGrp in inqActGrList)
                        {
                            smpInqBasExt.SimplInqAcntGrIdList.Add(inqAcntGrp.SimplInqAcntAcntGrId);
                        }
                    }
                    else
                    {
                        Debug.Assert(false, "NG: inqActGrList ��null" + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                    }
                }
                else
                {
                    Debug.Assert(false, "NG:�G���[�R�[�h�F" + status.ToString() + "<- " + authenticateCode + ", " + simplInqAcntAcntId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                errorMsg += Environment.NewLine + ex.Message;
                Debug.Assert(false, "NG:��O\n" + "<- " + authenticateCode + ", " + simplInqAcntAcntId + "\n" + ex.ToString());

                //    2010/06/25 20:00 ���_�ł́A���s����ƃG���[�ɂȂ�܂��̂ł����ӂ�������
                //status = 0; // HACK:2010/06/28 ���������܂ŉ��Ή�
            }
            return status;
        }
        // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<

        #endregion
    }

    /// <summary>
    /// �ȒP�⍇��ID�ϊ��\���t�@�C��
    /// </summary>
    [Serializable]
    public class SimplInqIDExchangeAppConfig
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SimplInqIDExchangeAppConfig() { }

        #endregion // </Constructor>

        #region <WebURL>

        /// <summary>Web�T�[�r�XURL</summary>
        private string _webServiceURL;

        /// <summary>Web�T�[�r�XURL</summary>
        public string WebServiceURL
        {
            get { return _webServiceURL; }
            set { _webServiceURL = value; }
        }

        #endregion  // WebURL
    }

    // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
    /// <summary>
    /// �ȒP�⍇��ID�t�����}�X�^(��{���)�̊g���N���X
    /// </summary>
    public sealed class SmplInqBasExt : SmplInqBas
    {
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID���X�g</summary>
        private readonly List<string> _simplInqAcntGrIdList = new List<string>();
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID���X�g���擾���܂��B</summary>
        public List<string> SimplInqAcntGrIdList
        {
            get { return _simplInqAcntGrIdList; }
        }

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SmplInqBasExt() : base() { }

        #endregion // Constructor
    }
    // ADD 2010/06/25 IDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<
}
