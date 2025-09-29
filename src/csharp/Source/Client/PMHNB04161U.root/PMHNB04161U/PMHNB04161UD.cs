//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/07/20  �C�����e : �e�L�X�g�o��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �C �� ��  2010/10/09  �C�����e : ��QID:15880�Ή�
//----------------------------------------------------------------------------//
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
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	public partial class PMHNB04161UD : Form
	{
		#region Constructor
		/// <summary>
		/// ���[�U�[�ݒ��ʃN���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���[�U�[�ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public PMHNB04161UD()
		{
			InitializeComponent();

			this._imageList16									= IconResourceManagement.ImageList16;

            this._analysisTextSettingAcs                        = new AnalysisTextSettingAcs();

            this._analysisTextSettingAcs.ReferDivValue = this.ReferDiv; // ADD 2010/10/09
            this.tEdit_SalesEmployeeFileName.Text = this._analysisTextSettingAcs.SalesEmployeeFileNameValue;
		}
        // ---ADD 2010/10/09 --------------------->>>
        public PMHNB04161UD(int referDiv)
        {
            InitializeComponent();

            this.ReferDiv = referDiv;
            this._imageList16 = IconResourceManagement.ImageList16;

            this._analysisTextSettingAcs = new AnalysisTextSettingAcs(this.ReferDiv);

            this._analysisTextSettingAcs.ReferDivValue = this.ReferDiv;
            this.tEdit_SalesEmployeeFileName.Text = this._analysisTextSettingAcs.SalesEmployeeFileNameValue;
            this.tEdit_SalesSellerFileName.Text = this._analysisTextSettingAcs.SalesSellerFileNameValue;
            this.tEdit_SalesPublisherFileName.Text = this._analysisTextSettingAcs.SalesPublisherFileNameValue;
        }
        // ---ADD 2010/10/09 ---------------------<<<
		#endregion

        /// <summary>�e�L�X�g�o�͐ݒ�A�N�Z�X�N���X</summary>
        public AnalysisTextSettingAcs AnalysisTextSettingAcs
        {
            get { return this._analysisTextSettingAcs; }
            set { this._analysisTextSettingAcs = value; }
        }

		#region Private Members
		private ImageList _imageList16 = null;
        private AnalysisTextSettingAcs _analysisTextSettingAcs = null;
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>�Q�Ƌ敪</summary>
        private int _referDiv = 0;
        // ---ADD 2010/10/09 ---------------------<<<
		#endregion

        // ---ADD 2010/10/09 --------------------->>>
        #region �v���p�e�B
        /// <summary>
        /// �Q�Ƌ敪
        /// </summary>
        public int ReferDiv
        {
            get { return this._referDiv; }
            set { this._referDiv = value; }
        }
        #endregion
        // ---ADD 2010/10/09 ---------------------<<<

        #region Control Events
        /// <summary>
		/// Form.Load �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
        private void PMHNB04161UD_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;

            this.ultraButton_SalesEmployeeFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesEmployeeFileSelect.Appearance.Image = Size16_Index.STAR1;

            this.tEdit_SalesEmployeeFileName.Text = this._analysisTextSettingAcs.SalesEmployeeFileNameValue;
            // ---ADD 2010/10/09 --------------------->>>
            this.ultraButton_SalesSellerFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesSellerFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesPublisherFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesPublisherFileSelect.Appearance.Image = Size16_Index.STAR1;

            this.tEdit_SalesSellerFileName.Text = this._analysisTextSettingAcs.SalesSellerFileNameValue;
            this.tEdit_SalesPublisherFileName.Text = this._analysisTextSettingAcs.SalesPublisherFileNameValue;
            // ---ADD 2010/10/09 ---------------------<<<
		}

        private void ultraButton_FileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {
               
                case "ultraButton_SalesEmployeeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesEmployeeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesEmployeeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesEmployeeFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }
            
        }

        // ---ADD 2010/10/09 --------------------->>>
        private void ultraButton_SellerFileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {

                case "ultraButton_SalesSellerFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesSellerFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesSellerFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesSellerFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }

        }

        private void ultraButton_PublisherFileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {

                case "ultraButton_SalesPublisherFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesPublisherFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesPublisherFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesPublisherFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }

        }
        // ---ADD 2010/10/09 ---------------------<<<

		/// <summary>
		/// UltraButton.Click �C�x���g�iOk_ultraButton�j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
        /// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
            // ---UPD 2010/10/09 --------------------->>>
            //this._analysisTextSettingAcs.SalesEmployeeFileNameValue = this.tEdit_SalesEmployeeFileName.Text;
            // �t�@�C�����i�S���ҁj
            this._analysisTextSettingAcs.SalesEmployeeFileNameValue = this.tEdit_SalesEmployeeFileName.Text;

            // �t�@�C�����i�󒍎ҁj
            this._analysisTextSettingAcs.SalesSellerFileNameValue = this.tEdit_SalesSellerFileName.Text;

            // �t�@�C�����i���s�ҁj
            this._analysisTextSettingAcs.SalesPublisherFileNameValue = this.tEdit_SalesPublisherFileName.Text;
            // ---UPD 2010/10/09 ---------------------<<<
            this._analysisTextSettingAcs.Serialize();

            this.Close();
            
		}
		#endregion

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g����</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SalesEmployeeFileName":
                    {
                        if (e.ShiftKey)
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
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text))
                                        {
                                            // ������
                                            //e.NextCtrl = Ok_ultraButton; // DEL 2010/10/09
                                            e.NextCtrl = tEdit_SalesSellerFileName; // DEL 2010/10/09
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_SalesEmployeeFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                // ---ADD 2010/10/09 --------------------->>>
                case "tEdit_SalesSellerFileName":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text))
                                        {
                                            // �t�@�C�����i�S���ҁj�K�C�h
                                            e.NextCtrl = ultraButton_SalesEmployeeFileSelect;
                                        }
                                        else
                                        {
                                            // �t�@�C�����i�S���ҁj
                                            e.NextCtrl = tEdit_SalesEmployeeFileName;
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
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesSellerFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_SalesPublisherFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_SalesSellerFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesPublisherFileName":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SalesSellerFileName.Text))
                                        {
                                            // �t�@�C�����i�󒍎ҁj�K�C�h
                                            e.NextCtrl = ultraButton_SalesSellerFileSelect;
                                        }
                                        else
                                        {
                                            // �t�@�C�����i�󒍎ҁj
                                            e.NextCtrl = tEdit_SalesSellerFileName;
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
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesPublisherFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_SalesPublisherFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                // ---ADD 2010/10/09 ---------------------<<<
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
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        //if (string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text)) // DEL 2010/10/09
                                        if (string.IsNullOrEmpty(tEdit_SalesPublisherFileName.Text)) // ADD 2010/10/09
                                        {
                                            // ������
                                            //e.NextCtrl = ultraButton_SalesEmployeeFileSelect; // DEL 2010/10/09
                                            e.NextCtrl = ultraButton_SalesPublisherFileSelect; // ADD 2010/10/09
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            //e.NextCtrl = tEdit_SalesEmployeeFileName; // DEL 2010/10/09
                                            e.NextCtrl = tEdit_SalesPublisherFileName; // ADD 2010/10/09
                                        }
                                    }
                                    break;
                                default:
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �L�����Z���{�^��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
	}

    
    /// <summary>
    /// �e�L�X�g�o�͐ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V���A�������镪�̓e�L�X�g�o�͐ݒ�N���X�ł��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010/07/20</br>
    /// </remarks>
    [Serializable]
    public class AnalysisTextSetting
    {
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>�Q�Ƌ敪</summary>
        private int _referDivValue = 0;
        // ---ADD 2010/10/09 ---------------------<<<

        // ---ADD 2010/10/09 --------------------->>>
        #region �v���p�e�B
        /// <summary>
        /// �Q�Ƌ敪
        /// </summary>
        public int ReferDivValue
        {
            get { return this._referDivValue; }
            set { this._referDivValue = value; }
        }
        #endregion
        // ---ADD 2010/10/09 ---------------------<<<

        #region Constructor
        /// <summary>
        /// �e�L�X�g�o�͐ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͐ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSetting()
        {
            this._salesEmployeeFileNameValue = string.Empty;
            this._salesSellerFileNameValue = string.Empty; // ADD 2010/10/09
            this._salesPublisherFileNameValue = string.Empty; // ADD 2010/10/09
        }

        /// <summary>
        /// �e�L�X�g�o�͐ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="salesEmployeeFileNameValue">�o�̓t�@�C�����i�S���ҁj�����l</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͐ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSetting(string salesEmployeeFileNameValue)
        {
            // ---UPD 2010/10/09 --------------------->>>
            //this._salesEmployeeFileNameValue = salesEmployeeFileNameValue;
            // �Q�Ƌ敪�͎󒍎҂̏ꍇ
            if (this._referDivValue == 2)
            {
                this._salesSellerFileNameValue = salesEmployeeFileNameValue;
            }
            // �Q�Ƌ敪�͔��s�҂̏ꍇ
            else if (this._referDivValue == 3)
            {
                this._salesPublisherFileNameValue = salesEmployeeFileNameValue;
            }
            // ���̂ق��̏ꍇ
            else
            {
                this._salesEmployeeFileNameValue = salesEmployeeFileNameValue;
            }
            // ---UPD 2010/10/09 ---------------------<<<
        }
        #endregion

        #region Private Member
        /// <summary>�o�̓t�@�C�����i�S���ҁj�����l</summary>
        private string _salesEmployeeFileNameValue;

        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>�o�̓t�@�C�����i�󒍎ҁj�����l</summary>
        private string _salesSellerFileNameValue;

        /// <summary>�o�̓t�@�C�����i���s�ҁj�����l</summary>
        private string _salesPublisherFileNameValue;
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion

        #region Propaty

        /// <summary>�o�̓t�@�C�����i�S���ҁj�����l�v���p�e�B</summary>
        public string SalesEmployeeFileNameValue
        {
            get { return this._salesEmployeeFileNameValue; }
            set { this._salesEmployeeFileNameValue = value; }
        }
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>�o�̓t�@�C�����i�󒍎ҁj�����l�v���p�e�B</summary>
        public string SalesSellerFileNameValue
        {
            get { return this._salesSellerFileNameValue; }
            set { this._salesSellerFileNameValue = value; }
        }

        /// <summary>�o�̓t�@�C�����i���s�ҁj�����l�v���p�e�B</summary>
        public string SalesPublisherFileNameValue
        {
            get { return this._salesPublisherFileNameValue; }
            set { this._salesPublisherFileNameValue = value; }
        }
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion
    }

    /// <summary>
    /// �e�L�X�g�o�͐ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�͐ݒ�N���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010/07/20</br>
    /// </remarks>
    public class AnalysisTextSettingAcs
    {
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>�Q�Ƌ敪</summary>
        private int _referDivValue = 0;
        // ---ADD 2010/10/09 ---------------------<<<

        // ---ADD 2010/10/09 --------------------->>>
        #region �v���p�e�B
        /// <summary>
        /// �Q�Ƌ敪
        /// </summary>
        public int ReferDivValue
        {
            get { return this._referDivValue; }
            set { this._referDivValue = value; }
        }

        /// <summary>�e�L�X�g�o�͐ݒ�N���X</summary>
        public AnalysisTextSetting AnalysisTextSetting
        {
            get { return _analysisTextSetting; }
            set { _analysisTextSetting = value; }
        }
        #endregion
        // ---ADD 2010/10/09 ---------------------<<<

        #region Constructor
        /// <summary>
        /// �e�L�X�g�o�͐ݒ�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͐ݒ�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSettingAcs()
        {
            if (_analysisTextSetting == null)
            {
                _analysisTextSetting = new AnalysisTextSetting();
            }
            _analysisTextSetting.ReferDivValue = this.ReferDivValue; // ADD 2010/10/09
            this.Deserialize();
        }
        // ---ADD 2010/10/09 --------------------->>>
        public AnalysisTextSettingAcs(int referDivValue)
        {
            this.ReferDivValue = referDivValue;
            if (_analysisTextSetting == null)
            {
                _analysisTextSetting = new AnalysisTextSetting();
            }
            _analysisTextSetting.ReferDivValue = this.ReferDivValue;
            this.Deserialize();
        }
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion

        #region Private Member
        /// <summary>�e�L�X�g�o�͐ݒ�N���X</summary>
        private static AnalysisTextSetting _analysisTextSetting;
        /// <summary>�e�L�X�g�o�͐ݒ�ۑ��t�@�C������</summary>
        private const string XML_FILE_NAME = "PMHNB04160U_Construction.XML";
        #endregion

        #region Events
        /// <summary>�e�L�X�g�o�͐ݒ�ύX��C�x���g</summary>
        public static event EventHandler AnalysisTextSettingChanged;
        #endregion

        #region Properties
        /// <summary>�o�̓t�@�C�����i�S���ҁj�����l�v���p�e�B</summary>
        public string SalesEmployeeFileNameValue
        {
            get
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue; // ADD 2010/10/09

                return _analysisTextSetting.SalesEmployeeFileNameValue;
            }
            set
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue; // ADD 2010/10/09

                _analysisTextSetting.SalesEmployeeFileNameValue = value;
            }
        }
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>�o�̓t�@�C�����i�󒍎ҁj�����l�v���p�e�B</summary>
        public string SalesSellerFileNameValue
        {
            get
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;

                return _analysisTextSetting.SalesSellerFileNameValue;
            }
            set
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;

                _analysisTextSetting.SalesSellerFileNameValue = value;
            }
        }

        /// <summary>�o�̓t�@�C�����i���s�ҁj�����l�v���p�e�B</summary>
        public string SalesPublisherFileNameValue
        {
            get
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;

                return _analysisTextSetting.SalesPublisherFileNameValue;
            }
            set
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;
                _analysisTextSetting.SalesPublisherFileNameValue = value;
            }
        }
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion

        #region Public Methods
        /// <summary>
        /// �e�L�X�g�o�͐ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͐ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_analysisTextSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

            // �S���ҕʎ��яƉ��ʗp���[�U�[�ݒ�ύX��C�x���g
            if (AnalysisTextSettingChanged != null)
            {
                AnalysisTextSettingChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// �e�L�X�g�o�͐ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͐ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    _analysisTextSetting = UserSettingController.DeserializeUserSetting<AnalysisTextSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
            }
        }
        #endregion
    }
    
}