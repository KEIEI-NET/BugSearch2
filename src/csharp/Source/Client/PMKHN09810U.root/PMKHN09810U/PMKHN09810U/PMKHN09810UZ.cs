//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�C���|�[�g�E�G�N�X�|�[�g�t���[���N���X
// �v���O�����T�v   : �C���|�[�g�E�G�N�X�|�[�g���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
#define ADD20060407

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[���ʗp�t�H�[���R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���ʃt���[���ɂċN������t�H�[�����R���g���[������N���X�ł��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// </remarks>
    internal class FormControlInfo
    {
        # region Private Members
        private string _key;
        private string _assemblyID;
        private string _classID;
        private string _name;
        private System.Drawing.Image _icon;
        private Form _form;
        private Form _viewForm;
        private bool _isInit = false;
        private int _ctrlFuncCode = 10;
        private object _param = null;
#if ADD20060407
        private int _selSectionKindIndex;
        private string[] _selSections = new string[0];
        private int[] _selSystems = new int[0];
#endif
        private int[] _softwareCode = new int[0];

        # endregion

        # region Constructor
        /// <summary>
        /// ���[���ʗp�t�H�[���R���g���[���N���X�R���X�g���N�^
        /// </summary>
        /// <param name="key">�N���X�̃L�[���</param>
        /// <param name="assemblyId">�A�Z���u���h�c</param>
        /// <param name="classId">�N���X�h�c</param>
        /// <param name="name">����</param>
        /// <param name="icon">�A�C�R��</param>
        /// <param name="ctrlFuncCode">���䋒�_�R�[�h</param>
        /// <param name="softwareCode">�I���\�V�X�e���R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���[���ʗp�t�H�[���R���g���[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public FormControlInfo(string key, string assemblyId, string classId, string name, object icon, int ctrlFuncCode, object param, int[] softwareCode)
        {
            this._key = key;
            this._assemblyID = assemblyId;
            this._classID = classId;
            this._name = name;
            this._icon = icon as System.Drawing.Image;
            this._form = null;
            this._viewForm = null;
            this._isInit = false;
            this._ctrlFuncCode = ctrlFuncCode;
            this._param = param;
            this._softwareCode = softwareCode;
        }
        # endregion

        # region Properties
        /// <summary>�L�[�v���p�e�B</summary>
        /// <value>���̃v���O�����A�C�e���̃L�[���擾�܂��͐ݒ肵�܂��B</value>
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>�A�Z���u��ID�v���p�e�B</summary>
        /// <value>���̃v���O�����A�C�e���̃A�Z���u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string AssemblyID
        {
            get { return _assemblyID; }
            set { _assemblyID = value; }
        }

        /// <summary>�N���XID�v���p�e�B</summary>
        /// <value>���̃v���O�����A�C�e���̃N���X�������̂��擾�܂��͐ݒ肵�܂��B</value>
        public string ClassID
        {
            get { return _classID; }
            set { _classID = value; }
        }

        /// <summary>�v���O�������̃v���p�e�B</summary>
        /// <value>���̃v���O�����̖��̂��擾�܂��͐ݒ肵�܂��B</value>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>�A�C�R���v���p�e�B</summary>
        /// <value>�A�C�R�����擾�܂��͐ݒ肵�܂��B</value>
        public System.Drawing.Image Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        /// <value>Form�^�ɃL���X�g�����ʃA�Z���u���̃t�H�[���I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
        public System.Windows.Forms.Form Form
        {
            get { return _form; }
            set { _form = value; }
        }

        /// <value>Form�^�ɃL���X�g�����ʃA�Z���u���̃r���[�v�t�H�[���I�u�W�F�N�g���擾�܂��͐ݒ肵�܂��B</value>
        public System.Windows.Forms.Form ViewForm
        {
            get { return _viewForm; }
            set { _viewForm = value; }
        }

        /// <summary>����N���L���v���p�e�B</summary>
        /// <value>����N���L�����擾�܂��͐ݒ肵�܂��B</value>
        public bool IsInit
        {
            get { return _isInit; }
            set { _isInit = value; }
        }

        /// <summary>����@�\�R�[�h�v���p�e�B</summary>
        /// <value>����@�\�R�[�h���擾�܂��͐ݒ肵�܂��B</value>
        public int CtrlFuncCode
        {
            get { return _ctrlFuncCode; }
            set { _ctrlFuncCode = value; }
        }

        /// <summary>�����p�����[�^�v���p�e�B</summary>
        /// <value>�����p�����[�^���擾�܂��͐ݒ肵�܂��B</value>
        public object Param
        {
            get { return _param; }
            set { _param = value; }
        }

        /// <summary>�I�����_��ރv���p�e�B</summary>
        /// <value>�I�����_��ނ��擾�܂��͐ݒ肵�܂��B</value>
        public int SelSectionKindIndex
        {
            get { return _selSectionKindIndex; }
            set { _selSectionKindIndex = value; }
        }

        /// <summary>�I�����_�v���p�e�B</summary>
        /// <value>�I�����_���擾�܂��͐ݒ肵�܂��B</value>
        public string[] SelSections
        {
            get { return _selSections; }
            set { _selSections = value; }
        }

        /// <summary>�I���V�X�e���v���p�e�B</summary>
        /// <value>�I���V�X�e�����擾�܂��͐ݒ肵�܂��B</value>
        public int[] SelSystems
        {
            get { return _selSystems; }
            set { _selSystems = value; }
        }

        /// <summary>�I���\�V�X�e���v���p�e�B</summary>
        /// <value>�I���\�V�X�e�����擾�܂��͐ݒ肵�܂��B</value>
        public int[] SoftWareCode
        {
            get { return _softwareCode; }
            set { _softwareCode = value; }
        }
      
        # endregion

        # region Internal Methods
        # endregion
    }
}
