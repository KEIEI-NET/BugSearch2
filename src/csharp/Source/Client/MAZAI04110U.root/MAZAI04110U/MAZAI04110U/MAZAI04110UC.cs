//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌ɏƉ�
// �v���O�����T�v   : �݌ɏƉ� �e�L�X�g�o�͊m�F�t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI �֓� �a�G
// �C �� ��  2012/09/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Common;     // UserSettingController�Ɏg�p
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌ɏƉ� �e�L�X�g�o�͊m�F�t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�͎��Ƀt�@�C�����E�o�̓^�C�v��I������ׂ̂t�h�ł��B</br>
    /// <br>Programmer : FSI �֓� �a�G</br>
    /// <br>Date       : 2012/09/19</br>
    /// </remarks>
    public partial class MAZAI04110UC : Form
    {
        #region �v���C�x�[�g�ϐ�
        // ���[�U�[�ݒ�
        private StockUserConst _userSetting;

        // ��؂蕶��
        private string _divider;

        // �p�^�[��
        private string[] _outputPattern;

        // �I������Ă���p�^�[����
        private string _selectedPattern;
        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B
        /// <summary>
        /// ���[�U�[�ݒ��`
        /// </summary>
        public StockUserConst UserSetting
        {
            get { return this._userSetting; }
            set { this._userSetting = value; }
        }
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MAZAI04110UC()
        {
            InitializeComponent();

            this._userSetting = new StockUserConst();
        }
        #endregion

        #region �v���C�x�[�g�֐�

        /// <summary>
        /// ��ʂ̏����l��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����l��ݒ�B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void setInitialValue()
        {
            // �ݒ�l������΂����ݒu
            if (this._outputPattern == null)
            {
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;
            }
            else
            {
                string pName = string.Empty;
                string[] patternValue = new string[9];

                // �p�^�[���̍\��
                // ��؂蕶��(�^�u�E�C�ӁE�Œ蒷�j/��؂蕶���C��/  0-1
                // ���蕶��(�h�E�C�Ӂj/���蕶���C��/                2-3
                // ���l����i����^���Ȃ�)                          4
                // ��������i����^���Ȃ�)                          5
                // �^�C�g���s�i����^�Ȃ��j                         6
                // �o�͍��ڃ��X�g (35����x4����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��99, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
                // �p�^�[���`��(.CSV/.TXT/.PRN/�J�X�^��)            8

                if (String.IsNullOrEmpty(this._selectedPattern))
                {
                    this._selectedPattern = "�e�L�X�g�o�̓p�^�[��1";
                }

                // �擾�����p�^�[���𕪉����A�p�^�[�����̃��X�g���쐬
                this.tComboEditor_PetternSelect.Items.Clear();
                Infragistics.Win.ValueListItem item;
                foreach (string pattern in this._outputPattern)
                {
                    item = new Infragistics.Win.ValueListItem();
                    
                    // �ŏ��̋�؂蕶���܂ł��p�^�[����
                    if (pattern.Contains(this._divider))
                    {
                        pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                        item.DataValue = pName;
                        item.DisplayText = pName;

                        this.tComboEditor_PetternSelect.Items.Add( item );

                        // �ݒ肳��Ă���p�^�[���̏ꍇ�͓��e���擾
                        if (pName == this._selectedPattern)
                        {
                            getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                        }
                    }
                }

                // �擾���I�������A��ʂ�ݒ肷��

                // �t�@�C����
                this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;

                // �p�^�[����
                this.tComboEditor_PetternSelect.Text = this._selectedPattern;
            }
        }

        /// <summary>
        /// �p�^�[���̓��e�𕪉�
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        /// <remarks>
        /// <br>Note       : �p�^�[���̓��e�𕪉��B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void getPatternValue(string pBody, out string[] pValue)
        {
            const int ct_ItemCount = 11;
            pValue = new string[ct_ItemCount];

            string str1 = pBody;
            string str2 = string.Empty;

            for ( int i = 0; i < ct_ItemCount; i++ )
            {
                if (str1.Contains(this._divider))
                {
                    pValue[i] = str1.Substring(0, str1.IndexOf(this._divider));
                }
                else
                {
                    pValue[i] = str1.Substring(0);
                }
                str2 = str1.Substring(str1.IndexOf(this._divider) + 1);
                str1 = str2;
            }
        }

        /// <summary>
        /// �O���b�h�̃Z�b�e�B���O�𕶎��񂩂���o��
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <param name="isSlip"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃Z�b�e�B���O�𕶎��񂩂���o���B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            int count = patternStr.Length / 4;
            gridSetting = new string[count];

            for ( int i = 0; i < count; i++ )
            {
                gridSetting[i] = patternStr.Substring( i * 4, 4 );
            }
        }

        /// <summary>
        /// �I�����ꂽ�p�^�[����K�p
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�����ꂽ�p�^�[����K�p�B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void getSelectedPattern()
        {
            string pName = string.Empty;
            string[] patternValue = new string[9];

            // �p�^�[���̍\��
            // ��؂蕶��(�^�u�E�C�ӁE�Œ蒷�j/��؂蕶���C��/  0-1
            // ���蕶��(�h�E�C�Ӂj/���蕶���C��/                2-3
            // ���l����i����^���Ȃ�)                          4
            // ��������i����^���Ȃ�)                          5
            // �^�C�g���s�i����^�Ȃ��j                         6
            // �o�͍��ڃ��X�g (35����x4����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��99, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
            // �p�^�[���`��(.CSV/.TXT/.PRN/�J�X�^��)            8

            // �擾�����p�^�[���𕪉����A�p�^�[�����̃��X�g���쐬
            foreach (string pattern in this._outputPattern)
            {
                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));

                    // �ݒ肳��Ă���p�^�[���̏ꍇ�͓��e���擾
                    if (pName == this._selectedPattern)
                    {
                        getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                        break;
                    }
                }
            }

            // �擾���I�������A��ʂ�ݒ肷��

            // �p�^�[����
            this.tComboEditor_PetternSelect.Text = this._selectedPattern;

            // �t�@�C�����֓K�p
            this.OutputStyle_ValueChanged( patternValue[8].ToString() );
        }

        /// <summary>
        /// �o�͌`���ύX
        /// </summary>
        /// <param name="selected"></param>
        /// <remarks>
        /// <br>Note       : �o�͌`���ύX�B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void OutputStyle_ValueChanged( string selected )
        {
            // �I��l
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            // �g���q�ϊ�
            fileName = StockUserConst.ChangeFileExtension(fileName, selected);
            this.tEdit_SettingFileName.Text = fileName;
        }

        /// <summary>
        /// ���͒l�`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���͒l�`�F�b�N�B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private bool checkValues()
        {
            // �t�@�C����
            if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
            {
                // �t�@�C�������w�肳��Ă��Ȃ��ƃG���[
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�o�̓t�@�C�������w�肳��Ă��܂���B", -1, MessageBoxButtons.OK);

                return false;
            }

            // �p�^�[����
            if ( String.IsNullOrEmpty( this.tComboEditor_PetternSelect.Text.Trim() ) ) return false;

            return true;
        }
        #endregion // �v���C�x�[�g�֐�

        #region �C�x���g

        /// <summary>
        /// ��ʋN��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��ʋN���������B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void MAZAI04110UC_Load( object sender, EventArgs e )
        {
            // �p�^�[���E��؂蕶���E�ݒ薼���擾
            if ( this._userSetting != null )
            {
                this._outputPattern = this._userSetting.OutputPattern;
                this._divider = this._userSetting.DIVIDER;
                this._selectedPattern = this._userSetting.SelectedPatternName;
            }

            // �{�^���ݒ�
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // ��ʂ̏����l���Z�b�g
            setInitialValue();

            // ValueChanged�C�x���g�ŏ����ς�����t�@�C������߂�
            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
        }

        /// <summary>
        /// �p�^�[���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �p�^�[���ύX�B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void tComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if ( tComboEditor_PetternSelect.SelectedItem != null )
            {
                this._selectedPattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();
                getSelectedPattern();
            }
        }

        /// <summary>
        /// �p�^�[���e�L�X�g�ύX���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �p�^�[���e�L�X�g�ύX���C�x���g�����B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void tComboEditor_PetternSelect_ValueChanged( object sender, EventArgs e )
        {
            if ( tComboEditor_PetternSelect.SelectedItem != null )
            {
                // �����̃p�^�[��
                this.tComboEditor_PetternSelect_SelectionChangeCommitted( sender, e );
            }
            else
            {
                // �V�K�p�^�[��
            }
        }
        /// <summary>
        /// �ݒ�t�h�����\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ݒ�t�h�����\���C�x���g�����B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void MAZAI04110UB_Shown( object sender, EventArgs e )
        {
            tEdit_SettingFileName.Focus();
        }
        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g�����B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// <br></br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null || e.NextCtrl == null ) return;

            switch ( e.PrevCtrl.Name )
            {
                case "tEdit_SettingFileName":
                    {
                        # region [���t�H�[�J�X]
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( !string.IsNullOrEmpty( tEdit_SettingFileName.Text ) )
                                        {
                                            // ������
                                            e.NextCtrl = tComboEditor_PetternSelect;
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
                            switch ( e.Key )
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
                case "uButton_FileSelect":
                    break;
                case "tComboEditor_PetternSelect":
                    break;
                case "uButton_OK":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        // �{�^������
                                        uButton_OK_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Cancel":
                    if ( !e.ShiftKey )
                    {
                        switch ( e.Key )
                        {
                            case Keys.Return:
                                {
                                    // �{�^������
                                    uButton_Cancel_Click( this, new EventArgs() );
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
        #endregion // �C�x���g

        #region �{�^��

        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �L�����Z���{�^���B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OK�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : OK�{�^���B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // �`�F�b�N
            if (!checkValues())
            {
                return;
            }

            // �t�@�C����
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            // �p�^�[����
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();

            this.DialogResult = DialogResult.OK;

            // �I��
            this.Close();
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�@�C���_�C�A���O�\���B</br>
        /// <br>Programmer : FSI �֓� �a�G</br>
        /// <br>Date       : 2012/09/19</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        #endregion // �{�^��

    }
}