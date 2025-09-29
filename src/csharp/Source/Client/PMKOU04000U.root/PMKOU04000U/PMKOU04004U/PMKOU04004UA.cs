//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d����d�q����
// �v���O�����T�v   : �d����d�q���� ����ݒ�t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI�y�~ �їR��
// �C �� ��  2013/01/21  �C�����e : �ԕi�v��@�\�ǉ�
//                                   1.�I���`�F�b�N�{�b�N�X�����ǉ�
//                                   2.�ԕi�v��Grid�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901273-00 �쐬�S�� : gezh
// �C �� ��  2013/04/16  �C�����e : 2013/05/15�z�M�� Redmine#35309
//                                  ��1871_�d����d�q�����̃e�L�X�g�o�͂̏�Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170170-00    �쐬�S�� : �c����
// �C �� ��  2015/09/17     �C�����e : Redmine#47006 �d����d�q�����̏�Q�Ή�
//                                     ���s�ۏ�����邽�߉�ʂɋ敪��݂���
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
//using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKOU04004UA : Form
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        # region const
        // �p�^�[���폜�m�F���b�Z�[�W
        private const string MSG_CONFIRM_DELETE_PATTERN = "�I�𒆂̏o�̓p�^�[�����폜���Ă�낵���ł����H";
        // �t�@�C���������̓��b�Z�[�W
        //private const string MSG_OUTPUTTEXT_NOFILENAME = "�t�@�C��������͂��ĉ�����"; // DEL 2010/09/28 ��Q�� #15619
        // �p�^�[�������̓��b�Z�[�W
        private const string MSG_OUTPUTTEXT_NOPATTERN = "�o�̓p�^�[������͂��ĉ�����";
        # endregion
        # region event
        /// <summary>�`�[�O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingSlipGrid;
        /// <summary>���׃O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingDetailGrid;
        /// <summary>�c���O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettingBalanceGrid;
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>�ԕi�v����̓O���b�h�ݒ菉����</summary>
        public event EventHandler ClearSettinRetGoodsAddUpInpGrid;
        // ----------ADD 2013/01/21-----------<<<<<
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        #region �v���C�x�[�g�ϐ�

        // �ݒ�ۑ��p���ʃI�u�W�F�N�g

        //private UserSettingController uSettingControl;

        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMKOU04000U_Construction.XML";

        // �f�[�^�Z�b�g
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
        //private ExportColumnDataSet _dataSet;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        private SuppPtrStcDetailDataSet _dataSet;
        private int prevDividerChar;
        private int prevParenthesis;
        private int prevTieNumeric;
        private int prevTieChar;
        private int prevTitleLine;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // ���[�U�[�ݒ�
        private SuppPtrStcUserConst _userSetting;

        //// ���[�U�[�ݒ�
        //private int _outputStyle;

        // **** �X�L���ݒ�p�N���X ****
        private ControlScreenSkin _controlScreenSkin;

        // ��؂蕶��
        private string _divider;

        // �p�^�[��
        private string[] _outputPattern;

        // �I������Ă���p�^�[����
        private string _selectedPattern;

        // �`�[�O���b�h�̐ݒ�
        private string _gridSetting_Slip = string.Empty;

        // ���׃O���b�h�̐ݒ�
        private string _gridSetting_Detail = string.Empty;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        // �`�[����index�f�B�N�V���i��
        private Dictionary<string, int> _columnIndexDicOfSlip;
        // ���׍���index�f�B�N�V���i��
        private Dictionary<string, int> _columnIndexDicOfDetail;
        // �`�[�O���b�h�J�����E�R���N�V����
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _slipColCollection;
        // ���׃O���b�h�J�����E�R���N�V����
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _detailColCollection;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        // �c���O���b�h�J�����E�R���N�V����
        private Infragistics.Win.UltraWinGrid.ColumnsCollection _balanceColCollection;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
        // �t�H�[�J�X����
        private FocusControl _focusControl1;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        // �O���b�h�E�J�����`���[�U�[����
        private GridColumnChooserControl _gridColumnChooserControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

        // 2010/04/05 Add >>>
        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_TextOutput;

        #region �񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        #endregion // �񋓑�

        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�������
        /// </summary>
        public int Opt_TextOutput
        {
            get { return this._opt_TextOutput; }
            set { this._opt_TextOutput = value; }
        }

        // 2010/04/05 Add <<<


        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B

        public SuppPtrStcUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// �`�[�O���b�h�J�����E�R���N�V���� 
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection SlipColCollection
        {
            get { return _slipColCollection; }
            set { _slipColCollection = value; }
        }
        /// <summary>
        /// ���׃O���b�h�J�����E�R���N�V����
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection DetailColCollection
        {
            get { return _detailColCollection; }
            set { _detailColCollection = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
        /// <summary>
        /// ���׃O���b�h�J�����E�R���N�V����
        /// </summary>
        public Infragistics.Win.UltraWinGrid.ColumnsCollection BalanceColCollection
        {
            get { return _balanceColCollection; }
            set { _balanceColCollection = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
        /// <summary>
        /// ��؂蕶��
        /// </summary>
        private int DividerChar
        {
            get
            {
                if ( rb_DividerChar_0.Checked )
                {
                    return 0;
                }
                else if ( rb_DividerChar_1.Checked )
                {
                    return 1;
                }
                else if ( rb_DividerChar_2.Checked )
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
                switch ( value )
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
                if ( rb_Parenthesis_0.Checked )
                {
                    return 0;
                }
                else if ( rb_Parenthesis_1.Checked )
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
                switch ( value )
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
                if ( rb_TieNumeric_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TieNumeric_1.Checked )
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
                switch ( value )
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
                if ( rb_TieChar_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TieChar_1.Checked )
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
                switch ( value )
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
                if ( rb_TitleLine_0.Checked )
                {
                    return 0;
                }
                else if ( rb_TitleLine_1.Checked )
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
                switch ( value )
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKOU04004UA()
        {
            InitializeComponent();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            this._dataSet = new SuppPtrStcDetailDataSet();

            // �`�[����index
            _columnIndexDicOfSlip = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.StcList.Columns.Count; index++ )
            {
                _columnIndexDicOfSlip.Add( _dataSet.StcList.Columns[index].ColumnName, index );
            }

            // ���׍���index
            _columnIndexDicOfDetail = new Dictionary<string, int>();
            for ( int index = 0; index < _dataSet.StcDetail.Columns.Count; index++ )
            {
                _columnIndexDicOfDetail.Add( _dataSet.StcDetail.Columns[index].ColumnName, index );
            }

            this._userSetting = new SuppPtrStcUserConst();

            // �t�H�[�J�X����(�e�L�X�g�o�͐ݒ�^�u)
            _focusControl1 = new FocusControl();
            _focusControl1.AddLine( tComboEditor_OutputStyle );
            _focusControl1.AddLine( rb_DividerChar_0, rb_DividerChar_1, tEdit_DividerChar, rb_DividerChar_2 );
            _focusControl1.AddLine( rb_Parenthesis_0, rb_Parenthesis_1, tEdit_ParenthesisChar );
            _focusControl1.AddLine( rb_TieNumeric_0, rb_TieNumeric_1 );
            _focusControl1.AddLine( rb_TieChar_0, rb_TieChar_1 );
            _focusControl1.AddLine( rb_TitleLine_0, rb_TitleLine_1 );
            _focusControl1.AddLine( tComboEditor_OutputType );

            _focusControl1.AddLine( uCheckEditor_RetSlipMinus_Saleslip ); // ADD 2015/09/17 �c���� Redmine#47006
            _focusControl1.AddLine( uCheckEditor_RetSlipMinus_Meisai ); // ADD 2015/09/17 �c���� Redmine#47006

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            _gridColumnChooserControl = new GridColumnChooserControl();
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector );
            _gridColumnChooserControl.Add( uGrid_ColumnItemSelector2 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
        /// <summary>
        /// �`�[����index�擾����
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetColumnPositionOfSlip( string[] patterns, string columnName )
        {
            if ( _columnIndexDicOfSlip.ContainsKey( columnName ) )
            {
                try
                {
                    //return Int32.Parse( patterns[_columnIndexDicOfSlip[columnName]].ToString() );  // DEL 2013/04/16 gezh FOR Redmine#35309
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ---------->>>>>
                    // XML�t�@�C�����ŐV�ł͂Ȃ��ꍇ
                    if (_columnIndexDicOfSlip.Count != patterns.Length)
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfSlip[columnName] - 1].ToString());
                    }
                    // XML�t�@�C�����ŐV�ꍇ
                    else
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfSlip[columnName]].ToString());
                    }
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ----------<<<<<
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
        /// ���׍���index�擾����
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetColumnPositionOfDetail( string[] patterns, string columnName )
        {
            if ( _columnIndexDicOfDetail.ContainsKey( columnName ) )
            {
                try
                {
                    //return Int32.Parse(patterns[_columnIndexDicOfDetail[columnName]].ToString()); // DEL 2013/04/16 gezh FOR Redmine#35309
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ---------->>>>>
                    // XML�t�@�C�����ŐV�ł͂Ȃ��ꍇ
                    if (_columnIndexDicOfDetail.Count != patterns.Length)
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfDetail[columnName] - 1].ToString());
                    }
                    // XML�t�@�C�����ŐV�ꍇ
                    else
                    {
                        return Int32.Parse(patterns[_columnIndexDicOfDetail[columnName]].ToString());
                    }
                    // --------------- ADD 2013/04/16 gezh FOR Redmine#35309 ----------<<<<<
                }
                catch
                {
                    return _columnIndexDicOfDetail.Count + 1;
                }
            }
            else
            {
                return _columnIndexDicOfDetail.Count + 1;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

        /// <summary>
        /// ��ʋN��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>UpdateNote : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void PMKOU04004UA_Load(object sender, EventArgs e)
        {
            // ��ʐݒ�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //this._dataSet = new ExportColumnDataSet();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL

            // �O���b�h���Ɏg�p����f�[�^�r���[���쐬
            DataView dViewSlip = new DataView(this._dataSet.StcList);
            DataView dViewDetail = new DataView(this._dataSet.StcDetail);

            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_ColumnItemSelector.DataSource = dViewSlip;
            this.uGrid_ColumnItemSelector2.DataSource = dViewDetail;

            // �ݒ�l������΃��[�h
            this._userSetting = new SuppPtrStcUserConst();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            InitializeUserSetting( ref _userSetting );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            this.Deserialize();

            // �p�^�[���E��؂蕶���E�ݒ薼���擾
            if (this._userSetting != null)
            {
                this._outputPattern = this._userSetting.OutputPattern;
                this._divider = this._userSetting.DIVIDER;
                this._selectedPattern = this._userSetting.SelectedPatternName;
            }

            // �J����
            InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0);
            InitializeGridColumns(this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1);

            // �{�^���ݒ�
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
            this.uButton_AccpayFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_AccpayFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            this.uButton_PaymentFileName.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_PaymentFileName.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<

            // ��{�p�^�[�����쐬
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //string tempName = string.Empty;
            //createPatternStringNonCustom(0, out tempName, true);
            //createPatternStringNonCustom(1, out tempName, true);
            //createPatternStringNonCustom(2, out tempName, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            if ( _userSetting == null ||
                _userSetting.OutputPattern == null ||
                _userSetting.OutputPattern.Length == 0 )
            {
                string tempName = string.Empty;
                createPatternStringNonCustom( 0, out tempName, true );
                createPatternStringNonCustom( 1, out tempName, true );
                createPatternStringNonCustom( 2, out tempName, true );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

            //this._outputStyle = 0;// �����ݒ�

            // ��ʂ̏����l���Z�b�g
            setInitialValue();

            // ��ʂ̏����ݒ�
            this.uComboEditor_OutputType_ValueChanged(null, null);
            this.uComboEditor_OutputStyle_ValueChanged(null, null);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            // ValueChanged�C�x���g�ŏ����ς�����t�@�C������߂�
            tEdit_SettingFileName.Text = _userSetting.OutputFileName;
            // ---------------------- ADD  2010/07/20 ---------------->>>>>
            tEdit_AccpayFileName.Text = _userSetting.SuplierFileName;
            tEdit_PaymentFileName.Text = _userSetting.SuplAccFileName;
            // ---------------------- ADD  2010/07/20 ------------------>>>>>

            //�\���X�V

            // ��؂蕶���C��
            if ( prevDividerChar == 1 )
            {
                this.tEdit_DividerChar.Enabled = true;
            }
            else
            {
                this.tEdit_DividerChar.Enabled = false;
                this.tEdit_DividerChar.Clear();
            }
            // ���蕶���C��
            if ( prevParenthesis == 1 )
            {
                this.tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                this.tEdit_ParenthesisChar.Enabled = false;
                this.tEdit_ParenthesisChar.Clear();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// ���[�U�[�ݒ菉��������
        /// </summary>
        /// <param name="_userSetting"></param>
        private void InitializeUserSetting( ref SuppPtrStcUserConst userSetting )
        {
            userSetting = new SuppPtrStcUserConst();
            InitializeSlipGrid( ref userSetting );
            InitializeDetailGrid( ref userSetting );
            InitializeBalanceGrid( ref userSetting );
            InitializeRetGoodsAddUpInpGrid(ref userSetting);   // ADD  2013/01/21
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i�`�[�\���j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeSlipGrid( ref SuppPtrStcUserConst userSetting )
        {
            userSetting.SlipColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustSlip = false;
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i���ו\���j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeDetailGrid( ref SuppPtrStcUserConst userSetting )
        {
            userSetting.DetailColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustDetail = false;
        }
        /// <summary>
        /// ���[�U�[�ݒ菉�����i�c���ꗗ�\���j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeBalanceGrid( ref SuppPtrStcUserConst userSetting )
        {
            userSetting.BalanceColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustBalance = false;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
 
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>
        /// ���[�U�[�ݒ菉�����i�ԕi�v����́j
        /// </summary>
        /// <param name="userSetting"></param>
        private void InitializeRetGoodsAddUpInpGrid(ref SuppPtrStcUserConst userSetting)
        {
            userSetting.RetGoodsAddUpInpColumnsList = new List<ColumnInfo>();
            userSetting.AutoAdjustRetGoodsAddUpInp = false;
        }
        // ----------ADD 2013/01/21-----------<<<<<
 
        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�֐�

        /// <summary>
        /// ��ʂ̏����l��ݒ�
        /// </summary>
        private void setInitialValue()
        {
            // �ݒ�l������΂����ݒu
            if (this._outputPattern == null)
            {
                this.tEdit_DividerChar.Clear();
                this.tEdit_ParenthesisChar.Clear();
                this.tEdit_SettingFileName.Clear();
                this.tComboEditor_PetternSelect.Text = string.Empty;

                //this.uComboEditor_OutputType.SelectedIndex = 0;
                //this.uComboEditor_OutputStyle.SelectedIndex = 0;
                this.tComboEditor_OutputType.SelectedIndex = 0;
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                this.tComboEditor_PetternSelect.Items.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
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

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //// �o�͌`��
                ////this.uComboEditor_OutputStyle.Text = "�J�X�^��";
                //this.uComboEditor_OutputStyle.SelectedIndex = Int32.Parse(patternValue[9].ToString());

                //// ��؂蕶��
                //this.uOptionSet_DividerChar.CheckedIndex = Int32.Parse(patternValue[0].ToString());
                //// ��؂蕶���C��
                //this.tEdit_DividerChar.Text = patternValue[1].ToString();

                //// ���蕶��
                //this.uOptionSet_Parenthesis.CheckedIndex = Int32.Parse(patternValue[2].ToString());
                //// ���蕶���C��
                //this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();

                //// ���l����
                //this.uOptionSet_TieNumeric.CheckedIndex = Int32.Parse(patternValue[4].ToString());
                //// ��������
                //this.uOptionSet_TieChar.CheckedIndex = Int32.Parse(patternValue[5].ToString());

                //// �^�C�g���s
                //this.uOptionSet_TitleLine.CheckedIndex = Int32.Parse(patternValue[6].ToString());

                //// �O���b�h
                //this._gridSetting_Slip = patternValue[7].ToString();
                //this._gridSetting_Detail = patternValue[8].ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                // �t�h�\��
                SetDisplayFromPattern( patternValue );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            }
        }

        /// <summary>
        /// �p�^�[���̓��e�𕪉�
        /// </summary>
        /// <param name="pBody"></param>
        /// <param name="pValue"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void getPatternValue(string pBody, out string[] pValue)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //pValue = new string[10];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            //const int ct_ItemCount = 11; // DEL 2015/09/17 �c���� Redmine#47006
            const int ct_ItemCount = 13; // ADD 2015/09/17 �c���� Redmine#47006
            pValue = new string[ct_ItemCount];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            string str1 = pBody;
            string str2 = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //for (int i=0; i < 10; i++)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            for ( int i = 0; i < ct_ItemCount; i++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
            {
                if (str1.Contains(this._divider))
                {
                    pValue[i] = str1.Substring(0, str1.IndexOf(this._divider));
                }
                else
                {
                    pValue[i] = str1.Substring(0);

                    // ----- ADD 2015/09/17 �c���� Redmine#47006 ----->>>>>
                    // ����XML�̃p�^�[���̓��e��11���ڂ����A12��13�̍��ڂ̓��e��ǉ����܂��B
                    if (i == 10)
                    {
                        // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v�̏ꍇ�A�I�t��ݒ肵�܂��B
                        pValue[11] = "0";
                        // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v�̏ꍇ�A�I�t��ݒ肵�܂��B
                        pValue[12] = "0";
                        break;
                    }
                    // ----- ADD 2015/09/17 �c���� Redmine#47006 -----<<<<<
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
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //if (isSlip)
            //{
            //    //gridSetting = new string[32];
            //    gridSetting = new string[18];

            //    //for (int i = 0; i < 32; i++)
            //    for (int i = 0; i < 19; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            //else
            //{
            //    //gridSetting = new string[57];
            //    gridSetting = new string[35];

            //    //for (int i = 0; i < 57; i++)
            //    for (int i = 0; i < 36; i++)
            //    {
            //        gridSetting[i] = patternStr.Substring(i * 3, 3);
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            int count = patternStr.Length / 3;
            gridSetting = new string[count];

            for ( int i = 0; i < count; i++ )
            {
                gridSetting[i] = patternStr.Substring( i * 3, 3 );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        }

        /// <summary>
        /// �I�����ꂽ�p�^�[����K�p
        /// </summary>
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
            //int counter = 0;
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// �t�@�C����
            //this.tEdit_SettingFileName.Text = this._userSetting.OutputFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL

            // �p�^�[����
            this.tComboEditor_PetternSelect.Text = this._selectedPattern;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// �o�͌`��
            ////this.uComboEditor_OutputStyle.Text = "�J�X�^��";
            //this.uComboEditor_OutputStyle.SelectedIndex = Int32.Parse(patternValue[9].ToString());

            //// ��؂蕶��
            //this.uOptionSet_DividerChar.CheckedIndex = Int32.Parse(patternValue[0].ToString());
            //// ��؂蕶���C��
            //this.tEdit_DividerChar.Text = patternValue[1].ToString();

            //// ���蕶��
            //this.uOptionSet_Parenthesis.CheckedIndex = Int32.Parse(patternValue[2].ToString());
            //// ���蕶���C��
            //this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();

            //// ���l����
            //this.uOptionSet_TieNumeric.CheckedIndex = Int32.Parse(patternValue[4].ToString());
            //// ��������
            //this.uOptionSet_TieChar.CheckedIndex = Int32.Parse(patternValue[5].ToString());

            //// �^�C�g���s
            //this.uOptionSet_TitleLine.CheckedIndex = Int32.Parse(patternValue[6].ToString());

            //// �O���b�h
            //this._gridSetting_Slip = patternValue[7].ToString();
            //this._gridSetting_Detail = patternValue[8].ToString();

            //// �J�����ݒ�
            //InitializeGridColumns(this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0);
            InitializeGridColumns(this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            // �t�h�\��
            SetDisplayFromPattern( patternValue );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/27 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patternValue"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void SetDisplayFromPattern( string[] patternValue )
        {
            try
            {
                // �o�͌`��
                //this.uComboEditor_OutputStyle.Text = "�J�X�^��";
                this.tComboEditor_OutputStyle.SelectedIndex = Int32.Parse( patternValue[9].ToString() );

                // ��؂蕶��
                //this.uOptionSet_DividerChar.CheckedIndex = Int32.Parse( patternValue[0].ToString() );
                this.DividerChar = Int32.Parse( patternValue[0].ToString() );
                prevDividerChar = this.DividerChar;
                // ��؂蕶���C��
                this.tEdit_DividerChar.Text = patternValue[1].ToString();
                if ( prevDividerChar == 1 )
                {
                    this.tEdit_DividerChar.Enabled = true;
                }
                else
                {
                    this.tEdit_DividerChar.Enabled = false;
                    this.tEdit_DividerChar.Clear();
                }

                // ���蕶��
                //this.uOptionSet_Parenthesis.CheckedIndex = Int32.Parse( patternValue[2].ToString() );
                this.Parenthesis = Int32.Parse( patternValue[2].ToString() );
                prevParenthesis = this.Parenthesis;
                // ���蕶���C��
                this.tEdit_ParenthesisChar.Text = patternValue[3].ToString();
                if ( prevParenthesis == 1 )
                {
                    this.tEdit_ParenthesisChar.Enabled = true;
                }
                else
                {
                    this.tEdit_ParenthesisChar.Enabled = false;
                    this.tEdit_ParenthesisChar.Clear();
                }

                // ���l����
                //this.uOptionSet_TieNumeric.CheckedIndex = Int32.Parse( patternValue[4].ToString() );
                this.TieNumeric = Int32.Parse( patternValue[4].ToString() );
                prevTieNumeric = this.TieNumeric;
                // ��������
                //this.uOptionSet_TieChar.CheckedIndex = Int32.Parse( patternValue[5].ToString() );
                this.TieChar = Int32.Parse( patternValue[5].ToString() );
                prevTieChar = this.TieChar;

                // �^�C�g���s
                //this.uOptionSet_TitleLine.CheckedIndex = Int32.Parse( patternValue[6].ToString() );
                this.TitleLine = Int32.Parse( patternValue[6].ToString() );
                prevTitleLine = this.TitleLine;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                // �O���b�h�I��
                this.tComboEditor_OutputType.SelectedIndex = Int32.Parse( patternValue[10].ToString() );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v�`�F�b�N�I���̏ꍇ�A
                if (patternValue[11] == "1")
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = true;
                }
                else
                {
                    this.uCheckEditor_RetSlipMinus_Saleslip.Checked = false;
                }

                // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v�`�F�b�N�I���̏ꍇ�A
                if (patternValue[12] == "1")
                {
                    this.uCheckEditor_RetSlipMinus_Meisai.Checked = true;
                }
                else
                {
                    this.uCheckEditor_RetSlipMinus_Meisai.Checked = false;
                }
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                // �O���b�h
                this._gridSetting_Slip = patternValue[7].ToString();
                this._gridSetting_Detail = patternValue[8].ToString();

                // �J�����ݒ�
                InitializeGridColumns( this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns, 0 );
                InitializeGridColumns( this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns, 1 );
            }
            catch
            {
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/27 ADD

        /// <summary>
        /// �f�[�^�O���b�h�Z�b�g
        /// </summary>
        /// <param name="Columns"></param>
        /// <param name="tabNo"></param>
        /// <remarks>
        /// <br>Update Note : 2013/01/21 FSI�y�~ �їR��</br>
        /// <br>              [�d���ԕi�\��@�\] �I���`�F�b�N�{�b�N�X�̏��O������ǉ�</br>
        /// <br>Update Note: 2013/04/16 gezh</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/05/15�z�M��</br>
        /// <br>             Redmine#35309 ��1871_�d����d�q�����̃e�L�X�g�o�͂̏�Q�Ή�</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, int tabNo)
        {
            // �\���ʒu�����l
            int visiblePosition = 1;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False; // m.suzuki 2009/02/20 True->False

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }


            switch (tabNo)
            {
                case 0:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                        # region // DEL
                        //#region �`�[

                        //// �ݒ肪����΂���ɏ]���A�Ȃ���ΑS�\��
                        //if (String.IsNullOrEmpty(this._gridSetting_Slip))
                        //{
                        //    #region �`�[�O���b�h�w�b�_�쐬�i�ݒ�Ȃ��j

                        //    // �`�[���t
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���t�iyyyy/mm/dd�j
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �`�[�ԍ�
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Width = 110;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �敪��
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Width = 80;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �S���Җ�
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���z
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���z
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �����
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F���z
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�P
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�Q
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���_�R�[�h
                        //    // �J�����`���[�U�F�ΏۊO�@�t�H�[�}�b�g�F��\��
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Hidden = true;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Width = 80;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Caption = "���_�R�[�h";
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���_
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Width = 120;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 2008.12.05 del start [8726]
                        //    // ���s��
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Width = 100;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // 2008.12.05 del end [8726]

                        //    // �d����R�[�h
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������(���l)
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Width = 80;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �d���於
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Caption = "�d���於";
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N1
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Caption = "UOE���}�[�N1";
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N2
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Caption = "UOE���}�[�N2";
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �d��SEQ/�x��No
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Caption = "�d��SEQ/�x��No";
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v���
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������(���l)
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Width = 100;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���|�敪��
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������(���l)
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Width = 70;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �ԓ`�敪
                        //    // �J�����`���[�U�F�Ώہ@�@�t�H�[�}�b�g�F������(���l)
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Width = 50;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    #endregion
                        //}
                        //else
                        //{
                        //    #region �`�[�O���b�h�w�b�_�쐬�i�ݒ肠��j

                        //    string[] gridPattern = new string[18];
                        //    getGridSettingPattern(this._gridSetting_Slip, out gridPattern, true);

                        //    int position = 0;

                        //    // �`�[���t
                        //    position = Int32.Parse(gridPattern[0].ToString());
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �`�[�ԍ�
                        //    position = Int32.Parse(gridPattern[1].ToString());
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �敪��
                        //    position = Int32.Parse(gridPattern[2].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �S���Җ�
                        //    position = Int32.Parse(gridPattern[3].ToString());
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���z
                        //    position = Int32.Parse(gridPattern[4].ToString());
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �����
                        //    position = Int32.Parse(gridPattern[5].ToString());
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.ConsumeTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���l�P
                        //    position = Int32.Parse(gridPattern[6].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // ���l�Q
                        //    position = Int32.Parse(gridPattern[7].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���_�R�[�h
                        //    position = Int32.Parse(gridPattern[8].ToString());
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Caption = "���_�R�[�h";
                        //    Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SectionCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���_
                        //    position = Int32.Parse(gridPattern[9].ToString());
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // 2008.12.05 del start [8726]
                        //    // ���s��
                        //    //position = Int32.Parse(gridPattern[10].ToString());
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    //Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.StcList.StockInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // 2008.12.05 del end [8726]

                        //    // �d����R�[�h
                        //    position = Int32.Parse(gridPattern[11].ToString());
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
                        //    Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �d���於
                        //    position = Int32.Parse(gridPattern[12].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Caption = "�d���於";
                        //    Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // UOE���}�[�N1
                        //    position = Int32.Parse(gridPattern[13].ToString());
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Caption = "UOE���}�[�N1";
                        //    Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.UoeRemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }
      
                        //    // UOE���}�[�N2
                        //    position = Int32.Parse(gridPattern[14].ToString());
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Caption = "UOE���}�[�N2";
                        //    Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.UoeRemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �d��SEQ/�x��No
                        //    position = Int32.Parse(gridPattern[15].ToString());
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Caption = "�d��SEQ/�x��No";
                        //    Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �v���
                        //    position = Int32.Parse(gridPattern[16].ToString());
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���|�敪��
                        //    position = Int32.Parse(gridPattern[17].ToString());
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �ԓ`�敪
                        //    position = Int32.Parse(gridPattern[18].ToString());
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcList.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    #endregion
                        //}

                        //#region �J�����`���[�U�ݒ�

                        ////--------------------------------------------------------------------------------
                        ////  �J�����`���[�U��L���ɂ���
                        ////--------------------------------------------------------------------------------
                        //this.uGrid_ColumnItemSelector.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorWidth = 24;

                        //// �J�����`���[�U�{�^���̊O�ς�ݒ�
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        //this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinGroup;

                        //#endregion // �J�����`���[�U�ݒ�

                        //// �񕝎���������ݒ�l�ɂ��������čs��
                        //autoColumnAdjust(false, 0);

                        //#endregion // �`�[
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Slip ) )
                        {
                            getGridSettingPattern( this._gridSetting_Slip, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _slipColCollection )
                        {
                            // ----------ADD 2013/01/21----------->>>>>
                            // �I��p�̃`�F�b�N�{�b�N�X�͏��O
                            if (orgCol.Key == _dataSet.StcList.SelectionColumn.ColumnName) continue;
                            // ----------ADD 2013/01/21-----------<<<<<

                            // �J�����`���[�U���珜�O����Ă��鍀�ڂ͓�������p�Ƃ݂Ȃ��ď��O
                            if ( orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True ) continue;

                            // ���J��������R�s�[
                            Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                            Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                            Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                            // �l�Z�b�g
                            Columns[orgCol.Key].Hidden = false;
                            Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                            Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                            if ( !string.IsNullOrEmpty( _gridSetting_Slip ) )
                            {
                                // �ݒ肠��
                                position = GetColumnPositionOfSlip( gridPattern, orgCol.Key );
                                //if ( position > 100 )  // DEL 2013/04/16 gezh FOR Redmine#35309
                                if (position >= 100)  // ADD 2013/04/16 gezh FOR Redmine#35309
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - 100;
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
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // �J�����`���[�U�ݒ�

                        // �񕝎���������ݒ�l�ɂ��������čs��
                        autoColumnAdjust( false, 0 );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                        break;
                    }
                case 1:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                        # region // DEL
                        //#region ����

                        //// �ݒ肪����΂���ɏ]���A�Ȃ���ΑS�\��
                        //if (String.IsNullOrEmpty(this._gridSetting_Detail))
                        //{
                        //    #region ���׃O���b�h�w�b�_�쐬�i�ݒ�Ȃ��j

                        //    // �`�[���t
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �`�[�ԍ�
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �sNo
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Caption = "�sNo";
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �敪��
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �S���Җ�
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���z
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �i��
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �i��
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���[�J�[�R�[�h
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "���[�J�[�R�[�h";
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���[�J�[
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Caption = "���[�J�[";
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BL�R�[�h
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����";
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // BL�O���[�v
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BL��ٰ��";
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
                        //    // �d������
                        //    //Columns[this._dataSet.StcDetail.stockuni.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "�W�����i";
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD

                        //    // ����
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Caption = "����";
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �W�����i
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "�W�����i";
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �����
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�P
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���l�Q
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���_�R�[�h
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Caption = "���_�R�[�h";
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���_
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // 2008.12.05 del start [8726]
                        //    // ���s��
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        //    // 2008.12.05 del end [8726]

                        //    // �d����R�[�h
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �d����
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Caption = "�d����";
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �݌Ɏ��敪
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Caption = "�݌Ɏ��敪";
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �q�ɃR�[�h
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Caption = "�q�ɃR�[�h";
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �q��
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Caption = "�q��";
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �I��
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Caption = "�I��";
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N�P
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Caption = "UOE���}�[�N�P";
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // UOE���}�[�N�Q
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Caption = "UOE���}�[�N�Q";
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �d��SEQ/�x��No
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "�d��SEQ/�x��No";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �v���
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���|�敪��
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // �ԓ`�敪
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ��������`�[�ԍ�
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "��������`�[�ԍ�";
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ����������t
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Caption = "����������t";
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ�R�[�h
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    // ���Ӑ於
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ於";
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        //    #endregion // ���׃O���b�h�w�b�_�쐬�i�ݒ�Ȃ��j
                        //}
                        //else
                        //{
                        //    #region ���׃O���b�h�w�b�_�쐬�i�ݒ肠��j

                        //    string[] gridPattern = new string[35];
                        //    getGridSettingPattern(this._gridSetting_Detail, out gridPattern, false);

                        //    int position = 0;

                        //    // �`�[���t
                        //    position = Int32.Parse(gridPattern[0].ToString());
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Caption = "�`�[���t";
                        //    Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �`�[�ԍ�
                        //    position = Int32.Parse(gridPattern[1].ToString());
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
                        //    Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �sNo
                        //    position = Int32.Parse(gridPattern[2].ToString());
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Caption = "�sNo";
                        //    Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockRowNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �敪��
                        //    position = Int32.Parse(gridPattern[3].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "�敪";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �S���Җ�
                        //    position = Int32.Parse(gridPattern[4].ToString());
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Caption = "�S���Җ�";
                        //    Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockAgentNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���z
                        //    position = Int32.Parse(gridPattern[5].ToString());
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Caption = "���z";
                        //    Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �i��
                        //    position = Int32.Parse(gridPattern[6].ToString());
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �i��
                        //    position = Int32.Parse(gridPattern[7].ToString());
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Caption = "�i��";
                        //    Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // ���[�J�[�R�[�h
                        //    position = Int32.Parse(gridPattern[8].ToString());
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "���[�J�[�R�[�h";
                        //    Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���[�J�[
                        //    position = Int32.Parse(gridPattern[9].ToString());
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Caption = "���[�J�[";
                        //    Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // BL�R�[�h
                        //    position = Int32.Parse(gridPattern[10].ToString());
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����";
                        //    Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // BL�O���[�v
                        //    position = Int32.Parse(gridPattern[11].ToString());
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Caption = "BL��ٰ��";
                        //    Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.BLGroupCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // ����
                        //    position = Int32.Parse(gridPattern[12].ToString());
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Caption = "����";
                        //    Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockCountColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // �W�����i
                        //    position = Int32.Parse(gridPattern[13].ToString());
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "�W�����i";
                        //    Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // �����
                        //    position = Int32.Parse(gridPattern[14].ToString());
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Caption = "�����";
                        //    Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // ���l�P
                        //    position = Int32.Parse(gridPattern[15].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Caption = "���l�P";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���l�Q
                        //    position = Int32.Parse(gridPattern[16].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Caption = "���l�Q";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���_�R�[�h
                        //    position = Int32.Parse(gridPattern[17].ToString());
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Caption = "���_�R�[�h";
                        //    Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SectionCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // ���_
                        //    position = Int32.Parse(gridPattern[18].ToString());
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Caption = "���_";
                        //    Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }


                        //    // 2008.12.05 del start [8726]
                        //    // ���s��
                        //    //position = Int32.Parse(gridPattern[19].ToString());
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Caption = "���s��";
                        //    //Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    //if (position > 100)
                        //    //{
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Hidden = true;
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    //}
                        //    //else
                        //    //{
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Hidden = false;
                        //    //    Columns[this._dataSet.StcDetail.StockInputNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    //}
                        //    // 2008.12.05 del end [8726]

                        //    // �d����R�[�h
                        //    position = Int32.Parse(gridPattern[20].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Caption = "�d����R�[�h";
                        //    Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �d����
                        //    position = Int32.Parse(gridPattern[21].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Caption = "�d����";
                        //    Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �݌Ɏ��敪
                        //    position = Int32.Parse(gridPattern[22].ToString());
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Caption = "�݌Ɏ��敪";
                        //    Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �q�ɃR�[�h
                        //    position = Int32.Parse(gridPattern[23].ToString());
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Caption = "�q�ɃR�[�h";
                        //    Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.WarehouseCdColumn.ColumnName].Header.VisiblePosition = position;
                        //    }

                        //    // �q��
                        //    position = Int32.Parse(gridPattern[24].ToString());
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Caption = "�q��";
                        //    Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // �I��
                        //    position = Int32.Parse(gridPattern[25].ToString());
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Caption = "�I��";
                        //    Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // UOE���}�[�N�P
                        //    position = Int32.Parse(gridPattern[26].ToString());
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Caption = "UOE���}�[�N�P";
                        //    Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.UoeRemark1Column.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // UOE���}�[�N�Q
                        //    position = Int32.Parse(gridPattern[27].ToString());
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Caption = "UOE���}�[�N�Q";
                        //    Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.UoeRemark2Column.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // �d��SEQ/�x��No
                        //    position = Int32.Parse(gridPattern[28].ToString());
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Caption = "�d��SEQ/�x��No";
                        //    Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // �v���
                        //    position = Int32.Parse(gridPattern[29].ToString());
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Caption = "�v���";
                        //    Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // ���|�敪��
                        //    position = Int32.Parse(gridPattern[30].ToString());
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Caption = "���|�敪";
                        //    Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // �ԓ`�敪
                        //    position = Int32.Parse(gridPattern[31].ToString());
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Caption = "�ԓ`�敪";
                        //    Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.DebitNoteDivColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
             
                        //    // ��������`�[�ԍ�
                        //    position = Int32.Parse(gridPattern[32].ToString());
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "��������`�[�ԍ�";
                        //    Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // ����������t
                        //    position = Int32.Parse(gridPattern[33].ToString());
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Caption = "����������t";
                        //    Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.SalesDateColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                            
                        //    // ���Ӑ�R�[�h
                        //    position = Int32.Parse(gridPattern[34].ToString());
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
                        //    Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                           
                        //    // ���Ӑ於
                        //    position = Int32.Parse(gridPattern[35].ToString());
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Caption = "���Ӑ於";
                        //    Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        //    if (position > 100)
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Hidden = true;
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position - 100;
                        //    }
                        //    else
                        //    {
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Hidden = false;
                        //        Columns[this._dataSet.StcDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = position;
                        //    }
                        
                        //    #endregion // ���׃O���b�h�w�b�_�쐬�i�ݒ肠��j
                        //}

                        //#region �J�����`���[�U�ݒ�

                        ////--------------------------------------------------------------------------------
                        ////  �J�����`���[�U��L���ɂ���
                        ////--------------------------------------------------------------------------------
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorWidth = 24;

                        //// �J�����`���[�U�{�^���̊O�ς�ݒ�		
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        //this.uGrid_ColumnItemSelector2.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        //this.uGrid_ColumnItemSelector2.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinGroup;


                        //#endregion // �J�����`���[�U�ݒ�

                        //// �񕝎���������ݒ�l�ɂ��������čs��
                        //autoColumnAdjust(false, 1);

                        //#endregion //����
                        # endregion
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                        string[] gridPattern = new string[0];
                        if ( !string.IsNullOrEmpty( _gridSetting_Detail ) )
                        {
                            getGridSettingPattern( this._gridSetting_Detail, out gridPattern, true );
                        }

                        int position = 0;


                        foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn orgCol in _detailColCollection )
                        {
                            // ----------ADD 2013/01/21----------->>>>>
                            // �I��p�̃`�F�b�N�{�b�N�X�͏��O
                            if (orgCol.Key == _dataSet.StcDetail.SelectionCheckColumn.ColumnName) continue;
                            // ----------ADD 2013/01/21-----------<<<<<

                            // �J�����`���[�U���珜�O����Ă��鍀�ڂ͓�������p�Ƃ݂Ȃ��ď��O
                            if ( orgCol.ExcludeFromColumnChooser == Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True ) continue;

                            // ���J��������R�s�[
                            Columns[orgCol.Key].CellAppearance.TextHAlign = orgCol.CellAppearance.TextHAlign;
                            Columns[orgCol.Key].Header.Caption = orgCol.Header.Caption;
                            Columns[orgCol.Key].Header.Appearance.TextHAlign = orgCol.Header.Appearance.TextHAlign;
                            // �l�Z�b�g
                            Columns[orgCol.Key].Hidden = false;
                            Columns[orgCol.Key].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
                            Columns[orgCol.Key].Header.VisiblePosition = visiblePosition++;

                            if ( !string.IsNullOrEmpty( _gridSetting_Detail ) )
                            {
                                // �ݒ肠��
                                position = GetColumnPositionOfDetail( gridPattern, orgCol.Key );
                                //if ( position > 100 )  // DEL 2013/04/16 gezh FOR Redmine#35309
                                if (position >= 100)  // ADD 2013/04/16 gezh FOR Redmine#35309
                                {
                                    Columns[orgCol.Key].Hidden = true;
                                    Columns[orgCol.Key].Header.VisiblePosition = position - 100;
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
                        this.uGrid_ColumnItemSelector2.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorWidth = 24;

                        // �J�����`���[�U�{�^���̊O�ς�ݒ�		
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb( 89, 135, 214 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb( 7, 59, 150 );
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
                        this.uGrid_ColumnItemSelector2.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
                        this.uGrid_ColumnItemSelector2.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

                        #endregion // �J�����`���[�U�ݒ�

                        // �񕝎���������ݒ�l�ɂ��������čs��
                        autoColumnAdjust( false, 1 );

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

                        break;
                    }
                default: break;
            }

            // �O�ϐݒ�
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // �O�ϐݒ�
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_ColumnItemSelector2.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

        }

        /// <summary>
        /// �񕝎�������
        /// </summary>
        /// <param name="autoAdjust">�����������邩�ǂ���</param>
        /// <param name="targetGrid">�ΏۂƂȂ�O���b�h 0:�`�[�ꗗ, 1:����</param>
        private void autoColumnAdjust(bool autoAdjust, int targetGrid)
        {
            switch (targetGrid)
            {
                case 0:
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
                            this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                case 1:
                    {
                        // ���������v���p�e�B�𒲐�
                        if (autoAdjust)
                        {
                            this.uGrid_ColumnItemSelector2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_ColumnItemSelector2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // �S�Ă̗�ŃT�C�Y����
                        for (int i = 0; i < this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// ���͒l�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool checkValues()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// �t�@�C����
            //if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
            //{
            //    string path =this.tEdit_SettingFileName.Text.Trim();
            //    if (!path.Contains("\\"))
            //    {
            //        return false;
            //    }
            //    else if (Directory.Exists(path))
            //    {
            //        // dirPath�̃f�B���N�g���͑��݂���
            //        path = path.Substring(0, path.IndexOf("\\"));
            //        if (!Directory.Exists(path)) return false;
            //    } 
            //    return false;
            //}
            
            //// �p�^�[����
            //if (String.IsNullOrEmpty(this.tComboEditor_PetternSelect.Text.Trim())) return false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            // �t�@�C����
            // 2010/04/05 Add �e�L�X�g�o�̓I�v�V�����������Ă��Ȃ��ꍇ�̓`�F�b�N���Ȃ� >>>
            if (this._opt_TextOutput == (int)Option.ON)
            {
                // --- DEL 2010/09/28 ��Q�� #15619 ---------->>>>>
                // 2010/04/05 Add <<<
                //if (String.IsNullOrEmpty(this.tEdit_SettingFileName.Text.Trim()))
                //{
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOFILENAME, -1, MessageBoxButtons.OK);
                //    this.tEdit_SettingFileName.Focus();
                //    return false;
                //}
                // --- DEL 2010/09/28 ��Q�� #15619 ----------<<<<<
            }   // 2010/04/05 Add

            // �p�^�[����
            if ( String.IsNullOrEmpty( this.tComboEditor_PetternSelect.Text.Trim() ) )
            {
                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MSG_OUTPUTTEXT_NOPATTERN, -1, MessageBoxButtons.OK );
                this.tComboEditor_PetternSelect.Focus();
                return false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            return true;
        }

        /// <summary>
        /// �p�^�[�����X�V
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void renewalOutputPattern(bool isDelete)
        {
            if (!isDelete)
            {
                // ���O
                string selectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();
                //string value01 = this.uOptionSet_DividerChar.CheckedIndex.ToString();
                string value01 = this.DividerChar.ToString();
                string value02 = this.tEdit_DividerChar.Text.Trim();
                //string value03 = this.uOptionSet_Parenthesis.CheckedIndex.ToString();
                string value03 = this.Parenthesis.ToString();
                string value04 = this.tEdit_ParenthesisChar.Text.Trim();
                //string value05 = this.uOptionSet_TieNumeric.CheckedIndex.ToString();
                string value05 = this.TieNumeric.ToString();
                //string value06 = this.uOptionSet_TieChar.CheckedIndex.ToString();
                string value06 = this.TieChar.ToString();
                //string value07 = this.uOptionSet_TitleLine.CheckedIndex.ToString();
                string value07 = this.TitleLine.ToString();

                // �O���b�h����ݒ�l���擾
                string value08 = string.Empty;
                createGridPatternString(true, out value08);
                string value09 = string.Empty;
                createGridPatternString(false, out value09);
                //string value08 = "00100200300400500600700800901001101201301401501601701801902021022023024025026027028029030031032";
                //string value09 = "010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657";
                string value10 = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                string value11 = this.tComboEditor_OutputType.SelectedItem.DataValue.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                string value12 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Saleslip.Checked)
                {
                    // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v���`�F�b�N�I������ꍇ�A�u1�v�Ƃ���
                    value12 = "1";
                }
                else
                {
                    // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v���`�F�b�N�I�t����ꍇ�A�u0�v�Ƃ���
                    value12 = "0";
                }

                string value13 = string.Empty;
                if (this.uCheckEditor_RetSlipMinus_Meisai.Checked)
                {
                    // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v���`�F�b�N�I������ꍇ�A�u1�v�Ƃ���
                    value13 = "1";
                }
                else
                {
                    // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v���`�F�b�N�I�t����ꍇ�A�u0�v�Ƃ���
                    value13 = "0";
                }
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                // �S�ĘA��
                string convinedStr = selectedPatternName + this._divider +
                        value01 + this._divider + value02 + this._divider +
                        value03 + this._divider + value04 + this._divider +
                        value05 + this._divider + value06 + this._divider +
                        value07 + this._divider + value08 + this._divider +
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
                        //value09 + this._divider + value10;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
                        value09 + this._divider +
                        value10 + this._divider +
                        //value11; // DEL 2015/09/17 �c���� Redmine#47006
                        //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                        value11 + this._divider +
                        value12 + this._divider +
                        value13;
                        //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD
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
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                            //if (pName == this._selectedPattern)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            if ( pName == selectedPatternName )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
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
        /// <param name="isSlip"></param>
        /// <param name="patternString"></param>
        private void createGridPatternString(bool isSlip, out string patternString)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            # region // DEL
            //patternString = string.Empty;

            //if (isSlip)
            //{
            //    #region �`�[�O���b�h

            //    string[] gridHeaderPattern = new string[18];

            //    Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
            //    //if (col[0].Header.Caption == "
            //    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
            //    {
            //        switch (column.Header.Caption)
            //        {
            //            case "�`�[���t":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�`�[�ԍ�":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�敪":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�S���Җ�":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���z":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�����":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���l�P":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���l�Q":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���_�R�[�h":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���_":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            // 2008.12.05 del start [8726]
            //            //case "���s��":
            //            //    {
            //            //        if (column.Hidden)
            //            //            gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        else
            //            //            gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        break;
            //            //    }
            //            // 2008.12.05 del end [8726]
            //            case "�d����R�[�h":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�d���於":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOE���}�[�N1":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOE���}�[�N2":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�d��SEQ/�x��No":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�v���":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���|�敪":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�ԓ`�敪":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            default: break;
            //        }
            //    }

            //    // ��̏��ɕ��Ԃ悤�ɕ�������쐬�i���Ԃ��قȂ�Ɛ���ɏC���ł��Ȃ��j
            //    for (int i = 0; i < 18; i++)
            //    {
            //        patternString = patternString + gridHeaderPattern[i];
            //    }

            //    #endregion // �`�[�O���b�h
            //}
            //else
            //{
            //    #region ���׃O���b�h

            //    string[] gridHeaderPattern = new string[35];

            //    // UI�ɕ\������Ă������DisplayLayout������K�v������
            //    Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns;
                
            //    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in col)
            //    {
            //        switch (column.Header.Caption)
            //        {
            //            case "�`�[���t":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[0] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[0] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�`�[�ԍ�":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[1] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[1] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�sNo":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[2] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[2] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�敪":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[3] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[3] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�S���Җ�":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[4] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[4] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���z":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[5] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[5] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�i��":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[6] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[6] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�i��":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[7] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[7] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���[�J�[�R�[�h":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[8] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[8] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���[�J�[":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[9] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[9] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "BL����":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[10] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[10] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "BL��ٰ��":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[11] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[11] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "����":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[12] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[12] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�W�����i":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[13] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[13] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�����":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[14] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[14] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���l�P":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[15] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[15] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���l�Q":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[16] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[16] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���_�R�[�h":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[17] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[17] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���_":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[18] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[18] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            // 2008.12.05 del start [8726]
            //            //case "���s��":
            //            //    {
            //            //        if (column.Hidden)
            //            //            gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        else
            //            //            gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //            //        break;
            //            //    }
            //            // 2008.12.05 del end [8726]
            //            case "�d����R�[�h":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[19] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[19] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�d����":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[20] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[20] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�݌Ɏ��敪":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[21] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[21] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�q�ɃR�[�h":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[22] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[22] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�q��":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[23] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[23] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�I��":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[24] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[24] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOE���}�[�N�P":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[25] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[25] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "UOE���}�[�N�Q":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[26] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[26] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�d��SEQ/�x��No":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[27] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[27] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�v���":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[28] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[28] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���|�敪":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[29] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[29] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "�ԓ`�敪":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[30] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[30] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "��������`�[�ԍ�":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[31] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[31] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "����������t":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[32] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[32] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���Ӑ�R�[�h":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[33] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[33] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }
            //            case "���Ӑ於":
            //                {
            //                    if (column.Hidden)
            //                        gridHeaderPattern[34] = "1" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    else
            //                        gridHeaderPattern[34] = "0" + column.Header.VisiblePosition.ToString().PadLeft(2, '0');
            //                    break;
            //                }

            //            default: break;
            //        }
            //    }

            //    // ��̏��ɕ��Ԃ悤�ɕ�������쐬�i���Ԃ��قȂ�Ɛ���ɏC���ł��Ȃ��j
            //    for (int i = 0; i < 35; i++)
            //    {
            //        patternString = patternString + gridHeaderPattern[i];
            //    }

            //    #endregion // ���׃O���b�h
            //}
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            patternString = string.Empty;

            if ( isSlip )
            {
                #region �`�[�O���b�h
                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector.DisplayLayout.Bands[0].Columns;
                string[] gridHeaderPattern = new string[col.Count];
                foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in col )
                {
                    if ( _columnIndexDicOfSlip.ContainsKey( column.Key ) )
                    {
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfSlip[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                    }
                }
                for ( int i = 0; i < col.Count; i++ )
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                # endregion
            }
            else
            {
                #region ���׃O���b�h

                // UI�ɕ\������Ă������DisplayLayout������K�v������
                Infragistics.Win.UltraWinGrid.ColumnsCollection col = this.uGrid_ColumnItemSelector2.DisplayLayout.Bands[0].Columns;
                string[] gridHeaderPattern = new string[col.Count];

                foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in col )
                {
                    if ( _columnIndexDicOfDetail.ContainsKey( column.Key ) )
                    {
                        if ( column.Hidden )
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "1" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                        else
                        {
                            gridHeaderPattern[_columnIndexDicOfDetail[column.Key]] = "0" + column.Header.VisiblePosition.ToString().PadLeft( 2, '0' );
                        }
                    }
                }
                for ( int i = 0; i < col.Count; i++ )
                {
                    patternString = patternString + gridHeaderPattern[i];
                }

                # endregion
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        }

        /// <summary>
        /// ��{�p�^�[����ǉ�
        /// </summary>
        /// <param name="outputStyle"></param>
        /// <param name="patternString"></param>
        /// <param name="addPattern"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            string value11 = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
            string value12 = string.Empty; // ADD 2015/09/17 �c���� Redmine#47006
            string value13 = string.Empty; // ADD 2015/09/17 �c���� Redmine#47006

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
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "0";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
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
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "1";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
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
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                        //value07 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value07 = "0";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value08 = string.Empty;
                        value09 = string.Empty;
                        value10 = "2";
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        value11 = "1";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        value12 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        value13 = "1"; // ADD 2015/09/17 �c���� Redmine#47006
                        break;
                    }

                default: break;
            }
            patternString = selectedPatternName + this._divider +
                value01 + this._divider + value02 + this._divider +
                value03 + this._divider + value04 + this._divider +
                value05 + this._divider + value06 + this._divider +
                value07 + this._divider + value08 + this._divider +
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                //value09 + this._divider + value10;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                value09 + this._divider + value10 + this._divider +
                //value11; // DEL 2015/09/17 �c���� Redmine#47006
                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                value11 + this._divider +
                value12 + this._divider +
                value13;
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

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
                            //if (pName == this._selectedPattern)
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
        /// �d����d�q�����p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����d�q�����p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        public void Serialize()
        {
            // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
            //UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<
            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// �d����d�q�����p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����d�q�����p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note : 2013/01/21 FSI�y�~ �їR��</br>
        /// <br>              [�d���ԕi�\��@�\] �I���`�F�b�N�{�b�N�X�̕⊮������ǉ�</br>
        /// </remarks>
        public void Deserialize()
        {
            // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //this._userSetting = UserSettingController.DeserializeUserSetting<SuppPtrStcUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                try
                {
                    // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
                    //this._userSetting = UserSettingController.DeserializeUserSetting<SuppPtrStcUserConst>( Path.Combine( ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME ) );
                    this._userSetting = UserSettingController.DeserializeUserSetting<SuppPtrStcUserConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                    // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<

                    // ----------ADD 2013/01/21----------->>>>>
                    // �I���`�F�b�N�{�b�N�X�i�`�[�\���p�j�̃��[�U�[�ݒ�̕⊮����
                    bool SelectionFlg = false;

                    foreach (ColumnInfo SlipColumnInfo in this._userSetting.SlipColumnsList)
                    {
                        if (SlipColumnInfo.ColumnName == "Selection")
                        {
                            // �I���`�F�b�N�{�b�N�X�i�`�[�\���p�j�̐ݒ肪���݂��Ă���
                            SelectionFlg = true;
                            break;
                        }
                    }

                    // �I���`�F�b�N�{�b�N�X�i�`�[�\���p�j�̐ݒ肪���݂��Ă��Ȃ��ꍇ�͕⊮���s��
                    if (SelectionFlg != true)
                    {
                        // ���я��̍Đݒ�
                        for (int i = 0; i < this._userSetting.SlipColumnsList.Count; i++)
                        {
                            ColumnInfo tempSlipColumns = this._userSetting.SlipColumnsList[i];

                            // �I���`�F�b�N�{�b�N�X�i�`�[�\���p�j��}�����邽�߁A���я���1���ɂ��炷
                            tempSlipColumns.VisiblePosition = this._userSetting.SlipColumnsList[i].VisiblePosition + 1;

                            this._userSetting.SlipColumnsList[i] = tempSlipColumns;
                        }

                        // �I���`�F�b�N�{�b�N�X�i�`�[�\���p�j����ԍ��ɂȂ�悤�ɏ����ݒ�l�ő}��
                        this._userSetting.SlipColumnsList.Insert(0, new ColumnInfo("Selection", 0, false, 50, true));
                    }

                    // �I���`�F�b�N�{�b�N�X�i���ו\���p�j�̃��[�U�[�ݒ�̕⊮����
                    bool SelectionCheckFlg = false;

                    foreach (ColumnInfo DetailColumnInfo in this._userSetting.DetailColumnsList)
                    {
                        if (DetailColumnInfo.ColumnName == "SelectionCheck")
                        {
                            // �I���`�F�b�N�{�b�N�X�i���ו\���p�j�̐ݒ肪���݂��Ă���
                            SelectionCheckFlg = true;
                            break;
                        }
                    }

                    // �I���`�F�b�N�{�b�N�X�i���ו\���p�j�̐ݒ肪���݂��Ă��Ȃ��ꍇ�͕⊮���s��
                    if (SelectionCheckFlg != true)
                    {
                        // ���я��̍Đݒ�
                        for (int i = 0; i < this._userSetting.DetailColumnsList.Count; i++)
                        {
                            ColumnInfo tempDetailColumns = this._userSetting.DetailColumnsList[i];

                            // �I���`�F�b�N�{�b�N�X�i���ו\���p�j��}�����邽�߁A���я���1���ɂ��炷
                            tempDetailColumns.VisiblePosition = this._userSetting.DetailColumnsList[i].VisiblePosition + 1;

                            this._userSetting.DetailColumnsList[i] = tempDetailColumns;
                        }

                        // �I���`�F�b�N�{�b�N�X�i���ו\���p�j����ԍ��ɂȂ�悤�ɏ����ݒ�l�ő}��
                        this._userSetting.DetailColumnsList.Insert(0, new ColumnInfo("SelectionCheck", 0, false, 50, true));
                    }
                    // ----------ADD 2013/01/21-----------<<<<<
                }
                catch
                {
                    this._userSetting = new SuppPtrStcUserConst();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            }
        }


        /// <summary>
        /// �d����d�q�����p���[�U�[�ݒ� �ݒ���e��������
        /// </summary>
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
            // �`�[�o�͍��ڃ��X�g (32����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesList�̏��ɕ���ł���   7
            // ���׏o�͍��ڃ��X�g (57����x3����) ��{�I�ɕ\�����̐���,��\���̏ꍇ��+100, �K��ExportColumnDataSet.SalesDetail�̏��ɕ���ł��� 8

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
        public List<String> GetColumnNameList(string sourceStr, bool isSlip)
        {
            List<String> columnList;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //if (isSlip)
            //{
            //    columnList = new List<String>();//[32];
            //    string[] p = new string[18];
            //    getGridSettingPattern(sourceStr, out p, true);

            //    for (int i = 0; i < 18; i++)
            //    {
            //        columnList.Add(p[i]);
            //    }
            //}
            //else
            //{
            //    columnList = new List<String>();//[57];
            //    string[] p = new string[35];
            //    getGridSettingPattern(sourceStr, out p, true);

            //    for (int i = 0; i < 35; i++)
            //    {
            //        columnList.Add(p[i]);
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            columnList = new List<String>();
            string[] p;
            getGridSettingPattern( sourceStr, out p, true );

            for ( int i = 0; i < p.Length; i++ )
            {
                columnList.Add( p[i] );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

            return columnList;
        }

        #endregion // ���[�U�[�ݒ�̕ۑ��E�ǂݍ���

        #region �C�x���g

        /// <summary>
        /// �o�͌`���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uComboEditor_OutputStyle_ValueChanged(object sender, EventArgs e)
        {
            // �I��l
            string selected = this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString();
            string fileName = this.tEdit_SettingFileName.Text.Trim();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //string ext = string.Empty;
            //if (fileName.Length > 4) ext = fileName.Substring(fileName.Length - 4, 4);

            //string newExt = string.Empty;
            //switch (selected)
            //{
            //    case "0": newExt = ".CSV"; break;
            //    case "1": newExt = ".TXT"; break;
            //    case "2": newExt = ".PRN"; break;
            //    case "3": newExt = ext; break;
            //    default:break;
            //}
            //if (fileName.Length > 4)
            //{
                
            //    if (ext.Contains("."))
            //    {
            //        if (ext.ToLower() == ".txt" || ext.ToLower() == ".prn" || ext.ToLower() == ".csv")
            //        {
            //            fileName = fileName.ToUpper().Replace(".TXT", newExt).Replace(".PRN", newExt).Replace(".CSV", newExt);
            //        }
            //    }
            //    else if (fileName.Contains("."))
            //    {
            //        fileName = fileName.Substring(1, fileName.IndexOf(".", 1)) + newExt;
            //    }
            //    else
            //    {
            //        fileName = fileName + newExt;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            fileName = SuppPtrStcUserConst.ChangeFileExtension( fileName, selected );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            this.tEdit_SettingFileName.Text = fileName;

            // �J�X�^���̂Ƃ��̂ݗL��
            bool val = (this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() == "3");

            // ���ڂ𒲐�
            //this.uOptionSet_DividerChar.Enabled = val;
            this.pn_DividerChar.Enabled = val;
            //this.uOptionSet_Parenthesis.Enabled = val;
            this.pn_Parenthesis.Enabled = val;
            //this.uOptionSet_TieChar.Enabled = val;
            this.pn_TieChar.Enabled = val;
            //this.uOptionSet_TieNumeric.Enabled = val;
            this.pn_TieNumeric.Enabled = val;
            //this.uOptionSet_TitleLine.Enabled = val;
            this.pn_TitleLine.Enabled = val;

            this.tEdit_DividerChar.Enabled = val;
            this.tEdit_ParenthesisChar.Enabled = val;

            //this.uComboEditor_OutputType.Enabled = val;

            //this.uGrid_ColumnItemSelector.Enabled = val;
            //this.uGrid_ColumnItemSelector2.Enabled = val;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
            //if (val) this.tComboEditor_PetternSelect.Text = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
        }

        /// <summary>
        /// �o�̓^�C�v�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void uComboEditor_OutputType_ValueChanged(object sender, EventArgs e)
        {

            if (this.tComboEditor_OutputType.SelectedItem.DataValue.ToString() == "0") //�`�[
            {
                this.uGrid_ColumnItemSelector.Visible = true;
                this.uGrid_ColumnItemSelector2.Visible = false;

                // ----- ADD 2015/09/17 �c���� Redmine#47006 ----->>>>>
                this.uCheckEditor_RetSlipMinus_Meisai.Visible = false;
                this.uCheckEditor_RetSlipMinus_Meisai.Enabled = false;
                this.uCheckEditor_RetSlipMinus_Saleslip.Enabled = true;
                this.uCheckEditor_RetSlipMinus_Saleslip.Visible = true;
                // ----- ADD 2015/09/17 �c���� Redmine#47006 -----<<<<<
            }
            else
            {
                this.uGrid_ColumnItemSelector.Visible = false;
                this.uGrid_ColumnItemSelector2.Visible = true;

                // ----- ADD 2015/09/17 �c���� Redmine#47006 ----->>>>>
                this.uCheckEditor_RetSlipMinus_Meisai.Enabled = true;
                this.uCheckEditor_RetSlipMinus_Meisai.Visible = true;
                this.uCheckEditor_RetSlipMinus_Saleslip.Visible = false;
                this.uCheckEditor_RetSlipMinus_Saleslip.Enabled = false;
                // ----- ADD 2015/09/17 �c���� Redmine#47006 -----<<<<<
            }
        }

        /// <summary>
        /// �p�^�[���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_PetternSelect_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            this._selectedPattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();
            getSelectedPattern();

        }

        #endregion // �C�x���g

        #region �{�^��

        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            //string str = string.Empty;
            //createGridPatternString(true, out str);
            //createGridPatternString(false, out str);

            //return;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 DEL
            //// �V���A���C�Y
            //this.Serialize();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this.DialogResult = DialogResult.Cancel;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            this.Close();
        }

        /// <summary>
        /// OK�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // �`�F�b�N
            if (!checkValues())
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                this.DialogResult = DialogResult.None;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                return;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //if (Int32.Parse(this.uComboEditor_OutputStyle.SelectedItem.DataValue.ToString()) == 3)
            //{
            //    renewalOutputPattern(false);
            //    this._userSetting.OutputStyle = 3;
            //}
            //else 
            //{
            //    renewalOutputPattern(false);
            //    this._userSetting.OutputStyle = Int32.Parse(this.uComboEditor_OutputStyle.SelectedItem.DataValue.ToString());
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            renewalOutputPattern( false );
            this._userSetting.OutputStyle = Int32.Parse( this.tComboEditor_OutputStyle.SelectedItem.DataValue.ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

            // �t�@�C����
            this._userSetting.OutputFileName = this.tEdit_SettingFileName.Text.Trim();

            // �p�^�[����
            this._userSetting.SelectedPatternName = this.tComboEditor_PetternSelect.Text.Trim();
            // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
            this._userSetting.SuplierFileName = this.tEdit_AccpayFileName.Text;
            this._userSetting.SuplAccFileName = this.tEdit_PaymentFileName.Text;
            // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<

            // �V���A���C�Y
            this.Serialize();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/24 ADD
            this.DialogResult = DialogResult.OK;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/24 ADD

            // �I��
            this.Close();
        }

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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            this.openFileDialog.Filter = string.Format( "{0} | {1}", "�t�@�C��(*.*)", "*.*" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                this.tEdit_SettingFileName.Text = openFileDialog.FileName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            }
        }

        #endregion // �{�^��


        /// <summary>
        /// �e�L�X�g�o�̓p�^�[���폜�{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_PaternDelete_Click( object sender, EventArgs e )
        {
            if ( this.tComboEditor_PetternSelect.SelectedItem == null ) return;

            // ���ݑI������Ă���p�^�[�����폜�ΏۂƂ���
            string deletePattern = this.tComboEditor_PetternSelect.SelectedItem.DataValue.ToString();

            // �m�F�_�C�A���O
            if ( TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_DELETE_PATTERN + Environment.NewLine + Environment.NewLine + string.Format( "�o�̓p�^�[���F{0}", deletePattern ),
                -1, MessageBoxButtons.YesNo ) == DialogResult.No )
            {
                return;
            }

            // �폜
            # region [�폜]
            // ���݂̃p�^�[���ꗗ�����X�g�Ɋi�[����
            List<string> patternList = new List<string>( _outputPattern );
            string pName = string.Empty;

            // ���v����p�^�[�������폜
            foreach ( string pattern in this._outputPattern )
            {
                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if ( pattern.Contains( this._divider ) )
                {
                    pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );

                    // �ݒ肳��Ă���p�^�[���̏ꍇ�͓��e���擾
                    if ( pName == deletePattern )
                    {
                        patternList.Remove( pattern );
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
            foreach ( string pattern in this._outputPattern )
            {
                item = new Infragistics.Win.ValueListItem();

                // �ŏ��̋�؂蕶���܂ł��p�^�[����
                if ( pattern.Contains( this._divider ) )
                {
                    pName = pattern.Substring( 0, pattern.IndexOf( this._divider ) );
                    item.DataValue = pName;
                    item.DisplayText = pName;

                    this.tComboEditor_PetternSelect.Items.Add( item );
                }
            }
            // �ŏ��̃p�^�[����I������
            if ( tComboEditor_PetternSelect.Items.Count > 0 )
            {
                tComboEditor_PetternSelect.SelectedIndex = 0;
            }
            else
            {
                tComboEditor_PetternSelect.Text = string.Empty;
            }
            # endregion

            //// ���ʃ_�C�A���O
            //TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //    "�폜���܂����B",
            //    -1, MessageBoxButtons.OK );
        }
        /// <summary>
        /// �p�^�[���e�L�X�g�ύX���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            // �폜�{�^���̗L����������
            uButton_PatternDelete.Enabled = (tComboEditor_PetternSelect.SelectedItem != null);
        }
        /// <summary>
        /// �ݒ�t�h�����\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKOU04004UA_Shown( object sender, EventArgs e )
        {
            tEdit_SettingFileName.Focus();
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// �������{�^���i�`�[�O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_SlipGrid_Click( object sender, EventArgs e )
        {
            InitializeSlipGrid( ref _userSetting );
            if ( this.ClearSettingSlipGrid != null )
            {
                this.ClearSettingSlipGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// �������{�^���i���׃O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_DetailGrid_Click( object sender, EventArgs e )
        {
            InitializeDetailGrid( ref _userSetting );
            if ( this.ClearSettingDetailGrid != null )
            {
                this.ClearSettingDetailGrid( this, new EventArgs() );
            }
        }
        /// <summary>
        /// �������{�^���i�c���O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_BalanceGrid_Click( object sender, EventArgs e )
        {
            InitializeBalanceGrid( ref _userSetting );
            if ( this.ClearSettingBalanceGrid != null )
            {
                this.ClearSettingBalanceGrid( this, new EventArgs() );
            }
        }
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>
        /// �������{�^���i�ԕi�v����̓O���b�h�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Clear_RetGoodsAddUpInpGrid_Click(object sender, EventArgs e)
        {
            InitializeRetGoodsAddUpInpGrid(ref _userSetting);
            if (this.ClearSettinRetGoodsAddUpInpGrid != null)
            {
                this.ClearSettinRetGoodsAddUpInpGrid(this, new EventArgs());
            }
        }
        // ----------ADD 2013/01/21-----------<<<<<

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2015/09/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170170-00</br>
        /// <br>           : Redmine#47006 ���s�ۏ�����邽�߉�ʂɋ敪��݂���</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            //if ( e.PrevCtrl == null || e.NextCtrl == null ) return;
            if ( e.PrevCtrl == null ) return;

            switch ( e.PrevCtrl.Name )
            {
                # region [�e�L�X�g�o��]
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
                    {
                        # region [���t�H�[�J�X]
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tComboEditor_OutputStyle;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = uButton_PatternDelete;
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;

                case "tComboEditor_OutputStyle":
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
                case "rb_TitleLine_1":
                case "tComboEditor_OutputType": // ADD 2015/09/17 �c���� Redmine#47006
                    {
                        // �����ڂ��擾
                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                        if ( nextControl != null )
                        {
                            e.NextCtrl = nextControl;
                        }
                    }
                    break;
                //----- DEL 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                //case "tComboEditor_OutputType":
                //    {
                //        if ( !e.ShiftKey )
                //        {
                //            switch ( e.Key )
                //            {
                //                case Keys.Down:
                //                    {
                //                        e.NextCtrl = e.PrevCtrl;
                //                    }
                //                    break;
                //                case Keys.Tab:
                //                case Keys.Return:
                //                    {
                //                        // ---------------------- DEL 2010/07/20 --------------------------------->>>>>
                //                        // �^�u�؂�ւ�
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // ������
                //                        e.NextCtrl = uButton_Clear_SlipGrid;
                //                        // ---------------------- DEL  2010/07/20 ---------------------------------<<<<<
                //                        // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
                //                        // �^�u�؂�ւ�
                //                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                //                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                //                        // ������
                //                        e.NextCtrl = tEdit_AccpayFileName;
                //                        // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<

                //                    }
                //                    break;
                //                default:
                //                    {
                //                        // �����ڂ��擾
                //                        Control nextControl = _focusControl1.GetNextControl( e.PrevCtrl, e.Key, e.ShiftKey );
                //                        if ( nextControl != null )
                //                        {
                //                            e.NextCtrl = nextControl;
                //                        }
                //                    }
                //                    break;
                //            }
                //        }
                //    }
                //    break;
                //----- DEL 2015/09/17 �c���� Redmine#47006 ----------<<<<<
                //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                case "uCheckEditor_RetSlipMinus_Saleslip": // �ԕi�`�[���z���}�C�i�X�ŏo�͂̋敪
                case "uCheckEditor_RetSlipMinus_Meisai": 
                    {

                        if (!e.ShiftKey)
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
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = tEdit_AccpayFileName;

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
                        else
                        {
                            // ������
                            e.NextCtrl = tComboEditor_OutputType;
                        }
                    }
                    break;
                //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<

                # endregion
                // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                #region [�c���o��]
                case "tEdit_AccpayFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_AccpayFileName.Text))
                                        {
                                            // ������
                                            e.NextCtrl = tEdit_PaymentFileName;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = uButton_AccpayFileName;
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
                                        if (uTabControl_Setting.Tabs["TextOutput"].Visible == true)
                                        {
                                            // �^�u�؂�ւ�
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            // ������
                                            //e.NextCtrl = tComboEditor_OutputType; // DEL 2015/09/17 �c���� Redmine#47006
                                            //----- ADD 2015/09/17 �c���� Redmine#47006 ---------->>>>>
                                            // ������
                                            if (this.tComboEditor_OutputType.SelectedItem.DataValue.ToString() == "0")
                                            {
                                                e.NextCtrl = uCheckEditor_RetSlipMinus_Saleslip; // �u�ԕi�`�[���z���}�C�i�X�ŏo�͂���v�̋敪
                                            }
                                            else
                                            {
                                                e.NextCtrl = uCheckEditor_RetSlipMinus_Meisai; // �u�}�C�i�X���z�ɂ̓}�C�i�X�L����t�^����v�̋敪
                                            }
                                            //----- ADD 2015/09/17 �c���� Redmine#47006 ----------<<<<<
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
                case "tEdit_PaymentFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_PaymentFileName.Text))
                                        {
                                            // ������
                                            uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                            uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                            e.NextCtrl = uButton_Clear_SlipGrid;
                                        }
                                        else
                                        {
                                            // �K�C�h�{�^��
                                            e.NextCtrl = uButton_PaymentFileName;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_PaymentFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ������
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["SettingClear"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        e.NextCtrl = uButton_Clear_SlipGrid;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                #endregion
                // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
                # region [�ݒ�N���A]
                case "uButton_Clear_SlipGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_SlipGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // ---------------------- DEL 2010/07/20 --------------------------------->>>>>
                                        // �^�u�؂�ւ�
                                        //uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["TextOutput"];
                                        //uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        //e.NextCtrl = tComboEditor_OutputType;
                                        // ---------------------- DEL  2010/07/20 --------------------------------->>>>>
                                        // ---------------------- ADD  2010/07/20 --------------------------------->>>>>
                                        // �^�u�؂�ւ�
                                        uTabControl_Setting.ActiveTab = uTabControl_Setting.Tabs["BalanceOutput"];
                                        uTabControl_Setting.SelectedTab = uTabControl_Setting.ActiveTab;
                                        // ������
                                        e.NextCtrl = uButton_PaymentFileName;
                                        // ---------------------- ADD  2010/07/20 ---------------------------------<<<<<
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_DetailGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Return:
                                    {
                                        uButton_Clear_DetailGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_Clear_BalanceGrid":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = uButton_OK;
                                    }
                                    break;
                                case Keys.Return:
                                    {
                                        uButton_Clear_BalanceGrid_Click( this, new EventArgs() );
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                # endregion
                    
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
        /// <summary>
        /// ��؂蕶��Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_0_Enter( object sender, EventArgs e )
        {
            this.DividerChar = prevDividerChar;
        }
        /// <summary>
        /// ��؂蕶��Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_0_Leave( object sender, EventArgs e )
        {
            prevDividerChar = this.DividerChar;
        }
        /// <summary>
        /// ��؂蕶��Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_DividerChar_1_CheckedChanged( object sender, EventArgs e )
        {
            if ( rb_DividerChar_1.Checked )
            {
                tEdit_DividerChar.Enabled = true;
            }
            else
            {
                tEdit_DividerChar.Enabled = false;
                tEdit_DividerChar.Clear();
            }
        }
        /// <summary>
        /// ���蕶��Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_0_Enter( object sender, EventArgs e )
        {
            this.Parenthesis = prevParenthesis;
        }
        /// <summary>
        /// ���蕶��Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_0_Leave( object sender, EventArgs e )
        {
            prevParenthesis = this.Parenthesis;
        }
        /// <summary>
        /// ���蕶��Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_Parenthesis_1_CheckedChanged( object sender, EventArgs e )
        {
            if ( rb_Parenthesis_1.Checked )
            {
                tEdit_ParenthesisChar.Enabled = true;
            }
            else
            {
                tEdit_ParenthesisChar.Enabled = false;
                tEdit_ParenthesisChar.Clear();
            }
        }
        /// <summary>
        /// ���l����Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieNumeric_0_Enter( object sender, EventArgs e )
        {
            this.TieNumeric = prevTieNumeric;
        }
        /// <summary>
        /// ���l����Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieNumeric_0_Leave( object sender, EventArgs e )
        {
            prevTieNumeric = this.TieNumeric;
        }
        /// <summary>
        /// ��������Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieChar_0_Enter( object sender, EventArgs e )
        {
            this.TieChar = prevTieChar;
        }
        /// <summary>
        /// ��������Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TieChar_0_Leave( object sender, EventArgs e )
        {
            prevTieChar = this.TieChar;
        }
        /// <summary>
        /// �^�C�g���sEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TitleLine_0_Enter( object sender, EventArgs e )
        {
            this.TitleLine = prevTitleLine;
        }
        /// <summary>
        /// �^�C�g���sLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_TitleLine_0_Leave( object sender, EventArgs e )
        {
            prevTitleLine = this.TitleLine;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // 2010/04/05 Add >>>
        /// <summary>
        /// �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\������
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/04/05</br>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        public void uTabControlSet(bool display)
        {
            //�e�L�X�g�o�̓I�v�V�����̗L���A�����Őݒ�̃e�L�X�g�o�̓^�u�̕\��������s���B
            uTabControl_Setting.Tabs["TextOutput"].Visible = display;
            if (display)
            {
                this._opt_TextOutput = (int)Option.ON;
            }
            else
            {
                this._opt_TextOutput = (int)Option.OFF;
            }

            uTabControl_Setting.Tabs["BalanceOutput"].Visible = display;  // ADD 2010/07/20 
        }
        // 2010/04/05 Add <<<

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// �t�@�C�����i�x���j�K�C�h�{�^��Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�@�C�����i�x���j�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_AccpayFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_AccpayFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_AccpayFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_AccpayFileName.Text = openFileDialog.FileName.ToUpper();
            }

        }

        /// <summary>
        /// �t�@�C�����i���|�j�K�C�h�{�^��Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�@�C�����i���|�j�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_PaymentFileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_PaymentFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_PaymentFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = string.Format("{0} | {1}", "�t�@�C��(*.*)", "*.*");

            // �t�@�C���I��
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_PaymentFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }
    }
    // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<

    /// <summary>
    /// �d����d�q�����p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����d�q�����̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SuppPtrStcUserConst
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

        // ���l�P�p�^�[��
        private int _slipNote1Pattern;

        // ���l�P�C��
        private string _slipNote1Default;

        // ���l�Q�p�^�[��
        private int _slipNote2Pattern;

        // ���l�Q�C��
        private string _slipNote2Default;

        // ���l�R�p�^�[��
        private int _slipNote3Pattern;

        // ���l�R�C��
        private string _slipNote3Default;

        /// <summary>���ڋ�؂蕶��</summary>
        private const string STRING_DIVIDER = "/";

        //private const int[] DEFAULT_VAL_SLIP = { 0, 0, 0, 2, 3, 0, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 0, 27, 28, 29, 30, 31, 0, 32, 33 };

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        // �L���ȏڍ׏������X�g
        private List<string> _enabledConditionList;

        // �`�[�O���b�h�J�������X�g
        private List<ColumnInfo> _slipColumnsList;
        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;
        // �c���O���b�h�J�������X�g
        private List<ColumnInfo> _balanceColumnsList;
        // ----------ADD 2013/01/21----------->>>>>
        // �ԕi�v����̓O���b�h�J�������X�g
        private List<ColumnInfo> _retGoodsAddUpInpColumnsList;
        // ----------ADD 2013/01/21-----------<<<<<

        // �ڍ׏����O���[�v�W�J���
        private bool _extraConditionExpanded;
        // ���v�\���O���[�v�W�J���
        private bool _balanceChartExpanded;

        // �`�[�O���b�h�����T�C�Y����
        private bool _autoAdjustSlip;
        // ���׃O���b�h�����T�C�Y����
        private bool _autoAdjustDetail;
        // �c���O���b�h�����T�C�Y����
        private bool _autoAdjustBalance;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // �ԕi�v����̓O���b�h�����T�C�Y����
        private bool _autoAdjustRetGoodsAddUpInp; // ADD  2013/01/21

        // �o�̓t�@�C�����i�x���j
        private string _suplierFileName;  // ADD 2010/07/20 

        // �o�̓t�@�C�����i���|�j
        private string _suplAccFileName;  // ADD 2010/07/20

        # endregion // �v���C�x�[�g�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// �d����d�q�������[�U�[�ݒ���N���X
        /// </summary>
        public SuppPtrStcUserConst()
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

        /// <summary>���l�P�p�^�[��</summary>
        public int SlipNote1Pattern
        {
            get { return this._slipNote1Pattern; }
            set { this._slipNote1Pattern = value; }
        }

        /// <summary>���l�P�C�Ӑݒ�</summary>
        public string SlipNote1Default
        {
            get { return this._slipNote1Default; }
            set { this._slipNote1Default = value; }
        }

        /// <summary>���l�Q�p�^�[��</summary>
        public int SlipNote2Pattern
        {
            get { return this._slipNote2Pattern; }
            set { this._slipNote2Pattern = value; }
        }

        /// <summary>���l�Q�C�Ӑݒ�</summary>
        public string SlipNote2Default
        {
            get { return this._slipNote2Default; }
            set { this._slipNote2Default = value; }
        }
        /// <summary>���l�R�p�^�[��</summary>
        public int SlipNote3Pattern
        {
            get { return this._slipNote3Pattern; }
            set { this._slipNote3Pattern = value; }
        }

        /// <summary>���l�R�C�Ӑݒ�</summary>
        public string SlipNote3Default
        {
            get { return this._slipNote3Default; }
            set { this._slipNote3Default = value; }
        }

        /// <summary>��؂蕶��</summary>
        public string DIVIDER
        {
            get { return STRING_DIVIDER; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>�L���ȏڍ׏������X�g</summary>
        public List<string> EnabledConditionList
        {
            get { return this._enabledConditionList; }
            set { this._enabledConditionList = value; }
        }
        /// <summary>�`�[�O���b�h�J�������X�g</summary>
        public List<ColumnInfo> SlipColumnsList
        {
            get { return this._slipColumnsList; }
            set { this._slipColumnsList = value; }
        }
        /// <summary>���׃O���b�h�J�������X�g</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }
        /// <summary>�c���O���b�h�J�������X�g</summary>
        public List<ColumnInfo> BalanceColumnsList
        {
            get { return this._balanceColumnsList; }
            set { this._balanceColumnsList = value; }
        }
        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>�ԕi�v����̓O���b�h�J�������X�g</summary>
        public List<ColumnInfo> RetGoodsAddUpInpColumnsList
        {
            get { return this._retGoodsAddUpInpColumnsList; }
            set { this._retGoodsAddUpInpColumnsList = value; }
        }
        // ----------ADD 2013/01/21-----------<<<<<
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
        /// <summary>�`�[�O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustSlip
        {
            get { return _autoAdjustSlip; }
            set { _autoAdjustSlip = value; }
        }
        /// <summary>���׃O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustDetail
        {
            get { return _autoAdjustDetail; }
            set { _autoAdjustDetail = value; }
        }
        /// <summary>�c���O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustBalance
        {
            get { return _autoAdjustBalance; }
            set { _autoAdjustBalance = value; }
        }

        // ----------ADD 2013/01/21----------->>>>>
        /// <summary>�ԕi�v����̓O���b�h�����T�C�Y����</summary>
        public bool AutoAdjustRetGoodsAddUpInp
        {
            get { return _autoAdjustRetGoodsAddUpInp; }
            set { _autoAdjustRetGoodsAddUpInp = value; }
        }
        // ----------ADD 2013/01/21-----------<<<<<
        
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        // �o�̓t�@�C�����i�x���j
        public string SuplierFileName
        {
            get { return this._suplierFileName; }
            set { this._suplierFileName = value; }
        }

        // �o�̓t�@�C�����i���|�j
        public string SuplAccFileName
        {
            get { return this._suplAccFileName; }
            set { this._suplAccFileName = value; }
        }
        // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
        # endregion

        /// <summary>
        /// �d����d�q�������[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>�d����d�q�������[�U�[�ݒ���N���X</returns>
        public SuppPtrStcUserConst Clone()
        {
            SuppPtrStcUserConst constObj = new SuppPtrStcUserConst();
            return constObj;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// �t�@�C���g���q�ϊ�����
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newExtension"></param>
        /// <returns></returns>
        public static string ChangeFileExtension( string fileName, string selectedValue )
        {
            string newExt = string.Empty;
            switch ( selectedValue )
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
            if ( newExt != string.Empty )
            {
                try
                {
                    fileName = Path.ChangeExtension( fileName, newExt );
                }
                catch
                {
                }
            }
            return fileName;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
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
        public ColumnInfo( string columnName, int visiblePosition, bool hidden, int width, bool columnFixed )
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }
    # endregion

    # region [��ʃt�H�[�J�X����N���X]
    /// <summary>
    /// ��ʃt�H�[�J�X����N���X
    /// </summary>
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
        public void AddLine( params Control[] controls )
        {
            List<Control> line = new List<Control>( controls );

            for ( int index = 0; index < line.Count; index++ )
            {
                int col = index;
                int row = _controls.Count;

                _col.Add( line[index].Name, col );
                _row.Add( line[index].Name, row );
            }

            _controls.Add( line );
        }

        /// <summary>
        /// ���R���g���[���擾�i�t�H�[�J�X�ړ���j
        /// </summary>
        /// <param name="prevControl"></param>
        /// <param name="key"></param>
        /// <param name="shiftKey"></param>
        /// <returns></returns>
        public Control GetNextControl( Control prevControl, Keys key, bool shiftKey )
        {
            Control nextControl = null;

            if ( !_col.ContainsKey( prevControl.Name ) ) return null;

            int col = _col[prevControl.Name];
            int row = _row[prevControl.Name];

            if ( _controls[row][col].Name != prevControl.Name ) return null;

            if ( !shiftKey )
            {
                switch ( key )
                {
                    # region [UP]
                    case Keys.Up:
                        {
                            if ( row - 1 >= 0 )
                            {
                                int originCol = col;
                                row--;

                                if ( col > _controls[row].Count - 1 )
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while ( nextControl == null || nextControl.Enabled == false )
                                {
                                    if ( col > 0 )
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if ( row > 0 )
                                    {
                                        col = originCol;
                                        row--;
                                        if ( col > _controls[row].Count - 1 )
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
                            if ( row + 1 <= _controls.Count - 1 )
                            {
                                int originCol = col;
                                row++;

                                if ( col > _controls[row].Count - 1 )
                                {
                                    col = _controls[row].Count - 1;
                                }
                                nextControl = _controls[row][col];
                                while ( nextControl == null || nextControl.Enabled == false )
                                {
                                    if ( col > 0 )
                                    {
                                        col--;
                                        nextControl = _controls[row][col];
                                    }
                                    else if ( row + 1 <= _controls.Count - 1 )
                                    {
                                        col = originCol;
                                        row++;
                                        if ( col > _controls[row].Count - 1 )
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

                    # region [LEFT]
                    case Keys.Left:
                        {
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col > 0 )
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
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col < _controls[row].Count - 1 )
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
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col + 1 <= _controls[row].Count - 1 )
                                {
                                    col++;
                                }
                                else if ( row + 1 <= _controls.Count - 1 )
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
                switch ( key )
                {
                    # region [Tab���O]
                    case Keys.Tab:
                    case Keys.Return:
                        {
                            // Tab���O����
                            nextControl = null;
                            while ( nextControl == null || nextControl.Enabled == false )
                            {
                                if ( col - 1 >= 0 )
                                {
                                    col--;
                                }
                                else if ( row - 1 >= 0 )
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
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
    # region [�O���b�h�E��I���_�C�A���O����N���X]
    /// <summary>
    /// �O���b�h�E��I���_�C�A���O����N���X
    /// </summary>
    /// <remarks>Grid�̃J�����`���[�U�����ʉ����܂�</remarks>
    public class GridColumnChooserControl
    {
        private List<Infragistics.Win.UltraWinGrid.UltraGrid> _targetList;
        private Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog> _chooserDialogs;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GridColumnChooserControl()
        {
            _targetList = new List<Infragistics.Win.UltraWinGrid.UltraGrid>();
            _chooserDialogs = new Dictionary<string, Infragistics.Win.UltraWinGrid.ColumnChooserDialog>();
        }

        /// <summary>
        /// �Ώےǉ�
        /// </summary>
        /// <param name="targetGrid"></param>
        public void Add( Infragistics.Win.UltraWinGrid.UltraGrid targetGrid )
        {
            if ( !_targetList.Contains( targetGrid ) )
            {
                // �Ώ�Grid���X�g
                _targetList.Add( targetGrid );
                // �J�����`���[�U�_�C�A���O
                _chooserDialogs.Add( targetGrid.Name, CreateColumnChooser( targetGrid ) );

                // �Ώ�Grid�ւ̑���
                targetGrid.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
                targetGrid.BeforeColumnChooserDisplayed += new Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventHandler( uGrid_BeforeColumnChooserDisplayed );
            }
        }
        /// <summary>
        /// �J�����`���[�U�[�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>��Grid�̃f�t�H���g�̃J�����`���[�U�[���J�X�^�}�C�Y���܂�</remarks>
        private void uGrid_BeforeColumnChooserDisplayed( object sender, Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventArgs e )
        {
            // �f�t�H���g�̏����̓L�����Z������
            e.Cancel = true;
            //bool flag = false;

            // �J�����`���[�U�[�_�C�A���O
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = _chooserDialogs[(sender as Control).Name];
            if ( chooser == null ) return;

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
        /// <param name="chooser"></param>
        private Infragistics.Win.UltraWinGrid.ColumnChooserDialog CreateColumnChooser( Infragistics.Win.UltraWinGrid.UltraGrid sourceGrid )
        {
            Infragistics.Win.UltraWinGrid.ColumnChooserDialog chooser = new Infragistics.Win.UltraWinGrid.ColumnChooserDialog();

            chooser.Text = "�\�����ڂ̑I��";
            chooser.StartPosition = FormStartPosition.CenterScreen;
            chooser.Size = new Size( 250, 400 );
            chooser.TopMost = true;

            // �\����������A�j�����Ȃ�
            chooser.DisposeOnClose = Infragistics.Win.DefaultableBoolean.False;

            chooser.ColumnChooserControl.SourceGrid = sourceGrid;
            chooser.ColumnChooserControl.Font = sourceGrid.Font;

            return chooser;
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD
}