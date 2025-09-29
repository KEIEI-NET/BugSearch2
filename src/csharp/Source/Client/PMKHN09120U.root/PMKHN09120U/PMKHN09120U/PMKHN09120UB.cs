//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : �Z�L�����e�B�Ǘ����C���t���[���̃^�u�\��
// �v���O�����T�v   : �Z�L�����e�B�Ǘ����C���t���[���̃^�u�\�����`���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �Z�L�����e�B�Ǘ����C���t���[���̃^�u�\���N���X
    /// </summary>
    internal sealed class TabConfig
    {
        #region <���쌠���ݒ�/>

        /// <summary>���쌠���ݒ�^�u�̃L�[</summary>
        public const string SECURITY_MANAGEMENT_SETTING_KEY = "TAB_SECURITY_MANAGEMENT_SETTING";

        /// <summary>���쌠���ݒ�^�u�̃e�L�X�g�i�^�C�g���j</summary>
        private const string SECURITY_MANAGEMENT_SETTING_TEXT = "���쌠���ݒ�"; // LITERAL:

        /// <summary>���쌠���ݒ�^�u�̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int SECURITY_MANAGEMENT_SETTING_ICON_INDEX = (int)Size16_Index.EDITING;

        /// <summary>
        /// ���쌠���ݒ�^�u�\���C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <returns>���쌠���ݒ�^�u�\���C���X�^���X</returns>
        private static TabConfig CreateSecurityManagementSettingTabConfig()
        {
            return new TabConfig(
                SECURITY_MANAGEMENT_SETTING_KEY,
                SECURITY_MANAGEMENT_SETTING_TEXT,
                IconResourceManagement.ImageList16.Images[SECURITY_MANAGEMENT_SETTING_ICON_INDEX],
                new PMKHN09130UA()
            );
        }

        #endregion  // <���쌠���ݒ�/>

        #region <���쌠���ꗗ�\��/>

        /// <summary>���쌠���ꗗ�\���^�u�̃L�[</summary>
        public const string SECURITY_MANAGEMENT_VIEW_KEY = "TAB_SECURITY_MANAGEMENT_VIEW";

        /// <summary>���쌠���ꗗ�\���^�u�̃e�L�X�g</summary>
        private const string SECURITY_MANAGEMENT_VIEW_TEXT = "�]�ƈ������ꗗ�\��";    // LITERAL:

        /// <summary>���쌠���ꗗ�\���^�u�̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int SECURITY_MANAGEMENT_VIEW_ICON_INDEX = (int)Size16_Index.VIEW;

        /// <summary>
        /// ���쌠���ꗗ�\���^�u�\���C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <returns>���쌠���ꗗ�\���^�u�\���C���X�^���X</returns>
        private static TabConfig CreateSecurityManagementViewTabConfig()
        {
            return new TabConfig(
                SECURITY_MANAGEMENT_VIEW_KEY,
                SECURITY_MANAGEMENT_VIEW_TEXT,
                IconResourceManagement.ImageList16.Images[SECURITY_MANAGEMENT_VIEW_ICON_INDEX],
                new PMKHN09130UB()
            );
        }

        #endregion  // <���쌠���ꗗ�\��/>

        #region <���엚��\��/>

        /// <summary>���엚��\���^�u�̃L�[</summary>
        public const string OPERATION_LOG_VIEW_KEY = "TAB_OPERATION_LOG_VIEW";

        /// <summary>���엚��\���^�u�̃e�L�X�g</summary>
        private const string OPERATION_LOG_VIEW_TEXT = "���엚��\��";  // LITERAL:

        /// <summary>���엚��\���^�u�̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int OPERATION_LOG_VIEW_ICON_INDEX = (int)Size16_Index.INPUTCHECK;

        /// <summary>
        /// ���엚��\���^�u�\���C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <returns>���엚��\���^�u�\���C���X�^���X</returns>
        private static TabConfig CreateOperationLogViewTabConfig()
        {
            return new TabConfig(
                OPERATION_LOG_VIEW_KEY,
                OPERATION_LOG_VIEW_TEXT,
                IconResourceManagement.ImageList16.Images[OPERATION_LOG_VIEW_ICON_INDEX],
                new PMKHN09140UA()
            );
        }

        #endregion  // <���엚��\��/>

        #region <�G���[���O�\��/>

        /// <summary>�G���[���O�\���^�u�̃L�[</summary>
        public const string ERROR_LOG_VIEW_KEY = "TAB_ERROR_LOG_VIEW";

        /// <summary>�G���[���O�\���^�u�̃e�L�X�g</summary>
        private const string ERROR_LOG_VIEW_TEXT = "���O�\��";  // LITERAL:

        /// <summary>�G���[���O�\���^�u�̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int ERROR_LOG_VIEW_ICON_INDEX = (int)Size16_Index.INPUTCHECK;

        /// <summary>
        /// �G���[���O�\���^�u�\���C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <returns>�G���[���O�\���^�u�\���C���X�^���X</returns>
        private static TabConfig CreateErrorLogViewTabConfig()
        {
            return new TabConfig(
                ERROR_LOG_VIEW_KEY,
                ERROR_LOG_VIEW_TEXT,
                IconResourceManagement.ImageList16.Images[ERROR_LOG_VIEW_ICON_INDEX],
                new PMKHN09140UB()
            );
        }

        #endregion  // <�G���[���O�\��/>

        /// <summary>
        /// �^�u�\���C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <remarks>
        /// �L�[�ɊY��������̂��Ȃ��ꍇ�Anull ��Ԃ��܂��B
        /// </remarks>
        /// <param name="tabKey">�^�u�̃L�[</param>
        /// <returns>�^�u�\���C���X�^���X</returns>
        public static TabConfig CreateInstance(string tabKey)
        {
            switch (tabKey)
            {
                case SECURITY_MANAGEMENT_SETTING_KEY:
                    return CreateSecurityManagementSettingTabConfig();

                case SECURITY_MANAGEMENT_VIEW_KEY:
                    return CreateSecurityManagementViewTabConfig();

                case OPERATION_LOG_VIEW_KEY:
                    return CreateOperationLogViewTabConfig();

                case ERROR_LOG_VIEW_KEY:
                    return CreateErrorLogViewTabConfig();

                default:
                    return null;
            }
        }

        /// <summary>
        /// �C���[�W���X�g���擾���܂��B
        /// </summary>
        /// <value>�C���[�W���X�g</value>
        public static ImageList ImageList
        {
            get { return IconResourceManagement.ImageList16; }
        }

        #region <�A�N�Z�T/>

        /// <summary>�^�u�̃L�[</summary>
		private readonly string _key;
        /// <summary>
        /// �^�u�̃L�[���擾���܂��B
        /// </summary>
        /// <value>�^�u�̃L�[</value>
        public string Key
        {
            get { return _key; }
        }

        /// <summary>�^�u�̃e�L�X�g�i�^�C�g���j</summary>
        private readonly string _text;
        /// <summary>
        /// �^�u�̃e�L�X�g�i�^�C�g���j���擾���܂��B
        /// </summary>
        /// <value>�^�u�̃e�L�X�g�i�^�C�g���j</value>
        public string Text
        {
            get { return _text; }
        }

        /// <summary>�^�u�̃A�C�R��</summary>
        private readonly Image _icon;
        /// <summary>
        /// �^�u�̃A�C�R�����擾���܂��B
        /// </summary>
        /// <value>�^�u�̃A�C�R��</value>
        public Image Icon
        {
            get { return _icon; }
        }

        /// <summary>�Ή�����t�H�[���R���g���[��</summary>
        private readonly Form _form;
        /// <summary>
        /// �Ή�����t�H�[���R���g���[�����擾���܂��B
        /// </summary>
        /// <value>�Ή�����t�H�[���R���g���[��</value>
        public Form Form
        {
            get { return _form; }
        }

        #endregion  // <�A�N�Z�T/>

        #region <Constructor/>

        /// <summary>
		/// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="key">�^�u�̃L�[</param>
        /// <param name="text">�^�u�̃e�L�X�g�i�^�C�g���j</param>
        /// <param name="icon">�^�u�̃A�C�R��</param>
        /// <param name="form">�Ή�����t�H�[���R���g���[��</param>
        private TabConfig(
			string key, 
			string text,
            Image icon,
            Form form
		)
        {
            _key = key;
            _text = text;
            _icon = icon;
            _form = form;
        }

        #endregion  // <Constructor/>
    }
}