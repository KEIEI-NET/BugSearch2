//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : PMTAB�Z�b�V�����Ǘ��f�[�^�폜���� �t�H�[���N���X        //
// �v���O�����T�v   : PMTAB�Z�b�V�����Ǘ��f�[�^�e�[�u���ɑ΂��č폜�������s�� //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11300141-00 �쐬�S�� : 杍^                                      //
// �� �� ��  2017/04/06 �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMTAB�Z�b�V�����Ǘ��f�[�^�폜���� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : PMTAB�Z�b�V�����Ǘ��f�[�^�폜����UI�t�H�[���N���X</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : 2017/04/06</br>
    /// </remarks>
    public partial class PMTAB00200UA : Form
    {
        #region �� Const Memebers ��
        /// <summary>�v���O����ID</summary>
        private const string ASSEMBLY_ID = "PMTAB00200UA";
        /// <summary>XML�t�@�C��</summary>
        private const string XMLFileName = "PMTAB00200U_UserSetting.xml";
        #endregion

        # region �� private field ��
        /// <summary>���[�U�[�ݒ���</summary>
        private UserSettingInfo UserSetInfo;
        private PmTabSessionMngAcs _pmTabSessionMngAcs;
        #endregion
       
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="workDir">���s���p�X</param>
        /// <remarks>
        /// <br>Note        : �R���X�g���N�^</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2017/04/06</br>
        /// </remarks>
        public PMTAB00200UA(string workDir)
        {
            InitializeComponent();

            this.UserSetInfo = new UserSettingInfo();
            this._pmTabSessionMngAcs = PmTabSessionMngAcs.GetInstance();

            this.Deserialize(workDir);
        }
        #endregion

        # region �� �C�x���g ��
        /// <summary>
        /// PMTAB�Z�b�V�����Ǘ��f�[�^�폜����
        /// </summary>
        /// <remarks>
        /// <br>Note		: PMTAB�Z�b�V�����Ǘ��f�[�^�폜�������s���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2017/04/06</br>
        /// </remarks>
        public int DeleteData()
        {
            // �����p�����[�^�ݒ�
            PmTabSessionMngWork pmTabSessionMngWork = new PmTabSessionMngWork();
            pmTabSessionMngWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            string holdDays = this.UserSetInfo.HoldDays;
            int holdDaysResult = 0;
            if (!int.TryParse(holdDays, out holdDaysResult))
            {
                // �ϊ��ł��Ȃ������ꍇ��7�����Œ�Ƃ���
                holdDaysResult = 7;
            }
            DateTime holdDaysDateTime = DateTime.Today.AddDays((holdDaysResult * -1) + 1);
            pmTabSessionMngWork.CreateDateTime = holdDaysDateTime;

            // �f�[�^�폜����
            string errMsg;
            int status = this._pmTabSessionMngAcs.DeleteData(pmTabSessionMngWork, out errMsg);
            return status;
        }
        #endregion

        #region �� �z�u�t�@�C���f�V���A���C�Y�E�V���A���C�Y����
        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <param name="workDir">���s���p�X</param>
        /// <remarks>
        /// <br>Note        : �f�V���A���C�Y�������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2017/04/06</br>
        /// </remarks>
        private void Deserialize(string workDir)
        {

            if (UserSettingController.ExistUserSetting(Path.Combine(workDir, XMLFileName)))
            {
                try
                {
                    this.UserSetInfo = UserSettingController.DeserializeUserSetting<UserSettingInfo>(Path.Combine(workDir, XMLFileName));
                }
                catch
                {
                    this.UserSetInfo = new UserSettingInfo();
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// XML���擾�p���[�U�[�ݒ���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : XML���擾�p���[�U�[�ݒ���N���X�ł��B</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : 2017/04/06</br>
    /// </remarks>
    public class UserSettingInfo
    {
        /// <summary> �ۑ����t </summary>
        private string _holdDays = string.Empty;

        /// <summary>
        /// �ۑ����t
        /// </summary>
        public string HoldDays
        {
            get { return _holdDays; }
            set { _holdDays = value; }
        }
    }
}
