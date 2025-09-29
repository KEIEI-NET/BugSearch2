using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
   /// <summary>
	/// ���㑬��\�� ���[�U�[�ݒ���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���㑬��\���̃��[�U�[�ݒ�����Ǘ�����N���X</br>
	/// <br>Programmer : 30418 ���i</br>
	/// <br>Date       : 2008.11.210</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class SalesReportSetting
	{
		#region �v���C�x�[�g�ϐ�

        /// <summary>�ݒ�F�N�����̒��o 0:���Ȃ� 1:����</summary>
		private int _startupSearch;

        /// <summary>�ݒ�F�����X�V 0:���Ȃ� 0~:�X�V�Ԋu(��)</summary>
		private int _autoUpdateTime;

        /// <summary>�ݒ�F���_�����l 0:�����_ 1:�S��</summary>
        private int _initialSectionCode;

        #endregion // �v���C�x�[�g�ϐ�

        #region �����ݒ�l

        /// <summary>�����ݒ�l�F�N�����̒��o �����l�u���Ȃ��v</summary>
        private const int DEFAULT_STARTUP_SEARCH = 1;

        /// <summary>�����ݒ�l�F�����X�V �����l�u0:���Ȃ��v</summary>
        private const int DEFAULT_AUTO_UPDATE = 0;

        /// <summary>�����ݒ�l�F���_�̏����l �����l�u�����_�v</summary>
        private const int DEFAULT_INITIAL_SECTIONCODE = 0;

        #endregion // �����ݒ�l

		#region �R���X�g���N�^

		/// <summary>
		/// ���㑬��\���p���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���㑬��\���p���[�U�[�ݒ�N���X�̐V�����C���X�^���X��������</br>
		/// <br>Programmer : 34108 ���i</br>
		/// <br>Date       : 2008.11.20</br>
		/// </remarks>
		public SalesReportSetting()
		{
            this._startupSearch = DEFAULT_STARTUP_SEARCH;
			this._autoUpdateTime = DEFAULT_AUTO_UPDATE;
			this._initialSectionCode = DEFAULT_INITIAL_SECTIONCODE;
		}

		/// <summary>
		/// ���㑬��\���p���[�U�[�ݒ�N���X
		/// </summary>
        /// <param name="startupSearch"></param>
        /// <param name="autoUpdateTime"></param>
        /// <param name="initialSectionCode"></param>
		/// <remarks>
		/// <br>Note       : ���㑬��\���p���[�U�[�ݒ�N���X�̐V�����C���X�^���X��������</br>
		/// <br>Programmer : 34108 ���i</br>
		/// <br>Date       : 2008.11.20</br>
		/// </remarks>
		public SalesReportSetting(int startupSearch, int autoUpdateTime, int initialSectionCode)
		{
            this._startupSearch = startupSearch;
			this._autoUpdateTime = autoUpdateTime;
			this._initialSectionCode = initialSectionCode;
		}
		#endregion // �R���X�g���N�^

		#region ���J�v���p�e�B

		/// <summary>�N�����̒��o�v���p�e�B</summary>
		public int StartupSearch
		{
			get { return this._startupSearch; }
			set { this._startupSearch = value; }
		}

		/// <summary>�����X�V�v���p�e�B</summary>
		public int AutoUpdateTime
		{
			get { return this._autoUpdateTime; }
			set { this._autoUpdateTime = value; }
		}

        /// <summary>���_�̏����l�v���p�e�B</summary>
		public int InitialSectionCode
		{
			get { return this._initialSectionCode; }
			set { this._initialSectionCode = value; }
		}

        #endregion // ���J�v���p�e�B

        #region �N���[��

		/// <summary>
		/// ���㑬��\���p���[�U�[�ݒ�N���X��������
		/// </summary>
		/// <returns>���㑬��\���p���[�U�[�ݒ�N���X</returns>
		public SalesReportSetting Clone()
		{
			return new SalesReportSetting(this._startupSearch, this._autoUpdateTime, this._initialSectionCode);
		}

		#endregion // �N���[��
	}

    /// <summary>
    /// ���㑬��\���p ���[�U�[�ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㑬��\���̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SalesReportSettingAcs
    {
        # region �p�u���b�N�萔

        /// <summary>�ݒ��ʁF�N�����̒��o�@�����l�u���Ȃ��v</summary>
        public static readonly int SETTING_DEFVALUE_START_SEARCH = 1;

        /// <summary>�ݒ��ʁF�����X�V�@�����l�u0:���Ȃ��v</summary>
        public static readonly int SETTING_DEFVALUE_AUTO_UPDATE = 0;

        /// <summary>�ݒ��ʁF���_�̏����l�@�����l�u�����_�v</summary>
        public static readonly int SETTING_DEFVALUE_DEF_SECTIONCODE = 0;

        # endregion // �p�u���b�N�萔

        # region �v���C�x�[�g�ϐ�

        /// <summary>XML�t�@�C�����́F�����l�uPMKHN04150U_Construction.XML�v</summary>
        private const string CT_XML_FILE_NAME = "PMKHN04150U_Construction.XML";

        /// <summary>XML�t�@�C�����F�����l�Ȃ�</summary>
        private string _xmlFileName = "";

        /// <summary>���㑬��\���p���[�U�[�ݒ�N���X</summary>
        private static SalesReportSetting _salesReportSetting;

        /// <summary>�ݒ���s�t���O</summary>
        private bool _alreadySetup = false;

        # endregion // �v���C�x�[�g�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// ���㑬��\���p���[�U�[�ݒ� �A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���㑬��\���p���[�U�[�ݒ� �A�N�Z�X�N���X�̐V�����C���X�^���X���쐬</br>
        /// <br>Programmer : 34108 ���i</br>
        /// <br>Date       : 2008.11.20</br>
        /// </remarks>
        public SalesReportSettingAcs()
        {
            this._xmlFileName = CT_XML_FILE_NAME;
            if (_salesReportSetting == null)
            {
                _salesReportSetting = new SalesReportSetting();
            }
            this.Deserialize();
        }

        /// <summary>
        /// ���㑬��\���p���[�U�[�ݒ� �A�N�Z�X�N���X
        /// </summary>
        /// <param name="xmlFileName">XML�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���㑬��\���p���[�U�[�ݒ� �A�N�Z�X�N���X�̐V�����C���X�^���X���쐬</br>
        /// <br>Programmer : 34108 ���i</br>
        /// <br>Date       : 2008.11.20</br>
        /// </remarks>
        public SalesReportSettingAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_salesReportSetting == null)
            {
                _salesReportSetting = new SalesReportSetting();
            }
            this.Deserialize();
        }

        # endregion // �R���X�g���N�^

        # region �v���p�e�B

        /// <summary>�ݒ���s�t���O</summary>
        public bool AlreadySetup
        {
            get { return this._alreadySetup; }
            set { this._alreadySetup = value; }
        }

        /// <summary>�N�����̒��o�v���p�e�B</summary>
        public int StartupSearch
        {
            get
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                return _salesReportSetting.StartupSearch;
            }
            set
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                _salesReportSetting.StartupSearch = value;
            }
        }

        /// <summary>�����X�V�v���p�e�B</summary>
        public int AutoUpdateTime
        {
            get
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                return _salesReportSetting.AutoUpdateTime;
            }
            set
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                _salesReportSetting.AutoUpdateTime = value;
            }
        }

        /// <summary>���_�̏����l�v���p�e�B</summary>
        public int InitialSectionCode
        {
            get
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                return _salesReportSetting.InitialSectionCode;
            }
            set
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                _salesReportSetting.InitialSectionCode = value;
            }
        }

        # endregion // �v���p�e�B

        # region �p�u���b�N���\�b�h

        /// <summary>
        /// �V���A���C�Y����
        /// </summary>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_salesReportSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
        }

        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                _salesReportSetting = UserSettingController.DeserializeUserSetting<SalesReportSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
                this._alreadySetup = true;
            }
            else
            {
                this._alreadySetup = false;
            }
        }

        # endregion // �p�u���b�N���\�b�h
    }
}
