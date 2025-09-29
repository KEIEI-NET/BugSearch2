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
using System.Xml;
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
    /// <br>Update Note: 2010/07/20 �m�u��</br>
    /// <br>            �E�e�L�X�g�AExcek�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�13482</br>
    /// </remarks>
    public partial class PMKOU04110UC : Form
    {
        #region Constructor
        /// <summary>
        /// ���[�U�[�ݒ��ʃN���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public PMKOU04110UC()
        {
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;

            this._analysisChartSettingAcs = new AnalysisChartSettingAcs();

            // --- ADD 2010/06/28 ---------->>>>>
            this._textFileSettingAcs = new TextFileSettingAcs();
            // --- ADD 2010/06/28 ----------<<<<<

            // �ڍו\�������l
            this.DetailDisplayInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.DetailDisplayInitialValue;
            // �|�C���g���x���\�������l
            this.PointLabelInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.PointLabelInitialValue;
            // �|�C���g���x���t�H���g�T�C�Y�����l
            this.PointLabelSize_tComboEditor.Value = this._analysisChartSettingAcs.PointLabelSizeInitialValue;
            // ���x���p�x�����l
            this.LabelVerticalInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.LabelVerticalInitialValue;
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
            this.LabelSize_tComboEditor.Value = this._analysisChartSettingAcs.LabelSizeInitialValue;
            // �R�c�^�Q�c�\�������l
            this.View3D2DInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.View3D2DInitialValue;

            // --- ADD 2010/06/28 ---------->>>>>
            this.tEdit_SettingFileName.Value = this._textFileSettingAcs.SupplierFileName;
            // --- ADD 2010/06/28 ----------<<<<<
        }
        #endregion

        #region Private Members
        private ImageList _imageList16 = null;
        private AnalysisChartSettingAcs _analysisChartSettingAcs = null;

        // --- ADD 2010/06/28 ---------->>>>>
        public TextFileSettingAcs _textFileSettingAcs = null;
        // --- ADD 2010/06/28 ----------<<<<<
        #endregion

        // --- ADD 2010/07/20-------------------------------->>>>>
        #region Public Method
        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\������
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// <remarks>
        public void uTabControlSet(bool display)
        {
            //�e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B
            UserSetup_ultraTabControl.Tabs[1].Visible = display;
        }
        #endregion
        // --- ADD 2010/07/20--------------------------------<<<<<

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
        /// </remarks>
        private void SFANL06500UE_Load(object sender, EventArgs e)
        {
            this.Ok_ultraButton.ImageList = this._imageList16;
            this.Cancel_ultraButton.ImageList = this._imageList16;
            this.Ok_ultraButton.Appearance.Image = Size16_Index.DECISION;
            this.Cancel_ultraButton.Appearance.Image = Size16_Index.BEFORE;
            this.uButton_FileSelect.ImageList = this._imageList16; // ADD 2010/07/20
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1; // ADD 2010/07/20

            // �ڍו\�������l
            this.DetailDisplayInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.DetailDisplayInitialValue;
            this.DetailDisplayInitialValue_ultraOptionSet.FocusedIndex = this.DetailDisplayInitialValue_ultraOptionSet.CheckedIndex;
            // �|�C���g���x���\�������l
            this.PointLabelInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.PointLabelInitialValue;
            this.PointLabelInitialValue_ultraOptionSet.FocusedIndex = this.PointLabelInitialValue_ultraOptionSet.CheckedIndex;
            // �|�C���g���x���t�H���g�T�C�Y�����l
            this.PointLabelSize_tComboEditor.Value = this._analysisChartSettingAcs.PointLabelSizeInitialValue;
            // ���x���p�x�����l
            this.LabelVerticalInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.LabelVerticalInitialValue;
            this.LabelVerticalInitialValue_ultraOptionSet.FocusedIndex = this.LabelVerticalInitialValue_ultraOptionSet.CheckedIndex;
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
            this.LabelSize_tComboEditor.Value = this._analysisChartSettingAcs.LabelSizeInitialValue;
            // �R�c�^�Q�c�\�������l
            this.View3D2DInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.View3D2DInitialValue;
            this.View3D2DInitialValue_ultraOptionSet.FocusedIndex = this.View3D2DInitialValue_ultraOptionSet.CheckedIndex;

            // --- ADD 2010/06/28 ---------->>>>>
            this.tEdit_SettingFileName.Value = this._textFileSettingAcs.SupplierFileName;
            // --- ADD 2010/06/28 ----------<<<<<

        // --- ADD 2010/07/20-------------------------------->>>>>
            // �{�^���ݒ�
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
        // --- ADD 2010/07/20--------------------------------<<<<<
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
        /// </remarks>
        private void Ok_ultraButton_Click(object sender, EventArgs e)
        {
            // �ڍו\�������l
            this._analysisChartSettingAcs.DetailDisplayInitialValue = (bool)this.DetailDisplayInitialValue_ultraOptionSet.Value;
            // �|�C���g���x���\�������l
            this._analysisChartSettingAcs.PointLabelInitialValue = (bool)this.PointLabelInitialValue_ultraOptionSet.Value;
            // �|�C���g���x���t�H���g�T�C�Y�����l
            this._analysisChartSettingAcs.PointLabelSizeInitialValue = (int)this.PointLabelSize_tComboEditor.SelectedItem.DataValue;
            // ���x���p�x�����l
            this._analysisChartSettingAcs.LabelVerticalInitialValue = (bool)this.LabelVerticalInitialValue_ultraOptionSet.Value;
            // ���x���ő包�������l
            if (this.LabelMaxLengthInitialValue_tNedit.DataText == string.Empty)
            {
                this._analysisChartSettingAcs.LabelMaxLengthInitialValue = -1;
            }
            else
            {
                this._analysisChartSettingAcs.LabelMaxLengthInitialValue = this.LabelMaxLengthInitialValue_tNedit.GetInt();
            }
            // ���x���t�H���g�T�C�Y�����l
            this._analysisChartSettingAcs.LabelSizeInitialValue = (int)this.LabelSize_tComboEditor.SelectedItem.DataValue;
            // �R�c�^�Q�c�\�������l
            this._analysisChartSettingAcs.View3D2DInitialValue = (bool)this.View3D2DInitialValue_ultraOptionSet.Value;

            this._analysisChartSettingAcs.Serialize();

            // --- ADD 2010/06/28 ---------->>>>>
            this._textFileSettingAcs.SupplierFileName = (string)this.tEdit_SettingFileName.Value;
            this._textFileSettingAcs.Serialize();
        // --- ADD 2010/07/20-------------------------------->>>>>
            // �I��
            this.Close();
        // --- ADD 2010/07/20--------------------------------<<<<<
            // --- ADD 2010/06/28 ----------<<<<<
        }
        #endregion

        // --- ADD 2010/06/28 ---------->>>>>
        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName;
            }

        }


        // --- ADD 2010/06/28 ----------<<<<<

        // --- ADD 2010/07/20 ---------->>>>>
        private void PMKOU04110UC_Shown(object sender, EventArgs e)
        {
            DetailDisplayInitialValue_ultraOptionSet.Focus();
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g�������s��</br>
        /// <br>Programmer : �m�u��</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SettingFileName":
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                    if (!string.IsNullOrEmpty(tEdit_SettingFileName.Text))
                                    {
                                        // ������
                                        e.NextCtrl = Ok_ultraButton;
                                    }
                                    else
                                    {
                                        // �K�C�h�{�^��
                                        e.NextCtrl = uButton_FileSelect;
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
                                    if (UserSetup_ultraTabControl.Tabs[0].Visible == true)
                                    {
                                        // �^�u�؂�ւ�
                                        UserSetup_ultraTabControl.ActiveTab = UserSetup_ultraTabControl.Tabs[0];
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
                    break;
                case "View3D2DInitialValue_ultraOptionSet":
                    if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (UserSetup_ultraTabControl.Tabs[1].Visible) // ADD 2010/08/23
                                        {
                                            // ������
                                            UserSetup_ultraTabControl.ActiveTab = UserSetup_ultraTabControl.Tabs[1];
                                            UserSetup_ultraTabControl.SelectedTab = UserSetup_ultraTabControl.ActiveTab;
                                            e.NextCtrl = tEdit_SettingFileName;
                                        }
                                        else
                                        {
                                            // ������
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                        
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    break;
                case "DetailDisplayInitialValue_ultraOptionSet":
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
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SettingFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = tEdit_SettingFileName;
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
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
        // --- ADD 2010/07/20 ----------<<<<<

    }

    /// <summary>
    /// ���̓`���[�g�\���ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V���A�������镪�̓`���[�g�\���ݒ�N���X�ł��B</br>
    /// <br>Programmer : 30462 �s�V�@�m��</br>
    /// <br>Date       : 2008.12.01</br>
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
            this._detailDisplayInitialValue = DEFAULT_DETAILDISPLAYINITIAL_VALUE;
            this._pointLabelInitialValue = DEFAULT_POINTLABELINITIAL_VALUE;
            this._pointLabelSizeInitialValue = DEFAULT_POINTLABELSIZEINITIAL_VALUE;
            this._labelVerticalInitialValue = DEFAULT_LABELVERTICALINITIAL_VALUE;
            this._labelMaxLengthInitialValue = DEFAULT_LABELMAXLENGTHINITIAL_VALUE;
            this._labelSizeInitialValue = DEFAULT_LABELSIZEINITIAL_VALUE;
            this._view3D2DInitialValue = DEFAULT_VIEW3D2DINITIAL_VALUE;
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
        /// <remarks>
        /// <br>Note       : ���̓`���[�g�\���ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public AnalysisChartSetting(bool detailDisplayInitialValue, bool pointLabelInitialValue, int pointLabelSizeInitialValue, bool labelVerticalInitialValue, int labelMaxLengthInitialValue, int labelSizeInitialValue, bool view3D2DInitialValue)
        {
            this._detailDisplayInitialValue = detailDisplayInitialValue;
            this._pointLabelInitialValue = pointLabelInitialValue;
            this._pointLabelSizeInitialValue = pointLabelSizeInitialValue;
            this._labelVerticalInitialValue = labelVerticalInitialValue;
            this._labelMaxLengthInitialValue = labelMaxLengthInitialValue;
            this._labelSizeInitialValue = labelSizeInitialValue;
            this._view3D2DInitialValue = view3D2DInitialValue;
        }
        #endregion

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
        private const bool DEFAULT_DETAILDISPLAYINITIAL_VALUE = false;
        /// <summary>�|�C���g���x���\�������l</summary>
        private const bool DEFAULT_POINTLABELINITIAL_VALUE = true;
        /// <summary>�|�C���g���x���t�H���g�T�C�Y�����l</summary>
        private const int DEFAULT_POINTLABELSIZEINITIAL_VALUE = 9;
        /// <summary>���x���p�x�����l</summary>
        private const bool DEFAULT_LABELVERTICALINITIAL_VALUE = false;
        /// <summary>���x���ő包�������l</summary>
        private const int DEFAULT_LABELMAXLENGTHINITIAL_VALUE = -1;
        /// <summary>���x���t�H���g�T�C�Y�����l</summary>
        private const int DEFAULT_LABELSIZEINITIAL_VALUE = 9;
        /// <summary>�R�c�^�Q�c�\�������l</summary>
        private const bool DEFAULT_VIEW3D2DINITIAL_VALUE = true;
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
        #endregion
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
            //if (PMKOU04110UA._parameter.Length != 0)
            //{
            //    this._startMode = TStrConv.StrToIntDef(PMKOU04110UA._parameter[0], 0);
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
        #endregion

        #region Public Methods
        /// <summary>
        /// ���̓`���[�g�\���ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���̓`���[�g�\���ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V�@�m��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public void Serialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            // --- ADD 2010/06/28 ---------->>>>>
            //UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
            UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
            // --- ADD 2010/06/28 ----------<<<<<

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
        /// </remarks>
        public void Deserialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            // --- ADD 2010/06/28 ---------->>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))))
            // --- ADD 2010/06/28 ----------<<<<<
            {
                try
                {
                    // --- ADD 2010/06/28 ---------->>>>>
                    //_analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                    _analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                    // --- ADD 2010/06/28 ----------<<<<<
                }
                catch (InvalidOperationException)
                {
                    // --- ADD 2010/06/28 ---------->>>>>
                    //UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                    // --- ADD 2010/06/28 ----------<<<<<
                }
            }
        }
        #endregion
    }

    // --- ADD 2010/06/28 ---------->>>>>
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class TextFileSetting
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
        public TextFileSetting()
        {
            this._supplierFileName = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierfilename"></param>
        public TextFileSetting(string supplierFileName)
        {
            this._supplierFileName = supplierFileName;
        }
        #endregion

        #region Private Member
        /// <summary>�ڍו\�������l</summary>
        private string _supplierFileName;
        #endregion

        #region Propaty
        /// <summary>�ڍו\�������l�v���p�e�B</summary>
        public string SupplierFileName
        {
            get { return this._supplierFileName; }
            set { this._supplierFileName = value; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class TextFileSettingAcs
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
        public TextFileSettingAcs()
        {

            if (_textFileSetting == null)
            {
                _textFileSetting = new TextFileSetting();
            }
            this.Deserialize();
        }
        #endregion

        #region Private Member
        /// <summary>�N�����[�h</summary>
        private int _startMode = 1;
        /// <summary>���̓`���[�g�\���ݒ�N���X</summary>
        private static TextFileSetting _textFileSetting;

        /// <summary>���̓`���[�g�\���ݒ�ۑ��t�@�C������</summary>
        private const string XML_FILE_NAME = "SFANL06500U_ChartSetting?.XML";
        #endregion

        #region Events
        /// <summary>���̓`���[�g�\���ݒ�ύX��C�x���g</summary>
        public static event EventHandler TextFileSettingChanged;
        #endregion

        #region Properties
        /// <summary>�ڍו\�������l�v���p�e�B</summary>
        public string SupplierFileName
        {
            get
            {
                if (_textFileSetting == null)
                {
                    _textFileSetting = new TextFileSetting();
                }
                return _textFileSetting.SupplierFileName;
            }
            set
            {
                if (_textFileSetting == null)
                {
                    _textFileSetting = new TextFileSetting();
                }
                _textFileSetting.SupplierFileName = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        public void Serialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            UserSettingController.SerializeUserSetting(_textFileSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));

            // �󒍌���������ʗp���[�U�[�ݒ�ύX��C�x���g
            if (TextFileSettingChanged != null)
            {
                TextFileSettingChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Deserialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))))
            {
                try
                {
                    _textFileSetting = UserSettingController.DeserializeUserSetting<TextFileSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                }
            }
        }

        // --- ADD 2010/06/28 ----------<<<<<
        #endregion
    }
}