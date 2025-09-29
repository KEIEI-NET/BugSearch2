//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���}�X�^���
// �v���O�����T�v   : ���o���ʂ��o�͌��ʃC���[�W�\���E�o�c�e�o�́E������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/12  �C�����e : Redmine#22927 ���o�����̔��s�^�C�v��ύX���Ĉ���EPDF�o�͂������ƁA���o�������s���܂���̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[���}�X�^�i����jUI�t�H�[���N���X�R���X�g���N�^
    /// </summary>
    /// <remarks>
    /// <br>Note        : �L�����y�[���}�X�^�i����jUI�t�H�[���N���X�R���X�g���N�^</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/04/25</br>
    /// </remarks>
    public partial class PMKHN08700UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// �L�����y�[���}�X�^�i����jUI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���}�X�^�i����jUI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>UpdateNote : 2011/07/12 杍^ Redmine#22927 ���o�����̔��s�^�C�v��ύX���Ĉ���EPDF�o�͂������ƁA���o�������s���܂���̏C��</br>
        /// <br></br>
        /// </remarks>
        public PMKHN08700UA()
        {
            InitializeComponent();
            
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // �ϐ�������
            this._campaignMasterAcs = new CampaignMasterAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            
            this.secInfoSetTable = new Hashtable();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // ----- ADD 2011/07/12 ------- >>>>>>>>>
            this._goodsAcs = new GoodsAcs();
            String retMessage = string.Empty;
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._ownSectionCode, out retMessage);
            // ----- ADD 2011/07/12 ------- <<<<<<<<<
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;


        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        private Employee _loginWorker = null;
        // �����_�R�[�h
        private string _ownSectionCode = "";

        //���_�K�C�h�p
        private SecInfoSetAcs _secInfoSetAcs;

        private GoodsAcs _goodsAcs = null;    // ADD 2011/07/12
        private IWin32Window _owner = null;   // ADD 2011/07/12

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private CampaignMasterPrintWork _campaignMasterPrintWork;

        // �f�[�^�A�N�Z�X
        private CampaignMasterAcs _campaignMasterAcs;

        //�L�����y�[���K�C�h�p
        private CampaignLinkAcs _campaignLinkAcs;

        // �O���[�v�R�[�h�K�C�h
        private BLGroupUAcs _bLGroupUAcs;

        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;

        /// <summary>���[�J�[�}�X�^�@�A�N�Z�X�N���X</summary>
        private MakerAcs _makerAcs;

        // ���[�U�[�K�C�h�p
        private UserGuideAcs _userGuideAcs;

        private Hashtable secInfoSetTable;
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMKHN08700UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN08700U";
        //// ���[����
        private string _printName = "�L�����y�[���}�X�^�i����j";
        // ���[�L�[	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // �ۗ�
        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// �o�͏���
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����


        private const string PRINTSET_TABLE = "CAMPAIGNSSET";

        // dataview���̗p
        private const string UPDATEDATETIME = "updatedatetime";
        private const string CREATEDATETIME = "createdatetime";
        private const string CAMPAIGNCODE = "campaigncode";
        private const string CAMPAIGNNAME = "campaignname";
        private const string SECTIONCODE = "sectioncode";
        private const string SECTIONGUIDESNM = "sectionguidesnm";
        private const string CAMPAIGNOBJDIV = "campaignobjdiv";
        private const string APPLYSTADATE = "applystadate";
        private const string APPLYENDDATE = "applyenddate";
        private const string CUSTOMERCODE = "customercode";
        private const string CUSTOMERSNM = "customersnm";
        private const string GOODSNO = "goodsno";
        private const string GOODSNAME = "goodsname";
        private const string GOODSMAKERCD = "goodsmakercd";
        private const string MAKERNAME = "makername";
        private const string BLGOODSCODE = "blgoodscode";
        private const string BLGOODSHALFNAME = "blgoodshalfname";
        private const string BLGROUPCODE = "blgroupcode";
        private const string BLGROUPNAME = "blgroupname";
        private const string SALESCODE = "salescode";
        private const string GUIDENAME = "guidename";
        private const string RATEVAL = "rateval";
        private const string PRICEFL = "pricefl";
        private const string DISCOUNTRATE = "discountrate";
        private const string PRICESTARTDATE = "pricestartdate";
        private const string PRICEENDDATE = "priceenddate";
        private const string APPLYDATE = "applydate";
        private const string PRICEDATE = "pricedate";
        private const string SALESPRICESETDIV = "salespricesetdiv";

        private const string UPDATEDATETIME_TITLE = "�X�V��";
        private const string CREATEDATETIME_TITLE = "�쐬��";
        private const string CAMPAIGNCODE_TITLE = "����";
        private const string CAMPAIGNNAME_TITLE = "����";
        private const string SECTIONCODE_TITLE = "���_";
        private const string SECTIONGUIDESNM_TITLE = "���_��";
        private const string CAMPAIGNOBJDIV_TITLE = "�Ώۓ��Ӑ�敪";
        private const string APPLYSTADATE_TITLE = "�K�p�J�n��";
        private const string APPLYENDDATE_TITLE = "�K�p�I����";
        private const string CUSTOMERCODE_TITLE = "���Ӑ�";
        private const string CUSTOMERSNM_TITLE = "���Ӑ於";
        private const string GOODSNO_TITLE = "�i��";
        private const string GOODSNAME_TITLE = "�i��";
        private const string GOODSMAKERCD_TITLE = "Ұ��";
        private const string MAKERNAME_TITLE = "Ұ����";
        private const string BLGOODSCODE_TITLE = "BL����";
        private const string BLGOODSHALFNAME_TITLE = "BL���ޖ�";
        private const string BLGROUPCODE_TITLE = "��ٰ�ߺ���";
        private const string BLGROUPNAME_TITLE = "��ٰ�ߺ��ޖ�";
        private const string SALESCODE_TITLE = "�̔��敪";
        private const string GUIDENAME_TITLE = "�̔��敪��";
        private const string RATEVAL_TITLE = "������";
        private const string PRICEFL_TITLE = "�����z";
        private const string DISCOUNTRATE_TITLE = "�l����";
        private const string PRICESTARTDATE_TITLE = "���i�J�n��";
        private const string PRICEENDDATE_TITLE = "���i�I����";
        private const string APPLYDATE_TITLE = "�K�p����";
        private const string PRICEDATE_TITLE = "���i��";
        private const string SALESPRICESETDIV_TITLE = "�����ݒ�敪";

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color ct_REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color ct_MINUS_FONT_COLOR = Color.Red;
        private static readonly Color ct_GOODSDISCOUNT_CELL_COLOR = Color.Pink;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        private static readonly Color ct_ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));

        private static readonly Color ct_MARGIN_LESS_COLOR = Color.Orchid;
        private static readonly Color ct_MARGIN_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_MARGIN_OVER_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

        private static readonly Color ct_UNITPRICE_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_UNITPRICE_CHANGE_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note		: ���o�������s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {

            int status = 0;
            ArrayList PrintSets = null;

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._campaignMasterAcs.Search(out PrintSets, this._enterpriseCode,  this._campaignMasterPrintWork);
            }
            else
            {
                status = this._campaignMasterAcs.SearchDelete(out PrintSets, this._enterpriseCode, this._campaignMasterPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {

                        // ���i�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (CampaignMaster campaignMaster in PrintSets)
                        {

                            SecPrintSetToDataSet(campaignMaster.Clone(), index);
                            ++index;
                        }
                        
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN08700U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�L�����y�[���}�X�^�i����j", 	    // �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._campaignMasterAcs, 	        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._campaignMasterPrintWork;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._campaignMasterPrintWork = new CampaignMasterPrintWork();

            this.Show();
            return;
        }
        #endregion

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���i��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// ���C���t���[���O���b�g���C�A�E�g�ݒ�
        /// </summary>
        /// <param name="UGrid"></param>
        /// <remarks>
        /// <br>Note		: ���C���t���[���O���b�g���C�A�E�g�ݒ�</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        public void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid)
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = UGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn uGrid in editBand.Columns)
            {
                uGrid.Hidden = false;
            }

            UGrid.DisplayLayout.Bands[0].UseRowLayout = true;

            // �񕝂̎����������@
            UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            UGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            UGrid.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            UGrid.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;


            UGrid.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            UGrid.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            #region ���ڂ̃T�C�Y��ݒ�
            sizeCell.Height = 22;
            sizeCell.Width = 60;
            sizeHeader.Height = 20;
            sizeHeader.Width = 60;

            // �R�[�h
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ����
            sizeCell.Width = 180;
            sizeHeader.Width = 180;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���_
            sizeCell.Width = 50;
            sizeHeader.Width = 50;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���_��
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �Ώۓ��Ӑ�敪
            sizeCell.Width = 120;
            sizeHeader.Width = 120;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �K�p�J�n��
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �K�p�I����
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �쐬��
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            // �X�V��
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���Ӑ�
            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���Ӑ於
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �i��
            sizeCell.Width = 200;
            sizeHeader.Width = 200;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �i��
            sizeCell.Width = 250;
            sizeHeader.Width = 250;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // Ұ��
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // Ұ����
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BL����
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BL���ޖ�
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ��ٰ�ߺ���
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ��ٰ�ߺ��ޖ�
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �̔��敪
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �̔��敪��
            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ������
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ������
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �����z
            sizeCell.Width = 180;
            sizeHeader.Width = 180;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���i�J�n��
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���i�I����
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �K�p����
            sizeCell.Width = 100;
            sizeHeader.Width = 100;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���i��
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �����ݒ�敪
            sizeCell.Width = 50;
            sizeHeader.Width = 50;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  ���ڂ̃T�C�Y��ݒ�

            #region LabelSpan�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpan�̐ݒ�

            #region �w�b�_����
            // �w�b�_���̂�ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].Header.Caption = CAMPAIGNCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].Header.Caption = CAMPAIGNNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].Header.Caption = SECTIONCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].Header.Caption = SECTIONGUIDESNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Header.Caption = CAMPAIGNOBJDIV_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Header.Caption = APPLYSTADATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Header.Caption = APPLYENDDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].Header.Caption = CUSTOMERSNM_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Header.Caption = GOODSNO_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Header.Caption = GOODSNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Header.Caption = GOODSMAKERCD_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Header.Caption = MAKERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Header.Caption = BLGOODSHALFNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Header.Caption = BLGROUPCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Header.Caption = BLGROUPNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Header.Caption = SALESCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Header.Caption = GUIDENAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].Header.Caption = DISCOUNTRATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].Header.Caption = RATEVAL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Header.Caption = PRICEFL_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Header.Caption = PRICESTARTDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].Header.Caption = PRICEENDDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].Header.Caption = APPLYDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].Header.Caption = PRICEDATE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].Header.Caption = SALESPRICESETDIV_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].Header.Caption = UPDATEDATETIME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].Header.Caption = CREATEDATETIME_TITLE;
            #endregion

            #region ��\������
            //��\������
            UGrid.DisplayLayout.Bands[0].Columns[APPLYDATE].Hidden = true;          // �K�p����
            UGrid.DisplayLayout.Bands[0].Columns[PRICEDATE].Hidden = true;          // ���i��
            UGrid.DisplayLayout.Bands[0].Columns[SALESPRICESETDIV].Hidden = true;   // �����ݒ�敪

            if ((int)this.tComboEditor_PrintType.Value == 1) //���[�J�[�{�i��
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;

            }
            else if ((int)this.tComboEditor_PrintType.Value == 2) //���[�J�[�{�a�k�R�[�h
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;


                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = false;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = false;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 3) //���[�J�[�{�O���[�v�R�[�h
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 4) //���[�J�[
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
             else if ((int)this.tComboEditor_PrintType.Value == 5) //�a�k�R�[�h
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
             else if ((int)this.tComboEditor_PrintType.Value == 6) //�̔��敪
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
            }
             else if ((int)this.tComboEditor_PrintType.Value == 7) //�}�X�^���X�g
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].Hidden = true;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].Hidden = true;
            }
            #endregion

            // �����\���ʒu�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �\���t�H�[�}�b�g�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].Format = "#,##0.00";
            UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].Format = "0.00";
            UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].Format = "0.00";
            UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].Format = "yyyy/MM/dd";
            UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].Format = "yyyy/MM/dd";

            #region ��z�u


            // 1�s��
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[SECTIONGUIDESNM].RowLayoutColumnInfo.SpanY = 2;

            if ((int)this.tComboEditor_PrintType.Value == 1) // ���[�J�[�{�i��
            {
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNO].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEFL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 30;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 32;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

            }
            else if ((int)this.tComboEditor_PrintType.Value == 2) // ���[�J�[�{�a�k�R�[�h
            {
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 30;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }            
            else if ((int)this.tComboEditor_PrintType.Value == 3) // ���[�J�[�{�O���[�v�R�[�h
            {
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGROUPNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 28;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 30;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 4) // ���[�J�[
            {
                

                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GOODSMAKERCD].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 5) //�a�k�R�[�h
            {
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[BLGOODSHALFNAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 6) //�̔��敪
            {
                

                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[SALESCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[GUIDENAME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[DISCOUNTRATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginX = 18;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[RATEVAL].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginX = 20;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICESTARTDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginX = 22;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[PRICEENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginX = 24;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CREATEDATETIME].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginX = 26;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[UPDATEDATETIME].RowLayoutColumnInfo.SpanY = 2;
            }
            else if ((int)this.tComboEditor_PrintType.Value == 7) //�}�X�^���X�g
            {
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.OriginX = 8;
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CAMPAIGNOBJDIV].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.OriginX = 10;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYSTADATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.OriginX = 12;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[APPLYENDDATE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 14;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginX = 16;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.OriginY = 0;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanX = 2;
                UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERSNM].RowLayoutColumnInfo.SpanY = 2;
            }
            #endregion ��z�u
        }

        /// <summary>
        /// ���o�����`�F�b�N����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ���o�����`�F�b�N����</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// <br>UpdateNote  : 2011/07/12 杍^ Redmine#22927 ���o�����̔��s�^�C�v��ύX���Ĉ���EPDF�o�͂������ƁA���o�������s���܂���̏C��</br>
        /// </remarks>
        public bool DataCheck()
        {
            bool status = true;

            // ----- ADD 2011/07/12 ------- >>>>>>>>>
            //����p�^�[��
            if (this._campaignMasterPrintWork.PrintType != (int)this.tComboEditor_PrintType.SelectedIndex)
            {
                status = false;
                return status;
            }
            // ----- ADD 2011/07/12 ------- <<<<<<<<<

            // �J�n�L�����y�[��
            if (this._campaignMasterPrintWork.CampaignCodeSt != this.tNedit_CampaignCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // �I���L�����y�[��
            if (this._campaignMasterPrintWork.CampaignCodeEd != this.tNedit_CampaignCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // �J�n���_
            if (this._campaignMasterPrintWork.SectionCodeSt != this.tEdit_SectionCode_St.DataText)
            {
                status = false;
                return status;
            }
            // �I�����_
            if (this._campaignMasterPrintWork.SectionCodeEd != this.tEdit_SectionCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            // �J�n���[�J�[
            if (this._campaignMasterPrintWork.GoodsMakerCodeSt != this.tNedit_GoodsMakerCd_St.GetInt())
            {
                status = false;
                return status;
            }
            // �I�����[�J�[
            if (this._campaignMasterPrintWork.GoodsMakerCodeSt != this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // �J�n�a�k�R�[�h
            if (this._campaignMasterPrintWork.BLGoodsCodeSt != this.tNedit_BLGoodsCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // �I���a�k�R�[�h
            if (this._campaignMasterPrintWork.BLGoodsCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // �J�n�a�k�O���[�v�R�[�h
            if (this._campaignMasterPrintWork.BLGroupCodeSt != this.tNedit_BLGroupCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // �I���a�k�O���[�v�R�[�h
            if (this._campaignMasterPrintWork.BLGroupCodeEd != this.tNedit_BLGroupCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // �J�n�̔��敪
            if (this._campaignMasterPrintWork.BLGoodsCodeSt != this.tNedit_SalesCode_St.GetInt())
            {
                status = false;
                return status;
            }
            // �I���̔��敪
            if (this._campaignMasterPrintWork.BLGoodsCodeEd != this.tNedit_SalesCode_Ed.GetInt())
            {
                status = false;
                return status;
            }
            // �J�n�i��
            if (this._campaignMasterPrintWork.GoodsNoSt != this.tEdit_GoodsNo_St.DataText)
            {
                status = false;
                return status;
            }
            // �I���i��
            if (this._campaignMasterPrintWork.GoodsNoEd != this.tEdit_GoodsNo_Ed.DataText)
            {
                status = false;
                return status;
            }            

            // �폜�w��
            if (this._campaignMasterPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }
            // �J�n�폜�N����
            if (this._campaignMasterPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            // �I���폜�N����
            if (this._campaignMasterPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetLongDate())
            {
                status = false;
                return status;
            }
            return status;
        }
        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return this._printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: ���i��</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E������
                this.tNedit_CampaignCode_St.DataText = string.Empty;
                this.tNedit_CampaignCode_Ed.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.tNedit_PriceFl.DataText = string.Empty;
                this.tNedit_RateVal.DataText = string.Empty;
                this.tNedit_DiscountRate.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_CampaignCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CampaignCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SectionCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SectionCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SalesCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SalesCodeGuide, Size16_Index.STAR1);

                // �R���{�̏�����
                this.tComboEditor_PrintType.Value = 1;
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.tComboEditor_PriceFlDiv.Value = 0;
                this.tComboEditor_RateValDiv.Value = 0;
                this.tCmb_DiscountRate.Value = 0;

                // �����w��̎g�p�s��
                this.pn_BLCode.Visible = false;
                this.pn_BLGroupCode.Visible = false;
                this.pn_SalesCode.Visible = false;

                // �폜�w��R���{�̐ݒ�
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // �����t�H�[�J�X�Z�b�g
                this.tComboEditor_PrintType.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks >
        /// <br>Note		: �{�^���A�C�R���ݒ菈�� </br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";


            // �L�����y�[��
            if (
                (this.tNedit_CampaignCode_St.GetInt() != 0) &&
                (this.tNedit_CampaignCode_Ed.GetInt() != 0) &&
                this.tNedit_CampaignCode_St.GetInt() > this.tNedit_CampaignCode_Ed.GetInt())
            {
                errMessage = string.Format("�L�����y�[���R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_CampaignCode_St;
                status = false;
                return status;
            }

            int sectionCodeSt = 0;
            int sectionCodeEd = 0;
            int.TryParse(this.tEdit_SectionCode_St.Text, out sectionCodeSt);
            int.TryParse(this.tEdit_SectionCode_Ed.Text, out sectionCodeEd);
            // ���_
            if (
                !string.IsNullOrEmpty(this.tEdit_SectionCode_St.Text) &&
                !string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.Text) &&
                sectionCodeSt > sectionCodeEd)
            {
                errMessage = string.Format("���_{0}", ct_RangeError);
                errComponent = this.tEdit_SectionCode_St;
                status = false;
                return status;
            }

            // ���[�J�[
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("���[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // BL�R�[�h
            if (
                (this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return status;
            }

            // ��ٰ�ߺ���
            if (
                (this.tNedit_BLGroupCode_St.GetInt() != 0) &&
                (this.tNedit_BLGroupCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGroupCode_St.GetInt() > this.tNedit_BLGroupCode_Ed.GetInt())
            {
                errMessage = string.Format("�a�k�O���[�v{0}", ct_RangeError);
                errComponent = this.tNedit_BLGroupCode_St;
                status = false;
                return status;
            }

            // �i��
            if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_GoodsNo_St.DataText.CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0)
            {
                errMessage = string.Format("�i��{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
                return status;
            }

            // �̔��敪
            if (
                (this.tNedit_SalesCode_St.GetInt() != 0) &&
                (this.tNedit_SalesCode_Ed.GetInt() != 0) &&
                this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt())
            {
                errMessage = string.Format("�̔��敪{0}", ct_RangeError);
                errComponent = this.tNedit_SalesCode_St;
                status = false;
                return status;
            }

            // �폜���t
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    status = false;
                    return status;
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    status = false;
                    return status;
                }

                // �͈̓`�F�b�N
                if ((this.SerchSlipDataStRF_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.SerchSlipDataEdRF_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.SerchSlipDataStRF_tDateEdit.GetDateTime() > this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
                    {
                        errMessage = "�폜���t�͈͎̔w��Ɍ�肪����܂��B";
                        this.SerchSlipDataStRF_tDateEdit.Focus();
                        return (false);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="minValueCheck">�����̓`�F�b�N�t���O(True:�����͕s�� False:�����͉�)</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMsg = "���t���w�肵�Ă��������B";
                    return (false);
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }

                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMsg = "���t���w�肵�Ă��������B";
                    return (false);
                }
            }

            if (year < 1900)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            return (true);
        }
        #endregion


        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ��ƃR�[�h
                this._campaignMasterPrintWork.EnterpriseCode = this._enterpriseCode;

                // ���s�^�C�v
                this._campaignMasterPrintWork.PrintType = (int)this.tComboEditor_PrintType.SelectedIndex;

                // ����
                this._campaignMasterPrintWork.ChangePage = (int)this.ChangePage_ultraOptionSet.Value;

                // �J�n�L�����y�[���R�[�h
                this._campaignMasterPrintWork.CampaignCodeSt = this.tNedit_CampaignCode_St.GetInt();

                // �I���L�����y�[���R�[�h
                this._campaignMasterPrintWork.CampaignCodeEd = this.tNedit_CampaignCode_Ed.GetInt();

                // �J�n���_�R�[�h
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText))
                {
                    this._campaignMasterPrintWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignMasterPrintWork.SectionCodeSt))
                    {
                        this._campaignMasterPrintWork.SectionCodeSt = string.Empty;
                    }
                }
                else
                {
                    this._campaignMasterPrintWork.SectionCodeSt = string.Empty;
                }
                

                // �I�����_�R�[�h
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText))
                {
                    this._campaignMasterPrintWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText.Trim().PadLeft(2, '0');
                    if ("00".Equals(this._campaignMasterPrintWork.SectionCodeEd))
                    {
                        this._campaignMasterPrintWork.SectionCodeEd = string.Empty;
                    }
                }
                else
                {
                    this._campaignMasterPrintWork.SectionCodeEd = string.Empty;
                }

                // �J�n���i���[�J�[�R�[�h
                this._campaignMasterPrintWork.GoodsMakerCodeSt = this.tNedit_GoodsMakerCd_St.GetInt();

                // �I�����i���[�J�[�R�[�h
                this._campaignMasterPrintWork.GoodsMakerCodeEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // �J�nBL���i�R�[�h
                this._campaignMasterPrintWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();

                // �I��BL���i�R�[�h
                this._campaignMasterPrintWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();

                // �J�nBL�O���[�v�R�[�h
                this._campaignMasterPrintWork.BLGroupCodeSt = this.tNedit_BLGroupCode_St.GetInt();

                // �I��BL�O���[�v�R�[�h
                 this._campaignMasterPrintWork.BLGroupCodeEd = this.tNedit_BLGroupCode_Ed.GetInt();

                // �J�n�̔��敪
                 this._campaignMasterPrintWork.SalesCodeSt = this.tNedit_SalesCode_St.GetInt();

                // �I���̔��敪
                this._campaignMasterPrintWork.SalesCodeEd = this.tNedit_SalesCode_Ed.GetInt();

                // �l����
                if (!string.IsNullOrEmpty(this.tNedit_DiscountRate.DataText))
                {
                    double discountRate = 0;
                    double.TryParse(this.tNedit_DiscountRate.Text, out discountRate);
                    this._campaignMasterPrintWork.DiscountRate = discountRate;
                }
                else
                {
                    this._campaignMasterPrintWork.DiscountRate = 0.00;
                }

                // �l�����敪
                this._campaignMasterPrintWork.DiscountRateDiv = this.tCmb_DiscountRate.SelectedIndex;

                // ������
                if (!string.IsNullOrEmpty(this.tNedit_RateVal.DataText))
                {
                    double rateVal = 0;
                    double.TryParse(this.tNedit_RateVal.Text, out rateVal);
                    this._campaignMasterPrintWork.RateVal = rateVal;
                }
                else
                {
                    this._campaignMasterPrintWork.RateVal = 0.00;
                }

                // �������敪
                this._campaignMasterPrintWork.RateValDiv = this.tComboEditor_RateValDiv.SelectedIndex;

                // �����z
                if (!string.IsNullOrEmpty(this.tNedit_PriceFl.DataText))
                {
                    double priceFl = 0;
                    double.TryParse(this.tNedit_PriceFl.Text, out priceFl);
                    this._campaignMasterPrintWork.PriceFl = priceFl;
                }
                else
                {
                    this._campaignMasterPrintWork.PriceFl = 0.00;
                }

                // �����z�敪
                this._campaignMasterPrintWork.PriceFlDiv = this.tComboEditor_PriceFlDiv.SelectedIndex;

                // �J�n���i�ԍ�
                this._campaignMasterPrintWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText;

                // �I�����i�ԍ�
                this._campaignMasterPrintWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText;              

                // �폜�w��敪
                this._campaignMasterPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // �J�n�폜���t
                this._campaignMasterPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetLongDate();
                // �I���폜���t
                this._campaignMasterPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetLongDate();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// <br>Note		: ���l���ځ@�I���R�[�h�擾�����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }
        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        /// <remarks >
        /// <br>Note		: ���l���ځ@�I���R�[�h�擾�����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }
        #endregion
        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region DataSet�֘A
        /// <summary>
        /// ���i�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="campaignMaster">���i�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���i�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>UpdateNote : 2011/07/12 杍^ Redmine#22927 ���s�^�C�v���h���[�J�[�{�i�ԁh�̏ꍇ�ɁA�i�����擾����܂���̑Ή�</br>
        /// </remarks>
        private void SecPrintSetToDataSet(CampaignMaster campaignMaster, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;
            }

            // �L�����y�[���R�[�h
            if (campaignMaster.CampaignCode.ToString().Trim().PadLeft(6, '0').Equals("000000"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNCODE] = campaignMaster.CampaignCode.ToString().Trim().PadLeft(6, '0');
            }

            // �L�����y�[���R�[�h����
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNNAME] = campaignMaster.CampaignName;

            // �L�����y�[���Ώۋ敪
            if (campaignMaster.CampaignObjDiv == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNOBJDIV] = "�S���Ӑ�";
            }
            else if (campaignMaster.CampaignObjDiv == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNOBJDIV] = "�Ώۓ��Ӑ�";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CAMPAIGNOBJDIV] = "���~";
            }

            // �K�p�J�n��
            if (campaignMaster.ApplyStaDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYSTADATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYSTADATE] = campaignMaster.ApplyStaDate.ToString("####/##/##");
            }
            // �K�p�I����
            if (campaignMaster.ApplyEndDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYENDDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYENDDATE] = campaignMaster.ApplyEndDate.ToString("####/##/##");
            }

            // �K�p����
            string ApplyDate = "[ " + campaignMaster.ApplyStaDate.ToString("####/##/##") + " �` " + campaignMaster.ApplyEndDate.ToString("####/##/##") + " ]";
            if (ApplyDate == "[ // �` // ]")
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][APPLYDATE] = ApplyDate;
            }

            // �L�����y�[�����{���_
            if (campaignMaster.SectionCode.Trim().PadLeft(2, '0').Equals("00"))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = "00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONCODE] = campaignMaster.SectionCode.Trim().PadLeft(2, '0');
            }

            // ���_����
            if (string.IsNullOrEmpty(campaignMaster.SectionGuideSnm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = "�S��";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SECTIONGUIDESNM] = campaignMaster.SectionGuideSnm;
            }

            // ���Ӑ�R�[�h
            if (campaignMaster.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = campaignMaster.CustomerCode.ToString().Trim().PadLeft(8, '0'); ;
            }

            // ���Ӑ旪��
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERSNM] = campaignMaster.CustomerSnm;

            // BL���i�R�[�h
            if (campaignMaster.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = campaignMaster.BLGoodsCode.ToString().Trim().PadLeft(5,'0'); ;
            }

            // ���i���[�J�[�R�[�h
            if (campaignMaster.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSMAKERCD] = campaignMaster.GoodsMakerCd.ToString().Trim().PadLeft(4,'0');
            }

            // ���i�ԍ�
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNO] = campaignMaster.GoodsNo;

            // BL�O���[�v�R�[�h
            if (campaignMaster.BLGroupCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = campaignMaster.BLGroupCode.ToString().Trim().PadLeft(5,'0');
            }

            // �̔��敪�R�[�h
            if (campaignMaster.SalesCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESCODE] = campaignMaster.SalesCode.ToString().Trim().PadLeft(4, '0');
            }          

            // ���i�i�����j
            if (campaignMaster.PriceFl == 0.0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEFL] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEFL] = campaignMaster.PriceFl.ToString("#,##0.00");
            }

            // �|��
            if (campaignMaster.RateVal == 0.0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][RATEVAL] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][RATEVAL] = campaignMaster.RateVal.ToString ("0.00");
            }

            // ������
            if (campaignMaster.DiscountRate == 0.0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DISCOUNTRATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][DISCOUNTRATE] = campaignMaster.DiscountRate.ToString("0.00");
            }
            // ���i�J�n��
            if (campaignMaster.PriceStartDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESTARTDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESTARTDATE] = campaignMaster.PriceStartDate.ToString("####/##/##");
            }

            // ���i�I����
            if (campaignMaster.PriceEndDate == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEENDDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEENDDATE] = campaignMaster.PriceEndDate.ToString("####/##/##");
            }

            // �K�p����
            string PriceDate = campaignMaster.PriceStartDate.ToString("####/##/##") + " �` " + campaignMaster.PriceEndDate.ToString("####/##/##");
            if (PriceDate == "// �` //")
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEDATE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICEDATE] = PriceDate;
            }

            // �����ݒ�敪
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SALESPRICESETDIV] = campaignMaster.SalesPriceSetDiv;

            // �a�k�R�[�h���́i���p�j
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSHALFNAME] = campaignMaster.BLGoodsHalfName;
            // ���[�J�[����
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERNAME] = campaignMaster.MakerName;

            // ----- UPD 2011/07/12 ------- >>>>>>>>>
            // �i�ԁA���[�J�[�̏ꍇ�A
            if (this.tComboEditor_PrintType.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(campaignMaster.GoodsName))
                {
                    List<GoodsUnitData> goodsUnitDataList;
                    PartsInfoDataSet partsInfoDataSet;
                    string msg = string.Empty;

                    // ���o�����̍쐬
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.GoodsMakerCd = campaignMaster.GoodsMakerCd;
                    goodsCndtn.GoodsNo = campaignMaster.GoodsNo;
                    goodsCndtn.IsSettingSupplier = 1;

                    this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

                    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                    {
                        if (goodsUnitData.LogicalDeleteCode == 0)
                        {
                            // ���i����
                            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNAME] = goodsUnitData.GoodsName;
                        }
                    }
                }
                else
                {
                    // ���i����
                    this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GOODSNAME] = campaignMaster.GoodsName;
                }
            }
            // ----- UPD 2011/07/12 ------- <<<<<<<<<

            // �O���[�v�R�[�h����
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPNAME] = campaignMaster.BLGroupName;
            // �K�C�h����
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][GUIDENAME] = campaignMaster.GuideName;
            // �쐬��
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CREATEDATETIME] = campaignMaster.CreateDateTime.ToShortDateString();
            // �X�V��
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][UPDATEDATETIME] = campaignMaster.UpdateDateTime.ToShortDateString();
        }
       
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            PrintSetTable.Columns.Add(CAMPAIGNCODE, typeof(string));		    // ���
            PrintSetTable.Columns.Add(CAMPAIGNNAME, typeof(string));		    // ����
            PrintSetTable.Columns.Add(SECTIONCODE, typeof(string));		        // ���_
            PrintSetTable.Columns.Add(SECTIONGUIDESNM, typeof(string));		    // ���_��
            PrintSetTable.Columns.Add(CAMPAIGNOBJDIV, typeof(string));		    // �Ώۓ��Ӑ�敪
            PrintSetTable.Columns.Add(APPLYSTADATE, typeof(string));		    // �K�p�J�n��
            PrintSetTable.Columns.Add(APPLYENDDATE, typeof(string));		    // �K�p�I����
            PrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		    // ���Ӑ�
            PrintSetTable.Columns.Add(CUSTOMERSNM, typeof(string));		        // ���Ӑ於
            PrintSetTable.Columns.Add(GOODSNO, typeof(string));		            // �i��
            PrintSetTable.Columns.Add(GOODSNAME, typeof(string));		        // �i��
            PrintSetTable.Columns.Add(GOODSMAKERCD, typeof(string));		    // Ұ��
            PrintSetTable.Columns.Add(MAKERNAME, typeof(string));		        // Ұ����
            PrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));	            // BL����
            PrintSetTable.Columns.Add(BLGOODSHALFNAME, typeof(string));		    // BL���ޖ�
            PrintSetTable.Columns.Add(BLGROUPCODE, typeof(string));		        // ��ٰ�ߺ���
            PrintSetTable.Columns.Add(BLGROUPNAME, typeof(string));		        // ��ٰ�ߺ��ޖ�
            PrintSetTable.Columns.Add(SALESCODE, typeof(string));		        // �̔��敪
            PrintSetTable.Columns.Add(GUIDENAME, typeof(string));		        // �̔��敪��
            PrintSetTable.Columns.Add(DISCOUNTRATE, typeof(string));		    // ������
            PrintSetTable.Columns.Add(RATEVAL, typeof(string));		            // ������
            PrintSetTable.Columns.Add(PRICEFL, typeof(string));		            // �����z
            PrintSetTable.Columns.Add(PRICESTARTDATE, typeof(string));	        // ���i�J�n��
            PrintSetTable.Columns.Add(PRICEENDDATE, typeof(string));		    // ���i�I����
            PrintSetTable.Columns.Add(APPLYDATE, typeof(string));	            // �K�p����
            PrintSetTable.Columns.Add(PRICEDATE, typeof(string));		        // ���i��
            PrintSetTable.Columns.Add(SALESPRICESETDIV, typeof(Int32));		    // �����ݒ�敪
            PrintSetTable.Columns.Add(CREATEDATETIME, typeof(string));	        // �쐬��
            PrintSetTable.Columns.Add(UPDATEDATETIME, typeof(string));		    // �X�V��
            
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        #endregion DataSet�֘A
        #endregion �� Private Method

        #region �� Control Event
        
        #region �� PMKHN08700UA_Load Event
        /// <summary>
        /// PMKHN08700UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void PMKHN08700UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;
            
            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion // �� PMKHN08700UA_Load Event

        #region [�O���[�v���k�E�W�J]
        /// <summary>
        /// �O���[�v���k�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�C�x���g</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }
        /// <summary>
        /// �O���[�v�W�J�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �O���[�v�W�J�C�x���g</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }
        #endregion // �O���[�v���k�E�W�J

        #region [�K�C�h�̃N���b�N]

        /// <summary>
        /// �L�����y�[���K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �����y�[���K�C�h���N���b�N����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_CampaignCodeGuide_Click(object sender, EventArgs e)
        {
            CampaignSt campaignSt;
            TEdit targetControl = null;
            Control nextControl = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �K�C�h�N��
                int status = _campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    string tag = (string)((UltraButton)sender).Tag;

                    if (tag.ToString().CompareTo("1") == 0)
                    {
                        targetControl = this.tNedit_CampaignCode_St;
                        nextControl = this.tNedit_CampaignCode_Ed;
                    }
                    else if (tag.ToString().CompareTo("2") == 0)
                    {
                        targetControl = this.tNedit_CampaignCode_Ed;
                        nextControl = this.tEdit_SectionCode_St;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                // �R�[�h�W�J
                targetControl.DataText = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                // �t�H�[�J�X
                nextControl.Focus();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���_�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h���N���b�N����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_SectionCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // ���_�K�C�h�\��
            status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tEdit_SectionCode_St;
                nextControl = this.tEdit_SectionCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tEdit_SectionCode_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 1: //���[�J�[�{�i��
                    case 2: //���[�J�[�{�a�k�R�[�h
                    case 3: //���[�J�[�{�O���[�v�R�[�h
                    case 4: //���[�J�[
                        nextControl = this.tNedit_GoodsMakerCd_St;
                        break;
                    case 5: //�a�k�R�[�h
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                    case 6: //�̔��敪
                        nextControl = this.tNedit_SalesCode_St;
                        break;
                    case 7: //�}�X�^���X�g 
                        nextControl = this.ChangePage_ultraOptionSet;
                        break;
                }

            }
            else
            {
                return;
            }

            if (status != 0)
            {
                return;
            }

            // �R�[�h�W�J
            targetControl.DataText = secInfoSet.SectionCode.Trim();
            // �t�H�[�J�X
            nextControl.Focus();
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h���N���b�N����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 1: //���[�J�[�{�i��
                        nextControl = this.tEdit_GoodsNo_St;
                        break;
                    case 2: //���[�J�[�{�a�k�R�[�h
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                    case 3: //���[�J�[�{�O���[�v�R�[�h
                        nextControl = this.tNedit_BLGroupCode_St;
                        break;
                    case 4: //���[�J�[
                        nextControl = this.tNedit_RateVal;
                        break;
                }

            }
            else
            {
                return;
            }
            targetControl.DataText = makerUMnt.GoodsMakerCd.ToString().TrimEnd();

            // ���t�H�[�J�X
            nextControl.Focus();
        }

        /// <summary>
        /// BL�R�[�h�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h���N���b�N����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            BLGoodsCdUMnt bLGoodsCdUmnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUmnt);
            if (status != 0) return;

            TNedit targetControl= null;
            Control nextControl= null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 2: //���[�J�[�{�a�k�R�[�h
                    case 5: //�a�k�R�[�h
                        nextControl = this.tNedit_RateVal;
                        break;
                }
            }
            else
            {
                return;
            }

            targetControl.SetInt(bLGoodsCdUmnt.BLGoodsCode);
            nextControl.Focus();
        }

        /// <summary>
        /// BL�O���[�v�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�K�C�h���N���b�N����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_BLGroupCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // �K�C�h�f�[�^�T�[�`���[�h(1:�����[�g)
            if (status != 0) return;

            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGroupCode_St;
                nextControl = this.tNedit_BLGroupCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGroupCode_Ed;
                nextControl = this.tNedit_RateVal;
            }
            else
            {
                return;
            }
            targetControl.DataText = bLGroupU.BLGroupCode.ToString().PadLeft(5, '0');
            nextControl.Focus();
        }

        /// <summary>
        /// �̔��敪�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �̔��敪�K�C�h���N���b�N����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void ub_St_SalesCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 0; // 
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 6: //�̔��敪 
                    GuideNo = 71;
                    break;
            }

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SalesCode_St;
                nextControl = this.tNedit_SalesCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SalesCode_Ed;
                nextControl = this.tNedit_RateVal;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // �t�H�[�J�X�ړ�
            nextControl.Focus();
        }

        #endregion // �K�C�h�̃N���b�N

        #region [���s�^�C�v�ύX]
        /// <summary>
        /// ���s�^�C�v�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���s�^�C�v�ύX�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 1: //���[�J�[�{�i�� 
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_GoodsNo.Visible = true;
                    this.pn_GoodsNo2.Visible = true;                           
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_BLCode.Location;
                    this.pn_PriceFl.Visible = true;
                    this.pn_PriceFl.Location = this.pn_BLGroupCode.Location;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_SalesCode.Location;
                    this.pn_BLCode.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;

                    break;
                case 2: //���[�J�[�{�a�k�R�[�h
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_BLCode.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo2.Location;
                    this.pn_BLCode.Visible = true;
                    this.pn_BLCode.Location = this.pn_GoodsNo.Location;
                                        
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 3: //���[�J�[�{�O���[�v�R�[�h
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_BLGroupCode.Visible = true;
                    this.pn_BLGroupCode.Location = this.pn_GoodsNo.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo2.Location;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_BLCode.Location;
                    
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 4: //���[�J�[ 
                    initializeLayout();
                    this.pn_Maker.Visible = true;
                    this.pn_changePage.Visible = true;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo.Location;
                    this.pn_changePage.Location = this.pn_GoodsNo2.Location;

                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 5: //�a�k�R�[�h 
                    initializeLayout();
                    this.pn_BLCode.Visible = true;
                    this.pn_BLCode.Location = this.pn_Maker.Location;
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_GoodsNo2.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo.Location;

                    this.pn_Maker.Visible = false;
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_SalesCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 6: //�̔��敪
                    initializeLayout();
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_GoodsNo2.Location;
                    this.pn_RateVal.Visible = true;
                    this.pn_RateVal.Location = this.pn_GoodsNo.Location;
                    this.pn_SalesCode.Visible = true;
                    this.pn_SalesCode.Location = this.pn_Maker.Location;
                                        
                    this.pn_Maker.Visible = false;
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_PriceFl.Visible = false;

                    break;
                case 7: //�}�X�^���X�g
                    initializeLayout();
                    this.pn_changePage.Visible = true;
                    this.pn_changePage.Location = this.pn_Maker.Location;

                    this.pn_SalesCode.Visible = false;
                    this.pn_Maker.Visible = false;
                    this.pn_GoodsNo.Visible = false;
                    this.pn_GoodsNo2.Visible = false;
                    this.pn_BLGroupCode.Visible = false;
                    this.pn_BLCode.Visible = false;
                    this.pn_PriceFl.Visible = false;
                    this.pn_RateVal.Visible = false;
                    break;

            }

            this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
            this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
            this.tNedit_BLGroupCode_St.DataText = string.Empty;
            this.tNedit_BLGroupCode_Ed.DataText = string.Empty;
            this.tNedit_BLGoodsCode_St.DataText = string.Empty;
            this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
            this.tNedit_SalesCode_St.DataText = string.Empty;
            this.tNedit_SalesCode_Ed.DataText = string.Empty;
            this.tEdit_GoodsNo_St.DataText = string.Empty;
            this.tEdit_GoodsNo_Ed.DataText = string.Empty;
            this.tNedit_PriceFl.DataText = string.Empty;
            this.tComboEditor_PriceFlDiv.Value = 0;
            this.tNedit_DiscountRate.DataText = string.Empty;
            this.tCmb_DiscountRate.Value = 0;
            this.tNedit_RateVal.DataText = string.Empty;
            this.tComboEditor_RateValDiv.Value = 0;
        }
        #endregion // ���s�^�C�v�ύX

        #region[��ʍ��ڈʒu�̏���������]
        /// <summary>
        /// ��ʍ��ڈʒu�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʍ��ڈʒu�̏����������B</br>
        /// <br>Programmer : ���i��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void initializeLayout()
        {
            this.pn_Maker.Location = new System.Drawing.Point(3, 91);
            this.pn_GoodsNo.Location = new System.Drawing.Point(3, 117);
            this.pn_GoodsNo2.Location = new System.Drawing.Point(3, 142);
            this.pn_BLCode.Location = new System.Drawing.Point(3, 169);
            this.pn_BLGroupCode.Location = new System.Drawing.Point(3, 195);
            this.pn_SalesCode.Location = new System.Drawing.Point(3, 221);
            this.pn_RateVal.Location = new System.Drawing.Point(3, 247);
            this.pn_PriceFl.Location = new System.Drawing.Point(3, 273);
            this.pn_changePage.Location = new System.Drawing.Point(3, 299);
        }
        #endregion

        #region [�폜�w��ύX]
        /// <summary>
        /// �폜�w��ݒ莞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���s�^�C�v�ύX�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void tComboEditor_LogicalDeleteCode_ValueChanged(object sender, EventArgs e)
        {
            if ((int)tComboEditor_LogicalDeleteCode.Value == 1)
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.Now);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.Now);
            }
            else
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
            }
        }
        #endregion // �폜�w��ύX

        #endregion �� Control Event

    }
}
