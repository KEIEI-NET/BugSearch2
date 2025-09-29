//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉړ��d�q����
// �v���O�����T�v   : �݌Ɉړ��d�q���� ����ݒ�t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : tianjw
// �� �� ��  2011/05/11  �C�����e : redmine #20955,#29951
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/05/25  �C�����e : redmine #21703�A#21718
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/05/26  �C�����e : redmine #21752
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/05/27  �C�����e : redmine #21703�C#21794
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
    /// �݌Ɉړ��d�q���� ����ݒ�t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��d�q���� ����ݒ�t�h�N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br>Update Note: 2011/05/11 tianjw</br>
    /// <br>             redmine #20955,#29951</br>
    /// <br></br>
    /// </remarks>
    public partial class PMZAI04604UA : Form
    {
        /// <summary>
        /// �ݒ�t�@�C����̗�ԍ���3���[���l��
        /// </summary>
        static public readonly int ct_ColumnCountLength = 3;
        # region const
        // �p�^�[���폜�m�F���b�Z�[�W
        private const string MSG_CONFIRM_DELETE_PATTERN = "�I�𒆂̏o�̓p�^�[�����폜���Ă�낵���ł����H";

        // �p�^�[�������̓��b�Z�[�W
        private const string MSG_OUTPUTTEXT_NOPATTERN = "�o�̓p�^�[������͂��ĉ�����";


        # endregion

        # region event
        /// <summary>�`�[�O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingStockMoveGrid;

        # endregion

        #region �v���C�x�[�g�ϐ�

        // �ݒ�ۑ��p���ʃI�u�W�F�N�g

        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMZAI04600U_Construction.XML";

        // �f�[�^�Z�b�g
        private StockMoveDetailDataSet _stockMoveDataSet;
        private int prevDividerChar;
        private int prevParenthesis;
        private int prevTieNumeric;
        private int prevTieChar;
        private int prevTitleLine;

        // ���[�U�[�ݒ�
        private StockMoveUserConst _userSetting;

        // ��؂蕶��
        private string _divider;

        // �p�^�[��
        private string[] _outputPattern;

        // �I������Ă���p�^�[����
        private string _selectedPattern;

        // �`�[�O���b�h�̐ݒ�
        private string _gridSetting_Slip = string.Empty;

        // �`�[����index�f�B�N�V���i��
        private Dictionary<string, int> _columnIndexDicOfSlip;
        // �`�[�O���b�h�J�����E�R���N�V����
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _slipColCollection;
        // �t�H�[�J�X����
        private FocusControl _focusControl1;
        // �O���b�h�E�J�����`���[�U�[����
        GridColumnChooserControl _gridColumnChooserControl;

        private bool _dividerCharClearFlg = true; // ADD 2011/05/25
        private bool _parenthesisClearFlg = true; // ADD 2011/05/25

        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B

        /// <summary>
        /// �݌Ɉړ��d�q�������[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>�݌Ɉړ��d�q�������[�U�[�ݒ���N���X</returns>
        public StockMoveUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>
        /// �`�[�O���b�h�J�����E�R���N�V���� 
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection SlipColCollection
        {
            get { return _slipColCollection; }
            set { _slipColCollection = value; }
        }

        /// <summary>
        /// ��؂蕶��
        /// </summary>
        private int DividerChar
        {
            get
            {
                if (rb_DividerChar_0.Checked)
                {
                    return 0;
                }
                else if (rb_DividerChar_1.Checked)
                {
                    return 1;
                }
                else if (rb_DividerChar_2.Checked)
                {
                    return 2;
                }
                else
                {
                    rb_DividerChar_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        rb_DividerChar_0.Checked = true;
                        tEdit_DividerChar.Enabled = false;
                        break;
                    case 1:
                        rb_DividerChar_1.Checked = true;
                        tEdit_DividerChar.Enabled = true;
                        break;
                    case 2:
                        rb_DividerChar_2.Checked = true;
                        tEdit_DividerChar.Enabled = false;
                        break;
                }
            }
        }
        /// <summary>
        /// ���蕶��
        /// </summary>
        private int Parenthesis
        {
            get
            {
                if (rb_Parenthesis_0.Checked)
                {
                    return 0;
                }
                else if (rb_Parenthesis_1.Checked)
                {
                    return 1;
                }
                else
                {
                    rb_Parenthesis_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        rb_Parenthesis_0.Checked = true;
                        tEdit_ParenthesisChar.Enabled = false;
                        break;
                    case 1:
                        rb_Parenthesis_1.Checked = true;
                        tEdit_ParenthesisChar.Enabled = true;
                        break;
                }
            }
        }
        /// <summary>
        /// ���l����
        /// </summary>
        private int TieNumeric
        {
            get
            {
                if (rb_TieNumeric_0.Checked)
                {
                    return 0;
                }
                else if (rb_TieNumeric_1.Checked)
                {
                    return 1;
                }
                else
                {
                    rb_TieNumeric_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        rb_TieNumeric_0.Checked = true;
                        break;
                    case 1:
                        rb_TieNumeric_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        private int TieChar
        {
            get
            {
                if (rb_TieChar_0.Checked)
                {
                    return 0;
                }
                else if (rb_TieChar_1.Checked)
                {
                    return 1;
                }
                else
                {
                    rb_TieChar_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        rb_TieChar_0.Checked = true;
                        break;
                    case 1:
                        rb_TieChar_1.Checked = true;
                        break;
                }
            }
        }
        /// <summary>
        /// �^�C�g���s
        /// </summary>
        private int TitleLine
        {
            get
            {
                if (rb_TitleLine_0.Checked)
                {
                    return 0;
                }
                else if (rb_TitleLine_1.Checked)
                {
                    return 1;
                }
                else
                {
                    rb_TitleLine_0.Checked = true;
                    return 0;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case 0:
                        rb_TitleLine_0.Checked = true;
                        break;
                    case 1:
                        rb_TitleLine_1.Checked = true;
                        break;
                }
            }
        }

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public PMZAI04604UA()
        {
            InitializeComponent();

            this._stockMoveDataSet = new StockMoveDetailDataSet();

            // �`�[����index
            _columnIndexDicOfSlip = new Dictionary<string, int>();
            for (int index = 0; index < _stockMoveDataSet.StockMoveDetail.Columns.Count; index++)
            {
                _columnIndexDicOfSlip.Add(_stockMoveDataSet.StockMoveDetail.Columns[index].ColumnName, index);
            }

            this._userSetting = new StockMoveUserConst();

            // �t�H�[�J�X����(�e�L�X�g�o�͐ݒ�^�u)
            _focusControl1 = new FocusControl();
            _focusControl1.AddLine(tComboEditor_OutputStyle);
            _focusControl1.AddLine(rb_DividerChar_0, rb_DividerChar_1, tEdit_DividerChar, rb_DividerChar_2);
            _focusControl1.AddLine(rb_Parenthesis_0, rb_Parenthesis_1, tEdit_ParenthesisChar);
            _focusControl1.AddLine(rb_TieNumeric_0, rb_TieNumeric_1);
            _focusControl1.AddLine(rb_TieChar_0, rb_TieChar_1);
            _focusControl1.AddLine(rb_TitleLine_0, rb_TitleLine_1);

            _gridColumnChooserControl = new GridColumnChooserControl();
            _gridColumnChooserControl.Add(uGrid_ColumnItemSelector);

        }
        /// <summary>
        /// �`�[����index�擾����
        /// </summary>
        /// <param name="patterns"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �`�[����index�擾�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private int GetColumnPositionOfSlip(string[] patterns, string columnName)
        {
            if (_columnIndexDicOfSlip.ContainsKey(columnName))
            {
                try
                {
                    return Int32.Parse(patterns[_columnIndexDicOfSlip[columnName]].ToString());
                }
                catch
                {
                    return _columnIndexDicOfSlip.Count + 1;
                }
            }
            else
            {
                return _columnIndexDicOfSlip.Count + 1;
            }
        }

        /// <summary>
        /// ��ʋN��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��ʋN���������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04604UA_Load(object sender, EventArgs e)
        {

            // �O���b�h���Ɏg�p����f�[�^�r���[���쐬
            DataView dViewStockMove = new DataView(this._stockMoveDataSet.StockMoveDetail);


            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_ColumnItemSelector.DataSource = dViewStockMove;

            // �ݒ�l������΃��[�h
            this._userSetting = new StockMoveUserConst();
            InitializeUserSetting(ref _userSetting);
            this.Deserialize();

            // �p�^�[���E��؂蕶���E�ݒ薼���擾
            if (this._userSetting != null)
            {
                this._outputPattern = this._userSetting.OutputPattern;
                this._divider = this._userSetting.DIVIDER;
                this._selectedPattern = this._userSetting.SelectedPatternName;
            }

            // �J����
            InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns);

            // �{�^���ݒ�
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // ��{�p�^�[�����쐬
            if (_userSetting == null ||
                _userSetting.OutputPattern == null ||
                _userSetting.OutputPattern.Length == 0)
            {
                string tempName = string.Empty;
                createPatternStringNonCustom(0, out tempName, true);
                createPatternStringNonCustom(1, out tempName, true);
                createPatternStringNonCustom(2, out tempName, true);
            }

            // ��ʂ̏����l���Z�b�g
            setInitialValue();

            // ��ʂ̏����ݒ�
            this.tComboEditor_OutputStyle_ValueChanged(null, null);

            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
            //�\���X�V

            // ��؂蕶���C��
            if (prevDividerChar == 1)
            {
                this.tEdit_DividerChar.Enabled = true;
            }
            else
            {
                this.tEdit_DividerChar.Enabled = false;
                this.tEdit_DividerChar.Clear();
            }
            // ���蕶���C��
            if (prevParenthesis == 1)
            {
                this.tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                this.tEdit_ParenthesisChar.Enabled = false;
                this.tEdit_ParenthesisChar.Clear();
            }
        }

        /// <summary>
        /// ���[�U�[�ݒ菉��������
        /// </summary>
        /// <param name="userSetting"></param>
        /// <remarks>
        /// <br>Note       : ���[�U�[�ݒ菉���������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeUserSetting(ref StockMoveUserConst userSetting)
        {
            userSetting = new StockMoveUserConst();
            InitializeStockMoveGrid(ref userSetting);
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i�`�[�\���j
        /// </summary>
        /// <param name="userSetting"></param>
        /// <remarks>
        /// <br>Note       : ���[�U�[�ݒ菉�����i�`�[�\���j�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeStockMoveGrid(ref StockMoveUserConst userSetting)
        {
            userSetting.StockMoveColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustStockMove = false;
        }

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�֐�

        /// <summary>
        /// ��ʂ̏����l��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����l��ݒ�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void setInitialValue()
        {
            // �ݒ�l������΂����ݒu
            if (this._outputPattern == null)
            {
                this.tEdit_DividerChar.Clear();
                this.tEdit_ParenthesisChar.Clear();
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;

                this.tComboEditor_OutputStyle.SelectedIndex = 0;
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
                // �`�[�o�͍��ڃ��X�g (32����x2����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��99, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
                // ���׏o�͍��ڃ��X�g (57����x2����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��99, �K��ExportColumnDataSet.SalesDetail�̏��ɕ���ł��� 8
                // �p�^�[���`��(.CSV/.TXT/.PRN/�J�X�^��)            9

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

                        this.tComboEditor_PetternSelect.Items.Add(item);

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

                // �t�h�\��
                SetDisplayFromPattern(patternValue);
            }
        }

        /// <summary>
        /// �p�^�[���̓��e�𕪉�
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        /// <remarks>
        /// <br>Note       : �p�^�[���̓��e�𕪉��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void getPatternValue(string pBody, out string[] pValue)
        {
            const int ct_ItemCount = 10;
            pValue = new string[ct_ItemCount];

            string str1 = pBody;
            string str2 = string.Empty;

            for (int i = 0; i < ct_ItemCount; i++)
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            int count = patternStr.Length / (ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for (int i = 0; i < count; i++)
            {
                gridSetting[i] = patternStr.Substring(i * (ct_ColumnCountLength + 1), (ct_ColumnCountLength + 1));
            }
        }

        /// <summary>
        /// �I�����ꂽ�p�^�[����K�p
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�����ꂽ�p�^�[����K�p�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
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
            // �`�[�o�͍��ڃ��X�g (32����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
            // ���׏o�͍��ڃ��X�g (57����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesDetail�̏��ɕ���ł��� 8
            // �p�^�[���`��(.CSV/.TXT/.PRN/�J�X�^��)            9

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

            // �t�h�\��
            SetDisplayFromPattern(patternValue);
        }

        /// <summary>
        /// SetDisplayFromPattern
        /// </summary>
        /// <param name="patternValue"></param>
        /// <remarks>
        /// <br>Note       : SetDisplayFromPattern�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SetDisplayFromPattern(string[] patternValue)
        {
            try
            {
                // �o�͌`��
                this.tComboEditor_OutputStyle.SelectedIndex = Int32.Parse(patternValue[8].ToString());

                // ��؂蕶��
                this.DividerChar = Int32.Parse(patternValue[0].ToString());
                prevDividerChar = this.DividerChar;
                // ��؂蕶���C��
                this.tEdit_DividerChar.Text = patternValue[1].ToString();
                if (prevDividerChar == 1)
                {
                    this.tEdit_DividerChar.Enabled = true;
                }
                else
                {
                    this.tEdit_DividerChar.Enabled = false;
                    this.tEdit_DividerChar.Clear();
                }

                // ���蕶��
                this.Parenthesis = Int32.Parse(patternValue[2].ToString());
                prevParenthesis = this.Parenthesis;
                // ���蕶���C��
                this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();
                if (prevParenthesis == 1)
                {
                    this.tEdit_ParenthesisChar.Enabled = true;
                }
                else
                {
                    this.tEdit_ParenthesisChar.Enabled = false;
                    this.tEdit_ParenthesisChar.Clear();
                }

                // ���l����
                this.TieNumeric = Int32.Parse(patternValue[4].ToString());
                prevTieNumeric = this.TieNumeric;
                // ��������
                this.TieChar = Int32.Parse(patternValue[5].ToString());
                prevTieChar = this.TieChar;

                // �^�C�g���s
                this.TitleLine = Int32.Parse(patternValue[6].ToString());
                prevTitleLine = this.TitleLine;

                // �O���b�h
                this._gridSetting_Slip = patternValue[7].ToString();

                // �J�����ݒ�
                InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns);
            }
            catch
            {
            }

        }

        /// <summary>
        /// �f�[�^�O���b�h�Z�b�g
        /// </summary>
        /// <param name="Columns"></param>
        /// <remarks>
        /// <br>Note       : �f�[�^�O���b�h�Z�b�g�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // �\���ʒu�����l
            int visiblePosition = 1;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            string[] gridPattern = new string[0];
            if (!string.IsNullOrEmpty(_gridSetting_Slip))
            {
                getGridSettingPattern(this._gridSetting_Slip, out gridPattern, true);
            }

            int position = 0;


            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _slipColCollection)
            {
                // �I��p�̃`�F�b�N�{�b�N�X�͏��O
                if (orgCol.Key == _stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName) continue;

                // �J�����`���[�U���珜�O����Ă��鍀�ڂ͓�������p�Ƃ݂Ȃ��ď��O
                if (orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True) continue;

                // ���J��������R�s�[
                Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                // �l�Z�b�g
                Columns[orgCol.Key].Hidden = false;
                Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                if (!string.IsNullOrEmpty(_gridSetting_Slip))
                {
                    int hiddenFlag = (int)Math.Pow(10, ct_ColumnCountLength);

                    // �ݒ肠��
                    position = GetColumnPositionOfSlip(gridPattern, orgCol.Key);
                    if (position >= hiddenFlag)
                    {
                        Columns[orgCol.Key].Hidden = true;
                        Columns[orgCol.Key].Header.VisiblePosition = position - hiddenFlag;
                    }
                    else
                    {
                        Columns[orgCol.Key].Hidden = false;
                        Columns[orgCol.Key].Header.VisiblePosition = position;
                    }
                }
                else
                {
                    // �ݒ�Ȃ�
                    Columns[orgCol.Key].Hidden = false;
                    Columns[orgCol.Key].Header.VisiblePosition = position++;
                }
            }

            #region �J�����`���[�U�ݒ�

            //--------------------------------------------------------------------------------
            //  �J�����`���[�U��L���ɂ���
            //--------------------------------------------------------------------------------
            this.uGrid_ColumnItemSelector.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorWidth = 24;

            // �J�����`���[�U�{�^���̊O�ς�ݒ�
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
            this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            #endregion // �J�����`���[�U�ݒ�

            // �񕝎���������ݒ�l�ɂ��������čs��
            autoColumnAdjust(false);

            // �O�ϐݒ�
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;


        }

        /// <summary>
        /// �񕝎�������
        /// </summary>
        /// <param name="autoAdjust">�����������邩�ǂ���</param>
        /// <remarks>
        /// <br>Note       : �񕝎��������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
        {
            // ���������v���p�e�B�𒲐�
            if (autoAdjust)
            {
                this.uGrid_ColumnItemSelector.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_ColumnItemSelector.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }
            // �S�Ă̗�ŃT�C�Y����
            for (int i = 0; i < this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns.Count; i++)
            {
            	if (this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].Hidden) continue;
                this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
        }

        /// <summary>
        /// ���͒l�`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���͒l�`�F�b�N�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool checkValues()
        {
            // �p�^�[����
            if (String.IsNullOrEmpty(this.tComboEditor_PetternSelect.Text.Trim()))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOPATTERN, -1, MessageBoxButtons.OK);
                this.tComboEditor_PetternSelect.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// �p�^�[�����X�V
        /// </summary>
        /// <remarks>
        /// <br>Note       : �p�^�[�����X�V�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: Redmine #21794</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/05/27</br>
        /// <br></br>
        /// </remarks>
        private void renewalOutputPattern(bool isDelete)
        {
            if (!isDelete)
            {
                // ���O
                string selectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();
                string value01 = this.DividerChar.ToString();
                //string value02 = this.tEdit_DividerChar.Text.Trim(); // DEL 2011/05/27
                string value02 = this.tEdit_DividerChar.Text;// ADD 2011/05/27
                string value03 = this.Parenthesis.ToString();
                //string value04 = this.tEdit_ParenthesisChar.Text.Trim();// DEL 2011/05/27
                string value04 = this.tEdit_ParenthesisChar.Text;// ADD 2011/05/27
                string value05 = this.TieNumeric.ToString();
                string value06 = this.TieChar.ToString();
                string value07 = this.TitleLine.ToString();

                // �O���b�h����ݒ�l���擾
                string value08 = string.Empty;
                createGridPatternString(out value08);
                string value09 = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();

                // �S�ĘA��
                string convinedStr = selectedPatternName + this._divider +
                        value01 + this._divider + value02 + this._divider +
                        value03 + this._divider + value04 + this._divider +
                        value05 + this._divider + value06 + this._divider +
                        value07 + this._divider + value08 + this._divider +
                        value09 + this._divider;
                string[] newOutputPattern;

                if (this._outputPattern == null)
                {
                    newOutputPattern = new string[1];
                    newOutputPattern[0] = convinedStr;
                }
                else
                {
                    bool exists = false;
                    string pName = string.Empty;
                    int count = 0;

                    // �����łȂ�������
                    foreach (string pattern in this._outputPattern)
                    {
                        // �ŏ��̋�؂蕶���܂ł��p�^�[����
                        if (pattern.Contains(this._divider))
                        {
                            pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                            if (pName == selectedPatternName)
                            {
                                this._outputPattern[count] = convinedStr;
                                exists = true;
                                break;
                            }
                        }
                        count++;
                    }

                    if (exists)
                    {
                        // �X�V
                        this._userSetting.OutputPattern = this._outputPattern;
                    }
                    else
                    {
                        newOutputPattern = new string[this._outputPattern.Length + 1];
                        count = 0;
                        foreach (string pattern in _outputPattern)
                        {
                            newOutputPattern[count] = pattern;
                            count++;
                        }
                        newOutputPattern[count] = convinedStr;

                        // �ǉ�
                        this._userSetting.OutputPattern = newOutputPattern;
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h�̐ݒ�𕶎���ɕϊ�
        /// </summary>
        /// <param name="patternString"></param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̐ݒ�𕶎���ɕϊ��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void createGridPatternString(out string patternString)
        {
            patternString = string.Empty;

            Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
            string[] gridHeaderPattern = new string[col.Count];
            int visiblePosition = 0;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
            {
                if (_columnIndexDicOfSlip.ContainsKey(column.Key))
                {
                    if (column.Hidden)
                    {
                        gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + visiblePosition.ToString().PadLeft(ct_ColumnCountLength, '0');
                    }
                    else
                    {
                        gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + visiblePosition.ToString().PadLeft(ct_ColumnCountLength, '0');
                    }
                    visiblePosition++;
                }
            }

            // ��̏��ɕ��Ԃ悤�ɕ�������쐬�i���Ԃ��قȂ�Ɛ���ɏC���ł��Ȃ��j
            for (int i = 0; i < col.Count; i++)
            {
                patternString = patternString + gridHeaderPattern[i];
            }
        }

        /// <summary>
        /// ��{�p�^�[����ǉ�
        /// </summary>
        /// <param name="outputStyle"></param>
        /// <param name="patternString"></param>
        /// <param name="addPattern"></param>
        /// <remarks>
        /// <br>Note       : ��{�p�^�[����ǉ��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void createPatternStringNonCustom(int outputStyle, out string patternString, bool addPattern)
        {

            patternString = string.Empty;
            string selectedPatternName = string.Empty;
            string value01 = string.Empty;
            string value02 = string.Empty;
            string value03 = string.Empty;
            string value04 = string.Empty;
            string value05 = string.Empty;
            string value06 = string.Empty;
            string value07 = string.Empty;
            string value08 = string.Empty;
            string value09 = string.Empty;
            string value10 = string.Empty;


            switch (outputStyle)
            {
                case 0:
                    {
                        selectedPatternName = "�e�L�X�g�o�̓p�^�[��1";
                        value01 = "1";
                        value02 = ",";
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        value07 = "0";

                        value08 = string.Empty;

                        value09 = "0";

                        value10 = "1";

                        break;
                    }
                case 1:
                    {
                        selectedPatternName = "�e�L�X�g�o�̓p�^�[��2";
                        value01 = "0";
                        value02 = string.Empty;
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";
                        value07 = "0";

                        value08 = string.Empty;

                        value09 = "1";

                        value10 = "1";

                        break;
                    }
                case 2:
                    {
                        selectedPatternName = "�e�L�X�g�o�̓p�^�[��3";
                        value01 = "1";
                        value02 = " ";
                        value03 = "0";
                        value04 = string.Empty;
                        value05 = "0";
                        value06 = "0";

                        value07 = "0";

                        value08 = string.Empty;

                        value09 = "2";

                        value10 = "1";

                        break;
                    }

                default: break;
            }
            patternString = selectedPatternName + this._divider +
                value01 + this._divider + value02 + this._divider +
                value03 + this._divider + value04 + this._divider +
                value05 + this._divider + value06 + this._divider +
                value07 + this._divider + value08 + this._divider +

                value09 + this._divider + value10;

            if (addPattern)
            {

                string[] newOutputPattern;

                if (this._outputPattern == null)
                {
                    newOutputPattern = new string[1];
                    newOutputPattern[0] = patternString;
                    this._outputPattern = newOutputPattern;
                }
                else
                {
                    bool exists = false;
                    string pName = string.Empty;
                    int count = 0;

                    // �����łȂ�������
                    foreach (string pattern in this._outputPattern)
                    {
                        // �ŏ��̋�؂蕶���܂ł��p�^�[����
                        if (pattern.Contains(this._divider))
                        {
                            pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                            if (pName == selectedPatternName)
                            {
                                this._outputPattern[count] = patternString;
                                exists = true;
                                break;
                            }
                        }
                        count++;
                    }

                    if (exists)
                    {
                        // �X�V
                        this._userSetting.OutputPattern = this._outputPattern;
                    }
                    else
                    {
                        newOutputPattern = new string[this._outputPattern.Length + 1];
                        count = 0;
                        foreach (string pattern in _outputPattern)
                        {
                            newOutputPattern[count] = pattern;
                            count++;
                        }
                        newOutputPattern[count] = patternString;

                        // �ǉ�
                        this._outputPattern = newOutputPattern;
                        this._userSetting.OutputPattern = newOutputPattern;
                    }
                }
            }
        }
        #endregion // �v���C�x�[�g�֐�

        #region ���[�U�[�ݒ�̕ۑ��E�ǂݍ���

        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        public event EventHandler DataChanged;

        /// <summary>
        /// �݌Ɉړ��d�q�����p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɉړ��d�q�����p���[�U�[�ݒ�V���A���C�Y�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// �݌Ɉړ��d�q�����p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɉړ��d�q�����p���[�U�[�ݒ�f�V���A���C�Y�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<StockMoveUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new StockMoveUserConst();
                }
            }
        }


        /// <summary>
        /// �݌Ɉړ��d�q�����p���[�U�[�ݒ� �ݒ���e��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɉړ��d�q�����p���[�U�[�ݒ� �ݒ���e���������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Degradation(string selectedSettingName, out string[] patternValue)
        {
            // �ݒ肳�ꂽ�p�^�[����(��{�I�Ɉ����Ɠ����ɂȂ�)
            if (String.IsNullOrEmpty(selectedSettingName))
            {
                selectedSettingName = this._userSetting.SelectedPatternName;
            }

            // �p�^�[������ы�؂蕶�����擾
            this._outputPattern = this._userSetting.OutputPattern;
            this._divider = this._userSetting.DIVIDER;

            string pName = string.Empty;
            //string[] 
            patternValue = new string[9];

            // �p�^�[���̍\��
            // ��؂蕶��(�^�u�E�C�ӁE�Œ蒷�j/��؂蕶���C��/  0-1
            // ���蕶��(�h�E�C�Ӂj/���蕶���C��/                2-3
            // ���l����i����^���Ȃ�)                          4
            // ��������i����^���Ȃ�)                          5
            // �^�C�g���s�i����^�Ȃ��j                         6
            // �o�͍��ڃ��X�g (xx����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.StockMoveDetail�̏��ɕ���ł��� 7

            // �擾�����p�^�[���𕪉����A�p�^�[�����̃��X�g���쐬
            foreach (string pattern in this._outputPattern)
            {
                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));
                    // �v�����ꂽ�p�^�[�����H
                    if (pName == selectedSettingName)
                    {
                        getPatternValue(pattern.Substring(pattern.IndexOf(this._divider) + 1), out patternValue);
                    }
                }
            }
        }

        /// <summary>
        /// �J�������̃��X�g�擾
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="isSlip"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �J�������̃��X�g�擾�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public List<String> GetColumnNameList(string sourceStr, bool isSlip)
        {
            List<String> columnList;
            columnList = new List<String>();
            string[] p;
            getGridSettingPattern(sourceStr, out p, true);

            for (int i = 0; i < p.Length; i++)
            {
                columnList.Add(p[i]);
            }

            return columnList;
        }

        #endregion // ���[�U�[�ݒ�̕ۑ��E�ǂݍ���

        #region �C�x���g

        /// <summary>
        /// �o�͌`���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �o�͌`���ύX�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: Redmint #21703��Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/05/25</br>
        /// <br>Update Note: Redmint #21703��Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/05/27</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_OutputStyle_ValueChanged(object sender, EventArgs e)
        {
            // �I��l
            string selected = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            fileName = StockMoveUserConst.ChangeFileExtension(fileName, selected);

            this.tEdit_SettingFileName.Text = fileName;

            // �J�X�^���̂Ƃ��̂ݗL��
            bool val = (this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() == "3");

            // ���ڂ𒲐�
            this.pn_DividerChar.Enabled = val;
            this.pn_Parenthesis.Enabled = val;
            this.pn_TieChar.Enabled = val;
            this.pn_TieNumeric.Enabled = val;
            this.pn_TitleLine.Enabled = val;

            this.tEdit_DividerChar.Enabled = val;
            this.tEdit_ParenthesisChar.Enabled = val;

            // ��؂蕶���C��
            if (prevDividerChar == 1)
            {
                this.tEdit_DividerChar.Enabled = true;
            }
            else
            {
                this.tEdit_DividerChar.Enabled = false;
                this.tEdit_DividerChar.Clear();
            }
            // ���蕶���C��
            if (prevParenthesis == 1)
            {
                this.tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                this.tEdit_ParenthesisChar.Enabled = false;
                this.tEdit_ParenthesisChar.Clear();
            }

            // --- ADD 2011/05/25 ---------->>>>>
            switch (this.tComboEditor_OutputStyle.SelectedIndex)
            {
                case 0:
                    {
                        this.rb_DividerChar_1.Checked = true;
                        this.tEdit_DividerChar.Text = ",";
                        this.rb_Parenthesis_0.Checked = true;
                        this.rb_TieNumeric_0.Checked = true;
                        this.rb_TieChar_0.Checked = true;
                        this.rb_TitleLine_0.Checked = true;
                        this.ultraGroupBox1.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        this.rb_DividerChar_0.Checked = true;
                        this.tEdit_DividerChar.Clear();
                        this.rb_Parenthesis_0.Checked = true;
                        this.rb_TieNumeric_0.Checked = true;
                        this.rb_TieChar_0.Checked = true;
                        this.rb_TitleLine_0.Checked = true;
                        this.ultraGroupBox1.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        //this.rb_DividerChar_1.Checked = true; // DEL 2011/05/27
                        this.rb_DividerChar_2.Checked = true; // ADD 2011/05/27
                        this.tEdit_DividerChar.Text = " ";
                        this.rb_Parenthesis_0.Checked = true;
                        this.rb_TieNumeric_0.Checked = true;
                        this.rb_TieChar_0.Checked = true;
                        this.rb_TitleLine_0.Checked = true;
                        this.ultraGroupBox1.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        this.ultraGroupBox1.Enabled = true;
                        this.tEdit_DividerChar.Enabled = this.rb_DividerChar_1.Checked;
                        this.tEdit_ParenthesisChar.Enabled = rb_Parenthesis_1.Checked;
                        break;
                    }
                default:
                    break;
            }
            // --- ADD 2011/05/25 ----------<<<<<

        }

        /// <summary>
        /// �p�^�[���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �p�^�[���ύX�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (tComboEditor_PetternSelect.SelectedItem != null)
            {
                this._selectedPattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();
                getSelectedPattern();
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // �`�F�b�N
            if (!checkValues())
            {
                return;
            }

            if (Int32.Parse(this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString()) == 3)
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = 3;
            }
            else
            {
                renewalOutputPattern(false);
                this._userSetting.OutputStyle = Int32.Parse(this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString());
            }
            renewalOutputPattern(false);
            this._userSetting.OutputStyle = Int32.Parse(this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString());

            // �t�@�C����
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            // �p�^�[����
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();

            // �V���A���C�Y
            this.Serialize();

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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
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

        #region �v���C�x�[�g�֐�
        /// <summary>
        /// �e�L�X�g�o�̓p�^�[���폜�{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓p�^�[���폜�{�^�����������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_PaternDelete_Click(object sender, EventArgs e)
        {
            if (this.tComboEditor_PetternSelect.SelectedItem == null) return;

            // ���ݑI������Ă���p�^�[�����폜�ΏۂƂ���
            string deletePattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();

            // �m�F�_�C�A���O
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_DELETE_PATTERN + Environment.NewLine + Environment.NewLine + string.Format("�o�̓p�^�[���F{0}", deletePattern),
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // �폜
            # region [�폜]
            // ���݂̃p�^�[���ꗗ�����X�g�Ɋi�[����
            List<string> patternList = new List<string>(_outputPattern);
            string pName = string.Empty;

            // ���v����p�^�[�������폜
            foreach (string pattern in this._outputPattern)
            {
                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if (pattern.Contains(this._divider))
                {
                    pName = pattern.Substring(0, pattern.IndexOf(this._divider));

                    // �ݒ肳��Ă���p�^�[���̏ꍇ�͓��e���擾
                    if (pName == deletePattern)
                    {
                        patternList.Remove(pattern);
                        break;
                    }
                }
            }
            // �폜��̃��X�g���e�Œu��������
            _outputPattern = patternList.ToArray();
            # endregion

            // �\���X�V
            # region [�\���X�V]
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

                    this.tComboEditor_PetternSelect.Items.Add(item);
                }
            }
            // �ŏ��̃p�^�[����I������
            if (tComboEditor_PetternSelect.Items.Count > 0)
            {
                tComboEditor_PetternSelect.SelectedIndex = 0;
            }
            else
            {
                tComboEditor_PetternSelect.Text = string.Empty;
            }
            # endregion

        }
        /// <summary>
        /// �p�^�[���e�L�X�g�ύX���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �p�^�[���e�L�X�g�ύX���C�x���g�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_PetternSelect_ValueChanged(object sender, EventArgs e)
        {
            if (tComboEditor_PetternSelect.SelectedItem != null)
            {
                // �����̃p�^�[��
                this.uComboEditor_PetternSelect_SelectionChangeCommitted(sender, e);
            }
            else
            {
                // �V�K�p�^�[��
            }

            // �폜�{�^���̗L����������
            uButton_PaternDelete.Enabled = (tComboEditor_PetternSelect.SelectedItem != null);
        }
        /// <summary>
        /// �ݒ�t�h�����\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ݒ�t�h�����\���C�x���g�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20955</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04604UA_Shown(object sender, EventArgs e)
        {
            if (uTabControl_Setting.Tabs["TextOutput"].Visible)
            {
                tEdit_SettingFileName.Focus();

                // ----- ADD 2011/05/11 tianjw ------------------------->>>>>
                if (!string.IsNullOrEmpty(tComboEditor_PetternSelect.Text))
                {
                    uButton_PaternDelete.Enabled = true;
                }
                // ----- ADD 2011/05/11 tianjw -------------------------<<<<<
            } 
            else 
            {
                uButton_Clear_StockMoveGrid.Focus();
            }
        }
        /// <summary>
        /// �������{�^���i�݌Ɉړ��O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �������{�^���i�݌Ɉړ��O���b�h�j�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_Clear_StockMoveGrid_Click(object sender, EventArgs e)
        {
            InitializeStockMoveGrid(ref _userSetting);
            if (this.ClearSettingStockMoveGrid != null)
            {
                this.ClearSettingStockMoveGrid(this, new EventArgs());
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g�����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20951</br>
        /// <br>Update Note: Redmine #21703�A#21718</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/05/25</br>
        /// <br>Update Note: Redmine #21752</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/05/26</br>
        /// <br></br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                # region [�e�L�X�g�o��]
                case "tEdit_SettingFileName":
                    {
                        # region [���t�H�[�J�X]
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
                case "uButton_FileSelect":
                    break;
                case "tComboEditor_PetternSelect":
                    {
                        # region [���t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tComboEditor_OutputStyle;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = uButton_PaternDelete;
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;

                //case "tComboEditor_OutputStyle":
                case "rb_DividerChar_0":
                case "rb_DividerChar_1":
                case "tEdit_DividerChar":
                case "rb_DividerChar_2":
                case "rb_Parenthesis_0":
                case "rb_Parenthesis_1":
                case "tEdit_ParenthesisChar":
                case "rb_TieNumeric_0":
                case "rb_TieNumeric_1":
                case "rb_TieChar_0":
                case "rb_TieChar_1":
                case "rb_TitleLine_0":
                //case "rb_TitleLine_1": // DEL 2011/05/11 tianjw
                case "rb_TitleLine_1": // ADD 2011/05/25
                    {
                        // �����ڂ��擾
                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                        if (nextControl != null)
                        {
                            e.NextCtrl = nextControl;
                        }
                        // ----- ADD 2011/05/25 ---------->>>>>
                        if (e.PrevCtrl.Name == "rb_TitleLine_1")
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            // �^�u�؂�ւ�
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];

                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;

                                            e.NextCtrl = uButton_Clear_StockMoveGrid;
                                        }
                                        break;
                                }
                            }
                        }
                        // ----- ADD 2011/05/25 ----------<<<<<
                    }
                    break;
                // ----- DEL 2011/05/25 ---------->>>>>
                //// ----- ADD 2011/05/11 tianjw ----------------------------------------------->>>>>
                //case "rb_TitleLine_1":
                //    {
                //        if (!e.ShiftKey)
                //        {
                //            switch (e.Key)
                //            {
                //                case Keys.Tab:
                //                case Keys.Return:
                //                    {
                //                        // �^�u�؂�ւ�
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];

                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;

                //                        e.NextCtrl = uButton_Clear_StockMoveGrid;
                //                    }
                //                    break;
                //            }
                //        }
                //    }
                //    break;
                //// ----- ADD 2011/05/11 tianjw -----------------------------------------------<<<<<
                // ----- DEL 2011/05/25 ----------<<<<<
                case "tComboEditor_OutputStyle":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        // ----- ADD 2011/05/11 tianjw ------------------>>>>>
                                        if (tComboEditor_OutputStyle.SelectedIndex == 3)
                                        {
                                            e.NextCtrl = rb_DividerChar_0;
                                        }
                                        else
                                        {
                                        // ----- ADD 2011/05/11 tianjw ------------------<<<<<
                                            e.NextCtrl = e.PrevCtrl;
                                        }// ADD 2011/05/11 tianjw
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ----- ADD 2011/05/11 tianjw ------------------------------------------>>>>>
                                        if (tComboEditor_OutputStyle.SelectedIndex == 3)
                                        {
                                            // �����ڂ��擾
                                            Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                                            if (nextControl != null)
                                            {
                                                e.NextCtrl = nextControl;
                                            }
                                        }
                                        else
                                        {
                                        // ----- ADD 2011/05/11 tianjw ------------------------------------------<<<<<
                                            // �^�u�؂�ւ�
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];

                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;

                                            e.NextCtrl = uButton_Clear_StockMoveGrid;
                                        } // ADD 2011/05/11 tianjw
                                    }
                                    break;
                                default:
                                    {
                                        // �����ڂ��擾
                                        Control nextControl = _focusControl1.GetNextControl(e.PrevCtrl, e.Key, e.ShiftKey);
                                        if (nextControl != null)
                                        {
                                            e.NextCtrl = nextControl;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                # endregion

                # region [�ݒ�N���A]
                case "uButton_Clear_StockMoveGrid":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_StockMoveGrid_Click(this, new EventArgs());
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
                                        // --- ADD 2011/05/26 ---------->>>>>
                                        if (uTabControl_Setting.Tabs["TextOutput"].Visible)
                                        {
                                        // --- ADD 2011/05/26 ----------<<<<<
                                            // �^�u�؂�ւ�
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            e.NextCtrl = tComboEditor_OutputStyle;
                                        }
                                        // --- ADD 2011/05/26 ---------->>>>>
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        // --- ADD 2011/05/26 ----------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion

                case "uButton_OK":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        // �{�^������
                                        uButton_OK_Click(this, new EventArgs());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Cancel":
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // �{�^������
                                    uButton_Cancel_Click(this, new EventArgs());
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
            // --- ADD 2011/05/25 ---------->>>>>
            if (e.Key != Keys.LButton)
            {
                if (e.NextCtrl != null && (e.NextCtrl.Name == "rb_DividerChar_0" || e.NextCtrl.Name == "rb_DividerChar_1" || e.NextCtrl.Name == "rb_DividerChar_2"))
                {
                    this._dividerCharClearFlg = false;
                }
                if (e.NextCtrl != null && (e.NextCtrl.Name == "rb_Parenthesis_0" || e.NextCtrl.Name == "rb_Parenthesis_1"))
                {
                    this._parenthesisClearFlg = false;
                }
            }
            else
            {
                this._dividerCharClearFlg = true;
                this._parenthesisClearFlg = true;
            }
            // --- ADD 2011/05/25 ----------<<<<<
        }
        /// <summary>
        /// ��؂蕶��Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��؂蕶��Enter�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_DividerChar_0_Enter(object sender, EventArgs e)
        {
            this.DividerChar = prevDividerChar;
        }
        /// <summary>
        /// ��؂蕶��Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��؂蕶��Leave�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_DividerChar_0_Leave(object sender, EventArgs e)
        {
            prevDividerChar = this.DividerChar;
        }
        /// <summary>
        /// ��؂蕶��Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��؂蕶��Changed�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: Redmine 21703</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/05/25</br>
        /// <br></br>
        /// </remarks>
        private void rb_DividerChar_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_DividerChar_1.Checked)
            {
                tEdit_DividerChar.Enabled = true;
            }
            else
            {
                tEdit_DividerChar.Enabled = false;
                // --- UPD 2011/05/25 ---------->>>>>
                //tEdit_DividerChar.Clear();
                if (this._dividerCharClearFlg)
                {
                    tEdit_DividerChar.Clear();
                }
                else
                {
                    this._dividerCharClearFlg = true;
                }
                // --- UPD 2011/05/25 ----------<<<<<
            }
        }
        /// <summary>
        /// ���蕶��Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���蕶��Enter�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_Parenthesis_0_Enter(object sender, EventArgs e)
        {
            this.Parenthesis = prevParenthesis;
        }
        /// <summary>
        /// ���蕶��Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���蕶��Leave�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_Parenthesis_0_Leave(object sender, EventArgs e)
        {
            prevParenthesis = this.Parenthesis;
        }
        /// <summary>
        /// ���蕶��Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���蕶��Changed�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_Parenthesis_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Parenthesis_1.Checked)
            {
                tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                tEdit_ParenthesisChar.Enabled = false;
                // --- UPD 2011/05/25 ---------->>>>>
                // tEdit_ParenthesisChar.Clear();
                if (this._parenthesisClearFlg)
                {
                    tEdit_ParenthesisChar.Clear();
                }
                else
                {
                    this._parenthesisClearFlg = true;
                }
                // --- UPD 2011/05/25 ----------<<<<<
            }
        }
        /// <summary>
        /// ���l����Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���l����Enter�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieNumeric_0_Enter(object sender, EventArgs e)
        {
            this.TieNumeric = prevTieNumeric;
        }
        /// <summary>
        /// ���l����Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���l����Leave�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieNumeric_0_Leave(object sender, EventArgs e)
        {
            prevTieNumeric = this.TieNumeric;
        }
        /// <summary>
        /// ��������Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��������Enter�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieChar_0_Enter(object sender, EventArgs e)
        {
            this.TieChar = prevTieChar;
        }
        /// <summary>
        /// ��������Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ��������Leave�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TieChar_0_Leave(object sender, EventArgs e)
        {
            prevTieChar = this.TieChar;
        }
        /// <summary>
        /// �^�C�g���sEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�C�g���sEnter�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TitleLine_0_Enter(object sender, EventArgs e)
        {
            this.TitleLine = prevTitleLine;
        }
        /// <summary>
        /// �^�C�g���sLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�C�g���sLeave�B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rb_TitleLine_0_Leave(object sender, EventArgs e)
        {
            prevTitleLine = this.TitleLine;
        }

        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\������
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\������B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void uTabControlSet(bool display)
        {
            //�e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B
            uTabControl_Setting.Tabs["TextOutput"].Visible = display;
        }
        #endregion �v���C�x�[�g�֐�

    }

    /// <summary>
    /// �݌Ɉړ��d�q�����p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉړ��d�q�����̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class StockMoveUserConst
    {

        # region �v���C�x�[�g�ϐ�

        // �o�̓t�@�C����
        private string _outputFileName;

        // �o�͌`��
        private int _outputStyle;

        // �o�̓p�^�[��
        private string[] _outputPattern;

        // �I�����ꂽ�p�^�[����
        private string _selectedPatternName;

        /// <summary>���ڋ�؂蕶��</summary>
        private const string STRING_DIVIDER = "'";
        // �L���ȏڍ׏������X�g
        private List<string> _enabledConditionList;
        // �L���Ȋ�{�������X�g
        private List<string> _enabledCommonConditionList;
        // �ڍ׏���Enable���X�g
        private List<string> _enabledList;
        // �`�[�O���b�h�J�������X�g
        private List<ColumnInfo> _stockMoveColumnsList;

        // �ڍ׏����O���[�v�W�J���
        private bool _extraConditionExpanded;
        // ���v�\���O���[�v�W�J���
        private bool _balanceChartExpanded;

        // �݌Ɉړ��O���b�h�����T�C�Y����
        private bool _autoAdjustStockMove;

        // �o�͋敪
        private int _outPutDiv;

        // �`�[�敪
        private int _salesSlipDiv;

        # endregion // �v���C�x�[�g�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// �݌Ɉړ��d�q�������[�U�[�ݒ���N���X
        /// </summary>
        public StockMoveUserConst()
        {

        }

        # endregion // �R���X�g���N�^

        # region �v���p�e�B

        /// <summary>�o�̓t�@�C����</summary>
        public string OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        /// <summary>�o�͌^��</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>�o�̓p�^�[��</summary>
        public string[] OutputPattern
        {
            get { return this._outputPattern; }
            set { this._outputPattern = value; }
        }

        /// <summary>�I���p�^�[����</summary>
        public string SelectedPatternName
        {
            get { return this._selectedPatternName; }
            set { this._selectedPatternName = value; }
        }

        /// <summary>��؂蕶��</summary>
        public string DIVIDER
        {
            get { return STRING_DIVIDER; }
        }

        /// <summary>�L���ȏڍ׏������X�g</summary>
        public List<string> EnabledConditionList
        {
            get { return this._enabledConditionList; }
            set { this._enabledConditionList = value; }
        }

        /// <summary>�L���Ȋ�{�������X�g</summary>
        public List<string> EnabledCommonConditionList
        {
            get { return this._enabledCommonConditionList; }
            set { this._enabledCommonConditionList = value; }
        }
        /// <summary>�L���Ȋ�{����Enable���X�g</summary>
        public List<string> EnabledList
        {
            get { return this._enabledList; }
            set { this._enabledList = value; }
        }

        /// <summary>�݌Ɉړ��O���b�h�J�������X�g</summary>
        public List<ColumnInfo> StockMoveColumnsList
        {
            get { return this._stockMoveColumnsList; }
            set { this._stockMoveColumnsList = value; }
        }

        /// <summary>�ڍ׏����O���[�v�W�J���</summary>
        public bool ExtraConditionExpanded
        {
            get { return _extraConditionExpanded; }
            set { _extraConditionExpanded = value; }
        }
        /// <summary>���v�\���O���[�v�W�J���</summary>
        public bool BalanceChartExpanded
        {
            get { return _balanceChartExpanded; }
            set { _balanceChartExpanded = value; }
        }
        /// <summary>�݌Ɉړ��O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustStockMove
        {
            get { return _autoAdjustStockMove; }
            set { _autoAdjustStockMove = value; }
        }

        /// <summary>�o�͋敪</summary>
        public int OutPutDiv
        {
            get { return this._outPutDiv; }
            set { this._outPutDiv = value; }
        }

        /// <summary>�`�[�敪</summary>
        public int SalesSlipDiv
        {
            get { return this._salesSlipDiv; }
            set { this._salesSlipDiv = value; }
        }
        # endregion

        /// <summary>
        /// �݌Ɉړ��d�q�������[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>�݌Ɉړ��d�q�������[�U�[�ݒ���N���X</returns>
        public StockMoveUserConst Clone()
        {
            StockMoveUserConst constObj = new StockMoveUserConst();
            return constObj;
        }

        /// <summary>
        /// �t�@�C���g���q�ϊ�����
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�@�C���g���q�ϊ�����</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public static string ChangeFileExtension(string fileName, string selectedValue)
        {
            string newExt = string.Empty;
            switch (selectedValue)
            {
                case "0":
                    newExt = ".CSV";
                    break;
                case "1":
                    newExt = ".TXT";
                    break;
                case "2":
                    newExt = ".PRN";
                    break;
                case "3":
                default:
                    break;
            }
            if (newExt != string.Empty)
            {
                try
                {
                    fileName = Path.ChangeExtension(fileName, newExt);
                }
                catch
                {
                }
            }
            return fileName;
        }
    }

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>��</summary>
        private string _columnName;
        /// <summary>���я�</summary>
        private int _visiblePosition;
        /// <summary>��\���t���O</summary>
        private bool _hidden;
        /// <summary>��</summary>
        private int _width;
        /// <summary>�Œ�t���O</summary>
        private bool _columnFixed;
        /// <summary>
        /// ��
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// ���я�
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// ��\���t���O
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// �Œ�t���O
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="visiblePosition">���я�</param>
        /// <param name="hidden">��\���t���O</param>
        /// <param name="width">��</param>
        /// <param name="columnFixed">�Œ�t���O</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }

    /// <summary>
    /// ColumnInfo��r�N���X�i�\�[�g�p�j
    /// </summary>
    /// <remarks>
    /// <br>Note       : ColumnInfo��r�N���X�i�\�[�g�p�j</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo��r����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ColumnInfo x, ColumnInfo y)
        {
            // ��\�����Ŕ�r
            int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
            // ��\��������v����ꍇ�͗񖼂Ŕ�r(�ʏ�͔������Ȃ�)
            if (result == 0)
            {
                result = x.ColumnName.CompareTo(y.ColumnName);
            }
            return result;
        }
    }

    # endregion

    # region [��ʃt�H�[�J�X����N���X]
    /// <summary>
    /// ��ʃt�H�[�J�X����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ʃt�H�[�J�X����N���X</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    internal class FocusControl
    {
        List<List<Control>> _controls;
        Dictionary<string, int> _col;
        Dictionary<string, int> _row;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FocusControl()
        {
            this.Clear();
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����������</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Clear()
        {
            _controls = new List<List<Control>>();
            _col = new Dictionary<string, int>();
            _row = new Dictionary<string, int>();
        }

        /// <summary>
        /// �P�s�ǉ�
        /// </summary>
        /// <param name="controls"></param>
        /// <remarks>
        /// <br>Note       : �P�s�ǉ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void AddLine(params Control[] controls)
        {
            List<Control> line = new List<Control>(controls);

            for (int index = 0; index < line.Count; index++)
            {
                int col = index;
                int row = _controls.Count;

                _col.Add(line[index].Name, col);
                _row.Add(line[index].Name, row);
            }

            _controls.Add(line);
        }

        /// <summary>
        /// ���R���g���[���擾�i�t�H�[�J�X�ړ���j
        /// </summary>
        /// <param name="prevControl"></param>
        /// <param name="key"></param>
        /// <param name="shiftKey"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���R���g���[���擾�i�t�H�[�J�X�ړ���j</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20951</br>
        /// <br></br>
        /// </remarks>
        public Control GetNextControl(Control prevControl, Keys key, bool shiftKey)
        {
            Control nextControl = null;

            if (!_col.ContainsKey(prevControl.Name)) return null;

            int col = _col[prevControl.Name];
            int row = _row[prevControl.Name];

            if (_controls[row][col].Name != prevControl.Name) return null;

            if (!shiftKey)
            {
                switch (key)
                {
                    # region [UP]
                    case Keys.Up:
                        {
                            if (row - 1 >= 0)
                            {
                                int originCol = col;
                                row--;

                                if (col > _controls[row].Count - 1)
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while (nextControl == null || nextControl.Enabled == false)
                                {
                                    if (col > 0)
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if (row > 0)
                                    {
                                        col = originCol;
                                        row--;
                                        if (col > _controls[row].Count - 1)
                                        {
                                            col = _controls[row].Count - 1;
                                        }
                                        nextControl = _controls[row][col];
                                    }
                                    else
                                    {
                                        nextControl = null;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                nextControl = null;
                            }
                        }
                        break;
                    # endregion

                    # region [DOWN]
                    case Keys.Down:
                        {
                            if (row + 1 <= _controls.Count - 1)
                            {
                                int originCol = col;
                                row++;

                                if (col > _controls[row].Count - 1)
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while (nextControl == null || nextControl.Enabled == false)
                                {
                                    if (col > 0)
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if (row + 1 <= _controls.Count - 1)
                                    {
                                        col = originCol;
                                        row++;
                                        if (col > _controls[row].Count - 1)
                                        {
                                            col = _controls[row].Count - 1;
                                        }
                                        nextControl = _controls[row][col];
                                    }
                                    else
                                    {
                                        nextControl = null;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //nextControl = null; // DEL 2011/05/11 tianjw
                                nextControl = _controls[row][col]; // ADD 2011/05/11 tianjw
                            }
                        }
                        break;
                    # endregion

                    # region [LEFT]
                    case Keys.Left:
                        {
                            nextControl = null;
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col > 0)
                                {
                                    col--;
                                    nextControl = _controls[row][col];
                                }
                                else
                                {
                                    nextControl = null;
                                    break;
                                }
                            }
                        }
                        break;
                    # endregion

                    # region [RIGHT]
                    case Keys.Right:
                        {
                            nextControl = null;
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col < _controls[row].Count - 1)
                                {
                                    col++;
                                    nextControl = _controls[row][col];
                                }
                                else
                                {
                                    nextControl = null;
                                    break;
                                }
                            }
                        }
                        break;
                    # endregion

                    # region [Tab����]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab��������
                            nextControl = null;
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col + 1 <= _controls[row].Count - 1)
                                {
                                    col++;
                                }
                                else if (row + 1 <= _controls.Count - 1)
                                {
                                    row++;
                                    col = 0;
                                }
                                else
                                {
                                    break;
                                }
                                nextControl = _controls[row][col];
                            }
                        }
                        break;
                    # endregion
                }
            }
            else
            {
                switch (key)
                {
                    # region [Tab���O]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab���O����
                            nextControl = null;
                            while (nextControl == null || nextControl.Enabled == false)
                            {
                                if (col - 1 >= 0)
                                {
                                    col--;
                                }
                                else if (row - 1 >= 0)
                                {
                                    row--;
                                    col = _controls[row].Count - 1;
                                }
                                else
                                {
                                    break;
                                }

                                nextControl = _controls[row][col];
                            }
                        }
                        break;
                    # endregion
                }
            }

            return nextControl;
        }
    }
    # endregion

    # region [�O���b�h�E��I���_�C�A���O����N���X]
    /// <summary>
    /// �O���b�h�E��I���_�C�A���O����N���X
    /// </summary>
    /// <remarks>Grid�̃J�����`���[�U�����ʉ����܂�</remarks>
    /// <remarks>
    /// <br>Note       : �O���b�h�E��I���_�C�A���O����N���X</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    public class GridColumnChooserControl
    {
        private List<Infragistics.Win.UltraWinGrid.UltraGrid> _targetList;
        private Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog> _chooserDialogs;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public GridColumnChooserControl()
        {
            _targetList = new List<Infragistics.Win.UltraWinGrid.UltraGrid>();
            _chooserDialogs = new Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog>();
        }

        /// <summary>
        /// �Ώےǉ�
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <remarks>
        /// <br>Note       :�Ώےǉ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void Add(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            if (!_targetList.Contains(targetGrid))
            {
                // �Ώ�Grid���X�g
                _targetList.Add(targetGrid);
                // �J�����`���[�U�_�C�A���O
                _chooserDialogs.Add(targetGrid.Name, CreateColumnChooser(targetGrid));

                // �Ώ�Grid�ւ̑���
                targetGrid.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
                targetGrid.BeforeColumnChooserDisplayed += new Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventHandler(uGrid_BeforeColumnChooserDisplayed);
            }
        }
        /// <summary>
        /// �J�����`���[�U�[�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>��Grid�̃f�t�H���g�̃J�����`���[�U�[���J�X�^�}�C�Y���܂�</remarks>
        /// <remarks>
        /// <br>Note       :�J�����`���[�U�[�\��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_BeforeColumnChooserDisplayed(object sender, Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventArgs e)
        {
            // �f�t�H���g�̏����̓L�����Z������
            e.Cancel = true;

            // �J�����`���[�U�[�_�C�A���O
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = _chooserDialogs[(sender as Control).Name];
            if (chooser == null) return;

            try
            {
                //-----------------------------------------------------------------
                // �����ӁF
                //   �Ӑ}�I�ɖ����Ȓl-1��^���鎖�Œ��O�Ƀ\�[�g��������Ȃ��悤�ɂ���B
                //-----------------------------------------------------------------
                chooser.ColumnChooserControl.ColumnDisplayOrder = (Infragistics.Win.UltraWinGrid.ColumnDisplayOrder)(-1);
                chooser.Show();
            }
            catch
            {
                // ��O
            }
        }
        /// <summary>
        /// �J�����`���[�U�[��������
        /// </summary>
        /// <param name="sourceGrid"></param>
        /// <remarks>
        /// <br>Note       :�J�����`���[�U�[��������</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Infragistics.Win.UltraWinGrid.ColumnChooserDialog CreateColumnChooser(Infragistics.Win.UltraWinGrid.UltraGrid sourceGrid)
        {
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = new Infragistics.Win.UltraWinGrid.ColumnChooserDialog();

            chooser.Text = "�\�����ڂ̑I��";
            chooser.StartPosition = FormStartPosition.CenterScreen;
            chooser.Size = new Size(250, 400);
            chooser.TopMost = true;

            // �\����������A�j�����Ȃ�
            chooser.DisposeOnClose = Infragistics.Win.DefaultableBoolean.False;

            chooser.ColumnChooserControl.SourceGrid = sourceGrid;
            chooser.ColumnChooserControl.Font = sourceGrid.Font;

            return chooser;
        }
    }
    # endregion

}