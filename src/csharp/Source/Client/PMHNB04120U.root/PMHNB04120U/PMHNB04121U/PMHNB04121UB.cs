using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�U�[�ݒ��ʃN���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���[�U�[�ݒ������͂��܂��B</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	public partial class PMHNB04121UB : Form
	{
		#region Constructor
		/// <summary>
		/// ���[�U�[�ݒ��ʃN���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���[�U�[�ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public PMHNB04121UB()
		{
			InitializeComponent();

			this._imageList16 = IconResourceManagement.ImageList16;

            this._analysisChartSettingAcs = new AnalysisChartSettingAcs(); 

		}
		#endregion

        public AnalysisChartSettingAcs AnalysisChartSettingAcs
        {
            get { return this._analysisChartSettingAcs; }
            set { this._analysisChartSettingAcs = value; }
        }

		#region Private Members
		private ImageList _imageList16 = null;
        private AnalysisChartSettingAcs _analysisChartSettingAcs = null; 
		#endregion

		#region Control Events
		/// <summary>
		/// Form.Load �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
        private void PMHNB04121UB_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;
			this.Ok_ultraButton.Appearance.Image						= Size16_Index.DECISION;
			this.Cancel_ultraButton.Appearance.Image					= Size16_Index.BEFORE;

            this.ultraButton_FileSelect.ImageList = this._imageList16;
            this.ultraButton_FileSelect.Appearance.Image = Size16_Index.STAR1;

            this.tEdit_FileName.Text = this._analysisChartSettingAcs.CustomInqFileNameValue;

		}

        /// <summary>
        /// FileSelect �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void ultraButton_FileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {
                case "ultraButton_FileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_FileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_FileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_FileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }
            
        }

		/// <summary>
		/// UltraButton.Click �C�x���g�iOk_ultraButton�j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
            this._analysisChartSettingAcs.CustomInqFileNameValue = this.tEdit_FileName.Text;
            this._analysisChartSettingAcs.Serialize();
            this.DialogResult = DialogResult.OK;
            // �I��
            this.Close();
		}
		#endregion

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g�������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_FileName":
                    {
                        # region [���t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_FileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_FileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                case "Ok_ultraButton":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        // �{�^������
                                        Ok_ultraButton_Click(this, new EventArgs());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "Cancel_ultraButton":
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // �{�^������
                                    Cancel_ultraButton_Click(this, new EventArgs());
                                }
                                break;
                            case Keys.Tab:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�����Z���{�^���C�x���g�������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
	}

	/// <summary>
	/// �ݒ�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �V���A�������镪�͐ݒ�N���X�ł��B</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	[Serializable]
	public class AnalysisChartSetting
	{
		#region Constructor
		/// <summary>
		/// �ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public AnalysisChartSetting()
		{
            this._customInqFileNameValue = string.Empty;
		}

		/// <summary>
		/// �ݒ�N���X�R���X�g���N�^
		/// </summary>
        /// <param name="customInqFileNameValue">�o�̓t�@�C���������l</param>
		/// <remarks>
        /// <br>Note       : �ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
        public AnalysisChartSetting(string customInqFileNameValue)
		{
            this._customInqFileNameValue = customInqFileNameValue;
		}
		#endregion

        #region Private Member
        /// <summary>�o�̓t�@�C���������l</summary>
        private string _customInqFileNameValue;
        #endregion

        #region Propaty
        /// <summary>�o�̓t�@�C���������l�v���p�e�B</summary>
        public string CustomInqFileNameValue
        {
            get { return this._customInqFileNameValue; }
            set { this._customInqFileNameValue = value; }
        }
        #endregion
	}

	/// <summary>
	/// �\���ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �\���ݒ�N���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	public class AnalysisChartSettingAcs
	{
		#region Constructor
		/// <summary>
		/// �\���ݒ�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �ݒ�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public AnalysisChartSettingAcs()
		{
			if (_analysisChartSetting == null)
			{
				_analysisChartSetting = new AnalysisChartSetting();
			}
			this.Deserialize();
		}
		#endregion

		#region Private Member
		/// <summary>�ݒ�N���X</summary>
		private static AnalysisChartSetting _analysisChartSetting;

		/// <summary>�ݒ�ۑ��t�@�C������</summary>
		private const string XML_FILE_NAME = "PMHNB04120U_Construction.XML";
		#endregion

		#region Events
		/// <summary>�ݒ�ύX��C�x���g</summary>
		public static event EventHandler AnalysisChartSettingChanged;
		#endregion

        #region Properties
        /// <summary>�o�̓t�@�C���������l�v���p�e�B</summary>
        public string CustomInqFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.CustomInqFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.CustomInqFileNameValue = value;
            }
        }
        #endregion

		#region Public Methods
		/// <summary>
		/// �\���ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : �\���ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public void Serialize()
		{
            string fileName = XML_FILE_NAME;

            UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));

			// ������ʗp���[�U�[�ݒ�ύX��C�x���g
			if (AnalysisChartSettingChanged != null)
			{
				AnalysisChartSettingChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// �\���ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : �\���ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public void Deserialize()
		{
            string fileName = XML_FILE_NAME;

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))))
			{
				try
				{
					_analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                }
				catch (InvalidOperationException)
				{
					UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
				}
			}
		}
		#endregion
	}
}