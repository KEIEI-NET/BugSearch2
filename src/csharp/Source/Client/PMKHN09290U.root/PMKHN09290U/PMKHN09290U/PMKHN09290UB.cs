using System;
using System.IO;

//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �o�b�N�A�b�v������ʕۑ��N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�b�N�A�b�v������ʕۑ��N���X�ł��B</br>
    /// <br>Programmer : ���r��</br>
    /// <br>Date       : 2011.06.25</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class UiSetByAssembly
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members

        private string _saveFilePath;
        private string _executionDiv;
        private string _executeHour;
        private string _executeMinute;
        private string _shutdownDiv;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �I�v�V�����ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V�����ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���r��</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public UiSetByAssembly()
        {
            //�ۑ���t�H���_
            this._saveFilePath = "";
            //�����敪
            this._executionDiv = "";
            //�����J�n���Ԃ̎�
            this._executeHour = "";
            //�����J�n���Ԃ̕�
            this._executeMinute = "";
            //�����V���b�g�_�E���敪
            this._shutdownDiv= "";
        }

        /// <summary>
        /// �o�b�N�A�b�v������ʕۑ��I�v�V�����ݒ�N���X
        /// </summary>
        /// <param name="saveFilePath">�ۑ���t�H���_</param>
        /// <param name="executionDiv">�����敪</param>
        /// <param name="executeHour">�����J�n���Ԃ̎�</param>
        ///<param name="executeMinute">�����J�n���Ԃ̕�</param>
        /// <param name="shutdownDiv">�����V���b�g�_�E���敪</param>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v������ʕۑ��N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���r��</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public UiSetByAssembly(string saveFilePath, string executionDiv, string executeHour, string executeMinute, string shutdownDiv)
        {
            this._saveFilePath = saveFilePath;
            this._executionDiv = executionDiv;
            this._executeHour = executeHour;
            this._executeMinute = executeMinute;
            this._shutdownDiv = shutdownDiv;

        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�ۑ���t�H���_�v���p�e�B</summary>
        public string SaveFilePath
        {
            get { return this._saveFilePath; }
            set { this._saveFilePath = value; }
        }

        /// <summary>�����敪�v���p�e�B</summary>
        public string ExecutionDiv
        {
            get { return this._executionDiv; }
            set { this._executionDiv = value; }
        }

        /// <summary>�����J�n���Ԃ̎��v���p�e�B</summary>
        public string ExecuteHour
        {
            get { return this._executeHour; }
            set { this._executeHour = value; }
        }
        /// <summary>�����J�n���Ԃ̕��v���p�e�B</summary>
        public string ExecutionMinute
        {
            get { return this._executeMinute; }
            set { this._executeMinute = value; }
        }

        /// <summary>�����V���b�g�_�E���敪�v���p�e�B</summary>
        public string ShutdownDiv
        {
            get { return this._shutdownDiv; }
            set { this._shutdownDiv= value; }
        }

        # endregion

        /// <summary>
        /// �o�b�N�A�b�v������ʕۑ�����
        /// </summary>
        /// <returns>�o�b�N�A�b�v������ʕۑ������ݒ�N���X</returns>
        public UiSetByAssembly Clone()
        {
            return new UiSetByAssembly(this._saveFilePath, this._executionDiv, this._executeHour, this._executeMinute, this._shutdownDiv);
        }
    }

    /// <summary>
    /// �o�b�N�A�b�v������ʕۑ������ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�b�N�A�b�v������ʕۑ��������Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : ���r��</br>
    /// <br>Date       : 2011.06.25</br>
    /// <br></br>
    /// </remarks>
    public class UiSetByAssemblyAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private static UiSetByAssembly _UiSetByAssembly;
        private const string XML_FILE_NAME = "PMKHN09290U_Settings.XML ";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �o�b�N�A�b�v������ʕۑ��N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v������ʕۑ��N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���r��</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public UiSetByAssemblyAcs()
        {
            if (_UiSetByAssembly == null)
            {
                _UiSetByAssembly = new UiSetByAssembly();
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        # region Event
        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        public static event EventHandler DataChanged;
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties



        /// <summary> �ۑ���t�H���_�ݒ�l�v���p�e�B</summary>
        public string SaveFilePath
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.SaveFilePath;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.SaveFilePath = value;
            }
        }

        /// <summary> �����敪�ݒ�l�v���p�e�B</summary>
        public string ExecutionDiv
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ExecutionDiv;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ExecutionDiv = value;
            }
        }

        /// <summary> �����J�n���Ԃ̎��ݒ�l�v���p�e�B</summary>
        public string ExecuteHour
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ExecuteHour;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ExecuteHour = value;
            }
        }

        /// <summary> �����J�n���Ԃ̕��ݒ�l�v���p�e�B</summary>
        public string ExecutionMinute
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ExecutionMinute;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ExecutionMinute = value;
            }
        }

        /// <summary> �����V���b�g�_�E���敪�ݒ�l�v���p�e�B</summary>
        public string ShutdownDiv
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ShutdownDiv;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ShutdownDiv = value;
            }
        }

        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// �o�b�N�A�b�v������ʕۑ������N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v������ʕۑ������N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : ���r��</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_UiSetByAssembly, Path.Combine               (ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// �o�b�N�A�b�v������ʕۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v������ʕۑ��N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : ���r��</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _UiSetByAssembly = UserSettingController.DeserializeUserSetting<UiSetByAssembly>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
        }
        # endregion
    }
}
