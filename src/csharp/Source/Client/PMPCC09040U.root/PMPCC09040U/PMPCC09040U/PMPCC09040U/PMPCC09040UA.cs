//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : PCC�i�ڐݒ�
// �v���O�����T�v   : PCC�i�ڐݒ� �t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2013/02/17  �C�����e : 2013/03/13�z�M�� SCM��Q��10276�Ή� 
//                                  SCM_DB�ɓo�^����ہASF���̊�ƃR�[�h�E���_�R�[�h�̎擾���𓾈Ӑ�}�X�^�ɕύX����       
// --------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2013/05/30  �C�����e : 2013/99/99�z�M SCM��Q��10541�Ή� 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC�i�ڐݒ� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�i�ڐݒ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br>Update Note: 2013/02/17 ����</br>
    /// <br>�Ǘ��ԍ�   : 2013/03/13�z�M��</br>
    /// <br>           : SCM��Q��10276�Ή� SCM_DB�ɓo�^����ہASF���̊�ƃR�[�h�E���_�R�[�h�̎擾���𓾈Ӑ�}�X�^�ɕύX����</br> 
    /// </remarks>
    public partial class PMPCC09040UA : Form, IMasterMaintenanceArrayType
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMPCC09040UA()
        {
            InitializeComponent();
            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;		// �f�t�H���g:true�Œ�
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;
            // �ϐ�������
            this._dataIndex = -1;
            this._detailsDataIndex = -1;
            this._totalCount = 0;
            this._detailTable = new Hashtable();
            this._pccItemGrpTable = new Hashtable();
            this._pccItemGrpAcs = new PccItemGrpAcs();
            _customerInfoAcs = new CustomerInfoAcs();
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._enterpriseName = LoginInfoAcquisition.EnterpriseName;
            //
            this._inqOtherEpCd = this._enterpriseCode;
            this._inqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //this._mainGridTitle = "PCC�i��";//DEL by huanghx for #25173 �e��}�X�^�̖��̕ύX�Ή� on 20110914
            this._mainGridTitle = "���Ӑ�";//ADD by huanghx for #25173 �e��}�X�^�̖��̕ύX�Ή� on 20110914
            //this._detailsGridTitle = "PCC�O���[�v";//DEL by huanghx for #25173 �e��}�X�^�̖��̕ύX�Ή� on 20110914
            this._detailsGridTitle = "�i�ڃO���[�v";//ADD by huanghx for #25173 �e��}�X�^�̖��̕ύX�Ή� on 20110914
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();
            GetCustomerHTable();
            //�c�[���o�[�A�C�R���ݒ�
            this.SetToolIcon();
        }
        #endregion

        #region private �ϐ�
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        private string _enterpriseCode = string.Empty;
        private string _enterpriseName = string.Empty;
        //�⍇������ƃR�[�h
        private string _inqOriginalEpCd = string.Empty;
        //�⍇�������_�R�[�h
        private string _inqOriginalSecCd = string.Empty;
        //�O�⍇������ƃR�[�h
        private string _inqOriginalEpCdPre = string.Empty;
        //�O�⍇�������_�R�[�h
        private string _inqOriginalSecCdPre = string.Empty;
        //�⍇�����ƃR�[�h
        private string _inqOtherEpCd = string.Empty;
        //�⍇���拒�_�R�[�h
        private string _inqOtherSecCd = string.Empty;
        private CustomerInfoAcs _customerInfoAcs;
        
        private PccItemGrid _pccItemGridClone = null;
        private Dictionary<int, PccItemGrp> _pccItemGrpDicClone = null;
        private Dictionary<int, Dictionary<int, PccItemSt>> _pccItemStDicDicClone = null;
        private int _prevCustomerCode = -1;
        private int _firstCustomerCode;
        /// <summary>��ʋN�������t���O</summary>
        private bool _isLoaded = false;
        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private PccItemGrpAcs _pccItemGrpAcs = null;
        private Hashtable _pccItemGrpTable;
        private Hashtable _detailTable = null;
        private int _totalCount;
        private int _indexBuf;
        private ButtonTool _closeButtonTool = null;
        private ButtonTool _saveButtonTool = null;
        private ButtonTool _newTabButtonTool = null;
        private ButtonTool _deleteTabButtonTool = null;
        private ButtonTool _clearButtonTool = null;
        private ButtonTool _allDeleteButtonTool = null;
        private ButtonTool _reviveButtonTool = null;
        private ButtonTool _reButtonNameButtonTool = null;
        private ButtonTool _quoteButtonTool = null;
        private int _startMode;                 //�N�����[�h
        private PMPCC09040UC _pMPCC09040UC;
        //���p�K�C�h���
        private PMPCC09040UD _pMPCC09040UD;
        /// <summary>
        /// PCC�i�ڃO���[�v�f�B�N�V���i���[
        /// </summary>
        private Dictionary<string, List<PccItemGrp>> _pccItemGrpDict = null;
        /// <summary>
        /// PCC�i�ڐݒ�f�B�N�V���i���[
        /// </summary>
        Dictionary<string, Dictionary<int, List<PccItemSt>>> _pccItemStDictDict = null;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        private string _targetTableName;
        private int _detailsDataIndex;
        private Image _mainGridIcon;
        private Image _detailsGridIcon;
        private string _mainGridTitle;
        private string _detailsGridTitle;
        // ���Ӑ�e�[�v��
        private Dictionary<int, PccCmpnySt> _customerHTable;
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
        //�i�ڑI���敪Hashtable
        private Hashtable _blCheckedInfoTb = null;
        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
        #region //�񋓌^��`

        /// <summary>��ʂ̋N�����[�h</summary>
        /// <remarks>0:�V�K�A1:�C��</remarks>
        public enum StartMode
        {
            /// <summary>
            /// �V�K
            /// </summary>
            MODE_NEW = 0,
            /// <summary>
            /// �ҏW
            /// </summary>
            MODE_EDIT = 1,
            /// <summary>
            /// �폜
            /// </summary>
            MODE_EDITLOGICDELETE = 2
        }

        /// <summary>
        /// ��ʕi�ڃO���[�v�̐���
        /// </summary>
        private int _tabCount = 0;

        #endregion

        #endregion

        # region ��Consts
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        private const string ASSEMBLY_ID = "PMPCC09040U";
        private const string PCCITEM_TABLE = "PCCITEM";
        private const string PCCITEMDETIAL_TABLE = "PCCITEMDETIAL";
        private const string DELETE_DATE = "�폜��";
        private const string S_DELETEDATE = "�폜��";
        //�⍇������ƃR�[�h
        private const string INQORIGINALEPCD_TITLE = "�⍇������ƃR�[�h";
        //�⍇�������_�R�[�h
        private const string INQORIGINALSECCD_TITLE = "�⍇�������_�R�[�h";
        //�⍇�����ƃR�[�h
        private const string INQOTHEREPCD_TITLE = "�⍇�����ƃR�[�h";
        //�⍇���拒�_�R�[�h
        private const string INQOTHERSECCD_TITLE = "�⍇���拒�_�R�[�h";
        //PCC���ЃR�[�h
        private const string PCCCOMPANYCODE_TITLE = "���Ӑ�R�[�h";
        //���Ӑ於
        private const string PCCCOMPANYNAME_TITLE = "���Ӑ於";
        //�i�ڃO���[�v�R�[�h
        private const string ITEMGROUPCODE_TITLE1 = "�i�ڃO���[�v�R�[�h";
        //�i�ڃO���[�v����
        private const string ITEMGROUPNAME_TITLE1 = "�i�ڃO���[�v����";
        //�i�ڃO���[�v�\������
        private const string ITEMGRPDSPODR_TITLE1 = "�i�ڃO���[�v�\������";
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //�i�ڃO���[�v�摜�R�[�h
        private const string ITEMGRPIMGCODE_TITLE1 = "�i�ڃO���[�v�摜�R�[�h";
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        //�⍇������
        private const string INQCONDITION_TITLE = "GUID";
        //�⍇������
        private const string S_INQCONDITION_TITLE = "GUID";
        private const string INF_NOT_FOUND = "�Y������f�[�^������܂���B";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";
        private const string ERR_TIMEOUT_MSG = "�폜���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const int MAX_TABCOUNT = 5;
        private const int MAXROW = 8;
        private const int MAXALLROW = 64;
        private const int GRIDCOUNT = 8;
        private const string CUSTOMEMPTY_BASE = "�x�[�X�ݒ�";
        //PCC�I�����C����ʋ敪
        private const int ONLINEKINDDIV = 10;
        private const string TODELKEY = "tab_toDelete";
        #endregion

        # region ��Main
        /// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMPCC09040UA());
        }
        # endregion

        #region ��IMasterMaintenanceInputStart Members
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraTable"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(Hashtable paraTable)
        {
            this.ShowDialog();
            return this.DialogResult;
        }
        #endregion

        # region ��IMasterMaintenanceArrayType�����o�[

        # region ��Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region ��Properties
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }
        # endregion

        # region ��Public Methods
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PCCITEM_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            List<PccItemGrid> pccItemGridList = null;
            PccItemGrid parsePccItemGrid = new PccItemGrid();
            parsePccItemGrid.EnterpriseCode = this._enterpriseCode;
            parsePccItemGrid.InqOtherEpCd = this._inqOtherEpCd;
            parsePccItemGrid.InqOtherSecCd = this._inqOtherSecCd;
            int index = 0;

            if (readCount == 0)
            {
                status = this._pccItemGrpAcs.Search(
                            out pccItemGridList,
                            out _pccItemGrpDict,
                            out _pccItemStDictDict,
                            parsePccItemGrid, 0, ConstantManagement.LogicalMode.GetData01);
            }
            
            switch (status)
            {
                  
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this._totalCount = pccItemGridList.Count;
                        this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Clear();
                        this._pccItemGrpTable.Clear();
                        foreach (PccItemGrid pccItemGridShow in pccItemGridList)
                        {
                            if (this._pccItemGrpTable.ContainsKey(pccItemGridShow.InqCondition) == false)
                            {
                                PccItemGridToDataSet(pccItemGridShow.Clone(), index);
                                ++index;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                         break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Search",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccItemGrpAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Search",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccItemGrpAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        break;
                    }
            }
            totalCount = this._totalCount;
            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            return status;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string inqCondition = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[inqCondition]).Clone();
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null; 
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            if (pccItemGrid != null && this._pccItemGrpDict != null 
                && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
            }

            if (pccItemGrid != null && this._pccItemStDictDict != null
                && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
            }

            int dummy = 0;
            status = this._pccItemGrpAcs.LogicalDelete(ref pccItemGrid,ref pccItemGrpList, ref pccItemStDict);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (pccItemGrid != null && this._pccItemGrpDict != null
                            && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemGrpDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemGrpDict.Add(pccItemGrid.InqCondition, pccItemGrpList);
                        }

                        if (pccItemGrid != null && this._pccItemStDictDict != null
                            && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemStDictDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemStDictDict.Add(pccItemGrid.InqCondition, pccItemStDict);
                        }
                        // �N���X�f�[�^�Z�b�g�W�J����
                        PccItemGridToDataSet(pccItemGrid.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccItemGrpAcs);
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Delete",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccItemGrpAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Delete",							// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._pccItemGrpAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
                    }
            }

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
        /// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>
        /// ���׃f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrModelNameU = new ArrayList();

            // ���ݕێ����Ă���i�ڐݒ�f�[�^���N���A����
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Clear();
            this._detailTable.Clear();

            if (readCount < 0) return 0;

            // �I������Ă��郁�[�J�[�f�[�^���擾����
            string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = (PccItemGrid)this._pccItemGrpTable[guid];
            List<PccItemGrp> pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];

            this._totalCount = 0;
            if (pccItemGrpList != null && pccItemGrpList.Count > 0)
            {
                int index = 0;
                this._totalCount = pccItemGrpList.Count;
                foreach (PccItemGrp wkPccItemGrp in pccItemGrpList)
                {
                    // �i�ڐݒ�N���X�f�[�^�Z�b�g�W�J����
                    PccItemGrpToDataSet(wkPccItemGrp.Clone(), index);
                    ++index;
                }
            }
            else
            {
                // ���׃f�[�^��������
                TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "DetailsDataSearch",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            "PCC�i�ڐݒ�}�X�^���̓ǂݍ��݂Ɏ��s���܂����B",						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccItemGrpAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

            }


            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <param name="appearanceTable">�O���b�h�O��</param>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // ���C���O���b�h
            Hashtable mainAppearanceTable = new Hashtable();

            // �폜��
            //�폜��
            mainAppearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

            //�⍇������ƃR�[�h
            mainAppearanceTable.Add(INQORIGINALEPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //�⍇�������_�R�[�h
            mainAppearanceTable.Add(INQORIGINALSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //�⍇�����ƃR�[�h
            mainAppearanceTable.Add(INQOTHEREPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //�⍇���拒�_�R�[�h
            mainAppearanceTable.Add(INQOTHERSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC���ЃR�[�h
            mainAppearanceTable.Add(PCCCOMPANYCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //���Ӑ於
            mainAppearanceTable.Add(PCCCOMPANYNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC���ЃR�[�h
            mainAppearanceTable.Add(INQCONDITION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            // �T�u�O���b�h
            Hashtable detailsAppearanceTable = new Hashtable();

            // �폜��
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //�i�ڃO���[�v�R�[�h1
            detailsAppearanceTable.Add(ITEMGROUPCODE_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�i�ڃO���[�v����1
            detailsAppearanceTable.Add(ITEMGROUPNAME_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�i�ڃO���[�v�\������1
            detailsAppearanceTable.Add(ITEMGRPDSPODR_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�i�ڃO���[�v�\������1
            detailsAppearanceTable.Add(S_INQCONDITION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�i�ڃO���[�v�摜�R�[�h
            detailsAppearanceTable.Add(ITEMGRPIMGCODE_TITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�\���p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // �O���b�h�\���p�f�[�^�Z�b�g��ݒ�
            bindDataSet = this.Bind_DataSet;

            // �Q�̃e�[�u�����̂̐ݒ�
            string[] strRet = new string[2];
            strRet[0] = PCCITEM_TABLE;
            strRet[1] = PCCITEMDETIAL_TABLE;
            tableName = strRet;
        }

        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] objRet = new Image[2];
            objRet[0] = this._mainGridIcon;
            objRet[1] = this._detailsGridIcon;
            return objRet;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] strRet = new string[2];
            strRet[0] = this._mainGridTitle;
            strRet[1] = this._detailsGridTitle;
            return strRet;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br></br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._dataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
        /// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }   

        # endregion

        # endregion

        #region �C�x���g
        /// <summary>Form.Load �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���ǂݍ��ݎ��̐ݒ���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UA_Load(object sender, EventArgs e)
        {
            // �N�������t���O
            this._isLoaded = false;
            // �N�����[�h�ŉ�ʃf�[�^�\������
            this.InitializeDisply();
            this._blCheckedInfoTb = new Hashtable();
            // �N�������t���O
            this._isLoaded = true;
            Initial_Timer.Enabled = true;
            // IPC�T�[�o�[�̐����E�C�x���g�o�^
           
        }

        /// <summary>
        /// Form.Closing �C�x���g(PMPCC09040UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                ClearProc();
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(PMPCC09040UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            // ��ʍč\�z����
            ScreenReconstruction();
        }

        #region MainToolbarsManager
        /// <summary>���C���c�[���o�[�}�l�[�W���[ToolClick</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// Note       : ���C���c�[���o�[�}�l�[�W���[��ToolClick�����ł��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void MainToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
             //�A�N�e�B�u��ԂɂȂ��Ă���c�[���̃t�H�[�J�X���N���A����
            e.Tool.IsActiveTool = false;
            switch (e.Tool.Key)
            {
                // ����{�^��
                case "ButtonTool_Close":
                    {
                        this.CloseForm();
                        break;
                    }
                //�ۑ��{�^��
                case "ButtonTool_Save":
                    {
                        this.SaveProc();
                        break;
                    }
                //�V�KTAB�{�^��
                case "ButtonTool_NewTab":
                    {
                        this.NewTabProc();
                        break;
                    }
                //�폜TAB�{�^��
                case "ButtonTool_DeleteTab":
                    {
                        UltraTab selectedTab = UTabControl_StayInfo.SelectedTab;
                        this.DeleteTabProc(selectedTab);
                        break;
                    }
                //�N���A�{�^��
                case "ButtonTool_Clear":
                    {
                        this._dataIndex = -1;
            
                        this.ClearProc();
                        _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                        _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                        this._pccItemGridClone = new PccItemGrid();
                        GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                        break;
                    }
                //���S�폜�{�^��
                case "ButtonTool_AllDelete":
                    {
                        this.AllDeleteProc();
                        break;
                    }
                //�����{�^��
                case "ButtonTool_Revive":
                    {
                        this.ReviveProc();
                        break;
                    }
                //TAB���ύX�{�^��
                case "ButtonTool_ReButtonName":
                    {
                        this.ReButtonProc(1);
                        break;
                    }
                //���p�{�^��
                    case "ButtonTool_Quote":
                    {
                        this.QuoteButtonProc();
                        break;
                    }
            }
        }
        #endregion

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void UButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
           
            DialogResult result = customerSearchForm.ShowDialog(this);
        }

        #region ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

        /// <summary>
        /// ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender">PMKHN4002E�t�H�[���I�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

            // �X�e�[�^�X�ɂ��G���[���b�Z�[�W���o��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status, MessageBoxButtons.OK);
                    return;
                }
                else
                {
                     //�I�����C����ʋ敪 0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��
                    if (customerInfo.OnlineKindDiv == ONLINEKINDDIV)
                    {
                        //�O�⍇������ƃR�[�h
                        this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                        //�O�⍇�������_�R�[�h
                        this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                        //�⍇������ƃR�[�h
                        this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                        //�⍇�������_�R�[�h
                        this._inqOriginalSecCd = customerInfo.CustomerSecCode;

                        string pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();//@@@@20230303
                        PccCmpnySt pccCmpnySt;
                        if (_customerHTable != null && _customerHTable.Count > 0 && _customerHTable.ContainsKey(customerInfo.CustomerCode))
                        {
                            pccCmpnySt = _customerHTable[customerInfo.CustomerCode];
                            if (ModeChangeProc(pccInqCondition, pccCmpnySt))
                            {
                                return;
                            }
                            else
                            {
                                //���Ӑ����UI�ɐݒ�
                                tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                                uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                _prevCustomerCode = customerInfo.CustomerCode;
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                //��ʓ��͋����䏈��
                                ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                UTabControl_StayInfo.Tabs[0].Selected = true;
                                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                pMPCC09040UB.SetInitFocus(this._startMode);
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                return;
                            }
                        }
                    }
                    else
                    {
                        // �G���[��
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���Ӑ�R�[�h [" + customerSearchRet.CustomerCode + "]�͐ݒ�ł��܂���B\r\n�I�����C�������m�F���ĉ������B",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status, MessageBoxButtons.OK);
                return;
            }
        }
        #endregion

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: 2013/02/17 ����</br>
        /// <br>�Ǘ��ԍ�   : 2013/03/13�z�M��</br>
        /// <br>           : ���Ӑ���͂�����A���Ӑ���Č���������ǉ�����</br> 
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // PrevCtrl�ݒ�
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            int gridNo = 0;
            // ���O�ɂ�蕪��
            switch (prevCtrl.Name)
            {
                #region ���Ӑ�R�[�h
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();
                        string pccInqCondition = string.Empty;
                        if (e.NextCtrl.Name == "MainToolbarsManager")
                        {
                            // �J�ڐ悪����{�^��

                        }
                        else
                        {

                            if (_prevCustomerCode != inputValue)
                            {
                                PccCmpnySt pccCmpnySt;
                                if (_customerHTable == null || !_customerHTable.ContainsKey(inputValue))
                                {
                                    this.GetCustomerHTable();
                                }
                                if (_customerHTable != null && _customerHTable.Count > 0 && _customerHTable.ContainsKey(inputValue))
                                {
                                    pccCmpnySt = _customerHTable[inputValue];
                                    // ----ADD 2013/02/17 ����--------->>>>>
                                    CustomerInfo customerInfo;
                                    int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, _enterpriseCode, inputValue);
                                    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || customerInfo == null) && inputValue != 0)
                                    {
                                        // �G���[��
                                        TMsgDisp.Show(this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                             "���Ӑ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",
                                            -1,
                                            MessageBoxButtons.OK);
                                        if (_prevCustomerCode == -1)
                                        {
                                            this.tNedit_CustomerCode.SetInt(0);
                                        }
                                        else
                                        {
                                            this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                                        }
                                        e.NextCtrl = e.PrevCtrl;
                                        if (_prevCustomerCode == 0)
                                        {
                                            ScreenInputPermissionControl((int)StartMode.MODE_NEW);
                                        }
                                        else
                                        {
                                            ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                        }
                                        return;
                                    }
                                    // ----ADD 2013/02/17 ����---------<<<<<
                                    //�O�⍇������ƃR�[�h
                                    this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                    //�O�⍇�������_�R�[�h
                                    this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                    // ----DEL 2013/02/17 ����--------->>>>>
                                    ////�⍇������ƃR�[�h
                                    //this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd;
                                    ////�⍇�������_�R�[�h
                                    //this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                                    // ----DEL 2013/02/17 ����---------<<<<<

                                    // ----ADD 2013/02/17 ����--------->>>>>
                                    if (customerInfo != null)
                                    {
                                        //�⍇������ƃR�[�h
                                        this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                        //�⍇�������_�R�[�h
                                        this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                    }
                                    else
                                    {
                                        //�⍇������ƃR�[�h
                                        this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                                        //�⍇�������_�R�[�h
                                        this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                                    }
                                    // ----ADD 2013/02/17 ����---------<<<<<
                                    pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                                        + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();
                                    if (ModeChangeProc(pccInqCondition, pccCmpnySt))
                                    {
                                        return;
                                    }
                                    this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName.TrimEnd();
                                    _prevCustomerCode = inputValue;
                                    //�⍇������ƃR�[�h
                                    this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                    //�⍇�������_�R�[�h
                                    this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                    ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                    UTabControl_StayInfo.Tabs[0].Selected = true;
                                    PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                    pMPCC09040UB.SetInitFocus(this._startMode);

                                }
                                else
                                {
                                    // �G���[��
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        //"PCC���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",  //DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                                         "BL�߰µ��ް���Аݒ�}�X�^�ɖ��o�^�ׁ̈A���̓��Ӑ�͐ݒ�ł��܂���B\r\n [" + inputValue + "] ",  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
                                        -1,
                                        MessageBoxButtons.OK);
                                    if (_prevCustomerCode == -1)
                                    {
                                        this.tNedit_CustomerCode.SetInt(0);
                                    }
                                    else
                                    {
                                        this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                                    }
                                    e.NextCtrl = e.PrevCtrl;
                                    if (_prevCustomerCode == 0)
                                    {
                                        ScreenInputPermissionControl((int)StartMode.MODE_NEW);
                                    }
                                    else
                                    {
                                        ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                                    }
                                    return;
                                }
                            }
                        }
                        
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.UButton_CustomerGuide;
                                        break;
                                    }
                            }

                        }

                        break;
                    }
                #endregion

                case "PMPCC09040UB":
                    {
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);
                        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
                        foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                        {
                            PMPCC09040UB pMPCC09040UEach = (PMPCC09040UB)eachTab.Tag;
                            if (this.UTabControl_StayInfo.SelectedTab.Key.Equals(eachTab.Key))
                            {
                                continue;
                            }
                            pMPCC09040UEach.SetBlChecked();
                        }
                        //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
                        break;
                    }
                // PCC�i�ڐݒ�O���b�h1
                case "PccItemSt_UltraGrid1":
                    {
                        gridNo = 0;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                // PCC�i�ڐݒ�O���b�h2
                case "PccItemSt_UltraGrid2":
                    {
                        gridNo = 1;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                // PCC�i�ڐݒ�O���b�h3
                case "PccItemSt_UltraGrid3":
                    {
                        gridNo = 2;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                // PCC�i�ڐݒ�O���b�h4
                case "PccItemSt_UltraGrid4":
                    {
                        gridNo = 3;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid5":
                    {
                        gridNo = 4;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid6":
                    {
                        gridNo = 5;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid7":
                    {
                        gridNo = 6;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
                case "PccItemSt_UltraGrid8":
                    {
                        gridNo = 7;
                        UltraGrid ultraGrid = (UltraGrid)e.PrevCtrl;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ReturnKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                pMPCC09040UB.ShiftKeyDown(ref e, 0, ref ultraGrid, gridNo);
                            }
                        }

                        break;
                    }
            }
        }

        //-----DEL by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
        ///// <summary>
        ///// Tab�ύX�C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : Tab�ύX�C�x���g���s���܂��B</br>
        ///// <br>Programmer : ���C��</br>
        ///// <br>Date       : 2011.07.20</br>
        ///// </remarks>
        //private void UTabControl_StayInfo_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        //{
        //    if (UTabControl_StayInfo.SelectedTab != null)
        //    {
        //        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.SelectedTab.Tag;
        //        if (pMPCC09040UB != null)
        //        {
        //            pMPCC09040UB.InitBlCheckedTb(ref _blCheckedInfoTb);
        //        }
        //    }
        //}
        //-----DEL by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<

        #endregion

        #region private Methods
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        /// <param name="pccInqCondition">�₹����</param>
        /// <param name="pccCmpnySt">PCC���Џ��</param>
        /// <remarks>
        /// <br>Note       : ���[�h�ύX�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// <br>Update Note: 2013/02/17 ����</br>
        /// <br>�Ǘ��ԍ�   : 2013/03/13�z�M��</br>
        /// <br>           : ���Ӑ���͂�����A���Ӑ���Č���������ǉ�����</br>   
        /// </remarks>
        private bool ModeChangeProc(string pccInqCondition, PccCmpnySt pccCmpnySt)
        {
            // ���[�J�[�ʒ񋟎擾�ݒ�}�X�^�����e�R�[�h
            bool exsit = false;
            int customerCode = this.tNedit_CustomerCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string pccInqConditionPre = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[i][INQCONDITION_TITLE];
                if (pccInqConditionPre.Equals(pccInqCondition))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        if (pccCmpnySt.PccCompanyCode == 0)
                        {
                            TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                              emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                              ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                //"�x�[�X�ݒ��PCC�i�ڐݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 	// �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                              "�x�[�X�ݒ��BL�߰µ��ް�i�ڐݒ�}�X�^���͊��ɍ폜����Ă��܂��B", �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
                              0, 									// �X�e�[�^�X�l
                              MessageBoxButtons.OK);				// �\������{�^��
                        }
                        else
                        {
                            TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                              emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                              ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                //"���͂��ꂽ�R�[�h��PCC�i�ڐݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 	// �\�����郁�b�Z�[�W�@�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                              "���͂��ꂽ�R�[�h��BL�߰µ��ް�i�ڐݒ�}�X�^���͊��ɍ폜����Ă��܂��B", �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                              0, 									// �X�e�[�^�X�l
                              MessageBoxButtons.OK);				// �\������{�^��
                        }
                        // PCC�i�ڐݒ�}�X�^�����e�R�[�h�̃N���A
                        if (_prevCustomerCode == -1)
                        {
                            this.tNedit_CustomerCode.SetInt(0);
                        }
                        else
                        {
                            this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                        }
                        //�⍇������ƃR�[�h
                        this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                        //�⍇�������_�R�[�h
                        this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                        UTabControl_StayInfo.Tabs[0].Selected = true;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);

                        return true;
                    }
                    exsit = true;
                    DialogResult res = DialogResult.No;
                    if (pccCmpnySt.PccCompanyCode == 0)
                    {
                        res = TMsgDisp.Show(
                           this,                                   // �e�E�B���h�E�t�H�[��
                           emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                           ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //"�x�[�X�ݒ��PCC�i�ڐݒ�}�X�^����񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                           "�x�[�X�ݒ��BL�߰µ��ް�i�ڐݒ�}�X�^����񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H", �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                           0,                                      // �X�e�[�^�X�l
                           MessageBoxButtons.YesNo);               // �\������{�^��
                    }
                    else
                    {
                        res = TMsgDisp.Show(
                            this,                                   // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                            ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //"���͂��ꂽ�R�[�h��PCC�i�ڐݒ�}�X�^����񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                            "���͂��ꂽ�R�[�h��BL�߰µ��ް�i�ڐݒ�}�X�^����񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                            0,                                      // �X�e�[�^�X�l
                            MessageBoxButtons.YesNo);               // �\������{�^��
                    }
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                this.ClearProc();
                                ScreenReconstruction();
                                this.tNedit_CustomerCode.SetInt(pccCmpnySt.PccCompanyCode);
                                uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName.TrimEnd();
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �R�[�h�̃N���A
                                if (_prevCustomerCode == -1)
                                {
                                    this.tNedit_CustomerCode.SetInt(0);
                                }
                                else
                                {
                                    this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                                }
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                                UTabControl_StayInfo.Tabs[0].Selected = true;
                                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                pMPCC09040UB.SetInitFocus(this._startMode);

                                break;
                            }
                    }
                    return true;
                }
               
            }
            if (!exsit && this._dataIndex >= 0)
            {
                DialogResult res = DialogResult.No;
                if (pccCmpnySt.PccCompanyCode == 0)
                {
                    res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        //"�x�[�X�ݒ�̂o�b�b���Аݒ�}�X�^���͑��݂��܂���B\n�V�K�o�^���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "�x�[�X�ݒ��BL�߰µ��ް���Аݒ�}�X�^���͑��݂��܂���B\n�V�K�o�^���s���܂����H", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                }
                else
                {
                    res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        //"���͂��ꂽ�R�[�h�̂o�b�b���Аݒ�}�X�^���͑��݂��܂���B\n�V�K�o�^���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "���͂��ꂽ�R�[�h��BL�߰µ��ް���Аݒ�}�X�^���͑��݂��܂���B\n�V�K�o�^���s���܂����H",  �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                }
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // ��ʍĕ`��
                            this._dataIndex = -1;
                            ClearProc();
                            _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                            _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                            this._pccItemGridClone = new PccItemGrid();
                            GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                            // �V�K���[�h
                            this.Mode_Label.Text = INSERT_MODE;
                            this.tNedit_CustomerCode.SetInt(pccCmpnySt.PccCompanyCode);
                            this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName;
                            this._prevCustomerCode = pccCmpnySt.PccCompanyCode;
                            // ----DEL 2013/02/17 ����--------->>>>>
                            ////�⍇������ƃR�[�h
                            //this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd;
                            ////�⍇�������_�R�[�h
                            //this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                            ////�⍇������ƃR�[�h
                            //this._inqOriginalEpCdPre = pccCmpnySt.InqOriginalEpCd;
                            ////�⍇�������_�R�[�h
                            //this._inqOriginalSecCdPre = pccCmpnySt.InqOriginalSecCd;
                            // ----DEL 2013/02/17 ����---------<<<<<
                            // ----ADD 2013/02/17 ����--------->>>>>
                            CustomerInfo customerInfo;
                            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, _enterpriseCode, pccCmpnySt.PccCompanyCode);
                            if (customerInfo != null)
                            {
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                            }
                            else
                            {
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                            }
                            //�⍇������ƃR�[�h
                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                            //�⍇�������_�R�[�h
                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                            // ----ADD 2013/02/17 ����---------<<<<<
                            ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                            UTabControl_StayInfo.Tabs[0].Selected = true;
                            PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                            pMPCC09040UB.SetInitFocus(this._startMode);
                            break;
                        }
                    case DialogResult.No:
                        {
                            // �R�[�h�̃N���A
                            if (_prevCustomerCode == -1)
                            {
                                this.tNedit_CustomerCode.SetInt(0);
                            }
                            else
                            {
                                this.tNedit_CustomerCode.SetInt(_prevCustomerCode);
                            }
                            //�⍇������ƃR�[�h
                            this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                            //�⍇�������_�R�[�h
                            this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                            break;
                        }
                }
                return true;


            }
           
            return false;
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable pccItemTable = new DataTable(PCCITEM_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            pccItemTable.Columns.Add(DELETE_DATE, typeof(string));
            pccItemTable.Columns.Add(INQORIGINALEPCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQORIGINALSECCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQOTHEREPCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQOTHERSECCD_TITLE, typeof(string));
            pccItemTable.Columns.Add(PCCCOMPANYCODE_TITLE, typeof(int));
            pccItemTable.Columns.Add(PCCCOMPANYNAME_TITLE, typeof(string));
            pccItemTable.Columns.Add(INQCONDITION_TITLE, typeof(string));
            this.Bind_DataSet.Tables.Add(pccItemTable);

            // ���׃e�[�u���̗��`
            DataTable detailDt = new DataTable(PCCITEMDETIAL_TABLE);
            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            detailDt.Columns.Add(S_DELETEDATE, typeof(string));                 // �폜��
            detailDt.Columns.Add(ITEMGROUPCODE_TITLE1, typeof(int));			// �i�ڃO���[�v�R�[�h
            detailDt.Columns.Add(ITEMGROUPNAME_TITLE1, typeof(string));			// �i�ڃO���[�v����
            detailDt.Columns.Add(ITEMGRPDSPODR_TITLE1, typeof(int));		    // �i�ڃO���[�v�\������
            detailDt.Columns.Add(S_INQCONDITION_TITLE, typeof(string));           // �i�ڃO���[�vGUID
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            detailDt.Columns.Add(ITEMGRPIMGCODE_TITLE1, typeof(short));			// �i�ڃO���[�v�摜�R�[�h
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            this.Bind_DataSet.Tables.Add(detailDt);
        }

        /// <summary>
        /// ��ʏ����\��
        /// </summary>
        /// <remarks>
        /// <br> Note       : ��ʏ����\�����s���܂��B</br>
        /// <br> Programmer : ���C��</br> 
        /// <br> Date       : 2011.07.20</br>
        /// </remarks>
        private void InitializeDisply()
        {
            // �^�u���e��\������
            NewTabProc();
        }

        /// <summary>
        /// ��ʍ\��������������
        /// </summary>
        /// <remarks>
        ///<br> Note       : ��ʍ\�������������܂��B</br>
        ///<br> Programmer : ���C��</br> 
        ///<br> Date       : 2011.07.20</br>
        /// </remarks>
        private void NewTabProc()
        {
            PMPCC09040UB  pMPCC09040UB = new PMPCC09040UB(this._enterpriseCode, this._startMode);
            pMPCC09040UB.Dock = DockStyle.Fill;
            pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
            _tabCount = _tabCount + 1;
            // �^�u�y�[�W�R���g���[�����C���X�^���X
            UltraTabPageControl uTabPageControl = new UltraTabPageControl();
            // �^�u�L�[
            string tabKey = "tabKey" + this._tabCount.ToString();
            // �^�u����
            string tabName = string.Empty;
           
            // �ǉ��^�u�ݒ�ʒu
            int newIdex = 0;
            newIdex = this.UTabControl_StayInfo.Tabs.Count;
            this.UTabControl_StayInfo.Tabs.Insert(newIdex, tabKey, tabName);

             // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
             UltraTab uTab = this.UTabControl_StayInfo.Tabs[newIdex];
             uTab.TabPage = uTabPageControl;
             uTab.Tag = pMPCC09040UB;
             uTab.Appearance.BackColor = Color.White;
             uTab.Appearance.BackColor2 = Color.Lavender;
             uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
             uTab.ActiveAppearance.BackColor = Color.White;
             uTab.ActiveAppearance.BackColor2 = Color.LightPink;
             uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;
             uTab.VisibleIndex = newIdex;

             uTabPageControl.Controls.Add(pMPCC09040UB);
             this.UTabControl_StayInfo.Controls.Add(uTabPageControl);
             this.UTabControl_StayInfo.SelectedTab = uTab;
             
             // �V�K�^�u��I��
             UltraTab uTabDel = this.UTabControl_StayInfo.Tabs[0];
             if (TODELKEY.Equals(uTabDel.Key) && !_isLoaded)
             {
                 this.UTabControl_StayInfo.Tabs.Remove(uTabDel);
             }
             int tabCount = this.UTabControl_StayInfo.Tabs.Count;
             if (tabCount >= MAX_TABCOUNT)
             {
                 this._newTabButtonTool.SharedProps.Enabled = false;
             }
             else
             {
                 this._newTabButtonTool.SharedProps.Enabled = true;
             }
            if (tabCount == 1)
            {
                this._deleteTabButtonTool.SharedProps.Enabled = false;
            }
            else
            {
                this._deleteTabButtonTool.SharedProps.Enabled = true;
            }
        }

      
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            //���Аݒ�}�X�^�擾����
            GetCustomerHTable();
            if (this.DataIndex < 0)
            {
                
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                this._startMode = (int)StartMode.MODE_NEW;
                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(this._startMode);
                // �t�H�[�J�X�ݒ�
                UTabControl_StayInfo.Tabs[0].Selected = true;
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                pMPCC09040UB.SetInitFocus(this._startMode);
                 this.tNedit_CustomerCode.Focus();
                 //���݂̉�ʏ����擾����
                 if (this._pccItemGridClone != null)
                 {
                     this._pccItemGridClone = new PccItemGrid();
                 }
                 _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                 _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                 this._pccItemGridClone = new PccItemGrid();
                 GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                _firstCustomerCode = 0;
                //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
                // BL�R�[�h�`�F�b�N�e�v�b���擾����
                this._blCheckedInfoTb = new Hashtable();
                foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                {
                    PMPCC09040UB pMPCC09040UBEach = (PMPCC09040UB)eachTab.Tag;
                    pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                    pMPCC09040UB.InitBlCheckedTb();
                    this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
                }
                //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
                
            }
            else
            {
                string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
                this._startMode = (int)StartMode.MODE_EDIT;
                PccItemGrid pccItemGrid = (PccItemGrid)this._pccItemGrpTable[guid];
                List<PccItemGrp> pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
                Dictionary<int, List<PccItemSt>> pccItemStDict = null;
                if (pccItemGrpList != null)
                {
                    if (this._pccItemStDictDict != null && this._pccItemStDictDict.Count > 0
                        && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                    {
                        pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
                    }
                }
                // ��ʓW�J����
                tNedit_CustomerCode.SetInt(pccItemGrid.PccCompanyCode);
                _firstCustomerCode = pccItemGrid.PccCompanyCode;
                _prevCustomerCode = pccItemGrid.PccCompanyCode;
                //���Ӑ揉����
               
                //���Ӑ於��
                uLabel_CustomerName.Text = pccItemGrid.PccCompanyName;
                //�⍇������ƃR�[�h
                this._inqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                //�⍇�������_�R�[�h
                this._inqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                //�O�⍇������ƃR�[�h
                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                //�O�⍇�������_�R�[�h
                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                this._prevCustomerCode = pccItemGrid.PccCompanyCode;
                PccItemToScreen(pccItemGrpList, pccItemStDict);
                UltraTab selectedTab = UTabControl_StayInfo.Tabs[0];
                this.DeleteTabProc(selectedTab);

                if (pccItemGrid.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;
                    this._startMode = (int)StartMode.MODE_EDIT;
                   
                    
                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(this._startMode);

                    // �{�^���ݒ�
                    this._deleteTabButtonTool.SharedProps.Enabled = true;
                    if (pccItemGrpList.Count == MAX_TABCOUNT)
                    {
                        this._newTabButtonTool.SharedProps.Enabled = false;
                    }
                    else
                    {
                        this._newTabButtonTool.SharedProps.Enabled = true;
                    }


                    //�N���[���쐬
                    //���݂̉�ʏ����擾����
                    this._pccItemGridClone = pccItemGrid;
                    _pccItemStDicDicClone = new Dictionary<int, Dictionary<int, PccItemSt>>();
                    _pccItemGrpDicClone = new Dictionary<int, PccItemGrp>();
                    GetListFromTabs(ref _pccItemStDicDicClone, out _pccItemGrpDicClone, ref  this._pccItemGridClone);
                    UTabControl_StayInfo.Tabs[0].Selected = true;
                    //-----DEL by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
                    //PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                    //pMPCC09040UB.InitBlCheckedTb();
                    //-----DEL by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
                    //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
                    // BL�R�[�h�`�F�b�N�e�v�b���擾����
                    this._blCheckedInfoTb = new Hashtable();
                    foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                    {
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)eachTab.Tag;
                        pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                        pMPCC09040UB.InitBlCheckedTb();
                        this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
                    }
                    //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;
                    this.tNedit_CustomerCode.Focus();
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;
                    
                    this._startMode = (int)StartMode.MODE_EDITLOGICDELETE;
                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                   
                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(this._startMode);
                    UTabControl_StayInfo.Tabs[0].Selected = true; ;
                }

            }
        }

        /// <summary>
        /// PCC�i�ډ�ʓW�J����
        /// </summary>
        /// <param name="pccItemGrpList">PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">PCC�i�ڐݒ�f�B�N�V���i���[</param>
        /// <remarks>
        /// <br>Note       : ��ʓW�J�����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemToScreen(List<PccItemGrp> pccItemGrpList, Dictionary<int, List<PccItemSt>> pccItemStDict)
        {
            foreach (PccItemGrp pccItemGrp in pccItemGrpList)
            {
                NewTabProc();
                UltraTab newtab = this.UTabControl_StayInfo.SelectedTab;
                newtab.Text = pccItemGrp.ItemGroupName;
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)newtab.Tag;
                if (pccItemStDict != null && pccItemStDict .Count > 0 
                    && pccItemStDict.ContainsKey(pccItemGrp.ItemGroupCode))
                {
                    pMPCC09040UB.PccItemToGrid(pccItemStDict[pccItemGrp.ItemGroupCode]);
                }
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //�i�ڃO���[�v�摜�\��
                pMPCC09040UB.ImageComboSet(pccItemGrp.ItemGrpImgCode);
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        /// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
        /// <param name="modifyFiag">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���C��</br>
		/// <br>Date       : 2011.07.20</br>
		/// </remarks>
        private void ScreenInputPermissionControl(int modifyFiag)
        {
            switch (modifyFiag)
            {
                case (int)StartMode.MODE_NEW:
                    {
                        tNedit_CustomerCode.Enabled = true;
                        UButton_CustomerGuide.Enabled = true;
                        GridsPermissionControl(false);
                        // �{�^���ݒ�
                        this._saveButtonTool.SharedProps.Enabled = false;
                        this._reviveButtonTool.SharedProps.Enabled = false;
                        this._allDeleteButtonTool.SharedProps.Enabled = false;
                        this._deleteTabButtonTool.SharedProps.Enabled = false;
                        this._newTabButtonTool.SharedProps.Enabled = false;
                        this._clearButtonTool.SharedProps.Enabled = false;
                        this._reButtonNameButtonTool.SharedProps.Enabled = false;
                        this._quoteButtonTool.SharedProps.Enabled = false;
                        break;
                    }
                case (int)StartMode.MODE_EDIT:
                    {
                        tNedit_CustomerCode.Enabled = true;
                        UButton_CustomerGuide.Enabled = true;
                        GridsPermissionControl(true);
                        // �{�^���ݒ�
                        this._saveButtonTool.SharedProps.Enabled = true;
                        this._reviveButtonTool.SharedProps.Enabled = false;
                        this._allDeleteButtonTool.SharedProps.Enabled = false;
                        this._clearButtonTool.SharedProps.Enabled = true;
                        this._reButtonNameButtonTool.SharedProps.Enabled = true;
                        this._quoteButtonTool.SharedProps.Enabled = true;

                        if (UTabControl_StayInfo.Tabs.Count == 1)
                        {
                            this._deleteTabButtonTool.SharedProps.Enabled = false;
                        }
                        else
                        {
                            this._deleteTabButtonTool.SharedProps.Enabled = true;
                        }
                        if (UTabControl_StayInfo.Tabs.Count == MAX_TABCOUNT)
                        {
                            this._newTabButtonTool.SharedProps.Enabled = false;
                        }
                        else
                        {
                            this._newTabButtonTool.SharedProps.Enabled = true;
                        }
                        break;
                    }
                case (int)StartMode.MODE_EDITLOGICDELETE:
                    {
                        tNedit_CustomerCode.Enabled = false;
                        UButton_CustomerGuide.Enabled = false;
                        GridsPermissionControl(false);
                        // �{�^���ݒ�
                        this._saveButtonTool.SharedProps.Enabled = false;
                        this._reviveButtonTool.SharedProps.Enabled = true;
                        this._allDeleteButtonTool.SharedProps.Enabled = true;
                        this._deleteTabButtonTool.SharedProps.Enabled = false;
                        this._newTabButtonTool.SharedProps.Enabled = false;
                        this._clearButtonTool.SharedProps.Enabled = false;
                        this._reButtonNameButtonTool.SharedProps.Enabled = false;
                        this._quoteButtonTool.SharedProps.Enabled = false;
                        break;
                    }
            }
           
        }

        /// <summary>
        /// ��ʃO���b�h�ҏW�����䏈��
        /// </summary>
        /// <param name="enabled">���͋��ݒ�l</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̃O���b�h�ҏW�𐧌䂵�܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GridsPermissionControl(bool enabled)
        {
            if (UTabControl_StayInfo.Tabs != null && UTabControl_StayInfo.Tabs.Count > 0)
            {
                foreach (UltraTab uTab in UTabControl_StayInfo.Tabs)
                {
                    PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)uTab.Tag;
                    if (pMPCC09040UB != null)
                    {
                        pMPCC09040UB.PermissionControl(enabled);
                    }
                }
            }
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="pccItemGrid">PCC�i�ڃO���[�v�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃO���[�v���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemGridToDataSet(PccItemGrid pccItemGrid, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PCCITEM_TABLE].NewRow();
                this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows.Count - 1;
            }

            if (pccItemGrid.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][DELETE_DATE] = pccItemGrid.UpdateDateTimeJpInFormal;
            }
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQORIGINALEPCD_TITLE] = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQORIGINALSECCD_TITLE] = pccItemGrid.InqOriginalSecCd;
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQOTHEREPCD_TITLE] = pccItemGrid.InqOtherEpCd;
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQOTHERSECCD_TITLE] = pccItemGrid.InqOtherSecCd;

            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][PCCCOMPANYCODE_TITLE] = pccItemGrid.PccCompanyCode;
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][PCCCOMPANYNAME_TITLE] = pccItemGrid.PccCompanyName;
            // GUID
            this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[index][INQCONDITION_TITLE] = pccItemGrid.InqCondition;

            if (this._pccItemGrpTable.ContainsKey(pccItemGrid.InqCondition))
            {
                this._pccItemGrpTable.Remove(pccItemGrid.InqCondition);
            }
            this._pccItemGrpTable.Add(pccItemGrid.InqCondition, pccItemGrid);

        }

        /// <summary>
        /// PCC�i�ڐݒ�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="pccItemGrp">PCC�i�ڐݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : PCC�i�ڐݒ���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void PccItemGrpToDataSet(PccItemGrp pccItemGrp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].NewRow();
                this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows.Count - 1;
            }

            if (pccItemGrp.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][S_DELETEDATE] = pccItemGrp.UpdateDateTimeJpInFormal;
            }
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGROUPCODE_TITLE1] = pccItemGrp.ItemGroupCode;
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGROUPNAME_TITLE1] = pccItemGrp.ItemGroupName;
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGRPDSPODR_TITLE1] = pccItemGrp.ItemGrpDspOdr;
            // GUID
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][S_INQCONDITION_TITLE] = pccItemGrp.InqCondition;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this.Bind_DataSet.Tables[PCCITEMDETIAL_TABLE].Rows[index][ITEMGRPIMGCODE_TITLE1] = pccItemGrp.ItemGrpImgCode;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            if (this._detailTable.ContainsKey(pccItemGrp.InqCondition))
            {
                this._detailTable.Remove(pccItemGrp.InqCondition);
            }
            this._detailTable.Add(pccItemGrp.InqCondition, pccItemGrp);

        }

        /// <summary>�A�C�R���̐ݒ�</summary>
        /// <remarks>
        /// Note       : �t���[���̃A�C�R���̐ݒ���s���܂��B<br />
        /// Programmer : ���C��
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void SetToolIcon()
        {
            //�c�[���o�[
            _closeButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Close"];
            _saveButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Save"];
            _newTabButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_NewTab"];
            _deleteTabButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_DeleteTab"];
            _clearButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Clear"];
            _allDeleteButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_AllDelete"];
            _reviveButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Revive"];
            _reButtonNameButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_ReButtonName"];

            _quoteButtonTool = (ButtonTool)this.MainToolbarsManager.Tools["ButtonTool_Quote"];
            this.MainToolbarsManager.ImageListSmall = IconResourceManagement.ImageList24;
            _closeButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.CLOSE;
            _saveButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SAVE;
            _newTabButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.NEW;
            _deleteTabButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            _allDeleteButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            _reviveButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.REVIVAL;
            _reButtonNameButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SETUP1;
            _quoteButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.ADJUST;
            _clearButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            
            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.UButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// ��ʂ̕߂�
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Note       : �t���[���̃A�C�R���̐ݒ���s���܂��B<br />
        /// Programmer : ���C��<br />
        /// Date       : 2011.7.20<br />
        /// </remarks>
        private void CloseForm()
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                Dictionary<int, PccItemGrp> pccItemGrpDic = new Dictionary<int,PccItemGrp>();
                Dictionary<int, Dictionary<int, PccItemSt>> pccItemStDictPs = new Dictionary<int,Dictionary<int,PccItemSt>>();
                PccItemGrid pccItemGrid = new PccItemGrid();
                pccItemGrid = this._pccItemGridClone.Clone();
                //���݂̉�ʏ����擾����
                GetListFromTabs(ref pccItemStDictPs, out pccItemGrpDic, ref  pccItemGrid);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                bool isEquals = ListCompare(pccItemGrpDic, pccItemStDictPs);
                if (!isEquals)
               {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
								 tNedit_CustomerCode.Focus();
                                UTabControl_StayInfo.Tabs[0].Selected = true;
                                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                                pMPCC09040UB.SetInitFocus(this._startMode);
                                
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            ClearProc();
            
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

        }

        /// <summary>
        /// ���PCC�i�ڃO���[�v�N���X��r
        /// </summary>
        /// <param name="pccItemGrpList">���PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">���PCC�i�ڐݒ�</param>
        /// <remarks>
        /// <br>Note       : ���PCC�i�ڃO���[�v�N���X���r���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ListCompare(Dictionary<int, PccItemGrp> pccItemGrpList, Dictionary<int, Dictionary<int, PccItemSt>> pccItemStDict)
        {
            bool isEqualsValue = true;
            if (_firstCustomerCode != tNedit_CustomerCode.GetInt())
            {
                isEqualsValue = false;
                return isEqualsValue;
            }
            if (pccItemGrpList.Count != this._pccItemGrpDicClone.Count || pccItemStDict.Count != this._pccItemStDicDicClone.Count)
            {
                isEqualsValue = false;
                return isEqualsValue;
            }
            //PCC�i�ڃO���[�v��r
            foreach (KeyValuePair<int, PccItemGrp> pairPccItemGrp in pccItemGrpList)
             {
                if (!this._pccItemGrpDicClone.ContainsKey(pairPccItemGrp.Key) || !pairPccItemGrp.Value.Equals(this._pccItemGrpDicClone[pairPccItemGrp.Key]))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
            }
            //PCC�i�ڐݒ��r
            foreach (KeyValuePair<int, Dictionary<int, PccItemSt>> pccItemStPair in pccItemStDict)
            {

                if (pccItemStPair.Value.Count != (this._pccItemStDicDicClone[pccItemStPair.Key].Count))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                if (!this._pccItemStDicDicClone.ContainsKey(pccItemStPair.Key))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
                foreach (KeyValuePair<int, PccItemSt> pccItemStPairPair in pccItemStPair.Value)
                {
                    if (!this._pccItemStDicDicClone[pccItemStPair.Key].ContainsKey(pccItemStPairPair.Key))
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }
                    if (!pccItemStPairPair.Value.Equals((this._pccItemStDicDicClone[pccItemStPair.Key][pccItemStPairPair.Key])))
                    {
                        isEqualsValue = false;
                        return isEqualsValue;
                    }
                }
            }
            return isEqualsValue;
        }

        /// <summary>
        /// ���PCC�i�ڃO���[�v�N���X�i�[����
        /// </summary>
        /// <param name="pccItemGrpList">���PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemStDict">���PCC�i�ڐݒ胊�X�g</param>
        /// <param name="pccItemGrid">���PCC�i�ڃO���b�h</param>
        /// <remarks>
        /// <br>Note       : ���PCC�i�ڃO���[�v�N���X�i�[���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void DispToPccItemGrp(ref List<PccItemGrp> pccItemGrpList, ref Dictionary<int, List<PccItemSt>> pccItemStDict, ref PccItemGrid pccItemGrid)
        {
            //�X�V�O��PCC�i�ڃO���[�v���X�g
            List<PccItemGrp> pccItemGrpListOld = null;
            //PCC�i�ڃO���[�v�f�B�N�V���i���[
            Dictionary<int, PccItemGrp> pccItemGrpDic = null;
            Dictionary<int, Dictionary<int, PccItemSt>> pccItemStDictPs = null;
            //�X�V���PCC�i�ڃO���[�v���X�g
            pccItemGrpList = null;
            //PCC�i�ڃO���b�h�}�X�^
            if (pccItemGrid == null)
            {
                pccItemGrid = new PccItemGrid();
                //PCC���ЃR�[�h
                pccItemGrid.PccCompanyCode = this.tNedit_CustomerCode.GetInt();
                //��ƃR�[�h
                pccItemGrid.EnterpriseCode = this._enterpriseCode;
                pccItemGrid.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
                pccItemGrid.InqOriginalSecCd = this._inqOriginalSecCd;
                pccItemGrid.InqOtherEpCd = this._inqOtherEpCd;
                pccItemGrid.InqOtherSecCd = this._inqOtherSecCd;
            }
            GetListFromTabs(ref pccItemStDictPs, out pccItemGrpDic, ref pccItemGrid);
            if (this._pccItemGrpDict != null && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                //PCC�i�ڃO���[�v���X�g���ݏꍇ
                pccItemGrpListOld = this._pccItemGrpDict[pccItemGrid.InqCondition];
                //PCC�i�ڃO���[�v���X�g���X�V
                foreach (PccItemGrp pccItemGrp in pccItemGrpListOld)
                {
                    PccItemGrp pccItemGrpNew = null;
                    if (pccItemGrpDic != null && pccItemGrpDic.ContainsKey(pccItemGrp.ItemGroupCode))
                    {
                        pccItemGrpNew = new PccItemGrp();
                        pccItemGrpNew = pccItemGrpDic[pccItemGrp.ItemGroupCode];
                        pccItemGrpNew.CreateDateTime = pccItemGrp.CreateDateTime;
                        pccItemGrpNew.UpdateDateTime = pccItemGrp.UpdateDateTime;
                        pccItemGrpNew.InqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                        pccItemGrpNew.InqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                        pccItemGrpNew.InqOtherEpCd = pccItemGrid.InqOtherEpCd;
                        pccItemGrpNew.InqOtherSecCd = pccItemGrid.InqOtherSecCd;
                        pccItemGrpNew.InqCondition = pccItemGrid.InqCondition;
                        pccItemGrpNew.LogicalDeleteCode = pccItemGrp.LogicalDeleteCode;
                        //�X�V�敪= 1:�X�V
                        pccItemGrpNew.UpdateFlag = pccItemGrp.UpdateFlag;
                        pccItemGrpDic.Remove(pccItemGrp.ItemGroupCode);

                    }
                    else
                    {
                        pccItemGrpNew = pccItemGrp;
                        //�X�V�敪= 2:�폜
                        pccItemGrpNew.UpdateFlag = 2;
                    }
                    pccItemGrpDic.Add(pccItemGrpNew.ItemGroupCode, pccItemGrpNew);
                }
            }
            //�X�V���PCC�i�ڃO���[�v���X�g���쐬
            if (pccItemGrpDic != null && pccItemGrpDic.Count > 0)
            {
                pccItemGrpList = new List<PccItemGrp>();
                pccItemGrpList.AddRange(pccItemGrpDic.Values);
                
            }

            //�X�V�O��PCC�i�ڐݒ�f�B�N�V���i���[
            Dictionary<int, List<PccItemSt>> pccItemStDictOld = null;
            if (this._pccItemStDictDict != null && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                //PCC�i�ڃO���[�v���X�g���ݏꍇ
                pccItemStDictOld = this._pccItemStDictDict[pccItemGrid.InqCondition];
                foreach (KeyValuePair<int, List<PccItemSt>> pccItemStListPair in pccItemStDictOld)
                {
                    Dictionary<int, PccItemSt> pccItemStListNew = new Dictionary<int, PccItemSt>();
                    if (pccItemStDictPs != null && pccItemStDictPs.Count > 0 && pccItemStDictPs.ContainsKey(pccItemStListPair.Key))
                    {
                        pccItemStListNew = new Dictionary<int, PccItemSt>();
                        pccItemStListNew = pccItemStDictPs[pccItemStListPair.Key];
                        foreach (PccItemSt pccItemSt in pccItemStListPair.Value)
                        {
                            int  listDiv = 0;
                            if (pccItemSt.ItemDspPos2 >= MAXROW)
                            {
                                listDiv = (pccItemSt.ItemDspPos1 + (GRIDCOUNT / 2) -1) * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            else
                            {
                                listDiv = pccItemSt.ItemDspPos1 * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            if (pccItemStListNew != null && pccItemStListNew.Count > 0 && pccItemStListNew.ContainsKey(listDiv))
                            {
                                PccItemSt pccItemStNew = pccItemStDictPs[pccItemStListPair.Key][listDiv];
                                pccItemStNew.CreateDateTime = pccItemSt.CreateDateTime;
                                pccItemStNew.UpdateDateTime = pccItemSt.UpdateDateTime;
                                pccItemStNew.InqOtherEpCd = pccItemSt.InqOtherEpCd;
                                pccItemStNew.InqOtherSecCd = pccItemSt.InqOtherSecCd;

                                pccItemStNew.LogicalDeleteCode = pccItemSt.LogicalDeleteCode;
                                //�X�V�敪= 1:�X�V
                                pccItemStNew.UpdateFlag = pccItemSt.UpdateFlag;
                            }
                            else
                            {
                                //�X�V�敪= 2:�폜
                                pccItemSt.UpdateFlag = 2;
                                pccItemStListNew.Add(listDiv, pccItemSt);
                            }
                        }
                        pccItemStDictPs.Remove(pccItemStListPair.Key);
                        pccItemStDictPs.Add(pccItemStListPair.Key, pccItemStListNew);
                    }
                    else
                    {
                        if (pccItemStDictPs != null && pccItemStDictPs.Count > 0)
                        {
                            pccItemStDictPs.Remove(pccItemStListPair.Key);
                        }
                        else
                        {
                            pccItemStDictPs = new Dictionary<int, Dictionary<int, PccItemSt>>();
                        }
                        foreach (PccItemSt pccItemSt in pccItemStListPair.Value)
                        {
                            int listDiv = 0;
                            if (pccItemSt.ItemDspPos2 >= MAXROW)
                            {
                                listDiv = (pccItemSt.ItemDspPos1 + (GRIDCOUNT / 2) - 1) * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            else
                            {
                                listDiv = pccItemSt.ItemDspPos1 * MAXROW + pccItemSt.ItemDspPos2;
                            }
                            //�X�V�敪= 2:�폜
                            pccItemSt.UpdateFlag = 2;
                            pccItemStListNew.Add(listDiv, pccItemSt);
                        }
                        pccItemStDictPs.Add(pccItemStListPair.Key, pccItemStListNew);

                    }
                   
                }
            }
            
            pccItemStDict = new Dictionary<int, List<PccItemSt>>();
            if (pccItemStDictPs != null && pccItemStDictPs.Count > 0)
            {
                foreach (KeyValuePair<int, Dictionary<int, PccItemSt>> pccItemStListPair in pccItemStDictPs)
                {
                    List<PccItemSt> pccItemStNewList = new List<PccItemSt>();
                    pccItemStNewList.AddRange(pccItemStListPair.Value.Values);
                    pccItemStDict.Add(pccItemStListPair.Key, pccItemStNewList);
                }
            }
           
        }

        /// <summary>
        /// ���PCC�i�ڐݒ胉�X�i�[����
        /// </summary>
        /// <param name="pccItemStDict">���PCC�i�ڐݒ胊�X�g</param>
        /// <param name="pccItemGrpDic">���PCC�i�ڃO���[�v���X�g</param>
        /// <param name="pccItemGrid">���PCC�i�ڃO���b�h</param>
        /// <remarks>
        /// <br>Note       : ���PCC�i�ڐݒ�N���X�i�[���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void GetListFromTabs(ref Dictionary<int, Dictionary<int,PccItemSt>> pccItemStDict, out Dictionary<int, PccItemGrp> pccItemGrpDic, ref PccItemGrid pccItemGrid)
        {
            //��ʂ�Tabs�����擾
            int i = 1;
            pccItemGrpDic = null;
            PccItemGrp pccItemGrp = null;
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            {
                PMPCC09040UB pMPCC09040U = (PMPCC09040UB)eachTab.Tag;
                //PCC�i�ڃO���[�v�N���X
                pccItemGrp = new PccItemGrp();
                //PCC���ЃR�[�h
                pccItemGrp.PccCompanyCode = pccItemGrid.PccCompanyCode;
                //��ƃR�[�h
                pccItemGrp.InqCondition = pccItemGrid.InqCondition;
                pccItemGrp.InqOriginalEpCd = pccItemGrid.InqOriginalEpCd.Trim();//@@@@20230303
                pccItemGrp.InqOriginalSecCd = pccItemGrid.InqOriginalSecCd;
                pccItemGrp.InqOtherEpCd = pccItemGrid.InqOtherEpCd;
                pccItemGrp.InqOtherSecCd = pccItemGrid.InqOtherSecCd;
                //�i�ڃO���[�v�R�[�h
                pccItemGrp.ItemGroupCode = i;
                //�i�ڃO���[�v����
                pccItemGrp.ItemGroupName = eachTab.Text;
                //�i�ڃO���[�v�\������
                pccItemGrp.ItemGrpDspOdr = i;
                //�X�V�敪= 0:�V�K
                pccItemGrp.UpdateFlag = 0;
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                pccItemGrp.ItemGrpImgCode = pMPCC09040U.GetItemGrpImgCode();
                // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                //PCC�i�ڐݒ�}�X�^���X�g
                Dictionary<int, PccItemSt> pccItemStList = null;
                //��ʂ̃O���b�h����PCC�i�ڐݒ�}�X�^���X�g���擾
                pMPCC09040U.GridToPccItem(out pccItemStList, pccItemGrid, i);
                if (pccItemStList != null && pccItemStList.Count > 0)
                {
                    if (pccItemStDict == null)
                    {
                        pccItemStDict = new Dictionary<int, Dictionary<int, PccItemSt>>();
                    }
                    //PCC�i�ڐݒ�f�B�N�V���i���[��ǉ�
                    pccItemStDict.Add(i, pccItemStList);
                }

                //���TAB�̕\������
                switch (i)
                {
                    case 1:
                        {
                            pccItemGrid.ItemGroupCode1 = i;
                            //���TAB1�̕\������
                            pccItemGrid.ItemGroupName1 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr1 = i;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode1 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 2:
                        {
                            pccItemGrid.ItemGroupCode2 = i;
                            pccItemGrid.ItemGroupName2 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr2 = i;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode2 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 3:
                        {
                            pccItemGrid.ItemGroupCode3 = i;
                            pccItemGrid.ItemGroupName3 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr3 = i;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode3 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 4:
                        {
                            pccItemGrid.ItemGroupCode4 = i;
                            pccItemGrid.ItemGroupName4 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr4 = i;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode4 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                    case 5:
                        {
                            pccItemGrid.ItemGroupCode5 = i;
                            pccItemGrid.ItemGroupName5 = eachTab.Text;
                            pccItemGrid.ItemGrpDspOdr5 = i;
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            pccItemGrid.ItemGrpImgCode5 = pMPCC09040U.GetItemGrpImgCode();
                            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            break;
                        }
                }
                //���PCC�i�ڃO���[�v���X�g��ǉ�
                if (pccItemGrpDic == null)
                {
                    pccItemGrpDic = new Dictionary<int, PccItemGrp>();
                }
                pccItemGrpDic.Add(pccItemGrp.ItemGroupCode, pccItemGrp);
                i++;
            }
        }

        /// <summary>
        /// PCC�i�ړo�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : PCC�i�ړo�^���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool SaveProc()
        {
            int dummy = 0;
            Control control = null;
            string message = null;
            int pccCompanyCode = 0;
            UltraTab selectedTab = this.UTabControl_StayInfo.Tabs[0];
            PccItemGrid pccItemGrid = null;
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null;
            if (this.DataIndex >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
                pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[guid]).Clone();
            }
            else
            {
                pccItemGrid = new PccItemGrid();
                pccItemGrid.InqOtherEpCd = this._inqOtherEpCd;
                pccItemGrid.InqOtherSecCd = this._inqOtherSecCd;
            
            }

            // ���O�C��ID�d���`�F�b�N�p�ϐ��Z�b�g
            if (pccItemGrid != null)
            {
                pccCompanyCode = this.tNedit_CustomerCode.GetInt();
              
            }
            pccItemGrid.PccCompanyCode = pccCompanyCode;
            pccItemGrid.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            pccItemGrid.InqOriginalSecCd = this._inqOriginalSecCd;
            pccItemGrid.InqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();//@@@@20230303
            if (!ScreenDataCheck(ref control, ref message, ref selectedTab, pccCompanyCode))
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.UTabControl_StayInfo.SelectedTab = selectedTab;
                control.Focus();
                if (control == this.UTabControl_StayInfo)
                {
                    ReButtonProc(0);
                }
                    
                return false;
            }

            //�i�ڃO���[�v�N���X�ݒ�
            DispToPccItemGrp(ref pccItemGrpList, ref pccItemStDict, ref pccItemGrid);
           
            int status = this._pccItemGrpAcs.Write(ref pccItemGrid, ref pccItemGrpList, ref pccItemStDict);
            this.ClearProc();
                        
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Search(ref dummy, 0);
                       
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        UTabControl_StayInfo.Tabs[0].Selected = true;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);
                        this.tNedit_CustomerCode.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccItemGrpAcs);

                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "SaveProc",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccItemGrpAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "SaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._pccItemGrpAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }
            NewEntryTransaction();
            return true;
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="selectedTab">�I�������s����</param>
        /// <param name="pccCompanyCode">���Ӑ�R�[�h</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, ref UltraTab selectedTab, int pccCompanyCode)
        {


            string pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() + this._inqOtherEpCd.TrimEnd() + this._inqOtherSecCd.TrimEnd();//@@@@20230303
            if (_pccItemGrpDict != null && _pccItemGrpDict.Count > 0)
            {
                if (this._pccItemGrpDict.ContainsKey(pccInqCondition) && this.Mode_Label.Text.Equals(INSERT_MODE))
                {
                    // ���Ӑ�R�[�h
                    control = this.tNedit_CustomerCode;
                    message = this.uLabel_CustomerTitle.Text + "�͑��݂��܂����B���̒l����͂��ĉ������B";
                    this.tNedit_CustomerCode.Enabled = true;
                    this.UButton_CustomerGuide.Enabled = true;
                    this.tNedit_CustomerCode.SetInt(0);
                    this.uLabel_CustomerTitle.Text = string.Empty;
                    selectedTab = this.UTabControl_StayInfo.Tabs[0];
                    return (false);
                }
            }
            int i = 1;
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            { 
                if(String.IsNullOrEmpty(eachTab.Text.TrimEnd()))
                {
                    // Tab��
                    control = this.UTabControl_StayInfo;
                    message = "�^�u������͂��Ă��������B";
                    selectedTab = eachTab;
                    return (false);
                }
                i++;
            }
            if (string.IsNullOrEmpty(this._inqOriginalSecCd) && tNedit_CustomerCode.GetInt() != 0)
            {
                // ���Ӑ�R�[�h
                control = this.tNedit_CustomerCode;
                message = this.uLabel_CustomerTitle.Text + "�̓��Ӑ��ƃR�[�h�͑��݂��܂���B���̒l����͂��ĉ������B";
                this.tNedit_CustomerCode.Enabled = true;
                this.UButton_CustomerGuide.Enabled = true;
                this.tNedit_CustomerCode.SetInt(0);
                this.uLabel_CustomerTitle.Text = string.Empty;
                return (false);
            }
            if (string.IsNullOrEmpty(this._inqOriginalSecCd) && tNedit_CustomerCode.GetInt() != 0)
            {
                // ���Ӑ�R�[�h
                control = this.tNedit_CustomerCode;
                message = this.uLabel_CustomerTitle.Text + "�̓��Ӑ拒�_�R�[�h�͑��݂��܂���B���̒l����͂��ĉ������B";
                this.tNedit_CustomerCode.Enabled = true;
                this.UButton_CustomerGuide.Enabled = true;
                this.tNedit_CustomerCode.SetInt(0);
                this.uLabel_CustomerTitle.Text = string.Empty;
                return (false);
            }
            return true;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_801_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// PCC�i��Tab�폜
        /// </summary>
        /// <param name="selectedTab">Tab</param>
        /// <remarks>
        /// <br>Note       : PCC�i��Tab�폜���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void DeleteTabProc(UltraTab selectedTab)
        {
            int tabCount = this.UTabControl_StayInfo.Tabs.Count;  
            if (tabCount == 1)
            {
                if (selectedTab != null && selectedTab.Tag != null)
                {
                    PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)selectedTab.Tag;
                    pMPCC09040UB.ClearTable();
                    selectedTab.Text = string.Empty;
                    this._deleteTabButtonTool.SharedProps.Enabled = false;
                }
            }
            else
            {
                UTabControl_StayInfo.Tabs.Remove(selectedTab);
                
            }
            tabCount = this.UTabControl_StayInfo.Tabs.Count;
            //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
            // BL�R�[�h�`�F�b�N�e�v�b���擾����
            this._blCheckedInfoTb = new Hashtable();
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            {
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)eachTab.Tag;
                pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                pMPCC09040UB.InitBlCheckedTb();
                this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
            }
            //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
            if (tabCount >= MAX_TABCOUNT)
            {
                this._newTabButtonTool.SharedProps.Enabled = false;
            }
            else
            {
                this._newTabButtonTool.SharedProps.Enabled = true;
            }
        }

        /// <summary>
        /// PCC�i�ڃN���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC�i�ڃN���A���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ClearProc()
        {
            tNedit_CustomerCode.SetInt(0);
            UltraTab selectedTab = null;
            uLabel_CustomerName.Text = string.Empty;
            int count = UTabControl_StayInfo.Tabs.Count;
            for (int i = count - 1; i > 0; i--)
            {
                selectedTab = UTabControl_StayInfo.Tabs[i];
                this.DeleteTabProc(selectedTab);
            }
            selectedTab = UTabControl_StayInfo.Tabs[0];
            
            selectedTab.Text = string.Empty;
            //�⍇������ƃR�[�h
            _inqOriginalEpCd = string.Empty;
            //�⍇�������_�R�[�h
            _inqOriginalSecCd = string.Empty;
            //�O�⍇������ƃR�[�h
           _inqOriginalEpCdPre = string.Empty;
            //�O�⍇�������_�R�[�h
            _inqOriginalSecCdPre = string.Empty;
            if (selectedTab != null && selectedTab.Tag != null)
            {
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)selectedTab.Tag;
                pMPCC09040UB.ClearTable();
                selectedTab.Key = TODELKEY;
                selectedTab.Text = string.Empty;
            }
            this._startMode = (int)StartMode.MODE_NEW;
            // ��ʓ��͋����䏈��
            ScreenInputPermissionControl(this._startMode);
            this.tNedit_CustomerCode.Focus();
            this.Mode_Label.Text = INSERT_MODE;
            _prevCustomerCode = -1;
            _firstCustomerCode = 0;
            //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
            // BL�R�[�h�`�F�b�N�e�v�b���擾����
            this._blCheckedInfoTb = new Hashtable();
            foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
            {
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)eachTab.Tag;
                pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                pMPCC09040UB.InitBlCheckedTb();
                this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
            }
            //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<
        }

        /// <summary>
        /// PCC�i�ڕ����폜
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC�i�ڊ��S�폜���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void AllDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.Yes)
            {
                return;
            }
            string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[guid]).Clone();
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null;
            if (pccItemGrid != null && this._pccItemGrpDict != null
                && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
            }

            if (pccItemGrid != null && this._pccItemStDictDict != null
                && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
            }

            int dummy = 0;
            status = this._pccItemGrpAcs.Delete(ref pccItemGrid, ref pccItemGrpList, ref pccItemStDict);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (pccItemGrid != null && this._pccItemGrpDict != null
                            && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemGrpDict.Remove(pccItemGrid.InqCondition);
                        }

                        if (pccItemGrid != null && this._pccItemStDictDict != null
                            && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemStDictDict.Remove(pccItemGrid.InqCondition);
                        }
                        // DataSet�X�V
                        this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex].Delete();
                        // �n�b�V���e�[�u������폜���܂�
                        if (this._pccItemGrpTable.ContainsKey(pccItemGrid.FileHeaderGuid) == true)
                        {
                            this._pccItemGrpTable.Remove(pccItemGrid.FileHeaderGuid);
                        }
                        this.ClearProc();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        this.UTabControl_StayInfo.SelectedTab = this.UTabControl_StayInfo.Tabs[0];
                        UTabControl_StayInfo.Tabs[0].Selected = true;
                        PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)UTabControl_StayInfo.Tabs[0].Tag;
                        pMPCC09040UB.SetInitFocus(this._startMode);
                        this.tNedit_CustomerCode.Focus();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccItemGrpAcs);

                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                       
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Delete",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccItemGrpAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Delete",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._pccItemGrpAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        break;
                       
                      
                    }
            }
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// PCC�i��TAB���ύX
        /// </summary>
        /// <param name="newTabFalg">AB���V�KFLAF</param>
        /// <remarks>
        /// <br>Note       : PCC�i��TAB���ύX���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ReButtonProc(int newTabFalg)
        {
            UltraTab selectedTab = UTabControl_StayInfo.SelectedTab;
            
            _pMPCC09040UC = new PMPCC09040UC();
            _pMPCC09040UC.TabName = selectedTab.Text.TrimEnd();
            this._pMPCC09040UC.ShowDialog();
            DialogResult dialogResult = this._pMPCC09040UC.DialogResult;
            if (DialogResult.OK == dialogResult)
            {
                selectedTab.Text = _pMPCC09040UC.TabName;
            }
            else if (DialogResult.No == dialogResult)
            {
                selectedTab.Text = string.Empty;
                PMPCC09040UB pMPCC09040UB = (PMPCC09040UB)selectedTab.Tag;
                pMPCC09040UB.ClearTable();
                //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 ----->>>>>
                // BL�R�[�h�`�F�b�N�e�v�b���擾����
                this._blCheckedInfoTb = new Hashtable();
                foreach (UltraTab eachTab in this.UTabControl_StayInfo.Tabs)
                {
                    PMPCC09040UB pMPCC09040UBEach = (PMPCC09040UB)eachTab.Tag;
                    pMPCC09040UB.BlCheckedInfoTb = this._blCheckedInfoTb;
                    pMPCC09040UB.InitBlCheckedTb();
                    this._blCheckedInfoTb = pMPCC09040UB.BlCheckedInfoTb;
                }
                //-----ADD by huanghx for #25387 BL�p�[�c�I�[�_�[�i�ڐݒ�̃`�F�b�N�{�b�N�X���� on 20110921 -----<<<<<

            }
        }

        /// <summary>
        /// PCC�i�ڊ��S����
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC�i�ڊ��S�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void ReviveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // �����m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���ݕ\�����̕i�ڐݒ�}�X�^�𕜊����܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.Yes)
            {
                return;
            }
            string guid = (string)this.Bind_DataSet.Tables[PCCITEM_TABLE].Rows[this._dataIndex][INQCONDITION_TITLE];
            PccItemGrid pccItemGrid = ((PccItemGrid)this._pccItemGrpTable[guid]).Clone();
            List<PccItemGrp> pccItemGrpList = null;
            Dictionary<int, List<PccItemSt>> pccItemStDict = null;
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            if (pccItemGrid != null && this._pccItemGrpDict != null
                && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemGrpList = this._pccItemGrpDict[pccItemGrid.InqCondition];
            }

            if (pccItemGrid != null && this._pccItemStDictDict != null
                && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
            {
                pccItemStDict = this._pccItemStDictDict[pccItemGrid.InqCondition];
            }


            int dummy = 0;
            status = this._pccItemGrpAcs.RevivalLogicalDelete(ref pccItemGrid, ref pccItemGrpList, ref pccItemStDict);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (pccItemGrid != null && this._pccItemGrpDict != null
                            && this._pccItemGrpDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemGrpDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemGrpDict.Add(pccItemGrid.InqCondition, pccItemGrpList);
                        }

                        if (pccItemGrid != null && this._pccItemStDictDict != null
                            && this._pccItemStDictDict.ContainsKey(pccItemGrid.InqCondition))
                        {
                            this._pccItemStDictDict.Remove(pccItemGrid.InqCondition);
                            this._pccItemStDictDict.Add(pccItemGrid.InqCondition, pccItemStDict);
                        }
                        //  �f�[�^�Z�b�g�W�J����
                        PccItemGridToDataSet(pccItemGrid.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccItemGrpAcs);
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "ReviveProc",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccItemGrpAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);

                        break;
                    }

                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ReviveProc",							// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._pccItemGrpAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pccItemGrpTable.Clear();
                        this.Search(ref dummy, 0);
                        break;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            this.ClearProc();
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011/07/20</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
           
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ���p�{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���p�{�^���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void QuoteButtonProc()
        {

            _pMPCC09040UD = new PMPCC09040UD(this._pccItemGrpDict);
            string inqCondition = string.Empty;
            int customerCode = 0;
            this._pMPCC09040UD.ShowDialog();
            DialogResult dialogResult = this._pMPCC09040UD.DialogResult;
            if (DialogResult.OK == dialogResult)
            {
                inqCondition = this._pMPCC09040UD.PccInqCondition;
                customerCode = this._pMPCC09040UD.CustomCode;
                int count = UTabControl_StayInfo.Tabs.Count;
                UltraTab selectedTab = null;
                UTabControl_StayInfo.Tabs[0].Selected = true;
                for (int i = count - 1; i > 0; i--)
                {
                    selectedTab = UTabControl_StayInfo.Tabs[i];
                    this.DeleteTabProc(selectedTab);
                }
                List<PccItemGrp> pccItemGrpList = null;
                if(this._pccItemGrpDict != null && this._pccItemGrpDict.ContainsKey(inqCondition))
                {
                    pccItemGrpList = this._pccItemGrpDict[inqCondition];
                }
                Dictionary<int, List<PccItemSt>> pccItemStDict = null;
                if (pccItemGrpList != null)
                {
                    if (this._pccItemStDictDict != null && this._pccItemStDictDict.Count > 0
                        && this._pccItemStDictDict.ContainsKey(inqCondition))
                    {
                        pccItemStDict = this._pccItemStDictDict[inqCondition];
                    }
                    PccItemToScreen(pccItemGrpList, pccItemStDict);
                
                }
                selectedTab = UTabControl_StayInfo.Tabs[0];
                this.DeleteTabProc(selectedTab);
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl((int)StartMode.MODE_EDIT);
                UTabControl_StayInfo.Tabs[0].Selected = true;
                // �{�^���ݒ�
                if (pccItemGrpList.Count == 1)
                {
                    this._deleteTabButtonTool.SharedProps.Enabled = false;
                }
                else
                {
                    this._deleteTabButtonTool.SharedProps.Enabled = true;
                }
                if (pccItemGrpList.Count == MAX_TABCOUNT)
                {
                    this._newTabButtonTool.SharedProps.Enabled = false;
                }
                else
                {
                    this._newTabButtonTool.SharedProps.Enabled = true;
                }
            }
           
        }

        #region ���Аݒ蓾�Ӑ�ݒ�}�X�^�擾����
        /// <summary>
        /// ���Аݒ蓾�Ӑ�ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Аݒ蓾�Ӑ�ݒ�}�X�^���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public void GetCustomerHTable()
        {
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._inqOtherSecCd;
            List<PccCmpnySt> pccCmpnyStList = null;
            if (this._customerHTable == null)
            {
                this._customerHTable = new Dictionary<int, PccCmpnySt>();
            }
            else
            {
                this._customerHTable.Clear();
            }
            PccCmpnySt pccCmpnySt0 = new PccCmpnySt();
            pccCmpnySt0.PccCompanyCode = 0;
            pccCmpnySt0.PccCompanyName = CUSTOMEMPTY_BASE;
            pccCmpnySt0.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt0.InqOtherSecCd = this._inqOtherSecCd;
            pccCmpnySt0.InqOriginalEpCd = string.Empty;
            pccCmpnySt0.InqOriginalSecCd = string.Empty;
            this._customerHTable.Add(pccCmpnySt0.PccCompanyCode, pccCmpnySt0);
            int status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    if (!this._customerHTable.ContainsKey(pccCmpnySt.PccCompanyCode))
                    {
                        this._customerHTable.Add(pccCmpnySt.PccCompanyCode, pccCmpnySt);
                    }
                }
            }

        }
        #endregion

        #endregion
       
    }
}