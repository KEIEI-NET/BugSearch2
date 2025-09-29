//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �i�ԕϊ��ꊇ����
// �v���O�����T�v   : �i�ԕϊ��ꊇ�����t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S��  : �i�N
// �� �� ��  2015/01/26  �C�����e  : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/02/17   �C�����e : Redmine#44209 �p�X�̕���������s����Ă��Ȃ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �c����
// �� �� ��  2015/02/25   �C�����e : Redmine#44209 �t�@�C�����A�����敪���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �v��
// �� �� ��  2015/02/25   �C�����e : Redmine#44209 No.35 ���O�t�H���_���J���{�^���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/02/26   �C�����e : Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/02/27   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/02   �C�����e : Redmine#44209 �O�u�d�l�ύX�v�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/16   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �c����
// �� �� ��  2015/04/06   �C�����e : Redmine#44209 ���j���[�N������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : zhujc
// �� �� ��  2015/04/17   �C�����e : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/04/30   �C�����e : Redmine#44209 No.100 Client�̃��O�t�H���_�����݂��Ȃ���ԂŃ��O�t�H���_�\���{�^������������Ɨ�O�G���[����������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���R
// �� �� ��  2015/05/12   �C�����e : Redmine#45436 No.105 �i�ԕϊ��������ɏI���{�^���A���s�{�^���������Ă��܂��̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Win32;
using System.IO;
using System.Collections; //ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �i�ԕϊ��ꊇ����
    /// </summary>
    /// <remarks>
    /// Note       : �i�ԕϊ��ꊇ�����ł��B<br />
    /// Programmer : �i�N<br />
    /// Date       : 2015/01/26<br />
    /// <br>UpdateNote : 2015/02/25 �c���� </br>
    /// <br>           : Redmine#44209 �t�@�C�����A�����敪���̑Ή�</br>
    /// <br>UpdateNote : 2015/04/06 �c���� </br>
    /// <br>           : Redmine#44209 ���j���[�N������Ή�</br>
    /// <br>UpdateNote : 2015/04/17 zhujc </br>
    /// <br>           : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
    /// <br>UpdateNote : 2015/05/12 ���R </br>
    /// <br>           : Redmine#45436 No.105 �i�ԕϊ��������ɏI���{�^���A���s�{�^���������Ă��܂��̑Ή�</br>
    /// </remarks>
    public partial class PMKHN01700UA : Form
    {
        #region �� Const Memebers
        private const string PROGRAM_ID = "PMKHN01700U";

        private const string DATATABLE_SLESCT = "�I��";
        private const string DATATABLE_MAST = "�����Ώ�";
        private const string DATATABLE_READ = "�Ǎ�����";
        private const string DATATABLE_UPDATE = "�X�V����";
        private const string DATATABLE_ERR = "�G���[����";
        private const string CHECKFLG = "��";

        // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
        private const string ct_GOODSNOCHANGERF = "�i�ԕϊ��}�X�^";
        private const string ct_GOODSUSTOCKRF = "���i�݌Ƀ}�X�^";
        private const string ct_GOODSMNGRF = "���i�Ǘ����}�X�^";
        private const string ct_RATERF = "�|���}�X�^";
        private const string ct_JOINPARTSURF = "�����}�X�^";
        private const string ct_PARTSSUBSTURF = "��փ}�X�^";
        private const string ct_GOODSSETRF = "�Z�b�g�}�X�^";
        private const string ct_SALESDETAILRF = "���v��ݏo�f�[�^";
        private const string ct_PRMSETTINGURF = "�D�ǐݒ�}�X�^";
        // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<

        #endregion

        //----- DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�----->>>>>
        ////----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
        //private const string ct_GOODS_ERROR = "(�G���[)���i�}�X�^���O.csv";
        //private const string ct_GOODSPRICE_ERROR = "(�G���[)���i�}�X�^���O.csv";
        //private const string ct_STOCK_ERROR = "(�G���[)�݌Ƀ}�X�^���O.csv";
        //private const string ct_GOODSMNG_ERROR = "(�G���[)���i�Ǘ����}�X�^���O.csv";
        //private const string ct_RATE_ERROR = "(�G���[)�|���}�X�^���O.csv";
        //private const string ct_JOINPARTS_ERROR = "(�G���[)�����}�X�^���O.csv";
        //private const string ct_SUBST_ERROR = "(�G���[)��փ}�X�^���O.csv";
        //private const string ct_GOODSSET_ERROR = "(�G���[)�Z�b�g�}�X�^���O.csv";
        //private const string ct_RENTDATA_ERROR = "(�G���[)���v��ݏo�f�[�^���O.csv";
        //private const string ct_CROSS_INDEX_GOODSCHG_ERROR = "(�G���[)�i�ԕϊ��}�X�^���O.csv";
        ////----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<
        //----- DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�-----<<<<<

        # region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �R���X�g���N�^�̏��������s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
        /// </remarks>
        public PMKHN01700UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._dataTable = new DataTable();
            this._subSectionAcs = new SubSectionAcs();
            this._meijiGoodsChgAllAcs = new MeijiGoodsChgAllAcs();
            this._goodsNoChangeAcs = new GoodsNoChangeAcs();//ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
        }

        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� ----->>>>>
        /// <summary>
        /// �R���X�g���N�^�i�v���O���}�����s����O�ɁA���t�`�F�b�N�p�j
        /// </summary>
        /// <param name="mode"></param>
        public PMKHN01700UA(int mode)
        {
            InitializeComponent();
        }
        //----- ADD 2015/04/06 �c���� Redmine#44209 ���j���[�N������Ή� -----<<<<<
        # endregion

        # region �� private field
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executionButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        private string _loginSection = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _loginCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode;                         // ��ƃR�[�h
        private DataTable _dataTable;
        private bool firstStart;
        private MeijiGoodsChgAllAcs _meijiGoodsChgAllAcs;
        private SubSectionAcs _subSectionAcs;
        private string _path = string.Empty;

        // ADD 2014/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�  ------>>>>>>
        private GoodsNoChangeAcs _goodsNoChangeAcs;
        private ArrayList _goodsNoChangeAList;
        private bool _goodsNoChangeAFlg = false;
        // ADD 2014/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�  ------<<<<<<

        #endregion

        # region �� �t�H�[�����[�h
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
        /// </remarks>
        private void PMKHN01700UA_Load(object sender, EventArgs e)
        {
            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ADD 2014/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�  ------>>>>>>
            this._goodsNoChangeAcs.SearchAll(this._enterpriseCode, out this._goodsNoChangeAList);
            GoodsNoChangedDataCheck();
            // ADD 2014/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�  ------<<<<<<

            // �O���b�h�����ݒ菈��
            this.GridInitialSetting();

            // ����N���`�F�b�N
            firstStart = this.firstStartCheck();
            if (firstStart)
            {
                SetDeploy(false);
            }
            else
            {
                SetDeploy(true);
            }

            // ��ʃf�[�^�̏������ݒ�
            this.InitializeScreen();
        }

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }

        /// <summary>
		/// �f�[�^�r���[�p�O���b�h�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h�̏����ݒ���s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
		/// </remarks>
        private void GridInitialSetting()
        {
            // �O���b�h�̏����ݒ�
            _dataTable.Columns.Add(DATATABLE_SLESCT, typeof(string));
            _dataTable.Columns.Add(DATATABLE_MAST, typeof(string));
            _dataTable.Columns.Add(DATATABLE_READ, typeof(string));
            _dataTable.Columns.Add(DATATABLE_UPDATE, typeof(string));
            _dataTable.Columns.Add(DATATABLE_ERR, typeof(string));

            //_dataTable.Rows.Add("", "�i�ԕϊ��}�X�^", "0", "0", "0"); // DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
            // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
            if (!_goodsNoChangeAFlg)
            {
            _dataTable.Rows.Add("", "�i�ԕϊ��}�X�^", "0", "0", "0");
            }
            // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<

            _dataTable.Rows.Add("", "���i�݌Ƀ}�X�^", "0", "0", "0");
            _dataTable.Rows.Add("", "���i�Ǘ����}�X�^", "0", "0", "0");
            _dataTable.Rows.Add("", "�|���}�X�^", "0", "0", "0");
            _dataTable.Rows.Add("", "�����}�X�^", "0", "0", "0");
            _dataTable.Rows.Add("", "��փ}�X�^", "0", "0", "0");
            _dataTable.Rows.Add("", "�Z�b�g�}�X�^", "0", "0", "0");
            _dataTable.Rows.Add("", "���v��ݏo�f�[�^", "0", "0", "0");
            _dataTable.Rows.Add("", "�D�ǐݒ�}�X�^", "0", "0", "0");// ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�

            DataView dataView = new DataView(_dataTable);
            this.gridData.DataSource = dataView;

            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.gridData.DisplayLayout.Bands[0].Columns;

            // �\���ʒu�����l
            int visiblePosition = 1;

            // �I��
            columns[DATATABLE_SLESCT].Hidden = false;
            columns[DATATABLE_SLESCT].Width = 30;
            columns[DATATABLE_SLESCT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[DATATABLE_SLESCT].Header.Caption = DATATABLE_SLESCT;
            columns[DATATABLE_SLESCT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_SLESCT].Header.VisiblePosition = visiblePosition++;

            // �����Ώ�
            columns[DATATABLE_MAST].Hidden = false;
            columns[DATATABLE_MAST].Width = 325;
            columns[DATATABLE_MAST].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[DATATABLE_MAST].Header.Caption = DATATABLE_MAST;
            columns[DATATABLE_MAST].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_MAST].Header.VisiblePosition = visiblePosition++;

            // �Ǎ�����
            columns[DATATABLE_READ].Hidden = false;
            columns[DATATABLE_READ].Width = 100;
            columns[DATATABLE_READ].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[DATATABLE_READ].Header.Caption = DATATABLE_READ;
            columns[DATATABLE_READ].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_READ].Header.VisiblePosition = visiblePosition++;

            // �X�V����
            columns[DATATABLE_UPDATE].Hidden = false;
            columns[DATATABLE_UPDATE].Width = 100;
            columns[DATATABLE_UPDATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[DATATABLE_UPDATE].Header.Caption = DATATABLE_UPDATE;
            columns[DATATABLE_UPDATE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_UPDATE].Header.VisiblePosition = visiblePosition++;

            // �G���[����
            columns[DATATABLE_ERR].Hidden = false;
            columns[DATATABLE_ERR].Width = 100;
            columns[DATATABLE_ERR].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[DATATABLE_ERR].Header.Caption = DATATABLE_ERR;
            columns[DATATABLE_ERR].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_ERR].Header.VisiblePosition = visiblePosition++;
        }


        /// <summary>
        /// ����N���`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����N���`�F�b�N���s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private bool firstStartCheck()
        {
            string workDir = null;
            // ���W�X�g���L�[�擾
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            if (key == null)    // �ʏ�͂��肦�Ȃ�
            {
                workDir = @"C:\Program Files\Partsman";     // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
            }
            _path = Path.Combine(@workDir, "Log\\Trance_csv");

            // �t�H���_���݂���
            if (Directory.Exists(_path))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(_path);
                //�t�H���_�Ƀ��O������
                if (di.GetFiles().Length + di.GetDirectories().Length == 0)
                {
                    return false;
                }
            }
            // �t�H���_���݂��Ȃ�
            else
            {
                Directory.CreateDirectory(_path);
                return false;
            }
            return true;
        }
        # endregion

        #region �� ��ʃf�[�^�̏��������� ��
        /// <summary>
        /// ��ʃf�[�^�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʃf�[�^�̂��s��</br>
        /// <br>Programmer	: �i�N</br>
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ���_
            this.tComboEditor_ChangeDiv.SelectedIndex = 0;
        }
        #endregion

        
        #endregion

        #region �� �i�ԕϊ��ꊇ�������b�\�h�֘A
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote : 2015/05/12 ���R </br>
        /// <br>           : Redmine#45436 No.105 �i�ԕϊ��������ɏI���{�^���A���s�{�^���������Ă��܂��̑Ή�</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Run":
                    {
                        bool inputCheck = this.ExecutBeforeCheck();

                        if (inputCheck)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "���s���܂����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                changeButtonEnabled(false); // ADD 2015/05/12 ���R Redmine#45436 ��105 
                                // ���s����
                                this.ExecuteProcess();
                                changeButtonEnabled(true); // ADD 2015/05/12 ���R Redmine#45436 ��105 
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
        /// <br>Programmer	: �i�N</br>
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            // Grid�֌W����
            if (e.PrevCtrl == gridData)
            {
                if (gridData.ActiveRow != null)
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        SetValue(gridData.ActiveRow);
                        gridData.UpdateData();

                        UltraGridRow ugr = gridData.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        e.NextCtrl = gridData;
                    }
                }
            }
        }

        #endregion

        #region �� private method
        /// <summary>
        /// �i�ԕϊ��ꊇ��������
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �i�ԕϊ��ꊇ�����������s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/02/25 �c���� </br>
        /// <br>            : Redmine#44209 �t�@�C�����A�����敪���̑Ή�</br>
        /// <br>UpdateNote  : 2015/02/26 ���V�� </br>
        /// <br>            : Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMsg = string.Empty;
            string newPath = "";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�

            GoodsChangeResultWork goodsChangeResultWork = null;

            // ����������ݒ肷��
            GoodsChangeAllCndWorkWork cndWork = getCndWork();

            #region ��ʌ����̃N���A
            this.updateGridData(goodsChangeResultWork, cndWork, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            #endregion

            // �C���|�[�g����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

            try
            {
                // �\��������ݒ�
                form.Title = "�i�ԕϊ�������";
                form.Message = "���݁A�f�[�^��ϊ����ł��B" + "\r\n" + "���΂炭���҂���������";
                // �_�C�A���O�\��
                form.Show();

                //status = _meijiGoodsChgAllAcs.GoodsChange(cndWork, _path, out goodsChangeResultWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
                status = _meijiGoodsChgAllAcs.GoodsChange(cndWork, _path, out goodsChangeResultWork, out newPath);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�

                //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
                // Grid���Z�b�g
                updateGridData(goodsChangeResultWork, cndWork, status);
                //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

                // �_�C�A���O�����
                form.Close();
            }
            catch (Exception)
            {
                form.Close();
                DialogResult result = TMsgDisp.Show(
                        this,													    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,						        // �G���[���x��
                        PROGRAM_ID,											        // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�i�ԕϊ��������ɗ\�����Ȃ��G���[���������܂����B" + "\r\n" + "�����敪���u�S�āv�ɐݒ肵�čēx���s���ĉ������B",// �\�����郁�b�Z�[�W 
                        status,														    // �X�e�[�^�X�l
                        MessageBoxButtons.OK,								        // �\������{�^��
                        MessageBoxDefaultButton.Button1);						    // �����\���{�^��
            }
            //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL || goodsChangeResultWork.ErrCntGoodsChgMst > 0) //DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL || goodsChangeResultWork.ErrCntGoodsChgMst > 0 || !string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg)) //ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            {
                string resultMessage = "";
                StringBuilder builderMessage = new StringBuilder();
                //----- DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                //int allCount = goodsChangeResultWork.ReadCntGoodsChgMst + goodsChangeResultWork.ReadCntGoodsAll + goodsChangeResultWork.ReadCntMng
                //    + goodsChangeResultWork.ReadCntRate + goodsChangeResultWork.ReadCntJoin + goodsChangeResultWork.ReadCntParts
                //    + goodsChangeResultWork.ReadCntSet + goodsChangeResultWork.ReadCntShipment;
                //----- DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                int allCount = goodsChangeResultWork.ReadCntGoodsChgMst + goodsChangeResultWork.ReadCntGoodsAll + goodsChangeResultWork.ReadCntMng
                      + goodsChangeResultWork.ReadCntRate + goodsChangeResultWork.ReadCntJoin + goodsChangeResultWork.ReadCntParts
                      + goodsChangeResultWork.ReadCntSet + goodsChangeResultWork.ReadCntShipment + goodsChangeResultWork.ReadCntPrm;
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                //if (allCount == 0)//DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                if (allCount == 0 && string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg)) //ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                {
                    Directory.Delete(newPath); // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
                    errMsg = "�Y������f�[�^������܂���B";
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, errMsg, 0, MessageBoxButtons.OK);
                }
                //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
                // �D�ǐݒ�̒񋟕��f�[�^���擾�ł��Ȃ��ꍇ
                else if (this._meijiGoodsChgAllAcs.ct_PRMOFFER_ERROR.Equals(goodsChangeResultWork.ErrMsg))
                {
                    // �t�H���_���݂���
                    if (Directory.Exists(newPath))
                    {
                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(newPath);
                        //�t�H���_�Ƀ��O������
                        if (di.GetFiles().Length + di.GetDirectories().Length == 0)
                        {
                            Directory.Delete(newPath);
                        }
                    }
                    // ���b�Z�[�W�\��
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PROGRAM_ID, goodsChangeResultWork.ErrMsg, 0, MessageBoxButtons.OK);
                }
                //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<
                else
                {
                    // �i�ԕϊ��}�X�^
                    if (goodsChangeResultWork.ErrCntGoodsChgMst > 0 && goodsChangeResultWork.MstStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " �ECross_Index_Goodschg_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                        //builderMessage.Append("\r\n �E" + ct_CROSS_INDEX_GOODSCHG_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_CROSS_INDEX_GOODSCHG_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    }
                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                    //// ���i�݌Ƀ}�X�^
                    //if (goodsChangeResultWork.ErrorCntGoods > 0 && goodsChangeResultWork.GoodsStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //{
                    //    //builderMessage.Append("\r\n" + " �EGoods_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                    //    //builderMessage.Append("\r\n �E" + ct_GOODS_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    //    builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_GOODS_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    //}
                    //if (goodsChangeResultWork.ErrorCntPrice > 0 && goodsChangeResultWork.PriceStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //{
                    //    //builderMessage.Append("\r\n" + " �EGoodsPrice_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                    //    //builderMessage.Append("\r\n �E" + ct_GOODSPRICE_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    //    builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_GOODSPRICE_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    //}
                    //if (goodsChangeResultWork.ErrorCntStock > 0 && goodsChangeResultWork.StockStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //{
                    //    //builderMessage.Append("\r\n" + " �EStock_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                    //    //builderMessage.Append("\r\n �E" + ct_STOCK_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    //    builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_STOCK_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    //}
                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                    // ���i�݌Ƀ}�X�^
                    if (goodsChangeResultWork.ErrorCntGoods > 0 && goodsChangeResultWork.GoodsStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_GOODSSTOCK_ERROR);
                    }
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                    // �Ǘ����}�X�^
                    if (goodsChangeResultWork.ErrorCntMng > 0 && goodsChangeResultWork.MngStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " �EGoodsMng_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                        //builderMessage.Append("\r\n �E" + ct_GOODSMNG_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_GOODSMNG_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    }
                    // �|���}�X�^
                    if (goodsChangeResultWork.ErrorCntRate > 0 && goodsChangeResultWork.RateStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " �ERate_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                        //builderMessage.Append("\r\n �E" + ct_RATE_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_RATE_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    }
                    // �����}�X�^
                    if (goodsChangeResultWork.ErrorCntJoin > 0 && goodsChangeResultWork.JoinStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " �EJoinParts_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                        //builderMessage.Append("\r\n �E" + ct_JOINPARTS_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_JOINPARTS_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    }
                    // ��փ}�X�^
                    if (goodsChangeResultWork.ErrCntParts > 0 && goodsChangeResultWork.PartsStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " �ESubst_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                        //builderMessage.Append("\r\n �E" + ct_SUBST_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_SUBST_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    }
                    // �Z�b�g�}�X�^
                    if (goodsChangeResultWork.ErrCntSet > 0 && goodsChangeResultWork.SetStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " �EGoodsSet_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                        //builderMessage.Append("\r\n �E" + ct_GOODSSET_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_GOODSSET_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    }
                    // ���v��ݏo�f�[�^
                    if (goodsChangeResultWork.ErrCntShipment > 0 && goodsChangeResultWork.ShipmentStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " �ERentData_error.csv"); // DEL 2015/02/25 �c���� Redmine#44209
                        //builderMessage.Append("\r\n �E" + ct_RENTDATA_ERROR); // ADD 2015/02/25 �c���� Redmine#44209 // DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_RENTDATA_ERROR); // ADD 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�
                    }
                    //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                    // �D�ǐݒ�}�X�^
                    if (goodsChangeResultWork.ErrCntPrm > 0 && goodsChangeResultWork.PrmStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        builderMessage.Append("\r\n �E" + this._meijiGoodsChgAllAcs.ct_PRMSETTING_ERROR);
                    }
                    //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

                    // �G���[�f�[�^������
                    if (!string.IsNullOrEmpty(builderMessage.ToString()))
                    {
                        // --- DEL 2015/02/17 ���V�� Redmine#44209 �p�X�̕���������s����Ă��Ȃ��Ή� -------------->>>>>
                        //resultMessage = "�ϊ��Ɏ��s�����s������܂��B" + "\r\n" + "���L�G���[���O���Q�Ƃ��ĉ������B" 
                        //    + _path + "\\"  + builderMessage.ToString();
                        // --- DEL 2015/02/17 ���V�� Redmine#44209 �p�X�̕���������s����Ă��Ȃ��Ή� --------------<<<<<
                        // --- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή� ----->>>>>
                        // --- ADD 2015/02/17 ���V�� Redmine#44209 �p�X�̕���������s����Ă��Ȃ��Ή� -------------->>>>>
                        //resultMessage = "�ϊ��Ɏ��s�����s������܂��B" + "\r\n" +"���O�t�H���_�\���{�^���������ă��O�t�H���_���J���A"+"\r\n" + "���L�G���[���O���Q�Ƃ��ĉ������B" + "\r\n" + "\r\n"
                        //    + _path + "\\" + builderMessage.ToString();
                        // --- ADD 2015/02/17 ���V�� Redmine#44209 �p�X�̕���������s����Ă��Ȃ��Ή� --------------<<<<<
                        // --- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή� -----<<<<<
                        // --- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή� ----->>>>>
                        resultMessage = "�ϊ��Ɏ��s�����s������܂��B" + "\r\n" + "���O�t�H���_�\���{�^���������ă��O�t�H���_���J���A" + "\r\n" + "���L�G���[���O���Q�Ƃ��ĉ������B" + "\r\n" + "\r\n"
                            + newPath + "\\" + builderMessage.ToString();
                        // --- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή� -----<<<<<
                        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                        if (!string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg))
                        {
                            resultMessage = resultMessage + "\r\n" + "\r\n" + goodsChangeResultWork.ErrMsg;
                        }
                    }
                    else
                    {
                        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                        if (!string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg))
                        {
                            resultMessage = goodsChangeResultWork.ErrMsg;
                        }
                        else
                        {
                            //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<<
                            // ����Ȋ���
                            if (goodsChangeResultWork.LogCSVOpen == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsChangeResultWork.ErrLogCSVOpen == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                resultMessage = "�}�X�^�ϊ��������������܂����B";
                            }
                        }//ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                    }

                    // ���b�Z�[�W�\��
                    if (!string.IsNullOrEmpty(resultMessage))
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, resultMessage, 0, MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                // --- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή� --->>>>>
                // �t�H���_���݂���
                if (Directory.Exists(newPath))
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(newPath);
                    //�t�H���_�Ƀ��O������
                    if (di.GetFiles().Length + di.GetDirectories().Length == 0)
                    {
                        Directory.Delete(newPath);
                    }
                }
                // --- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή� ---<<<<<
                // --- DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                //if (!string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg))
                //{
                //    DialogResult result = TMsgDisp.Show(
                //        this,													    // �e�E�B���h�E�t�H�[��
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,						    // �G���[���x��
                //        PROGRAM_ID,											        // �A�Z���u���h�c�܂��̓N���X�h�c
                //        goodsChangeResultWork.ErrMsg,                               // �\�����郁�b�Z�[�W 
                //        status,														// �X�e�[�^�X�l
                //        MessageBoxButtons.OK,								        // �\������{�^��
                //        MessageBoxDefaultButton.Button1);						    // �����\���{�^��
                //}
                //else
                //{
                    // --- DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                    DialogResult result = TMsgDisp.Show(
                        this,													    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,						        // �G���[���x��
                        PROGRAM_ID,											        // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�i�ԕϊ��������ɗ\�����Ȃ��G���[���������܂����B" + "\r\n" + "�����敪���u�S�āv�ɐݒ肵�čēx���s���ĉ������B",// �\�����郁�b�Z�[�W 
                        status,														    // �X�e�[�^�X�l
                        MessageBoxButtons.OK,								        // �\������{�^��
                        MessageBoxDefaultButton.Button1);						    // �����\���{�^��
                //}//  DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            }

            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //// Grid���Z�b�g
            //updateGridData(goodsChangeResultWork, cndWork, status);
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
        }

        /// <summary>
        /// �`�F�b�N����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �`�F�b�N�������s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            int checkeCount = 0;
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                if (CHECKFLG.Equals(_dataTable.Rows[i][0]))
                {
                    checkeCount++;
                }
            }
            if (checkeCount == 0)
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                    "�i�ԕϊ������Ώۂ�I��ŉ������B",	// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                return false;
            }

            return true;
        }

        /// <summary>
        /// ����������ݒ肷��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���������̐ݒ���s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
        /// </remarks>
        private GoodsChangeAllCndWorkWork getCndWork()
        {
            GoodsChangeAllCndWorkWork cndWork = new GoodsChangeAllCndWorkWork();
            cndWork.EnterpriseCode = this._enterpriseCode;
            cndWork.LoginEmpleeCode = this._loginCode;
            cndWork.LoginEmpleeName = this._loginName;
            cndWork.LoginSectionCode = this._loginSection;
            cndWork.LoginSectionNm = this._subSectionAcs.GetSectionName(this._loginSection);

            cndWork.ChangeDiv = this.tComboEditor_ChangeDiv.SelectedIndex;

            #region DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
            /* 
            if (CHECKFLG.Equals(_dataTable.Rows[0][0]))
            {
                cndWork.GoodsChangeMstDiv = 1;
            }
            else
            {
                cndWork.GoodsChangeMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[1][0]))
            {
                cndWork.GoodsMstDiv = 1;
            }
            else
            {
                cndWork.GoodsMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[2][0]))
            {
                cndWork.GoodsMngMstDiv = 1;
            }
            else
            {
                cndWork.GoodsMngMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[3][0]))
            {
                cndWork.RateMstDiv = 1;
            }
            else
            {
                cndWork.RateMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[4][0]))
            {
                cndWork.JoinMstDiv = 1;
            }
            else
            {
                cndWork.JoinMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[5][0]))
            {
                cndWork.PartsMstDiv = 1;
            }
            else
            {
                cndWork.PartsMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[6][0]))
            {
                cndWork.SetMstDiv = 1;
            }
            else
            {
                cndWork.SetMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[7][0]))
            {
                cndWork.ShipmentDiv = 1;
            }
            else
            {
                cndWork.ShipmentDiv = 0;
            }
            //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
            if (CHECKFLG.Equals(_dataTable.Rows[8][0]))
            {
                cndWork.PrmMstDiv = 1;
            }
            else
            {
                cndWork.PrmMstDiv = 0;
            }
            //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
            */
            #endregion DEL Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
            // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
            foreach (DataRow dataRow in _dataTable.Rows)
            {
                if (dataRow[DATATABLE_SLESCT].ToString().Equals(CHECKFLG))
                {
                    this.getCndWorkProc(ref cndWork, dataRow, 1);
                }
                else
                {
                    this.getCndWorkProc(ref cndWork, dataRow, 0);
                }
            }
            // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<
            return cndWork;
        }

        /// <summary>
        /// �����̃Z�b�g
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �����̃Z�b�g���s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
        /// </remarks>
        private void updateGridData(GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, int status)
        {
            #region DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
            /*
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // �i�ԕϊ��}�X�^
                _dataTable.Rows[0][2] = goodsChangeResultWork.ReadCntGoodsChgMst.ToString("#,###,##0");
                _dataTable.Rows[0][3] = goodsChangeResultWork.LoadCntGoodsChgMst.ToString("#,###,##0");
                _dataTable.Rows[0][4] = goodsChangeResultWork.ErrCntGoodsChgMst.ToString("#,###,##0");
                // ���i�݌Ƀ}�X�^
                _dataTable.Rows[1][2] = goodsChangeResultWork.ReadCntGoodsAll.ToString("#,###,##0");
                _dataTable.Rows[1][3] = goodsChangeResultWork.LoadCntGoodsAll.ToString("#,###,##0");
                _dataTable.Rows[1][4] = goodsChangeResultWork.ErrCntGoodsAll.ToString("#,###,##0");
                // �Ǘ����}�X�^
                _dataTable.Rows[2][2] = goodsChangeResultWork.ReadCntMng.ToString("#,###,##0");
                _dataTable.Rows[2][3] = goodsChangeResultWork.LoadCntMng.ToString("#,###,##0");
                _dataTable.Rows[2][4] = goodsChangeResultWork.ErrorCntMng.ToString("#,###,##0");
                // �|���}�X�^
                _dataTable.Rows[3][2] = goodsChangeResultWork.ReadCntRate.ToString("#,###,##0");
                _dataTable.Rows[3][3] = goodsChangeResultWork.LoadCntRate.ToString("#,###,##0");
                _dataTable.Rows[3][4] = goodsChangeResultWork.ErrorCntRate.ToString("#,###,##0");
                // �����}�X�^
                _dataTable.Rows[4][2] = goodsChangeResultWork.ReadCntJoin.ToString("#,###,##0");
                _dataTable.Rows[4][3] = goodsChangeResultWork.LoadCntJoin.ToString("#,###,##0");
                _dataTable.Rows[4][4] = goodsChangeResultWork.ErrorCntJoin.ToString("#,###,##0");
                // ��փ}�X�^
                _dataTable.Rows[5][2] = goodsChangeResultWork.ReadCntParts.ToString("#,###,##0");
                _dataTable.Rows[5][3] = goodsChangeResultWork.LoadCntParts.ToString("#,###,##0");
                _dataTable.Rows[5][4] = goodsChangeResultWork.ErrCntParts.ToString("#,###,##0");
                // �Z�b�g�}�X�^
                _dataTable.Rows[6][2] = goodsChangeResultWork.ReadCntSet.ToString("#,###,##0");
                _dataTable.Rows[6][3] = goodsChangeResultWork.LoadCntSet.ToString("#,###,##0");
                _dataTable.Rows[6][4] = goodsChangeResultWork.ErrCntSet.ToString("#,###,##0");
                // ���v��ݏo�f�[�^
                _dataTable.Rows[7][2] = goodsChangeResultWork.ReadCntShipment.ToString("#,###,##0");
                _dataTable.Rows[7][3] = goodsChangeResultWork.LoadCntShipment.ToString("#,###,##0");
                _dataTable.Rows[7][4] = goodsChangeResultWork.ErrCntShipment.ToString("#,###,##0");
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                // �D�ǐݒ�}�X�^
                _dataTable.Rows[8][2] = goodsChangeResultWork.ReadCntPrm.ToString("#,###,##0");
                _dataTable.Rows[8][3] = goodsChangeResultWork.LoadCntPrm.ToString("#,###,##0");
                _dataTable.Rows[8][4] = goodsChangeResultWork.ErrCntPrm.ToString("#,###,##0");
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
            }
            else
            {
                // �i�ԕϊ��}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[0][2] = 0;
                    _dataTable.Rows[0][3] = 0;
                    _dataTable.Rows[0][4] = 0;
                }
                else
                {
                    _dataTable.Rows[0][2] = goodsChangeResultWork.ReadCntGoodsChgMst.ToString("#,###,##0");
                    _dataTable.Rows[0][3] = goodsChangeResultWork.LoadCntGoodsChgMst.ToString("#,###,##0");
                    _dataTable.Rows[0][4] = goodsChangeResultWork.ErrCntGoodsChgMst.ToString("#,###,##0");
                }
                //----- DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                // ���i�݌Ƀ}�X�^
                //_dataTable.Rows[1][2] = 0;
                //_dataTable.Rows[1][3] = 0;
                //_dataTable.Rows[1][4] = 0;
                //// �Ǘ����}�X�^
                //_dataTable.Rows[2][2] = 0;
                //_dataTable.Rows[2][3] = 0;
                //_dataTable.Rows[2][4] = 0;
                //// �|���}�X�^
                //_dataTable.Rows[3][2] = 0;
                //_dataTable.Rows[3][3] = 0;
                //_dataTable.Rows[3][4] = 0;
                //// �����}�X�^
                //_dataTable.Rows[4][2] = 0;
                //_dataTable.Rows[4][3] = 0;
                //_dataTable.Rows[4][4] = 0;
                //// ��փ}�X�^
                //_dataTable.Rows[5][2] = 0;
                //_dataTable.Rows[5][3] = 0;
                //_dataTable.Rows[5][4] = 0;
                //// �Z�b�g�}�X�^
                //_dataTable.Rows[6][2] = 0;
                //_dataTable.Rows[6][3] = 0;
                //_dataTable.Rows[6][4] = 0;
                //----- DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                // ���i�݌Ƀ}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[1][2] = 0;
                    _dataTable.Rows[1][3] = 0;
                    _dataTable.Rows[1][4] = 0;
                }
                else
                {
                    _dataTable.Rows[1][2] = goodsChangeResultWork.ReadCntGoodsAll.ToString("#,###,##0");
                    _dataTable.Rows[1][3] = goodsChangeResultWork.LoadCntGoodsAll.ToString("#,###,##0");
                    _dataTable.Rows[1][4] = goodsChangeResultWork.ErrCntGoodsAll.ToString("#,###,##0");
                }
                // �Ǘ����}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[2][2] = 0;
                    _dataTable.Rows[2][3] = 0;
                    _dataTable.Rows[2][4] = 0;
                }
                else
                {
                    _dataTable.Rows[2][2] = goodsChangeResultWork.ReadCntMng.ToString("#,###,##0");
                    _dataTable.Rows[2][3] = goodsChangeResultWork.LoadCntMng.ToString("#,###,##0");
                    _dataTable.Rows[2][4] = goodsChangeResultWork.ErrorCntMng.ToString("#,###,##0");
                }
                // �|���}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[3][2] = 0;
                    _dataTable.Rows[3][3] = 0;
                    _dataTable.Rows[3][4] = 0;
                }
                else
                {
                    _dataTable.Rows[3][2] = goodsChangeResultWork.ReadCntRate.ToString("#,###,##0");
                    _dataTable.Rows[3][3] = goodsChangeResultWork.LoadCntRate.ToString("#,###,##0");
                    _dataTable.Rows[3][4] = goodsChangeResultWork.ErrorCntRate.ToString("#,###,##0");
                }
                // �����}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[4][2] = 0;
                    _dataTable.Rows[4][3] = 0;
                    _dataTable.Rows[4][4] = 0;
                }
                else
                {
                    _dataTable.Rows[4][2] = goodsChangeResultWork.ReadCntJoin.ToString("#,###,##0");
                    _dataTable.Rows[4][3] = goodsChangeResultWork.LoadCntJoin.ToString("#,###,##0");
                    _dataTable.Rows[4][4] = goodsChangeResultWork.ErrorCntJoin.ToString("#,###,##0");
                }
                // ��փ}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[5][2] = 0;
                    _dataTable.Rows[5][3] = 0;
                    _dataTable.Rows[5][4] = 0;
                }
                else
                {
                    _dataTable.Rows[5][2] = goodsChangeResultWork.ReadCntParts.ToString("#,###,##0");
                    _dataTable.Rows[5][3] = goodsChangeResultWork.LoadCntParts.ToString("#,###,##0");
                    _dataTable.Rows[5][4] = goodsChangeResultWork.ErrCntParts.ToString("#,###,##0");
                }
                // �Z�b�g�}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[6][2] = 0;
                    _dataTable.Rows[6][3] = 0;
                    _dataTable.Rows[6][4] = 0;
                }
                else
                {
                    _dataTable.Rows[6][2] = goodsChangeResultWork.ReadCntSet.ToString("#,###,##0");
                    _dataTable.Rows[6][3] = goodsChangeResultWork.LoadCntSet.ToString("#,###,##0");
                    _dataTable.Rows[6][4] = goodsChangeResultWork.ErrCntSet.ToString("#,###,##0");
                }
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                // ���v��ݏo�f�[�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[7][2] = 0;
                    _dataTable.Rows[7][3] = 0;
                    _dataTable.Rows[7][4] = 0;
                }
                else
                {
                    _dataTable.Rows[7][2] = goodsChangeResultWork.ReadCntShipment.ToString("#,###,##0");
                    _dataTable.Rows[7][3] = goodsChangeResultWork.LoadCntShipment.ToString("#,###,##0");
                    _dataTable.Rows[7][4] = goodsChangeResultWork.ErrCntShipment.ToString("#,###,##0");
                }
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                // �D�ǐݒ�}�X�^
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[8][2] = 0;
                    _dataTable.Rows[8][3] = 0;
                    _dataTable.Rows[8][4] = 0;
                }
                else
                {
                    _dataTable.Rows[8][2] = goodsChangeResultWork.ReadCntPrm.ToString("#,###,##0");
                    _dataTable.Rows[8][3] = goodsChangeResultWork.LoadCntPrm.ToString("#,###,##0");
                    _dataTable.Rows[8][4] = goodsChangeResultWork.ErrCntPrm.ToString("#,###,##0");
                }
                //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
            }
            */
            #endregion DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�

            //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
            if (goodsChangeResultWork == null)
            {
                for (int rowIndex = 0; rowIndex < _dataTable.Rows.Count; rowIndex++)
                {
                    _dataTable.Rows[rowIndex][2] = 0;
                    _dataTable.Rows[rowIndex][3] = 0;
                    _dataTable.Rows[rowIndex][4] = 0;
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < _dataTable.Rows.Count; rowIndex++)
                {
                    if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSNOCHANGERF))
                    {
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntGoodsChgMst.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntGoodsChgMst.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntGoodsChgMst.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSUSTOCKRF))
                    {
                        // ���i�݌Ƀ}�X�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntGoodsAll.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntGoodsAll.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntGoodsAll.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSMNGRF))
                    {
                        // �Ǘ����}�X�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntMng.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntMng.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrorCntMng.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_RATERF))
                    {
                        // �|���}�X�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntRate.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntRate.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrorCntRate.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_JOINPARTSURF))
                    {
                        // �����}�X�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntJoin.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntJoin.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrorCntJoin.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_PARTSSUBSTURF))
                    {
                        // ��փ}�X�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntParts.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntParts.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntParts.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSSETRF))
                    {
                        // �Z�b�g�}�X�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntSet.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntSet.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntSet.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_SALESDETAILRF))
                    {
                        // ���v��ݏo�f�[�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntShipment.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntShipment.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntShipment.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_PRMSETTINGURF))
                    {
                        // �D�ǐݒ�}�X�^
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntPrm.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntPrm.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntPrm.ToString("#,###,##0");
                    }
                }

            }
            //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<

        }

        // ADD 2015/02/25 �v�� Redmine#44209 No.35 ���O�t�H���_���J���{�^���ǉ�----->>>>> 
        /// <summary>
        /// ���O�t�H���_�\��
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ultraButtonLogOutput_Click(object sender, EventArgs e)
        {
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�----->>>>>
            DirectoryInfo di = new DirectoryInfo(_path);
            //----- ADD 2015/04/30 ���V�� No.100 Client�̃��O�t�H���_�����݂��Ȃ���ԂŃ��O�t�H���_�\���{�^������������Ɨ�O�G���[����������Ή�------>>>>>
            // �t�H���_���݂���
            if (!Directory.Exists(_path))
            {
                TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                "���O�t�H���_�����݂��܂���B",	    // �\�����郁�b�Z�[�W 
                                0,									// �X�e�[�^�X�l
                                MessageBoxButtons.OK);				// �\������{�^��
            }
            else
            {
                //----- ADD 2015/04/30 ���V�� No.100 Client�̃��O�t�H���_�����݂��Ȃ���ԂŃ��O�t�H���_�\���{�^������������Ɨ�O�G���[����������Ή�------<<<<<
                DirectoryInfo[] files = di.GetDirectories();
                string path = string.Empty;
                if (di.GetDirectories().Length > 0)
                {
                    FileComparer fc = new FileComparer();
                    Array.Sort(files, fc);
                    path = files[0].FullName;
                }
                else
                {
                    path = _path;
                }
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�-----<<<<<
                //System.Diagnostics.Process.Start("explorer.exe", _path); //DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
                System.Diagnostics.Process.Start("explorer.exe", path); //ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
            }
        }//ADD 2015/04/30 ���V�� No.100 Client�̃��O�t�H���_�����݂��Ȃ���ԂŃ��O�t�H���_�\���{�^������������Ɨ�O�G���[����������Ή�
        // ADD 2015/02/25 �v�� Redmine#44209 No.35 ���O�t�H���_���J���{�^���ǉ�-----<<<<<

        #endregion

        #region �� Event
        #region Grid Event
        /// <summary>
        /// gridData_Leave
        /// </summary>
        /// <remarks>		
        /// <br>Note		: Grid��Leave Event���s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_Leave(object sender, EventArgs e)
        {
            gridData.Selected.Rows.Clear();
        }

        /// <summary>
        /// gridData_Enter
        /// </summary>
        /// <remarks>		
        /// <br>Note		: Grid��Enter Event���s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_Enter(object sender, EventArgs e)
        {
            if (gridData.Selected.Rows.Count == 0)
            {
                if (gridData.ActiveRow != null)
                {
                    gridData.ActiveRow.Selected = true;
                }
                else
                {
                    if (gridData.Rows.Count > 0)
                    {
                        gridData.Rows[0].Activate();
                        gridData.Rows[0].Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// gridData_DoubleClickRow
        /// </summary>
        /// <remarks>		
        /// <br>Note		: Grid��DoubleClickRow Event���s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            SetValue(e.Row);

            gridData.UpdateData();
        }

        /// <summary>
        /// �I����ԍX�V����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �I����ԍX�V�������s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
        /// </remarks>
        private void SetValue(UltraGridRow row)
        {
            UltraGridCell cell = row.Cells[0];
            string val = string.Empty;
            if (this.tComboEditor_ChangeDiv.SelectedIndex == 0)
            {
                if (cell.Value.Equals(CHECKFLG))
                {
                    val = string.Empty;
                }
                else
                {
                    val = CHECKFLG;
                }
                cell.Value = val;
            }
            else
            {
                //if (row.Index != 0 && row.Index != 7) // DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                //if (row.Index != 0 && row.Index != 7 && row.Index != 8) // ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� //DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
                if (!((row.Cells[DATATABLE_MAST].Text).Equals(ct_GOODSNOCHANGERF)
                    ||(row.Cells[DATATABLE_MAST].Text).Equals(ct_SALESDETAILRF)
                    || (row.Cells[DATATABLE_MAST].Text).Equals(ct_PRMSETTINGURF))) //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
                {
                    if (cell.Value.Equals(CHECKFLG))
                    {
                        val = string.Empty;
                    }
                    else
                    {
                        val = CHECKFLG;
                    }
                    cell.Value = val;
                }
            }
        }

        /// <summary>
        /// gridData_KeyDown
        /// </summary>
        /// <remarks>		
        /// <br>Note		: Grid��KeyDown Event���s���B</br>
        /// <br>Programmer	: �i�N</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridData.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    SetValue(gridData.ActiveRow);

                    gridData.UpdateData();

                    UltraGridRow ugr = gridData.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// [�S�ĉ���]�{�^�������C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ClearAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
        }

        /// <summary>
        /// [�S�đI��]�{�^�������C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SelectAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
            SetDeploy(true);
        }

        /// <summary>
        /// �W�J�敪�ݒ�
        /// </summary>
        /// <param name="flg">true: �S�I��/false: �S����</param>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
        private void SetDeploy(bool flg)
        {
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                DataRow dw = _dataTable.Rows[i];
                if (flg)
                {
                    //if ((i == 0 || i == 7) && this.tComboEditor_ChangeDiv.SelectedIndex == 1) // DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                    //if ((i == 0 || i == 7 || i == 8) && this.tComboEditor_ChangeDiv.SelectedIndex == 1) // ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� //DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
                    if (
                        (
                        dw[DATATABLE_MAST].ToString().Equals(ct_GOODSNOCHANGERF) || 
                        dw[DATATABLE_MAST].ToString().Equals(ct_SALESDETAILRF) || 
                        dw[DATATABLE_MAST].ToString().Equals(ct_PRMSETTINGURF)
                        ) &&
                        this.tComboEditor_ChangeDiv.SelectedIndex == 1) //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�
                    {
                        _dataTable.Rows[i][0] = string.Empty;
                    }
                    else
                    {
                        _dataTable.Rows[i][0] = CHECKFLG;
                    }
                }
                else
                {
                    _dataTable.Rows[i][0] = string.Empty;
                }
            }
        }

        /// <summary>
        /// �����敪
        /// </summary>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 �i�ԕϊ�������ʂ̐���Ή�</br>
        private void tComboEditor_ChangeDiv_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_ChangeDiv.SelectedIndex == 0)
            {
                // DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
                //gridData.Rows[0].Appearance.BackColor = Color.White;
                //gridData.Rows[0].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                //gridData.Rows[7].Appearance.BackColor = gridData.Rows[1].Appearance.BackColor;
                //gridData.Rows[7].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                ////----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                //gridData.Rows[8].Appearance.BackColor = Color.White;
                //gridData.Rows[8].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                ////----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                // DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<

                //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
                string targetRow = "";
                for (int rowIndex = 0; rowIndex < gridData.Rows.Count; rowIndex++ )
                {
                    targetRow = gridData.Rows[rowIndex].Cells[DATATABLE_MAST].Text;
                    if (targetRow.Equals(ct_GOODSNOCHANGERF)
                        || targetRow.Equals(ct_SALESDETAILRF)
                        || targetRow.Equals(ct_PRMSETTINGURF))
                    {
                        if (rowIndex == 0 || (rowIndex % 2) == 0)
                        {
                            gridData.Rows[rowIndex].Appearance.BackColor = Color.White;
            }
            else
            {
                            gridData.Rows[rowIndex].Appearance.BackColor = gridData.Rows[1].Appearance.BackColor;
                        }
                        gridData.Rows[rowIndex].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                }
                //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<
            }
            else
            {
                // DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
                //gridData.Rows[0].Appearance.BackColor = Color.Gainsboro;
                //_dataTable.Rows[0][0] = string.Empty;
                //gridData.Rows[0].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                //gridData.Rows[7].Appearance.BackColor = Color.Gainsboro;
                //_dataTable.Rows[7][0] = string.Empty;
                //gridData.Rows[7].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                ////----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                //gridData.Rows[8].Appearance.BackColor = Color.Gainsboro;
                //_dataTable.Rows[8][0] = string.Empty;
                //gridData.Rows[8].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                ////----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                // DEL 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<

                // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
                string targetRow = "";
                for (int rowIndex = 0; rowIndex < gridData.Rows.Count; rowIndex++)
                {
                    targetRow = gridData.Rows[rowIndex].Cells[DATATABLE_MAST].Text;
                    if (targetRow.Equals(ct_GOODSNOCHANGERF)
                        || targetRow.Equals(ct_SALESDETAILRF)
                        || targetRow.Equals(ct_PRMSETTINGURF))
                    {
                        gridData.Rows[rowIndex].Appearance.BackColor = Color.Gainsboro;
                        _dataTable.Rows[rowIndex][0] = string.Empty;
                        gridData.Rows[rowIndex].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                    }
                }
                // ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<
            }
        }

        #endregion

        //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------>>>>>>
        #region Redmine#44209 �z�M�ŕi�ԕϊ��}�X�^�捞�ނ��Ƃɂ��A�i�ԕϊ�������ʂ̐���Ή�
        /// <summary>
        /// �i�ԕϊ�������ʂ̐���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ�������ʂ̐���</br>
        /// <br>Programmer : zhujc</br>
        /// <br>Date       : 2015/04/17</br>
        /// </remarks>
        private void GoodsNoChangedDataCheck()
        {
            if(this._goodsNoChangeAList != null && this._goodsNoChangeAList.Count > 0)
            {
                this._goodsNoChangeAFlg = true;
            }
        }

        /// <summary>
        /// ���������̐ݒ�
        /// </summary>
        /// <param name="cndWork">��������</param>
        /// <param name="dataRow">�s�f�[�^</param>
        /// <param name="setValue">�ݒ�l</param>
        private void getCndWorkProc(ref GoodsChangeAllCndWorkWork cndWork, DataRow dataRow, int setValue)
        {
            if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSNOCHANGERF))
            {
                cndWork.GoodsChangeMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSUSTOCKRF))
            {
                cndWork.GoodsMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSMNGRF))
            {
                cndWork.GoodsMngMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_RATERF))
            {
                cndWork.RateMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_JOINPARTSURF))
            {
                cndWork.JoinMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_PARTSSUBSTURF))
            {
                cndWork.PartsMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSSETRF))
            {
                cndWork.SetMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_SALESDETAILRF))
            {
                cndWork.ShipmentDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_PRMSETTINGURF))
            {
                cndWork.PrmMstDiv = setValue;
            }
        }

        #endregion
        //ADD 2015/04/17 zhujc Redmine#44209 �i�ԕϊ�������ʂ̐���Ή� ------<<<<<<

        //ADD 2015/05/12 ���R Redmine#45436 ��105 ------>>>>>>
        #region �� �ϊ��������{�^������
        /// <summary>
        /// �ϊ��������c�[���o�[�{�^���̐���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ϊ��������c�[���o�[�{�^���̐���</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2015/05/12</br>
        /// </remarks>
        private void changeButtonEnabled(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Run"].SharedProps.Enabled = enable;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = enable;
            // ��ʂ̃��t���b�V��
            System.Windows.Forms.Application.DoEvents();
        }
        #endregion
        //ADD 2015/05/12 ���R Redmine#45436 ��105 ------<<<<<

    }

    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�----->>>>>
    /// <summary>�t�H���_�̍X�V������r�N���X</summary>
    /// <remarks>
    /// <br>Note       : �t�H���_�̍X�V������r���s��</br>
    /// <br>Programmer : ���V��</br>
    /// <br>Date       : 2015/03/02</br>
    /// </remarks>
    public class FileComparer : IComparer 
    { 
        int IComparer.Compare(Object o1, Object o2) 
        {
            DirectoryInfo fi1 = o1 as DirectoryInfo;
            DirectoryInfo fi2 = o2 as DirectoryInfo;
            return fi2.CreationTime.CompareTo(fi1.CreationTime);
        }
    }
    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�-----<<<<<
}