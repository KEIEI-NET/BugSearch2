using System;
//using System.Collections.Generic;
//using System.Text;
using System.Collections;
//using System.Xml;
//using System.IO;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���[���T�[�r�X�֘A Infomation Base
    /// </summary>
    /// <remarks>
    /// ���[���T�[�r�X�Ŏg�p����e��ݒ�����Ǘ����Ă��܂��B
    /// �܂��A���̃N���X��DB���̊O���ʐM������S�ė}���Ă��܂�
    /// 2006.11.04���� �e��Remoteing�Ɋւ��Ă͍쐬���ł��̂ŁA
    /// �����̓x��Remoteing���������s����Ă��܂��B
    /// �����悻�̖ڏ����t������ARemoteing�����̎��s�񐔂����炷
    /// �`���[�j���O�������Ă����܂�
    /// </remarks>
    public class MailInfoBase
    {

        #region �R���X�g���N�^�A�e�평��������

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="mailServiceInfoCreateMode">���[���T�[�r�X�֘A��� �������[�h</param>
        public MailInfoBase(MailServiceInfoCreateMode mailServiceInfoCreateMode)
        { 
            // �����_�R�[�h�̎擾
            try
            {
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                if (secInfoAcs.SecInfoSet != null)
                {
                    _SectionCode = secInfoAcs.SecInfoSet.SectionCode;
                    _MainOfficeFuncFlag = secInfoAcs.SecInfoSet.MainOfficeFuncFlag;
                }
                else
                {
                    _SectionCode = "";
                }

            }
            catch (Exception)
            {
                _SectionCode = "";
                IsNsSystem = false;
            }

            // �e����̏�����
            InitProc(_SectionCode, mailServiceInfoCreateMode);

        }


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="mailServiceInfoCreateMode">���[���T�[�r�X�֘A��� �������[�h</param>
        public MailInfoBase(string sectionCode, MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {
            _SectionCode = sectionCode;

            // �e����̏�����
            InitProc(_SectionCode, mailServiceInfoCreateMode);
        }


        /// <summary>
        /// InfoBase����������
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="mailServiceInfoCreateMode">���[���T�[�r�X�֘A��� �������[�h</param>
        private bool InitProc(string sectionCode, MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {

            // �e��v���p�e�B�̏�����
            _EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _SectionGuideName =   GetSectionGuideName(sectionCode);
            _MainOfficeFuncFlag = ((SecInfoSet)GetSectionInfo(sectionCode)).MainOfficeFuncFlag;

            // ���[�������Ǘ��}�X�^�֘A���W���[��������
            //if (MailInfoBase._MailDocMngAcs == null)
            //{
            //    _MailDocMngAcs = new MailDocMngAcs();
            //}


            // ���̏�����
            return true;
        }

        #endregion 

        #region static �����o


        /// <summary>
        /// ���[�������敪 0:���[������(PC)
        /// </summary>
        public static int MailDocCode_Type_PC = 0;
        /// <summary>
        /// ���[�������敪 1:�g�у��[������
        /// </summary>
        public static int MailDocCode_Type_Mobile = 1;
        /// <summary>
        /// ���[�������敪 2:����
        /// </summary>
        public static int MailDocCode_Type_Signature = 2;

        /// <summary>
        /// ���[���X�e�[�^�X��` 0:�V�K
        /// </summary>
        public static int MailStatus_NEW = MailBackup.MailBackup_MailStatus_NEW;

        /// <summary>
        /// ���[���X�e�[�^�X��` 5:�G���[�����M
        /// </summary>
        public static int MailStatus_ERROR = MailBackup.MailBackup_MailStatus_ERROR;


        private bool IsNsSystem = true;

        /// <summary>
        /// ��ƃR�[�h(InfoBase�̓����ݒ肷���ƃR�[�h)
        /// </summary>
        private string _EnterpriseCode = "";

        /// <summary>
        /// ���_�R�[�h(InfoBase�̓����ݒ肷�鋒�_�R�[�h
        /// </summary>
        private string _SectionCode = "";

        /// <summary>
        /// ���_����(InfoBase�̓����ݒ肷�鋒�_����
        /// </summary>
        private string _SectionGuideName = "";

        /// <summary>
        /// �{�Ћ@�\�t���O
        /// </summary>
        private int _MainOfficeFuncFlag = 0;


        //static private MailDocMngAcs _MailDocMngAcs = null;

        //static private DmFirstSetAcs _DmFirstSetAcs = null;

        //static private AlItmDspNmAcs _AlItmDspNmAcs = null;


        #endregion static �����o

        #region InfoBase ���t���b�V���֘A


        /// <summary>
        /// �e���񃊃t���b�V��(�Ď擾��������)
        /// </summary>
        /// <param name="mailServiceInfoCreateMode">���[���T�[�r�X�֘A��� �������[�h</param>
        /// <returns></returns>
        public bool RefreshInfoBase(MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {
            return RefreshInfoBase(_SectionCode, mailServiceInfoCreateMode);
        }


        /// <summary>
        /// �e���񃊃t���b�V��(�Ď擾��������)
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="mailServiceInfoCreateMode">���[���T�[�r�X�֘A��� �������[�h</param>
        /// <returns>true:��������</returns>
        public bool RefreshInfoBase(string sectionCode, MailServiceInfoCreateMode mailServiceInfoCreateMode)
        {


            return true;
        }

        #endregion InfoBase ���t���b�V���֘A

        #region ���_�֘A


        /// <summary>
        /// �����_���擾
        /// </summary>
        /// <remarks>
        /// ���݂̋��_���(MailInfoBase�̏�񋒓_)���擾���܂�
        /// </remarks>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionGuideName">���_����</param>
        public void GetBaseSectionCodeSet(out string sectionCode, out string sectionGuideName)
        {
            sectionCode = _SectionCode;
            sectionGuideName = _SectionGuideName;
            return;        
        
        }

        /// <summary>
        /// �����_���擾
        /// </summary>
        /// <remarks>
        /// ���݂̋��_���(MailInfoBase�̏�񋒓_)���擾���܂�
        /// </remarks>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionGuideName">���_����</param>
        /// <param name="mainOfficeFuncFlag">�{�Ћ@�\�t���O</param>
        public void GetBaseSectionCodeSet(out string sectionCode, out string sectionGuideName, out int mainOfficeFuncFlag)
        {
            sectionCode          = _SectionCode;
            sectionGuideName     = _SectionGuideName;
            mainOfficeFuncFlag   = _MainOfficeFuncFlag;
            return;        
        
        }


        /// <summary>
        /// ���_���̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�擾�������_����</returns>
        public string GetSectionGuideName(string sectionCode)
        {
            // �e��v���p�e�B�̏�����
            string retStr = "";
            if (IsNsSystem)
            {
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                retStr = "";

                if (secInfoAcs.SecInfoSetList != null)
                {
                    foreach (SecInfoSet obj in secInfoAcs.SecInfoSetList)
                    {

                        if (obj.SectionCode.Trim().Equals(sectionCode.Trim()))
                        {
                            retStr = obj.SectionGuideNm.Trim();
                            break;
                        }
                    }
                }

            }
            return retStr;
        }


        /// <summary>
        /// ���_���擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�擾�������_����</returns>
        private SecInfoSet GetSectionInfo(string sectionCode)
        {
            SecInfoSet retStr = null;
            if (IsNsSystem)
            {

                // �e��v���p�e�B�̏�����
                SecInfoAcs secInfoAcs = new SecInfoAcs();
                foreach (SecInfoSet obj in secInfoAcs.SecInfoSetList)
                {

                    if (obj.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        retStr = obj;
                        break;
                    }
                }
            }

            if (retStr == null)
            {
                retStr = new SecInfoSet();
            }

            return retStr;
        }

        /// <summary>
        /// ���_��񃊃X�g�擾
        /// </summary>
        /// <param name="secInfoSetList">�擾�������_��񃊃X�g</param>
        /// <returns>�擾���� true:����, false:���s </returns>
        public bool GetSecInfoSetList(out SecInfoSet[] secInfoSetList)
        {
            bool retSt = false;
            secInfoSetList = null;

            if (IsNsSystem)
            {

                // �e��v���p�e�B�̏�����
                SecInfoAcs secInfoAcs = new SecInfoAcs();

                if (secInfoAcs.SecInfoSetList != null)
                {
                    secInfoSetList = secInfoAcs.SecInfoSetList;
                    retSt = true;
                }
                else
                {
                    retSt = false;
                }
            }

            if (!retSt)
            {
                ArrayList al = new ArrayList();
                secInfoSetList = (SecInfoSet[])al.ToArray(typeof(SecInfoSet));
            }

            return retSt;
        }

        #endregion ���_�֘A

        #region �]�ƈ��}�X�^�֘A

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^ ���擾
        /// </summary>
        /// <returns>status</returns>
        public int GetEmployeeDtl(out Employee employee, out EmployeeDtl employeeDtl, string employeeCode)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();

            // �]�ƈ��ڍ׃}�X�^�Ǎ�
            int st = employeeAcs.Read(out employee, out employeeDtl, _EnterpriseCode, employeeCode);

            return st;
        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^ ���擾�i�K�C�h�j
        /// </summary>
        /// <returns>status</returns>
        public int GetEmployeeGuid(out Employee employee, out EmployeeDtl employeeDtl)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employee = null;
            employeeDtl = null;

            // �]�ƈ��}�X�^�Ǎ�
            int status = employeeAcs.ExecuteGuid(_EnterpriseCode, true, out employee);

            if (status == 0)
            {
                // �]�ƈ��ڍ׃}�X�^�Ǎ�
                int st = employeeAcs.Read(out employee, out employeeDtl, _EnterpriseCode, employee.EmployeeCode);

                return st;
            }
            else
            {
                return status;
            }
        }

        #endregion �]�ƈ��}�X�^�֘A

        #region ���[�����M�Ǘ��}�X�^�֘A

        /// <summary>
        /// ���[�����ݒ�}�X�^ ���擾
        /// </summary>
        /// <returns>���[�����ݒ�</returns>
        public int GetMailInfoSetting(out MailInfoSetting mailInfoSetting)
        {
            MailInfoSettingAcs mailInfoSettingAcs = new MailInfoSettingAcs();
            int st = mailInfoSettingAcs.Read(out mailInfoSetting, _EnterpriseCode, _SectionCode);

            if (mailInfoSetting == null)
            {
                mailInfoSetting = new MailInfoSetting();
            }

            return st;
        }

        #endregion ���[�����M�Ǘ��}�X�^�֘A

    }

    /// <summary>
    /// ���[���T�[�r�X�֘A��� �������[�h
    /// </summary>
    /// <remarks>
    /// MailInfoBase�AMailFactoryBase�������Ɏ擾(������)����e��������邽�߂̎��ʎq
    /// ���ʂ͂ǂ̃��[�h�ł��S�����^���[�h�œ��삵�܂��B
    /// ���̌�A���X�|���X�����݂ĉ��ǂ��K�v�ł���Ύw�肳�ꂽ���[�h�ŕK�v�Ȋe����݂̂�
    /// �I�u�W�F�N�g�������Ɏ擾���A���̑��̃f�[�^�͕K�v�ɂȂ����^�C�~���O�Ŏ擾���悤��
    /// �l���Ă��܂����
    /// </remarks>
    public enum MailServiceInfoCreateMode
    {
        /// <summary>
        /// �f�t�H���g(�Y�����郂�[�h�������ꍇ�͂����I��)
        /// </summary>
        Default = 0,
        /// <summary>
        /// �G�f�B�^���[�h
        /// </summary>
        Editor = 1,
        /// <summary>
        /// ���[�����M���C�u�������[�h
        /// </summary>
        MailSender = 2,
        /// <summary>
        /// ���[�������������[�h
        /// </summary>
        MailFactory = 4,
        /// <summary>
        /// �}�N���R���o�[�^�[�������[�h
        /// </summary>
        MacroConverter = 8,
        /// <summary>
        /// ���[���r���[�A�[���[�h
        /// </summary>
        MailViewer = 16,
        /// <summary>
        /// ���[���o�b�N�A�b�v�f�[�^���샂�[�h
        /// </summary>
        MailBackupMaker = 32,
        /// <summary>
        /// ���[�����M���𑀍샂�[�h
        /// </summary>
        MailSendHistoryMaker = 64,

        /// <summary>
        /// �S���擾���[�h
        /// </summary>
        All = Editor | MailSender | MailFactory | MacroConverter | MailViewer | MailBackupMaker | MailSendHistoryMaker
     }
}
 