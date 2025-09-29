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
//using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�U�[�ݒ��ʃN���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���[�U�[�ݒ������͂��܂��B</br>
    /// <br>Programmer : 30462 �s�V�@�m��</br>
    /// <br>Date       : 2008.12.01</br>
    /// <br>Update Note: 2010/07/20 ����p</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13482</br>
	/// </remarks>
	public partial class DCHNB04180UC : Form
	{
		#region Constructor
		/// <summary>
		/// ���[�U�[�ݒ��ʃN���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���[�U�[�ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		/// </remarks>
		public DCHNB04180UC()
		{
			InitializeComponent();

			this._imageList16									= IconResourceManagement.ImageList16;

			this._analysisChartSettingAcs						= new AnalysisChartSettingAcs();

			// �ڍו\�������l
			this.DetailDisplayInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.DetailDisplayInitialValue;
			// �|�C���g���x���\�������l
			this.PointLabelInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.PointLabelInitialValue;
			// �|�C���g���x���t�H���g�T�C�Y�����l
			this.PointLabelSize_tComboEditor.Value				= this._analysisChartSettingAcs.PointLabelSizeInitialValue;
			// ���x���p�x�����l
			this.LabelVerticalInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.LabelVerticalInitialValue;
			// ���x���ő包�������l
			if (this._analysisChartSettingAcs.LabelMaxLengthInitialValue != -1)
			{
				this.LabelMaxLengthInitialValue_tNedit.SetInt(this._analysisChartSettingAcs.LabelMaxLengthInitialValue);
			}
			else
			{
				this.LabelMaxLengthInitialValue_tNedit.Clear();
			}
			// ���x���t�H���g�T�C�Y�����l
			this.LabelSize_tComboEditor.Value					= this._analysisChartSettingAcs.LabelSizeInitialValue;
			// �R�c�^�Q�c�\�������l
			this.View3D2DInitialValue_ultraOptionSet.Value		= this._analysisChartSettingAcs.View3D2DInitialValue;

            // --- ADD 2010/07/20 -------------------------------->>>>>
            this.tEdit_SectionFileName.Text = this._analysisChartSettingAcs.SectionFileNameValue;
            this.tEdit_CustomerFileName.Text = this._analysisChartSettingAcs.CustomerFileNameValue;
            this.tEdit_SalesEmployeeFileName.Text = this._analysisChartSettingAcs.SalesEmployeeFileNameValue;
            this.tEdit_FrontEmployeeFileName.Text = this._analysisChartSettingAcs.FrontEmployeeFileNameValue;
            this.tEdit_SalesInputFileName.Text = this._analysisChartSettingAcs.SalesInputFileNameValue;
            this.tEdit_SalesAreaFileName.Text = this._analysisChartSettingAcs.SalesAreaFileNameValue;
            this.tEdit_BusinessTypeFileName.Text = this._analysisChartSettingAcs.BusinessTypeFileNameValue;
            // --- ADD 2010/07/20 --------------------------------<<<<<
		}
		#endregion

        // --- ADD 2010/07/20 -------------------------------->>>>>
        public AnalysisChartSettingAcs AnalysisChartSettingAcs
        {
            get { return this._analysisChartSettingAcs; }
            set { this._analysisChartSettingAcs = value; }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

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
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		/// </remarks>
		private void SFANL06500UE_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;
			this.Ok_ultraButton.Appearance.Image						= Size16_Index.DECISION;
			this.Cancel_ultraButton.Appearance.Image					= Size16_Index.BEFORE;

            // --- ADD 2010/07/20 -------------------------------->>>>>
            this.ultraButton_SectionFileSelect.ImageList = this._imageList16;
            this.ultraButton_CustomerFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesEmployeeFileSelect.ImageList = this._imageList16;
            this.ultraButton_FrontEmployeeFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesInputFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesAreaFileSelect.ImageList = this._imageList16;
            this.ultraButton_BusinessTypeFileSelect.ImageList = this._imageList16;
            this.ultraButton_SectionFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_CustomerFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesEmployeeFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_FrontEmployeeFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesInputFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesAreaFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_BusinessTypeFileSelect.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2010/07/20 --------------------------------<<<<<

			// �ڍו\�������l
			this.DetailDisplayInitialValue_ultraOptionSet.Value			= this._analysisChartSettingAcs.DetailDisplayInitialValue;
			this.DetailDisplayInitialValue_ultraOptionSet.FocusedIndex	= this.DetailDisplayInitialValue_ultraOptionSet.CheckedIndex;
			// �|�C���g���x���\�������l
			this.PointLabelInitialValue_ultraOptionSet.Value			= this._analysisChartSettingAcs.PointLabelInitialValue;
			this.PointLabelInitialValue_ultraOptionSet.FocusedIndex		= this.PointLabelInitialValue_ultraOptionSet.CheckedIndex;
			// �|�C���g���x���t�H���g�T�C�Y�����l
			this.PointLabelSize_tComboEditor.Value						= this._analysisChartSettingAcs.PointLabelSizeInitialValue;
			// ���x���p�x�����l
			this.LabelVerticalInitialValue_ultraOptionSet.Value			= this._analysisChartSettingAcs.LabelVerticalInitialValue;
			this.LabelVerticalInitialValue_ultraOptionSet.FocusedIndex	= this.LabelVerticalInitialValue_ultraOptionSet.CheckedIndex;
			// ���x���ő包�������l
			if (this._analysisChartSettingAcs.LabelMaxLengthInitialValue != -1)
			{
				this.LabelMaxLengthInitialValue_tNedit.SetInt(this._analysisChartSettingAcs.LabelMaxLengthInitialValue);
			}
			else
			{
				this.LabelMaxLengthInitialValue_tNedit.Clear();
			}
			// ���x���t�H���g�T�C�Y�����l
			this.LabelSize_tComboEditor.Value							= this._analysisChartSettingAcs.LabelSizeInitialValue;
			// �R�c�^�Q�c�\�������l
			this.View3D2DInitialValue_ultraOptionSet.Value				= this._analysisChartSettingAcs.View3D2DInitialValue;
			this.View3D2DInitialValue_ultraOptionSet.FocusedIndex		= this.View3D2DInitialValue_ultraOptionSet.CheckedIndex;
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this.tEdit_SectionFileName.Text = this._analysisChartSettingAcs.SectionFileNameValue;
            this.tEdit_CustomerFileName.Text = this._analysisChartSettingAcs.CustomerFileNameValue;
            this.tEdit_SalesEmployeeFileName.Text = this._analysisChartSettingAcs.SalesEmployeeFileNameValue;
            this.tEdit_FrontEmployeeFileName.Text = this._analysisChartSettingAcs.FrontEmployeeFileNameValue;
            this.tEdit_SalesInputFileName.Text = this._analysisChartSettingAcs.SalesInputFileNameValue;
            this.tEdit_SalesAreaFileName.Text = this._analysisChartSettingAcs.SalesAreaFileNameValue;
            this.tEdit_BusinessTypeFileName.Text = this._analysisChartSettingAcs.BusinessTypeFileNameValue;
            // --- ADD 2010/07/20 --------------------------------<<<<<
            
		}

        /// <summary>
        /// �t�@�C�����K�C�h�{�^��Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�@�C�����K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void ultraButton_FileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {
                case "ultraButton_SectionFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SectionFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SectionFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SectionFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_CustomerFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_CustomerFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_CustomerFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_CustomerFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_SalesEmployeeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesEmployeeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesEmployeeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesEmployeeFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_FrontEmployeeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_FrontEmployeeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_FrontEmployeeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_FrontEmployeeFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_SalesInputFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesInputFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesInputFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesInputFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_SalesAreaFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesAreaFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesAreaFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesAreaFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_BusinessTypeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_BusinessTypeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_BusinessTypeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");
                        // �t�@�C���I��
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_BusinessTypeFileName.Text = this.openFileDialog.FileName.ToUpper();
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
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
			// �ڍו\�������l
			this._analysisChartSettingAcs.DetailDisplayInitialValue			= (bool)this.DetailDisplayInitialValue_ultraOptionSet.Value;
			// �|�C���g���x���\�������l
			this._analysisChartSettingAcs.PointLabelInitialValue			= (bool)this.PointLabelInitialValue_ultraOptionSet.Value;
			// �|�C���g���x���t�H���g�T�C�Y�����l
			this._analysisChartSettingAcs.PointLabelSizeInitialValue		= (int)this.PointLabelSize_tComboEditor.SelectedItem.DataValue;
			// ���x���p�x�����l
			this._analysisChartSettingAcs.LabelVerticalInitialValue			= (bool)this.LabelVerticalInitialValue_ultraOptionSet.Value;
			// ���x���ő包�������l
			if (this.LabelMaxLengthInitialValue_tNedit.DataText == string.Empty)
			{
				this._analysisChartSettingAcs.LabelMaxLengthInitialValue	= -1;
			}
			else
			{
				this._analysisChartSettingAcs.LabelMaxLengthInitialValue	= this.LabelMaxLengthInitialValue_tNedit.GetInt();
			}
			// ���x���t�H���g�T�C�Y�����l
			this._analysisChartSettingAcs.LabelSizeInitialValue				= (int)this.LabelSize_tComboEditor.SelectedItem.DataValue;
			// �R�c�^�Q�c�\�������l
			this._analysisChartSettingAcs.View3D2DInitialValue				= (bool)this.View3D2DInitialValue_ultraOptionSet.Value;

            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._analysisChartSettingAcs.SectionFileNameValue = this.tEdit_SectionFileName.Text;
            this._analysisChartSettingAcs.CustomerFileNameValue = this.tEdit_CustomerFileName.Text;
            this._analysisChartSettingAcs.SalesEmployeeFileNameValue = this.tEdit_SalesEmployeeFileName.Text;
            this._analysisChartSettingAcs.FrontEmployeeFileNameValue = this.tEdit_FrontEmployeeFileName.Text;
            this._analysisChartSettingAcs.SalesInputFileNameValue = this.tEdit_SalesInputFileName.Text;
            this._analysisChartSettingAcs.SalesAreaFileNameValue = this.tEdit_SalesAreaFileName.Text;
            this._analysisChartSettingAcs.BusinessTypeFileNameValue = this.tEdit_BusinessTypeFileName.Text;
            // --- ADD 2010/07/20 --------------------------------<<<<<

			this._analysisChartSettingAcs.Serialize();
		}
		#endregion

        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g�������܂��B</br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "View3D2DInitialValue_ultraOptionSet":
                    {
                        # region [���t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (UserSetup_ultraTabControl.Tabs["TextSetting"].Visible == true)  // ADD 2010/08/23
                                        {
                                            // �^�u�؂�ւ�
                                            UserSetup_ultraTabControl.ActiveTab = UserSetup_ultraTabControl.Tabs["TextSetting"];
                                            UserSetup_ultraTabControl.SelectedTab = UserSetup_ultraTabControl.ActiveTab;
                                            // ������
                                            e.NextCtrl = tEdit_SectionFileName;
                                        }
                                        else
                                        {
                                            // ������
                                            e.NextCtrl = Ok_ultraButton; // ADD 2010/08/23
                                        }
                                       
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                case "tEdit_SectionFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SectionFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_CustomerFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_SectionFileSelect;
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
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (UserSetup_ultraTabControl.Tabs["ChartSetting"].Visible == true)
                                        {
                                            // �^�u�؂�ւ�
                                            UserSetup_ultraTabControl.ActiveTab = UserSetup_ultraTabControl.Tabs["ChartSetting"];
                                            UserSetup_ultraTabControl.SelectedTab = UserSetup_ultraTabControl.ActiveTab;
                                            // ������
                                            e.NextCtrl = View3D2DInitialValue_ultraOptionSet;
                                        }
                                        else
                                        {
                                            // ������
                                            e.NextCtrl = e.PrevCtrl;
                                        }

                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_CustomerFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_CustomerFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_SalesEmployeeFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_CustomerFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesEmployeeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_FrontEmployeeFileName;
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
                case "tEdit_FrontEmployeeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_FrontEmployeeFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_SalesInputFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_FrontEmployeeFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesInputFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesInputFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_SalesAreaFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_SalesInputFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesAreaFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesAreaFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_BusinessTypeFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_SalesAreaFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_BusinessTypeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_BusinessTypeFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = ultraButton_BusinessTypeFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
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
        /// UltraButton.Click �C�x���g�iCancel_ultraButton�j
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ����p</br>
        /// <br>Date		: 2010/07/20</br>
        /// </remarks>
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

        // --- ADD 2010/08/23 -------------------------------->>>>>
        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\������
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/23</br>
        /// </remarks>
        public void uTabControlSet(bool display)
        {
            //�e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B
            UserSetup_ultraTabControl.Tabs["TextSetting"].Visible = display;
        }
        // --- ADD 2010/08/23 --------------------------------<<<<<
	}

	/// <summary>
	/// ���̓`���[�g�\���ݒ�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �V���A�������镪�̓`���[�g�\���ݒ�N���X�ł��B</br>
    /// <br>Programmer : 30462 �s�V�@�m��</br>
    /// <br>Date       : 2008.12.01</br>
    /// <br>Update Note: 2010/07/20 ����p</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
	/// </remarks>
	[Serializable]
	public class AnalysisChartSetting
	{
		#region Constructor
		/// <summary>
		/// ���̓`���[�g�\���ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���̓`���[�g�\���ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
		/// </remarks>
		public AnalysisChartSetting()
		{
			this._detailDisplayInitialValue		= DEFAULT_DETAILDISPLAYINITIAL_VALUE;
			this._pointLabelInitialValue		= DEFAULT_POINTLABELINITIAL_VALUE;
			this._pointLabelSizeInitialValue	= DEFAULT_POINTLABELSIZEINITIAL_VALUE;
			this._labelVerticalInitialValue		= DEFAULT_LABELVERTICALINITIAL_VALUE;
			this._labelMaxLengthInitialValue	= DEFAULT_LABELMAXLENGTHINITIAL_VALUE;
			this._labelSizeInitialValue			= DEFAULT_LABELSIZEINITIAL_VALUE;
			this._view3D2DInitialValue			= DEFAULT_VIEW3D2DINITIAL_VALUE;
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._sectionFileNameValue = string.Empty;
            this._customerFileNameValue = string.Empty;
            this._salesEmployeeFileNameValue = string.Empty;
            this._frontEmployeeFileNameValue = string.Empty;
            this._salesInputFileNameValue = string.Empty;
            this._salesAreaFileNameValue = string.Empty;
            this._businessTypeFileNameValue = string.Empty;
            // --- ADD 2010/07/20 --------------------------------<<<<<
		}

		/// <summary>
		/// ���̓`���[�g�\���ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="detailDisplayInitialValue">�ڍו\�������l</param>
		/// <param name="pointLabelInitialValue">�|�C���g���x���\�������l</param>
		/// <param name="pointLabelSizeInitialValue">�|�C���g���x���t�H���g�T�C�Y�����l</param>
		/// <param name="labelVerticalInitialValue">���x���p�x�����l</param>
		/// <param name="labelMaxLengthInitialValue">���x���ő包�������l</param>
		/// <param name="labelSizeInitialValue">���x���t�H���g�T�C�Y�����l</param>
		/// <param name="view3D2DInitialValue">�R�c�^�Q�c�\�������l</param>
        /// <param name="sectionFileNameValue">�o�̓t�@�C�����i���_�j�����l</param>
        /// <param name="customerFileNameValue">�o�̓t�@�C�����i���Ӑ�j�����l</param>
        /// <param name="salesEmployeeFileNameValue">�o�̓t�@�C�����i�S���ҁj�����l</param>
        /// <param name="frontEmployeeFileNameValue">�o�̓t�@�C�����i�󒍎ҁj�����l</param>
        /// <param name="salesInputFileNameValue">�o�̓t�@�C�����i���s�ҁj�����l</param>
        /// <param name="salesAreaFileNameValue">�o�̓t�@�C�����i�n��j�����l</param>
        /// <param name="businessTypeFileNameValue">�o�̓t�@�C�����i�Ǝ�j�����l</param>
		/// <remarks>
        /// <br>Note       : ���̓`���[�g�\���ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		/// </remarks>
        //public AnalysisChartSetting(bool detailDisplayInitialValue, bool pointLabelInitialValue, int pointLabelSizeInitialValue, bool labelVerticalInitialValue, int labelMaxLengthInitialValue, int labelSizeInitialValue, bool view3D2DInitialValue)
        public AnalysisChartSetting(bool detailDisplayInitialValue, bool pointLabelInitialValue, int pointLabelSizeInitialValue, bool labelVerticalInitialValue, int labelMaxLengthInitialValue, int labelSizeInitialValue, bool view3D2DInitialValue, string sectionFileNameValue, string customerFileNameValue, string salesEmployeeFileNameValue, string frontEmployeeFileNameValue, string salesInputFileNameValue, string salesAreaFileNameValue, string businessTypeFileNameValue)
		{
			this._detailDisplayInitialValue		= detailDisplayInitialValue;
			this._pointLabelInitialValue		= pointLabelInitialValue;
			this._pointLabelSizeInitialValue	= pointLabelSizeInitialValue;
			this._labelVerticalInitialValue		= labelVerticalInitialValue;
			this._labelMaxLengthInitialValue	= labelMaxLengthInitialValue;
			this._labelSizeInitialValue			= labelSizeInitialValue;
			this._view3D2DInitialValue			= view3D2DInitialValue;
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._sectionFileNameValue = sectionFileNameValue;
            this._customerFileNameValue = customerFileNameValue;
            this._salesEmployeeFileNameValue = salesEmployeeFileNameValue;
            this._frontEmployeeFileNameValue = frontEmployeeFileNameValue;
            this._salesInputFileNameValue = salesInputFileNameValue;
            this._salesAreaFileNameValue = salesAreaFileNameValue;
            this._businessTypeFileNameValue = businessTypeFileNameValue;
            // --- ADD 2010/07/20 --------------------------------<<<<<
        }
        #endregion
        // --- ADD 2010/07/20 -------------------------------->>>>>
        #region Private Member
        /// <summary>�o�̓t�@�C�����i���_�j�����l</summary>
        private string _sectionFileNameValue;
        /// <summary>�o�̓t�@�C�����i���Ӑ�j�����l</summary>
        private string _customerFileNameValue;
        /// <summary>�o�̓t�@�C�����i�S���ҁj�����l</summary>
        private string _salesEmployeeFileNameValue;
        /// <summary>�o�̓t�@�C�����i�󒍎ҁj�����l</summary>
        private string _frontEmployeeFileNameValue;
        /// <summary>�o�̓t�@�C�����i���s�ҁj�����l</summary>
        private string _salesInputFileNameValue;
        /// <summary>�o�̓t�@�C�����i�n��j�����l</summary>
        private string _salesAreaFileNameValue;
        /// <summary>�o�̓t�@�C�����i�Ǝ�j�����l</summary>
        private string _businessTypeFileNameValue;
        #endregion
        // --- ADD 2010/07/20 --------------------------------<<<<<
		#region Private Member
		/// <summary>�ڍו\�������l</summary>
		private bool _detailDisplayInitialValue;
		/// <summary>�|�C���g���x���\�������l</summary>
		private bool _pointLabelInitialValue;
		/// <summary>�|�C���g���x���t�H���g�T�C�Y�����l</summary>
		private int _pointLabelSizeInitialValue;
		/// <summary>���x���p�x�����l</summary>
		private bool _labelVerticalInitialValue;
		/// <summary>���x���ő包�������l</summary>
		private int _labelMaxLengthInitialValue;
		/// <summary>���x���t�H���g�T�C�Y�����l</summary>
		private int _labelSizeInitialValue;
		/// <summary>�R�c�^�Q�c�\�������l</summary>
		private bool _view3D2DInitialValue;

		/// <summary>�ڍו\�������l</summary>
		private const bool DEFAULT_DETAILDISPLAYINITIAL_VALUE	= false;
		/// <summary>�|�C���g���x���\�������l</summary>
		private const bool DEFAULT_POINTLABELINITIAL_VALUE		= true;
		/// <summary>�|�C���g���x���t�H���g�T�C�Y�����l</summary>
		private const int DEFAULT_POINTLABELSIZEINITIAL_VALUE	= 9;
		/// <summary>���x���p�x�����l</summary>
		private const bool DEFAULT_LABELVERTICALINITIAL_VALUE	= false;
		/// <summary>���x���ő包�������l</summary>
		private const int DEFAULT_LABELMAXLENGTHINITIAL_VALUE	= -1;
		/// <summary>���x���t�H���g�T�C�Y�����l</summary>
		private const int DEFAULT_LABELSIZEINITIAL_VALUE		= 9;
		/// <summary>�R�c�^�Q�c�\�������l</summary>
		private const bool DEFAULT_VIEW3D2DINITIAL_VALUE		= true;
		#endregion

		#region Propaty
		/// <summary>�ڍו\�������l�v���p�e�B</summary>
		public bool DetailDisplayInitialValue
		{
			get { return this._detailDisplayInitialValue; }
			set { this._detailDisplayInitialValue = value; }
		}

		/// <summary>�|�C���g���x���\�������l�v���p�e�B</summary>
		public bool PointLabelInitialValue
		{
			get { return this._pointLabelInitialValue; }
			set { this._pointLabelInitialValue = value; }
		}

		/// <summary>�|�C���g���x���t�H���g�T�C�Y�����l�v���p�e�B</summary>
		public int PointLabelSizeInitialValue
		{
			get { return this._pointLabelSizeInitialValue; }
			set { this._pointLabelSizeInitialValue = value; }
		}

		/// <summary>���x���p�x�����l�v���p�e�B</summary>
		public bool LabelVerticalInitialValue
		{
			get { return this._labelVerticalInitialValue; }
			set { this._labelVerticalInitialValue = value; }
		}

		/// <summary>���x���ő包�������l�v���p�e�B</summary>
		public int LabelMaxLengthInitialValue
		{
			get { return this._labelMaxLengthInitialValue; }
			set { this._labelMaxLengthInitialValue = value; }
		}

		/// <summary>���x���t�H���g�T�C�Y�����l�v���p�e�B</summary>
		public int LabelSizeInitialValue
		{
			get { return this._labelSizeInitialValue; }
			set { this._labelSizeInitialValue = value; }
		}

		/// <summary>�R�c�^�Q�c�\�������l�v���p�e�B</summary>
		public bool View3D2DInitialValue
		{
			get { return this._view3D2DInitialValue; }
			set { this._view3D2DInitialValue = value; }
		}
        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>�o�̓t�@�C�����i���_�j�����l�v���p�e�B</summary>
        public string SectionFileNameValue
        {
            get { return this._sectionFileNameValue; }
            set { this._sectionFileNameValue = value; }
        }

        /// <summary>�o�̓t�@�C�����i���Ӑ�j�����l�v���p�e�B</summary>
        public string CustomerFileNameValue
        {
            get { return this._customerFileNameValue; }
            set { this._customerFileNameValue = value; }
        }

        /// <summary>�o�̓t�@�C�����i�S���ҁj�����l�v���p�e�B</summary>
        public string SalesEmployeeFileNameValue
        {
            get { return this._salesEmployeeFileNameValue; }
            set { this._salesEmployeeFileNameValue = value; }
        }

        /// <summary>�o�̓t�@�C�����i�󒍎ҁj�����l�v���p�e�B</summary>
        public string FrontEmployeeFileNameValue
        {
            get { return this._frontEmployeeFileNameValue; }
            set { this._frontEmployeeFileNameValue = value; }
        }

        /// <summary>�o�̓t�@�C�����i���s�ҁj�����l�v���p�e�B</summary>
        public string SalesInputFileNameValue
        {
            get { return this._salesInputFileNameValue; }
            set { this._salesInputFileNameValue = value; }
        }

        /// <summary>�o�̓t�@�C�����i�n��j�����l�v���p�e�B</summary>
        public string SalesAreaFileNameValue
        {
            get { return this._salesAreaFileNameValue; }
            set { this._salesAreaFileNameValue = value; }
        }

        /// <summary>�o�̓t�@�C�����i�Ǝ�j�����l�v���p�e�B</summary>
        public string BusinessTypeFileNameValue
        {
            get { return this._businessTypeFileNameValue; }
            set { this._businessTypeFileNameValue = value; }
        }
        #endregion
        // --- ADD 2010/07/20 --------------------------------<<<<<
	}

	/// <summary>
	/// ���̓`���[�g�\���ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̓`���[�g�\���ݒ�N���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30462 �s�V�@�m��</br>
    /// <br>Date       : 2008.12.01</br>
	/// </remarks>
	public class AnalysisChartSettingAcs
	{
		#region Constructor
		/// <summary>
		/// ���̓`���[�g�\���ݒ�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���̓`���[�g�\���ݒ�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
		/// </remarks>
		public AnalysisChartSettingAcs()
		{
			// �N�����[�h�擾
			//if (DCHNB04180UA._parameter.Length != 0)
			//{
            //    this._startMode = TStrConv.StrToIntDef(DCHNB04180UA._parameter[0], 0);
			//}

			if (_analysisChartSetting == null)
			{
				_analysisChartSetting = new AnalysisChartSetting();
			}
			this.Deserialize();
		}
		#endregion

		#region Private Member
		/// <summary>�N�����[�h</summary>
		private int _startMode = 0;
		/// <summary>���̓`���[�g�\���ݒ�N���X</summary>
		private static AnalysisChartSetting _analysisChartSetting;

		/// <summary>���̓`���[�g�\���ݒ�ۑ��t�@�C������</summary>
		private const string XML_FILE_NAME = "SFANL06500U_ChartSetting?.XML";
		#endregion

		#region Events
		/// <summary>���̓`���[�g�\���ݒ�ύX��C�x���g</summary>
		public static event EventHandler AnalysisChartSettingChanged;
		#endregion

		#region Properties
		/// <summary>�ڍו\�������l�v���p�e�B</summary>
		public bool DetailDisplayInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.DetailDisplayInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.DetailDisplayInitialValue = value;
			}
		}

		/// <summary>�|�C���g���x���\�������l�v���p�e�B</summary>
		public bool PointLabelInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.PointLabelInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.PointLabelInitialValue = value;
			}
		}

		/// <summary>�|�C���g���x���t�H���g�T�C�Y�����l�v���p�e�B</summary>
		public int PointLabelSizeInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.PointLabelSizeInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.PointLabelSizeInitialValue = value;
			}
		}

		/// <summary>���x���p�x�����l�v���p�e�B</summary>
		public bool LabelVerticalInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.LabelVerticalInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.LabelVerticalInitialValue = value;
			}
		}

		/// <summary>���x���ő包�������l�v���p�e�B</summary>
		public int LabelMaxLengthInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.LabelMaxLengthInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.LabelMaxLengthInitialValue = value;
			}
		}

        /// <summary>���x���t�H���g�T�C�Y�����l�v���p�e�B</summary>
        public int LabelSizeInitialValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.LabelSizeInitialValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.LabelSizeInitialValue = value;
            }
        }

        /// <summary>�R�c�^�Q�c�\�������l�v���p�e�B</summary>
        public bool View3D2DInitialValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.View3D2DInitialValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.View3D2DInitialValue = value;
            }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<
        #region Properties
        /// <summary>�o�̓t�@�C�����i���_�j�����l�v���p�e�B</summary>
        public string SectionFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SectionFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SectionFileNameValue = value;
            }
        }

        /// <summary>�o�̓t�@�C�����i���Ӑ�j�����l�v���p�e�B</summary>
        public string CustomerFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.CustomerFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.CustomerFileNameValue = value;
            }
        }

        /// <summary>�o�̓t�@�C�����i�S���ҁj�����l�v���p�e�B</summary>
        public string SalesEmployeeFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SalesEmployeeFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SalesEmployeeFileNameValue = value;
            }
        }

        /// <summary>�o�̓t�@�C�����i�󒍎ҁj�����l�v���p�e�B</summary>
        public string FrontEmployeeFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.FrontEmployeeFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.FrontEmployeeFileNameValue = value;
            }
        }

        /// <summary>�o�̓t�@�C�����i���s�ҁj�����l�v���p�e�B</summary>
        public string SalesInputFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SalesInputFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SalesInputFileNameValue = value;
            }
        }

        /// <summary>�o�̓t�@�C�����i�n��j�����l�v���p�e�B</summary>
        public string SalesAreaFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SalesAreaFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SalesAreaFileNameValue = value;
            }
        }

        /// <summary>�o�̓t�@�C�����i�Ǝ�j�����l�v���p�e�B</summary>
        public string BusinessTypeFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.BusinessTypeFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.BusinessTypeFileNameValue = value;
            }
        }
        #endregion
        // --- ADD 2010/07/20 --------------------------------<<<<<
		#endregion

		#region Public Methods
		/// <summary>
		/// ���̓`���[�g�\���ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���̓`���[�g�\���ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		/// </remarks>
		public void Serialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());
            
            //UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));//  DEL 2010/07/20
            UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));// ADD 2010/07/20

			// �󒍌���������ʗp���[�U�[�ݒ�ύX��C�x���g
			if (AnalysisChartSettingChanged != null)
			{
				AnalysisChartSettingChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// ���̓`���[�g�\���ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���̓`���[�g�\���ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 ����p</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
		/// </remarks>
		public void Deserialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))//  DEL 2010/07/20
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))))// ADD 2010/07/20
			{
				try
				{
                    //_analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));//  DEL 2010/07/20
                    _analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));// ADD 2010/07/20

				}
				catch (InvalidOperationException)
				{
                    //UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));//  DEL 2010/07/20
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));// ADD 2010/07/20
				}
			}
		}
		#endregion
	}
}