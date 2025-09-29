//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : ���i�f�[�^�폜���� �t�H�[���N���X                       //
// �v���O�����T�v   : ���i�f�[�^�e�[�u���ɑ΂��č폜�������s��                //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������                                 //
// �� �� ��  2017/05/22  �C�����e : �V�K�쐬                                  //
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
    /// ���i�f�[�^�폜���� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�f�[�^�폜����UI�t�H�[���N���X</br>
    /// <br>Programmer  : 3H ������</br>
    /// <br>Date        : 2017/05/22</br>
    /// </remarks>
    public partial class PMHND00200UA : Form
    {
        #region �� Const Memebers ��
        /// <summary>XML�t�@�C��</summary>
        private const string ct_XMLFileName = "PMHND00200U_UserSetting.xml";
        /// <summary>�f�t�H���g�ۑ����t</summary>
        private const int ct_DefaultHoldDays = 30;
        #endregion

        # region �� private field ��
        /// <summary>���[�U�[�ݒ���</summary>
        private UserSettingInfo UserSetInfo;
        /// <summary>���i�f�[�^�폜�����A�N�Z�X�N���X</summary>
        private InspectDataAcs _inspectDataAcs;
        #endregion
       
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="workDir">���s���p�X</param>
        /// <remarks>
        /// <br>Note        : �R���X�g���N�^</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date        : 2017/05/22</br>
        /// </remarks>
        public PMHND00200UA(string workDir)
        {
            InitializeComponent();

            // ���[�U�[�ݒ���<
            this.UserSetInfo = new UserSettingInfo();
            // ���i�f�[�^�폜�����A�N�Z�X�N���X
            this._inspectDataAcs = InspectDataAcs.GetInstance();

            // �f�V���A���C�Y����
            this.Deserialize(workDir);
        }
        #endregion

        # region �� �C�x���g ��
        /// <summary>
        /// ���i�f�[�^�폜����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���i�f�[�^�폜�������s���܂��B</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date        : 2017/05/22</br>
        /// </remarks>
        public int DeleteData()
        {
            // �����p�����[�^�ݒ�
            InspectDataWork inspectDataWork = new InspectDataWork();

            // ��ƃR�[�h
            inspectDataWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ۑ����t
            int intHoldDays = 0;
            // �ۑ������̐����^�C�v�ϊ�
            bool parseFlg = int.TryParse(this.UserSetInfo.HoldDays, out intHoldDays);
            if (!parseFlg)
            {
                intHoldDays = ct_DefaultHoldDays;
            }
            DateTime createDateTimeEnd = DateTime.Today.AddDays((intHoldDays * -1) + 1);
            // �쐬����
            inspectDataWork.CreateDateTime = createDateTimeEnd;

            // �f�[�^�폜����
            string errMsg;
            int status = this._inspectDataAcs.DeleteData(inspectDataWork, out errMsg);
            return status;
        }
        #endregion

        #region �� �z�u�t�@�C���f�V���A���C�Y�E�V���A���C�Y���� ��
        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <param name="workDir">���s���p�X</param>
        /// <remarks>
        /// <br>Note        : �f�V���A���C�Y�������s���B</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date        : 2017/05/22</br>
        /// </remarks>
        private void Deserialize(string workDir)
        {

            if (UserSettingController.ExistUserSetting(Path.Combine(workDir, ct_XMLFileName)))
            {
                try
                {
                    this.UserSetInfo = UserSettingController.DeserializeUserSetting<UserSettingInfo>(Path.Combine(workDir, ct_XMLFileName));
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
    /// <br>Programmer  : 3H ������</br>
    /// <br>Date        : 2017/05/22</br>
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
