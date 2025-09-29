using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Broadleaf.Application.Resources;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PM.NS�T�|�[�g�c�[���N�����j���[
    /// </summary>
    /// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer	: 23003 enokida</br>
    /// <br>Date        : 2014.09.08</br>
    /// </remarks>
    public partial class PMKHN00800UA : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PMKHN00800UA()
        {
            InitializeComponent();
        }

        #region Private Members
        /// <summary> �O���b�h�p�f�[�^�Z�b�g </summary>
        private DataSet _dataset = null;
        /// <summary> �N���c�[�����X�g�t�@�C���t���p�X </summary>
        private string filePath = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, "PMKHN00800UA_ToolList.xml");

        /// <summary> �J�������F�c�[������ </summary>
        private const string COL_TOOLNAME = "toolName";
        /// <summary> �J�������F�A�Z���u��ID </summary>
        private const string COL_TOOLASMID = "assemblyID";
        /// <summary> �J�������F�N���X�� </summary>
        private const string COL_TOOLCLASSID = "className";
        /// <summary> �J�������F���\�b�h�� </summary>
        private const string COL_TOOLMETHOD = "methodName";
        /// <summary> �J�������F�N���{�^�� </summary>
        private const string COL_TOOLBOOTBTN = "bootBtn";

            #endregion

        #region Event Methods

        /// <summary>
        /// �t�H�[���Ǎ��݃C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN00800UA_Load(object sender, EventArgs e)
        {
            // XML�Ǎ��ݏ���
            string errMsg = string.Empty;
            int status = ReadToolListXML(out errMsg);

            if (status == 0)
            {
                // ��ʏ����ݒ�
                InitializeDisplaySetting();
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    errMsg,
                    status,
                    MessageBoxButtons.OK);

                this.Close();
            }

        }

        /// <summary>
        /// �O���b�h���{�^���Z���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supportTool_uGrid_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; // �J�[�\����ҋ@���ɂ���

                // �N���{�^�����N���b�N���ꂽ�ꍇ
                if (e.Cell.Column.Key == COL_TOOLBOOTBTN)
                {
                    string asmid = (string)e.Cell.Row.Cells[COL_TOOLASMID].Value; // �A�Z���u��ID�擾
                    string classid = (string)e.Cell.Row.Cells[COL_TOOLCLASSID].Value; // �N���X���擾                
                    string extension = System.IO.Path.GetExtension(asmid); // �g���q�擾
                    string methodnm = (string)e.Cell.Row.Cells[COL_TOOLMETHOD].Value; // ���\�b�h���擾

                    AsmInvoked(asmid, classid, extension, methodnm);

                }

            }
            catch (FileNotFoundException)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    "�w�肳�ꂽ�t�@�C����������܂���B",
                    -1,
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �O���b�h���L�[��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supportTool_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // �X�y�[�X�L�[�����������ꍇ�A�O���b�h���{�^���Z���N���b�N�����Ɠ������������܂�
                if ((e.KeyCode == Keys.Space) && (this.supportTool_uGrid.ActiveRow != null))
                {
                    this.Cursor = Cursors.WaitCursor; // �J�[�\����ҋ@���ɂ���

                    string asmid = (string)this.supportTool_uGrid.ActiveRow.Cells[COL_TOOLASMID].Value; // �A�Z���u��ID�擾
                    string classid = (string)this.supportTool_uGrid.ActiveRow.Cells[COL_TOOLCLASSID].Value; // �N���X���擾                
                    string extension = System.IO.Path.GetExtension(asmid); // �g���q�擾
                    string methodnm = (string)this.supportTool_uGrid.ActiveRow.Cells[COL_TOOLMETHOD].Value; // ���\�b�h���擾

                    AsmInvoked(asmid, classid, extension, methodnm);

                }
            }
            catch (FileNotFoundException)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    "�w�肳�ꂽ�t�@�C����������܂���B",
                    -1,
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// �t�H�[�J�X�J�ڃC�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

        }

        /// <summary>
        /// ����{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_uButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// �c�[�����X�gXML�Ǎ��ݏ���
        /// </summary>
        /// <returns>�X�e�[�^�X[0:����A-1:�G���[�A2:�t�@�C���`�F�b�N�G���[]</returns>
        /// <param name="errMsg">���b�Z�[�W</param>
        private int ReadToolListXML(out string errMsg)
        {
            int status = 0;
            errMsg = string.Empty;
            try
            {
                // �t�@�C�����݃`�F�b�N
                if (!File.Exists(filePath))
                {
                    errMsg = "�ݒ�t�@�C��������܂���B";
                    return -1;
                }

                // XML�f�[�^�� DataSet�ɓǂݍ��݂܂�
                _dataset = new DataSet();
                _dataset.ReadXml(filePath);
            }
            catch (Exception ex)
            {
                errMsg = "�ݒ�t�@�C�������Ă��܂��B\r\n" + ex.Message;
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// ��ʏ����ݒ�
        /// </summary>
        private void InitializeDisplaySetting()
        {
            try
            {
                // �O���b�h�Ƀf�[�^���o�C���h
                supportTool_uGrid.DataSource = _dataset;
                supportTool_uGrid.DataMember = "ToolList";

                // �O���b�h�����ݒ�
                GridInitialSetting();

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);

                this.Hide();
            }
        }

        /// <summary>
        /// �O���b�h�����ݒ�
        /// </summary>
        private void GridInitialSetting()
        {
            // --- �O���b�h�O�ϐݒ� --- //

            #region --- �O���b�h�O�ϐݒ� ---
            // GroupByBox���\��
            this.supportTool_uGrid.DisplayLayout.GroupByBox.Hidden = true;
            // �O���b�h�S�̂̊O�ϐݒ�
            this.supportTool_uGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.supportTool_uGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.supportTool_uGrid.DisplayLayout.Appearance.BackGradientStyle = GradientStyle.Vertical;
            // �t�H���g�T�C�Y
            this.supportTool_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints = 14;

            // �s�����I��ݒ�
            this.supportTool_uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            // �s�̃T�C�Y�ύX�s��
            this.supportTool_uGrid.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
            // �񕡐��I��ݒ�
            this.supportTool_uGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            // �񕝂̎�������
            this.supportTool_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            // �s�̒ǉ��s��
            this.supportTool_uGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            // �s�̍폜�s��
            this.supportTool_uGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            // ��̈ړ��s��
            this.supportTool_uGrid.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            this.supportTool_uGrid.DisplayLayout.Override.AllowColSizing = AllowColSizing.None;
            // ��̌����s��
            this.supportTool_uGrid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            this.supportTool_uGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False;
            // IME����
            this.supportTool_uGrid.ImeMode = ImeMode.Disable;
            // HeaderSort��ǉ�
            this.supportTool_uGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            // �^�C�g���̊O�ϐݒ�
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.supportTool_uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Alpha.Transparent;
            // �s�Z���N�^�̊O�ϐݒ�
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;
            // �݂��Ⴂ�̍s�̐F��ύX
            this.supportTool_uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�\���L��
            this.supportTool_uGrid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            // �X�N���[���o�[�\��
            this.supportTool_uGrid.DisplayLayout.Scrollbars = Scrollbars.Vertical;
            this.supportTool_uGrid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            // �A�N�e�B�u�s�̊O�ϐݒ�
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.White;
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(251, 230, 148);
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.supportTool_uGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            // �����ʒu�i�c�j�̐ݒ�
            this.supportTool_uGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = VAlign.Middle;
            this.supportTool_uGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = VAlign.Middle;
            this.supportTool_uGrid.DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            // �s�Ԃ̌r���F�̐ݒ�
            this.supportTool_uGrid.DisplayLayout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68, 208);
            // �ҏW���̐F�̐ݒ�
            this.supportTool_uGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            // �}�E�X�|�C���^�̃J�[�\���`��
            this.supportTool_uGrid.Cursor = Cursors.Arrow;
            // �X�N���[���`�b�v���\��
            this.supportTool_uGrid.DisplayLayout.Override.TipStyleScroll = TipStyle.Hide;


            #endregion

            // --- �O���b�h�J�������ݒ� --- //
            
            // �O���b�h�̃J�������擾
            ColumnsCollection columns = this.supportTool_uGrid.DisplayLayout.Bands[0].Columns;
            // ��U���ׂĂ̗���\���ɐݒ肷��
            foreach (UltraGridColumn col in columns)
            {
                col.Hidden = true;
            }

            // �c�[�����itoolname�j
            columns[COL_TOOLNAME].Header.Caption = "�T�|�[�g�c�[����";
            columns[COL_TOOLNAME].Hidden = false;
            columns[COL_TOOLNAME].CellActivation = Activation.NoEdit;

            // �c�[��PGID
            columns[COL_TOOLASMID].Header.Caption = "PGID";
            columns[COL_TOOLASMID].Hidden = true;
            columns[COL_TOOLASMID].CellActivation = Activation.NoEdit;

            // �c�[���N���XID
            columns[COL_TOOLCLASSID].Header.Caption = "CLASSID";
            columns[COL_TOOLCLASSID].Hidden = true;
            columns[COL_TOOLCLASSID].CellActivation = Activation.NoEdit;

            // �c�[�����\�b�h
            columns[COL_TOOLMETHOD].Header.Caption = "METHOD";
            columns[COL_TOOLMETHOD].Hidden = true;
            columns[COL_TOOLMETHOD].CellActivation = Activation.NoEdit;

            // ����s�̃{�^�����������s���Ăł��Ȃ��̂��ȁE�E�E

            // �N���{�^��
            columns[COL_TOOLBOOTBTN].Header.Caption = "�N��";
            columns[COL_TOOLBOOTBTN].Hidden = false;
            columns[COL_TOOLBOOTBTN].CellActivation = Activation.NoEdit;
            columns[COL_TOOLBOOTBTN].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[COL_TOOLBOOTBTN].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[COL_TOOLBOOTBTN].CellButtonAppearance.ForeColorDisabled = Color.OrangeRed;
            columns[COL_TOOLBOOTBTN].Width = 10;
            columns[COL_TOOLBOOTBTN].CellButtonAppearance.TextHAlign = HAlign.Center;
            columns[COL_TOOLBOOTBTN].CellButtonAppearance.TextVAlign = VAlign.Middle;

        }

        /// <summary>
        /// �A�Z���u���N��
        /// </summary>
        /// <param name="asmid">�A�Z���u��ID</param>
        /// <param name="classid">�N���X��</param>
        /// <param name="extension">�g���q</param>
        /// <param name="methodnm">���\�b�h��</param>
        private void AsmInvoked(string asmid, string classid, string extension, string methodnm)
        {

            switch (extension)
            {
                case ".exe":
                case ".EXE":
                    {
                        StringBuilder arguments = new StringBuilder();
                        // ���O�C���p�����[�^���擾
                        Broadleaf.Application.Common.ApplicationStartControl applicationStartControl = new Broadleaf.Application.Common.ApplicationStartControl();
                        string[] loginArguments = applicationStartControl.Parameters;
                        foreach (string argument in loginArguments)
                        {
                            if (argument.Trim() != string.Empty)
                            {
                                arguments.Append(argument + " ");
                            }
                        }

                        // �N���p�����[�^��ݒ�@���ɂȂ��H�@
                        //arguments.Append(�@);

                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = asmid;
                        proc.StartInfo.Arguments = arguments.ToString(); //�R�}���h���C������

                        // exe�N��
                        proc.Start();
                        break;
                    }
                case ".dll":
                case ".DLL":
                    {

                        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(asmid);
                        Type type = assembly.GetType(classid);
                        if (type != null)
                        {
                            object obj = Activator.CreateInstance(type);
                            if (methodnm != string.Empty)
                            {
                                //System.Reflection.MethodInfo myMethod = type.GetMethod(methodnm);
                                //myMethod.Invoke(obj, null); // �p�����[�^�Ȃ�

                                type.InvokeMember(methodnm, System.Reflection.BindingFlags.InvokeMethod, null, obj, null); // �p�����[�^�Ȃ�
                            }
                            else
                            {
                                Form form = obj as Form;
                                form.Show();
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion








    }
}